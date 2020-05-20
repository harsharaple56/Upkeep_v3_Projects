using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Configuration;

namespace Upkeep_v3.VMS
{
    public partial class Visit_Request : System.Web.UI.Page
    {

        #region Global variables
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        DataSet dsConfig = new DataSet();
        int CompanyID = 0;
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            //LoggedInUserID = "admin";
            //LoggedInUserID = "121";
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                //Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            if (!IsPostBack)
            {
                //GenerateTableHeader();
                //GenerateTable(3, 1);
                Fetch_User_UserGroupList();
                Fetch_Department();
                BindVMSTitle();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string WpTitleSelectedID = "";
            WpTitleSelectedID = ddlVMSTitle.SelectedValue;
            //if (ValidateData() == false)
            //{
            //    //ddlWorkPermitTitle.SelectedValue = "0";
            //    //ddlWorkPermitTitle.SelectedValue = WpTitleSelectedID;
            //    //setWorkPermitData();
            //    SetRepeater();
            //    return;
            //}

            SaveVisitData();
        }

        protected void ddlVMSTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ConfigTitleID = 0;

            try
            {
                //lblRequestDate.Text = DateTime.Now.ToString("dd/MMM/yyyy hh:mm tt");

                ConfigTitleID = Convert.ToInt32(ddlVMSTitle.SelectedValue);


                dsConfig = ObjUpkeep.Bind_VMSRequestDetails(ConfigTitleID, LoggedInUserID);

                rptHeaderDetails.DataSource = dsConfig.Tables[4];
                rptHeaderDetails.DataBind();


            }
            catch (Exception ex)
            {
                throw ex;
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

                DataSet dsVMSHeader = new DataSet();
                dsVMSHeader = dsConfig.Copy(); //ObjUpkeep.Bind_VMSConfiguration(sPublicConfigId);

                DataTable dt = new DataTable();
                dt = dsVMSHeader.Tables[3].Copy();
                dt.DefaultView.RowFilter = "VMS_Qn_ID = " + Convert.ToString(HeadId) + "";
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

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fetch_User_UserGroupList();
        }

        protected void btnSuccessOk_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/VMS/MyVMS.aspx"), false);
        }

        #endregion

        #region Functions

        public void BindVMSTitle()
        {
            DataSet dsTitle = new DataSet();
            string Initiator = string.Empty;
            try
            {
                Initiator = Convert.ToString(Session["UserType"]);
                dsTitle = ObjUpkeep.Fetch_VMSConfiguration(Initiator);
                if (dsTitle.Tables.Count > 0)
                {
                    if (dsTitle.Tables[0].Rows.Count > 0)
                    {
                        ddlVMSTitle.DataSource = dsTitle.Tables[0];
                        ddlVMSTitle.DataTextField = "Config_Title";
                        ddlVMSTitle.DataValueField = "VMS_Config_Id";
                        ddlVMSTitle.DataBind();
                        ddlVMSTitle.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
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

                DataSet ds = ObjUpkeep.Fetch_User_UserGroupList();

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

        public void Fetch_Department()
        {
            DataSet dsDept = new DataSet();
            try
            {
                dsDept = ObjUpkeep.Fetch_Department(CompanyID);

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


        private void SaveVisitData()
        {
            try
            {
                #region UserData
                int ConfigID = Convert.ToInt32(ddlVMSTitle.SelectedValue.ToString());
                string LoggedInUser = LoggedInUserID;
                string strVisitDate = txtVMSDate.Text;
                string strMeetUsers = txtMeetUsers.Text;
                #endregion


                #region SectionHeader
                /*
                 Create table and store data in table and convert later in xml and pass in to Datatbase..
                 Table Structure : SectionID | HeaderID | AnswerID | Data
                */

                string strVMSData = "";

                DataTable dt = new DataTable();
                dt.Clear();
                dt.TableName = "TableSectionHeader";
                dt.Columns.Add("HeaderID");
                dt.Columns.Add("AnswerID");
                dt.Columns.Add("Data");
                // dtRow["SectionID"] = ""; dtRow["HeaderID"] = ""; dtRow["AnswerID"] = ""; dtRow["Data"] = ""; 

                string Is_Not_Valid = "False";


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
                                        fileName =  HeadId + "_" + AnswerType + "_" + Convert.ToString(i) + filetype;
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
                    strVMSData = xmlstr;
                }
                #endregion


                #region SaveDataToDB
                DataSet dsWPHeaderData = new DataSet();
                dsWPHeaderData = ObjUpkeep.Insert_WorkPermitRequest(CompanyID,ConfigID, strVisitDate, strVMSData,strFeedbackData LoggedInUserID );

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

        #endregion
    }
}