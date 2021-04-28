using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eFacilito_CompanyGroup_Portal
{
    public partial class eFacilito_MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_Full_Name.Text = Convert.ToString(Session["Full_Name"]);
        }
    }
}