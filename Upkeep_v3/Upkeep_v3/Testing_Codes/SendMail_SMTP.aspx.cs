using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
//using mailinblue;

namespace Upkeep_v3.Testing_Codes
{
    public partial class SendMail_SMTP : System.Web.UI.Page
    {
        

        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("admin@efacilito.com");
                message.To.Add(new MailAddress("lokesh@compelconsultancy.com"));
                message.Subject = "Test";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = "Test Body";
                smtp.Port = 587;
                smtp.Host = "smtp.zeptomail.in"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("emailappsmtp.750a35af209617d1", "ENd1iZsH86Dy__2978041b65e93");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            var baseAddress = "https://api.zeptomail.in/v1.1/email";

            var http = (HttpWebRequest)WebRequest.Create(new Uri(baseAddress));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "POST";
            http.PreAuthenticate = true;
            http.Headers.Add("Authorization", "Zoho-enczapikey PHtE6r1bR+3p2mZ6pxFVsP+5H5KiYIIrqO1nKlFE4d1HXvFSHk1V+ox/kGWxrEosUvFDFPSTzoJh57PN4r6DIzrrZzsaVWqyqK3sx/VYSPOZsbq6x00VslsdcEHbUobsc99i3SXXudfSNA==");
            JObject parsedContent = JObject.Parse("{'bounce_address':'system@bounce.efacilito.com','from': { 'address': 'admin@efacilito.com'},'to': [{'email_address': {'address': 'lokesh@compelconsultancy.com','name': 'Lokesh Devasani'}}],'subject':'Test Email','htmlbody':'<div><b> Test email sent successfully.  </b></div>'}");
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
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            string Html_Body = string.Empty;
            string emails = string.Empty;
            string Subject= string.Empty;

            DataSet ds = new DataSet();
            
            try
            {
               // ds = ObjUpkeep.Send_Mail_Test("","","");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Html_Body = Convert.ToString(ds.Tables[0].Rows[0]["Mail_Body"]);
                        emails = Convert.ToString(ds.Tables[0].Rows[0]["Recipients"]);
                        Subject = Convert.ToString(ds.Tables[0].Rows[0]["Subject"]);

                    }

                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        //protected void Button4_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        API sendinBlue = new mailinblue.API("xkeysib - 68798a1b10c50144abb17dcd35cfa9eec222d7d9f45b35cf6a526ddc6a63a4f5 - nA49k7XzDVO1UTpK");

        //        Dictionary<string, object> data = null;
        //        Dictionary<string, string> to = new Dictionary<string, string>();
        //        to.Add("to@email.com", "to whom!");
        //        List<string> from_name = new List<string>();
        //        from_name.Add("from@email.com");
        //        from_name.Add("from email!");
        //        List<string> attachment = new List<string>();
        //        attachment.Add("https://domain.com/path-to-file/filename1.pdf");
        //        attachment.Add("https://domain.com/path-to-file/filename2.jpg");
        //        data.Add("to", to);
        //        data.Add("from", from_name);
        //        data.Add("subject", "My subject");
        //        data.Add("html", "This is the <h1>HTML</h1>");
        //        data.Add("attachment", attachment);
        //        Object sendEmail = sendinBlue.send_email(data);
        //        string response = sendEmail.ToString();
        //    }
        //    catch (Exception) { }
        //}


        public void Send_Mail_InFunction( string To_Emails , string Subject ,string Html_Body)
        {

            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            var baseAddress = "https://api.zeptomail.in/v1.1/email";

            var http = (HttpWebRequest)WebRequest.Create(new Uri(baseAddress));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "POST";
            http.PreAuthenticate = true;
            http.Headers.Add("Authorization", "Zoho-enczapikey PHtE6r1bR+3p2mZ6pxFVsP+5H5KiYIIrqO1nKlFE4d1HXvFSHk1V+ox/kGWxrEosUvFDFPSTzoJh57PN4r6DIzrrZzsaVWqyqK3sx/VYSPOZsbq6x00VslsdcEHbUobsc99i3SXXudfSNA==");
            JObject parsedContent = JObject.Parse("{'bounce_address':'system@bounce.efacilito.com','from': { 'address': 'admin@efacilito.com'},'to': [{'email_address': {'address': '"+To_Emails+ "','name': 'eFacilito System'}}],'subject':'" + Subject + "','htmlbody':'" + Html_Body + "'}");
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

        }

    }
}