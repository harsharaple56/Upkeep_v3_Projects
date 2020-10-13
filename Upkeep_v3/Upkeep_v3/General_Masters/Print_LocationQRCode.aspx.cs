using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.General_Masters
{
    public partial class Print_LocationQRCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rptQRCodes.DataSource = null;
            rptQRCodes.DataBind();
        }
    }
}