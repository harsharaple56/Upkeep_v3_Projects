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

namespace Upkeep_v3.WorkPermit
{
    public partial class WorkPermit_Configuration : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int WP_ConfigID = 0;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string strWPConfigID = string.Empty;
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            
            //frmWorkPermit.Action = @"WorkPermit_Configuration.aspx";
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }

            if (!IsPostBack)
            {
                ViewState["ConfigID"] = "0";
                Fetch_Answer();
                string Initiator = string.Empty;
                if (rdbEmployee.Checked == true)
                {
                    Initiator = "E";
                }
                else if (rdbRetailer.Checked == true)
                {
                    Initiator = "R";
                }
                if (!System.String.IsNullOrWhiteSpace(Request.QueryString["WPConfigID"]))
                {
                    strWPConfigID = Request.QueryString["WPConfigID"].ToString();
                    if (strWPConfigID.All(char.IsDigit))
                        ViewState["ConfigID"] = Convert.ToInt32(strWPConfigID);
                    if (ViewState["ConfigID"].ToString() != "0")
                        Bind_WorkPermitConfiguration();
                }
                else if (!System.String.IsNullOrWhiteSpace(Request.QueryString["DelWPConfigID"]))
                {
                    strWPConfigID = Request.QueryString["DelWPConfigID"].ToString();
                    if (strWPConfigID.All(char.IsDigit))
                        WP_ConfigID = Convert.ToInt32(strWPConfigID);
                    if (WP_ConfigID != 0)
                        ObjUpkeep.Delete_WPConfiguration(WP_ConfigID, LoggedInUserID);
                }

                Fetch_User_UserGroupList(Initiator);
            }
        }


        public void Bind_WorkPermitConfiguration()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = ObjUpkeep.Bind_WorkPermitConfiguration(Convert.ToInt32(ViewState["ConfigID"]));
                if (ds != null)
                {
                    btnSave.Text = "Update";
                    hdnWPConfigID.Value = ViewState["ConfigID"].ToString();
                    txtTitle.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Title"]);
                    string Initiator = Convert.ToString(ds.Tables[0].Rows[0]["Initiator"]);
                    if (Initiator == "E")
                        rdbEmployee.Checked = true;
                    else
                        rdbRetailer.Checked = true;

                    rdbEmployee.Enabled = false;
                    rdbRetailer.Enabled = false;

                    ChkLinkDept.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["Link_Dept"]);


                    txtWPPrefix.Text = Convert.ToString(ds.Tables[0].Rows[0]["Transaction_Prefix"]);
                    txtNoOfLevel.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoOfLevel"]);

                    AddRows(Convert.ToInt32(ds.Tables[0].Rows[0]["NoOfLevel"]), ds);


                    var SectionValues = ds.Tables[1].AsEnumerable().Select(s => s.Field<decimal>("WP_Section_ID").ToString() + "||" + s.Field<string>("WP_Section_Desc")).ToArray();

                    hdnWPSections.Value = string.Join("~", SectionValues);

                    var HeaderValues = ds.Tables[2].AsEnumerable().Select(s =>
                    s.Field<decimal>("WP_Section_ID").ToString() + "||" + s.Field<decimal>("WP_Header_ID").ToString() + "||"
                    + s.Field<string>("Header_Name").ToString() + "||" + s.Field<string>("Is_Mandatory").ToString() + "||"
                    + s.Field<decimal>("Ans_Type_ID") + "||"
                    + string.Join(";", ds.Tables[6].AsEnumerable().Where(ans =>
                    ans.Field<decimal>("WP_Header_ID").ToString() == s.Field<decimal>("WP_Header_ID").ToString()).Select(ans =>
                    ans.Field<decimal>("Ans_Type_Data_ID").ToString() + "::" + ans.Field<string>("Ans_Type_Data").ToString()))).ToArray();

                    hdnWPHeaders.Value = string.Join("~", HeaderValues);

                    var TermsValues = ds.Tables[3].AsEnumerable().Select(s => s.Field<decimal>("WP_Terms_ID").ToString() + "||" + s.Field<string>("Terms_Desc").Replace("<br>", System.Environment.NewLine)).ToArray(); //Added by RC 

                    hdnWPTerms.Value = string.Join("~", TermsValues);

                    chkShowApprovalMatrix_Initiator.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ShowApprovalMatrix_Initiators"]);
                    chkShowApprovalMatrix_Approver.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["ShowApprovalMatrix_Approvers"]);

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                string WorkPermitHeader = string.Empty;
                string WorkPermitHeaderID = string.Empty;
                string WPHeaderMandatory = string.Empty;
                string WPHeaderAns = string.Empty;
                string WPAnsData = string.Empty;

                string WorkPermitType = string.Empty;
                string WorkPermitTermCondition = string.Empty;

                StringBuilder strXmlWorkPermit_Header = new StringBuilder();
                //strXmlWorkPermit_Header.Append(@"<?xml version=""1.0"" ?>");
                strXmlWorkPermit_Header.Append(@"<WORKPERMIT_HEADER_ROOT>");

                StringBuilder strXmlWorkPermit_Type = new StringBuilder();
                strXmlWorkPermit_Type.Append(@"<?xml version=""1.0"" ?>");
                strXmlWorkPermit_Type.Append(@"<WORKPERMIT_TYPE_ROOT>");

                StringBuilder strXmlWorkPermit_TermCondition = new StringBuilder();
                strXmlWorkPermit_TermCondition.Append(@"<?xml version=""1.0"" ?>");
                strXmlWorkPermit_TermCondition.Append(@"<WORKPERMIT_TERM_ROOT>");

                int ccc = Request.Form.Count;
                for (int i = 0; i < ccc; i++)
                {
                    WorkPermitHeader = "";
                    WPHeaderAns = "";
                    WPHeaderMandatory = "0";
                    WorkPermitType = "";
                    WorkPermitTermCondition = "";

                    string[] WorkPermitSectionArray = Request.Form.GetValues("WorkPermitSection[" + i + "][ctl00$ContentPlaceHolder1$txtWorkPermitSection]");



                    foreach (string key in Request.Form.AllKeys)
                    {
                        if (key == "WorkPermitHeader[" + i + "][ctl00$ContentPlaceHolder1$ChkMandatory][]")
                        {
                            WPHeaderMandatory = "1";
                        }
                    }

                    //string[] WorkPermitType_Array = Request.Form.GetValues("WorkPermitType[" + i + "][ctl00$ContentPlaceHolder1$txtWorkPermitType]");
                    //if (WorkPermitType_Array != null)
                    //{
                    //	WorkPermitType = WorkPermitType_Array[0];
                    //}

                    string[] WorkPermitTermCondition_Array = Request.Form.GetValues("WorkPermitTermCondition[" + i + "][ctl00$ContentPlaceHolder1$txtTermComdition]");
                    if (WorkPermitTermCondition_Array != null)
                    {
                        WorkPermitTermCondition = WorkPermitTermCondition_Array[0];
                    }
                    if (WorkPermitSectionArray != null)
                    {
                        int ln = Convert.ToInt32(Request.Form.GetValues("WorkPermitSection[" + i + "][ctl00$ContentPlaceHolder1$txtCount]")[0]);
                        //string ln = Request.Form.GetValues("WorkPermitSection["+i+"][ctl00$ContentPlaceHolder1$txtCount]")[0];
                        string WPSectionName = Request.Form.GetValues("WorkPermitSection[" + i + "][ctl00$ContentPlaceHolder1$txtWorkPermitSection]")[0];
                        string WPSectionID = Request.Form.GetValues("WorkPermitSection[" + i + "][ctl00$ContentPlaceHolder1$hdnWPSectionID]")[0];
                        strXmlWorkPermit_Header.Append(@"<WORKPERMIT_SECTION>");
                        //strXmlWorkPermit_Header.Append(@"<WORKPERMIT_SECTION_NAME>" + WPSectionName + "</WORKPERMIT_SECTION_NAME>");
                        for (int h = 0; h <= ln; h++)
                        {
                            string[] WorkPermitHeaderArray = Request.Form.GetValues("WorkPermitSection[" + i + "][WorkPermitHeader][" + h + "][ctl00$ContentPlaceHolder1$txtWorkPermitHeader]");

                            string[] WorkPermitHeader_MandatoryArray = Request.Form.GetValues("WorkPermitHeader[" + i + "][ctl00$ContentPlaceHolder1$ChkMandatory]");

                            string[] WorkPermitHeaderIDArray = Request.Form.GetValues("WorkPermitSection[" + i + "][WorkPermitHeader][" + h + "][ctl00$ContentPlaceHolder1$hdnWorkPermitHeader]");

                            string[] WorkPermitHeader_AnsArray = Request.Form.GetValues("WorkPermitSection[" + i + "][WorkPermitHeader][" + h + "][ctl00$ContentPlaceHolder1$ddlAns]");

                            //string[] WorkPermitHeader_AnsDataID = Request.Form.GetValues("WorkPermitSection[" + i + "][WorkPermitHeader][" + h + "][hdnRepeaterAnswer]");
                            string[] WorkPermitHeader_AnsData = Request.Form.GetValues("WorkPermitSection[" + i + "][WorkPermitHeader][" + h + "][hdnRepeaterAnswer]");

                            if (WorkPermitHeaderIDArray != null)
                            {
                                WorkPermitHeaderID = WorkPermitHeaderIDArray[0];
                            }
                            if (WorkPermitHeaderArray != null)
                            {
                                WorkPermitHeader = WorkPermitHeaderArray[0];
                            }
                            if (WorkPermitHeader_AnsData != null)
                            {
                                WPAnsData = WorkPermitHeader_AnsData[0];
                            }
                            if (WorkPermitHeader_AnsArray != null)
                            {
                                WPHeaderAns = WorkPermitHeader_AnsArray[0];
                            }

                            if (WorkPermitHeaderArray != null && WorkPermitHeader_AnsArray != null)
                            {
                                //Replacing special characters with Escape in XML
                                strXmlWorkPermit_Header.Append(@"<WORKPERMIT_HEADER_DESC>");
                                strXmlWorkPermit_Header.Append(@"<WORKPERMIT_SECTION_NAME>" + WPSectionName.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</WORKPERMIT_SECTION_NAME>");
                                strXmlWorkPermit_Header.Append(@"<WORKPERMIT_SECTION_ID>" + WPSectionID.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</WORKPERMIT_SECTION_ID>");
                                strXmlWorkPermit_Header.Append(@"<WORKPERMIT_HEADER_ID>" + WorkPermitHeaderID.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</WORKPERMIT_HEADER_ID>");
                                strXmlWorkPermit_Header.Append(@"<WORKPERMIT_HEADER>" + WorkPermitHeader.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</WORKPERMIT_HEADER>");
                                strXmlWorkPermit_Header.Append(@"<WORKPERMIT_MANDATORY>" + WPHeaderMandatory.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</WORKPERMIT_MANDATORY>");
                                strXmlWorkPermit_Header.Append(@"<WORKPERMIT_ANSWER>" + WPHeaderAns.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</WORKPERMIT_ANSWER>");
                                strXmlWorkPermit_Header.Append(@"<WORKPERMIT_ANSWER_DATA>" + WPAnsData.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</WORKPERMIT_ANSWER_DATA>");
                                strXmlWorkPermit_Header.Append(@"</WORKPERMIT_HEADER_DESC>");
                            }

                        }

                        strXmlWorkPermit_Header.Append(@"</WORKPERMIT_SECTION>");
                    }

                    //if (WorkPermitType_Array != null)
                    //{
                    //	strXmlWorkPermit_Type.Append(@"<WORKPERMIT_TYPE_DESC>");
                    //	strXmlWorkPermit_Type.Append(@"<WORKPERMIT_TYPE>" + WorkPermitType + "</WORKPERMIT_TYPE>");
                    //	strXmlWorkPermit_Type.Append(@"</WORKPERMIT_TYPE_DESC>");
                    //}

                    if (WorkPermitTermCondition_Array != null)
                    {
                        strXmlWorkPermit_TermCondition.Append(@"<WORKPERMIT_TERM_DESC>");
                        strXmlWorkPermit_TermCondition.Append(@"<WORKPERMIT_TERM>" + WorkPermitTermCondition.Replace(System.Environment.NewLine, "<br>").Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;") + "</WORKPERMIT_TERM>");
                        strXmlWorkPermit_TermCondition.Append(@"</WORKPERMIT_TERM_DESC>");
                    }

                }

                strXmlWorkPermit_Header.Append(@"</WORKPERMIT_HEADER_ROOT>");
                strXmlWorkPermit_Type.Append(@"</WORKPERMIT_TYPE_ROOT>");
                strXmlWorkPermit_TermCondition.Append(@"</WORKPERMIT_TERM_ROOT>");


                string hdnApprovalMatrix = txtHdn.Text;

                string[] strArrayApprovalMatrix = hdnApprovalMatrix.Split(',');


                XmlDocument xmlDocProm = null;
                xmlDocProm = new XmlDocument();
                int ApprovalLevel = 0;
                ApprovalLevel = strArrayApprovalMatrix.Length - 1;

                StringBuilder strXmlApprovalMatrix = new StringBuilder();
                strXmlApprovalMatrix.Append(@"<?xml version=""1.0"" ?>");
                strXmlApprovalMatrix.Append(@"<APPROVAL_MATRIX_ROOT>");

                for (int intLocRowCtr = 0; intLocRowCtr <= ApprovalLevel; intLocRowCtr++)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(strArrayApprovalMatrix[intLocRowCtr])))
                    {
                        string[] LocArr = strArrayApprovalMatrix[intLocRowCtr].Split('#');

                        strXmlApprovalMatrix.Append(@"<APPROVAL_MATRIX_DETAILS>");

                        strXmlApprovalMatrix.Append(@"<level>" + LocArr[0] + "</level>");
                        strXmlApprovalMatrix.Append(@"<Userid>" + LocArr[1] + "</Userid>");
                        strXmlApprovalMatrix.Append(@"<UserGroupid>" + LocArr[2] + "</UserGroupid>");
                        strXmlApprovalMatrix.Append(@"<SendEmail>" + LocArr[3] + "</SendEmail>");
                        strXmlApprovalMatrix.Append(@"<SendSMS>" + LocArr[4] + "</SendSMS>");
                        strXmlApprovalMatrix.Append(@"<SendNotification>" + LocArr[5] + "</SendNotification>");
                        strXmlApprovalMatrix.Append(@"<MobileAccess>" + LocArr[6] + "</MobileAccess>");
                        strXmlApprovalMatrix.Append(@"<WebAccess>" + LocArr[7] + "</WebAccess>");
                        strXmlApprovalMatrix.Append(@"<ApprovalRights>" + LocArr[8] + "</ApprovalRights>");
                        strXmlApprovalMatrix.Append(@"<HoldRights>" + LocArr[9] + "</HoldRights>");
                        strXmlApprovalMatrix.Append(@"<RejectRights>" + LocArr[10] + "</RejectRights>");
                        strXmlApprovalMatrix.Append(@"<nextactionlevel>" + LocArr[11] + "</nextactionlevel>");

                        strXmlApprovalMatrix.Append(@"</APPROVAL_MATRIX_DETAILS>");
                    }
                }
                strXmlApprovalMatrix.Append(@"</APPROVAL_MATRIX_ROOT>");

                string strConfigTitle = string.Empty;
                int CompanyID = 0;
                string strInitiator = string.Empty;
                bool LinkDepartment = false;
                string strTransactionPrefix = string.Empty;

                bool ShowApprovalMatrix_Initiator = false;
                bool ShowApprovalMatrix_Approver = false;

                ShowApprovalMatrix_Initiator = chkShowApprovalMatrix_Initiator.Checked;
                ShowApprovalMatrix_Approver = chkShowApprovalMatrix_Approver.Checked;

                strConfigTitle = txtTitle.Text.Trim();
                //CompanyID = Convert.ToInt32(ddlCompany.SelectedValue);
                LinkDepartment = Convert.ToBoolean(ChkLinkDept.Checked);
                //ShowApprovalMatrix = Convert.ToBoolean(chkShowApprovalMatrix.Checked);

                if (rdbEmployee.Checked == true)
                {
                    strInitiator = "E";
                }
                else if (rdbRetailer.Checked == true)
                {
                    strInitiator = "R";
                }

                strTransactionPrefix = Convert.ToString(txtWPPrefix.Text.Trim());

                DataSet dsWorkPermitConfig = new DataSet();

                //Replacing special characters with Escape in XML
                //strXmlWorkPermit_Header.Replace("&", "&amp;");
                //strXmlWorkPermit_Header.Replace("<", "&lt;");
                //strXmlWorkPermit_Header.Replace(">", "&gt;");
                //strXmlWorkPermit_Header.Replace("\"", "&quot;");
                //strXmlWorkPermit_Header.Replace("'", "&apos;");

                //strXmlWorkPermit_TermCondition.Replace("&", "&amp;");
                //strXmlWorkPermit_TermCondition.Replace("<", "&lt;");
                //strXmlWorkPermit_TermCondition.Replace(">", "&gt;");
                //strXmlWorkPermit_TermCondition.Replace("\"", "&quot;");
                //strXmlWorkPermit_TermCondition.Replace("'", "&apos;");

                //strXmlApprovalMatrix.Replace("&", "&amp;");
                //strXmlApprovalMatrix.Replace("<", "&lt;");
                //strXmlApprovalMatrix.Replace(">", "&gt;");
                //strXmlApprovalMatrix.Replace("\"", "&quot;");
                //strXmlApprovalMatrix.Replace("'", "&apos;");


                CompanyID = Convert.ToInt32(Session["CompanyID"].ToString());

                if (ViewState["ConfigID"].ToString() != "0")
                    dsWorkPermitConfig = ObjUpkeep.Update_WorkPermitConfiguration(Convert.ToInt32(ViewState["ConfigID"]), strConfigTitle, CompanyID, strInitiator, LinkDepartment, strTransactionPrefix, strXmlWorkPermit_Header.ToString(), strXmlWorkPermit_TermCondition.ToString(), strXmlApprovalMatrix.ToString(), ShowApprovalMatrix_Initiator, ShowApprovalMatrix_Approver, LoggedInUserID);
                else
                    dsWorkPermitConfig = ObjUpkeep.Insert_WorkPermitConfiguration(strConfigTitle, CompanyID, strInitiator, LinkDepartment, strTransactionPrefix, strXmlWorkPermit_Header.ToString(), strXmlWorkPermit_TermCondition.ToString(), strXmlApprovalMatrix.ToString(), ShowApprovalMatrix_Initiator, ShowApprovalMatrix_Approver, LoggedInUserID);

                if (dsWorkPermitConfig.Tables.Count > 0)
                {
                    if (dsWorkPermitConfig.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsWorkPermitConfig.Tables[0].Rows[0]["Status"]);
                        if (Status == 0)
                        {

                        }
                        else if (Status == 1)
                        {

                            Response.Redirect(Page.ResolveClientUrl("~/WorkPermit/WPConfig_Listing.aspx"), false);
                        }
                        else if (Status == 3)
                        {
                            divError.Visible = true;
                            lblErrorMsg.Text = "Title already exists";
                        }
                        else if (Status == 2)
                        {
                            divError.Visible = true;
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

        protected void rdbInitiator_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnMakeCombination_Click(object sender, EventArgs e)
        {
            int NoOfLevels = Convert.ToInt32(txtNoOfLevel.Text);
            AddRows(NoOfLevels, null);

        }


        #region Function


        private void AddRows(int NoOfLevels, DataSet dsApprovalMatrix)
        {
            int ctr = NoOfLevels;
            DataTable ObjDt = null;

            if (dsApprovalMatrix != null)
            {
                if (System.String.IsNullOrWhiteSpace(Request.QueryString["WPConfigID"]))
                    ObjDt = dsApprovalMatrix.Tables[1];
                else
                    ObjDt = dsApprovalMatrix.Tables[4];
            }
            TblLevels.Visible = true;
            //TblSave.Visible = true;
            if (dsApprovalMatrix == null)
            {
                try
                {
                    int IntPriCounter;
                    for (IntPriCounter = 0; IntPriCounter <= ctr - 1; IntPriCounter++)
                    {
                        this.TblLevels.Rows.Add(new HtmlTableRow());
                        this.TblLevels.Rows[IntPriCounter + 1].ID = System.Convert.ToString(this.TblLevels.ID) + System.Convert.ToString(this.TblLevels.Rows.Count - 1);

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[0].InnerHtml = (IntPriCounter + 1).ToString();
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[0].Attributes.Add("class", "GridItem");

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[1].Attributes.Add("class", "form-control m-input");

                        this.TblLevels.Rows[IntPriCounter + 1].Cells[1].Attributes.Add("style", "width:25%");

                        System.Web.UI.WebControls.TextBox LocTxtActionGroup = new System.Web.UI.WebControls.TextBox();
                        System.Web.UI.HtmlControls.HtmlImage LocImgBtnHelp = new System.Web.UI.HtmlControls.HtmlImage();

                        System.Web.UI.WebControls.HiddenField LocHdnAction = new System.Web.UI.WebControls.HiddenField();
                        // LocHdnAction.Style.Add("display", "none")
                        LocHdnAction.ID = "hdn2" + IntPriCounter;
                        LocTxtActionGroup.Width = 176;
                        LocTxtActionGroup.Attributes.Add("class", "form-control m-input");
                        LocTxtActionGroup.Attributes.Add("style", "display: inline");
                        LocTxtActionGroup.ReadOnly = true;
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[1].Controls.Add(LocTxtActionGroup);


                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[2].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox LocChkBoxEmail = new System.Web.UI.WebControls.CheckBox();
                        LocChkBoxEmail.Checked = false;

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[3].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox LocChkBoxTxt = new System.Web.UI.WebControls.CheckBox();
                        LocChkBoxTxt.Checked = false;

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[4].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox ChkBoxNotification = new System.Web.UI.WebControls.CheckBox();
                        ChkBoxNotification.Checked = false;


                        // ---------------ADD HELP BUTTON---------------------
                        //LocImgBtnHelp.Src = "../generalimages/mypc_search.png";
                        LocImgBtnHelp.Src = Page.ResolveClientUrl("~/assets/app/media/img/icons/AddUser.png");
                        LocImgBtnHelp.Attributes.Add("width", "32");
                        LocImgBtnHelp.Attributes.Add("height", "32");
                        //LocImgBtnHelp.Style.Add("vertical-align", "bottom");
                        LocImgBtnHelp.Attributes.Add("onclick", "PopUpGrid(" + LocTxtActionGroup.ClientID + ",'" + LocHdnAction.ClientID + "');");
                        // ---------------------------------------------------------
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[1].Controls.Add(LocImgBtnHelp);
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[1].Controls.Add(LocHdnAction);


                        this.TblLevels.Rows[IntPriCounter + 1].Cells[2].Controls.Add(LocChkBoxEmail);
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[3].Controls.Add(LocChkBoxTxt);
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[4].Controls.Add(ChkBoxNotification);

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[1].Attributes.Add("class", "GridItem");

                        //System.Web.UI.WebControls.TextBox LocTxtTime = new System.Web.UI.WebControls.TextBox();
                        //LocTxtTime.Width = 30;
                        //LocTxtTime.Attributes.Add("data-rule-number", "true");
                        //this.TblLevels.Rows[IntPriCounter + 1].Cells[5].Controls.Add(LocTxtTime);

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[5].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox ChkMobile = new System.Web.UI.WebControls.CheckBox();
                        ChkMobile.Checked = false;
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[5].Controls.Add(ChkMobile);

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[6].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox ChkWeb = new System.Web.UI.WebControls.CheckBox();
                        ChkWeb.Checked = false;
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[6].Controls.Add(ChkWeb);

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[7].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox ChkApprove = new System.Web.UI.WebControls.CheckBox();
                        ChkApprove.Checked = false;
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[7].Controls.Add(ChkApprove);

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[8].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox ChkHold = new System.Web.UI.WebControls.CheckBox();
                        ChkHold.Checked = false;
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[8].Controls.Add(ChkHold);

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[9].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox ChkReject = new System.Web.UI.WebControls.CheckBox();
                        ChkReject.Checked = false;
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[9].Controls.Add(ChkReject);

                        //this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        if (IntPriCounter == ctr - 1)
                        {
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[10].InnerHtml = "0";
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[10].Attributes.Add("class", "GridItem");
                        }
                        else
                        {
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[10].InnerHtml = (IntPriCounter + 2).ToString();
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[10].Attributes.Add("class", "GridItem");
                        }

                        //this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        System.Web.UI.WebControls.TextBox LocTxtInf = new System.Web.UI.WebControls.TextBox();
                        System.Web.UI.HtmlControls.HtmlImage LocImgBtnHelp1 = new System.Web.UI.HtmlControls.HtmlImage();

                        System.Web.UI.WebControls.HiddenField LocHdnInf = new System.Web.UI.WebControls.HiddenField();
                        // LocHdnInf.Style.Add("display", "none")
                        LocHdnInf.ID = "hdn3" + IntPriCounter;
                        LocTxtInf.Width = 150;
                        LocTxtInf.ReadOnly = true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                try
                {
                    int IntPriCounter;
                    for (IntPriCounter = 0; IntPriCounter <= ctr - 1; IntPriCounter++)
                    {
                        this.TblLevels.Rows.Add(new HtmlTableRow());
                        this.TblLevels.Rows[IntPriCounter + 1].ID = System.Convert.ToString(this.TblLevels.ID) + System.Convert.ToString(this.TblLevels.Rows.Count - 1);

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[0].InnerHtml = Convert.ToString(IntPriCounter + 1);
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[0].Attributes.Add("class", "GridItem");

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[1].Attributes.Add("class", "form-control m-input");
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[1].Attributes.Add("style", "width:25%");

                        System.Web.UI.WebControls.TextBox LocTxtActionGroup = new System.Web.UI.WebControls.TextBox();
                        System.Web.UI.HtmlControls.HtmlImage LocImgBtnHelp = new System.Web.UI.HtmlControls.HtmlImage();

                        System.Web.UI.WebControls.HiddenField LocHdnAction = new System.Web.UI.WebControls.HiddenField();
                        // LocHdnAction.Style.Add("display", "none")
                        LocHdnAction.ID = "hdn" + IntPriCounter;
                        LocTxtActionGroup.Width = 180;
                        LocTxtActionGroup.ReadOnly = true;
                        LocTxtActionGroup.Attributes.Add("class", "form-control m-input");
                        LocTxtActionGroup.Attributes.Add("style", "display: inline");
                        // Assign dt value
                        if (!string.IsNullOrEmpty(Convert.ToString((ObjDt.Rows[IntPriCounter]["UserDesc"]))))
                        {
                            LocTxtActionGroup.Text = Convert.ToString(ObjDt.Rows[IntPriCounter]["UserDesc"]);
                            LocHdnAction.Value = Convert.ToString(ObjDt.Rows[IntPriCounter]["ActionId"]);
                        }
                        else if (!string.IsNullOrEmpty(Convert.ToString((ObjDt.Rows[IntPriCounter]["GroupDesc"]))))
                        {
                            LocTxtActionGroup.Text = Convert.ToString(ObjDt.Rows[IntPriCounter]["GroupDesc"]);
                            LocHdnAction.Value = Convert.ToString(ObjDt.Rows[IntPriCounter]["ActionId"]);
                        }

                        this.TblLevels.Rows[IntPriCounter + 1].Cells[1].Controls.Add(LocTxtActionGroup);


                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[2].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox LocChkBoxEmail = new System.Web.UI.WebControls.CheckBox();

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[3].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox LocChkBoxTxt = new System.Web.UI.WebControls.CheckBox();

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[4].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox ChkBoxAppNotification = new System.Web.UI.WebControls.CheckBox();

                        // ---------------ADD HELP BUTTON---------------------
                        LocImgBtnHelp.Src = "~/assets/app/media/img/icons/AddUser.png";
                        LocImgBtnHelp.Attributes.Add("width", "32");
                        LocImgBtnHelp.Attributes.Add("height", "32");
                        //LocImgBtnHelp.Style.Add("vertical-align", "bottom");
                        LocImgBtnHelp.Attributes.Add("onclick", "PopUpGrid(" + LocTxtActionGroup.ClientID + ",'" + LocHdnAction.ClientID + "');");
                        // ---------------------------------------------------------
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[1].Controls.Add(LocImgBtnHelp);
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[1].Controls.Add(LocHdnAction);


                        if (System.String.IsNullOrWhiteSpace(Request.QueryString["WPConfigID"]))
                        {
                            if (Convert.ToBoolean(ObjDt.Rows[IntPriCounter]["EmailforInformation"]) == true)
                                LocChkBoxEmail.Checked = true;
                            else
                                LocChkBoxEmail.Checked = false;
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[2].Controls.Add(LocChkBoxEmail);

                            if (Convert.ToBoolean(ObjDt.Rows[IntPriCounter]["TextforInformation"]) == true)
                                LocChkBoxTxt.Checked = true;
                            else
                                LocChkBoxTxt.Checked = false;
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[3].Controls.Add(LocChkBoxTxt);


                            if (Convert.ToBoolean(ObjDt.Rows[IntPriCounter]["AppNotification"]) == true)
                                ChkBoxAppNotification.Checked = true;
                            else
                                ChkBoxAppNotification.Checked = false;
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[4].Controls.Add(ChkBoxAppNotification);


                            this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[1].Attributes.Add("class", "GridItem");
                            System.Web.UI.WebControls.TextBox LocTxtTime = new System.Web.UI.WebControls.TextBox();
                            LocTxtTime.Width = 30;

                            LocTxtTime.Text = Convert.ToString(ObjDt.Rows[IntPriCounter]["Escalate_Time"]);
                            LocTxtTime.Attributes.Add("data-rule-number", "true");
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[5].Controls.Add(LocTxtTime);

                            this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                            if (IntPriCounter == ctr - 1)
                            {
                                this.TblLevels.Rows[IntPriCounter + 1].Cells[6].InnerHtml = "0";
                                this.TblLevels.Rows[IntPriCounter + 1].Cells[6].Attributes.Add("class", "GridItem");
                            }
                            else
                            {
                                this.TblLevels.Rows[IntPriCounter + 1].Cells[6].InnerHtml = Convert.ToString(IntPriCounter + 2);
                                this.TblLevels.Rows[IntPriCounter + 1].Cells[6].Attributes.Add("class", "GridItem");
                            }

                            this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        }
                        else
                        {
                            if (Convert.ToBoolean(ObjDt.Rows[IntPriCounter]["EmailNotification"]) == true)
                                LocChkBoxEmail.Checked = true;
                            else
                                LocChkBoxEmail.Checked = false;
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[2].Controls.Add(LocChkBoxEmail);

                            if (Convert.ToBoolean(ObjDt.Rows[IntPriCounter]["SMSNotification"]) == true)
                                LocChkBoxTxt.Checked = true;
                            else
                                LocChkBoxTxt.Checked = false;
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[3].Controls.Add(LocChkBoxTxt);


                            if (Convert.ToBoolean(ObjDt.Rows[IntPriCounter]["AppNotification"]) == true)
                                ChkBoxAppNotification.Checked = true;
                            else
                                ChkBoxAppNotification.Checked = false;
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[4].Controls.Add(ChkBoxAppNotification);

                            this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[5].Attributes.Add("class", "GridItem");
                            System.Web.UI.WebControls.CheckBox ChkBoxMobileAccess = new System.Web.UI.WebControls.CheckBox();
                            if (Convert.ToBoolean(ObjDt.Rows[IntPriCounter]["MobileAccess"]) == true)
                                ChkBoxMobileAccess.Checked = true;
                            else
                                ChkBoxMobileAccess.Checked = false;
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[5].Controls.Add(ChkBoxMobileAccess);

                            this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[6].Attributes.Add("class", "GridItem");
                            System.Web.UI.WebControls.CheckBox ChkBoxWebAccess = new System.Web.UI.WebControls.CheckBox();
                            if (Convert.ToBoolean(ObjDt.Rows[IntPriCounter]["WebAccess"]) == true)
                                ChkBoxWebAccess.Checked = true;
                            else
                                ChkBoxWebAccess.Checked = false;
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[6].Controls.Add(ChkBoxWebAccess);

                            this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[7].Attributes.Add("class", "GridItem");
                            System.Web.UI.WebControls.CheckBox ChkBoxIs_Approve = new System.Web.UI.WebControls.CheckBox();
                            if (Convert.ToBoolean(ObjDt.Rows[IntPriCounter]["Is_Approve"]) == true)
                                ChkBoxIs_Approve.Checked = true;
                            else
                                ChkBoxIs_Approve.Checked = false;
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[7].Controls.Add(ChkBoxIs_Approve);

                            this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[8].Attributes.Add("class", "GridItem");
                            System.Web.UI.WebControls.CheckBox ChkBoxIs_Hold = new System.Web.UI.WebControls.CheckBox();
                            if (Convert.ToBoolean(ObjDt.Rows[IntPriCounter]["Is_Hold"]) == true)
                                ChkBoxIs_Hold.Checked = true;
                            else
                                ChkBoxIs_Hold.Checked = false;
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[8].Controls.Add(ChkBoxIs_Hold);

                            this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[9].Attributes.Add("class", "GridItem");
                            System.Web.UI.WebControls.CheckBox ChkBoxIs_Reject = new System.Web.UI.WebControls.CheckBox();
                            if (Convert.ToBoolean(ObjDt.Rows[IntPriCounter]["Is_Reject"]) == true)
                                ChkBoxIs_Reject.Checked = true;
                            else
                                ChkBoxIs_Reject.Checked = false;
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[9].Controls.Add(ChkBoxIs_Reject);


                            this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[1].Attributes.Add("class", "GridItem");
                            //System.Web.UI.WebControls.TextBox LocTxtTime = new System.Web.UI.WebControls.TextBox();
                            //LocTxtTime.Width = 30;

                            //LocTxtTime.Text = Convert.ToString(ObjDt.Rows[IntPriCounter]["Escalate_Time"]);
                            //LocTxtTime.Attributes.Add("data-rule-number", "true");
                            //this.TblLevels.Rows[IntPriCounter + 1].Cells[5].Controls.Add(LocTxtTime);

                            //this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                            if (IntPriCounter == ctr - 1)
                            {
                                this.TblLevels.Rows[IntPriCounter + 1].Cells[10].InnerHtml = "0";
                                this.TblLevels.Rows[IntPriCounter + 1].Cells[10].Attributes.Add("class", "GridItem");
                            }
                            else
                            {
                                this.TblLevels.Rows[IntPriCounter + 1].Cells[10].InnerHtml = Convert.ToString(IntPriCounter + 2);
                                this.TblLevels.Rows[IntPriCounter + 1].Cells[10].Attributes.Add("class", "GridItem");
                            }

                            //this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());

                        }
                        System.Web.UI.WebControls.TextBox LocTxtInf = new System.Web.UI.WebControls.TextBox();
                        System.Web.UI.HtmlControls.HtmlImage LocImgBtnHelp1 = new System.Web.UI.HtmlControls.HtmlImage();
                        System.Web.UI.WebControls.HiddenField LocHdnInf = new System.Web.UI.WebControls.HiddenField();
                        LocHdnInf.ID = "LocHdnInf4" + IntPriCounter;
                        LocTxtInf.Width = 150;
                        LocTxtInf.ReadOnly = true;

                        // Assign dt value
                        //if (!IsDBNull(ObjDt.Rows(IntPriCounter).Item("infodesc")))
                        //{
                        //    LocTxtInf.Text = ObjDt.Rows(IntPriCounter).Item("infodesc");
                        //    LocHdnInf.Value = ObjDt.Rows(IntPriCounter).Item("infoid");
                        //}
                        //else if (!IsDBNull(ObjDt.Rows(IntPriCounter).Item("infogroupdesc")))
                        //{
                        //    LocTxtInf.Text = ObjDt.Rows(IntPriCounter).Item("infogroupdesc");
                        //    LocHdnInf.Value = ObjDt.Rows(IntPriCounter).Item("infoid");
                        //}


                        //this.TblLevels.Rows(IntPriCounter + 1).Cells(6).Controls.Add(LocTxtInf);



                        // ---------------ADD HELP BUTTON---------------------
                        //LocImgBtnHelp1.Src = "../generalimages/mypc_search.png";
                        //LocImgBtnHelp1.Attributes.Add("width", "32");
                        //LocImgBtnHelp1.Attributes.Add("height", "32");
                        //LocImgBtnHelp1.Style.Add("vertical-align", "bottom");
                        //LocImgBtnHelp1.Attributes.Add("onclick", "PopUpGrid(" + LocTxtInf.ClientID + ",'" + LocHdnInf.ClientID + "');");
                        //// ---------------------------------------------------------
                        //this.TblLevels.Rows[IntPriCounter + 1].Cells[6].Controls.Add(LocImgBtnHelp1);
                        //this.TblLevels.Rows[IntPriCounter + 1].Cells[6].Controls.Add(LocHdnInf);



                        //this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        //this.TblLevels.Rows[IntPriCounter + 1].Cells[7].Attributes.Add("class", "GridItem");
                        //System.Web.UI.WebControls.CheckBox LocChkBoxInfEmail = new System.Web.UI.WebControls.CheckBox();

                        //this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        //this.TblLevels.Rows[IntPriCounter + 1].Cells[8].Attributes.Add("class", "GridItem");
                        //System.Web.UI.WebControls.CheckBox LocChkBoxInfTxt = new System.Web.UI.WebControls.CheckBox();



                        //if (ObjDt.Rows(IntPriCounter).Item("EmailforInformation") == true)
                        //    LocChkBoxInfEmail.Checked = true;
                        //else
                        //    LocChkBoxInfEmail.Checked = false;

                        //this.TblLevels.Rows(IntPriCounter + 1).Cells(7).Controls.Add(LocChkBoxInfEmail);

                        //if (ObjDt.Rows(IntPriCounter).Item("TextforInformation") == true)
                        //    LocChkBoxInfTxt.Checked = true;
                        //else
                        //    LocChkBoxInfTxt.Checked = false;
                        //this.TblLevels.Rows(IntPriCounter + 1).Cells(8).Controls.Add(LocChkBoxInfTxt);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
        }
        public void Fetch_User_UserGroupList(string Initiator)
        {
            //int CategoryID = 0;
            try
            {
                Initiator = "E"; //Approvers only be employee not retailer
                DataSet dsApprovalMatrix = new DataSet();
                dsApprovalMatrix = ObjUpkeep.Fetch_User_UserGroupList(CompanyID);   //changed function RC

                if (dsApprovalMatrix.Tables.Count > 0)
                {
                    if (dsApprovalMatrix.Tables[0].Rows.Count > 0)
                    {
                        //grdInfodetails.DataSource = dsApprovalMatrix.Tables[0];
                        //grdInfodetails.DataBind();
                        html_table.DataSource = dsApprovalMatrix.Tables[0];
                        html_table.DataBind();
                    }
                    if (dsApprovalMatrix.Tables[1].Rows.Count > 0)
                    {
                        grdGroupDesc.DataSource = dsApprovalMatrix.Tables[1];
                        grdGroupDesc.DataBind();
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

                ds = ObjUpkeep.Fetch_AnswerForAll('W');



                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlAns.DataSource = ds.Tables[0];
                        ddlAns.DataTextField = "Ans_Type_Desc";
                        ddlAns.DataValueField = "Ans_Type_ID";


                        ddlAns.DataBind();

                        for (int i = 0; i < ddlAns.Items.Count - 1; i++)
                            ddlAns.Items[i].Attributes["data-isMulti"] = ds.Tables[0].Rows[i]["IS_MultiValue"].ToString();

                        //ddlAns.Items.Insert(0, new ListItem("--Select--", "0"));
                        //ddlAns.SelectedIndex = 0;

                        //ddlAns.Items[0].Attributes["disabled"] = "disabled";
                        //ddlAns.Items[1].Attributes["data-icon"] = "glyphicon-music";
                        //ddlAns.Items[2].Attributes["data-content"] = "<i class='fa fa-calculator' aria-hidden='true'></i>";

                        //foreach (DataRow row in ds.Tables[0].Rows)
                        //{
                        //    sltest.InnerHtml += "<option data-icon = 'glyphicon-music> "+row.Field<string>("Ans_Type_Desc") +" </ option >";
                        //}
                        //sltest.InnerHtml = "";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion Function


    }
}