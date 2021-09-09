using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing;

namespace Upkeep_v3.VMS
{
    public partial class Verify_Visitor_ID_V2 : System.Web.UI.Page
    {
        private static Random random = new Random();
        string LoggedInUserID = string.Empty;
        string SessionVisitor = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private static int RandomNumber()
        {
            return random.Next(0, 99);
        }

        private static string RandomString()
        {
            int length = 3;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [WebMethod]
        public static string Upload(string image, string type)
        {
            try
            {
                string barcodeText = "";
                string FilePathToGet = string.Empty;
                string FilePathToDelete = string.Empty;
                string UserImage_fileName = string.Empty;
                string UserImage_fileExtension = string.Empty;
                string UserImage_filePath = string.Empty;
                if (!string.IsNullOrEmpty(image))
                {
                    UserImage_fileName = RandomNumber() + '_' + RandomString() + '_' + DateTime.Now.ToString("dd-MMM-yyyy");

                    //Convert Base64 Encoded string to Byte Array.
                    byte[] UserImage_imageBytes = Convert.FromBase64String(image.Split(',')[1]);

                    //Save the Byte Array as Image File.
                    UserImage_filePath = HttpContext.Current.Server.MapPath(string.Format("~/VMS_Uploads/Vacc_User_Photo/{0}.jpg", UserImage_fileName));

                    UserImage_fileExtension = Path.GetExtension(UserImage_filePath);

                    FilePathToGet = "/VMS_Uploads/Vacc_User_Photo/" + UserImage_fileName + UserImage_fileExtension;
                    FilePathToDelete = "/VMS_Uploads/Vacc_User_Photo/";
                    File.WriteAllBytes(UserImage_filePath, UserImage_imageBytes);
                }
                string barcodePath = HttpContext.Current.Server.MapPath(FilePathToGet);
                var barcodeReader = new BarcodeReader();

                var result = barcodeReader.Decode(new Bitmap(barcodePath));
                if (result != null)
                {
                    barcodeText = result.Text;
                }

                if (File.Exists(Path.Combine(barcodePath)))
                {
                    // File.Delete(UserImage_filePath);
                }

                //Get User Data from Database
                if (!string.IsNullOrEmpty(barcodeText))
                {
                    string Visit_Request_Code = barcodeText;
                    string Visitor_Name = string.Empty; ;
                    string Visitor_Email = string.Empty; ;
                    string Visitor_Contact = string.Empty;
                    string Visitor_Request_ID = string.Empty;

                    #region Fetch Data From [Spr_VMS_Verify_Visitor_ID] using barcode
                    Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
                    DataSet dsVCOde = new DataSet();
                    dsVCOde = ObjUpkeep.Get_VMS_Verify_Visitor_ID(Visit_Request_Code);
                    if (dsVCOde.Tables[0].Rows.Count > 0)
                    {
                        Visitor_Name = dsVCOde.Tables[0].Rows[1]["Visitor_Name"].ToString();
                        Visitor_Email = dsVCOde.Tables[0].Rows[1]["Visitor_Email"].ToString();
                        Visitor_Request_ID = dsVCOde.Tables[0].Rows[1]["Visit_Request_ID"].ToString();
                        Visitor_Contact = dsVCOde.Tables[0].Rows[1]["Visitor_Contact"].ToString();

                        string csvString = string.Join(",", Visitor_Name, Visitor_Email, Visitor_Request_ID, Visitor_Contact);
                        return csvString.ToString();
                    }
                    #endregion
                }

                return barcodeText;
            }
            catch (Exception ex)
            {
                return (ex.Message + "rn" + ex.StackTrace);
            }
        }


    }
}