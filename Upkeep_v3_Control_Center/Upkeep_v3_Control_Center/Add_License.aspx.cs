using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
//using System.Web.Services.Protocols;

namespace Upkeep_v3_Control_Center
{
    public partial class Add_License : System.Web.UI.Page
    {
        UpkeepControlCenter_Service.UpkeepControlCenter_Service objUpkeepCC = new UpkeepControlCenter_Service.UpkeepControlCenter_Service();
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            if (!IsPostBack)
            {
                PopulateLicenseMasters();
                int LicenseID = Convert.ToInt32(Request.QueryString["LicenseID"]);
                int DelLicense_Id = Convert.ToInt32(Request.QueryString["DelLicense_Id"]);
                if (LicenseID > 0)
                {
                    Session["LicenseID"] = Convert.ToString(LicenseID);
                    bindLicense_Details(LicenseID);
                }
                if (DelLicense_Id > 0)
                {
                    DeleteLicense_Details(DelLicense_Id);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            
            string strClientID = string.Empty;
            int Company_ID = 0;
            int Subs_Pack_Id = 0;
            string strActivationDate = string.Empty;
            string strExpirationDate = string.Empty;
            string strDueDate = string.Empty;
            int UserLimit = 0;
            string strSelectedModules = string.Empty;
            string Action = "";
            
            try
            {
                int LicenseID = Convert.ToInt32(Session["LicenseID"]);
                if (LicenseID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                strClientID = txtClient_ID.Text.Trim();
                Company_ID = Convert.ToInt32(ddlcompanyName.SelectedValue);
                Subs_Pack_Id = Convert.ToInt32(ddlSubscription.SelectedValue);

                strActivationDate = ActivationDate.Text.Trim();

                DateTime Activationdt;

                if (DateTime.TryParseExact(strActivationDate, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out Activationdt))
                {
                    strActivationDate = Activationdt.ToString("dd/MMM/yyyy");
                }

                strExpirationDate = txtExpDate.Text.Trim();
                strDueDate = txtDueDate.Text.Trim();
                UserLimit = Convert.ToInt32(ddlUserLimit.SelectedValue);

                foreach (ListItem li in chkModules.Items)
                {
                    if (li.Selected == true)
                    {
                        strSelectedModules += li.Value + ",";
                    }
                }
                strSelectedModules = strSelectedModules.Substring(0, (strSelectedModules.Length - 1));

                ds = objUpkeepCC.License_CRUD(LicenseID, strClientID, Company_ID, Subs_Pack_Id, strActivationDate, strExpirationDate, strDueDate, UserLimit, strSelectedModules, LoggedInUserID, Action);

                
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 0)
                        {

                        }
                        else if (Status == 1)
                        {
                            Session["LicenseID"] = "";
                            Response.Redirect(Page.ResolveClientUrl("~/License_Management.aspx"), false);
                        }
                        else if (Status == 3)
                        {
                            lblErrorMsg.Text = "Client ID already exists";
                        }
                        else if (Status == 2)
                        {
                            lblErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                    }
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PopulateLicenseMasters()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = objUpkeepCC.PopulateLicenseMasters();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlcompanyName.DataSource = ds.Tables[0];
                        ddlcompanyName.DataTextField = "Company";
                        ddlcompanyName.DataValueField = "Company_ID";
                        ddlcompanyName.DataBind();
                        ddlcompanyName.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    if (ds.Tables.Count > 1)
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            ddlSubscription.DataSource = ds.Tables[1];
                            ddlSubscription.DataTextField = "Subs_Pack_Desc";
                            ddlSubscription.DataValueField = "Subs_Pack_Id";
                            ddlSubscription.DataBind();
                            ddlSubscription.Items.Insert(0, new ListItem("--Select--", "0"));
                        }
                    }
                    if (ds.Tables.Count > 2)
                    {
                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            ddlUserLimit.DataSource = ds.Tables[2];
                            ddlUserLimit.DataTextField = "User_Limit_No";
                            ddlUserLimit.DataValueField = "User_Limit_Id";
                            ddlUserLimit.DataBind();
                            ddlUserLimit.Items.Insert(0, new ListItem("--Select--", "0"));
                        }
                    }

