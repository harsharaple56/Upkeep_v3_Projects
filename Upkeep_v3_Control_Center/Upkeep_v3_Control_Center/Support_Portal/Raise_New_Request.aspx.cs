using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data;
using System.IO;
using System.Configuration;

namespace Upkeep_v3_Control_Center.Support_Portal
{
    public partial class Raise_New_Request : System.Web.UI.Page
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
                PopulateLicenseMasters();

                Fetch_ddlModule();
                Fetch_ddlUser_List();



            }

            //Check_SMS_Balance_API("");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int User_ID = 0;
            if (Convert.ToString(Session["User_ID"]) != "")
            {
                User_ID = Convert.ToInt32(Session["User_ID"]);
            }
            DataSet ds = new DataSet();

            string Request_Type = string.Empty;
            int Module_ID = Convert.ToInt32(ddlModule.SelectedValue); 
            string Request_Description = string.Empty;

            Request_Type = Convert.ToString(ddlRequestType.SelectedValue);
            //Module_ID = Convert.ToInt32(ddlModule.SelectedValue);
            Request_Description = txtRequestDescription.InnerText.Trim();

            string Request_Photo = string.Empty;
            string RequestPhoto_FilePath = string.Empty;

            string imgPath = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadURL"]);

            string Token_No_For_Folder = string.Empty;
            Random random = new Random();
            if (Token_No_For_Folder == "0")
            {
                Token_No_For_Folder = random.Next(0, 999999999).ToString("D9");
            }

            int i = 0;
            string fileName = string.Empty;
            List<string> Lst_Images = new List<string>();

            if (fileUpload_RequestImage.HasFile)
            {
                string fileUploadPath_RequestImagePath = HttpContext.Current.Server.MapPath("~/Support_Portal/Images/" + Token_No_For_Folder);

                if (!Directory.Exists(fileUploadPath_RequestImagePath))
                {
                    Directory.CreateDirectory(fileUploadPath_RequestImagePath);
                }

                foreach (HttpPostedFile postfiles in fileUpload_RequestImage.PostedFiles)
                {
                    string fileExtension = Path.GetExtension(fileUpload_RequestImage.FileName);
                    fileName = Convert.ToString(i) + "_" + fileExtension;

                    string SaveLocation = Server.MapPath("~/Support_Portal/Images/" + Token_No_For_Folder) + "/" + fileName;
                    string FileLocation = imgPath + "/Support_Portal/Images/" + Token_No_For_Folder + "/" + fileName;

                    postfiles.SaveAs(SaveLocation);
                    Lst_Images.Add(FileLocation);

                    i = i + 1;

                }
            }

            string list_Images = String.Join(",", Lst_Images);

            int CompanyID = Convert.ToInt32(ddlcompanyName.SelectedValue);
            string Selected_ddlUser = Convert.ToString(ddlUser.SelectedValue);

            ds = objUpkeepCC.SUPPORT_Save_Request(CompanyID, Request_Type, Module_ID, Request_Description, Selected_ddlUser);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                    if (Status == 1)
                    {
                        Session["User_ID"] = "";

                        Response.Redirect(Page.ResolveClientUrl("~/Support_Portal/View_Request_List.aspx"), false);
                    }
                    else if (Status == 2)
                    {

                        lblError.InnerText = "Due to some technical issue your request can not be process. Kindly try after some time";
                    }
                }
            }


        }

        public void Fetch_ddlModule()
        {
            int CompanyID = Convert.ToInt32(ddlcompanyName.SelectedValue);


            DataSet dsDept = new DataSet();
            try
            {
                dsDept = objUpkeepCC.Fetch_License_Module_list(CompanyID);

                if (dsDept.Tables.Count > 0)
                {
                    if (dsDept.Tables[0].Rows.Count > 0)
                    {
                        ddlModule.DataSource = dsDept.Tables[0];
                        ddlModule.DataTextField = "Module_Desc";
                        ddlModule.DataValueField = "Module_ID";
                        ddlModule.DataBind();
                        ddlModule.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Fetch_ddlUser_List()
        {
            int CompanyID = Convert.ToInt32(ddlcompanyName.SelectedValue);

            DataSet dsDept = new DataSet();
            try
            {
                dsDept = objUpkeepCC.Fetch_User_List(CompanyID);

                if (dsDept.Tables.Count > 0)
                {
                    if (dsDept.Tables[0].Rows.Count > 0)
                    {
                        ddlUser.DataSource = dsDept.Tables[0];
                        ddlUser.DataTextField = "User_List";
                        ddlUser.DataValueField = "User_ID";
                        ddlUser.DataBind();
                        ddlUser.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void PopulateLicenseMasters()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objUpkeepCC.PopulateLicenseMasters();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlcompanyName.DataSource = ds.Tables[0];
                        ddlcompanyName.DataTextField = "Company";
                        ddlcompanyName.DataValueField = "Company_ID";
                        ddlcompanyName.DataBind();
                        ddlcompanyName.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void ddlcompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // module
            Fetch_ddlModule();

            // user
            Fetch_ddlUser_List();
            
        }
    }
}