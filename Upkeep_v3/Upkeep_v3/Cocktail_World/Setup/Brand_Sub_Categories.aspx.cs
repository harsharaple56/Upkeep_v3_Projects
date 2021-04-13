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
    public partial class Brand_Sub_Categories : System.Web.UI.Page
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
                bindSubCategorygrid();
                bindcategory();

                int SubCategory_ID = Convert.ToInt32(Request.QueryString["SubCategory_ID"]);
                if (SubCategory_ID > 0)
                {
                    BindSubCategory(SubCategory_ID);
                }
                int DelSubCategory_ID = Convert.ToInt32(Request.QueryString["DelSubCategory_ID"]);
                if (DelSubCategory_ID > 0)
                {
                    DeleteSubCategory(SubCategory_ID);
                }

            }
        }


        public void DeleteSubCategory(int SubCategory_ID)

        {
            try
            {
                DataSet ds = new DataSet();

                ds = ds = ObjCocktailWorld.SubCategoryMaster_CRUD(SubCategory_ID, 0, "", LoggedInUserID, CompanyID, "D");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Brand_Sub_Categories.aspx"), false);
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

        public void BindSubCategory(int SubCategory_ID)
        {
            try
            {
                ds = ds = ObjCocktailWorld.SubCategoryMaster_CRUD(SubCategory_ID, 0, "", LoggedInUserID, CompanyID, "R");



                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["SubCategory_ID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["SubCategory_ID"]);
                        txtSubCategoryDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["SubCategory_Desc"]);
                        ddlCategory.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Category_ID"]);
                       
                        mpeSubCategory.Show();
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

        protected void btnAddSubCategory_Click(object sender, EventArgs e)
        {

        }

        protected void btnCloseSubCategory_Click(object sender, EventArgs e)
        {
            Session["SubCategory_ID"] = "";
            txtSubCategoryDesc.Text = "";
          //  ddlCategory.SelectedValue = "";

            mpeSubCategory.Hide();

            //mpeZone.Hide();
            //bindgrid();
            Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Brand_Sub_Categories.aspx"), false);

        }

        protected void btnSubCategorySave_Click(object sender, EventArgs e)
        {


            int SubCategory_ID = 0;
            int Category_ID = 0;


            string SubCategory_Desc = string.Empty;
           

            try
            {

                if (Convert.ToString(Session["SubCategory_ID"]) != "")
                {
                    SubCategory_ID = Convert.ToInt32(Session["SubCategory_ID"]);
                }
                string Action = "";

                if (SubCategory_ID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                Category_ID = Convert.ToInt32(ddlCategory.SelectedValue);
                SubCategory_Desc = txtSubCategoryDesc.Text.Trim();


                ds = ds = ObjCocktailWorld.SubCategoryMaster_CRUD(SubCategory_ID, Category_ID, SubCategory_Desc, LoggedInUserID,CompanyID, Action);




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
                            Session["SubCategory_ID"] = "";
                            txtSubCategoryDesc.Text = "";
                            //ddlCategory.SelectedValue = "";
                            
                            mpeSubCategory.Hide();

                            //mpeZone.Hide();
                            //bindgrid();
                            Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Brand_Sub_Categories.aspx"), false);
                        }
                        else if (Status == 3)
                        {
                            lblSubCategoryErrorMsg.Text = "SubCategory already exists";
                        }
                        else if (Status == 2)
                        {
                            lblSubCategoryErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }




        }





        public void bindcategory()
        {
            try
            {
                int Category_ID = 0;
                DataSet ds = new DataSet();

                ds = ds = ObjCocktailWorld.CategoryMaster_CRUD(24, Category_ID, "", "", LoggedInUserID, "select");


                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlCategory.DataSource = ds.Tables[0];
                        ddlCategory.DataTextField = "Category_Desc";
                        ddlCategory.DataValueField = "Category_ID";
                        ddlCategory.DataBind();
                        ddlCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        public string bindSubCategorygrid()
        {
            int SubCategory_ID = 0;
            string data = "";
            try
            {
                ds = ds = ObjCocktailWorld.SubCategoryMaster_CRUD(SubCategory_ID, 0, "", LoggedInUserID, CompanyID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            SubCategory_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["SubCategory_ID"]);
                            string SubCategory_Desc = Convert.ToString(ds.Tables[0].Rows[i]["SubCategory_Desc"]);
                            string Category_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Category_Desc"]);

                            data += "<tr><td>" + SubCategory_Desc + "</td><td>" + Category_Desc + "</td><td><a href='Brand_Sub_Categories.aspx?SubCategory_ID=" + SubCategory_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  <a href='Brand_Sub_Categories?DelSubCategory_ID=" + SubCategory_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

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