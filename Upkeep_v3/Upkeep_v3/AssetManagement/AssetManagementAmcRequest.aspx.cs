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


namespace Upkeep_v3.AssetManagement
{
    public partial class AssetManagementAmcRequest : System.Web.UI.Page
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

                btnRenewAMC.Attributes.Add("style", "display:none");

                Session["TransactionID"] = 0; 
                if (TransactionID > 0)
                {
                    Fetch_Bind_DropDown();
                    DivIsNewAmc.Attributes.Add("style", "display:none");
                    Session["TransactionID"] = Convert.ToString(TransactionID);
                    DisplayData(TransactionID);
                }
                else
                {
                    Fetch_Bind_DropDown();
                    customCheck.Checked = true;
                    DivIsUpdateAMC.Attributes.Add("style", "display:none");
                }

            }
            //if (TransactionID > 0)
            //{
            //    customCheck.Checked = true;
            //}

        }
        public void Fetch_Bind_DropDown()
        {
            DataSet dsTitle = new DataSet();
            string Initiator = string.Empty;
            try
            {
                dsTitle = ObjUpkeep.Fetch_Asset_DropDown(Convert.ToInt32(LoggedInUserID), CompanyID,0,string.Empty,string.Empty,string.Empty);
                ViewState["dsGlobalDropDownData"] = dsTitle.Copy();
                //SPR_ASSET_FETCH_DROPDOWN_LIST
                if (dsTitle.Tables.Count > 0)
                {
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

                        dlRenewAmcassigVendor.InnerHtml = builder.ToString();
                        dlRenewAmcassigVendor.DataBind();
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


                        ddlRenewAmcType.DataSource = dsTitle.Tables[5];
                        ddlRenewAmcType.DataTextField = "Asset_AMC_Type_Desc";
                        ddlRenewAmcType.DataValueField = "Asset_AMC_Type_ID";
                        ddlRenewAmcType.DataBind();
                        ddlRenewAmcType.Items.Insert(0, new ListItem("--Select--", "0"));
                    }

                    if (dsTitle.Tables[6].Rows.Count > 0)
                    {
                        ddlCurrencyType.DataSource = dsTitle.Tables[6];
                        ddlCurrencyType.DataTextField = "Currency_Code";
                        ddlCurrencyType.DataValueField = "Currency_Code";
                        ddlCurrencyType.DataBind();
                        ddlCurrencyType.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    if (dsTitle.Tables[9].Rows.Count > 0) //dsTitle.Tables[8].Rows.Count 
                    {
                        if ((int)Session["TransactionID"] > 0)
                        {
                            ddlAssetName.DataSource = dsTitle.Tables[8];
                        }
                        else
                        {
                            ddlAssetName.DataSource = dsTitle.Tables[9];
                        }
                        ddlAssetName.DataTextField = "Asset_Name";
                        ddlAssetName.DataValueField = "Asset_ID";
                        ddlAssetName.DataBind();
                        ddlAssetName.Items.Insert(0, new ListItem("--Select--", "0"));
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
                btnRenewAMC.Attributes.Add("style", "display:none");

                dsAssestData = ObjUpkeep.Fetch_ASSET_REQUEST_Details(LoggedInUserID, TransactionID);
                if (dsAssestData.Tables.Count > 0)
                {

                    //Asset_ID Asset_Type_ID   Asset_Category_ID Asset_Name  Asset_Desc Asset_Make  Asset_Serial_No Vendor_ID 
                    //    Department_ID Loc_id  Asset_Cost Currency_Type   Asset_Images Asset_Videos    Asset_Docs Asset_Purchase_Date 
                    //    Asset_Is_AMC_Active Created_By  Created_Date Updated_By  Updated_Date Is_Deleted  Company_ID


                    if (dsAssestData.Tables[0].Rows.Count > 0)
                    {
                        ddlAssetType.SelectedValue = dsAssestData.Tables[0].Rows[0]["Asset_Type_ID"].ToString();
                        ddlAssetCategory.SelectedValue = dsAssestData.Tables[0].Rows[0]["Asset_Category_ID"].ToString();
                        txtAssetName.Text = dsAssestData.Tables[0].Rows[0]["Asset_Name"].ToString();

                        txttAmcName.Text = dsAssestData.Tables[0].Rows[0]["Asset_Name"].ToString();

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

                        if (txtAmcStatus.Text == "ACTIVE" || txtAmcStatus.Text.Trim() == "")
                        {
                            btnRenewAMC.Attributes.Add("style", "display:none");
                        }
                        else
                        {

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

                            txtAmcStatus.Attributes.Remove("style");
                            lblAmcStatus.Attributes.Remove("style");

                            btnRenewAMC.Attributes.Remove("style");
                            Button1.Attributes.Add("style", "display:none");
                        }

                        // else{
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
                        //}
                        if (dsAssestData.Tables[3].Rows.Count > 0)
                        {
                            HdnAmcDoc.Value = dsAssestData.Tables[3].Rows[0]["ImagePath"].ToString();
                        }

                    }
                    else
                    {
                        customCheck.Checked = true;
                        ddlAmcType.SelectedIndex = 0;
                        txtAmcDescription.Text = "";
                        txtAmcStartDate.Text = "";
                        txtAmcEndDate.Text = "";
                        txtamcassigVendor.Value = "";
                        hfAmcAssignedVendor.Value = "";
                        txtAmcInclusion.Text = "";
                        txtAmcExclusion.Text = "";
                        txtAmcRemarks.Text = "";
                        txtAmcStatus.Text = "";

                        txtAmcStatus.Attributes.Add("style", "display:none");
                        lblAmcStatus.Attributes.Add("style", "display:none");

                        customCheck.Attributes.Remove("disabled");
                        ddlAmcType.Attributes.Remove("disabled");
                        txtAmcDescription.Attributes.Remove("disabled");
                        txtAmcStartDate.Attributes.Remove("disabled");
                        txtAmcEndDate.Attributes.Remove("disabled");
                        txtamcassigVendor.Attributes.Remove("disabled");
                        txtAmcInclusion.Attributes.Remove("disabled");
                        txtAmcExclusion.Attributes.Remove("disabled");
                        txtAmcRemarks.Attributes.Remove("disabled");
                        txtAmcStatus.Attributes.Remove("disabled");
                        flAmcDoc.Attributes.Remove("disabled");

                        //btnRenewAMC.Attributes.Remove("style");
                        Button1.Attributes.Remove("style");
                    }

                    if (dsAssestData.Tables[5].Rows.Count > 0)
                    {
                        ViewState["AmcHistoryData"] = dsAssestData.Tables[5].Copy();
                        fetchListing();

                        if (dsAssestData.Tables[6].Rows.Count > 0)
                        {
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string fetchListing()
        {
            string data = "";
            string From_Date = string.Empty;
            string To_Date = string.Empty;

            try
            {
                DataTable dt = new DataTable();

                if (ViewState["AmcHistoryData"] != null && !ViewState["AmcHistoryData"].Equals("-1"))
                {
                    dt = (DataTable)ViewState["AmcHistoryData"];

                    if (dt.Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(dt.Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            string Asset_AMC_Type_Desc = Convert.ToString(dt.Rows[i]["Asset_AMC_Type_Desc"]);
                            string AMC_Desc = Convert.ToString(dt.Rows[i]["AMC_Desc"]);
                            string AMC_Start_Date = Convert.ToString(dt.Rows[i]["AMC_Start_Date"]);
                            string AMC_End_Date = Convert.ToString(dt.Rows[i]["AMC_End_Date"]);
                            string Vendor_Name = Convert.ToString(dt.Rows[i]["Vendor_Name"]);
                            string AMC_Inclusions = Convert.ToString(dt.Rows[i]["AMC_Inclusions"]);
                            string AMC_Exclusions = Convert.ToString(dt.Rows[i]["AMC_Exclusions"]);
                            string Remarks = Convert.ToString(dt.Rows[i]["Additional Remarks"]);
                            string AMC_Status = Convert.ToString(dt.Rows[i]["AMC_Status"]);


                            //Asset_ID Asset_Name  Asset_Desc Asset_Make  Asset_Serial_No Asset_Type  Asset_Category Vendor  Department Location    
                            //    Asset_Cost Currency_Type   Asset_Purchase_Date Asset_Is_AMC_Active Created_By Created_Date
                            //< td > < a href = 'AssetManagementAmcRequest.aspx?TransactionID=" + Asset_ID + "' style = 'text-decoration: underline;' > " + Asset_Name + " </ a ></ td > "
                            data += "<tr>" +
                                "<td>" + Asset_AMC_Type_Desc + "</td>" +
                                "<td>" + AMC_Desc + "</td>" +
                                "<td>" + AMC_Start_Date + "</td>" +
                                "<td>" + AMC_End_Date + "</td>" +
                                "<td>" + Vendor_Name + "</td>" +
                                "<td>" + AMC_Inclusions + "</td>" +
                                "<td>" + AMC_Exclusions + "</td>" +
                                "<td>" + Remarks + "</td>" +
                                "<td>" + AMC_Status + "</td>" +
                                "</tr>";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

        protected void ddlAssetName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAssetName.SelectedIndex > 0)
            {
                ViewState["TransactionID"] = ddlAssetName.SelectedValue.ToString();
                Session["TransactionID"] = Convert.ToString(ddlAssetName.SelectedValue.ToString());
                DisplayData(Convert.ToInt32(ddlAssetName.SelectedValue.ToString()));
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
        protected void btnModalAssetSave_Click(object sender, EventArgs e)
        {
            int OutputStatus = 0;

            if (hfRenewAmcAssignedVendor.Value == "")
            {
                lblErrorMsg.Text = "Please select vendor name";
                return;
            }

            OutputStatus = InsertData();
            if (OutputStatus == 99)
            {
                lblErrorMsg.Text = "Missing Service Data";
                return;
            }
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


            ////PROCESS DATA 
            int OutputStatus = 0;
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


            string strAssetAMCData = "";
            strAssetAMCData = AssetRenewAMCData(0);


            ds = ObjUpkeep.INSERT_UPDATE_ASSET_AMC_REQUEST_Details(LoggedInUserID, ViewState["TransactionID"].ToString(), strAssetAMCData, "INSERT");
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
        public int UpdateData()
        {
            int Status = 0;
            ViewState["RequestAssetID"] = "";
            DataSet ds = new DataSet();

            string strAssetAMCData = "";


            if (ddlAssetName.SelectedIndex > 0)
            {
                strAssetAMCData = AssetAMCData(Convert.ToInt32(ddlAssetName.SelectedValue.ToString()));
                ds = ObjUpkeep.INSERT_UPDATE_ASSET_AMC_REQUEST_Details(LoggedInUserID, ddlAssetName.SelectedValue.ToString(), strAssetAMCData, "UPDATE");
            }
            else
            {
                if (customCheck.Checked == true)
                    strAssetAMCData = AssetAMCData((int)ViewState["TransactionID"]);

                ds = ObjUpkeep.INSERT_UPDATE_ASSET_AMC_REQUEST_Details(LoggedInUserID, Convert.ToString((int)ViewState["TransactionID"]), strAssetAMCData, "UPDATE");
            }



            //string strAssetServiceData = "";
            //if (customCheck1.Checked == true)
            //    strAssetServiceData = AssetServiceData();
            //if (customCheck.Checked == true)
            //    strAssetAMCData = AssetAMCData((int)ViewState["TransactionID"]);
            //ds = ObjUpkeep.INSERT_UPDATE_ASSET_AMC_REQUEST_Details(LoggedInUserID, Convert.ToString((int)ViewState["TransactionID"]), strAssetAMCData, "UPDATE");

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
        private string AssetRenewAMCData(int Asseet_AMC_ID)
        {
            StringBuilder strXmlAsset = new StringBuilder();
            //strXmlAsset.Append(@"<?xml version=""1.0"" ?>");
            strXmlAsset.Append(@"<Asset_AMC_ROOT>");
            strXmlAsset.Append(@"<Asset_AMC>");

            strXmlAsset.Append(@"<Asset_AMC_Id>" + Asseet_AMC_ID + "</Asset_AMC_Id>");
            //-------------------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------------------
            strXmlAsset.Append(@"<Asset_AMC_Type>" + ddlRenewAmcType.SelectedValue.ToString() + "</Asset_AMC_Type>");
            strXmlAsset.Append(@"<Asset_AMC_Desc>" + txtRenewAmcDescription.Text.ToString() + "</Asset_AMC_Desc>");
            strXmlAsset.Append(@"<Asset_AMC_StartDate>" + txtRenewAmcStartDate.Text.ToString() + "</Asset_AMC_StartDate>");
            strXmlAsset.Append(@"<Asset_AMC_EndDate>" + txtRenewAmcEndDate.Text.ToString() + "</Asset_AMC_EndDate>");
            strXmlAsset.Append(@"<Asset_AMC_Vendor>" + hfRenewAmcAssignedVendor.Value.ToString() + "</Asset_AMC_Vendor>");
            strXmlAsset.Append(@"<Asset_AMC_Inclusion>" + txtRenewAmcInclusion.Text.ToString() + "</Asset_AMC_Inclusion>");
            strXmlAsset.Append(@"<Asset_AMC_Exclusion>" + txtRenewAmcExclusion.Text.ToString() + "</Asset_AMC_Exclusion>");
            strXmlAsset.Append(@"<Asset_AMC_Remarks>" + txtRenewAmcRemarks.Text.ToString() + "</Asset_AMC_Remarks>");
            //-------------------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------------------
            strXmlAsset.Append(@"<Asset_AMC_Docs>");
            if (flRenewAmcDoc.HasFiles)
            {
                strXmlAsset.Append(@"<Asset_Docs_Has_File>YES</Asset_Docs_Has_File>");
            }
            else
            {
                strXmlAsset.Append(@"<Asset_Docs_Has_File>NO</Asset_Docs_Has_File>");
            }
            if (flRenewAmcDoc.HasFiles)
            {
                // UploadFile
                foreach (HttpPostedFile postfiles in flRenewAmcDoc.PostedFiles)
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


        #endregion

        protected void btnSuccessOk_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/AssetManagement/AssetManagementAmcList.aspx"), false);
        }


    }
}