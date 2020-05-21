using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Text;
using System.Web.UI.HtmlControls;

namespace Upkeep_Gatepass_Workpermit.GatePass
{
    public partial class EditGP_Configuration : System.Web.UI.Page
    {
        Upkeep_GP_WP_Services.Upkeep_GP_WP_Services ObjUpkeep = new Upkeep_GP_WP_Services.Upkeep_GP_WP_Services();
        string LoggedInUserID = string.Empty;
        int GP_ConfigID = 0;
        int Del_GPConfigID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            GP_ConfigID = Convert.ToInt32(Request.QueryString["GPConfigID"]);
            Del_GPConfigID = Convert.ToInt32(Request.QueryString["DelGPConfigID"]);
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            if (!IsPostBack)
            {
                if (Del_GPConfigID > 0)
                {
                    Delete_GatePassConfiguration(Del_GPConfigID);
                }
                else
                {
                    if (Convert.ToString(Session["CurrentURL"]) != "")
                    {
                        btnAddGPHeader.Focus();
                        Session["CurrentURL"] = "";
                    }
                    Session["CurrentURL"] = HttpContext.Current.Request.Url.AbsoluteUri;
                    Fetch_Company();
                    string Initiator = string.Empty;
                    if (rdbEmployee.Checked == true)
                    {
                        Initiator = "E";
                    }
                    else if (rdbRetailer.Checked == true)
                    {
                        Initiator = "R";
                    }

                    //Fetch_User_UserGroupList(Initiator);
                    Bind_GatePassConfiguration(GP_ConfigID);
                }
            }
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

