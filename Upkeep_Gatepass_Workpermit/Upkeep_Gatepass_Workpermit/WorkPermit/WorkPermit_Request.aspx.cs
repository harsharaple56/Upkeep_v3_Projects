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

namespace Upkeep_Gatepass_Workpermit.WorkPermit
{
    public partial class WorkPermit_Request : System.Web.UI.Page
    {
        int sPublicConfigId = 0;

        Upkeep_GP_WP_Services.Upkeep_GP_WP_Services ObjUpkeep = new Upkeep_GP_WP_Services.Upkeep_GP_WP_Services();
        string LoggedInUserID = string.Empty;
        string TransLoggedInUserID = string.Empty;
        string TransInitiator = string.Empty;
        DataSet dsGlobalDataS = new DataSet();
        string MyActionFlag = string.Empty;
        string MyActionCompeletd = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            int TransactionID = 0;
            if (Request.QueryString["TransactionID"] != null)
            {
                TransactionID = Convert.ToInt32(Request.QueryString["TransactionID"]);
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


            if (!IsPostBack)
            {

                if (System.Web.HttpContext.Current.Session["PreviousURL"] == null)
                {
                    Session["PreviousURL"] = "~/WorkPermit/MyWorkPermit.aspx";
                }


                if (TransactionID > 0)
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
                    if (TransactionID <= 0)
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

                dsTitle = ObjUpkeep.Fetch_WorkPermitConfiguration(Initiator);
                if (dsTitle.Tables.Count > 0)
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

                int AnswerType = Convert.ToInt32((e.Item.FindControl("hdnlblAnswerType") as HiddenField).Value);
                string HeadId = (e.Item.FindControl("hfHeaderId") as HiddenField).Value;

                string HeadMandatoryId = (e.Item.FindControl("hdnIs_Mandatory") as HiddenField).Value;
                if (HeadMandatoryId == "*")
                {

                    Label sample = e.Item.FindControl("lblIsMandatory") as Label;
                    sample.Attributes.Remove("style");
                }

                if (AnswerType == 1) //Multi Selection [CheckBox]
                {
                    HtmlGenericControl sample = e.Item.FindControl("divCheckBox") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == 2) //Single Selection [Radio Button]
                {
                    HtmlGenericControl sample = e.Item.FindControl("divRadioButton") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == 3) //Image Upload  
                {
                    HtmlGenericControl sample = e.Item.FindControl("divImage") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == 4) //Number Text Field
                {
                    HtmlGenericControl sample = e.Item.FindControl("divNumber") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == 5) //Normal Text Field
                {
                    HtmlGenericControl sample = e.Item.FindControl("divText") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == 6) // Textarea Field
                {
                    HtmlGenericControl sample = e.Item.FindControl("divTextArea") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else  //Normal Text Field
                {
                    HtmlGenericControl sample = e.Item.FindControl("divText") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
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

                if (AnswerType == 2)
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
                else if (AnswerType == 1)
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
                dsWorkPermitHeader = ObjUpkeep.Bind_WorkPermitSavedConfiguration(ConfigTitleID, Session["TransactionID"].ToString());
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
                    int AnswerType = Convert.ToInt32((itemHeader.FindControl("hdnlblAnswerType") as HiddenField).Value);
                    string HeadId = (itemHeader.FindControl("hfHeaderId") as HiddenField).Value;

                    string HeadMandatoryId = (itemHeader.FindControl("hdnIs_Mandatory") as HiddenField).Value;
                    if (HeadMandatoryId == "*")
                    {

                        Label sample = itemHeader.FindControl("lblIsMandatory") as Label;
                        sample.Attributes.Remove("style");
                    }

                    if (AnswerType == 1) //Multi Selection [CheckBox]
                    {
                        HtmlGenericControl sample = itemHeader.FindControl("divCheckBox") as HtmlGenericControl;
                        sample.Attributes.Remove("style");
                    }
                    else if (AnswerType == 2) //Single Selection [Radio Button]
                    {
                        HtmlGenericControl sample = itemHeader.FindControl("divRadioButton") as HtmlGenericControl;
                        sample.Attributes.Remove("style");
                    }
                    else if (AnswerType == 3) //Image Upload  
                    {
                        HtmlGenericControl sample = itemHeader.FindControl("divImage") as HtmlGenericControl;
                        sample.Attributes.Remove("style");
                    }
                    else if (AnswerType == 4) //Number Text Field
                    {
                        HtmlGenericControl sample = itemHeader.FindControl("divNumber") as HtmlGenericControl;
                        sample.Attributes.Remove("style");
                    }
                    else if (AnswerType == 5) //Normal Text Field
                    {
                        HtmlGenericControl sample = itemHeader.FindControl("divText") as HtmlGenericControl;
                        sample.Attributes.Remove("style");
                    }
                    else if (AnswerType == 6) // Textarea Field
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

        private void SaveSectionHeaderData()
        {
            try
            {
                #region UserData
                int WP_ConfigID = Convert.ToInt32(ddlWorkPermitTitle.SelectedValue.ToString());
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
                // dtRow["SectionID"] = ""; dtRow["HeaderID"] = ""; dtRow["AnswerID"] = ""; dtRow["Data"] = ""; 

                string Is_Not_Valid = "False";

                foreach (RepeaterItem itemSection in rptSectionDetails.Items)
                {
                    string DivId = (itemSection.FindControl("hfCustomerId") as HiddenField).Value;
                    Repeater rptHeaderDetails = itemSection.FindControl("rptHeaderDetails") as Repeater;

                    foreach (RepeaterItem itemHeader in rptHeaderDetails.Items)
                    {

                        int AnswerType = Convert.ToInt32((itemHeader.FindControl("hdnlblAnswerType") as HiddenField).Value);
                        string Is_Mandatory = Convert.ToString((itemHeader.FindControl("hdnIs_Mandatory") as HiddenField).Value);
                        Label lblHeaderErr = (itemHeader.FindControl("lblHeaderErr") as Label);
                        string isField = "False";

                        // int AnswerTypeData = Convert.ToInt32((itemHeader.FindControl("hdnlblAnswerTypeData") as HiddenField).Value);
                        string HeadId = (itemHeader.FindControl("hfHeaderId") as HiddenField).Value;


                        if (AnswerType == 1) //Multi Selection [CheckBox]
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
                                    dtRow["AnswerID"] = AnswerType;
                                    dtRow["Data"] = item.Value;
                                    dt.Rows.Add(dtRow);
                                }
                            }

                            if (Is_Mandatory == "*")
                            {
                                if (isField == "False")
                                {
                                    Is_Not_Valid = "True";
                                    lblHeaderErr.Text = "Please provide valid data.";
                                }
                            }

                            //String YrStr = String.Join(";", chkStrList.ToArray());
                        }
                        else if (AnswerType == 2) //Single Selection [Radio Button]
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
                                    dtRow["AnswerID"] = AnswerType;
                                    dtRow["Data"] = item.Value;
                                    dt.Rows.Add(dtRow);
                                }
                            }
                            if (Is_Mandatory == "*")
                            {
                                if (isField == "False")
                                {
                                    Is_Not_Valid = "True";
                                    lblHeaderErr.Text = "Please provide valid data.";
                                }
                            }
                            //String YrStr = String.Join(";", RadioStrList.ToArray());

                        }
                        else if (AnswerType == 3) //Image Upload  
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
                                                dtRow["AnswerID"] = AnswerType;
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
                                    lblHeaderErr.Text = "Please provide valid data.";
                                }
                            }

                        }
                        else if (AnswerType == 4) //Number Text Field
                        {
                            HtmlGenericControl sample = itemHeader.FindControl("divNumber") as HtmlGenericControl;
                            string txtNum = sample.Controls[1].UniqueID;
                            string sVal = Request.Form.GetValues(txtNum)[0];
                            DataRow dtRow = dt.NewRow();
                            dtRow["SectionID"] = DivId;
                            dtRow["HeaderID"] = HeadId;
                            dtRow["AnswerID"] = AnswerType;
                            dtRow["Data"] = sVal;
                            dt.Rows.Add(dtRow);


                            if (Is_Mandatory == "*")
                            {
                                if (isField == "False")
                                {
                                    Is_Not_Valid = "True";
                                    lblHeaderErr.Text = "Please provide valid data.";
                                }
                            }

                        }
                        else if (AnswerType == 5) //Normal Text Field
                        {
                            HtmlGenericControl sample = itemHeader.FindControl("divText") as HtmlGenericControl;
                            string txtNum = sample.Controls[1].UniqueID;
                            string sVal = Request.Form.GetValues(txtNum)[0];
                            DataRow dtRow = dt.NewRow();
                            dtRow["SectionID"] = DivId;
                            dtRow["HeaderID"] = HeadId;
                            dtRow["AnswerID"] = AnswerType;
                            dtRow["Data"] = sVal;
                            dt.Rows.Add(dtRow);



                            if (Is_Mandatory == "*")
                            {
                                if (isField == "False")
                                {
                                    Is_Not_Valid = "True";
                                    lblHeaderErr.Text = "Please provide valid data.";
                                }
                            }
                        }
                        else if (AnswerType == 6) // Textarea Field
                        {
                            HtmlGenericControl sample = itemHeader.FindControl("divTextArea") as HtmlGenericControl;
                            string txtNum = sample.Controls[1].UniqueID;
                            string sVal = Request.Form.GetValues(txtNum)[0];
                            DataRow dtRow = dt.NewRow();
                            dtRow["SectionID"] = DivId;
                            dtRow["HeaderID"] = HeadId;
                            dtRow["AnswerID"] = AnswerType;
                            dtRow["Data"] = sVal;
                            dt.Rows.Add(dtRow);


                            if (Is_Mandatory == "*")
                            {
                                if (isField == "False")
                                {
                                    Is_Not_Valid = "True";
                                    lblHeaderErr.Text = "Please provide valid data.";
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
                            dtRow["AnswerID"] = AnswerType;
                            dtRow["Data"] = sVal;
                            dt.Rows.Add(dtRow);


                            if (Is_Mandatory == "*")
                            {
                                if (isField == "False")
                                {
                                    Is_Not_Valid = "True";
                                    lblHeaderErr.Text = "Please provide valid data.";
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
                            SetRepeater();
                            divInsertButton.Visible = false;
                            lblWpRequestCode.Text = Convert.ToString(dsWPHeaderData.Tables[0].Rows[0]["RequestID"]);
                            mpeWpRequestSaveSuccess.Show();
                        }
                        else
                        {
                            SetRepeater();
                            lblErrorMsg1.Text = "Error Occured !!!";
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
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("");
                    lbTable.Text = sb.ToString();
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
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FetchSectionHeaderData(int TransID)
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

                        txtWorkPermitDate.Text = dsData.Tables[0].Rows[0]["Wp_Date"].ToString();
                        txtWorkPermitToDate.Text = dsData.Tables[0].Rows[0]["Wp_To_Date"].ToString();

                        foreach (RepeaterItem itemSection in rptSectionDetails.Items)
                        {
                            string DivId = (itemSection.FindControl("hfCustomerId") as HiddenField).Value;
                            Repeater rptHeaderDetails = itemSection.FindControl("rptHeaderDetails") as Repeater;

                            foreach (RepeaterItem itemHeader in rptHeaderDetails.Items)
                            {
                                int AnswerType = Convert.ToInt32((itemHeader.FindControl("hdnlblAnswerType") as HiddenField).Value);
                                string HeadId = (itemHeader.FindControl("hfHeaderId") as HiddenField).Value;

                                DataTable dta = new DataTable();
                                dta = dsData.Tables[2].Copy();
                                dta.DefaultView.RowFilter = "WP_Section_ID = " + Convert.ToString(DivId) + " AND WP_Header_ID =" + Convert.ToString(HeadId) + "  ";
                                dta = dta.DefaultView.ToTable();

                                if (dta.Rows.Count > 0)
                                {
                                    if (AnswerType == 1) //Multi Selection [CheckBox]
                                    {
                                        CheckBoxList divCheckBoxIDI = itemHeader.FindControl("divCheckBoxIDI") as CheckBoxList;

                                        for (int i = 0; i < divCheckBoxIDI.Items.Count; i++)
                                        {
                                            for (int j = 0; j < dta.Rows.Count; j++)
                                            {
                                                string vals = divCheckBoxIDI.Items[i].Value;
                                                if (vals == dta.Rows[j]["Header_Data"].ToString())
                                                {
                                                    divCheckBoxIDI.Items[i].Selected = true;
                                                }
                                                divCheckBoxIDI.Items[i].Enabled = false;
                                            }
                                            divCheckBoxIDI.Attributes.Add("Enabled", "false");
                                        }

                                    }
                                    else if (AnswerType == 2) //Single Selection [Radio Button]
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
                                    else if (AnswerType == 3) //Image Upload  
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
                                                vals = dtImg.Rows[j]["IMAGEPATH"].ToString();
                                            }
                                            else
                                            {
                                                vals = "," + dtImg.Rows[j]["IMAGEPATH"].ToString();
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
                                    else if (AnswerType == 4) //Number Text Field
                                    {
                                        HtmlGenericControl sample = itemHeader.FindControl("divNumber") as HtmlGenericControl;
                                        string txtNum = sample.Controls[1].UniqueID;
                                        //string sVal = Request.Form.GetValues(txtNum)[0];


                                        HtmlInputGenericControl tb = FindControl(txtNum) as HtmlInputGenericControl;
                                        tb.Value = dta.Rows[0]["Header_Data"].ToString();
                                        //Request.Form.Set(txtNum, dta.Rows[0]["Header_Data"].ToString());
                                    }
                                    else if (AnswerType == 5) //Normal Text Field
                                    {
                                        HtmlGenericControl sample = itemHeader.FindControl("divText") as HtmlGenericControl;
                                        string txtNum = sample.Controls[1].UniqueID;
                                        //string sVal = Request.Form.GetValues(txtNum)[0];

                                        HtmlInputText tb = FindControl(txtNum) as HtmlInputText;
                                        tb.Value = dta.Rows[0]["Header_Data"].ToString();
                                        //Request.Form.Set(txtNum, dta.Rows[0]["Header_Data"].ToString());
                                    }
                                    else if (AnswerType == 6) // Textarea Field
                                    {
                                        HtmlGenericControl sample = itemHeader.FindControl("divTextArea") as HtmlGenericControl;
                                        string txtNum = sample.Controls[1].UniqueID;
                                        // string sVal = Request.Form.GetValues(txtNum)[0];

                                        HtmlTextArea tb = FindControl(txtNum) as HtmlTextArea;
                                        tb.Value = dta.Rows[0]["Header_Data"].ToString();
                                        //Request.Form.Set(txtNum, dta.Rows[0]["Header_Data"].ToString());
                                    }
                                    else  //Normal Text Field
                                    {
                                        HtmlGenericControl sample = itemHeader.FindControl("divText") as HtmlGenericControl;
                                        string txtNum = sample.Controls[1].UniqueID;
                                        //string sVal = Request.Form.GetValues(txtNum)[0];

                                        HtmlInputGenericControl tb = FindControl(txtNum) as HtmlInputGenericControl;
                                        tb.Value = dta.Rows[0]["Header_Data"].ToString();
                                        //Request.Form.Set(txtNum, dta.Rows[0]["Header_Data"].ToString());
                                    }
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
                        MyActionCompeletd = dsData.Tables[5].Rows[0]["IsComplete"].ToString();
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

                }
                else
                { 
                    //dvApprovalHistory.Attributes.Add("style", "display:none;");
                    dvApprovalDetails.Attributes.Add("style", "display:none;");
                    dvApprovalDetHeader.Attributes.Add("Style", "display:none;");
                    divUpdateButton.Attributes.Add("style", "display:none;");
                    //dvApprovalDetails.Attributes.Add("Style", "display:none;");
                    //dvSubmitSection.Attributes.Add("Style", "display:none;"); ;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            if (ddlAction.SelectedIndex < 1)
            {
                LabelERRORmsg.Text = "Please enter Proper Action type";
                return;
            }
            if (txtRemarks.Text.Trim() == "")
            {
                LabelERRORmsg.Text = "Please enter remarks";
                return;
            }
            string ActionStatus = string.Empty;
            ActionStatus = Convert.ToString(ddlAction.SelectedItem.Text);
            DataSet dsWPAction = new DataSet();
            dsWPAction = ObjUpkeep.Update_WorkPermitRequest(Convert.ToInt32(Session["TransactionID"].ToString()), LoggedInUserID, ActionStatus, txtRemarks.Text);

            if (dsWPAction.Tables.Count > 0)
            {
                if (dsWPAction.Tables[0].Rows.Count > 0)
                {
                    int Status = Convert.ToInt32(dsWPAction.Tables[0].Rows[0]["Status"]);
                    if (Status == 1)
                    {
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

        private void ModifyControls()
        {
            btnSubmit.Attributes.Add("style", "display:none;");
            divUpdateButton.Attributes.Remove("style");
            //dvApprovalDetails.Attributes.Add("style", "display:Block;");
            divInsertButton.Attributes.Add("style", "display:none;");
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

    }
}