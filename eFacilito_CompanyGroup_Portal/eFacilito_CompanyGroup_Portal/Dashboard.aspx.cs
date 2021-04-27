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

namespace eFacilito_CompanyGroup_Portal
{
    public partial class Dashboard : System.Web.UI.Page
    {

        eFacilito_CompanyGroup_Portal_Service.eFacilito_CompanyGroup_Portal_Service objUpkeepCC = new eFacilito_CompanyGroup_Portal_Service.eFacilito_CompanyGroup_Portal_Service();

        string LoggedInUserID = string.Empty;
        int Group_ID = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            Group_ID = Convert.ToInt32(Session["Group_ID"]);


            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }
           
            hdn_IsPostBack.Value = "yes";

            if (!IsPostBack)
            {
                hdn_IsPostBack.Value = "no";
                bind_ddl_CompanyList();

            }

        }


        public void bind_ddl_CompanyList()
        {
            try
            {
                Group_ID = Convert.ToInt32(Session["Group_ID"]);
                DataSet ds = new DataSet();

                ds = objUpkeepCC.Fetch_Group_Dashboard_Company_List(Group_ID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddl_CompanyList.DataSource = ds.Tables[0];
                        ddl_CompanyList.DataTextField = "Company_Desc";
                        ddl_CompanyList.DataValueField = "Company_ID";
                        ddl_CompanyList.DataBind();
                        ddl_CompanyList.Items.Insert(0, new ListItem("-- Select Company --", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btn_LoadDashboard_Click(object sender, EventArgs e)
        {
            //if (start_date.Value != "")
            //{
            //    Fromdate = Convert.ToString(start_date.Value);
            //}
            //else
            //{
            //    DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture)).AddDays(-30);
            //    Fromdate = FromDate.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
            //}

            //if (end_date.Value != "")
            //{
            //    ToDate = Convert.ToString(end_date.Value);
            //}
            //else
            //{
            //    ToDate = DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
            //}


            string Fromdate = "01/Jan/2016";
            string ToDate = "01/Jan/2022";

            int Company_ID = Convert.ToInt32(ddl_CompanyList.SelectedValue);


       

            DataSet ds = new DataSet();
            try
            {
                ds = objUpkeepCC.Fetch_Group_Dashboard(Company_ID, LoggedInUserID, Fromdate, ToDate);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lbl_Tkt_Total.Text = Convert.ToString(ds.Tables[0].Rows[0]["Total_Tickets"]);
                        lbl_Tkt_open.Text = Convert.ToString(ds.Tables[0].Rows[0]["Open_Tickets"]);
                        lbl_Tkt_Parked.Text = Convert.ToString(ds.Tables[0].Rows[0]["Parked_Tickets"]);
                        lbl_Tkt_Closed.Text = Convert.ToString(ds.Tables[0].Rows[0]["Closed_Tickets"]);
                        lbl_Tkt_Expired.Text = Convert.ToString(ds.Tables[0].Rows[0]["Expired_Tickets"]);

                        lbl_Chk_Total_Attended.Text = Convert.ToString(ds.Tables[0].Rows[0]["Chk_Total_Attended"]);
                        lbl_chk_Open.Text = Convert.ToString(ds.Tables[0].Rows[0]["Chk_Pending"]);
                        lbl_chk_Closed.Text = Convert.ToString(ds.Tables[0].Rows[0]["Chk_Closed"]);

                        lbl_WP_Total.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Total"]);
                        lbl_WP_Open.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Open"]);
                        lbl_WP_InProgress.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_InProgress"]);
                        lbl_WP_Hold.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Hold"]);
                        lbl_WP_Approved.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Approved"]);
                        lbl_WP_Rejected.Text = Convert.ToString(ds.Tables[0].Rows[0]["wP_Raised_Rejected"]);
                        lbl_WP_Expired.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Expired"]);
                        lbl_WP_Closed.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Closed"]);

                        lbl_GP_Total.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Total"]);
                        lbl_GP_Open.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Open"]);
                        lbl_GP_InProgress.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_InProgress"]);
                        lbl_GP_Hold.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Hold"]);
                        lbl_GP_Approved.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Approved"]);
                        lbl_GP_Rejected.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Rejected"]);
                        lbl_GP_Expired.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Expired"]);
                        lbl_GP_Closed.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Closed"]);

                        lbl_Feedback_Total.Text = Convert.ToString(ds.Tables[0].Rows[0]["Feedback_Total"]);

                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void ddl_CompanyList_SelectedIndexChanged(object sender, EventArgs e)
        {

            string Fromdate = "01/Jan/2016";
            string ToDate = "01/Jan/2022";

            int Company_ID = Convert.ToInt32(ddl_CompanyList.SelectedValue);




            DataSet ds = new DataSet();
            try
            {
                ds = objUpkeepCC.Fetch_Group_Dashboard(Company_ID, LoggedInUserID, Fromdate, ToDate);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lbl_Tkt_Total.Text = Convert.ToString(ds.Tables[0].Rows[0]["Total_Tickets"]);
                        lbl_Tkt_open.Text = Convert.ToString(ds.Tables[0].Rows[0]["Open_Tickets"]);
                        lbl_Tkt_Parked.Text = Convert.ToString(ds.Tables[0].Rows[0]["Parked_Tickets"]);
                        lbl_Tkt_Closed.Text = Convert.ToString(ds.Tables[0].Rows[0]["Closed_Tickets"]);
                        lbl_Tkt_Expired.Text = Convert.ToString(ds.Tables[0].Rows[0]["Expired_Tickets"]);

                        lbl_Chk_Total_Attended.Text = Convert.ToString(ds.Tables[0].Rows[0]["Chk_Total_Attended"]);
                        lbl_chk_Open.Text = Convert.ToString(ds.Tables[0].Rows[0]["Chk_Pending"]);
                        lbl_chk_Closed.Text = Convert.ToString(ds.Tables[0].Rows[0]["Chk_Closed"]);

                        lbl_WP_Total.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Total"]);
                        lbl_WP_Open.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Open"]);
                        lbl_WP_InProgress.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_InProgress"]);
                        lbl_WP_Hold.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Hold"]);
                        lbl_WP_Approved.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Approved"]);
                        lbl_WP_Rejected.Text = Convert.ToString(ds.Tables[0].Rows[0]["wP_Raised_Rejected"]);
                        lbl_WP_Expired.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Expired"]);
                        lbl_WP_Closed.Text = Convert.ToString(ds.Tables[0].Rows[0]["WP_Raised_Closed"]);

                        lbl_GP_Total.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Total"]);
                        lbl_GP_Open.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Open"]);
                        lbl_GP_InProgress.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_InProgress"]);
                        lbl_GP_Hold.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Hold"]);
                        lbl_GP_Approved.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Approved"]);
                        lbl_GP_Rejected.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Rejected"]);
                        lbl_GP_Expired.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Expired"]);
                        lbl_GP_Closed.Text = Convert.ToString(ds.Tables[0].Rows[0]["GP_Raised_Closed"]);

                        lbl_Feedback_Total.Text = Convert.ToString(ds.Tables[0].Rows[0]["Feedback_Total"]);

                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}