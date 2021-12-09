using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Text;
using System.Globalization;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;

namespace Upkeep_v3
{
    public partial class Dashboard_v2 : System.Web.UI.Page
    {

        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        public static string LoggedInUserID = string.Empty;
        public static int CompanyID = 0;

        string Role_Name = string.Empty;
        string Module_IDs = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            Module_IDs = Convert.ToString(Session["ModuleID"]);


            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }
            hdn_IsPostBack.Value = "yes";

            if (!IsPostBack)
            {
                hdn_IsPostBack.Value = "no";

                Bind_Feedback_Data();
                Bind_Feedback_GraphData();
            }

        }

        protected void btn_Employee_Dashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Dashboard_Employee.aspx");
        }

        protected void btn_Admin_Dashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Dashboard_Admin.aspx");
        }

        public string Bind_Feedback_Data()
        {
            DataSet ds_Feedback = new DataSet();
            string data = "";
            string Fromdate = string.Empty;
            string Todate = string.Empty;

            if (start_date.Value != "")
            {
                Fromdate = Convert.ToString(start_date.Value);
            }
            else
            {
                DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture)).AddDays(-30);
                Fromdate = FromDate.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);

                //From_Date = DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
            }

            if (end_date.Value != "")
            {
                Todate = Convert.ToString(end_date.Value);
            }
            else
            {
                //DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture)).AddDays(30);
                //To_Date = FromDate.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
                Todate = DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
            }



            try
            {
                ds_Feedback = ObjUpkeep.Get_ChartData(Fromdate, Todate, CompanyID);

                if (ds_Feedback.Tables.Count > 0)
                {
                    if (ds_Feedback.Tables[0].Rows.Count > 0)
                    {

                        int count = Convert.ToInt32(ds_Feedback.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Event_ID = Convert.ToInt32(ds_Feedback.Tables[0].Rows[i]["Event_ID"]);
                            string Event_Name = Convert.ToString(ds_Feedback.Tables[0].Rows[i]["Event_Name"]);
                            int TotalFeedbacks = Convert.ToInt32(ds_Feedback.Tables[0].Rows[i]["TotalFeedbacks"]);
                            int TotalPositive = Convert.ToInt32(ds_Feedback.Tables[0].Rows[i]["TotalPositve"]);
                            decimal PositivePercent = Convert.ToInt32(ds_Feedback.Tables[0].Rows[i]["PositivePercent"]);
                            int TotalNeutral = Convert.ToInt32(ds_Feedback.Tables[0].Rows[i]["TotalNeutral"]);
                            decimal NeutralPercent = Convert.ToInt32(ds_Feedback.Tables[0].Rows[i]["NeutralPercent"]);
                            int TotalNegative = Convert.ToInt32(ds_Feedback.Tables[0].Rows[i]["TotalNegative"]);
                            decimal NegativePercent = Convert.ToInt32(ds_Feedback.Tables[0].Rows[i]["NegativePercent"]);


                            data += "<tr><td>" + Event_Name + "</td><td>" + PositivePercent + "</td><td>" + NegativePercent + "</td><td>" + NeutralPercent + "</td></tr>";

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

        public void Bind_Feedback_GraphData()
        {
            DataSet ds_Feedback = new DataSet();
            string data = "";
            string Fromdate = string.Empty;
            string Todate = string.Empty;

            if (start_date.Value != "")
            {
                Fromdate = Convert.ToString(start_date.Value);
            }
            else
            {
                DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture)).AddDays(-30);
                Fromdate = FromDate.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);

                //From_Date = DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
            }

            if (end_date.Value != "")
            {
                Todate = Convert.ToString(end_date.Value);
            }
            else
            {
                //DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture)).AddDays(30);
                //To_Date = FromDate.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
                Todate = DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
            }



            try
            {
                ds_Feedback = ObjUpkeep.Get_ChartData(Fromdate, Todate, CompanyID);

                if (ds_Feedback.Tables.Count > 0)
                {
                    if (ds_Feedback.Tables[0].Rows.Count > 0)
                    {
                        rptFeedbackDetails.DataSource = ds_Feedback.Tables[0];
                        rptFeedbackDetails.DataBind();

                        //int count = Convert.ToInt32(ds_Feedback.Tables[0].Rows.Count);

                        //for (int i = 0; i < count; i++)
                        //{
                        //    int Event_ID = Convert.ToInt32(ds_Feedback.Tables[0].Rows[i]["Event_ID"]);
                        //    string Event_Name = Convert.ToString(ds_Feedback.Tables[0].Rows[i]["Event_Name"]);
                        //    int TotalFeedbacks = Convert.ToInt32(ds_Feedback.Tables[0].Rows[i]["TotalFeedbacks"]);
                        //    int TotalPositive = Convert.ToInt32(ds_Feedback.Tables[0].Rows[i]["TotalPositve"]);
                        //    decimal PositivePercent = Convert.ToInt32(ds_Feedback.Tables[0].Rows[i]["PositivePercent"]);
                        //    int TotalNeutral = Convert.ToInt32(ds_Feedback.Tables[0].Rows[i]["TotalNeutral"]);
                        //    decimal NeutralPercent = Convert.ToInt32(ds_Feedback.Tables[0].Rows[i]["NeutralPercent"]);
                        //    int TotalNegative = Convert.ToInt32(ds_Feedback.Tables[0].Rows[i]["TotalNegative"]);
                        //    decimal NegativePercent = Convert.ToInt32(ds_Feedback.Tables[0].Rows[i]["NegativePercent"]);

                        //}

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
        }

        [System.Web.Services.WebMethod]
        public static Dictionary<string, string> GetDashboardDetails(string start_Date, string end_Date)
        {
            Dashboard_v2 obj = new Dashboard_v2();
            string Fromdate = start_Date;
            string ToDate = end_Date;
            DataSet ds = new DataSet();
            Dictionary<string, string> list = new Dictionary<string, string>();
            try
            {
                ds = obj.ObjUpkeep.Fetch_Dashboard_Admin(CompanyID, LoggedInUserID, Fromdate, ToDate, 0, string.Empty);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        list.Add("lbl_Tkt_Total", Convert.ToString(ds.Tables[0].Rows[0]["Total_Tickets"]));
                        list.Add("lbl_Tkt_open", Convert.ToString(ds.Tables[0].Rows[0]["Open_Tickets"]));
                        list.Add("lbl_Tkt_Parked", Convert.ToString(ds.Tables[0].Rows[0]["Parked_Tickets"]));
                        list.Add("lbl_Tkt_Closed", Convert.ToString(ds.Tables[0].Rows[0]["Closed_Tickets"]));
                        list.Add("lbl_Tkt_Expired", Convert.ToString(ds.Tables[0].Rows[0]["Expired_Tickets"]));

                        list.Add("lbl_Chk_Total_Attended", Convert.ToString(ds.Tables[0].Rows[0]["Chk_Total_Attended"]));
                        list.Add("lbl_chk_Open", Convert.ToString(ds.Tables[0].Rows[0]["Chk_Pending"]));
                        list.Add("lbl_chk_Closed", Convert.ToString(ds.Tables[0].Rows[0]["Chk_Closed"]));

                        list.Add("lbl_WP_Total", Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Total"]));
                        list.Add("lbl_WP_Open", Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Open"]));
                        list.Add("lbl_WP_InProgress", Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_InProgress"]));
                        list.Add("lbl_WP_Hold", Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Hold"]));
                        list.Add("lbl_WP_Approved", Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Approved"]));
                        list.Add("lbl_WP_Rejected", Convert.ToString(ds.Tables[0].Rows[0]["wP_Raised_Rejected"]));
                        list.Add("lbl_WP_Expired", Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Expired"]));
                        list.Add("lbl_WP_Closed", Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Closed"]));

                        list.Add("lbl_GP_Total", Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Total"]));
                        list.Add("lbl_GP_Open", Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Open"]));
                        list.Add("lbl_GP_InProgress", Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_InProgress"]));
                        list.Add("lbl_GP_Hold", Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Hold"]));
                        list.Add("lbl_GP_Approved", Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Approved"]));
                        list.Add("lbl_GP_Rejected", Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Rejected"]));
                        list.Add("lbl_GP_Expired", Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Expired"]));
                        list.Add("lbl_GP_Closed", Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Closed"]));

                        list.Add("lbl_Feedback_Total", Convert.ToString(ds.Tables[0].Rows[0]["Feedback_Total"]));
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            DataSet ds1 = new DataSet();
                            ds1 = obj.ObjUpkeep.Fetch_Dashboard_Admin(CompanyID, LoggedInUserID, Fromdate, ToDate, Convert.ToInt32(ds.Tables[1].Rows[i].ItemArray[0]), "F");

                            if (ds1.Tables[0].Rows[0]["Module_Code"] != null)
                            {
                                if (Convert.ToString(ds1.Tables[0].Rows[0]["Module_Code"]) == "TKT")
                                {
                                    list.Add("Tkt_Visible", "true");
                                }

                                if (Convert.ToString(ds1.Tables[0].Rows[0]["Module_Code"]) == "CHK")
                                {
                                    list.Add("Chk_Visible", "true");
                                }

                                if (Convert.ToString(ds1.Tables[0].Rows[0]["Module_Code"]) == "WP")
                                {
                                    list.Add("WP_Visible", "true");

                                }

                                if (Convert.ToString(ds1.Tables[0].Rows[0]["Module_Code"]) == "GP")
                                {
                                    list.Add("GP_Visible", "true");
                                }

                                if (Convert.ToString(ds1.Tables[0].Rows[0]["Module_Code"]) == "VMS")
                                {
                                    list.Add("VMS_Visible", "true");
                                }
                            }

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }


    }
}