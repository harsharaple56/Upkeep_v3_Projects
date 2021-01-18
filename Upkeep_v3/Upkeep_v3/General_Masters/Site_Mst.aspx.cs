using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using System.Globalization;

namespace Upkeep_v3.General_Masters
{
    public partial class Site_Mst : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeepCC = new Upkeep_V3_Services.Upkeep_V3_Services();

        // string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            int Site_ID = Convert.ToInt32(Request.QueryString["Site_ID"]);
            int DelSite_ID = Convert.ToInt32(Request.QueryString["DelSite_ID"]);
            if (Site_ID > 0)
            {
                Session["Site_ID"] = Convert.ToString(Site_ID);

                bindSite_Master(Site_ID);
            }
            if (DelSite_ID > 0)
            {
                DeleteSite_Master(DelSite_ID);
            }

        }



        public void bindSite_Master(int Site_ID)
        {
            try
            {
                ds = ObjUpkeepCC.SiteMaster_CRUD(Site_ID, "", "", CompanyID, LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["Site_ID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Site_ID"]);
                        txtSitecode.Text = Convert.ToString(ds.Tables[0].Rows[0]["Site_Code"]);
                        txtSiteDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["Site_Desc"]);
                        mpeCategoryMaster.Show();
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
        }



        public void DeleteSite_Master(int Site_ID)
        {
            try
            {
                ds = ObjUpkeepCC.SiteMaster_CRUD(Site_ID, "", "", CompanyID, LoggedInUserID, "D");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //Session["Site_ID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Site_ID"]);
                        //txtSitecode.Text = Convert.ToString(ds.Tables[0].Rows[0]["Site_Code"]);
                        //txtSiteDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["Site_Desc"]);
                        //mpeCategoryMaster.Show();
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
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {



        }

        protected void btnSiteSave_ServerClick(object sender, EventArgs e)
        {

            

        }

        protected void btnSite_New_Click(object sender, EventArgs e)
        {

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            txtSitecode.Text = "";
            txtSiteDesc.Text = "";
            lblErrorMsg.Text = "";
            mpeCategoryMaster.Hide();
            Session["Site_ID"] = "";
            Response.Redirect(Page.ResolveClientUrl("~/General_Masters/Site_Mst.aspx"), false);


        }

        protected void btnSiteMst_Click(object sender, EventArgs e)
        {
            int Site_ID = 0;
            if (Convert.ToString(Session["Site_ID"]) != "")
            {
                Site_ID = Convert.ToInt32(Session["Site_ID"]);
            }

            string Action = "";
            DataSet ds = new DataSet();

            if (Site_ID > 0)
            {
                Action = "U";
            }
            else
            {
                Action = "C";
            }



            string Site_Code = string.Empty;
            string Site_Name = string.Empty;




            Site_Code = txtSitecode.Text.Trim();
            Site_Name = txtSiteDesc.Text.Trim();


            ds = ObjUpkeepCC.SiteMaster_CRUD(Site_ID, Site_Code, Site_Name, CompanyID, LoggedInUserID, Action);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                    if (Status == 1)
                    {
                        Session["User_ID"] = "";

                        Response.Redirect(Page.ResolveClientUrl("~/General_Masters/Site_Mst.aspx"), false);
                    }
                    else if (Status == 3)
                    {
                         lblErrorMsg.Text = "";
                    }
                    else if (Status == 2)
                    {
                         lblErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                    }
                }
            }

        }

        public string bindgrid()
        {

            int Site_ID = 0;

            string data = "";
            try
            {
                ds = ObjUpkeepCC.SiteMaster_CRUD(Site_ID, "", "", CompanyID, LoggedInUserID, "R");


                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int SiteID = Convert.ToInt32(ds.Tables[0].Rows[i]["Site_ID"]);
                            string Site_Code = Convert.ToString(ds.Tables[0].Rows[i]["Site_Code"]);
                            string Site_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Site_Desc"]);
                           

                            data += "<tr><td>" + Site_Code + "</td><td>" + Site_Desc + "</td><td><a href='Site_Mst.aspx?Site_ID=" + SiteID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  <a href='Site_Mst.aspx?DelSite_ID=" + SiteID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

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



        protected void btnCloseHeader_ServerClick(object sender, EventArgs e)
        {

        }
    }
}