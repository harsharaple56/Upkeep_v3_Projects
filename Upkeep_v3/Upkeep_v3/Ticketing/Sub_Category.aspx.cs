using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.Ticketing
{
    public partial class Sub_Category : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        int CompanyID = 0;   //Added by Sujata
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]); //Added by Sujata
            if (LoggedInUserID == "")
            {
                Response.Redirect("~/Login.aspx", false);
            }

            if (!IsPostBack)
            {
                bindSubCategorygrid();
                Fetch_CategorySubCategory(0);
                Fetch_Priority(0);

                int SubCategory_ID = Convert.ToInt32(Request.QueryString["SubCategory_ID"]);
                if (SubCategory_ID > 0)
                {
                    BindSubCategory(SubCategory_ID);
                }
                int DelSubCategory_ID = Convert.ToInt32(Request.QueryString["DelSubCategory_ID"]);
                if (DelSubCategory_ID > 0)
                {
                    DeleteSubCategory(DelSubCategory_ID);
                }
            }

        }


        public string bindSubCategorygrid()
        {
            string data = "";
            try
            {
                ds = ObjUpkeep.SubCategoryMaster_CRUD(CompanyID, 0, "", 0,0,0, LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int SubCategory_Id = Convert.ToInt32(ds.Tables[0].Rows[i]["SubCategory_Id"]);
                            string SubCategory_Desc = Convert.ToString(ds.Tables[0].Rows[i]["SubCategory_Desc"]);
                            string Category_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Category_Desc"]);
                            string Priority_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Priority_Desc"]);
                            
                            ////data += "<tr><td>" + Frquency_Id + "</td><td>" + Frquency_Desc + "</td><td><a href='General_Masters/Add_Frequency.aspx?Frquency_Id=" + Frquency_Id + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  <a href='General_Masters/Add_Frequency.aspx?DelFreq_ID=" + Frquency_Id + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";
                            data += "<tr><td>" + SubCategory_Id + "</td><td>" + SubCategory_Desc + "</td><td>" + Priority_Desc + "</td><td>" + Category_Desc + "</td><td><a href='Sub_Category.aspx?SubCategory_Id=" + SubCategory_Id + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  <a href='Sub_Category.aspx?DelSubCategory_Id=" + SubCategory_Id + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

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


        protected void btnAddSubCategory_Click(object sender, EventArgs e)
        {

        }

        protected void btnCloseSubCategory_Click(object sender, EventArgs e)
        {
            txtSubCategoryDesc.Text = "";
            ddlCategory.SelectedValue = "0";
           
            ddlCategory.Items.Clear();
            lblSubCategoryErrorMsg.Text = "";
            mpeSubCategory.Hide();
            Session["SubCategory_ID"] = "";
           Response.Redirect(Page.ResolveClientUrl("~/Ticketing/Sub_Category.aspx"), false);
        }

        protected void btnSubCategorySave_Click(object sender, EventArgs e)
        {
            int SubCategory_ID = 0;
            int CategoryID = 0;
            int PriorityID = 0;


            try
            {
                if (Convert.ToString(Session["SubCategory_ID"]) != "")
                {
                    SubCategory_ID = Convert.ToInt32(Session["SubCategory_ID"]);
                }
                string Action = "";

                if (SubCategory_ID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);

                PriorityID = Convert.ToInt32(ddlPriority.SelectedValue);

                int Approval_Required = 0;

                if (chk_Approval.Checked == true)
                {
                    Approval_Required = 1;

                }
                else
                {
                    Approval_Required = 0;

                }


                ds = ObjUpkeep.SubCategoryMaster_CRUD(CompanyID,SubCategory_ID, txtSubCategoryDesc.Text.Trim(), CategoryID, PriorityID, Approval_Required, LoggedInUserID, Action);

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
                            Session["SubCategory_ID"] = "";
                            txtSubCategoryDesc.Text = "";
                            mpeSubCategory.Hide();
                           
                            Response.Redirect(Page.ResolveClientUrl("~/Ticketing/Sub_Category.aspx"), false);
                        }
                        else if (Status == 3)
                        {
                            lblSubCategoryErrorMsg.Text = "SubCategory already exists";
                        }
                        else if (Status == 2)
                        {
                            lblSubCategoryErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }


        public void Fetch_CategorySubCategory(int CategoryID)
        {
            DataSet dsCat = new DataSet();
            try
            {
                dsCat = ObjUpkeep.Fetch_CategorySubCategory(CategoryID, CompanyID);

                if (CategoryID == 0)
                {
                    ddlCategory.DataSource = dsCat.Tables[0];
                    ddlCategory.DataTextField = "Category_Desc";
                    ddlCategory.DataValueField = "Category_ID";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                }
             

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Fetch_Priority(int Priority_ID)
        {
            DataSet dsCat = new DataSet();
            try
            {
                dsCat = ObjUpkeep.PriorityMaster_CRUD(0, "", CompanyID, LoggedInUserID, "R"); ;
                
                    ddlPriority.DataSource = dsCat.Tables[0];
                    ddlPriority.DataTextField = "Priority_Desc";
                    ddlPriority.DataValueField = "Priority_ID";
                    ddlPriority.DataBind();
                    ddlPriority.Items.Insert(0, new ListItem("--Select--", "0"));


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void BindSubCategory(int SubCategory_ID)
        {
            try
            {
                ds = ObjUpkeep.SubCategoryMaster_CRUD(CompanyID,SubCategory_ID, "", 0,0,0, LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["SubCategory_ID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["SubCategory_ID"]);
                        txtSubCategoryDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["SubCategory_Desc"]);
                        ddlCategory.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Category_ID"]);
                        
                        Fetch_CategorySubCategory(Convert.ToInt32(ds.Tables[0].Rows[0]["Category_ID"]));

                        ddlPriority.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Priority_ID"]);

                        //Fetch_Priority(Convert.ToInt32(ds.Tables[0].Rows[0]["Priority_ID"]));

                        mpeSubCategory.Show();
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


        public void DeleteSubCategory(int DelSubCategory_ID)
        {
            try
            {
                ds = ObjUpkeep.SubCategoryMaster_CRUD(CompanyID,DelSubCategory_ID, "", 0,0,0, LoggedInUserID, "D");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["SubCategory_ID"] = "";
                        Response.Redirect(Page.ResolveClientUrl("~/Ticketing/Sub_Category.aspx"), false);
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

        

        protected void chk_Approval_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void chk_Approval_Required_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}