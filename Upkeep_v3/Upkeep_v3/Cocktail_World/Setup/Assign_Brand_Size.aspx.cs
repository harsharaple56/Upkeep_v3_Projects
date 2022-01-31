using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Cocktail_World.Setup
{
    public partial class Assign_Brand_Size : System.Web.UI.Page
    {
        CocktailWorld_Service.CocktailWorld_Service ObjCocktailWorld = new CocktailWorld_Service.CocktailWorld_Service();
        public ArrayList gblArrMDICheckedLicensegblArrMDICheckedLicense = new ArrayList();
        DataSet Ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        public static bool getUpdate = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            if (!IsPostBack)
            {
                BindCategory();
                btn_edit.Visible = false;
                btn_delete.Visible = false;
            }
        }

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            getUpdate = true;
            ListItemCollection liCol = ddlCategory.Items;
            for (int i = 0; i < liCol.Count; i++)
            {
                ListItem li = liCol[i];
                if (li.Selected)
                {
                    DataSet ds = new DataSet();
                    ds = ObjCocktailWorld.CategoryMaster_CRUD(CompanyID, Convert.ToInt32(liCol[i].Value), "", "", LoggedInUserID, "R");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtCategoryDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["Category_Desc"]);
                        mpeCategoryMaster.Show();
                    }
                }
            }
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            ListItemCollection liCol = ddlCategory.Items;
            for (int i = 0; i < liCol.Count; i++)
            {
                ListItem li = liCol[i];
                if (li.Selected)
                {
                    ObjCocktailWorld.CategoryMaster_CRUD(CompanyID, Convert.ToInt32(liCol[i].Value), "", "", LoggedInUserID, "Delete");
                    Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Brand_Categories.aspx"), false);
                }
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

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            FetchCategorySizeLinkUp();
        }

        protected void btnAddcategory_Click(object sender, EventArgs e)
        {

        }

        protected void btnCloseCategory_Click(object sender, EventArgs e)
        {
            mpeCategoryMaster.Hide();
        }

        protected void btnCategorySave_Click(object sender, EventArgs e)
        {
            try
            {
                int Category_ID = 0;
                string Cate_Desc = txtCategoryDesc.Text;
                string Cate_Alias = txtCategoryAlias.Text;
                string Action = string.Empty;

                if (getUpdate)
                {
                    ListItemCollection liCol = ddlCategory.Items;
                    for (int i = 0; i < liCol.Count; i++)
                    {
                        ListItem li = liCol[i];
                        if (li.Selected)
                        {
                            Category_ID = Convert.ToInt32(liCol[i].Value);
                            Action = "update";
                            getUpdate = false;
                        }
                    }
                }
                else
                {
                    Action = "insert";
                }
                ObjCocktailWorld.CategoryMaster_CRUD(CompanyID, Category_ID, Cate_Desc, Cate_Alias, LoggedInUserID, Action);
                mpeCategoryMaster.Hide();
                Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Brand_Categories.aspx"), false);
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
                DataSet ds = new DataSet();
                Category_ID = Convert.ToInt32(ddlCategory.SelectedValue);
                if (Category_ID != 0)
                {
                    ds = ObjCocktailWorld.Fetch_CategorySizeLinkup(Category_ID, CompanyID);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ddlCategory.SelectedIndex > 0)
                        {
                            grdCatagLinkUp.DataSource = ds.Tables[0];
                            grdCatagLinkUp.DataBind();
                            btn_edit.Visible = true;
                            btn_delete.Visible = true;
                        }
                    }
                    else
                    {
                        grdCatagLinkUp.DataSource = null;
                        grdCatagLinkUp.DataBind();
                        btn_edit.Visible = false;
                        btn_delete.Visible = false;
                    }
                }
                else
                {
                    grdCatagLinkUp.DataSource = null;
                    grdCatagLinkUp.DataBind();
                    btn_edit.Visible = false;
                    btn_delete.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string CategoryDetails = string.Empty;
            var rows = grdCatagLinkUp.Rows;
            int count = grdCatagLinkUp.Rows.Count;

            int CategoryID = 0;
            int LicenseID = 0;

            try
            {
                StringBuilder strXmlCategory = new StringBuilder();
                strXmlCategory.Append(@"<?xml version=""1.0"" ?>");
                strXmlCategory.Append(@"<CategoryRoot>");

                for (int i = 0; i < count; i++)
                {

                    bool isChecked = ((CheckBox)rows[i].FindControl("chkSelct")).Checked;
                    if (isChecked)
                    {
                        string hdnSize_ID = ((HiddenField)rows[i].FindControl("hdnSize_ID")).Value;
                        string txtalias = ((TextBox)rows[i].FindControl("txtalias")).Text;

                        DropDownList ddlStockIn = (DropDownList)rows[i].FindControl("ddlStockIn");
                        string StockIn = ddlStockIn.SelectedItem.Value;

                        string txtnoofspeg = ((TextBox)rows[i].FindControl("txtnoofspeg")).Text;
                        string txtpegsize = ((TextBox)rows[i].FindControl("txtpegsize")).Text;

                        strXmlCategory.Append(@"<Category>");
                        strXmlCategory.Append(@"<Size_ID>" + hdnSize_ID + "</Size_ID>");
                        strXmlCategory.Append(@"<Alias>" + txtalias + "</Alias>");
                        strXmlCategory.Append(@"<PegSizeML>" + txtpegsize + "</PegSizeML>");
                        strXmlCategory.Append(@"<StockIn>" + StockIn + "</StockIn>");
                        strXmlCategory.Append(@"<Size_Qty>" + txtnoofspeg + "</Size_Qty>");

                        strXmlCategory.Append(@"</Category>");
                    }
                }

                strXmlCategory.Append(@"</CategoryRoot>");

                CategoryDetails = strXmlCategory.ToString();

                CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                //LicenseID = Convert.ToInt32(ddllicense.SelectedValue);
                LicenseID = 3;

                DataSet dsCatSave = new DataSet();

                dsCatSave = ObjCocktailWorld.Save_CategorySizeLinkup(CategoryID, CategoryDetails, LicenseID, CompanyID, LoggedInUserID);

                if (Ds.Tables.Count > 0)
                {
                    if (Ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(Ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 0)
                        {

                        }
                        else if (Status == 1)
                        {

                            //  Response.Redirect(Page.ResolveClientUrl(""), false);
                        }
                        else if (Status == 3)
                        {
                            //lblErrorMsg.Text = "";
                        }
                        else if (Status == 2)
                        {
                            // lblErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void grdCatagLinkUp_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                GridViewRow gvRow = (GridViewRow)e.Row;
                HiddenField hdnStockIn = (HiddenField)gvRow.FindControl("hdnStockIn");
                if (hdnStockIn != null)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        DropDownList ddlStockIn = (DropDownList)gvRow.FindControl("ddlStockIn");
                        ddlStockIn.SelectedValue = hdnStockIn.Value;
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
            BindCategory();
        }
    }
}