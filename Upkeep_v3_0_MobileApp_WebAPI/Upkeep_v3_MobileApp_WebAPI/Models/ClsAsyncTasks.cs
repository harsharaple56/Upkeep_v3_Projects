using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;


namespace Upkeep_v3_MobileApp_WebAPI.Models
{
    public static class ClsAsyncTasks
    {

        public static void AssignRequestToWorkFlow(ClsCommunication ObjLocComm, string StrLocConnection, DataSet DsLocDataSet, string StrRollCd, string StrEmpCd, double DblCategoryID, double DblSubCategoryID, string StrUnitID,
            double DblRequestID, double DblLocationID, double DblEquipmentID, string StrClientName, string StrReplyMessage, string DblDepartementId, double Dblflowid)
        {
            Task.Factory
                .StartNewOnDefaultScheduler(() =>
                {

                    DataSet DsLocDataSet2 = new DataSet();

                    for (int i = 1; i < DsLocDataSet.Tables[0].Rows.Count; i++)
                    {
                        string StrRecStatus = DsLocDataSet.Tables[0].Rows[i].Field<string>("RecStatus");
                        int DblNextLevel = DsLocDataSet.Tables[0].Rows[i].Field<Int32>("NextActionLevel");
                        int DblExpectedTime = DsLocDataSet.Tables[0].Rows[i].Field<Int32>("ExpectedTime");
                        string StrSendToRollCD = DsLocDataSet.Tables[0].Rows[i].Field<string>("SendToRollCD");
                        string StrSendToEmpCD = DsLocDataSet.Tables[0].Rows[i].Field<string>("SendToEmpCD");
                        string StrTokenNumber = DsLocDataSet.Tables[0].Rows[i].Field<string>("TokenNumber");

                        SqlParameter[] ObjLocSqlParameters = new SqlParameter[37];
                        ObjLocSqlParameters[0] = new SqlParameter("@RequestID", DblRequestID);
                        ObjLocSqlParameters[1] = new SqlParameter("@flowid", Dblflowid);
                        ObjLocSqlParameters[2] = new SqlParameter("@SubCategoryId", DblSubCategoryID);
                        ObjLocSqlParameters[3] = new SqlParameter("@CategoryId", DblCategoryID);
                        ObjLocSqlParameters[4] = new SqlParameter("@EquipmentID", DblEquipmentID);
                        ObjLocSqlParameters[5] = new SqlParameter("@ClientName", StrClientName);
                        ObjLocSqlParameters[6] = new SqlParameter("@EmpCD", StrEmpCd);
                        ObjLocSqlParameters[7] = new SqlParameter("@RollCD", StrRollCd);
                        ObjLocSqlParameters[8] = new SqlParameter("@RequestedByEmpCD", StrEmpCd);
                        ObjLocSqlParameters[9] = new SqlParameter("@RequestedByRollCD", StrRollCd);
                        ObjLocSqlParameters[10] = new SqlParameter("@UnitID", StrUnitID);
                        ObjLocSqlParameters[11] = new SqlParameter("@LocationID", DblLocationID);
                        ObjLocSqlParameters[12] = new SqlParameter("@RequestStatus", "open");
                        ObjLocSqlParameters[13] = new SqlParameter("@NextLevel", DblNextLevel);
                        ObjLocSqlParameters[14] = new SqlParameter("@RecStatus", StrRecStatus);
                        ObjLocSqlParameters[15] = new SqlParameter("@ReplyMessage", StrReplyMessage);
                        ObjLocSqlParameters[16] = new SqlParameter("@ExpectedTime", DblExpectedTime);
                        ObjLocSqlParameters[17] = new SqlParameter("@DoneByRollCd", StrRollCd);
                        ObjLocSqlParameters[18] = new SqlParameter("@DoneByEmpCd", StrEmpCd);
                        ObjLocSqlParameters[19] = new SqlParameter("@SendToRollCd", StrSendToRollCD);
                        ObjLocSqlParameters[20] = new SqlParameter("@SendToEmpCd", StrSendToEmpCD);
                        ObjLocSqlParameters[21] = new SqlParameter("@DepartmentId ", DblDepartementId);
                        ObjLocSqlParameters[22] = new SqlParameter("@Status ", "Pending");
                        ObjLocSqlParameters[23] = new SqlParameter("@Message", StrReplyMessage);
                        ObjLocSqlParameters[24] = new SqlParameter("@IsAcknowledge", "false");
                        ObjLocSqlParameters[25] = new SqlParameter("@IsCloserExpected", "false");
                        ObjLocSqlParameters[26] = new SqlParameter("@sendbit", "true");
                        ObjLocSqlParameters[27] = new SqlParameter("@Username", "admin");
                        ObjLocSqlParameters[28] = new SqlParameter("@Subject", "");
                        ObjLocSqlParameters[29] = new SqlParameter("@Priority", 1);
                        ObjLocSqlParameters[30] = new SqlParameter("@Outbit", SqlDbType.Bit, 1);
                        ObjLocSqlParameters[30].Direction = ParameterDirection.Output;
                        ObjLocSqlParameters[31] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 100);
                        ObjLocSqlParameters[31].Direction = ParameterDirection.Output;
                        ObjLocSqlParameters[32] = new SqlParameter("@OutFlowID", SqlDbType.Decimal, 100);
                        ObjLocSqlParameters[32].Direction = ParameterDirection.Output;
                        ObjLocSqlParameters[33] = new SqlParameter("@OutRequestID", SqlDbType.Decimal, 100);
                        ObjLocSqlParameters[33].Direction = ParameterDirection.Output;
                        ObjLocSqlParameters[34] = new SqlParameter("@OutFlowID2", SqlDbType.Decimal, 100);
                        ObjLocSqlParameters[34].Direction = ParameterDirection.Output;
                        ObjLocSqlParameters[35] = new SqlParameter("@ticketid", SqlDbType.VarChar, 100);
                        ObjLocSqlParameters[35].Direction = ParameterDirection.Output;
                        DsLocDataSet2 = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_SaveMyRequestv2", ObjLocSqlParameters);
                        DblRequestID = Convert.ToDouble(ObjLocSqlParameters[33].Value);
                        Dblflowid = Convert.ToDouble(ObjLocSqlParameters[34].Value);

                        string response = RestsharpAPI.SendNotification(StrTokenNumber, "Ticket ID: " + Convert.ToString(ObjLocSqlParameters[35].Value), "New request recieved","TICKET");

                    }

                    return 1;
                });

        }


