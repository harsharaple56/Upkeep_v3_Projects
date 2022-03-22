using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Cocktail_World.Transactions
{
    public partial class Add_Transfers : System.Web.UI.Page
    {
        CocktailWorld_Service.CocktailWorld_Service ObjCocktailWorld = new CocktailWorld_Service.CocktailWorld_Service();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            txtTransferDate.Text = DateTime.Now.ToString("dd-MMMM-yyyy");
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            if (!IsPostBack)
            {
                Fetch_License();
                SetTransferInitialRow();

                #region Edit and Delete Transfer
                int Transfer_ID = Convert.ToInt32(Request.QueryString["Transfer_ID"]);
                int Transfer_ID_Delete = Convert.ToInt32(Request.QueryString["DelTransfer_ID"]);
                if (Transfer_ID > 0)
                {
                    Bind_TransferMaster(Transfer_ID);
                }
                if (Transfer_ID_Delete > 0)
                {
                    Delete_TransferMaster(Transfer_ID_Delete);
                }
                #endregion
            }
        }

        public void Bind_TransferMaster(int Transfer_ID)
        {
            try
            {
                DataSet dsTransfer = new DataSet();
                dsTransfer = ObjCocktailWorld.TransferMaster_CRUD(Transfer_ID, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, 0, LoggedInUserID, CompanyID, "Fetch");

                DataSet dsTransferDetails = new DataSet();
                dsTransferDetails = ObjCocktailWorld.TransferDetailsMaster_CRUD(Transfer_ID, string.Empty, string.Empty, 0, string.Empty, string.Empty, string.Empty, 0, 0, 0, 0, 0, 0, string.Empty, string.Empty, string.Empty, "Fetch");

                if (dsTransfer.Tables.Count > 0)
                {
                    if (dsTransfer.Tables[0].Rows.Count > 0)
                    {
                        DateTime transferDate = Convert.ToDateTime(dsTransfer.Tables[0].Rows[0]["Transfer_Date"]);
                        txtTransferDate.Text = transferDate.ToString("dd-MMMM-yyyy");
                        txttpnumber.Text = Convert.ToString(dsTransfer.Tables[0].Rows[0]["TP_No"]);
                        txtinvoicenumber.Text = Convert.ToString(dsTransfer.Tables[0].Rows[0]["Invoice_No"]);
                        string txtLicen = Convert.ToString(dsTransfer.Tables[0].Rows[0]["From_License"]);
                        string txtTrasnfLice = Convert.ToString(dsTransfer.Tables[0].Rows[0]["To_License"]);
                        ddlLicense.ClearSelection(); //making sure the previous selection has been cleared
                        ddlLicense.Items.FindByValue(txtLicen).Selected = true;


                        DataSet ds = new DataSet();
                        ds = ObjCocktailWorld.License_CRUD(Convert.ToInt32(txtLicen), string.Empty, string.Empty, LoggedInUserID, CompanyID, "Fetch");
                        ddlTransferLicense.DataSource = ds.Tables[0];
                        ddlTransferLicense.DataTextField = "License_Name";
                        ddlTransferLicense.DataValueField = "License_ID";
                        ddlTransferLicense.DataBind();
                        ddlTransferLicense.Items.Insert(0, new ListItem("--Select License--", "0"));
                        ddlTransferLicense.Items.FindByValue(txtTrasnfLice).Selected = true;

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
                        dtCurrentTable.Columns.Add("Stock", typeof(String));
                        dtCurrentTable.Columns.Add("Total_Amount", typeof(String));

                        dsTransferDetails.Tables[0].Columns.Add("Stock", typeof(String));
                        dsTransferDetails.Tables[0].Columns.Add("Total_Amount", typeof(String));

                        if (ViewState["Transfer"] != null)
                        {
                            for (int i = 0; i < dsTransferDetails.Tables[0].Rows.Count; i++)
                            {
                                drCurrentRow = dtCurrentTable.NewRow();
                                drCurrentRow["Brand"] = dsTransferDetails.Tables[0].Rows[i]["Brand"].ToString();
                                drCurrentRow["Size"] = dsTransferDetails.Tables[0].Rows[i]["Size"].ToString();
                                drCurrentRow["sPegQty"] = dsTransferDetails.Tables[0].Rows[i]["sPegQty"].ToString();
                                drCurrentRow["sPegRate"] = dsTransferDetails.Tables[0].Rows[i]["sPegRate"].ToString();
                                DateTime dtmfg = Convert.ToDateTime(dsTransferDetails.Tables[0].Rows[i]["MfgDate"].ToString());
                                drCurrentRow["MfgDate"] = dtmfg.ToString("dd/MMMM/yyyy");
                                drCurrentRow["BatchNo"] = dsTransferDetails.Tables[0].Rows[i]["BatchNo"].ToString();
                                drCurrentRow["Boxes"] = dsTransferDetails.Tables[0].Rows[i]["Boxes"].ToString();
                                drCurrentRow["Bottle_Qty"] = dsTransferDetails.Tables[0].Rows[i]["Bottle_Qty"].ToString();
                                drCurrentRow["Bottle_Rate"] = dsTransferDetails.Tables[0].Rows[i]["Bottle_Rate"].ToString();
                                drCurrentRow["Total_Amount"] = (Convert.ToDecimal(dsTransferDetails.Tables[0].Rows[i]["Bottle_Rate"]) *
                                                                 Convert.ToDecimal(dsTransferDetails.Tables[0].Rows[i]["Bottle_Qty"])) +
                                                                 (Convert.ToDecimal(dsTransferDetails.Tables[0].Rows[i]["sPegQty"]) *
                                                                 Convert.ToDecimal(dsTransferDetails.Tables[0].Rows[i]["sPegRate"]));
                                DataSet dsGetStockDetails = new DataSet();
                                dsGetStockDetails = ObjCocktailWorld.FetchBrandSizeLinkup(0, 0, 0, dsTransferDetails.Tables[0].Rows[i]["Brand"].ToString(), dsTransferDetails.Tables[0].Rows[i]["Size"].ToString(), CompanyID, 0, string.Empty, DateTime.Now);
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
                            grdTransfer.DataSource = dtCurrentTable.Copy();
                            grdTransfer.DataBind();
                            DataTable dt = new DataTable();
                            dt = dtCurrentTable.Copy();
                            ViewState["Transfer"] = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Delete_TransferMaster(int Transfer_ID_Delete)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = ObjCocktailWorld.TransferMaster_CRUD(Transfer_ID_Delete, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, 0, LoggedInUserID, CompanyID, "Delete");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataSet dsTranferDetails = new DataSet();
                        dsTranferDetails = ObjCocktailWorld.TransferDetailsMaster_CRUD(Transfer_ID_Delete, string.Empty, string.Empty, 0, string.Empty, string.Empty, string.Empty, 0, 0, 0, 0, 0, CompanyID, LoggedInUserID, string.Empty, string.Empty, "Delete");

                        if (dsTranferDetails.Tables.Count > 0)
                        {
                            if (dsTranferDetails.Tables[0].Rows.Count > 0)
                            {
                                Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Transactions/Transfers.aspx"), false);
                            }
                        }
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
            DataSet ds = new DataSet();
            ds = ObjCocktailWorld.License_CRUD(0, string.Empty, string.Empty, LoggedInUserID, CompanyID, "R");
            ddlLicense.DataSource = ds.Tables[0];
            ddlLicense.DataTextField = "License_Name";
            ddlLicense.DataValueField = "License_ID";
            ddlLicense.DataBind();
            ddlLicense.Items.Insert(0, new ListItem("--Select License--", "0"));
        }

        protected void ddlLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fetch_TransferLicense();
            Fetch_Brand_Size(true);
        }

        private void Fetch_TransferLicense()
        {
            DataSet ds = new DataSet();
            ds = ObjCocktailWorld.License_CRUD(Convert.ToInt32(ddlLicense.SelectedValue), string.Empty, string.Empty, LoggedInUserID, CompanyID, "Fetch");
            ddlTransferLicense.DataSource = ds.Tables[0];
            ddlTransferLicense.DataTextField = "License_Name";
            ddlTransferLicense.DataValueField = "License_ID";
            ddlTransferLicense.DataBind();
            ddlTransferLicense.Items.Insert(0, new ListItem("--Select License--", "0"));
        }

        private DataSet GetStockDetails()
        {
            DataSet ds = new DataSet();
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
                ds = ObjCocktailWorld.FetchBrandSizeLinkup(0, BrandID, Size_ID, "", "", CompanyID, 0, "Sale", DateTime.Now);
            else
                ds = null;
            return ds;
        }

        private void Fetch_Brand_Size(bool chk)
        {
            DataSet ds = new DataSet();
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

        private void SetTransferInitialRow()
        {
            try
            {
                ViewState["Transfer"] = null;

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
                dt.Rows.Add(drRow);

                ViewState["Transfer"] = dt;
                grdTransfer.DataSource = ViewState["Transfer"];
                grdTransfer.DataBind();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AddTransfer_NewRowToGrid()
        {
            try
            {
                int rowIndex = 0;
                if (ViewState["Transfer"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["Transfer"];

                    DataRow drCurrentRow = null;

                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {
                            //extract the TextBox values  
                            TextBox txt1 = grdTransfer.Rows[rowIndex].FindControl("txtspegqty") as TextBox;
                            TextBox txt2 = grdTransfer.Rows[rowIndex].FindControl("txtspegrate") as TextBox;
                            TextBox txt3 = grdTransfer.Rows[rowIndex].FindControl("txtboxes") as TextBox;
                            TextBox txt4 = grdTransfer.Rows[rowIndex].FindControl("txtbatchno") as TextBox;
                            TextBox txt5 = grdTransfer.Rows[rowIndex].FindControl("txtmfgdate") as TextBox;
                            TextBox txt6 = grdTransfer.Rows[rowIndex].FindControl("txtbottleqty") as TextBox;
                            TextBox txt7 = grdTransfer.Rows[rowIndex].FindControl("txtbottlerate") as TextBox;
                            TextBox txt8 = grdTransfer.Rows[rowIndex].FindControl("txttotalamount") as TextBox;

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

                        ViewState["Transfer"] = dtCurrentTable;
                        grdTransfer.DataSource = dtCurrentTable;
                        grdTransfer.DataBind();
                    }
                }
                else
                {
                    Response.Write("ViewState is null");
                }

                //Set Previous Data on Postbacks
                SetTransferPreviousRow();
                ddlBrand.ClearSelection();
                ddlSize.ClearSelection();
                lbl_stock.Text = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetTransferPreviousRow()
        {
            try
            {
                int rowIndex = 0;
                if (ViewState["Transfer"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["Transfer"];
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                        {
                            TextBox txt1 = grdTransfer.Rows[rowIndex].FindControl("txtspegqty") as TextBox;
                            TextBox txt2 = grdTransfer.Rows[rowIndex].FindControl("txtspegrate") as TextBox;
                            TextBox txt3 = grdTransfer.Rows[rowIndex].FindControl("txtboxes") as TextBox;
                            TextBox txt4 = grdTransfer.Rows[rowIndex].FindControl("txtbatchno") as TextBox;
                            TextBox txt5 = grdTransfer.Rows[rowIndex].FindControl("txtmfgdate") as TextBox;
                            TextBox txt6 = grdTransfer.Rows[rowIndex].FindControl("txtbottleqty") as TextBox;
                            TextBox txt7 = grdTransfer.Rows[rowIndex].FindControl("txtbottlerate") as TextBox;
                            TextBox txt8 = grdTransfer.Rows[rowIndex].FindControl("txttotalamount") as TextBox;

                            txt1.Text = dtCurrentTable.Rows[i]["sPegQty"].ToString();
                            txt2.Text = dtCurrentTable.Rows[i]["sPegRate"].ToString();
                            txt3.Text = dtCurrentTable.Rows[i]["Boxes"].ToString();
                            txt4.Text = dtCurrentTable.Rows[i]["BatchNo"].ToString();
                            txt5.Text = dtCurrentTable.Rows[i]["MfgDate"].ToString();
                            txt6.Text = dtCurrentTable.Rows[i]["Bottle_Qty"].ToString();
                            txt7.Text = dtCurrentTable.Rows[i]["Bottle_Rate"].ToString();
                            txt8.Text = dtCurrentTable.Rows[i]["Total_Amount"].ToString();
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

        protected void BindTransferGrid()
        {
            grdTransfer.DataSource = (DataTable)ViewState["Transfer"];
            grdTransfer.DataBind();
        }

        protected void Transfer_OnRowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void Transfer_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = ViewState["Transfer"] as DataTable;



            dt.Rows[index].Delete();
            dt.AcceptChanges();
            ViewState["Transfer"] = dt;
            BindTransferGrid();
            if (index == 0)
            {
                SetTransferInitialRow();
            }
        }

        protected void Transfer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTransfer.PageIndex = e.NewPageIndex;
            BindTransferGrid();
        }

        protected void btn_AddTransferRow_Click(object sender, EventArgs e)
        {
            AddTransfer_NewRowToGrid();
        }

        public bool Check_Transfer_DuplicateData()
        {
            DataSet dsGetTransfer = new DataSet();

            if (dsGetTransfer.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        protected void btn_Add_Transfer_Click(object sender, EventArgs e)
        {
            int Transfer_ID = Convert.ToInt32(Request.QueryString["Transfer_ID"]);
            if (Transfer_ID > 0)
            {
                UpdateTransfer(Transfer_ID);
            }
            else
            {
                SaveTransfer();
            }
        }

        protected void UpdateTransfer(int Transfer_ID)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtTransferDate.Text) && ddlTransferLicense.SelectedIndex != 0 && !string.IsNullOrEmpty(txttpnumber.Text) && !string.IsNullOrEmpty(txtinvoicenumber.Text) && grdTransfer.Rows.Count > 0)
                {
                    #region Update Transfer Data
                    DataSet dsTransferData = new DataSet();
                    dsTransferData = ObjCocktailWorld.TransferMaster_CRUD(Transfer_ID, txtTransferDate.Text, txttpnumber.Text, txtinvoicenumber.Text, string.Empty
                        , string.Empty, Convert.ToInt32(ddlTransferLicense.SelectedValue), Convert.ToInt32(ddlLicense.SelectedValue), LoggedInUserID, CompanyID, "Update");
                    if (dsTransferData.Tables[0].Rows.Count > 0)
                    {
                        #region Update Transfer Details Data
                        if (ViewState["Transfer"] != null && grdTransfer.Rows.Count > 0)
                        {
                            #region Check Current Grid Data and Previous Grid Data

                            DataTable dtPreviousData = (DataTable)ViewState["Transfer"];
                            //Add Transfer Details Data in Temporary Datatable
                            DataTable dtInsertTransferDetailsData = new DataTable();
                            dtInsertTransferDetailsData.Columns.Add("Brand_Name");
                            dtInsertTransferDetailsData.Columns.Add("Size_Desc");
                            dtInsertTransferDetailsData.Columns.Add("Opening_ID");
                            dtInsertTransferDetailsData.Columns.Add("Tax_Type");
                            dtInsertTransferDetailsData.Columns.Add("Bottle_Qty");
                            dtInsertTransferDetailsData.Columns.Add("Bottle_Rate");
                            dtInsertTransferDetailsData.Columns.Add("SPeg_Qty");
                            dtInsertTransferDetailsData.Columns.Add("Speg_Rate");
                            dtInsertTransferDetailsData.Columns.Add("Boxes");
                            dtInsertTransferDetailsData.Columns.Add("BatchNo");
                            dtInsertTransferDetailsData.Columns.Add("MfgDate");
                            dtInsertTransferDetailsData.Columns.Add("TotalAmount");

                            foreach (GridViewRow row in grdTransfer.Rows)
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
                                decimal TotalAmount = 0;
                                for (int i = 0; i < grdTransfer.Columns.Count; i++)
                                {
                                    string header = grdTransfer.Columns[i].HeaderText;
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
                                        TotalAmount = (Bottle_Rate * Bottle_Qty) + (Speg_Rate * SPeg_Qty);

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


                                //Add Sale Details Data in Row 
                                DateTime myTime = DateTime.MinValue;
                                DateTime dtMFgDate = !string.IsNullOrEmpty(MfgDate.ToString()) ? Convert.ToDateTime(MfgDate) : DateTime.MinValue;
                                DateTime dtConvertMfgDate = Convert.ToDateTime(dtMFgDate.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture));
                                DataRow drInsertTransferDetailsData = dtInsertTransferDetailsData.NewRow();
                                drInsertTransferDetailsData["Brand_Name"] = Brand_Name;
                                drInsertTransferDetailsData["Size_Desc"] = Size_Desc;
                                drInsertTransferDetailsData["Opening_ID"] = Opening_ID;
                                drInsertTransferDetailsData["Tax_Type"] = Tax_Type;
                                drInsertTransferDetailsData["Bottle_Qty"] = Bottle_Qty;
                                drInsertTransferDetailsData["Bottle_Rate"] = Bottle_Rate;
                                drInsertTransferDetailsData["SPeg_Qty"] = SPeg_Qty;
                                drInsertTransferDetailsData["Speg_Rate"] = Speg_Rate;
                                drInsertTransferDetailsData["Boxes"] = Boxes;
                                drInsertTransferDetailsData["BatchNo"] = BatchNo;
                                drInsertTransferDetailsData["MfgDate"] = dtConvertMfgDate;
                                drInsertTransferDetailsData["TotalAmount"] = TotalAmount;
                                dtInsertTransferDetailsData.Rows.Add(drInsertTransferDetailsData);

                            }

                            dtInsertTransferDetailsData.AcceptChanges();
                            #endregion

                            #region Update Data
                            DataSet dsUpdate = new DataSet();
                            dsUpdate = ObjCocktailWorld.TransferDetailsMaster_CRUD(Transfer_ID, string.Empty, string.Empty, 0, string.Empty, string.Empty, string.Empty, 0, 0, 0, 0, 0, 0, string.Empty, string.Empty, string.Empty, "Fetch");
                            if (dsUpdate.Tables[0].Rows.Count > 0)
                            {
                                #region Fetch Old Trasnfer Details Data
                                DataSet dsOldTrasnferDetails = new DataSet();
                                dsOldTrasnferDetails = ObjCocktailWorld.TransferDetailsMaster_CRUD(Transfer_ID, "", "", 0, "", "", "", 0, 0, 0, 0, 0, CompanyID, LoggedInUserID, "", "", "TrasnferToDelete");
                                if (dsOldTrasnferDetails.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < dtInsertTransferDetailsData.Rows.Count; i++)
                                    {
                                        DataSet dsNewTrasnferDetails = new DataSet();
                                        dsNewTrasnferDetails = ObjCocktailWorld.TransferDetailsMaster_CRUD(
                                                Transfer_ID, string.Empty, txttpnumber.Text,
                                                Convert.ToInt32(dtInsertTransferDetailsData.Rows[i]["Opening_ID"]),
                                                Convert.ToString(dtInsertTransferDetailsData.Rows[i]["MfgDate"]),
                                                 Convert.ToString(dtInsertTransferDetailsData.Rows[i]["Boxes"]),
                                                Convert.ToString(dtInsertTransferDetailsData.Rows[i]["BatchNo"]),
                                                 Convert.ToDecimal(dtInsertTransferDetailsData.Rows[i]["SPeg_Qty"]),
                                                Convert.ToDecimal(dtInsertTransferDetailsData.Rows[i]["Speg_Rate"]),
                                                Convert.ToDecimal(dtInsertTransferDetailsData.Rows[i]["Bottle_Qty"]),
                                                Convert.ToDecimal(dtInsertTransferDetailsData.Rows[i]["Bottle_Rate"]),
                                                Convert.ToInt32(ddlLicense.SelectedValue), CompanyID, LoggedInUserID,
                                                Convert.ToString(dsUpdate.Tables[0].Rows[i]["Created_By"]),
                                                Convert.ToString(dsUpdate.Tables[0].Rows[i]["Created_Date"]), "Update");
                                    }
                                }
                                #endregion
                            }
                            #endregion


                        }
                        #endregion
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void SaveTransfer()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtTransferDate.Text) && ddlTransferLicense.SelectedIndex != 0 && !string.IsNullOrEmpty(txttpnumber.Text) && grdTransfer.Rows.Count > 0)
                {
                    bool displayMessage = false;
                    bool checkamount = false;

                    //Add Transfer Details Data in Temporary Datatable
                    DataTable dtInsertTransferData = new DataTable();
                    dtInsertTransferData.Columns.Add("Opening_ID");
                    dtInsertTransferData.Columns.Add("getClosingBottle");
                    dtInsertTransferData.Columns.Add("getClosingSpeg");

                    //Add Transfer Details Data in Temporary Datatable
                    DataTable dtInsertTransferDetailsData = new DataTable();
                    dtInsertTransferDetailsData.Columns.Add("Brand_Name");
                    dtInsertTransferDetailsData.Columns.Add("Size_Desc");
                    dtInsertTransferDetailsData.Columns.Add("Opening_ID");
                    dtInsertTransferDetailsData.Columns.Add("Tax_Type");
                    dtInsertTransferDetailsData.Columns.Add("Bottle_Qty");
                    dtInsertTransferDetailsData.Columns.Add("Bottle_Rate");
                    dtInsertTransferDetailsData.Columns.Add("SPeg_Qty");
                    dtInsertTransferDetailsData.Columns.Add("Speg_Rate");
                    dtInsertTransferDetailsData.Columns.Add("Boxes");
                    dtInsertTransferDetailsData.Columns.Add("BatchNo");
                    dtInsertTransferDetailsData.Columns.Add("MfgDate");
                    dtInsertTransferDetailsData.Columns.Add("TotalAmount");

                    foreach (GridViewRow row in grdTransfer.Rows)
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
                        decimal TotalAmount = 0;
                        for (int i = 0; i < grdTransfer.Columns.Count; i++)
                        {
                            string header = grdTransfer.Columns[i].HeaderText;
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
                                TotalAmount = (Bottle_Rate * Bottle_Qty) + (Speg_Rate * SPeg_Qty);
                                if (TotalAmount == 0)
                                {
                                    checkamount = true;
                                    break;
                                }
                            }

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
                            dsFetchBrand = ObjCocktailWorld.FetchBrandSizeLinkup(0, 0, 0, Brand_Name, Size_Desc, CompanyID, 0, string.Empty, DateTime.Now);
                            if (dsFetchBrand.Tables[0].Rows.Count > 0)
                            {
                                getCurrentBottle = Convert.ToInt32(dsFetchBrand.Tables[0].Rows[0].ItemArray[0]);
                                getCurrentsPeg = Convert.ToInt32(dsFetchBrand.Tables[0].Rows[0].ItemArray[1]);

                                getClosingBottle = getCurrentBottle - Bottle_Qty;
                                getClosingSpeg = getCurrentsPeg - SPeg_Qty;

                                if (getClosingSpeg >= 0 && getClosingBottle >= 0)
                                {
                                    //Add Transfer Data in Row 
                                    DataRow drInsertTransferData = dtInsertTransferData.NewRow();
                                    drInsertTransferData["Opening_ID"] = Opening_ID;
                                    drInsertTransferData["getClosingBottle"] = getClosingBottle;
                                    drInsertTransferData["getClosingSpeg"] = getClosingSpeg;
                                    dtInsertTransferData.Rows.Add(drInsertTransferData);

                                    //Add Transfer Details Data in Row 
                                    DataRow drInsertTransferDetailsData = dtInsertTransferDetailsData.NewRow();
                                    drInsertTransferDetailsData["Brand_Name"] = Brand_Name;
                                    drInsertTransferDetailsData["Size_Desc"] = Size_Desc;
                                    drInsertTransferDetailsData["Opening_ID"] = Opening_ID;
                                    drInsertTransferDetailsData["Tax_Type"] = Tax_Type;
                                    drInsertTransferDetailsData["Bottle_Qty"] = Bottle_Qty;
                                    drInsertTransferDetailsData["Bottle_Rate"] = Bottle_Rate;
                                    drInsertTransferDetailsData["SPeg_Qty"] = SPeg_Qty;
                                    drInsertTransferDetailsData["Speg_Rate"] = Speg_Rate;
                                    drInsertTransferDetailsData["Boxes"] = Boxes;
                                    drInsertTransferDetailsData["BatchNo"] = BatchNo;
                                    drInsertTransferDetailsData["MfgDate"] = MfgDate;
                                    drInsertTransferDetailsData["TotalAmount"] = TotalAmount;
                                    dtInsertTransferDetailsData.Rows.Add(drInsertTransferDetailsData);
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
                        if (grdTransfer.Rows.Count > 0 && dtInsertTransferData.Rows.Count > 0 && dtInsertTransferDetailsData.Rows.Count > 0 && (grdTransfer.Rows.Count == dtInsertTransferData.Rows.Count))
                        {
                            //Insert Operation for Transfer Data
                            DataSet dsTransfer = new DataSet();
                            dsTransfer = ObjCocktailWorld.TransferMaster_CRUD(0, txtTransferDate.Text, txttpnumber.Text, txtinvoicenumber.Text, string.Empty, string.Empty,
                                Convert.ToInt32(ddlTransferLicense.SelectedValue), Convert.ToInt32(ddlLicense.SelectedValue), LoggedInUserID, CompanyID, "Insert");

                            for (int i = 0; i < dtInsertTransferData.Rows.Count; i++)
                            {
                                ObjCocktailWorld.TransferDetailsMaster_CRUD(
                                    Convert.ToInt32(dsTransfer.Tables[0].Rows[0]["Transfer_ID"]), string.Empty, txttpnumber.Text,
                                    Convert.ToInt32(dtInsertTransferData.Rows[i]["Opening_ID"]),
                                    Convert.ToString(dtInsertTransferDetailsData.Rows[i]["MfgDate"]) != string.Empty ? Convert.ToString(dtInsertTransferDetailsData.Rows[i]["MfgDate"]) : DateTime.Now.ToString("dd/MMMM/yyyy"),
                                     Convert.ToString(dtInsertTransferDetailsData.Rows[i]["Boxes"]),
                                    Convert.ToString(dtInsertTransferDetailsData.Rows[i]["BatchNo"]),
                                     Convert.ToDecimal(dtInsertTransferDetailsData.Rows[i]["SPeg_Qty"]),
                                    Convert.ToDecimal(dtInsertTransferDetailsData.Rows[i]["Speg_Rate"]),
                                    Convert.ToDecimal(dtInsertTransferDetailsData.Rows[i]["Bottle_Qty"]),
                                    Convert.ToDecimal(dtInsertTransferDetailsData.Rows[i]["Bottle_Rate"]),
                                    Convert.ToInt32(ddlLicense.SelectedValue), CompanyID, LoggedInUserID, string.Empty, string.Empty, "Insert");
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
                string getBottle = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                string getsPeg = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                string displayStock = "Available Stock :- Bottle :" + getBottle + " & Speg :" + getsPeg;
                lbl_stock.Text = displayStock;
            }
        }
    }
}