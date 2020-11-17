using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Globalization;
using System.IO;

namespace Upkeep_v3.Feedback
{
    public partial class EditEvent : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeepFeedback = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        int CompanyID = 0;
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                //Response.Redirect("~/Login.aspx", false);
            }

            if (!IsPostBack)
            {
                int EventID = Convert.ToInt32(Request.QueryString["EventID"]);
                int EventID_Delete = Convert.ToInt32(Request.QueryString["DelEventID"]);
                if (EventID > 0)
                {
                    Session["EventID"] = Convert.ToString(EventID);
                    bindEventDetails(EventID);
                }
                if (EventID_Delete > 0)
                {
                    DeleteEvent(EventID_Delete);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            int EventID = Convert.ToInt32(Session["EventID"]);
            DataSet ds = new DataSet();
            string QuesFor = string.Empty;
            if (rdbCustomer.Checked == true)
            { QuesFor = "C"; }
            if (rdbRetailer.Checked == true)
            { QuesFor = "R"; }
            if (rdbVisitor.Checked == true)
            { QuesFor = "V"; }
            if (rdbAll.Checked == true)
            { QuesFor = "A"; }

            string EventMode = string.Empty;
            if (rdbDaily.Checked == true)
            {
                EventMode = "D"; // Daily/Monthly
            }
            if (rdbPeriodic.Checked == true)
            {
                EventMode = "P"; // Periodic            
            }

            ds = ObjUpkeepFeedback.Event_Update(EventID, Location.Text.Trim(), QuesFor, EventMode, startDate.Text.Trim(), endDate.Text.Trim(), LoggedInUserID, "Update");

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //EventID = Convert.ToInt32(ds.Tables[0].Rows[0]["Event_ID"]);

                    Response.Redirect(Page.ResolveClientUrl("~/Feedback/EventListing.aspx"), false);
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

        public void bindEventDetails(int EventID)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = ObjUpkeepFeedback.bindEventDetails(CompanyID,EventID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        event_name.Text = Convert.ToString(ds.Tables[0].Rows[0]["Event_Name"]);
                        //event_name.Enabled = false;
                        string User_Type = Convert.ToString(ds.Tables[0].Rows[0]["User_Type"]);
                        if (User_Type == "C")
                        {
                            rdbCustomer.Checked = true;
                        }
                        else if (User_Type == "R")
                        {
                            rdbRetailer.Checked = true;
                        }
                        else if (User_Type == "V")
                        {
                            rdbVisitor.Checked = true;
                        }
                        else 
                        {
                            rdbAll.Checked = true;
                        }
                        string Event_Mode = Convert.ToString(ds.Tables[0].Rows[0]["Event_Mode"]);
                        if (Event_Mode == "D")
                        {
                            rdbDaily.Checked = true;
                        }
                        else
                        {
                            rdbPeriodic.Checked = true;
                            dvDate.Attributes.Add("style", "display:block");
                            startDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["Start_Date"]);
                            endDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["Expiry_Date"]);
                        }

                        Location.Text = Convert.ToString(ds.Tables[0].Rows[0]["Location"]);

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
        }

        public void DeleteEvent(int EventID)
        {
            DataSet ds = new DataSet();

            try
            {
                ds = ObjUpkeepFeedback.Event_Update(EventID, "", "", "", "", "", LoggedInUserID, "Delete");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Redirect(Page.ResolveClientUrl("~/Feedback/EventListing.aspx"), false);
                        //Response.Redirect("~/EventListing.aspx", false);
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
        }
    }
}