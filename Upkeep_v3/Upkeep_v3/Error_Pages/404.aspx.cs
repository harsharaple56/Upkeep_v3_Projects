using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace Upkeep_v3.Error_Pages
{
    public partial class _404 : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check for visitor
            Session["Visitor"] = null;
            string path = HttpContext.Current.Request.RawUrl;//.Split("/",stringsp.);//.Replace("/", "");
            if (path.Length >= 5)
            { path = path.Substring(path.Length - 5); }
            Char FormType = ' ';
            string VisitFormURL = "../Login.aspx";
            DataSet dsURL = new DataSet();

            //string s1 = "Hello C#/123HJ/54321";
            int index = path.LastIndexOf("/") + 1;
            int lindex = 0;
            if (index > 0)
                lindex = path.Length - index;

            if (lindex == 5)
                path = path.Substring(index, lindex);

            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

            if (regexItem.IsMatch(path))
            { dsURL = ObjUpkeep.Fetch_VMSFormURL(path); }
            else { return; }


            if (dsURL.Tables[0] != null)
            {
                if (dsURL.Tables[0].Rows.Count > 0)
                {
                    FormType = Convert.ToChar(dsURL.Tables[0].Rows[0]["FormType"]);
                    if (FormType == 'V')
                    {
                        VisitFormURL = "~/VMS/Visit_Request.aspx?ConfigID=";
                    }
                    else if (FormType == 'F')
                    {
                        //VisitFormURL = "~/Feedback/Feedback_Request.aspx?EventID=";
                        VisitFormURL = "~/Feedback/Customer_Feedback.aspx?EventID=";
                    }
                    VisitFormURL = VisitFormURL + dsURL.Tables[0].Rows[0]["ConfigID"].ToString();

                    Session["Visitor"] = "Visitor";
                    //Session["Visitor"]
                    Response.Redirect(VisitFormURL);
                }
                else
                {

                }
            }
        }
    }
}