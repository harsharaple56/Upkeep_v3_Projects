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
    public partial class Brand_Categories : System.Web.UI.Page
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
                int Category_ID = Convert.ToInt32(Request.QueryString["Category_ID"]);
                if (Category_ID > 0)
                {
                    BindCategoryData(Category_ID);
                }
                int DelCategory_ID = Convert.ToInt32(Request.QueryString["DelCategory_ID"]);
                if (DelCategory_ID > 0)
                {
                    DeleteCategory(DelCategory_ID);
                }
            }
        }

        public void BindCategoryData(int Category_ID)
        {
            try
            {
                ds = ObjCocktailWorld.CategoryMaster_CRUD(CompanyID, Category_ID, string.Empty, string.Empty, LoggedInUserID, "R");
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtCategoryName.Text = Convert.ToString(ds.Tables[0].Rows[0]["Category_Desc"]);
                        txtCategoryAlias.Text = Convert.ToString(ds.Tables[0].Rows[0]["Category_Alias"]);
                        mpeCategoryMaster.Show();
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
            Closecontrol();
        }

        public void Closecontrol()
        {
            txtCategoryAlias.Text = "";
            txtCategoryName.Text = "";
            lblCategoryErrorMsg.Text = "";
            mpeCategoryMaster.Hide();
            Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Brand_Categories.aspx"), false);
        }

        protected void btnCategorySave_Click(object sender, EventArgs e)
        {
            int CategoryID = 0;
            string category_desc = string.Empty;
            string category_alias = string.Empty;
            string Action = string.Empty;

            try
            {
                if (Convert.ToInt32(Request.QueryString["Category_ID"]) > 0)
                {
                    CategoryID = Convert.ToInt32(Request.QueryString["Category_ID"]);
                }

                if (CategoryID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                category_desc = txtCategoryName.Text.Trim();
                category_alias = txtCategoryAlias.Text.Trim();

                ds = ObjCocktailWorld.CategoryMaster_CRUD(CompanyID, CategoryID, category_desc, category_alias, LoggedInUserID, Action);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            category_desc = "";
                            category_alias = "";
                            mpeCategoryMaster.Hide();
                            Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Brand_Categories.aspx"), false);
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

        public string BindCategory()
        {
            string data = "";
            try
            {
                ds = ObjCocktailWorld.CategoryMaster_CRUD(CompanyID, 0, "", "", LoggedInUserID, "R");
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            string Category_ID = Convert.ToString(ds.Tables[0].Rows[i]["Category_ID"]);
                            string Category_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Category_Desc"]);
                            string Category_Alias = Convert.ToString(ds.Tables[0].Rows[i]["Category_Alias"]);

                            data += "<tr>";
                            data += "<td>" + Category_Desc + "</td>";
                            data += "<td>" + Category_Alias + "</td>";
                            data += "<td>" +
                                "<a href='Brand_Categories.aspx?Category_ID=" + Category_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  " +
                                "<a href='Brand_Categories.aspx?DelCategory_ID=" + Category_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> " +
                                "</td>";
                            data += "</tr>";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

        public void DeleteCategory(int Category_ID)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = ObjCocktailWorld.CategoryMaster_CRUD(CompanyID,Category_ID,string.Empty,string.Empty, LoggedInUserID, "D");
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Brand_Categories.aspx"), false);
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