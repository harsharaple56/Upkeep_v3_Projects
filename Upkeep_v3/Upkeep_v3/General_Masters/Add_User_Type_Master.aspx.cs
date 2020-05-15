using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.General_Masters
{
    public partial class Add_User_Type_Master : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeepCC = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            //frmUserType.Action = @"General_Masters/Add_User_Type_Master.aspx";
            if (!IsPostBack)
            {
                int User_Type_ID = Convert.ToInt32(Request.QueryString["User_Type_ID"]);
                int Del_User_Type_ID = Convert.ToInt32(Request.QueryString["DelUser_Type_ID"]);

                if (User_Type_ID > 0)
                {
                    fetchUserType(User_Type_ID);
                }
                if (Del_User_Type_ID > 0)
                {
                    DeleteUserType(Del_User_Type_ID);
                }
            }


        }


        public void fetchUserType(int User_Type_ID)
        {
            try
            {
                ds = ObjUpkeepCC.UserTypeMaster_CRUD(User_Type_ID, "", CompanyID, LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        Session["User_Type_ID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["User_Type_ID"]);
                        txtUserTypeDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["User_Type_Desc"]);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteUserType(int User_Type_ID)
        {
            try
            {
                ds = ObjUpkeepCC.UserTypeMaster_CRUD(User_Type_ID, "", CompanyID, LoggedInUserID, "D");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["User_Type_ID"] = "";
                        Response.Redirect(Page.ResolveClientUrl("~/General_Masters/User_Type_Master.aspx"), false);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnUserTypeSave_Click(object sender, EventArgs e)
        {
            int User_Type_ID = 0;
            try
            {
                if (Convert.ToString(Session["User_Type_ID"]) != "")
                {
                    User_Type_ID = Convert.ToInt32(Session["User_Type_ID"]);
                }
                string Action = "";

                if (User_Type_ID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }


                ds = ObjUpkeepCC.UserTypeMaster_CRUD(User_Type_ID, txtUserTypeDesc.Text, CompanyID, LoggedInUserID, Action);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 0)
                        {

                        }
                        else if (Status == 1)
                        {
                            Session["User_Type_ID"] = "";
                            Response.Redirect(Page.ResolveClientUrl("~/General_Masters/User_Type_Master.aspx"), false);
                        }
                        else if (Status == 3)
                        {
                            lblErrorMsg.Text = "User Type already exists";
                        }
                        else if (Status == 2)
                        {
                            lblErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
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