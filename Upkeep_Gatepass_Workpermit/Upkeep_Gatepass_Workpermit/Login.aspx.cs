using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_Gatepass_Workpermit
{
    public partial class Login : System.Web.UI.Page
    {
        Upkeep_GP_WP_Services.Upkeep_GP_WP_Services ObjUpkeep = new Upkeep_GP_WP_Services.Upkeep_GP_WP_Services();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
        }

        public void btnLogin_Click(object sender, EventArgs e)
        {
            string UserType = string.Empty;
            try
            {
                DataSet dsLogin = new DataSet();

                if (rdbEmployee.Checked)
                {
                    UserType = "E";
                }
                else
                {
                    UserType = "R";
                }

                dsLogin = ObjUpkeep.User_Login(txtUsername.Text.Trim(), txtPassword.Text.Trim(), UserType);

                int AssignedRoleCount = 0;
                if (dsLogin.Tables.Count > 0)
                {
                    if (dsLogin.Tables[0].Rows.Count > 0)
                    {
                        AssignedRoleCount= Convert.ToInt32(dsLogin.Tables[0].Rows[0]["RoleMenuCount"]);
                        if (AssignedRoleCount > 0)
                        {
                            Session["UserType"] = Convert.ToString(UserType);
                            if (UserType == "E")
                            {
                                Session["EmpCD"] = Convert.ToString(dsLogin.Tables[0].Rows[0]["empcd"]);
                                Session["RollCD"] = Convert.ToString(dsLogin.Tables[0].Rows[0]["rollcd"]);
                                Session["LoggedInUserID"] = Convert.ToString(dsLogin.Tables[0].Rows[0]["EmployeeID"]);
                            }
                            else
                            {
                                Session["LoggedInUserID"] = Convert.ToString(txtUsername.Text.Trim());
                            }

                            Session["UserName"] = Convert.ToString(txtUsername.Text.Trim());
                            Session["LoggedInProfileName"] = Convert.ToString(dsLogin.Tables[0].Rows[0]["Name"]);

                            if (dsLogin.Tables[0].Rows.Count > 0)
                            {
                                Response.Redirect("~/Dashboard2.aspx", false);
                            }
                            else
                            {
                                //invalid login
                                lblError.Text = "Invalid credential";
                            }
                        }
                        else
                        {
                            lblError.Text = "Dear "+ txtUsername.Text.Trim() + " , no role has been assigned to you. Hence you cannot login. Please contact your Property Administrator for further assistance."; //No role assigned
                        }
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