using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Text;
using System.Web.UI.HtmlControls;
//using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
//using System.Data.OleDb;
//using System.Data.Common;
//using iTextSharp.text;
//using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf;
using System.Web.Script.Serialization;
using Microsoft.Reporting.WebForms;

namespace Upkeep_v3.CheckList
{
    public partial class CheckList_Report_Details : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        DataSet dsGlobalDataS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {

            string Trans_Ans_Response_ID = "";
            if (Request.QueryString["Ans_Response_ID"] != null)
            {
                Trans_Ans_Response_ID = Convert.ToString(Request.QueryString["Ans_Response_ID"]);
                Session["Ans_Response_ID"] = Trans_Ans_Response_ID;
            }

            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);

                //Session["PreviousURL"] = "";
                //LoggedInUserID = "1"; 
            }


            if (!IsPostBack)
            {
                if (System.Web.HttpContext.Current.Session["PreviousURL"] == null)
                {
                    Session["PreviousURL"] = "~/CheckList/CheckList_Report_Details.aspx";
                }
                else
                {
                    Session["PreviousURL"] = "";
                }

                //if (Trans_Ans_Response_ID != "")
                //{
                    FetchAndBindData(Trans_Ans_Response_ID);
                //}
            }

        }


        public void FetchAndBindData(string Trans_Ans_Response_ID)
        {
            DataSet ds = new DataSet();

            ds = ObjUpkeep.Fetch_Checklist_Report(Trans_Ans_Response_ID, Convert.ToString(Session["LoggedInUserID"]));

            dsGlobalDataS.Clear();
            dsGlobalDataS = ds.Copy();


            if (ds.Tables[0].Rows.Count > 0)
            { 
                lblChecklisID.Text = ds.Tables[0].Rows[0]["Chk_Response_No"].ToString();
                lblChecklistName.Text = ds.Tables[0].Rows[0]["ChecklistName"].ToString();
                lblChecklistDesc.Text = ds.Tables[0].Rows[0]["ChecklistDesc"].ToString();

                lblDepartment.Text = ds.Tables[0].Rows[0]["Department"].ToString();
                lblLocation.Text = ds.Tables[0].Rows[0]["Location"].ToString();
                lblstartTime.Text = ds.Tables[0].Rows[0]["StartTime"].ToString();
                lblEndTime.Text = ds.Tables[0].Rows[0]["EndTime"].ToString();
                lblTotalScore.Text = ds.Tables[0].Rows[0]["TotalHrs"].ToString();
                lblGeneratedBy.Text = ds.Tables[0].Rows[0]["Generated_By"].ToString();
                lblStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();

                lblProgress.Text = ds.Tables[0].Rows[0]["PercentCompleted"].ToString();
            }


            if (ds.Tables[1].Rows.Count > 0)
            {
                rptSectionDetails.DataSource = ds.Tables[1];
                rptSectionDetails.DataBind();
            }
        }

        protected void rptSectionDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Reference the Repeater Item.
                RepeaterItem item = e.Item;
                 
                Label SectionName = e.Item.FindControl("lblSectionName") as Label;

                string hdnSectionID = (e.Item.FindControl("hdnSectionID") as HiddenField).Value;

                Repeater tblGrid = e.Item.FindControl("grdTable") as Repeater;

                DataSet dsWorkPermitHeader = new DataSet();
                dsWorkPermitHeader = dsGlobalDataS.Copy(); // ObjUpkeep.Bind_WorkPermitConfiguration(sPublicConfigId);

                DataTable dt = new DataTable();
                dt = dsWorkPermitHeader.Tables[2].Copy();
                dt.DefaultView.RowFilter = "Chk_Section_ID  = " + Convert.ToString(hdnSectionID) + "";
                dt = dt.DefaultView.ToTable();
                 

                if (dt.Rows.Count > 0)
                {
                    tblGrid.DataSource = dt;
                    tblGrid.DataBind();
                }
                else
                {
                    DataTable dt1 = new DataTable();
                    tblGrid.DataSource = dt1;
                    tblGrid.DataBind();

                }
            }
        }

        //protected void btnExportPDF_Click(object sender, EventArgs e)
        //{
        //    GridView dgGrid = new GridView();
        //    Document doc = new Document();
        //    try
        //    {
        //        string Trans_Ans_Response_ID = string.Empty;

        //        Trans_Ans_Response_ID = Convert.ToString(Session["Ans_Response_ID"]);

        //        DataSet dsReport = new DataSet();
        //        dsReport = ObjUpkeep.Fetch_Checklist_Report(Trans_Ans_Response_ID, Convert.ToString(Session["LoggedInUserID"]));

        //        System.Data.DataTable dtReport = new System.Data.DataTable();
        //        dtReport = dsReport.Tables[2];

        //        if (dsReport != null)
        //        {
        //            if (dsReport.Tables.Count > 0)
        //            {
        //                if (dsReport.Tables[0].Rows.Count > 0)
        //                {
        //                    dtReport.Columns.Remove("Flag");
        //                    dtReport.Columns.Remove("CHK_Question_ID");
        //                    dtReport.Columns.Remove("Chk_Section_ID");
        //                    dtReport.Columns.Remove("Is_Attach_Mandatory");
        //                    dtReport.Columns.Remove("Is_Qn_Mandatory");
        //                    dtReport.Columns.Remove("Qn_Score");
        //                    dtReport.Columns.Remove("Chk_Ans_Type_ID");
        //                    dtReport.Columns.Remove("Is_Raise_Flag_Issue");
        //                    dtReport.Columns.Remove("Ans_Response_ID");
        //                    dtReport.Columns.Remove("Chk_Response_ID");
        //                    dtReport.Columns.Remove("Chk_Ans_Value_ID");

        //                    dtReport.Columns["FlagValue"].ColumnName = "Flag";
        //                    dtReport.Columns["Qn_Desc"].ColumnName = "Question Description";
        //                    dtReport.Columns["Chk_Ans_Value_Data"].ColumnName = "Answer Data";
        //                    //dtReport.Columns.Remove("Password");

        //                    dtReport.AcceptChanges();

        //                    dgGrid.DataSource = dtReport;
        //                    dgGrid.DataBind();


        //                    System.IO.StringWriter tw = new System.IO.StringWriter();
        //                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

        //                    string filename = "Checklist_Report_" + DateTime.Now + ".pdf";

        //                    string HeaderText = "CHECKLIST REPORT ON " + DateTime.Now;

        //                    Style textStyle = new Style();
        //                    textStyle.ForeColor = System.Drawing.Color.DarkCyan;
        //                    hw.EnterStyle(textStyle);

        //                    hw.Write("<h2><center>" + HeaderText + "</center></h2> </br>");
        //                    hw.ExitStyle(textStyle);


        //                    //Write the HTML back to the browser.

        //                    Response.ContentType = "application/pdf";
        //                    //Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
        //                    Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}.pdf", "Checklist_Report"));

        //                    //this.EnableViewState = false;
        //                    //Response.Write(tw.ToString());
        //                    //Response.End();
        //                    //return;
        //                    iTextSharp.text.pdf.PdfPTable grd;

        //                    PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
        //                    doc.Open();

        //                    grd = new PdfPTable(dtReport.Columns.Count);
        //                    grd.WidthPercentage = 100.0F;

        //                    PdfPCell cellRptNm = new PdfPCell(new Phrase("CHECKLIST REPORT AS ON " + DateTime.Now));
        //                    cellRptNm.HorizontalAlignment = 1;
        //                    cellRptNm.Colspan = dtReport.Columns.Count;
        //                    cellRptNm.Border = 0;
        //                    cellRptNm.PaddingBottom = 20.0F;
        //                    grd.AddCell(cellRptNm);

        //                    BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
        //                    iTextSharp.text.Font fnt = new iTextSharp.text.Font(bfTimes, 7);

        //                    for (var IntLocColCnt = 0; IntLocColCnt <= dtReport.Columns.Count - 1; IntLocColCnt++)
        //                    {
        //                        PdfPCell cellHD1 = new PdfPCell(new Phrase(dtReport.Columns[IntLocColCnt].ColumnName, fnt));
        //                        cellHD1.PaddingBottom = 10.0F;
        //                        cellHD1.BackgroundColor = iTextSharp.text.Color.LIGHT_GRAY;
        //                        cellHD1.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
        //                        cellHD1.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
        //                        grd.AddCell(cellHD1);
        //                    }

        //                    for (var IntLocRowCnt = 0; IntLocRowCnt <= dtReport.Rows.Count - 1; IntLocRowCnt++)
        //                    {
        //                        for (var IntLocColCnt = 0; IntLocColCnt <= dtReport.Columns.Count - 1; IntLocColCnt++)
        //                        {
        //                            string str = Convert.ToString(dtReport.Rows[IntLocRowCnt][IntLocColCnt]);
        //                            PdfPCell cell = new PdfPCell(new Phrase(str, fnt));
        //                            cell.PaddingBottom = 10.0F;
        //                            grd.AddCell(cell);
        //                        }
        //                    }
        //                    doc.Add(grd);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            dgGrid.DataSource = null;
        //            dgGrid.DataBind();

        //            return;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        doc.Close();
        //    }
        //    // Indicate that the data to send to the client has ended
        //    Response.End();
        //}

        protected void btnExportPDF_Click(object sender, EventArgs e)
        {
           
            try
            {
                string Trans_Ans_Response_ID = string.Empty;

                Trans_Ans_Response_ID = Convert.ToString(Session["Ans_Response_ID"]);

                DataSet dsReport = new DataSet();
                dsReport = ObjUpkeep.Fetch_Checklist_Report(Trans_Ans_Response_ID, Convert.ToString(Session["LoggedInUserID"]));

                if (dsReport != null)
                {
                    if (dsReport.Tables.Count > 0)
                    {
                        if (dsReport.Tables[0].Rows.Count > 0)
                        {
                            ReportViewer1.ProcessingMode = ProcessingMode.Local;
                            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Checklist/Checklist_Report.rdlc");

                            ReportDataSource datasource0 = new ReportDataSource("ds_Checklist_Header", dsReport.Tables[0]);
                            ReportDataSource datasource1 = new ReportDataSource("ds_Checklist_Data", dsReport.Tables[2]);

                            ReportViewer1.LocalReport.DataSources.Clear();
                            ReportViewer1.LocalReport.EnableHyperlinks = true;
                            ReportViewer1.LocalReport.DataSources.Add(datasource0);
                            ReportViewer1.LocalReport.DataSources.Add(datasource1);
                            ReportViewer1.LocalReport.Refresh();

                            string filename = "Checklist_Report_" + DateTime.Now;

                            string deviceInfo = "<DeviceInfo>" +
                                "  <OutputFormat>PDF</OutputFormat>" +
                                "  <PageWidth>8.27in</PageWidth>" +
                                //"  <PageHeight>11.69in</PageHeight>" +
                                //"  <MarginTop>0.25in</MarginTop>" +
                                "  <MarginLeft>0.4in</MarginLeft>" +
                                "  <MarginRight>0in</MarginRight>" +
                                //"  <MarginBottom>0.25in</MarginBottom>" +
                                "  <EmbedFonts>None</EmbedFonts>" +
                                "</DeviceInfo>";

                            Warning[] warnings;
                            string[] streamIds;
                            string mimeType = string.Empty;
                            string encoding = string.Empty;
                            string extension = string.Empty;
                            byte[] bytes = ReportViewer1.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding, out extension, out streamIds, out warnings);

                            Response.Buffer = true;
                            Response.Clear();
                            Response.ContentType = mimeType;
                            Response.AddHeader("content-disposition", "attachment; filename=" + filename + "." + extension);
                            Response.BinaryWrite(bytes);
                            Response.Flush();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }

}