using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.CSM
{
    public partial class List_Service_Requests_Type : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);


            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            fetchCSMConfigListing();
        }

        public string fetchCSMConfigListing()
        {
            string data = "";
            string strInitiator = string.Empty;
            try
            {
                strInitiator = Convert.ToString(Session["UserType"]);
                DataSet ds = new DataSet();
                ds = ObjUpkeep.Fetch_CSMConfiguration(CompanyID);

                rptCSMConfig.DataSource = ds.Tables[0];
                rptCSMConfig.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }
    }
}