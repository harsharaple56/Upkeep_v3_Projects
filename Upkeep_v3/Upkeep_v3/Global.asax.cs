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

namespace Upkeep_v3
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
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

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}