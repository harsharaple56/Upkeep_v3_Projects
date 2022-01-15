using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Xml;
using System.Collections;

namespace Upkeep_v3.Cocktail_World.Setup
{
    public partial class Brand_Sizes : System.Web.UI.Page
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
                bindgrid();
                int Size_ID = Convert.ToInt32(Request.QueryString["Size_ID"]);
                if (Size_ID > 0)
                {
                    BindSize(Size_ID);
                }
                int DelSize_ID = Convert.ToInt32(Request.QueryString["DelSize_ID"]);
                if (DelSize_ID > 0)
                {
                    DeleteSize(DelSize_ID);
                }
            }
        }

        public void DeleteSize(int Size_ID)
        {
            try
            {
                ds = ObjCocktailWorld.SizeMaster_CRUD(Size_ID, "", 0, LoggedInUserID, CompanyID, "D");
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Brand_Sizes.aspx"), false);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindSize(int Size_ID)
        {
            try
            {
                ds = ObjCocktailWorld.SizeMaster_CRUD(Size_ID, "", 0, LoggedInUserID, CompanyID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["Size_ID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Size_ID"]);
                        txtSizedes.Text = Convert.ToString(ds.Tables[0].Rows[0]["Size_Desc"]);
                        txtSizeAlias.Text = Convert.ToString(ds.Tables[0].Rows[0]["Size_Alias"]);
                        mpeCategoryMaster.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCategorySave_Click(object sender, EventArgs e)
        {
            int Size_ID = 0;
            string Size_Desc = string.Empty;
            int Size_Alias = 0;

            try
            {
                if (Convert.ToString(Request.QueryString["Size_ID"]) != "")
                {
                    Size_ID = Convert.ToInt32(Request.QueryString["Size_ID"]);
                }

                string Action = "";

                if (Size_ID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                Size_Desc = txtSizedes.Text.Trim();
                Size_Alias = Convert.ToInt32(txtSizeAlias.Text.Trim());

                ds = ObjCocktailWorld.SizeMaster_CRUD(Size_ID, Size_Desc, Size_Alias, LoggedInUserID, CompanyID, Action);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            txtSizeAlias.Text = "";
                            txtSizedes.Text = "";
                            mpeCategoryMaster.Hide();
                            Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Brand_Sizes.aspx"), false);
                        }
                        else if (Status == 2)
                        {
                            lblCategoryErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                        else if (Status == 3)
                        {
                            lblCategoryErrorMsg.Text = "Size already exists";
                        }
                        
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string bindgrid()
        {
            string data = "";
            try
            {
                ds = ObjCocktailWorld.SizeMaster_CRUD(0, "", 0, LoggedInUserID, CompanyID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Size_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Size_ID"]);
                            string Size_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Size_Desc"]);
                            string Size_Alias = Convert.ToString(ds.Tables[0].Rows[i]["Size_Alias"]);

                            data += "<tr>";
                            data += "<td>" + Size_Desc + "</td>";
                            data += "<td>" + Size_Alias + "</td>";
                            data += "<td>" +
                                "<a href='Brand_Sizes.aspx?Size_ID=" + Size_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  " +
                                "<a href='Brand_Sizes.aspx?DelSize_ID=" + Size_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> " +
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

        protected void btnCloseCategory_Click(object sender, EventArgs e)
        {
            Closecontrol();
        }

        public void Closecontrol()
        {
            txtSizedes.Text = "";
            txtSizeAlias.Text = "";
            lblCategoryErrorMsg.Text = "";
            mpeCategoryMaster.Hide();
            Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Brand_Sizes.aspx"), false);
        }
    }
}