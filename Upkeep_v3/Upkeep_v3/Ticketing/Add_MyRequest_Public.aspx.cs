using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Upkeep_v3.SMS;

namespace Upkeep_v3.Ticketing
{
    public partial class Add_MyRequest_Public : System.Web.UI.Page
    {

        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        public static int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //string Decrypt_CompanyID = DecryptString(Request.QueryString["cid"].ToString());
            //CompanyID = Convert.ToInt32(Decrypt_CompanyID);

            CompanyID= Convert.ToInt32(Request.QueryString["cid"]);
            if (!IsPostBack)
            {
                Fetch_LocationTree();
                Fetch_CategorySubCategory(0);
                Fetch_System_settings();
                hdnIs_Retailer.Value = "0";
                dvEmployeeLocation.Attributes.Add("style", "display:block");
                dvRetailerLocation.Attributes.Add("style", "display:none");
            }
        }

        public void Fetch_System_settings()
        {
            DataSet dsSetting = new DataSet();
            try
            {
                dsSetting = ObjUpkeep.CRU_System_Setting(0, 0, 0, 0, 0, 0, 0, 0, 0, CompanyID, LoggedInUserID, "R");
                if (dsSetting.Tables.Count > 0)
                {
                    if (dsSetting.Tables[0].Rows.Count > 0)
                    {
                        int Tkt_Is_Img_Open_QR = Convert.ToInt32(dsSetting.Tables[0].Rows[0]["Tkt_Is_Img_Open_QR_Public"]);
                        if (Tkt_Is_Img_Open_QR == 0)
                        {
                            rfvFileupload.Enabled = false;
                        }
                       
                        int Tkt_Is_Remark_Open_QR = Convert.ToInt32(dsSetting.Tables[0].Rows[0]["Tkt_Is_Remark_Open_QR_Public"]);
                        if (Tkt_Is_Remark_Open_QR == 0)
                        {
                            rfvTicketDesc.Enabled = false;
                        }

                       
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DecryptString(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }
            return decrypted;
        }

        protected void ddlSublocation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void BindLocationDetails(int ZoneID, int LocationID)
        {
            DataSet dsLocDetails = new DataSet();
            try
            {
                dsLocDetails = ObjUpkeep.BindLocationDetails(ZoneID, LocationID);

                if (dsLocDetails.Tables.Count > 0)
                {
                    if (ZoneID == 0)
                    {
                        if (dsLocDetails.Tables[0].Rows.Count > 0)
                        {
                            ddlLocation.Items.Insert(0, new ListItem("--Select--", "0"));
                            //ddlSublocation.Items.Insert(0, new ListItem("--Select--", "0"));
                        }
                    }
                    if (ZoneID > 0 && LocationID == 0)
                    {
                        if (dsLocDetails.Tables[1].Rows.Count > 0)
                        {
                            ddlLocation.DataSource = dsLocDetails.Tables[1];
                            ddlLocation.DataTextField = "Loc_Desc";
                            ddlLocation.DataValueField = "Loc_ID";
                            ddlLocation.DataBind();
                            ddlLocation.Items.Insert(0, new ListItem("--Select--", "0"));
                        }
                    }
                    if (LocationID > 0)
                    {
                        if (dsLocDetails.Tables[2].Rows.Count > 0)
                        {
                            //ddlSublocation.DataSource = dsLocDetails.Tables[2];
                            //ddlSublocation.DataTextField = "SubLoc_Desc";
                            //ddlSublocation.DataValueField = "SubLoc_ID";
                            //ddlSublocation.DataBind();
                            //ddlSublocation.Items.Insert(0, new ListItem("--Select--", "0"));
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCategoryChange_Click(object sender, EventArgs e)
        {
            int CategoryID = Convert.ToInt32(hdnCategory.Value);
            Fetch_CategorySubCategory(CategoryID);
            int SubCategoryID = 0;
            if (Convert.ToString(hdnSubCategory.Value) != "")
            {
                SubCategoryID = Convert.ToInt32(hdnSubCategory.Value);
            }
            BindWorkflow(CategoryID, SubCategoryID);
        }

        public void Fetch_CategorySubCategory(int CategoryID)
        {
            DataSet dsCategory = new DataSet();
            try
            {
                dsCategory = ObjUpkeep.Fetch_CategorySubCategory(CategoryID, CompanyID);
                if (CategoryID == 0)
                {
                    var builder = new System.Text.StringBuilder();
                    for (int i = 0; i < dsCategory.Tables[0].Rows.Count; i++)
                    {
                        builder.Append(String.Format("<option value='{0}' text='{1}'>", dsCategory.Tables[0].Rows[i]["Category_Desc"], dsCategory.Tables[0].Rows[i]["Category_ID"]));
                    }
                    dlCategory.InnerHtml = builder.ToString();
                    dlCategory.DataBind();

                }
                else if (CategoryID > 0)
                {
                    var builder = new System.Text.StringBuilder();
                    for (int i = 0; i < dsCategory.Tables[0].Rows.Count; i++)
                    {
                        builder.Append(String.Format("<option value='{0}' text='{1}'>", dsCategory.Tables[0].Rows[i]["SubCategory_Desc"], dsCategory.Tables[0].Rows[i]["SubCategory_ID"]));
                    }
                    dlSubCategory.InnerHtml = builder.ToString();
                    dlSubCategory.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindWorkflow(int CategoryID, int SubCategoryID)
        {
            DataSet dsWorkflow = new DataSet();
            try
            {
                string TicketPrefix = string.Empty;
                TicketPrefix = Convert.ToString(ConfigurationManager.AppSettings["TicketPrefix"]);
                dsWorkflow = ObjUpkeep.Fetch_Ticket_Workflow(CompanyID, CategoryID, SubCategoryID, TicketPrefix, LoggedInUserID);

                if (dsWorkflow.Tables.Count > 0)
                {
                    if (dsWorkflow.Tables[1].Rows.Count > 0)
                    {
                        //  lblDepartmentName.InnerText = Convert.ToString(dsWorkflow.Tables[1].Rows[0]["Dept_Desc"]);
                        Session["Department"] = Convert.ToString(dsWorkflow.Tables[1].Rows[0]["Dept_Desc"]);
                    }

                    if (dsWorkflow.Tables[2].Rows.Count > 0)
                    {
                        Session["NextTicketCode"] = Convert.ToString(dsWorkflow.Tables[2].Rows[0]["NextTicketCode"]);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSubCategoryChange_Click(object sender, EventArgs e)
        {
            int SubCategoryID = 0;
            int CategoryID = 0;
            CategoryID = Convert.ToInt32(hdnCategory.Value);
            SubCategoryID = Convert.ToInt32(hdnSubCategory.Value);
            BindWorkflow(CategoryID, SubCategoryID);
            //  dvDepartment.Attributes.Add("style", "display:block;");
        }

        protected void btnViewWorkflow_Click(object sender, EventArgs e)
        {
            //  mpeWorkflow.Show();
            int SubCategoryID = 0;
            int CategoryID = 0;
            CategoryID = Convert.ToInt32(hdnCategory.Value);
            if (!string.IsNullOrEmpty(hdnSubCategory.Value))
                SubCategoryID = Convert.ToInt32(hdnSubCategory.Value);
            else
                SubCategoryID = 0;
            BindWorkflow(CategoryID, SubCategoryID);
        }

        public void Fetch_LocationTree()
        {
            DataSet dsLocDetails = new DataSet();
            try
            {
                dsLocDetails = ObjUpkeep.Fetch_LocationTree(CompanyID);

                if (dsLocDetails.Tables.Count > 0)
                {
                    if (dsLocDetails.Tables[0].Rows.Count > 0)
                    {
                        ddlLocation.DataSource = dsLocDetails.Tables[0];
                        ddlLocation.DataTextField = "Loc_Desc";
                        ddlLocation.DataValueField = "Loc_ID";
                        ddlLocation.DataBind();
                        ddlLocation.Items.Insert(0, new ListItem("--Select--", "0"));

                        var builder = new System.Text.StringBuilder();

                        for (int i = 0; i < dsLocDetails.Tables[0].Rows.Count; i++)
                        {
                            builder.Append(String.Format("<option value='{0}' text='{1}'>", dsLocDetails.Tables[0].Rows[i]["Loc_Desc"], dsLocDetails.Tables[0].Rows[i]["Loc_id"]));
                        }
                        dlassetLocation.InnerHtml = builder.ToString();
                        dlassetLocation.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SavePublicTicket();
        }

        protected async void SavePublicTicket()
        {
            try
            {
                #region Variable Declaration
                bool IsPublicTicket = true;
                string UserName = txtName.Text.Trim();
                string UserEmail = txtEmail.Text.Trim();
                string UserMobile = txtPhone.Text.Trim();
                string UserDesc = txtTicketDesc.Text.Trim();
                int LocationID = Convert.ToInt32(hdnassetLocation.Value);
                int CategoryID = 0;
                int SubCategoryID = 0;
                if (!string.IsNullOrEmpty(hdnCategory.Value))
                    CategoryID = Convert.ToInt32(hdnCategory.Value);
                if (!string.IsNullOrEmpty(hdnSubCategory.Value))
                    SubCategoryID = Convert.ToInt32(hdnSubCategory.Value);
                string CurrentDate = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));
                List<int> Lst_ValidImage = new List<int>();
                List<int> Lst_ImageSaved = new List<int>();
                List<string> Lst_Images = new List<string>();
                string fileName = "1";
                string TicketCode = Convert.ToString(Session["NextTicketCode"]);
                int i = 0;
                #endregion

                #region Image Upload
                string fileUploadPath = HttpContext.Current.Server.MapPath("~/TicketImages/" + CurrentDate);

                if (!Directory.Exists(fileUploadPath))
                {
                    Directory.CreateDirectory(fileUploadPath);
                }

                if (FileUpload_TicketImage.HasFile)
                {
                    foreach (HttpPostedFile postfiles in FileUpload_TicketImage.PostedFiles)
                    {
                        string filetype = Path.GetExtension(postfiles.FileName);
                        if (filetype.ToLower() == ".jpg" || filetype.ToLower() == ".jpeg" || filetype.ToLower() == ".png")
                        {
                            Lst_ValidImage.Add(1);
                        }
                        else
                        {
                            Lst_ValidImage.Add(0);
                        }
                    }
                    foreach (HttpPostedFile postfiles in FileUpload_TicketImage.PostedFiles)
                    {
                        string filetype = Path.GetExtension(postfiles.FileName);
                        if (filetype.ToLower() == ".jpg" || filetype.ToLower() == ".jpeg" || filetype.ToLower() == ".png")
                        {
                            try
                            {

                                fileName = TicketCode + "_" + Convert.ToString(i) + filetype;
                                string imgPath = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadURL"]);
                                string SaveLocation = Server.MapPath("~/TicketImages/" + CurrentDate) + "/" + fileName;
                                string FileLocation = imgPath + "/TicketImages/" + CurrentDate + "/" + fileName;

                                string ImageName = Path.GetFileName(postfiles.FileName);
                                Stream strm = postfiles.InputStream;  //FileUpload_TicketImage.PostedFile.InputStream;
                                var targetFile = SaveLocation;
                                if (!Lst_ValidImage.Contains(0))
                                {
                                    postfiles.SaveAs(SaveLocation);
                                    Lst_Images.Add(FileLocation);
                                }
                            }
                            catch (Exception ex)
                            {
                                Lst_ImageSaved.Add(0);
                                throw ex;
                            }
                        }
                        else
                        {
                            Lst_ValidImage.Add(0);
                        }

                        i = i + 1;
                    }
                    if (Lst_ValidImage.Contains(0))
                    {
                        lblTicketErrorMsg.Text = "Image format not supported";
                        FileUpload_TicketImage.Focus();
                    }
                    else if (Lst_ImageSaved.Contains(0))
                    {
                        lblTicketErrorMsg.Text = "Image upload failed, please try again";
                        txtTicketDesc.Focus();
                    }
                }
                #endregion

                #region Save Public Ticket
                DataSet dsTicketSave = new DataSet();
                string list_Images = String.Join(",", Lst_Images);
                dsTicketSave = ObjUpkeep.Insert_Ticket_Details(TicketCode, CompanyID, LocationID, CategoryID, SubCategoryID, UserDesc, list_Images, string.Empty, string.Empty, IsPublicTicket, UserName, UserMobile, UserEmail,"","", "C");
                if (dsTicketSave.Tables.Count > 0)
                {
                    if (dsTicketSave.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsTicketSave.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            //Send SMS
                            string Send_SMS_URL = string.Empty;
                            string User_ID = string.Empty;
                            string Password = string.Empty;
                            string MobileNo = string.Empty;
                            string TextMessage = string.Empty;
                            string Department = string.Empty;
                            string Category = string.Empty;
                            string Location = string.Empty;

                            string TicketRaisedBy_FirstName = string.Empty;
                            string TicketRaisedBy_MobileNo = string.Empty;
                            string TextMessage_RaisedBy = string.Empty;
                            string TicketRaisedBy_DepartmentName = string.Empty;

                            string StoreManager_Name = string.Empty;
                            string Store_Name = string.Empty;
                            string Store_No = string.Empty;

                            Category = Convert.ToString(hdnCategory.Value);

                            Location = Convert.ToString(ddlLocation.SelectedItem.Text);
                            Department = Convert.ToString(Session["Department"]);

                            if (dsTicketSave.Tables.Count > 1)
                            {
                                if (dsTicketSave.Tables[1].Rows.Count > 0)
                                {
                                    Send_SMS_URL = Convert.ToString(dsTicketSave.Tables[1].Rows[0]["Send_SMS_URL"]);
                                    User_ID = Convert.ToString(dsTicketSave.Tables[1].Rows[0]["User_ID"]);
                                    Password = Convert.ToString(dsTicketSave.Tables[1].Rows[0]["Password"]);

                                    Send_SMS_URL = Send_SMS_URL.Replace("%26", "&");

                                    Send_eFacilito_SMS sms1 = new Send_eFacilito_SMS();


                                    foreach (DataRow dr in dsTicketSave.Tables[2].Rows)
                                    {
                                        string FirstName = Convert.ToString(dr["FirstName"]);
                                        MobileNo = Convert.ToString(dr["MobileNo"]);
                                        TicketRaisedBy_FirstName = Convert.ToString(dr["TicketRaisedBy"]);
                                        TicketRaisedBy_MobileNo = Convert.ToString(dr["TicketRaisedByMobileNo"]);
                                        int Is_SMS_Send = Convert.ToInt32(dr["Is_SMS_Send"]);

                                        TextMessage = "Dear " + FirstName + ",";
                                        if (Convert.ToString(Session["UserType"]) == "E")
                                        {
                                            TextMessage += "%0a%0aA ticket " + TicketCode + " has been raised by " + TicketRaisedBy_FirstName + " from " + Department + " Department.";
                                        }
                                        else
                                        {
                                            StoreManager_Name = Convert.ToString(Session["StoreManager_Name"]);
                                            Store_Name = Convert.ToString(Session["StoreName"]);
                                            Store_No = Convert.ToString(Session["StoreNo"]);

                                            TextMessage += "%0a%0aA ticket " + TicketCode + " has been raised by " + StoreManager_Name + " from " + Store_Name + " - " + Store_No + " store.";
                                        }
                                        TextMessage += "%0a%0aCategory :" + Category;
                                        TextMessage += "%0aLocation :" + Location;
                                        TextMessage += "%0aStatus : OPEN(Assigned)";
                                        TextMessage += "%0aLevel : 1";
                                        TextMessage += "%0a%0aLogn to eFacilito and accept the ticket to take further action";



                                        //Send SMS only when the user has access to send SMS in workflow
                                        if (Is_SMS_Send > 0)
                                        {
                                            //string response = sms.Send_SMS(APIKey, SenderID, Send_SMS_URL, MobileNo, TextMessage);
                                            //string response = sms1.Send_SMS("https://www.businesssms.co.in/smsaspx?", "compel.admin@compelconsultancy.com", "Compel@12345", "9920874488", "Dear%20Lokesh,%20A%20ticket%20TKT3547%20has%20been%20raised%20by%20Ajay%20from%20Operations%20Department.%20Category%20:%20Housekeeping%20Location%20:1st%20Floor%3E34th%20Room%20Status%20:%20OPEN%20Level%20:%201%20Logn%20to%20eFacilito%20and%20accept%20the%20ticket%20to%20take%20further%20action.", "1007940892573975122");
                                            string response = sms1.Send_SMS(Send_SMS_URL, User_ID, Password, MobileNo, TextMessage, "1007940892573975122");

                                        }
                                    }

                                    if (Convert.ToString(Session["UserType"]) == "E")
                                    {
                                        TextMessage_RaisedBy = "Dear " + TicketRaisedBy_FirstName + ",";
                                    }
                                    else
                                    {
                                        StoreManager_Name = Convert.ToString(Session["StoreManager_Name"]);
                                        TextMessage_RaisedBy = "Dear " + StoreManager_Name + ",";
                                    }
                                    TextMessage_RaisedBy += "%0a%0aYour ticket " + TicketCode + " has been raised successfully & has been sent to the users of " + Department + " Department.";

                                    string response_raisedBy = sms1.Send_SMS(Send_SMS_URL, User_ID, Password, TicketRaisedBy_MobileNo, TextMessage, "1007940892573975122");


                                }
                            }

                            // Send App Notifications
                            string NotificationMsg = string.Empty;
                            TicketRaisedBy_DepartmentName = Convert.ToString(dsTicketSave.Tables[0].Rows[0]["TicketRaisedBy_Department_Name"]);
                            string TicketRaisedBy_Name = Convert.ToString(dsTicketSave.Tables[0].Rows[0]["TicketRaisedBy_FName"]);
                            if (dsTicketSave.Tables.Count > 3)
                            {
                                if (Convert.ToString(Session["UserType"]) == "E")
                                {
                                    NotificationMsg = "A ticket has been raised by " + TicketRaisedBy_Name + " from " + TicketRaisedBy_DepartmentName + " Department. Tap to Accept";
                                }
                                else
                                {
                                    StoreManager_Name = Convert.ToString(Session["StoreManager_Name"]);
                                    Store_Name = Convert.ToString(Session["StoreName"]);
                                    Store_No = Convert.ToString(Session["StoreNo"]);

                                    NotificationMsg = "A ticket has been raised by " + StoreManager_Name + " from " + Store_Name + " - " + Store_No + " store. Tap to Accept";

                                }

                                foreach (DataRow dr in dsTicketSave.Tables[3].Rows)
                                {
                                    var TokenNO = Convert.ToString(dr["TokenNumber"]);
                                    var TicketID = Convert.ToInt32(dr["TicketID"]);
                                    var TicketNo = Convert.ToString(dr["TicketNo"]);
                                    int Is_App_Notification_Send = Convert.ToInt32(dr["Is_App_Notification_Send"]);

                                    if (Is_App_Notification_Send > 0)
                                    {
                                        await SendNotification(TokenNO, TicketID, "Ticket No. " + TicketNo + ". New Ticket Received.", NotificationMsg);
                                    }
                                }
                            }
                        }
                    }

                    lblTicketCode.Text = TicketCode;
                    mpeTicketSaveSuccess.Show();
                    ClearControlls();
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task SendNotification(string TokenNo, int TransactionID, string NotificationHeader, string NotificationMsg)
        {
            //TokenNo = "eSkpv5ZFSGip9BpPA0J2FE:APA91bEBZfqr4bvP7gIzfCdAcjTYU4uPYVMTvz4264ID5q32EfViLz2eRAqSb8tEuajK3l7LORQthSTnV_NMswAy2jXtbjfGyOEfafkijorMe5oAm9NjlUG1TJXGd0t6smmZN1r3mkTE";
            using (var client = new HttpClient())
            {
                //Send HTTP requests from here.  
                string API_URL = Convert.ToString(ConfigurationManager.AppSettings["API_URL"]);
                client.BaseAddress = new Uri(API_URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage response = await client.GetAsync("FunSendAppNotification?StrTokenNumber=" + TokenNo + "&TransactionID=" + TransactionID + "&NotificationHeader=" + NotificationHeader + "&NotificationMsg=" + NotificationMsg + "&click_action=" + "TICKET");

                if (response.IsSuccessStatusCode)
                {
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
        }

        protected void ClearControlls()
        {
            Session["NextTicketCode"] = "";
            Session["Department"] = "";
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtTicketDesc.Text = string.Empty;
            hdnassetLocation.Value = string.Empty;
            hdnCategory.Value = string.Empty;
            hdnSubCategory.Value = string.Empty;
            FileUpload_TicketImage.PostedFile.InputStream.Dispose();
        }

        protected void btnTicketSuccessOk_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Ticketing/Add_MyRequest_Public.aspx"), false);
        }
    }
}