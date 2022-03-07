using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Data;
using System.IO;
/// <summary>
/// Summary description for CocktailWorld_Service
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class CocktailWorld_Service : System.Web.Services.WebService
{
    My_CocktailWorld ObjCocktailWorld = new My_CocktailWorld();
    DataSet ds = new DataSet();

    public CocktailWorld_Service()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    #region RDLC Reports

    [WebMethod]
    public DataSet Fetch_Flr6Data()
    {
        try
        {
            ds = ObjCocktailWorld.Fetch_Flr6Data();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_FLR3LegalReport()
    {
        try
        {
            ds = ObjCocktailWorld.Fetch_FLR3LegalReport();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_CashMemo()
    {
        try
        {
            ds = ObjCocktailWorld.Fetch_CashMemo();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_FetchCostValuation_Report()
    {
        try
        {
            ds = ObjCocktailWorld.Fetch_FetchCostValuation_Report();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Flr4Data()
    {
        try
        {
            ds = ObjCocktailWorld.Fetch_Flr4Data();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_FetchFlr6Data()
    {
        try
        {
            ds = ObjCocktailWorld.Fetch_FetchFlr6Data();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    #endregion


    #region Reports
    [WebMethod]
    public DataSet Fetch_Sales_Report(string License, string From_Date, string To_Date, string Brand, string Category)
    {
        try
        {
            ds = ObjCocktailWorld.Fetch_Sales_Report(License, From_Date, To_Date, Brand, Category);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Purchase_Report(string License, string From_Date, string To_Date, string Brand, string Category)
    {
        try
        {
            ds = ObjCocktailWorld.Fetch_Purchase_Report(License, From_Date, To_Date, Brand, Category);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Transfer_Report(string License, string From_Date, string To_Date, string Brand, string Category)
    {
        try
        {
            ds = ObjCocktailWorld.Fetch_Transfer_Report(License, From_Date, To_Date, Brand, Category);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Cost_Report(string License, string From_Date, string To_Date, string Brand, string Category)
    {
        try
        {
            ds = ObjCocktailWorld.Fetch_Cost_Report(License, From_Date, To_Date, Brand, Category);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_SlowMovingQty_Report(string License, string From_Date, string To_Date, string Brand, string Category)
    {
        try
        {
            ds = ObjCocktailWorld.Fetch_SlowMovingQty_Report(License, From_Date, To_Date, Brand, Category);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_NonMovingQty_Report(string License, string From_Date, string To_Date, string Brand, string Category)
    {
        try
        {
            ds = ObjCocktailWorld.Fetch_NonMovingQty_Report(License, From_Date, To_Date, Brand, Category);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_CocktailSale_Report(string License, string From_Date, string To_Date, string Brand, string Category)
    {
        try
        {
            ds = ObjCocktailWorld.Fetch_CocktailSale_Report(License, From_Date, To_Date, Brand, Category);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_BulkLitre_Report(string License, string From_Date, string To_Date, string Brand, string Category)
    {
        try
        {
            ds = ObjCocktailWorld.Fetch_BulkLitre_Report(License, From_Date, To_Date, Brand, Category);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_BaseQuantity_Report(string License, string From_Date, string To_Date, string Brand, string Category)
    {
        try
        {
            ds = ObjCocktailWorld.Fetch_BaseQuantity_Report(License, From_Date, To_Date, Brand, Category);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Abstract_Report(string License, string From_Date, string To_Date, string Brand, string Category)
    {
        try
        {
            ds = ObjCocktailWorld.Fetch_Abstract_Report(License, From_Date, To_Date, Brand, Category);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_BrandSummary_Report(string License, string From_Date, string To_Date, string Brand, string Category)
    {
        try
        {
            ds = ObjCocktailWorld.Fetch_BrandSummary_Report(License, From_Date, To_Date, Brand, Category);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Chatai_Report(string License, string From_Date, string To_Date, string Brand, string Category)
    {
        try
        {
            ds = ObjCocktailWorld.Fetch_Chatai_Report(License, From_Date, To_Date, Brand, Category);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_OptimumQuantity_Report(string License, string From_Date, string To_Date, string Brand, string Category)
    {
        try
        {
            ds = ObjCocktailWorld.Fetch_OptimumQuantity_Report(License, From_Date, To_Date, Brand, Category);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    #endregion

    [WebMethod]
    public DataSet FetchTaxDetails(int Brand_ID)
    {
        try
        {
            ds = ObjCocktailWorld.FetchTaxDetails(Brand_ID);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet BrandOpeningMaster_CRUD(int BrandOpening_ID, string CategoryDetails, int BrandID, decimal closingBottle, decimal closingSpeg, int License_ID, int Company_ID, string LoggedInUser, string Action)
    {
        try
        {
            ds = ObjCocktailWorld.BrandOpeningMaster_CRUD(BrandOpening_ID, CategoryDetails, BrandID, closingBottle, closingSpeg,License_ID, Company_ID, LoggedInUser, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet PurchaseMaster_CRUD(int Purchase_ID, int Supplier_ID, string TP_No, string Invoice_No, string Purchase_Date, decimal Other_Charges,
            decimal Discount_Percentage, int License_ID, int Company_ID, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjCocktailWorld.PurchaseMaster_CRUD(Purchase_ID, Supplier_ID, TP_No, Invoice_No, Purchase_Date, Other_Charges,
             Discount_Percentage, License_ID, Company_ID, LoggedInUserID, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet TransferMaster_CRUD(int Transfer_ID, string TransferDate, string TP_No, string Invoice_No, string FL_IV, string Is_Show_Excise,
            int Trasnfer_To_LicenseID, int License_ID, string LoggedInUserID, int Company_ID, string Action)
    {
        try
        {
            ds = ObjCocktailWorld.TransferMaster_CRUD(Transfer_ID, TransferDate, TP_No, Invoice_No, FL_IV, Is_Show_Excise, Trasnfer_To_LicenseID, License_ID, LoggedInUserID, Company_ID, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet PurchaseDetailsMaster_CRUD(int Purchase_ID, int Brand_Opening_ID, string Brand_Desc, string Size_Desc, decimal Bottle_Qty, decimal Bottle_Rate
            , decimal Speg_Qty, decimal Speg_Rate, int Free_Qty, int No_Of_Boxes, int Batch_No, string Mfg, string Tax_Type, decimal Tax_Amt, decimal Total_Amt
            , int License_ID, int Company_ID, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjCocktailWorld.PurchaseDetailsMaster_CRUD(Purchase_ID, Brand_Opening_ID, Brand_Desc, Size_Desc, Bottle_Qty, Bottle_Rate
            , Speg_Qty, Speg_Rate, Free_Qty, No_Of_Boxes, Batch_No, Mfg, Tax_Type, Tax_Amt, Total_Amt
            , License_ID, Company_ID, LoggedInUserID, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet TransferDetailsMaster_CRUD(int Transfer_ID, string Transfer_Against, string TP_No, int Brand_Opening_ID, string MfgDate, string Boxes, string BatchNo, decimal Speg_Qty, decimal Speg_Rate
        , decimal Bottle_Qty, decimal Bottle_Rate, int License_ID, int Company_ID, string LoggedInUserID, string Created_By, string Created_Date, string Action)
    {
        try
        {
            ds = ObjCocktailWorld.TransferDetailsMaster_CRUD(Transfer_ID, Transfer_Against, TP_No, Brand_Opening_ID, MfgDate, Boxes, BatchNo, Speg_Qty, Speg_Rate, Bottle_Qty, Bottle_Rate, License_ID, Company_ID, LoggedInUserID, Created_By, Created_Date, Action);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet SaleDetailsMaster_Crud(int Sale_ID, int SaleDetail_ID, string Brand_Desc, string Size_Desc, string Cocktail_Desc, int Opening_ID, string TaxType, decimal Bottle_Qty, decimal Bottle_Rate, decimal SPeg_Qty, decimal SPeg_Rate, decimal LPeg_Qty, decimal LPeg_Rate, decimal TaxAmount, decimal Amount, int Permit_Holder, int License_ID, string Action, int LoggedInUser, int Company_ID)
    {
        try
        {
            ds = ObjCocktailWorld.SaleDetailsMaster_Crud(Sale_ID, SaleDetail_ID, Brand_Desc, Size_Desc, Cocktail_Desc, Opening_ID, TaxType, Bottle_Qty, Bottle_Rate, SPeg_Qty, SPeg_Rate, LPeg_Qty, LPeg_Rate, TaxAmount, Amount, Permit_Holder, License_ID, Action, LoggedInUser, Company_ID);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet SaleMaster_Crud(int Sale_ID, string date, string Bill_No, int license, string Action, int LoggedInUser, int Company_ID, bool Is_Auto_Bill)
    {
        try
        {
            ds = ObjCocktailWorld.SaleMaster_Crud(Sale_ID, date, Bill_No, license, Action, LoggedInUser, Company_ID, Is_Auto_Bill);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet BillBook_Crud(int Bill_ID, string Bill_Start_No, string Bill_End_No, string License_No, string Action, string LoggedInUser, int Company_ID)
    {
        try
        {
            ds = ObjCocktailWorld.BillBook_Crud(Bill_ID, Bill_Start_No, Bill_End_No, License_No, Action, LoggedInUser, Company_ID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet CategoryMaster_CRUD(int Company_ID, int Category_ID, string Category_Desc, string Category_Alias, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjCocktailWorld.CategoryMaster_CRUD(Company_ID, Category_ID, Category_Desc, Category_Alias, LoggedInUserID, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Category_Brand(int CompanyId, int CategoryID)   //Added CompanyId by sujata
    {
        try
        {
            ds = ObjCocktailWorld.Fetch_Category_Brand(CompanyId, CategoryID);
        }
        catch (Exception ex)
        {
            throw ex;

        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Brand_Opening(int Cat_Size_ID, int Opening_ID, int BrandID, string Brand_Desc, string Size_Desc, string Cocktail_Desc, int CompanyID,string License_ID)   //Added CompanyId by sujata
    {
        try
        {
            ds = ObjCocktailWorld.Fetch_Brand_Opening(Cat_Size_ID, Opening_ID, BrandID, Brand_Desc, Size_Desc, Cocktail_Desc, CompanyID,License_ID);
        }
        catch (Exception ex)
        {
            throw ex;

        }
        return ds;
    }


    [WebMethod]
    public DataSet Fetch_CategorySizeLinkup(int Size_ID , int Category_ID, int License_ID, int Company_ID)
    {
        try
        {
            ds = ObjCocktailWorld.Fetch_CategorySizeLinkup(Size_ID,Category_ID, License_ID, Company_ID);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet CocktailMaster_CRUD(int Cocktail_ID, string Category_Desc, string Rate, int Company_ID, string LoggedInUserID, int License_ID, string Action)
    {
        try
        {
            ds = ObjCocktailWorld.CocktailMaster_CRUD(Cocktail_ID, Category_Desc, Rate, Company_ID, LoggedInUserID,License_ID, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet CocktailBrandsMaster_CRUD(int Cocktail_Brand_ID, int Cocktail_ID, int Brand_ID, int Pegml, int Size, int Company_ID, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjCocktailWorld.CocktailBrandsMaster_CRUD(Cocktail_Brand_ID, Cocktail_ID, Brand_ID, Pegml, Size, Company_ID, LoggedInUserID, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet FetchBrandSizeLinkup(int Category_ID, int Brand_ID, int Size_ID, string Brand_Desc, string Size_Desc, int Company_ID, int License_ID, string Action,DateTime date)
    {
        try
        {
            ds = ObjCocktailWorld.FetchBrandSizeLinkup(Category_ID, Brand_ID, Size_ID, Brand_Desc, Size_Desc, Company_ID, License_ID,Action,date);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet BrandMaster_CRUD(int Company_ID, int Brand_ID, int Category_ID, int SubCategory_ID, string Brand_Desc, string Brand_Short_Name, int Strength, int Purchase_Rate_Peg, int Selling_Rate_Peg, int Selling_Rate_Bottle, int Is_Disabled,string Size,int Cocktail_ID, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjCocktailWorld.BrandMaster_CRUD(Company_ID, Brand_ID, Category_ID, SubCategory_ID, Brand_Desc, Brand_Short_Name, Strength, Purchase_Rate_Peg, Selling_Rate_Peg, Selling_Rate_Bottle, Is_Disabled, Size, Cocktail_ID, LoggedInUserID, Action);
        }
        catch (Exception ex)
        {
            throw ex;

        }
        return ds;


    }

    [WebMethod]
    public DataSet SizeMaster_CRUD(int Size_ID, string Size_Desc, int Size_Alias, string LoggedInUserID, int Company_ID, string Action)
    {
        try
        {
            ds = ObjCocktailWorld.SizeMaster_CRUD(Size_ID, Size_Desc, Size_Alias, LoggedInUserID, Company_ID, Action);
        }
        catch (Exception ex)
        {
            throw ex;

        }
        return ds;


    }


    [WebMethod]
    public DataSet SubCategoryMaster_CRUD(int SubCategory_ID, int Category_ID, string SubCategory_Desc, string LoggedInUserID, int Company_ID, string Action)
    {
        try
        {
            ds = ObjCocktailWorld.SubCategoryMaster_CRUD(SubCategory_ID, Category_ID, SubCategory_Desc, LoggedInUserID, Company_ID, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }



    [WebMethod]
    public DataSet PermitMaster_CRUD(int Permit_ID, string Permit_Type, string Permit_Holder, string Permit_Number, string Expire_Date, bool Life_Time, string LoggedInUserID, int CompanyID, string Action)
    {
        try
        {
            ds = ObjCocktailWorld.PermitMaster_CRUD(Permit_ID, Permit_Type, Permit_Holder, Permit_Number, Expire_Date, Life_Time, LoggedInUserID, CompanyID, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Save_CategorySizeLinkup(int CategoryID, string CategoryDetails, int LicenseID, int CompanyID, string LoggedInUserID)
    {
        try
        {
            ds = ObjCocktailWorld.Save_CategorySizeLinkup(CategoryID, CategoryDetails, LicenseID, CompanyID, LoggedInUserID);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet License_CRUD(int LicenseID, string LicenseName, string LicenseNo, string LoggedInUserID, int Company_ID, string Action)
    {
        try
        {
            ds = ObjCocktailWorld.License_CRUD(LicenseID, LicenseName, LicenseNo, LoggedInUserID, Company_ID, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet SupplierMaster_CRUD(int Supplier_ID, string SupplierName, string Code, int pincode, string Address, string Contact, string City, string Email, string LoggedInUserID, int Company_ID, string Action)
    {
        try
        {
            ds = ObjCocktailWorld.SupplierMaster_CRUD(Supplier_ID, SupplierName, Code, pincode, Address, Contact, City, Email, LoggedInUserID, Company_ID, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Test_Dataset_RDLC()
    {
        try
        {
            ds = ObjCocktailWorld.Fetch_Test_Dataset_RDLC();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }



}
