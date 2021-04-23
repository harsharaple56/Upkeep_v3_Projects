﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Text;
using System.IO;

namespace Upkeep_v3
{
    public partial class Dashboard_Employee : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        string Role_Name = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }

            if (!IsPostBack)
            {
                Dashboard_Details();
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
                        
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}