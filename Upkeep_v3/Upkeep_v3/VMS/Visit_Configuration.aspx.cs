using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using System.Text;
using System.Data;

namespace Upkeep_v3.VMS
{
    public partial class Visit_Configuration : System.Web.UI.Page
    {
        int CompanyID = 0;

        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int ConfigID = 0;

        DataSet dsConfig = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            string strConfigID = string.Empty;
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            ChkNameComp.Enabled = false;
            //frmGatePass.Action = @"GatePass_Configuration.aspx";
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }

            if (!IsPostBack)
            {
                ViewState["CompanyID"] = 0;
                if (!System.String.IsNullOrWhiteSpace(Convert.ToString(Session["CompanyID"])))
                {
                    if (Convert.ToString(Session["CompanyID"]).All(char.IsDigit))
                    {

                        ViewState["CompanyID"] = Convert.ToInt32(Session["CompanyID"]);
                    }
                }
                Fetch_Answer();
                ViewState["ConfigID"] = 0;
                BindFeedbackEventTitle();
                if (!System.String.IsNullOrWhiteSpace(Request.QueryString["ConfigID"]))
                {
                    strConfigID = Request.QueryString["ConfigID"].ToString();
                    if (strConfigID.All(char.IsDigit))
                        ViewState["ConfigID"] = Convert.ToInt32(strConfigID);

                    btnSave.Text = "Update";
                    BindVMSConfig();
                }
                else if (!System.String.IsNullOrWhiteSpace(Request.QueryString["DelVMSConfigID"]))
                {
                    strConfigID = Request.QueryString["DelVMSConfigID"].ToString();
                    if (strConfigID.All(char.IsDigit))
                        ConfigID = Convert.ToInt32(strConfigID);

                    ViewState["ConfigID"] = ConfigID;
                    DataSet dsVMSConfig = new DataSet();
                    dsVMSConfig = ObjUpkeep.Delete_VMSConfiguration(ConfigID, LoggedInUserID);
                    if (dsVMSConfig.Tables.Count > 0)
                    {
                        if (dsVMSConfig.Tables[0].Rows.Count > 0)
                        {
                            int Status = Convert.ToInt32(dsVMSConfig.Tables[0].Rows[0]["Status"]);
                            if (Status == 1)
                            {
                                Response.Redirect(Page.ResolveClientUrl("~/VMS/VMSConfig_Listing.aspx"), false);
                            }
                            else if (Status == 2)
                            {
                                divError.Visible = true;
                                lblErrorMsg.Text = "Requests found can't delete you can edit.";
                                btnSave.Text = "Update";
                                BindVMSConfig();
                            }
                        }
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string VMSQuestionID = string.Empty;
                string VMSQuestion = string.Empty;
                string VMSQuestionMandatory = string.Empty;
                string VMSQuestionVisible = string.Empty;
                string VMSQuestionAns = string.Empty;
                string VMSQuestionAnsData = string.Empty;
                string VMSTermCondition = string.Empty;
                string VMS_SMS_Template = string.Empty;
                //string VMSFeedback = string.Empty;
                //string VMSFeedbackMandatory = string.Empty;
                //string VMSFeedbackVisible = string.Empty;
                //string VMSFeedbackAns = string.Empty;
                //string VMSFeedbackAnsData = string.Empty;

                StringBuilder strXmlVMS_Question = new StringBuilder();
                strXmlVMS_Question.Append(@"<?xml version=""1.0"" ?>");
                strXmlVMS_Question.Append(@"<VMS_HEADER_ROOT>");

                StringBuilder strXmlVMS_Feedback = new StringBuilder();
                strXmlVMS_Feedback.Append(@"<?xml version=""1.0"" ?>");
                //strXmlVMS_Feedback.Append(@"<VMS_FEEDBACK_ROOT>");

                int Qln = 0;
                if (String.IsNullOrEmpty(txtQuestionCount.Value)) { Qln = 0; }
                else { Qln = Convert.ToInt32(txtQuestionCount.Value); }

                //int Fln = 0;
                //if (String.IsNullOrEmpty(txtFeedbackCount.Value)) { Fln = 0; }
                //else { Fln = Convert.ToInt32(txtFeedbackCount.Value); }

                for (int i = 0; i < Qln; i++)
                {
                    VMSQuestionID = "0";
                    VMSQuestion = "";
                    VMSQuestionVisible = "0";
                    VMSQuestionMandatory = "0";
                    VMSQuestionAns = "";
                    VMSQuestionAnsData = "";

                    if (Request.Form.GetValues("VMSQuestion[" + i + "][ctl00$ContentPlaceHolder1$hdnQnID]")[0] != string.Empty)
                        VMSQuestionID = Request.Form.GetValues("VMSQuestion[" + i + "][ctl00$ContentPlaceHolder1$hdnQnID]")[0];
                    if (Request.Form.GetValues("VMSQuestion[" + i + "][ctl00$ContentPlaceHolder1$txtVMSQuestion]")[0] != string.Empty)
                        VMSQuestion = Request.Form.GetValues("VMSQuestion[" + i + "][ctl00$ContentPlaceHolder1$txtVMSQuestion]")[0];
                    if (Request.Form.GetValues("VMSQuestion[" + i + "][ctl00$ContentPlaceHolder1$ddlAns]") != null)
                        VMSQuestionAns = Request.Form.GetValues("VMSQuestion[" + i + "][ctl00$ContentPlaceHolder1$ddlAns]")[0];
                    if (Request.Form.GetValues("VMSQuestion[" + i + "][hdnRepeaterAnswer]")[0] != string.Empty)
                        VMSQuestionAnsData = Request.Form.GetValues("VMSQuestion[" + i + "][hdnRepeaterAnswer]")[0];

                    if (Request.Form.AllKeys.Contains("VMSQuestion[" + i + "][ctl00$ContentPlaceHolder1$ChkVisible][]"))
                        VMSQuestionVisible = "1";
                    if (Request.Form.AllKeys.Contains("VMSQuestion[" + i + "][ctl00$ContentPlaceHolder1$ChkMandatory][]"))
                        VMSQuestionMandatory = "1";


                    strXmlVMS_Question.Append(@"<Question_Desc>");
                    strXmlVMS_Question.Append(@"<Question_Sequence>" + i + "</Question_Sequence>");
                    strXmlVMS_Question.Append(@"<Question_Id>" + VMSQuestionID.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Id>");
                    strXmlVMS_Question.Append(@"<Question_Header>" + VMSQuestion.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Header>");
                    strXmlVMS_Question.Append(@"<Question_Visible>" + VMSQuestionVisible.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Visible>");
                    strXmlVMS_Question.Append(@"<Question_Mandatory>" + VMSQuestionMandatory.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Mandatory>");
                    strXmlVMS_Question.Append(@"<Question_Ans>" + VMSQuestionAns.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Ans>");

                    strXmlVMS_Question.Append(@"<Question_Ans_Data_Root>");
                    string[] strValueData = VMSQuestionAnsData.Split(';');

                    if (strValueData.Length == 1)
                    {
                        strXmlVMS_Question.Append(@"<Question_Ans_Data>");

                        strXmlVMS_Question.Append(@"<Question_Ans_Sequence>0</Question_Ans_Sequence>");
                        strXmlVMS_Question.Append(@"<Question_Ans_Data_ID></Question_Ans_Data_ID>");
                        strXmlVMS_Question.Append(@"<Question_Ans_Data_Text></Question_Ans_Data_Text>");
                        strXmlVMS_Question.Append(@"<Question_Ans_Data_IsFlag></Question_Ans_Data_IsFlag>");

                        strXmlVMS_Question.Append(@"</Question_Ans_Data>");
                    }
                    else
                    {
                        for (int f = 0; f <= strValueData.Length - 1; f++)
                        {
                            //string[] strValue = strValueData[f].Split(new[] { "::" }, StringSplitOptions.None);
                            string[] strValue = strValueData[f].Split(':');

                            //string isFlag = "0";
                            //if (strValue[2].ToString() == "on") { isFlag = "1"; }

                            strXmlVMS_Question.Append(@"<Question_Ans_Data>");
                            strXmlVMS_Question.Append(@"<Question_Ans_Sequence>" + f + "</Question_Ans_Sequence>");

                            strXmlVMS_Question.Append(@"<Question_Ans_Data_ID>" + strValue[0].ToString().Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Ans_Data_ID>");
                            strXmlVMS_Question.Append(@"<Question_Ans_Data_Text>" + strValue[1].ToString().Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Ans_Data_Text>");
                            strXmlVMS_Question.Append(@"<Question_Ans_Data_IsFlag>" + strValue[2].ToString().Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Ans_Data_IsFlag>");

                            strXmlVMS_Question.Append(@"</Question_Ans_Data>");
                        }
                    }

                    strXmlVMS_Question.Append(@"</Question_Ans_Data_Root>");
                    strXmlVMS_Question.Append(@"</Question_Desc>");

                }

                strXmlVMS_Question.Append(@"</VMS_HEADER_ROOT>");
                //strXmlVMS_Feedback.Append(@"</VMS_FEEDBACK_ROOT>");

                StringBuilder strXmlVMS_TermCondition = new StringBuilder();
                strXmlVMS_TermCondition.Append(@"<?xml version=""1.0"" ?>");
                strXmlVMS_TermCondition.Append(@"<VMS_TERM_ROOT>");

                int ccc = Request.Form.Count;
                for (int j = 0; j < ccc; j++)
                {
                    VMSTermCondition = "";
                    string[] VMSCondition_Array = Request.Form.GetValues("VMSTermCondition[" + j + "][ctl00$ContentPlaceHolder1$txtTermCondition]");
                    if (VMSCondition_Array != null)
                    {
                        VMSTermCondition = VMSCondition_Array[0];
                    }

                    if (VMSCondition_Array != null)
                    {
                        if (VMSTermCondition != "")
                        {
                            strXmlVMS_TermCondition.Append(@"<VMS_TERM_DESC>");
                            strXmlVMS_TermCondition.Append(@"<VMS_TERM>" + VMSTermCondition + "</VMS_TERM>");
                            strXmlVMS_TermCondition.Append(@"</VMS_TERM_DESC>");
                        }
                    }
                }

                strXmlVMS_TermCondition.Append(@"</VMS_TERM_ROOT>");

                //SMS Template
                StringBuilder strXmlVMS_SMS_Template = new StringBuilder();
                strXmlVMS_SMS_Template.Append(@"<?xml version=""1.0"" ?>");
                strXmlVMS_SMS_Template.Append(@"<VMS_SMS_TEMPLATE>");
                string SMS_Type = string.Empty;

                int iSMS = Request.Form.Count;
                for (int j = 0; j < iSMS; j++)
                {
                    VMS_SMS_Template = "";
                    SMS_Type = "";
                    string[] VMS_SMS_Array = Request.Form.GetValues("VMS_SMSTemplate[" + j + "][ctl00$ContentPlaceHolder1$txtSMSTemplate]");


                    if (VMS_SMS_Array != null && VMS_SMS_Array[0] != string.Empty)
                    {
                        VMS_SMS_Template = VMS_SMS_Array[0];
                        VMS_SMS_Template = VMS_SMS_Template.Replace("&", "&amp;");
                        SMS_Type = Request.Form.GetValues("VMS_SMSTemplate[" + j + "][ctl00$ContentPlaceHolder1$ddlSMS]")[0];
                    }

                    if (VMS_SMS_Array != null && VMS_SMS_Array[0] != string.Empty)
                    {
                        if (VMS_SMS_Template != "")
                        {
                            strXmlVMS_SMS_Template.Append(@"<VMS_SMS_DESC>");
                            strXmlVMS_SMS_Template.Append(@"<VMS_SMS>" + VMS_SMS_Template + "</VMS_SMS>");
                            strXmlVMS_SMS_Template.Append(@"<VMS_SMS_TYPE>" + SMS_Type + "</VMS_SMS_TYPE>");
                            strXmlVMS_SMS_Template.Append(@"</VMS_SMS_DESC>");
                        }
                    }
                }

                strXmlVMS_SMS_Template.Append(@"</VMS_SMS_TEMPLATE>");

                string SMS_Template_Details = strXmlVMS_SMS_Template.ToString();


                int ConfigID = Convert.ToInt32(ViewState["ConfigID"]);
                string strConfigTitle = string.Empty;
                string strConfigDesc = string.Empty;
                int CompanyID = Convert.ToInt32(ViewState["CompanyID"]);
                string strInitiator = string.Empty;
                bool blFeedbackCompulsary = false;
                bool blEnableCovid = false;
                bool blEnableVaccination = false;
                int FeedbackTitle = 0;
                int EntryCount = 0;
                bool blNameComp = false;
                bool blEmailComp = false;
                bool blContactComp = false;
                bool blMeetingComp = false;
                bool blContactOtpComp = false;
                bool blEmailOtpComp = false;


                strConfigTitle = txtTitle.Text.Trim();
                strConfigDesc = txtVMSDesc.Text.Trim();
                if (txtCount.Text.All(char.IsDigit))
                    EntryCount = Convert.ToInt32(txtCount.Text);
                if (rdbCustomer.Checked == true)
                { strInitiator = "C"; }
                if (rdbVisitor.Checked == true)
                { strInitiator = "V"; }

                blNameComp = Convert.ToBoolean(ChkNameComp.Checked);
                blEmailComp = Convert.ToBoolean(ChkEmailComp.Checked);
                blContactComp = Convert.ToBoolean(ChkContactComp.Checked);
                blMeetingComp = Convert.ToBoolean(ChkMeetingComp.Checked);
                blContactOtpComp = Convert.ToBoolean(ChkContactOTPComp.Checked);
                blEmailOtpComp = Convert.ToBoolean(ChkEmailOtpCom.Checked);

                if (ddlFeedbackTitle.SelectedValue.All(char.IsDigit))
                    FeedbackTitle = Convert.ToInt32(ddlFeedbackTitle.SelectedValue);
                blFeedbackCompulsary = Convert.ToBoolean(ChkFeedback.Checked);
                blEnableCovid = Convert.ToBoolean(ChkCovid.Checked);
                blEnableVaccination = Convert.ToBoolean(ChkVaccinated.Checked);

                string NotifyEmails = string.Empty;
                NotifyEmails = Convert.ToString(txt_Emails.Text.Trim());

                bool Is_TimeLimit_Enabled = false;
                string FromTime = string.Empty;
                string ToTime = string.Empty;

                Is_TimeLimit_Enabled = Convert.ToBoolean(ChkTimeLimit.Checked);
                FromTime = Convert.ToString(txtFromTime.Text.Trim());
                ToTime = Convert.ToString(txtToTime.Text.Trim());


                DataSet dsVMSConfig = new DataSet();
                dsVMSConfig = ObjUpkeep.Insert_Update_VMSConfiguration(ConfigID, strConfigTitle, strConfigDesc, CompanyID, strInitiator, strXmlVMS_Question.ToString(), blFeedbackCompulsary, FeedbackTitle, blEnableCovid, blEnableVaccination, EntryCount, blNameComp, blContactComp, blEmailComp, blMeetingComp, blEmailOtpComp, blContactOtpComp, strXmlVMS_TermCondition.ToString(), NotifyEmails, Is_TimeLimit_Enabled, FromTime, ToTime, SMS_Template_Details, LoggedInUserID);

                if (dsVMSConfig.Tables.Count > 0)
                {
                    if (dsVMSConfig.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsVMSConfig.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {

                            Response.Redirect(Page.ResolveClientUrl("~/VMS/VMSConfig_Listing.aspx"), false);
                        }
                        else if (Status == 3)
                        {
                            divError.Visible = true;
                            lblErrorMsg.Text = "Title already exists";
                        }

                        else if (Status == 2)
                        {
                            divError.Visible = true;
                            lblErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly contact support team.";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Fetch_Answer()
        {
            DataSet ds = new DataSet();
            try
            {

                ds = ObjUpkeep.Fetch_AnswerForAll('V');



                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlAns.DataSource = ds.Tables[0];
                        ddlAns.DataTextField = "Ans_Type_Desc";
                        ddlAns.DataValueField = "Ans_Type_ID";

                        ddlAns.DataBind();

                        //ddlFAns.DataSource = ds.Tables[0];
                        //ddlFAns.DataTextField = "Ans_Type_Desc";
                        //ddlFAns.DataValueField = "Ans_Type_ID";

                        //ddlFAns.DataBind();

                        for (int i = 0; i < ddlAns.Items.Count - 1; i++)
                            ddlAns.Items[i].Attributes["data-isMulti"] = ds.Tables[0].Rows[i]["IS_MultiValue"].ToString();

                        //ddlAns.Items.Insert(0, new ListItem("Select", "NA"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void BindFeedbackEventTitle()
        {
            DataSet dsTitle = new DataSet();
            string Initiator = string.Empty;
            try
            {
                Initiator = Convert.ToString(Session["UserType"]);
                dsTitle = ObjUpkeep.GetEventList(Convert.ToInt32(ViewState["CompanyID"]), "V");
                if (dsTitle.Tables.Count > 0)
                {
                    if (dsTitle.Tables[0].Rows.Count > 0)
                    {
                        ddlFeedbackTitle.DataSource = dsTitle.Tables[0];
                        ddlFeedbackTitle.DataTextField = "Event_Name";
                        ddlFeedbackTitle.DataValueField = "Event_ID";
                        ddlFeedbackTitle.DataBind();
                    }
                    ddlFeedbackTitle.Items.Insert(0, new ListItem("--Select--", "0"));
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BindVMSConfig()
        {
            try
            {
                //lblRequestDate.Text = DateTime.Now.ToString("dd/MMM/yyyy hh:mm tt");
                int ConfigTitleID = Convert.ToInt32(ViewState["ConfigID"]);
                dsConfig = ObjUpkeep.Bind_VMSConfiguration(ConfigTitleID);

                if (!System.String.IsNullOrWhiteSpace(dsConfig.Tables[0].Rows[0]["Config_Title"].ToString()))
                {
                    //divDesc.Visible = true;
                    hdnVMSConfigID.Value = ConfigTitleID.ToString();
                    txtTitle.Text = dsConfig.Tables[0].Rows[0]["Config_Title"].ToString();
                    txtVMSDesc.Text = dsConfig.Tables[0].Rows[0]["Config_Desc"].ToString();
                    txtCount.Text = dsConfig.Tables[0].Rows[0]["EntryCount"].ToString(); ;
                    if (dsConfig.Tables[0].Rows[0]["Initiator"].ToString() == "C")
                    {
                        rdbCustomer.Checked = true;
                        rdbVisitor.Checked = false;
                    }
                    else if (dsConfig.Tables[0].Rows[0]["Initiator"].ToString() == "V")
                    {
                        rdbVisitor.Checked = true;
                        rdbCustomer.Checked = false;
                    }
                    ChkFeedback.Checked = Convert.ToBoolean(dsConfig.Tables[0].Rows[0]["Feedback_Is_Compulsory"]);
                    ChkCovid.Checked = Convert.ToBoolean(dsConfig.Tables[0].Rows[0]["isCovidEnable"]);
                    ddlFeedbackTitle.SelectedValue = dsConfig.Tables[0].Rows[0]["Feedback_ID"].ToString();
                    ChkNameComp.Checked = true;
                    ChkContactComp.Checked = Convert.ToBoolean(dsConfig.Tables[0].Rows[0]["Is_Contact_Compulsory"]);
                    ChkEmailComp.Checked = Convert.ToBoolean(dsConfig.Tables[0].Rows[0]["Is_Email_Compulsory"]);
                    ChkMeetingComp.Checked = Convert.ToBoolean(dsConfig.Tables[0].Rows[0]["Is_MeetingWith_Compulsory"]);
                    ChkEmailOtpCom.Checked = Convert.ToBoolean(dsConfig.Tables[0].Rows[0]["Is_Email_OTP_Compulsory"]);
                    ChkContactOTPComp.Checked = Convert.ToBoolean(dsConfig.Tables[0].Rows[0]["Is_Contact_OTP_Compulsory"]);
                    ChkVaccinated.Checked = Convert.ToBoolean(dsConfig.Tables[0].Rows[0]["Vaccine_Check_Enable"]);

                    txt_Emails.Text = Convert.ToString(dsConfig.Tables[0].Rows[0]["Notify_Emails"].ToString());

                    ChkTimeLimit.Checked = Convert.ToBoolean(dsConfig.Tables[0].Rows[0]["Is_TimeLimit_Enabled"]);
                    txtFromTime.Text = Convert.ToString(dsConfig.Tables[0].Rows[0]["From_Time"].ToString());
                    txtToTime.Text = Convert.ToString(dsConfig.Tables[0].Rows[0]["To_Time"].ToString());

                    var QnValues = dsConfig.Tables[1].AsEnumerable().Select(s =>
                       s.Field<decimal>("VMS_Qn_Id").ToString() + "||" + s.Field<string>("Qn_Desc").ToString() + "||"
                       + s.Field<bool>("Is_Mandatory").ToString() + "||" + s.Field<bool>("Is_Visible").ToString() + "||"
                       + s.Field<decimal>("Ans_Type_ID") + "||" + string.Join(";", dsConfig.Tables[2].AsEnumerable().Where(ans =>
                       ans.Field<decimal>("VMS_Qn_Id").ToString() == s.Field<decimal>("VMS_Qn_Id").ToString()).Select(ans =>
                       ans.Field<decimal>("Ans_Type_Data_ID").ToString() + ":" + ans.Field<string>("Ans_Type_Data").ToString() + ":" +
                       ans.Field<bool>("Is_Flag").ToString()))).ToArray();

                    hdnVMSQns.Value = string.Join("~", QnValues);

                    var TermsValues = dsConfig.Tables[4].AsEnumerable().Select(s => s.Field<Int32>("Terms_ID").ToString() + "||" + s.Field<string>("Terms_Desc").Replace("<br>", System.Environment.NewLine)).ToArray();

                    hdnVMSTerms.Value = string.Join("~", TermsValues);

                    var SMSTemplateValues = dsConfig.Tables[6].AsEnumerable().Select(s => s.Field<Int32>("SMS_ID").ToString() + "||" + s.Field<string>("SMS_Desc") + "||" + s.Field<Int32>("SMS_Action_Code").ToString().Replace("<br>", System.Environment.NewLine)).ToArray();

                    hdnSMSTemplate.Value = string.Join("~", SMSTemplateValues);

                }




            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}