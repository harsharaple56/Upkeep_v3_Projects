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
using System.Text.RegularExpressions;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using System.Globalization;


namespace Upkeep_Gatepass_Workpermit.AssetManagement
{
    public partial class AssetManagementServiceRequest : System.Web.UI.Page
    {
        Upkeep_GP_WP_Services.Upkeep_GP_WP_Services ObjUpkeep = new Upkeep_GP_WP_Services.Upkeep_GP_WP_Services();

        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            int TransactionID = 0;
            int AssetID = 0;
            int ActionType = 0;
            ViewState["TransactionID"] = 0;
            ViewState["AssetID"] = 0;
            ViewState["ActionType"] = 0;
            if (Request.QueryString["TransactionID"] != null)
            {
                TransactionID = Convert.ToInt32(Request.QueryString["TransactionID"]);
                ViewState["TransactionID"] = TransactionID;
            }
            if (Request.QueryString["AssetID"] != null)
            {
                AssetID = Convert.ToInt32(Request.QueryString["AssetID"]);
                ViewState["AssetID"] = AssetID;
            }
            if (Request.QueryString["ActionType"] != null)
            {
                ActionType = Convert.ToInt32(Request.QueryString["ActionType"]);
                ViewState["ActionType"] = ActionType;
            }

            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);

