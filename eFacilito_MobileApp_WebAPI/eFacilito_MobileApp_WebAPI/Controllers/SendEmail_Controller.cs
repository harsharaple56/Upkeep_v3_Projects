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
using RestSharp;

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


        [Route("api/SendEmail/Send_Email_Json")]
        [HttpPost]
        public HttpResponseMessage Send_Email_Json([FromBody] Cls_Send_Email_Json objMail)
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
                //JObject parsedContent = JObject.Parse("{'bounce_address':'system@bounce.efacilito.com','from': { 'address': 'admin@efacilito.com'},'to': [{'email_address': {'address': '" + objMail.To_Email + "','name': 'eFacilito System'}}],'subject':'" + objMail.Subject + "','htmlbody':'" + objMail.Html_Body + "'}");

                JObject parsedContent = JObject.Parse("{'mail_template_key': '2518b.750a35af209617d1.k1.d5c656c0-f492-11eb-a4cb-5254006ade39.17b0d89462c','bounce_address': 'system@bounce.efacilito.com','from': {'address': 'admin@efacilito.com','name': 'eFacilito System'},'to': [{'email_address': {'address': 'lokesh@compelconsultancy.com','name': 'Lokesh Devasani'}}],'cc': [{'email_address': {'address': 'ajay.p@compelconsultancy.com','name': 'Ajay Prajapati'}}],'bcc': [{'email_address': {'address': '','name': ''}}],'merge_info': {'meeting_link':''},'reply_to': [{'address': 'support@efacilito.com','name': 'eFacilito Support Team'}],'client_reference': '1234','mime_headers': {'X-Test': 'test'}}");



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



        [Route("api/SendEmail/Send_Email_Json_Template")]
        [HttpPost]
        public HttpResponseMessage Send_Email_Json_Template()
        {
            string email_response = string.Empty;

            try
            {
                //System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                //var baseAddress = "https://api.zeptomail.in/v1.1/email/template/batch";

                //var http = (HttpWebRequest)WebRequest.Create(new Uri(baseAddress));
                //http.Accept = "application/json";
                //http.ContentType = "application/json";
                //http.Method = "POST";
                //http.PreAuthenticate = true;
                //http.Headers.Add("Authorization", "Zoho-enczapikey PHtE6r1ZQenu3jUq9EIE5PG6FpKsNYx9/e9gelROtIxADqMHTk1W/914xDLjrUguXKEWQKGbntg8sb7Ptr/WJWrpYGhJWmqyqK3sx/VYSPOZsbq6x00ZtlkYdE3ZVIfsdNZp3SPUvN3YNA==");
                ////JObject parsedContent = JObject.Parse("{'bounce_address':'system@bounce.efacilito.com','from': { 'address': 'admin@efacilito.com'},'to': [{'email_address': {'address': '" + objMail.To_Email + "','name': 'eFacilito System'}}],'subject':'" + objMail.Subject + "','htmlbody':'" + objMail.Html_Body + "'}");

                //JObject parsedContent = JObject.Parse("{'mail_template_key': '2518b.750a35af209617d1.k1.d5c656c0-f492-11eb-a4cb-5254006ade39.17b0d89462c','bounce_address': 'system@bounce.efacilito.com','from': {'address': 'admin@efacilito.com','name': 'eFacilito System'},'to': [{'email_address': {'address': 'lokesh@compelconsultancy.com','name': 'Lokesh Devasani'}}],'cc': [{'email_address': {'address': 'ajay.p@compelconsultancy.com','name': 'Ajay Prajapati'}}],'merge_info': {'meeting_link':''},'reply_to': [{'address': 'support@efacilito.com','name': 'eFacilito Support Team'}],'client_reference': '1234','mime_headers': {'X-Test': 'test'}}");

                //Console.WriteLine(parsedContent.ToString());
                //ASCIIEncoding encoding = new ASCIIEncoding();
                //Byte[] bytes = encoding.GetBytes(parsedContent.ToString());

                //Stream newStream = http.GetRequestStream();
                //newStream.Write(bytes, 0, bytes.Length);
                //newStream.Close();

                //var response = http.GetResponse();

                //var stream = response.GetResponseStream();
                //var sr = new StreamReader(stream);
                //var content = sr.ReadToEnd();
                //Console.WriteLine(content);

                //email_response = Convert.ToString(content);

                //return Request.CreateResponse(HttpStatusCode.OK, email_response);

                var client = new RestClient("https://api.zeptomail.in/v1.1/email/template/batch");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Zoho-enczapikey PHtE6r1bR+3p2mZ6pxFVsP+5H5KiYIIrqO1nKlFE4d1HXvFSHk1V+ox/kGWxrEosUvFDFPSTzoJh57PN4r6DIzrrZzsaVWqyqK3sx/VYSPOZsbq6x00VslsdcEHbUobsc99i3SXXudfSNA==");
                request.AddHeader("Cookie", "6389eb1069=abcd21ccb74b786b4877b315e275abe4; tmappgrp=-1");
                var body = @"{" + "\n" + @"""mail_template_key"": ""2518b.750a35af209617d1.k1.d5c656c0-f492-11eb-a4cb-5254006ade39.17b0d89462c""," + "\n" +
                @"""bounce_address"": ""system@bounce.efacilito.com""," + "\n" +
                @"""from"": {" + "\n" +
                @"""address"": ""admin@efacilito.com""," + "\n" +
                @"""name"": ""Mail from API""" + "\n" +
                          @"}," + "\n" +
                @"""to"": [" + "\n" +
                            @"{" + "\n" +
                                @"""email_address"": {" + "\n" +
                                    @"""address"": ""lokesh@compelconsultancy.com""," + "\n" +
                                     @"""name"": ""Ajay""" + "\n" +
                                @"}" + "\n" +
                            @"}" + "\n" +
                          @"]," + "\n" +
                @"""merge_info"": {" + "\n" +
                        @"""meeting_link"":""https://meeting.zoho.com/join?key=103666049*************22c92ca4""" + "\n" +
                @"}," + "\n" +
                @"""reply_to"": [" + "\n" +
                                   @"{" + "\n" +
                                        @"""address"": ""admin@compelconsultancy.com""," + "\n" +
                                        @"""name"": ""Rebecca""" + "\n" +
                                    @"}" + "\n" +
                                @"]," + "\n" +
                @"""client_reference"": ""1234""," + "\n" +
                @"""mime_headers"": {" + "\n" +
                                        @"""X-Test"": ""test""" + "\n" +
                                    @"}" + "\n" +
                @"}";
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                email_response = Convert.ToString(response.Content);

                return Request.CreateResponse(HttpStatusCode.OK, email_response);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
