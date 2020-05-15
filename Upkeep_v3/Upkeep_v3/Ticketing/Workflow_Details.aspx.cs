using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Text;

namespace Upkeep_v3.Ticketing
{
    public partial class Workflow_Details : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            //frmMain.Action = @"Workflow_Details.aspx";
            if (LoggedInUserID == "")
            {
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            if (!IsPostBack)
            {
                Fetch_Zone();
                Fetch_CategorySubCategory(0);
                Fetch_User_UserGroupList();
                Fetch_Department();
                int WorkflowId = Convert.ToInt32(Request.QueryString["WorkflowId"]);
                if (WorkflowId > 0)
                {
                    BindWorkflowDetails(WorkflowId);
                }
                //int DelWorkflowID = Convert.ToInt32(Request.QueryString["DelWorkflowID"]);
                //if (DelWorkflowID > 0)
                //{
                //    DeleteWorkflowMaster(DelWorkflowID);
                //}

                Session["SelectedUsersID"] = "";
                Session["SelectedUsersName"] = "";
            }
        }

        protected void btnSaveWorkflowDetail_Click(object sender, EventArgs e)
        {
            int WorkflowID = 0;
            int ZoneID = 0;
            int CategoryID = 0;
            int SubCategoryID = 0;

            try
            {
                if (Convert.ToString(Session["WorkflowID"]) != "")
                {
                    WorkflowID = Convert.ToInt32(Session["WorkflowID"]);
                }
                string Action = "";

                if (WorkflowID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                ZoneID = Convert.ToInt32(ddlZone.SelectedValue);
                CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                SubCategoryID = Convert.ToInt32(ddlSubCategory.SelectedValue);

                string hdnWorkflowDetails = txtHdn.Text;

                string[] strArrayWorkflow = hdnWorkflowDetails.Split(',');


                XmlDocument xmlDocProm = null;
                xmlDocProm = new XmlDocument();
                int WorkflowLevel = 0;
                WorkflowLevel = strArrayWorkflow.Length - 1;

                StringBuilder strXmlOutput = new StringBuilder();
                //strXmlOutput.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
                strXmlOutput.Append(@"<?xml version=""1.0"" ?>");
                strXmlOutput.Append(@"<WORKFLOW_ROOT>");

                for (int intLocRowCtr = 0; intLocRowCtr <= WorkflowLevel; intLocRowCtr++)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(strArrayWorkflow[intLocRowCtr])))
                    {
                        string[] LocArr = strArrayWorkflow[intLocRowCtr].Split('#');

                        strXmlOutput.Append(@"<WORKFLOW_DETAILS>");

                        strXmlOutput.Append(@"<level>" + LocArr[0] + "</level>");
                        strXmlOutput.Append(@"<Userid>" + LocArr[1].Replace("$",",") + "</Userid>");
                        strXmlOutput.Append(@"<UserGroupid>" + LocArr[2] + "</UserGroupid>");
                        strXmlOutput.Append(@"<SendEmail>" + LocArr[3] + "</SendEmail>");
                        strXmlOutput.Append(@"<SendSMS>" + LocArr[4] + "</SendSMS>");
                        strXmlOutput.Append(@"<SendNotification>" + LocArr[5] + "</SendNotification>");
                        strXmlOutput.Append(@"<replytime>" + LocArr[6] + "</replytime>");
                        strXmlOutput.Append(@"<nextactionlevel>" + LocArr[7] + "</nextactionlevel>");

                        strXmlOutput.Append(@"</WORKFLOW_DETAILS>");
                    }
                }
                strXmlOutput.Append(@"</WORKFLOW_ROOT>");

