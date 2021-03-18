using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;
using System.Data;


namespace Upkeep_BusinessLayer
{
    public class UpkeepCC_BL
    {
        public DataSet GroupMaster_CRUD(int Group_ID, string Group_Desc, string Group_Code, string LoggedInUserID, string Is_Deleted, string Action, string strConn)
        {
            DataSet ds = new DataSet();
            string strOutput = string.Empty;

            try
            {
                SqlConnection con = new SqlConnection(strConn);

                SqlCommand cmd = new SqlCommand("Spr_CRUD_Group_Mst", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Group_ID", Group_ID);
                cmd.Parameters.AddWithValue("@Group_Desc", Group_Desc);

                cmd.Parameters.AddWithValue("@Group_Code", Group_Code);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Is_Deleted", Is_Deleted);
                cmd.Parameters.AddWithValue("@Action", Action);

                //cmd.Parameters.Add("@Outbit", SqlDbType.Int, Outbit);
                //cmd.Parameters["@Outbit"].Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("@OutMsg", SqlDbType.Int, Outbit);
                //cmd.Parameters["@OutMsg"].Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("@Outbit", SqlDbType.Int).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("@OutMsg", SqlDbType.Int).Direction = ParameterDirection.Output;           

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                //Outbit= Convert.ToInt32(cmd.Parameters["@Outbit"].Value);
                //OutMsg = Convert.ToString(cmd.Parameters["@OutMsg"].Value);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet CC_Dashboard(string strConn)
        {
            DataSet ds = new DataSet();
            string strOutput = string.Empty;

            try
            {
                SqlConnection con = new SqlConnection(strConn);

                SqlCommand cmd = new SqlCommand("Spr_CC_Dashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("@Total_Employee_Users", Total_Employee_Users);
                //cmd.Parameters.AddWithValue("@Total_Retailers", Total_Retailers);

                //cmd.Parameters.AddWithValue("@Total_Users", Total_Users);
               
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

        //public DataSet CC_Dashboard_Company(string strConn)
        //{
        //    DataSet ds = new DataSet();
        //    string strOutput = string.Empty;

        //    try
        //    {
        //        SqlConnection con = new SqlConnection(strConn);

        //        SqlCommand cmd = new SqlCommand("Spr_CC_Dashboard_Company", con);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        //cmd.Parameters.AddWithValue("@Total_Employee_Users", Total_Employee_Users);
        //        //cmd.Parameters.AddWithValue("@Total_Retailers", Total_Retailers);

        //        //cmd.Parameters.AddWithValue("@Total_Users", Total_Users);

        //        con.Open();

        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(ds);


        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        public DataSet Fetch_GroupDesc(string strConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(strConn);

                SqlCommand cmd = new SqlCommand("SPR_FETCH_GROUPDESC", con);
                cmd.CommandType = CommandType.StoredProcedure;

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

        public DataSet CompanyMaster_CRUD(int CompanyID, string strCompanyCode, string strCompanyDesc, int GroupID, string CompanyLogo, string ClientURL, int Is_DBatClientServer, string ConString,string CompanyEmailID,string CompanyMobileNo, string User_FName, string User_LName, string User_Dept, string User_Code, string User_Name,string User_Designation,string User_EmailID,string User_MobileNo,int SMS_ConfigID,int SMS_Alloted,int SMS_Min_Bal_Alert,int SMS_Available_Balance, string LoggedInUserID, string Action, string strConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(strConn);

                SqlCommand cmd = new SqlCommand("Spr_CRUD_Company_Mst", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Company_ID", CompanyID);
                cmd.Parameters.AddWithValue("@Company_Code", strCompanyCode);
                cmd.Parameters.AddWithValue("@Company_Desc", strCompanyDesc);
                cmd.Parameters.AddWithValue("@Group_ID", GroupID);

                cmd.Parameters.AddWithValue("@Company_Logo", CompanyLogo);
                cmd.Parameters.AddWithValue("@Client_URL", ClientURL);
                cmd.Parameters.AddWithValue("@Is_DBatClientServer", Is_DBatClientServer);
                cmd.Parameters.AddWithValue("@Con_String", ConString); 
                cmd.Parameters.AddWithValue("@CompanyEmailID", CompanyEmailID);
                cmd.Parameters.AddWithValue("@CompanyMobileNo", CompanyMobileNo);

                cmd.Parameters.AddWithValue("@User_FName", User_FName);
                cmd.Parameters.AddWithValue("@User_LName",User_LName);
                cmd.Parameters.AddWithValue("@User_Dept",User_Dept);
                cmd.Parameters.AddWithValue("@User_Code",User_Code);

                cmd.Parameters.AddWithValue("@User_Name", User_Name);
                cmd.Parameters.AddWithValue("@User_Designation", User_Designation);
                cmd.Parameters.AddWithValue("@User_EmailID", User_EmailID);
                cmd.Parameters.AddWithValue("@User_MobileNo", User_MobileNo);

                cmd.Parameters.AddWithValue("@SMS_ConfigID", SMS_ConfigID);
                cmd.Parameters.AddWithValue("@SMS_Alloted", SMS_Alloted);
                cmd.Parameters.AddWithValue("@SMS_Min_Bal_Alert", SMS_Min_Bal_Alert);
                cmd.Parameters.AddWithValue("@SMS_Available_Balance", SMS_Available_Balance);

                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Action", Action);
                
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



        //Method for Invoices Management in Control Center

        public DataSet Invoices_CRUD(int CompanyID, string strCompanyCode, string strCompanyDesc, int GroupID, string CompanyLogo, string ClientURL, int Is_DBatClientServer, string ConString, string CompanyEmailID, string CompanyMobileNo, string User_FName, string User_LName, string User_Dept, string User_Code, string User_Name, string User_Designation, string User_EmailID, string User_MobileNo, int SMS_ConfigID, int SMS_Alloted, int SMS_Min_Bal_Alert, int SMS_Available_Balance, string LoggedInUserID, string Action, string strConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(strConn);

                SqlCommand cmd = new SqlCommand("Spr_CRUD_Invoices", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Company_ID", CompanyID);
                cmd.Parameters.AddWithValue("@Company_Code", strCompanyCode);
                cmd.Parameters.AddWithValue("@Company_Desc", strCompanyDesc);
                cmd.Parameters.AddWithValue("@Group_ID", GroupID);

                cmd.Parameters.AddWithValue("@Company_Logo", CompanyLogo);
                cmd.Parameters.AddWithValue("@Client_URL", ClientURL);
                cmd.Parameters.AddWithValue("@Is_DBatClientServer", Is_DBatClientServer);
                cmd.Parameters.AddWithValue("@Con_String", ConString);
                cmd.Parameters.AddWithValue("@CompanyEmailID", CompanyEmailID);
                cmd.Parameters.AddWithValue("@CompanyMobileNo", CompanyMobileNo);

                cmd.Parameters.AddWithValue("@User_FName", User_FName);
                cmd.Parameters.AddWithValue("@User_LName", User_LName);
                cmd.Parameters.AddWithValue("@User_Dept", User_Dept);
                cmd.Parameters.AddWithValue("@User_Code", User_Code);

                cmd.Parameters.AddWithValue("@User_Name", User_Name);
                cmd.Parameters.AddWithValue("@User_Designation", User_Designation);
                cmd.Parameters.AddWithValue("@User_EmailID", User_EmailID);
                cmd.Parameters.AddWithValue("@User_MobileNo", User_MobileNo);

                cmd.Parameters.AddWithValue("@SMS_ConfigID", SMS_ConfigID);
                cmd.Parameters.AddWithValue("@SMS_Alloted", SMS_Alloted);
                cmd.Parameters.AddWithValue("@SMS_Min_Bal_Alert", SMS_Min_Bal_Alert);
                cmd.Parameters.AddWithValue("@SMS_Available_Balance", SMS_Available_Balance);

                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Action", Action);

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


        public DataSet PopulateLicenseMasters(string strConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(strConn);

                SqlCommand cmd = new SqlCommand("SPR_FETCH_LicenseMasters", con);
                cmd.CommandType = CommandType.StoredProcedure;

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

        public DataSet FetchLicenseExpiryDate(int SubscriptionID, string ActivationDate, string strConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(strConn);

                SqlCommand cmd = new SqlCommand("SPR_FetchLicenseExpiryDate", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SubscriptionID", SubscriptionID);
                cmd.Parameters.AddWithValue("@ActivationDate", ActivationDate);

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

        public DataSet License_CRUD(int LicenseID, string strClientID, int Company_ID, int Subs_Pack_Id, string strActivationDate, string strExpirationDate, string strDueDate, int UserLimit, string strSelectedModules, string LoggedInUserID, string Action, string strConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(strConn);

                SqlCommand cmd = new SqlCommand("Spr_CRUD_Tbl_License", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@License_Id", LicenseID);
                cmd.Parameters.AddWithValue("@Client_Id", strClientID);
                cmd.Parameters.AddWithValue("@Company_ID", Company_ID);
                cmd.Parameters.AddWithValue("@Subs_Pack_Id", Subs_Pack_Id);
                cmd.Parameters.AddWithValue("@Activation_Date", strActivationDate);
                cmd.Parameters.AddWithValue("@Expiry_Date", strExpirationDate);
                cmd.Parameters.AddWithValue("@Due_Date", strDueDate);
                cmd.Parameters.AddWithValue("@User_Limit_Id", UserLimit);
                cmd.Parameters.AddWithValue("@Module_Id", strSelectedModules);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Action", Action);

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


        public DataSet LoginUser(string UserName, string strPassword, string strConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(strConn);

                SqlCommand cmd = new SqlCommand("Spr_AdminLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Password", strPassword);

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

        public DataSet AdminLogin_Master(int ID, string FirstName, string LastName, string UserName, string Password, string LoggedInUserID, string Is_Deleted, string Action, string strConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(strConn);

                SqlCommand cmd = new SqlCommand("Spr_CRUD_AdminLogin_Mst", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@UserName", UserName);

                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@FirstName", FirstName);
                cmd.Parameters.AddWithValue("@LastName", LastName);



                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Is_Deleted", Is_Deleted);
                cmd.Parameters.AddWithValue("@Action", Action);


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

        public DataSet ValidateCompany(string CompanyCode, string strConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Spr_ValidateCompany", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyCode", CompanyCode);             
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

        public DataSet UpdatedsLicenseAction(int LicenseID, int LicenseAction,string LoggedInUserID, string strConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Spr_UpdateLicenseStatus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                cmd.Parameters.AddWithValue("@LicenseAction", LicenseAction);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
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

        public DataSet Subscription_Package_CRUD(int PackageID, string PackageName, int NoOfDays, int Price, string LoggedInUserID, string Action, string strConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_Subscription_Package_Mst", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Subs_Pack_Id", PackageID);
                cmd.Parameters.AddWithValue("@Subs_Pack_Desc", PackageName);
                cmd.Parameters.AddWithValue("@No_of_Days", NoOfDays);
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Action", Action);
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

        public DataSet Fetch_SMS_Config_Details(int ConfigID, string strConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_SMS_Config_Details", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SMSConfigID", ConfigID);
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


    }
}
