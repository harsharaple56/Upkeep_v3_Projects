using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace Upkeep_v3.SMS
{
    public class Send_eFacilito_SMS
    {

        public string Send_SMS(string Send_SMS_URL, string User_ID, string Password, string MobileNo, string TextMessage, string TemplateID)
        {
            string message = "";
            try
            {
                HttpClient client = new HttpClient();
                string sURL = "";
                
                sURL = Send_SMS_URL + "&ID=" + User_ID + "&Pwd=" + Password + "&PhNo=" + MobileNo + "&Text=" + TextMessage + "&TemplateID=" + TemplateID;
                
                HttpResponseMessage response = client.GetAsync(sURL).Result;
                
               if (response.RequestMessage.Equals("Message Submitted"))
                {
                    message = "success";
                    return message;

                }
               else if(response.RequestMessage.Equals("Authentication Failed."))
                {
                    message = "failure";
                    return message;
                }
                else if (response.RequestMessage.Equals("Your Account is not active"))
                {
                    message = "account_deactivated";
                    return message;
                }
                else if (response.RequestMessage.Equals("Insufficient Credit.’ "))
                {
                    message = "no_sms_Balance";
                    return message;
                }

                return message;
            }
            

            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}