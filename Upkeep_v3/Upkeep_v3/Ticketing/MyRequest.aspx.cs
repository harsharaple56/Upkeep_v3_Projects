using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.Ticketing
{
    public partial class MyRequest : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            // Session["User"] = Session["User"];  //Sam
            //bindgrid();
            //frmMain.Action = @"General_Masters/Frequency_Master.aspx";
            //frmMain.Action = @"MyRequest.aspx";
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
                dsTicket = ObjUpkeep.Insert_Ticket_Details("", CompanyID, 0, 0, 0, "", "","", LoggedInUserID, "R");

                int TicketID = 0;
                string TicketNumber = string.Empty;
                string Zone = string.Empty;
                string Location = string.Empty;
                string SubLocation = string.Empty;
                string Category = string.Empty;
                string SubCategory = string.Empty;
                string RequestDate = string.Empty;
                string RequestStatus = string.Empty;
                string ActionStatus = string.Empty;
                string RaisedBy = string.Empty;
                string Down_Time = string.Empty;

                if (dsTicket.Tables.Count > 0)
                {
                    if (dsTicket.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(dsTicket.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                             TicketID = Convert.ToInt32(dsTicket.Tables[0].Rows[i]["Ticket_ID"]);
                            TicketNumber = Convert.ToString(dsTicket.Tables[0].Rows[i]["Tkt_Code"]);
                            //Zone = Convert.ToString(dsTicket.Tables[0].Rows[i]["Zone_Desc"]);
                            Location = Convert.ToString(dsTicket.Tables[0].Rows[i]["Loc_Desc"]);
                            //SubLocation = Convert.ToString(dsTicket.Tables[0].Rows[i]["SubLoc_Desc"]);
                            Category = Convert.ToString(dsTicket.Tables[0].Rows[i]["Category_Desc"]);
                            SubCategory = Convert.ToString(dsTicket.Tables[0].Rows[i]["SubCategory_Desc"]);                      
                            RequestDate = Convert.ToString(dsTicket.Tables[0].Rows[i]["Ticket_Date"]);
                            RaisedBy = Convert.ToString(dsTicket.Tables[0].Rows[i]["RaisedBy"]);
                            RequestStatus = Convert.ToString(dsTicket.Tables[0].Rows[i]["Tkt_Status"]);
                            ActionStatus = Convert.ToString(dsTicket.Tables[0].Rows[i]["Tkt_ActionStatus"]);

                            Down_Time = Convert.ToString(dsTicket.Tables[0].Rows[i]["Down_Time"]);

                            //data += "<tr><td>" + TicketNumber + "</td><td>" + Zone + "</td><td>" + Location + "</td><td>" + SubLocation + "</td><td>" + Category + "</td><td>" + SubCategory + "</td><td>" + RequestDate + "</td><td>" + RequestStatus + "</td><td>" + ActionStatus + "</td><td><a href='Add_MyRequest.aspx?TicketID=" + TicketID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>   </td></tr>";
                            data += "<tr><td> <a href='My_RequestRply.aspx?TicketID=" + TicketID + "&MyRequest=1 ' style='text-decoration: underline;' > " + TicketNumber + " </a></td><td>" + Location + "</td><td>" + Category + "</td><td>" + SubCategory + "</td><td>" + RequestDate + "</td><td>" + RaisedBy + "</td><td>" + Down_Time + "</td><td>" + RequestStatus + "</td><td>" + ActionStatus + "</td></tr>";

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