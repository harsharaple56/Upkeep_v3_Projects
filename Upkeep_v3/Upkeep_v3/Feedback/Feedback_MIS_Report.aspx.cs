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
    public partial class Feedback_MIS_Report : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeepFeedback = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        int CompanyID = 0;
        string LoggedInUserID = string.Empty;
        GridView dgGrid = new GridView();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                //Response.Redirect("~/Login.aspx", false);
            }
            
            hdn_IsPostBack.Value = "yes";
            if (!IsPostBack)
            {
                bindEvent();
                hdn_IsPostBack.Value = "no";
                //bindHeader();
            }
        }

        public void bindEvent()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = ObjUpkeepFeedback.GetEventList(CompanyID,"*");

                ddlEventName.DataSource = ds.Tables[0];
                ddlEventName.DataValueField = "Event_ID";
                ddlEventName.DataTextField = "Event_Name";
                ddlEventName.DataBind();
                //ddlEventName.Items.Insert(0, "--Select--");
                ddlEventName.Items.Insert(0, new ListItem("--Select--", "0"));

                //ddlEventName.SelectedValue = Convert.ToString(ds.Tables[0].Rows.Count);
                ddlEventName.SelectedIndex = ds.Tables[0].Rows.Count;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public string bindHeader()
        {
            string data = "";
            string From_Date = string.Empty;
            string To_Date = string.Empty;
            try
            {
                if (start_date.Value != "")
                {
                    From_Date = Convert.ToString(start_date.Value);
                }
                else
                {
                    //DateTime dtime = DateTime.Now;
                    //DateTime date = DateTime.ParseExact(dtime.ToShortDateString(), "dd/MMM/yy", CultureInfo.InvariantCulture).AddDays(-30);
                    //DateTime date = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)).AddDays(-30);

                    //DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)).AddDays(-30);
                    DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yy", CultureInfo.InvariantCulture)).AddDays(-30);

                    ////DateTime expiryDate = FromDate.AddDays(-30);
                    From_Date = FromDate.ToString("dd/MMM/yy", CultureInfo.InvariantCulture);
                }


                if (end_date.Value != "")
                {
                    To_Date = Convert.ToString(end_date.Value);
                }
                else
                {
                    //To_Date = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    To_Date = DateTime.Now.ToString("dd/MMM/yy", CultureInfo.InvariantCulture);

                }

                string EventID = Convert.ToString(ddlEventName.SelectedValue);
                DataSet ds = new DataSet();
                ds = ObjUpkeepFeedback.Fetch_MIS_Report(EventID, From_Date, To_Date, CompanyID);
                int ColumnCount = 0;

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Columns.Count > 3)
                        {
                            int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                            //for (int i = 0; i < count; i++)
                            //{
                            //int EventID = Convert.ToInt32(ds.Tables[0].Rows[i]["Event_ID"]);
                            //string EventName = Convert.ToString(ds.Tables[0].Rows[i]["Event_Name"]);
                            //string Location = Convert.ToString(ds.Tables[0].Rows[i]["Location"]);
                            //string EventFor = Convert.ToString(ds.Tables[0].Rows[i]["EventFor"]);
                            //string CreatedOn = Convert.ToString(ds.Tables[0].Rows[i]["Created_Date"]);
                            //string StartDate = Convert.ToString(ds.Tables[0].Rows[i]["Start_Date"]);
                            //string EndDate = Convert.ToString(ds.Tables[0].Rows[i]["Expiry_Date"]);

                            string UserType = Convert.ToString(ds.Tables[0].Rows[0]["User_Type"]);

                            string Question = string.Empty;

                            if (UserType == "R")
                            {

                                data = "<tr><th>Action</th><th>Feedback No</th> <th>Store Name</th><th>Store No.</th><th>Manager Name</th><th>Email</th><th>Phone No</th> <th>User Name</th><th>FeedbackTakenDate</th> ";
                            }
                            else
                            {
                                data = "<tr><th>Action</th><th>Feedback No</th> <th>Name</th><th>Email</th><th>Mobile</th><th>Gender</th><th>User Name</th><th>FeedbackTakenDate</th> ";
                            }
                            //for (int k = 1; k <= ds.Tables[0].Columns.Count; k++)
                            //{

                            //ColumnCount = (ds.Tables[0].Columns.Count) - 10;
                            ColumnCount = (ds.Tables[1].Rows.Count);

                            int QuestionRowCount = 0;
                            string indicator = string.Empty;
                            string ans_type = string.Empty;
                            //indicator = "<span class='fa-smile-beam'></span>";

                            for (int j = 1; j <= ColumnCount; j++)
                            {
                                QuestionRowCount = j - 1;
                                Question = Convert.ToString(ds.Tables[1].Rows[QuestionRowCount]["Question"]);
                                indicator = Convert.ToString(ds.Tables[1].Rows[QuestionRowCount]["Indicator"]);
                                //ans_type = Convert.ToString(ds.Tables[1].Rows[QuestionRowCount]["Answer_Type"]);
                                //if (ans_type == "Emoji")
                                //{
                                //    indicator = "<span class='fa fa-smile-beam'></span>";
                                //}
                                //else if (ans_type == "Star")
                                //{
                                //    indicator = "<span class='fa fa-star'></span>";
                                //}
                                //else if (ans_type == "Text")
                                //{
                                //    indicator = "<span class='fa fa-text-height'></span>";
                                //}
                                //else if (ans_type == "NPS")
                                //{
                                //    indicator = "<span class='fa a-tachometer-alt'></span>";
                                //}
                                //else if (ans_type == "Options")
                                //{
                                //    indicator = "<span class='fa fa-align-left'></span>";
                                //}

                                //data += "<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Nostrud esse officia adipisicing dolore est in eiusmod dolor tempor adipisicing ut non non.'>Q" + j + "</th> ";
                                data += "<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='" + Question + "'>Q" + j +" "+ indicator+ "</th> ";

                            }
                            //}

                            data += " <th data-container='body' data-toggle='m-tooltip' data-placement='top' title='It is SUM of Emoji and Star '>Total</th><th data-toggle='m-tooltip' data-placement='top' title='Average for EMOJI Feedbacks'>Average</th><th data-toggle='m-tooltip' data-placement='top' title='Percentage of Emoji Feedbacks out of Total Count'>Percentage</th> </tr>";

                            //data += "<tr><td>" + EventName + "</td><td>" + Location + "</td><td>" + EventFor + "</td><td>" + CreatedOn + "</td><td>" + StartDate + "</td> <td>" + EndDate + "</td> <td><a href='EventDetails.aspx?EventID=" + EventID + "'
                            //class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record'> <i class='la la-edit'></i> </a> <a href='EventQuestions.aspx?EventID=" + EventID + "'
                            //class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='View question list'><i class='la la-th-list'></i></a> <a href='EventDetails.aspx?DelEventID=" +
                            //EventID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

                            //}
                        }
                        else
                        {
                            data = "<tr><th>Name</th><th>Email</th><th>Mobile</th><th>Gender</th><th>User Name</th><th>FeedbackTakenDate</th><th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q1'>Q1</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q2'>Q2</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q3'>Q3</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q4'>Q4</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q5'>Q5</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q6'>Q6</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q7'>Q7</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q8'>Q8</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q9'>Q9</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q10'>Q10</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q11'>Q11</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q12'>Q12</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q13'>Q13</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q14'>Q14</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q15'>Q15</th> </tr>";

                        }
                    }
                    else
                    {
                        data = "<tr><th>Name</th><th>Email</th><th>Mobile</th><th>Gender</th><th>User Name</th><th>FeedbackTakenDate</th><th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q1'>Q1</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q2'>Q2</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q3'>Q3</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q4'>Q4</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q5'>Q5</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q6'>Q6</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q7'>Q7</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q8'>Q8</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q9'>Q9</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q10'>Q10</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q11'>Q11</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q12'>Q12</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q13'>Q13</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q14'>Q14</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q15'>Q15</th> </tr>";

                        //invalid login
                    }
                }
                else
                {
                    data = "<tr><th>Name</th><th>Email</th><th>Mobile</th><th>Gender</th><th>User Name</th><th>FeedbackTakenDate</th><th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q1'>Q1</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q2'>Q2</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q3'>Q3</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q4'>Q4</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q5'>Q5</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q6'>Q6</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q7'>Q7</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q8'>Q8</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q9'>Q9</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q10'>Q10</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q11'>Q11</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q12'>Q12</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q13'>Q13</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q14'>Q14</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q15'>Q15</th> </tr>";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

        public string bindMIS_Report()
        {
            string data = "";
            string From_Date = string.Empty;
            string To_Date = string.Empty;
            try
            {
                if (start_date.Value != "")
                {
                    From_Date = Convert.ToString(start_date.Value);
                }
                else
                {
                    DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yy", CultureInfo.InvariantCulture)).AddDays(-30);
                    //DateTime expiryDate = FromDate.AddDays(-30);
                    From_Date = FromDate.ToString("dd/MMM/yy", CultureInfo.InvariantCulture);
                }


                if (end_date.Value != "")
                {
                    To_Date = Convert.ToString(end_date.Value);
                }
                else
                {
                    To_Date = DateTime.Now.ToString("dd/MMM/yy", CultureInfo.InvariantCulture);
                }

                string EventID = Convert.ToString(ddlEventName.SelectedValue);

                DataSet ds = new DataSet();
                ds = ObjUpkeepFeedback.Fetch_MIS_Report(EventID, From_Date, To_Date, CompanyID);
                int ColumnCount = 0;
                string Name = string.Empty;
                string EmailID = string.Empty;
                string MobileNo = string.Empty;
                string Gender = string.Empty;
                string Answer = string.Empty;
                string StoreName = string.Empty;
                string StoreNo = string.Empty;
                string UserName = string.Empty;
                string FeedbackTakenDate = string.Empty;
                int UserID = 0;
                string FeedbackNo = string.Empty;

                DateTime FeedbackDate;
                int x = 0;

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Columns.Count > 3)
                        {
                            int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                            string UserType = Convert.ToString(ds.Tables[0].Rows[0]["User_Type"]);



                            for (int i = 0; i < count; i++)
                            {
                                UserName = Convert.ToString(ds.Tables[0].Rows[i]["UserName"]);
                                FeedbackDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["FeedbackTakenDate"]);
                                FeedbackTakenDate = FeedbackDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                                if (UserType == "R")
                                {
                                    UserID = Convert.ToInt32(ds.Tables[0].Rows[i]["User_ID"]);
                                    StoreName = Convert.ToString(ds.Tables[0].Rows[i]["Store_name"]);
                                    StoreNo = Convert.ToString(ds.Tables[0].Rows[i]["Store_no"]);
                                    Name = Convert.ToString(ds.Tables[0].Rows[i]["Manager_Name"]);
                                    EmailID = Convert.ToString(ds.Tables[0].Rows[i]["EmailID"]);
                                    MobileNo = Convert.ToString(ds.Tables[0].Rows[i]["PhoneNo"]);
                                    FeedbackNo = Convert.ToString(ds.Tables[0].Rows[i]["Feedback_No"]);
                                    //string StartDate = Convert.ToString(ds.Tables[0].Rows[i]["Start_Date"]);
                                    //string EndDate = Convert.ToString(ds.Tables[0].Rows[i]["Expiry_Date"]);

                                    data += "<tr><td><a href='Feedback_Details.aspx?EventID=" + EventID + "&uid=" + UserID + "&fno=" + FeedbackNo + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='View Feedback Details'> <i class='la la-eye'></i> </a></td> <td>" + FeedbackNo + "</td><td>" + StoreName + "</td><td>" + StoreNo + "</td><td>" + Name + "</td><td>" + EmailID + "</td><td>" + MobileNo + "</td><td>" + UserName + "</td><td>" + FeedbackTakenDate + "</td>";

                                    ColumnCount = (ds.Tables[0].Columns.Count);

                                    for (int j = 11; j < ColumnCount - 1; j++)
                                    {
                                        Answer = Convert.ToString(ds.Tables[0].Rows[x][j]);
                                        data += "<td>" + Answer + "</td>";
                                    }
                                }
                                else
                                {
                                    UserID = Convert.ToInt32(ds.Tables[0].Rows[i]["User_ID"]);
                                    Name = Convert.ToString(ds.Tables[0].Rows[i]["CustomerName"]);
                                    EmailID = Convert.ToString(ds.Tables[0].Rows[i]["EmailID"]);
                                    MobileNo = Convert.ToString(ds.Tables[0].Rows[i]["MobileNo"]);
                                    Gender = Convert.ToString(ds.Tables[0].Rows[i]["Gender"]);
                                    FeedbackNo = Convert.ToString(ds.Tables[0].Rows[i]["Feedback_No"]);
                                    //string EndDate = Convert.ToString(ds.Tables[0].Rows[i]["Expiry_Date"]);

                                    data += "<tr><td><a href='Feedback_Details.aspx?EventID=" + EventID + "&uid=" + UserID + "&fno=" + FeedbackNo + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='View Feedback Details'> <i class='la la-eye'></i> </a></td> <td>" +  FeedbackNo + " </td> <td>" + Name + " </td><td>" + EmailID + "</td><td>" + MobileNo + "</td><td>" + Gender + "</td><td>" + UserName + "</td> <td>" + FeedbackTakenDate + "</td>";

                                    ColumnCount = (ds.Tables[0].Columns.Count);

                                    for (int j = 10; j < ColumnCount; j++)
                                    {
                                        Answer = Convert.ToString(ds.Tables[0].Rows[x][j]);
                                        data += "<td>" + Answer + "</td>";


                                    }
                                }
                                //for (int k = 1; k <= ds.Tables[0].Columns.Count; k++)
                                //{

                                //ColumnCount = (ds.Tables[0].Columns.Count);

                                //for (int j = 9; j < ColumnCount-1; j++)
                                //{
                                //    Answer = Convert.ToString(ds.Tables[0].Rows[x][j]);
                                //    data += "<td>" + Answer + "</td>";


                                //}

                                //}

                                data += "</tr>";
                                x++;
                                //data += " <th>Total</th><th>Average</th><th>Percentage</th> ";

                                //data += "<tr><td>" + EventName + "</td><td>" + Location + "</td><td>" + EventFor + "</td><td>" + CreatedOn + "</td><td>" + StartDate + "</td> <td>" + EndDate + "</td> <td><a href='EventDetails.aspx?EventID=" + EventID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record'> <i class='la la-edit'></i> </a> <a href='EventQuestions.aspx?EventID=" + EventID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='View question list'><i class='la la-th-list'></i></a> <a href='EventDetails.aspx?DelEventID=" + EventID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

                            }
                        }
                    }
                    else
                    {
                        //data = "<tr><th>Name</th><th>Email</th><th>Mobile</th><th>Gender</th><th>User Name</th><th>FeedbackTakenDate</th><th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q1'>Q1</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q2'>Q2</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q3'>Q3</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q4'>Q4</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q5'>Q5</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q6'>Q6</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q7'>Q7</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q8'>Q8</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q9'>Q9</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q10'>Q10</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q11'>Q11</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q12'>Q12</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q13'>Q13</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q14'>Q14</th> 											<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Q15'>Q15</th> </tr>";

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


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindMIS_Report();
        }
        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        public void ExportToExcel()
        {
            string From_Date = string.Empty;
            string To_Date = string.Empty;

            try
            {

                if (start_date.Value != "")
                {
                    From_Date = Convert.ToString(start_date.Value);
                }

                if (end_date.Value != "")
                {
                    To_Date = Convert.ToString(end_date.Value);
                }
                string EventID = Convert.ToString(ddlEventName.SelectedValue);

                DataSet dsMisReport = new DataSet();
                dsMisReport = ObjUpkeepFeedback.Fetch_MIS_Report_Excel(EventID, From_Date, To_Date, CompanyID);

                System.Data.DataTable dtMISReport = new System.Data.DataTable();


                if (dsMisReport != null)
                {
                    if (dsMisReport.Tables.Count > 0)
                    {
                        if (dsMisReport.Tables[0].Rows.Count > 0)
                        {
                            dtMISReport = dsMisReport.Tables[0];

                            dtMISReport.Columns.Remove("Event_ID");
                            dtMISReport.Columns.Remove("User_ID");
                            //dtMISReport.Columns.Remove("Date Time"); 
                            dtMISReport.AcceptChanges();

                            if (Convert.ToString(dsMisReport.Tables[0].Rows[0]["User_Type"]) == "Retailer")
                            {
                                dtMISReport.Columns.Remove("RowNumber");
                                dtMISReport.AcceptChanges();
                            }

                            System.IO.StringWriter tw = new System.IO.StringWriter();
                            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                            string filename = "Feedback_MISReport_" + DateTime.Now + ".xls";


                            //btnExportToExcel.Visible = true;
                            //dgGrid.DataSource = dsMisReport.Tables[0];
                            dgGrid.DataSource = dtMISReport;
                            dgGrid.DataBind();
                            //Get the HTML for the control.
                            dgGrid.RenderControl(hw);


                            //Write the HTML back to the browser.

                            Response.ContentType = "application/vnd.ms-excel";
                            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                            this.EnableViewState = false;
                            Response.Write(tw.ToString());
                            Response.End();
                            return;
                        }
                    }
                }
                else
                {
                    //lblError.Visible = true;
                    //lblError.Text = "No Data Found";

                    dgGrid.DataSource = null;
                    dgGrid.DataBind();

                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}