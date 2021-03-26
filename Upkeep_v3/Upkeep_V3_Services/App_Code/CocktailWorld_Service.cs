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


    [WebMethod]
    public DataSet CategoryMaster_CRUD(int Company_ID ,int Category_ID,string Category_Desc,string Category_Alias, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjCocktailWorld.CategoryMaster_CRUD(Company_ID,Category_ID,Category_Desc,Category_Alias,LoggedInUserID, Action);
           
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }



    [WebMethod]
    public DataSet FetchCategorySizeLinkup(int Category_ID)
    {
        try
        {
            ds = ObjCocktailWorld.FetchCategorySizeLinkup(Category_ID);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    [WebMethod]
    public DataSet BrandMaster_CRUD(int Company_ID,int Brand_ID,int Category_ID, int SubCategory_ID, string Brand_Desc, int Strength, int Purchase_Rate_Peg, int Selling_Rate_Peg , int Selling_Rate_Bottle, int Is_Disabled, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjCocktailWorld.BrandMaster_CRUD(Company_ID,Brand_ID, Category_ID, SubCategory_ID, Brand_Desc, Strength, Purchase_Rate_Peg, Selling_Rate_Peg, Selling_Rate_Bottle, Is_Disabled, LoggedInUserID, Action);
        }
        catch(Exception ex)
        {
            throw ex;

        }
        return ds;


    }







}
