using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace eFacilito_MobileApp_WebAPI.Models
{
    public class SendSMS
    {
        public string Send_SMS(string APIKey, string SenderID, string Send_SMS_URL, string MobileNo, string TextMessage)
        {
            try
            {
                string sResponse = "";
                string sURL = "";

                //sURL = "http://yourdomain.com/api/mt/SendSMS?APIKEY=" + sAPIKey + "&senderid=" + sSenderID + "&channel=" + sChannel + "&DCS=0&flashsms=0&number=" + sNumber + "&text=" + sMessage + "& route = " + sRoute;
                //sURL = "http://sms.thebulksms.in/api/mt/SendSMS?route=06&channel=Trans&DCS=0&flashsms=0" + "&APIKEY=" + sAPIKey + "&senderid=" + sSenderID + "&number=" + sNumber + "&text=" + sMessage;

                sURL = Send_SMS_URL + "&APIKEY=" + APIKey + "&senderid=" + SenderID + "&number=" + MobileNo + "&text=" + TextMessage;

                sResponse = GetJSONResponse(sURL);

                Send_SMS_API sms = JsonConvert.DeserializeObject<Send_SMS_API>(sResponse);

                if (sms.ErrorCode == "000")
                {
                    return "success";
                }
                else
                {
                    return "failure";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetJSONResponse(string sURL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
            request.MaximumAutomaticRedirections = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            request.ContentType = "application/json; charset=utf-8";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream receiveStream = response.GetResponseStream(
                );
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string sResponse = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                return sResponse;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

    }

    public class Send_SMS_API
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }

}