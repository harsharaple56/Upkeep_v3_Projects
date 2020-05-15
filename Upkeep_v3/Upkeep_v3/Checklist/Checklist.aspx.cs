using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.Checklist
{
    public partial class Checklist : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            frmMain.Action = @"Checklist.aspx";
            if (LoggedInUserID == "")
            {
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
        }

        public string bindgrid()
        {
            string data = "";
            DateTime DtSchlddate;
            try
            {
                DtSchlddate = Convert.ToDateTime(System.DateTime.Now.ToString());

                //ds = ObjUpkeep.FrequencyMaster_CRUD(0, "", LoggedInUserID, "R");
                ds = ObjUpkeep.AddChecklistMaster_CRUD(0,"", 0, false, false, false, 0, DtSchlddate, "", "", 0, 0, 0, 0, 0, "", LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);
                        int Checklist_Id = 0;
                        string ChecklistName = string.Empty;
                        string DeptName = string.Empty;
                        string Zone = string.Empty;
                        string Location = string.Empty;
                        string CreatedOn = string.Empty;

                        for (int i = 0; i < count; i++)
                        {
                            Checklist_Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Chk_Id"]);
                            ChecklistName = Convert.ToString(ds.Tables[0].Rows[i]["Chk_Name"]);
                            DeptName = Convert.ToString(ds.Tables[0].Rows[i]["Dept_Desc"]);
                            Zone = Convert.ToString(ds.Tables[0].Rows[i]["Zone_Desc"]);
                            Location = Convert.ToString(ds.Tables[0].Rows[i]["Loc_Desc"]);
                            CreatedOn = Convert.ToString(ds.Tables[0].Rows[i]["Created_Date"]);
                            //data += "<tr><td>" + Frquency_Id + "</td><td>" + Frquency_Desc + "</td><td><a href='General_Masters/Add_Frequency.aspx?Frquency_Id=" + Frquency_Id + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  <a href='General_Masters/Add_Frequency.aspx?DelFreq_ID=" + Frquency_Id + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";
                            data += "<tr><td>" + ChecklistName + "</td><td>" + DeptName + "</td><td>" + Zone + "</td><td>" + Location + "</td><td>" + CreatedOn + "</td><td><a href='Edit_Checklist.aspx?ChecklstID=" + Checklist_Id + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  <a class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i id='btnedit' onclick='DeleteChecklist(" + Checklist_Id + ")' runat='server' class='la la-trash'></i> </a> </td></tr>";

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

        protected void btnAddChecklist_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Checklist/Add_Checklist.aspx"), false);
        }

        protected void btnDeleteChecklist_Click(object sender, EventArgs e)
        {
            DataSet dsAddChecklist = new DataSet();
            try
            {
                int ChecklistID = 0;
                DateTime DtSchlddate;

                Session["ChecklistID"]= Convert.ToString(hdnChecklstID.Value);

                if (Convert.ToString(Session["ChecklistID"]) != "")
                {
                    ChecklistID = Convert.ToInt32(Session["ChecklistID"]);
                }
                DtSchlddate = Convert.ToDateTime(System.DateTime.Now.ToString());

                dsAddChecklist = ObjUpkeep.AddChecklistMaster_CRUD(ChecklistID, "", 0, false, false, false, 0, DtSchlddate, "", "", 0, 0, 0, 0, 0, "", LoggedInUserID, "D");

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
                        
                        else if (Status == 2)
                        {
                            lblChecklstErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
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