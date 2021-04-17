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
        string path = "~/Masters/";
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
                lblApplication_Size.Text =Convert.ToString(FindFolderSize(new DirectoryInfo(Server.MapPath(path)), UnitType.MB, 2).ToString() + " MB");


                //Response.Write(FindFolderSize(new DirectoryInfo(Server.MapPath("~/Masters")), UnitType.MB, 2).ToString() + " MB");


            }

        }

        public enum UnitType { KB = 1, MB = 2, GB = 3 }

        public double FindFolderSize(DirectoryInfo d, UnitType u, int r)
        {
            double divider = Math.Pow(1024, (int)u);
            double size = 0;
            foreach (FileInfo f in d.GetFiles())
                size += Convert.ToDouble(f.Length) / divider;
            foreach (DirectoryInfo c in d.GetDirectories())
                size += this.FindFolderSize(c, u, r);
            return Math.Round(size, r);
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
                        
                        lbl_Total_Asset_Count.Text = Convert.ToString(ds.Tables[0].Rows[0]["Total_Asset_Count"]);
                        lbl_Total_CHK_Count.Text = Convert.ToString(ds.Tables[0].Rows[0]["Total_CHK_Count"]);
                        lbl_Total_GP_Count.Text = Convert.ToString(ds.Tables[0].Rows[0]["Total_GP_Count"]);
                        lbl_Total_WP_Count.Text = Convert.ToString(ds.Tables[0].Rows[0]["Total_WP_Count"]);
                        lbl_Total_TKT_Count.Text = Convert.ToString(ds.Tables[0].Rows[0]["Total_TKT_Count"]);
                        lbl_Total_Feedback_Count.Text = Convert.ToString(ds.Tables[0].Rows[0]["Total_Feedback_Count"]);


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
                            string Total_Users = Convert.ToString(ds.Tables[1].Rows[i]["UserCount"]);
                            string Total_Retailers = Convert.ToString(ds.Tables[1].Rows[i]["RetailerCount"]);

                            

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