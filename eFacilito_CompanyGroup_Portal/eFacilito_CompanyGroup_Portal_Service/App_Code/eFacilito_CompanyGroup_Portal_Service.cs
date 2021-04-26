using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Data;
using System.IO;

/// <summary>
/// Summary description for eFacilito_CompanyGroup_Portal_Service
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class eFacilito_CompanyGroup_Portal_Service : System.Web.Services.WebService
{

    My_eFacilito_CompanyGroup_Portal_Service ObjUpkeep = new My_eFacilito_CompanyGroup_Portal_Service();
    DataSet ds = new DataSet();


    public eFacilito_CompanyGroup_Portal_Service()
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
    public DataSet Fetch_Group_Dashboard_Company_List(int Group_ID)
    {
        try
        {
            ds = ObjUpkeep.Fetch_Group_Dashboard_Company_List(Group_ID);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    [WebMethod]
    public DataSet LoginUser(string UserName, string Password)
    {
        try
        {
            ds = ObjUpkeep.LoginUser(UserName, Password);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }



    [WebMethod]
    public DataSet Fetch_Group_Dashboard(int CompanyID, string LoggedInUserID, string Fromdate, string ToDate)
    {
        try
        {
            ds = ObjUpkeep.Fetch_Group_Dashboard(CompanyID, LoggedInUserID, Fromdate, ToDate);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


}
