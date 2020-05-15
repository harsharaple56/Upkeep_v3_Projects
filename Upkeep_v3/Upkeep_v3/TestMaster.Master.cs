using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Upkeep_v3
{
    public partial class TestMaster : System.Web.UI.MasterPage
    {
        DataTable dtGlobal = new DataTable();

        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dtMenuDetails = new DataTable();
            //dtMenuDetails = ObjUpkeep.FetchMenu(0).Tables[0];

            dtGlobal = dtMenuDetails.Copy();

            DataTable dtx = new DataTable();
            dtx = dtMenuDetails.Copy();
            dtx.DefaultView.RowFilter = "Parent_Menu_Id = 0";
            dtx = dtx.DefaultView.ToTable();

            rptVerMenu.DataSource = dtx;
            rptVerMenu.DataBind();
            //if (!this.IsPostBack)
            //{
            //    //populateMenuItem();
            //    DataTable dt = this.GetData(0);
            //   PopulateMenu(dt, 0, null);
            //}
        }

        private DataTable GetData(int parentMenuId)
        {
            DataSet dtMenuDetails = new DataSet();
            try
            {
                //dtMenuDetails= ObjUpkeep.FetchMenu(parentMenuId);
                //rptVerMenu.DataSource = dtMenuDetails;
                //rptVerMenu.DataBind();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtMenuDetails.Tables[0];

            //string query = "SELECT [Menu_Id], Menu_Desc as [Title], Menu_Desc as [Description], [Menu_Url] FROM [Tbl_Menu_Mst] where Parent_Menu_Id = "+ parentMenuId;
            //string constr = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    DataTable dt = new DataTable();
            //    using (SqlCommand cmd = new SqlCommand(query))
            //    {
            //        using (SqlDataAdapter sda = new SqlDataAdapter())
            //        {
            //            cmd.Parameters.AddWithValue("@ParentMenuId", parentMenuId);
            //            cmd.CommandType = CommandType.Text;
            //            cmd.Connection = con;
            //            sda.SelectCommand = cmd;
            //            sda.Fill(dt);
            //        }
            //    }
            //    return dt;
            //}
        }

        private void PopulateMenu(DataTable dt, int parentMenuId, MenuItem parentMenuItem)
        {
            string currentPage = Path.GetFileName(Request.Url.AbsolutePath);
            foreach (DataRow row in dt.Rows)
            {
                MenuItem menuItem = new MenuItem
                {
                    
                    Value = row["Menu_Id"].ToString(),
                    Text = row["Title"].ToString(),
                    NavigateUrl = row["Menu_Url"].ToString(),
                    Selected = row["Menu_Url"].ToString().EndsWith(currentPage, StringComparison.CurrentCultureIgnoreCase)
                };
                if (parentMenuId == 0)
                {
                    Menu1.Items.Add(menuItem);
                    DataTable dtChild = this.GetData(int.Parse(menuItem.Value));
                    PopulateMenu(dtChild, int.Parse(menuItem.Value), menuItem);
                }
                else
                {
                    parentMenuItem.ChildItems.Add(menuItem);
                }
            }
        }

        //private void populateMenuItem()
        //{

        //    DataTable menuData = GetMenuData();
        //    AddTopMenuItems(menuData);

        //}
        //private void AddTopMenuItems(DataTable menuData)
        //{
        //    DataView view = new DataView(menuData);
        //    view.RowFilter = "Parent_menu_ID IS NULL";
        //    foreach (DataRowView row in view)
        //    {
        //        //MenuItem newMenuItem = new MenuItem(row["DepartmentName"].ToString(), row["DepartmentID"].ToString());
        //        MenuItem newMenuItem = new MenuItem(row["Menu_Desc"].ToString(), row["Menu_Id"].ToString());

        //        Menu1.Items.Add(newMenuItem);
        //        AddChildMenuItems(menuData, newMenuItem);
        //    }

        //}
        //private void AddChildMenuItems(DataTable menuData, MenuItem parentMenuItem)
        //{
        //    DataView view = new DataView(menuData);
        //    view.RowFilter = "Parent_menu_ID=" + parentMenuItem.Value;
        //    foreach (DataRowView row in view)
        //    {
        //        MenuItem newMenuItem = new MenuItem(row["Menu_Desc"].ToString(), row["Menu_Id"].ToString());
        //        parentMenuItem.ChildItems.Add(newMenuItem);
        //        AddChildMenuItems(menuData, newMenuItem);
        //    }
        //}

        //private DataTable GetMenuData()
        //{
        //    string conStr = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(conStr))
        //    {

        //        using (SqlCommand cmd = new SqlCommand("SELECT [Menu_Id], [Menu_Desc],  [Menu_Url],[Parent_menu_ID] FROM [Tbl_Menu_Mst]", con))
        //        {
        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);
        //            return dt;
        //        }

        //    }
        //}



        //NEW METHOD

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


    }


 

}