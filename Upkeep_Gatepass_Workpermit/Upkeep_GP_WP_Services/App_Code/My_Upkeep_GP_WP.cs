using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Upkeep_GP_WP_BL;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for My_Upkeep_GP_WP
/// </summary>
public class My_Upkeep_GP_WP
{
    Upkeep_GP_WP_BL.My_Upkeep_GP_WP_BL ObjMy_Upkeep_GP_WP_BL = new Upkeep_GP_WP_BL.My_Upkeep_GP_WP_BL();
    string StrConn;
    public My_Upkeep_GP_WP()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataSet Fetch_User_UserGroupList(string Initiator)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Fetch_User_UserGroupList(Initiator,StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Fetch_Company(StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Insert_GatePassConfiguration(string strConfigTitle, int CompanyID, string strInitiator, bool LinkDepartment,string strTransactionPrefix, string strXmlGatepass_Header, string strXmlGatepass_Type, string strXmlGatepass_TermCondition, string strXmlApprovalMatrix,bool ShowApprovalMatrix, string strGPClosureBy,string GatepassDescription, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Insert_GatePassConfiguration(strConfigTitle, CompanyID, strInitiator, LinkDepartment, strTransactionPrefix, strXmlGatepass_Header, strXmlGatepass_Type, strXmlGatepass_TermCondition, strXmlApprovalMatrix, ShowApprovalMatrix, strGPClosureBy, GatepassDescription, LoggedInUserID,StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Fetch_GatePassConfiguration(Initiator,StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Bind_GatePassConfiguration(GP_ConfigID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet GatePassHeader_CRUD(int GatePassHeaderID, string GatePassHeader, bool GPHeaderNumeric, int GPHeaderUnit,int GatePass_ConfigID, string LoggedInUserID, string strAction)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.GatePassHeader_CRUD(GatePassHeaderID, GatePassHeader, GPHeaderNumeric, GPHeaderUnit, GatePass_ConfigID, LoggedInUserID, strAction,StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.GatePassType_CRUD(GP_TypeID, GP_TypeDesc, GatePass_ConfigID, LoggedInUserID, strAction, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.GatePassTerm_CRUD(GP_TermID, GP_TermDesc, GatePass_ConfigID, LoggedInUserID, strAction, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Update_GatePassConfiguration(int GP_Config_ID, string strConfigTitle, int CompanyID, string strInitiator, bool LinkDepartment,string strTransactionPrefix, string strXmlApprovalMatrix,bool ShowApprovalMatrix, string strGPClosureBy,string GatepassDescription, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Update_GatePassConfiguration(GP_Config_ID,strConfigTitle, CompanyID, strInitiator, LinkDepartment, strTransactionPrefix, strXmlApprovalMatrix, ShowApprovalMatrix, strGPClosureBy, GatepassDescription, LoggedInUserID, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Bind_GatePassRequestDetails(GP_ConfigID, LoggedInUserID, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Insert_GatePassRequest(GP_ConfigID, strGatePassDate, DeptID, GPTypeID, strGPHeader, strGPHeaderData, LoggedInUserID, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Fetch_MyRequestGatePass(LoggedInUserID, From_Date, To_Date, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Fetch_MyActionableGatePass(LoggedInUserID, From_Date, To_Date, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Fetch_GatePassRequest_Approval_Details(TransactionID,LoggedInUserID, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.UpdateAction_GatePassRequest(TransactionID, CurrentLevel, ActionStatus, strRemarks, LoggedInUserID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet User_Login(string UserName, string strPassword, string UserType)
    {
        try
        {
            StrConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            ds = ObjMy_Upkeep_GP_WP_BL.User_Login(UserName, strPassword, UserType, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region Work_Permit


    //Added by RC WorkPermitConfiguration Save
    public DataSet Insert_WorkPermitConfiguration(string strConfigTitle, int CompanyID, string strInitiator, bool LinkDepartment, string strTransactionPrefix, string strXmlWorkPermit_Header, string strXmlWorkPermit_TermCondition, string strXmlApprovalMatrix, bool ShowApprovalMatrix, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Insert_WorkPermitConfiguration(strConfigTitle, CompanyID, strInitiator, LinkDepartment, strTransactionPrefix, strXmlWorkPermit_Header, strXmlWorkPermit_TermCondition, strXmlApprovalMatrix, ShowApprovalMatrix, LoggedInUserID, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Fetch_Answer(StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Fetch_WorkPermitConfiguration(Initiator, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Bind_WorkPermitConfiguration(WP_ConfigID, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Bind_WorkPermitRequestDetails(WP_ConfigID, LoggedInUserID, StrConn);
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
    //        StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
    //        string strOutput = string.Empty;
    //        ds = ObjMy_Upkeep_GP_WP_BL.Insert_WorkPermitRequest(WP_ConfigID, LoggedInUserID, strWpDate, strWpSectionHeaderData, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Insert_WorkPermitRequest(WP_ConfigID, LoggedInUserID, strWpDate, strWpTpDate, strWpSectionHeaderData, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Fetch_WorkPermitRequestSavedData(WP_ConfigID, Transaction_ID, LoggedInUserID, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Update_WorkPermitRequest(TransactionID, LoggedInUserID, ActionStatus, Remarks, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Fetch_MyRequestWorkPermit(LoggedInUserID, From_Date, To_Date, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Fetch_MyActionableWorkPermit(LoggedInUserID, From_Date, To_Date, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_DashboardCount(int CompanyID,string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Fetch_DashboardCount(CompanyID,LoggedInUserID, From_Date, To_Date, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Delete_GatePassConfiguration(ConfigID, LoggedInUserID, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Update_WorkPermitConfiguration(WP_Config_ID, strConfigTitle, CompanyID, strInitiator, LinkDepartment, strTransactionPrefix, strXmlWorkPermit_Header, strXmlWorkPermit_TermCondition, strXmlApprovalMatrix, ShowApprovalMatrix, LoggedInUserID, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Bind_WorkPermitSavedConfiguration(WP_ConfigID, LoggedInUserID, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Fetch_GatePass_MIS(LoggedInUserID, From_Date, To_Date, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Fetch_WorkPermit_MIS(LoggedInUserID, From_Date, To_Date, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region Role Management

    public DataSet FetchMenu(int parentMenuId, string LoggedInUserID)
    {
        DataSet dtMenu = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            dtMenu = ObjMy_Upkeep_GP_WP_BL.FetchMenu(parentMenuId, LoggedInUserID, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.RoleMaster_CRUD(RoleID, Role, LoggedInUserID, strAction, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            dtMenu = ObjMy_Upkeep_GP_WP_BL.Fetch_Assigned_Role(RoleID, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            dsMenu = ObjMy_Upkeep_GP_WP_BL.Fetch_Role_Menu(StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            dsMenu = ObjMy_Upkeep_GP_WP_BL.FETCH_Saved_Role_MENU_Rights(RoleID, ParentMenuId, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Insert_RoleMenuRights(RoleId, ParentMenuId, LoggedInUserID, strWpSectionHeaderData, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Insert_Assigned_Role(RoleID, SelectedEmployees, LoggedInUserID, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Fetch_RoleListing(StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Fetch_Chk_Answer(StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Update_ChecklistConfiguration(Chk_Config_ID, strConfigTitle, strConfigTitleDesc, IsScoreEnable, TotalScore, strXmlChecklist, LoggedInUserID, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Insert_ChecklistConfiguration(strConfigTitle, strConfigTitleDesc, IsScoreEnable, TotalScore, strXmlChecklist, LoggedInUserID, StrConn);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Bind_ChecklistConfiguration(CHK_ConfigID, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataSet Fetch_MyChecklist(string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            ds = ObjMy_Upkeep_GP_WP_BL.Fetch_MyChecklist(LoggedInUserID, From_Date, To_Date, StrConn);
            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    #endregion


}