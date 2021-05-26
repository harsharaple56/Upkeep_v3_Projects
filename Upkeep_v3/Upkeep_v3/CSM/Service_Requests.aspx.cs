using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

namespace Upkeep_v3.CSM
{
    public partial class Service_Requests : System.Web.UI.Page
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
            fetchRequestList();
        }

        public string fetchRequestList()
        {
            
            string data = "";
            string From_Date = string.Empty;
            string To_Date = string.Empty;

            try
            {
                if (start_date.Value != "")
                {
                    From_Date = Convert.ToDateTime(start_date.Value).ToString("dd-MMM-yyyy");
                }
                else
                {
                    From_Date = DateTime.Now.AddDays(-29).ToString("dd/MMM/yy", CultureInfo.InvariantCulture);

                }

                if (end_date.Value != "")
                {
                    To_Date = Convert.ToDateTime(end_date.Value).ToString("dd-MMM-yyyy");
                }
                else
                {
                    DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yy", CultureInfo.InvariantCulture)).AddDays(30);
                    To_Date = FromDate.ToString("dd/MMM/yy", CultureInfo.InvariantCulture);
                }

                DataSet ds = new DataSet();
                ds = ObjUpkeep.Fetch_CSMRequestList(Convert.ToInt32(Session["CompanyID"]), LoggedInUserID, From_Date, To_Date);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            string SrNO = Convert.ToString(1 + i);
                            string RequestID = Convert.ToString(ds.Tables[0].Rows[i]["Request_ID"]);
                            //string TicketNo = Convert.ToString(ds.Tables[0].Rows[i]["TicketNo"]);
                            string Config_Title = Convert.ToString(ds.Tables[0].Rows[i]["Config_Desc"]);
                            //string Department = Convert.ToString(ds.Tables[0].Rows[i]["DepartmentName"]);
                            //string GP_Type = Convert.ToString(ds.Tables[0].Rows[i]["GP_Type_Desc"]);
                            string RequestDate = Convert.ToString(ds.Tables[0].Rows[i]["Request_Date"]);
                            string ClosedDate = Convert.ToString(ds.Tables[0].Rows[i]["Closed_Date"]);
                            string Status = Convert.ToString(ds.Tables[0].Rows[i]["Status"]);
                            //string Created_By = Convert.ToString(ds.Tables[0].Rows[i]["Created_By"]);

                            data += "<tr><td> <a href='Raise_Service_Request.aspx?RequestID=" + RequestID + "' style='text-decoration: underline;' > "
                                + RequestID + " </a></td><td>" + Config_Title + "</td><td>" + RequestDate + "</td><td>" + ClosedDate + "</td><td>" + Status + "</td></tr>";

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