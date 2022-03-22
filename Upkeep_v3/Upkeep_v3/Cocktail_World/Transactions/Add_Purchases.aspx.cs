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
    public partial class Add_Purchases : System.Web.UI.Page
    {
        CocktailWorld_Service.CocktailWorld_Service ObjCocktailWorld = new CocktailWorld_Service.CocktailWorld_Service();

        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            txtPurchaseDate.Text = DateTime.Now.ToString("dd-MMMM-yyyy");
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            if (!IsPostBack)
            {
                Fetch_License();
                Fetch_Supplier();
                SetPurchaseInitialRow();

                #region Edit and Delete Sale
                int Purchase_ID = Convert.ToInt32(Request.QueryString["Purchase_ID"]);
                int DelPurchase_ID = Convert.ToInt32(Request.QueryString["DelPurchase_ID"]);
                if (Purchase_ID > 0)
                {
                    Bind_PurchaseMaster(Purchase_ID);
                }
                if (DelPurchase_ID > 0)
                {
                    Delete_PurchaseMaster(DelPurchase_ID);
                }
                #endregion
            }
        }

        public void Bind_PurchaseMaster(int Purchase_ID)
        {
            try
            {
                DataSet dsPurchase = new DataSet();
                dsPurchase = ObjCocktailWorld.PurchaseMaster_CRUD(Purchase_ID, 0, string.Empty, string.Empty, string.Empty, 0, 0, 0, CompanyID, LoggedInUserID, "R");

                DataSet dsPurchaseDetail = new DataSet();
                dsPurchaseDetail = ObjCocktailWorld.PurchaseDetailsMaster_CRUD(Purchase_ID, 0, string.Empty, string.Empty, 0, 0, 0, 0, 0, 0, 0, string.Empty, string.Empty, 0, 0, 0, CompanyID, LoggedInUserID, "R");

                if (dsPurchase.Tables.Count > 0)
                {
                    if (dsPurchase.Tables[0].Rows.Count > 0)
                    {
                        DateTime purchaseDate = Convert.ToDateTime(dsPurchase.Tables[0].Rows[0]["Purchase_Date"]);
                        txtPurchaseDate.Text = purchaseDate.ToString("dd-MMMM-yyyy");
                        txttpnumber.Text = Convert.ToString(dsPurchase.Tables[0].Rows[0]["TP_No"]);
                        txtinvoicenumber.Text = Convert.ToString(dsPurchase.Tables[0].Rows[0]["Invoice_No"]);
                        txtdiscount.Text = Convert.ToString(dsPurchase.Tables[0].Rows[0]["Discount_Percentage"]);
                        txttotalcharges.Text = Convert.ToString(dsPurchase.Tables[0].Rows[0]["Other_Charges"]);
                        string txtLicen = Convert.ToString(dsPurchase.Tables[0].Rows[0]["License_Name"]);
                        string txtSupplier = Convert.ToString(dsPurchase.Tables[0].Rows[0]["Supplier_Name"]);

                        Fetch_License();
                        ddlLicense.ClearSelection(); //making sure the previous selection has been cleared
                        ddlLicense.Items.FindByText(txtLicen).Selected = true;

                        Fetch_Supplier();
                        ddlSupplier.ClearSelection(); //making sure the previous selection has been cleared
                        ddlSupplier.Items.FindByText(txtSupplier).Selected = true;

                        DataRow drCurrentRow = null;
                        DataTable dtCurrentTable = new DataTable();

                        dtCurrentTable.Columns.Add("Brand", typeof(String));
                        dtCurrentTable.Columns.Add("Size", typeof(String));
                        dtCurrentTable.Columns.Add("sPegQty", typeof(String));
                        dtCurrentTable.Columns.Add("sPegRate", typeof(String));
                        dtCurrentTable.Columns.Add("MfgDate", typeof(String));
                        dtCurrentTable.Columns.Add("BatchNo", typeof(String));
                        dtCurrentTable.Columns.Add("Boxes", typeof(String));
                        dtCurrentTable.Columns.Add("Bottle_Qty", typeof(String));
                        dtCurrentTable.Columns.Add("Bottle_Rate", typeof(String));
                        dtCurrentTable.Columns.Add("Total_Amount", typeof(String));
                        dtCurrentTable.Columns.Add("Tax_Amount", typeof(String));
                        dtCurrentTable.Columns.Add("Stock", typeof(String));

                        dsPurchaseDetail.Tables[0].Columns.Add("Stock", typeof(String));

                        if (ViewState["Purchase"] != null)
                        {
                            for (int i = 0; i < dsPurchaseDetail.Tables[0].Rows.Count; i++)
                            {
                                drCurrentRow = dtCurrentTable.NewRow();
                                drCurrentRow["Brand"] = dsPurchaseDetail.Tables[0].Rows[i]["Brand_Desc"].ToString();
                                drCurrentRow["Size"] = dsPurchaseDetail.Tables[0].Rows[i]["Size_Desc"].ToString();
                                drCurrentRow["sPegQty"] = dsPurchaseDetail.Tables[0].Rows[i]["SPeg_Qty"].ToString();
                                drCurrentRow["sPegRate"] = dsPurchaseDetail.Tables[0].Rows[i]["SPeg_Rate"].ToString();
                                drCurrentRow["MfgDate"] = dsPurchaseDetail.Tables[0].Rows[i]["Mfg"].ToString();
                                drCurrentRow["BatchNo"] = dsPurchaseDetail.Tables[0].Rows[i]["Batch_No"].ToString();
                                drCurrentRow["Boxes"] = dsPurchaseDetail.Tables[0].Rows[i]["No_Of_Boxes"].ToString();
                                drCurrentRow["Bottle_Qty"] = dsPurchaseDetail.Tables[0].Rows[i]["Bottle_Qty"].ToString();
                                drCurrentRow["Bottle_Rate"] = dsPurchaseDetail.Tables[0].Rows[i]["Bottle_Rate"].ToString();
                                drCurrentRow["Total_Amount"] = dsPurchaseDetail.Tables[0].Rows[i]["Total_Amt"].ToString();
                                drCurrentRow["Tax_Amount"] = dsPurchaseDetail.Tables[0].Rows[i]["Tax_Amt"].ToString();


                                DataSet dsGetStockDetails = new DataSet();
                                dsGetStockDetails = ObjCocktailWorld.FetchBrandSizeLinkup(0, 0, 0, dsPurchaseDetail.Tables[0].Rows[i]["Brand_Desc"].ToString(), dsPurchaseDetail.Tables[0].Rows[i]["Size_Desc"].ToString(), CompanyID, 0, string.Empty, DateTime.Now);
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
                            grdPurchase.DataSource = dtCurrentTable.Copy();
                            grdPurchase.DataBind();
                            DataTable dt = new DataTable();
                            dt = dtCurrentTable.Copy();
                            ViewState["Purchase"] = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Delete_PurchaseMaster(int Purchase_ID)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = ObjCocktailWorld.PurchaseMaster_CRUD(Purchase_ID, 0, string.Empty, string.Empty, string.Empty, 0, 0, 0, CompanyID, LoggedInUserID, "D");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataSet dsSD = new DataSet();
                        dsSD = ObjCocktailWorld.PurchaseDetailsMaster_CRUD(Purchase_ID, 0, string.Empty, string.Empty, 0, 0, 0, 0, 0, 0, 0, string.Empty, string.Empty, 0, 0, 0, CompanyID, LoggedInUserID, "D");

                        Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Transactions/Purchases.aspx"), false);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Fetch_Supplier()
        {
            ds = ObjCocktailWorld.SupplierMaster_CRUD(0, "", "", 0, "", "", "", "", LoggedInUserID, CompanyID, "Fetch");
            ddlSupplier.DataSource = ds.Tables[0];
            ddlSupplier.DataTextField = "Supplier_Name";
            ddlSupplier.DataValueField = "Supplier_ID";
            ddlSupplier.DataBind();
            ddlSupplier.Items.Insert(0, new ListItem("--Select Supplier--", "0"));
        }

        private void Fetch_License()
        {
            ds = ObjCocktailWorld.License_CRUD(0, string.Empty, string.Empty, LoggedInUserID, CompanyID, "R");
            ddlLicense.DataSource = ds.Tables[0];
            ddlLicense.DataTextField = "License_Name";
            ddlLicense.DataValueField = "License_ID";
            ddlLicense.DataBind();
            ddlLicense.Items.Insert(0, new ListItem("--Select License--", "0"));
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
                ds = ObjCocktailWorld.FetchBrandSizeLinkup(0, BrandID, Size_ID, "", "", CompanyID, Convert.ToInt32(ddlLicense.SelectedValue), "Purchase", Convert.ToDateTime(txtPurchaseDate.Text));
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

        private void SetPurchaseInitialRow()
        {
            try
            {
                ViewState["Purchase"] = null;

                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[]
                {
        new DataColumn("Brand", typeof(string)),
        new DataColumn("Size", typeof(string)),
        new DataColumn("Stock", typeof(string)),
        new DataColumn("sPegQty", typeof(string)),
        new DataColumn("sPegRate",typeof(string)),
        new DataColumn("MfgDate", typeof(string)),
        new DataColumn("BatchNo", typeof(string)),
        new DataColumn("Boxes", typeof(string)),
        new DataColumn("Bottle_Qty", typeof(string)),
        new DataColumn("Bottle_Rate", typeof(string)),
        new DataColumn("Total_Amount", typeof(string)),
        new DataColumn("Tax_Amount", typeof(string)),

                });

                DataRow drRow = dt.NewRow();
                drRow["Brand"] = string.Empty;
                drRow["Size"] = string.Empty;
                drRow["Stock"] = string.Empty;
                drRow["sPegQty"] = string.Empty;
                drRow["sPegRate"] = string.Empty;
                drRow["MfgDate"] = string.Empty;
                drRow["BatchNo"] = string.Empty;
                drRow["Boxes"] = string.Empty;
                drRow["Bottle_Qty"] = string.Empty;
                drRow["Bottle_Rate"] = string.Empty;
                drRow["Total_Amount"] = string.Empty;
                drRow["Tax_Amount"] = string.Empty;
                dt.Rows.Add(drRow);

                ViewState["Purchase"] = dt;
                grdPurchase.DataSource = ViewState["Purchase"];
                grdPurchase.DataBind();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AddPurchase_NewRowToGrid()
        {
            try
            {
                int rowIndex = 0;
                if (ViewState["Purchase"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["Purchase"];

                    DataRow drCurrentRow = null;

                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {
                            //extract the TextBox values  
                            TextBox txt1 = grdPurchase.Rows[rowIndex].FindControl("txtspegqty") as TextBox;
                            TextBox txt2 = grdPurchase.Rows[rowIndex].FindControl("txtspegrate") as TextBox;
                            TextBox txt3 = grdPurchase.Rows[rowIndex].FindControl("txtboxes") as TextBox;
                            TextBox txt4 = grdPurchase.Rows[rowIndex].FindControl("txtbatchno") as TextBox;
                            TextBox txt5 = grdPurchase.Rows[rowIndex].FindControl("txtmfgdate") as TextBox;
                            TextBox txt6 = grdPurchase.Rows[rowIndex].FindControl("txtbottleqty") as TextBox;
                            TextBox txt7 = grdPurchase.Rows[rowIndex].FindControl("txtbottlerate") as TextBox;
                            TextBox txt8 = grdPurchase.Rows[rowIndex].FindControl("txttotalamount") as TextBox;
                            TextBox txt9 = grdPurchase.Rows[rowIndex].FindControl("txtamount") as TextBox;

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
                            dtCurrentTable.Rows[i - 1]["Boxes"] = txt3.Text;
                            dtCurrentTable.Rows[i - 1]["BatchNo"] = txt4.Text;
                            dtCurrentTable.Rows[i - 1]["MfgDate"] = txt5.Text;
                            dtCurrentTable.Rows[i - 1]["Bottle_Qty"] = txt6.Text;
                            dtCurrentTable.Rows[i - 1]["Bottle_Rate"] = txt7.Text;
                            dtCurrentTable.Rows[i - 1]["Total_Amount"] = txt8.Text;
                            dtCurrentTable.Rows[i - 1]["Tax_Amount"] = txt9.Text;

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

                        ViewState["Purchase"] = dtCurrentTable;
                        grdPurchase.DataSource = dtCurrentTable;
                        grdPurchase.DataBind();
                    }
                }
                else
                {
                    Response.Write("ViewState is null");
                }

                //Set Previous Data on Postbacks
                SetPreviousPurchaseData();
                ddlBrand.ClearSelection();
                ddlSize.ClearSelection();
                lbl_stock.Text = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetPreviousPurchaseData()
        {
            try
            {
                int rowIndex = 0;
                if (ViewState["Purchase"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["Purchase"];
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {
                            TextBox txt1 = grdPurchase.Rows[rowIndex].FindControl("txtspegqty") as TextBox;
                            TextBox txt2 = grdPurchase.Rows[rowIndex].FindControl("txtspegrate") as TextBox;
                            TextBox txt3 = grdPurchase.Rows[rowIndex].FindControl("txtboxes") as TextBox;
                            TextBox txt4 = grdPurchase.Rows[rowIndex].FindControl("txtbatchno") as TextBox;
                            TextBox txt5 = grdPurchase.Rows[rowIndex].FindControl("txtmfgdate") as TextBox;
                            TextBox txt6 = grdPurchase.Rows[rowIndex].FindControl("txtbottleqty") as TextBox;
                            TextBox txt7 = grdPurchase.Rows[rowIndex].FindControl("txtbottlerate") as TextBox;
                            TextBox txt8 = grdPurchase.Rows[rowIndex].FindControl("txttotalamount") as TextBox;
                            TextBox txt9 = grdPurchase.Rows[rowIndex].FindControl("txtamount") as TextBox;

                            txt1.Text = dtCurrentTable.Rows[i]["sPegQty"].ToString();
                            txt2.Text = dtCurrentTable.Rows[i]["sPegRate"].ToString();
                            txt3.Text = dtCurrentTable.Rows[i]["Boxes"].ToString();
                            txt4.Text = dtCurrentTable.Rows[i]["BatchNo"].ToString();
                            txt5.Text = dtCurrentTable.Rows[i]["MfgDate"].ToString();
                            txt6.Text = dtCurrentTable.Rows[i]["Bottle_Qty"].ToString();
                            txt7.Text = dtCurrentTable.Rows[i]["Bottle_Rate"].ToString();
                            txt8.Text = dtCurrentTable.Rows[i]["Total_Amount"].ToString();
                            txt9.Text = dtCurrentTable.Rows[i]["Tax_Amount"].ToString();
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

        protected void BindPurchaseGrid()
        {
            grdPurchase.DataSource = (DataTable)ViewState["Purchase"];
            grdPurchase.DataBind();
        }

        protected void Purchase_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    foreach (LinkButton button in e.Row.Cells[0].Controls.OfType<LinkButton>())
                    {
                        if (button.CommandName == "Delete")
                        {
                            button.Attributes["onclick"] = "if(!confirm('Are You Sure Want To Remove ?')){ return false; };";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void Purchase_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = ViewState["Purchase"] as DataTable;
            dt.Rows[index].Delete();
            dt.AcceptChanges();
            ViewState["Purchase"] = dt;
            BindPurchaseGrid();
            if (index == 0)
            {
                SetPurchaseInitialRow();
            }
        }

        protected void Purchase_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPurchase.PageIndex = e.NewPageIndex;
            BindPurchaseGrid();
        }

        protected void btn_AddPurchase_Click(object sender, EventArgs e)
        {
            AddPurchase_NewRowToGrid();
        }

        public bool Check_Purchase_DuplicateData()
        {
            DataSet dsGetPurchase = new DataSet();
            dsGetPurchase = ObjCocktailWorld.PurchaseMaster_CRUD(0, Convert.ToInt32(ddlSupplier.SelectedValue), txttpnumber.Text, txtinvoicenumber.Text, txtPurchaseDate.Text, !string.IsNullOrEmpty(txttotalcharges.Text) ? Convert.ToDecimal(txttotalcharges.Text) : 0, !string.IsNullOrEmpty(txtdiscount.Text) ? Convert.ToDecimal(txtdiscount.Text) : 0, ddlLicense.SelectedIndex, CompanyID, LoggedInUserID, "Duplicate");
            if (dsGetPurchase.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        protected void btn_Add_Purchase_Click(object sender, EventArgs e)
        {
            if (ddlSupplier.SelectedIndex > 0)
            {
                Insert_Purchase_Data();
            }
            else if (ddlSupplier.SelectedIndex == 0)
            {
                //Excel
            }
        }

        protected void Insert_Purchase_Data()
        {
            try
            {
                bool hasvalue = false;
                DataTable dt = new DataTable();
                dt.Columns.Add("Brand");
                DataRow dr = dt.NewRow();

                foreach (GridViewRow row in grdPurchase.Rows)
                {
                    dr["Brand"] = row.Cells[1].Text.Replace("&nbsp;", "");
                }
                dt.Rows.Add(dr);

                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[0]["Brand"].ToString()))
                        hasvalue = true;
                }


                if (hasvalue)
                {
                    if (ddlLicense.SelectedIndex != 0 && grdPurchase.Rows.Count > 0 && !string.IsNullOrEmpty(txtPurchaseDate.Text) && !string.IsNullOrEmpty(txttpnumber.Text) && ddlSupplier.SelectedIndex != 0)
                    {
                        //Check Brand Sale Duplicate Data
                        bool purchaseDuplicate = Check_Purchase_DuplicateData();
                        bool displayMessage = false;
                        bool checkamount = false;

                        if (!purchaseDuplicate)
                        {
                            //Add Sale Data in Temporary Datatable
                            DataTable dtInsertPurchaseData = new DataTable();
                            dtInsertPurchaseData.Columns.Add("Opening_ID");
                            dtInsertPurchaseData.Columns.Add("getClosingBottle");
                            dtInsertPurchaseData.Columns.Add("getClosingSpeg");

                            //Add Sale Details Data in Temporary Datatable
                            DataTable dtInsertPurchaseDetailsData = new DataTable();
                            dtInsertPurchaseDetailsData.Columns.Add("Brand_Name");
                            dtInsertPurchaseDetailsData.Columns.Add("Size_Desc");
                            dtInsertPurchaseDetailsData.Columns.Add("Opening_ID");
                            dtInsertPurchaseDetailsData.Columns.Add("Tax_Type");
                            dtInsertPurchaseDetailsData.Columns.Add("Bottle_Qty");
                            dtInsertPurchaseDetailsData.Columns.Add("Bottle_Rate");
                            dtInsertPurchaseDetailsData.Columns.Add("SPeg_Qty");
                            dtInsertPurchaseDetailsData.Columns.Add("Speg_Rate");
                            dtInsertPurchaseDetailsData.Columns.Add("Boxes");
                            dtInsertPurchaseDetailsData.Columns.Add("BatchNo");
                            dtInsertPurchaseDetailsData.Columns.Add("MfgDate");
                            dtInsertPurchaseDetailsData.Columns.Add("TaxAmount");
                            dtInsertPurchaseDetailsData.Columns.Add("Amount");

                            foreach (GridViewRow row in grdPurchase.Rows)
                            {
                                string Brand_Name = string.Empty;
                                string Size_Desc = string.Empty;
                                int Opening_ID = 0;
                                string Tax_Type = string.Empty;
                                decimal Bottle_Qty = 0;
                                decimal Bottle_Rate = 0;
                                decimal SPeg_Qty = 0;
                                decimal Speg_Rate = 0;
                                int Boxes = 0;
                                int BatchNo = 0;
                                string MfgDate = string.Empty;
                                decimal TaxAmount = 0;
                                decimal Amount = 0;
                                for (int i = 0; i < grdPurchase.Columns.Count; i++)
                                {
                                    string header = grdPurchase.Columns[i].HeaderText;
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

                                    if (!string.IsNullOrEmpty(row.FindControl("txtboxes").ToString()) && header == "Boxes")
                                    {
                                        if (!string.IsNullOrEmpty((row.FindControl("txtboxes") as TextBox).Text))
                                            Boxes = Convert.ToInt32((row.FindControl("txtboxes") as TextBox).Text);
                                        else
                                            Boxes = 0;
                                    }

                                    if (!string.IsNullOrEmpty(row.FindControl("txtbatchno").ToString()) && header == "Batch No")
                                    {
                                        if (!string.IsNullOrEmpty((row.FindControl("txtbatchno") as TextBox).Text))
                                            BatchNo = Convert.ToInt32((row.FindControl("txtbatchno") as TextBox).Text);
                                        else
                                            BatchNo = 0;
                                    }

                                    if (!string.IsNullOrEmpty(row.FindControl("txtmfgdate").ToString()) && header == "Mfg Date")
                                    {
                                        if (!string.IsNullOrEmpty((row.FindControl("txtmfgdate") as TextBox).Text))
                                            MfgDate = Convert.ToString((row.FindControl("txtmfgdate") as TextBox).Text);
                                        else
                                            MfgDate = string.Empty;
                                    }

                                    if (!string.IsNullOrEmpty(row.FindControl("txttotalamount").ToString()) && header == "Total Amount")
                                    {
                                        Amount = (Bottle_Rate * Bottle_Qty) + (Speg_Rate * SPeg_Qty);
                                        if (Amount == 0)
                                        {
                                            checkamount = true;
                                            break;
                                        }
                                    }

                                    if (!string.IsNullOrEmpty(row.FindControl("txtamount").ToString()) && header == "Tax Amount")
                                        TaxAmount = Amount * Convert.ToInt32(Session["hdnTax"]) / 100;

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
                                    decimal getClosingBottle = 0;
                                    decimal getClosingSpeg = 0;

                                    //Add Purchase Data in Row 
                                    DataRow drInsertPurchaseData = dtInsertPurchaseData.NewRow();
                                    drInsertPurchaseData["Opening_ID"] = Opening_ID;
                                    drInsertPurchaseData["getClosingBottle"] = getClosingBottle;
                                    drInsertPurchaseData["getClosingSpeg"] = getClosingSpeg;
                                    dtInsertPurchaseData.Rows.Add(drInsertPurchaseData);

                                    //Add Purchase Details Data in Row 
                                    DataRow drInsertPurchaseDetailsData = dtInsertPurchaseDetailsData.NewRow();
                                    drInsertPurchaseDetailsData["Brand_Name"] = Brand_Name;
                                    drInsertPurchaseDetailsData["Size_Desc"] = Size_Desc;
                                    drInsertPurchaseDetailsData["Opening_ID"] = Opening_ID;
                                    drInsertPurchaseDetailsData["Tax_Type"] = Tax_Type;
                                    drInsertPurchaseDetailsData["Bottle_Qty"] = Bottle_Qty;
                                    drInsertPurchaseDetailsData["Bottle_Rate"] = Bottle_Rate;
                                    drInsertPurchaseDetailsData["SPeg_Qty"] = SPeg_Qty;
                                    drInsertPurchaseDetailsData["Speg_Rate"] = Speg_Rate;
                                    drInsertPurchaseDetailsData["Boxes"] = Boxes;
                                    drInsertPurchaseDetailsData["BatchNo"] = BatchNo;
                                    drInsertPurchaseDetailsData["MfgDate"] = MfgDate;
                                    drInsertPurchaseDetailsData["TaxAmount"] = TaxAmount;
                                    drInsertPurchaseDetailsData["Amount"] = Amount;
                                    dtInsertPurchaseDetailsData.Rows.Add(drInsertPurchaseDetailsData);
                                }
                            }

                            if (!checkamount)
                            {
                                if (grdPurchase.Rows.Count > 0 && dtInsertPurchaseData.Rows.Count > 0 && dtInsertPurchaseDetailsData.Rows.Count > 0 && (grdPurchase.Rows.Count == dtInsertPurchaseData.Rows.Count))
                                {
                                    //Insert Operation for Purchase Data
                                    DataSet dsPurchase = new DataSet();
                                    dsPurchase = ObjCocktailWorld.PurchaseMaster_CRUD(0, Convert.ToInt32(ddlSupplier.SelectedValue), txttpnumber.Text, txtinvoicenumber.Text, txtPurchaseDate.Text, !string.IsNullOrEmpty(txttotalcharges.Text) ? Convert.ToDecimal(txttotalcharges.Text) : 0, !string.IsNullOrEmpty(txtdiscount.Text) ? Convert.ToDecimal(txtdiscount.Text) : 0, Convert.ToInt32(ddlLicense.SelectedValue), CompanyID, LoggedInUserID, "Insert");

                                    for (int i = 0; i < dtInsertPurchaseData.Rows.Count; i++)
                                    {
                                        ObjCocktailWorld.PurchaseDetailsMaster_CRUD(Convert.ToInt32(dsPurchase.Tables[0].Rows[0]["Purchase_ID"]),
                                            Convert.ToInt32(dtInsertPurchaseDetailsData.Rows[i]["Opening_ID"]),
                                            Convert.ToString(dtInsertPurchaseDetailsData.Rows[i]["Brand_Name"]),
                                            Convert.ToString(dtInsertPurchaseDetailsData.Rows[i]["Size_Desc"]),
                                            Convert.ToDecimal(dtInsertPurchaseDetailsData.Rows[i]["Bottle_Qty"]),
                                            Convert.ToDecimal(dtInsertPurchaseDetailsData.Rows[i]["Bottle_Rate"]),
                                            Convert.ToDecimal(dtInsertPurchaseDetailsData.Rows[i]["SPeg_Qty"]),
                                            Convert.ToDecimal(dtInsertPurchaseDetailsData.Rows[i]["Speg_Rate"]),
                                            0,
                                            Convert.ToInt32(dtInsertPurchaseDetailsData.Rows[i]["Boxes"]),
                                            Convert.ToInt32(dtInsertPurchaseDetailsData.Rows[i]["BatchNo"]),
                                            Convert.ToString(dtInsertPurchaseDetailsData.Rows[i]["MfgDate"]),
                                            Convert.ToString(dtInsertPurchaseDetailsData.Rows[i]["Tax_Type"]),
                                             Convert.ToDecimal(dtInsertPurchaseDetailsData.Rows[i]["TaxAmount"]),
                                              Convert.ToDecimal(dtInsertPurchaseDetailsData.Rows[i]["Amount"]),
                                              Convert.ToInt32(ddlLicense.SelectedValue)
                                            , CompanyID, LoggedInUserID, "Insert");
                                        displayMessage = true;
                                    }
                                }

                                if (displayMessage)
                                    Page.ClientScript.RegisterHiddenField("Redirect", "Redirect");
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
                else
                {
                    Page.ClientScript.RegisterHiddenField("hasvalue", "hasvalue");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        protected void ddlLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fetch_Brand_Size(true);
        }
    }
}