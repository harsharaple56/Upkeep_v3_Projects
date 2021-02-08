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

       
    }
}