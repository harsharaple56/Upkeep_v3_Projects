using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Cocktail_World.Reports.Standard
{
    public partial class Abstract_Report : System.Web.UI.Page
    {
        CocktailWorld_Service.CocktailWorld_Service ObjCocktailWorld = new CocktailWorld_Service.CocktailWorld_Service();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            hdn_IsPostBack.Value = "yes";
            if (!IsPostBack)
            {
                Fetch_License();
                hdn_IsPostBack.Value = "no";
            }
        }

        private void Fetch_License()
        {
            DataSet ds = new DataSet();
            ds = ObjCocktailWorld.License_CRUD(0, string.Empty, string.Empty, LoggedInUserID, CompanyID, "R");
            ddlLicense.DataSource = ds.Tables[0];
            ddlLicense.DataTextField = "License_Name";
            ddlLicense.DataValueField = "License_ID";
            ddlLicense.DataBind();
            ddlLicense.Items.Insert(0, new ListItem("--Select License--", "0"));
            ddlLicense.SelectedIndex = 1;
        }

        public string Bind_Report()
        {
            string data = "";
            DataSet ds = new DataSet();
            int LicenseID = Convert.ToInt32(ddlLicense.SelectedValue);
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
                    DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture)).AddDays(-6);
                    From_Date = FromDate.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
                }

                if (end_date.Value != "")
                {
                    To_Date = Convert.ToString(end_date.Value);
                }
                else
                {
                    To_Date = DateTime.Now.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);
                }


                ds = ObjCocktailWorld.Fetch_Abstract_Report(LicenseID, From_Date, To_Date);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            string TPno = Convert.ToString(ds.Tables[0].Rows[i]["TPno"]);
                            string CategoryDescription = Convert.ToString(ds.Tables[0].Rows[i]["CategoryDescription"]);
                            string Alias = Convert.ToString(ds.Tables[0].Rows[i]["Alias"]);
                            string Quantity = Convert.ToString(ds.Tables[0].Rows[i]["Quantity"]);
                            string LicenseName = Convert.ToString(ds.Tables[0].Rows[i]["LicenseName"]);
                            string PeriodDesc = Convert.ToString(ds.Tables[0].Rows[i]["PeriodDesc"]);

                            data += "<tr>" +
                                 "<td>" + TPno + "</td>" +
                                "<td>" + CategoryDescription + "</td>" +
                                "<td>" + Alias + "</td>" +
                                "<td>" + Quantity + "</td>" +
                                "<td>" + LicenseName + "</td>" +
                                "<td>" + PeriodDesc + "</td>" +
                                "</tr>";
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }
    }
}