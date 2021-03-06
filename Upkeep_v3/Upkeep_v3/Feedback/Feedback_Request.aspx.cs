using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Configuration;
using System.Web.Script.Serialization;

namespace Upkeep_v3.Feedback
{
    public partial class Feedback_Request : System.Web.UI.Page
    {
        #region Global variables
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        string SessionVisitor = string.Empty;
        DataSet dsConfig = new DataSet();
        int CompanyID = 0;
        int EventID = 0;
        protected string Values;
        #endregion

        #region Event 

        void Page_PreInit(Object sender, EventArgs e)
        {
            if (!System.String.IsNullOrWhiteSpace(Request.QueryString["EventID"]))
            {
                this.MasterPageFile = "~/BlankMaster.master";
            }
            else
            {
                this.MasterPageFile = "~/UpkeepMaster.master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //LoggedInUserID = "admin";
            //LoggedInUserID = "121";
            string strEventID = string.Empty;
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            SessionVisitor = Convert.ToString(Session["Visitor"]);
            dv_Feedback.Visible = false;
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(LoggedInUserID) && string.IsNullOrEmpty(SessionVisitor))
                {
                    Response.Redirect("~/Login.aspx", false);
                    return;
                }
                else if (string.IsNullOrEmpty(LoggedInUserID) && !string.IsNullOrEmpty(SessionVisitor))
                {
                    divTitle.Visible = false;
                    if (!System.String.IsNullOrWhiteSpace(Request.QueryString["EventID"]))
                    {
                        strEventID = Request.QueryString["EventID"].ToString();
                        if (strEventID.All(char.IsDigit))
                        {
                            ViewState["EventID"] = Convert.ToInt32(strEventID);
                        }

                        BindEvent();

                    }
                }

                else if (!string.IsNullOrEmpty(LoggedInUserID) && string.IsNullOrEmpty(SessionVisitor))
                {

                    divCustomer.Visible = false;
                }

                BindFeedbackEventTitle();
            }

            //if (!System.String.IsNullOrWhiteSpace(Request.QueryString["WPEventID"]))
            //{
            //    strWPEventID = Request.QueryString["WPEventID"].ToString();
            //        WP_EventID = Convert.ToInt32(strWPEventID);
            //}

        }

        protected void ddlFeedbackTitle_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                //lblRequestDate.Text = DateTime.Now.ToString("dd/MMM/yyyy hh:mm tt");

                ViewState["EventID"] = Convert.ToInt32(ddlFeedbackTitle.SelectedValue);



                BindEvent();



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void rptHeaderDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Reference the Repeater Item.
                RepeaterItem item = e.Item;

                String AnswerType = (e.Item.FindControl("hdnlblAnswerType") as HiddenField).Value;
                string HeadId = (e.Item.FindControl("hfHeaderId") as HiddenField).Value;

