using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using System.Globalization;

namespace Upkeep_v3.Inventory
{
    public partial class Inventory_Stock_Detail : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();

        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            int StockID = 0;
            ViewState["Stock_ID"] = 0;
            if (Request.QueryString["Stock_ID"] != null)
            {
                StockID = Convert.ToInt32(Request.QueryString["Stock_ID"]);
                ViewState["Stock_ID"] = StockID;
            }

            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);


            //LoggedInUserID = "3";
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }

            if (!IsPostBack)
            {

                Session["Stock_ID"] = 0;
                if (StockID > 0)
                {
                    Session["Stock_ID"] = Convert.ToString(StockID); 
                }

                Fetch_Bind_DropDown();

                if (StockID > 0)
                {
                    Session["Stock_ID"] = Convert.ToString(StockID);
                    DisplayData(StockID);
                }
            }

        }
        public void Fetch_Bind_DropDown()
        {
            DataSet dsTitle = new DataSet();
            string Initiator = string.Empty;
            try
            {
                dsTitle = ObjUpkeep.Fetch_Inv_Item_Stock_Ddl(Convert.ToString(Session["LoggedInUserID"]), Convert.ToString(Session["CompanyID"]), Convert.ToString(Session["Stock_ID"]) );
                 
                if (dsTitle.Tables.Count > 0)
                {
                    if (dsTitle.Tables[0].Rows.Count > 0)
                    {
                        ddlItems.DataSource = dsTitle.Tables[0];
                        ddlItems.DataTextField = "Items";
                        ddlItems.DataValueField = "Item_ID";
                        ddlItems.DataBind();
                        ddlItems.Items.Insert(0, new ListItem("--Select--", "0"));
                    }

                    if (dsTitle.Tables[1].Rows.Count > 0)
                    {
                        ddlDepartment.DataSource = dsTitle.Tables[1];
                        ddlDepartment.DataTextField = "Dept_Desc";
                        ddlDepartment.DataValueField = "Department_ID";
                        ddlDepartment.DataBind();
                        ddlDepartment.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                     
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DisplayData(int StockID)
        {

            DataSet dsData = new DataSet();
            try
            {
                dsData = ObjUpkeep.Fetch_Inv_Item_Stock_Data(Convert.ToString(Session["LoggedInUserID"]), Convert.ToString(Session["CompanyID"]), Convert.ToString(StockID));
                if (dsData.Tables.Count > 0)
                { 

                    if (dsData.Tables[0].Rows.Count > 0)
                    {
                        /*
                         Stock_ID,Item_ID,Opening_Stock,Optimum_Value,Reorder_Value,Base_Value,Cost_Rate,Department_ID , Current_Stock
                         */

                        ddlItems.SelectedValue = dsData.Tables[0].Rows[0]["Item_ID"].ToString();
                        txtItems.Text = dsData.Tables[0].Rows[0]["Items"].ToString();

                        txtOpeningStockValue.Value = dsData.Tables[0].Rows[0]["Opening_Stock"].ToString();
                        txtOptimumValue.Value = dsData.Tables[0].Rows[0]["Optimum_Value"].ToString();
                        txtReorderValue.Value = dsData.Tables[0].Rows[0]["Reorder_Value"].ToString();
                        txtBaseValue.Value = dsData.Tables[0].Rows[0]["Base_Value"].ToString();
                        txtCostRate.Value = dsData.Tables[0].Rows[0]["Cost_Rate"].ToString();
                        ddlDepartment.SelectedValue = dsData.Tables[0].Rows[0]["Department_ID"].ToString();
                        txtCurrentStock.Value = dsData.Tables[0].Rows[0]["Current_Stock"].ToString();

                        ddlItems.Visible = false;

                        txtOpeningStockValue.Attributes.Add("Readonly", "Readonly");
                        txtCostRate.Attributes.Add("Readonly", "Readonly"); 


                    }
                     

                }
                 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        { 

            int Status = 0;
            DataSet ds = new DataSet();

            int StckId = 0;
            if ((int)ViewState["Stock_ID"] > 0)
            {
                StckId = (int)ViewState["Stock_ID"];
            }

            //PROCESS DATA
            string strAssetData = "";
            strAssetData = SaveData();
            ds = ObjUpkeep.Fetch_Inv_Crud_Item_Stock(Convert.ToString(Session["LoggedInUserID"]), Convert.ToString(Session["CompanyID"]), Convert.ToString(StckId), strAssetData );
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                    ViewState["Stock_ID"] = Convert.ToString(ds.Tables[0].Rows[0]["StockID"]);
                    Session["Stock_ID"] = Convert.ToString(ds.Tables[0].Rows[0]["StockID"]);
                }
            }

            //DISPLAY RESPONSE
            if (Status == 1)
            {
                lblErrorMsg.Text = "Due to some technical issue, Request Cannot be Processed. Kindly try after some time";
            }
            else if (Status == 2)
            {
                //lblErrorMsg.Text = "OKAY";
                //lblWpRequestCode.Text = Convert.ToString(ViewState["RequestAssetID"]).ToString();
                //mpeWpRequestSaveSuccess.Show();
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Data saved successfully')</script>");
                return;
            }
            else if (Status == 3)
            {
                lblErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
            }
            else
            {
                lblErrorMsg.Text = "Error Occured !!!";
            }
        }
       

        #region Generate XML For Processing  

        private string SaveData()
        {

            /*
             Stock_ID, Item_ID, Opening_Stock, Optimum_Value, Reorder_Value, Base_Value, Cost_Rate, Department_ID, Current_Stock, 
             Created_By, Created_Date, Updated_By, Updated_Date, Is_Deleted, Company_ID
             */

            //int StckId = 0;
            //if ((int)ViewState["Stock_ID"] > 0)
            //{
            //    StckId = (int)ViewState["Stock_ID"];
            //}

            StringBuilder strXmlAsset = new StringBuilder();
            //strXmlAsset.Append(@"<?xml version=""1.0"" ?>");
            strXmlAsset.Append(@"<DocumentElement>");
            strXmlAsset.Append(@"<Items>");

            //-------------------------------------------------------------------------------------------------------------------
           // strXmlAsset.Append(@"<Stock_ID>" + StckId + "</Stock_ID>");
            strXmlAsset.Append(@"<Item_ID>" + ddlItems.SelectedValue.ToString() + "</Item_ID>");
            strXmlAsset.Append(@"<Item_Name>" + txtItems.Text + "</Item_Name>");
            strXmlAsset.Append(@"<Opening_Stock>" + txtOpeningStockValue.Value.ToString() + "</Opening_Stock>");
            strXmlAsset.Append(@"<Optimum_Value>" + txtOptimumValue.Value.ToString() + "</Optimum_Value>");
            strXmlAsset.Append(@"<Reorder_Value>" + txtReorderValue.Value.ToString() + "</Reorder_Value>");
            strXmlAsset.Append(@"<Base_Value>" + txtBaseValue.Value.ToString() + "</Base_Value>");
            strXmlAsset.Append(@"<Cost_Rate>" + txtCostRate.Value.ToString() + "</Cost_Rate>");
            strXmlAsset.Append(@"<Department_ID>" + ddlDepartment.SelectedValue.ToString() + "</Department_ID>");
            //-------------------------------------------------------------------------------------------------------------------
            strXmlAsset.Append(@"</Items>");
            strXmlAsset.Append(@"</DocumentElement>");

            return strXmlAsset.ToString();
        }
        #endregion


      
    }


  

}