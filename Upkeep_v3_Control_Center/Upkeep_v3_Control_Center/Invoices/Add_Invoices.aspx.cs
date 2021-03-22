﻿using System;
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
                bindCompanyDesc();

                int InvoiceID = Convert.ToInt32(Request.QueryString["InvoiceID"]);
                int InvoiceID_Delete = Convert.ToInt32(Request.QueryString["InvoiceID_Delete"]);
                if (InvoiceID > 0)
                {
                    Session["InvoiceID"] = Convert.ToString(InvoiceID);
                    //bindInvoice_Master(InvoiceID);
                    bindCompany_Master(InvoiceID);
                }
                else
                {
                    Session["InvoiceID"] = "";
                }
                if (InvoiceID_Delete > 0)
                {
                    //DeleteInvoice_Master(InvoiceID_Delete);
                    bindCompany_Master(InvoiceID);

                }
            }

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               
                int InvoiceID = 0;
                if (Convert.ToString(Session["InvoiceID"]) != "")
                {
                    InvoiceID = Convert.ToInt32(Session["InvoiceID"]);
                }
                string Action = "";
                DataSet ds = new DataSet();

                if (InvoiceID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                
                string Invoice_No = string.Empty;
                string Invoice_Desc = string.Empty;
                string Invoice_Amount = string.Empty;
                string Invoice_CGST = string.Empty;
                string Invoice_SGST = string.Empty;
                int Company_ID = 0;
                
                string GSTIN = string.Empty;
                string Nature_of_Invoice = string.Empty;
                string Invoice_File_Path = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadURL"]);
                string Due_Date = string.Empty;
                string Billing_Name = string.Empty;

                string ConString = string.Empty;


                Invoice_No = txt_Invoice_No.Text.Trim();
                Invoice_Desc = txt_Invoice_Desc.Text.Trim();
                Invoice_Amount = txt_Invoice_Amount.Text.Trim();

                Invoice_CGST=Convert.ToString((Convert.ToDecimal(Invoice_Amount)*18)/ 100);
                Invoice_SGST = Convert.ToString((Convert.ToDecimal(Invoice_Amount) * 18) / 100);

                //Invoice_CGST = lbl_Invoice_CGST.Text.Trim();
                //Invoice_SGST = lbl_Invoice_SGST.Text.Trim();
                Company_ID = Convert.ToInt32(ddl_Company_Desc.SelectedValue);
                GSTIN = Txt_GSTIN.Text.Trim();
                Nature_of_Invoice = Convert.ToString(ddl_Nature_of_Invoice.SelectedValue);
                Billing_Name = txt_Billing_Name.Text.Trim();
                //Invoice_File_Path = fileUpload_Invoice.Text.Trim();
                //Due_Date = txt_Invoice_No.Text.Trim();

                string Invoice_FilePath = string.Empty;
                string imgPath = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadURL"]);

                if (fileUpload_Invoice.HasFile)
                {
                    string fileUploadInvoice = string.Empty;

                    string fileUploadPath_Invoice = HttpContext.Current.Server.MapPath("~/Invoices/Uploads/");

                    if (!Directory.Exists(fileUploadPath_Invoice))
                    {
                        Directory.CreateDirectory(fileUploadPath_Invoice);
                    }

                    string fileExtension = Path.GetExtension(fileUpload_Invoice.FileName);
                   string Invoice_FileName = Invoice_No + fileExtension;

                    string Invoice_SaveLocation = Server.MapPath("~/Invoices/Uploads/") + Invoice_FileName;
                    Invoice_FilePath = imgPath + "/Invoices/Uploads/" + Invoice_FileName;

                    fileUpload_Invoice.PostedFile.SaveAs(Invoice_SaveLocation);

                   
                    //CompanyLogoName = CompanyCode + ".PNG";
                }
                else
                {
                    Invoice_FilePath = "";
                }

                //ConString = "";

                ds = objUpkeepCC.Invoices_CRUD(0, Invoice_No, Invoice_Desc, Invoice_Amount, Invoice_CGST, Invoice_SGST, "","Pending", "", Company_ID,"","", Nature_of_Invoice, Billing_Name, "", GSTIN, Invoice_FilePath, LoggedInUserID, Action);


                Session["InvoiceID"] = "";
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
                            Response.Redirect(Page.ResolveClientUrl("~/Invoices/Invoices_Listing.aspx"), false);
                            //Response.Redirect("~/Masters/Company_Mst.aspx", false);
                        }
                        else if (Status == 3)
                        {
                            lblErrorMsg.Text = "Invoice No. already exists";
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

        public void bindCompanyDesc()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objUpkeepCC.Fetch_CompanyDesc();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddl_Company_Desc.DataSource = ds.Tables[0];
                        ddl_Company_Desc.DataTextField = "Company_Desc";
                        ddl_Company_Desc.DataValueField = "Company_ID";
                        ddl_Company_Desc.DataBind();
                        ddl_Company_Desc.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void Invoice_Due_Date_TextChanged(object sender, EventArgs e)
        {
            //FetchLicenseExpiryDate(Convert.ToInt32(ddlSubscription.SelectedValue), ActivationDate.Text.Trim());
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
                       

                        //txtFName.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_FName"]);
                        //txtLName.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_LName"]);
                        //txtUserDept.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_Department"]);
                        //txtUserCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_Code"]);

                        //txtAdminName.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_Name"]);
                        //txtUserDesignation.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_Designation"]);
                        //txtUserEmailID.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_EmailID"]);
                        //txtUserMobileNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_MobileNo"]);

                        //txtClientURL.Text = Convert.ToString(ds.Tables[0].Rows[0]["ClientURL"]);

                        //ddlSMS_Config.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SMS_Config_ID"]);
                        //Available_Allot_SMS_Bal.Text = Convert.ToString(ds.Tables[0].Rows[0]["SMS_Available"]);
                        //txt_Alloted_SMS.Text = Convert.ToString(ds.Tables[0].Rows[0]["SMS_Alloted"]);
                        //txt_SMS_Balance_Alert.Text = Convert.ToString(ds.Tables[0].Rows[0]["SMS_Min_Alert_Bal"]);

                        //if (Convert.ToString(ds.Tables[0].Rows[0]["SMS_Config_ID"]) != "")
                        //{
                        //    if (Convert.ToInt32(ds.Tables[0].Rows[0]["SMS_Config_ID"]) > 0)
                        //    {
                        //        chk_Is_SMS_Enable.Checked = true;
                        //        SMS_Config_Details.Visible = true;
                        //    }
                        //}


                        ////txtCompany_Code.ReadOnly = true;

                        //int Is_DBatClientServer = Convert.ToInt32(ds.Tables[0].Rows[0]["Is_DBatClient"]);
                        //if (Is_DBatClientServer == 1)
                        //{
                        //    chk_IsDBatClient.Checked = true;
                        //    dvServerDetails.Visible = true;

                        //    string ConStr = Convert.ToString(ds.Tables[0].Rows[0]["Con_String"]);

                        //    string strServer = string.Empty;
                        //    string strDBName = string.Empty;
                        //    string strUserID = string.Empty;
                        //    string strPassword = string.Empty;

                        //    string[] strSplitValues = Regex.Split(ConStr, @"[;=]+");

                        //    if (strSplitValues.Length > 8)
                        //    {
                        //        txtServerName.Text = strSplitValues[1];
                        //        txtDatabase.Text = strSplitValues[3];
                        //        txtDbUser.Text = strSplitValues[7];
                        //        txtDbPassword.Text = strSplitValues[9];
                        //    }
                        //}
                        //else
                        //{
                        //    chk_IsDBatClient.Checked = false;
                        //}



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

        //protected void chk_IsDBatClient_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chk_IsDBatClient.Checked)
        //    {
        //        dvServerDetails.Visible = true;
        //    }
        //    else
        //    {
        //        dvServerDetails.Visible = false;
        //    }
        //}

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

        //protected void chk_Is_SMS_Enable_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chk_Is_SMS_Enable.Checked)
        //    {
        //        SMS_Config_Details.Visible = true;
        //    }
        //    else
        //    {
        //        SMS_Config_Details.Visible = false;
        //    }
        //}

        //protected void ddlSMS_Config_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int ConfigID = 0;
        //    ConfigID = Convert.ToInt32(ddlSMS_Config.SelectedValue);
        //    Fetch_SMS_Config_Details(ConfigID);
        //}

        //public void Fetch_SMS_Config_Details(int ConfigID)
        //{
        //    DataSet dsSMS = new DataSet();
        //    string Check_Balance_API = string.Empty;
        //    bool Is_Client_SMS_Pack;
        //    try
        //    {
        //        dsSMS = objUpkeepCC.Fetch_SMS_Config_Details(ConfigID);

        //        if (dsSMS.Tables.Count > 0)
        //        {
        //            if (dsSMS.Tables[0].Rows.Count > 0)
        //            {
        //                Check_Balance_API = Convert.ToString(dsSMS.Tables[0].Rows[0]["Check_Balance_URL"]);
        //                Is_Client_SMS_Pack = Convert.ToBoolean(dsSMS.Tables[0].Rows[0]["Is_Client_SMS_Pack"]);

        //                Session["APIKEY"] = Convert.ToString(dsSMS.Tables[0].Rows[0]["Api_Key"]);
        //                Session["SenderID"] = Convert.ToString(dsSMS.Tables[0].Rows[0]["Sender_ID"]);
        //                Session["SendSMSURL"] = Convert.ToString(dsSMS.Tables[0].Rows[0]["Send_SMS_URL"]);

        //                if (Is_Client_SMS_Pack)
        //                {
        //                    txt_Alloted_SMS.Text = ""; //Same count as on Balance sms
        //                }
        //                else
        //                {
        //                    //User will enter
        //                    //txt_Alloted_SMS.Text = "";
        //                }
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //private void Check_SMS_Balance_API(string API_URL)
        //{
        //    try
        //    {
        //        API_URL = "http://sms.thebulksms.in/api/mt/GetBalance?User=alembic&Password=alm@123";
        //        string inputJson = (new JavaScriptSerializer()).Serialize(API_URL);
        //        //HttpClient client = new HttpClient();
        //        HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
        //        ////HttpResponseMessage response = client.GetAsync(API_URL).Result;
        //        //HttpResponseMessage response = client.PostAsync(API_URL, inputContent).Result;
        //        //if (response.IsSuccessStatusCode)
        //        //{
        //        //    List<SMS_Balance_API> company = (new JavaScriptSerializer()).Deserialize<List<SMS_Balance_API>>(response.Content.ReadAsStringAsync().Result);

        //        //    //int status = Convert.ToInt32(company[0].Status);
        //        //    string CompanyID = Convert.ToString(company[0].ErrorCode);
        //        //    string ModuleIDs = Convert.ToString(company[0].ErrorMessage);
        //        //    string CompanyName = Convert.ToString(company[0].Balance);

        //        //}


        //        var client = new RestClient("http://sms.thebulksms.in/api/mt/GetBalance?User=alembic&Password=alm%40123");
        //        var request = new RestRequest(Intersoft.Crosslight.RestClient.HttpMethod.POST);
        //        //request.AddHeader("postman-token", "016b0072-8eb8-5411-9a61-a96b1b44caa3");
        //        //request.AddHeader("cache-control", "no-cache");

        //        //IRestResponse<SMS_Balance_API> response = client.Execute<SMS_Balance_API>(request);
        //        //IRestResponse response = client.ExecuteAsyncGet<SMS_Balance_API>(request);
        //        //IRestResponse response = client.ExecuteAsync(request); //.ExecuteAsync(request);

        //        //string inputJson = (new JavaScriptSerializer()).Serialize(input);
        //        //HttpClient client = new HttpClient();
        //        //HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
        //        //HttpResponseMessage response = client.PostAsync(apiUrl + "/GetCustomers", inputContent).Result;
        //        //if (response.IsSuccessStatusCode)
        //        //{
        //        //    List<Customer> customers = (new JavaScriptSerializer()).Deserialize<List<Customer>>(response.Content.ReadAsStringAsync().Result);
        //        //    gvCustomers.DataSource = customers;
        //        //    gvCustomers.DataBind();
        //        //}

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public class SMS_Balance_API
        //{
        //    public string ErrorCode { get; set; }
        //    public string ErrorMessage { get; set; }
        //    public string Balance { get; set; }
        //}

        //public class Send_SMS_API
        //{
        //    public string ErrorCode { get; set; }
        //    public string ErrorMessage { get; set; }
        //}

        //protected void btnSendTestSMS_Click(object sender, EventArgs e)
        //{
        //    lblTestSMSSuccess.Text = "";
        //    lblTestSMSError.Text = "";
        //    try
        //    {
        //        string sAPIKey = "";
        //        string sNumber = txtSendTestSMSMobileNo.Text.Trim();
        //        string sMessage = txtSendTestSMSText.Text.Trim();
        //        string sSenderID = "";
        //        //string sChannel = "Trans";
        //        //string sRoute = "06";
        //        string sResponse = "";
        //        string sURL = "";
        //        string Send_SMS_URL = "";
        //        sAPIKey = Convert.ToString(Session["APIKEY"]);
        //        sSenderID = Convert.ToString(Session["SenderID"]);
        //        Send_SMS_URL = Convert.ToString(Session["SendSMSURL"]);
        //        //if (string.IsNullOrWhiteSpace(txtInput.Text))
        //        //{
        //        //sURL = "http://yourdomain.com/api/mt/SendSMS?APIKEY=" + sAPIKey + "&senderid=" + sSenderID + "&channel=" + sChannel + "&DCS=0&flashsms=0&number=" + sNumber + "&text=" + sMessage + "& route = " + sRoute;
        //        //sURL = "http://sms.thebulksms.in/api/mt/SendSMS?route=06&channel=Trans&DCS=0&flashsms=0" + "&APIKEY=" + sAPIKey + "&senderid=" + sSenderID + "&number=" + sNumber + "&text=" + sMessage;

        //        sURL = Send_SMS_URL + "&APIKEY=" + sAPIKey + "&senderid=" + sSenderID + "&number=" + sNumber + "&text=" + sMessage;
        //        //}
        //        sResponse = GetJSONResponse(sURL);

        //        Send_SMS_API sms = JsonConvert.DeserializeObject<Send_SMS_API>(sResponse);

        //        if (sms.ErrorCode == "000")
        //        {
        //            lblTestSMSSuccess.Text = "Test SMS send successfully";
        //            Session["APIKEY"] = "";
        //            Session["SenderID"] = "";
        //            Session["SendSMSURL"] = "";
        //        }
        //        else
        //        {
        //            lblTestSMSError.Text = "Test SMS failed, Please check config details";
        //        }

        //        //Response.Write(sResponse);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

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