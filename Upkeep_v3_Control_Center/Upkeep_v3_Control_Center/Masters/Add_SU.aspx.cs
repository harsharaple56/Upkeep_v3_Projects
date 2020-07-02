using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;

namespace Upkeep_v3_Control_Center.Masters
{
    public partial class Add_SU : System.Web.UI.Page
    {
        UpkeepControlCenter_Service.UpkeepControlCenter_Service objUpkeepCC = new UpkeepControlCenter_Service.UpkeepControlCenter_Service();
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            lblErrorMsg.Text = "";
            if (!IsPostBack)
            {
                int ID = Convert.ToInt32(Request.QueryString["ID"]);
                int ID_Delete = Convert.ToInt32(Request.QueryString["DelID"]);
                if (ID > 0)
                {
                    Session["ID"] = Convert.ToString(ID);
                    bindAdmin_Master(ID);
                }
                if (ID_Delete > 0)
                {
                    DeleteAdmin_Master(ID_Delete);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                int ID = Convert.ToInt32(Session["ID"]);
                string Action = "";
                DataSet ds = new DataSet();

                if (ID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                ds = objUpkeepCC.AdminLogin_Master(ID, txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtUserName.Text.Trim(),txtPassword.Text.Trim(), "1", "0", Action);

                Session["ID"] = "";
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
                            Response.Redirect(Page.ResolveClientUrl("~/Masters/SU_Mst.aspx"), false);
                            //Response.Redirect("~/Masters/Group_Mst.aspx", false);
                        }
                        else if (Status == 3)
                        {
                            lblErrorMsg.Text = "User already exists";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void bindAdmin_Master(int ID)
        {

            try
            {
                DataSet ds = new DataSet();

                ds = objUpkeepCC.AdminLogin_Master(ID, "", "","","", "1", "0", "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                      

                        txtFirstName.Text = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);
                        txtLastName.Text = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
                        txtUserName.Text = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                        txtPassword.Text = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);

                        //int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        //if (Status == 0)
                        //{

                        //}
                        //else if (Status == 1)
                        //{
                        //    //Response.Redirect("~/Masters/Group_Mst.aspx", false);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void DeleteAdmin_Master(int ID_Delete)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objUpkeepCC.AdminLogin_Master(ID_Delete, "", "","","", "1", "0", "D");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Redirect(Page.ResolveClientUrl("~/Masters/SU_Mst.aspx"), false);
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