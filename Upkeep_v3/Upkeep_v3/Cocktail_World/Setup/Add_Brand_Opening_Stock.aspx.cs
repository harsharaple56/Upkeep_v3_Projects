using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

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
                Bind_License();
                Fetch_Category_Brand();
                int BrandOpening_ID = Convert.ToInt32(Request.QueryString["BrandOpening_ID"]);
                if (BrandOpening_ID > 0)
                {
                    UpdateBrandOpening(BrandOpening_ID);
                }
                int DelBrandOpening_ID = Convert.ToInt32(Request.QueryString["DelBrandOpening_ID"]);
                if (DelBrandOpening_ID > 0)
                {
                    DeleteBrandOpening(DelBrandOpening_ID);
                }
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
            FetchBrandSizeLinkUp(0, 0);
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
                    ddlCategory.Items.Insert(0, new ListItem("--Select Category--", "0"));
                }
                else if (CategoryID > 0)
                {
                    ddlBrand.DataSource = dsCategory.Tables[0];
                    ddlBrand.DataTextField = "Brand_Desc";
                    ddlBrand.DataValueField = "Brand_ID";
                    ddlBrand.DataBind();
                    ddlBrand.Items.Insert(0, new ListItem("--Select Brand--", "0"));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FetchBrandSizeLinkUp(int Category_ID, int Brand_ID)
        {
            try
            {
                DataSet ds = new DataSet();
                if (Category_ID == 0)
                    Category_ID = Convert.ToInt32(ddlCategory.SelectedValue);
                if (Brand_ID == 0 && !string.IsNullOrEmpty(ddlBrand.SelectedValue.ToString()))
                    Brand_ID = Convert.ToInt32(ddlBrand.SelectedValue);
                if (Category_ID != 0 && Brand_ID != 0)
                {
                    ds = ObjCocktailWorld.FetchBrandSizeLinkup(Category_ID, Brand_ID, 0, "", "", CompanyID, Convert.ToInt32(ddlLicense.SelectedValue), string.Empty, DateTime.Now);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        grdCatagLinkUp.Visible = true;
                        grdCatagLinkUp.DataSource = ds.Tables[0];
                        grdCatagLinkUp.DataBind();
                    }
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
            FetchBrandSizeLinkUp(0, 0);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string CategoryDetails = string.Empty;
            var rows = grdCatagLinkUp.Rows;
            int count = grdCatagLinkUp.Rows.Count;
            int Cat_Size_ID = 0;
            int BrandID = 0;
            int License_ID = Convert.ToInt32(ddlLicense.SelectedValue);
            int BrandOpening_ID = 0;
            string Action = string.Empty;
            bool a = false;
            bool b = false;

            try
            {
                bool allChecked = false;
                for (int i = 0; i < count; i++)
                {
                    bool isChecked = ((CheckBox)rows[i].FindControl("chkSelct")).Checked;
                    if (isChecked)
                    {
                        allChecked = true;
                        break;
                    }
                }

                bool is_Match = false;

                if (allChecked)
                {
                    for (int i = 0; i < count; i++)
                    {
                        bool isChecked = ((CheckBox)rows[i].FindControl("chkSelct")).Checked;
                        if (isChecked)
                        {
                            string hdnSize_ID = ((HiddenField)rows[i].FindControl("hdnSize_ID")).Value;
                            string txtspegqty = ((TextBox)rows[i].FindControl("txtspegqty")).Text;
                            string txtbottleqty = ((TextBox)rows[i].FindControl("txtbottleqty")).Text;
                            string txtbottlerate = ((TextBox)rows[i].FindControl("txtbottlerate")).Text;
                            string txtbaseqty = ((TextBox)rows[i].FindControl("txtbaseqty")).Text;
                            string txtreorderlevel = ((TextBox)rows[i].FindControl("txtreorderlevel")).Text;
                            string txtoptimumlevel = ((TextBox)rows[i].FindControl("txtoptimumlevel")).Text;

                            if (string.IsNullOrEmpty(txtspegqty))
                                txtspegqty = "0";
                            if (string.IsNullOrEmpty(txtbottleqty))
                                txtbottleqty = "0";
                            if (string.IsNullOrEmpty(txtbottlerate))
                                txtbottlerate = "0";
                            if (string.IsNullOrEmpty(txtbaseqty))
                                txtbaseqty = "0";
                            if (string.IsNullOrEmpty(txtreorderlevel))
                                txtreorderlevel = "0";
                            if (string.IsNullOrEmpty(txtoptimumlevel))
                                txtoptimumlevel = "0";

                            var settings = new XElement("CW", new XElement("BrandOpening", new XElement("CatgSize",
                                           new XAttribute("CategorySizeLinkUpID", hdnSize_ID),
                                           new XAttribute("BottleQty", txtbottleqty),
                                           new XAttribute("SPegQty", txtspegqty),
                                           new XAttribute("BottleRate", txtbottlerate),
                                           new XAttribute("BaseQty", txtbaseqty),
                                           new XAttribute("ReorderLevel", txtreorderlevel),
                                           new XAttribute("OptimumLevel", txtoptimumlevel)
                                           )));

                            CategoryDetails = settings.ToString();

                            Cat_Size_ID = Convert.ToInt32(((HiddenField)rows[i].FindControl("hdnSize_ID")).Value);
                            BrandID = Convert.ToInt32(ddlBrand.SelectedValue);
                            DataSet dt = new DataSet();
                            dt = ObjCocktailWorld.Fetch_Brand_Opening(Cat_Size_ID, 0, BrandID, "", "", "", CompanyID, Convert.ToString(ddlLicense.SelectedValue));
                            if (dt.Tables[0].Rows.Count == 0)
                            {
                                Action = "I";
                                BrandOpening_ID = 0;
                                is_Match = false;
                                a = true;
                            }
                            else
                            {

                                #region Fetch Old Data
                                if (dt.Tables[0].Rows.Count > 0)
                                {
                                    if (Convert.ToBoolean(dt.Tables[0].Rows[0]["Selected"]) == isChecked && dt.Tables[0].Rows[0]["Bottle_Qty"].ToString() == txtbottleqty && dt.Tables[0].Rows[0]["SPeg_Qty"].ToString() == txtspegqty
                                        && dt.Tables[0].Rows[0]["Bottle_Rate"].ToString() == txtbottlerate && dt.Tables[0].Rows[0]["Base_Qty"].ToString() == txtbaseqty
                                        && dt.Tables[0].Rows[0]["Optimum_Level"].ToString() == txtoptimumlevel && dt.Tables[0].Rows[0]["Re_Order_Level"].ToString() == txtreorderlevel)
                                    {
                                        is_Match = true;
                                        b = true;
                                    }
                                    else
                                    {
                                        a = true;
                                    }
                                }
                                #endregion


                                Action = "U";
                                BrandOpening_ID = Convert.ToInt32(dt.Tables[0].Rows[0]["Opening_ID"]);

                            }

                            if (a)
                            {
                                ObjCocktailWorld.BrandOpeningMaster_CRUD(BrandOpening_ID, CategoryDetails, BrandID, 0, 0, License_ID, CompanyID, LoggedInUserID, Action);
                            }
                        }

                    }
                    if (!a)
                    {
                        Page.ClientScript.RegisterHiddenField("matched", "matched");
                    }
                    else
                    {
                        Page.ClientScript.RegisterHiddenField("Redirect", "Redirect");
                    }
                }
                else
                {
                    Page.ClientScript.RegisterHiddenField("selected", "selected");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateBrandOpening(int BrandOpening_ID)
        {
            try
            {
                DataSet ds = new DataSet();
                XmlDocument xmlBrandDetails = new XmlDocument();
                xmlBrandDetails.LoadXml("<CW><BrandOpening></BrandOpening></CW>");

                ds = ObjCocktailWorld.BrandOpeningMaster_CRUD(BrandOpening_ID, xmlBrandDetails.OuterXml.ToString(), 0, 0, 0, Convert.ToInt32(ddlLicense.SelectedValue), CompanyID, LoggedInUserID, "R");
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlCategory.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Category_ID"]);
                        ddlLicense.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["License_ID"]);
                        FetchBrands(Convert.ToInt32(ds.Tables[0].Rows[0]["Category_ID"]), Convert.ToInt32(ds.Tables[0].Rows[0]["Brand_ID"]));
                        FetchBrandSizeLinkUp(Convert.ToInt32(ds.Tables[0].Rows[0]["Category_ID"]), Convert.ToInt32(ds.Tables[0].Rows[0]["Brand_ID"]));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FetchBrands(int categoryid, int brandid)
        {
            DataSet dsCategory = new DataSet();
            dsCategory = ObjCocktailWorld.Fetch_Category_Brand(CompanyID, categoryid);
            if (dsCategory.Tables[0].Rows.Count > 0)
            {
                ddlBrand.DataSource = dsCategory.Tables[0];
                ddlBrand.DataTextField = "Brand_Desc";
                ddlBrand.DataValueField = "Brand_ID";
                ddlBrand.DataBind();
                ddlBrand.SelectedValue = Convert.ToString(brandid);
            }
        }

        public void DeleteBrandOpening(int BrandOpening_ID)
        {
            try
            {
                DataSet ds = new DataSet();
                XmlDocument xmlBrandDetails = new XmlDocument();
                xmlBrandDetails.LoadXml("<CW><BrandOpening></BrandOpening></CW>");

                ds = ObjCocktailWorld.BrandOpeningMaster_CRUD(BrandOpening_ID, xmlBrandDetails.OuterXml.ToString(), 0, 0, 0, Convert.ToInt32(ddlLicense.SelectedValue), CompanyID, LoggedInUserID, "D");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Brand_Opening_Stock.aspx"), false);
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

        protected void ddlLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            FetchBrandSizeLinkUp(0, 0);
        }
    }
}