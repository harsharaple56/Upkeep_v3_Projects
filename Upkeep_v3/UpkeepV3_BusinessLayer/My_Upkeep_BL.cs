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

        public DataSet UserTypeMaster_CRUD(int User_Type_ID, string User_Type_Desc,int CompanyID, string LoggedInUserID, string Action, string StrConn)
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

        public DataSet DepartmentMaster_CRUD(int Department_ID, string Dept_Desc,int CompanyID, string LoggedInUserID, string Is_Deleted, string Action, string StrConn)
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

        public DataSet PriorityMaster_CRUD(int Priority_ID, string Priority_Desc,int CompanyID, string LoggedInUserID, string Action, string StrConn)
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

        public DataSet FrequencyMaster_CRUD(int Frquency_Id, string Frquency_Desc,int CompanyID, string LoggedInUserID, string Action, string StrConn)
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


        public DataSet UserGroupMaster_CRUD(int Grp_Id, string Grp_Desc, string User_ID,int CompanyID, string LoggedInUserID, string Action, string StrConn)
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


        public DataSet FetchDepartment(int CompanyID,String StrConn)
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
        public DataSet FetchUserType(int CompanyID , String StrConn) //Added CompanyId by sujata
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


        public DataSet UserMaster_CRUD(int User_ID, string User_Code, string F_name, string L_Name, string User_Mobile, string User_Email, string User_MobileAlter, string User_Landline, string User_Designation, int User_Type_ID, int Zone_ID, int Loc_ID, int SubLoc_Id, int Department_Id, string Login_Id, string Password, int Is_Approver, int Is_GobalApprover, string Approver_ID, string Profilephoto,int CompanyID, string LoggedInUserID, string Action, string StrConn)
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
                cmd.Parameters.AddWithValue("@Profile_photo", Profilephoto); 
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
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

        public DataSet LoginUser(string UserName, string strPassword, string strConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(strConn);

                SqlCommand cmd = new SqlCommand("Spr_Login", con);
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




        public DataSet FetchUserGrp(int GroupID,int CompanyID,string StrConn)
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

        public DataSet Fetch_CategorySubCategory(int CategoryID, string StrConn)
        {
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_CategorySubCategory_List", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet WorkflowMaster_CRUD(int WorkflowID, string WorkflowDesc, int ZoneID, int CategoryID, int SubCategoryID, string xmlWorkflow,int CompanyID, string LoggedInUserID, string Action, string StrConn)
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

        public DataSet Fetch_User_UserGroupList(string StrConn)
        {
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_FetchUser_UserGroup", con);
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

        public DataSet CategoryMaster_CRUD(int Category_ID, string Category_Desc, int DepartmentID, string LoggedInUserID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_Category", con);
                cmd.CommandType = CommandType.StoredProcedure;
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

        public DataSet SubCategoryMaster_CRUD(int SubcategoryID, string SubCategoryDesc, int CategoryID, int Approval_Required, string LoggedInUserID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_SubCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
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

        public DataSet Fetch_Ticket_Workflow(int ZoneID, int CategoryID, int SubCategoryID, string TicketPrefix, string LoggedInUserID, string StrConn)
        {
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_TKT_Fetch_Workflow", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ZoneID", ZoneID);
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

        public DataSet Insert_Ticket_Details(string TicketCode, int ZoneID, int LocationID, int SubLocationID, int CategoryID, int SubCategoryID, string TicketMessage, string list_Images, string LoggedInUserID, string strAction, string StrConn)
        {
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_Ticket_Mast", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TktCode", TicketCode);
                cmd.Parameters.AddWithValue("@ZoneID", ZoneID);
                cmd.Parameters.AddWithValue("@LocationID", LocationID);
                cmd.Parameters.AddWithValue("@SubLocationID", SubLocationID);
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                cmd.Parameters.AddWithValue("@SubCategoryID", SubCategoryID);
                cmd.Parameters.AddWithValue("@TicketMessage", TicketMessage);
                cmd.Parameters.AddWithValue("@TicketImages", list_Images);
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

        public DataSet Update_ChecklistPoints(string TicketNumber, string strXmlChecklist,string list_Images, string LoggedInUserID, string StrConn)
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
        public DataSet Close_Ticket_Details(string TicketID, string CloseTicketDesc, string LoggedInUserID, string list_Images, string StrConn)
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
        public DataSet Location_PopulateRootLevel(int CompanyID,string StrConn)
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

        public DataSet Location_PopulateSubLevel(int ParentID,string StrConn)
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


        #region VMS
        //Added by RC This function is used to save VMS Configuration
        public DataSet Insert_VMSConfiguration(string strConfigTitle, string strConfigDesc, int CompanyID, string strXmlVMS_Question, string strXmlVMS_Feedback, bool blFeedbackCompulsary, string LoggedInUserID, string StrConn)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("SPR_INSERT_VMS_CONFIG", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ConfigTitle", strConfigTitle);
                cmd.Parameters.AddWithValue("@ConfigTitle", strConfigTitle);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@XmlVMS_Question", strXmlVMS_Question);
                cmd.Parameters.AddWithValue("@XmlVMS_Feedback", strXmlVMS_Feedback);
                cmd.Parameters.AddWithValue("@isFeedbackCompulsary", blFeedbackCompulsary);
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
        public DataSet Fetch_Answer(char Key,string StrConn)
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
        #endregion
    }

}
