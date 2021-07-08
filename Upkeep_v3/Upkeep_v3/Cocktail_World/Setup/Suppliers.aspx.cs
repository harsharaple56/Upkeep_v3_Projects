using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.Cocktail_World.Setup
{
    public partial class Suppliers : System.Web.UI.Page
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


                int Supplier_ID = Convert.ToInt32(Request.QueryString["Supplier_ID"]);
                if (Supplier_ID > 0)
                {
                    // BindSubCategory(SubCategory_ID);

                    BindSupplier(Supplier_ID);

                }
                int DelSupplier_ID = Convert.ToInt32(Request.QueryString["DelSupplier_ID"]);
                if (DelSupplier_ID > 0)
                {
                    // DeleteBrand(DelBrand_ID);
                }




            }
        }


        public void BindSupplier(int Supplier_ID)
        {
            //  string data = "";
            try
            {
                //   ds = ObjCocktailWorld.BrandMaster_CRUD(CompanyID, Brand_ID, 0, 0, "", 0, 0, 0, 0, 0, LoggedInUserID, "R");



                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        Session["Supplier_ID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Supplier_ID"]);

                        txtSupplierName.Text = Convert.ToString(ds.Tables[0].Rows[0]["Supplier_Name"]);

                        txtCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["Supplier_Code"]); ;
                        txtPincode.Text = Convert.ToString(ds.Tables[0].Rows[0]["Supplier_PINCODE"]); ;
                        txtContct.Text = Convert.ToString(ds.Tables[0].Rows[0]["Supplier_Contact"]); ;
                        txtEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["Supplier_Email"]);





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





        protected void btnAddcategory_Click(object sender, EventArgs e)
        {






        }

        protected void btnCloseCategory_Click(object sender, EventArgs e)
        {
            txtAddress.Text = "";
            txtCode.Text = "";
            txtSupplierName.Text = "";
            txtEmail.Text = "";
            txtPincode.Text = "";
            txtContct.Text = "";

            lblCategoryErrorMsg.Text = "";
            mpeCategoryMaster.Hide();
            Session[""] = "";
            Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Suppliers.aspx"), false);
        }

        protected void btnCategorySave_Click(object sender, EventArgs e)
        {

            int Supplier_ID = 0;
            string supplierName = string.Empty;
            // string Pincode = string.Empty;
            //int Code = 0;
            string Code = string.Empty;
            int Contact = 0;
            int Pincode = 0;
            string Address = string.Empty;
            string Email = string.Empty;


            try
            {

                if (Convert.ToString(Session["Supplier_ID"]) != "")
                {
                    Supplier_ID = Convert.ToInt32(Session["Supplier_ID"]);
                }
                string Action = "";

                if (Supplier_ID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                // DepartmentID = Convert.ToInt32(ddlDept.SelectedValue);

                supplierName = txtSupplierName.Text.Trim();
                // Code = Convert.ToInt32(txtCode.Text.Trim());
                Code = txtCode.Text.Trim();
                Contact = Convert.ToInt32(txtContct.Text.Trim());
                Pincode = Convert.ToInt32(txtPincode.Text.Trim());
                Address = txtAddress.Text.Trim();
                Email = txtEmail.Text.Trim();



                ds = ObjCocktailWorld.SupplierMaster_CRUD(Supplier_ID, supplierName, Code, Pincode, Address, Contact, "", Email, LoggedInUserID, CompanyID, Action);

                //  ds = ObjCocktailWorld.BrandMaster_CRUD(CompanyID,BrandID,CategoryID,0,txtBrandDesc.Text.Trim(),txtShortname.Text.Trim(),Convert.ToInt32(txtPurchRatepeg),Convert.ToInt32(txtSellingRatePeg),Convert.ToInt32(txtSellingRateBotle),Disable,LoggedInUserID,Action);

                //  ds = ObjCocktailWorld.BrandMaster_CRUD(CompanyID, Brand_ID, CategoryID, SubCategoryID, brandDesc, Strenght, PurchaseRatePeg, SellRatePeg, SellRateBottle, Disable, LoggedInUserID, Action);





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
                            Session["Supplier_ID"] = "";
                            //txt.Text = "";
                            txtSupplierName.Text = "";
                            txtAddress.Text = "";
                            txtCode.Text = "";
                            txtContct.Text = "";
                            txtEmail.Text = "";
                            txtPincode.Text = "";

                            mpeCategoryMaster.Hide();

                            //mpeZone.Hide();
                            //bindgrid();
                            Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Suppliers.aspx"), false);
                        }
                        else if (Status == 3)
                        {
                            lblCategoryErrorMsg.Text = "Supplier already exists";
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
                ds = ObjCocktailWorld.SupplierMaster_CRUD(0, "", "", 0, "", 0, "", "", LoggedInUserID, CompanyID, "R");


                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Supplier_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Supplier_ID"]);
                            string SupplierName = Convert.ToString(ds.Tables[0].Rows[i]["Supplier_Name"]);
                            string SupplierCode = Convert.ToString(ds.Tables[0].Rows[i]["Supplier_Code"]);
                            int Contact = Convert.ToInt32(ds.Tables[0].Rows[i]["Supplier_Contact"]);
                            string City = Convert.ToString(ds.Tables[0].Rows[i]["Supplier_City"]);
                            int Pincode = Convert.ToInt32(ds.Tables[0].Rows[i]["Supplier_PINCODE"]);
                           // string Address = Convert.ToString(ds.Tables[0].Rows[i]["Supplier_Address"]);
                            string Email = Convert.ToString(ds.Tables[0].Rows[i]["Supplier_Email"]);



                            data += "<tr><td>" + SupplierName + "</td><td>" + SupplierCode + "</td><td>" + Contact + "</td><td>" + City + "</td><td>" + Pincode + "</td><td>" + Email + "</td> <td><a href='Suppliers.aspx?Supplier_ID=" + Supplier_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  <a href='Suppliers.aspx?DelSupplier_ID=" + Supplier_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

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

        protected void btnCloseHeader_ServerClick(object sender, EventArgs e)
        {

        }
    }
}