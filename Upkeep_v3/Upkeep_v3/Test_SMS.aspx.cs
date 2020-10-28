using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Collections.Specialized;

namespace Upkeep_v3
{
    public partial class Test_SMS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string OnClick_Send_SMS()
        {
            String message = HttpUtility.UrlEncode("This is your message");
            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("http://sms.thebulksms.in/api/mt/SendSMS?route=06&channel=Trans&DCS=0&flashsms=0", new NameValueCollection()
                {
                {"apikey" , "uCxdTlOtJUGOFMN4JJT5cA"},
                {"numbers" , "918898084488"},
                {"message" , message},
                {"sender" , "AlmGrp"}
                });
                string result = System.Text.Encoding.UTF8.GetString(response);
                return result;
               
            }
            
        }

        protected void OnClick_Send_SMS(object sender, EventArgs e)
        {
            OnClick_Send_SMS();
        }
    }
}