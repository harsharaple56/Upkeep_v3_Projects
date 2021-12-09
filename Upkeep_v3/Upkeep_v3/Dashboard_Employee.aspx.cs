using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Text;
using System.Globalization;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;

namespace Upkeep_v3

{
    public partial class Dashboard_Employee : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        public static string LoggedInUserID = string.Empty;
        public static int CompanyID = 0;

        string Role_Name = string.Empty;
        string UserType = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            UserType = Convert.ToString(Session["UserType"]);

            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }
            hdn_IsPostBack.Value = "yes";
            if (!IsPostBack)
            {
                if (UserType == "E")
                {
                    hdn_IsPostBack.Value = "no";
                }
                else
                {
                    Response.Redirect("~/Dashboard_Retailer.aspx");
                }

            }

        }

        protected void btn_Employee_Dashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Dashboard_Employee.aspx");
        }

        protected void btn_Admin_Dashboard_Click(object sender, EventArgs e)
        {

            Role_Name = Convert.ToString(Session["Role_Name"]);

            if (Role_Name == "Property Admin")
            {
                Response.Redirect("~/Dashboard_Admin.aspx");
            }
            else
            {
                Response.Redirect("~/Dashboard_Employee.aspx");
            }

        }

        [System.Web.Services.WebMethod]
        public static Dictionary<string, string> GetDashboardDetails(string start_Date, string end_Date)
        {
            Dashboard_Employee obj = new Dashboard_Employee();
            string Fromdate = start_Date;
            string ToDate = end_Date;
            DataSet ds = new DataSet();
            Dictionary<string, string> list = new Dictionary<string, string>();

            try
            {
                ds = obj.ObjUpkeep.Fetch_Dashboard_Employee(CompanyID, LoggedInUserID, Fromdate, ToDate, 0, string.Empty);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        list.Add("lbl_tkt_Pending_Close", Convert.ToString(ds.Tables[0].Rows[0]["Pending_Closure_Tickets"]));
                        list.Add("lbl_tkt_Open_Accepted", Convert.ToString(ds.Tables[0].Rows[0]["Accepted_Tickets"]));
                        list.Add("lbl_Tkt_Open_Assigned", Convert.ToString(ds.Tables[0].Rows[0]["Assigned_Tickets"]));
                        list.Add("lbl_Tkt_Parked_Hold", Convert.ToString(ds.Tables[0].Rows[0]["Parked_Tickets"]));
                        list.Add("lbl_Tkt_Open_User", Convert.ToString(ds.Tables[0].Rows[0]["MyAcc_Open_Tickets"]));
                        list.Add("lbl_tkt_Closed_User", Convert.ToString(ds.Tables[0].Rows[0]["MyAcc_Closed_Tickets"]));
                        list.Add("lbl_Tkt_Expired_User", Convert.ToString(ds.Tables[0].Rows[0]["MyAcc_Expired_Tickets"]));
                        list.Add("lbl_Chk_Total", Convert.ToString(ds.Tables[0].Rows[0]["Chk_Pending"]));
                        list.Add("lbl_Chk_Open_User", Convert.ToString(ds.Tables[0].Rows[0]["Chk_Draft"]));
                        list.Add("lbl_Chk_Closed_User", Convert.ToString(ds.Tables[0].Rows[0]["Chk_Closed"]));

                        list.Add("lbl_WP_Pending_Approvals",Convert.ToString(ds.Tables[0].Rows[0]["WP_Pending_Approvals"]));
                        list.Add("lbl_WP_Open_User", Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Open"]));
                        list.Add("lbl_WP_InProgress_User", Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_InProgress"]));
                        list.Add("lbl_WP_OnHold_User", Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Hold"]));
                        list.Add("lbl_WP_Approved_User", Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Approved"]));

                        list.Add("lbl_GP_Pending_Approval", Convert.ToString(ds.Tables[0].Rows[0]["GP_Pending_Approvals"]));
                        list.Add("lbl_GP_Open_User", Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Open"]));
                        list.Add("lbl_GP_InProgress", Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_InProgress"]));
                        list.Add("lbl_GP_OnHold", Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Hold"]));
                        list.Add("lbl_GP_Approved_User", Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Approved"]));

                        list.Add("lbl_VMS_IN",  Convert.ToString(ds.Tables[0].Rows[0]["VMS_IN"]));
                        list.Add("lbl_VMS_OUT", Convert.ToString(ds.Tables[0].Rows[0]["VMS_OUT"]));
                        list.Add("lbl_VMS_Pending", Convert.ToString(ds.Tables[0].Rows[0]["VMS_Pending"]));
                        list.Add("lbl_VMS_Recieved", Convert.ToString(ds.Tables[0].Rows[0]["VMS_Recieved"]));
                        list.Add("lbl_VMS_Rejected",  Convert.ToString(ds.Tables[0].Rows[0]["VMS_Rejected"]));

                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            DataSet ds1 = new DataSet();
                            ds1 = obj.ObjUpkeep.Fetch_Dashboard_Employee(CompanyID, LoggedInUserID, Fromdate, ToDate, Convert.ToInt32(ds.Tables[1].Rows[i].ItemArray[0]), "F");

                            if (ds1.Tables[0].Rows[0]["Module_Code"] != null)
                            {
                                if (Convert.ToString(ds1.Tables[0].Rows[0]["Module_Code"]) == "TKT")
                                {
                                    list.Add("Tkt_Visible","true");
                                }

                                if (Convert.ToString(ds1.Tables[0].Rows[0]["Module_Code"]) == "CHK")
                                {
                                    list.Add("Chk_Visible", "true");
                                }

                                if (Convert.ToString(ds1.Tables[0].Rows[0]["Module_Code"]) == "WP")
                                {
                                    list.Add("WP_Visible", "true");

                                }

                                if (Convert.ToString(ds1.Tables[0].Rows[0]["Module_Code"]) == "GP")
                                {
                                    list.Add("GP_Visible", "true");
                                }

                                if (Convert.ToString(ds1.Tables[0].Rows[0]["Module_Code"]) == "VMS")
                                {
                                    list.Add("VMS_Visible", "true");
                                }
                            }

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list ;
        }
    }
}