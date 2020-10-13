﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Text;
using System.IO;
using System.Globalization;

namespace Upkeep_v3.Ticketing
{
    public partial class Ticket_CTT_Report : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }

            if (!IsPostBack)
            {
                Fetch_CTT_Report();
            }
        }

        public void Fetch_CTT_Report()
        {
            DataSet dsCTT = new DataSet();
            try
            {
                dsCTT = ObjUpkeep.Fetch_CTT_Report(CompanyID);

                if (dsCTT.Tables.Count > 0)
                {
                    if (dsCTT.Tables[0].Rows.Count > 0)
                    {
                        gvCTT_Report.DataSource = dsCTT;
                        gvCTT_Report.DataBind();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvCTT_Report_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //check if the row is the header row
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //add the thead and tbody section programatically
                e.Row.TableSection = TableRowSection.TableHeader;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Get the cell content
                //Change the cell index as per your gridview
                string ReqStatus = e.Row.Cells[5].Text;
                string ActionStatus = e.Row.Cells[6].Text;
                string ReqStatusClass = string.Empty;
                string ActionStatusClass = string.Empty;

                switch (ReqStatus)
                {
                    case "Open":
                        ReqStatusClass = "danger";
                        break;
                    case "Closed":
                        ReqStatusClass = "success";
                        break;
                    case "Expired":
                        ReqStatusClass = "secondary";
                        break;
                    default:
                        ReqStatusClass = "secondary";
                        break;
                }

                switch (ActionStatus)
                {
                    case "Assigned":
                        ActionStatusClass = "info";
                        break;
                    case "Accepted":
                        ActionStatusClass = "success";
                        break;
                    case "Expired":
                        ActionStatusClass = "secondary";
                        break;
                    case "In Progress":
                        ActionStatusClass = "accent";
                        break;
                    case "Closed":
                        ActionStatusClass = "success";
                        break;
                    default:
                        ReqStatusClass = "secondary";
                        break;
                }

                e.Row.Cells[5].Text = "<span style='width: 113px;'><span class='m-badge m-badge--" + ReqStatusClass + " m-badge--wide'>" + ReqStatus + "</span></span>";
                e.Row.Cells[6].Text = "<span style='width: 113px;'><span class='m-badge m-badge--" + ActionStatusClass + " m-badge--dot'></span>&nbsp;" +
                    "<span class='m--font-bold m--font-" + ActionStatusClass + "'>"+ActionStatus+"</span></span>";

            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            GridView dgGrid = new GridView();
            DataSet dsExport = new DataSet();
            string currentDate = string.Empty;
            try
            {
                dsExport = ObjUpkeep.Fetch_CTT_Report(CompanyID);

                System.Data.DataTable dtCTTReport = new System.Data.DataTable();

                if (dsExport.Tables.Count > 0)
                {
                    if (dsExport.Tables[0].Rows.Count > 0)
                    {
                        dtCTTReport = dsExport.Tables[0];

                        dtCTTReport.Columns.Remove("Ticket_ID");
                        dtCTTReport.Columns["Tkt_Code"].ColumnName = "Ticket No";
                        dtCTTReport.Columns["RequestStatus"].ColumnName = "Request Status";
                        dtCTTReport.Columns["ActionStatus"].ColumnName = "Action Status";
                        dtCTTReport.Columns["Ticket_Date"].ColumnName = "Ticket Date";
                        dtCTTReport.Columns["Category_Desc"].ColumnName = "Category";
                        dtCTTReport.Columns["SubCategory_Desc"].ColumnName = "SubCategory";
                        dtCTTReport.Columns["Dept_Desc"].ColumnName = "Department";
                        dtCTTReport.Columns["Down_Time"].ColumnName = "Down Time";
                        dtCTTReport.AcceptChanges();

                        dgGrid.DataSource = dtCTTReport;
                        dgGrid.DataBind();

                        currentDate =DateTime.Now.ToString();

                        System.IO.StringWriter tw = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                        string filename = "TICKET CTT REPORT AS ON " + currentDate + ".xls";

                        string HeaderText = "TICKET CTT REPORT AS ON " + currentDate ;

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

        protected void gvCTT_Report_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewTicket")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = gvCTT_Report.Rows[rowIndex];

                string TicketID = ((HiddenField)row.FindControl("hdnTicketID")).Value;

                string Downtime = gvCTT_Report.Rows[rowIndex].Cells[7].Text;
                Session["Downtime"] = Downtime;

                Response.Redirect(Page.ResolveClientUrl("~/Ticketing/View_Ticket_Details.aspx?TicketID=" + TicketID), false);
            }
        }
    }
}