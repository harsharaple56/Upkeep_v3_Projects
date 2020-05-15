using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.General_Masters
{
    public partial class Add_Priority : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeepCC = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            //frmPriority.Action = @"General_Masters/Add_Priority.aspx";
            //frmPriority.Action = @"Add_Priority.aspx";
            if (!IsPostBack)
            {
                int Priority_ID = Convert.ToInt32(Request.QueryString["Priority_ID"]);
                int Del_Priority_ID = Convert.ToInt32(Request.QueryString["DelPrio_ID"]);

                if (Priority_ID > 0)
                {
                    FetchPriority(Priority_ID);
                }
                if (Del_Priority_ID > 0)
                {
                    DeletePriority(Del_Priority_ID);
                }
            }
        }

        protected void btnPrioritySave_Click(object sender, EventArgs e)
        {
            int Priority_ID = 0;
            try
            {
                if (Convert.ToString(Session["Priority_ID"]) != "")
                {
                    Priority_ID = Convert.ToInt32(Session["Priority_ID"]);
                }
                string Action = "";

                if (Priority_ID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                //ds = ObjUpkeepCC.DepartmentMaster_CRUD(Department_ID, txtDeptDesc.Text.Trim(), LoggedInUserID, "0", Action);
                ds = ObjUpkeepCC.PriorityMaster_CRUD(Priority_ID, txtPriorityDesc.Text.Trim(), CompanyID, LoggedInUserID, Action);


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
                            Session["Priority_ID"] = "";
                            //Response.Redirect("~/General_Masters/Priority_Master.aspx", false);
                            Response.Redirect(Page.ResolveClientUrl("~/General_Masters/Priority_Master.aspx"), false);
                        }
                        else if (Status == 3)
                        {
                            lblErrorMsg.Text = "Priority already exists";
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

        public void FetchPriority(int Priority_ID)
        {
            try
            {
                
                ds = ObjUpkeepCC.PriorityMaster_CRUD(Priority_ID, "", CompanyID, LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        Session["Priority_ID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Priority_ID"]);
                        txtPriorityDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["Priority_Desc"]);
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

        public void DeletePriority(int Priority_ID)
        {
            try
            {
                ds = ObjUpkeepCC.PriorityMaster_CRUD(Priority_ID, "", CompanyID, LoggedInUserID, "D");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["Priority_ID"] = "";
                        //Response.Redirect("~/General_Masters/Priority_Master.aspx", false);
                        Response.Redirect(Page.ResolveClientUrl("~/General_Masters/Priority_Master.aspx"), false);
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