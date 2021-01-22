using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Text;
using System.IO;

namespace Upkeep_v3.Ticketing
{
    public partial class My_RequestRply : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        int TicketID = 0;
        int MyRequest = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            TicketID = Convert.ToInt32(Request.QueryString["TicketID"]);
            MyRequest = Convert.ToInt32(Request.QueryString["MyRequest"]);

            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }

            if (TicketID > 0)
            {
                Session["TicketID"] = Convert.ToString(TicketID);

                if (MyRequest == 1)
                {
                    Fetch_My_Request_Ticket_Details(TicketID);
                    dvTicketAction.Attributes.Add("style", "display:none;");
                    dvAccept.Attributes.Add("style", "display:none;");
                    //dvApprovalDetails.Attributes.Add("style", "display:none;");
                    //dvClose.Attributes.Add("style", "display:none;");
                }
                else
                {
                    Fetch_My_Actionable_Ticket_Details(TicketID);
                    Fetch_System_settings();
                }
            }


        }

        public string Fetch_My_Request_Ticket_Details(int TicketID)
        {
            string data = "";
            DataSet dsTicket = new DataSet();
            try
            {
                dsTicket = ObjUpkeep.Insert_Ticket_Details((Request.QueryString["TicketID"]), CompanyID, 0, 0, 0, "", "", LoggedInUserID, "R");

                // int TicketID = 0;
                string TicketNumber = string.Empty;
                string Zone = string.Empty;
                string Location = string.Empty;
                string SubLocation = string.Empty;
                string Category = string.Empty;
                string SubCategory = string.Empty;
                string RequestDate = string.Empty;
                string RequestStatus = string.Empty;
                string ActionStatus = string.Empty;


                if (dsTicket.Tables.Count > 0)
                {
                    if (dsTicket.Tables[0].Rows.Count > 0)
                    {
                        //int count = Convert.ToInt32(dsTicket.Tables[0].Rows.Count);

                        //for (int i = 0; i < count; i++)
                        //{
                        Session["TicketCode"] = dsTicket.Tables[0].Rows[0].Field<string>("Tkt_Code"); //ajay
                        lblTicketNo.Text = dsTicket.Tables[0].Rows[0].Field<string>("Tkt_Code");
                        lblLocation.Text = dsTicket.Tables[0].Rows[0].Field<string>("Loc_Desc");
                        lblCategory.Text = dsTicket.Tables[0].Rows[0].Field<string>("Category_Desc");
                        lblSubCategory.Text = dsTicket.Tables[0].Rows[0].Field<string>("SubCategory_Desc");
                        lblRequestDate.Text = dsTicket.Tables[0].Rows[0].Field<string>("Ticket_Date");
                        lblTicketdesc.Text = dsTicket.Tables[0].Rows[0].Field<string>("Tkt_Message");
                        lblTicketRaisedBy.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["RaisedBy"]);

                        lblRaisedImageCount.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["TicketRaised_Image_Count"]);
                        if (Convert.ToInt32(dsTicket.Tables[0].Rows[0]["TicketRaised_Image_Count"]) == 0)
                        {
                            dvRaiseImage.Attributes.Add("style", "display:none");
                        }

                        lblClosedImageCount.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["TicketClosed_Image_Count"]);
                        if (Convert.ToInt32(dsTicket.Tables[0].Rows[0]["TicketClosed_Image_Count"]) == 0)
                        {
                            dvCloseImage.Attributes.Add("style", "display:none");
                        }

                        rptTicketImage.DataSource = dsTicket.Tables[0];
                        rptTicketImage.DataBind();

                        rptTicketClosingImage.DataSource = dsTicket.Tables[0];
                        rptTicketClosingImage.DataBind();

                        lblAssignedDept.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["Dept_Desc"]);
                        lblDowntime.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["Down_Time"]);

                        int SubCategoryID = 0;
                        int CategoryID = 0;
                        CategoryID = Convert.ToInt32(dsTicket.Tables[0].Rows[0]["Category_ID"]);
                        SubCategoryID = Convert.ToInt32(dsTicket.Tables[0].Rows[0]["SubCategory_ID"]);
                        BindWorkflow(CategoryID, SubCategoryID);

                        RequestStatus = Convert.ToString(dsTicket.Tables[0].Rows[0]["Tkt_Status"]);

                        ActionStatus = Convert.ToString(dsTicket.Tables[0].Rows[0]["Tkt_ActionStatus"]);
                        //if (ActionStatus == "Assigned")
                        //{
                        //    btnClose.Attributes.Add("style", "display:none;");
                        //    dvApprovalDetails.Attributes.Add("style", "display:none;");
                        //}
                        //else
                        //{
                        //    btnAccept.Attributes.Add("style", "display:none;");
                        //}


                        if (RequestStatus == "Open")
                        {
                            lblTicketStatus.Text = "Open";
                            lblTicketStatus.Attributes.Add("class", "m-badge m-badge--danger m-badge--wide");
                        }
                        else if (RequestStatus == "Expired")
                        {
                            lblTicketStatus.Text = "Expired";
                            lblTicketStatus.Attributes.Add("class", "m-badge m-badge--secondary m-badge--wide");
                        }
                        else if (RequestStatus == "Closed")
                        {
                            lblTicketStatus.Text = "Closed";
                            lblTicketStatus.Attributes.Add("class", "m-badge m-badge--success m-badge--wide");
                        }
                        else if (RequestStatus == "Parked")
                        {
                            lblTicketStatus.Text = "Parked";
                            lblTicketStatus.Attributes.Add("class", "m-badge m-badge--warning m-badge--wide");
                        }

                        if (ActionStatus == "Assigned")
                        {
                            lblActionStatus.Text = "Assigned";
                            lblActionStatus.Attributes.Add("class", "m-badge m-badge--info m-badge--wide");
                        }
                        else if (ActionStatus == "Accepted")
                        {
                            lblActionStatus.Text = "Accepted";
                            lblActionStatus.Attributes.Add("class", "m-badge m-badge--success m-badge--wide");
                        }
                        else if (ActionStatus == "In Progress")
                        {
                            lblActionStatus.Text = "In Progress";
                            lblActionStatus.Attributes.Add("class", "m-badge m-badge--accent m-badge--wide");
                        }
                        else if (ActionStatus == "Hold")
                        {
                            lblActionStatus.Text = "Hold";
                            lblActionStatus.Attributes.Add("class", "m-badge m-badge--warning m-badge--wide");
                        }
                        else if (ActionStatus == "Closed")
                        {
                            lblActionStatus.Text = "Closed";
                            lblActionStatus.Attributes.Add("class", "m-badge m-badge--success m-badge--wide");
                        }
                        else if (ActionStatus == "Expired")
                        {
                            lblActionStatus.Text = "Expired";
                            lblActionStatus.Attributes.Add("class", "m-badge m-badge--secondary m-badge--wide");
                        }


                        //}
                    }

                    if (dsTicket.Tables[1].Rows.Count > 0)
                    {
                        Session["CurrentLevel"] = Convert.ToString(dsTicket.Tables[1].Rows[0]["CurrentLevel"]);
                        lblCurrentLevel.Text = Convert.ToString(dsTicket.Tables[1].Rows[0]["CurrentLevel"]);
                    }

                    if (dsTicket.Tables.Count > 2)
                    {
                        if (dsTicket.Tables[2].Rows.Count > 0)
                        {
                            gvActionHistory.DataSource = dsTicket.Tables[2];
                            gvActionHistory.DataBind();
                        }
                        else
                        {
                            gvActionHistory.DataSource = null;
                            gvActionHistory.DataBind();
                        }
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

        public string Fetch_My_Actionable_Ticket_Details(int TicketID)
        {
            string data = "";
            DataSet dsTicket = new DataSet();
            try
            {
                dsTicket = ObjUpkeep.Fetch_Ticket_MyActionable(TicketID, CompanyID, LoggedInUserID);

                // int TicketID = 0;
                string TicketNumber = string.Empty;
                string Zone = string.Empty;
                string Location = string.Empty;
                string SubLocation = string.Empty;
                string Category = string.Empty;
                string SubCategory = string.Empty;
                string RequestDate = string.Empty;
                string RequestStatus = string.Empty;
                string ActionStatus = string.Empty;


                if (dsTicket.Tables.Count > 0)
                {
                    if (dsTicket.Tables[0].Rows.Count > 0)
                    {
                        //int count = Convert.ToInt32(dsTicket.Tables[0].Rows.Count);

                        //for (int i = 0; i < count; i++)
                        //{
                        Session["TicketCode"] = dsTicket.Tables[0].Rows[0].Field<string>("Tkt_Code"); //ajay
                        lblTicketNo.Text = dsTicket.Tables[0].Rows[0].Field<string>("Tkt_Code");
                        lblLocation.Text = dsTicket.Tables[0].Rows[0].Field<string>("Loc_Desc");
                        lblCategory.Text = dsTicket.Tables[0].Rows[0].Field<string>("Category_Desc");
                        lblSubCategory.Text = dsTicket.Tables[0].Rows[0].Field<string>("SubCategory_Desc");
                        lblRequestDate.Text = dsTicket.Tables[0].Rows[0].Field<string>("Ticket_Date");
                        lblTicketdesc.Text = dsTicket.Tables[0].Rows[0].Field<string>("Tkt_Message");
                        lblTicketRaisedBy.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["RaisedBy"]);

                        lblRaisedImageCount.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["TicketRaised_Image_Count"]);
                        if (Convert.ToInt32(dsTicket.Tables[0].Rows[0]["TicketRaised_Image_Count"]) == 0)
                        {
                            dvRaiseImage.Attributes.Add("style", "display:none");
                        }
                        lblClosedImageCount.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["TicketClosed_Image_Count"]);
                        if (Convert.ToInt32(dsTicket.Tables[0].Rows[0]["TicketClosed_Image_Count"]) == 0)
                        {
                            dvCloseImage.Attributes.Add("style", "display:none");
                        }

                        rptTicketImage.DataSource = dsTicket.Tables[0];
                        rptTicketImage.DataBind();

                        rptTicketClosingImage.DataSource = dsTicket.Tables[0];
                        rptTicketClosingImage.DataBind();

                        lblAssignedDept.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["Dept_Desc"]);
                        lblDowntime.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["Down_Time"]);

                        int SubCategoryID = 0;
                        int CategoryID = 0;
                        CategoryID = Convert.ToInt32(dsTicket.Tables[0].Rows[0]["Category_ID"]);
                        SubCategoryID = Convert.ToInt32(dsTicket.Tables[0].Rows[0]["SubCategory_ID"]);
                        BindWorkflow(CategoryID, SubCategoryID);

                        RequestStatus = Convert.ToString(dsTicket.Tables[0].Rows[0]["Tkt_Status"]);

                        ActionStatus = Convert.ToString(dsTicket.Tables[0].Rows[0]["Tkt_ActionStatus"]);

                        if (ActionStatus == "Assigned")
                        {
                            //btnClose.Attributes.Add("style", "display:none;");
                            //dvApprovalDetails.Attributes.Add("style", "display:none;");
                            dvAction.Attributes.Add("style", "display:none;");
                        }
                        else
                        {
                            //btnAccept.Attributes.Add("style", "display:none;");
                            dvAccept.Attributes.Add("style", "display:none;");

                        }

                        if (RequestStatus == "Open")
                        {
                            lblTicketStatus.Text = "Open";
                            lblTicketStatus.Attributes.Add("class", "m-badge m-badge--danger m-badge--wide");
                        }
                        else if (RequestStatus == "Expired")
                        {
                            lblTicketStatus.Text = "Expired";
                            lblTicketStatus.Attributes.Add("class", "m-badge m-badge--secondary m-badge--wide");
                        }
                        else if (RequestStatus == "Closed")
                        {
                            lblTicketStatus.Text = "Closed";
                            lblTicketStatus.Attributes.Add("class", "m-badge m-badge--success m-badge--wide");
                        }
                        else if (RequestStatus == "Parked")
                        {
                            lblTicketStatus.Text = "Parked";
                            lblTicketStatus.Attributes.Add("class", "m-badge m-badge--warning m-badge--wide");
                        }

                        if (ActionStatus == "Assigned")
                        {
                            lblActionStatus.Text = "Assigned";
                            lblActionStatus.Attributes.Add("class", "m-badge m-badge--info m-badge--wide");
                        }
                        else if (ActionStatus == "Accepted")
                        {
                            lblActionStatus.Text = "Accepted";
                            lblActionStatus.Attributes.Add("class", "m-badge m-badge--success m-badge--wide");
                        }
                        else if (ActionStatus == "In Progress")
                        {
                            lblActionStatus.Text = "In Progress";
                            lblActionStatus.Attributes.Add("class", "m-badge m-badge--accent m-badge--wide");
                        }
                        else if (ActionStatus == "Hold")
                        {
                            lblActionStatus.Text = "Hold";
                            lblActionStatus.Attributes.Add("class", "m-badge m-badge--warning m-badge--wide");
                        }
                        else if (ActionStatus == "Closed")
                        {
                            lblActionStatus.Text = "Closed";
                            lblActionStatus.Attributes.Add("class", "m-badge m-badge--success m-badge--wide");
                        }
                        else if (ActionStatus == "Expired")
                        {
                            lblActionStatus.Text = "Expired";
                            lblActionStatus.Attributes.Add("class", "m-badge m-badge--secondary m-badge--wide");
                        }

                        //}
                    }

                    if (dsTicket.Tables[1].Rows.Count > 0)
                    {
                        Session["CurrentLevel"] = Convert.ToString(dsTicket.Tables[1].Rows[0]["CurrentLevel"]);

                        if (Convert.ToInt32(dsTicket.Tables[1].Rows[0]["ShowAction"]) == 0)
                        {
                            dvApprovalDetails.Attributes.Add("style","display:none");
                            dvClose.Attributes.Add("style", "display:none");
                        }

                    }
                    if (dsTicket.Tables.Count > 2)
                    {
                        if (dsTicket.Tables[2].Rows.Count > 0)
                        {
                            gvActionHistory.DataSource = dsTicket.Tables[2];
                            gvActionHistory.DataBind();
                        }
                        else
                        {
                            gvActionHistory.DataSource = null;
                            gvActionHistory.DataBind();
                        }
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

        protected void btnViewWorkflow_Click(object sender, EventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (MyRequest == 1)
            {
                Response.Redirect("~/Ticketing/MyRequest.aspx", false);
            }
            else
            {
                Response.Redirect("~/Ticketing/MyActionable.aspx", false);
            }

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Close_Ticket();


        }

        //Added by Sam
        //public string Close_Ticket()
        //{
        //    string data = "";
        //    string imgPath = string.Empty;
        //    string CloseTicketDesc = txtCloseTicketDesc.Text;
        //    string strTicketID = Convert.ToString((Request.QueryString["TicketID"]));
        //    DataSet dsCloseTicket = new DataSet();
        //    try
        //    {

        //        dsCloseTicket = ObjUpkeep.Close_Ticket_Details(strTicketID, CloseTicketDesc, LoggedInUserID, imgPath);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return data;
        //}


        public void Close_Ticket()
        {


            //string data = "";
            string imgPath = string.Empty;
            string CloseTicketDesc = txtCloseTicketDesc.Text;
            string strTicketID = Convert.ToString((Request.QueryString["TicketID"]));
            List<int> Lst_ValidImage = new List<int>();
            List<int> Lst_ImageSaved = new List<int>();
            List<string> Lst_Images = new List<string>();
            string TicketImages = string.Empty;
            StringBuilder ImagesList = new StringBuilder();



            string fileName = string.Empty;
            string TicketCode = string.Empty;
            string CurrentDate = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));
            TicketCode = Convert.ToString(Session["TicketCode"]);

            string list_Images = string.Empty;  //sam

            DataSet dsCloseTicket = new DataSet();

            try
            {

                if (Convert.ToString(ddlAction.SelectedValue) == "Closed")
                {
                    if (FileUpload_TicketImage.HasFile)
                    {
                        string fileUploadPath = HttpContext.Current.Server.MapPath("~/TicketImages/" + CurrentDate);

                        if (!Directory.Exists(fileUploadPath))
                        {
                            Directory.CreateDirectory(fileUploadPath);
                        }

                        int i = 0;

                        foreach (HttpPostedFile postfiles in FileUpload_TicketImage.PostedFiles)
                        {
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

                            string filetype = Path.GetExtension(postfiles.FileName);
                            if (filetype.ToLower() == ".jpg" || filetype.ToLower() == ".png")
                            {
                                try
                                {
                                    fileName = TicketCode + "_Close_" + Convert.ToString(i) + filetype;

                                    imgPath = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadURL"]);

                                    string SaveLocation = Server.MapPath("~/TicketImages/" + CurrentDate) + "/" + fileName;
                                    string FileLocation = imgPath + "/TicketImages/" + CurrentDate + "/" + fileName;

                                    if (!Lst_ValidImage.Contains(0))
                                    {

                                        postfiles.SaveAs(SaveLocation);
                                        Lst_Images.Add(FileLocation);
                                    }

                                }
                                catch (Exception ex)
                                {

                                    Lst_ImageSaved.Add(0); // Image failed to save
                                    throw ex;
                                }
                            }
                            else
                            {
                                //Is_ValidImage = false;
                                Lst_ValidImage.Add(0);  // image extension is not proper
                            }


                            i = i + 1;
                        }

                        if (Lst_ValidImage.Contains(0))
                        {

                            lblTicketErrorMsg.Text = "Image format not supported";
                            FileUpload_TicketImage.Focus();
                            return;


                        }
                        else if (Lst_ImageSaved.Contains(0))
                        {

                            lblTicketErrorMsg.Text = "Image upload failed, please try again";
                            return;

                        }
                    }
                    try
                    {
                        list_Images = String.Join(",", Lst_Images);

                        string strTicketAction = string.Empty;
                        strTicketAction = Convert.ToString(ddlAction.SelectedValue);


                        string CurrentLevel = Convert.ToString(Session["CurrentLevel"]);

                        dsCloseTicket = ObjUpkeep.Close_Ticket_Details(strTicketID, CloseTicketDesc, LoggedInUserID, list_Images, strTicketAction, CurrentLevel);                        //mpeTicketSaveSuccess.Show();

                        //Samvedna
                        if (dsCloseTicket.Tables.Count > 0)
                        {
                            if (dsCloseTicket.Tables[0].Rows.Count > 0)
                            {
                                int Status = Convert.ToInt32(dsCloseTicket.Tables[0].Rows[0]["Status"]);
                                if (Status == 1)
                                {
                                    //Send SMS
                                    string APIKey = string.Empty;
                                    string SenderID = string.Empty;
                                    string Send_SMS_URL = string.Empty;

                                    string TicketNo = string.Empty;
                                    string TextMessage = string.Empty;
                                    string TicketRaisedBy_Name = string.Empty;
                                    string TicketRaisedBy_MobileNo = string.Empty;
                                    string TicketAction = string.Empty;

                                    if (dsCloseTicket.Tables.Count > 1)
                                    {
                                        if (dsCloseTicket.Tables[1].Rows.Count > 0)
                                        {
                                            APIKey = Convert.ToString(dsCloseTicket.Tables[1].Rows[0]["Api_Key"]);
                                            SenderID = Convert.ToString(dsCloseTicket.Tables[1].Rows[0]["Sender_ID"]);
                                            Send_SMS_URL = Convert.ToString(dsCloseTicket.Tables[1].Rows[0]["Send_SMS_URL"]);

                                            Send_SMS_URL = Send_SMS_URL.Replace("%26", "&");

                                            SendSMS sms = new SendSMS();
                                            if (dsCloseTicket.Tables.Count > 2)
                                            {
                                                if (dsCloseTicket.Tables[2].Rows.Count > 0)
                                                {
                                                    TicketNo = Convert.ToString(dsCloseTicket.Tables[2].Rows[0]["TicketNo"]);
                                                    TicketRaisedBy_Name = Convert.ToString(dsCloseTicket.Tables[2].Rows[0]["TicketRaisedBy_Name"]);
                                                    TicketRaisedBy_MobileNo = Convert.ToString(dsCloseTicket.Tables[2].Rows[0]["TicketRaisedBy_MobileNo"]);

                                                    if (strTicketAction == "In Progress")
                                                    {
                                                        TicketAction = "OPEN (In Progress)";
                                                    }
                                                    else if (strTicketAction == "Hold")
                                                    {
                                                        TicketAction = "PARKED (Hold)";
                                                    }
                                                    else if (strTicketAction == "Closed")
                                                    {
                                                        TicketAction = "CLOSED (Done)";
                                                    }

                                                    TextMessage = "Dear " + TicketRaisedBy_Name + ",";
                                                    TextMessage += "%0a%0aAn Action has been taken on your ticket " + TicketNo + ".";
                                                    TextMessage += "%0aTicket status has been changed to " + TicketAction + "";
                                                    string response_raisedBy = sms.Send_SMS(APIKey, SenderID, Send_SMS_URL, TicketRaisedBy_MobileNo, TextMessage);
                                                }
                                            }
                                        }
                                    }

                                    //Send SMS

                                    Response.Redirect(Page.ResolveClientUrl("~/Ticketing/MyActionable.aspx"), false);
                                }
                                else
                                {
                                    lblTicketErrorMsg.Text = "Something went wrong, please try again";
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

                else
                {
                    // In progress, Hold

                    string strTicketAction = string.Empty;
                    strTicketAction = Convert.ToString(ddlAction.SelectedValue);


                    string CurrentLevel = Convert.ToString(Session["CurrentLevel"]);

                    dsCloseTicket = ObjUpkeep.Close_Ticket_Details(strTicketID, CloseTicketDesc, LoggedInUserID, list_Images, strTicketAction, CurrentLevel);

                    //Samvedna
                    if (dsCloseTicket.Tables.Count > 0)
                    {
                        if (dsCloseTicket.Tables[0].Rows.Count > 0)
                        {
                            int Status = Convert.ToInt32(dsCloseTicket.Tables[0].Rows[0]["Status"]);
                            if (Status == 1)
                            {
                                //Send SMS
                                string APIKey = string.Empty;
                                string SenderID = string.Empty;
                                string Send_SMS_URL = string.Empty;

                                string TicketNo = string.Empty;
                                string TextMessage = string.Empty;
                                string TicketRaisedBy_Name = string.Empty;
                                string TicketRaisedBy_MobileNo = string.Empty;
                                string TicketAction = string.Empty;

                                if (dsCloseTicket.Tables.Count > 1)
                                {
                                    if (dsCloseTicket.Tables[1].Rows.Count > 0)
                                    {
                                        APIKey = Convert.ToString(dsCloseTicket.Tables[1].Rows[0]["Api_Key"]);
                                        SenderID = Convert.ToString(dsCloseTicket.Tables[1].Rows[0]["Sender_ID"]);
                                        Send_SMS_URL = Convert.ToString(dsCloseTicket.Tables[1].Rows[0]["Send_SMS_URL"]);

                                        Send_SMS_URL = Send_SMS_URL.Replace("%26", "&");

                                        SendSMS sms = new SendSMS();
                                        if (dsCloseTicket.Tables.Count > 2)
                                        {
                                            if (dsCloseTicket.Tables[2].Rows.Count > 0)
                                            {
                                                TicketNo = Convert.ToString(dsCloseTicket.Tables[2].Rows[0]["TicketNo"]);
                                                TicketRaisedBy_Name = Convert.ToString(dsCloseTicket.Tables[2].Rows[0]["TicketRaisedBy_Name"]);
                                                TicketRaisedBy_MobileNo = Convert.ToString(dsCloseTicket.Tables[2].Rows[0]["TicketRaisedBy_MobileNo"]);

                                                if (strTicketAction == "In Progress")
                                                {
                                                    TicketAction = "OPEN (In Progress)";
                                                }
                                                else if (strTicketAction == "Hold")
                                                {
                                                    TicketAction = "PARKED (Hold)";
                                                }
                                                else if (strTicketAction == "Closed")
                                                {
                                                    TicketAction = "CLOSED (Done)";
                                                }

                                                TextMessage = "Dear " + TicketRaisedBy_Name + ",";
                                                TextMessage += "%0a%0aAn Action has been taken on your ticket " + TicketNo + ".";
                                                TextMessage += "%0aTicket status has been changed to " + TicketAction + "";
                                                string response_raisedBy = sms.Send_SMS(APIKey, SenderID, Send_SMS_URL, TicketRaisedBy_MobileNo, TextMessage);
                                            }
                                        }
                                    }
                                }

                                //Send SMS

                                Response.Redirect(Page.ResolveClientUrl("~/Ticketing/MyActionable.aspx"), false);
                            }
                            else
                            {
                                lblTicketErrorMsg.Text = "Something went wrong, please try again";
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }




        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            DataSet dsTicket = new DataSet();
            try
            {
                dsTicket = ObjUpkeep.Accept_Ticket(TicketID, LoggedInUserID);
                if (dsTicket.Tables.Count > 0)
                {
                    if (dsTicket.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsTicket.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            //Send SMS
                            string APIKey = string.Empty;
                            string SenderID = string.Empty;
                            string Send_SMS_URL = string.Empty;

                            string TicketNo = string.Empty;
                            string TextMessage = string.Empty;
                            string TicketAcceptedBy_Name = string.Empty;
                            string TicketAcceptedBy_Department = string.Empty;
                            string TicketRaisedBy_Name = string.Empty;
                            string TicketRaisedBy_MobileNo = string.Empty;

                            if (dsTicket.Tables.Count > 1)
                            {
                                if (dsTicket.Tables[1].Rows.Count > 0)
                                {
                                    APIKey = Convert.ToString(dsTicket.Tables[1].Rows[0]["Api_Key"]);
                                    SenderID = Convert.ToString(dsTicket.Tables[1].Rows[0]["Sender_ID"]);
                                    Send_SMS_URL = Convert.ToString(dsTicket.Tables[1].Rows[0]["Send_SMS_URL"]);

                                    Send_SMS_URL = Send_SMS_URL.Replace("%26", "&");

                                    SendSMS sms = new SendSMS();
                                    if (dsTicket.Tables.Count > 2)
                                    {
                                        if (dsTicket.Tables[2].Rows.Count > 0)
                                        {
                                            TicketNo = Convert.ToString(dsTicket.Tables[2].Rows[0]["TicketNo"]);
                                            TicketAcceptedBy_Name = Convert.ToString(dsTicket.Tables[2].Rows[0]["TicketAcceptedBy"]);
                                            TicketAcceptedBy_Department = Convert.ToString(dsTicket.Tables[2].Rows[0]["TicketAcceptedBy_Dept"]);
                                            TicketRaisedBy_Name = Convert.ToString(dsTicket.Tables[2].Rows[0]["TicketRaisedBy"]);
                                            TicketRaisedBy_MobileNo = Convert.ToString(dsTicket.Tables[2].Rows[0]["TicketRaisedBy_MobileNo"]);

                                            TextMessage = "Dear " + TicketRaisedBy_Name + ",";
                                            TextMessage += "%0a%0aYour ticket " + TicketNo + " has been accepted by " + TicketAcceptedBy_Name + " from " + TicketAcceptedBy_Department + "";
                                            string response_raisedBy = sms.Send_SMS(APIKey, SenderID, Send_SMS_URL, TicketRaisedBy_MobileNo, TextMessage);
                                        }
                                    }
                                }
                            }

                            //Send SMS

                            Response.Redirect("~/Ticketing/MyActionable.aspx", false);
                        }
                        else if (Status == 2)
                        {
                            lblTicketErrorMsg.Text = "This ticket is already accepted by other user.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvTicketActionHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //check if the row is the header row
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //add the thead and tbody section programatically
                e.Row.TableSection = TableRowSection.TableHeader;
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
                }
                else
                {
                    gvWorkflow.DataSource = null;
                    gvWorkflow.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                        //if (Convert.ToString(ddlAction.SelectedValue) == "Closed")
                        //{
                        int Tkt_Is_Img_Close = Convert.ToInt32(dsSetting.Tables[0].Rows[0]["Tkt_Is_Img_Close"]);
                        int Tkt_Is_Remark_Close = Convert.ToInt32(dsSetting.Tables[0].Rows[0]["Tkt_Is_Remark_Close"]);

                        hdn_Mandatory_Img_Close.Value = Convert.ToString(dsSetting.Tables[0].Rows[0]["Tkt_Is_Img_Close"]);
                        hdn_Mandatory_Remark_Close.Value = Convert.ToString(dsSetting.Tables[0].Rows[0]["Tkt_Is_Remark_Close"]); ;

                        //if (Tkt_Is_Img_Close == 0)
                        //    {
                        //        rfvFileupload.Enabled = false;
                        //    }


                        //    if (Tkt_Is_Remark_Close == 0)
                        //    {
                        //        rfvClosingRemarks.Enabled = false;
                        //    }
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }

}
