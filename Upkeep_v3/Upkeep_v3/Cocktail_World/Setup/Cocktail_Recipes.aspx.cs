using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Cocktail_World.Setup
{
    public partial class Cocktail_Recipes : System.Web.UI.Page
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

            }
        }

        public string BindCocktailRecipes()
        {
            string data = "";
            try
            {
                ds = ObjCocktailWorld.CocktailMaster_CRUD(0, string.Empty, string.Empty, CompanyID, LoggedInUserID, "F");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Cocktail_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Cocktail_ID"]);
                            int Cocktail_Brand_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Cocktail_Brand_ID"]);
                            string Cocktail_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Cocktail_Desc"]);
                            string Cocktail_Rate = Convert.ToString(ds.Tables[0].Rows[i]["Cocktail_Rate"]);
                            string Brand_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Brand_Desc"]);
                            string Size = Convert.ToString(ds.Tables[0].Rows[i]["Size"]);
                            string Peg_ML_Qty = Convert.ToString(ds.Tables[0].Rows[i]["Peg_ML_Qty"]);

                            data += "<tr>";
                            data += "<td>" + Cocktail_Desc + "</td>";
                            data += "<td>" + Cocktail_Rate + "</td>";
                            data += "<td>" + Brand_Desc + "</td>";
                            data += "<td>" + Size + "</td>";
                            data += "<td>" + Peg_ML_Qty + "</td>";
                            data += "<td>" +
                                "<a href='Add_Cocktail_Recipes.aspx?Cocktail_ID=" + Cocktail_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  " +
                                "<a href='Add_Cocktail_Recipes.aspx?DelCocktail_ID=" + Cocktail_Brand_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> " +
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

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            GridView dgGrid = new GridView();
            DataSet dsExport = new DataSet();
            string currentDate = string.Empty;

            try
            {
                dsExport = ObjCocktailWorld.CocktailMaster_CRUD(0, string.Empty, string.Empty, CompanyID, LoggedInUserID, "F");

                DataTable dtCocktailMasterReport = new DataTable();

                if (dsExport.Tables.Count > 0)
                {
                    if (dsExport.Tables[0].Rows.Count > 0)
                    {
                        dtCocktailMasterReport = dsExport.Tables[0];

                        dtCocktailMasterReport.Columns.Remove("Cocktail_Brand_ID");
                        dtCocktailMasterReport.Columns.Remove("Cocktail_ID");
                        dtCocktailMasterReport.Columns["Cocktail_Desc"].ColumnName = "Cocktail Name";
                        dtCocktailMasterReport.Columns["Cocktail_Rate"].ColumnName = "Cocktail Rate";
                        dtCocktailMasterReport.Columns["Brand_Desc"].ColumnName = "Brand Name";
                        dtCocktailMasterReport.Columns["Size"].ColumnName = "Size";
                        dtCocktailMasterReport.Columns["Peg_ML_Qty"].ColumnName = "Peg / ML";
                        dtCocktailMasterReport.AcceptChanges();

                        dgGrid.DataSource = dtCocktailMasterReport;
                        dgGrid.DataBind();

                        currentDate = DateTime.Now.ToString();

                        System.IO.StringWriter tw = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                        string filename = "Cocktail Recipes REPORT AS ON " + currentDate + ".xls";

                        string HeaderText = "Cocktail Recipes REPORT AS ON " + currentDate;

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
        
        protected void btnExportPdf_Click(object sender, EventArgs e)
        {
            GridView dgGrid = new GridView();
            Document doc = new Document();
            try
            {
                DataSet dsReport = new DataSet();
                dsReport = ObjCocktailWorld.CocktailMaster_CRUD(0, string.Empty, string.Empty, CompanyID, LoggedInUserID, "F");

                System.Data.DataTable dtReport = new System.Data.DataTable();
                dtReport = dsReport.Tables[0];

                if (dsReport != null)
                {
                    if (dsReport.Tables.Count > 0)
                    {
                        if (dsReport.Tables[0].Rows.Count > 0)
                        {
                            dtReport.Columns.Remove("Cocktail_Brand_ID");
                            dtReport.Columns.Remove("Cocktail_ID");
                            dtReport.Columns["Cocktail_Desc"].ColumnName = "Cocktail Name";
                            dtReport.Columns["Cocktail_Rate"].ColumnName = "Cocktail Rate";
                            dtReport.Columns["Brand_Desc"].ColumnName = "Brand Name";
                            dtReport.Columns["Size"].ColumnName = "Size";
                            dtReport.Columns["Peg_ML_Qty"].ColumnName = "Peg / ML";

                            dtReport.AcceptChanges();

                            dgGrid.DataSource = dtReport;
                            dgGrid.DataBind();


                            System.IO.StringWriter tw = new System.IO.StringWriter();
                            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                            string filename = "Cocktail_Recipes_" + DateTime.Now + ".pdf";

                            string HeaderText = "Cocktail Recipes AS ON " + DateTime.Now;

                            Style textStyle = new Style();
                            textStyle.ForeColor = System.Drawing.Color.DarkCyan;
                            hw.EnterStyle(textStyle);

                            hw.Write("<h2><center>" + HeaderText + "</center></h2> </br>");
                            hw.ExitStyle(textStyle);

                            //Write the HTML back to the browser.

                            Response.ContentType = "application/pdf";
                            Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}.pdf", "Cocktail Recipes Report"));

                            iTextSharp.text.pdf.PdfPTable grd;

                            PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
                            doc.Open();

                            grd = new PdfPTable(dtReport.Columns.Count);
                            grd.WidthPercentage = 100.0F;

                            PdfPCell cellRptNm = new PdfPCell(new Phrase("Cocktail Recipes AS ON " + DateTime.Now));
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