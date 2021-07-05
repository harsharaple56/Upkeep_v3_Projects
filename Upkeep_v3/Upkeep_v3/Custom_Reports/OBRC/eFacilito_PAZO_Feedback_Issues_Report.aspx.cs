using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using RestSharp;
using System.Globalization;
using Newtonsoft.Json;

namespace Upkeep_v3.Custom_Reports.OBRC
{
    public partial class eFacilito_PAZO_Feedback_Issues_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Fetch_Data();
        }

        public void Fetch_Data()
        {
            try
            {


                var client = new RestClient("https://api.gopazo.com/api/v3/issues/get-raised-issues");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");

                string body = @"{" + "\n" +
                @"  ""apiKey"": ""$2a$10$15LaiX5FNGS4NFsV2I/m5OTwAxis3R0HAs96kvYSn2gGUmIo6JeJK""," + "\n" +
                @"  ""siteId"": ""5d53d80fef5b6627bb053b62""" + "\n" +
                @"}";


                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);


                MenuObj pazo = JsonConvert.DeserializeObject<MenuObj>(response.Content);
                

                if (pazo.status == "1")
                {
                    //lblmsg.InnerText = "Api is Working";
                    //dvSuccess.Attributes.Add("style", "display:block;");

                    gv_Pazo_GetIssues.DataSource = pazo.issues;
                    gv_Pazo_GetIssues.DataBind();

                }
                else
                {
                    //lblmsg.InnerText = "Something went wrong, please try again later";
                    dvFailure.Attributes.Add("style", "display:block;");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public class PAZO_API_Response
        {
       
            
        }

        public class ItemObj
        {
            #region Properties  

            /// <summary>  
            /// Gets or sets ID property.  
            /// </summary>  

            public string id { get; set; }
            public string refId { get; set; }
            public string flagIssue { get; set; }
            public string title { get; set; }
            public string createdTime { get; set; }
            public string createdDate { get; set; }
            public string lockedDueDate { get; set; }
            public string departmentId { get; set; }
            public string department { get; set; }
            public string location { get; set; }
            public string raisedBy { get; set; }
            public string assignedTo { get; set; }
            public string dueDate { get; set; }
            public string dueTime { get; set; }
            public string priority { get; set; }
            public string read { get; set; }
            public string timeline { get; set; }
            public string lastActivityOn { get; set; }
            public string statusLabel { get; set; }

            #endregion
        }

        public class MenuObj
        {
            #region Properties  

            public string status { get; set; }
            public string message { get; set; }
            public string uid { get; set; }
            /// <summary>  
            /// Gets or sets header property.  
            /// </summary>  
            public string header { get; set; } = string.Empty;

            /// <summary>  
            /// Gets or sets label property.  
            /// </summary>  
            public List<ItemObj> issues { get; set; } = new List<ItemObj>();

            #endregion
        }

        public class JSONMapperObj
        {
            #region Properties  

            /// <summary>  
            /// Gets or sets menu property.  
            /// </summary>  
            public MenuObj menu { get; set; } = new MenuObj();

            #endregion
        }


    }
}