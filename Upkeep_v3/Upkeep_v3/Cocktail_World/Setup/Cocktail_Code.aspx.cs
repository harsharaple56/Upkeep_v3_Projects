using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Cocktail_World.Setup
{
    public partial class Cocktail_Code : System.Web.UI.Page
    {
        CocktailWorld_Service.CocktailWorld_Service ObjCocktailWorld = new CocktailWorld_Service.CocktailWorld_Service();

        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            if (!IsPostBack)
            {
                Fetch_License();
            }
        }

        private void Fetch_License()
        {
            ds = ObjCocktailWorld.License_CRUD(0, string.Empty, string.Empty, LoggedInUserID, CompanyID, "R");
            ddlLicense.DataSource = ds.Tables[0];
            ddlLicense.DataTextField = "License_Name";
            ddlLicense.DataValueField = "License_ID";
            ddlLicense.DataBind();
            ddlLicense.Items.Insert(0, new System.Web.UI.WebControls.ListItem("------Select License-----", "0"));

            ddlLicense_grd.DataSource = ds.Tables[0];
            ddlLicense_grd.DataTextField = "License_Name";
            ddlLicense_grd.DataValueField = "License_ID";
            ddlLicense_grd.DataBind();
            ddlLicense_grd.SelectedIndex = 0;
        }

        private void Fetch_Cocktail()
        {
            int License_ID = Convert.ToInt32(ddlLicense.SelectedValue);
            ds = ObjCocktailWorld.CocktailMaster_CRUD(0, string.Empty, string.Empty, CompanyID, LoggedInUserID, License_ID, "Fetch");
            ddlCocktail.DataSource = ds.Tables[0];
            ddlCocktail.DataTextField = "Cocktail_Desc";
            ddlCocktail.DataValueField = "Cocktail_ID";
            ddlCocktail.DataBind();
            ddlCocktail.Items.Insert(0, new System.Web.UI.WebControls.ListItem("------Select License-----", "0"));
        }

        protected void btnCloseCategory_Click(object sender, EventArgs e)
        {
            ddlLicense.SelectedIndex = -1;
            ddlCocktail.SelectedIndex = -1;
            txtcode.Text = "";
            lblError.Text = "";
            mpeLicenseMaster.Hide();
            Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Cocktail_Code.aspx"), false);
        }

        protected void btnLicenseSave_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32(ddlLicense.SelectedValue);
            int CocktailID = Convert.ToInt32(ddlLicense.SelectedValue);
            string CocktailName = Convert.ToString(ddlLicense.SelectedItem);
            string Code = txtcode.Text;
            ds = ObjCocktailWorld.Spr_CRUD_CocktailCode(LicenseID, 0, CocktailID, CocktailName, Code, LoggedInUserID, CompanyID, "I");
            if (ds.Tables[0].Rows.Count > 0)
            {
                int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                if (Status == 1)
                {
                    Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Cocktail_Code.aspx"), false);
                }
                else
                {
                    lblError.Text = "This Cocktail Code already Exist!!!";
                }
            }
        }

        public string bindgrid()
        {
            int LicenseID = Convert.ToInt32(ddlLicense_grd.SelectedValue);
            string data = "";

            try
            {
                ds = ObjCocktailWorld.Spr_CRUD_CocktailCode(LicenseID, 0, 0, "", "", LoggedInUserID, CompanyID, "F");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int AssignCocktailCode_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["AssignCocktailCode_ID"]);
                            string Cocktail_ID = Convert.ToString(ds.Tables[0].Rows[i]["Cocktail_ID"]);
                            string Cocktail_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Cocktail_Desc"]);
                            string Cocktail_Code = Convert.ToString(ds.Tables[0].Rows[i]["Cocktail_Code"]);

                            data += "<tr>";
                            data += "<td>" + Cocktail_Desc + "</td>";
                            data += "<td>" + Cocktail_Code + "</td>";
                            data += "<td>" +
                                "<a href='Cocktail_Code.aspx?CocktailCodeID=" + AssignCocktailCode_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  " +
                                "<a href='Cocktail_Code.aspx?DelCocktailCodeID=" + AssignCocktailCode_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> " +
                                "</td>";
                            data += "</tr>";

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

        protected void ddlLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fetch_Cocktail();
        }

        protected void exce_ServerClick(object sender, EventArgs e)
        {
            GridView dgGrid = new GridView();
            DataSet dsExport = new DataSet();
            string currentDate = string.Empty;
            int LicenseID = Convert.ToInt32(ddlLicense_grd.SelectedValue);

            try
            {
                dsExport = ObjCocktailWorld.Spr_CRUD_CocktailCode(LicenseID, 0, 0, "", "", LoggedInUserID, CompanyID, "F");

                DataTable dtCocktailMasterReport = new DataTable();

                if (dsExport.Tables.Count > 0)
                {
                    if (dsExport.Tables[0].Rows.Count > 0)
                    {
                        dtCocktailMasterReport = dsExport.Tables[0];
                        dtCocktailMasterReport.Columns.Remove("AssignCocktailCode_ID");
                        dtCocktailMasterReport.Columns.Remove("Cocktail_ID");
                        dtCocktailMasterReport.Columns.Remove("License_Name");
                        dtCocktailMasterReport.Columns["Cocktail_Desc"].ColumnName = "Cocktail Name";
                        dtCocktailMasterReport.Columns["Cocktail_Code"].ColumnName = "Cocktail Code";
                        dtCocktailMasterReport.AcceptChanges();

                        dgGrid.DataSource = dtCocktailMasterReport;
                        dgGrid.DataBind();

                        currentDate = DateTime.Now.ToString();

                        System.IO.StringWriter tw = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                        string filename = "Cocktail Code REPORT AS ON " + currentDate + ".xls";

                        string HeaderText = "Cocktail Code REPORT AS ON " + currentDate;

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

        protected void pdf_ServerClick(object sender, EventArgs e)
        {
            GridView dgGrid = new GridView();
            Document doc = new Document();
            int LicenseID = Convert.ToInt32(ddlLicense_grd.SelectedValue);
            try
            {
                DataSet dsReport = new DataSet();
                dsReport = ObjCocktailWorld.Spr_CRUD_CocktailCode(LicenseID, 0, 0, "", "", LoggedInUserID, CompanyID, "F");

                System.Data.DataTable dtReport = new System.Data.DataTable();
                dtReport = dsReport.Tables[0];

                if (dsReport != null)
                {
                    if (dsReport.Tables.Count > 0)
                    {
                        if (dsReport.Tables[0].Rows.Count > 0)
                        {
                            dtReport.Columns.Remove("AssignCocktailCode_ID");
                            dtReport.Columns.Remove("Cocktail_ID");
                            dtReport.Columns.Remove("License_Name");
                            dtReport.Columns["Cocktail_Desc"].ColumnName = "Cocktail Name";
                            dtReport.Columns["Cocktail_Code"].ColumnName = "Cocktail Code";
                            dtReport.AcceptChanges();

                            dgGrid.DataSource = dtReport;
                            dgGrid.DataBind();


                            System.IO.StringWriter tw = new System.IO.StringWriter();
                            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                            string filename = "Cocktail_Code_" + DateTime.Now + ".pdf";

                            string HeaderText = "Cocktail Code REPORT AS ON " + DateTime.Now;

                            Style textStyle = new Style();
                            textStyle.ForeColor = System.Drawing.Color.DarkCyan;
                            hw.EnterStyle(textStyle);

                            hw.Write("<h2><center>" + HeaderText + "</center></h2> </br>");
                            hw.ExitStyle(textStyle);

                            //Write the HTML back to the browser.

                            Response.ContentType = "application/pdf";
                            Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}.pdf", "Brand Code REPORT"));

                            iTextSharp.text.pdf.PdfPTable grd;

                            PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
                            doc.Open();

                            grd = new PdfPTable(dtReport.Columns.Count);
                            grd.WidthPercentage = 100.0F;

                            PdfPCell cellRptNm = new PdfPCell(new Phrase("Cocktail Code REPORT AS ON " + DateTime.Now));
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

            if (FU_Category.HasFile && FU_Category.PostedFile != null)
            {
                try
                {
                    string path = string.Concat(Server.MapPath("~/Cocktail_World/ImportFile/" + FU_Category.FileName));
                    string extension = Path.GetExtension(FU_Category.PostedFile.FileName);
                    FU_Category.SaveAs(path);

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
                        string CS = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString;
                        // Bulk Copy to SQL Server   
                        SqlBulkCopy bulkInsert = new SqlBulkCopy(CS);
                        bulkInsert.DestinationTableName = "Tbl_CW_Import_CocktailCode_Temp";
                        bulkInsert.ColumnMappings.Add("Cocktail", "Cocktail_Desc");
                        bulkInsert.ColumnMappings.Add("Cocktail Code", "Cocktail_Code");
                        bulkInsert.ColumnMappings.Add("License Name", "License_Desc");
                        bulkInsert.WriteToServer(dr);

                        dsResult = ObjCocktailWorld.Import_CocktailCode(CompanyID, LoggedInUserID);

                        if (dsResult.Tables.Count > 0)
                        {
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                DataTable dtCTTReport = new DataTable();
                                dtCTTReport = dsResult.Tables[0];
                                dtCTTReport.AcceptChanges();

                                dvErrorGrid.Attributes.Add("style", "display:block; overflow-y:auto; height:210px;");
                                pnlImportExport.Attributes.Add("style", "height:580px; width:700px; top:-14px !important;");

                                mpeUserMst.Show();
                                lblImportErrorMsg.Text = "Below Stock List can not be created, kindly check error message.";
                                gvImportError.DataSource = dtCTTReport;
                                gvImportError.DataBind();
                            }
                            else
                            {
                                bindgrid();
                            }
                        }
                        else
                        {
                            bindgrid();
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void btnCloseImportPopUp_Click(object sender, EventArgs e)
        {
            lblImportErrorMsg.Text = "";
            gvImportError.DataSource = null;
            gvImportError.DataBind();
            mpeUserMst.Hide();
        }

        protected void lnk_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "~/Cocktail_World/Template/Cocktail Code.xlsx";
                string filename = "Cocktail Code.xlsx";
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