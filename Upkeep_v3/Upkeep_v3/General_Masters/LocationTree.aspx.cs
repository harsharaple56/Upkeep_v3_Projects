using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

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

        protected void btnImportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string parentNode, childNode, description, tempNode, emptyParentNode, rowColumnNumber;
                parentNode = childNode = description = tempNode = emptyParentNode = rowColumnNumber = string.Empty;
                DataTable dt = new DataTable();

                string path = string.Concat(Server.MapPath("~/Checklist/ImportFile/" + FU_ChecklistMst.FileName));
                FU_ChecklistMst.SaveAs(path);
                string excelCS = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties='Excel 12.0 Xml;HDR=YES'", path);
                OleDbConnection oledbconn = new OleDbConnection(excelCS);
                oledbconn.Open();
                OleDbCommand cmdSelect = new OleDbCommand("select * from [Sheet1$]", oledbconn);
                OleDbDataAdapter oledbda = new OleDbDataAdapter();
                oledbda.SelectCommand = cmdSelect;
                oledbda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    int noOfRows = dt.Rows.Count;
                    int noOfColumns = dt.Columns.Count;

                    for (int i = 0; i < noOfRows; i++)
                    {
                        for (int j = 0; j < noOfColumns; j++)
                        {
                            tempNode = dt.Rows[i][j].ToString();

                            if (tempNode != "")
                            {
                                childNode = tempNode;
                                if (j == 0)
                                {
                                    parentNode = dt.Rows[i][j].ToString();
                                }
                                else
                                {
                                    int n = j - 1;
                                    parentNode = dt.Rows[i][n].ToString();
                                }

                            }

                            if (parentNode == "")
                            {
                                int q = i;

                                for (int p = 0; p < i; p++)
                                {
                                    string sa = dt.Rows[q][j].ToString();
                                    if (sa != "")
                                    {
                                        emptyParentNode = sa.ToString();
                                        break;
                                    }
                                    else
                                    {
                                        q = q - 1;
                                        continue;
                                    }
                                }
                                break;
                            }

                            DataSet dsChkerror = new DataSet();
                            DataTable dterror = new DataTable();
                            rowColumnNumber = "At Row Number : " + i + " , And At Column Number : " + j;
                            dsChkerror = Insert_Treview_ImportExcel(parentNode, childNode, emptyParentNode, rowColumnNumber, CompanyID, LoggedInUserID);
                            if (dsChkerror.Tables.Count > 0)
                            {
                                if (dsChkerror.Tables[0].Rows.Count > 0)
                                {
                                    int Status = Convert.ToInt32(dsChkerror.Tables[0].Rows[0]["Status"]);
                                    if (Status == 1)
                                    {
                                        Response.Redirect(Page.ResolveClientUrl("~/General_Masters/LocationTree.aspx"), false);
                                    }
                                    else
                                    if (Status == 2)
                                    {
                                        dvErrorGrid.Attributes.Add("style", "display:block; overflow-y:auto; height:100px;");
                                        pnlImportExport.Attributes.Add("style", "height:580px; width:700px; top:-14px !important;");
                                        mpeUserMst.Show();
                                        lblImportErrorMsg.Text = "Below checklist can not be created, kindly check error message.";

                                        dterror = dsChkerror.Tables[0];
                                        dterror.Columns.Remove("Status");
                                        gvImportError.DataSource = dterror;
                                        gvImportError.DataBind();
                                        dterror.AcceptChanges();
                                    }
                                }
                            }
                            parentNode = childNode = tempNode = emptyParentNode = rowColumnNumber = string.Empty;
                        }
                    }
                }
                oledbconn.Close();
                oledbda = null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected DataSet Insert_Treview_ImportExcel(string parentNode, string childNode, string emptyParentNode, string rowColumnNumber, int CompanyID, string LoggedInUserID)
        {
            DataSet dsNodes = new DataSet();
            dsNodes = ObjUpkeep.Insert_LocationTree(parentNode, childNode, emptyParentNode, rowColumnNumber, CompanyID, LoggedInUserID);
            return dsNodes;
        }

        protected void btnCloseImportPopUp_Click(object sender, EventArgs e)
        {
            lblImportErrorMsg.Text = "";
            gvImportError.DataSource = null;
            gvImportError.DataBind();
            mpeUserMst.Hide();
        }

        protected void lnkSampleFile_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "~/General_Masters/Template/Location_Import.xlsx";
                string filename = "Location_Import.xlsx";
                Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");
                Response.TransmitFile(Server.MapPath(filePath));
                Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
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
                tn.Text = dr["Loc_Desc"].ToString();
                tn.Value = dr["Loc_id"].ToString();
                nodes.Add(tn);
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
            lblSuccessMsg.Text = "";
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
                            lblSuccessMsg.Text = "Location updated successfully.";
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
            lblSuccessMsg.Text = "";
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
                else
                {
                    lblErrorMsg.Text = "Please select a location first";
                    return;
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
                            TreeView1.Nodes.Clear();
                            PopulateRootLevel();
                            //TreeNode node = new TreeNode(txtNewNode.Text.Trim());
                            //TreeView1.SelectedNode.ChildNodes.Add(node);
                            txtNewNode.Text = "";

                            lblErrorMsg.Text = "";
                            lblSuccessMsg.Text = "Location added successfully.";
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
            lblSuccessMsg.Text = "";
            lblErrorMsg.Text = "";
            DataSet dsParent = new DataSet();
            int ParentID = 0;
            string Location_Node = string.Empty;
            string strAction = string.Empty;
            try
            {
                //if (Convert.ToString(hdnNode.Value) != "")
                //{
                //    ParentID = Convert.ToInt32(hdnNode.Value);
                //}
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

                            TreeView1.Nodes.Clear();
                            PopulateRootLevel();

                            txtNewNode.Text = "";
                            lblSelectedLocation.Text = "";
                            lblErrorMsg.Text = "";
                            hdnNode.Value = "";
                            lblSuccessMsg.Text = "Location added successfully.";
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
            lblSuccessMsg.Text = "";
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
                strAction = "Delete";
                dsParent = ObjUpkeep.Add_Update_Location_Node(ParentID, Location_Node, CompanyID, LoggedInUserID, strAction);

                if (dsParent.Tables.Count > 0)
                {
                    if (dsParent.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsParent.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            //TreeView1.SelectedNode.Text = txtNewNode.Text.Trim();
                            txtNewNode.Text = "";

                            lblErrorMsg.Text = "";
                            lblSuccessMsg.Text = "Location Deleted successfully.";
                            TreeView1.Nodes.Clear();

                            PopulateRootLevel();
                        }
                        //else if (Status == 2)
                        //{
                        //    lblErrorMsg.Text = "Location already exists. Please enter a different name";
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

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


    }
}