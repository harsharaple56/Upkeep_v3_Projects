using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Cocktail_World.Reports_Excise.Maharashtra
{
    public partial class Cash_Memo : System.Web.UI.Page
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
                Fetch_Report();
                hdn_IsPostBack.Value = "no";
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
            ddlLicense.SelectedIndex = 1;
        }

        private void Fetch_Report()
        {
            int License_ID = Convert.ToInt32(ddlLicense.SelectedValue);
            string From_Date = string.Empty;
            string To_Date = string.Empty;

            if (start_date.Value != "")
            {
                From_Date = Convert.ToString(start_date.Value);
            }
            else
            {
                DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture)).AddDays(-6);
                From_Date = FromDate.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
            }

            if (end_date.Value != "")
            {
                To_Date = Convert.ToString(end_date.Value);
            }
            else
            {
                To_Date = DateTime.Now.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
            }

            DataSet dsReport = new DataSet();
            dsReport = ObjCocktailWorld.Fetch_CashMemo(License_ID,From_Date,To_Date);

            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Cocktail_World/Reports_Excise/Maharashtra/RDLC_Files/Cash_Memo.rdlc");

            ReportDataSource datasource0 = new ReportDataSource("DsCashMemo", dsReport.Tables[0]);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.EnableHyperlinks = true;
            ReportViewer1.LocalReport.DataSources.Add(datasource0);
            ReportViewer1.LocalReport.Refresh();
        }

        protected void generate_ServerClick(object sender, EventArgs e)
        {
            Fetch_Report();
        }

    }
}