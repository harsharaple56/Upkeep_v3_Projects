using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Cocktail_World.Setup
{
    public partial class Add_Cocktail_Recipes : System.Web.UI.Page
    {
        CocktailWorld_Service.CocktailWorld_Service ObjCocktailWorld = new CocktailWorld_Service.CocktailWorld_Service();

        DataSet ds = new DataSet();
        public static string LoggedInUserID = string.Empty;
        public static int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            if (!IsPostBack)
            {
                Bind_License();

                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Name"), new DataColumn("Size"), new DataColumn("Pegml") });
                ViewState["Customers"] = dt;

                int Cocktail_ID = Convert.ToInt32(Request.QueryString["Cocktail_ID"]);
                if (Cocktail_ID > 0)
                {
                    UpdateCocktail(Cocktail_ID);
                }
                int DelCocktail_ID = Convert.ToInt32(Request.QueryString["DelCocktail_ID"]);
                if (DelCocktail_ID > 0)
                {
                    DeleteCocktail(DelCocktail_ID);
                }
            }
        }

        public void Bind_License()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = ObjCocktailWorld.License_CRUD(0, "", "", LoggedInUserID, CompanyID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlLicense.DataSource = ds.Tables[0];
                        ddlLicense.DataTextField = "License_Name";
                        ddlLicense.DataValueField = "License_ID";
                        ddlLicense.DataBind();
                        ddlLicense.Items.Insert(0, new ListItem("--Select License--", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateCocktail(int Cocktail_ID)
        {
            SetUpdateData(Cocktail_ID);
        }

        public void DeleteCocktail(int DelCocktail_ID)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = ObjCocktailWorld.CocktailBrandsMaster_CRUD(DelCocktail_ID,0,0,0,0, CompanyID, LoggedInUserID, "DeleteGridData");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Cocktail_Recipes.aspx"), false);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void SetUpdateData(int Cocktail_ID)
        {
            ds = ObjCocktailWorld.CocktailMaster_CRUD(Cocktail_ID, string.Empty, string.Empty, CompanyID, LoggedInUserID,0, "FetchEditData");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlLicense.SelectedValue = ds.Tables[0].Rows[0]["License_ID"].ToString();
                Fetch_BrandLinkUp(Convert.ToInt32(ddlLicense.SelectedValue));
                txtRate.Text = ds.Tables[0].Rows[0]["Cocktail_Rate"].ToString();
                Page.ClientScript.RegisterHiddenField("CocktailName", ds.Tables[0].Rows[0]["Cocktail_Desc"].ToString());
            }
            grdAddData.DataSource = ds.Tables[0].Copy();
            grdAddData.DataBind();
            DataTable dt = new DataTable();
            dt = ds.Tables[0].Copy();
            ViewState["Customers"] = dt;
        }

        protected void BindGrid()
        {
            grdAddData.DataSource = (DataTable)ViewState["Customers"];
            grdAddData.DataBind();
        }

        protected void btnAddtoRow_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtpegml.Text) && ddlBrand.SelectedIndex != 0 && ddlSize.SelectedIndex != 0)
            {
                DataTable dt = (DataTable)ViewState["Customers"];
                dt.Rows.Add(ddlBrand.SelectedItem.Text, ddlSize.SelectedItem.Text, txtpegml.Text);
                ViewState["Customers"] = dt;
                BindGrid();
                ddlBrand.SelectedIndex = 0;
                ddlSize.SelectedIndex = 0;
                txtpegml.Text = string.Empty;
            }
        }

        protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBrand.SelectedIndex == 0)
            {
                ddlSize.Items.Clear();
            }
            Fetch_BrandLinkUp(Convert.ToInt32(ddlLicense.SelectedValue));
        }

        public void Fetch_BrandLinkUp(int License_ID)
        {
            DataSet dsCategory = new DataSet();
            int BrandID = 0;

            if (!string.IsNullOrEmpty(ddlBrand.SelectedValue))
                BrandID = Convert.ToInt32(ddlBrand.SelectedValue);
            else
                BrandID = 0;

            try
            {
                dsCategory = ObjCocktailWorld.FetchBrandSizeLinkup(0, BrandID, 0, "", "", CompanyID,License_ID,string.Empty, DateTime.Now);

                if (BrandID == 0)
                {
                    ddlBrand.DataSource = dsCategory.Tables[0];
                    ddlBrand.DataTextField = "Brand_Desc";
                    ddlBrand.DataValueField = "Brand_ID";
                    ddlBrand.DataBind();
                    ddlBrand.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                else if (BrandID > 0)
                {
                    ddlSize.DataSource = dsCategory.Tables[0];
                    ddlSize.DataTextField = "Alias";
                    ddlSize.DataValueField = "Size_ID";
                    ddlSize.DataBind();
                    ddlSize.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (Button button in e.Row.Cells[0].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Are You Sure Want To Remove ?')){ return false; };";
                    }
                }
            }
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = ViewState["Customers"] as DataTable;
            dt.Rows[index].Delete();
            dt.AcceptChanges();
            ViewState["Customers"] = dt;
            BindGrid();
        }

        protected void grdAddData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAddData.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckGridEmptyOrNot())
                {
                    string Cocktail_Name = hdnCocktailName.Value;
                    int Cocktail_ID = CheckCocktailNameExists(Cocktail_Name);
                    if (Cocktail_ID > 0)
                    {
                        //Delete old data
                        ObjCocktailWorld.CocktailMaster_CRUD(Cocktail_ID, Cocktail_Name, txtRate.Text, CompanyID, LoggedInUserID,0, "DeleteData");

                        //update data
                        DataSet ds = new DataSet();
                        string Action = "U";
                        ds = ObjCocktailWorld.CocktailMaster_CRUD(Cocktail_ID, Cocktail_Name, txtRate.Text, CompanyID, LoggedInUserID,Convert.ToInt32(ddlLicense.SelectedValue), Action);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (GridViewRow row in grdAddData.Rows)
                            {
                                string name = "";
                                string size = "";
                                string peg = "";
                                for (int i = 0; i < grdAddData.Columns.Count; i++)
                                {
                                    String header = grdAddData.Columns[i].HeaderText;
                                    String cellText = row.Cells[i].Text;
                                    if (header == "Brand Name")
                                        name = cellText;
                                    if (header == "ML / Peg")
                                        peg = cellText;
                                    if (header == "Size")
                                        size = cellText;
                                }
                                DataSet dsBrandId = new DataSet();
                                string grdAction = string.Empty;
                                dsBrandId = ObjCocktailWorld.BrandMaster_CRUD(CompanyID,0, 0, 0, 0, name, string.Empty, 0,size, Convert.ToInt32(ds.Tables[0].Rows[0]["Cocktail_ID"]), LoggedInUserID, "Fetch");
                                if (dsBrandId.Tables[0].Rows.Count > 0)
                                {
                                    int CocktailBrandID = dsBrandId.Tables[0].Rows[0]["Cocktail_Brand_ID"].ToString() != "" ? Convert.ToInt32(dsBrandId.Tables[0].Rows[0]["Cocktail_Brand_ID"]) : 0;
                                    if (CocktailBrandID > 0)
                                        grdAction = "U";
                                    else
                                        grdAction = "I";

                                    ObjCocktailWorld.CocktailBrandsMaster_CRUD(CocktailBrandID, Convert.ToInt32(ds.Tables[0].Rows[0]["Cocktail_ID"]), Convert.ToInt32(dsBrandId.Tables[1].Rows[0]["Brand_ID"]), Convert.ToInt32(peg), Convert.ToInt32(size), CompanyID, LoggedInUserID, grdAction);
                                }
                                else {
                                    ObjCocktailWorld.CocktailBrandsMaster_CRUD(0, Convert.ToInt32(ds.Tables[0].Rows[0]["Cocktail_ID"]), Convert.ToInt32(dsBrandId.Tables[1].Rows[0]["Brand_ID"]), Convert.ToInt32(peg), Convert.ToInt32(size), CompanyID, LoggedInUserID, "I");
                                }
                            }
                        }
                        ds.AcceptChanges();
                        Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Cocktail_Recipes.aspx"), false);
                    }
                    else
                    {
                        DataSet ds = new DataSet();
                        string Action = "I";
                        ds = ObjCocktailWorld.CocktailMaster_CRUD(Cocktail_ID, Cocktail_Name, txtRate.Text, CompanyID, LoggedInUserID, Convert.ToInt32(ddlLicense.SelectedValue), Action);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (GridViewRow row in grdAddData.Rows)
                            {
                                string name = "";
                                string size = "";
                                string peg = "";
                                for (int i = 0; i < grdAddData.Columns.Count; i++)
                                {
                                    String header = grdAddData.Columns[i].HeaderText;
                                    String cellText = row.Cells[i].Text;
                                    if (header == "Brand Name")
                                        name = cellText;
                                    if (header == "ML / Peg")
                                        peg = cellText;
                                    if (header == "Size")
                                        size = cellText;
                                }
                                DataSet dsBrandId = new DataSet();
                                string grdAction = string.Empty;
                                dsBrandId = ObjCocktailWorld.BrandMaster_CRUD(CompanyID,0, 0, 0, 0, name, string.Empty,  0,size, Convert.ToInt32(ds.Tables[0].Rows[0]["Cocktail_ID"]), LoggedInUserID, "Fetch");
                                if (dsBrandId.Tables[1].Rows.Count > 0)
                                {
                                    int CocktailBrandID = 0;
                                    grdAction = "I";

                                    ObjCocktailWorld.CocktailBrandsMaster_CRUD(CocktailBrandID, Convert.ToInt32(ds.Tables[0].Rows[0]["Cocktail_ID"]), Convert.ToInt32(dsBrandId.Tables[1].Rows[0]["Brand_ID"]), Convert.ToInt32(peg), Convert.ToInt32(size), CompanyID, LoggedInUserID, grdAction);
                                }
                            }
                        }

                        ds.AcceptChanges();
                        Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Cocktail_Recipes.aspx"), false);
                    }
                }
                else
                {
                    //grid is empty
                    Page.ClientScript.RegisterHiddenField("GridEmpty","GridEmpty");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckGridEmptyOrNot()
        {
            if (grdAddData.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public int CheckCocktailNameExists(string name)
        {
            int Cocktail_ID = 0;
            if (!string.IsNullOrEmpty(name))
            {
                DataSet ds = new DataSet();
                ds = ObjCocktailWorld.CocktailMaster_CRUD(0, name, string.Empty, CompanyID, LoggedInUserID,0, "Duplicate");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Cocktail_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["Cocktail_ID"]);
                    }
                }
                else
                {
                    Cocktail_ID = 0;
                }
            }
            return Cocktail_ID;
        }


        [System.Web.Services.WebMethod]
        public static Dictionary<string, string> FetchCocktailList(string companycode)
        {
            Dictionary<string, string> dlst = new Dictionary<string, string>();
            Add_Cocktail_Recipes obj = new Add_Cocktail_Recipes();
            DataSet ds = new DataSet();
            ds = obj.ObjCocktailWorld.CocktailMaster_CRUD(0, "", "", CompanyID, "",0, "Fetch");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dlst.Add(ds.Tables[0].Rows[i]["Cocktail_ID"].ToString(), ds.Tables[0].Rows[i]["Cocktail_Desc"].ToString());
                }

            }
            return dlst;
        }

        protected void ddlLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fetch_BrandLinkUp(Convert.ToInt32(ddlLicense.SelectedValue));
        }
    }
}