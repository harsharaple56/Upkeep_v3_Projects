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
/// Summary description for UpkeepControlCenter_Service
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class UpkeepControlCenter_Service : System.Web.Services.WebService
{
    public AuthenticationHeader Authentication;
    public UpkeepControlCenter_Service()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    /// <summary>
    /// This method is used to authenticate service request.
    /// </summary>
    /// <returns>Returns true if service Id and Service password are matched, else false.</returns>
    private bool AuthenticateRequest()
    {
        bool retVal = false;
        try
        {
            string id = System.Configuration.ConfigurationManager.AppSettings["UpkeepCCServiceID"].ToString().Trim();
            string password = System.Configuration.ConfigurationManager.AppSettings["UpkeepCCServicePwd"].ToString().Trim();
            if (Authentication.serviceId == id && Authentication.ServicePassword == password)
            {
                retVal = true;
            }
        }
        catch (Exception ex)
        {
            string ErrMsg = ex.Message;
            //returnDataSet.Tables.Add(CreateErrorMessage("1", "Access denied."));
        }
        return retVal;
    }
    


    [WebMethod]
    public DataSet SUPPORT_Fetch_Comments(int Request_ID)
    {
        DataSet ds = new DataSet();

        try
        {
            My_UpkeepCC obj = new My_UpkeepCC();

            ds = obj.SUPPORT_Fetch_Comments(Request_ID);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }

    [WebMethod]
    public DataSet Fetch_License_Module_list(int CompanyID)
    {
        DataSet ds = new DataSet();

        try
        {
            My_UpkeepCC obj = new My_UpkeepCC();

            ds = obj.Fetch_License_Module_list(CompanyID);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }




    [WebMethod]
    public DataSet SUPPORT_Save_Request(int Company_ID, string Request_Type, int Module_ID, string Description, string LoggedInUserID)
    {
        DataSet ds = new DataSet();

        try
        {
            My_UpkeepCC obj = new My_UpkeepCC();

            ds = obj.SUPPORT_Save_Request(Company_ID, Request_Type, Module_ID, Description, LoggedInUserID);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_User_List(int CompanyID)
    {
        DataSet ds = new DataSet();

        try
        {
            My_UpkeepCC obj = new My_UpkeepCC();

            ds = obj.Fetch_User_List(CompanyID);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }




    [WebMethod]
    public DataSet SUPPORT_Save_Comment_Support(int Request_ID, string Comment, string LoggedInUserID)
    {
        DataSet ds = new DataSet();

        try
        {
            My_UpkeepCC obj = new My_UpkeepCC();

            ds = obj.SUPPORT_Save_Comment_Support(Request_ID, Comment, LoggedInUserID);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }




    [WebMethod]
    public DataSet SUPPORT_View_Ticket_Details(int Request_ID)
    {
        DataSet ds = new DataSet();

        try
        {
            My_UpkeepCC obj = new My_UpkeepCC();

            ds = obj.SUPPORT_View_Ticket_Details(Request_ID);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }



    [WebMethod]
    public DataSet SUPPORT_Update_Ticket_Details(int Request_ID, string LoggedInUserID, string Status, string Closing_Remarks)
    {
        DataSet ds = new DataSet();

        try
        {
            My_UpkeepCC obj = new My_UpkeepCC();

            ds = obj.SUPPORT_Update_Ticket_Details(Request_ID, LoggedInUserID, Status, Closing_Remarks);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }




    [WebMethod]
    public DataSet SUPPORT_Fetch_Tickets_List()
    {
        DataSet ds = new DataSet();

        try
        {
            My_UpkeepCC obj = new My_UpkeepCC();

            ds = obj.SUPPORT_Fetch_Tickets_List();

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }




    [WebMethod]
    public DataSet GroupMaster_CRUD(int Group_ID, string Group_Desc, string Group_Code, string LoggedInUserID, string Is_Deleted, string Action)
    {
        DataSet ds = new DataSet();
       
        try
        {
            My_UpkeepCC obj = new My_UpkeepCC();

            ds = obj.GroupMaster_CRUD(Group_ID, Group_Desc, Group_Code, LoggedInUserID, Is_Deleted, Action);

        }
        catch (Exception ex)
        {
            throw ex;
            
        }

        return ds;
    }


    //Method for Invoices Management in Control Center

    [WebMethod]
    public DataSet Invoices_CRUD(int Invoice_ID, string Invoice_No, string Invoice_Desc, string Invoice_Amount, string Invoice_GST, string GST_Type, string Invoice_Date, string Status, string Transaction_Details, int Company_ID, string Company_Desc, string Payment_Mode, string Nature_of_Invoice, string Billing_Name, string Due_date, string GSTIN, string Invoice_File_Path, string LoggedInUserID, string Action)
    {
        DataSet ds = new DataSet();

        try
        {
            My_UpkeepCC obj = new My_UpkeepCC();

            ds = obj.Invoices_CRUD( Invoice_ID,  Invoice_No,  Invoice_Desc,  Invoice_Amount,  Invoice_GST,  GST_Type,  Invoice_Date,  Status, Transaction_Details, Company_ID, Company_Desc, Payment_Mode, Nature_of_Invoice, Billing_Name, Due_date, GSTIN, Invoice_File_Path, LoggedInUserID,Action);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }




    [WebMethod]
    public DataSet CC_Dashboard()
    {
        DataSet ds = new DataSet();

        try
        {
            My_UpkeepCC obj = new My_UpkeepCC();

            ds = obj.CC_Dashboard();

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }

    //public DataSet CC_Dashboard_Company()
    //{
    //    DataSet ds = new DataSet();

    //    try
    //    {
    //        My_UpkeepCC obj = new My_UpkeepCC();

    //        ds = obj.CC_Dashboard_Company();

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;

    //    }

    //    return ds;
    //}


    [WebMethod]
    public DataSet Fetch_GroupDesc()
    {
        DataSet ds = new DataSet();

        try
        {
            My_UpkeepCC obj = new My_UpkeepCC();

            ds = obj.Fetch_GroupDesc();

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }

    [WebMethod]
    public DataSet Fetch_CompanyDesc()
    {
        DataSet ds = new DataSet();

        try
        {
            My_UpkeepCC obj = new My_UpkeepCC();

            ds = obj.Fetch_CompanyDesc();

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }



    [WebMethod]
    public DataSet CompanyMaster_CRUD(int CompanyID, string strCompanyCode, string strCompanyDesc,int GroupID, string CompanyLogo, string ClientURL, int Is_DBatClientServer,string ConString,string CompanyEmailID,string CompanyMobileNo, string User_FName, string User_LName, string User_Dept, string User_Code, string User_Name,string User_Designation,string User_EmailID,string User_MobileNo,int SMS_ConfigID,int SMS_Alloted,int SMS_Min_Bal_Alert,int SMS_Available_Balance, string LoggedInUserID,string Action)
    {
        DataSet ds = new DataSet();

        try
        {
            My_UpkeepCC obj = new My_UpkeepCC();

            ds = obj.CompanyMaster_CRUD(CompanyID, strCompanyCode, strCompanyDesc, GroupID, CompanyLogo, ClientURL, Is_DBatClientServer, ConString, CompanyEmailID, CompanyMobileNo, User_FName, User_LName, User_Dept, User_Code, User_Name, User_Designation, User_EmailID, User_MobileNo, SMS_ConfigID, SMS_Alloted, SMS_Min_Bal_Alert, SMS_Available_Balance, LoggedInUserID, Action);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }

    [WebMethod]
    
    public DataSet PopulateLicenseMasters()
    {
        DataSet ds = new DataSet();

        try
        {
            My_UpkeepCC obj = new My_UpkeepCC();

            ds = obj.PopulateLicenseMasters();

            //if (AuthenticateRequest())
            //{
            //    ds = obj.PopulateLicenseMasters();
            //}
            //else
            //{
            //    ds = null;
            //}
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;
    }

    [WebMethod]
    public DataSet FetchLicenseExpiryDate(int SubscriptionID, string ActivationDate)
    {
        DataSet ds = new DataSet();

        try
        {
            My_UpkeepCC obj = new My_UpkeepCC();

            ds = obj.FetchLicenseExpiryDate(SubscriptionID, ActivationDate);
           
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ds;
    }


    [WebMethod]
    public DataSet License_CRUD(int LicenseID,string strClientID,int Company_ID,int Subs_Pack_Id,string strActivationDate,string strExpirationDate, string strDueDate,int UserLimit, string strSelectedModules, string LoggedInUserID, string Action)
    {
        DataSet ds = new DataSet();

        try
        {
            My_UpkeepCC obj = new My_UpkeepCC();

            ds = obj.License_CRUD(LicenseID, strClientID, Company_ID, Subs_Pack_Id, strActivationDate, strExpirationDate, strDueDate, UserLimit, strSelectedModules, LoggedInUserID, Action);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }



    [WebMethod]
    public DataSet LoginUser(string UserId, string strPassword)
    {
        DataSet ds = new DataSet();

        try
        {
            My_UpkeepCC obj = new My_UpkeepCC();

            ds = obj.LoginUser(UserId, strPassword);

        }
        catch (Exception ex)
        {
            throw ex;
          
        }

        return ds;
    }

    [WebMethod]
    public DataSet AdminLogin_Master(int ID, string FirstName, string LastName,string UserName,string Password, string LoggedInUserID, string Is_Deleted, string Action)
    {
        DataSet ds = new DataSet();

        try
        {
            My_UpkeepCC obj = new My_UpkeepCC();

            ds = obj.AdminLogin_Master(ID, FirstName, LastName,UserName,Password, LoggedInUserID, Is_Deleted, Action);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }

    [WebMethod]
    public DataSet ValidateCompany(string CompanyCode)
    {
        DataSet dsLogin = new DataSet();
        try
        {
            My_UpkeepCC obj = new My_UpkeepCC();
            dsLogin = obj.ValidateCompany(CompanyCode);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dsLogin;
    }

    [WebMethod]
    public DataSet UpdatedsLicenseAction(int LicenseID,int LicenseAction, string LoggedInUserID)
    {
        DataSet dsLogin = new DataSet();
        try
        {
            My_UpkeepCC obj = new My_UpkeepCC();
            dsLogin = obj.UpdatedsLicenseAction(LicenseID, LicenseAction, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dsLogin;
    }

    [WebMethod]
    public DataSet Subscription_Package_CRUD(int PackageID, string PackageName, int NoOfDays, int Price, string LoggedInUserID, string Action)
    {
        DataSet dsLogin = new DataSet();
        try
        {
            My_UpkeepCC obj = new My_UpkeepCC();
            dsLogin = obj.Subscription_Package_CRUD(PackageID, PackageName, NoOfDays, Price, LoggedInUserID, Action);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dsLogin;
    }

    [WebMethod]
    public DataSet Fetch_SMS_Config_Details(int ConfigID)
    {
        DataSet ds = new DataSet();

        try
        {
            My_UpkeepCC obj = new My_UpkeepCC();

            ds = obj.Fetch_SMS_Config_Details(ConfigID);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }



}

public class AuthenticationHeader : SoapHeader
{
    public string serviceId;
    public string ServicePassword;
}
