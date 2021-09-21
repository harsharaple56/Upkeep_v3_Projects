using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Text;
using System.Data;
using System.Globalization;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Upkeep_v3.AssetManagement
{
    public partial class AssetManagementList : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            hdn_IsPostBack.Value = "yes";
            if (!IsPostBack)
            {
                hdn_IsPostBack.Value = "no";
                Session["PreviousURL"] = HttpContext.Current.Request.Url.AbsoluteUri;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            fetchListing();
        }

        public string fetchListing()
        {
            string data = "";
            string From_Date = string.Empty;
            string To_Date = string.Empty;

            try
            {
                //if (start_date.Value != "")
                //{
                //    From_Date = Convert.ToString(start_date.Value);
                //}
                //else
                //{
                //    From_Date = DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);

                //}

                //if (end_date.Value != "")
                //{
                //    To_Date = Convert.ToString(end_date.Value);
                //}
                //else
                //{
                //    DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture)).AddDays(30);
                //    To_Date = FromDate.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
                //}

                DataSet ds = new DataSet();
                ds = ObjUpkeep.Fetch_MyAsset(LoggedInUserID, "", "");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            string Asset_ID = Convert.ToString(ds.Tables[0].Rows[i]["Asset_ID"]);
                            string Asset_Name = Convert.ToString(ds.Tables[0].Rows[i]["Asset_Name"]);
                            //string Asset_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Asset_Desc"]);
                            //string Asset_Make = Convert.ToString(ds.Tables[0].Rows[i]["Asset_Make"]);
                            string Asset_Serial_No = Convert.ToString(ds.Tables[0].Rows[i]["Asset_Serial_No"]);
                            string Asset_Type = Convert.ToString(ds.Tables[0].Rows[i]["Asset_Type"]);
                            string Asset_Category = Convert.ToString(ds.Tables[0].Rows[i]["Asset_Category"]);
                            string Vendor = Convert.ToString(ds.Tables[0].Rows[i]["Vendor"]);
                            string Department = Convert.ToString(ds.Tables[0].Rows[i]["Department"]);
                            string Location = Convert.ToString(ds.Tables[0].Rows[i]["Location"]);

                            //string Asset_Cost = Convert.ToString(ds.Tables[0].Rows[i]["Asset_Cost"]);
                            //string Currency_Type = Convert.ToString(ds.Tables[0].Rows[i]["Currency_Type"]);
                            //string Asset_Purchase_Date = Convert.ToString(ds.Tables[0].Rows[i]["Asset_Purchase_Date"]);
                            //string Asset_Is_AMC_Active = Convert.ToString(ds.Tables[0].Rows[i]["Asset_Is_AMC_Active"]);
                            //string Created_By = Convert.ToString(ds.Tables[0].Rows[i]["Created_By"]);
                            //string Created_Date = Convert.ToString(ds.Tables[0].Rows[i]["Created_Date"]);
                            string AMC_Status = Convert.ToString(ds.Tables[0].Rows[i]["AMC_Status"]);


                            //Asset_ID Asset_Name  Asset_Desc Asset_Make  Asset_Serial_No Asset_Type  Asset_Category Vendor  Department Location    
                            //    Asset_Cost Currency_Type   Asset_Purchase_Date Asset_Is_AMC_Active Created_By Created_Date

                            //data += "<tr><td> " + "<a href='AssetManagementRequest.aspx?TransactionID=" + Asset_ID + "> " + Asset_ID + " </a></td>" +
                            //    "<td>" + Asset_Name + "</td>" +
                            //    "<td>" + Asset_Serial_No + "</td>" +
                            //    "<td>" + Asset_Type + "</td>" +
                            //    "<td>" + Asset_Category + "</td>"+ 
                            //    "<td>" + Department + "</td>" +
                            //    "<td>" + Location + "</td>" +
                            //    "<td>" + AMC_Status + "</td>" +
                            //    "</tr>";

                            data += "<tr><td><a href='AssetManagementRequest.aspx?TransactionID=" + Asset_ID + "'> " + Asset_ID + " </a></td><td>" + Asset_Name + "</td><td>" + Asset_Serial_No + "</td><td>" + Asset_Type + "</td><td>" + Asset_Category + "</td><td>" + Department + "</td><td>" + Location + "</td><td>" + AMC_Status + "</td> </tr>";


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

        protected void btnExportPDF_Click(object sender, EventArgs e)
        {
            GridView dgGrid = new GridView();

            Document doc = new Document();
            try
            {
                DataSet dsReport = new DataSet();

                dsReport = ObjUpkeep.Fetch_MyAsset(LoggedInUserID, "", "");

                DataTable dtReport = new DataTable();
                dtReport = dsReport.Tables[0];

                if (dtReport != null)
                {
                    if (dtReport.Rows.Count > 0)
                    {

                        dtReport.Columns.Remove("Asset_ID");
                        dtReport.Columns.Remove("Asset_Desc");
                        dtReport.Columns.Remove("Asset_Make");
                        dtReport.Columns.Remove("Asset_Cost");
                        dtReport.Columns.Remove("IsAmc");
                        dtReport.Columns.Remove("AMC_Start_Date");
                        dtReport.Columns.Remove("AMC_End_Date");
                        dtReport.Columns.Remove("Vendor_Name");
                        dtReport.Columns.Remove("AmcType");
                        dtReport.Columns.Remove("Created_By");
                        dtReport.Columns.Remove("Created_Date");
                        dtReport.Columns["Asset_Name"].ColumnName = "Asset Name";
                        dtReport.Columns["Asset_Serial_No"].ColumnName = "Asset Serial No";
                        dtReport.Columns["Asset_Type"].ColumnName = "Asset Type";
                        dtReport.Columns["Asset_Category"].ColumnName = "Asset Category";
                        dtReport.Columns["Vendor"].ColumnName = "Vendor";
                        dtReport.Columns["Department"].ColumnName = "Department";
                        dtReport.Columns["Location"].ColumnName = "Location";
                        dtReport.Columns["AMC_Status"].ColumnName = "AMC Status";
                        dtReport.AcceptChanges();

                        dgGrid.DataSource = dtReport;
                        dgGrid.DataBind();


                        System.IO.StringWriter tw = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                        string filename = "ASSET_LIST_REPORT" + DateTime.Now + ".pdf";

                        string HeaderText = "ASSET LIST REPORT AS ON " + DateTime.Now;

                        Style textStyle = new Style();
                        textStyle.ForeColor = System.Drawing.Color.DarkCyan;
                        hw.EnterStyle(textStyle);

                        hw.Write("<h2><center>" + HeaderText + "</center></h2> </br>");
                        hw.ExitStyle(textStyle);

                        //Write the HTML back to the browser.

                        Response.ContentType = "application/pdf";
                        //Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                        Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}.pdf", "ASSET_LIST_REPORT"));


                        iTextSharp.text.pdf.PdfPTable grd;

                        PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
                        doc.Open();

                        grd = new PdfPTable(dtReport.Columns.Count);
                        grd.WidthPercentage = 100.0F;

                        PdfPCell cellRptNm = new PdfPCell(new Phrase("ASSET LIST REPORT AS ON " + DateTime.Now));
                        cellRptNm.HorizontalAlignment = 1;
                        cellRptNm.Colspan = dtReport.Columns.Count;
                        cellRptNm.Border = 0;
                        cellRptNm.PaddingBottom = 20.0F;
                        grd.AddCell(cellRptNm);

                        BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                        iTextSharp.text.Font fnt = new iTextSharp.text.Font(bfTimes, 7);

                        for (var IntLocColCnt = 0; IntLocColCnt <= dtReport.Columns.Count - 1; IntLocColCnt++)
                        {
                            PdfPCell cellHD1 = new PdfPCell(new Phrase(dtReport.Columns[IntLocColCnt].ColumnName, fnt));
                            cellHD1.PaddingBottom = 10.0F;
                            cellHD1.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
                            cellHD1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            cellHD1.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                            grd.AddCell(cellHD1);
                        }

                        for (var IntLocRowCnt = 0; IntLocRowCnt <= dtReport.Rows.Count - 1; IntLocRowCnt++)
                        {
                            for (var IntLocColCnt = 0; IntLocColCnt <= dtReport.Columns.Count - 1; IntLocColCnt++)
                            {
                                string str = Convert.ToString(dtReport.Rows[IntLocRowCnt][IntLocColCnt]);
                                PdfPCell cell = new PdfPCell(new Phrase(str, fnt));
                                cell.PaddingBottom = 10.0F;
                                grd.AddCell(cell);
                            }
                        }
                        doc.Add(grd);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                doc.Close();
            }
            Response.End();
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            GridView dgGrid = new GridView();
            DataSet dsExport = new DataSet();
            string currentDate = string.Empty;
            try
            {
                dsExport = ObjUpkeep.Fetch_MyAsset(LoggedInUserID, "", "");

                DataTable dtCTTReport = new DataTable();

                if (dsExport.Tables.Count > 0)
                {
                    if (dsExport.Tables[0].Rows.Count > 0)
                    {
                        dtCTTReport = dsExport.Tables[0];

                        dtCTTReport.Columns.Remove("Asset_ID");
                        dtCTTReport.Columns["Asset_Name"].ColumnName = "Asset Name";
                        dtCTTReport.Columns["Asset_Serial_No"].ColumnName = "Asset Serial No";
                        dtCTTReport.Columns["Asset_Type"].ColumnName = "Asset Type";
                        dtCTTReport.Columns["Asset_Category"].ColumnName = "Asset Category";
                        dtCTTReport.Columns["Vendor"].ColumnName = "Vendor";
                        dtCTTReport.Columns["Department"].ColumnName = "Department";
                        dtCTTReport.Columns["Location"].ColumnName = "Location";
                        dtCTTReport.Columns["AMC_Status"].ColumnName = "AMC Status";
                        dtCTTReport.AcceptChanges();

                        dgGrid.DataSource = dtCTTReport;
                        dgGrid.DataBind();

                        currentDate = DateTime.Now.ToString();

                        System.IO.StringWriter tw = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                        string filename = "ASSET LIST REPORT AS ON " + currentDate + ".xls";

                        string HeaderText = "ASSET LIST REPORT AS ON " + currentDate;

                        Style textStyle = new Style();
                        textStyle.ForeColor = System.Drawing.Color.DarkCyan;
                        hw.EnterStyle(textStyle);

                        hw.Write("<h2><center>" + HeaderText + "</center></h2> </br>");
                        hw.ExitStyle(textStyle);

                        dgGrid.RenderControl(hw);

                        Response.ContentType = "application/vnd.ms-excel";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                        this.EnableViewState = false;
                        Response.Write(tw.ToString());
                        Response.End();
                        return;

                    }
                    else
                    {
                        dgGrid.DataSource = null;
                        dgGrid.DataBind();

                        return;
                    }
                }
                else
                {
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

        protected void btnImport_Click(object sender, EventArgs e)
        {
            DataSet dsResult = new DataSet();

            if (FU_AssetMst.HasFile && FU_AssetMst.PostedFile != null)
            {
                try
                {
                    string path = string.Concat(Server.MapPath("~/Checklist/ImportFile/" + FU_AssetMst.FileName));
                    string extension = Path.GetExtension(FU_AssetMst.PostedFile.FileName);
                    FU_AssetMst.SaveAs(path);

                    // Connection String to Excel Workbook  
                    string conString = string.Empty;
                    switch (extension)
                    {
                        case ".xls": //For Excel 97-03.  
                            conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                            break;
                        case ".xlsx": //For Excel 07 and above.  
                            conString = ConfigurationManager.ConnectionStrings["Excel07+ConString"].ConnectionString;
                            break;
                    }
                    string excelCS = string.Format(conString, path);

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
                        bulkInsert.DestinationTableName = "Tbl_Asset_Temp_Import";
                        bulkInsert.ColumnMappings.Add("Asset Type", "Asset_Type_ID");
                        bulkInsert.ColumnMappings.Add("Asset Category", "Asset_Category_ID");
                        bulkInsert.ColumnMappings.Add("Asset Name", "Asset_Name");
                        bulkInsert.ColumnMappings.Add("Asset Description", "Asset_Desc");
                        bulkInsert.ColumnMappings.Add("Manufactured By", "Asset_Make");
                        bulkInsert.ColumnMappings.Add("Serial No", "Asset_Serial_No");
                        bulkInsert.ColumnMappings.Add("Assigned Department", "Department_ID");
                        bulkInsert.ColumnMappings.Add("Assigned Location", "Loc_id");
                        bulkInsert.ColumnMappings.Add("Vendor ( Purchased from )", "Vendor_ID");
                        bulkInsert.ColumnMappings.Add("Asset Cost", "Asset_Cost");
                        bulkInsert.ColumnMappings.Add("Currency Type", "Currency_Type");
                        bulkInsert.ColumnMappings.Add("Asset Purchase Date","Asset_Purchase_Date");

                        bulkInsert.WriteToServer(dr);

                        dsResult = ObjUpkeep.Import_AssetList_Master(CompanyID, LoggedInUserID);

                        if (dsResult.Tables.Count > 0)
                        {
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                DataTable dtCTTReport = new DataTable();
                                dtCTTReport = dsResult.Tables[0];
                                dtCTTReport.Columns["Asset_Name"].ColumnName = "Asset Name";
                                dtCTTReport.Columns["Asset_Type_ID"].ColumnName = "Asset Type";
                                dtCTTReport.Columns["Asset_Category_ID"].ColumnName = "Asset Category";
                                dtCTTReport.Columns["Department_ID"].ColumnName = "Department";
                                dtCTTReport.Columns["Loc_id"].ColumnName = "Location";
                                dtCTTReport.Columns["Vendor_ID"].ColumnName = "Vendor";
                                dtCTTReport.AcceptChanges();

                                dvErrorGrid.Attributes.Add("style", "display:block; overflow-y:auto; height:210px;");
                                pnlImportExport.Attributes.Add("style", "height:580px; width:700px; top:-14px !important;");

                                mpeUserMst.Show();
                                lblImportErrorMsg.Text = "Below Asset List can not be created, kindly check error message.";
                                gvImportError.DataSource = dtCTTReport;
                                gvImportError.DataBind();
                            }
                            else
                            {
                                fetchListing();
                            }
                        }
                        else
                        {
                            fetchListing();
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
            }
        }

        protected void btnCloseImportPopUp_Click(object sender, EventArgs e)
        {
            lblImportErrorMsg.Text = "";
            gvImportError.DataSource = null;
            gvImportError.DataBind();
            mpeUserMst.Hide();
        }

        protected void lnkSampleFile_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "~/General_Masters/Template/Asset_Management_List_Template.xlsx";
                string filename = "Asset_Management_List_Template.xlsx";
                Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");
                Response.TransmitFile(Server.MapPath(filePath));

                Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }



}