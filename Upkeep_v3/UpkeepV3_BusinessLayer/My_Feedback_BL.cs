using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;
using System.Data;

namespace UpkeepV3_BusinessLayer
{
  public class My_Feedback_BL
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


        public DataSet LoginUser(string UserName, string strPassword, string strConn)
        {
            DataSet ds = new DataSet();
            string strOutput = string.Empty;

            SqlConnection con = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand("Feedback_Login", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", strPassword);

            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }

        public DataSet Employee_CRUD(string firstName, string lastName, string email, Int64 phone, string EmpID, string LoggedInUserID, string role, string Username, string Password, string actionType, string strConn)
        {
            DataSet ds = new DataSet();
            string strOutput = string.Empty;

            SqlConnection con = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand("Feedback_Proc_Employee_CRUD", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FName", firstName);
            cmd.Parameters.AddWithValue("@LName", lastName);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@EmpID", EmpID);
            cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
            cmd.Parameters.AddWithValue("@role", role);
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@action", actionType);

            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }

        public DataSet ChangePassword(string UserName, string strPassword, string strConn)
        {
            DataSet ds = new DataSet();
            string strOutput = string.Empty;

            SqlConnection con = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand("Feedback_Proc_ChangePassword", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", strPassword);

            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }

        public DataSet fetchStore(string strConn)
        {
            DataSet ds = new DataSet();
            string strOutput = string.Empty;

            SqlConnection con = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand("Feedback_Proc_fetchStore", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }

        public DataSet Retailer_CRUD(string storeName, string firstName, string lastName, string email, Int64 phone, int RetailerID, string Username, string Password, int CompanyID, string LoggedInUserID, string actionType, string strConn)
        {
            DataSet ds = new DataSet();
            string strOutput = string.Empty;

            SqlConnection con = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand("Feedback_Proc_Retailer_CRUD", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@storeName", storeName);
            cmd.Parameters.AddWithValue("@FName", firstName);
            cmd.Parameters.AddWithValue("@LName", lastName);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@RetailerID", RetailerID);
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
            cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
            cmd.Parameters.AddWithValue("@action", actionType);

            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }

        public DataSet Event_Insert(string eventName, string locationName, string startDateTime, string endDateTime, string CustomerQuestion, string CustQuesType, string QuesFor, int EventID, string EventMode, string LoggedInUserID, string option1, string option2, string option3, string option4, string strConn)
        {
            DataSet ds = new DataSet();
            string strOutput = string.Empty;

            SqlConnection con = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand("Feedback_Proc_Event_Insert", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@eventName", eventName);
            cmd.Parameters.AddWithValue("@locationName", locationName);
            cmd.Parameters.AddWithValue("@startDateTime", startDateTime);
            cmd.Parameters.AddWithValue("@endDateTime", endDateTime);
            cmd.Parameters.AddWithValue("@CustomerQuestion", CustomerQuestion);
            cmd.Parameters.AddWithValue("@CustAnsType", CustQuesType);
            cmd.Parameters.AddWithValue("@QuesFor", QuesFor);
            //cmd.Parameters.AddWithValue("@RetQuesType", RetQuesType);
            cmd.Parameters.AddWithValue("@EventID", EventID);
            cmd.Parameters.AddWithValue("@EventMode", EventMode);
            cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);

            cmd.Parameters.AddWithValue("@option1", option1);
            cmd.Parameters.AddWithValue("@option2", option2);
            cmd.Parameters.AddWithValue("@option3", option3);
            cmd.Parameters.AddWithValue("@option4", option4);

            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }

        public DataSet EventDetails_CRUD(int EventID, string actionType, string strConn)
        {
            DataSet ds = new DataSet();
            string strOutput = string.Empty;

            SqlConnection con = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand("Feedback_Proc_EventDetails_CRUD", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EventID", EventID);
            cmd.Parameters.AddWithValue("@action", actionType);

            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }

        public DataTable Feedback_Insert(int UserID, int LoggedInUserID, int EventID, int QuestionID, string Answer, string strConn)
        {
            SqlConnection con = new SqlConnection(strConn);
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Feedback_Proc_Feedback_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@EventID", EventID);
                cmd.Parameters.AddWithValue("@QuestionID", QuestionID);
                cmd.Parameters.AddWithValue("@Answer", Answer);

                con.Open();
                //cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable Get_RetailerDetails(string storeName, string strConn)
        {
            SqlConnection con = new SqlConnection(strConn);
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("Feedback_Proc_Get_RetailerDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@storeName", storeName);

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable GetEventList(string eventType, string strConn)
        {
            SqlConnection con = new SqlConnection(strConn);
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("Feedback_Proc_Get_EventList", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@eventType", eventType);

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable Insert_CustomerDetails(string firstName, string lastName, string phoneNo, string emailID, string gender, string imagePath, string LoggedInUserID, string strConn)
        {
            SqlConnection con = new SqlConnection(strConn);
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("Feedback_Proc_Insert_CustomerDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@phoneNo", phoneNo);
                cmd.Parameters.AddWithValue("@emailID", emailID);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@imagePath", imagePath);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable Get_FeedbackQuestions(string EventID, string strConn)
        {
            SqlConnection con = new SqlConnection(strConn);
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("Feedback_Proc_Get_FeedbackQuestions", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EventID", EventID);

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet bindEventDetails(int CompanyID,int EventID, string strConn) // companyID Added by sujata
        {
            DataSet ds = new DataSet();
            string strOutput = string.Empty;

            SqlConnection con = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand("Feedback_Proc_Get_EventDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EventID", EventID);
            cmd.Parameters.AddWithValue("@CompanyID", CompanyID);

            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }


        //Added by Sujata This function is used to save Feedback form  
        public DataSet Insert_FeedbackForm(int CompanyID, int EventID,string strFname,string strLname,string strPhoneno,string strGender,string strEmailID,  string FeedbackData,string LoggedInUserID, string strConn) // companyID Added by sujata
        {
            DataSet ds = new DataSet();
            string strOutput = string.Empty;

            SqlConnection con = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand("SPR_INSERT_FEEDBACK_REQUEST", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EventID", EventID);
            cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
            cmd.Parameters.AddWithValue("@Fname",strFname);
            cmd.Parameters.AddWithValue("@Lname", strLname);
            cmd.Parameters.AddWithValue("@PhoneNo", strPhoneno);
            cmd.Parameters.AddWithValue("@EmailID", strEmailID);
            cmd.Parameters.AddWithValue("@Gender", strGender);
            cmd.Parameters.AddWithValue("@FeedbackData", FeedbackData);
            cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
            
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }



        public DataTable Update_CustomerImage(string filePath, int UserID, string strConn)
        {
            SqlConnection con = new SqlConnection(strConn);
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("Feedback_Proc_Update_CustomerImage", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@filePath", filePath);
                cmd.Parameters.AddWithValue("@UserID", UserID);

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet Get_CustomerDetails(string strConn)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(strConn);

            try
            {
                string strOutput = string.Empty;

                SqlCommand cmd = new SqlCommand("Feedback_Proc_Get_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet Get_EventQuestions(int EventID, string strConn)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(strConn);

            try
            {
                string strOutput = string.Empty;

                SqlCommand cmd = new SqlCommand("Feedback_Proc_Get_Questions", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EventID", EventID);

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet Event_QuestionIU(int EventID, string CustomerQuestion, string AnswerType, string opt1, string opt2, string opt3, string opt4, string LoggedInUserID, int QuestionID, string ActionType, string strConn)
        {
            DataSet ds = new DataSet();
            string strOutput = string.Empty;

            SqlConnection con = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand("Feedback_Proc_Event_QuestionIU", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EventID", EventID);
            cmd.Parameters.AddWithValue("@CustomerQuestion", CustomerQuestion);
            cmd.Parameters.AddWithValue("@AnswerType", AnswerType);
            cmd.Parameters.AddWithValue("@option1", opt1);
            cmd.Parameters.AddWithValue("@option2", opt2);
            cmd.Parameters.AddWithValue("@option3", opt3);
            cmd.Parameters.AddWithValue("@option4", opt4);
            cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
            cmd.Parameters.AddWithValue("@QuestID", QuestionID);
            cmd.Parameters.AddWithValue("@ActionType", ActionType);
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }

        public DataSet Fetch_MIS_Report(string EventID, string From_Date, string To_Date, string strConn)
        {
            DataSet ds = new DataSet();
            string strOutput = string.Empty;

            SqlConnection con = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand("Feedback_Proc_MIS_Report", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EventID", EventID);
            cmd.Parameters.AddWithValue("@From_Date", From_Date);
            cmd.Parameters.AddWithValue("@To_Date", To_Date);

            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }

        public DataTable Get_ChartData(string EventID, string fromDate, string toDate, string strConn)
        {
            SqlConnection con = new SqlConnection(strConn);
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("Feedback_Proc_GetChartData", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EventID", EventID);
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate);

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet Event_Update(int EventID, string Location, string QuesFor, string EventMode, string startDate, string endDate, string LoggedInUserID, string ActionType, string strConn)
        {
            DataSet ds = new DataSet();
            string strOutput = string.Empty;

            SqlConnection con = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand("Feedback_Proc_Event_Update_Delete", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EventID", EventID);
            cmd.Parameters.AddWithValue("@locationName", Location);
            cmd.Parameters.AddWithValue("@QuesFor", QuesFor);
            cmd.Parameters.AddWithValue("@EventMode", EventMode);
            cmd.Parameters.AddWithValue("@startDateTime", startDate);
            cmd.Parameters.AddWithValue("@endDateTime", endDate);
            cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
            cmd.Parameters.AddWithValue("@ActionType", ActionType);

            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }

        public DataSet GetEventList(int CompanyID,string EventFor,string strConn) //CompanyID added by sujata 
        {
            SqlConnection con = new SqlConnection(strConn);
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Feedback_Proc_Get_EventList_MIS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@EventFor", EventFor);

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable Get_UpcomingEvent(string strConn)
        {
            SqlConnection con = new SqlConnection(strConn);
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("Feedback_Proc_Get_UpcomingEvents", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet Fetch_MIS_Report_Excel(string EventID, string From_Date, string To_Date, string strConn)
        {
            DataSet ds = new DataSet();
            string strOutput = string.Empty;

            SqlConnection con = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand("Feedback_Proc_MIS_Report_Excel", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EventID", EventID);
            cmd.Parameters.AddWithValue("@From_Date", From_Date);
            cmd.Parameters.AddWithValue("@To_Date", To_Date);

            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }

        public DataSet ImportRetailer(int CompanyID, string strConn)
        {
            DataSet ds = new DataSet();
            string strOutput = string.Empty;

            SqlConnection con = new SqlConnection(strConn);

            SqlCommand cmd = new SqlCommand("Feedback_Proc_Import_Retailer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }


    }
}
