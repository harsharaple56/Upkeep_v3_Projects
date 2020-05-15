using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_Gatepass_Workpermit
{
    public partial class Location : System.Web.UI.Page
    {
        string StrConn = string.Empty;
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }

            if (!IsPostBack)
            {
                PopulateRootLevel();
            }
        }

        private void PopulateRootLevel()
        {
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();

            SqlConnection objConn = new SqlConnection(StrConn);
            //SqlCommand objCommand = new SqlCommand(("select id,title,(select count(*) FROM Tbl_Test_Location_Tree " + "WHERE parentid=sc.id) childnodecount FROM Tbl_Test_Location_Tree sc where parentID IS NULL"), objConn);
            SqlCommand objCommand = new SqlCommand("Spr_Fetch_Location_RootLevel", objConn);
            objCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(objCommand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            PopulateNodes(dt, TreeView1.Nodes);
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
            StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();

            SqlConnection objConn = new SqlConnection(StrConn);
            //SqlCommand objCommand = new SqlCommand(("select id,title,(select count(*) FROM Tbl_Test_Location_Tree " + "WHERE parentid=sc.id) childnodecount FROM Tbl_Test_Location_Tree sc where parentID=@parentID"), objConn);
            SqlCommand objCommand = new SqlCommand("Spr_Fetch_Location_SubLevel", objConn);
            objCommand.CommandType = CommandType.StoredProcedure;

            objCommand.Parameters.Add("@parentID", SqlDbType.Int).Value = parentid;
            SqlDataAdapter da = new SqlDataAdapter(objCommand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            PopulateNodes(dt, parentNode.ChildNodes);
        }

        protected void TreeView1_TreeNodePopulate(object sender, System.Web.UI.WebControls.TreeNodeEventArgs e)
        {
            PopulateSubLevel(int.Parse(e.Node.Value), e.Node);
            //txtbox.Text = e.Node.Text;
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            //txtbox.Text = Convert.ToString(TreeView1.SelectedNode.Value);
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
                dsParent = Add_Update_Location_Node(ParentID, Location_Node, LoggedInUserID, strAction);

                if (dsParent.Tables.Count > 0)
                {
                    if (dsParent.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsParent.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            TreeView1.SelectedNode.Text = txtNewNode.Text.Trim();
                            txtNewNode.Text = "";
                            hdnNode.Value = "";
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
            //TreeView1.SelectedNode.Text = txtNewNode.Text.Trim();
            //txtNewNode.Text = "";
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
                dsParent = Add_Update_Location_Node(ParentID, Location_Node, LoggedInUserID, strAction);

                if (dsParent.Tables.Count > 0)
                {
                    if (dsParent.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsParent.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            TreeNode node = new TreeNode(txtNewNode.Text.Trim());
                            //TreeView1.Nodes.Add(node);
                            TreeView1.SelectedNode.ChildNodes.Add(node);
                            txtNewNode.Text = "";
                            hdnNode.Value = "";
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
            //TreeNode node = new TreeNode(txtNewNode.Text.Trim());
            //TreeView1.SelectedNode.ChildNodes.Add(node);
            //txtNewNode.Text = "";
        }

        protected void btnAddParent_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            DataSet dsParent = new DataSet();
            int ParentID=0;
            string Location_Node=string.Empty;
            string strAction = string.Empty;
            try
            {
                if (Convert.ToString(hdnNode.Value) != "")
                {
                    ParentID = Convert.ToInt32(hdnNode.Value);
                }
                Location_Node = txtNewNode.Text.Trim();
                strAction = "Add";
                dsParent = Add_Update_Location_Node(ParentID, Location_Node, LoggedInUserID, strAction);

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
                            hdnNode.Value = "";
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

        public DataSet Add_Update_Location_Node(int ParentID,string Location_Node, string LoggedInUserID, string strAction)
        {
            DataSet ds = new DataSet();
            try
            {
                StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();

                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Location_AddUpdateNode", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ParentID", ParentID);
                cmd.Parameters.AddWithValue("@Node", Location_Node);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Action", strAction);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        [WebMethod]
        public static List<object> Bind_LocationTree()
        {
            List<object> chartData = new List<object>();
            string StrConn = string.Empty;

            try
            {
                chartData.Add(new object[]
                 {
                    "ID", "ParentID","title"
                 });

                StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();

                using (SqlConnection con = new SqlConnection(StrConn))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from Tbl_Test_Location_Tree"))
                    {
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@SelectedCompany", Selected_Company);
                        //cmd.Parameters.AddWithValue("@FromDate", From_Date);
                        //cmd.Parameters.AddWithValue("@ToDate", To_Date);
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                chartData.Add(new object[]
                                {
                                    sdr["ID"], sdr["ParentID"], sdr["title"]
                                });
                            }
                        }
                        con.Close();
                        return chartData;
                    }
                }

                //return chartData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       
    }
}