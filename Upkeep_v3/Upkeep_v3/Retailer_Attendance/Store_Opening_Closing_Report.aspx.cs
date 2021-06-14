using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.Store_Attendance
{
    public partial class Store_Opening_Closing_Report : System.Web.UI.Page
    {

        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);


            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
        }

        

        public string Fetch_Store_Attendance()
        {
            string data = "";
            try
            {
                DataSet ds = new DataSet();
                ds = ObjUpkeep.Fetch_Store_Attendance(CompanyID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {

                            string Store_Name = Convert.ToString(ds.Tables[0].Rows[i]["Store_Name"]);
                            string Store_Manager = Convert.ToString(ds.Tables[0].Rows[i]["Store_Manager"]);
                            string Date = Convert.ToString(ds.Tables[0].Rows[i]["Date"]);
                            string Punch_IN = Convert.ToString(ds.Tables[0].Rows[i]["Punch_IN"]);
                            string Punch_OUT = Convert.ToString(ds.Tables[0].Rows[i]["Punch_OUT"]);
                            string Total_Hrs = Convert.ToString(ds.Tables[0].Rows[i]["Total_Hrs"]);

                            data += "<tr><td>" + Store_Name + "</td><td>" + Store_Manager + "</td><td>" + Date + "</td><td>" + Punch_IN + "</td><td>" + Punch_OUT + "</td><td>" + Total_Hrs + "</td></tr>";
                        }
                    }
                    else
                    {
                        //invalid login
                    }
                }
                else
                {
                    //invalid login
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

    }
}