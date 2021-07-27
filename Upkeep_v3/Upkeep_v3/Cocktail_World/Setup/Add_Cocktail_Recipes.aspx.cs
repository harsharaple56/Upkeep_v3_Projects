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
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            if (!IsPostBack)
            {
                Fetch_CocktailName();
                Fetch_BrandLinkUp();

                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Name"), new DataColumn("Size"), new DataColumn("Pegml") });
                ViewState["Customers"] = dt;
            }
        }


        protected void txtCocktail_TextChanged(object sender, EventArgs e)
        {
            ddlCocktail.ClearSelection();
            ddlCocktail.SelectedIndex = 0;
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Name"), new DataColumn("Size"), new DataColumn("Pegml") });
            grdAddData.DataSource = null;
            grdAddData.DataBind();
            ViewState["Customers"] = dt;
        }

        protected void ddlCocktail_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCocktail.Text = "";
            if (!string.IsNullOrEmpty(ddlCocktail.SelectedItem.Text))
            {
                ds = ObjCocktailWorld.Fetch_Cocktail_Brand_Details(ddlCocktail.SelectedItem.Text, CompanyID);
                if (ds.Tables[0].Rows.Count > 0)
                    txtRate.Text = ds.Tables[0].Rows[0]["Cocktail_Rate"].ToString();
                grdAddData.DataSource = ds.Tables[0].Copy();
                grdAddData.DataBind();
                DataTable dt = new DataTable();
                dt = ds.Tables[0].Copy();
                ViewState["Customers"] = dt;
            }
        }

        public void Fetch_CocktailName()
        {
            ds = ObjCocktailWorld.CocktailMaster_CRUD("", "", CompanyID, "", "Fetch");
            ddlCocktail.DataSource = ds.Tables[0];
            ddlCocktail.DataTextField = "Cocktail_Desc";
            ddlCocktail.DataValueField = "Cocktail_ID";
            ddlCocktail.DataBind();
            ddlCocktail.Items.Insert(0, new ListItem("", "0"));
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
                txtpegml.Text = "";
            }
        }

        protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBrand.SelectedIndex == 0)
            {
                ddlSize.Items.Clear();
            }
            Fetch_BrandLinkUp();
        }

        protected void ddlSize_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        public void Fetch_BrandLinkUp()
        {
            DataSet dsCategory = new DataSet();
            int BrandID = 0;

            if (!string.IsNullOrEmpty(ddlBrand.SelectedValue))
                BrandID = Convert.ToInt32(ddlBrand.SelectedValue);
            else
                BrandID = 0;

            try
            {

                dsCategory = ObjCocktailWorld.FetchBrandSizeLinkup(0, BrandID);

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
                if (CheckDuplicateValue())
                {
                    if (CheckGridEmptyOrNot())
                    {
                        if (!string.IsNullOrEmpty(txtCocktail.Text))
                        {
                            string Action = "Insert";
                            ds = ObjCocktailWorld.CocktailMaster_CRUD(txtCocktail.Text, txtRate.Text, CompanyID, LoggedInUserID, Action);
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
                                    dsBrandId = ObjCocktailWorld.BrandMaster_CRUD(CompanyID, 0, 0, 0, name, 0, 0, 0, 0, 0, LoggedInUserID, "Fetch");
                                    ObjCocktailWorld.CocktailBrandsMaster_CRUD(Convert.ToInt32(ds.Tables[0].Rows[0]["Cocktail_ID"]), Convert.ToInt32(dsBrandId.Tables[0].Rows[0]["Brand_ID"]), Convert.ToInt32(peg), Convert.ToInt32(size), CompanyID, LoggedInUserID, Action);

                                }
                            }
                            ds.AcceptChanges();
                        }
                        else
                        {
                            //Update Rate In Cocktial Master Table
                            ds = ObjCocktailWorld.CocktailMaster_CRUD(ddlCocktail.SelectedItem.Text, txtRate.Text, CompanyID, LoggedInUserID, "Update");

                            //Fetch Old Grid From Cocktail Brand Master Table
                            DataSet dsOldGrid = new DataSet();
                            dsOldGrid = ObjCocktailWorld.CocktailBrandsMaster_CRUD(Convert.ToInt32(ds.Tables[0].Rows[0]["Cocktail_ID"]), 0, 0, 0, CompanyID, LoggedInUserID, "Fetch_OldGrid");

                            if (dsOldGrid.Tables[0].Rows.Count > 0 && grdAddData.Rows.Count > 0)
                            {
                                for (int i = 0; i < dsOldGrid.Tables[0].Rows.Count; i++)
                                {
                                    DataSet dsBrandId = new DataSet();
                                    dsBrandId = ObjCocktailWorld.BrandMaster_CRUD(CompanyID, 0, 0, 0, dsOldGrid.Tables[0].Rows[i]["Brand_Desc"].ToString(), 0, 0, 0, 0, 0, LoggedInUserID, "Fetch");
                                    ObjCocktailWorld.CocktailBrandsMaster_CRUD(Convert.ToInt32(ds.Tables[0].Rows[0]["Cocktail_ID"]), Convert.ToInt32(dsBrandId.Tables[0].Rows[0]["Brand_ID"]), Convert.ToInt32(dsOldGrid.Tables[0].Rows[i]["Peg_ML_Qty"]), Convert.ToInt32(dsOldGrid.Tables[0].Rows[i]["Size"]), CompanyID, LoggedInUserID, "Delete");
                                }

                                DataTable dtGridData = new DataTable();
                                foreach (TableCell cell in grdAddData.HeaderRow.Cells)
                                {
                                    dtGridData.Columns.Add(cell.Text);
                                }
                                foreach (GridViewRow row in grdAddData.Rows)
                                {
                                    dtGridData.Rows.Add();
                                    for (int i = 0; i < row.Cells.Count; i++)
                                    {
                                        dtGridData.Rows[row.RowIndex][i] = row.Cells[i].Text;
                                    }
                                }
                                for (int i = 0; i < dtGridData.Rows.Count; i++)
                                {
                                    DataSet dsBrandId = new DataSet();
                                    dsBrandId = ObjCocktailWorld.BrandMaster_CRUD(CompanyID, 0, 0, 0, dtGridData.Rows[i]["Brand Name"].ToString(), 0, 0, 0, 0, 0, LoggedInUserID, "Fetch");
                                    ObjCocktailWorld.CocktailBrandsMaster_CRUD(Convert.ToInt32(ds.Tables[0].Rows[0]["Cocktail_ID"]), Convert.ToInt32(dsBrandId.Tables[0].Rows[0]["Brand_ID"]), Convert.ToInt32(dtGridData.Rows[i]["ML / Peg"]), Convert.ToInt32(dtGridData.Rows[i]["Size"]), CompanyID, LoggedInUserID, "Insert");
                                }
                            }
                        }

                        ds.AcceptChanges();
                    }
                    else
                    {
                        Response.Write("<script>alert('Nothing To Save.')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Cocktail Name Already Exists.')</script>");
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

        public bool CheckDuplicateValue()
        {
            string Cocktail_Desc = txtCocktail.Text;
            for (int i = 0; i < ddlCocktail.Items.Count; i++)
            {
                if (ddlCocktail.Items[i].Text != "" && txtCocktail.Text == ddlCocktail.Items[i].Text)
                {
                    return false;
                }
            }
            return true;
        }
    }
}