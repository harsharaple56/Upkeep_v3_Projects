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
using QRCoder;
using System.Drawing;

namespace Upkeep_v3.VMS
{
    public partial class Visitor_ID_V3 : System.Web.UI.Page
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
                    Generate_Visitor_ID();
                    Generate_QR_Code();
                }
                else
                {
                    div_Visitor_ID.Visible = false;
                    div_No_Visitor_ID.Visible = true;
                }

            }
        }

        protected void Generate_Visitor_ID()
        {
            string Visit_Request_Code = string.Empty;

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
                            Img_CompanyLogo.ImageUrl = Convert.ToString(dsVisitor_ID.Tables[0].Rows[0]["Company_Logo"]);
                            Img_Visitor_Photo.ImageUrl = Convert.ToString(dsVisitor_ID.Tables[0].Rows[0]["Visitor_Photo"]);
                            lbl_Visitor_Name.InnerText = Convert.ToString(dsVisitor_ID.Tables[0].Rows[0]["Visitor_Name"]);
                            lbl_Visitor_Email.InnerText = Convert.ToString(dsVisitor_ID.Tables[0].Rows[0]["Visitor_Email"]);
                            lbl_Visitor_Contact.InnerText = Convert.ToString(dsVisitor_ID.Tables[0].Rows[0]["Visitor_Contact"]);
                            lbl_VisitRequest_ID.InnerText = Convert.ToString(dsVisitor_ID.Tables[0].Rows[0]["Visit_Request_ID"]);
                            lbl_Vacc_Date.InnerText = Convert.ToString(dsVisitor_ID.Tables[0].Rows[0]["Vaccination_Date"]);
                            lbl_Request_Date_Text.InnerText = Convert.ToString(dsVisitor_ID.Tables[0].Rows[0]["Visit_Request_Date"]);
                            lbl_Visit_Date_Text.InnerText = Convert.ToString(dsVisitor_ID.Tables[0].Rows[0]["Visit_Date_Text"]);
                            Visit_Request_Code = Convert.ToString(dsVisitor_ID.Tables[0].Rows[0]["Visit_Request_Code"]);

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


                            //Convert Base64 Encoded string to Byte Array.
                            string imageBase64 = string.Empty;
                            imageBase64 = Convert.ToString(Session["QR_Byte_Array"]);

                            byte[] imageBytes = Convert.FromBase64String(imageBase64);

                            string VDName = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadURL"]);
                            string SaveLocation = Server.MapPath("~/VMS/QR_Codes/VMS_") + Convert.ToString(Request_ID) + ".png";

                            string imgPath = VDName + "/VMS/QR_Codes/VMS_" + Convert.ToString(Request_ID) + ".png";

                            //Save the Byte Array as Image File.
                            File.WriteAllBytes(SaveLocation, imageBytes);

                            //Session["QR_Code_Path"] = imgPath;


                            DataTable dtQRCodeImage = new DataTable();
                            dtQRCodeImage.Clear();
                            dtQRCodeImage.Columns.Add("QR_Code_Path");
                            //string QRImage = Convert.ToString(Session["QR_Code_Path"]);
                            dtQRCodeImage.Rows.Add(new object[] { imgPath });

                            ReportDataSource datasource0 = new ReportDataSource("ds_Visitor_Info_ID", dsVisitor_ID.Tables[0]);
                            ReportDataSource datasource1 = new ReportDataSource("ds_QR_Image", dtQRCodeImage);

                            rv_Visitor_ID.LocalReport.EnableExternalImages = true;
                            rv_Visitor_ID.LocalReport.DataSources.Clear();
                            rv_Visitor_ID.LocalReport.EnableHyperlinks = true;
                            rv_Visitor_ID.LocalReport.DataSources.Add(datasource0);
                            rv_Visitor_ID.LocalReport.DataSources.Add(datasource1);
                            rv_Visitor_ID.LocalReport.Refresh();

                            string filename = "Visitor_ID_" + dsVisitor_ID.Tables[0].Rows[0]["Visit_Request_ID"].ToString() + "_" + DateTime.Now;

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

        protected void Generate_QR_Code()
        {
            string code = string.Empty;
            DataSet dsVisitor_ID = new DataSet();
            string imageBase64 = string.Empty;
            try
            {
                dsVisitor_ID = ObjUpkeep.VMS_Generate_Visitor_ID(Request_ID);

                if (dsVisitor_ID != null)
                {
                    if (dsVisitor_ID.Tables.Count > 0)
                    {
                        if (dsVisitor_ID.Tables[0].Rows.Count > 0)
                        {
                            code = Convert.ToString(dsVisitor_ID.Tables[0].Rows[0]["Visit_Request_Code"]);
                            QRCodeGenerator qrGenerator = new QRCodeGenerator();
                            QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                            imgBarCode.Height = 200;
                            imgBarCode.Width = 200;
                            using (Bitmap bitMap = qrCode.GetGraphic(20))
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    byte[] byteImage = ms.ToArray();
                                    Img_QR_Code.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                    imageBase64 = Convert.ToBase64String(byteImage);

                                    Session["QR_Byte_Array"] = imageBase64;


                                }
                            }
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