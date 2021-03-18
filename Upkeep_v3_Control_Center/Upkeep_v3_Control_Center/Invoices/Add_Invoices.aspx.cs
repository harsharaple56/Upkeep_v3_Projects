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

namespace Upkeep_v3_Control_Center.Invoices
{
    public partial class Add_Invoices : System.Web.UI.Page
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
                bindGroupDesc();
                int CompanyID = Convert.ToInt32(Request.QueryString["CompanyID"]);
                int CompanyID_Delete = Convert.ToInt32(Request.QueryString["DelCompanyID"]);
                if (CompanyID > 0)
                {
                    Session["CompanyID"] = Convert.ToString(CompanyID);
                    bindCompany_Master(CompanyID);
                }
                else
                {
                    Session["CompanyID"] = "";
                }
                if (CompanyID_Delete > 0)
                {
                    DeleteCompany_Master(CompanyID_Delete);
                }
            }

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int CompanyID = 0;
                if (Convert.ToString(Session["CompanyID"]) != "")
                {
                    CompanyID = Convert.ToInt32(Session["CompanyID"]);
                }
                string Action = "";
                DataSet ds = new DataSet();

                if (CompanyID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                int GroupID = 0;
                GroupID = Convert.ToInt32(ddlGroupDesc.SelectedValue);
                string ConString = string.Empty;
                int Is_DBatClientServer = 0;
                string CompanyLogoName = string.Empty;
                string CompanyCode = string.Empty;
                string ClientURL = string.Empty;
                string CompanyEmailID = string.Empty;
                string CompanyMobileNo = string.Empty;

                string User_FName = string.Empty;
                string User_LName = string.Empty;
                string User_Code = string.Empty;
                string User_Dept = string.Empty;

                string User_Name = string.Empty;
                string User_Designation = string.Empty;
                string User_EmailID = string.Empty;
                string User_MobileNo = string.Empty;

                CompanyCode = txtCompany_Code.Text.Trim();
                ClientURL = txtClientURL.Text.Trim();

                CompanyEmailID = txtCompanyEmailID.Text.Trim();
                CompanyMobileNo = txtCompanyMobileNo.Text.Trim();

                User_FName = txtFName.Text.Trim();
                User_LName = txtLName.Text.Trim();
                User_Dept = txtUserDept.Text.Trim();
                User_Code = txtUserCode.Text.Trim();

                User_Name = txtAdminName.Text.Trim();
                User_Designation = txtUserDesignation.Text.Trim();
                User_EmailID = txtUserEmailID.Text.Trim();
                User_MobileNo = txtUserMobileNo.Text.Trim();



                if (chk_IsDBatClient.Checked == true)
                {
                    Is_DBatClientServer = 1;
                    ConString = "Data Source=" + txtServerName.Text.Trim() + ";Initial Catalog=" + txtDatabase.Text.Trim() + ";Persist Security Info=True;User ID=" + txtDbUser.Text.Trim() + ";Password=" + txtDbPassword.Text.Trim() + "";

                }
                else
                {
                    Is_DBatClientServer = 0;
                }



                string imgPath = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadURL"]);

                if (fileUpload_CompanyLogo.HasFile)
                {
                    string CompanyLogo_Pic = string.Empty;

                    string fileUploadPath_Sign = HttpContext.Current.Server.MapPath("~/CompanyLogo/");

                    if (!Directory.Exists(fileUploadPath_Sign))
                    {
                        Directory.CreateDirectory(fileUploadPath_Sign);
                    }

                    string fileExtension_Sign = Path.GetExtension(fileUpload_CompanyLogo.FileName);
                    CompanyLogo_Pic = CompanyCode + fileExtension_Sign;

                    string Sign_SaveLocation = Server.MapPath("~/CompanyLogo/") + "/" + CompanyLogo_Pic;
                    CompanyLogoName = imgPath + "/CompanyLogo/" + CompanyLogo_Pic;

                    fileUpload_CompanyLogo.PostedFile.SaveAs(Sign_SaveLocation);

                    //fileUpload_CompanyLogo.PostedFile.SaveAs(Server.MapPath("~/Images/") + CompanyCode + ".PNG");
                    //CompanyLogoName = CompanyCode + ".PNG";
                }
                else
                {
                    CompanyLogoName = "";
                }

                //ConString = "";

                int SMS_ConfigID = 0;
                int SMS_Min_Bal_Alert = 0;
                int SMS_Alloted = 0;
                int SMS_Available_Balance = 0;

                SMS_ConfigID = Convert.ToInt32(ddlSMS_Config.SelectedValue);

                if (Convert.ToInt32(ddlSMS_Config.SelectedValue) > 0)
                {
                    SMS_Alloted = Convert.ToInt32(txt_Alloted_SMS.Text.Trim());
                    SMS_Min_Bal_Alert = Convert.ToInt32(txt_SMS_Balance_Alert.Text.Trim());
                    SMS_Available_Balance = Convert.ToInt32(txt_Alloted_SMS.Text.Trim());
                }
                ds = objUpkeepCC.CompanyMaster_CRUD(CompanyID, txtCompany_Code.Text.Trim(), txtCompDesc.Text.Trim(), GroupID, CompanyLogoName, ClientURL, Is_DBatClientServer, ConString, CompanyEmailID, CompanyMobileNo, User_FName, User_LName, User_Dept, User_Code, User_Name, User_Designation, User_EmailID, User_MobileNo, SMS_ConfigID, SMS_Alloted, SMS_Min_Bal_Alert, SMS_Available_Balance, LoggedInUserID, Action);

                Session["CompanyID"] = "";
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 0)
                        {

                        }
                        else if (Status == 1)
                        {
                            Response.Redirect(Page.ResolveClientUrl("~/Masters/Company_Mst.aspx"), false);
                            //Response.Redirect("~/Masters/Company_Mst.aspx", false);
                        }
                        else if (Status == 3)
                        {
                            lblErrorMsg.Text = "Group Code/ Group Description already exists";
                        }
                        else if (Status == 2)
                        {
                            lblErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void bindGroupDesc()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objUpkeepCC.Fetch_GroupDesc();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlGroupDesc.DataSource = ds.Tables[0];
                        ddlGroupDesc.DataTextField = "Group_Desc";
                        ddlGroupDesc.DataValueField = "Group_ID";
                        ddlGroupDesc.DataBind();
                        ddlGroupDesc.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    if (ds.Tables.Count > 1)
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            ddlSMS_Config.DataSource = ds.Tables[1];
                            ddlSMS_Config.DataTextField = "Config_Desc";
                            ddlSMS_Config.DataValueField = "Config_ID";
                            ddlSMS_Config.DataBind();
                            ddlSMS_Config.Items.Insert(0, new ListItem("--Select--", "0"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void bindCompany_Master(int CompanyID)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objUpkeepCC.CompanyMaster_CRUD(CompanyID, "", "", 0, "", "", 0, "", "", "", "", "", "", "", "", "", "", "", 0, 0, 0, 0, LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtCompany_Code.Text = Convert.ToString(ds.Tables[0].Rows[0]["Company_Code"]);
                        txtCompDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["Company_Desc"]);
                        ddlGroupDesc.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Group_ID"]);

                        txtCompanyEmailID.Text = Convert.ToString(ds.Tables[0].Rows[0]["Company_EmailID"]);
                        txtCompanyMobileNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["Company_MobileNo"]);

                        txtFName.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_FName"]);
                        txtLName.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_LName"]);
                        txtUserDept.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_Department"]);
                        txtUserCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_Code"]);

                        txtAdminName.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_Name"]);
                        txtUserDesignation.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_Designation"]);
                        txtUserEmailID.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_EmailID"]);
                        txtUserMobileNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_MobileNo"]);

                        txtClientURL.Text = Convert.ToString(ds.Tables[0].Rows[0]["ClientURL"]);

                        ddlSMS_Config.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SMS_Config_ID"]);
                        Available_Allot_SMS_Bal.Text = Convert.ToString(ds.Tables[0].Rows[0]["SMS_Available"]);
                        txt_Alloted_SMS.Text = Convert.ToString(ds.Tables[0].Rows[0]["SMS_Alloted"]);
                        txt_SMS_Balance_Alert.Text = Convert.ToString(ds.Tables[0].Rows[0]["SMS_Min_Alert_Bal"]);

                        if (Convert.ToString(ds.Tables[0].Rows[0]["SMS_Config_ID"]) != "")
                        {
                            if (Convert.ToInt32(ds.Tables[0].Rows[0]["SMS_Config_ID"]) > 0)
                            {
                                chk_Is_SMS_Enable.Checked = true;
                                SMS_Config_Details.Visible = true;
                            }
                        }


                        txtCompany_Code.ReadOnly = true;

                        int Is_DBatClientServer = Convert.ToInt32(ds.Tables[0].Rows[0]["Is_DBatClient"]);
                        if (Is_DBatClientServer == 1)
                        {
                            chk_IsDBatClient.Checked = true;
                            dvServerDetails.Visible = true;

                            string ConStr = Convert.ToString(ds.Tables[0].Rows[0]["Con_String"]);

                            string strServer = string.Empty;
                            string strDBName = string.Empty;
                            string strUserID = string.Empty;
                            string strPassword = string.Empty;

                            string[] strSplitValues = Regex.Split(ConStr, @"[;=]+");

                            if (strSplitValues.Length > 8)
                            {
                                txtServerName.Text = strSplitValues[1];
                                txtDatabase.Text = strSplitValues[3];
                                txtDbUser.Text = strSplitValues[7];
                                txtDbPassword.Text = strSplitValues[9];
                            }
                        }
                        else
                        {
                            chk_IsDBatClient.Checked = false;
                        }



                        //string[] authorsList = ConStr.Split('=');

                        //int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        //if (Status == 0)
                        //{

                        //}
                        //else if (Status == 1)
                        //{
                        //    //Response.Redirect("~/Masters/Group_Mst.aspx", false);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void chk_IsDBatClient_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_IsDBatClient.Checked)
            {
                dvServerDetails.Visible = true;
            }
            else
            {
                dvServerDetails.Visible = false;
            }
        }

        public void DeleteCompany_Master(int CompanyID_Delete)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objUpkeepCC.CompanyMaster_CRUD(CompanyID_Delete, "", "", 0, "", "", 0, "", "", "", "", "", "", "", "", "", "", "", 0, 0, 0, 0, LoggedInUserID, "D");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Redirect("~/Masters/Company_Mst.aspx", false);
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
        }

        protected void chk_Is_SMS_Enable_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Is_SMS_Enable.Checked)
            {
                SMS_Config_Details.Visible = true;
            }
            else
            {
                SMS_Config_Details.Visible = false;
            }
        }

        protected void ddlSMS_Config_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ConfigID = 0;
            ConfigID = Convert.ToInt32(ddlSMS_Config.SelectedValue);
            Fetch_SMS_Config_Details(ConfigID);
        }

        public void Fetch_SMS_Config_Details(int ConfigID)
        {
            DataSet dsSMS = new DataSet();
            string Check_Balance_API = string.Empty;
            bool Is_Client_SMS_Pack;
            try
            {
                dsSMS = objUpkeepCC.Fetch_SMS_Config_Details(ConfigID);

                if (dsSMS.Tables.Count > 0)
                {
                    if (dsSMS.Tables[0].Rows.Count > 0)
                    {
                        Check_Balance_API = Convert.ToString(dsSMS.Tables[0].Rows[0]["Check_Balance_URL"]);
                        Is_Client_SMS_Pack = Convert.ToBoolean(dsSMS.Tables[0].Rows[0]["Is_Client_SMS_Pack"]);

                        Session["APIKEY"] = Convert.ToString(dsSMS.Tables[0].Rows[0]["Api_Key"]);
                        Session["SenderID"] = Convert.ToString(dsSMS.Tables[0].Rows[0]["Sender_ID"]);
                        Session["SendSMSURL"] = Convert.ToString(dsSMS.Tables[0].Rows[0]["Send_SMS_URL"]);

                        if (Is_Client_SMS_Pack)
                        {
                            txt_Alloted_SMS.Text = ""; //Same count as on Balance sms
                        }
                        else
                        {
                            //User will enter
                            //txt_Alloted_SMS.Text = "";
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Check_SMS_Balance_API(string API_URL)
        {
            try
            {
                API_URL = "http://sms.thebulksms.in/api/mt/GetBalance?User=alembic&Password=alm@123";
                string inputJson = (new JavaScriptSerializer()).Serialize(API_URL);
                //HttpClient client = new HttpClient();
                HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
                ////HttpResponseMessage response = client.GetAsync(API_URL).Result;
                //HttpResponseMessage response = client.PostAsync(API_URL, inputContent).Result;
                //if (response.IsSuccessStatusCode)
                //{
                //    List<SMS_Balance_API> company = (new JavaScriptSerializer()).Deserialize<List<SMS_Balance_API>>(response.Content.ReadAsStringAsync().Result);

                //    //int status = Convert.ToInt32(company[0].Status);
                //    string CompanyID = Convert.ToString(company[0].ErrorCode);
                //    string ModuleIDs = Convert.ToString(company[0].ErrorMessage);
                //    string CompanyName = Convert.ToString(company[0].Balance);

                //}


                var client = new RestClient("http://sms.thebulksms.in/api/mt/GetBalance?User=alembic&Password=alm%40123");
                var request = new RestRequest(Intersoft.Crosslight.RestClient.HttpMethod.POST);
                //request.AddHeader("postman-token", "016b0072-8eb8-5411-9a61-a96b1b44caa3");
                //request.AddHeader("cache-control", "no-cache");

                //IRestResponse<SMS_Balance_API> response = client.Execute<SMS_Balance_API>(request);
                //IRestResponse response = client.ExecuteAsyncGet<SMS_Balance_API>(request);
                //IRestResponse response = client.ExecuteAsync(request); //.ExecuteAsync(request);

                //string inputJson = (new JavaScriptSerializer()).Serialize(input);
                //HttpClient client = new HttpClient();
                //HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
                //HttpResponseMessage response = client.PostAsync(apiUrl + "/GetCustomers", inputContent).Result;
                //if (response.IsSuccessStatusCode)
                //{
                //    List<Customer> customers = (new JavaScriptSerializer()).Deserialize<List<Customer>>(response.Content.ReadAsStringAsync().Result);
                //    gvCustomers.DataSource = customers;
                //    gvCustomers.DataBind();
                //}

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public class SMS_Balance_API
        {
            public string ErrorCode { get; set; }
            public string ErrorMessage { get; set; }
            public string Balance { get; set; }
        }

        public class Send_SMS_API
        {
            public string ErrorCode { get; set; }
            public string ErrorMessage { get; set; }
        }

        protected void btnSendTestSMS_Click(object sender, EventArgs e)
        {
            lblTestSMSSuccess.Text = "";
            lblTestSMSError.Text = "";
            try
            {
                string sAPIKey = "";
                string sNumber = txtSendTestSMSMobileNo.Text.Trim();
                string sMessage = txtSendTestSMSText.Text.Trim();
                string sSenderID = "";
                //string sChannel = "Trans";
                //string sRoute = "06";
                string sResponse = "";
                string sURL = "";
                string Send_SMS_URL = "";
                sAPIKey = Convert.ToString(Session["APIKEY"]);
                sSenderID = Convert.ToString(Session["SenderID"]);
                Send_SMS_URL = Convert.ToString(Session["SendSMSURL"]);
                //if (string.IsNullOrWhiteSpace(txtInput.Text))
                //{
                //sURL = "http://yourdomain.com/api/mt/SendSMS?APIKEY=" + sAPIKey + "&senderid=" + sSenderID + "&channel=" + sChannel + "&DCS=0&flashsms=0&number=" + sNumber + "&text=" + sMessage + "& route = " + sRoute;
                //sURL = "http://sms.thebulksms.in/api/mt/SendSMS?route=06&channel=Trans&DCS=0&flashsms=0" + "&APIKEY=" + sAPIKey + "&senderid=" + sSenderID + "&number=" + sNumber + "&text=" + sMessage;

                sURL = Send_SMS_URL + "&APIKEY=" + sAPIKey + "&senderid=" + sSenderID + "&number=" + sNumber + "&text=" + sMessage;
                //}
                sResponse = GetJSONResponse(sURL);

                Send_SMS_API sms = JsonConvert.DeserializeObject<Send_SMS_API>(sResponse);

                if (sms.ErrorCode == "000")
                {
                    lblTestSMSSuccess.Text = "Test SMS send successfully";
                    Session["APIKEY"] = "";
                    Session["SenderID"] = "";
                    Session["SendSMSURL"] = "";
                }
                else
                {
                    lblTestSMSError.Text = "Test SMS failed, Please check config details";
                }

                //Response.Write(sResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static string GetJSONResponse(string sURL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
            request.MaximumAutomaticRedirections = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            request.ContentType = "application/json; charset=utf-8";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream receiveStream = response.GetResponseStream(
                );
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string sResponse = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                return sResponse;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

    }
}