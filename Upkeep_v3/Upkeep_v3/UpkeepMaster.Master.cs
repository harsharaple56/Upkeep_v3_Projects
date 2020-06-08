using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

namespace Upkeep_v3
{
    public partial class UpkeepMaster : System.Web.UI.MasterPage
    {
        DataTable dtGlobal = new DataTable();

        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        string SessionVisitor = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            SessionVisitor = Convert.ToString(Session["Visitor"]);

            if (string.IsNullOrEmpty(LoggedInUserID) && string.IsNullOrEmpty(SessionVisitor))
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }


            DataTable dtMenuDetails = new DataTable();
            dtMenuDetails = ObjUpkeep.FetchMenu(0, LoggedInUserID).Tables[0];

            dtGlobal = dtMenuDetails.Copy();

            DataTable dtx = new DataTable();
            dtx = dtMenuDetails.Copy();
            dtx.DefaultView.RowFilter = "Parent_Menu_Id = 0";
            dtx = dtx.DefaultView.ToTable();

            rptVerMenu.DataSource = dtx;
            rptVerMenu.DataBind();
            
            if (!IsPostBack)
            {
                lblUsername.Text = Convert.ToString(Session["UserName"]);
                lblProfileName.Text = Convert.ToString(Session["LoggedInProfileName"]);
            }
        }

        private DataTable GetData(int parentMenuId)
        {
            DataSet dtMenuDetails = new DataSet();
            try
            {
                dtMenuDetails = ObjUpkeep.FetchMenu(parentMenuId, LoggedInUserID);
                
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
    }
}