                if (AnswerType == "Options") //Single Selection [Radio Button]
                {
                    HtmlGenericControl sample = e.Item.FindControl("divOptions") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == "Star") //Star Rating
                {
                    HtmlGenericControl sample = e.Item.FindControl("divStar") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == "NPS") //NPS Scoring
                {
                    HtmlGenericControl sample = e.Item.FindControl("divNPS") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == "Emoji") //emoji 
                {
                    HtmlGenericControl sample = e.Item.FindControl("divEmoji") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == "Text") // Textarea Field
                {
                    HtmlGenericControl sample = e.Item.FindControl("divTextArea") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else  //Normal Text Field
                {
                    HtmlGenericControl sample = e.Item.FindControl("divText") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }


                //Repeater rptRadio = e.Item.FindControl("rptRadio") as Repeater;

                DataSet dsFeedbackHeader = new DataSet();
                dsFeedbackHeader = dsConfig.Copy(); //ObjUpkeep.Bind_FeedbackConfiguration(sPublicEventID);

                DataTable dt = new DataTable();
                dt = dsFeedbackHeader.Tables[0].Copy();
                dt.DefaultView.RowFilter = "Question_ID = " + Convert.ToString(HeadId) + "";
                dt = dt.DefaultView.ToTable();

                if (AnswerType == "Options")
                {
                    RadioButtonList divRadioButtonrdbYes = e.Item.FindControl("divRadioButtonrdbYes") as RadioButtonList;
                    if (dt.Rows.Count > 0)
                    {
                        divRadioButtonrdbYes.Items.Add(new ListItem(dt.Rows[0]["Option1"].ToString(), "1"));
                        divRadioButtonrdbYes.Items.Add(new ListItem(dt.Rows[0]["Option2"].ToString(), "2"));
                        divRadioButtonrdbYes.Items.Add(new ListItem(dt.Rows[0]["Option3"].ToString(), "3"));
                        divRadioButtonrdbYes.Items.Add(new ListItem(dt.Rows[0]["Option4"].ToString(), "4"));
                    }
                    else
                    {
                        DataTable dt1 = new DataTable();
                        divRadioButtonrdbYes.DataSource = dt;
                        divRadioButtonrdbYes.DataBind();
                    }

                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string WpTitleSelectedID = "";
            WpTitleSelectedID = ddlFeedbackTitle.SelectedValue;

            SaveFeedbackData();
        }

        #endregion

        #region Function

        public void BindFeedbackEventTitle()
        {
            DataSet dsTitle = new DataSet();
            string Initiator = string.Empty;
            try
            {
                Initiator = Convert.ToString(Session["UserType"]);
                dsTitle = ObjUpkeep.GetEventList(CompanyID, "R");
                if (dsTitle.Tables.Count > 0)
                {
                    if (dsTitle.Tables[0].Rows.Count > 0)
                    {
                        ddlFeedbackTitle.DataSource = dsTitle.Tables[0];
                        ddlFeedbackTitle.DataTextField = "Event_Name";
                        ddlFeedbackTitle.DataValueField = "Event_ID";
                        ddlFeedbackTitle.DataBind();
                        ddlFeedbackTitle.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void SaveFeedbackData()
        {
            try
            {
                #region UserData
                int EventID = Convert.ToInt32(ViewState["EventID"]);
                string LoggedInUser = LoggedInUserID;
                string strFname = Fname.Text;
                string strLname = Lname.Text;
                string strPhone = Phoneno.Text;
                string strEmailID = EmailID.Text;
                string strGender = string.Empty;
                if (rdbMale.Checked == true)
                { strGender = "Male"; }
                if (rdbFemale.Checked == true)
                { strGender = "Female"; }
                if (rdbOther.Checked == true)
                { strGender = "Other"; }


                lblFeedbackError.Text = "";

                #endregion


                #region FeedbackQuestion
                /*
                 Create table and store data in table and convert later in xml and pass in to Datatbase..
                 Table Structure :  QuestionID | AnswerID | Data
                */

                string strFeedbackData = "";

                DataTable dt = new DataTable();
                dt.Clear();
                dt.TableName = "TableFeedbackQuestion";
                dt.Columns.Add("QuestionID");
                dt.Columns.Add("AnswerID");
                dt.Columns.Add("Data");
                dt.Columns.Add("NegativeFeedback");
                // dtRow["SectionID"] = ""; dtRow["QuestionID"] = ""; dtRow["AnswerID"] = ""; dtRow["Data"] = ""; 

                string Is_Not_Valid = "False";


                foreach (RepeaterItem itemQuestion in rptHeaderDetails.Items)
                {

                    string AnswerType = (itemQuestion.FindControl("hdnlblAnswerType") as HiddenField).Value;
                    //string Is_Mandatory = Convert.ToString((itemQuestion.FindControl("hdnIs_Mandatory") as HiddenField).Value);
                    Label lblQuestionErr = (itemQuestion.FindControl("lblQuestionErr") as Label);
                    string isField = "False";

                    // int AnswerTypeData = Convert.ToInt32((itemQuestion.FindControl("hdnlblAnswerTypeData") as HiddenField).Value);
                    string HeadId = (itemQuestion.FindControl("hfHeaderId") as HiddenField).Value;

                    if (AnswerType == "Options") //Multi Selection [CheckBox]
                    {

                        RadioButtonList divRadioButtonrdbYes = itemQuestion.FindControl("divRadioButtonrdbYes") as RadioButtonList;
                        List<String> RadioStrList = new List<string>();
                        foreach (ListItem item in divRadioButtonrdbYes.Items)
                        {
                            if (item.Selected)
                            {
                                isField = "True";

                                RadioStrList.Add(item.Value);
                                DataRow dtRow = dt.NewRow();
                                dtRow["QuestionID"] = HeadId;
                                dtRow["AnswerID"] = AnswerType;
                                dtRow["Data"] = item.Value;
                                dtRow["NegativeFeedback"] = string.Empty;
                                dt.Rows.Add(dtRow);
                            }
                        }

                    }

                    else if (AnswerType == "Star") //Star Rating 
                    {

                        HtmlGenericControl sample = itemQuestion.FindControl("divStar") as HtmlGenericControl;
                        string txtNum = sample.Controls[1].UniqueID;
                        string sVal = Request.Form.GetValues(txtNum)[0];

                        #region Fetch Feedback from textbox
                        string feedbackdesc = string.Empty;
                        string getTextBoxID = itemQuestion.FindControl("divStar").ClientID.Split('_')[3];
                        string setTextBoxID = "StarTextBox_" + getTextBoxID;
                        string[] textboxValues = Request.Form.GetValues(setTextBoxID);
                        if (textboxValues != null)
                        {
                            JavaScriptSerializer serializer = new JavaScriptSerializer();
                            this.Values = serializer.Serialize(textboxValues);
                            foreach (string textboxValue in textboxValues)
                            {
                                feedbackdesc = textboxValue;
                            }
                        }
                        #endregion

                        DataRow dtRow = dt.NewRow();
                        dtRow["QuestionID"] = HeadId;
                        dtRow["AnswerID"] = AnswerType;
                        dtRow["Data"] = sVal;
                        dtRow["NegativeFeedback"] = feedbackdesc;
                        dt.Rows.Add(dtRow);



                    }
                    else if (AnswerType == "NPS") //NPS SCORING
                    {
                        HtmlGenericControl sample = itemQuestion.FindControl("divNPS") as HtmlGenericControl;
                        string txtNum = sample.Controls[1].UniqueID;
                        string sVal = Request.Form.GetValues(txtNum)[0];
                        DataRow dtRow = dt.NewRow();
                        dtRow["QuestionID"] = HeadId;
                        dtRow["AnswerID"] = AnswerType;
                        dtRow["Data"] = sVal;
                        dtRow["NegativeFeedback"] = string.Empty;
                        dt.Rows.Add(dtRow);


                    }
                    else if (AnswerType == "Emoji") //Emoji Rating
                    {
                        HtmlGenericControl sample = itemQuestion.FindControl("divEmoji") as HtmlGenericControl;
                        string txtNum = sample.Controls[1].UniqueID;
                        string sVal = Request.Form.GetValues(txtNum)[0];

                        #region Fetch Feedback from textbox
                        string feedbackdesc = string.Empty;
                        string getTextBoxID = itemQuestion.FindControl("divEmoji").ClientID.Split('_')[3];
                        string setTextBoxID = "DynamicTextBox_" + getTextBoxID;
                        string[] textboxValues = Request.Form.GetValues(setTextBoxID);
                        if (textboxValues != null)
                        {
                            JavaScriptSerializer serializer = new JavaScriptSerializer();
                            this.Values = serializer.Serialize(textboxValues);
                            foreach (string textboxValue in textboxValues)
                            {
                                feedbackdesc = textboxValue;
                            }
                        }
                        #endregion


                        if (sVal == "")
                        {
                            lblFeedbackError.Text = "Kindly fill all the feedback";
                            BindEvent();
                            return;
                        }


                        DataRow dtRow = dt.NewRow();
                        dtRow["QuestionID"] = HeadId;
                        dtRow["AnswerID"] = AnswerType;
                        dtRow["Data"] = sVal;
                        dtRow["NegativeFeedback"] = feedbackdesc;
                        dt.Rows.Add(dtRow);



                        //if (Is_Mandatory == "*")
                        //{
                        //    if (isField == "False")
                        //    {
                        //        Is_Not_Valid = "True";
                        //        lblQuestionErr.Text = "Please provide valid data.";
                        //    }
                        //}
                    }
                    else  //Normal Text Field
                    {
                        HtmlGenericControl sample = itemQuestion.FindControl("divTextArea") as HtmlGenericControl;
                        string txtNum = sample.Controls[1].UniqueID;
                        string sVal = Request.Form.GetValues(txtNum)[0];
                        DataRow dtRow = dt.NewRow();
                        dtRow["QuestionID"] = HeadId;
                        dtRow["AnswerID"] = AnswerType;
                        dtRow["Data"] = sVal;
                        dtRow["NegativeFeedback"] = string.Empty;
                        dt.Rows.Add(dtRow);


                        //    if (Is_Mandatory == "*")
                        //    {
                        //        if (isField == "False")
                        //        {
                        //            Is_Not_Valid = "True";
                        //            lblQuestionErr.Text = "Please provide valid data.";
                        //        }
                        //    }
                    }
                }



                if (Is_Not_Valid == "True")
                {
                    return;
                }

                if (dt.Rows.Count > 0)
                {
                    DataTable DTS = new DataTable();
                    DTS = dt.Copy();

                    MemoryStream str = new MemoryStream();
                    DTS.WriteXml(str, true);
                    str.Seek(0, SeekOrigin.Begin);
                    StreamReader sr = new StreamReader(str);
                    string xmlstr;
                    xmlstr = sr.ReadToEnd();
                    strFeedbackData = xmlstr;
                }
                #endregion


                #region SaveDataToDB
                DataSet dsFeedbackQuestionData = new DataSet();

                if (!string.IsNullOrEmpty(SessionVisitor))
                {

                }

                Random random = new Random();
                string FeedbackNo = string.Empty;
                FeedbackNo = random.Next(0, 999999999).ToString("D9");

                dsFeedbackQuestionData = ObjUpkeep.Insert_FeedbackForm(CompanyID, EventID, strFname, strLname, strPhone, strGender, strEmailID, strFeedbackData, FeedbackNo, LoggedInUserID);

                if (dsFeedbackQuestionData.Tables.Count > 0)
                {
                    if (dsFeedbackQuestionData.Tables[0].Rows.Count > 0)
                    {
                        int status = Convert.ToInt32(dsFeedbackQuestionData.Tables[0].Rows[0]["Status"]);
                        if (status == 1)
                        {
                            //SetRepeater();
                            //divStatus.Visible = true;
                            //lblStatus.Text = "Save Successfully..!";

                            //divinsertbutton.visible = false;
                            //lblFeedbackRequestCode.Text = Convert.ToString(dsFeedbackQuestionData.Tables[0].Rows[0]["requestid"]);

                            Response.Write(@"
                                                 <script>
                                                    alert('Thanks for your valuable time, Your feedback helps us to serve you better.');
                                                    window.location = '" + Request.RawUrl + @"';
                                                </script>
                                            ");

                            BindEvent();

                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "callSaveAlert();", true);

                            //mpeFeedbackRequestSaveSuccess.Show();
                            //Response.Redirect("~/Dashboard.aspx");
                        }
                        else
                        {
                            SetRepeater();
                            divStatus.Visible = true;
                            lblStatus.Text = "Error Occured..!";

                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetRepeater()
        {
            foreach (RepeaterItem itemQuestion in rptHeaderDetails.Items)
            {
                String AnswerType = (itemQuestion.FindControl("hdnlblAnswerType") as HiddenField).Value;
                string HeadId = (itemQuestion.FindControl("hfHeaderId") as HiddenField).Value;

                if (AnswerType == "Options") //Single Selection [Radio Button]
                {
                    HtmlGenericControl sample = itemQuestion.FindControl("divOptions") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == "Star") //Star Rating
                {
                    HtmlGenericControl sample = itemQuestion.FindControl("divStar") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == "NPS") //NPS Scoring
                {
                    HtmlGenericControl sample = itemQuestion.FindControl("divNPS") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == "Emoji") //emoji 
                {
                    HtmlGenericControl sample = itemQuestion.FindControl("divEmoji") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == "Text") // Textarea Field
                {
                    HtmlGenericControl sample = itemQuestion.FindControl("divTextArea") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else  //Normal Text Field
                {
                    HtmlGenericControl sample = itemQuestion.FindControl("divText") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }

            }

        }


        private void BindEvent()
        {
            try
            {
                //lblRequestDate.Text = DateTime.Now.ToString("dd/MMM/yyyy hh:mm tt");

                EventID = Convert.ToInt32(ViewState["EventID"]);
                dsConfig = ObjUpkeep.bindEventDetails(CompanyID, EventID);
                if (dsConfig.Tables[0].Rows.Count > 0)
                    dv_Feedback.Visible = true;
                else
                    dv_Feedback.Visible = false;
                rptHeaderDetails.DataSource = dsConfig.Tables[0];
                rptHeaderDetails.DataBind();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        protected void btntest1_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "callSaveAlert();", false);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "callSaveAlert();", true);
        }
    }
}