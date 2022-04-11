using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Cocktail_World.Setup
{
    public partial class Import_Master : System.Web.UI.Page
    {
        CocktailWorld_Service.CocktailWorld_Service ObjCocktailWorld = new CocktailWorld_Service.CocktailWorld_Service();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Session["LoggedInUserID"].ToString();
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            if (!IsPostBack)
            {
                Bind_License();
                Bind_Format();
                btnImportExcelPopup.Visible = false;
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


        public void Bind_Format()
        {
            try
            {
                ddlFormat.DataBind();
                ddlFormat.Items.Insert(0, new ListItem("Microsoft Excel 97-2003", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnImportExcel_Click(object sender, EventArgs e)
        {
            string name = ddlMaster.SelectedItem.ToString();

            if (name == "Brand")
            {
                Brand_Import();
            }
            if (name == "Supplier")
            {
                Supplier_Import();
            }
            if (name == "Brand Opening")
            {
                Brand_Opening_Import();

            }
            if (name == "Brand Code")
            {
                Brand_Code_Import();
            }
            if (name == "Cocktail Code")
            {
                Cocktail_Code_Import();
            }
            if (name == "Cocktail")
            {
                Cocktail_Import();
            }
        }

        public void Brand_Import()
        {
            DataSet dsResult = new DataSet();
            if (FU_Category.HasFile && FU_Category.PostedFile != null)
            {
                try
                {
                    string path = string.Concat(Server.MapPath("~/Cocktail_World/ImportFile/" + FU_Category.FileName));
                    string extension = Path.GetExtension(FU_Category.PostedFile.FileName);
                    FU_Category.SaveAs(path);

                    // Connection String to Excel Workbook  
                    string conString = string.Empty;
                    switch (extension)
                    {
                        case ".xls": //For Excel 97-03.  
                            conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                            break;
                        case ".xlsx": //For Excel 07 and above.  
                            conString = ConfigurationManager.ConnectionStrings["Excel07+ConString"].ConnectionString;
                            break;
                    }
                    string excelCS = string.Format(conString, path);

                    using (OleDbConnection con = new OleDbConnection(excelCS))
                    {
                        OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", con);
                        con.Open();
                        // Create DbDataReader to Data Worksheet  
                        DbDataReader dr = cmd.ExecuteReader();
                        // SQL Server Connection String  
                        string CS = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString;
                        // Bulk Copy to SQL Server   
                        SqlBulkCopy bulkInsert = new SqlBulkCopy(CS);
                        bulkInsert.DestinationTableName = "Tbl_CW_Import_Brand_Temp";
                        bulkInsert.ColumnMappings.Add("Category", "Category");
                        bulkInsert.ColumnMappings.Add("Brand Name", "Brand_Name");
                        bulkInsert.ColumnMappings.Add("Short Name", "Short_Name");
                        bulkInsert.ColumnMappings.Add("Strength", "Strength");
                        bulkInsert.ColumnMappings.Add("Purchase_Rate_Peg", "Purchase_Rate_Peg");
                        bulkInsert.ColumnMappings.Add("Selling_Rate_Peg", "Selling_Rate_Peg");
                        bulkInsert.ColumnMappings.Add("Selling_Rate_Bottle", "Selling_Rate_Bottle");
                        bulkInsert.ColumnMappings.Add("SubCategory", "SubCategory");
                        bulkInsert.WriteToServer(dr);

                        dsResult = ObjCocktailWorld.Import_Brands(CompanyID, LoggedInUserID);

                        if (dsResult.Tables.Count > 0)
                        {
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                DataTable dtCTTReport = new DataTable();
                                dtCTTReport = dsResult.Tables[0];
                                dtCTTReport.Columns["Category"].ColumnName = "Category";
                                dtCTTReport.Columns["Brand_Name"].ColumnName = "Brand";
                                dtCTTReport.Columns["Short_Name"].ColumnName = "Short_Name";
                                dtCTTReport.Columns["Strength"].ColumnName = "Strength";
                                dtCTTReport.Columns["Purchase_Rate_Peg"].ColumnName = "Purchase_Rate_Peg";
                                dtCTTReport.Columns["Selling_Rate_Peg"].ColumnName = "Selling_Rate_Peg";
                                dtCTTReport.Columns["Selling_Rate_Bottle"].ColumnName = "Selling_Rate_Bottle";
                                dtCTTReport.Columns["SubCategory"].ColumnName = "SubCategory";
                                dtCTTReport.AcceptChanges();

                                dvErrorGrid.Attributes.Add("style", "display:block; overflow-y:auto; height:210px;");
                                pnlImportExport.Attributes.Add("style", "height:580px; width:700px; top:-14px !important;");

                                mpeUserMst.Show();
                                lblImportErrorMsg.Text = "Below Stock List can not be created, kindly check error message.";
                                gvImportError.DataSource = dtCTTReport;
                                gvImportError.DataBind();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Supplier_Import()
        {
            DataSet dsResult = new DataSet();
            if (FU_Category.HasFile && FU_Category.PostedFile != null)
            {
                try
                {
                    string path = string.Concat(Server.MapPath("~/Cocktail_World/ImportFile/" + FU_Category.FileName));
                    string extension = Path.GetExtension(FU_Category.PostedFile.FileName);
                    FU_Category.SaveAs(path);

                    // Connection String to Excel Workbook  
                    string conString = string.Empty;
                    switch (extension)
                    {
                        case ".xls": //For Excel 97-03.  
                            conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                            break;
                        case ".xlsx": //For Excel 07 and above.  
                            conString = ConfigurationManager.ConnectionStrings["Excel07+ConString"].ConnectionString;
                            break;
                    }
                    string excelCS = string.Format(conString, path);

                    using (OleDbConnection con = new OleDbConnection(excelCS))
                    {
                        OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", con);
                        con.Open();
                        // Create DbDataReader to Data Worksheet  
                        DbDataReader dr = cmd.ExecuteReader();
                        // SQL Server Connection String  
                        string CS = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString;
                        // Bulk Copy to SQL Server   
                        SqlBulkCopy bulkInsert = new SqlBulkCopy(CS);
                        bulkInsert.DestinationTableName = "Tbl_CW_Supplier_Temp_Import";
                        bulkInsert.ColumnMappings.Add("License Name", "License_Name");
                        bulkInsert.ColumnMappings.Add("Category", "Category");
                        bulkInsert.ColumnMappings.Add("Brand Name", "Brand_Name");
                        bulkInsert.ColumnMappings.Add("Size", "Size");
                        bulkInsert.ColumnMappings.Add("Bottle Qty", "Bottle_Qty");
                        bulkInsert.ColumnMappings.Add("Speg Qty", "Speg_Qty");
                        bulkInsert.ColumnMappings.Add("Bottle Rate", "Bottle_Rate");
                        bulkInsert.ColumnMappings.Add("Base Qty", "Base_Qty");
                        bulkInsert.ColumnMappings.Add("Re-Order Level", "Re_Order_Level");
                        bulkInsert.ColumnMappings.Add("Optimum Level", "Optimum_Level");
                        bulkInsert.WriteToServer(dr);

                        dsResult = ObjCocktailWorld.Import_BrandOpeningStock(CompanyID, LoggedInUserID);

                        if (dsResult.Tables.Count > 0)
                        {
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                DataTable dtCTTReport = new DataTable();
                                dtCTTReport = dsResult.Tables[0];
                                dtCTTReport.Columns["License_Name"].ColumnName = "License";
                                dtCTTReport.Columns["Category"].ColumnName = "Category";
                                dtCTTReport.Columns["Brand_Name"].ColumnName = "Brand";
                                dtCTTReport.Columns["Size"].ColumnName = "Size";
                                dtCTTReport.Columns["Bottle_Qty"].ColumnName = "Bottle Qty";
                                dtCTTReport.Columns["Speg_Qty"].ColumnName = "Speg Qty";
                                dtCTTReport.Columns["Bottle_Rate"].ColumnName = "Bottle Rate";
                                dtCTTReport.Columns["Base_Qty"].ColumnName = "Base Qty";
                                dtCTTReport.Columns["Re_Order_Level"].ColumnName = "Re-Order Level";
                                dtCTTReport.Columns["Optimum_Level"].ColumnName = "Optimum Level";
                                dtCTTReport.AcceptChanges();

                                dvErrorGrid.Attributes.Add("style", "display:block; overflow-y:auto; height:210px;");
                                pnlImportExport.Attributes.Add("style", "height:580px; width:700px; top:-14px !important;");

                                mpeUserMst.Show();
                                lblImportErrorMsg.Text = "Below Stock List can not be created, kindly check error message.";
                                gvImportError.DataSource = dtCTTReport;
                                gvImportError.DataBind();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Brand_Code_Import()
        {
            DataSet dsResult = new DataSet();
            if (FU_Category.HasFile && FU_Category.PostedFile != null)
            {
                try
                {
                    string path = string.Concat(Server.MapPath("~/Cocktail_World/ImportFile/" + FU_Category.FileName));
                    string extension = Path.GetExtension(FU_Category.PostedFile.FileName);
                    FU_Category.SaveAs(path);

                    // Connection String to Excel Workbook  
                    string conString = string.Empty;
                    switch (extension)
                    {
                        case ".xls": //For Excel 97-03.  
                            conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                            break;
                        case ".xlsx": //For Excel 07 and above.  
                            conString = ConfigurationManager.ConnectionStrings["Excel07+ConString"].ConnectionString;
                            break;
                    }
                    string excelCS = string.Format(conString, path);

                    using (OleDbConnection con = new OleDbConnection(excelCS))
                    {
                        OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", con);
                        con.Open();
                        // Create DbDataReader to Data Worksheet  
                        DbDataReader dr = cmd.ExecuteReader();
                        // SQL Server Connection String  
                        string CS = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString;
                        // Bulk Copy to SQL Server   
                        SqlBulkCopy bulkInsert = new SqlBulkCopy(CS);
                        bulkInsert.DestinationTableName = "Tbl_CW_BrandOpeningStock_Temp_Import";
                        bulkInsert.ColumnMappings.Add("License Name", "License_Name");
                        bulkInsert.ColumnMappings.Add("Category", "Category");
                        bulkInsert.ColumnMappings.Add("Brand Name", "Brand_Name");
                        bulkInsert.ColumnMappings.Add("Size", "Size");
                        bulkInsert.ColumnMappings.Add("Bottle Qty", "Bottle_Qty");
                        bulkInsert.ColumnMappings.Add("Speg Qty", "Speg_Qty");
                        bulkInsert.ColumnMappings.Add("Bottle Rate", "Bottle_Rate");
                        bulkInsert.ColumnMappings.Add("Base Qty", "Base_Qty");
                        bulkInsert.ColumnMappings.Add("Re-Order Level", "Re_Order_Level");
                        bulkInsert.ColumnMappings.Add("Optimum Level", "Optimum_Level");
                        bulkInsert.WriteToServer(dr);

                        dsResult = ObjCocktailWorld.Import_BrandOpeningStock(CompanyID, LoggedInUserID);

                        if (dsResult.Tables.Count > 0)
                        {
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                DataTable dtCTTReport = new DataTable();
                                dtCTTReport = dsResult.Tables[0];
                                dtCTTReport.Columns["License_Name"].ColumnName = "License";
                                dtCTTReport.Columns["Category"].ColumnName = "Category";
                                dtCTTReport.Columns["Brand_Name"].ColumnName = "Brand";
                                dtCTTReport.Columns["Size"].ColumnName = "Size";
                                dtCTTReport.Columns["Bottle_Qty"].ColumnName = "Bottle Qty";
                                dtCTTReport.Columns["Speg_Qty"].ColumnName = "Speg Qty";
                                dtCTTReport.Columns["Bottle_Rate"].ColumnName = "Bottle Rate";
                                dtCTTReport.Columns["Base_Qty"].ColumnName = "Base Qty";
                                dtCTTReport.Columns["Re_Order_Level"].ColumnName = "Re-Order Level";
                                dtCTTReport.Columns["Optimum_Level"].ColumnName = "Optimum Level";
                                dtCTTReport.AcceptChanges();

                                dvErrorGrid.Attributes.Add("style", "display:block; overflow-y:auto; height:210px;");
                                pnlImportExport.Attributes.Add("style", "height:580px; width:700px; top:-14px !important;");

                                mpeUserMst.Show();
                                lblImportErrorMsg.Text = "Below Stock List can not be created, kindly check error message.";
                                gvImportError.DataSource = dtCTTReport;
                                gvImportError.DataBind();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Brand_Opening_Import()
        {
            DataSet dsResult = new DataSet();
            if (FU_Category.HasFile && FU_Category.PostedFile != null)
            {
                try
                {
                    string path = string.Concat(Server.MapPath("~/Cocktail_World/ImportFile/" + FU_Category.FileName));
                    string extension = Path.GetExtension(FU_Category.PostedFile.FileName);
                    FU_Category.SaveAs(path);

                    // Connection String to Excel Workbook  
                    string conString = string.Empty;
                    switch (extension)
                    {
                        case ".xls": //For Excel 97-03.  
                            conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                            break;
                        case ".xlsx": //For Excel 07 and above.  
                            conString = ConfigurationManager.ConnectionStrings["Excel07+ConString"].ConnectionString;
                            break;
                    }
                    string excelCS = string.Format(conString, path);

                    using (OleDbConnection con = new OleDbConnection(excelCS))
                    {
                        OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", con);
                        con.Open();
                        // Create DbDataReader to Data Worksheet  
                        DbDataReader dr = cmd.ExecuteReader();
                        // SQL Server Connection String  
                        string CS = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString;
                        // Bulk Copy to SQL Server   
                        SqlBulkCopy bulkInsert = new SqlBulkCopy(CS);
                        bulkInsert.DestinationTableName = "Tbl_CW_Import_BrandOpeningStock_Temp";
                        bulkInsert.ColumnMappings.Add("License Name", "License_Name");
                        bulkInsert.ColumnMappings.Add("Category", "Category");
                        bulkInsert.ColumnMappings.Add("Brand Name", "Brand_Name");
                        bulkInsert.ColumnMappings.Add("Size", "Size");
                        bulkInsert.ColumnMappings.Add("Bottle Qty", "Bottle_Qty");
                        bulkInsert.ColumnMappings.Add("Speg Qty", "Speg_Qty");
                        bulkInsert.ColumnMappings.Add("Bottle Rate", "Bottle_Rate");
                        bulkInsert.ColumnMappings.Add("Base Qty", "Base_Qty");
                        bulkInsert.ColumnMappings.Add("Re-Order Level", "Re_Order_Level");
                        bulkInsert.ColumnMappings.Add("Optimum Level", "Optimum_Level");
                        bulkInsert.WriteToServer(dr);

                        dsResult = ObjCocktailWorld.Import_BrandOpeningStock(CompanyID, LoggedInUserID);

                        if (dsResult.Tables.Count > 0)
                        {
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                DataTable dtCTTReport = new DataTable();
                                dtCTTReport = dsResult.Tables[0];
                                dtCTTReport.Columns["License_Name"].ColumnName = "License";
                                dtCTTReport.Columns["Category"].ColumnName = "Category";
                                dtCTTReport.Columns["Brand_Name"].ColumnName = "Brand";
                                dtCTTReport.Columns["Size"].ColumnName = "Size";
                                dtCTTReport.Columns["Bottle_Qty"].ColumnName = "Bottle Qty";
                                dtCTTReport.Columns["Speg_Qty"].ColumnName = "Speg Qty";
                                dtCTTReport.Columns["Bottle_Rate"].ColumnName = "Bottle Rate";
                                dtCTTReport.Columns["Base_Qty"].ColumnName = "Base Qty";
                                dtCTTReport.Columns["Re_Order_Level"].ColumnName = "Re-Order Level";
                                dtCTTReport.Columns["Optimum_Level"].ColumnName = "Optimum Level";
                                dtCTTReport.AcceptChanges();

                                dvErrorGrid.Attributes.Add("style", "display:block; overflow-y:auto; height:210px;");
                                pnlImportExport.Attributes.Add("style", "height:580px; width:700px; top:-14px !important;");

                                mpeUserMst.Show();
                                lblImportErrorMsg.Text = "Below Stock List can not be created, kindly check error message.";
                                gvImportError.DataSource = dtCTTReport;
                                gvImportError.DataBind();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Cocktail_Code_Import()
        {
            DataSet dsResult = new DataSet();
            if (FU_Category.HasFile && FU_Category.PostedFile != null)
            {
                try
                {
                    string path = string.Concat(Server.MapPath("~/Cocktail_World/ImportFile/" + FU_Category.FileName));
                    string extension = Path.GetExtension(FU_Category.PostedFile.FileName);
                    FU_Category.SaveAs(path);

                    // Connection String to Excel Workbook  
                    string conString = string.Empty;
                    switch (extension)
                    {
                        case ".xls": //For Excel 97-03.  
                            conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                            break;
                        case ".xlsx": //For Excel 07 and above.  
                            conString = ConfigurationManager.ConnectionStrings["Excel07+ConString"].ConnectionString;
                            break;
                    }
                    string excelCS = string.Format(conString, path);

                    using (OleDbConnection con = new OleDbConnection(excelCS))
                    {
                        OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", con);
                        con.Open();
                        // Create DbDataReader to Data Worksheet  
                        DbDataReader dr = cmd.ExecuteReader();
                        // SQL Server Connection String  
                        string CS = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString;
                        // Bulk Copy to SQL Server   
                        SqlBulkCopy bulkInsert = new SqlBulkCopy(CS);
                        bulkInsert.DestinationTableName = "Tbl_CW_BrandOpeningStock_Temp_Import";
                        bulkInsert.ColumnMappings.Add("License Name", "License_Name");
                        bulkInsert.ColumnMappings.Add("Category", "Category");
                        bulkInsert.ColumnMappings.Add("Brand Name", "Brand_Name");
                        bulkInsert.ColumnMappings.Add("Size", "Size");
                        bulkInsert.ColumnMappings.Add("Bottle Qty", "Bottle_Qty");
                        bulkInsert.ColumnMappings.Add("Speg Qty", "Speg_Qty");
                        bulkInsert.ColumnMappings.Add("Bottle Rate", "Bottle_Rate");
                        bulkInsert.ColumnMappings.Add("Base Qty", "Base_Qty");
                        bulkInsert.ColumnMappings.Add("Re-Order Level", "Re_Order_Level");
                        bulkInsert.ColumnMappings.Add("Optimum Level", "Optimum_Level");
                        bulkInsert.WriteToServer(dr);

                        dsResult = ObjCocktailWorld.Import_BrandOpeningStock(CompanyID, LoggedInUserID);

                        if (dsResult.Tables.Count > 0)
                        {
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                DataTable dtCTTReport = new DataTable();
                                dtCTTReport = dsResult.Tables[0];
                                dtCTTReport.Columns["License_Name"].ColumnName = "License";
                                dtCTTReport.Columns["Category"].ColumnName = "Category";
                                dtCTTReport.Columns["Brand_Name"].ColumnName = "Brand";
                                dtCTTReport.Columns["Size"].ColumnName = "Size";
                                dtCTTReport.Columns["Bottle_Qty"].ColumnName = "Bottle Qty";
                                dtCTTReport.Columns["Speg_Qty"].ColumnName = "Speg Qty";
                                dtCTTReport.Columns["Bottle_Rate"].ColumnName = "Bottle Rate";
                                dtCTTReport.Columns["Base_Qty"].ColumnName = "Base Qty";
                                dtCTTReport.Columns["Re_Order_Level"].ColumnName = "Re-Order Level";
                                dtCTTReport.Columns["Optimum_Level"].ColumnName = "Optimum Level";
                                dtCTTReport.AcceptChanges();

                                dvErrorGrid.Attributes.Add("style", "display:block; overflow-y:auto; height:210px;");
                                pnlImportExport.Attributes.Add("style", "height:580px; width:700px; top:-14px !important;");

                                mpeUserMst.Show();
                                lblImportErrorMsg.Text = "Below Stock List can not be created, kindly check error message.";
                                gvImportError.DataSource = dtCTTReport;
                                gvImportError.DataBind();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Cocktail_Import()
        {
            DataSet dsResult = new DataSet();
            if (FU_Category.HasFile && FU_Category.PostedFile != null)
            {
                try
                {
                    string path = string.Concat(Server.MapPath("~/Cocktail_World/ImportFile/" + FU_Category.FileName));
                    string extension = Path.GetExtension(FU_Category.PostedFile.FileName);
                    FU_Category.SaveAs(path);

                    // Connection String to Excel Workbook  
                    string conString = string.Empty;
                    switch (extension)
                    {
                        case ".xls": //For Excel 97-03.  
                            conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                            break;
                        case ".xlsx": //For Excel 07 and above.  
                            conString = ConfigurationManager.ConnectionStrings["Excel07+ConString"].ConnectionString;
                            break;
                    }
                    string excelCS = string.Format(conString, path);

                    using (OleDbConnection con = new OleDbConnection(excelCS))
                    {
                        OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", con);
                        con.Open();
                        // Create DbDataReader to Data Worksheet  
                        DbDataReader dr = cmd.ExecuteReader();
                        // SQL Server Connection String  
                        string CS = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString;
                        // Bulk Copy to SQL Server   
                        SqlBulkCopy bulkInsert = new SqlBulkCopy(CS);
                        bulkInsert.DestinationTableName = "Tbl_CW_BrandOpeningStock_Temp_Import";
                        bulkInsert.ColumnMappings.Add("License Name", "License_Name");
                        bulkInsert.ColumnMappings.Add("Category", "Category");
                        bulkInsert.ColumnMappings.Add("Brand Name", "Brand_Name");
                        bulkInsert.ColumnMappings.Add("Size", "Size");
                        bulkInsert.ColumnMappings.Add("Bottle Qty", "Bottle_Qty");
                        bulkInsert.ColumnMappings.Add("Speg Qty", "Speg_Qty");
                        bulkInsert.ColumnMappings.Add("Bottle Rate", "Bottle_Rate");
                        bulkInsert.ColumnMappings.Add("Base Qty", "Base_Qty");
                        bulkInsert.ColumnMappings.Add("Re-Order Level", "Re_Order_Level");
                        bulkInsert.ColumnMappings.Add("Optimum Level", "Optimum_Level");
                        bulkInsert.WriteToServer(dr);

                        dsResult = ObjCocktailWorld.Import_BrandOpeningStock(CompanyID, LoggedInUserID);

                        if (dsResult.Tables.Count > 0)
                        {
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                DataTable dtCTTReport = new DataTable();
                                dtCTTReport = dsResult.Tables[0];
                                dtCTTReport.Columns["License_Name"].ColumnName = "License";
                                dtCTTReport.Columns["Category"].ColumnName = "Category";
                                dtCTTReport.Columns["Brand_Name"].ColumnName = "Brand";
                                dtCTTReport.Columns["Size"].ColumnName = "Size";
                                dtCTTReport.Columns["Bottle_Qty"].ColumnName = "Bottle Qty";
                                dtCTTReport.Columns["Speg_Qty"].ColumnName = "Speg Qty";
                                dtCTTReport.Columns["Bottle_Rate"].ColumnName = "Bottle Rate";
                                dtCTTReport.Columns["Base_Qty"].ColumnName = "Base Qty";
                                dtCTTReport.Columns["Re_Order_Level"].ColumnName = "Re-Order Level";
                                dtCTTReport.Columns["Optimum_Level"].ColumnName = "Optimum Level";
                                dtCTTReport.AcceptChanges();

                                dvErrorGrid.Attributes.Add("style", "display:block; overflow-y:auto; height:210px;");
                                pnlImportExport.Attributes.Add("style", "height:580px; width:700px; top:-14px !important;");

                                mpeUserMst.Show();
                                lblImportErrorMsg.Text = "Below Stock List can not be created, kindly check error message.";
                                gvImportError.DataSource = dtCTTReport;
                                gvImportError.DataBind();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void btnCloseImportPopUp_Click(object sender, EventArgs e)
        {
            lblImportErrorMsg.Text = "";
            gvImportError.DataSource = null;
            gvImportError.DataBind();
            mpeUserMst.Hide();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {

                string filePath = string.Empty;
                string filename = string.Empty;
                string name = ddlMaster.SelectedItem.ToString();

                if (name == "Brand")
                {
                    filePath = "~/Cocktail_World/Template/Brand.xlsx";
                    filename = "Brand Opening Stock.xlsx";
                }
                if (name == "Supplier")
                {
                    filePath = "~/Cocktail_World/Template/Supplier.xlsx";
                    filename = "Brand Opening Stock.xlsx";
                }
                if (name == "Brand Opening")
                {
                    filePath = "~/Cocktail_World/Template/Brand Opening Stock.xlsx";
                    filename = "Brand Opening Stock.xlsx";
                }
                if (name == "Brand Code")
                {
                    filePath = "~/Cocktail_World/Template/Brand Code.xlsx";
                    filename = "Brand Opening Stock.xlsx";
                }
                if (name == "Cocktail Code")
                {
                    filePath = "~/Cocktail_World/Template/Cocktail Code.xlsx";
                    filename = "Brand Opening Stock.xlsx";
                }
                if (name == "Cocktail")
                {
                    filePath = "~/Cocktail_World/Template/Cocktail.xlsx";
                    filename = "Brand Opening Stock.xlsx";
                }

                Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");
                Response.TransmitFile(Server.MapPath(filePath));
                Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlMaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLicense.SelectedIndex > 0 && ddlMaster.SelectedIndex > 0)
            {
                btnImportExcelPopup.Visible = true;
            }
            else
            {
                btnImportExcelPopup.Visible = false;
            }
        }
    }
}