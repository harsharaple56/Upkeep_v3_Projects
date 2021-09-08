using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.Cocktail_World.Setup
{
    public partial class Licenses : System.Web.UI.Page
    {

        CocktailWorld_Service.CocktailWorld_Service ObjCocktailWorld = new CocktailWorld_Service.CocktailWorld_Service();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            if (!IsPostBack)
            {
                bindgrid();

                int License_ID = Convert.ToInt32(Request.QueryString["License_ID"]);
                if (License_ID > 0)
                {
                    UpdateLicense(License_ID);
                }
                int DelLicense_ID = Convert.ToInt32(Request.QueryString["DelLicense_ID"]);
                if (DelLicense_ID > 0)
                {
                    DeleteLicense(DelLicense_ID);
                }
            }

        }

        public void DeleteLicense(int License_ID)
        {
            try
            {
                ds = ds = ObjCocktailWorld.License(License_ID, string.Empty, string.Empty, LoggedInUserID, CompanyID, "D");
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Licenses.aspx"), false);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateLicense(int License_ID)
        {
            try
            {
                ds = ds = ObjCocktailWorld.License(License_ID, txtLicenseName.Text.Trim(),txtLicenseNo.Text.Trim(), LoggedInUserID, CompanyID, "F");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtLicenseName.Text = Convert.ToString(ds.Tables[0].Rows[0]["License_Name"]);
                        txtLicenseNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["License_No"]);
                        mpeLicenseMaster.Show();
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string bindgrid()
        {
            string data = "";
            try
            {
                ds = ds = ObjCocktailWorld.License(0, string.Empty, string.Empty, LoggedInUserID, CompanyID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int License_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["License_ID"]);
                            string License_Name = Convert.ToString(ds.Tables[0].Rows[i]["License_Name"]);
                            string License_No = Convert.ToString(ds.Tables[0].Rows[i]["License_No"]);

                            data += "<tr>";
                            data += "<td>" + License_Name + "</td>";
                            data += "<td>" + License_No + "</td>";
                            data += "<td>" +
                                "<a href='Licenses.aspx?License_ID=" + License_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  " +
                                "<a href='Licenses.aspx?DelLicense_ID=" + License_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> " +
                                "</td>";
                            data += "</tr>";

                        }
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

        protected void btnLicenseSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsCreate = new DataSet();
                int License_ID = 0;
                string Action = string.Empty;

                if (Convert.ToString(Request.QueryString["License_ID"]) != "")
                {
                    License_ID = Convert.ToInt32(Request.QueryString["License_ID"]);
                }

                if (License_ID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }
                dsCreate = ObjCocktailWorld.License(License_ID, txtLicenseName.Text.Trim(), txtLicenseNo.Text.Trim(), LoggedInUserID, CompanyID, Action);
                if (dsCreate.Tables[0].Rows.Count > 0)
                {
                    int Status = Convert.ToInt32(dsCreate.Tables[0].Rows[0]["Status"]);
                    if (Status == 0)
                    {

                    }
                    else if (Status == 1)
                    {
                        mpeLicenseMaster.Hide();
                        Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Licenses.aspx"), false);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCloseLicense_Click(object sender, EventArgs e)
        {
            txtLicenseName.Text = string.Empty;
            txtLicenseNo.Text = string.Empty;
            mpeLicenseMaster.Hide();
        }
    }
}