                    if (ds.Tables.Count > 3)
                    {
                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            chkModules.DataSource = ds.Tables[3];
                            chkModules.DataTextField = "Module_Desc";
                            chkModules.DataValueField = "Module_Id";
                            chkModules.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void ActivationDate_TextChanged(object sender, EventArgs e)
        {
            FetchLicenseExpiryDate(Convert.ToInt32(ddlSubscription.SelectedValue), ActivationDate.Text.Trim());
        }

        public void FetchLicenseExpiryDate(int SubscriptionID, string ActivationDate)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objUpkeepCC.FetchLicenseExpiryDate(SubscriptionID, ActivationDate);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string strExpiryDate = Convert.ToString(ds.Tables[0].Rows[0]["Expiry_Date"]);
                        string strDueDate = Convert.ToString(ds.Tables[0].Rows[0]["Due_Date"]);

                        txtExpDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["Expiry_Date"]);
                        txtDueDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["Due_Date"]);

                        //string ExpiryDate = strExpiryDate.Substring(0, 10);
                        //DateTime Expirydt;

                        //if (DateTime.TryParseExact(ExpiryDate, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out Expirydt))
                        //{
                        //    txtExpDate.Text = Expirydt.ToString("dd/MMM/yyyy");
                        //}

                        //string DueDate = strDueDate.Substring(0, 10);
                        //DateTime Duedt;

                        //if (DateTime.TryParseExact(DueDate, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out Duedt))
                        //{
                        //    txtDueDate.Text = Duedt.ToString("dd/MMM/yyyy");
                        //}
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlSubscription_SelectedIndexChanged(object sender, EventArgs e)
        {
            FetchLicenseExpiryDate(Convert.ToInt32(ddlSubscription.SelectedValue), ActivationDate.Text.Trim());
        }

        public void bindLicense_Details(int LicenseID)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objUpkeepCC.License_CRUD(LicenseID, "", 0, 0, "", "", "", 0, "", LoggedInUserID, "R");

