using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Configuration;
using System.Linq;
using Upkeep_v3.SMS;

namespace Upkeep_v3.VMS
{
    public partial class Visit_Request_Details : System.Web.UI.Page
    {

        #region Global variables
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        string SessionVisitor = string.Empty;
        DataSet dsConfig = new DataSet();
        //int CompanyID = 0;
        int ConfigID = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //LoggedInUserID = "admin";
            //LoggedInUserID = "121";

            string strConfigID = string.Empty;
            string strRequestID = string.Empty;

            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            SessionVisitor = Convert.ToString(Session["Visitor"]);

            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(LoggedInUserID) && string.IsNullOrEmpty(SessionVisitor))
                {
                    Response.Redirect("~/Login.aspx", false);
                    return;
                }
                else if (string.IsNullOrEmpty(LoggedInUserID) && !string.IsNullOrEmpty(SessionVisitor))
                {
                    divTitle.Visible = false;
                    if (!System.String.IsNullOrWhiteSpace(Request.QueryString["ConfigID"]))
                    {
                        strConfigID = Request.QueryString["ConfigID"].ToString();
                        if (strConfigID.All(char.IsDigit))
                        {
                            ViewState["ConfigID"] = Convert.ToInt32(strConfigID);
                        }
                        BindVMSConfig();

                    }
                }
                else if (!string.IsNullOrEmpty(LoggedInUserID) && string.IsNullOrEmpty(SessionVisitor))
                {

                    btnSave.Text = "Mark IN";
                    dv_rpt.Visible = false;
                    dv_Remark.Visible = false;
                    dv_ClosingRemark.Visible = false;
                    if (!System.String.IsNullOrWhiteSpace(Request.QueryString["RequestID"]))
                    {
                        strRequestID = Request.QueryString["RequestID"].ToString();
                        if (strRequestID.All(char.IsDigit))
                        {
                            ViewState["RequestID"] = Convert.ToInt32(strRequestID);

                            FetchSectionHeaderData();
                        }

                    }

                    ViewState["CompanyID"] = Convert.ToInt32(Session["CompanyID"]);
                }

                //GenerateTableQuestion();
                //GenerateTable(3, 1);
                Fetch_User_UserGroupList();
                Fetch_Department();
                BindVMSTitle();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //string WpTitleSelectedID = "";
            //WpTitleSelectedID = ddlVMSTitle.SelectedValue;
            //if (ValidateData() == false)
            //{
            //    //ddlVMSTitle.SelectedValue = "0";
            //    //ddlVMSTitle.SelectedValue = WpTitleSelectedID;
            //    //setVMSData();
            //    SetRepeater();
            //    return;
            //}

