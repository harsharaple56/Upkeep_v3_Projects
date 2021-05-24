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

namespace Upkeep_v3.General_Masters
{
    public partial class Vendor_Mst : System.Web.UI.Page
    {

        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        GridView dgGrid = new GridView();
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            //frmMain.Action = @"Retailer_Master.aspx";
            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect("~/Login.aspx", false);
            }
        }



        public string fetchVendorDetails()
        {
            string data = "";
            try
            {

                DataSet ds = new DataSet();
                ds = ObjUpkeep.Fetch_CRUD_Vendor_Mst(0, " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", CompanyID, "List");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Vendor_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Vendor_ID"]);
                            string Vendor_Name = Convert.ToString(ds.Tables[0].Rows[i]["Vendor_Name"]);
                            string Vendor_Reg_ID = Convert.ToString(ds.Tables[0].Rows[i]["Vendor_Reg_ID"]);
                            string Vendor_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Vendor_Desc"]);
                            string Vendor_Contact1 = Convert.ToString(ds.Tables[0].Rows[i]["Vendor_Contact1"]);
                            string Vendor_Contact2 = Convert.ToString(ds.Tables[0].Rows[i]["Vendor_Contact2"]);
                            string Vendor_Email = Convert.ToString(ds.Tables[0].Rows[i]["Vendor_Email"]);
                            string Vendor_Address = Convert.ToString(ds.Tables[0].Rows[i]["Vendor_Address"]);
                            string Vendor_GSTIN = Convert.ToString(ds.Tables[0].Rows[i]["Vendor_GSTIN"]);
                            string Vendor_PAN = Convert.ToString(ds.Tables[0].Rows[i]["Vendor_PAN"]);
                            string Vendor_Bank_Details = Convert.ToString(ds.Tables[0].Rows[i]["Vendor_Bank_Details"]);
                            string Created_By = Convert.ToString(ds.Tables[0].Rows[i]["Created_By"]);
                            string Created_Date = Convert.ToString(ds.Tables[0].Rows[i]["Created_Date"]);

                            data += "<tr><td>" + Vendor_Name + "</td><td>" + Vendor_Reg_ID + "</td><td>" + Vendor_Desc + "</td><td>" + Vendor_Contact1 + "</td><td>" + Vendor_Email + "</td><td>" + Vendor_GSTIN + "</td><td>" + Created_By + "</td><td>" + Created_Date + "</td> <td style='width: 10%;'><a href='Add_Vendor.aspx?Vendor_ID=" + Vendor_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record'> <i class='la la-edit'></i> </a> <a href='Add_Vendor.aspx?Del_Vendor_ID=" + Vendor_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

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