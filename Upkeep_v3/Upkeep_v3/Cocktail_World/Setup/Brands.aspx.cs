using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.Cocktail_World.Setup
{
    public partial class Brands : System.Web.UI.Page
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
                int Brand_ID = Convert.ToInt32(Request.QueryString["Brand_ID"]);
                if (Brand_ID > 0)
                {
                    //BindBrand(Brand_ID);
                }
                int DelBrand_ID = Convert.ToInt32(Request.QueryString["DelBrand_ID"]);
                if (DelBrand_ID > 0)
                {
                    DeleteBrand(DelBrand_ID);
                }
            }
        }

        public string bindgrid()
        {
            string data = "";
            try
            {
                ds = ObjCocktailWorld.BrandMaster_CRUD(CompanyID,0, 0, 0, 0, "", "",  0, string.Empty, 0, LoggedInUserID, "R");
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Brand_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Brand_ID"]);
                            string Category_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Category_Desc"]);
                            string SubCategory_Desc = Convert.ToString(ds.Tables[0].Rows[i]["SubCategory_Desc"]);
                            string Brand_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Brand_Desc"]);
                            string Brand_Short_Desc = Convert.ToString(ds.Tables[0].Rows[i]["ShortName"]);

                            data += "<tr>";
                            data += "<td>" + Brand_Desc + "</td>";
                            data += "<td>" + Brand_Short_Desc + "</td>";
                            data += "<td>" + Category_Desc + "</td>";
                            data += "<td>" + SubCategory_Desc + "</td>";
                            data += "<td>" +
                                "<a href='Brands.aspx?Brand_ID=" + Brand_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  " +
                                "<a href='Brands.aspx?DelBrand_ID=" + Brand_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> " +
                                "</td>";
                            data += "</tr>";
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

        public void DeleteBrand(int Brand_ID)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = ObjCocktailWorld.BrandMaster_CRUD(CompanyID,0, Brand_ID, 0, 0, "", "",  0, string.Empty, 0, LoggedInUserID, "D");
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Brands.aspx"), false);
                        }
                        else if (Status == 4)
                        {
                            Page.ClientScript.RegisterHiddenField("selected", "selected");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}