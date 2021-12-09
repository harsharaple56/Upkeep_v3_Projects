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
        int GP_ConfigID = 0;
        int Del_GPConfigID = 0;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string strGPConfigID = string.Empty;
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            //frmGatePass.Action = @"GatePass_Configuration.aspx";
            if (!System.String.IsNullOrWhiteSpace(Request.QueryString["DelGPConfigID"]))
                Del_GPConfigID = Convert.ToInt32(Request.QueryString["DelGPConfigID"]);
            if (!System.String.IsNullOrWhiteSpace(Request.QueryString["GPConfigID"]))
                GP_ConfigID = Convert.ToInt32(Request.QueryString["GPConfigID"]);


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

                if (GP_ConfigID > 0)
                {
                    strGPConfigID = Request.QueryString["GPConfigID"].ToString();
                    if (strGPConfigID.All(char.IsDigit))
                        ViewState["ConfigID"] = Convert.ToInt32(strGPConfigID);
                    if (ViewState["ConfigID"].ToString() != "0")
                    {
                        Initiator = string.Empty;
                        Bind_GatePassConfiguration(Convert.ToInt32(ViewState["ConfigID"].ToString()));
                    }
                    if (Convert.ToString(Session["CurrentURL"]) != "")
                    {
                        Session["CurrentURL"] = "";
                    }
                }
                else if (Del_GPConfigID > 0)
                {
                    strGPConfigID = Request.QueryString["DelGPConfigID"].ToString();
                    if (strGPConfigID.All(char.IsDigit))
                        GP_ConfigID = Convert.ToInt32(strGPConfigID);
                    if (GP_ConfigID != 0)
                        ObjUpkeep.Delete_GatePassConfiguration(GP_ConfigID, LoggedInUserID);
                }

                Fetch_User_UserGroupList(Initiator);
            }
        }

        public void Bind_GatePassConfiguration(int GP_ConfigID)
        {
            DataSet ds = new DataSet();
            try
            {

                ds = ObjUpkeep.Bind_GatePassConfiguration(GP_ConfigID);
                hdnGPConfigID.Value = Convert.ToString(GP_ConfigID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtTitle.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Title"]);
                        //ddlCompany.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Company_ID"]);
                        string Initiator = Convert.ToString(ds.Tables[0].Rows[0]["Initiator"]);

                        txtGatepassDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["Gatepass_Description"]);

                        if (Initiator == "E")
                        {
                            rdbEmployee.Checked = true;
                        }
                        else
                        {
                            rdbRetailer.Checked = true;
                        }

                        Fetch_User_UserGroupList(Initiator);

                        bool Link_Dept = Convert.ToBoolean(ds.Tables[0].Rows[0]["Link_Dept"]);
                        if (Link_Dept == true)
                        {
                            ChkLinkDept.Checked = true;
                        }
                        else
                        {
                            ChkLinkDept.Checked = false;
                        }

                        bool Is_Returnable_GP = Convert.ToBoolean(ds.Tables[0].Rows[0]["Is_Returnable_Gatepass"]);
                        if (Is_Returnable_GP == true)
                        {
                            chk_returnable_gatepass.Checked = true;
                        }
                        else
                        {
                            chk_returnable_gatepass.Checked = false;
                        }

                        txtGPPrefix.Text = Convert.ToString(ds.Tables[0].Rows[0]["Transaction_Prefix"]);
                        txtNoOfLevel.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoOfLevel"]);
                        txtNoOfLevel_Returnable.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoOfLevel_Returable"]);

                        bool strShowApprovalMatrix = Convert.ToBoolean(ds.Tables[0].Rows[0]["ShowApprovalMatrix"]);
                        if (strShowApprovalMatrix == true)
                        {
                            chkShowApprovalMatrix.Checked = true;
                        }
                        else
                        {
                            chkShowApprovalMatrix.Checked = false;
                        }
                        AddRows(Convert.ToInt32(ds.Tables[0].Rows[0]["NoOfLevel"]), ds);
                        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["NoOfLevel_Returable"].ToString()))
                        {
                            dvReturnable.Visible = true;
                            AddRows_Returnable(Convert.ToInt32(ds.Tables[0].Rows[0]["NoOfLevel_Returable"]), ds);
                        }
                        else
                            dvReturnable.Visible = false;
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        var HeaderValues = ds.Tables[1].AsEnumerable().Select(s =>
                                            s.Field<decimal>("GP_Header_ID").ToString() + "||"
                                            + s.Field<string>("Header_Name").ToString() + "||" + s.Field<string>("Numeric").ToString() + "||"
                                            + s.Field<decimal>("Ans_Type_ID")).ToArray();

                        hdnGPHeaderValues.Value = string.Join("~", HeaderValues);
                    }

                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        var TermsValues = ds.Tables[3].AsEnumerable().Select(s => s.Field<decimal>("GP_Terms_ID").ToString()
                        + "||" + s.Field<string>("Terms_Desc").Replace("<br>", System.Environment.NewLine)).ToArray(); //Added by RC 

                        hdnGPTermsValues.Value = string.Join("~", TermsValues);
                    }

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        var TermsValues = ds.Tables[2].AsEnumerable().Select(s => s.Field<decimal>("GP_Type_ID").ToString()
                        + "||" + s.Field<string>("GP_Type_Desc").Replace("<br>", System.Environment.NewLine)).ToArray(); //Added by RC 

                        hdnGPTypeValues.Value = string.Join("~", TermsValues);
                    }
                }

                if (ds.Tables.Count > 4)
                {
                    if (ds.Tables[5].Rows.Count > 0)
                    {
                        hdnGPClosureBy.Value = Convert.ToString(ds.Tables[5].Rows[0]["ActionId"]);
                        if (Convert.ToString(ds.Tables[5].Rows[0]["UserDesc"]) != "")
                        {
                            txtGPClosure.Text = Convert.ToString(ds.Tables[5].Rows[0]["UserDesc"]);
                        }
                        else
                        {
                            txtGPClosure.Text = Convert.ToString(ds.Tables[5].Rows[0]["GroupDesc"]);
                        }
                    }

                    if (ds.Tables[6].Rows.Count > 0)
                    {
                        hdnGPReceivedBy.Value = Convert.ToString(ds.Tables[5].Rows[0]["ActionId"]);
                        if (Convert.ToString(ds.Tables[5].Rows[0]["UserDesc"]) != "")
                        {
                            txtGPReceivedBy.Text = Convert.ToString(ds.Tables[5].Rows[0]["UserDesc"]);
                        }
                        else
                        {
                            txtGPReceivedBy.Text = Convert.ToString(ds.Tables[5].Rows[0]["GroupDesc"]);
                        }
                    }
                }

                DataSet dsGatePassDoc = new DataSet();
                Session["GPDocID"] = Convert.ToString(hdnGPDocID.Value);
                int GatePassDocID = 0;
                hdnGPTypeID.Value = "";
                GatePassDocID = Session["GPDocID"].ToString() != "" ? Convert.ToInt32(Session["GPDocID"]) : 0;
                dsGatePassDoc = ObjUpkeep.GatePassConfiguration_Document_CRUD(GP_ConfigID, GatePassDocID, "", 0, LoggedInUserID, "R");

                if (dsGatePassDoc.Tables.Count > 0)
                {
                    var DocValues = dsGatePassDoc.Tables[0].AsEnumerable().Select(s =>
                                        s.Field<decimal>("Doc_Config_Id").ToString() + "||"
                                        + s.Field<string>("Doc_Desc").ToString() + "||" + s.Field<bool>("Is_Mandatory").ToString()).ToArray();

                    hdnGPDocumentValues.Value = string.Join("~", DocValues);
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

                string GatePassHeader = string.Empty;
                string GatePassHeaderID = string.Empty;
                string GPHeaderNumeric = string.Empty;
                string GPHeaderUnit = string.Empty;

                string GatePassType = string.Empty;
                string GatePassTypeID = string.Empty;
                string GatePassTermCondition = string.Empty;
                string GatePassTermConditionID = string.Empty;
                string GatePassDoc = string.Empty;
                string GatePassDocID = string.Empty;
                string GPDocMandatory = string.Empty;
                string is_quantity = string.Empty;

                StringBuilder strXmlGatepass_Header = new StringBuilder();
                strXmlGatepass_Header.Append(@"<GATEPASS_HEADER_ROOT>");

                StringBuilder strXmlGatepass_Type = new StringBuilder();
                strXmlGatepass_Type.Append(@"<GATEPASS_TYPE_ROOT>");

                StringBuilder strXmlGatepass_TermCondition = new StringBuilder();
                strXmlGatepass_TermCondition.Append(@"<GATEPASS_TERM_ROOT>");

                StringBuilder strXmlGatepass_Doc = new StringBuilder();
                strXmlGatepass_Doc.Append(@"<GATEPASS_DOC_ROOT>");

                int ccc = Request.Form.Count;
                for (int i = 0; i < ccc; i++)
                {
                    GatePassHeader = "";
                    GatePassHeaderID = "";
                    GPHeaderUnit = "";
                    GPHeaderNumeric = "0";
                    GatePassType = "";
                    GatePassTypeID = "";
                    GatePassDoc = "";
                    GatePassDocID = "";
                    GPDocMandatory = "0";

                    is_quantity = "0";

                    GatePassTermCondition = "";
                    GatePassTermConditionID = "";

                    string[] GatePassHeaderArray = Request.Form.GetValues("GatepassHeader[" + i + "][ctl00$ContentPlaceHolder1$txtGatepassHeader]");
                    string[] GatePassHeaderIDArray = Request.Form.GetValues("GatepassHeader[" + i + "][hdntxtGatepassHeader]");
                    string[] GatePassHeader_UnitArray = Request.Form.GetValues("GatepassHeader[" + i + "][ctl00$ContentPlaceHolder1$ddlUnit]");

                    if (GatePassHeaderArray != null)
                    {
                        GatePassHeader = GatePassHeaderArray[0];
                    }

                    if (GatePassHeaderIDArray != null)
                    {
                        GatePassHeaderID = GatePassHeaderIDArray[0];
                    }
                    
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
                        if (key == "GatepassHeader[" + i + "][ctl00$ContentPlaceHolder1$chk_is_quantity][]")
                        {
                            is_quantity = "1";
                        }
                    }

                    string[] GatePassType_Array = Request.Form.GetValues("GatepassType[" + i + "][ctl00$ContentPlaceHolder1$txtGatepassType]");
                    string[] GatePassTypeID_Array = Request.Form.GetValues("GatepassType[" + i + "][hdnRepeaterGPTID]");
                    if (GatePassType_Array != null)
                    {
                        GatePassType = GatePassType_Array[0];
                    }

                    if (GatePassTypeID_Array != null)
                    {
                        GatePassTypeID = GatePassTypeID_Array[0];
                    }



                    string[] GatePassDoc_Array = Request.Form.GetValues("GatepassDoc[" + i + "][ctl00$ContentPlaceHolder1$txtGPDoc]");
                    string[] GatePassDocID_Array = Request.Form.GetValues("GatepassDoc[" + i + "][hdnRepeaterGPDocID]");
                    if (GatePassDoc_Array != null)
                    {
                        GatePassDoc = GatePassDoc_Array[0];
                    }

                    if (GatePassDocID_Array != null)
                    {
                        GatePassDocID = GatePassDocID_Array[0];
                    }

                    foreach (string key in Request.Form.AllKeys)
                    {
                        if (key == "GatepassDoc[" + i + "][ctl00$ContentPlaceHolder1$chkDocMandatory][]")
                        {
                            GPDocMandatory = "1";
                        }
                    }


                    string[] GatePassTermCondition_Array = Request.Form.GetValues("GatepassTermCondition[" + i + "][ctl00$ContentPlaceHolder1$txtTermComdition]");
                    string[] GatePassTermConditionID_Array = Request.Form.GetValues("GatepassTermCondition[" + i + "][hdnRepeaterTermID]");

                    if (GatePassTermCondition_Array != null)
                    {
                        GatePassTermCondition = GatePassTermCondition_Array[0];
                    }

                    if (GatePassTermConditionID_Array != null)
                    {
                        GatePassTermConditionID = GatePassTermConditionID_Array[0];
                    }

                    if (GatePassHeaderArray != null)
                    {
                        strXmlGatepass_Header.Append(@"<GATEPASS_HEADER_DESC>");
                        strXmlGatepass_Header.Append(@"<GATEPASS_HEADER_ID>" + GatePassHeaderID + "</GATEPASS_HEADER_ID>");
                        strXmlGatepass_Header.Append(@"<GATEPASS_HEADER>" + GatePassHeader + "</GATEPASS_HEADER>");
                        strXmlGatepass_Header.Append(@"<GATEPASS_NUMERIC>" + GPHeaderNumeric + "</GATEPASS_NUMERIC>");
                        strXmlGatepass_Header.Append(@"<GATEPASS_UNIT>" + GPHeaderUnit + "</GATEPASS_UNIT>");
                        strXmlGatepass_Header.Append(@"<GATEPASS_IS_QUANTITY>" + is_quantity + "</GATEPASS_IS_QUANTITY>");
                        strXmlGatepass_Header.Append(@"</GATEPASS_HEADER_DESC>");
                    }

                    if (GatePassType_Array != null)
                    {
                        strXmlGatepass_Type.Append(@"<GATEPASS_TYPE_DESC>");
                        strXmlGatepass_Type.Append(@"<GATEPASS_TYPE_ID>" + GatePassTypeID + "</GATEPASS_TYPE_ID>");
                        strXmlGatepass_Type.Append(@"<GATEPASS_TYPE>" + GatePassType + "</GATEPASS_TYPE>");
                        strXmlGatepass_Type.Append(@"</GATEPASS_TYPE_DESC>");
                    }

                    if (GatePassDoc_Array != null)
                    {
                        strXmlGatepass_Doc.Append(@"<GATEPASS_DOC_DESC>");
                        strXmlGatepass_Doc.Append(@"<GATEPASS_DOC_HEADER_ID>" + GatePassDocID + "</GATEPASS_DOC_HEADER_ID>");
                        strXmlGatepass_Doc.Append(@"<GATEPASS_DOC_HEADER>" + GatePassDoc + "</GATEPASS_DOC_HEADER>");
                        strXmlGatepass_Doc.Append(@"<GATEPASS_DOC_MANDATORY>" + GPDocMandatory + "</GATEPASS_DOC_MANDATORY>");
                        strXmlGatepass_Doc.Append(@"</GATEPASS_DOC_DESC>");
                    }

                    if (GatePassTermCondition_Array != null)
                    {
                        strXmlGatepass_TermCondition.Append(@"<GATEPASS_TERM_DESC>");
                        strXmlGatepass_TermCondition.Append(@"<GATEPASS_TERM_ID>" + GatePassTermConditionID + "</GATEPASS_TERM_ID>");
                        strXmlGatepass_TermCondition.Append(@"<GATEPASS_TERM>" + GatePassTermCondition + "</GATEPASS_TERM>");
                        strXmlGatepass_TermCondition.Append(@"</GATEPASS_TERM_DESC>");
                    }

                }

                strXmlGatepass_Header.Append(@"</GATEPASS_HEADER_ROOT>");
                strXmlGatepass_Type.Append(@"</GATEPASS_TYPE_ROOT>");
                strXmlGatepass_Doc.Append(@"</GATEPASS_DOC_ROOT>");
                strXmlGatepass_TermCondition.Append(@"</GATEPASS_TERM_ROOT>");


                //Normal approval matrix
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

                //Returnable approval matrix
                string hdnApprovalMatrix_Returnable = txtHdn_Returnable.Text;
                string[] strArrayApprovalMatrix_Returnable = hdnApprovalMatrix_Returnable.Split(',');

                XmlDocument xmlDocProm_return = null;
                xmlDocProm_return = new XmlDocument();
                int ApprovalLevel_Returnable = 0;
                ApprovalLevel_Returnable = strArrayApprovalMatrix_Returnable.Length - 1;

                StringBuilder strXmlApprovalMatrix_Returnable = new StringBuilder();
                strXmlApprovalMatrix_Returnable.Append(@"<?xml version=""1.0"" ?>");
                strXmlApprovalMatrix_Returnable.Append(@"<APPROVAL_MATRIX_RETURN_ROOT>");

                for (int intLocRowCtr = 0; intLocRowCtr <= ApprovalLevel_Returnable; intLocRowCtr++)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(strArrayApprovalMatrix_Returnable[intLocRowCtr])))
                    {
                        string[] LocArr = strArrayApprovalMatrix_Returnable[intLocRowCtr].Split('#');

                        strXmlApprovalMatrix_Returnable.Append(@"<APPROVAL_MATRIX_DETAILS>");

                        strXmlApprovalMatrix_Returnable.Append(@"<level>" + LocArr[0] + "</level>");
                        strXmlApprovalMatrix_Returnable.Append(@"<Userid>" + LocArr[1] + "</Userid>");
                        strXmlApprovalMatrix_Returnable.Append(@"<UserGroupid>" + LocArr[2] + "</UserGroupid>");
                        strXmlApprovalMatrix_Returnable.Append(@"<SendEmail>" + LocArr[3] + "</SendEmail>");
                        strXmlApprovalMatrix_Returnable.Append(@"<SendSMS>" + LocArr[4] + "</SendSMS>");
                        strXmlApprovalMatrix_Returnable.Append(@"<SendNotification>" + LocArr[5] + "</SendNotification>");
                        strXmlApprovalMatrix_Returnable.Append(@"<MobileAccess>" + LocArr[6] + "</MobileAccess>");
                        strXmlApprovalMatrix_Returnable.Append(@"<WebAccess>" + LocArr[7] + "</WebAccess>");
                        strXmlApprovalMatrix_Returnable.Append(@"<ApprovalRights>" + LocArr[8] + "</ApprovalRights>");
                        strXmlApprovalMatrix_Returnable.Append(@"<HoldRights>" + LocArr[9] + "</HoldRights>");
                        strXmlApprovalMatrix_Returnable.Append(@"<RejectRights>" + LocArr[10] + "</RejectRights>");
                        strXmlApprovalMatrix_Returnable.Append(@"<nextactionlevel>" + LocArr[11] + "</nextactionlevel>");

                        strXmlApprovalMatrix_Returnable.Append(@"</APPROVAL_MATRIX_DETAILS>");
                    }
                }
                strXmlApprovalMatrix_Returnable.Append(@"</APPROVAL_MATRIX_RETURN_ROOT>");



                string strConfigTitle = string.Empty;
                //int CompanyID = 0;
                string strInitiator = string.Empty;
                bool LinkDepartment = false;
                string strTransactionPrefix = string.Empty;
                string strGPClosureBy = string.Empty;
                string strGPReceivedBy = string.Empty;

                bool is_Returnable_Gatepass = false;

                bool ShowApprovalMatrix = false;

                strConfigTitle = txtTitle.Text.Trim();
                //CompanyID = Convert.ToInt32(Convert.ToString(Session["LoggedInUserID"]));
                LinkDepartment = Convert.ToBoolean(ChkLinkDept.Checked);
                ShowApprovalMatrix = Convert.ToBoolean(chkShowApprovalMatrix.Checked);

                is_Returnable_Gatepass = Convert.ToBoolean(chk_returnable_gatepass.Checked);

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
                strGPReceivedBy = Convert.ToString(hdnGPReceivedBy.Value);

                string GatepassDescription = string.Empty;
                GatepassDescription = Convert.ToString(txtGatepassDescription.Text.Trim());

                DataSet dsGatePassConfig = new DataSet();
                if (GP_ConfigID == 0)
                {
                    dsGatePassConfig = ObjUpkeep.Insert_GatePassConfiguration(strConfigTitle, CompanyID, strInitiator, LinkDepartment, strTransactionPrefix, strXmlGatepass_Header.ToString(), strXmlGatepass_Type.ToString(), strXmlGatepass_Doc.ToString(), strXmlGatepass_TermCondition.ToString(), strXmlApprovalMatrix.ToString(), strXmlApprovalMatrix_Returnable.ToString(), ShowApprovalMatrix, strGPClosureBy, strGPReceivedBy, GatepassDescription, is_Returnable_Gatepass, LoggedInUserID);
                }
                else
                {
                    dsGatePassConfig = ObjUpkeep.Update_GatePassConfiguration(GP_ConfigID,strConfigTitle, CompanyID, strInitiator, LinkDepartment, strTransactionPrefix, strXmlGatepass_Header.ToString(), strXmlGatepass_Type.ToString(), strXmlGatepass_Doc.ToString(), strXmlGatepass_TermCondition.ToString(), strXmlApprovalMatrix.ToString(), strXmlApprovalMatrix_Returnable.ToString(), ShowApprovalMatrix, strGPClosureBy, strGPReceivedBy, GatepassDescription, is_Returnable_Gatepass, LoggedInUserID);
                }

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
                ObjDt = dsApprovalMatrix.Tables[4];
            }
            //TblLevels.Visible = true;
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
                        string call_type = "Approve";
                        //LocImgBtnHelp.Attributes.Add("onclick", "PopUpGrid(" + LocTxtActionGroup.ClientID + ",'" + LocHdnAction.ClientID + ","" + call_type+"");");
                        LocImgBtnHelp.Attributes.Add("onclick", "PopUpGrid(" + LocTxtActionGroup.ClientID + ",'" + LocHdnAction.ClientID + "', 'close');");
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
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    ddlCompany.DataSource = ds.Tables[0];
                    //    ddlCompany.DataTextField = "CompanyDesc";
                    //    ddlCompany.DataValueField = "CompanyId";
                    //    ddlCompany.DataBind();
                    //    ddlCompany.Items.Insert(0, new ListItem("--Select--", "0"));
                    //}
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
                            ddlUnit.Items[i].Attributes["data-isMulti"] = ds.Tables[0].Rows[i]["IS_MultiValue"].ToString();

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

        protected void btnMakeCombination_Returnable_Click(object sender, EventArgs e)
        {
            int NoOfLevels_Return = Convert.ToInt32(txtNoOfLevel_Returnable.Text);
            AddRows_Returnable(NoOfLevels_Return, null);

            //int NoOfLevels = Convert.ToInt32(txtNoOfLevel.Text);
            //if (NoOfLevels > 0)
            //{
            //    AddRows(NoOfLevels, null);
            //}
        }

        private void AddRows_Returnable(int NoOfLevels, DataSet dsReturableMatrix)
        {
            int ctr = NoOfLevels;
            DataTable ObjDt = null;

            if (dsReturableMatrix != null)
            {
                ObjDt = dsReturableMatrix.Tables[6];
            }
            //TblLevels.Visible = true;
            //TblSave.Visible = true;
            if (dsReturableMatrix == null)
            {
                try
                {
                    int IntPriCounter;
                    for (IntPriCounter = 0; IntPriCounter <= ctr - 1; IntPriCounter++)
                    {
                        this.TblLevels_Returnable.Rows.Add(new HtmlTableRow());
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].ID = System.Convert.ToString(this.TblLevels_Returnable.ID) + System.Convert.ToString(this.TblLevels_Returnable.Rows.Count - 1);

                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[0].InnerHtml = (IntPriCounter + 1).ToString();
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[0].Attributes.Add("class", "GridItem");

                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[1].Attributes.Add("class", "form-control m-input");

                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[1].Attributes.Add("style", "width:25%");

                        System.Web.UI.WebControls.TextBox LocTxtActionGroup1 = new System.Web.UI.WebControls.TextBox();
                        System.Web.UI.HtmlControls.HtmlImage LocImgBtnHelp1 = new System.Web.UI.HtmlControls.HtmlImage();

                        System.Web.UI.WebControls.HiddenField LocHdnAction1 = new System.Web.UI.WebControls.HiddenField();
                        // LocHdnAction.Style.Add("display", "none")
                        LocHdnAction1.ID = "hdn2" + IntPriCounter;
                        LocTxtActionGroup1.Width = 176;
                        LocTxtActionGroup1.Attributes.Add("class", "form-control m-input");
                        LocTxtActionGroup1.Attributes.Add("style", "display: inline");
                        LocTxtActionGroup1.ReadOnly = true;
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[1].Controls.Add(LocTxtActionGroup1);


                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[2].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox LocChkBoxEmail1 = new System.Web.UI.WebControls.CheckBox();
                        LocChkBoxEmail1.Checked = false;

                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[3].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox LocChkBoxTxt1 = new System.Web.UI.WebControls.CheckBox();
                        LocChkBoxTxt1.Checked = false;

                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[4].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox ChkBoxNotification1 = new System.Web.UI.WebControls.CheckBox();
                        ChkBoxNotification1.Checked = false;


                        // ---------------ADD HELP BUTTON---------------------
                        //LocImgBtnHelp.Src = "../generalimages/mypc_search.png";
                        LocImgBtnHelp1.Src = Page.ResolveClientUrl("~/assets/app/media/img/icons/AddUser.png");
                        LocImgBtnHelp1.Attributes.Add("width", "32");
                        LocImgBtnHelp1.Attributes.Add("height", "32");
                        //LocImgBtnHelp.Style.Add("vertical-align", "bottom");
                        string call_type = "Approve";
                        //LocImgBtnHelp.Attributes.Add("onclick", "PopUpGrid(" + LocTxtActionGroup.ClientID + ",'" + LocHdnAction.ClientID + ","" + call_type+"");");
                        LocImgBtnHelp1.Attributes.Add("onclick", "PopUpGrid(" + LocTxtActionGroup1.ClientID + ",'" + LocHdnAction1.ClientID + "', 'return');");
                        // ---------------------------------------------------------
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[1].Controls.Add(LocImgBtnHelp1);
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[1].Controls.Add(LocHdnAction1);


                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[2].Controls.Add(LocChkBoxEmail1);
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[3].Controls.Add(LocChkBoxTxt1);
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[4].Controls.Add(ChkBoxNotification1);

                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[1].Attributes.Add("class", "GridItem");

                        //System.Web.UI.WebControls.TextBox LocTxtTime = new System.Web.UI.WebControls.TextBox();
                        //LocTxtTime.Width = 30;
                        //LocTxtTime.Attributes.Add("data-rule-number", "true");
                        //this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[5].Controls.Add(LocTxtTime);

                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[5].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox ChkMobile1 = new System.Web.UI.WebControls.CheckBox();
                        ChkMobile1.Checked = false;
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[5].Controls.Add(ChkMobile1);

                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[6].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox ChkWeb1 = new System.Web.UI.WebControls.CheckBox();
                        ChkWeb1.Checked = false;
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[6].Controls.Add(ChkWeb1);

                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[7].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox ChkApprove1 = new System.Web.UI.WebControls.CheckBox();
                        ChkApprove1.Checked = false;
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[7].Controls.Add(ChkApprove1);

                        if (IntPriCounter == 0 || IntPriCounter == ctr - 1)
                        {
                            ChkApprove1.Checked = true;
                            ChkApprove1.Enabled = false;
                        }



                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[8].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox ChkHold1 = new System.Web.UI.WebControls.CheckBox();
                        ChkHold1.Checked = false;
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[8].Controls.Add(ChkHold1);

                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[9].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox ChkReject1 = new System.Web.UI.WebControls.CheckBox();
                        ChkReject1.Checked = false;
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[9].Controls.Add(ChkReject1);

                        //this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        if (IntPriCounter == ctr - 1)
                        {
                            this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[10].InnerHtml = "0";
                            this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[10].Attributes.Add("class", "GridItem");
                        }
                        else
                        {
                            this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[10].InnerHtml = (IntPriCounter + 2).ToString();
                            this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[10].Attributes.Add("class", "GridItem");
                        }

                        //this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        System.Web.UI.WebControls.TextBox LocTxtInf1 = new System.Web.UI.WebControls.TextBox();
                        System.Web.UI.HtmlControls.HtmlImage LocImgBtnHelp11 = new System.Web.UI.HtmlControls.HtmlImage();

                        System.Web.UI.WebControls.HiddenField LocHdnInf1 = new System.Web.UI.WebControls.HiddenField();
                        // LocHdnInf.Style.Add("display", "none")
                        LocHdnInf1.ID = "hdn3" + IntPriCounter;
                        LocTxtInf1.Width = 150;
                        LocTxtInf1.ReadOnly = true;
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
                        this.TblLevels_Returnable.Rows.Add(new HtmlTableRow());
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].ID = System.Convert.ToString(this.TblLevels_Returnable.ID) + System.Convert.ToString(this.TblLevels_Returnable.Rows.Count - 1);

                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[0].InnerHtml = Convert.ToString(IntPriCounter + 1);
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[0].Attributes.Add("class", "GridItem");

                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[1].Attributes.Add("class", "form-control m-input");
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[1].Attributes.Add("style", "width:25%");

                        System.Web.UI.WebControls.TextBox LocTxtActionGroup2 = new System.Web.UI.WebControls.TextBox();
                        System.Web.UI.HtmlControls.HtmlImage LocImgBtnHelp2 = new System.Web.UI.HtmlControls.HtmlImage();

                        System.Web.UI.WebControls.HiddenField LocHdnAction2 = new System.Web.UI.WebControls.HiddenField();
                        // LocHdnAction.Style.Add("display", "none")
                        LocHdnAction2.ID = "hdn_Returnable" + IntPriCounter;
                        LocTxtActionGroup2.Width = 180;
                        LocTxtActionGroup2.ReadOnly = true;
                        LocTxtActionGroup2.Attributes.Add("class", "form-control m-input");
                        LocTxtActionGroup2.Attributes.Add("style", "display: inline");
                        // Assign dt value
                        if (!string.IsNullOrEmpty(Convert.ToString((ObjDt.Rows[IntPriCounter]["UserDesc"]))))
                        {
                            LocTxtActionGroup2.Text = Convert.ToString(ObjDt.Rows[IntPriCounter]["UserDesc"]);
                            LocHdnAction2.Value = Convert.ToString(ObjDt.Rows[IntPriCounter]["ActionId"]);
                        }
                        else if (!string.IsNullOrEmpty(Convert.ToString((ObjDt.Rows[IntPriCounter]["GroupDesc"]))))
                        {
                            LocTxtActionGroup2.Text = Convert.ToString(ObjDt.Rows[IntPriCounter]["GroupDesc"]);
                            LocHdnAction2.Value = Convert.ToString(ObjDt.Rows[IntPriCounter]["ActionId"]);
                        }

                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[1].Controls.Add(LocTxtActionGroup2);


                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[2].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox LocChkBoxEmail2 = new System.Web.UI.WebControls.CheckBox();

                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[3].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox LocChkBoxTxt2 = new System.Web.UI.WebControls.CheckBox();

                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[4].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox ChkBoxAppNotification2 = new System.Web.UI.WebControls.CheckBox();

                        // ---------------ADD HELP BUTTON---------------------
                        LocImgBtnHelp2.Src = "~/assets/app/media/img/icons/AddUser.png";
                        LocImgBtnHelp2.Attributes.Add("width", "32");
                        LocImgBtnHelp2.Attributes.Add("height", "32");
                        //LocImgBtnHelp.Style.Add("vertical-align", "bottom");
                        LocImgBtnHelp2.Attributes.Add("onclick", "PopUpGrid(" + LocTxtActionGroup2.ClientID + ",'" + LocHdnAction2.ClientID + "');");
                        // ---------------------------------------------------------
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[1].Controls.Add(LocImgBtnHelp2);
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[1].Controls.Add(LocHdnAction2);



                        if (Convert.ToBoolean(ObjDt.Rows[IntPriCounter]["EmailNotification"]) == true)
                            LocChkBoxEmail2.Checked = true;
                        else
                            LocChkBoxEmail2.Checked = false;
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[2].Controls.Add(LocChkBoxEmail2);

                        if (Convert.ToBoolean(ObjDt.Rows[IntPriCounter]["SMSNotification"]) == true)
                            LocChkBoxTxt2.Checked = true;
                        else
                            LocChkBoxTxt2.Checked = false;
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[3].Controls.Add(LocChkBoxTxt2);


                        if (Convert.ToBoolean(ObjDt.Rows[IntPriCounter]["AppNotification"]) == true)
                            ChkBoxAppNotification2.Checked = true;
                        else
                            ChkBoxAppNotification2.Checked = false;
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[4].Controls.Add(ChkBoxAppNotification2);

                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[5].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox ChkBoxMobileAccess2 = new System.Web.UI.WebControls.CheckBox();
                        if (Convert.ToBoolean(ObjDt.Rows[IntPriCounter]["MobileAccess"]) == true)
                            ChkBoxMobileAccess2.Checked = true;
                        else
                            ChkBoxMobileAccess2.Checked = false;
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[5].Controls.Add(ChkBoxMobileAccess2);

                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[6].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox ChkBoxWebAccess2 = new System.Web.UI.WebControls.CheckBox();
                        if (Convert.ToBoolean(ObjDt.Rows[IntPriCounter]["WebAccess"]) == true)
                            ChkBoxWebAccess2.Checked = true;
                        else
                            ChkBoxWebAccess2.Checked = false;
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[6].Controls.Add(ChkBoxWebAccess2);

                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[7].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox ChkBoxIs_Approve2 = new System.Web.UI.WebControls.CheckBox();
                        if (Convert.ToBoolean(ObjDt.Rows[IntPriCounter]["Is_Approve"]) == true)
                            ChkBoxIs_Approve2.Checked = true;
                        else
                            ChkBoxIs_Approve2.Checked = false;
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[7].Controls.Add(ChkBoxIs_Approve2);

                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[8].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox ChkBoxIs_Hold2 = new System.Web.UI.WebControls.CheckBox();
                        if (Convert.ToBoolean(ObjDt.Rows[IntPriCounter]["Is_Hold"]) == true)
                            ChkBoxIs_Hold2.Checked = true;
                        else
                            ChkBoxIs_Hold2.Checked = false;
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[8].Controls.Add(ChkBoxIs_Hold2);

                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[9].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.CheckBox ChkBoxIs_Reject2 = new System.Web.UI.WebControls.CheckBox();
                        if (Convert.ToBoolean(ObjDt.Rows[IntPriCounter]["Is_Reject"]) == true)
                            ChkBoxIs_Reject2.Checked = true;
                        else
                            ChkBoxIs_Reject2.Checked = false;
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[9].Controls.Add(ChkBoxIs_Reject2);


                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[1].Attributes.Add("class", "GridItem");
                        //System.Web.UI.WebControls.TextBox LocTxtTime = new System.Web.UI.WebControls.TextBox();
                        //LocTxtTime.Width = 30;

                        //LocTxtTime.Text = Convert.ToString(ObjDt.Rows[IntPriCounter]["Escalate_Time"]);
                        //LocTxtTime.Attributes.Add("data-rule-number", "true");
                        //this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[5].Controls.Add(LocTxtTime);

                        //this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        if (IntPriCounter == ctr - 1)
                        {
                            this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[10].InnerHtml = "0";
                            this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[10].Attributes.Add("class", "GridItem");
                        }
                        else
                        {
                            this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[10].InnerHtml = Convert.ToString(IntPriCounter + 2);
                            this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells[10].Attributes.Add("class", "GridItem");
                        }

                        //this.TblLevels_Returnable.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        System.Web.UI.WebControls.TextBox LocTxtInf2 = new System.Web.UI.WebControls.TextBox();
                        System.Web.UI.HtmlControls.HtmlImage LocImgBtnHelp22 = new System.Web.UI.HtmlControls.HtmlImage();
                        System.Web.UI.WebControls.HiddenField LocHdnInf2 = new System.Web.UI.WebControls.HiddenField();
                        LocHdnInf2.ID = "LocHdnInf4" + IntPriCounter;
                        LocTxtInf2.Width = 150;
                        LocTxtInf2.ReadOnly = true;

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
        }

    }
}