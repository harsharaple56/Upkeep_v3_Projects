using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.CheckList
{
    public partial class Checklist_Consolidated_Report : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        DataSet dsGlobalDataS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }

            if (!IsPostBack)
            {
                int Chk_Config_ID = 0;
                if (Request.QueryString["Chk_Config_ID"] != null)
                {                   
                    Chk_Config_ID = Convert.ToInt32(Request.QueryString["Chk_Config_ID"]);
                    Session["Chk_Config_ID"] = Chk_Config_ID;
                }

                Fetch_Checklist_Consolidated_Report(Chk_Config_ID);
            }
        }

        public void Fetch_Checklist_Consolidated_Report(int Chk_Config_ID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = ObjUpkeep.Fetch_Checklist_Consolidated_Report(Chk_Config_ID, LoggedInUserID);

                if (ds.Tables[0].Rows.Count > 0)
                {
                   
                    lblChecklistName.Text = ds.Tables[0].Rows[0]["ChecklistName"].ToString();
                    lblChecklistDesc.Text = ds.Tables[0].Rows[0]["ChecklistDesc"].ToString();

                    lblDepartment.Text = ds.Tables[0].Rows[0]["Department"].ToString();
                    lblGeneratedBy.Text = ds.Tables[0].Rows[0]["Generated_By"].ToString();
                   
                    //lblProgress.Text = ds.Tables[0].Rows[0]["PercentCompleted"].ToString();
                }


                if (ds.Tables[1].Rows.Count > 0)
                {
                    gvChecklistReport.DataSource = ds.Tables[1];
                    gvChecklistReport.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            GridView dgGrid = new GridView();
            DataSet dsExport = new DataSet();
            try
            {
                int Chk_Config_ID = 0;
                Chk_Config_ID = Convert.ToInt32(Session["Chk_Config_ID"]);

                dsExport = ObjUpkeep.Fetch_Checklist_Consolidated_Report(Chk_Config_ID, LoggedInUserID);

                System.Data.DataTable dtChecklistReport = new System.Data.DataTable();

                if (dsExport.Tables.Count > 0)
                {
                    if (dsExport.Tables[0].Rows.Count > 0)
                    {
                        dtChecklistReport = dsExport.Tables[1];

                        //dtGatepassReport.Columns.Remove("GP_Trans_ID");
                        //dtGatepassReport.Columns.Remove("Gp_Config_ID");
                        //dtGatepassReport.AcceptChanges();

                        dgGrid.DataSource = dtChecklistReport;
                        dgGrid.DataBind();

                        System.IO.StringWriter tw = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                        string Department = string.Empty;
                        string Checklist_Title = string.Empty;
                        string GeneratedBy = string.Empty;
                        
                        Department = Convert.ToString(dsExport.Tables[0].Rows[0]["Department"]);
                        Checklist_Title = Convert.ToString(dsExport.Tables[0].Rows[0]["ChecklistName"]);

                        //lblDepartment.Text = ds.Tables[0].Rows[0]["Department"].ToString();
                        GeneratedBy = Convert.ToString(dsExport.Tables[0].Rows[0]["Generated_By"]);

                        string filename = "Checklist_Consolidated_Report.xls";

                        string HeaderText = "CHECKLIST CONSOLIDATED REPORT FOR - "+ Checklist_Title;

                        Style textStyle = new Style();
                        textStyle.ForeColor = System.Drawing.Color.DarkCyan;
                        hw.EnterStyle(textStyle);

                        hw.Write("<h2>" + HeaderText + "</h2> </br>");
                        hw.Write("<h3> Department Name : " + Department + "</h3> </br>");
                        hw.Write("<h3> Generated By : " + GeneratedBy + "</h3> </br>");
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