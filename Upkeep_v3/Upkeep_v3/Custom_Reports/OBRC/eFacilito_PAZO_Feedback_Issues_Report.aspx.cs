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

                PAZO_API_Response pazo = JsonConvert.DeserializeObject<PAZO_API_Response>(response.Content);

                if (pazo.status == "1")
                {
                    //lblmsg.InnerText = "Api is Working";
                    //dvSuccess.Attributes.Add("style", "display:block;");
                    
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
            public string status { get; set; }
            public string message { get; set; }
            public string uid { get; set; }
            public string _id { get; set; }
            public string refId { get; set; }
        }

    }
}