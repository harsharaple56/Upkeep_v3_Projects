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

        protected void Page_Load(object sender, EventArgs e)
        {
            div_Maharashtra_Excise.Visible = true;
            
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
                        if (dsReport.Tables[0].Rows.Count > 0)
                        {
                            ReportViewer1.ProcessingMode = ProcessingMode.Local;
                            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Cocktail_World/Reports_Excise/RDLC_Files/Flr3ReportWizard.rdlc");

                            ReportDataSource datasource0 = new ReportDataSource("Flr3DatasetReportWizard", dsReport.Tables[0]);
                            ReportDataSource datasource1 = new ReportDataSource("DataSet1", dsReport.Tables[1]);

                            ReportViewer1.LocalReport.DataSources.Clear();
                            ReportViewer1.LocalReport.EnableHyperlinks = true;
                            ReportViewer1.LocalReport.DataSources.Add(datasource0);
                            ReportViewer1.LocalReport.DataSources.Add(datasource1);
                            ReportViewer1.LocalReport.Refresh();



                        }
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