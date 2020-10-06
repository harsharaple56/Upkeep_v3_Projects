using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;

namespace Upkeep_v3_Control_Center.Masters
{
    public partial class Add_Company : System.Web.UI.Page
    {
        UpkeepControlCenter_Service.UpkeepControlCenter_Service objUpkeepCC = new UpkeepControlCenter_Service.UpkeepControlCenter_Service();
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            if (!IsPostBack)
            {
                bindGroupDesc();
                int CompanyID = Convert.ToInt32(Request.QueryString["CompanyID"]);
                int CompanyID_Delete = Convert.ToInt32(Request.QueryString["DelCompanyID"]);
                if (CompanyID > 0)
                {
                    Session["CompanyID"] = Convert.ToString(CompanyID);
                    bindCompany_Master(CompanyID);
                }
                if (CompanyID_Delete > 0)
                {
                    DeleteCompany_Master(CompanyID_Delete);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int CompanyID = Convert.ToInt32(Session["CompanyID"]);
                string Action = "";
                DataSet ds = new DataSet();

                if (CompanyID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                int GroupID = 0;
                GroupID = Convert.ToInt32(ddlGroupDesc.SelectedValue);
                string ConString = string.Empty;
                int Is_DBatClientServer=0;
                string CompanyLogoName = string.Empty;
                string CompanyCode = string.Empty;
                string ClientURL = string.Empty;
                string CompanyEmailID = string.Empty;
                string CompanyMobileNo = string.Empty;

                string User_Name = string.Empty;
                string User_Designation = string.Empty;
                string User_EmailID = string.Empty;
                string User_MobileNo = string.Empty;

                CompanyCode = txtCompany_Code.Text.Trim();
                ClientURL = txtClientURL.Text.Trim();

                CompanyEmailID = txtCompanyEmailID.Text.Trim();
                CompanyMobileNo = txtCompanyMobileNo.Text.Trim();

                User_Name = txtAdminName.Text.Trim();
                User_Designation = txtUserDesignation.Text.Trim();
                User_EmailID = txtUserEmailID.Text.Trim();
                User_MobileNo = txtUserMobileNo.Text.Trim();

                if (chk_IsDBatClient.Checked == true)
                {
                    Is_DBatClientServer = 1;
                    ConString = "Data Source=" + txtServerName.Text.Trim() + ";Initial Catalog=" + txtDatabase.Text.Trim() + ";Persist Security Info=True;User ID=" + txtDbUser.Text.Trim() + ";Password=" + txtDbPassword.Text.Trim() + "";

                }
                else
                {
                    Is_DBatClientServer = 0;
                }

               
                
                string imgPath = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadURL"]);

                if (fileUpload_CompanyLogo.HasFile)
                {
                    string CompanyLogo_Pic = string.Empty;

                    string fileUploadPath_Sign = HttpContext.Current.Server.MapPath("~/CompanyLogo/");

                    if (!Directory.Exists(fileUploadPath_Sign))
                    {
                        Directory.CreateDirectory(fileUploadPath_Sign);
                    }

                    string fileExtension_Sign = Path.GetExtension(fileUpload_CompanyLogo.FileName);
                    CompanyLogo_Pic = CompanyCode + fileExtension_Sign;

                    string Sign_SaveLocation = Server.MapPath("~/CompanyLogo/") + "/" + CompanyLogo_Pic;
                    CompanyLogoName = imgPath + "/CompanyLogo/" + CompanyLogo_Pic;

                    fileUpload_CompanyLogo.PostedFile.SaveAs(Sign_SaveLocation);

                    //fileUpload_CompanyLogo.PostedFile.SaveAs(Server.MapPath("~/Images/") + CompanyCode + ".PNG");
                    //CompanyLogoName = CompanyCode + ".PNG";
                }
                else
                {
                    CompanyLogoName = "";
                }

                //ConString = "";

                ds = objUpkeepCC.CompanyMaster_CRUD(CompanyID, txtCompany_Code.Text.Trim(), txtCompDesc.Text.Trim(), GroupID, CompanyLogoName, ClientURL, Is_DBatClientServer, ConString, CompanyEmailID, CompanyMobileNo, User_Name, User_Designation, User_EmailID, User_MobileNo, LoggedInUserID, Action);

                Session["CompanyID"] = "";
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
                            Response.Redirect(Page.ResolveClientUrl("~/Masters/Company_Mst.aspx"), false);
                            //Response.Redirect("~/Masters/Company_Mst.aspx", false);
                        }
                        else if (Status == 3)
                        {
                            lblErrorMsg.Text = "Group Code/ Group Description already exists";
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

        public void bindGroupDesc()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objUpkeepCC.Fetch_GroupDesc();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlGroupDesc.DataSource = ds.Tables[0];
                        ddlGroupDesc.DataTextField= "Group_Desc";
                        ddlGroupDesc.DataValueField= "Group_ID";
                        ddlGroupDesc.DataBind();
                        ddlGroupDesc.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void bindCompany_Master(int CompanyID)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objUpkeepCC.CompanyMaster_CRUD(CompanyID, "", "", 0, "","", 0, "","","","","","","", LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtCompany_Code.Text = Convert.ToString(ds.Tables[0].Rows[0]["Company_Code"]);
                        txtCompDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["Company_Desc"]);
                        ddlGroupDesc.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Group_ID"]);

                        txtCompanyEmailID.Text = Convert.ToString(ds.Tables[0].Rows[0]["Company_EmailID"]);
                        txtCompanyMobileNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["Company_MobileNo"]);

                        txtAdminName.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_Name"]);
                        txtUserDesignation.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_Designation"]);
                        txtUserEmailID.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_EmailID"]);
                        txtUserMobileNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_MobileNo"]);

                        txtClientURL.Text= Convert.ToString(ds.Tables[0].Rows[0]["ClientURL"]);

                        txtCompany_Code.ReadOnly = true;

                        int Is_DBatClientServer = Convert.ToInt32(ds.Tables[0].Rows[0]["Is_DBatClient"]);
                        if (Is_DBatClientServer == 1)
                        {
                            chk_IsDBatClient.Checked = true;
                            dvServerDetails.Visible = true;

                            string ConStr = Convert.ToString(ds.Tables[0].Rows[0]["Con_String"]);

                            string strServer = string.Empty;
                            string strDBName = string.Empty;
                            string strUserID = string.Empty;
                            string strPassword = string.Empty;

                            string[] strSplitValues = Regex.Split(ConStr, @"[;=]+");

                            if (strSplitValues.Length > 8)
                            {
                                txtServerName.Text = strSplitValues[1];
                                txtDatabase.Text = strSplitValues[3];
                                txtDbUser.Text = strSplitValues[7];
                                txtDbPassword.Text = strSplitValues[9];
                            }
                        }
                        else
                        {
                            chk_IsDBatClient.Checked = false;
                        }

                        

                        //string[] authorsList = ConStr.Split('=');

                        //int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        //if (Status == 0)
                        //{

                        //}
                        //else if (Status == 1)
                        //{
                        //    //Response.Redirect("~/Masters/Group_Mst.aspx", false);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void chk_IsDBatClient_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_IsDBatClient.Checked)
            {
                dvServerDetails.Visible = true;
            }
            else
            {
                dvServerDetails.Visible = false;
            }
        }

        public void DeleteCompany_Master(int CompanyID_Delete)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objUpkeepCC.CompanyMaster_CRUD(CompanyID_Delete, "", "", 0, "","", 0, "","","","","","","", LoggedInUserID, "D");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Redirect("~/Masters/Company_Mst.aspx", false);
                    }
                }
                else
                {
                    //invalid login
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}