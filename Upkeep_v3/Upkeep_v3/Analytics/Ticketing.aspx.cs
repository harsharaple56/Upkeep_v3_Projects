using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Analytics
{
    public partial class Ticketing : System.Web.UI.Page
    {
        #region Global Variables
        static Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        static string LoggedInUserID = string.Empty;
        public static string FromDate = string.Empty;
        public static string ToDate = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (LoggedInUserID == "")
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);

            if (start_date.Value != "")
            {
                FromDate = Convert.ToString(start_date.Value);
            }
            else
            {
                DateTime Fromdate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture)).AddDays(-30);
                FromDate = Fromdate.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
            }

            if (end_date.Value != "")
            {
                ToDate = Convert.ToString(end_date.Value);
            }
            else
            {
                ToDate = DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
            }
        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static string Fetch_Analyze_Tkt_Block1()
        {
            DataSet ds = new DataSet();
            ds = ObjUpkeep.Fetch_Analyze_Tkt_Block1(LoggedInUserID, FromDate, ToDate);
            return JsonConvert.SerializeObject(ds);
        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static string Fetch_Analyze_Tkt_Block2()
        {
            DataSet ds = new DataSet();
            ds = ObjUpkeep.Fetch_Analyze_Tkt_Block2(LoggedInUserID, FromDate, ToDate);
            return JsonConvert.SerializeObject(ds);
        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static string Fetch_Analyze_Tkt_Block3()
        {
            DataSet ds = new DataSet();
            ds = ObjUpkeep.Fetch_Analyze_Tkt_Block3(LoggedInUserID, FromDate, ToDate);
            return JsonConvert.SerializeObject(ds);
        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static string Fetch_Analyze_Tkt_Block4()
        {
            DataSet ds = new DataSet();
            ds = ObjUpkeep.Fetch_Analyze_Tkt_Block4(LoggedInUserID);
            return JsonConvert.SerializeObject(ds);
        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static string Fetch_Analyze_Tkt_Block5()
        {
            DataSet ds = new DataSet();
            ds = ObjUpkeep.Fetch_Analyze_Tkt_Block5(LoggedInUserID, FromDate, ToDate);
            return JsonConvert.SerializeObject(ds);
        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static string Fetch_Analyze_Tkt_Block6()
        {
            DataSet ds = new DataSet();
            ds = ObjUpkeep.Fetch_Analyze_Tkt_Block6(LoggedInUserID, FromDate, ToDate);
            return JsonConvert.SerializeObject(ds);
        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public static string Fetch_Analyze_Tkt_Block7()
        {
            DataSet ds = new DataSet();
            ds = ObjUpkeep.Fetch_Analyze_Tkt_Block7(LoggedInUserID, FromDate, ToDate);
            return JsonConvert.SerializeObject(ds);
        }
    }
}