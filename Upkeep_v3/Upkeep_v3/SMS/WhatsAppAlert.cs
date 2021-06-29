using System;
using System.Web.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Upkeep_v3.SMS
{
    public class WhatsAppAlert
    {
        public static void SendALert(string MsgBody, string ToNo, string ModuleType, int CompanyID, string LoggedInUserID, int RecordID = 0)
        {
            MessageResource message = null;
            WhatsAppAlert oWhatsAppAlert = new WhatsAppAlert();
            string accountSid = string.Empty, authToken = string.Empty, FromNo = string.Empty,ErrorMsg = null;
            try
            {
                accountSid = WebConfigurationManager.AppSettings["TwilioAccountSid"];
                authToken = WebConfigurationManager.AppSettings["TwilioAuthToken"];
                FromNo = WebConfigurationManager.AppSettings["TwilioFromNo"];
                TwilioClient.Init(accountSid, authToken);

                var messageOptions = new CreateMessageOptions(
                    new PhoneNumber("whatsapp:" + ToNo));
                messageOptions.From = new PhoneNumber("whatsapp:" + FromNo);
                messageOptions.Body = MsgBody;

                
                message = MessageResource.Create(messageOptions);

            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message;
            }
            finally
            {
                //Log Data
                Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
                ObjUpkeep.Insert_WhatSappLog(ModuleType, RecordID, accountSid, authToken,
                message == null ? null : message.Sid, MsgBody, Convert.ToString(message == null ? "Failed" : message.Status),
                FromNo, ToNo, message == null ? null : message.ErrorCode, ErrorMsg, CompanyID, LoggedInUserID);
            }
        }
    }
}