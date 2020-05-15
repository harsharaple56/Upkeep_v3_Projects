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

namespace Upkeep_v3.Feedback
{
    public partial class EventQuestions : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeepFeedback = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int EventID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                //Response.Redirect("~/Login.aspx", false);
            }
            EventID = Convert.ToInt32(Request.QueryString["EventID"]);
            Session["EventID"] = Convert.ToString(EventID);
        }

        public string fetchEventQuestions()
        {
            string data = "";
            try
            {
                // int EventID = Convert.ToInt32(Session["EventID"]);
                DataSet ds = new DataSet();
                ds = ObjUpkeepFeedback.Get_EventQuestions(EventID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        // lblEventName.Text = Convert.ToString(ds.Tables[0].Rows[0]["Event_Name"]);
                        for (int i = 0; i < count; i++)
                        {
                            //int EventID = Convert.ToInt32(ds.Tables[0].Rows[i]["Event_ID"]);
                            string EventName = Convert.ToString(ds.Tables[0].Rows[i]["Event_Name"]);
                            string Question_ID = Convert.ToString(ds.Tables[0].Rows[i]["Question_ID"]);
                            string Question = Convert.ToString(ds.Tables[0].Rows[i]["Question"]);
                            string Answer_Type = Convert.ToString(ds.Tables[0].Rows[i]["Answer_Type"]);
                            string CreatedOn = Convert.ToString(ds.Tables[0].Rows[i]["Created_Date"]);

                            //data += "<tr><td>" + EventName + "</td><td>" + Location + "</td><td>" + EventFor + "</td><td>" + CreatedOn + "</td><td>" + StartDate + "</td> <td>" + EndDate + "</td> <td><a href='EventDetails.aspx?EventID=" + EventID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record'> <i class='la la-edit'></i> </a> <a href='EventDetails.aspx?DelEventID=" + EventID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

                            data += "<tr><td>" + Question_ID + "</td><td>" + Question + "</td><td>" + Answer_Type + "</td><td>" + CreatedOn + "</td><td><a href='AddEventQuestion.aspx?QuestionID=" + Question_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit question'><i class='la la-edit'></i></a><a href='AddEventQuestion.aspx?DelQuestionID=" + Question_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete question'><i class='la la-trash'></i></a></td></tr>";
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