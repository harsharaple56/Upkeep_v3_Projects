using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SendMail mail = new SendMail();
            mail.Send_Mail("ajay.p@compelconsultancy.com", "MailBody", "MailSubject");
        }

        protected void btnWhatsapp_Click(object sender, EventArgs e)
        {
            Upkeep_v3.SMS.WhatsAppAlert.SendALert(txtMsg.Text, txtNumber.Text, "Test", 0, "RC");
        }
    }
}