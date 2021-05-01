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
                //bindgrid();

                int Permit_ID = Convert.ToInt32(Request.QueryString["Permit_ID"]);
                if (Permit_ID > 0)
                {
                    BindPermit(Permit_ID);
                }
                int DelPermit_ID = Convert.ToInt32(Request.QueryString["DelPermit_ID"]);
                if (DelPermit_ID > 0)
                {
                   // DeleteCategory(DelCategory_ID);
                }

            }

        }




        protected void btnClosePermit_Click(object sender, EventArgs e)
        {

        }

        protected void btnCategoryPermit_Click(object sender, EventArgs e)
        {

        }

        protected void btnPermitSave_Click(object sender, EventArgs e)
        {

            int Permit_ID = 0;

            string Permit_Desc = string.Empty;
           

            try
            {

                if (Convert.ToString(Session["Permit_ID"]) != "")
                {
                    Permit_ID = Convert.ToInt32(Session["Permit_ID"]);
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

                // DepartmentID = Convert.ToInt32(ddlDept.SelectedValue);
                Permit_Desc = txtPermit.Text.Trim();

         

                ds = ds = ObjCocktailWorld.PermitMaster_CRUD(Permit_ID, Permit_Desc, LoggedInUserID,CompanyID, Action);




                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 0)
                        {

                        }
                        else if (Status == 1)
                        {
                            Session["Category_ID"] = "";
                            txtPermit.Text = "";
                          
                            mpeCategoryMaster.Hide();

                            //mpeZone.Hide();
                            //bindgrid();
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

        protected void btnAddPermit_Click(object sender, EventArgs e)
        {

        }

        protected void btnCloseHeader_ServerClick(object sender, EventArgs e)
        {

        }


        public void BindPermit(int Permit_ID)
        {
            try
            {
                ds = ds = ObjCocktailWorld.PermitMaster_CRUD(Permit_ID, "", LoggedInUserID, CompanyID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                       

                            Session["Permit_ID"]  = Convert.ToInt32(ds.Tables[0].Rows[0]["Permit_ID"]);
                          //  string Permit_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Permit_Desc"]);
                            txtPermit.Text = Convert.ToString(ds.Tables[0].Rows[0]["Permit_Desc"]);




                            mpeCategoryMaster.Show();


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
    // return data;

        }


        public string bindgrid()
                {
                    string data = "";
                    try
                    {
                        ds = ds = ObjCocktailWorld.PermitMaster_CRUD(0, "", LoggedInUserID, CompanyID, "R");

                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                                for (int i = 0; i < count; i++)
                                {
                                    int Permit_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Permit_ID"]);
                                    string Permit_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Permit_Desc"]);
                           



                                    data += "<tr><td>" + Permit_ID + "</td><td>" + Permit_Desc + "</td><td><a href='Permit_holders.aspx?Permit_ID=" + Permit_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  <a href='Permit_holders.aspx?DelPermit_ID=" + Permit_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

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
            }
}