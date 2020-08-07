using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace eFacilito_MobileApp_WebAPI.Models
{
    public class GatePassMail
    {
        DataSet ObjSetUpDt = new DataSet();

        string StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
        public System.Data.DataSet FunFetchEmpDetail(string StrGateID)
        {

            // string StrLocConnection = null;
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DtLocDatatable = new DataSet();

            try
            {
                //StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[1];
                ObjLocSqlParameter[0] = new SqlParameter("@GateID", StrGateID);
                DtLocDatatable = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchEmpDetailsMobile", ObjLocSqlParameter);
                return DtLocDatatable;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void SendMailsForGatePass(DataSet ToEmpDt, string lblRetailerName, string lblmobileno, string Message = " ", string GatepassID = " ", string StrRollCD = "", string StrHdnEmpCD = "", string StrRequestStatus = "")
        {
            DataSet ObjEmpDet = new DataSet();
            DataSet ObjFromEmpDet = new DataSet();
            //DataSet ObjSetUpDt = new DataSet();
            DataSet ObjToEmpDet = new DataSet();
            DataSet ObjMailFormat = new DataSet();
            string StrMailBody = "";
            string StrMailSubject = "";
            MailMessage ObjMg = new MailMessage();



            ClsCommunication ObjLocComm = new ClsCommunication();

            try
            {

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[1];
                ObjLocSqlParameter[0] = new SqlParameter("@GateID", GatepassID);
                ObjEmpDet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchEmployeeDetailsForGatepassMail", ObjLocSqlParameter);
                //  return ObjEmpDet;
            }
            catch (Exception ex)
            {
                throw ex;
            }


            try
            {

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[2];
                ObjLocSqlParameter[0] = new SqlParameter("@rollcd", StrRollCD);
                ObjLocSqlParameter[1] = new SqlParameter("@empcd", StrHdnEmpCD);
                ObjFromEmpDet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchEmployeeDetailsForMail", ObjLocSqlParameter);
                // return ObjFromEmpDet;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[0];
                ObjSetUpDt = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchGeneralSetup", ObjLocSqlParameter);
                // return ObjSetUpDt;
            }
            catch (Exception ex)
            {
                throw ex;
            }


            for (int arCntr = 0; arCntr <= (ToEmpDt.Tables.Count - 1); arCntr++)
            {
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@rollcd", StrRollCD);
                ObjLocSqlParameter[1] = new SqlParameter("@empcd", StrHdnEmpCD);
                ObjLocSqlParameter[2] = new SqlParameter("@RequestStatus", StrRequestStatus);
                ObjToEmpDet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchEmpDetailsNEW", ObjLocSqlParameter);
                // return ObjToEmpDet;


                SqlParameter[] ObjLocSqlParameter1 = new SqlParameter[1];
                ObjLocSqlParameter1[0] = new SqlParameter("@mailid", 11);
                ObjMailFormat = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_FetchMailFormat", ObjLocSqlParameter1);
                //return ObjMailFormat;



                //Send MAil to gatepass Creater
                StrMailBody = ObjMailFormat.Tables[0].Rows[0]["MailBody"].ToString();
                StrMailSubject = ObjMailFormat.Tables[0].Rows[0]["MailSubject"].ToString();

                StrMailSubject = StrMailSubject.Replace("[MailSubject]", (GatepassID.Trim() + ("-" + StrRequestStatus.Trim())));
                ObjMg.Subject = StrMailSubject.Trim();
                string smtpfrom = ObjSetUpDt.Tables[0].Rows[0]["smtpfrom"].ToString();
                MailAddress ObjMAFrom = new MailAddress(smtpfrom);
                ObjMg.From = ObjMAFrom;
                ObjMg.To.Clear();
                ObjMg.To.Add(ObjEmpDet.Tables[0].Rows[0]["email"].ToString());
                StrMailBody = StrMailBody.Replace("[Employee Name]", ObjEmpDet.Tables[0].Rows[0]["Retailername"].ToString());

                //if (ObjToEmpDet.Tables.Count > 0)
                //{
                //    StrMailBody = StrMailBody.Replace("[To Employee Name]", ObjEmpDet.Tables[0].Rows[arCntr]["name"].ToString());
                //}
                //else
                //{
                StrMailBody = StrMailBody.Replace("[To Employee Name]", ObjFromEmpDet.Tables[0].Rows[0]["name"].ToString());
                //}
                StrMailBody = StrMailBody.Replace("[From Employee Name]", ObjEmpDet.Tables[0].Rows[0]["Retailername"].ToString());
                StrMailBody = StrMailBody.Replace("[GatepassID]", GatepassID);
                StrMailBody = StrMailBody.Replace("[Create Date]", ObjEmpDet.Tables[0].Rows[0]["Dtc"].ToString());
                StrMailBody = StrMailBody.Replace("[GatePass Type]", ObjEmpDet.Tables[0].Rows[0]["GatePassType"].ToString());
                StrMailBody = StrMailBody.Replace("[Delivery Date]", ObjEmpDet.Tables[0].Rows[0]["expecteddate"].ToString());
                StrMailBody = StrMailBody.Replace("[RequestStatus]", StrRequestStatus);
                ObjMg.Body = StrMailBody;
                SendMailFinal(ObjMg);




                //FIRST SEND MAIL TO SELF

                StrMailBody = ObjMailFormat.Tables[0].Rows[0]["MailBody"].ToString();
                StrMailSubject = ObjMailFormat.Tables[0].Rows[0]["MailSubject"].ToString();

                StrMailSubject = StrMailSubject.Replace("[MailSubject]", (GatepassID.Trim() + ("-" + StrRequestStatus.Trim())));
                ObjMg.Subject = StrMailSubject.Trim();
                smtpfrom = ObjSetUpDt.Tables[0].Rows[0]["smtpfrom"].ToString();
                ObjMAFrom = new MailAddress(smtpfrom);
                ObjMg.From = ObjMAFrom;
                ObjMg.To.Clear();
                ObjMg.To.Add(ObjFromEmpDet.Tables[0].Rows[0]["email"].ToString());
                StrMailBody = StrMailBody.Replace("[Employee Name]", ObjFromEmpDet.Tables[0].Rows[0]["name"].ToString());

                //if (ObjToEmpDet.Tables.Count > 0)
                //{
                //    StrMailBody = StrMailBody.Replace("[To Employee Name]", ObjToEmpDet.Tables[0].Rows[arCntr]["name"].ToString());
                //}
                //else
                //{
                StrMailBody = StrMailBody.Replace("[To Employee Name]", ObjFromEmpDet.Tables[0].Rows[0]["name"].ToString());
                //}
                StrMailBody = StrMailBody.Replace("[From Employee Name]", ObjEmpDet.Tables[0].Rows[0]["Retailername"].ToString());
                StrMailBody = StrMailBody.Replace("[GatepassID]", GatepassID);
                StrMailBody = StrMailBody.Replace("[Create Date]", ObjEmpDet.Tables[0].Rows[0]["Dtc"].ToString());
                StrMailBody = StrMailBody.Replace("[GatePass Type]", ObjEmpDet.Tables[0].Rows[0]["GatePassType"].ToString());
                StrMailBody = StrMailBody.Replace("[Delivery Date]", ObjEmpDet.Tables[0].Rows[0]["expecteddate"].ToString());
                StrMailBody = StrMailBody.Replace("[RequestStatus]", StrRequestStatus);
                ObjMg.Body = StrMailBody;
                SendMailFinal(ObjMg);


                //NOW SEND MAIL TO THE PERSON'S

                for (int i = 0; i <= (ObjToEmpDet.Tables.Count - 1); i++)
                {

                    StrMailBody = ObjMailFormat.Tables[0].Rows[0]["MailBody"].ToString();
                    StrMailSubject = ObjMailFormat.Tables[0].Rows[0]["MailSubject"].ToString();

                    StrMailSubject = StrMailSubject.Replace("[MailSubject]", (GatepassID.Trim() + ("-" + StrRequestStatus.Trim())));
                    ObjMg.Subject = StrMailSubject.Trim();
                    smtpfrom = ObjSetUpDt.Tables[0].Rows[0]["smtpfrom"].ToString();
                    // MailAddress ObjMAFrom = new MailAddress(smtpfrom);
                    ObjMg.From = ObjMAFrom;
                    ObjMg.To.Clear();
                    ObjMg.To.Add(ObjToEmpDet.Tables[0].Rows[i]["email"].ToString());
                    StrMailBody = StrMailBody.Replace("[Employee Name]", ObjToEmpDet.Tables[0].Rows[i]["name"].ToString());
                    StrMailBody = StrMailBody.Replace("[To Employee Name]", ObjFromEmpDet.Tables[0].Rows[0]["name"].ToString());
                    StrMailBody = StrMailBody.Replace("[From Employee Name]", ObjEmpDet.Tables[0].Rows[0]["Retailername"].ToString());
                    StrMailBody = StrMailBody.Replace("[GatepassID]", GatepassID);
                    StrMailBody = StrMailBody.Replace("[Create Date]", ObjEmpDet.Tables[0].Rows[0]["Dtc"].ToString());
                    StrMailBody = StrMailBody.Replace("[GatePass Type]", ObjEmpDet.Tables[0].Rows[0]["GatePassType"].ToString());
                    StrMailBody = StrMailBody.Replace("[Delivery Date]", ObjEmpDet.Tables[0].Rows[0]["expecteddate"].ToString());
                    StrMailBody = StrMailBody.Replace("[RequestStatus]", StrRequestStatus);
                    ObjMg.Body = StrMailBody;
                    SendMailFinal(ObjMg);


                }

            }

        }

        public void SendMailFinal(MailMessage MailMessageObj)
        {
            SmtpClient smtClient = new SmtpClient(ObjSetUpDt.Tables[0].Rows[0]["smtpserver"].ToString());
            MailMessage mail = new MailMessage();
            try
            {
                MailMessageObj.IsBodyHtml = true;
                smtClient.Port = Convert.ToInt32(ObjSetUpDt.Tables[0].Rows[0]["smtpport"]);
                smtClient.UseDefaultCredentials = false;
                smtClient.Credentials = new System.Net.NetworkCredential(ObjSetUpDt.Tables[0].Rows[0]["smtpusername"].ToString().Trim(), ObjSetUpDt.Tables[0].Rows[0]["smtppassword"].ToString().Trim());
                smtClient.EnableSsl = Convert.ToBoolean(ObjSetUpDt.Tables[0].Rows[0]["Enablessl"]);
                smtClient.Send(MailMessageObj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }





    public class WorkPermitMail
    {
        DataSet ObjSetUpDt = new DataSet();

        string StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
        public System.Data.DataSet FunFetchEmpDetail(string Strworkorderid)
        {

            // string StrLocConnection = null;
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DtLocDatatable = new DataSet();

            try
            {
                //StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[1];
                ObjLocSqlParameter[0] = new SqlParameter("@workorderID", Strworkorderid);
                DtLocDatatable = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchEmpDetailsWorkPermitMobile", ObjLocSqlParameter);
                return DtLocDatatable;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void SendMailsForWorkPermit(DataSet ToEmpDt, string lblRetailerName, string lblmobileno, string Message = " ", string WorkorderID = " ", string StrRollCD = "", string StrHdnEmpCD = "", string StrRequestStatus = "")
        {
            DataSet ObjEmpDet = new DataSet();
            DataSet ObjFromEmpDet = new DataSet();
            //DataSet ObjSetUpDt = new DataSet();
            DataSet ObjToEmpDet = new DataSet();
            DataSet ObjMailFormat = new DataSet();
            string StrMailBody = "";
            string StrMailSubject = "";
            MailMessage ObjMg = new MailMessage();



            ClsCommunication ObjLocComm = new ClsCommunication();

            try
            {

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[1];
                ObjLocSqlParameter[0] = new SqlParameter("@WorkorderID", WorkorderID);
                ObjEmpDet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchEmployeeDetailsForWorkPermitMail", ObjLocSqlParameter);
                //  return ObjEmpDet;
            }
            catch (Exception ex)
            {
                throw ex;
            }


            try
            {

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[2];
                ObjLocSqlParameter[0] = new SqlParameter("@rollcd", StrRollCD);
                ObjLocSqlParameter[1] = new SqlParameter("@empcd", StrHdnEmpCD);
                ObjFromEmpDet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchEmployeeDetailsForMail", ObjLocSqlParameter);
                // return ObjFromEmpDet;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            try
            {

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[0];
                ObjSetUpDt = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchGeneralSetup", ObjLocSqlParameter);
                // return ObjSetUpDt;
            }
            catch (Exception ex)
            {
                throw ex;
            }


            for (int arCntr = 0; arCntr <= (ToEmpDt.Tables.Count - 1); arCntr++)
            {
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@rollcd", StrRollCD);
                ObjLocSqlParameter[1] = new SqlParameter("@empcd", StrHdnEmpCD);
                ObjLocSqlParameter[2] = new SqlParameter("@RequestStatus", StrRequestStatus);
                ObjToEmpDet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchEmpDetailsNEW", ObjLocSqlParameter);
                // return ObjToEmpDet;


                SqlParameter[] ObjLocSqlParameter1 = new SqlParameter[1];
                ObjLocSqlParameter1[0] = new SqlParameter("@mailid", 12);
                ObjMailFormat = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_FetchMailFormat", ObjLocSqlParameter1);
                //return ObjMailFormat;



                //Send MAil to gatepass Creater
                StrMailBody = ObjMailFormat.Tables[0].Rows[0]["MailBody"].ToString();
                StrMailSubject = ObjMailFormat.Tables[0].Rows[0]["MailSubject"].ToString();

                StrMailSubject = StrMailSubject.Replace("[MailSubject]", (WorkorderID.Trim() + ("-" + StrRequestStatus.Trim())));
                ObjMg.Subject = StrMailSubject.Trim();
                string smtpfrom = ObjSetUpDt.Tables[0].Rows[0]["smtpfrom"].ToString();
                MailAddress ObjMAFrom = new MailAddress(smtpfrom);
                ObjMg.From = ObjMAFrom;
                ObjMg.To.Clear();
                ObjMg.To.Add(ObjEmpDet.Tables[0].Rows[0]["email"].ToString());
                StrMailBody = StrMailBody.Replace("[Employee Name]", ObjEmpDet.Tables[0].Rows[0]["Retailername"].ToString());

                //if (ObjToEmpDet.Tables.Count > 0)
                //{
                //    StrMailBody = StrMailBody.Replace("[To Employee Name]", ObjEmpDet.Tables[0].Rows[arCntr]["name"].ToString());
                //}
                //else
                //{
                StrMailBody = StrMailBody.Replace("[To Employee Name]", ObjFromEmpDet.Tables[0].Rows[0]["name"].ToString());
                //}
                StrMailBody = StrMailBody.Replace("[From Employee Name]", ObjEmpDet.Tables[0].Rows[0]["Retailername"].ToString());
                StrMailBody = StrMailBody.Replace("[WorkPermitID]", WorkorderID);
                StrMailBody = StrMailBody.Replace("[Create Date]", ObjEmpDet.Tables[0].Rows[0]["Dtc"].ToString());
                StrMailBody = StrMailBody.Replace("[Expected From Date]", ObjEmpDet.Tables[0].Rows[0]["expectedfromdate"].ToString());
                StrMailBody = StrMailBody.Replace("[Expected To Date]", ObjEmpDet.Tables[0].Rows[0]["expectedtodate"].ToString());
                StrMailBody = StrMailBody.Replace("[RequestStatus]", StrRequestStatus);
                ObjMg.Body = StrMailBody;
                SendMailFinal(ObjMg);




                //FIRST SEND MAIL TO SELF

                StrMailBody = ObjMailFormat.Tables[0].Rows[0]["MailBody"].ToString();
                StrMailSubject = ObjMailFormat.Tables[0].Rows[0]["MailSubject"].ToString();

                StrMailSubject = StrMailSubject.Replace("[MailSubject]", (WorkorderID.Trim() + ("-" + StrRequestStatus.Trim())));
                ObjMg.Subject = StrMailSubject.Trim();
                smtpfrom = ObjSetUpDt.Tables[0].Rows[0]["smtpfrom"].ToString();
                ObjMAFrom = new MailAddress(smtpfrom);
                ObjMg.From = ObjMAFrom;
                ObjMg.To.Clear();
                ObjMg.To.Add(ObjFromEmpDet.Tables[0].Rows[0]["email"].ToString());
                StrMailBody = StrMailBody.Replace("[Employee Name]", ObjFromEmpDet.Tables[0].Rows[0]["name"].ToString());

                //if (ObjToEmpDet.Tables.Count > 0)
                //{
                //    StrMailBody = StrMailBody.Replace("[To Employee Name]", ObjToEmpDet.Tables[0].Rows[arCntr]["name"].ToString());
                //}
                //else
                //{
                StrMailBody = StrMailBody.Replace("[To Employee Name]", ObjFromEmpDet.Tables[0].Rows[0]["name"].ToString());
                //}
                StrMailBody = StrMailBody.Replace("[From Employee Name]", ObjEmpDet.Tables[0].Rows[0]["Retailername"].ToString());
                StrMailBody = StrMailBody.Replace("[WorkPermitID]", WorkorderID);
                StrMailBody = StrMailBody.Replace("[Create Date]", ObjEmpDet.Tables[0].Rows[0]["Dtc"].ToString());
                StrMailBody = StrMailBody.Replace("[Expected From Date]", ObjEmpDet.Tables[0].Rows[0]["expectedfromdate"].ToString());
                StrMailBody = StrMailBody.Replace("[Expected To Date]", ObjEmpDet.Tables[0].Rows[0]["expectedtodate"].ToString());
                StrMailBody = StrMailBody.Replace("[RequestStatus]", StrRequestStatus);
                ObjMg.Body = StrMailBody;
                SendMailFinal(ObjMg);


                //NOW SEND MAIL TO THE PERSON'S

                for (int i = 0; i <= (ObjToEmpDet.Tables.Count - 1); i++)
                {

                    StrMailBody = ObjMailFormat.Tables[0].Rows[0]["MailBody"].ToString();
                    StrMailSubject = ObjMailFormat.Tables[0].Rows[0]["MailSubject"].ToString();

                    StrMailSubject = StrMailSubject.Replace("[MailSubject]", (WorkorderID.Trim() + ("-" + StrRequestStatus.Trim())));
                    ObjMg.Subject = StrMailSubject.Trim();
                    smtpfrom = ObjSetUpDt.Tables[0].Rows[0]["smtpfrom"].ToString();
                    // MailAddress ObjMAFrom = new MailAddress(smtpfrom);
                    ObjMg.From = ObjMAFrom;
                    ObjMg.To.Clear();
                    ObjMg.To.Add(ObjToEmpDet.Tables[0].Rows[i]["email"].ToString());
                    StrMailBody = StrMailBody.Replace("[Employee Name]", ObjToEmpDet.Tables[0].Rows[i]["name"].ToString());
                    StrMailBody = StrMailBody.Replace("[To Employee Name]", ObjFromEmpDet.Tables[0].Rows[0]["name"].ToString());
                    StrMailBody = StrMailBody.Replace("[From Employee Name]", ObjEmpDet.Tables[0].Rows[0]["Retailername"].ToString());
                    StrMailBody = StrMailBody.Replace("[WorkPermitID]", WorkorderID);
                    StrMailBody = StrMailBody.Replace("[Create Date]", ObjEmpDet.Tables[0].Rows[0]["Dtc"].ToString());
                    StrMailBody = StrMailBody.Replace("[Expected From Date]", ObjEmpDet.Tables[0].Rows[0]["expectedfromdate"].ToString());
                    StrMailBody = StrMailBody.Replace("[Expected To Date]", ObjEmpDet.Tables[0].Rows[0]["expectedtodate"].ToString());
                    StrMailBody = StrMailBody.Replace("[RequestStatus]", StrRequestStatus);
                    ObjMg.Body = StrMailBody;
                    SendMailFinal(ObjMg);


                }

            }

        }

        public void SendMailFinal(MailMessage MailMessageObj)
        {
            SmtpClient smtClient = new SmtpClient(ObjSetUpDt.Tables[0].Rows[0]["smtpserver"].ToString());
            MailMessage mail = new MailMessage();
            try
            {
                MailMessageObj.IsBodyHtml = true;
                smtClient.Port = Convert.ToInt32(ObjSetUpDt.Tables[0].Rows[0]["smtpport"]);
                smtClient.UseDefaultCredentials = false;
                smtClient.Credentials = new System.Net.NetworkCredential(ObjSetUpDt.Tables[0].Rows[0]["smtpusername"].ToString().Trim(), ObjSetUpDt.Tables[0].Rows[0]["smtppassword"].ToString().Trim());
                smtClient.EnableSsl = Convert.ToBoolean(ObjSetUpDt.Tables[0].Rows[0]["Enablessl"]);
                smtClient.Send(MailMessageObj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}