using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using eFacilito_CompanyGroup_Portal_BL;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for My_eFacilito_CompanyGroup_Portal_Service
/// </summary>
public class My_eFacilito_CompanyGroup_Portal_Service
{
    eFacilito_CompanyGroup_Portal_BL.eFacilito_CompanyGroup_BL ObjUpkeepCC_BL = new eFacilito_CompanyGroup_Portal_BL.eFacilito_CompanyGroup_BL();
    string StrConn;
    DataSet ds = new DataSet();

    public My_eFacilito_CompanyGroup_Portal_Service()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public DataSet LoginUser(string UserName, string Password)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;

            ds = ObjUpkeepCC_BL.LoginUser(UserName, Password, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


    public DataSet Fetch_Group_Dashboard_Company_List(int Group_ID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;

            ds = ObjUpkeepCC_BL.Fetch_Group_Dashboard_Company_List(Group_ID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataSet Fetch_Group_Dashboard(int CompanyID, string LoggedInUserID, string Fromdate, string ToDate)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;

            ds = ObjUpkeepCC_BL.Fetch_Group_Dashboard(CompanyID, LoggedInUserID, Fromdate, ToDate,StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }



}