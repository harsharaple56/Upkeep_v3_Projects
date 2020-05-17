using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;

namespace Upkeep_v3_Control_Center.Masters
{
    public partial class Add_Group : System.Web.UI.Page
    {
        UpkeepControlCenter_Service.UpkeepControlCenter_Service objUpkeepCC = new UpkeepControlCenter_Service.UpkeepControlCenter_Service();
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //frmGroup.Action = @"Add_Group.aspx";
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            lblErrorMsg.Text = "";
            if (!IsPostBack)
            {
                int GroupID = Convert.ToInt32(Request.QueryString["GroupID"]);
                int GroupID_Delete = Convert.ToInt32(Request.QueryString["DelGroupID"]);
                if (GroupID > 0)
                {
                    Session["GroupID"] = Convert.ToString(GroupID);
                    bindGroup_Master(GroupID);
                }
                if (GroupID_Delete > 0)
                {
                    DeleteGroup_Master(GroupID_Delete);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int GroupID = 0;

                if (Convert.ToString(Session["GroupID"]) != "")
                {
                    GroupID = Convert.ToInt32(Session["GroupID"]);
                }
                string Action = "";
                DataSet ds = new DataSet();

                if (GroupID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                ds = objUpkeepCC.GroupMaster_CRUD(GroupID, txtGrpDesc.Text.Trim(), txtGrpCode.Text.Trim(), LoggedInUserID, "0", Action);
              
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
                            Session["GroupID"] = "";
                            Response.Redirect(Page.ResolveClientUrl("~/Masters/Group_Mst.aspx"), false);
                            //Response.Redirect("~/Masters/Group_Mst.aspx", false);
                        }
                        else if (Status == 3)
                        {
                            lblErrorMsg.Text = "Group Code/ Group Description already exists";
                        }
                        else if (Status == 2)
                        {
                            lblErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void bindGroup_Master(int GroupID)
        {

            try
            {
                DataSet ds = new DataSet();

                ds = objUpkeepCC.GroupMaster_CRUD(GroupID, "", "", "1", "0", "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        txtGrpDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["Group_Desc"]);
                        txtGrpCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["Group_Code"]);


                        //int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        //if (Status == 0)
                        //{

                        //}
                        //else if (Status == 1)
                        //{
                        //    //Response.Redirect("~/Masters/Group_Mst.aspx", false);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void DeleteGroup_Master(int GroupID_Delete)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objUpkeepCC.GroupMaster_CRUD(GroupID_Delete, "", "", "1", "0", "D");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //Response.Redirect("~/Masters/Group_Mst.aspx", false);
                        Response.Redirect(Page.ResolveClientUrl("~/Masters/Group_Mst.aspx"), false);
                    }

                }
                else
                {
                    //invalid login
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}