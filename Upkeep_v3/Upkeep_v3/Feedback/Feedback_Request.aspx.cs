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

        }

        protected void ddlFeedbackTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ConfigTitleID = 0;

            try
            {
                //lblRequestDate.Text = DateTime.Now.ToString("dd/MMM/yyyy hh:mm tt");

                ConfigTitleID = Convert.ToInt32(ddlFeedbackTitle.SelectedValue);


                dsConfig = null;// ObjUpkeep.Bind_FeedbackRequestDetails(ConfigTitleID, LoggedInUserID);

                rptHeaderDetails.DataSource = dsConfig.Tables[4];
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

                int AnswerType = Convert.ToInt32((e.Item.FindControl("hdnlblAnswerType") as HiddenField).Value);
                string HeadId = (e.Item.FindControl("hfHeaderId") as HiddenField).Value;

                if (AnswerType == 1) //Multi Selection [CheckBox]
                {
                    HtmlGenericControl sample = e.Item.FindControl("divCheckBox") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == 2) //Single Selection [Radio Button]
                {
                    HtmlGenericControl sample = e.Item.FindControl("divRadioButton") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == 3) //Image Upload  
                {
                    HtmlGenericControl sample = e.Item.FindControl("divImage") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == 4) //Number Text Field
                {
                    HtmlGenericControl sample = e.Item.FindControl("divNumber") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == 5) //Normal Text Field
                {
                    HtmlGenericControl sample = e.Item.FindControl("divText") as HtmlGenericControl;
                    sample.Attributes.Remove("style");
                }
                else if (AnswerType == 6) // Textarea Field
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
                dsFeedbackHeader = dsConfig.Copy(); //ObjUpkeep.Bind_FeedbackConfiguration(sPublicConfigId);

                DataTable dt = new DataTable();
                dt = dsFeedbackHeader.Tables[3].Copy();
                dt.DefaultView.RowFilter = "Feedback_Qn_ID = " + Convert.ToString(HeadId) + "";
                dt = dt.DefaultView.ToTable();

                if (AnswerType == 2)
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
                else if (AnswerType == 1)
                {
                    CheckBoxList divCheckBoxIDI = e.Item.FindControl("divCheckBoxIDI") as CheckBoxList;
                    if (dt.Rows.Count > 0)
                    {
                        //rptRadio.DataSource = dt;
                        //rptRadio.DataBind(); 
                        divCheckBoxIDI.DataTextField = "Ans_Type_Data"; // "Ans_Type_Desc";
                        divCheckBoxIDI.DataValueField = "Ans_Type_Data_ID";  // "Ans_Type_ID";// 
                        divCheckBoxIDI.DataSource = dt;
                        divCheckBoxIDI.DataBind();
                    }
                    else
                    {
                        DataTable dt1 = new DataTable();
                        //rptRadio.DataSource = dt1;
                        //rptRadio.DataBind();
                        divCheckBoxIDI.DataSource = dt;
                        divCheckBoxIDI.DataBind();
                    }
                }

            }
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
                dsTitle = null;// ObjUpkeep.Fetch_FeedbackConfiguration(Initiator);
                if (dsTitle.Tables.Count > 0)
                {
                    if (dsTitle.Tables[0].Rows.Count > 0)
                    {
                        ddlFeedbackTitle.DataSource = dsTitle.Tables[0];
                        ddlFeedbackTitle.DataTextField = "Config_Title";
                        ddlFeedbackTitle.DataValueField = "Feedback_Config_Id";
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

        #endregion

    }
}