using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

namespace Upkeep_v3.GatePass
{
    public partial class GatePass_Report : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();

        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["LoggedInUserID"] = "111";
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
                //LoggedInUserID = "3";
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
            fetchGPRequestListing();
        }

        public string fetchGPRequestListing()
        {
            string data = "";
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
                    DateTime FrsmDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yy", CultureInfo.InvariantCulture)).AddDays(-5);
                    From_Date = FrsmDate.ToString("dd/MMM/yy", CultureInfo.InvariantCulture);
                }

                if (end_date.Value != "")
                {
                    To_Date = Convert.ToString(end_date.Value);
                }
                else
                {
                    DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yy", CultureInfo.InvariantCulture)).AddDays(25);
                    To_Date = FromDate.ToString("dd/MMM/yy", CultureInfo.InvariantCulture);
                }



                DataSet ds = new DataSet();
                ds = ObjUpkeep.Fetch_GatePass_MIS(CompanyID,LoggedInUserID, From_Date, To_Date);
                //  ds = ObjUpkeep.Fetch_MyRequestGatePass(LoggedInUserID, From_Date, To_Date);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            string SrNO = Convert.ToString(ds.Tables[0].Rows[i]["SrNo"]);
                            string TransactionID = Convert.ToString(ds.Tables[0].Rows[i]["GP_Trans_ID"]);
                            string TicketNo = Convert.ToString(ds.Tables[0].Rows[i]["TicketNo"]);
                            string GatePass_Title = Convert.ToString(ds.Tables[0].Rows[i]["GP_Title"]);
                            string Department = Convert.ToString(ds.Tables[0].Rows[i]["DepartmentName"]);
                            string GP_Type = Convert.ToString(ds.Tables[0].Rows[i]["GP_Type_Desc"]);
                            string GatePassDate = Convert.ToString(ds.Tables[0].Rows[i]["GatePassDate"]);
                            string RequestDate = Convert.ToString(ds.Tables[0].Rows[i]["RequestDate"]);
                            string Status = Convert.ToString(ds.Tables[0].Rows[i]["GP_Status"]);
                            string Created_By = Convert.ToString(ds.Tables[0].Rows[i]["Created_By"]);
                            string Store = Convert.ToString(ds.Tables[0].Rows[i]["Store"]);

                            data += "<tr><td> <a href='..\\Gatepass\\GatePass_Approval.aspx?TransactionID=" + TransactionID + "' style='text-decoration: underline;' > " + TicketNo + " </a></td><td>" + GatePass_Title + "</td><td>" + Department + "</td><td>" + GP_Type + "</td><td>" + GatePassDate + "</td><td>" + RequestDate + "</td><td>" + Status + "</td><td>" + Created_By + "</td><td>" + Store + "</td></tr>";

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

        protected void btnExport_Click(object sender, EventArgs e)
        {
            GridView dgGrid = new GridView();
            string From_Date = string.Empty;
            string To_Date = string.Empty;
            DataSet dsExport = new DataSet();
            try
            {
                if (start_date.Value != "")
                {
                    From_Date = Convert.ToString(start_date.Value);
                }
                else
                {
                    DateTime FrsmDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yy", CultureInfo.InvariantCulture)).AddDays(-5);
                    From_Date = FrsmDate.ToString("dd/MMM/yy", CultureInfo.InvariantCulture);
                }

                if (end_date.Value != "")
                {
                    To_Date = Convert.ToString(end_date.Value);
                }
                else
                {
                    DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yy", CultureInfo.InvariantCulture)).AddDays(25);
                    To_Date = FromDate.ToString("dd/MMM/yy", CultureInfo.InvariantCulture);
                }

                dsExport = ObjUpkeep.Fetch_GatePass_MIS(CompanyID, LoggedInUserID, From_Date, To_Date);

                System.Data.DataTable dtGatepassReport = new System.Data.DataTable();

                if (dsExport.Tables.Count > 0)
                {
                    if (dsExport.Tables[0].Rows.Count > 0)
                    {
                        dtGatepassReport = dsExport.Tables[0];

                        dtGatepassReport.Columns.Remove("GP_Trans_ID");
                        dtGatepassReport.Columns.Remove("Gp_Config_ID");
                        dtGatepassReport.AcceptChanges();

                        dgGrid.DataSource = dtGatepassReport;
                        dgGrid.DataBind();

                        System.IO.StringWriter tw = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                        string filename = "GATEPASS REPORT FOR " + From_Date + " to " + To_Date + ".xls";

                        string HeaderText = "GATEPASS REPORT FOR " + From_Date + " to " + To_Date;

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
    }
}