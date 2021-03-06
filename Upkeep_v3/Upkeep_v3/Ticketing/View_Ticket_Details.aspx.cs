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
    public partial class View_Ticket_Details : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        int TicketID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            TicketID = Convert.ToInt32(Request.QueryString["TicketID"]);

            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }

            if (!IsPostBack)
            {
                Bind_Ticket_Details();
            }
        }

        public void Bind_Ticket_Details()
        {
            DataSet dsTicket = new DataSet();
            try
            {
                dsTicket = ObjUpkeep.Bind_Ticket_Details(TicketID, CompanyID);

                if (dsTicket.Tables.Count > 0)
                {
                    if (dsTicket.Tables[0].Rows.Count > 0)
                    {
                        lblTicketNo.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["Tkt_Code"]);
                        lblRequestDate.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["Ticket_Date"]);
                        lblTicketRaisedBy.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["Ticket_RaisedBy"]);
                        lblTicketRaisedBy_MobileNo.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["RaisedBy_MobileNo"]);
                        lblTicketRaisedBy_EmailID.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["RaisedBy_EmailID"]);
                        lblLocation.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["Loc_Desc"]);
                        lblCategory.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["Category_Desc"]);
                        lblSubCategory.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["SubCategory_Desc"]);
                        lblTicketdesc.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["Tkt_Message"]);

                        rptTicketImage.DataSource = dsTicket.Tables[0];
                        rptTicketImage.DataBind();

                        rptTicketClosingImage.DataSource = dsTicket.Tables[0];
                        rptTicketClosingImage.DataBind();

                        lblAssignedDept.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["Dept_Desc"]);
                        lblCurrentLevel.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["CurrentLevel"]);
                        lblActionStatus.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["Tkt_ActionStatus"]);
                        lblTicketStatus.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["Tkt_Status"]);

                        lblRaisedImageCount.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["TicketRaised_Image_Count"]);
                        lblClosedImageCount.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["TicketClosed_Image_Count"]);

                        int SubCategoryID = 0;
                        int CategoryID = 0;
                        CategoryID = Convert.ToInt32(dsTicket.Tables[0].Rows[0]["Category_ID"]);
                        SubCategoryID = Convert.ToInt32(dsTicket.Tables[0].Rows[0]["SubCategory_ID"]);
                        BindWorkflow(CategoryID, SubCategoryID);
                        lblDowntime.Text = Convert.ToString(Session["Downtime"]);

                        //force close
                        int Is_Force_Close = 0;
                        Is_Force_Close = Convert.ToInt32(dsTicket.Tables[0].Rows[0]["Is_Force_Close"]);
                        if (Is_Force_Close > 0)
                        {
                            lbl_force_close_by.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["Force_Close_By_user"]);
                            lbl_force_close_date.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["Force_Closed_Date"]);
                            lbl_force_close_remarks.Text = Convert.ToString(dsTicket.Tables[0].Rows[0]["Force_Closed_Remarks"]);
                        }
                        else
                        {
                            dv_force_close.Attributes.Add("style", "display:none;");
                        }

                    }

                    if (dsTicket.Tables.Count > 1)
                    {
                        if (dsTicket.Tables[1].Rows.Count > 0)
                        {
                            gvActionHistory.DataSource = dsTicket.Tables[1];
                            gvActionHistory.DataBind();
                        }
                        else
                        {
                            gvActionHistory.DataSource = null;
                            gvActionHistory.DataBind();
                        }
                    }

                    if (dsTicket.Tables.Count > 2)
                    {
                        if (dsTicket.Tables[2].Rows.Count > 0)
                        {
                            gvCustomField.DataSource = dsTicket.Tables[2];
                            gvCustomField.DataBind();
                        }
                        else
                        {
                            dv_Custom_Field.Attributes.Add("style", "display:none;");
                            gvCustomField.DataSource = null;
                            gvCustomField.DataBind();
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindWorkflow(int CategoryID, int SubCategoryID)
        {
            DataSet dsWorkflow = new DataSet();
            try
            {
                string TicketPrefix = string.Empty;
                TicketPrefix = Convert.ToString(ConfigurationManager.AppSettings["TicketPrefix"]);
                dsWorkflow = ObjUpkeep.Fetch_Ticket_Workflow(CompanyID, CategoryID, SubCategoryID, TicketPrefix, LoggedInUserID);

                if (dsWorkflow.Tables.Count > 0)
                {
                    if (dsWorkflow.Tables[0].Rows.Count > 0)
                    {
                        gvWorkflow.DataSource = dsWorkflow;
                        gvWorkflow.DataBind();
                    }
                    else
                    {
                        gvWorkflow.DataSource = null;
                        gvWorkflow.DataBind();
                    }
                }
                else
                {                   
                    gvWorkflow.DataSource = null;
                    gvWorkflow.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnViewWorkflow_Click(object sender, EventArgs e)
        {

        }
    }
}