                if(ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["LicenseID"] = Convert.ToString(ds.Tables[0].Rows[0]["License_Id"]);
                        txtClient_ID.Text = Convert.ToString(ds.Tables[0].Rows[0]["Client_Id"]);
                        ddlcompanyName.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Company_ID"]);
                        ddlSubscription.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Subs_Pack_Id"]);

                        ddlSubscription.Attributes.Add("class", "form-control m-input disabled");
                        ddlSubscription.Attributes.Add("style", "pointer-events: none");




                        string Activation_Date = Convert.ToString(ds.Tables[0].Rows[0]["Activation_Date"]);

                        string Activation_Dt = Activation_Date.Substring(0, 10);

                        DateTime Activationdt;

                        if (DateTime.TryParseExact(Activation_Dt, "dd-MM-yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out Activationdt))
                        {
                            ActivationDate.Text = Activationdt.ToString("dd/MM/yyyy");
                        }

                        ActivationDate.Attributes.Add("class", "form-control m-input datetimepicker disabled");
                        ActivationDate.Attributes.Add("style", "pointer-events: none");

                        string Expiry_Date = Convert.ToString(ds.Tables[0].Rows[0]["Expiry_Date"]);
                        string ExpiryDate = Expiry_Date.Substring(0, 10);

                        DateTime Expirydt;

                        if (DateTime.TryParseExact(ExpiryDate, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out Expirydt))
                        {
                            txtExpDate.Text = Expirydt.ToString("dd/MMM/yyyy");
                        }

                        string Due_Date = Convert.ToString(ds.Tables[0].Rows[0]["Due_Date"]);
                        string DueDate = Due_Date.Substring(0, 10);
                        DateTime Duedt;

                        if (DateTime.TryParseExact(DueDate, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out Duedt))
                        {
                            txtDueDate.Text = Duedt.ToString("dd/MMM/yyyy");
                        }

                        ddlUserLimit.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["User_Limit_Id"]);

                        string Module_Ids = Convert.ToString(ds.Tables[0].Rows[0]["Modules"]);

                        int Is_Expire = Convert.ToInt32(ds.Tables[0].Rows[0]["Is_Expire"]);
                        int Is_Active = Convert.ToInt32(ds.Tables[0].Rows[0]["Is_Active"]);

                        List<string> result = Module_Ids.Split(',').ToList();
                        int iResult= 0;
                        
                            for (int i = 0; i < result.Count; i++)
                            {
                                iResult = Convert.ToInt32(result[i]);
                                chkModules.Items[iResult-1].Selected = true;
                            }

                        dvHeaderButton.Visible = true;
                        if (Is_Expire == 1 && Is_Active == 0)
                        {
                            lblStatus.Text = "Expired";
                            //btnDeactivate.Enabled = false;
                            btnDeactivate.Attributes.Add("class", "btn m-btn m-btn--icon m-btn--outline-2x m-btn--pill m-btn--air dark disabled");
                            btnDeactivate.Attributes.Add("style", "pointer-events: none");

                            btnActivate.Attributes.Add("class", "btn m-btn m-btn--icon m-btn--outline-2x m-btn--pill m-btn--air dark disabled");
                            btnActivate.Attributes.Add("style", "pointer-events: none");
                        }
                        else if (Is_Expire == 0 && Is_Active == 1)
                        {
                            lblStatus.Text = "Active";
                            //btnActivate.Enabled = false;
                            btnDeactivate.Attributes.Add("class", "btn btn-outline-danger m-btn m-btn--icon m-btn--outline-2x m-btn--pill m-btn--air");
                            btnDeactivate.Attributes.Add("style", "pointer-events: painted");

                            btnActivate.Attributes.Add("class", "btn m-btn m-btn--icon m-btn--outline-2x m-btn--pill m-btn--air dark disabled");
                            btnActivate.Attributes.Add("style", "pointer-events: none");
                        }

                       else if (Is_Expire == 0 && Is_Active == 0)
                        {
                            lblStatus.Text = "De-Active";
                            btnDeactivate.Attributes.Add("class", "btn m-btn m-btn--icon m-btn--outline-2x m-btn--pill m-btn--air dark disabled");
                            btnDeactivate.Attributes.Add("style", "pointer-events: none");

                            btnRenew.Attributes.Add("class", "btn m-btn m-btn--icon m-btn--outline-2x m-btn--pill m-btn--air dark disabled");
                            btnRenew.Attributes.Add("style", "pointer-events: none");

                            btnActivate.Attributes.Add("class", "btn btn-outline-success m-btn m-btn--icon m-btn--outline-2x m-btn--pill m-btn--air");
                            btnActivate.Attributes.Add("style", "pointer-events: painted");
                        }
                        //else if (Is_Active == 1)
                        //{
                        //    lblStatus.Text = "Active";
                        //    btnDeactivate.Attributes.Add("class", "btn m-btn m-btn--icon m-btn--outline-2x m-btn--pill m-btn--air dark disabled");
                        //    btnDeactivate.Attributes.Add("style", "pointer-events: painted");

                        //    btnRenew.Attributes.Add("class", "btn m-btn m-btn--icon m-btn--outline-2x m-btn--pill m-btn--air dark disabled");
                        //    btnRenew.Attributes.Add("style", "pointer-events: painted");
                        //}
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteLicense_Details(int LicenseID_Delete)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objUpkeepCC.License_CRUD(LicenseID_Delete, "", 0, 0, "", "", "", 0, "", LoggedInUserID, "D");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Redirect("~/License_Management.aspx", false);
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

        protected void btnDeactivate_Click(object sender, EventArgs e)
        {

        }

        protected void btnRenew_Click(object sender, EventArgs e)
        {
            ddlSubscription.Attributes.Add("class", "form-control m-input disabled");
            ddlSubscription.Attributes.Add("style", "pointer-events: painted");

            ActivationDate.Attributes.Add("class", "form-control m-input datetimepicker disabled");
            ActivationDate.Attributes.Add("style", "pointer-events: painted");

            ddlSubscription.SelectedValue = "0";
            ActivationDate.Text = "";
            txtExpDate.Text = "";
            txtDueDate.Text = "";
        }

        protected void btnActivate_Click(object sender, EventArgs e)
        {
            hdnLicenseAction.Value = "Activate";
            lblLicenseAction.Text = "Are you sure, you want to Activate this License ?";
            mpeLicenseStatus.Show();

        }

        protected void btnCloseLicense_Click(object sender, EventArgs e)
        {
            mpeLicenseStatus.Hide();
        }

        protected void btnLicenseStatusSave_Click(object sender, EventArgs e)
        {
            try
            {
                int LicenseID = 0;
                int LicenseAction = 0;
                if (Convert.ToString(Session["LicenseID"]) != "")
                {
                    LicenseID = Convert.ToInt32(Session["LicenseID"]);
                }
                if (Convert.ToString(hdnLicenseAction.Value) == "Activate")
                {
                    LicenseAction = 1; //Activate
                }
                else
                {
                    LicenseAction = 0; //De-Activate
                }

                DataSet dsLicenseAction = new DataSet();
                dsLicenseAction = objUpkeepCC.UpdatedsLicenseAction(LicenseID, LicenseAction, LoggedInUserID);

                Session["LicenseID"] = "";
                Response.Redirect(Page.ResolveClientUrl("~/License_Management.aspx"), false);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}