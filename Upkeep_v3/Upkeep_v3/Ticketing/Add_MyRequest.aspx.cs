using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Text;
using System.Configuration;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Upkeep_v3.Ticketing
{
    public partial class Add_MyRequest : System.Web.UI.Page
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
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            if (!IsPostBack)
            {
                //BindLocationDetails(0, 0);
                Fetch_LocationTree();

                if (Convert.ToString(Session["UserType"]) == "R")
                {
                    dvEmployeeLocation.Attributes.Add("style", "display:none");
                    dvRetailerLocation.Attributes.Add("style", "display:block");
                    if (Convert.ToString(Session["Retailer_Location"]) != "")
                    {
                        ddlLocation.SelectedValue = Convert.ToString(Session["Retailer_Location"]);
                        ddlLocation.Enabled = false;
                    }
                }
                else
                {
                    dvEmployeeLocation.Attributes.Add("style", "display:block");
                    dvRetailerLocation.Attributes.Add("style", "display:none");
                }

                Fetch_CategorySubCategory(0);
                Fetch_System_settings();
            }
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
                            ddlZone.DataSource = dsLocDetails.Tables[0];
                            ddlZone.DataTextField = "Zone_Desc";
                            ddlZone.DataValueField = "Zone_ID";
                            ddlZone.DataBind();
                            ddlZone.Items.Insert(0, new ListItem("--Select--", "0"));
                            ddlLocation.Items.Insert(0, new ListItem("--Select--", "0"));
                            ddlSublocation.Items.Insert(0, new ListItem("--Select--", "0"));
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
                            ddlSublocation.DataSource = dsLocDetails.Tables[2];
                            ddlSublocation.DataTextField = "SubLoc_Desc";
                            ddlSublocation.DataValueField = "SubLoc_ID";
                            ddlSublocation.DataBind();
                            ddlSublocation.Items.Insert(0, new ListItem("--Select--", "0"));
                        }
                    }

                    if (dsLocDetails.Tables[3].Rows.Count > 0)
                    {
                        lblCompanyName.Text = Convert.ToString(dsLocDetails.Tables[3].Rows[0]["Company_Desc"]);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Fetch_CategorySubCategory(int CategoryID)
        {
            DataSet dsCategory = new DataSet();
            try
            {

                dsCategory = ObjUpkeep.Fetch_CategorySubCategory(CategoryID, CompanyID);

                if (CategoryID == 0)
                {
                    //ddlCategory.DataSource = dsCategory.Tables[0];
                    //ddlCategory.DataTextField = "Category_Desc";
                    //ddlCategory.DataValueField = "Category_ID";
                    //ddlCategory.DataBind();
                    //ddlCategory.Items.Insert(0, new ListItem("--Select--", "0"));

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
                    ddlSubCategory.DataSource = dsCategory.Tables[0];
                    ddlSubCategory.DataTextField = "SubCategory_Desc";
                    ddlSubCategory.DataValueField = "SubCategory_ID";
                    ddlSubCategory.DataBind();
                    ddlSubCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void ddlZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSublocation.Items.Clear();
            ddlSublocation.Items.Insert(0, new ListItem("--Select--", "0"));
            int ZoneID = 0;
            ZoneID = Convert.ToInt32(ddlZone.SelectedValue);
            BindLocationDetails(ZoneID, 0);
        }

        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ddlSublocation.Items.Clear();
            //ddlSublocation.Items.Insert(0, new ListItem("--Select--", "0"));
            //int ZoneID = 0;
            //int LocationID = 0;
            //ZoneID = Convert.ToInt32(ddlZone.SelectedValue);
            //LocationID = Convert.ToInt32(ddlLocation.SelectedValue);
            //BindLocationDetails(ZoneID, LocationID);
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSublocation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void Fetch_System_settings()
        {
            DataSet dsSetting = new DataSet();
            try
            {
                dsSetting = ObjUpkeep.CRU_System_Setting(0, 0, 0, 0, 0, 0, CompanyID, LoggedInUserID, "R");
                if (dsSetting.Tables.Count > 0)
                {
                    if (dsSetting.Tables[0].Rows.Count > 0)
                    {
                        int Tkt_Is_Img_Open = Convert.ToInt32(dsSetting.Tables[0].Rows[0]["Tkt_Is_Img_Open"]);
                        if (Tkt_Is_Img_Open == 0)
                        {
                            rfvFileupload.Enabled = false;
                        }
                        int Tkt_Is_Img_Close = Convert.ToInt32(dsSetting.Tables[0].Rows[0]["Tkt_Is_Img_Close"]);
                        int Tkt_Is_Remark_Open = Convert.ToInt32(dsSetting.Tables[0].Rows[0]["Tkt_Is_Remark_Open"]);
                        if (Tkt_Is_Remark_Open == 0)
                        {
                            rfvTicketDesc.Enabled = false;
                        }

                        int Tkt_Is_Remark_Close = Convert.ToInt32(dsSetting.Tables[0].Rows[0]["Tkt_Is_Remark_Close"]);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                lblTicketErrorMsg.Text = "";
                string TicketPrefix = string.Empty;
                //int ZoneID = 0;
                int LocationID = 0;
                //int SubLocationID = 0;
                int CategoryID = 0;
                int SubCategoryID = 0;
                string TicketMessage = string.Empty;
                string TicketImages = string.Empty;
                //bool Is_ValidImage = true;
                List<int> Lst_ValidImage = new List<int>();
                List<int> Lst_ImageSaved = new List<int>();
                List<string> Lst_Images = new List<string>();

                StringBuilder ImagesList = new StringBuilder();
                string abc = string.Empty;

                TicketPrefix = Convert.ToString(ConfigurationManager.AppSettings["TicketPrefix"]);
                //ZoneID = Convert.ToInt32(ddlZone.SelectedValue);
                //LocationID = Convert.ToInt32(ddlLocation.SelectedValue);

                LocationID = Convert.ToInt32(hdnassetLocation.Value);

                //SubLocationID = Convert.ToInt32(ddlSublocation.SelectedValue);
                //CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                CategoryID = Convert.ToInt32(hdnCategory.Value);
                SubCategoryID = Convert.ToInt32(ddlSubCategory.SelectedValue);
                TicketMessage = txtTicketDesc.Text.Trim();

                string fileName = string.Empty;
                string TicketCode = string.Empty;

                string CurrentDate = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));

                TicketCode = Convert.ToString(Session["NextTicketCode"]);


                //if (FileUpload_TicketImage.HasFile)
                //{
                string fileUploadPath = HttpContext.Current.Server.MapPath("~/TicketImages/" + CurrentDate);

                if (!Directory.Exists(fileUploadPath))
                {
                    Directory.CreateDirectory(fileUploadPath);
                }

                int i = 0;
                if (FileUpload_TicketImage.HasFile)
                {
                    foreach (HttpPostedFile postfiles in FileUpload_TicketImage.PostedFiles)
                    {

                        //IsExeFile(Server.MapPath(FileUpload_TicketImage.FileName));

                        string filetype = Path.GetExtension(postfiles.FileName);
                        if (filetype.ToLower() == ".jpg" || filetype.ToLower() == ".png")
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
                        //for (int i = 0; i < FileUpload_TicketImage.PostedFiles.Count; i++)
                        //{

                        string filetype = Path.GetExtension(postfiles.FileName);
                        if (filetype.ToLower() == ".jpg" || filetype.ToLower() == ".png")
                        {
                            try
                            {

                                fileName = TicketCode + "_" + Convert.ToString(i) + filetype;
                                //fileName = postfiles.FileName;

                                string imgPath = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadURL"]);

                                //string fileUploadPath = HttpContext.Current.Server.MapPath("~/TicketImages/" + fileName);
                                // FileUpload_TicketImage.SaveAs(Server.MapPath("~/") + fileName);

                                string SaveLocation = Server.MapPath("~/TicketImages/" + CurrentDate) + "/" + fileName;
                                string FileLocation = imgPath + "/TicketImages/" + CurrentDate + "/" + fileName;
                                //string SaveLocation = Server.MapPath(filePath) + fileName;
                                //File.Copy(SaveLocation, imgPath);

                                //[+][Size Compress]
                                string ImageName = Path.GetFileName(postfiles.FileName);
                                //string storedb = "Images/" + ImageName + "";
                                //string targetPath = Server.MapPath("Images/" + ImageName);
                                Stream strm = postfiles.InputStream;  //FileUpload_TicketImage.PostedFile.InputStream;
                                var targetFile = SaveLocation;
                                //ReduceImageSize(0.5, strm, targetFile);
                                //GenerateThumbnails(0.5, strm, targetFile);
                                //[-][Size Compress]



                                //string SaveLocation = Server.MapPath(imgPath) + fileName;

                                if (!Lst_ValidImage.Contains(0))
                                {
                                    //FileUpload_TicketImage.PostedFile.SaveAs(SaveLocation);
                                    postfiles.SaveAs(SaveLocation);
                                    //Lst_Images.Add(SaveLocation);
                                    Lst_Images.Add(FileLocation);
                                }

                                //ImagesList.Append(fileName);
                                //abc += fileName;
                            }
                            catch (Exception ex)
                            {

                                //Is_ImageSaved = false;
                                Lst_ImageSaved.Add(0); // Image failed to save
                                throw ex;
                            }
                        }
                        else
                        {
                            //Is_ValidImage = false;
                            Lst_ValidImage.Add(0);  // image extension is not proper
                        }
                        //}

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
                //else
                //{
                //Save details       
                DataSet dsTicketSave = new DataSet();
                try
                {
                    string list_Images = String.Join(",", Lst_Images);

                    //string title = "Greetings";
                    //string body = "Welcome to ASPSnippets.com";
                    //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);

                    dsTicketSave = ObjUpkeep.Insert_Ticket_Details(TicketCode, CompanyID, LocationID, CategoryID, SubCategoryID, TicketMessage, list_Images, LoggedInUserID, "C");
                    //mpeTicketSaveSuccess.Show();

                    if (dsTicketSave.Tables.Count > 0)
                    {
                        if (dsTicketSave.Tables[0].Rows.Count > 0)
                        {
                            int Status = Convert.ToInt32(dsTicketSave.Tables[0].Rows[0]["Status"]);
                            if (Status == 1)
                            {
                                //Send SMS
                                string APIKey = string.Empty;
                                string SenderID = string.Empty;
                                string Send_SMS_URL = string.Empty;
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

                                //Category = Convert.ToString(ddlCategory.SelectedItem.Text);
                                Category = Convert.ToString(hdnCategory.Value);
                                
                                Location = Convert.ToString(ddlLocation.SelectedItem.Text);
                                Department = Convert.ToString(Session["Department"]);

                                if (dsTicketSave.Tables.Count > 1)
                                {
                                    if (dsTicketSave.Tables[1].Rows.Count > 0)
                                    {
                                        APIKey = Convert.ToString(dsTicketSave.Tables[1].Rows[0]["Api_Key"]);
                                        SenderID = Convert.ToString(dsTicketSave.Tables[1].Rows[0]["Sender_ID"]);
                                        Send_SMS_URL = Convert.ToString(dsTicketSave.Tables[1].Rows[0]["Send_SMS_URL"]);

                                        Send_SMS_URL = Send_SMS_URL.Replace("%26", "&");

                                        SendSMS sms = new SendSMS();
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
                                            TextMessage += "%0a%0aPlease accept the ticket to take further Action.";

                                            if (APIKey != "")
                                            {
                                                //Send SMS only when the user has access to send SMS in workflow
                                                if (Is_SMS_Send > 0)
                                                {
                                                    string response = sms.Send_SMS(APIKey, SenderID, Send_SMS_URL, MobileNo, TextMessage);
                                                }
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

                                        if (APIKey != "")
                                        {
                                            string response_raisedBy = sms.Send_SMS(APIKey, SenderID, Send_SMS_URL, TicketRaisedBy_MobileNo, TextMessage_RaisedBy);
                                        }
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

                                        //await SendNotification(TokenNO, "Ticket No: " + Convert.ToString(dsGpHeaderData.Tables[1].Rows[0]["RequestID"]), "New Gatepass Request");
                                        //Send app notification only when the user has access to send app notification in workflow
                                        if (Is_App_Notification_Send > 0)
                                        {
                                            await SendNotification(TokenNO, TicketID, "Ticket No. " + TicketNo + ". New Ticket Received.", NotificationMsg);
                                        }
                                    }
                                }
                                // Send SMS
                                lblTicketCode.Text = TicketCode;
                                Session["NextTicketCode"] = "";
                                Session["Department"] = "";
                                mpeTicketSaveSuccess.Show();
                            }
                        }
                    }


                }

                catch (Exception ex)
                {
                    throw ex;
                }
                //}
                //}
                //else
                //{
                //    lblTicketErrorMsg.Text = "Please select image";
                //    FileUpload_TicketImage.Focus();
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CategoryID = Convert.ToInt32(hdnCategory.Value);
            Fetch_CategorySubCategory(CategoryID);

            //btnViewWorkflow.Attributes.Add("class", "btn btn-accent  m-btn m-btn--icon dark disabled");
            //btnViewWorkflow.Attributes.Add("style", "pointer-events: none;;padding: 0.45rem 1.15rem;");

            int SubCategoryID = 0;
            SubCategoryID = Convert.ToInt32(ddlSubCategory.SelectedValue);
            btnViewWorkflow.Attributes.Add("class", "btn btn-accent  m-btn m-btn--icon");
            btnViewWorkflow.Attributes.Add("style", "pointer-events: painted;padding: 0.45rem 1.15rem;");

            BindWorkflow(CategoryID, SubCategoryID);

            dvDepartment.Attributes.Add("style", "display:block; padding-left: 10%;");
        }

        protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnViewWorkflow.Attributes.Add("class", "btn btn-accent  m-btn m-btn--icon");
            btnViewWorkflow.Attributes.Add("style", "pointer-events: painted;padding: 0.45rem 1.15rem;");

            //int ZoneID = 0;
            int SubCategoryID = 0;
            int CategoryID = 0;
            //ZoneID = Convert.ToInt32(ddlZone.SelectedValue);
            CategoryID = Convert.ToInt32(hdnCategory.Value);
            SubCategoryID = Convert.ToInt32(ddlSubCategory.SelectedValue);
            BindWorkflow(CategoryID, SubCategoryID);

            dvDepartment.Attributes.Add("style", "display:block; padding-left: 18%;");
        }

        protected void btnViewWorkflow_Click(object sender, EventArgs e)
        {
            mpeWorkflow.Show();

            //int ZoneID = 0;
            int SubCategoryID = 0;
            int CategoryID = 0;
            //ZoneID = Convert.ToInt32(ddlZone.SelectedValue);
            CategoryID = Convert.ToInt32(hdnCategory.Value);
            SubCategoryID = Convert.ToInt32(ddlSubCategory.SelectedValue);
            BindWorkflow(CategoryID, SubCategoryID);


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
                    if (dsWorkflow.Tables[0].Rows.Count > 0)
                    {
                        gvWorkflow.DataSource = dsWorkflow;
                        gvWorkflow.DataBind();
                    }
                    else
                    {
                        gvWorkflow.DataSource = null;
                        gvWorkflow.DataBind();
                    }

                    //if (dsWorkflow.Tables[1].Rows.Count > 0)
                    //{
                    //    ddlApprover.DataSource = dsWorkflow.Tables[1];
                    //    ddlApprover.DataTextField = "Approver";
                    //    ddlApprover.DataValueField = "User_ID";
                    //    ddlApprover.DataBind();
                    //    ddlApprover.Items.Insert(0, new ListItem("--Select--", "0"));
                    //}
                    //else
                    //{
                    //    ddlApprover.Items.Clear();
                    //    ddlApprover.Items.Insert(0, new ListItem("--Select--", "0"));
                    //}
                    if (dsWorkflow.Tables[1].Rows.Count > 0)
                    {
                        lblDepartmentName.Text = Convert.ToString(dsWorkflow.Tables[1].Rows[0]["Dept_Desc"]);
                        Session["Department"] = Convert.ToString(dsWorkflow.Tables[1].Rows[0]["Dept_Desc"]);
                    }

                    if (dsWorkflow.Tables[2].Rows.Count > 0)
                    {
                        Session["NextTicketCode"] = Convert.ToString(dsWorkflow.Tables[2].Rows[0]["NextTicketCode"]);
                    }

                }
                else
                {
                    //ddlApprover.Items.Clear();
                    //ddlApprover.Items.Insert(0, new ListItem("--Select--", "0"));

                    gvWorkflow.DataSource = null;
                    gvWorkflow.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void btnTicketSuccessOk_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Ticketing/MyRequest.aspx"), false);
        }

        public static async Task SendNotification(string TokenNo, int TransactionID, string NotificationHeader, string NotificationMsg)
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
                //HttpResponseMessage response = await client.GetAsync("FunSendAppNotification?StrTokenNumber=" + TokenNo + "&TransactionID=" + TicketID + "&TicketNo=" + TicketNo + "&StrMessage=" + strMessage + "&click_action=" + "TICKET");
                HttpResponseMessage response = await client.GetAsync("FunSendAppNotification?StrTokenNumber=" + TokenNo + "&TransactionID=" + TransactionID + "&NotificationHeader=" + NotificationHeader + "&NotificationMsg=" + NotificationMsg + "&click_action=" + "TICKET");

                if (response.IsSuccessStatusCode)
                {
                    //Departmentdepartment = awaitresponse.Content.ReadAsAsync<Department>();
                    //Console.WriteLine("Id:{0}\tName:{1}", department.DepartmentId, department.DepartmentName);
                    //Console.WriteLine("No of Employee in Department: {0}", department.Employees.Count);
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
        }

        private void ReduceImageSize(double scaleFactor, Stream sourcePath, string targetPath)
        {
            using (var image = System.Drawing.Image.FromStream(sourcePath))
            {
                var newWidth = (int)(image.Width * scaleFactor);
                var newHeight = (int)(image.Height * scaleFactor);
                //var thumbnailImg = new Bitmap(newWidth, newHeight);
                //var thumbGraph = Graphics.FromImage(thumbnailImg);
                //thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                //thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                //thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                //var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                //thumbGraph.DrawImage(image, imageRectangle);
                //thumbnailImg.Save(targetPath, image.RawFormat);

                Bitmap newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);
                using (Graphics gr = Graphics.FromImage(newImage))
                {
                    gr.SmoothingMode = SmoothingMode.HighQuality;
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    gr.DrawImage(image, new Rectangle(0, 0, newWidth, newHeight));

                }
                // Get an ImageCodecInfo object that represents the JPEG codec.
                ImageCodecInfo imageCodecInfo = this.GetEncoderInfo(ImageFormat.Jpeg);

                // Create an Encoder object for the Quality parameter.
                System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Quality;

                // Create an EncoderParameters object. 
                EncoderParameters encoderParameters = new EncoderParameters(1);

                // Save the image as a JPEG file with quality level.
                EncoderParameter encoderParameter = new EncoderParameter(encoder, 50);
                encoderParameters.Param[0] = encoderParameter;
                newImage.Save(targetPath, imageCodecInfo, encoderParameters);
            }
        }

        private void GenerateThumbnails(double scaleFactor, Stream sourcePath, string targetPath)
        {
            using (var image = System.Drawing.Image.FromStream(sourcePath))
            {
                var newWidth = (int)(image.Width * scaleFactor);
                var newHeight = (int)(image.Height * scaleFactor);
                var thumbnailImg = new Bitmap(newWidth, newHeight);
                var thumbGraph = Graphics.FromImage(thumbnailImg);
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbGraph.DrawImage(image, imageRectangle);
                thumbnailImg.Save(targetPath, image.RawFormat);
            }
        }

        private ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            return ImageCodecInfo.GetImageDecoders().SingleOrDefault(c => c.FormatID == format.Guid);
        }

        public bool IsExeFile(string path)
        {
            var twoBytes = new byte[2];
            using (var fileStream = File.Open(path, FileMode.Open))
            {
                fileStream.Read(twoBytes, 0, 2);
            }

            return Encoding.UTF8.GetString(twoBytes) == "MZ";
        }


    }
}