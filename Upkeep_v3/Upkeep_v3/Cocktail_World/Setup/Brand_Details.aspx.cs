using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Cocktail_World.Setup
{
    public partial class Brand_Details : System.Web.UI.Page
    {
        CocktailWorld_Service.CocktailWorld_Service ObjCocktailWorld = new CocktailWorld_Service.CocktailWorld_Service();
        DataSet Ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            if (!IsPostBack)
            {
                Bind_License();
                Bind_Category();
            }
        }

        public void Bind_License()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = ObjCocktailWorld.License_CRUD(0, "", "", LoggedInUserID, CompanyID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlLicense.DataSource = ds.Tables[0];
                        ddlLicense.DataTextField = "License_Name";
                        ddlLicense.DataValueField = "License_ID";
                        ddlLicense.DataBind();
                        ddlLicense.Items.Insert(0, new ListItem("--Select License--", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Bind_Category()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = ObjCocktailWorld.CategoryMaster_CRUD(CompanyID, 0, "", "", LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlCategory.DataSource = ds.Tables[0];
                        ddlCategory.DataTextField = "Category_Desc";
                        ddlCategory.DataValueField = "Category_ID";
                        ddlCategory.DataBind();
                        ddlCategory.Items.Insert(0, new ListItem("--Select Category--", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            FetchCategorySizeLinkUp();
            BindSubCategory(Convert.ToInt32(ddlCategory.SelectedValue));
        }

        public void BindSubCategory(int Category_Id)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = ObjCocktailWorld.SubCategoryMaster_CRUD(0, Category_Id, "", LoggedInUserID, CompanyID, "R");
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlSubCategory.DataSource = ds.Tables[0];
                        ddlSubCategory.DataTextField = "SubCategory_Desc";
                        ddlSubCategory.DataValueField = "SubCategory_ID";
                        ddlSubCategory.DataBind();
                        ddlSubCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    else
                    {
                        ddlSubCategory.Items.Clear();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FetchCategorySizeLinkUp()
        {
            try
            {
                int Category_ID = 0;
                int License_ID = 0;
                DataSet ds = new DataSet();
                Category_ID = Convert.ToInt32(ddlCategory.SelectedValue);
                License_ID = Convert.ToInt32(ddlLicense.SelectedValue);
                if (License_ID != 0 && Category_ID != 0)
                {
                    ds = ObjCocktailWorld.Fetch_CategorySizeLinkup(0, Category_ID, License_ID, CompanyID,1);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ddlCategory.SelectedIndex > 0)
                        {
                            grdCatagLinkUp.DataSource = ds.Tables[0];
                            grdCatagLinkUp.DataBind();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlLicense_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Action = "C";
            string brandDesc = string.Empty;
            string shortDesc = string.Empty;
            int strength = 0;
            int Brand_ID = 0;
            int CategoryID = 0;
            int SubCategoryID = 0;
            int License_ID = 0;

            brandDesc = txtbrand.Text.Trim();
            shortDesc = txtShort.Text.Trim();
            CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
            License_ID = Convert.ToInt32(ddlLicense.SelectedValue);

            if (!string.IsNullOrEmpty(ddlSubCategory.SelectedValue))
                SubCategoryID = Convert.ToInt32(ddlSubCategory.SelectedValue);
            else
                SubCategoryID = 0;

            strength = !string.IsNullOrEmpty(txtStrength.Text) ? Convert.ToInt32(txtStrength.Text) : 0;

            DataSet ds = new DataSet();
            ds = ObjCocktailWorld.BrandMaster_CRUD(CompanyID, License_ID, Brand_ID, CategoryID, SubCategoryID, brandDesc, shortDesc, strength, string.Empty, 0, LoggedInUserID, Action);

            var rows = grdCatagLinkUp.Rows;
            int count = grdCatagLinkUp.Rows.Count;

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    int brand_id = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
                    string size_id = string.Empty;
                    foreach (GridViewRow gr in rows)
                    {
                        size_id = gr.Cells[0].Text;
                    }
                    string box = ((TextBox)rows[i].FindControl("txtbox")).Text;
                    string pegpur = ((TextBox)rows[i].FindControl("txtpegpur")).Text;

                    DataSet ds1 = new DataSet();
                    ds1 = ObjCocktailWorld.BrandDetailsMaster_CRUD(brand_id,Convert.ToInt32(size_id), Convert.ToInt32(box), Convert.ToDecimal(pegpur), Action);
                }

                Page.ClientScript.RegisterHiddenField("Redirect", "Redirect");
            }
        }
    }
}