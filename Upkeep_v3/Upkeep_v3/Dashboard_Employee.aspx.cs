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
    public partial class Dashboard_Employee : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        string Role_Name = string.Empty;
        string UserType = string.Empty;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            UserType = Convert.ToString(Session["UserType"]);
            

            //lblSession.Text = Convert.ToString(Application["SessionCount"]);

            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }
            hdn_IsPostBack.Value = "yes";
            if (!IsPostBack)
            {
                if(UserType=="E")
                {
                    hdn_IsPostBack.Value = "no";
                    //Dashboard_Details();
                }
                else
                {
                    Response.Redirect("~/Dashboard_Retailer.aspx");
                }
                
            }

        }

        protected void btn_Employee_Dashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Dashboard_Employee.aspx");
        }

        protected void btn_Admin_Dashboard_Click(object sender, EventArgs e)
        {

            Role_Name = Convert.ToString(Session["Role_Name"]);

            if (Role_Name=="Property Admin")
            {
                Response.Redirect("~/Dashboard_Admin.aspx");
            }
            else
            {
                Response.Redirect("~/Dashboard_Employee.aspx");
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
                ds = ObjUpkeep.Fetch_Dashboard_Employee(CompanyID, LoggedInUserID, Fromdate, ToDate);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lbl_tkt_Pending_Close.Text = Convert.ToString(ds.Tables[0].Rows[0]["Pending_Closure_Tickets"]);
                        lbl_tkt_Open_Accepted.Text = Convert.ToString(ds.Tables[0].Rows[0]["Accepted_Tickets"]);
                        lbl_Tkt_Open_Assigned.Text = Convert.ToString(ds.Tables[0].Rows[0]["Assigned_Tickets"]);
                        lbl_Tkt_Parked_Hold.Text = Convert.ToString(ds.Tables[0].Rows[0]["Parked_Tickets"]);
                        lbl_Tkt_Open_User.Text = Convert.ToString(ds.Tables[0].Rows[0]["MyAcc_Open_Tickets"]);
                        lbl_tkt_Closed_User.Text = Convert.ToString(ds.Tables[0].Rows[0]["MyAcc_Closed_Tickets"]);
                        lbl_Tkt_Expired_User.Text = Convert.ToString(ds.Tables[0].Rows[0]["MyAcc_Expired_Tickets"]);

                        lbl_Chk_Total.Text = Convert.ToString(ds.Tables[0].Rows[0]["Chk_Pending"]);
                        lbl_Chk_Open_User.Text = Convert.ToString(ds.Tables[0].Rows[0]["Chk_Draft"]);
                        lbl_Chk_Closed_User.Text = Convert.ToString(ds.Tables[0].Rows[0]["Chk_Closed"]);

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

                        lbl_VMS_IN.Text = Convert.ToString(ds.Tables[0].Rows[0]["VMS_IN"]);
                        lbl_VMS_OUT.Text = Convert.ToString(ds.Tables[0].Rows[0]["VMS_OUT"]);
                        lbl_VMS_Pending.Text = Convert.ToString(ds.Tables[0].Rows[0]["VMS_Pending"]);
                        lbl_VMS_Recieved.Text = Convert.ToString(ds.Tables[0].Rows[0]["VMS_Recieved"]);
                        lbl_VMS_Rejected.Text = Convert.ToString(ds.Tables[0].Rows[0]["VMS_Rejected"]);



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