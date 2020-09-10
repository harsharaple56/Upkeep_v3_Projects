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
    public class UpKeepController : ApiController
    {
        #region "Master"
        /// <summary>
        /// Function is used to fetch Group Masters
        /// </summary>
        /// <param name="StrGroupID"></param>
        /// <param name="StrGroupDesc"></param>
        /// <param name="StrUsername"></param>
        /// <param name="StrActioType"></param>
        /// <returns></returns>

        [HttpGet]
        public List<ClsGroupMaster> FunPubFetchGroupMaster(string StrGroupID, string StrGroupDesc, string StrUsername)
        {
            List<ClsGroupMaster> ObjLocGroupList = new List<ClsGroupMaster>();
            ClsCommunication objLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;
            try
            {
                if (StrGroupID == null)
                    StrGroupID = "0";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);


                SqlParameter[] ObjLocSqlParameter = new SqlParameter[1];
                ObjLocSqlParameter[0] = new SqlParameter("@GroupId", StrGroupID);

                DsLocDataSet = objLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchGroupMst", ObjLocSqlParameter);

                if ((DsLocDataSet != null))
                {
                    if (DsLocDataSet.Tables[0].Rows.Count > 0)
                    {
                        ObjLocGroupList = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                           select new ClsGroupMaster
                                           {
                                               ProPubStrGroupId = Convert.ToString(p.Field<decimal>("GroupId")),
                                               ProPubStrGroupDesc = p.Field<string>("GroupDesc"),

                                           }).ToList();
                        return ObjLocGroupList;
                    }
                    else
                    {
                        return ObjLocGroupList;
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
                DsLocDataSet = null;
                ObjLocGroupList = null;
            }


        }

        /// <summary>
        /// Function is used to Save & Edit Group Masters
        /// </summary>
        /// <param name="StrGroupID"></param>
        /// <param name="StrGroupDesc"></param>
        /// <param name="StrUsername"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubSaveEditGroupMaster(string StrGroupID, string StrGroupDesc, string StrUsername)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (StrGroupID == null)
                    StrGroupID = "0";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[5];
                ObjLocSqlParameter[0] = new SqlParameter("@GroupId", StrGroupID);
                ObjLocSqlParameter[1] = new SqlParameter("@GroupDesc", StrGroupDesc);
                ObjLocSqlParameter[2] = new SqlParameter("@Username", StrUsername);
                ObjLocSqlParameter[3] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[3].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[4] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[4].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_SaveGroupMst", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[4].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }


        /// <summary>
        /// Function is used to Delete Group Masters
        /// </summary>
        /// <param name="StrGroupID"></param>
        /// <param name="StrGroupDesc"></param>
        /// <param name="StrUsername"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubDeleteGroupMaster(string StrGroupID)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (StrGroupID == null)
                    StrGroupID = "0";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[1];
                ObjLocSqlParameter[0] = new SqlParameter("@GroupId", StrGroupID);
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_DeleteGroupMst", ObjLocSqlParameter);

                return "GroupMaster Delete Succesfully.";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }
        /// <summary>
        /// Function is used to fetch Company Masters
        /// </summary>
        /// <param name="StrGroupID"></param>
        /// <param name="StrCompanyId"></param>
        /// <param name="StrCompanyDesc"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ClsCompanyMaster> FunPubFetchCompanyMst(string StrGroupID, string StrCompanyId, string StrCompanyDesc)
        {
            List<ClsCompanyMaster> ObjLocCompanyList = new List<ClsCompanyMaster>();
            ClsCommunication objLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;
            try
            {
                if (StrGroupID == null)
                    StrGroupID = "0";
                if (StrCompanyId == null)
                    StrCompanyId = "0";
                if (StrCompanyDesc == null)
                    StrCompanyDesc = "";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@GroupId", StrGroupID);
                ObjLocSqlParameter[1] = new SqlParameter("@CompanyId", StrCompanyId);
                ObjLocSqlParameter[2] = new SqlParameter("@CompanyDesc", StrCompanyDesc);
                DsLocDataSet = objLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchCompanyMst", ObjLocSqlParameter);

                if ((DsLocDataSet != null))
                {
                    if (DsLocDataSet.Tables[0].Rows.Count > 0)
                    {
                        ObjLocCompanyList = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                             select new ClsCompanyMaster
                                             {
                                                 ProPubStrGroupId = Convert.ToString(p.Field<decimal>("GroupId")),
                                                 ProPubStrGroupDesc = p.Field<string>("GroupDesc"),
                                                 ProPubStrAddress = p.Field<string>("Address"),
                                                 ProPubStrCompanyCode = p.Field<string>("CompanyCode"),
                                                 ProPubStrCompanyId = Convert.ToString(p.Field<decimal>("CompanyId")),
                                                 ProPubStrCompanyDesc = p.Field<string>("CompanyDesc")

                                             }).ToList();
                        return ObjLocCompanyList;
                    }
                    else
                    {
                        return ObjLocCompanyList;
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
                DsLocDataSet = null;
                ObjLocCompanyList = null;
            }


        }
        /// <summary>
        /// Function is used to Save & Edit Company Masters
        /// </summary>
        /// <param name="StrGroupID"></param>
        /// <param name="StrCompanyId"></param>
        /// <param name="StrCompanyDesc"></param>
        /// <param name="StrAddress"></param>
        /// <param name="StrCompanyCode"></param>
        /// <param name="StrUsername"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubSaveEditCompanyMst(string StrGroupID, string StrCompanyId, string StrAddress, string StrUsername, string StrCompanyDesc, string StrCompanyCode)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (StrGroupID == null)
                    StrGroupID = "0";
                if (StrCompanyId == null)
                    StrCompanyId = "0";
                if (StrCompanyDesc == null)
                    StrCompanyDesc = "";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[8];
                ObjLocSqlParameter[0] = new SqlParameter("@CompanyId", StrCompanyId);
                ObjLocSqlParameter[1] = new SqlParameter("@companydesc", StrCompanyDesc);
                ObjLocSqlParameter[2] = new SqlParameter("@Address", StrAddress);
                ObjLocSqlParameter[3] = new SqlParameter("@companycode", StrCompanyCode);
                ObjLocSqlParameter[4] = new SqlParameter("@GroupID", StrGroupID);
                ObjLocSqlParameter[5] = new SqlParameter("@Username", StrUsername);
                ObjLocSqlParameter[6] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[6].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[7] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[7].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_SaveCompanyMst", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[7].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }
        /// <summary>
        /// Function is used to Save & Edit Company Masters
        /// </summary>
        /// <param name="StrGroupID"></param>
        [HttpGet]
        public string FunPubDeleteCompanyMst(string StrCompanyId)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@CompanyId", StrCompanyId);
                ObjLocSqlParameter[1] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[1].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[2] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[2].Direction = ParameterDirection.Output;
                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_DeleteCompanyMst", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[2].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }

        /// <summary>
        /// Function is used to fetch Zone & Unit
        /// </summary>
        /// <param name="StrUnitId"></param>
        /// <param name="StrUnitDesc"></param>
        /// <param name="StrUnitCode"></param>
        /// <param name="StrUnitPrefix"></param>
        /// <param name="StrCompanyId"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ClsZoneLocationMaster> FunPubFetchZoneUnit(string StrUnitId, string StrUnitDesc, string StrUnitCode, string StrUnitPrefix, string StrCompanyId)
        {
            List<ClsZoneLocationMaster> ObjLocZoneUnitList = new List<ClsZoneLocationMaster>();
            ClsCommunication objLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;
            try
            {
                if (StrUnitId == null)
                    StrUnitId = "0";
                if (StrUnitDesc == null)
                    StrUnitDesc = "";
                if (StrUnitCode == null)
                    StrUnitCode = "";
                if (StrUnitPrefix == null)
                    StrUnitPrefix = "";
                if (StrCompanyId == null)
                    StrCompanyId = "0";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[5];
                ObjLocSqlParameter[0] = new SqlParameter("@UnitId", StrUnitId);
                ObjLocSqlParameter[1] = new SqlParameter("@UnitDesc", StrUnitDesc);
                ObjLocSqlParameter[2] = new SqlParameter("@UnitCode", StrUnitCode);
                ObjLocSqlParameter[3] = new SqlParameter("@UnitPrefix", StrUnitPrefix);
                ObjLocSqlParameter[4] = new SqlParameter("@CompanyId", StrCompanyId);
                DsLocDataSet = objLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchUnitMst", ObjLocSqlParameter);

                if ((DsLocDataSet != null))
                {
                    if (DsLocDataSet.Tables[0].Rows.Count > 0)
                    {
                        ObjLocZoneUnitList = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                              select new ClsZoneLocationMaster
                                              {
                                                  ProPubStrUnitId = Convert.ToString(p.Field<decimal>("UnitId")),
                                                  ProPubStrUnitDesc = p.Field<string>("UnitDesc"),
                                                  ProPubStrUnitCode = p.Field<string>("UnitCode"),
                                                  ProPubStrUnitPrefix = p.Field<string>("UnitPrefix"),
                                                  ProPubStrCompanyId = Convert.ToString(p.Field<decimal>("CompanyId")),
                                                  ProPubStrCompanyDesc = p.Field<string>("CompanyDesc")
                                              }).ToList();
                        return ObjLocZoneUnitList;
                    }
                    else
                    {
                        return ObjLocZoneUnitList;
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
                DsLocDataSet = null;
                ObjLocZoneUnitList = null;
            }


        }
        /// <summary>
        /// Function is used to Save & Edit Zone & Unit
        /// </summary>
        /// <param name="StrUnitId"></param>
        /// <param name="StrUnitDesc"></param>
        /// <param name="StrUnitCode"></param>
        /// <param name="StrUnitPrefix"></param>
        /// <param name="StrCompanyId"></param>
        /// <param name="StrUsername"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubSaveEditZoneUnit(string StrUnitId, string StrUnitDesc, string StrUnitCode, string StrUnitPrefix, string StrCompanyId, string StrUsername)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (StrUnitId == null)
                    StrUnitId = "0";
                if (StrUnitDesc == null)
                    StrUnitDesc = "";
                if (StrUnitCode == null)
                    StrUnitCode = "";
                if (StrUnitPrefix == null)
                    StrUnitPrefix = "";
                if (StrCompanyId == null)
                    StrCompanyId = "0";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[8];
                ObjLocSqlParameter[0] = new SqlParameter("@UnitId", StrUnitId);
                ObjLocSqlParameter[1] = new SqlParameter("@UnitDesc", StrUnitDesc);
                ObjLocSqlParameter[2] = new SqlParameter("@UnitCode", StrUnitCode);
                ObjLocSqlParameter[3] = new SqlParameter("@UnitPrefix", StrUnitPrefix);
                ObjLocSqlParameter[4] = new SqlParameter("@CompanyId", StrCompanyId);
                ObjLocSqlParameter[5] = new SqlParameter("@Username", StrUsername);
                ObjLocSqlParameter[6] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[6].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[7] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[7].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_SaveUnitMst", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[7].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }
        /// <summary>
        /// Function is used to Delete Zone & Unit
        /// </summary>
        /// <param name="StrUnitId"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubDeleteZoneUnit(string StrUnitId)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (StrUnitId == null)
                    StrUnitId = "0";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@UnitId", StrUnitId);
                ObjLocSqlParameter[1] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[1].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[2] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[2].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_DeleteUnitMaster", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[2].Value);
                return StrStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }
        /// <summary>
        /// Function is used to fetch Sub Location
        /// </summary>
        /// <param name="StrDeptId"></param>
        /// <param name="StrDeptDesc"></param>
        /// <param name="StrDeptPrefix"></param>
        /// <param name="StrUsername"></param>
        /// <param name="StrShowOnRequest"></param>
        /// <param name="StrLocationId"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ClsSubLocationMaster> FunPubFetchSubLocation(string StrDeptId, string StrDeptDesc, string StrDeptPrefix, string StrLocationId)
        {
            List<ClsSubLocationMaster> ObjSubLocationList = new List<ClsSubLocationMaster>();
            ClsCommunication objLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;
            try
            {
                if (StrDeptId == null)
                    StrDeptId = "0";
                if (StrDeptDesc == null)
                    StrDeptDesc = "";
                if (StrDeptPrefix == null)
                    StrDeptPrefix = "";
                if (StrLocationId == null)
                    StrLocationId = "0";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[4];
                ObjLocSqlParameter[0] = new SqlParameter("@DeptId", StrDeptId);
                ObjLocSqlParameter[1] = new SqlParameter("@DeptDesc", StrDeptDesc);
                ObjLocSqlParameter[2] = new SqlParameter("@DeptPrefix", StrDeptPrefix);
                ObjLocSqlParameter[3] = new SqlParameter("@LocationID", StrLocationId);
                DsLocDataSet = objLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchDeptMst", ObjLocSqlParameter);
                if ((DsLocDataSet != null))
                {
                    if (DsLocDataSet.Tables[0].Rows.Count > 0)
                    {
                        ObjSubLocationList = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                              select new ClsSubLocationMaster
                                              {
                                                  ProPubStrDeptId = Convert.ToString(p.Field<decimal>("DeptId")),
                                                  ProPubStrDeptDesc = p.Field<string>("DeptDesc"),
                                                  ProPubStrDeptPrefix = p.Field<string>("DeptPrefix"),
                                                  ProPubStrLocationId = Convert.ToString(p.Field<decimal>("LocationID")),
                                              }).ToList();
                        return ObjSubLocationList;
                    }
                    else
                    {
                        return ObjSubLocationList;
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
                DsLocDataSet = null;
                ObjSubLocationList = null;
            }

        }
        /// <summary>
        /// Function is used to Save & Edit SubLocation
        /// </summary>
        /// <param name="StrUnitId"></param>
        /// <param name="StrUnitDesc"></param>
        /// <param name="StrUnitCode"></param>
        /// <param name="StrUnitPrefix"></param>
        /// <param name="StrCompanyId"></param>
        /// <param name="StrUsername"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubSaveEditSubLocation(string StrDeptId, string StrDeptDesc, string StrDeptPrefix, string StrUsername, string StrShowOnRequest, string StrLocationId)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (StrDeptId == null)
                    StrDeptId = "0";
                if (StrDeptDesc == null)
                    StrDeptDesc = "";
                if (StrDeptPrefix == null)
                    StrDeptPrefix = "";
                if (StrLocationId == null)
                    StrLocationId = "0";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[9];
                ObjLocSqlParameter[0] = new SqlParameter("@DeptId", StrDeptId);
                ObjLocSqlParameter[1] = new SqlParameter("@DeptDesc", StrDeptDesc);
                ObjLocSqlParameter[2] = new SqlParameter("@DeptPrefix", StrDeptPrefix);
                ObjLocSqlParameter[3] = new SqlParameter("@Username", StrUsername);
                ObjLocSqlParameter[4] = new SqlParameter("@showOnRequest", StrShowOnRequest);
                ObjLocSqlParameter[5] = new SqlParameter("@LocationID", StrLocationId);
                ObjLocSqlParameter[6] = new SqlParameter("@Outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[6].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[7] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[7].Direction = ParameterDirection.Output;
                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_SaveDeptMst", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[7].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }
        /// <summary>
        /// Function is used to Delete SubLocation
        /// </summary>
        /// <param name="StrDeptId"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubDeleteSubLocation(string StrDeptId)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (StrDeptId == null)
                    StrDeptId = "0";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@DeptId", StrDeptId);
                ObjLocSqlParameter[1] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[1].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[2] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[2].Direction = ParameterDirection.Output;
                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_DeleteDeptMst", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[2].Value);
                return StrStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }

        /// <summary>
        /// Function is used to fetch Area
        /// </summary>
        /// <param name="StrCategoryId"></param>
        /// <param name="StrCategoryDesc"></param>
        /// <param name="StrDeptId"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ClsAreaMaster> FunPubFetchArea(string StrCategoryId, string StrCategoryDesc, string StrDeptId)
        {
            List<ClsAreaMaster> ObjAreaList = new List<ClsAreaMaster>();
            ClsCommunication objLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;
            try
            {
                if (StrCategoryId == null)
                    StrCategoryId = "0";
                if (StrCategoryDesc == null)
                    StrCategoryDesc = "";
                if (StrDeptId == null)
                    StrDeptId = "0";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@CategoryId", StrCategoryId);
                ObjLocSqlParameter[1] = new SqlParameter("@CategoryDesc", StrCategoryDesc);
                ObjLocSqlParameter[2] = new SqlParameter("@DeptID", StrDeptId);

                DsLocDataSet = objLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchCategoryMaster", ObjLocSqlParameter);

                if ((DsLocDataSet != null))
                {
                    if (DsLocDataSet.Tables[0].Rows.Count > 0)
                    {
                        ObjAreaList = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                       select new ClsAreaMaster
                                       {
                                           ProPubStrCategoryId = Convert.ToString(p.Field<decimal>("CategoryId")),
                                           ProPubStrCategoryDesc = p.Field<string>("CategoryDesc"),
                                           ProPubStrDeptId = Convert.ToString(p.Field<decimal>("DeptID")),
                                       }).ToList();
                        return ObjAreaList;
                    }
                    else
                    {
                        return ObjAreaList;
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
                DsLocDataSet = null;
                ObjAreaList = null;
            }
        }

        /// <summary>
        /// Function is used to Save & Edit Area
        /// </summary>
        /// <param name="StrCategoryId"></param>
        /// <param name="StrCategoryDesc"></param>
        /// <param name="StrDeptId"></param>
        /// <param name="StrUsername"></param>
        /// <param name="StrCompanyId"></param>
        /// <param name="StrUsername"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubSaveEditArea(string StrCategoryId, string StrCategoryDesc, string StrDeptId, string StrUsername)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (StrCategoryId == null)
                    StrCategoryId = "0";
                if (StrCategoryDesc == null)
                    StrCategoryDesc = "";
                if (StrDeptId == null)
                    StrDeptId = "0";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[8];
                ObjLocSqlParameter[0] = new SqlParameter("@CategoryId", StrCategoryId);
                ObjLocSqlParameter[1] = new SqlParameter("@CategoryDesc", StrCategoryDesc);
                ObjLocSqlParameter[2] = new SqlParameter("@DeptID", StrDeptId);
                ObjLocSqlParameter[3] = new SqlParameter("@Username", StrUsername);
                ObjLocSqlParameter[6] = new SqlParameter("@Outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[6].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[7] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[7].Direction = ParameterDirection.Output;
                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_SaveCategoryMaster", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[7].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }
        /// <summary>
        /// Function is used to Delete Area
        /// </summary>
        /// <param name="StrCategoryId"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubDeleteArea(string StrCategoryId)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (StrCategoryId == null)
                    StrCategoryId = "0";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@CategoryId", StrCategoryId);
                ObjLocSqlParameter[1] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[1].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[2] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[2].Direction = ParameterDirection.Output;
                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_DeleteCategoryMater", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[2].Value);
                return StrStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }

        /// <summary>
        /// Function is used to fetch EmployeeList
        /// </summary>
        /// <param name="StrEmployeeId"></param>
        /// <param name="StrCode"></param>
        /// <param name="StrName"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ClsEmployeeList> FunPubFetchEmployeeList(string StrEmployeeId, string StrCode, string StrName)
        {
            List<ClsEmployeeList> ObjLocEmplyeeList = new List<ClsEmployeeList>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {
                if (StrEmployeeId == null)
                    StrEmployeeId = "0.0";
                if (StrCode == null)
                    StrCode = "";
                if (StrName == null)
                    StrName = "";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@EmployeeID", StrEmployeeId);
                ObjLocSqlParameter[1] = new SqlParameter("@Code", StrCode);
                ObjLocSqlParameter[2] = new SqlParameter("@Name", StrName);

                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchEmployeeMst", ObjLocSqlParameter);

                if (DsLocDataSet != null)
                {
                    if (DsLocDataSet.Tables.Count > 0)
                    {
                        if (DsLocDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjLocEmplyeeList = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                                 select new ClsEmployeeList
                                                 {
                                                     ProPubStrEmployeeId = Convert.ToString(p.Field<decimal>("EmployeeId")),
                                                     ProPubStrCode = p.Field<string>("Code"),
                                                     ProPubStrName = p.Field<string>("Name"),
                                                     ProPubCompany = p.Field<string>("Company"),
                                                     ProPubDesignation = p.Field<string>("Designation"),
                                                     ProPubSubLocation = p.Field<string>("Department"),
                                                 }).ToList();



                            return ObjLocEmplyeeList;
                        }
                    }
                    else
                    {
                        return ObjLocEmplyeeList;
                    }
                }
                else
                {
                    return ObjLocEmplyeeList;
                }

                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;
                ObjLocEmplyeeList = null;
            }


        }

        /// <summary>
        /// Function is used to Save & Edit Employee
        /// </summary>
        /// <param name="StrEmployeeID"></param>
        /// <param name="StrCode"></param>
        /// <param name="StrName"></param>
        /// <param name="StrEmail"></param>
        /// <param name="StrPhoneNumber"></param>
        /// <param name="StrMobile"></param>
        /// <param name="StrCompanyId"></param>
        /// <param name="StrDeptId"></param>
        /// <param name="StrDesignation"></param>
        /// <param name="StrEmpUserName"></param>
        /// <param name="StrGrade"></param>
        /// <param name="StrGroupId"></param>
        /// <param name="StrLocationID"></param>
        /// <param name="StrOtherField1"></param>
        /// <param name="StrOtherField2"></param>
        /// <param name="StrOtherField3"></param>
        /// <param name="StrOtherField4"></param>
        /// <param name="StrOtherField5"></param>
        /// <param name="StrSubDept"></param>
        /// <param name="StrUnitID"></param>
        /// <param name="StrUsername"></param>
        /// <returns></returns>
        [HttpGet]

        public string FunPubSaveEditEmployee(string StrEmployeeID, string StrCode, string StrName, string StrEmail,
                                             string StrPhoneNumber, string StrMobile, string StrUnitID, string StrDeptId,
                                             string StrGrade, string StrDesignation, string StrSubDept, string StrCompanyId, string StrTypeOfUser,
                                             string StrEmpUserName, string StrOtherField1, string StrOtherField2, string StrOtherField3,
                                             string StrOtherField4, string StrOtherField5, string StrLocationID, string StrGroupId, string StrUsername)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (StrEmployeeID == null)
                    StrEmployeeID = "0.0";
                if (StrLocationID == null)
                    StrLocationID = "0.0";
                if (StrCompanyId == null)
                    StrCompanyId = "0.0";
                if (StrCode == null)
                    StrCode = "0.0";
                if (StrName == null)
                    StrName = "";
                if (StrEmail == null)
                    StrEmail = "";
                if (StrPhoneNumber == null)
                    StrPhoneNumber = "";
                if (StrMobile == null)
                    StrMobile = "";
                if (StrUnitID == null)
                    StrUnitID = "";
                if (StrDeptId == null)
                    StrDeptId = "";
                if (StrGrade == null)
                    StrGrade = "";
                if (StrDesignation == null)
                    StrDesignation = "";
                if (StrTypeOfUser == null)
                    StrTypeOfUser = "";
                if (StrEmpUserName == null)
                    StrEmpUserName = "";
                if (StrOtherField1 == null)
                    StrOtherField1 = "";
                if (StrOtherField2 == null)
                    StrOtherField2 = "";
                if (StrOtherField3 == null)
                    StrOtherField3 = "";
                if (StrOtherField4 == null)
                    StrOtherField4 = "";
                if (StrOtherField5 == null)
                    StrOtherField5 = "";
                if (StrUsername == null)
                    StrUsername = "";
                if (StrSubDept == null)
                    StrSubDept = "";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[24];
                ObjLocSqlParameter[0] = new SqlParameter("@EmployeeID", StrEmployeeID);
                ObjLocSqlParameter[1] = new SqlParameter("@Code", StrCode);
                ObjLocSqlParameter[2] = new SqlParameter("@Name", StrName);
                ObjLocSqlParameter[3] = new SqlParameter("@Email", StrEmail);
                ObjLocSqlParameter[4] = new SqlParameter("@PhoneNumber", StrPhoneNumber);
                ObjLocSqlParameter[5] = new SqlParameter("@Mobile", StrMobile);
                ObjLocSqlParameter[6] = new SqlParameter("@UnitID", StrUnitID);
                ObjLocSqlParameter[7] = new SqlParameter("@DeptId", StrDeptId);
                ObjLocSqlParameter[8] = new SqlParameter("@Grade", StrGrade);
                ObjLocSqlParameter[9] = new SqlParameter("@Designation", StrDesignation);
                ObjLocSqlParameter[10] = new SqlParameter("@SubDept", StrSubDept);
                ObjLocSqlParameter[11] = new SqlParameter("@CompanyId", StrCompanyId);
                ObjLocSqlParameter[12] = new SqlParameter("@TypeOfUser", StrTypeOfUser);
                ObjLocSqlParameter[13] = new SqlParameter("@EmpUserName", StrEmpUserName);
                ObjLocSqlParameter[14] = new SqlParameter("@OtherField1", StrOtherField1);
                ObjLocSqlParameter[15] = new SqlParameter("@OtherField2", StrOtherField2);
                ObjLocSqlParameter[16] = new SqlParameter("@OtherField3", StrOtherField3);
                ObjLocSqlParameter[17] = new SqlParameter("@OtherField4", StrOtherField4);
                ObjLocSqlParameter[18] = new SqlParameter("@OtherField5", StrOtherField5);
                ObjLocSqlParameter[19] = new SqlParameter("@LocationID", StrLocationID);
                ObjLocSqlParameter[20] = new SqlParameter("@GroupId", StrGroupId);
                ObjLocSqlParameter[21] = new SqlParameter("@Username", StrUsername);
                ObjLocSqlParameter[22] = new SqlParameter("@Outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[22].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[23] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[23].Direction = ParameterDirection.Output;
                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_SaveEmployeeMst", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[23].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }

        /// <summary>
        /// Function is used to delete EmployeeList
        /// </summary>
        /// <param name="StrEmployeeId"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubDeleteEmployee(string StrEmployeeID)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (StrEmployeeID == null)
                    StrEmployeeID = "0";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@EmployeeID", StrEmployeeID);
                ObjLocSqlParameter[1] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[1].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[2] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[2].Direction = ParameterDirection.Output;
                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_DeleteEmployeeMaster", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[2].Value);
                return StrStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }


        /// <summary>
        /// Function is used to fetch ActionInfoDetails
        /// </summary>
        /// <param name="StrActionInfoId"></param>
        /// <param name="StrActionInfoDesc"></param>
        /// <param name="StrUnitId"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ClsActionInfoDetails> FunPubFetchActionInfoDetails(string StrActionInfoId, string StrActionInfoDesc, string StrUnitId)
        {
            List<ClsActionInfoDetails> ObjLocActionInfoDetails = new List<ClsActionInfoDetails>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {
                if (StrActionInfoId == null)
                    StrActionInfoId = "0";
                if (StrActionInfoDesc == null)
                    StrActionInfoDesc = "";
                if (StrUnitId == null)
                    StrUnitId = "0.0";

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@ActionInfoId", StrActionInfoId);
                ObjLocSqlParameter[1] = new SqlParameter("@ActionInfoDesc", StrActionInfoDesc);
                ObjLocSqlParameter[2] = new SqlParameter("@unitid", StrUnitId);

                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchActionInfoDetails", ObjLocSqlParameter);

                if (DsLocDataSet != null)
                {
                    if (DsLocDataSet.Tables.Count > 0)
                    {
                        if (DsLocDataSet.Tables[0].Rows.Count > 0)
                        {


                            ObjLocActionInfoDetails = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                                       select new ClsActionInfoDetails
                                                       {
                                                           ProPubStrActionInfoId = Convert.ToString(p.Field<decimal>("ActionInfoId")),
                                                           ProPubStrActionInfoDesc = p.Field<string>("ActionInfoDesc"),
                                                           ProPubStrEmployeeName = p.Field<string>("Empname")

                                                       }).ToList();
                            return ObjLocActionInfoDetails;
                        }
                    }
                    else
                    {
                        return ObjLocActionInfoDetails;
                    }
                }
                else
                {
                    return ObjLocActionInfoDetails;
                }




                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsLocDataSet = null;
                ObjLocActionInfoDetails = null;
            }

        }
        /// <summary>
        /// Function is used to Save & Edit ActionInfoDetails
        /// </summary>
        /// <param name="StrActionInfoId"></param>
        /// <param name="StrActionInfoDesc"></param>
        /// <param name="StrEmail"></param>
        /// <param name="StrEmpcd"></param>
        /// <param name="StrMobile"></param>
        /// <param name="StrOwnerName"></param>
        /// <param name="StrRollCd"></param>
        /// <param name="StrUsername"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubSaveEditActionInfoDetails(string StrActionInfoId, string StrActionInfoDesc, string StrRollCd, string StrEmpcd, string StrOwnerName, string StrEmail, string StrMobile, string StrUsername)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (StrActionInfoId == null)
                    StrActionInfoId = "0";
                if (StrActionInfoDesc == null)
                    StrActionInfoDesc = "";
                if (StrRollCd == null)
                    StrRollCd = "";
                if (StrEmpcd == null)
                    StrEmpcd = "";
                if (StrOwnerName == null)
                    StrOwnerName = "";
                if (StrEmail == null)
                    StrEmail = "";
                if (StrMobile == null)
                    StrMobile = "";
                if (StrUsername == null)
                    StrUsername = "";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[10];
                ObjLocSqlParameter[0] = new SqlParameter("@ActionInfoId", StrActionInfoId);
                ObjLocSqlParameter[1] = new SqlParameter("@ActionInfoDesc", StrActionInfoDesc);
                ObjLocSqlParameter[2] = new SqlParameter("@RollCd", StrRollCd);
                ObjLocSqlParameter[3] = new SqlParameter("@EMPCD", StrEmpcd);
                ObjLocSqlParameter[4] = new SqlParameter("@OwnerName", StrOwnerName);
                ObjLocSqlParameter[5] = new SqlParameter("@Email", StrEmail);
                ObjLocSqlParameter[6] = new SqlParameter("@Mobile", StrMobile);
                ObjLocSqlParameter[7] = new SqlParameter("@Username", StrUsername);
                ObjLocSqlParameter[8] = new SqlParameter("@Outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[8].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[9] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[9].Direction = ParameterDirection.Output;
                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_SaveActionInfoDet", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[9].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }
        /// <summary>
        /// Function is used to Delete ActionInfoDetails
        /// </summary>
        /// <param name="StrCategoryId"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubDeleteActionInfoDetails(string StrActionInfoId)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (StrActionInfoId == null)
                    StrActionInfoId = "0";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@ActionInfoId", StrActionInfoId);
                ObjLocSqlParameter[1] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[1].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[2] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[2].Direction = ParameterDirection.Output;
                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_DeleteActionInfoDetail", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[2].Value);
                return StrStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }

        /// <summary>
        /// Function is used to fetch FetchActionInfoGroupLinkup
        /// </summary>
        /// <param name="StrActionInfoGId"></param>
        /// <param name="StrActionInfoGDesc"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ClsActionInfoGroupLinkup> FunPubFetchActionInfoGroupLinkup(string StrActionInfoGId, string StrActionInfoGDesc)
        {
            List<ClsActionInfoGroupLinkup> ObjLocActionInfoGroupLinkup = new List<ClsActionInfoGroupLinkup>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {
                if (StrActionInfoGId == null)
                    StrActionInfoGId = "0.0";
                if (StrActionInfoGDesc == null)
                    StrActionInfoGDesc = "";

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[2];
                ObjLocSqlParameter[0] = new SqlParameter("@ActionInfoGId", StrActionInfoGId);
                ObjLocSqlParameter[1] = new SqlParameter("@ActionInfoGDesc", StrActionInfoGDesc);

                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchActionInfoGroupLinkup", ObjLocSqlParameter);

                if (DsLocDataSet != null)
                {
                    if (DsLocDataSet.Tables.Count > 0)
                    {
                        if (DsLocDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjLocActionInfoGroupLinkup = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                                           select new ClsActionInfoGroupLinkup
                                                           {
                                                               ProPubStrActionInfoGId = Convert.ToString(p.Field<decimal>("ActionInfoGId")),
                                                               ProPubStrActInLinkUp = p.Field<string>("ActionInfoDesc"),
                                                               ProPubStrActionInfoDesc = p.Field<string>("ActionInfoGroupDesc")
                                                           }).ToList();
                            return ObjLocActionInfoGroupLinkup;
                        }
                    }
                    else
                    {
                        return ObjLocActionInfoGroupLinkup;
                    }
                }
                else
                {
                    return ObjLocActionInfoGroupLinkup;
                }



                throw new Exception("Error while processing request.");
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            finally
            {
                ObjLocActionInfoGroupLinkup = null;
                DsLocDataSet = null;
            }
        }

        /// <summary>
        /// Function is used to Save & Edit ActionInfoGroupLinkup
        /// </summary>
        /// <param name="StrActionInfoId"></param>
        /// <param name="StrActionInfoDesc"></param>
        /// <param name="StrEmail"></param>
        /// <param name="StrEmpcd"></param>
        /// <param name="StrMobile"></param>
        /// <param name="StrOwnerName"></param>
        /// <param name="StrRollCd"></param>
        /// <param name="StrUsername"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubSaveEditActionInfoGroupLinkup(string StrActionInfoLinkupId, string StrActionInfoGId, string StrActionInfoGDesc, string StrXmlDoc, string StrUsername)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (StrActionInfoLinkupId == null)
                    StrActionInfoLinkupId = "0";
                if (StrActionInfoLinkupId == null)
                    StrActionInfoLinkupId = "0";
                if (StrActionInfoGDesc == null)
                    StrActionInfoGDesc = "";
                if (StrXmlDoc == null)
                    StrXmlDoc = "";
                if (StrUsername == null)
                    StrUsername = "";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[10];
                ObjLocSqlParameter[0] = new SqlParameter("@ActionInfoLinkupId", StrActionInfoLinkupId);
                ObjLocSqlParameter[1] = new SqlParameter("@ActionInfoGId", StrActionInfoGId);
                ObjLocSqlParameter[2] = new SqlParameter("@ActionInfoGDesc", StrActionInfoGDesc);
                ObjLocSqlParameter[3] = new SqlParameter("@XmlDoc", StrXmlDoc);
                ObjLocSqlParameter[4] = new SqlParameter("@Username", StrUsername);
                ObjLocSqlParameter[5] = new SqlParameter("@Outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[5].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[6] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[6].Direction = ParameterDirection.Output;
                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_SaveActionInfoGroupLinkUp", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[6].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }
        /// <summary>
        /// Function is used to Delete ActionInfoDetails
        /// </summary>
        /// <param name="StrActionInfoId"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubDeleteActionInfoGroupLinkup(string StrActionInfoGID)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;
            try
            {
                if (StrActionInfoGID == null)
                    StrActionInfoGID = "0";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@ActionInfoGID", StrActionInfoGID);
                ObjLocSqlParameter[1] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[1].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[2] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[2].Direction = ParameterDirection.Output;
                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_DeleteActionInfoLinkUp", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[2].Value);
                return StrStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }




        /// <summary>
        /// Function is used to fetch Loaction
        /// </summary>
        /// <param name="StrLocationId"></param>
        /// <param name="StrUnitId"></param>
        /// <param name="StrLocName"></param>
        /// <param name="StrLocationPrefix"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ClsLocationMaster> FunPubFetchLocation(string StrLocationId, string StrUnitId, string StrLocName, string StrLocationPrefix)
        {
            List<ClsLocationMaster> ObjLocLocationList = new List<ClsLocationMaster>();
            ClsCommunication objLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;
            try
            {
                if (StrUnitId == null)
                    StrUnitId = "0";
                if (StrLocationId == null)
                    StrLocationId = "0";
                if (StrLocName == null)
                    StrLocName = "";
                if (StrLocationPrefix == null)
                    StrLocationPrefix = "";

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[4];
                ObjLocSqlParameter[0] = new SqlParameter("@LocationID", StrLocationId);
                ObjLocSqlParameter[1] = new SqlParameter("@unitid", StrUnitId);
                ObjLocSqlParameter[2] = new SqlParameter("@LocName", StrLocName);
                ObjLocSqlParameter[3] = new SqlParameter("@LocationPrefix", StrLocationPrefix);
                DsLocDataSet = objLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FeatchLocationMst", ObjLocSqlParameter);

                if ((DsLocDataSet != null))
                {
                    if (DsLocDataSet.Tables[0].Rows.Count > 0)
                    {
                        ObjLocLocationList = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                              select new ClsLocationMaster
                                              {
                                                  ProPubStrLocationID = Convert.ToString(p.Field<decimal>("LocationID")),
                                                  ProPubStrLocName = p.Field<string>("LocName"),
                                                  ProPubStrUnitID = Convert.ToString(p.Field<decimal>("UnitID")),
                                                  ProPubStrUnitDesc = p.Field<string>("UnitDesc"),
                                                  ProPubStrLocPrefix = p.Field<string>("LocPrefix"),
                                                  ProPubStrLocationUnit = p.Field<string>("LocationUnit")
                                              }).ToList();
                        return ObjLocLocationList;
                    }
                    else
                    {
                        return ObjLocLocationList;
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
                DsLocDataSet = null;
                ObjLocLocationList = null;
            }


        }
        /// <summary>
        /// Function is used to Save & Edit Loaction
        /// </summary>
        /// <param name="StrLocationID"></param>
        /// <param name="StrLocName"></param>
        /// <param name="StrUnitId"></param>
        /// <param name="StrLocationPrefix"></param>
        /// <param name="StrUsername"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubSaveEditLocation(string StrLocationID, string StrLocName, string StrUnitId, string StrLocationPrefix, string StrUsername)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (StrUnitId == null)
                    StrUnitId = "0";
                if (StrLocationID == null)
                    StrLocationID = "0";
                if (StrUnitId == null)
                    StrUnitId = "0";
                if (StrLocationPrefix == null)
                    StrLocationPrefix = "";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[8];
                ObjLocSqlParameter[0] = new SqlParameter("@LocationID", StrLocationID);
                ObjLocSqlParameter[1] = new SqlParameter("@LocName", StrLocName);
                ObjLocSqlParameter[2] = new SqlParameter("@UnitId", StrUnitId);
                ObjLocSqlParameter[3] = new SqlParameter("@LocationPrefix", StrLocationPrefix);
                ObjLocSqlParameter[5] = new SqlParameter("@Username", StrUsername);
                ObjLocSqlParameter[6] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[6].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[7] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[7].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_SaveLocationMst", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[7].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }
        /// <summary>
        /// Function is used to Delete Location
        /// </summary>
        /// <param name="StrLocationId"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubDeleteLocation(string StrLocationId)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (StrLocationId == null)
                    StrLocationId = "0";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@LocationID", StrLocationId);
                ObjLocSqlParameter[1] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[1].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[2] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[2].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_DeleteLocationMst", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[2].Value);
                return StrStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }




        /// <summary>
        /// Function is used to fetch SubArea
        /// Modified By RV on 27-Feb-2019
        /// </summary>
        /// <param name="StrCategoryId"></param>
        /// <param name="StrSubCategoryId"></param>
        /// <param name="StrSubCategoryDesc"></param>
        /// <param name="StrImmediateAssistance"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ClsSubArea> FunPubFetchSubArea(string StrCategoryId, string StrSubCategoryId, string StrSubCategoryDesc, string StrImmediateAssistance)
        {
            List<ClsSubArea> ObjLocSubArea = new List<ClsSubArea>();
            ClsCommunication objLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;
            try
            {
                if (StrCategoryId == null)
                    StrCategoryId = "0";
                if (StrSubCategoryId == null)
                    StrSubCategoryId = "0";
                if (StrSubCategoryDesc == null)
                    StrSubCategoryDesc = "";
                if (StrImmediateAssistance == null)
                    StrImmediateAssistance = "";

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[5];
                ObjLocSqlParameter[0] = new SqlParameter("@CategoryId", StrCategoryId);
                ObjLocSqlParameter[1] = new SqlParameter("@SubCategoryId", StrSubCategoryId);
                ObjLocSqlParameter[2] = new SqlParameter("@SubCategoryDesc", StrSubCategoryDesc);
                ObjLocSqlParameter[3] = new SqlParameter("@ImmediateAssistance", StrImmediateAssistance);
                DsLocDataSet = objLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchSubCategoryMaster", ObjLocSqlParameter);

                if ((DsLocDataSet != null))
                {
                    if (DsLocDataSet.Tables[0].Rows.Count > 0)
                    {
                        ObjLocSubArea = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                         select new ClsSubArea
                                         {
                                             ProPubStrCategoryId = Convert.ToString(p.Field<decimal>("CategoryId")),
                                             ProPubStrSubCategoryId = Convert.ToString(p.Field<decimal>("SubCategoryId")),
                                             ProPubStrSubCategoryDesc = p.Field<string>("SubCategoryDesc"),
                                             ProPubStrImmediateAssistance = p.Field<string>("ImmediateAssistance"),
                                             ProPubStrRemarks = p.Field<string>("Remarks"),
                                             ProPubStrLeadtime = Convert.ToString(p.Field<decimal>("Leadtime")),
                                             ProPubStrExplicitLinkUp = Convert.ToString(p.Field<decimal>("ExplicitLinkUp"))

                                         }).ToList();
                        return ObjLocSubArea;
                    }
                    else
                    {
                        return ObjLocSubArea;
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
                DsLocDataSet = null;
                ObjLocSubArea = null;
            }


        }
        /// <summary>
        /// Function is used to Save & Edit SubArea
        /// </summary>
        /// <param name="StrSubCategoryId"></param>
        /// <param name="StrCategoryId"></param>
        /// <param name="StrSubCategoryDesc"></param>
        /// <param name="StrImmediateAssistance"></param>
        /// <param name="StrExplicitLinkUp"></param>
        /// <param name="StrUsername"></param>
        /// <param name="StrRemarks"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubSaveEditSubArea(string StrSubCategoryId, string StrCategoryId, string StrSubCategoryDesc, string StrImmediateAssistance, string StrRemarks, string StrExplicitLinkUp, string StrUsername, string StrLeadTime)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (StrSubCategoryId == null)
                    StrSubCategoryId = "0";
                if (StrCategoryId == null)
                    StrCategoryId = "0";
                if (StrSubCategoryDesc == null)
                    StrSubCategoryDesc = "";
                if (StrImmediateAssistance == null)
                    StrImmediateAssistance = "";
                if (StrRemarks == null)
                    StrRemarks = "";
                if (StrExplicitLinkUp == null)
                    StrExplicitLinkUp = "";
                if (StrLeadTime == null)
                    StrLeadTime = "";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[10];
                ObjLocSqlParameter[0] = new SqlParameter("@SubCategoryId", StrSubCategoryId);
                ObjLocSqlParameter[1] = new SqlParameter("@CategoryId", StrCategoryId);
                ObjLocSqlParameter[2] = new SqlParameter("@SubCategoryDesc", StrSubCategoryDesc);
                ObjLocSqlParameter[3] = new SqlParameter("@ImmediateAssistance", StrImmediateAssistance);
                ObjLocSqlParameter[4] = new SqlParameter("@Remarks", StrRemarks);
                ObjLocSqlParameter[5] = new SqlParameter("@ExplicitLinkUp", StrExplicitLinkUp);
                ObjLocSqlParameter[6] = new SqlParameter("@Username", StrUsername);
                ObjLocSqlParameter[7] = new SqlParameter("@LeadTime", StrLeadTime);
                ObjLocSqlParameter[8] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[8].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[9] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[9].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_SaveSubCategoryMaster", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[9].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }
        /// <summary>
        /// Function is used to Delete SubArea
        /// </summary>
        /// <param name="StrSubCategoryId"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubDeleteSubArea(string StrSubCategoryId)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (StrSubCategoryId == null)
                    StrSubCategoryId = "0";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@SubCategoryId", StrSubCategoryId);
                ObjLocSqlParameter[1] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[1].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[2] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[2].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_DeleteSubCategoryMater", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[2].Value);
                return StrStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }



        #endregion

        #region "Transaction"
        /// <summary>
        /// Function For Login
        /// Modified By Ravindra Muthe on 19-Nov-2018
        /// </summary>
        /// <param name="StrUserName"></param>
        /// <param name="StrPassword"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage FunPubLogin(string StrUserName, string StrPassword, string UserType, int CompanyID)
        {
            List<ClsUpkeepLogin> ObjLocLogin = new List<ClsUpkeepLogin>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {

                if (StrUserName == null)
                    StrUserName = "";
                if (StrPassword == null)
                    StrPassword = "";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[4];
                ObjLocSqlParameter[0] = new SqlParameter("@Username", StrUserName);
                ObjLocSqlParameter[1] = new SqlParameter("@Password", StrPassword);
                ObjLocSqlParameter[2] = new SqlParameter("@UserType", UserType);
                ObjLocSqlParameter[3] = new SqlParameter("@CompanyID", CompanyID);

                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_Login", ObjLocSqlParameter);

                if (DsLocDataSet != null)
                {
                    if (DsLocDataSet.Tables.Count > 0)
                    {
                        if (DsLocDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjLocLogin = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                           select new ClsUpkeepLogin
                                           {

                                               ProPubStrEmployeeID = Convert.ToString(p.Field<int>("User_ID")),
                                               ProPubStrUsername = p.Field<string>("Username"),
                                               //ProPubStrRights = p.Field<string>("Rights"),
                                               ProPubStrName = p.Field<string>("Name"),
                                               ProPubStrRollCd = p.Field<string>("rollcd"),
                                               ProPubStrEmpCd = p.Field<string>("empcd"),
                                               //ProPubStrPrtycd = p.Field<string>("Prtycd"),
                                               //ProPubStrGroupCompany = p.Field<string>("groupandcompany")


                                           }).ToList();
                            //return ObjLocLogin;
                            return Request.CreateResponse(HttpStatusCode.OK, ObjLocLogin);
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.NotFound, "No Records Found");
                        }
                    }
                    else
                    {
                        //return ObjLocLogin;
                        return Request.CreateResponse(HttpStatusCode.NotFound, "No Records Found");
                    }
                }
                else
                {
                    //return ObjLocLogin;
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
                DsLocDataSet = null;
                ObjLocLogin = null;
            }

        }



        /// <summary>
        /// Function created for Save Employee Token
        /// Modified By Ravindra Muthe on 19-Nov-2018
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <param name="TokenNumber"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubSaveToken(string EmployeeID, string TokenNumber)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                //if (EmployeeID == null)
                //    EmployeeID = "0";
                if (TokenNumber == null)
                    TokenNumber = "0";

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[4];
                ObjLocSqlParameter[0] = new SqlParameter("@EmployeeID", EmployeeID);
                ObjLocSqlParameter[1] = new SqlParameter("@TokenNumber", TokenNumber);
                ObjLocSqlParameter[2] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[2].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[3] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[3].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_SaveEmpToken", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[3].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }




        /// <summary>
        /// Function created for Delete checklist Request details
        /// Created By Ravindra Muthe on 07-Dec-2018
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunDeleteChklistRequest(string strId)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                //if (EmployeeID == null)
                //    EmployeeID = "0";

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@id", strId);
                ObjLocSqlParameter[1] = new SqlParameter("@Outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[1].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[2] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[2].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_DeleteChklistRequest", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[2].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }



        [HttpGet]
        public string FunTestDemoNotification(string StrTokenNumber)
        {
            string response = RestsharpAPI.SendNotification(StrTokenNumber, "Upkeep", "New request recieved", "TICKET");
            return response;
        }





        /// <summary>
        /// Function created for Save MyRequest
        /// Modified by Ravindra Muthe on 19-Nov-2018
        /// </summary>
        /// <param name="StrRollCd"></param>
        /// <param name="StrEmpCd"></param>
        /// <param name="DblCategoryID"></param>
        /// <param name="DblSubCategoryID"></param>
        /// <param name="StrUnitID"></param>
        /// <param name="DblRequestID"></param>
        /// <param name="DblLocationID"></param>
        /// <param name="DblEquipmentID"></param>
        /// <param name="StrClientName"></param>
        /// <returns></returns>

        [HttpGet]
        public string FunPubSaveRequest(string StrRollCd, string StrEmpCd, double DblCategoryID, double DblSubCategoryID, string StrUnitID,
            double DblRequestID, double DblLocationID, double DblEquipmentID, string StrClientName, string StrReplyMessage, string DblDepartementId)
        {

            List<ClsApplyRequest> ObjLocRequest = new List<ClsApplyRequest>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            DataSet DsLocDataSet2 = new DataSet();
            DataSet DsLocParkedId = new DataSet();

            string StrTKTID;
            string StrLocConnection = null;
            double Dblflowid = 0.0;
            // double DblDepartementId = 0.0;
            try
            {
                if (StrRollCd == null)
                    StrRollCd = " ";
                if (StrEmpCd == null)
                    StrEmpCd = " ";
                if (StrUnitID == null)
                    StrUnitID = "";
                if (StrClientName == null)
                    StrClientName = "";
                if (StrReplyMessage == null)
                    StrReplyMessage = "";
                if (DblDepartementId == null)
                    DblDepartementId = "";


                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[7];
                ObjLocSqlParameter[0] = new SqlParameter("@categoryid", DblCategoryID);
                ObjLocSqlParameter[1] = new SqlParameter("@subcategoryid", DblSubCategoryID);
                ObjLocSqlParameter[2] = new SqlParameter("@UnitId", StrUnitID);
                ObjLocSqlParameter[3] = new SqlParameter("@RequestID", DblRequestID);
                ObjLocSqlParameter[4] = new SqlParameter("@SessionRollCd", StrRollCd);
                ObjLocSqlParameter[5] = new SqlParameter("@SessionEmpCd", StrEmpCd);


                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_MyRequestWorkFlow", ObjLocSqlParameter);
                if (DsLocDataSet.Tables[0].Rows.Count > 0)
                {
                    //for (int i = 0; i < DsLocDataSet.Tables[0].Rows.Count; i++)
                    //{
                    string StrRecStatus = DsLocDataSet.Tables[0].Rows[0].Field<string>("RecStatus");
                    int DblNextLevel = DsLocDataSet.Tables[0].Rows[0].Field<Int32>("NextActionLevel");
                    int DblExpectedTime = DsLocDataSet.Tables[0].Rows[0].Field<Int32>("ExpectedTime");
                    string StrSendToRollCD = DsLocDataSet.Tables[0].Rows[0].Field<string>("SendToRollCD");
                    string StrSendToEmpCD = DsLocDataSet.Tables[0].Rows[0].Field<string>("SendToEmpCD");
                    string StrTokenNumber = DsLocDataSet.Tables[0].Rows[0].Field<string>("TokenNumber");



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


                    StrTKTID = Convert.ToString(ObjLocSqlParameters[35].Value);

                    string response = RestsharpAPI.SendNotification(StrTokenNumber, "Ticket ID: " + StrTKTID, "New request recieved", "TICKET");

                    //if (StrParkedId > 0 && StrParkedId != null)
                    //{
                    //    SqlParameter[] ObjLocSqlParametersParked = new SqlParameter[1];
                    //    ObjLocSqlParametersParked[0] = new SqlParameter("@parkedId", StrParkedId);
                    //    DsLocParkedId = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_saveParkedChanges", ObjLocSqlParametersParked);

                    //}

                    if (DsLocDataSet.Tables[0].Rows.Count > 1)
                    {
                        ClsAsyncTasks.AssignRequestToWorkFlow(ObjLocComm, StrLocConnection, DsLocDataSet, StrRollCd, StrEmpCd, DblCategoryID, DblSubCategoryID, StrUnitID,
            DblRequestID, DblLocationID, DblEquipmentID, StrClientName, StrReplyMessage, DblDepartementId, Dblflowid);
                    }


                    if (DsLocDataSet2 != null)
                    {
                        return DblRequestID.ToString();
                    }

                }
                else
                {
                    throw new Exception("Workflow does not exists for this combination");
                }


                throw new Exception("Error while processing request.");
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            finally
            {
                ObjLocRequest = null;
                DsLocDataSet = null;
            }

        }

        /// <summary>
        /// Function created for Saving Image in TKT
        /// Created By Ravindra Muthe on 04-Jan-2019
        /// </summary>
        /// <param name="ObjImg"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage FunPubSaveImg([FromBody]ClsSaveImg ObjImg)
        //string StrMyRequestID, Byte[] StrImgPath)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (ObjImg.StrImgPath == null)
                {
                    ObjImg.StrImgPath = "FFD8FFE000104A46494600010100000100010000FFDB004300100B0C0E0C0A100E0D0E1211101318281A181616183123251D283A333D3C3933383740485C4E404457453738506D51575F626768673E4D71797064785C656763FFDB0043011112121815182F1A1A2F634238426363636363636363636363636363636363636363636363636363636363636363636363636363636363636363636363636363FFC0001108016801E003012200021101031101FFC40017000101010100000000000000000000000000050106FFC4001F1001000301010002030100000000000000000314A15253011121418131FFC40014010100000000000000000000000000000000FFC40014110100000000000000000000000000000000FFDA000C03010002110311003F00E5ACC1DE16A0EF13C051B50F785A83BC4E0146D41DE16A1EF138051B50F785A87BC4E0146D43DE32D43DE2780A16A0F4C6DA83D3138051B50F785A87BC4E0146D43DE16A0EF138FBF9051B507785A87BC4E0146CC1DE1660EF138051B30F78CB50F789E0285A87BC6DA87BC4E0146D43DE32D43DE2780A16A1EF0B50F789E0285A87BC6DA87BC4E0146D41DE32D41E989E0285A83D30B50FA6279F40A16A1EF1B6A1EF138051B50F785A87BC4E0146D43DE16A1EF138050B50F785A87BC4F0146D43E98CB50FA6279F60A36A1EF0B507A6271F9051B507A616A1EF138050B50F785A87BC4F0146D43DE16A1F4C4E3EC146DC3E985A83D3138050B50F78DB50F789C028DA87D30B507789C028DA83BC2D43DE270000000000000000000000000035801FB0000000000018D0FB006340000000000000000000000000000000FE80000000000035800000000000000000000000000000000000C68000031A000000000000000000000000000000031A0000000000031A0306800000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000301A00000000000000000000000000000000000000000000007F4000000000000000000000000000000000000000006034000000000180D0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000006340000000000637E0000000000018D00000000000634000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000FD0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000031A03068000000000000000000000000000000000007C7FA7EBE400000000000000000000000000000000000000000000000000003E400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001FFFD9";
                    // throw new ArgumentNullException();
                }


                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                var bytes = GetBytesFromByteString(ObjImg.StrImgPath).ToArray();

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[4];
                ObjLocSqlParameter[0] = new SqlParameter("@RequestID", ObjImg.StrMyRequestID);
                // ObjLocSqlParameter[1] = new SqlParameter("@ImagePath", ObjImg.StrImgPath);
                ObjLocSqlParameter[1] = new SqlParameter("@ImagePath", SqlDbType.VarBinary);
                ObjLocSqlParameter[1].Value = bytes;
                ObjLocSqlParameter[2] = new SqlParameter("@Outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[2].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[3] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[3].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_SaveImage", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[3].Value);
                return Request.CreateResponse(HttpStatusCode.OK, StrStatus);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }




        /// <summary>
        /// Function created for Saving Image in Checklist
        /// Created By Ravindra Muthe on 04-Jan-2019
        /// </summary>
        /// <param name="ObjImg"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage FunPubSaveImgChklist([FromBody]ClsSaveImgChklist ObjImg)
        //string StrMyRequestID, Byte[] StrImgPath)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (ObjImg.StrImgPathChklist == null)
                {
                    //throw new ArgumentNullException();
                    ObjImg.StrImgPathChklist = "FFD8FFE000104A46494600010100000100010000FFDB004300100B0C0E0C0A100E0D0E1211101318281A181616183123251D283A333D3C3933383740485C4E404457453738506D51575F626768673E4D71797064785C656763FFDB0043011112121815182F1A1A2F634238426363636363636363636363636363636363636363636363636363636363636363636363636363636363636363636363636363FFC0001108016801E003012200021101031101FFC40017000101010100000000000000000000000000050106FFC4001F1001000301010002030100000000000000000314A15253011121418131FFC40014010100000000000000000000000000000000FFC40014110100000000000000000000000000000000FFDA000C03010002110311003F00E5ACC1DE16A0EF13C051B50F785A83BC4E0146D41DE16A1EF138051B50F785A87BC4E0146D43DE32D43DE2780A16A0F4C6DA83D3138051B50F785A87BC4E0146D43DE16A0EF138FBF9051B507785A87BC4E0146CC1DE1660EF138051B30F78CB50F789E0285A87BC6DA87BC4E0146D43DE32D43DE2780A16A1EF0B50F789E0285A87BC6DA87BC4E0146D41DE32D41E989E0285A83D30B50FA6279F40A16A1EF1B6A1EF138051B50F785A87BC4E0146D43DE16A1EF138050B50F785A87BC4F0146D43E98CB50FA6279F60A36A1EF0B507A6271F9051B507A616A1EF138050B50F785A87BC4F0146D43DE16A1F4C4E3EC146DC3E985A83D3138050B50F78DB50F789C028DA87D30B507789C028DA83BC2D43DE270000000000000000000000000035801FB0000000000018D0FB006340000000000000000000000000000000FE80000000000035800000000000000000000000000000000000C68000031A000000000000000000000000000000031A0000000000031A0306800000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000301A00000000000000000000000000000000000000000000007F4000000000000000000000000000000000000000006034000000000180D0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000006340000000000637E0000000000018D00000000000634000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000FD0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000031A03068000000000000000000000000000000000007C7FA7EBE400000000000000000000000000000000000000000000000000003E400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001FFFD9";
                }


                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                //byte[] bytes = Encoding.ASCII.GetBytes(ObjImg.StrImgPathChklist);

                //string someString = Encoding.ASCII.GetString(bytes);
                //StrToByteArray(ObjImg.StrImgPathChklist);
                var bytes = GetBytesFromByteString(ObjImg.StrImgPathChklist).ToArray();
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[2];
                ObjLocSqlParameter[0] = new SqlParameter("@ParkedId", ObjImg.StrParkedId);
                ObjLocSqlParameter[1] = new SqlParameter("@ImgPath", SqlDbType.VarBinary);
                ObjLocSqlParameter[1].Value = bytes;

                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_SaveImagWithParked", ObjLocSqlParameter);
                return Request.CreateResponse(HttpStatusCode.OK, "Image Uploaded Succesfully...");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }


        public IEnumerable<byte> GetBytesFromByteString(string s)
        {
            if (s.Length % 2 != 0)
            {
                yield return Convert.ToByte(s.Substring(0, 1), 16);
                s = s.Substring(1, s.Length - 1);
            }
            for (int index = 0; index < s.Length; index += 2)
            {
                //if (index == 0)
                //    yield return Convert.ToByte(s.Substring(index, 1), 16);
                yield return Convert.ToByte(s.Substring(index, 2), 16);
            }
        }




        /// <summary>
        /// Function created for Saving Image in Close Request
        /// Created By Ravindra Muthe on 22-April-2019
        /// </summary>
        /// <param name="ObjImg"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage FunPubCloseImg([FromBody]ClsSaveImg ObjImg)
        //string StrMyRequestID, Byte[] StrImgPath)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (ObjImg.StrImgPath == null)
                {
                    //throw new ArgumentNullException();
                    ObjImg.StrImgPath = "FFD8FFE000104A46494600010100000100010000FFDB004300100B0C0E0C0A100E0D0E1211101318281A181616183123251D283A333D3C3933383740485C4E404457453738506D51575F626768673E4D71797064785C656763FFDB0043011112121815182F1A1A2F634238426363636363636363636363636363636363636363636363636363636363636363636363636363636363636363636363636363FFC0001108016801E003012200021101031101FFC40017000101010100000000000000000000000000050106FFC4001F1001000301010002030100000000000000000314A15253011121418131FFC40014010100000000000000000000000000000000FFC40014110100000000000000000000000000000000FFDA000C03010002110311003F00E5ACC1DE16A0EF13C051B50F785A83BC4E0146D41DE16A1EF138051B50F785A87BC4E0146D43DE32D43DE2780A16A0F4C6DA83D3138051B50F785A87BC4E0146D43DE16A0EF138FBF9051B507785A87BC4E0146CC1DE1660EF138051B30F78CB50F789E0285A87BC6DA87BC4E0146D43DE32D43DE2780A16A1EF0B50F789E0285A87BC6DA87BC4E0146D41DE32D41E989E0285A83D30B50FA6279F40A16A1EF1B6A1EF138051B50F785A87BC4E0146D43DE16A1EF138050B50F785A87BC4F0146D43E98CB50FA6279F60A36A1EF0B507A6271F9051B507A616A1EF138050B50F785A87BC4F0146D43DE16A1F4C4E3EC146DC3E985A83D3138050B50F78DB50F789C028DA87D30B507789C028DA83BC2D43DE270000000000000000000000000035801FB0000000000018D0FB006340000000000000000000000000000000FE80000000000035800000000000000000000000000000000000C68000031A000000000000000000000000000000031A0000000000031A0306800000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000301A00000000000000000000000000000000000000000000007F4000000000000000000000000000000000000000006034000000000180D0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000006340000000000637E0000000000018D00000000000634000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000FD0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000031A03068000000000000000000000000000000000007C7FA7EBE400000000000000000000000000000000000000000000000000003E400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001FFFD9";
                }


                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                var bytes = GetBytesFromByteString(ObjImg.StrImgPath).ToArray();

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[4];
                ObjLocSqlParameter[0] = new SqlParameter("@RequestID", ObjImg.StrMyRequestID);
                // ObjLocSqlParameter[1] = new SqlParameter("@ImagePath", ObjImg.StrImgPath);
                ObjLocSqlParameter[1] = new SqlParameter("@ImagePath", SqlDbType.VarBinary);
                ObjLocSqlParameter[1].Value = bytes;
                ObjLocSqlParameter[2] = new SqlParameter("@Outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[2].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[3] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[3].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_CloseImage", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[3].Value);
                return Request.CreateResponse(HttpStatusCode.OK, StrStatus);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }





        /// <summary>
        /// Function created for Fetching Close ImagePath
        /// Added By Ravindra Muthe on 22-April-2019
        /// </summary>
        /// <param name="StrRequestID"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ClsImage> FunPubFetchCloseImage(string StrRequestID)
        {
            List<ClsImage> ObjImage = new List<ClsImage>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {

                if (StrRequestID == null)
                    StrRequestID = "";

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[1];

                ObjLocSqlParameter[0] = new SqlParameter("@StrRequestID", StrRequestID);


                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchCloseImgPath", ObjLocSqlParameter);


                byte[] bytes = DsLocDataSet.Tables[0].Rows[0].Field<byte[]>("CloseImgPath");



                if (DsLocDataSet != null)
                {
                    if (DsLocDataSet.Tables.Count > 0)
                    {
                        if (DsLocDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjImage = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                        select new ClsImage
                                        {
                                            // ProPubStrImagePath = Convert.ToBase64String(bytes)

                                            ProPubStrImagePath = "0x" + BitConverter.ToString(p.Field<Byte[]>("CloseImgPath")).Replace("-", string.Empty)

                                        }).ToList();
                            return ObjImage;
                        }
                    }
                    else
                    {
                        return ObjImage;
                    }
                }
                else
                {
                    return ObjImage;
                }

                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsLocDataSet = null;
                ObjImage = null;
            }

        }






        /// <summary>
        /// Function created for Close Request
        /// </summary>
        /// <param name="DblPubMyRequestID"></param>
        /// <param name="DblPubFlowID"></param>
        /// <param name="StrReplyMessage"></param>
        /// <param name="StrPubOperator"></param>
        /// <returns></returns>

        [HttpGet]
        public string FunPubCloseRequest(double DblPubMyRequestID, double DblPubFlowID, string StrReplyMessage, string StrPubOperator)
        {

            List<ClsApplyRequest> ObjLocRequest = new List<ClsApplyRequest>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;
            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[6];
                ObjLocSqlParameter[0] = new SqlParameter("@RequestID", DblPubMyRequestID);
                ObjLocSqlParameter[1] = new SqlParameter("@flowid", DblPubFlowID);
                ObjLocSqlParameter[2] = new SqlParameter("@ReplyMessage", StrReplyMessage);
                ObjLocSqlParameter[3] = new SqlParameter("@Username", StrPubOperator);
                ObjLocSqlParameter[4] = new SqlParameter("@Outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[4].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[5] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[5].Direction = ParameterDirection.Output;
                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_Closerequest", ObjLocSqlParameter);

                if (DsLocDataSet != null)
                {
                    return "Request close Succesfully.";
                }

                throw new Exception("Error while processing request.");
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            finally
            {
                ObjLocRequest = null;
                DsLocDataSet = null;
            }

        }







        /// <summary>
        /// Function created for Parked Request
        /// Created By Ravindra Muthe on 12-June-2019
        /// </summary>
        /// <param name="DblPubMyRequestID"></param>
        /// <param name="DblPubFlowID"></param>
        /// <param name="StrReplyMessage"></param>
        /// <param name="StrPubOperator"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubParkRequest(double DblPubMyRequestID, double DblPubFlowID, string StrReplyMessage, string StrPubOperator)
        {

            List<ClsApplyRequest> ObjLocRequest = new List<ClsApplyRequest>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;
            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[6];
                ObjLocSqlParameter[0] = new SqlParameter("@RequestID", DblPubMyRequestID);
                ObjLocSqlParameter[1] = new SqlParameter("@flowid", DblPubFlowID);
                ObjLocSqlParameter[2] = new SqlParameter("@ReplyMessage", StrReplyMessage);
                ObjLocSqlParameter[3] = new SqlParameter("@Username", StrPubOperator);
                ObjLocSqlParameter[4] = new SqlParameter("@Outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[4].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[5] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[5].Direction = ParameterDirection.Output;
                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_ParkRequest", ObjLocSqlParameter);

                if (DsLocDataSet != null)
                {
                    return "Request Parked Succesfully.";
                }

                throw new Exception("Error while processing request.");
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            finally
            {
                ObjLocRequest = null;
                DsLocDataSet = null;
            }

        }



        /// <summary>
        ///  Function created for Fecthing GatePass Details
        /// Created By Ravindra Muthe on 10-March-2019
        /// </summary>
        /// <param name="StrEmpCD"></param>
        /// <param name="StrUsername"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ClsMyGatePassMst> FunPubFetchMyGatePassMst(string StrEmpCD, string StrUsername)
        {
            List<ClsMyGatePassMst> ObjLocActionInfoDetails = new List<ClsMyGatePassMst>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {
                if (StrEmpCD == null)
                    StrEmpCD = "";
                if (StrUsername == null)
                    StrUsername = "";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[2];
                ObjLocSqlParameter[0] = new SqlParameter("@HdnEmpCD", StrEmpCD);
                ObjLocSqlParameter[1] = new SqlParameter("@username", StrUsername);
                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_FetchMyGetPassMst", ObjLocSqlParameter);

                if (DsLocDataSet != null)
                {
                    if (DsLocDataSet.Tables.Count > 0)
                    {
                        if (DsLocDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjLocActionInfoDetails = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                                       select new ClsMyGatePassMst
                                                       {
                                                           ProPubStrretailerid = p.Field<string>("retailerid"),
                                                           ProPubStrRetailername = p.Field<string>("Retailername"),
                                                           ProPubStrDesignation = p.Field<string>("Designation"),
                                                           ProPubStrRequestDate = Convert.ToString(p.Field<DateTime>("RequestDate")),
                                                           ProPubStrmobileno = p.Field<string>("mobileno"),
                                                           ProPubStrGatepassID = p.Field<string>("GatepassID"),


                                                       }).ToList();
                            return ObjLocActionInfoDetails;
                        }
                    }
                    else
                    {
                        return ObjLocActionInfoDetails;
                    }
                }
                else
                {
                    return ObjLocActionInfoDetails;
                }
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsLocDataSet = null;
                ObjLocActionInfoDetails = null;
            }

        }



        /// <summary>
        /// Function created for Adding GatePassMaterial
        /// Created By Ravindra Muthe on 10-March-2019
        /// </summary>
        /// <param name="StrGateID"></param>
        /// <param name="StrDescription"></param>
        /// <param name="StrPieces"></param>
        /// <param name="StrBoxes"></param>
        /// <param name="StrStock"></param>
        /// <param name="StrLocation"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubSaveGatePassMaterial(string StrGateID, string StrDescription, string StrPieces, string StrBoxes, string StrStock, string StrLocation)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (StrGateID == null)
                    StrGateID = "0";
                if (StrDescription == null)
                    StrDescription = "0";
                if (StrPieces == null)
                    StrPieces = "";
                if (StrBoxes == null)
                    StrBoxes = "";
                if (StrStock == null)
                    StrStock = "";
                if (StrLocation == null)
                    StrLocation = "";

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[8];
                ObjLocSqlParameter[0] = new SqlParameter("@GateID", StrGateID);
                ObjLocSqlParameter[1] = new SqlParameter("@Description", StrDescription);
                ObjLocSqlParameter[2] = new SqlParameter("@Pieces", StrPieces);
                ObjLocSqlParameter[3] = new SqlParameter("@Boxes", StrBoxes);
                ObjLocSqlParameter[4] = new SqlParameter("@Stock", StrStock);
                ObjLocSqlParameter[5] = new SqlParameter("@Location", StrLocation);
                ObjLocSqlParameter[6] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[6].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[7] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[7].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_SaveGetPassMaterial", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[7].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }



        /// <summary>
        /// Function created for Saving GatePass Details
        /// Created By Ravindra Muthe on 10-March-2019
        /// </summary>
        /// <param name="StrGateID"></param>
        /// <param name="StrDeliveryDate"></param>
        /// <param name="StrType"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubSaveGatePassDetail(string StrGateID, string StrDeliveryDate, string StrType)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (StrGateID == null)
                    StrGateID = "0";
                if (StrDeliveryDate == null)
                    StrDeliveryDate = "0";
                if (StrType == null)
                    StrType = "";


                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[8];
                ObjLocSqlParameter[0] = new SqlParameter("@GateID", StrGateID);
                ObjLocSqlParameter[1] = new SqlParameter("@DeliveryDate", StrDeliveryDate);
                ObjLocSqlParameter[2] = new SqlParameter("@Type", StrType);
                ObjLocSqlParameter[3] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[3].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[4] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[4].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_SaveGatePassType", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[4].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }



        /// <summary>
        /// Function created for Updating GatePassMaterial Details
        /// Created By Ravindra Muthe on 10-March-2019
        /// </summary>
        /// <param name="StrSrNumber"></param>
        /// <param name="StrGateID"></param>
        /// <param name="StrDescription"></param>
        /// <param name="StrPieces"></param>
        /// <param name="StrBoxes"></param>
        /// <param name="StrStock"></param>
        /// <param name="StrLocation"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubUpdateGatePassMaterial(string StrSrNumber, string StrGateID, string StrDescription, string StrPieces, string StrBoxes, string StrStock, string StrLocation)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (StrSrNumber == null)
                    StrSrNumber = "0";
                if (StrGateID == null)
                    StrGateID = "0";
                if (StrDescription == null)
                    StrDescription = "";
                if (StrPieces == null)
                    StrPieces = "";
                if (StrBoxes == null)
                    StrBoxes = "";
                if (StrStock == null)
                    StrStock = "";
                if (StrLocation == null)
                    StrLocation = "";


                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[9];
                ObjLocSqlParameter[0] = new SqlParameter("@SrNumber", StrSrNumber);
                ObjLocSqlParameter[1] = new SqlParameter("@GateID", StrGateID);
                ObjLocSqlParameter[2] = new SqlParameter("@Description", StrDescription);
                ObjLocSqlParameter[3] = new SqlParameter("@Pieces", StrPieces);
                ObjLocSqlParameter[4] = new SqlParameter("@Boxes", StrBoxes);
                ObjLocSqlParameter[5] = new SqlParameter("@Stock", StrStock);
                ObjLocSqlParameter[6] = new SqlParameter("@Location", StrLocation);
                ObjLocSqlParameter[7] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[7].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[8] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[8].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_UpdateGatePassMaterial", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[8].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }


        /// <summary>
        /// Function created for Deleting GatePassMaterial Details
        /// Created By Ravindra Muthe on 10-March-2019
        /// </summary>
        /// <param name="StrSrNumber"></param>
        /// <param name="StrGateID"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubDeleteGatePassMaterial(string StrSrNumber, string StrGateID)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (StrSrNumber == null)
                    StrSrNumber = "0";
                if (StrGateID == null)
                    StrGateID = "0";

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[9];
                ObjLocSqlParameter[0] = new SqlParameter("@SrNumber", StrSrNumber);
                ObjLocSqlParameter[1] = new SqlParameter("@GateID", StrGateID);
                ObjLocSqlParameter[2] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[2].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[3] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[3].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_deleteGatePassMaterial", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[3].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }




        /// <summary>
        ///  Function created for Fecthing GatePass Details For Operator And Security Manager
        /// Created By Ravindra Muthe on 10-March-2019
        /// </summary>
        /// <param name="Strfromdate"></param>
        /// <param name="Strtodate"></param>
        /// <param name="Strgatepasstype"></param>
        /// <param name="StrRequestStatus"></param>
        /// <param name="Strgatepassno"></param>
        /// <returns></returns>

        [HttpGet]
        public List<ClsGatePass> FunPubFetchGatePass(string StrRollCD, string StrEmpCD, string Strfromdate, string Strtodate, string Strgatepasstype, string StrRequestStatus, string Strgatepassno)
        {
            List<ClsGatePass> ObjLocActionInfoDetails = new List<ClsGatePass>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {
                if (Strfromdate == null)
                    Strfromdate = "";
                if (Strtodate == null)
                    Strtodate = "";
                if (Strgatepasstype == null)
                    Strgatepasstype = "0";
                if (StrRequestStatus == null)
                    StrRequestStatus = "0";
                if (Strgatepassno == null)
                    Strgatepassno = "0";

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[8];
                ObjLocSqlParameter[0] = new SqlParameter("@fromdate", Strfromdate);
                ObjLocSqlParameter[1] = new SqlParameter("@todate", Strtodate);
                ObjLocSqlParameter[3] = new SqlParameter("@gatepasstype", Strgatepasstype);
                ObjLocSqlParameter[4] = new SqlParameter("@RequestStatus", StrRequestStatus);
                ObjLocSqlParameter[5] = new SqlParameter("@gatepassno", Strgatepassno);
                ObjLocSqlParameter[6] = new SqlParameter("@RollCD", StrRollCD);                                //Added By Ravindra Muthe on 02-March-2019
                ObjLocSqlParameter[7] = new SqlParameter("@EmpCD", StrEmpCD);                                //Added By Ravindra Muthe on 02-March-2019

                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchGatePassDetailsMobile", ObjLocSqlParameter);


                if (DsLocDataSet != null)
                {
                    if (DsLocDataSet.Tables.Count > 0)
                    {
                        if (DsLocDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjLocActionInfoDetails = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                                       select new ClsGatePass
                                                       {
                                                           ProPubStrGatePassID = p.Field<string>("GatePassID"),
                                                           ProPubStrretailerid = p.Field<string>("retailerid"),
                                                           ProPubStrRetailername = p.Field<string>("Retailername"),
                                                           ProPubStrmobileno = p.Field<string>("mobileno"),
                                                           ProPubStrexpecteddate = Convert.ToString(p.Field<DateTime>("expecteddate")),
                                                           ProPubStrreqStatus = p.Field<string>("reqStatus"),
                                                           ProPubStrGatePassType = p.Field<string>("GatePassType"),
                                                           ProPubStrApprovedBy = p.Field<string>("ApprovedBy"),                             //Added By Ravindra Muthe on 15-May-2019
                                                           ProPubStrRemark = p.Field<string>("OperationRemark")                           //Added By Ravindra Muthe on 15-May2019

                                                       }).ToList();
                            return ObjLocActionInfoDetails;
                        }
                    }
                    else
                    {
                        return ObjLocActionInfoDetails;
                    }
                }
                else
                {
                    return ObjLocActionInfoDetails;
                }
                return null;
                // throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsLocDataSet = null;
                ObjLocActionInfoDetails = null;
            }

        }




        /// <summary>
        /// Function created for Fecthing GatePass Details For Security Person
        /// Created By Ravindra Muthe on 10-March-2019
        /// </summary>
        /// <param name="Strfromdate"></param>
        /// <param name="Strtodate"></param>
        /// <param name="Strgatepasstype"></param>
        /// <param name="StrRequestStatus"></param>
        /// <param name="Strgatepassno"></param>
        /// <returns></returns>

        [HttpGet]
        public List<ClsStatusApprovalDetails> FunPubFetchStatusApprovalDetails(string Strfromdate, string Strtodate, string Strgatepasstype, string StrRequestStatus, string Strgatepassno)
        {
            List<ClsStatusApprovalDetails> ObjLocActionInfoDetails = new List<ClsStatusApprovalDetails>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {
                if (Strfromdate == null)
                    Strfromdate = "";
                if (Strtodate == null)
                    Strtodate = "";
                if (Strgatepasstype == null)
                    Strgatepasstype = "0";
                if (StrRequestStatus == null)
                    StrRequestStatus = "Approved";
                if (Strgatepassno == null)
                    Strgatepassno = "0";

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[6];
                ObjLocSqlParameter[0] = new SqlParameter("@fromdate", Strfromdate);
                ObjLocSqlParameter[1] = new SqlParameter("@todate", Strtodate);
                ObjLocSqlParameter[3] = new SqlParameter("@gatepasstype", Strgatepasstype);
                ObjLocSqlParameter[4] = new SqlParameter("@RequestStatus", StrRequestStatus);
                ObjLocSqlParameter[5] = new SqlParameter("@gatepassno", Strgatepassno);

                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchStatusApprovalDetails", ObjLocSqlParameter);


                if (DsLocDataSet != null)
                {
                    if (DsLocDataSet.Tables.Count > 0)
                    {
                        if (DsLocDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjLocActionInfoDetails = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                                       select new ClsStatusApprovalDetails
                                                       {
                                                           ProPubStrGatePassID = p.Field<string>("GatePassID"),
                                                           ProPubStrretailerid = p.Field<string>("retailerid"),
                                                           ProPubStrRetailername = p.Field<string>("Retailername"),
                                                           ProPubStrmobileno = p.Field<string>("mobileno"),
                                                           ProPubStrexpecteddate = Convert.ToString(p.Field<DateTime>("expecteddate")),
                                                           ProPubStrreqStatus = p.Field<string>("SecurityManagerStatus"),
                                                           ProPubStrGatePassType = p.Field<string>("GatePassType"),

                                                       }).ToList();
                            return ObjLocActionInfoDetails;
                        }
                    }
                    else
                    {
                        return ObjLocActionInfoDetails;
                    }
                }
                else
                {
                    return ObjLocActionInfoDetails;
                }
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsLocDataSet = null;
                ObjLocActionInfoDetails = null;
            }

        }






        /// <summary>
        ///  Function created for Fecthing GatePass Details For Operator Reply And Security Manager Reply and Security Person Reply
        /// Created By Ravindra Muthe on 10-March-2019
        /// </summary>
        /// <param name="StrGateID"></param>
        /// <returns></returns>

        [HttpGet]
        public List<ClsGatePassRply> FunPubGatePassRply(string StrGateID)
        {
            List<ClsGatePassRply> ObjLocActionInfoDetails = new List<ClsGatePassRply>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[1];
                ObjLocSqlParameter[0] = new SqlParameter("@GateID", StrGateID);

                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_FetchGatePassRply", ObjLocSqlParameter);


                if (DsLocDataSet != null)
                {
                    if (DsLocDataSet.Tables.Count > 0)
                    {
                        if (DsLocDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjLocActionInfoDetails = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                                       select new ClsGatePassRply
                                                       {
                                                           ProPubStrretailerid = p.Field<string>("retailerid"),
                                                           ProPubStrRetailername = p.Field<string>("Retailername"),
                                                           ProPubStrmobileno = p.Field<string>("mobileno"),
                                                           ProPubStrSrNo = Convert.ToString(p.Field<Int32>("SrNo")),
                                                           ProPubStrIDescription = p.Field<string>("IDescription"),
                                                           ProPubStrNoOfBoxes = p.Field<string>("NoOfBoxes"),
                                                           ProPubStrNoOfPieces = p.Field<string>("NoOfPieces"),
                                                           ProPubStrBalanceStock = p.Field<string>("BalanceStock"),
                                                           ProPubStrTransLocation = p.Field<string>("TransLocation"),

                                                       }).ToList();
                            return ObjLocActionInfoDetails;
                        }
                    }
                    else
                    {
                        return ObjLocActionInfoDetails;
                    }
                }
                else
                {
                    return ObjLocActionInfoDetails;
                }
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsLocDataSet = null;
                ObjLocActionInfoDetails = null;
            }

        }




        /// <summary>
        /// Function created for Updating GatePass Details of Opertor Reply
        /// Sending Mails As per trident Requirement
        /// Modified By Ravindra Muthe on 14-May-2019
        /// </summary>
        /// <param name="StrGateID"></param>
        /// <param name="StrHdnEmpCD"></param>
        /// <param name="StrStrRequestStatus"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubUpdateMyGatePassMst(string StrRollCD, string StrGateID, string StrHdnEmpCD, string StrRequestStatus, string Message)
        {
            GatePassMail gt = new GatePassMail();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;
            DataSet DsLocDatasetNew = new DataSet();

            DsLocDatasetNew = gt.FunFetchEmpDetail(StrGateID);



            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[7];
                ObjLocSqlParameter[0] = new SqlParameter("@RollCD", StrRollCD);                                //Added By Ravindra Muthe on 04-March-2019
                ObjLocSqlParameter[1] = new SqlParameter("@GateID", StrGateID);
                ObjLocSqlParameter[2] = new SqlParameter("@HdnEmpCD", StrHdnEmpCD);
                ObjLocSqlParameter[3] = new SqlParameter("@Status", StrRequestStatus);
                ObjLocSqlParameter[4] = new SqlParameter("@Remark", Message);
                ObjLocSqlParameter[5] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[5].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[6] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[6].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_UpdateMyGatePassMstMobile", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[6].Value);
                //return StrStatus;


                if (DsLocDatasetNew.Tables.Count < 0)
                {
                    Console.WriteLine("Workflow does not exists for this combination");
                }
                else
                {
                    try
                    {
                        ClsAsyncTasks.SendMailsForGatePass(DsLocDatasetNew, DsLocDatasetNew.Tables[0].Rows[0]["Name"].ToString(), DsLocDatasetNew.Tables[0].Rows[0]["Mobile"].ToString(), Message, StrGateID, StrRollCD, StrHdnEmpCD, StrRequestStatus);
                        //gt.SendMailsForGatePass(DsLocDatasetNew, lblRetailerName, lblmobileno, Message, StrGateID, StrRollCD, StrHdnEmpCD, StrRequestStatus);

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }

                return StrStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }







        ///// <summary>
        /////  Function created for Updating GatePass Details of Opertor Reply
        ///// Created By Ravindra Muthe on 10-March-2019
        ///// </summary>
        ///// <param name="StrGateID"></param>
        ///// <param name="StrHdnEmpCD"></param>
        ///// <param name="StrStrRequestStatus"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public string FunPubUpdateMyGatePassMst(string StrRollCD, string StrGateID, string StrHdnEmpCD, string StrRequestStatus)
        //{
        //    ClsCommunication ObjLocComm = new ClsCommunication();
        //    DataSet DsLocDataSet = new DataSet();
        //    string StrLocConnection = null;

        //    try
        //    {

        //        StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

        //        SqlParameter[] ObjLocSqlParameter = new SqlParameter[6];
        //        ObjLocSqlParameter[0] = new SqlParameter("@RollCD", StrRollCD);                                //Added By Ravindra Muthe on 04-March-2019
        //        ObjLocSqlParameter[1] = new SqlParameter("@GateID", StrGateID);
        //        ObjLocSqlParameter[2] = new SqlParameter("@HdnEmpCD", StrHdnEmpCD);
        //        ObjLocSqlParameter[3] = new SqlParameter("@Status", StrRequestStatus);
        //        ObjLocSqlParameter[4] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
        //        ObjLocSqlParameter[4].Direction = ParameterDirection.Output;
        //        ObjLocSqlParameter[5] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
        //        ObjLocSqlParameter[5].Direction = ParameterDirection.Output;
        //        ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_UpdateMyGatePassMstMobile", ObjLocSqlParameter);
        //        string StrStatus = Convert.ToString(ObjLocSqlParameter[5].Value);
        //        return StrStatus;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        DsLocDataSet = null;

        //    }
        //}




        /// <summary>
        /// Function created for Updating GatePass Details of Security Manager Reply
        /// Created By Ravindra Muthe on 10-March-2019
        /// </summary>
        /// <param name="StrGateID"></param>
        /// <param name="StrHdnEmpCD"></param>
        /// <param name="StrStrRequestStatus"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubUpdatestatusapproval(string StrGateID, string StrHdnEmpCD, string StrRequestStatus)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[5];
                ObjLocSqlParameter[0] = new SqlParameter("@GateID", StrGateID);
                ObjLocSqlParameter[1] = new SqlParameter("@HdnEmpCD", StrHdnEmpCD);
                ObjLocSqlParameter[2] = new SqlParameter("@Status", StrRequestStatus);
                ObjLocSqlParameter[3] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[3].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[4] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[4].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_Updatestatusapproval", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[4].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }


        /// <summary>
        /// Function created for Updating/Closing GatePass Details of Security Person Reply
        /// Created By Ravindra Muthe on 10-March-2019
        /// </summary>
        /// <param name="StrGateID"></param>
        /// <param name="StrHdnEmpCD"></param>
        /// <param name="StrStrRequestStatus"></param>
        /// <returns></returns>

        [HttpGet]
        public string FunPubCloseStatusapproval(string StrGateID, string StrHdnEmpCD, string StrRequestStatus)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                StrRequestStatus = "Closed";


                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[5];
                ObjLocSqlParameter[0] = new SqlParameter("@GateID", StrGateID);
                ObjLocSqlParameter[1] = new SqlParameter("@HdnEmpCD", StrHdnEmpCD);
                ObjLocSqlParameter[2] = new SqlParameter("@Status", StrRequestStatus);
                ObjLocSqlParameter[3] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[3].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[4] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[4].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_CloseStatusapproval", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[4].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }


        /// <summary>
        /// Function created for Fecthing Workorder Details
        /// Created By Ravindra Muthe on 10-March-2019
        /// </summary>
        /// <param name="StrEmpCD"></param>
        /// <param name="StrUsername"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ClsMyworkorderid> FunPubFetchMyworkorderid(string StrEmpCD, string StrUsername)
        {
            List<ClsMyworkorderid> ObjLocActionInfoDetails = new List<ClsMyworkorderid>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {
                if (StrEmpCD == null)
                    StrEmpCD = "";
                if (StrUsername == null)
                    StrUsername = "";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[2];
                ObjLocSqlParameter[0] = new SqlParameter("@HdnEmpCD", StrEmpCD);
                ObjLocSqlParameter[1] = new SqlParameter("@username", StrUsername);
                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_FetchWorkOrderID", ObjLocSqlParameter);

                if (DsLocDataSet != null)
                {
                    if (DsLocDataSet.Tables.Count > 0)
                    {
                        if (DsLocDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjLocActionInfoDetails = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                                       select new ClsMyworkorderid
                                                       {
                                                           ProPubStrretailerid = p.Field<string>("retailerid"),
                                                           ProPubStrRetailername = p.Field<string>("Retailername"),
                                                           ProPubStrDesignation = p.Field<string>("Designation"),
                                                           ProPubStrRequestDate = Convert.ToString(p.Field<DateTime>("woRequestDate")),
                                                           ProPubStrmobileno = p.Field<string>("mobileno"),
                                                           ProPubStrWorkorderID = p.Field<string>("WorkorderID"),

                                                       }).ToList();
                            return ObjLocActionInfoDetails;
                        }
                    }
                    else
                    {
                        return ObjLocActionInfoDetails;
                    }
                }
                else
                {
                    return ObjLocActionInfoDetails;
                }
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsLocDataSet = null;
                ObjLocActionInfoDetails = null;
            }

        }



        /// <summary>
        /// Function created for Saving Workorder Details
        /// Created By Ravindra Muthe on 10-March-2019
        /// </summary>
        /// <param name="StrGateID"></param>
        /// <param name="StrDeliveryDate"></param>
        /// <param name="StrType"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubSaveWorkorderDetail(string Strworkerorderid, string Strnameofcontractor, string StrContactnoofcontractor, string StrnameofSiteIncharge, string StrContactNoofSiteIncharge, string StrSupervisorname, string StrSupervisorcontact, string StrNooflabours, string StrExactlocofjob, string StrElectricalsystem, string StrWatersupplysystem, string StrCarpenterandfurniture, string Strstorestockaudit, string Strpestcontrol, string StrHvacSystem, string StrSecuritySurveillancesystem, string StrCivilwork, string StrVMdisplay, string Strpowersupply, string Strwatersuply, string StrWorkinconfinedspace, string Strworkatheight, string StrFemalestaff, string Strothertool, string Strfemale, string Strfirefightingdetectionsystem, string Strotherchk, string Strworktobecarriedout, string Strusername)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (StrElectricalsystem == null)
                    StrElectricalsystem = "0";
                if (StrWatersupplysystem == null)
                    StrWatersupplysystem = "0";
                if (StrCarpenterandfurniture == null)
                    StrCarpenterandfurniture = "0";
                if (Strstorestockaudit == null)
                    Strstorestockaudit = "0";
                if (Strpestcontrol == null)
                    Strpestcontrol = "0";
                if (StrHvacSystem == null)
                    StrHvacSystem = "0";
                if (StrSecuritySurveillancesystem == null)
                    StrSecuritySurveillancesystem = "0";
                if (StrCivilwork == null)
                    StrCivilwork = "0";
                if (StrVMdisplay == null)
                    StrVMdisplay = "0";
                if (Strpowersupply == null)
                    Strpowersupply = "0";
                if (Strwatersuply == null)
                    Strwatersuply = "0";
                if (StrWorkinconfinedspace == null)
                    StrWorkinconfinedspace = "0";
                if (Strworkatheight == null)
                    Strworkatheight = "0";
                if (Strfirefightingdetectionsystem == null)
                    Strfirefightingdetectionsystem = "0";
                if (Strotherchk == null)
                    Strotherchk = "0";
                if (Strworktobecarriedout == null)
                    Strworktobecarriedout = "0";



                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[31];
                ObjLocSqlParameter[0] = new SqlParameter("@Workorderid", Strworkerorderid);
                ObjLocSqlParameter[1] = new SqlParameter("@nameofcontractor", Strnameofcontractor);
                ObjLocSqlParameter[2] = new SqlParameter("@Contactnoofcontractor", StrContactnoofcontractor);
                ObjLocSqlParameter[3] = new SqlParameter("@nameofSiteIncharge", StrnameofSiteIncharge);
                ObjLocSqlParameter[4] = new SqlParameter("@ContactNoofsiteIncharge", StrContactNoofSiteIncharge);
                ObjLocSqlParameter[5] = new SqlParameter("@Supervisorname", StrSupervisorname);
                ObjLocSqlParameter[6] = new SqlParameter("@Supervisorcontact", StrSupervisorcontact);
                ObjLocSqlParameter[7] = new SqlParameter("@Nooflabours", StrNooflabours);
                ObjLocSqlParameter[8] = new SqlParameter("@Exactlocofjob", StrExactlocofjob);
                ObjLocSqlParameter[9] = new SqlParameter("@ElectricalSystem", StrElectricalsystem);
                ObjLocSqlParameter[10] = new SqlParameter("@watersupply", StrWatersupplysystem);
                ObjLocSqlParameter[11] = new SqlParameter("@Carpenterandfurniture", StrCarpenterandfurniture);
                ObjLocSqlParameter[12] = new SqlParameter("@storestockaudit", Strstorestockaudit);
                ObjLocSqlParameter[13] = new SqlParameter("@pestcontrol", Strpestcontrol);
                ObjLocSqlParameter[14] = new SqlParameter("@HvacSystem", StrHvacSystem);
                ObjLocSqlParameter[15] = new SqlParameter("@SecuritySurveillancesystem", StrSecuritySurveillancesystem);
                ObjLocSqlParameter[16] = new SqlParameter("@Civilwork", StrCivilwork);
                ObjLocSqlParameter[17] = new SqlParameter("@VMdisplay", StrVMdisplay);
                ObjLocSqlParameter[18] = new SqlParameter("@powersupplyrequired", Strpowersupply);
                ObjLocSqlParameter[19] = new SqlParameter("@Watersupplyrequired", Strwatersuply);
                ObjLocSqlParameter[20] = new SqlParameter("@workinconfinedspace", StrWorkinconfinedspace);
                ObjLocSqlParameter[21] = new SqlParameter("@workatheight", Strworkatheight);
                ObjLocSqlParameter[22] = new SqlParameter("@femalestaff", StrFemalestaff);
                ObjLocSqlParameter[23] = new SqlParameter("@Tollkit", Strothertool);
                ObjLocSqlParameter[24] = new SqlParameter("@note2", Strfemale);
                ObjLocSqlParameter[25] = new SqlParameter("@firefightingdetectionsystem", Strfirefightingdetectionsystem);
                ObjLocSqlParameter[26] = new SqlParameter("@otherchk", Strotherchk);
                ObjLocSqlParameter[27] = new SqlParameter("@worktobecarriedout", Strworktobecarriedout);
                ObjLocSqlParameter[28] = new SqlParameter("@Username", Strusername);
                ObjLocSqlParameter[29] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[29].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[30] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[30].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_SaveWorkPermit", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[30].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }




        /// <summary>
        /// Function created for Fecthing Workorder Details For Operator And Security Manager
        /// Created By Ravindra Muthe on 10-March-2019
        /// </summary>
        /// <param name="StrEmpCd"></param>
        /// <param name="StrUsername"></param>
        /// <param name="Strfromdate"></param>
        /// <param name="Strtodate"></param>
        /// <param name="StrRequestStatus"></param>
        /// <param name="Strworkorderno"></param>
        /// <returns></returns>

        [HttpGet]
        public List<ClsWorkPass> FunPubFetchWorkPass(string StrRollCD, string StrEmpCd, string StrUsername, string Strfromdate, string Strtodate, string StrRequestStatus, string Strworkorderno)
        {
            List<ClsWorkPass> ObjLocActionInfoDetails = new List<ClsWorkPass>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {
                if (Strfromdate == null)
                    Strfromdate = "";
                if (Strtodate == null)
                    Strtodate = "";
                if (StrRequestStatus == null)
                    StrRequestStatus = "0";
                if (StrRequestStatus == null)
                    StrRequestStatus = "0";
                if (Strworkorderno == null)
                    Strworkorderno = "0";

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[7];
                ObjLocSqlParameter[0] = new SqlParameter("@RollCD", StrRollCD);
                ObjLocSqlParameter[1] = new SqlParameter("@HdnEmpCD", StrEmpCd);
                ObjLocSqlParameter[2] = new SqlParameter("@username", StrUsername);
                ObjLocSqlParameter[3] = new SqlParameter("@fromdate", Strfromdate);
                ObjLocSqlParameter[4] = new SqlParameter("@todate", Strtodate);
                ObjLocSqlParameter[5] = new SqlParameter("@RequestStatus", StrRequestStatus);
                ObjLocSqlParameter[6] = new SqlParameter("@workorderno", Strworkorderno);

                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchWorkpermitDetailsMobile", ObjLocSqlParameter);


                if (DsLocDataSet != null)
                {
                    if (DsLocDataSet.Tables.Count > 0)
                    {
                        if (DsLocDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjLocActionInfoDetails = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                                       select new ClsWorkPass
                                                       {
                                                           ProPubStrWorkorderID = p.Field<string>("WorkorderID"),
                                                           ProPubStrretailerid = p.Field<string>("retailerid"),
                                                           ProPubStrRetailername = p.Field<string>("Retailername"),
                                                           ProPubStrmobileno = p.Field<string>("mobileno"),
                                                           ProPubStrexpectedfromdate = Convert.ToString(p.Field<DateTime>("expectedfromdate")),
                                                           ProPubStrreqStatus = p.Field<string>("reqStatus"),
                                                           ProPubStrApprovedBy = p.Field<string>("ApprovedBy"),                               //Added By Ravindra Muthe on 15-May-2019
                                                           ProPubStrRemark = p.Field<string>("OperationRemark")                             //Added By Ravindra Muthe on 15-May2019

                                                       }).ToList();
                            return ObjLocActionInfoDetails;
                        }
                    }
                    else
                    {
                        return ObjLocActionInfoDetails;
                    }
                }
                else
                {
                    return ObjLocActionInfoDetails;
                }
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsLocDataSet = null;
                ObjLocActionInfoDetails = null;
            }

        }



        /// <summary>
        /// Function created for Fecthing Workorder Details For Security Person
        /// Created By Ravindra Muthe on 10-March-2019
        /// </summary>
        /// <param name="Strfromdate"></param>
        /// <param name="Strtodate"></param>
        /// <param name="StrRequestStatus"></param>
        /// <param name="Strworkorderno"></param>
        /// <returns></returns>

        [HttpGet]
        public List<ClsWorkStatusApprovalDetails> FunPubFetchWorkStatusApprovalDetails(string Strfromdate, string Strtodate, string StrRequestStatus, string Strworkorderno)
        {
            List<ClsWorkStatusApprovalDetails> ObjLocActionInfoDetails = new List<ClsWorkStatusApprovalDetails>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {
                if (Strfromdate == null)
                    Strfromdate = "";
                if (Strtodate == null)
                    Strtodate = "";
                if (StrRequestStatus == null)
                    StrRequestStatus = "Approved";
                if (Strworkorderno == null)
                    Strworkorderno = "0";

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[4];
                ObjLocSqlParameter[0] = new SqlParameter("@fromdate", Strfromdate);
                ObjLocSqlParameter[1] = new SqlParameter("@todate", Strtodate);
                ObjLocSqlParameter[2] = new SqlParameter("@RequestStatus", StrRequestStatus);
                ObjLocSqlParameter[3] = new SqlParameter("@workorderid", Strworkorderno);

                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchWorkStatusApprovalDetails", ObjLocSqlParameter);


                if (DsLocDataSet != null)
                {
                    if (DsLocDataSet.Tables.Count > 0)
                    {
                        if (DsLocDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjLocActionInfoDetails = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                                       select new ClsWorkStatusApprovalDetails
                                                       {
                                                           ProPubStrWorkorderID = p.Field<string>("WorkorderID"),
                                                           ProPubStrretailerid = p.Field<string>("retailerid"),
                                                           ProPubStrRetailername = p.Field<string>("Retailername"),
                                                           ProPubStrmobileno = p.Field<string>("mobileno"),
                                                           ProPubStrexpectedfromdate = Convert.ToString(p.Field<DateTime>("expectedfromdate")),
                                                           ProPubStrreqStatus = p.Field<string>("SecurityManagerStatus")

                                                       }).ToList();
                            return ObjLocActionInfoDetails;
                        }
                    }
                    else
                    {
                        return ObjLocActionInfoDetails;
                    }
                }
                else
                {
                    return ObjLocActionInfoDetails;
                }
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsLocDataSet = null;
                ObjLocActionInfoDetails = null;
            }

        }




        /// <summary>
        /// Function created for Fecthing Workorder Details For Operator Reply And Security Manager Reply and Security Person Reply
        /// Created By Ravindra Muthe on 10-March-2019
        /// </summary>
        /// <param name="workorderid"></param>
        /// <returns></returns>

        [HttpGet]
        public List<ClsworkpermitRply> FunPubworkpermitRply(string workorderid)
        {
            List<ClsworkpermitRply> ObjLocActionInfoDetails = new List<ClsworkpermitRply>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[1];
                ObjLocSqlParameter[0] = new SqlParameter("@workorderID", workorderid);

                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_FetchworkpermitRply", ObjLocSqlParameter);


                if (DsLocDataSet != null)
                {
                    if (DsLocDataSet.Tables.Count > 0)
                    {
                        if (DsLocDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjLocActionInfoDetails = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                                       select new ClsworkpermitRply
                                                       {
                                                           ProPubStrretailerid = p.Field<string>("retailerid"),
                                                           ProPubStrRetailername = p.Field<string>("Retailername"),
                                                           ProPubStrmobileno = p.Field<string>("mobileno"),
                                                           ProPubStrNameofcontractor = p.Field<string>("Nameofcontractor"),
                                                           ProPubStrContactNoofContractor = Convert.ToString(p.Field<decimal>("ContactNoofContractor")),
                                                           ProPubStrNameofSiteIncharge = p.Field<string>("NameofSiteIncharge"),
                                                           ProPubStrContactNoofsiteincharge = Convert.ToString(p.Field<decimal>("ContactNoofsiteincharge")),
                                                           ProPubStrSupervisorname = p.Field<string>("Supervisorname"),
                                                           ProPubStrsupervisorcontact = Convert.ToString(p.Field<decimal>("supervisorcontact")),
                                                           ProPubStrnooflabours = Convert.ToString(p.Field<decimal>("nooflabours")),
                                                           ProPubStrExactlocofjob = p.Field<string>("Exactlocofjob"),
                                                           ProPubStrElectricalsystem = p.Field<string>("Electricalsystem"),
                                                           ProPubStrwatersupply = p.Field<string>("watersupply"),
                                                           ProPubStrcarpenterandfurniture = p.Field<string>("carpenterandfurniture"),
                                                           ProPubStrstorestockaudit = p.Field<string>("storestockaudit"),
                                                           ProPubStrpestcontrol = p.Field<string>("pestcontrol"),
                                                           ProPubStrHvacSystem = p.Field<string>("HvacSystem"),
                                                           ProPubStrSecuritySurveillancesystem = p.Field<string>("SecuritySurveillancesystem"),
                                                           ProPubStrCivilwork = p.Field<string>("Civilwork"),
                                                           ProPubStrVMdisplay = p.Field<string>("VMdisplay"),
                                                           ProPubStrfirefightingdetectionsystem = p.Field<string>("firefightingdetectionsystem"),
                                                           ProPubStrOthers = p.Field<string>("Others"),
                                                           ProPubStrworktobecarriedout = p.Field<string>("worktobecarriedout"),
                                                           ProPubStrpowersupplyrequired = p.Field<string>("powersupplyrequired"),
                                                           ProPubStrworkinconfinedspace = p.Field<string>("workinconfinedspace"),
                                                           ProPubStrwatersupplyrequired = p.Field<string>("watersupplyrequired"),
                                                           ProPubStrworkatheight = p.Field<string>("workatheight"),
                                                           ProPubStrfemalestaff = p.Field<string>("femalestaff"),
                                                           ProPubStrTollkit = p.Field<string>("Tollkit"),
                                                           ProPubStrnote2 = p.Field<string>("note2")

                                                       }).ToList();
                            return ObjLocActionInfoDetails;
                        }
                    }
                    else
                    {
                        return ObjLocActionInfoDetails;
                    }
                }
                else
                {
                    return ObjLocActionInfoDetails;
                }
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsLocDataSet = null;
                ObjLocActionInfoDetails = null;
            }

        }




        ///// <summary>
        /////  Function created for Updating Workorder Details of Opertor Reply 
        ///// Created By Ravindra Muthe on 10-March-2019
        ///// </summary>
        ///// <param name="StrGateID"></param>
        ///// <param name="StrHdnEmpCD"></param>
        ///// <param name="StrStrRequestStatus"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public string FunPubUpdateWorkpermit(string Strworkorderid, string StrHdnEmpCD, string StrRequestStatus)
        //{
        //    ClsCommunication ObjLocComm = new ClsCommunication();
        //    DataSet DsLocDataSet = new DataSet();
        //    string StrLocConnection = null;

        //    try
        //    {

        //        StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

        //        SqlParameter[] ObjLocSqlParameter = new SqlParameter[5];
        //        ObjLocSqlParameter[0] = new SqlParameter("@workorderid", Strworkorderid);
        //        ObjLocSqlParameter[1] = new SqlParameter("@HdnEmpCD", StrHdnEmpCD);
        //        ObjLocSqlParameter[2] = new SqlParameter("@Status", StrRequestStatus);
        //        ObjLocSqlParameter[3] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
        //        ObjLocSqlParameter[3].Direction = ParameterDirection.Output;
        //        ObjLocSqlParameter[4] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
        //        ObjLocSqlParameter[4].Direction = ParameterDirection.Output;
        //        ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_UpdateMyworkpermit", ObjLocSqlParameter);
        //        string StrStatus = Convert.ToString(ObjLocSqlParameter[4].Value);
        //        return StrStatus;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        DsLocDataSet = null;

        //    }
        //}




        /// <summary>
        ///  Function created for Updating Workorder Details of Opertor Reply 
        /// Created By Ravindra Muthe on 10-March-2019
        /// </summary>
        /// <param name="StrGateID"></param>
        /// <param name="StrHdnEmpCD"></param>
        /// <param name="StrStrRequestStatus"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubUpdateWorkpermit(string StrRollCD, string Strworkorderid, string StrHdnEmpCD, string StrRequestStatus, string Message)
        {
            WorkPermitMail wk = new WorkPermitMail();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;
            DataSet DsLocDatasetNew = new DataSet();

            DsLocDatasetNew = wk.FunFetchEmpDetail(Strworkorderid);

            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[5];
                ObjLocSqlParameter[0] = new SqlParameter("@workorderid", Strworkorderid);
                ObjLocSqlParameter[1] = new SqlParameter("@HdnEmpCD", StrHdnEmpCD);
                ObjLocSqlParameter[2] = new SqlParameter("@Status", StrRequestStatus);
                ObjLocSqlParameter[3] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[3].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[4] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[4].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_UpdateMyworkpermit", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[4].Value);
                // return StrStatus;

                if (DsLocDatasetNew.Tables.Count < 0)
                {
                    Console.WriteLine("Workflow does not exists for this combination");
                }
                else
                {
                    try
                    {
                        ClsAsyncTasks.SendMailsForWorkPermit(DsLocDatasetNew, DsLocDatasetNew.Tables[0].Rows[0]["Name"].ToString(), DsLocDatasetNew.Tables[0].Rows[0]["Mobile"].ToString(), Message, Strworkorderid, StrRollCD, StrHdnEmpCD, StrRequestStatus);
                        //gt.SendMailsForGatePass(DsLocDatasetNew, lblRetailerName, lblmobileno, Message, StrGateID, StrRollCD, StrHdnEmpCD, StrRequestStatus);

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }

                return StrStatus;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }






        /// <summary>
        /// Function created for Updating Workorder Details of Security Manager Reply
        /// Created By Ravindra Muthe on 10-March-2019
        /// </summary>
        /// <param name="Strworkorderid"></param>
        /// <param name="StrHdnEmpCD"></param>
        /// <param name="StrRequestStatus"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubUpdateMyWorkStatus(string Strworkorderid, string StrHdnEmpCD, string StrRequestStatus)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[5];
                ObjLocSqlParameter[0] = new SqlParameter("@workorderid", Strworkorderid);
                ObjLocSqlParameter[1] = new SqlParameter("@HdnEmpCD", StrHdnEmpCD);
                ObjLocSqlParameter[2] = new SqlParameter("@Status", StrRequestStatus);
                ObjLocSqlParameter[3] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[3].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[4] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[4].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_Updateworkstatusapproval", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[4].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }





        /// <summary>
        /// Function created for Updating/Closing Workorder Details of Security Person Reply
        /// Created By Ravindra Muthe on 10-March-2019
        /// </summary>
        /// <param name="Strworkorderid"></param>
        /// <param name="StrHdnEmpCD"></param>
        /// <param name="StrRequestStatus"></param>
        /// <returns></returns>

        [HttpGet]
        public string FunPubCloseWorkStatusapproval(string Strworkorderid, string StrHdnEmpCD, string StrRequestStatus)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                StrRequestStatus = "Closed";


                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[5];
                ObjLocSqlParameter[0] = new SqlParameter("@Workorderid", Strworkorderid);
                ObjLocSqlParameter[1] = new SqlParameter("@HdnEmpCD", StrHdnEmpCD);
                ObjLocSqlParameter[2] = new SqlParameter("@Status", StrRequestStatus);
                ObjLocSqlParameter[3] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[3].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[4] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[4].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_CloseWorkStatusapproval", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[4].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }





        /// <summary>
        /// Function created for Fecthing Request List
        /// Modified By Ravindra Muthe On 21-Feb-2019
        /// </summary>
        /// <param name="DblMyRequestID"></param>
        /// <param name="DblFlowID"></param>
        /// <param name="StrRollCD"></param>
        /// <param name="StrEmpCD"></param>
        /// <param name="DblCategoryId"></param>
        /// <param name="DblSubCategoryId"></param>
        /// <param name="StrUnitID"></param>
        /// <param name="StrTicketID"></param>
        /// <param name="StrRequestStatus"></param>
        /// <param name="strStatusID"></param>
        /// <returns></returns>

        // [Route("api/UpKeep/FunPubFetchRequestList")]
        [HttpGet]
        public List<ClsRequestList> FunPubFetchRequestList(double DblMyRequestID, double DblFlowID, string StrRollCD, string StrEmpCD, double DblCategoryId, double DblSubCategoryId, string StrUnitID, string StrTicketID, string StrRequestStatus, string strStatusID)
        {
            List<ClsRequestList> ObjLocActionInfoDetails = new List<ClsRequestList>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {
                if (DblMyRequestID == null)
                    DblMyRequestID = 0.0;
                if (DblFlowID == null)
                    DblFlowID = 0.0;
                if (StrRollCD == null)
                    StrRollCD = "";
                if (StrEmpCD == null)
                    StrEmpCD = "";
                if (DblCategoryId == null)
                    DblCategoryId = 0.0;
                if (DblSubCategoryId == null)
                    DblSubCategoryId = 0.0;
                if (StrUnitID == null)
                    StrUnitID = "0";
                if (StrTicketID == null)
                    StrTicketID = "";
                if (StrRequestStatus == null)
                    StrRequestStatus = "";
                if (strStatusID == null)
                    strStatusID = "";

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[11];
                ObjLocSqlParameter[0] = new SqlParameter("@RequestID", DblMyRequestID);
                ObjLocSqlParameter[1] = new SqlParameter("@flowid", DblFlowID);
                ObjLocSqlParameter[3] = new SqlParameter("@rollcd", StrRollCD);
                ObjLocSqlParameter[4] = new SqlParameter("@empcd", StrEmpCD);
                ObjLocSqlParameter[5] = new SqlParameter("@categoryid", DblCategoryId);
                ObjLocSqlParameter[6] = new SqlParameter("@Subcategoryid", DblSubCategoryId);
                ObjLocSqlParameter[7] = new SqlParameter("@UnitId", StrUnitID);
                ObjLocSqlParameter[8] = new SqlParameter("@TicketID", StrTicketID);
                ObjLocSqlParameter[9] = new SqlParameter("@RequestStatus", StrRequestStatus);
                ObjLocSqlParameter[10] = new SqlParameter("@StatusId", strStatusID);

                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchMyRequest", ObjLocSqlParameter);

                if (DsLocDataSet != null)
                {
                    if (DsLocDataSet.Tables.Count > 0)
                    {
                        if (DsLocDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjLocActionInfoDetails = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                                       select new ClsRequestList
                                                       {
                                                           ProPubStrMyRequestID = Convert.ToString(p.Field<decimal>("RequestID")),
                                                           ProPubStrPubFlowID = Convert.ToString(p.Field<decimal>("FlowID")),
                                                           ProPubStrTicketNo = p.Field<string>("TicketId"),
                                                           ProPubStrFromEmployee = p.Field<string>("FromEmployee"),            //Added By Ravindra Muthe on 21-Feb-2019            
                                                           ProPubStrArea = p.Field<string>("CategoryDesc"),
                                                           ProPubStrSubArea = p.Field<string>("SubCategoryDesc"),
                                                           ProPubStrZone = p.Field<string>("Unit"),
                                                           ProPubStrLocation = p.Field<string>("LocationDesc"),
                                                           ProPubStrSubLocation = p.Field<string>("SubLocationDesc"),
                                                           ProPubStrPendingWith = p.Field<string>("PendingWith"),
                                                           ProPubStrRequestDate = p.Field<string>("RequestDate"),
                                                           ProPubStrRequestStatus = p.Field<string>("RequestStatus"),
                                                           ProPubStrStatus = p.Field<string>("status"),
                                                           ProPubStrMessage = p.Field<string>("Message"),
                                                           ProPubStrCloseMessage = p.Field<string>("CloseMessage"),               //Added By Ravindra Muthe on 22-April-2019   
                                                           //ProPubStrcurrentlevel = p.Field<string>("currentlevel")               //Added By Ravindra Muthe on 03-July-2019   

                                                       }).ToList();
                            return ObjLocActionInfoDetails;
                        }
                    }
                    else
                    {
                        return ObjLocActionInfoDetails;
                    }
                }
                else
                {
                    return ObjLocActionInfoDetails;
                }
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsLocDataSet = null;
                ObjLocActionInfoDetails = null;
            }

        }

        /// <summary>
        /// Function created for Fecthing Actionable List
        /// Modified By Ravindra Muthe on 30-Nov-2018
        /// </summary>
        /// <param name="StrRollCD"></param>
        /// <param name="StrEmpCD"></param>
        /// <param name="DblCategoryId"></param>
        /// <param name="DblSubCategoryId"></param>
        /// <param name="StrUnitID"></param>
        /// <param name="StrTicketID"></param>
        /// <param name="StrRequestStatus"></param>
        /// <returns></returns>

        [HttpGet]
        public List<ClsRequestList> FunPubFetchActionableList(string StrRollCD, string StrEmpCD, double DblCategoryId, double DblSubCategoryId, string StrUnitID, string StrTicketID, string StrRequestStatus)
        {
            List<ClsRequestList> ObjLocActionInfoDetails = new List<ClsRequestList>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {

                if (StrRollCD == null)
                    StrRollCD = "";
                if (StrEmpCD == null)
                    StrEmpCD = "";
                if (DblCategoryId == null)
                    DblCategoryId = 0.0;
                if (DblSubCategoryId == null)
                    DblSubCategoryId = 0.0;
                if (StrUnitID == null)
                    StrUnitID = "0";
                if (StrTicketID == null)
                    StrTicketID = "";
                if (StrRequestStatus == null)
                    StrRequestStatus = "";

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[7];

                ObjLocSqlParameter[0] = new SqlParameter("@rollcd", StrRollCD);
                ObjLocSqlParameter[1] = new SqlParameter("@empcd", StrEmpCD);
                ObjLocSqlParameter[2] = new SqlParameter("@categoryid", DblCategoryId);
                ObjLocSqlParameter[3] = new SqlParameter("@Subcategoryid", DblSubCategoryId);
                ObjLocSqlParameter[4] = new SqlParameter("@UnitId", StrUnitID);
                ObjLocSqlParameter[5] = new SqlParameter("@TicketID", StrTicketID);
                ObjLocSqlParameter[6] = new SqlParameter("@RequestStatus", StrRequestStatus);


                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchMyActionable", ObjLocSqlParameter);

                if (DsLocDataSet != null)
                {
                    if (DsLocDataSet.Tables.Count > 0)
                    {
                        if (DsLocDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjLocActionInfoDetails = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                                       select new ClsRequestList
                                                       {

                                                           ProPubStrMyRequestID = Convert.ToString(p.Field<decimal>("RequestID")),
                                                           ProPubStrPubFlowID = Convert.ToString(p.Field<decimal>("FlowID")),
                                                           ProPubStrTicketNo = p.Field<string>("TicketId"),
                                                           ProPubStrFromEmployee = p.Field<string>("FromEmployee"),
                                                           ProPubStrArea = p.Field<string>("CategoryDesc"),
                                                           ProPubStrZone = p.Field<string>("Unit"),
                                                           ProPubStrLocation = p.Field<string>("LocationDesc"),
                                                           ProPubStrSubLocation = p.Field<string>("SubLocationDesc"),
                                                           ProPubStrSubArea = p.Field<string>("SubCategoryDesc"),
                                                           ProPubStrPendingWith = p.Field<string>("PendingWith"),
                                                           ProPubStrRequestDate = p.Field<string>("RequestDate"),
                                                           ProPubStrRequestStatus = p.Field<string>("RequestStatus"),
                                                           ProPubStrMessage = p.Field<string>("Message"),
                                                           ProPubStrCloseMessage = p.Field<string>("CloseMessage"),                    //Added By Ravindra Muthe on 22-April-2019   
                                                           //ProPubStrcurrentlevel = p.Field<string>("currentlevel")                    //Added By Ravindra Muthe on 03-July-2019   
                                                           // ProPubStrImagePath = "0x" + BitConverter.ToString(p.Field<Byte[]>("ImgPath")).Replace("-", string.Empty)


                                                       }).ToList();
                            return ObjLocActionInfoDetails;
                        }
                    }
                    else
                    {
                        return ObjLocActionInfoDetails;
                    }
                }
                else
                {
                    return ObjLocActionInfoDetails;
                }
                //throw new Exception("Error while processing request.");
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsLocDataSet = null;
                ObjLocActionInfoDetails = null;
            }

        }




        /// <summary>
        /// Function created for Fetching ImagePath
        /// Added By Ravindra Muthe on 05-Jan-2019
        /// </summary>
        /// <param name="StrRequestID"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ClsImage> FunPubFetchImage(string StrRequestID)
        {
            List<ClsImage> ObjImage = new List<ClsImage>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {

                if (StrRequestID == null)
                    StrRequestID = "";

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[1];

                ObjLocSqlParameter[0] = new SqlParameter("@StrRequestID", StrRequestID);


                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchImgPath", ObjLocSqlParameter);


                // byte[] bytes = DsLocDataSet.Tables[0].Rows[0].Field<byte[]>("ImgPath");



                if (DsLocDataSet != null)
                {
                    if (DsLocDataSet.Tables.Count > 0)
                    {
                        if (DsLocDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjImage = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                        select new ClsImage
                                        {
                                            //ProPubStrImagePath = Convert.ToBase64String(bytes)

                                            ProPubStrImagePath = "0x" + BitConverter.ToString(p.Field<Byte[]>("ImgPath")).Replace("-", string.Empty)

                                        }).ToList();
                            return ObjImage;
                        }
                    }
                    else
                    {
                        return ObjImage;
                    }
                }
                else
                {
                    return ObjImage;
                }

                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsLocDataSet = null;
                ObjImage = null;
            }

        }








        /// <summary>
        /// Function created for Fecthing Request List on Take Action
        /// Created By Ravindra Muthe on 04-Dec-2018  UNUSABLE
        /// </summary>
        /// <param name="DblMyRequestID"></param>
        /// <param name="DblFlowID"></param>
        /// <param name="StrRollCD"></param>
        /// <param name="StrEmpCD"></param>
        /// <param name="DblCategoryId"></param>
        /// <param name="DblSubCategoryId"></param>
        /// <param name="StrUnitID"></param>
        /// <param name="StrTicketID"></param>
        /// <param name="StrRequestStatus"></param>
        /// <param name="strStatusID"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ClsRequestList> FunPubFetchRequestListAction(double DblMyRequestID, double DblFlowID, string StrRollCD, string StrEmpCD, double DblCategoryId, double DblSubCategoryId, string StrUnitID, string StrTicketID, string StrRequestStatus, string strStatusID)
        {
            List<ClsRequestList> ObjLocActionInfoDetails = new List<ClsRequestList>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {
                if (DblMyRequestID == null)
                    DblMyRequestID = 0.0;
                if (DblFlowID == null)
                    DblFlowID = 0.0;
                if (StrRollCD == null)
                    StrRollCD = "";
                if (StrEmpCD == null)
                    StrEmpCD = "";
                if (DblCategoryId == null)
                    DblCategoryId = 0.0;
                if (DblSubCategoryId == null)
                    DblSubCategoryId = 0.0;
                if (StrUnitID == null)
                    StrUnitID = "0";
                if (StrTicketID == null)
                    StrTicketID = "";
                if (StrRequestStatus == null)
                    StrRequestStatus = "";
                if (strStatusID == null)
                    strStatusID = "";

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[11];
                ObjLocSqlParameter[0] = new SqlParameter("@RequestID", DblMyRequestID);
                ObjLocSqlParameter[1] = new SqlParameter("@flowid", DblFlowID);
                ObjLocSqlParameter[3] = new SqlParameter("@rollcd", StrRollCD);
                ObjLocSqlParameter[4] = new SqlParameter("@empcd", StrEmpCD);
                ObjLocSqlParameter[5] = new SqlParameter("@categoryid", DblCategoryId);
                ObjLocSqlParameter[6] = new SqlParameter("@Subcategoryid", DblSubCategoryId);
                ObjLocSqlParameter[7] = new SqlParameter("@UnitId", StrUnitID);
                ObjLocSqlParameter[8] = new SqlParameter("@TicketID", StrTicketID);
                ObjLocSqlParameter[9] = new SqlParameter("@RequestStatus", StrRequestStatus);
                ObjLocSqlParameter[10] = new SqlParameter("@StatusId", strStatusID);

                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchMyRequest", ObjLocSqlParameter);

                if (DsLocDataSet != null)
                {
                    if (DsLocDataSet.Tables.Count > 0)
                    {
                        if (DsLocDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjLocActionInfoDetails = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                                       select new ClsRequestList
                                                       {
                                                           ProPubStrMyRequestID = Convert.ToString(p.Field<decimal>("RequestID")),
                                                           ProPubStrPubFlowID = Convert.ToString(p.Field<decimal>("FlowID")),
                                                           ProPubStrTicketNo = p.Field<string>("TicketId"),
                                                           ProPubStrArea = p.Field<string>("CategoryDesc"),
                                                           ProPubStrSubArea = p.Field<string>("SubCategoryDesc"),
                                                           ProPubStrZone = p.Field<string>("UnitDesc"),
                                                           // ProPubStrLocationDesc = p.Field<string>("LocationDesc"),
                                                           // ProPubStrSubLocationDesc = p.Field<string>("SubLocationDesc"),
                                                           //ProPubStrPendingWith = p.Field<string>("PendingWith"),
                                                           ProPubStrRequestDate = p.Field<string>("RequestDate"),
                                                           ProPubStrRequestStatus = p.Field<string>("RequestStatus"),
                                                           // ProPubStrStatus = p.Field<string>("status"),
                                                           ProPubStrMessage = p.Field<string>("Message")

                                                       }).ToList();
                            return ObjLocActionInfoDetails;
                        }
                    }
                    else
                    {
                        return ObjLocActionInfoDetails;
                    }
                }
                else
                {
                    return ObjLocActionInfoDetails;
                }
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsLocDataSet = null;
                ObjLocActionInfoDetails = null;
            }

        }





        /// <summary>
        /// Function created for Save MyRequest offline to online
        /// </summary>
        /// <param name="StrRollCd"></param>
        /// <param name="StrEmpCd"></param>
        /// <param name="DblCategoryID"></param>
        /// <param name="DblSubCategoryID"></param>
        /// <param name="StrUnitID"></param>
        /// <param name="DblRequestID"></param>
        /// <param name="DblLocationID"></param>
        /// <param name="DblEquipmentID"></param>
        /// <param name="StrClientName"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public List<ClsRequestData> FunPubSaveRequestOffToOnline(string StrRollCd, string StrEmpCd, double DblCategoryID, double DblSubCategoryID, string StrUnitID,
            double DblRequestID, double DblLocationID, double DblEquipmentID, string StrClientName, string StrTempID)
        {


            ClsCommunication ObjLocComm = new ClsCommunication();

            DataSet DsLocDataSet = new DataSet();
            DataSet DsLocDataSet1 = new DataSet();
            DataSet DsLocDataSet2 = new DataSet();
            List<ClsRequestData> ObjLocRequestData = new List<ClsRequestData>();
            string StrLocConnection = null;
            bool Flag;

            double Dblflowid = 0.0;
            double DblDepartementId = 0.0;
            try
            {

                if (StrRollCd == null)
                    StrRollCd = " ";
                if (StrEmpCd == null)
                    StrEmpCd = " ";
                if (StrUnitID == null)
                    StrUnitID = "";
                if (StrClientName == null)
                    StrClientName = "";


                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjSqlParameter = new SqlParameter[3];
                ObjSqlParameter[0] = new SqlParameter("@TempId", StrTempID);
                ObjSqlParameter[1] = new SqlParameter("@Flag", SqlDbType.Bit, 1);
                ObjSqlParameter[1].Direction = ParameterDirection.Output;
                ObjSqlParameter[2] = new SqlParameter("@Username", "admin");
                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Sprh_FetchOflineRequest", ObjSqlParameter);
                Flag = Convert.ToBoolean(ObjSqlParameter[1].Value);
                if (Flag == true)
                {
                    SqlParameter[] ObjLocSqlParameter = new SqlParameter[7];
                    ObjLocSqlParameter[0] = new SqlParameter("@categoryid", DblCategoryID);
                    ObjLocSqlParameter[1] = new SqlParameter("@subcategoryid", DblSubCategoryID);
                    ObjLocSqlParameter[2] = new SqlParameter("@UnitId", StrUnitID);
                    ObjLocSqlParameter[3] = new SqlParameter("@RequestID", DblRequestID);
                    ObjLocSqlParameter[4] = new SqlParameter("@SessionRollCd", StrRollCd);
                    ObjLocSqlParameter[5] = new SqlParameter("@SessionEmpCd", StrEmpCd);

                    DsLocDataSet1 = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_MyRequestWorkFlow", ObjLocSqlParameter);
                    if (DsLocDataSet1.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < DsLocDataSet1.Tables[0].Rows.Count; i++)
                        {
                            string StrRecStatus = DsLocDataSet1.Tables[0].Rows[i].Field<string>("RecStatus");
                            int DblNextLevel = DsLocDataSet1.Tables[0].Rows[i].Field<Int32>("NextActionLevel");
                            int DblExpectedTime = DsLocDataSet1.Tables[0].Rows[i].Field<Int32>("ExpectedTime");
                            string StrSendToRollCD = DsLocDataSet1.Tables[0].Rows[i].Field<string>("SendToRollCD");
                            string StrSendToEmpCD = DsLocDataSet1.Tables[0].Rows[i].Field<string>("SendToEmpCD");

                            SqlParameter[] ObjLocSqlParameters = new SqlParameter[41];
                            ObjLocSqlParameters[0] = new SqlParameter("@TempID", StrTempID);
                            ObjLocSqlParameters[1] = new SqlParameter("@RequestID", DblRequestID);
                            ObjLocSqlParameters[2] = new SqlParameter("@flowid", Dblflowid);
                            ObjLocSqlParameters[3] = new SqlParameter("@SubCategoryId", DblSubCategoryID);
                            ObjLocSqlParameters[4] = new SqlParameter("@CategoryId", DblCategoryID);
                            ObjLocSqlParameters[5] = new SqlParameter("@EquipmentID", DblEquipmentID);
                            ObjLocSqlParameters[6] = new SqlParameter("@ClientName", StrClientName);
                            ObjLocSqlParameters[7] = new SqlParameter("@EmpCD", StrEmpCd);
                            ObjLocSqlParameters[8] = new SqlParameter("@RollCD", StrRollCd);
                            ObjLocSqlParameters[9] = new SqlParameter("@RequestedByEmpCD", StrEmpCd);
                            ObjLocSqlParameters[10] = new SqlParameter("@RequestedByRollCD", StrRollCd);
                            ObjLocSqlParameters[11] = new SqlParameter("@UnitID", StrUnitID);
                            ObjLocSqlParameters[12] = new SqlParameter("@LocationID", DblLocationID);
                            ObjLocSqlParameters[13] = new SqlParameter("@RequestStatus", "open");
                            ObjLocSqlParameters[14] = new SqlParameter("@NextLevel", DblNextLevel);
                            ObjLocSqlParameters[15] = new SqlParameter("@RecStatus", StrRecStatus);
                            ObjLocSqlParameters[16] = new SqlParameter("@ReplyMessage", "");
                            ObjLocSqlParameters[17] = new SqlParameter("@ExpectedTime", DblExpectedTime);
                            ObjLocSqlParameters[18] = new SqlParameter("@DoneByRollCd", StrRollCd);
                            ObjLocSqlParameters[19] = new SqlParameter("@DoneByEmpCd", StrEmpCd);
                            ObjLocSqlParameters[20] = new SqlParameter("@SendToRollCd", StrSendToRollCD);
                            ObjLocSqlParameters[21] = new SqlParameter("@SendToEmpCd", StrSendToEmpCD);
                            ObjLocSqlParameters[22] = new SqlParameter("@DepartmentId ", DblDepartementId);
                            ObjLocSqlParameters[23] = new SqlParameter("@Status ", "Pending");
                            ObjLocSqlParameters[24] = new SqlParameter("@Message", "");
                            ObjLocSqlParameters[25] = new SqlParameter("@IsAcknowledge", "false");
                            ObjLocSqlParameters[26] = new SqlParameter("@IsCloserExpected", "false");
                            ObjLocSqlParameters[27] = new SqlParameter("@sendbit", "true");
                            ObjLocSqlParameters[28] = new SqlParameter("@Username", "admin");
                            ObjLocSqlParameters[29] = new SqlParameter("@Subject", "");
                            ObjLocSqlParameters[30] = new SqlParameter("@Priority", 1);
                            ObjLocSqlParameters[31] = new SqlParameter("@Outbit", SqlDbType.Bit, 1);
                            ObjLocSqlParameters[31].Direction = ParameterDirection.Output;
                            ObjLocSqlParameters[32] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 100);
                            ObjLocSqlParameters[32].Direction = ParameterDirection.Output;
                            ObjLocSqlParameters[33] = new SqlParameter("@OutFlowID", SqlDbType.Decimal, 100);
                            ObjLocSqlParameters[33].Direction = ParameterDirection.Output;
                            ObjLocSqlParameters[34] = new SqlParameter("@OutRequestID", SqlDbType.Decimal, 100);
                            ObjLocSqlParameters[34].Direction = ParameterDirection.Output;
                            ObjLocSqlParameters[35] = new SqlParameter("@OutFlowID2", SqlDbType.Decimal, 100);
                            ObjLocSqlParameters[35].Direction = ParameterDirection.Output;
                            ObjLocSqlParameters[36] = new SqlParameter("@Outticketid", SqlDbType.VarChar, 100);
                            ObjLocSqlParameters[36].Direction = ParameterDirection.Output;
                            ObjLocSqlParameters[37] = new SqlParameter("@OutTempID", SqlDbType.VarChar, 100);
                            ObjLocSqlParameters[37].Direction = ParameterDirection.Output;
                            ObjLocSqlParameters[38] = new SqlParameter("@OutPendingWith", SqlDbType.VarChar, 100);
                            ObjLocSqlParameters[38].Direction = ParameterDirection.Output;
                            ObjLocSqlParameters[39] = new SqlParameter("@OutPendingRollcd", SqlDbType.Char, 6);
                            ObjLocSqlParameters[39].Direction = ParameterDirection.Output;
                            ObjLocSqlParameters[40] = new SqlParameter("@OutPendingEmpcd", SqlDbType.Char, 6);
                            ObjLocSqlParameters[40].Direction = ParameterDirection.Output;

                            DsLocDataSet2 = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_SaveRequestOfflineToOnline", ObjLocSqlParameters);
                            DblRequestID = Convert.ToDouble(ObjLocSqlParameters[34].Value);
                            Dblflowid = Convert.ToDouble(ObjLocSqlParameters[33].Value);
                            if (DsLocDataSet2 != null)
                            {
                                ClsRequestData ClsRD = new ClsRequestData();
                                ClsRD.ProPubStrFlowID = Convert.ToString(ObjLocSqlParameters[35].Value);
                                ClsRD.ProPubStrRequestID = Convert.ToString(ObjLocSqlParameters[34].Value);
                                ClsRD.ProPubStrTempID = Convert.ToString(ObjLocSqlParameters[37].Value);
                                ClsRD.ProPubStrTicketId = Convert.ToString(ObjLocSqlParameters[36].Value);
                                ClsRD.ProPubStrPendingWith = Convert.ToString(ObjLocSqlParameters[38].Value);
                                ClsRD.ProPubStrPendingRollcd = Convert.ToString(ObjLocSqlParameters[39].Value);
                                ClsRD.ProPubStrPendingEmpcd = Convert.ToString(ObjLocSqlParameters[40].Value);

                                ObjLocRequestData.Add(ClsRD);
                            }

                        }

                        return ObjLocRequestData;

                    }

                    else
                    {
                        throw new Exception("Workflow does not exists for this combination.");
                    }
                }

                else
                {
                    throw new Exception("Temp Id already exist");
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            finally
            {

                DsLocDataSet = null;
            }

        }


        /// <summary>
        /// Function is used to fetch checklist holder name
        /// </summary>
        /// <param name="StrDepartment"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ClsCheckListHolder> FunPubFetchChkHolder(string StrDepartment)
        {
            List<ClsCheckListHolder> ObjchkListHolder = new List<ClsCheckListHolder>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;
            try
            {

                if (StrDepartment == null)
                    StrDepartment = "";

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[2];
                ObjLocSqlParameter[0] = new SqlParameter("@DepartmentName", StrDepartment);
                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_fetchChkHolderNameOnDept", ObjLocSqlParameter);

                if (DsLocDataSet != null)
                {
                    if (DsLocDataSet.Tables.Count > 0)
                    {
                        if (DsLocDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjchkListHolder = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                                select new ClsCheckListHolder
                                                {
                                                    ProPubStrChkListId = Convert.ToString(p.Field<Int32>("ChId")),
                                                    ProPubStrChkListHolder = p.Field<string>("CheckListHolder")
                                                }).ToList();
                            return ObjchkListHolder;
                        }
                    }
                    else
                    {
                        return ObjchkListHolder;
                    }
                }
                else
                {
                    return ObjchkListHolder;
                }
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsLocDataSet = null;
                ObjchkListHolder = null;
            }

        }

        /// <summary>
        /// Function is used for to send checklist Request
        /// Modified By Ravindra Muthe on 12-Dec-2018
        /// </summary>
        /// <param name="StrGroupID"></param>
        /// <param name="StrCompanyID"></param>
        /// <param name="StrDepartmentName"></param>
        /// <param name="StrChkListHolderId"></param>
        /// <param name="StrScheduleDate"></param>
        /// <param name="StrStartTime"></param>
        /// <returns></returns>

        [HttpGet]
        public ClsCheck FunPubSendChkRequest(string StrGroupID, string StrCompanyID, string StrUnitID, string StrLocationID, string StrSubLocationID, string QRrequest, string StrDepartmentName, string StrChkListHolderId, string StrScheduleDate, string StrStartTime, string StrUsername)
        {
            ClsCheck objlocClsCheck = new ClsCheck();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;
            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter1 = new SqlParameter[3];
                ObjLocSqlParameter1[0] = new SqlParameter("@ChkHolderId", StrChkListHolderId);
                ObjLocSqlParameter1[1] = new SqlParameter("@Outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter1[1].Direction = ParameterDirection.Output;
                ObjLocSqlParameter1[2] = new SqlParameter("@Outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter1[2].Direction = ParameterDirection.Output;
                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchChkRequest", ObjLocSqlParameter1);

                bool Outbit = Convert.ToBoolean(ObjLocSqlParameter1[1].Value);

                if (Outbit == true)
                {
                    try
                    {
                        StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                        SqlParameter[] ObjLocSqlParameter = new SqlParameter[16];
                        ObjLocSqlParameter[0] = new SqlParameter("@GroupID", StrGroupID);
                        ObjLocSqlParameter[1] = new SqlParameter("@CompanyID", StrCompanyID);
                        ObjLocSqlParameter[2] = new SqlParameter("@DepartmentName", StrDepartmentName);
                        ObjLocSqlParameter[3] = new SqlParameter("@CheckListHolderId", StrChkListHolderId);
                        ObjLocSqlParameter[4] = new SqlParameter("@ScheduleDate", StrScheduleDate);
                        ObjLocSqlParameter[5] = new SqlParameter("@Priority", "High");
                        ObjLocSqlParameter[6] = new SqlParameter("@Frequency", "Daily");
                        ObjLocSqlParameter[7] = new SqlParameter("@StartTime", StrStartTime);
                        ObjLocSqlParameter[8] = new SqlParameter("@UnitID", StrUnitID);
                        ObjLocSqlParameter[9] = new SqlParameter("@LocationID", StrLocationID);
                        ObjLocSqlParameter[10] = new SqlParameter("@SubLocationID", StrSubLocationID);
                        ObjLocSqlParameter[11] = new SqlParameter("@QR_Request", QRrequest);
                        ObjLocSqlParameter[12] = new SqlParameter("@Username", StrUsername);
                        ObjLocSqlParameter[13] = new SqlParameter("@Outbit", SqlDbType.Bit, 1);
                        ObjLocSqlParameter[13].Direction = ParameterDirection.Output;
                        ObjLocSqlParameter[14] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 100);
                        ObjLocSqlParameter[14].Direction = ParameterDirection.Output;
                        ObjLocSqlParameter[15] = new SqlParameter("@ticketid", SqlDbType.VarChar, 100);
                        ObjLocSqlParameter[15].Direction = ParameterDirection.Output;
                        DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_SaveFetchMyCheckListMst", ObjLocSqlParameter);

                        string ChkListRequestId = DsLocDataSet.Tables[0].Rows[0]["ChkListRequestId"].ToString();
                        string ChkTransactionId = DsLocDataSet.Tables[0].Rows[0]["ChkTransactionId"].ToString();
                        if (ChkListRequestId != null && ChkTransactionId != null)
                        {
                            objlocClsCheck = FunPubCheckListData(ChkListRequestId, ChkTransactionId);
                            return objlocClsCheck;
                        }
                        else
                        {
                            return objlocClsCheck;
                        }
                        throw new Exception("Error while processing request.");
                    }
                    catch (Exception Ex)
                    {
                        throw new Exception(Ex.Message);
                    }
                }
                else
                {
                    return objlocClsCheck;
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            finally
            {
                DsLocDataSet = null;
            }
        }




        /// <summary>
        /// Function Created For Fetching Chklist Department For Mobile
        /// Created By Ravindra Muthe on 22-Feb-2019
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ClsDepartment> FunPubFetchDepartment(string StrRollcd, string StrEmpcd)
        {
            List<ClsDepartment> objlocClsDepartment = new List<ClsDepartment>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDSDepartment = new DataSet();
            string StrLocConnection = null;
            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[2];
                ObjLocSqlParameter[0] = new SqlParameter("@Rollcd", StrRollcd);
                ObjLocSqlParameter[1] = new SqlParameter("@Empcd", StrEmpcd);
                DsLocDSDepartment = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchDepartment", ObjLocSqlParameter);
                if (DsLocDSDepartment != null)
                {
                    if (DsLocDSDepartment.Tables.Count > 0)
                    {
                        if (DsLocDSDepartment.Tables[0].Rows.Count > 0)
                        {
                            objlocClsDepartment = (from p in DsLocDSDepartment.Tables[0].AsEnumerable()
                                                   select new ClsDepartment
                                                   {
                                                       ProPubStrDepartment = p.Field<string>("DepartmentName")
                                                   }).ToList();
                            return objlocClsDepartment;

                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
                throw new Exception("Error while processing request.");
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDSDepartment = null;
                objlocClsDepartment = null;
            }
        }









        /// <summary>
        /// Function Created For Fetching Chklist Image For Mobile
        /// Created By Ravindra Muthe on 22-Feb-2019
        /// </summary>
        /// <param name="StrChkListRequestId"></param>
        /// <returns></returns>
        [HttpGet]
        public ClsChkList FunPubFetchChkListImage(string StrChkListRequestId)
        {
            List<ClsChkList> objlocClsChkList = new List<ClsChkList>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDSChkList = new DataSet();
            string StrLocConnection = null;
            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[1];
                ObjLocSqlParameter[0] = new SqlParameter("@Id", StrChkListRequestId);
                DsLocDSChkList = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_Fetch_chkListImageMobile", ObjLocSqlParameter);
                if (DsLocDSChkList != null)
                {
                    if (DsLocDSChkList.Tables.Count > 0)
                    {
                        if (DsLocDSChkList.Tables[0].Rows.Count > 0)
                        {
                            objlocClsChkList = (from s in DsLocDSChkList.Tables[0].AsEnumerable()
                                                select new ClsChkList
                                                {
                                                    // ProPubStrImagePath = Convert.ToString(s.Field<Int32>("ImgPath"))
                                                    ProPubStrImagePath = "0x" + BitConverter.ToString(s.Field<Byte[]>("ImgPath")).Replace("-", string.Empty),

                                                }).ToList();
                            return objlocClsChkList[0];

                        }
                        //throw new Exception("Error while processing request.");
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
                throw new Exception("Error while processing request.");
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDSChkList = null;
                objlocClsChkList = null;
            }
        }


        /// <summary>
        /// Function is used for to send checklist Request
        /// Modified By Ravindra Muthe on 12-Dec-2018
        /// </summary>
        /// <param name="StrGroupID"></param>
        /// <param name="StrCompanyID"></param>
        /// <param name="StrDepartmentName"></param>
        /// <param name="StrChkListHolderId"></param>
        /// <param name="StrScheduleDate"></param>
        /// <param name="StrStartTime"></param>
        /// <returns></returns>
        [HttpGet]
        public ClsCheck FunPubTakeChkActionable(string StrChkListRequestId, string StrChkTransactionId)
        {
            ClsCheck objlocClsCheck = new ClsCheck();
            ClsCommunication ObjLocComm = new ClsCommunication();
            string ChkListRequestId = StrChkListRequestId;
            string ChkTransactionId = StrChkTransactionId;
            try
            {
                if (ChkListRequestId != null && ChkTransactionId != null)
                {
                    objlocClsCheck = FunPubCheckListData(ChkListRequestId, ChkTransactionId);
                    return objlocClsCheck;
                }
                else
                {
                    return objlocClsCheck;
                }
                throw new Exception("Error while processing request.");
            }

            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }

        }

        private ClsCheck FunPubCheckListData(string ChkListRequestId, string ChkTransactionId)
        {
            ClsCheck objlocClsCheck = new ClsCheck();
            List<ClsCheckListData> objClsCheckListData = new List<ClsCheckListData>();
            List<ClsCheckList> objCheckList = new List<ClsCheckList>();
            List<ClsCheckRadio> ObjClsCheckRadio = new List<ClsCheckRadio>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDSChkListData = new DataSet();
            DataSet DsLocDSChkList = new DataSet();
            DataSet DsLocDSChkRadio = new DataSet();
            string StrLocConnection = null;
            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter1 = new SqlParameter[2];
                ObjLocSqlParameter1[0] = new SqlParameter("@Id", ChkListRequestId);
                DsLocDSChkListData = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_Fetch_fetchChklistRequest", ObjLocSqlParameter1);
                if (DsLocDSChkListData != null)
                {
                    if (DsLocDSChkListData.Tables.Count > 0)
                    {
                        if (DsLocDSChkListData.Tables[0].Rows.Count > 0)
                        {
                            objClsCheckListData = (from p in DsLocDSChkListData.Tables[0].AsEnumerable()
                                                   select new ClsCheckListData
                                                   {
                                                       ProPubStrCheckListHolder = p.Field<string>("CheckListHolder"),
                                                       ProPubStrCompanyDesc = p.Field<string>("CompanyDesc"),
                                                       ProPubStrDepartmentName = p.Field<string>("DepartmentName"),
                                                       ProPubStrFrequency = p.Field<string>("Frequency"),
                                                       ProPubStrGroupDesc = p.Field<string>("GroupDesc"),
                                                       ProPubStrPriority = p.Field<string>("Priority"),
                                                       ProPubStrScheduleDate = Convert.ToString(p.Field<DateTime>("ScheduleDate")),
                                                       ProPubStrStartTime = p.Field<string>("StartTime"),
                                                       ProPubStrTicketId = p.Field<string>("TicketId"),
                                                       ProPubStrUsername = p.Field<string>("Username"),
                                                       ProPubStrZone = p.Field<string>("Zone"),                                    //Added By RV on 15-April-2019
                                                       ProPubStrLocation = p.Field<string>("Location"),                           //Added By RV on 15-April-2019
                                                       ProPubStrSubLocation = p.Field<string>("SubLocation"),                     //Added By RV on 15-April-2019
                                                       ProPubStrZoneID = Convert.ToString(p.Field<Decimal>("ZoneID")),                     //Added By RV on 31-July-2019
                                                       ProPubStrLocationID = Convert.ToString(p.Field<Decimal>("LocationID")),                     //Added By RV on 31-July-2019
                                                       ProPubStrSubLocationID = Convert.ToString(p.Field<Decimal>("SubLocationID")),                     //Added By RV on 31-July-2019
                                                       ProPubStrTransactionID = ChkTransactionId
                                                   }).ToList();

                            string TicketId = DsLocDSChkListData.Tables[0].Rows[0]["TicketId"].ToString();

                            SqlParameter[] ObjLocSqlParameter2 = new SqlParameter[3];
                            ObjLocSqlParameter2[0] = new SqlParameter("@Id", ChkListRequestId);
                            ObjLocSqlParameter2[1] = new SqlParameter("@TicketId", TicketId);
                            DsLocDSChkList = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_Fetch_chkListForCheckMobile", ObjLocSqlParameter2);
                            if (DsLocDSChkList != null)
                            {
                                if (DsLocDSChkList.Tables.Count > 0)
                                {
                                    if (DsLocDSChkList.Tables[0].Rows.Count > 0)
                                    {
                                        objCheckList = (from s in DsLocDSChkList.Tables[0].AsEnumerable()
                                                        select new ClsCheckList
                                                        {
                                                            ProPubStrCheckID = Convert.ToString(s.Field<Int32>("CheckID")),
                                                            ProPubStrChekList = s.Field<string>("CheckList"),
                                                            ProPubStrId = Convert.ToString(s.Field<Int32>("Id")),
                                                            ProPubStrImagePath = Convert.ToString(s.Field<Int32>("ImgPath")),
                                                            // ProPubStrImagePath = "0x" + BitConverter.ToString(s.Field<Byte[]>("ImgPath")).Replace("-", string.Empty),
                                                            ProPubStrRemark = s.Field<string>("Remark"),
                                                            ProPubStrWeigthage = Convert.ToString(s.Field<decimal>("Weightege")),
                                                            ProPubStrChkImgRequired = Convert.ToString(s.Field<string>("ImageRequired"))

                                                        }).ToList();


                                        SqlParameter[] ObjLocSqlParameter3 = new SqlParameter[2];
                                        ObjLocSqlParameter3[0] = new SqlParameter("@CheckListId", TicketId);
                                        DsLocDSChkRadio = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_FetchchkListForRadioButton", ObjLocSqlParameter3);
                                        if (DsLocDSChkRadio != null)
                                        {
                                            if (DsLocDSChkRadio.Tables[0].Rows.Count > 0)
                                            {
                                                ObjClsCheckRadio = (from s in DsLocDSChkRadio.Tables[0].AsEnumerable()
                                                                    select new ClsCheckRadio
                                                                    {
                                                                        ProPubStrCktId = s.Field<string>("CktId"),
                                                                        ProPubStrChekListID = Convert.ToString(s.Field<Int32>("CheckListId")),
                                                                        ProPubStrId = Convert.ToString(s.Field<Int32>("Id")),
                                                                        ProPubStrNo = Convert.ToString(s.Field<Boolean>("No")),
                                                                        ProPubStrYes = Convert.ToString(s.Field<Boolean>("Yes")),
                                                                        ProPubStrNA = Convert.ToString(s.Field<Boolean>("NA"))                        //Added By Ravindra Muthe on 09-April-2019
                                                                    }).ToList();

                                                objlocClsCheck = new ClsCheck() { CheckListData = objClsCheckListData, CheckList = objCheckList, CheckListRadio = ObjClsCheckRadio };
                                                return objlocClsCheck;
                                            }

                                        }


                                    }
                                }
                            }
                            return objlocClsCheck;
                        }

                    }
                    return objlocClsCheck;
                }
                throw new Exception("Error while processing request.");
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
        }


        /// <summary>
        /// Function is used for Close CheckList Request
        /// </summary>
        /// <param name="StrTicketID"></param>
        /// <param name="StrChkListRequestId"></param>
        /// <param name="StrYes"></param>
        /// <param name="StrNo"></param>
        /// <param name="StrRemark"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubCloseChkRequest(string StrTicketID, string StrId, string StrYes, string StrNo, string StrRemark, string StrCheckListId, string StrChkTransactionId)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (StrTicketID == null)
                    StrTicketID = "0";
                if (StrId == null)
                    StrId = "0";
                if (StrYes == null)
                    StrYes = "0";
                if (StrNo == null)
                    StrNo = "0";
                if (StrRemark == null)
                    StrRemark = "";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[5];
                ObjLocSqlParameter[0] = new SqlParameter("@TicketId", StrTicketID);
                ObjLocSqlParameter[1] = new SqlParameter("@ParkedId", StrId);
                ObjLocSqlParameter[2] = new SqlParameter("@RadioButtonValue1", StrYes);
                ObjLocSqlParameter[3] = new SqlParameter("@RadioButtonValue2", StrNo);
                ObjLocSqlParameter[4] = new SqlParameter("@RemarkData", StrRemark);

                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_SaveRadioBtn", ObjLocSqlParameter);

                /***Added by Ravindra on 19-Dec-2017 to Close CheckList   ***/
                SqlParameter[] ObjLocSqlParameter1 = new SqlParameter[6];
                ObjLocSqlParameter1[0] = new SqlParameter("@TicketId", StrTicketID);
                ObjLocSqlParameter1[1] = new SqlParameter("@CheckListId", StrCheckListId);
                ObjLocSqlParameter1[2] = new SqlParameter("@RadioButtonValue1", StrYes);
                ObjLocSqlParameter1[3] = new SqlParameter("@RadioButtonValue2", StrNo);
                ObjLocSqlParameter1[4] = new SqlParameter("@TotalWeightage", Convert.ToString("0"));  /* No need to Send TotalWeightage it will handle in Procedure level */
                ObjLocSqlParameter1[5] = new SqlParameter("@ChkTransactionId", StrChkTransactionId);
                // ObjLocSqlParameter1[6] = new SqlParameter("@Username", StrUsername);     

                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_FunInsertCheckListRequestData", ObjLocSqlParameter1);
                /********************************/
                string StrStatus = "CheckList Request Close Successfully.....";
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }




        /// <summary>
        /// Function is used for Close CheckList Request for Mobile App
        /// Created By Ravindra Muthe on 21-Dec-2018
        /// </summary>
        /// <param name="StrTicketID"></param>
        /// <param name="StrId"></param>
        /// <param name="StrYes"></param>
        /// <param name="StrNo"></param>
        /// <param name="StrRemark"></param>
        /// <param name="StrCheckListId"></param>
        /// <param name="StrChkTransactionId"></param>
        /// <returns></returns>
        /// Edited By Tanmay Pradhan on 09-April-2019
        [HttpPost]
        public string FunPubCloseChkRequestMobile([FromBody] ClsSaveChckDetails Chkdetails)
        {

            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;
            string[] StrIdArray = Chkdetails.StrId.Split(',');
            string[] StrYesArray = Chkdetails.StrYes.Split(',');
            string[] StrNoArray = Chkdetails.StrNo.Split(',');
            string[] StrNAArray = Chkdetails.StrNA.Split(',');
            string[] StrRemarkArray = Chkdetails.StrRemark.Split(',');
            string[] StrCheckListIdArray = Chkdetails.StrCheckListId.Split(',');
            // string[] StrChkTransactionIdArray = StrChkTransactionId.Split(',');

            try
            {
                if (Chkdetails.StrTicketID == null)
                    Chkdetails.StrTicketID = "0";
                //if (StrId == null)
                //    StrId = "0";
                //if (StrYes == null)
                //    StrYes = "0";
                //if (StrNo == null)
                //    StrNo = "0";
                if (Chkdetails.StrRemark == null)
                    Chkdetails.StrRemark = "";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);



                for (int i = 0; i < StrIdArray.Length; i++)
                {
                    SqlParameter[] ObjLocSqlParameter = new SqlParameter[6];
                    ObjLocSqlParameter[0] = new SqlParameter("@TicketId", Chkdetails.StrTicketID);
                    ObjLocSqlParameter[1] = new SqlParameter("@RemarkData", StrRemarkArray[i]);
                    ObjLocSqlParameter[2] = new SqlParameter("@ParkedId", StrIdArray[i]);
                    ObjLocSqlParameter[3] = new SqlParameter("@RadioButtonValue1", StrYesArray[i]);
                    ObjLocSqlParameter[4] = new SqlParameter("@RadioButtonValue2", StrNoArray[i]);
                    ObjLocSqlParameter[5] = new SqlParameter("@RadioButtonValue3", StrNAArray[i]);

                    ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_SaveRadioBtn", ObjLocSqlParameter);
                }

                /***Added by Ravindra on 19-Dec-2017 to Close CheckList   ***/


                for (int i = 0; i < StrIdArray.Length; i++)
                {
                    SqlParameter[] ObjLocSqlParameter1 = new SqlParameter[7];
                    ObjLocSqlParameter1[0] = new SqlParameter("@TicketId", Chkdetails.StrTicketID);
                    ObjLocSqlParameter1[1] = new SqlParameter("@TotalWeightage", Convert.ToString("0"));
                    ObjLocSqlParameter1[2] = new SqlParameter("@CheckListId", StrCheckListIdArray[i]);
                    ObjLocSqlParameter1[3] = new SqlParameter("@RadioButtonValue1", StrYesArray[i]);
                    ObjLocSqlParameter1[4] = new SqlParameter("@RadioButtonValue2", StrNoArray[i]);
                    ObjLocSqlParameter1[5] = new SqlParameter("@RadioButtonValue3", StrNAArray[i]);
                    /* No need to Send TotalWeightage it will handle in Procedure level */
                    ObjLocSqlParameter1[6] = new SqlParameter("@ChkTransactionId", Chkdetails.StrChkTransactionId);
                    // ObjLocSqlParameter1[6] = new SqlParameter("@Username", StrUsername);     

                    ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_FunInsertCheckListRequestData", ObjLocSqlParameter1);
                }
                /********************************/
                string StrStatus = "CheckList Request Close Successfully.....";
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }







        /// <summary>
        /// Function is used for Close CheckList Request Offline
        /// </summary>
        /// <param name="StrTicketID"></param>
        /// <param name="StrChkListRequestId"></param>
        /// <param name="StrYes"></param>
        /// <param name="StrNo"></param>
        /// <param name="StrRemark"></param>
        /// <param name="StrId"></param>
        /// <param name="TempID"></param>
        /// <param name="Username"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ClsCheckListOFFline> FunPubCloseChkRequestOffline(string StrTicketID, string StrId, string StrYes, string StrNo, string StrRemark, string StrTempID, string StrUsername, string StrCheckListId, string StrChkTransactionId)
        {
            List<ClsCheckListOFFline> objClsCheckListOFFline = new List<ClsCheckListOFFline>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (StrTicketID == null)
                    StrTicketID = "0";
                if (StrId == null)
                    StrId = "0";
                if (StrYes == null)
                    StrYes = "0";
                if (StrNo == null)
                    StrNo = "0";
                if (StrRemark == null)
                    StrRemark = "";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[7];
                ObjLocSqlParameter[0] = new SqlParameter("@TicketId", StrTicketID);
                ObjLocSqlParameter[1] = new SqlParameter("@ParkedId", StrId);
                ObjLocSqlParameter[2] = new SqlParameter("@RadioButtonValue1", StrYes);
                ObjLocSqlParameter[3] = new SqlParameter("@RadioButtonValue2", StrNo);
                ObjLocSqlParameter[4] = new SqlParameter("@RemarkData", StrRemark);
                ObjLocSqlParameter[5] = new SqlParameter("@TempID", StrTempID);
                ObjLocSqlParameter[6] = new SqlParameter("@Username", StrUsername);

                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_SaveRadioBtn_offline", ObjLocSqlParameter);
                if (DsLocDataSet != null)
                {

                    /***Added by Ravindra on 19-Dec-2017 to Close CheckList   ***/
                    SqlParameter[] ObjLocSqlParameter1 = new SqlParameter[6];
                    ObjLocSqlParameter1[0] = new SqlParameter("@TicketId", StrTicketID);
                    ObjLocSqlParameter1[1] = new SqlParameter("@CheckListId", StrCheckListId);
                    ObjLocSqlParameter1[2] = new SqlParameter("@RadioButtonValue1", StrYes);
                    ObjLocSqlParameter1[3] = new SqlParameter("@RadioButtonValue2", StrNo);
                    ObjLocSqlParameter1[4] = new SqlParameter("@TotalWeightage", Convert.ToString("0"));  /* No need to Send TotalWeightage it will handle in Procedure level */
                    ObjLocSqlParameter1[5] = new SqlParameter("@ChkTransactionId", StrChkTransactionId);

                    ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_FunInsertCheckListRequestData", ObjLocSqlParameter1);
                    /********************************/
                    if (DsLocDataSet.Tables.Count > 0)
                    {
                        if (DsLocDataSet.Tables[0].Rows.Count > 0)
                        {
                            objClsCheckListOFFline = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                                      select new ClsCheckListOFFline
                                                      {
                                                          ProPubStrCheckListHolder = p.Field<string>("CheckListHolder"),
                                                          ProPubStrCompanyDesc = p.Field<string>("CompanyDesc"),
                                                          ProPubStrDepartmentName = p.Field<string>("DepartmentName"),
                                                          ProPubStrGroupDesc = p.Field<string>("GroupDesc"),
                                                          ProPubStrTicketId = p.Field<string>("TicketId"),
                                                          ProPubStrTempID = p.Field<string>("TempID")
                                                      }).ToList();


                            return objClsCheckListOFFline;
                        }
                        else
                        {
                            return objClsCheckListOFFline;
                        }
                    }
                    else
                    {
                        return objClsCheckListOFFline;
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
                DsLocDataSet = null;

            }
        }



        /// <summary>
        /// Function is used to fetch all Data For Mobile Dashboard
        /// Added By Tanmay Pradhan on 15-Feb-2019
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ClsMobileDashboard FunPubFetchMobileDashboard(string StrRollCD, string StrEmpCD)
        {
            ClsMobileDashboard ObjLocGroupList = new ClsMobileDashboard();
            CLsRequestDashboard reqDash = new CLsRequestDashboard();
            CLsChecklistDashboard chkDash = new CLsChecklistDashboard();
            ClsCommunication objLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;
            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[2];
                ObjLocSqlParameter[0] = new SqlParameter("@rollcd", StrRollCD);
                ObjLocSqlParameter[1] = new SqlParameter("@empcd", StrEmpCD);
                DsLocDataSet = objLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchMobileDashboard", ObjLocSqlParameter);

                if ((DsLocDataSet != null))
                {
                    if (DsLocDataSet.Tables[0].Rows.Count > 0)
                    {
                        reqDash.ProPubStrOpen = Convert.ToString(DsLocDataSet.Tables[0].Rows[0]["OpenRequest"]);
                    }
                    else
                    {
                        reqDash.ProPubStrOpen = "0";
                    }

                    if (DsLocDataSet.Tables[1].Rows.Count > 0)
                    {
                        reqDash.ProPubStrClose = Convert.ToString(DsLocDataSet.Tables[1].Rows[0]["CloseRequest"]);
                    }
                    else
                    {
                        reqDash.ProPubStrClose = "0";
                    }

                    ObjLocGroupList.clsReqDashboard = reqDash;

                    if (DsLocDataSet.Tables[2].Rows.Count > 0)
                    {
                        chkDash.ProPubStrOpen = Convert.ToString(DsLocDataSet.Tables[2].Rows[0]["OpenChecklist"]);
                    }
                    else
                    {
                        chkDash.ProPubStrOpen = "0";
                    }

                    if (DsLocDataSet.Tables[3].Rows.Count > 0)
                    {
                        chkDash.ProPubStrClose = Convert.ToString(DsLocDataSet.Tables[3].Rows[0]["CloseChecklist"]);
                    }
                    else
                    {
                        chkDash.ProPubStrClose = "0";
                    }
                    ObjLocGroupList.clsChkDashboard = chkDash;

                    return ObjLocGroupList;
                }

                throw new Exception("Error while processing request.");

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;
                ObjLocGroupList = null;
            }


        }












        /// <summary>
        /// Function is used to fetch My Actionable CheckList
        /// Modified By Ravindra Muthe on 12-Dec-2018
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public List<ClsCheckActionable> FunPubFetchMyChkListActionable(string StrRollcd, string StrEmpcd)
        {
            List<ClsCheckActionable> ObjLocGroupList = new List<ClsCheckActionable>();
            ClsCommunication objLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;
            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[2];
                ObjLocSqlParameter[0] = new SqlParameter("@Rollcd", StrRollcd);
                ObjLocSqlParameter[1] = new SqlParameter("@Empcd", StrEmpcd);
                DsLocDataSet = objLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchCheckListRequestmstforAdmin", ObjLocSqlParameter);

                if ((DsLocDataSet != null))
                {
                    if (DsLocDataSet.Tables[0].Rows.Count > 0)
                    {
                        ObjLocGroupList = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                           select new ClsCheckActionable
                                           {
                                               ProPubStrCheckListHolder = p.Field<string>("CheckListHolder"),
                                               ProPubStrChkTransactionId = Convert.ToString(p.Field<Int32>("ChkTransactionId")),
                                               ProPubStrCktListRequestId = Convert.ToString(p.Field<Int32>("ChkListRequestId")),
                                               ProPubStrEndTime = p.Field<string>("EndTime"),
                                               ProPubStrRequestStatus = p.Field<string>("Requeststatus"),
                                               ProPubStrScheduleDate = p.Field<string>("ScheduleDate"),
                                               ProPubStrStartTime = p.Field<string>("StartTime"),
                                               ProPubStrStatus = p.Field<string>("Status"),
                                               ProPubStrTicketID = p.Field<string>("TicketId"),
                                               ProPubStrDepartmentName = p.Field<string>("DepartmentName"),
                                               ProPubStrUsername = p.Field<string>("Username")

                                           }).ToList();
                        return ObjLocGroupList;
                    }
                    else
                    {
                        return ObjLocGroupList;
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
                DsLocDataSet = null;
                ObjLocGroupList = null;
            }


        }



        /// <summary>
        /// Function is used to fetch Pending CheckList
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ClsCheckListPending> FunPubFetchPendingCheckList()
        {
            List<ClsCheckListPending> ObjLocGroupList = new List<ClsCheckListPending>();
            ClsCommunication objLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;
            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                DsLocDataSet = objLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_FetchPendingCheckListPoints");

                if ((DsLocDataSet != null))
                {
                    if (DsLocDataSet.Tables[0].Rows.Count > 0)
                    {
                        ObjLocGroupList = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                           select new ClsCheckListPending
                                           {
                                               ProPubStrPrkId = p.Field<string>("parkid"),
                                               ProPubStrCompanyDesc = p.Field<string>("CompanyDesc"),
                                               ProPubStrCategoryDesc = p.Field<string>("CategoryDesc"),
                                               ProPubStrCheckList = p.Field<string>("checklist"),
                                               ProPubStrCheckListHolder = p.Field<string>("CheckListHolder"),
                                               ProPubStrScheduleDate = p.Field<string>("ScheduleDate"),
                                               ProPubStrRemark = p.Field<string>("Remark"),
                                               proPubImgPath = "0x" + BitConverter.ToString(p.Field<Byte[]>("ImgPath")).Replace("-", string.Empty),
                                               ProPubStrRequestStatus = p.Field<string>("requeststatus")




                                           }).ToList();
                        return ObjLocGroupList;
                    }
                    else
                    {
                        return ObjLocGroupList;
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
                DsLocDataSet = null;
                ObjLocGroupList = null;
            }


        }


        /// <summary>
        /// Function created for Fecthing CheckList Report
        /// </summary>
        /// <returns></returns>
        /// 

        [HttpGet]
        public ClsCheckReport FunPubTakeCheckListReport(string StrRequeststatus, string StrFromDate, string StrToDate)
        {
            ClsCheckReport objlocClsCheck = new ClsCheckReport();
            ClsCommunication ObjLocComm = new ClsCommunication();
            string Requeststatus = StrRequeststatus;
            string FromDate = StrFromDate;
            string ToDate = StrToDate;

            try
            {
                if (Requeststatus != null && FromDate != null && ToDate != null)
                {
                    objlocClsCheck = FunFetchCheckListReport(Requeststatus, FromDate, ToDate);
                    return objlocClsCheck;
                }
                else
                {
                    return objlocClsCheck;
                }
                throw new Exception("Error while processing request.");
            }

            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }

        }


        [HttpGet]
        private ClsCheckReport FunFetchCheckListReport(string StrRequeststatus, string StrFromDate, string StrToDate)
        {
            ClsCheckReport ObjChekReport = new ClsCheckReport();
            List<ClsCheckListReportData> ObjCheckListReport = new List<ClsCheckListReportData>();
            List<ClsCheckListReportDataForChart> ObjCheckListReportForChart = new List<ClsCheckListReportDataForChart>();
            ClsCommunication objLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            DataSet DsChkForChart = new DataSet();
            string StrLocConnection = null;
            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@Requeststatus", StrRequeststatus);
                ObjLocSqlParameter[1] = new SqlParameter("@FromDate", StrFromDate);
                ObjLocSqlParameter[2] = new SqlParameter("@ToDate", StrToDate);
                DsLocDataSet = objLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchCheckListReport", ObjLocSqlParameter);
                if ((DsLocDataSet != null))
                {
                    if (DsLocDataSet.Tables[0].Rows.Count > 0)
                    {
                        ObjCheckListReport = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                              select new ClsCheckListReportData
                                              {
                                                  ProPubTicketID = p.Field<string>("TicketId"),
                                                  ProPubGroupDesc = p.Field<string>("GroupDesc"),
                                                  ProPubCompanyDesc = p.Field<string>("CompanyDesc"),
                                                  ProPubDepartmentName = p.Field<string>("DepartmentName"),
                                                  ProPubCheckListHolder = p.Field<string>("CheckListHolder"),
                                                  ProPubScheduleDate = p.Field<string>("ScheduleDate"),
                                                  ProPubPriority = p.Field<string>("Priority"),
                                                  ProPubFrequency = p.Field<string>("Frequency"),
                                                  ProPubStartTime = p.Field<string>("StartTime"),
                                                  ProPubEndTime = p.Field<string>("EndTime"),
                                                  ProPubRequeststatus = p.Field<string>("Requeststatus")


                                              }).ToList();

                        SqlParameter[] ObjLocSqlParameter1 = new SqlParameter[3];
                        ObjLocSqlParameter1[0] = new SqlParameter("@Requeststatus", StrRequeststatus);
                        ObjLocSqlParameter1[1] = new SqlParameter("@FromDate", StrFromDate);
                        ObjLocSqlParameter1[2] = new SqlParameter("@ToDate", StrToDate);

                        DsChkForChart = objLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchCheckListReport", ObjLocSqlParameter1);
                        if ((DsChkForChart != null))
                        {
                            if (DsChkForChart.Tables[1].Rows.Count > 0)
                            {
                                ObjCheckListReportForChart = (from p in DsChkForChart.Tables[1].AsEnumerable()
                                                              select new ClsCheckListReportDataForChart
                                                              {
                                                                  ProPubCheckListHolder = p.Field<string>("CheckListHolder"),
                                                                  ProPubCheckListCount = p.Field<int>("CheckListCount")

                                                              }).ToList();



                                ObjChekReport = new ClsCheckReport() { CheckListData1 = ObjCheckListReport, CheckList1 = ObjCheckListReportForChart };
                                return ObjChekReport;
                            }
                        }
                    }
                    return ObjChekReport;
                }
                throw new Exception("Error while processing request.");

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;
                ObjCheckListReport = null;
            }

        }

        [HttpGet]
        public List<ClsCheckListWiseReport> FunFetchCheckListWiseReport(string StrCheckListId, string StrDate)
        {
            List<ClsCheckListWiseReport> ObjCheckListDetail = new List<ClsCheckListWiseReport>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet ObjDs = new DataSet();

            string RequestStatus = StrCheckListId;
            string ChkDate = StrDate;
            string StrLocConnection = null;
            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                if (RequestStatus != null && ChkDate != null)
                {
                    SqlParameter[] ObjLocSqlParameter = new SqlParameter[2];
                    ObjLocSqlParameter[0] = new SqlParameter("@CheckListID", RequestStatus);
                    ObjLocSqlParameter[1] = new SqlParameter("@Date", ChkDate);
                    ObjDs = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_CheckListWiseReport", ObjLocSqlParameter);
                    if (ObjDs.Tables[0].Rows.Count > 0)
                    {
                        ObjCheckListDetail = (from p in ObjDs.Tables[0].AsEnumerable()
                                              select new ClsCheckListWiseReport
                                              {
                                                  ProPubCHECKLIST = p.Field<string>("CHECKLIST"),
                                                  ProPubYES = Convert.ToString(p.Field<Boolean>("YES")),
                                                  ProPubNO = Convert.ToString(p.Field<Boolean>("NO")),
                                                  ProPubREMARK = p.Field<string>("REMARK")

                                              }).ToList();
                        return ObjCheckListDetail;
                    }
                    else
                    {
                        return ObjCheckListDetail;
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
                ObjCheckListDetail = null;
                ObjDs = null;
            }
        }

        [HttpGet]
        public List<ClsCountCKTandTKT> FunPubFetchCountTKTandCKT()
        {
            List<ClsCountCKTandTKT> ObjLocGroupList = new List<ClsCountCKTandTKT>();
            ClsCommunication objLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;
            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                DsLocDataSet = objLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_CountTKTandCKTNew");

                if ((DsLocDataSet != null))
                {
                    if (DsLocDataSet.Tables[0].Rows.Count > 0)
                    {
                        ObjLocGroupList = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                           select new ClsCountCKTandTKT
                                           {
                                               ProPubTotalTicket = p.Field<string>("TotalTicket"),
                                               ProPubOpenTicket = p.Field<string>("OpenTicket"),
                                               ProPubCloseTicket = p.Field<string>("CloseTicket"),
                                               ProPubTotalCheckList = p.Field<string>("TotalCheckList"),
                                               ProPubOpenCheckList = p.Field<string>("OpenCheckList"),
                                               ProPubClosedCheckList = p.Field<string>("ClosedCheckList")


                                           }).ToList();
                        return ObjLocGroupList;
                    }
                    else
                    {
                        return ObjLocGroupList;
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
                DsLocDataSet = null;
                ObjLocGroupList = null;
            }


        }


        [HttpGet]
        public string FunPubsaveParkedChanges(string StrparkedId)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            if (StrparkedId == null)
            {
                StrparkedId = "0";
            }


            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@parkedId", StrparkedId);
                ObjLocSqlParameter[1] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[1].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[2] = new SqlParameter("@outmsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[2].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_saveParkedChanges", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[2].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }


        [HttpGet]
        public List<ClsReportTicketRaised> FunPubFetchReportTicketRaised(string StrCategoryId, string StrSubCategoryId, string StrUnitID, string strDeptId, string strFromDate, string strToDate, string strUserName)
        {
            List<ClsReportTicketRaised> ObjLocGroupList = new List<ClsReportTicketRaised>();
            ClsCommunication objLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            if (StrCategoryId == null)
            {
                StrCategoryId = "0";
            }
            if (StrSubCategoryId == null)
            {
                StrSubCategoryId = "0";
            }
            if (StrUnitID == null)
            {
                StrUnitID = "0";
            }
            if (strDeptId == null)
            {
                strDeptId = "0";
            }

            try
            {
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[7];
                ObjLocSqlParameter[0] = new SqlParameter("@CategoryId", StrCategoryId);
                ObjLocSqlParameter[1] = new SqlParameter("@SubCategoryId", StrSubCategoryId);
                ObjLocSqlParameter[2] = new SqlParameter("@UnitId", StrUnitID);
                ObjLocSqlParameter[3] = new SqlParameter("@DeptId", strDeptId);
                ObjLocSqlParameter[4] = new SqlParameter("@FromDate", strFromDate);
                ObjLocSqlParameter[5] = new SqlParameter("@ToDate", strToDate);
                ObjLocSqlParameter[6] = new SqlParameter("@UserName", strUserName);
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                DsLocDataSet = objLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_ReportTicketRaised", ObjLocSqlParameter);

                if ((DsLocDataSet != null))
                {
                    if (DsLocDataSet.Tables[0].Rows.Count > 0)
                    {
                        ObjLocGroupList = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                           select new ClsReportTicketRaised
                                           {
                                               ProPubTicketID = p.Field<string>("TicketID"),
                                               ProPubCategoryDesc = p.Field<string>("CategoryDesc"),
                                               ProPubSubCategoryDesc = p.Field<string>("SubCategoryDesc"),
                                               ProPubUnit = p.Field<string>("Unit"),
                                               ProPubPendingWith = p.Field<string>("PendingWith"),
                                               ProPubstatus = p.Field<string>("status"),
                                               ProPubRequestStatus = p.Field<string>("RequestStatus"),
                                               ProPubRequestDate = p.Field<string>("RequestDate"),
                                               ProPubMessage = p.Field<string>("Message")


                                           }).ToList();
                        return ObjLocGroupList;
                    }
                    else
                    {
                        return ObjLocGroupList;
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
                DsLocDataSet = null;
                ObjLocGroupList = null;
            }


        }

        [HttpGet]
        public ClsCheckListDataBulk FunPubCheckListDataBulk()
        {
            ClsCheckListDataBulk objlocClsCheck = new ClsCheckListDataBulk();
            List<ClsCheckActionable> objCheckActionable = new List<ClsCheckActionable>(); //Fetch top 10 CheckList on this fetch other data
            List<ClsCheckListData> objClsCheckListData = new List<ClsCheckListData>();
            List<ClsCheckListNew> objCheckList = new List<ClsCheckListNew>();
            List<ClsCheckRadio> ObjClsCheckRadio = new List<ClsCheckRadio>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDSChkListData = new DataSet();

            string StrLocConnection = null;
            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                DsLocDSChkListData = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchCheckListRequestmstforAPI");
                if (DsLocDSChkListData != null)
                {
                    if (DsLocDSChkListData.Tables.Count > 0)
                    {
                        if (DsLocDSChkListData.Tables[0].Rows.Count > 0)
                        {
                            objCheckActionable = (from p in DsLocDSChkListData.Tables[0].AsEnumerable()
                                                  select new ClsCheckActionable
                                                  {
                                                      ProPubStrCheckListHolder = p.Field<string>("CheckListHolder"),
                                                      ProPubStrChkTransactionId = Convert.ToString(p.Field<decimal>("ChkTransactionId")),
                                                      ProPubStrCktListRequestId = Convert.ToString(p.Field<decimal>("ChkListRequestId")),
                                                      ProPubStrEndTime = p.Field<string>("EndTime"),
                                                      ProPubStrRequestStatus = p.Field<string>("Requeststatus"),
                                                      ProPubStrScheduleDate = p.Field<string>("ScheduleDate"),
                                                      ProPubStrStartTime = p.Field<string>("StartTime"),
                                                      ProPubStrStatus = p.Field<string>("Status"),
                                                      ProPubStrTicketID = p.Field<string>("TicketId")

                                                  }).ToList();

                            if (DsLocDSChkListData.Tables[1].Rows.Count > 0)
                            {
                                objClsCheckListData = (from p in DsLocDSChkListData.Tables[1].AsEnumerable()
                                                       select new ClsCheckListData
                                                       {
                                                           ProPubStrCheckListHolder = p.Field<string>("CheckListHolder"),
                                                           ProPubStrCompanyDesc = p.Field<string>("CompanyDesc"),
                                                           ProPubStrDepartmentName = p.Field<string>("DepartmentName"),
                                                           ProPubStrFrequency = p.Field<string>("Frequency"),
                                                           ProPubStrGroupDesc = p.Field<string>("GroupDesc"),
                                                           ProPubStrPriority = p.Field<string>("Priority"),
                                                           ProPubStrScheduleDate = Convert.ToString(p.Field<DateTime>("ScheduleDate")),
                                                           ProPubStrStartTime = p.Field<string>("StartTime"),
                                                           ProPubStrTicketId = p.Field<string>("TicketId"),
                                                           ProPubStrTransactionID = Convert.ToString(p.Field<Int32>("TransactionId"))
                                                       }).ToList();

                                if (DsLocDSChkListData.Tables[2].Rows.Count > 0)
                                {
                                    objCheckList = (from s in DsLocDSChkListData.Tables[2].AsEnumerable()
                                                    select new ClsCheckListNew
                                                    {
                                                        ProPubStrCheckID = Convert.ToString(s.Field<decimal>("CheckID")),
                                                        ProPubStrChekList = s.Field<string>("CheckList"),
                                                        ProPubStrId = Convert.ToString(s.Field<decimal>("Id")),
                                                        ProPubStrImagePath = "0x" + BitConverter.ToString(s.Field<Byte[]>("ImgPath")).Replace("-", string.Empty),
                                                        ProPubStrRemark = s.Field<string>("Remark"),
                                                        ProPubStrWeigthage = Convert.ToString(s.Field<decimal>("Weightege")),
                                                        ProPubStrCheckListHolderId = Convert.ToString(s.Field<decimal>("CheckListHolderId")),
                                                        ProPubStrTicketId = s.Field<string>("TicketId")
                                                    }).ToList();

                                    if (DsLocDSChkListData.Tables[3].Rows.Count > 0)
                                    {
                                        ObjClsCheckRadio = (from s in DsLocDSChkListData.Tables[3].AsEnumerable()
                                                            select new ClsCheckRadio
                                                            {
                                                                ProPubStrCktId = s.Field<string>("CktId"),
                                                                ProPubStrChekListID = Convert.ToString(s.Field<decimal>("CheckListId")),
                                                                ProPubStrId = Convert.ToString(s.Field<decimal>("Id")),
                                                                ProPubStrNo = Convert.ToString(s.Field<Boolean>("No")),
                                                                ProPubStrYes = Convert.ToString(s.Field<Boolean>("Yes"))
                                                            }).ToList();

                                        objlocClsCheck = new ClsCheckListDataBulk() { CheckListActionable = objCheckActionable, CheckListData = objClsCheckListData, CheckList = objCheckList, CheckListRadio = ObjClsCheckRadio };

                                        return objlocClsCheck;
                                    }

                                }
                            }

                        }

                    }
                }
                return objlocClsCheck;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDSChkListData = null;

            }

        }





        /// <summary>
        /// Function Created For Fetching QR ID's
        /// Created By Ravindra Muthe on 22-April-2019
        /// </summary>
        /// <param name="StrZone"></param>
        /// <param name="StrLocation"></param>
        /// <param name="StrSubLocation"></param>
        /// <returns></returns>
        [HttpGet]
        public ClsQRIDs FunFetchQRIDs(string StrZone, string StrLocation, string StrSubLocation)
        {
            ClsQRIDs ObjQRIDs = new ClsQRIDs();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet ObjDs = new DataSet();

            string StrLocConnection = null;
            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                {
                    SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                    ObjLocSqlParameter[0] = new SqlParameter("@Zone", StrZone);
                    ObjLocSqlParameter[1] = new SqlParameter("@Location", StrLocation);
                    ObjLocSqlParameter[2] = new SqlParameter("@SubLocation", StrSubLocation);
                    ObjDs = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchQRIDs", ObjLocSqlParameter);

                    if ((ObjDs != null))
                    {
                        if (ObjDs.Tables[0].Rows.Count > 0)
                        {
                            ObjQRIDs.ProPubStrZone = Convert.ToString(ObjDs.Tables[0].Rows[0]["UnitID"]);
                        }
                        else
                        {
                            ObjQRIDs.ProPubStrZone = null;
                        }

                        if (ObjDs.Tables[1].Rows.Count > 0)
                        {
                            ObjQRIDs.ProPubStrLocation = Convert.ToString(ObjDs.Tables[1].Rows[0]["LocationID"]);
                        }
                        else
                        {
                            ObjQRIDs.ProPubStrLocation = null;
                        }

                        if (ObjDs.Tables[2].Rows.Count > 0)
                        {
                            ObjQRIDs.ProPubStrSubLocation = Convert.ToString(ObjDs.Tables[2].Rows[0]["DeptID"]);
                        }
                        else
                        {
                            ObjQRIDs.ProPubStrSubLocation = null;
                        }


                        return ObjQRIDs;
                    }

                    else
                    {
                        return ObjQRIDs;
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
                ObjQRIDs = null;
                ObjDs = null;
            }
        }



        /// <summary>
        /// Function Created For Saving EmpBeacon
        /// Created By Ravindra Muthe on 07-June-2019
        /// </summary>
        /// <param name="StrEmpcd"></param>
        /// <param name="StrRollcd"></param>
        /// <param name="StrH_Freq"></param>
        /// <param name="StrL_Freq"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubSaveEmpBeaconLog(string StrEmpcd, string StrRollcd, string StrBeaconCode)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {


                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[5];
                ObjLocSqlParameter[0] = new SqlParameter("@Empcd", StrEmpcd);
                ObjLocSqlParameter[1] = new SqlParameter("@Rollcd", StrRollcd);
                ObjLocSqlParameter[2] = new SqlParameter("@BeaconCode", StrBeaconCode);
                ObjLocSqlParameter[3] = new SqlParameter("@Outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[3].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[4] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[4].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_SaveEmpBeaconLog", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[4].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }



        /// <summary>
        /// Function Created For Fetching BeaconMst
        /// Created By Ravindra Muthe on 07-June-2019
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ClsBeaconMst> FunPubFetchBeaconMst()
        {
            List<ClsBeaconMst> ObjLocGroupList = new List<ClsBeaconMst>();
            ClsCommunication objLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;
            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                DsLocDataSet = objLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchBeaconMst");

                if ((DsLocDataSet != null))
                {
                    if (DsLocDataSet.Tables[0].Rows.Count > 0)
                    {
                        ObjLocGroupList = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                           select new ClsBeaconMst
                                           {
                                               ProPubStrBeaconId = Convert.ToString(p.Field<Int32>("BeaconId")),
                                               ProPubStrBeaconName = p.Field<string>("BeaconName"),
                                               ProPubStrBeaconDesc = p.Field<string>("BeaconDesc"),
                                               ProPubStrBeaconCode = p.Field<string>("BeaconCode")

                                           }).ToList();
                        return ObjLocGroupList;
                    }
                    else
                    {
                        return ObjLocGroupList;
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
                DsLocDataSet = null;
                ObjLocGroupList = null;
            }


        }


        [HttpGet]
        public List<ClsAndroidVersions> FunPubFetchAndroidVersions()
        {
            List<ClsAndroidVersions> ObjClsAndroidVersions = new List<ClsAndroidVersions>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {


                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[0];
                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_FetchAndroidVersions", ObjLocSqlParameter);

                if (DsLocDataSet != null)
                {
                    if (DsLocDataSet.Tables.Count > 0)
                    {
                        ObjClsAndroidVersions = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                                 select new ClsAndroidVersions
                                                 {
                                                     ProPubStrVersionCode = p.Field<string>("VersionCode"),
                                                     ProPubStrVersionName = p.Field<string>("VersionName"),
                                                     ProPubStrCreatedOn = Convert.ToString(p.Field<DateTime>("CreatedOn"))

                                                 }).ToList();
                        return ObjClsAndroidVersions;
                    }
                    else
                    {
                        return ObjClsAndroidVersions;
                    }
                }

                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }


        //Ravindra Starts FOR WOW Module 09-April-2019



        /// <summary>
        /// Function Created For Saving Baggage
        /// Created By Ravindra Muthe on 09-April-2019
        /// </summary>
        /// <param name="StrCustomerID"></param>
        /// <param name="StrFullName"></param>
        /// <param name="StrAddress"></param>
        /// <param name="StrEmailID"></param>
        /// <param name="StrContactNo"></param>
        /// <param name="StrAlterNo"></param>
        /// <param name="StrImage"></param>
        /// <param name="StrTotalBag"></param>
        /// <param name="StrPrice"></param>
        /// <param name="Outbit"></param>
        /// <param name="StrUsername"></param>
        /// <param name="OutMsg"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubSaveBaggage(string StrCustomerID, string StrFullName, string StrAddress, string StrEmailID, string StrContactNo, string StrAlterNo,
            string StrTotalBag, string StrPrice, string StrUsername, string StrBagTagID, string StrAssociate)
        {

            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            if (StrCustomerID == null)
            {
                StrCustomerID = "0";
            }

            if (StrFullName == null)
            {
                StrFullName = "0";
            }

            if (StrAddress == null)
            {
                StrAddress = "0";
            }
            if (StrEmailID == null)
            {
                StrEmailID = "0";
            }
            if (StrContactNo == null)
            {
                StrContactNo = "0";
            }
            if (StrAlterNo == null)
            {
                StrAlterNo = "0";
            }
            if (StrTotalBag == null)
            {
                StrTotalBag = "0";
            }
            if (StrPrice == null)
            {
                StrPrice = "0";
            }
            if (StrUsername == null)
            {
                StrUsername = "0";
            }



            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[13];
                ObjLocSqlParameter[0] = new SqlParameter("@customer_id", StrCustomerID);
                ObjLocSqlParameter[1] = new SqlParameter("@Full_Name", StrFullName);
                ObjLocSqlParameter[2] = new SqlParameter("@Address", StrAddress);
                ObjLocSqlParameter[3] = new SqlParameter("@Email_id", StrEmailID);
                ObjLocSqlParameter[4] = new SqlParameter("@Contact_No", StrContactNo);
                ObjLocSqlParameter[5] = new SqlParameter("@Alter_No", StrAlterNo);
                ObjLocSqlParameter[6] = new SqlParameter("@Total_bag", StrTotalBag);
                ObjLocSqlParameter[7] = new SqlParameter("@Price", StrPrice);
                ObjLocSqlParameter[8] = new SqlParameter("@Username", StrUsername);
                ObjLocSqlParameter[9] = new SqlParameter("@BagTagID", StrBagTagID);
                ObjLocSqlParameter[10] = new SqlParameter("@Associate", StrAssociate);
                ObjLocSqlParameter[11] = new SqlParameter("@Outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[11].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[12] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[12].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_saveWowBaggageTransaction", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[12].Value);


                string SMSMessage = "Dear " + StrFullName + ", Thank you for using baggage service with Phoenix Marketcity. We confirm to recieve Rs. " + StrPrice +
                    " for your receipt No. BKT" + StrStatus + " dated " + DateTime.Now.ToString("dd-MMMM-yyyy") + " for " + StrTotalBag + " bags at " + DateTime.Now.ToString("hh:mm tt");

                string SMSAPIReturn = RestsharpAPI.SendSMS(StrContactNo, SMSMessage, false);

                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }


        /// <summary>
        /// Function Created For Fetching Price from total Bags
        /// Created By Tanmay Pradhan on 11-April-2019
        /// </summary>
        [HttpGet]
        public string FunPubGetPrice(string StrTotalBag)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;
            string price = null;
            if (StrTotalBag == null)
            {
                StrTotalBag = "1";
            }

            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[1];
                ObjLocSqlParameter[0] = new SqlParameter("@TotalBag", StrTotalBag);
                //ObjLocSqlParameter[1] = new SqlParameter("@outbit", SqlDbType.Bit, 1);
                //ObjLocSqlParameter[1].Direction = ParameterDirection.Output;
                //ObjLocSqlParameter[2] = new SqlParameter("@outmsg", SqlDbType.VarChar, 50);
                //ObjLocSqlParameter[2].Direction = ParameterDirection.Output;
                DsLocDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_fetchWowBagPrice", ObjLocSqlParameter);
                if (DsLocDataSet != null && DsLocDataSet.Tables[0].Rows.Count > 0)
                {
                    price = DsLocDataSet.Tables[0].Rows[0]["price"].ToString();
                }
                return price;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }


        /// <summary>
        /// Function Created For Updating Baggage Status
        /// Created By Ravindra Muthe on 09-April-2019
        /// </summary>
        /// <param name="StrbaggageId"></param>
        [HttpGet]
        public string FunPubUpdateBaggageStatus(string StrbaggageId, string StrUsername)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            if (StrbaggageId == null)
            {
                StrbaggageId = "0";
            }
            if (StrUsername == null)
            {
                StrUsername = "0";
            }


            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[4];
                ObjLocSqlParameter[0] = new SqlParameter("@baggage_Id", StrbaggageId);
                ObjLocSqlParameter[1] = new SqlParameter("@Username", StrUsername);
                ObjLocSqlParameter[2] = new SqlParameter("@Outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[2].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[3] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[3].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_UpdateWowBaggageDetails", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[3].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }



        /// <summary>
        /// Function Created for Fetching customer Details Of Wow Centre
        /// Created By Ravindra Muthe on 09-April-2019
        /// </summary>
        /// <param name="StrContactno"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ClsWowCustomerDetails> FunPubFetchWowCustomerDetails(string StrContactno)
        {
            List<ClsWowCustomerDetails> ObjLocGroupList = new List<ClsWowCustomerDetails>();
            ClsCommunication objLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            if (StrContactno == null)
            {
                StrContactno = "0";
            }


            try
            {
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[1];
                ObjLocSqlParameter[0] = new SqlParameter("@Contact_no", StrContactno);
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                DsLocDataSet = objLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_fetchWow_CustomerDetails", ObjLocSqlParameter);
                if ((DsLocDataSet != null))
                {
                    if (DsLocDataSet.Tables[0].Rows.Count > 0)
                    {
                        ObjLocGroupList = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                           select new ClsWowCustomerDetails
                                           {
                                               ProPubStrCustomer_id = p.Field<string>("Customer_id"),
                                               ProPubStrFull_Name = p.Field<string>("Full_Name"),
                                               ProPubStrAddress = p.Field<string>("Address"),
                                               ProPubStrEmail_id = p.Field<string>("Email_id"),
                                               ProPubStrContact_No = p.Field<string>("Contact_No"),
                                               ProPubStrAlter_No = p.Field<string>("Alter_No"),
                                               // ProPubStrImage = p.Field<string>("Image"),
                                               ProPubStrOprc = p.Field<string>("Oprc"),
                                               ProPubStrDtc = Convert.ToString(p.Field<DateTime>("Dtc"))

                                           }).ToList();
                        return ObjLocGroupList;
                    }
                    else
                    {
                        return ObjLocGroupList;
                    }
                }

                return null;
                // throw new Exception("Error while processing request.");

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;
                ObjLocGroupList = null;
            }


        }





        /// <summary>
        /// Function Created For Fetching Customer's Image
        /// Created By Ravindra Muthe on 16-April-2019
        /// </summary>
        /// <param name="Strcustomerid"></param>
        /// <returns></returns>
        [HttpGet]
        public ClsWowWowImageDetails FunPubFetchWowCustomerImageDetails(string Strcustomerid)
        {
            List<ClsWowWowImageDetails> ObjLocGroupList = new List<ClsWowWowImageDetails>();
            ClsCommunication objLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            if (Strcustomerid == null)
            {
                Strcustomerid = "0";
            }


            try
            {
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[1];
                ObjLocSqlParameter[0] = new SqlParameter("@customer_id", Strcustomerid);
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                DsLocDataSet = objLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_fetchWowImageDetails", ObjLocSqlParameter);
                if ((DsLocDataSet != null))
                {
                    if (DsLocDataSet.Tables[0].Rows.Count > 0)
                    {
                        ObjLocGroupList = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                           select new ClsWowWowImageDetails
                                           {
                                               // ProPubStrImage = p.Field<string>("Image")
                                               ProPubStrImage = "0x" + BitConverter.ToString(p.Field<Byte[]>("Image")).Replace("-", string.Empty)


                                           }).ToList();
                        return ObjLocGroupList[0];
                    }
                    else
                    {
                        return null;
                    }
                }

                return null;
                // throw new Exception("Error while processing request.");

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;
                ObjLocGroupList = null;
            }


        }




        /// <summary>
        /// Function Created For Saving Image Of WowBaggage For Mobile
        /// Created By Ravindra Muthe on 16-April-2019
        /// </summary>
        /// <param name="ObjImg"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage FunPubSaveWowBaggageImage([FromBody]ClsWowWowImageDetails ObjImg)
        //string StrMyRequestID, Byte[] StrImgPath)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                if (ObjImg.ProPubStrImage == null)
                {
                    //throw new ArgumentNullException();
                    ObjImg.ProPubStrImage = "FFD8FFE000104A46494600010100000100010000FFDB004300100B0C0E0C0A100E0D0E1211101318281A181616183123251D283A333D3C3933383740485C4E404457453738506D51575F626768673E4D71797064785C656763FFDB0043011112121815182F1A1A2F634238426363636363636363636363636363636363636363636363636363636363636363636363636363636363636363636363636363FFC0001108016801E003012200021101031101FFC40017000101010100000000000000000000000000050106FFC4001F1001000301010002030100000000000000000314A15253011121418131FFC40014010100000000000000000000000000000000FFC40014110100000000000000000000000000000000FFDA000C03010002110311003F00E5ACC1DE16A0EF13C051B50F785A83BC4E0146D41DE16A1EF138051B50F785A87BC4E0146D43DE32D43DE2780A16A0F4C6DA83D3138051B50F785A87BC4E0146D43DE16A0EF138FBF9051B507785A87BC4E0146CC1DE1660EF138051B30F78CB50F789E0285A87BC6DA87BC4E0146D43DE32D43DE2780A16A1EF0B50F789E0285A87BC6DA87BC4E0146D41DE32D41E989E0285A83D30B50FA6279F40A16A1EF1B6A1EF138051B50F785A87BC4E0146D43DE16A1EF138050B50F785A87BC4F0146D43E98CB50FA6279F60A36A1EF0B507A6271F9051B507A616A1EF138050B50F785A87BC4F0146D43DE16A1F4C4E3EC146DC3E985A83D3138050B50F78DB50F789C028DA87D30B507789C028DA83BC2D43DE270000000000000000000000000035801FB0000000000018D0FB006340000000000000000000000000000000FE80000000000035800000000000000000000000000000000000C68000031A000000000000000000000000000000031A0000000000031A0306800000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000301A00000000000000000000000000000000000000000000007F4000000000000000000000000000000000000000006034000000000180D0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000006340000000000637E0000000000018D00000000000634000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000FD0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000031A03068000000000000000000000000000000000007C7FA7EBE400000000000000000000000000000000000000000000000000003E400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001FFFD9";
                }


                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                var bytes = GetBytesFromByteString(ObjImg.ProPubStrImage).ToArray();

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[4];
                ObjLocSqlParameter[0] = new SqlParameter("@CustomerID", ObjImg.ProPubStrcustomerid);
                // ObjLocSqlParameter[1] = new SqlParameter("@ImagePath", ObjImg.StrImgPath);
                ObjLocSqlParameter[1] = new SqlParameter("@ImagePath", SqlDbType.VarBinary);
                ObjLocSqlParameter[1].Value = bytes;
                ObjLocSqlParameter[2] = new SqlParameter("@Outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[2].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[3] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[3].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_SaveWowBaggageImage", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[3].Value);
                return Request.CreateResponse(HttpStatusCode.OK, StrStatus);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }








        /// <summary>
        /// Function Created For Fetching Baggage Details
        /// Created By Tanmay Mohmu Cheli on 11-April-2019
        /// </summary>
        /// <param name="Strcustomerid"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ClsWowBaggageDetails> FunPubFetchWowBaggageDetails()
        {
            List<ClsWowBaggageDetails> ObjLocGroupList = new List<ClsWowBaggageDetails>();
            ClsCommunication objLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[0];
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                DsLocDataSet = objLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_fetchWowBaggageDetails", ObjLocSqlParameter);
                if ((DsLocDataSet != null))
                {
                    if (DsLocDataSet.Tables[0].Rows.Count > 0)
                    {
                        ObjLocGroupList = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                           select new ClsWowBaggageDetails
                                           {
                                               ProPubStrCustomer_id = Convert.ToString(p.Field<decimal>("Customer_id")),
                                               ProPubStrBaggageId = p.Field<string>("Baggage_id"),
                                               ProPubStrTotalBag = p.Field<string>("total_Bag"),
                                               ProPubStrPrice = p.Field<string>("Price"),
                                               ProPubStrStatus = p.Field<string>("Status"),
                                               ProPubStrBagTicketId = p.Field<string>("BagTicketId"),
                                               ProPubStrFull_Name = p.Field<string>("Full_name"),
                                               ProPubStrAddress = p.Field<string>("Address"),
                                               ProPubStrEmail_id = p.Field<string>("Email_id"),
                                               ProPubStrContact_No = p.Field<string>("Contact_No"),
                                               ProPubStrAlter_No = p.Field<string>("Alter_No"),
                                               ProPubStrDtc = Convert.ToString(p.Field<DateTime>("Dtc")),
                                               ProPubStrBagTagID = p.Field<string>("BagTagID"),
                                               ProPubStrAssociate = p.Field<string>("Associate")

                                           }).ToList();
                        return ObjLocGroupList;
                    }
                    else
                    {
                        return ObjLocGroupList;
                    }
                }

                return null;
                // throw new Exception("Error while processing request.");

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;
                ObjLocGroupList = null;
            }


        }


        /// <summary>
        /// Function Created For Fetching Power Bank's Details
        /// Created By Tanmay on 11-April-2019
        /// </summary>
        /// <param name="Strcustomerid"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ClsWowPowerBankDetails> FunPubFetchPowerBanks()
        {
            List<ClsWowPowerBankDetails> ObjLocGroupList = new List<ClsWowPowerBankDetails>();
            ClsCommunication objLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            try
            {
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[0];
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                DsLocDataSet = objLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_WOWFetchPowerBank", ObjLocSqlParameter);
                if ((DsLocDataSet != null))
                {
                    if (DsLocDataSet.Tables[0].Rows.Count > 0)
                    {
                        ObjLocGroupList = (from p in DsLocDataSet.Tables[0].AsEnumerable()
                                           select new ClsWowPowerBankDetails
                                           {
                                               ProPubStrAssignId = p.Field<string>("Assign_id"),
                                               ProPubStrCustomerId = p.Field<string>("Customer_id"),
                                               ProPubStrPowerBankId = p.Field<string>("PowerBnkId"),
                                               ProPubStrStatus = p.Field<string>("Status"),
                                               ProPubStrFullName = p.Field<string>("Full_Name"),
                                               ProPubStrAddress = p.Field<string>("Address"),
                                               ProPubStrEmailId = p.Field<string>("Email_id"),
                                               ProPubStrContactNo = p.Field<string>("Contact_No"),
                                               ProPubStrAlterNo = p.Field<string>("Alter_No"),
                                               ProPubStrMake = p.Field<string>("PowerBnk_Make"),
                                               ProPubStrModel = p.Field<string>("PowerBnk_Model"),
                                               ProPubStrColor = p.Field<string>("PowerBnK_Colr"),
                                               ProPubStrSerialNo = p.Field<string>("PowerBnk_serial"),
                                               ProPubStrDtc = Convert.ToString(p.Field<DateTime>("Dtc"))

                                           }).ToList();
                        return ObjLocGroupList;
                    }
                    else
                    {
                        return ObjLocGroupList;
                    }
                }

                return null;
                // throw new Exception("Error while processing request.");

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;
                ObjLocGroupList = null;
            }


        }



        /// <summary>
        ///  Function Created For Assigning Power Bank
        /// Created By Tanmay on 11-April-2019
        /// </summary>
        /// <param name="StrCustomerID"></param>
        /// <param name="StrFullName"></param>
        /// <param name="StrAddress"></param>
        /// <param name="StrEmailID"></param>
        /// <param name="StrContactNo"></param>
        /// <param name="StrAlterNo"></param>
        /// <param name="StrUsername"></param>
        /// <param name="StrPowerBankId"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubAssignPowerBank(int StrCustomerID, string StrFullName, string StrAddress, string StrEmailID, string StrContactNo, string StrAlterNo, string StrUsername, int StrPowerBankId)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            if (StrCustomerID == null)
            {
                StrCustomerID = 0;
            }

            if (StrFullName == null)
            {
                StrFullName = "0";
            }

            if (StrAddress == null)
            {
                StrAddress = "0";
            }
            if (StrEmailID == null)
            {
                StrEmailID = "0";
            }
            if (StrContactNo == null)
            {
                StrContactNo = "0";
            }
            if (StrAlterNo == null)
            {
                StrAlterNo = "0";
            }
            if (StrPowerBankId == null)
            {
                StrPowerBankId = 0;
            }

            if (StrUsername == null)
            {
                StrUsername = "0";
            }

            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[10];
                ObjLocSqlParameter[0] = new SqlParameter("@CustomerId", StrCustomerID);
                ObjLocSqlParameter[1] = new SqlParameter("@FullName", StrFullName);
                ObjLocSqlParameter[2] = new SqlParameter("@Address", StrAddress);
                ObjLocSqlParameter[3] = new SqlParameter("@EmailId", StrEmailID);
                ObjLocSqlParameter[4] = new SqlParameter("@ContactNo", StrContactNo);
                ObjLocSqlParameter[5] = new SqlParameter("@AlterNo", StrAlterNo);
                ObjLocSqlParameter[6] = new SqlParameter("@PowerBankId", StrPowerBankId);
                ObjLocSqlParameter[7] = new SqlParameter("@Username", StrUsername);
                ObjLocSqlParameter[8] = new SqlParameter("@Outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[8].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[9] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[9].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_WOWAssignPowerBank", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[9].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }



        /// <summary>
        ///  Function Created For Closing Power Bank Status
        /// Created By Tanmay on 11-April-2019
        /// </summary>
        /// <param name="StrAssignId"></param>
        /// <returns></returns>
        [HttpGet]
        public string FunPubClosePowerBankStatus(string StrAssignId)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsLocDataSet = new DataSet();
            string StrLocConnection = null;

            if (StrAssignId == null)
            {
                return "No Assign ID Found";
            }

            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@AssignId", StrAssignId);
                ObjLocSqlParameter[1] = new SqlParameter("@Outbit", SqlDbType.Bit, 1);
                ObjLocSqlParameter[1].Direction = ParameterDirection.Output;
                ObjLocSqlParameter[2] = new SqlParameter("@OutMsg", SqlDbType.VarChar, 100);
                ObjLocSqlParameter[2].Direction = ParameterDirection.Output;
                ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "spr_WOWClosePowerBank", ObjLocSqlParameter);
                string StrStatus = Convert.ToString(ObjLocSqlParameter[2].Value);
                return StrStatus;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                DsLocDataSet = null;

            }
        }



        //Ravindra Ends 09-April-2019

        //[+]Gate Pass API by Ajay 7th March 2020
        [Route("api/UpKeep/Fetch_MyRequest_GatePass")]
        [HttpGet]
        public HttpResponseMessage Fetch_MyRequest_GatePass(string EmpCD, string RollCD, string Date)
        {
            List<ClsGatePassRequestDetails> ObjGatePass = new List<ClsGatePassRequestDetails>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@EmpCD", EmpCD);
                ObjLocSqlParameter[1] = new SqlParameter("@RollCD", RollCD);
                ObjLocSqlParameter[2] = new SqlParameter("@Date", Date);

                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "SPR_FETCH_MYREQUEST_GP_API", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjGatePass = (from p in DsDataSet.Tables[0].AsEnumerable()
                                           select new ClsGatePassRequestDetails
                                           {
                                               GP_TrancationID = Convert.ToString(p.Field<decimal>("GP_Trans_ID")),
                                               GP_TicketNo = p.Field<string>("TicketNo"),
                                               GP_Config_ID = Convert.ToString(p.Field<decimal>("Gp_Config_ID")),
                                               GP_Title = p.Field<string>("GP_Title"),
                                               GP_Department = p.Field<string>("DepartmentName"),
                                               GP_Type_Desc = p.Field<string>("GP_Type_Desc"),
                                               GP_Date = p.Field<string>("GatePassDate"),
                                               GP_RequestDate = p.Field<string>("RequestDate"),
                                               GP_Status = p.Field<string>("GP_Status"),
                                               GP_CreatedBy = p.Field<string>("Created_By")
                                           }).ToList();

                            return Request.CreateResponse(HttpStatusCode.OK, ObjGatePass);
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

        [Route("api/UpKeep/Fetch_MyActionable_GatePass")]
        [HttpGet]
        public HttpResponseMessage Fetch_MyActionable_GatePass(string EmpCD, string RollCD, string Date)
        {
            List<ClsGatePassRequestDetails> ObjGatePass = new List<ClsGatePassRequestDetails>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@EmpCD", EmpCD);
                ObjLocSqlParameter[1] = new SqlParameter("@RollCD", RollCD);
                ObjLocSqlParameter[2] = new SqlParameter("@Date", Date);

                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_Fetch_MyActionable_GP_API", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjGatePass = (from p in DsDataSet.Tables[0].AsEnumerable()
                                           select new ClsGatePassRequestDetails
                                           {
                                               GP_TrancationID = Convert.ToString(p.Field<decimal>("GP_Trans_ID")),
                                               GP_TicketNo = p.Field<string>("TicketNo"),
                                               GP_Config_ID = Convert.ToString(p.Field<decimal>("Gp_Config_ID")),
                                               GP_Title = p.Field<string>("GP_Title"),
                                               GP_Department = p.Field<string>("DepartmentName"),
                                               GP_Type_Desc = p.Field<string>("GP_Type_Desc"),
                                               GP_Date = p.Field<string>("GatePassDate"),
                                               GP_RequestDate = p.Field<string>("RequestDate"),
                                               GP_Status = p.Field<string>("GP_Status"),
                                               GP_CreatedBy = p.Field<string>("Created_By")
                                           }).ToList();

                            return Request.CreateResponse(HttpStatusCode.OK, ObjGatePass);
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


        [Route("api/UpKeep/Fetch_GatePass_Details")]
        [HttpGet]
        public HttpResponseMessage Fetch_GatePass_Details(int TransactionID, string EmpCD, string RollCD)
        {
            List<ClsGatePassRequestDetails> ObjGatePass = new List<ClsGatePassRequestDetails>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();
            DataTable dt = new DataTable();
            string StrLocConnection = null;

            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@TransactionID", TransactionID);
                ObjLocSqlParameter[1] = new SqlParameter("@EmpCD", EmpCD);
                ObjLocSqlParameter[2] = new SqlParameter("@RollCD", RollCD);

                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "SPR_FETCH_GP_REQUEST_APPROVAL_DETAILS_API", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            //dt = DsDataSet.Tables[2];

                            //DataColumn dc = new DataColumn(dt.Columns);
                            //var stringArr=  dt.AsEnumerable().Select(r => r.Field<decimal>("GP_Header_ID")).ToArray();
                            //var stringArr = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
                            //var stringArr = dt.Columns.co .ItemArray.Select(x => x.ToString()).ToArray();
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

        [HttpGet]
        public HttpResponseMessage Fetch_GatePass_HeaderDetails(int TransactionID, string EmpCD, string RollCD)
        {
            List<ClsGatePassRequestDetails> ObjGatePass = new List<ClsGatePassRequestDetails>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();
            DataTable dt = new DataTable();
            string StrLocConnection = null;

            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@TransactionID", TransactionID);
                ObjLocSqlParameter[1] = new SqlParameter("@EmpCD", EmpCD);
                ObjLocSqlParameter[2] = new SqlParameter("@RollCD", RollCD);

                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "SPR_FETCH_GP_REQUEST_APPROVAL_DETAILS_API", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            dt = DsDataSet.Tables[5];

                            dt.Columns.Remove("SrNo");
                            // string[][] matrix = new string[dt.Rows.Count][];
                            // Converter<object, string> converter = Convert.ToString;

                            //var matrix1 = Array.ConvertAll(dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray(),converter);

                            // for (int row = 0; row < dt.Rows.Count; row++)
                            // {
                            //     matrix[row] = Array.ConvertAll(dt.Rows[row].ItemArray, converter);
                            // }

                            string[][] jaggedArray = new string[dt.Rows.Count][];
                            for (int ind = 0; ind < dt.Rows.Count; ind++)
                            {
                                string[] array = new string[dt.Columns.Count];
                                for (int ind1 = 0; ind1 < dt.Columns.Count; ind1++)
                                {
                                    array[ind1] = dt.Rows[ind][ind1].ToString();
                                }
                                jaggedArray[ind] = array;
                            }

                            //var  matrix1= dt.AsEnumerable().Select(x => x.ItemArray).ToArray();

                            //matrix =matrix1;

                            //DataColumn dc = new DataColumn(dt.Columns);
                            //var stringArr=  dt.AsEnumerable().Select(r => r.Field<decimal>("GP_Header_ID")).ToArray();
                            // var stringArr = dt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
                            //var stringArr = dt.Columns.co .ItemArray.Select(x => x.ToString()).ToArray();
                            return Request.CreateResponse(HttpStatusCode.OK, jaggedArray);
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



        [Route("api/UpKeep/Update_GatePass_Action")]
        [HttpPost]
        public HttpResponseMessage Update_GatePass_Action([FromBody] ClsGatePassAction objInsert)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();

            string StrLocConnection = null;
            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[6];
                ObjLocSqlParameter[0] = new SqlParameter("@TransactionID", objInsert.GP_TransacationID);
                ObjLocSqlParameter[1] = new SqlParameter("@CurrentLevel", objInsert.GP_CurrentLevel);
                ObjLocSqlParameter[2] = new SqlParameter("@ActionStatus", objInsert.GP_ActionStatus);
                ObjLocSqlParameter[3] = new SqlParameter("@Remarks", objInsert.GP_Remarks);
                ObjLocSqlParameter[4] = new SqlParameter("@Emp_CD", objInsert.GP_EmpCD);
                ObjLocSqlParameter[5] = new SqlParameter("@Roll_CD", objInsert.GP_RollCD);
                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_UpdateAction_GP_Request_API", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in DsDataSet.Tables[0].Rows)
                            {
                                var TokenNO = Convert.ToString(dr["TokenNumber"]);
                                var TicketNo = Convert.ToString(dr["TicketNo"]);

                                FunSendAppNotification(TokenNO, TicketNo, "New Gatepass Request", "GATEPASS");
                            }

                        }
                    }
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
            }
        }


        [Route("api/UpKeep/Fetch_Dashboard_ChecklistCount")]
        [HttpGet]
        public HttpResponseMessage Fetch_Dashboard_ChecklistCount(string SelectedCompany, string FromDate, string ToDate)
        {
            List<ClsGatePassRequestDetails> ObjGatePass = new List<ClsGatePassRequestDetails>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();
            DataTable dt = new DataTable();
            string StrLocConnection = null;

            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@SelectedCompany", SelectedCompany);
                ObjLocSqlParameter[1] = new SqlParameter("@FromDate", FromDate);
                ObjLocSqlParameter[2] = new SqlParameter("@ToDate", ToDate);

                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_fetch_ChecklistCount", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
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

        [HttpGet]
        public string FunSendAppNotification(string StrTokenNumber, string TicketNo, string StrMessage, string click_action)
        {
            string response = RestsharpAPI.SendNotification(StrTokenNumber, "Ticket ID: " + TicketNo, StrMessage, click_action);
            return response;
        }

        [Route("api/UpKeep/Fetch_API_Version")]
        [HttpGet]
        public HttpResponseMessage Fetch_API_Version()
        {
            string VersionNo = string.Empty;

            try
            {

                VersionNo = Convert.ToString(ConfigurationManager.AppSettings["VersionNo"]);

                return Request.CreateResponse(HttpStatusCode.OK, VersionNo);

                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }

        //[-]Gate Pass API by Ajay 7th March 2020

        #endregion

        #region Work permit
        [Route("api/UpKeep/Fetch_MyRequest_WorkPermit")]
        [HttpGet]
        public HttpResponseMessage Fetch_MyRequest_WorkPermit(string EmpCD, string RollCD, string Date)
        {
            List<ClsWorkPermitRequestDetails> ObjWorkPermit = new List<ClsWorkPermitRequestDetails>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@EmpCD", EmpCD);
                ObjLocSqlParameter[1] = new SqlParameter("@RollCD", RollCD);
                ObjLocSqlParameter[2] = new SqlParameter("@Date", Date);

                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "SPR_FETCH_MYREQUEST_WP_API", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjWorkPermit = (from p in DsDataSet.Tables[0].AsEnumerable()
                                             select new ClsWorkPermitRequestDetails
                                             {
                                                 WP_Trans_ID = Convert.ToString(p.Field<decimal>("WP_Trans_ID")),
                                                 TicketNo = p.Field<string>("TicketNo"),
                                                 Wp_Config_ID = Convert.ToString(p.Field<decimal>("Wp_Config_ID")),
                                                 WP_Title = p.Field<string>("WP_Title"),
                                                 DepartmentName = p.Field<string>("DepartmentName"),
                                                 WorkPermitDate = p.Field<string>("WorkPermitDate"),
                                                 RequestDate = p.Field<string>("RequestDate"),
                                                 WP_Status = p.Field<string>("WP_Status"),
                                                 Created_By = p.Field<string>("Created_By")
                                             }).ToList();



                            return Request.CreateResponse(HttpStatusCode.OK, ObjWorkPermit);
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
                ObjWorkPermit = null;
            }
        }

        [Route("api/UpKeep/Fetch_MyActionable_WorkPermit")]
        [HttpGet]
        public HttpResponseMessage Fetch_MyActionable_WorkPermit(string EmpCD, string RollCD, string Date)
        {
            List<ClsWorkPermitRequestDetails> ObjWorkPermit = new List<ClsWorkPermitRequestDetails>();
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();

            string StrLocConnection = null;

            try
            {

                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@EmpCD", EmpCD);
                ObjLocSqlParameter[1] = new SqlParameter("@RollCD", RollCD);
                ObjLocSqlParameter[2] = new SqlParameter("@Date", Date);

                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_Fetch_MyActionable_WP_API ", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjWorkPermit = (from p in DsDataSet.Tables[0].AsEnumerable()
                                             select new ClsWorkPermitRequestDetails
                                             {
                                                 WP_Trans_ID = Convert.ToString(p.Field<decimal>("WP_Trans_ID")),
                                                 TicketNo = p.Field<string>("TicketNo"),
                                                 Wp_Config_ID = Convert.ToString(p.Field<decimal>("Wp_Config_ID")),
                                                 WP_Title = p.Field<string>("WP_Title"),
                                                 DepartmentName = p.Field<string>("DepartmentName"),
                                                 WorkPermitDate = p.Field<string>("WorkPermitDate"),
                                                 RequestDate = p.Field<string>("RequestDate"),
                                                 WP_Status = p.Field<string>("WP_Status"),
                                                 Created_By = p.Field<string>("Created_By")
                                             }).ToList();

                            return Request.CreateResponse(HttpStatusCode.OK, ObjWorkPermit);
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
                ObjWorkPermit = null;
            }

        }

        [Route("api/UpKeep/Update_WorkPermit_Action")]
        [HttpPost]
        public HttpResponseMessage Update_WorkPermit_Action([FromBody] ClsWorkPermitAction objInsert)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();

            string StrLocConnection = null;
            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[6];
                ObjLocSqlParameter[0] = new SqlParameter("@TransactionID", objInsert.WP_TransacationID);
                ObjLocSqlParameter[2] = new SqlParameter("@ActionStatus", objInsert.WP_ActionStatus);
                ObjLocSqlParameter[3] = new SqlParameter("@Remarks", objInsert.WP_Remarks);
                ObjLocSqlParameter[4] = new SqlParameter("@Emp_CD", objInsert.WP_EmpCD);
                ObjLocSqlParameter[5] = new SqlParameter("@Roll_CD", objInsert.WP_RollCD);
                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_UpdateAction_WP_Request_API", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in DsDataSet.Tables[0].Rows)
                            {
                                var TokenNO = Convert.ToString(dr["TokenNumber"]);
                                var TicketNo = Convert.ToString(dr["TicketNo"]);

                                FunSendAppNotification(TokenNO, TicketNo, "Action taken Workpermit Request", "WORKPERMIT");
                            }

                        }
                    }
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
            }
        }

        [Route("api/UpKeep/Fetch_WorkPermit_Details")]
        [HttpGet]
        public HttpResponseMessage Fetch_WorkPermit_Details(int TransactionID, string EmpCD, string RollCD)
        {

            // List<ClsWorkPermitMain> ObjWorkPermit = new List<ClsWorkPermitMain>();
            ClsWorkPermitMain ObjWorkPermit = new ClsWorkPermitMain();

            List<ClsWorkPermitTransaction> ObjTransaction = new List<ClsWorkPermitTransaction>();
            List<ClsWorkPermitInitiator> ObjInitiator = new List<ClsWorkPermitInitiator>();
            List<ClsWorkPermitApprover> ObjApprover = new List<ClsWorkPermitApprover>();
            List<ClsWorkPermitSection> ObjSection = new List<ClsWorkPermitSection>();
            List<ClsWorkPermitHeader> ObjHeader = new List<ClsWorkPermitHeader>();
            List<ClsWorkPermitSectionHeader> ObjSectionHeader = new List<ClsWorkPermitSectionHeader>();

            List<ClsWorkPermitApproverMatrix> ObjApproverMatrix = new List<ClsWorkPermitApproverMatrix>();
            List<ClsWorkPermitActions> ObjActions = new List<ClsWorkPermitActions>();

            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();
            DataTable dt = new DataTable();
            string StrLocConnection = null;

            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);


                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@Transaction_ID", TransactionID);
                ObjLocSqlParameter[1] = new SqlParameter("@EmpCD", EmpCD);
                ObjLocSqlParameter[2] = new SqlParameter("@RollCD", RollCD);

                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "SPR_FETCH_SAVED_WP_REQUEST_DATA_API", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {

                            ObjTransaction = (from p in DsDataSet.Tables[0].AsEnumerable()
                                              select new ClsWorkPermitTransaction
                                              {
                                                  WP_Config_ID = Convert.ToString(p.Field<decimal>("WP_Config_ID")),
                                                  Level = Convert.ToString(p.Field<decimal>("Level")),
                                                  TicketNo = Convert.ToString(p.Field<string>("TicketNo")),
                                                  Wp_Status = Convert.ToString(p.Field<string>("Wp_Status")),
                                                  WP_Title = Convert.ToString(p.Field<string>("WP_Title")),
                                                  Initiator = Convert.ToString(p.Field<string>("Initiator")),
                                                  Created_By = Convert.ToString(p.Field<string>("Created_By")),
                                                  Created_Date = Convert.ToString(p.Field<string>("Created_Date")),
                                                  Wp_date = Convert.ToString(p.Field<string>("Wp_date")),
                                                  Wp_To_date = Convert.ToString(p.Field<string>("Wp_To_date"))
                                              }).ToList();

                            ObjInitiator = (from p in DsDataSet.Tables[1].AsEnumerable()
                                            select new ClsWorkPermitInitiator
                                            {
                                                UserType = Convert.ToString(p.Field<string>("UserType")),
                                                Username = Convert.ToString(p.Field<string>("Username")),
                                                Store_Name = Convert.ToString(p.Field<string>("Store_Name")),
                                                Name = Convert.ToString(p.Field<string>("Name")),
                                                PhoneNo = Convert.ToString(p.Field<string>("PhoneNo")),
                                                EmailID = Convert.ToString(p.Field<string>("EmailID")),
                                            }).ToList();

                            ObjSection = (from p in DsDataSet.Tables[2].AsEnumerable()
                                          select new ClsWorkPermitSection
                                          {
                                              SectionName = Convert.ToString(p.Field<string>("Section")),
                                              ObjHeader = (from x in DsDataSet.Tables[3].AsEnumerable()
                                                           where x.Field<decimal>("WP_Section_ID") == p.Field<decimal>("WP_Section_ID")
                                                           select new ClsWorkPermitHeader
                                                           {
                                                               ObjSectionHeader = (from y in DsDataSet.Tables[4].AsEnumerable()
                                                                                   where y.Field<decimal>("WP_Section_ID") == p.Field<decimal>("WP_Section_ID")
                                                                                   where y.Field<decimal>("Wp_Header_ID") == x.Field<decimal>("Wp_Header_ID")
                                                                                   select new ClsWorkPermitSectionHeader
                                                                                   {
                                                                                       Header = Convert.ToString(y.Field<string>("Header")),
                                                                                       Type = Convert.ToString(y.Field<string>("ANS_Type")),
                                                                                       Value = Convert.ToString(y.Field<string>("Record")),
                                                                                   }).ToList()
                                                           }).ToList()
                                          }).ToList();




                            ObjApprover = (from p in DsDataSet.Tables[5].AsEnumerable()
                                           select new ClsWorkPermitApprover
                                           {
                                               Level = Convert.ToString(p.Field<decimal>("Level")),
                                               Approver = Convert.ToString(p.Field<string>("Approver")),
                                               Remarks = Convert.ToString(p.Field<string>("Remarks")),
                                               Date = Convert.ToString(p.Field<string>("Action_Date")),
                                               Status = Convert.ToString(p.Field<string>("Status")),
                                           }).ToList();

                            ObjApproverMatrix = (from p in DsDataSet.Tables[6].AsEnumerable()
                                                 select new ClsWorkPermitApproverMatrix
                                                 {
                                                     Level = Convert.ToString(p.Field<decimal>("Level")),
                                                     LevelDescription = Convert.ToString(p.Field<string>("LevelDescription")),
                                                     User = Convert.ToString(p.Field<string>("Users"))
                                                 }).ToList();

                            ObjActions = (from p in DsDataSet.Tables[7].AsEnumerable()
                                          select new ClsWorkPermitActions
                                          {
                                              ActionID = Convert.ToString(p.Field<string>("ActionID")),
                                              Action_Desc = Convert.ToString(p.Field<string>("Action_Desc"))
                                          }).ToList();

                            ObjWorkPermit.ObjClsTransaction = ObjTransaction;
                            ObjWorkPermit.ObjClsInitiator = ObjInitiator;
                            ObjWorkPermit.ObjClsSection = ObjSection;
                            ObjWorkPermit.ObjClsApprover = ObjApprover;
                            ObjWorkPermit.ObjClsApproverMatrix = ObjApproverMatrix;
                            ObjWorkPermit.ObjClsActions = ObjActions;


                            return Request.CreateResponse(HttpStatusCode.OK, ObjWorkPermit);
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
                //  ObjGatePass = null;
            }

        }

        #endregion

        #region Ticketing

        [Route("api/UpKeep/Fetch_Location_Tree")]
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

        [Route("api/UpKeep/Fetch_MyActionable_Ticket")]
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

        [Route("api/UpKeep/Fetch_MyRequest_Ticket")]
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

        [Route("api/UpKeep/Accept_Ticket")]
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
                                return Request.CreateResponse(HttpStatusCode.OK);
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


        [Route("api/UpKeep/Request_Ticket")]
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
                            TicketID = Convert.ToString(DsDataSet.Tables[0].Rows[0]["TicketNo"]);
                            foreach (DataRow dr in DsDataSet.Tables[0].Rows)
                            {
                                var TokenNO = Convert.ToString(dr["TokenNumber"]);
                                var TicketNo = Convert.ToString(dr["TicketNo"]);

                                FunSendAppNotification(TokenNO, TicketNo, "New Ticket Request", "TICKET");
                            }
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.NotFound, "No Workflow Found");
                        }
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

        [Route("api/UpKeep/Fetch_Ticket_Details")]
        [HttpGet]
        public HttpResponseMessage Fetch_Ticket_Details(int TicketID, int CompanyID, string EmpCD, string RollCD)
        {
            List<ClsMyActionableTicket> Objticket = new List<ClsMyActionableTicket>();
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

        [Route("api/UpKeep/Update_Ticket_Action")]
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

                return Request.CreateResponse(HttpStatusCode.OK);
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

        [Route("api/UpKeep/Save_Ticket_Image")]
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
                            var filePath = HttpContext.Current.Server.MapPath("~/FeedbackImages/" + postedFile.FileName + extension);

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


        [Route("api/UpKeep/PostTicketImage")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<HttpResponseMessage> PostTicketImage(string TicketCode)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {

                var httpRequest = HttpContext.Current.Request;
                string CurrentDate = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));
                string imgPath = Convert.ToString(ConfigurationManager.AppSettings["TicketImageUploadURL"]);

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
                            string fileUploadPath = imgPath + CurrentDate;
                            if (!Directory.Exists(fileUploadPath))
                            {
                                Directory.CreateDirectory(fileUploadPath);
                            }
                            var ImageName = TicketCode;
                            //var filePath = HttpContext.Current.Server.MapPath("~/FeedbackImages/" + postedFile.FileName + extension);
                            var filePath = fileUploadPath + "/" + ImageName + extension;

                            postedFile.SaveAs(filePath);
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


        [Route("api/UpKeep/Fetch_Ticket_Workflow")]
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

        [Route("api/UpKeep/Validate_Company")]
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

        #endregion


        #region "CheckList"

        [Route("api/UpKeep/Fetch_CheckList_Config_List")]
        [HttpGet]
        public HttpResponseMessage Fetch_CheckList_Config_List(int CompanyCode) //int UserID,
        {
            // List<ClsWorkPermitMain> ObjWorkPermit = new List<ClsWorkPermitMain>();
            ClsWorkPermitMain ObjWorkPermit = new ClsWorkPermitMain();

            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();
            DataTable dt = new DataTable();
            string StrLocConnection = null;

            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                // ObjLocSqlParameter[0] = new SqlParameter("@USERID", UserID);
                ObjLocSqlParameter[0] = new SqlParameter("@CompanyCode", CompanyCode);

                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "SPR_FETCH_CHK_CONFIG_LIST", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
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
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsDataSet = null;
                //  ObjGatePass = null;
            }

        }

        [Route("api/UpKeep/Fetch_CheckList_Config_Details")]
        [HttpGet]
        public HttpResponseMessage Fetch_CheckList_Config_Details(int ConfigID) //, string EmpCD, string RollCD
        {

            // List<ClsWorkPermitMain> ObjWorkPermit = new List<ClsWorkPermitMain>();
            ClChecklistConfig ObjChecklistConfig = new ClChecklistConfig();

            List<ClChecklistConfigHead> ObjChecklistConfigHead = new List<ClChecklistConfigHead>();
            List<ClChecklistConfigSection> ObjChecklistConfigSection = new List<ClChecklistConfigSection>();
            //List<ClChecklistConfigQuestion> ObjChecklistConfigQuestion = new List<ClChecklistConfigQuestion>();
            //List<ClChecklistConfigAnswer> ObjChecklistConfigAnswer = new List<ClChecklistConfigAnswer>();
            List<ClChecklistConfigAnswerType> ObjChecklistConfigAnswerType = new List<ClChecklistConfigAnswerType>();

            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();
            DataTable dt = new DataTable();
            string StrLocConnection = null;

            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);


                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@CHK_ConfigID", ConfigID);
                //ObjLocSqlParameter[1] = new SqlParameter("@EmpCD", EmpCD);
                //ObjLocSqlParameter[2] = new SqlParameter("@RollCD", RollCD);

                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "SPR_FETCH_CHK_CONFIG_DETAILS_API", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {

                            ObjChecklistConfigHead = (from p in DsDataSet.Tables[0].AsEnumerable()
                                                      select new ClChecklistConfigHead
                                                      {
                                                          Chk_Response_ID = 0,
                                                          Location_ID = 0,
                                                          Department_ID = 0,
                                                          Status = "",
                                                          ActionStatus = "",

                                                          Chk_Config_ID = Convert.ToInt32(p.Field<decimal>("Chk_Config_ID")),
                                                          Chk_Title = Convert.ToString(p.Field<string>("Chk_Title")),
                                                          Chk_Desc = Convert.ToString(p.Field<string>("Chk_Desc")),
                                                          Is_Enable_Score = Convert.ToBoolean(p.Field<bool>("Is_Enable_Score")),
                                                          TotalScore = Convert.ToInt32(p.Field<decimal>("TotalScore"))
                                                      }).ToList();

                            ObjChecklistConfigSection = (from p in DsDataSet.Tables[1].AsEnumerable()
                                                         select new ClChecklistConfigSection
                                                         {
                                                             // SrNo = Convert.ToInt32(p.Field<decimal>("SrNo")),
                                                             Chk_Section_ID = Convert.ToInt32(p.Field<decimal>("Chk_Section_ID")),
                                                             Chk_Config_ID = Convert.ToInt32(p.Field<decimal>("Chk_Config_ID")),
                                                             Chk_Section_Desc = Convert.ToString(p.Field<string>("Chk_Section_Desc")),

                                                             ObjClChecklistConfigQuestion = (from x in DsDataSet.Tables[2].AsEnumerable()
                                                                                             where x.Field<decimal>("Chk_Section_ID") == p.Field<decimal>("Chk_Section_ID")
                                                                                             select new ClChecklistConfigQuestion
                                                                                             {

                                                                                                 CHK_Question_ID = Convert.ToInt32(x.Field<decimal>("CHK_Question_ID")),
                                                                                                 Chk_Section_ID = Convert.ToInt32(x.Field<decimal>("Chk_Section_ID")),
                                                                                                 Qn_Desc = Convert.ToString(x.Field<string>("Qn_Desc")),
                                                                                                 Is_Attach_Mandatory = Convert.ToBoolean(x.Field<bool>("Is_Attach_Mandatory")),
                                                                                                 Is_Qn_Mandatory = Convert.ToBoolean(x.Field<bool>("Is_Qn_Mandatory")),
                                                                                                 Qn_Score = Convert.ToInt32(x.Field<decimal>("Qn_Score")),
                                                                                                 Chk_Qn_Ref_Desc = Convert.ToString(x.Field<string>("Chk_Qn_Ref_Desc")),
                                                                                                 Chk_Qn_Ref_Photo = Convert.ToString(x.Field<string>("Chk_Qn_Ref_Photo")),
                                                                                                 Chk_Ans_Type_ID = Convert.ToInt32(x.Field<decimal>("Chk_Ans_Type_ID")),
                                                                                                 Is_Raise_Flag_Issue = Convert.ToBoolean(x.Field<bool>("Is_Raise_Flag_Issue")),

                                                                                                 ObjClChecklistConfigAnswerType = (from z in DsDataSet.Tables[4].AsEnumerable()
                                                                                                                                   where x.Field<decimal>("Chk_Ans_Type_ID") == z.Field<decimal>("Ans_Type_ID")
                                                                                                                                   select new ClChecklistConfigAnswerType
                                                                                                                                   {
                                                                                                                                       Ans_Type_ID = Convert.ToInt32(z.Field<decimal>("Ans_Type_ID")),
                                                                                                                                       Ans_Type_Desc = Convert.ToString(z.Field<string>("Ans_Type_Desc")),
                                                                                                                                       SDesc = Convert.ToString(z.Field<string>("SDesc")),
                                                                                                                                       Is_MultiValue = Convert.ToBoolean(z.Field<bool>("Is_MultiValue"))
                                                                                                                                   }).ToList(),

                                                                                                 ObjClChecklistConfigAnswer = (from y in DsDataSet.Tables[3].AsEnumerable()
                                                                                                                                   // where y.field<decimal>("chk_question_id ") == p.field<decimal>("chk_question_id ")
                                                                                                                               where y.Field<decimal>("chk_question_id") == x.Field<decimal>("chk_question_id")
                                                                                                                               select new ClChecklistConfigAnswer
                                                                                                                               {
                                                                                                                                   Chk_Ans_Value_ID = Convert.ToInt32(y.Field<decimal>("chk_ans_value_id")),
                                                                                                                                   CHK_Question_ID = Convert.ToInt32(y.Field<decimal>("chk_question_id")),
                                                                                                                                   Ans_Is_Flag = Convert.ToBoolean(y.Field<bool>("ans_is_flag")),
                                                                                                                                   Is_Default = Convert.ToBoolean(y.Field<bool>("is_default")),
                                                                                                                                   Chk_Ans_Desc = Convert.ToString(y.Field<string>("chk_ans_desc")),
                                                                                                                                   Chk_Ans_Type_ID = Convert.ToInt32(y.Field<decimal>("chk_ans_type_id"))
                                                                                                                               }).ToList()
                                                                                             }).ToList()
                                                         }).ToList();

                                         //ObjChecklistConfigAnswerType = (from p in DsDataSet.Tables[4].AsEnumerable()
                                         //                   select new ClChecklistConfigAnswerType
                                         //                   {
                                         //                       Ans_Type_ID = Convert.ToInt32(p.Field<decimal>("Ans_Type_ID")),
                                         //                       Ans_Type_Desc = Convert.ToString(p.Field<string>("Ans_Type_Desc")),
                                         //                       SDesc = Convert.ToString(p.Field<string>("SDesc")),
                                         //                       Is_MultiValue = Convert.ToBoolean(p.Field<bool>("Is_MultiValue"))
                                         //                   }).ToList();



                            ObjChecklistConfig.ObjClChecklistConfigHead = ObjChecklistConfigHead;
                            ObjChecklistConfig.ObjClChecklistConfigSection = ObjChecklistConfigSection;
                          //  ObjChecklistConfig.ObjClChecklistConfigAnswerType = ObjChecklistConfigAnswerType;


                            return Request.CreateResponse(HttpStatusCode.OK, ObjChecklistConfig);
                            //return Request.CreateResponse(HttpStatusCode.OK, DsDataSet);
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
                //  ObjGatePass = null;
            }

        }

        [Route("api/UpKeep/Insert_Checklist_Response")]
        [HttpPost]
        public HttpResponseMessage Insert_Checklist_Response([FromBody] ClsChecklist_Response objInsert)
        {
            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();

            string StrLocConnection = null;
            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[6];
                ObjLocSqlParameter[0] = new SqlParameter("@Chk_Response_ID", objInsert.Chk_Response_ID);
                ObjLocSqlParameter[1] = new SqlParameter("@Chk_Config_ID", objInsert.Chk_Config_ID);
                ObjLocSqlParameter[2] = new SqlParameter("@User_Code", objInsert.User_Code);
                ObjLocSqlParameter[3] = new SqlParameter("@CompanyID", objInsert.CompanyID);
                ObjLocSqlParameter[4] = new SqlParameter("@LocationID", objInsert.LocationID);
                ObjLocSqlParameter[5] = new SqlParameter("@DepartmentID", objInsert.DepartmentID);

                //NEED TO CONVERT DATA TO XML AND PASSED IN SP 
                StringBuilder strXml = new StringBuilder();
                strXml.Append(@"<DocumentElement>");

                foreach (ClsChecklist_Response_Data objs in objInsert.ObjChkResponseData)
                {
                    strXml.Append(@"<Section>");
                    strXml.Append(@"<SectionID>" + objs.SectionID.ToString() + "</SectionID>");
                    strXml.Append(@"<QuestionID>" + objs.QuestionID.ToString() + "</QuestionID>");
                    //strXml.Append(@"<AnswerID>" + objs.AnswerID.ToString() + "</AnswerID>");
                    strXml.Append(@"<AnswerTypeID>" + objs.AnswerTypeID.ToString() + "</AnswerTypeID>");

                    strXml.Append(@"<AnswerData>");

                    foreach (ClsChecklist_Response_Data_Values objsValue in objs.ObjChkResponseDataValue)
                    {
                        strXml.Append(@"<AnswerValue>");

                        strXml.Append(@"<AnswerID>" + objsValue.AnswerID.ToString() + "</AnswerID>");
                        strXml.Append(@"<value>" + objsValue.value.ToString() + "</value>");

                        strXml.Append(@"</AnswerValue>");
                    }
                    strXml.Append(@"</AnswerData>");
                    strXml.Append(@"</Section>");
                }

                strXml.Append(@"</DocumentElement>");

                ObjLocSqlParameter[6] = new SqlParameter("@ChkResponseData", strXml.ToString());

                // ObjLocSqlParameter[5] = new SqlParameter("@ChkResponseData", objInsert.ChkResponseData);

                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "SPR_INSERT_CHK_RESPONSE", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            //foreach (DataRow dr in DsDataSet.Tables[0].Rows)
                            //{
                            //    var TokenNO = Convert.ToString(dr["TokenNumber"]);
                            //    var TicketNo = Convert.ToString(dr["TicketNo"]);

                            //    FunSendAppNotification(TokenNO, TicketNo, "Action taken Workpermit Request", "WORKPERMIT");
                            //}

                        }
                    }
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
            }
        }

        //CHECKLIST RESPONSE LIST
        [Route("api/UpKeep/Fetch_CheckList_Response")]
        [HttpGet]
        public HttpResponseMessage Fetch_CheckList_Response(string EmpCd, int CompanyID) //int UserID,
        {
            // List<ClsWorkPermitMain> ObjWorkPermit = new List<ClsWorkPermitMain>();
            ClsWorkPermitMain ObjWorkPermit = new ClsWorkPermitMain();

            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();
            DataTable dt = new DataTable();
            string StrLocConnection = null;

            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                // ObjLocSqlParameter[0] = new SqlParameter("@USERID", UserID);
                ObjLocSqlParameter[0] = new SqlParameter("@EmpCd", EmpCd);
                ObjLocSqlParameter[1] = new SqlParameter("@CompanyID", CompanyID);

                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "SPR_FETCH_CHK_MY_RESPONSE_LIST", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
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
                throw new Exception("Error while processing request.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                DsDataSet = null;
                //  ObjGatePass = null;
            }

        }


        //CHECKLIST RESPONSE Details
        [Route("api/UpKeep/Fetch_CheckList_Response_Details")]
        [HttpGet]
        public HttpResponseMessage Fetch_CheckList_Response_Details(string ResponseId) //int UserID,
        {
            ClChecklistConfig ObjChecklistConfig = new ClChecklistConfig();

            List<ClChecklistConfigHead> ObjChecklistConfigHead = new List<ClChecklistConfigHead>();
            List<ClChecklistConfigSection> ObjChecklistConfigSection = new List<ClChecklistConfigSection>();
            List<ClChecklistConfigAnswerType> ObjChecklistConfigAnswerType = new List<ClChecklistConfigAnswerType>();

            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();
            DataTable dt = new DataTable();
            string StrLocConnection = null;

            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@ResponseId", ResponseId);
                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "SPR_FETCH_CHK_RESPONSE_DETAILS_API", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {

                            ObjChecklistConfigHead = (from p in DsDataSet.Tables[0].AsEnumerable()
                                                      select new ClChecklistConfigHead
                                                      {
                                                          Chk_Response_ID = Convert.ToInt32(p.Field<decimal>("Chk_Response_ID")),
                                                          Location_ID = Convert.ToInt32(p.Field<decimal>("Location_ID")),
                                                          Department_ID = Convert.ToInt32(p.Field<decimal>("Department_ID")),
                                                          Status = Convert.ToString(p.Field<string>("Status")),
                                                          ActionStatus = Convert.ToString(p.Field<string>("ActionStatus")),

                                                          Chk_Config_ID = Convert.ToInt32(p.Field<decimal>("Chk_Config_ID")),
                                                          Chk_Title = Convert.ToString(p.Field<string>("Chk_Title")),
                                                          Chk_Desc = Convert.ToString(p.Field<string>("Chk_Desc")),
                                                          Is_Enable_Score = Convert.ToBoolean(p.Field<bool>("Is_Enable_Score")),
                                                          TotalScore = Convert.ToInt32(p.Field<decimal>("TotalScore"))
                                                      }).ToList();

                            ObjChecklistConfigSection = (from p in DsDataSet.Tables[1].AsEnumerable()
                                                         select new ClChecklistConfigSection
                                                         {
                                                             // SrNo = Convert.ToInt32(p.Field<decimal>("SrNo")),
                                                             Chk_Section_ID = Convert.ToInt32(p.Field<decimal>("Chk_Section_ID")),
                                                             Chk_Config_ID = Convert.ToInt32(p.Field<decimal>("Chk_Config_ID")),
                                                             Chk_Section_Desc = Convert.ToString(p.Field<string>("Chk_Section_Desc")),

                                                             ObjClChecklistConfigQuestion = (from x in DsDataSet.Tables[2].AsEnumerable()
                                                                                             where x.Field<decimal>("Chk_Section_ID") == p.Field<decimal>("Chk_Section_ID")
                                                                                             select new ClChecklistConfigQuestion
                                                                                             {

                                                                                                 CHK_Question_ID = Convert.ToInt32(x.Field<decimal>("CHK_Question_ID")),
                                                                                                 Chk_Section_ID = Convert.ToInt32(x.Field<decimal>("Chk_Section_ID")),
                                                                                                 Qn_Desc = Convert.ToString(x.Field<string>("Qn_Desc")),
                                                                                                 Is_Attach_Mandatory = Convert.ToBoolean(x.Field<bool>("Is_Attach_Mandatory")),
                                                                                                 Is_Qn_Mandatory = Convert.ToBoolean(x.Field<bool>("Is_Qn_Mandatory")),
                                                                                                 Qn_Score = Convert.ToInt32(x.Field<decimal>("Qn_Score")),
                                                                                                 Chk_Qn_Ref_Desc = Convert.ToString(x.Field<string>("Chk_Qn_Ref_Desc")),
                                                                                                 Chk_Qn_Ref_Photo = Convert.ToString(x.Field<string>("Chk_Qn_Ref_Photo")),
                                                                                                 Chk_Ans_Type_ID = Convert.ToInt32(x.Field<decimal>("Chk_Ans_Type_ID")),
                                                                                                 Is_Raise_Flag_Issue = Convert.ToBoolean(x.Field<bool>("Is_Raise_Flag_Issue")),

                                                                                                 ObjClChecklistConfigAnswerType = (from z in DsDataSet.Tables[4].AsEnumerable()
                                                                                                                                   where x.Field<decimal>("Chk_Ans_Type_ID") == z.Field<decimal>("Ans_Type_ID")
                                                                                                                                   select new ClChecklistConfigAnswerType
                                                                                                                                   {
                                                                                                                                       Ans_Type_ID = Convert.ToInt32(z.Field<decimal>("Ans_Type_ID")),
                                                                                                                                       Ans_Type_Desc = Convert.ToString(z.Field<string>("Ans_Type_Desc")),
                                                                                                                                       SDesc = Convert.ToString(z.Field<string>("SDesc")),
                                                                                                                                       Is_MultiValue = Convert.ToBoolean(z.Field<bool>("Is_MultiValue"))
                                                                                                                                   }).ToList(),

                                                                                                 ObjClChecklistConfigAnswer = (from y in DsDataSet.Tables[3].AsEnumerable()
                                                                                                                                   // where y.field<decimal>("chk_question_id ") == p.field<decimal>("chk_question_id ")
                                                                                                                               where y.Field<decimal>("chk_question_id") == x.Field<decimal>("chk_question_id")
                                                                                                                               select new ClChecklistConfigAnswer
                                                                                                                               {
                                                                                                                                   Chk_Ans_Value_ID = Convert.ToInt32(y.Field<decimal>("chk_ans_value_id")),
                                                                                                                                   CHK_Question_ID = Convert.ToInt32(y.Field<decimal>("chk_question_id")),
                                                                                                                                   Ans_Is_Flag = Convert.ToBoolean(y.Field<bool>("ans_is_flag")),
                                                                                                                                   Is_Default = Convert.ToBoolean(y.Field<bool>("is_default")),
                                                                                                                                   Chk_Ans_Desc = Convert.ToString(y.Field<string>("chk_ans_desc")),
                                                                                                                                   Chk_Ans_Type_ID = Convert.ToInt32(y.Field<decimal>("chk_ans_type_id"))
                                                                                                                               }).ToList(),

                                                                                                 ObjClChecklist_Response_Data_Values = (from Z in DsDataSet.Tables[5].AsEnumerable()
                                                                                                                                        where Z.Field<decimal>("chk_question_id") == x.Field<decimal>("chk_question_id")
                                                                                                                                        select new ClChecklist_Response_Data_Values
                                                                                                                                        {
                                                                                                                                            AnswerID = Convert.ToInt32(Z.Field<decimal>("Ans_Response_ID")),
                                                                                                                                            value = Convert.ToString(Z.Field<string>("Chk_Ans_Value_Data"))
                                                                                                                                        }).ToList()

                                                                                             }).ToList()
                                                         }).ToList();

                            //ObjChecklistConfigAnswerType = (from p in DsDataSet.Tables[4].AsEnumerable()
                            //                                select new ClChecklistConfigAnswerType
                            //                                {
                            //                                    Ans_Type_ID = Convert.ToInt32(p.Field<decimal>("Ans_Type_ID")),
                            //                                    Ans_Type_Desc = Convert.ToString(p.Field<string>("Ans_Type_Desc")),
                            //                                    SDesc = Convert.ToString(p.Field<string>("SDesc")),
                            //                                    Is_MultiValue = Convert.ToBoolean(p.Field<bool>("Is_MultiValue"))
                            //                                }).ToList();



                            ObjChecklistConfig.ObjClChecklistConfigHead = ObjChecklistConfigHead;
                            ObjChecklistConfig.ObjClChecklistConfigSection = ObjChecklistConfigSection;
                           // ObjChecklistConfig.ObjClChecklistConfigAnswerType = ObjChecklistConfigAnswerType;


                            return Request.CreateResponse(HttpStatusCode.OK, ObjChecklistConfig);
                            //return Request.CreateResponse(HttpStatusCode.OK, DsDataSet);
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
                //  ObjGatePass = null;
            }

        }
        #endregion


        #region "ASSET"

        [Route("api/UpKeep/Fetch_Asset_master")]
        [HttpGet]
        public HttpResponseMessage Fetch_Asset_master(int UserID) //, int CompanyID
        {

            clsMasterAsset ObjAssetMst = new clsMasterAsset();

            List<clsMasterAssestType> objAssetType = new List<clsMasterAssestType>();
            List<clsMasterAssestCategory> objAssetCategory = new List<clsMasterAssestCategory>();
            List<clsMasterAssestVendor> objAssetVendor = new List<clsMasterAssestVendor>();
            List<clsMasterAssestDepartement> objAssetDepartment = new List<clsMasterAssestDepartement>();
            List<clsMasterAssestLocation> objAssetLocation = new List<clsMasterAssestLocation>();
            List<clsMasterAssestAmcType> objAssetAMCType = new List<clsMasterAssestAmcType>();
            List<clsMasterAssestCurrency> objAssetCurrency = new List<clsMasterAssestCurrency>();
            List<clsMasterAssestUsers> objAssetUser = new List<clsMasterAssestUsers>();


            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();
            DataTable dt = new DataTable();
            string StrLocConnection = null;

            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@UserID", UserID);

                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "SPR_ASSET_FETCH_DROPDOWN_LIST", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            objAssetType = (from p in DsDataSet.Tables[0].AsEnumerable()
                                            select new clsMasterAssestType
                                            {
                                                Asset_Type_ID = Convert.ToInt32(p.Field<decimal>("Asset_Type_ID")),
                                                Asset_Type_Desc = Convert.ToString(p.Field<string>("Asset_Type_Desc"))

                                            }).ToList();
                        }
                        if (DsDataSet.Tables[1].Rows.Count > 0)
                        {
                            objAssetCategory = (from p in DsDataSet.Tables[1].AsEnumerable()
                                                select new clsMasterAssestCategory
                                                {
                                                    Asset_Type_ID = Convert.ToInt32(p.Field<decimal>("Asset_Type_ID")),
                                                    Asset_Category_ID = Convert.ToInt32(p.Field<decimal>("Asset_Category_ID")),
                                                    Category_Desc = Convert.ToString(p.Field<string>("Category_Desc"))

                                                }).ToList();
                        }
                        if (DsDataSet.Tables[2].Rows.Count > 0)
                        {
                            objAssetVendor = (from p in DsDataSet.Tables[2].AsEnumerable()
                                              select new clsMasterAssestVendor
                                              {
                                                  Vendor_ID = Convert.ToInt32(p.Field<decimal>("Vendor_ID")),
                                                  Vendor_Name = Convert.ToString(p.Field<string>("Vendor_Name"))

                                              }).ToList();
                        }
                        if (DsDataSet.Tables[3].Rows.Count > 0)
                        {
                            objAssetDepartment = (from p in DsDataSet.Tables[3].AsEnumerable()
                                                  select new clsMasterAssestDepartement
                                                  {
                                                      Department_ID = Convert.ToInt32(p.Field<decimal>("Department_ID")),
                                                      Dept_Desc = Convert.ToString(p.Field<string>("Dept_Desc"))

                                                  }).ToList();
                        }
                        if (DsDataSet.Tables[4].Rows.Count > 0)
                        {
                            objAssetLocation = (from p in DsDataSet.Tables[4].AsEnumerable()
                                                select new clsMasterAssestLocation
                                                {
                                                    Loc_id = Convert.ToInt32(p.Field<decimal>("Loc_id")),
                                                    Loc_Desc = Convert.ToString(p.Field<string>("Loc_Desc"))
                                                }).ToList();
                        }
                        if (DsDataSet.Tables[5].Rows.Count > 0)
                        {
                            objAssetAMCType = (from p in DsDataSet.Tables[5].AsEnumerable()
                                               select new clsMasterAssestAmcType
                                               {
                                                   Asset_AMC_Type_ID = Convert.ToInt32(p.Field<decimal>("Asset_AMC_Type_ID")),
                                                   Asset_AMC_Type_Desc = Convert.ToString(p.Field<string>("Asset_AMC_Type_Desc"))
                                               }).ToList();
                        }
                        if (DsDataSet.Tables[6].Rows.Count > 0)
                        {
                            objAssetCurrency = (from p in DsDataSet.Tables[6].AsEnumerable()
                                                select new clsMasterAssestCurrency
                                                {
                                                    Currency_ID = Convert.ToInt32(p.Field<int>("Currency_ID")),
                                                    Currency_Code = Convert.ToString(p.Field<string>("Currency_Code"))
                                                }).ToList();
                        }
                        if (DsDataSet.Tables[7].Rows.Count > 0)
                        {
                            objAssetUser = (from p in DsDataSet.Tables[7].AsEnumerable()
                                            select new clsMasterAssestUsers
                                            {
                                                User_ID = Convert.ToInt32(p.Field<int>("User_ID")),
                                                User_Code = Convert.ToString(p.Field<string>("User_Code")),
                                                Name = Convert.ToString(p.Field<string>("Name"))
                                            }).ToList();
                        }


                        ObjAssetMst.objAssetType = objAssetType;
                        ObjAssetMst.objAssetCategory = objAssetCategory;
                        ObjAssetMst.objAssetVendor = objAssetVendor;
                        ObjAssetMst.objAssetDepartment = objAssetDepartment;
                        ObjAssetMst.objAssetLocation = objAssetLocation;
                        ObjAssetMst.objAssetAMCType = objAssetAMCType;
                        ObjAssetMst.objAssetCurrency = objAssetCurrency;
                        ObjAssetMst.objAssetUser = objAssetUser;
                        return Request.CreateResponse(HttpStatusCode.OK, ObjAssetMst);
                        //return Request.CreateResponse(HttpStatusCode.OK, DsDataSet);
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
                //  ObjGatePass = null;
            }

        }

        [Route("api/UpKeep/Fetch_Asset_Request_Details")]
        [HttpGet]
        public HttpResponseMessage Fetch_Asset_Request_Details(int AssetId) //, int CompanyID
        {

            ClsAssetRequest ObjAssetRequest = new ClsAssetRequest();
            //ClsAssetRequestDetail ObjAssetRequestDetail = new ClsAssetRequestDetail();
            ClsAssetAMCRequest ObjAssetRequestAmcDetail = new ClsAssetAMCRequest();
            //ClsAssetAMCHistoryDetail ObjAssetRequestAmcHistoryDetail = new ClsAssetAMCHistoryDetail();
            //ClsAssetServiceDetail ObjAssetRequestServiceDetail = new ClsAssetServiceDetail();

            List<ClsAssetServiceDetail> ObjAssetService = new List<ClsAssetServiceDetail>();
            //List<ClsAssetAMCHistoryDoc> ObjAssetAmcHistoryDoc = new List<ClsAssetAMCHistoryDoc>();
            List<ClsAssetAMCHistoryDetail> ObjAssetAmcHistory = new List<ClsAssetAMCHistoryDetail>();
            List<ClsAssetAMCDetail> ObjAssetAmc = new List<ClsAssetAMCDetail>();
            //List<ClsAssetAMCDoc> ObjAssetAmcDoc = new List<ClsAssetAMCDoc>();
            //List<ClsAssetRequestDoc> ObjAssetDoc = new List<ClsAssetRequestDoc>();
            List<ClsAssetRequestDetail> ObjAssetDetail = new List<ClsAssetRequestDetail>();

            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsDataSet = new DataSet();
            DataTable dt = new DataTable();
            string StrLocConnection = null;

            try
            {
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);

                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@AssetID", AssetId);
                //ObjLocSqlParameter[1] = new SqlParameter("@LoggedInUserID", LoggedInUserID);
                //ObjLocSqlParameter[2] = new SqlParameter("@CompanyID", CompanyID);

                DsDataSet = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "SPR_ASSET_FETCH_ASSET_REQUEST", ObjLocSqlParameter);

                if (DsDataSet != null)
                {
                    if (DsDataSet.Tables.Count > 0)
                    {
                        if (DsDataSet.Tables[0].Rows.Count > 0)
                        {
                            ObjAssetDetail = (from p in DsDataSet.Tables[0].AsEnumerable()
                                              select new ClsAssetRequestDetail
                                              {
                                                  Asset_ID = Convert.ToInt32(p.Field<decimal>("Asset_ID")),
                                                  Asset_Type_ID = Convert.ToInt32(p.Field<decimal>("Asset_Type_ID")),
                                                  Asset_Category_ID = Convert.ToInt32(p.Field<decimal>("Asset_Category_ID")),
                                                  Asset_Name = Convert.ToString(p.Field<string>("Asset_Name")),
                                                  Asset_Desc = Convert.ToString(p.Field<string>("Asset_Desc")),
                                                  Asset_Make = Convert.ToString(p.Field<string>("Asset_Make")),
                                                  Asset_Serial_No = Convert.ToString(p.Field<string>("Asset_Serial_No")),
                                                  Vendor_ID = Convert.ToInt32(p.Field<decimal>("Vendor_ID")),
                                                  Department_ID = Convert.ToInt32(p.Field<decimal>("Department_ID")),
                                                  Loc_id = Convert.ToInt32(p.Field<decimal>("Loc_id")),
                                                  Asset_Cost = Convert.ToInt32(p.Field<decimal>("Asset_Cost")),
                                                  Currency_Type = Convert.ToString(p.Field<string>("Currency_Type")),
                                                  Asset_Purchase_Date = Convert.ToString(p.Field<string>("Asset_Purchase_Date")),
                                                  Asset_Is_AMC_Active = Convert.ToBoolean(p.Field<bool>("Asset_Is_AMC_Active")),
                                                  Company_ID = Convert.ToInt32(p.Field<decimal>("Company_ID")),
                                                  Loc_Desc = Convert.ToString(p.Field<string>("Loc_Desc")),

                                                  objAssetDoc = (from x in DsDataSet.Tables[1].AsEnumerable()
                                                                 select new ClsAssetRequestDoc
                                                                 {
                                                                     Asset_Doc_Type = Convert.ToString(x.Field<string>("Asset_Doc_Type")),
                                                                     ImagePath = Convert.ToString(x.Field<string>("ImagePath")),
                                                                 }).ToList()
                                              }).ToList();
                        }
                        if (DsDataSet.Tables[2].Rows.Count > 0)
                        {
                            ObjAssetAmc = (from p in DsDataSet.Tables[2].AsEnumerable()
                                           select new ClsAssetAMCDetail
                                           {
                                               Asset_AMC_ID = Convert.ToInt32(p.Field<decimal>("Asset_AMC_ID")),
                                               Asset_AMC_Type_ID = Convert.ToInt32(p.Field<decimal>("Asset_AMC_Type_ID")),
                                               Asset_ID = Convert.ToInt32(p.Field<decimal>("Asset_ID")),
                                               AMC_Desc = Convert.ToString(p.Field<string>("AMC_Desc")),
                                               AMC_Start_Date = Convert.ToString(p.Field<string>("AMC_Start_Date")),
                                               AMC_End_Date = Convert.ToString(p.Field<string>("AMC_End_Date")),
                                               Assigned_Vendor = Convert.ToInt32(p.Field<decimal>("Assigned_Vendor")),
                                               AMC_Inclusions = Convert.ToString(p.Field<string>("AMC_Inclusions")),
                                               AMC_Exclusions = Convert.ToString(p.Field<string>("AMC_Exclusions")),
                                               AdditionalRemarks = Convert.ToString(p.Field<string>("Additional Remarks")),
                                               AMC_Status = Convert.ToString(p.Field<string>("AMC_Status")),
                                               Vendor_Name = Convert.ToString(p.Field<string>("Vendor_Name")),

                                               objAssetAmcDoc = (from x in DsDataSet.Tables[3].AsEnumerable()
                                                                 select new ClsAssetAMCDoc
                                                                 {
                                                                     Asset_AMC_Doc_Type = Convert.ToString(x.Field<string>("Asset_AMC_Doc_Type")),
                                                                     ImagePath = Convert.ToString(x.Field<string>("ImagePath")),
                                                                 }).ToList()
                                           }).ToList();
                        }
                        if (DsDataSet.Tables[4].Rows.Count > 0)
                        {
                            ObjAssetService = (from p in DsDataSet.Tables[4].AsEnumerable()
                                               select new ClsAssetServiceDetail
                                               {
                                                   Schedule_ID = Convert.ToInt32(p.Field<decimal>("Schedule_ID")),
                                                   Asset_ID = Convert.ToInt32(p.Field<decimal>("Asset_ID")),
                                                   Service_Date = Convert.ToString(p.Field<string>("Service_Date")),
                                                   Alert_Date = Convert.ToString(p.Field<string>("Alert_Date")),
                                                   Assigned_To = Convert.ToInt32(p.Field<decimal>("Assigned_To")),
                                                   Service_Status = Convert.ToString(p.Field<string>("Service_Status")),
                                                   Remarks = Convert.ToString(p.Field<string>("Remarks")),
                                                   Alert_Day = Convert.ToInt32(p.Field<int>("Alert_Day"))
                                               }).ToList();
                        }
                        if (DsDataSet.Tables[5].Rows.Count > 0)
                        {
                            ObjAssetAmcHistory = (from p in DsDataSet.Tables[5].AsEnumerable()
                                                  select new ClsAssetAMCHistoryDetail
                                                  {
                                                      Asset_AMC_ID = Convert.ToInt32(p.Field<decimal>("Asset_AMC_ID")),
                                                      Asset_AMC_Type_ID = Convert.ToInt32(p.Field<decimal>("Asset_AMC_Type_ID")),
                                                      Asset_ID = Convert.ToInt32(p.Field<decimal>("Asset_ID")),
                                                      AMC_Desc = Convert.ToString(p.Field<string>("AMC_Desc")),
                                                      AMC_Start_Date = Convert.ToString(p.Field<string>("AMC_Start_Date")),
                                                      AMC_End_Date = Convert.ToString(p.Field<string>("AMC_End_Date")),
                                                      Assigned_Vendor = Convert.ToInt32(p.Field<decimal>("Assigned_Vendor")),
                                                      AMC_Inclusions = Convert.ToString(p.Field<string>("AMC_Inclusions")),
                                                      AMC_Exclusions = Convert.ToString(p.Field<string>("AMC_Exclusions")),
                                                      AdditionalRemarks = Convert.ToString(p.Field<string>("Additional Remarks")),
                                                      AMC_Status = Convert.ToString(p.Field<string>("AMC_Status")),
                                                      Vendor_Name = Convert.ToString(p.Field<string>("Vendor_Name")),
                                                      Asset_AMC_Type_Desc = Convert.ToString(p.Field<string>("Asset_AMC_Type_Desc")),
                                                      objAssetAmcHistoryDoc = (from x in DsDataSet.Tables[6].AsEnumerable()
                                                                               select new ClsAssetAMCHistoryDoc
                                                                               {
                                                                                   Asset_AMC_Doc_Type = Convert.ToString(x.Field<string>("Asset_AMC_Doc_Type")),
                                                                                   ImagePath = Convert.ToString(x.Field<string>("ImagePath")),
                                                                               }).ToList()
                                                  }).ToList();
                        }

                        ObjAssetRequestAmcDetail.objAssetAmc = ObjAssetAmc;
                        ObjAssetRequestAmcDetail.objAssetAmcHistory = ObjAssetAmcHistory;


                        ObjAssetRequest.objAssetDetail = ObjAssetDetail;
                        ObjAssetRequest.objAssetAmcDetail = ObjAssetRequestAmcDetail;
                        ObjAssetRequest.objAssetServiceDetailc = ObjAssetService;

                        return Request.CreateResponse(HttpStatusCode.OK, ObjAssetRequest);
                        //return Request.CreateResponse(HttpStatusCode.OK, DsDataSet);
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
                //  ObjGatePass = null;
            }

        }

        #endregion

    }
}