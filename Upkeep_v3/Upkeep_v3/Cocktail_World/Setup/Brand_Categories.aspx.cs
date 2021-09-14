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
        public ArrayList gblArrMDICheckedLicensegblArrMDICheckedLicense = new ArrayList();

        DataSet Ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            if (!IsPostBack)
            {
                BindCategory();
            }
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

        }

        protected void btnCategorySave_Click(object sender, EventArgs e)
        {
            try
            {
                string Cate_Desc = txtCategoryDesc.Text;
                DataSet dsCateDesc = new DataSet();
                //dsCateDesc = ObjCocktailWorld.
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
                int Category_ID;
                //ObjCategorySizeLnkUp = new ClsCategorySizelinlup();
                // ds = new DataTable();

                DataSet ds = new DataSet();
                //  ds = ObjCocktailWorld.CategoryMaster_CRUD(24, 0, "", "", LoggedInUserID, "select");
                Category_ID = Convert.ToInt32(ddlCategory.SelectedValue);

                ds = ObjCocktailWorld.FetchCategorySizeLinkup(Category_ID);


                //  ObjCategorySizeLnkUp.CategoryID = DDLCatag.SelectedValue;
                // ObjCategorySizeLnkUp.LicenseID = Session("LicID");
                // ObjDt = ObjCategorySizeLnkUp.FunFetch;
                //txtDetails.Text = "";
                //txtDetails.Text = "=$=";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdCatagLinkUp.DataSource = ds.Tables[0];
                    grdCatagLinkUp.DataBind();
                    //for (int index = 0; index <= ds.Tables[0].Rows.Count - 1; index++)
                    //{
                    //    //if (ds.Tables[0].Rows[index]["Selected"] == 1)
                    //    //    txtDetails.Text += ds.Tables[0].Rows[index]["SizeID"] + "=$=";
                    //}
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
            finally
            {
                //if (!IsNothing(ObjCategorySizeLnkUp))
                //    ObjCategorySizeLnkUp = null;
                //if (!Information.IsNothing(ObjDt))
                //    ObjDt = null;
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

                dsCatSave = ObjCocktailWorld.Save_CategorySizeLinkup(CategoryID, CategoryDetails, LicenseID,CompanyID,LoggedInUserID);

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











        //   // GetSelectedLicense();
        //    int cnt;
        //   // cnt = getcount();
        //       if (cnt == 0)
        //        {
        //            for (int index = 0, loopTo = gblArrMDICheckedLicense.Count - 1; index <= loopTo; index++)
        //            {
        //               // var objsize = new ClsCategorySizelinlup();
        //                objsize.CategoryID = ddlCategory.SelectedValue;
        //                objsize.CategorySizeLnkUpXML = generateXml(gblArrMDICheckedLicense.Item(index));
        //                objsize.Username = Session("username");
        //                objsize.LicenseID = gblArrMDICheckedLicense.Item(index);
        //                objsize.FunSave();
        //            }
        //        }
        //        else
        //        {
        //            foreach (DataListItem dli in DataList1.Items)
        //            {
        //                CheckBox chk = (CheckBox)dli.FindControl("LicenseId");
        //                Label lbl = (Label)dli.FindControl("DescriptionLabel");
        //                if (chk.Checked)
        //                {
        //                    // Dl += (lbl.Text + "<br />")
        //                    var objsize = new ClsCategorySizelinlup();
        //                    objsize.CategoryID = DDLCatag.SelectedValue;
        //                    objsize.CategorySizeLnkUpXML = generateXml();
        //                  //  objsize.Username = Session("username");
        //                    objsize.LicenseID = Convert.ToDouble(lbl.Text);
        //                    objsize.FunSave();

        //                    // FetchCategorySizeLinkUp()
        //                }
        //            }
        //        }

        //    //    lblInfo.Text = "Saved successfully";
        //      //  divInfo.Style.Add("display", "inline");
        //        txtDetails.Text = "";
        //        txtDetails.Text = "=$=";
        //        FetchCategorySizeLinkUp();
        //    }
        //}



        // private XmlDocument GenerateXml()
        //{
        // Array arr = Split(txtDetails.Text, "=$=");
        //XmlDocument xmlDocProm = null/* TODO Change to default(_) if this is not a reference type */;
        //try
        //{
        //    xmlDocProm = new XmlDocument();
        //    xmlDocProm.LoadXml("<Master><CatgSizeLnk></CatgSizeLnk></Master>");
        //    XmlElement XmlElt = xmlDocProm.CreateElement("CatgSize");


        //    for (int i = 0; i <= arrRowIndex.Count - 1; i++)
        //    {
        //        // if (arrRowLicenses.Item(i) == DblLocLicenseid)
        //        //{
        //        //    int j = arrRowIndex.Item(i);
        //        //    if ((CheckBox)grdCatagLinkUp.Rows(j).Cells(0).FindControl("chkSelct").Checked == true)
        //        //    {
        //        //        XmlElt = xmlDocProm.CreateElement("CatgSize");



        //        //        XmlElt.SetAttribute("SizeID", grdCatagLinkUp.Rows(j).Cells(2).Text);



        //        //        XmlElt.SetAttribute("Alias", (TextBox)grdCatagLinkUp.Rows(j).Cells(4).FindControl("txtalias").Text);
        //        //        XmlElt.SetAttribute("ML", (TextBox)grdCatagLinkUp.Rows(j).Cells(5).FindControl("txtml").Text);
        //        //        XmlElt.SetAttribute("Speg", (TextBox)grdCatagLinkUp.Rows(j).Cells(6).FindControl("txtspeg").Text);
        //        //        XmlElt.SetAttribute("StockIN", (TextBox)grdCatagLinkUp.Rows(j).Cells(7).FindControl("txtstockin").Text);
        //        //        XmlElt.SetAttribute("noofspeg", (TextBox)grdCatagLinkUp.Rows(j).Cells(8).FindControl("txtnoofspeg").Text);
        //        //        XmlElt.SetAttribute("pegsize", (TextBox)grdCatagLinkUp.Rows(j).Cells(9).FindControl("txtpegsize").Text);
        //        //        xmlDocProm.DocumentElement.Item("CatgSizeLnk").AppendChild(XmlElt);
        //        //    }
        //        }
        //    }

        //    return xmlDocProm;
        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
        //finally
        //{
        //}
        // }






    }
}