using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.Cocktail_World.Setup
{
    public partial class Brands : System.Web.UI.Page
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
                BindCategory();
                int Brand_ID = Convert.ToInt32(Request.QueryString["Brand_ID"]);
                if (Brand_ID > 0)
                {
                    BindBrand(Brand_ID);
                }
                int DelBrand_ID = Convert.ToInt32(Request.QueryString["DelBrand_ID"]);
                if (DelBrand_ID > 0)
                {
                    DeleteBrand(DelBrand_ID);
                }
            }
        }

        public void BindBrand(int Brand_ID)
        {
            try
            {
                ds = ObjCocktailWorld.BrandMaster_CRUD(CompanyID, Brand_ID, 0, 0, "", "", 0, 0, 0, 0, 0, string.Empty, 0, LoggedInUserID, "R");
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlcategory.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Category_ID"]);
                        BindSubCategory(Convert.ToInt32(ds.Tables[0].Rows[0]["Category_ID"]));
                        ddlSubCategory.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SubCategory_ID"]);
                        txtBrandDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["Brand_Desc"]);
                        txtBrandShortDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["ShortName"]);
                        txtShortname.Text = Convert.ToString(ds.Tables[0].Rows[0]["Strength"]);
                        txtPurchRatepeg.Text = Convert.ToString(ds.Tables[0].Rows[0]["Purchase_Rate_Peg"]);
                        txtSellingRatePeg.Text = Convert.ToString(ds.Tables[0].Rows[0]["Selling_Rate_Peg"]);
                        txtSellingRateBotle.Text = Convert.ToString(ds.Tables[0].Rows[0]["Selling_Rate_Bottle"]);
                        mpeCategoryMaster.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindCategory()
        {
            try
            {

                DataSet ds = new DataSet();
                ds = ObjCocktailWorld.CategoryMaster_CRUD(CompanyID, 0, "", "", LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlcategory.DataSource = ds.Tables[0];
                        ddlcategory.DataTextField = "Category_Desc";
                        ddlcategory.DataValueField = "Category_ID";
                        ddlcategory.DataBind();
                        ddlcategory.Items.Insert(0, new ListItem("--Select--", "0"));

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

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

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Category_Id = Convert.ToInt32(ddlcategory.SelectedValue);
            BindSubCategory(Category_Id);
        }

        protected void btnCloseCategory_Click(object sender, EventArgs e)
        {
            Closecontrol();
        }

        public void Closecontrol()
        {
            txtBrandDesc.Text = "";
            txtBrandShortDesc.Text = "";
            txtShortname.Text = "";
            lblCategoryErrorMsg.Text = "";
            mpeCategoryMaster.Hide();
            Session[""] = "";
            Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Brands.aspx"), false);
        }

        protected void btnCategorySave_Click(object sender, EventArgs e)
        {
            int Brand_ID = 0;
            int CategoryID = 0;
            int SubCategoryID = 0;
            int Disable = 0;
            int PurchaseRatePeg = 0;
            int SellRatePeg = 0;
            int SellRateBottle = 0;
            string brandDesc = string.Empty;
            string shortDesc = string.Empty;
            int Strenght = 0;
            try
            {
                if (Convert.ToInt32(Request.QueryString["Brand_ID"]) > 0)
                {
                    Brand_ID = Convert.ToInt32(Request.QueryString["Brand_ID"]);
                }

                string Action = "";

                if (Brand_ID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                CategoryID = Convert.ToInt32(ddlcategory.SelectedValue);

                if (!string.IsNullOrEmpty(ddlSubCategory.SelectedValue))
                    SubCategoryID = Convert.ToInt32(ddlSubCategory.SelectedValue);
                else
                    SubCategoryID = 0;

                if (!string.IsNullOrEmpty(txtPurchRatepeg.Text.Trim()))
                    PurchaseRatePeg = Convert.ToInt32(txtPurchRatepeg.Text.Trim());
                else
                    PurchaseRatePeg = 0;

                if (!string.IsNullOrEmpty(txtSellingRatePeg.Text.Trim()))
                    SellRatePeg = Convert.ToInt32(txtSellingRatePeg.Text.Trim());
                else
                    SellRatePeg = 0;

                if (!string.IsNullOrEmpty(txtSellingRateBotle.Text.Trim()))
                    SellRateBottle = Convert.ToInt32(txtSellingRateBotle.Text.Trim());
                else
                    SellRateBottle = 0;

                if (!string.IsNullOrEmpty(txtShortname.Text.Trim()))
                    Strenght = Convert.ToInt32(txtShortname.Text.Trim());
                else
                    Strenght = 0;

                brandDesc = txtBrandDesc.Text.Trim();
                shortDesc = txtBrandShortDesc.Text.Trim();

                if (chkBrndDisable.Checked == true)
                {
                    Disable = 1;
                }
                else
                {
                    Disable = 0;
                }

                ds = ObjCocktailWorld.BrandMaster_CRUD(CompanyID, Brand_ID, CategoryID, SubCategoryID, brandDesc, shortDesc, Strenght, PurchaseRatePeg, SellRatePeg, SellRateBottle, Disable, string.Empty, 0, LoggedInUserID, Action);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            txtBrandDesc.Text = "";
                            mpeCategoryMaster.Hide();
                            Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Brands.aspx"), false);
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

        public string bindgrid()
        {
            string data = "";
            try
            {
                ds = ObjCocktailWorld.BrandMaster_CRUD(CompanyID, 0, 0, 0, "", "", 0, 0, 0, 0, 0, string.Empty, 0, LoggedInUserID, "R");
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Brand_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Brand_ID"]);
                            string Category_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Category_Desc"]);
                            string SubCategory_Desc = Convert.ToString(ds.Tables[0].Rows[i]["SubCategory_Desc"]);
                            string Brand_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Brand_Desc"]);
                            string Brand_Short_Desc = Convert.ToString(ds.Tables[0].Rows[i]["ShortName"]);

                            data += "<tr>";
                            data += "<td>" + Brand_Desc + "</td>";
                            data += "<td>" + Brand_Short_Desc + "</td>";
                            data += "<td>" + Category_Desc + "</td>";
                            data += "<td>" + SubCategory_Desc + "</td>";
                            data += "<td>" +
                                "<a href='Brands.aspx?Brand_ID=" + Brand_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  " +
                                "<a href='Brands.aspx?DelBrand_ID=" + Brand_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> " +
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

        public void DeleteBrand(int Brand_ID)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = ObjCocktailWorld.BrandMaster_CRUD(CompanyID, Brand_ID, 0, 0, "", "", 0, 0, 0, 0, 0, string.Empty, 0, LoggedInUserID, "D");
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Brands.aspx"), false);
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