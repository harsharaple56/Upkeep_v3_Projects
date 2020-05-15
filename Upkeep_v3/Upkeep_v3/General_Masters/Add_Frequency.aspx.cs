using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.General_Masters
{
    public partial class Add_Frequency : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeepCC = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            //frmFrequency.Action = @"General_Masters/Add_Frequency.aspx";
            //frmFrequency.Action = @"Add_Frequency.aspx";
            if (LoggedInUserID == "")
            {
                Response.Redirect("~/Login.aspx", false);
            }

            if (!IsPostBack)
            {
                int Frequency_Id = Convert.ToInt32(Request.QueryString["Frquency_Id"]);
                int Del_Frequency_ID = Convert.ToInt32(Request.QueryString["DelFreq_ID"]);

                if (Frequency_Id > 0)
                {
                    FetchFrequency(Frequency_Id);
                }
                if (Del_Frequency_ID > 0)
                {
                    DeleteFrequency(Del_Frequency_ID);
                }
            }
        }

        protected void btnFrequencySave_Click(object sender, EventArgs e)
        {
            int Frequency_ID = 0;
            try
            {
                if (Convert.ToString(Session["Frequency_ID"]) != "")
                {
                    Frequency_ID = Convert.ToInt32(Session["Frequency_ID"]);
                }
                string Action = "";

                if (Frequency_ID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                ds = ObjUpkeepCC.FrequencyMaster_CRUD(Frequency_ID, txtFrequencyDesc.Text.Trim(), CompanyID, LoggedInUserID, Action);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 0)
                        {

                        }
                        else if (Status == 1)
                        {
                            Session["Frequency_ID"] = "";
                            //Response.Redirect("~/General_Masters/Frequency_Master.aspx", false);
                            Response.Redirect(Page.ResolveClientUrl("~/General_Masters/Frequency_Master.aspx"), false);
                        }
                        else if (Status == 3)
                        {
                            lblErrorMsg.Text = "Frequency already exists";
                        }
                        else if (Status == 2)
                        {
                            lblErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FetchFrequency(int Frequency_Id)
        {
            try
            {
                ds = ObjUpkeepCC.FrequencyMaster_CRUD(Frequency_Id, "", CompanyID, LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        Session["Frequency_ID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Frquency_Id"]);
                        txtFrequencyDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["Frquency_Desc"]);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteFrequency(int Frequency_Id)
        {
            try
            {
                ds = ObjUpkeepCC.FrequencyMaster_CRUD(Frequency_Id, "", CompanyID, LoggedInUserID, "D");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["Frequency_ID"] = "";
                        //Response.Redirect("~/General_Masters/Frequency_Master.aspx", false);
                        Response.Redirect(Page.ResolveClientUrl("~/General_Masters/Frequency_Master.aspx"), false);
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}