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
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Drawing;

namespace Upkeep_Gatepass_Workpermit.Reports
{
    public partial class BaggageReport : System.Web.UI.Page
    {
        Upkeep_GP_WP_Services.Upkeep_GP_WP_Services ObjUpkeepBaggage = new Upkeep_GP_WP_Services.Upkeep_GP_WP_Services();
        //DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        GridView dgGrid = new GridView();
        protected void Page_Load(object sender, EventArgs e)
        {
            hdn_IsPostBack.Value = "yes";
            if (!IsPostBack)
            {
                hdn_IsPostBack.Value = "no";
            }
        }

        public string FetchBaggageReport()
        {
            string BaggageData = "";
            string From_Date = string.Empty;
            string To_Date = string.Empty;
            DataSet dsBaggage = new DataSet();
            try
            {
                if (start_date.Value != "")
                {
                    From_Date = Convert.ToString(start_date.Value);
                }
                else
                {
                    DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture)).AddDays(-30);
                    From_Date = FromDate.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
                }

                if (end_date.Value != "")
                {
                    To_Date = Convert.ToString(end_date.Value);
                }
                else
                {
                    To_Date = DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
                }

                dsBaggage = ObjUpkeepBaggage.FetchBaggageReport(From_Date, To_Date);

                string BagTicket = string.Empty;
                string CustomerName = string.Empty;
                string Location = string.Empty;
                string ContactNo = string.Empty;
                string AlterNo = string.Empty;
                string TotalBag = string.Empty;
                string Price = string.Empty;
                string UserName = string.Empty;
                string InTime = string.Empty;
                string OutTime = string.Empty;
                string GivenUser = string.Empty;
                string Porter = string.Empty;
                string BagTagID = string.Empty;
                string TotalTime = string.Empty;

                if (dsBaggage.Tables.Count > 0)
                {
                    if (dsBaggage.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(dsBaggage.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            BagTicket = Convert.ToString(dsBaggage.Tables[0].Rows[i]["BagTicketId"]);
                            CustomerName = Convert.ToString(dsBaggage.Tables[0].Rows[i]["Full_Name"]);
                            Location = Convert.ToString(dsBaggage.Tables[0].Rows[i]["Address"]);
                            ContactNo = Convert.ToString(dsBaggage.Tables[0].Rows[i]["Contact_No"]);
                            AlterNo = Convert.ToString(dsBaggage.Tables[0].Rows[i]["Alter_No"]);
                            TotalBag = Convert.ToString(dsBaggage.Tables[0].Rows[i]["total_Bag"]);
                            Price = Convert.ToString(dsBaggage.Tables[0].Rows[i]["Price"]);
                            UserName = Convert.ToString(dsBaggage.Tables[0].Rows[i]["Username"]);
                            InTime = Convert.ToString(dsBaggage.Tables[0].Rows[i]["InTime"]);
                            OutTime = Convert.ToString(dsBaggage.Tables[0].Rows[i]["OutTime"]);
                            GivenUser = Convert.ToString(dsBaggage.Tables[0].Rows[i]["GivenUser"]);
                            Porter = Convert.ToString(dsBaggage.Tables[0].Rows[i]["Associate"]);
                            BagTagID = Convert.ToString(dsBaggage.Tables[0].Rows[i]["bagTagID"]);
                            TotalTime = Convert.ToString(dsBaggage.Tables[0].Rows[i]["TotalTime"]);


                            BaggageData += "<tr><td> " + BagTicket + " </td><td>" + CustomerName + "</td><td>" + Location + "</td><td>" + ContactNo + "</td><td>" + AlterNo + "</td><td>" + TotalBag + "</td><td>" + Price + "</td><td>" + UserName + "</td>" +
                                "<td>" + InTime + "</td><td>" + OutTime + "</td><td>" + GivenUser + "</td><td>" + Porter + "</td><td>" + BagTagID + "</td><td>" + TotalTime + "</td></tr>";

                        }

                    }
                    else
                    {
                        //invalid login
                    }
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }

            return BaggageData;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            FetchBaggageReport();
        }

