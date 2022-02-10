using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using eFacilito_MobileApp_WebAPI.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Text;
using System.IO;

namespace eFacilito_MobileApp_WebAPI.Controllers
{
    public class FeedbackController : ApiController
    {

        [HttpGet]
        public HttpResponseMessage GetEventList(string eventType, int CompanyID)
        {
            List<ClsEvent> ObjEventList = new List<ClsEvent>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsEventDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[2];
                ObjLocSqlParameter[0] = new SqlParameter("@eventType", eventType);
                ObjLocSqlParameter[1] = new SqlParameter("@CompanyID", CompanyID);

                DsEventDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Feedback_Proc_Get_EventList", ObjLocSqlParameter);

                if (DsEventDataSet != null)
                {
                    if (DsEventDataSet.Tables.Count > 0)
                    {
                        if (DsEventDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjEventList = (from p in DsEventDataSet.Tables[0].AsEnumerable()
                                            select new ClsEvent
                                            {
                                                Event_ID = Convert.ToString(p.Field<int>("Event_ID")),
                                                Event_Name = p.Field<string>("Event_Name"),
                                                Start_Date = p.Field<string>("Start_Date"),
                                                Expiry_Date = p.Field<string>("Expiry_Date")

                                            }).ToList();
                            //return ObjEventList;
                            return Request.CreateResponse(HttpStatusCode.OK, ObjEventList);
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.NotFound, "No Records Found");
                            //return ObjRetailer;
                        }
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "No Records Found");
                        //return ObjEventList;
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No Records Found");
                    //return ObjEventList;
                }
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsEventDataSet = null;
                ObjEventList = null;
            }

        }

        [HttpGet]
        public HttpResponseMessage GetEventList_V2(string eventType, int CompanyID)
        {
            List<ClsEvent_V2> ObjEventList = new List<ClsEvent_V2>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsEventDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[2];
                ObjLocSqlParameter[0] = new SqlParameter("@eventType", eventType);
                ObjLocSqlParameter[1] = new SqlParameter("@CompanyID", CompanyID);

                DsEventDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Feedback_Proc_Get_EventList", ObjLocSqlParameter);

                if (DsEventDataSet != null)
                {
                    if (DsEventDataSet.Tables.Count > 0)
                    {
                        if (DsEventDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjEventList = (from p in DsEventDataSet.Tables[0].AsEnumerable()
                                            select new ClsEvent_V2
                                            {
                                                Event_ID = Convert.ToString(p.Field<int>("Event_ID")),
                                                Event_Name = p.Field<string>("Event_Name"),
                                                Start_Date = p.Field<string>("Start_Date"),
                                                Expiry_Date = p.Field<string>("Expiry_Date"),
                                                Is_Fname_Mandatory = Convert.ToInt32(p.Field<Boolean>("Is_Fname_Mandatory")),
                                                Is_Lname_Mandatory = Convert.ToInt32(p.Field<Boolean>("Is_Lname_Mandatory")),
                                                Is_Contact_Manadatoy = Convert.ToInt32(p.Field<Boolean>("Is_Contact_Manadatoy")),
                                                Is_Email_Manadatoy = Convert.ToInt32(p.Field<Boolean>("Is_Email_Manadatoy")),
                                                Is_Gender_Manadatoy = Convert.ToInt32(p.Field<Boolean>("Is_Gender_Manadatoy"))

                                            }).ToList();
                            //return ObjEventList;
                            return Request.CreateResponse(HttpStatusCode.OK, ObjEventList);
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.NotFound, "No Records Found");
                            //return ObjRetailer;
                        }
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "No Records Found");
                        //return ObjEventList;
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No Records Found");
                    //return ObjEventList;
                }
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsEventDataSet = null;
                ObjEventList = null;
            }

        }


        [HttpGet]

        public HttpResponseMessage Fetch_RetailerList(int CompanyID)
        {
            List<ClsFetchRetailers> ObjRetailer = new List<ClsFetchRetailers>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsRetailerDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                
                ObjLocSqlParameter[1] = new SqlParameter("@CompanyID", CompanyID);

                DsRetailerDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Fetch_Retailers_List", ObjLocSqlParameter);

                if (DsRetailerDataSet != null)
                {
                    if (DsRetailerDataSet.Tables.Count > 0)
                    {
                        if (DsRetailerDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjRetailer = (from p in DsRetailerDataSet.Tables[0].AsEnumerable()
                                           select new ClsFetchRetailers
                                           {
                                               Retailer_ID = p.Field<int>("Retailer_ID"),
                                               Store_Name = p.Field<string>("Store_Name"),
                                               Store_No = p.Field<string>("Store_No"),

                                           }).ToList();
                            //return ObjRetailer;
                            return Request.CreateResponse(HttpStatusCode.OK, ObjRetailer);
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.NotFound, "No Records Found");
                            //return ObjRetailer;
                        }
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "No Records Found");
                        //return ObjRetailer;
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No Records Found");
                    //return ObjRetailer;
                }
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsRetailerDataSet = null;
                ObjRetailer = null;
            }

        }


        public HttpResponseMessage Fetch_RetailerDetails(string storeName, int CompanyID)
        {
            List<ClsRetailer> ObjRetailer = new List<ClsRetailer>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsRetailerDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[2];
                ObjLocSqlParameter[0] = new SqlParameter("@storeName", storeName);
                ObjLocSqlParameter[1] = new SqlParameter("@CompanyID", CompanyID);

                DsRetailerDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Feedback_Proc_Get_RetailerDetails", ObjLocSqlParameter);

                if (DsRetailerDataSet != null)
                {
                    if (DsRetailerDataSet.Tables.Count > 0)
                    {
                        if (DsRetailerDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjRetailer = (from p in DsRetailerDataSet.Tables[0].AsEnumerable()
                                           select new ClsRetailer
                                           {
                                               Retailer_ID = Convert.ToString(p.Field<int>("UserID")),
                                               Manager_Name = p.Field<string>("Name"),
                                               Store_Name = p.Field<string>("Store_Name"),
                                               PhoneNo = Convert.ToString(p.Field<decimal>("PhoneNo")),
                                               EmailID = p.Field<string>("EmailID")
                                           }).ToList();
                            //return ObjRetailer;
                            return Request.CreateResponse(HttpStatusCode.OK, ObjRetailer);
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.NotFound, "No Records Found");
                            //return ObjRetailer;
                        }
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "No Records Found");
                        //return ObjRetailer;
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No Records Found");
                    //return ObjRetailer;
                }
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsRetailerDataSet = null;
                ObjRetailer = null;
            }

        }

        [HttpGet]
        public HttpResponseMessage Fetch_FeedbackQuestions(string EventID)
        {
            List<ClsFeedbackQuestions> ObjFeedbackQuestions = new List<ClsFeedbackQuestions>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[1];
                ObjLocSqlParameter[0] = new SqlParameter("@EventID", EventID);

                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Feedback_Proc_Get_FeedbackQuestions", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjFeedbackQuestions = (from p in DsDataSet.Tables[0].AsEnumerable()
                                                    select new ClsFeedbackQuestions
                                                    {
                                                        Event_ID = Convert.ToString(p.Field<int>("Event_ID")),
                                                        Question_ID = Convert.ToString(p.Field<int>("Question_ID")),
                                                        Question = p.Field<string>("Question"),
                                                        Answer_Type = p.Field<string>("Answer_Type"),
                                                        Option1 = p.Field<string>("Option1"),
                                                        Option2 = p.Field<string>("Option2"),
                                                        Option3 = p.Field<string>("Option3"),
                                                        Option4 = p.Field<string>("Option4")
                                                    }).ToList();
                            //return ObjRetailer;
                            return Request.CreateResponse(HttpStatusCode.OK, ObjFeedbackQuestions);
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.NotFound, "No Records Found");
                            //return ObjRetailer;
                        }
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "No Records Found");
                        //return ObjRetailer;
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No Records Found");
                    //return ObjRetailer;
                }
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsDataSet = null;
                ObjFeedbackQuestions = null;
            }

        }

        [Route("api/Feedback/Insert_UserFeedback")]
        [HttpPost]
        public HttpResponseMessage Insert_UserFeedback(List<ClsInsertFeedback> objInsert)
        {
            List<ClsFeedbackQuestions> ObjFeedback = new List<ClsFeedbackQuestions>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                Random random = new Random();
                string strRandomNo = string.Empty;
                strRandomNo = random.Next(0, 999999999).ToString("D9");
               
                foreach (ClsInsertFeedback item in objInsert)
                {
                    item.RandomNo = strRandomNo;
                    SqlParameter[] ObjLocSqlParameter = new SqlParameter[6];
                    ObjLocSqlParameter[0] = new SqlParameter("@UserID", item.UserID);
                    ObjLocSqlParameter[1] = new SqlParameter("@LoggedInUserID", item.LoggedInUserID);
                    ObjLocSqlParameter[2] = new SqlParameter("@EventID", item.EventID);
                    ObjLocSqlParameter[3] = new SqlParameter("@QuestionID", item.QuestionID);
                    ObjLocSqlParameter[4] = new SqlParameter("@Answer", item.Answer);
                    ObjLocSqlParameter[5] = new SqlParameter("@FeedbackNo", item.RandomNo);

                    ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Feedback_Proc_Feedback_Insert", ObjLocSqlParameter);

                }
                return Request.CreateResponse(HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsDataSet = null;
                ObjFeedback = null;
            }

        }

        [Route("api/Feedback/Insert_CustomerDetails")]
        [HttpPost]
        public HttpResponseMessage Insert_CustomerDetails([FromBody] ClsCustomer objInsertCustomer)
        {
            List<ClsCustomer> ObjFeedbackCustomer = new List<ClsCustomer>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();

            string StrLocConnection = null;
            //int UserID = 0;

            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[7];
                ObjLocSqlParameter[0] = new SqlParameter("@firstName", objInsertCustomer.firstName);
                ObjLocSqlParameter[1] = new SqlParameter("@lastName", objInsertCustomer.lastName);
                ObjLocSqlParameter[2] = new SqlParameter("@phoneNo", objInsertCustomer.phoneNo);
                ObjLocSqlParameter[3] = new SqlParameter("@emailID", objInsertCustomer.emailID);
                ObjLocSqlParameter[4] = new SqlParameter("@gender", objInsertCustomer.gender);
                //ObjLocSqlParameter[5] = new SqlParameter("@imagePath", objInsertCustomer.imagePath);
                ObjLocSqlParameter[5] = new SqlParameter("@LoggedInUserID", objInsertCustomer.LoggedInUserID);
                ObjLocSqlParameter[6] = new SqlParameter("@CompanyID", objInsertCustomer.CompanyID);

                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Feedback_Proc_Insert_CustomerDetails", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            //UserID = Convert.ToInt32(DsDataSet.Tables[0].Rows[0]["UserID"]);
                            //Update_CustomerImage(objInsertCustomer.ImageString, UserID);
                            return Request.CreateResponse(HttpStatusCode.OK, DsDataSet.Tables[0]);
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.NotFound, "No Records Found");
                        }
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "No Records Found");
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No Records Found");
                }
                //return Request.CreateResponse(HttpStatusCode.OK, DsDataSet);
                //return Request.CreateResponse(HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsDataSet = null;
                ObjFeedbackCustomer = null;
            }

        }

        // [HttpPost]
        [Route("api/Feedback/Update_CustomerImage")]
        [HttpPost]
        public HttpResponseMessage Update_CustomerImage([FromBody] ClsCustomerImage objCustomer)
        {
            try
            {
                string ImgString = Convert.ToString(objCustomer.ImageString);
                byte[] imageBytes = Convert.FromBase64String(ImgString);

                string ServerPath = Convert.ToString(ConfigurationManager.AppSettings["ServerPath"]) + objCustomer.UserID + ".jpg";

                string filePath = HttpContext.Current.Server.MapPath("~/FeedbackImages/" + objCustomer.UserID + ".jpg");
                //string filePath = HttpContext.Current.Server.MapPath(ServerPath);

                File.WriteAllBytes(filePath, imageBytes);

                List<ClsCustomer> ObjFeedbackCustomer = new List<ClsCustomer>();
                ClsCommunication ObjLocComm = new ClsCommunication();
                DataSet dsUpdateCustomer = new DataSet();

                string StrLocConnection = null;
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[2];
                ObjLocSqlParameter[0] = new SqlParameter("@filePath", ServerPath);
                ObjLocSqlParameter[1] = new SqlParameter("@UserID", objCustomer.UserID);

                dsUpdateCustomer = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Feedback_Proc_Update_CustomerImage", ObjLocSqlParameter);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}