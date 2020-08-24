using System;
using System.Linq;
using System.Web.UI;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;


namespace Upkeep_v3.CSM
{
   
    public partial class CSM_Configuration : System.Web.UI.Page
    {
        #region Global Variables
        int CompanyID = 0;

        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int ConfigID = 0;

        DataSet dsConfig = new DataSet();
        #endregion

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            string strConfigID = string.Empty;
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            //frmGatePass.Action = @"GatePass_Configuration.aspx";
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                //Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
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

                if (!System.String.IsNullOrWhiteSpace(Request.QueryString["ConfigID"]))
                {
                    strConfigID = Request.QueryString["ConfigID"].ToString();
                    if (strConfigID.All(char.IsDigit))
                        ViewState["ConfigID"] = Convert.ToInt32(strConfigID);

                    btnSave.Text = "Update";
                    BindCSMConfig();
                }
                else if (!System.String.IsNullOrWhiteSpace(Request.QueryString["DelCSMConfigID"]))
                {
                    strConfigID = Request.QueryString["DelCSMConfigID"].ToString();
                    if (strConfigID.All(char.IsDigit))
                        ConfigID = Convert.ToInt32(strConfigID);

                    ObjUpkeep.Delete_VMSConfiguration(ConfigID, LoggedInUserID);
                }
                Fetch_User_UserGroupList();
                Fetch_Department();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string CSMQuestionID = string.Empty;
                string CSMQuestion = string.Empty;
                string CSMQuestionMandatory = string.Empty;
                string CSMQuestionVisible = string.Empty;
                string CSMQuestionAns = string.Empty;
                string CSMQuestionAnsData = string.Empty;

                //string CSMFeedback = string.Empty;
                //string CSMFeedbackMandatory = string.Empty;
                //string CSMFeedbackVisible = string.Empty;
                //string CSMFeedbackAns = string.Empty;
                //string CSMFeedbackAnsData = string.Empty;

                StringBuilder strXmlCSM_Question = new StringBuilder();
                strXmlCSM_Question.Append(@"<?xml version=""1.0"" ?>");
                strXmlCSM_Question.Append(@"<CSM_HEADER_ROOT>");

                StringBuilder strXmlCSM_Feedback = new StringBuilder();
                strXmlCSM_Feedback.Append(@"<?xml version=""1.0"" ?>");
                //strXmlCSM_Feedback.Append(@"<CSM_FEEDBACK_ROOT>");

                int Qln = 0;
                if (String.IsNullOrEmpty(txtInQuestion.Text)) { Qln = 0; }
                else { Qln = Convert.ToInt32(txtInQuestion.Text); }

                //int Fln = 0;
                //if (String.IsNullOrEmpty(txtFeedbackCount.Value)) { Fln = 0; }
                //else { Fln = Convert.ToInt32(txtFeedbackCount.Value); }

