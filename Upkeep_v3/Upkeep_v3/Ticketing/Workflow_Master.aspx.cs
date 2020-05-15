using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.Ticketing
{
    public partial class Workflow_Master : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            //frmMain.Action = @"Workflow_Master.aspx";
            if (LoggedInUserID == "")
            {
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }

            if (!IsPostBack)
            {
                Fetch_CategorySubCategory(0); 
                int WorkflowId = Convert.ToInt32(Request.QueryString["WorkflowId"]);
                if (WorkflowId > 0)
                {
                    BindWorkflowMaster(WorkflowId);
                }
                int DelWorkflowID = Convert.ToInt32(Request.QueryString["DelWorkflowID"]);
                if (DelWorkflowID > 0)
                {
                    DeleteWorkflowMaster(DelWorkflowID);
                }
            }
        }

        public void Fetch_CategorySubCategory(int CategoryID)
        {
            //int CategoryID = 0;
            try
            {
                
                ds = ObjUpkeep.Fetch_CategorySubCategory(CategoryID);

                if (CategoryID == 0)
                {
                    ddlCategory.DataSource = ds.Tables[0];
                    ddlCategory.DataTextField = "Category_Desc";
                    ddlCategory.DataValueField = "Category_ID";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                else if (CategoryID > 0)
                {
                    ddlSubCategory.DataSource = ds.Tables[0];
                    ddlSubCategory.DataTextField = "SubCategory_Desc";
                    ddlSubCategory.DataValueField = "SubCategory_ID";
                    ddlSubCategory.DataBind();
                    ddlSubCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string bindWorkflowgrid()
        {
            string data = "";
            try
            {
                ds = ObjUpkeep.WorkflowMaster_CRUD(0, "",0, 0, 0,"",CompanyID, LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Workflow_Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Workflow_Id"]);
                            string Workflow_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Workflow_Desc"]);
                            //string Zone = Convert.ToString(ds.Tables[0].Rows[i]["Zone_Desc"]);
                            string Category_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Category_Desc"]);
                            string SubCategory_Desc = Convert.ToString(ds.Tables[0].Rows[i]["SubCategory_Desc"]);

                            ////data += "<tr><td>" + Frquency_Id + "</td><td>" + Frquency_Desc + "</td><td><a href='General_Masters/Add_Frequency.aspx?Frquency_Id=" + Frquency_Id + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  <a href='General_Masters/Add_Frequency.aspx?DelFreq_ID=" + Frquency_Id + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";
                            data += "<tr><td>" + Workflow_Id + "</td><td>" + Workflow_Desc + "</td><td>" + Category_Desc + "</td><td>" + SubCategory_Desc + "</td><td><a href='Workflow_Details.aspx?WorkflowId=" + Workflow_Id + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  <a href='Workflow_Master.aspx?DelWorkflowID=" + Workflow_Id + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

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

        protected void btnAddWorkflow_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/Ticketing/Workflow_Details.aspx"), false);
        }

        protected void btnWorkflowMstSave_Click(object sender, EventArgs e)
        {
            /*
            int WorkflowID = 0;
            int CategoryID = 0;
            int SubCategoryID = 0;

            try
            {
                if (Convert.ToString(Session["WorkflowID"]) != "")
                {
                    WorkflowID = Convert.ToInt32(Session["WorkflowID"]);
                }
                string Action = "";

                if (WorkflowID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                SubCategoryID = Convert.ToInt32(ddlSubCategory.SelectedValue);

                //ds = ObjUpkeep.WorkflowMaster_CRUD(WorkflowID, txtWorkflowDesc.Text.Trim(), CategoryID, SubCategoryID, LoggedInUserID, Action);

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
                            Session["WorkflowID"] = "";
                            txtWorkflowDesc.Text = "";
                            //mpeWorkflowMaster.Hide();
                            //Zone_bindgrid();
                            //Response.Redirect("~/General_Masters/Locations_Mst.aspx", false);
                            Response.Redirect(Page.ResolveClientUrl("~/Ticketing/Workflow_Master.aspx"), false);
                        }
                        else if (Status == 3)
                        {
                            lblWorkflowErrorMsg.Text = "Workflow already exists";
                        }
                        else if (Status == 2)
                        {
                            lblWorkflowErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            */
        }

        protected void btnCloseWorkflowMast_Click(object sender, EventArgs e)
        {
            txtWorkflowDesc.Text = "";
            ddlCategory.SelectedValue = "0";
            ddlSubCategory.SelectedValue = "0";

            ddlSubCategory.Items.Clear();
            lblWorkflowErrorMsg.Text = "";
            //mpeWorkflowMaster.Hide();
            Session["WorkflowID"] = "";
            Response.Redirect(Page.ResolveClientUrl("~/Ticketing/Workflow_Master.aspx"), false);

        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
           int CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
            Fetch_CategorySubCategory(CategoryID);
        }

        public void BindWorkflowMaster(int WorkflowID)
        {
            try
            {
               // ds = ObjUpkeep.WorkflowMaster_CRUD(WorkflowID, "", 0, 0, LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["WorkflowID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Workflow_Id"]);
                        txtWorkflowDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["Workflow_Desc"]);
                        ddlCategory.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Category_ID"]);

                        Fetch_CategorySubCategory(Convert.ToInt32(ds.Tables[0].Rows[0]["Category_ID"]));

                        ddlSubCategory.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["SubCategory_ID"]);

                        //mpeWorkflowMaster.Show();
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

        public void DeleteWorkflowMaster(int DelWorkflowID)
        {
            try
            {
                  ds = ObjUpkeep.WorkflowMaster_CRUD(DelWorkflowID, "", 0, 0, 0, "", CompanyID, LoggedInUserID, "D");
                //ds = ObjUpkeep.WorkflowMaster_CRUD(DelWorkflowID, "", 0, 0, LoggedInUserID, "D");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["WorkflowID"] = "";
                        Response.Redirect(Page.ResolveClientUrl("~/Ticketing/Workflow_Master.aspx"), false);
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
    }
}