using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Custom_Reports
{
    public partial class Page_Redirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl(Global.ReportPath), false);
        }
    }
}