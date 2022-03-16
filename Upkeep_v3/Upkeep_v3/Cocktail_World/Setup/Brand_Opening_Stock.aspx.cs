using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Upkeep_v3.Cocktail_World.Setup
{
    public partial class Brand_Opening_Stock : System.Web.UI.Page
    {
        CocktailWorld_Service.CocktailWorld_Service ObjCocktailWorld = new CocktailWorld_Service.CocktailWorld_Service();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        XmlDocument xmlBrandDetails = new XmlDocument();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Session["LoggedInUserID"].ToString();
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            xmlBrandDetails.LoadXml("<CW><BrandOpening></BrandOpening></CW>");

            if (!IsPostBack)
            {

            }
        }

        public string BindBrandOpening()
        {
            string data = "";          

            try
            {
                ds = ObjCocktailWorld.BrandOpeningMaster_CRUD(0, xmlBrandDetails.OuterXml.ToString(), 0, 0, 0, 0, CompanyID, LoggedInUserID, "F");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Opening_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Opening_ID"]);
                            string License_Name = Convert.ToString(ds.Tables[0].Rows[i]["License_Name"]);
                            string Category_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Category_Desc"]);
                            string Brand_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Brand_Desc"]);
                            string Size_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Size_Desc"]);
                            string Bottle_Qty = Convert.ToString(ds.Tables[0].Rows[i]["Bottle_Qty"]);
                            string SPeg_Qty = Convert.ToString(ds.Tables[0].Rows[i]["SPeg_Qty"]);
                            string Bottle_Rate = Convert.ToString(ds.Tables[0].Rows[i]["Bottle_Rate"]);
                            string Base_Qty = Convert.ToString(ds.Tables[0].Rows[i]["Base_Qty"]);
                            string Re_Order_Level = Convert.ToString(ds.Tables[0].Rows[i]["Re_Order_Level"]);
                            string Optimum_Level = Convert.ToString(ds.Tables[0].Rows[i]["Optimum_Level"]);

                            data += "<tr>";
                            data += "<td>" + License_Name + "</td>";
                            data += "<td>" + Category_Desc + "</td>";
                            data += "<td>" + Brand_Desc + "</td>";
                            data += "<td>" + Size_Desc + "</td>";
                            data += "<td>" + Bottle_Qty + "</td>";
                            data += "<td>" + SPeg_Qty + "</td>";
                            data += "<td>" + Bottle_Rate + "</td>";
                            data += "<td>" + Base_Qty + "</td>";
                            data += "<td>" + Re_Order_Level + "</td>";
                            data += "<td>" + Optimum_Level + "</td>";
                            data += "<td>" +
                                "<a href='Add_Brand_Opening_Stock.aspx?BrandOpening_ID=" + Opening_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  " +
                                "<a href='Add_Brand_Opening_Stock.aspx?DelBrandOpening_ID=" + Opening_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> " +
                                "</td>";
                            data += "</tr>";
                        }
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            GridView dgGrid = new GridView();
            DataSet dsExport = new DataSet();
            string currentDate = string.Empty;

            try
            {
                dsExport = ObjCocktailWorld.BrandOpeningMaster_CRUD(0, xmlBrandDetails.OuterXml.ToString(), 0, 0, 0, 0, CompanyID, LoggedInUserID, "F");

                DataTable dtCocktailMasterReport = new DataTable();

                if (dsExport.Tables.Count > 0)
                {
                    if (dsExport.Tables[0].Rows.Count > 0)
                    {
                        dtCocktailMasterReport = dsExport.Tables[0];

                        dtCocktailMasterReport.Columns.Remove("Opening_ID");
                        dtCocktailMasterReport.Columns["Category_Desc"].ColumnName = "Category Name";
                        dtCocktailMasterReport.Columns["Brand_Desc"].ColumnName = "Brand Name";
                        dtCocktailMasterReport.Columns["Size_Desc"].ColumnName = "Size Name";
                        dtCocktailMasterReport.Columns["Bottle_Qty"].ColumnName = "Bottle Qty";
                        dtCocktailMasterReport.Columns["SPeg_Qty"].ColumnName = "SPeg Qty";
                        dtCocktailMasterReport.Columns["Bottle_Rate"].ColumnName = "Bottle Rate";
                        dtCocktailMasterReport.Columns["Base_Qty"].ColumnName = "Base Qty";
                        dtCocktailMasterReport.Columns["Re_Order_Level"].ColumnName = "Re-Order Level";
                        dtCocktailMasterReport.Columns["Optimum_Level"].ColumnName = "Optimum Level";
                        dtCocktailMasterReport.AcceptChanges();

                        dgGrid.DataSource = dtCocktailMasterReport;
                        dgGrid.DataBind();

                        currentDate = DateTime.Now.ToString();

                        System.IO.StringWriter tw = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                        string filename = "Brand Opening Stock REPORT AS ON " + currentDate + ".xls";

                        string HeaderText = "Brand Opening Stock REPORT AS ON " + currentDate;

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

        protected void btnPdf_Click(object sender, EventArgs e)
        {
            GridView dgGrid = new GridView();
            Document doc = new Document();
            try
            {
                DataSet dsReport = new DataSet();
                dsReport = ObjCocktailWorld.BrandOpeningMaster_CRUD(0, xmlBrandDetails.OuterXml.ToString(), 0, 0, 0, 0, CompanyID, LoggedInUserID, "F");

                System.Data.DataTable dtReport = new System.Data.DataTable();
                dtReport = dsReport.Tables[0];

                if (dsReport != null)
                {
                    if (dsReport.Tables.Count > 0)
                    {
                        if (dsReport.Tables[0].Rows.Count > 0)
                        {
                            dtReport.Columns.Remove("Opening_ID");
                            dtReport.Columns["Category_Desc"].ColumnName = "Category Name";
                            dtReport.Columns["Brand_Desc"].ColumnName = "Brand Name";
                            dtReport.Columns["Size_Desc"].ColumnName = "Size Name";
                            dtReport.Columns["Bottle_Qty"].ColumnName = "Bottle Qty";
                            dtReport.Columns["SPeg_Qty"].ColumnName = "SPeg Qty";
                            dtReport.Columns["Bottle_Rate"].ColumnName = "Bottle Rate";
                            dtReport.Columns["Base_Qty"].ColumnName = "Base Qty";
                            dtReport.Columns["Re_Order_Level"].ColumnName = "Re-Order Level";
                            dtReport.Columns["Optimum_Level"].ColumnName = "Optimum Level";
                            dtReport.AcceptChanges();

                            dgGrid.DataSource = dtReport;
                            dgGrid.DataBind();


                            System.IO.StringWriter tw = new System.IO.StringWriter();
                            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                            string filename = "Brand_Opening_Stock" + DateTime.Now + ".pdf";

                            string HeaderText = "Brand Opening Stock AS ON " + DateTime.Now;

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

                            PdfPCell cellRptNm = new PdfPCell(new Phrase("Brand Opening Stock AS ON " + DateTime.Now));
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