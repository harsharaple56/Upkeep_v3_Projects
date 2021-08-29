<%@ WebHandler Language="C#" Class="VCertificate_Handler" %>

using System;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Configuration;
using System.IO;
using Upkeep_v3.Upkeep_V3_Services;
using System.Web.SessionState;

public class VCertificate_Handler : IHttpHandler, IReadOnlySessionState
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


        string dirFullPath = HttpContext.Current.Server.MapPath("~/VaccinationCertificate/");
        string[] files;
        int numFiles;
        files = System.IO.Directory.GetFiles(dirFullPath);
        numFiles = files.Length;
        numFiles = numFiles + 1;

        string str_image = string.Empty;
        string ProfilePhoto_FilePath = string.Empty;
        string imgPath = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadURL"]);
        foreach (string s in context.Request.Files)
        {
            HttpPostedFile file = context.Request.Files[s];
            string fileName = file.FileName;
            string fileExtension = file.ContentType;
            if (!string.IsNullOrEmpty(fileName))
            {
                string fileUploadPath_Profile = HttpContext.Current.Server.MapPath("~/VaccinationCertificate/");

                if (!Directory.Exists(fileUploadPath_Profile))
                {
                    Directory.CreateDirectory(fileUploadPath_Profile);
                }

                Random r = new Random();
                int genRand = r.Next(1, 1000);

                DataSet ds = new DataSet();
                int id = 0;
                ds = ObjUpkeep.GetLastVMSRequestID(CompanyID);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    id = Convert.ToInt32(row["RequestID"]);
                }
                id++;

                fileExtension = Path.GetExtension(fileName);
                str_image = id + "_" + genRand + "_" + DateTime.Now.ToString("dd-MMM-yy") + fileExtension;

                string pathToSave = HttpContext.Current.Server.MapPath("~/VaccinationCertificate/") + str_image;
                ProfilePhoto_FilePath = imgPath + "/VaccinationCertificate/" + str_image;
                context.Session["fileContent"] = string.Empty;
                context.Session["fileContent"] = str_image;
                file.SaveAs(pathToSave);
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