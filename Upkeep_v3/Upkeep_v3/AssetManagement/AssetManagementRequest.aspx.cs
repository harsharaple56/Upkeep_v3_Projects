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
using System.Net.Http.Formatting;

namespace Upkeep_v3.AssetManagement
{
    public partial class AssetManagementRequest : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();

        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            int TransactionID = 0;
            ViewState["TransactionID"] = 0;
            if (Request.QueryString["TransactionID"] != null)
            {
                TransactionID = Convert.ToInt32(Request.QueryString["TransactionID"]);
                ViewState["TransactionID"] = TransactionID;

            }

            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);


            //LoggedInUserID = "3";
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
                Fetch_Custom_Fields();

                Session["TransactionID"] = 0;
                if (TransactionID > 0)
                {
                    Session["TransactionID"] = Convert.ToString(TransactionID);
                    DisplayData(TransactionID);
                }
            }

        }
        public void Fetch_Bind_DropDown()
        {
            DataSet dsTitle = new DataSet();
            string Initiator = string.Empty;
            try
            {
                dsTitle = ObjUpkeep.Fetch_Asset_DropDown(Convert.ToInt32(LoggedInUserID),CompanyID);
                ViewState["dsGlobalDropDownData"] = dsTitle.Copy();

                if (dsTitle.Tables.Count > 0)
                {
                    if (dsTitle.Tables[0].Rows.Count > 0)
                    {
                        ddlAssetType.DataSource = dsTitle.Tables[0];
                        ddlAssetType.DataTextField = "Asset_Type_Desc";
                        ddlAssetType.DataValueField = "Asset_Type_ID";
                        ddlAssetType.DataBind();
                        ddlAssetType.Items.Insert(0, new ListItem("--Select--", "0"));


                        ddlModalAssetType.DataSource = dsTitle.Tables[0];
                        ddlModalAssetType.DataTextField = "Asset_Type_Desc";
                        ddlModalAssetType.DataValueField = "Asset_Type_ID";
                        ddlModalAssetType.DataBind();
                        ddlModalAssetType.Items.Insert(0, new ListItem("--Select--", "0"));

                    }

                    //if (dsTitle.Tables[1].Rows.Count > 0)
                    //{
                    //    ddlAssetCategory.DataSource = dsTitle.Tables[1];
                    //    ddlAssetCategory.DataTextField = "Category_Desc";
                    //    ddlAssetCategory.DataValueField = "Asset_Category_ID";
                    //    ddlAssetCategory.DataBind();
                    //    ddlAssetCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                    //}

                    if (dsTitle.Tables[2].Rows.Count > 0)
                    {

                        ddlAssetVendor.DataSource = dsTitle.Tables[2];
                        ddlAssetVendor.DataTextField = "Vendor_Name";
                        ddlAssetVendor.DataValueField = "Vendor_ID";
                        ddlAssetVendor.DataBind();
                        ddlAssetVendor.Items.Insert(0, new ListItem("--Select--", "0"));

                        var builder = new System.Text.StringBuilder();


                        for (int i = 0; i < dsTitle.Tables[2].Rows.Count; i++)
                        {
                            builder.Append(String.Format("<option value='{0}' text='{1}'>", dsTitle.Tables[2].Rows[i]["Vendor_Name"], dsTitle.Tables[2].Rows[i]["Vendor_ID"]));
                        }
                        dlamcassigVendor.InnerHtml = builder.ToString();
                        dlamcassigVendor.DataBind();
                        dlamcassigVendor.DataBind();


                    }

                    if (dsTitle.Tables[3].Rows.Count > 0)
                    {
                        ddlDepartment.DataSource = dsTitle.Tables[3];
                        ddlDepartment.DataTextField = "Dept_Desc";
                        ddlDepartment.DataValueField = "Department_ID";
                        ddlDepartment.DataBind();
                        ddlDepartment.Items.Insert(0, new ListItem("--Select--", "0"));
                    }

                    if (dsTitle.Tables[4].Rows.Count > 0)
                    {
                        //ddlLocation.DataSource = dsTitle.Tables[4];
                        //ddlLocation.DataTextField = "Loc_Desc";
                        //ddlLocation.DataValueField = "Loc_id";
                        //ddlLocation.DataBind();
                        //ddlLocation.Items.Insert(0, new ListItem("--Select--", "0"));


                        var builder = new System.Text.StringBuilder();

                        for (int i = 0; i < dsTitle.Tables[4].Rows.Count; i++)
                        {
                            builder.Append(String.Format("<option value='{0}' text='{1}'>", dsTitle.Tables[4].Rows[i]["Loc_Desc"], dsTitle.Tables[4].Rows[i]["Loc_id"]));
                        }
                        dlassetLocation.InnerHtml = builder.ToString();
                        dlassetLocation.DataBind();


                    }

                    if (dsTitle.Tables[5].Rows.Count > 0)
                    {
                        ddlAmcType.DataSource = dsTitle.Tables[5];
                        ddlAmcType.DataTextField = "Asset_AMC_Type_Desc";
                        ddlAmcType.DataValueField = "Asset_AMC_Type_ID";
                        ddlAmcType.DataBind();
                        ddlAmcType.Items.Insert(0, new ListItem("--Select--", "0"));
                    }

                    if (dsTitle.Tables[6].Rows.Count > 0)
                    {
                        ddlCurrencyType.DataSource = dsTitle.Tables[6];
                        ddlCurrencyType.DataTextField = "Currency_Code";
                        ddlCurrencyType.DataValueField = "Currency_Code";
                        ddlCurrencyType.DataBind();
                        ddlCurrencyType.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Fetch_Custom_Fields()
        {
            DataSet dsSetting = new DataSet();
            try
            {
                dsSetting = ObjUpkeep.Fetch_Asset_Custom_Fields(CompanyID);
                if (dsSetting.Tables.Count > 0)
                {
                    if (dsSetting.Tables[0].Rows.Count > 0)
                    {
                        Session["CustomeFields"] = "True";
                        rptCustomFields.DataSource = dsSetting.Tables[0];
                        rptCustomFields.DataBind();
                          
                    }
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

                    //Asset_ID Asset_Type_ID   Asset_Category_ID Asset_Name  Asset_Desc Asset_Make  Asset_Serial_No Vendor_ID 
                    //    Department_ID Loc_id  Asset_Cost Currency_Type   Asset_Images Asset_Videos    Asset_Docs Asset_Purchase_Date 
                    //    Asset_Is_AMC_Active Created_By  Created_Date Updated_By  Updated_Date Is_Deleted  Company_ID


                    if (dsAssestData.Tables[0].Rows.Count > 0)
                    {
                        ddlAssetType.SelectedValue = dsAssestData.Tables[0].Rows[0]["Asset_Type_ID"].ToString();

                        //comment
                        DataTable dt = new DataTable();
                        DataTable dtCopy = new DataTable();
                        DataSet dsGlobalDropDownData = new DataSet();
                        dsGlobalDropDownData = (DataSet)ViewState["dsGlobalDropDownData"];
                        dt = dsGlobalDropDownData.Tables[1].Copy();

                        if (dt.Rows.Count > 0)
                        {
                            dtCopy = dt.Copy();
                            dtCopy.DefaultView.RowFilter = "Asset_Type_ID = '" + ddlAssetType.SelectedValue.ToString() + "'";
                            dtCopy.DefaultView.ToTable();

                            ddlAssetCategory.DataSource = dtCopy;
                            ddlAssetCategory.DataTextField = "Category_Desc";
                            ddlAssetCategory.DataValueField = "Asset_Category_ID";
                            ddlAssetCategory.DataBind();
                            ddlAssetCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                        }

                        ddlAssetCategory.SelectedValue = dsAssestData.Tables[0].Rows[0]["Asset_Category_ID"].ToString();
                        txtAssetName.Text = dsAssestData.Tables[0].Rows[0]["Asset_Name"].ToString();
                        txtAssetDescription.Text = dsAssestData.Tables[0].Rows[0]["Asset_Desc"].ToString();
                        txtAssetMaker.Text = dsAssestData.Tables[0].Rows[0]["Asset_Make"].ToString();
                        txtAssetSerialNo.Text = dsAssestData.Tables[0].Rows[0]["Asset_Serial_No"].ToString();
                        ddlAssetVendor.SelectedValue = dsAssestData.Tables[0].Rows[0]["Vendor_ID"].ToString();
                        ddlDepartment.SelectedValue = dsAssestData.Tables[0].Rows[0]["Department_ID"].ToString();
                        txtassetLocation.Value = dsAssestData.Tables[0].Rows[0]["Loc_Desc"].ToString();
                        hdnassetLocation.Value = dsAssestData.Tables[0].Rows[0]["Loc_id"].ToString();
                        txtAssetCost.Value = dsAssestData.Tables[0].Rows[0]["Asset_Cost"].ToString();
                        ddlCurrencyType.SelectedValue = dsAssestData.Tables[0].Rows[0]["Currency_Type"].ToString();
                        txtAssetPurchaseDate.Text = dsAssestData.Tables[0].Rows[0]["Asset_Purchase_Date"].ToString();


                        foreach (RepeaterItem item in rptCustomFields.Items)
                        {
                            (rptCustomFields.Items[item.ItemIndex].FindControl("txtCustomFieldsValue") as TextBox).Text = dsAssestData.Tables[0].Rows[item.ItemIndex]["Asset_Field_Value"].ToString();
                        }


                        if (dsAssestData.Tables[1].Rows.Count > 0)
                        {
                            DataTable dtImg = new DataTable();
                            DataTable dtVid = new DataTable();
                            DataTable dtDoc = new DataTable();


                            dtImg = dsAssestData.Tables[1].Copy();
                            dtVid = dsAssestData.Tables[1].Copy();
                            dtDoc = dsAssestData.Tables[1].Copy();

                            dtImg.DefaultView.RowFilter = "Asset_Doc_Type = '" + "IMAGE" + "' ";
                            dtImg = dtImg.DefaultView.ToTable();
                            if (dtImg.Rows.Count > 0)
                            {
                                hdnAssetImg.Value = dtImg.Rows[0]["ImagePath"].ToString();
                            }
                            else { hdnAssetImg.Value = ""; }

                            dtVid.DefaultView.RowFilter = "Asset_Doc_Type = '" + "VIDEO" + "' ";
                            dtVid = dtVid.DefaultView.ToTable();
                            if (dtVid.Rows.Count > 0)
                            {
                                hdnAssetVid.Value = dtVid.Rows[0]["ImagePath"].ToString();
                            }
                            else { hdnAssetVid.Value = ""; }

                            dtDoc.DefaultView.RowFilter = "Asset_Doc_Type = '" + "DOC" + "' ";
                            dtDoc = dtDoc.DefaultView.ToTable();
                            if (dtDoc.Rows.Count > 0)
                            {
                                hdnAssetDoc.Value = dtDoc.Rows[0]["ImagePath"].ToString();
                            }
                            else { hdnAssetDoc.Value = ""; }
                        }

                    }

                    if (dsAssestData.Tables[2].Rows.Count > 0)
                    {
                        //Asset_AMC_ID Asset_AMC_Type_ID   Company_ID Asset_ID    AMC_Desc AMC_Start_Date  
                        //AMC_End_Date Assigned_Vendor AMC_Inclusions AMC_Exclusions  Additional Remarks  AMC_Docs AMC_Status

                        customCheck.Checked = true;
                        ddlAmcType.SelectedValue = dsAssestData.Tables[2].Rows[0]["Asset_AMC_Type_ID"].ToString();
                        txtAmcDescription.Text = dsAssestData.Tables[2].Rows[0]["AMC_Desc"].ToString();
                        txtAmcStartDate.Text = dsAssestData.Tables[2].Rows[0]["AMC_Start_Date"].ToString();
                        txtAmcEndDate.Text = dsAssestData.Tables[2].Rows[0]["AMC_End_Date"].ToString();
                        txtamcassigVendor.Value = dsAssestData.Tables[2].Rows[0]["Vendor_Name"].ToString();
                        hfAmcAssignedVendor.Value = dsAssestData.Tables[2].Rows[0]["Assigned_Vendor"].ToString();
                        txtAmcInclusion.Text = dsAssestData.Tables[2].Rows[0]["AMC_Inclusions"].ToString();
                        txtAmcExclusion.Text = dsAssestData.Tables[2].Rows[0]["AMC_Exclusions"].ToString();
                        txtAmcRemarks.Text = dsAssestData.Tables[2].Rows[0]["Additional Remarks"].ToString();
                        txtAmcStatus.Text = dsAssestData.Tables[2].Rows[0]["AMC_Status"].ToString();

                        //customCheck.Disabled = true;
                        //ddlAmcType.Enabled = false;
                        //txtAmcDescription.Enabled = false;
                        //txtAmcStartDate.Enabled = false;
                        //txtAmcEndDate.Enabled = false;
                        //txtamcassigVendor.Disabled = true;
                        //txtAmcInclusion.Enabled = false;
                        //txtAmcExclusion.Enabled = false;
                        //txtAmcRemarks.Enabled = false;
                        //txtAmcStatus.Enabled = false;
                        //flAmcDoc.Enabled = false;





                        if (dsAssestData.Tables[3].Rows.Count > 0)
                        {
                            //string FilPath = "";
                            //FilPath = UploadFile(postfiles, "AmcDoc", ddlAssetType.SelectedItem.ToString(), txtAssetName.Text.ToString());
                            //strXmlAsset.Append(@"<Asset_AMC_Doc_Data>");
                            //strXmlAsset.Append(@"<Asset_AMC_Doc_Path>" + FilPath.ToString() + "</Asset_AMC_Doc_Path>");
                            //strXmlAsset.Append(@"</Asset_AMC_Doc_Data>");
                            //if (dsAssestData.Tables[3].Rows.Count > 0)

                            HdnAmcDoc.Value = dsAssestData.Tables[3].Rows[0]["ImagePath"].ToString();
                        }

                    }

                    if (dsAssestData.Tables[4].Rows.Count > 0)
                    {
                        customCheck1.Checked = true;
                        txtNoOfService.Value = Convert.ToString(dsAssestData.Tables[4].Rows.Count);

                        //Schedule_ID Asset_ID    Service_Date Alert_Date  Assigned_To Service_Status  Created_By Created_Date   
                        //Updated_By Updated_Date    Is_Deleted Remarks Company_ID
                        AddRows(dsAssestData.Tables[4].Rows.Count, dsAssestData.Tables[4].Copy());

                    }

                }

                //AMC
                customCheck.Attributes.Add("disabled", "true");
                ddlAmcType.Attributes.Add("disabled", "true");
                txtAmcDescription.Attributes.Add("disabled", "true");
                txtAmcStartDate.Attributes.Add("disabled", "true");
                txtAmcEndDate.Attributes.Add("disabled", "true");
                txtamcassigVendor.Attributes.Add("disabled", "true");
                txtAmcInclusion.Attributes.Add("disabled", "true");
                txtAmcExclusion.Attributes.Add("disabled", "true");
                txtAmcRemarks.Attributes.Add("disabled", "true");
                txtAmcStatus.Attributes.Add("disabled", "true");
                flAmcDoc.Attributes.Add("disabled", "true");

                //SERVICE
                customCheck1.Attributes.Add("disabled", "true");
                txtNoOfService.Attributes.Add("disabled", "true");
                btnNoOfService.Attributes.Add("disabled", "true");
                TblLevels.Attributes.Add("disabled", "true");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlAssetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dtCopy = new DataTable();
            DataSet dsGlobalDropDownData = new DataSet();
            dsGlobalDropDownData = (DataSet)ViewState["dsGlobalDropDownData"];
            dt = dsGlobalDropDownData.Tables[1].Copy();

            if (dt.Rows.Count > 0)
            {
                dtCopy = dt.Copy();
                dtCopy.DefaultView.RowFilter = "Asset_Type_ID = '" + ddlAssetType.SelectedValue.ToString() + "'";
                dtCopy.DefaultView.ToTable();

                ddlAssetCategory.DataSource = dtCopy;
                ddlAssetCategory.DataTextField = "Category_Desc";
                ddlAssetCategory.DataValueField = "Asset_Category_ID";
                ddlAssetCategory.DataBind();
                ddlAssetCategory.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
        //protected void ddlAssetVendor_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlAssetVendor.SelectedIndex > 0)
        //    {
        //        txtamcassigVendor.Value = ddlAssetVendor.SelectedItem.ToString();
        //        hfAmcAssignedVendor.Value = ddlAssetVendor.SelectedValue.ToString();
        //    }
        //}

        protected void btnNoOfService_Click(object sender, EventArgs e)
        {
            if (txtNoOfService.Value != "")
            {
                int NoOfLevels = Convert.ToInt32(txtNoOfService.Value);
                AddRows(NoOfLevels, null);
            }
        }

        public bool ValidateData(string Flag)
        {
            //DO VALIDATIONS HERE
            if (Flag == "Insert") { }
            else if (Flag == "Update") { }
            else
            {
                return false;
            }
            return true;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //SET FLAG
            string CRUD_Flag = "";
            if ((int)ViewState["TransactionID"] == 0)
                CRUD_Flag = "Insert";
            else
                CRUD_Flag = "Update";

            //CHECK VALIDATION
            if (ValidateData(CRUD_Flag) == false)
                return;


            //PROCESS DATA
            int OutputStatus = 0;
            if ((int)ViewState["TransactionID"] == 0)
            {
                OutputStatus = InsertData();
                if (OutputStatus == 99)
                {
                    lblErrorMsg.Text = "Missing Service Data";
                    return;
                }
            }
            else
                OutputStatus = UpdateData();


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
        public int InsertData()
        {
            int Status = 0;

            ViewState["RequestAssetID"] = "";
            DataSet ds = new DataSet();
            //dsWPHeaderData = ObjUpkeep.Insert_WorkPermitRequest(LoggedInUserID);

            string strAssetData = "";
            strAssetData = AssetData(0, "Insert");

            string strAssetAMCData = "";
            if (customCheck.Checked == true)
                strAssetAMCData = AssetAMCData(0);

            string strAssetServiceData = "";
            if (customCheck1.Checked == true)
            {
                strAssetServiceData = AssetServiceData();
                if (strAssetServiceData == "")
                {
                    return 99;
                }
            }
            ds = ObjUpkeep.INSERT_ASSET_REQUEST_Details(LoggedInUserID, strAssetData, strAssetAMCData, strAssetServiceData);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                    ViewState["RequestAssetID"] = Convert.ToString(ds.Tables[0].Rows[0]["RequestID"]);
                }
            }

            //Save Data of Custome Field

            if (Convert.ToString(Session["CustomeFields"]) == "True")
            {

                foreach (RepeaterItem item in rptCustomFields.Items)
                {
                    StringBuilder strXmlCustomFields = new StringBuilder();
                    string CustomFields_XML = string.Empty;
                    strXmlCustomFields.Append(@"<?xml version=""1.0"" ?>");
                    strXmlCustomFields.Append(@"<CustomFields>");
                    string FieldID = Convert.ToString((item.FindControl("hdnFieldID") as HiddenField).Value);
                    string CustomFieldsValue = Convert.ToString((item.FindControl("txtCustomFieldsValue") as TextBox).Text);

                    strXmlCustomFields.Append(@"<FieldID>" + FieldID + "</FieldID>");
                    strXmlCustomFields.Append(@"<CustomFieldsValue>" + CustomFieldsValue + "</CustomFieldsValue>");
                    strXmlCustomFields.Append(@"</CustomFields>");

                    CustomFields_XML = strXmlCustomFields.ToString();
                    ObjUpkeep.INSERT_ASSET_CUSTOMFIELD_REQUEST_Details(LoggedInUserID, CustomFields_XML, Convert.ToInt32(ds.Tables[0].Rows[0]["RequestID"]));
                }

            }




            return Status;
        }
        public int UpdateData()
        {
            int Status = 0;
            ViewState["RequestAssetID"] = "";
            DataSet ds = new DataSet();
            //dsWPHeaderData = ObjUpkeep.Insert_WorkPermitRequest(LoggedInUserID);

            string strAssetData = "";
            strAssetData = AssetData((int)ViewState["TransactionID"], "Update");

            string strAssetAMCData = "";
            //if (customCheck.Checked == true)
            //    strAssetAMCData = AssetAMCData((int)ViewState["TransactionID"]);

            string strAssetServiceData = "";
            //if (customCheck1.Checked == true)
            //    strAssetServiceData = AssetServiceData();

            ds = ObjUpkeep.UPDATE_ASSET_REQUEST_Details(LoggedInUserID, Convert.ToString((int)ViewState["TransactionID"]), strAssetData, strAssetAMCData, strAssetServiceData);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                    ViewState["RequestAssetID"] = Convert.ToString(ds.Tables[0].Rows[0]["RequestID"]);
                }
            }

            //Update Data of Custome Field

            if (Convert.ToString(Session["CustomeFields"]) == "True")
            {

                foreach (RepeaterItem item in rptCustomFields.Items)
                {
                    StringBuilder strXmlCustomFields = new StringBuilder();
                    string CustomFields_XML = string.Empty;
                    strXmlCustomFields.Append(@"<?xml version=""1.0"" ?>");
                    strXmlCustomFields.Append(@"<CustomFields>");
                    string FieldID = Convert.ToString((item.FindControl("hdnFieldID") as HiddenField).Value);
                    string CustomFieldsValue = Convert.ToString((item.FindControl("txtCustomFieldsValue") as TextBox).Text);

                    strXmlCustomFields.Append(@"<FieldID>" + FieldID + "</FieldID>");
                    strXmlCustomFields.Append(@"<CustomFieldsValue>" + CustomFieldsValue + "</CustomFieldsValue>");
                    strXmlCustomFields.Append(@"</CustomFields>");

                    CustomFields_XML = strXmlCustomFields.ToString();
                    ObjUpkeep.UPDATE_ASSET_CUSTOMFIELD_REQUEST_Details(LoggedInUserID, CustomFields_XML, (int)ViewState["TransactionID"]);
                }

            }

            return Status;
        }

        public string UploadFile(HttpPostedFile FileUploaderFile, string FileType, string AssetType, string AssetName)
        {
            string FilePath = "";
            try
            {
                HttpPostedFile file = FileUploaderFile;

                string CurrentDate = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));
                string CurrentDates = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy hhmmss"));
                string fileUploadPath = HttpContext.Current.Server.MapPath("~/AssetMangDocs/" + FileType + "/" + CurrentDate);
                if (!Directory.Exists(fileUploadPath))
                {
                    Directory.CreateDirectory(fileUploadPath);
                }

                //check file was submitted
                if (file != null && file.ContentLength > 0)
                {
                    string filetypea = Path.GetExtension(file.FileName);

                    string ImageName = Path.GetFileName(file.FileName);
                    string fileName = AssetType.ToString().Replace(" ", "") + "_" + AssetName.ToString().Replace(" ", "") + "_" + CurrentDates + "_" + ImageName;
                    string imgPath = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadURL"]);
                    string SaveLocation = Server.MapPath("~/AssetMangDocs/" + FileType + "/" + CurrentDate) + "/" + fileName;
                    string FileLocation = imgPath + "/AssetMangDocs/" + FileType + "/" + CurrentDate + "/" + fileName;// + "*WP";
                    var targetFile = SaveLocation;
                    file.SaveAs(SaveLocation);

                    FilePath = FileLocation;
                }
                return FilePath;
            }
            catch (Exception ex)
            {
                //throw ex;
                return "";
            }
        }

        #region Generate XML For Processing 
        private string AssetData(int AsseetID, string sIU_Type)
        {
            StringBuilder strXmlAsset = new StringBuilder();
            //strXmlAsset.Append(@"<?xml version=""1.0"" ?>");
            strXmlAsset.Append(@"<Asset_ROOT>");
            strXmlAsset.Append(@"<Asset>");

            strXmlAsset.Append(@"<Asset_Id>" + AsseetID + "</Asset_Id>");
            //-------------------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------------------
            strXmlAsset.Append(@"<Asset_Type>" + ddlAssetType.SelectedValue.ToString() + "</Asset_Type>");
            strXmlAsset.Append(@"<Asset_Category>" + ddlAssetCategory.SelectedValue.ToString() + "</Asset_Category>");
            strXmlAsset.Append(@"<Asset_Name>" + txtAssetName.Text.ToString() + "</Asset_Name>");
            strXmlAsset.Append(@"<Asset_Desc>" + txtAssetDescription.Text.ToString() + "</Asset_Desc>");
            strXmlAsset.Append(@"<Asset_Maker>" + txtAssetMaker.Text.ToString() + "</Asset_Maker>");
            strXmlAsset.Append(@"<Asset_SerialNo>" + txtAssetSerialNo.Text.ToString() + "</Asset_SerialNo>");
            //strXmlAsset.Append(@"<Asset_Incharge>" + txtCustomFieldsValue.ToString() + "</Asset_Incharge>");
            strXmlAsset.Append(@"<Asset_Vendor>" + ddlAssetVendor.SelectedValue.ToString() + "</Asset_Vendor>");
            strXmlAsset.Append(@"<Asset_Dept>" + ddlDepartment.SelectedValue.ToString() + "</Asset_Dept>");
            strXmlAsset.Append(@"<Asset_Loc>" + hdnassetLocation.Value.ToString() + "</Asset_Loc>");
            strXmlAsset.Append(@"<Asset_Cost>" + txtAssetCost.Value.ToString() + "</Asset_Cost>");
            strXmlAsset.Append(@"<Asset_CurrencyType>" + ddlCurrencyType.SelectedValue.ToString() + "</Asset_CurrencyType>");
            //-------------------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------------------
            strXmlAsset.Append(@"<Asset_Images>");
            if (flAssetImg.HasFiles)
            {
                strXmlAsset.Append(@"<Asset_Images_Has_File>YES</Asset_Images_Has_File>");
            }
            else
            {
                strXmlAsset.Append(@"<Asset_Images_Has_File>NO</Asset_Images_Has_File>");
            }
            if (flAssetImg.HasFiles)
            {
                // UploadFile
                foreach (HttpPostedFile postfiles in flAssetImg.PostedFiles)
                {
                    string filetype = Path.GetExtension(postfiles.FileName);
                    if (filetype.ToLower() == ".jpg" || filetype.ToLower() == ".png")
                    {
                        string FilPath = "";
                        FilPath = UploadFile(postfiles, "Image", ddlAssetType.SelectedItem.ToString(), txtAssetName.Text.ToString());
                        strXmlAsset.Append(@"<Asset_Image_Data>");
                        strXmlAsset.Append(@"<Asset_Image_Path>" + FilPath.ToString() + "</Asset_Image_Path>");
                        strXmlAsset.Append(@"</Asset_Image_Data>");
                    }
                }
            }
            else
            {
                strXmlAsset.Append(@"<Asset_Image_Data>");
                strXmlAsset.Append(@"<Asset_Image_Path>""</Asset_Image_Path>");
                strXmlAsset.Append(@"</Asset_Image_Data>");
            }
            strXmlAsset.Append(@"</Asset_Images>");
            //-------------------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------------------
            strXmlAsset.Append(@"<Asset_Videos>");
            if (flAssetVideo.HasFiles)
            {
                strXmlAsset.Append(@"<Asset_Videos_Has_File>YES</Asset_Videos_Has_File>");
            }
            else
            {
                strXmlAsset.Append(@"<Asset_Videos_Has_File>NO</Asset_Videos_Has_File>");
            }
            if (flAssetVideo.HasFiles)
            {
                // UploadFile
                foreach (HttpPostedFile postfiles in flAssetVideo.PostedFiles)
                {
                    string filetype = Path.GetExtension(postfiles.FileName);
                    if (filetype.ToLower() == ".mp4" || filetype.ToLower() == ".avi" || filetype.ToLower() == ".mpeg")
                    {
                        string FilPath = "";
                        FilPath = UploadFile(postfiles, "Video", ddlAssetType.SelectedItem.ToString(), txtAssetName.Text.ToString());
                        strXmlAsset.Append(@"<Asset_Video_Data>");
                        strXmlAsset.Append(@"<Asset_Video_Path>" + FilPath.ToString() + "</Asset_Video_Path>");
                        strXmlAsset.Append(@"</Asset_Video_Data>");
                    }
                }
            }
            else
            {
                strXmlAsset.Append(@"<Asset_Video_Data>");
                strXmlAsset.Append(@"<Asset_Video_Path>""</Asset_Video_Path>");
                strXmlAsset.Append(@"</Asset_Video_Data>");
            }
            strXmlAsset.Append(@"</Asset_Videos>");
            //-------------------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------------------
            strXmlAsset.Append(@"<Asset_Docs>");
            if (flAssetDoc.HasFiles)
            {
                strXmlAsset.Append(@"<Asset_Docs_Has_File>YES</Asset_Docs_Has_File>");
            }
            else
            {
                strXmlAsset.Append(@"<Asset_Docs_Has_File>NO</Asset_Docs_Has_File>");
            }
            if (flAssetDoc.HasFiles)
            {
                // UploadFile
                foreach (HttpPostedFile postfiles in flAssetDoc.PostedFiles)
                {
                    string filetype = Path.GetExtension(postfiles.FileName);
                    if (filetype.ToLower() == ".pdf" || filetype.ToLower() == ".xls" || filetype.ToLower() == ".xlsx" || filetype.ToLower() == ".txt")
                    {
                        string FilPath = "";
                        FilPath = UploadFile(postfiles, "DOC", ddlAssetType.SelectedItem.ToString(), txtAssetName.Text.ToString());
                        strXmlAsset.Append(@"<Asset_Doc_Data>");
                        strXmlAsset.Append(@"<Asset_Doc_Path>" + FilPath.ToString() + "</Asset_Doc_Path>");
                        strXmlAsset.Append(@"</Asset_Doc_Data>");
                    }
                }
            }
            else
            {
                strXmlAsset.Append(@"<Asset_Doc_Data>");
                strXmlAsset.Append(@"<Asset_Doc_Path>""</Asset_Doc_Path>");
                strXmlAsset.Append(@"</Asset_Doc_Data>");
            }
            strXmlAsset.Append(@"</Asset_Docs>");
            //-------------------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------------------

            strXmlAsset.Append(@"<Asset_PurchaseDate>" + txtAssetPurchaseDate.Text.ToString() + "</Asset_PurchaseDate>");
            strXmlAsset.Append(@"</Asset>");
            strXmlAsset.Append(@"</Asset_ROOT>");

            return strXmlAsset.ToString();
        }
        private string AssetAMCData(int Asseet_AMC_ID)
        {
            StringBuilder strXmlAsset = new StringBuilder();
            //strXmlAsset.Append(@"<?xml version=""1.0"" ?>");
            strXmlAsset.Append(@"<Asset_AMC_ROOT>");
            strXmlAsset.Append(@"<Asset_AMC>");

            strXmlAsset.Append(@"<Asset_AMC_Id>" + Asseet_AMC_ID + "</Asset_AMC_Id>");
            //-------------------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------------------
            strXmlAsset.Append(@"<Asset_AMC_Type>" + ddlAmcType.SelectedValue.ToString() + "</Asset_AMC_Type>");
            strXmlAsset.Append(@"<Asset_AMC_Desc>" + txtAmcDescription.Text.ToString() + "</Asset_AMC_Desc>");
            strXmlAsset.Append(@"<Asset_AMC_StartDate>" + txtAmcStartDate.Text.ToString() + "</Asset_AMC_StartDate>");
            strXmlAsset.Append(@"<Asset_AMC_EndDate>" + txtAmcEndDate.Text.ToString() + "</Asset_AMC_EndDate>");
            strXmlAsset.Append(@"<Asset_AMC_Vendor>" + hfAmcAssignedVendor.Value.ToString() + "</Asset_AMC_Vendor>");
            strXmlAsset.Append(@"<Asset_AMC_Inclusion>" + txtAmcInclusion.Text.ToString() + "</Asset_AMC_Inclusion>");
            strXmlAsset.Append(@"<Asset_AMC_Exclusion>" + txtAmcExclusion.Text.ToString() + "</Asset_AMC_Exclusion>");
            strXmlAsset.Append(@"<Asset_AMC_Remarks>" + txtAmcRemarks.Text.ToString() + "</Asset_AMC_Remarks>");
            //-------------------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------------------
            strXmlAsset.Append(@"<Asset_AMC_Docs>");
            if (flAmcDoc.HasFiles)
            {
                strXmlAsset.Append(@"<Asset_Docs_Has_File>YES</Asset_Docs_Has_File>");
            }
            else
            {
                strXmlAsset.Append(@"<Asset_Docs_Has_File>NO</Asset_Docs_Has_File>");
            }
            if (flAmcDoc.HasFiles)
            {
                // UploadFile
                foreach (HttpPostedFile postfiles in flAmcDoc.PostedFiles)
                {
                    string filetype = Path.GetExtension(postfiles.FileName);
                    if (filetype.ToLower() == ".pdf" || filetype.ToLower() == ".xls" || filetype.ToLower() == ".xlsx" || filetype.ToLower() == ".txt")
                    {
                        string FilPath = "";
                        FilPath = UploadFile(postfiles, "AmcDoc", ddlAssetType.SelectedItem.ToString(), txtAssetName.Text.ToString());
                        strXmlAsset.Append(@"<Asset_AMC_Doc_Data>");
                        strXmlAsset.Append(@"<Asset_AMC_Doc_Path>" + FilPath.ToString() + "</Asset_AMC_Doc_Path>");
                        strXmlAsset.Append(@"</Asset_AMC_Doc_Data>");
                    }
                }
            }
            else
            {
                strXmlAsset.Append(@"<Asset_AMC_Doc_Data>");
                strXmlAsset.Append(@"<Asset_AMC_Doc_Path>""</Asset_AMC_Doc_Path>");
                strXmlAsset.Append(@"</Asset_AMC_Doc_Data>");
            }
            strXmlAsset.Append(@"</Asset_AMC_Docs>");
            //-------------------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------------------
            strXmlAsset.Append(@"</Asset_AMC>");
            strXmlAsset.Append(@"</Asset_AMC_ROOT>");

            return strXmlAsset.ToString();
        }
        private string AssetServiceData()
        {
            StringBuilder strXmlAsset = new StringBuilder();

            if (txtHdn.Text != "")
            {
                strXmlAsset.Append(txtHdn.Text);
            }

            return strXmlAsset.ToString();
        }


        private string AssetVendorData()
        {
            StringBuilder strXmlAsset = new StringBuilder();
            //strXmlAsset.Append(@"<?xml version=""1.0"" ?>");
            strXmlAsset.Append(@"<Asset_Vendor_ROOT>");
            strXmlAsset.Append(@"<Asset_Vendor>");

            //-------------------------------------------------------------------------------------------------------------------
            strXmlAsset.Append(@"<Asset_Vendor_Name>" + txtModalVendor_Name.Text.ToString() + "</Asset_Vendor_Name>");
            strXmlAsset.Append(@"<Asset_Vendor_Desc>" + txtModalVendor_Desc.Text.ToString() + "</Asset_Vendor_Desc>");
            strXmlAsset.Append(@"<Asset_Vendor_Address>" + txtModalVendor_Address.Text.ToString() + "</Asset_Vendor_Address>");
            strXmlAsset.Append(@"<Asset_Vendor_Contact1>" + txtModalVendor_Contact1.Text.ToString() + "</Asset_Vendor_Contact1>");
            strXmlAsset.Append(@"<Asset_Vendor_Contact2>" + txtModalVendor_Contact2.Text.ToString() + "</Asset_Vendor_Contact2>");
            strXmlAsset.Append(@"<Asset_Vendor_Email>" + txtModalVendor_Email.Text.ToString() + "</Asset_Vendor_Email>");
            //-------------------------------------------------------------------------------------------------------------------
            strXmlAsset.Append(@"</Asset_Vendor>");
            strXmlAsset.Append(@"</Asset_Vendor_ROOT>");

            return strXmlAsset.ToString();
        }
        #endregion
        protected void btnModalAssetSave_Click(object sender, EventArgs e)
        {
            string VendorxXml = "";
            if (hdAddAsset.Value == "1")
            {
                // Add Asset Type
                if (txtModalAssetType.Text == "")
                {
                    lblModalAssetErrorMessage.InnerText = "Please Enter Asset Type.";
                    lblModalAssetErrorMessage.Attributes.Remove("style");
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    return;
                }

                //SPR_ASSET_INSERT_ASSET_TYPE
            }
            else if (hdAddAsset.Value == "2")
            {
                // ADD ASSET CATEGORY
                if (txtModalAssetCategory.Text == "")
                {
                    lblModalAssetErrorMessage.InnerText = "Please Enter Asset Category.";
                    lblModalAssetErrorMessage.Attributes.Remove("style");
                    return;
                }
                else if (ddlModalAssetType.SelectedIndex == 0)
                {
                    lblModalAssetErrorMessage.InnerText = "Please Select Asset Type.";
                    lblModalAssetErrorMessage.Attributes.Remove("style");
                    return;
                }
                //SPR_ASSET_INSERT_ASSET_CATEGORY
            }
            if (hdAddAsset.Value == "4")
            {
                // Add Department
                if (txtModalDepartment.Text == "")
                {
                    lblModalAssetErrorMessage.InnerText = "Please Enter Department.";
                    lblModalAssetErrorMessage.Attributes.Remove("style");
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    return;
                }

                //SPR_ASSET_INSERT_Department
            }
            if (hdAddAsset.Value == "3")
            {
                //Vendor
                VendorxXml = AssetVendorData();
            }

            DataSet dsConfig = new DataSet();
            if (hdAddAsset.Value == "1")
                dsConfig = ObjUpkeep.ASSET_Insert_AssetType(LoggedInUserID, 0, txtModalAssetType.Text);
            else if (hdAddAsset.Value == "2")
                dsConfig = ObjUpkeep.ASSET_Insert_AssetCategory(LoggedInUserID, 0, Convert.ToInt32(ddlModalAssetType.SelectedValue.ToString()), txtModalAssetCategory.Text);
            else if (hdAddAsset.Value == "3") //3 5
                dsConfig = ObjUpkeep.ASSET_INSERT_GRNL_MASTER(LoggedInUserID, "VENDOR", "", "", VendorxXml.ToString());
            else if (hdAddAsset.Value == "4") //3 5
                dsConfig = ObjUpkeep.ASSET_INSERT_GRNL_MASTER(LoggedInUserID, "DEPARTMENT", txtModalDepartment.Text, "", "");

            if (dsConfig.Tables.Count > 0)
            {
                if (dsConfig.Tables[0].Rows.Count > 0)
                {
                    int Status = Convert.ToInt32(dsConfig.Tables[0].Rows[0]["Status"]);
                    if (Status == 0)
                    {
                    }
                    else if (Status == 1)
                    {
                        lblModalAssetErrorMessage.InnerText = "Record Already exists";
                        lblModalAssetErrorMessage.Attributes.Remove("style");
                    }
                    else if (Status == 2)
                    {
                        lblModalAssetErrorMessage.InnerText = "Data Saved Successfully";
                        lblModalAssetErrorMessage.Attributes.Remove("style");

                        Fetch_Updated_Bind_DropDown(hdAddAsset.Value);
                    }
                    else if (Status == 3)
                    {
                        lblModalAssetErrorMessage.InnerText = "Due to some technical issue your request can not be process. Kindly try after some time";
                        lblModalAssetErrorMessage.Attributes.Remove("style");
                    }
                }
            }
        }


        public void Fetch_Updated_Bind_DropDown(string TypeID)
        {
            DataSet dsTitle = new DataSet();
            string Initiator = string.Empty;
            try
            {
                dsTitle = ObjUpkeep.Fetch_Asset_DropDown(Convert.ToInt32(LoggedInUserID), CompanyID);
                ViewState["dsGlobalDropDownData"] = dsTitle.Copy();

                if (dsTitle.Tables.Count > 0)
                {
                    if (TypeID == "1")
                    {
                        if (dsTitle.Tables[0].Rows.Count > 0)
                        {
                            ddlAssetType.DataSource = dsTitle.Tables[0];
                            ddlAssetType.DataTextField = "Asset_Type_Desc";
                            ddlAssetType.DataValueField = "Asset_Type_ID";
                            ddlAssetType.DataBind();
                            ddlAssetType.Items.Insert(0, new ListItem("--Select Asset Type--", "0"));


                            ddlModalAssetType.DataSource = dsTitle.Tables[0];
                            ddlModalAssetType.DataTextField = "Asset_Type_Desc";
                            ddlModalAssetType.DataValueField = "Asset_Type_ID";
                            ddlModalAssetType.DataBind();
                            ddlModalAssetType.Items.Insert(0, new ListItem("--Select--", "0"));

                        }
                    }

                    if (TypeID == "2")
                    {
                        if (dsTitle.Tables[1].Rows.Count > 0)
                        {

                            ddlAssetCategory.DataSource = dsTitle.Tables[1];
                            ddlAssetCategory.DataTextField = "Category_Desc";
                            ddlAssetCategory.DataValueField = "Asset_Category_ID";
                            ddlAssetCategory.DataBind();
                            ddlAssetCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                        }
                    }

                    if (TypeID == "3")
                    {
                        if (dsTitle.Tables[2].Rows.Count > 0)
                        {

                            ddlAssetVendor.DataSource = dsTitle.Tables[2];
                            ddlAssetVendor.DataTextField = "Vendor_Name";
                            ddlAssetVendor.DataValueField = "Vendor_ID";
                            ddlAssetVendor.DataBind();
                            ddlAssetVendor.Items.Insert(0, new ListItem("--Select--", "0"));

                            var builder = new System.Text.StringBuilder();


                            for (int i = 0; i < dsTitle.Tables[2].Rows.Count; i++)
                            {
                                builder.Append(String.Format("<option value='{0}' text='{1}'>", dsTitle.Tables[2].Rows[i]["Vendor_Name"], dsTitle.Tables[2].Rows[i]["Vendor_ID"]));
                            }
                            dlamcassigVendor.InnerHtml = builder.ToString();
                            dlamcassigVendor.DataBind();


                        }
                    }
                    if (TypeID == "4")
                    {
                        if (dsTitle.Tables[3].Rows.Count > 0)
                        {
                            ddlDepartment.DataSource = dsTitle.Tables[3];
                            ddlDepartment.DataTextField = "Dept_Desc";
                            ddlDepartment.DataValueField = "Department_ID";
                            ddlDepartment.DataBind();
                            ddlDepartment.Items.Insert(0, new ListItem("--Select--", "0"));
                        }
                    }
                    if (TypeID == "5")
                    {
                        if (dsTitle.Tables[4].Rows.Count > 0)
                        {
                            var builder = new System.Text.StringBuilder();

                            for (int i = 0; i < dsTitle.Tables[4].Rows.Count; i++)
                            {
                                builder.Append(String.Format("<option value='{0}' text='{1}'>", dsTitle.Tables[4].Rows[i]["Loc_Desc"], dsTitle.Tables[4].Rows[i]["Loc_id"]));
                            }
                            dlassetLocation.InnerHtml = builder.ToString();
                            dlassetLocation.DataBind();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSuccessOk_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/AssetManagement/AssetManagementList.aspx"), false);
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
                            LocTxtActionGroup.DataValueField = "User_ID";
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

                        txtServiceRemarks.Attributes.Add("style", "display:none");

                        txtServiceRemarks.Attributes.Add("ID", "" + sCellId + "4" + "");
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[4].Controls.Add(txtServiceRemarks);

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[5].Attributes.Add("class", "GridItem");
                        System.Web.UI.WebControls.TextBox txtServiceStatus = new System.Web.UI.WebControls.TextBox();
                        txtServiceStatus.Attributes.Add("class", "form-control m-input");
                        txtServiceStatus.Attributes.Add("style", "width: 100px");

                        txtServiceStatus.Attributes.Add("style", "display:none");

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
                            LocTxtActionGroup.DataValueField = "User_ID";
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