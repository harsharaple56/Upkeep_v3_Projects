using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

namespace Upkeep_v3.VMS
{
    public partial class VMSRequest_Listing : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
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
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            fetchVMSRequestList();
        }

        public string fetchVMSRequestList()
        {
            string data = "";
            string From_Date = string.Empty;
            string To_Date = string.Empty;

            try
            {
                if (start_date.Value != "")
                {
                    From_Date = Convert.ToDateTime(start_date.Value).ToString("dd-MMM-yyyy");
                }
                else
                {
                    //From_Date = DateTime.Now.AddDays(-29).ToString("dd/MMM/yy", CultureInfo.InvariantCulture);

                    From_Date = DateTime.Now.ToString("dd/MMM/yy", CultureInfo.InvariantCulture);
                }

                if (end_date.Value != "")
                {
                    To_Date = Convert.ToDateTime(end_date.Value).ToString("dd-MMM-yyyy");
                }
                else
                {
                    //DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yy", CultureInfo.InvariantCulture)).AddDays(30);
                    DateTime To_Date_dt = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yy", CultureInfo.InvariantCulture));

                    To_Date = To_Date_dt.ToString("dd/MMM/yy", CultureInfo.InvariantCulture);
                }

                DataSet ds = new DataSet();
                ds = ObjUpkeep.Fetch_VMSRequestList(Convert.ToInt32(Session["CompanyID"]), LoggedInUserID, From_Date, To_Date);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            string SrNO = Convert.ToString(1 + i);
                            string RequestID = Convert.ToString(ds.Tables[0].Rows[i]["Request_ID"]);
                            string Config_Title = Convert.ToString(ds.Tables[0].Rows[i]["Config_Title"]);
                            string MeetDate = Convert.ToString(ds.Tables[0].Rows[i]["Meeting_Time"]);
                            string RequestDate = Convert.ToString(ds.Tables[0].Rows[i]["Created_Date"]);
                            string InTime = Convert.ToString(ds.Tables[0].Rows[i]["CheckIn_Time"]);
                            string OutTime = Convert.ToString(ds.Tables[0].Rows[i]["CheckOut_Time"]);
                            string Status = Convert.ToString(ds.Tables[0].Rows[i]["Status"]);
                            string Created_By = Convert.ToString(ds.Tables[0].Rows[i]["Created_By"]);
                            string Name = Convert.ToString(ds.Tables[0].Rows[i]["Name"]);
                            string Phone = Convert.ToString(ds.Tables[0].Rows[i]["Phone"]);
                            string Email = Convert.ToString(ds.Tables[0].Rows[i]["Email"]);
                            
                            data += "<tr><td> <a href='Visit_Request.aspx?RequestID=" + RequestID + "' style='text-decoration: underline;' > " + RequestID + " </a></td><td>" + Config_Title + "</td><td>" + Name + "</td><td>" + Phone + "</td><td>" + Email + "</td><td>" + InTime + "</td><td>" + OutTime + "</td><td>" + Status + "</td><td>" + Created_By + "</td><td>" + MeetDate + "</td><td>" + RequestDate + "</td></tr>";

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
            catch (Exception ex)
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
                dsReport = ObjUpkeep.Fetch_VMSRequestList(Convert.ToInt32(Session["CompanyID"]), LoggedInUserID, From_Date, To_Date);

                System.Data.DataTable dtChkReport = new System.Data.DataTable();
                dtChkReport = dsReport.Tables[0];

                if (dsReport != null)
                {
                    if (dsReport.Tables.Count > 0)
                    {
                        if (dsReport.Tables[0].Rows.Count > 0)
                        {
                            dtChkReport.Columns["Request_ID"].ColumnName = "Request ID";
                            dtChkReport.Columns["Config_Title"].ColumnName = "Vistor Form Name";
                            dtChkReport.Columns["Created_By"].ColumnName = "Created By";
                            dtChkReport.Columns["Created_Date"].ColumnName = "Created Date";
                            dtChkReport.Columns["CheckIn_Time"].ColumnName = "Check In Time";
                            dtChkReport.Columns["CheckOut_Time"].ColumnName = "Check Out Time";
                            dtChkReport.Columns["Meeting_Time"].ColumnName = "Meeting Time";
                            

                            //dtChkReport.Columns["Name"].ColumnName = "Manager Name";
                            //dtChkReport.Columns.Remove("Password");

                            //////dtCustomer.Columns.Remove("User_ID");
                            dtChkReport.AcceptChanges();

                            System.IO.StringWriter tw = new System.IO.StringWriter();
                            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                            string filename = "Visitors_Report_" + DateTime.Now + ".xls";

                            string HeaderText = "VISITORS REPORT AS ON " + DateTime.Now;

                            Style textStyle = new Style();
                            textStyle.ForeColor = System.Drawing.Color.DarkCyan;
                            hw.EnterStyle(textStyle);

                            hw.Write("<h2><center>" + HeaderText + "</center></h2> </br>");
                            hw.ExitStyle(textStyle);
                            
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


    }
}