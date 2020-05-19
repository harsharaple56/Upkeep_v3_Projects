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
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        DataSet dsConfig = new DataSet();
        int CompanyID = 0;
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
        

        public string bindVMSHeaderValue()
        {
            string data = "";


            return data;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
                
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            int colsCount = 0;
            colsCount = Convert.ToInt32(Session["colsCount"]);
            //GenerateTable(colsCount, 1);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string VMSHeader = Convert.ToString(hdnVMSHeader.Value);
            string VMSHeaderData = Convert.ToString(hdnVMSHeaderData.Value);

            string[] strArrayVMSHeader = VMSHeader.Split(',');
            string[] strArrayVMSHeaderData = VMSHeaderData.Split(',');

            int recCount = 0;
            recCount = strArrayVMSHeader.Length - 1;

            DataTable dtHeader = new DataTable();

            // string df = "1,2,1,3";

            int i;

            DataColumn dc = new DataColumn();

            dtHeader.Columns.Add(dc);

            for (i = 0; i < 1; i++)
            {
                string[] LocArr = strArrayVMSHeader[i].Split('#');
                int recCount2 = LocArr.Length;

                for (int j = 0; j < recCount2; j++)
                {
                    if (LocArr[j] != "")
                    {
                        //dr[dc] = VMSHeader.Split(',')[i];
                        //dr[dc] = LocArr[j];
                        //dt.Rows.Add(dr);
                        dtHeader.Columns.Add(LocArr[j]);

                    }
                }
            }

            string[] LocArray = strArrayVMSHeader[1].Split('#');

            DataRow row = dtHeader.NewRow(); ///creating new row in your datatable

            row.ItemArray = LocArray;///copying your data into data row object

            dtHeader.Rows.InsertAt(row, 2);///insert row at 3rd index of datatable


            for (int k = 0; k < strArrayVMSHeaderData.Length - 1; k++)
            {

                string[] HValueArray = strArrayVMSHeaderData[k].Split('#');

                ////if(HValueArray)
                DataRow rowHValue = dtHeader.NewRow(); ///creating new row in your datatable

                rowHValue.ItemArray = HValueArray;///copying your data into data row object

                dtHeader.Rows.InsertAt(rowHValue, 2);///insert row at 3rd index of datatable

            }

            dtHeader.Columns.Remove("Column1");
            
            int VMS_ConfigID = 0;
            string strVMSDate = string.Empty;
            int DeptID = 0;
            int TypeID = 0;

            VMS_ConfigID = Convert.ToInt32(ddlVMSTitle.SelectedValue);
            strVMSDate = Convert.ToString(txtVMSDate.Text.Trim());
            DeptID = Convert.ToInt32(ddlDepartment.SelectedValue);


            DataSet dsVMSHeaderData = new DataSet();
            dsVMSHeaderData = ObjUpkeep.Insert_VMSRequest(VMS_ConfigID, strVMSDate, DeptID, TypeID, VMSHeader, VMSHeaderData, LoggedInUserID);

            if (dsVMSHeaderData.Tables.Count > 0)
            {
                if (dsVMSHeaderData.Tables[0].Rows.Count > 0)
                {
                    int Status = Convert.ToInt32(dsVMSHeaderData.Tables[0].Rows[0]["Status"]);
                    if (Status == 1)
                    {
                        lblVMSRequestCode.Text = Convert.ToString(dsVMSHeaderData.Tables[1].Rows[0]["RequestID"]);

                        mpeVMSRequestSaveSuccess.Show();
                    }
                }
            }
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

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
    }
}