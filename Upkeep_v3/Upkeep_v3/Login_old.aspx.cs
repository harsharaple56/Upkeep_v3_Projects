using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Configuration;

namespace Upkeep_v3
{
    public partial class Login_old : System.Web.UI.Page
    {

        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeepCC = new Upkeep_V3_Services.Upkeep_V3_Services();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblVersion.Text = Convert.ToString(ConfigurationManager.AppSettings["VersionNo"]);

            if (!IsPostBack)
            {
                
                if (Convert.ToString(Request.QueryString["Modules"]) != null)
                {
                    Session["ModuleID"] = Decrypt(HttpUtility.UrlDecode(Request.QueryString["Modules"]));
                }
                else
                {
                    //redirect to custome error page
                }

                if (Convert.ToString(Request.QueryString["CID"]) != null)
                {
                    Session["CompanyID"] = Decrypt(HttpUtility.UrlDecode(Request.QueryString["CID"]));
                }
                else
                {
                    //redirect to custome error page
                }

                Session["CompanyID"] = "2";
            }
        }

        private string Decrypt(string cipherText)
        {
            try
            {
                string EncryptionKey = "LOKESH_KA_UPKEEP_V3";
                cipherText = cipherText.Replace(" ", "+");
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cipherText;
        }

        public void btnLogin_Click(object sender, EventArgs e)
        {
            string UserType = string.Empty;
            try
            {
               
                if (rdbEmployee.Checked)
                {
                    UserType = "E";
                }
                else
                {
                    UserType = "R";
                }

                DataSet ds = new DataSet();
                ds = ObjUpkeepCC.LoginUser(txtUsername.Text.Trim(), txtPassword.Text, UserType,0);

                int AssignedRoleCount = 0;

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        AssignedRoleCount = Convert.ToInt32(ds.Tables[0].Rows[0]["RoleMenuCount"]);

                        if (AssignedRoleCount > 0)
                        {
                            Session["UserType"] = Convert.ToString(UserType);
                            if (UserType == "E")
                            {
                                Session["EmpCD"] = Convert.ToString(ds.Tables[0].Rows[0]["empcd"]);
                                Session["RollCD"] = Convert.ToString(ds.Tables[0].Rows[0]["rollcd"]);
                                Session["LoggedInUserID"] = Convert.ToString(ds.Tables[0].Rows[0]["User_ID"]);
                            }
                            else
                            {
                                Session["LoggedInUserID"] = Convert.ToString(txtUsername.Text.Trim());
                            }

                            Session["UserName"] = Convert.ToString(txtUsername.Text.Trim());
                            Session["LoggedInProfileName"] = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);

                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                Response.Redirect("~/Dashboard.aspx", false);
                            }
                            else
                            {
                                //invalid login
                                lblError.Text = "Invalid credential";
                            }
                        }
                        else
                        {
                            lblError.Text = "Dear " + txtUsername.Text.Trim() + " , no role has been assigned to you. Hence you cannot login. Please contact your Property Administrator for further assistance."; //No role assigned
                        }
                        //Session["Login_ID"] = Convert.ToString(ds.Tables[0].Rows[0]["User_ID"]);
                        //Session["LoggedInUserID"] = Convert.ToString(ds.Tables[0].Rows[0]["User_ID"]);
                        //Session["UserName"] = Convert.ToString(txtUsername.Text.Trim());
                        //if (ds.Tables[0].Rows.Count > 0)
                        //{
                        //    Response.Redirect("~/Dashboard.aspx", false);
                        //}
                        //else
                        //{
                        //    //invalid login
                        //    lblError.Text = "Invalid credential";
                        //}
                    }
                    else
                    {
                        //invalid login
                        lblError.Text = "Invalid credential";
                    }
                }
                else
                {
                    lblError.Text = "Invalid credential";
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