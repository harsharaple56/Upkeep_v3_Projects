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

namespace Upkeep_v3.Laundry_Management.Stock
{
    public partial class Stock_Details : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        DataSet ds = new DataSet();
        int Del_Item_ID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            Del_Item_ID = Convert.ToInt32(Request.QueryString["Del_Item_ID"]);

            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            if (!IsPostBack)
            {
                //Fetch_Stock_Details();
                bindCategory();
                //bind_SubCategory();
            }
            if (Del_Item_ID > 0)
            {
                Delete_Item(Del_Item_ID);
            }



        }

        protected void btnModalsubmit_Click(object sender, EventArgs e)
        {

            int Category_ID = Convert.ToInt32(ddl_Category.SelectedValue);
            int SubCategory_ID = Convert.ToInt32(ddl_SubCategory.SelectedValue);
            string Item_Desc = Convert.ToString(txtItem_Desc.Text);
            

            ds = ObjUpkeep.LMS_ItemMaster_CRUD(0, Item_Desc, Category_ID, SubCategory_ID, CompanyID, LoggedInUserID, "C");

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                    if (Status == 1)
                    {
                        Response.Redirect(Page.ResolveClientUrl("~/Laundry_Management/Stock_Setup/Item_Details.aspx"), false);
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



        protected void btnPopup_Click(object sender, EventArgs e)
        {
            //fetchInvItemSelectedListing();
        }
        

        public string Fetch_Stock_Details()
        {
            string data = "";

            try
            {
                //ds = ObjUpkeep.INV_ItemMaster_CRUD(0, "", 0, 0, CompanyID, "", "R");
                ds = ObjUpkeep.LMS_ItemMaster_CRUD(0, "", 0, 0, CompanyID, "", "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Item_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Item_ID"]);
                            string Item_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Item_Desc"]);
                            string Category_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Category_Desc"]);
                            string SubCategory_Desc = Convert.ToString(ds.Tables[0].Rows[i]["SubCategory_Desc"]);


                            data += "<tr><td>" + Item_ID + "</td><td>" + Item_Desc + "</td><td>" + Category_Desc + "</td><td>" + SubCategory_Desc + "</td><td><a href='Item_Details.aspx?Del_Item_ID=" + Item_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top'> <i class='la la-edit'></i> </a>  <a href='Items_Details.aspx?Del_Item_ID=" + Item_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' > 	<i class='la la-trash'></i> </a> </td></tr>";
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


        public void Delete_Item(int Del_Item_ID)

        {
            try
            {
                DataSet ds = new DataSet();

                ds = ds = ObjUpkeep.LMS_ItemMaster_CRUD(Del_Item_ID, "", 0, 0, CompanyID, "", "D");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //Response.Redirect("~/General_Masters/User_Mst.aspx", false);
                        Response.Redirect(Page.ResolveClientUrl("~/General_Masters/User_Mst.aspx"), false);
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


        }



        public void bindCategory()
        {
            try
            {
                CompanyID = Convert.ToInt32(Session["CompanyID"]);
                DataSet ds = new DataSet();

                ds = ObjUpkeep.LMS_Category_Mst(0,"",CompanyID,LoggedInUserID,"R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddl_Category.DataSource = ds.Tables[0];
                        ddl_Category.DataTextField = "Category_Desc";
                        ddl_Category.DataValueField = "Category_ID";
                        ddl_Category.DataBind();
                        ddl_Category.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
                else
                {
                    Response.Redirect(Page.ResolveClientUrl("~/Laundry_Management/Stock_Setup/Setup.aspx"), false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void ddl_SubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind_SubCategory();
        }

        public void bind_SubCategory()
        {
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            int CategoryID = Convert.ToInt32(ddl_Category.SelectedValue);

            try

            {
                DataSet ds = new DataSet();

                ds = ObjUpkeep.LMS_SubCategory_Mst(0,"",CategoryID, CompanyID, LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddl_SubCategory.DataSource = ds.Tables[0];
                        ddl_SubCategory.DataTextField = "SubCategory_Desc";
                        ddl_SubCategory.DataValueField = "SubCategory_ID";
                        ddl_SubCategory.DataBind();
                        ddl_SubCategory.Items.Insert(0, new ListItem("--Select--", "0"));
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