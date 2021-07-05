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
using Newtonsoft.Json;

namespace eFacilito_MobileApp_WebAPI.Controllers
{
    public class CocktailWorld_Controller : ApiController
    {
        [Route("api/CocktailWorld/Validate_CW_Account_Migration")]
        [HttpGet]
        public HttpResponseMessage Validate_CW_Account_Migration(string StrCompanyCode , string StrUserName, string StrPassword)
        {
            List<Cls_CW_Validate_Account_Migration> Obj_ValidateAccount = new List<Cls_CW_Validate_Account_Migration>();

            ClsCommunication ObjLocComm = new ClsCommunication();
            DataSet DsValidateAccount = new DataSet();

            string StrLocConnection = null;

            try
            {

                if (StrUserName == null)
                    StrUserName = "";
                if (StrPassword == null)
                    StrPassword = "";
                StrLocConnection = Convert.ToString(ConfigurationManager.ConnectionStrings["StrSqlConnUpkeep"].ConnectionString);
                SqlParameter[] ObjLocSqlParameter = new SqlParameter[3];
                ObjLocSqlParameter[0] = new SqlParameter("@Company_Code", StrCompanyCode);
                ObjLocSqlParameter[1] = new SqlParameter("@Username", StrUserName);
                ObjLocSqlParameter[2] = new SqlParameter("@Password", StrPassword);

                DsValidateAccount = ObjLocComm.FunPubGetDataSet(StrLocConnection, CommandType.StoredProcedure, "Spr_CW_Validate_Account_Migration", ObjLocSqlParameter);

                if (DsValidateAccount != null)
                {
                    if (DsValidateAccount.Tables.Count > 0)
                    {
                        if (DsValidateAccount.Tables[0].Rows.Count > 0)
                        {
                            Obj_ValidateAccount = (from p in DsValidateAccount.Tables[1].AsEnumerable()
                                           select new Cls_CW_Validate_Account_Migration
                                           {

                                               //ProPubStrEmployeeID = Convert.ToString(p.Field<int>("User_ID")),
                                               Status = p.Field<int>("Status"),
                                               Company_ID = p.Field<int>("Company_ID")
                                               

                                           }).ToList();
                            //return ObjLocLogin;
                            return Request.CreateResponse(HttpStatusCode.OK, Obj_ValidateAccount);
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
                DsValidateAccount = null;
                Obj_ValidateAccount = null;
            }

        }


    }


}