        public void Fetch_User_UserGroupList(string Initiator)
        {
            //int CategoryID = 0;
            try
            {
                DataSet dsApprovalMatrix = new DataSet();
                dsApprovalMatrix = ObjUpkeep.Fetch_User_UserGroupList(Initiator);

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

        public void Bind_GatePassConfiguration(int GP_ConfigID)
        {
            DataSet ds = new DataSet();
            try
            {

                ds = ObjUpkeep.Bind_GatePassConfiguration(GP_ConfigID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtTitle.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Title"]);
                        ddlCompany.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Company_ID"]);
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

                        txtGPPrefix.Text = Convert.ToString(ds.Tables[0].Rows[0]["Transaction_Prefix"]);
                        txtNoOfLevel.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoOfLevel"]);

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
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string bindGP_Header_Type_Terms()
        {
            string data = "";
            DataSet ds = new DataSet();
            try
            {
                ds = ObjUpkeep.Bind_GatePassConfiguration(GP_ConfigID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables.Count > 1)
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            int count = Convert.ToInt32(ds.Tables[1].Rows.Count);

                            for (int i = 0; i < count; i++)
                            {
                                string strSrNo = Convert.ToString(ds.Tables[1].Rows[i]["SrNo"]);
                                int GP_HeaderID = Convert.ToInt32(ds.Tables[1].Rows[i]["GP_Header_ID"]);
                                string GP_Header = Convert.ToString(ds.Tables[1].Rows[i]["Header_Name"]);
                                string Numeric = Convert.ToString(ds.Tables[1].Rows[i]["Numeric"]);
                                string Unit = Convert.ToString(ds.Tables[1].Rows[i]["Unit_Type_Desc"]);

                                data += "<tr><td>" + strSrNo + "</td><td>" + GP_Header + "</td><td>" + Numeric + "</td><td>" + Unit + "</td><td><a class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' onclick='BindGP_Header(" + GP_HeaderID + ")' style='color: white;' class='la la-edit'></i> </a>  <a class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top'  title='Delete record'><i id='btnDeleteHeader' onclick='DeleteGP_Header(" + GP_HeaderID + ")' style='color: white;' class='la la-trash'></i> </a> </td></tr>";


                            }
                        }
                    }
                    if (ds.Tables.Count > 2)
                    {
                        Session["ds_GP_Type"] = ds;
                        bindGP_Type();
                        bindGP_Terms();
                    }
                }

                //if (ds.Tables.Count > 1)
                //{
                //    if (ds.Tables[1].Rows.Count > 0)
                //    {


                //    }
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

        public string bindGP_Type()
        {
            string data = "";
            DataSet ds_GP_Type = (DataSet)Session["ds_GP_Type"];

            if (ds_GP_Type.Tables[2].Rows.Count > 0)
            {
                int count = Convert.ToInt32(ds_GP_Type.Tables[2].Rows.Count);

                for (int i = 0; i < count; i++)
                {
                    string strSrNo = Convert.ToString(ds_GP_Type.Tables[2].Rows[i]["SrNo"]);
                    int GP_TypeID = Convert.ToInt32(ds_GP_Type.Tables[2].Rows[i]["GP_Type_ID"]);
                    string GP_Type = Convert.ToString(ds_GP_Type.Tables[2].Rows[i]["GP_Type_Desc"]);

                    data += "<tr><td>" + strSrNo + "</td><td>" + GP_Type + "</td><td><a class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' onclick='BindGP_Type(" + GP_TypeID + ")' style='color: white;' class='la la-edit'></i> </a>  <a class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top'  title='Delete record'><i id='btnDeleteHeader' onclick='DeleteGP_Type(" + GP_TypeID + ")' style='color: white;' class='la la-trash'></i> </a> </td></tr>";


                }
            }

            return data;
        }

        public string bindGP_Terms()
        {
            string data = "";
            DataSet ds_GP_Type = (DataSet)Session["ds_GP_Type"];

            if (ds_GP_Type.Tables[3].Rows.Count > 0)
            {
                int count = Convert.ToInt32(ds_GP_Type.Tables[3].Rows.Count);

                for (int i = 0; i < count; i++)
                {
                    string strSrNo = Convert.ToString(ds_GP_Type.Tables[3].Rows[i]["SrNo"]);
                    int GP_Terms_ID = Convert.ToInt32(ds_GP_Type.Tables[3].Rows[i]["GP_Terms_ID"]);
                    string Terms_Desc = Convert.ToString(ds_GP_Type.Tables[3].Rows[i]["Terms_Desc"]);

                    data += "<tr><td>" + strSrNo + "</td><td>" + Terms_Desc + "</td><td><a class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' onclick='BindGP_Term(" + GP_Terms_ID + ")' style='color: white;' class='la la-edit'></i> </a>  <a class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top'  title='Delete record'><i id='btnDeleteHeader' onclick='DeleteGP_Term(" + GP_Terms_ID + ")' style='color: white;' class='la la-trash'></i> </a> </td></tr>";


                }
            }

            return data;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
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
                bool ShowApprovalMatrix = false;
                string strGPClosureBy = string.Empty;

                strConfigTitle = txtTitle.Text.Trim();
                CompanyID = Convert.ToInt32(ddlCompany.SelectedValue);
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
                dsGatePassConfig = ObjUpkeep.Update_GatePassConfiguration(GP_ConfigID, strConfigTitle, CompanyID, strInitiator, LinkDepartment, strTransactionPrefix, strXmlApprovalMatrix.ToString(), ShowApprovalMatrix, strGPClosureBy, GatepassDescription, LoggedInUserID);

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
                            btnAddGPTerms.Focus();
                            lblErrorMsg.Text = "Title already exists";
                        }
                        else if (Status == 4)
                        {
                            btnAddGPTerms.Focus();
                            lblErrorMsg.Text = "Prefix already exists";
                        }
                        else if (Status == 2)
                        {
                            btnAddGPTerms.Focus();
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
            //Bind_GatePassConfiguration(GP_ConfigID);
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
            Bind_GatePassConfiguration(GP_ConfigID);
            Fetch_User_UserGroupList(Initiator);
        }

        protected void rptGatePassHeader_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void btnSaveGPHeader_Click(object sender, EventArgs e)
        {
            DataSet dsGatePassHeader = new DataSet();
            string strGPHeader = string.Empty;
            bool GPHeaderNumeric = false;
            int GPHeaderUnit = 0;
            int GatePassHeaderID = 0;
            string strAction = string.Empty;
            try
            {
                strGPHeader = Convert.ToString(txtGatepassHeader.Text.Trim());
                if (ChkNumeric.Checked == true)
                {
                    GPHeaderNumeric = true;
                }
                else
                {
                    GPHeaderNumeric = false;
                }
                GPHeaderUnit = Convert.ToInt32(ddlUnit.SelectedValue);
                if (Convert.ToString(Session["GPHeaderID"]) != "")
                {
                    GatePassHeaderID = Convert.ToInt32(Session["GPHeaderID"]);
                }
                if (GatePassHeaderID > 0)
                {
                    strAction = "U";
                }
                else
                {
                    strAction = "C";
                }

                dsGatePassHeader = ObjUpkeep.GatePassHeader_CRUD(GatePassHeaderID, strGPHeader, GPHeaderNumeric, GPHeaderUnit, GP_ConfigID, LoggedInUserID, strAction);
                if (dsGatePassHeader.Tables.Count > 0)
                {
                    if (dsGatePassHeader.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsGatePassHeader.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            Session["GPHeaderID"] = "";
                            txtGatepassHeader.Text = "";
                            ChkNumeric.Checked = false;
                            ddlUnit.SelectedValue = "0";
                            Response.Redirect(Page.ResolveClientUrl(Convert.ToString(Session["CurrentURL"])), false);
                            btnAddGPHeader.Focus();
                        }
                        else if (Status == 3)
                        {
                            lblGPHeaderErrorMsg.Text = "Gate Pass Header already exists";
                        }
                        else if (Status == 2)
                        {
                            lblGPHeaderErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCloseAddGPHeader_Click(object sender, EventArgs e)
        {
            Session["GPHeaderID"] = "";
            txtGatepassHeader.Text = "";
            ChkNumeric.Checked = false;
            ddlUnit.SelectedValue = "0";
            mpeGPHeader.Hide();
        }

        protected void btnBindGPHeader_Click(object sender, EventArgs e)
        {
            Session["GPHeaderID"] = Convert.ToString(hdnGPHeaderID.Value);
            int GatePassHeaderID = 0;
            DataSet dsGatePassHeader = new DataSet();
            DataSet dsDeleteGPHeader = new DataSet();
            try
            {
                if (Convert.ToString(Session["GPHeaderID"]) != "")
                {
                    hdnGPHeaderID.Value = "";
                    GatePassHeaderID = Convert.ToInt32(Session["GPHeaderID"]);
                    //bindChecklistPoint(ChecklistPointID);
                    dsGatePassHeader = ObjUpkeep.GatePassHeader_CRUD(GatePassHeaderID, "", false, 0, 0, LoggedInUserID, "R");

                    if (dsGatePassHeader.Tables.Count > 0)
                    {
                        if (dsGatePassHeader.Tables[0].Rows.Count > 0)
                        {
                            txtGatepassHeader.Text = Convert.ToString(dsGatePassHeader.Tables[0].Rows[0]["Header_Name"]);
                            int Is_Numeric = Convert.ToInt32(dsGatePassHeader.Tables[0].Rows[0]["Is_Numeric"]);
                            if (Is_Numeric == 1)
                            {
                                ChkNumeric.Checked = true;
                            }
                            else
                            {
                                ChkNumeric.Checked = false;
                            }

                            ddlUnit.SelectedValue = Convert.ToString(dsGatePassHeader.Tables[0].Rows[0]["Unit_ID"]);

                            mpeGPHeader.Show();
                        }
                    }
                }

                int DeleteGatePassHeaderID = 0;
                Session["DeleteGPHeaderID"] = Convert.ToString(hdnDeleteGPHeaderID.Value);
                if (Convert.ToString(Session["DeleteGPHeaderID"]) != "")
                {
                    DeleteGatePassHeaderID = Convert.ToInt32(Session["DeleteGPHeaderID"]);

                    dsDeleteGPHeader = ObjUpkeep.GatePassHeader_CRUD(DeleteGatePassHeaderID, "", false, 0, GP_ConfigID, LoggedInUserID, "D");
                    if (dsDeleteGPHeader.Tables.Count > 0)
                    {
                        if (dsDeleteGPHeader.Tables[0].Rows.Count > 0)
                        {
                            Session["DeleteGPHeaderID"] = "";
                            Session["GPHeaderID"] = "";
                            int Status = Convert.ToInt32(dsDeleteGPHeader.Tables[0].Rows[0]["Status"]);
                            if (Status == 1)
                            {
                                Response.Redirect(Page.ResolveClientUrl(Convert.ToString(Session["CurrentURL"])), false);
                                btnAddGPHeader.Focus();
                            }

                            else if (Status == 2)
                            {
                                lblGPHeaderErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnBindGPType_Click(object sender, EventArgs e)
        {
            Session["GPTypeID"] = Convert.ToString(hdnGPTypeID.Value);
            int GatePassTypeID = 0;
            DataSet dsGatePassType = new DataSet();
            DataSet dsDeleteGPType = new DataSet();
            try
            {
                if (Convert.ToString(Session["GPTypeID"]) != "")
                {
                    hdnGPTypeID.Value = "";
                    GatePassTypeID = Convert.ToInt32(Session["GPTypeID"]);

                    dsGatePassType = ObjUpkeep.GatePassType_CRUD(GatePassTypeID, "", 0, LoggedInUserID, "R");

                    if (dsGatePassType.Tables.Count > 0)
                    {
                        if (dsGatePassType.Tables[0].Rows.Count > 0)
                        {
                            txtGatePassType.Text = Convert.ToString(dsGatePassType.Tables[0].Rows[0]["GP_Type_Desc"]);

                            mpeGatePassType.Show();
                        }
                    }
                }

                int DeleteGatePassTypeID = 0;
                Session["DeleteGPTypeID"] = Convert.ToString(hdnDeleteGPTypeID.Value);
                if (Convert.ToString(Session["DeleteGPTypeID"]) != "")
                {
                    DeleteGatePassTypeID = Convert.ToInt32(Session["DeleteGPTypeID"]);

                    dsDeleteGPType = ObjUpkeep.GatePassType_CRUD(DeleteGatePassTypeID, "", 0, LoggedInUserID, "D");
                    if (dsDeleteGPType.Tables.Count > 0)
                    {
                        if (dsDeleteGPType.Tables[0].Rows.Count > 0)
                        {
                            Session["DeleteGPTypeID"] = "";
                            Session["GPTypeID"] = "";
                            int Status = Convert.ToInt32(dsDeleteGPType.Tables[0].Rows[0]["Status"]);
                            if (Status == 1)
                            {
                                Response.Redirect(Page.ResolveClientUrl(Convert.ToString(Session["CurrentURL"])), false);
                                btnAddGPHeader.Focus();
                            }


                        }
                    }
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnGPTypeCancel_Click(object sender, EventArgs e)
        {
            txtGatePassType.Text = "";
            Session["GPTypeID"] = "";
            mpeGatePassType.Hide();
        }

        protected void btnGPTypeSave_Click(object sender, EventArgs e)
        {
            DataSet dsGatePassType = new DataSet();
            string strGPType = string.Empty;
            int GatePassTypeID = 0;
            string strAction = string.Empty;
            try
            {
                if (Convert.ToString(Session["GPTypeID"]) != "")
                {
                    GatePassTypeID = Convert.ToInt32(Session["GPTypeID"]);
                }
                strGPType = Convert.ToString(txtGatePassType.Text.Trim());

                if (GatePassTypeID > 0)
                {
                    strAction = "U";
                }
                else
                {
                    strAction = "C";
                }

                dsGatePassType = ObjUpkeep.GatePassType_CRUD(GatePassTypeID, strGPType, GP_ConfigID, LoggedInUserID, strAction);
                if (dsGatePassType.Tables.Count > 0)
                {
                    if (dsGatePassType.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsGatePassType.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            Session["GPTypeID"] = "";
                            txtGatePassType.Text = "";
                            Response.Redirect(Page.ResolveClientUrl(Convert.ToString(Session["CurrentURL"])), false);
                            btnAddGPHeader.Focus();
                        }
                        else if (Status == 3)
                        {
                            lblErrorGPType.Text = "Gate Pass Type already exists";
                        }
                        else if (Status == 2)
                        {
                            lblErrorGPType.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnBindGPTerms_Click(object sender, EventArgs e)
        {
            Session["GPTermID"] = Convert.ToString(hdnGPTermID.Value);
            int GatePassTermID = 0;
            DataSet dsGatePassTerm = new DataSet();
            DataSet dsDeleteGPTerm = new DataSet();

            try
            {
                if (Convert.ToString(Session["GPTermID"]) != "")
                {
                    hdnGPTermID.Value = "";
                    GatePassTermID = Convert.ToInt32(Session["GPTermID"]);

                    dsGatePassTerm = ObjUpkeep.GatePassTerm_CRUD(GatePassTermID, "", 0, LoggedInUserID, "R");

                    if (dsGatePassTerm.Tables.Count > 0)
                    {
                        if (dsGatePassTerm.Tables[0].Rows.Count > 0)
                        {
                            txtTerms.Text = Convert.ToString(dsGatePassTerm.Tables[0].Rows[0]["Terms_Desc"]);

                            mpeGatePassTerm.Show();
                        }
                    }
                }

                int DeleteGatePassTermID = 0;
                Session["DeleteGPTermID"] = Convert.ToString(hdnDeleteGPTermID.Value);
                if (Convert.ToString(Session["DeleteGPTermID"]) != "")
                {
                    DeleteGatePassTermID = Convert.ToInt32(Session["DeleteGPTermID"]);

                    dsDeleteGPTerm = ObjUpkeep.GatePassTerm_CRUD(DeleteGatePassTermID, "", 0, LoggedInUserID, "D");
                    if (dsDeleteGPTerm.Tables.Count > 0)
                    {
                        if (dsDeleteGPTerm.Tables[0].Rows.Count > 0)
                        {
                            Session["DeleteGPTermID"] = "";
                            Session["GPTermID"] = "";
                            int Status = Convert.ToInt32(dsDeleteGPTerm.Tables[0].Rows[0]["Status"]);
                            if (Status == 1)
                            {
                                Response.Redirect(Page.ResolveClientUrl(Convert.ToString(Session["CurrentURL"])), false);
                                btnAddGPHeader.Focus();
                            }


                        }
                    }
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnCloseGatePassTerms_Click(object sender, EventArgs e)
        {
            Session["GPTermID"] = "";
            txtTerms.Text = "";
            mpeGatePassTerm.Hide();
        }

        protected void btnSaveGatePassTerms_Click(object sender, EventArgs e)
        {
            DataSet dsGatePassTerm = new DataSet();
            string strGPTerm = string.Empty;
            int GatePassTermID = 0;
            string strAction = string.Empty;
            try
            {
                if (Convert.ToString(Session["GPTermID"]) != "")
                {
                    GatePassTermID = Convert.ToInt32(Session["GPTermID"]);
                }
                strGPTerm = Convert.ToString(txtTerms.Text.Trim());

                if (GatePassTermID > 0)
                {
                    strAction = "U";
                }
                else
                {
                    strAction = "C";
                }

                dsGatePassTerm = ObjUpkeep.GatePassTerm_CRUD(GatePassTermID, strGPTerm, GP_ConfigID, LoggedInUserID, strAction);
                if (dsGatePassTerm.Tables.Count > 0)
                {
                    if (dsGatePassTerm.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsGatePassTerm.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            Session["GPTermID"] = "";
                            txtTerms.Text = "";
                            Response.Redirect(Page.ResolveClientUrl(Convert.ToString(Session["CurrentURL"])), false);
                            btnAddGPHeader.Focus();
                        }
                        else if (Status == 3)
                        {
                            lblErrorGPType.Text = "Gate Pass Terms already exists";
                        }
                        else if (Status == 2)
                        {
                            lblErrorGPType.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void AddRows(int NoOfLevels, DataSet dsApprovalMatrix)
        {
            int ctr = NoOfLevels;
            DataTable ObjDt = null;

            if (dsApprovalMatrix != null)
            {
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
                        LocTxtActionGroup.Width = 176;
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

        protected void rdbEmployee_CheckedChanged(object sender, EventArgs e)
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
            Bind_GatePassConfiguration(GP_ConfigID);
        }

        public void Delete_GatePassConfiguration(int ConfigID)
        {
            DataSet ds = new DataSet();

            try
            {
                ds = ObjUpkeep.Delete_GatePassConfiguration(ConfigID, LoggedInUserID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            Response.Redirect(Page.ResolveClientUrl("~/GatePass/GatePassConfig_Listing.aspx"), false);
                        }
                        else if (Status == 2)
                        {
                            Session["GPConfig_Not_Delete"] = "1";
                            Response.Redirect(Page.ResolveClientUrl("~/GatePass/GatePassConfig_Listing.aspx"), false);
                        }
                        
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