using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_Gatepass_Workpermit.Security
{
    public partial class Assign_RoleMst : System.Web.UI.Page
    {
        Upkeep_GP_WP_Services.Upkeep_GP_WP_Services ObjUpkeep = new Upkeep_GP_WP_Services.Upkeep_GP_WP_Services();
        string LoggedInUserID = string.Empty;
        int AssignedRoleID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            AssignedRoleID = Convert.ToInt32(Request.QueryString["RoleID"]);
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            if (!IsPostBack)
            {

                Bind_Role();
                Bind_Employee();
            }
        }

        public void Bind_Role()
        {
            DataSet dsRole = new DataSet();
            try
            {
                dsRole = ObjUpkeep.RoleMaster_CRUD(0, "", LoggedInUserID, "R");

                if (dsRole.Tables.Count > 0)
                {
                    if (dsRole.Tables[0].Rows.Count > 0)
                    {
                        ddlRole.DataSource = dsRole.Tables[0];
                        ddlRole.DataTextField = "Role_Name";
                        ddlRole.DataValueField = "Role_ID";
                        ddlRole.DataBind();
                        ddlRole.Items.Insert(0, new ListItem("--Select--", "0"));
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

        public void Bind_Employee()
        {
            DataSet dsEmployee = new DataSet();
            int RoleID = 0;
            try
            {
                if (AssignedRoleID > 0)
                {
                    ddlRole.SelectedValue =Convert.ToString(AssignedRoleID);
                }
                if (Convert.ToInt32(ddlRole.SelectedValue) > 0)
                {
                    RoleID = Convert.ToInt32(ddlRole.SelectedValue);
                }
                else
                {
                    RoleID = 0;
                }
                dsEmployee = ObjUpkeep.Fetch_Assigned_Role(RoleID);

                if (dsEmployee.Tables.Count > 0)
                {
                    if (dsEmployee.Tables[0].Rows.Count > 0)
                    {
                        gvEmployee.DataSource = dsEmployee;
                        gvEmployee.DataBind();
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

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind_Employee();
        }

        protected void gvEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //check if the row is the header row
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //add the thead and tbody section programatically
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string SelectedEmployees = string.Empty;
            var rows = gvEmployee.Rows;
            int count = gvEmployee.Rows.Count;
            int RoleID = 0;
            DataSet dsEmployee = new DataSet();
            try
            {
                for (int i = 0; i < count; i++)
                {
                    bool isChecked = ((CheckBox)rows[i].FindControl("chkEmployee")).Checked;
                    if (isChecked)
                    {
                        //string EmployeeID = gvEmployee.Rows[i].Cells[1].Text;
                        string EmployeeID = ((HiddenField)rows[i].FindControl("hdnEmployeeID")).Value;
                        SelectedEmployees = SelectedEmployees + EmployeeID + ",";
                    }
                }

                SelectedEmployees = SelectedEmployees.TrimEnd(',');

                RoleID = Convert.ToInt32(ddlRole.SelectedValue);
                
                dsEmployee = ObjUpkeep.Insert_Assigned_Role(RoleID, SelectedEmployees, LoggedInUserID);

                if (dsEmployee.Tables.Count > 0)
                {
                    if (dsEmployee.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsEmployee.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            Response.Redirect(Page.ResolveClientUrl("~/Security/Assign_RoleList.aspx"), false);
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
            Response.Redirect(Page.ResolveClientUrl("~/Security/Assign_RoleList.aspx"), false);
        }
    }
}