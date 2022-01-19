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
using System.Web.Script.Serialization;
using Microsoft.Reporting.WebForms;

namespace Upkeep_v3.Cocktail_World.Reports_Excise
{
    public partial class Generate_Reports : System.Web.UI.Page
    {
        CocktailWorld_Service.CocktailWorld_Service ObjCocktailWorld = new CocktailWorld_Service.CocktailWorld_Service();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            if (!IsPostBack)
            {
                div_Maharashtra_Excise.Visible = true;
                Fetch_License();

                //ReportViewer1.Visible = true;
                //ReportViewer1.ProcessingMode = ProcessingMode.Local;
                //ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Cocktail_World/Reports_Excise/RDLC_Files/Flr3ReportWizard.rdlc");
                DataSet dsReport = new DataSet();
                dsReport = ObjCocktailWorld.Fetch_Test_Dataset_RDLC();
                //if (dsReport.Tables[0].Rows.Count > 0)
                //{
                //    ReportDataSource rds = new ReportDataSource("bramandamDataSet", dsReport.Tables[0]);
                //    ReportViewer1.LocalReport.DataSources.Clear();
                //    ReportViewer1.LocalReport.DataSources.Add(rds);
                //}   

                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dsReport.Tables[0]));
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Cocktail_World/Reports_Excise/RDLC_Files/Report1.rdlc");
                ReportViewer1.LocalReport.EnableHyperlinks = true;

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

        protected void btn_GenerateReport1_ServerClick2(object sender, EventArgs e)
        {

            try
            {
                DataSet dsReport = new DataSet();
                dsReport = ObjCocktailWorld.Fetch_Test_Dataset_RDLC();


                if (dsReport != null)
                {
                    if (dsReport.Tables.Count > 0)
                    {
                        //if (dsReport.Tables[0].Rows.Count > 0)
                        //{
                        //    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                        //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Cocktail_World/Reports_Excise/RDLC_Files/Flr3ReportWizard.rdlc");

                        //    ReportDataSource datasource0 = new ReportDataSource("Flr3DatasetReportWizard", dsReport.Tables[0]);
                        //    ReportDataSource datasource1 = new ReportDataSource("DataSet1", dsReport.Tables[1]);

                        //    ReportViewer1.LocalReport.DataSources.Clear();
                        //    ReportViewer1.LocalReport.EnableHyperlinks = true;
                        //    ReportViewer1.LocalReport.DataSources.Add(datasource0);
                        //    ReportViewer1.LocalReport.DataSources.Add(datasource1);
                        //    ReportViewer1.LocalReport.Refresh();

                        //}

                        ReportDataSource datasource = new ReportDataSource("Customers", dsReport.Tables[0]);
                        this.ReportViewer1.LocalReport.DataSources.Clear();
                        this.ReportViewer1.LocalReport.DataSources.Add(datasource);
                        this.ReportViewer1.LocalReport.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btn_GenerateReport1_ServerClick3(object sender, EventArgs e)
        {

            try
            {
                DataSet dsReport = new DataSet();
                dsReport = ObjCocktailWorld.Fetch_Test_Dataset_RDLC();

                if (dsReport != null)
                {
                    if (dsReport.Tables.Count > 0)
                    {
                        if (dsReport.Tables[0].Rows.Count > 0)
                        {
                            ReportViewer2.ProcessingMode = ProcessingMode.Local;
                            ReportViewer2.LocalReport.ReportPath = Server.MapPath("~/Cocktail_World/Reports_Excise/RDLC_Files/Flr3ReportWizard.rdlc");

                            ReportDataSource datasource0 = new ReportDataSource("Flr3DatasetReportWizard", dsReport.Tables[0]);
                            ReportDataSource datasource1 = new ReportDataSource("DataSet1", dsReport.Tables[1]);

                            ReportViewer2.LocalReport.DataSources.Clear();
                            ReportViewer2.LocalReport.EnableHyperlinks = true;
                            ReportViewer2.LocalReport.DataSources.Add(datasource0);
                            ReportViewer2.LocalReport.DataSources.Add(datasource1);
                            ReportViewer2.LocalReport.Refresh();



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