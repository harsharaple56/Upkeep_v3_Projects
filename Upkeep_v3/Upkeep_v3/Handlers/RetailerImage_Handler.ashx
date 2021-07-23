<%@ WebHandler Language="C#" Class="RetailerImage_Handler" %>

using System;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Configuration;
using System.IO;
using Upkeep_v3.Upkeep_V3_Services;
using System.Web.SessionState;

public class RetailerImage_Handler : IHttpHandler , IReadOnlySessionState
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


        string dirFullPath = HttpContext.Current.Server.MapPath("~/RetailerImages/");
        string[] files;
        int numFiles;
        files = System.IO.Directory.GetFiles(dirFullPath);
        numFiles = files.Length;
        numFiles = numFiles + 1;

        string str_image = "";
        string Store_No = string.Empty;
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
                string fileUploadPath_Profile = HttpContext.Current.Server.MapPath("~/RetailerImages/");

                if (!Directory.Exists(fileUploadPath_Profile))
                {
                    Directory.CreateDirectory(fileUploadPath_Profile);
                }

                Store_No = Convert.ToString(context.Session["Store_No"]);
                fileExtension = Path.GetExtension(fileName);
                str_image = Store_No + fileExtension;

                string pathToSave = HttpContext.Current.Server.MapPath("~/RetailerImages/") + str_image;
                ProfilePhoto_FilePath = imgPath + "/RetailerImages/" + str_image;

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
                    context.Session["Store_No"] = "";
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
            return true;
        }
    }

}