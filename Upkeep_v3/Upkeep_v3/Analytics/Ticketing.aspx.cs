using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Analytics
{
    public partial class Ticketing : System.Web.UI.Page
    {
        #region Global Variables

        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        public static string LoggedInUserID = string.Empty;
        public static int CompanyID = 0;
        string Role_Name = string.Empty;
        public static string UserType = string.Empty;
        public static string FromDate = string.Empty;
        public static string ToDate = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            UserType = Convert.ToString(Session["UserType"]);

            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }
            hdn_IsPostBack.Value = "yes";
            if (!IsPostBack)
            {
                if (UserType == "E")
                {
                    hdn_IsPostBack.Value = "no";
                }
                else
                {
                    Response.Redirect("~/Dashboard_Retailer.aspx");
                }

            }

        }

        public void Dashboard_Details()
        {
            if (start_date.Value != "")
            {
                FromDate = Convert.ToString(start_date.Value);
            }
            else
            {
                DateTime Fromdate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture)).AddDays(-30);
                FromDate = Fromdate.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
            }

            if (end_date.Value != "")
            {
                ToDate = Convert.ToString(end_date.Value);
            }
            else
            {
                ToDate = DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
            }
        }

        protected void btnSearchDashboard_Click(object sender, EventArgs e)
        {
            Dashboard_Details();
        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static string Fetch_Analyze_Tkt_Block1()
        {
            Ticketing form = new Ticketing();
            DataSet ds = new DataSet();
            ds = form.ObjUpkeep.Fetch_Analyze_Tkt_Block1(LoggedInUserID,CompanyID, FromDate, ToDate);
            return JsonConvert.SerializeObject(ds);
        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static string Fetch_Analyze_Tkt_Block2()
        {
            Ticketing form = new Ticketing();

            DataSet ds = new DataSet();
            ds = form.ObjUpkeep.Fetch_Analyze_Tkt_Block2(LoggedInUserID, CompanyID, FromDate, ToDate);
            return JsonConvert.SerializeObject(ds);
        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static string Fetch_Analyze_Tkt_Block3()
        {
            Ticketing form = new Ticketing();
            DataSet ds = new DataSet();
            ds = form.ObjUpkeep.Fetch_Analyze_Tkt_Block3(LoggedInUserID, CompanyID, FromDate, ToDate);
            return JsonConvert.SerializeObject(ds);
        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static string Fetch_Analyze_Tkt_Block4()
        {
            Ticketing form = new Ticketing();
            DataSet ds = new DataSet();
            ds = form.ObjUpkeep.Fetch_Analyze_Tkt_Block4(LoggedInUserID, CompanyID);
            return JsonConvert.SerializeObject(ds);
        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static string Fetch_Analyze_Tkt_Block5()
        {
            Ticketing form = new Ticketing();
            DataSet ds = new DataSet();
            ds = form.ObjUpkeep.Fetch_Analyze_Tkt_Block5(LoggedInUserID, CompanyID, FromDate, ToDate);
            return JsonConvert.SerializeObject(ds);
        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static string Fetch_Analyze_Tkt_Block6()
        {
            Ticketing form = new Ticketing();
            DataSet ds = new DataSet();
            ds = form.ObjUpkeep.Fetch_Analyze_Tkt_Block6(LoggedInUserID, CompanyID, FromDate, ToDate);
            return JsonConvert.SerializeObject(ds);
        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static string Fetch_Analyze_Tkt_Block7()
        {
            Ticketing form = new Ticketing();
            DataSet ds = new DataSet();
            ds = form.ObjUpkeep.Fetch_Analyze_Tkt_Block7(LoggedInUserID, CompanyID, FromDate, ToDate);
            return JsonConvert.SerializeObject(ds);
        }

        public string BindDowntimeTickets()
        {
            string data = "";
            try
            {
                DataSet ds = new DataSet();
                ds = ObjUpkeep.Fetch_Highest_Downtime_Ticket(FromDate, ToDate, CompanyID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);
                        string ReqStatusClass = string.Empty;
                        string ActionStatusClass = string.Empty;


                        for (int i = 0; i < count; i++)
                        {
                            int Ticket_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Ticket_ID"]);
                            string Tkt_Code = Convert.ToString(ds.Tables[0].Rows[i]["Tkt_Code"]);
                            string Dept_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Dept_Desc"]);
                            string Category_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Category_Desc"]);
                            string SubCategory_Desc = Convert.ToString(ds.Tables[0].Rows[i]["SubCategory_Desc"]);
                            string Ticket_Date_Time = Convert.ToString(ds.Tables[0].Rows[i]["Ticket_Date_Time"]);
                            string RequestStatus = Convert.ToString(ds.Tables[0].Rows[i]["RequestStatus"]);
                            string ActionStatus = Convert.ToString(ds.Tables[0].Rows[i]["ActionStatus"]);
                            string Down_Time = Convert.ToString(ds.Tables[0].Rows[i]["Down_Time"]);

                            string link = "/Ticketing/View_Ticket_Details.aspx?TicketID=" + Ticket_ID;
                            switch (RequestStatus)
                            {
                                case "Open":
                                    ReqStatusClass = "danger";
                                    break;
                                case "Closed":
                                    ReqStatusClass = "success";
                                    break;
                                case "Expired":
                                    ReqStatusClass = "secondary";
                                    break;
                                default:
                                    ReqStatusClass = "secondary";
                                    break;
                            }

                            switch (ActionStatus)
                            {
                                case "Assigned":
                                    ActionStatusClass = "info";
                                    break;
                                case "Accepted":
                                    ActionStatusClass = "success";
                                    break;
                                case "Expired":
                                    ActionStatusClass = "secondary";
                                    break;
                                case "In Progress":
                                    ActionStatusClass = "accent";
                                    break;
                                case "Closed":
                                    ActionStatusClass = "success";
                                    break;
                                default:
                                    ActionStatusClass = "secondary";
                                    break;
                            }
                            data += "<tr>";
                            data += "<td><a href = '" + link + "' >" + Tkt_Code + "</td>";
                            data += "<td>" + Dept_Desc + "</td>";
                            data += "<td>" + Category_Desc + "</td>";
                            data += "<td>" + SubCategory_Desc + "</td>";
                            data += "<td>" + Ticket_Date_Time + "</td>";
                            data += "<td>" + "<span style='width: 113px;'><span class='m-badge m-badge--" + ReqStatusClass + " m-badge--wide'>" + RequestStatus + "</span></span>" + "</td>";
                            data += "<td>" + "<span style='width: 113px;'><span class='m-badge m-badge--" + ActionStatusClass + " m-badge--dot'></span>&nbsp;" +
                            "<span class='m--font-bold m--font-" + ActionStatusClass + "'>" + ActionStatus + "</span></span>" + "</td>";
                            data += "<td>" + Down_Time + "</td>";
                            data += "</tr>";

                        }
                    }
                    else
                    {

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