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

namespace Upkeep_v3.GatePass
{
    public partial class GatePass_Approval : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        string MyActionFlag = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            int TransactionID = Convert.ToInt32(Request.QueryString["TransactionID"]);
            MyActionFlag = Convert.ToString(Request.QueryString["MyAction"]);
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }

            if (!IsPostBack)
            {
                if (TransactionID > 0)
                {
                    Session["TransactionID"] = Convert.ToString(TransactionID);
                    BindGatePassRequest_Approval_Details(TransactionID, LoggedInUserID);
                    //Session["PreviousURL"] = HttpContext.Current.Request.Url.AbsoluteUri;
                }
            }
        }

        public void BindGatePassRequest_Approval_Details(int TransactionID, string LoggedInUserID)
        {
            DataSet dsApproval = new DataSet();
            string RequestStatus = string.Empty;
            try
            {
                dsApproval = ObjUpkeep.Fetch_GatePassRequest_Approval_Details(TransactionID, LoggedInUserID);

                if (dsApproval.Tables.Count > 0)
                {
                    lblGatepassTitle.Text = Convert.ToString(dsApproval.Tables[0].Rows[0]["GP_Title"]);
                    lblGatepassDescription.Text = Convert.ToString(dsApproval.Tables[0].Rows[0]["Gatepass_Description"]);
                    lblTicketNo.Text = Convert.ToString(dsApproval.Tables[0].Rows[0]["TicketNo"]);
                    lblDepartment.Text = Convert.ToString(dsApproval.Tables[0].Rows[0]["DepartmentName"]);
                    lblRequestDate.Text = Convert.ToString(dsApproval.Tables[0].Rows[0]["GatePassDate"]);
                    lblGatePassType.Text = Convert.ToString(dsApproval.Tables[0].Rows[0]["GP_Type_Desc"]);
                    lbl_Returnable_Gatepass.Text = Convert.ToString(dsApproval.Tables[0].Rows[0]["Returnable_Gatepass"]);

                    RequestStatus = Convert.ToString(dsApproval.Tables[0].Rows[0]["GP_Status"]);
                    if (Convert.ToString(dsApproval.Tables[0].Rows[0]["GP_Status"]) == "Open")
                    {
                        dvApprovalHistory.Attributes.Add("Style", "display:none;");
                    }
                    else
                    {
                        dvApprovalHistory.Attributes.Add("Style", "display:block;");
                    }

                    if (RequestStatus == "Open")
                    {
                        lblRequestStatus.Text = "Open";
                        lblRequestStatus.Attributes.Add("class", "m-badge m-badge--danger m-badge--wide");
                    }
                    else if (RequestStatus == "Approve")
                    {
                        lblRequestStatus.Text = "Approved";
                        lblRequestStatus.Attributes.Add("class", "m-badge m-badge--info m-badge--wide");
                    }
                    else if (RequestStatus == "In Progress")
                    {
                        lblRequestStatus.Text = "In Progress";
                        lblRequestStatus.Attributes.Add("class", "m-badge m-badge--success m-badge--wide");
                    }
                    else if (RequestStatus == "Close")
                    {
                        lblRequestStatus.Text = "Closed";
                        lblRequestStatus.Attributes.Add("class", "m-badge m-badge--success m-badge--wide");
                    }
                    else if (RequestStatus == "Hold")
                    {
                        lblRequestStatus.Text = "Hold";
                        lblRequestStatus.Attributes.Add("class", "m-badge m-badge--warning m-badge--wide");
                    }
                    else if (RequestStatus == "Reject")
                    {
                        lblRequestStatus.Text = "Rejected";
                        lblRequestStatus.Attributes.Add("class", "m-badge m-badge--danger m-badge--wide");
                    }
                    else if (RequestStatus == "Outward Closed")
                    {
                        lblRequestStatus.Text = "Outward Closed";
                        lblRequestStatus.Attributes.Add("class", "m-badge m-badge--success m-badge--wide");
                    }
                    else if (RequestStatus == "Return Approval Pending")
                    {
                        lblRequestStatus.Text = "Return Approval Pending";
                        lblRequestStatus.Attributes.Add("class", "m-badge m-badge--warning m-badge--wide");
                    }
                    else if (RequestStatus == "Returnable Pending")
                    {
                        lblRequestStatus.Text = "Return Approval Pending";
                        lblRequestStatus.Attributes.Add("class", "m-badge m-badge--warning m-badge--wide");
                    }

                }
                if (dsApproval.Tables.Count > 1)
                {
                    string strUserType = Convert.ToString(dsApproval.Tables[1].Rows[0]["UserType"]);
                    if (strUserType == "E")
                    {
                        dvEmployee.Attributes.Add("style", "display:block;");
                        dvRetailer.Attributes.Add("style", "display:none;");

                        Btn_GP_Print_PDF_Retailer.Visible = false;

                    }
                    else
                    {
                        dvEmployee.Attributes.Add("style", "display:none;");
                        dvRetailer.Attributes.Add("style", "display:block;");
                        Btn_GP_Print_PDF_Employee.Visible = false;
                    }

                    if (dsApproval.Tables.Count > 0)
                    {
                        if (dsApproval.Tables[1].Rows.Count > 0)
                        {
                            if (strUserType == "E")
                            {
                                lblEmpName.Text = Convert.ToString(dsApproval.Tables[1].Rows[0]["EmpName"]);
                                lblEmpCode.Text = Convert.ToString(dsApproval.Tables[1].Rows[0]["EmpCode"]);
                                lblMobileNo.Text = Convert.ToString(dsApproval.Tables[1].Rows[0]["EmpMobileNo"]);
                                LblEmailID.Text = Convert.ToString(dsApproval.Tables[1].Rows[0]["EmpEmail"]);
                            }
                            else
                            {
                                lblStoreName.Text = Convert.ToString(dsApproval.Tables[1].Rows[0]["Retail_Store_Name"]);
                                lblRetailerName.Text = Convert.ToString(dsApproval.Tables[1].Rows[0]["Store_Mger_Name"]);
                                lblMobileNo.Text = Convert.ToString(dsApproval.Tables[1].Rows[0]["Contact"]);
                                LblEmailID.Text = Convert.ToString(dsApproval.Tables[1].Rows[0]["Email"]);
                            }


                        }
                    }
                }
                if (dsApproval.Tables.Count > 1)
                {
                    if (dsApproval.Tables[2].Rows.Count > 0)
                    {
                        gvGPHeader.DataSource = dsApproval.Tables[2];
                        gvGPHeader.DataBind();
                    }
                }
                if (dsApproval.Tables.Count > 2)
                {
                    if (dsApproval.Tables[3].Rows.Count > 0)
                    {
                        rptTermsCondition.DataSource = dsApproval.Tables[3];
                        rptTermsCondition.DataBind();
                    }
                }
                if (dsApproval.Tables.Count > 3)
                {
                    if (dsApproval.Tables[4].Rows.Count > 0)
                    {
                        ddlAction.DataSource = dsApproval.Tables[4];
                        ddlAction.DataTextField = "Action_Desc";
                        ddlAction.DataValueField = "ActionID";
                        ddlAction.DataBind();
                        ddlAction.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
                if (dsApproval.Tables.Count > 4)
                {
                    if (dsApproval.Tables[5].Rows.Count > 0)
                    {
                        Session["CurrentLevel"] = Convert.ToString(dsApproval.Tables[5].Rows[0]["CurrentLevel"]);

                        //if (Convert.ToInt32(dsApproval.Tables[5].Rows[0]["CurrentLevel"]) == 1)
                        //{
                        //    dvApprovalHistory.Attributes.Add("Style", "display:none;");

                        //}
                        //else
                        //{
                        //    dvApprovalHistory.Attributes.Add("Style", "display:block;");
                        //}
                    }
                }
                if (dsApproval.Tables.Count > 5)
                {
                    if (dsApproval.Tables[6].Rows.Count > 0)
                    {
                        gvApprovalHistory.DataSource = dsApproval.Tables[6];
                        gvApprovalHistory.DataBind();
                    }
                }

                string Is_Initiator = Convert.ToString(dsApproval.Tables[5].Rows[0]["Is_Initiator"]);

                if (dsApproval.Tables.Count > 6)
                {
                    if (dsApproval.Tables[7].Rows.Count > 0)
                    {
                        gvApprovalMatrix.DataSource = dsApproval.Tables[7];
                        gvApprovalMatrix.DataBind();

                        //if (Is_Initiator == "1")
                        //{
                        //    dvApprovalMatrix.Attributes.Add("Style", "display:none;");
                        //}
                        //else
                        //{
                        //    dvApprovalMatrix.Attributes.Add("Style", "display:none;");
                        //}
                        if (Convert.ToInt32(dsApproval.Tables[0].Rows[0]["ShowApprovalMatrix"]) == 0)
                        {
                            dvApprovalMatrix.Attributes.Add("Style", "display:none;");
                        }
                    }
                }
                if (dsApproval.Tables.Count > 7)
                {
                    if (dsApproval.Tables[8].Rows.Count > 0)
                    {
                        rptGP_Doc_Upload.DataSource = dsApproval.Tables[8];
                        rptGP_Doc_Upload.DataBind();
                    }
                }

                if (MyActionFlag == "1")
                {

                    //dvApprovalDetHeader.Attributes.Add("Style", "display:block;");
                    //dvApprovalDetails.Attributes.Add("Style", "display:block;");
                    //dvSubmitSection.Attributes.Add("Style", "display:block;");
                }
                else
                {
                    dvApprovalDetHeader.Attributes.Add("Style", "display:none;");
                    dvApprovalDetails.Attributes.Add("Style", "display:none;");
                    dvSubmitSection.Attributes.Add("Style", "display:none;"); ;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btn_GP_Print_PDF_Employee(object sender, EventArgs e)
        {

            int TransactionID = Convert.ToInt32(Request.QueryString["TransactionID"]);
            Session["TransactionID"] = Convert.ToString(TransactionID);

            DataSet dsApproval = new DataSet();

            try
            {

                dsApproval = ObjUpkeep.Fetch_GatePassRequest_Approval_Details(TransactionID, LoggedInUserID);

                if (dsApproval != null)
                {
                    if (dsApproval.Tables.Count > 0)
                    {
                        if (dsApproval.Tables[0].Rows.Count > 0)
                        {

                            ReportViewer1.ProcessingMode = ProcessingMode.Local;
                            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/GatePass/Gatepass_Details_Print.rdlc");

                            ReportDataSource datasource0 = new ReportDataSource("ds_GP_0", dsApproval.Tables[0]);
                            //ReportDataSource datasource1 = new ReportDataSource("ds_GP1_Retailers", dsApproval.Tables[1]);
                            ReportDataSource datasource1E = new ReportDataSource("ds_GP1_Employee", dsApproval.Tables[1]);
                            ReportDataSource datasource3 = new ReportDataSource("ds_GP3_Terms", dsApproval.Tables[3]);
                            ReportDataSource datasource6 = new ReportDataSource("ds_GP6", dsApproval.Tables[6]);
                            ReportDataSource datasource7 = new ReportDataSource("ds_GP7", dsApproval.Tables[8]);
                            ReportDataSource datasource2 = new ReportDataSource("ds_GP2_Headerdata", dsApproval.Tables[2]);
                            ReportDataSource datasource9 = new ReportDataSource("ds_GP9", dsApproval.Tables[9]);
                            ReportDataSource datasource10 = new ReportDataSource("ds_GP10", dsApproval.Tables[10]);
                            ReportDataSource datasource11 = new ReportDataSource("ds_GP11_HeaderData", dsApproval.Tables[11]);



                            ReportViewer1.LocalReport.DataSources.Clear();
                            ReportViewer1.LocalReport.EnableHyperlinks = true;
                            ReportViewer1.LocalReport.EnableExternalImages = true;

                            ReportViewer1.LocalReport.DataSources.Add(datasource0);
                            //ReportViewer1.LocalReport.DataSources.Add(datasource1);
                            ReportViewer1.LocalReport.DataSources.Add(datasource1E);
                            ReportViewer1.LocalReport.DataSources.Add(datasource3);
                            ReportViewer1.LocalReport.DataSources.Add(datasource6);
                            ReportViewer1.LocalReport.DataSources.Add(datasource7);
                            ReportViewer1.LocalReport.DataSources.Add(datasource2);
                            ReportViewer1.LocalReport.DataSources.Add(datasource9);
                            ReportViewer1.LocalReport.DataSources.Add(datasource10);
                            ReportViewer1.LocalReport.DataSources.Add(datasource11);





                            ReportViewer1.LocalReport.Refresh();

                            string filename = "Gatepass_Report_" + DateTime.Now;

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

        protected void btn_GP_Print_PDF_Retailer(object sender, EventArgs e)
        {

            int TransactionID = Convert.ToInt32(Request.QueryString["TransactionID"]);
            Session["TransactionID"] = Convert.ToString(TransactionID);

            DataSet dsApproval = new DataSet();

            try
            {

                dsApproval = ObjUpkeep.Fetch_GatePassRequest_Approval_Details(TransactionID, LoggedInUserID);

                if (dsApproval != null)
                {
                    if (dsApproval.Tables.Count > 0)
                    {
                        if (dsApproval.Tables[0].Rows.Count > 0)
                        {


                            ReportViewer1.ProcessingMode = ProcessingMode.Local;
                            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/GatePass/Gatepass_Details_Print_Retailers.rdlc");

                            ReportDataSource datasource0 = new ReportDataSource("ds_GP_0", dsApproval.Tables[0]);
                            ReportDataSource datasource1 = new ReportDataSource("ds_GP1_Retailers", dsApproval.Tables[1]);
                            ReportDataSource datasource1E = new ReportDataSource("ds_GP1_Employee", dsApproval.Tables[1]);
                            ReportDataSource datasource3 = new ReportDataSource("ds_GP3_Terms", dsApproval.Tables[3]);
                            ReportDataSource datasource6 = new ReportDataSource("ds_GP6", dsApproval.Tables[6]);
                            ReportDataSource datasource7 = new ReportDataSource("ds_GP7", dsApproval.Tables[8]);
                            ReportDataSource datasource2 = new ReportDataSource("ds_GP2_Headerdata", dsApproval.Tables[2]);
                            ReportDataSource datasource9 = new ReportDataSource("ds_GP9", dsApproval.Tables[9]);
                            ReportDataSource datasource10 = new ReportDataSource("ds_GP10", dsApproval.Tables[10]);
                            ReportDataSource datasource11 = new ReportDataSource("ds_GP11_HeaderData", dsApproval.Tables[11]);


                            ReportViewer1.LocalReport.DataSources.Clear();
                            ReportViewer1.LocalReport.EnableHyperlinks = true;
                            ReportViewer1.LocalReport.EnableExternalImages = true;

                            ReportViewer1.LocalReport.DataSources.Add(datasource0);
                            ReportViewer1.LocalReport.DataSources.Add(datasource1);
                            ReportViewer1.LocalReport.DataSources.Add(datasource1E);
                            ReportViewer1.LocalReport.DataSources.Add(datasource3);
                            ReportViewer1.LocalReport.DataSources.Add(datasource6);
                            ReportViewer1.LocalReport.DataSources.Add(datasource7);
                            ReportViewer1.LocalReport.DataSources.Add(datasource2);
                            ReportViewer1.LocalReport.DataSources.Add(datasource9);
                            ReportViewer1.LocalReport.DataSources.Add(datasource10);
                            ReportViewer1.LocalReport.DataSources.Add(datasource11);





                            ReportViewer1.LocalReport.Refresh();

                            string filename = "Gatepass_Report_" + DateTime.Now;

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


        public List<ReportCell> GetReportCells(DataTable table)
        {
            return ReportCell.ConvertTableToCells(table);
        }

        protected async void btnSubmit_Click(object sender, EventArgs e)
        {
            string CurrentLevel = string.Empty;
            string TransactionID = string.Empty;
            string ActionStatus = string.Empty;
            string strRemarks = string.Empty;
            DataSet dsApproval = new DataSet();
            try
            {
                CurrentLevel = Convert.ToString(Session["CurrentLevel"]);
                TransactionID = Convert.ToString(Session["TransactionID"]);
                ActionStatus = Convert.ToString(ddlAction.SelectedItem.Text);
                strRemarks = Convert.ToString(txtRemarks.Text.Trim());

                dsApproval = ObjUpkeep.UpdateAction_GatePassRequest(TransactionID, CurrentLevel, ActionStatus, strRemarks, LoggedInUserID);

                if (dsApproval.Tables.Count > 0)
                {
                    if (dsApproval.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsApproval.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            if (dsApproval.Tables.Count > 1)
                            {
                                if (dsApproval.Tables[1].Rows.Count > 0)
                                {
                                    string NotificationHeader = string.Empty;
                                    string NotificationMsg = string.Empty;
                                    string TicketNo = string.Empty;

                                    if (ActionStatus == "Approve")
                                    {
                                        TicketNo = Convert.ToString(dsApproval.Tables[1].Rows[0]["TicketNo"]);

                                        NotificationHeader = "Gate pass ID " + TicketNo + ".";
                                        NotificationMsg = "A gate pass approved at Level " + CurrentLevel + " is now pending in your Account. Tap to take Action.";

                                        foreach (DataRow dr in dsApproval.Tables[1].Rows)
                                        {
                                            var TokenNO = Convert.ToString(dr["TokenNumber"]);
                                            int Is_App_Notification_Send = Convert.ToInt32(dr["Is_App_Notification_Send"]);
                                            //await SendNotification(TokenNO, Convert.ToString(lblTicketNo.Text), "New Gatepass Request");
                                            if (Is_App_Notification_Send > 0)
                                            {
                                                await SendNotification(TokenNO, Convert.ToInt32(TransactionID), NotificationHeader, NotificationMsg);
                                            }
                                        }
                                    }
                                }
                            }

                            Response.Redirect(Page.ResolveClientUrl(Convert.ToString(Session["PreviousURL"])), false);
                        }
                        else if (Status == 2)
                        {
                            lblErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl(Convert.ToString(Session["PreviousURL"])), false);
        }

        public static async Task SendNotification(string TokenNo, int TransactionID, string NotificationHeader, string NotificationMsg)
        {
            //TokenNo = "eSkpv5ZFSGip9BpPA0J2FE:APA91bEBZfqr4bvP7gIzfCdAcjTYU4uPYVMTvz4264ID5q32EfViLz2eRAqSb8tEuajK3l7LORQthSTnV_NMswAy2jXtbjfGyOEfafkijorMe5oAm9NjlUG1TJXGd0t6smmZN1r3mkTE";
            using (var client = new HttpClient())
            {
                //Send HTTP requests from here.  
                string API_URL = Convert.ToString(ConfigurationManager.AppSettings["API_URL"]);
                client.BaseAddress = new Uri(API_URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                //HttpResponseMessage response = await client.GetAsync("FunSendAppNotification?StrTokenNumber=" + TokenNo + "&TicketNo=" + TicketNo + "&StrMessage=" + strMessage + "&click_action=" + "Gatepass");
                HttpResponseMessage response = await client.GetAsync("FunSendAppNotification?StrTokenNumber=" + TokenNo + "&TransactionID=" + TransactionID + "&NotificationHeader=" + NotificationHeader + "&NotificationMsg=" + NotificationMsg + "&click_action=" + "GATEPASS");

                if (response.IsSuccessStatusCode)
                {
                    //Departmentdepartment = awaitresponse.Content.ReadAsAsync<Department>();
                    //Console.WriteLine("Id:{0}\tName:{1}", department.DepartmentId, department.DepartmentName);
                    //Console.WriteLine("No of Employee in Department: {0}", department.Employees.Count);
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
        }

    }

    public class ReportCell
    {
        public int RowId { get; set; }
        public string ColumnName { get; set; }
        public string Value { get; set; }

        public static List<ReportCell> ConvertTableToCells(DataTable table)
        {
            List<ReportCell> cells = new List<ReportCell>();

            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    ReportCell cell = new ReportCell
                    {
                        ColumnName = col.Caption,
                        RowId = table.Rows.IndexOf(row),
                        Value = row[col.ColumnName].ToString()
                    };

                    cells.Add(cell);
                }
            }

            return cells;
        }
    }

}