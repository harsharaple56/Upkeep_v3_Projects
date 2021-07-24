using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Xml;

namespace eFacilito_MobileApp_WebAPI.Models
{
    public class Cls_Send_Email
    {
        public int Emails { get; set; }
        public int Subject { get; set; }
        public int Html_Body { get; set; }

    }

}