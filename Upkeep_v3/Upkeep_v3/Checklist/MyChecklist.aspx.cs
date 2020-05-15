using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.Checklist
{
    public partial class MyChecklist : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            //bindgrid();
            frmMain.Action = @"MyChecklist.aspx";
            if (LoggedInUserID == "")
            {
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
        }

        public string bindgrid()
        {
            string data = "";
            DataSet dsTicket = new DataSet();
            try
            {
                dsTicket = ObjUpkeep.ChecklistRequest("", 0, 0, 0, 0, 0, "", "", LoggedInUserID, "L");

                int TicketID = 0;
                string TicketNumber = string.Empty;
                string ChecklistName = string.Empty;
                string ScheduleDate = string.Empty;
                string StartTime = string.Empty;
                string EndTime = string.Empty;
                string Requeststatus = string.Empty;
                string Status = string.Empty;
                string CompletedPercentage = string.Empty;
                string UserName = string.Empty;


                if (dsTicket.Tables.Count > 0)
                {
                    if (dsTicket.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(dsTicket.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            //TicketID = Convert.ToInt32(dsTicket.Tables[0].Rows[i]["Ticket_ID"]);
                            TicketNumber = Convert.ToString(dsTicket.Tables[0].Rows[i]["TicketId"]);
                            ChecklistName = Convert.ToString(dsTicket.Tables[0].Rows[i]["Chk_Name"]);
                            ScheduleDate = Convert.ToString(dsTicket.Tables[0].Rows[i]["ScheduleDate"]);
                            StartTime = Convert.ToString(dsTicket.Tables[0].Rows[i]["StartTime"]);
                            EndTime = Convert.ToString(dsTicket.Tables[0].Rows[i]["EndTime"]);
                            Requeststatus = Convert.ToString(dsTicket.Tables[0].Rows[i]["Requeststatus"]);
                            Status = Convert.ToString(dsTicket.Tables[0].Rows[i]["Status"]);
                            CompletedPercentage = Convert.ToString(dsTicket.Tables[0].Rows[i]["CompletedPercentage"]);
                            UserName = Convert.ToString(dsTicket.Tables[0].Rows[i]["UserName"]);

                            //data += "<tr><td>" + TicketNumber + "</td><td>" + Zone + "</td><td>" + Location + "</td><td>" + SubLocation + "</td><td>" + Category + "</td><td>" + SubCategory + "</td><td>" + RequestDate + "</td><td>" + RequestStatus + "</td><td>" + ActionStatus + "</td><td><a href='Add_MyRequest.aspx?TicketID=" + TicketID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>   </td></tr>";
                            data += "<tr><td> <a href='Checklist_Action.aspx?TicketNo=" + TicketNumber + "' style='text-decoration: underline;' > " + TicketNumber + " </a></td><td>" + ChecklistName + "</td><td>" + ScheduleDate + "</td><td>" + StartTime + "</td><td>" + EndTime + "</td><td>" + Requeststatus + "</td><td>" + Status + "</td><td>" + CompletedPercentage + "</td><td>" + UserName + "</td></tr>";

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