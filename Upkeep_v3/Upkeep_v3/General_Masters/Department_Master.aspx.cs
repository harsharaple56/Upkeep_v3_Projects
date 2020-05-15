using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.General_Masters
{
    public partial class Department_Master : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeepCC = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
           
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            // bindgrid();
            //frmMain.Action = @"Department_Master.aspx";

            if (!IsPostBack)
            {
                //int DepartmentID = Convert.ToInt32(Request.QueryString["Department_ID"]);

                //if(DepartmentID>0)
                //{
                //    fetchDepartment(DepartmentID);
                //}
                
            }

        }

        public string bindgrid()
        {
            string data = "";
            try
            {
                ds = ObjUpkeepCC.DepartmentMaster_CRUD(0, "", CompanyID, LoggedInUserID, "0", "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Department_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Department_ID"]);
                            string Dept_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Dept_Desc"]);

                            data += "<tr><td>" + Department_ID + "</td><td>" + Dept_Desc + "</td><td><a href='Add_Department.aspx?Department_ID=" + Department_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  <a href='Add_Department.aspx?DelDept_ID=" + Department_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

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

        protected void btnDepartmentSave_Click(object sender, EventArgs e)
        {
            //if (btnDepartmentSave.Text == "")
            //{
            //    Response.Write("Select Dep");
            //}
            //else
            //{
            try
            {
                int Department_ID = Convert.ToInt32(Session["Department_ID"]);
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

            }
            catch (Exception ex)
            {
                throw ex;
            }

            //}
        }

        protected void btnAddDept_Click(object sender, EventArgs e)
        {
            // Response.Redirect("~/General_Masters/Add_Department.aspx", false);
            Response.Redirect(Page.ResolveClientUrl("~/General_Masters/Add_Department.aspx"), false);
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
                        
                            int Department_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["Department_ID"]);
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
    }
}