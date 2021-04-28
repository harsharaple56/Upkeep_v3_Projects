using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;


namespace eFacilito_CompanyGroup_Portal
{
    public partial class Login : System.Web.UI.Page
    {
        eFacilito_CompanyGroup_Portal_Service.eFacilito_CompanyGroup_Portal_Service objUpkeepCC = new eFacilito_CompanyGroup_Portal_Service.eFacilito_CompanyGroup_Portal_Service();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string Username = txtUserName.Text;
            string Password = txtPassword.Text;

            DataSet ds = new DataSet();
            ds = objUpkeepCC.LoginUser(Username, Password);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["LoggedInUserID"] = Convert.ToString(ds.Tables[0].Rows[0]["Grp_User_ID"]);
                    Session["Designation"] = Convert.ToString(ds.Tables[0].Rows[0]["Designation"]);
                    Session["Full_Name"] = Convert.ToString(ds.Tables[0].Rows[0]["Full_Name"]);
                    Session["Group_ID"] = Convert.ToString(ds.Tables[0].Rows[0]["Group_ID"]);
                    Session["Username"] = Convert.ToString(ds.Tables[0].Rows[0]["Username"]);

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
                    //invalid login
                    lblError.Text = "Invalid credentials";
                }
            }
            else
            {
                lblError.Text = "Invalid credential";
            }
        }
    }
}