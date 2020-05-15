using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace Upkeep_v3.General_Masters
{
    public partial class Add_Department : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeepCC = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        int CompanyID = 0;
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            // frmDepartment.Action = @"General_Masters/Add_Department.aspx";
            //frmDepartment.Action = @"Add_Department.aspx";

            if (!IsPostBack)
            {
                int DepartmentID = Convert.ToInt32(Request.QueryString["Department_ID"]);
                int Del_DepartmentID = Convert.ToInt32(Request.QueryString["DelDept_ID"]);

                if (DepartmentID > 0)
                {
                    fetchDepartment(DepartmentID);
                }
                if(Del_DepartmentID>0)
                {
                    DeleteDepartment(Del_DepartmentID);
                }
            }

        }

        protected void btnDepartmentSave_Click(object sender, EventArgs e)
        {
            int Department_ID = 0;
            try
            {
                if (Convert.ToString(Session["Department_ID"]) != "")
                {
                    Department_ID = Convert.ToInt32(Session["Department_ID"]);
                }
                string Action = "";

                if (Department_ID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                ds = ObjUpkeepCC.DepartmentMaster_CRUD(Department_ID, txtDeptDesc.Text.Trim(), CompanyID, LoggedInUserID, "0", Action);

                
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
                            Session["Department_ID"] = "";
                            Response.Redirect("~/General_Masters/Department_Master.aspx", false);
                        }
                        else if (Status == 3)
                        {
                            lblErrorMsg.Text = "Department already exists";
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

        public void fetchDepartment(int DepartmentID)
        {
            try
            {
                ds = ObjUpkeepCC.DepartmentMaster_CRUD(DepartmentID, "", CompanyID, LoggedInUserID, "0", "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        Session["Department_ID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Department_ID"]);
                        txtDeptDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["Dept_Desc"]);
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

        public void DeleteDepartment(int DepartmentID)
        {
            try
            {
                ds = ObjUpkeepCC.DepartmentMaster_CRUD(DepartmentID, "", CompanyID, LoggedInUserID, "0", "D");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["Department_ID"] = "";
                        //Response.Redirect("~/General_Masters/Department_Master.aspx", false);
                        Response.Redirect(Page.ResolveClientUrl("~/General_Masters/Department_Master.aspx"), false);
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

    }
}