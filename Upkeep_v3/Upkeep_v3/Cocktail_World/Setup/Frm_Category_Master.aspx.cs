using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Xml;
using System.Collections;

namespace Upkeep_v3.Cocktail_World.Setup
{
    public partial class Frm_Category_Master : System.Web.UI.Page
    {

        CocktailWorld_Service.CocktailWorld_Service ObjCocktailWorld = new CocktailWorld_Service.CocktailWorld_Service();


        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            if (!IsPostBack)
            {
                bindgrid();

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
                ds = ds = ObjCocktailWorld.CategoryMaster_CRUD(24, Category_ID, "", "", LoggedInUserID, "select");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["Category_ID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Category_ID"]);
                       
                        txtcategoryDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["Category_Desc"]);
                        txtCatAlias.Text = Convert.ToString(ds.Tables[0].Rows[0]["Category_Alias"]);
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

        protected void btnAddcategory_Click(object sender, EventArgs e)
        {



        }

        protected void btnCategorySave_Click(object sender, EventArgs e)
        {
           
            int Category_ID = 0;
            
            string Category_Desc = string.Empty;
            string Category_Alias = string.Empty;
           
            try
            {

                if (Convert.ToString(Session["Category_ID"]) != "")
                {
                    Category_ID = Convert.ToInt32(Session["Category_ID"]);
                }
                string Action = "";

                if (Category_ID > 0)
                {
                    Action = "Update";
                }
                else
                {
                    Action = "insert";
                }

                // DepartmentID = Convert.ToInt32(ddlDept.SelectedValue);
                Category_Desc = txtcategoryDesc.Text.Trim();

                Category_Alias = txtCatAlias.Text.Trim();
               


               



                ds = ds = ObjCocktailWorld.CategoryMaster_CRUD(24, Category_ID, Category_Desc, Category_Alias, LoggedInUserID, Action);

               
             

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
                            txtcategoryDesc.Text = "";
                            txtCatAlias.Text = "";
                            mpeCategoryMaster.Hide();

                            //mpeZone.Hide();
                            //bindgrid();
                            Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Frm_Category_Master.aspx"), false);
                        }
                        else if (Status == 3)
                        {
                            lblCategoryErrorMsg.Text = "Brand already exists";
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

        protected void btnCloseCategory_Click(object sender, EventArgs e)
        {
            txtcategoryDesc.Text = "";
            txtCatAlias.Text = "";
            lblCategoryErrorMsg.Text = "";
            mpeCategoryMaster.Hide();
            Session["Category_ID"] = "";
            Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Frm_Category_Master.aspx"), false);
        }

        protected void btnCloseHeader_ServerClick(object sender, EventArgs e)
        {

        }








        public string bindgrid()
        {
            string data = "";
            try
            {
                ds = ds = ObjCocktailWorld.CategoryMaster_CRUD(24, 0, "", "", LoggedInUserID, "select");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Category_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Category_ID"]);
                            string Category_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Category_Desc"]);
                            // string Brand_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Brand_Desc"]);
                            string Category_Alias = Convert.ToString(ds.Tables[0].Rows[i]["Category_Alias"]);



                            data += "<tr><td>" + Category_Desc + "</td><td>" + Category_Alias + "</td><td><a href='Frm_Category_Master.aspx?Category_ID=" + Category_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  <a href='Frm_Category_Master.aspx?DelCategory_ID=" + Category_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

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
    }
}