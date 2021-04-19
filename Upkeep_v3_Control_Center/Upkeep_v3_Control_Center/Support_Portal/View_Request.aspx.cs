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
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;
//using Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Data.Common;


namespace Upkeep_v3_Control_Center.Support_Portal
{
    public partial class View_Request : System.Web.UI.Page
    {
        UpkeepControlCenter_Service.UpkeepControlCenter_Service objUpkeepCC = new UpkeepControlCenter_Service.UpkeepControlCenter_Service();
        //DataSet ds = new DataSet();
        GridView dgGrid = new GridView();

        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        int Request_ID = 0;
        string Full_Name = string.Empty;


        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            Full_Name = Convert.ToString(Session["Full_Name"]);


            Request_ID = Convert.ToInt32(Request.QueryString["Request_ID"]);

            //frmMain.Action = @"Retailer_Master.aspx";
            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect("~/Login.aspx", false);
            }
            else
            {
                View_Request_Details();
            }

            if (lblActionStatus.Text!= "Closed")
            {
                div1.Visible = false;
                div2.Visible = false;
                div3.Visible = true;
                div4.Visible = true;
                btnSumit.Visible = true;
            }
            else if (lblActionStatus.Text == "Closed")
            {
                div1.Visible = true;
                div2.Visible = true;
                div3.Visible = false;
                div4.Visible = false;
                btnSumit.Visible = false;
            }
        }

        public void View_Request_Details()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = objUpkeepCC.SUPPORT_View_Ticket_Details(Request_ID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        lblRequestID.Text = Convert.ToString(ds.Tables[0].Rows[0]["Request_ID"]);
                        lblRequestRaisedBy.Text = Convert.ToString(ds.Tables[0].Rows[0]["Raised_By"]);
                        lblRequestType.Text = Convert.ToString(ds.Tables[0].Rows[0]["Request_Type"]);
                        lblModule.Text = Convert.ToString(ds.Tables[0].Rows[0]["Module_Desc"]);
                        lblActionStatus.Text = Convert.ToString(ds.Tables[0].Rows[0]["Status"]);
                        lblRequestDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["Created_Date"]);
                        lblTicketdesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["Description"]);
                        lblUpdtedby.Text = Convert.ToString(ds.Tables[0].Rows[0]["Updated_By"]);
                        lblUpdatedDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["Updated_Date"]);
                        lblClosingRemarks.Text = Convert.ToString(ds.Tables[0].Rows[0]["Closing_Remarks"]);
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

        protected void btnSumit_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            string ActionStatus = string.Empty;
            ActionStatus = ddlStatus.SelectedValue;

            string Closing_Remarks = string.Empty;
            Closing_Remarks = txtClosingRemarks.InnerText;

            try
            {
                ds = objUpkeepCC.SUPPORT_Update_Ticket_Details(Request_ID, Full_Name, ActionStatus, Closing_Remarks);


                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            Response.Redirect(Page.ResolveClientUrl("~/Support_Portal/View_Request_List.aspx"), false);
                        }
                        else if (Status == 2)
                        {
                            lblError.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
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