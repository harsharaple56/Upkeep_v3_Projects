using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// using SendGrid's C# Library
// https://github.com/sendgrid/sendgrid-csharp
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Upkeep_v3.Testing_Codes
{
    public partial class SendGrid_emails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Execute().Wait();
        }

        static async Task Execute()
        {
            try
            {
                var apiKey = "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";
                var Template_ID = "d-6d2b77e7749043f6a5e98c9f832c279e";

                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("admin@efacilito.com", "eFacilito System");
                var to = new EmailAddress("lokesh@compelconsultancy.com", "Lokesh Devasani");
                //var to = new EmailAddress("prajapatiajay39@gmail.com", "Ajay Prajapati");
                //var dynamicData = "test";

                var dynamicData = new Dictionary<string, object>
                    {
                        { "test", "value1" }
                    };

                var msg = MailHelper.CreateSingleTemplateEmail(from, to, Template_ID, dynamicData);
                //var msg = MailHelper.CreateSingleEmail(from, to, Template_ID, dynamicData);

                var response = await client.SendEmailAsync(msg);

                string response1 = Convert.ToString(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static SendGridMessage CreateSingleTemplateEmail(EmailAddress from,EmailAddress to,string templateId,object dynamicTemplateData)
        //{
        //    if (string.IsNullOrWhiteSpace(templateId))
        //    {
        //        throw new ArgumentException($"{nameof(templateId)} is required when creating a dynamic template email.", nameof(templateId));
        //    }

        //    var msg = new SendGridMessage();
        //    msg.SetFrom(from);
        //    msg.AddTo(to);
        //    msg.TemplateId = templateId;

        //    if (dynamicTemplateData != null)
        //    {
        //        msg.SetTemplateData(dynamicTemplateData);
        //    }

        //    return msg;
        //}

    }
}