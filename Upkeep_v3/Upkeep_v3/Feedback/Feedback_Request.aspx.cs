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

namespace Upkeep_v3.Feedback
{
    public partial class Feedback_Request : System.Web.UI.Page
    {
        #region Global variables
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        DataSet dsConfig = new DataSet();
        int CompanyID = 0;
        #endregion

        #region Event 

        protected void Page_Load(object sender, EventArgs e)
        {
            //LoggedInUserID = "admin";
            //LoggedInUserID = "121";
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                //Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            if (!IsPostBack)
            {
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
            int ConfigTitleID = 0;

            try
            {
                //lblRequestDate.Text = DateTime.Now.ToString("dd/MMM/yyyy hh:mm tt");

                ConfigTitleID = Convert.ToInt32(ddlFeedbackTitle.SelectedValue);


                dsConfig = ObjUpkeep.bindEventDetails(CompanyID, ConfigTitleID);

                rptHeaderDetails.DataSource = dsConfig.Tables[0];
                rptHeaderDetails.DataBind();


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

                if (AnswerType == "Option1")
                {
                    RadioButtonList divRadioButtonrdbYes = e.Item.FindControl("divRadioButtonrdbYes") as RadioButtonList;

                    if (dt.Rows.Count > 0)
                    {
                        //rptRadio.DataSource = dt;
                        //rptRadio.DataBind(); 
                        divRadioButtonrdbYes.DataTextField = "Ans_Type_Data"; // "Ans_Type_Desc";
                        divRadioButtonrdbYes.DataValueField = "Ans_Type_Data_ID";  // "Ans_Type_ID";// 
                        divRadioButtonrdbYes.DataSource = dt;
                        divRadioButtonrdbYes.DataBind();
                    }
                    else
                    {
                        DataTable dt1 = new DataTable();
                        //rptRadio.DataSource = dt1;
                        //rptRadio.DataBind();
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
                dsTitle = ObjUpkeep.GetEventList(CompanyID,"*");
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
                int EventID = Convert.ToInt32(ddlFeedbackTitle.SelectedValue.ToString());
                string LoggedInUser = LoggedInUserID;
                 
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
                        CheckBoxList divCheckBoxIDI = itemQuestion.FindControl("divCheckBoxIDI") as CheckBoxList;
                        List<String> chkStrList = new List<string>();


                        foreach (ListItem item in divCheckBoxIDI.Items)
                        {
                            if (item.Selected)
                            {
                                isField = "True";

                                chkStrList.Add(item.Value);
                                DataRow dtRow = dt.NewRow();
                                dtRow["QuestionID"] = HeadId;
                                dtRow["AnswerID"] = AnswerType;
                                dtRow["Data"] = item.Value;
                                dt.Rows.Add(dtRow);
                            }
                        }

                        //if (Is_Mandatory == "*")
                        //{
                        //    if (isField == "False")
                        //    {
                        //        Is_Not_Valid = "True";
                        //        lblQuestionErr.Text = "Please provide valid data.";
                        //    }
                        //}

                        //String YrStr = String.Join(";", chkStrList.ToArray());
                    }
                     
                    else if (AnswerType =="Star") //Star Rating 
                    {

                        HtmlGenericControl sample = itemQuestion.FindControl("divStar") as HtmlGenericControl;
                        string txtNum = sample.Controls[1].UniqueID;
                        string sVal = Request.Form.GetValues(txtNum)[0];
                        DataRow dtRow = dt.NewRow();
                        dtRow["QuestionID"] = HeadId;
                        dtRow["AnswerID"] = AnswerType;
                        dtRow["Data"] = sVal;
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
                    else if (AnswerType =="NPS") //NPS SCORING
                    {
                        HtmlGenericControl sample = itemQuestion.FindControl("divNPS") as HtmlGenericControl;
                        string txtNum = sample.Controls[1].UniqueID;
                        string sVal = Request.Form.GetValues(txtNum)[0];
                        DataRow dtRow = dt.NewRow();
                        dtRow["QuestionID"] = HeadId;
                        dtRow["AnswerID"] = AnswerType;
                        dtRow["Data"] = sVal;
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
                    else if (AnswerType =="Emoji") //Emoji Rating
                    {
                        HtmlGenericControl sample = itemQuestion.FindControl("divEmoji") as HtmlGenericControl;
                        string txtNum = sample.Controls[1].UniqueID;
                        string sVal = Request.Form.GetValues(txtNum)[0];
                        DataRow dtRow = dt.NewRow();
                        dtRow["QuestionID"] = HeadId;
                        dtRow["AnswerID"] = AnswerType;
                        dtRow["Data"] = sVal;
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
                dsFeedbackQuestionData = ObjUpkeep.Insert_FeedbackForm(CompanyID, EventID, strFeedbackData, LoggedInUserID);

                if (dsFeedbackQuestionData.Tables.Count > 0)
                {
                    if (dsFeedbackQuestionData.Tables[0].Rows.Count > 0)
                    {
                        int status = Convert.ToInt32(dsFeedbackQuestionData.Tables[0].Rows[0]["status"]);
                        if (status == 1)
                        {
                            SetRepeater();
                            //divinsertbutton.visible = false;
                            //lblFeedbackRequestCode.Text = Convert.ToString(dsFeedbackQuestionData.Tables[0].Rows[0]["requestid"]);
                            mpeFeedbackRequestSaveSuccess.Show();
                        }
                        else
                        {
                            SetRepeater();
                            lblErrorMsg.Text = "error occured !!!";
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

        #endregion

    }
}