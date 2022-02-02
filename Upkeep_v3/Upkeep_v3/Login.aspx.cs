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

            Session["IPAddress"] = Request.ServerVariables["REMOTE_ADDR"].ToString();

        }

        public class Company
        {
            public int Status { get; set; }
            public int CompanyID { get; set; }
            public string CompanyName { get; set; }
            public string Module_ID { get; set; }
            public string Company_Logo { get; set; }
        }

        [System.Web.Services.WebMethod]
        public static Dictionary<string, string> LoginClick(string txtUsername, string txtPassword, string LoggingAs)
        {
            Dictionary<string, string> dlst = new Dictionary<string, string>();
            Login page = new Login();
            string UserType = string.Empty;
            int status = 0;
            try
            {
                bool isInternet = CheckForInternetConnection();
                if (isInternet)
                {
                    string strStatus = Convert.ToString(page.Session["Status"]);

                    if (!string.IsNullOrEmpty(strStatus))
                    {
                        status = Convert.ToInt32(strStatus);
                    }

                    if (status == 1)
                    {
                        if (LoggingAs == "1")
                        {
                            UserType = "E";
                        }
                        else
                        {
                            UserType = "R";
                        }

                        DataSet ds = new DataSet();
                        int CompanyID = 0;

                        if (Convert.ToString(page.Session["CompanyID"]) != "")
                        {
                            CompanyID = Convert.ToInt32(page.Session["CompanyID"]);
                        }

                        ds = page.ObjUpkeepCC.LoginUser(txtUsername.Trim(), txtPassword, UserType, CompanyID);

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

                                        page.Session["UserType"] = Convert.ToString(UserType);
                                        if (UserType == "E")
                                        {
                                            page.Session["EmpCD"] = Convert.ToString(ds.Tables[0].Rows[0]["empcd"]);
                                            page.Session["RollCD"] = Convert.ToString(ds.Tables[0].Rows[0]["rollcd"]);
                                            page.Session["LoggedInUserID"] = Convert.ToString(ds.Tables[0].Rows[0]["User_ID"]);
                                            page.Session["Profile_Photo"] = Convert.ToString(ds.Tables[0].Rows[0]["Profile_Photo"]);
                                            page.Session["Role_Name"] = Convert.ToString(ds.Tables[0].Rows[0]["Role_Name"]);
                                            page.Session["User_Dept_ID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Department_ID"]);
                                            page.Session["Company_Logo"] = Convert.ToString(ds.Tables[0].Rows[0]["Company_Logo"]);
                                            page.Session["UserID"] = Convert.ToString(ds.Tables[0].Rows[0]["User_ID"]);

                                            Save_Web_Login_Activity(Convert.ToInt32(ds.Tables[0].Rows[0]["User_ID"]), "E");

                                            dlst.Add("1", "Dashboard_Employee.aspx");

                                        }
                                        else
                                        {
                                            page.Session["LoggedInUserID"] = Convert.ToString(txtUsername.Trim());
                                            page.Session["Retailer_Location"] = Convert.ToString(ds.Tables[0].Rows[0]["Loc_ID"]);
                                            page.Session["StoreManager_Name"] = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
                                            page.Session["StoreName"] = Convert.ToString(ds.Tables[0].Rows[0]["Store_Name"]);
                                            page.Session["StoreNo"] = Convert.ToString(ds.Tables[0].Rows[0]["Store_No"]);
                                            page.Session["Retailer_ID"] = Convert.ToString(ds.Tables[0].Rows[0]["Retailer_ID"]);
                                            page.Session["UserID"] = Convert.ToString(ds.Tables[0].Rows[0]["Retailer_ID"]);

                                            Save_Web_Login_Activity(Convert.ToInt32(ds.Tables[0].Rows[0]["Retailer_ID"]), "R");

                                            dlst.Add("2", "Dashboard_Retailer.aspx");
                                        }

                                        page.Session["UserName"] = Convert.ToString(txtUsername.Trim());
                                        page.Session["LoggedInProfileName"] = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);


                                    }
                                    else
                                    {
                                        //invalid login
                                        dlst.Add("3", "Invalid credential");
                                    }
                                }
                                else
                                {
                                    dlst.Add("3", "Dear " + txtUsername.Trim() + " , no role has been assigned to you. Hence you cannot login. Please contact your Property Administrator for further assistance.");
                                }

                            }
                            else
                            {
                                //invalid login
                                dlst.Add("3", "Invalid credential");
                            }
                        }
                        else
                        {
                            //invalid login
                            dlst.Add("3", "Invalid credential");
                        }

                    }
                    else if (status == 2)
                    {
                        dlst.Add("3", "License Expired, Kindly contact eFacilito Support Team");
                    }
                    else if (status == 3)
                    {
                        dlst.Add("3", "Invalid Company Code");
                    }
                    else
                    {
                        dlst.Add("3", "Please try again later");
                    }
                }
                else
                {
                    dlst.Add("3", "Unable to connect to Server. Please try again later.");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dlst;
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

        [System.Web.Services.WebMethod]
        public static Dictionary<string, string> VerifiedCompanyCode(string companycode)
        {
            Dictionary<string, string> dlst = new Dictionary<string, string>();
            Login obj = new Login();
            bool isInternet = CheckForInternetConnection();

            if (isInternet)
                dlst = obj.Validate_Company(companycode.Trim());
            else
                dlst.Add("4", "Unable to connect to Server. Please try again later.");

            return dlst;
        }

        private Dictionary<string, string> Validate_Company(string CompanyCode)
        {
            try
            {
                Dictionary<string, string> dlst = new Dictionary<string, string>();
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
                        Session["CompanyCode"] = Convert.ToString(CompanyCode.Trim());
                        Session["CompanyLogo"] = Company_Logo;

                        dlst.Add("1", Company_Logo);

                    }
                    else if (status == 2)
                    {
                        dlst.Add("2", "License Expired, Kindly contact eFacilito Support Team");
                    }
                    else if (status == 3)
                    {
                        dlst.Add("3", "Invalid Company Code");
                    }


                }
                else
                {
                    dlst.Add("3", "Invalid Company Code");
                }
                return dlst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [System.Web.Services.WebMethod]
        public static Dictionary<string, string> ForgotPassword(string txtEmail, string rdb)
        {
            Dictionary<string, string> dlst = new Dictionary<string, string>();
            string UserType = string.Empty;
            int status = 0;
            Login obj = new Login();

            try
            {
                bool isInternet = CheckForInternetConnection();
                if (isInternet)
                {
                    string strStatus = Convert.ToString(obj.Session["Status"]);

                    if (!string.IsNullOrEmpty(strStatus))
                    {
                        status = Convert.ToInt32(strStatus);
                    }

                    if (status == 1)
                    {
                        if (rdb.Contains("rdb_Employee"))
                        {
                            UserType = "E";
                        }
                        else
                        {
                            UserType = "R";
                        }

                        DataSet ds = new DataSet();
                        int CompanyID = 0;

                        if (Convert.ToString(obj.Session["CompanyID"]) != "")
                        {
                            CompanyID = Convert.ToInt32(obj.Session["CompanyID"]);
                        }


                        ds = obj.ObjUpkeepCC.FetchUserEmail(txtEmail.Trim(), UserType, CompanyID);



                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {

                                obj.Session["UserType"] = Convert.ToString(UserType);
                                if (UserType == "E")
                                {
                                    obj.Session["EmailID"] = Convert.ToString(ds.Tables[0].Rows[0]["User_Email"]);
                                    obj.Session["User_ID"] = Convert.ToString(ds.Tables[0].Rows[0]["User_ID"]);
                                }
                                else
                                {
                                    obj.Session["User_ID"] = Convert.ToString(ds.Tables[0].Rows[0]["Retailer_ID"]);
                                    obj.Session["EmailID"] = Convert.ToString(ds.Tables[0].Rows[0]["EmailID"]);
                                }


                                if (status == 1)
                                {
                                    // dvCompanyCode.Attributes.Add("style", "display:none;");
                                    //DivOtp.Attributes.Add("style", "display:block;");
                                    //dvCompanyLogo.Attributes.Add("style", "display:block; text-align: center;");

                                    dlst.Add("1", "OTP");

                                    Random random = new Random();
                                    string OTP = string.Empty;

                                    OTP = random.Next(0, 999999).ToString("D6");
                                    obj.Session["OTP"] = OTP;
                                    ds = obj.ObjUpkeepCC.ForgetPasswordSendOTP(Convert.ToString(obj.Session["EmailID"]), OTP, CompanyID);

                                }
                                else if (status == 2)
                                {
                                    dlst.Add("2", "License Expired, Kindly contact eFacilito Support Team");
                                }
                                else if (status == 3)
                                {
                                    dlst.Add("3", "Invalid Email Id");
                                }

                            }
                            else
                            {
                                //invalid login
                                if (ds.Tables[1].Rows.Count > 0)
                                {
                                    dlst.Add("4", "This Email-ID is not registered under the " + ds.Tables[1].Rows[0]["Company_Desc"].ToString());
                                }
                            }
                        }
                        else
                        {
                            dlst.Add("5", "Invalid credential");
                        }

                    }
                    else if (status == 2)
                    {
                        dlst.Add("6", "License Expired, Kindly contact eFacilito Support Team");
                    }
                    else if (status == 3)
                    {
                        dlst.Add("7", "Invalid Company Code");
                    }
                    else
                    {
                        dlst.Add("8", "Please try again later");
                    }
                }
                else
                {
                    dlst.Add("8", "Unable to connect to Server. Please try again later.");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dlst;
        }

        [System.Web.Services.WebMethod]
        public static Dictionary<string, string> ChangePassword(string txtPass, string txtconfipass)
        {
            Dictionary<string, string> dlst = new Dictionary<string, string>();
            DataSet ds = new DataSet();
            Login obj = new Login();
            int User_ID = 0;
            if (Convert.ToString(obj.Session["User_ID"]) != "")
            {
                User_ID = Convert.ToInt32(obj.Session["User_ID"]);
            }

            int CompanyID = 0;

            if (Convert.ToString(obj.Session["CompanyID"]) != "")
            {
                CompanyID = Convert.ToInt32(obj.Session["CompanyID"]);
            }

            string Password = string.Empty;
            string ConfirmPassword = string.Empty;
            string EmailID = Convert.ToString(obj.Session["EmailID"]);
            string UserType = Convert.ToString(obj.Session["UserType"]);

            Password = txtPass.Trim();
            ConfirmPassword = txtconfipass.Trim();

            if (Password == ConfirmPassword)
            {
                ds = obj.ObjUpkeepCC.UpdatePassword(Convert.ToString(obj.Session["User_ID"]), EmailID, Password, UserType, CompanyID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            obj.Session["User_ID"] = "";
                            dlst.Add("1", "Login");
                        }
                        else if (Status == 3)
                        {
                            dlst.Add("2", "User already exists");
                        }
                        else if (Status == 2)
                        {
                            dlst.Add("3", "Due to some technical issue your request can not be process. Kindly try after some time");
                        }
                    }
                }
            }
            else
            {
                dlst.Add("4", "Please enter correct cofirm passowrd.");
            }
            return dlst;
        }

        [System.Web.Services.WebMethod]
        public static Dictionary<string, string> CheckOTP(string txtOtp)
        {

            Dictionary<string, string> dlst = new Dictionary<string, string>();
            Login obj = new Login();
            if (txtOtp == obj.Session["OTP"].ToString())
            {
                dlst.Add("1", "Success");
            }
            else
            {
                dlst.Add("2", "Invalid OTP");

            }
            return dlst;
        }

        public static string Save_Web_Login_Activity(int UserID, string User_Type)
        {
            DataSet dslogs = new DataSet();
            Login obj = new Login();
            try
            {
                string Log_Type = string.Empty;
                string IP_Address = string.Empty;
                string Browser_Name = string.Empty;
                string OS_Name = string.Empty;

                Log_Type = "Login";
                //IP_Address = obj.Request.ServerVariables["REMOTE_ADDR"].ToString();
                IP_Address = Convert.ToString(obj.Session["IPAddress"]);

                System.Web.HttpBrowserCapabilities browser = HttpContext.Current.Request.Browser;
                Browser_Name = Convert.ToString(browser.Browser);

                System.OperatingSystem osInfo = System.Environment.OSVersion;
                OS_Name = browser.Platform; //osInfo.Platform.ToString();

                //string operatingSystem = getOperatinSystemDetails(Request.UserAgent);

                dslogs = obj.ObjUpkeepCC.Save_Web_Login_Activity(Log_Type, UserID, User_Type, IP_Address, Browser_Name, OS_Name);

                return "1";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string getOperatinSystemDetails(string browserDetails)
        {
            try
            {
                switch (browserDetails.Substring(browserDetails.LastIndexOf("Windows NT") + 11, 3).Trim())
                {
                    case "6.2":
                        return "Windows 8";
                    case "6.1":
                        return "Windows 7";
                    case "6.0":
                        return "Windows Vista";
                    case "5.2":
                        return "Windows XP 64-Bit Edition";
                    case "5.1":
                        return "Windows XP";
                    case "5.0":
                        return "Windows 2000";
                    default:
                        return browserDetails.Substring(browserDetails.LastIndexOf("Windows NT"), 14);
                }
            }
            catch
            {
                if (browserDetails.Length > 149)
                    return browserDetails.Substring(0, 149);
                else
                    return browserDetails;
            }
        }


    }
}