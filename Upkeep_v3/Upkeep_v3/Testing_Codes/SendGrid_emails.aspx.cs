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
            var apiKey = "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";
            var Template_ID = "d-6d2b77e7749043f6a5e98c9f832c279e";

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("admin@efacilito.com", "eFacilito System");
            var to = new EmailAddress("lokesh@compelconsultancy.com", "Lokesh Devasani");
            var dynamicData = "test";
            var msg = MailHelper.CreateSingleTemplateEmail(from, to, Template_ID,dynamicData);

            var response = await client.SendEmailAsync(msg);

            string response1 = Convert.ToString(response);
        }
    }
}