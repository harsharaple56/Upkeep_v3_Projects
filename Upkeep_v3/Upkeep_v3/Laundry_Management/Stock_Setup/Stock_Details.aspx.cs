using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Text;
using System.Data;
using System.Globalization;

namespace Upkeep_v3.Laundry_Management.Stock_Setup
{
    public partial class Stock_Details : System.Web.UI.Page
    {

        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {

            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            if (!IsPostBack)
            {
                //Fetch_Stock_Details();
                //Fetch_ItemStock_Details();

                bindDepartment();
                bindItems();
            }


        }

        protected void btnPopup_Click(object sender, EventArgs e)
        {
            //fetchInvItemSelectedListing();


        }
        protected void btnModalsubmit_Click(object sender, EventArgs e)
        {
            
            int Item_ID = Convert.ToInt32(ddlItems.SelectedValue);
            int Department_ID = Convert.ToInt32(ddlDept.SelectedValue);
            string Opening_Stock = string.Empty;
            string Optimum_Value = string.Empty;
            string ReOrder_Value = string.Empty;
            string Base_Value = string.Empty;
            Opening_Stock = txtOpeningStock.Text.Trim();
            Optimum_Value = txtOptimumValue.Text.Trim();
            ReOrder_Value = txtReOrderValue.Text.Trim();
            Base_Value = txtBaseValue.Text.Trim();

        ds = ObjUpkeep.INV_ItemStock_CRUD(0, Item_ID, Opening_Stock, Optimum_Value, ReOrder_Value, Base_Value, Department_ID, 0, CompanyID, LoggedInUserID, "C");

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                    if (Status == 1)
                    {
                        Session["User_ID"] = "";

                        Response.Redirect(Page.ResolveClientUrl("~/Laundry_Management/Stock_Setup/Stock_Details.aspx"), false);
                    }
                    else if (Status == 3)
                    {
                        lblStockErrorMsg.Text = "User, UserCode, MobileNo already exists";
                    }
                    else if (Status == 2)
                    {
                        lblStockErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                    }
                }
            }


        }

        public string Fetch_ItemStock_Details()
        {
            DataSet ds_ItemStock = new DataSet();
            string data = "";

            try
            {
                //ds = ObjUpkeep.INV_ItemMaster_CRUD(0, "", 0, 0, CompanyID, "", "R");
                ds_ItemStock = ObjUpkeep.INV_ItemStock_CRUD(0,0,"", "", "", "", 0, 0, CompanyID, "", "R");

                if (ds_ItemStock.Tables.Count > 0)
                {
                    if (ds_ItemStock.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds_ItemStock.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Stock_ID =Convert.ToInt32(ds_ItemStock.Tables[0].Rows[i]["Stock_ID"]);
                            string Item_Desc = Convert.ToString(ds_ItemStock.Tables[0].Rows[i]["Item_Desc"]);
                            int Opening_Stock = Convert.ToInt32(ds_ItemStock.Tables[0].Rows[i]["Opening_Stock"]);
                            int Optimum_Value = Convert.ToInt32(ds_ItemStock.Tables[0].Rows[i]["Optimum_Value"]);
                            int ReOrder_Value = Convert.ToInt32(ds_ItemStock.Tables[0].Rows[i]["ReOrder_Value"]);
                            int Base_Value = Convert.ToInt32(ds_ItemStock.Tables[0].Rows[i]["Base_Value"]);
                            string Dept_Desc = Convert.ToString(ds_ItemStock.Tables[0].Rows[i]["Dept_Desc"]);
                            int Current_Stock = Convert.ToInt32(ds_ItemStock.Tables[0].Rows[i]["Current_Stock"]);
                            string Created_By = Convert.ToString(ds_ItemStock.Tables[0].Rows[i]["Created_By"]); ;
                            string Created_Date = Convert.ToString(ds_ItemStock.Tables[0].Rows[i]["Created_Date"]);


                            data += "<tr><td>" + Item_Desc + "</td><td>" + Opening_Stock + "</td><td>" + Optimum_Value + "</td><td>" + ReOrder_Value + "</td><td>" + Base_Value + "</td><td>" + Dept_Desc + "</td><td>" + Current_Stock + "</td><td>" + Created_By + "</td><td>" + Created_Date + "</td><td><a href='Add_User_Mst.aspx?User_ID=" + Stock_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top'> <i class='la la-edit'></i> </a>  <a href='Add_User_Mst.aspx?DelUser_ID=" + Stock_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' > 	<i class='la la-trash'></i> </a> </td></tr>";
                        }
                    }
                    else
                    {

                    }
                }
                else
                {

                }

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void bindDepartment()
        {
            try
            {
                CompanyID = Convert.ToInt32(Session["CompanyID"]);
                DataSet ds = new DataSet();

                ds = ObjUpkeep.Fetch_Department(CompanyID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlDept.DataSource = ds.Tables[0];
                        ddlDept.DataTextField = "Department";
                        ddlDept.DataValueField = "Department_ID";
                        ddlDept.DataBind();
                        ddlDept.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void bindItems()
        {
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            try
            {
                DataSet ds = new DataSet();

                ds = ObjUpkeep.INV_Fetch_Items_List(CompanyID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlItems.DataSource = ds.Tables[0];
                        ddlItems.DataTextField = "Item_Desc";
                        ddlItems.DataValueField = "Item_ID";
                        ddlItems.DataBind();
                        ddlItems.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}