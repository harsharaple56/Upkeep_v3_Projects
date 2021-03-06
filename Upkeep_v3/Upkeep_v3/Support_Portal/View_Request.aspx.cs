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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace Upkeep_v3.Support_Portal
{
    public partial class View_Request : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        //DataSet ds = new DataSet();
        GridView dgGrid = new GridView();

        string LoggedInUserID = string.Empty;
        string Role_Name = string.Empty;
        int CompanyID = 0;
        int Request_ID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            Request_ID = Convert.ToInt32(Request.QueryString["Request_ID"]);


            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }

            if (!IsPostBack)
            {
                View_Request_Details();
            }
        }


        public void View_Request_Details()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = ObjUpkeep.SUPPORT_View_Request_Details(Request_ID, CompanyID, LoggedInUserID);

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

        public string View_Request_Comments()
        {
            string data = "";
            DataSet ds = new DataSet();

            try
            {
                ds = ObjUpkeep.SUPPORT_Fetch_Comments(Request_ID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        
                        for (int i = 0; i < count; i++)
                        {

                           
                            string Client_User_ID = Convert.ToString(ds.Tables[0].Rows[i]["Client_User_ID"]);
                            string Comment_Date = Convert.ToString(ds.Tables[0].Rows[i]["Comment_Date"]);
                            string Support_User_ID = Convert.ToString(ds.Tables[0].Rows[i]["Support_User_ID"]);
                            string Comment_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Comment_Desc"]);

                            data += "<tr><td>" + Client_User_ID + "</td><td>" + Support_User_ID + "</td><td>" + Comment_Desc + "</td></tr>";


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


        protected void btnSaveComment_Click(object sender, EventArgs e)
        {
            string Comment = Convert.ToString(txtcomment.Text);

            DataSet ds = new DataSet();
            Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();

            ds = ObjUpkeep.SUPPORT_Save_Comment_Client(Request_ID, Comment, LoggedInUserID);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                    if (Status == 1)
                    {
                        Response.Redirect(Page.ResolveClientUrl("~/Support_Portal/View_Request.aspx?Request_ID="+ Request_ID), false);
                    }
                }
            }

        }


    }
}