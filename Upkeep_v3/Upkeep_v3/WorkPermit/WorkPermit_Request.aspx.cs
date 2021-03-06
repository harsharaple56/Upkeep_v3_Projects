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
//using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Upkeep_v3.WorkPermit
{
    public partial class WorkPermit_Request : System.Web.UI.Page
    {
        int sPublicConfigId = 0;

        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        string TransLoggedInUserID = string.Empty;
        string TransInitiator = string.Empty;
        DataSet dsGlobalDataS = new DataSet();
        string MyActionFlag = string.Empty;
        string MyActionCompeletd = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //int TransactionID = 0;
            string TransactionID = "0";
            if (Request.QueryString["TransactionID"] != null)
            {
                //TransactionID = Convert.ToInt32(Request.QueryString["TransactionID"]);
                TransactionID = Convert.ToString(Request.QueryString["TransactionID"]);
            }

            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            MyActionFlag = Convert.ToString(Request.QueryString["MyAction"]);
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);

                //Session["PreviousURL"] = "";
                //LoggedInUserID = "zara";
            }

            if (Convert.ToString(Session["CompanyID"]) == "")
            {
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }


            if (!IsPostBack)
            {

                if (System.Web.HttpContext.Current.Session["PreviousURL"] == null)
                {
                    Session["PreviousURL"] = "~/WorkPermit/MyWorkPermit.aspx";
                }


                //if (TransactionID > 0)
                if (TransactionID != "0")
                {
                    Session["TransactionID"] = Convert.ToString(TransactionID);
                    FetchSectionHeaderData(TransactionID);
                }
                else
                {
                    BindWorkPermitTitle();
                    btnApprove.Attributes.Add("style", "display:none;");
                }


                if (MyActionFlag != "1")
                {
                    //if (TransactionID <= 0)
                    if (TransactionID == "0")
                    {
                        dvApprovalHistory.Attributes.Add("style", "display:none;");
                    }
                    btnApprove.Attributes.Add("style", "display:none;");
                    dvApprovalDetails.Attributes.Add("style", "display:none;");
                    dvApprovalDetHeader.Attributes.Add("Style", "display:none;");
                    //dvApprovalDetails.Attributes.Add("Style", "display:none;");
                    //dvSubmitSection.Attributes.Add("Style", "display:none;"); ;
                }
            }

        }

        public void BindWorkPermitTitle()
        {
            DataSet dsTitle = new DataSet();
            string Initiator = string.Empty;
            try
            {
                if (TransInitiator != "")
                {
                    Initiator = Convert.ToString(TransInitiator);
                }
                else
                {
                    Initiator = Convert.ToString(Session["UserType"]);
                }

                //dsTitle = ObjUpkeep.Fetch_WorkPermitConfiguration(Initiator, Session["CompanyID"].ToString());
                dsTitle = ObjUpkeep.Fetch_WorkPermitConfiguration(Initiator, Convert.ToString(Session["CompanyID"]));

                
                
                    if (dsTitle.Tables[0].Rows.Count > 0)
                    {
                        if (dsTitle.Tables[0].Rows.Count > 0)
                        {
                            ddlWorkPermitTitle.DataSource = dsTitle.Tables[0];
                            ddlWorkPermitTitle.DataTextField = "WP_Title";
                            ddlWorkPermitTitle.DataValueField = "WP_Config_ID";
                            ddlWorkPermitTitle.DataBind();
                            ddlWorkPermitTitle.Items.Insert(0, new ListItem("--Select--", "0"));
                        }
                    }
                    else
                    {
                        mpeNo_Work_Permits.Show();
                        if (Initiator == "R")
                        {
                            lbl_Retailer_NoForm.InnerText = "Retailers";
                        }
                        else
                        {
                            lbl_Employee_NoForm.InnerText = "Employees";
                        }
                    }
                


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public string bindWorkPermitHeader()
        //{
        //    string data = "";
        //    int WorkPermitTitleID = 0;
        //    try
        //    {
        //        // WorkPermitTitleID = Convert.ToInt32(ddlWorkPermitTitle.SelectedValue);

        //        WorkPermitTitleID = 6;

        //        DataSet dsWorkPermitHeader = new DataSet();
        //        dsWorkPermitHeader = ObjUpkeep.Bind_WorkPermitConfiguration(WorkPermitTitleID);

        //        if (dsWorkPermitHeader.Tables.Count > 2)
        //        {
        //            if (dsWorkPermitHeader.Tables[3].Rows.Count > 0)
        //            {
        //                rptTermsCondition.DataSource = dsWorkPermitHeader.Tables[3];
        //                rptTermsCondition.DataBind();
        //            }
        //        }

        //        int ColumnCount = 0;

        //        if (dsWorkPermitHeader.Tables.Count > 0)
        //        {
        //            if (dsWorkPermitHeader.Tables[1].Rows.Count > 0)
        //            {
        //                int count = Convert.ToInt32(dsWorkPermitHeader.Tables[1].Rows.Count);

        //                ColumnCount = (dsWorkPermitHeader.Tables[1].Rows.Count);

        //                string WPHeader = string.Empty;
        //                for (int j = 0; j < count; j++)
        //                {

        //                    WPHeader = Convert.ToString(dsWorkPermitHeader.Tables[1].Rows[j]["Header_Name"]);

        //                    //data += "<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Nostrud esse officia adipisicing dolore est in eiusmod dolor tempor adipisicing ut non non.'>Q" + j + "</th> ";
        //                    data += "<th data-container='body' data-toggle='m-tooltip' data-placement='top'>" + WPHeader + "</th> ";

        //                }
        //                //}

        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return data;
        //}

        //public string bindWorkPermitHeaderValue()
        //{
        //    string data = "";
        //    return data;
        //}

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void rptSectionDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Reference the Repeater Item.
                RepeaterItem item = e.Item;

                //string DivId = (e.Item.FindControl("DivSectionIDLabel") as Label).Text;
                string DivId = (e.Item.FindControl("hfCustomerId") as HiddenField).Value;
                Repeater rptHeaderDetails = e.Item.FindControl("rptHeaderDetails") as Repeater;

                DataSet dsWorkPermitHeader = new DataSet();
                dsWorkPermitHeader = dsGlobalDataS.Copy(); // ObjUpkeep.Bind_WorkPermitConfiguration(sPublicConfigId);
                DataTable dt = new DataTable();
                dt = dsWorkPermitHeader.Tables[2].Copy();
                dt.DefaultView.RowFilter = "WP_Section_ID = " + Convert.ToString(DivId) + "";
                dt = dt.DefaultView.ToTable();
                if (dt.Rows.Count > 0)
                {
                    rptHeaderDetails.DataSource = dt;
                    rptHeaderDetails.DataBind();
                }
                else
                {
                    DataTable dt1 = new DataTable();
                    rptHeaderDetails.DataSource = dt1;
                    rptHeaderDetails.DataBind();

                    //Control FooterTemplate = rptHeaderDetails.Controls[rptHeaderDetails.Controls.Count - 1].Controls[0];
                    //HtmlGenericControl FootesrTemplate = FooterTemplate.FindControl("HeaderFooter") as HtmlGenericControl;
                    //FootesrTemplate.Attributes.Remove("style");
                }
            }
        }

        protected void rptHeaderDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Reference the Repeater Item.
                RepeaterItem item = e.Item;

                //int AnswerType = Convert.ToInt32((e.Item.FindControl("hdnlblAnswerType") as HiddenField).Value);
                string AnswerType = (e.Item.FindControl("hdnAnswerTypeSDesc") as HiddenField).Value;
                string HeadId = (e.Item.FindControl("hfHeaderId") as HiddenField).Value;

                string HeadMandatoryId = (e.Item.FindControl("hdnIs_Mandatory") as HiddenField).Value;
                if (HeadMandatoryId == "*")
                {
                    // Commented by Ajay
                    //Label sample = e.Item.FindControl("lblIsMandatory") as Label;
                    //sample.Attributes.Remove("style");
                }

                if (AnswerType == "MSLCT") //Multi Selection [CheckBox]
                {
                    HtmlGenericControl sample = e.Item.FindControl("divCheckBox") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == "SSLCT") //Single Selection [Radio Button]
                {
                    HtmlGenericControl sample = e.Item.FindControl("divRadioButton") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == "IMAGE") //Image Upload  
                {
                    HtmlGenericControl sample = e.Item.FindControl("divImage") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == "NUMBR") //Number Text Field
                {
                    HtmlGenericControl sample = e.Item.FindControl("divNumber") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                    //[+][Ajay][17/03/2021][Validation]
                    //HtmlInputText divNumberid = (HtmlInputText)e.Item.FindControl("divNumberid");
                    //divNumberid.MaxLength = 20;
                }
                else if (AnswerType == "STEXT") //Normal Text Field
                {
                    HtmlGenericControl sample = e.Item.FindControl("divText") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                    //[+][Ajay][16/03/2021][Validation]
                    //HtmlInputText divTextid = (HtmlInputText)e.Item.FindControl("divTextid");
                    //divTextid.MaxLength = 100;
                }
                else if (AnswerType == "LTEXT") // Textarea Field
                {
                    HtmlGenericControl sample = e.Item.FindControl("divTextArea") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                    //[+][Ajay][17/03/2021][Validation]
                    //HtmlTextArea divTextAreaid = (HtmlTextArea)e.Item.FindControl("divTextAreaid");
                    //divTextAreaid.MaxLength = 500;
                }
                else  //Normal Text Field
                {
                    HtmlGenericControl sample = e.Item.FindControl("divText") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                    //[+][Ajay][17/03/2021][Validation]
                    //HtmlInputText divTextid = (HtmlInputText)e.Item.FindControl("divTextid");
                    //divTextid.MaxLength = 100;
                }


                //Repeater rptRadio = e.Item.FindControl("rptRadio") as Repeater;

                DataSet dsWorkPermitHeader = new DataSet();
                dsWorkPermitHeader = dsGlobalDataS.Copy(); //ObjUpkeep.Bind_WorkPermitConfiguration(sPublicConfigId);

                DataTable dt = new DataTable();
                if (TransLoggedInUserID != "")
                {
                    dt = dsWorkPermitHeader.Tables[7].Copy();
                }
                else
                {
                    dt = dsWorkPermitHeader.Tables[6].Copy();
                }

                dt.DefaultView.RowFilter = "WP_Header_ID = " + Convert.ToString(HeadId) + "";
                dt = dt.DefaultView.ToTable();

                if (AnswerType == "SSLCT")
                {
                    RadioButtonList divRadioButtonrdbYes = e.Item.FindControl("divRadioButtonrdbYes") as RadioButtonList;

                    if (dt.Rows.Count > 0)
                    {
                        //rptRadio.DataSource = dt;
                        //rptRadio.DataBind(); 
                        divRadioButtonrdbYes.DataTextField = "Ans_Type_Data"; // "Ans_Type_Desc";
                        divRadioButtonrdbYes.DataValueField = "Ans_Type_Data_ID";  // "Ans_Type_ID";// 
                        divRadioButtonrdbYes.DataSource = dt;
                        divRadioButtonrdbYes.DataBind();
                    }
                    else
                    {
                        DataTable dt1 = new DataTable();
                        //rptRadio.DataSource = dt1;
                        //rptRadio.DataBind();
                        divRadioButtonrdbYes.DataSource = dt;
                        divRadioButtonrdbYes.DataBind();
                    }

                }
                else if (AnswerType == "MSLCT")
                {
                    CheckBoxList divCheckBoxIDI = e.Item.FindControl("divCheckBoxIDI") as CheckBoxList;
                    if (dt.Rows.Count > 0)
                    {
                        //rptRadio.DataSource = dt;
                        //rptRadio.DataBind(); 
                        divCheckBoxIDI.DataTextField = "Ans_Type_Data"; // "Ans_Type_Desc";
                        divCheckBoxIDI.DataValueField = "Ans_Type_Data_ID";  // "Ans_Type_ID";// 
                        divCheckBoxIDI.DataSource = dt;
                        divCheckBoxIDI.DataBind();
                    }
                    else
                    {
                        DataTable dt1 = new DataTable();
                        //rptRadio.DataSource = dt1;
                        //rptRadio.DataBind();
                        divCheckBoxIDI.DataSource = dt;
                        divCheckBoxIDI.DataBind();
                    }
                }

            }
        }

        private void BindSectionHeaderData(int ConfigTitleID)
        {
            sPublicConfigId = ConfigTitleID;
            DataSet dsWorkPermitHeader = new DataSet();

            if (TransLoggedInUserID != "")
            {
                //dsWorkPermitHeader = ObjUpkeep.Bind_WorkPermitSavedConfiguration(ConfigTitleID, Session["TransactionID"].ToString());
                dsWorkPermitHeader = ObjUpkeep.Bind_WorkPermitSavedConfiguration(ConfigTitleID,Convert.ToString(Session["TransactionID"]));

            }
            else
            {
                dsWorkPermitHeader = ObjUpkeep.Bind_WorkPermitConfiguration(ConfigTitleID);
            }

            dsGlobalDataS.Clear();
            dsGlobalDataS = dsWorkPermitHeader.Copy();

            if (dsWorkPermitHeader.Tables[1].Rows.Count > 0)
            {
                rptSectionDetails.DataSource = dsWorkPermitHeader.Tables[1];
                rptSectionDetails.DataBind();
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            int colsCount = 0;
            colsCount = Convert.ToInt32(Session["colsCount"]);
            //GenerateTable(colsCount, 1);
        }


        public bool ValidateData()
        {
            // // Validate Terms and Conditions..
            foreach (RepeaterItem item in rptTermsCondition.Items)
            {
                if (((CheckBox)item.FindControl("chkTermsCondition")).Checked == false)
                {
                    lblErrorMsg1.Text = "Please select all Terms and Conditions";
                    return false;
                }
            }

            // // Validate date..
            if (txtWorkPermitDate.Text == "")
            {
                lblErrorMsg1.Text = "Please select work permit From date.";
                return false;
            }

            // // Validate date..
            if (txtWorkPermitToDate.Text == "")
            {
                lblErrorMsg1.Text = "Please select work permit To date.";
                return false;
            }
            return true;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string WpTitleSelectedID = "";
            WpTitleSelectedID = ddlWorkPermitTitle.SelectedValue;
            if (ValidateData() == false)
            {
                //ddlWorkPermitTitle.SelectedValue = "0";
                //ddlWorkPermitTitle.SelectedValue = WpTitleSelectedID;
                //setWorkPermitData();
                SetRepeater();
                return;
            }

            SaveSectionHeaderData();
        }

        private void SetRepeater()
        {
            foreach (RepeaterItem itemSection in rptSectionDetails.Items)
            {
                string DivId = (itemSection.FindControl("hfCustomerId") as HiddenField).Value;
                Repeater rptHeaderDetails = itemSection.FindControl("rptHeaderDetails") as Repeater;

                foreach (RepeaterItem itemHeader in rptHeaderDetails.Items)
                {
                    // int AnswerType = Convert.ToInt32((itemHeader.FindControl("hdnlblAnswerType") as HiddenField).Value);
                    string AnswerType = (itemHeader.FindControl("hdnAnswerTypeSDesc") as HiddenField).Value;
                    string HeadId = (itemHeader.FindControl("hfHeaderId") as HiddenField).Value;

                    string HeadMandatoryId = (itemHeader.FindControl("hdnIs_Mandatory") as HiddenField).Value;
                    if (HeadMandatoryId == "*")
                    {
                        // Commented by Ajay
                        //Label sample = itemHeader.FindControl("lblIsMandatory") as Label;
                        //sample.Attributes.Remove("style");
                    }

                    if (AnswerType == "MSLCT") //Multi Selection [CheckBox]
                    {
                        HtmlGenericControl sample = itemHeader.FindControl("divCheckBox") as HtmlGenericControl;
                        sample.Attributes.Remove("style");
                    }
                    else if (AnswerType == "SSLCT") //Single Selection [Radio Button]
                    {
                        HtmlGenericControl sample = itemHeader.FindControl("divRadioButton") as HtmlGenericControl;
                        sample.Attributes.Remove("style");
                    }
                    else if (AnswerType == "IMAGE") //Image Upload  
                    {
                        HtmlGenericControl sample = itemHeader.FindControl("divImage") as HtmlGenericControl;
                        sample.Attributes.Remove("style");
                    }
                    else if (AnswerType == "NUMBR") //Number Text Field
                    {
                        HtmlGenericControl sample = itemHeader.FindControl("divNumber") as HtmlGenericControl;
                        sample.Attributes.Remove("style");
                    }
                    else if (AnswerType == "STEXT") //Normal Text Field
                    {
                        HtmlGenericControl sample = itemHeader.FindControl("divText") as HtmlGenericControl;
                        sample.Attributes.Remove("style");
                    }
                    else if (AnswerType == "LTEXT") // Textarea Field
                    {
                        HtmlGenericControl sample = itemHeader.FindControl("divTextArea") as HtmlGenericControl;
                        sample.Attributes.Remove("style");
                    }
                    else  //Normal Text Field
                    {
                        HtmlGenericControl sample = itemHeader.FindControl("divText") as HtmlGenericControl;
                        sample.Attributes.Remove("style");
                    }

                }
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void ddlWorkPermitTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            setWorkPermitData();
        }

        protected void btnSuccessOk_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/WorkPermit/MyWorkPermit.aspx"), false);
        }

        private async void SaveSectionHeaderData()
        {
            try
            {
                #region UserData
                //int WP_ConfigID = Convert.ToInt32(ddlWorkPermitTitle.SelectedValue.ToString());
                int WP_ConfigID = Convert.ToInt32(Convert.ToString(ddlWorkPermitTitle.SelectedValue));
                string LoggedInUser = LoggedInUserID;
                string strWpDate = txtWorkPermitDate.Text;
                string strWpTpDate = txtWorkPermitToDate.Text;
                #endregion


                #region SectionHeader
                /*
                 Create table and store data in table and convert later in xml and pass in to Datatbase..
                 Table Structure : SectionID | HeaderID | AnswerID | Data
                */

                string strWpSectionHeaderData = "";

                DataTable dt = new DataTable();
                dt.Clear();
                dt.TableName = "TableSectionHeader";
                dt.Columns.Add("SectionID");
                dt.Columns.Add("HeaderID");
                dt.Columns.Add("AnswerID");
                dt.Columns.Add("Data");
                // dtRow["SectionID"] = ""; dtRow["HeaderID"] = ""; dtRow["AnswerID"] = ""; dtRow["Data"] = ""; hdnAnswerTypeSDesc

                string Is_Not_Valid = "False";

                foreach (RepeaterItem itemSection in rptSectionDetails.Items)
                {
                    string DivId = (itemSection.FindControl("hfCustomerId") as HiddenField).Value;
                    Repeater rptHeaderDetails = itemSection.FindControl("rptHeaderDetails") as Repeater;

                    foreach (RepeaterItem itemHeader in rptHeaderDetails.Items)
                    {

                        int IAnswerType = Convert.ToInt32((itemHeader.FindControl("hdnlblAnswerType") as HiddenField).Value);
                        string AnswerType = (itemHeader.FindControl("hdnAnswerTypeSDesc") as HiddenField).Value;
                        string Is_Mandatory = Convert.ToString((itemHeader.FindControl("hdnIs_Mandatory") as HiddenField).Value);
                        Label lblHeaderErr = (itemHeader.FindControl("lblHeaderErr") as Label);
                        string isField = "False";

                        // int AnswerTypeData = Convert.ToInt32((itemHeader.FindControl("hdnlblAnswerTypeData") as HiddenField).Value);
                        string HeadId = (itemHeader.FindControl("hfHeaderId") as HiddenField).Value;


                        if (AnswerType == "MSLCT") //Multi Selection [CheckBox]
                        {
                            CheckBoxList divCheckBoxIDI = itemHeader.FindControl("divCheckBoxIDI") as CheckBoxList;
                            List<String> chkStrList = new List<string>();


                            foreach (ListItem item in divCheckBoxIDI.Items)
                            {
                                if (item.Selected)
                                {
                                    isField = "True";

                                    chkStrList.Add(item.Value);
                                    DataRow dtRow = dt.NewRow();
                                    dtRow["SectionID"] = DivId;
                                    dtRow["HeaderID"] = HeadId;
                                    dtRow["AnswerID"] = IAnswerType;
                                    dtRow["Data"] = item.Value;
                                    dt.Rows.Add(dtRow);
                                }
                            }

                            if (Is_Mandatory == "*")
                            {
                                if (isField == "False")
                                {
                                    Is_Not_Valid = "True";
                                    //lblHeaderErr.Text = "Please provide valid data.";
                                    // Ajay 20/03/2021
                                    setWorkPermitData();
                                    dvMandatoryMsg.Visible = true;
                                    //Response.Write("<script>alert('Please provide all valid data.');</script>");
                                    return;
                                }
                            }

                            //String YrStr = String.Join(";", chkStrList.ToArray());
                        }
                        else if (AnswerType == "SSLCT") //Single Selection [Radio Button]
                        {
                            RadioButtonList divRadioButtonrdbYes = itemHeader.FindControl("divRadioButtonrdbYes") as RadioButtonList;
                            List<String> RadioStrList = new List<string>();
                            foreach (ListItem item in divRadioButtonrdbYes.Items)
                            {
                                if (item.Selected)
                                {
                                    isField = "True";
                                    RadioStrList.Add(item.Value);

                                    DataRow dtRow = dt.NewRow();
                                    dtRow["SectionID"] = DivId;
                                    dtRow["HeaderID"] = HeadId;
                                    dtRow["AnswerID"] = IAnswerType;
                                    dtRow["Data"] = item.Value;
                                    dt.Rows.Add(dtRow);
                                }
                            }
                            if (Is_Mandatory == "*")
                            {
                                if (isField == "False")
                                {
                                    Is_Not_Valid = "True";
                                    //lblHeaderErr.Text = "Please provide valid data.";
                                    // Ajay 20/03/2021
                                    setWorkPermitData();
                                    dvMandatoryMsg.Visible = true;
                                    //Response.Write("<script>alert('Please provide all valid data.');</script>");
                                    return;
                                }
                            }
                            //String YrStr = String.Join(";", RadioStrList.ToArray());

                        }
                        else if (AnswerType == "IMAGE") //Image Upload  
                        {
                            HtmlGenericControl sample = itemHeader.FindControl("divImage") as HtmlGenericControl;

                            FileUpload ChecklistImage = (FileUpload)itemHeader.FindControl("FileUpload_ChecklistImage");


                            if (ChecklistImage.HasFile)
                            {
                                List<int> Lst_ValidImage = new List<int>();
                                List<int> Lst_ImageSaved = new List<int>();
                                List<string> Lst_Images = new List<string>();
                                string CurrentDate = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));
                                string fileName = string.Empty;

                                string fileUploadPath = HttpContext.Current.Server.MapPath("~/WorkPermitImages/" + CurrentDate);
                                if (!Directory.Exists(fileUploadPath))
                                {
                                    Directory.CreateDirectory(fileUploadPath);
                                }

                                int i = 0;

                                foreach (HttpPostedFile postfiles in ChecklistImage.PostedFiles)
                                {
                                    string filetype = Path.GetExtension(postfiles.FileName);
                                    if (filetype.ToLower() == ".jpg" || filetype.ToLower() == ".png")
                                    {
                                        Lst_ValidImage.Add(1);
                                    }
                                    else
                                    {
                                        Lst_ValidImage.Add(0);
                                    }
                                }
                                foreach (HttpPostedFile postfiles in ChecklistImage.PostedFiles)
                                {
                                    string filetype = Path.GetExtension(postfiles.FileName);
                                    if (filetype.ToLower() == ".jpg" || filetype.ToLower() == ".png")
                                    {
                                        try
                                        {
                                            fileName = DivId + "_" + HeadId + "_" + AnswerType + "_" + Convert.ToString(i) + filetype;
                                            string imgPath = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadURL"]);
                                            string SaveLocation = Server.MapPath("~/WorkPermitImages/" + CurrentDate) + "/" + fileName;
                                            string FileLocation = imgPath + "/WorkPermitImages/" + CurrentDate + "/" + fileName;// + "*WP";
                                            string ImageName = Path.GetFileName(postfiles.FileName);
                                            Stream strm = postfiles.InputStream;  //FileUpload_TicketImage.PostedFile.InputStream;
                                            var targetFile = SaveLocation;

                                            if (!Lst_ValidImage.Contains(0))
                                            {
                                                postfiles.SaveAs(SaveLocation);
                                                Lst_Images.Add(FileLocation);

                                                isField = "True";
                                                DataRow dtRow = dt.NewRow();
                                                dtRow["SectionID"] = DivId;
                                                dtRow["HeaderID"] = HeadId;
                                                dtRow["AnswerID"] = IAnswerType;
                                                dtRow["Data"] = FileLocation;
                                                dt.Rows.Add(dtRow);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Lst_ImageSaved.Add(0); // Image failed to save
                                            throw ex;
                                        }
                                    }
                                    else
                                    {
                                        Lst_ValidImage.Add(0);  // image extension is not proper
                                    }
                                    i = i + 1;
                                }
                            }


                            if (Is_Mandatory == "*")
                            {
                                if (isField == "False")
                                {
                                    Is_Not_Valid = "True";
                                    //lblHeaderErr.Text = "Please provide valid data.";
                                    // Ajay 20/03/2021
                                    setWorkPermitData();
                                    dvMandatoryMsg.Visible = true;
                                    //Response.Write("<script>alert('Please provide all valid data.');</script>");
                                    return;
                                }
                            }

                        }
                        else if (AnswerType == "NUMBR") //Number Text Field
                        {
                            HtmlGenericControl sample = itemHeader.FindControl("divNumber") as HtmlGenericControl;
                            string txtNum = sample.Controls[1].UniqueID;
                            string sVal = Request.Form.GetValues(txtNum)[0];
                            DataRow dtRow = dt.NewRow();
                            dtRow["SectionID"] = DivId;
                            dtRow["HeaderID"] = HeadId;
                            dtRow["AnswerID"] = IAnswerType;
                            dtRow["Data"] = sVal;
                            dt.Rows.Add(dtRow);

                            // Ajay 20/03/2021
                            if (sVal != "")
                            {
                                isField = "True";
                            }

                            if (Is_Mandatory == "*")
                            {
                                if (isField == "False")
                                {
                                    Is_Not_Valid = "True";
                                    //lblHeaderErr.Text = "Please provide valid data.";
                                    // Ajay 20/03/2021
                                    setWorkPermitData();
                                    dvMandatoryMsg.Visible = true;
                                    //Response.Write("<script>alert('Please provide all valid data.');</script>");
                                    return;
                                }
                            }

                        }
                        else if (AnswerType == "STEXT") //Normal Text Field
                        {
                            HtmlGenericControl sample = itemHeader.FindControl("divText") as HtmlGenericControl;
                            string txtNum = sample.Controls[1].UniqueID;
                            string sVal = Request.Form.GetValues(txtNum)[0];
                            DataRow dtRow = dt.NewRow();
                            dtRow["SectionID"] = DivId;
                            dtRow["HeaderID"] = HeadId;
                            dtRow["AnswerID"] = IAnswerType;
                            dtRow["Data"] = sVal;
                            dt.Rows.Add(dtRow);
                            // Ajay 20/03/2021
                            if (sVal != "")
                            {
                                isField = "True";
                            }

                            if (Is_Mandatory == "*")
                            {
                                if (isField == "False")
                                {
                                    Is_Not_Valid = "True";
                                    //lblHeaderErr.Text = "Please provide valid data.";
                                    // Ajay 20/03/2021
                                    setWorkPermitData();
                                    dvMandatoryMsg.Visible = true;
                                    //LabelERRORmsg.Text = "Please provide all valid data.";
                                    //divUpdateButton.Attributes.Add("style", "display:block;");
                                    //Response.Write("<script>alert('Please provide all valid data.');</script>");
                                    return;
                                }
                            }
                        }
                        else if (AnswerType == "LTEXT") // Textarea Field
                        {
                            HtmlGenericControl sample = itemHeader.FindControl("divTextArea") as HtmlGenericControl;
                            string txtNum = sample.Controls[1].UniqueID;
                            string sVal = Request.Form.GetValues(txtNum)[0];
                            DataRow dtRow = dt.NewRow();
                            dtRow["SectionID"] = DivId;
                            dtRow["HeaderID"] = HeadId;
                            dtRow["AnswerID"] = IAnswerType;
                            dtRow["Data"] = sVal;
                            dt.Rows.Add(dtRow);

                            // Ajay 20/03/2021
                            if (sVal != "")
                            {
                                isField = "True";
                            }

                            if (Is_Mandatory == "*")
                            {
                                if (isField == "False")
                                {
                                    Is_Not_Valid = "True";
                                    // Ajay 20/03/2021
                                    //lblHeaderErr.Text = "Please provide valid data.";
                                    setWorkPermitData();
                                    dvMandatoryMsg.Visible = true;
                                    //Response.Write("<script>alert('Please provide all valid data.');</script>");
                                    return;
                                }
                            }
                        }
                        else  //Normal Text Field
                        {
                            HtmlGenericControl sample = itemHeader.FindControl("divText") as HtmlGenericControl;
                            string txtNum = sample.Controls[1].UniqueID;
                            string sVal = Request.Form.GetValues(txtNum)[0];
                            DataRow dtRow = dt.NewRow();
                            dtRow["SectionID"] = DivId;
                            dtRow["HeaderID"] = HeadId;
                            dtRow["AnswerID"] = IAnswerType;
                            dtRow["Data"] = sVal;
                            dt.Rows.Add(dtRow);

                            // Ajay 20/03/2021
                            if (sVal != "")
                            {
                                isField = "True";
                            }

                            if (Is_Mandatory == "*")
                            {
                                if (isField == "False")
                                {
                                    Is_Not_Valid = "True";
                                    lblHeaderErr.Text = "Please provide valid data.";
                                    // Ajay 20/03/2021
                                    setWorkPermitData();
                                    dvMandatoryMsg.Visible = true;
                                    //Response.Write("<script>alert('Please provide all valid data.');</script>");
                                    return;
                                   
                                }
                            }
                        }
                    }
                }


                if (Is_Not_Valid == "True")
                {
                    return;
                }

                if (dt.Rows.Count > 0)
                {
                    DataTable DTS = new DataTable();
                    DTS = dt.Copy();

                    MemoryStream str = new MemoryStream();
                    DTS.WriteXml(str, true);
                    str.Seek(0, SeekOrigin.Begin);
                    StreamReader sr = new StreamReader(str);
                    string xmlstr;
                    xmlstr = sr.ReadToEnd();
                    strWpSectionHeaderData = xmlstr;
                }
                #endregion


                #region SaveDataToDB
                DataSet dsWPHeaderData = new DataSet();
                dsWPHeaderData = ObjUpkeep.Insert_WorkPermitRequest(WP_ConfigID, LoggedInUserID, strWpDate, strWpTpDate, strWpSectionHeaderData);

                if (dsWPHeaderData.Tables.Count > 0)
                {
                    if (dsWPHeaderData.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsWPHeaderData.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            //[+][Ajay Prajapati]
                            if (dsWPHeaderData.Tables.Count > 1)
                            {
                                string NotificationHeader = string.Empty;
                                string NotificationMsg = string.Empty;
                                int TransactionID = 0;
                                string StoreManager_Name = string.Empty;
                                string Store_Name = string.Empty;
                                string Employee_Name = string.Empty;
                                string Emp_Department = string.Empty;
                                string TicketNo = string.Empty;

                                TransactionID = Convert.ToInt32(dsWPHeaderData.Tables[1].Rows[0]["TransactionID"]);
                                StoreManager_Name = Convert.ToString(dsWPHeaderData.Tables[1].Rows[0]["StoreManager_Name"]);
                                Store_Name = Convert.ToString(dsWPHeaderData.Tables[1].Rows[0]["Store_Name"]);
                                Employee_Name = Convert.ToString(dsWPHeaderData.Tables[1].Rows[0]["Employee_Name"]);
                                Emp_Department = Convert.ToString(dsWPHeaderData.Tables[1].Rows[0]["Emp_Department"]);
                                TicketNo = Convert.ToString(dsWPHeaderData.Tables[1].Rows[0]["TicketNo"]);

                                NotificationHeader = "Work Permit ID " + TicketNo + ". New Request Received. ";

                                if (StoreManager_Name != "")
                                {
                                    NotificationMsg = "A Work Permit has been raised by " + StoreManager_Name + " from " + Store_Name + " store. Tap to take Action";
                                }
                                else
                                {
                                    NotificationMsg = "A Work Permit has been raised by " + Employee_Name + " from " + Emp_Department + " department. Tap to take Action";
                                }

                                foreach (DataRow dr in dsWPHeaderData.Tables[2].Rows)
                                {
                                    var TokenNO = Convert.ToString(dr["TokenNumber"]);
                                    int Is_App_Notification_Send = Convert.ToInt32(dr["Is_App_Notification_Send"]);
                                    //await SendNotification(TokenNO, Convert.ToString(dsWPHeaderData.Tables[0].Rows[0]["RequestID"]), "New WorkPermit Request");
                                    if (Is_App_Notification_Send > 0)
                                    {
                                        await SendNotification(TokenNO, TransactionID, NotificationHeader, NotificationMsg);
                                    }
                                }
                            }
                            //[-][Ajay Prajapati]
                            SetRepeater();
                            btnSubmit.Visible = false;
                            lblWpRequestCode.InnerText = Convert.ToString(dsWPHeaderData.Tables[1].Rows[0]["TicketNo"]);
                            mpeWpRequestSaveSuccess.Show();
                        }
                        else
                        {
                            SetRepeater();
                            lblErrorMsg1.Text = "Something went wrong. Please Try again by Clicking on SUBMIT !!!";
                            btnSubmit.Focus();
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void setWorkPermitData()
        {
            DataSet dsConfig = new DataSet();
            int ConfigTitleID = 0;

            try
            {
                //lblRequestDate.Text = DateTime.Now.ToString("dd/MMM/yyyy hh:mm tt");

                ConfigTitleID = Convert.ToInt32(ddlWorkPermitTitle.SelectedValue);
                if (TransLoggedInUserID != "")
                {
                    dsConfig = ObjUpkeep.Bind_WorkPermitRequestDetails(ConfigTitleID, TransLoggedInUserID);
                }
                else
                {
                    dsConfig = ObjUpkeep.Bind_WorkPermitRequestDetails(ConfigTitleID, LoggedInUserID);
                }


                if (dsConfig.Tables.Count > 1)
                {

                    string strUserType = Convert.ToString(dsConfig.Tables[1].Rows[0]["UserType"]);
                    if (strUserType == "E")
                    {
                        dvEmployee.Attributes.Add("style", "display:block;");
                        dvRetailer.Attributes.Add("style", "display:none;");
                    }
                    else
                    {
                        dvEmployee.Attributes.Add("style", "display:none;");
                        dvRetailer.Attributes.Add("style", "display:block;");
                    }

                    if (dsConfig.Tables.Count > 0)
                    {
                        if (dsConfig.Tables[1].Rows.Count > 0)
                        {
                            if (strUserType == "E")
                            {
                                lblEmpName.Text = Convert.ToString(dsConfig.Tables[1].Rows[0]["Name"]);
                                lblEmpCode.Text = Convert.ToString(dsConfig.Tables[1].Rows[0]["Code"]);
                                lblMobileNo.Text = Convert.ToString(dsConfig.Tables[1].Rows[0]["Mobile"]);
                                LblEmailID.Text = Convert.ToString(dsConfig.Tables[1].Rows[0]["Email"]);
                            }
                            else
                            {
                                lblStoreName.Text = Convert.ToString(dsConfig.Tables[1].Rows[0]["Retail_Store_Name"]);
                                lblRetailerName.Text = Convert.ToString(dsConfig.Tables[1].Rows[0]["Store_Mger_Name"]);
                                lblMobileNo.Text = Convert.ToString(dsConfig.Tables[1].Rows[0]["Contact"]);
                                LblEmailID.Text = Convert.ToString(dsConfig.Tables[1].Rows[0]["Email"]);
                            }
                        }
                    }
                }

                if (dsConfig.Tables.Count > 1)
                {
                    if (dsConfig.Tables[2].Rows.Count > 0)
                    {
                        //GenerateTableHeader(ConfigTitleID);
                        BindSectionHeaderData(ConfigTitleID);
                    }
                }

                // GenerateTableHeader(ConfigTitleID);

                if (dsConfig.Tables.Count > 3)
                {
                }

                if (dsConfig.Tables.Count > 4)
                {
                    rptTermsCondition.DataSource = dsConfig.Tables[4];
                    rptTermsCondition.DataBind();
                }

                if (dsConfig.Tables.Count > 5)
                {
                    gvApprovalMatrix.DataSource = dsConfig.Tables[5];
                    gvApprovalMatrix.DataBind();

                    if (Convert.ToInt32(dsConfig.Tables[0].Rows[0]["ShowApprovalMatrix_Initiators"]) == 0)
                    {
                        dvApprovalMatrix.Attributes.Add("style", "display:none;");
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FetchSectionHeaderData(string TransID)
        {
            try
            {
                DataSet dsData = new DataSet();
                dsData = ObjUpkeep.Fetch_WorkPermitRequestSavedData(0, TransID, LoggedInUserID);


                if (dsData.Tables.Count > 0)
                {
                    TransLoggedInUserID = Convert.ToString(dsData.Tables[0].Rows[0]["UID"]);
                    TransInitiator = Convert.ToString(dsData.Tables[0].Rows[0]["U_Init"]);
                    BindWorkPermitTitle();

                    if (dsData.Tables[3].Rows.Count > 0)
                    {
                        ddlAction.DataSource = dsData.Tables[3];
                        ddlAction.DataTextField = "Action_Desc";
                        ddlAction.DataValueField = "ActionID";
                        ddlAction.DataBind();
                        ddlAction.Items.Insert(0, new ListItem("--Select--", "0"));
                    }

                    if (dsData.Tables[0].Rows.Count > 0)
                    {
                        ddlWorkPermitTitle.SelectedValue = dsData.Tables[0].Rows[0]["WP_Config_ID"].ToString();
                        setWorkPermitData();

                        //txtWorkPermitDate.Text = dsData.Tables[0].Rows[0]["Wp_Date"].ToString();
                        txtWorkPermitDate.Text = Convert.ToString(dsData.Tables[0].Rows[0]["Wp_Date"]);

                        //txtWorkPermitToDate.Text = dsData.Tables[0].Rows[0]["Wp_To_Date"].ToString();
                        txtWorkPermitToDate.Text = Convert.ToString(dsData.Tables[0].Rows[0]["Wp_To_Date"]);


                        //lblTicketNo.Visible = true;
                        div_WorkPermit_Details_top.Visible = true;
                        //lblTicket.Text = dsData.Tables[0].Rows[0]["TicketNo"].ToString();
                        lblTicketNo.InnerText = Convert.ToString(dsData.Tables[0].Rows[0]["TicketNo"]);
                        
                        //switch (dsData.Tables[0].Rows[0]["WP_Status"].ToString())
                        switch (Convert.ToString(dsData.Tables[0].Rows[0]["WP_Status"]))
                        {
                            case "Close":
                                lblRequestStatus1.InnerText = "Closed";
                                lblRequestStatus1.Attributes.Add("class", "m-badge m-badge--info m-badge--wide");
                                break;
                            case "Expired":
                                lblRequestStatus1.InnerText = "Expired";
                                lblRequestStatus1.Attributes.Add("class", "m-badge m-badge--metal m-badge--wide");
                                lblRequestStatus1.Attributes.Add("style", "color:blank");

                                break;
                            case "Open":
                                lblRequestStatus1.InnerText = "Open";
                                lblRequestStatus1.Attributes.Add("class", "m-badge m-badge--danger m-badge--wide");
                                break;
                            case "Reject":
                                lblRequestStatus1.InnerText = "Rejected";
                                lblRequestStatus1.Attributes.Add("class", "m-badge m-badge--warning m-badge--wide");
                                break;
                            case "Approve":
                                lblRequestStatus1.InnerText = "Approved";
                                lblRequestStatus1.Attributes.Add("class", "m-badge m-badge--success m-badge--wide");
                                break;
                        }

                        foreach (RepeaterItem itemSection in rptSectionDetails.Items)
                        {
                            string DivId = (itemSection.FindControl("hfCustomerId") as HiddenField).Value;
                            Repeater rptHeaderDetails = itemSection.FindControl("rptHeaderDetails") as Repeater;

                            foreach (RepeaterItem itemHeader in rptHeaderDetails.Items)
                            {
                                //int AnswerType = Convert.ToInt32((itemHeader.FindControl("hdnlblAnswerType") as HiddenField).Value);
                                string AnswerType = (itemHeader.FindControl("hdnAnswerTypeSDesc") as HiddenField).Value;
                                string HeadId = (itemHeader.FindControl("hfHeaderId") as HiddenField).Value;

                                DataTable dta = new DataTable();
                                dta = dsData.Tables[2].Copy();
                                dta.DefaultView.RowFilter = "WP_Section_ID = " + Convert.ToString(DivId) + " AND WP_Header_ID =" + Convert.ToString(HeadId) + "  ";
                                dta = dta.DefaultView.ToTable();

                                if (dta.Rows.Count > 0)
                                {
                                    if (AnswerType == "MSLCT") //Multi Selection [CheckBox]
                                    {
                                        CheckBoxList divCheckBoxIDI = itemHeader.FindControl("divCheckBoxIDI") as CheckBoxList;

                                        for (int i = 0; i < divCheckBoxIDI.Items.Count; i++)
                                        {
                                            for (int j = 0; j < dta.Rows.Count; j++)
                                            {
                                                string vals = divCheckBoxIDI.Items[i].Value;

                                                //if (vals == dta.Rows[j]["Header_Data"].ToString())
                                                if (vals == dta.Rows[j]["Header_Data"].ToString())
                                                {
                                                    divCheckBoxIDI.Items[i].Selected = true;
                                                }
                                                divCheckBoxIDI.Items[i].Enabled = false;
                                            }
                                            divCheckBoxIDI.Attributes.Add("Enabled", "false");
                                        }

                                    }
                                    else if (AnswerType == "SSLCT") //Single Selection [Radio Button]
                                    {
                                        RadioButtonList divRadioButtonrdbYes = itemHeader.FindControl("divRadioButtonrdbYes") as RadioButtonList;

                                        for (int i = 0; i < divRadioButtonrdbYes.Items.Count; i++)
                                        {
                                            for (int j = 0; j < dta.Rows.Count; j++)
                                            {
                                                string vals = divRadioButtonrdbYes.Items[i].Value;
                                                if (vals == dta.Rows[j]["Header_Data"].ToString())
                                                {
                                                    divRadioButtonrdbYes.Items[i].Selected = true;
                                                }
                                                divRadioButtonrdbYes.Items[i].Enabled = false;
                                            }
                                            divRadioButtonrdbYes.Attributes.Add("Enabled", "false");
                                        }
                                    }
                                    else if (AnswerType == "IMAGE") //Image Upload  
                                    {
                                        HtmlGenericControl sample = itemHeader.FindControl("divImage") as HtmlGenericControl;
                                        FileUpload ChecklistImage = (FileUpload)itemHeader.FindControl("FileUpload_ChecklistImage");

                                        DataTable dtImg = new DataTable();
                                        dtImg = dta.Copy();
                                        dtImg.DefaultView.RowFilter = "IMAGEPATH <> '' ";
                                        dtImg.DefaultView.ToTable();

                                        string vals = "";
                                        for (int j = 0; j < dtImg.Rows.Count; j++)
                                        {
                                            if (j == 0)
                                            {
                                                vals = Convert.ToString(dtImg.Rows[j]["IMAGEPATH"]);
                                            }
                                            else
                                            {
                                                vals = "," + Convert.ToString(dtImg.Rows[j]["IMAGEPATH"]);
                                            }
                                        }

                                        ChecklistImage.Attributes.Add("style", "display:none;");

                                        HiddenField hdImg = itemHeader.FindControl("hdnImg") as HiddenField;
                                        hdImg.Value = vals;


                                        HtmlGenericControl divsImgBtns = itemHeader.FindControl("divImgBtns") as HtmlGenericControl;
                                        divsImgBtns.Attributes.Remove("style");

                                        //Button BtnDivImg = itemHeader.FindControl("btnImg") as Button;
                                        //BtnDivImg.Attributes.Remove("data-images");
                                        //BtnDivImg.Attributes.Add("data-images", vals);

                                    }
                                    else if (AnswerType == "NUMBR") //Number Text Field
                                    {
                                        HtmlGenericControl sample = itemHeader.FindControl("divNumber") as HtmlGenericControl;
                                        string txtNum = sample.Controls[1].UniqueID;
                                        //string sVal = Request.Form.GetValues(txtNum)[0];


                                        HtmlInputGenericControl tb = FindControl(txtNum) as HtmlInputGenericControl;
                                        tb.Value = Convert.ToString(dta.Rows[0]["Header_Data"]);
                                        tb.Attributes.Add("Disabled", "true");
                                        //Request.Form.Set(txtNum, dta.Rows[0]["Header_Data"].ToString());
                                    }
                                    else if (AnswerType == "STEXT") //Normal Text Field
                                    {
                                        HtmlGenericControl sample = itemHeader.FindControl("divText") as HtmlGenericControl;
                                        string txtNum = sample.Controls[1].UniqueID;
                                        //string sVal = Request.Form.GetValues(txtNum)[0];

                                        HtmlInputText tb = FindControl(txtNum) as HtmlInputText;
                                        //tb.Value = dta.Rows[0]["Header_Data"].ToString();

                                        tb.Value = Convert.ToString(dta.Rows[0]["Header_Data"]);
                                        tb.Attributes.Add("Disabled", "true");
                                        //Request.Form.Set(txtNum, dta.Rows[0]["Header_Data"].ToString());
                                    }
                                    else if (AnswerType == "LTEXT") // Textarea Field
                                    {
                                        HtmlGenericControl sample = itemHeader.FindControl("divTextArea") as HtmlGenericControl;
                                        string txtNum = sample.Controls[1].UniqueID;
                                        // string sVal = Request.Form.GetValues(txtNum)[0];

                                        HtmlTextArea tb = FindControl(txtNum) as HtmlTextArea;
                                        tb.Value = Convert.ToString(dta.Rows[0]["Header_Data"]);

                                        //tb.Value = dta.Rows[0]["Header_Data"].ToString();
                                        tb.Attributes.Add("Disabled", "true");
                                        //Request.Form.Set(txtNum, dta.Rows[0]["Header_Data"].ToString());
                                    }
                                    else  //Normal Text Field
                                    {
                                        HtmlGenericControl sample = itemHeader.FindControl("divText") as HtmlGenericControl;
                                        string txtNum = sample.Controls[1].UniqueID;
                                        //string sVal = Request.Form.GetValues(txtNum)[0];

                                        HtmlInputGenericControl tb = FindControl(txtNum) as HtmlInputGenericControl;
                                        tb.Value = dta.Rows[0]["Header_Data"].ToString();
                                        tb.Attributes.Add("Disabled", "true");
                                        //Request.Form.Set(txtNum, dta.Rows[0]["Header_Data"].ToString());
                                    }
                                }
                            }
                        }


                    }

                    if (dsData.Tables.Count > 1)
                    {

                        if (dsData.Tables.Count > 0)
                        {
                            if (dsData.Tables[1].Rows.Count > 0)
                            {
                                string strUserType = Convert.ToString(dsData.Tables[1].Rows[0]["UserType"]);
                                if (strUserType == "E")
                                {
                                    dvEmployee.Attributes.Add("style", "display:block;");
                                    dvRetailer.Attributes.Add("style", "display:none;");
                                }
                                else
                                {
                                    dvEmployee.Attributes.Add("style", "display:none;");
                                    dvRetailer.Attributes.Add("style", "display:block;");
                                }

                                if (strUserType == "E")
                                {
                                    lblEmpName.Text = Convert.ToString(dsData.Tables[1].Rows[0]["EmpName"]);
                                    lblEmpCode.Text = Convert.ToString(dsData.Tables[1].Rows[0]["EmpCode"]);
                                    lblMobileNo.Text = Convert.ToString(dsData.Tables[1].Rows[0]["EmpMobileNo"]);
                                    LblEmailID.Text = Convert.ToString(dsData.Tables[1].Rows[0]["EmpEmail"]);
                                }
                                else
                                {
                                    lblStoreName.Text = Convert.ToString(dsData.Tables[1].Rows[0]["Retail_Store_Name"]);
                                    lblRetailerName.Text = Convert.ToString(dsData.Tables[1].Rows[0]["Store_Mger_Name"]);
                                    lblMobileNo.Text = Convert.ToString(dsData.Tables[1].Rows[0]["Contact"]);
                                    LblEmailID.Text = Convert.ToString(dsData.Tables[1].Rows[0]["Email"]);
                                }
                            }
                        }
                    }

                    if (dsData.Tables.Count > 3)
                    {
                        if (dsData.Tables[4].Rows.Count > 0)
                        {
                            gvApprovalHistory.DataSource = dsData.Tables[4];
                            gvApprovalHistory.DataBind();

                        }
                        else
                        {
                            dvApprovalHistory.Attributes.Add("style", "display:none;");

                        }

                    }

                    if (dsData.Tables[5].Rows.Count > 0)
                    {
                        MyActionCompeletd = Convert.ToString(dsData.Tables[5].Rows[0]["IsComplete"]);
                    }

                }



                //Disable controls
                ModifyControls();

                if (MyActionFlag == "1")
                {

                    //dvApprovalDetHeader.Attributes.Add("Style", "display:block;");
                    //dvApprovalDetails.Attributes.Add("Style", "display:block;");
                    //dvSubmitSection.Attributes.Add("Style", "display:block;");

                    if (MyActionCompeletd != "")
                    {
                        dvApprovalDetails.Attributes.Add("style", "display:none;");
                        dvApprovalDetHeader.Attributes.Add("Style", "display:none;");
                        divUpdateButton.Attributes.Add("style", "display:none;");
                    }
                    else if (dsData.Tables[3].Rows.Count == 0)
                    {
                        dvApprovalDetails.Attributes.Add("style", "display:none;");
                        dvApprovalDetHeader.Attributes.Add("Style", "display:none;");
                        divUpdateButton.Attributes.Add("style", "display:none;");
                    }

                    if (Convert.ToInt32(dsData.Tables[0].Rows[0]["ShowApprovalMatrix_Approvers"]) == 0)
                    {
                        dvApprovalMatrix.Attributes.Add("style", "display:none;");
                    }

                }
                else
                {
                    //dvApprovalHistory.Attributes.Add("style", "display:none;");
                    dvApprovalDetails.Attributes.Add("style", "display:none;");
                    dvApprovalDetHeader.Attributes.Add("Style", "display:none;");
                    divUpdateButton.Attributes.Add("style", "display:none;");
                    //dvApprovalDetails.Attributes.Add("Style", "display:none;");
                    //dvSubmitSection.Attributes.Add("Style", "display:none;"); ;

                    if (Convert.ToInt32(dsData.Tables[0].Rows[0]["ShowApprovalMatrix_Initiators"]) == 0)
                    {
                        dvApprovalMatrix.Attributes.Add("style", "display:none;");
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected async void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                int TransactionID = 0;
                if (Convert.ToString(Session["TransactionID"]) != "")
                {
                    TransactionID = Convert.ToInt32(Session["TransactionID"]);
                }
                else
                {
                    Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
                }

                if (ddlAction.SelectedIndex < 1)
                {
                    LabelERRORmsg.Text = "Please enter Proper Action type";
                    divUpdateButton.Attributes.Add("style", "display:block;");
                    return;
                }
                if (txtRemarks.Text.Trim() == "")
                {
                    LabelERRORmsg.Text = "Please enter remarks";
                    divUpdateButton.Attributes.Add("style", "display:block;");
                    return;
                }
                string ActionStatus = string.Empty;
                ActionStatus = Convert.ToString(ddlAction.SelectedItem.Text);
                DataSet dsWPAction = new DataSet();
                dsWPAction = ObjUpkeep.Update_WorkPermitRequest(TransactionID, LoggedInUserID, ActionStatus, txtRemarks.Text);

                if (dsWPAction.Tables.Count > 0)
                {
                    if (dsWPAction.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsWPAction.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            //[+][Ajay]
                            if (dsWPAction.Tables.Count > 1)
                            {
                                if (dsWPAction.Tables[1].Rows.Count > 0)
                                {
                                    string NotificationHeader = string.Empty;
                                    string NotificationMsg = string.Empty;
                                    string TicketNo = string.Empty;
                                    string CurrentLevel = string.Empty;

                                    TicketNo = Convert.ToString(dsWPAction.Tables[1].Rows[0]["TicketNo"]);
                                    CurrentLevel = Convert.ToString(dsWPAction.Tables[1].Rows[0]["CurrentLevel"]);

                                    NotificationHeader = "Work Permit ID " + TicketNo + ".";
                                    NotificationMsg = "A Work Permit approved at Level " + CurrentLevel + " is now pending in your Account. Tap to take Action.";

                                    if (ActionStatus == "Approve")
                                    {
                                        foreach (DataRow dr in dsWPAction.Tables[1].Rows)
                                        {
                                            var TokenNO = Convert.ToString(dr["TokenNumber"]);
                                            int Is_App_Notification_Send = Convert.ToInt32(dr["Is_App_Notification_Send"]);
                                            //await SendNotification(TokenNO, Convert.ToString(lblTicket.Text), "New WorkPermit Request");
                                            if (Is_App_Notification_Send > 0)
                                            {
                                                await SendNotification(TokenNO, Convert.ToInt32(Session["TransactionID"]), NotificationHeader, NotificationMsg);
                                            }
                                        }
                                    }
                                }
                            }
                            //[-][Ajay]
                            Response.Redirect(Page.ResolveClientUrl(Convert.ToString(Session["PreviousURL"])), false);
                            //lblWpRequestCode.Text = Convert.ToString(dsWPAction.Tables[1].Rows[0]["RequestID"]);
                            //mpeWpRequestSaveSuccess.Show();
                        }
                        else if (Status == 2)
                        {
                            LabelERRORmsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void ModifyControls()
        {
            btnSubmit.Attributes.Add("style", "display:none;");
            divUpdateButton.Attributes.Remove("style");
            //dvApprovalDetails.Attributes.Add("style", "display:Block;");
            btnSubmit.Attributes.Add("style", "display:none;");
            //ddlWorkPermitTitle.Attributes.Add("Enabled", "False");
            //txtWorkPermitDate.Attributes.Add("Enabled", "False");
            ddlWorkPermitTitle.Attributes.Add("disabled", "disabled");
            txtWorkPermitDate.Attributes.Add("disabled", "disabled");
            txtWorkPermitToDate.Attributes.Add("disabled", "disabled");
            //Select ALL TermsCondition

            foreach (RepeaterItem itemTerms in rptTermsCondition.Items)
            {
                CheckBox divCheckBoxIDI = itemTerms.FindControl("chkTermsCondition") as CheckBox;
                divCheckBoxIDI.Checked = true;
                divCheckBoxIDI.Attributes.Add("Enabled", "false");
            }
        }

        //private void GenerateTableHeader(int ConfigTitleID)
        //{
        //    sPublicConfigId = ConfigTitleID;

        //    int WorkPermitTitleID = 0;
        //    int colsCount = 0;
        //    string WPHeader = string.Empty;
        //    int SequenceID = 0;
        //    WorkPermitTitleID = ConfigTitleID;

        //    DataSet dsWorkPermitHeader = new DataSet();
        //    dsWorkPermitHeader = ObjUpkeep.Bind_WorkPermitConfiguration(WorkPermitTitleID);



        //    if (dsWorkPermitHeader.Tables[1].Rows.Count > 0)
        //    {
        //        rptSectionDetails.DataSource = dsWorkPermitHeader.Tables[1];
        //        rptSectionDetails.DataBind();
        //    }


        //    // Now iterate through the table and add your controls 
        //    //HtmlTableCell cell = new HtmlTableCell();


        //    //BIND TABLE TO lbReport

        //    StringBuilder sb = new StringBuilder();

        //    int iSection = 0;
        //    iSection = Convert.ToInt32(dsWorkPermitHeader.Tables[1].Rows.Count);


        //    for (int k = 0; k < iSection; k++)
        //    {
        //        string wpTableName = "tblWorkPermitHeader" + Convert.ToString(k+1);
        //        string wpTableID = "tblWorkPermitHeader" + Convert.ToString(k + 1);
        //        string wpDivID = "DivWorkPermitHeader" + Convert.ToString(k + 1);
        //        string wpDivScrollID = "DivWpScroll" + Convert.ToString(k + 1);
        //        string wpBtnAddNewID = "tblWorkPermitHeader" +Convert.ToString(k + 1);

        //        string sSection = Convert.ToString(dsWorkPermitHeader.Tables[1].Rows[k]["WP_Section_Desc"]);


        //        DataTable dt = new DataTable();
        //        dt = dsWorkPermitHeader.Tables[2].Copy();
        //        dt.DefaultView.RowFilter = "WP_Section_ID = "+ Convert.ToString(dsWorkPermitHeader.Tables[1].Rows[k]["WP_Section_ID"]) + "";
        //        dt = dt.DefaultView.ToTable();

        //        colsCount = Convert.ToInt32(dt.Rows.Count);
        //        Session["colsCount"] = Convert.ToString(colsCount);

        //        sb.Append("<div class='form-group row' style='background-color: #00c5dc;' id = '"+ wpDivID + "' >");
        //        sb.Append("<label class='auto-style1' style='color: #ffffff; margin-top: 1%;'> " + sSection + "  </label>");
        //        sb.Append("</div>");
        //        sb.Append("<div class='m-portlet__body'  id = '" + wpDivScrollID + "' style='overflow-x: scroll;'>");

        //        if (dt.Rows.Count > 0)
        //        {
        //            sb.Append("<table class='table table-striped- table-bordered table-hover table-checkable' style='width: 100%' border='1' runat='server' id='" + wpTableID + "'>");

        //            for (int i = 0; i < 1; i++)
        //            {
        //                //HtmlTableRow row = new HtmlTableRow(); 
        //                sb.Append("<TR>");

        //                for (int j = 0; j < colsCount; j++)
        //                {
        //                    WPHeader = Convert.ToString(dt.Rows[j]["Header_Name"]);
        //                    Label lbl = new Label();
        //                    // Set a unique ID for each TextBox added
        //                    lbl.ID = "lbl_" + SequenceID;
        //                    lbl.Text = WPHeader;

        //                    sb.Append("<td >");
        //                    sb.Append("<span id='" + lbl.ID + "' class='form-control-label'>" + lbl.Text + "</span>");
        //                    sb.Append("</td>");

        //                    SequenceID = SequenceID + 1;
        //                }
        //                Label lblAction = new Label();
        //                lblAction.ID = "lblAction";
        //                lblAction.Text = "Action";
        //                sb.Append("<td>");
        //                sb.Append("<span id='" + lblAction.ID + "' class='form-control-label'>" + lblAction.Text + "</span>");
        //                sb.Append("</td>");

        //                sb.Append("</TR>");
        //            }

        //            for (int i = 0; i < 1; i++)
        //            {
        //                sb.Append("<TR style='display:none;'>");
        //                for (int j = 0; j < colsCount; j++)
        //                {
        //                    WPHeader = Convert.ToString(dt.Rows[j]["WP_Header_ID"]);
        //                    //TextBox tb = new TextBox();
        //                    Label lbl = new Label();
        //                    // Set a unique ID for each TextBox added
        //                    lbl.ID = "lbl_ID_" + SequenceID;
        //                    lbl.Text = WPHeader;
        //                    sb.Append("<td>");
        //                    sb.Append("<span id='" + lbl.ID + "' class='form-control-label'>" + lbl.Text + "</span>");
        //                    sb.Append("</td>");

        //                    SequenceID = SequenceID + 1;
        //                }
        //                Label lblAction = new Label();
        //                lblAction.ID = "ColHeaderID";
        //                //lblAction.Text = "Action";  
        //                sb.Append("<td>");
        //                sb.Append("<span id='" + lblAction.ID + "' class='form-control-label'>" + lblAction.Text + "</span>");
        //                sb.Append("</td>");

        //                sb.Append("</TR>");
        //                // Add the TableRow to the Table
        //                //tblWorkPermitHeader.Rows.Add(row);
        //                //tblWorkPermitHeader.Rows[1].Attributes.Add("style", "display:none;");
        //            }

        //            if (dsWorkPermitHeader.Tables[5].Rows.Count > 0)
        //            {
        //                DataTable dtSData = new DataTable();
        //                dtSData = dsWorkPermitHeader.Tables[5].Copy();
        //                dtSData.DefaultView.RowFilter = "WP_Section_ID = " + Convert.ToString(dsWorkPermitHeader.Tables[1].Rows[k]["WP_Section_ID"]) + " ";
        //                dtSData = dtSData.DefaultView.ToTable();
        //                if (dtSData.Rows.Count > 0)
        //                {
        //                    sb.Append("<tr>");
        //                    for (int j = 0; j < colsCount; j++)
        //                    {
        //                        DataTable dtSHData = new DataTable();
        //                        dtSHData = dsWorkPermitHeader.Tables[2].Copy();
        //                        dtSHData.DefaultView.RowFilter = "WP_Section_ID = " + Convert.ToString(dsWorkPermitHeader.Tables[1].Rows[k]["WP_Section_ID"]) + " AND " +
        //                                                            "Wp_Header_ID = " + Convert.ToString(dsWorkPermitHeader.Tables[1].Rows[j]["Wp_Header_ID"]) + " ";
        //                        dtSHData = dtSData.DefaultView.ToTable();
        //                        if (dtSData.Rows.Count > 0)
        //                        {
        //                            TextBox tb = new TextBox();
        //                            // Set a unique ID for each TextBox added
        //                            tb.ID = "tb_ID_" + SequenceID;
        //                            tb.Text = Convert.ToString(dtSData.Rows[0]["Header_Data"]) ;
        //                            sb.Append("<td>");
        //                            sb.Append("<input name='" + tb.ID + "' type='text' id='" + tb.ID + "' class='form-control' readonly='true' value='"+ tb.Text + "'>"); 
        //                            sb.Append("</td>");
        //                            SequenceID = SequenceID + 1;
        //                        }
        //                    }
        //                    sb.Append("</tr>");
        //                }
        //            }



        //            sb.Append("</table>");
        //            sb.Append("<input type='button' class='btn btn-accent m-btn m-btn--icon m-btn--pill m-btn--wide' onclick=AddRow('" + wpTableID + "') value='+ Add New' id='" + wpBtnAddNewID + "' />");
        //        }
        //         sb.Append("</div>");
        //    }

        //    lbTable.Text = sb.ToString();


        //    //GenerateTable(colsCount, 1);
        //}

        public static async Task SendNotification(string TokenNo, int TransactionID, string NotificationHeader, string NotificationMsg)
        {
            //TokenNo = "eSkpv5ZFSGip9BpPA0J2FE:APA91bEBZfqr4bvP7gIzfCdAcjTYU4uPYVMTvz4264ID5q32EfViLz2eRAqSb8tEuajK3l7LORQthSTnV_NMswAy2jXtbjfGyOEfafkijorMe5oAm9NjlUG1TJXGd0t6smmZN1r3mkTE";
            using (var client = new HttpClient())
            {
                //Send HTTP requests from here.  
                string API_URL = Convert.ToString(ConfigurationManager.AppSettings["API_URL"]);
                client.BaseAddress = new Uri(API_URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                //HttpResponseMessage response = await client.GetAsync("FunSendAppNotification?StrTokenNumber=" + TokenNo + "&TicketNo=" + TicketNo + "&StrMessage=" + strMessage + "&click_action=" + "Workpermit");
                HttpResponseMessage response = await client.GetAsync("FunSendAppNotification?StrTokenNumber=" + TokenNo + "&TransactionID=" + TransactionID + "&NotificationHeader=" + NotificationHeader + "&NotificationMsg=" + NotificationMsg + "&click_action=" + "WORKPERMIT");

                if (response.IsSuccessStatusCode)
                {
                    //Departmentdepartment = awaitresponse.Content.ReadAsAsync<Department>();
                    //Console.WriteLine("Id:{0}\tName:{1}", department.DepartmentId, department.DepartmentName);
                    //Console.WriteLine("No of Employee in Department: {0}", department.Employees.Count);
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
        }
    }
}