using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.General_Masters
{
    public partial class Add_Retailer : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeepFeedback = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            //frmFrequency.Action = @"General_Masters/Add_Frequency.aspx";
            //retailer_form.Action = @"Add_Retailer.aspx";
            if (LoggedInUserID == "")
            {
                Response.Redirect("~/Login.aspx", false);
            }

            if (!IsPostBack)
            {
                Fetch_LocationTree();
                int RetailerID = Convert.ToInt32(Request.QueryString["RetID"]);

                int RetailerID_Delete = Convert.ToInt32(Request.QueryString["DelRetID"]);

                if (RetailerID>0)
                {
                    Session["RetailerID"] = Convert.ToString(RetailerID);
                    bindRetailer(RetailerID);
                    this.Bind_Retailer_Escalation_Grid();
                }

                if (RetailerID_Delete>0)
                {
                    //Session["RetailerID"] = Convert.ToString(RetailerID);
                    DeleteRetailer(RetailerID_Delete);
                }

            }

        }

        public void Fetch_LocationTree()
        {
            DataSet dsLocDetails = new DataSet();
            try
            {
                dsLocDetails = ObjUpkeepFeedback.Fetch_LocationTree(CompanyID);

                if (dsLocDetails.Tables.Count > 0)
                {
                    if (dsLocDetails.Tables[0].Rows.Count > 0)
                    {
                        //ddlLocation.DataSource = dsLocDetails.Tables[0];
                        //ddlLocation.DataTextField = "Loc_Desc";
                        //ddlLocation.DataValueField = "Loc_ID";
                        //ddlLocation.DataBind();
                        //ddlLocation.Items.Insert(0, new ListItem("--Select--", "0"));

                        var builder = new System.Text.StringBuilder();

                        for (int i = 0; i < dsLocDetails.Tables[0].Rows.Count; i++)
                        {
                            builder.Append(String.Format("<option value='{0}' text='{1}'>", dsLocDetails.Tables[0].Rows[i]["Loc_Desc"], dsLocDetails.Tables[0].Rows[i]["Loc_id"]));
                        }
                        dlassetLocation.InnerHtml = builder.ToString();
                        dlassetLocation.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int Retailer_ID = 0;
            try
            {
                if (Convert.ToString(Session["RetailerID"]) != "")
                {
                    Retailer_ID = Convert.ToInt32(Session["RetailerID"]);
                }
                string Action = "";
                string Username = string.Empty;
                string Password = string.Empty;
                string Store_No = string.Empty;

                if (Retailer_ID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                Username = Convert.ToString(txtUsername.Text.Trim());
                Password = Convert.ToString(txtPassword.Text.Trim());

                Store_No = Convert.ToString(txtStoreNo.Text.Trim());

                int LocationID = 0; //Convert.ToInt32(ddlLocation.SelectedValue);
                LocationID = Convert.ToInt32(hdnassetLocation.Value);

                DataSet ds = new DataSet();
                ds = ObjUpkeepFeedback.Retailer_CRUD(store.Text.Trim(), Store_No, first_name.Text.Trim(), last_name.Text.Trim(), email.Text.Trim(), Convert.ToInt64(contact.Text.Trim()), Retailer_ID, Username, Password, LocationID, CompanyID, LoggedInUserID, Action);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            Session["RetailerID"] = "";
                            Response.Redirect(Page.ResolveClientUrl("~/General_Masters/Retailer_Master.aspx"), false);
                        }
                        else if (Status == 3)
                        {
                            lblErrorMsg.Text = "Store details already exists";
                        }
                        else if (Status == 2)
                        {
                            lblErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
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
        }

        public void bindRetailer(int RetailerID)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = ObjUpkeepFeedback.Retailer_CRUD("","", "", "", "", 0, RetailerID,"","",0, CompanyID,LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        store.Text = Convert.ToString(ds.Tables[0].Rows[0]["Store_Name"]);
                        txtStoreNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["Store_No"]);
                        first_name.Text = Convert.ToString(ds.Tables[0].Rows[0]["StoreManagerFirstName"]);
                        last_name.Text = Convert.ToString(ds.Tables[0].Rows[0]["StoreManagerLastName"]);
                        email.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmailID"]);
                        contact.Text = Convert.ToString(ds.Tables[0].Rows[0]["PhoneNo"]);
                        txtUsername.Text = Convert.ToString(ds.Tables[0].Rows[0]["Username"]);
                        txtPassword.Text = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);

                        txtassetLocation.Value = ds.Tables[0].Rows[0]["Loc_Desc"].ToString();
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

        public void DeleteRetailer(int RetailerID)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = ObjUpkeepFeedback.Retailer_CRUD("","", "", "", "", 0, RetailerID,"","",0, CompanyID,LoggedInUserID, "D");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["RetailerID"] = "";
                        //Response.Redirect("~/RetailerListing.aspx", false);
                        Response.Redirect(Page.ResolveClientUrl("~/General_Masters/Retailer_Master.aspx"), false);
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


        private void Bind_Retailer_Escalation_Grid()
        {
            DataSet dsProfile = new DataSet();
            try
            {
                dsProfile = ObjUpkeepFeedback.Retailer_Escalation_CRUD(0, "", "", "", "", "", LoggedInUserID, CompanyID, "R");

                if (dsProfile.Tables.Count > 0)
                {
                    if (dsProfile.Tables[0].Rows.Count > 0)
                    {
                        gvEscalation.DataSource = dsProfile.Tables[0];
                        gvEscalation.DataBind();
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void gvEscalation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //check if the row is the header row
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //add the thead and tbody section programatically
                e.Row.TableSection = TableRowSection.TableHeader;
            }

            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != gvEscalation.EditIndex)
            {
                (e.Row.Cells[6].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }

        protected void gvEscalation_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEscalation.EditIndex = e.NewEditIndex;
            this.Bind_Retailer_Escalation_Grid();
        }

        protected void gvEscalation_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEscalation.EditIndex = -1;
            this.Bind_Retailer_Escalation_Grid();
        }

        protected void gvEscalation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEscalation.PageIndex = e.NewPageIndex;
            this.Bind_Retailer_Escalation_Grid();
        }

        protected void gvEscalation_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataSet dsEscalation = new DataSet();
            try
            {
                string Name = string.Empty;
                string Designation = string.Empty;
                string Department = string.Empty;
                string ContactNo = string.Empty;
                string EmailID = string.Empty;
                int EscalationID = 0;

                GridViewRow row = gvEscalation.Rows[e.RowIndex];
                EscalationID = Convert.ToInt32(gvEscalation.DataKeys[e.RowIndex].Values[0]);

                Name = Convert.ToString((row.FindControl("txtName") as TextBox).Text);
                Designation = Convert.ToString((row.FindControl("txtDesignation") as TextBox).Text);
                Department = Convert.ToString((row.FindControl("txtDepartment") as TextBox).Text);
                ContactNo = Convert.ToString((row.FindControl("txtContactNo_Esc") as TextBox).Text);
                EmailID = Convert.ToString((row.FindControl("txtEmailID_Esc") as TextBox).Text);


                dsEscalation = ObjUpkeepFeedback.Retailer_Escalation_CRUD(EscalationID, Name, Designation, Department, ContactNo, EmailID, LoggedInUserID, CompanyID, "U");
                if (dsEscalation.Tables.Count > 0)
                {
                    if (dsEscalation.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsEscalation.Tables[0].Rows[0]["Status"]);

                        if (Status == 1)
                        {
                            gvEscalation.EditIndex = -1;
                            this.Bind_Retailer_Escalation_Grid();
                        }
                        else if (Status == 2)
                        {
                            lblEscalationError.Text = "User already exists";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvEscalation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet dsEscalation = new DataSet();
            try
            {
                int EscalationID = 0;

                GridViewRow row = gvEscalation.Rows[e.RowIndex];
                EscalationID = Convert.ToInt32(gvEscalation.DataKeys[e.RowIndex].Values[0]);

                dsEscalation = ObjUpkeepFeedback.Retailer_Escalation_CRUD(EscalationID, "", "", "", "", "", LoggedInUserID, CompanyID, "D");
                if (dsEscalation.Tables.Count > 0)
                {
                    if (dsEscalation.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsEscalation.Tables[0].Rows[0]["Status"]);

                        if (Status == 1)
                        {
                            this.Bind_Retailer_Escalation_Grid();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAddEscalation_Click(object sender, EventArgs e)
        {

            DataSet dsEscalation = new DataSet();
            try
            {
                string Name = string.Empty;
                string Designation = string.Empty;
                string Department = string.Empty;
                string ContactNo = string.Empty;
                string EmailID = string.Empty;
                int EscalationID = 0;

                Name = Convert.ToString(txtAddName.Text.Trim());
                Designation = Convert.ToString(txtAddDesignation.Text.Trim());
                Department = Convert.ToString(txtAddDepartment.Text.Trim());
                ContactNo = Convert.ToString(txtAddContactNo.Text.Trim());
                EmailID = Convert.ToString(txtAddEmailID.Text.Trim());


                dsEscalation = ObjUpkeepFeedback.Retailer_Escalation_CRUD(EscalationID, Name, Designation, Department, ContactNo, EmailID, LoggedInUserID, CompanyID, "C");
                if (dsEscalation.Tables.Count > 0)
                {
                    if (dsEscalation.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsEscalation.Tables[0].Rows[0]["Status"]);

                        if (Status == 1)
                        {
                            this.Bind_Retailer_Escalation_Grid();
                            //lblChangePasswordSuccess.Text = "Data saved successfully.";
                            //mpeChangePassword.Hide();
                        }
                        else if (Status == 2)
                        {
                            lblEscalationError.Text = "User already exists";
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