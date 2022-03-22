using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Upkeep_v3.Cocktail_World.Transactions
{
    public partial class Add_Auto_Billing : System.Web.UI.Page
    {
        CocktailWorld_Service.CocktailWorld_Service ObjCocktailWorld = new CocktailWorld_Service.CocktailWorld_Service();
        public static CocktailWorld_Service.CocktailWorld_Service ObjCocktailWorld1 = new CocktailWorld_Service.CocktailWorld_Service();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;


        [System.Web.Services.WebMethod]
        public static void GetCount(string item)
        {
            DataSet BillDetails = HttpContext.Current.Session["BillDetails"] as DataSet;
            string BrandDate = HttpContext.Current.Session["BrandDate"] as string;
            string License = HttpContext.Current.Session["License"] as string;
            string Company = HttpContext.Current.Session["CompanyID"] as string;
            string User = HttpContext.Current.Session["User"] as string;

            for (int i = 0; i < BillDetails.Tables[1].Rows.Count; i++)
            {
                DataSet dsBrandSale = new DataSet();
                dsBrandSale = ObjCocktailWorld1.SaleMaster_Crud(0, BrandDate, BillDetails.Tables[1].Rows[i]["Bill_No"].ToString(), Convert.ToInt32(License), "Insert", Convert.ToInt32(User), Convert.ToInt32(Company), true);

                for (int x = 0; x < BillDetails.Tables[2].Rows.Count; x++)
                {
                    if (BillDetails.Tables[1].Rows[i]["Sale_ID"].ToString() == BillDetails.Tables[2].Rows[x]["Sale_ID"].ToString())
                    {
                        ObjCocktailWorld1.SaleDetailsMaster_Crud(Convert.ToInt32(dsBrandSale.Tables[0].Rows[0]["Sale_ID"]), 0, Convert.ToString(BillDetails.Tables[2].Rows[x]["Brand_Name"]),
                        Convert.ToString(BillDetails.Tables[2].Rows[x]["Size_Desc"]), Convert.ToString(BillDetails.Tables[2].Rows[x]["Cocktail_Desc"]),
                        Convert.ToInt32(BillDetails.Tables[2].Rows[x]["Opening_ID"]),
                        Convert.ToString(BillDetails.Tables[2].Rows[x]["Tax_Type"]), Convert.ToDecimal(BillDetails.Tables[2].Rows[x]["Bottle_Qty"]),
                        Convert.ToDecimal(BillDetails.Tables[2].Rows[x]["Bottle_Rate"]), Convert.ToDecimal(BillDetails.Tables[2].Rows[x]["SPeg_Qty"]),
                        Convert.ToDecimal(BillDetails.Tables[2].Rows[x]["Speg_Rate"]), Convert.ToDecimal(BillDetails.Tables[2].Rows[x]["LPeg_Qty"]),
                        Convert.ToDecimal(BillDetails.Tables[2].Rows[x]["LPeg_Rate"]), Convert.ToDecimal(BillDetails.Tables[2].Rows[x]["TaxAmount"]),
                        Convert.ToDecimal(BillDetails.Tables[2].Rows[x]["Amount"]), GetRandomPermitHolder1(User, Company),
                        Convert.ToInt32(License), "Insert", Convert.ToInt32(User), Convert.ToInt32(Company));
                    }
                }
            }
        }

        public static int GetRandomPermitHolder1(string User, string Company)
        {
            int id = 0;
            DataSet ds = new DataSet();
            ds = ObjCocktailWorld1.PermitMaster_CRUD(0, string.Empty, string.Empty, string.Empty, string.Empty, false, User, Convert.ToInt32(Company), "Random");
            if (ds.Tables[0].Rows.Count > 0)
            {
                id = Convert.ToInt32(ds.Tables[0].Rows[0]["Permit_ID"]);
            }
            return id;
        }

        // Instantiate random number generator.  
        private readonly Random _random = new Random();

        // Generates a random number within a range.      
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            txtBrandDate.Text = DateTime.Now.ToString("dd-MMMM-yyyy");
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            if (!IsPostBack)
            {
                Fetch_License();
                SetBrandInitialRow();
                Fetch_CocktailName();
                SetCocktailInitialRow();

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
                dsSale = ObjCocktailWorld.SaleMaster_Crud(Sale_ID, string.Empty, string.Empty, 0, "Fetch", Convert.ToInt32(LoggedInUserID), CompanyID, true);

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
                                dsGetStockDetails = ObjCocktailWorld.FetchBrandSizeLinkup(0, 0, 0, dsSaleDetail.Tables[0].Rows[i]["Brand_Desc"].ToString(), dsSaleDetail.Tables[0].Rows[i]["Size_Desc"].ToString(), CompanyID, 0, string.Empty, DateTime.Now);
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
                ds = ObjCocktailWorld.SaleMaster_Crud(Sale_ID, string.Empty, string.Empty, 0, "D", Convert.ToInt32(LoggedInUserID), CompanyID, true);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataSet dsSD = new DataSet();
                        dsSD = ObjCocktailWorld.SaleDetailsMaster_Crud(Sale_ID, 0, string.Empty, string.Empty, string.Empty, 0, string.Empty, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "Delete", Convert.ToInt32(LoggedInUserID), CompanyID);

                        Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Transactions/Auto_Billing.aspx"), false);
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
                ds = ObjCocktailWorld.FetchBrandSizeLinkup(0, BrandID, Size_ID, "", "", CompanyID, Convert.ToInt32(ddlLicense.SelectedValue), "Sale", Convert.ToDateTime(txtBrandDate.Text));
            else
                ds = null;
            return ds;
        }

        private void Fetch_Brand_Size(bool chk)
        {
            int BrandID, Size_ID = 0;
            Session.Remove("hdnTax");
            Session["hdnTax"] = null;

            if (chk)
            {
                ddlBrand.SelectedIndex = -1;
                ddlSize.SelectedIndex = -1;
            }

            if (!string.IsNullOrEmpty(ddlBrand.SelectedValue))
                BrandID = Convert.ToInt32(ddlBrand.SelectedValue);
            else
                BrandID = 0;

            try
            {
                ds = ObjCocktailWorld.FetchBrandSizeLinkup(0, BrandID, Size_ID, "", "", CompanyID, Convert.ToInt32(ddlLicense.SelectedValue), string.Empty, DateTime.Now);

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
            Fetch_Brand_Size(false);
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
                string stock = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                string displayStock = "Available Stock :- " + stock;
                lbl_stock.Text = displayStock;
            }
        }

        private void Fetch_CocktailName()
        {
            Session.Remove("hdnCocktailTax");
            Session["hdnCocktailTax"] = null;

            ds = ObjCocktailWorld.CocktailMaster_CRUD(0, "", "", CompanyID, "", 0, "Fetch");
            ddlCocktail.DataSource = ds.Tables[0];
            ddlCocktail.DataTextField = "Cocktail_Desc";
            ddlCocktail.DataValueField = "Cocktail_ID";
            ddlCocktail.DataBind();
            ddlCocktail.Items.Insert(0, new ListItem("--Select Cocktail--", "0"));

            if (ddlCocktail.SelectedIndex > 0)
            {
                DataSet dsGetBrandId = new DataSet();
                dsGetBrandId = ObjCocktailWorld.Fetch_Brand_Opening(0, 0, 0, "", "", ddlCocktail.SelectedValue, CompanyID, string.Empty);
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
            dsPermit = ObjCocktailWorld.PermitMaster_CRUD(0, string.Empty, string.Empty, string.Empty, string.Empty, false, LoggedInUserID, CompanyID, "SELECT");

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
                                string stock = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                                drCurrentRow["Stock"] = stock;
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
                ddlBrand.ClearSelection();
                ddlSize.ClearSelection();
                lbl_stock.Text = string.Empty;
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
            if (ddlSize.SelectedIndex == 0)
            {
                Insert_Brand_Size_Sale_Grid();
            }
            else if (ddlSize.SelectedIndex == -1)
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
                    bool checkamount = false;

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
                            for (int i = 0; i < grdBrandLinkup.Columns.Count; i++)
                            {
                                string header = grdBrandLinkup.Columns[i].HeaderText;
                                string cellText = row.Cells[i].Text;
                                if (row.FindControl("Brand") == null && header == "Brand")
                                {
                                    Brand_Name = cellText;
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
                                {
                                    Amount = (Bottle_Rate * Bottle_Qty) + (Speg_Rate * SPeg_Qty) + (LPeg_Qty * LPeg_Rate);
                                    if (Amount == 0)
                                    {
                                        checkamount = true;
                                        break;
                                    }
                                }

                                if (!string.IsNullOrEmpty(row.FindControl("txtamount").ToString()) && header == "Tax Amount")
                                    TaxAmount = Amount;

                                if (!string.IsNullOrEmpty(Brand_Name) && !string.IsNullOrEmpty(Size_Desc))
                                {
                                    DataSet dsGetBrandId = new DataSet();
                                    dsGetBrandId = ObjCocktailWorld.Fetch_Brand_Opening(0, 0, 0, Brand_Name, Size_Desc, "", CompanyID, Convert.ToString(ddlLicense.SelectedValue));
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
                                dsFetchBrand = ObjCocktailWorld.FetchBrandSizeLinkup(0, 0, 0, Brand_Name, Size_Desc, CompanyID, Convert.ToInt32(ddlLicense.SelectedValue), "Sale", Convert.ToDateTime(txtBrandDate.Text));

                                if (dsFetchBrand.Tables[0].Rows.Count > 0)
                                {
                                    getCurrentBottle = Convert.ToInt32(dsFetchBrand.Tables[0].Rows[0].ItemArray[2]);
                                    getCurrentsPeg = Convert.ToInt32(dsFetchBrand.Tables[0].Rows[0].ItemArray[3]);

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

                        if (!checkamount)
                        {
                            if (grdBrandLinkup.Rows.Count > 0 && dtInsertSaleData.Rows.Count > 0 && dtInsertSaleDetailsData.Rows.Count > 0 && (grdBrandLinkup.Rows.Count == dtInsertSaleData.Rows.Count))
                            {
                                DataSet getAutoBillData = GetAutoBillingBrandCount(dtInsertSaleDetailsData, txtBillAmount.Text.Trim());
                                Session.Add("BillDetails", getAutoBillData);
                                Session.Add("BrandDate", txtBrandDate.Text);
                                Session.Add("License", ddlLicense.SelectedValue);
                                Session.Add("User", LoggedInUserID);
                                Page.ClientScript.RegisterHiddenField("BillDataDetails", getAutoBillData.Tables[0].Rows[0]["Bill_Count"].ToString());
                            }

                            if (displayMessage)
                                Response.Redirect("~/Cocktail_World/Transactions/Auto_Billing.aspx");
                        }
                        else
                        {
                            Page.ClientScript.RegisterHiddenField("CheckAmount", "CheckAmount");
                        }
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

        public DataSet GetAutoBillingBrandCount(DataTable dt, string splitnumber)
        {
            DataSet ds = new DataSet();
            DataTable brand = BindBrandGridView();
            DataTable dtxml = new DataTable();
            int vRange = Convert.ToInt32(splitnumber);
            int Sale_ID = 1;
            int vBillNo = 0;
            DataSet dsBillMaster = ObjCocktailWorld.BillBook_Crud(0, string.Empty, string.Empty, ddlLicense.SelectedValue, "Fetch", LoggedInUserID, CompanyID);

            DataTable resultCount = ds.Tables.Add("billCount");
            resultCount.Columns.Add("Bill_Count");

            DataTable dtInsertSaleData = ds.Tables.Add("Bill_Data");
            dtInsertSaleData.Columns.Add("Sale_ID");
            dtInsertSaleData.Columns.Add("Bill_No");

            #region Generate Bottle Bills
            for (var index = 0; index <= dt.Rows.Count - 1; index++)
            {
                if (Convert.ToInt32(dt.Rows[index]["Bottle_Qty"]) == 0)
                    continue;
                double vSum = Convert.ToDouble(dt.Rows[index]["Bottle_Rate"]);
                dtxml = BindXMLBrandGridView();
                dtxml.Rows.Add(Sale_ID, dt.Rows[index]["Brand_Name"], dt.Rows[index]["Size_Desc"], dt.Rows[index]["Cocktail_Desc"], dt.Rows[index]["Opening_ID"], dt.Rows[index]["Tax_Type"],
                   dt.Rows[index]["Bottle_Qty"], vSum, 0, 0, 0, 0, 0, dt.Rows[index]["Amount"]);

                if (Convert.ToInt32(dt.Rows[index]["Bottle_Qty"]) == 1)
                {
                    DataRow drInsertSaleDetailsData1 = brand.NewRow();
                    drInsertSaleDetailsData1["Sale_ID"] = Sale_ID;
                    drInsertSaleDetailsData1["Brand_Name"] = dt.Rows[0]["Brand_Name"];
                    drInsertSaleDetailsData1["Size_Desc"] = dt.Rows[0]["Size_Desc"];
                    drInsertSaleDetailsData1["Cocktail_Desc"] = dt.Rows[0]["Cocktail_Desc"];
                    drInsertSaleDetailsData1["Opening_ID"] = dt.Rows[0]["Opening_ID"];
                    drInsertSaleDetailsData1["Tax_Type"] = dt.Rows[0]["Tax_Type"];
                    drInsertSaleDetailsData1["Bottle_Qty"] = dtxml.Rows.Count;
                    drInsertSaleDetailsData1["Bottle_Rate"] = dt.Rows[0]["Bottle_Rate"];
                    drInsertSaleDetailsData1["SPeg_Qty"] = 0;
                    drInsertSaleDetailsData1["Speg_Rate"] = 0;
                    drInsertSaleDetailsData1["LPeg_Qty"] = 0;
                    drInsertSaleDetailsData1["LPeg_Rate"] = 0;
                    drInsertSaleDetailsData1["TaxAmount"] = 0;
                    drInsertSaleDetailsData1["Amount"] = dtxml.Rows.Count * Convert.ToInt32(dt.Rows[0]["Bottle_Rate"]);
                    brand.Rows.Add(drInsertSaleDetailsData1);


                    #region Bill ID Generate
                    int random_No = RandomNumber(Convert.ToInt32(dsBillMaster.Tables[0].Rows[0]["Bill_Start_No"]), Convert.ToInt32(dsBillMaster.Tables[0].Rows[0]["Bill_End_No"]));

                    DataRow drInsertSaleData = dtInsertSaleData.NewRow();
                    drInsertSaleData["Sale_ID"] = Sale_ID;
                    drInsertSaleData["Bill_No"] = random_No;
                    dtInsertSaleData.Rows.Add(drInsertSaleData);
                    #endregion

                    vBillNo += 1;
                    Sale_ID += 1;
                    continue;
                }

                for (var inCtr = 2; inCtr <= Convert.ToInt32(dt.Rows[index]["Bottle_Qty"]); inCtr++)
                {
                    vSum += Convert.ToDouble(dt.Rows[index]["Bottle_Rate"]);
                    if (vSum > vRange)
                    {
                        DataRow drInsertSaleDetailsData1 = brand.NewRow();
                        drInsertSaleDetailsData1["Sale_ID"] = Sale_ID;
                        drInsertSaleDetailsData1["Brand_Name"] = dtxml.Rows[0]["Brand_Name"];
                        drInsertSaleDetailsData1["Size_Desc"] = dtxml.Rows[0]["Size_Desc"];
                        drInsertSaleDetailsData1["Cocktail_Desc"] = dtxml.Rows[0]["Cocktail_Desc"];
                        drInsertSaleDetailsData1["Opening_ID"] = dtxml.Rows[0]["Opening_ID"];
                        drInsertSaleDetailsData1["Tax_Type"] = dtxml.Rows[0]["Tax_Type"];
                        drInsertSaleDetailsData1["Bottle_Qty"] = dtxml.Rows.Count;
                        drInsertSaleDetailsData1["Bottle_Rate"] = dtxml.Rows[0]["Bottle_Rate"];
                        drInsertSaleDetailsData1["SPeg_Qty"] = 0;
                        drInsertSaleDetailsData1["Speg_Rate"] = 0;
                        drInsertSaleDetailsData1["LPeg_Qty"] = 0;
                        drInsertSaleDetailsData1["LPeg_Rate"] = 0;
                        drInsertSaleDetailsData1["TaxAmount"] = 0;
                        drInsertSaleDetailsData1["Amount"] = dtxml.Rows.Count * Convert.ToInt32(dtxml.Rows[0]["Bottle_Rate"]);
                        brand.Rows.Add(drInsertSaleDetailsData1);



                        #region Bill ID Generate
                        int random_No1 = RandomNumber(Convert.ToInt32(dsBillMaster.Tables[0].Rows[0]["Bill_Start_No"]), Convert.ToInt32(dsBillMaster.Tables[0].Rows[0]["Bill_End_No"]));

                        DataRow drInsertSaleData1 = dtInsertSaleData.NewRow();
                        drInsertSaleData1["Sale_ID"] = Sale_ID;
                        drInsertSaleData1["Bill_No"] = random_No1;
                        dtInsertSaleData.Rows.Add(drInsertSaleData1);

                        #endregion

                        vBillNo += 1;
                        Sale_ID += 1;

                        DataRow drInsert = brand.NewRow();
                        vSum = Convert.ToDouble(dt.Rows[index]["Bottle_Rate"]);

                        dtxml = BindXMLBrandGridView();

                        dtxml.Rows.Add(Sale_ID, dt.Rows[index]["Brand_Name"], dt.Rows[index]["Size_Desc"], dt.Rows[index]["Cocktail_Desc"], dt.Rows[index]["Opening_ID"], dt.Rows[index]["Tax_Type"],
                           dt.Rows[index]["Bottle_Qty"], dt.Rows[index]["Bottle_Rate"], 0, 0, 0, 0, 0, dt.Rows[index]["Amount"]);

                        if (inCtr == Convert.ToInt32(dt.Rows[index]["Bottle_Qty"]))
                        {
                            DataRow drInsert1 = brand.NewRow();
                            drInsert1["Sale_ID"] = Sale_ID;
                            drInsert1["Brand_Name"] = dtxml.Rows[0]["Brand_Name"];
                            drInsert1["Size_Desc"] = dtxml.Rows[0]["Size_Desc"];
                            drInsert1["Cocktail_Desc"] = dtxml.Rows[0]["Cocktail_Desc"];
                            drInsert1["Opening_ID"] = dtxml.Rows[0]["Opening_ID"];
                            drInsert1["Tax_Type"] = dtxml.Rows[0]["Tax_Type"];
                            drInsert1["Bottle_Qty"] = dtxml.Rows.Count;
                            drInsert1["Bottle_Rate"] = dtxml.Rows[0]["Bottle_Rate"];
                            drInsert1["SPeg_Qty"] = 0;
                            drInsert1["Speg_Rate"] = 0;
                            drInsert1["LPeg_Qty"] = 0;
                            drInsert1["LPeg_Rate"] = 0;
                            drInsert1["TaxAmount"] = 0;
                            drInsert1["Amount"] = dtxml.Rows.Count * Convert.ToInt32(dtxml.Rows[0]["Bottle_Rate"]);
                            brand.Rows.Add(drInsert1);
                        }
                    }
                    else
                    {
                        dtxml.Rows.Add(Sale_ID, dt.Rows[index]["Brand_Name"], dt.Rows[index]["Size_Desc"], dt.Rows[index]["Cocktail_Desc"], dt.Rows[index]["Opening_ID"], dt.Rows[index]["Tax_Type"],
                           dt.Rows[index]["Bottle_Qty"], dt.Rows[index]["Bottle_Rate"], 0, 0, 0, 0, 0, dt.Rows[index]["Amount"]);


                        if (inCtr == Convert.ToInt32(dt.Rows[index]["Bottle_Qty"]))
                        {
                            DataRow drInsert11 = brand.NewRow();
                            drInsert11["Sale_ID"] = Sale_ID;
                            drInsert11["Brand_Name"] = dtxml.Rows[0]["Brand_Name"];
                            drInsert11["Size_Desc"] = dtxml.Rows[0]["Size_Desc"];
                            drInsert11["Cocktail_Desc"] = dtxml.Rows[0]["Cocktail_Desc"];
                            drInsert11["Opening_ID"] = dtxml.Rows[0]["Opening_ID"];
                            drInsert11["Tax_Type"] = dtxml.Rows[0]["Tax_Type"];
                            drInsert11["Bottle_Qty"] = dtxml.Rows.Count;
                            drInsert11["Bottle_Rate"] = dtxml.Rows[0]["Bottle_Rate"];
                            drInsert11["SPeg_Qty"] = 0;
                            drInsert11["Speg_Rate"] = 0;
                            drInsert11["LPeg_Qty"] = 0;
                            drInsert11["LPeg_Rate"] = 0;
                            drInsert11["TaxAmount"] = 0;
                            drInsert11["Amount"] = dtxml.Rows.Count * Convert.ToInt32(dtxml.Rows[0]["Bottle_Rate"]);
                            brand.Rows.Add(drInsert11);
                        }
                    }
                }

                #region Bill ID Generate
                int random_No2 = RandomNumber(Convert.ToInt32(dsBillMaster.Tables[0].Rows[0]["Bill_Start_No"]), Convert.ToInt32(dsBillMaster.Tables[0].Rows[0]["Bill_End_No"]));

                DataRow drInsertSaleData2 = dtInsertSaleData.NewRow();
                drInsertSaleData2["Sale_ID"] = Sale_ID;
                drInsertSaleData2["Bill_No"] = random_No2;
                dtInsertSaleData.Rows.Add(drInsertSaleData2);
                #endregion

                vBillNo += 1;
                Sale_ID += 1;
            }
            #endregion

            #region Generate Speg Bills
            for (var index = 0; index <= dt.Rows.Count - 1; index++)
            {
                if (Convert.ToInt32(dt.Rows[index]["SPeg_Qty"]) == 0)
                    continue;
                double vSum = Convert.ToDouble(dt.Rows[index]["Speg_Rate"]);
                dtxml = BindXMLBrandGridView();
                dtxml.Rows.Add(Sale_ID, dt.Rows[index]["Brand_Name"], dt.Rows[index]["Size_Desc"], dt.Rows[index]["Cocktail_Desc"], dt.Rows[index]["Opening_ID"], dt.Rows[index]["Tax_Type"], 0, 0,
                   dt.Rows[index]["SPeg_Qty"], vSum, 0, 0, 0, dt.Rows[index]["Amount"]);


                if (Convert.ToInt32(dt.Rows[index]["SPeg_Qty"]) == 1)
                {
                    DataRow drInsertSaleDetailsData1 = brand.NewRow();
                    drInsertSaleDetailsData1["Sale_ID"] = Sale_ID;
                    drInsertSaleDetailsData1["Brand_Name"] = dt.Rows[0]["Brand_Name"];
                    drInsertSaleDetailsData1["Size_Desc"] = dt.Rows[0]["Size_Desc"];
                    drInsertSaleDetailsData1["Cocktail_Desc"] = dt.Rows[0]["Cocktail_Desc"];
                    drInsertSaleDetailsData1["Opening_ID"] = dt.Rows[0]["Opening_ID"];
                    drInsertSaleDetailsData1["Tax_Type"] = dt.Rows[0]["Tax_Type"];
                    drInsertSaleDetailsData1["Bottle_Qty"] = 0;
                    drInsertSaleDetailsData1["Bottle_Rate"] = 0;
                    drInsertSaleDetailsData1["SPeg_Qty"] = dtxml.Rows.Count;
                    drInsertSaleDetailsData1["Speg_Rate"] = dt.Rows[0]["Speg_Rate"];
                    drInsertSaleDetailsData1["LPeg_Qty"] = 0;
                    drInsertSaleDetailsData1["LPeg_Rate"] = 0;
                    drInsertSaleDetailsData1["TaxAmount"] = 0;
                    drInsertSaleDetailsData1["Amount"] = dtxml.Rows.Count * Convert.ToInt32(dt.Rows[0]["Speg_Rate"]);
                    brand.Rows.Add(drInsertSaleDetailsData1);


                    #region Bill ID Generate
                    int random_No = RandomNumber(Convert.ToInt32(dsBillMaster.Tables[0].Rows[0]["Bill_Start_No"]), Convert.ToInt32(dsBillMaster.Tables[0].Rows[0]["Bill_End_No"]));

                    DataRow drInsertSaleData = dtInsertSaleData.NewRow();
                    drInsertSaleData["Sale_ID"] = Sale_ID;
                    drInsertSaleData["Bill_No"] = random_No;
                    dtInsertSaleData.Rows.Add(drInsertSaleData);
                    #endregion

                    vBillNo += 1;
                    Sale_ID += 1;
                    continue;
                }

                for (var inCtr = 2; inCtr <= Convert.ToInt32(dt.Rows[index]["SPeg_Qty"]); inCtr++)
                {
                    vSum += Convert.ToDouble(dt.Rows[index]["Speg_Rate"]);
                    if (vSum > vRange)
                    {
                        DataRow drInsertSaleDetailsData1 = brand.NewRow();
                        drInsertSaleDetailsData1["Sale_ID"] = Sale_ID;
                        drInsertSaleDetailsData1["Brand_Name"] = dtxml.Rows[0]["Brand_Name"];
                        drInsertSaleDetailsData1["Size_Desc"] = dtxml.Rows[0]["Size_Desc"];
                        drInsertSaleDetailsData1["Cocktail_Desc"] = dtxml.Rows[0]["Cocktail_Desc"];
                        drInsertSaleDetailsData1["Opening_ID"] = dtxml.Rows[0]["Opening_ID"];
                        drInsertSaleDetailsData1["Tax_Type"] = dtxml.Rows[0]["Tax_Type"];
                        drInsertSaleDetailsData1["Bottle_Qty"] = 0;
                        drInsertSaleDetailsData1["Bottle_Rate"] = 0;
                        drInsertSaleDetailsData1["SPeg_Qty"] = dtxml.Rows.Count;
                        drInsertSaleDetailsData1["Speg_Rate"] = dtxml.Rows[0]["Speg_Rate"];
                        drInsertSaleDetailsData1["LPeg_Qty"] = 0;
                        drInsertSaleDetailsData1["LPeg_Rate"] = 0;
                        drInsertSaleDetailsData1["TaxAmount"] = 0;
                        drInsertSaleDetailsData1["Amount"] = dtxml.Rows.Count * Convert.ToInt32(dtxml.Rows[0]["Speg_Rate"]);
                        brand.Rows.Add(drInsertSaleDetailsData1);



                        #region Bill ID Generate
                        int random_No1 = RandomNumber(Convert.ToInt32(dsBillMaster.Tables[0].Rows[0]["Bill_Start_No"]), Convert.ToInt32(dsBillMaster.Tables[0].Rows[0]["Bill_End_No"]));

                        DataRow drInsertSaleData1 = dtInsertSaleData.NewRow();
                        drInsertSaleData1["Sale_ID"] = Sale_ID;
                        drInsertSaleData1["Bill_No"] = random_No1;
                        dtInsertSaleData.Rows.Add(drInsertSaleData1);

                        #endregion

                        vBillNo += 1;
                        Sale_ID += 1;

                        DataRow drInsert = brand.NewRow();
                        vSum = Convert.ToDouble(dt.Rows[index]["Speg_Rate"]);

                        dtxml = BindXMLBrandGridView();

                        dtxml.Rows.Add(Sale_ID, dt.Rows[index]["Brand_Name"], dt.Rows[index]["Size_Desc"], dt.Rows[index]["Cocktail_Desc"], dt.Rows[index]["Opening_ID"], dt.Rows[index]["Tax_Type"], 0, 0,
                           dt.Rows[index]["SPeg_Qty"], dt.Rows[index]["Speg_Rate"], 0, 0, 0, dt.Rows[index]["Amount"]);

                        if (inCtr == Convert.ToInt32(dt.Rows[index]["SPeg_Qty"]))
                        {
                            DataRow drInsert1 = brand.NewRow();
                            drInsert1["Sale_ID"] = Sale_ID;
                            drInsert1["Brand_Name"] = dtxml.Rows[0]["Brand_Name"];
                            drInsert1["Size_Desc"] = dtxml.Rows[0]["Size_Desc"];
                            drInsert1["Cocktail_Desc"] = dtxml.Rows[0]["Cocktail_Desc"];
                            drInsert1["Opening_ID"] = dtxml.Rows[0]["Opening_ID"];
                            drInsert1["Tax_Type"] = dtxml.Rows[0]["Tax_Type"];
                            drInsert1["Bottle_Qty"] = 0;
                            drInsert1["Bottle_Rate"] = 0;
                            drInsert1["SPeg_Qty"] = dtxml.Rows.Count;
                            drInsert1["Speg_Rate"] = dtxml.Rows[0]["Speg_Rate"];
                            drInsert1["LPeg_Qty"] = 0;
                            drInsert1["LPeg_Rate"] = 0;
                            drInsert1["TaxAmount"] = 0;
                            drInsert1["Amount"] = dtxml.Rows.Count * Convert.ToInt32(dtxml.Rows[0]["Speg_Rate"]);
                            brand.Rows.Add(drInsert1);
                        }
                    }
                    else
                    {
                        dtxml.Rows.Add(Sale_ID, dt.Rows[index]["Brand_Name"], dt.Rows[index]["Size_Desc"], dt.Rows[index]["Cocktail_Desc"], dt.Rows[index]["Opening_ID"], dt.Rows[index]["Tax_Type"], 0, 0,
                           dt.Rows[index]["SPeg_Qty"], dt.Rows[index]["Speg_Rate"], 0, 0, 0, dt.Rows[index]["Amount"]);


                        if (inCtr == Convert.ToInt32(dt.Rows[index]["SPeg_Qty"]))
                        {
                            DataRow drInsert11 = brand.NewRow();
                            drInsert11["Sale_ID"] = Sale_ID;
                            drInsert11["Brand_Name"] = dtxml.Rows[0]["Brand_Name"];
                            drInsert11["Size_Desc"] = dtxml.Rows[0]["Size_Desc"];
                            drInsert11["Cocktail_Desc"] = dtxml.Rows[0]["Cocktail_Desc"];
                            drInsert11["Opening_ID"] = dtxml.Rows[0]["Opening_ID"];
                            drInsert11["Tax_Type"] = dtxml.Rows[0]["Tax_Type"];
                            drInsert11["Bottle_Qty"] = 0;
                            drInsert11["Bottle_Rate"] = 0;
                            drInsert11["SPeg_Qty"] = dtxml.Rows.Count;
                            drInsert11["Speg_Rate"] = dtxml.Rows[0]["Speg_Rate"];
                            drInsert11["LPeg_Qty"] = 0;
                            drInsert11["LPeg_Rate"] = 0;
                            drInsert11["TaxAmount"] = 0;
                            drInsert11["Amount"] = dtxml.Rows.Count * Convert.ToInt32(dtxml.Rows[0]["Speg_Rate"]);
                            brand.Rows.Add(drInsert11);
                        }
                    }
                }

                #region Bill ID Generate
                int random_No2 = RandomNumber(Convert.ToInt32(dsBillMaster.Tables[0].Rows[0]["Bill_Start_No"]), Convert.ToInt32(dsBillMaster.Tables[0].Rows[0]["Bill_End_No"]));

                DataRow drInsertSaleData2 = dtInsertSaleData.NewRow();
                drInsertSaleData2["Sale_ID"] = Sale_ID;
                drInsertSaleData2["Bill_No"] = random_No2;
                dtInsertSaleData.Rows.Add(drInsertSaleData2);
                #endregion

                vBillNo += 1;
                Sale_ID += 1;
            }
            #endregion

            #region Generate Lpeg Bills
            for (var index = 0; index <= dt.Rows.Count - 1; index++)
            {
                if (Convert.ToInt32(dt.Rows[index]["LPeg_Qty"]) == 0)
                    continue;
                double vSum = Convert.ToDouble(dt.Rows[index]["LPeg_Rate"]);
                dtxml = BindXMLBrandGridView();
                dtxml.Rows.Add(Sale_ID, dt.Rows[index]["Brand_Name"], dt.Rows[index]["Size_Desc"], dt.Rows[index]["Cocktail_Desc"], dt.Rows[index]["Opening_ID"], dt.Rows[index]["Tax_Type"], 0, 0, 0, 0,
                   dt.Rows[index]["LPeg_Qty"], vSum, 0, dt.Rows[index]["Amount"]);


                if (Convert.ToInt32(dt.Rows[index]["LPeg_Qty"]) == 1)
                {
                    DataRow drInsertSaleDetailsData1 = brand.NewRow();
                    drInsertSaleDetailsData1["Sale_ID"] = Sale_ID;
                    drInsertSaleDetailsData1["Brand_Name"] = dt.Rows[0]["Brand_Name"];
                    drInsertSaleDetailsData1["Size_Desc"] = dt.Rows[0]["Size_Desc"];
                    drInsertSaleDetailsData1["Cocktail_Desc"] = dt.Rows[0]["Cocktail_Desc"];
                    drInsertSaleDetailsData1["Opening_ID"] = dt.Rows[0]["Opening_ID"];
                    drInsertSaleDetailsData1["Tax_Type"] = dt.Rows[0]["Tax_Type"];
                    drInsertSaleDetailsData1["Bottle_Qty"] = 0;
                    drInsertSaleDetailsData1["Bottle_Rate"] = 0;
                    drInsertSaleDetailsData1["SPeg_Qty"] = 0;
                    drInsertSaleDetailsData1["Speg_Rate"] = 0;
                    drInsertSaleDetailsData1["LPeg_Qty"] = dtxml.Rows.Count;
                    drInsertSaleDetailsData1["LPeg_Rate"] = dt.Rows[0]["LPeg_Rate"];
                    drInsertSaleDetailsData1["TaxAmount"] = 0;
                    drInsertSaleDetailsData1["Amount"] = dtxml.Rows.Count * Convert.ToInt32(dt.Rows[0]["LPeg_Rate"]);
                    brand.Rows.Add(drInsertSaleDetailsData1);


                    #region Bill ID Generate
                    int random_No = RandomNumber(Convert.ToInt32(dsBillMaster.Tables[0].Rows[0]["Bill_Start_No"]), Convert.ToInt32(dsBillMaster.Tables[0].Rows[0]["Bill_End_No"]));

                    DataRow drInsertSaleData = dtInsertSaleData.NewRow();
                    drInsertSaleData["Sale_ID"] = Sale_ID;
                    drInsertSaleData["Bill_No"] = random_No;
                    dtInsertSaleData.Rows.Add(drInsertSaleData);
                    #endregion

                    vBillNo += 1;
                    Sale_ID += 1;
                    continue;
                }

                for (var inCtr = 2; inCtr <= Convert.ToInt32(dt.Rows[index]["LPeg_Qty"]); inCtr++)
                {
                    vSum += Convert.ToDouble(dt.Rows[index]["LPeg_Rate"]);
                    if (vSum > vRange)
                    {
                        DataRow drInsertSaleDetailsData1 = brand.NewRow();
                        drInsertSaleDetailsData1["Sale_ID"] = Sale_ID;
                        drInsertSaleDetailsData1["Brand_Name"] = dtxml.Rows[0]["Brand_Name"];
                        drInsertSaleDetailsData1["Size_Desc"] = dtxml.Rows[0]["Size_Desc"];
                        drInsertSaleDetailsData1["Cocktail_Desc"] = dtxml.Rows[0]["Cocktail_Desc"];
                        drInsertSaleDetailsData1["Opening_ID"] = dtxml.Rows[0]["Opening_ID"];
                        drInsertSaleDetailsData1["Tax_Type"] = dtxml.Rows[0]["Tax_Type"];
                        drInsertSaleDetailsData1["Bottle_Qty"] = 0;
                        drInsertSaleDetailsData1["Bottle_Rate"] = 0;
                        drInsertSaleDetailsData1["SPeg_Qty"] = 0;
                        drInsertSaleDetailsData1["Speg_Rate"] = 0;
                        drInsertSaleDetailsData1["LPeg_Qty"] = dtxml.Rows.Count;
                        drInsertSaleDetailsData1["LPeg_Rate"] = dtxml.Rows[0]["LPeg_Rate"];
                        drInsertSaleDetailsData1["TaxAmount"] = 0;
                        drInsertSaleDetailsData1["Amount"] = dtxml.Rows.Count * Convert.ToInt32(dtxml.Rows[0]["LPeg_Rate"]);
                        brand.Rows.Add(drInsertSaleDetailsData1);



                        #region Bill ID Generate
                        int random_No1 = RandomNumber(Convert.ToInt32(dsBillMaster.Tables[0].Rows[0]["Bill_Start_No"]), Convert.ToInt32(dsBillMaster.Tables[0].Rows[0]["Bill_End_No"]));

                        DataRow drInsertSaleData1 = dtInsertSaleData.NewRow();
                        drInsertSaleData1["Sale_ID"] = Sale_ID;
                        drInsertSaleData1["Bill_No"] = random_No1;
                        dtInsertSaleData.Rows.Add(drInsertSaleData1);

                        #endregion

                        vBillNo += 1;
                        Sale_ID += 1;

                        DataRow drInsert = brand.NewRow();
                        vSum = Convert.ToDouble(dt.Rows[index]["LPeg_Rate"]);

                        dtxml = BindXMLBrandGridView();

                        dtxml.Rows.Add(Sale_ID, dt.Rows[index]["Brand_Name"], dt.Rows[index]["Size_Desc"], dt.Rows[index]["Cocktail_Desc"], dt.Rows[index]["Opening_ID"], dt.Rows[index]["Tax_Type"], 0, 0, 0, 0,
                           dt.Rows[index]["LPeg_Qty"], dt.Rows[index]["LPeg_Rate"], 0, dt.Rows[index]["Amount"]);

                        if (inCtr == Convert.ToInt32(dt.Rows[index]["LPeg_Qty"]))
                        {
                            DataRow drInsert1 = brand.NewRow();
                            drInsert1["Sale_ID"] = Sale_ID;
                            drInsert1["Brand_Name"] = dtxml.Rows[0]["Brand_Name"];
                            drInsert1["Size_Desc"] = dtxml.Rows[0]["Size_Desc"];
                            drInsert1["Cocktail_Desc"] = dtxml.Rows[0]["Cocktail_Desc"];
                            drInsert1["Opening_ID"] = dtxml.Rows[0]["Opening_ID"];
                            drInsert1["Tax_Type"] = dtxml.Rows[0]["Tax_Type"];
                            drInsert1["Bottle_Qty"] = 0;
                            drInsert1["Bottle_Rate"] = 0;
                            drInsert1["SPeg_Qty"] = 0;
                            drInsert1["Speg_Rate"] = 0;
                            drInsert1["LPeg_Qty"] = dtxml.Rows.Count;
                            drInsert1["LPeg_Rate"] = dtxml.Rows[0]["LPeg_Rate"];
                            drInsert1["TaxAmount"] = 0;
                            drInsert1["Amount"] = dtxml.Rows.Count * Convert.ToInt32(dtxml.Rows[0]["LPeg_Rate"]);
                            brand.Rows.Add(drInsert1);
                        }
                    }
                    else
                    {
                        dtxml.Rows.Add(Sale_ID, dt.Rows[index]["Brand_Name"], dt.Rows[index]["Size_Desc"], dt.Rows[index]["Cocktail_Desc"], dt.Rows[index]["Opening_ID"], dt.Rows[index]["Tax_Type"], 0, 0, 0, 0,
                           dt.Rows[index]["LPeg_Qty"], dt.Rows[index]["LPeg_Rate"], 0, dt.Rows[index]["Amount"]);


                        if (inCtr == Convert.ToInt32(dt.Rows[index]["LPeg_Qty"]))
                        {
                            DataRow drInsert11 = brand.NewRow();
                            drInsert11["Sale_ID"] = Sale_ID;
                            drInsert11["Brand_Name"] = dtxml.Rows[0]["Brand_Name"];
                            drInsert11["Size_Desc"] = dtxml.Rows[0]["Size_Desc"];
                            drInsert11["Cocktail_Desc"] = dtxml.Rows[0]["Cocktail_Desc"];
                            drInsert11["Opening_ID"] = dtxml.Rows[0]["Opening_ID"];
                            drInsert11["Tax_Type"] = dtxml.Rows[0]["Tax_Type"];
                            drInsert11["Bottle_Qty"] = 0;
                            drInsert11["Bottle_Rate"] = 0;
                            drInsert11["SPeg_Qty"] = 0;
                            drInsert11["Speg_Rate"] = 0;
                            drInsert11["LPeg_Qty"] = dtxml.Rows.Count;
                            drInsert11["LPeg_Rate"] = dtxml.Rows[0]["LPeg_Rate"];
                            drInsert11["TaxAmount"] = 0;
                            drInsert11["Amount"] = dtxml.Rows.Count * Convert.ToInt32(dtxml.Rows[0]["LPeg_Rate"]);
                            brand.Rows.Add(drInsert11);
                        }
                    }
                }

                #region Bill ID Generate
                int random_No2 = RandomNumber(Convert.ToInt32(dsBillMaster.Tables[0].Rows[0]["Bill_Start_No"]), Convert.ToInt32(dsBillMaster.Tables[0].Rows[0]["Bill_End_No"]));

                DataRow drInsertSaleData2 = dtInsertSaleData.NewRow();
                drInsertSaleData2["Sale_ID"] = Sale_ID;
                drInsertSaleData2["Bill_No"] = random_No2;
                dtInsertSaleData.Rows.Add(drInsertSaleData2);
                #endregion

                vBillNo += 1;
                Sale_ID += 1;
            }
            #endregion

            #region Get Bill Count
            DataRow drbillCount = resultCount.NewRow();
            drbillCount["Bill_Count"] = Convert.ToInt32(vBillNo);
            resultCount.Rows.Add(drbillCount);
            #endregion

            ds.Tables.Add(brand.Copy());

            return ds;
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
                            for (int i = 0; i < grdCocktail.Columns.Count; i++)
                            {
                                string header = grdCocktail.Columns[i].HeaderText;
                                string cellText = row.Cells[i].Text;
                                if (row.FindControl("Cocktail_Desc") == null && header == "Cocktail")
                                {
                                    Cocktail_Desc = cellText;
                                    DataSet dsGetBrandId = new DataSet();
                                    dsGetBrandId = ObjCocktailWorld.Fetch_Brand_Opening(0, 0, 0, "", "", Cocktail_Desc, CompanyID, string.Empty);
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
                                dsFetchBrand = ObjCocktailWorld.Fetch_Brand_Opening(0, 0, 0, "", "", Cocktail_Desc, CompanyID, string.Empty);
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
                            dsCocktailSale = ObjCocktailWorld.SaleMaster_Crud(0, txtCocktailDate.Text, CocktailBill.Text, ddlLicense.SelectedIndex, "Insert", Convert.ToInt32(LoggedInUserID), CompanyID, true);
                            for (int i = 0; i < dtInsertSaleData.Rows.Count; i++)
                            {
                                ObjCocktailWorld.SaleDetailsMaster_Crud(Convert.ToInt32(dsCocktailSale.Tables[0].Rows[0]["Sale_ID"]), 0, Convert.ToString(dtInsertSaleDetailsData.Rows[i]["Brand_Name"]),
                                    Convert.ToString(dtInsertSaleDetailsData.Rows[i]["Size_Desc"]), Convert.ToString(dtInsertSaleDetailsData.Rows[i]["Cocktail_Desc"]),
                                    Convert.ToInt32(dtInsertSaleDetailsData.Rows[i]["Opening_ID"]),
                                    Convert.ToString(dtInsertSaleDetailsData.Rows[i]["Tax_Type"]), Convert.ToDecimal(dtInsertSaleDetailsData.Rows[i]["Bottle_Qty"]),
                                    Convert.ToDecimal(dtInsertSaleDetailsData.Rows[i]["Bottle_Rate"]), Convert.ToDecimal(dtInsertSaleDetailsData.Rows[i]["SPeg_Qty"]),
                                    Convert.ToDecimal(dtInsertSaleDetailsData.Rows[i]["Speg_Rate"]), Convert.ToDecimal(dtInsertSaleDetailsData.Rows[i]["LPeg_Qty"]),
                                    Convert.ToDecimal(dtInsertSaleDetailsData.Rows[i]["LPeg_Rate"]), Convert.ToDecimal(dtInsertSaleDetailsData.Rows[i]["TaxAmount"]),
                                    Convert.ToDecimal(dtInsertSaleDetailsData.Rows[i]["Amount"]), GetRandomPermitHolder(),
                                    ddlLicense.SelectedIndex, "Insert", Convert.ToInt32(LoggedInUserID), CompanyID);
                                displayMessage = true;
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

        private int GetRandomPermitHolder()
        {
            int id = 0;
            DataSet ds = new DataSet();
            ds = ObjCocktailWorld.PermitMaster_CRUD(0, string.Empty, string.Empty, string.Empty, string.Empty, false, LoggedInUserID, CompanyID, "Random");
            if (ds.Tables[0].Rows.Count > 0)
            {
                id = Convert.ToInt32(ds.Tables[0].Rows[0]["Permit_ID"]);
            }
            return id;
        }

        protected void ddlLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fetch_Brand_Size(true);
        }

        private DataTable BindBrandGridView()
        {
            DataTable dtInsertSaleDetailsData = new DataTable();
            dtInsertSaleDetailsData.Columns.Add("Sale_ID");
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
            return dtInsertSaleDetailsData;
        }

        private DataTable BindXMLBrandGridView()
        {
            DataTable dtInsertSaleDetailsData = new DataTable();
            dtInsertSaleDetailsData.Columns.Add("Sale_ID");
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
            return dtInsertSaleDetailsData;
        }


    }
}