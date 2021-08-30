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

namespace Upkeep_v3.VMS
{
    public partial class Visitor_ID_v2 : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        int Request_ID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Request_ID = Convert.ToInt32(Request.QueryString["Request_ID"]);

            if (IsPostBack)
                return;
            else
            {
                if (Request_ID > 0)
                {
                    div_Visitor_ID.Visible = true;
                    div_No_Visitor_ID.Visible = false;
                    Generate_Report();
                }
                else
                {
                    div_Visitor_ID.Visible = false;
                    div_No_Visitor_ID.Visible = true;
                }
                
            }
        }

        protected void Generate_Report()
        {

            try
            {
                DataSet dsVisitor_ID = new DataSet();
                dsVisitor_ID = ObjUpkeep.VMS_Generate_Visitor_ID(Request_ID);

                if (dsVisitor_ID != null)
                {
                    if (dsVisitor_ID.Tables.Count > 0)
                    {
                        if (dsVisitor_ID.Tables[0].Rows.Count > 0)
                        {
                            rv_Visitor_ID.ProcessingMode = ProcessingMode.Local;

                            rv_Visitor_ID.LocalReport.ReportPath = Server.MapPath("~/VMS/Visitor_ID.rdlc");
                            //rv_Visitor_ID.LocalReport.ReportPath = Server.MapPath("~/Cocktail_World/Reports_Excise/RDLC_Files/Flr3ReportWizard.rdlc");

                            ReportDataSource datasource0 = new ReportDataSource("ds_Visitor_Info_ID", dsVisitor_ID.Tables[0]);


                            rv_Visitor_ID.LocalReport.EnableExternalImages = true;
                            rv_Visitor_ID.LocalReport.DataSources.Clear();
                            rv_Visitor_ID.LocalReport.EnableHyperlinks = true;
                            rv_Visitor_ID.LocalReport.DataSources.Add(datasource0);
                            //rv_Visitor_ID.LocalReport.Refresh();



                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void Download_Visitor_ID(object sender, EventArgs e)
        {

            try
            {
                DataSet dsVisitor_ID = new DataSet();
                dsVisitor_ID = ObjUpkeep.VMS_Generate_Visitor_ID(Request_ID);

                if (dsVisitor_ID != null)
                {
                    if (dsVisitor_ID.Tables.Count > 0)
                    {
                        if (dsVisitor_ID.Tables[0].Rows.Count > 0)
                        {
                            rv_Visitor_ID.ProcessingMode = ProcessingMode.Local;

                            rv_Visitor_ID.LocalReport.ReportPath = Server.MapPath("~/VMS/Visitor_ID.rdlc");
                            //rv_Visitor_ID.LocalReport.ReportPath = Server.MapPath("~/Cocktail_World/Reports_Excise/RDLC_Files/Flr3ReportWizard.rdlc");

                            ReportDataSource datasource0 = new ReportDataSource("ds_Visitor_Info_ID", dsVisitor_ID.Tables[0]);


                            rv_Visitor_ID.LocalReport.EnableExternalImages = true;
                            rv_Visitor_ID.LocalReport.DataSources.Clear();
                            rv_Visitor_ID.LocalReport.EnableHyperlinks = true;
                            rv_Visitor_ID.LocalReport.DataSources.Add(datasource0);
                            //rv_Visitor_ID.LocalReport.Refresh();

                            rv_Visitor_ID.LocalReport.Refresh();

                            string filename = "Visitor_ID_" + DateTime.Now;

                            string deviceInfo = "<DeviceInfo>" +
                                "  <OutputFormat>PDF</OutputFormat>" +
                                //"  <PageWidth>8.27in</PageWidth>" +
                                //"  <PageHeight>11.69in</PageHeight>" +
                                //"  <MarginTop>0.25in</MarginTop>" +
                                //"  <MarginLeft>0.4in</MarginLeft>" +
                                //"  <MarginRight>0in</MarginRight>" +
                                //"  <MarginBottom>0.25in</MarginBottom>" +
                                "  <EmbedFonts>None</EmbedFonts>" +
                                "</DeviceInfo>";

                            Warning[] warnings;
                            string[] streamIds;
                            string mimeType = string.Empty;
                            string encoding = string.Empty;
                            string extension = string.Empty;
                            byte[] bytes = rv_Visitor_ID.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding, out extension, out streamIds, out warnings);

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

    }
}