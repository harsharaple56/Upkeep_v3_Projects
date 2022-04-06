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

namespace Upkeep_v3.Cocktail_World.Reports.Standard
{
    public partial class Cost_Valuation_Report : System.Web.UI.Page
    {
        CocktailWorld_Service.CocktailWorld_Service ObjCocktailWorld = new CocktailWorld_Service.CocktailWorld_Service();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
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


                ds = ObjCocktailWorld.Fetch_CostValuation_Report(LicenseID, From_Date, To_Date);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            string Brand = Convert.ToString(ds.Tables[0].Rows[i]["Brand"]);
                            string Size = Convert.ToString(ds.Tables[0].Rows[i]["Size"]);
                            string Category = Convert.ToString(ds.Tables[0].Rows[i]["Category"]);
                            string OpeningStock = Convert.ToString(ds.Tables[0].Rows[i]["OpeningStock"]);
                            string OpeningUnitCost = Convert.ToString(ds.Tables[0].Rows[i]["OpeningUnitCost"]);
                            string OpeningCostValue = Convert.ToString(ds.Tables[0].Rows[i]["OpeningCostValue"]);
                            string Purchase = Convert.ToString(ds.Tables[0].Rows[i]["Purchase"]);
                            string PurchaseCost = Convert.ToString(ds.Tables[0].Rows[i]["PurchaseCost"]);
                            string Sale = Convert.ToString(ds.Tables[0].Rows[i]["Sale"]);
                            string SaleRevenue = Convert.ToString(ds.Tables[0].Rows[i]["SaleRevenue"]);
                            string SaleCost = Convert.ToString(ds.Tables[0].Rows[i]["SaleCost"]);
                            string SaleProfit = Convert.ToString(ds.Tables[0].Rows[i]["SaleProfit"]);
                            string ClosingStock = Convert.ToString(ds.Tables[0].Rows[i]["ClosingStock"]);
                            string ClosingUnitCost = Convert.ToString(ds.Tables[0].Rows[i]["ClosingUnitCost"]);
                            string ClosingCostValue = Convert.ToString(ds.Tables[0].Rows[i]["ClosingCostValue"]);

                            data += "<tr>" +
                                 "<td>" + Brand + "</td>" +
                                "<td>" + Size + "</td>" +
                                "<td>" + Category + "</td>" +
                                "<td>" + OpeningStock + "</td>" +
                                "<td>" + OpeningUnitCost + "</td>" +
                                "<td>" + OpeningCostValue + "</td>" +
                                "<td>" + Purchase + "</td>" +
                                "<td>" + PurchaseCost + "</td>" +
                                "<td>" + Sale + "</td>" +
                                "<td>" + SaleRevenue + "</td>" +
                                "<td>" + SaleCost + "</td>" +
                                "<td>" + SaleProfit + "</td>" +
                                "<td>" + ClosingStock + "</td>" +
                                "<td>" + ClosingUnitCost + "</td>" +
                                "<td>" + ClosingCostValue + "</td>" +
                                "</tr>";
                        }
                    }

                    //if (ds.Tables[1].Rows.Count > 0)
                    //{
                    //    int count = Convert.ToInt32(ds.Tables[1].Rows.Count);

                    //    for (int i = 0; i < count; i++)
                    //    {
                    //        string Category = Convert.ToString(ds.Tables[1].Rows[i]["Category"]);
                    //        string Size = Convert.ToString(ds.Tables[1].Rows[i]["Size"]);
                    //        string Stock = Convert.ToString(ds.Tables[1].Rows[i]["Stock"]);
                    //        string UnitCost = Convert.ToString(ds.Tables[1].Rows[i]["UnitCost"]);
                    //        string CostValue = Convert.ToString(ds.Tables[1].Rows[i]["CostValue"]);

                    //        data += "<tr>" +
                    //             "<td>" + Category + "</td>" +
                    //            "<td>" + Size + "</td>" +
                    //            "<td>" + Stock + "</td>" +
                    //            "<td>" + UnitCost + "</td>" +
                    //            "<td>" + CostValue + "</td>" +
                    //            "</tr>";
                    //    }
                    //}
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

                //dsExport = ObjCocktailWorld.Fetch_BrandSummary_Report(LicenseID, From_Date, To_Date, Brandwise, Categorywise, SubCategorywise, IsBulkLitre);

                DataTable dtCocktailMasterReport = new DataTable();

                if (dsExport.Tables.Count > 0)
                {
                    if (dsExport.Tables[0].Rows.Count > 0)
                    {
                        dtCocktailMasterReport = dsExport.Tables[0];

                        dtCocktailMasterReport.Columns["Brand"].ColumnName = "Brand";
                        dtCocktailMasterReport.Columns["Category"].ColumnName = "Category";
                        dtCocktailMasterReport.Columns["SubCategory"].ColumnName = "SubCategory";
                        dtCocktailMasterReport.Columns["Size"].ColumnName = "Size";
                        dtCocktailMasterReport.Columns["Opening"].ColumnName = "Opening";
                        dtCocktailMasterReport.Columns["Purchase"].ColumnName = "Purchase";
                        dtCocktailMasterReport.Columns["Total"].ColumnName = "Total";
                        dtCocktailMasterReport.Columns["Sale"].ColumnName = "Sale";
                        dtCocktailMasterReport.Columns["Closing"].ColumnName = "Closing";

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
                // dsReport = ObjCocktailWorld.Fetch_BrandSummary_Report(LicenseID, From_Date, To_Date, Brandwise, Categorywise, SubCategorywise, IsBulkLitre);

                System.Data.DataTable dtReport = new System.Data.DataTable();
                dtReport = dsReport.Tables[0];

                if (dsReport != null)
                {
                    if (dsReport.Tables.Count > 0)
                    {
                        if (dsReport.Tables[0].Rows.Count > 0)
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