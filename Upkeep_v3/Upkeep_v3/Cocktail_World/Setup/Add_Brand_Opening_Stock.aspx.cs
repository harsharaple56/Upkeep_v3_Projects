using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Cocktail_World.Setup
{
    public partial class Add_Brand_Opening_Stock : System.Web.UI.Page
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
                Fetch_Category_Brand();
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedIndex == 0)
            {
                ddlBrand.Items.Clear();
                grdCatagLinkUp.Visible = false;
            }
            Fetch_Category_Brand();
        }

        protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            FetchBrandSizeLinkUp();
        }


        public void Fetch_Category_Brand()
        {
            grdCatagLinkUp.Visible = false;
            DataSet dsCategory = new DataSet();
            int CategoryID = 0;

            if (!string.IsNullOrEmpty(ddlCategory.SelectedValue))
                CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
            else
                CategoryID = 0;

            try
            {

                dsCategory = ObjCocktailWorld.Fetch_Category_Brand(CompanyID, CategoryID);

                if (CategoryID == 0)
                {
                    ddlCategory.DataSource = dsCategory.Tables[0];
                    ddlCategory.DataTextField = "Category_Desc";
                    ddlCategory.DataValueField = "Category_ID";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                else if (CategoryID > 0)
                {
                    ddlBrand.DataSource = dsCategory.Tables[0];
                    ddlBrand.DataTextField = "Brand_Desc";
                    ddlBrand.DataValueField = "Brand_ID";
                    ddlBrand.DataBind();
                    ddlBrand.Items.Insert(0, new ListItem("--Select--", "0"));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FetchBrandSizeLinkUp()
        {
            try
            {
                grdCatagLinkUp.Visible = true;
                int Category_ID;
                int Brand_ID;
                DataSet ds = new DataSet();
                Category_ID = Convert.ToInt32(ddlCategory.SelectedValue);
                Brand_ID = Convert.ToInt32(ddlBrand.SelectedValue);

                ds = ObjCocktailWorld.FetchBrandSizeLinkup(Category_ID, Brand_ID);

                for (int i = ds.Tables[0].Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    if (Convert.ToInt32(dr["Selected"]) == 0)
                        dr.Delete();
                }
                ds.AcceptChanges();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdCatagLinkUp.DataSource = ds.Tables[0];
                    grdCatagLinkUp.DataBind();
                }
                else
                {
                    grdCatagLinkUp.DataSource = null;
                    grdCatagLinkUp.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdCatagLinkUp_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCatagLinkUp.PageIndex = e.NewPageIndex;
            FetchBrandSizeLinkUp();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            string CategoryDetails = string.Empty;
            var rows = grdCatagLinkUp.Rows;
            int count = grdCatagLinkUp.Rows.Count;

            int Cat_Size_ID = 0; // Cat_Size_ID
            int BrandID = 0;
            int Opening_ID = 0;
            string Operation = string.Empty;
            try
            {
                for (int i = 0; i < count; i++)
                {
                    StringBuilder strXmlCategory = new StringBuilder();
                    bool isChecked = ((CheckBox)rows[i].FindControl("chkSelct")).Checked;
                    string hdnSize_ID = ((HiddenField)rows[i].FindControl("hdnSize_ID")).Value;
                    string txtspegqty = ((TextBox)rows[i].FindControl("txtspegqty")).Text;
                    string txtbottleqty = ((TextBox)rows[i].FindControl("txtbottleqty")).Text;
                    string txtbottlerate = ((TextBox)rows[i].FindControl("txtbottlerate")).Text;
                    string txtbaseqty = ((TextBox)rows[i].FindControl("txtbaseqty")).Text;
                    string txtreorderlevel = ((TextBox)rows[i].FindControl("txtreorderlevel")).Text;
                    string txtoptimumlevel = ((TextBox)rows[i].FindControl("txtoptimumlevel")).Text;
                    if (isChecked)
                    {
                        strXmlCategory.Append(@"<?xml version=""1.0"" ?>");
                        strXmlCategory.Append(@"<Category>");
                        strXmlCategory.Append(@"<Size_ID>" + hdnSize_ID + "</Size_ID>");
                        strXmlCategory.Append(@"<SPeg_Qty>" + txtspegqty + "</SPeg_Qty>");
                        strXmlCategory.Append(@"<Bottle_Qty>" + txtbottleqty + "</Bottle_Qty>");
                        strXmlCategory.Append(@"<BottleRate>" + txtbottlerate + "</BottleRate>");
                        strXmlCategory.Append(@"<BaseQty>" + txtbaseqty + "</BaseQty>");
                        strXmlCategory.Append(@"<Reorder>" + txtreorderlevel + "</Reorder>");
                        strXmlCategory.Append(@"<Optimum>" + txtoptimumlevel + "</Optimum>");
                        strXmlCategory.Append(@"</Category>");
                    }

                    CategoryDetails = strXmlCategory.ToString();
                    Cat_Size_ID = Convert.ToInt32(((HiddenField)rows[i].FindControl("hdnSize_ID")).Value);
                    BrandID = Convert.ToInt32(ddlBrand.SelectedValue);
                    DataSet dt = new DataSet();
                    dt = ObjCocktailWorld.Fetch_Brand_Opening(Cat_Size_ID, BrandID, CompanyID);
                    if (dt.Tables[0].Rows.Count == 0)
                    {
                        Operation = "Insert";
                        Opening_ID = 0;
                    }
                    else
                    {
                        Operation = "Update";
                        Opening_ID = Convert.ToInt32(dt.Tables[0].Rows[0]["Opening_ID"]);
                    }

                    if (!string.IsNullOrEmpty(txtspegqty) || !string.IsNullOrEmpty(txtbottleqty))
                        ObjCocktailWorld.Save_BrandOpening(Opening_ID, CategoryDetails, BrandID, CompanyID, LoggedInUserID, Operation);
                }
                FetchBrandSizeLinkUp();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}