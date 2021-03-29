using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3
{
    public partial class Dashboard_v2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void btnClick_Tkt_Analyse(object sender, EventArgs e)
        {
            Response.Redirect("~/Dashboard_Admin_Ticketing.aspx");
        }

        protected void btn_Employee_Dashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Dashboard_Employee.aspx");
        }

        protected void btn_Admin_Dashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Dashboard_Admin.aspx");
        }
    }
}