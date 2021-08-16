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
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            if (!IsPostBack)
            {
                Fetch_License();
                Fetch_Supplier();
                Fetch_Brand_Size();
                SetPurchaseInitialRow();
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
            ds = ObjCocktailWorld.License(LoggedInUserID, CompanyID, "Fetch");
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

            //ObjCocktailWorld.SaleDetailsMaster_Crud(0, dt.Rows[index]["Brand"].ToString(), dt.Rows[index]["Size"].ToString(), "", 0, "",
            //  !string.IsNullOrEmpty(dt.Rows[index]["Bottle_Qty"].ToString()) ? Convert.ToDecimal(dt.Rows[index]["Bottle_Qty"]) : 0,
            //  !string.IsNullOrEmpty(dt.Rows[index]["Bottle_Rate"].ToString()) ? Convert.ToDecimal(dt.Rows[index]["Bottle_Rate"]) : 0,
            //  !string.IsNullOrEmpty(dt.Rows[index]["sPegQty"].ToString()) ? Convert.ToDecimal(dt.Rows[index]["sPegQty"]) : 0,
            //  !string.IsNullOrEmpty(dt.Rows[index]["sPegRate"].ToString()) ? Convert.ToDecimal(dt.Rows[index]["sPegRate"]) : 0,
            //  !string.IsNullOrEmpty(dt.Rows[index]["lPegQty"].ToString()) ? Convert.ToDecimal(dt.Rows[index]["lPegQty"]) : 0,
            //  !string.IsNullOrEmpty(dt.Rows[index]["lPegRate"].ToString()) ? Convert.ToDecimal(dt.Rows[index]["lPegRate"]) : 0,
            //  !string.IsNullOrEmpty(dt.Rows[index]["Total_Amount"].ToString()) ? Convert.ToDecimal(dt.Rows[index]["Total_Amount"]) : 0,
            //  !string.IsNullOrEmpty(dt.Rows[index]["Tax_Amount"].ToString()) ? Convert.ToDecimal(dt.Rows[index]["Tax_Amount"]) : 0,
            //  !string.IsNullOrEmpty(dt.Rows[index]["Permit_Holder"].ToString()) ? Convert.ToInt32(dt.Rows[index]["Permit_Holder"]) : 0, Convert.ToInt32(ddlLicense.SelectedValue), "Update", Convert.ToInt32(LoggedInUserID), CompanyID);

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
            dsGetPurchase = ObjCocktailWorld.PurchaseMaster_CRUD(Convert.ToInt32(ddlSupplier.SelectedValue), txttpnumber.Text, txtinvoicenumber.Text, txtPurchaseDate.Text, !string.IsNullOrEmpty(txttotalcharges.Text) ? Convert.ToDecimal(txttotalcharges.Text) : 0, !string.IsNullOrEmpty(txtdiscount.Text) ? Convert.ToDecimal(txtdiscount.Text) : 0, ddlLicense.SelectedIndex, CompanyID, LoggedInUserID, "Duplicate");
            if (dsGetPurchase.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        protected void btn_Add_Purchase_Click(object sender, EventArgs e)
        {
            if (ddlSupplier.SelectedIndex > 0 && ddlBrand.SelectedIndex > 0 && ddlSize.SelectedIndex > 0)
            {
                Insert_Purchase_Data();
            }
            else if (ddlSupplier.SelectedIndex == 0 && ddlBrand.SelectedIndex == 0 && ddlSize.SelectedIndex == 0)
            {
                //Excel
            }
        }

        protected void Insert_Purchase_Data()
        {
            try
            {
                if (ddlLicense.SelectedIndex != 0 && grdPurchase.Rows.Count > 0 && !string.IsNullOrEmpty(txtPurchaseDate.Text) && !string.IsNullOrEmpty(txttpnumber.Text) && ddlSupplier.SelectedIndex != 0)
                {
                    //Check Brand Sale Duplicate Data
                    bool purchaseDuplicate = Check_Purchase_DuplicateData();
                    bool displayMessage = false;

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
                                    Amount = (Bottle_Rate * Bottle_Qty) + (Speg_Rate * SPeg_Qty);

                                if (!string.IsNullOrEmpty(row.FindControl("txtamount").ToString()) && header == "Tax Amount")
                                    TaxAmount = Amount * Convert.ToInt32(Session["hdnTax"]) / 100;
                            }

                            //Get Calculation from Current Stock
                            if (Opening_ID == 0)
                            {
                                Response.Write("<script>alert('Brand Opening not avalible.')</script>");
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
                                        DataRow drInsertPurchaseData = dtInsertPurchaseData.NewRow();
                                        drInsertPurchaseData["Opening_ID"] = Opening_ID;
                                        drInsertPurchaseData["getClosingBottle"] = getClosingBottle;
                                        drInsertPurchaseData["getClosingSpeg"] = getClosingSpeg;
                                        dtInsertPurchaseData.Rows.Add(drInsertPurchaseData);

                                        //Add Sale Details Data in Row 
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
                                    else
                                    {
                                        string message = "Negative stock found in : Brand : " + Brand_Name + " And Size : " + Size_Desc + " With Bottle : " + getCurrentBottle + " and Speg : " + getCurrentsPeg;
                                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                                        sb.Append("<script type = 'text/javascript'>");
                                        sb.Append("window.onload=function(){");
                                        sb.Append("alert('");
                                        sb.Append(message);
                                        sb.Append("')};");
                                        sb.Append("</script>");
                                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                                        displayMessage = false;
                                        break;
                                    }
                                }
                                else
                                {
                                    Response.Write("<script>alert('Please Check Bottle Qty and SPeg Qty.')</script>");
                                }
                            }
                        }

                        if (grdPurchase.Rows.Count > 0 && dtInsertPurchaseData.Rows.Count > 0 && dtInsertPurchaseDetailsData.Rows.Count > 0 && (grdPurchase.Rows.Count == dtInsertPurchaseData.Rows.Count))
                        {
                            //Insert Operation for Purchase Data
                            DataSet dsPurchase = new DataSet();
                            dsPurchase = ObjCocktailWorld.PurchaseMaster_CRUD(Convert.ToInt32(ddlSupplier.SelectedValue), txttpnumber.Text, txtinvoicenumber.Text, txtPurchaseDate.Text, !string.IsNullOrEmpty(txttotalcharges.Text) ? Convert.ToDecimal(txttotalcharges.Text) : 0, !string.IsNullOrEmpty(txtdiscount.Text) ? Convert.ToDecimal(txtdiscount.Text) : 0,Convert.ToInt32(ddlLicense.SelectedValue), CompanyID, LoggedInUserID, "Insert");

                            for (int i = 0; i < dtInsertPurchaseData.Rows.Count; i++)
                            {
                                DataSet dsUpdateOpeningData = new DataSet();
                                dsUpdateOpeningData = ObjCocktailWorld.BrandOpeningMaster_CRUD(Convert.ToInt32(dtInsertPurchaseData.Rows[i]["Opening_ID"]),
                                    Convert.ToDecimal(dtInsertPurchaseData.Rows[i]["getClosingBottle"]), Convert.ToDecimal(dtInsertPurchaseData.Rows[i]["getClosingSpeg"]), "Update", Convert.ToInt32(LoggedInUserID), CompanyID);

                                if (dsUpdateOpeningData.Tables[0].Rows.Count > 0)
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
                        }

                        if (displayMessage)
                            Response.Redirect("~/Cocktail_World/Transactions/Purchase.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Data already avalible.')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please select License.')</script>");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}