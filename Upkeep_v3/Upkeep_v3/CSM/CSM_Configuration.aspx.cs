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

                    DataSet ds = new DataSet();
                    ds = ObjUpkeep.Delete_CSMConfiguration(ConfigID, LoggedInUserID);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                            if (Status == 1)
                            {
                                Response.Redirect(Page.ResolveClientUrl("~/CSM/CSMConfig_Listing.aspx"), false);
                            }
                            else if (Status == 2)
                            {
                                divError.Visible = true;
                                lblErrorMsg.Text = "Active requests found can't delete you can edit instead.";
                                btnSave.Text = "Update";
                                BindCSMConfig();
                            }
                        }
                    }
                }
                Fetch_User_UserGroupList();
                Fetch_Department();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string CSMInQuestionID = string.Empty;
                string CSMInQuestion = string.Empty;
                string CSMInQuestionAns = string.Empty;
                string CSMInQuestionAnsData = string.Empty;

                string CSMOutQuestionID = string.Empty;
                string CSMOutQuestion = string.Empty;
                string CSMOutQuestionAns = string.Empty;
                string CSMOutQuestionAnsData = string.Empty;

                string CSMImageHeaderID = string.Empty;
                string CSMImageHeader = string.Empty;

                StringBuilder strXmlCSM_InQuestion = new StringBuilder();
                StringBuilder strXmlCSM_OutQuestion = new StringBuilder();
                StringBuilder strXmlCSM_Terms = new StringBuilder();
                //strXmlCSM_InQuestion.Append(@"<?xml version=""1.0"" ?>");
                strXmlCSM_InQuestion.Append(@"<CSM_IN_HEADER_ROOT>");
                strXmlCSM_OutQuestion.Append(@"<CSM_OUT_HEADER_ROOT>");
                strXmlCSM_Terms.Append(@"<CSM_TERMS_ROOT>");

                int InQln = 0;
                if (String.IsNullOrEmpty(txtInQuestionCount.Value)) { InQln = 0; }
                else { InQln = Convert.ToInt32(txtInQuestionCount.Value); }

                int OutQln = 0;
                if (String.IsNullOrEmpty(txtOutQuestionCount.Value)) { OutQln = 0; }
                else { OutQln = Convert.ToInt32(txtOutQuestionCount.Value); }

                int Termln = 0;
                if (String.IsNullOrEmpty(txtTermCount.Value)) { Termln = 0; }
                else { Termln = Convert.ToInt32(txtTermCount.Value); }

                //loop for In question
                for (int i = 0; i < InQln; i++)
                {
                    CSMInQuestionID = "0";
                    CSMInQuestion = "";
                    CSMInQuestionAns = "";
                    CSMInQuestionAnsData = "";

                    CSMInQuestionID = Request.Form.GetValues("InQuestion[" + i + "][ctl00$ContentPlaceHolder1$hdnInQnID]")[0];
                    CSMInQuestion = Request.Form.GetValues("InQuestion[" + i + "][ctl00$ContentPlaceHolder1$txtInQuestion]")[0];
                    CSMInQuestionAns = Request.Form.GetValues("InQuestion[" + i + "][ctl00$ContentPlaceHolder1$ddlInAns]")[0];
                    CSMInQuestionAnsData = Request.Form.GetValues("InQuestion[" + i + "][hdnInRepeaterAnswer]")[0];

                    strXmlCSM_InQuestion.Append(@"<Question_Desc>");
                    strXmlCSM_InQuestion.Append(@"<Question_Sequence>" + i + "</Question_Sequence>");
                    strXmlCSM_InQuestion.Append(@"<Question_Id>" + CSMInQuestionID.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Id>");
                    strXmlCSM_InQuestion.Append(@"<Question_Header>" + CSMInQuestion.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Header>");
                    strXmlCSM_InQuestion.Append(@"<Question_Ans>" + CSMInQuestionAns.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Ans>");

                    strXmlCSM_InQuestion.Append(@"<Question_Ans_Data_Root>");
                    string[] strValueData = CSMInQuestionAnsData.Split(';');

                    if (strValueData.Length == 1)
                    {
                        strXmlCSM_InQuestion.Append(@"<Question_Ans_Data>");

                        strXmlCSM_InQuestion.Append(@"<Question_Ans_Sequence>0</Question_Ans_Sequence>");
                        strXmlCSM_InQuestion.Append(@"<Question_Ans_Data_ID></Question_Ans_Data_ID>");
                        strXmlCSM_InQuestion.Append(@"<Question_Ans_Data_Text></Question_Ans_Data_Text>");
                        strXmlCSM_InQuestion.Append(@"<Question_Ans_Data_IsFlag></Question_Ans_Data_IsFlag>");

                        strXmlCSM_InQuestion.Append(@"</Question_Ans_Data>");
                    }
                    else
                    {
                        for (int f = 0; f <= strValueData.Length - 1; f++)
                        {
                            //string[] strValue = strValueData[f].Split(new[] { "::" }, StringSplitOptions.None);
                            string[] strValue = strValueData[f].Split(':');

                            //string isFlag = "0";
                            //if (strValue[2].ToString() == "on") { isFlag = "1"; }

                            strXmlCSM_InQuestion.Append(@"<Question_Ans_Data>");
                            strXmlCSM_InQuestion.Append(@"<Question_Ans_Sequence>" + f + "</Question_Ans_Sequence>");

                            strXmlCSM_InQuestion.Append(@"<Question_Ans_Data_ID>" + strValue[0].ToString().Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Ans_Data_ID>");
                            strXmlCSM_InQuestion.Append(@"<Question_Ans_Data_Text>" + strValue[1].ToString().Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Ans_Data_Text>");
                            strXmlCSM_InQuestion.Append(@"<Question_Ans_Data_IsFlag>" + strValue[2].ToString().Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Ans_Data_IsFlag>");

                            strXmlCSM_InQuestion.Append(@"</Question_Ans_Data>");
                        }
                    }

                    strXmlCSM_InQuestion.Append(@"</Question_Ans_Data_Root>");
                    strXmlCSM_InQuestion.Append(@"</Question_Desc>");


                }

                //loop for Out question
                for (int i = 0; i < OutQln; i++)
                {
                    CSMOutQuestionID = "0";
                    CSMOutQuestion = "";
                    CSMOutQuestionAns = "";
                    CSMOutQuestionAnsData = "";

                    CSMOutQuestionID = Request.Form.GetValues("OutQuestion[" + i + "][ctl00$ContentPlaceHolder1$hdnOutQnID]")[0];
                    CSMOutQuestion = Request.Form.GetValues("OutQuestion[" + i + "][ctl00$ContentPlaceHolder1$txtOutQuestion]")[0];
                    CSMOutQuestionAns = Request.Form.GetValues("OutQuestion[" + i + "][ctl00$ContentPlaceHolder1$ddlOutAns]")[0];
                    CSMOutQuestionAnsData = Request.Form.GetValues("OutQuestion[" + i + "][hdnOutRepeaterAnswer]")[0];

                    strXmlCSM_OutQuestion.Append(@"<Question_Desc>");
                    strXmlCSM_OutQuestion.Append(@"<Question_Sequence>" + i + "</Question_Sequence>");
                    strXmlCSM_OutQuestion.Append(@"<Question_Id>" + CSMOutQuestionID.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Id>");
                    strXmlCSM_OutQuestion.Append(@"<Question_Header>" + CSMOutQuestion.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Header>");
                    strXmlCSM_OutQuestion.Append(@"<Question_Ans>" + CSMOutQuestionAns.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Ans>");

                    strXmlCSM_OutQuestion.Append(@"<Question_Ans_Data_Root>");
                    string[] strValueData = CSMOutQuestionAnsData.Split(';');

                    if (strValueData.Length == 1)
                    {
                        strXmlCSM_OutQuestion.Append(@"<Question_Ans_Data>");

                        strXmlCSM_OutQuestion.Append(@"<Question_Ans_Sequence>0</Question_Ans_Sequence>");
                        strXmlCSM_OutQuestion.Append(@"<Question_Ans_Data_ID></Question_Ans_Data_ID>");
                        strXmlCSM_OutQuestion.Append(@"<Question_Ans_Data_Text></Question_Ans_Data_Text>");
                        strXmlCSM_OutQuestion.Append(@"<Question_Ans_Data_IsFlag></Question_Ans_Data_IsFlag>");

                        strXmlCSM_OutQuestion.Append(@"</Question_Ans_Data>");
                    }
                    else
                    {
                        for (int f = 0; f <= strValueData.Length - 1; f++)
                        {
                            //string[] strValue = strValueData[f].Split(new[] { "::" }, StringSplitOptions.None);
                            string[] strValue = strValueData[f].Split(':');

                            //string isFlag = "0";
                            //if (strValue[2].ToString() == "on") { isFlag = "1"; }

                            strXmlCSM_OutQuestion.Append(@"<Question_Ans_Data>");
                            strXmlCSM_OutQuestion.Append(@"<Question_Ans_Sequence>" + f + "</Question_Ans_Sequence>");

                            strXmlCSM_OutQuestion.Append(@"<Question_Ans_Data_ID>" + strValue[0].ToString().Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Ans_Data_ID>");
                            strXmlCSM_OutQuestion.Append(@"<Question_Ans_Data_Text>" + strValue[1].ToString().Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Ans_Data_Text>");
                            strXmlCSM_OutQuestion.Append(@"<Question_Ans_Data_IsFlag>" + strValue[2].ToString().Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</Question_Ans_Data_IsFlag>");

                            strXmlCSM_OutQuestion.Append(@"</Question_Ans_Data>");
                        }
                    }

                    strXmlCSM_OutQuestion.Append(@"</Question_Ans_Data_Root>");
                    strXmlCSM_OutQuestion.Append(@"</Question_Desc>");


                }

                //loop for Image Header
                for (int i = 0; i < Termln; i++)
                {
                    CSMImageHeaderID = "0";
                    CSMImageHeader = "";

                    CSMImageHeaderID = Request.Form.GetValues("TermCondition[" + i + "][hdnRepeaterTermID]")[0];
                    CSMImageHeader = Request.Form.GetValues("TermCondition[" + i + "][ctl00$ContentPlaceHolder1$txtTermCondition]")[0];

                    strXmlCSM_Terms.Append(@"<TERM_DETAIL>");
                    strXmlCSM_Terms.Append(@"<TERM_Sequence>" + i + "</TERM_Sequence>");
                    strXmlCSM_Terms.Append(@"<TERM_Id>" + CSMImageHeaderID.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</TERM_Id>");
                    strXmlCSM_Terms.Append(@"<TERM_DESC>" + CSMImageHeader.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</TERM_DESC>");
                    strXmlCSM_Terms.Append(@"</TERM_DETAIL>");

                }

                strXmlCSM_InQuestion.Append(@"</CSM_IN_HEADER_ROOT>");
                strXmlCSM_OutQuestion.Append(@"</CSM_OUT_HEADER_ROOT>");
                strXmlCSM_Terms.Append(@"</CSM_TERMS_ROOT>");
                //strXmlCSM_Feedback.Append(@"</CSM_FEEDBACK_ROOT>");

                int ConfigID = Convert.ToInt32(ViewState["ConfigID"]);
                string strConfigTitle = string.Empty;
                int CompanyID = Convert.ToInt32(ViewState["CompanyID"]);
                string strInitiator = string.Empty;
                bool blFreeService = false;
                int intCost = 0;
                string CostUnit = string.Empty;
                string strFlowUsers = string.Empty;
                string Description = txtDesc.Text;
                strFlowUsers = hdnSelectedUserID.Value;
                strConfigTitle = txtTitle.Text.Trim();

                if (txtCost.Text.All(char.IsDigit) && !string.IsNullOrEmpty(txtCost.Text))
                    intCost = Convert.ToInt32(txtCost.Text);

                CostUnit = intCost.ToString() + "/" + txtUnit.Text;

                blFreeService = !ChkFreeService.Checked;

                DataSet dsCSMConfig = new DataSet();
                dsCSMConfig = ObjUpkeep.Insert_Update_CSMConfiguration(ConfigID, strConfigTitle, CompanyID, Description, strXmlCSM_InQuestion.ToString(), strXmlCSM_OutQuestion.ToString(), strXmlCSM_Terms.ToString(), blFreeService, CostUnit, strFlowUsers, LoggedInUserID);

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
                dsConfig = ObjUpkeep.Bind_CSMConfiguration(ConfigTitleID);

                if (!System.String.IsNullOrWhiteSpace(dsConfig.Tables[0].Rows[0]["Config_Desc"].ToString()))
                {
                    //divDesc.Visible = true;
                    hdnCSMConfigID.Value = ConfigTitleID.ToString();
                    txtTitle.Text = dsConfig.Tables[0].Rows[0]["Config_Desc"].ToString();
                    txtDesc.Text = dsConfig.Tables[0].Rows[0]["Config_Detailed_Desc"].ToString();
                    ChkFreeService.Checked = !Convert.ToBoolean(dsConfig.Tables[0].Rows[0]["Is_Cost_Enable"]);
                    hdnUsersID.Value = dsConfig.Tables[0].Rows[0]["Request_Flow_ID"].ToString();
                    hdnSelectedUserID.Value = dsConfig.Tables[0].Rows[0]["Request_Flow_ID"].ToString();
                    string UnitCost = dsConfig.Tables[0].Rows[0]["Cost"].ToString();
                    if(UnitCost.Contains("/"))
                    {
                        txtCost.Text = UnitCost.Split('/')[0] == null ? "0" : UnitCost.Split('/')[0];
                        txtUnit.Text = UnitCost.Split('/')[1] == null ? "" : UnitCost.Split('/')[1];
                    }

                    var InQnValues = dsConfig.Tables[1].AsEnumerable().Select(s =>
                       s.Field<int>("Open_Qn_ID").ToString() + "||" + s.Field<string>("Desc").ToString() + "||"
                       + s.Field<int>("Ans_Type_ID") + "||" + string.Join(";", dsConfig.Tables[2].AsEnumerable().Where(ans =>
                       ans.Field<int>("Open_Qn_ID").ToString() == s.Field<int>("Open_Qn_ID").ToString()).Select(ans =>
                       ans.Field<decimal>("Ans_Type_Data_ID").ToString() + ":" + ans.Field<string>("Ans_Type_Data").ToString() + ":" +
                       ans.Field<bool>("Is_Flag").ToString()))).ToArray();

                    hdnInQns.Value = string.Join("~", InQnValues);

                    var OutQnValues = dsConfig.Tables[3].AsEnumerable().Select(s =>
                       s.Field<int>("Close_Qn_ID").ToString() + "||" + s.Field<string>("Desc").ToString() + "||"
                       + s.Field<int>("Ans_Type_ID") + "||" + string.Join(";", dsConfig.Tables[4].AsEnumerable().Where(ans =>
                       ans.Field<int>("Close_Qn_ID").ToString() == s.Field<int>("Close_Qn_ID").ToString()).Select(ans =>
                       ans.Field<decimal>("Ans_Type_Data_ID").ToString() + ":" + ans.Field<string>("Ans_Type_Data").ToString() + ":" +
                       ans.Field<bool>("Is_Flag").ToString()))).ToArray();

                    hdnOutQns.Value = string.Join("~", OutQnValues);

                    var TermsValues = dsConfig.Tables[5].AsEnumerable().Select(s => s.Field<int>("Terms_ID").ToString() + "||" + s.Field<string>("Term_Desc").Replace("<br>", System.Environment.NewLine)).ToArray(); //Added by RC 

                    hdnTerms.Value = string.Join("~", TermsValues);
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