                ds = ObjUpkeep.WorkflowMaster_CRUD(WorkflowID, txtWorkflowDesc.Text.Trim(), ZoneID, CategoryID, SubCategoryID, strXmlOutput.ToString(), CompanyID, LoggedInUserID, Action);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 0)
                        {

                        }
                        else if (Status == 1)
                        {
                            Session["WorkflowID"] = "";
                            txtWorkflowDesc.Text = "";

                            Response.Redirect(Page.ResolveClientUrl("~/Ticketing/Workflow_Master.aspx"), false);
                        }
                        else if (Status == 3)
                        {
                            lblWorkflowErrorMsg.Text = "Workflow already exists";
                        }
                        else if (Status == 2)
                        {
                            lblWorkflowErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Fetch_CategorySubCategory(int CategoryID)
        {
            //int CategoryID = 0;
            try
            {

                ds = ObjUpkeep.Fetch_CategorySubCategory(CategoryID);

                if (CategoryID == 0)
                {
                    ddlCategory.DataSource = ds.Tables[0];
                    ddlCategory.DataTextField = "Category_Desc";
                    ddlCategory.DataValueField = "Category_ID";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                else if (CategoryID > 0)
                {
                    ddlSubCategory.DataSource = ds.Tables[0];
                    ddlSubCategory.DataTextField = "SubCategory_Desc";
                    ddlSubCategory.DataValueField = "SubCategory_ID";
                    ddlSubCategory.DataBind();
                    ddlSubCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
            Fetch_CategorySubCategory(CategoryID);
        }


        private void AddRows(int NoOfLevels, DataSet dsWorkflowDetail)
        {
            int ctr = NoOfLevels;
            DataTable ObjDt = null;

            if (dsWorkflowDetail !=null)
            {
                ObjDt = dsWorkflowDetail.Tables[1];
            }
            TblLevels.Visible = true;
            //TblSave.Visible = true;
            if (dsWorkflowDetail == null)
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
                        LocTxtActionGroup.Width = 180;
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
                        System.Web.UI.WebControls.TextBox LocTxtTime = new System.Web.UI.WebControls.TextBox();
                        LocTxtTime.Width = 30;
                        LocTxtTime.Attributes.Add("data-rule-number", "true");
                        // LocTxtTime.Attributes.Add("onpaste", "return onlyNumbers();")
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[5].Controls.Add(LocTxtTime);

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
                        if (IntPriCounter == ctr - 1)
                        {
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[6].InnerHtml = "0";
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[6].Attributes.Add("class", "GridItem");
                        }
                        else
                        {
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[6].InnerHtml = (IntPriCounter + 2).ToString();
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[6].Attributes.Add("class", "GridItem");
                        }

                        this.TblLevels.Rows[IntPriCounter + 1].Cells.Add(new HtmlTableCell());
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
                        this.TblLevels.Rows[IntPriCounter + 1].Cells[0].InnerHtml =Convert.ToString(IntPriCounter + 1);
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
                            LocTxtActionGroup.ToolTip= Convert.ToString(ObjDt.Rows[IntPriCounter]["UserDesc"]);
                        }
                        else if (!string.IsNullOrEmpty(Convert.ToString((ObjDt.Rows[IntPriCounter]["GroupDesc"]))))
                        {
                            LocTxtActionGroup.Text = Convert.ToString(ObjDt.Rows[IntPriCounter]["GroupDesc"]);
                            LocHdnAction.Value = Convert.ToString(ObjDt.Rows[IntPriCounter]["ActionId"]);
                            LocTxtActionGroup.ToolTip = Convert.ToString(ObjDt.Rows[IntPriCounter]["GroupDesc"]);
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

                        LocTxtTime.Text =Convert.ToString(ObjDt.Rows[IntPriCounter]["Escalate_Time"]);
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
                            this.TblLevels.Rows[IntPriCounter + 1].Cells[6].InnerHtml =Convert.ToString(IntPriCounter + 2);
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

        protected void btnMakeCombination_Click(object sender, EventArgs e)
        {
            int NoOfLevels = Convert.ToInt32(txtNoOfLevel.Text);
            AddRows(NoOfLevels, null);
        }

        public void Fetch_User_UserGroupList()
        {
            //int CategoryID = 0;
            try
            {

                ds = ObjUpkeep.Fetch_User_UserGroupList();

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

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
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

        public void Fetch_Zone()
        {
            try
            {

                ds = ObjUpkeep.Fetch_Zone();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlZone.DataSource = ds.Tables[0];
                        ddlZone.DataTextField = "Zone";
                        ddlZone.DataValueField = "Zone_ID";
                        ddlZone.DataBind();
                        ddlZone.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindWorkflowDetails(int WorkflowID)
        {
            DataSet dsWorkflowDetail = new DataSet();
            try
            {
                dsWorkflowDetail = ObjUpkeep.WorkflowMaster_CRUD(WorkflowID, "", 0, 0, 0, "",CompanyID, LoggedInUserID, "R");
                // ds = ObjUpkeep.WorkflowMaster_CRUD(WorkflowID, "", 0, 0, LoggedInUserID, "R");

                if (dsWorkflowDetail.Tables.Count > 0)
                {
                    if (dsWorkflowDetail.Tables[0].Rows.Count > 0)
                    {
                        Session["WorkflowID"] = Convert.ToInt32(dsWorkflowDetail.Tables[0].Rows[0]["Workflow_Id"]);
                        txtWorkflowDesc.Text = Convert.ToString(dsWorkflowDetail.Tables[0].Rows[0]["Workflow_Desc"]);
                        //Fetch_Zone();
                        ddlZone.SelectedValue = Convert.ToString(dsWorkflowDetail.Tables[0].Rows[0]["ZoneID"]);

                        ddlCategory.SelectedValue = Convert.ToString(dsWorkflowDetail.Tables[0].Rows[0]["Category_ID"]);

                        Fetch_CategorySubCategory(Convert.ToInt32(dsWorkflowDetail.Tables[0].Rows[0]["Category_ID"]));

                        ddlSubCategory.SelectedValue = Convert.ToString(dsWorkflowDetail.Tables[0].Rows[0]["SubCategory_ID"]);
                        txtNoOfLevel.Text = Convert.ToString(dsWorkflowDetail.Tables[0].Rows[0]["NoOfLevel"]);
                        //mpeWorkflowMaster.Show();

                        AddRows(Convert.ToInt32(dsWorkflowDetail.Tables[0].Rows[0]["NoOfLevel"]), dsWorkflowDetail);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fetch_User_UserGroupList();
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
            ScriptManager.RegisterClientScriptBlock(Page, typeof(string), "myScriptName" , $"SelectUser();", true);
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
    }
}