            SaveVisitData();
        }

        protected void ddlVMSTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int ConfigTitleID = 0;

            try
            {
                //lblRequestDate.Text = DateTime.Now.ToString("dd/MMM/yyyy hh:mm tt");

                ViewState["ConfigID"] = Convert.ToInt32(ddlVMSTitle.SelectedValue);

                BindVMSConfig();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void rptQuestionDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Reference the Repeater Item.
                RepeaterItem item = e.Item;

                string AnswerType = (e.Item.FindControl("hdnAnswerTypeSDesc") as HiddenField).Value;
                string HeadId = (e.Item.FindControl("hfQuestionId") as HiddenField).Value;

                if (AnswerType == "MSLCT") //Multi Selection [CheckBox]
                {
                    HtmlGenericControl sample = e.Item.FindControl("divCheckBox") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == "SSLCT") //Single Selection [Radio Button]
                {
                    HtmlGenericControl sample = e.Item.FindControl("divRadioButton") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == "IMAGE") //Image Upload  
                {
                    HtmlGenericControl sample = e.Item.FindControl("divImage") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == "NUMBR") //Number Text Field
                {
                    HtmlGenericControl sample = e.Item.FindControl("divNumber") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == "STEXT") //Normal Text Field
                {
                    HtmlGenericControl sample = e.Item.FindControl("divText") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == "LTEXT") // Textarea Field
                {
                    HtmlGenericControl sample = e.Item.FindControl("divTextArea") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else  //Normal Text Field
                {
                    HtmlGenericControl sample = e.Item.FindControl("divText") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }


                //Repeater rptRadio = e.Item.FindControl("rptRadio") as Repeater;

                DataSet dsVMSQuestion = new DataSet();
                dsVMSQuestion = dsConfig.Copy(); //ObjUpkeep.Bind_VMSConfiguration(sPublicConfigId);

                DataTable dt = new DataTable();
                dt = dsVMSQuestion.Tables[2].Copy();
                dt.DefaultView.RowFilter = "VMS_Qn_ID = " + Convert.ToString(HeadId) + "";
                dt = dt.DefaultView.ToTable();

                if (AnswerType == "SSLCT")
                {
                    RadioButtonList divRadioButtonrdbYes = e.Item.FindControl("divRadioButtonrdbYes") as RadioButtonList;

                    if (dt.Rows.Count > 0)
                    {
                        //rptRadio.DataSource = dt;
                        //rptRadio.DataBind(); 
                        divRadioButtonrdbYes.DataTextField = "Ans_Type_Data"; // "Ans_Type_Desc";
                        divRadioButtonrdbYes.DataValueField = "Ans_Type_Data_ID";  // "Ans_Type_ID";// 
                        divRadioButtonrdbYes.DataSource = dt;
                        divRadioButtonrdbYes.DataBind();
                    }
                    else
                    {
                        DataTable dt1 = new DataTable();
                        //rptRadio.DataSource = dt1;
                        //rptRadio.DataBind();
                        divRadioButtonrdbYes.DataSource = dt;
                        divRadioButtonrdbYes.DataBind();
                    }

                }
                else if (AnswerType == "MSLCT")
                {
                    CheckBoxList divCheckBoxIDI = e.Item.FindControl("divCheckBoxIDI") as CheckBoxList;
                    if (dt.Rows.Count > 0)
                    {
                        //rptRadio.DataSource = dt;
                        //rptRadio.DataBind(); 
                        divCheckBoxIDI.DataTextField = "Ans_Type_Data"; // "Ans_Type_Desc";
                        divCheckBoxIDI.DataValueField = "Ans_Type_Data_ID";  // "Ans_Type_ID";// 
                        divCheckBoxIDI.DataSource = dt;
                        divCheckBoxIDI.DataBind();
                    }
                    else
                    {
                        DataTable dt1 = new DataTable();
                        //rptRadio.DataSource = dt1;
                        //rptRadio.DataBind();
                        divCheckBoxIDI.DataSource = dt;
                        divCheckBoxIDI.DataBind();
                    }
                }

            }
        }

        protected void btnSelectUser_Click(object sender, EventArgs e)
        {
            string SelectedUsersID = string.Empty;
            string SelectedUsersName = string.Empty;
            var rows = grdInfodetails.Rows;
            int count = grdInfodetails.Rows.Count;

            for (int i = 0; i < count; i++)
            {
                bool isChecked = ((CheckBox)rows[i].FindControl("chkUserID")).Checked;
                if (isChecked)
                {
                    //string EmployeeID = gvEmployee.Rows[i].Cells[1].Text;
                    string UserName = ((HiddenField)rows[i].FindControl("hdnUser_Name")).Value;

                    string UserID = ((HiddenField)rows[i].FindControl("hdnUserID")).Value;
                    SelectedUsersID = SelectedUsersID + UserID + "$";

                    SelectedUsersName = SelectedUsersName + UserName + "$";
                }
            }

            SelectedUsersID = SelectedUsersID.TrimEnd('$');
            SelectedUsersName = SelectedUsersName.TrimEnd('$');

            //Session["SelectedUsersID"] = SelectedUsersID;
            //Session["SelectedUsersName"] = SelectedUsersName;

            hdnSelectedUserID.Value = SelectedUsersID;
            hdnSelectedUserName.Value = SelectedUsersName;

            //ClientScript.RegisterStartupScript(this.GetType(), "updateProgress", "FunEditClick(" + SelectedUsersID + "," + SelectedUsersName + ");", true);
            ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "myScriptName", $"SelectUser();", true);
            //ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "myScriptName", "<script>FunEditClick(" + SelectedUsersID + "," + SelectedUsersName + ");</script>", true);
            //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>FunEditClick(" + SelectedUsersID + "," + SelectedUsersName + ");</script>");
            mpeMeetingUsers.Hide();
        }

        protected void grdInfodetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //check if the row is the header row
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //add the thead and tbody section programatically
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fetch_User_UserGroupList();
        }

        protected void btnSuccessOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LoggedInUserID) && !string.IsNullOrEmpty(SessionVisitor))
                Response.Redirect("http://www.efacilito.com");
            else
                Response.Redirect(Page.ResolveClientUrl("~/VMS/VMSRequest_Listing.aspx"), false);
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            ViewState["Action"] = 'R';
            SaveVisitData();
        }

        #region Functions

        private void BindVMSConfig()
        {
            try
            {
                //lblRequestDate.Text = DateTime.Now.ToString("dd/MMM/yyyy hh:mm tt");

                ConfigID = Convert.ToInt32(ViewState["ConfigID"]);
                dsConfig = ObjUpkeep.Bind_VMSConfiguration(ConfigID);

                if (!System.String.IsNullOrWhiteSpace(dsConfig.Tables[0].Rows[0]["Config_Desc"].ToString()))
                {
                    divDesc.Visible = true;
                    spnDesc.InnerText = dsConfig.Tables[0].Rows[0]["Config_Desc"].ToString();
                }
                if (!System.String.IsNullOrWhiteSpace(dsConfig.Tables[0].Rows[0]["Company_ID"].ToString()))
                {
                    ViewState["CompanyID"] = dsConfig.Tables[0].Rows[0]["Company_ID"];
                }

                if (!string.IsNullOrEmpty(LoggedInUserID) && string.IsNullOrEmpty(SessionVisitor) && Convert.ToBoolean(dsConfig.Tables[0].Rows[0]["isCovidEnable"]))
                {
                    divCovid.Visible = true;
                    divCovid1.Visible = true;
                }

                if (ViewState["RequestID"] == null)
                {
                    rptQuestionDetails.DataSource = dsConfig.Tables[1];
                    rptQuestionDetails.DataBind();
                    dv_rpt.Visible = true;
                    totalNumber.InnerText = dsConfig.Tables[3].Rows[0]["TotalCount"].ToString();
                }

                // string blNameComp = "true";
                string blEmailComp = Convert.ToString(dsConfig.Tables[0].Rows[0]["Is_Email_Compulsory"]);
                string blContactComp = Convert.ToString(dsConfig.Tables[0].Rows[0]["Is_Contact_Compulsory"]);
                string blMeetingComp = Convert.ToString(dsConfig.Tables[0].Rows[0]["Is_MeetingWith_Compulsory"]);
                string blContactOtpComp = Convert.ToString(dsConfig.Tables[0].Rows[0]["Is_Contact_OTP_Compulsory"]);
                string blEmailOtpComp = Convert.ToString(dsConfig.Tables[0].Rows[0]["Is_Email_OTP_Compulsory"]);


                if (blEmailComp == "True")
                {
                    //divEmailComp.Visible = true;
                    //spnEmailComp.Visible = true;
                    rfvEmail.Enabled = true;
                }

                if (blContactComp == "True")
                {

                    rfvphone.Enabled = true;
                }
                if (blMeetingComp == "True")
                {

                    div_MeetingWith1.Visible = true;
                    div_MeetingWith2.Visible = true;

                }
                else
                {
                    div_MeetingWith1.Visible = false;
                    div_MeetingWith2.Visible = true;

                }



                // spnEmailComp.Visible = true;





            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        private void FetchSectionHeaderData()

        {
            try
            {
                int RequestID = Convert.ToInt32(ViewState["RequestID"]);

                DataSet dsData = new DataSet();
                dsData = ObjUpkeep.Bind_VMSRequestDetails(RequestID, LoggedInUserID);

                if (dsData.Tables.Count > 0)
                {

                    if (dsData.Tables[0].Rows.Count > 0)
                    {

                        ViewState["ConfigID"] = Convert.ToInt32(dsData.Tables[0].Rows[0]["VMS_Config_ID"]);

                        //ddlWorkPermitTitle.SelectedValue = dsData.Tables[0].Rows[0]["WP_Config_ID"].ToString();
                        BindVMSConfig();

                        bool isVaccineCheck_Enable = dsData.Tables[0].Rows[0]["Vaccine_Check_Enable"].ToString() == "True" ? true : false;
                        if (isVaccineCheck_Enable == true)
                        {
                            div_vaccination.Visible = true;
                            div_vaccination1.Visible = true;
                        }
                        else
                        {
                            div_vaccination.Visible = false;
                            div_vaccination1.Visible = false;
                        }
                    }
                    //Bind inserted Visit data
                    if (dsData.Tables[1].Rows.Count > 0)
                    {
                        divTitle.Visible = false;

                        txtVMSDate.ReadOnly = true;
                        txtName.ReadOnly = true;
                        txtEmail.ReadOnly = true;
                        txtPhone.ReadOnly = true;
                        txtClosingRemarks.ReadOnly = true;


                        txtVMSDate.Text = dsData.Tables[1].Rows[0]["Meeting_Time"].ToString();
                        txtName.Text = dsData.Tables[1].Rows[0]["Name"].ToString();

                        //if
                        //rfvName.Enabled = true;

                        txtEmail.Text = dsData.Tables[1].Rows[0]["Email"].ToString();
                        txtPhone.Text = dsData.Tables[1].Rows[0]["Phone"].ToString();
                        txtClosingRemarks.Text = dsData.Tables[1].Rows[0]["Closing_Remarks"].ToString();


                        //txtWorkPermitToDate.Text = dsData.Tables[0].Rows[0]["Wp_To_Date"].ToString();

                        //lblTicket.Text = dsData.Tables[0].Rows[0]["TicketNo"].ToString();

                        switch (dsData.Tables[1].Rows[0]["Status"].ToString())
                        {
                            case "Apply":
                                divAlertApply.Visible = true;
                                btnReject.Visible = true;
                                ViewState["Action"] = 'I';
                                break;
                            case "IN":
                                divAlertOpen.Visible = true;
                                btnSave.Text = "Mark OUT";
                                ViewState["Action"] = 'O';
                                dv_Remark.Visible = true;
                                dv_ClosingRemark.Visible = true;
                                txtClosingRemarks.ReadOnly = false;
                                break;
                            case "OUT":
                                divAlertClosed.Visible = true;
                                btnSave.Visible = false;
                                dv_Remark.Visible = true;
                                dv_ClosingRemark.Visible = true;
                                break;
                            case "Expired":
                                divAlertExpired.Visible = true;
                                btnSave.Visible = false;
                                break;
                            case "Reject":
                                divAlertRejected.Visible = true;
                                btnSave.Visible = false;
                                break;
                        }

                    }
                    //Bind inserted covid data
                    if (dsData.Tables[2].Rows.Count > 0)
                    {


                        bool isCovidEnable = Convert.ToBoolean(dsData.Tables[0].Rows[0]["isCovidEnable"]);
                        if (isCovidEnable)
                        {
                            string color = dsData.Tables[2].Rows[0]["ColorCode"].ToString();
                            switch (color)
                            {
                                case "GREEN":
                                    rdbGreen.Checked = true;
                                    break;
                                case "ORANGE":
                                    rdbOrange.Checked = true;
                                    break;
                                case "RED":
                                    rdbRed.Checked = true;
                                    break;
                            }

                            txtAsmmtDate.ReadOnly = true;
                            txtTemperature.ReadOnly = true;

                            txtAsmmtDate.Text = dsData.Tables[2].Rows[0]["TestDate"].ToString();
                            txtTemperature.Text = dsData.Tables[2].Rows[0]["Temperature"].ToString();
                        }


                    }
                    //Bind configured Visit data
                    if (dsData.Tables[3].Rows.Count > 0)
                    {
                        rptQuestionDetails.DataSource = dsData.Tables[3];
                        rptQuestionDetails.DataBind();
                        dv_rpt.Visible = true;
                    }
                    //Bind configured Visit data
                    if (dsData.Tables[4].Rows.Count > 0)
                    {

                        DataTable dta = new DataTable();
                        dta = dsData.Tables[4].Copy();

                        foreach (RepeaterItem itemHeader in rptQuestionDetails.Items)
                        {
                            string AnswerType = (itemHeader.FindControl("hdnAnswerTypeSDesc") as HiddenField).Value;
                            string HeadId = (itemHeader.FindControl("hfQuestionId") as HiddenField).Value;

                            DataTable dtQN = new DataTable();

                            dta.DefaultView.RowFilter = "VMS_QN_ID = '" + HeadId + "' ";
                            dtQN = dta.DefaultView.ToTable();
                            //dta.DefaultView.RowFilter = "WP_Section_ID = " + Convert.ToString(DivId) + " AND WP_Header_ID =" + Convert.ToString(HeadId) + "  ";

                            if (dta.Rows.Count > 0)
                            {
                                if (AnswerType == "MSLCT") //Multi Selection [CheckBox]
                                {
                                    CheckBoxList divCheckBoxIDI = itemHeader.FindControl("divCheckBoxIDI") as CheckBoxList;

                                    for (int i = 0; i < divCheckBoxIDI.Items.Count; i++)
                                    {
                                        for (int j = 0; j < dtQN.Rows.Count; j++)
                                        {
                                            string vals = divCheckBoxIDI.Items[i].Value;
                                            if (vals == dtQN.Rows[j]["Ans_Type_Data"].ToString() && Convert.ToBoolean(dtQN.Rows[j]["Selected"]))
                                            {
                                                divCheckBoxIDI.Items[i].Selected = true;
                                            }
                                            divCheckBoxIDI.Items[i].Enabled = false;
                                        }
                                        divCheckBoxIDI.Attributes.Add("Enabled", "false");
                                    }

                                }
                                else if (AnswerType == "SSLCT") //Single Selection [Radio Button]
                                {
                                    RadioButtonList divRadioButtonrdbYes = itemHeader.FindControl("divRadioButtonrdbYes") as RadioButtonList;

                                    for (int i = 0; i < divRadioButtonrdbYes.Items.Count; i++)
                                    {
                                        for (int j = 0; j < dtQN.Rows.Count; j++)
                                        {
                                            string vals = divRadioButtonrdbYes.Items[i].Value;
                                            if (vals == dtQN.Rows[j]["Ans_Type_Data"].ToString() && Convert.ToBoolean(dtQN.Rows[j]["Selected"]))
                                            {
                                                divRadioButtonrdbYes.Items[i].Selected = true;
                                            }
                                            divRadioButtonrdbYes.Items[i].Enabled = false;
                                        }
                                        divRadioButtonrdbYes.Attributes.Add("Enabled", "false");
                                    }
                                }
                                else if (AnswerType == "IMAGE") //Image Upload  
                                {
                                    HtmlGenericControl sample = itemHeader.FindControl("divImage") as HtmlGenericControl;
                                    FileUpload ChecklistImage = (FileUpload)itemHeader.FindControl("FileUpload_ChecklistImage");

                                    string vals = "";
                                    for (int j = 0; j < dtQN.Rows.Count; j++)
                                    {
                                        if (j == 0)
                                        {
                                            vals = dtQN.Rows[j]["Ans_Type_Data"].ToString();
                                        }
                                        else
                                        {
                                            vals = vals + "," + dtQN.Rows[j]["Ans_Type_Data"].ToString();
                                        }
                                    }

                                    ChecklistImage.Attributes.Add("style", "display:none;");

                                    HiddenField hdImg = itemHeader.FindControl("hdnImg") as HiddenField;
                                    hdImg.Value = vals;


                                    HtmlGenericControl divsImgBtns = itemHeader.FindControl("divImgBtns") as HtmlGenericControl;
                                    divsImgBtns.Attributes.Remove("style");

                                    //Button BtnDivImg = itemHeader.FindControl("btnImg") as Button;
                                    //BtnDivImg.Attributes.Remove("data-images");
                                    //BtnDivImg.Attributes.Add("data-images", vals);

                                }
                                else if (AnswerType == "NUMBR") //Number Text Field
                                {
                                    HtmlGenericControl sample = itemHeader.FindControl("divNumber") as HtmlGenericControl;
                                    string txtNum = sample.Controls[1].UniqueID;
                                    //string sVal = Request.Form.GetValues(txtNum)[0];


                                    HtmlInputGenericControl tb = FindControl(txtNum) as HtmlInputGenericControl;
                                    tb.Value = dtQN.Rows[0]["Ans_Type_Data"].ToString();
                                    tb.Disabled = true;
                                    //Request.Form.Set(txtNum, dtQN.Rows[0]["Ans_Type_Data"].ToString());
                                }
                                else if (AnswerType == "STEXT") //Normal Text Field
                                {
                                    HtmlGenericControl sample = itemHeader.FindControl("divText") as HtmlGenericControl;
                                    string txtNum = sample.Controls[1].UniqueID;
                                    //string sVal = Request.Form.GetValues(txtNum)[0];

                                    HtmlInputText tb = FindControl(txtNum) as HtmlInputText;
                                    tb.Value = dtQN.Rows[0]["Ans_Type_Data"].ToString();
                                    tb.Disabled = true;
                                    //Request.Form.Set(txtNum, dtQN.Rows[0]["Ans_Type_Data"].ToString());
                                }
                                else if (AnswerType == "LTEXT") // Textarea Field
                                {
                                    HtmlGenericControl sample = itemHeader.FindControl("divTextArea") as HtmlGenericControl;
                                    string txtNum = sample.Controls[1].UniqueID;
                                    // string sVal = Request.Form.GetValues(txtNum)[0];

                                    HtmlTextArea tb = FindControl(txtNum) as HtmlTextArea;
                                    tb.Value = dtQN.Rows[0]["Ans_Type_Data"].ToString();
                                    tb.Disabled = true;
                                    //Request.Form.Set(txtNum, dtQN.Rows[0]["Ans_Type_Data"].ToString());
                                }
                                else  //Normal Text Field
                                {
                                    HtmlGenericControl sample = itemHeader.FindControl("divText") as HtmlGenericControl;
                                    string txtNum = sample.Controls[1].UniqueID;
                                    //string sVal = Request.Form.GetValues(txtNum)[0];

                                    HtmlInputGenericControl tb = FindControl(txtNum) as HtmlInputGenericControl;
                                    tb.Value = dtQN.Rows[0]["Ans_Type_Data"].ToString();
                                    tb.Disabled = true;
                                    //Request.Form.Set(txtNum, dta.Rows[0]["Ans_Type_Data"].ToString());
                                }
                            }
                        }



                    }


                    if (dsData.Tables[5].Rows.Count > 0)
                    {

                        txtMeetUsers.Text = dsData.Tables[5].Rows[0]["Meeting_Host"].ToString();

                    }

                    //Bind Vaccination_Details Data
                    if (dsData.Tables[6].Rows.Count > 0)
                    {
                        ContentPlaceHolder1_imgProfilePic.ImageUrl = dsData.Tables[6].Rows[0]["Visitor_Photo"].ToString();
                        IDProof.ImageUrl = dsData.Tables[6].Rows[0]["ID_Proof"].ToString();
                        iframe_Document.Attributes.Add("src", dsData.Tables[6].Rows[0]["Vaccine_Certificate"].ToString());
                        lbl_DoseDate.Text = DateTime.Parse(dsData.Tables[6].Rows[0]["Date_of_Vaccination"].ToString()).ToString("dd-MMM-yyyy");
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetRepeater()
        {
            foreach (RepeaterItem itemQuestion in rptQuestionDetails.Items)
            {
                string AnswerType = (itemQuestion.FindControl("hdnAnswerTypeSDesc") as HiddenField).Value;
                string HeadId = (itemQuestion.FindControl("hfQuestionId") as HiddenField).Value;

                string HeadMandatoryId = (itemQuestion.FindControl("hdnIs_Mandatory") as HiddenField).Value;

                // string EmailMandatoryId = (itemQuestion.FindControl("hdnIs_EmailMandatory") as HiddenField).Value;
                if (HeadMandatoryId == "*")
                {

                    Label sample = itemQuestion.FindControl("lblIsMandatory") as Label;
                    sample.Attributes.Remove("style");
                }

                if (AnswerType == "MSLCT") //Multi Selection [CheckBox]
                {
                    HtmlGenericControl sample = itemQuestion.FindControl("divCheckBox") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == "SSLCT") //Single Selection [Radio Button]
                {
                    HtmlGenericControl sample = itemQuestion.FindControl("divRadioButton") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == "IMAGE") //Image Upload  
                {
                    HtmlGenericControl sample = itemQuestion.FindControl("divImage") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == "NUMBR") //Number Text Field
                {
                    HtmlGenericControl sample = itemQuestion.FindControl("divNumber") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == "STEXT") //Normal Text Field
                {
                    HtmlGenericControl sample = itemQuestion.FindControl("divText") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == "LTEXT") // Textarea Field
                {
                    HtmlGenericControl sample = itemQuestion.FindControl("divTextArea") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else  //Normal Text Field
                {
                    HtmlGenericControl sample = itemQuestion.FindControl("divText") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }

            }

        }

        public void BindVMSTitle()
        {
            DataSet dsTitle = new DataSet();
            string Initiator = string.Empty;
            try
            {
                Initiator = Convert.ToString(Session["UserType"]);
                dsTitle = ObjUpkeep.Fetch_VMSConfiguration(Convert.ToInt32(Session["CompanyID"]), Initiator);
                if (dsTitle.Tables.Count > 0)
                {
                    if (dsTitle.Tables[0].Rows.Count > 0)
                    {
                        ddlVMSTitle.DataSource = dsTitle.Tables[0];
                        ddlVMSTitle.DataTextField = "Config_Title";
                        ddlVMSTitle.DataValueField = "VMS_Config_Id";
                        ddlVMSTitle.DataBind();
                        ddlVMSTitle.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Fetch_User_UserGroupList()
        {
            //int CategoryID = 0;
            try
            {


                DataSet ds = ObjUpkeep.Fetch_User_UserGroupList(Convert.ToInt32(ViewState["CompanyID"]));

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdInfodetails.DataSource = ds.Tables[0];
                        grdInfodetails.DataBind();
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Fetch_Department()
        {
            DataSet dsDept = new DataSet();
            try
            {
                dsDept = ObjUpkeep.Fetch_Department(Convert.ToInt32(ViewState["CompanyID"]));

                if (dsDept.Tables.Count > 0)
                {
                    if (dsDept.Tables[0].Rows.Count > 0)
                    {
                        ddlDepartment.DataSource = dsDept.Tables[0];
                        ddlDepartment.DataTextField = "Department";
                        ddlDepartment.DataValueField = "Department_ID";
                        ddlDepartment.DataBind();
                        ddlDepartment.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SaveVisitData()
        {
            try
            {
                #region UserData
                int RequestID = 0;
                char Action = 'N';
                if (ViewState["Action"] != null)
                {
                    Action = Convert.ToChar(ViewState["Action"]);
                }
                if (ViewState["RequestID"] != null)
                {
                    RequestID = Convert.ToInt32(ViewState["RequestID"]);
                }
                ConfigID = Convert.ToInt32(ViewState["ConfigID"]);
                string LoggedInUser = LoggedInUserID;
                string ClosingRemark = txtClosingRemarks.Text.Trim();
                string strName = txtName.Text;
                string strEmail = txtEmail.Text;
                string strPhone = txtPhone.Text;
                string strVisitDate = txtVMSDate.Text != null ? txtVMSDate.Text : DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                string strMeetUsers = hdnSelectedUserID.Value;
                string strCovidTestDate = txtAsmmtDate.Text != null ? txtAsmmtDate.Text : DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
                string strTemperature = txtTemperature.Text;
                string strCovidColor = string.Empty;
                if (rdbGreen.Checked == true)
                { strCovidColor = "GREEN"; }
                if (rdbOrange.Checked == true)
                { strCovidColor = "ORANGE"; }
                if (rdbRed.Checked == true)
                { strCovidColor = "RED"; }
                #endregion

                #region VisitQuestion
                /*
                 Create table and store data in table and convert later in xml and pass in to Datatbase..
                 Table Structure :  QuestionID | AnswerID | Data
                */

                string strVMSData = "";

                Send_eFacilito_SMS sms1 = new Send_eFacilito_SMS();



                if (Action != 'N')
                    goto Save;

                DataTable dt = new DataTable();
                dt.Clear();
                dt.TableName = "TableVisitQuestion";
                dt.Columns.Add("QuestionID");
                dt.Columns.Add("AnswerID");
                dt.Columns.Add("Data");
                // dt.Columns.Add("DataValue");  //Add by Mohammed
                // dtRow["SectionID"] = ""; dtRow["QuestionID"] = ""; dtRow["AnswerID"] = ""; dtRow["Data"] = ""; 

                string Is_Not_Valid = "False";


                foreach (RepeaterItem itemQuestion in rptQuestionDetails.Items)
                {

                    string AnswerType = (itemQuestion.FindControl("hdnAnswerTypeSDesc") as HiddenField).Value;
                    string Is_Mandatory = Convert.ToString((itemQuestion.FindControl("hdnIs_Mandatory") as HiddenField).Value);
                    Label lblQuestionErr = (itemQuestion.FindControl("lblQuestionErr") as Label);
                    string isField = "False";

                    int AnswerTypeID = Convert.ToInt32((itemQuestion.FindControl("hdnAnswerID") as HiddenField).Value);
                    string HeadId = (itemQuestion.FindControl("hfQuestionId") as HiddenField).Value;

                    if (AnswerType == "MSLCT") //Multi Selection [CheckBox]
                    {
                        CheckBoxList divCheckBoxIDI = itemQuestion.FindControl("divCheckBoxIDI") as CheckBoxList;
                        List<String> chkStrList = new List<string>();


                        foreach (ListItem item in divCheckBoxIDI.Items)
                        {
                            if (item.Selected)
                            {
                                isField = "True";

                                chkStrList.Add(item.Value);
                                DataRow dtRow = dt.NewRow();
                                dtRow["QuestionID"] = HeadId;
                                dtRow["AnswerID"] = AnswerTypeID;
                                dtRow["Data"] = item;
                                // dtRow["DataValue"] = item;
                                dt.Rows.Add(dtRow);
                            }
                        }

                        if (Is_Mandatory == "*")
                        {
                            if (isField == "False")
                            {
                                Is_Not_Valid = "True";
                                lblQuestionErr.Text = "Please provide valid data.";
                            }
                        }

                        //String YrStr = String.Join(";", chkStrList.ToArray());
                    }
                    else if (AnswerType == "SSLCT") //Single Selection [Radio Button]
                    {
                        RadioButtonList divRadioButtonrdbYes = itemQuestion.FindControl("divRadioButtonrdbYes") as RadioButtonList;
                        List<String> RadioStrList = new List<string>();
                        foreach (ListItem item in divRadioButtonrdbYes.Items)
                        {
                            if (item.Selected)
                            {
                                isField = "True";
                                RadioStrList.Add(item.Value);

                                DataRow dtRow = dt.NewRow();
                                dtRow["QuestionID"] = HeadId;
                                dtRow["AnswerID"] = AnswerTypeID;
                                // dtRow["Data"] = item.Value;
                                dtRow["Data"] = item;
                                //  dtRow["DataValue"] = item;
                                dt.Rows.Add(dtRow);
                            }
                        }
                        if (Is_Mandatory == "*")
                        {
                            if (isField == "False")
                            {
                                Is_Not_Valid = "True";
                                lblQuestionErr.Text = "Please provide valid data.";
                            }
                        }
                        //String YrStr = String.Join(";", RadioStrList.ToArray());

                    }
                    else if (AnswerType == "IMAGE") //Image Upload  
                    {
                        HtmlGenericControl sample = itemQuestion.FindControl("divImage") as HtmlGenericControl;

                        FileUpload ChecklistImage = (FileUpload)itemQuestion.FindControl("FileUpload_ChecklistImage");


                        if (ChecklistImage.HasFile)
                        {
                            isField = "True";
                            List<int> Lst_ValidImage = new List<int>();
                            List<int> Lst_ImageSaved = new List<int>();
                            List<string> Lst_Images = new List<string>();
                            string CurrentDate = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));
                            string fileName = string.Empty;

                            string fileUploadPath = HttpContext.Current.Server.MapPath("~/VMSImages/" + CurrentDate);
                            if (!Directory.Exists(fileUploadPath))
                            {
                                Directory.CreateDirectory(fileUploadPath);
                            }

                            int i = 0;

                            foreach (HttpPostedFile postfiles in ChecklistImage.PostedFiles)
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
                            foreach (HttpPostedFile postfiles in ChecklistImage.PostedFiles)
                            {
                                string filetype = Path.GetExtension(postfiles.FileName);
                                if (filetype.ToLower() == ".jpg" || filetype.ToLower() == ".png")
                                {
                                    try
                                    {
                                        fileName = HeadId + "_" + AnswerType + "_" + Convert.ToString(i) + filetype;
                                        string imgPath = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadURL"]);
                                        string SaveLocation = Server.MapPath("~/VMSImages/" + CurrentDate) + "/" + fileName;
                                        string FileLocation = imgPath + "/VMSImages/" + CurrentDate + "/" + fileName;// + "*WP";
                                        string ImageName = Path.GetFileName(postfiles.FileName);
                                        Stream strm = postfiles.InputStream;  //FileUpload_TicketImage.PostedFile.InputStream;
                                        var targetFile = SaveLocation;

                                        if (!Lst_ValidImage.Contains(0))
                                        {
                                            postfiles.SaveAs(SaveLocation);
                                            Lst_Images.Add(FileLocation);

                                            isField = "True";
                                            DataRow dtRow = dt.NewRow();
                                            dtRow["QuestionID"] = HeadId;
                                            dtRow["AnswerID"] = AnswerTypeID;
                                            dtRow["Data"] = FileLocation;
                                            //  dtRow["DataValue"] = FileLocation;
                                            dt.Rows.Add(dtRow);
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
                                    Lst_ValidImage.Add(0);  // image extension is not proper
                                }
                                i = i + 1;
                            }
                        }


                        if (Is_Mandatory == "*")
                        {
                            if (isField == "False")
                            {
                                Is_Not_Valid = "True";
                                lblQuestionErr.Text = "Please provide valid data.";
                            }
                        }

                    }
                    else if (AnswerType == "NUMBR") //Number Text Field
                    {
                        // isField = "True";
                        HtmlGenericControl sample = itemQuestion.FindControl("divNumber") as HtmlGenericControl;
                        string txtNum = sample.Controls[1].UniqueID;
                        string sVal = Request.Form.GetValues(txtNum)[0];

                        if (sVal == "")
                        {
                            isField = "False";
                        }
                        else
                        {
                            isField = "True";
                        }
                        DataRow dtRow = dt.NewRow();
                        dtRow["QuestionID"] = HeadId;
                        dtRow["AnswerID"] = AnswerTypeID;
                        dtRow["Data"] = sVal;
                        // dtRow["DataValue"] = sVal;
                        dt.Rows.Add(dtRow);

                        if (Is_Mandatory == "*")
                        {
                            if (isField == "False")
                            {
                                Is_Not_Valid = "True";
                                lblQuestionErr.Text = "Please provide valid data.";
                            }
                        }

                    }
                    else if (AnswerType == "STEXT") //Normal Text Field
                    {
                        // isField = "True";
                        HtmlGenericControl sample = itemQuestion.FindControl("divText") as HtmlGenericControl;
                        string txtNum = sample.Controls[1].UniqueID;
                        string sVal = Request.Form.GetValues(txtNum)[0];
                        if (sVal == "")
                        {
                            isField = "False";
                        }
                        else
                        {
                            isField = "True";
                        }

                        DataRow dtRow = dt.NewRow();
                        dtRow["QuestionID"] = HeadId;
                        dtRow["AnswerID"] = AnswerTypeID;
                        dtRow["Data"] = sVal;
                        // dtRow["DataValue"] = sVal;
                        dt.Rows.Add(dtRow);



                        if (Is_Mandatory == "*")
                        {
                            if (isField == "False")
                            {
                                Is_Not_Valid = "True";
                                lblQuestionErr.Text = "Please provide valid data.";
                            }
                        }
                    }
                    else if (AnswerType == "LTEXT") // Textarea Field
                    {
                        isField = "True";
                        HtmlGenericControl sample = itemQuestion.FindControl("divTextArea") as HtmlGenericControl;
                        string txtNum = sample.Controls[1].UniqueID;
                        string sVal = Request.Form.GetValues(txtNum)[0];
                        if (sVal == "")
                        {
                            isField = "False";
                        }
                        else
                        {
                            isField = "True";
                        }
                        DataRow dtRow = dt.NewRow();
                        dtRow["QuestionID"] = HeadId;
                        dtRow["AnswerID"] = AnswerTypeID;
                        dtRow["Data"] = sVal;
                        // dtRow["DataValue"] = sVal;
                        dt.Rows.Add(dtRow);


                        if (Is_Mandatory == "*")
                        {
                            if (isField == "False")
                            {
                                Is_Not_Valid = "True";
                                lblQuestionErr.Text = "Please provide valid data.";
                            }
                        }
                    }
                    else  //Normal Text Field
                    {
                        isField = "True";
                        HtmlGenericControl sample = itemQuestion.FindControl("divText") as HtmlGenericControl;
                        string txtNum = sample.Controls[1].UniqueID;
                        string sVal = Request.Form.GetValues(txtNum)[0];
                        if (sVal == "")
                        {
                            isField = "False";
                        }
                        else
                        {
                            isField = "True";
                        }
                        DataRow dtRow = dt.NewRow();
                        dtRow["QuestionID"] = HeadId;
                        dtRow["AnswerID"] = AnswerTypeID;
                        dtRow["Data"] = sVal;
                        //dtRow["DataValue"] = sVal;
                        dt.Rows.Add(dtRow);


                        if (Is_Mandatory == "*")
                        {
                            if (isField == "False")
                            {
                                Is_Not_Valid = "True";
                                lblQuestionErr.Text = "Please provide valid data.";
                            }
                        }
                    }
                }



                if (Is_Not_Valid == "True")
                {
                    //call repeater
                    BindVMSConfig();
                    return;
                }

                if (dt.Rows.Count > 0)
                {
                    DataTable DTS = new DataTable();
                    DTS = dt.Copy();

                    MemoryStream str = new MemoryStream();
                    DTS.WriteXml(str, true);
                    str.Seek(0, SeekOrigin.Begin);
                    StreamReader sr = new StreamReader(str);
                    string xmlstr;
                    xmlstr = sr.ReadToEnd();
                    strVMSData = xmlstr;
                }
            #endregion

            #region SaveDataToDB
            Save:
                DataSet dsVMSQuestionData = new DataSet();
                dsVMSQuestionData = ObjUpkeep.Insert_VMSRequest(Convert.ToInt32(ViewState["CompanyID"]), Action, RequestID, ConfigID, ClosingRemark, strName, strEmail, strPhone, strVisitDate, strMeetUsers, strVMSData, strCovidColor, strCovidTestDate, strTemperature, "", "", "", "", LoggedInUserID);

                if (dsVMSQuestionData.Tables.Count > 0)
                {
                    if (dsVMSQuestionData.Tables[0].Rows.Count > 0)
                    {
                        int status = Convert.ToInt32(dsVMSQuestionData.Tables[0].Rows[0]["Status"]);
                        int SMS_Enabled = Convert.ToInt32(dsVMSQuestionData.Tables[1].Rows[0]["SMS_Enabled"]);
                        string Send_SMS_URL = Convert.ToString(dsVMSQuestionData.Tables[2].Rows[0]["Send_SMS_URL"]);
                        string User_ID = Convert.ToString(dsVMSQuestionData.Tables[2].Rows[0]["User_ID"]);
                        string Password = Convert.ToString(dsVMSQuestionData.Tables[2].Rows[0]["Password"]);
                        string DLT_Template_ID = string.Empty;
                        if (dsVMSQuestionData.Tables[3].Columns.Contains("DLT_Template_ID"))
                            DLT_Template_ID = Convert.ToString(dsVMSQuestionData.Tables[3].Rows[0]["DLT_Template_ID"]);
                        string Company_Desc = Convert.ToString(dsVMSQuestionData.Tables[2].Rows[0]["Company_Name"]);
                        string Visitor_ID_Link = Convert.ToString(dsVMSQuestionData.Tables[2].Rows[0]["Visitor_ID_Link"]);

                        int Visit_Request_ID = Convert.ToInt32(dsVMSQuestionData.Tables[0].Rows[0]["RequestID"]);
                        string TextMessage = string.Empty;

                        string Custom_SMS_Msg = Convert.ToString(dsVMSQuestionData.Tables[4].Rows[0]["Custom_SMS"]);
                        string Custom_DLT_Template_ID = Convert.ToString(dsVMSQuestionData.Tables[4].Rows[0]["Custom_DLT_Template_ID"]);

                        string Custom_SMS_Message = HttpUtility.UrlEncode(Custom_SMS_Msg, System.Text.Encoding.GetEncoding("ISO-8859-1"));

                        string Custom_TextMessage = "Dear " + strName + "," + "%0a%0aYou have a new Message. %0a%0a" + Custom_SMS_Message + "%0a%0agenerated from eFacilito.";

                        if (status == 1 && Action == 'N')
                        {
                            //SetRepeater();
                            //divinsertbutton.visible = false;
                            lblVMSRequestCode.Text = Convert.ToString(dsVMSQuestionData.Tables[0].Rows[0]["RequestID"]);

                            mpeVMSRequestSaveSuccess.Show();

                            TextMessage = "Dear " + strName + "," + "%0a%0aThanks for registering your Visit Request at Company_Name through eFacilito. We will notify you soon once your Visitor ID is ready." + "%0a%0aVisit Request ID : " + Visit_Request_ID;

                            if (SMS_Enabled > 0)
                            {
                                string response = sms1.Send_SMS(Send_SMS_URL, User_ID, Password, strPhone, TextMessage, DLT_Template_ID);
                            }

                        }
                        else if (status == 1 && Action == 'I')
                        {
                            Response.Write("<script>alert('Status changed.');</script>");

                            TextMessage = "Dear " + strName + "," + "%0a%0aYour Visit Request ID " + Visit_Request_ID + " is Approved and you can now use your Digital Visitor Pass to visit " + Company_Desc + " , by clicking the link below." + "%0a%0aeFacilito Visitor Pass >> " + Visitor_ID_Link;

                            if (SMS_Enabled > 0)
                            {
                                string response = sms1.Send_SMS(Send_SMS_URL, User_ID, Password, strPhone, TextMessage, DLT_Template_ID);
                            }
                            if (Custom_DLT_Template_ID != "")
                            {
                                string custom_sms_response = sms1.Send_SMS(Send_SMS_URL, User_ID, Password, strPhone, Custom_TextMessage, Custom_DLT_Template_ID);
                            }

                            Response.Redirect(Page.ResolveClientUrl("~/VMS/VMSRequest_Listing.aspx"), false);
                        }
                        else if (status == 1 && Action == 'R')
                        {
                            Response.Write("<script>alert('Status changed.');</script>");

                            TextMessage = "Dear " + strName + "," + "%0a%0aYour visit Request ID " + Visit_Request_ID + " registered using eFacilito has been rejected by " + Company_Desc + " . You may submit your request again.";

                            if (SMS_Enabled > 0)
                            {
                                string response = sms1.Send_SMS(Send_SMS_URL, User_ID, Password, strPhone, TextMessage, DLT_Template_ID);
                            }
                            if (Custom_DLT_Template_ID != "")
                            {
                                string custom_sms_response = sms1.Send_SMS(Send_SMS_URL, User_ID, Password, strPhone, Custom_TextMessage, Custom_DLT_Template_ID);
                            }

                            Response.Redirect(Page.ResolveClientUrl("~/VMS/VMSRequest_Listing.aspx"), false);
                        }
                        else if (status == 1 && Action == 'O')
                        {
                            divAlertOpen.Visible = false;
                            divAlertClosed.Visible = true;
                            btnSave.Visible = false;
                            txtClosingRemarks.ReadOnly = true;

                            if (Custom_DLT_Template_ID != "")
                            {
                                string custom_sms_response = sms1.Send_SMS(Send_SMS_URL, User_ID, Password, strPhone, Custom_TextMessage, Custom_DLT_Template_ID);
                            }
                        }
                        else if (status == 5)
                        {
                            divCountFull.Visible = true;
                            // Response.Write("<script>alert('Count is Full.');</script>");
                            // Response.Redirect(Page.ResolveClientUrl("~/VMS/VMSRequest_Listing.aspx"), false);
                        }
                        else
                        {
                            SetRepeater();
                            divError.Visible = true;
                            lblErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly contact support team.";
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        protected void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, "[^0-9]"))
            {
                lblErrorMsg.Text = "Please enter only number";
                // MessageBox.Show("Please enter only numbers.");
                txtPhone.Text = txtPhone.Text.Remove(txtPhone.Text.Length - 1);
            }
        }

    }
}