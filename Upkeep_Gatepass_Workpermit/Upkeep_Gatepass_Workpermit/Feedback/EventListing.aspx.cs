using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Globalization;
using System.IO;

namespace Upkeep_Gatepass_Workpermit.Feedback
{
    public partial class EventListing : System.Web.UI.Page
    {
        Upkeep_GP_WP_Services.Upkeep_GP_WP_Services ObjUpkeepFeedback = new Upkeep_GP_WP_Services.Upkeep_GP_WP_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            //frmMain.Action = @"EventListing.aspx";
            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                //Response.Redirect("~/Login.aspx", false);
            }
        }

        public string fetchEventListing()
        {
            string data = "";
            try
            {
                DataSet ds = new DataSet();
                ds = ObjUpkeepFeedback.EventDetails_CRUD(0, "Select");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int EventID = Convert.ToInt32(ds.Tables[0].Rows[i]["Event_ID"]);
                            string EventName = Convert.ToString(ds.Tables[0].Rows[i]["Event_Name"]);
                            string Location = Convert.ToString(ds.Tables[0].Rows[i]["Location"]);
                            string EventFor = Convert.ToString(ds.Tables[0].Rows[i]["EventFor"]);
                            string CreatedOn = Convert.ToString(ds.Tables[0].Rows[i]["Created_Date"]);
                            string StartDate = Convert.ToString(ds.Tables[0].Rows[i]["Start_Date"]);
                            string EndDate = Convert.ToString(ds.Tables[0].Rows[i]["Expiry_Date"]);

                            data += "<tr><td>" + EventName + "</td><td>" + Location + "</td><td>" + EventFor + "</td><td>" + CreatedOn + "</td><td>" + StartDate + "</td> <td>" + EndDate + "</td> <td><a href='EditEvent.aspx?EventID=" + EventID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record'> <i class='la la-edit'></i> </a> <a href='EventQuestions.aspx?EventID=" + EventID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='View question list'><i class='la la-th-list'></i></a> <a href='EditEvent.aspx?DelEventID=" + EventID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

                        }

                    }
                    else
                    {
                        //invalid login
                    }
                }
                else
                {
                    //invalid login
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