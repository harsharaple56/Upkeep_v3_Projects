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
    public partial class AddEventQuestion : System.Web.UI.Page
    {
        Upkeep_GP_WP_Services.Upkeep_GP_WP_Services ObjUpkeepFeedback = new Upkeep_GP_WP_Services.Upkeep_GP_WP_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        string ActionType = string.Empty;
        int QuestionID = 0;
        int EventID = 0;
        int DelQuestionID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
                //Response.Redirect("~/Login.aspx", false);
            }
            EventID = Convert.ToInt32(Session["EventID"]);
            QuestionID = Convert.ToInt32(Request.QueryString["QuestionID"]);
            DelQuestionID = Convert.ToInt32(Request.QueryString["DelQuestionID"]);

            if (!IsPostBack)
            {
                if (DelQuestionID > 0)
                {
                    DeleteEventQuestion(DelQuestionID);
                }

                if (QuestionID > 0)
                {
                    bindEventQuestion(QuestionID);
                }
            }
        }

        public void SaveData(string ActionType)
        {
            string CustomerQuestion = string.Empty;
            string AnswerType = string.Empty;
            string RetailerQuestion = string.Empty;
            string RetQuesType = string.Empty;

            string opt1 = string.Empty;
            string opt2 = string.Empty;
            string opt3 = string.Empty;
            string opt4 = string.Empty;

            CustomerQuestion = question.Text.Trim();

            AnswerType = type.SelectedItem.Text;
            opt1 = option1.Text.Trim();
            opt2 = option2.Text.Trim();
            opt3 = option3.Text.Trim();
            opt4 = option4.Text.Trim();

            DataSet ds = new DataSet();
            ds = ObjUpkeepFeedback.Event_QuestionIU(EventID, CustomerQuestion, AnswerType, opt1, opt2, opt3, opt4, LoggedInUserID, QuestionID, ActionType);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Response.Redirect(Page.ResolveClientUrl("~/Feedback/EventQuestions.aspx?EventID=" + EventID + ""), false);
                    //Response.Redirect("~/EventQuestions.aspx?EventID=" + EventID + "", false);
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ActionType = "Insert";
            SaveData(ActionType);
        }

        public void bindEventQuestion(int QuestionID)
        {
            ActionType = "Select";
            DataSet ds = new DataSet();
            ds = ObjUpkeepFeedback.Event_QuestionIU(EventID, "", "", "", "", "", "", LoggedInUserID, QuestionID, ActionType);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    question.Text = Convert.ToString(ds.Tables[0].Rows[0]["Question"]);

                    string strAnsType = Convert.ToString(ds.Tables[0].Rows[0]["Answer_Type"]);
                    if (strAnsType == "Emoji")
                    {
                        type.SelectedValue = "1";
                    }
                    else if (strAnsType == "Text")
                    {
                        type.SelectedValue = "2";
                    }
                    else if (strAnsType == "Options")
                    {
                        type.SelectedValue = "3";
                    }
                    //type.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["Answer_Type"]);
                    string OptionType = Convert.ToString(ds.Tables[0].Rows[0]["Answer_Type"]);
                    if (OptionType == "Options")
                    {
                        options_group.Attributes.Add("style", "display:block");
                        option1.Text = Convert.ToString(ds.Tables[0].Rows[0]["Option1"]);
                        option2.Text = Convert.ToString(ds.Tables[0].Rows[0]["Option2"]);
                        option3.Text = Convert.ToString(ds.Tables[0].Rows[0]["Option3"]);
                        option4.Text = Convert.ToString(ds.Tables[0].Rows[0]["Option4"]);
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

        public void DeleteEventQuestion(int DelQuestionID)
        {
            DataSet ds = new DataSet();
            ds = ObjUpkeepFeedback.Event_QuestionIU(EventID, "", "", "", "", "", "", LoggedInUserID, DelQuestionID, "Delete");

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Response.Redirect(Page.ResolveClientUrl("~/Feedback/EventQuestions.aspx?EventID=" + EventID + ""), false);
                    //Response.Redirect("~/EventQuestions.aspx?EventID=" + EventID + "", false);
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
    }
}