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
    public partial class View_Requests : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        //DataSet ds = new DataSet();
        GridView dgGrid = new GridView();

        string LoggedInUserID = string.Empty;
        string Role_Name=string.Empty;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            Role_Name = Convert.ToString(Session["Role_Name"]);

            //frmMain.Action = @"Retailer_Master.aspx";
            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect("~/Login.aspx", false);
            }
        }


        public string fetch_Request_List()
        {
            string data = "";
            try
            {

                DataSet ds = new DataSet();
                Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();

                ds = ObjUpkeep.SUPPORT_Fetch_Requests("","", CompanyID, LoggedInUserID, Role_Name);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Request_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Request_ID"]);
                            string Company_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Company_Desc"]);
                            string Raised_By = Convert.ToString(ds.Tables[0].Rows[i]["Raised_By"]);
                            string Request_Type = Convert.ToString(ds.Tables[0].Rows[i]["Request_Type"]);
                            string Module_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Module_Desc"]);
                            string Status = Convert.ToString(ds.Tables[0].Rows[i]["Status"]);
                            string Created_Date = Convert.ToString(ds.Tables[0].Rows[i]["Created_Date"]);

                            data += "<tr><td>" + Request_ID + "</td><td>" + Raised_By + "</td><td>" + Request_Type + "</td><td>" + Module_Desc + "</td><td>" + Status + "</td><td>" + Created_Date + "</td> <td style='width: 10%;'><a href='Add_Retailer.aspx?RetID=" + Request_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record'> <i class='la la-edit'></i> </a> </td></tr>";

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


    }
}