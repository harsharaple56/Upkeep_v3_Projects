using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using Newtonsoft.Json;

namespace eFacilito_MobileApp_WebAPI
{
    public class RestsharpAPI
    {
        private static string APIkey = "AAAA_fJmLxk:APA91bGHjkqHSTmd_XM8OSmSlKLpt-ig8vOyGyjkR-s2cSOsBW7YfnfXyhaV3-V3Ry8ODeNVsNv6iTOGq6POEHo4gd6NMSjH30iD4osuo5tc0eIinNKhbB_fSJ-H3GI2ukF1vsLfOdiS";
        private static string SMS_APIkey = "bS7uQ+tAGnY-o8t4rZhN79hREhC5GbEW7mMSl34oBL";
        private static string SMS_SENDER = "TXTLCL";
        private static RestsharpAPI ourInstance = null;


        public static RestsharpAPI GetInstance()
        {
            if (ourInstance == null)
            {
                ourInstance = new RestsharpAPI();
            }

            return ourInstance;
        }

        private class Push
        {
            public string to { get; set; }
            public Notification notification { get; set; }
            public Data data { get; set; }

            public Push(string to, Notification notification, Data data)
            {
                this.to = to;
                this.notification = notification;
                this.data = data;
            }
        }


        private class Notification
        {
            public string title { get; set; }
            public string body { get; set; }
            public int TransactionID { get; set; }
            public string click_action { get; set; }

            public Notification(string title, string body, int TransactionID, string click_action)
            {
                this.title = title;
                this.body = body;
                this.TransactionID = TransactionID;
                this.click_action = click_action;
            }
        }

        private class Data
        {
            public string title { get; set; }
            public string body { get; set; }
            public int TransactionID { get; set; }
            public string timestamp { get; set; }

            public Data(string title, string body, int TransactionID)
            {
                this.title = title;
                this.body = body;
                this.TransactionID = TransactionID;
                timestamp = DateTime.Now.ToString();
            }
        }

        public static string SendNotification(string token, int TransactionID, string title, string message, string click_action)
        {
            var client = new RestClient("https://fcm.googleapis.com");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);


            var request = new RestRequest("fcm/send", Method.POST);
            //request.AddParameter("to", token); // adds to POST or URL querystring based on Method
            // request.AddBody(new Push(token, new Notification(title, message), new Data(title, message)));
            // request.RequestFormat = DataFormat.Json;

            string data = JsonConvert.SerializeObject(new Push(token, new Notification(title, message, TransactionID, click_action), new Data(title, message, TransactionID)));
            request.AddParameter("application/json", data, ParameterType.RequestBody);

            //  Push push = new Push(title, message);
            //  string data = JsonConvert.SerializeObject(push);
            //request.AddParameter("data", data); // adds to POST or URL querystring based on Method
            //request.AddParameter("data","Inserted data");

            // easily add HTTP Headers
            request.AddHeader("Authorization", "key =" + APIkey);
            request.AddHeader("Content-Type", "application/json");


            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string


            //// easy async support
            //client.ExecuteAsync(request, response =>
            //{
            //    Console.WriteLine(response.Content);
            //});

            return content.ToString();

        }

        private class SMSBody
        {
            public string apiKey { get; set; }
            public string numbers { get; set; }
            public string message { get; set; }
            public string sender { get; set; }
            public bool test { get; set; }

            public SMSBody(string apikey, string phone, string message, string sender, bool test)
            {
                this.apiKey = apikey;
                this.numbers = phone;
                this.message = message;
                this.sender = sender;
                this.test = true;
            }
        }

        public static string SendSMS(string phone, string message, bool testMode = false) // TEST MODE FOR RESPONSE CHECK NO SMS WILL BE SENT 
        {
            var client = new RestClient("https://api.textlocal.in");

            var request = new RestRequest("send/?apikey={apiKey}&numbers={numbers}&message={message}&sender={sender}&test={test}", Method.GET);
            request.AddUrlSegment("apiKey", SMS_APIkey);
            request.AddUrlSegment("numbers", phone);
            request.AddUrlSegment("message", message);
            request.AddUrlSegment("sender", SMS_SENDER);
            request.AddUrlSegment("test", testMode ? "true" : "false");


            //string data = JsonConvert.SerializeObject(new SMSBody(SMS_APIkey, phone, message, SMS_SENDER, testMode));
            //request.AddParameter("application/json",data,ParameterType.RequestBody);
            //request.AddBody(data);

            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string
            return content.ToString();
        }

    }
}