using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace Upkeep_v3
{
    public class SendMail
    {

        public void Send_Mail(string ToEmailID, string MailBody, string MailSubject)
        {
            try
            {             
                string strSMTP = string.Empty;
                string strPort = string.Empty;
                string strFromEmailID = string.Empty;
                string strReplyEmailID = string.Empty;
                string strUsername = string.Empty;
                string strPassword = string.Empty;

                strSMTP = Convert.ToString(ConfigurationManager.AppSettings["smtp"]);
                strPort = Convert.ToString(ConfigurationManager.AppSettings["port"]);
                strFromEmailID = Convert.ToString(ConfigurationManager.AppSettings["FromEmail"]);
                strReplyEmailID = Convert.ToString(ConfigurationManager.AppSettings["ReplyEmail"]);
                strUsername = Convert.ToString(ConfigurationManager.AppSettings["smtp_username"]);
                strPassword = Convert.ToString(ConfigurationManager.AppSettings["smtp_password"]);
              
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(strFromEmailID);
                msg.To.Add(ToEmailID);
                msg.ReplyTo = new MailAddress(strReplyEmailID);

                //msg.Bcc.Add("atharv.paranjpe@gmail.com,ameyamusale@outlook.co.nz");
                //msg.CC.Add("");
                msg.Subject = MailSubject;
                msg.Body = MailBody;//Your Textbox.text;
                msg.IsBodyHtml = true;

                SmtpClient smt = new SmtpClient();
                smt.Host = strSMTP;
                System.Net.NetworkCredential ntwd = new NetworkCredential();
                ntwd.UserName = strUsername; //Your Email ID
                ntwd.Password = strPassword; // Your Password
                smt.UseDefaultCredentials = false; //true;
                smt.Credentials = ntwd;
                smt.Port = Convert.ToInt32(strPort);
                smt.EnableSsl = true; //  true;
                smt.Send(msg);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



    }
}