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
using System.Threading.Tasks;
using System.IO;
namespace eFacilito_MobileApp_WebAPI.Controllers
{
    public class DashboardController : ApiController
    {

        // GET: Dashboard Data for Ticketing

        [Route("api/Dashboard/Fetch_Ticket_Dashboard_Count")]
        [HttpGet]
        public HttpResponseMessage Fetch_Ticket_Dashboard_Count(int CompanyID, string EmpCD, string RollCD, string FromDate, string ToDate)
        {
            List<ClsTicketDashboard> objTickets = new List<ClsTicketDashboard>();

            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[5];

                ObjLocSqlParameter[0] = new SqlParameter("@CompanyID", CompanyID);
                ObjLocSqlParameter[1] = new SqlParameter("@EmpCD", EmpCD);
                ObjLocSqlParameter[2] = new SqlParameter("@RollCD", RollCD);
                ObjLocSqlParameter[3] = new SqlParameter("@FromDate", FromDate);
                ObjLocSqlParameter[4] = new SqlParameter("@ToDate", ToDate);


                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_Fetch_Dashboard_Count_API", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            objTickets = (from p in DsDataSet.Tables[0].AsEnumerable()
                                          select new ClsTicketDashboard
                                          {
                                              AssignedTicket = Convert.ToInt32(p.Field<int>("AssignedTicketCount")),
                                              AcceptedTicket = Convert.ToInt32(p.Field<int>("AcceptedTicketCount")),
                                              InProgressTicket = Convert.ToInt32(p.Field<int>("InProgressTicketCount")),
                                              HoldTicket = Convert.ToInt32(p.Field<int>("HoldTicketCount")),
                                              OpenTicket = Convert.ToInt32(p.Field<int>("OpenTicketCount")),
                                              ClosedTicket = Convert.ToInt32(p.Field<int>("TicketClosedCount")),
                                              ExpiredTicket = Convert.ToInt32(p.Field<int>("ExpiredTicketCount")),
                                              TotalTicket = Convert.ToInt32(p.Field<int>("TotalTicketCount")),
                                              ClosedTicketPercentage = Convert.ToDecimal(p.Field<decimal>("ClosedTicketPercentage"))

                                          }).ToList();

