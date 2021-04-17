using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;
using System.Data;

namespace UpkeepV3_BusinessLayer
{
    public class My_Upkeep_BL
    {
        DataSet ds = new DataSet();


        public DataSet INV_ItemMaster_CRUD(int Item_ID, string Item_Desc, int Category_ID, int SubCategory_ID, int Company_ID, string LoggedInUserID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);

                SqlCommand cmd = new SqlCommand("Spr_Tbl_LMS_Items_Mst", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Item_ID", Item_ID);
                cmd.Parameters.AddWithValue("@Item_Desc", Item_Desc);
                cmd.Parameters.AddWithValue("@Category_ID", Category_ID);
                cmd.Parameters.AddWithValue("@SubCategory_ID", SubCategory_ID);
                cmd.Parameters.AddWithValue("@Company_ID", Company_ID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Action", Action);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet INV_ItemStock_CRUD(int Stock_ID, int Item_ID, string Opening_Stock, string Optimum_Value, string ReOrder_Value, string Base_Value, int Department_ID, int Current_Stock, int Company_ID, string LoggedInUserID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);

                SqlCommand cmd = new SqlCommand("Spr_CRUD_LMS_Items_Stock", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Stock_ID", Stock_ID);
                cmd.Parameters.AddWithValue("@Item_ID", Item_ID);
                cmd.Parameters.AddWithValue("@Opening_Stock", Opening_Stock);
                cmd.Parameters.AddWithValue("@Optimum_Value", Optimum_Value);
                cmd.Parameters.AddWithValue("@ReOrder_Value", ReOrder_Value);
                cmd.Parameters.AddWithValue("@Base_Value", Base_Value);
                cmd.Parameters.AddWithValue("@Department_ID", Department_ID);
                cmd.Parameters.AddWithValue("@Current_Stock", Current_Stock);
                cmd.Parameters.AddWithValue("@Company_ID", Company_ID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Action", Action);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet INV_Fetch_Items_List(int CompanyID, String StrConn)
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_INV_Fetch_AddStock_Items", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Company_ID", CompanyID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public DataSet LMS_Fetch_Department_Transactions(string Start_Date, string End_Date, int CompanyID, int Dept_ID, String StrConn)
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_LMS_Dept_Transactions", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Start_Date", Start_Date);
                cmd.Parameters.AddWithValue("@End_Date", End_Date);
                cmd.Parameters.AddWithValue("@Company_ID", CompanyID);
                cmd.Parameters.AddWithValue("@Department_ID", Dept_ID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public DataSet LMS_Fetch_Vendor_Transactions(string Start_Date, string End_Date, int CompanyID, int Vendor_ID, String StrConn)
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_LMS_Vendor_Transactions", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Start_Date", Start_Date);
                cmd.Parameters.AddWithValue("@End_Date", End_Date);
                cmd.Parameters.AddWithValue("@Company_ID", CompanyID);
                cmd.Parameters.AddWithValue("@Vendor_ID", Vendor_ID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public DataSet Fetch_LMS_ItemList(int DepartmentID, int CompanyID, String StrConn)
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_LMS_Items_List", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public DataSet Fetch_Invoices(int Company_ID, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);

                SqlCommand cmd = new SqlCommand("Spr_Fetch_Invoice_Details", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Company_ID", Company_ID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet MenuMaster_CRUD(int Menu_ID, string Menu_Desc, string Parent_Menu_Id, string Toot_Tip, string Menu_Url, string Module_Menu_Id, string Is_Deleted, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);

                SqlCommand cmd = new SqlCommand("Spr_CRUD_Menu_Mst", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Menu_Id", Menu_ID);
                cmd.Parameters.AddWithValue("@Menu_Desc", Menu_Desc);
                cmd.Parameters.AddWithValue("@Parent_Menu_Id", Parent_Menu_Id);
                cmd.Parameters.AddWithValue("@Toot_Tip", Toot_Tip);
                cmd.Parameters.AddWithValue("@Menu_Url", Menu_Url);
                cmd.Parameters.AddWithValue("@Module_Menu_Id", Module_Menu_Id);
                cmd.Parameters.AddWithValue("@Is_Deleted", Is_Deleted);
                cmd.Parameters.AddWithValue("@Action", Action);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet CustomReports_RU(int Report_ID, string Report_Name, string Report_Desc, int Company_ID, string LoggedInUserID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);

                SqlCommand cmd = new SqlCommand("Spr_Fetch_Custom_Reports", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Report_ID", Report_ID);
                cmd.Parameters.AddWithValue("@Report_Name", Report_Name);
                cmd.Parameters.AddWithValue("@Report_Desc", Report_Desc);
                
                cmd.Parameters.AddWithValue("@Company_ID", Company_ID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                
                cmd.Parameters.AddWithValue("@Action", Action);
              

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet UserTypeMaster_CRUD(int User_Type_ID, string User_Type_Desc, int CompanyID, string LoggedInUserID, string Action, string StrConn)
        {
            try
            {

                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_UserTypeMaster_CRUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@User_Type_ID", User_Type_ID);
                cmd.Parameters.AddWithValue("@User_Type_Desc", User_Type_Desc);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Action", Action);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet DepartmentMaster_CRUD(int Department_ID, string Dept_Desc, int CompanyID, string LoggedInUserID, string Is_Deleted, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_DepartmentMaster_CRUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Department_ID", Department_ID);
                cmd.Parameters.AddWithValue("Dept_Desc", Dept_Desc);
                cmd.Parameters.AddWithValue("CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("Is_Deleted", Is_Deleted);
                cmd.Parameters.AddWithValue("Action", Action);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet PriorityMaster_CRUD(int Priority_ID, string Priority_Desc, int CompanyID, string LoggedInUserID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_PriorityMaster_CRUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Priority_ID", Priority_ID);
                cmd.Parameters.AddWithValue("@Priority_Desc", Priority_Desc);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("Action", Action);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet FrequencyMaster_CRUD(int Frquency_Id, string Frquency_Desc, int CompanyID, string LoggedInUserID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_FrequencyMaster_CRUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Frequency_Id", Frquency_Id);
                cmd.Parameters.AddWithValue("@Frequency_Desc", Frquency_Desc);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Action", Action);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ZoneMaster_CRUD(int ZoneID, int CompanyID, string ZoneCode, string ZoneDesc, string LoggedInUserID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_Zone_Mast", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ZonID", ZoneID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@ZoneCode", ZoneCode);
                cmd.Parameters.AddWithValue("@ZoneDesc", ZoneDesc);
                cmd.Parameters.AddWithValue("LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("Action", Action);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet LocationMaster_CRUD(int LocID, string Zone, string LocCode, string LocDesc, string LoggedInUserID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_Location_Mast", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LocID", LocID);
                cmd.Parameters.AddWithValue("@Zone", Zone);
                cmd.Parameters.AddWithValue("@LocCode", LocCode);
                cmd.Parameters.AddWithValue("@LocDesc", LocDesc);
                cmd.Parameters.AddWithValue("LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("Action", Action);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet UserGroupMaster_CRUD(int Grp_Id, string Grp_Desc, string User_ID, int CompanyID, string LoggedInUserID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_UserGroupMaster_CRUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Grp_Id", Grp_Id);
                cmd.Parameters.AddWithValue("@Grp_Desc", Grp_Desc);
                cmd.Parameters.AddWithValue("@User_ID", User_ID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Action", Action);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet FetchZone(String StrConn)
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_Zone", con);
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

        public DataSet FetchLocation(int Zone_ID, String StrConn)
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("spr_Fetch_Location", con);
                cmd.Parameters.AddWithValue("Zone_ID", Zone_ID);
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

        public DataSet FetchSubLocation(int Loc_ID, String StrConn)
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("spr_Fetch_SubLocation", con);
                cmd.Parameters.AddWithValue("Loc_ID", Loc_ID);
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


        public DataSet FetchDepartment(int CompanyID, String StrConn)
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_Department", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }


        public DataSet FetchUserType(int CompanyID, String StrConn) //Added CompanyId by sujata
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_User_Type", con);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
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


        public DataSet UserMaster_CRUD(int User_ID, string User_Code, string F_name, string L_Name, string User_Mobile, string User_Email, string User_MobileAlter, string User_Landline, string User_Designation, int User_Type_ID, int Zone_ID, int Loc_ID, int SubLoc_Id, int Department_Id, string Login_Id, string Password, int Is_Approver, int Is_GobalApprover, int Approver_ID, int RoleID, string ProfilePhoto_FilePath,string Sign_FilePath, int CompanyID,int Is_Email_Verified, string LoggedInUserID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_User_Mst", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@User_ID", User_ID);
                cmd.Parameters.AddWithValue("@User_Code", User_Code);
                cmd.Parameters.AddWithValue("@F_Name", F_name);
                cmd.Parameters.AddWithValue("@L_Name", L_Name);
                cmd.Parameters.AddWithValue("@User_Email", User_Email);
                cmd.Parameters.AddWithValue("@User_Mobile", User_Mobile);
                cmd.Parameters.AddWithValue("@User_MobileAlter", User_MobileAlter);
                cmd.Parameters.AddWithValue("@User_Landline", User_Landline);
                cmd.Parameters.AddWithValue("@User_Designation", User_Designation);
                cmd.Parameters.AddWithValue("@User_Type_ID", User_Type_ID);
                cmd.Parameters.AddWithValue("@Zone_Id", Zone_ID);
                cmd.Parameters.AddWithValue("@Loc_ID", Loc_ID);
                cmd.Parameters.AddWithValue("@SubLoc_ID", SubLoc_Id);
                cmd.Parameters.AddWithValue("@Department_ID", Department_Id);
                cmd.Parameters.AddWithValue("@Login_Id", Login_Id);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@Is_Approver", Is_Approver);
                cmd.Parameters.AddWithValue("@Is_GlobalApprover", Is_GobalApprover);
                cmd.Parameters.AddWithValue("@Approver_ID", Approver_ID);
                cmd.Parameters.AddWithValue("@RoleID", RoleID);
                cmd.Parameters.AddWithValue("@Profile_photo", ProfilePhoto_FilePath);
                cmd.Parameters.AddWithValue("@Sign_photo", Sign_FilePath);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@Is_Email_Verified", Is_Email_Verified);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                //cmd.Parameters.AddWithValue("Is_Deleted", Is_Deleted);
                cmd.Parameters.AddWithValue("Action", Action);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Email_Verification_Mail(string EmailID, string OTP, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {

                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("eFacilito_spr_Email_Verification_Mail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailID", EmailID);
                cmd.Parameters.AddWithValue("@OTP", OTP);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet LoginUser(string UserName, string strPassword, string UserType, int CompanyID, string strConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(strConn);

                SqlCommand cmd = new SqlCommand("Spr_Login", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Password", strPassword);
                cmd.Parameters.AddWithValue("@UserType", UserType);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
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

        public DataSet SubLocationMaster_CRUD(int SubLocID, string LocName, string Zone, string SubLocCode, string SubLocDesc, string LoggedInUserID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_SubLocation_Mast", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SubLocID", SubLocID);
                cmd.Parameters.AddWithValue("@LocName", LocName);
                cmd.Parameters.AddWithValue("@Zone", Zone);
                cmd.Parameters.AddWithValue("@SubLocCode", SubLocCode);
                cmd.Parameters.AddWithValue("@SubLocDesc", SubLocDesc);
                cmd.Parameters.AddWithValue("LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("Action", Action);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public DataSet FetchUserGrp(int GroupID, int CompanyID, string StrConn)
        {
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_FetchUserGrp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@GroupID", GroupID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Fetch_CategorySubCategory(int CategoryID, int CompanyID, string StrConn)
        {
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_CategorySubCategory_List", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet WorkflowMaster_CRUD(int WorkflowID, string WorkflowDesc, int ZoneID, int CategoryID, int SubCategoryID, string xmlWorkflow, int CompanyID, string LoggedInUserID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_Workflow_Mast", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WorkflowID", WorkflowID);
                cmd.Parameters.AddWithValue("@WorkflowDesc", WorkflowDesc);
                cmd.Parameters.AddWithValue("@ZoneID", ZoneID);
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                cmd.Parameters.AddWithValue("@SubCategoryID", SubCategoryID);
                cmd.Parameters.AddWithValue("@WorkFlowDtlXml", xmlWorkflow);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Action", Action);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Fetch_User_UserGroupList(int CompanyID, string StrConn)
        {
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_FetchUser_UserGroup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet CategoryMaster_CRUD(int CompanyID, int Category_ID, string Category_Desc, int DepartmentID, string LoggedInUserID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_Category", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("CompanyID", CompanyID); //Added by sujata
                cmd.Parameters.AddWithValue("Category_ID", Category_ID);
                cmd.Parameters.AddWithValue("Category_Desc", Category_Desc);
                cmd.Parameters.AddWithValue("DepartmentID", DepartmentID);
                cmd.Parameters.AddWithValue("LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("Action", Action);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet RetailerPunch_CR(string LoggedInUserID, string Punch_Type, int CompanyID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Retailer_Att_Punches_CR", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("Punch_Type", Punch_Type);
                cmd.Parameters.AddWithValue("Company_ID", CompanyID);
                cmd.Parameters.AddWithValue("Action", Action);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet SubCategoryMaster_CRUD(int CompanyID, int SubcategoryID, string SubCategoryDesc, int CategoryID, int Approval_Required, string LoggedInUserID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_SubCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("CompanyID", CompanyID); //Added by sujata 
                cmd.Parameters.AddWithValue("SubCategory_ID", SubcategoryID);
                cmd.Parameters.AddWithValue("SubCategory_Desc", SubCategoryDesc);
                cmd.Parameters.AddWithValue("Category_ID", CategoryID);
                cmd.Parameters.AddWithValue("Approval_Required", Approval_Required);
                cmd.Parameters.AddWithValue("LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("Action", Action);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet BindLocationDetails(int ZoneID, int LocationID, string StrConn)
        {
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_Tkt_LocationDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ZoneID", ZoneID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Fetch_LocationTree(int CompanyID, string StrConn)
        {
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_LocationTree", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Fetch_Ticket_Workflow(int CompanyID, int CategoryID, int SubCategoryID, string TicketPrefix, string LoggedInUserID, string StrConn)
        {
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_TKT_Fetch_Workflow", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                cmd.Parameters.AddWithValue("@SubCategoryID", SubCategoryID);
                cmd.Parameters.AddWithValue("@TktPrefix", TicketPrefix);
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

        public DataSet Insert_Ticket_Details(string TicketCode, int CompanyID, int LocationID, int CategoryID, int SubCategoryID, string TicketMessage, string list_Images,string CustomFields_XML, string LoggedInUserID, string strAction, string StrConn)
        {
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_Ticket_Mast", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TktCode", TicketCode);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                //cmd.Parameters.AddWithValue("@SubLocationID", SubLocationID);
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                cmd.Parameters.AddWithValue("@SubCategoryID", SubCategoryID);
                cmd.Parameters.AddWithValue("@TicketMessage", TicketMessage);
                cmd.Parameters.AddWithValue("@TicketImages", list_Images);
                cmd.Parameters.AddWithValue("@CustomFields_XML", CustomFields_XML);
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

        public DataSet Fetch_Ticket_MyActionable(int TicketID, int CompanyID, string LoggedInUserID, string From_Date, string To_Date, string StrConn)
        {
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Ticket_Fetch_MyActionable", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TicketID", TicketID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
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

        public DataSet Fetch_Ticket_MyActionable_Details(int TicketID, int CompanyID, string LoggedInUserID, string StrConn)
        {
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Ticket_Fetch_MyActionable_Details", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TicketID", TicketID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
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


        public DataSet Accept_Ticket(int TicketID, string LoggedInUserID, string StrConn)
        {
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Accept_Ticket", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TicketID", TicketID);
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

        public DataSet Fetch_CTT_Report(string TicketStatus,string ActionStatus, string From_Date, string To_Date, int CompanyID, string StrConn)
        {
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_Ticket_CTT_Report", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TicketStatus", TicketStatus);
                cmd.Parameters.AddWithValue("@ActionStatus", ActionStatus);
                cmd.Parameters.AddWithValue("@From_Date", From_Date);
                cmd.Parameters.AddWithValue("@To_Date", To_Date);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Bind_Ticket_Details(int TicketID, int CompanyID, string StrConn)
        {
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_Ticket_Details", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TicketID", TicketID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet AddChecklistMaster_CRUD(int ChecklistID, string ChecklistName, int DeptID, Boolean Chkapproval, Boolean ChkExpry, Boolean ChkSchedule, int ExpirytimeID, DateTime dtSchedule_Date, string StartTime, string EndTime, int CustFrequency, int Frquency_Id, int ZoneID, int LocationID, int SubLocationID, string strXmlChecklistPoint, string LoggedInUserID, string Action, string StrConn)
        {
            DataSet dsAddChecklist = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_Checklist_Mst", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ChkList_ID", ChecklistID);
                cmd.Parameters.AddWithValue("@Chk_Name", ChecklistName);
                cmd.Parameters.AddWithValue("@Department_ID", DeptID);
                cmd.Parameters.AddWithValue("@Approval_Required", Chkapproval);
                cmd.Parameters.AddWithValue("@Is_Expire", ChkExpry);
                cmd.Parameters.AddWithValue("@Expire_Time", ExpirytimeID);
                cmd.Parameters.AddWithValue("@Is_Scheduled", ChkSchedule);
                cmd.Parameters.AddWithValue("@Schedule_Date", dtSchedule_Date);
                cmd.Parameters.AddWithValue("@Schedule_Start_Time", StartTime);
                cmd.Parameters.AddWithValue("@Schedule_End_Time", EndTime);
                cmd.Parameters.AddWithValue("@Frequency_Custom", CustFrequency);
                cmd.Parameters.AddWithValue("@Frquency_Id", Frquency_Id);
                cmd.Parameters.AddWithValue("@Zone_ID", ZoneID);
                cmd.Parameters.AddWithValue("@Loc_ID", LocationID);
                cmd.Parameters.AddWithValue("@SubLoc_ID", SubLocationID);
                cmd.Parameters.AddWithValue("@ChecklistPointlXml", strXmlChecklistPoint);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Action", Action);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsAddChecklist);
                return dsAddChecklist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet FetchMenu(int parentMenuId, string StrConn)
        {
            DataSet dtMenu = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_MenuDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@parentMenuId", parentMenuId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtMenu);
                return dtMenu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ChecklistPoint_CRUD(int ChecklistID, int ChecklistPointID, string strChecklistPointDesc, string strChecklstAnstype, string LoggedInUserID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_CRUD_CHECKLIST_POINT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ChecklistID", ChecklistID);
                cmd.Parameters.AddWithValue("CheckPointID", ChecklistPointID);
                cmd.Parameters.AddWithValue("ChecklstPoint_Desc", strChecklistPointDesc);
                cmd.Parameters.AddWithValue("ChecklstAnsType", strChecklstAnstype);
                cmd.Parameters.AddWithValue("LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("Action", Action);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ChecklistRequest(string ScheduleDate, int ZoneID, int LocationID, int SubLocationID, int DepartmentID, int ChecklistID, string StartTime, string TicketNumber, string LoggedInUserID, string strAction, string StrConn)
        {
            DataSet dsDept_Checklist = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_ChecklistRequest", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ScheduleDate", ScheduleDate);
                cmd.Parameters.AddWithValue("@ZoneID", ZoneID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@SubLocationID", SubLocationID);
                cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                cmd.Parameters.AddWithValue("@ChecklistID", ChecklistID);
                cmd.Parameters.AddWithValue("@StartTime", StartTime);
                cmd.Parameters.AddWithValue("@TicketID", TicketNumber);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Action", strAction);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsDept_Checklist);
                return dsDept_Checklist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Update_ChecklistPoints(string TicketNumber, string strXmlChecklist, string list_Images, string LoggedInUserID, string StrConn)
        {
            DataSet dsChecklist = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Update_ChecklistPoints", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TicketID", TicketNumber);
                cmd.Parameters.AddWithValue("@ChecklistPointlXml", strXmlChecklist);
                cmd.Parameters.AddWithValue("@TicketImages", list_Images);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsChecklist);
                return dsChecklist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Close_Ticket_Details(string TicketID, string CloseTicketDesc, string LoggedInUserID, string list_Images, string strTicketAction, string CurrentLevel, string StrConn)
        {
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CloseTkt", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TicketID", TicketID);
                cmd.Parameters.AddWithValue("@CloseTicketDesc", CloseTicketDesc);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@ImagePath", list_Images);
                cmd.Parameters.AddWithValue("@TicketAction", strTicketAction);
                cmd.Parameters.AddWithValue("@CurrentLevel", CurrentLevel);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Location Tree View
        public DataSet Location_PopulateRootLevel(int CompanyID, string StrConn)
        {
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_Location_RootLevel", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Location_PopulateSubLevel(int ParentID, string StrConn)
        {
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_Location_SubLevel", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@parentID", ParentID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Add_Update_Location_Node(int ParentID, string Location_Node, int CompanyID, string LoggedInUserID, string strAction, string StrConn)
        {
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Location_AddUpdateNode", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ParentID", ParentID);
                cmd.Parameters.AddWithValue("@Node", Location_Node);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
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


        #endregion

        #region Role Management
        public DataSet FetchMenu(int parentMenuId, string LoggedInUserID, string ModuleIDs, int CompanyID, string StrConn)
        {
            DataSet dtMenu = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_MenuDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@parentMenuId", parentMenuId);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@ModuleIDs", ModuleIDs);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);

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

        #region GatePass

        public DataSet Insert_GatePassConfiguration(string strConfigTitle, int CompanyID, string strInitiator, bool LinkDepartment, string strTransactionPrefix, string strXmlGatepass_Header, string strXmlGatepass_Type, string strXmlGatepass_Doc, string strXmlGatepass_TermCondition, string strXmlApprovalMatrix, bool ShowApprovalMatrix, string strGPClosureBy, string GatepassDescription, string LoggedInUserID, string StrConn)
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
                cmd.Parameters.AddWithValue("@XmlGatepass_Doc", strXmlGatepass_Doc);
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

        public DataSet Fetch_GatePassConfiguration(string Initiator,int CompanyID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_GP_CONFIG", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Initiator", Initiator);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
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

        public DataSet GatePassHeader_CRUD(int GatePassHeaderID, string GatePassHeader, bool GPHeaderNumeric, int GPHeaderUnit, int GatePass_ConfigID, string LoggedInUserID, string strAction, string StrConn)
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

        public DataSet Update_GatePassConfiguration(int GP_Config_ID, string strConfigTitle, int CompanyID, string strInitiator, bool LinkDepartment, string strTransactionPrefix, string strXmlApprovalMatrix, bool ShowApprovalMatrix, string strGPClosureBy, string GatepassDescription, string LoggedInUserID, string StrConn)
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

        public DataSet Insert_GatePassRequest(int GP_ConfigID, string strGatePassDate, int DeptID, int GPTypeID, string strGPHeader, string strGPHeaderData, string strGPDoc, string LoggedInUserID, string StrConn)
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
                cmd.Parameters.AddWithValue("@GPDoc", strGPDoc);
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

        public DataSet Fetch_MyRequestGatePass(int CompanyID,string LoggedInUserID, string From_Date, string To_Date, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_MYREQUEST_GP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
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

        public DataSet Fetch_MyActionableGatePass(int CompanyID,string LoggedInUserID, string From_Date, string To_Date, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_MyActionable_GP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
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

        public DataSet GatePassConfiguration_Document_CRUD(int GP_ConfigID, int GatePassDocID, string DocumentHeader, int Mandatory, string LoggedInUserID, string strAction, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_GP_Config_Document_CRUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@GP_ConfigID", GP_ConfigID);
                cmd.Parameters.AddWithValue("@GPConfig_DocID", GatePassDocID);
                cmd.Parameters.AddWithValue("@DocumentHeader", DocumentHeader);
                cmd.Parameters.AddWithValue("@Mandatory", Mandatory);
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


        #endregion

        #region Work_Permit


        //Added by RC WorkPermitConfiguration Save

        public DataSet Insert_WorkPermitConfiguration(string strConfigTitle, int CompanyID, string strInitiator, bool LinkDepartment, string strTransactionPrefix, string strXmlWorkPermit_Header, string strXmlWorkPermit_TermCondition, string strXmlApprovalMatrix, bool chkShowApprovalMatrix_Initiator, bool chkShowApprovalMatrix_Approver, string LoggedInUserID, string StrConn)
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
                cmd.Parameters.AddWithValue("@chkShowApprovalMatrix_Initiator", chkShowApprovalMatrix_Initiator);
                cmd.Parameters.AddWithValue("@chkShowApprovalMatrix_Approver", chkShowApprovalMatrix_Approver);
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

        public DataSet Fetch_WorkPermitConfiguration(string Initiator,string CompanyID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_WP_CONFIG", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Initiator", Initiator);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                
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

        public DataSet Fetch_DashboardCount(int CompanyID, string LoggedInUserID, string From_Date, string To_Date, string StrConn)
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
        public DataSet Update_WorkPermitConfiguration(int WP_Config_ID, string strConfigTitle, int CompanyID, string strInitiator, bool LinkDepartment, string strTransactionPrefix, string strXmlWorkPermit_Header, string strXmlWorkPermit_TermCondition, string strXmlApprovalMatrix, bool chkShowApprovalMatrix_Initiator, bool chkShowApprovalMatrix_Approver, string LoggedInUserID, string StrConn)
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
                cmd.Parameters.AddWithValue("@chkShowApprovalMatrix_Initiator", chkShowApprovalMatrix_Initiator);
                cmd.Parameters.AddWithValue("@chkShowApprovalMatrix_Approver", chkShowApprovalMatrix_Approver);
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


        public DataSet Fetch_GatePass_MIS(int CompanyID,string LoggedInUserID, string From_Date, string To_Date, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_MYREQUEST_GP_MIS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                //cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
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

        //Added by sujata This function is used to delete WP ConfigID
        public DataSet Delete_WPConfiguration(int ConfigID, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_DELETE_WP_CONFIG", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ConfigID", ConfigID);
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


        public DataSet Fetch_MyChecklist(string LoggedInUserID, string CompanyID, string From_Date, string To_Date, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_CHK_MYCHECKLIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
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
        //Added by sujata This function is used to delete CHK ConfigID
        public DataSet Delete_CHKConfiguration(int ConfigID, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_DELETE_CHK_CONFIG", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ConfigID", ConfigID);
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

        public DataSet Fetch_MyChecklistReportList(string LoggedInUserID, string CompanyID, string From_Date, string To_Date, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_CHK_REPORT_LIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
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

        public DataSet Fetch_Checklist_Report(string Response_ID, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_CHK_REPORT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Chk_Response_ID", Response_ID);
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

        public DataSet Fetch_Checklist_Consolidated_Report(int Chk_Config_ID, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_Checklist_Point_Report", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Chk_Config_ID", Chk_Config_ID);
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

        public DataSet Save_Checklist_Schedule(int Checklist_ConfigID, int DepartmentID, string SelectedLocationID, string LoggedInUserID, int CompanyID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Save_Checklist_Schedule", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Checklist_ConfigID", Checklist_ConfigID);
                cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                cmd.Parameters.AddWithValue("@SelectedLocationID", SelectedLocationID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Save_Checklist_Schedule_NEW(int Chk_Map_ID,int Checklist_ConfigID, int DepartmentID, string SelectedLocationID, string LoggedInUserID, int CompanyID, string Action, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Save_Checklist_Schedule_CURD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Chk_Map_ID", Chk_Map_ID);
                cmd.Parameters.AddWithValue("@Checklist_ConfigID", Checklist_ConfigID);
                cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                cmd.Parameters.AddWithValue("@SelectedLocationID", SelectedLocationID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@Action", Action);
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

        #region VMS

        //Added by RC This function is used to save VMS Configuration
        public DataSet Insert_Update_VMSConfiguration(int ConfigID, string strConfigTitle, string strConfigDesc, int CompanyID, string strInitiator, string strXmlVMS_Question, bool blFeedbackCompulsary, int FeedbackTitle, bool blEnableCovid, int EntryCount, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_INSERT_UPDATE_VMS_CONFIG", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ConfigID", ConfigID);
                cmd.Parameters.AddWithValue("@ConfigTitle", strConfigTitle);
                cmd.Parameters.AddWithValue("@ConfigDesc", strConfigDesc);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@Initiator", strInitiator);
                cmd.Parameters.AddWithValue("@XmlVMS_Question", strXmlVMS_Question);
                cmd.Parameters.AddWithValue("@isFeedbackCompulsary", blFeedbackCompulsary);
                cmd.Parameters.AddWithValue("@FeedbackID", FeedbackTitle);
                cmd.Parameters.AddWithValue("@EnableCovid", blEnableCovid);
                cmd.Parameters.AddWithValue("@EntryCount", EntryCount);
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

        //Added by RC This function is used to Fetch VMS Configuration
        public DataSet Fetch_VMSConfiguration(int CompanyID, string Initiator, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_VMS_CONFIG", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
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

        //Added by RC This function is used to Bind VMS Configuration 
        public DataSet Bind_VMSConfiguration(int VMS_ConfigID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_VMS_CONFIG_DETAILS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VMS_ConfigID", VMS_ConfigID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Added by RC This function is used to Fetch VMS Request list
        public DataSet Fetch_VMSRequestList(int CompanyID, string LoggedInUserID, string From_Date, string To_Date, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_VMS_REQUEST_LIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
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

        //Added by RC This function is used to bind VMS request details
        public DataSet Bind_VMSRequestDetails(int RequestID, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_VMS_REQUEST_DATA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RequestID", RequestID);
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

        //Added by RC This function is used to save VMS Request
        public DataSet Insert_VMSRequest(int CompanyID, char Action, int RequestID, int VMS_ConfigID, string Name, string Email, string Phone, string strVMSDate, string strMeetUsrs, string strVMSData, string strVMSCovidColorCode, string strVMSCovidTestDate, string strTemperature, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_INSERT_VMS_REQUEST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@RequestID", RequestID);
                cmd.Parameters.AddWithValue("@VMS_ConfigID", VMS_ConfigID);
                cmd.Parameters.AddWithValue("@VName", Name);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Phone", Phone);
                cmd.Parameters.AddWithValue("@MeetDate", strVMSDate);
                cmd.Parameters.AddWithValue("@MeetUsers", strMeetUsrs);
                cmd.Parameters.AddWithValue("@VisitData", strVMSData);
                cmd.Parameters.AddWithValue("@CovidColorCode", strVMSCovidColorCode);
                cmd.Parameters.AddWithValue("@CovidtestDate", strVMSCovidTestDate);
                cmd.Parameters.AddWithValue("@Temperature", strTemperature);
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

        //Added by RC This function is used to Fetch Visit Form Url for Session less User 
        public DataSet Fetch_VMSFormURL(string ShortUrl, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_VMS_FORMLINK", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ShortUrl", ShortUrl);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Added by sujata This function is used to delete VMS ConfigID
        public DataSet Delete_VMSConfiguration(int ConfigID, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_DELETE_VMS_CONFIG", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ConfigID", ConfigID);
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
        #endregion

        #region CSM
        //Added by RC This function is used to save CSM Configuration
        public DataSet Insert_Update_CSMConfiguration(int ConfigID, string strConfigTitle, int CompanyID, string strXmlIn_Question, string strXmlOut_Question, string strXmlCSM_Terms, bool blFreeService, string CostUnit, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_INSERT_UPDATE_CSM_CONFIG", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ConfigID", ConfigID);
                cmd.Parameters.AddWithValue("@ConfigDesc", strConfigTitle);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@XmlIn_Question", strXmlIn_Question);
                cmd.Parameters.AddWithValue("@XmlOut_Question", strXmlOut_Question);
                cmd.Parameters.AddWithValue("@XmlCSM_TermCondition", strXmlCSM_Terms);
                cmd.Parameters.AddWithValue("@isFreeService", blFreeService);
                cmd.Parameters.AddWithValue("@UnitCost", CostUnit);
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

        //Added by RC This function is used to Fetch CSM Configuration
        public DataSet Fetch_CSMConfiguration(int CompanyID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_CSM_CONFIG", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Added by RC This function is used to Bind CSM Configuration 
        public DataSet Bind_CSMConfiguration(int ConfigID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_CSM_CONFIG_DETAILS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ConfigID", ConfigID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Added by RC This function is used to delete CSM ConfigID
        public DataSet Delete_CSMConfiguration(int ConfigID, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_DELETE_CSM_CONFIG", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ConfigID", ConfigID);
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

        #endregion

        #region General Functions

        //Added by RC This function is used to Fetch Answer type master
        public DataSet Fetch_AnswerForAll(char Key, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_Fetch_AnsMst", con);
                cmd.Parameters.AddWithValue("@Key", Key);
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

        public DataSet Fetch_User_UserGroupListGPWP(string Initiator, string StrConn)
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

        public DataSet Error_Log(string Extype, string Page, string Errormsg, string StackTrace, string CompanyID, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_ERROR_LOG_MAIL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ErrorMsg", Errormsg);
                cmd.Parameters.AddWithValue("@PageName", Page);
                cmd.Parameters.AddWithValue("@ExType", Extype);
                cmd.Parameters.AddWithValue("@StackTrace", StackTrace);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
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

        #endregion

        #region Asset Management 

        public DataSet Fetch_Asset_DropDown(int UserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_ASSET_FETCH_DROPDOWN_LIST", con);
                cmd.Parameters.AddWithValue("@UserID", UserID);
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

        public DataSet Fetch_Asset_Vendor_DropDown(string VendorPrefix, int UserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_ASSET_FETCH_VENDOR_LIST", con);
                cmd.Parameters.AddWithValue("@VendorPrefix", VendorPrefix);
                cmd.Parameters.AddWithValue("@UserID", UserID);
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

        public DataSet ASSET_Insert_AssetType(string LoggedInUserID, int companyID, string AssetType, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_ASSET_INSERT_ASSET_TYPE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@companyID", companyID);
                cmd.Parameters.AddWithValue("@UserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Asset_Type", AssetType);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ASSET_Insert_AssetCategory(string LoggedInUserID, int companyID, int AssetTypeID, string AssetCategory, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_ASSET_INSERT_ASSET_CATEGORY", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@companyID", companyID);
                cmd.Parameters.AddWithValue("@UserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@AssetTypeID", AssetTypeID);
                cmd.Parameters.AddWithValue("@Category", AssetCategory);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet ASSET_INSERT_GRNL_MASTER(string LoggedInUserID, string MasterType, string Dept_Value, string LocationXmlValue, string VendorXmlValue, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_ASSET_INSERT_GRNL_MASTER", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@MasterType", MasterType);
                cmd.Parameters.AddWithValue("@Dept_Value", Dept_Value);
                cmd.Parameters.AddWithValue("@LocationXmlValue", LocationXmlValue);
                cmd.Parameters.AddWithValue("@VendorXmlValue", VendorXmlValue);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Fetch_MyAsset(string LoggedInUserID, string From_Date, string To_Date, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_ASSET_FETCH_MY_ASSET", con);
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

        public DataSet Fetch_ASSET_REQUEST_Details(string LoggedInUserID, int TransactionID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_ASSET_FETCH_ASSET_REQUEST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AssetID", TransactionID);
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

        public DataSet INSERT_ASSET_REQUEST_Details(string LoggedInUserID, string AssetXml, string AssetAmcXml, string AssetServiceXml, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_ASSET_INSERT_REQUEST_DATA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@AssetXml", AssetXml);
                cmd.Parameters.AddWithValue("@AssetAmcXml", AssetAmcXml);
                cmd.Parameters.AddWithValue("@AssetServiceXml", AssetServiceXml);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet UPDATE_ASSET_REQUEST_Details(string LoggedInUserID, string TransactionID, string AssetXml, string AssetAmcXml, string AssetServiceXml, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_ASSET_UPDATE_REQUEST_DATA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@AssetID", TransactionID);
                cmd.Parameters.AddWithValue("@AssetXml", AssetXml);
                cmd.Parameters.AddWithValue("@AssetAmcXml", AssetAmcXml);
                cmd.Parameters.AddWithValue("@AssetServiceXml", AssetServiceXml);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataSet INSERT_UPDATE_ASSET_AMC_REQUEST_Details(string LoggedInUserID, string TransactionID, string AssetAmcXml, string Flag, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_ASSET_CRUD_AMC_REQUEST_DATA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@AssetID", TransactionID);
                cmd.Parameters.AddWithValue("@AssetAmcXml", AssetAmcXml);
                cmd.Parameters.AddWithValue("@InsertUpdateFlag", Flag);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Fetch_MyAsset_Service(string LoggedInUserID, string From_Date, string To_Date, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_ASSET_FETCH_MY_SERVICE_ASSET", con);
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
        public DataSet CRUD_ASSET_SERVICE_REQUEST_DATA(string LoggedInUserID, string AssetID, string ServiceScheduleID, string AssetServiceXml, string Flag, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_ASSET_CRUD_SERVICE_REQUEST_DATA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@AssetID", AssetID);
                cmd.Parameters.AddWithValue("@AssetScheduleID", ServiceScheduleID);
                cmd.Parameters.AddWithValue("@AssetServiceXml", AssetServiceXml);
                cmd.Parameters.AddWithValue("@Flag", Flag);
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


        #region Inventory

        public DataSet Fetch_Transaction_List(string LoggedInUserID, string CompanyID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_INV_TRANSACTION", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Delete_Inv_Transaction(int TransactionID, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_DELETE_INV_TRANSACTION", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TRANSACTIONID", TransactionID);
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

        public DataSet Fetch_Stock_List(string LoggedInUserID, string CompanyID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_INV_STOCK", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Delete_Inv_Stock(int ItemId, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_DELETE_INV_ITEM_STOCK", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ITEMSTOCKID", ItemId);
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
        public DataSet Delete_Inv_Item(int ItemId, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_DELETE_INV_ITEM", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ITEMID", ItemId);
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

        public DataSet Fetch_Stock_Detail(string LoggedInUserID, string CompanyID, int StockId, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_INV_STOCK_DETAIL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@Stock_ID", StockId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Fetch_Inv_Items_List(string LoggedInUserID, string CompanyID, string XmlItem, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_INV_ITEM", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@XmlItem", XmlItem);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Fetch_Inv_Item_Stock_Ddl(string LoggedInUserID, string CompanyID, string StockID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_INV_ITEM_STOCK_DDL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@StockID", StockID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Fetch_Inv_Crud_Item_Stock(string LoggedInUserID, string CompanyID, string StockID, string XmlItem, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_CRUD_INV_ITEM_STOCK", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@StockID", StockID);
                cmd.Parameters.AddWithValue("@XmlItem", XmlItem);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Fetch_Inv_Item_Stock_Data(string LoggedInUserID, string CompanyID, string StockID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_INV_ITEM_STOCK_DETAIL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@StockID", StockID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Fetch_Inv_Item_Purchase_List(string LoggedInUserID, string CompanyID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_INV_PURCHASE_LIST", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Delete_Inv_Purchase(int ItemId, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_DELETE_INV_PURCHASE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PurchaseID", ItemId);
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

        public DataSet Crud_Inv_Purchase(string LoggedInUserID, string CompanyID, string PurchaseID, string XmlItem, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_CRUD_INV_PURCHASE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@PurchaseID", PurchaseID);
                cmd.Parameters.AddWithValue("@XmlItem", XmlItem);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Fetch_Inv_Crud_Item(string LoggedInUserID, string CompanyID, string StockID, string XmlItem, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_CRUD_INV_ITEM", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@StockID", StockID);
                cmd.Parameters.AddWithValue("@XmlItem", XmlItem);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet Fetch_Tran_Detail(string LoggedInUserID, string CompanyID, int TransID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_INV_TRAN_STOCK_DETAIL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@TransID", TransID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Fetch_Tran_Item_Detail(string LoggedInUserID, string CompanyID, int TransID, string XmlItem, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_INV_TRAN_ITEM", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@TransID", TransID);
                cmd.Parameters.AddWithValue("@XmlItem", XmlItem);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Crud_Inv_Transaction(string LoggedInUserID, string CompanyID, string DeptID, string TranID, string XmlItem, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_CRUD_INV_TRAN", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@DeptID", DeptID);
                cmd.Parameters.AddWithValue("@TranID", TranID);
                cmd.Parameters.AddWithValue("@XmlItem", XmlItem);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Crud_Inv_Category_Mst(string LoggedInUserID, string CompanyID, int CategoryID, string CategoryDesc, string Action, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_Inv_Category_Mst", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@Category_ID", CategoryID);
                cmd.Parameters.AddWithValue("@Category_Desc", CategoryDesc);
                cmd.Parameters.AddWithValue("@Action", Action);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Crud_Inv_SubCategory_Mst(string LoggedInUserID, string CompanyID, string CategoryID, int SubCategoryID, string SubCategoryDesc, string Action, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_Inv_SubCategory_Mst", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@Category", CategoryID);
                cmd.Parameters.AddWithValue("@SubCategory_ID", SubCategoryID);
                cmd.Parameters.AddWithValue("@SubCategory_Desc", SubCategoryDesc);
                cmd.Parameters.AddWithValue("@Action", Action);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Crud_Inv_Item_Mst(string LoggedInUserID, string CompanyID, string CategoryID, string SubCategoryID, int ItemID, string ItemDesc, int DeptID, 
            int Opening, int Optimum, int Reorder, int Base, int CostRate, string Action, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {

                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_Inv_Item_Mst", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@Category", CategoryID);
                cmd.Parameters.AddWithValue("@SubCategory", SubCategoryID);
                cmd.Parameters.AddWithValue("@ItemID", ItemID);
                cmd.Parameters.AddWithValue("@ItemDesc", ItemDesc);
                cmd.Parameters.AddWithValue("@DeptID", DeptID);
                cmd.Parameters.AddWithValue("@Opening", Opening);
                cmd.Parameters.AddWithValue("@Optimum", Optimum);
                cmd.Parameters.AddWithValue("@Reorder", Reorder);
                cmd.Parameters.AddWithValue("@Base", Base);
                cmd.Parameters.AddWithValue("@CostRate", CostRate);
                cmd.Parameters.AddWithValue("@Action", Action);
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

        #region My Profile

        public DataSet Fetch_My_Profile_Details(string LoggedInUserID,string UserType, int CompanyID, string StrConn)
        {
            DataSet dsProfile = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_User_Profile_Details", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@UserType", UserType);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsProfile);
                return dsProfile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Update_My_Profile_Details(string PhoneNo, string AltPhoneNo, string EmailID, string Address, string City, string State, string Postcode, string LoggedInUserID,string UserType, int CompanyID, string StrConn)
        {
            DataSet dsProfile = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Update_User_Profile_Details", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
                cmd.Parameters.AddWithValue("@AltPhoneNo", AltPhoneNo);
                cmd.Parameters.AddWithValue("@EmailID", EmailID);
                cmd.Parameters.AddWithValue("@Address", Address);
                cmd.Parameters.AddWithValue("@City", City);
                cmd.Parameters.AddWithValue("@State", State);
                cmd.Parameters.AddWithValue("@Postcode", Postcode);
                cmd.Parameters.AddWithValue("@UserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@UserType", UserType);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsProfile);
                return dsProfile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Update_Change_Password(string Username, string CurrentPassword, string NewPassword, int CompanyID,string UserType, string StrConn)
        {
            DataSet dsChangePassword = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Update_Change_Password", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", Username);
                cmd.Parameters.AddWithValue("@CurrentPassword", CurrentPassword);
                cmd.Parameters.AddWithValue("@NewPassword", NewPassword);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@UserType", UserType);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsChangePassword);
                return dsChangePassword;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Retailer_Escalation_CRUD(int EscalationID, string Name, string Designation, string Department, string ContactNo, string EmailID, string LoggedInUserID, int CompanyID,string strAction, string StrConn)
        {
            DataSet dsEscalation = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Retailer_Escalation_CRUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EscalationID", EscalationID);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Designation", Designation);
                cmd.Parameters.AddWithValue("@Department", Department);
                cmd.Parameters.AddWithValue("@ContactNo", ContactNo);
                cmd.Parameters.AddWithValue("@EmailID", EmailID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID); 
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@strAction", strAction);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsEscalation);
                return dsEscalation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet My_Profile_Email_Verification(int Is_Email_Verified, string LoggedInUserID, int CompanyID, string StrConn)
        {
            DataSet dsProfile = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Update_User_Profile_Email_Verification", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Is_Email_Verified", Is_Email_Verified);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dsProfile);
                return dsProfile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        #endregion

        public DataSet Import_User_Master(int CompanyID, string LoggedInUserID, string StrConn)
        {
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Import_Users_Mst", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
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


        /*Mohammed*/

        public DataSet Import_Checklist_Master(int CompanyID, string LoggedInUserID, string StrConn)
        {
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Import_Checklist_Mst", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);

                cmd.CommandTimeout = 300;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Schedule_Checklist_CRUD(int CompanyID, string StrConn)
        {
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_Checklist_Schedule", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataSet Fetch_MyChecklist_NEW(int Chk_Config_ID,string LoggedInUserID, string CompanyID, string From_Date, string To_Date, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_FETCH_CHK_MYCHECKLIST_NEW", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Chk_Config_ID", Chk_Config_ID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
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

        public DataSet CRU_System_Setting(int Setting_ID, int Tkt_Is_Img_Open, int Tkt_Is_Img_Close, int Tkt_Is_Remark_Open, int Tkt_Is_Remark_Close, int Tkt_Is_Expiry, int Chk_Is_QR_Compulsory, int CompanyID, string LoggedInUserID, string Action,string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {

                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRU_SYS_Settings", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Setting_ID", Setting_ID);
                cmd.Parameters.AddWithValue("@Tkt_Is_Img_Open", Tkt_Is_Img_Open);
                cmd.Parameters.AddWithValue("@Tkt_Is_Img_Close", Tkt_Is_Img_Close);
                cmd.Parameters.AddWithValue("@Tkt_Is_Remark_Open", Tkt_Is_Remark_Open);
                cmd.Parameters.AddWithValue("@Tkt_Is_Remark_Close", Tkt_Is_Remark_Close);
                cmd.Parameters.AddWithValue("@Tkt_Is_Expiry", Tkt_Is_Expiry);
                cmd.Parameters.AddWithValue("@Chk_Is_QR_Compulsory", Chk_Is_QR_Compulsory );
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@Action", Action);
               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public DataSet Fetch_Custom_Fields(int CompanyID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("spr_Sys_Settings_Tkt_Fields", con);
                cmd.CommandType = CommandType.StoredProcedure;
              
                cmd.Parameters.AddWithValue("@Company_ID", CompanyID);
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet FetchUserEmail(string EmailID, string UserType, int CompanyID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {

                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_FetchEmailID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailID", EmailID);
                cmd.Parameters.AddWithValue("@UserType", UserType);
               
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
              

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet ForgetPasswordSendOTP(string EmailID, string OTP, int CompanyID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {

                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_ForgetPasswordSendOTP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailID", EmailID);
                cmd.Parameters.AddWithValue("@OTP", OTP);

                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet UpdatePassword(string User_ID,string EmailID, string Password,string UserType, int CompanyID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {

                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_UpdateForgetPassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", User_ID);
                cmd.Parameters.AddWithValue("@EmailID", EmailID);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@UserType", UserType);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public DataSet SiteMaster_CRUD(int Site_ID, string Site_Code, string Site_Name, int CompanyID,string LoggedInUserID,string Action, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {

                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_Site_Mst", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Site_ID", Site_ID);
                cmd.Parameters.AddWithValue("@Site_Code", Site_Code);
                cmd.Parameters.AddWithValue("@Site_Desc", Site_Name);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Action", Action);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet Fetch_states(int Country_Id,string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Fetch_States_List", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Country_Id", Country_Id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;

            }
             catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet Fetch_City(int State_Id,string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Fetch_City_List", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("State_ID", State_Id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return (ds);

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        #region Electricity Monitoring

        public DataSet INSERT_Electricity_Category(string Electricity_CatXML, int CompanyID, string LoggedInUserID,int Electricity_Cat_ID,string strAction, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {

                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_INSERT_Electricity_Category", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Electricity_CatXML", Electricity_CatXML);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Electricity_Cat_ID", Electricity_Cat_ID);
                cmd.Parameters.AddWithValue("@strAction", strAction);
                

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
