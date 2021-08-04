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

        protected void btn_GenerateReport1_ServerClick(object sender, EventArgs e)
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
                            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Cocktail_World/Reports_Excise/RDLC_Files/Flr3PrePrintedReport.rdlc");

                            ReportDataSource datasource0 = new ReportDataSource("Flr3ReportTotal", dsReport.Tables[0]);
                            ReportDataSource datasource1 = new ReportDataSource("Flr3Reportdata", dsReport.Tables[1]);
                            ReportDataSource datasource2 = new ReportDataSource("DtAbstract", dsReport.Tables[2]);


                            ReportViewer1.LocalReport.DataSources.Clear();
                            ReportViewer1.LocalReport.EnableHyperlinks = true;
                            ReportViewer1.LocalReport.DataSources.Add(datasource0);
                            ReportViewer1.LocalReport.DataSources.Add(datasource1);
                            ReportViewer1.LocalReport.Refresh();

                            string filename = "FL3_Report_" + DateTime.Now;

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
                            //byte[] bytes = ReportViewer1.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding, out extension, out streamIds, out warnings);

                            Response.Buffer = true;
                            Response.Clear();
                            Response.ContentType = mimeType;
                            Response.AddHeader("content-disposition", "attachment; filename=" + filename + "." + extension);
                            //Response.BinaryWrite(bytes);
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
                            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Cocktail_World/Reports_Excise/RDLC_Files/Flr3PrePrintedReport.rdlc");

                            ReportDataSource datasource0 = new ReportDataSource("Flr3ReportTotal", dsReport.Tables[0]);
                            ReportDataSource datasource1 = new ReportDataSource("Flr3Reportdata", dsReport.Tables[1]);
                            ReportDataSource datasource2 = new ReportDataSource("DtAbstract", dsReport.Tables[2]);


                            ReportViewer1.LocalReport.DataSources.Clear();

                            ReportViewer1.LocalReport.DataSources.Add(datasource0);
                            ReportViewer1.LocalReport.DataSources.Add(datasource1);
                            ReportViewer1.LocalReport.DataSources.Add(datasource2);

                            
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