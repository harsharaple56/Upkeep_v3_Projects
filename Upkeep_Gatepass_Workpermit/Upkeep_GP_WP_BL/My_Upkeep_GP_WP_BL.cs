using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;
using System.Data;


namespace Upkeep_GP_WP_BL
{
  public class My_Upkeep_GP_WP_BL
    {
        public DataSet Fetch_User_UserGroupList(string Initiator, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Upkeep_Spr_FetchUser_UserGroup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Initiator", Initiator);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Fetch_Company(string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_GP_FETCHCOMPANY", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Insert_GatePassConfiguration(string strConfigTitle, int CompanyID, string strInitiator, bool LinkDepartment,string strTransactionPrefix, string strXmlGatepass_Header, string strXmlGatepass_Type, string strXmlGatepass_TermCondition, string strXmlApprovalMatrix,bool ShowApprovalMatrix, string strGPClosureBy,string GatepassDescription, string LoggedInUserID,string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_INSERT_GP_CONFIG", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ConfigTitle", strConfigTitle);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@Initiator", strInitiator);
                cmd.Parameters.AddWithValue("@LinkDepartment", LinkDepartment);
                cmd.Parameters.AddWithValue("@TransactionPrefix", strTransactionPrefix);
                cmd.Parameters.AddWithValue("@XmlGatepass_Header", strXmlGatepass_Header);
                cmd.Parameters.AddWithValue("@XmlGatepass_Type", strXmlGatepass_Type);
                cmd.Parameters.AddWithValue("@XmlGatepass_TermCondition", strXmlGatepass_TermCondition);
                cmd.Parameters.AddWithValue("@XmlApprovalMatrix", strXmlApprovalMatrix); 
                cmd.Parameters.AddWithValue("@ShowApprovalMatrix", ShowApprovalMatrix);
                cmd.Parameters.AddWithValue("@GPClosureBy", strGPClosureBy); 
                cmd.Parameters.AddWithValue("@GatepassDescription", GatepassDescription);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Fetch_GatePassConfiguration(string Initiator, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_GP_CONFIG", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Initiator", Initiator);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Bind_GatePassConfiguration(int GP_ConfigID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_GP_CONFIG_DETAILS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@GP_ConfigID", GP_ConfigID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GatePassHeader_CRUD(int GatePassHeaderID, string GatePassHeader, bool GPHeaderNumeric, int GPHeaderUnit, int GatePass_ConfigID, string LoggedInUserID,string strAction, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_GatePassHeader_CRUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@GatePassHeaderID", GatePassHeaderID);
                cmd.Parameters.AddWithValue("@GatePassHeader", GatePassHeader);
                cmd.Parameters.AddWithValue("@GPHeaderNumeric", GPHeaderNumeric);
                cmd.Parameters.AddWithValue("@GPHeaderUnit", GPHeaderUnit);
                cmd.Parameters.AddWithValue("@GatePass_ConfigID", GatePass_ConfigID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Action", strAction);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GatePassType_CRUD(int GP_TypeID, string GP_TypeDesc, int GatePass_ConfigID, string LoggedInUserID, string strAction, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_GatePassType_CRUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@GPTypeID", GP_TypeID);
                cmd.Parameters.AddWithValue("@GPType_Desc", GP_TypeDesc);
                cmd.Parameters.AddWithValue("@GatePass_ConfigID", GatePass_ConfigID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Action", strAction);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GatePassTerm_CRUD(int GP_TermID, string GP_TermDesc, int GatePass_ConfigID, string LoggedInUserID, string strAction, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_GatePassTerm_CRUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@GPTermID", GP_TermID);
                cmd.Parameters.AddWithValue("@GPTerm_Desc", GP_TermDesc);
                cmd.Parameters.AddWithValue("@GatePass_ConfigID", GatePass_ConfigID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Action", strAction);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Update_GatePassConfiguration(int GP_Config_ID,string strConfigTitle, int CompanyID, string strInitiator, bool LinkDepartment,string strTransactionPrefix, string strXmlApprovalMatrix,bool ShowApprovalMatrix, string strGPClosureBy,string GatepassDescription, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_UPDATE_GP_CONFIG", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@GP_Config_ID", GP_Config_ID);
                cmd.Parameters.AddWithValue("@ConfigTitle", strConfigTitle);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@Initiator", strInitiator);
                cmd.Parameters.AddWithValue("@LinkDepartment", LinkDepartment);
                cmd.Parameters.AddWithValue("@TransactionPrefix", strTransactionPrefix);
                cmd.Parameters.AddWithValue("@XmlApprovalMatrix", strXmlApprovalMatrix); 
                cmd.Parameters.AddWithValue("@ShowApprovalMatrix", ShowApprovalMatrix);
                cmd.Parameters.AddWithValue("@GPClosureBy", strGPClosureBy); 
                cmd.Parameters.AddWithValue("@GatepassDescription", GatepassDescription);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Bind_GatePassRequestDetails(int GP_ConfigID, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_GP_REQUEST_DATA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@GP_ConfigID", GP_ConfigID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Insert_GatePassRequest(int GP_ConfigID, string strGatePassDate, int DeptID, int GPTypeID, string strGPHeader,string strGPHeaderData, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_INSERT_GP_REQUEST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@GP_ConfigID", GP_ConfigID);
                cmd.Parameters.AddWithValue("@GatePassDate", strGatePassDate);
                cmd.Parameters.AddWithValue("@DeptID", DeptID);
                cmd.Parameters.AddWithValue("@GPTypeID", GPTypeID);
                cmd.Parameters.AddWithValue("@GPHeader", strGPHeader);
                cmd.Parameters.AddWithValue("@GPHeaderData", strGPHeaderData);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Fetch_MyRequestGatePass(string LoggedInUserID, string From_Date, string To_Date, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_MYREQUEST_GP", con);
                cmd.CommandType = CommandType.StoredProcedure;               
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@From_Date", From_Date);
                cmd.Parameters.AddWithValue("@To_Date", To_Date);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Fetch_MyActionableGatePass(string LoggedInUserID, string From_Date, string To_Date, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_MyActionable_GP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@From_Date", From_Date);
                cmd.Parameters.AddWithValue("@To_Date", To_Date);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Fetch_GatePassRequest_Approval_Details(int TransactionID, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_GP_REQUEST_APPROVAL_DETAILS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TransactionID", TransactionID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet UpdateAction_GatePassRequest(string TransactionID, string CurrentLevel, string ActionStatus, string strRemarks, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_UpdateAction_GP_Request", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TransactionID", TransactionID);
                cmd.Parameters.AddWithValue("@CurrentLevel", CurrentLevel);
                cmd.Parameters.AddWithValue("@ActionStatus", ActionStatus);
                cmd.Parameters.AddWithValue("@Remarks", strRemarks);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet User_Login(string UserName, string strPassword,string UserType, string strConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(strConn);

                SqlCommand cmd = new SqlCommand("Spr_GP_Login", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Password", strPassword);
                cmd.Parameters.AddWithValue("@UserType", UserType);
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Work_Permit


        //Added by RC WorkPermitConfiguration Save

        public DataSet Insert_WorkPermitConfiguration(string strConfigTitle, int CompanyID, string strInitiator, bool LinkDepartment, string strTransactionPrefix, string strXmlWorkPermit_Header, string strXmlWorkPermit_TermCondition, string strXmlApprovalMatrix, bool ShowApprovalMatrix, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_INSERT_WP_CONFIG", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ConfigTitle", strConfigTitle);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@Initiator", strInitiator);
                cmd.Parameters.AddWithValue("@LinkDepartment", LinkDepartment);
                cmd.Parameters.AddWithValue("@TransactionPrefix", strTransactionPrefix);
                cmd.Parameters.AddWithValue("@XmlWorkPermit_Header", strXmlWorkPermit_Header);
                //cmd.Parameters.AddWithValue("@XmlGatepass_Type", strXmlGatepass_Type);
                cmd.Parameters.AddWithValue("@XmlWorkPermit_TermCondition", strXmlWorkPermit_TermCondition);
                cmd.Parameters.AddWithValue("@XmlApprovalMatrix", strXmlApprovalMatrix);
                cmd.Parameters.AddWithValue("@ShowApprovalMatrix", ShowApprovalMatrix);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Fetch_Answer(string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_WP_AnsMst", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Fetch_WorkPermitConfiguration(string Initiator, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_WP_CONFIG", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Initiator", Initiator);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Bind_WorkPermitConfiguration(int WP_ConfigID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_WP_CONFIG_DETAILS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WP_ConfigID", WP_ConfigID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Bind_WorkPermitRequestDetails(int WP_ConfigID, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_WP_REQUEST_DATA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WP_ConfigID", Convert.ToInt32(WP_ConfigID));
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public DataSet Insert_WorkPermitRequest(int WP_ConfigID, string LoggedInUserID, string strWpDate, string strWpSectionHeaderData, string StrConn)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        SqlConnection con = new SqlConnection(StrConn);
        //        SqlCommand cmd = new SqlCommand("SPR_INSERT_WP_REQUEST", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@WP_ConfigID", WP_ConfigID);
        //        cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
        //        cmd.Parameters.AddWithValue("@WpDate", strWpDate);
        //        cmd.Parameters.AddWithValue("@WpData", strWpSectionHeaderData);

        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(ds);
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public DataSet Insert_WorkPermitRequest(int WP_ConfigID, string LoggedInUserID, string strWpDate, string strWpTpDate, string strWpSectionHeaderData, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_INSERT_WP_REQUEST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WP_ConfigID", WP_ConfigID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@WpDate", strWpDate);
                cmd.Parameters.AddWithValue("@WpToDate", strWpTpDate);
                cmd.Parameters.AddWithValue("@WpData", strWpSectionHeaderData);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Fetch_WorkPermitRequestSavedData(int WP_ConfigID, int Transaction_ID, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_SAVED_WP_REQUEST_DATA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WP_ConfigID", WP_ConfigID);
                cmd.Parameters.AddWithValue("@Transaction_ID", Transaction_ID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Update_WorkPermitRequest(int TransactionID, string LoggedInUserID, string ActionStatus, string Remarks, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_UpdateAction_WP_Request", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TransactionID", TransactionID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@ActionStatus", ActionStatus);
                cmd.Parameters.AddWithValue("@Remarks", Remarks);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Fetch_MyRequestWorkPermit(string LoggedInUserID, string From_Date, string To_Date, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_MYREQUEST_WP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@From_Date", From_Date);
                cmd.Parameters.AddWithValue("@To_Date", To_Date);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Fetch_MyActionableWorkPermit(string LoggedInUserID, string From_Date, string To_Date, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_MyActionable_WP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@From_Date", From_Date);
                cmd.Parameters.AddWithValue("@To_Date", To_Date);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Fetch_DashboardCount(int CompanyID,string LoggedInUserID, string From_Date, string To_Date, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_Dashboard_Count", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@FromDate", From_Date);
                cmd.Parameters.AddWithValue("@ToDate", To_Date);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Delete_GatePassConfiguration(int ConfigID, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_DELETE_GP_CONFIG", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@GPConfigID", ConfigID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Added by RC WorkPermitConfiguration Update
        public DataSet Update_WorkPermitConfiguration(int WP_Config_ID, string strConfigTitle, int CompanyID, string strInitiator, bool LinkDepartment, string strTransactionPrefix, string strXmlWorkPermit_Header, string strXmlWorkPermit_TermCondition, string strXmlApprovalMatrix, bool ShowApprovalMatrix, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_UPDATE_WP_CONFIG", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@WP_Config_ID", WP_Config_ID);
                cmd.Parameters.AddWithValue("@ConfigTitle", strConfigTitle);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@Initiator", strInitiator);
                cmd.Parameters.AddWithValue("@LinkDepartment", LinkDepartment);
                cmd.Parameters.AddWithValue("@TransactionPrefix", strTransactionPrefix);
                cmd.Parameters.AddWithValue("@XmlWorkPermit_Header", strXmlWorkPermit_Header);
                //cmd.Parameters.AddWithValue("@XmlGatepass_Type", strXmlGatepass_Type);
                cmd.Parameters.AddWithValue("@XmlWorkPermit_TermCondition", strXmlWorkPermit_TermCondition);
                cmd.Parameters.AddWithValue("@XmlApprovalMatrix", strXmlApprovalMatrix);
                cmd.Parameters.AddWithValue("@ShowApprovalMatrix", ShowApprovalMatrix);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Bind_WorkPermitSavedConfiguration(int WP_ConfigID, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_SAVED_WP_CONFIG_DETAILS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WP_ConfigID", Convert.ToInt32(WP_ConfigID));
                cmd.Parameters.AddWithValue("@WP_TransID", LoggedInUserID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet Fetch_GatePass_MIS(string LoggedInUserID, string From_Date, string To_Date, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_MYREQUEST_GP_MIS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@From_Date", From_Date);
                cmd.Parameters.AddWithValue("@To_Date", To_Date);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataSet Fetch_WorkPermit_MIS(string LoggedInUserID, string From_Date, string To_Date, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_MYREQUEST_WP_MIS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@From_Date", From_Date);
                cmd.Parameters.AddWithValue("@To_Date", To_Date);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Role Management
        public DataSet FetchMenu(int parentMenuId, string LoggedInUserID, string StrConn)
        {
            DataSet dtMenu = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_MenuDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@parentMenuId", parentMenuId);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtMenu);
                return dtMenu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet RoleMaster_CRUD(int RoleID, string Role, string LoggedInUserID, string strAction, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_RM_ROLE_CRUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoleID", RoleID);
                cmd.Parameters.AddWithValue("@Role", Role);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Action", strAction);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Fetch_Assigned_Role(int RoleID, string StrConn)
        {
            DataSet dtMenu = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Fetch_RM_Assigned_Role", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoleID", RoleID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtMenu);
                return dtMenu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Fetch_Role_Menu(string StrConn)
        {
            DataSet dsMenu = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_RM_FETCH_ROLE_MENU", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsMenu);
                return dsMenu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet FETCH_Saved_Role_MENU_Rights(int RoleID, int ParentMenuId, string StrConn)
        {
            DataSet dsMenu = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_RM_FETCH_Saved_Role_MENU_Rights", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoleID", RoleID);
                cmd.Parameters.AddWithValue("@ParentMenuId", ParentMenuId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsMenu);
                return dsMenu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Insert_RoleMenuRights(int RoleId, int ParentMenuId, string LoggedInUserID, string strWpSectionHeaderData, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_RM_INSERT_Role_Menu_Rights", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoleId", RoleId);
                cmd.Parameters.AddWithValue("@ParentMenuId", ParentMenuId);
                cmd.Parameters.AddWithValue("@username", LoggedInUserID);
                cmd.Parameters.AddWithValue("@XMLData", strWpSectionHeaderData);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Insert_Assigned_Role(int RoleID, string SelectedEmployees, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_RM_Insert_Assigned_Role", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RoleID", RoleID);
                cmd.Parameters.AddWithValue("@SelectedEmployees", SelectedEmployees);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Fetch_RoleListing(string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_RM_Fetch_Role_List", con);
                cmd.CommandType = CommandType.StoredProcedure;
               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        #endregion





        #region Checklist
        public DataSet Fetch_Chk_Answer(string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_CHK_ANS_MST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet Update_ChecklistConfiguration(int Chk_Config_ID, string strConfigTitle, string strConfigTitleDesc, bool IsScoreEnable, int TotalScore, string strXmlChecklist, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_UPDATE_CHK_CONFIG", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Chk_Config_ID", Chk_Config_ID);
                cmd.Parameters.AddWithValue("@ConfigTitle", strConfigTitle);
                cmd.Parameters.AddWithValue("@ConfigTitleDesc", strConfigTitleDesc);
                cmd.Parameters.AddWithValue("@IsScoreEnable", IsScoreEnable);
                cmd.Parameters.AddWithValue("@TotalScore", TotalScore);
                cmd.Parameters.AddWithValue("@XmlChecklist_Config", strXmlChecklist);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataSet Insert_ChecklistConfiguration(string strConfigTitle, string strConfigTitleDesc, bool IsScoreEnable, int TotalScore, string strXmlChecklist, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_INSERT_CHK_CONFIG", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ConfigTitle", strConfigTitle);
                cmd.Parameters.AddWithValue("@ConfigTitleDesc", strConfigTitleDesc);
                cmd.Parameters.AddWithValue("@IsScoreEnable", IsScoreEnable);
                cmd.Parameters.AddWithValue("@TotalScore", TotalScore);
                cmd.Parameters.AddWithValue("@XmlChecklist_Config", strXmlChecklist);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Bind_ChecklistConfiguration(int Chk_ConfigID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_CHK_CONFIG_DETAILS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CHK_ConfigID", Chk_ConfigID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet Fetch_MyChecklist(string LoggedInUserID, string From_Date, string To_Date, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_CHK_MYCHECKLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@From_Date", From_Date);
                cmd.Parameters.AddWithValue("@To_Date", To_Date);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


    }
}
