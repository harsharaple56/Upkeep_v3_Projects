using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;
using System.Net.Mail;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
/// <summary>
/// Summary description for Email_Service
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Email_Service : System.Web.Services.WebService
{

    public Email_Service()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public void Send_Mail(string To_Emails, string Subject, string Html_Body)
    {

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

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

}
