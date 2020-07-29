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

namespace Upkeep_v3.Inventory
{
    public partial class Inventory_Stock_List : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);

            }
            if (!IsPostBack)
            {
                Session["PreviousURL"] = HttpContext.Current.Request.Url.AbsoluteUri;
                BindDropDown();
            }

        }
        public void BindDropDown()
        {
            try
            {
                DataSet dsTitle = new DataSet();

                dsTitle = ObjUpkeep.Fetch_Inv_Item_Stock_Ddl(Convert.ToString(Session["LoggedInUserID"]), Convert.ToString(Session["CompanyID"]), Convert.ToString(Session["Stock_ID"]));

                if (dsTitle.Tables.Count > 0)
                {
                    if (dsTitle.Tables[1].Rows.Count > 0)
                    {
                        ddlDepartment.DataSource = dsTitle.Tables[1];
                        ddlDepartment.DataTextField = "Dept_Desc";
                        ddlDepartment.DataValueField = "Department_ID";
                        ddlDepartment.DataBind();
                        ddlDepartment.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    if (dsTitle.Tables[2].Rows.Count > 0)
                    {
                        ddlCategory.DataSource = dsTitle.Tables[2];
                        ddlCategory.DataTextField = "Category_Desc";
                        ddlCategory.DataValueField = "Category_ID";
                        ddlCategory.DataBind();
                        ddlCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                    }

                    if (dsTitle.Tables[3].Rows.Count > 0)
                    {
                        ddlSubCategory.DataSource = dsTitle.Tables[3];
                        ddlSubCategory.DataTextField = "SubCategory_Desc";
                        ddlSubCategory.DataValueField = "SubCategory_ID";
                        ddlSubCategory.DataBind();

                        for (int i = 0; i < ddlSubCategory.Items.Count; i++)
                            ddlSubCategory.Items[i].Attributes["data-isMulti"] = dsTitle.Tables[3].Rows[i]["Category_ID"].ToString();

                        ddlSubCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string fetchInvStockListing()
        {
            string data = "";

            try
            {

                DataSet ds = new DataSet();

                if (LoggedInUserID == "")
                {
                    return "";
                }

                ds = ObjUpkeep.Fetch_Stock_List(LoggedInUserID, Session["CompanyID"].ToString());

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            string Stock_ID = Convert.ToString(ds.Tables[0].Rows[i]["Stock_ID"]);
                            string Item_ID = Convert.ToString(ds.Tables[0].Rows[i]["Item_ID"]);
                            string Items = Convert.ToString(ds.Tables[0].Rows[i]["Items"]);
                            string Department = Convert.ToString(ds.Tables[0].Rows[i]["Department"]);
                            string Category = Convert.ToString(ds.Tables[0].Rows[i]["Category"]);
                            string Sub_Category = Convert.ToString(ds.Tables[0].Rows[i]["Sub_Category"]);
                            string Balance = Convert.ToString(ds.Tables[0].Rows[i]["Balance"]);


                            data += "<tr>" +
                                //"<td>" + "<input type='checkbox' id='" + Stock_ID + "' name='" + Stock_ID + "' value ='" + Stock_ID + "'>" + "</td>" +
                                "<td>" + Items + "</td>" +
                                "<td>" + Department + "</td>" +
                                "<td>" + Category + "</td>" +
                                "<td>" + Sub_Category + "</td>" +
                                "<td>" + Balance + "</td>" +
                                "<td><a href='Inventory_Stock_Detail.aspx?Stock_ID=" + Stock_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record'> <i class='la la-edit'></i> </a>  " +
                                "<a href='#' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation removeItem' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record' data-config-id='" + Stock_ID + "'><i class='la la-trash'></i> </a> " +
                                "</tr>";
                        }
                    }
                    else
                    {
                        //invalid login
                    }
                }
                else
                {
                    //invalid login
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

        public string DeleteInvStockListing()
        {
            if (hdnDeleteID.Value != "")
            {
                ObjUpkeep.Delete_Inv_Stock(Convert.ToInt32(hdnDeleteID.Value.ToString()), LoggedInUserID);
            }
            hdnDeleteID.Value = "";

            return "";
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteInvStockListing();
        }

        //protected void btnPrintAll_Click(object sender, EventArgs e)
        //{
        //    if (hdnPrntD.Value != "")
        //    {
        //        string founderMinus1 = hdnPrntD.Value.TrimEnd(',');
        //        Session["PrintIdList"] = "";
        //        Session["PrintIdList"] = founderMinus1;

        //        Response.Redirect("ReportViewer.aspx");
        //    }
        //    hdnPrntD.Value = "";
        //}


        //protected void btnPopup_Click(object sender, EventArgs e)
        //{
        //}
        protected void btnModalsubmit_Click(object sender, EventArgs e)
        {

            int Status = 0;
            DataSet ds = new DataSet();

            int StckId = 0;

            //PROCESS DATA 
            StringBuilder strXmls = new StringBuilder();
            strXmls.Append(@"<DocumentElement>");
            strXmls.Append(@"<Items>");

            //-------------------------------------------------------------------------------------------------------------------
            strXmls.Append(@"<Category>" + ddlCategory.SelectedValue.ToString() + "</Category>");
            strXmls.Append(@"<SubCategory>" + ddlSubCategory.SelectedValue.ToString() + "</SubCategory>");
            strXmls.Append(@"<Item>" + txtItem.Text.ToString() + "</Item>");
            strXmls.Append(@"<Opening_Stock>" + txtOpening.Value.ToString() + "</Opening_Stock>");
            strXmls.Append(@"<Optimum_Value>" + txtOptinum.Value.ToString() + "</Optimum_Value>");
            strXmls.Append(@"<Reorder_Value>" + txtReOrder.Value.ToString() + "</Reorder_Value>");
            strXmls.Append(@"<Base_Value>" + txtBase.Value.ToString() + "</Base_Value>");
            strXmls.Append(@"<Cost_Rate>" + txtCost_rate.Value.ToString() + "</Cost_Rate>");
            strXmls.Append(@"<Department_ID>" + ddlDepartment.SelectedValue.ToString() + "</Department_ID>");
            //-------------------------------------------------------------------------------------------------------------------
            strXmls.Append(@"</Items>");
            strXmls.Append(@"</DocumentElement>");

            ds = ObjUpkeep.Fetch_Inv_Crud_Item(Convert.ToString(Session["LoggedInUserID"]), Convert.ToString(Session["CompanyID"]), Convert.ToString(StckId), strXmls.ToString());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]); 
                }
            }

            //DISPLAY RESPONSE
            if (Status == 1)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Item already Exists, please check.')</script>");
                return;
            }
            else if (Status == 2)
            {
                fetchInvStockListing();
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Data saved successfully')</script>");
                return;
            }
            else if (Status == 3)
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Due to some technical issue your request can not be process. Kindly try after some time')</script>");
                return;
             }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Error Occured !!!')</script>");
                return; 
            }
        }
    }
}