using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Text;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.Configuration;
//using ShawMan.Libraries;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace eFacilito_MobileApp_WebAPI.Models
{
    public class ClsCommunication
    {
        public DataSet FunPubGetDataSet(string StrLocCnn, CommandType ObjLocType, string StrLocSelectStatement, SqlParameter[] ObjLocParas)
        {
            DataSet DsLocGetData = new DataSet();
            using (SqlConnection ObjLocConnection = new SqlConnection(StrLocCnn))
            {

                SqlCommand ObjLocCommand = new SqlCommand();

                if (ObjLocType == CommandType.StoredProcedure)
                {
                    ObjLocCommand.CommandType = CommandType.StoredProcedure;
                    ObjLocCommand.CommandText = StrLocSelectStatement;
                }
                else
                {
                    ObjLocCommand.CommandType = CommandType.Text;
                    ObjLocCommand.CommandText = StrLocSelectStatement;
                }

                ObjLocCommand.Parameters.Clear();
                int IntLocCtr1 = 0;
                for (IntLocCtr1 = 0; IntLocCtr1 <= ObjLocParas.GetUpperBound(0); IntLocCtr1++)
                {
                    if ((ObjLocParas[IntLocCtr1] != null))
                    {
                        ObjLocCommand.Parameters.Add(ObjLocParas[IntLocCtr1]);
                    }
                }
                ObjLocCommand.Connection = ObjLocConnection;
                ObjLocCommand.CommandTimeout = 0;

                SqlDataAdapter ObjLocAdapter = new SqlDataAdapter(ObjLocCommand);
                ObjLocAdapter.Fill(DsLocGetData);

                return DsLocGetData;
            }
        }
        public DataSet FunPubGetDataSet(string StrLocCnn, CommandType ObjLocType, string StrLocSelectStatement)
        {
            DataSet DsLocGetData = new DataSet();
            using (SqlConnection ObjLocConnection = new SqlConnection(StrLocCnn))
            {

                SqlCommand ObjLocCommand = new SqlCommand();

                if (ObjLocType == CommandType.StoredProcedure)
                {
                    ObjLocCommand.CommandType = CommandType.StoredProcedure;
                    ObjLocCommand.CommandText = StrLocSelectStatement;
                }
                else
                {
                    ObjLocCommand.CommandType = CommandType.Text;
                    ObjLocCommand.CommandText = StrLocSelectStatement;
                }

                ObjLocCommand.Parameters.Clear();


                ObjLocCommand.Connection = ObjLocConnection;
                ObjLocCommand.CommandTimeout = 0;

                SqlDataAdapter ObjLocAdapter = new SqlDataAdapter(ObjLocCommand);
                ObjLocAdapter.Fill(DsLocGetData);

                return DsLocGetData;
            }
        }
        public void FunPubPostData(string StrLocCnn, CommandType ObjLocType, string StrLocSelectStatement, SqlParameter[] ObjLocParas)
        {
            DataSet DsLocGetData = new DataSet();
            using (SqlConnection ObjLocConnection = new SqlConnection(StrLocCnn))
            {

                SqlCommand ObjLocCommand = new SqlCommand();

                if (ObjLocType == CommandType.StoredProcedure)
                {
                    ObjLocCommand.CommandType = CommandType.StoredProcedure;
                    ObjLocCommand.CommandText = StrLocSelectStatement;
                }
                else
                {
                    ObjLocCommand.CommandType = CommandType.Text;
                    ObjLocCommand.CommandText = StrLocSelectStatement;
                }

                ObjLocCommand.Parameters.Clear();
                int IntLocCtr1 = 0;
                for (IntLocCtr1 = 0; IntLocCtr1 <= ObjLocParas.GetUpperBound(0); IntLocCtr1++)
                {
                    if ((ObjLocParas[IntLocCtr1] != null))
                    {
                        ObjLocCommand.Parameters.Add(ObjLocParas[IntLocCtr1]);
                    }
                }
                ObjLocCommand.Connection = ObjLocConnection;
                ObjLocCommand.CommandTimeout = 0;

                SqlDataAdapter ObjLocAdapter = new SqlDataAdapter(ObjLocCommand);
                ObjLocAdapter.Fill(DsLocGetData);


            }
        }

    }
}