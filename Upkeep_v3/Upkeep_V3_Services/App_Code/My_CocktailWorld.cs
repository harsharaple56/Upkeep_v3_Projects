using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using UpkeepV3_BusinessLayer;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for My_CocktailWorld
/// </summary>
public class My_CocktailWorld
{

    UpkeepV3_BusinessLayer.CocktailWorld_Master_BL ObjcocktailWorld_Master_BL = new UpkeepV3_BusinessLayer.CocktailWorld_Master_BL();


    String StrConn;
    DataSet ds = new DataSet();

    public My_CocktailWorld()
    {


        // TODO: Add constructor logic here
        //

    }

    #region RDLC Reports
    public DataSet Fetch_CashMemo(int License_ID, string From_Date, string To_Date)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.Fetch_CashMemo(License_ID, From_Date, To_Date, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_Flr4Data()
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.Fetch_Flr4Data(StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_Flr6Data(int Company_ID, string Date, string License_ID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.Fetch_Flr6Data(Company_ID, Date, License_ID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_FLR3LegalReport(int Company_ID, string Date, string License_ID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.Fetch_FLR3LegalReport(Company_ID, Date, License_ID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_FetchCostValuation_Report()
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.Fetch_FetchCostValuation_Report(StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    #endregion

    #region Reports
    public DataSet Fetch_Sales_Report(string License, string From_Date, string To_Date, string Brand, string Category)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.Fetch_Sales_Report(License, From_Date, To_Date, Brand, Category, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_Purchase_Report(string License, string From_Date, string To_Date, string Brand, string Category)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.Fetch_Purchase_Report(License, From_Date, To_Date, Brand, Category, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_Transfer_Report(string License, string From_Date, string To_Date, string Brand, string Category)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.Fetch_Transfer_Report(License, From_Date, To_Date, Brand, Category, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_Cost_Report(string License, string From_Date, string To_Date, string Brand, string Category)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.Fetch_Cost_Report(License, From_Date, To_Date, Brand, Category, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_SlowMovingQty_Report(string License, string From_Date, string To_Date, string Brand, string Category)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.Fetch_SlowMovingQty_Report(License, From_Date, To_Date, Brand, Category, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_NonMovingQty_Report(string License, string From_Date, string To_Date, string Brand, string Category)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.Fetch_NonMovingQty_Report(License, From_Date, To_Date, Brand, Category, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_CocktailSale_Report(string License, string From_Date, string To_Date, string Brand, string Category)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.Fetch_CocktailSale_Report(License, From_Date, To_Date, Brand, Category, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_BulkLitre_Report(string License, string From_Date, string To_Date, string Brand, string Category)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.Fetch_BulkLitre_Report(License, From_Date, To_Date, Brand, Category, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_BaseQuantity_Report(string License, string From_Date, string To_Date, string Brand, string Category)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.Fetch_BaseQuantity_Report(License, From_Date, To_Date, Brand, Category, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_Abstract_Report(string License, string From_Date, string To_Date, string Brand, string Category)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.Fetch_Abstract_Report(License, From_Date, To_Date, Brand, Category, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_BrandSummary_Report(int LicenseID, string From_Date, string To_Date, bool Brandwise, bool Categorywise, bool SubCategorywise, bool IsBulkLitre)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.Fetch_BrandSummary_Report(LicenseID, From_Date, To_Date, Brandwise, Categorywise, SubCategorywise, IsBulkLitre, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_Chatai_Report(int LicenseID, string From_Date, string To_Date)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.Fetch_Chatai_Report(LicenseID, From_Date, To_Date, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_OptimumQuantity_Report(string License, string From_Date, string To_Date, string Brand, string Category)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.Fetch_OptimumQuantity_Report(License, From_Date, To_Date, Brand, Category, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    #endregion

    #region Imports Method Of Cocktail World
    public DataSet Import_BrandOpeningStock(int CompanyID, string LoggedInUserID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.Import_BrandOpeningStock(CompanyID, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion
    public DataSet Validate_NegativeStockNew(int licenseid, DateTime date, int Bill_No, int BrandOpeningID, decimal Bottle_Qty, decimal Bottle_Rate, decimal SPeg_Qty, decimal SPeg_Rate, decimal LPeg_Qty, decimal LPeg_Rate, decimal CategorytaxID, decimal Taxper, decimal TotalAmount)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.Validate_NegativeStockNew(licenseid, date, Bill_No, BrandOpeningID, Bottle_Qty, Bottle_Rate, SPeg_Qty, SPeg_Rate, LPeg_Qty, LPeg_Rate, CategorytaxID, Taxper, TotalAmount, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataSet FetchTaxDetails(int Brand_ID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.FetchTaxDetails(Brand_ID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet BrandOpeningMaster_CRUD(int BrandOpening_ID, string CategoryDetails, int BrandID, decimal closingBottle, decimal closingSpeg, int License_ID, int Company_ID, string LoggedInUser, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.BrandOpeningMaster_CRUD(BrandOpening_ID, CategoryDetails, BrandID, closingBottle, closingSpeg, License_ID, Company_ID, LoggedInUser, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet PurchaseMaster_CRUD(int Purchase_ID, int Supplier_ID, string TP_No, string Invoice_No, string Purchase_Date, decimal Other_Charges,
            decimal Discount_Percentage, int License_ID, int Company_ID, string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.PurchaseMaster_CRUD(Purchase_ID, Supplier_ID, TP_No, Invoice_No, Purchase_Date, Other_Charges,
             Discount_Percentage, License_ID, Company_ID, LoggedInUserID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet TransferMaster_CRUD(int Transfer_ID, string TransferDate, string TP_No, string Invoice_No, string FL_IV, string Is_Show_Excise,
            int Trasnfer_To_LicenseID, int License_ID, string LoggedInUserID, int Company_ID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.TransferMaster_CRUD(Transfer_ID, TransferDate, TP_No, Invoice_No, FL_IV, Is_Show_Excise, Trasnfer_To_LicenseID, License_ID, LoggedInUserID, Company_ID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet PurchaseDetailsMaster_CRUD(int Purchase_ID, int Brand_Opening_ID, string Brand_Desc, string Size_Desc, decimal Bottle_Qty, decimal Bottle_Rate
            , decimal Speg_Qty, decimal Speg_Rate, int Free_Qty, int No_Of_Boxes, int Batch_No, string Mfg, string Tax_Type, decimal Tax_Amt, decimal Total_Amt
            , int License_ID, int Company_ID, string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.PurchaseDetailsMaster_CRUD(Purchase_ID, Brand_Opening_ID, Brand_Desc, Size_Desc, Bottle_Qty, Bottle_Rate
            , Speg_Qty, Speg_Rate, Free_Qty, No_Of_Boxes, Batch_No, Mfg, Tax_Type, Tax_Amt, Total_Amt
            , License_ID, Company_ID, LoggedInUserID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet TransferDetailsMaster_CRUD(int Transfer_ID, string Transfer_Against, string TP_No, int Brand_Opening_ID, string MfgDate, string Boxes, string BatchNo, decimal Speg_Qty, decimal Speg_Rate
        , decimal Bottle_Qty, decimal Bottle_Rate, int License_ID, int Company_ID, string LoggedInUserID, string Created_By, string Created_Date, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.TransferDetailsMaster_CRUD(Transfer_ID, Transfer_Against, TP_No, Brand_Opening_ID, MfgDate, Boxes, BatchNo, Speg_Qty, Speg_Rate, Bottle_Qty, Bottle_Rate, License_ID, Company_ID, LoggedInUserID, Created_By, Created_Date, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet SaleDetailsMaster_Crud(int Sale_ID, int SaleDetail_ID, int Bill_No, string Brand_Desc, string Size_Desc, string Cocktail_Desc, int Opening_ID, string TaxType, decimal Bottle_Qty, decimal Bottle_Rate, decimal SPeg_Qty, decimal SPeg_Rate, decimal LPeg_Qty, decimal LPeg_Rate, decimal TaxAmount, decimal Amount, int Permit_Holder, int License_ID, string Action, int LoggedInUser, int Company_ID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.SaleDetailsMaster_Crud(Sale_ID, SaleDetail_ID, Bill_No, Brand_Desc, Size_Desc, Cocktail_Desc, Opening_ID, TaxType, Bottle_Qty, Bottle_Rate, SPeg_Qty, SPeg_Rate, LPeg_Qty, LPeg_Rate, TaxAmount, Amount, Permit_Holder, License_ID, Action, LoggedInUser, Company_ID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataSet SaleMaster_Crud(int Sale_ID, string date, string Bill_No, int license, string Action, int LoggedInUser, int Company_ID, bool Is_Auto_Bill)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.SaleMaster_Crud(Sale_ID, date, Bill_No, license, Action, LoggedInUser, Company_ID, Is_Auto_Bill, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet BillBook_Crud(int Bill_ID, string Bill_Start_No, string Bill_End_No, string License_No, string Action, string LoggedInUser, int Company_ID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.BillBook_Crud(Bill_ID, Bill_Start_No, Bill_End_No, License_No, Action, LoggedInUser, Company_ID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet CategoryMaster_CRUD(int Company_ID, int Category_ID, string Category_Desc, string Category_Alias, string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.CategoryMaster_CRUD(Company_ID, Category_ID, Category_Desc, Category_Alias, LoggedInUserID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


    public DataSet Fetch_CategorySizeLinkup(int Size_ID, int Category_ID, int License_ID, int Company_ID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.Fetch_CategorySizeLinkup(Size_ID, Category_ID, License_ID, Company_ID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataSet FetchBrandSizeLinkup(int Category_ID, int Brand_ID, int Size_ID, string Brand_Desc, string Size_Desc, int Company_ID, int License_ID, string Action, DateTime date)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.FetchBrand_SizeLinkup(Category_ID, Brand_ID, Size_ID, Brand_Desc, Size_Desc, Company_ID, License_ID, Action, date, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataSet Fetch_Brand_Opening(int Cat_Size_ID, int Opening_ID, int Brand_ID, string Brand_Desc, string Size_Desc, string Cocktail_Desc, int Company_ID, string License_ID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.Fetch_Brand_Opening(Cat_Size_ID, Opening_ID, Brand_ID, Brand_Desc, Size_Desc, Cocktail_Desc, Company_ID, License_ID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public DataSet BrandMaster_CRUD(int Company_ID, int Brand_ID, int Category_ID, int SubCategory_ID, string Brand_Desc, string Brand_Short_Name, int Strength, int Purchase_Rate_Peg, int Selling_Rate_Peg, int Selling_Rate_Bottle, int Is_Disabled, string Size, int Cocktail_ID, string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.BrandMaster_CRUD(Company_ID, Brand_ID, Category_ID, SubCategory_ID, Brand_Desc, Brand_Short_Name, Strength, Purchase_Rate_Peg, Selling_Rate_Peg, Selling_Rate_Bottle, Is_Disabled, Size, Cocktail_ID, LoggedInUserID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataSet SizeMaster_CRUD(int Size_ID, string Size_Desc, int Size_Alias, string LoggedInUserID, int Company_ID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.SizeMaster_CRUD(Size_ID, Size_Desc, Size_Alias, LoggedInUserID, Company_ID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataSet Fetch_Category_Brand(int CompanyID, int CategoryID, int BrandID)
    {
        try
        {
            StrConn = System.Configuration.ConfigurationManager.ConnectionStrings["CocktailWorld_ConString"].ConnectionString.ToString();
            DataSet ds = new DataSet();
            ds = ObjcocktailWorld_Master_BL.Fetch_Category_Brand(CompanyID, CategoryID, BrandID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet SubCategoryMaster_CRUD(int SubCategory_ID, int Category_ID, string SubCategory_Desc, string LoggedInUserID, int Company_ID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.SubCategory_CRUD(SubCategory_ID, Category_ID, SubCategory_Desc, LoggedInUserID, Company_ID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataSet PermitMaster_CRUD(int Permit_ID, string Permit_Type, string Permit_Holder, string Permit_Number, string Expire_Date, bool Life_Time, string LoggedInUserID, int CompanyID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.PermitMaster_CRUD(Permit_ID, Permit_Type, Permit_Holder, Permit_Number, Expire_Date, Life_Time, LoggedInUserID, CompanyID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataSet CocktailMaster_CRUD(int Cocktail_ID, string Category_Desc, string Rate, int Company_ID, string LoggedInUserID, int License_ID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.CocktailMaster_CRUD(Cocktail_ID, Category_Desc, Rate, Company_ID, LoggedInUserID, License_ID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataSet CocktailBrandsMaster_CRUD(int Cocktail_Brand_ID, int Cocktail_ID, int Brand_ID, int Pegml, int Size, int Company_ID, string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.CocktailBrandsMaster_CRUD(Cocktail_Brand_ID, Cocktail_ID, Brand_ID, Pegml, Size, Company_ID, LoggedInUserID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataSet Save_CategorySizeLinkup(int CategoryID, string CategoryDetails, int LicenseID, int CompanyID, string LoggedInUserID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.Save_CategorySizeLinkup(CategoryID, CategoryDetails, LicenseID, CompanyID, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataSet License_CRUD(int LicenseID, string LicenseName, string LicenseNo, string LoggedInUserID, int Company_ID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.License_CRUD(LicenseID, LicenseName, LicenseNo, LoggedInUserID, Company_ID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataSet SupplierMaster_CRUD(int Supplier_ID, string SupplierName, string Code, int pincode, string Address, string Contact, string City, string Email, string LoggedInUserID, int Company_ID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.SupplierMaster_CRUD(Supplier_ID, SupplierName, Code, pincode, Address, Contact, City, Email, LoggedInUserID, Company_ID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_Test_Dataset_RDLC()
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            ds = ObjcocktailWorld_Master_BL.Fetch_Test_Dataset_RDLC(StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }




}