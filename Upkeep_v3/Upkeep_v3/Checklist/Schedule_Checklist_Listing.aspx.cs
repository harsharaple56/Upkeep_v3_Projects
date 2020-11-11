using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.CheckList
{
    public partial class Schedule_Checklist_Listing : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            //frmMain.Action = @"Workflow_Master.aspx";
            if (LoggedInUserID == "")
            {
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }

            if (!IsPostBack)
            {
                
            }
        }

        public string bindScheduleChecklist()
        {
            DataSet dsChecklist = new DataSet();
            string data = "";
            try
            {
                //Spr_Fetch_Checklist_Schedule
                dsChecklist = ObjUpkeep.Schedule_Checklist_CRUD(CompanyID);

                if (dsChecklist.Tables.Count > 0)
                {
                    if (dsChecklist.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(dsChecklist.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Chk_Map_ID = Convert.ToInt32(dsChecklist.Tables[0].Rows[i]["Chk_Map_ID"]);
                            string Chk_Desc = Convert.ToString(dsChecklist.Tables[0].Rows[i]["Chk_Title"]);
                            string Dept_Desc = Convert.ToString(dsChecklist.Tables[0].Rows[i]["Dept_Desc"]);
                            string Location_Count = Convert.ToString(dsChecklist.Tables[0].Rows[i]["LocationCount"]);

                            data += "<tr><td>" + Chk_Desc + "</td><td>" + Dept_Desc + "</td><td>" + Location_Count + "</td><td><a href='Schedule_Checklist.aspx?EditMapId=" + Chk_Map_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  <a href='Schedule_Checklist.aspx?DelMapID=" + Chk_Map_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

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



        
    }
}