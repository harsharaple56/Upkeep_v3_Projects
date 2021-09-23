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
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Sharpbrake.Client;
//using System.Net.WebClient;

namespace Upkeep_v3
{
    public partial class Forgot_Password : System.Web.UI.Page
    {

        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeepCC = new Upkeep_V3_Services.Upkeep_V3_Services();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ForgotPassword(object sender, EventArgs e)
        {
            string UserType = string.Empty;
            int status = 0;

            try
            {
                bool isInternet = CheckForInternetConnection();
                if (isInternet)
                {
                    string strStatus = Convert.ToString(Session["Status"]);

                    if (!string.IsNullOrEmpty(strStatus))
                    {
                        status = Convert.ToInt32(strStatus);
                    }

                    if (status == 1)
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
                        int CompanyID = 0;

                        if (Convert.ToString(Session["CompanyID"]) != "")
                        {
                            CompanyID = Convert.ToInt32(Session["CompanyID"]);
                        }


                        ds = ObjUpkeepCC.FetchUserEmail(txtEmail.Text.Trim(), UserType, CompanyID);



                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {

                                Session["UserType"] = Convert.ToString(UserType);
                                if (UserType == "E")
                                {
                                    Session["EmailID"] = Convert.ToString(ds.Tables[0].Rows[0]["User_Email"]);
                                    Session["User_ID"] = Convert.ToString(ds.Tables[0].Rows[0]["User_ID"]);


                                }
                                else
                                {
                                    Session["User_ID"] = Convert.ToString(ds.Tables[0].Rows[0]["Retailer_ID"]);
                                    Session["EmailID"] = Convert.ToString(ds.Tables[0].Rows[0]["EmailID"]);
                                }




                                if (status == 1)
                                {


                                    dvCompanyCode.Attributes.Add("style", "display:none;");
                                    DivOtp.Attributes.Add("style", "display:block;");
                                    //dvCompanyLogo.Attributes.Add("style", "display:block; text-align: center;");



                                    Random random = new Random();
                                    string OTP = string.Empty;

                                    OTP = random.Next(0, 999999).ToString("D6");

                                    Session["OTP"] = OTP;


                                    ds = ObjUpkeepCC.ForgetPasswordSendOTP(Convert.ToString(Session["EmailID"]), OTP, CompanyID);

                                }
                                else if (status == 2)
                                {
                                    lblError.Text = "License Expired, Kindly contact eFacilito Support Team";
                                    txtEmail.Text = "";


                                }
                                else if (status == 3)
                                {
                                    lblError.Text = "Invalid Email Id";
                                    txtEmail.Text = "";


                                }

                            }
                            else
                            {
                                //invalid login
                                if (ds.Tables[1].Rows.Count > 0)
                                {
                                    lblError.Text = "This Email-ID is not registered under the " + ds.Tables[1].Rows[0]["Company_Desc"].ToString();
                                }
                            }
                        }
                        else
                        {
                            lblError.Text = "Invalid credential";
                            //invalid login
                        }

                    }
                    else if (status == 2)
                    {
                        lblError.Text = "License Expired, Kindly contact eFacilito Support Team";
                        txtEmail.Text = "";

                        //txtUsername.ReadOnly = true;
                        //txtPassword.ReadOnly = true;
                    }
                    else if (status == 3)
                    {
                        lblError.Text = "Invalid Company Code";
                        txtEmail.Text = "";

                        //txtUsername.ReadOnly = true;
                        //txtPassword.ReadOnly = true;
                    }
                    else
                    {
                        lblError.Text = "Please try again later";
                        txtEmail.Text = "";
                        //txtUsername.ReadOnly = true;
                        //txtPassword.ReadOnly = true;
                    }
                }
                else
                {
                    lblError.Text = "Unable to connect to Server. Please try again later.";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new System.Net.WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {


            if (txtOtp.Text == Session["OTP"].ToString())
            {

                lblError.Text = "";
                DivOtp.Attributes.Add("style", "display:none;");
                dvCompanyCode.Attributes.Add("style", "display:none;");
                DivChangePassword.Attributes.Add("style", "display:block;");
                // DivOtp.Attributes.Add("style", "display:block;");



            }

            else
            {
                lblError.Text = "Invalid OTP";

            }


        }

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            lblError.Text = "";
            int User_ID = 0;
            if (Convert.ToString(Session["User_ID"]) != "")
            {
                User_ID = Convert.ToInt32(Session["User_ID"]);
            }

            int CompanyID = 0;

            if (Convert.ToString(Session["CompanyID"]) != "")
            {
                CompanyID = Convert.ToInt32(Session["CompanyID"]);
            }

            string Password = string.Empty;
            string ConfirmPassword = string.Empty;
            string EmailID = Convert.ToString(Session["EmailID"]);
            string UserType = Convert.ToString(Session["UserType"]);



            Password = TxtPassword.Text.Trim();
            ConfirmPassword = TxtConfrmPassword.Text.Trim();


            ds = ObjUpkeepCC.UpdatePassword(Convert.ToString(Session["User_ID"]), EmailID, Password, UserType, CompanyID);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                    if (Status == 1)
                    {
                        Session["User_ID"] = "";

                        Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
                    }
                    else if (Status == 3)
                    {
                        lblError.Text = "User already exists";
                    }
                    else if (Status == 2)
                    {
                        lblError.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                    }
                }
            }

        }
    }
}