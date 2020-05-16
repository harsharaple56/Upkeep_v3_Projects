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




namespace Upkeep_Gatepass_Workpermit.Feedback
{
    public partial class Retailer_Master : System.Web.UI.Page
    {
        Upkeep_GP_WP_Services.Upkeep_GP_WP_Services ObjUpkeepFeedback = new Upkeep_GP_WP_Services.Upkeep_GP_WP_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        GridView dgGrid = new GridView();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            //frmMain.Action = @"Retailer_Master.aspx";
            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                //Response.Redirect("~/Login.aspx", false);
            }
        }

        public string fetchRetailerDetails()
        {
            string data = "";
            try
            {

                DataSet ds = new DataSet();
                ds = ObjUpkeepFeedback.Retailer_CRUD("", "", "", "", 0, 0,"","", LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int RetID = Convert.ToInt32(ds.Tables[0].Rows[i]["Retailer_ID"]);
                            string StoreName = Convert.ToString(ds.Tables[0].Rows[i]["Store_Name"]);
                            string ManagerName = Convert.ToString(ds.Tables[0].Rows[i]["Name"]);

                            string PhoneNo = Convert.ToString(ds.Tables[0].Rows[i]["PhoneNo"]);
                            string EmailID = Convert.ToString(ds.Tables[0].Rows[i]["EmailID"]);
                            string Created_Date = Convert.ToString(ds.Tables[0].Rows[i]["Created_Date"]);

                            data += "<tr><td>" + StoreName + "</td><td>" + ManagerName + "</td><td>" + EmailID + "</td><td>" + PhoneNo + "</td><td>" + Created_Date + "</td> <td><a href='Add_Retailer.aspx?RetID=" + RetID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record'> <i class='la la-edit'></i> </a> <a href='Add_Retailer.aspx?DelRetID=" + RetID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

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
        protected void btnImportExcel_Click(object sender, EventArgs e)
        {
            
            //UploadRetailer();
            ImportFromExcel();
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        public void ExportToExcel()
        {

            DataSet dsRetailer = new DataSet();
            dsRetailer = ObjUpkeepFeedback.Retailer_CRUD("", "", "", "", 0, 0,"","", "", "R");

            System.Data.DataTable dtRetailer = new System.Data.DataTable();
            dtRetailer = dsRetailer.Tables[0];

            if (dsRetailer != null)
            {
                if (dsRetailer.Tables.Count > 0)
                {
                    if (dsRetailer.Tables[0].Rows.Count > 0)
                    {
                        dtRetailer.Columns.Remove("Retailer_ID");
                        dtRetailer.Columns["Store_Name"].ColumnName = "Store Name";
                        dtRetailer.Columns["Name"].ColumnName = "Manager Name";
                        //dtCustomer.Columns.Remove("ImagePath");
                        ////dtCustomer.Columns.Remove("User_ID");
                        dtRetailer.AcceptChanges();

                        System.IO.StringWriter tw = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                        string filename = "Feedback_Retailers_" + DateTime.Now + ".xls";


                        //btnExportToExcel.Visible = true;
                        //dgGrid.DataSource = dsMisReport.Tables[0];
                        dgGrid.DataSource = dtRetailer;
                        dgGrid.DataBind();
                        //Get the HTML for the control.
                        dgGrid.RenderControl(hw);


                        //Write the HTML back to the browser.

                        Response.ContentType = "application/vnd.ms-excel";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                        this.EnableViewState = false;
                        Response.Write(tw.ToString());
                        Response.End();
                        return;
                    }
                }
            }
            else
            {
                //lblError.Visible = true;
                //lblError.Text = "No Data Found";

                dgGrid.DataSource = null;
                dgGrid.DataBind();

                return;
            }
        }

        public void ImportFromExcel()
        {
            DataSet dsResult = new DataSet();

            if (fileUpload.PostedFile != null)
            {
                try
                {
                    string path = string.Concat(Server.MapPath("~/Feedback/RetailerUploadFile/" + fileUpload.FileName));
                    fileUpload.SaveAs(path);
                    // Connection String to Excel Workbook  
                    string excelCS = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);
                    using (OleDbConnection con = new OleDbConnection(excelCS))
                    {
                        OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", con);
                        con.Open();
                        // Create DbDataReader to Data Worksheet  
                        DbDataReader dr = cmd.ExecuteReader();
                        // SQL Server Connection String  
                        string CS = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString;
                       

                        // Bulk Copy to SQL Server   
                        SqlBulkCopy bulkInsert = new SqlBulkCopy(CS);
                        bulkInsert.DestinationTableName = "Tbl_RetailerImport";
                        bulkInsert.ColumnMappings.Add("StoreName", "Store_Name");
                        bulkInsert.ColumnMappings.Add("FirstName", "FirstName");
                        bulkInsert.ColumnMappings.Add("LastName", "LastName");
                        bulkInsert.ColumnMappings.Add("PhoneNo", "PhoneNo");
                        bulkInsert.ColumnMappings.Add("EmailID", "EmailID");
                        bulkInsert.WriteToServer(dr);

                        
                        dsResult = ObjUpkeepFeedback.ImportRetailer();

                        if (dsResult.Tables.Count > 0)
                        {
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                //ClientScript.RegisterStartupScript(this.GetType(), "showPopup", true);

                                //ClientScript.RegisterStartupScript(GetType(), "id", "showErrorPopup()", true);

                                Page.ClientScript.RegisterStartupScript(this.GetType(), "showPopup", "showErrorPopup()", true);

                                //ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:showErrorPopup(); ", true);

                                gvImportError.DataSource = dsResult;
                                gvImportError.DataBind();
                            }
                            else
                            {
                                fetchRetailerDetails();
                            }
                        }
                        else
                        {
                            fetchRetailerDetails();
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;

                }
            }
            else
            {
                //lbl
            }
        }

        protected void UploadRetailer()
        {
            try
            {
                DataSet dsResult = new DataSet();
                //Upload and save the file
                string excelPath = Server.MapPath("~/Feedback/RetailerUploadFile/") + Path.GetFileName(fileUpload.PostedFile.FileName);
                fileUpload.SaveAs(excelPath);

                string conString = string.Empty;
                string extension = Path.GetExtension(fileUpload.PostedFile.FileName);
                switch (extension)
                {
                    case ".xls": //Excel 97-03
                        conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                        break;
                    case ".xlsx": //Excel 07 or higher
                        conString = ConfigurationManager.ConnectionStrings["Excel07+ConString"].ConnectionString;
                        break;

                }
                conString = string.Format(conString, excelPath);
                using (OleDbConnection excel_con = new OleDbConnection(conString))
                {
                    excel_con.Open();
                    string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                    System.Data.DataTable dtExcelData = new System.Data.DataTable();

                    //[OPTIONAL]: It is recommended as otherwise the data will be considered as String by default.
                    dtExcelData.Columns.AddRange(new DataColumn[5]
                    {
                     new DataColumn("StoreName", typeof(string)),
                     new DataColumn("FirstName", typeof(string)),
                     new DataColumn("LastName", typeof(string)),
                     new DataColumn("PhoneNo", typeof(string)),
                     new DataColumn("EmailID", typeof(string))
                    });

                    using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
                    {
                        oda.Fill(dtExcelData);
                    }
                    excel_con.Close();

                    string consString = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(consString))
                    {
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                        {
                            //Set the database table name
                            //[OPTIONAL]: Map the Excel columns with that of the database table
                            sqlBulkCopy.ColumnMappings.Add("StoreName", "Store_Name");
                            sqlBulkCopy.ColumnMappings.Add("FirstName", "FirstName");
                            sqlBulkCopy.ColumnMappings.Add("LastName", "LastName");
                            sqlBulkCopy.ColumnMappings.Add("PhoneNo", "PhoneNo");
                            sqlBulkCopy.ColumnMappings.Add("EmailID", "EmailID");
                            con.Open();
                            sqlBulkCopy.WriteToServer(dtExcelData);
                            con.Close();

                            dsResult = ObjUpkeepFeedback.ImportRetailer();

                            if (dsResult.Tables.Count > 0)
                            {
                                if (dsResult.Tables[0].Rows.Count > 0)
                                {
                                    //ClientScript.RegisterStartupScript(this.GetType(), "showPopup", true);

                                    //ClientScript.RegisterStartupScript(GetType(), "id", "showErrorPopup()", true);

                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "showPopup", "showErrorPopup()", true);

                                    //ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:showErrorPopup(); ", true);

                                    gvImportError.DataSource = dsResult;
                                    gvImportError.DataBind();
                                }
                                else
                                {
                                    fetchRetailerDetails();
                                }
                            }
                            else
                            {
                                fetchRetailerDetails();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        protected void lnkSampleFile_Click(object sender, EventArgs e)
        {
            string filePath = "~/Feedback/Template/RetailerData.xlsx";

            //string filePath = "~/Feedback/Template/RetailerData.xls";
            //string filePath = Page.ResolveClientUrl("~/Feedback/Template/RetailerData.xls");

            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
            Response.TransmitFile(Server.MapPath(filePath));

            Response.End();



        }

        private static string NewMethod()
        {
            return "~/FeedBack/Template/RetailerData.xls";
        }
    }
}