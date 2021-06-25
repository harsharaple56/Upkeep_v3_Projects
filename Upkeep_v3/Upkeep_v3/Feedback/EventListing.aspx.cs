using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using QRCoder;
using System.Reflection;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Drawing;

namespace Upkeep_v3.Feedback
{
    public partial class EventListing : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeepFeedback = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            // frmMain.Action = @"EventListing.aspx"; //commented by suju removed form type 
            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                //Response.Redirect("~/Login.aspx", false);
            }
        }

        public string fetchEventListing()
        {
            string data = "";
            try
            {
                DataSet ds = new DataSet();
                ds = ObjUpkeepFeedback.EventDetails_CRUD(0, CompanyID, "Select");

                string ServerURL = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "") + System.Configuration.ConfigurationManager.AppSettings["VDName"] + "/";

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int EventID = Convert.ToInt32(ds.Tables[0].Rows[i]["Event_ID"]);
                            string EventName = Convert.ToString(ds.Tables[0].Rows[i]["Event_Name"]);
                            string Location = Convert.ToString(ds.Tables[0].Rows[i]["Location"]);
                            string EventFor = Convert.ToString(ds.Tables[0].Rows[i]["EventFor"]);
                            string CreatedOn = Convert.ToString(ds.Tables[0].Rows[i]["Created_Date"]);
                            string StartDate = Convert.ToString(ds.Tables[0].Rows[i]["Start_Date"]);
                            string EndDate = Convert.ToString(ds.Tables[0].Rows[i]["Expiry_Date"]);
                            string URL = ServerURL + Convert.ToString(ds.Tables[0].Rows[i]["ShortURL"]);
                            GenerateQRImage(URL);

                            data += "<tr><td>" + EventName + "</td><td>" + Location + "</td><td>" + EventFor + "</td><td>" + CreatedOn + "</td><td>" + StartDate + "</td> <td>" + EndDate + "</td> <td><a href='EditEvent.aspx?EventID=" + EventID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record'> <i class='la la-edit'></i> </a> <a href='EventQuestions.aspx?EventID=" + EventID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='View question list'><i class='la la-th-list'></i></a> <a href='EditEvent.aspx?DelEventID=" + EventID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> <a href='#' class='btn btn-focus m-btn m-btn--icon btn-sm m-btn--icon-only btnModalLink' data-container='body' data-toggle='modal' data-target='#modalLink' data-placement='top'  data-url='" + URL + "' title='Link'> 	<i class='la la-qrcode' style='font-size: 2.1rem;' ></i> </a>    </td></tr>";

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