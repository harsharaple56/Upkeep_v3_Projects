using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.General_Masters
{
    public partial class LocationTree : System.Web.UI.Page
    {
        static string ZoneName = string.Empty;
        static string LocName = string.Empty;
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            if (LoggedInUserID == "")
            {
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            if (!IsPostBack)
            {
                PopulateRootLevel();
            }
        }

        private void PopulateRootLevel()
        {
            DataSet dsRoot = new DataSet();
            try
            {
                dsRoot = ObjUpkeep.Location_PopulateRootLevel(CompanyID);

                if (dsRoot.Tables.Count > 0)
                {
                    if (dsRoot.Tables[0].Rows.Count > 0)
                    {
                        PopulateNodes(dsRoot.Tables[0], TreeView1.Nodes);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


           
        }

        private void PopulateNodes(DataTable dt, TreeNodeCollection nodes)
        {
            foreach (DataRow dr in dt.Rows)
            {
                TreeNode tn = new TreeNode();
                //tn.Text = dr["title"].ToString();
                //tn.Value = dr["id"].ToString();
                tn.Text = dr["Loc_Desc"].ToString();
                tn.Value = dr["Loc_id"].ToString();
                nodes.Add(tn);
                // If node has child nodes, then enable on-demand populating
                //tn.PopulateOnDemand = (int.Parse(dr["childnodecount"]) > 0);
                tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);

            }

        }

        private void PopulateSubLevel(int parentid, TreeNode parentNode)
        {
            DataSet dsSubLevel = new DataSet();
            try
            {
                dsSubLevel = ObjUpkeep.Location_PopulateSubLevel(parentid);

                if (dsSubLevel.Tables.Count > 0)
                {
                    if (dsSubLevel.Tables[0].Rows.Count > 0)
                    {
                        PopulateNodes(dsSubLevel.Tables[0], parentNode.ChildNodes);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        protected void TreeView1_TreeNodePopulate(object sender, System.Web.UI.WebControls.TreeNodeEventArgs e)
        {
            PopulateSubLevel(int.Parse(e.Node.Value), e.Node);
           
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {

            hdnNode.Value = Convert.ToString(TreeView1.SelectedNode.Value);
            lblSelectedLocation.Text = TreeView1.SelectedNode.Text;
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            //TreeNode node = new TreeNode(txtbox.Text);
            // TreeView1.SelectedNode.ChildNodes.Add(node);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            DataSet dsParent = new DataSet();
            int ParentID = 0;
            string Location_Node = string.Empty;
            string strAction = string.Empty;
            try
            {
                if (Convert.ToString(hdnNode.Value) != "")
                {
                    ParentID = Convert.ToInt32(hdnNode.Value);
                }
                Location_Node = txtNewNode.Text.Trim();
                strAction = "Update";
                dsParent = ObjUpkeep.Add_Update_Location_Node(ParentID, Location_Node, CompanyID, LoggedInUserID, strAction);

                if (dsParent.Tables.Count > 0)
                {
                    if (dsParent.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsParent.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            TreeView1.SelectedNode.Text = txtNewNode.Text.Trim();
                            txtNewNode.Text = "";

                            lblErrorMsg.Text = "";
                        }
                        else if (Status == 2)
                        {
                            lblErrorMsg.Text = "Location already exists. Please enter a different name";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnAddChild_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            DataSet dsParent = new DataSet();
            int ParentID = 0;
            string Location_Node = string.Empty;
            string strAction = string.Empty;
            try
            {
                if (Convert.ToString(hdnNode.Value) != "")
                {
                    ParentID = Convert.ToInt32(hdnNode.Value);
                }
                Location_Node = txtNewNode.Text.Trim();
                strAction = "Add";
                dsParent = ObjUpkeep.Add_Update_Location_Node(ParentID, Location_Node, CompanyID, LoggedInUserID, strAction);

                if (dsParent.Tables.Count > 0)
                {
                    if (dsParent.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsParent.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            TreeNode node = new TreeNode(txtNewNode.Text.Trim());

                            TreeView1.SelectedNode.ChildNodes.Add(node);
                            txtNewNode.Text = "";

                            lblErrorMsg.Text = "";
                        }
                        else if (Status == 2)
                        {
                            lblErrorMsg.Text = "Location already exists. Please enter a different name";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnAddParent_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            DataSet dsParent = new DataSet();
            int ParentID = 0;
            string Location_Node = string.Empty;
            string strAction = string.Empty;
            try
            {
                if (Convert.ToString(hdnNode.Value) != "")
                {
                    ParentID = Convert.ToInt32(hdnNode.Value);
                }
                Location_Node = txtNewNode.Text.Trim();
                strAction = "Add";
                dsParent = ObjUpkeep.Add_Update_Location_Node(ParentID, Location_Node, CompanyID, LoggedInUserID, strAction);

                if (dsParent.Tables.Count > 0)
                {
                    if (dsParent.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsParent.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            TreeNode node = new TreeNode(txtNewNode.Text.Trim());
                            TreeView1.Nodes.Add(node);
                            txtNewNode.Text = "";

                            lblErrorMsg.Text = "";
                        }
                        else if (Status == 2)
                        {
                            lblErrorMsg.Text = "Location already exists. Please enter a different name";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {

            //TreeView tv1 = new TreeView();
            //TreeNode tn = new TreeNode();

            //tv1.Nodes.Remove(tv1.SelectedNode);


            //TreeView1.Nodes.Remove(TreeView1.SelectedNode);
            //TreeView1.Nodes.Clear();

            //TreeNode node = TreeView1.SelectedNode;
            //if (TreeView1.SelectedNode != null)
            //{
            //    if (TreeView1.SelectedNode.Parent == null)
            //        TreeView1.SelectedNode.Remove(TreeView1.SelectedNode);
            //    else if (TreeView1.SelectedNode.Parent.Nodes.Count == 1)
            //        TreeView1.SelectedNode.Parent.Remove();
            //    else
            //        TreeView1.SelectedNode.Remove();
            //}

        }

        //public DataSet Add_Update_Location_Node(int ParentID, string Location_Node, string LoggedInUserID, string strAction)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();

        //        SqlConnection con = new SqlConnection(StrConn);
        //        SqlCommand cmd = new SqlCommand("Spr_Location_AddUpdateNode", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@ParentID", ParentID);
        //        cmd.Parameters.AddWithValue("@Node", Location_Node);
        //        cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
        //        cmd.Parameters.AddWithValue("@Action", strAction);
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(ds);
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}




    }
}