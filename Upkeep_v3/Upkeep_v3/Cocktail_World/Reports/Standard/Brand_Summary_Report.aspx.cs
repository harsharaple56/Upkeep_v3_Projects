using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Cocktail_World.Reports
{
    public partial class Brand_Summary_Report : System.Web.UI.Page
    {
        CocktailWorld_Service.CocktailWorld_Service ObjCocktailWorld = new CocktailWorld_Service.CocktailWorld_Service();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        bool BrandSelect = false;
        bool CategorySelect = false;
        bool SubCategorySelect = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            BrandSelect = rdbBrandwise.Checked;
            CategorySelect = rdbCategoryWise.Checked;
            SubCategorySelect = rdbSubcategorywise.Checked;
            hdn_IsPostBack.Value = "yes";
            if (!IsPostBack)
            {
                Fetch_License();
                hdn_IsPostBack.Value = "no";
            }
        }

        private void Fetch_License()
        {
            DataSet ds = new DataSet();
            ds = ObjCocktailWorld.License_CRUD(0, string.Empty, string.Empty, LoggedInUserID, CompanyID, "R");
            ddlLicense.DataSource = ds.Tables[0];
            ddlLicense.DataTextField = "License_Name";
            ddlLicense.DataValueField = "License_ID";
            ddlLicense.DataBind();
            ddlLicense.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select License--", "0"));
            ddlLicense.SelectedIndex = 1;
        }

        public string Bind_Report()
        {
            string data = "";
            DataSet ds = new DataSet();
            int LicenseID = Convert.ToInt32(ddlLicense.SelectedValue);
            string From_Date = string.Empty;
            string To_Date = string.Empty;
            bool Brandwise = rdbBrandwise.Checked;
            bool Categorywise = rdbCategoryWise.Checked;
            bool SubCategorywise = rdbSubcategorywise.Checked;
            bool IsBulkLitre = chkIsBulkLitre.Checked;

            try
            {

                if (start_date.Value != "")
                {
                    From_Date = Convert.ToString(start_date.Value);
                }
                else
                {
                    DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture)).AddDays(-6);
                    From_Date = FromDate.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
                }

                if (end_date.Value != "")
                {
                    To_Date = Convert.ToString(end_date.Value);
                }
                else
                {
                    To_Date = DateTime.Now.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
                }


                ds = ObjCocktailWorld.Fetch_BrandSummary_Report(LicenseID, From_Date, To_Date, Brandwise, Categorywise, SubCategorywise, IsBulkLitre);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {

                            string Brand_name = string.Empty;
                            string Category_name = string.Empty;
                            string SubCategory = string.Empty;
                            if (Brandwise)
                            {
                                Brand_name = Convert.ToString(ds.Tables[0].Rows[i]["Brand"]);
                                Category_name = Convert.ToString(ds.Tables[0].Rows[i]["Category"]);
                                SubCategory = Convert.ToString(ds.Tables[0].Rows[i]["SubCategory"]);
                            }
                            if (Categorywise)
                            {
                                Category_name = Convert.ToString(ds.Tables[0].Rows[i]["Category"]);
                                SubCategory = Convert.ToString(ds.Tables[0].Rows[i]["SubCategory"]);
                            }
                            if (SubCategorywise)
                                SubCategory = Convert.ToString(ds.Tables[0].Rows[i]["SubCategory"]);


                            string Size = Convert.ToString(ds.Tables[0].Rows[i]["Size"]);
                            string Opening = Convert.ToString(ds.Tables[0].Rows[i]["Opening"]);
                            string Purchase = Convert.ToString(ds.Tables[0].Rows[i]["Purchase"]);
                            string Total = Convert.ToString(ds.Tables[0].Rows[i]["Total"]);
                            string Sale = Convert.ToString(ds.Tables[0].Rows[i]["Sale"]);
                            string Closing = Convert.ToString(ds.Tables[0].Rows[i]["Closing"]);

                            if (Brandwise)
                            {
                                data += "<tr>" +
                                     "<td>" + Brand_name + "</td>" +
                                    "<td>" + Category_name + "</td>" +
                                    "<td>" + SubCategory + "</td>" +
                                    "<td>" + Size + "</td>" +
                                    "<td>" + Opening + "</td>" +
                                    "<td>" + Purchase + "</td>" +
                                    "<td>" + Total + "</td>" +
                                    "<td>" + Sale + "</td>" +
                                    "<td>" + Closing + "</td>" +
                                    "</tr>";
                            }
                            if (Categorywise)
                            {
                                data += "<tr>" +
                                    "<td>" + Category_name + "</td>" +
                                    "<td>" + SubCategory + "</td>" +
                                    "<td>" + Size + "</td>" +
                                    "<td>" + Opening + "</td>" +
                                    "<td>" + Purchase + "</td>" +
                                    "<td>" + Total + "</td>" +
                                    "<td>" + Sale + "</td>" +
                                    "<td>" + Closing + "</td>" +
                                    "</tr>";
                            }
                            if (SubCategorywise)
                            {
                                data += "<tr>" +
                                    "<td>" + SubCategory + "</td>" +
                                    "<td>" + Size + "</td>" +
                                    "<td>" + Opening + "</td>" +
                                    "<td>" + Purchase + "</td>" +
                                    "<td>" + Total + "</td>" +
                                    "<td>" + Sale + "</td>" +
                                    "<td>" + Closing + "</td>" +
                                    "</tr>";
                            }

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

        public string Bind_ReportHeader()
        {
            string data = "";
            try
            {
                if (BrandSelect)
                {
                    data += "<tr>" +
                            "<th>Brand</th>" +
                            "<th>Category</th>" +
                            "<th>SubCategory</th>" +
                            "<th>Size</th>" +
                            "<th>Opening</th>" +
                            "<th>Purchase</th>" +
                            "<th>Total</th>" +
                            "<th>Sale</th>" +
                            "<th>Closing</th>" +
                            "</tr>";
                }

                if (CategorySelect)
                {
                    data += "<tr>" +
                            "<th>Category</th>" +
                            "<th>SubCategory</th>" +
                            "<th>Size</th>" +
                            "<th>Opening</th>" +
                            "<th>Purchase</th>" +
                            "<th>Total</th>" +
                            "<th>Sale</th>" +
                            "<th>Closing</th>" +
                            "</tr>";
                }

                if (SubCategorySelect)
                {
                    data += "<tr>" +
                            "<th>SubCategory</th>" +
                            "<th>Size</th>" +
                            "<th>Opening</th>" +
                            "<th>Purchase</th>" +
                            "<th>Total</th>" +
                            "<th>Sale</th>" +
                            "<th>Closing</th>" +
                            "</tr>";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

        protected void export_excel_ServerClick(object sender, EventArgs e)
        {
            GridView dgGrid = new GridView();
            DataSet dsExport = new DataSet();
            string currentDate = string.Empty;
            int LicenseID = Convert.ToInt32(ddlLicense.SelectedValue);
            string From_Date = string.Empty;
            string To_Date = string.Empty;
            bool Brandwise = rdbBrandwise.Checked;
            bool Categorywise = rdbCategoryWise.Checked;
            bool SubCategorywise = rdbSubcategorywise.Checked;
            bool IsBulkLitre = chkIsBulkLitre.Checked;

            try
            {
                if (start_date.Value != "")
                {
                    From_Date = Convert.ToString(start_date.Value);
                }
                else
                {
                    DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture)).AddDays(-6);
                    From_Date = FromDate.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
                }

                if (end_date.Value != "")
                {
                    To_Date = Convert.ToString(end_date.Value);
                }
                else
                {
                    To_Date = DateTime.Now.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
                }

                dsExport = ObjCocktailWorld.Fetch_BrandSummary_Report(LicenseID, From_Date, To_Date, Brandwise, Categorywise, SubCategorywise, IsBulkLitre);

                DataTable dtCocktailMasterReport = new DataTable();

                if (dsExport.Tables.Count > 0)
                {
                    if (dsExport.Tables[0].Rows.Count > 0)
                    {
                        dtCocktailMasterReport = dsExport.Tables[0];

                        if (Brandwise)
                        {
                            dtCocktailMasterReport.Columns["Brand"].ColumnName = "Brand";
                            dtCocktailMasterReport.Columns["Category"].ColumnName = "Category";
                            dtCocktailMasterReport.Columns["SubCategory"].ColumnName = "SubCategory";
                            dtCocktailMasterReport.Columns["Size"].ColumnName = "Size";
                            dtCocktailMasterReport.Columns["Opening"].ColumnName = "Opening";
                            dtCocktailMasterReport.Columns["Purchase"].ColumnName = "Purchase";
                            dtCocktailMasterReport.Columns["Total"].ColumnName = "Total";
                            dtCocktailMasterReport.Columns["Sale"].ColumnName = "Sale";
                            dtCocktailMasterReport.Columns["Closing"].ColumnName = "Closing";
                        }
                        if (Categorywise)
                        {
                            dtCocktailMasterReport.Columns["Category"].ColumnName = "Category";
                            dtCocktailMasterReport.Columns["SubCategory"].ColumnName = "SubCategory";
                            dtCocktailMasterReport.Columns["Size"].ColumnName = "Size";
                            dtCocktailMasterReport.Columns["Opening"].ColumnName = "Opening";
                            dtCocktailMasterReport.Columns["Purchase"].ColumnName = "Purchase";
                            dtCocktailMasterReport.Columns["Total"].ColumnName = "Total";
                            dtCocktailMasterReport.Columns["Sale"].ColumnName = "Sale";
                            dtCocktailMasterReport.Columns["Closing"].ColumnName = "Closing";
                        }
                        if (SubCategorywise)
                        {
                            dtCocktailMasterReport.Columns["SubCategory"].ColumnName = "SubCategory";
                            dtCocktailMasterReport.Columns["Size"].ColumnName = "Size";
                            dtCocktailMasterReport.Columns["Opening"].ColumnName = "Opening";
                            dtCocktailMasterReport.Columns["Purchase"].ColumnName = "Purchase";
                            dtCocktailMasterReport.Columns["Total"].ColumnName = "Total";
                            dtCocktailMasterReport.Columns["Sale"].ColumnName = "Sale";
                            dtCocktailMasterReport.Columns["Closing"].ColumnName = "Closing";
                        }


                        dtCocktailMasterReport.AcceptChanges();

                        dgGrid.DataSource = dtCocktailMasterReport;
                        dgGrid.DataBind();

                        currentDate = DateTime.Now.ToString();

                        System.IO.StringWriter tw = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                        string filename = "Brand Summary Report As On " + currentDate + ".xls";

                        string HeaderText = "Brand Summary Report As On " + currentDate;

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

        protected void export_pdf_ServerClick(object sender, EventArgs e)
        {
            GridView dgGrid = new GridView();
            Document doc = new Document();
            int LicenseID = Convert.ToInt32(ddlLicense.SelectedValue);
            string From_Date = string.Empty;
            string To_Date = string.Empty;
            bool Brandwise = rdbBrandwise.Checked;
            bool Categorywise = rdbCategoryWise.Checked;
            bool SubCategorywise = rdbSubcategorywise.Checked;
            bool IsBulkLitre = chkIsBulkLitre.Checked;
            try
            {
                if (start_date.Value != "")
                {
                    From_Date = Convert.ToString(start_date.Value);
                }
                else
                {
                    DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture)).AddDays(-6);
                    From_Date = FromDate.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
                }

                if (end_date.Value != "")
                {
                    To_Date = Convert.ToString(end_date.Value);
                }
                else
                {
                    To_Date = DateTime.Now.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
                }

                DataSet dsReport = new DataSet();
                dsReport = ObjCocktailWorld.Fetch_BrandSummary_Report(LicenseID, From_Date, To_Date, Brandwise, Categorywise, SubCategorywise, IsBulkLitre);

                System.Data.DataTable dtReport = new System.Data.DataTable();
                dtReport = dsReport.Tables[0];

                if (dsReport != null)
                {
                    if (dsReport.Tables.Count > 0)
                    {
                        if (dsReport.Tables[0].Rows.Count > 0)
                        {
                            if (Brandwise)
                            {
                                dtReport.Columns["Brand"].ColumnName = "Brand";
                                dtReport.Columns["Category"].ColumnName = "Category";
                                dtReport.Columns["SubCategory"].ColumnName = "SubCategory";
                                dtReport.Columns["Size"].ColumnName = "Size";
                                dtReport.Columns["Opening"].ColumnName = "Opening";
                                dtReport.Columns["Purchase"].ColumnName = "Purchase";
                                dtReport.Columns["Total"].ColumnName = "Total";
                                dtReport.Columns["Sale"].ColumnName = "Sale";
                                dtReport.Columns["Closing"].ColumnName = "Closing";
                            }

                            if (Categorywise)
                            {
                                dtReport.Columns["Category"].ColumnName = "Category";
                                dtReport.Columns["SubCategory"].ColumnName = "SubCategory";
                                dtReport.Columns["Size"].ColumnName = "Size";
                                dtReport.Columns["Opening"].ColumnName = "Opening";
                                dtReport.Columns["Purchase"].ColumnName = "Purchase";
                                dtReport.Columns["Total"].ColumnName = "Total";
                                dtReport.Columns["Sale"].ColumnName = "Sale";
                                dtReport.Columns["Closing"].ColumnName = "Closing";
                            }

                            if (SubCategorywise)
                            {
                                dtReport.Columns["SubCategory"].ColumnName = "SubCategory";
                                dtReport.Columns["Size"].ColumnName = "Size";
                                dtReport.Columns["Opening"].ColumnName = "Opening";
                                dtReport.Columns["Purchase"].ColumnName = "Purchase";
                                dtReport.Columns["Total"].ColumnName = "Total";
                                dtReport.Columns["Sale"].ColumnName = "Sale";
                                dtReport.Columns["Closing"].ColumnName = "Closing";
                            }



                            dtReport.AcceptChanges();

                            dgGrid.DataSource = dtReport;
                            dgGrid.DataBind();


                            System.IO.StringWriter tw = new System.IO.StringWriter();
                            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                            string filename = "Brand Summary Report As On" + DateTime.Now + ".pdf";

                            string HeaderText = "Brand Summary Report As On " + DateTime.Now;

                            Style textStyle = new Style();
                            textStyle.ForeColor = System.Drawing.Color.DarkCyan;
                            hw.EnterStyle(textStyle);

                            hw.Write("<h2><center>" + HeaderText + "</center></h2> </br>");
                            hw.ExitStyle(textStyle);

                            //Write the HTML back to the browser.

                            Response.ContentType = "application/pdf";
                            Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}.pdf", "Brand Opening Stock Report"));

                            iTextSharp.text.pdf.PdfPTable grd;

                            PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
                            doc.Open();

                            grd = new PdfPTable(dtReport.Columns.Count);
                            grd.WidthPercentage = 100.0F;

                            PdfPCell cellRptNm = new PdfPCell(new Phrase("Brand Summary AS ON " + DateTime.Now));
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
    }
}