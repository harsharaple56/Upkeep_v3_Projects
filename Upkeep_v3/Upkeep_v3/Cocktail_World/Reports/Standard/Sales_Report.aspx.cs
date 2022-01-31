using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Upkeep_v3.Cocktail_World.Reports
{
    public partial class Sales_Report : System.Web.UI.Page
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
                Fetch_Brands();
                Fetch_Category();
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

        private void Fetch_Brands()
        {
            //DataSet ds = new DataSet();
            //ds = ObjCocktailWorld.License_CRUD(0, string.Empty, string.Empty, LoggedInUserID, CompanyID, "R");
            //ddlBrand.DataSource = ds.Tables[0];
            //ddlBrand.DataTextField = "License_Name";
            //ddlBrand.DataValueField = "License_ID";
            //ddlBrand.DataBind();
            ddlBrand.Items.Insert(0, new ListItem("--Select License--", "0"));
            ddlBrand.SelectedIndex = 0;
        }

        private void Fetch_Category()
        {
            //DataSet ds = new DataSet();
            //ds = ObjCocktailWorld.License_CRUD(0, string.Empty, string.Empty, LoggedInUserID, CompanyID, "R");
            //ddlCategory.DataSource = ds.Tables[0];
            //ddlCategory.DataTextField = "License_Name";
            //ddlCategory.DataValueField = "License_ID";
            //ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("--Select License--", "0"));
            ddlCategory.SelectedIndex = 0;
        }

        public string Bind_Report()
        {
            string data = "";
            DataSet ds = new DataSet();
            string License = ddlLicense.SelectedValue;
            string From_Date = string.Empty;
            string To_Date = string.Empty;
            string Bill_No = string.Empty;
            string Brand = ddlBrand.SelectedValue;
            string Category = ddlCategory.SelectedValue;

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


                ds = ObjCocktailWorld.Fetch_Sales_Report(License, From_Date, To_Date, Brand, Category);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Sale_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Sale_ID"]);
                            string License_Name = Convert.ToString(ds.Tables[0].Rows[i]["License_Name"]);
                            string BillDate = Convert.ToString(ds.Tables[0].Rows[i]["BillDate"]);
                            string BillNo = Convert.ToString(ds.Tables[0].Rows[i]["Bill_No"]);
                            string Category_Name = string.Empty;
                            string Brand_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Brand_Desc"]);
                            string Size = Convert.ToString(ds.Tables[0].Rows[i]["Size"]);
                            string SPeg_Qty = Convert.ToString(ds.Tables[0].Rows[i]["SPeg_Qty"]);
                            string Speg_Rate = Convert.ToString(ds.Tables[0].Rows[i]["Speg_Rate"]);
                            string LPeg_Qty = Convert.ToString(ds.Tables[0].Rows[i]["LPeg_Qty"]);
                            string LPeg_Rate = Convert.ToString(ds.Tables[0].Rows[i]["LPeg_Rate"]);
                            string Bottle_Qty = Convert.ToString(ds.Tables[0].Rows[i]["Bottle_Qty"]);
                            string Bottle_Rate = Convert.ToString(ds.Tables[0].Rows[i]["Bottle_Rate"]);

                            data += "<tr>" +
                                    "<td>" + License_Name + "</td>" +
                                    "<td>" + BillDate + "</td>" +
                                    "<td>" + BillNo + "</td>" +
                                    "<td>" + Category_Name + "</td>" +
                                    "<td>" + Brand_Desc + "</td>" +
                                    "<td>" + Size + "</td>" +
                                    "<td>" + SPeg_Qty + "</td>" +
                                    "<td>" + Speg_Rate + "</td>" +
                                    "<td>" + LPeg_Qty + "</td>" +
                                    "<td>" + LPeg_Rate + "</td>" +
                                    "<td>" + Bottle_Qty + "</td>" +
                                    "<td>" + Bottle_Rate + "</td>" +
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