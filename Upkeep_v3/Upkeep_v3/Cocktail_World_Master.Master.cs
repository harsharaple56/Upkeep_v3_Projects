using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Configuration;
using System.Web.Configuration;

namespace Upkeep_v3
{
    public partial class Cocktail_World_Master : System.Web.UI.MasterPage
    {

        DataTable dtGlobal = new DataTable();

        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        string SessionVisitor = string.Empty;
        string ModuleIDs = string.Empty;
        int CompanyID = 0;
        string UserType = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            SessionVisitor = Convert.ToString(Session["Visitor"]);
            UserType = Convert.ToString(Session["UserType"]);

            if (string.IsNullOrEmpty(LoggedInUserID) && string.IsNullOrEmpty(SessionVisitor))
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }


            if (Convert.ToString(Session["CompanyID"]) != "")
            {
                CompanyID = Convert.ToInt32(Session["CompanyID"]);
            }

            if (UserType == "E")
            {

            }
            else if (UserType == "R")
            {
                div_list_Quick_Links_MyChecklist.Visible = false;
                div_list_Quick_Reports.Visible = false;
                div_list_Quick_Links_VistRequest.Visible = false;
                div_list_Quick_Links_CSM_Request.Visible = false;

            }



            ModuleIDs = Convert.ToString(Session["ModuleID"]);

            DataTable dtMenuDetails = new DataTable();
            dtMenuDetails = ObjUpkeep.FetchMenu(0, LoggedInUserID, ModuleIDs, CompanyID).Tables[0];

            dtGlobal = dtMenuDetails.Copy();

            DataTable dtx = new DataTable();
            dtx = dtMenuDetails.Copy();
            dtx.DefaultView.RowFilter = "Parent_Menu_Id = 0";
            dtx = dtx.DefaultView.ToTable();

            rptVerMenu.DataSource = dtx;
            rptVerMenu.DataBind();


            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            if (!IsPostBack)
            {
                //Session Timeout
                Session["Reset"] = true;
                Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
                SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
                int timeout = (int)section.Timeout.TotalMinutes * 1000 * 60;
                //int timeout = (int)section.Timeout.TotalMinutes * 60;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SessionAlert", "SessionExpireAlert(" + timeout + ");", true);

                //Session Timeout

                lblUsername.Text = Convert.ToString(Session["UserName"]);
                lblProfileName.Text = Convert.ToString(Session["LoggedInProfileName"]);

                string VD_Path = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadURL"]);

                Image1.ImageUrl = VD_Path + "/assets/demo/media/img/logo/efacilito_White.png";
                Img_CompanyLogo.ImageUrl = Convert.ToString(Session["Company_Logo"]);


                //Image1.ImageUrl = Convert.ToString(Session["Company_Logo"]);


                if (Convert.ToString(Session["Profile_Photo"]) != "")
                {
                    imgProfilePic.ImageUrl = Convert.ToString(Session["Profile_Photo"]);
                    imgProfilePic1.ImageUrl = Convert.ToString(Session["Profile_Photo"]);
                }
                else
                {
                    //imgProfilePic.ImageUrl = Page.ResolveClientUrl("~/assets/app/media/img/users/user4.png");
                    //imgProfilePic1.ImageUrl = Page.ResolveClientUrl("~/assets/app/media/img/users/user4.png");
                    imgProfilePic.ImageUrl = VD_Path + "/assets/app/media/img/users/user4.png";
                    imgProfilePic1.ImageUrl = VD_Path + "/assets/app/media/img/users/user4.png";
                }


            }
        }

        private DataTable GetData(int parentMenuId)
        {
            DataSet dtMenuDetails = new DataSet();
            try
            {
                dtMenuDetails = ObjUpkeep.FetchMenu(parentMenuId, LoggedInUserID, ModuleIDs, CompanyID);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtMenuDetails.Tables[0];
        }

        protected void rptVerMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Reference the Repeater Item.
                RepeaterItem item = e.Item;

                //string DivId = (e.Item.FindControl("DivSectionIDLabel") as Label).Text;
                string DivId = (e.Item.FindControl("hfMenuId") as HiddenField).Value;
                Repeater rptVerSubMenu = e.Item.FindControl("rptVerSubMenu") as Repeater;

                DataTable dtSubMenu = new DataTable();
                dtSubMenu = dtGlobal.Copy();
                DataTable dt = new DataTable();
                dt = dtSubMenu.Copy();
                dt.DefaultView.RowFilter = "Parent_Menu_Id = " + Convert.ToString(DivId) + "";
                dt = dt.DefaultView.ToTable();
                if (dt.Rows.Count > 0)
                {
                    rptVerSubMenu.DataSource = dt;
                    rptVerSubMenu.DataBind();
                }
                else
                {
                    DataTable dt1 = new DataTable();
                    rptVerSubMenu.DataSource = dt1;
                    rptVerSubMenu.DataBind();
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("~/Login.aspx");
        }

        protected void lnkProfile_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["UserType"]) == "E")
            {
                Response.Redirect("~/My_Profile.aspx");
            }
            else if (Convert.ToString(Session["UserType"]) == "R")
            {
                Response.Redirect("~/Retailer_Profile.aspx");
            }
        }

        protected void lnkUserManual_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["UserType"]) == "E")
            {
                Response.Redirect("~/Knowledge_Base/User_Manual.aspx");
            }
            else if (Convert.ToString(Session["UserType"]) == "R")
            {
                Response.Redirect("~/Knowledge_Base/Retailer_Manual.aspx");
            }
        }

        protected void lnkManageAccount_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["UserType"]) == "E")
            {
                Response.Redirect("~/Manage_Account/Billing/Invoices_listing.aspx");
            }
            else if (Convert.ToString(Session["UserType"]) == "R")
            {
                Response.Redirect("~/Dashboard.aspx");
            }
        }

    }
}