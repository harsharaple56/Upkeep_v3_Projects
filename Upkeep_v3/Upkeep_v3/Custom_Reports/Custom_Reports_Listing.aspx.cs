using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.Custom_Reports
{
    public partial class Custom_Reports_Listing : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeepCC = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();

        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            if (LoggedInUserID == "")
            {
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }

            if(!IsPostBack)
            {
                bindgrid();
            }
 
        }

        public string bindgrid()
        {
            string data = "";
            try
            {
                ds = ObjUpkeepCC.CustomReports_RU(0, "", "", CompanyID,LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Report_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Report_ID"]);
                            string Report_Name = Convert.ToString(ds.Tables[0].Rows[i]["Report_Name"]);
                            string Report_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Report_Desc"]);
                            string Report_Path = Convert.ToString(ds.Tables[0].Rows[0]["Report_Path"]);

                            data += "<tr><td>" + Report_Name + "</td><td>" + Report_Desc + "</td><td><a href='<%= Page.ResolveClientUrl(~" + Report_Path + ") %>' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='View Report'> <i class='la la-eye'></i> </a> </td></tr>";

                        }
                    }
                }
                else
                {

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