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
    public partial class Purchase_Report : System.Web.UI.Page
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


                ds = ObjCocktailWorld.Fetch_Purchase_Report(License, From_Date, To_Date, Brand, Category);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Purchase_Detail_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Purchase_Detail_ID"]);
                            int Purchase_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Purchase_ID"]);
                            string TP_No = Convert.ToString(ds.Tables[0].Rows[i]["TP_No"]);
                            string Invoice_No = Convert.ToString(ds.Tables[0].Rows[i]["Invoice_No"]);
                            string Purchase_Date = Convert.ToString(ds.Tables[0].Rows[i]["Purchase_Date"]);
                            string License_Name = Convert.ToString(ds.Tables[0].Rows[i]["License_Name"]);
                            string Brand_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Brand_Desc"]);
                            string Size = Convert.ToString(ds.Tables[0].Rows[i]["Size"]);
                            string Speg_Rate = Convert.ToString(ds.Tables[0].Rows[i]["Speg_Rate"]);
                            string Bottle_Qty = Convert.ToString(ds.Tables[0].Rows[i]["Bottle_Qty"]);
                            string Bottle_Rate = Convert.ToString(ds.Tables[0].Rows[i]["Bottle_Rate"]);
                            string Free_Qty = Convert.ToString(ds.Tables[0].Rows[i]["Free_Qty"]);

                            data += "<tr>" +
                                    "<td>" + Purchase_Detail_ID + "</td>" +
                                    "<td>" + Purchase_ID + "</td>" +
                                    "<td>" + TP_No + "</td>" +
                                    "<td>" + Invoice_No + "</td>" +
                                    "<td>" + Purchase_Date + "</td>" +
                                    "<td>" + License_Name + "</td>" +
                                    "<td>" + Brand_Desc + "</td>" +
                                    "<td>" + Size + "</td>" +
                                    "<td>" + Speg_Rate + "</td>" +
                                    "<td>" + Bottle_Qty + "</td>" +
                                    "<td>" + Bottle_Rate + "</td>" +
                                    "<td>" + Free_Qty + "</td>" +
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