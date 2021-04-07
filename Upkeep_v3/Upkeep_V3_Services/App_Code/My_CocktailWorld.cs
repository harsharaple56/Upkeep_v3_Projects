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

    public DataSet CategoryMaster_CRUD(int Company_ID, int Category_ID, string Category_Desc, string Category_Alias, string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;

            ds = ObjcocktailWorld_Master_BL.Category_CRUD( Company_ID,Category_ID,Category_Desc,Category_Alias,LoggedInUserID ,Action, StrConn);
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

    public DataSet BrandMaster_CRUD(int Company_ID, int Brand_ID, int Category_ID, int SubCategory_ID, string Brand_Desc, int Strength, int Purchase_Rate_Peg, int Selling_Rate_Peg, int Selling_Rate_Bottle, int Is_Disabled, string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Cocktailworld_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjcocktailWorld_Master_BL.BrandMaster_CRUD(Company_ID, Brand_ID, Category_ID, SubCategory_ID, Brand_Desc, Strength, Purchase_Rate_Peg, Selling_Rate_Peg, Selling_Rate_Bottle, Is_Disabled, LoggedInUserID, Action, StrConn);
            return ds;
        }
        catch(Exception ex)
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
            ds = ObjcocktailWorld_Master_BL.SizeMaster_CRUD(Size_ID, Size_Desc, Size_Alias, LoggedInUserID, Company_ID, Action ,StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }





    public DataSet SubCategoryMaster_CRUD(int SubCategory_ID , int Category_ID, string SubCategory_Desc, string LoggedInUserID, int Company_ID, string Action)
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

}