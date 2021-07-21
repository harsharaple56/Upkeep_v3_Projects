using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Text;
using System.Data;
using System.Globalization;
using System.Data.OleDb;
using System.Data.Common;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using ListItem = System.Web.UI.WebControls.ListItem;

namespace Upkeep_v3.CheckList
{
    public partial class CheckList_Report_Listing : System.Web.UI.Page
    {

        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            hdn_IsPostBack.Value = "yes";
            if (!IsPostBack)
            {
                hdn_IsPostBack.Value = "no";
                Session["PreviousURL"] = HttpContext.Current.Request.Url.AbsoluteUri;

                Fetch_Checklist();
                Fetch_Department();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            fetchChkReportListing();
        }

        public string fetchChkReportListing()
        {
            string data = "";
            string From_Date = string.Empty;
            string To_Date = string.Empty;
            int Checklist_ID = Convert.ToInt32(ddlCheckist_Name.SelectedValue);
            int Department_ID = Convert.ToInt32(ddlCheckist_Department.SelectedValue);
            string Checklist_Status = Convert.ToString(ddlCheckist_Status.SelectedValue);

            //int Checklist_ID = 0;
            //int Department_ID = 0;
            //string Checklist_Status = " ";

            try
            {
                if (start_date.Value != "")
                {
                    From_Date = Convert.ToString(start_date.Value);
                }
                else
                {
                    From_Date = DateTime.Now.ToString("dd/MMM/yy", CultureInfo.InvariantCulture);

                }

                if (end_date.Value != "")
                {
                    To_Date = Convert.ToString(end_date.Value);
                }
                else
                {
                    DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yy", CultureInfo.InvariantCulture)).AddDays(30);
                    To_Date = FromDate.ToString("dd/MMM/yy", CultureInfo.InvariantCulture);
                }

                DataSet ds = new DataSet();
                ds = ObjUpkeep.Fetch_MyChecklistReportList(LoggedInUserID, Session["CompanyID"].ToString(), From_Date, To_Date,Department_ID,Checklist_ID, Checklist_Status);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            string Ans_Response_ID = Convert.ToString(ds.Tables[0].Rows[i]["Chk_Response_ID"]);
                            string Chk_Response_No = Convert.ToString(ds.Tables[0].Rows[i]["Chk_Response_No"]);
                            string Chk_Config_ID = Convert.ToString(ds.Tables[0].Rows[i]["Chk_Config_ID"]);
                            string ChecklistName = Convert.ToString(ds.Tables[0].Rows[i]["Checklist Name"]);
                            string Department = Convert.ToString(ds.Tables[0].Rows[i]["Department"]);
                            string Location = Convert.ToString(ds.Tables[0].Rows[i]["Location"]);
                            string StartTime = Convert.ToString(ds.Tables[0].Rows[i]["Start Time"]);
                            string EndTime = Convert.ToString(ds.Tables[0].Rows[i]["End Time"]);
                            string TotalHrs = Convert.ToString(ds.Tables[0].Rows[i]["Total Hrs"]);
                            string PercentCompleted = Convert.ToString(ds.Tables[0].Rows[i]["PercentCompleted"]);
                            string Generated_By = Convert.ToString(ds.Tables[0].Rows[i]["Generated_By"]);
                            string Status = Convert.ToString(ds.Tables[0].Rows[i]["Status"]);

                            
                            data += "<tr><td> <a href='CheckList_Report_Details.aspx?Ans_Response_ID=" + Ans_Response_ID + "' style='text-decoration: underline;' > " + Chk_Response_No + " </a></td>" +
                                "<td>" + ChecklistName + "</td>" + "<td>" + Department + "</td>" + "<td>" + Location + "</td>" +
                                "<td>" + StartTime + "</td>" +
                                "<td>" + EndTime + "</td>" +
                                "<td>" + TotalHrs + "</td>" + "<td class='Progress'>" + PercentCompleted + "</td>" +
                                "<td>" + Generated_By + "</td>" +
                                "<td>" + Status + "</td>" + 
                                "</tr>";
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
            catch  (Exception ex)
            {
                throw ex;
            }
            return data;
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            GridView dgGrid = new GridView();
            string From_Date = string.Empty;
            string To_Date = string.Empty;
            int Checklist_ID = Convert.ToInt32(ddlCheckist_Name.SelectedValue);
            int Department_ID = Convert.ToInt32(ddlCheckist_Department.SelectedValue);
            string Checklist_Status = Convert.ToString(ddlCheckist_Status.SelectedValue);

            try
            {
                if (start_date.Value != "")
                {
                    From_Date = Convert.ToString(start_date.Value);
                }
                else
                {
                    From_Date = DateTime.Now.ToString("dd/MMM/yy", CultureInfo.InvariantCulture);

                }

                if (end_date.Value != "")
                {
                    To_Date = Convert.ToString(end_date.Value);
                }
                else
                {
                    DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yy", CultureInfo.InvariantCulture)).AddDays(30);
                    To_Date = FromDate.ToString("dd/MMM/yy", CultureInfo.InvariantCulture);
                }

                DataSet dsReport = new DataSet();
                dsReport = ObjUpkeep.Fetch_MyChecklistReportList(LoggedInUserID, Session["CompanyID"].ToString(), From_Date, To_Date, Department_ID, Checklist_ID, Checklist_Status);

                System.Data.DataTable dtChkReport = new System.Data.DataTable();
                dtChkReport = dsReport.Tables[0];

                if (dsReport != null)
                {
                    if (dsReport.Tables.Count > 0)
                    {
                        if (dsReport.Tables[0].Rows.Count > 0)
                        {
                            dtChkReport.Columns.Remove("Chk_Response_ID");
                            dtChkReport.Columns.Remove("Chk_Config_ID");
                            dtChkReport.Columns["Chk_Response_No"].ColumnName = "Checklist No";
                            dtChkReport.Columns["Generated_By"].ColumnName = "Generated By";
                            //dtChkReport.Columns["Name"].ColumnName = "Manager Name";
                            //dtChkReport.Columns.Remove("Password");
                            //////dtCustomer.Columns.Remove("User_ID");
                            dtChkReport.AcceptChanges();

                            System.IO.StringWriter tw = new System.IO.StringWriter();
                            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                            string filename = "Checklist_Report_" + DateTime.Now + ".xls";

                            string HeaderText = "CHECKLIST REPORT AS ON " + DateTime.Now;

                            Style textStyle = new Style();
                            textStyle.ForeColor = System.Drawing.Color.DarkCyan;
                            hw.EnterStyle(textStyle);

                            hw.Write("<h2><center>" + HeaderText + "</center></h2> </br>");
                            hw.ExitStyle(textStyle);

                            //dgGrid.RenderControl(hw);



                            //btnExportToExcel.Visible = true;
                            //dgGrid.DataSource = dsMisReport.Tables[0];
                            dgGrid.DataSource = dtChkReport;
                            dgGrid.DataBind();
                            //Get the HTML for the control.
                            dgGrid.RenderControl(hw);


                            //Write the HTML back to the browser.

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


        protected void btnExportPDF_Click(object sender, EventArgs e)
        {
            GridView dgGrid = new GridView();
            string From_Date = string.Empty;
            string To_Date = string.Empty;
            int Checklist_ID = Convert.ToInt32(ddlCheckist_Name.SelectedValue);
            int Department_ID = Convert.ToInt32(ddlCheckist_Department.SelectedValue);
            string Checklist_Status = Convert.ToString(ddlCheckist_Status.SelectedValue);

            Document doc = new Document();
            try
            {
                if (start_date.Value != "")
                {
                    From_Date = Convert.ToString(start_date.Value);
                }
                else
                {
                    From_Date = DateTime.Now.ToString("dd/MMM/yy", CultureInfo.InvariantCulture);
                }

                if (end_date.Value != "")
                {
                    To_Date = Convert.ToString(end_date.Value);
                }
                else
                {
                    DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yy", CultureInfo.InvariantCulture)).AddDays(30);
                    To_Date = FromDate.ToString("dd/MMM/yy", CultureInfo.InvariantCulture);
                }

                DataSet dsReport = new DataSet();
                dsReport = ObjUpkeep.Fetch_MyChecklistReportList(LoggedInUserID, Session["CompanyID"].ToString(), From_Date, To_Date, Department_ID, Checklist_ID, Checklist_Status);


                System.Data.DataTable dtReport = new System.Data.DataTable();
                dtReport = dsReport.Tables[0];

                if (dsReport != null)
                {
                    if (dsReport.Tables.Count > 0)
                    {
                        if (dsReport.Tables[0].Rows.Count > 0)
                        {
                           
                            dtReport.Columns.Remove("Chk_Response_ID");
                            dtReport.Columns.Remove("Chk_Config_ID");
                            dtReport.Columns["Chk_Response_No"].ColumnName = "Checklist Response No";
                            ////dtReport.Columns["Store_Name"].ColumnName = "Store Name";
                            ////dtReport.Columns["Name"].ColumnName = "Manager Name";
                            ////dtReport.Columns.Remove("Password");

                            dtReport.AcceptChanges();

                            dgGrid.DataSource = dtReport;
                            dgGrid.DataBind();


                            System.IO.StringWriter tw = new System.IO.StringWriter();
                            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                            string filename = "Checklist_Report_" + DateTime.Now + ".pdf";

                            string HeaderText = "CHECKLIST REPORT AS ON " + DateTime.Now;

                            Style textStyle = new Style();
                            textStyle.ForeColor = System.Drawing.Color.DarkCyan;
                            hw.EnterStyle(textStyle);

                            hw.Write("<h2><center>" + HeaderText + "</center></h2> </br>");
                            hw.ExitStyle(textStyle);

                            //Write the HTML back to the browser.

                            Response.ContentType = "application/pdf";
                            //Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                            Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}.pdf", "Checklist_Report"));

                            
                            iTextSharp.text.pdf.PdfPTable grd;

                            PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
                            doc.Open();

                            grd = new PdfPTable(dtReport.Columns.Count);
                            grd.WidthPercentage = 100.0F;

                            PdfPCell cellRptNm = new PdfPCell(new Phrase("CHECKLIST REPORT AS ON " +From_Date + " to " + To_Date));
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

        public void Fetch_Checklist()
        {
            DataSet dsChecklist = new DataSet();
            try
            {
                dsChecklist = ObjUpkeep.Fetch_MyChecklist(LoggedInUserID, Convert.ToString(CompanyID), "", "");

                if (dsChecklist.Tables.Count > 0)
                {
                    if (dsChecklist.Tables[0].Rows.Count > 0)
                    {
                        ddlCheckist_Name.DataSource = dsChecklist.Tables[0];
                        ddlCheckist_Name.DataTextField = "Chk_Title";
                        ddlCheckist_Name.DataValueField = "Chk_Config_ID";
                        ddlCheckist_Name.DataBind();
                        ddlCheckist_Name.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Fetch_Department()
        {
            DataSet dsDept = new DataSet();
            try
            {
                dsDept = ObjUpkeep.Fetch_Department(CompanyID);

                if (dsDept.Tables.Count > 0)
                {
                    if (dsDept.Tables[0].Rows.Count > 0)
                    {
                        ddlCheckist_Department.DataSource = dsDept.Tables[0];
                        ddlCheckist_Department.DataTextField = "Department";
                        ddlCheckist_Department.DataValueField = "Department_ID";
                        ddlCheckist_Department.DataBind();
                        ddlCheckist_Department.Items.Insert(0, new ListItem("--Select--", "0"));
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