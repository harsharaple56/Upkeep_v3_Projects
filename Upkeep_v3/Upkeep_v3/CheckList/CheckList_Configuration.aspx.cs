using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Text;
using System.Data;
using System.IO;
using System.Configuration;

namespace Upkeep_v3.CheckList
{
    public partial class CheckList_Configuration : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int Chk_ConfigID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string strChkConfigID = string.Empty;
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
                //LoggedInUserID = "3";
            }
            if (!System.String.IsNullOrWhiteSpace(Request.QueryString["ChkConfigID"]))
            {
                strChkConfigID = Request.QueryString["ChkConfigID"].ToString();
                if (strChkConfigID.All(char.IsDigit))
                    Chk_ConfigID = Convert.ToInt32(strChkConfigID);
            }
            if (!IsPostBack)
            {
                Fetch_Chk_Answer();
                string Initiator = string.Empty;
                Initiator = Convert.ToString(Session["UserType"]);

                if (Chk_ConfigID != 0)
                    Bind_ChecklistConfiguration(Convert.ToInt32(Chk_ConfigID));
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        #region "Functions"
        public void Fetch_Chk_Answer()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = ObjUpkeep.Fetch_Chk_Answer();
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlAns.DataSource = ds.Tables[0];
                        ddlAns.DataTextField = "Ans_Type_Desc";
                        ddlAns.DataValueField = "Ans_Type_ID";
                        ddlAns.DataBind();

                        //for (int i = 0; i < ddlAns.Items.Count; i++)
                        //{
                        //    ddlAns.Items[i].Attributes["data-multi"] = ds.Tables[0].Rows[i]["Is_MultiValue"].ToString();
                        //    //ddlAns.Items[i].Attributes["data-content"] = "<i class='fa fa-" + ds.Tables[0].Rows[i]["Icon"] + "'  > " + ds.Tables[0].Rows[i]["Chk_Ans_Type_Desc"] + "</i>";
                        //}

                        for (int i = 0; i <= ddlAns.Items.Count - 1; i++)
                        {
                            ddlAns.Items[i].Attributes["data-isMulti"] = ds.Tables[0].Rows[i]["IS_MultiValue"].ToString();
                            ddlAns.Items[i].Attributes["data-isType"] = ds.Tables[0].Rows[i]["SDesc"].ToString();
                        }
                        // ddlAns.Items.Insert(0, new ListItem("select", ""));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Bind_ChecklistConfiguration(int CHK_ConfigID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = ObjUpkeep.Bind_ChecklistConfiguration(CHK_ConfigID);
                if (ds != null)
                {
                    btnSave.Text = "Update";
                    hdnCLConfigID.Value = CHK_ConfigID.ToString();

                    txtTitle.Text = Convert.ToString(ds.Tables[0].Rows[0]["Chk_Title"]); ;
                    txtCLDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["Chk_Desc"]); ;
                    txtTotScore.InnerText = Convert.ToString(ds.Tables[0].Rows[0]["Total Score"]);
                    hdnTotScore.Value = Convert.ToString(ds.Tables[0].Rows[0]["Total Score"]);

                    if (ds.Tables[0].Rows[0]["Is_Enable_Score"].ToString() == "1")
                        ChkScoring.Checked = true;
                    else
                        ChkScoring.Checked = false;

                    var SectionValues = ds.Tables[1].AsEnumerable().Select(s => s.Field<decimal>("Chk_Section_ID").ToString() + "||" + s.Field<string>("Chk_Section_Desc")).ToArray();
                    hdnCLGroups.Value = string.Join("~", SectionValues);

                    var HeaderValues = ds.Tables[2].AsEnumerable().Select(s =>
                                s.Field<decimal>("Chk_Section_ID").ToString() + "||" + s.Field<decimal>("CHK_Question_ID").ToString() + "||"
                                + s.Field<string>("Qn_Desc").ToString() + "||" + s.Field<bool>("Is_Qn_Mandatory").ToString() + "||"
                                + s.Field<bool>("Is_Attach_Mandatory").ToString() + "||" + s.Field<decimal>("Qn_Score").ToString() + "||"
                                + s.Field<string>("Chk_Qn_Ref_Desc").ToString() + "||" + s.Field<string>("Chk_Qn_Ref_Photo").ToString() + "||"
                                + s.Field<bool>("Is_Raise_Flag_Issue").ToString() + "||"
                                + s.Field<decimal>("Chk_Ans_Type_ID") + "||"
                                + string.Join(";", ds.Tables[3].AsEnumerable().Where(ans =>
                                ans.Field<decimal>("CHK_Question_ID").ToString() == s.Field<decimal>("CHK_Question_ID").ToString()).Select(ans =>
                                ans.Field<decimal>("Chk_Ans_Value_ID").ToString() + ":" + ans.Field<string>("Chk_Ans_Desc").ToString()
                                + ":" + ans.Field<bool>("Ans_Is_Flag").ToString() + ":" + ans.Field<bool>("Is_Default").ToString()))
                                //+ ":" + ans.Field<bool>("Is_Default").ToString() + ":" + ans.Field<bool>("Ans_Is_Flag").ToString()))
                                ).ToArray();

                    hdnCLQuestions.Value = string.Join("~", HeaderValues);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void SaveData()
        {
            try
            {
                string ChecklistQuestion = string.Empty, ChecklistQuestionID = string.Empty, ChkQuestionMandatory = string.Empty;
                string ChkQuestionAns = string.Empty, ChkQuestionAttachment = string.Empty, ChkQuestionRaisedFlag = string.Empty;
                //string ChkQuestionRefID = string.Empty;
                string ChkQuestionUploadImgID = string.Empty;
                string ChkQuestionImgID = string.Empty, ChkQuestionRefPath = string.Empty, ChkQuestionRefDesc = string.Empty, ChkQuestionRefPathUploaded = string.Empty;
                string ChkAnsData = string.Empty, ChkQuestionScore = string.Empty, ChecklistType = string.Empty;

                StringBuilder strXmlCHECKLIST_QUESTION = new StringBuilder();
                //strXmlCHECKLIST_QUESTION.Append(@"<?xml version=""1.0"" ?>");
                strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_QUESTION_ROOT>");

                int ccc = Request.Form.Count;
                for (int i = 0; i < ccc; i++)
                {
                    ChecklistQuestion = ""; ChkQuestionAns = ""; ChkQuestionMandatory = "0"; ChecklistType = "";
                    //ChkQuestionRefID = "";
                    ChkQuestionImgID = ""; ChkQuestionRefPath = ""; ChkQuestionRefDesc = ""; ChkQuestionRefPathUploaded = "";
                    ChkQuestionAttachment = "0"; ChkQuestionScore = "0"; ChkQuestionRaisedFlag = "";

                    string[] ChecklistGROUPArray = Request.Form.GetValues("CheckListGroup[" + i + "][ctl00$ContentPlaceHolder1$txtCheckListGroup]");

                    if (ChecklistGROUPArray != null)
                    {
                        int ln = 0;
                        if (String.IsNullOrEmpty(Request.Form.GetValues("CheckListGroup[" + i + "][ctl00$ContentPlaceHolder1$txtCount]")[0].ToString()))
                        {
                            ln = 0;
                        }
                        else
                        {
                            ln = Convert.ToInt32(Request.Form.GetValues("CheckListGroup[" + i + "][ctl00$ContentPlaceHolder1$txtCount]")[0].ToString());
                        }
                        //  ln = Convert.ToInt32(Request.Form.GetValues("CheckListGroup[" + i + "][ctl00$ContentPlaceHolder1$txtCount]")[0].ToString());
                        //string ln = Request.Form.GetValues("ChecklistGROUP["+i+"][ctl00$ContentPlaceHolder1$txtCount]")[0];
                        string ChkGROUPName = Request.Form.GetValues("CheckListGroup[" + i + "][ctl00$ContentPlaceHolder1$txtCheckListGroup]")[0];
                        string ChkGROUPID = Request.Form.GetValues("CheckListGroup[" + i + "][ctl00$ContentPlaceHolder1$hdnClGROUPID]")[0];
                        strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_GROUP>");
                        for (int h = 0; h <= ln; h++)
                        {
                            string[] ChecklistQuestionArray = Request.Form.GetValues("CheckListGroup[" + i + "][CheckListQuestion][" + h + "][ctl00$ContentPlaceHolder1$txtCheckListQuestion]");
                            string[] ChecklistQuestion_MandatoryArray = Request.Form.GetValues("CheckListGroup[" + i + "][CheckListQuestion][" + h + "][ctl00$ContentPlaceHolder1$ChkMandatory][]");
                            string[] ChecklistQuestion_AttachmentArray = Request.Form.GetValues("CheckListGroup[" + i + "][CheckListQuestion][" + h + "][ctl00$ContentPlaceHolder1$ChkAttach][]");
                            string[] ChecklistQuestion_RaisedFlagArray = Request.Form.GetValues("CheckListGroup[" + i + "][CheckListQuestion][" + h + "][ctl00$ContentPlaceHolder1$chkRaisedFlag][]");
                            string[] ChecklistQuestion_ScoreArray = Request.Form.GetValues("CheckListGroup[" + i + "][CheckListQuestion][" + h + "][ctl00$ContentPlaceHolder1$txtScore]");
                             

                            // string[] ChecklistQuestion_Ref_ID_Array = Request.Form.GetValues("ChecklistGroup[" + i + "][ChecklistQuestion][" + h + "][hdnRefID]");
                            ChkQuestionUploadImgID = "CheckListGroup[" + i + "][CheckListQuestion][" + h + "][hdnflRefImage]";
                            string[] ChecklistQuestion_ImgFileArray = Request.Form.GetValues("CheckListGroup[" + i + "][CheckListQuestion][" + h + "][hdnflRefImage]");
                            string[] ChecklistQuestion_Ref_Path_Array = Request.Form.GetValues("CheckListGroup[" + i + "][CheckListQuestion][" + h + "][hdnRefPath]");
                            string[] ChecklistQuestion_Ref_Desc_Array = Request.Form.GetValues("CheckListGroup[" + i + "][CheckListQuestion][" + h + "][hdnRefDesc]");

                            string[] ChecklistQuestion_Ref_PathUploaded_Array = Request.Form.GetValues("CheckListGroup[" + i + "][CheckListQuestion][" + h + "][hdnRefPathUploaded]");


                            string[] ChecklistQuestionIDArray = Request.Form.GetValues("CheckListGroup[" + i + "][CheckListQuestion][" + h + "][ctl00$ContentPlaceHolder1$hdnCheckListQuestion]");
                            string[] ChecklistQuestion_AnsArray = Request.Form.GetValues("CheckListGroup[" + i + "][CheckListQuestion][" + h + "][ctl00$ContentPlaceHolder1$ddlAns]");
                            string[] ChecklistQuestion_AnsData = Request.Form.GetValues("CheckListGroup[" + i + "][CheckListQuestion][" + h + "][hdnRepeaterAnswer]");

                            if (ChecklistQuestionIDArray != null)
                                ChecklistQuestionID = ChecklistQuestionIDArray[0];
                            if (ChecklistQuestionArray != null)
                                ChecklistQuestion = ChecklistQuestionArray[0];
                            if (ChecklistQuestion_AnsData != null)
                                ChkAnsData = ChecklistQuestion_AnsData[0];
                            if (ChecklistQuestion_AnsArray != null)
                                ChkQuestionAns = ChecklistQuestion_AnsArray[0];
                            if (ChecklistQuestion_MandatoryArray != null)
                                ChkQuestionMandatory = ChecklistQuestion_MandatoryArray[0];
                            if (ChecklistQuestion_AttachmentArray != null)
                                ChkQuestionAttachment = ChecklistQuestion_AttachmentArray[0];
                            if (ChecklistQuestion_RaisedFlagArray != null)
                                ChkQuestionRaisedFlag = ChecklistQuestion_RaisedFlagArray[0];
                            if (ChecklistQuestion_ScoreArray != null)
                                ChkQuestionScore = ChecklistQuestion_ScoreArray[0];

                            //if (ChecklistQuestion_Ref_ID_Array != null)
                            //ChkQuestionRefID = ChecklistQuestion_Ref_ID_Array[0];
                            if (ChecklistQuestion_ImgFileArray != null)
                                ChkQuestionImgID = ChecklistQuestion_ImgFileArray[0];
                            if (ChecklistQuestion_Ref_Path_Array != null)
                                ChkQuestionRefPath = ChecklistQuestion_Ref_Path_Array[0];
                            if (ChecklistQuestion_Ref_Desc_Array != null)
                                ChkQuestionRefDesc = ChecklistQuestion_Ref_Desc_Array[0];
                            if (ChecklistQuestion_Ref_PathUploaded_Array != null)
                                ChkQuestionRefPathUploaded = ChecklistQuestion_Ref_PathUploaded_Array[0];

                            if (ChecklistQuestionArray != null && ChecklistQuestion_AnsArray != null)
                            {
                                strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_QUESTION_DESC>");

                                strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_GROUP_NAME>" + ChkGROUPName + "</CHECKLIST_GROUP_NAME>");
                                strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_GROUP_ID>" + ChkGROUPID + "</CHECKLIST_GROUP_ID>");

                                strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_GROUP_SEQ>" + i + "</CHECKLIST_GROUP_SEQ>");
                                strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_QUESTION_SEQ>" + h + "</CHECKLIST_QUESTION_SEQ>");

                                strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_QUESTION_ID>" + ChecklistQuestionID + "</CHECKLIST_QUESTION_ID>");
                                strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_QUESTION>" + ChecklistQuestion + "</CHECKLIST_QUESTION>");
                                if (ChkQuestionMandatory.ToString() == "on")
                                {
                                    ChkQuestionMandatory = "1";
                                }
                                else
                                {
                                    ChkQuestionMandatory = "0";
                                }
                                strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_MANDATORY>" + ChkQuestionMandatory.ToString() + "</CHECKLIST_MANDATORY>");

                                if (ChkQuestionAttachment.ToString() == "on")
                                {
                                    ChkQuestionAttachment = "1";
                                }
                                else
                                {
                                    ChkQuestionAttachment = "0";
                                }
                                strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_ATTACHMENT>" + ChkQuestionAttachment.ToString() + "</CHECKLIST_ATTACHMENT>");

                                if (ChkQuestionRaisedFlag.ToString() == "on")
                                {
                                    ChkQuestionRaisedFlag = "1";
                                }
                                else
                                {
                                    ChkQuestionRaisedFlag = "0";
                                }
                                strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_RAISEDFLAG>" + ChkQuestionRaisedFlag.ToString() + "</CHECKLIST_RAISEDFLAG>");
                                strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_SCORE>" + ChkQuestionScore + "</CHECKLIST_SCORE>");

                                //strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_REF_ID>" + ChkQuestionRefID + "</CHECKLIST_REF_ID>");

                                strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_REF_DESC>" + ChkQuestionRefDesc.ToString() + "</CHECKLIST_REF_DESC>");

                                //hdnflRefImage get file control by id
                                string RefImgPath = UploadImage(ChkQuestionUploadImgID, ChkGROUPName, ChecklistQuestion);
                                // strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_REF_PATH>" + ChkQuestionRefPath.ToString() + "</CHECKLIST_REF_PATH>"); 

                                if (RefImgPath != "")
                                {
                                    strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_REF_PATH>" + RefImgPath.ToString() + "</CHECKLIST_REF_PATH>");
                                }
                                else if (ChkQuestionRefPathUploaded.ToString() != "" && Chk_ConfigID != 0)
                                {
                                    strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_REF_PATH>" + ChkQuestionRefPathUploaded.ToString() + "</CHECKLIST_REF_PATH>");
                                }
                                else
                                {
                                    strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_REF_PATH>" + "" + "</CHECKLIST_REF_PATH>");
                                }

                                strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_ANSWER>" + ChkQuestionAns + "</CHECKLIST_ANSWER>");

                                strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_QUESTION_ANSWER_VALUES>");
                                string[] strValueData = ChkAnsData.Split(';');

                                if (strValueData.Length == 1)
                                {
                                    strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_QUESTION_ANSWER_VALUES_DATA>");

                                    if (Chk_ConfigID != 0)
                                    {
                                        string[] strValue = ChkAnsData.Split(':');

                                        if (strValue.Length > 1)
                                        {
                                            strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_ANSWER_DATA_SEQ>1</CHECKLIST_ANSWER_DATA_SEQ>");
                                            strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_ANSWER_DATA_ID>" + strValue[0].ToString() + "</CHECKLIST_ANSWER_DATA_ID>");
                                            strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_ANSWER_DATA>" + strValue[1].ToString() + "</CHECKLIST_ANSWER_DATA>");
                                            strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_IS_DEFAULT></CHECKLIST_IS_DEFAULT>");
                                            strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_IS_FLAG></CHECKLIST_IS_FLAG>");
                                        }
                                        else
                                        {
                                            strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_ANSWER_DATA_SEQ>1</CHECKLIST_ANSWER_DATA_SEQ>");
                                            strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_ANSWER_DATA_ID></CHECKLIST_ANSWER_DATA_ID>");
                                            strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_ANSWER_DATA>" + strValue[0].ToString() + "</CHECKLIST_ANSWER_DATA>");
                                            strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_IS_DEFAULT></CHECKLIST_IS_DEFAULT>");
                                            strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_IS_FLAG></CHECKLIST_IS_FLAG>");
                                        }
                                    }
                                    else
                                    {
                                        strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_ANSWER_DATA_SEQ>1</CHECKLIST_ANSWER_DATA_SEQ>");
                                        strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_ANSWER_DATA_ID></CHECKLIST_ANSWER_DATA_ID>");
                                        strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_ANSWER_DATA>" + ChkAnsData + "</CHECKLIST_ANSWER_DATA>");
                                        strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_IS_DEFAULT></CHECKLIST_IS_DEFAULT>");
                                        strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_IS_FLAG></CHECKLIST_IS_FLAG>");
                                    }

                                    strXmlCHECKLIST_QUESTION.Append(@"</CHECKLIST_QUESTION_ANSWER_VALUES_DATA>");
                                }
                                else
                                {
                                    for (int f = 0; f <= strValueData.Length - 1; f++)
                                    {
                                        //string[] strValue = strValueData[f].Split(new[] { "::" }, StringSplitOptions.None);
                                        string[] strValue = strValueData[f].Split(':');

                                        //string isDefault = "0", iFlag = "0";
                                        //if (strValue[2].ToString() == "on") { isDefault = "1"; }
                                        //if (strValue[3].ToString() == "on") { iFlag = "1"; }

                                        strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_QUESTION_ANSWER_VALUES_DATA>");

                                        strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_ANSWER_DATA_SEQ>" + f + "</CHECKLIST_ANSWER_DATA_SEQ>");
                                        strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_ANSWER_DATA_ID>" + strValue[0].ToString() + "</CHECKLIST_ANSWER_DATA_ID>");
                                        strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_ANSWER_DATA>" + strValue[1].ToString() + "</CHECKLIST_ANSWER_DATA>");

                                        if (Chk_ConfigID != 0)
                                        {
                                            string isDefault = "0", iFlag = "0";
                                            if (strValue[2].ToString() == "True")
                                            {
                                                isDefault = "1";
                                            }
                                            else if (strValue[2].ToString() == "False")
                                            {
                                                isDefault = "0";
                                            }
                                            else
                                            {
                                                isDefault = strValue[2].ToString();
                                            }

                                            if (strValue[3].ToString() == "True")
                                            {
                                                iFlag = "1";
                                            }
                                            else if (strValue[3].ToString() == "False")
                                            {
                                                iFlag = "0";
                                            }
                                            else
                                            {
                                                iFlag = strValue[3].ToString();
                                            }

                                            strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_IS_DEFAULT>" + isDefault + "</CHECKLIST_IS_DEFAULT>");
                                            strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_IS_FLAG>" + iFlag + "</CHECKLIST_IS_FLAG>");
                                        }
                                        else
                                        {
                                            strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_IS_DEFAULT>" + strValue[2].ToString() + "</CHECKLIST_IS_DEFAULT>");
                                            strXmlCHECKLIST_QUESTION.Append(@"<CHECKLIST_IS_FLAG>" + strValue[3].ToString() + "</CHECKLIST_IS_FLAG>");
                                        }

                                        strXmlCHECKLIST_QUESTION.Append(@"</CHECKLIST_QUESTION_ANSWER_VALUES_DATA>");
                                    }
                                }
                                strXmlCHECKLIST_QUESTION.Append(@"</CHECKLIST_QUESTION_ANSWER_VALUES>");


                                strXmlCHECKLIST_QUESTION.Append(@"</CHECKLIST_QUESTION_DESC>");
                            }
                        }
                        strXmlCHECKLIST_QUESTION.Append(@"</CHECKLIST_GROUP>");
                    }
                }
                strXmlCHECKLIST_QUESTION.Append(@"</CHECKLIST_QUESTION_ROOT>");


                string strConfigTitle = string.Empty;
                string strConfigDesc = string.Empty;
                bool IsEnableScoring = false;
                int TotalScore = 0;
                strConfigTitle = txtTitle.Text.Trim();
                strConfigDesc = txtCLDesc.Text.Trim();
                 

                if (hdnTotScore.Value != "")
                {
                    if (Convert.ToInt32(hdnTotScore.Value) > 0)
                    {
                        IsEnableScoring = true;
                        TotalScore = Convert.ToInt32(hdnTotScore.Value);
                    }
                }


                string X = strXmlCHECKLIST_QUESTION.ToString().Replace("&", "&amp;");

                DataSet dsChecklistConfig = new DataSet();
                if (Chk_ConfigID != 0)
                    dsChecklistConfig = ObjUpkeep.Update_ChecklistConfiguration(Chk_ConfigID, strConfigTitle, strConfigDesc, IsEnableScoring, TotalScore,
                        strXmlCHECKLIST_QUESTION.ToString().Replace("&", "&amp;"), LoggedInUserID);
                else
                    dsChecklistConfig = ObjUpkeep.Insert_ChecklistConfiguration(strConfigTitle, strConfigDesc, IsEnableScoring, TotalScore,
                        strXmlCHECKLIST_QUESTION.ToString().Replace("&", "&amp;"), LoggedInUserID);

                if (dsChecklistConfig.Tables.Count > 0)
                {
                    if (dsChecklistConfig.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsChecklistConfig.Tables[0].Rows[0]["Status"]);
                        if (Status == 0)
                        {
                        }
                        else if (Status == 1)
                        {
                            Response.Redirect(Page.ResolveClientUrl("~/CheckList/ChkConfig_Listing.aspx"), false);
                        }
                        else if (Status == 3)
                        {
                            if (Chk_ConfigID == 0)
                                lblErrorMsg.Text = "Title already exists";
                            else
                                lblErrorMsg.Text = "Missing Config";
                        }
                        else if (Status == 4)
                        {
                            lblErrorMsg.Text = Convert.ToString(dsChecklistConfig.Tables[0].Rows[0]["ErrorMessage"]);
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
        public string UploadImage(string FileUploaderID, string SectionName, string QuestionName)
        {
            string FilePath = "";
            try
            {
                if (FileUploaderID != "")
                {
                    HttpPostedFile file = Request.Files[FileUploaderID];

                    string CurrentDate = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));
                    string fileUploadPath = HttpContext.Current.Server.MapPath("~/CheckListImages/" + CurrentDate);
                    if (!Directory.Exists(fileUploadPath))
                    {
                        Directory.CreateDirectory(fileUploadPath);
                    }


                    //check file was submitted
                    if (file != null && file.ContentLength > 0)
                    {
                        string filetypea = Path.GetExtension(file.FileName);

                        string ImageName = Path.GetFileName(file.FileName);
                        string fileName = SectionName.ToString().Replace(" ", "") + "_" + QuestionName.ToString().Replace(" ", "") + "_" + ImageName;
                        string imgPath = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadURL"]);
                        string SaveLocation = Server.MapPath("~/CheckListImages/" + CurrentDate) + "/" + fileName;
                        string FileLocation = imgPath + "/CheckListImages/" + CurrentDate + "/" + fileName;// + "*WP";
                        var targetFile = SaveLocation;
                        file.SaveAs(SaveLocation);

                        FilePath = FileLocation;
                    }
                }
                return FilePath;
            }
            catch (Exception)
            {
                //throw ex;
                return "";
            }
        }
        #endregion

    }
}