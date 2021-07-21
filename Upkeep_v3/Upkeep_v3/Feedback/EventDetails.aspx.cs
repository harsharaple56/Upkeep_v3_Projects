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
    public partial class EventDetails : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeepFeedback = new Upkeep_V3_Services.Upkeep_V3_Services();

        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();

        DataSet ds = new DataSet();
        int CompanyID = 0;
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            //event_form.Action= @"EventDetails.aspx";  // commentd by suju removed form type 
            
            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect("~/Login.aspx", false);
            }

            if (!IsPostBack)
            {
                int EventID = Convert.ToInt32(Request.QueryString["EventID"]);
                

                int EventID_Delete = Convert.ToInt32(Request.QueryString["DelEventID"]);

                Fetch_CategorySubCategory(0);

                if (EventID > 0)
                {
                    Session["EventID"] = Convert.ToString(EventID);
                    bindEventDetails(EventID);
                    
                }

                if (EventID_Delete > 0)
                {
                    // DeleteEmployee(EventID_Delete);
                }

            }
        }

        public void Fetch_CategorySubCategory(int CategoryID)
        {
            DataSet dsCategory = new DataSet();
            try
            {

                dsCategory = ObjUpkeep.Fetch_CategorySubCategory(CategoryID, CompanyID);

                if (CategoryID == 0)
                {
                    //ddlCategory.DataSource = dsCategory.Tables[0];
                    //ddlCategory.DataTextField = "Category_Desc";
                    //ddlCategory.DataValueField = "Category_ID";
                    //ddlCategory.DataBind();
                    //ddlCategory.Items.Insert(0, new ListItem("--Select--", "0"));

                    //dlCategory.InnerHtml = "";
                    //dlCategory.DataBind();

                    var builder = new System.Text.StringBuilder();

                    for (int i = 0; i < dsCategory.Tables[0].Rows.Count; i++)
                    {
                        builder.Append(String.Format("<option value='{0}' text='{1}'>", dsCategory.Tables[0].Rows[i]["Category_Desc"], dsCategory.Tables[0].Rows[i]["Category_ID"]));
                    }
                    dlCategory.InnerHtml = builder.ToString();
                    dlCategory.DataBind();

                }
                else if (CategoryID > 0)
                {
                    //ddlSubCategory.DataSource = dsCategory.Tables[0];
                    //ddlSubCategory.DataTextField = "SubCategory_Desc";
                    //ddlSubCategory.DataValueField = "SubCategory_ID";
                    //ddlSubCategory.DataBind();
                    //ddlSubCategory.Items.Insert(0, new ListItem("--Select--", "0"));

                    var builder = new System.Text.StringBuilder();

                    for (int i = 0; i < dsCategory.Tables[0].Rows.Count; i++)
                    {
                        builder.Append(String.Format("<option value='{0}' text='{1}'>", dsCategory.Tables[0].Rows[i]["SubCategory_Desc"], dsCategory.Tables[0].Rows[i]["SubCategory_ID"]));
                    }
                    //dlSubCategory.InnerHtml = builder.ToString();
                    //dlSubCategory.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string eventName = name.Text;
                string locationName = Location.Text;
                string[] startDT = Request.Form.GetValues("startDate");

                string startDateTime = string.Empty;
                if (startDT != null)
                {
                    startDateTime = startDT[0];
                }

                string[] endtDT = Request.Form.GetValues("endDate");
                string endDateTime = string.Empty;
                if (endtDT != null)
                {
                    endDateTime = endtDT[0];
                }
                string CustomerQuestion = string.Empty;
                string CustQuesType = string.Empty;
                string RetailerQuestion = string.Empty;
                string RetQuesType = string.Empty;

                string option1 = string.Empty;
                string option2 = string.Empty;
                string option3 = string.Empty;
                string option4 = string.Empty;

                int EventID = 0;
                DataSet ds = new DataSet();
                string QuesFor = string.Empty;
                if (rdbCustomer.Checked == true)
                { QuesFor = "C"; }
                if (rdbRetailer.Checked == true)
                { QuesFor = "R"; }
                if (rdbVisitor.Checked == true)
                { QuesFor = "V"; }
                if (rdbEmployee.Checked == true)
                { QuesFor = "E"; }

                string EventMode = string.Empty;
                if (rdbDaily.Checked == true)
                {
                    EventMode = "D"; // Daily/Monthly
                }
                if (rdbPeriodic.Checked == true)
                {
                    EventMode = "P"; // Periodic            
                }

                int ccc = Request.Form.Count;
                for (int i = 0; i < ccc; i++)
                {
                    
                    //string[] CustQuesArray = Request.Form.GetValues("Customer[" + i + "][txtCustomerQuestion]");
                    string[] CustQuesArray = Request.Form.GetValues("Customer[" + i + "][ctl00$ContentPlaceHolder1$txtCustomerQuestion]");

                    if (CustQuesArray != null)
                    {
                        CustomerQuestion = CustQuesArray[0];
                    }

                    string[] CustQuestypeArray = Request.Form.GetValues("Customer[" + i + "][type]");

                    if (CustQuestypeArray != null)
                    {
                        CustQuesType = CustQuestypeArray[0];
                    }

                    string[] Arr_option1 = Request.Form.GetValues("Customer[" + i + "][ctl00$ContentPlaceHolder1$option1]");
                    if (Arr_option1 != null)
                    {
                        option1 = Arr_option1[0];
                    }

                    string[] Arr_option2 = Request.Form.GetValues("Customer[" + i + "][ctl00$ContentPlaceHolder1$option2]");
                    if (Arr_option2 != null)
                    {
                        option2 = Arr_option2[0];
                    }

                    string[] Arr_option3 = Request.Form.GetValues("Customer[" + i + "][ctl00$ContentPlaceHolder1$option3]");
                    if (Arr_option3 != null)
                    {
                        option3 = Arr_option3[0];
                    }

                    string[] Arr_option4 = Request.Form.GetValues("Customer[" + i + "][ctl00$ContentPlaceHolder1$option4]");
                    if (Arr_option4 != null)
                    {
                        option4 = Arr_option4[0];
                    }

                    //string[] RetQuesArray = Request.Form.GetValues("Retailer[" + i + "][txtRetailerQuestion]");
                    //if (RetQuesArray != null)
                    //{
                    //    RetailerQuestion = RetQuesArray[0];
                    //}

                    //string[] RetQuestypeArray = Request.Form.GetValues("Retailer[" + i + "][type]");

                    //if (RetQuestypeArray != null)
                    //{
                    //    RetQuesType = RetQuestypeArray[0];
                    //}


                    if (CustQuesArray != null)
                    {
                        //ds = objFeedbackService.Event_Insert(eventName, locationName, startDateTime, endDateTime, CustomerQuestion, CustQuesType, RetailerQuestion, RetQuesType, EventID);

                        ds = ObjUpkeepFeedback.Event_Insert(eventName, locationName, startDateTime, endDateTime, CustomerQuestion, CustQuesType, QuesFor, EventID, EventMode, LoggedInUserID, option1, option2, option3, option4, CompanyID);

                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                EventID = Convert.ToInt32(ds.Tables[0].Rows[0]["Event_ID"]);
                                //Response.Redirect("~/RetailerListing.aspx", false);
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

                Response.Redirect(Page.ResolveClientUrl("~/Feedback/EventListing.aspx"), false);
                

                //foreach (string key in Request.Form)
                //{
                //    int ccc = Request.Form.Count;
                //   //Response.Write(Request.Form[key]);
                //    int i = 0;
                //    string[] n = Request.Form.GetValues("Customer["+i+"][txtCustomerQuestion]");

                //    string xczx = n[0];

                //    string[] type = Request.Form.GetValues("Customer[" + i + "][type]");

                //    string t = type[0];
                //    i++;
                //}

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void bindEventDetails(int EventID)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = ObjUpkeepFeedback.bindEventDetails(CompanyID,EventID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        name.Text = Convert.ToString(ds.Tables[0].Rows[0]["Event_Name"]);
                        string User_Type = Convert.ToString(ds.Tables[0].Rows[0]["User_Type"]);
                        if (User_Type == "C")
                        {
                            rdbCustomer.Checked = true;
                        }
                        else
                        {
                            rdbRetailer.Checked = true;
                        }
                        string Event_Mode = Convert.ToString(ds.Tables[0].Rows[0]["Event_Mode"]);
                        if (Event_Mode == "D")
                        {
                            rdbDaily.Checked = true;
                        }
                        else
                        {
                            rdbPeriodic.Checked = true;
                            dvDate.Attributes.Add("style", "display:block");
                            startDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["Start_Date"]);
                            endDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["Expiry_Date"]);
                        }

                        Location.Text = Convert.ToString(ds.Tables[0].Rows[0]["Location"]);

                        int rowCount = ds.Tables[0].Rows.Count;



                        string data = "";

                        for (int i = 0; i < rowCount; i++)
                        {
                            //string[] CustQuesArray = Request.Form.Set(    GetValues("Customer[" + i + "][txtCustomerQuestion]");
                            //Request.Form.GetValues( ( ("Customer[1][txtCustomerQuestion]", Convert.ToString(ds.Tables[0].Rows[i]["Question"]));
                            //if (CustQuesArray != null)
                            //{
                            //    CustomerQuestion = CustQuesArray[0];
                            //}

                            //txtCustomerQuestion.Text = Convert.ToString(ds.Tables[0].Rows[i]["Question"]);
                            //txtquestion.InnerText = Convert.ToString(ds.Tables[0].Rows[i]["Question"]);

                            data += "<div data-repeater-list='customer' class='col-lg-12'> <div data-repeater-item class='form-group m-form__group row'> <div class='col-md-8'> <div class='m-form__group'><div class='m-form__control'><textarea class='form-control m-input autosize_textarea question_textarea' placeholder='Enter question' rows='1' name='question'></textarea> 																						<span class='error_question text-danger small'></span> 																					</div> 																				</div> 																				<div class='d-md-none m--margin-bottom-10'></div> 																			</div> 																			<div class='col-md-3'> 																				<div class='m-form__group'> 																					<div class='m-form__control'> 																						<select name='type' class='form-control m-input type_select'> 																							<option value=''>Select Answer Type</option> 																							<option value='1'>Emoji</option> 																							<option value='2'>Text</option> 																							<option value='3'>Options</option> 																						</select> 																						<span class='error_type text-danger small'></span> 																					</div> 																				</div> 																				<div class='d-md-none m--margin-bottom-10'></div> 																			</div> 																			<div class='col-md-1'> 																				<div data-repeater-delete='' class='btn btn-danger m-btn m-btn--icon m-btn--icon-only has-confirmation'> 																					<i class='la la-trash'></i> 																				</div> 																			</div> 																			<div class='options_group row col-md-12' style='display: none;'> 																				<div class='col-md-12 m--margin-bottom-10 font-weight-bold'>Enter Options</div> 																				<div class='col-md-6 m--margin-bottom-10'> 																					<input type='text' name='option1' class='form-control m-input text_option' placeholder='Enter option'> 																					<span class='error_option text-danger small'></span> 																				</div> 																				<div class='col-md-6 m--margin-bottom-10'> 																					<input type='text' name='option2' class='form-control m-input text_option' placeholder='Enter option'> 																					<span class='error_option text-danger small'></span> 																				</div> 																				<div class='col-md-6 m--margin-bottom-10'> 																					<input type='text' name='option3' class='form-control m-input text_option' placeholder='Enter option'> 																					<span class='error_option text-danger small'></span> 																				</div> 																				<div class='col-md-6 m--margin-bottom-10'> 																					<input type='text' name='option4' class='form-control m-input text_option' placeholder='Enter option'> 																					<span class='error_option text-danger small'></span> 																				</div> 																			</div> 																		</div></div> 																	";

                        }

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
        }

        public string EventBind()
        {
            string data = "";
            DataSet ds = new DataSet();
            ds = ObjUpkeepFeedback.bindEventDetails(CompanyID,3);

            int rowCount = ds.Tables[0].Rows.Count;

            dvCustomer.Attributes.Add("style", "display:none;");

            string Option1 = string.Empty;
            string Option2 = string.Empty;
            string Option3 = string.Empty;
            string Option4 = string.Empty;

            for (int i = 0; i < rowCount; i++)
            {
                //string[] CustQuesArray = Request.Form.Set(    GetValues("Customer[" + i + "][txtCustomerQuestion]");
                //Request.Form.GetValues( ( ("Customer[1][txtCustomerQuestion]", Convert.ToString(ds.Tables[0].Rows[i]["Question"]));
                //if (CustQuesArray != null)
                //{
                //    CustomerQuestion = CustQuesArray[0];
                //}

                string Ques = Convert.ToString(ds.Tables[0].Rows[i]["Question"]);
                string AnsType = Convert.ToString(ds.Tables[0].Rows[i]["Answer_Type"]);

                Option1 = Convert.ToString(ds.Tables[0].Rows[i]["Option1"]);
                //txtquestion.InnerText = Convert.ToString(ds.Tables[0].Rows[i]["Question"]);


                //data += "<div data-repeater-item='' class='form-group m-form__group row' runat='server' id='dvCustomer'><div class='col-md-8'><div class='m-form__group'><div class='m-form__control'><asp:TextBox id='txtCustomerQuestion' runat='server' TextMode='MultiLine' class='form-control m-input autosize_textarea question_textarea' placeholder='Enter question' rows='1' Text='"+Ques+"' ></asp:TextBox></div></div><div class='d-md-none m--margin-bottom-10'></div></div><div class='col-md-3'><div class='m-form__group'><div class='m-form__control'><select name='type' class='form-control m-input type_select'><option value='' selected>Select Answer Type</option><option value='Emoji' ";
                //if(AnsType=="Emoji") {
                //    data += "Selected";
                //} 

                //data +=">Emoji</option><option value='Text' ";
                //if (AnsType == "Text")
                //{
                //    data += "Selected";
                //}
                //data += ">Text</option><option value='Options' ";

                //if (AnsType == "Options")
                //{
                //    data += "Selected";
                //}
                //data += ">Options</option></select><span class='error_type text-danger small'></span></div></div><div class='d-md-none m--margin-bottom-10'></div></div><div class='col-md-1'><div data-repeater-delete='' class='btn btn-danger m-btn m-btn--icon m-btn--icon-only'><i class='la la-trash'></i></div></div><div class='options_group row col-md-12' ";

                //if (AnsType == "Options")
                //{
                //    data += "style='display:block;'";
                //}
                //else
                //{
                //    data += "style='display:none;'";
                //}

                //data += "><div class='col-md-12 m--margin-bottom-10 font-weight-bold'>Enter Options</div><div class='col-md-6 m--margin-bottom-10'><asp:TextBox ID='option1' runat='server' class='form-control m-input text_option' placeholder='Enter option' Text=" + Option1 + " ></asp:TextBox><span class='error_option text-danger small'></span></div><div class='col-md-6 m--margin-bottom-10'><asp:TextBox ID='option2' runat='server' class='form-control m-input text_option' placeholder='Enter option' ></asp:TextBox><span class='error_option text-danger small'></span></div><div class='col-md-6 m--margin-bottom-10'><asp:TextBox ID='option3' runat='server' class='form-control m-input text_option' placeholder='Enter option' ></asp:TextBox><span class='error_option text-danger small'></span></div><div class='col-md-6 m--margin-bottom-10'><asp:TextBox ID='option4' runat='server' class='form-control m-input text_option' placeholder='Enter option' ></asp:TextBox><span class='error_option text-danger small'></span></div></div></div>";




                data += "<div data-repeater-item class='form-group m-form__group row'><div class='col-md-8'><div class='m-form__group'><div class='m-form__control'><textarea class='form-control m-input autosize_textarea question_textarea' placeholder='Enter question' rows='1' name='question'> " + Ques + "   </textarea><span class='error_question text-danger small'></span></div></div><div class='d-md-none m--margin-bottom-10'></div></div><div class='col-md-3'><div class='m-form__group'><div class='m-form__control'><select name='type' class='form-control m-input type_select'><option value=''>Select Answer Type</option><option value='Emoji' ";
                if (AnsType == "Emoji")
                {
                    data += "Selected";
                }

                data += " >Emoji</option><option value='Text'";
                if (AnsType == "Text")
                {
                    data += "Selected";
                }
                data += ">Text</option><option value='Options'";
                if (AnsType == "Options")
                {
                    data += "Selected";

                }
                data += ">Options</option> </select> 	<span class='error_type text-danger small'></span> </div></div>	<div class='d-md-none m--margin-bottom-10'></div></div><div class='col-md-1'><div data-repeater-delete='' class='btn btn-danger m-btn m-btn--icon m-btn--icon-only has-confirmation'><i class='la la-trash'></i></div></div><div class='options_group row col-md-12'";
                if (AnsType == "Options")
                {
                    data += "'style=display:block'";

                }
                else
                {
                    data += "'style=display:none'";
                }
                data += "><div class='col-md-12 m--margin-bottom-10 font-weight-bold'>Enter Options</div><div class='col-md-6 m--margin-bottom-10'><input type='text' name='option1' class='form-control m-input text_option' placeholder='Enter option'>" + Option1 + "<span class='error_option text-danger small'></span> 																				</div> 																				<div class='col-md-6 m--margin-bottom-10'> 																					<input type='text' name='option2' class='form-control m-input text_option' placeholder='Enter option'> 																					<span class='error_option text-danger small'></span> 																				</div> 																				<div class='col-md-6 m--margin-bottom-10'> 																					<input type='text' name='option3' class='form-control m-input text_option' placeholder='Enter option'> 																					<span class='error_option text-danger small'></span> 																				</div> 																				<div class='col-md-6 m--margin-bottom-10'> 																					<input type='text' name='option4' class='form-control m-input text_option' placeholder='Enter option'> 																					<span class='error_option text-danger small'></span> 																				</div> 																			</div> 																		</div>";

            }



            return data;
        }

        protected void btnSubCategorySave_Click(object sender, EventArgs e)
        {

        }
    }
}