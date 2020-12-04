using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using UpkeepV3_BusinessLayer;
using System.Reflection;

/// <summary>
/// Summary description for My_FeedbackSystem
/// </summary>
public class My_FeedbackSystem
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

    UpkeepV3_BusinessLayer.My_Feedback_BL ObjFeedback_BL = new UpkeepV3_BusinessLayer.My_Feedback_BL();
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
    //        strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
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

    public DataSet Employee_CRUD(string firstName, string lastName, string email, Int64 phone, string EmpID, string LoggedInUserID, string role,string Username,string Password, string actionType)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
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
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
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
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
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

    public DataSet Retailer_CRUD(string storeName,string Store_No, string firstName, string lastName, string email, Int64 phone, int RetailerID, string Username, string Password, int CompanyID, string LoggedInUserID, string actionType)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            ds = ObjFeedback_BL.Retailer_CRUD(storeName, Store_No, firstName, lastName, email, phone, RetailerID, Username, Password, CompanyID, LoggedInUserID, actionType, strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataSet Event_Insert(string eventName, string locationName, string startDateTime, string endDateTime, string CustomerQuestion, string CustQuesType, string QuesFor, int EventID,string EventMode,string LoggedInUserID,string option1,string option2,string option3,string option4, int CompanyID)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            //ds = objEmp.Event_Insert(eventName, locationName, startDateTime, endDateTime, CustomerQuestion, CustQuesType, RetailerQuestion, RetQuesType,EventID, strConn);
            ds = ObjFeedback_BL.Event_Insert(eventName, locationName, startDateTime, endDateTime, CustomerQuestion, CustQuesType, QuesFor, EventID, EventMode, LoggedInUserID,option1, option2, option3, option4, CompanyID, strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataSet EventDetails_CRUD(int EventID,int CompanyID, string actionType)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            ds = ObjFeedback_BL.EventDetails_CRUD(EventID, CompanyID, actionType, strConn);

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
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataTable dt = new DataTable();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            dt= ObjFeedback_BL.Feedback_Insert(UserID, LoggedInUserID,EventID, QuestionID, Answer, strConn);
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
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataTable dt = new DataTable();
            //FeedbackSystemBusiness.Class1  obj = new //FeedbackSystemBusiness.Class1 ();
            dt = ObjFeedback_BL.Get_RetailerDetails(storeName,strConn);

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
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataTable dt = new DataTable();
            //FeedbackSystemBusiness.Class1  obj= new //FeedbackSystemBusiness.Class1 ();
            dt = ObjFeedback_BL.GetEventList(eventType,strConn);

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
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataTable dt = new DataTable();
            //FeedbackSystemBusiness.Class1  obj = new //FeedbackSystemBusiness.Class1 ();
            dt = ObjFeedback_BL.Insert_CustomerDetails(firstName, lastName, phoneNo, emailID, gender, imagePath,LoggedInUserID, strConn);

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
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
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

    public DataSet bindEventDetails(int CompanyID,int EventID)  //CompanyID Added by sujata 
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            ds = ObjFeedback_BL.bindEventDetails(CompanyID,EventID, strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //Added by Sujata This function is used to save Feedback form
    public DataSet Insert_FeedbackForm(int CompanyID, int EventID, string strFname, string strLname, string strPhoneno, string strGender, string strEmailID, string FeedbackData, string LoggedInUserID)  //CompanyID Added by sujata 
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            ds = ObjFeedback_BL.Insert_FeedbackForm(CompanyID, EventID, strFname, strLname, strPhoneno, strGender, strEmailID, FeedbackData, LoggedInUserID ,strConn);

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
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataTable dt = new DataTable();
            //FeedbackSystemBusiness.Class1  obj = new //FeedbackSystemBusiness.Class1 ();
            dt = ObjFeedback_BL.Update_CustomerImage(filePath,UserID, strConn);

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
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
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
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            ds = ObjFeedback_BL.Get_EventQuestions(EventID,strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Event_QuestionIU(int EventID, string CustomerQuestion, string AnswerType, string opt1, string opt2, string opt3, string opt4, string LoggedInUserID,int QuestionID, string ActionType)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            //ds = objEmp.Event_Insert(eventName, locationName, startDateTime, endDateTime, CustomerQuestion, CustQuesType, RetailerQuestion, RetQuesType,EventID, strConn);
            ds = ObjFeedback_BL.Event_QuestionIU(EventID, CustomerQuestion, AnswerType, opt1, opt2, opt3, opt4, LoggedInUserID,QuestionID, ActionType, strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet Fetch_MIS_Report(string EventID, string From_Date,string To_Date, int CompanyID)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            ds = ObjFeedback_BL.Fetch_MIS_Report(EventID,From_Date, To_Date, CompanyID, strConn);

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
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
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
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            //ds = objEmp.Event_Insert(eventName, locationName, startDateTime, endDateTime, CustomerQuestion, CustQuesType, RetailerQuestion, RetQuesType,EventID, strConn);
            ds = ObjFeedback_BL.Event_Update(EventID, Location, QuesFor, EventMode, startDate, endDate, LoggedInUserID,ActionType, strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataSet GetEventList(int CompanyID,String EventFor) //CompanyID Added by Sujata 
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            //FeedbackSystemBusiness.Class1  obj = new //FeedbackSystemBusiness.Class1 ();
            ds = ObjFeedback_BL.GetEventList(CompanyID,EventFor,strConn);

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
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
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

    public DataSet Fetch_MIS_Report_Excel(string EventID, string From_Date, string To_Date, int CompanyID)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            ds = ObjFeedback_BL.Fetch_MIS_Report_Excel(EventID,From_Date, To_Date, CompanyID, strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataSet ImportRetailer(int CompanyID)
    {
        try
        {
            strConn = System.Configuration.ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString.ToString();
            string strOutput = string.Empty;
            DataSet ds = new DataSet();
            //FeedbackSystemBusiness.Class1  objEmp = new //FeedbackSystemBusiness.Class1 ();
            ds = ObjFeedback_BL.ImportRetailer(CompanyID,strConn);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //----------------------------------------------

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
    }  


    //-----------------------------------------------

}