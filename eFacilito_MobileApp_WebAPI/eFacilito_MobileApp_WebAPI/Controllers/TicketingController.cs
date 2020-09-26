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
    public class TicketingController : ApiController
    {
       

        #region Ticketing

        [Route("api/Ticketing/Fetch_Location_Tree")]
        [HttpGet]
        public HttpResponseMessage Fetch_Location_Tree(int CompanyID)
        {
            List<ClsGatePassRequestDetails> ObjGatePass = new List<ClsGatePassRequestDetails>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();
            DataTable dt = new DataTable();
            string StrLocConnection = null;

            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[1];
                ObjLocSqlParameter[0] = new SqlParameter("@CompanyID", CompanyID);

                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_Fetch_LocationTree", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, DsDataSet);
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
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsDataSet = null;
                ObjGatePass = null;
            }

        }

        [Route("api/Ticketing/Fetch_MyActionable_Ticket")]
        [HttpGet]
        public HttpResponseMessage Fetch_MyActionable_Ticket(int CompanyID, string EmpCD, string RollCD)
        {
            List<ClsMyActionableTicket> Objticket = new List<ClsMyActionableTicket>();
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

                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_Ticket_Fetch_MyActionable_API", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            Objticket = (from p in DsDataSet.Tables[0].AsEnumerable()
                                         select new ClsMyActionableTicket
                                         {
                                             TicketID = Convert.ToString(p.Field<decimal>("Ticket_ID")),
                                             TicketCode = p.Field<string>("Tkt_Code"),
                                             LocID = Convert.ToString(p.Field<decimal>("Loc_Id")),
                                             Loc_Desc = p.Field<string>("Loc_Desc"),
                                             CategoryID = Convert.ToString(p.Field<decimal>("Category_ID")),
                                             Category_Desc = p.Field<string>("Category_Desc"),
                                             SubCategoryID = Convert.ToString(p.Field<decimal>("SubCategory_ID")),
                                             SubCategory_Desc = p.Field<string>("SubCategory_Desc"),
                                             Ticket_Date = p.Field<string>("Ticket_Date"),
                                             Ticket_Status = p.Field<string>("Tkt_Status"),
                                             Level = Convert.ToString(p.Field<Int32>("Tkt_Level")),
                                             Ticket_ActionStatus = p.Field<string>("Tkt_ActionStatus"),
                                             Ticket_Message = p.Field<string>("Tkt_Message"),
                                             Ticket_ImagePath = p.Field<string>("ImagePath")
                                         }).ToList();

                            return Request.CreateResponse(HttpStatusCode.OK, Objticket);
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
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsDataSet = null;
                Objticket = null;
            }

        }

        [Route("api/Ticketing/Fetch_MyRequest_Ticket")]
        [HttpGet]
        public HttpResponseMessage Fetch_MyRequest_Ticket(int CompanyID, string EmpCD, string RollCD)
        {
            List<ClsMyActionableTicket> Objticket = new List<ClsMyActionableTicket>();
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

                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_Ticket_Fetch_MyRequest_API", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            Objticket = (from p in DsDataSet.Tables[0].AsEnumerable()
                                         select new ClsMyActionableTicket
                                         {
                                             TicketID = Convert.ToString(p.Field<decimal>("Ticket_ID")),
                                             TicketCode = p.Field<string>("Tkt_Code"),
                                             LocID = Convert.ToString(p.Field<decimal>("Loc_Id")),
                                             Loc_Desc = p.Field<string>("Loc_Desc"),
                                             CategoryID = Convert.ToString(p.Field<decimal>("Category_ID")),
                                             Category_Desc = p.Field<string>("Category_Desc"),
                                             SubCategoryID = Convert.ToString(p.Field<decimal>("SubCategory_ID")),
                                             SubCategory_Desc = p.Field<string>("SubCategory_Desc"),
                                             Ticket_Date = p.Field<string>("Ticket_Date"),
                                             Ticket_Status = p.Field<string>("Tkt_Status"),
                                             Level = Convert.ToString(p.Field<Int32>("Tkt_Level")),
                                             Ticket_ActionStatus = p.Field<string>("Tkt_ActionStatus"),
                                             Ticket_Message = p.Field<string>("Tkt_Message"),
                                             Ticket_ImagePath = p.Field<string>("ImagePath")
                                         }).ToList();

                            return Request.CreateResponse(HttpStatusCode.OK, Objticket);
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
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsDataSet = null;
                Objticket = null;
            }

        }

        [Route("api/Ticketing/Accept_Ticket")]
        [HttpPost]
        public HttpResponseMessage Accept_Ticket(int TicketID, string EmpCD, string RollCD)
        {
            //List<ClsMyActionableTicket> Objticket = new List<ClsMyActionableTicket>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();

            string StrLocConnection = null;
            int iStatus = 0;
            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@TicketID", TicketID);
                ObjLocSqlParameter[1] = new SqlParameter("@EmpCD", EmpCD);
                ObjLocSqlParameter[2] = new SqlParameter("@RollCD", RollCD);

                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_Accept_Ticket_API", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            iStatus = Convert.ToInt32(DsDataSet.Tables[0].Rows[0]["Status"]);
                            if (iStatus == 1)
                            {
                                return Request.CreateResponse(HttpStatusCode.OK, DsDataSet);
                            }
                            else
                            {
                                return Request.CreateResponse(HttpStatusCode.NotFound, "This ticket already accepted by other user");
                            }
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.NotFound, "No Records Found");

                        }
                    }

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
                //Objticket = null;
            }

        }


        [Route("api/Ticketing/Request_Ticket")]
        [HttpPost]
        public HttpResponseMessage Request_Ticket([FromBody] ClsTicketRaise objInsert)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();
            string TicketPrefix = string.Empty;
            string StrLocConnection = null;
            string TicketID = string.Empty;
            try
            {
                TicketPrefix = Convert.ToString(ConfigurationManager.AppSettings["TicketPrefix"]);

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[7];
                ObjLocSqlParameter[0] = new SqlParameter("@TicketPrefix", TicketPrefix);
                ObjLocSqlParameter[1] = new SqlParameter("@LocationID", objInsert.LocationID);
                ObjLocSqlParameter[2] = new SqlParameter("@CategoryID", objInsert.CategoryID);
                ObjLocSqlParameter[3] = new SqlParameter("@SubCategoryID", objInsert.SubCategoryID);
                ObjLocSqlParameter[4] = new SqlParameter("@TicketMessage", objInsert.Ticket_Message);
                //ObjLocSqlParameter[3] = new SqlParameter("@TicketImages", objInsert.Ticket_ImagePath);
                ObjLocSqlParameter[5] = new SqlParameter("@EmpCD", objInsert.EmpCD);
                ObjLocSqlParameter[6] = new SqlParameter("@RollCD", objInsert.RollCD);
                
                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_Ticket_Request_API", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            //TicketID = Convert.ToString(DsDataSet.Tables[0].Rows[0]["TicketNo"]);
                            foreach (DataRow dr in DsDataSet.Tables[0].Rows)
                            {
                                var TokenNO = Convert.ToString(dr["TokenNumber"]);
                                var TicketNo = Convert.ToString(dr["TicketNo"]);

                                FunSendAppNotification(TokenNO, TicketNo, "New Ticket Request", "TICKET");
                            }
                        }
                        if (DsDataSet.Tables[1].Rows.Count > 0)
                        {
                            TicketID = Convert.ToString(DsDataSet.Tables[1].Rows[0]["TicketNo"]);                           
                        }
                        //else
                        //{
                        //    return Request.CreateResponse(HttpStatusCode.NotFound, "No Workflow Found");
                        //}
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK, TicketID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsDataSet = null;
            }
        }

        [Route("api/Ticketing/Fetch_Ticket_Details")]
        [HttpGet]
        public HttpResponseMessage Fetch_Ticket_Details(int TicketID, int CompanyID, string EmpCD, string RollCD)
        {
            clsMasterTicketDetails ObjTicketDetailsMst = new clsMasterTicketDetails();

            List<ClsMyActionableTicket> objTickets = new List<ClsMyActionableTicket>();
            List<ClsTicketActionHistory> objTicketAction = new List<ClsTicketActionHistory>();

            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[4];
                ObjLocSqlParameter[0] = new SqlParameter("@TicketID", TicketID);
                ObjLocSqlParameter[1] = new SqlParameter("@CompanyID", CompanyID);
                ObjLocSqlParameter[2] = new SqlParameter("@EmpCD", EmpCD);
                ObjLocSqlParameter[3] = new SqlParameter("@RollCD", RollCD);

                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_Fetch_Ticket_Details_API", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            objTickets = (from p in DsDataSet.Tables[0].AsEnumerable()
                                         select new ClsMyActionableTicket
                                         {
                                             TicketID = Convert.ToString(p.Field<decimal>("Ticket_ID")),
                                             TicketCode = p.Field<string>("Tkt_Code"),
                                             LocID = Convert.ToString(p.Field<decimal>("Loc_Id")),
                                             Loc_Desc = p.Field<string>("Loc_Desc"),
                                             CategoryID = Convert.ToString(p.Field<decimal>("Category_ID")),
                                             Category_Desc = p.Field<string>("Category_Desc"),
                                             SubCategoryID = Convert.ToString(p.Field<decimal>("SubCategory_ID")),
                                             SubCategory_Desc = p.Field<string>("SubCategory_Desc"),
                                             Ticket_Date = p.Field<string>("Ticket_Date"),
                                             Ticket_Status = p.Field<string>("Tkt_Status"),
                                             Ticket_ActionStatus = p.Field<string>("Tkt_ActionStatus"),
                                             Ticket_Message = p.Field<string>("Tkt_Message"),
                                             Ticket_ImagePath = p.Field<string>("ImagePath"),
                                             Level = Convert.ToString(p.Field<decimal>("Tkt_Level"))
                                         }).ToList();

                            //return Request.CreateResponse(HttpStatusCode.OK, Objticket);
                        }

                        if (DsDataSet.Tables[1].Rows.Count > 0)
                        {
                            objTicketAction = (from p in DsDataSet.Tables[1].AsEnumerable()
                                                select new ClsTicketActionHistory
                                                {
                                                    Level = Convert.ToInt32(p.Field<decimal>("Level")),
                                                    User = Convert.ToString(p.Field<string>("User")),
                                                    Remarks = Convert.ToString(p.Field<string>("Remarks")),
                                                    ActionDateTime = Convert.ToString(p.Field<string>("ActionDate")),
                                                    ExpectedDateTime = Convert.ToString(p.Field<string>("ExpectedTime")),
                                                    Ticket_Status = Convert.ToString(p.Field<string>("TicketStatus")),
                                                    Ticket_ActionStatus = Convert.ToString(p.Field<string>("ActionStatus"))

                                                }).ToList();
                        }


                        ObjTicketDetailsMst.objTickets = objTickets;
                        ObjTicketDetailsMst.objTicketAction = objTicketAction;
                        return Request.CreateResponse(HttpStatusCode.OK, ObjTicketDetailsMst);
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
                objTicketAction = null;
            }

        }

        [Route("api/Ticketing/Update_Ticket_Action")]
        [HttpPost]
        public HttpResponseMessage Update_Ticket_Action([FromBody] ClsTicketUpdateAction objInsert)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();
            string StrLocConnection = null;
            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[6];
                ObjLocSqlParameter[0] = new SqlParameter("@TicketID", objInsert.TicketID);
                ObjLocSqlParameter[1] = new SqlParameter("@CloseTicketDesc", objInsert.CloseTicketDesc);
                ObjLocSqlParameter[2] = new SqlParameter("@TicketAction", objInsert.TicketAction);
                ObjLocSqlParameter[3] = new SqlParameter("@CurrentLevel", objInsert.CurrentLevel);
                ObjLocSqlParameter[4] = new SqlParameter("@EmpCD", objInsert.EmpCD);
                ObjLocSqlParameter[5] = new SqlParameter("@RollCD", objInsert.RollCD);
                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_Ticket_Action_API", ObjLocSqlParameter);

                //if (DsDataSet != null)
                //{
                //    if (DsDataSet.Tables.Count > 0)
                //    {
                //        if (DsDataSet.Tables[0].Rows.Count > 0)
                //        {
                //            foreach (DataRow dr in DsDataSet.Tables[0].Rows)
                //            {
                //                var TokenNO = Convert.ToString(dr["TokenNumber"]);
                //                var TicketNo = Convert.ToString(dr["TicketNo"]);

                //                FunSendAppNotification(TokenNO, TicketNo, "New Ticket Request", "TICKET");
                //            }

                //        }
                //    }
                //}

                return Request.CreateResponse(HttpStatusCode.OK, DsDataSet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsDataSet = null;
            }
        }

        [Route("api/Ticketing/Save_Ticket_Image")]
        [HttpPost]
        public HttpResponseMessage Save_Ticket_Image([FromBody] ClsTicketImage objInsert)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();
            string StrLocConnection = null;
            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {
                // Image save
                var httpRequest = HttpContext.Current.Request;
                string CurrentDate = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));
                string imgPath = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadURL"]);
                var message1 = "";
                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {
                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB  

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {
                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {

                            var message = string.Format("Please Upload a file upto 1 mb.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else
                        {
                            //var filePath = HttpContext.Current.Server.MapPath("~/FeedbackImages/" + postedFile.FileName + extension);
                            //postedFile.SaveAs(filePath);

                            string fileUploadPath = imgPath + CurrentDate;
                            if (!Directory.Exists(fileUploadPath))
                            {
                                Directory.CreateDirectory(fileUploadPath);
                            }
                            var ImageName = objInsert.TicketID;
                            //var filePath = HttpContext.Current.Server.MapPath("~/FeedbackImages/" + postedFile.FileName + extension);
                            var filePath = fileUploadPath + "/" + ImageName + extension;

                            postedFile.SaveAs(filePath);

                        }
                    }

                    message1 = string.Format("Image Updated Successfully.");
                    //return Request.CreateErrorResponse(HttpStatusCode.Created, message1); ;
                }

                // Image save


                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[5];
                ObjLocSqlParameter[0] = new SqlParameter("@TicketID", objInsert.TicketID);
                ObjLocSqlParameter[1] = new SqlParameter("@EmpCD", objInsert.EmpCD);
                ObjLocSqlParameter[2] = new SqlParameter("@RollCD", objInsert.RollCD);
                ObjLocSqlParameter[3] = new SqlParameter("@ImagePath", objInsert.Ticket_ImagePath);
                ObjLocSqlParameter[4] = new SqlParameter("@TicketFlag", objInsert.TicketFlag);

                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_Insert_Ticket_ImagePath_API", ObjLocSqlParameter);

                return Request.CreateResponse(HttpStatusCode.OK, message1);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsDataSet = null;
            }
        }


        [Route("api/Ticketing/PostTicketImage")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<HttpResponseMessage> PostTicketImage(string TicketCode, string EmpCD, string RollCD, int TicketFlag)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();
            string StrLocConnection = null;
            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {

                var httpRequest = HttpContext.Current.Request;
                string CurrentDate = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));
                string imgPath = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadURL"]);
                //string ImagePhysicalPath = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadPath"]);
                int ticketImgCount = 0;
                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB  

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {

                            var message = string.Format("Please Upload a file upto 1 mb.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else
                        {
                            //string fileUploadPath = ImagePhysicalPath + CurrentDate;
                            string fileUploadPath = HttpContext.Current.Server.MapPath("~/TicketImages/" + CurrentDate);

                            if (!Directory.Exists(fileUploadPath))
                            {
                                Directory.CreateDirectory(fileUploadPath);
                            }

                            var ImageName = TicketCode+"_"+ TicketFlag + "_"+ ticketImgCount;

                            var fileName = ImageName + extension;

                            string SaveLocation = HttpContext.Current.Server.MapPath("~/TicketImages/" + CurrentDate) + "/" + fileName;
                            string FileLocation = imgPath + "TicketImages/" + CurrentDate + "/" + fileName;

                            //var filePath = HttpContext.Current.Server.MapPath("~/FeedbackImages/" + postedFile.FileName + extension);
                            

                            postedFile.SaveAs(SaveLocation);

                            ticketImgCount = ticketImgCount + 1;

                            //string ImageURL= imgPath + "/" + ImageName + extension;

                            StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                            SqlParameter[] ObjLocSqlParameter = new SqlParameter[5];
                            ObjLocSqlParameter[0] = new SqlParameter("@TicketNo", TicketCode);
                            ObjLocSqlParameter[1] = new SqlParameter("@EmpCD", EmpCD);
                            ObjLocSqlParameter[2] = new SqlParameter("@RollCD", RollCD);
                            ObjLocSqlParameter[3] = new SqlParameter("@ImagePath", FileLocation);
                            ObjLocSqlParameter[4] = new SqlParameter("@TicketFlag", TicketFlag);

                            DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_Insert_Ticket_ImagePath_API", ObjLocSqlParameter);

                            return Request.CreateResponse(HttpStatusCode.OK);

                        }
                    }

                    var message1 = string.Format("Image Updated Successfully.");
                    return Request.CreateErrorResponse(HttpStatusCode.Created, message1); ;
                }
                var res = string.Format("Please Upload a image.");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
            catch (Exception ex)
            {
                var res = string.Format("some Message");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
        }


        [Route("api/Ticketing/Fetch_Ticket_Workflow")]
        [HttpGet]
        public HttpResponseMessage Fetch_Ticket_Workflow(int CategoryID, int SubCategoryID)
        {
            List<ClsTicketWorkflow> Objticket = new List<ClsTicketWorkflow>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[2];
                ObjLocSqlParameter[0] = new SqlParameter("@CategoryID", CategoryID);
                ObjLocSqlParameter[1] = new SqlParameter("@SubCategoryID", SubCategoryID);

                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_TKT_Fetch_Workflow_API", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            Objticket = (from p in DsDataSet.Tables[0].AsEnumerable()
                                         select new ClsTicketWorkflow
                                         {
                                             Level = Convert.ToString(p.Field<decimal>("Level")),
                                             User_Desc = p.Field<string>("UserDescription"),
                                             Group_Desc = p.Field<string>("GroupDescription"),
                                             Escalate_Time = Convert.ToString(p.Field<decimal>("EscalateTime"))

                                         }).ToList();

                            return Request.CreateResponse(HttpStatusCode.OK, Objticket);
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
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsDataSet = null;
                Objticket = null;
            }

        }

        [Route("api/Ticketing/Validate_Company")]
        [HttpGet]
        public HttpResponseMessage Validate_Company(string CompanyCode)
        {
            List<ClsValidateCompany> ObjCompany = new List<ClsValidateCompany>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["eFacilitoCC_Con"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[1];
                ObjLocSqlParameter[0] = new SqlParameter("@CompanyCode", CompanyCode);


                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_ValidateCompany", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjCompany = (from p in DsDataSet.Tables[0].AsEnumerable()
                                          select new ClsValidateCompany
                                          {
                                              Status = Convert.ToInt32(p.Field<string>("Status")),
                                              CompanyID = Convert.ToInt32(p.Field<decimal>("Company_ID")),
                                              CompanyName = Convert.ToString(p.Field<string>("Company_Name")),
                                              Client_URL = Convert.ToString(p.Field<string>("ClientURL")),
                                              Module_ID = Convert.ToString(p.Field<string>("Module_ID"))

                                          }).ToList();

                            return Request.CreateResponse(HttpStatusCode.OK, ObjCompany);
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
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsDataSet = null;
                ObjCompany = null;
            }

        }

        [HttpGet]
        public string FunSendAppNotification(string StrTokenNumber, string TicketNo, string StrMessage, string click_action)
        {
            string response = RestsharpAPI.SendNotification(StrTokenNumber, "Ticket ID: " + TicketNo, StrMessage, click_action);
            return response;
        }

        [Route("api/Ticketing/Fetch_Ticket_SubCategory_Department")]
        [HttpGet]
        public HttpResponseMessage Fetch_Ticket_SubCategory_Department(int CategoryID)
        {
            clsSubCate_DeptMst ObjSubCate_DeptMst = new clsSubCate_DeptMst();

            List<ClsSubCategory> objSubCategory = new List<ClsSubCategory>();
            List<ClsDepartmentName> objDepartment = new List<ClsDepartmentName>();

            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[1];
                ObjLocSqlParameter[0] = new SqlParameter("@CategoryID", CategoryID);
              

                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_Fetch_Ticket_SubCategory_Department_API", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            objSubCategory = (from p in DsDataSet.Tables[0].AsEnumerable()
                                          select new ClsSubCategory
                                          {
                                              SubCategoryID = Convert.ToInt32(p.Field<decimal>("SubCategory_ID")),
                                              CategoryName = Convert.ToString(p.Field<string>("SubCategory_Desc"))
                                             
                                          }).ToList();

                            //return Request.CreateResponse(HttpStatusCode.OK, Objticket);
                        }

                        if (DsDataSet.Tables[1].Rows.Count > 0)
                        {
                            objDepartment = (from p in DsDataSet.Tables[1].AsEnumerable()
                                               select new ClsDepartmentName
                                               {
                                                   DepartmentID = Convert.ToInt32(p.Field<decimal>("Department_ID")),
                                                   DepartmentName = Convert.ToString(p.Field<string>("Dept_Desc"))

                                               }).ToList();
                        }


                        ObjSubCate_DeptMst.objSubCategory = objSubCategory;
                        ObjSubCate_DeptMst.objDepartmentName = objDepartment;
                        return Request.CreateResponse(HttpStatusCode.OK, ObjSubCate_DeptMst);
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
                objSubCategory = null;
                objDepartment = null;
            }

        }

        [Route("api/Ticketing/Fetch_Ticket_Dashboard_Count")]
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

        #endregion




    }
}