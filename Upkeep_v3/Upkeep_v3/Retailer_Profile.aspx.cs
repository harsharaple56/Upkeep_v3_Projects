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
    public partial class Retailer_Profile : System.Web.UI.Page
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
            
            //lblChangePasswordSuccess.Text = "";
            //lblChangePasswordError.Text = "";

            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }

            if (!IsPostBack)
            {
                Fetch_My_Profile_Details(LoggedInUserID, UserType, CompanyID);
                this.Bind_Retailer_Escalation_Grid();
            }
        }

        public void Fetch_My_Profile_Details(string LoggedInUserID,string UserType, int CompanyID)
        {
            DataSet dsProfile = new DataSet();
            try
            {
                dsProfile = ObjUpkeep.Fetch_My_Profile_Details(LoggedInUserID, UserType, CompanyID);

                if (dsProfile.Tables.Count > 0)
                {
                    if (dsProfile.Tables[0].Rows.Count > 0)
                    {
                        lblStorename.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["Store_Name"]);
                        lblStoreNo.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["Store_No"]);
                        lblUsername.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["Username"]);
                        lblFirstName.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["StoreManagerFirstName"]);
                        lblLastName.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["StoreManagerLastName"]);
                        txtContactNo.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["PhoneNo"]);
                        txtAlternatePhoneNo.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["Alternate_Contact"]);
                        //txtAltPhoneNo.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["User_MobileAlter"]);
                        txtEmailID.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["EmailID"]);
                        txtAddress.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["Address"]);
                        txtCity.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["City"]);
                        txtState.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["State"]);
                        txtPostcode.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["Postal_Code"]);

                        //lblUserCode.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["User_Code"]);
                        ////lblCompanyName1.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["Login_ID"]);
                        //lblCompanyCode.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["Company_Code"]);
                        //lblDesignation.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["User_Designation"]);
                        //lblReportingManager.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["ReportingManager"]);
                        //lblAssignedRole.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["Role_Name"]);
                        //lblLandlineNo.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["User_Landine"]);

                        lblProfileName.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["StoreManagerFirstName"])+" "+ Convert.ToString(dsProfile.Tables[0].Rows[0]["StoreManagerLastName"]);
                        lblProfileUsername.Text = Convert.ToString(dsProfile.Tables[0].Rows[0]["Username"]);

                        if (Convert.ToString(dsProfile.Tables[0].Rows[0]["Profile_Pic"]) != "")
                        {
                            imgProfilePic.ImageUrl = Convert.ToString(dsProfile.Tables[0].Rows[0]["Profile_Pic"]);
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

                PhoneNo = Convert.ToString(txtContactNo.Text.Trim());
                AltPhoneNo = Convert.ToString(txtAlternatePhoneNo.Text.Trim());
                EmailID = Convert.ToString(txtEmailID.Text.Trim());
                Address = Convert.ToString(txtAddress.Text.Trim());
                City = Convert.ToString(txtCity.Text.Trim());
                State = Convert.ToString(txtState.Text.Trim());
                Postcode = Convert.ToString(txtPostcode.Text.Trim());

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

        }

        private void Bind_Retailer_Escalation_Grid()
        {
            DataSet dsProfile = new DataSet();
            try
            {
                dsProfile = ObjUpkeep.Retailer_Escalation_CRUD(0, "", "", "", "", "", LoggedInUserID, CompanyID,"R");

                if (dsProfile.Tables.Count > 0)
                {
                    if (dsProfile.Tables[0].Rows.Count > 0)
                    {
                        gvEscalation.DataSource = dsProfile.Tables[0];
                        gvEscalation.DataBind();
                    }
                    
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void gvEscalation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //check if the row is the header row
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //add the thead and tbody section programatically
                e.Row.TableSection = TableRowSection.TableHeader;
            }

            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != gvEscalation.EditIndex)
            {
                (e.Row.Cells[6].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }

        protected void gvEscalation_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEscalation.EditIndex = e.NewEditIndex;
            this.Bind_Retailer_Escalation_Grid();
        }

        protected void gvEscalation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEscalation.EditIndex = -1;
            this.Bind_Retailer_Escalation_Grid();
        }

        protected void gvEscalation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEscalation.PageIndex = e.NewPageIndex;
            this.Bind_Retailer_Escalation_Grid();
        }

        protected void gvEscalation_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {            
            DataSet dsEscalation = new DataSet();
            try
            {
                string Name = string.Empty;
                string Designation = string.Empty;
                string Department = string.Empty;
                string ContactNo = string.Empty;
                string EmailID = string.Empty;
                int EscalationID = 0;

                GridViewRow row = gvEscalation.Rows[e.RowIndex];
                EscalationID = Convert.ToInt32(gvEscalation.DataKeys[e.RowIndex].Values[0]);
                
                Name = Convert.ToString((row.FindControl("txtName") as TextBox).Text);
                Designation = Convert.ToString((row.FindControl("txtDesignation") as TextBox).Text);
                Department = Convert.ToString((row.FindControl("txtDepartment") as TextBox).Text);
                ContactNo = Convert.ToString((row.FindControl("txtContactNo_Esc") as TextBox).Text);
                EmailID = Convert.ToString((row.FindControl("txtEmailID_Esc") as TextBox).Text);


                dsEscalation = ObjUpkeep.Retailer_Escalation_CRUD(EscalationID, Name, Designation, Department, ContactNo, EmailID, LoggedInUserID, CompanyID, "U");
                if (dsEscalation.Tables.Count > 0)
                {
                    if (dsEscalation.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsEscalation.Tables[0].Rows[0]["Status"]);

                        if (Status == 1)
                        {
                            gvEscalation.EditIndex = -1;
                            this.Bind_Retailer_Escalation_Grid();                           
                        }
                        else if (Status == 2)
                        {
                            lblEscalationError.Text = "User already exists";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvEscalation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet dsEscalation = new DataSet();
            try
            {                
                int EscalationID = 0;

                GridViewRow row = gvEscalation.Rows[e.RowIndex];
                EscalationID = Convert.ToInt32(gvEscalation.DataKeys[e.RowIndex].Values[0]);
                
                dsEscalation = ObjUpkeep.Retailer_Escalation_CRUD(EscalationID, "", "", "", "", "", LoggedInUserID, CompanyID, "D");
                if (dsEscalation.Tables.Count > 0)
                {
                    if (dsEscalation.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsEscalation.Tables[0].Rows[0]["Status"]);

                        if (Status == 1)
                        {
                            this.Bind_Retailer_Escalation_Grid();
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAddEscalation_Click(object sender, EventArgs e)
        {
            
            DataSet dsEscalation = new DataSet();
            try
            {
                string Name = string.Empty;
                string Designation = string.Empty;
                string Department = string.Empty;
                string ContactNo = string.Empty;
                string EmailID = string.Empty;
                int EscalationID = 0;

                Name = Convert.ToString(txtAddName.Text.Trim());
                Designation = Convert.ToString(txtAddDesignation.Text.Trim());
                Department = Convert.ToString(txtAddDepartment.Text.Trim());
                ContactNo = Convert.ToString(txtAddContactNo.Text.Trim());
                EmailID = Convert.ToString(txtAddEmailID.Text.Trim());


                dsEscalation = ObjUpkeep.Retailer_Escalation_CRUD(EscalationID, Name, Designation, Department, ContactNo, EmailID, LoggedInUserID, CompanyID,"C");
                if (dsEscalation.Tables.Count > 0)
                {
                    if (dsEscalation.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsEscalation.Tables[0].Rows[0]["Status"]);

                        if (Status == 1)
                        {
                            this.Bind_Retailer_Escalation_Grid();
                            //lblChangePasswordSuccess.Text = "Data saved successfully.";
                            //mpeChangePassword.Hide();
                        }
                        else if (Status == 2)
                        {
                            lblEscalationError.Text = "User already exists";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}