        public static void SendMailsForGatePass(DataSet ToEmpDt, string lblRetailerName, string lblmobileno, string Message = " ", string GatepassID = " ", string StrRollCD = "", string StrHdnEmpCD = "", string StrRequestStatus = "")
        {
            Task.Factory.StartNewLongRunningScheduler(() =>
            {
                GatePassMail passMail = new GatePassMail();
                passMail.SendMailsForGatePass(ToEmpDt, lblRetailerName, lblmobileno, Message, GatepassID, StrRollCD, StrHdnEmpCD, StrRequestStatus);
                return 1;
            });
        }


        public static void SendMailsForWorkPermit(DataSet ToEmpDt, string lblRetailerName, string lblmobileno, string Message = " ", string WorkorderID = " ", string StrRollCD = "", string StrHdnEmpCD = "", string StrRequestStatus = "")
        {
            Task.Factory.StartNewLongRunningScheduler(() =>
            {
                WorkPermitMail passMail = new WorkPermitMail();
                passMail.SendMailsForWorkPermit(ToEmpDt, lblRetailerName, lblmobileno, Message, WorkorderID, StrRollCD, StrHdnEmpCD, StrRequestStatus);
                return 1;
            });
        }



        /// <summary>
        /// Starts the new <see cref="Task"/> from <paramref name="function"/> on the Default(usually ThreadPool) task scheduler (not on the TaskScheduler.Current).
        /// It is a 4.0 method nearly analogous to 4.5 Task.Run.
        /// </summary>
        /// <typeparam name="T">The type of the return value.</typeparam>
        /// <param name="factory">The factory to start from.</param>
        /// <param name="function">The function to execute.</param>
        /// <returns>The task representing the execution of the <paramref name="function"/>.</returns>
        public static Task<T> StartNewOnDefaultScheduler<T>(this TaskFactory factory, Func<T> function)
        {
            Contract.Requires(factory != null);
            Contract.Requires(function != null);

            return factory
                .StartNew(
                    function,
                    cancellationToken: CancellationToken.None,
                    creationOptions: TaskCreationOptions.None,
                    scheduler: TaskScheduler.Default);
        }


        /// <summary>
        /// Starts the new <see cref="Task"/> from <paramref name="function"/> on the Default(usually ThreadPool) task scheduler (not on the TaskScheduler.Current).
        /// It is a 4.0 method nearly analogous to 4.5 Task.Run.
        /// </summary>
        /// <typeparam name="T">The type of the return value.</typeparam>
        /// <param name="factory">The factory to start from.</param>
        /// <param name="function">The function to execute.</param>
        /// <returns>The task representing the execution of the <paramref name="function"/>.</returns>
        public static Task<T> StartNewLongRunningScheduler<T>(this TaskFactory factory, Func<T> function)
        {
            Contract.Requires(factory != null);
            Contract.Requires(function != null);
            return factory
                .StartNew(
                    function,
                    cancellationToken: CancellationToken.None,
                    creationOptions: TaskCreationOptions.LongRunning,
                    scheduler: TaskScheduler.Default);
        }
    }
}