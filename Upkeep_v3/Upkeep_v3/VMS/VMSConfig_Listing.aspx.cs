using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using QRCoder;
using System.IO;
using System.Drawing;

namespace Upkeep_v3.VMS
{
    public partial class VMSConfig_Listing : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
        }

        public string fetchVMSConfigListing()
        {
            string data = "";
            string strInitiator = string.Empty;
            try
            {
                strInitiator = Convert.ToString(Session["UserType"]);
                DataSet ds = new DataSet();
                ds = ObjUpkeep.Fetch_VMSConfiguration(Convert.ToInt32(Session["CompanyID"]),"");


                string ServerURL = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "") + System.Configuration.ConfigurationManager.AppSettings["VDName"] + "/";
                //// http://localhost:1302/TESTERS/Default6.aspx

                //string path = HttpContext.Current.Request.Url.AbsolutePath;
                //// /TESTERS/Default6.aspx

                //string SURL = url.Replace(path, "");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {

                            int ConfigID = Convert.ToInt32(ds.Tables[0].Rows[i]["VMS_Config_Id"]);
                            string Visit_Title = Convert.ToString(ds.Tables[0].Rows[i]["Config_Title"]);
                            string URL = ServerURL + Convert.ToString(ds.Tables[0].Rows[i]["ShortURL"]);
                            GenerateQRImage(URL);
                            string Company = Convert.ToString(ds.Tables[0].Rows[i]["Company"]);
                            string Initiator = Convert.ToString(ds.Tables[0].Rows[i]["Initiator"]);
                            string CreatedOn = Convert.ToString(ds.Tables[0].Rows[i]["Created_Date"]);

                            data += "<tr><td>" + Visit_Title + "</td><td>" + Company + "</td><td>" + Initiator + "</td><td>" + CreatedOn + "</td><td><a href='Visit_Configuration.aspx?ConfigID=" + ConfigID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record'> <i class='la la-edit'></i> </a>  <a href='Visit_Configuration.aspx?DelVMSConfigID=" + ConfigID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> <a href='#' class='btn btn-focus m-btn m-btn--icon btn-sm m-btn--icon-only btnModalLink' data-container='body' data-toggle='modal' data-target='#modalLink' data-placement='top' data-url='" + URL + "' title='Link'> 	<i class='fa fa-link'></i> </a> </td></tr>";

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

        public void GenerateQRImage(string URL)
        {
            string code = URL;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            imgBarCode.Height = 300;
            imgBarCode.Width = 300;
            using (Bitmap bitMap = qrCode.GetGraphic(20))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();
                    imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                    imgBarCode.Attributes.Add("id", URL.Substring(URL.Length - 5));
                    imgBarCode.Style.Add("display", "none");
                }
                plBarCode.Controls.Add(imgBarCode);
            }
        }
    }
}