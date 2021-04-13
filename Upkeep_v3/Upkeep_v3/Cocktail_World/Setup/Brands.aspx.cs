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
                // BindSubCategory(SubCategory_ID);

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
          //  string data = "";
            try
            {
                ds = ObjCocktailWorld.BrandMaster_CRUD(CompanyID, Brand_ID, 0, 0, "", 0, 0, 0, 0, 0, LoggedInUserID, "R");

              
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            Session["Brand_ID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Brand_ID"]);
                        ddlcategory.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Category_ID"]);
                        ddlSubCategory.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SubCategory_ID"]);
                        txtBrandDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["Brand_Desc"]);
                        txtShortname.Text = Convert.ToString(ds.Tables[0].Rows[0]["Strength"]);

                        txtPurchRatepeg.Text = Convert.ToString(ds.Tables[0].Rows[0]["Purchase_Rate_Peg"]);
                        txtSellingRatePeg.Text = Convert.ToString(ds.Tables[0].Rows[0]["Selling_Rate_Peg"]);

                        txtSellingRateBotle.Text = Convert.ToString(ds.Tables[0].Rows[0]["Selling_Rate_Bottle"]);





                        mpeCategoryMaster.Show();

                        
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
          // return data;

        }

  


        public void BindCategory()
        {
            try
            {

                DataSet ds = new DataSet();
                ds = ObjCocktailWorld.CategoryMaster_CRUD(24, 0, "", "", LoggedInUserID, "select");

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

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int Category_Id = Convert.ToInt32(ddlcategory.SelectedValue);
                DataSet ds = new DataSet();
                // ds = ObjCocktailWorld.SubCategoryMaster_CRUD(24, 0, "", "", LoggedInUserID, "select");

                ds = ds = ObjCocktailWorld.SubCategoryMaster_CRUD(0, Category_Id, "", LoggedInUserID, CompanyID, "R");
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
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCloseHeader_ServerClick(object sender, EventArgs e)
        {

        }

        protected void btnAddcategory_Click(object sender, EventArgs e)
        {

        }

        protected void btnCloseCategory_Click(object sender, EventArgs e)
        {
            txtBrandDesc.Text = "";
            txtShortname.Text = "";
            lblCategoryErrorMsg.Text = "";
            mpeCategoryMaster.Hide();
            Session[""] = "";
            Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Brands.aspx"), false);
        }

        protected void btnCategorySave_Click(object sender, EventArgs e)
        {


            int BrandID = 0;
            int CategoryID = 0;
            int SubCategoryID = 0;
            int Disable = 0;
            int PurchaseRatePeg = 0;
            int SellRatePeg = 0;
            int SellRateBottle = 0;
            string brandDesc = string.Empty;
            // string Strenght = string.Empty;
            int Strenght = 0;
            try
            {

                if (Convert.ToString(Session["BrandID"]) != "")
                {
                    BrandID = Convert.ToInt32(Session["BrandID"]);
                }
                string Action = "";

                if (BrandID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                // DepartmentID = Convert.ToInt32(ddlDept.SelectedValue);
                CategoryID = Convert.ToInt32(ddlcategory.SelectedValue);
                PurchaseRatePeg = Convert.ToInt32(txtPurchRatepeg.Text.Trim());
                SellRatePeg = Convert.ToInt32(txtSellingRatePeg.Text.Trim());
                SellRateBottle = Convert.ToInt32(txtSellingRateBotle.Text.Trim());
                brandDesc = txtBrandDesc.Text.Trim();
                Strenght = Convert.ToInt32(txtShortname.Text.Trim());

                
                if(chkBrndDisable.Checked == true)
                {
                    Disable = 1;
                }
                else
                {
                    Disable = 0;
                }


              //  ds = ObjCocktailWorld.BrandMaster_CRUD(CompanyID,BrandID,CategoryID,0,txtBrandDesc.Text.Trim(),txtShortname.Text.Trim(),Convert.ToInt32(txtPurchRatepeg),Convert.ToInt32(txtSellingRatePeg),Convert.ToInt32(txtSellingRateBotle),Disable,LoggedInUserID,Action);

               ds = ObjCocktailWorld.BrandMaster_CRUD(CompanyID, BrandID, CategoryID, 1, brandDesc, Strenght, PurchaseRatePeg ,SellRatePeg,SellRateBottle, Disable, LoggedInUserID, Action);


                //ds = ObjUpkeep.CategoryMaster_CRUD(CompanyID, Category_ID, txtCategoryDesc.Text.Trim(), DepartmentID, LoggedInUserID, Action);

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
                            Session["BrandID"] = "";
                            txtBrandDesc.Text = "";
                            mpeCategoryMaster.Hide();

                            //mpeZone.Hide();
                            //bindgrid();
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

        protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        public string bindgrid()
        {
            string data = "";
            try
            {
                ds = ObjCocktailWorld.BrandMaster_CRUD(CompanyID, 0, 0, 0,"", 0,0, 0, 0, 0, LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Brand_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Brand_ID"]);
                            string Category_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Category_Desc"]);
                            string Brand_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Brand_Desc"]);



                            data += "<tr><td>" + Brand_Desc + "</td><td>" + Category_Desc + "</td><td><a href='Brands.aspx?Brand_ID=" + Brand_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  <a href='Brand.aspx.aspx?DelBrand_ID=" + Brand_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

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


        public void DeleteBrand(int Brand_ID)

        {
            try
            {
                DataSet ds = new DataSet();

                ds = ObjCocktailWorld.BrandMaster_CRUD(CompanyID, Brand_ID, 0, 0, "", 0, 0, 0, 0, 0, LoggedInUserID, "D");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Brands.aspx"), false);
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