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
            //frmGatePass.Action = @"GatePass_Configuration.aspx";
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }

            if (!IsPostBack)
            {

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

                    ObjUpkeep.Delete_VMSConfiguration(ConfigID, LoggedInUserID);
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

                    VMSQuestionID = Request.Form.GetValues("VMSQuestion[" + i + "][ctl00$ContentPlaceHolder1$hdnQnID]")[0];
                    VMSQuestion = Request.Form.GetValues("VMSQuestion[" + i + "][ctl00$ContentPlaceHolder1$txtVMSQuestion]")[0];
                    VMSQuestionAns = Request.Form.GetValues("VMSQuestion[" + i + "][ctl00$ContentPlaceHolder1$ddlAns]")[0];
                    VMSQuestionAnsData = Request.Form.GetValues("VMSQuestion[" + i + "][hdnRepeaterAnswer]")[0];

                    if (Request.Form.AllKeys.Contains("VMSQuestion[" + i + "][ctl00$ContentPlaceHolder1$ChkVisible][]"))
                        VMSQuestionVisible = "1";
                    if (Request.Form.AllKeys.Contains("VMSQuestion[" + i + "][ctl00$ContentPlaceHolder1$ChkMandatory][]"))
                        VMSQuestionMandatory = "1";


                    strXmlVMS_Question.Append(@"<Question_Desc>");
                    strXmlVMS_Question.Append(@"<Question_Sequence>" + i + "</Question_Sequence>");
                    strXmlVMS_Question.Append(@"<Question_Id>" + VMSQuestionID + "</Question_Id>");
                    strXmlVMS_Question.Append(@"<Question_Header>" + VMSQuestion + "</Question_Header>");
                    strXmlVMS_Question.Append(@"<Question_Visible>" + VMSQuestionVisible + "</Question_Visible>");
                    strXmlVMS_Question.Append(@"<Question_Mandatory>" + VMSQuestionMandatory + "</Question_Mandatory>");
                    strXmlVMS_Question.Append(@"<Question_Ans>" + VMSQuestionAns + "</Question_Ans>");

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

                            strXmlVMS_Question.Append(@"<Question_Ans_Data_ID>" + strValue[0].ToString() + "</Question_Ans_Data_ID>");
                            strXmlVMS_Question.Append(@"<Question_Ans_Data_Text>" + strValue[1].ToString() + "</Question_Ans_Data_Text>");
                            strXmlVMS_Question.Append(@"<Question_Ans_Data_IsFlag>" + strValue[2].ToString() + "</Question_Ans_Data_IsFlag>");

                            strXmlVMS_Question.Append(@"</Question_Ans_Data>");
                        }
                    }

                    strXmlVMS_Question.Append(@"</Question_Ans_Data_Root>");
                    strXmlVMS_Question.Append(@"</Question_Desc>");


                }

                strXmlVMS_Question.Append(@"</VMS_HEADER_ROOT>");
                //strXmlVMS_Feedback.Append(@"</VMS_FEEDBACK_ROOT>");

                int ConfigID = Convert.ToInt32(ViewState["ConfigID"]);
                string strConfigTitle = string.Empty;
                string strConfigDesc = string.Empty;
                int CompanyID = 0;
                string strInitiator = string.Empty;
                bool blFeedbackCompulsary = false;
                bool blEnableCovid = false;
                int FeedbackTitle = 0;
                int EntryCount = 0;

                strConfigTitle = txtTitle.Text.Trim();
                strConfigDesc = txtVMSDesc.Text.Trim();
                if (txtCount.Text.All(char.IsDigit))
                    EntryCount = Convert.ToInt32(txtCount.Text);
                if (rdbCustomer.Checked == true)
                { strInitiator = "C"; }
                if (rdbVisitor.Checked == true)
                { strInitiator = "V"; }

                if (ddlFeedbackTitle.SelectedValue.All(char.IsDigit))
                    FeedbackTitle = Convert.ToInt32(ddlFeedbackTitle.SelectedValue);
                blFeedbackCompulsary = Convert.ToBoolean(ChkFeedback.Checked);
                blEnableCovid = Convert.ToBoolean(ChkCovid.Checked);

                DataSet dsVMSConfig = new DataSet();
                dsVMSConfig = ObjUpkeep.Insert_Update_VMSConfiguration(ConfigID, strConfigTitle, strConfigDesc, CompanyID, strInitiator, strXmlVMS_Question.ToString(), blFeedbackCompulsary, FeedbackTitle, blEnableCovid, EntryCount, LoggedInUserID);

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
                dsTitle = ObjUpkeep.GetEventList(CompanyID, "V");
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
                    { rdbCustomer.Checked = true; }
                    else if (dsConfig.Tables[0].Rows[0]["Initiator"].ToString() == "V")
                    { rdbVisitor.Checked = true; }
                    ChkFeedback.Checked = Convert.ToBoolean(dsConfig.Tables[0].Rows[0]["Feedback_Is_Compulsory"]);
                    ChkCovid.Checked = Convert.ToBoolean(dsConfig.Tables[0].Rows[0]["isCovidEnable"]);
                    ddlFeedbackTitle.SelectedValue = dsConfig.Tables[0].Rows[0]["Feedback_ID"].ToString();
                    
                    var QnValues = dsConfig.Tables[1].AsEnumerable().Select(s =>
                       s.Field<decimal>("VMS_Qn_Id").ToString() + "||" + s.Field<string>("Qn_Desc").ToString() + "||"
                       + s.Field<bool>("Is_Mandatory").ToString() + "||" + s.Field<bool>("Is_Visible").ToString() + "||"
                       + s.Field<decimal>("Ans_Type_ID") + "||" + string.Join(";", dsConfig.Tables[2].AsEnumerable().Where(ans =>
                       ans.Field<decimal>("VMS_Qn_Id").ToString() == s.Field<decimal>("VMS_Qn_Id").ToString()).Select(ans =>
                       ans.Field<decimal>("Ans_Type_Data_ID").ToString() + ":" + ans.Field<string>("Ans_Type_Data").ToString() + ":" +
                       ans.Field<bool>("Is_Flag").ToString()))).ToArray();

                    hdnVMSQns.Value = string.Join("~", QnValues);
                }




            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}