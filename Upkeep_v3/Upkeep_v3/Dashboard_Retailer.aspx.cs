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
    public partial class Dashboard_Retailer : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            hdnCompanyID.Value = Convert.ToString(Session["CompanyID"]);
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
                return;
            }
            hdn_IsPostBack.Value = "yes";
            if (!IsPostBack)
            {
                //Fetch_Company();
                hdn_IsPostBack.Value = "no";
                if (Convert.ToString(Session["UserType"]) == "R")
                {
                    Fetch_Retailer_Latest_Punch();
                    //Dashboard_Details();
                }
            }
        }

        protected void Btn_Retailer_PunchIn_Click(object sender, EventArgs e)
        {
            string Punch_Type = "IN";
            DataSet dspunch = new DataSet();
            try
            {
                dspunch = ObjUpkeep.RetailerPunch_CR(LoggedInUserID, Punch_Type, CompanyID, "C");

                if (dspunch.Tables.Count > 0)
                {
                    if (dspunch.Tables[0].Rows.Count > 0)
                    {
                        lblPunchInTime.Text = Convert.ToString(dspunch.Tables[0].Rows[0]["Punch_Datetime"]);
                        btnPunchIn.Attributes.Add("style", "display:none;");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Btn_Retailer_PunchOut_Click(object sender, EventArgs e)
        {
            string Punch_Type = "OUT";
            DataSet dspunch = new DataSet();

            try
            {
                dspunch = ObjUpkeep.RetailerPunch_CR(LoggedInUserID, Punch_Type, CompanyID, "C");

                if (dspunch.Tables.Count > 0)
                {
                    if (dspunch.Tables[0].Rows.Count > 0)
                    {
                        lblPunchOutTime.Text = Convert.ToString(dspunch.Tables[0].Rows[0]["Punch_Datetime"]);
                        btnPunchOut.Attributes.Add("style", "display:none;");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Fetch_Retailer_Latest_Punch()
        {

            DataSet dspunch = new DataSet();

            try
            {
                dspunch = ObjUpkeep.RetailerPunch_CR(LoggedInUserID, "", CompanyID, "R");

                if (dspunch.Tables.Count > 0)
                {
                    if (dspunch.Tables[0].Rows.Count > 0)
                    {
                        lblPunchInTime.Text = Convert.ToString(dspunch.Tables[0].Rows[0]["PunchIn_Datetime"]);
                        lblPunchOutTime.Text = Convert.ToString(dspunch.Tables[0].Rows[0]["PunchOut_Datetime"]);

                        if (Convert.ToString(dspunch.Tables[0].Rows[0]["PunchIn_Datetime"]) != "")
                        {
                            btnPunchIn.Attributes.Add("style", "display:none;");
                        }

                        if (Convert.ToString(dspunch.Tables[0].Rows[0]["PunchOut_Datetime"]) != "")
                        {
                            btnPunchOut.Attributes.Add("style", "display:none;");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                ds = ObjUpkeep.Fetch_Dashboard_Retailer(CompanyID, LoggedInUserID, Fromdate, ToDate);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lbl_tkt_Pending_Close.Text = Convert.ToString(ds.Tables[0].Rows[0]["Pending_Closure_Tickets_Total"]);
                        lbl_Tkt_Total_User.Text = Convert.ToString(ds.Tables[0].Rows[0]["MyAcc_Total_Raised"]);
                        lbl_Tkt_Open_User.Text = Convert.ToString(ds.Tables[0].Rows[0]["MyAcc_Open_Tickets"]);
                        lbl_tkt_Open_Accepted_User.Text = Convert.ToString(ds.Tables[0].Rows[0]["MyAcc_Open_Accepted_Tickets"]);
                        lbl_tkt_Closed_User.Text = Convert.ToString(ds.Tables[0].Rows[0]["MyAcc_Closed_Tickets"]);

                        lbl_WP_Pending_Approvals.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Pending_Approvals"]);
                        lbl_WP_Open_User.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Open"]);
                        lbl_WP_InProgress_User.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_InProgress"]);
                        lbl_WP_OnHold_User.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Hold"]);
                        lbl_WP_Approved_User.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Approved"]);

                        lbl_GP_Pending_Approval.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Pending_Approvals"]);
                        lbl_GP_Open_User.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Open"]);
                        lbl_GP_InProgress.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_InProgress"]);
                        lbl_GP_OnHold.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Hold"]);
                        lbl_GP_Approved_User.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Approved"]);

                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void btnSearchDashboard_Click(object sender, EventArgs e)
        {
            Dashboard_Details();
        }


    }
}