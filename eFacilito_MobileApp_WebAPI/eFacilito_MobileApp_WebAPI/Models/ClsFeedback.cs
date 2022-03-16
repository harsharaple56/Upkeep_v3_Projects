using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Xml;

namespace eFacilito_MobileApp_WebAPI.Models
{
    public class ClsFeedback
    {

    }

    public class ClsEvent
    {
        public string Event_ID { get; set; }
        public string Event_Name { get; set; }
        public string Start_Date { get; set; }
        public string Expiry_Date { get; set; }
    }

    public class ClsEvent_V2
    {
        public string Event_ID { get; set; }
        public string Event_Name { get; set; }
        public string Start_Date { get; set; }
        public string Expiry_Date { get; set; }
        public int Is_Fname_Mandatory { get; set; }
        public int Is_Lname_Mandatory { get; set; }
        public int Is_Contact_Manadatoy { get; set; }
        public int Is_Email_Manadatoy { get; set; }
        public int Is_Gender_Manadatoy { get; set; }
    }

    public class ClsRetailer
    {
        public string Retailer_ID { get; set; }
        public string Manager_Name { get; set; }
        public string Store_Name { get; set; }
        public string PhoneNo { get; set; }
        public string EmailID { get; set; }
    }

    public class ClsFeedbackQuestions
    {
        public string Event_ID { get; set; }
        public string Question_ID { get; set; }
        public string Question { get; set; }
        public string Answer_Type { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
    }

    public class ClsInsertFeedback
    {
        public string UserID { get; set; }
        public string LoggedInUserID { get; set; }
        public string EventID { get; set; }
        public string QuestionID { get; set; }
        public string Answer { get; set; }
        public string RandomNo { get; set; }
    }

    public class ClsCustomer
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNo { get; set; }
        public string emailID { get; set; }
        public string gender { get; set; }
        //public string imagePath { get; set; }
       // public string ImageString { get; set; }
        public string LoggedInUserID { get; set; }
        public int CompanyID { get; set; }
    }

    public class ClsCustomerImage
    {
        public string UserID { get; set; }
        public string ImageString { get; set; }
    }

    public class ClsFetchRetailers
    {
        public int Retailer_ID { get; set; }
        public string Store_Name { get; set; }
        public string Store_No { get; set; }


    }


}