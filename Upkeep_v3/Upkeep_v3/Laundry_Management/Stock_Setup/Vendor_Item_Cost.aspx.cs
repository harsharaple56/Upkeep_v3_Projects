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
    public partial class Vendor_Item_Cost : System.Web.UI.Page
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

                bindVendor();
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
            int Vendor_ID = Convert.ToInt32(ddlVendor.SelectedValue);
            int Cost;
            Cost = Convert.ToInt32(txtCost.Text);
            
            ds = ObjUpkeep.LMS_Vendor_Cost(0, Vendor_ID, Item_ID, Cost, "", "", LoggedInUserID, "C", CompanyID);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                    if (Status == 1)
                    {
                        Response.Redirect(Page.ResolveClientUrl("~/Laundry_Management/Stock_Setup/Vendor_Item_Cost.aspx"), false);
                    }
                    else if (Status == 3)
                    {
                        lblStockErrorMsg.Text = "Cost already exists against this Item & Vendor";
                    }
                    else if (Status == 2)
                    {
                        lblStockErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                    }
                }
            }


        }

        public string Fetch_ItemCost_Details()
        {
            DataSet ds_ItemStock = new DataSet();
            string data = "";

            try
            {

                ds_ItemStock = ObjUpkeep.LMS_Vendor_Cost(0, 0, 0, 0, "", "", "", "R", CompanyID);

                if (ds_ItemStock.Tables.Count > 0)
                {
                    if (ds_ItemStock.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds_ItemStock.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Cost_ID = Convert.ToInt32(ds_ItemStock.Tables[0].Rows[i]["Cost_ID"]);
                            string Vendor_Desc = Convert.ToString(ds_ItemStock.Tables[0].Rows[i]["Vendor_Name"]);
                            string Item_Desc = Convert.ToString(ds_ItemStock.Tables[0].Rows[i]["Item_Desc"]);
                            int Cost = Convert.ToInt32(ds_ItemStock.Tables[0].Rows[i]["Cost"]);
                            string Valid_From = Convert.ToString(ds_ItemStock.Tables[0].Rows[i]["Valid_From"]);
                            string Valid_To = Convert.ToString(ds_ItemStock.Tables[0].Rows[i]["Valid_To"]);
                            string Created_By = Convert.ToString(ds_ItemStock.Tables[0].Rows[i]["Created_By"]);
                            string Created_Date = Convert.ToString(ds_ItemStock.Tables[0].Rows[i]["Created_Date"]);



                            data += "<tr><td>" + Vendor_Desc + "</td><td>" + Item_Desc + "</td><td>" + Cost + "</td><td>" + Created_By + "</td><td>" + Created_Date + "</td><td><a href='Add_User_Mst.aspx?User_ID=" + Cost_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top'> <i class='la la-edit'></i> </a>  <a href='Add_User_Mst.aspx?DelUser_ID=" + Cost_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' > 	<i class='la la-trash'></i> </a> </td></tr>";
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


        public void bindVendor()
        {
            try
            {
                CompanyID = Convert.ToInt32(Session["CompanyID"]);
                DataSet ds = new DataSet();

                ds = ObjUpkeep.LMS_Vendor_Cost(0, 0, 0,0, "", "", "", "Fetch_Vendor", CompanyID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlVendor.DataSource = ds.Tables[0];
                        ddlVendor.DataTextField = "Vendor_Name";
                        ddlVendor.DataValueField = "Vendor_ID";
                        ddlVendor.DataBind();
                        ddlVendor.Items.Insert(0, new ListItem("--Select--", "0"));
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