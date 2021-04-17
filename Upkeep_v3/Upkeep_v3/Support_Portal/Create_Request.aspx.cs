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

namespace Upkeep_v3.Support_Portal
{
    public partial class Create_Request : System.Web.UI.Page
    {

        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeepCC = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

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
            int Module_ID=5;
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


            if (fileUpload_RequestImage.HasFile)
            {
                string fileUploadPath_RequestImagePath = HttpContext.Current.Server.MapPath("~/Support_Portal/Images/");



                if (!Directory.Exists(fileUploadPath_RequestImagePath))
                {
                    Directory.CreateDirectory(fileUploadPath_RequestImagePath);
                }

                string fileExtension = Path.GetExtension(fileUpload_RequestImage.FileName);
                //Request_Photo = User_Code + fileExtension;

                //string Profile_SaveLocation = Server.MapPath("~/Support_Portal/Images/") + "/" + ProfilePhoto;
                //RequestPhoto_FilePath = imgPath + "~/Support_Portal/Images/" + ProfilePhoto;

                //fileUpload_UserImage.PostedFile.SaveAs(Profile_SaveLocation);

            }
            
            ds = ObjUpkeepCC.SUPPORT_Save_Request(CompanyID,  Request_Type,  Module_ID, Request_Description,  LoggedInUserID);

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




    }
}