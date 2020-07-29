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

namespace Upkeep_v3.GatePass
{
    public partial class MyGatePass : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["LoggedInUserID"] = "121";
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
            fetchGPRequestListing();
        }

        public string fetchGPRequestListing()
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
                ds = ObjUpkeep.Fetch_MyRequestGatePass(LoggedInUserID, From_Date, To_Date);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            //string SrNO = Convert.ToString(ds.Tables[0].Rows[i]["SrNo"]);
                            string TransactionID = Convert.ToString(ds.Tables[0].Rows[i]["GP_Trans_ID"]);
                            string TicketNo = Convert.ToString(ds.Tables[0].Rows[i]["TicketNo"]);
                            string GatePass_Title = Convert.ToString(ds.Tables[0].Rows[i]["GP_Title"]);
                            string Department = Convert.ToString(ds.Tables[0].Rows[i]["DepartmentName"]);
                            string GP_Type = Convert.ToString(ds.Tables[0].Rows[i]["GP_Type_Desc"]);
                            string GatePassDate = Convert.ToString(ds.Tables[0].Rows[i]["GatePassDate"]);
                            string RequestDate = Convert.ToString(ds.Tables[0].Rows[i]["RequestDate"]);
                            string Status = Convert.ToString(ds.Tables[0].Rows[i]["GP_Status"]);
                            string Created_By = Convert.ToString(ds.Tables[0].Rows[i]["Created_By"]);

                            data += "<tr><td> <a href='GatePass_Approval.aspx?TransactionID=" + TransactionID + "' style='text-decoration: underline;' > " + TicketNo + " </a></td><td>" + GatePass_Title + "</td><td>" + Department + "</td><td>" + GP_Type + "</td><td>" + GatePassDate + "</td><td>" + RequestDate + "</td><td>" + Status + "</td><td>" + Created_By + "</td></tr>";

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