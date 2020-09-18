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
    public partial class Retailer_Master : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeepFeedback = new Upkeep_V3_Services.Upkeep_V3_Services();
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

        public string fetchRetailerDetails()
        {
            string data = "";
            try
            {

                DataSet ds = new DataSet();
                ds = ObjUpkeepFeedback.Retailer_CRUD("", "", "", "", 0, 0,"","", CompanyID, LoggedInUserID, "R");

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
            ImportFromExcel();
             //UploadRetailer();
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        protected void btnExportPDF_Click1(object sender, EventArgs e)
        {
            //ExportToPDF();
            try
            {
                DataSet dsRetailer = new DataSet();
                dsRetailer = ObjUpkeepFeedback.Retailer_CRUD("", "", "", "", 0, 0, "", "", CompanyID, LoggedInUserID, "R");

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
                            dtRetailer.Columns.Remove("Password");
                            ////dtCustomer.Columns.Remove("User_ID");
                            dtRetailer.AcceptChanges();

                            System.IO.StringWriter tw = new System.IO.StringWriter();
                            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                            string filename = "Retailers_Master_" + DateTime.Now + ".pdf";

                            string HeaderText = "RETAILERS MASTER AS ON " + DateTime.Now;

                            //Style textStyle = new Style();
                            //textStyle.ForeColor = System.Drawing.Color.DarkCyan;
                            //hw.EnterStyle(textStyle);

                            //hw.Write("<h2><center>" + HeaderText + "</center></h2> </br>");
                            //hw.ExitStyle(textStyle);

                            //dgGrid.RenderControl(hw);



                            //btnExportToExcel.Visible = true;
                            //dgGrid.DataSource = dsMisReport.Tables[0];
                            //dgGrid.DataSource = dtRetailer;
                            //dgGrid.DataBind();
                            ////Get the HTML for the control.
                            //dgGrid.RenderControl(hw);


                            //Write the HTML back to the browser.

                            Response.ContentType = "application/pdf";
                            //Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                            Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}.pdf", "RETAILERS MASTER AS ON " + DateTime.Now));

                            Document doc = new Document();

                            //this.EnableViewState = false;
                            //Response.Write(tw.ToString());
                            //Response.End();
                            //return;
                            iTextSharp.text.pdf.PdfPTable grd;

                            PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
                            doc.Open();

                            grd = new PdfPTable(dtRetailer.Columns.Count);
                            grd.WidthPercentage = 100.0F;

                            PdfPCell cellRptNm = new PdfPCell(new Phrase("RETAILERS MASTER AS ON " + DateTime.Now));
                            cellRptNm.HorizontalAlignment = 1;
                            cellRptNm.Colspan = dtRetailer.Columns.Count;
                            cellRptNm.Border = 0;
                            cellRptNm.PaddingBottom = 20.0F;
                            grd.AddCell(cellRptNm);

                            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                            iTextSharp.text.Font fnt = new iTextSharp.text.Font(bfTimes, 7);

                            for (var IntLocColCnt = 0; IntLocColCnt <= dtRetailer.Columns.Count - 1; IntLocColCnt++)
                            {
                                PdfPCell cellHD1 = new PdfPCell(new Phrase(dtRetailer.Columns[IntLocColCnt].ColumnName, fnt));
                                cellHD1.PaddingBottom = 10.0F;
                                cellHD1.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                                cellHD1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                                cellHD1.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                                grd.AddCell(cellHD1);
                            }

                            for (var IntLocRowCnt = 0; IntLocRowCnt <= dtRetailer.Rows.Count - 1; IntLocRowCnt++)
                            {
                                for (var IntLocColCnt = 0; IntLocColCnt <= dtRetailer.Columns.Count - 1; IntLocColCnt++)
                                {
                                    //string str = IIf(IsDBNull(dtBaggageReport.Rows[IntLocRowCnt][IntLocColCnt]), "", dtBaggageReport.Rows[IntLocRowCnt][IntLocColCnt]);
                                    string str = Convert.ToString(dtRetailer.Rows[IntLocRowCnt][IntLocColCnt]);
                                    PdfPCell cell = new PdfPCell(new Phrase(str, fnt));
                                    cell.PaddingBottom = 10.0F;
                                    grd.AddCell(cell);
                                }
                            }
                            doc.Add(grd);
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnExportPDF_Click(object sender, EventArgs e)
        {
           
            DataSet dsRetailer = new DataSet();

            // Specify the content type.
            Response.ContentType = "application/pdf";

            // Add a Content-Disposition header.
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}.pdf", "RETAILERS MASTER AS ON " + DateTime.Now));

            // Create a Document object
            Document doc = new Document();
            System.Data.DataTable dtRetailerMaster = new System.Data.DataTable();
            try
            {
                dsRetailer = ObjUpkeepFeedback.Retailer_CRUD("", "", "", "", 0, 0, "", "", CompanyID, LoggedInUserID, "R");
                if (dsRetailer != null)
                {
                    if (dsRetailer.Tables.Count > 0)
                    {
                        if (dsRetailer.Tables[0].Rows.Count > 0)
                        {
                            dtRetailerMaster = dsRetailer.Tables[0];
                            dgGrid.DataSource = dtRetailerMaster;
                            dgGrid.DataBind();
                        }
                    }
                }

                dtRetailerMaster.Columns.Remove("Retailer_ID");
                dtRetailerMaster.Columns["Store_Name"].ColumnName = "Store Name";
                dtRetailerMaster.Columns["Name"].ColumnName = "Manager Name";
                dtRetailerMaster.Columns.Remove("Password");
                ////dtCustomer.Columns.Remove("User_ID");
                dtRetailerMaster.AcceptChanges();


                iTextSharp.text.pdf.PdfPTable grd;

                PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
                doc.Open();

                grd = new PdfPTable(dtRetailerMaster.Columns.Count);
                grd.WidthPercentage = 100.0F;

                PdfPCell cellRptNm = new PdfPCell(new Phrase("RETAILERS MASTER AS ON " + DateTime.Now));
                cellRptNm.HorizontalAlignment = 1;
                cellRptNm.Colspan = dtRetailerMaster.Columns.Count;
                cellRptNm.Border = 0;
                cellRptNm.PaddingBottom = 20.0F;
                grd.AddCell(cellRptNm);

                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                iTextSharp.text.Font fnt = new iTextSharp.text.Font(bfTimes, 7);

                for (var IntLocColCnt = 0; IntLocColCnt <= dtRetailerMaster.Columns.Count - 1; IntLocColCnt++)
                {
                    PdfPCell cellHD1 = new PdfPCell(new Phrase(dtRetailerMaster.Columns[IntLocColCnt].ColumnName, fnt));
                    cellHD1.PaddingBottom = 10.0F;
                    cellHD1.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                    cellHD1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellHD1.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    grd.AddCell(cellHD1);
                }

                for (var IntLocRowCnt = 0; IntLocRowCnt <= dtRetailerMaster.Rows.Count - 1; IntLocRowCnt++)
                {
                    for (var IntLocColCnt = 0; IntLocColCnt <= dtRetailerMaster.Columns.Count - 1; IntLocColCnt++)
                    {
                        //string str = IIf(IsDBNull(dtBaggageReport.Rows[IntLocRowCnt][IntLocColCnt]), "", dtBaggageReport.Rows[IntLocRowCnt][IntLocColCnt]);
                        string str = Convert.ToString(dtRetailerMaster.Rows[IntLocRowCnt][IntLocColCnt]);
                        PdfPCell cell = new PdfPCell(new Phrase(str, fnt));
                        cell.PaddingBottom = 10.0F;
                        grd.AddCell(cell);
                    }
                }
                doc.Add(grd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                doc.Close();
            }
            // Indicate that the data to send to the client has ended
            Response.End();

        }


        public void ExportToExcel()
        {

            DataSet dsRetailer = new DataSet();
            dsRetailer = ObjUpkeepFeedback.Retailer_CRUD("", "", "", "", 0, 0,"","", CompanyID, LoggedInUserID, "R");

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
                        dtRetailer.Columns.Remove("Password");
                        ////dtCustomer.Columns.Remove("User_ID");
                        dtRetailer.AcceptChanges();

                        System.IO.StringWriter tw = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                        string filename = "Retailers_Master_" + DateTime.Now + ".xls";

                        string HeaderText = "RETAILERS MASTER AS ON " + DateTime.Now;

                        Style textStyle = new Style();
                        textStyle.ForeColor = System.Drawing.Color.DarkCyan;
                        hw.EnterStyle(textStyle);

                        hw.Write("<h2><center>" + HeaderText + "</center></h2> </br>");
                        hw.ExitStyle(textStyle);

                        //dgGrid.RenderControl(hw);



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

        public void ExportToPDF()
        {

            DataSet dsRetailer = new DataSet();
            dsRetailer = ObjUpkeepFeedback.Retailer_CRUD("", "", "", "", 0, 0, "", "", CompanyID, LoggedInUserID, "R");

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
                        dtRetailer.Columns.Remove("Password");
                        ////dtCustomer.Columns.Remove("User_ID");
                        dtRetailer.AcceptChanges();

                        System.IO.StringWriter tw = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                        string filename = "Retailers_Master_" + DateTime.Now + ".pdf";

                        string HeaderText = "RETAILERS MASTER AS ON " + DateTime.Now;

                        Style textStyle = new Style();
                        textStyle.ForeColor = System.Drawing.Color.DarkCyan;
                        hw.EnterStyle(textStyle);

                        hw.Write("<h2><center>" + HeaderText + "</center></h2> </br>");
                        hw.ExitStyle(textStyle);

                        //dgGrid.RenderControl(hw);



                        //btnExportToExcel.Visible = true;
                        //dgGrid.DataSource = dsMisReport.Tables[0];
                        dgGrid.DataSource = dtRetailer;
                        dgGrid.DataBind();
                        //Get the HTML for the control.
                        dgGrid.RenderControl(hw);


                        //Write the HTML back to the browser.

                        Response.ContentType = "application/pdf";
                        //Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                        Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}.pdf", "BAGGAGE-REPORT-"));

                        Document doc = new Document();

                        //this.EnableViewState = false;
                        //Response.Write(tw.ToString());
                        //Response.End();
                        //return;
                        iTextSharp.text.pdf.PdfPTable grd;

                        PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
                        doc.Open();

                        grd = new PdfPTable(dtRetailer.Columns.Count);
                        grd.WidthPercentage = 100.0F;

                        PdfPCell cellRptNm = new PdfPCell(new Phrase("RETAILERS MASTER AS ON " + DateTime.Now));
                        cellRptNm.HorizontalAlignment = 1;
                        cellRptNm.Colspan = dtRetailer.Columns.Count;
                        cellRptNm.Border = 0;
                        cellRptNm.PaddingBottom = 20.0F;
                        grd.AddCell(cellRptNm);

                        BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                        iTextSharp.text.Font fnt = new iTextSharp.text.Font(bfTimes, 7);

                        for (var IntLocColCnt = 0; IntLocColCnt <= dtRetailer.Columns.Count - 1; IntLocColCnt++)
                        {
                            PdfPCell cellHD1 = new PdfPCell(new Phrase(dtRetailer.Columns[IntLocColCnt].ColumnName, fnt));
                            cellHD1.PaddingBottom = 10.0F;
                            cellHD1.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                            cellHD1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            cellHD1.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                            grd.AddCell(cellHD1);
                        }

                        for (var IntLocRowCnt = 0; IntLocRowCnt <= dtRetailer.Rows.Count - 1; IntLocRowCnt++)
                        {
                            for (var IntLocColCnt = 0; IntLocColCnt <= dtRetailer.Columns.Count - 1; IntLocColCnt++)
                            {
                                //string str = IIf(IsDBNull(dtBaggageReport.Rows[IntLocRowCnt][IntLocColCnt]), "", dtBaggageReport.Rows[IntLocRowCnt][IntLocColCnt]);
                                string str = Convert.ToString(dtRetailer.Rows[IntLocRowCnt][IntLocColCnt]);
                                PdfPCell cell = new PdfPCell(new Phrase(str, fnt));
                                cell.PaddingBottom = 10.0F;
                                grd.AddCell(cell);
                            }
                        }
                        doc.Add(grd);
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

            if (FU_RetailerMst.PostedFile != null)
            {
                try
                {
                    string path = string.Concat(Server.MapPath("~/RetailerUploadFile/" + FU_RetailerMst.FileName));
                    FU_RetailerMst.SaveAs(path);
                    // Connection String to Excel Workbook  
                    string excelCS = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);
                    using (OleDbConnection con = new OleDbConnection(excelCS))
                    {
                        OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", con);
                        con.Open();
                        // Create DbDataReader to Data Worksheet  
                        DbDataReader dr = cmd.ExecuteReader();
                        // SQL Server Connection String  
                        string CS = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString;
                        // Bulk Copy to SQL Server   
                        SqlBulkCopy bulkInsert = new SqlBulkCopy(CS);
                        bulkInsert.DestinationTableName = "Tbl_RetailerImport";
                        bulkInsert.ColumnMappings.Add("Store_Name", "Store_Name");
                        bulkInsert.ColumnMappings.Add("First_Name", "FirstName");
                        bulkInsert.ColumnMappings.Add("Last_Name", "LastName");
                        bulkInsert.ColumnMappings.Add("Phone_No", "PhoneNo");
                        bulkInsert.ColumnMappings.Add("Email_ID", "EmailID");
                        bulkInsert.ColumnMappings.Add("Store_No", "Store_No");
                        bulkInsert.ColumnMappings.Add("Address", "Address");
                        bulkInsert.ColumnMappings.Add("City", "City");
                        bulkInsert.ColumnMappings.Add("State", "State");
                        bulkInsert.ColumnMappings.Add("Pincode", "Pincode");
                        bulkInsert.WriteToServer(dr);


                        dsResult = ObjUpkeepFeedback.ImportRetailer(CompanyID);

                        if (dsResult.Tables.Count > 0)
                        {
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                //ClientScript.RegisterStartupScript(this.GetType(), "showPopup", true);

                                //ClientScript.RegisterStartupScript(GetType(), "id", "showErrorPopup()", true);

                                //Page.ClientScript.RegisterStartupScript(this.GetType(), "showPopup", "showErrorPopup()", true);

                                //ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:showErrorPopup(); ", true);

                                dvErrorGrid.Attributes.Add("style", "display:block; overflow-y:auto; height:280px;");

                                mpeSubCategory.Show();
                                lblImportErrorMsg.Text = "Below Retailers are already exists";
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
                string excelPath = Server.MapPath("~/RetailerUploadFile/") + Path.GetFileName(fileUpload.PostedFile.FileName);
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
                            //bulkInsert.DestinationTableName = "Tbl_RetailerImport";
                            sqlBulkCopy.ColumnMappings.Add("StoreName", "Store_Name");
                            sqlBulkCopy.ColumnMappings.Add("FirstName", "FirstName");
                            sqlBulkCopy.ColumnMappings.Add("LastName", "LastName");
                            sqlBulkCopy.ColumnMappings.Add("PhoneNo", "PhoneNo");
                            sqlBulkCopy.ColumnMappings.Add("EmailID", "EmailID");
                            con.Open();
                            sqlBulkCopy.WriteToServer(dtExcelData);
                            con.Close();

                            dsResult = ObjUpkeepFeedback.ImportRetailer(CompanyID);

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
            try
            {
                string filePath = "~/General_Masters/Template/RetailerData.xlsx";

                //string filePath = "~/Feedback/Template/RetailerData.xls";
                //string filePath = Page.ResolveClientUrl("~/Feedback/Template/RetailerData.xls");

                Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
                Response.TransmitFile(Server.MapPath(filePath));

                Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCloseImportPopUp_Click(object sender, EventArgs e)
        {
            lblImportErrorMsg.Text = "";
            gvImportError.DataSource = null;
            gvImportError.DataBind();
            mpeSubCategory.Hide();
        }
    }
}