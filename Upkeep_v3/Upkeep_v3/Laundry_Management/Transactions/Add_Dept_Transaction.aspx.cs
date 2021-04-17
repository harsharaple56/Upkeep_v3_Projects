using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

namespace Upkeep_v3.Laundry_Management.Transactions
{
    public partial class Add_Dept_Transaction : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            if (!IsPostBack)
            {
                bindDepartment();
            }
        }

        public void bindDepartment()
        {
            try
            {
                CompanyID = Convert.ToInt32(Session["CompanyID"]);
                DataSet ds = new DataSet();

                ds = ObjUpkeep.Fetch_Department(CompanyID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlDepartment.DataSource = ds.Tables[0];
                        ddlDepartment.DataTextField = "Department";
                        ddlDepartment.DataValueField = "Department_ID";
                        ddlDepartment.DataBind();
                        ddlDepartment.Items.Insert(0, new ListItem("--Select Department--", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvItemDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            gvItemDetails.DataSource = null;
            gvItemDetails.DataBind();
        }

        protected void btnAddcategory_Click(object sender, EventArgs e)
        {

        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DepartmentID = 0;
            try
            {
                DepartmentID = Convert.ToInt32(ddlDepartment.SelectedValue);
                bindItemList(DepartmentID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void bindItemList(int DepartmentID)
        {
            try
            {
                DataSet dsItems = new DataSet();

                dsItems = ObjUpkeep.Fetch_LMS_ItemList(DepartmentID,CompanyID);

                if (dsItems.Tables.Count > 0)
                {
                    if (dsItems.Tables[0].Rows.Count > 0)
                    {
                        ddlItems.DataSource = dsItems.Tables[0];
                        ddlItems.DataTextField = "Item_Desc";
                        ddlItems.DataValueField = "Item_ID";
                        ddlItems.DataBind();
                        ddlItems.Items.Insert(0, new ListItem("--Select Item--", "0"));
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