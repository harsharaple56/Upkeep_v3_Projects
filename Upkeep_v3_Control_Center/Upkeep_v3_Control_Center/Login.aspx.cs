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


namespace Upkeep_v3_Control_Center
{

    public partial class Login : System.Web.UI.Page
    {
        UpkeepControlCenter_Service.UpkeepControlCenter_Service objUpkeepCC = new UpkeepControlCenter_Service.UpkeepControlCenter_Service();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = objUpkeepCC.LoginUser(txtUserName.Text.Trim(), txtPassword.Text);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["LoggedInUserID"] = Convert.ToString(ds.Tables[0].Rows[0]["ID"]);
                    Session["UserName"] = Convert.ToString(txtUserName.Text.Trim());
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
                    lblError.Text = "Invalid credential";
                }
            }
            else
            {
                lblError.Text = "Invalid credential";
                //invalid login
            }
        }

    }
}