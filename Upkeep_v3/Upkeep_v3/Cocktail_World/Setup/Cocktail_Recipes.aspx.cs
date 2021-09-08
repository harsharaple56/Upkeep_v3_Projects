using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Cocktail_World.Setup
{
    public partial class Cocktail_Recipes : System.Web.UI.Page
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
                
            }
        }

        public string BindCocktailRecipes()
        {
            string data = "";
            try
            {
                ds = ObjCocktailWorld.CocktailMaster_CRUD(string.Empty, string.Empty,CompanyID,LoggedInUserID ,"F");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Cocktail_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Cocktail_ID"]);
                            string Cocktail_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Cocktail_Desc"]);
                            string Cocktail_Rate = Convert.ToString(ds.Tables[0].Rows[i]["Cocktail_Rate"]);
                            string Brand_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Brand_Desc"]);
                            string Size = Convert.ToString(ds.Tables[0].Rows[i]["Size"]);
                            string Peg_ML_Qty = Convert.ToString(ds.Tables[0].Rows[i]["Peg_ML_Qty"]);

                            data += "<tr>";
                            data += "<td>" + Cocktail_Desc + "</td>";
                            data += "<td>" + Cocktail_Rate + "</td>";
                            data += "<td>" + Brand_Desc + "</td>";
                            data += "<td>" + Size + "</td>";
                            data += "<td>" + Peg_ML_Qty + "</td>";
                            data += "<td>" +
                                "<a href='Add_Cocktail_Recipes.aspx?Cocktail_ID=" + Cocktail_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  " +
                                "<a href='Cocktail_Recipes.aspx?DelCocktail_ID=" + Cocktail_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> " +
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

        protected void btnExport_Click(object sender, EventArgs e)
        {
            GridView dgGrid = new GridView();
            DataSet dsExport = new DataSet();
            string currentDate = string.Empty;

            try
            {
                dsExport = ObjCocktailWorld.CocktailMaster_CRUD(string.Empty, string.Empty, CompanyID, LoggedInUserID, "F");

                DataTable dtCocktailMasterReport = new DataTable();

                if (dsExport.Tables.Count > 0)
                {
                    if (dsExport.Tables[0].Rows.Count > 0)
                    {
                        dtCocktailMasterReport = dsExport.Tables[0];

                        dtCocktailMasterReport.Columns.Remove("Cocktail_ID");
                        dtCocktailMasterReport.Columns["Cocktail_Desc"].ColumnName = "Cocktail Name";
                        dtCocktailMasterReport.Columns["Cocktail_Rate"].ColumnName = "Cocktail Rate";
                        dtCocktailMasterReport.Columns["Brand_Desc"].ColumnName = "Brand Name";
                        dtCocktailMasterReport.Columns["Size"].ColumnName = "Size";
                        dtCocktailMasterReport.Columns["Peg_ML_Qty"].ColumnName = "Peg / ML";
                        dtCocktailMasterReport.AcceptChanges();

                        dgGrid.DataSource = dtCocktailMasterReport;
                        dgGrid.DataBind();

                        currentDate = DateTime.Now.ToString();

                        System.IO.StringWriter tw = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                        string filename = "Cocktail Recipes REPORT AS ON " + currentDate + ".xls";

                        string HeaderText = "Cocktail Recipes REPORT AS ON " + currentDate;

                        Style textStyle = new Style();
                        textStyle.ForeColor = System.Drawing.Color.DarkCyan;
                        hw.EnterStyle(textStyle);

                        hw.Write("<h2><center>" + HeaderText + "</center></h2> </br>");
                        hw.ExitStyle(textStyle);

                        dgGrid.RenderControl(hw);

                        Response.ContentType = "application/vnd.ms-excel";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                        this.EnableViewState = false;
                        Response.Write(tw.ToString());
                        Response.End();
                        return;

                    }
                    else
                    {
                        dgGrid.DataSource = null;
                        dgGrid.DataBind();

                        return;
                    }
                }
                else
                {
                    dgGrid.DataSource = null;
                    dgGrid.DataBind();

                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}