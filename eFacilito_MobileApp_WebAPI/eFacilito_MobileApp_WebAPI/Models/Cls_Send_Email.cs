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

    #region Ticket Mail Json
    public class Json_Mail_Root_Ticket
    {
        public string mail_template_key { get; set; }
        public string bounce_address { get; set; }
        public From from { get; set; }
        public List<To> to { get; set; }
        //public To to { get; set; }
        public MergeInfo_Ticket merge_ticket_info { get; set; }
        //public ReplyTo reply_to { get; set; }
        public List<ReplyTo> reply_to { get; set; }
        public string client_reference { get; set; }
        public MimeHeaders mime_headers { get; set; }
    }

    public class MergeInfo_Ticket
    {
        public string RaisedBy_Name { get; set; }
        public string Assigned_Department { get; set; }
        public string Ticket_ID { get; set; }
        public string Ticket_Date { get; set; }
        public string Ticket_Location { get; set; }
        public string Ticket_Category { get; set; }
        public string Ticket_SubCategory { get; set; }
        public string Ticket_Level { get; set; }
        public string User_Department { get; set; }
    }
    #endregion

    #region Gatepass Mail Json
    public class Json_Mail_Root_Gatepass
    {
        public string mail_template_key { get; set; }
        public string bounce_address { get; set; }
        public From from { get; set; }
        public List<To> to { get; set; }
        //public To to { get; set; }
        public MergeInfo_Gatepass merge_gatepass_info { get; set; }
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
        public MergeInfo_WorkPermit merge_workpermit_info { get; set; }
        //public ReplyTo reply_to { get; set; }
        public List<ReplyTo> reply_to { get; set; }
        public string client_reference { get; set; }
        public MimeHeaders mime_headers { get; set; }
    }
    public class MergeInfo_WorkPermit
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

    #region VMS Mail Json
    public class Json_Mail_Root_VMS
    {
        public string mail_template_key { get; set; }
        public string bounce_address { get; set; }
        public From from { get; set; }
        public List<To> to { get; set; }
        //public To to { get; set; }
        public MergeInfo_VMS merge_vms_info { get; set; }
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
    }
    #endregion
}