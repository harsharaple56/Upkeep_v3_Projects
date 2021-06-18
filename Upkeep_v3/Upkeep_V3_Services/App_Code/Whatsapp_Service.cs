using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Data;
using System.IO;
using WhatsAppApi;
using System.Net;
using System.Web.Script.Serialization; // requires the reference 'System.Web.Extensions'

/// <summary>
/// Summary description for Whatsapp_Service
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Whatsapp_Service : System.Web.Services.WebService
{

    public Whatsapp_Service()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    //[WebMethod]
    //public string Send_Message()
    //{
    //    string from = "8779598878";
    //    string to = "8898084488";
    //    string msg = "Hi";

    //    WhatsApp wa = new WhatsApp(from, "BnXk*******B0=", "eFacilito System", true, true);

    //    wa.OnConnectSuccess += () =>
    //    {
    //        MessageBox.Show("Connected to whatsapp...");

    //        wa.OnLoginSuccess += (phoneNumber, data) =>
    //        {
    //            wa.SendMessage(to, msg);
    //            MessageBox.Show("Message Sent...");
    //        };

    //        wa.OnLoginFailed += (data) =>
    //        {
    //            MessageBox.Show("Login Failed : {0}", data);
    //        };

    //        wa.Login();
    //    };

    //    wa.OnConnectFailed += (ex) =>
    //    {
    //        MessageBox.Show("Connection Failed...");
    //    };

    //    wa.Connect();
    //}


}
