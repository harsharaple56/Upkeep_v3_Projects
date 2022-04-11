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
    public partial class Slow_Moving_Qty_Report : System.Web.UI.Page
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

        public string Bind_BrandReport()
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


                ds = ObjCocktailWorld.Fetch_CostValuation_Report(LicenseID, From_Date, To_Date);

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
                            string Opening = Convert.ToString(ds.Tables[0].Rows[i]["Opening"]);
                            string Purchase = Convert.ToString(ds.Tables[0].Rows[i]["Purchase"]);
                            string Total = Convert.ToString(ds.Tables[0].Rows[i]["Total"]);
                            string Sale = Convert.ToString(ds.Tables[0].Rows[i]["Sale"]);
                            string SalePercentage = Convert.ToString(ds.Tables[0].Rows[i]["SalePercentage"]);

                            data += "<tr>" +
                                 "<td>" + Category + "</td>" +
                                "<td>" + Subcategory + "</td>" +
                                "<td>" + Brand + "</td>" +
                                "<td>" + Size + "</td>" +
                                "<td>" + Opening + "</td>" +
                                "<td>" + Purchase + "</td>" +
                                "<td>" + Total + "</td>" +
                                "<td>" + Sale + "</td>" +
                                "<td>" + SalePercentage + "</td>" +
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

        public string Bind_CategoryReport()
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


                ds = ObjCocktailWorld.Fetch_SlowMovingQty_Report(LicenseID, From_Date, To_Date);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[1].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            string Category1 = Convert.ToString(ds.Tables[1].Rows[i]["Category"]);
                            string Size1 = Convert.ToString(ds.Tables[1].Rows[i]["Size"]);
                            string Opening1 = Convert.ToString(ds.Tables[1].Rows[i]["Opening"]);
                            string Purchase1 = Convert.ToString(ds.Tables[1].Rows[i]["Purchase"]);
                            string Total1 = Convert.ToString(ds.Tables[1].Rows[i]["Total"]);
                            string Sale1 = Convert.ToString(ds.Tables[1].Rows[i]["Sale"]);
                            string SalePercentage1 = Convert.ToString(ds.Tables[1].Rows[i]["SalePercentage"]);

                            data += "<tr>" +
                                 "<td>" + Category1 + "</td>" +
                                "<td>" + Size1 + "</td>" +
                                "<td>" + Opening1 + "</td>" +
                                "<td>" + Purchase1 + "</td>" +
                                "<td>" + Total1 + "</td>" +
                                "<td>" + Sale1 + "</td>" +
                                "<td>" + SalePercentage1 + "</td>" +
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