           // LoggedInUserID = "3";
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }

            if (!IsPostBack)
            {

                //    if (System.Web.HttpContext.Current.Session["PreviousURL"] == null)
                //    {
                //        Session["PreviousURL"] = "~/WorkPermit/MyWorkPermit.aspx";
                //    }

                Fetch_Bind_DropDown();

                if (ActionType == 0) //ADD NEW SERVICES
                {
                    DivIsServiceSchedule.Attributes.Add("style", "display:none");
                    //DivAddServiceSchedule.Attributes.Add("style", "display:none");
                    divCloseRemarks.Attributes.Add("style", "display:none");
                }
                else if (ActionType == 1) // EDIT SERVICES
                {
                    //DivIsServiceSchedule.Attributes.Add("style", "display:none");
                    DivAddServiceSchedule.Attributes.Add("style", "display:none");
                    divCloseRemarks.Attributes.Add("style", "display:none");

                    btnSaveEdit.Attributes.Remove("style");
                    Button1.Attributes.Add("style", "display:none");
                }
                else if (ActionType == 2) //CLOSE SERVICES
                {
                    //DivIsServiceSchedule.Attributes.Add("style", "display:none");
                    DivAddServiceSchedule.Attributes.Add("style", "display:none");
                    divCloseRemarks.Attributes.Add("style", "display:none");

                    btnSaveEdit.Attributes.Remove("style");
                    Button1.Attributes.Add("style", "display:none");
                }
                 
                Session["TransactionID"] = 0; 
                Session["AssetID"] = Convert.ToString(AssetID);
                Session["ActionType"] = ActionType;

                if (TransactionID > 0)
                {
                    Session["TransactionID"] = Convert.ToString(TransactionID);
                    DisplayData(AssetID);
                }

            }

        }
        public void Fetch_Bind_DropDown()
        {
            DataSet dsTitle = new DataSet();
            string Initiator = string.Empty;
            try
            {
                dsTitle = ObjUpkeep.Fetch_Asset_DropDown(Convert.ToInt32(LoggedInUserID));
                ViewState["dsGlobalDropDownData"] = dsTitle.Copy();

                if (dsTitle.Tables[0].Rows.Count > 0)
                {
                    ddlAssetType.DataSource = dsTitle.Tables[0];
                    ddlAssetType.DataTextField = "Asset_Type_Desc";
                    ddlAssetType.DataValueField = "Asset_Type_ID";
                    ddlAssetType.DataBind();
                    ddlAssetType.Items.Insert(0, new ListItem("--Select--", "0"));
                }

                if (dsTitle.Tables[1].Rows.Count > 0)
                {
                    ddlAssetCategory.DataSource = dsTitle.Tables[1];
                    ddlAssetCategory.DataTextField = "Category_Desc";
                    ddlAssetCategory.DataValueField = "Asset_Category_ID";
                    ddlAssetCategory.DataBind();
                    ddlAssetCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                if (dsTitle.Tables[7].Rows.Count > 0)
                {
                    ddlServiceAssignTo.DataSource = dsTitle.Tables[7];
                    ddlServiceAssignTo.DataTextField = "Name";
                    ddlServiceAssignTo.DataValueField = "EmployeeID";
                    ddlServiceAssignTo.DataBind();
                    ddlServiceAssignTo.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                if (dsTitle.Tables[8].Rows.Count > 0)
                {
                    ddlAssetName.DataSource = dsTitle.Tables[8];
                    ddlAssetName.DataTextField = "Asset_Name";
                    ddlAssetName.DataValueField = "Asset_ID";
                    ddlAssetName.DataBind();
                    ddlAssetName.Items.Insert(0, new ListItem("--Select--", "0"));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DisplayData(int TransactionID)
        {

            DataSet dsAssestData = new DataSet();
            try
            {
                dsAssestData = ObjUpkeep.Fetch_ASSET_REQUEST_Details(LoggedInUserID, TransactionID);
                if (dsAssestData.Tables.Count > 0)
                {

                    if (dsAssestData.Tables[0].Rows.Count > 0)
                    {
                        ddlAssetType.SelectedValue = dsAssestData.Tables[0].Rows[0]["Asset_Type_ID"].ToString();
                        ddlAssetCategory.SelectedValue = dsAssestData.Tables[0].Rows[0]["Asset_Category_ID"].ToString();
                        txtAssetName.Text = dsAssestData.Tables[0].Rows[0]["Asset_Name"].ToString();
                        txtAssetDescription.Text = dsAssestData.Tables[0].Rows[0]["Asset_Desc"].ToString();
                    }

                    if (dsAssestData.Tables[4].Rows.Count > 0)
                    {
                        DataTable dtServ = new DataTable();
                        dtServ = dsAssestData.Tables[4].Copy();
                        dtServ.DefaultView.RowFilter = "Schedule_ID = '" + Convert.ToString((int)ViewState["TransactionID"]) + "'";
                        dtServ = dtServ.DefaultView.ToTable();
                        txtNoOfService.Value = Convert.ToString(dtServ.Rows.Count);

                        //Schedule_ID	Asset_ID	Service_Date	Alert_Date	Assigned_To	Service_Status	Created_By	Created_Date	
                        //Updated_By	Updated_Date	Is_Deleted	Remarks	Company_ID	Alert_Day 

                        if (dtServ.Rows.Count > 0)
                        {
                            ddlServiceAssignTo.SelectedValue = dtServ.Rows[0]["Assigned_To"].ToString();
                            txtServiceDate.Text = dtServ.Rows[0]["Service_Date"].ToString();
                            txtAlertDate.Text = dtServ.Rows[0]["Alert_Date"].ToString();
                            txtServiceRemarks.Text = dtServ.Rows[0]["Remarks"].ToString();
                            txtServiceClosingRemarks.Text = dtServ.Rows[0]["Remarks"].ToString();
                            txtServiceStatus.Text = dtServ.Rows[0]["Service_Status"].ToString();
                        }
                    }

                    if ((int)ViewState["ActionType"] == 1 || (int)ViewState["ActionType"] == 2)
                    {
                        if (txtServiceStatus.Text.ToLower() != "open" || (int)ViewState["ActionType"] == 2)
                        { 
                            Button1.Attributes.Add("disabled", "true");

                            if ((int)ViewState["ActionType"] == 2)
                            {
                                btnSaveEdit.Text = "Close";
                            }
                            else {
                                btnSaveEdit.Attributes.Add("disabled", "true");
                            }

                            btnNoOfService.Attributes.Add("disabled", "true");
                            TblLevels.Attributes.Add("disabled", "true");


                            ddlServiceAssignTo.Attributes.Add("disabled", "true");
                            txtServiceDate.Attributes.Add("disabled", "true");
                            txtAlertDate.Attributes.Add("disabled", "true");
                            txtServiceRemarks.Attributes.Add("disabled", "true");
                            txtServiceClosingRemarks.Attributes.Add("disabled", "true");
                            txtServiceStatus.Attributes.Add("disabled", "true");

                            ddlAssetType.Attributes.Add("disabled", "true");
                            ddlAssetCategory.Attributes.Add("disabled", "true");
                            txtAssetName.Attributes.Add("disabled", "true");
                            txtAssetDescription.Attributes.Add("disabled", "true");
                        }

                      

                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnNoOfService_Click(object sender, EventArgs e)
        {
            if (txtNoOfService.Value != "")
            {
                int NoOfLevels = Convert.ToInt32(txtNoOfService.Value);
                AddRows(NoOfLevels, null);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            int OutputStatus = 0;

            OutputStatus = ProcessData();

            //DISPLAY RESPONSE
            int Status = Convert.ToInt32(OutputStatus);
            if (Status == 1)
            {
                lblErrorMsg.Text = "Due to some technical issue, Request Cannot be Processed. Kindly try after some time";
            }
            else if (Status == 2)
            {
                lblWpRequestCode.Text = Convert.ToString(ViewState["RequestAssetID"]).ToString();
                mpeWpRequestSaveSuccess.Show();
            }
            else if (Status == 3)
            {
                lblErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
            }
            else
            {
                lblErrorMsg.Text = "Error Occured !!!";
            }
        }
        public int ProcessData()
        {
            int Status = 0;

            ViewState["RequestAssetID"] = "";
            DataSet ds = new DataSet();

            string strAssetServiceData = "";
            string strFlag = "";
            string strAssetID = ViewState["AssetID"].ToString();
            string strScheduleID = ViewState["TransactionID"].ToString();
            int iActionTy = 0;
            iActionTy = (int)ViewState["ActionType"];
            if (iActionTy == 0) //ADD NEW SERVICES
            {
                strAssetServiceData = AssetNewServiceData();
                if (strAssetServiceData == "")
                {
                    return 99;
                }
                strFlag = "INSERT";
                strAssetID = ddlAssetName.SelectedValue.ToString();
                strScheduleID = "";
            }
            else if (iActionTy == 1) //EDIT SERVICES
            {
                strAssetServiceData = AssetServiceData();
                if (strAssetServiceData == "")
                {
                    return 99;
                }
                strFlag = "UPDATE";
            }
            else if (iActionTy == 2) //CLOSE SERVICES
            {
                strAssetServiceData = "";
                strFlag = "CLOSE";
            }
            else
            {
                return 99;
            }

            ds = ObjUpkeep.CRUD_ASSET_SERVICE_REQUEST_DATA(LoggedInUserID, strAssetID, strScheduleID, strAssetServiceData, strFlag);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                    ViewState["RequestAssetID"] = Convert.ToString(ds.Tables[0].Rows[0]["RequestID"]);
                }
            }
            return Status;
        }


        #region Generate XML For Processing   
        private string AssetServiceData()
        {
            StringBuilder strXmlAsset = new StringBuilder();

            DateTime ServiceDate = DateTime.Parse(txtServiceDate.Text);
            DateTime AlertDate = DateTime.Parse(txtAlertDate.Text);
            int Alertdays = 0;
            Alertdays = (ServiceDate - AlertDate).Days;

            string f = ServiceDate.ToString("yyyy-MM-dd");


            strXmlAsset.Append(@"<Asset_Service_ROOT>");
            strXmlAsset.Append(@"<Asset_Service>");
            strXmlAsset.Append(@"<Asset_Service_Date>" + ServiceDate.ToString("yyyy-MM-dd") + "</Asset_Service_Date>");
            strXmlAsset.Append(@"<Asset_Service_AssignTo>" + ddlServiceAssignTo.SelectedValue.ToString() + "</Asset_Service_AssignTo>");
            strXmlAsset.Append(@"<Asset_Service_AlertBeforeDays>" + Alertdays.ToString() + "</Asset_Service_AlertBeforeDays>");
            strXmlAsset.Append(@"<Asset_Service_Remarks>" + txtServiceRemarks.Text + "</Asset_Service_Remarks>");
            strXmlAsset.Append(@"</Asset_Service>");
            strXmlAsset.Append(@"</Asset_Service_ROOT>");


            return strXmlAsset.ToString();
        }
        private string AssetNewServiceData()
        {
            StringBuilder strXmlAsset = new StringBuilder();

            if (txtHdn.Text != "")
            {
                strXmlAsset.Append(txtHdn.Text);
            }

            return strXmlAsset.ToString();
        }
        #endregion


        protected void btnSuccessOk_Click(object sender, EventArgs e)
        {
            if ((int)ViewState["ActionType"] == 2)
            {
                Response.Redirect(Page.ResolveClientUrl("~/AssetManagement/AssetManagementServiceCloseList.aspx"), false);
            }
            else
            {
                Response.Redirect(Page.ResolveClientUrl("~/AssetManagement/AssetManagementServiceList.aspx"), false);
            }
            
        }
         

        private void AddRows(int NoOfLevels, DataTable dtData)
        {
            int ctr = NoOfLevels;
            DataTable ObjDt = null;

            if (dtData != null)
            {
                ObjDt = dtData.Copy();
            }
            TblLevels.Visible = true;
            //TblSave.Visible = true;
            if (dtData == null)
            {
                try
                {
                    DataTable dtCopy = new DataTable();
                    DataSet dsData = new DataSet();
                    dsData = (DataSet)ViewState["dsGlobalDropDownData"];
                    dtCopy = dsData.Tables[7].Copy();

                    int IntPriCounter;
                    for (IntPriCounter = 0; IntPriCounter <= ctr - 1; IntPriCounter++)
                    {
                        this.TblLevels.Rows.Add(new HtmlTableRow());
                        this.TblLevels.Rows[IntPriCounter + 1].Attributes.Add("class", "data");

                        this.TblLevels.Rows[IntPriCounter + 1].ID = System.Convert.ToString(this.TblLevels.ID) + System.Convert.ToString(this.TblLevels.Rows.Count - 1);

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[0].InnerHtml = (IntPriCounter + 1).ToString();
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[0].Attributes.Add("class", "GridItem");

                        string sCellId = "Cell" + Convert.ToString(IntPriCounter + 1);

                        //this.TblLevels.Rows[IntPriCounter + 1].Cells[0].Attributes.Add("ID", ""+ sCellId+ IntPriCounter + "");


                        //this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        //// this.TblLevels.Rows[IntPriCounter + 1].Cells[1].Attributes.Add("class", "GridItem");
                        //System.Web.UI.WebControls.TextBox txtServiceDate = new System.Web.UI.WebControls.TextBox();
                        //txtServiceDate.Width = 176;
                        //txtServiceDate.Attributes.Add("class", "form-control m-input datepicker");
                        ////txtServiceDate.Attributes.Add("style", "display: inline");
                        //txtServiceDate.Attributes.Add("autocomplete", "off"); 

                        //System.Web.UI.HtmlControls.HtmlGenericControl createDiv =  new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                        //createDiv.Attributes.Add("class", "input-group date");
                        //createDiv.Controls.Add(txtServiceDate);

                        //this.TblLevels.Rows[IntPriCounter + 1].Cells[1].Controls.Add(createDiv);


                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[1].Attributes.Add("class", "GridItem");
                        System.Web.UI.HtmlControls.HtmlInputText txtServiceDate = new System.Web.UI.HtmlControls.HtmlInputText();
                        txtServiceDate.Attributes.Add("type", "date");
                        txtServiceDate.Attributes.Add("class", "form-control m-input");
                        txtServiceDate.Attributes.Add("style", "width: 250px");

                        txtServiceDate.Attributes.Add("ID", "" + sCellId + "1" + "");

                        this.TblLevels.Rows[IntPriCounter + 1].Cells[1].Controls.Add(txtServiceDate);


                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[2].Attributes.Add("class", "form-control m-input");
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[2].Attributes.Add("style", "width:25%");

                        System.Web.UI.WebControls.DropDownList LocTxtActionGroup = new System.Web.UI.WebControls.DropDownList();
                        //System.Web.UI.HtmlControls.HtmlImage LocImgBtnHelp = new System.Web.UI.HtmlControls.HtmlImage();

                        System.Web.UI.WebControls.HiddenField LocHdnAction = new System.Web.UI.WebControls.HiddenField();
                        // LocHdnAction.Style.Add("display", "none")
                        LocHdnAction.ID = "hdn2" + IntPriCounter;
                        LocTxtActionGroup.Width = 250;
                        LocTxtActionGroup.Attributes.Add("class", "form-control m-input");
                        LocTxtActionGroup.Attributes.Add("style", "display: inline");
                        LocTxtActionGroup.Attributes.Add("ID", "" + sCellId + "2" + "");


                        if (dtCopy.Rows.Count > 0)
                        {
                            LocTxtActionGroup.DataSource = dtCopy;
                            LocTxtActionGroup.DataTextField = "Name";
                            LocTxtActionGroup.DataValueField = "EmployeeID";
                            LocTxtActionGroup.DataBind();
                            LocTxtActionGroup.Items.Insert(0, new ListItem("--Select--", "0"));
                        }

                        this.TblLevels.Rows[IntPriCounter + 1].Cells[2].Controls.Add(LocTxtActionGroup);

                        //// ---------------ADD HELP BUTTON---------------------
                        ////LocImgBtnHelp.Src = "../generalimages/mypc_search.png";
                        //LocImgBtnHelp.Src = Page.ResolveClientUrl("~/assets/app/media/img/icons/AddUser.png");
                        //LocImgBtnHelp.Attributes.Add("width", "32");
                        //LocImgBtnHelp.Attributes.Add("height", "32");
                        ////LocImgBtnHelp.Style.Add("vertical-align", "bottom");
                        //LocImgBtnHelp.Attributes.Add("onclick", "PopUpGrid(" + LocTxtActionGroup.ClientID + ",'" + LocHdnAction.ClientID + "');");
                        //// ---------------------------------------------------------
                        //this.TblLevels.Rows[IntPriCounter + 1].Cells[2].Controls.Add(LocImgBtnHelp);
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[2].Controls.Add(LocHdnAction);

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[2].Attributes.Add("class", "GridItem");

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[3].Attributes.Add("class", "GridItem");

                        System.Web.UI.HtmlControls.HtmlInputText txtAlertDays = new System.Web.UI.HtmlControls.HtmlInputText();
                        txtAlertDays.Attributes.Add("type", "number");
                        txtAlertDays.Attributes.Add("min", "0");
                        txtAlertDays.Attributes.Add("max", "31");
                        txtAlertDays.Attributes.Add("class", "form-control m-input");
                        txtAlertDays.Attributes.Add("style", "width: 150px");
                        txtAlertDays.Attributes.Add("ID", "" + sCellId + "3" + "");
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[3].Controls.Add(txtAlertDays);


                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[4].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.TextBox txtServiceRemarks = new System.Web.UI.WebControls.TextBox();
                        txtServiceRemarks.Attributes.Add("class", "form-control m-input");
                        txtServiceRemarks.Attributes.Add("style", "width: 250px");
                        txtServiceRemarks.Attributes.Add("ID", "" + sCellId + "4" + "");
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[4].Controls.Add(txtServiceRemarks);

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[5].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.TextBox txtServiceStatus = new System.Web.UI.WebControls.TextBox();
                        txtServiceStatus.Attributes.Add("class", "form-control m-input");
                        txtServiceStatus.Attributes.Add("style", "width: 100px");
                        txtServiceStatus.ReadOnly = true;
                        txtServiceStatus.Text = "Open";
                        txtServiceStatus.Attributes.Add("ID", "" + sCellId + "5" + "");
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[5].Controls.Add(txtServiceStatus);


                        System.Web.UI.WebControls.TextBox LocTxtInf = new System.Web.UI.WebControls.TextBox();
                        System.Web.UI.HtmlControls.HtmlImage LocImgBtnHelp1 = new System.Web.UI.HtmlControls.HtmlImage();

                        System.Web.UI.WebControls.HiddenField LocHdnInf = new System.Web.UI.WebControls.HiddenField();
                        // LocHdnInf.Style.Add("display", "none")
                        LocHdnInf.ID = "hdn3" + IntPriCounter;
                        LocTxtInf.Width = 150;
                        LocTxtInf.ReadOnly = true;
                    }

                    ViewState["dynamictable"] = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

                try
                {
                    DataTable dtCopy = new DataTable();
                    DataSet dsData = new DataSet();
                    dsData = (DataSet)ViewState["dsGlobalDropDownData"];
                    dtCopy = dsData.Tables[7].Copy();

                    int IntPriCounter;
                    for (IntPriCounter = 0; IntPriCounter <= ctr - 1; IntPriCounter++)
                    {
                        string Service_Date = "";
                        string Assigned_To = "";
                        string AlertDays = "";
                        string Remarks = "";
                        string Service_Status = "";

                        Service_Date = ObjDt.Rows[IntPriCounter]["Service_Date"].ToString();
                        Assigned_To = ObjDt.Rows[IntPriCounter]["Assigned_To"].ToString();
                        AlertDays = ObjDt.Rows[IntPriCounter]["Alert_Day"].ToString();
                        Remarks = ObjDt.Rows[IntPriCounter]["Remarks"].ToString();
                        Service_Status = ObjDt.Rows[IntPriCounter]["Service_Status"].ToString();

                        this.TblLevels.Rows.Add(new HtmlTableRow());
                        this.TblLevels.Rows[IntPriCounter + 1].Attributes.Add("class", "data");

                        this.TblLevels.Rows[IntPriCounter + 1].ID = System.Convert.ToString(this.TblLevels.ID) + System.Convert.ToString(this.TblLevels.Rows.Count - 1);

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[0].InnerHtml = (IntPriCounter + 1).ToString();
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[0].Attributes.Add("class", "GridItem");

                        string sCellId = "Cell" + Convert.ToString(IntPriCounter + 1);

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[1].Attributes.Add("class", "GridItem");
                        System.Web.UI.HtmlControls.HtmlInputText txtServiceDate = new System.Web.UI.HtmlControls.HtmlInputText();
                        txtServiceDate.Attributes.Add("type", "text");
                        txtServiceDate.Attributes.Add("class", "form-control m-input");
                        txtServiceDate.Attributes.Add("style", "width: 250px");
                        txtServiceDate.Attributes.Add("ID", "" + sCellId + "1" + "");

                        txtServiceDate.Value = Service_Date;

                        this.TblLevels.Rows[IntPriCounter + 1].Cells[1].Controls.Add(txtServiceDate);

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[2].Attributes.Add("class", "form-control m-input");
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[2].Attributes.Add("style", "width:25%");

                        System.Web.UI.WebControls.DropDownList LocTxtActionGroup = new System.Web.UI.WebControls.DropDownList();

                        System.Web.UI.WebControls.HiddenField LocHdnAction = new System.Web.UI.WebControls.HiddenField();
                        LocHdnAction.ID = "hdn2" + IntPriCounter;
                        LocTxtActionGroup.Width = 250;
                        LocTxtActionGroup.Attributes.Add("class", "form-control m-input");
                        LocTxtActionGroup.Attributes.Add("style", "display: inline");
                        LocTxtActionGroup.Attributes.Add("ID", "" + sCellId + "2" + "");


                        if (dtCopy.Rows.Count > 0)
                        {
                            LocTxtActionGroup.DataSource = dtCopy;
                            LocTxtActionGroup.DataTextField = "Name";
                            LocTxtActionGroup.DataValueField = "EmployeeID";
                            LocTxtActionGroup.DataBind();
                            LocTxtActionGroup.Items.Insert(0, new ListItem("--Select--", "0"));
                        }

                        LocTxtActionGroup.SelectedValue = Assigned_To;

                        this.TblLevels.Rows[IntPriCounter + 1].Cells[2].Controls.Add(LocTxtActionGroup);

                        this.TblLevels.Rows[IntPriCounter + 1].Cells[2].Controls.Add(LocHdnAction);

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[2].Attributes.Add("class", "GridItem");

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[3].Attributes.Add("class", "GridItem");

                        System.Web.UI.HtmlControls.HtmlInputText txtAlertDays = new System.Web.UI.HtmlControls.HtmlInputText();
                        txtAlertDays.Attributes.Add("type", "number");
                        txtAlertDays.Attributes.Add("min", "0");
                        txtAlertDays.Attributes.Add("max", "31");
                        txtAlertDays.Attributes.Add("class", "form-control m-input");
                        txtAlertDays.Attributes.Add("style", "width: 150px");
                        txtAlertDays.Attributes.Add("ID", "" + sCellId + "3" + "");
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[3].Controls.Add(txtAlertDays);

                        txtAlertDays.Value = AlertDays;

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[4].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.TextBox txtServiceRemarks = new System.Web.UI.WebControls.TextBox();
                        txtServiceRemarks.Attributes.Add("class", "form-control m-input");
                        txtServiceRemarks.Attributes.Add("style", "width: 250px");
                        txtServiceRemarks.Attributes.Add("ID", "" + sCellId + "4" + "");
                        txtServiceRemarks.Text = Remarks;
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[4].Controls.Add(txtServiceRemarks);

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[5].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.TextBox txtServiceStatus = new System.Web.UI.WebControls.TextBox();
                        txtServiceStatus.Attributes.Add("class", "form-control m-input");
                        txtServiceStatus.Attributes.Add("style", "width: 100px");
                        txtServiceStatus.ReadOnly = true;
                        txtServiceStatus.Attributes.Add("ID", "" + sCellId + "5" + "");
                        txtServiceStatus.Text = Service_Status;
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[5].Controls.Add(txtServiceStatus);


                        System.Web.UI.WebControls.TextBox LocTxtInf = new System.Web.UI.WebControls.TextBox();
                        System.Web.UI.HtmlControls.HtmlImage LocImgBtnHelp1 = new System.Web.UI.HtmlControls.HtmlImage();

                        System.Web.UI.WebControls.HiddenField LocHdnInf = new System.Web.UI.WebControls.HiddenField();
                        // LocHdnInf.Style.Add("display", "none")
                        LocHdnInf.ID = "hdn3" + IntPriCounter;
                        LocTxtInf.Width = 150;
                        LocTxtInf.ReadOnly = true;
                    }

                    ViewState["dynamictable"] = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}