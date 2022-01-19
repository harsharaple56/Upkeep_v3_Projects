using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Net.Mail;
using System.Configuration;
using System.Net;
using context = System.Web.HttpContext;
using Sentry;
using Sentry.AspNet;
using Sentry.EntityFramework; // if you also installed Sentry.EntityFramework
using Sentry.Extensibility;


namespace Upkeep_v3
{
    public class Global : System.Web.HttpApplication
    {
        private IDisposable _sentry;

        protected void Application_Start(object sender, EventArgs e)
        {
            //Session Count is intialized with 0.      
            Application["SessionCount"] = 0;

            // Initialize Sentry to capture AppDomain unhandled exceptions and more.
            _sentry = SentrySdk.Init(o =>
            {
                o.AddAspNet();
                //o.Dsn = "https://0d1244e846ad4945bd42b2ac3398a996@o1114068.ingest.sentry.io/6145004";
                o.Dsn = "https://0d1244e846ad4945bd42b2ac3398a996@o1114068.ingest.sentry.io/6145004";
                // When configuring for the first time, to see what the SDK is doing:
                o.Debug = true;
                // Set TracesSampleRate to 1.0 to capture 100%
                // of transactions for performance monitoring.
                // We recommend adjusting this value in production
                o.TracesSampleRate = 1.0;
                // if you also installed the Sentry.EntityFramework package
                o.AddEntityFramework();
            });
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();

            int countSession = (int)Application["SessionCount"];

            Application["SessionCount"] = countSession + 1;

            Application.UnLock();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Context.StartSentryTransaction();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            SentrySdk.CaptureException(exception);

            string StackTrace, Errormsg, Extype, Page, LoggedInUserID, CompanyID;

            Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();

            try
            {
                LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
                CompanyID = Convert.ToString(Session["CompanyID"]);

                Exception exmail = Server.GetLastError().InnerException;
                StackTrace = exmail.StackTrace;
                Extype = exmail.GetType().ToString();
                Page = context.Current.Request.Url.ToString();
                Errormsg = exmail.Message.ToString();
                //HttpContext con = HttpContext.Current;
                //Page = con.Request.Url.ToString();
                
                //EmailHead = "<b>Dear Team,</b>" + "<br/><br/>" + "An exception occurred in a Application Url" +
                //    " " + exurl + " " + "With following Details" + "<br/>" + "<br/>";
                //EmailSing = newline + "Thanks and Regards" + newline + "    " + "     " + "<b>Application Admin </b>" + "</br>";
                //Sub = "Exception occurred" + " " + "in Application" + " " + exurl;
                //HostAdd = ConfigurationManager.AppSettings["Host"].ToString();
                //string errortomail = EmailHead + "<b>Log Written Date: </b>" + " " + DateTime.Now.ToString() + newline + "<b>Error Line No :</b>" +
                //    " " + StackTrace + "\t\n" + " " + newline + "<b>Error Message:</b>" + " " + Errormsg + newline + "<b>Exception Type:</b>" + " " + 
                //    extype + newline + "<b> Error Details :</b>" + " " + ErrorLocation + newline + "<b>Error Page Url:</b>" + " " +
                //    exurl + newline + newline + EmailSing;

                ObjUpkeep.Error_Log(Extype, Page, Errormsg, StackTrace,CompanyID, LoggedInUserID);
                //using (MailMessage mailMessage = new MailMessage())
                //{
                //    Frommail = "compelapps_in_sql_db@compelconsultancy.in";
                //    ToMail = "rohanchelimela@gmail.com";
                //    password = "Compel@123#";

                //    mailMessage.From = new MailAddress(Frommail);
                //    mailMessage.Subject = Sub;
                //    mailMessage.Body = errortomail;
                //    mailMessage.IsBodyHtml = true;

                //    string[] MultiEmailId = ToMail.Split(',');
                //    foreach (string userEmails in MultiEmailId)
                //    {
                //        mailMessage.To.Add(new MailAddress(userEmails));
                //    }

                //    SmtpClient smtp = new SmtpClient();  // creating object of smptpclient  
                //    smtp.Host = "mail.compelconsultancy.in";              //host of emailaddress for example smtp.gmail.com etc  
                //    smtp.EnableSsl = false;
                //    NetworkCredential NetworkCred = new NetworkCredential();
                //    NetworkCred.UserName = mailMessage.From.Address;
                //    NetworkCred.Password = password;
                //    smtp.UseDefaultCredentials = true;
                //    smtp.Credentials = NetworkCred;
                //    smtp.Port = 465;
                //    smtp.Send(mailMessage); //sending Email  

                //}
            }
            catch (Exception em)
            {
                em.ToString();

            }

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();

            int countSession = (int)Application["SessionCount"];
            Application["SessionCount"] = countSession - 1;

            Application.UnLock();
        }

        protected void Application_EndRequest()
        {
            Context.FinishSentryTransaction();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            // Flushes out events before shutting down.
            _sentry?.Dispose();
        }
    }
}