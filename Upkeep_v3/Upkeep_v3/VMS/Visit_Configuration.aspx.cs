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
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            //frmGatePass.Action = @"GatePass_Configuration.aspx";
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                //Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            if (!IsPostBack)
            {

                Fetch_Answer();
                //string Initiator = string.Empty;
                //if (rdbEmployee.Checked == true)
                //{
                //    Initiator = "E";
                //}
                //else if (rdbRetailer.Checked == true)
                //{
                //    Initiator = "R";
                //}

                //Fetch_User_UserGroupList(Initiator);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string VMSQuestion = string.Empty;
                string VMSQuestionMandatory = string.Empty;
                string VMSQuestionVisible = string.Empty;
                string VMSQuestionAns = string.Empty;
                string VMSQuestionAnsData = string.Empty;

                string VMSFeedback = string.Empty;
                string VMSFeedbackMandatory = string.Empty;
                string VMSFeedbackVisible = string.Empty;
                string VMSFeedbackAns = string.Empty;
                string VMSFeedbackAnsData = string.Empty;

                StringBuilder strXmlVMS_Question = new StringBuilder();
                strXmlVMS_Question.Append(@"<?xml version=""1.0"" ?>");
                strXmlVMS_Question.Append(@"<VMS_HEADER_ROOT>");

                StringBuilder strXmlVMS_Feedback = new StringBuilder();
                strXmlVMS_Feedback.Append(@"<?xml version=""1.0"" ?>");
                strXmlVMS_Feedback.Append(@"<VMS_FEEDBACK_ROOT>");

                int Qln = 0;
                if (String.IsNullOrEmpty(txtQuestionCount.Value)) { Qln = 0; }
                else { Qln = Convert.ToInt32(txtQuestionCount.Value); }

                //int Fln = 0;
                //if (String.IsNullOrEmpty(txtFeedbackCount.Value)) { Fln = 0; }
                //else { Fln = Convert.ToInt32(txtFeedbackCount.Value); }

                for (int i = 0; i < Qln; i++)
                {

                    VMSQuestion = "";
                    VMSQuestionVisible = "0";
                    VMSQuestionMandatory = "0";
                    VMSQuestionAns = "";
                    VMSQuestionAnsData = "";

                    VMSQuestion = Request.Form.GetValues("VMSQuestion[" + i + "][ctl00$ContentPlaceHolder1$txtVMSQuestion]")[0];
                    VMSQuestionAns = Request.Form.GetValues("VMSQuestion[" + i + "][ctl00$ContentPlaceHolder1$ddlAns]")[0];
                    VMSQuestionAnsData = Request.Form.GetValues("VMSQuestion[" + i + "][hdnRepeaterAnswer]")[0];

                    if (Request.Form.AllKeys.Contains("VMSQuestion[" + i + "][ctl00$ContentPlaceHolder1$ChkVisible][]"))
                        VMSQuestionVisible = "1";
                    if (Request.Form.AllKeys.Contains("VMSQuestion[" + i + "][ctl00$ContentPlaceHolder1$ChkMandatory][]"))
                        VMSQuestionMandatory = "1";


                    strXmlVMS_Question.Append(@"<Question_Desc>");
                    strXmlVMS_Question.Append(@"<Question_Header>" + VMSQuestion + "</Question_Header>");
                    strXmlVMS_Question.Append(@"<Question_Visible>" + VMSQuestionVisible + "</Question_Visible>");
                    strXmlVMS_Question.Append(@"<Question_Mandatory>" + VMSQuestionMandatory + "</Question_Mandatory>");
                    strXmlVMS_Question.Append(@"<Question_Ans>" + VMSQuestionAns + "</Question_Ans>");

                    strXmlVMS_Question.Append(@"<Question_Ans_Data_Root>");
                    string[] strValueData = VMSQuestionAnsData.Split(';');

                    if (strValueData.Length == 1)
                    {
                        strXmlVMS_Question.Append(@"<Question_Ans_Data>");

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

                            strXmlVMS_Question.Append(@"<Question_Ans_Data_ID>" + strValue[0].ToString() + "</Question_Ans_Data_ID>");
                            strXmlVMS_Question.Append(@"<Question_Ans_Data_Text>" + strValue[1].ToString() + "</Question_Ans_Data_Text>");
                            strXmlVMS_Question.Append(@"<Question_Ans_Data_IsFlag>0</Question_Ans_Data_IsFlag>");

                            strXmlVMS_Question.Append(@"</Question_Ans_Data>");
                        }
                    }

                    strXmlVMS_Question.Append(@"</Question_Ans_Data_Root>");
                    strXmlVMS_Question.Append(@"</Question_Desc>");


                }

                //for (int i = 0; i < Fln; i++)
                //{
                //    VMSFeedback = "";
                //    VMSFeedbackVisible = "0";
                //    VMSFeedbackMandatory = "0";
                //    VMSFeedbackAns = "";
                //    VMSFeedbackAnsData = "";

                //    VMSFeedback = Request.Form.GetValues("VMSFeedback[" + i + "][ctl00$ContentPlaceHolder1$txtVMSFeedback]")[0];
                //    VMSFeedbackAns = Request.Form.GetValues("VMSFeedback[" + i + "][ctl00$ContentPlaceHolder1$ddlFAns]")[0];
                //    VMSFeedbackAnsData = Request.Form.GetValues("VMSFeedback[" + i + "][hdnFRepeaterAnswer]")[0];

                //    if (Request.Form.AllKeys.Contains("VMSFeedback[" + i + "][ctl00$ContentPlaceHolder1$ChkFVisible][]"))
                //        VMSFeedbackVisible = "1";
                //    if (Request.Form.AllKeys.Contains("VMSFeedback[" + i + "][ctl00$ContentPlaceHolder1$ChkFMandatory][]"))
                //        VMSFeedbackMandatory = "1";

                //    strXmlVMS_Feedback.Append(@"<Feedback_Desc>");
                //    strXmlVMS_Feedback.Append(@"<Feedback_Header>" + VMSFeedback + "</Feedback_Header>");
                //    strXmlVMS_Feedback.Append(@"<Feedback_Visible>" + VMSFeedbackVisible + "</Feedback_Visible>");
                //    strXmlVMS_Feedback.Append(@"<Feedback_Mandatory>" + VMSFeedbackMandatory + "</Feedback_Mandatory>");
                //    strXmlVMS_Feedback.Append(@"<Feedback_Ans>" + VMSFeedbackAns + "</Feedback_Ans>");

                //    strXmlVMS_Feedback.Append(@"<Feedback_Ans_Data_Root>");
                //    string[] strValueData = VMSFeedbackAnsData.Split(';');

                //    if (strValueData.Length == 1)
                //    {
                //        strXmlVMS_Feedback.Append(@"<Feedback_Ans_Data>");

                //        strXmlVMS_Feedback.Append(@"<Feedback_Ans_Data_ID></Feedback_Ans_Data_ID>");
                //        strXmlVMS_Feedback.Append(@"<Feedback_Ans_Data_Text></Feedback_Ans_Data_Text>");
                //        strXmlVMS_Feedback.Append(@"<Feedback_Ans_Data_IsFlag></Feedback_Ans_Data_IsFlag>");

                //        strXmlVMS_Feedback.Append(@"</Feedback_Ans_Data>");
                //    }
                //    else
                //    {
                //        for (int f = 0; f <= strValueData.Length - 1; f++)
                //        {
                //            //string[] strValue = strValueData[f].Split(new[] { "::" }, StringSplitOptions.None);
                //            string[] strValue = strValueData[f].Split(':');

                //            //string isDefault = "0", isFlag = "0";
                //            //if (strValue[2].ToString() == "on") { isFlag = "1"; }

                //            strXmlVMS_Feedback.Append(@"<Feedback_Ans_Data>");

                //            strXmlVMS_Feedback.Append(@"<Feedback_Ans_Data_ID>" + strValue[0].ToString() + "</Feedback_Ans_Data_ID>");
                //            strXmlVMS_Feedback.Append(@"<Feedback_Ans_Data_Text>" + strValue[1].ToString() + "</Feedback_Ans_Data_Text>");
                //            strXmlVMS_Feedback.Append(@"<Feedback_Ans_Data_IsFlag>0</Feedback_Ans_Data_IsFlag>");

                //            strXmlVMS_Feedback.Append(@"</Feedback_Ans_Data>");
                //        }
                //    }
                //    strXmlVMS_Feedback.Append(@"</Feedback_Ans_Data_Root>");
                //    strXmlVMS_Feedback.Append(@"</Feedback_Desc>");
                //}


                strXmlVMS_Question.Append(@"</VMS_HEADER_ROOT>");
                strXmlVMS_Feedback.Append(@"</VMS_FEEDBACK_ROOT>");

                string strConfigTitle = string.Empty;
                string strConfigDesc = string.Empty;
                int CompanyID = 0;
                string strInitiator = string.Empty;
                bool blFeedbackCompulsary = false;

                strConfigTitle = txtTitle.Text.Trim();
                strConfigDesc = txtVMSDesc.Text.Trim();
                //CompanyID = Convert.ToInt32(ddlCompany.SelectedValue);
                blFeedbackCompulsary = Convert.ToBoolean(ChkFeedback.Checked);

                DataSet dsVMSConfig = new DataSet();
                dsVMSConfig = ObjUpkeep.Insert_VMSConfiguration(strConfigTitle, strConfigDesc, CompanyID, strXmlVMS_Question.ToString(), strXmlVMS_Feedback.ToString(), blFeedbackCompulsary, LoggedInUserID);

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
                            lblErrorMsg.Text = "Title already exists";
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

        public void Fetch_Answer()
        {
            DataSet ds = new DataSet();
            try
            {

                ds = ObjUpkeep.Fetch_Answer('V');



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

                        //ddlAns.Items.Insert(0, new ListItem("Select", "NA"));
                        //for (int i = 0; i < ddlAns.Items.Count; i++)
                        //    ddlAns.Items[i].Attributes["data-content"] = "<i class='fa fa-" + ds.Tables[0].Rows[i]["Icon"] + "'> " + ds.Tables[0].Rows[i]["Ans_Type_Desc"] + "</i>";

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