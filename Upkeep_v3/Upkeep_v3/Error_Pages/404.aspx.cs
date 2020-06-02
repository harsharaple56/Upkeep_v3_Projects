using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.Error_Pages
{
    public partial class _404 : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check for visitor
            Session["Visitor"] = null;
            string path = HttpContext.Current.Request.RawUrl.Replace("/", "");
            string VisitFormURL = "/VMS/Visit_Request.aspx?ConfigID=";
            DataSet dsURL = new DataSet();
            dsURL = ObjUpkeep.Fetch_VMSFormURL(path);
            if (dsURL.Tables[0] != null)
            {
                if (dsURL.Tables[0].Rows.Count > 0)
                {
                    VisitFormURL = VisitFormURL + dsURL.Tables[0].Rows[0]["ConfigID"].ToString();
                    Session["Visitor"] = "Visitor";
                    Response.Redirect(VisitFormURL);
                }
                else
                {
                    
                }
            }
        }
    }
}