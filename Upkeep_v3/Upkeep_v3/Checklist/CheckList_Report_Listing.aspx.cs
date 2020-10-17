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


namespace Upkeep_v3.CheckList
{
    public partial class CheckList_Report_Listing : System.Web.UI.Page
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
            hdn_IsPostBack.Value = "yes";
            if (!IsPostBack)
            {
                hdn_IsPostBack.Value = "no";
                Session["PreviousURL"] = HttpContext.Current.Request.Url.AbsoluteUri;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            fetchChkReportListing();
        }

        public string fetchChkReportListing()
        {
            string data = "";
            string From_Date = string.Empty;
            string To_Date = string.Empty;

            try
            {
                if (start_date.Value != "")
                {
                    From_Date = Convert.ToString(start_date.Value);
                }
                else
                {
                    From_Date = DateTime.Now.ToString("dd/MMM/yy", CultureInfo.InvariantCulture);

                }

                if (end_date.Value != "")
                {
                    To_Date = Convert.ToString(end_date.Value);
                }
                else
                {
                    DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yy", CultureInfo.InvariantCulture)).AddDays(30);
                    To_Date = FromDate.ToString("dd/MMM/yy", CultureInfo.InvariantCulture);
                }

                DataSet ds = new DataSet();
                ds = ObjUpkeep.Fetch_MyChecklistReportList(LoggedInUserID, Session["CompanyID"].ToString(), From_Date, To_Date);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            string Ans_Response_ID = Convert.ToString(ds.Tables[0].Rows[i]["Chk_Response_ID"]);
                            string Chk_Config_ID = Convert.ToString(ds.Tables[0].Rows[i]["Chk_Config_ID"]);
                            string ChecklistName = Convert.ToString(ds.Tables[0].Rows[i]["Checklist Name"]);
                            string StartTime = Convert.ToString(ds.Tables[0].Rows[i]["Start Time"]);
                            string EndTime = Convert.ToString(ds.Tables[0].Rows[i]["End Time"]);
                            string TotalHrs = Convert.ToString(ds.Tables[0].Rows[i]["Total Hrs"]);
                            string Generated_By = Convert.ToString(ds.Tables[0].Rows[i]["Generated_By"]);
                            string Status = Convert.ToString(ds.Tables[0].Rows[i]["Status"]); 

                            data += "<tr><td> <a href='CheckList_Report_Details.aspx?Ans_Response_ID=" + Ans_Response_ID + "' style='text-decoration: underline;' > " + Ans_Response_ID + " </a></td>" +
                                "<td>" + ChecklistName + "</td>" +
                                "<td>" + StartTime + "</td>" +
                                "<td>" + EndTime + "</td>" +
                                "<td>" + TotalHrs + "</td>" +
                                "<td>" + Generated_By + "</td>" +
                                "<td>" + Status + "</td>" + 
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

    }
}