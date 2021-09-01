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


                string merge_info = string.Empty;

                merge_info = @"""name"":""Ajay Prajapati""," + "\n" + @"""product_name"":""eFacilito System""," + "\n" + @"""username"":""ajay.p""" + "\n";

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
                                    @"""address"": ""ajay.p@compelconsultancy.com""," + "\n" +
                                     @"""name"": ""Ajay""" + "\n" +
                                @"}" + "\n" +
                            @"}" + "\n" +
                          @"]," + "\n" +
                @"""merge_info"": {" + "\n" //+
                                            //@"""meeting_link"":""https://meeting.zoho.com/join?key=103666049*************22c92ca4""" + "\n" 
                        + Convert.ToString(merge_info)
                        +
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

        #region Send Zepto Mail

        [Route("api/SendEmail/Send_Email_Zepto_Template_Ticket")]
        [HttpPost]
        public HttpResponseMessage Send_Email_Zepto_Template_Ticket(string mail_template_key, string to_email_address, string dynamic_values)
        {
            string email_response = string.Empty;

            string strRaisedBy_Name = string.Empty;
            string strAssigned_Department = string.Empty;
            string strTicket_ID = string.Empty;
            string strTicket_Date = string.Empty;
            string strTicket_Location = string.Empty;
            string strTicket_Category = string.Empty;
            string strTicket_SubCategory = string.Empty;
            string strTicket_Level = string.Empty;
            string strUser_Department = string.Empty;

            //dynamic_values = "Ajay Prajapati,Engineering,Tkt1001,10/08/2021 05:00 PM,loc > loc 1,Housekeeping,Cleaning,1,DepartmentName";

            try
            {
                string[] mergeinfo_array = dynamic_values.Split(',');

                //foreach (string lst in mergeinfo_array)
                //for (int i = 0; i <= mergeinfo_array.Length; i++)
                //{
                strRaisedBy_Name = Convert.ToString(mergeinfo_array[0]);
                strAssigned_Department = Convert.ToString(mergeinfo_array[1]);
                strTicket_ID = Convert.ToString(mergeinfo_array[2]);
                strTicket_Date = Convert.ToString(mergeinfo_array[3]);
                strTicket_Location = Convert.ToString(mergeinfo_array[4]);
                strTicket_Category = Convert.ToString(mergeinfo_array[5]);
                strTicket_SubCategory = Convert.ToString(mergeinfo_array[6]);
                strTicket_Level = Convert.ToString(mergeinfo_array[7]);
                strUser_Department = Convert.ToString(mergeinfo_array[8]);
                //}

                string merge_info = string.Empty;
                string dynamic_values2 = string.Empty;

                List<To> dataTo = new List<To>();
                for (int i = 0; i < to_email_address.Split(';').Count(); i++)
                {
                    To toItem = new To();
                    {
                        toItem.email_address = new EmailAddress
                        {
                            address = to_email_address.Split(';')[i],
                            name = "",
                        };

                    };
                    dataTo.Add(toItem);
                }

                List<ReplyTo> dataReply = new List<ReplyTo>();
                ReplyTo replyItem = new ReplyTo();
                {
                    replyItem.address = "admin@efacilito.com";
                    replyItem.name = "eFacilito System";
                };
                dataReply.Add(replyItem);

                Json_Mail_Root rootBody = new Json_Mail_Root()
                {
                    mail_template_key = mail_template_key,
                    bounce_address = "system@bounce.efacilito.com",
                    from = new From()
                    {
                        address = "admin@efacilito.com",
                        name = "eFacilito System",
                    },
                    to = dataTo,
                    merge_info = new MergeInfo()
                    {
                        RaisedBy_Name = strRaisedBy_Name,
                        Assigned_Department = strAssigned_Department,
                        Ticket_ID = strTicket_ID,
                        Ticket_Date = strTicket_Date,
                        Ticket_Location = strTicket_Location,
                        Ticket_Category = strTicket_Category,
                        Ticket_SubCategory = strTicket_SubCategory,
                        Ticket_Level = strTicket_Level,
                        User_Department = strUser_Department,
                    },
                    reply_to = dataReply,
                    client_reference = "",
                    mime_headers = new MimeHeaders()
                    {
                        XTest = "",
                    },
                };

                string rootBody_Json = JsonConvert.SerializeObject(rootBody);

                var client = new RestClient("https://api.zeptomail.in/v1.1/email/template/batch");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Zoho-enczapikey PHtE6r1bR+3p2mZ6pxFVsP+5H5KiYIIrqO1nKlFE4d1HXvFSHk1V+ox/kGWxrEosUvFDFPSTzoJh57PN4r6DIzrrZzsaVWqyqK3sx/VYSPOZsbq6x00VslsdcEHbUobsc99i3SXXudfSNA==");
                request.AddHeader("Cookie", "6389eb1069=abcd21ccb74b786b4877b315e275abe4; tmappgrp=-1");

                request.AddParameter("application/json", rootBody_Json, ParameterType.RequestBody);
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

        [Route("api/SendEmail/Send_Email_Zepto_Template_Gatepass")]
        [HttpPost]
        public HttpResponseMessage Send_Email_Zepto_Template_Gatepass(string mail_template_key, string to_email_address, string dynamic_values)
        {
            string email_response = string.Empty;

            string Raiser_Name = string.Empty;
            string Gatepass_ID = string.Empty;
            string Gatepass_Raised_Date = string.Empty;
            string Gatepass_No = string.Empty;
            string Gatepass_Title = string.Empty;
            string Gatepass_Type = string.Empty;
            string Gatepass_Date = string.Empty;
            string Gatepass_Material_Detail = string.Empty;
            string Company_Name = string.Empty;

            //dynamic_values = "Anjali Kori,Housekeepings,TKT4592,17 Aug 2021 6:46PM,CENTRIUM,Cat100,NA,Housekeepings,aaa,bbb";

            try
            {
                string[] mergeinfo_array = dynamic_values.Split(',');

                //foreach (string lst in mergeinfo_array)
                //for (int i = 0; i <= mergeinfo_array.Length; i++)
                //{
                Raiser_Name = Convert.ToString(mergeinfo_array[0]);
                Gatepass_ID = Convert.ToString(mergeinfo_array[1]);
                Gatepass_Raised_Date = Convert.ToString(mergeinfo_array[2]);
                Gatepass_No = Convert.ToString(mergeinfo_array[3]);
                Gatepass_Title = Convert.ToString(mergeinfo_array[4]);
                Gatepass_Type = Convert.ToString(mergeinfo_array[5]);
                Gatepass_Date = Convert.ToString(mergeinfo_array[6]);
                Gatepass_Material_Detail = Convert.ToString(mergeinfo_array[7]);
                Company_Name = Convert.ToString(mergeinfo_array[8]);
                //}

                string merge_info_gatepass = string.Empty;
                string dynamic_values2 = string.Empty;

                List<To> dataTo = new List<To>();
                for (int i = 0; i < to_email_address.Split(';').Count(); i++)
                {
                    To toItem = new To();
                    {
                        toItem.email_address = new EmailAddress
                        {
                            address = to_email_address.Split(';')[i],
                            name = "",
                        };

                    };
                    dataTo.Add(toItem);
                }

                List<ReplyTo> dataReply = new List<ReplyTo>();
                ReplyTo replyItem = new ReplyTo();
                {
                    replyItem.address = "admin@efacilito.com";
                    replyItem.name = "eFacilito System";
                };
                dataReply.Add(replyItem);

                Json_Mail_Root_Gatepass rootBody = new Json_Mail_Root_Gatepass()
                {
                    mail_template_key = mail_template_key,
                    bounce_address = "system@bounce.efacilito.com",
                    from = new From()
                    {
                        address = "admin@efacilito.com",
                        name = "eFacilito System",
                    },
                    to = dataTo,
                    merge_info = new MergeInfo_Gatepass()
                    {
                        Raiser_Name = Raiser_Name,
                        Gatepass_ID = Gatepass_ID,
                        Gatepass_Raised_Date = Gatepass_Raised_Date,
                        Gatepass_No = Gatepass_No,
                        Gatepass_Title = Gatepass_Title,
                        Gatepass_Type = Gatepass_Type,
                        Gatepass_Date = Gatepass_Date,
                        Gatepass_Material_Detail = Gatepass_Material_Detail,
                        Company_Name = Company_Name
                    },
                    reply_to = dataReply,
                    client_reference = "",
                    mime_headers = new MimeHeaders()
                    {
                        XTest = "",
                    },
                };

                string rootBody_Json = JsonConvert.SerializeObject(rootBody);

                var client = new RestClient("https://api.zeptomail.in/v1.1/email/template/batch");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Zoho-enczapikey PHtE6r1bR+3p2mZ6pxFVsP+5H5KiYIIrqO1nKlFE4d1HXvFSHk1V+ox/kGWxrEosUvFDFPSTzoJh57PN4r6DIzrrZzsaVWqyqK3sx/VYSPOZsbq6x00VslsdcEHbUobsc99i3SXXudfSNA==");
                request.AddHeader("Cookie", "6389eb1069=abcd21ccb74b786b4877b315e275abe4; tmappgrp=-1");

                request.AddParameter("application/json", rootBody_Json, ParameterType.RequestBody);
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

        [Route("api/SendEmail/Send_Email_Zepto_Template_WorkPermit")]
        [HttpPost]
        public HttpResponseMessage Send_Email_Zepto_Template_WorkPermit(string mail_template_key, string to_email_address, string dynamic_values)
        {
            string email_response = string.Empty;
            string Raiser_Name = string.Empty;
            string Gatepass_ID = string.Empty;
            string Gatepass_Raised_Date = string.Empty;
            string Gatepass_No = string.Empty;
            string Gatepass_Title = string.Empty;
            string Gatepass_Type = string.Empty;
            string Gatepass_Date = string.Empty;
            string Gatepass_Material_Detail = string.Empty;
            string Company_Name = string.Empty;

            try
            {
                string[] mergeinfo_array = dynamic_values.Split(',');

                Raiser_Name = Convert.ToString(mergeinfo_array[0]);
                Gatepass_ID = Convert.ToString(mergeinfo_array[1]);
                Gatepass_Raised_Date = Convert.ToString(mergeinfo_array[2]);
                Gatepass_No = Convert.ToString(mergeinfo_array[3]);
                Gatepass_Title = Convert.ToString(mergeinfo_array[4]);
                Gatepass_Type = Convert.ToString(mergeinfo_array[5]);
                Gatepass_Date = Convert.ToString(mergeinfo_array[6]);
                Gatepass_Material_Detail = Convert.ToString(mergeinfo_array[7]);
                Company_Name = Convert.ToString(mergeinfo_array[8]);
                //}


                List<To> dataTo = new List<To>();
                for (int i = 0; i < to_email_address.Split(';').Count(); i++)
                {
                    To toItem = new To();
                    {
                        toItem.email_address = new EmailAddress
                        {
                            address = to_email_address.Split(';')[i],
                            name = "",
                        };

                    };
                    dataTo.Add(toItem);
                }

                List<ReplyTo> dataReply = new List<ReplyTo>();
                ReplyTo replyItem = new ReplyTo();
                {
                    replyItem.address = "admin@efacilito.com";
                    replyItem.name = "eFacilito System";
                };
                dataReply.Add(replyItem);

                Json_Mail_Root_WorkPermit rootBody = new Json_Mail_Root_WorkPermit()
                {
                    mail_template_key = mail_template_key,
                    bounce_address = "system@bounce.efacilito.com",
                    from = new From()
                    {
                        address = "admin@efacilito.com",
                        name = "eFacilito System",
                    },
                    to = dataTo,
                    merge_info = new MergeInfo_WorkPermit()
                    {
                        Raiser_Name = Raiser_Name,
                        Gatepass_ID = Gatepass_ID,
                        Gatepass_Raised_Date = Gatepass_Raised_Date,
                        Gatepass_No = Gatepass_No,
                        Gatepass_Title = Gatepass_Title,
                        Gatepass_Type = Gatepass_Type,
                        Gatepass_Date = Gatepass_Date,
                        Gatepass_Material_Detail = Gatepass_Material_Detail,
                        Company_Name = Company_Name
                    },
                    reply_to = dataReply,
                    client_reference = "",
                    mime_headers = new MimeHeaders()
                    {
                        XTest = "",
                    },
                };

                string rootBody_Json = JsonConvert.SerializeObject(rootBody);

                var client = new RestClient("https://api.zeptomail.in/v1.1/email/template/batch");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Zoho-enczapikey PHtE6r1bR+3p2mZ6pxFVsP+5H5KiYIIrqO1nKlFE4d1HXvFSHk1V+ox/kGWxrEosUvFDFPSTzoJh57PN4r6DIzrrZzsaVWqyqK3sx/VYSPOZsbq6x00VslsdcEHbUobsc99i3SXXudfSNA==");
                request.AddHeader("Cookie", "6389eb1069=abcd21ccb74b786b4877b315e275abe4; tmappgrp=-1");

                request.AddParameter("application/json", rootBody_Json, ParameterType.RequestBody);
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

        [Route("api/SendEmail/Send_Email_Zepto_Template_VMS")]
        [HttpPost]
        public HttpResponseMessage Send_Email_Zepto_Template_VMS(string mail_template_key, string to_email_address, string dynamic_values)
        {
            string email_response = string.Empty;
            string Company_Name = string.Empty;
            string Visit_Request_ID = string.Empty;
            string Visitor_Name = string.Empty;
            string Visitor_ID_Link = string.Empty;
            string VMS_Config_Title = string.Empty;
            string Visit_Date = string.Empty;
            string Visit_Request_Date = string.Empty;

            try
            {
                string[] mergeinfo_array = dynamic_values.Split(',');

                Company_Name = Convert.ToString(mergeinfo_array[0]);
                Visit_Request_ID = Convert.ToString(mergeinfo_array[1]);
                Visitor_Name = Convert.ToString(mergeinfo_array[2]);
                Visitor_ID_Link = Convert.ToString(mergeinfo_array[3]);
                VMS_Config_Title = Convert.ToString(mergeinfo_array[4]);
                Visit_Date = Convert.ToString(mergeinfo_array[5]);
                Visit_Request_Date = Convert.ToString(mergeinfo_array[6]);

                List<To> dataTo = new List<To>();
                for (int i = 0; i < to_email_address.Split(';').Count(); i++)
                {
                    To toItem = new To();
                    {
                        toItem.email_address = new EmailAddress
                        {
                            address = to_email_address.Split(';')[i],
                            name = "",
                        };

                    };
                    dataTo.Add(toItem);
                }

                List<ReplyTo> dataReply = new List<ReplyTo>();
                ReplyTo replyItem = new ReplyTo();
                {
                    replyItem.address = "admin@efacilito.com";
                    replyItem.name = "eFacilito System";
                };
                dataReply.Add(replyItem);

                Json_Mail_Root_VMS rootBody = new Json_Mail_Root_VMS()
                {
                    mail_template_key = mail_template_key,
                    bounce_address = "system@bounce.efacilito.com",
                    from = new From()
                    {
                        address = "admin@efacilito.com",
                        name = "eFacilito System",
                    },
                    to = dataTo,
                    merge_info = new MergeInfo_VMS()
                    {
                        Company_Name = Company_Name,
                        Visit_Request_ID = Visit_Request_ID,
                        Visitor_Name = Visitor_Name,
                        Visitor_ID_Link = Visitor_ID_Link,
                        VMS_Config_Title = VMS_Config_Title,
                        Visit_Date = Visit_Date,
                        Visit_Request_Date = Visit_Request_Date
                    },
                    reply_to = dataReply,
                    client_reference = "",
                    mime_headers = new MimeHeaders()
                    {
                        XTest = "",
                    },
                };

                string rootBody_Json = JsonConvert.SerializeObject(rootBody);

                var client = new RestClient("https://api.zeptomail.in/v1.1/email/template/batch");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Zoho-enczapikey PHtE6r1bR+3p2mZ6pxFVsP+5H5KiYIIrqO1nKlFE4d1HXvFSHk1V+ox/kGWxrEosUvFDFPSTzoJh57PN4r6DIzrrZzsaVWqyqK3sx/VYSPOZsbq6x00VslsdcEHbUobsc99i3SXXudfSNA==");
                request.AddHeader("Cookie", "6389eb1069=abcd21ccb74b786b4877b315e275abe4; tmappgrp=-1");

                request.AddParameter("application/json", rootBody_Json, ParameterType.RequestBody);
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

        #endregion
    }
}
