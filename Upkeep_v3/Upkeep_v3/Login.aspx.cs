using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Sharpbrake.Client;
//using System.Net.WebClient;

namespace Upkeep_v3
{
    public partial class Login : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeepCC = new Upkeep_V3_Services.Upkeep_V3_Services();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblVersion.Text = Convert.ToString(ConfigurationManager.AppSettings["VersionNo"]);

            try
            {

                var settings = ConfigurationManager.AppSettings.AllKeys.Where(key => key.StartsWith("Airbrake", StringComparison.OrdinalIgnoreCase)).ToDictionary(key => key, key => ConfigurationManager.AppSettings[key]);

                var airbrakeConfiguration = AirbrakeConfig.Load(settings);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void txtCompanyCode_TextChanged(object sender, EventArgs e)
        {

            bool isInternet = CheckForInternetConnection();
            if (isInternet)
            {
                lblError.Text = "";
                Validate_Company(txtCompanyCode.Text.Trim());
                //Session["CompanyID"] = "";
            }
            else
            {
                lblError.Text = "Unable to connect to Server. Please try again later.";
            }

        }

        //public static async Task Validate_Company(string CompanyCode)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        //Send HTTP requests from here.  
        //        string API_URL = Convert.ToString(ConfigurationManager.AppSettings["API_URL"]);
        //        client.BaseAddress = new Uri(API_URL);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        //GET Method  
        //        HttpResponseMessage response = await client.GetAsync("Validate_Company?CompanyCode=" + CompanyCode + "");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            string status =  response.Content.ReadAsAsync<Status>();
        //            //Console.WriteLine("Id:{0}\tName:{1}", department.DepartmentId, department.DepartmentName);
        //            //Console.WriteLine("No of Employee in Department: {0}", department.Employees.Count);
        //        }
        //        else
        //        {
        //            Console.WriteLine("Internal server Error");
        //        }
        //    }
        //}

        private void Validate_Company(string CompanyCode)
        {
            try
            {
                string API_URL = Convert.ToString(ConfigurationManager.AppSettings["API_URL"]);

                string inputJson = (new JavaScriptSerializer()).Serialize(CompanyCode);
                HttpClient client = new HttpClient();
                HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.GetAsync(API_URL + "Validate_Company?CompanyCode=" + CompanyCode + "").Result;
                if (response.IsSuccessStatusCode)
                {
                    List<Company> company = (new JavaScriptSerializer()).Deserialize<List<Company>>(response.Content.ReadAsStringAsync().Result);
                    int status = Convert.ToInt32(company[0].Status);
                    string CompanyID = Convert.ToString(company[0].CompanyID);
                    string ModuleIDs = Convert.ToString(company[0].Module_ID);
                    string CompanyName = Convert.ToString(company[0].CompanyName);
                    string Company_Logo = Convert.ToString(company[0].Company_Logo);

                    Session["Status"] = Convert.ToString(status);
                    if (status == 1)
                    {
                        Session["ModuleID"] = ModuleIDs;
                        Session["CompanyID"] = CompanyID;
                        Session["CompanyName"] = CompanyName;
                        Session["CompanyCode"] = Convert.ToString(txtCompanyCode.Text.Trim());
                        Session["CompanyLogo"] = Company_Logo;

                        dvCompanyCode.Attributes.Add("style", "display:none;");
                        dvLogin.Attributes.Add("style", "display:block;");
                        dvCompanyLogo.Attributes.Add("style", "display:block; text-align: center;");
                        imgCompany_Logo.ImageUrl = Company_Logo;

                        //txtUsername.Attributes.Remove("readonly");
                        //txtUsername.ReadOnly = false;
                        //txtPassword.ReadOnly = false;
                    }
                    else if (status == 2)
                    {
                        lblError.Text = "License Expired, Kindly contact eFacilito Support Team";
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        //txtUsername.ReadOnly = true;
                        //txtPassword.ReadOnly = true;
                    }
                    else if (status == 3)
                    {
                        lblError.Text = "Invalid Company Code";
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        //txtUsername.ReadOnly = true;
                        //txtPassword.ReadOnly = true;
                    }


                }
                else
                {
                    lblError.Text = "Invalid Company Code";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public class Company
        {
            public int Status { get; set; }
            public int CompanyID { get; set; }
            public string CompanyName { get; set; }
            public string Module_ID { get; set; }
            public string Company_Logo { get; set; }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string UserType = string.Empty;
            int status = 0;
            try
            {
                bool isInternet = CheckForInternetConnection();
                if (isInternet)
                {
                    string strStatus = Convert.ToString(Session["Status"]);

                    if (!string.IsNullOrEmpty(strStatus))
                    {
                        status = Convert.ToInt32(strStatus);
                    }

                    if (status == 1)
                    {
                        if (rdbEmployee.Checked)
                        {
                            UserType = "E";
                        }
                        else
                        {
                            UserType = "R";
                        }

                        DataSet ds = new DataSet();
                        int CompanyID = 0;

                        if (Convert.ToString(Session["CompanyID"]) != "")
                        {
                            CompanyID = Convert.ToInt32(Session["CompanyID"]);
                        }

                        ds = ObjUpkeepCC.LoginUser(txtUsername.Text.Trim(), txtPassword.Text, UserType, CompanyID);

                        int AssignedRoleCount = 0;

                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                AssignedRoleCount = Convert.ToInt32(ds.Tables[0].Rows[0]["RoleMenuCount"]);

                                if (AssignedRoleCount > 0)
                                {
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {

                                        Session["UserType"] = Convert.ToString(UserType);
                                        if (UserType == "E")
                                        {
                                            Session["EmpCD"] = Convert.ToString(ds.Tables[0].Rows[0]["empcd"]);
                                            Session["RollCD"] = Convert.ToString(ds.Tables[0].Rows[0]["rollcd"]);
                                            Session["LoggedInUserID"] = Convert.ToString(ds.Tables[0].Rows[0]["User_ID"]);
                                            Session["Profile_Photo"] = Convert.ToString(ds.Tables[0].Rows[0]["Profile_Photo"]);
                                            Session["Role_Name"] = Convert.ToString(ds.Tables[0].Rows[0]["Role_Name"]);
                                            Session["User_Dept_ID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Department_ID"]);
                                            Session["Company_Logo"] = Convert.ToString(ds.Tables[0].Rows[0]["Company_Logo"]);

                                            Response.Redirect("~/Dashboard_Employee.aspx", false);

                                        }
                                        else
                                        {
                                            Session["LoggedInUserID"] = Convert.ToString(txtUsername.Text.Trim());
                                            Session["Retailer_Location"] = Convert.ToString(ds.Tables[0].Rows[0]["Loc_ID"]);
                                            Session["StoreManager_Name"] = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
                                            Session["StoreName"] = Convert.ToString(ds.Tables[0].Rows[0]["Store_Name"]);
                                            Session["StoreNo"] = Convert.ToString(ds.Tables[0].Rows[0]["Store_No"]);

                                            Response.Redirect("~/Dashboard_Retailer.aspx", false);

                                        }

                                        Session["UserName"] = Convert.ToString(txtUsername.Text.Trim());
                                        Session["LoggedInProfileName"] = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);


                                    }
                                    else
                                    {
                                        //invalid login
                                        lblError.Text = "Invalid credential";
                                    }
                                }
                                else
                                {
                                    lblError.Text = "Dear " + txtUsername.Text.Trim() + " , no role has been assigned to you. Hence you cannot login. Please contact your Property Administrator for further assistance."; //No role assigned
                                }

                            }
                            else
                            {
                                //invalid login
                                lblError.Text = "Invalid credential";
                            }
                        }
                        else
                        {
                            lblError.Text = "Invalid credential";
                            //invalid login
                        }

                    }
                    else if (status == 2)
                    {
                        lblError.Text = "License Expired, Kindly contact eFacilito Support Team";
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        //txtUsername.ReadOnly = true;
                        //txtPassword.ReadOnly = true;
                    }
                    else if (status == 3)
                    {
                        lblError.Text = "Invalid Company Code";
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        //txtUsername.ReadOnly = true;
                        //txtPassword.ReadOnly = true;
                    }
                    else
                    {
                        lblError.Text = "Please try again later";
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        //txtUsername.ReadOnly = true;
                        //txtPassword.ReadOnly = true;
                    }
                }
                else
                {
                    lblError.Text = "Unable to connect to Server. Please try again later.";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new System.Net.WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


    }
}