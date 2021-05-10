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
    public partial class Dashboard_Retailer : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            hdnCompanyID.Value = Convert.ToString(Session["CompanyID"]);
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
                return;
            }
            hdn_IsPostBack.Value = "yes";
            if (!IsPostBack)
            {
                //Fetch_Company();
                hdn_IsPostBack.Value = "no";
                if (Convert.ToString(Session["UserType"]) == "R")
                {
                    Fetch_Retailer_Latest_Punch();
                }
            }
        }

        protected void Btn_Retailer_PunchIn_Click(object sender, EventArgs e)
        {
            string Punch_Type = "IN";
            DataSet dspunch = new DataSet();
            try
            {
                dspunch = ObjUpkeep.RetailerPunch_CR(LoggedInUserID, Punch_Type, CompanyID, "C");

                if (dspunch.Tables.Count > 0)
                {
                    if (dspunch.Tables[0].Rows.Count > 0)
                    {
                        lblPunchInTime.Text = Convert.ToString(dspunch.Tables[0].Rows[0]["Punch_Datetime"]);
                        btnPunchIn.Attributes.Add("style", "display:none;");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Btn_Retailer_PunchOut_Click(object sender, EventArgs e)
        {
            string Punch_Type = "OUT";
            DataSet dspunch = new DataSet();

            try
            {
                dspunch = ObjUpkeep.RetailerPunch_CR(LoggedInUserID, Punch_Type, CompanyID, "C");

                if (dspunch.Tables.Count > 0)
                {
                    if (dspunch.Tables[0].Rows.Count > 0)
                    {
                        lblPunchOutTime.Text = Convert.ToString(dspunch.Tables[0].Rows[0]["Punch_Datetime"]);
                        btnPunchOut.Attributes.Add("style", "display:none;");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Fetch_Retailer_Latest_Punch()
        {

            DataSet dspunch = new DataSet();

            try
            {
                dspunch = ObjUpkeep.RetailerPunch_CR(LoggedInUserID, "", CompanyID, "R");

                if (dspunch.Tables.Count > 0)
                {
                    if (dspunch.Tables[0].Rows.Count > 0)
                    {
                        lblPunchInTime.Text = Convert.ToString(dspunch.Tables[0].Rows[0]["PunchIn_Datetime"]);
                        lblPunchOutTime.Text = Convert.ToString(dspunch.Tables[0].Rows[0]["PunchOut_Datetime"]);

                        if (Convert.ToString(dspunch.Tables[0].Rows[0]["PunchIn_Datetime"]) != "")
                        {
                            btnPunchIn.Attributes.Add("style", "display:none;");
                        }

                        if (Convert.ToString(dspunch.Tables[0].Rows[0]["PunchOut_Datetime"]) != "")
                        {
                            btnPunchOut.Attributes.Add("style", "display:none;");
                        }

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