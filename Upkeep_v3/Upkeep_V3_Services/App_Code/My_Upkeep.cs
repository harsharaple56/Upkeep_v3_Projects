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

    public DataSet UserTypeMaster_CRUD(int User_Type_ID, string User_Type_Desc,int CompanyID, string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.UserTypeMaster_CRUD(User_Type_ID,User_Type_Desc, CompanyID, LoggedInUserID, Action,StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet DepartmentMaster_CRUD(int Department_ID, string Dept_Desc,int CompanyID, string LoggedInUserID, string Is_Deleted, string Action)
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

    public DataSet PriorityMaster_CRUD(int Priority_ID, string Priority_Desc,int CompanyID, string LoggedInUserID, string Action)
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

    public DataSet FrequencyMaster_CRUD(int Frquency_Id, string Frquency_Desc,int CompanyID, string LoggedInUserID, string Action)
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

            ds = ObjUpkeepCC_BL.FetchLocation(Zone_ID,StrConn);

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

    public DataSet FetchDepartment(int CompanyID)
    {
        try
        {
            StrConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();

            ds = ObjUpkeepCC_BL.FetchDepartment(CompanyID,StrConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }

    public DataSet FetchUserType()
    {
        try
        {
            StrConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();

            ds = ObjUpkeepCC_BL.FetchUserType(StrConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }

    public DataSet UserMaster_CRUD(int User_ID, string User_Code, string F_name, string L_Name, string User_Mobile, string User_Email, string User_MobileAlter, string User_Landline, string User_Designation, int User_Type_ID, int Zone_ID, int Loc_ID, int SubLoc_Id, int Department_Id, string Login_Id, string Password, int Is_Approver, int Is_GobalApprover,string Approver_ID, string Profilephoto,int CompanyID, string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.UserMaster_CRUD(User_ID, User_Code, F_name, L_Name, User_Mobile, User_Email, User_MobileAlter, User_Landline, User_Designation, User_Type_ID, Zone_ID, Loc_ID, SubLoc_Id, Department_Id, Login_Id, Password, Is_Approver, Is_GobalApprover, Approver_ID, Profilephoto, CompanyID, LoggedInUserID, Action, StrConn);
     
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
            StrConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            ds = ObjUpkeepCC_BL.LoginUser(UserName, strPassword, StrConn);
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

    public DataSet UserGroupMaster_CRUD(int Grp_Id, string Grp_Desc, string User_ID,int CompanyID, string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.UserGroupMaster_CRUD(Grp_Id, Grp_Desc, User_ID, CompanyID, LoggedInUserID, Action,StrConn);
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

    public DataSet FetchUserGrp(int GroupID,int CompanyID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.FetchUserGrp(GroupID,CompanyID, StrConn);
            return ds;
        }
        catch(Exception ex)
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
            ds = ObjUpkeepCC_BL.Fetch_CategorySubCategory(CategoryID,StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet WorkflowMaster_CRUD(int WorkflowID, string WorkflowDesc, int ZoneID, int CategoryID, int SubCategoryID, string xmlWorkflow,int CompanyID, string LoggedInUserID, string Action)
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

    public DataSet Fetch_User_UserGroupList()
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_User_UserGroupList(StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet CategoryMaster_CRUD(int Category_ID, string Category_Desc,int DepartmentID,string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty; 
            ds = ObjUpkeepCC_BL.CategoryMaster_CRUD(Category_ID, Category_Desc, DepartmentID, LoggedInUserID, Action, StrConn);
            //return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    public DataSet SubCategoryMaster_CRUD(int SubcategoryID, string SubCategoryDesc, int CategoryID, int Approval_Required, string LoggedInUserID, string Action)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.SubCategoryMaster_CRUD(SubcategoryID, SubCategoryDesc, CategoryID, Approval_Required, LoggedInUserID, Action, StrConn);

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
            ds = ObjUpkeepCC_BL.Fetch_LocationTree(CompanyID,StrConn);
            //return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    public DataSet Fetch_Ticket_Workflow(int ZoneID, int CategoryID, int SubCategoryID, string TicketPrefix, string LoggedInUserID)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_Ticket_Workflow(ZoneID, CategoryID, SubCategoryID,TicketPrefix, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //return ds;
    }

    public DataSet Insert_Ticket_Details(string TicketCode, int ZoneID, int LocationID, int SubLocationID, int CategoryID, int SubCategoryID, string TicketMessage, string list_Images, string LoggedInUserID, string strAction)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Insert_Ticket_Details(TicketCode, ZoneID, LocationID, SubLocationID, CategoryID, SubCategoryID, TicketMessage, list_Images, LoggedInUserID, strAction, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //return ds;
    }

    public DataSet AddChecklistMaster_CRUD(int ChecklistID, string ChecklistName, int DeptID, Boolean Chkapproval, Boolean ChkExpry, Boolean ChkSchedule, int ExpirytimeID, DateTime dtSchedule_Date, string StartTime, string EndTime, int CustFrequency, int Frquency_Id, int ZoneID, int LocationID, int SubLocationID,string strXmlChecklistPoint, string LoggedInUserID, string Action)
    {
        DataSet dsAddChecklist = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            dsAddChecklist= ObjUpkeepCC_BL.AddChecklistMaster_CRUD(ChecklistID, ChecklistName, DeptID, Chkapproval, ChkExpry, ChkSchedule, ExpirytimeID, dtSchedule_Date, StartTime, EndTime, CustFrequency, Frquency_Id, ZoneID, LocationID, SubLocationID, strXmlChecklistPoint, LoggedInUserID, Action, StrConn);

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

    public DataSet ChecklistRequest(string ScheduleDate, int ZoneID, int LocationID, int SubLocationID, int DepartmentID, int ChecklistID, string StartTime,string TicketNumber, string LoggedInUserID, string strAction)
    {
        DataSet dsDept_Checklist = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            dsDept_Checklist = ObjUpkeepCC_BL.ChecklistRequest(ScheduleDate, ZoneID, LocationID, SubLocationID, DepartmentID, ChecklistID, StartTime, TicketNumber,LoggedInUserID, strAction, StrConn);
            return dsDept_Checklist;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //return ds;
    }


    public DataSet Update_ChecklistPoints(string TicketNumber, string strXmlChecklist,string list_Images, string LoggedInUserID)
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


    public DataSet Close_Ticket_Details(string TicketID, string CloseTicketDesc, string LoggedInUserID, string list_Images)
    {
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Close_Ticket_Details(TicketID, CloseTicketDesc, LoggedInUserID, list_Images, StrConn);
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
            ds = ObjUpkeepCC_BL.Location_PopulateRootLevel(CompanyID,StrConn);
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
            ds = ObjUpkeepCC_BL.Location_PopulateSubLevel(ParentID,StrConn);
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

    public DataSet FetchMenu(int parentMenuId, string LoggedInUserID)
    {
        DataSet dtMenu = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            dtMenu = ObjUpkeepCC_BL.FetchMenu(parentMenuId, LoggedInUserID, StrConn);
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


    #region VMS

    //Added by RC This function is used to save VMS Configuration 

    public DataSet Insert_VMSConfiguration(string strConfigTitle, string strConfigDesc, int CompanyID, string strXmlVMS_Question, string strXmlVMS_Feedback, bool blFeedbackCompulsary, string LoggedInUserID)
    {

        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Insert_VMSConfiguration(strConfigTitle, strConfigDesc, CompanyID, strXmlVMS_Question, strXmlVMS_Feedback, blFeedbackCompulsary, LoggedInUserID, StrConn);
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

    public DataSet Fetch_Answer(char Key)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjUpkeepCC_BL.Fetch_Answer(Key,StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

}