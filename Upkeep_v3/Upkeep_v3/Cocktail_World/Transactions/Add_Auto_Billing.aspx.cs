using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Cocktail_World.Transactions
{
    public partial class Add_Auto_Billing : System.Web.UI.Page
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
                Fetch_License();
                Fetch_Brand_Size();
                SetBrandInitialRow();
                Fetch_CocktailName();
                //SetCocktailInitialRow();

                #region Edit and Delete Sale
                int Sale_ID = Convert.ToInt32(Request.QueryString["Sale_ID"]);
                int DelSale_ID = Convert.ToInt32(Request.QueryString["DelSale_ID"]);
                if (Sale_ID > 0)
                {
                    Bind_SaleMaster(Sale_ID);
                }
                if (DelSale_ID > 0)
                {
                    Delete_SaleMaster(DelSale_ID);
                }
                #endregion
            }
        }

        public void Bind_SaleMaster(int Sale_ID)
        {
            try
            {
                DataSet dsSale = new DataSet();
                dsSale = ObjCocktailWorld.SaleMaster_Crud(Sale_ID, string.Empty, string.Empty, 0, "Fetch", Convert.ToInt32(LoggedInUserID), CompanyID);

                DataSet dsSaleDetail = new DataSet();
                dsSaleDetail = ObjCocktailWorld.SaleDetailsMaster_Crud(Sale_ID, 0, string.Empty, string.Empty, string.Empty, 0, string.Empty, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "Fetch", Convert.ToInt32(LoggedInUserID), CompanyID);

                if (dsSale.Tables.Count > 0)
                {
                    if (dsSale.Tables[0].Rows.Count > 0)
                    {
                        DateTime saleDate = Convert.ToDateTime(dsSale.Tables[0].Rows[0]["Sale_Date"]);
                        txtBrandDate.Text = saleDate.ToString("dd-MMMM-yyyy");
                        string txtLicen = Convert.ToString(dsSale.Tables[0].Rows[0]["License_ID"]);

                        Fetch_License();
                        ddlLicense.ClearSelection(); //making sure the previous selection has been cleared
                        ddlLicense.Items.FindByValue(txtLicen).Selected = true;

                        DataRow drCurrentRow = null;
                        DataTable dtCurrentTable = new DataTable();

                        dtCurrentTable.Columns.Add("Brand", typeof(String));
                        dtCurrentTable.Columns.Add("Size", typeof(String));
                        dtCurrentTable.Columns.Add("sPegQty", typeof(String));
                        dtCurrentTable.Columns.Add("sPegRate", typeof(String));
                        dtCurrentTable.Columns.Add("lPegQty", typeof(String));
                        dtCurrentTable.Columns.Add("lPegRate", typeof(String));
                        dtCurrentTable.Columns.Add("Bottle_Qty", typeof(String));
                        dtCurrentTable.Columns.Add("Bottle_Rate", typeof(String));
                        dtCurrentTable.Columns.Add("Stock", typeof(String));
                        dtCurrentTable.Columns.Add("Total_Amount", typeof(String));
                        dtCurrentTable.Columns.Add("Tax_Amount", typeof(String));

                        dsSaleDetail.Tables[0].Columns.Add("Stock", typeof(String));

                        if (ViewState["Brands"] != null)
                        {
                            for (int i = 0; i < dsSaleDetail.Tables[0].Rows.Count; i++)
                            {
                                drCurrentRow = dtCurrentTable.NewRow();
                                drCurrentRow["Brand"] = dsSaleDetail.Tables[0].Rows[i]["Brand_Desc"].ToString();
                                drCurrentRow["Size"] = dsSaleDetail.Tables[0].Rows[i]["Size_Desc"].ToString();
                                drCurrentRow["sPegQty"] = dsSaleDetail.Tables[0].Rows[i]["SPeg_Qty"].ToString();
                                drCurrentRow["sPegRate"] = dsSaleDetail.Tables[0].Rows[i]["SPeg_Rate"].ToString();
                                drCurrentRow["lPegQty"] = dsSaleDetail.Tables[0].Rows[i]["LPeg_Qty"].ToString();
                                drCurrentRow["lPegRate"] = dsSaleDetail.Tables[0].Rows[i]["LPeg_Rate"].ToString();
                                drCurrentRow["Bottle_Qty"] = dsSaleDetail.Tables[0].Rows[i]["Bottle_Qty"].ToString();
                                drCurrentRow["Bottle_Rate"] = dsSaleDetail.Tables[0].Rows[i]["Bottle_Rate"].ToString();
                                drCurrentRow["Tax_Amount"] = dsSaleDetail.Tables[0].Rows[i]["Category_Tax_Amt"].ToString();
                                drCurrentRow["Total_Amount"] = dsSaleDetail.Tables[0].Rows[i]["Total_Amt"].ToString();



                                DataSet dsGetStockDetails = new DataSet();
                                dsGetStockDetails = ObjCocktailWorld.FetchBrandSizeLinkup(0, 0, 0, dsSaleDetail.Tables[0].Rows[i]["Brand_Desc"].ToString(), dsSaleDetail.Tables[0].Rows[i]["Size_Desc"].ToString(), CompanyID);
                                if (dsGetStockDetails.Tables[0].Rows.Count > 0)
                                {
                                    string getBottle = dsGetStockDetails.Tables[0].Rows[0].ItemArray[0].ToString();
                                    string getsPeg = dsGetStockDetails.Tables[0].Rows[0].ItemArray[1].ToString();
                                    string getOpningID = dsGetStockDetails.Tables[0].Rows[0].ItemArray[2].ToString();
                                    string displayStock = "Bottle :" + getBottle + " , Speg :" + getsPeg;
                                    drCurrentRow["Stock"] = displayStock;
                                }
                                else
                                {
                                    drCurrentRow["Stock"] = "Bottle :" + 0 + " , Speg :" + 0;
                                }

                                dtCurrentTable.Rows.Add(drCurrentRow);
                            }
                            dtCurrentTable.AcceptChanges();
                        }

                        if (dtCurrentTable.Rows.Count > 0)
                        {
                            grdBrandLinkup.DataSource = dtCurrentTable.Copy();
                            grdBrandLinkup.DataBind();
                            DataTable dt = new DataTable();
                            dt = dtCurrentTable.Copy();
                            ViewState["Brands"] = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Delete_SaleMaster(int Sale_ID)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = ObjCocktailWorld.SaleMaster_Crud(Sale_ID, string.Empty, string.Empty, 0, "D", Convert.ToInt32(LoggedInUserID), CompanyID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataSet dsSD = new DataSet();
                        dsSD = ObjCocktailWorld.SaleDetailsMaster_Crud(Sale_ID, 0, string.Empty, string.Empty, string.Empty, 0, string.Empty, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "Delete", Convert.ToInt32(LoggedInUserID), CompanyID);

                        Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Transactions/Sales.aspx"), false);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Fetch_License()
        {
            ds = ObjCocktailWorld.License_CRUD(0, string.Empty, string.Empty, LoggedInUserID, CompanyID, "R");
            ddlLicense.DataSource = ds.Tables[0];
            ddlLicense.DataTextField = "License_Name";
            ddlLicense.DataValueField = "License_ID";
            ddlLicense.DataBind();
            ddlLicense.Items.Insert(0, new ListItem("------Select License-----", "0"));
        }

        private DataSet GetStockDetails()
        {
            int BrandID, Size_ID = 0;

            if (!string.IsNullOrEmpty(ddlBrand.SelectedValue))
                BrandID = Convert.ToInt32(ddlBrand.SelectedValue);
            else
                BrandID = 0;

            if (!string.IsNullOrEmpty(ddlSize.SelectedValue))
                Size_ID = Convert.ToInt32(ddlSize.SelectedValue);
            else
                Size_ID = 0;
            if (Size_ID > 0)
                ds = ObjCocktailWorld.FetchBrandSizeLinkup(0, BrandID, Size_ID, "", "", CompanyID);
            else
                ds = null;
            return ds;
        }

        private void Fetch_Brand_Size()
        {
            int BrandID, Size_ID = 0;
            Session.Remove("hdnTax");
            Session["hdnTax"] = null;

            if (!string.IsNullOrEmpty(ddlBrand.SelectedValue))
                BrandID = Convert.ToInt32(ddlBrand.SelectedValue);
            else
                BrandID = 0;

            try
            {
                ds = ObjCocktailWorld.FetchBrandSizeLinkup(0, BrandID, Size_ID, "", "", CompanyID);

                if (BrandID == 0)
                {
                    ddlBrand.DataSource = ds.Tables[0];
                    ddlBrand.DataTextField = "Brand_Desc";
                    ddlBrand.DataValueField = "Brand_ID";
                    ddlBrand.DataBind();
                    ddlBrand.Items.Insert(0, new ListItem("--Select Brand--", "0"));
                }
                else if (BrandID > 0 && Size_ID == 0)
                {
                    ddlSize.DataSource = ds.Tables[0];
                    ddlSize.DataTextField = "Alias";
                    ddlSize.DataValueField = "Size_ID";
                    ddlSize.DataBind();
                    ddlSize.Items.Insert(0, new ListItem("--Select Size--", "0"));

                    DataSet dsGetTax = new DataSet();
                    dsGetTax = ObjCocktailWorld.FetchTaxDetails(BrandID);
                    if (dsGetTax.Tables[0].Rows.Count > 0)
                    {
                        string Tax_Percentage = dsGetTax.Tables[0].Rows[0].ItemArray[2].ToString();
                        Session["hdnTax"] = Tax_Percentage;
                    }
                    else
                        Session["hdnTax"] = "0";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fetch_Brand_Size();
        }

        protected void ddlSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = GetStockDetails();
            if (ds == null)
            {
                lbl_stock.Text = string.Empty;
            }
            else if (ds.Tables[0].Rows.Count > 0)
            {
                string getBottle = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                string getsPeg = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                string displayStock = "Available Stock :- Bottle :" + getBottle + " & Speg :" + getsPeg;
                lbl_stock.Text = displayStock;
            }
        }

        private void Fetch_CocktailName()
        {
            Session.Remove("hdnCocktailTax");
            Session["hdnCocktailTax"] = null;

            ds = ObjCocktailWorld.CocktailMaster_CRUD(0, "", "", CompanyID, "", "Fetch");
            ddlCocktail.DataSource = ds.Tables[0];
            ddlCocktail.DataTextField = "Cocktail_Desc";
            ddlCocktail.DataValueField = "Cocktail_ID";
            ddlCocktail.DataBind();
            ddlCocktail.Items.Insert(0, new ListItem("--Select Cocktail--", "0"));

            if (ddlCocktail.SelectedIndex > 0)
            {
                DataSet dsGetBrandId = new DataSet();
                dsGetBrandId = ObjCocktailWorld.Fetch_Brand_Opening(0, 0, 0, "", ddlCocktail.SelectedValue, CompanyID);
                if (dsGetBrandId.Tables[0].Rows.Count > 0)
                {
                    DataSet dsGetTax = new DataSet();
                    dsGetTax = ObjCocktailWorld.FetchTaxDetails(Convert.ToInt32(dsGetBrandId.Tables[0].Rows[0]["Brand_ID"]));
                    if (dsGetTax.Tables[0].Rows.Count > 0)
                    {
                        string Tax_Percentage = dsGetTax.Tables[0].Rows[0].ItemArray[2].ToString();
                        Session["hdnCocktailTax"] = Tax_Percentage;
                    }
                    else
                        Session["hdnCocktailTax"] = "0";
                }
                else
                {
                    Session["hdnCocktailTax"] = "0";
                }
            }
        }

        private ArrayList GetPermitHolderData()
        {
            ArrayList arr = new ArrayList();
            DataSet dsPermit = new DataSet();
            int CompanyID = Convert.ToInt32(Session["CompanyID"]);
            dsPermit = ObjCocktailWorld.PermitMaster_CRUD(0, "", LoggedInUserID, CompanyID, "SELECT");

            foreach (DataRow dataRow in dsPermit.Tables[0].Rows)
                arr.Add(new ListItem(Convert.ToString(dataRow.ItemArray[1]), Convert.ToString(dataRow.ItemArray[0])));

            return arr;
        }

        private void FillDropDownListPermitHolder(DropDownList ddl)
        {
            ArrayList arr = GetPermitHolderData();
            foreach (ListItem item in arr)
            {
                ddl.Items.Add(item);
            }
        }

        private void FillDropDownListPermitHolderCocktail(DropDownList dd2)
        {
            ArrayList arr = GetPermitHolderData();
            foreach (ListItem item in arr)
            {
                dd2.Items.Add(item);
            }
        }

        private void SetBrandInitialRow()
        {
            try
            {
                ViewState["Brands"] = null;

                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[11]
                {
                    new DataColumn("Brand", typeof(string)),
                    new DataColumn("Size", typeof(string)),
                    new DataColumn("Stock", typeof(string)),
                    new DataColumn("sPegQty", typeof(string)),
                    new DataColumn("sPegRate",typeof(string)),
                    new DataColumn("lPegQty", typeof(string)),
                    new DataColumn("lPegRate", typeof(string)),
                    new DataColumn("Bottle_Qty", typeof(string)),
                    new DataColumn("Bottle_Rate", typeof(string)),
                    new DataColumn("Total_Amount", typeof(string)),
                    new DataColumn("Tax_Amount", typeof(string))
                });

                DataRow drRow = dt.NewRow();
                drRow["Brand"] = string.Empty;
                drRow["Size"] = string.Empty;
                drRow["Stock"] = string.Empty;
                drRow["sPegQty"] = string.Empty;
                drRow["sPegRate"] = string.Empty;
                drRow["lPegQty"] = string.Empty;
                drRow["lPegRate"] = string.Empty;
                drRow["Bottle_Qty"] = string.Empty;
                drRow["Bottle_Rate"] = string.Empty;
                drRow["Total_Amount"] = string.Empty;
                drRow["Tax_Amount"] = string.Empty;
                dt.Rows.Add(drRow);

                ViewState["Brands"] = dt;
                BindBrandGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetCocktailInitialRow()
        {
            try
            {
                ViewState["Cocktails"] = null;

                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[]
                {
        new DataColumn("Cocktail_Desc", typeof(string)),
        new DataColumn("Cat_Bottle_Qty", typeof(string)),
        new DataColumn("Cat_Bottle_Rate", typeof(string)),
        new DataColumn("Cat_Total_Amount", typeof(string)),
        new DataColumn("Cat_Tax_Amount", typeof(string)),

                });

                DataRow drRow = dt.NewRow();
                drRow["Cocktail_Desc"] = string.Empty;
                drRow["Cat_Bottle_Qty"] = string.Empty;
                drRow["Cat_Bottle_Rate"] = string.Empty;
                drRow["Cat_Total_Amount"] = string.Empty;
                drRow["Cat_Tax_Amount"] = string.Empty;

                dt.Rows.Add(drRow);

                ViewState["Cocktails"] = dt;
                BindCocktailGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AddBrandNewRowToGrid()
        {
            try
            {
                int rowIndex = 0;
                if (ViewState["Brands"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["Brands"];

                    DataRow drCurrentRow = null;

                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {
                            //extract the TextBox values  
                            TextBox txt1 = grdBrandLinkup.Rows[rowIndex].FindControl("txtspegqty") as TextBox;
                            TextBox txt2 = grdBrandLinkup.Rows[rowIndex].FindControl("txtspegrate") as TextBox;
                            TextBox txt3 = grdBrandLinkup.Rows[rowIndex].FindControl("txtlpegqty") as TextBox;
                            TextBox txt4 = grdBrandLinkup.Rows[rowIndex].FindControl("txtlpegrate") as TextBox;
                            TextBox txt5 = grdBrandLinkup.Rows[rowIndex].FindControl("txtbottleqty") as TextBox;
                            TextBox txt6 = grdBrandLinkup.Rows[rowIndex].FindControl("txtbottlerate") as TextBox;
                            TextBox txt7 = grdBrandLinkup.Rows[rowIndex].FindControl("txttotalamount") as TextBox;
                            TextBox txt8 = grdBrandLinkup.Rows[rowIndex].FindControl("txtamount") as TextBox;

                            drCurrentRow = dtCurrentTable.NewRow();
                            drCurrentRow["Brand"] = ddlBrand.SelectedItem.Text;
                            drCurrentRow["Size"] = ddlSize.SelectedItem.Text;
                            DataSet ds = new DataSet();
                            ds = GetStockDetails();
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                string getBottle = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                                string getsPeg = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                                string getOpningID = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                                string displayStock = "Bottle :" + getBottle + " , Speg :" + getsPeg;
                                drCurrentRow["Stock"] = displayStock;
                            }
                            else
                            {
                                drCurrentRow["Stock"] = "Bottle :" + 0 + " , Speg :" + 0;
                            }

                            dtCurrentTable.Rows[i - 1]["sPegQty"] = txt1.Text;
                            dtCurrentTable.Rows[i - 1]["sPegRate"] = txt2.Text;
                            dtCurrentTable.Rows[i - 1]["lPegQty"] = txt3.Text;
                            dtCurrentTable.Rows[i - 1]["lPegRate"] = txt4.Text;
                            dtCurrentTable.Rows[i - 1]["Bottle_Qty"] = txt5.Text;
                            dtCurrentTable.Rows[i - 1]["Bottle_Rate"] = txt6.Text;
                            dtCurrentTable.Rows[i - 1]["Total_Amount"] = txt7.Text;
                            dtCurrentTable.Rows[i - 1]["Tax_Amount"] = txt8.Text;
                            rowIndex++;
                        }

                        dtCurrentTable.Rows.Add(drCurrentRow);

                        //Delete Extra Row
                        for (int i = dtCurrentTable.Rows.Count - 1; i >= 0; i--)
                        {
                            DataRow dr = dtCurrentTable.Rows[i];
                            if (string.IsNullOrEmpty(dr.ItemArray[1].ToString()) && string.IsNullOrEmpty(dr.ItemArray[2].ToString()))
                                dr.Delete();
                        }
                        dtCurrentTable.AcceptChanges();

                        ViewState["Brands"] = dtCurrentTable;
                        grdBrandLinkup.DataSource = dtCurrentTable;
                        grdBrandLinkup.DataBind();
                    }
                }
                else
                {
                    Response.Write("ViewState is null");
                }

                //Set Previous Data on Postbacks
                SetPreviousBrandData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetPreviousBrandData()
        {
            try
            {
                int rowIndex = 0;
                if (ViewState["Brands"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["Brands"];
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {
                            TextBox txt1 = grdBrandLinkup.Rows[rowIndex].FindControl("txtspegqty") as TextBox;
                            TextBox txt2 = grdBrandLinkup.Rows[rowIndex].FindControl("txtspegrate") as TextBox;
                            TextBox txt3 = grdBrandLinkup.Rows[rowIndex].FindControl("txtlpegqty") as TextBox;
                            TextBox txt4 = grdBrandLinkup.Rows[rowIndex].FindControl("txtlpegrate") as TextBox;
                            TextBox txt5 = grdBrandLinkup.Rows[rowIndex].FindControl("txtbottleqty") as TextBox;
                            TextBox txt6 = grdBrandLinkup.Rows[rowIndex].FindControl("txtbottlerate") as TextBox;
                            TextBox txt7 = grdBrandLinkup.Rows[rowIndex].FindControl("txttotalamount") as TextBox;
                            TextBox txt8 = grdBrandLinkup.Rows[rowIndex].FindControl("txtamount") as TextBox;
                            
                            txt1.Text = dtCurrentTable.Rows[i]["sPegQty"].ToString();
                            txt2.Text = dtCurrentTable.Rows[i]["sPegRate"].ToString();
                            txt3.Text = dtCurrentTable.Rows[i]["lPegQty"].ToString();
                            txt4.Text = dtCurrentTable.Rows[i]["lPegRate"].ToString();
                            txt5.Text = dtCurrentTable.Rows[i]["Bottle_Qty"].ToString();
                            txt6.Text = dtCurrentTable.Rows[i]["Bottle_Rate"].ToString();
                            txt7.Text = dtCurrentTable.Rows[i]["Total_Amount"].ToString();
                            txt8.Text = dtCurrentTable.Rows[i]["Tax_Amount"].ToString();
                            rowIndex++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AddCocktailNewRowToGrid()
        {
            try
            {
                int rowIndex = 0;
                if (ViewState["Cocktails"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["Cocktails"];

                    DataRow drCurrentRow = null;

                    if (dtCurrentTable.Rows.Count > 0)
                    {

                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {
                            //extract the TextBox values  
                            TextBox txt1 = grdCocktail.Rows[rowIndex].FindControl("cocktailqty") as TextBox;
                            TextBox txt2 = grdCocktail.Rows[rowIndex].FindControl("cocktailrate") as TextBox;
                            TextBox txt3 = grdCocktail.Rows[rowIndex].FindControl("cocktailtotalamount") as TextBox;
                            TextBox txt4 = grdCocktail.Rows[rowIndex].FindControl("cocktailamount") as TextBox;

                            drCurrentRow = dtCurrentTable.NewRow();
                            drCurrentRow["Cocktail_Desc"] = ddlCocktail.SelectedItem.Text;
                            dtCurrentTable.Rows[i - 1]["Cat_Bottle_Qty"] = txt1.Text;
                            dtCurrentTable.Rows[i - 1]["Cat_Bottle_Rate"] = txt2.Text;
                            dtCurrentTable.Rows[i - 1]["Cat_Total_Amount"] = txt3.Text;
                            dtCurrentTable.Rows[i - 1]["Cat_Tax_Amount"] = txt4.Text;
                            rowIndex++;
                        }

                        dtCurrentTable.Rows.Add(drCurrentRow);

                        //Delete Extra Row
                        for (int i = dtCurrentTable.Rows.Count - 1; i >= 0; i--)
                        {
                            DataRow dr = dtCurrentTable.Rows[i];
                            if (string.IsNullOrEmpty(dr.ItemArray[0].ToString()) && string.IsNullOrEmpty(dr.ItemArray[1].ToString()))
                                dr.Delete();
                        }
                        dtCurrentTable.AcceptChanges();

                        ViewState["Cocktails"] = dtCurrentTable;
                        grdCocktail.DataSource = dtCurrentTable;
                        grdCocktail.DataBind();
                    }
                }
                else
                {
                    Response.Write("ViewState is null");
                }

                //Set Previous Data on Postbacks
                SetPreviousCocktailData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetPreviousCocktailData()
        {
            try
            {
                int rowIndex = 0;
                if (ViewState["Cocktails"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["Cocktails"];
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {
                            TextBox txt1 = grdCocktail.Rows[rowIndex].FindControl("cocktailqty") as TextBox;
                            TextBox txt2 = grdCocktail.Rows[rowIndex].FindControl("cocktailrate") as TextBox;
                            TextBox txt3 = grdCocktail.Rows[rowIndex].FindControl("cocktailtotalamount") as TextBox;
                            TextBox txt4 = grdCocktail.Rows[rowIndex].FindControl("cocktailamount") as TextBox;
                            
                            txt1.Text = dtCurrentTable.Rows[i]["Cat_Bottle_Qty"].ToString();
                            txt2.Text = dtCurrentTable.Rows[i]["Cat_Bottle_Rate"].ToString();
                            txt3.Text = dtCurrentTable.Rows[i]["Cat_Total_Amount"].ToString();
                            txt4.Text = dtCurrentTable.Rows[i]["Cat_Tax_Amount"].ToString();
                            rowIndex++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BindBrandGrid()
        {
            grdBrandLinkup.DataSource = ViewState["Brands"] as DataTable;
            grdBrandLinkup.DataBind();
        }

        protected void BindCocktailGrid()
        {
            grdCocktail.DataSource = (DataTable)ViewState["Cocktails"];
            grdCocktail.DataBind();
        }

        protected void BrandOnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList DropDownList1 = (DropDownList)e.Row.FindControl("ddlPermit");
                    foreach (LinkButton button in e.Row.Cells[0].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Are You Sure Want To Remove This Transaction ?')){ return false; };";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void BrandOnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = ViewState["Brands"] as DataTable;
            dt.Rows[index].Delete();
            dt.AcceptChanges();
            ViewState["Brands"] = dt;
            BindBrandGrid();
            if (index == 0 && dt.Rows.Count == 0)
                SetBrandInitialRow();
        }

        protected void grdBrandLinkup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdBrandLinkup.PageIndex = e.NewPageIndex;
            BindBrandGrid();
        }

        protected void CocktailOnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    foreach (LinkButton button in e.Row.Cells[0].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Are You Sure Want To Remove This Transaction ?')){ return false; };";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CocktailOnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = ViewState["Cocktails"] as DataTable;
            dt.Rows[index].Delete();
            dt.AcceptChanges();
            ViewState["Cocktails"] = dt;
            BindCocktailGrid();
            if (index == 0 && dt.Rows.Count == 0)
                SetCocktailInitialRow();
        }

        protected void grdCocktailLinkup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdBrandLinkup.PageIndex = e.NewPageIndex;
            BindCocktailGrid();
        }

        protected void btn_AddBrand_Click(object sender, EventArgs e)
        {
            AddBrandNewRowToGrid();
        }

        protected void btn_AddCocktail_Click(object sender, EventArgs e)
        {
            AddCocktailNewRowToGrid();
        }

        public bool CheckBrandSaleDuplicateData()
        {
            return true;
        }

        public bool CheckCocktailSaleDuplicateData()
        {
            return true;
        }

        protected void btn_Add_Brand_Cocktail_Sale_Click(object sender, EventArgs e)
        {
            if (ddlCocktail.SelectedIndex == 0)
            {
                Insert_Brand_Size_Sale_Grid();
            }
            else if (ddlBrand.SelectedIndex == 0 && (ddlSize.SelectedIndex == -1 || ddlSize.SelectedIndex == 0))
            {
                Insert_Cocktail_Sale_Grid();
            }
            else if (ddlCocktail.SelectedIndex == 0 && ddlBrand.SelectedIndex == 0 && ddlSize.SelectedIndex == 0)
            {
                //Import
            }
        }

        protected void Insert_Brand_Size_Sale_Grid()
        {
            try
            {
                if (ddlLicense.SelectedIndex != 0 && grdBrandLinkup.Rows.Count > 0 && !string.IsNullOrEmpty(txtBrandDate.Text))
                {
                    //Check Brand Sale Duplicate Data
                    bool brandDuplicate = CheckBrandSaleDuplicateData();
                    bool displayMessage = false;

                    if (brandDuplicate)
                    {
                        //Add Sale Data in Temporary Datatable
                        DataTable dtInsertSaleData = new DataTable();
                        dtInsertSaleData.Columns.Add("Opening_ID");
                        dtInsertSaleData.Columns.Add("getClosingBottle");
                        dtInsertSaleData.Columns.Add("getClosingSpeg");

                        //Add Sale Details Data in Temporary Datatable
                        DataTable dtInsertSaleDetailsData = new DataTable();
                        dtInsertSaleDetailsData.Columns.Add("Brand_Name");
                        dtInsertSaleDetailsData.Columns.Add("Size_Desc");
                        dtInsertSaleDetailsData.Columns.Add("Cocktail_Desc");
                        dtInsertSaleDetailsData.Columns.Add("Opening_ID");
                        dtInsertSaleDetailsData.Columns.Add("Tax_Type");
                        dtInsertSaleDetailsData.Columns.Add("Bottle_Qty");
                        dtInsertSaleDetailsData.Columns.Add("Bottle_Rate");
                        dtInsertSaleDetailsData.Columns.Add("SPeg_Qty");
                        dtInsertSaleDetailsData.Columns.Add("Speg_Rate");
                        dtInsertSaleDetailsData.Columns.Add("LPeg_Qty");
                        dtInsertSaleDetailsData.Columns.Add("LPeg_Rate");
                        dtInsertSaleDetailsData.Columns.Add("TaxAmount");
                        dtInsertSaleDetailsData.Columns.Add("Amount");

                        foreach (GridViewRow row in grdBrandLinkup.Rows)
                        {
                            string Brand_Name = string.Empty;
                            string Size_Desc = string.Empty;
                            string Cocktail_Desc = string.Empty;
                            int Opening_ID = 0;
                            string Tax_Type = string.Empty;
                            decimal Bottle_Qty = 0;
                            decimal Bottle_Rate = 0;
                            decimal SPeg_Qty = 0;
                            decimal Speg_Rate = 0;
                            decimal LPeg_Qty = 0;
                            decimal LPeg_Rate = 0;
                            decimal TaxAmount = 0;
                            decimal Amount = 0;
                            int Permit_Holder = 0;
                            for (int i = 0; i < grdBrandLinkup.Columns.Count; i++)
                            {
                                string header = grdBrandLinkup.Columns[i].HeaderText;
                                string cellText = row.Cells[i].Text;
                                if (row.FindControl("Brand") == null && header == "Brand")
                                {
                                    Brand_Name = cellText;
                                    DataSet dsGetBrandId = new DataSet();
                                    dsGetBrandId = ObjCocktailWorld.Fetch_Brand_Opening(0, 0, 0, Brand_Name, "", CompanyID);
                                    if (dsGetBrandId.Tables[0].Rows.Count > 0)
                                    {
                                        Opening_ID = Convert.ToInt32(dsGetBrandId.Tables[0].Rows[0]["Opening_ID"]);
                                        DataSet dsGetTax = new DataSet();
                                        dsGetTax = ObjCocktailWorld.FetchTaxDetails(Convert.ToInt32(dsGetBrandId.Tables[0].Rows[0]["Brand_ID"]));
                                        if (dsGetTax.Tables[0].Rows.Count > 0)
                                            Tax_Type = dsGetTax.Tables[0].Rows[0].ItemArray[1].ToString();
                                    }
                                    else
                                    {
                                        Opening_ID = 0;
                                        Tax_Type = "";
                                    }
                                }

                                if (row.FindControl("Size") == null && header == "Size")
                                {
                                    Size_Desc = cellText;
                                }

                                if (!string.IsNullOrEmpty(row.FindControl("txtbottleqty").ToString()) && header == "Bottle Qty")
                                {
                                    if (!string.IsNullOrEmpty((row.FindControl("txtbottleqty") as TextBox).Text))
                                        Bottle_Qty = Convert.ToDecimal((row.FindControl("txtbottleqty") as TextBox).Text);
                                    else
                                        Bottle_Qty = 0;
                                }

                                if (!string.IsNullOrEmpty(row.FindControl("txtbottlerate").ToString()) && header == "Bottle Rate")
                                {
                                    if (!string.IsNullOrEmpty((row.FindControl("txtbottlerate") as TextBox).Text))
                                        Bottle_Rate = Convert.ToDecimal((row.FindControl("txtbottlerate") as TextBox).Text);
                                    else
                                        Bottle_Rate = 0;
                                }

                                if (!string.IsNullOrEmpty(row.FindControl("txtspegqty").ToString()) && header == "SPeg Qty")
                                {
                                    if (!string.IsNullOrEmpty((row.FindControl("txtspegqty") as TextBox).Text))
                                        SPeg_Qty = Convert.ToDecimal((row.FindControl("txtspegqty") as TextBox).Text);
                                    else
                                        SPeg_Qty = 0;
                                }

                                if (!string.IsNullOrEmpty(row.FindControl("txtspegrate").ToString()) && header == "SPeg Rate")
                                {
                                    if (!string.IsNullOrEmpty((row.FindControl("txtspegrate") as TextBox).Text))
                                        Speg_Rate = Convert.ToDecimal((row.FindControl("txtspegrate") as TextBox).Text);
                                    else
                                        Speg_Rate = 0;
                                }

                                if (!string.IsNullOrEmpty(row.FindControl("txtlpegqty").ToString()) && header == "LPeg Qty")
                                {
                                    if (!string.IsNullOrEmpty((row.FindControl("txtlpegqty") as TextBox).Text))
                                        LPeg_Qty = Convert.ToDecimal((row.FindControl("txtlpegqty") as TextBox).Text);
                                    else
                                        LPeg_Qty = 0;
                                }

                                if (!string.IsNullOrEmpty(row.FindControl("txtlpegrate").ToString()) && header == "LPeg Rate")
                                {
                                    if (!string.IsNullOrEmpty((row.FindControl("txtlpegrate") as TextBox).Text))
                                        LPeg_Rate = Convert.ToDecimal((row.FindControl("txtlpegrate") as TextBox).Text);
                                    else
                                        LPeg_Rate = 0;
                                }

                                if (!string.IsNullOrEmpty(row.FindControl("txttotalamount").ToString()) && header == "Total Amount")
                                    Amount = (Bottle_Rate * Bottle_Qty) + (Speg_Rate * SPeg_Qty) + (LPeg_Qty * LPeg_Rate);

                                if (!string.IsNullOrEmpty(row.FindControl("txtamount").ToString()) && header == "Tax Amount")
                                    TaxAmount = Amount * Convert.ToInt32(Session["hdnTax"]) / 100;
                            }

                            //Get Calculation from Current Stock
                            if (Opening_ID == 0)
                            {
                                Page.ClientScript.RegisterHiddenField("Opening_ID", "Opening_ID");
                                break;
                            }
                            else
                            {
                                //Calculation Of Opening stock and Closing stock
                                decimal getCurrentBottle = 0;
                                decimal getCurrentsPeg = 0;

                                decimal getClosingBottle = 0;
                                decimal getClosingSpeg = 0;

                                DataSet dsFetchBrand = new DataSet();
                                dsFetchBrand = ObjCocktailWorld.FetchBrandSizeLinkup(0, 0, 0, Brand_Name, Size_Desc, CompanyID);
                                if (dsFetchBrand.Tables[0].Rows.Count > 0)
                                {
                                    getCurrentBottle = Convert.ToInt32(dsFetchBrand.Tables[0].Rows[0].ItemArray[0]);
                                    getCurrentsPeg = Convert.ToInt32(dsFetchBrand.Tables[0].Rows[0].ItemArray[1]);

                                    getClosingBottle = getCurrentBottle - Bottle_Qty;
                                    getClosingSpeg = getCurrentsPeg - SPeg_Qty;

                                    if (getClosingSpeg >= 0 && getClosingBottle >= 0)
                                    {
                                        //Add Sale Data in Row 
                                        DataRow drInsertSaleData = dtInsertSaleData.NewRow();
                                        drInsertSaleData["Opening_ID"] = Opening_ID;
                                        drInsertSaleData["getClosingBottle"] = getClosingBottle;
                                        drInsertSaleData["getClosingSpeg"] = getClosingSpeg;
                                        dtInsertSaleData.Rows.Add(drInsertSaleData);

                                        //Add Sale Details Data in Row 
                                        DataRow drInsertSaleDetailsData = dtInsertSaleDetailsData.NewRow();
                                        drInsertSaleDetailsData["Brand_Name"] = Brand_Name;
                                        drInsertSaleDetailsData["Size_Desc"] = Size_Desc;
                                        drInsertSaleDetailsData["Cocktail_Desc"] = Cocktail_Desc;
                                        drInsertSaleDetailsData["Opening_ID"] = Opening_ID;
                                        drInsertSaleDetailsData["Tax_Type"] = Tax_Type;
                                        drInsertSaleDetailsData["Bottle_Qty"] = Bottle_Qty;
                                        drInsertSaleDetailsData["Bottle_Rate"] = Bottle_Rate;
                                        drInsertSaleDetailsData["SPeg_Qty"] = SPeg_Qty;
                                        drInsertSaleDetailsData["Speg_Rate"] = Speg_Rate;
                                        drInsertSaleDetailsData["LPeg_Qty"] = LPeg_Qty;
                                        drInsertSaleDetailsData["LPeg_Rate"] = LPeg_Rate;
                                        drInsertSaleDetailsData["TaxAmount"] = TaxAmount;
                                        drInsertSaleDetailsData["Amount"] = Amount;
                                        dtInsertSaleDetailsData.Rows.Add(drInsertSaleDetailsData);
                                    }
                                    else
                                    {
                                        string message = "Negative stock found in : Brand : " + Brand_Name + " And Size : " + Size_Desc + " With Bottle : " + getCurrentBottle + " and Speg : " + getCurrentsPeg;
                                        Page.ClientScript.RegisterHiddenField("Negative", message);
                                        displayMessage = false;
                                        break;
                                    }
                                }
                                else
                                {
                                    Page.ClientScript.RegisterHiddenField("BS_QTY", "BS_QTY");
                                }
                            }
                        }

                        if (grdBrandLinkup.Rows.Count > 0 && dtInsertSaleData.Rows.Count > 0 && dtInsertSaleDetailsData.Rows.Count > 0 && (grdBrandLinkup.Rows.Count == dtInsertSaleData.Rows.Count))
                        {
                            //Insert Operation for Brand Sale
                            DataSet dsBrandSale = new DataSet();
                            dsBrandSale = ObjCocktailWorld.SaleMaster_Crud(0, txtBrandDate.Text, string.Empty, Convert.ToInt32(ddlLicense.SelectedValue), "Insert", Convert.ToInt32(LoggedInUserID), CompanyID);

                            for (int i = 0; i < dtInsertSaleData.Rows.Count; i++)
                            {
                                DataSet dsUpdateOpeningData = new DataSet();
                                dsUpdateOpeningData = ObjCocktailWorld.BrandOpeningMaster_CRUD(Convert.ToInt32(dtInsertSaleData.Rows[i]["Opening_ID"]), string.Empty, 0,
                                   Convert.ToDecimal(dtInsertSaleData.Rows[i]["getClosingBottle"]), Convert.ToDecimal(dtInsertSaleData.Rows[i]["getClosingSpeg"]), CompanyID, LoggedInUserID, "UpdateStock");

                                if (dsUpdateOpeningData.Tables[0].Rows.Count > 0)
                                {
                                    ObjCocktailWorld.SaleDetailsMaster_Crud(Convert.ToInt32(dsBrandSale.Tables[0].Rows[0]["Sale_ID"]), 0, Convert.ToString(dtInsertSaleDetailsData.Rows[i]["Brand_Name"]),
                                        Convert.ToString(dtInsertSaleDetailsData.Rows[i]["Size_Desc"]), Convert.ToString(dtInsertSaleDetailsData.Rows[i]["Cocktail_Desc"]),
                                        Convert.ToInt32(dtInsertSaleDetailsData.Rows[i]["Opening_ID"]),
                                        Convert.ToString(dtInsertSaleDetailsData.Rows[i]["Tax_Type"]), Convert.ToDecimal(dtInsertSaleDetailsData.Rows[i]["Bottle_Qty"]),
                                        Convert.ToDecimal(dtInsertSaleDetailsData.Rows[i]["Bottle_Rate"]), Convert.ToDecimal(dtInsertSaleDetailsData.Rows[i]["SPeg_Qty"]),
                                        Convert.ToDecimal(dtInsertSaleDetailsData.Rows[i]["Speg_Rate"]), Convert.ToDecimal(dtInsertSaleDetailsData.Rows[i]["LPeg_Qty"]),
                                        Convert.ToDecimal(dtInsertSaleDetailsData.Rows[i]["LPeg_Rate"]), Convert.ToDecimal(dtInsertSaleDetailsData.Rows[i]["TaxAmount"]),
                                        Convert.ToDecimal(dtInsertSaleDetailsData.Rows[i]["Amount"]), Convert.ToInt32(dtInsertSaleDetailsData.Rows[i]["Permit_Holder"]),
                                        Convert.ToInt32(ddlLicense.SelectedValue), "Insert", Convert.ToInt32(LoggedInUserID), CompanyID);
                                    displayMessage = true;
                                }
                            }
                        }

                        if (displayMessage)
                            Response.Redirect("~/Cocktail_World/Transactions/Sales.aspx");
                    }
                    else
                    {
                        Page.ClientScript.RegisterHiddenField("Duplicate", "Duplicate");
                    }
                }
                else
                {
                    Page.ClientScript.RegisterHiddenField("License", "License");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Insert_Cocktail_Sale_Grid()
        {
            try
            {
                if (ddlLicense.SelectedIndex != 0 && grdCocktail.Rows.Count > 0 && !string.IsNullOrEmpty(txtCocktailDate.Text) && !string.IsNullOrEmpty(CocktailBill.Text))
                {
                    //Check Cocktail Sale Duplicate Data
                    bool cocktailDuplicate = CheckCocktailSaleDuplicateData();
                    bool displayMessage = false;
                    if (cocktailDuplicate)
                    {
                        //Add Sale Data in Temporary Datatable
                        DataTable dtInsertSaleData = new DataTable();
                        dtInsertSaleData.Columns.Add("Opening_ID");
                        dtInsertSaleData.Columns.Add("getClosingBottle");
                        dtInsertSaleData.Columns.Add("getClosingSpeg");

                        //Add Sale Details Data in Temporary Datatable
                        DataTable dtInsertSaleDetailsData = new DataTable();
                        dtInsertSaleDetailsData.Columns.Add("Brand_Name");
                        dtInsertSaleDetailsData.Columns.Add("Size_Desc");
                        dtInsertSaleDetailsData.Columns.Add("Cocktail_Desc");
                        dtInsertSaleDetailsData.Columns.Add("Opening_ID");
                        dtInsertSaleDetailsData.Columns.Add("Tax_Type");
                        dtInsertSaleDetailsData.Columns.Add("Bottle_Qty");
                        dtInsertSaleDetailsData.Columns.Add("Bottle_Rate");
                        dtInsertSaleDetailsData.Columns.Add("SPeg_Qty");
                        dtInsertSaleDetailsData.Columns.Add("Speg_Rate");
                        dtInsertSaleDetailsData.Columns.Add("LPeg_Qty");
                        dtInsertSaleDetailsData.Columns.Add("LPeg_Rate");
                        dtInsertSaleDetailsData.Columns.Add("TaxAmount");
                        dtInsertSaleDetailsData.Columns.Add("Amount");

                        foreach (GridViewRow row in grdCocktail.Rows)

                        {
                            string Cocktail_Desc = string.Empty;
                            string Brand_Name = string.Empty;
                            string Size_Desc = string.Empty;
                            int Opening_ID = 0;
                            string Tax_Type = string.Empty;
                            decimal Bottle_Qty = 0;
                            decimal Bottle_Rate = 0;
                            decimal SPeg_Qty = 0;
                            decimal Speg_Rate = 0;
                            decimal LPeg_Qty = 0;
                            decimal LPeg_Rate = 0;
                            decimal TaxAmount = 0;
                            decimal Amount = 0;
                            int Permit_Holder = 0;
                            for (int i = 0; i < grdCocktail.Columns.Count; i++)
                            {
                                string header = grdCocktail.Columns[i].HeaderText;
                                string cellText = row.Cells[i].Text;
                                if (row.FindControl("Cocktail_Desc") == null && header == "Cocktail")
                                {
                                    Cocktail_Desc = cellText;
                                    DataSet dsGetBrandId = new DataSet();
                                    dsGetBrandId = ObjCocktailWorld.Fetch_Brand_Opening(0, 0, 0, "", Cocktail_Desc, CompanyID);
                                    if (dsGetBrandId.Tables[0].Rows.Count > 0)
                                    {
                                        Opening_ID = Convert.ToInt32(dsGetBrandId.Tables[0].Rows[0]["Opening_ID"]);
                                        DataSet dsGetTax = new DataSet();
                                        dsGetTax = ObjCocktailWorld.FetchTaxDetails(Convert.ToInt32(dsGetBrandId.Tables[0].Rows[0]["Brand_ID"]));
                                        if (dsGetTax.Tables[0].Rows.Count > 0)
                                            Tax_Type = dsGetTax.Tables[0].Rows[0].ItemArray[1].ToString();
                                    }
                                    else
                                    {
                                        Opening_ID = 0;
                                        Tax_Type = "";
                                    }
                                }

                                if (!string.IsNullOrEmpty(row.FindControl("cocktailqty").ToString()) && header == "Bottle Qty")
                                {
                                    if (!string.IsNullOrEmpty((row.FindControl("cocktailqty") as TextBox).Text))
                                        Bottle_Qty = Convert.ToDecimal((row.FindControl("cocktailqty") as TextBox).Text);
                                    else
                                        Bottle_Qty = 0;
                                }

                                if (!string.IsNullOrEmpty(row.FindControl("cocktailrate").ToString()) && header == "Bottle Rate")
                                {
                                    if (!string.IsNullOrEmpty((row.FindControl("cocktailrate") as TextBox).Text))
                                        Bottle_Rate = Convert.ToDecimal((row.FindControl("cocktailrate") as TextBox).Text);
                                    else
                                        Bottle_Rate = 0;
                                }

                                if (!string.IsNullOrEmpty(row.FindControl("cocktailtotalamount").ToString()) && header == "Total Amount")
                                    Amount = (Bottle_Rate * Bottle_Qty);

                                if (!string.IsNullOrEmpty(row.FindControl("cocktailamount").ToString()) && header == "Tax Amount")
                                    TaxAmount = Amount * Convert.ToInt32(Session["hdnCocktailTax"]) / 100;
                            }

                            //Get Calculation from Current Stock
                            if (Opening_ID == 0)
                            {
                                Page.ClientScript.RegisterHiddenField("Opening_ID", "Opening_ID");
                                break;
                            }
                            else
                            {
                                //Calculation Of Opening stock and Closing stock
                                decimal getCurrentBottle = 0;
                                decimal getCurrentsPeg = 0;

                                decimal getClosingBottle = 0;
                                decimal getClosingSpeg = 0;


                                DataSet dsFetchBrand = new DataSet();
                                dsFetchBrand = ObjCocktailWorld.Fetch_Brand_Opening(0, 0, 0, "", Cocktail_Desc, CompanyID);
                                if (dsFetchBrand.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < dsFetchBrand.Tables[0].Rows.Count; i++)
                                    {
                                        getCurrentBottle = Convert.ToInt32(dsFetchBrand.Tables[0].Rows[i]["Bottle_Qty"]);
                                        getCurrentsPeg = Convert.ToInt32(dsFetchBrand.Tables[0].Rows[i]["SPeg_Qty"]);

                                        getClosingBottle = getCurrentBottle - Bottle_Qty;
                                        getClosingSpeg = getCurrentsPeg - SPeg_Qty;

                                        if (getClosingSpeg >= 0 && getClosingBottle >= 0)
                                        {
                                            //Add Sale Data in Row 
                                            DataRow drInsertSaleData = dtInsertSaleData.NewRow();
                                            drInsertSaleData["Opening_ID"] = Opening_ID;
                                            drInsertSaleData["getClosingBottle"] = getClosingBottle;
                                            drInsertSaleData["getClosingSpeg"] = getClosingSpeg;
                                            dtInsertSaleData.Rows.Add(drInsertSaleData);

                                            //Add Sale Details Data in Row 
                                            DataRow drInsertSaleDetailsData = dtInsertSaleDetailsData.NewRow();
                                            drInsertSaleDetailsData["Brand_Name"] = Brand_Name;
                                            drInsertSaleDetailsData["Size_Desc"] = Size_Desc;
                                            drInsertSaleDetailsData["Cocktail_Desc"] = Cocktail_Desc;
                                            drInsertSaleDetailsData["Opening_ID"] = Convert.ToInt32(dsFetchBrand.Tables[0].Rows[i]["Opening_ID"]);
                                            drInsertSaleDetailsData["Tax_Type"] = Tax_Type;
                                            drInsertSaleDetailsData["Bottle_Qty"] = Bottle_Qty;
                                            drInsertSaleDetailsData["Bottle_Rate"] = Bottle_Rate;
                                            drInsertSaleDetailsData["SPeg_Qty"] = SPeg_Qty;
                                            drInsertSaleDetailsData["Speg_Rate"] = Speg_Rate;
                                            drInsertSaleDetailsData["LPeg_Qty"] = LPeg_Qty;
                                            drInsertSaleDetailsData["LPeg_Rate"] = LPeg_Rate;
                                            drInsertSaleDetailsData["TaxAmount"] = TaxAmount;
                                            drInsertSaleDetailsData["Amount"] = Amount;
                                            dtInsertSaleDetailsData.Rows.Add(drInsertSaleDetailsData);
                                        }
                                        else
                                        {

                                            string message = "Negative stock found in : Brand : " + Brand_Name + " And Size : " + Size_Desc + " With Bottle : " + getCurrentBottle + " and Speg : " + getCurrentsPeg;
                                            Page.ClientScript.RegisterHiddenField("Negative", message);
                                            displayMessage = false;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    Page.ClientScript.RegisterHiddenField("BS_QTY", "BS_QTY");
                                }
                            }
                        }

                        if (grdBrandLinkup.Rows.Count > 0 && dtInsertSaleData.Rows.Count > 0 && dtInsertSaleDetailsData.Rows.Count > 0 && (grdBrandLinkup.Rows.Count <= dtInsertSaleData.Rows.Count))
                        {
                            //Insert Operation for Cocktail Sale
                            DataSet dsCocktailSale = new DataSet();
                            dsCocktailSale = ObjCocktailWorld.SaleMaster_Crud(0, txtCocktailDate.Text, CocktailBill.Text, ddlLicense.SelectedIndex, "Insert", Convert.ToInt32(LoggedInUserID), CompanyID);
                            for (int i = 0; i < dtInsertSaleData.Rows.Count; i++)
                            {
                                DataSet dsUpdateOpeningData = new DataSet();
                                //dsUpdateOpeningData = ObjCocktailWorld.BrandOpeningMaster_CRUD(Convert.ToInt32(dtInsertSaleData.Rows[i]["Opening_ID"]),
                                //    Convert.ToDecimal(dtInsertSaleData.Rows[i]["getClosingBottle"]), Convert.ToDecimal(dtInsertSaleData.Rows[i]["getClosingSpeg"]), "Update", Convert.ToInt32(LoggedInUserID), CompanyID);

                                if (dsUpdateOpeningData.Tables[0].Rows.Count > 0)
                                {
                                    ObjCocktailWorld.SaleDetailsMaster_Crud(Convert.ToInt32(dsCocktailSale.Tables[0].Rows[0]["Sale_ID"]), 0, Convert.ToString(dtInsertSaleDetailsData.Rows[i]["Brand_Name"]),
                                        Convert.ToString(dtInsertSaleDetailsData.Rows[i]["Size_Desc"]), Convert.ToString(dtInsertSaleDetailsData.Rows[i]["Cocktail_Desc"]),
                                        Convert.ToInt32(dtInsertSaleDetailsData.Rows[i]["Opening_ID"]),
                                        Convert.ToString(dtInsertSaleDetailsData.Rows[i]["Tax_Type"]), Convert.ToDecimal(dtInsertSaleDetailsData.Rows[i]["Bottle_Qty"]),
                                        Convert.ToDecimal(dtInsertSaleDetailsData.Rows[i]["Bottle_Rate"]), Convert.ToDecimal(dtInsertSaleDetailsData.Rows[i]["SPeg_Qty"]),
                                        Convert.ToDecimal(dtInsertSaleDetailsData.Rows[i]["Speg_Rate"]), Convert.ToDecimal(dtInsertSaleDetailsData.Rows[i]["LPeg_Qty"]),
                                        Convert.ToDecimal(dtInsertSaleDetailsData.Rows[i]["LPeg_Rate"]), Convert.ToDecimal(dtInsertSaleDetailsData.Rows[i]["TaxAmount"]),
                                        Convert.ToDecimal(dtInsertSaleDetailsData.Rows[i]["Amount"]), Convert.ToInt32(dtInsertSaleDetailsData.Rows[i]["Permit_Holder"]),
                                        ddlLicense.SelectedIndex, "Insert", Convert.ToInt32(LoggedInUserID), CompanyID);
                                    displayMessage = true;
                                }
                            }
                        }
                        if (displayMessage)
                            Response.Redirect("~/Cocktail_World/Transactions/Sales.aspx");
                    }
                    else
                    {
                        Page.ClientScript.RegisterHiddenField("Duplicate", "Duplicate");
                    }
                }
                else
                {
                    Page.ClientScript.RegisterHiddenField("License", "License");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlPermit_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList drp = (DropDownList)sender;
            GridViewRow gv = (GridViewRow)drp.NamingContainer;
            int index = gv.RowIndex;
            DataTable dt = ViewState["Brands"] as DataTable;
            dt.AcceptChanges();
            ViewState["Brands"] = dt;
        }
    }
}