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
/// Summary description for My_Upkeep
/// </summary>
public class My_Upkeep
{
    UpkeepV3_BusinessLayer.My_Upkeep_BL ObjUpkeepCC_BL = new UpkeepV3_BusinessLayer.My_Upkeep_BL();
    string StrConn;
    DataSet ds = new DataSet();
    public My_Upkeep()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet MenuMaster_CRUD(int Menu_ID, string Menu_Desc, string Parent_Menu_Id, string Toot_Tip, string Menu_Url, string Module_Menu_Id, string Is_Deleted, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;

            ds = ObjUpkeepCC_BL.MenuMaster_CRUD(Menu_ID, Menu_Desc, Parent_Menu_Id, Toot_Tip, Menu_Url, Module_Menu_Id, Is_Deleted, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataSet UserTypeMaster_CRUD(int User_Type_ID, string User_Type_Desc, int CompanyID, string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.UserTypeMaster_CRUD(User_Type_ID, User_Type_Desc, CompanyID, LoggedInUserID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet DepartmentMaster_CRUD(int Department_ID, string Dept_Desc, int CompanyID, string LoggedInUserID, string Is_Deleted, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.DepartmentMaster_CRUD(Department_ID, Dept_Desc, CompanyID, LoggedInUserID, Is_Deleted, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet PriorityMaster_CRUD(int Priority_ID, string Priority_Desc, int CompanyID, string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.PriorityMaster_CRUD(Priority_ID, Priority_Desc, CompanyID, LoggedInUserID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet FrequencyMaster_CRUD(int Frquency_Id, string Frquency_Desc, int CompanyID, string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.FrequencyMaster_CRUD(Frquency_Id, Frquency_Desc, CompanyID, LoggedInUserID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet ZoneMaster_CRUD(int ZoneID, int CompanyID, string ZoneCode, string ZoneDesc, string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.ZoneMaster_CRUD(ZoneID, CompanyID, ZoneCode, ZoneDesc, LoggedInUserID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet FetchZone()
    {

        try
        {
            StrConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();

            ds = ObjUpkeepCC_BL.FetchZone(StrConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


    public DataSet FetchLocation(int Zone_ID)
    {
        try
        {
            StrConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();

            ds = ObjUpkeepCC_BL.FetchLocation(Zone_ID, StrConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }

    public DataSet FetchSubLocation(int Loc_ID)
    {
        try
        {
            StrConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();

            ds = ObjUpkeepCC_BL.FetchSubLocation(Loc_ID, StrConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataSet FetchDepartment(int CompanyID)  //Added CompanyId by sujata
    {
        try
        {
            StrConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();

            ds = ObjUpkeepCC_BL.FetchDepartment(CompanyID, StrConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }

    public DataSet FetchUserType(int CompanyID)  //Added CompanyId by sujata
    {
        try
        {
            StrConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();

            ds = ObjUpkeepCC_BL.FetchUserType(CompanyID, StrConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }

    public DataSet UserMaster_CRUD(int User_ID, string User_Code, string F_name, string L_Name, string User_Mobile, string User_Email, string User_MobileAlter, string User_Landline, string User_Designation, int User_Type_ID, int Zone_ID, int Loc_ID, int SubLoc_Id, int Department_Id, string Login_Id, string Password, int Is_Approver, int Is_GobalApprover, int Approver_ID, int RoleID, string Profilephoto, int CompanyID, string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.UserMaster_CRUD(User_ID, User_Code, F_name, L_Name, User_Mobile, User_Email, User_MobileAlter, User_Landline, User_Designation, User_Type_ID, Zone_ID, Loc_ID, SubLoc_Id, Department_Id, Login_Id, Password, Is_Approver, Is_GobalApprover, Approver_ID, RoleID, Profilephoto, CompanyID, LoggedInUserID, Action, StrConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet LoginUser(string UserName, string strPassword, string UserType, int CompanyID)
    {
        try
        {
            StrConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            ds = ObjUpkeepCC_BL.LoginUser(UserName, strPassword, UserType, CompanyID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet LocationMaster_CRUD(int LocID, string Zone, string LocCode, string LocDesc, string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.LocationMaster_CRUD(LocID, Zone, LocCode, LocDesc, LoggedInUserID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet UserGroupMaster_CRUD(int Grp_Id, string Grp_Desc, string User_ID, int CompanyID, string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.UserGroupMaster_CRUD(Grp_Id, Grp_Desc, User_ID, CompanyID, LoggedInUserID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet SubLocationMaster_CRUD(int SubLocID, string LocName, string Zone, string SubLocCode, string SubLocDesc, string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.SubLocationMaster_CRUD(SubLocID, LocName, Zone, SubLocCode, SubLocDesc, LoggedInUserID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet FetchUserGrp(int GroupID, int CompanyID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.FetchUserGrp(GroupID, CompanyID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_CategorySubCategory(int CategoryID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_CategorySubCategory(CategoryID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet WorkflowMaster_CRUD(int WorkflowID, string WorkflowDesc, int ZoneID, int CategoryID, int SubCategoryID, string xmlWorkflow, int CompanyID, string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.WorkflowMaster_CRUD(WorkflowID, WorkflowDesc, ZoneID, CategoryID, SubCategoryID, xmlWorkflow, CompanyID, LoggedInUserID, Action, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_User_UserGroupList(int CompanyID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_User_UserGroupList(CompanyID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet CategoryMaster_CRUD(int CompanyID, int Category_ID, string Category_Desc, int DepartmentID, string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.CategoryMaster_CRUD(CompanyID, Category_ID, Category_Desc, DepartmentID, LoggedInUserID, Action, StrConn);
            //return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    public DataSet SubCategoryMaster_CRUD(int ComapnyID, int SubcategoryID, string SubCategoryDesc, int CategoryID, int Approval_Required, string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.SubCategoryMaster_CRUD(ComapnyID, SubcategoryID, SubCategoryDesc, CategoryID, Approval_Required, LoggedInUserID, Action, StrConn);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    public DataSet BindLocationDetails(int ZoneID, int LocationID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.BindLocationDetails(ZoneID, LocationID, StrConn);
            //return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    public DataSet Fetch_LocationTree(int CompanyID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_LocationTree(CompanyID, StrConn);
            //return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    public DataSet Fetch_Ticket_Workflow(int CompanyID, int CategoryID, int SubCategoryID, string TicketPrefix, string LoggedInUserID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_Ticket_Workflow(CompanyID, CategoryID, SubCategoryID, TicketPrefix, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //return ds;
    }

    public DataSet Insert_Ticket_Details(string TicketCode, int CompanyID, int LocationID, int CategoryID, int SubCategoryID, string TicketMessage, string list_Images, string LoggedInUserID, string strAction)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Insert_Ticket_Details(TicketCode, CompanyID, LocationID, CategoryID, SubCategoryID, TicketMessage, list_Images, LoggedInUserID, strAction, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //return ds;
    }

    public DataSet Fetch_Ticket_MyActionable(int TicketID, int CompanyID, string LoggedInUserID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_Ticket_MyActionable(TicketID, CompanyID, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //return ds;
    }

    public DataSet Accept_Ticket(int TicketID, string LoggedInUserID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Accept_Ticket(TicketID, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //return ds;
    }

    public DataSet Fetch_CTT_Report(int CompanyID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            //string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_CTT_Report(CompanyID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //return ds;
    }

    public DataSet Bind_Ticket_Details(int TicketID, int CompanyID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            //string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Bind_Ticket_Details(TicketID, CompanyID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //return ds;
    }


    public DataSet AddChecklistMaster_CRUD(int ChecklistID, string ChecklistName, int DeptID, Boolean Chkapproval, Boolean ChkExpry, Boolean ChkSchedule, int ExpirytimeID, DateTime dtSchedule_Date, string StartTime, string EndTime, int CustFrequency, int Frquency_Id, int ZoneID, int LocationID, int SubLocationID, string strXmlChecklistPoint, string LoggedInUserID, string Action)
    {
        DataSet dsAddChecklist = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            dsAddChecklist = ObjUpkeepCC_BL.AddChecklistMaster_CRUD(ChecklistID, ChecklistName, DeptID, Chkapproval, ChkExpry, ChkSchedule, ExpirytimeID, dtSchedule_Date, StartTime, EndTime, CustFrequency, Frquency_Id, ZoneID, LocationID, SubLocationID, strXmlChecklistPoint, LoggedInUserID, Action, StrConn);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dsAddChecklist;
    }

    public DataSet FetchMenu(int parentMenuId)
    {
        DataSet dtMenu = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            dtMenu = ObjUpkeepCC_BL.FetchMenu(parentMenuId, StrConn);
            return dtMenu;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //return ds;
    }

    public DataSet ChecklistPoint_CRUD(int ChecklistID, int ChecklistPointID, string strChecklistPointDesc, string strChecklstAnstype, string LoggedInUserID, string Action)
    {
        DataSet dsAddChecklist = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            dsAddChecklist = ObjUpkeepCC_BL.ChecklistPoint_CRUD(ChecklistID, ChecklistPointID, strChecklistPointDesc, strChecklstAnstype, LoggedInUserID, Action, StrConn);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dsAddChecklist;
    }

    public DataSet ChecklistRequest(string ScheduleDate, int ZoneID, int LocationID, int SubLocationID, int DepartmentID, int ChecklistID, string StartTime, string TicketNumber, string LoggedInUserID, string strAction)
    {
        DataSet dsDept_Checklist = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            dsDept_Checklist = ObjUpkeepCC_BL.ChecklistRequest(ScheduleDate, ZoneID, LocationID, SubLocationID, DepartmentID, ChecklistID, StartTime, TicketNumber, LoggedInUserID, strAction, StrConn);
            return dsDept_Checklist;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //return ds;
    }


    public DataSet Update_ChecklistPoints(string TicketNumber, string strXmlChecklist, string list_Images, string LoggedInUserID)
    {
        DataSet dsChecklist = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            dsChecklist = ObjUpkeepCC_BL.Update_ChecklistPoints(TicketNumber, strXmlChecklist, list_Images, LoggedInUserID, StrConn);
            return dsChecklist;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //return ds;
    }


    public DataSet Close_Ticket_Details(string TicketID, string CloseTicketDesc, string LoggedInUserID, string list_Images, string strTicketAction, string CurrentLevel)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Close_Ticket_Details(TicketID, CloseTicketDesc, LoggedInUserID, list_Images, strTicketAction, CurrentLevel, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //return ds;
    }

    #region Location Tree View
    public DataSet Location_PopulateRootLevel(int CompanyID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Location_PopulateRootLevel(CompanyID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //return ds;
    }

    public DataSet Location_PopulateSubLevel(int ParentID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Location_PopulateSubLevel(ParentID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //return ds;
    }

    public DataSet Add_Update_Location_Node(int ParentID, string Location_Node, int CompanyID, string LoggedInUserID, string strAction)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Add_Update_Location_Node(ParentID, Location_Node, CompanyID, LoggedInUserID, strAction, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //return ds;
    }


    #endregion

    #region Role Management

    public DataSet FetchMenu(int parentMenuId, string LoggedInUserID, string ModuleIDs, int CompanyID)
    {
        DataSet dtMenu = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            dtMenu = ObjUpkeepCC_BL.FetchMenu(parentMenuId, LoggedInUserID, ModuleIDs, CompanyID, StrConn);
            return dtMenu;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //return ds;
    }

    public DataSet RoleMaster_CRUD(int RoleID, string Role, string LoggedInUserID, string strAction)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.RoleMaster_CRUD(RoleID, Role, LoggedInUserID, strAction, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_Assigned_Role(int RoleID)
    {
        DataSet dtMenu = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            dtMenu = ObjUpkeepCC_BL.Fetch_Assigned_Role(RoleID, StrConn);
            return dtMenu;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //return ds;
    }

    public DataSet Fetch_Role_Menu()
    {
        DataSet dsMenu = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            dsMenu = ObjUpkeepCC_BL.Fetch_Role_Menu(StrConn);
            return dsMenu;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet FETCH_Saved_Role_MENU_Rights(int RoleID, int ParentMenuId)
    {
        DataSet dsMenu = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            dsMenu = ObjUpkeepCC_BL.FETCH_Saved_Role_MENU_Rights(RoleID, ParentMenuId, StrConn);
            return dsMenu;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Insert_RoleMenuRights(int RoleId, int ParentMenuId, string LoggedInUserID, string strWpSectionHeaderData)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Insert_RoleMenuRights(RoleId, ParentMenuId, LoggedInUserID, strWpSectionHeaderData, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Insert_Assigned_Role(int RoleID, string SelectedEmployees, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Insert_Assigned_Role(RoleID, SelectedEmployees, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_RoleListing()
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_RoleListing(StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    #endregion

    #region GatePass
    public DataSet Insert_GatePassConfiguration(string strConfigTitle, int CompanyID, string strInitiator, bool LinkDepartment, string strTransactionPrefix, string strXmlGatepass_Header, string strXmlGatepass_Type, string strXmlGatepass_Doc, string strXmlGatepass_TermCondition, string strXmlApprovalMatrix, bool ShowApprovalMatrix, string strGPClosureBy, string GatepassDescription, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Insert_GatePassConfiguration(strConfigTitle, CompanyID, strInitiator, LinkDepartment, strTransactionPrefix, strXmlGatepass_Header, strXmlGatepass_Type, strXmlGatepass_Doc, strXmlGatepass_TermCondition, strXmlApprovalMatrix, ShowApprovalMatrix, strGPClosureBy, GatepassDescription, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_GatePassConfiguration(string Initiator)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_GatePassConfiguration(Initiator, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Bind_GatePassConfiguration(int GP_ConfigID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Bind_GatePassConfiguration(GP_ConfigID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GatePassHeader_CRUD(int GatePassHeaderID, string GatePassHeader, bool GPHeaderNumeric, int GPHeaderUnit, int GatePass_ConfigID, string LoggedInUserID, string strAction)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.GatePassHeader_CRUD(GatePassHeaderID, GatePassHeader, GPHeaderNumeric, GPHeaderUnit, GatePass_ConfigID, LoggedInUserID, strAction, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GatePassType_CRUD(int GP_TypeID, string GP_TypeDesc, int GatePass_ConfigID, string LoggedInUserID, string strAction)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.GatePassType_CRUD(GP_TypeID, GP_TypeDesc, GatePass_ConfigID, LoggedInUserID, strAction, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GatePassTerm_CRUD(int GP_TermID, string GP_TermDesc, int GatePass_ConfigID, string LoggedInUserID, string strAction)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.GatePassTerm_CRUD(GP_TermID, GP_TermDesc, GatePass_ConfigID, LoggedInUserID, strAction, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Update_GatePassConfiguration(int GP_Config_ID, string strConfigTitle, int CompanyID, string strInitiator, bool LinkDepartment, string strTransactionPrefix, string strXmlApprovalMatrix, bool ShowApprovalMatrix, string strGPClosureBy, string GatepassDescription, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Update_GatePassConfiguration(GP_Config_ID, strConfigTitle, CompanyID, strInitiator, LinkDepartment, strTransactionPrefix, strXmlApprovalMatrix, ShowApprovalMatrix, strGPClosureBy, GatepassDescription, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Bind_GatePassRequestDetails(int GP_ConfigID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Bind_GatePassRequestDetails(GP_ConfigID, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Insert_GatePassRequest(int GP_ConfigID, string strGatePassDate, int DeptID, int GPTypeID, string strGPHeader, string strGPHeaderData, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Insert_GatePassRequest(GP_ConfigID, strGatePassDate, DeptID, GPTypeID, strGPHeader, strGPHeaderData, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_MyRequestGatePass(string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_MyRequestGatePass(LoggedInUserID, From_Date, To_Date, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_MyActionableGatePass(string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_MyActionableGatePass(LoggedInUserID, From_Date, To_Date, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_GatePassRequest_Approval_Details(int TransactionID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_GatePassRequest_Approval_Details(TransactionID, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet UpdateAction_GatePassRequest(string TransactionID, string CurrentLevel, string ActionStatus, string strRemarks, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.UpdateAction_GatePassRequest(TransactionID, CurrentLevel, ActionStatus, strRemarks, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region Work_Permit


    //Added by RC WorkPermitConfiguration Save
    public DataSet Insert_WorkPermitConfiguration(string strConfigTitle, int CompanyID, string strInitiator, bool LinkDepartment, string strTransactionPrefix, string strXmlWorkPermit_Header, string strXmlWorkPermit_TermCondition, string strXmlApprovalMatrix, bool ShowApprovalMatrix, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Insert_WorkPermitConfiguration(strConfigTitle, CompanyID, strInitiator, LinkDepartment, strTransactionPrefix, strXmlWorkPermit_Header, strXmlWorkPermit_TermCondition, strXmlApprovalMatrix, ShowApprovalMatrix, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //Added by RC Fetch WP header Ansers
    public DataSet Fetch_Answer()
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_Answer(StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataSet Fetch_WorkPermitConfiguration(string Initiator)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_WorkPermitConfiguration(Initiator, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Bind_WorkPermitConfiguration(int WP_ConfigID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Bind_WorkPermitConfiguration(WP_ConfigID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataSet Bind_WorkPermitRequestDetails(int WP_ConfigID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Bind_WorkPermitRequestDetails(WP_ConfigID, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //public DataSet Insert_WorkPermitRequest(int WP_ConfigID, string LoggedInUserID, string strWpDate, string strWpSectionHeaderData)
    //{
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
    //        string strOutput = string.Empty;
    //        ds = ObjUpkeepCC_BL.Insert_WorkPermitRequest(WP_ConfigID, LoggedInUserID, strWpDate, strWpSectionHeaderData, StrConn);
    //        return ds;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    public DataSet Insert_WorkPermitRequest(int WP_ConfigID, string LoggedInUserID, string strWpDate, string strWpTpDate, string strWpSectionHeaderData)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Insert_WorkPermitRequest(WP_ConfigID, LoggedInUserID, strWpDate, strWpTpDate, strWpSectionHeaderData, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet Fetch_WorkPermitRequestSavedData(int WP_ConfigID, int Transaction_ID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_WorkPermitRequestSavedData(WP_ConfigID, Transaction_ID, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Update_WorkPermitRequest(int TransactionID, string LoggedInUserID, string ActionStatus, string Remarks)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Update_WorkPermitRequest(TransactionID, LoggedInUserID, ActionStatus, Remarks, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_MyRequestWorkPermit(string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_MyRequestWorkPermit(LoggedInUserID, From_Date, To_Date, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_MyActionableWorkPermit(string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_MyActionableWorkPermit(LoggedInUserID, From_Date, To_Date, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_DashboardCount(int CompanyID, string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_DashboardCount(CompanyID, LoggedInUserID, From_Date, To_Date, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Delete_GatePassConfiguration(int ConfigID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Delete_GatePassConfiguration(ConfigID, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    //Added by RC Update WP Config
    public DataSet Update_WorkPermitConfiguration(int WP_Config_ID, string strConfigTitle, int CompanyID, string strInitiator, bool LinkDepartment, string strTransactionPrefix, string strXmlWorkPermit_Header, string strXmlWorkPermit_TermCondition, string strXmlApprovalMatrix, bool ShowApprovalMatrix, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Update_WorkPermitConfiguration(WP_Config_ID, strConfigTitle, CompanyID, strInitiator, LinkDepartment, strTransactionPrefix, strXmlWorkPermit_Header, strXmlWorkPermit_TermCondition, strXmlApprovalMatrix, ShowApprovalMatrix, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Bind_WorkPermitSavedConfiguration(int WP_ConfigID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Bind_WorkPermitSavedConfiguration(WP_ConfigID, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    public DataSet Fetch_GatePass_MIS(string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_GatePass_MIS(LoggedInUserID, From_Date, To_Date, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    public DataSet Fetch_WorkPermit_MIS(string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_WorkPermit_MIS(LoggedInUserID, From_Date, To_Date, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //Added by sujata delete wp config
    public DataSet Delete_WPConfiguration(int ConfigID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Delete_WPConfiguration(ConfigID, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region Checklist
    public DataSet Fetch_Chk_Answer()
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_Chk_Answer(StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Update_ChecklistConfiguration(int Chk_Config_ID, string strConfigTitle, string strConfigTitleDesc, bool IsScoreEnable, int TotalScore, string strXmlChecklist, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Update_ChecklistConfiguration(Chk_Config_ID, strConfigTitle, strConfigTitleDesc, IsScoreEnable, TotalScore, strXmlChecklist, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet Insert_ChecklistConfiguration(string strConfigTitle, string strConfigTitleDesc, bool IsScoreEnable, int TotalScore, string strXmlChecklist, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Insert_ChecklistConfiguration(strConfigTitle, strConfigTitleDesc, IsScoreEnable, TotalScore, strXmlChecklist, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataSet Bind_ChecklistConfiguration(int CHK_ConfigID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Bind_ChecklistConfiguration(CHK_ConfigID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataSet Fetch_MyChecklist(string LoggedInUserID, string CompanyID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_MyChecklist(LoggedInUserID, CompanyID, From_Date, To_Date, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Added by sujata delete CHK config
    public DataSet Delete_CHKConfiguration(int ConfigID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Delete_CHKConfiguration(ConfigID, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    public DataSet Fetch_MyChecklistReportList(string LoggedInUserID, string CompanyID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_MyChecklistReportList(LoggedInUserID, CompanyID, From_Date, To_Date, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_Checklist_Report(string Response_ID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_Checklist_Report(Response_ID, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    #endregion

    #region VMS

    //Added by RC This function is used to save VMS Configuration 
    public DataSet Insert_Update_VMSConfiguration(int ConfigID, string strConfigTitle, string strConfigDesc, int CompanyID, string strInitiator, string strXmlVMS_Question, bool blFeedbackCompulsary, int FeedbackTitle, bool blEnableCovid, int EntryCount, string LoggedInUserID)
    {

        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Insert_Update_VMSConfiguration(ConfigID, strConfigTitle, strConfigDesc, CompanyID, strInitiator, strXmlVMS_Question, blFeedbackCompulsary, FeedbackTitle, blEnableCovid, EntryCount, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Added by RC This function is used to Fetch VMS Configuration 
    public DataSet Fetch_VMSConfiguration(string Initiator)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_VMSConfiguration(Initiator, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Added by RC This function is used to bind VMS Configuration 
    public DataSet Bind_VMSConfiguration(int VMS_ConfigID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Bind_VMSConfiguration(VMS_ConfigID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Added by RC This function is used to fetch VMS requests 
    public DataSet Fetch_VMSRequestList(string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try

        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_VMSRequestList(LoggedInUserID, From_Date, To_Date, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Added by RC This function is used to bind VMS request details
    public DataSet Bind_VMSRequestDetails(int RequestID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Bind_VMSRequestDetails(RequestID, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Added by RC This function is used to save VMS request 
    public DataSet Insert_VMSRequest(int CompanyID, char Action, int RequestID, int VMS_ConfigID, string Name, string Email, string Phone, string strVMSDate, string strMeetUsrs, string strVMSData, string strVMSCovidColorCode, string strVMSCovidTestDate, string strTemperature, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Insert_VMSRequest(CompanyID, Action, RequestID, VMS_ConfigID, Name, Email, Phone, strVMSDate, strMeetUsrs, strVMSData, strVMSCovidColorCode, strVMSCovidTestDate, strTemperature, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Added by RC This function is used to Fetch Visit Form Url for Session less User 
    public DataSet Fetch_VMSFormURL(string ShortUrl)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_VMSFormURL(ShortUrl, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //Added by sujata delete VMS config
    public DataSet Delete_VMSConfiguration(int ConfigID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Delete_VMSConfiguration(ConfigID, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region General Functions

    //Added by RC This function is used to Fetch Answer type master

    public DataSet Fetch_AnswerForAll(char Key)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_AnswerForAll(Key, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_User_UserGroupListGPWP(string Initiator)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_User_UserGroupListGPWP(Initiator, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_Company()
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_Company(StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Added by RC This function is used to Log error

    public DataSet Error_Log(string Extype, string Page, string Errormsg, string StackTrace, string CompanyID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Error_Log(Extype, Page, Errormsg, StackTrace, CompanyID, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion


    #region Asset Management 
    public DataSet Fetch_Asset_DropDown(int UserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            ds = ObjUpkeepCC_BL.Fetch_Asset_DropDown(UserID, StrConn);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    public DataSet Fetch_Asset_Vendor_DropDown(string VendorPrefix, int UserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            ds = ObjUpkeepCC_BL.Fetch_Asset_Vendor_DropDown(VendorPrefix, UserID, StrConn);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    public DataSet ASSET_Insert_AssetType(string LoggedInUserID, int companyID, string AssetType)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            ds = ObjUpkeepCC_BL.ASSET_Insert_AssetType(LoggedInUserID, companyID, AssetType, StrConn);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    public DataSet ASSET_Insert_AssetCategory(string LoggedInUserID, int companyID, int AssetTypeID, string AssetCategory)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            ds = ObjUpkeepCC_BL.ASSET_Insert_AssetCategory(LoggedInUserID, companyID, AssetTypeID, AssetCategory, StrConn);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    public DataSet ASSET_INSERT_GRNL_MASTER(string LoggedInUserID, string MasterType, string Dept_Value, string LocationXmlValue, string VendorXmlValue)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            ds = ObjUpkeepCC_BL.ASSET_INSERT_GRNL_MASTER(LoggedInUserID, MasterType, Dept_Value, LocationXmlValue, VendorXmlValue, StrConn);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }


    public DataSet Fetch_MyAsset(string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_MyAsset(LoggedInUserID, From_Date, To_Date, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet Fetch_ASSET_REQUEST_Details(string LoggedInUserID, int TransactionID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_ASSET_REQUEST_Details(LoggedInUserID, TransactionID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet INSERT_ASSET_REQUEST_Details(string LoggedInUserID, string AssetXml, string AssetAmcXml, string AssetServiceXml)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.INSERT_ASSET_REQUEST_Details(LoggedInUserID, AssetXml, AssetAmcXml, AssetServiceXml, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet UPDATE_ASSET_REQUEST_Details(string LoggedInUserID, string TransactionID, string AssetXml, string AssetAmcXml, string AssetServiceXml)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.UPDATE_ASSET_REQUEST_Details(LoggedInUserID, TransactionID, AssetXml, AssetAmcXml, AssetServiceXml, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataSet INSERT_UPDATE_ASSET_AMC_REQUEST_Details(string LoggedInUserID, string TransactionID, string AssetAmcXml, string Flag)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.INSERT_UPDATE_ASSET_AMC_REQUEST_Details(LoggedInUserID, TransactionID, AssetAmcXml, Flag, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_MyAsset_Service(string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_MyAsset_Service(LoggedInUserID, From_Date, To_Date, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet CRUD_ASSET_SERVICE_REQUEST_DATA(string LoggedInUserID, string AssetID, string ServiceScheduleID, string AssetServiceXml, string Flag)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.CRUD_ASSET_SERVICE_REQUEST_DATA(LoggedInUserID, AssetID, ServiceScheduleID, AssetServiceXml, Flag, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    #endregion


    #region Inventory


    public DataSet Fetch_Transaction_List(string LoggedInUserID, string CompanyID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_Transaction_List(LoggedInUserID, CompanyID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Delete_Inv_Transaction(int TransactionID, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Delete_Inv_Transaction(TransactionID, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    public DataSet Fetch_Stock_List(string LoggedInUserID, string CompanyID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_Stock_List(LoggedInUserID, CompanyID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Delete_Inv_Stock(int ItemId, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Delete_Inv_Stock(ItemId, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet Delete_Inv_Item(int ItemId, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Delete_Inv_Item(ItemId, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_Stock_Detail(string LoggedInUserID, string CompanyID, int StockId)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_Stock_Detail(LoggedInUserID, CompanyID, StockId, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_Inv_Items_List(string LoggedInUserID, string CompanyID, string XmlItem)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_Inv_Items_List(LoggedInUserID, CompanyID, XmlItem, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet Fetch_Inv_Item_Stock_Ddl(string LoggedInUserID, string CompanyID, string StockID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_Inv_Item_Stock_Ddl(LoggedInUserID, CompanyID, StockID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet Fetch_Inv_Crud_Item_Stock(string LoggedInUserID, string CompanyID, string StockID, string XmlItem) 
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_Inv_Crud_Item_Stock(LoggedInUserID, CompanyID, StockID, XmlItem ,StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_Inv_Item_Stock_Data(string LoggedInUserID, string CompanyID, string StockID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_Inv_Item_Stock_Data(LoggedInUserID, CompanyID, StockID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_Inv_Item_Purchase_List(string LoggedInUserID, string CompanyID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_Inv_Item_Purchase_List(LoggedInUserID, CompanyID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataSet Delete_Inv_Purchase(int ItemId, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Delete_Inv_Purchase(ItemId, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    #endregion

}