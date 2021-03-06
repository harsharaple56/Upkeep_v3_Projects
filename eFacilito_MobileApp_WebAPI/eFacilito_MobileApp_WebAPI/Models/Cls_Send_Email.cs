using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Xml;
using Newtonsoft.Json;

namespace eFacilito_MobileApp_WebAPI.Models
{
    public class Cls_Send_Email
    {
        public int Emails { get; set; }
        public int Subject { get; set; }
        public int Html_Body { get; set; }

    }

    public class Cls_Send_Email_Json
    {
        public string To_Email { get; set; }
        public string Subject { get; set; }
        public string Html_Body { get; set; }

    }

    public class From
    {
        public string address { get; set; }
        public string name { get; set; }
    }

    public class EmailAddress
    {
        public string address { get; set; }
        public string name { get; set; }
    }

    public class To
    {
        //public List<EmailAddress> email_address { get; set; }
        public EmailAddress email_address { get; set; }
    }

    #region Ticket Json mail body
    public class Json_Mail_Root
    {
        public string mail_template_key { get; set; }
        public string bounce_address { get; set; }
        public From from { get; set; }
        public List<To> to { get; set; }
        //public To to { get; set; }
        public MergeInfo merge_info { get; set; }
        //public MergeInfo_Gatepass merge_info_gatepass { get; set; }
        //public ReplyTo reply_to { get; set; }
        public List<ReplyTo> reply_to { get; set; }
        public string client_reference { get; set; }
        public MimeHeaders mime_headers { get; set; }
    }

    public class MergeInfo
    {
        public string Company_Name { get; set; }
        public string RaisedBy_Name { get; set; }
        public string Assigned_Department { get; set; }
        public string Ticket_ID { get; set; }
        public string Ticket_Date { get; set; }
        public string Ticket_Location { get; set; }
        public string Ticket_Category { get; set; }
        public string Ticket_SubCategory { get; set; }
        public string Ticket_Level { get; set; }
        public string User_Department { get; set; }
        public string Ticket_Status { get; set; }
        public string Action_Status { get; set; }
        public string Escalated_Users { get; set; }
        public string Ticket_Remarks { get; set; }

    }
    #endregion

    #region Gatepass Json mail 

    public class Json_Mail_Root_Gatepass
    {
        public string mail_template_key { get; set; }
        public string bounce_address { get; set; }
        public From from { get; set; }
        public List<To> to { get; set; }
        //public To to { get; set; }
        public MergeInfo_Gatepass merge_info { get; set; }
        //public ReplyTo reply_to { get; set; }
        public List<ReplyTo> reply_to { get; set; }
        public string client_reference { get; set; }
        public MimeHeaders mime_headers { get; set; }
    }
    public class MergeInfo_Gatepass
    {
        public string Raiser_Name { get; set; }
        public string Gatepass_ID { get; set; }
        public string Gatepass_Raised_Date { get; set; }
        public string Gatepass_No { get; set; }
        public string Gatepass_Title { get; set; }
        public string Gatepass_Type { get; set; }
        public string Gatepass_Date { get; set; }
        public string Gatepass_Material_Detail { get; set; }
        public string Company_Name { get; set; }
    }
    #endregion

    #region WorkPermit Mail Json
    public class Json_Mail_Root_WorkPermit
    {
        public string mail_template_key { get; set; }
        public string bounce_address { get; set; }
        public From from { get; set; }
        public List<To> to { get; set; }
        //public To to { get; set; }
        public MergeInfo_WorkPermit merge_info { get; set; }
        //public ReplyTo reply_to { get; set; }
        public List<ReplyTo> reply_to { get; set; }
        public string client_reference { get; set; }
        public MimeHeaders mime_headers { get; set; }
    }
    public class MergeInfo_WorkPermit
    {
        public string Company_Name { get; set; }
        public string Work_Permit_ID { get; set; }
        public string Work_Permit_Title { get; set; }
        public string Request_Date { get; set; }
        public string Permit_From_Date { get; set; }
        public string Permit_To_Date { get; set; }
    }
    #endregion

    #region VMS Mail Json
    public class Json_Mail_Root_VMS
    {
        public string mail_template_key { get; set; }
        public string bounce_address { get; set; }
        public From from { get; set; }
        public List<To> to { get; set; }
        //public To to { get; set; }
        public MergeInfo_VMS merge_info { get; set; }
        //public ReplyTo reply_to { get; set; }
        public List<ReplyTo> reply_to { get; set; }
        public string client_reference { get; set; }
        public MimeHeaders mime_headers { get; set; }
    }
    public class MergeInfo_VMS
    {
        public string Company_Name { get; set; }
        public string Visit_Request_ID { get; set; }
        public string Visitor_Name { get; set; }
        public string Visitor_ID_Link { get; set; }
        public string VMS_Config_Title { get; set; }
        public string Visit_Date { get; set; }
        public string Visit_Request_Date { get; set; }
    }
    #endregion

    #region Forgot Password OTP
    public class Json_Mail_Root_OTP
    {
        public string mail_template_key { get; set; }
        public string bounce_address { get; set; }
        public From from { get; set; }
        public List<To> to { get; set; }
        //public To to { get; set; }
        public MergeInfo_OTP merge_info { get; set; }
        //public ReplyTo reply_to { get; set; }
        public List<ReplyTo> reply_to { get; set; }
        public string client_reference { get; set; }
        public MimeHeaders mime_headers { get; set; }
    }
    public class MergeInfo_OTP
    {
        public string OTP { get; set; }
        public string User_Name { get; set; }
    }
    #endregion

    #region Meet Users Visit Request
    public class Json_Mail_Root_MeetUsers
    {
        public string mail_template_key { get; set; }
        public string bounce_address { get; set; }
        public From from { get; set; }
        public List<To> to { get; set; }
        //public To to { get; set; }
        public MergeInfo_MeetUsers merge_info { get; set; }
        //public ReplyTo reply_to { get; set; }
        public List<ReplyTo> reply_to { get; set; }
        public string client_reference { get; set; }
        public MimeHeaders mime_headers { get; set; }
    }
    public class MergeInfo_MeetUsers
    {
        public string Meeting_with_Name { get; set; }
        public string Company_Name { get; set; }
        public string Visit_Request_ID { get; set; }
        public string Visitor_Name { get; set; }
        public string Visitor_ID_Link { get; set; }
        public string VMS_Config_Title { get; set; }
        public string Visit_Date { get; set; }
    }
    #endregion


    public class ReplyTo
    {
        public string address { get; set; }
        public string name { get; set; }
    }

    public class MimeHeaders
    {
        [JsonProperty("X-Test")]
        public string XTest { get; set; }
    }

}