                for (int i = 0; i < Qln; i++)
                {
                    CSMQuestionID = "0";
                    CSMQuestion = "";
                    CSMQuestionVisible = "0";
                    CSMQuestionMandatory = "0";
                    CSMQuestionAns = "";
                    CSMQuestionAnsData = "";

                    CSMQuestionID = Request.Form.GetValues("CSMQuestion[" + i + "][ctl00$ContentPlaceHolder1$hdnQnID]")[0];
                    CSMQuestion = Request.Form.GetValues("CSMQuestion[" + i + "][ctl00$ContentPlaceHolder1$txtCSMQuestion]")[0];
                    CSMQuestionAns = Request.Form.GetValues("CSMQuestion[" + i + "][ctl00$ContentPlaceHolder1$ddlAns]")[0];
                    CSMQuestionAnsData = Request.Form.GetValues("CSMQuestion[" + i + "][hdnRepeaterAnswer]")[0];

                    if (Request.Form.AllKeys.Contains("CSMQuestion[" + i + "][ctl00$ContentPlaceHolder1$ChkVisible][]"))
                        CSMQuestionVisible = "1";
                    if (Request.Form.AllKeys.Contains("CSMQuestion[" + i + "][ctl00$ContentPlaceHolder1$ChkMandatory][]"))
                        CSMQuestionMandatory = "1";


                    strXmlCSM_Question.Append(@"<Question_Desc>");
                    strXmlCSM_Question.Append(@"<Question_Sequence>" + i + "</Question_Sequence>");
                    strXmlCSM_Question.Append(@"<Question_Id>" + CSMQuestionID.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Id>");
                    strXmlCSM_Question.Append(@"<Question_Header>" + CSMQuestion.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Header>");
                    strXmlCSM_Question.Append(@"<Question_Visible>" + CSMQuestionVisible.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Visible>");
                    strXmlCSM_Question.Append(@"<Question_Mandatory>" + CSMQuestionMandatory.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Mandatory>");
                    strXmlCSM_Question.Append(@"<Question_Ans>" + CSMQuestionAns.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Ans>");

                    strXmlCSM_Question.Append(@"<Question_Ans_Data_Root>");
                    string[] strValueData = CSMQuestionAnsData.Split(';');

                    if (strValueData.Length == 1)
                    {
                        strXmlCSM_Question.Append(@"<Question_Ans_Data>");

                        strXmlCSM_Question.Append(@"<Question_Ans_Sequence>0</Question_Ans_Sequence>");
                        strXmlCSM_Question.Append(@"<Question_Ans_Data_ID></Question_Ans_Data_ID>");
                        strXmlCSM_Question.Append(@"<Question_Ans_Data_Text></Question_Ans_Data_Text>");
                        strXmlCSM_Question.Append(@"<Question_Ans_Data_IsFlag></Question_Ans_Data_IsFlag>");

                        strXmlCSM_Question.Append(@"</Question_Ans_Data>");
                    }
                    else
                    {
                        for (int f = 0; f <= strValueData.Length - 1; f++)
                        {
                            //string[] strValue = strValueData[f].Split(new[] { "::" }, StringSplitOptions.None);
                            string[] strValue = strValueData[f].Split(':');

                            //string isFlag = "0";
                            //if (strValue[2].ToString() == "on") { isFlag = "1"; }

                            strXmlCSM_Question.Append(@"<Question_Ans_Data>");
                            strXmlCSM_Question.Append(@"<Question_Ans_Sequence>" + f + "</Question_Ans_Sequence>");

                            strXmlCSM_Question.Append(@"<Question_Ans_Data_ID>" + strValue[0].ToString().Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Ans_Data_ID>");
                            strXmlCSM_Question.Append(@"<Question_Ans_Data_Text>" + strValue[1].ToString().Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Ans_Data_Text>");
                            strXmlCSM_Question.Append(@"<Question_Ans_Data_IsFlag>" + strValue[2].ToString().Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Ans_Data_IsFlag>");

                            strXmlCSM_Question.Append(@"</Question_Ans_Data>");
                        }
                    }

                    strXmlCSM_Question.Append(@"</Question_Ans_Data_Root>");
                    strXmlCSM_Question.Append(@"</Question_Desc>");


                }

                strXmlCSM_Question.Append(@"</CSM_HEADER_ROOT>");
                //strXmlCSM_Feedback.Append(@"</CSM_FEEDBACK_ROOT>");

                int ConfigID = Convert.ToInt32(ViewState["ConfigID"]);
                string strConfigTitle = string.Empty;
                string strConfigDesc = string.Empty;
                int CompanyID = Convert.ToInt32(ViewState["CompanyID"]);
                string strInitiator = string.Empty;
                bool blFeedbackCompulsary = false;
                bool blEnableCovid = false;
                int FeedbackTitle = 0;
                int EntryCount = 0;

                strConfigTitle = txtTitle.Text.Trim();
                
                blFeedbackCompulsary = Convert.ToBoolean(ChkFreeService.Checked);

                DataSet dsCSMConfig = new DataSet();
                dsCSMConfig = ObjUpkeep.Insert_Update_VMSConfiguration(ConfigID, strConfigTitle, strConfigDesc, CompanyID, strInitiator, strXmlCSM_Question.ToString(), blFeedbackCompulsary, FeedbackTitle, blEnableCovid, EntryCount, LoggedInUserID);

                if (dsCSMConfig.Tables.Count > 0)
                {
                    if (dsCSMConfig.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsCSMConfig.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {

                            Response.Redirect(Page.ResolveClientUrl("~/CSM/CSMConfig_Listing.aspx"), false);
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

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fetch_User_UserGroupList();
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

        #endregion

        #region Functions
        public void Fetch_Answer()
        {
            DataSet ds = new DataSet();
            try
            {

                ds = ObjUpkeep.Fetch_AnswerForAll('S');



                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlInAns.DataSource = ds.Tables[0];
                        ddlInAns.DataTextField = "Ans_Type_Desc";
                        ddlInAns.DataValueField = "Ans_Type_ID";

                        ddlInAns.DataBind();

                        ddlOutAns.DataSource = ds.Tables[0];
                        ddlOutAns.DataTextField = "Ans_Type_Desc";
                        ddlOutAns.DataValueField = "Ans_Type_ID";

                        ddlOutAns.DataBind();

                        //ddlFAns.DataSource = ds.Tables[0];
                        //ddlFAns.DataTextField = "Ans_Type_Desc";
                        //ddlFAns.DataValueField = "Ans_Type_ID";

                        //ddlFAns.DataBind();

                        for (int i = 0; i < ddlInAns.Items.Count - 1; i++)
                        {
                            ddlInAns.Items[i].Attributes["data-isMulti"] = ds.Tables[0].Rows[i]["IS_MultiValue"].ToString();
                            ddlOutAns.Items[i].Attributes["data-isMulti"] = ds.Tables[0].Rows[i]["IS_MultiValue"].ToString();
                        }

                        //ddlAns.Items.Insert(0, new ListItem("Select", "NA"));
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

        private void BindCSMConfig()
        {
            try
            {
                //lblRequestDate.Text = DateTime.Now.ToString("dd/MMM/yyyy hh:mm tt");
                int ConfigTitleID = Convert.ToInt32(ViewState["ConfigID"]);
                dsConfig = ObjUpkeep.Bind_VMSConfiguration(ConfigTitleID);

                if (!System.String.IsNullOrWhiteSpace(dsConfig.Tables[0].Rows[0]["Config_Title"].ToString()))
                {
                    //divDesc.Visible = true;
                    hdnCSMConfigID.Value = ConfigTitleID.ToString();
                    txtTitle.Text = dsConfig.Tables[0].Rows[0]["Config_Title"].ToString();

                    //txtCSMDesc.Text = dsConfig.Tables[0].Rows[0]["Config_Desc"].ToString();
                    //txtCount.Text = dsConfig.Tables[0].Rows[0]["EntryCount"].ToString(); ;
                    //if (dsConfig.Tables[0].Rows[0]["Initiator"].ToString() == "C")
                    //{ rdbCustomer.Checked = true; }
                    //else if (dsConfig.Tables[0].Rows[0]["Initiator"].ToString() == "V")
                    //{ rdbVisitor.Checked = true; }
                    //ChkFeedback.Checked = Convert.ToBoolean(dsConfig.Tables[0].Rows[0]["Feedback_Is_Compulsory"]);
                    //ChkCovid.Checked = Convert.ToBoolean(dsConfig.Tables[0].Rows[0]["isCovidEnable"]);
                    //ddlFeedbackTitle.SelectedValue = dsConfig.Tables[0].Rows[0]["Feedback_ID"].ToString();

                    var QnValues = dsConfig.Tables[1].AsEnumerable().Select(s =>
                       s.Field<decimal>("CSM_Qn_Id").ToString() + "||" + s.Field<string>("Qn_Desc").ToString() + "||"
                       + s.Field<bool>("Is_Mandatory").ToString() + "||" + s.Field<bool>("Is_Visible").ToString() + "||"
                       + s.Field<decimal>("Ans_Type_ID") + "||" + string.Join(";", dsConfig.Tables[2].AsEnumerable().Where(ans =>
                       ans.Field<decimal>("CSM_Qn_Id").ToString() == s.Field<decimal>("CSM_Qn_Id").ToString()).Select(ans =>
                       ans.Field<decimal>("Ans_Type_Data_ID").ToString() + ":" + ans.Field<string>("Ans_Type_Data").ToString() + ":" +
                       ans.Field<bool>("Is_Flag").ToString()))).ToArray();

                    hdnCSMQns.Value = string.Join("~", QnValues);
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
                        grdGroupDesc.DataSource = ds.Tables[1];
                        grdGroupDesc.DataBind();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}