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


    public DataSet FetchTaxDetails(int Brand_ID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;

            ds = ObjcocktailWorld_Master_BL.FetchTaxDetails(Brand_ID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet BrandOpeningMaster_CRUD(int Opening_ID, decimal Closing_Bottle, decimal Closing_Speg, string Action, int LoggedInUser, int Company_ID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;

            ds = ObjcocktailWorld_Master_BL.BrandOpeningMaster_CRUD(Opening_ID, Closing_Bottle, Closing_Speg, Action, LoggedInUser, Company_ID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet SaleDetailsMaster_Crud(int Sale_ID,string Brand_Desc, string Size_Desc, string Cocktail_Desc, int Opening_ID, string TaxType, decimal Bottle_Qty, decimal Bottle_Rate, decimal SPeg_Qty, decimal SPeg_Rate, decimal LPeg_Qty, decimal LPeg_Rate, decimal TaxAmount, decimal Amount, int Permit_Holder,int License_ID, string Action, int LoggedInUser, int Company_ID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;

            ds = ObjcocktailWorld_Master_BL.SaleDetailsMaster_Crud(Sale_ID,Brand_Desc,  Size_Desc,  Cocktail_Desc, Opening_ID, TaxType, Bottle_Qty, Bottle_Rate, SPeg_Qty, SPeg_Rate, LPeg_Qty, LPeg_Rate, TaxAmount, Amount,Permit_Holder,License_ID,Action, LoggedInUser, Company_ID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataSet SaleMaster_Crud(string date, string Bill_No, int license, string Action, int LoggedInUser, int Company_ID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;

            ds = ObjcocktailWorld_Master_BL.SaleMaster_Crud(date, Bill_No, license, Action, LoggedInUser, Company_ID, StrConn);
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
            string strOutput = string.Empty;

            ds = ObjcocktailWorld_Master_BL.Category_CRUD(Company_ID, Category_ID, Category_Desc, Category_Alias, LoggedInUserID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


    public DataSet FetchCategorySizeLinkup(int Category_ID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;

            ds = ObjcocktailWorld_Master_BL.FetchCategory_SizeLinkup(Category_ID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataSet FetchBrandSizeLinkup(int Category_ID, int Brand_ID, int Size_ID,string Brand_Desc,string Size_Desc,int Company_ID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;

            ds = ObjcocktailWorld_Master_BL.FetchBrand_SizeLinkup(Category_ID, Brand_ID, Size_ID,Brand_Desc,Size_Desc,Company_ID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataSet Fetch_Brand_Opening(int Cat_Size_ID,int Opening_ID, int Brand_ID,string Brand_Desc,string Cocktail_Desc, int Company_ID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;

            ds = ObjcocktailWorld_Master_BL.Fetch_Brand_Opening(Cat_Size_ID,Opening_ID, Brand_ID, Brand_Desc,Cocktail_Desc, Company_ID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public DataSet BrandMaster_CRUD(int Company_ID, int Brand_ID, int Category_ID, int SubCategory_ID, string Brand_Desc, int Strength, int Purchase_Rate_Peg, int Selling_Rate_Peg, int Selling_Rate_Bottle, int Is_Disabled, string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjcocktailWorld_Master_BL.BrandMaster_CRUD(Company_ID, Brand_ID, Category_ID, SubCategory_ID, Brand_Desc, Strength, Purchase_Rate_Peg, Selling_Rate_Peg, Selling_Rate_Bottle, Is_Disabled, LoggedInUserID, Action, StrConn);
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
            string strOutput = string.Empty;
            ds = ObjcocktailWorld_Master_BL.SizeMaster_CRUD(Size_ID, Size_Desc, Size_Alias, LoggedInUserID, Company_ID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataSet Fetch_Category_Brand(int CompanyID, int CategoryID)
    {
        try
        {
            StrConn = System.Configuration.ConfigurationManager.ConnectionStrings["CocktailWorld_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            ds = ObjcocktailWorld_Master_BL.Fetch_Category_Brand(CompanyID, CategoryID, StrConn);
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
            string strOutput = string.Empty;

            ds = ObjcocktailWorld_Master_BL.SubCategory_CRUD(SubCategory_ID, Category_ID, SubCategory_Desc, LoggedInUserID, Company_ID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataSet PermitMaster_CRUD(int Permit_ID, string Permit_Desc, string LoggedInUserID, int Company_ID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;

            ds = ObjcocktailWorld_Master_BL.PermitMaster_CRUD(Permit_ID, Permit_Desc, LoggedInUserID, Company_ID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataSet CocktailMaster_CRUD(string Category_Desc, string Rate, int Company_ID, string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;

            ds = ObjcocktailWorld_Master_BL.CocktailMaster_CRUD(Category_Desc, Rate, Company_ID, LoggedInUserID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataSet CocktailBrandsMaster_CRUD(int Cocktail_ID, int Brand_ID, int Pegml, int Size, int Company_ID, string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;

            ds = ObjcocktailWorld_Master_BL.CocktailBrandsMaster_CRUD(Cocktail_ID, Brand_ID, Pegml, Size, Company_ID, LoggedInUserID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


    public DataSet Fetch_Cocktail_Brand_Details(string Cocktail_Desc, int Company_ID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;

            ds = ObjcocktailWorld_Master_BL.Fetch_Cocktail_Brand_Details(Cocktail_Desc, Company_ID,StrConn);
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
            string strOutput = string.Empty;

            ds = ObjcocktailWorld_Master_BL.Save_CategorySizeLinkup(CategoryID, CategoryDetails, LicenseID, CompanyID, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataSet Save_BrandOpening(int Opening_ID, string CategoryDetails, int BrandID, int CompanyID, string LoggedInUserID, string Operation)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;

            ds = ObjcocktailWorld_Master_BL.Save_BrandOpening(Opening_ID, CategoryDetails, BrandID, CompanyID, LoggedInUserID, Operation, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet License(string LoggedInUserID, int Company_ID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;

            ds = ObjcocktailWorld_Master_BL.License(LoggedInUserID, Company_ID, Action, StrConn);
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
            string strOutput = string.Empty;
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
            string strOutput = string.Empty;
            ds = ObjcocktailWorld_Master_BL.Fetch_Test_Dataset_RDLC( StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }




}