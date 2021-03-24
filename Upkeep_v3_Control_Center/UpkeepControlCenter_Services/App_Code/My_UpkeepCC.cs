using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Upkeep_BusinessLayer;

/// <summary>
/// Summary description for My_UpkeepCC
/// </summary>
public class My_UpkeepCC
{
    string strConn;
    public My_UpkeepCC()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet GroupMaster_CRUD(int Group_ID, string Group_Desc, string Group_Code, string LoggedInUserID, string Is_Deleted, string Action)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["UpkeepCC_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            Upkeep_BusinessLayer.UpkeepCC_BL objUpkeepCC_BL = new Upkeep_BusinessLayer.UpkeepCC_BL();
            ds = objUpkeepCC_BL.GroupMaster_CRUD(Group_ID, Group_Desc, Group_Code, LoggedInUserID, Is_Deleted, Action,strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Method for Invoices Management in Control Center
    public DataSet Invoices_CRUD(int Invoice_ID, string Invoice_No, string Invoice_Desc, String Invoice_Amount, String Invoice_GST, String GST_Type, string Invoice_Date, string Status, string Transaction_Details, int Company_ID, string Company_Desc, string Payment_Mode, string Nature_of_Invoice, string Billing_Name, string Due_date, string GSTIN, string Invoice_File_Path, string LoggedInUserID, string Action)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["UpkeepCC_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            Upkeep_BusinessLayer.UpkeepCC_BL objUpkeepCC_BL = new Upkeep_BusinessLayer.UpkeepCC_BL();
            ds = objUpkeepCC_BL.Invoices_CRUD(Invoice_ID, Invoice_No, Invoice_Desc, Invoice_Amount, Invoice_GST, GST_Type, Invoice_Date, Status, Transaction_Details, Company_ID, Company_Desc, Payment_Mode, Nature_of_Invoice, Billing_Name, Due_date, GSTIN, Invoice_File_Path, LoggedInUserID, Action, strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    public DataSet CC_Dashboard()
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["UpkeepCC_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            Upkeep_BusinessLayer.UpkeepCC_BL objUpkeepCC_BL = new Upkeep_BusinessLayer.UpkeepCC_BL();
            ds = objUpkeepCC_BL.CC_Dashboard(strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //public DataSet CC_Dashboard_Company()
    //{
    //    try
    //    {
    //        strConn = System.Configuration.ConfigurationManager.ConnectionStrings["UpkeepCC_ConString"].ConnectionString.ToString();
    //        string strOutput = string.Empty;
    //        DataSet ds = new DataSet();
    //        Upkeep_BusinessLayer.UpkeepCC_BL objUpkeepCC_BL = new Upkeep_BusinessLayer.UpkeepCC_BL();
    //        ds = objUpkeepCC_BL.CC_Dashboard_Company(strConn);

    //        return ds;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}



    public DataSet Fetch_GroupDesc()
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["UpkeepCC_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            Upkeep_BusinessLayer.UpkeepCC_BL objUpkeepCC_BL = new Upkeep_BusinessLayer.UpkeepCC_BL();
            ds = objUpkeepCC_BL.Fetch_GroupDesc(strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_CompanyDesc()
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["UpkeepCC_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            Upkeep_BusinessLayer.UpkeepCC_BL objUpkeepCC_BL = new Upkeep_BusinessLayer.UpkeepCC_BL();
            ds = objUpkeepCC_BL.Fetch_CompanyDesc(strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet CompanyMaster_CRUD(int CompanyID, string strCompanyCode, string strCompanyDesc, int GroupID, string CompanyLogo,string ClientURL, int Is_DBatClientServer, string ConString,string CompanyEmailID,string CompanyMobileNo, string User_FName, string User_LName, string User_Dept, string User_Code, string User_Name,string User_Designation,string User_EmailID,string User_MobileNo,int SMS_ConfigID,int SMS_Alloted,int SMS_Min_Bal_Alert,int SMS_Available_Balance, string LoggedInUserID, string Action)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["UpkeepCC_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            Upkeep_BusinessLayer.UpkeepCC_BL objUpkeepCC_BL = new Upkeep_BusinessLayer.UpkeepCC_BL();
            ds = objUpkeepCC_BL.CompanyMaster_CRUD(CompanyID, strCompanyCode, strCompanyDesc, GroupID, CompanyLogo, ClientURL, Is_DBatClientServer, ConString, CompanyEmailID, CompanyMobileNo, User_FName, User_LName, User_Dept, User_Code, User_Name, User_Designation, User_EmailID, User_MobileNo, SMS_ConfigID, SMS_Alloted, SMS_Min_Bal_Alert, SMS_Available_Balance, LoggedInUserID, Action, strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet PopulateLicenseMasters()
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["UpkeepCC_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            Upkeep_BusinessLayer.UpkeepCC_BL objUpkeepCC_BL = new Upkeep_BusinessLayer.UpkeepCC_BL();
            ds = objUpkeepCC_BL.PopulateLicenseMasters(strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet FetchLicenseExpiryDate(int SubscriptionID, string ActivationDate)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["UpkeepCC_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            Upkeep_BusinessLayer.UpkeepCC_BL objUpkeepCC_BL = new Upkeep_BusinessLayer.UpkeepCC_BL();
            ds = objUpkeepCC_BL.FetchLicenseExpiryDate(SubscriptionID, ActivationDate, strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet License_CRUD(int LicenseID, string strClientID, int Company_ID, int Subs_Pack_Id, string strActivationDate, string strExpirationDate, string strDueDate, int UserLimit, string strSelectedModules, string LoggedInUserID, string Action)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["UpkeepCC_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            Upkeep_BusinessLayer.UpkeepCC_BL objUpkeepCC_BL = new Upkeep_BusinessLayer.UpkeepCC_BL();
            ds = objUpkeepCC_BL.License_CRUD(LicenseID, strClientID, Company_ID, Subs_Pack_Id, strActivationDate, strExpirationDate, strDueDate, UserLimit, strSelectedModules, LoggedInUserID, Action, strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet LoginUser(string UserName, string strPassword)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["UpkeepCC_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            Upkeep_BusinessLayer.UpkeepCC_BL objUpkeepCC_BL = new Upkeep_BusinessLayer.UpkeepCC_BL();
            ds = objUpkeepCC_BL.LoginUser(UserName, strPassword, strConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet AdminLogin_Master(int ID, string FirstName, string LastName, string UserName, string Password, string LoggedInUserID, string Is_Deleted, string Action)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["UpkeepCC_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            Upkeep_BusinessLayer.UpkeepCC_BL objUpkeepCC_BL = new Upkeep_BusinessLayer.UpkeepCC_BL();
            ds = objUpkeepCC_BL.AdminLogin_Master(ID, FirstName, LastName, UserName, Password, LoggedInUserID, Is_Deleted, Action, strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet ValidateCompany(string CompanyCode)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["UpkeepCC_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            Upkeep_BusinessLayer.UpkeepCC_BL objUpkeepCC_BL = new Upkeep_BusinessLayer.UpkeepCC_BL();
            ds = objUpkeepCC_BL.ValidateCompany(CompanyCode, strConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet UpdatedsLicenseAction(int LicenseID, int LicenseAction, string LoggedInUserID)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["UpkeepCC_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            Upkeep_BusinessLayer.UpkeepCC_BL objUpkeepCC_BL = new Upkeep_BusinessLayer.UpkeepCC_BL();
            ds = objUpkeepCC_BL.UpdatedsLicenseAction(LicenseID, LicenseAction, LoggedInUserID, strConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Subscription_Package_CRUD(int PackageID, string PackageName, int NoOfDays, int Price, string LoggedInUserID, string Action)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["UpkeepCC_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            Upkeep_BusinessLayer.UpkeepCC_BL objUpkeepCC_BL = new Upkeep_BusinessLayer.UpkeepCC_BL();
            ds = objUpkeepCC_BL.Subscription_Package_CRUD(PackageID, PackageName, NoOfDays, Price, LoggedInUserID, Action, strConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_SMS_Config_Details(int ConfigID)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["UpkeepCC_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            Upkeep_BusinessLayer.UpkeepCC_BL objUpkeepCC_BL = new Upkeep_BusinessLayer.UpkeepCC_BL();
            ds = objUpkeepCC_BL.Fetch_SMS_Config_Details(ConfigID,strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


}