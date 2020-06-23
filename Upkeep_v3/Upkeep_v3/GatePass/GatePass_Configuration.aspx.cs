using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using System.Text;

namespace Upkeep_v3.GatePass
{
    public partial class GatePass_Configuration : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            //frmGatePass.Action = @"GatePass_Configuration.aspx";
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            if (!IsPostBack)
            {
                //Fetch_Company();
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

                Fetch_User_UserGroupList(Initiator);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string GatePassHeader = string.Empty;
                string GPHeaderNumeric = string.Empty;
                string GPHeaderUnit = string.Empty;

                string GatePassType = string.Empty;
                string GatePassTermCondition = string.Empty;

                StringBuilder strXmlGatepass_Header = new StringBuilder();
                strXmlGatepass_Header.Append(@"<?xml version=""1.0"" ?>");
                strXmlGatepass_Header.Append(@"<GATEPASS_HEADER_ROOT>");

                StringBuilder strXmlGatepass_Type = new StringBuilder();
                strXmlGatepass_Type.Append(@"<?xml version=""1.0"" ?>");
                strXmlGatepass_Type.Append(@"<GATEPASS_TYPE_ROOT>");

                StringBuilder strXmlGatepass_TermCondition = new StringBuilder();
                strXmlGatepass_TermCondition.Append(@"<?xml version=""1.0"" ?>");
                strXmlGatepass_TermCondition.Append(@"<GATEPASS_TERM_ROOT>");

                int ccc = Request.Form.Count;
                for (int i = 0; i < ccc; i++)
                {
                    GatePassHeader = "";
                    GPHeaderUnit = "";
                    GPHeaderNumeric = "0";
                    GatePassType = "";
                    GatePassTermCondition = "";
                    string[] GatePassHeaderArray = Request.Form.GetValues("GatepassHeader[" + i + "][ctl00$ContentPlaceHolder1$txtGatepassHeader]");
                    //string[] GatePassHeader_NumericArray = Request.Form.GetValues("GatepassHeader[" + i + "][ctl00$ContentPlaceHolder1$ChkNumeric]");

                    string[] GatePassHeader_UnitArray = Request.Form.GetValues("GatepassHeader[" + i + "][ctl00$ContentPlaceHolder1$ddlUnit]");

                    if (GatePassHeaderArray != null)
                    {
                        GatePassHeader = GatePassHeaderArray[0];
                    }
                    //if (GatePassHeader_NumericArray != null)
                    //{
                    //    GPHeaderNumeric = GatePassHeader_NumericArray[0];
                    //}
                    if (GatePassHeader_UnitArray != null)
                    {
                        GPHeaderUnit = GatePassHeader_UnitArray[0];
                    }

                    foreach (string key in Request.Form.AllKeys)
                    {
                        if (key == "GatepassHeader[" + i + "][ctl00$ContentPlaceHolder1$ChkNumeric][]")
                        {
                            GPHeaderNumeric = "1";
                        }
                    }

                    string[] GatePassType_Array = Request.Form.GetValues("GatepassType[" + i + "][ctl00$ContentPlaceHolder1$txtGatepassType]");
                    if (GatePassType_Array != null)
                    {
                        GatePassType = GatePassType_Array[0];
                    }

                    string[] GatePassTermCondition_Array = Request.Form.GetValues("GatepassTermCondition[" + i + "][ctl00$ContentPlaceHolder1$txtTermComdition]");
                    if (GatePassTermCondition_Array != null)
                    {
                        GatePassTermCondition = GatePassTermCondition_Array[0];
                    }

                    if (GatePassHeaderArray != null)
                    {
                        strXmlGatepass_Header.Append(@"<GATEPASS_HEADER_DESC>");
                        strXmlGatepass_Header.Append(@"<GATEPASS_HEADER>" + GatePassHeader + "</GATEPASS_HEADER>");
                        strXmlGatepass_Header.Append(@"<GATEPASS_NUMERIC>" + GPHeaderNumeric + "</GATEPASS_NUMERIC>");
                        strXmlGatepass_Header.Append(@"<GATEPASS_UNIT>" + GPHeaderUnit + "</GATEPASS_UNIT>");
                        strXmlGatepass_Header.Append(@"</GATEPASS_HEADER_DESC>");
                    }

                    if (GatePassType_Array != null)
                    {
                        strXmlGatepass_Type.Append(@"<GATEPASS_TYPE_DESC>");
                        strXmlGatepass_Type.Append(@"<GATEPASS_TYPE>" + GatePassType + "</GATEPASS_TYPE>");
                        strXmlGatepass_Type.Append(@"</GATEPASS_TYPE_DESC>");
                    }

                    if (GatePassTermCondition_Array != null)
                    {
                        strXmlGatepass_TermCondition.Append(@"<GATEPASS_TERM_DESC>");
                        strXmlGatepass_TermCondition.Append(@"<GATEPASS_TERM>" + GatePassTermCondition + "</GATEPASS_TERM>");
                        strXmlGatepass_TermCondition.Append(@"</GATEPASS_TERM_DESC>");
                    }

                }

                strXmlGatepass_Header.Append(@"</GATEPASS_HEADER_ROOT>");
                strXmlGatepass_Type.Append(@"</GATEPASS_TYPE_ROOT>");
                strXmlGatepass_TermCondition.Append(@"</GATEPASS_TERM_ROOT>");


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
                string strGPClosureBy = string.Empty;

                bool ShowApprovalMatrix = false;

                strConfigTitle = txtTitle.Text.Trim();
                CompanyID = Convert.ToInt32(Convert.ToString(Session["LoggedInUserID"]));
                LinkDepartment = Convert.ToBoolean(ChkLinkDept.Checked);
                ShowApprovalMatrix = Convert.ToBoolean(chkShowApprovalMatrix.Checked);

                if (rdbEmployee.Checked == true)
                {
                    strInitiator = "E";
                }
                else if (rdbRetailer.Checked == true)
                {
                    strInitiator = "R";
                }

                strTransactionPrefix = Convert.ToString(txtGPPrefix.Text.Trim());

                strGPClosureBy = Convert.ToString(hdnGPClosureBy.Value);

                string GatepassDescription = string.Empty;
                GatepassDescription = Convert.ToString(txtGatepassDescription.Text.Trim());

                DataSet dsGatePassConfig = new DataSet();
                dsGatePassConfig = ObjUpkeep.Insert_GatePassConfiguration(strConfigTitle, CompanyID, strInitiator, LinkDepartment, strTransactionPrefix, strXmlGatepass_Header.ToString(), strXmlGatepass_Type.ToString(), strXmlGatepass_TermCondition.ToString(), strXmlApprovalMatrix.ToString(), ShowApprovalMatrix, strGPClosureBy, GatepassDescription, LoggedInUserID);

                if (dsGatePassConfig.Tables.Count > 0)
                {
                    if (dsGatePassConfig.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsGatePassConfig.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {

                            Response.Redirect(Page.ResolveClientUrl("~/GatePass/GatePassConfig_Listing.aspx"), false);
                        }
                        else if (Status == 3)
                        {
                            lblErrorMsg.Text = "Title already exists";
                        }
                        else if (Status == 4)
                        {
                            lblErrorMsg.Text = "Prefix already exists";
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

        protected void btnMakeCombination_Click(object sender, EventArgs e)
        {
            int NoOfLevels = Convert.ToInt32(txtNoOfLevel.Text);
            AddRows(NoOfLevels, null);


        }

        private void AddRows(int NoOfLevels, DataSet dsApprovalMatrix)
        {
            int ctr = NoOfLevels;
            DataTable ObjDt = null;

            if (dsApprovalMatrix != null)
            {
                ObjDt = dsApprovalMatrix.Tables[1];
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

                        if (IntPriCounter == 0 || IntPriCounter == ctr - 1)
                        {
                            ChkApprove.Checked = true;
                            ChkApprove.Enabled = false;
                        }



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
                dsApprovalMatrix = ObjUpkeep.Fetch_User_UserGroupList(CompanyID);  // changed function

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

        protected void rdbInitiator_CheckedChanged(object sender, EventArgs e)
        {
            string Initiator = string.Empty;
            if (rdbEmployee.Checked == true)
            {
                Initiator = "E";
            }
            else if (rdbRetailer.Checked == true)
            {
                Initiator = "R";
            }

            Fetch_User_UserGroupList(Initiator);
        }

        public void Fetch_Company()
        {
            DataSet ds = new DataSet();
            try
            {

                ds = ObjUpkeep.Fetch_Company();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlCompany.DataSource = ds.Tables[0];
                        ddlCompany.DataTextField = "CompanyDesc";
                        ddlCompany.DataValueField = "CompanyId";
                        ddlCompany.DataBind();
                        ddlCompany.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
                if (ds.Tables.Count > 1)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        ddlUnit.DataSource = ds.Tables[1];
                        ddlUnit.DataTextField = "Unit_Type_Desc";
                        ddlUnit.DataValueField = "Unit_ID";
                        ddlUnit.DataBind();
                        ddlUnit.Items.Insert(0, new ListItem("--Select--", "0"));
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

                ds = ObjUpkeep.Fetch_AnswerForAll('G');



                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlUnit.DataSource = ds.Tables[0];
                        ddlUnit.DataTextField = "Ans_Type_Desc";
                        ddlUnit.DataValueField = "Ans_Type_ID";


                        ddlUnit.DataBind();

                        for (int i = 0; i < ddlUnit.Items.Count - 1; i++)
                            ddlUnit.Items[i].Attributes["data-isMulti"] = ds.Tables[0].Rows[i]["IS_MultiValue"].ToString(); //ddlAns.Items.Insert(0, new ListItem("--Select--", "0"));
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


    }
}