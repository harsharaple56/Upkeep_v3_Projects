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
/// Summary description for Upkeep_V3_Services
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Upkeep_V3_Services : System.Web.Services.WebService
{

    //#region Private Variable
    //private string strFname, strLname, strPhone, strEmailID, strGender;

    //#endregion


    //#region Properties


    //public string Fname
    //{
    //    get { return strFname; }

    //    set { strFname = value; }
    //}
    //public string Lname
    //{
    //    get { return strLname; }

    //    set { strLname = value; }
    //}
    //public string Phone
    //{
    //    get { return strPhone; }

    //    set { strPhone = value; }
    //}
    //public string EmailID
    //{
    //    get { return strEmailID; }

    //    set { strEmailID = value; }
    //}
    //public string Gender
    //{
    //    get { return strGender; }

    //    set { strGender = value; }
    //}
    //#endregion

    My_Upkeep ObjUpkeep = new My_Upkeep();
    DataSet ds = new DataSet();

    public Upkeep_V3_Services()
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
    public DataSet Fetch_Dashboard_Admin(int CompanyID, string LoggedInUserID, string Fromdate, string ToDate)
    {
        try
        {
            ds = ObjUpkeep.Fetch_Dashboard_Admin(CompanyID, LoggedInUserID, Fromdate, ToDate);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Dashboard_Employee(int CompanyID, string LoggedInUserID, string Fromdate, string ToDate)
    {
        try
        {
            ds = ObjUpkeep.Fetch_Dashboard_Employee(CompanyID, LoggedInUserID, Fromdate, ToDate);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Dashboard_Retailer(int CompanyID, string LoggedInUserID, string Fromdate, string ToDate)
    {
        try
        {
            ds = ObjUpkeep.Fetch_Dashboard_Retailer(CompanyID, LoggedInUserID, Fromdate, ToDate);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }




    [WebMethod]
    public DataSet Fetch_License_Module_list(string Module_ID_String)
    {
        try
        {
            ds = ObjUpkeep.Fetch_License_Module_list(Module_ID_String);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    [WebMethod]
    public DataSet SUPPORT_Fetch_Comments(int Request_ID)
    {
        try
        {
            ds = ObjUpkeep.SUPPORT_Fetch_Comments(Request_ID);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    [WebMethod]
    public DataSet SUPPORT_Save_Comment_Client(int Request_ID, string Comment, string LoggedInUserID)
    {
        try
        {
            ds = ObjUpkeep.SUPPORT_Save_Comment_Client(Request_ID, Comment, LoggedInUserID);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    [WebMethod]
    public DataSet SUPPORT_View_Request_Details(int Request_ID, int Company_ID, string LoggedInUserID)
    {
        try
        {
            ds = ObjUpkeep.SUPPORT_View_Request_Details(Request_ID, Company_ID, LoggedInUserID);

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
        try
        {
            ds = ObjUpkeep.SUPPORT_Save_Request(Company_ID, Request_Type, Module_ID, Description, LoggedInUserID);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet SUPPORT_Fetch_Requests(string From_Date, string To_Date, int Company_ID, string LoggedInUserID, string Role_Name)
    {
        try
        {
            ds = ObjUpkeep.SUPPORT_Fetch_Requests(From_Date, To_Date, Company_ID, LoggedInUserID, Role_Name);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    [WebMethod]
    public DataSet INV_ItemStock_CRUD(int Stock_ID, int Item_ID, string Opening_Stock, string Optimum_Value, string ReOrder_Value, string Base_Value, int Department_ID, int Current_Stock, int Company_ID, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjUpkeep.INV_ItemStock_CRUD(Stock_ID, Item_ID, Opening_Stock, Optimum_Value, ReOrder_Value, Base_Value, Department_ID, Current_Stock, Company_ID, LoggedInUserID, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet INV_Fetch_Items_List(int CompanyID)
    {
        try
        {
            ds = ObjUpkeep.INV_Fetch_Items_List(CompanyID);

        }
        catch (Exception ex)
        {
            throw ex;

        }
        return ds;
    }


    [WebMethod]
    public DataSet LMS_Vendor_Cost(int Cost_ID, int Vendor_ID, int Item_ID, decimal Cost, string Valid_From, string Valid_To, string LoggedInUserID, string Action, int CompanyID)
    {
        try
        {
            ds = ObjUpkeep.LMS_Vendor_Cost(Cost_ID, Vendor_ID, Item_ID, Cost, Valid_From, Valid_To, LoggedInUserID, Action, CompanyID);

        }
        catch (Exception ex)
        {
            throw ex;

        }
        return ds;
    }


    [WebMethod]
    public DataSet LMS_Fetch_Department_Transactions(string Start_Date, string End_Date, int CompanyID, int Dept_ID)
    {
        try
        {
            ds = ObjUpkeep.LMS_Fetch_Department_Transactions(Start_Date, End_Date, Dept_ID, CompanyID);

        }
        catch (Exception ex)
        {
            throw ex;

        }
        return ds;
    }


    [WebMethod]
    public DataSet LMS_Category_Mst(int Category_ID, string Category_Desc, int Company_ID, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjUpkeep.LMS_Category_Mst(Category_ID, Category_Desc, Company_ID, LoggedInUserID, Action);

        }
        catch (Exception ex)
        {
            throw ex;

        }
        return ds;
    }

    [WebMethod]
    public DataSet LMS_SubCategory_Mst(int SubCategory_ID, string SubCategory_Desc, int Category_ID, int Company_ID, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjUpkeep.LMS_SubCategory_Mst(SubCategory_ID, SubCategory_Desc, Category_ID, Company_ID, LoggedInUserID, Action);

        }
        catch (Exception ex)
        {
            throw ex;

        }
        return ds;
    }




    [WebMethod]
    public DataSet LMS_Fetch_Vendor_Transactions(string Start_Date, string End_Date, int CompanyID, int Vendor_ID)
    {
        try
        {
            ds = ObjUpkeep.LMS_Fetch_Vendor_Transactions(Start_Date, End_Date, Vendor_ID, CompanyID);

        }
        catch (Exception ex)
        {
            throw ex;

        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_LMS_ItemList(int DepartmentID, int CompanyID)
    {
        DataSet dsItem = new DataSet();
        try
        {
            dsItem = ObjUpkeep.Fetch_LMS_ItemList(DepartmentID,CompanyID);

        }
        catch (Exception ex)
        {
            throw ex;

        }
        return dsItem;
    }

    [WebMethod]
    public DataSet Fetch_LMS_ItemDetails_Dept_Transaction(int DepartmentID, int CompanyID, string ItemIDs)
    {
        DataSet dsItem = new DataSet();
        try
        {
            dsItem = ObjUpkeep.Fetch_LMS_ItemDetails_Dept_Transaction(DepartmentID, CompanyID, ItemIDs);

        }
        catch (Exception ex)
        {
            throw ex;

        }
        return dsItem;
    }


    [WebMethod]
    public DataSet LMS_Save_Department_Transaction(string Dept_ExecutiveName, string Dept_ExecutiveContactNo,int DepartmentID, string TransactionData,int CompanyID, string LoggedInUserID)
    {
        DataSet dsItem = new DataSet();
        try
        {
            dsItem = ObjUpkeep.LMS_Save_Department_Transaction(Dept_ExecutiveName, Dept_ExecutiveContactNo, DepartmentID, TransactionData, CompanyID, LoggedInUserID);

        }
        catch (Exception ex)
        {
            throw ex;

        }
        return dsItem;
    }

    [WebMethod]
    public DataSet LMS_Save_Vendor_Transaction(int VendorID, int DepartmentID, string TransactionData, int CompanyID, string LoggedInUserID)
    {
        DataSet dsItem = new DataSet();
        try
        {
            dsItem = ObjUpkeep.LMS_Save_Vendor_Transaction(VendorID, DepartmentID, TransactionData, CompanyID, LoggedInUserID);

        }
        catch (Exception ex)
        {
            throw ex;

        }
        return dsItem;
    }

    [WebMethod]
    public DataSet Fetch_LMS_Dept_Transaction_Details(int Dept_TransID)
    {
        DataSet dsItem = new DataSet();
        try
        {
            dsItem = ObjUpkeep.Fetch_LMS_Dept_Transaction_Details(Dept_TransID);

        }
        catch (Exception ex)
        {
            throw ex;

        }
        return dsItem;
    }


    [WebMethod]
    public DataSet Fetch_LMS_ItemDetails_Vendor_Transaction(int DepartmentID, int CompanyID, string ItemIDs)
    {
        DataSet dsItem = new DataSet();
        try
        {
            dsItem = ObjUpkeep.Fetch_LMS_ItemDetails_Vendor_Transaction(DepartmentID, CompanyID, ItemIDs);

        }
        catch (Exception ex)
        {
            throw ex;

        }
        return dsItem;
    }

    [WebMethod]
    public DataSet Fetch_LMS_Vendor_List(int CompanyID)
    {
        DataSet dsItem = new DataSet();
        try
        {
            dsItem = ObjUpkeep.Fetch_LMS_Vendor_List(CompanyID);

        }
        catch (Exception ex)
        {
            throw ex;

        }
        return dsItem;
    }

    [WebMethod]
    public DataSet Fetch_LMS_Vendor_Transaction_Details(int Vendor_TransID)
    {
        DataSet dsItem = new DataSet();
        try
        {
            dsItem = ObjUpkeep.Fetch_LMS_Vendor_Transaction_Details(Vendor_TransID);

        }
        catch (Exception ex)
        {
            throw ex;

        }
        return dsItem;
    }

    [WebMethod]
    public DataSet Fetch_Invoices(int Company_ID)
    {
        try
        {

            ds = ObjUpkeep.Fetch_Invoices(Company_ID);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }



    [WebMethod]
    public DataSet MenuMaster_CRUD(int Menu_ID, string Menu_Desc, string Parent_Menu_Id, string Toot_Tip, string Menu_Url, string Module_Menu_Id, string Is_Deleted, string Action)
    {
        try
        {

            ds = ObjUpkeep.MenuMaster_CRUD(Menu_ID, Menu_Desc, Parent_Menu_Id, Toot_Tip, Menu_Url, Module_Menu_Id, Is_Deleted, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet CustomReports_RU(int Report_ID, string Report_Name, string Report_Desc, int Company_ID, string LoggedInUserID, string Action)
    {
        try
        {
            DataSet dsCustom = new DataSet();
            dsCustom = ObjUpkeep.CustomReports_RU(Report_ID,Report_Name,Report_Desc, Company_ID, LoggedInUserID, Action);
            return dsCustom;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
    }

    [WebMethod]
    public DataSet UserTypeMaster_CRUD(int User_Type_ID, string User_Type_Desc, int CompanyID, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjUpkeep.UserTypeMaster_CRUD(User_Type_ID, User_Type_Desc, CompanyID, LoggedInUserID, Action);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet DepartmentMaster_CRUD(int Department_ID, string Dept_Desc, int CompanyID, string LoggedInUserID, string Is_Deleted, string Action)
    {
        try
        {
            ds = ObjUpkeep.DepartmentMaster_CRUD(Department_ID, Dept_Desc, CompanyID, LoggedInUserID, Is_Deleted, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Zone()
    {
        try
        {
            ds = ObjUpkeep.FetchZone();
        }
        catch (Exception ex)
        {
            throw ex;

        }
        return ds;
    }


    [WebMethod]
    public DataSet Fetch_Location(int ZoneID)
    {
        try
        {
            ds = ObjUpkeep.FetchLocation(ZoneID);
        }
        catch (Exception ex)
        {
            throw ex;

        }
        return ds;
    }


    [WebMethod]
    public DataSet Fetch_Sub_Location(int Loc_ID)
    {
        try
        {
            ds = ObjUpkeep.FetchSubLocation(Loc_ID);

        }
        catch (Exception ex)
        {
            throw ex;

        }
        return ds;
    }


    [WebMethod]
    public DataSet Fetch_Department(int CompanyID)
    {
        try
        {
            ds = ObjUpkeep.FetchDepartment(CompanyID);

        }
        catch (Exception ex)
        {
            throw ex;

        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_User_Type(int CompanyId)   //Added CompanyId by sujata
    {
        try
        {
            ds = ObjUpkeep.FetchUserType(CompanyId);
        }
        catch (Exception ex)
        {
            throw ex;

        }
        return ds;
    }



    [WebMethod]
    public DataSet UserMaster_CRUD(int User_ID, string User_Code, string F_name, string L_Name, string User_Mobile, string User_Email, string User_MobileAlter, string User_Landline, string User_Designation, int User_Type_ID, int Zone_ID, int Loc_ID, int SubLoc_Id, int Department_Id, string Login_Id, string Password, int Is_Approver, int Is_GobalApprover, int Approver_ID, int RoleID, string ProfilePhoto_FilePath, string Sign_FilePath, int CompanyID,int Is_Email_Verified, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjUpkeep.UserMaster_CRUD(User_ID, User_Code, F_name, L_Name, User_Mobile, User_Email, User_MobileAlter, User_Landline, User_Designation, User_Type_ID, Zone_ID, Loc_ID, SubLoc_Id, Department_Id, Login_Id, Password, Is_Approver, Is_GobalApprover, Approver_ID, RoleID, ProfilePhoto_FilePath, Sign_FilePath, CompanyID, Is_Email_Verified, LoggedInUserID, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Email_Verification_Mail(string EmailID, string OTP)
    {
        DataSet dsVerifyEmail = new DataSet();
        try
        {
            dsVerifyEmail = ObjUpkeep.Email_Verification_Mail(EmailID, OTP);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dsVerifyEmail;
    }




    [WebMethod]
    public DataSet LoginUser(string UserId, string strPassword, string UserType, int CompanyID)
    {
        DataSet ds = new DataSet();

        try
        {

            ds = ObjUpkeep.LoginUser(UserId, strPassword, UserType, CompanyID);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }

    [WebMethod]
    public DataSet PriorityMaster_CRUD(int Priority_ID, string Priority_Desc, int CompanyID, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjUpkeep.PriorityMaster_CRUD(Priority_ID, Priority_Desc, CompanyID, LoggedInUserID, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet FrequencyMaster_CRUD(int Frquency_Id, string Frquency_Desc, int CompanyID, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjUpkeep.FrequencyMaster_CRUD(Frquency_Id, Frquency_Desc, CompanyID, LoggedInUserID, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet ZoneMaster_CRUD(int ZoneID, int CompanyID, string ZoneCode, string ZoneDesc, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjUpkeep.ZoneMaster_CRUD(ZoneID, CompanyID, ZoneCode, ZoneDesc, LoggedInUserID, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet LocationMaster_CRUD(int LocID, string Zone, string LocCode, string LocDesc, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjUpkeep.LocationMaster_CRUD(LocID, Zone, LocCode, LocDesc, LoggedInUserID, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet INV_ItemMaster_CRUD(int Item_ID, string Item_Desc, int Category_ID, int SubCategory_ID, int Company_ID, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjUpkeep.INV_ItemMaster_CRUD(Item_ID, Item_Desc, Category_ID, SubCategory_ID,  Company_ID,  LoggedInUserID, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet SubLocationMaster_CRUD(int SubLocID, string LocName, string Zone, string SubLocCode, string SubLocDesc, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjUpkeep.SubLocationMaster_CRUD(SubLocID, LocName, Zone, SubLocCode, SubLocDesc, LoggedInUserID, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }




    [WebMethod]
    public DataSet UserGroupMaster_CRUD(int Grp_Id, string Grp_Desc, string User_ID, int CompanyID, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjUpkeep.UserGroupMaster_CRUD(Grp_Id, Grp_Desc, User_ID, CompanyID, LoggedInUserID, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet FetchUserGrp(int GroupID, int CompanyID)
    {
        try
        {
            ds = ObjUpkeep.FetchUserGrp(GroupID, CompanyID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_CategorySubCategory(int CategoryID, int CompanyID)
    {
        try
        {
            ds = ObjUpkeep.Fetch_CategorySubCategory(CategoryID, CompanyID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet WorkflowMaster_CRUD(int WorkflowID, string WorkflowDesc, int ZoneID, int CategoryID, int SubCategoryID, string xmlWorkflow, int CompanyID, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjUpkeep.WorkflowMaster_CRUD(WorkflowID, WorkflowDesc, ZoneID, CategoryID, SubCategoryID, xmlWorkflow, CompanyID, LoggedInUserID, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_User_UserGroupList(int CompanyID)
    {
        try
        {
            ds = ObjUpkeep.Fetch_User_UserGroupList(CompanyID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet CategoryMaster_CRUD(int CompanyID, int Category_ID, string Category_Desc, int DepartmentID, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjUpkeep.CategoryMaster_CRUD(CompanyID, Category_ID, Category_Desc, DepartmentID, LoggedInUserID, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    [WebMethod]
    public DataSet RetailerPunch_CR(string LoggedInUserID, string Punch_Type, int CompanyID, string Action)
    {
        try
        {
            ds = ObjUpkeep.RetailerPunch_CR(LoggedInUserID, Punch_Type, CompanyID, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    [WebMethod]
    public DataSet Fetch_CRUD_Vendor_Mst(int Vendor_ID, string Vendor_Name, string Vendor_Desc, string Vendor_Address, string Vendor_Contact1, string Vendor_Contact2, string Vendor_Email, string Vendor_Reg_ID, string Vendor_GSTIN, string Vendor_PAN, string Vendor_Bank_Details, string LoggedInUserID, int CompanyID, string Action)
    {
        try
        {
            ds = ObjUpkeep.Fetch_CRUD_Vendor_Mst(Vendor_ID, Vendor_Name, Vendor_Desc, Vendor_Address, Vendor_Contact1, Vendor_Contact2, Vendor_Email, Vendor_Reg_ID, Vendor_GSTIN, Vendor_PAN, Vendor_Bank_Details, LoggedInUserID, CompanyID, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }



    [WebMethod]
    public DataSet SubCategoryMaster_CRUD(int CompanyID, int SubcategoryID, string SubCategoryDesc, int CategoryID, int Priority_ID, int Approval_Required, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjUpkeep.SubCategoryMaster_CRUD(CompanyID, SubcategoryID, SubCategoryDesc, CategoryID, Priority_ID,Approval_Required, LoggedInUserID, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet BindLocationDetails(int ZoneID, int LocationID)
    {
        try
        {
            ds = ObjUpkeep.BindLocationDetails(ZoneID, LocationID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_LocationTree(int CompanyID)
    {
        try
        {
            ds = ObjUpkeep.Fetch_LocationTree(CompanyID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    #region Ticketing


    [WebMethod]
    public DataSet Fetch_Ticket_Workflow(int CompanyID, int CategoryID, int SubCategoryID, string TicketPrefix, string LoggedInUserID)
    {
        try
        {
            ds = ObjUpkeep.Fetch_Ticket_Workflow(CompanyID, CategoryID, SubCategoryID, TicketPrefix, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Insert_Ticket_Details(string TicketCode, int CompanyID, int LocationID, int CategoryID, int SubCategoryID, string TicketMessage, string list_Images,string CustomFields_XML, string LoggedInUserID, string strAction)
    {
        try
        {
            ds = ObjUpkeep.Insert_Ticket_Details(TicketCode, CompanyID, LocationID, CategoryID, SubCategoryID, TicketMessage, list_Images, CustomFields_XML, LoggedInUserID, strAction);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Ticket_MyActionable(int TicketID, int CompanyID, string LoggedInUserID, string From_Date, string To_Date)
    {
        try
        {
            ds = ObjUpkeep.Fetch_Ticket_MyActionable(TicketID, CompanyID, LoggedInUserID, From_Date, To_Date);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Ticket_MyActionable_Details(int TicketID, int CompanyID, string LoggedInUserID)
    {
        try
        {
            ds = ObjUpkeep.Fetch_Ticket_MyActionable_Details(TicketID, CompanyID, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Accept_Ticket(int TicketID, string LoggedInUserID)
    {
        try
        {
            ds = ObjUpkeep.Accept_Ticket(TicketID, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    [WebMethod]
    public DataSet Fetch_CTT_Report(string TicketStatus,string ActionStatus,string From_Date,string To_Date, int CompanyID)
    {
        try
        {
            ds = ObjUpkeep.Fetch_CTT_Report(TicketStatus, ActionStatus, From_Date, To_Date, CompanyID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Bind_Ticket_Details(int TicketID, int CompanyID)
    {
        try
        {
            ds = ObjUpkeep.Bind_Ticket_Details(TicketID, CompanyID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    #endregion

    //[+][Feedback System Methods]
    #region Feedback System Methods


    [WebMethod]
    public DataSet Get_ChartData(string fromDate, string toDate, int CompanyID)
    {
        DataSet ds = new DataSet();
        

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();

            ds = obj.Get_ChartData(fromDate, toDate, CompanyID);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }



    [WebMethod]
    public DataSet Employee_CRUD(string firstName, string lastName, string email, Int64 phone, string EmpID, string LoggedInUserID, string role, string Username, string Password, string actionType)
    {
        DataSet ds = new DataSet();

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();

            ds = obj.Employee_CRUD(firstName, lastName, email, phone, EmpID, LoggedInUserID, role, Username, Password, actionType);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }

    [WebMethod]
    public DataSet ChangePassword(string UserName, string strPassword)
    {
        DataSet ds = new DataSet();

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();

            ds = obj.ChangePassword(UserName, strPassword);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }

    [WebMethod]
    public DataSet fetchStore()
    {
        DataSet ds = new DataSet();

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();

            ds = obj.fetchStore();

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }


    [WebMethod]
    public DataSet Retailer_CRUD(string storeName,string Store_No, string firstName, string lastName, string email, Int64 phone, int RetailerID, string Username, string Password,int LocationID, int CompanyID, string LoggedInUserID, string actionType)
    {
        DataSet ds = new DataSet();

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();

            ds = obj.Retailer_CRUD(storeName, Store_No,firstName, lastName, email, phone, RetailerID, Username, Password, LocationID, CompanyID, LoggedInUserID, actionType);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }


    [WebMethod]
    public DataSet Event_Insert(string eventName, string locationName, string startDateTime, string endDateTime, string CustomerQuestion, string CustQuesType, string QuesFor, int EventID, string EventMode, string LoggedInUserID, string option1, string option2, string option3, string option4, int CompanyID)
    {
        DataSet ds = new DataSet();

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();

            //ds = obj.Event_Insert(eventName, locationName, startDateTime, endDateTime, CustomerQuestion, CustQuesType, RetailerQuestion, RetQuesType, EventID);
            ds = obj.Event_Insert(eventName, locationName, startDateTime, endDateTime, CustomerQuestion, CustQuesType, QuesFor, EventID, EventMode, LoggedInUserID, option1, option2, option3, option4, CompanyID);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }


    [WebMethod]
    public DataSet EventDetails_CRUD(int EventID,int CompanyID, string actionType)
    {
        DataSet ds = new DataSet();

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();

            ds = obj.EventDetails_CRUD(EventID, CompanyID, actionType);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }

    [WebMethod]
    public DataSet bindEventDetails(int CompanyID, int EventID) //CompanyID added by sujata
    {
        DataSet ds = new DataSet();

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();

            ds = obj.bindEventDetails(CompanyID, EventID);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }



    //Added by Sujata This function is used to save Feedback form

    [WebMethod]
    public DataSet Insert_FeedbackForm(int CompanyID, int EventID, string strFname, string strLname, string strPhoneno, string strGender, string strEmailID, string FeedbackData, string LoggedInUserID) //CompanyID added by sujata
    {
        DataSet ds = new DataSet();

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();

            ds = obj.Insert_FeedbackForm(CompanyID, EventID, strFname, strLname, strPhoneno, strGender, strEmailID, FeedbackData, LoggedInUserID);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }



    [WebMethod]
    public DataSet Get_CustomerDetails()
    {
        DataSet ds = new DataSet();

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();

            ds = obj.Get_CustomerDetails();

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }

    [WebMethod]
    public DataSet Get_EventQuestions(int EventID)
    {
        DataSet ds = new DataSet();

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();

            ds = obj.Get_EventQuestions(EventID);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }

    [WebMethod]
    public DataSet Event_QuestionIU(int EventID, string CustomerQuestion, string AnswerType, string opt1, string opt2, string opt3, string opt4, string LoggedInUserID, int QuestionID, string ActionType)
    {
        DataSet ds = new DataSet();

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();

            //ds = obj.Event_Insert(eventName, locationName, startDateTime, endDateTime, CustomerQuestion, CustQuesType, RetailerQuestion, RetQuesType, EventID);
            ds = obj.Event_QuestionIU(EventID, CustomerQuestion, AnswerType, opt1, opt2, opt3, opt4, LoggedInUserID, QuestionID, ActionType);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }


    [WebMethod]
    public DataSet Fetch_MIS_Report(string EventID, string From_Date, string To_Date, int CompanyID)
    {
        DataSet ds = new DataSet();

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();

            ds = obj.Fetch_MIS_Report(EventID, From_Date, To_Date, CompanyID);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }

    [WebMethod]
    public DataSet Event_Update(int EventID, string Location, string QuesFor, string EventMode, string startDate, string endDate, string LoggedInUserID, string ActionType)
    {
        DataSet ds = new DataSet();

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();

            //ds = obj.Event_Insert(eventName, locationName, startDateTime, endDateTime, CustomerQuestion, CustQuesType, RetailerQuestion, RetQuesType, EventID);
            ds = obj.Event_Update(EventID, Location, QuesFor, EventMode, startDate, endDate, LoggedInUserID, ActionType);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }

    [WebMethod(Description = "Fetch event list for MIS")]
    public DataSet GetEventList(int CompanyID, String EventFor)  //CompanyID Added by Sujata 
    {
        DataSet dsEventList = new DataSet();
        My_FeedbackSystem obj = new My_FeedbackSystem();

        dsEventList = obj.GetEventList(CompanyID, EventFor);

        return dsEventList;
    }

    [WebMethod]
    public DataSet Fetch_MIS_Report_Excel(string EventID, string From_Date, string To_Date, int CompanyID)
    {
        DataSet ds = new DataSet();

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();

            ds = obj.Fetch_MIS_Report_Excel(EventID, From_Date, To_Date, CompanyID);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }

    [WebMethod]
    public DataSet ImportRetailer(int CompanyID)
    {
        DataSet ds = new DataSet();

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();

            ds = obj.ImportRetailer(CompanyID);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }

    #endregion
    //[-][Feedback System Methods]

    [WebMethod]
    public DataSet AddChecklistMaster_CRUD(int ChecklistID, string ChecklistName, int DeptID, Boolean Chkapproval, Boolean ChkExpry, Boolean ChkSchedule, int ExpirytimeID, DateTime dtSchedule_Date, string StartTime, string EndTime, int CustFrequency, int Frquency_Id, int ZoneID, int LocationID, int SubLocationID, string strXmlChecklistPoint, string LoggedInUserID, string Action)
    {
        DataSet dsAddChecklist = new DataSet();
        try
        {
            dsAddChecklist = ObjUpkeep.AddChecklistMaster_CRUD(ChecklistID, ChecklistName, DeptID, Chkapproval, ChkExpry, ChkSchedule, ExpirytimeID, dtSchedule_Date, StartTime, EndTime, CustFrequency, Frquency_Id, ZoneID, LocationID, SubLocationID, strXmlChecklistPoint, LoggedInUserID, Action);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dsAddChecklist;
    }

    //[WebMethod]
    //public DataSet FetchMenu(int parentMenuId)
    //{
    //    DataSet dtMenu = new DataSet();
    //    try
    //    {
    //        dtMenu = ObjUpkeep.FetchMenu(parentMenuId);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return dtMenu;
    //}

    [WebMethod]
    public DataSet ChecklistPoint_CRUD(int ChecklistID, int ChecklistPointID, string strChecklistPointDesc, string strChecklstAnstype, string LoggedInUserID, string Action)
    {
        DataSet dsAddChecklist = new DataSet();
        try
        {
            dsAddChecklist = ObjUpkeep.ChecklistPoint_CRUD(ChecklistID, ChecklistPointID, strChecklistPointDesc, strChecklstAnstype, LoggedInUserID, Action);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dsAddChecklist;
    }

    [WebMethod]
    public DataSet ChecklistRequest(string ScheduleDate, int ZoneID, int LocationID, int SubLocationID, int DepartmentID, int ChecklistID, string StartTime, string TicketNumber, string LoggedInUserID, string strAction)
    {
        try
        {
            ds = ObjUpkeep.ChecklistRequest(ScheduleDate, ZoneID, LocationID, SubLocationID, DepartmentID, ChecklistID, StartTime, TicketNumber, LoggedInUserID, strAction);

        }
        catch (Exception ex)
        {
            throw ex;

        }
        return ds;
    }


    [WebMethod]
    public DataSet Update_ChecklistPoints(string TicketNumber, string strXmlChecklist, string list_Images, string LoggedInUserID)
    {
        DataSet dsChecklist = new DataSet();
        try
        {
            dsChecklist = ObjUpkeep.Update_ChecklistPoints(TicketNumber, strXmlChecklist, list_Images, LoggedInUserID);

        }
        catch (Exception ex)
        {
            throw ex;

        }
        return dsChecklist;
    }

    [WebMethod]
    public DataSet Close_Ticket_Details(string TicketID, string CloseTicketDesc, string LoggedInUserID, string list_Images, string strTicketAction, string CurrentLevel)
    {
        try
        {
            ds = ObjUpkeep.Close_Ticket_Details(TicketID, CloseTicketDesc, LoggedInUserID, list_Images, strTicketAction, CurrentLevel);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    #region Location Tree View

    [WebMethod]
    public DataSet Location_PopulateRootLevel(int CompanyID)
    {
        try
        {
            ds = ObjUpkeep.Location_PopulateRootLevel(CompanyID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Location_PopulateSubLevel(int ParentID)
    {
        try
        {
            ds = ObjUpkeep.Location_PopulateSubLevel(ParentID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Add_Update_Location_Node(int ParentID, string Location_Node, int CompanyID, string LoggedInUserID, string strAction)
    {
        try
        {
            ds = ObjUpkeep.Add_Update_Location_Node(ParentID, Location_Node, CompanyID, LoggedInUserID, strAction);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    #endregion


    #region Role Management

    [WebMethod]
    public DataSet FetchMenu(int parentMenuId, string LoggedInUserID, string ModuleIDs, int CompanyID)
    {
        DataSet dtMenu = new DataSet();
        try
        {
            dtMenu = ObjUpkeep.FetchMenu(parentMenuId, LoggedInUserID, ModuleIDs, CompanyID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dtMenu;
    }

    [WebMethod]
    public DataSet RoleMaster_CRUD(int RoleID, string Role, string LoggedInUserID, string strAction)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.RoleMaster_CRUD(RoleID, Role, LoggedInUserID, strAction);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Assigned_Role(int RoleID)
    {
        DataSet dtMenu = new DataSet();
        try
        {
            dtMenu = ObjUpkeep.Fetch_Assigned_Role(RoleID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dtMenu;
    }

    [WebMethod]
    public DataSet Fetch_Role_Menu()
    {
        DataSet dsMenu = new DataSet();
        try
        {
            dsMenu = ObjUpkeep.Fetch_Role_Menu();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dsMenu;
    }

    [WebMethod]
    public DataSet FETCH_Saved_Role_MENU_Rights(int RoleID, int ParentMenuId)
    {
        DataSet dsMenu = new DataSet();
        try
        {
            dsMenu = ObjUpkeep.FETCH_Saved_Role_MENU_Rights(RoleID, ParentMenuId);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dsMenu;
    }

    [WebMethod]
    public DataSet Insert_RoleMenuRights(int RoleId, int ParentMenuId, string LoggedInUserID, string strWpSectionHeaderData)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Insert_RoleMenuRights(RoleId, ParentMenuId, LoggedInUserID, strWpSectionHeaderData);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Insert_Assigned_Role(int RoleID, string SelectedEmployees, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Insert_Assigned_Role(RoleID, SelectedEmployees, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_RoleListing()
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_RoleListing();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }



    #endregion

    #region GatePass

    [WebMethod]
    public DataSet Insert_GatePassConfiguration(string strConfigTitle, int CompanyID, string strInitiator, bool LinkDepartment, string strTransactionPrefix, string strXmlGatepass_Header, string strXmlGatepass_Type, string strXmlGatepass_Doc, string strXmlGatepass_TermCondition, string strXmlApprovalMatrix, bool ShowApprovalMatrix, string strGPClosureBy, string GatepassDescription, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Insert_GatePassConfiguration(strConfigTitle, CompanyID, strInitiator, LinkDepartment, strTransactionPrefix, strXmlGatepass_Header, strXmlGatepass_Type, strXmlGatepass_Doc, strXmlGatepass_TermCondition, strXmlApprovalMatrix, ShowApprovalMatrix, strGPClosureBy, GatepassDescription, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    [WebMethod]
    public DataSet Fetch_GatePassConfiguration(string Initiator, int CompanyID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_GatePassConfiguration(Initiator, CompanyID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Bind_GatePassConfiguration(int GP_ConfigID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Bind_GatePassConfiguration(GP_ConfigID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet GatePassHeader_CRUD(int GatePassHeaderID, string GatePassHeader, bool GPHeaderNumeric, int GPHeaderUnit, int GatePass_ConfigID, string LoggedInUserID, string strAction)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.GatePassHeader_CRUD(GatePassHeaderID, GatePassHeader, GPHeaderNumeric, GPHeaderUnit, GatePass_ConfigID, LoggedInUserID, strAction);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet GatePassType_CRUD(int GP_TypeID, string GP_TypeDesc, int GatePass_ConfigID, string LoggedInUserID, string strAction)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.GatePassType_CRUD(GP_TypeID, GP_TypeDesc, GatePass_ConfigID, LoggedInUserID, strAction);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet GatePassTerm_CRUD(int GP_TermID, string GP_TermDesc, int GatePass_ConfigID, string LoggedInUserID, string strAction)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.GatePassTerm_CRUD(GP_TermID, GP_TermDesc, GatePass_ConfigID, LoggedInUserID, strAction);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Update_GatePassConfiguration(int GP_Config_ID, string strConfigTitle, int CompanyID, string strInitiator, bool LinkDepartment, string strTransactionPrefix, string strXmlApprovalMatrix, bool ShowApprovalMatrix, string strGPClosureBy, string GatepassDescription, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Update_GatePassConfiguration(GP_Config_ID, strConfigTitle, CompanyID, strInitiator, LinkDepartment, strTransactionPrefix, strXmlApprovalMatrix, ShowApprovalMatrix, strGPClosureBy, GatepassDescription, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Bind_GatePassRequestDetails(int GP_ConfigID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Bind_GatePassRequestDetails(GP_ConfigID, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Insert_GatePassRequest(int GP_ConfigID, string strGatePassDate, int DeptID, int GPTypeID, string strGPHeader, string strGPHeaderData, string strGPDoc, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Insert_GatePassRequest(GP_ConfigID, strGatePassDate, DeptID, GPTypeID, strGPHeader, strGPHeaderData, strGPDoc, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_MyRequestGatePass(int CompanyID, string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_MyRequestGatePass(CompanyID,LoggedInUserID, From_Date, To_Date);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_MyActionableGatePass(int CompanyID,string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_MyActionableGatePass(CompanyID,LoggedInUserID, From_Date, To_Date);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_GatePassRequest_Approval_Details(int TransactionID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_GatePassRequest_Approval_Details(TransactionID, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet UpdateAction_GatePassRequest(string TransactionID, string CurrentLevel, string ActionStatus, string strRemarks, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.UpdateAction_GatePassRequest(TransactionID, CurrentLevel, ActionStatus, strRemarks, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    [WebMethod]
    public DataSet Fetch_GatePass_MIS(int CompanyID,string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_GatePass_MIS(CompanyID,LoggedInUserID, From_Date, To_Date);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet GatePassConfiguration_Document_CRUD(int GP_ConfigID, int GatePassDocID, string DocumentHeader, int Mandatory, string LoggedInUserID, string strAction)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.GatePassConfiguration_Document_CRUD(GP_ConfigID, GatePassDocID, DocumentHeader, Mandatory, LoggedInUserID, strAction);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }




    #endregion

    #region Work_Permit

    //Added by RC WorkPermitConfiguration Save
    [WebMethod]
    public DataSet Insert_WorkPermitConfiguration(string strConfigTitle, int CompanyID, string strInitiator, bool LinkDepartment, string strTransactionPrefix, string strXmlWorkPermit_Header, string strXmlWorkPermit_TermCondition, string strXmlApprovalMatrix, bool chkShowApprovalMatrix_Initiator, bool chkShowApprovalMatrix_Approver, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Insert_WorkPermitConfiguration(strConfigTitle, CompanyID, strInitiator, LinkDepartment, strTransactionPrefix, strXmlWorkPermit_Header, strXmlWorkPermit_TermCondition, strXmlApprovalMatrix, chkShowApprovalMatrix_Initiator,chkShowApprovalMatrix_Approver, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    //Added by RC Fetch WP header Ansers
    [WebMethod]
    public DataSet Fetch_Answer()
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_Answer();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_WorkPermitConfiguration(string Initiator, string CompanyID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_WorkPermitConfiguration(Initiator, CompanyID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }



    [WebMethod]
    public DataSet Bind_WorkPermitConfiguration(int WP_ConfigID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Bind_WorkPermitConfiguration(WP_ConfigID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Bind_WorkPermitRequestDetails(int WP_ConfigID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Bind_WorkPermitRequestDetails(WP_ConfigID, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    //[WebMethod]
    //public DataSet Insert_WorkPermitRequest(int WP_ConfigID, string LoggedInUserID, string strWpDate, string strWpSectionHeaderData)
    //{
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        ds = ObjUpkeep.Insert_WorkPermitRequest(WP_ConfigID, LoggedInUserID, strWpDate, strWpSectionHeaderData);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    return ds;
    //}

    [WebMethod]
    public DataSet Insert_WorkPermitRequest(int WP_ConfigID, string LoggedInUserID, string strWpDate, string strWpTpDate, string strWpSectionHeaderData)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Insert_WorkPermitRequest(WP_ConfigID, LoggedInUserID, strWpDate, strWpTpDate, strWpSectionHeaderData);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_WorkPermitRequestSavedData(int WP_ConfigID, string Transaction_ID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_WorkPermitRequestSavedData(WP_ConfigID, Transaction_ID, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Update_WorkPermitRequest(int TransactionID, string LoggedInUserID, string ActionStatus, string Remarks)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Update_WorkPermitRequest(TransactionID, LoggedInUserID, ActionStatus, Remarks);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_MyRequestWorkPermit(string LoggedInUserID, string From_Date, string To_Date, int CompanyID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_MyRequestWorkPermit(LoggedInUserID, From_Date, To_Date, CompanyID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_MyActionableWorkPermit(string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_MyActionableWorkPermit(LoggedInUserID, From_Date, To_Date);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_DashboardCount(int CompanyID, string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_DashboardCount(CompanyID, LoggedInUserID, From_Date, To_Date);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Delete_GatePassConfiguration(int ConfigID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Delete_GatePassConfiguration(ConfigID, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    //Added by RC WorkPermitConfiguration Update

    [WebMethod]
    public DataSet Update_WorkPermitConfiguration(int WP_Config_ID, string strConfigTitle, int CompanyID, string strInitiator, bool LinkDepartment, string strTransactionPrefix, string strXmlWorkPermit_Header, string strXmlWorkPermit_TermCondition, string strXmlApprovalMatrix, bool chkShowApprovalMatrix_Initiator,bool chkShowApprovalMatrix_Approver, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Update_WorkPermitConfiguration(WP_Config_ID, strConfigTitle, CompanyID, strInitiator, LinkDepartment, strTransactionPrefix, strXmlWorkPermit_Header, strXmlWorkPermit_TermCondition, strXmlApprovalMatrix, chkShowApprovalMatrix_Initiator, chkShowApprovalMatrix_Approver, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Bind_WorkPermitSavedConfiguration(int WP_ConfigID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Bind_WorkPermitSavedConfiguration(WP_ConfigID, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    [WebMethod]
    public DataSet Fetch_WorkPermit_MIS(string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_WorkPermit_MIS(LoggedInUserID, From_Date, To_Date);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    [WebMethod]
    public DataSet Delete_WPConfiguration(int ConfigID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Delete_WPConfiguration(ConfigID, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    #endregion

    #region Checklist
    [WebMethod]
    public DataSet Fetch_Chk_Answer()
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_Chk_Answer();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    [WebMethod]
    public DataSet Update_ChecklistConfiguration(int Chk_Config_ID, string strConfigTitle, string strConfigTitleDesc, bool IsScoreEnable, int TotalScore, string strXmlChecklist, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Update_ChecklistConfiguration(Chk_Config_ID, strConfigTitle, strConfigTitleDesc, IsScoreEnable, TotalScore, strXmlChecklist, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    [WebMethod]
    public DataSet Insert_ChecklistConfiguration(string strConfigTitle, string strConfigTitleDesc, bool IsScoreEnable, int TotalScore, string strXmlChecklist, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Insert_ChecklistConfiguration(strConfigTitle, strConfigTitleDesc, IsScoreEnable, TotalScore, strXmlChecklist, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Bind_ChecklistConfiguration(int CHK_ConfigID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Bind_ChecklistConfiguration(CHK_ConfigID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    [WebMethod]
    public DataSet Fetch_MyChecklist(string LoggedInUserID, string CompanyID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_MyChecklist(LoggedInUserID, CompanyID, From_Date, To_Date);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    //Added by Sujata this function is used to delete CHK config 
    [WebMethod]
    public DataSet Delete_CHKConfiguration(int ConfigID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Delete_CHKConfiguration(ConfigID, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    [WebMethod]
    public DataSet Fetch_MyChecklistReportList(string LoggedInUserID, string CompanyID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_MyChecklistReportList(LoggedInUserID, CompanyID, From_Date, To_Date);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_My_Department_Checklists(string LoggedInUserID, string CompanyID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_My_Department_Checklists(LoggedInUserID, CompanyID, From_Date, To_Date);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_MyChecklists(string LoggedInUserID, string CompanyID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_MyChecklists(LoggedInUserID, CompanyID, From_Date, To_Date);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Checklist_Report(string Response_ID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_Checklist_Report(Response_ID, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Checklist_Consolidated_Report(int Chk_Config_ID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_Checklist_Consolidated_Report(Chk_Config_ID, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Save_Checklist_Schedule(int Checklist_ConfigID,int DepartmentID,string SelectedLocationID,string LoggedInUserID,int CompanyID)
    {
        DataSet dsChecklist = new DataSet();
        try
        {
            dsChecklist = ObjUpkeep.Save_Checklist_Schedule(Checklist_ConfigID, DepartmentID, SelectedLocationID, LoggedInUserID, CompanyID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dsChecklist;
    }


    [WebMethod]
    public DataSet Save_Checklist_Schedule_NEW(int Chk_Map_ID,int Checklist_ConfigID, int DepartmentID, string SelectedLocationID, string LoggedInUserID, int CompanyID,string Action)
    {
        DataSet dsChecklist = new DataSet();
        try
        {
            dsChecklist = ObjUpkeep.Save_Checklist_Schedule_NEW(Chk_Map_ID,Checklist_ConfigID, DepartmentID, SelectedLocationID, LoggedInUserID, CompanyID, Action);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dsChecklist;
    }




    #endregion

    #region VMS

    //Added by RC This function is used to save VMS Configuration 
    [WebMethod]
    public DataSet Insert_Update_VMSConfiguration(int ConfigID, string strConfigTitle, string strConfigDesc, int CompanyID, string strInitiator, string strXmlVMS_Question, bool blFeedbackCompulsary, int FeedbackTitle, bool blEnableCovid, int EntryCount, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Insert_Update_VMSConfiguration(ConfigID, strConfigTitle, strConfigDesc, CompanyID, strInitiator, strXmlVMS_Question, blFeedbackCompulsary, FeedbackTitle, blEnableCovid, EntryCount, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    //Added by RC This function is used to Fetch VMS Config
    [WebMethod]
    public DataSet Fetch_VMSConfiguration(int CompanyID, string Initiator)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_VMSConfiguration(CompanyID, Initiator);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    //Added by RC This function is used to bind VMS Config
    [WebMethod]
    public DataSet Bind_VMSConfiguration(int VMS_ConfigID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Bind_VMSConfiguration(VMS_ConfigID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    //Added by RC This function is used to Fetch VMS Request list
    [WebMethod]
    public DataSet Fetch_VMSRequestList(int CompanyID, string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_VMSRequestList(CompanyID, LoggedInUserID, From_Date, To_Date);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    //Added by RC This function is used to bind VMS request details
    [WebMethod]
    public DataSet Bind_VMSRequestDetails(int RequestID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Bind_VMSRequestDetails(RequestID, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    //Added by RC This function is used to save VMS Request
    [WebMethod]
    public DataSet Insert_VMSRequest(int CompanyID, char Action, int RequestID, int VMS_ConfigID, string Name, string Email, string Phone, string strVMSDate, string strMeetUsrs, string strVMSData, string strVMSCovidColorCode, string strVMSCovidTestDate, string strTemperature, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Insert_VMSRequest(CompanyID, Action, RequestID, VMS_ConfigID, Name, Email, Phone, strVMSDate, strMeetUsrs, strVMSData, strVMSCovidColorCode, strVMSCovidTestDate, strTemperature, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    //Added by RC This function is used to Fetch Visit Form Url for Session less User 
    [WebMethod]
    public DataSet Fetch_VMSFormURL(string ShortUrl)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_VMSFormURL(ShortUrl);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    //Added by Sujata this function is used to delete VMS config 
    [WebMethod]
    public DataSet Delete_VMSConfiguration(int ConfigID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Delete_VMSConfiguration(ConfigID, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    #endregion

    #region CSM
    //Added by RC This function is used to save CSM Configuration 
    [WebMethod]
    public DataSet Insert_Update_CSMConfiguration(int ConfigID, string strConfigTitle, int CompanyID, string Description, string strXmlIn_Question, string strXmlOut_Question, string strXmlCSM_Terms, bool blFreeService, string CostUnit, string RequestFlowID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Insert_Update_CSMConfiguration(ConfigID, strConfigTitle, CompanyID, Description, strXmlIn_Question, strXmlOut_Question, strXmlCSM_Terms, blFreeService, CostUnit,RequestFlowID, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    //Added by RC This function is used to Fetch CSM Config
    [WebMethod]
    public DataSet Fetch_CSMConfiguration(int CompanyID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_CSMConfiguration(CompanyID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    //Added by RC This function is used to bind CSM Config
    [WebMethod]
    public DataSet Bind_CSMConfiguration(int ConfigID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Bind_CSMConfiguration(ConfigID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    //Added by RC this function is used to delete CSM config 
    [WebMethod]
    public DataSet Delete_CSMConfiguration(int ConfigID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Delete_CSMConfiguration(ConfigID, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    //Added by RC This function is used to save CSM Request
    [WebMethod]
    public DataSet Insert_CSMRequest(int CompanyID, char Action, int RequestID, int ConfigID, string strCSMData, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Insert_CSMRequest(CompanyID, Action, RequestID, ConfigID, strCSMData, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    //Added by RC This function is used to Fetch VMS Request list
    [WebMethod]
    public DataSet Fetch_CSMRequestList(int CompanyID, string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_CSMRequestList(CompanyID, LoggedInUserID, From_Date, To_Date);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    //Added by RC This function is used to bind VMS request details
    [WebMethod]
    public DataSet Bind_CSMRequestDetails(int RequestID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Bind_CSMRequestDetails(RequestID, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    #endregion

    #region General Functions

    //Added by RC This function is used to Fetch Answer type master

    [WebMethod]
    public DataSet Fetch_AnswerForAll(char Key)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_AnswerForAll(Key);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_User_UserGroupListGPWP(string Initiator)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_User_UserGroupListGPWP(Initiator);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Company()
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_Company();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    //Added by RC This function is used to Log error

    [WebMethod]
    public DataSet Error_Log(string Extype, string Page, string Errormsg, string StackTrace, string CompanyID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Error_Log(Extype, Page, Errormsg, StackTrace, CompanyID, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    #endregion



    #region Asset Management
    [WebMethod]
    public DataSet Fetch_Asset_DropDown(int UserID,int CompanyID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_Asset_DropDown(UserID, CompanyID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    [WebMethod]
    public DataSet Fetch_Asset_Vendor_DropDown(string VendorPrefix, int UserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_Asset_Vendor_DropDown(VendorPrefix, UserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    [WebMethod]
    public DataSet ASSET_Insert_AssetType(string LoggedInUserID, int companyID, string AssetType)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.ASSET_Insert_AssetType(LoggedInUserID, companyID, AssetType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet ASSET_Insert_AssetCategory(string LoggedInUserID, int companyID, int AssetTypeID, string AssetCategory)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.ASSET_Insert_AssetCategory(LoggedInUserID, companyID, AssetTypeID, AssetCategory);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet ASSET_INSERT_GRNL_MASTER(string LoggedInUserID, string MasterType, string Dept_Value, string LocationXmlValue, string VendorXmlValue)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.ASSET_INSERT_GRNL_MASTER(LoggedInUserID, MasterType, Dept_Value, LocationXmlValue, VendorXmlValue);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_MyAsset(string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_MyAsset(LoggedInUserID, From_Date, To_Date);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_ASSET_REQUEST_Details(string LoggedInUserID, int TransactionID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_ASSET_REQUEST_Details(LoggedInUserID, TransactionID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet INSERT_ASSET_REQUEST_Details(string LoggedInUserID, string AssetXml, string AssetAmcXml, string AssetServiceXml)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.INSERT_ASSET_REQUEST_Details(LoggedInUserID, AssetXml, AssetAmcXml, AssetServiceXml);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet UPDATE_ASSET_REQUEST_Details(string LoggedInUserID, string TransactionID, string AssetXml, string AssetAmcXml, string AssetServiceXml)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.UPDATE_ASSET_REQUEST_Details(LoggedInUserID, TransactionID, AssetXml, AssetAmcXml, AssetServiceXml);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet INSERT_UPDATE_ASSET_AMC_REQUEST_Details(string LoggedInUserID, string TransactionID, string AssetAmcXml, string Flag)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.INSERT_UPDATE_ASSET_AMC_REQUEST_Details(LoggedInUserID, TransactionID, AssetAmcXml, Flag);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_MyAsset_Service(string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_MyAsset_Service(LoggedInUserID, From_Date, To_Date);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet CRUD_ASSET_SERVICE_REQUEST_DATA(string LoggedInUserID, string AssetID, string ServiceScheduleID, string AssetServiceXml, string Flag)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.CRUD_ASSET_SERVICE_REQUEST_DATA(LoggedInUserID, AssetID, ServiceScheduleID, AssetServiceXml, Flag);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    #endregion


    #region Inventory

    [WebMethod]
    public DataSet Fetch_Transaction_List(string LoggedInUserID, string CompanyID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_Transaction_List(LoggedInUserID, CompanyID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Delete_Inv_Transaction(int TransactionID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Delete_Inv_Transaction(TransactionID, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Stock_List(string LoggedInUserID, string CompanyID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_Stock_List(LoggedInUserID, CompanyID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    [WebMethod]
    public DataSet Delete_Inv_Stock(int ItemId, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Delete_Inv_Stock(ItemId, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    [WebMethod]
    public DataSet Delete_Inv_Item(int ItemId, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Delete_Inv_Item(ItemId, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Stock_Detail(string LoggedInUserID, string CompanyID, int StockId)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_Stock_Detail(LoggedInUserID, CompanyID, StockId);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Inv_Items_List(string LoggedInUserID, string CompanyID, string XmlItem)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_Inv_Items_List(LoggedInUserID, CompanyID, XmlItem);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    [WebMethod]
    public DataSet Fetch_Inv_Item_Stock_Ddl(string LoggedInUserID, string CompanyID, string StockID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_Inv_Item_Stock_Ddl(LoggedInUserID, CompanyID, StockID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Inv_Crud_Item_Stock(string LoggedInUserID, string CompanyID, string StockID, string XmlItem)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_Inv_Crud_Item_Stock(LoggedInUserID, CompanyID, StockID, XmlItem);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    [WebMethod]
    public DataSet Fetch_Inv_Item_Stock_Data(string LoggedInUserID, string CompanyID, string StockID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_Inv_Item_Stock_Data(LoggedInUserID, CompanyID, StockID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Inv_Item_Purchase_List(string LoggedInUserID, string CompanyID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_Inv_Item_Purchase_List(LoggedInUserID, CompanyID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    [WebMethod]
    public DataSet Delete_Inv_Purchase(int ItemId, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Delete_Inv_Purchase(ItemId, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    [WebMethod]
    public DataSet Crud_Inv_Purchase(string LoggedInUserID, string CompanyID, string PurchaseID, string XmlItem)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Crud_Inv_Purchase(LoggedInUserID, CompanyID, PurchaseID, XmlItem);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Inv_Crud_Item(string LoggedInUserID, string CompanyID, string StockID, string XmlItem)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_Inv_Crud_Item(LoggedInUserID, CompanyID, StockID, XmlItem);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Tran_Detail(string LoggedInUserID, string CompanyID, int TransID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_Tran_Detail(LoggedInUserID, CompanyID, TransID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Tran_Item_Detail(string LoggedInUserID, string CompanyID, int TransID, string XmlItem)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_Tran_Item_Detail(LoggedInUserID, CompanyID, TransID, XmlItem);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    [WebMethod]
    public DataSet Crud_Inv_Transaction(string LoggedInUserID, string CompanyID, string DeptID, string TranID, string XmlItem)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Crud_Inv_Transaction(LoggedInUserID, CompanyID, DeptID, TranID, XmlItem);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Crud_Inv_Category_Mst(string LoggedInUserID, string CompanyID, int CategoryID, string CategoryDesc, string Action)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Crud_Inv_Category_Mst(LoggedInUserID, CompanyID, CategoryID, CategoryDesc, Action);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    [WebMethod]
    public DataSet Crud_Inv_SubCategory_Mst(string LoggedInUserID, string CompanyID, string CategoryID, int SubCategoryID, string SubCategoryDesc, string Action)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Crud_Inv_SubCategory_Mst(LoggedInUserID, CompanyID, CategoryID, SubCategoryID, SubCategoryDesc, Action);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }
    [WebMethod]
    public DataSet Crud_Inv_Item_Mst(string LoggedInUserID, string CompanyID, string CategoryID, string SubCategoryID, int ItemID, string ItemDesc, int DeptID,
            int Opening, int Optimum, int Reorder, int Base, int CostRate, string Action)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Crud_Inv_Item_Mst(LoggedInUserID, CompanyID, CategoryID, SubCategoryID, ItemID, ItemDesc, DeptID,
             Opening, Optimum, Reorder, Base, CostRate, Action);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    #endregion

    #region My Profile

    [WebMethod]
    public DataSet Fetch_My_Profile_Details(string LoggedInUserID, string UserType, int CompanyID)
    {
        DataSet dsProfile = new DataSet();
        try
        {
            dsProfile = ObjUpkeep.Fetch_My_Profile_Details(LoggedInUserID, UserType, CompanyID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dsProfile;
    }

    [WebMethod]
    public DataSet Update_My_Profile_Details(string PhoneNo, string AltPhoneNo, string EmailID, string Address, string City, string State, string Postcode, string LoggedInUserID, string UserType, int CompanyID)
    {
        DataSet dsProfile = new DataSet();
        try
        {
            dsProfile = ObjUpkeep.Update_My_Profile_Details(PhoneNo, AltPhoneNo, EmailID, Address, City, State, Postcode, LoggedInUserID, UserType, CompanyID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dsProfile;
    }

    [WebMethod]
    public DataSet Update_Change_Password(string Username, string CurrentPassword, string NewPassword, int CompanyID, string UserType)
    {
        DataSet dsChangePassword = new DataSet();
        try
        {
            dsChangePassword = ObjUpkeep.Update_Change_Password(Username, CurrentPassword, NewPassword, CompanyID, UserType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dsChangePassword;
    }

    [WebMethod]
    public DataSet Retailer_Escalation_CRUD(int EscalationID, string Name, string Designation, string Department, string ContactNo, string EmailID, string LoggedInUserID, int CompanyID, string strAction)
    {
        DataSet dsEscalation = new DataSet();
        try
        {
            dsEscalation = ObjUpkeep.Retailer_Escalation_CRUD(EscalationID, Name, Designation, Department, ContactNo, EmailID, LoggedInUserID, CompanyID, strAction);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dsEscalation;
    }

    [WebMethod]
    public DataSet My_Profile_Email_Verification(int Is_Email_Verified,string LoggedInUserID, int CompanyID)
    {
        DataSet dsProfile = new DataSet();
        try
        {
            dsProfile = ObjUpkeep.My_Profile_Email_Verification(Is_Email_Verified, LoggedInUserID, CompanyID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dsProfile;
    }



    #endregion

    [WebMethod]
    public DataSet Import_User_Master(int CompanyID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();

        try
        {
            My_Upkeep obj = new My_Upkeep();

            ds = obj.Import_User_Master(CompanyID, LoggedInUserID);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }


    [WebMethod]
    public DataSet Import_Checklist_Master(int CompanyID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();

        try
        {
            My_Upkeep obj = new My_Upkeep();

            ds = obj.Import_Checklist_Master(CompanyID, LoggedInUserID);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }


    [WebMethod]
    public DataSet Schedule_Checklist_CRUD(int CompanyID)
    {
        DataSet ds = new DataSet();

        try
        {
            My_Upkeep obj = new My_Upkeep();

            ds = obj.Schedule_Checklist_CRUD(CompanyID);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }



    [WebMethod]
    public DataSet Fetch_MyChecklist_NEW( int Chk_Config_ID,string LoggedInUserID, string CompanyID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_MyChecklist_NEW(Chk_Config_ID,LoggedInUserID, CompanyID, From_Date, To_Date);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    [WebMethod]
    public DataSet CRU_System_Setting(int Setting_ID, int Tkt_Is_Img_Open, int Tkt_Is_Img_Close, int Tkt_Is_Remark_Open, int Tkt_Is_Remark_Close, int Tkt_Is_Expiry, int Chk_Is_QR_Compulsory, int CompanyID, string LoggedInUserID, string Action)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.CRU_System_Setting( Setting_ID, Tkt_Is_Img_Open, Tkt_Is_Img_Close, Tkt_Is_Remark_Open, Tkt_Is_Remark_Close, Tkt_Is_Expiry, Chk_Is_QR_Compulsory, CompanyID, LoggedInUserID,  Action);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Custom_Fields(int CompanyID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_Custom_Fields(CompanyID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }



    [WebMethod]
    public DataSet FetchUserEmail(string EmailID, string UserType, int CompanyID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.FetchUserEmail(EmailID,UserType,CompanyID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    [WebMethod]
    public DataSet ForgetPasswordSendOTP(string EmailID, string OTP, int CompanyID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.ForgetPasswordSendOTP(EmailID, OTP, CompanyID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    [WebMethod]
    public DataSet UpdatePassword(string User_ID , string EmailID, string Password,string UserType, int CompanyID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.UpdatePassword(User_ID,EmailID, Password, UserType, CompanyID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    [WebMethod]
    public DataSet SiteMaster_CRUD(int Site_ID, string Site_Code, string Site_Name, int CompanyID, string LoggedInUserID,string Action)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.SiteMaster_CRUD(Site_ID, Site_Code, Site_Name, CompanyID, LoggedInUserID, Action);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    [WebMethod]
    public DataSet Fetch_states(int Country_Id)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_states(Country_Id);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_City(int State_Id)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_City(State_Id);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    #region Electricity Monitoring

    [WebMethod]
    public DataSet INSERT_Electricity_Category(string Electricity_CatXML, int CompanyID, string LoggedInUserID, int Electricity_Cat_ID,string strAction)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.INSERT_Electricity_Category(Electricity_CatXML, CompanyID, LoggedInUserID, Electricity_Cat_ID, strAction);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    #endregion

}

public class AuthenticationHeader : SoapHeader
{
    public string serviceId;
    public string ServicePassword;
}