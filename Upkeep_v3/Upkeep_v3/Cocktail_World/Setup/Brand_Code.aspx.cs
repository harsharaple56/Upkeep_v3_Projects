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
    public partial class Brand_Code : System.Web.UI.Page
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



        protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fetch_Brand_Size(false);
        }

        protected void ddlLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fetch_Brand_Size(true);
        }

        private void Fetch_Brand_Size(bool chk)
        {
            int BrandID = 0;
            int Size_ID = 0;

            if (chk)
            {
                ddlBrand.SelectedIndex = -1;
                ddlSize.SelectedIndex = -1;
            }

            if (ddlBrand.SelectedIndex > 0)
                BrandID = Convert.ToInt32(ddlBrand.SelectedValue);
            else
                BrandID = 0;

            try
            {
                ds = ObjCocktailWorld.FetchBrandSizeLinkup(0, BrandID, Size_ID, "", "", CompanyID, Convert.ToInt32(ddlLicense.SelectedValue), string.Empty, DateTime.Now);

                if (BrandID == 0)
                {
                    ddlBrand.DataSource = ds.Tables[0];
                    ddlBrand.DataTextField = "Brand_Desc";
                    ddlBrand.DataValueField = "Brand_ID";
                    ddlBrand.DataBind();
                    ddlBrand.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Brand--", "0"));
                }
                else if (BrandID > 0 && Size_ID == 0)
                {
                    ddlSize.DataSource = ds.Tables[0];
                    ddlSize.DataTextField = "Alias";
                    ddlSize.DataValueField = "Size_ID";
                    ddlSize.DataBind();
                    ddlSize.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Size--", "0"));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private int Save_BrandCode(int License_ID, string Brand_Name, string Size_Desc, string lpeg, string speg, string bottle)
        {
            int count = 0;
            int Opening_ID = 0;

            DataSet dsGetBrandId = new DataSet();
            dsGetBrandId = ObjCocktailWorld.Fetch_Brand_Opening(0, 0, 0, Brand_Name, Size_Desc, "", CompanyID, Convert.ToString(ddlLicense.SelectedValue));
            if (dsGetBrandId.Tables[0].Rows.Count > 0)
            {
                Opening_ID = Convert.ToInt32(dsGetBrandId.Tables[0].Rows[0]["Opening_ID"]);
            }

            try
            {
                if (bottle != "")
                {
                    DataSet dsBottle = new DataSet();
                    dsBottle = ObjCocktailWorld.Save_BrandCode(0, Opening_ID, License_ID, bottle, LoggedInUserID, 1);
                    if (dsBottle.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsBottle.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            count = count + 1;
                        }
                        else
                        {
                            lblError.Text = "This Brand Code already Exist!!!";
                        }
                    }
                }
                if (speg != "")
                {
                    DataSet dsspeg = new DataSet();
                    dsspeg = ObjCocktailWorld.Save_BrandCode(0, Opening_ID, License_ID, speg, LoggedInUserID, 2);
                    if (dsspeg.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsspeg.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            count = count + 1;
                        }
                        else
                        {
                            lblError.Text = "This Brand Code already Exist!!!";
                        }
                    }
                }
                if (lpeg != "")
                {
                    DataSet dslpeg = new DataSet();
                    dslpeg = ObjCocktailWorld.Save_BrandCode(0, Opening_ID, License_ID, speg, LoggedInUserID, 3);
                    if (dslpeg.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dslpeg.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            count = count + 1;
                        }
                        else
                        {
                            lblError.Text = "This Brand Code already Exist!!!";
                        }
                    }
                }

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnLicenseSave_Click(object sender, EventArgs e)
        {
            int License_ID = Convert.ToInt32(ddlLicense.SelectedValue);
            string Brand_ID = ddlBrand.SelectedItem.ToString();
            string Size_ID = ddlSize.SelectedItem.ToString();
            string lpeg = txtlpeg.Text;
            string speg = txtSpeg.Text;
            string bottle = txtBottle.Text;

            int count = Save_BrandCode(License_ID, Brand_ID, Size_ID, lpeg, speg, bottle);
            if (count > 0)
            {
                Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Brand_Code.aspx"), false);
            }
        }

        protected void btnCloseCategory_Click(object sender, EventArgs e)
        {
            ddlLicense.SelectedIndex = -1;
            ddlBrand.SelectedIndex = -1;
            ddlSize.SelectedIndex = -1;
            txtlpeg.Text = "";
            txtSpeg.Text = "";
            txtBottle.Text = "";
            lblError.Text = "";
            mpeLicenseMaster.Hide();
            Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Brand_Code.aspx"), false);
        }

        public string bindgrid()
        {
            int BrandID = 0;
            int LicenseID = Convert.ToInt32(ddlLicense_grd.SelectedValue);
            string data = "";

            try
            {
                ds = ObjCocktailWorld.Fetch_AssignBrandCode(BrandID, LicenseID, 0);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int AssignBrandCodeID = Convert.ToInt32(ds.Tables[0].Rows[i]["AssignBrandCode_ID"]);
                            string Brand_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Brand_Desc"]);
                            string BrandCode = Convert.ToString(ds.Tables[0].Rows[i]["BrandCode"]);
                            string alias = Convert.ToString(ds.Tables[0].Rows[i]["alias"]);
                            string Speg = Convert.ToString(ds.Tables[0].Rows[i]["SPeg"]);
                            string Lpeg = Convert.ToString(ds.Tables[0].Rows[i]["LPeg"]);
                            string Bottle = Convert.ToString(ds.Tables[0].Rows[i]["Bottle"]);

                            data += "<tr>";
                            data += "<td>" + Brand_Desc + "</td>";
                            data += "<td>" + BrandCode + "</td>";
                            data += "<td>" + alias + "</td>";
                            data += "<td>" + Speg + "</td>";
                            data += "<td>" + Lpeg + "</td>";
                            data += "<td>" + Bottle + "</td>";
                            data += "<td>" +
                                "<a href='Brand_Code.aspx?AssignBrandCodeID=" + AssignBrandCodeID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  " +
                                "<a href='Brand_Code.aspx?DelAssignBrandCodeID=" + AssignBrandCodeID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> " +
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

        protected void exce_ServerClick(object sender, EventArgs e)
        {
            GridView dgGrid = new GridView();
            DataSet dsExport = new DataSet();
            string currentDate = string.Empty;
            int BrandID = 0;
            int LicenseID = Convert.ToInt32(ddlLicense_grd.SelectedValue);

            try
            {
                dsExport = ObjCocktailWorld.Fetch_AssignBrandCode(BrandID, LicenseID, 0);

                DataTable dtCocktailMasterReport = new DataTable();

                if (dsExport.Tables.Count > 0)
                {
                    if (dsExport.Tables[0].Rows.Count > 0)
                    {
                        dtCocktailMasterReport = dsExport.Tables[0];
                        dtCocktailMasterReport.Columns.Remove("AssignBrandCode_ID");
                        dtCocktailMasterReport.Columns.Remove("Brand_ID");
                        dtCocktailMasterReport.Columns.Remove("License_ID");
                        dtCocktailMasterReport.Columns.Remove("Type_ID");
                        dtCocktailMasterReport.Columns.Remove("Brandopening_ID");
                        dtCocktailMasterReport.Columns["Brand_Desc"].ColumnName = "Brand Name";
                        dtCocktailMasterReport.Columns["BrandCode"].ColumnName = "Brand Code";
                        dtCocktailMasterReport.Columns["alias"].ColumnName = "Size";
                        dtCocktailMasterReport.Columns["SPeg"].ColumnName = "Speg";
                        dtCocktailMasterReport.Columns["LPeg"].ColumnName = "LPeg";
                        dtCocktailMasterReport.Columns["Bottle"].ColumnName = "Bottle";
                        dtCocktailMasterReport.AcceptChanges();

                        dgGrid.DataSource = dtCocktailMasterReport;
                        dgGrid.DataBind();

                        currentDate = DateTime.Now.ToString();

                        System.IO.StringWriter tw = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                        string filename = "Brand Code REPORT AS ON " + currentDate + ".xls";

                        string HeaderText = "Brand Code REPORT AS ON " + currentDate;

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
            int BrandID = 0;
            int LicenseID = Convert.ToInt32(ddlLicense_grd.SelectedValue);
            try
            {
                DataSet dsReport = new DataSet();
                dsReport = ObjCocktailWorld.Fetch_AssignBrandCode(BrandID, LicenseID, 0);

                System.Data.DataTable dtReport = new System.Data.DataTable();
                dtReport = dsReport.Tables[0];

                if (dsReport != null)
                {
                    if (dsReport.Tables.Count > 0)
                    {
                        if (dsReport.Tables[0].Rows.Count > 0)
                        {
                            dtReport.Columns.Remove("AssignBrandCode_ID");
                            dtReport.Columns.Remove("Brand_ID");
                            dtReport.Columns.Remove("License_ID");
                            dtReport.Columns.Remove("Type_ID");
                            dtReport.Columns.Remove("Brandopening_ID");
                            dtReport.Columns["Brand_Desc"].ColumnName = "Brand Name";
                            dtReport.Columns["BrandCode"].ColumnName = "Brand Code";
                            dtReport.Columns["alias"].ColumnName = "Size";
                            dtReport.Columns["SPeg"].ColumnName = "Speg";
                            dtReport.Columns["LPeg"].ColumnName = "LPeg";
                            dtReport.Columns["Bottle"].ColumnName = "Bottle";
                            dtReport.AcceptChanges();

                            dgGrid.DataSource = dtReport;
                            dgGrid.DataBind();


                            System.IO.StringWriter tw = new System.IO.StringWriter();
                            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                            string filename = "Brand_Code_" + DateTime.Now + ".pdf";

                            string HeaderText = "Brand Code REPORT AS ON " + DateTime.Now;

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

                            PdfPCell cellRptNm = new PdfPCell(new Phrase("Brand Code REPORT AS ON " + DateTime.Now));
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
                        bulkInsert.DestinationTableName = "Tbl_CW_Import_BrandCode_Temp";
                        bulkInsert.ColumnMappings.Add("Brand Name", "Brand");
                        bulkInsert.ColumnMappings.Add("Alias", "Size");
                        bulkInsert.ColumnMappings.Add("Brand Name", "Brand_Name");
                        bulkInsert.ColumnMappings.Add("Bottle", "Bottle");
                        bulkInsert.ColumnMappings.Add("Speg", "Speg");
                        bulkInsert.ColumnMappings.Add("Lpeg", "Lpeg");
                        bulkInsert.WriteToServer(dr);

                        dsResult = ObjCocktailWorld.Import_BrandCode(CompanyID, LoggedInUserID);

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
                string filePath = "~/Cocktail_World/Template/Brand Code.xlsx";
                string filename = "Brand Code.xlsx";
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