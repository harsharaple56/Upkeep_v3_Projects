using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace Upkeep_v3.Checklist
{
    public partial class Checklist_Request : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0; //Added by Sujata
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]); //Added by Sujata
            frmChkList.Action = @"Checklist_Request.aspx";
            if (LoggedInUserID == "")
            {
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            if (!IsPostBack)
            {
                BindDepartment();
                BindLocationDetails(0, 0);
                BindDept_Checklist(LoggedInUserID);
            }
        }

        public void BindDepartment()
        {
            DataSet dsDepDetails = new DataSet();
            try
            {
                dsDepDetails = ObjUpkeep.Fetch_Department(CompanyID); //added company id by sujata 

                if (dsDepDetails.Tables.Count > 0)
                {
                    if (dsDepDetails.Tables[0].Rows.Count > 0)
                    {
                        ddlDept.DataSource = dsDepDetails.Tables[0];
                        ddlDept.DataTextField = "Department";
                        ddlDept.DataValueField = "Department_ID";
                        ddlDept.DataBind();
                        ddlDept.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void BindLocationDetails(int ZoneID, int LocationID)
        {
            DataSet dsLocDetails = new DataSet();
            try
            {
                dsLocDetails = ObjUpkeep.BindLocationDetails(ZoneID, LocationID);

                if (dsLocDetails.Tables.Count > 0)
                {
                    if (ZoneID == 0)
                    {
                        if (dsLocDetails.Tables[0].Rows.Count > 0)
                        {
                            ddlZone.DataSource = dsLocDetails.Tables[0];
                            ddlZone.DataTextField = "Zone_Desc";
                            ddlZone.DataValueField = "Zone_ID";
                            ddlZone.DataBind();
                            ddlZone.Items.Insert(0, new ListItem("--Select--", "0"));
                            ddlLocation.Items.Insert(0, new ListItem("--Select--", "0"));
                            ddlSublocation.Items.Insert(0, new ListItem("--Select--", "0"));
                        }
                    }
                    if (ZoneID > 0 && LocationID == 0)
                    {
                        if (dsLocDetails.Tables[1].Rows.Count > 0)
                        {
                            ddlLocation.DataSource = dsLocDetails.Tables[1];
                            ddlLocation.DataTextField = "Loc_Desc";
                            ddlLocation.DataValueField = "Loc_ID";
                            ddlLocation.DataBind();
                            ddlLocation.Items.Insert(0, new ListItem("--Select--", "0"));
                        }
                    }
                    if (LocationID > 0)
                    {
                        if (dsLocDetails.Tables[2].Rows.Count > 0)
                        {
                            ddlSublocation.DataSource = dsLocDetails.Tables[2];
                            ddlSublocation.DataTextField = "SubLoc_Desc";
                            ddlSublocation.DataValueField = "SubLoc_ID";
                            ddlSublocation.DataBind();
                            ddlSublocation.Items.Insert(0, new ListItem("--Select--", "0"));
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSublocation.Items.Clear();
            ddlSublocation.Items.Insert(0, new ListItem("--Select--", "0"));
            int ZoneID = 0;
            ZoneID = Convert.ToInt32(ddlZone.SelectedValue);
            BindLocationDetails(ZoneID, 0);
        }

        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSublocation.Items.Clear();
            ddlSublocation.Items.Insert(0, new ListItem("--Select--", "0"));
            int ZoneID = 0;
            int LocationID = 0;
            ZoneID = Convert.ToInt32(ddlZone.SelectedValue);
            LocationID = Convert.ToInt32(ddlLocation.SelectedValue);
            BindLocationDetails(ZoneID, LocationID);
        }

        public void BindDept_Checklist(string LoggedInUserID)
        {
            DataSet dsDepDetails = new DataSet();
            try
            {
                dsDepDetails = ObjUpkeep.ChecklistRequest("",0,0,0,0,0,"","",LoggedInUserID,"B");

                if (dsDepDetails.Tables.Count > 0)
                {
                    if (dsDepDetails.Tables[0].Rows.Count > 0)
                    {
                        ddlDept.SelectedValue = Convert.ToString(dsDepDetails.Tables[0].Rows[0]["Department_ID"]);
                        //ddlDept.Attributes.Add("class", "form-control m-input disabled");
                       // ddlDept.Attributes.Add("disabled", "disabled");
                    }
                }
                if (dsDepDetails.Tables.Count > 1)
                {
                    if (dsDepDetails.Tables[1].Rows.Count > 0)
                    {
                        ddlChecklist.DataSource = dsDepDetails.Tables[1];
                        ddlChecklist.DataTextField = "Chk_Name";
                        ddlChecklist.DataValueField = "Chk_Id";
                        ddlChecklist.DataBind();
                        ddlChecklist.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataSet dsAChecklistReq = new DataSet();
            try
            {
                string ScheduleDate = string.Empty;
                int ZoneID = 0;
                int LocationID = 0;
                int SubLocationID = 0;
                int DepartmentID = 0;
                int ChecklistID = 0;
                string StartTime = string.Empty;

                ScheduleDate = Convert.ToString(txtScheduleDate.Value);
                ZoneID = Convert.ToInt32(ddlZone.SelectedValue);
                LocationID = Convert.ToInt32(ddlLocation.SelectedValue);
                SubLocationID = Convert.ToInt32(ddlSublocation.SelectedValue);
                DepartmentID = Convert.ToInt32(ddlDept.SelectedValue);
                ChecklistID = Convert.ToInt32(ddlChecklist.SelectedValue);
                StartTime = Convert.ToString(txtStartTime.Value);

                dsAChecklistReq = ObjUpkeep.ChecklistRequest(ScheduleDate, ZoneID, LocationID, SubLocationID, DepartmentID, ChecklistID, StartTime,"",LoggedInUserID, "C");
                if (dsAChecklistReq.Tables.Count > 0)
                {
                    if (dsAChecklistReq.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsAChecklistReq.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            Session["TicketNo"] = Convert.ToString(dsAChecklistReq.Tables[1].Rows[0]["TicketId"]);
                            Response.Redirect(Page.ResolveClientUrl("~/Checklist/Checklist_Action.aspx"), false);
                        }

                        else if (Status == 2)
                        {
                            //lblChecklstErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
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