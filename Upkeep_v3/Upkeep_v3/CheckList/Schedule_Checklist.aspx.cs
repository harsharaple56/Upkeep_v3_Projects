using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace Upkeep_v3.CheckList
{
    public partial class Schedule_Checklist : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        public static int Chk_Map_ID = 0;

        public static string Action;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            //frmMain.Action = @"Workflow_Details.aspx";
            if (LoggedInUserID == "")
            {
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            if (!IsPostBack)
            {

                //bindgrid();
                Chk_Map_ID = Convert.ToInt32(Request.QueryString["EditMapId"]);
                int DelChk_Map_ID = Convert.ToInt32(Request.QueryString["DelMapID"]);

                Fetch_Checklist();
                Fetch_Department();
                Fetch_Location();
                if (Chk_Map_ID > 0)
                {
                    // bindgrid(Grp_Id);
                    fetchCHKMap(Chk_Map_ID);
                   // Fetch_Checklist_NEW( );
                   // Fetch_Department();
                }
                if (DelChk_Map_ID > 0)
                {
                    DeleteCHKMap(DelChk_Map_ID);
                }

              
            }
        }


        public void Fetch_Checklist_NEW()
        {
            int Chk_Config_ID = 0;
           DataSet dsChecklist = new DataSet();
            try
            {
                dsChecklist = ObjUpkeep.Fetch_MyChecklist_NEW(Chk_Config_ID, LoggedInUserID, Convert.ToString(CompanyID), "", "");

                if (dsChecklist.Tables.Count > 0)
                {
                    if (dsChecklist.Tables[0].Rows.Count > 0)
                    {
                        ddlChecklist.DataSource = dsChecklist.Tables[0];
                        ddlChecklist.DataTextField = "Chk_Title";
                        ddlChecklist.DataValueField = "Chk_Config_ID";
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
        public void Fetch_Checklist()
        {
            DataSet dsChecklist = new DataSet();
            try
            {
                dsChecklist = ObjUpkeep.Fetch_MyChecklist(LoggedInUserID, Convert.ToString(CompanyID), "", "");

                if (dsChecklist.Tables.Count > 0)
                {
                    if (dsChecklist.Tables[0].Rows.Count > 0)
                    {
                        ddlChecklist.DataSource = dsChecklist.Tables[0];
                        ddlChecklist.DataTextField = "Chk_Title";
                        ddlChecklist.DataValueField = "Chk_Config_ID";
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
        public void Fetch_Department()
        {
            DataSet dsDept = new DataSet();
            try
            {
                dsDept = ObjUpkeep.Fetch_Department(CompanyID);

                if (dsDept.Tables.Count > 0)
                {
                    if (dsDept.Tables[0].Rows.Count > 0)
                    {
                        ddlDepartment.DataSource = dsDept.Tables[0];
                        ddlDepartment.DataTextField = "Department";
                        ddlDepartment.DataValueField = "Department_ID";
                        ddlDepartment.DataBind();
                        ddlDepartment.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Fetch_Location()
        {
            DataSet dsLocDetails = new DataSet();
            try
            {
                dsLocDetails = ObjUpkeep.Fetch_LocationTree(CompanyID);

                if (dsLocDetails.Tables.Count > 0)
                {
                    if (dsLocDetails.Tables[0].Rows.Count > 0)
                    {
                        gvLocation.DataSource = dsLocDetails.Tables[0];
                        gvLocation.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSaveChecklistSchedule_Click(object sender, EventArgs e)
        {
            string SelectedLocationID = string.Empty;
            int Checklist_ConfigID = 0;
            int DepartmentID = 0;
            DataSet dsChecklist = new DataSet();
            lblSuccessMsg.Text = "";
            lblError.Text = "";
           

            if (Chk_Map_ID == 0)
            {
                Action = "C";
            }
            else
            {
                Action = "U";
            }

            try
            {
                Checklist_ConfigID = Convert.ToInt32(ddlChecklist.SelectedValue);
                DepartmentID = Convert.ToInt32(ddlDepartment.SelectedValue);

                var rows = gvSelectedLocation.Rows;
                int count = gvSelectedLocation.Rows.Count;

                for (int i = 0; i < count; i++)
                {
                    string LocID = ((HiddenField)rows[i].FindControl("hdnLocID")).Value;
                    SelectedLocationID = SelectedLocationID + LocID + ",";
                }

                SelectedLocationID = SelectedLocationID.TrimEnd(',');

                dsChecklist = ObjUpkeep.Save_Checklist_Schedule_NEW(Chk_Map_ID,Checklist_ConfigID, DepartmentID, SelectedLocationID, LoggedInUserID, CompanyID,Action);

                if (dsChecklist.Tables.Count > 0)
                {
                    if (dsChecklist.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsChecklist.Tables[0].Rows[0]["Status"]);

                        if (Status == 1)
                        {
                            lblSuccessMsg.Text = "Checklist scheduling has been saved successfully";
                        }
                        else if (Status == 3)
                        {
                            lblError.Text = "Checklist scheduling with the department already exists.";
                        }

                        DataTable dtLocRows = new DataTable();
                        if (Convert.ToString(Session["LocRows"]) != "")
                        {
                            dtLocRows = (DataTable)Session["LocRows"];
                        }

                        gvSelectedLocation.DataSource = dtLocRows;
                        gvSelectedLocation.DataBind();

                        Session["LocRows"] = "";
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSelectLocation_Click(object sender, EventArgs e)
        {
            string SelectedLocationID = string.Empty;
            string SelectedLocationName = string.Empty;
            var rows = gvLocation.Rows;
            int count = gvLocation.Rows.Count;

            DataTable dtLocation = new DataTable("dtLocation");
            DataTable dtSelectedLocation = new DataTable("dtSelectedLocation");
            dtSelectedLocation.Columns.Add("Loc_Id", typeof(string));
            dtSelectedLocation.Columns.Add("Loc_Name", typeof(string));

            for (int i = 0; i < count; i++)
            {
                bool isChecked = ((CheckBox)rows[i].FindControl("chkLocationID")).Checked;
                if (isChecked)
                {
                    //string EmployeeID = gvEmployee.Rows[i].Cells[1].Text;
                    SelectedLocationName = ((HiddenField)rows[i].FindControl("hdnLocation_Name")).Value;

                    SelectedLocationID = ((HiddenField)rows[i].FindControl("hdnLocationID")).Value;

                    dtSelectedLocation.Rows.Add(SelectedLocationID, SelectedLocationName);
                }
            }
            mpeAddLocation.Hide();

            dtLocation.Merge(dtSelectedLocation);
            dtLocation.AcceptChanges();

            DataTable dtLocRows = new DataTable();
            if (Convert.ToString(Session["LocRows"]) != "")
            {
                dtLocRows = (DataTable)Session["LocRows"];
            }
            if (dtLocRows != null)
            {
                if (dtLocRows.Rows.Count > 0)
                {
                    dtLocation.Merge(dtLocRows);
                    dtLocation.AcceptChanges();
                }
            }
            //dtLocation = dtSelectedLocation;
            Session.Add("LocRows", dtLocation);

            gvSelectedLocation.DataSource = dtLocation;
            gvSelectedLocation.DataBind();

            Fetch_Location();
        }

        protected void gvLocation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //check if the row is the header row
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //add the thead and tbody section programatically
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void gvSelectedLocation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //check if the row is the header row
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //add the thead and tbody section programatically
                e.Row.TableSection = TableRowSection.TableHeader;
            }

            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != gvSelectedLocation.EditIndex)
            {
                (e.Row.Cells[1].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }

        protected void gvSelectedLocation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int LocID = 0;
            try
            {
                GridViewRow row = gvSelectedLocation.Rows[e.RowIndex];
                LocID = Convert.ToInt32(gvSelectedLocation.DataKeys[e.RowIndex].Values[0]);

                DataTable dtLocRows = (DataTable)Session["LocRows"];

                for (int i = dtLocRows.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = dtLocRows.Rows[i];
                    if (Convert.ToInt32(dr["Loc_Id"]) == LocID)
                        dr.Delete();
                }

                dtLocRows.AcceptChanges();

                Session.Add("LocRows", dtLocRows);

                gvSelectedLocation.DataSource = dtLocRows;
                gvSelectedLocation.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void fetchCHKMap(int Chk_Map_ID)
        {
            string SelectedLocationID = string.Empty;
            int Checklist_ConfigID = 0;
            int DepartmentID = 0;
            DataSet dsCHk = new DataSet();
            try
            {


                dsCHk = ObjUpkeep.Save_Checklist_Schedule_NEW(Chk_Map_ID,Checklist_ConfigID, DepartmentID, SelectedLocationID, LoggedInUserID, CompanyID, "R");

                if (dsCHk.Tables.Count > 0)
                {
                    if (dsCHk.Tables[0].Rows.Count > 0)
                    {
                        ddlChecklist.SelectedValue = Convert.ToString(dsCHk.Tables[0].Rows[0]["CHK_Config_ID"]);
                        ddlDepartment.SelectedValue = Convert.ToString(dsCHk.Tables[0].Rows[0]["Dept_ID"]);
                        Session["Chk_Map_ID"] = dsCHk.Tables[0].Rows[0]["Chk_Map_ID"];

                        Session.Add("LocRows", dsCHk.Tables[0]);

                        gvSelectedLocation.DataSource = dsCHk.Tables[0];
                        gvSelectedLocation.DataBind();


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


        public void DeleteCHKMap(int DelChk_Map_ID)
        {

            string SelectedLocationID = string.Empty;
            int Checklist_ConfigID = 0;
            int DepartmentID = 0;
            DataSet dsDCHk = new DataSet();
            try
            {
                dsDCHk = ObjUpkeep.Save_Checklist_Schedule_NEW(DelChk_Map_ID, Checklist_ConfigID, DepartmentID, SelectedLocationID, LoggedInUserID, CompanyID, "D");
                if (dsDCHk.Tables.Count > 0)
                {
                    if (dsDCHk.Tables[0].Rows.Count > 0)
                    {
                        Session["Chk_Map_ID"] = "";
                        //Response.Redirect("~/UserGrp_Mst.aspx", false);
                        Response.Redirect(Page.ResolveClientUrl("~/CheckList/Schedule_Checklist_Listing.aspx"), false);
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