using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Intersoft.Crosslight.RestClient;
using Newtonsoft.Json;

namespace Upkeep_v3_Control_Center
{
    public partial class Dashboard : System.Web.UI.Page
    {

        UpkeepControlCenter_Service.UpkeepControlCenter_Service objUpkeepCC = new UpkeepControlCenter_Service.UpkeepControlCenter_Service();
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            if (!IsPostBack)
            {
                Fetch_CC_Dashboard();


            }

        }

        public void Fetch_CC_Dashboard()
        {
            try
            {
                DataSet ds = new DataSet();
                //DataSet ds = new DataSet();

                ds = objUpkeepCC.CC_Dashboard();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lbl_Total_Users.Text = Convert.ToString(ds.Tables[0].Rows[0]["Total_Users"]);
                        lbl_Total_Employee_Users.Text = Convert.ToString(ds.Tables[0].Rows[0]["Total_Employee_Users"]);
                        lbl_Total_Retailers.Text = Convert.ToString(ds.Tables[0].Rows[0]["Total_Retailers"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public string Fetch_CC_Dashboard_Company()
        {
            string data = "";
            try
            {
                DataSet ds = new DataSet();

                ds = objUpkeepCC.CC_Dashboard();

                if (ds.Tables.Count > 1)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[1].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {

                            string Company_Name = Convert.ToString(ds.Tables[1].Rows[i]["CompanyName"]);
                            int Total_Users = Convert.ToInt32(ds.Tables[1].Rows[i]["UserCount"]);
                            int Total_Retailers = Convert.ToInt32(ds.Tables[1].Rows[i]["RetailerCount"]);

                            data += "<tr><td>" + Company_Name + "</td><td>" + Total_Users + "</td><td>" + Total_Retailers + "</td></tr>";

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