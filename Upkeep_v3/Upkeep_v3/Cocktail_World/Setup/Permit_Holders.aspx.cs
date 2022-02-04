using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.Cocktail_World.Setup
{
    public partial class Permit_Holders : System.Web.UI.Page
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
                int Permit_ID = Convert.ToInt32(Request.QueryString["Permit_ID"]);
                if (Permit_ID > 0)
                {
                    BindPermit(Permit_ID);
                }
                int DelPermit_ID = Convert.ToInt32(Request.QueryString["DelPermit_ID"]);
                if (DelPermit_ID > 0)
                {
                    DeletePermit(DelPermit_ID);
                }
            }
        }

        public void DeletePermit(int Permit_ID)
        {
            try
            {
                ObjCocktailWorld.PermitMaster_CRUD(Permit_ID, string.Empty, string.Empty, string.Empty, string.Empty, false, LoggedInUserID, CompanyID, "D");
                Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Permit_Holders.aspx"), false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnClosePermit_Click(object sender, EventArgs e)
        {
            Closecontrol();
        }

        public void Closecontrol()
        {
            //txtPermit.Text = "";
            mpeCategoryMaster.Hide();
            Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Permit_Holders.aspx"), false);
        }

        protected void btnPermitSave_Click(object sender, EventArgs e)
        {
            int Permit_ID = 0;
            string Permit_Holder = txtPermitHolder.Text;
            string Permit_Number = txtPermitNumber.Text;
            string Permit_Type = ddlPermitType.SelectedItem.ToString();
            string Expire_Date = string.Empty;
            DateTime date = Convert.ToDateTime(txtExpireDate.Text);
            Expire_Date = date.ToString("dd-MMMM-yyyy");

            bool Life_Time = false;
            if (chkLifeTime.Checked == true)
            {
                Life_Time = true;
            }
            else
            {
                Life_Time = false;
            }

            try
            {
                if (Convert.ToInt32(Request.QueryString["Permit_ID"]) > 0)
                {
                    Permit_ID = Convert.ToInt32(Request.QueryString["Permit_ID"]);
                }
                string Action = "";

                if (Permit_ID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                ds = ObjCocktailWorld.PermitMaster_CRUD(Permit_ID, Permit_Type, Permit_Holder, Permit_Number, Expire_Date, Life_Time, LoggedInUserID, CompanyID, Action);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            txtExpireDate.Text = "";
                            txtPermitHolder.Text = "";
                            txtPermitNumber.Text = "";
                            mpeCategoryMaster.Hide();
                            Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Permit_Holders.aspx"), false);
                        }
                        else if (Status == 3)
                        {
                            lblCategoryErrorMsg.Text = "Permit already exists";
                        }
                        else if (Status == 2)
                        {
                            lblCategoryErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindPermit(int Permit_ID)
        {
            try
            {
                ds = ObjCocktailWorld.PermitMaster_CRUD(Permit_ID, string.Empty, string.Empty, string.Empty, string.Empty, false, LoggedInUserID, CompanyID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DateTime ExpiryDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["ExpireDate"]);
                        txtExpireDate.Text = ExpiryDate.ToString("dd-MMMM-yyyy");
                        txtPermitHolder.Text = Convert.ToString(ds.Tables[0].Rows[0]["Permit_Holder_Name"]);
                        txtPermitNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["Permit_Number"]);

                        string txtPermitType = Convert.ToString(ds.Tables[0].Rows[0]["Permit_Type"]);
                        ddlPermitType.ClearSelection();
                        ddlPermitType.Items.FindByText(txtPermitType).Selected = true;

                        string Is_LifeTime = Convert.ToString(ds.Tables[0].Rows[0]["Is_LifeTime"]);
                        if (Is_LifeTime == "True")
                        {
                            chkLifeTime.Checked = true;
                        }
                        else
                        {
                            chkLifeTime.Checked = false;
                        }
                        mpeCategoryMaster.Show();
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
                ds = ObjCocktailWorld.PermitMaster_CRUD(0, string.Empty, string.Empty, string.Empty, string.Empty, false, LoggedInUserID, CompanyID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Permit_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Permit_ID"]);
                            string Permit_Holder = Convert.ToString(ds.Tables[0].Rows[i]["Permit_Holder_Name"]);
                            string Permit_Type = Convert.ToString(ds.Tables[0].Rows[i]["Permit_Type"]);
                            string Permit_Number = Convert.ToString(ds.Tables[0].Rows[i]["Permit_Number"]);
                            string date = string.Empty;
                            DateTime ExpiryDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["ExpireDate"]);
                            date = ExpiryDate.ToString("dd-MMMM-yyyy");
                            string Is_LifeTime = Convert.ToString(ds.Tables[0].Rows[i]["Is_LifeTime"]);

                            data += "<tr><td>" + Permit_Type + "</td>" +
                                    "<td>" + Permit_Holder + "</td>" +
                                    "<td>" + Permit_Number + "</td>" +
                                    "<td>" + date + "</td>" +
                                    "<td>" + Is_LifeTime + "</td>" +
                                    "<td><a href='Permit_holders.aspx?Permit_ID=" + Permit_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  <a href='Permit_holders.aspx?DelPermit_ID=" + Permit_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";
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