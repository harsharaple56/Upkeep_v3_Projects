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
using System.Xml;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace Upkeep_v3.Feedback
{
    public partial class Feedback_Details : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();

        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        string CompanyCode = string.Empty;
        string UserType = string.Empty;
        string Feedback_No = string.Empty;
        int Event_ID = 0;
        int User_ID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            CompanyCode = Convert.ToString(Session["CompanyCode"]);
            UserType = Convert.ToString(Session["UserType"]);
            Feedback_No = Convert.ToString(Request.QueryString["fno"]);
            Event_ID = Convert.ToInt32(Request.QueryString["EventID"]);
            User_ID = Convert.ToInt32(Request.QueryString["uid"]);
            
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            //Bind_GatePassConfiguration(GP_ConfigID);
            if (!IsPostBack)
            {
                if(Feedback_No == "NA")
                {
                    Response.Redirect(Page.ResolveClientUrl("~/Feedback/Feedback_MIS_Report.aspx"), false);
                }
                else
                {
                    Fetch_Feedback_Details();
                    BindEvent();
                    //Oberoi Mall Integration with PAZO
                    if (CompanyCode == "OBRC")
                    {
                        div_Integration_PAZO.Visible = true;
                    }
                    else
                    {
                        div_Integration_PAZO.Visible = false;
                    }
                }
                
            }

        }

        protected void Fetch_Feedback_Details()
        {

            DataSet ds = new DataSet();
            try
            {

                ds = ObjUpkeep.Fetch_Feedback_Details(CompanyID, Feedback_No, Event_ID, User_ID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        rptFeedbackDetails.DataSource = ds.Tables[0];
                        rptFeedbackDetails.DataBind();


                        lbl_Feedback_Total_Points.InnerText = Convert.ToString(ds.Tables[0].Rows[0]["Total_Points"]);
                        string User_Type = Convert.ToString(ds.Tables[0].Rows[0]["Feedback_User_Type"]);

                        if(User_Type=="E")
                        {
                            div_Customer_Details.Visible = true;
                            div_Retailer_Details.Visible = false;

                            lbl_Customer_Name.InnerText = Convert.ToString(ds.Tables[1].Rows[0]["Customer_Name"]);
                            lbl_Customer_Email.InnerText = Convert.ToString(ds.Tables[1].Rows[0]["Customer_Email"]);
                            lbl_Customer_Contact.InnerText = Convert.ToString(ds.Tables[1].Rows[0]["Customer_Contact"]);
                            lbl_Customer_Gender.InnerText = Convert.ToString(ds.Tables[1].Rows[0]["Customer_Gender"]);
                            imp_Customer_Image.Src= Convert.ToString(ds.Tables[1].Rows[0]["Customer_Photo"]);

                        }
                        else if(User_Type=="R")
                        {
                            div_Customer_Details.Visible = false;
                            div_Retailer_Details.Visible = true;

                            lbl_Retailer_StoreName.InnerText = Convert.ToString(ds.Tables[1].Rows[0]["Store_Name"]);
                            lbl_Retailer_StoreNo.InnerText = Convert.ToString(ds.Tables[1].Rows[0]["Store_No"]);
                            lbl_Retailer_StoreMgrName.InnerText = Convert.ToString(ds.Tables[1].Rows[0]["Store_Manager_Name"]);
                            lbl_Retailer_Email.InnerText = Convert.ToString(ds.Tables[1].Rows[0]["Store_Email"]);
                            lbl_Retailer_Contact.InnerText = Convert.ToString(ds.Tables[1].Rows[0]["Store_Contact"]);

                        }
                        
                    }

                   
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void BindEvent()
        {
            try
            {

                ds = ObjUpkeep.Fetch_Feedback_Details(CompanyID, Feedback_No, Event_ID, User_ID);

               // ds = ObjUpkeep.bindEventDetails(CompanyID, Event_ID);


                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        rptHeaderDetails.DataSource = ds.Tables[2];
                        //rptHeaderDetails.DataSource = ds.Tables[0];

                        rptHeaderDetails.DataBind();

                    }
                }

                
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
                dsFeedbackHeader = ds.Copy(); //ObjUpkeep.Bind_FeedbackConfiguration(sPublicEventID);

                DataTable dt = new DataTable();
                dt = dsFeedbackHeader.Tables[2].Copy();
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
                        //rptRadio.DataSource = dt;
                        //rptRadio.DataBind(); 
                        //divRadioButtonrdbYes.DataTextField = "Ans_Type_Data"; // "Ans_Type_Desc";
                        //divRadioButtonrdbYes.DataValueField = "Ans_Type_Data_ID";  // "Ans_Type_ID";// 
                        //divRadioButtonrdbYes.DataSource = dt;
                        //divRadioButtonrdbYes.DataBind();
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

        protected void btn_Raise_Feedback_Issue_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Ticketing/Add_MyRequest.aspx?Feedback_No="+Feedback_No), false);
        }

    }
}