                            return Request.CreateResponse(HttpStatusCode.OK, objTickets);
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
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsDataSet = null;
                objTickets = null;
                //objTicketAction = null;
            }

        }


        // GET: Dashboard Data for Gatepass

        [Route("api/Dashboard/Fetch_Gatepass_Dashboard_Count")]
        [HttpGet]
        public HttpResponseMessage Fetch_Gatepass_Dashboard_Count(int CompanyID, string EmpCD, string RollCD, string FromDate, string ToDate)
        {
            
            List<ClsGatepassDashboard> objGatepass = new List<ClsGatepassDashboard>();

            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[5];

                ObjLocSqlParameter[0] = new SqlParameter("@CompanyID", CompanyID);
                ObjLocSqlParameter[1] = new SqlParameter("@EmpCD", EmpCD);
                ObjLocSqlParameter[2] = new SqlParameter("@RollCD", RollCD);
                ObjLocSqlParameter[3] = new SqlParameter("@FromDate", FromDate);
                ObjLocSqlParameter[4] = new SqlParameter("@ToDate", ToDate);


                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_Fetch_Dashboard_Gatepass_Count_API", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            objGatepass = (from p in DsDataSet.Tables[0].AsEnumerable()
                                          select new ClsGatepassDashboard
                                          {
                                              Total_Open=Convert.ToInt32(p.Field<int>("OpenCount")),
                                              InProgress = Convert.ToInt32(p.Field<int>("InProgressCount")),
                                              OnHold = Convert.ToInt32(p.Field<int>("OnHoldCount")),
                                              Approved = Convert.ToInt32(p.Field<int>("ApprovedCount")),
                                              Rejected = Convert.ToInt32(p.Field<int>("RejectedCount")),
                                              Expired = Convert.ToInt32(p.Field<int>("ExpiredCount")),
                                              PendingPercentage = Convert.ToDecimal(p.Field<decimal>("PendingPercentage")),
                                              Total = Convert.ToInt32(p.Field<int>("TotalCount")),
                                              Closed = Convert.ToInt32(p.Field<int>("ClosedCount")),
                                              PendingApprovals = Convert.ToInt32(p.Field<int>("PendingApprovalsCount"))

                                          }).ToList();

                            return Request.CreateResponse(HttpStatusCode.OK, objGatepass);
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
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsDataSet = null;
                objGatepass = null;
                //objTicketAction = null;
            }

        }


        // GET: Dashboard Data for Gatepass

        [Route("api/Dashboard/Fetch_Workpermit_Dashboard_Count")]
        [HttpGet]
        public HttpResponseMessage Fetch_Workpermit_Dashboard_Count(int CompanyID, string EmpCD, string RollCD, string FromDate, string ToDate)
        {
            
            List<ClsWorkpermitDashboard> objWorkpermit = new List<ClsWorkpermitDashboard>();

            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[5];

                ObjLocSqlParameter[0] = new SqlParameter("@CompanyID", CompanyID);
                ObjLocSqlParameter[1] = new SqlParameter("@EmpCD", EmpCD);
                ObjLocSqlParameter[2] = new SqlParameter("@RollCD", RollCD);
                ObjLocSqlParameter[3] = new SqlParameter("@FromDate", FromDate);
                ObjLocSqlParameter[4] = new SqlParameter("@ToDate", ToDate);


                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_Fetch_Dashboard_Workpermit_Count_API", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            objWorkpermit = (from p in DsDataSet.Tables[0].AsEnumerable()
                                           select new ClsWorkpermitDashboard
                                           {
                                               InProgress = Convert.ToInt32(p.Field<int>("InProgressCount")),
                                               OnHold = Convert.ToInt32(p.Field<int>("OnHoldCount")),
                                               Approved = Convert.ToInt32(p.Field<int>("ApprovedCount")),
                                               Rejected = Convert.ToInt32(p.Field<int>("RejectedCount")),
                                               Expired = Convert.ToInt32(p.Field<int>("ExpiredCount")),
                                               PendingPercentage = Convert.ToDecimal(p.Field<decimal>("PendingPercentage")),
                                               Total = Convert.ToInt32(p.Field<int>("TotalCount")),
                                               Closed = Convert.ToInt32(p.Field<int>("ClosedCount")),
                                               PendingApprovals = Convert.ToInt32(p.Field<int>("PendingApprovalsCount"))


                                           }).ToList();

                            return Request.CreateResponse(HttpStatusCode.OK, objWorkpermit);
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
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsDataSet = null;
                objWorkpermit = null;
                //objTicketAction = null;
            }

        }


        // GET: Dashboard Data for Checklist

        [Route("api/Dashboard/Fetch_Checklist_Dashboard_Count")]
        [HttpGet]
        public HttpResponseMessage Fetch_Checklist_Dashboard_Count(int CompanyID, string EmpCD, string RollCD, string FromDate, string ToDate)
        {

            
            List<ClsChecklistsDashboard> objChecklist = new List<ClsChecklistsDashboard>();

            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[5];

                ObjLocSqlParameter[0] = new SqlParameter("@CompanyID", CompanyID);
                ObjLocSqlParameter[1] = new SqlParameter("@EmpCD", EmpCD);
                ObjLocSqlParameter[2] = new SqlParameter("@RollCD", RollCD);
                ObjLocSqlParameter[3] = new SqlParameter("@FromDate", FromDate);
                ObjLocSqlParameter[4] = new SqlParameter("@ToDate", ToDate);


                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_Fetch_Dashboard_Checklist_Count_API", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            
                            objChecklist = (from p in DsDataSet.Tables[0].AsEnumerable()
                                             select new ClsChecklistsDashboard
                                             {
                                                 AvailableDeptChk = Convert.ToInt32(p.Field<int>("AvailableDeptChkCount")),
                                                 Pending = Convert.ToInt32(p.Field<int>("PendingCount")),
                                                 Closed = Convert.ToInt32(p.Field<int>("ClosedCount")),
                                                 Total = Convert.ToInt32(p.Field<int>("TotalCount")),
                                                 PendingChkPercentage = Convert.ToDecimal(p.Field<decimal>("PendingChkPercentage"))

                                             }).ToList();

                            return Request.CreateResponse(HttpStatusCode.OK, objChecklist);
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
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsDataSet = null;
                objChecklist = null;
                //objTicketAction = null;
            }

        }


        // GET: Fetch User Profile Data

        [Route("api/Dashboard/Fetch_Profile")]
        [HttpGet]
        public HttpResponseMessage Fetch_Profile(int CompanyID, string EmpCD, string RollCD)
        {
            List<ClsProfile> objProfile = new List<ClsProfile>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@CompanyID", CompanyID);
                ObjLocSqlParameter[1] = new SqlParameter("@EmpCD", EmpCD);
                ObjLocSqlParameter[2] = new SqlParameter("@RollCD", RollCD);


                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_Fetch_User_Profile_Details_Api", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {

                            objProfile = (from p in DsDataSet.Tables[0].AsEnumerable()
                                          select new ClsProfile
                                          {
                                              User_Code = Convert.ToString(p.Field<string>("User_Code")),
                                              ProfileName = Convert.ToString(p.Field<string>("ProfileName")),
                                              User_Mobile = Convert.ToString(p.Field<string>("User_Mobile")),
                                              User_Designation = Convert.ToString(p.Field<string>("User_Designation")),
                                              User_Email = Convert.ToString(p.Field<string>("User_Email")),
                                              Login_ID = Convert.ToString(p.Field<string>("Login_ID")),
                                              Address = Convert.ToString(p.Field<string>("Address")),
                                              City = Convert.ToString(p.Field<string>("City")),
                                              State = Convert.ToString(p.Field<string>("State")),
                                              Postcode = Convert.ToInt32(p.Field<int>("Postcode")),
                                              Company_Code = Convert.ToString(p.Field<string>("Company_Code")),
                                              Role_Name = Convert.ToString(p.Field<string>("Role_Name")),
                                              Reporting_Manager = Convert.ToString(p.Field<string>("ReportingManager")),
                                              ProfilePhoto = Convert.ToString(p.Field<string>("Profile_Photo")),
                                              Company_Name = Convert.ToString(p.Field<string>("Company_Desc")),

                                          }).ToList();

                            return Request.CreateResponse(HttpStatusCode.OK, objProfile);
                            //return Request.CreateResponse(HttpStatusCode.OK, DsDataSet);
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
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsDataSet = null;
                objProfile = null;
                //objTicketAction = null;
            }

        }


    }
}