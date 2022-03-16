using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Cocktail_World.Reports
{
    public partial class Brand_Summary_Report : System.Web.UI.Page
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
        }

        public string Bind_Report()
        {
            string data = "";
            DataSet ds = new DataSet();
            string License = ddlLicense.SelectedValue;
            string From_Date = string.Empty;
            string To_Date = string.Empty;
            string Bill_No = string.Empty;
            string Brand = string.Empty;
            string Category = string.Empty;

            try
            {

                if (start_date.Value != "")
                {
                    From_Date = Convert.ToString(start_date.Value);
                }
                else
                {
                    DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yy", CultureInfo.InvariantCulture)).AddDays(-6);
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


                ds = ObjCocktailWorld.Fetch_BrandSummary_Report("1056", "14-Feb-2021", "14-Feb-2022", Brand, Category);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            string Category_name = Convert.ToString(ds.Tables[0].Rows[i]["Category"]);
                            string SubCategory = Convert.ToString(ds.Tables[0].Rows[i]["SubCategory"]);
                            string Brand_name = Convert.ToString(ds.Tables[0].Rows[i]["Brand"]);
                            string Size = Convert.ToString(ds.Tables[0].Rows[i]["Size"]);
                            string Opening = Convert.ToString(ds.Tables[0].Rows[i]["Opening"]);
                            string Purchase = Convert.ToString(ds.Tables[0].Rows[i]["Purchase"]);
                            string Total = Convert.ToString(ds.Tables[0].Rows[i]["Total"]);
                            string Sale = Convert.ToString(ds.Tables[0].Rows[i]["Sale"]);
                            string Closing = Convert.ToString(ds.Tables[0].Rows[i]["Closing"]);

                            data += "<tr>" +
                                    "<td>" + Category_name + "</td>" +
                                    "<td>" + SubCategory + "</td>" +
                                    "<td>" + Brand_name + "</td>" +
                                    "<td>" + Size + "</td>" +
                                    "<td>" + Opening + "</td>" +
                                    "<td>" + Purchase + "</td>" +
                                    "<td>" + Total + "</td>" +
                                    "<td>" + Sale + "</td>" +
                                    "<td>" + Closing + "</td>" +
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