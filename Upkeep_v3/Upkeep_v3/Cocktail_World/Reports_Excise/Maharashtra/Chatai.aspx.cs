using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Cocktail_World.Reports_Excise.Maharashtra
{
    public partial class Chatai : System.Web.UI.Page
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
            Fetch_ChataiTable();

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

        public void Fetch_ChataiTable()
        {
            DataSet ds = new DataSet();
            int LicenseID = Convert.ToInt32(ddlLicense.SelectedValue);
            string From_Date = string.Empty;
            string To_Date = string.Empty;

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
            ds = ObjCocktailWorld.Fetch_Chatai_Report(LicenseID, From_Date, To_Date);
            Fetch_ChataiReport(ds.Tables[0]);
        }

        public void Fetch_ChataiReport(DataTable dt)
        {
            grdChataiReport.DataSource = null;
            grdChataiReport.DataBind();
            grdChataiReport.Columns.Clear();


            DataTable dtGrp = new DataTable();
            dtGrp = dt.DefaultView.ToTable(true, "date", "tpno");  // r7

            DataTable dtGrpCols = new DataTable();
            dtGrpCols = dt.DefaultView.ToTable(true, "catg", "siz");

            DataTable dtChataiTable = new DataTable();

            // ----------------------------------------------------------------
            DataTable dtt = new DataTable();


            BoundField tfield2 = new BoundField();
            tfield2.HeaderText = "Title";
            tfield2.DataField = "Title";
            grdChataiReport.Columns.Add(tfield2);
            dtt.Columns.Add("Title");
            BoundField tfield3 = new BoundField();
            tfield3.HeaderText = "Date";
            tfield3.DataField = "Date";
            grdChataiReport.Columns.Add(tfield3);
            dtt.Columns.Add("Date");
            BoundField tfield4 = new BoundField();
            tfield4.HeaderText = "TPNO";
            tfield4.DataField = "TPNO";
            grdChataiReport.Columns.Add(tfield4);
            dtt.Columns.Add("TPNO");
            // -----------------------------------------------------------------------------------------
            for (var index = 0; index <= dtGrpCols.Rows.Count - 1; index++)
            {
                if (index == 0)
                {
                    // ---------------------------------------------------------------------------------------------
                    BoundField tfield = new BoundField();
                    tfield.HeaderText = dtGrpCols.Rows[index]["catg"].ToString();
                    tfield.DataField = dtGrpCols.Rows[index]["catg"].ToString();
                    grdChataiReport.Columns.Add(tfield);
                    dtt.Columns.Add(dtGrpCols.Rows[index]["catg"].ToString());
                    ViewState["Category"] = dtGrpCols.Rows[index]["catg"];
                }

                else if (!(dtGrpCols.Rows[index - 1]["catg"] == dtGrpCols.Rows[index]["catg"]))
                {
                    // ----------------------------------------------------------------------------------------------
                    DataColumnCollection columns = dtt.Columns;
                    if (!columns.Contains(dtGrpCols.Rows[index]["catg"].ToString()))
                    {
                        BoundField tfield = new BoundField();
                        tfield.HeaderText = dtGrpCols.Rows[index]["catg"].ToString();
                        tfield.DataField = dtGrpCols.Rows[index]["catg"].ToString();
                        grdChataiReport.Columns.Add(tfield);

                        dtt.Columns.Add(dtGrpCols.Rows[index]["catg"].ToString());
                        ViewState["Category"] = dtGrpCols.Rows[index]["catg"];

                    }
                }
                // -----------------------------------------------------------
                BoundField tfield1 = new BoundField();
                tfield1.HeaderText = dtGrpCols.Rows[index]["siz"].ToString();
                tfield1.DataField = dtGrpCols.Rows[index]["siz"].ToString();
                grdChataiReport.Columns.Add(tfield1);

                if (ViewState["Category"].ToString() == "IMPORTED SPIRITS")
                {
                    dtt.Columns.Add(tfield1.DataField + "IS");
                    tfield1.HeaderText = tfield1.DataField + "IS";
                    tfield1.DataField = tfield1.DataField + "IS";
                }
                if (ViewState["Category"].ToString() == "SPIRITS")
                {
                    dtt.Columns.Add(tfield1.DataField + "SP");
                    tfield1.HeaderText = tfield1.DataField + "SP";
                    tfield1.DataField = tfield1.DataField + "SP";
                }
                if (ViewState["Category"].ToString() == "IMPORTED WINES")
                {
                    dtt.Columns.Add(tfield1.DataField + "IW");
                    tfield1.HeaderText = tfield1.DataField + "IW";
                    tfield1.DataField = tfield1.DataField + "IW";
                }
                if (ViewState["Category"].ToString() == "WINE")
                {
                    dtt.Columns.Add(tfield1.DataField + "WN");
                    tfield1.HeaderText = tfield1.DataField + "WN";
                    tfield1.DataField = tfield1.DataField + "WN";
                }
                if (ViewState["Category"].ToString() == "DRAFT BEER")
                {
                    dtt.Columns.Add(tfield1.DataField + "DB");
                    tfield1.HeaderText = tfield1.DataField + "DB";
                    tfield1.DataField = tfield1.DataField + "DB";
                }
                if (ViewState["Category"].ToString() == "MILD BEER")
                {
                    dtt.Columns.Add(tfield1.DataField + "MB");
                    tfield1.HeaderText = tfield1.DataField + "MB";
                    tfield1.DataField = tfield1.DataField + "MB";
                }
                if (ViewState["Category"].ToString() == "IMPORTED BEER")
                {
                    dtt.Columns.Add(tfield1.DataField + "IB");
                    tfield1.HeaderText = tfield1.DataField + "IB";
                    tfield1.DataField = tfield1.DataField + "IB";
                }

                if (ViewState["Category"].ToString() == "FERMENTED BEER")
                {
                    dtt.Columns.Add(tfield1.DataField + "FB");
                    tfield1.HeaderText = tfield1.DataField + "FB";
                    tfield1.DataField = tfield1.DataField + "FB";
                }


                if (ViewState["Category"].ToString() == "COUNTRY LIQUOR")
                {
                    dtt.Columns.Add(tfield1.DataField + "CL");
                    tfield1.HeaderText = tfield1.DataField + "CL";
                    tfield1.DataField = tfield1.DataField + "CL";
                }
            }
            // --------------------------------------------------------------------------------------------------------------------------
            for (var index = 0; index <= dtGrp.Rows.Count - 1; index++)
            {
                int dtindex = 0;


                // '''''''''IMPORTED SPIRITS''''''''''''''''
                DataView dvImportedSpirit2000;
                dvImportedSpirit2000 = new DataView(dt);
                dvImportedSpirit2000.RowFilter = "catg='IMPORTED SPIRITS' And siz='2000' And date='" + dtGrp.Rows[index]["date"] + "' ";
                DataTable dtImportedSpirit2000 = dvImportedSpirit2000.ToTable();

                DataView dvImportedSpirit1000;
                dvImportedSpirit1000 = new DataView(dt);
                dvImportedSpirit1000.RowFilter = "catg='IMPORTED SPIRITS' And siz='1000' And date='" + dtGrp.Rows[index]["date"] + "' ";
                DataTable dtImportedSpirit1000 = dvImportedSpirit1000.ToTable();

                DataView dvImportedSpirit700;
                dvImportedSpirit700 = new DataView(dt);
                dvImportedSpirit700.RowFilter = "catg='IMPORTED SPIRITS' And siz='700' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedSpirit700 = dvImportedSpirit700.ToTable();

                DataView dvImportedSpirit750;
                dvImportedSpirit750 = new DataView(dt);
                dvImportedSpirit750.RowFilter = "catg='IMPORTED SPIRITS' And siz='750' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedSpirit750 = dvImportedSpirit750.ToTable();

                DataView dvImportedSpirit650;
                dvImportedSpirit650 = new DataView(dt);
                dvImportedSpirit650.RowFilter = "catg='IMPORTED SPIRITS' And siz='650' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedSpirit650 = dvImportedSpirit650.ToTable();

                DataView dvImportedSpirit375;
                dvImportedSpirit375 = new DataView(dt);
                dvImportedSpirit375.RowFilter = "catg='IMPORTED SPIRITS' And siz='375' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedSpirit375 = dvImportedSpirit375.ToTable();

                DataView dvImportedSpirit330;
                dvImportedSpirit330 = new DataView(dt);
                dvImportedSpirit330.RowFilter = "catg='IMPORTED SPIRITS' And siz='330' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedSpirit330 = dvImportedSpirit330.ToTable();

                DataView dvImportedSpirit325;
                dvImportedSpirit325 = new DataView(dt);
                dvImportedSpirit325.RowFilter = "catg='IMPORTED SPIRITS' And siz='325' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedSpirit325 = dvImportedSpirit325.ToTable();

                DataView dvImportedSpirit280;
                dvImportedSpirit280 = new DataView(dt);
                dvImportedSpirit280.RowFilter = "catg='IMPORTED SPIRITS' And siz='280' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedSpirit280 = dvImportedSpirit280.ToTable();


                DataView dvImportedSpirit180;
                dvImportedSpirit180 = new DataView(dt);
                dvImportedSpirit180.RowFilter = "catg='IMPORTED SPIRITS' And siz='180' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedSpirit180 = dvImportedSpirit180.ToTable();

                DataView dvImportedSpirit60;
                dvImportedSpirit60 = new DataView(dt);
                dvImportedSpirit60.RowFilter = "catg='IMPORTED SPIRITS' And siz='60' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedSpirit60 = dvImportedSpirit60.ToTable();


                DataView dvImportedSpirit200;
                dvImportedSpirit200 = new DataView(dt);
                dvImportedSpirit200.RowFilter = "catg='IMPORTED SPIRITS' And siz='200' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedSpirit200 = dvImportedSpirit200.ToTable();

                DataView dvImportedSpirit500;
                dvImportedSpirit500 = new DataView(dt);
                dvImportedSpirit500.RowFilter = "catg='IMPORTED SPIRITS' And siz='500' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedSpirit500 = dvImportedSpirit500.ToTable();


                DataView dvImportedSpirit1750;
                dvImportedSpirit1750 = new DataView(dt);
                dvImportedSpirit1750.RowFilter = "catg='IMPORTED SPIRITS' And siz='1750' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedSpirit1750 = dvImportedSpirit1750.ToTable();

                DataView dvImportedSpirit50;
                dvImportedSpirit50 = new DataView(dt);
                dvImportedSpirit50.RowFilter = "catg='IMPORTED SPIRITS' And siz='50' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedSpirit50 = dvImportedSpirit50.ToTable();

                DataView dvImportedSpirit900;
                dvImportedSpirit900 = new DataView(dt);
                dvImportedSpirit900.RowFilter = "catg='IMPORTED SPIRITS' And siz='900' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedSpirit900 = dvImportedSpirit900.ToTable();
                // -------------------------------------------
                // --------------------Spirits-----------------------
                DataView dvSPIRITS1000;
                dvSPIRITS1000 = new DataView(dt);
                dvSPIRITS1000.RowFilter = "catg='SPIRITS' And siz='1000' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtSPIRITS1000 = dvSPIRITS1000.ToTable();

                DataView dvSPIRITS700;
                dvSPIRITS700 = new DataView(dt);
                dvSPIRITS700.RowFilter = "catg='SPIRITS' And siz='700' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtSPIRITS700 = dvSPIRITS700.ToTable();

                DataView dvSPIRITS750;
                dvSPIRITS750 = new DataView(dt);
                dvSPIRITS750.RowFilter = "catg='SPIRITS' And siz='750' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtSPIRITS750 = dvSPIRITS750.ToTable();

                DataView dvSPIRITS600;
                dvSPIRITS600 = new DataView(dt);
                dvSPIRITS600.RowFilter = "catg='SPIRITS' And siz='600' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtSPIRITS600 = dvSPIRITS600.ToTable();

                DataView dvSPIRITS650;
                dvSPIRITS650 = new DataView(dt);
                dvSPIRITS650.RowFilter = "catg='SPIRITS' And siz='650' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtSPIRITS650 = dvSPIRITS650.ToTable();

                DataView dvSPIRITS375;
                dvSPIRITS375 = new DataView(dt);
                dvSPIRITS375.RowFilter = "catg='SPIRITS' And siz='375' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtSPIRITS375 = dvSPIRITS375.ToTable();

                DataView dvSPIRITS330;
                dvSPIRITS330 = new DataView(dt);
                dvSPIRITS330.RowFilter = "catg='SPIRITS' And siz='330' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtSPIRITS330 = dvSPIRITS330.ToTable();

                DataView dvSPIRITS325;
                dvSPIRITS325 = new DataView(dt);
                dvSPIRITS325.RowFilter = "catg='SPIRITS' And siz='325' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtSPIRITS325 = dvSPIRITS325.ToTable();

                DataView dvSPIRITS180;
                dvSPIRITS180 = new DataView(dt);
                dvSPIRITS180.RowFilter = "catg='SPIRITS' And siz='180' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtSPIRITS180 = dvSPIRITS180.ToTable();

                DataView dvSPIRITS60;
                dvSPIRITS60 = new DataView(dt);
                dvSPIRITS60.RowFilter = "catg='SPIRITS' And siz='60' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtSPIRITS60 = dvSPIRITS60.ToTable();


                DataView dvSPIRITS275;
                dvSPIRITS275 = new DataView(dt);
                dvSPIRITS275.RowFilter = "catg='SPIRITS' And siz='275' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtSPIRITS275 = dvSPIRITS275.ToTable();

                DataView dvSPIRITS50;
                dvSPIRITS50 = new DataView(dt);
                dvSPIRITS50.RowFilter = "catg='SPIRITS' And siz='50' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtSPIRITS50 = dvSPIRITS50.ToTable();

                DataView dvSPIRITS90;
                dvSPIRITS90 = new DataView(dt);
                dvSPIRITS90.RowFilter = "catg='SPIRITS' And siz='90' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtSPIRITS90 = dvSPIRITS90.ToTable();

                DataView dvSPIRITS2000;
                dvSPIRITS2000 = new DataView(dt);
                dvSPIRITS2000.RowFilter = "catg='SPIRITS' And siz='2000' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtSPIRITS2000 = dvSPIRITS2000.ToTable();

                DataView dvSPIRITS500;
                dvSPIRITS500 = new DataView(dt);
                dvSPIRITS500.RowFilter = "catg='SPIRITS' And siz='500' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtSPIRITS500 = dvSPIRITS500.ToTable();

                // ------------------------------------------------------
                // ----------------------IMPORTED WINES------------------
                DataView dvImportedWines1000;
                dvImportedWines1000 = new DataView(dt);
                dvImportedWines1000.RowFilter = "catg='IMPORTED WINES' And siz='1000' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedWines1000 = dvImportedWines1000.ToTable();

                DataView dvImportedWines700;
                dvImportedWines700 = new DataView(dt);
                dvImportedWines700.RowFilter = "catg='IMPORTED WINES' And siz='700' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedWines700 = dvImportedWines700.ToTable();

                DataView dvImportedWines750;
                dvImportedWines750 = new DataView(dt);
                dvImportedWines750.RowFilter = "catg='IMPORTED WINES' And siz='750' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedWines750 = dvImportedWines750.ToTable();

                DataView dvImportedWines650;
                dvImportedWines650 = new DataView(dt);
                dvImportedWines650.RowFilter = "catg='IMPORTED WINES' And siz='650' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedWines650 = dvImportedWines650.ToTable();

                DataView dvImportedWines375;
                dvImportedWines375 = new DataView(dt);
                dvImportedWines375.RowFilter = "catg='IMPORTED WINES' And siz='375' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedWines375 = dvImportedWines375.ToTable();

                DataView dvImportedWines330;
                dvImportedWines330 = new DataView(dt);
                dvImportedWines330.RowFilter = "catg='IMPORTED WINES' And siz='330' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedWines330 = dvImportedWines330.ToTable();

                DataView dvImportedWines325;
                dvImportedWines325 = new DataView(dt);
                dvImportedWines325.RowFilter = "catg='IMPORTED WINES' And siz='325' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedWines325 = dvImportedWines325.ToTable();

                DataView dvImportedWines180;
                dvImportedWines180 = new DataView(dt);
                dvImportedWines180.RowFilter = "catg='IMPORTED WINES' And siz='180' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedWines180 = dvImportedWines180.ToTable();

                DataView dvImportedWines60;
                dvImportedWines60 = new DataView(dt);
                dvImportedWines60.RowFilter = "catg='IMPORTED WINES' And siz='60' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedWines60 = dvImportedWines60.ToTable();

                DataView dvImportedWines720;
                dvImportedWines720 = new DataView(dt);
                dvImportedWines720.RowFilter = "catg='IMPORTED WINES' And siz='720' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedWines720 = dvImportedWines720.ToTable();

                DataView dvImportedWines300;
                dvImportedWines300 = new DataView(dt);
                dvImportedWines300.RowFilter = "catg='IMPORTED WINES' And siz='300' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedWines300 = dvImportedWines300.ToTable();


                DataView dvImportedWines1500;
                dvImportedWines1500 = new DataView(dt);
                dvImportedWines1500.RowFilter = "catg='IMPORTED WINES' And siz='1500' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedWines1500 = dvImportedWines1500.ToTable();

                DataView dvImportedWines1800;
                dvImportedWines1800 = new DataView(dt);
                dvImportedWines1800.RowFilter = "catg='IMPORTED WINES' And siz='1800' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedWines1800 = dvImportedWines1800.ToTable();

                DataView dvImportedWines200;
                dvImportedWines200 = new DataView(dt);
                dvImportedWines200.RowFilter = "catg='IMPORTED WINES' And siz='200' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedWines200 = dvImportedWines200.ToTable();


                // Added by Samvedna on[19-03-2020]
                DataView dvImportedWines900;
                dvImportedWines900 = new DataView(dt);
                dvImportedWines900.RowFilter = "catg='IMPORTED WINES' And siz='900' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedWines900 = dvImportedWines900.ToTable();

                DataView dvImportedWines187;
                dvImportedWines187 = new DataView(dt);
                dvImportedWines187.RowFilter = "catg='IMPORTED WINES' And siz='187' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImportedWines187 = dvImportedWines187.ToTable();

                // -----------------------------------------------------------
                // ---------------------------WINE----------------------------
                DataView dvWine1000;
                dvWine1000 = new DataView(dt);
                dvWine1000.RowFilter = "catg='WINE' And siz='1000' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtWine1000 = dvWine1000.ToTable();

                DataView dvWine700;
                dvWine700 = new DataView(dt);
                dvWine700.RowFilter = "catg='WINE' And siz='700' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtWine700 = dvWine700.ToTable();

                DataView dvWine750;
                dvWine750 = new DataView(dt);
                dvWine750.RowFilter = "catg='WINE' And siz='750' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtWine750 = dvWine750.ToTable();

                DataView dvWine650;
                dvWine650 = new DataView(dt);
                dvWine650.RowFilter = "catg='WINE' And siz='650' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtWine650 = dvWine650.ToTable();

                DataView dvWine375;
                dvWine375 = new DataView(dt);
                dvWine375.RowFilter = "catg='WINE' And siz='375' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtWine375 = dvWine375.ToTable();

                DataView dvWine330;
                dvWine330 = new DataView(dt);
                dvWine330.RowFilter = "catg='WINE' And siz='330' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtWine330 = dvWine330.ToTable();

                DataView dvWine325;
                dvWine325 = new DataView(dt);
                dvWine325.RowFilter = "catg='WINE' And siz='325' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtWine325 = dvWine325.ToTable();

                DataView dvWine180;
                dvWine180 = new DataView(dt);
                dvWine180.RowFilter = "catg='WINE' And siz='180' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtWine180 = dvWine180.ToTable();

                DataView dvWine60;
                dvWine60 = new DataView(dt);
                dvWine60.RowFilter = "catg='WINE' And siz='60' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtWine60 = dvWine60.ToTable();

                DataView dvWine1500;
                dvWine1500 = new DataView(dt);
                dvWine1500.RowFilter = "catg='WINE' And siz='1500' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtWine1500 = dvWine1500.ToTable();

                DataView dvWine720;
                dvWine720 = new DataView(dt);
                dvWine720.RowFilter = "catg='WINE' And siz='720' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtWine720 = dvWine720.ToTable();


                DataView dvWine250;
                dvWine250 = new DataView(dt);
                dvWine250.RowFilter = "catg='WINE' And siz='250' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtWine250 = dvWine250.ToTable();

                // --------------------------------------------------------
                // ---------------------------DRAFT BEER-----------------------------------
                DataView dvDraftBeer1000;
                dvDraftBeer1000 = new DataView(dt);
                dvDraftBeer1000.RowFilter = "catg='DRAFT BEER' And siz='1000' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtDraftBeer1000 = dvDraftBeer1000.ToTable();

                DataView dvDraftBeer700;
                dvDraftBeer700 = new DataView(dt);
                dvDraftBeer700.RowFilter = "catg='DRAFT BEER' And siz='700' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtDraftBeer700 = dvDraftBeer700.ToTable();

                DataView dvDraftBeer750;
                dvDraftBeer750 = new DataView(dt);
                dvDraftBeer750.RowFilter = "catg='DRAFT BEER' And siz='750' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtDraftBeer750 = dvDraftBeer750.ToTable();

                DataView dvDraftBeer650;
                dvDraftBeer650 = new DataView(dt);
                dvDraftBeer650.RowFilter = "catg='DRAFT BEER' And siz='650' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtDraftBeer650 = dvDraftBeer650.ToTable();

                DataView dvDraftBeer375;
                dvDraftBeer375 = new DataView(dt);
                dvDraftBeer375.RowFilter = "catg='DRAFT BEER' And siz='375' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtDraftBeer375 = dvDraftBeer375.ToTable();

                DataView dvDraftBeer330;
                dvDraftBeer330 = new DataView(dt);
                dvDraftBeer330.RowFilter = "catg='DRAFT BEER' And siz='330' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtDraftBeer330 = dvDraftBeer330.ToTable();

                DataView dvDraftBeer355;
                dvDraftBeer355 = new DataView(dt);
                dvDraftBeer355.RowFilter = "catg='DRAFT BEER' And siz='355' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtDraftBeer355 = dvDraftBeer355.ToTable();

                DataView dvDraftBeer325;
                dvDraftBeer325 = new DataView(dt);
                dvDraftBeer325.RowFilter = "catg='DRAFT BEER' And siz='325' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtDraftBeer325 = dvDraftBeer325.ToTable();

                DataView dvDraftBeer180;
                dvDraftBeer180 = new DataView(dt);
                dvDraftBeer180.RowFilter = "catg='DRAFT BEER' And siz='180' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtDraftBeer180 = dvDraftBeer180.ToTable();

                DataView dvDraftBeer60;
                dvDraftBeer60 = new DataView(dt);
                dvDraftBeer60.RowFilter = "catg='DRAFT BEER' And siz='60' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtDraftBeer60 = dvDraftBeer60.ToTable();

                DataView dvDraftBeer1500;
                dvDraftBeer1500 = new DataView(dt);
                dvDraftBeer1500.RowFilter = "catg='DRAFT BEER' And siz='1500' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtDraftBeer1500 = dvDraftBeer1500.ToTable();
                // ------------------------------------------------------
                // ------------------------------MILD BEER---------------
                DataView dvMildBeer1000;
                dvMildBeer1000 = new DataView(dt);
                dvMildBeer1000.RowFilter = "catg='MILD BEER' And siz='1000' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtMildBeer1000 = dvMildBeer1000.ToTable();

                DataView dvMildBeer700;
                dvMildBeer700 = new DataView(dt);
                dvMildBeer700.RowFilter = "catg='MILD BEER' And siz='700' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtMildBeer700 = dvMildBeer700.ToTable();

                DataView dvMildBeer750;
                dvMildBeer750 = new DataView(dt);
                dvMildBeer750.RowFilter = "catg='MILD BEER' And siz='750' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtMildBeer750 = dvMildBeer750.ToTable();

                DataView dvMildBeer650;
                dvMildBeer650 = new DataView(dt);
                dvMildBeer650.RowFilter = "catg='MILD BEER' And siz='650' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtMildBeer650 = dvMildBeer650.ToTable();

                DataView dvMildBeer375;
                dvMildBeer375 = new DataView(dt);
                dvMildBeer375.RowFilter = "catg='MILD BEER' And siz='375' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtMildBeer375 = dvMildBeer375.ToTable();

                DataView dvMildBeer330;
                dvMildBeer330 = new DataView(dt);
                dvMildBeer330.RowFilter = "catg='MILD BEER' And siz='330' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtMildBeer330 = dvMildBeer330.ToTable();

                DataView dvMildBeer325;
                dvMildBeer325 = new DataView(dt);
                dvMildBeer325.RowFilter = "catg='MILD BEER' And siz='325' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtMildBeer325 = dvMildBeer325.ToTable();

                DataView dvMildBeer275;
                dvMildBeer275 = new DataView(dt);
                dvMildBeer275.RowFilter = "catg='MILD BEER' And siz='275' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtMildBeer275 = dvMildBeer275.ToTable();

                DataView dvMildBeer500;
                dvMildBeer500 = new DataView(dt);
                dvMildBeer500.RowFilter = "catg='MILD BEER' And siz='500' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtMildBeer500 = dvMildBeer500.ToTable();


                // ----------------------------------------------------------------------------------------------------------------------
                // ----------------------Imported Beer-----------------------------------
                DataView dvImporteddBeer355;
                dvImporteddBeer355 = new DataView(dt);
                dvImporteddBeer355.RowFilter = "catg='IMPORTED BEER' And siz='355' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImporteddBeer355 = dvImporteddBeer355.ToTable();

                DataView dvImporteddBeer330;
                dvImporteddBeer330 = new DataView(dt);
                dvImporteddBeer330.RowFilter = "catg='IMPORTED BEER' And siz='330' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImporteddBeer330 = dvImporteddBeer330.ToTable();

                DataView dvImporteddBeer300;
                dvImporteddBeer300 = new DataView(dt);
                dvImporteddBeer300.RowFilter = "catg='IMPORTED BEER' And siz='300' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImporteddBeer300 = dvImporteddBeer300.ToTable();

                DataView dvImporteddBeer1000;
                dvImporteddBeer1000 = new DataView(dt);
                dvImporteddBeer1000.RowFilter = "catg='IMPORTED BEER' And siz='1000' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImporteddBeer1000 = dvImporteddBeer1000.ToTable();

                DataView dvImporteddBeer500;
                dvImporteddBeer500 = new DataView(dt);
                dvImporteddBeer500.RowFilter = "catg='IMPORTED BEER' And siz='500' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtImporteddBeer500 = dvImporteddBeer500.ToTable();


                // ----------------------------------------------------------------------------------------------------------------------
                // ----------------------FERMENTED BEER-----------------------------------
                DataView dvFermenteddBeer330;
                dvFermenteddBeer330 = new DataView(dt);
                dvFermenteddBeer330.RowFilter = "catg='FERMENTED BEER' And siz='330' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtFermenteddBeer330 = dvFermenteddBeer330.ToTable();

                DataView dvFermenteddBeer500;
                dvFermenteddBeer500 = new DataView(dt);
                dvFermenteddBeer500.RowFilter = "catg='FERMENTED BEER' And siz='500' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtFermenteddBeer500 = dvFermenteddBeer500.ToTable();

                DataView dvFermenteddBeer650;
                dvFermenteddBeer650 = new DataView(dt);
                dvFermenteddBeer650.RowFilter = "catg='FERMENTED BEER' And siz='650' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtFermenteddBeer650 = dvFermenteddBeer650.ToTable();


                // ----------------------COUNTRY LIQOUR-----------------------------------
                DataView dvCountryLiqour750;
                dvCountryLiqour750 = new DataView(dt);
                dvCountryLiqour750.RowFilter = "catg='COUNTRY LIQUOR' And siz='750' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtCountryLiqour750 = dvCountryLiqour750.ToTable();

                DataView dvCountryLiqour375;
                dvCountryLiqour375 = new DataView(dt);
                dvCountryLiqour375.RowFilter = "catg='COUNTRY LIQUOR' And siz='375' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtCountryLiqour375 = dvCountryLiqour375.ToTable();

                DataView dvCountryLiqour180;
                dvCountryLiqour180 = new DataView(dt);
                dvCountryLiqour180.RowFilter = "catg='COUNTRY LIQUOR' And siz='180' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtCountryLiqour180 = dvCountryLiqour180.ToTable();

                DataView dvCountryLiqour90;
                dvCountryLiqour90 = new DataView(dt);
                dvCountryLiqour90.RowFilter = "catg='COUNTRY LIQUOR' And siz='90' And date='" + dtGrp.Rows[index]["date"] + "'";
                DataTable dtCountryLiqour90 = dvCountryLiqour90.ToTable();



                // ----------------------------------------------------------------------------------------------------------------------
                // ------Opening-------------
                DataRow dr = null/* TODO Change to default(_) if this is not a reference type */;
                dr = dtt.NewRow();
                dr["Title"] = "Opening";
                dr["Date"] = dtGrp.Rows[index]["date"];


                // -------------------Imported Spirits------------
                if ((dtt.Columns.Contains("2000IS") & dtImportedSpirit2000.Rows.Count > 0))
                    dr["2000IS"] = dtImportedSpirit2000.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("1000IS") & dtImportedSpirit1000.Rows.Count > 0))
                    dr["1000IS"] = dtImportedSpirit1000.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("700IS") & dtImportedSpirit700.Rows.Count > 0))
                    dr["700IS"] = dtImportedSpirit700.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("750IS") & dtImportedSpirit750.Rows.Count > 0))
                    dr["750IS"] = dtImportedSpirit750.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("650IS") & dtImportedSpirit650.Rows.Count > 0))
                    dr["650IS"] = dtImportedSpirit650.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("375IS") & dtImportedSpirit375.Rows.Count > 0))
                    dr["375IS"] = dtImportedSpirit375.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("330IS") & dtImportedSpirit330.Rows.Count > 0))
                    dr["330IS"] = dtImportedSpirit330.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("325IS") & dtImportedSpirit325.Rows.Count > 0))
                    dr["325IS"] = dtImportedSpirit325.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("180IS") & dtImportedSpirit180.Rows.Count > 0))
                    dr["180IS"] = dtImportedSpirit180.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("60IS") & dtImportedSpirit60.Rows.Count > 0))
                    dr["60IS"] = dtImportedSpirit60.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("280IS") & dtImportedSpirit280.Rows.Count > 0))
                    dr["280IS"] = dtImportedSpirit280.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("200IS") & dtImportedSpirit200.Rows.Count > 0))
                    dr["200IS"] = dtImportedSpirit200.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("500IS") & dtImportedSpirit500.Rows.Count > 0))
                    dr["500IS"] = dtImportedSpirit500.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("1750IS") & dtImportedSpirit1750.Rows.Count > 0))
                    dr["1750IS"] = dtImportedSpirit1750.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("50IS") & dtImportedSpirit50.Rows.Count > 0))
                    dr["50IS"] = dtImportedSpirit50.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("900IS") & dtImportedSpirit900.Rows.Count > 0))
                    dr["900IS"] = dtImportedSpirit900.Rows[0]["totsale"].ToString();
                // ------------------------------------------------------
                // -----------------------SPIRITS------------------------


                if ((dtt.Columns.Contains("1000SP") & dtSPIRITS1000.Rows.Count > 0))
                    dr["1000SP"] = dtSPIRITS1000.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("700SP") & dtSPIRITS700.Rows.Count > 0))
                    dr["700SP"] = dtSPIRITS700.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("750SP") & dtSPIRITS750.Rows.Count > 0))
                    dr["750SP"] = dtSPIRITS750.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("650SP") & dtSPIRITS650.Rows.Count > 0))
                    dr["650SP"] = dtSPIRITS650.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("600SP") & dtSPIRITS600.Rows.Count > 0))
                    dr["600SP"] = dtSPIRITS600.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("375SP") & dtSPIRITS375.Rows.Count > 0))
                    dr["375SP"] = dtSPIRITS375.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("330SP") & dtSPIRITS330.Rows.Count > 0))
                    dr["330SP"] = dtSPIRITS330.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("325SP") & dtSPIRITS325.Rows.Count > 0))
                    dr["325SP"] = dtSPIRITS325.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("180SP") & dtSPIRITS180.Rows.Count > 0))
                    dr["180SP"] = dtSPIRITS180.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("60SP") & dtSPIRITS60.Rows.Count > 0))
                    dr["60SP"] = dtSPIRITS60.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("275SP") & dtSPIRITS275.Rows.Count > 0))
                    dr["275SP"] = dtSPIRITS275.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("50SP") & dtSPIRITS50.Rows.Count > 0))
                    dr["50SP"] = dtSPIRITS50.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("90SP") & dtSPIRITS90.Rows.Count > 0))
                    dr["90SP"] = dtSPIRITS90.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("2000SP") & dtSPIRITS2000.Rows.Count > 0))
                    dr["2000SP"] = dtSPIRITS2000.Rows[0]["totsale"].ToString();


                if ((dtt.Columns.Contains("500SP") & dtSPIRITS500.Rows.Count > 0))
                    dr["500SP"] = dtSPIRITS500.Rows[0]["totsale"].ToString();


                // -----------------------------------------------
                // ---------------------Imported Wine-------------
                if ((dtt.Columns.Contains("1000IW") & dtImportedWines1000.Rows.Count > 0))
                    dr["1000IW"] = dtImportedWines1000.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("700IW") & dtImportedWines700.Rows.Count > 0))
                    dr["700IW"] = dtImportedWines700.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("750IW") & dtImportedWines750.Rows.Count > 0))
                    dr["750IW"] = dtImportedWines750.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("650IW") & dtImportedWines650.Rows.Count > 0))
                    dr["650IW"] = dtImportedWines650.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("375IW") & dtImportedWines375.Rows.Count > 0))
                    dr["375IW"] = dtImportedWines375.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("330IW") & dtImportedWines330.Rows.Count > 0))
                    dr["330IW"] = dtImportedWines330.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("325IW") & dtImportedWines325.Rows.Count > 0))
                    dr["325IW"] = dtImportedWines325.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("180IW") & dtImportedWines180.Rows.Count > 0))
                    dr["180IW"] = dtImportedWines180.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("60IW") & dtImportedWines60.Rows.Count > 0))
                    dr["60IW"] = dtImportedWines60.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("720IW") & dtImportedWines720.Rows.Count > 0))
                    dr["720IW"] = dtImportedWines720.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("300IW") & dtImportedWines300.Rows.Count > 0))
                    dr["300IW"] = dtImportedWines300.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("1500IW") & dtImportedWines1500.Rows.Count > 0))
                    dr["1500IW"] = dtImportedWines1500.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("1800IW") & dtImportedWines1800.Rows.Count > 0))
                    dr["1800IW"] = dtImportedWines1800.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("200IW") & dtImportedWines200.Rows.Count > 0))
                    dr["200IW"] = dtImportedWines200.Rows[0]["totsale"].ToString();

                if ((dtt.Columns.Contains("900IW") & dtImportedWines900.Rows.Count > 0))
                    dr["900IW"] = dtImportedWines900.Rows[0]["totsale"].ToString();

                if ((dtt.Columns.Contains("187IW") & dtImportedWines187.Rows.Count > 0))
                    dr["187IW"] = dtImportedWines187.Rows[0]["totsale"].ToString();
                // --------------------------------------------------
                // -----------------------Wine-----------------------
                if ((dtt.Columns.Contains("1000WN") & dtWine1000.Rows.Count > 0))
                    dr["1000WN"] = dtWine1000.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("700WN") & dtWine700.Rows.Count > 0))
                    dr["700WN"] = dtWine700.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("750WN") & dtWine750.Rows.Count > 0))
                    dr["750WN"] = dtWine750.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("650WN") & dtWine650.Rows.Count > 0))
                    dr["650WN"] = dtWine650.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("375WN") & dtWine375.Rows.Count > 0))
                    dr["375WN"] = dtWine375.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("330WN") & dtWine330.Rows.Count > 0))
                    dr["330WN"] = dtWine330.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("325WN") & dtWine325.Rows.Count > 0))
                    dr["325WN"] = dtWine325.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("180WN") & dtWine180.Rows.Count > 0))
                    dr["180WN"] = dtWine180.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("60WN") & dtWine60.Rows.Count > 0))
                    dr["60WN"] = dtWine60.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("1500WN") & dtWine1500.Rows.Count > 0))
                    dr["1500WN"] = dtWine1500.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("720WN") & dtWine720.Rows.Count > 0))
                    dr["720WN"] = dtWine720.Rows[0]["totsale"].ToString();

                if ((dtt.Columns.Contains("250WN") & dtWine250.Rows.Count > 0))
                    dr["250WN"] = dtWine250.Rows[0]["totsale"].ToString();


                // --------------------------------------------------
                // -------------------------draftBeer-------------------------
                if ((dtt.Columns.Contains("1000 MLDB") & dtDraftBeer1000.Rows.Count > 0))
                    dr["1000 MLDB"] = dtDraftBeer1000.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("1000DB") & dtDraftBeer1000.Rows.Count > 0))
                    dr["1000DB"] = dtDraftBeer1000.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("700DB") & dtDraftBeer700.Rows.Count > 0))
                    dr["700DB"] = dtDraftBeer700.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("750DB") & dtDraftBeer750.Rows.Count > 0))
                    dr["750DB"] = dtDraftBeer750.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("650DB") & dtDraftBeer650.Rows.Count > 0))
                    dr["650DB"] = dtDraftBeer650.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("375DB") & dtDraftBeer375.Rows.Count > 0))
                    dr["375DB"] = dtDraftBeer375.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("330DB") & dtDraftBeer330.Rows.Count > 0))
                    dr["330DB"] = dtDraftBeer330.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("355DB") & dtDraftBeer355.Rows.Count > 0))
                    dr["355DB"] = dtDraftBeer355.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("325DB") & dtDraftBeer325.Rows.Count > 0))
                    dr["325DB"] = dtDraftBeer325.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("180DB") & dtDraftBeer180.Rows.Count > 0))
                    dr["180DB"] = dtDraftBeer180.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("60DB") & dtDraftBeer60.Rows.Count > 0))
                    dr["60DB"] = dtDraftBeer60.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("1500DB") & dtDraftBeer1500.Rows.Count > 0))
                    dr["1500DB"] = dtDraftBeer1500.Rows[0]["totsale"].ToString();

                // ---------------------------------------------------
                // ------------MildBeer-------------------------------
                if ((dtt.Columns.Contains("1000MB") & dtMildBeer1000.Rows.Count > 0))
                    dr["1000MB"] = dtMildBeer1000.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("700MB") & dtMildBeer700.Rows.Count > 0))
                    dr["700MB"] = dtMildBeer700.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("750MB") & dtMildBeer750.Rows.Count > 0))
                    dr["750MB"] = dtMildBeer750.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("650MB") & dtMildBeer650.Rows.Count > 0))
                    dr["650MB"] = dtMildBeer650.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("330MB") & dtMildBeer330.Rows.Count > 0))
                    dr["330MB"] = dtMildBeer330.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("325MB") & dtMildBeer325.Rows.Count > 0))
                    dr["325MB"] = dtMildBeer325.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("275MB") & dtMildBeer275.Rows.Count > 0))
                    dr["275MB"] = dtMildBeer275.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("500MB") & dtMildBeer500.Rows.Count > 0))
                    dr["500MB"] = dtMildBeer500.Rows[0]["totsale"].ToString();

                // -------------------------------------------------
                // ------------ImporteddBeer-------------------------------

                if ((dtt.Columns.Contains("355IB") & dtImporteddBeer355.Rows.Count > 0))
                    dr["355IB"] = dtImporteddBeer355.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("330IB") & dtImporteddBeer330.Rows.Count > 0))
                    dr["330IB"] = dtImporteddBeer330.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("300IB") & dtImporteddBeer300.Rows.Count > 0))
                    dr["300IB"] = dtImporteddBeer300.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("1000IB") & dtImporteddBeer1000.Rows.Count > 0))
                    dr["1000IB"] = dtImporteddBeer1000.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("500IB") & dtImporteddBeer500.Rows.Count > 0))
                    dr["500IB"] = dtImporteddBeer500.Rows[0]["totsale"].ToString();


                // ------------FERMENTED BEER-------------------------------

                if ((dtt.Columns.Contains("330FB") & dtFermenteddBeer330.Rows.Count > 0))
                    dr["330FB"] = dtFermenteddBeer330.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("500FB") & dtFermenteddBeer500.Rows.Count > 0))
                    dr["500FB"] = dtFermenteddBeer500.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("650FB") & dtFermenteddBeer650.Rows.Count > 0))
                    dr["650FB"] = dtFermenteddBeer650.Rows[0]["totsale"].ToString();


                // ------------COUNTRY LIQOUR-------------------------------

                if ((dtt.Columns.Contains("750CL") & dtCountryLiqour750.Rows.Count > 0))
                    dr["750CL"] = dtCountryLiqour750.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("375CL") & dtCountryLiqour375.Rows.Count > 0))
                    dr["375CL"] = dtCountryLiqour375.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("180CL") & dtCountryLiqour180.Rows.Count > 0))
                    dr["180CL"] = dtCountryLiqour180.Rows[0]["totsale"].ToString();
                if ((dtt.Columns.Contains("90CL") & dtCountryLiqour90.Rows.Count > 0))
                    dr["90CL"] = dtCountryLiqour90.Rows[0]["totsale"].ToString();



                dtt.Rows.Add(dr);

                // --------------------------------------------------------------------------------------------------
                // ----Close Opening----------------
                // ----Open Purchase----------------
                DataRow dr1 = null/* TODO Change to default(_) if this is not a reference type */;
                dr1 = dtt.NewRow();
                dr1["Title"] = "Purchase";
                dr1["TPNO"] = dtGrp.Rows[index]["tpno"];
                // -------------------Imported Spirits------------
                if ((dtt.Columns.Contains("2000IS") & dtImportedSpirit2000.Rows.Count > 0))
                    dr1["2000IS"] = dtImportedSpirit2000.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("1000IS") & dtImportedSpirit1000.Rows.Count > 0))
                    dr1["1000IS"] = dtImportedSpirit1000.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("700IS") & dtImportedSpirit700.Rows.Count > 0))
                    dr1["700IS"] = dtImportedSpirit700.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("750IS") & dtImportedSpirit750.Rows.Count > 0))
                    dr1["750IS"] = dtImportedSpirit750.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("650IS") & dtImportedSpirit650.Rows.Count > 0))
                    dr1["650IS"] = dtImportedSpirit650.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("375IS") & dtImportedSpirit375.Rows.Count > 0))
                    dr1["375IS"] = dtImportedSpirit375.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("330IS") & dtImportedSpirit330.Rows.Count > 0))
                    dr1["330IS"] = dtImportedSpirit330.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("325IS") & dtImportedSpirit325.Rows.Count > 0))
                    dr1["325IS"] = dtImportedSpirit325.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("180IS") & dtImportedSpirit180.Rows.Count > 0))
                    dr1["180IS"] = dtImportedSpirit180.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("60IS") & dtImportedSpirit60.Rows.Count > 0))
                    dr1["60IS"] = dtImportedSpirit60.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("280IS") & dtImportedSpirit280.Rows.Count > 0))
                    dr1["280IS"] = dtImportedSpirit280.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("200IS") & dtImportedSpirit200.Rows.Count > 0))
                    dr1["200IS"] = dtImportedSpirit200.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("500IS") & dtImportedSpirit500.Rows.Count > 0))
                    dr1["500IS"] = dtImportedSpirit500.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("1750IS") & dtImportedSpirit1750.Rows.Count > 0))
                    dr1["1750IS"] = dtImportedSpirit1750.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("50IS") & dtImportedSpirit50.Rows.Count > 0))
                    dr1["50IS"] = dtImportedSpirit50.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("900IS") & dtImportedSpirit900.Rows.Count > 0))
                    dr1["900IS"] = dtImportedSpirit900.Rows[1]["totsale"].ToString();
                // ------------------------------------------------------
                // -----------------------SPIRITS------------------------


                if ((dtt.Columns.Contains("1000SP") & dtSPIRITS1000.Rows.Count > 0))
                    dr1["1000SP"] = dtSPIRITS1000.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("700SP") & dtSPIRITS700.Rows.Count > 0))
                    dr1["700SP"] = dtSPIRITS700.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("750SP") & dtSPIRITS750.Rows.Count > 0))
                    dr1["750SP"] = dtSPIRITS750.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("650SP") & dtSPIRITS650.Rows.Count > 0))
                    dr1["650SP"] = dtSPIRITS650.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("600SP") & dtSPIRITS600.Rows.Count > 0))
                    dr1["600SP"] = dtSPIRITS600.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("375SP") & dtSPIRITS375.Rows.Count > 0))
                    dr1["375SP"] = dtSPIRITS375.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("330SP") & dtSPIRITS330.Rows.Count > 0))
                    dr1["330SP"] = dtSPIRITS330.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("325SP") & dtSPIRITS325.Rows.Count > 0))
                    dr1["325SP"] = dtSPIRITS325.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("180SP") & dtSPIRITS180.Rows.Count > 0))
                    dr1["180SP"] = dtSPIRITS180.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("60SP") & dtSPIRITS60.Rows.Count > 0))
                    dr1["60SP"] = dtSPIRITS60.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("275SP") & dtSPIRITS275.Rows.Count > 0))
                    dr1["275SP"] = dtSPIRITS275.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("50SP") & dtSPIRITS50.Rows.Count > 0))
                    dr1["50SP"] = dtSPIRITS50.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("90SP") & dtSPIRITS90.Rows.Count > 0))
                    dr1["90SP"] = dtSPIRITS90.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("2000SP") & dtSPIRITS2000.Rows.Count > 0))
                    dr1["2000SP"] = dtSPIRITS2000.Rows[1]["totsale"].ToString();

                if ((dtt.Columns.Contains("500SP") & dtSPIRITS500.Rows.Count > 0))
                    dr1["500SP"] = dtSPIRITS500.Rows[1]["totsale"].ToString();

                // -----------------------------------------------
                // ---------------------Imported Wine-------------
                if ((dtt.Columns.Contains("1000IW") & dtImportedWines1000.Rows.Count > 0))
                    dr1["1000IW"] = dtImportedWines1000.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("700IW") & dtImportedWines700.Rows.Count > 0))
                    dr1["700IW"] = dtImportedWines700.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("750IW") & dtImportedWines750.Rows.Count > 0))
                    dr1["750IW"] = dtImportedWines750.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("650IW") & dtImportedWines650.Rows.Count > 0))
                    dr1["650IW"] = dtImportedWines650.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("375IW") & dtImportedWines375.Rows.Count > 0))
                    dr1["375IW"] = dtImportedWines375.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("330IW") & dtImportedWines330.Rows.Count > 0))
                    dr1["330IW"] = dtImportedWines330.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("325IW") & dtImportedWines325.Rows.Count > 0))
                    dr1["325IW"] = dtImportedWines325.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("180IW") & dtImportedWines180.Rows.Count > 0))
                    dr1["180IW"] = dtImportedWines180.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("60IW") & dtImportedWines60.Rows.Count > 0))
                    dr1["60IW"] = dtImportedWines60.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("720IW") & dtImportedWines720.Rows.Count > 0))
                    dr1["720IW"] = dtImportedWines720.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("300IW") & dtImportedWines300.Rows.Count > 0))
                    dr1["300IW"] = dtImportedWines300.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("1500IW") & dtImportedWines1500.Rows.Count > 0))
                    dr1["1500IW"] = dtImportedWines1500.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("1800IW") & dtImportedWines1800.Rows.Count > 0))
                    dr1["1800IW"] = dtImportedWines1800.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("200IW") & dtImportedWines200.Rows.Count > 0))
                    dr1["200IW"] = dtImportedWines200.Rows[1]["totsale"].ToString();


                if ((dtt.Columns.Contains("900IW") & dtImportedWines900.Rows.Count > 0))
                    dr1["900IW"] = dtImportedWines900.Rows[1]["totsale"].ToString();


                if ((dtt.Columns.Contains("187IW") & dtImportedWines187.Rows.Count > 0))
                    dr1["187IW"] = dtImportedWines187.Rows[1]["totsale"].ToString();
                // --------------------------------------------------
                // -----------------------Wine-----------------------
                if ((dtt.Columns.Contains("1000WN") & dtWine1000.Rows.Count > 0))
                    dr1["1000WN"] = dtWine1000.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("700WN") & dtWine700.Rows.Count > 0))
                    dr1["700WN"] = dtWine700.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("750WN") & dtWine750.Rows.Count > 0))
                    dr1["750WN"] = dtWine750.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("650WN") & dtWine650.Rows.Count > 0))
                    dr1["650WN"] = dtWine650.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("375WN") & dtWine375.Rows.Count > 0))
                    dr1["375WN"] = dtWine375.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("330WN") & dtWine330.Rows.Count > 0))
                    dr1["330WN"] = dtWine330.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("325WN") & dtWine325.Rows.Count > 0))
                    dr1["325WN"] = dtWine325.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("180WN") & dtWine180.Rows.Count > 0))
                    dr1["180WN"] = dtWine180.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("60WN") & dtWine60.Rows.Count > 0))
                    dr1["60WN"] = dtWine60.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("1500WN") & dtWine1500.Rows.Count > 0))
                    dr1["1500WN"] = dtWine1500.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("720WN") & dtWine720.Rows.Count > 0))
                    dr1["720WN"] = dtWine720.Rows[1]["totsale"].ToString();


                if ((dtt.Columns.Contains("250WN") & dtWine250.Rows.Count > 0))
                    dr1["250WN"] = dtWine250.Rows[1]["totsale"].ToString();

                // --------------------------------------------------
                // ------------Draft Beer----------------------------
                if ((dtt.Columns.Contains("1000 MLDB") & dtDraftBeer1000.Rows.Count > 0))
                    dr1["1000 MLDB"] = dtDraftBeer1000.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("1000DB") & dtDraftBeer1000.Rows.Count > 0))
                    dr1["1000DB"] = dtDraftBeer1000.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("700DB") & dtDraftBeer700.Rows.Count > 0))
                    dr1["700DB"] = dtDraftBeer700.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("750DB") & dtDraftBeer750.Rows.Count > 0))
                    dr1["750DB"] = dtDraftBeer750.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("650DB") & dtDraftBeer650.Rows.Count > 0))
                    dr1["650DB"] = dtDraftBeer650.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("375DB") & dtDraftBeer375.Rows.Count > 0))
                    dr1["375DB"] = dtDraftBeer375.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("330DB") & dtDraftBeer330.Rows.Count > 0))
                    dr1["330DB"] = dtDraftBeer330.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("355DB") & dtDraftBeer355.Rows.Count > 0))
                    dr1["355DB"] = dtDraftBeer355.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("325DB") & dtDraftBeer325.Rows.Count > 0))
                    dr1["325DB"] = dtDraftBeer325.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("180DB") & dtDraftBeer180.Rows.Count > 0))
                    dr1["180DB"] = dtDraftBeer180.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("60DB") & dtDraftBeer60.Rows.Count > 0))
                    dr1["60DB"] = dtDraftBeer60.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("1500DB") & dtDraftBeer1500.Rows.Count > 0))
                    dr1["1500DB"] = dtDraftBeer1500.Rows[1]["totsale"].ToString();

                // ---------------------------------------------------
                // ------------MildBeer-------------------------------
                if ((dtt.Columns.Contains("1000MB") & dtMildBeer1000.Rows.Count > 0))
                    dr1["1000MB"] = dtMildBeer1000.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("700MB") & dtMildBeer700.Rows.Count > 0))
                    dr1["700MB"] = dtMildBeer700.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("750MB") & dtMildBeer750.Rows.Count > 0))
                    dr1["750MB"] = dtMildBeer750.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("650MB") & dtMildBeer650.Rows.Count > 0))
                    dr1["650MB"] = dtMildBeer650.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("330MB") & dtMildBeer330.Rows.Count > 0))
                    dr1["330MB"] = dtMildBeer330.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("325MB") & dtMildBeer325.Rows.Count > 0))
                    dr1["325MB"] = dtMildBeer325.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("275MB") & dtMildBeer275.Rows.Count > 0))
                    dr1["275MB"] = dtMildBeer275.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("500MB") & dtMildBeer500.Rows.Count > 0))
                    dr1["500MB"] = dtMildBeer500.Rows[1]["totsale"].ToString();
                // --------------------Imported beer---------------------

                if ((dtt.Columns.Contains("355IB") & dtImporteddBeer355.Rows.Count > 0))
                    dr1["355IB"] = dtImporteddBeer355.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("330IB") & dtImporteddBeer330.Rows.Count > 0))
                    dr1["330IB"] = dtImporteddBeer330.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("300IB") & dtImporteddBeer300.Rows.Count > 0))
                    dr1["300IB"] = dtImporteddBeer300.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("1000IB") & dtImporteddBeer1000.Rows.Count > 0))
                    dr1["1000IB"] = dtImporteddBeer1000.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("500IB") & dtImporteddBeer500.Rows.Count > 0))
                    dr1["500IB"] = dtImporteddBeer500.Rows[1]["totsale"].ToString();

                // ------------FERMENTED BEER-------------------------------

                if ((dtt.Columns.Contains("330FB") & dtFermenteddBeer330.Rows.Count > 0))
                    dr1["330FB"] = dtFermenteddBeer330.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("500FB") & dtFermenteddBeer500.Rows.Count > 0))
                    dr1["500FB"] = dtFermenteddBeer500.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("650FB") & dtFermenteddBeer650.Rows.Count > 0))
                    dr1["650FB"] = dtFermenteddBeer650.Rows[1]["totsale"].ToString();



                // ------------COUNTRY LIQOUR-------------------------------

                if ((dtt.Columns.Contains("750CL") & dtCountryLiqour750.Rows.Count > 0))
                    dr1["750CL"] = dtCountryLiqour750.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("375CL") & dtCountryLiqour375.Rows.Count > 0))
                    dr1["375CL"] = dtCountryLiqour375.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("180CL") & dtCountryLiqour180.Rows.Count > 0))
                    dr1["180CL"] = dtCountryLiqour180.Rows[1]["totsale"].ToString();
                if ((dtt.Columns.Contains("90CL") & dtCountryLiqour90.Rows.Count > 0))
                    dr1["90CL"] = dtCountryLiqour90.Rows[1]["totsale"].ToString();



                dtt.Rows.Add(dr1);
                // --------------------------------------------------------------------------------------------------
                DataRow dr2 = null/* TODO Change to default(_) if this is not a reference type */;
                dr2 = dtt.NewRow();
                dr2["Title"] = "Total";
                // -------------------Imported Spirits------------
                if ((dtt.Columns.Contains("2000IS") & dtImportedSpirit2000.Rows.Count > 0))
                    dr2["2000IS"] = dtImportedSpirit2000.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("1000IS") & dtImportedSpirit1000.Rows.Count > 0))
                    dr2["1000IS"] = dtImportedSpirit1000.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("700IS") & dtImportedSpirit700.Rows.Count > 0))
                    dr2["700IS"] = dtImportedSpirit700.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("750IS") & dtImportedSpirit750.Rows.Count > 0))
                    dr2["750IS"] = dtImportedSpirit750.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("650IS") & dtImportedSpirit650.Rows.Count > 0))
                    dr2["650IS"] = dtImportedSpirit650.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("375IS") & dtImportedSpirit375.Rows.Count > 0))
                    dr2["375IS"] = dtImportedSpirit375.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("330IS") & dtImportedSpirit330.Rows.Count > 0))
                    dr2["330IS"] = dtImportedSpirit330.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("325IS") & dtImportedSpirit325.Rows.Count > 0))
                    dr2["325IS"] = dtImportedSpirit325.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("180IS") & dtImportedSpirit180.Rows.Count > 0))
                    dr2["180IS"] = dtImportedSpirit180.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("60IS") & dtImportedSpirit60.Rows.Count > 0))
                    dr2["60IS"] = dtImportedSpirit60.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("280IS") & dtImportedSpirit280.Rows.Count > 0))
                    dr2["280IS"] = dtImportedSpirit280.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("200IS") & dtImportedSpirit200.Rows.Count > 0))
                    dr2["200IS"] = dtImportedSpirit200.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("500IS") & dtImportedSpirit500.Rows.Count > 0))
                    dr2["500IS"] = dtImportedSpirit500.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("1750IS") & dtImportedSpirit1750.Rows.Count > 0))
                    dr2["1750IS"] = dtImportedSpirit1750.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("50IS") & dtImportedSpirit50.Rows.Count > 0))
                    dr2["50IS"] = dtImportedSpirit50.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("900IS") & dtImportedSpirit900.Rows.Count > 0))
                    dr2["900IS"] = dtImportedSpirit900.Rows[2]["totsale"].ToString();
                // ------------------------------------------------------
                // -----------------------SPIRITS------------------------


                if ((dtt.Columns.Contains("1000SP") & dtSPIRITS1000.Rows.Count > 0))
                    dr2["1000SP"] = dtSPIRITS1000.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("700SP") & dtSPIRITS700.Rows.Count > 0))
                    dr2["700SP"] = dtSPIRITS700.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("750SP") & dtSPIRITS750.Rows.Count > 0))
                    dr2["750SP"] = dtSPIRITS750.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("650SP") & dtSPIRITS750.Rows.Count > 0))
                    dr2["650SP"] = dtSPIRITS750.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("600SP") & dtSPIRITS600.Rows.Count > 0))
                    dr2["600SP"] = dtSPIRITS600.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("375SP") & dtSPIRITS375.Rows.Count > 0))
                    dr2["375SP"] = dtSPIRITS375.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("330SP") & dtSPIRITS330.Rows.Count > 0))
                    dr2["330SP"] = dtSPIRITS330.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("325SP") & dtSPIRITS325.Rows.Count > 0))
                    dr2["325SP"] = dtSPIRITS325.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("180SP") & dtSPIRITS180.Rows.Count > 0))
                    dr2["180SP"] = dtSPIRITS180.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("60SP") & dtSPIRITS60.Rows.Count > 0))
                    dr2["60SP"] = dtSPIRITS60.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("275SP") & dtSPIRITS275.Rows.Count > 0))
                    dr2["275SP"] = dtSPIRITS275.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("50SP") & dtSPIRITS50.Rows.Count > 0))
                    dr2["50SP"] = dtSPIRITS50.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("90SP") & dtSPIRITS90.Rows.Count > 0))
                    dr2["90SP"] = dtSPIRITS90.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("2000SP") & dtSPIRITS2000.Rows.Count > 0))
                    dr2["2000SP"] = dtSPIRITS2000.Rows[2]["totsale"].ToString();

                if ((dtt.Columns.Contains("500SP") & dtSPIRITS500.Rows.Count > 0))
                    dr2["500SP"] = dtSPIRITS500.Rows[2]["totsale"].ToString();

                // -----------------------------------------------
                // ---------------------Imported Wine-------------
                if ((dtt.Columns.Contains("1000IW") & dtImportedWines1000.Rows.Count > 0))
                    dr2["1000IW"] = dtImportedWines1000.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("700IW") & dtImportedWines700.Rows.Count > 0))
                    dr2["700IW"] = dtImportedWines700.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("750IW") & dtImportedWines750.Rows.Count > 0))
                    dr2["750IW"] = dtImportedWines750.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("650IW") & dtImportedWines650.Rows.Count > 0))
                    dr2["650IW"] = dtImportedWines650.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("375IW") & dtImportedWines375.Rows.Count > 0))
                    dr2["375IW"] = dtImportedWines375.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("330IW") & dtImportedWines330.Rows.Count > 0))
                    dr2["330IW"] = dtImportedWines330.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("325IW") & dtImportedWines325.Rows.Count > 0))
                    dr2["325IW"] = dtImportedWines325.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("180IW") & dtImportedWines180.Rows.Count > 0))
                    dr2["180IW"] = dtImportedWines180.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("60IW") & dtImportedWines60.Rows.Count > 0))
                    dr2["60IW"] = dtImportedWines60.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("720IW") & dtImportedWines720.Rows.Count > 0))
                    dr2["720IW"] = dtImportedWines720.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("300IW") & dtImportedWines300.Rows.Count > 0))
                    dr2["300IW"] = dtImportedWines300.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("1500IW") & dtImportedWines1500.Rows.Count > 0))
                    dr2["1500IW"] = dtImportedWines1500.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("1800IW") & dtImportedWines1800.Rows.Count > 0))
                    dr2["1800IW"] = dtImportedWines1800.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("200IW") & dtImportedWines200.Rows.Count > 0))
                    dr2["200IW"] = dtImportedWines200.Rows[2]["totsale"].ToString();

                if ((dtt.Columns.Contains("900IW") & dtImportedWines900.Rows.Count > 0))
                    dr2["900IW"] = dtImportedWines900.Rows[2]["totsale"].ToString();

                if ((dtt.Columns.Contains("187IW") & dtImportedWines187.Rows.Count > 0))
                    dr2["187IW"] = dtImportedWines187.Rows[2]["totsale"].ToString();

                // --------------------------------------------------
                // -----------------------Wine-----------------------
                if ((dtt.Columns.Contains("1000WN") & dtWine1000.Rows.Count > 0))
                    dr2["1000WN"] = dtWine1000.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("700WN") & dtWine700.Rows.Count > 0))
                    dr2["700WN"] = dtWine700.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("750WN") & dtWine750.Rows.Count > 0))
                    dr2["750WN"] = dtWine750.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("650WN") & dtWine650.Rows.Count > 0))
                    dr2["650WN"] = dtWine650.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("375WN") & dtWine375.Rows.Count > 0))
                    dr2["375WN"] = dtWine375.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("330WN") & dtWine330.Rows.Count > 0))
                    dr2["330WN"] = dtWine330.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("325WN") & dtWine325.Rows.Count > 0))
                    dr2["325WN"] = dtWine325.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("180WN") & dtWine180.Rows.Count > 0))
                    dr2["180WN"] = dtWine180.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("60WN") & dtWine60.Rows.Count > 0))
                    dr2["60WN"] = dtWine60.Rows[2]["totsale"].ToString();

                if ((dtt.Columns.Contains("1500WN") & dtWine1500.Rows.Count > 0))
                    dr2["1500WN"] = dtWine1500.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("720WN") & dtWine720.Rows.Count > 0))
                    dr2["720WN"] = dtWine720.Rows[2]["totsale"].ToString();


                if ((dtt.Columns.Contains("250WN") & dtWine250.Rows.Count > 0))
                    dr2["250WN"] = dtWine250.Rows[2]["totsale"].ToString();

                // --------------------------------------------------
                // ----------------Draft Beer------------------------
                if ((dtt.Columns.Contains("1000 MLDB") & dtDraftBeer1000.Rows.Count > 0))
                    dr2["1000 MLDB"] = dtDraftBeer1000.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("1000DB") & dtDraftBeer1000.Rows.Count > 0))
                    dr2["1000DB"] = dtDraftBeer1000.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("700DB") & dtDraftBeer700.Rows.Count > 0))
                    dr2["700DB"] = dtDraftBeer700.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("750DB") & dtDraftBeer750.Rows.Count > 0))
                    dr2["750DB"] = dtDraftBeer750.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("650DB") & dtDraftBeer650.Rows.Count > 0))
                    dr2["650DB"] = dtDraftBeer650.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("375DB") & dtDraftBeer375.Rows.Count > 0))
                    dr2["375DB"] = dtDraftBeer375.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("330DB") & dtDraftBeer330.Rows.Count > 0))
                    dr2["330DB"] = dtDraftBeer330.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("325DB") & dtDraftBeer325.Rows.Count > 0))
                    dr2["325DB"] = dtDraftBeer325.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("180DB") & dtDraftBeer180.Rows.Count > 0))
                    dr2["180DB"] = dtDraftBeer180.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("60DB") & dtDraftBeer60.Rows.Count > 0))
                    dr2["60DB"] = dtDraftBeer60.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("355DB") & dtDraftBeer355.Rows.Count > 0))
                    dr2["355DB"] = dtDraftBeer355.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("1500DB") & dtDraftBeer1500.Rows.Count > 0))
                    dr2["1500DB"] = dtDraftBeer1500.Rows[2]["totsale"].ToString();

                // ---------------------------------------------------
                // ------------MildBeer-------------------------------
                if ((dtt.Columns.Contains("1000MB") & dtMildBeer1000.Rows.Count > 0))
                    dr2["1000MB"] = dtMildBeer1000.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("700MB") & dtMildBeer700.Rows.Count > 0))
                    dr2["700MB"] = dtMildBeer700.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("750MB") & dtMildBeer750.Rows.Count > 0))
                    dr2["750MB"] = dtMildBeer750.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("650MB") & dtMildBeer650.Rows.Count > 0))
                    dr2["650MB"] = dtMildBeer650.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("330MB") & dtMildBeer330.Rows.Count > 0))
                    dr2["330MB"] = dtMildBeer330.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("325MB") & dtMildBeer325.Rows.Count > 0))
                    dr2["325MB"] = dtMildBeer325.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("275MB") & dtMildBeer275.Rows.Count > 0))
                    dr2["275MB"] = dtMildBeer275.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("500MB") & dtMildBeer500.Rows.Count > 0))
                    dr2["500MB"] = dtMildBeer500.Rows[2]["totsale"].ToString();
                // -------------------------------------------------
                // ------Imported Beer------------------------------

                if ((dtt.Columns.Contains("355IB") & dtImporteddBeer355.Rows.Count > 0))
                    dr2["355IB"] = dtImporteddBeer355.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("330IB") & dtImporteddBeer330.Rows.Count > 0))
                    dr2["330IB"] = dtImporteddBeer330.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("300IB") & dtImporteddBeer300.Rows.Count > 0))
                    dr2["300IB"] = dtImporteddBeer300.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("1000IB") & dtImporteddBeer1000.Rows.Count > 0))
                    dr2["1000IB"] = dtImporteddBeer1000.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("500IB") & dtImporteddBeer500.Rows.Count > 0))
                    dr2["500IB"] = dtImporteddBeer500.Rows[2]["totsale"].ToString();

                // ------------FERMENTED BEER-------------------------------

                if ((dtt.Columns.Contains("330FB") & dtFermenteddBeer330.Rows.Count > 0))
                    dr2["330FB"] = dtFermenteddBeer330.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("500FB") & dtFermenteddBeer500.Rows.Count > 0))
                    dr2["500FB"] = dtFermenteddBeer500.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("650FB") & dtFermenteddBeer650.Rows.Count > 0))
                    dr2["650FB"] = dtFermenteddBeer650.Rows[2]["totsale"].ToString();


                // ------------COUNTRY LIQOUR-------------------------------

                if ((dtt.Columns.Contains("750CL") & dtCountryLiqour750.Rows.Count > 0))
                    dr2["750CL"] = dtCountryLiqour750.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("375CL") & dtCountryLiqour375.Rows.Count > 0))
                    dr2["375CL"] = dtCountryLiqour375.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("180CL") & dtCountryLiqour180.Rows.Count > 0))
                    dr2["180CL"] = dtCountryLiqour180.Rows[2]["totsale"].ToString();
                if ((dtt.Columns.Contains("90CL") & dtCountryLiqour90.Rows.Count > 0))
                    dr2["90CL"] = dtCountryLiqour90.Rows[2]["totsale"].ToString();




                dtt.Rows.Add(dr2);
                // ------------------------------------------------------------------------------------------------------------------------
                // -----------------------------------------
                DataRow dr3 = null/* TODO Change to default(_) if this is not a reference type */;
                dr3 = dtt.NewRow();
                dr3["Title"] = "Sale";
                // -------------------Imported Spirits------------
                if ((dtt.Columns.Contains("2000IS") & dtImportedSpirit2000.Rows.Count > 0))
                    dr3["2000IS"] = dtImportedSpirit2000.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("1000IS") & dtImportedSpirit1000.Rows.Count > 0))
                    dr3["1000IS"] = dtImportedSpirit1000.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("700IS") & dtImportedSpirit700.Rows.Count > 0))
                    dr3["700IS"] = dtImportedSpirit700.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("750IS") & dtImportedSpirit750.Rows.Count > 0))
                    dr3["750IS"] = dtImportedSpirit750.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("650IS") & dtImportedSpirit650.Rows.Count > 0))
                    dr3["650IS"] = dtImportedSpirit650.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("375IS") & dtImportedSpirit375.Rows.Count > 0))
                    dr3["375IS"] = dtImportedSpirit375.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("330IS") & dtImportedSpirit330.Rows.Count > 0))
                    dr3["330IS"] = dtImportedSpirit330.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("325IS") & dtImportedSpirit325.Rows.Count > 0))
                    dr3["325IS"] = dtImportedSpirit325.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("180IS") & dtImportedSpirit180.Rows.Count > 0))
                    dr3["180IS"] = dtImportedSpirit180.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("60IS") & dtImportedSpirit60.Rows.Count > 0))
                    dr3["60IS"] = dtImportedSpirit60.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("280IS") & dtImportedSpirit280.Rows.Count > 0))
                    dr3["280IS"] = dtImportedSpirit280.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("200IS") & dtImportedSpirit200.Rows.Count > 0))
                    dr3["200IS"] = dtImportedSpirit200.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("500IS") & dtImportedSpirit500.Rows.Count > 0))
                    dr3["500IS"] = dtImportedSpirit500.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("1750IS") & dtImportedSpirit1750.Rows.Count > 0))
                    dr3["1750IS"] = dtImportedSpirit1750.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("50IS") & dtImportedSpirit50.Rows.Count > 0))
                    dr3["50IS"] = dtImportedSpirit50.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("900IS") & dtImportedSpirit900.Rows.Count > 0))
                    dr3["900IS"] = dtImportedSpirit900.Rows[3]["totsale"].ToString();
                // ------------------------------------------------------
                // -----------------------SPIRITS------------------------


                if ((dtt.Columns.Contains("1000SP") & dtSPIRITS1000.Rows.Count > 0))
                    dr3["1000SP"] = dtSPIRITS1000.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("700SP") & dtSPIRITS700.Rows.Count > 0))
                    dr3["700SP"] = dtSPIRITS700.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("750SP") & dtSPIRITS750.Rows.Count > 0))
                    dr3["750SP"] = dtSPIRITS750.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("650SP") & dtSPIRITS650.Rows.Count > 0))
                    dr3["650SP"] = dtSPIRITS650.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("600SP") & dtSPIRITS600.Rows.Count > 0))
                    dr3["600SP"] = dtSPIRITS600.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("375SP") & dtSPIRITS375.Rows.Count > 0))
                    dr3["375SP"] = dtSPIRITS375.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("330SP") & dtSPIRITS330.Rows.Count > 0))
                    dr3["330SP"] = dtSPIRITS330.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("325SP") & dtSPIRITS325.Rows.Count > 0))
                    dr3["325SP"] = dtSPIRITS325.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("180SP") & dtSPIRITS180.Rows.Count > 0))
                    dr3["180SP"] = dtSPIRITS180.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("60SP") & dtSPIRITS60.Rows.Count > 0))
                    dr3["60SP"] = dtSPIRITS60.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("275SP") & dtSPIRITS275.Rows.Count > 0))
                    dr3["275SP"] = dtSPIRITS275.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("50SP") & dtSPIRITS50.Rows.Count > 0))
                    dr3["50SP"] = dtSPIRITS50.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("90SP") & dtSPIRITS90.Rows.Count > 0))
                    dr3["90SP"] = dtSPIRITS90.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("2000SP") & dtSPIRITS2000.Rows.Count > 0))
                    dr3["2000SP"] = dtSPIRITS2000.Rows[3]["totsale"].ToString();

                if ((dtt.Columns.Contains("500SP") & dtSPIRITS500.Rows.Count > 0))
                    dr3["500SP"] = dtSPIRITS500.Rows[3]["totsale"].ToString();
                // -----------------------------------------------
                // ---------------------Imported Wine-------------
                if ((dtt.Columns.Contains("1000IW") & dtImportedWines1000.Rows.Count > 0))
                    dr3["1000IW"] = dtImportedWines1000.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("700IW") & dtImportedWines700.Rows.Count > 0))
                    dr3["700IW"] = dtImportedWines700.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("750IW") & dtImportedWines750.Rows.Count > 0))
                    dr3["750IW"] = dtImportedWines750.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("650IW") & dtImportedWines650.Rows.Count > 0))
                    dr3["650IW"] = dtImportedWines650.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("375IW") & dtImportedWines375.Rows.Count > 0))
                    dr3["375IW"] = dtImportedWines375.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("330IW") & dtImportedWines330.Rows.Count > 0))
                    dr3["330IW"] = dtImportedWines330.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("325IW") & dtImportedWines325.Rows.Count > 0))
                    dr3["325IW"] = dtImportedWines325.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("180IW") & dtImportedWines180.Rows.Count > 0))
                    dr3["180IW"] = dtImportedWines180.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("60IW") & dtImportedWines60.Rows.Count > 0))
                    dr3["60IW"] = dtImportedWines60.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("720IW") & dtImportedWines720.Rows.Count > 0))
                    dr3["720IW"] = dtImportedWines720.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("300IW") & dtImportedWines300.Rows.Count > 0))
                    dr3["300IW"] = dtImportedWines300.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("1500IW") & dtImportedWines1500.Rows.Count > 0))
                    dr3["1500IW"] = dtImportedWines1500.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("1800IW") & dtImportedWines1800.Rows.Count > 0))
                    dr3["1800IW"] = dtImportedWines1800.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("200IW") & dtImportedWines200.Rows.Count > 0))
                    dr3["200IW"] = dtImportedWines200.Rows[3]["totsale"].ToString();

                if ((dtt.Columns.Contains("900IW") & dtImportedWines900.Rows.Count > 0))
                    dr3["900IW"] = dtImportedWines900.Rows[3]["totsale"].ToString();

                if ((dtt.Columns.Contains("187IW") & dtImportedWines187.Rows.Count > 0))
                    dr3["187IW"] = dtImportedWines187.Rows[3]["totsale"].ToString();

                // --------------------------------------------------
                // -----------------------Wine-----------------------
                if ((dtt.Columns.Contains("1000WN") & dtWine1000.Rows.Count > 0))
                    dr3["1000WN"] = dtWine1000.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("700WN") & dtWine700.Rows.Count > 0))
                    dr3["700WN"] = dtWine700.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("750WN") & dtWine750.Rows.Count > 0))
                    dr3["750WN"] = dtWine750.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("650WN") & dtWine650.Rows.Count > 0))
                    dr3["650WN"] = dtWine650.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("375WN") & dtWine375.Rows.Count > 0))
                    dr3["375WN"] = dtWine375.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("330WN") & dtWine330.Rows.Count > 0))
                    dr3["330WN"] = dtWine330.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("325WN") & dtWine325.Rows.Count > 0))
                    dr3["325WN"] = dtWine325.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("180WN") & dtWine180.Rows.Count > 0))
                    dr3["180WN"] = dtWine180.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("60WN") & dtWine60.Rows.Count > 0))
                    dr3["60WN"] = dtWine60.Rows[3]["totsale"].ToString();

                if ((dtt.Columns.Contains("1500WN") & dtWine1500.Rows.Count > 0))
                    dr3["1500WN"] = dtWine1500.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("720WN") & dtWine720.Rows.Count > 0))
                    dr3["720WN"] = dtWine720.Rows[3]["totsale"].ToString();


                if ((dtt.Columns.Contains("250WN") & dtWine250.Rows.Count > 0))
                    dr3["250WN"] = dtWine250.Rows[3]["totsale"].ToString();

                // --------------------------------------------------
                // ----------------Draft Beer------------------------
                if ((dtt.Columns.Contains("1000 MLDB") & dtDraftBeer1000.Rows.Count > 0))
                    dr3["1000 MLDB"] = dtDraftBeer1000.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("1000DB") & dtDraftBeer1000.Rows.Count > 0))
                    dr3["1000DB"] = dtDraftBeer1000.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("700DB") & dtDraftBeer700.Rows.Count > 0))
                    dr3["700DB"] = dtDraftBeer700.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("750DB") & dtDraftBeer750.Rows.Count > 0))
                    dr3["750DB"] = dtDraftBeer750.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("650DB") & dtDraftBeer650.Rows.Count > 0))
                    dr3["650DB"] = dtDraftBeer650.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("375DB") & dtDraftBeer375.Rows.Count > 0))
                    dr3["375DB"] = dtDraftBeer375.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("330DB") & dtDraftBeer330.Rows.Count > 0))
                    dr3["330DB"] = dtDraftBeer330.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("325DB") & dtDraftBeer325.Rows.Count > 0))
                    dr3["325DB"] = dtDraftBeer325.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("180DB") & dtDraftBeer180.Rows.Count > 0))
                    dr3["180DB"] = dtDraftBeer180.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("60DB") & dtDraftBeer60.Rows.Count > 0))
                    dr3["60DB"] = dtDraftBeer60.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("355DB") & dtDraftBeer355.Rows.Count > 0))
                    dr3["355DB"] = dtDraftBeer355.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("1500DB") & dtDraftBeer1500.Rows.Count > 0))
                    dr3["1500DB"] = dtDraftBeer1500.Rows[3]["totsale"].ToString();

                // ---------------------------------------------------
                // ------------MildBeer-------------------------------
                if ((dtt.Columns.Contains("1000MB") & dtMildBeer1000.Rows.Count > 0))
                    dr3["1000MB"] = dtMildBeer1000.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("700MB") & dtMildBeer700.Rows.Count > 0))
                    dr3["700MB"] = dtMildBeer700.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("750MB") & dtMildBeer750.Rows.Count > 0))
                    dr3["750MB"] = dtMildBeer750.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("650MB") & dtMildBeer650.Rows.Count > 0))
                    dr3["650MB"] = dtMildBeer650.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("330MB") & dtMildBeer330.Rows.Count > 0))
                    dr3["330MB"] = dtMildBeer330.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("325MB") & dtMildBeer325.Rows.Count > 0))
                    dr3["325MB"] = dtMildBeer325.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("275MB") & dtMildBeer275.Rows.Count > 0))
                    dr3["275MB"] = dtMildBeer275.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("500MB") & dtMildBeer500.Rows.Count > 0))
                    dr3["500MB"] = dtMildBeer500.Rows[3]["totsale"].ToString();
                // -------------------------------------------------
                // ------Imported Beer------------------------------

                if ((dtt.Columns.Contains("355IB") & dtImporteddBeer355.Rows.Count > 0))
                    dr3["355IB"] = dtImporteddBeer355.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("330IB") & dtImporteddBeer330.Rows.Count > 0))
                    dr3["330IB"] = dtImporteddBeer330.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("300IB") & dtImporteddBeer300.Rows.Count > 0))
                    dr3["300IB"] = dtImporteddBeer300.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("1000IB") & dtImporteddBeer1000.Rows.Count > 0))
                    dr3["1000IB"] = dtImporteddBeer1000.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("500IB") & dtImporteddBeer500.Rows.Count > 0))
                    dr3["500IB"] = dtImporteddBeer500.Rows[3]["totsale"].ToString();

                // ------------FERMENTED BEER-------------------------------

                if ((dtt.Columns.Contains("330FB") & dtFermenteddBeer330.Rows.Count > 0))
                    dr3["330FB"] = dtFermenteddBeer330.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("500FB") & dtFermenteddBeer500.Rows.Count > 0))
                    dr3["500FB"] = dtFermenteddBeer500.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("650FB") & dtFermenteddBeer650.Rows.Count > 0))
                    dr3["650FB"] = dtFermenteddBeer650.Rows[3]["totsale"].ToString();



                // ------------COUNTRY LIQOUR-------------------------------

                if ((dtt.Columns.Contains("750CL") & dtCountryLiqour750.Rows.Count > 0))
                    dr3["750CL"] = dtCountryLiqour750.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("375CL") & dtCountryLiqour375.Rows.Count > 0))
                    dr3["375CL"] = dtCountryLiqour375.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("180CL") & dtCountryLiqour180.Rows.Count > 0))
                    dr3["180CL"] = dtCountryLiqour180.Rows[3]["totsale"].ToString();
                if ((dtt.Columns.Contains("90CL") & dtCountryLiqour90.Rows.Count > 0))
                    dr3["90CL"] = dtCountryLiqour90.Rows[3]["totsale"].ToString();




                dtt.Rows.Add(dr3);
                // ---------------------------------------------------------------------------------------------------------------
                DataRow dr4 = null/* TODO Change to default(_) if this is not a reference type */;
                dr4 = dtt.NewRow();
                dr4["Title"] = "Closing";
                // -------------------Imported Spirits------------
                if ((dtt.Columns.Contains("2000IS") & dtImportedSpirit2000.Rows.Count > 0))
                    dr4["2000IS"] = dtImportedSpirit2000.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("1000IS") & dtImportedSpirit1000.Rows.Count > 0))
                    dr4["1000IS"] = dtImportedSpirit1000.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("700IS") & dtImportedSpirit700.Rows.Count > 0))
                    dr4["700IS"] = dtImportedSpirit700.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("750IS") & dtImportedSpirit750.Rows.Count > 0))
                    dr4["750IS"] = dtImportedSpirit750.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("650IS") & dtImportedSpirit650.Rows.Count > 0))
                    dr4["650IS"] = dtImportedSpirit650.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("375IS") & dtImportedSpirit375.Rows.Count > 0))
                    dr4["375IS"] = dtImportedSpirit375.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("330IS") & dtImportedSpirit330.Rows.Count > 0))
                    dr4["330IS"] = dtImportedSpirit330.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("325IS") & dtImportedSpirit325.Rows.Count > 0))
                    dr4["325IS"] = dtImportedSpirit325.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("180IS") & dtImportedSpirit180.Rows.Count > 0))
                    dr4["180IS"] = dtImportedSpirit180.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("60IS") & dtImportedSpirit60.Rows.Count > 0))
                    dr4["60IS"] = dtImportedSpirit60.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("280IS") & dtImportedSpirit280.Rows.Count > 0))
                    dr4["280IS"] = dtImportedSpirit280.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("200IS") & dtImportedSpirit200.Rows.Count > 0))
                    dr4["200IS"] = dtImportedSpirit200.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("500IS") & dtImportedSpirit500.Rows.Count > 0))
                    dr4["500IS"] = dtImportedSpirit500.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("1750IS") & dtImportedSpirit1750.Rows.Count > 0))
                    dr4["1750IS"] = dtImportedSpirit1750.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("50IS") & dtImportedSpirit50.Rows.Count > 0))
                    dr4["50IS"] = dtImportedSpirit50.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("900IS") & dtImportedSpirit900.Rows.Count > 0))
                    dr4["900IS"] = dtImportedSpirit900.Rows[4]["totsale"].ToString();
                // ------------------------------------------------------
                // -----------------------SPIRITS------------------------


                if ((dtt.Columns.Contains("1000SP") & dtSPIRITS1000.Rows.Count > 0))
                    dr4["1000SP"] = dtSPIRITS1000.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("700SP") & dtSPIRITS700.Rows.Count > 0))
                    dr4["700SP"] = dtSPIRITS700.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("750SP") & dtSPIRITS750.Rows.Count > 0))
                    dr4["750SP"] = dtSPIRITS750.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("650SP") & dtSPIRITS650.Rows.Count > 0))
                    dr4["650SP"] = dtSPIRITS650.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("600SP") & dtSPIRITS600.Rows.Count > 0))
                    dr4["600SP"] = dtSPIRITS600.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("375SP") & dtSPIRITS375.Rows.Count > 0))
                    dr4["375SP"] = dtSPIRITS375.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("330SP") & dtSPIRITS330.Rows.Count > 0))
                    dr4["330SP"] = dtSPIRITS330.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("325SP") & dtSPIRITS325.Rows.Count > 0))
                    dr4["325SP"] = dtSPIRITS325.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("180SP") & dtSPIRITS180.Rows.Count > 0))
                    dr4["180SP"] = dtSPIRITS180.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("60SP") & dtSPIRITS60.Rows.Count > 0))
                    dr4["60SP"] = dtSPIRITS60.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("275SP") & dtSPIRITS275.Rows.Count > 0))
                    dr4["275SP"] = dtSPIRITS275.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("50SP") & dtSPIRITS50.Rows.Count > 0))
                    dr4["50SP"] = dtSPIRITS50.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("90SP") & dtSPIRITS90.Rows.Count > 0))
                    dr4["90SP"] = dtSPIRITS90.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("2000SP") & dtSPIRITS2000.Rows.Count > 0))
                    dr4["2000SP"] = dtSPIRITS2000.Rows[4]["totsale"].ToString();

                if ((dtt.Columns.Contains("500SP") & dtSPIRITS500.Rows.Count > 0))
                    dr4["500SP"] = dtSPIRITS500.Rows[4]["totsale"].ToString();

                // -----------------------------------------------
                // ---------------------Imported Wine-------------
                if ((dtt.Columns.Contains("1000IW") & dtImportedWines1000.Rows.Count > 0))
                    dr4["1000IW"] = dtImportedWines1000.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("700IW") & dtImportedWines700.Rows.Count > 0))
                    dr4["700IW"] = dtImportedWines700.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("750IW") & dtImportedWines750.Rows.Count > 0))
                    dr4["750IW"] = dtImportedWines750.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("650IW") & dtImportedWines650.Rows.Count > 0))
                    dr4["650IW"] = dtImportedWines650.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("375IW") & dtImportedWines375.Rows.Count > 0))
                    dr4["375IW"] = dtImportedWines375.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("330IW") & dtImportedWines330.Rows.Count > 0))
                    dr4["330IW"] = dtImportedWines330.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("325IW") & dtImportedWines325.Rows.Count > 0))
                    dr4["325IW"] = dtImportedWines325.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("180IW") & dtImportedWines180.Rows.Count > 0))
                    dr4["180IW"] = dtImportedWines180.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("60IW") & dtImportedWines60.Rows.Count > 0))
                    dr4["60IW"] = dtImportedWines60.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("720IW") & dtImportedWines720.Rows.Count > 0))
                    dr4["720IW"] = dtImportedWines720.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("300IW") & dtImportedWines300.Rows.Count > 0))
                    dr4["300IW"] = dtImportedWines300.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("1500IW") & dtImportedWines1500.Rows.Count > 0))
                    dr4["1500IW"] = dtImportedWines1500.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("1800IW") & dtImportedWines1800.Rows.Count > 0))
                    dr4["1800IW"] = dtImportedWines1800.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("200IW") & dtImportedWines200.Rows.Count > 0))
                    dr4["200IW"] = dtImportedWines200.Rows[4]["totsale"].ToString();

                if ((dtt.Columns.Contains("900IW") & dtImportedWines900.Rows.Count > 0))
                    dr4["900IW"] = dtImportedWines900.Rows[4]["totsale"].ToString();

                if ((dtt.Columns.Contains("187IW") & dtImportedWines187.Rows.Count > 0))
                    dr4["187IW"] = dtImportedWines187.Rows[4]["totsale"].ToString();


                // --------------------------------------------------
                // -----------------------Wine-----------------------
                if ((dtt.Columns.Contains("1000WN") & dtWine1000.Rows.Count > 0))
                    dr4["1000WN"] = dtWine1000.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("700WN") & dtWine700.Rows.Count > 0))
                    dr4["700WN"] = dtWine700.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("750WN") & dtWine750.Rows.Count > 0))
                    dr4["750WN"] = dtWine750.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("650WN") & dtWine650.Rows.Count > 0))
                    dr4["650WN"] = dtWine650.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("375WN") & dtWine375.Rows.Count > 0))
                    dr4["375WN"] = dtWine375.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("330WN") & dtWine330.Rows.Count > 0))
                    dr4["330WN"] = dtWine330.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("325WN") & dtWine325.Rows.Count > 0))
                    dr4["325WN"] = dtWine325.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("180WN") & dtWine180.Rows.Count > 0))
                    dr4["180WN"] = dtWine180.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("60WN") & dtWine60.Rows.Count > 0))
                    dr4["60WN"] = dtWine60.Rows[4]["totsale"].ToString();

                if ((dtt.Columns.Contains("1500WN") & dtWine1500.Rows.Count > 0))
                    dr4["1500WN"] = dtWine1500.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("720WN") & dtWine720.Rows.Count > 0))
                    dr4["720WN"] = dtWine720.Rows[4]["totsale"].ToString();

                if ((dtt.Columns.Contains("250WN") & dtWine250.Rows.Count > 0))
                    dr4["250WN"] = dtWine250.Rows[4]["totsale"].ToString();

                // --------------------------------------------------
                // ----------------Draft Beer------------------------
                if ((dtt.Columns.Contains("1000 MLDB") & dtDraftBeer1000.Rows.Count > 0))
                    dr4["1000 MLDB"] = dtDraftBeer1000.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("1000DB") & dtDraftBeer1000.Rows.Count > 0))
                    dr4["1000DB"] = dtDraftBeer1000.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("700DB") & dtDraftBeer700.Rows.Count > 0))
                    dr4["700DB"] = dtDraftBeer700.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("750DB") & dtDraftBeer750.Rows.Count > 0))
                    dr4["750DB"] = dtDraftBeer750.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("650DB") & dtDraftBeer650.Rows.Count > 0))
                    dr4["650DB"] = dtDraftBeer650.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("375DB") & dtDraftBeer375.Rows.Count > 0))
                    dr4["375DB"] = dtDraftBeer375.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("330DB") & dtDraftBeer330.Rows.Count > 0))
                    dr4["330DB"] = dtDraftBeer330.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("325DB") & dtDraftBeer325.Rows.Count > 0))
                    dr4["325DB"] = dtDraftBeer325.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("180DB") & dtDraftBeer180.Rows.Count > 0))
                    dr4["180DB"] = dtDraftBeer180.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("60DB") & dtDraftBeer60.Rows.Count > 0))
                    dr4["60DB"] = dtDraftBeer60.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("355DB") & dtDraftBeer355.Rows.Count > 0))
                    dr4["355DB"] = dtDraftBeer355.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("1500DB") & dtDraftBeer1500.Rows.Count > 0))
                    dr4["1500DB"] = dtDraftBeer1500.Rows[4]["totsale"].ToString();

                // ---------------------------------------------------
                // ------------MildBeer-------------------------------
                if ((dtt.Columns.Contains("1000MB") & dtMildBeer1000.Rows.Count > 0))
                    dr4["1000MB"] = dtMildBeer1000.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("700MB") & dtMildBeer700.Rows.Count > 0))
                    dr4["700MB"] = dtMildBeer700.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("750MB") & dtMildBeer750.Rows.Count > 0))
                    dr4["750MB"] = dtMildBeer750.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("650MB") & dtMildBeer650.Rows.Count > 0))
                    dr4["650MB"] = dtMildBeer650.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("330MB") & dtMildBeer330.Rows.Count > 0))
                    dr4["330MB"] = dtMildBeer330.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("325MB") & dtMildBeer325.Rows.Count > 0))
                    dr4["325MB"] = dtMildBeer325.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("275MB") & dtMildBeer275.Rows.Count > 0))
                    dr4["275MB"] = dtMildBeer275.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("500MB") & dtMildBeer500.Rows.Count > 0))
                    dr4["500MB"] = dtMildBeer500.Rows[4]["totsale"].ToString();
                // -------------------------------------------------
                // ------Imported Beer------------------------------

                if ((dtt.Columns.Contains("355IB") & dtImporteddBeer355.Rows.Count > 0))
                    dr4["355IB"] = dtImporteddBeer355.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("330IB") & dtImporteddBeer330.Rows.Count > 0))
                    dr4["330IB"] = dtImporteddBeer330.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("300IB") & dtImporteddBeer300.Rows.Count > 0))
                    dr4["300IB"] = dtImporteddBeer300.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("1000IB") & dtImporteddBeer1000.Rows.Count > 0))
                    dr4["1000IB"] = dtImporteddBeer1000.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("500IB") & dtImporteddBeer500.Rows.Count > 0))
                    dr4["500IB"] = dtImporteddBeer500.Rows[4]["totsale"].ToString();

                // ------------FERMENTED BEER-------------------------------

                if ((dtt.Columns.Contains("330FB") & dtFermenteddBeer330.Rows.Count > 0))
                    dr4["330FB"] = dtFermenteddBeer330.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("500FB") & dtFermenteddBeer500.Rows.Count > 0))
                    dr4["500FB"] = dtFermenteddBeer500.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("650FB") & dtFermenteddBeer650.Rows.Count > 0))
                    dr4["650FB"] = dtFermenteddBeer650.Rows[4]["totsale"].ToString();



                // ------------COUNTRY LIQOUR-------------------------------

                if ((dtt.Columns.Contains("750CL") & dtCountryLiqour750.Rows.Count > 0))
                    dr4["750CL"] = dtCountryLiqour750.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("375CL") & dtCountryLiqour375.Rows.Count > 0))
                    dr4["375CL"] = dtCountryLiqour375.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("180CL") & dtCountryLiqour180.Rows.Count > 0))
                    dr4["180CL"] = dtCountryLiqour180.Rows[4]["totsale"].ToString();
                if ((dtt.Columns.Contains("90CL") & dtCountryLiqour90.Rows.Count > 0))
                    dr4["90CL"] = dtCountryLiqour90.Rows[4]["totsale"].ToString();




                dtt.Rows.Add(dr4);
            }

            grdChataiReport.DataSource = dtt;
            grdChataiReport.DataBind();

            ViewState["ObjPriDt"] = dtt;
        }

    }
}