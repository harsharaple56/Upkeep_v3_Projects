using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.General_Masters
{
    public partial class Add_UserGrp_Mst : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeepCC = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        public static int Grp_Id=0;
        public static string Action;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            //frmUserGrp.Action = @"Add_UserGrp_Mst.aspx";

            // frmUserGrp.Action = @"General_Masters/Add_UserGrp_Mst.aspx";

            ViewState["User_ID"] = Convert.ToString(Request.QueryString["User_ID"]);

            if (!IsPostBack)
            {
                //bindgrid();
                Grp_Id = Convert.ToInt32(Request.QueryString["Grp_Id"]);
                int DelGrp_Id = Convert.ToInt32(Request.QueryString["DelGrp_Id"]);

                bindgrid(Grp_Id);
                if (Grp_Id > 0)
                {
                   // bindgrid(Grp_Id);
                    fetchGroup(Grp_Id);
                }
                if (DelGrp_Id > 0)
                {
                    DeleteGroup(DelGrp_Id);
                }
            }

            //ClientScript.RegisterStartupScript(typeof(string), "load", "<script>FunPubOnload();</script>");
        }

        public void bindgrid(int Grp_Id)
        {
            string data = string.Empty;

            try
            {
                ds = ObjUpkeepCC.FetchUserGrp(Grp_Id,CompanyID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        string StrUser_ID = Convert.ToString(ViewState["User_ID"]);
                        String[] User_ID = StrUser_ID.Split(',');


                        //int ctr;
                        //for (ctr = 0; (ctr < User_ID.Length); ctr++)
                        //{
                        //    TxtMembers.Text = (TxtMembers.Text + ("=$=" + User_ID[ctr]));
                        //}

                        //TxtMembers.Text = (TxtMembers.Text + "=$=");

                        Usernm.DataSource = ds;
                        Usernm.DataBind();




                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAddUserGrp_Click(object sender, EventArgs e)
        {

            string SelectedUsers = string.Empty;
            var rows = Usernm.Rows;
            int count = Usernm.Rows.Count;

            //string strGrdEmp = GrdEmp.Value;
            //strGrdEmp = strGrdEmp.TrimEnd(',');

            if (Grp_Id == 0)
            {
                Action = "C";
            }
            else
            {
                Action = "U";
            }

            try
            {

                for (int i = 0; i < count; i++)
                {
                    bool isChecked = ((CheckBox)rows[i].FindControl("chkUserID")).Checked;
                    if (isChecked)
                    {
                        //string EmployeeID = gvEmployee.Rows[i].Cells[1].Text;
                        string UserID = ((HiddenField)rows[i].FindControl("hdnUserID")).Value;
                        SelectedUsers = SelectedUsers + UserID + ",";
                    }
                }

                SelectedUsers = SelectedUsers.TrimEnd(',');
                if (SelectedUsers != "")
                {
                    ds = ObjUpkeepCC.UserGroupMaster_CRUD(Grp_Id, txtGroupName.Text, SelectedUsers, CompanyID, LoggedInUserID, Action);

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
                                //Response.Redirect("~/General_Masters/UserGrp_Mst.aspx", false);
                                Response.Redirect(Page.ResolveClientUrl("~/General_Masters/UserGrp_Mst.aspx"), false);
                            }
                            else if (Status == 3)
                            {
                                lblErrorMsg.Text = "Group Name already exists";
                            }
                            else if (Status == 2)
                            {
                                lblErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                            }
                        }
                    }
                }
                else
                {
                    lblErrorMsg.Text = "Please Select atleast one Employee";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void fetchGroup(int Grp_Id)
        {
            try
            {
                //txtGroupName.Enabled = false;

                ds = ObjUpkeepCC.UserGroupMaster_CRUD(Grp_Id, "", "", CompanyID, LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["Grp_Id"] = ds.Tables[0].Rows[0]["GroupID"];
                        txtGroupName.Text = Convert.ToString(ds.Tables[0].Rows[0]["GroupName"]);
                        // ChkEmp.Value = Convert.ToString(ds.Tables[0].Rows[0]["User_Id"]);
                        
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

        public void DeleteGroup(int DelGrp_Id)
        {
            try
            {
                ds = ObjUpkeepCC.UserGroupMaster_CRUD(DelGrp_Id, "", "", CompanyID, LoggedInUserID, "D");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["Grp_Id"] = "";
                        //Response.Redirect("~/UserGrp_Mst.aspx", false);
                        Response.Redirect(Page.ResolveClientUrl("~/General_Masters/UserGrp_Mst.aspx"), false);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Usernm_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if ((e.Row.RowType == DataControlRowType.DataRow))
            //{
            //    //System.Web.UI.HtmlControls.HtmlInputCheckBox Chk = new System.Web.UI.HtmlControls.HtmlInputCheckBox();
            //    //Chk.ID = "";
            //    //Chk.Value = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "User_Id"));
            //    //Chk.Attributes.Add("onclick", "FunLocCheck(this);");
            //    //Chk.Attributes.Add("class", "selectable");
            //    //e.Row.Cells[0].Controls.Add(Chk);
            //}
        }
    }
}