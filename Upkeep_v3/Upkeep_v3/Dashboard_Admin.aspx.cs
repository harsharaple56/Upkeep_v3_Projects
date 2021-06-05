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
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

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

                //Dashboard_Details();
                // Bind_Feedback_Data();
               // Bind_Feedback_GraphData();

                //DataSet ds = new DataSet();
                //try
                //{
                //    ds = ObjUpkeep.Fetch_License_Module_list(Module_IDs);

                //    if (ds.Tables.Count > 0)
                //    {
                //        if (ds.Tables[0].Rows.Count > 0)
                //        {
                //            int Module_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["Module_id"]);

                //            if(Module_ID == 1)
                //            {
                //                div_Ticketing.Visible = false;
                //            }
                //            else if(Module_ID == 2)
                //            {
                //                div_Checklist.Visible = false;
                //            }
                //        }
                //    }

                //}
                //catch
                //{

                //}


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


        public void Dashboard_Details()
        {
            string Fromdate = string.Empty;
            string ToDate = string.Empty;

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
                ToDate = Convert.ToString(end_date.Value);
            }
            else
            {
                //DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture)).AddDays(30);
                //To_Date = FromDate.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
                ToDate = DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
            }


            DataSet ds = new DataSet();
            try
            {
                ds = ObjUpkeep.Fetch_Dashboard_Admin(CompanyID, LoggedInUserID, Fromdate, ToDate);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lbl_Tkt_Total.Text = Convert.ToString(ds.Tables[0].Rows[0]["Total_Tickets"]);
                        lbl_Tkt_open.Text = Convert.ToString(ds.Tables[0].Rows[0]["Open_Tickets"]);
                        lbl_Tkt_Parked.Text = Convert.ToString(ds.Tables[0].Rows[0]["Parked_Tickets"]);
                        lbl_Tkt_Closed.Text = Convert.ToString(ds.Tables[0].Rows[0]["Closed_Tickets"]);
                        lbl_Tkt_Expired.Text = Convert.ToString(ds.Tables[0].Rows[0]["Expired_Tickets"]);

                        lbl_Chk_Total_Attended.Text = Convert.ToString(ds.Tables[0].Rows[0]["Chk_Total_Attended"]);
                        lbl_chk_Open.Text = Convert.ToString(ds.Tables[0].Rows[0]["Chk_Pending"]);
                        lbl_chk_Closed.Text = Convert.ToString(ds.Tables[0].Rows[0]["Chk_Closed"]);

                        lbl_WP_Total.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Total"]);
                        lbl_WP_Open.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Open"]);
                        lbl_WP_InProgress.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_InProgress"]);
                        lbl_WP_Hold.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Hold"]);
                        lbl_WP_Approved.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Approved"]);
                        lbl_WP_Rejected.Text = Convert.ToString(ds.Tables[0].Rows[0]["wP_Raised_Rejected"]);
                        lbl_WP_Expired.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Expired"]);
                        lbl_WP_Closed.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Closed"]);

                        lbl_GP_Total.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Total"]);
                        lbl_GP_Open.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Open"]);
                        lbl_GP_InProgress.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_InProgress"]);
                        lbl_GP_Hold.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Hold"]);
                        lbl_GP_Approved.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Approved"]);
                        lbl_GP_Rejected.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Rejected"]);
                        lbl_GP_Expired.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Expired"]);
                        lbl_GP_Closed.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Closed"]);

                        lbl_Feedback_Total.Text = Convert.ToString(ds.Tables[0].Rows[0]["Feedback_Total"]);

                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public string Bind_Feedback_Data()
        {
            DataSet ds_Feedback= new DataSet();
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
        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            Dashboard_Details();
            //Bind_Feedback_Data();
            Bind_Feedback_GraphData();
        }



    }
}