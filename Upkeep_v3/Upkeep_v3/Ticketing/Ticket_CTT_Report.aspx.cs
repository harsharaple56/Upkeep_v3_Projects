using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Text;
using System.IO;

namespace Upkeep_v3.Ticketing
{
    public partial class Ticket_CTT_Report : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }

            if (!IsPostBack)
            {
                Fetch_CTT_Report();
            }
        }

        public void Fetch_CTT_Report()
        {
            DataSet dsCTT = new DataSet();
            try
            {
                dsCTT = ObjUpkeep.Fetch_CTT_Report(CompanyID);

                if (dsCTT.Tables.Count > 0)
                {
                    if (dsCTT.Tables[0].Rows.Count > 0)
                    {
                        gvCTT_Report.DataSource = dsCTT;
                        gvCTT_Report.DataBind();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvCTT_Report_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //check if the row is the header row
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //add the thead and tbody section programatically
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {

        }

        protected void gvCTT_Report_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewTicket")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = gvCTT_Report.Rows[rowIndex];

                string TicketID = ((HiddenField)row.FindControl("hdnTicketID")).Value;

                Response.Redirect(Page.ResolveClientUrl("~/Ticketing/View_Ticket_Details.aspx?TicketID=" + TicketID), false);
            }
        }
    }
}