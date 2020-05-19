using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Globalization;

namespace Upkeep_v3.Checklist
{
    public partial class Edit_Checklist : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        int CompanyID = 0;   //Added by Sujata
        string LoggedInUserID = string.Empty;
        int ChecklistID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            CompanyID = Convert.ToInt32(Session["CompanyID"]); //Added by Sujata
            ChecklistID = Convert.ToInt32(Request.QueryString["ChecklstID"]);  //ChecklstID
            
            if(Convert.ToString(Session["CurrentURL"]) !="")
            {
                btnAddPoint.Focus();
                Session["CurrentURL"] = "";
            }
            //frmChkList.Action = @"Edit_Checklist.aspx";
            if (!IsPostBack)
            {
                Session["CurrentURL"] = HttpContext.Current.Request.Url.AbsoluteUri;
                BindDepartment();
                BindLocationDetails(0, 0);
                bindChecklistDetails(ChecklistID);
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataSet dsAddChecklist = new DataSet();
            try
            {
                int ChecklistID = 0;
                int DeptID = 0;
                int ZoneID = 0;
                int LocationID = 0;
                int SubLocationID = 0;
                int ExpirytimeID = 0;
                int Frquency_Id = 0;
                int CustomeFrquency = 0;
                Boolean Chkapproval;
                Boolean ChkExpry;
                Boolean ChkSchedule;
                DateTime DtSchlddate;

                if (Convert.ToString(Session["ChecklistID"]) != "")
                {
                    ChecklistID = Convert.ToInt32(Session["ChecklistID"]);
                }

                DeptID = Convert.ToInt32(ddlDept.SelectedValue);
                ZoneID = Convert.ToInt32(ddlZone.SelectedValue);
                LocationID = Convert.ToInt32(ddlLocation.SelectedValue);
                SubLocationID = Convert.ToInt32(ddlSublocation.SelectedValue);
                Frquency_Id = Convert.ToInt32(ddlFrequency.SelectedIndex);
                ExpirytimeID = Convert.ToInt32(ddlExpirytime.SelectedValue);  //19/12/2019 12:55 PM
                DtSchlddate = DateTime.ParseExact(dtSchdate.Text, "dd/MM/yyyy hh:mm tt", System.Globalization.CultureInfo.InvariantCulture);

                if (ChkApproval.Checked == true)
                {
                    Chkapproval = true;
                }
                else
                {
                    Chkapproval = false;
                }

                if (ChkExpiry.Checked == true)
                {
                    ChkExpry = true;
                }
                else
                {
                    ChkExpry = false;
                }


                if (ChkIS.Checked == true)
                {
                    ChkSchedule = true;
                }
                else
                {
                    ChkSchedule = false;
                }

                CustomeFrquency = Convert.ToInt32(txtCustFrequency.Text.Trim());
                
                
                dsAddChecklist = ObjUpkeep.AddChecklistMaster_CRUD(ChecklistID, txtChklist.Text, DeptID, Chkapproval, ChkExpry, ChkSchedule, ExpirytimeID, DtSchlddate, txtStarttime.Text, txtEndtime.Text, CustomeFrquency, Frquency_Id, ZoneID, LocationID, SubLocationID, "", LoggedInUserID, "U");

                if (dsAddChecklist.Tables.Count > 0)
                {
                    if (dsAddChecklist.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsAddChecklist.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            Session["ChecklistID"] = "";
                            Response.Redirect(Page.ResolveClientUrl("~/Checklist/Checklist.aspx"), false);
                        }
                        else if (Status == 3)
                        {
                            lblErrorMsg.Attributes.Add("style", "display:block");
                            lblErrorMsg.Text = "Checklist name already exists";
                            txtChklist.Focus();
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

        public string bindChecklistPoint()
        {
            string data = "";
            DateTime DtSchlddate;
            try
            {
                DtSchlddate = Convert.ToDateTime(System.DateTime.Now.ToString());

                ds = ObjUpkeep.AddChecklistMaster_CRUD(ChecklistID, "", 0, false, false, false, 0, DtSchlddate, "", "", 0, 0, 0, 0, 0, "", LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[1].Rows.Count);
                        int ChecklistPoint_Id = 0;
                        string ChecklistPoint = string.Empty;
                        string AnswerType = string.Empty;
                        string CreatedOn = string.Empty;

                        for (int i = 0; i < count; i++)
                        {
                            ChecklistPoint_Id = Convert.ToInt32(ds.Tables[1].Rows[i]["Chk_Point_Id"]);
                            ChecklistPoint = Convert.ToString(ds.Tables[1].Rows[i]["Chk_Point_Desc"]);
                            AnswerType = Convert.ToString(ds.Tables[1].Rows[i]["Answer_Type"]);
                            CreatedOn = Convert.ToString(ds.Tables[1].Rows[i]["CreatedDate"]);
                            //data += "<tr><td>" + ChecklistPoint + "</td><td>" + AnswerType + "</td><td>" + CreatedOn + "</td><td><a href='Edit_Checklist.aspx?ChecklistPointId=" + ChecklistPoint_Id + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  <a href='Checklist.aspx?DelChecklistPointId=" + ChecklistPoint_Id + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";
                            data += "<tr><td>" + ChecklistPoint + "</td><td>" + AnswerType + "</td><td>" + CreatedOn + "</td><td><a class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' onclick='BindChklstPoint("+ChecklistPoint_Id+")' runat='server' class='la la-edit'></i> </a>  <a class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'><i id='btnedit' onclick='DeleteChklstPoint(" + ChecklistPoint_Id + ")' runat='server' class='la la-trash'></i> </a> </td></tr>";
                            //data += "<tr><td>" + ChecklistPoint + "</td><td>" + AnswerType + "</td><td>" + CreatedOn + "</td><td><a class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' onclick='BindChklstPoint(" + ChecklistPoint_Id + ")' runat='server' class='la la-edit'></i> </a>  <a onclick='DeleteChklstPoint(" + ChecklistPoint_Id + ")' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'><i id='btnDelete' runat='server' class='la la-trash'></i> </a> </td></tr>";

                        }
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
            return data;
        }

        public void bindChecklistDetails(int ChecklistID)
        {
            DateTime DtSchlddate;
            int ApprovalRequired = 0;
            int IsExpired = 0;
            int ScheduleChecklist = 0;
            try
            {
                DtSchlddate = Convert.ToDateTime(System.DateTime.Now.ToString());

                ds = ObjUpkeep.AddChecklistMaster_CRUD(ChecklistID, "", 0, false, false, false, 0, DtSchlddate, "", "", 0, 0, 0, 0, 0, "", LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["ChecklistID"]= Convert.ToString(ds.Tables[0].Rows[0]["Chk_Id"]);
                        txtChklist.Text = Convert.ToString(ds.Tables[0].Rows[0]["Chk_Name"]);
                        ddlDept.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Department_ID"]);

                        ApprovalRequired = Convert.ToInt32(ds.Tables[0].Rows[0]["Approval_Required"]);
                        if (ApprovalRequired == 1)
                        {
                            ChkApproval.Checked = true;
                        }
                        else
                        {
                            ChkApproval.Checked = false;
                        }

                        IsExpired = Convert.ToInt32(ds.Tables[0].Rows[0]["Is_Expire"]);
                        if (IsExpired == 1)
                        {
                            ChkExpiry.Checked = true;
                        }
                        else
                        {
                            ChkExpiry.Checked = false;
                        }

                        ddlExpirytime.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Expire_Time"]);

                        ScheduleChecklist = Convert.ToInt32(ds.Tables[0].Rows[0]["Is_Scheduled"]);
                        if (ScheduleChecklist == 1)
                        {
                            ChkIS.Checked = true;
                        }
                        else
                        {
                            ChkIS.Checked = false;
                        }


                        ddlFrequency.SelectedIndex= Convert.ToInt32(ds.Tables[0].Rows[0]["Frquency_Id"]);
                        txtStarttime.Text= Convert.ToString(ds.Tables[0].Rows[0]["Schedule_Start_Time"]);
                        txtEndtime.Text = Convert.ToString(ds.Tables[0].Rows[0]["Schedule_End_Time"]);
                        txtCustFrequency.Text = Convert.ToString(ds.Tables[0].Rows[0]["Frequency_Custom"]);

                        //DateTime dtSch;
                        string strSchDate= Convert.ToString(ds.Tables[0].Rows[0]["Schedule_Date"]);
                        DateTime myDateTime = DateTime.Parse(strSchDate);

                        //DateTime date = new DateTime();
                        //         date = DateTime.ParseExact(strSchDate, "yyyy-MM-dd HH:mm tt", null);
                        //DateTime date2 = DateTime.ParseExact(strSchDate, "yyyy-MM-dd HH:mm tt", null);

                        //if (DateTime.TryParseExact(strSchDate, "yyyy/MM/dd hh:mm:ss tt",
                        //   CultureInfo.InvariantCulture, DateTimeStyles.None,out dtSch))
                        //{
                        //    string text = dtSch.ToString("dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                        //    // Use text
                        //}

                        dtSchdate.Text = myDateTime.ToString("dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture);

                        ddlZone.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Zone_Id"]);
                        int ZoneID = 0;
                        ZoneID = Convert.ToInt32(ddlZone.SelectedValue);
                        BindLocationDetails(ZoneID, 0);
                        ddlLocation.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Loc_Id"]);
                        int LocationID = 0;
                        LocationID = Convert.ToInt32(ddlLocation.SelectedValue);
                        BindLocationDetails(ZoneID, LocationID);
                        ddlSublocation.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SubLoc_ID"]);
                            
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

        protected void btnCloseAddPoint_Click(object sender, EventArgs e)
        {
            mpeChecklistPoint.Hide();
            btnAddPoint.Focus();
        }

        protected void btnAddPointSave_Click(object sender, EventArgs e)
        {
            DataSet dsAddChecklistPoint = new DataSet();
            int ChecklistID = 0;
            int ChecklistPointID = 0;
            string Action = "";
            if (Convert.ToString(Session["ChecklistID"]) != "")
            {
                ChecklistID = Convert.ToInt32(Session["ChecklistID"]);
            }
            if (Convert.ToString(Session["ChecklistPointID"]) != "")
            {
                ChecklistPointID = Convert.ToInt32(Session["ChecklistPointID"]);
            }

            if (ChecklistPointID > 0)
            {
                Action = "U";
            }
            else
            {
                Action = "C";
            }

            dsAddChecklistPoint = ObjUpkeep.ChecklistPoint_CRUD(ChecklistID, ChecklistPointID, txtChklistpoints.Text, ddlChkPoint.SelectedValue , LoggedInUserID, Action);

            if (dsAddChecklistPoint.Tables.Count > 0)
            {
                if (dsAddChecklistPoint.Tables[0].Rows.Count > 0)
                {
                    Session["ChecklistPointID"] = "";
                    int Status = Convert.ToInt32(dsAddChecklistPoint.Tables[0].Rows[0]["Status"]);
                    if (Status == 1)
                    {
                        //Response.Redirect(Page.ResolveClientUrl("~/Checklist/Edit_Checklist.aspx"), false);
                        Response.Redirect(Page.ResolveClientUrl(Convert.ToString(Session["CurrentURL"])), false);
                        btnAddPoint.Focus();
                    }
                    else if (Status == 3)
                    {
                        lblChecklstPointErrorMsg.Text = "Checklist Point already exists";
                    }
                    else if (Status == 2)
                    {
                        lblChecklstPointErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                    }
                }
            }
        }

        protected void btnBindChklstPoint_Click(object sender, EventArgs e)
        {
            Session["ChecklistPointID"] = Convert.ToString(hdnChecklstPointID.Value);
            int ChecklistPointID = 0;
            if (Convert.ToString(Session["ChecklistPointID"]) != "")
            {
                hdnChecklstPointID.Value = "";
                ChecklistPointID = Convert.ToInt32(Session["ChecklistPointID"]);
                bindChecklistPoint(ChecklistPointID);
                mpeChecklistPoint.Show();
            }
            
            Session["DeleteChklstPointID"] = Convert.ToString(hdnDeleteChklstPointID.Value);
            int DeleteChklstPointID = 0;
            if (Convert.ToString(Session["DeleteChklstPointID"]) != "")
            {
                DeleteChklstPointID = Convert.ToInt32(Session["DeleteChklstPointID"]);

                DataSet dsAddChecklistPoint = new DataSet();
                int ChecklistID = 0;
               
                if (Convert.ToString(Session["ChecklistID"]) != "")
                {
                    ChecklistID = Convert.ToInt32(Session["ChecklistID"]);
                }

                dsAddChecklistPoint = ObjUpkeep.ChecklistPoint_CRUD(ChecklistID, DeleteChklstPointID, "", "", LoggedInUserID, "D");

                if (dsAddChecklistPoint.Tables.Count > 0)
                {
                    if (dsAddChecklistPoint.Tables[0].Rows.Count > 0)
                    {
                        Session["ChecklistPointID"] = "";
                        Session["DeleteChklstPointID"] = "";
                        hdnDeleteChklstPointID.Value = "";
                        int Status = Convert.ToInt32(dsAddChecklistPoint.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            //Response.Redirect(Page.ResolveClientUrl("~/Checklist/Edit_Checklist.aspx"), false);
                            Response.Redirect(Page.ResolveClientUrl(Convert.ToString(Session["CurrentURL"])), false);                            
                        }
                        
                        else if (Status == 2)
                        {
                            lblChecklstPointErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                    }
                }

            }
        }

        public void bindChecklistPoint(int ChecklistPointID)
        {
            DataSet dsChecklistPoint = new DataSet();
            dsChecklistPoint = ObjUpkeep.ChecklistPoint_CRUD(ChecklistID, ChecklistPointID, "", "", LoggedInUserID, "R");

            if (dsChecklistPoint.Tables.Count > 0)
            {
                if (dsChecklistPoint.Tables[0].Rows.Count > 0)
                {
                    txtChklistpoints.Text = Convert.ToString(dsChecklistPoint.Tables[0].Rows[0]["Chk_Point_Desc"]);
                    ddlChkPoint.SelectedValue = Convert.ToString(dsChecklistPoint.Tables[0].Rows[0]["Answer_Type"]);
                }
            }
        }
    }
}