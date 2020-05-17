using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
  

namespace Upkeep_v3.Ticketing
{
    public partial class Frm_Category : System.Web.UI.Page
    {

        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;   //Added by Sujata
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]); //Added by Sujata
            // frmDepartment.Action = @"General_Masters/Add_Department.aspx";
            frmMain.Action = @"Frm_Category.aspx";

            if (!IsPostBack)
            {
                bindgrid();
                bindDepartment();

                int Category_ID = Convert.ToInt32(Request.QueryString["Category_ID"]);
                if (Category_ID > 0)
                {
                    BindCategory(Category_ID);
                }
                int DelCategory_ID = Convert.ToInt32(Request.QueryString["DelCategory_ID"]);
                if (DelCategory_ID > 0)
                {
                  // DeleteCategory(DelWorkflowID);
                }

            }



        }



        public void BindCategory(int Category_ID)
        {
            try
            {
                 ds = ObjUpkeep.CategoryMaster_CRUD(0, "",0, LoggedInUserID, "R"); 

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["Category_ID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Category_ID"]);
                        txtCategoryDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["Category_Desc"]);
                        ddlDept.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Department_ID"]);
                        mpeCategoryMaster.Show();
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




        protected void btnCategorySave_Click(object sender, EventArgs e)
        {

            //int Category_ID = 0;

            //try
            //{

            //    if (Convert.ToString(Session["Category_ID"]) != "")
            //    {
            //        Category_ID = Convert.ToInt32(Session["Category_ID"]);
            //    }
            //    string Action = "";

            //    if (Category_ID > 0)
            //    {
            //        Action = "U";
            //    }
            //    else
            //    {
            //        Action = "C";
            //    }

            //    ds = ObjUpkeep.CategoryMaster_CRUD(Category_ID, txtCategoryDesc.Text.Trim(), LoggedInUserID, Action);

            //    if (ds.Tables.Count > 0)
            //    {
            //        if (ds.Tables[0].Rows.Count > 0)
            //        {
            //            int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
            //            if (Status == 0)
            //            {

            //            }
            //            else if (Status == 1)
            //            {
            //                Session["Category_ID"] = "";
            //                txtCategoryDesc.Text = "";
            //                mpeCategoryMaster.Hide();

            //                //mpeZone.Hide();
            //                bindgrid();
            //                Response.Redirect(Page.ResolveClientUrl("~/Ticketing/Frm_Category.aspx"), false);
            //            }
            //            else if (Status == 3)
            //            {
            //                lblCategoryErrorMsg.Text = "Category already exists";
            //            }
            //            else if (Status == 2)
            //            {
            //                lblCategoryErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
            //            }
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}



        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {

        }

        public string bindgrid()
        {
            string data = "";
            try
            {
                ds = ObjUpkeep.CategoryMaster_CRUD(0, "",0, LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Category_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Category_ID"]);
                            string Category_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Category_Desc"]);

                            data += "<tr><td>" + Category_ID + "</td><td>" + Category_Desc + "</td><td><a href='Frm_Category.aspx?Category_ID=" + Category_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  <a href='Frm_Category.aspx.aspx?DelCategory_ID=" + Category_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

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

        protected void btnAddcategory_Click1(object sender, EventArgs e)
        {

        }

        protected void btnCloseCategory_Click(object sender, EventArgs e)
        {
            txtCategoryDesc.Text = "";
            lblCategoryErrorMsg.Text = "";
            mpeCategoryMaster.Hide();
            Session["Category_ID"] = "";
            Response.Redirect(Page.ResolveClientUrl("~/Ticketing/Frm_Category.aspx"), false);


        }

        protected void btnCategorySave_Click1(object sender, EventArgs e)
        {
           // bindDepartment();
            int Category_ID = 0;
            int DepartmentID = 0;
            try
            {

                if (Convert.ToString(Session["Category_ID"]) != "")
                {
                    Category_ID = Convert.ToInt32(Session["Category_ID"]);
                }
                string Action = "";

                if (Category_ID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                DepartmentID = Convert.ToInt32(ddlDept.SelectedValue);

                ds = ObjUpkeep.CategoryMaster_CRUD(Category_ID, txtCategoryDesc.Text.Trim(),DepartmentID,LoggedInUserID,Action);

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
                            Session["Category_ID"] = "";
                            txtCategoryDesc.Text = "";
                            mpeCategoryMaster.Hide();

                            //mpeZone.Hide();
                            bindgrid();
                            Response.Redirect(Page.ResolveClientUrl("~/Ticketing/Frm_Category.aspx"), false);
                        }
                        else if (Status == 3)
                        {
                            lblCategoryErrorMsg.Text = "Category already exists";
                        }
                        else if (Status == 2)
                        {
                            lblCategoryErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {

        }





        public void bindDepartment()
        {
            try
            {

                DataSet ds = new DataSet();



                ds = ObjUpkeep.Fetch_Department(CompanyID); //added company id by sujata 

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlDept.DataSource = ds.Tables[0];
                        ddlDept.DataTextField = "Department";
                        ddlDept.DataValueField = "Department_ID";
                        ddlDept.DataBind();
                        ddlDept.Items.Insert(0, new ListItem("--Select--", "0"));
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