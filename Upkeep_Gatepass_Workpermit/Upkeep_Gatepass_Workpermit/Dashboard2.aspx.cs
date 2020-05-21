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

namespace Upkeep_Gatepass_Workpermit
{
    public partial class Dashboard2 : System.Web.UI.Page
    {
        Upkeep_GP_WP_Services.Upkeep_GP_WP_Services ObjUpkeep = new Upkeep_GP_WP_Services.Upkeep_GP_WP_Services();
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["UserType"] = "R";
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
                return;
            }
            hdn_IsPostBack.Value = "yes";
            if (!IsPostBack)
            {
                Fetch_Company();
                hdn_IsPostBack.Value = "no";
                BindDashboardCount();
            }
        }

        public void Fetch_Company()
        {
            DataSet ds = new DataSet();
            try
            {

                ds = ObjUpkeep.Fetch_Company();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlCompany.DataSource = ds.Tables[0];
                        ddlCompany.DataTextField = "CompanyDesc";
                        ddlCompany.DataValueField = "CompanyId";
                        ddlCompany.DataBind();
                        //ddlCompany.Items.Insert(0, new ListItem("--Select Company--", "0"));
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void BindDashboardCount()
        {
            DataSet dsDashboard = new DataSet();
            string From_Date = string.Empty;
            string To_Date = string.Empty;
            int CompanyID = 0;
            try
            {
                if (start_date.Value != "")
                {
                    From_Date = Convert.ToString(start_date.Value);
                }
                else
                {
                    DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture)).AddDays(-30);
                    From_Date = FromDate.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);

                    //From_Date = DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
                }

                if (end_date.Value != "")
                {
                    To_Date = Convert.ToString(end_date.Value);
                }
                else
                {
                    //DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture)).AddDays(30);
                    //To_Date = FromDate.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
                    To_Date = DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
                }


                //if (Convert.ToString(Session["UserType"]) == "E")
                //{
                //    dvEmployee.Attributes.Add("style", "display:block;");
                //    dvRetailer.Attributes.Add("style", "display:none;");
                //}
                //else
                //{
                //    dvEmployee.Attributes.Add("style", "display:none;");
                //    dvRetailer.Attributes.Add("style", "display:block;");
                //}
                dsDashboard = ObjUpkeep.Fetch_DashboardCount(CompanyID, LoggedInUserID, From_Date, To_Date);
                if (dsDashboard.Tables.Count > 0)
                {
                    if (dsDashboard.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToString(Session["UserType"]) == "E")
                        {
                            dvEmployee.Attributes.Add("style", "display:block;");
                            dvRetailer.Attributes.Add("style", "display:none;");

                            lblGPTotal.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["GP_Request_Total"]);
                            lblGPHold.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["GP_Request_Hold"]);
                            lblGPApproved.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["GP_Request_Approve"]);
                            lblGPOpen.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["GP_Request_Open"]);
                            lblGPRejected.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["GP_Request_Rejected"]);
                            lblGPClosed.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["GP_Request_Close"]);
                            lblGPPendingApprovalCount.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["GPPendingApproval_Count"]);

                            lblWPTotalRequest.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["WP_Request_Total"]);
                            lblWPHold.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["WP_Request_Hold"]);
                            lblWPApproved.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["WP_Request_Approve"]);
                            lblWPOpen.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["WP_Request_Open"]);
                            lblWPRejected.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["WP_Request_Rejected"]);
                            lblWPClosed.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["WP_Request_Close"]);
                            lblWPPendingApprovalCount.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["WPPendingApproval_Count"]);

                            lblBaggageTotal.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["Baggage_Total"]);
                            lblBaggageOpen.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["Baggage_Open"]);
                            lblBaggageClosed.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["Baggage_Close"]);

                            lblPowerBankTotalRequest.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["Powerbank_TotalRequest"]);
                            lblPowerBankOpen.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["Powerbank_Open"]);
                            lblPowerBankClosed.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["Powerbank_Close"]);

                            lblPowerBankAvailable.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["Powerbank_Available"]);
                            lblPowerBankInUse.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["Powerbank_In_Use"]);
                            lblPowerBankTotal.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["Powerbank_Total"]);

                            lblOpenTicket.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["Request_Open"]);
                            lblCloseTicket.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["Request_Close"]);
                            lblParkedTicket.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["Request_Parked"]);

                        }
                        else if (Convert.ToString(Session["UserType"]) == "R")
                        {
                            dvEmployee.Attributes.Add("style", "display:none;");
                            dvRetailer.Attributes.Add("style", "display:block;");
                            dvGPPendingApproval.Attributes.Add("style", "display:none;");
                            dvWPPendingApproval.Attributes.Add("style", "display:none;");

                            lblR_GP_Total.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["Total_GP_Request"]);
                            lblR_GP_Hold.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["Hold_GP_Request"]);
                            lblR_GP_Approve.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["Approve_GP_Request"]);
                            lblR_GP_Open.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["Open_GP_Request"]);
                            lblR_GP_Rejected.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["Rejected_GP_Request"]);
                            lblR_GP_Close.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["Close_GP_Request"]);

                            lblR_WP_Total.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["Total_WP_Request"]);
                            lblR_WP_Hold.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["Hold_WP_Request"]);
                            lblR_WP_Approve.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["Approve_WP_Request"]);
                            lblR_WP_Open.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["Open_WP_Request"]);
                            lblR_WP_Rejected.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["Rejected_WP_Request"]);
                            lblR_WP_Close.Text = Convert.ToString(dsDashboard.Tables[0].Rows[0]["Open_WP_Request"]);


                        }

                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static void BindDashboard()
        {
            Dashboard2 d2 = new Dashboard2();
            //d2.BindDashboardCount();
        }

        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            BindDashboardCount();
        }

        //[WebMethod]
        //public static List<object> GetFeedback_ChartData()
        //{
        //    List<object> chartData = new List<object>();
        //    string From_Date = string.Empty;
        //    string To_Date = string.Empty;
        //    try
        //    {
        //        //if (start_date.Value != "")
        //        //{
        //        //    From_Date = Convert.ToString(start_date.Value);
        //        //}
        //        //else
        //        //{
        //        //    DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture)).AddDays(-30);
        //        //    From_Date = FromDate.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
        //        //}

        //        //if (end_date.Value != "")
        //        //{
        //        //    To_Date = Convert.ToString(end_date.Value);
        //        //}
        //        //else
        //        //{
        //        //    To_Date = DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
        //        //}
        //        chartData.Add(new object[]
        //         {
        //            "Event_Name", "TotalPositve" ,"TotalNeutral", "TotalNegative"
        //         });

        //      //  chartData=ObjUpkeep.GetFeedback_ChartData(From_Date, To_Date);


        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return chartData;

        //}


        [WebMethod]
        public static List<object> GetFeedback_AreaChartData(string From_Date, string To_Date)
        {
            List<object> chartData = new List<object>();
            string StrConn = string.Empty;
            
            try
            {
                
                chartData.Add(new object[]
                 {
                    "Event_Name", "TotalPositve" ,"TotalNeutral", "TotalNegative"
                 });

                StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();

                using (SqlConnection con = new SqlConnection(StrConn))
                {
                    using (SqlCommand cmd = new SqlCommand("Feedback_Proc_GetChartData"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FromDate", From_Date);
                        cmd.Parameters.AddWithValue("@ToDate", To_Date);
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                chartData.Add(new object[]
                                {
                                    sdr["Event_Name"], sdr["TotalPositve"] , sdr["TotalNeutral"], sdr["TotalNegative"]
                                });
                            }
                        }
                        con.Close();
                        return chartData;
                    }
                }

                //return chartData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [WebMethod]
        public static List<object> GetChecklist_PieChartData(string Selected_Company, string From_Date, string To_Date)
        {
            List<object> chartData = new List<object>();
            string StrConn = string.Empty;

            try
            {

                chartData.Add(new object[]
                 {
                    "Status", "TotalCount"
                 });

                StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();

                using (SqlConnection con = new SqlConnection(StrConn))
                {
                    using (SqlCommand cmd = new SqlCommand("Spr_fetch_ChecklistCount"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SelectedCompany", Selected_Company);
                        cmd.Parameters.AddWithValue("@FromDate", From_Date);
                        cmd.Parameters.AddWithValue("@ToDate", To_Date);
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                chartData.Add(new object[]
                                {
                                    sdr["Status"], sdr["TotalCount"] 
                                });
                            }
                        }
                        con.Close();
                        return chartData;
                    }
                }

                //return chartData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [WebMethod]
        public static List<object> GetChecklist_Departmentwise_BarChartData(string Selected_Company, string From_Date, string To_Date)
        {
            List<object> chartData = new List<object>();
            string StrConn = string.Empty;

            try
            {
                chartData.Add(new object[]
                 {
                    "Department", "Open","Close","Expired"
                 });

                StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();

                using (SqlConnection con = new SqlConnection(StrConn))
                {
                    using (SqlCommand cmd = new SqlCommand("Spr_Fetch_TotalChecklistcount"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SelectedCompany", Selected_Company);
                        cmd.Parameters.AddWithValue("@FromDate", From_Date);
                        cmd.Parameters.AddWithValue("@ToDate", To_Date);
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                chartData.Add(new object[]
                                {
                                    sdr["Department"], sdr["Open"], sdr["Close"], sdr["Expired"]
                                });
                            }
                        }
                        con.Close();
                        return chartData;
                    }
                }

                //return chartData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [WebMethod]
        public static List<object> GetTicket_Departmentwise_BarChartData(string Selected_Company, string From_Date, string To_Date)
        {
            List<object> chartData = new List<object>();
            string StrConn = string.Empty;

            try
            {
                chartData.Add(new object[]
                 {
                    "Department", "Open","Close","Parked"
                 });

                StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();

                using (SqlConnection con = new SqlConnection(StrConn))
                {
                    using (SqlCommand cmd = new SqlCommand("Spr_Fetch_TotalTicketcount"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SelectedCompany", Selected_Company);
                        cmd.Parameters.AddWithValue("@FromDate", From_Date);
                        cmd.Parameters.AddWithValue("@ToDate", To_Date);
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                chartData.Add(new object[]
                                {
                                    sdr["Department"], sdr["Open"], sdr["Close"], sdr["Parked"]
                                });
                            }
                        }
                        con.Close();
                        return chartData;
                    }
                }

                //return chartData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [WebMethod]
        public static List<object> GetTicket_Categorywise_BarChartData(string Selected_Company, string From_Date, string To_Date)
        {
            List<object> chartData = new List<object>();
            string StrConn = string.Empty;

            try
            {
                chartData.Add(new object[]
                 {
                    "Category", "Open","Close","Parked"
                 });

                StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();

                using (SqlConnection con = new SqlConnection(StrConn))
                {
                    using (SqlCommand cmd = new SqlCommand("Spr_Fetch_Categorywise_TotalTicketcount"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SelectedCompany", Selected_Company);
                        cmd.Parameters.AddWithValue("@FromDate", From_Date);
                        cmd.Parameters.AddWithValue("@ToDate", To_Date);
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                chartData.Add(new object[]
                                {
                                    sdr["Category"], sdr["Open"], sdr["Close"], sdr["Parked"]
                                });
                            }
                        }
                        con.Close();
                        return chartData;
                    }
                }

                //return chartData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



    }
}