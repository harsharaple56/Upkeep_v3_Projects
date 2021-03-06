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
/// Summary description for My_FeedbackSystem
/// </summary>
public class My_FeedbackSystem
{
    Upkeep_GP_WP_BL.My_Feedback_BL ObjFeedback_BL = new Upkeep_GP_WP_BL.My_Feedback_BL();
    string strConn;
    public My_FeedbackSystem()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    //public DataSet LoginUser(string UserName, string strPassword)
    //{
    //    try
    //    {
    //        strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
    //        string strOutput = string.Empty;
    //        DataSet ds = new DataSet();
    //        //FeedbackSystemBusiness.Class1  objLogin = new //FeedbackSystemBusiness.Class1 ();
    //       ds= objLogin.LoginUser( UserName, strPassword,strConn);

    //        return ds;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    public DataSet Employee_CRUD(string firstName, string lastName, string email, Int64 phone, string EmpID, string LoggedInUserID, string role, string Username, string Password, string actionType)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            ds = ObjFeedback_BL.Employee_CRUD(firstName, lastName, email, phone, EmpID, LoggedInUserID, role, Username, Password, actionType, strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet ChangePassword(string UserName, string strPassword)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            ////FeedbackSystemBusiness.Class1   objLogin = new //FeedbackSystemBusiness.Class1 ();
            ds = ObjFeedback_BL.ChangePassword(UserName, strPassword, strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet fetchStore()
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            //FeedbackSystemBusiness.Class1  objLogin = new //FeedbackSystemBusiness.Class1 ();
            ds = ObjFeedback_BL.fetchStore(strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Retailer_CRUD(string storeName, string firstName, string lastName, string email, Int64 phone, int RetailerID, string Username, string Password, string LoggedInUserID, string actionType)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            ds = ObjFeedback_BL.Retailer_CRUD(storeName, firstName, lastName, email, phone, RetailerID, Username, Password, LoggedInUserID, actionType, strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataSet Event_Insert(string eventName, string locationName, string startDateTime, string endDateTime, string CustomerQuestion, string CustQuesType, string QuesFor, int EventID, string EventMode, string LoggedInUserID, string option1, string option2, string option3, string option4)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            //ds = objEmp.Event_Insert(eventName, locationName, startDateTime, endDateTime, CustomerQuestion, CustQuesType, RetailerQuestion, RetQuesType,EventID, strConn);
            ds = ObjFeedback_BL.Event_Insert(eventName, locationName, startDateTime, endDateTime, CustomerQuestion, CustQuesType, QuesFor, EventID, EventMode, LoggedInUserID, option1, option2, option3, option4, strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataSet EventDetails_CRUD(int EventID, string actionType)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            ds = ObjFeedback_BL.EventDetails_CRUD(EventID, actionType, strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable Feedback_Insert(int UserID, int LoggedInUserID, int EventID, int QuestionID, string Answer)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataTable dt = new DataTable();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            dt = ObjFeedback_BL.Feedback_Insert(UserID, LoggedInUserID, EventID, QuestionID, Answer, strConn);
            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable Get_RetailerDetails(string storeName)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataTable dt = new DataTable();
            //FeedbackSystemBusiness.Class1  obj = new //FeedbackSystemBusiness.Class1 ();
            dt = ObjFeedback_BL.Get_RetailerDetails(storeName, strConn);

            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetEventList(string eventType)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataTable dt = new DataTable();
            //FeedbackSystemBusiness.Class1  obj= new //FeedbackSystemBusiness.Class1 ();
            dt = ObjFeedback_BL.GetEventList(eventType, strConn);

            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable Insert_CustomerDetails(string firstName, string lastName, string phoneNo, string emailID, string gender, string imagePath, string LoggedInUserID)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataTable dt = new DataTable();
            //FeedbackSystemBusiness.Class1  obj = new //FeedbackSystemBusiness.Class1 ();
            dt = ObjFeedback_BL.Insert_CustomerDetails(firstName, lastName, phoneNo, emailID, gender, imagePath, LoggedInUserID, strConn);

            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable Get_FeedbackQuestions(string EventID)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataTable dt = new DataTable();
            //FeedbackSystemBusiness.Class1  obj = new //FeedbackSystemBusiness.Class1 ();
            dt = ObjFeedback_BL.Get_FeedbackQuestions(EventID, strConn);

            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet bindEventDetails(int EventID)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            ds = ObjFeedback_BL.bindEventDetails(EventID, strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable Update_CustomerImage(string filePath, int UserID)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataTable dt = new DataTable();
            //FeedbackSystemBusiness.Class1  obj = new //FeedbackSystemBusiness.Class1 ();
            dt = ObjFeedback_BL.Update_CustomerImage(filePath, UserID, strConn);

            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Get_CustomerDetails()
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            ds = ObjFeedback_BL.Get_CustomerDetails(strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Get_EventQuestions(int EventID)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            ds = ObjFeedback_BL.Get_EventQuestions(EventID, strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Event_QuestionIU(int EventID, string CustomerQuestion, string AnswerType, string opt1, string opt2, string opt3, string opt4, string LoggedInUserID, int QuestionID, string ActionType)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            //ds = objEmp.Event_Insert(eventName, locationName, startDateTime, endDateTime, CustomerQuestion, CustQuesType, RetailerQuestion, RetQuesType,EventID, strConn);
            ds = ObjFeedback_BL.Event_QuestionIU(EventID, CustomerQuestion, AnswerType, opt1, opt2, opt3, opt4, LoggedInUserID, QuestionID, ActionType, strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_MIS_Report(string EventID, string From_Date, string To_Date)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            ds = ObjFeedback_BL.Fetch_MIS_Report(EventID, From_Date, To_Date, strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable Get_ChartData(string EventID, string fromDate, string toDate)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataTable dt = new DataTable();
            //FeedbackSystemBusiness.Class1  obj = new //FeedbackSystemBusiness.Class1 ();
            dt = ObjFeedback_BL.Get_ChartData(EventID, fromDate, toDate, strConn);

            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Event_Update(int EventID, string Location, string QuesFor, string EventMode, string startDate, string endDate, string LoggedInUserID, string ActionType)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            //ds = objEmp.Event_Insert(eventName, locationName, startDateTime, endDateTime, CustomerQuestion, CustQuesType, RetailerQuestion, RetQuesType,EventID, strConn);
            ds = ObjFeedback_BL.Event_Update(EventID, Location, QuesFor, EventMode, startDate, endDate, LoggedInUserID, ActionType, strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataSet GetEventList()
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            //FeedbackSystemBusiness.Class1  obj = new //FeedbackSystemBusiness.Class1 ();
            ds = ObjFeedback_BL.GetEventList(strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable Get_UpcomingEvent()
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataTable dt = new DataTable();
            //FeedbackSystemBusiness.Class1  obj = new //FeedbackSystemBusiness.Class1 ();
            dt = ObjFeedback_BL.Get_UpcomingEvent(strConn);

            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_MIS_Report_Excel(string EventID, string From_Date, string To_Date)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            ds = ObjFeedback_BL.Fetch_MIS_Report_Excel(EventID, From_Date, To_Date, strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet ImportRetailer()
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            ds = ObjFeedback_BL.ImportRetailer(strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet FetchBaggageReport(string From_Date, string To_Date)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet dsBaggage = new DataSet();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            dsBaggage = ObjFeedback_BL.FetchBaggageReport(From_Date, To_Date, strConn);

            return dsBaggage;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet FetchPowerBankReport(string From_Date, string To_Date)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet dsPowerBank = new DataSet();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            dsPowerBank = ObjFeedback_BL.FetchPowerBankReport(From_Date, To_Date, strConn);

            return dsPowerBank;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



}