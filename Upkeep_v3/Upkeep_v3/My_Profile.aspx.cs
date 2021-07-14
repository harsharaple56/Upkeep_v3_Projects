using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Services;
using System.Text;
using System.IO;

namespace Upkeep_v3
{
    public partial class My_Profile : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        string UserType = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            UserType = Convert.ToString(Session["UserType"]);

            lblChangePasswordSuccess.Text = "";
            lblChangePasswordError.Text = "";

            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }

            if (!IsPostBack)
            {
                //dvOTPBox.Attributes.Add("style", "display:none;");
                Fetch_My_Profile_Details(LoggedInUserID, UserType, CompanyID);
            }
        }

        public void Fetch_My_Profile_Details(string LoggedInUserID, string UserType, int CompanyID)
        {
            DataSet dsProfile = new DataSet();
            try
            {
                dsProfile = ObjUpkeep.Fetch_My_Profile_Details(LoggedInUserID, UserType, CompanyID);

                if (dsProfile.Tables.Count > 0)
                {
                    if (dsProfile.Tables[0].Rows.Count > 0)
                    {
                        lblUsername.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["Login_ID"]);
                        lblFirstName.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["F_Name"]);
                        lblLastName.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["L_Name"]);
                        //lblCompanyName.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["Login_ID"]);
                        txtPhoneNo.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["User_Mobile"]);
                        txtAltPhoneNo.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["User_MobileAlter"]);
                        txtEmail.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["User_Email"]);
                        txtAddress.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["Address"]);
                        txtCity.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["City"]);
                        txtState.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["State"]);
                        txtPostCode.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["Postcode"]);

                        lblUserCode.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["User_Code"]);

                        Session["User_Code"]= Convert.ToString(dsProfile.Tables[0].Rows[0]["User_Code"]);

                        lblCompanyName.Text = Convert.ToString(Session["CompanyName"]);
                        lblCompanyCode.Text = Convert.ToString(Session["CompanyCode"]);
                        lblDesignation.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["User_Designation"]);
                        lblReportingManager.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["ReportingManager"]);
                        lblAssignedRole.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["Role_Name"]);
                        lblLandlineNo.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["User_Landine"]);

                        lblProfileName.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["ProfileName"]);
                        lblProfileUsername.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["Login_ID"]);

                        if (Convert.ToString(dsProfile.Tables[0].Rows[0]["Profile_Photo"]) != "")
                        {
                            imgProfilePic.ImageUrl = Convert.ToString(dsProfile.Tables[0].Rows[0]["Profile_Photo"]);
                        }
                        else
                        {
                            imgProfilePic.ImageUrl = Page.ResolveClientUrl("~/assets/app/media/img/users/user4.png");
                        }

                        int Is_Email_Verified = Convert.ToInt32(dsProfile.Tables[0].Rows[0]["Is_Email_Verified"]);
                        if (Is_Email_Verified == 1)
                        {
                            lnkVerifyEmail.Attributes.Add("style", "display:none;");
                            lblMailVerifySuccess.Attributes.Add("style", "display:block;margin-top: 13px;");

                            dvOTPBox.Attributes.Add("style", "display:none;");
                            //dvOTPSubmit.Attributes.Add("style", "display:none;");
                            lblMailVerifyFail.Attributes.Add("style", "display:none;");
                        }


                    }
                    else
                    {

                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataSet dsProfile = new DataSet();
            try
            {
                string PhoneNo = string.Empty;
                string AltPhoneNo = string.Empty;
                string EmailID = string.Empty;
                string Address = string.Empty;
                string City = string.Empty;
                string State = string.Empty;
                string Postcode = string.Empty;

                PhoneNo = Convert.ToString(txtPhoneNo.Text.Trim());
                AltPhoneNo = Convert.ToString(txtAltPhoneNo.Text.Trim());
                EmailID = Convert.ToString(txtEmail.Text.Trim());
                Address = Convert.ToString(txtAddress.Text.Trim());
                City = Convert.ToString(txtCity.Text.Trim());
                State = Convert.ToString(txtState.Text.Trim());
                Postcode = Convert.ToString(txtPostCode.Text.Trim());

                dsProfile = ObjUpkeep.Update_My_Profile_Details(PhoneNo, AltPhoneNo, EmailID, Address, City, State, Postcode, LoggedInUserID, UserType, CompanyID);
                if (dsProfile.Tables.Count > 0)
                {
                    if (dsProfile.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsProfile.Tables[0].Rows[0]["Status"]);

                        if (Status == 1)
                        {
                            lblMsg.Text = "Profile details updated successfully.";
                            btnSubmit.Focus();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnChangePassword_Submit_Click(object sender, EventArgs e)
        {
            DataSet dsChangePassword = new DataSet();
            try
            {
                string Username = string.Empty;
                string CurrentPassword = string.Empty;
                string NewPassword = string.Empty;

                Username = Convert.ToString(Session["UserName"]);
                CurrentPassword = Convert.ToString(txtCurrentPassword.Text.Trim());
                NewPassword = Convert.ToString(txtNewPassword.Text.Trim());

                dsChangePassword = ObjUpkeep.Update_Change_Password(Username, CurrentPassword, NewPassword, CompanyID, UserType);
                if (dsChangePassword.Tables.Count > 0)
                {
                    if (dsChangePassword.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsChangePassword.Tables[0].Rows[0]["Status"]);

                        if (Status == 1)
                        {
                            lblChangePasswordSuccess.Text = "Password changed successfully.";
                            //mpeChangePassword.Hide();
                        }
                        else if (Status == 2)
                        {
                            lblChangePasswordError.Text = "Current Password is incorrect";
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnChangePassword_Cancel_Click(object sender, EventArgs e)
        {
            mpeChangePassword.Hide();
        }

        protected void lnkVerifyEmail_Click(object sender, EventArgs e)
        {
            DataSet dsVerifyEmail = new DataSet();
            try
            {
                Random random = new Random();
                string OTP = string.Empty;

                OTP = random.Next(0, 999999).ToString("D6");

                Session["OTP"] = OTP;

                dsVerifyEmail = ObjUpkeep.Email_Verification_Mail(Convert.ToString(txtEmail.Text.Trim()), OTP);

                if (dsVerifyEmail.Tables.Count > 0)
                {
                    if (dsVerifyEmail.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsVerifyEmail.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            lnkVerifyEmail.Attributes.Add("style", "display:none;");
                            lblMailVerifyFail.Attributes.Add("style", "display:none;");
                            lblMailVerifySuccess.Attributes.Add("style", "display:none;");

                            dvOTPBox.Attributes.Add("class", "form-group m-form__group row");
                            dvOTPBox.Visible = true;
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnVerifyOTP_Click(object sender, EventArgs e)
        {
            DataSet dsProfile = new DataSet();
            int Is_Email_Verified = 0;
            try
            {
                if (Convert.ToString(txtEmailOTP.Text) == Convert.ToString(Session["OTP"]))
                {
                    Is_Email_Verified = 1;
                    lblMailVerifySuccess.Attributes.Add("style", "display:block;margin-top: 13px;");

                    dvOTPBox.Attributes.Add("style", "display:none;");
                    //dvOTPSubmit.Attributes.Add("style", "display:none;");
                    lblMailVerifyFail.Attributes.Add("style", "display:none;");
                }

                else
                {
                    Is_Email_Verified = 0;
                    lblMailVerifyFail.Attributes.Add("style", "display:block;");
                    lblMailVerifyFail.Text = "Invalid OTP";

                }

                dsProfile = ObjUpkeep.My_Profile_Email_Verification(Is_Email_Verified, LoggedInUserID, CompanyID);
                if (dsProfile.Tables.Count > 0)
                {
                    if (dsProfile.Tables[0].Rows.Count > 0)
                    {
                        //int Status = Convert.ToInt32(dsProfile.Tables[0].Rows[0]["Status"]);

                        //if (Status == 1)
                        //{
                            
                        //}
                    }
                }




            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnChangeProfilePic_Click(object sender, EventArgs e)
        {
            DataSet dsProfile = new DataSet();
            try
            {
                string ProfilePhoto_FilePath = string.Empty;
                string imgPath = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadURL"]);
                string ProfilePhoto = string.Empty;
                string User_Code = string.Empty;
                //if (profile_picture.PostedFile.FileName!="")
                //{
                //    string fileUploadPath_Profile = HttpContext.Current.Server.MapPath("~/UserImages/");

                //    if (!Directory.Exists(fileUploadPath_Profile))
                //    {
                //        Directory.CreateDirectory(fileUploadPath_Profile);
                //    }

                //    User_Code = Convert.ToString(Session["User_Code"]);

                //    string fileExtension = Path.GetExtension(profile_picture.PostedFile.FileName);
                //    ProfilePhoto = User_Code + fileExtension;

                //    string Profile_SaveLocation = Server.MapPath("~/UserImages/") + "/" + ProfilePhoto;
                //    ProfilePhoto_FilePath = imgPath + "/UserImages/" + ProfilePhoto;

                //    profile_picture.PostedFile.SaveAs(Profile_SaveLocation);

                //}

                dsProfile = ObjUpkeep.Update_User_ProfilePic(LoggedInUserID, UserType, ProfilePhoto_FilePath, CompanyID);

                if (dsProfile.Tables.Count > 0)
                {
                    if (dsProfile.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsProfile.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            Session["User_Code"] = "";

                            Response.Redirect(Page.ResolveClientUrl("~/My_Profile.aspx"), false);
                        }
                       
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public void Update_User_ProfilePic()
        {


        }

    }
}