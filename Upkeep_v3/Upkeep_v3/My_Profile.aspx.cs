using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Text;
using System.IO;

namespace Upkeep_v3
{
    public partial class My_Profile : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            lblChangePasswordSuccess.Text = "";
            lblChangePasswordError.Text = "";

            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }

            if (!IsPostBack)
            {
                Fetch_My_Profile_Details(Convert.ToInt32(LoggedInUserID), CompanyID);
            }
        }

        public void Fetch_My_Profile_Details(int LoggedInUserID, int CompanyID)
        {
            DataSet dsProfile = new DataSet();
            try
            {
                dsProfile = ObjUpkeep.Fetch_My_Profile_Details(LoggedInUserID, CompanyID);

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
                        //lblCompanyName1.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["Login_ID"]);
                        lblCompanyCode.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["Company_Code"]);
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

                dsProfile = ObjUpkeep.Update_My_Profile_Details(PhoneNo, AltPhoneNo, EmailID, Address, City, State, Postcode, LoggedInUserID, CompanyID);
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

                dsChangePassword = ObjUpkeep.Update_Change_Password(Username, CurrentPassword, NewPassword, CompanyID);
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
    }
}