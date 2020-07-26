using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data;


namespace Upkeep_v3.General_Masters
{
    public partial class Add_User_Mst : System.Web.UI.Page

    {

        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeepCC = new Upkeep_V3_Services.Upkeep_V3_Services();

        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)

        {
            //frmAddUser.Action = @"Add_User_Mst.aspx";
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            //if (string.IsNullOrEmpty(LoggedInUserID))
            //{
            //    Response.Redirect("~/Login.aspx", false);
            //}
            if (!IsPostBack)
            {
                //Commented by sujata
                //bindZoneDesc();
                bindUserType();
                bindDepartment();
                int User_ID = Convert.ToInt32(Request.QueryString["User_ID"]);
                int User_ID_Delete = Convert.ToInt32(Request.QueryString["DelUser_ID"]);
                if (User_ID > 0)
                {
                    Session["User_ID"] = Convert.ToString(User_ID);
                    bindUser_Master(User_ID);
                }
                if (User_ID_Delete > 0)
                {
                    DeleteUser_Master(User_ID_Delete);
                }
            }


        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int User_ID = Convert.ToInt32(Session["User_ID"]);
            string Action = "";
            DataSet ds = new DataSet();

            if (User_ID > 0)
            {
                Action = "U";
            }
            else
            {
                Action = "C";
            }

            int Zone = 0;
            int location = 0;
            int subLocation = 0;
            int Department = 0;
            string User_Code = string.Empty;
            string F_Name = string.Empty;
            string L_Name = string.Empty;
            string User_Mobile = string.Empty;
            string User_MobileAlter = string.Empty;
            string User_Landline = string.Empty;
            string User_Designation = string.Empty;
            int User_Type_ID = 0;
            string Login_Id = string.Empty;
            string password = string.Empty;
            int Is_Approver = 0;
            string ProfilePhoto = string.Empty;
            string User_Email = string.Empty;
            int Approver_ID = 0;
            int Is_GobalApprover = 0;
            int RoleID = 0;


            User_Code = txtUserCode.Text.Trim();
            F_Name = txtFirstName.Text.Trim();
            L_Name = txtlastName.Text.Trim();
            User_Mobile = txtmobile.Text.Trim();
            User_Email = txtuseremail.Text.Trim();
            User_MobileAlter = txtAlterMobile.Text.Trim();
            User_Landline = TxtLandline.Text.Trim();
            User_Designation = txtUserDesignation.Text.Trim();
            User_Type_ID = 0; //Convert.ToInt32(ddlTypeUser.SelectedValue);
            Login_Id = txtUserLogin.Text.Trim();
            password = txtPassword.Text.Trim();
            Zone = 0;           //Commented by sujata       Convert.ToInt32(ddlZone.SelectedValue);
            location = 0;       //Commented by sujata       Convert.ToInt32(ddlLocation.SelectedValue);
            subLocation = 0;    //Commented by sujata       Convert.ToInt32(ddlSublocation.SelectedValue);
            Department = 0;     //Commented by sujata       Convert.ToInt32(ddlDepartment.SelectedValue);
            Department = Convert.ToInt32(ddlDepartment.SelectedValue);

            if (chk_IsApproval.Checked == true)
            {
                Is_Approver = 1;
                //Approver_ID = txtApprovalId.Text.Trim();
            }
            else
            {
                Is_Approver = 0;

            }
            if (chk_IsGobalApproval.Checked == true)
            {
                Is_GobalApprover = 1;

            }
            else
            {
                Is_GobalApprover = 0;

            }

            if (fileUpload_UserImage.HasFile)
            {
                //CompanyLogoName = Path.GetFileName(fileUpload_CompanyLogo.PostedFile.FileName);
                fileUpload_UserImage.PostedFile.SaveAs(Server.MapPath("~/UserImages/") + User_Code + ".PNG");
                ProfilePhoto = User_Code + ".PNG";
            }
            else
            {
                //User_Code = "";
            }


            Approver_ID = Convert.ToInt32(ddlApprover.SelectedValue);
            RoleID = Convert.ToInt32(ddlRole.SelectedValue);

            ds = ObjUpkeepCC.UserMaster_CRUD(User_ID, User_Code, F_Name, L_Name, User_Mobile, User_Email, User_MobileAlter, User_Landline, User_Designation, User_Type_ID, Zone, location, subLocation, Department, Login_Id, password, Is_Approver, Is_GobalApprover, Approver_ID, RoleID, ProfilePhoto, CompanyID, LoggedInUserID, Action);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                    if (Status == 1)
                    {
                        Session["User_ID"] = "";

                        Response.Redirect(Page.ResolveClientUrl("~/General_Masters/User_Mst.aspx"), false);
                    }
                    else if (Status == 3)
                    {
                        lblUserErrorMsg.Text = "User, UserCode, MobileNo already exists";
                    }
                    else if (Status == 2)
                    {
                        lblUserErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                    }
                }
            }
            
        }

        protected void chk_IsApproval_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_IsApproval.Checked)
            {
                dvApprovalID.Visible = true;

            }
            else
            {
                dvApprovalID.Visible = false;
            }

        }

        protected void chk_IsGobalApproval_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //Commented by sujata
        //protected void ddlSublocation_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    bindSubLoctionDesc(Convert.ToInt32(ddlLocation.SelectedValue));
        //}

        //protected void ddlZone_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    bindLoctionDesc(Convert.ToInt32(ddlZone.SelectedValue));

        //}


        //public void bindZoneDesc()
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();

        //        ds = ObjUpkeepCC.Fetch_Zone();

        //        if (ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                ddlZone.DataSource = ds.Tables[0];
        //                ddlZone.DataTextField = "Zone";
        //                ddlZone.DataValueField = "Zone_ID";
        //                ddlZone.DataBind();
        //                ddlZone.Items.Insert(0, new ListItem("--Select--", "0"));


        //            }

        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}
        //public void bindLoctionDesc(int Zone)
        //{
        //    try
        //    {


        //        //int Zone;

        //        DataSet ds = new DataSet();

        //        Zone = Convert.ToInt32(ddlZone.SelectedValue);


        //        ds = ObjUpkeepCC.Fetch_Location(Zone);

        //        if (ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                ddlLocation.DataSource = ds.Tables[0];
        //                ddlLocation.DataTextField = "Location";
        //                ddlLocation.DataValueField = "Loc_ID";
        //                ddlLocation.DataBind();
        //                ddlLocation.Items.Insert(0, new ListItem("--Select--", "0"));
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        //public void bindSubLoctionDesc(int LocID)
        //{
        //    try
        //    {
        //       // int LocID;

        //        DataSet ds = new DataSet();

        //        LocID = Convert.ToInt32(ddlLocation.SelectedValue);


        //        ds = ObjUpkeepCC.Fetch_Sub_Location(LocID);

        //        if (ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                ddlSublocation.DataSource = ds.Tables[0];
        //                ddlSublocation.DataTextField = "SubLocation";
        //                ddlSublocation.DataValueField = "SubLoc_ID";
        //                ddlSublocation.DataBind();
        //                ddlSublocation.Items.Insert(0, new ListItem("--Select--", "0"));
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}
        //end Commented by sujata

        public void bindDepartment()
        {
            try
            {



                DataSet ds = new DataSet();



                ds = ObjUpkeepCC.Fetch_Department(CompanyID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlDepartment.DataSource = ds.Tables[0];
                        ddlDepartment.DataTextField = "Department";
                        ddlDepartment.DataValueField = "Department_ID";
                        ddlDepartment.DataBind();
                        ddlDepartment.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void ddlTypeUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void bindUserType()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = ObjUpkeepCC.Fetch_User_Type(CompanyID); ////added company id by sujata 
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlTypeUser.DataSource = ds.Tables[0];
                        ddlTypeUser.DataTextField = "UserType";
                        ddlTypeUser.DataValueField = "User_Type_ID";
                        ddlTypeUser.DataBind();
                        ddlTypeUser.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        ddlApprover.DataSource = ds.Tables[1];
                        ddlApprover.DataTextField = "Approver";
                        ddlApprover.DataValueField = "User_ID";
                        ddlApprover.DataBind();
                        ddlApprover.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        ddlRole.DataSource = ds.Tables[2];
                        ddlRole.DataTextField = "Role_Name";
                        ddlRole.DataValueField = "Role_ID";
                        ddlRole.DataBind();
                        ddlRole.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void bindUser_Master(int User_ID)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = ObjUpkeepCC.UserMaster_CRUD(User_ID, "", "", "", "", "", "", "", "", 0, 0, 0, 0, 0, "", "", 0, 0, 0,0, "", CompanyID, LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtUserCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_Code"]);
                        txtFirstName.Text = Convert.ToString(ds.Tables[0].Rows[0]["F_Name"]);
                        txtlastName.Text = Convert.ToString(ds.Tables[0].Rows[0]["L_Name"]);
                        txtmobile.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_Mobile"]);
                        txtuseremail.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_Email"]);
                        txtUserLogin.Text = Convert.ToString(ds.Tables[0].Rows[0]["Login_Id"]);
                        txtUserDesignation.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_Designation"]);
                        TxtLandline.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_Landine"]);
                        txtPassword.Text = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
                        txtAlterMobile.Text = Convert.ToString(ds.Tables[0].Rows[0]["USer_MobileAlter"]);

                        //Commented by sujata
                        //ddlZone.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Zone_Id"]);
                        //bindLoctionDesc(Convert.ToInt32(ds.Tables[0].Rows[0]["Zone_Id"]));
                        //ddlLocation.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Loc_Id"]);
                        //bindSubLoctionDesc(Convert.ToInt32(ds.Tables[0].Rows[0]["Loc_Id"]));
                        //ddlSublocation.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SubLoc_Id"]);
                        //end Commented by sujata
                        ddlDepartment.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Department_Id"]);
                        ddlTypeUser.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["User_Type_ID"]);

                        int Is_Approver = Convert.ToInt32(ds.Tables[0].Rows[0]["Is_Approver"]);
                        int Is_GlobalApprover = Convert.ToInt32(ds.Tables[0].Rows[0]["Is_GlobalApprover"]);

                        if (Is_Approver == 1)
                        {
                            chk_IsApproval.Checked = true;

                        }
                        else
                        {
                            chk_IsApproval.Checked = false;
                        }

                        if (Is_GlobalApprover == 1)
                        {
                            chk_IsGobalApproval.Checked = true;

                        }
                        else
                        {
                            chk_IsGobalApproval.Checked = false;
                        }

                        ddlApprover.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Approver_ID"]);
                        ddlRole.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Role_ID"]);
                    }
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }


            

        }

        public void DeleteUser_Master( int User_ID_Delete)
        
        {
            try
            {
                DataSet ds = new DataSet();

                ds = ds = ObjUpkeepCC.UserMaster_CRUD(User_ID_Delete, "", "", "", "", "", "", "", "", 0, 0, 0, 0, 0, "", "", 0, 0, 0,0, "", CompanyID, LoggedInUserID, "D");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //Response.Redirect("~/General_Masters/User_Mst.aspx", false);
                        Response.Redirect(Page.ResolveClientUrl("~/General_Masters/User_Mst.aspx"), false);
                    }
                }
                else
                {
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