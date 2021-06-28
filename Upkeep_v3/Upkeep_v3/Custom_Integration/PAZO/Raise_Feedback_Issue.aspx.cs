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

namespace Upkeep_v3.Custom_Integration.PAZO
{
    public partial class Raise_Feedback_Issue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string FeedbackID = string.Empty;
                string CustomerName = string.Empty;
                string IssueName = string.Empty;
                string IssueDesc = string.Empty;
                string DueDate = string.Empty;

                FeedbackID = Convert.ToString(lblFeedbackID.Text.Trim());
                CustomerName = Convert.ToString(lblCustomerName.Text.Trim());
                IssueName = Convert.ToString(txtIssueName.Text.Trim());
                IssueDesc = Convert.ToString(txtIssueDesc.Text.Trim());

                DateTime dtDue = Convert.ToDateTime(txtDueDate.Text.Trim());

                DueDate =  DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'", DateTimeFormatInfo.InvariantInfo);
                //DueDate = dtDue.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.000+0530'", DateTimeFormatInfo.InvariantInfo);

                //document.write(dt.toISOString());

                //DueDate = Convert.ToString(txtDueDate.Text.Trim());

                var client = new RestClient("https://api.gopazo.com/api/v5/issues/add-issue");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");


                string body = @"{" + "\n" +
                @"  ""siteId"": ""5d53d80fef5b6627bb053b62""," + "\n" +
                @"  ""apiKey"": ""$2a$10$zsrP9PQyBNPwPjOSdDAESO2riYKXEqcfJblUjcxveu2AAv3iHJRyu""," + "\n" +
                @"  ""issueTypeId"": ""5d4d6b57ef5b6627bb0532b3""," + "\n" +
                @"  ""locationCode"": ""5e05f66b9fc7b9f7f4e8361e""," + "\n" +
                @"  ""departmentId"": ""5d53d880ef5b6627bb053b69""," + "\n" +
                @"  ""customValues"": [" + "\n" +
                @"{" + "\n" +
                @"""_id"": ""issueName""," + "\n" +
                @"""label"": ""Issue Name""," + "\n" +
                @"""type"": ""text""," + "\n" +
                //@"""value"": ""text""" + "\n" +
                @"""value"": """ + Convert.ToString(IssueName) +"\""+ "}," + "\n" +
                @"{" + "\n" +
                @"""_id"": ""issuePics""," + "\n" +
                @"""label"": ""Add Attachments of the Issue""," + "\n" +
                @"""type"": ""picture""," + "\n" +
                @"""value"": [" + "\n" +
                @"""https://trakdstorage.blob.core.windows.net/tapntrack/2021-06/img_20210611153709_1623406029463_zExjIbygy1s_J4v0WFiGgWl.jpg""," + "\n" +
                @"""https://trakdstorage.blob.core.windows.net/tapntrack/2021-06/file_20210209162507_1612868107543.pdf""" + "\n" +
                @"]" + "\n" +
                @"}," + "\n" +
                @"{" + "\n" +
                @"""_id"": ""dueDate""," + "\n" +
                @"""label"": ""Due Date""," + "\n" +
                @"""type"": ""datetime""," + "\n" +
                //@"""value"": ""DueDate""" + "\n" +    @"}," + "\n" +
                @"""value"": """ + Convert.ToString(DueDate) + "\"" + "}," + "\n" +
                @"{" + "\n" +
                @"""_id"": ""5e25b6597d8dbb6f3a97eb97""," + "\n" +
                @"""label"": ""Type of Request""," + "\n" +
                @"""type"": ""radio""," + "\n" +
                @"""value"": ""Complaint""" + "\n" +
                @"}," + "\n" +
                @"{" + "\n" +
                @"""_id"": ""5e25b6597d8dbb6f3a97eb98""," + "\n" +
                @"""label"": ""If Work Permit, Please enter  Start time""," + "\n" +
                @"""type"": ""datetime""," + "\n" +
                @"""value"": """"" + "\n" +
                @"}," + "\n" +
                @"{" + "\n" +
                @"""_id"": ""5e25603588d3ddbad6cf13cc""," + "\n" +
                @"""label"": ""Permit End Time""," + "\n" +
                @"""type"": ""datetime""," + "\n" +
                @"""value"": """"" + "\n" +
                @"}," + "\n" +
                @"{" + "\n" +
                @"""_id"": ""5e26a7ebbed8841865ddc5ee""," + "\n" +
                @"""label"": ""Number of people Working""," + "\n" +
                @"""type"": ""number""," + "\n" +
                @"""value"": """"" + "\n" +
                @"}," + "\n" +
                @"{" + "\n" +
                @"""_id"": ""60bf7086cc66994aa30d9b90""," + "\n" +
                @"""label"": ""Feedback ID""," + "\n" +
                @"""type"": ""number""," + "\n" +
                //@"""value"": ""FeedbackID""" + "\n" + @"}," + "\n" +
                @"""value"": """ + Convert.ToString(FeedbackID) + "\"" + "}," + "\n" +              
                @"{" + "\n" +
                @"""_id"": ""60bf7086cc66994aa30d9b91""," + "\n" +
                @"""label"": ""Customer Name (Contact)""," + "\n" +
                @"""type"": ""text""," + "\n" +
                //@"""value"": ""CustomerName""" + "\n" +    @"}," + "\n" +
                @"""value"": """ + Convert.ToString(CustomerName) + "\"" + "}," + "\n" +
                @"{" + "\n" +
                @"""_id"": ""60c32b4adab8d63656246e51""," + "\n" +
                @"""label"": ""Complaint Details""," + "\n" +
                @"""type"": ""longText""," + "\n" +
                //@"""value"": ""IssueDesc""" + "\n" +    @"}" + "\n" +
                @"""value"": """ + Convert.ToString(IssueDesc) + "\"" + "}" + "\n" +
                @"]," + "\n" +
                @"""time"": ""2021-06-11T15:37:28.174+0530""," + "\n" +
                @"""deviceTime"": ""2021-06-11T15:37:31.619+0530""," + "\n" +
                @"""incidentLat"": ""0.0""," + "\n" +
                @"""incidentLong"": ""0.0""," + "\n" +
                @"""lac"": ""0""," + "\n" +
                @"""cid"": ""0""," + "\n" +
                @"""mcc"": ""310""," + "\n" +
                @"""mnc"": ""260""," + "\n" +
                @"""version"": ""8.6.0-prod-beta""" + "\n" +
                @"}";


//                var body = @"{" + "\n" +
//@"  ""siteId"": ""5d53d80fef5b6627bb053b62""," + "\n" +
//@"  ""apiKey"": ""$2a$10$zsrP9PQyBNPwPjOSdDAESO2riYKXEqcfJblUjcxveu2AAv3iHJRyu""," + "\n" +
//@"  ""issueTypeId"": ""5d4d6b57ef5b6627bb0532b3""," + "\n" +
//@"  ""locationCode"": ""5e05f66b9fc7b9f7f4e8361e""," + "\n" +
//@"  ""departmentId"": ""5d53d880ef5b6627bb053b69""," + "\n" +
//@"  ""customValues"": [" + "\n" +
//@"    {" + "\n" +
//@"      ""_id"": ""issueName""," + "\n" +
//@"      ""label"": ""Issue Name""," + "\n" +
//@"      ""type"": ""text""," + "\n" +
//@"      ""value"": ""testing from eFacilito""" + "\n" +
//@"    }," + "\n" +
//@"    {" + "\n" +
//@"      ""_id"": ""issuePics""," + "\n" +
//@"      ""label"": ""Add Attachments of the Issue""," + "\n" +
//@"      ""type"": ""picture""," + "\n" +
//@"      ""value"": [" + "\n" +
//@"        ""https://trakdstorage.blob.core.windows.net/tapntrack/2021-06/img_20210611153709_1623406029463_zExjIbygy1s_J4v0WFiGgWl.jpg""," + "\n" +
//@"        ""https://trakdstorage.blob.core.windows.net/tapntrack/2021-06/file_20210209162507_1612868107543.pdf""" + "\n" +
//@"      ]" + "\n" +
//@"    }," + "\n" +
//@"    {" + "\n" +
//@"      ""_id"": ""dueDate""," + "\n" +
//@"      ""label"": ""Due Date""," + "\n" +
//@"      ""type"": ""datetime""," + "\n" +
//@"      ""value"": ""2021-06-12T15:36:00.000+0530""" + "\n" +
//@"    }," + "\n" +
//@"    {" + "\n" +
//@"      ""_id"": ""5e25b6597d8dbb6f3a97eb97""," + "\n" +
//@"      ""label"": ""Type of Request""," + "\n" +
//@"      ""type"": ""radio""," + "\n" +
//@"      ""value"": ""Complaint""" + "\n" +
//@"    }," + "\n" +
//@"    {" + "\n" +
//@"      ""_id"": ""5e25b6597d8dbb6f3a97eb98""," + "\n" +
//@"      ""label"": ""If Work Permit, Please enter  Start time""," + "\n" +
//@"      ""type"": ""datetime""," + "\n" +
//@"      ""value"": """"" + "\n" +
//@"    }," + "\n" +
//@"    {" + "\n" +
//@"      ""_id"": ""5e25603588d3ddbad6cf13cc""," + "\n" +
//@"      ""label"": ""Permit End Time""," + "\n" +
//@"      ""type"": ""datetime""," + "\n" +
//@"      ""value"": """"" + "\n" +
//@"    }," + "\n" +
//@"    {" + "\n" +
//@"      ""_id"": ""5e26a7ebbed8841865ddc5ee""," + "\n" +
//@"      ""label"": ""Number of people Working""," + "\n" +
//@"      ""type"": ""number""," + "\n" +
//@"      ""value"": """"" + "\n" +
//@"    }," + "\n" +
//@"    {" + "\n" +
//@"      ""_id"": ""60bf7086cc66994aa30d9b90""," + "\n" +
//@"      ""label"": ""Feedback ID""," + "\n" +
//@"      ""type"": ""number""," + "\n" +
//@"      ""value"": """"" + "\n" +
//@"    }," + "\n" +
//@"    {" + "\n" +
//@"      ""_id"": ""60bf7086cc66994aa30d9b91""," + "\n" +
//@"      ""label"": ""Customer Name (Contact)""," + "\n" +
//@"      ""type"": ""text""," + "\n" +
//@"      ""value"": """"" + "\n" +
//@"    }," + "\n" +
//@"    {" + "\n" +
//@"      ""_id"": ""60c32b4adab8d63656246e51""," + "\n" +
//@"      ""label"": ""Complaint Details""," + "\n" +
//@"      ""type"": ""longText""," + "\n" +
//@"      ""value"": """"" + "\n" +
//@"    }" + "\n" +
//@"  ]," + "\n" +
//@"  ""time"": ""2021-06-11T15:37:28.174+0530""," + "\n" +
//@"  ""deviceTime"": ""2021-06-11T15:37:31.619+0530""," + "\n" +
//@"  ""incidentLat"": ""0.0""," + "\n" +
//@"  ""incidentLong"": ""0.0""," + "\n" +
//@"  ""lac"": ""0""," + "\n" +
//@"  ""cid"": ""0""," + "\n" +
//@"  ""mcc"": ""310""," + "\n" +
//@"  ""mnc"": ""260""," + "\n" +
//@"  ""version"": ""8.6.0-prod-beta""" + "\n" +
//@"}";

                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                PAZO_API_Response pazo = JsonConvert.DeserializeObject<PAZO_API_Response>(response.Content);

