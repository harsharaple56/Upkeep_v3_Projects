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

namespace Upkeep_v3.Laundry_Management.Transactions
{
    public partial class Vendor_Transactions : System.Web.UI.Page
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
                Fetch_Vendor_Transactions();
            }

        }

        public string Fetch_Vendor_Transactions()
        {
            string data = "";

            try
            {
                ds = ObjUpkeep.LMS_Fetch_Vendor_Transactions("", "", CompanyID, 0);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Vdr_Trans_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Trans_ID"]);
                            string Vendor_Name = Convert.ToString(ds.Tables[0].Rows[i]["Vendor_Name"]);

                            string Created_By = Convert.ToString(ds.Tables[0].Rows[i]["Created_By"]); ;
                            string Created_Date = Convert.ToString(ds.Tables[0].Rows[i]["Created_Date"]);

                            data += "<tr><td>" + Vdr_Trans_ID + "</td><td>" + Vendor_Name + "</td><td>" + Created_By + "</td><td>" + Created_Date + "</td><td><a href='Add_Vendor_Transaction.aspx?Vendor_Trans_ID=" + Vdr_Trans_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top'> <i class='la la-edit'></i> </a>  <a href='Add_Vendor_Transaction.aspx?DelVendor_Trans_ID=" + Vdr_Trans_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' > 	<i class='la la-trash'></i> </a> </td></tr>";
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