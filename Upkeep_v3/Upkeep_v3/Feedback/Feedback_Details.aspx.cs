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
        int Feedback_No = 0;
        int Event_ID = 0;
        int User_ID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            CompanyCode = Convert.ToString(Session["CompanyCode"]);
            UserType = Convert.ToString(Session["UserType"]);
            Feedback_No = Convert.ToInt32(Request.QueryString["FeedbackNo"]);
            Event_ID = Convert.ToInt32(Request.QueryString["EventID"]);
            User_ID = Convert.ToInt32(Request.QueryString["UserID"]);
            

            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            //Bind_GatePassConfiguration(GP_ConfigID);
            if (!IsPostBack)
            {

                Fetch_Feedback_Details();

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
    }
}