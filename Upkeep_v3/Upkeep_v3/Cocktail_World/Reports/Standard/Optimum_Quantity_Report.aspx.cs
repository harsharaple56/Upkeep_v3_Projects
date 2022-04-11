using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Cocktail_World.Reports.Standard
{
    public partial class Optimum_Quantity_Report : System.Web.UI.Page
    {
        CocktailWorld_Service.CocktailWorld_Service ObjCocktailWorld = new CocktailWorld_Service.CocktailWorld_Service();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Now.ToString("dd-MMMM-yyyy");
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
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

                ds = ObjCocktailWorld.Fetch_OptimumQuantity_Report(LicenseID, Date);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {

                            string Category = Convert.ToString(ds.Tables[0].Rows[i]["Category"]);
                            string Subcategory = Convert.ToString(ds.Tables[0].Rows[i]["Subcategory"]);
                            string Brand = Convert.ToString(ds.Tables[0].Rows[i]["Brand"]);
                            string Size = Convert.ToString(ds.Tables[0].Rows[i]["Size"]);
                            string Optimum_Level = Convert.ToString(ds.Tables[0].Rows[i]["Optimum Level"]);
                            string Opening = Convert.ToString(ds.Tables[0].Rows[i]["Opening"]);
                            string Purchase = Convert.ToString(ds.Tables[0].Rows[i]["Purchase"]);
                            string Sale = Convert.ToString(ds.Tables[0].Rows[i]["Sale"]);
                            string Closing = Convert.ToString(ds.Tables[0].Rows[i]["Closing"]);
                            string BaseQty = Convert.ToString(ds.Tables[0].Rows[i]["BaseQty"]);
                            string Reorder_Level = Convert.ToString(ds.Tables[0].Rows[i]["Reorder Level"]);
                            string Excess_Quantity = Convert.ToString(ds.Tables[0].Rows[i]["Excess Quantity"]);
                            string License_Name = Convert.ToString(ds.Tables[0].Rows[i]["LicenseDesc"]);
                            string License_No = Convert.ToString(ds.Tables[0].Rows[i]["LicenseNo"]);
                            string Address = Convert.ToString(ds.Tables[0].Rows[i]["address"]);

                            data += "<tr>" +
                                 "<td>" + Category + "</td>" +
                                "<td>" + Subcategory + "</td>" +
                                "<td>" + Brand + "</td>" +
                                "<td>" + Size + "</td>" +
                                "<td>" + Optimum_Level + "</td>" +
                                "<td>" + Opening + "</td>" +
                                "<td>" + Purchase + "</td>" +
                                "<td>" + Sale + "</td>" +
                                "<td>" + Closing + "</td>" +
                                "<td>" + BaseQty + "</td>" +
                                "<td>" + Reorder_Level + "</td>" +
                                "<td>" + Excess_Quantity + "</td>" +
                                "<td>" + License_Name + "</td>" +
                                "<td>" + License_No + "</td>" +
                                "<td>" + Address + "</td>" +
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