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

    //Json mail body
    public class Json_Mail_Root
    {
        public string mail_template_key { get; set; }
        public string bounce_address { get; set; }
        public From from { get; set; }
        public List<To> to { get; set; }
        //public To to { get; set; }
        public MergeInfo merge_info { get; set; }
        //public ReplyTo reply_to { get; set; }
        public List<ReplyTo> reply_to { get; set; }
        public string client_reference { get; set; }
        public MimeHeaders mime_headers { get; set; }
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

    public class MergeInfo
    {
        public string RaisedBy_Name { get; set; }
        public string Ticket_ID { get; set; }
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

}