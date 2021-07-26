using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using eFacilito_MobileApp_WebAPI.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace eFacilito_MobileApp_WebAPI.Controllers
{
    public class SendEmail_Controller : ApiController
    {

        [Route("api/Send_Email")]
        [HttpGet]
        public HttpResponseMessage Send_Email(string To_Emails, string Subject, string Html_Body)
        {
            string email_response = string.Empty;
            
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                var baseAddress = "https://api.zeptomail.in/v1.1/email";

                var http = (HttpWebRequest)WebRequest.Create(new Uri(baseAddress));
                http.Accept = "application/json";
                http.ContentType = "application/json";
                http.Method = "POST";
                http.PreAuthenticate = true;
                http.Headers.Add("Authorization", "Zoho-enczapikey PHtE6r1bR+3p2mZ6pxFVsP+5H5KiYIIrqO1nKlFE4d1HXvFSHk1V+ox/kGWxrEosUvFDFPSTzoJh57PN4r6DIzrrZzsaVWqyqK3sx/VYSPOZsbq6x00VslsdcEHbUobsc99i3SXXudfSNA==");
                JObject parsedContent = JObject.Parse("{'bounce_address':'system@bounce.efacilito.com','from': { 'address': 'admin@efacilito.com'},'to': [{'email_address': {'address': '" + To_Emails + "','name': 'eFacilito System'}}],'subject':'" + Subject + "','htmlbody':'" + Html_Body + "'}");
                Console.WriteLine(parsedContent.ToString());
                ASCIIEncoding encoding = new ASCIIEncoding();
                Byte[] bytes = encoding.GetBytes(parsedContent.ToString());

                Stream newStream = http.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();

                var response = http.GetResponse();

                var stream = response.GetResponseStream();
                var sr = new StreamReader(stream);
                var content = sr.ReadToEnd();
                Console.WriteLine(content);

                email_response = Convert.ToString(content);

                return Request.CreateResponse(HttpStatusCode.OK, email_response);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
