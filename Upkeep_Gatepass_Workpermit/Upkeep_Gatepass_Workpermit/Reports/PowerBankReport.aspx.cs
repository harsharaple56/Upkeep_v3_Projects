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

namespace Upkeep_Gatepass_Workpermit.Reports
{
    public partial class PowerBankReport : System.Web.UI.Page
    {
        Upkeep_GP_WP_Services.Upkeep_GP_WP_Services ObjUpkeepPowerBank = new Upkeep_GP_WP_Services.Upkeep_GP_WP_Services();
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

        public string FetchPowerBankReport()
        {
            string PowerBankData = "";
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

                dsBaggage = ObjUpkeepPowerBank.FetchPowerBankReport(From_Date, To_Date);

                string PowerBankNo = string.Empty;
                string CustomerName = string.Empty;
                string Location = string.Empty;
                string EmailID = string.Empty;
                string ContactNo = string.Empty;
                string AlterNo = string.Empty;
                string Status = string.Empty;
                string CableType = string.Empty;
                string UserName = string.Empty;
                string InTime = string.Empty;
                string OutTime = string.Empty;
                string TotalTime = string.Empty;

                if (dsBaggage.Tables.Count > 0)
                {
                    if (dsBaggage.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(dsBaggage.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            PowerBankNo = Convert.ToString(dsBaggage.Tables[0].Rows[i]["Assign_id"]);
                            CustomerName = Convert.ToString(dsBaggage.Tables[0].Rows[i]["Full_Name"]);
                            Location = Convert.ToString(dsBaggage.Tables[0].Rows[i]["Address"]);
                            EmailID = Convert.ToString(dsBaggage.Tables[0].Rows[i]["Email_id"]);
                            ContactNo = Convert.ToString(dsBaggage.Tables[0].Rows[i]["Contact_No"]);
                            AlterNo = Convert.ToString(dsBaggage.Tables[0].Rows[i]["Alter_No"]);
                            Status = Convert.ToString(dsBaggage.Tables[0].Rows[i]["status"]);
                            CableType = Convert.ToString(dsBaggage.Tables[0].Rows[i]["PowerBnk_Model"]);
                            UserName = Convert.ToString(dsBaggage.Tables[0].Rows[i]["Username"]);
                            InTime = Convert.ToString(dsBaggage.Tables[0].Rows[i]["InTime"]);
                            OutTime = Convert.ToString(dsBaggage.Tables[0].Rows[i]["OutTime"]);
                            TotalTime = Convert.ToString(dsBaggage.Tables[0].Rows[i]["TotalTime"]);


                            PowerBankData += "<tr><td> " + PowerBankNo + " </td><td>" + CustomerName + "</td><td>" + Location + "</td><td>" + EmailID + "</td><td>" + ContactNo + "</td><td>" + AlterNo + "</td><td>" + Status + "</td><td>" + CableType + "</td><td>" + UserName + "</td>" +
                                "<td>" + InTime + "</td><td>" + OutTime + "</td><td>" + TotalTime + "</td></tr>";

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

            return PowerBankData;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            FetchPowerBankReport();
        }

        protected void btnExportPDF_Click(object sender, EventArgs e)
        {
            string From_Date = string.Empty;
            string To_Date = string.Empty;
            DataSet dsPowerBank = new DataSet();

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
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}.pdf", "POWERBANK-REPORT-" + From_Date + "-" + To_Date));

            // Create a Document object
            Document doc = new Document();
            System.Data.DataTable dtPowerBankReport = new System.Data.DataTable();
            try
            {
                dsPowerBank = ObjUpkeepPowerBank.FetchPowerBankReport(From_Date, To_Date);
                if (dsPowerBank != null)
                {
                    if (dsPowerBank.Tables.Count > 0)
                    {
                        if (dsPowerBank.Tables[0].Rows.Count > 0)
                        {
                            dtPowerBankReport = dsPowerBank.Tables[0];
                            dgGrid.DataSource = dtPowerBankReport;
                            dgGrid.DataBind();
                        }
                    }
                }

                dtPowerBankReport.Columns["Assign_id"].ColumnName = "Power Bank No";
                dtPowerBankReport.Columns["Full_Name"].ColumnName = " Customer Name";
                dtPowerBankReport.Columns["Address"].ColumnName = "Location";
                dtPowerBankReport.Columns["Email_id"].ColumnName = "Email ID";
                dtPowerBankReport.Columns["Contact_No"].ColumnName = "Contact No.";
                dtPowerBankReport.Columns["Alter_No"].ColumnName = "Alter No.";
                dtPowerBankReport.Columns["status"].ColumnName = "Status";
                dtPowerBankReport.Columns["PowerBnk_Model"].ColumnName = "Cable Type";
                dtPowerBankReport.Columns["Username"].ColumnName = "Username";
                dtPowerBankReport.Columns["InTime"].ColumnName = "In Time";
                dtPowerBankReport.Columns["OutTime"].ColumnName = "Out Time";
                dtPowerBankReport.Columns["TotalTime"].ColumnName = "Total Time";


                iTextSharp.text.pdf.PdfPTable grd;

                PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
                doc.Open();

                grd = new PdfPTable(dtPowerBankReport.Columns.Count);
                grd.WidthPercentage = 100.0F;

                PdfPCell cellRptNm = new PdfPCell(new Phrase("POWER BANK REPORT FOR " + From_Date + " to " + To_Date));
                cellRptNm.HorizontalAlignment = 1;
                cellRptNm.Colspan = dtPowerBankReport.Columns.Count;
                cellRptNm.Border = 0;
                cellRptNm.PaddingBottom = 20.0F;
                grd.AddCell(cellRptNm);

                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
                iTextSharp.text.Font fnt = new iTextSharp.text.Font(bfTimes, 7);

                for (var IntLocColCnt = 0; IntLocColCnt <= dtPowerBankReport.Columns.Count - 1; IntLocColCnt++)
                {
                    PdfPCell cellHD1 = new PdfPCell(new Phrase(dtPowerBankReport.Columns[IntLocColCnt].ColumnName, fnt));
                    cellHD1.PaddingBottom = 10.0F;
                    cellHD1.BackgroundColor = Color.LIGHT_GRAY;
                    cellHD1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cellHD1.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    grd.AddCell(cellHD1);
                }

                for (var IntLocRowCnt = 0; IntLocRowCnt <= dtPowerBankReport.Rows.Count - 1; IntLocRowCnt++)
                {
                    for (var IntLocColCnt = 0; IntLocColCnt <= dtPowerBankReport.Columns.Count - 1; IntLocColCnt++)
                    {
                        //string str = IIf(IsDBNull(dtBaggageReport.Rows[IntLocRowCnt][IntLocColCnt]), "", dtBaggageReport.Rows[IntLocRowCnt][IntLocColCnt]);
                        string str = Convert.ToString(dtPowerBankReport.Rows[IntLocRowCnt][IntLocColCnt]);
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
            DataSet dsPowerBank = new DataSet();
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

                dsPowerBank = ObjUpkeepPowerBank.FetchPowerBankReport(From_Date, To_Date);
                System.Data.DataTable dtPowerBankReport = new System.Data.DataTable();

                if (dsPowerBank != null)
                {
                    if (dsPowerBank.Tables.Count > 0)
                    {
                        if (dsPowerBank.Tables[0].Rows.Count > 0)
                        {
                            dtPowerBankReport = dsPowerBank.Tables[0];
                            dgGrid.DataSource = dtPowerBankReport;
                            dgGrid.DataBind();

                            System.IO.StringWriter tw = new System.IO.StringWriter();
                            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                            string filename = "POWER BANK REPORT FOR " + From_Date + " to " + To_Date + ".xls";

                            string HeaderText = "POWER BANK REPORT FOR " + From_Date + " to " + To_Date;

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


    }
}