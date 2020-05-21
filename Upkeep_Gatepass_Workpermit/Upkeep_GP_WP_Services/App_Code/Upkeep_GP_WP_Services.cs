using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for Upkeep_GP_WP_Services
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Upkeep_GP_WP_Services : System.Web.Services.WebService
{
    My_Upkeep_GP_WP ObjUpkeep = new My_Upkeep_GP_WP();
    public Upkeep_GP_WP_Services()
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
    public DataSet Fetch_User_UserGroupList(string Initiator)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_User_UserGroupList(Initiator);
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

    [WebMethod]
    public DataSet Insert_GatePassConfiguration(string strConfigTitle, int CompanyID, string strInitiator, bool LinkDepartment, string strTransactionPrefix, string strXmlGatepass_Header, string strXmlGatepass_Type, string strXmlGatepass_TermCondition, string strXmlApprovalMatrix, bool ShowApprovalMatrix, string strGPClosureBy,string GatepassDescription, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Insert_GatePassConfiguration(strConfigTitle, CompanyID, strInitiator, LinkDepartment, strTransactionPrefix, strXmlGatepass_Header, strXmlGatepass_Type, strXmlGatepass_TermCondition, strXmlApprovalMatrix, ShowApprovalMatrix, strGPClosureBy, GatepassDescription, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_GatePassConfiguration(string Initiator)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_GatePassConfiguration(Initiator);
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
    public DataSet Update_GatePassConfiguration(int GP_Config_ID, string strConfigTitle, int CompanyID, string strInitiator, bool LinkDepartment, string strTransactionPrefix, string strXmlApprovalMatrix, bool ShowApprovalMatrix, string strGPClosureBy,string GatepassDescription, string LoggedInUserID)
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
    public DataSet Insert_GatePassRequest(int GP_ConfigID, string strGatePassDate, int DeptID, int GPTypeID, string strGPHeader, string strGPHeaderData, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Insert_GatePassRequest(GP_ConfigID, strGatePassDate, DeptID, GPTypeID, strGPHeader, strGPHeaderData, LoggedInUserID);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_MyRequestGatePass(string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_MyRequestGatePass(LoggedInUserID, From_Date, To_Date);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    [WebMethod]
    public DataSet Fetch_MyActionableGatePass(string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_MyActionableGatePass(LoggedInUserID, From_Date, To_Date);
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
    public DataSet User_Login(string UserId, string strPassword, string UserType)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.User_Login(UserId, strPassword, UserType);
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
    public DataSet Retailer_CRUD(string storeName, string firstName, string lastName, string email, Int64 phone, int RetailerID, string Username, string Password, string LoggedInUserID, string actionType)
    {
        DataSet ds = new DataSet();

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();

            ds = obj.Retailer_CRUD(storeName, firstName, lastName, email, phone, RetailerID, Username, Password, LoggedInUserID, actionType);

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
    public DataSet ImportRetailer()
    {
        DataSet ds = new DataSet();

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();

            ds = obj.ImportRetailer();

        }
        catch (Exception ex)
        {
            throw ex;


        }

        return ds;
    }

    #endregion
    //[-][Feedback System Methods]


    //[+][WOW Center Report]
    [WebMethod]
    public DataSet FetchBaggageReport(string From_Date, string To_Date)
    {
        DataSet dsBaggage = new DataSet();

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();
            dsBaggage = obj.FetchBaggageReport(From_Date, To_Date);
        }
        catch (Exception ex)
        {
            throw ex;

        }

        return dsBaggage;
    }

    [WebMethod]
    public DataSet FetchPowerBankReport(string From_Date, string To_Date)
    {
        DataSet dsPowerBank = new DataSet();

        try
        {
            My_FeedbackSystem obj = new My_FeedbackSystem();
            dsPowerBank = obj.FetchPowerBankReport(From_Date, To_Date);
        }
        catch (Exception ex)
        {
            throw ex;

        }

        return dsPowerBank;
    }

    //[-][WOW Center Report]

    #region Work_Permit

    //Added by RC WorkPermitConfiguration Save
    [WebMethod]
    public DataSet Insert_WorkPermitConfiguration(string strConfigTitle, int CompanyID, string strInitiator, bool LinkDepartment, string strTransactionPrefix, string strXmlWorkPermit_Header, string strXmlWorkPermit_TermCondition, string strXmlApprovalMatrix, bool ShowApprovalMatrix, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Insert_WorkPermitConfiguration(strConfigTitle, CompanyID, strInitiator, LinkDepartment, strTransactionPrefix, strXmlWorkPermit_Header, strXmlWorkPermit_TermCondition, strXmlApprovalMatrix, ShowApprovalMatrix, LoggedInUserID);
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
    public DataSet Fetch_WorkPermitConfiguration(string Initiator)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_WorkPermitConfiguration(Initiator);
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
    public DataSet Fetch_WorkPermitRequestSavedData(int WP_ConfigID, int Transaction_ID, string LoggedInUserID)
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
    public DataSet Fetch_MyRequestWorkPermit(string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_MyRequestWorkPermit(LoggedInUserID, From_Date, To_Date);
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
    public DataSet Update_WorkPermitConfiguration(int WP_Config_ID, string strConfigTitle, int CompanyID, string strInitiator, bool LinkDepartment, string strTransactionPrefix, string strXmlWorkPermit_Header, string strXmlWorkPermit_TermCondition, string strXmlApprovalMatrix, bool ShowApprovalMatrix, string LoggedInUserID)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Update_WorkPermitConfiguration(WP_Config_ID, strConfigTitle, CompanyID, strInitiator, LinkDepartment, strTransactionPrefix, strXmlWorkPermit_Header, strXmlWorkPermit_TermCondition, strXmlApprovalMatrix, ShowApprovalMatrix, LoggedInUserID);
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
    public DataSet Fetch_GatePass_MIS(string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_GatePass_MIS(LoggedInUserID, From_Date, To_Date);
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

    //[WebMethod]
    //public static List<object> GetFeedback_ChartData(string From_Date, string To_Date)
    //{
    //    List<object> chartData = new List<object>();
    //    string StrConn = string.Empty;
    //    try
    //    {
    //        chartData.Add(new object[]
    //         {
    //                "Event_Name", "TotalPositve" ,"TotalNeutral", "TotalNegative"
    //         });

    //        StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();

    //        using (SqlConnection con = new SqlConnection(StrConn))
    //        {
    //            using (SqlCommand cmd = new SqlCommand("Feedback_Proc_GetChartData"))
    //            {
    //                cmd.CommandType = CommandType.StoredProcedure;
    //                cmd.Connection = con;
    //                con.Open();
    //                using (SqlDataReader sdr = cmd.ExecuteReader())
    //                {
    //                    while (sdr.Read())
    //                    {
    //                        chartData.Add(new object[]
    //                    {
    //                    sdr["Event_Name"], sdr["TotalPositve"] , sdr["TotalNeutral"], sdr["TotalNegative"]
    //                    });
    //                    }
    //                }
    //                con.Close();
    //                return chartData;
    //            }
    //        }

    //        //return chartData;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }

    //}





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
    public DataSet Fetch_MyChecklist(string LoggedInUserID, string From_Date, string To_Date)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = ObjUpkeep.Fetch_MyChecklist(LoggedInUserID, From_Date, To_Date);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return ds;
    }

    #endregion




}
