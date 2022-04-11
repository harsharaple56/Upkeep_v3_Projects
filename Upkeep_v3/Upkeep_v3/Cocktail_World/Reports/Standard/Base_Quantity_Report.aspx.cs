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
    public partial class Base_Quantity_Report : System.Web.UI.Page
    {
        CocktailWorld_Service.CocktailWorld_Service ObjCocktailWorld = new CocktailWorld_Service.CocktailWorld_Service();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            txtDate.Text = DateTime.Now.ToString("dd-MMMM-yyyy");
            if (!IsPostBack)
            {
                Fetch_License();
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
            string Date = txtDate.Text;

            try
            {
                ds = ObjCocktailWorld.Fetch_BaseQuantity_Report(LicenseID,Date);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            string Brand = Convert.ToString(ds.Tables[0].Rows[i]["Brand"]);
                            string Size = Convert.ToString(ds.Tables[0].Rows[i]["Size"]);
                            string ActualStock = Convert.ToString(ds.Tables[0].Rows[i]["ActualStock"]);
                            string BaseQty = Convert.ToString(ds.Tables[0].Rows[i]["BaseQty"]);
                            string ReorderLevel = Convert.ToString(ds.Tables[0].Rows[i]["ReorderLevel"]);
                            string OptimumLevel = Convert.ToString(ds.Tables[0].Rows[i]["OptimumLevel"]);

                            
                                data += "<tr>" +
                                    "<td>" + Brand + "</td>" +
                                    "<td>" + Size + "</td>" +
                                    "<td>" + ActualStock + "</td>" +
                                    "<td>" + BaseQty + "</td>" +
                                    "<td>" + ReorderLevel + "</td>" +
                                    "<td>" + OptimumLevel + "</td>" +
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