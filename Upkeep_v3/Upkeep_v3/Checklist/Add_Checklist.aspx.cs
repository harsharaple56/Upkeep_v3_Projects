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
    public partial class Add_Checklist : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;    //Added by Sujata
        protected void Page_Load(object sender, EventArgs e)
        {
            CompanyID = Convert.ToInt32(Session["CompanyID"]); //Added by Sujata
            frmChkList.Action = @"Add_Checklist.aspx";
            if (!IsPostBack)
            {
                BindDepartment();
                BindLocationDetails(0, 0);
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
                dsDepDetails = ObjUpkeep.Fetch_Department(CompanyID);  //added company id by sujata 

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
                string ChecklistPoint = string.Empty;
                string ChklistAnsType = string.Empty;

                StringBuilder strXmlChecklistPoint = new StringBuilder();
                strXmlChecklistPoint.Append(@"<?xml version=""1.0"" ?>");
                strXmlChecklistPoint.Append(@"<CHECKLIST_ROOT>");


                int ccc = Request.Form.Count;
                for (int i = 0; i < ccc; i++)
                {
                    string[] CustQuesArray = Request.Form.GetValues("Customer[" + i + "][ctl00$ContentPlaceHolder1$txtChklistpoints]");

                    if (CustQuesArray != null)
                    {
                        ChecklistPoint = CustQuesArray[0];
                    }

                    string[] CustQuestypeArray = Request.Form.GetValues("Customer[" + i + "][type]");

                    if (CustQuestypeArray != null)
                    {
                        ChklistAnsType = CustQuestypeArray[0];
                    }

                    if (CustQuesArray != null && CustQuestypeArray != null)
                    {
                        strXmlChecklistPoint.Append(@"<CHECKLIST_POINT>");
                        strXmlChecklistPoint.Append(@"<ChecklistPoint>" + ChecklistPoint + "</ChecklistPoint>");
                        strXmlChecklistPoint.Append(@"<ChecklistAnsType>" + ChklistAnsType + "</ChecklistAnsType>");

                        strXmlChecklistPoint.Append(@"</CHECKLIST_POINT>");
                    }
                }

                strXmlChecklistPoint.Append(@"</CHECKLIST_ROOT>");
                dsAddChecklist= ObjUpkeep.AddChecklistMaster_CRUD(ChecklistID,txtChklist.Text, DeptID, Chkapproval, ChkExpry, ChkSchedule, ExpirytimeID, DtSchlddate, txtStarttime.Text, txtEndtime.Text, CustomeFrquency, Frquency_Id, ZoneID, LocationID, SubLocationID, strXmlChecklistPoint.ToString(), LoggedInUserID, "C");

                if (dsAddChecklist.Tables.Count > 0)
                {
                    if (dsAddChecklist.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsAddChecklist.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {                         
                            Response.Redirect(Page.ResolveClientUrl("~/Checklist/Checklist.aspx"), false);
                        }
                        else if (Status == 3)
                        {
                            lblErrorMsg.Text = "Checklist name already exists";
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


       

        protected void ddlChklist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlScheduledate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        protected void ddlSublocation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}