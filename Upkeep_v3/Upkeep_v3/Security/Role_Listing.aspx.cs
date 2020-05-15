using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.Security
{
    public partial class Role_Listing : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }

            if (!IsPostBack)
            {
                int RoleID = Convert.ToInt32(Request.QueryString["RoleID"]);
                if (RoleID > 0)
                {
                    Fetch_Role(RoleID);
                }
                int DelRoleID = Convert.ToInt32(Request.QueryString["DelRoleID"]);
                if (DelRoleID > 0)
                {
                    Delete_Role(DelRoleID);
                }
            }

        }

        public void Delete_Role(int RoleID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = ObjUpkeep.RoleMaster_CRUD(RoleID, "", LoggedInUserID, "D");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            Session["Role_ID"] = "";

                            bindRole();
                            Response.Redirect(Page.ResolveClientUrl("~/Security/Role_Listing.aspx"), false);
                        }
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
        public void Fetch_Role(int RoleID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = ObjUpkeep.RoleMaster_CRUD(RoleID, "", LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["Role_ID"] = RoleID;
                        txtRole.Text = Convert.ToString(ds.Tables[0].Rows[0]["Role_Name"]);
                        mpeRole.Show();
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

        public string bindRole()
        {
            DataSet dsRole = new DataSet();
            string data = "";
            try
            {
                dsRole = ObjUpkeep.RoleMaster_CRUD(0, "", LoggedInUserID, "R");

                if (dsRole.Tables.Count > 0)
                {
                    if (dsRole.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(dsRole.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Role_ID = Convert.ToInt32(dsRole.Tables[0].Rows[i]["Role_ID"]);
                            string Role_Name = Convert.ToString(dsRole.Tables[0].Rows[i]["Role_Name"]);

                            data += "<tr><td>" + Role_Name + "</td><td><a href='Role_Listing.aspx?RoleID=" + Role_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  <a href='Role_Listing.aspx?DelRoleID=" + Role_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

                        }
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
            return data;
        }

        protected void btnAddRole_Click(object sender, EventArgs e)
        {

        }

        protected void btnCloseRole_Click(object sender, EventArgs e)
        {
            txtRole.Text = "";
            lblErrorMsg.Text = "";
            mpeRole.Hide();
            Session["Role_ID"] = "";
            Response.Redirect(Page.ResolveClientUrl("~/Security/Role_Listing.aspx"), false);

        }

        protected void btnSaveRole_Click(object sender, EventArgs e)
        {
            int Role_ID = 0;
            DataSet dsRole = new DataSet();
            try
            {

                if (Convert.ToString(Session["Role_ID"]) != "")
                {
                    Role_ID = Convert.ToInt32(Session["Role_ID"]);
                }
                string Action = "";

                if (Role_ID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                dsRole = ObjUpkeep.RoleMaster_CRUD(Role_ID, txtRole.Text.Trim(), LoggedInUserID, Action);

                if (dsRole.Tables.Count > 0)
                {
                    if (dsRole.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsRole.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            Session["Role_ID"] = "";
                            txtRole.Text = "";
                            mpeRole.Hide();

                            bindRole();
                            Response.Redirect(Page.ResolveClientUrl("~/Security/Role_Listing.aspx"), false);
                        }
                        else if (Status == 3)
                        {
                            lblErrorMsg.Text = "Role already exists";
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