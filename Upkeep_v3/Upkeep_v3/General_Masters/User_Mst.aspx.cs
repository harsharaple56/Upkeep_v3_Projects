using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
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
    public partial class User_Mst : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();

        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        GridView dgGrid = new GridView();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect("~/Login.aspx", false);
            }
            if (!IsPostBack)
            {
                bindGrid();
            }



        }


        public string bindGrid()
          {
            string data = "";
            try
            {
                DataSet ds = new DataSet();

                ds = ObjUpkeep.UserMaster_CRUD(0, "", "", "","", "", "", "", "",0,0,0,0,0,"","",0,0,0,0,"","", CompanyID, LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int User_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["User_ID"]);
                            string UserCode = Convert.ToString(ds.Tables[0].Rows[i]["User_Code"]);
                            string Name = Convert.ToString(ds.Tables[0].Rows[i]["Name"]);
                            //string f_name = Convert.ToString(ds.Tables[0].Rows[i]["F_Name"]);
                            //string LastName = Convert.ToString(ds.Tables[0].Rows[i]["L_Name"]);
                            string UserDesignation = Convert.ToString(ds.Tables[0].Rows[i]["User_Designation"]);
                            string User_Email = Convert.ToString(ds.Tables[0].Rows[i]["User_Email"]);
                            string Usermobile = Convert.ToString(ds.Tables[0].Rows[i]["User_Mobile"]);
                            string Is_Approver = Convert.ToString(ds.Tables[0].Rows[i]["Approver"]);
                            string Is_GlobalApprover = Convert.ToString(ds.Tables[0].Rows[i]["GlobalApprover"]);
                            string Created_Date = Convert.ToString(ds.Tables[0].Rows[i]["Created_Date"]);
                            

                            string Created_On = Created_Date.Substring(0, 10);
                            DateTime dt;

                            if (DateTime.TryParseExact(Created_On, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out dt))
                            {
                                Created_On = dt.ToString("dd/MMM/yyyy");
                            }

                            data += "<tr><td>" + UserCode + "</td><td>" + Name + "</td><td>" + UserDesignation + "</td><td>" + User_Email + "</td><td>" + Usermobile + "</td><td>" + Is_Approver + "</td><td>" + Is_GlobalApprover + "</td><td>" + Created_On + "</td><td><a href='Add_User_Mst.aspx?User_ID=" + User_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top'> <i class='la la-edit'></i> </a>  <a href='Add_User_Mst.aspx?DelUser_ID=" + User_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' > 	<i class='la la-trash'></i> </a> </td></tr>";
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

        protected void lnkSampleFile_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "~/General_Masters/Template/eFacilito_User_Data_Import.xlsx";

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
            mpeUserMst.Hide();
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            //ExportToExcel();
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
                dsRetailer = ObjUpkeep.Retailer_CRUD("", "", "", "", 0, 0, "", "", CompanyID, LoggedInUserID, "R");
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

        protected void btnImportExcel_Click(object sender, EventArgs e)
        {
            DataSet dsResult = new DataSet();

            if (FU_UserMst.PostedFile != null)
            {
                try
                {
                    string path = string.Concat(Server.MapPath("~/RetailerUploadFile/" + FU_UserMst.FileName));
                    FU_UserMst.SaveAs(path);
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
                        bulkInsert.DestinationTableName = "Tbl_UserMst_Import";
                        bulkInsert.ColumnMappings.Add("User_Code", "UserCode");
                        bulkInsert.ColumnMappings.Add("First_Name", "FirstName");
                        bulkInsert.ColumnMappings.Add("Last_Name", "LastName");
                        bulkInsert.ColumnMappings.Add("Department", "Department");
                        bulkInsert.ColumnMappings.Add("Designation", "Designation");
                        bulkInsert.ColumnMappings.Add("Role", "Role");
                        bulkInsert.ColumnMappings.Add("Email", "EmailID");
                        bulkInsert.ColumnMappings.Add("Mobile_No", "MobileNo");
                        bulkInsert.ColumnMappings.Add("Username", "Username");
                        
                        bulkInsert.WriteToServer(dr);


                        //dsResult = ObjUpkeep.ImportRetailer(CompanyID);

                        if (dsResult.Tables.Count > 0)
                        {
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                               
                                dvErrorGrid.Attributes.Add("style", "display:block; overflow-y:auto; height:280px;");

                                mpeUserMst.Show();
                                lblImportErrorMsg.Text = "Below mentioned users can not be created, kindly check error message.";
                                gvImportError.DataSource = dsResult;
                                gvImportError.DataBind();
                            }
                            else
                            {
                                bindGrid();
                            }
                        }
                        else
                        {
                            bindGrid();
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

    }


}
