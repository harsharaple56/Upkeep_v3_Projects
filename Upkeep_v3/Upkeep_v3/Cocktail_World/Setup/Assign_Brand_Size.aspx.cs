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
                Bind_License();
                Bind_Category();
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
                        txtCategoryAlias.Text = Convert.ToString(ds.Tables[0].Rows[0]["Category_Alias"]);
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
                int License_ID = 0;
                DataSet ds = new DataSet();
                Category_ID = Convert.ToInt32(ddlCategory.SelectedValue);
                License_ID = Convert.ToInt32(ddlLicense.SelectedValue);
                if (License_ID != 0 && Category_ID != 0)
                {
                    ds = ObjCocktailWorld.Fetch_CategorySizeLinkup(0, Category_ID, License_ID, CompanyID,0);
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
            bool a = false;
            bool b = false;

            CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
            LicenseID = Convert.ToInt32(ddlLicense.SelectedValue);

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

                if (allChecked)
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



                            #region Fetch Old Data
                            DataSet dataSet = new DataSet();
                            dataSet = ObjCocktailWorld.Fetch_CategorySizeLinkup(Convert.ToInt32(hdnSize_ID), CategoryID, LicenseID, CompanyID,0);
                            if (dataSet.Tables[0].Rows.Count > 0)
                            {
                                if (dataSet.Tables[0].Rows[0]["NoOfSpeg"].ToString() == txtnoofspeg && dataSet.Tables[0].Rows[0]["PegSize"].ToString() == txtpegsize
                                    && dataSet.Tables[0].Rows[0]["Stock_In"].ToString() == StockIn && dataSet.Tables[0].Rows[0]["Alias"].ToString() == txtalias)
                                {
                                    b = true;
                                }
                                else
                                {
                                    a = true;
                                }
                            }
                            #endregion
                        }
                    }


                    strXmlCategory.Append(@"</CategoryRoot>");
                    CategoryDetails = strXmlCategory.ToString();


                    if (a)
                    {
                        DataSet dsCatSave = new DataSet();
                        dsCatSave = ObjCocktailWorld.Save_CategorySizeLinkup(CategoryID, CategoryDetails, LicenseID, CompanyID, LoggedInUserID);
                        if (dsCatSave.Tables.Count > 0)
                        {
                            if (dsCatSave.Tables[1].Rows.Count > 0)
                            {
                                int Status = Convert.ToInt32(dsCatSave.Tables[1].Rows[0]["Status"]);
                                if (Status == 1)
                                {
                                    Page.ClientScript.RegisterHiddenField("Success", "Success");
                                }
                                else if (Status == 3)
                                {
                                    //Page.ClientScript.RegisterHiddenField("Duplicate", "Duplicate");
                                }
                                else if (Status == 2)
                                {
                                    //Page.ClientScript.RegisterHiddenField("Technical", "Due to some technical issue your request can not be process. Kindly try after some time");
                                }
                            }
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterHiddenField("matched", "matched");
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
            Bind_Category();
        }

        protected void ddlLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            FetchCategorySizeLinkUp();
        }
    }
}