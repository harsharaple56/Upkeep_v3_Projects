using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using System.Security.Cryptography;

namespace Upkeep_v3_Control_Center
{
    public partial class Company_Code : System.Web.UI.Page
    {
        UpkeepControlCenter_Service.UpkeepControlCenter_Service objUpkeepCC = new UpkeepControlCenter_Service.UpkeepControlCenter_Service();
        DataSet dsLogin = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnCompany_Code(object sender, EventArgs e)
        {
            string ClientURL = string.Empty;
            string Modules = string.Empty;
            string EncryptedModules = string.Empty;
            dsLogin = objUpkeepCC.ValidateCompany(txtCompanyCode.Text.Trim());

            if (dsLogin.Tables.Count > 0)
            {
                if (dsLogin.Tables[0].Rows.Count > 0)
                {
                    int Status = Convert.ToInt32(dsLogin.Tables[0].Rows[0]["Status"]);
                    //if (Status == 0)
                    //{

                    //}
                    //else 
                    if (Status == 1)
                    {
                        ClientURL= Convert.ToString(dsLogin.Tables[1].Rows[0]["ClientURL"]);
                        Modules = Convert.ToString(dsLogin.Tables[1].Rows[0]["Module_ID"]);
                        EncryptedModules = HttpUtility.UrlEncode(Encrypt(Modules));
                        Response.Redirect(Page.ResolveClientUrl(ClientURL+"?Modules="+ EncryptedModules), false);
                    }
                    else if (Status == 3)
                    {
                        lblError.Text = "Company Code not exists";
                    }
                    else if (Status == 2)
                    {
                        lblError.Text = "License Expired, Kindly contact Upkeep Support Team";
                    }
                }
            }
        }

        private string Encrypt(string clearText)
        {
            string EncryptionKey = "LOKESH_KA_UPKEEP_V3"; //"MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

    }
}