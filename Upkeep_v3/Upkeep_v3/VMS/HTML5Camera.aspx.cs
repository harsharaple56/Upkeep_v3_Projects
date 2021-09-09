using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing;

namespace Upkeep_v3.VMS
{
    public partial class HTML5Camera : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string Upload(string image, string type)
        {
            try
            {
                string barcodeText = "";
                string barcodePath = HttpContext.Current.Server.MapPath("~/VMS_Uploads/Vacc_User_Certificate/123.png"); 
                var barcodeReader = new BarcodeReader();

                var result = barcodeReader.Decode(new Bitmap(barcodePath));
                if (result != null)
                {
                    barcodeText = result.Text;
                }
                return barcodeText;
            }
            catch (Exception ex)
            {
                // return the exception instead
                return (ex.Message + "rn" + ex.StackTrace);
            }
        }


    }
}