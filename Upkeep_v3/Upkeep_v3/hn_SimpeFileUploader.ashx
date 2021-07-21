<%@ WebHandler Language="C#" Class="hn_SimpeFileUploader" %>

using System;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Configuration;
using System.IO;
using Upkeep_v3.Upkeep_V3_Services;
using System.Web.SessionState;

public class hn_SimpeFileUploader : IHttpHandler, IReadOnlySessionState
{
    string LoggedInUserID = string.Empty;
    int CompanyID = 0;
    string UserType = string.Empty;

    public void ProcessRequest(HttpContext context)
    {
        Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services();

        context.Response.ContentType = "text/plain";
        LoggedInUserID = Convert.ToString(context.Session["LoggedInUserID"]);
        CompanyID = Convert.ToInt32(context.Session["CompanyID"]);
        UserType = Convert.ToString(context.Session["UserType"]);


        string dirFullPath = HttpContext.Current.Server.MapPath("~/UserImages/");
        string[] files;
        int numFiles;
        files = System.IO.Directory.GetFiles(dirFullPath);
        numFiles = files.Length;
        numFiles = numFiles + 1;

        string str_image = "";
        string User_Code = string.Empty;
        string ProfilePhoto_FilePath = string.Empty;
        string imgPath = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadURL"]);
        DataSet dsProfile = new DataSet();

        foreach (string s in context.Request.Files)
        {
            HttpPostedFile file = context.Request.Files[s];
            string fileName = file.FileName;
            string fileExtension = file.ContentType;

            if (!string.IsNullOrEmpty(fileName))
            {
                string fileUploadPath_Profile = HttpContext.Current.Server.MapPath("~/UserImages/");

                if (!Directory.Exists(fileUploadPath_Profile))
                {
                    Directory.CreateDirectory(fileUploadPath_Profile);
                }

                User_Code = Convert.ToString(context.Session["User_Code"]);
                fileExtension = Path.GetExtension(fileName);
                str_image = User_Code + fileExtension;

                string pathToSave = HttpContext.Current.Server.MapPath("~/UserImages/") + str_image;
                ProfilePhoto_FilePath = imgPath + "/UserImages/" + str_image;

                file.SaveAs(pathToSave);
            }
        }
        dsProfile = ObjUpkeep.Update_User_ProfilePic(LoggedInUserID, UserType, ProfilePhoto_FilePath, CompanyID);

        if (dsProfile.Tables.Count > 0)
        {
            if (dsProfile.Tables[0].Rows.Count > 0)
            {
                int Status = Convert.ToInt32(dsProfile.Tables[0].Rows[0]["Status"]);
                if (Status == 1)
                {
                    context.Session["User_Code"] = "";
                    context.Session["Profile_Photo"] = ProfilePhoto_FilePath;
                }
            }
        }
        context.Response.Write(str_image);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }



}