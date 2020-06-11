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

namespace Upkeep_v3.WorkPermit
{
    public partial class WPConfig_Listing : System.Web.UI.Page
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
        }

        public string fetchWPConfigListing()
        {
            string data = "";
            string strInitiator = string.Empty;
            try
            {
                strInitiator = Convert.ToString(Session["UserType"]);
                DataSet ds = new DataSet();
                ds = ObjUpkeep.Fetch_WorkPermitConfiguration("");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int ConfigID = Convert.ToInt32(ds.Tables[0].Rows[i]["Wp_Config_ID"]);
                            string WorkPermit_Title = Convert.ToString(ds.Tables[0].Rows[i]["WP_Title"]);
                            string Company = Convert.ToString(ds.Tables[0].Rows[i]["Company"]);
                            string Initiator = Convert.ToString(ds.Tables[0].Rows[i]["Initiator"]);
                            string CreatedOn = Convert.ToString(ds.Tables[0].Rows[i]["Created_Date"]);

                            data += "<tr><td>" + WorkPermit_Title + "</td><td>" + Company + "</td><td>" + Initiator + "</td><td>" + CreatedOn + "</td><td><a href='WorkPermit_Configuration.aspx?WPConfigID=" + ConfigID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record'> <i class='la la-edit'></i> </a>  <a href='WorkPermit_Configuration.aspx?DelWPConfigID=" + ConfigID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

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



    }
}