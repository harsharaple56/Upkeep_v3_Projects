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
            }



        }
        protected void btnPopup_Click(object sender, EventArgs e)
        {
            //fetchInvItemSelectedListing();
        }
        protected void btnModalsubmit_Click(object sender, EventArgs e)
        {
            //fetchInvItemSelectedListing();
        }


        public string Fetch_Stock_Details()
        {
            string data = "";

            try
            {
                //ds = ObjUpkeep.INV_ItemMaster_CRUD(0, "", 0, 0, CompanyID, "", "R");
                ds = ObjUpkeep.INV_ItemMaster_CRUD(0, "", 0, 0, CompanyID, "", "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Item_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["Item_ID"]);
                            string Item_Desc = Convert.ToString(ds.Tables[0].Rows[0]["Item_Desc"]);
                            string Category_Desc = Convert.ToString(ds.Tables[0].Rows[0]["Category_Desc"]);
                            string SubCategory_Desc = Convert.ToString(ds.Tables[0].Rows[0]["SubCategory_Desc"]);

                            
                            data += "<tr><td>" + Item_ID + "</td><td>" + Item_Desc + "</td><td>" + Category_Desc + "</td><td>" + SubCategory_Desc + "</td><td><a href='Add_User_Mst.aspx?User_ID=" + Item_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top'> <i class='la la-edit'></i> </a>  <a href='Add_User_Mst.aspx?DelUser_ID=" + Item_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' > 	<i class='la la-trash'></i> </a> </td></tr>";
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



    }
}