        protected void btnExportPDF_Click(object sender, EventArgs e)
        {
            string From_Date = string.Empty;
            string To_Date = string.Empty;
            DataSet dsBaggage = new DataSet();

            if (start_date.Value != "")
            {
                From_Date = Convert.ToString(start_date.Value);
            }
            else
            {
                DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture)).AddDays(-30);
                From_Date = FromDate.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
            }

            if (end_date.Value != "")
            {
                To_Date = Convert.ToString(end_date.Value);
            }
            else
            {
                To_Date = DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
            }

           

            // Specify the content type.
            Response.ContentType = "application/pdf";

            // Add a Content-Disposition header.
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}.pdf", "BAGGAGE-REPORT-" + From_Date + "-" + To_Date));

            // Create a Document object
            Document doc = new Document();
            System.Data.DataTable dtBaggageReport = new System.Data.DataTable();
            try
            {
                dsBaggage = ObjUpkeepBaggage.FetchBaggageReport(From_Date, To_Date);
                if (dsBaggage != null)
                {
                    if (dsBaggage.Tables.Count > 0)
                    {
                        if (dsBaggage.Tables[0].Rows.Count > 0)
                        {
                            dtBaggageReport = dsBaggage.Tables[0];
                            dgGrid.DataSource = dtBaggageReport;
                            dgGrid.DataBind();
                        }
                    }
                }

                dtBaggageReport.Columns["BagTicketId"].ColumnName = "Bag Ticket No";
                dtBaggageReport.Columns["Full_Name"].ColumnName = " Customer Name";
                dtBaggageReport.Columns["Address"].ColumnName = "Location";
                dtBaggageReport.Columns["Contact_No"].ColumnName = "Contact No.";
                dtBaggageReport.Columns["Alter_No"].ColumnName = "Alter No.";
                dtBaggageReport.Columns["total_Bag"].ColumnName = "Total Bag";
                dtBaggageReport.Columns["Price"].ColumnName = "Price";
                dtBaggageReport.Columns["Username"].ColumnName = "Username";
                dtBaggageReport.Columns["InTime"].ColumnName = "In Time";
                dtBaggageReport.Columns["OutTime"].ColumnName = "Out Time";
                dtBaggageReport.Columns["GivenUser"].ColumnName = "Given User";
                dtBaggageReport.Columns["Associate"].ColumnName = "Associate";
                dtBaggageReport.Columns["bagTagID"].ColumnName = "Tag ID";
                dtBaggageReport.Columns["TotalTime"].ColumnName = "Total Time";


                iTextSharp.text.pdf.PdfPTable grd;

                PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
                doc.Open();

                grd = new PdfPTable(dtBaggageReport.Columns.Count);
                grd.WidthPercentage = 100.0F;

                PdfPCell cellRptNm = new PdfPCell(new Phrase("BAGGAGE REPORT FOR " + From_Date + " to " + To_Date));
                cellRptNm.HorizontalAlignment = 1;
                cellRptNm.Colspan = dtBaggageReport.Columns.Count;
                cellRptNm.Border = 0;
                cellRptNm.PaddingBottom = 20.0F;
                grd.AddCell(cellRptNm);

                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                iTextSharp.text.Font fnt = new iTextSharp.text.Font(bfTimes, 7);

                for (var IntLocColCnt = 0; IntLocColCnt <= dtBaggageReport.Columns.Count - 1; IntLocColCnt++)
                {
                    PdfPCell cellHD1 = new PdfPCell(new Phrase(dtBaggageReport.Columns[IntLocColCnt].ColumnName, fnt));
                    cellHD1.PaddingBottom = 10.0F;
                    cellHD1.BackgroundColor = Color.LIGHT_GRAY;
                    cellHD1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellHD1.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    grd.AddCell(cellHD1);
                }

                for (var IntLocRowCnt = 0; IntLocRowCnt <= dtBaggageReport.Rows.Count - 1; IntLocRowCnt++)
                {
                    for (var IntLocColCnt = 0; IntLocColCnt <= dtBaggageReport.Columns.Count - 1; IntLocColCnt++)
                    {
                        //string str = IIf(IsDBNull(dtBaggageReport.Rows[IntLocRowCnt][IntLocColCnt]), "", dtBaggageReport.Rows[IntLocRowCnt][IntLocColCnt]);
                        string str = Convert.ToString(dtBaggageReport.Rows[IntLocRowCnt][IntLocColCnt]);
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

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {

            string From_Date = string.Empty;
            string To_Date = string.Empty;
            DataSet dsBaggage = new DataSet();
            try
            {
                if (start_date.Value != "")
                {
                    From_Date = Convert.ToString(start_date.Value);
                }
                else
                {
                    DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture)).AddDays(-30);
                    From_Date = FromDate.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
                }

                if (end_date.Value != "")
                {
                    To_Date = Convert.ToString(end_date.Value);
                }
                else
                {
                    To_Date = DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
                }

                dsBaggage = ObjUpkeepBaggage.FetchBaggageReport(From_Date, To_Date);
                System.Data.DataTable dtBaggageReport = new System.Data.DataTable();

                if (dsBaggage != null)
                {
                    if (dsBaggage.Tables.Count > 0)
                    {
                        if (dsBaggage.Tables[0].Rows.Count > 0)
                        {
                            dtBaggageReport = dsBaggage.Tables[0];
                            dgGrid.DataSource = dtBaggageReport;
                            dgGrid.DataBind();

                            System.IO.StringWriter tw = new System.IO.StringWriter();
                            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                            string filename = "BAGGAGE REPORT FOR " + From_Date + " to " + To_Date + ".xls";

                            string HeaderText = "BAGGAGE REPORT FOR " + From_Date + " to " + To_Date ;

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

        protected void btnExportPDF_Click1(object sender, EventArgs e)
        {
            string From_Date = string.Empty;
            string To_Date = string.Empty;
            DataSet dsBaggage = new DataSet();
            try
            {
                if (start_date.Value != "")
                {
                    From_Date = Convert.ToString(start_date.Value);
                }
                else
                {
                    DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture)).AddDays(-30);
                    From_Date = FromDate.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
                }

                if (end_date.Value != "")
                {
                    To_Date = Convert.ToString(end_date.Value);
                }
                else
                {
                    To_Date = DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
                }

                dsBaggage = ObjUpkeepBaggage.FetchBaggageReport(From_Date, To_Date);
                System.Data.DataTable dtBaggageReport = new System.Data.DataTable();

                if (dsBaggage != null)
                {
                    if (dsBaggage.Tables.Count > 0)
                    {
                        if (dsBaggage.Tables[0].Rows.Count > 0)
                        {
                            dtBaggageReport = dsBaggage.Tables[0];
                            dgGrid.DataSource = dtBaggageReport;
                            dgGrid.DataBind();

                            using (StringWriter sw = new StringWriter())
                            {
                                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                                {
                                    dgGrid.RenderControl(hw);
                                    StringReader sr = new StringReader(sw.ToString());
                                    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                                    pdfDoc.Open();

                                    
                                    //
                                    iTextSharp.text.pdf.PdfPTable pdfTable;
                                    pdfTable = new PdfPTable(dtBaggageReport.Columns.Count);
                                    //pdfTable.TotalWidth = 480f;
                                    //pdfTable.LockedWidth = true;
                                    pdfTable.WidthPercentage = 100.0F;


                                    Phrase phrase = null;
                                    PdfPCell cell = null;
                                    phrase = new Phrase();
                                    phrase.Add(new Chunk("BAGGAGE REPORT FOR \n\n", FontFactory.GetFont("Arial", 16, Font.BOLD, Color.RED)));
                                    cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                                    cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                                    pdfTable.AddCell(cell);


                                    Font font_heading1 = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10f, Font.BOLD, Color.BLUE);

                                    //PdfPCell cellRptNm = new PdfPCell(new Phrase("BAGGAGE REPORT FOR " + From_Date + " to " + To_Date, font_heading1));
                                    //cellRptNm.HorizontalAlignment = 1;
                                    //cellRptNm.Colspan = dtBaggageReport.Columns.Count;
                                    //cellRptNm.Border = 0;
                                    //cellRptNm.PaddingBottom = 20.0F;
                                    //pdfTable.AddCell(cellRptNm);

                                    //BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                                    //iTextSharp.text.Font fnt = new iTextSharp.text.Font(bfTimes, 7);



                                    //
                                    htmlparser.Parse(sr);
                                    pdfDoc.Close();

                                    Response.ContentType = "application/pdf";
                                    //Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
                                    Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}.pdf", "BAGGAGE-REPORT-" + From_Date + "-" + To_Date));
                                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                                    Response.Write(pdfDoc);
                                    Response.End();
                                }
                            }
                        }
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

        private static PdfPCell PhraseCell(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = Color.WHITE;
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            return cell;
        }


    }
}