                if (pazo.status == "1")
                {
                    //lblSuccessMsg.Text = "Ticket has been raised successfully in PAZO.";
                    dvSuccess.Attributes.Add("style", "display:block;");
                }
                else
                {
                    //lblFalureMsg.Text = "Something went wrong, please try again later";
                    dvFailure.Attributes.Add("style", "display:block;");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Bind_Details()
        {
            try
            {
                ////int studentId = Request.QueryString["StudentId"];
                // string BaseURL = string.Empty;
                // //BaseURL = Convert.ToString(ConfigurationManager.AppSettings["Base_URL"]);

                //// SuccessURL = BaseURL + "Admission/FeePaymentSuccess.aspx?status=0&studentid=" + studentId;

                // //string surl = SuccessURL;
                // Session.Add("surl", surl);

                // Session["surl"] = SuccessURL;

                // Random r = new Random();
                // string txnid = "Txn" + r.Next(100, 9999);
                // Session.Add("txnid", txnid);

                // hdnMerchantKey.Value = Convert.ToString(ConfigurationManager.AppSettings["MERCHANT_KEY"]);
                // hdnMerchantSalt.Value = Convert.ToString(ConfigurationManager.AppSettings["SALT"]);
                // hdnTransactionID.Value = "";
                // hdnAmount.Value = "";
                // hdnProductInfo.Value = Convert.ToString(ConfigurationManager.AppSettings["ProductInfo"]);
                // hdnFirstName.Value = "Faisal"; //Convert.ToString(txtFirstname.Text.Trim());
                // hdnEmailID.Value = ""; //Convert.ToString(txtEmailID.Text.Trim());
                // hdnMobileNo.Value = ""; //Convert.ToString(txtMobileNo.Text.Trim());
                //                                   //hdnHash.Value =
                // Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "generateHash()", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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