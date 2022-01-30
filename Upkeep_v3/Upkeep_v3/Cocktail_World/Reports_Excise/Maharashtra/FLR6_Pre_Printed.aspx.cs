using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Cocktail_World.Reports_Excise.Maharashtra
{
    public partial class FLR6_Pre_Printed : System.Web.UI.Page
    {
        CocktailWorld_Service.CocktailWorld_Service ObjCocktailWorld = new CocktailWorld_Service.CocktailWorld_Service();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            hdn_IsPostBack.Value = "yes";
            if (!IsPostBack)
            {
                Fetch_License();
                hdn_IsPostBack.Value = "no";
                DataSet dsReport = new DataSet();
                dsReport = ObjCocktailWorld.Fetch_Flr6Data();

                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Cocktail_World/Reports_Excise/RDLC_Files/FLR6_Pre_Printed.rdlc");

                ReportDataSource datasource0 = new ReportDataSource("DataSet1", dsReport.Tables[0]);
                ReportDataSource datasource1 = new ReportDataSource("Flr6BriefDataset", dsReport.Tables[1]);
                ReportDataSource datasource2 = new ReportDataSource("Flr6TotalDataset", dsReport.Tables[1]);

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.EnableHyperlinks = true;
                ReportViewer1.LocalReport.DataSources.Add(datasource0);
                ReportViewer1.LocalReport.DataSources.Add(datasource1);
                ReportViewer1.LocalReport.DataSources.Add(datasource2);
                ReportViewer1.LocalReport.Refresh();
            }
        }

        private void Fetch_License()
        {
            DataSet ds = new DataSet();
            ds = ObjCocktailWorld.License_CRUD(0, string.Empty, string.Empty, LoggedInUserID, CompanyID, "R");
            ddlLicense.DataSource = ds.Tables[0];
            ddlLicense.DataTextField = "License_Name";
            ddlLicense.DataValueField = "License_ID";
            ddlLicense.DataBind();
            ddlLicense.Items.Insert(0, new ListItem("--Select License--", "0"));
        }
    }
}