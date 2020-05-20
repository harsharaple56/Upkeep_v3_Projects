﻿using System;
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
    public DataSet UserTypeMaster_CRUD(int User_Type_ID, string User_Type_Desc,int CompanyID, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjUpkeep.UserTypeMaster_CRUD(User_Type_ID,User_Type_Desc, CompanyID, LoggedInUserID, Action);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet DepartmentMaster_CRUD(int Department_ID,string Dept_Desc,int CompanyID, string LoggedInUserID,string Is_Deleted,string Action)
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
        catch(Exception ex)
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
        catch(Exception ex)
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
        catch(Exception ex)
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
    public DataSet UserMaster_CRUD(int User_ID, string User_Code, string F_name, string L_Name, string User_Mobile, string User_Email, string User_MobileAlter, string User_Landline, string User_Designation, int User_Type_ID, int Zone_ID, int Loc_ID, int SubLoc_Id, int Department_Id, string Login_Id, string Password, int Is_Approver, int Is_GobalApprover, string Approver_ID, string Profilephoto,int CompanyID, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjUpkeep.UserMaster_CRUD(User_ID, User_Code, F_name, L_Name, User_Mobile, User_Email, User_MobileAlter, User_Landline, User_Designation, User_Type_ID, Zone_ID, Loc_ID, SubLoc_Id, Department_Id, Login_Id, Password, Is_Approver, Is_GobalApprover, Approver_ID, Profilephoto, CompanyID, LoggedInUserID,  Action);

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
          
            ds = ObjUpkeep.LoginUser(UserId, strPassword);

        }
        catch (Exception ex)
        {
            throw ex;

        }

        return ds;
    }

    [WebMethod]
    public DataSet PriorityMaster_CRUD(int Priority_ID, string Priority_Desc,int CompanyID, string LoggedInUserID, string Action)
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
    public DataSet FrequencyMaster_CRUD(int Frquency_Id, string Frquency_Desc,int CompanyID, string LoggedInUserID, string Action)
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
    public DataSet ZoneMaster_CRUD(int ZoneID,int CompanyID, string ZoneCode,string ZoneDesc, string LoggedInUserID, string Action)
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
    public DataSet SubLocationMaster_CRUD(int SubLocID,string LocName, string Zone, string SubLocCode, string SubLocDesc, string LoggedInUserID, string Action)
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
    public DataSet UserGroupMaster_CRUD(int Grp_Id, string Grp_Desc,string User_ID,int CompanyID, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjUpkeep.UserGroupMaster_CRUD(Grp_Id, Grp_Desc,User_ID, CompanyID, LoggedInUserID, Action);

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
            ds = ObjUpkeep.FetchUserGrp(GroupID,CompanyID);
        }
        catch(Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_CategorySubCategory(int CategoryID)
    {
        try
        {
            ds = ObjUpkeep.Fetch_CategorySubCategory(CategoryID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet WorkflowMaster_CRUD(int WorkflowID, string WorkflowDesc,int ZoneID, int CategoryID, int SubCategoryID, string xmlWorkflow,int CompanyID, string LoggedInUserID, string Action)
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
    public DataSet Fetch_User_UserGroupList()
    {
        try
        {
            ds = ObjUpkeep.Fetch_User_UserGroupList();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet CategoryMaster_CRUD(int CompanyID,int Category_ID, string Category_Desc, int DepartmentID, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjUpkeep.CategoryMaster_CRUD(CompanyID,Category_ID, Category_Desc, DepartmentID,LoggedInUserID, Action);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet SubCategoryMaster_CRUD(int CompanyID, int SubcategoryID, string SubCategoryDesc, int CategoryID, int Approval_Required, string LoggedInUserID, string Action)
    {
        try
        {
            ds = ObjUpkeep.SubCategoryMaster_CRUD(CompanyID,SubcategoryID, SubCategoryDesc, CategoryID, Approval_Required, LoggedInUserID, Action);

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

    [WebMethod]
    public DataSet Fetch_Ticket_Workflow(int CompanyID, int CategoryID, int SubCategoryID,string TicketPrefix,string LoggedInUserID)
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
    public DataSet Insert_Ticket_Details(string TicketCode, int CompanyID, int LocationID, int CategoryID, int SubCategoryID, string TicketMessage,string list_Images, string LoggedInUserID, string strAction)
    {
        try
        {
            ds = ObjUpkeep.Insert_Ticket_Details(TicketCode, CompanyID, LocationID, CategoryID, SubCategoryID, TicketMessage, list_Images, LoggedInUserID,strAction);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_Ticket_MyActionable(int CompanyID,string LoggedInUserID)
    {
        try
        {
            ds = ObjUpkeep.Fetch_Ticket_MyActionable(CompanyID, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }




    //[+][Feedback System Methods]
    #region Feedback System Methods


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
    public DataSet Retailer_CRUD(string storeName, string firstName, string lastName, string email, Int64 phone, int RetailerID,int CompanyID, string LoggedInUserID, string actionType)
    {
        DataSet ds = new DataSet();

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();

            ds = obj.Retailer_CRUD(storeName, firstName, lastName, email, phone, RetailerID, CompanyID, LoggedInUserID, actionType);

        }
        catch (Exception ex)
        {
            throw ex;
             
        }

        return ds;
    }

    
    [WebMethod]
    public DataSet Event_Insert(string eventName, string locationName, string startDateTime, string endDateTime, string CustomerQuestion, string CustQuesType, string QuesFor, int EventID, string EventMode, string LoggedInUserID, string option1, string option2, string option3, string option4)
    {
        DataSet ds = new DataSet();

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();

            //ds = obj.Event_Insert(eventName, locationName, startDateTime, endDateTime, CustomerQuestion, CustQuesType, RetailerQuestion, RetQuesType, EventID);
            ds = obj.Event_Insert(eventName, locationName, startDateTime, endDateTime, CustomerQuestion, CustQuesType, QuesFor, EventID, EventMode, LoggedInUserID, option1, option2, option3, option4);

        }
        catch (Exception ex)
        {
            throw ex;
             
        }

        return ds;
    }


    [WebMethod]
    public DataSet EventDetails_CRUD(int EventID, string actionType)
    {
        DataSet ds = new DataSet();

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();

            ds = obj.EventDetails_CRUD(EventID, actionType);

        }
        catch (Exception ex)
        {
            throw ex;
             
        }

        return ds;
    }

    [WebMethod]
    public DataSet bindEventDetails(int EventID)
    {
        DataSet ds = new DataSet();

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();

            ds = obj.bindEventDetails(EventID);

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
    public DataSet Fetch_MIS_Report(string EventID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();

            ds = obj.Fetch_MIS_Report(EventID, From_Date, To_Date);

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
    public DataSet GetEventList()
    {
        DataSet dsEventList = new DataSet();
        My_FeedbackSystem obj = new My_FeedbackSystem();

        dsEventList = obj.GetEventList();

        return dsEventList;
    }

    [WebMethod]
    public DataSet Fetch_MIS_Report_Excel(string EventID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();

            ds = obj.Fetch_MIS_Report_Excel(EventID, From_Date, To_Date);

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
    public DataSet AddChecklistMaster_CRUD(int ChecklistID, string ChecklistName, int DeptID, Boolean Chkapproval, Boolean ChkExpry, Boolean ChkSchedule, int ExpirytimeID, DateTime dtSchedule_Date, string StartTime, string EndTime, int CustFrequency, int Frquency_Id, int ZoneID, int LocationID, int SubLocationID,string strXmlChecklistPoint, string LoggedInUserID, string Action)
    {
        DataSet dsAddChecklist = new DataSet();
        try
        {
            dsAddChecklist= ObjUpkeep.AddChecklistMaster_CRUD(ChecklistID, ChecklistName, DeptID, Chkapproval, ChkExpry, ChkSchedule, ExpirytimeID, dtSchedule_Date, StartTime, EndTime, CustFrequency, Frquency_Id, ZoneID, LocationID, SubLocationID, strXmlChecklistPoint, LoggedInUserID, Action);
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
    public DataSet ChecklistPoint_CRUD(int ChecklistID, int ChecklistPointID,string strChecklistPointDesc, string strChecklstAnstype, string LoggedInUserID, string Action)
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
    public DataSet ChecklistRequest(string ScheduleDate,int ZoneID, int LocationID, int SubLocationID, int DepartmentID, int ChecklistID,string StartTime,string TicketNumber, string LoggedInUserID, string strAction)
    {
        try
        {
            ds = ObjUpkeep.ChecklistRequest(ScheduleDate, ZoneID, LocationID, SubLocationID, DepartmentID, ChecklistID, StartTime, TicketNumber,LoggedInUserID, strAction);

        }
        catch (Exception ex)
        {
            throw ex;

        }
        return ds;
    }


    [WebMethod]
    public DataSet Update_ChecklistPoints(string TicketNumber,  string strXmlChecklist, string list_Images, string LoggedInUserID)
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
    public DataSet Close_Ticket_Details(string TicketID, string CloseTicketDesc,  string LoggedInUserID, string list_Images)
    {
        try
        {
            ds = ObjUpkeep.Close_Ticket_Details(TicketID, CloseTicketDesc, LoggedInUserID, list_Images);
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
    public DataSet Add_Update_Location_Node(int ParentID, string Location_Node,int CompanyID,string LoggedInUserID,string strAction)
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
    public DataSet FetchMenu(int parentMenuId, string LoggedInUserID)
    {
        DataSet dtMenu = new DataSet();
        try
        {
            dtMenu = ObjUpkeep.FetchMenu(parentMenuId, LoggedInUserID);
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

    #region VMS

    //Added by RC This function is used to save VMS Configuration 
    [WebMethod]
    public DataSet Insert_VMSConfiguration(string strConfigTitle, string strConfigDesc, int CompanyID, string strXmlVMS_Question, string strXmlVMS_Feedback, bool blFeedbackCompulsary, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Insert_VMSConfiguration(strConfigTitle, strConfigDesc, CompanyID, strXmlVMS_Question, strXmlVMS_Feedback, blFeedbackCompulsary, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    //Added by RC This function is used to Fetch VMS Config
    [WebMethod]
    public DataSet Fetch_VMSConfiguration(string Initiator)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_VMSConfiguration(Initiator);
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
    public DataSet Fetch_MyRequestVMS(string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_MyRequestVMS(LoggedInUserID, From_Date, To_Date);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    //Added by RC This function is used to bind VMS request details
    [WebMethod]
    public DataSet Bind_VMSRequestDetails(int VMS_ConfigID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Bind_VMSRequestDetails(VMS_ConfigID, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    //Added by RC This function is used to save VMS Request
    [WebMethod]
    public DataSet Insert_VMSRequest(int CompanyID, int VMS_ConfigID, string strVMSDate, string strMeetUsrs, string strVMSData, string strVMSFeedbackData, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Insert_VMSRequest(CompanyID,VMS_ConfigID, strVMSDate, strMeetUsrs, strVMSData, strVMSFeedbackData, LoggedInUserID);
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
    public DataSet Fetch_Answer(char Key)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_Answer(Key);
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
    public DataSet Fetch_Asset_DropDown(int UserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_Asset_DropDown(UserID);
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

}

public class AuthenticationHeader : SoapHeader
{
    public string serviceId;
    public string ServicePassword;
}