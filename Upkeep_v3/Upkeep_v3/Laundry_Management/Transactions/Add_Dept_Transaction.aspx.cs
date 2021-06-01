using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Text;

namespace Upkeep_v3.Laundry_Management.Transactions
{
    public partial class Add_Dept_Transaction : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);

            if (!IsPostBack)
            {
                int Dept_Trans_ID = Convert.ToInt32(Request.QueryString["Dept_Trans_ID"]);
                bindDepartment();

                if (Dept_Trans_ID > 0)
                {
                    Session["Dept_Trans_ID"] = Convert.ToString(Dept_Trans_ID);

                    bind_Department_Transaction_Details(Dept_Trans_ID);
                }

            }
        }

        public void bindDepartment()
        {
            try
            {
                CompanyID = Convert.ToInt32(Session["CompanyID"]);
                DataSet ds = new DataSet();

                ds = ObjUpkeep.Fetch_Department(CompanyID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlDepartment.DataSource = ds.Tables[0];
                        ddlDepartment.DataTextField = "Department";
                        ddlDepartment.DataValueField = "Department_ID";
                        ddlDepartment.DataBind();
                        ddlDepartment.Items.Insert(0, new ListItem("--Select Department--", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvItemDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            //int DepartmentID = 27;
            //string ItemIDs = "3,4,5";

            //bindItemDetails(DepartmentID, ItemIDs);

        }

        protected void btnSaveTransaction_Click(object sender, EventArgs e)
        {
            string Dept_ExecutiveName = string.Empty;
            string Dept_ExecutiveContactNo = string.Empty;
            int DepartmentID = 0;
            string TransactionData = string.Empty;
            try
            {
                Dept_ExecutiveName = Convert.ToString(txtDept_ExecutiveName.Text.Trim());
                Dept_ExecutiveContactNo = Convert.ToString(txtDept_ExecutiveContactNo.Text.Trim());
                DepartmentID = Convert.ToInt32(ddlDepartment.SelectedValue);

                var rows = gvItemDetails.Rows;
                int count = gvItemDetails.Rows.Count;

                StringBuilder strXmlTransaction = new StringBuilder();
                strXmlTransaction.Append(@"<?xml version=""1.0"" ?>");
                strXmlTransaction.Append(@"<DeptTransRoot>");

                for (int i = 0; i < count; i++)
                {
                    
                    string hdnStock_ID = ((HiddenField)rows[i].FindControl("hdnStock_ID")).Value;
                    string hdnOpening_Stock = ((HiddenField)rows[i].FindControl("hdnOpening_Stock")).Value;

                    string txtSoiledCollected = ((TextBox)rows[i].FindControl("txtSoiledCollected")).Text;
                    string txtCleanedGiven = ((TextBox)rows[i].FindControl("txtCleanedGiven")).Text;
                    string txtDamaged = ((TextBox)rows[i].FindControl("txtDamaged")).Text;
                    string txtClosing = ((TextBox)rows[i].FindControl("txtClosing")).Text;

                    strXmlTransaction.Append(@"<Transaction>");
                    strXmlTransaction.Append(@"<Stock_ID>" + hdnStock_ID + "</Stock_ID>");
                    strXmlTransaction.Append(@"<Opening_Stock>" + hdnOpening_Stock + "</Opening_Stock>");
                    strXmlTransaction.Append(@"<SoiledCollected>" + txtSoiledCollected + "</SoiledCollected>");
                    strXmlTransaction.Append(@"<CleanedGiven>" + txtCleanedGiven + "</CleanedGiven>");
                    strXmlTransaction.Append(@"<Damaged>" + txtDamaged + "</Damaged>");
                    strXmlTransaction.Append(@"<Closing>" + txtClosing + "</Closing>");

                    strXmlTransaction.Append(@"</Transaction>");

                }

                strXmlTransaction.Append(@"</DeptTransRoot>");

                TransactionData = strXmlTransaction.ToString();

                DataSet dsTransactionSave = new DataSet();

                dsTransactionSave = ObjUpkeep.LMS_Save_Department_Transaction(Dept_ExecutiveName, Dept_ExecutiveContactNo, DepartmentID, TransactionData, CompanyID, LoggedInUserID);

                if (dsTransactionSave.Tables.Count > 0)
                {
                    if (dsTransactionSave.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsTransactionSave.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                              Response.Redirect(Page.ResolveClientUrl("~/Laundry_Management/Transactions/Department_Transactions.aspx"), false);
                        }
                        else if (Status == 3)
                        {
                            //lblErrorMsg.Text = "";
                        }
                        else if (Status == 2)
                        {
                            // lblErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DepartmentID = 0;
            try
            {
                DepartmentID = Convert.ToInt32(ddlDepartment.SelectedValue);
                bindItemList(DepartmentID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void bindItemList(int DepartmentID)
        {
            try
            {
                DataSet dsItems = new DataSet();

                dsItems = ObjUpkeep.Fetch_LMS_ItemList(DepartmentID, CompanyID);

                chkItems.Items.Clear();

                if (dsItems.Tables.Count > 0)
                {
                    if (dsItems.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow sdr in dsItems.Tables[0].Rows)
                        {
                            ListItem item = new ListItem();
                            item.Text = sdr["Item_Desc"].ToString();
                            item.Value = sdr["Item_ID"].ToString();

                            chkItems.Items.Add(item);
                        }

                        //ddlItems.DataSource = dsItems.Tables[0];
                        //ddlItems.DataTextField = "Item_Desc";
                        //ddlItems.DataValueField = "Item_ID";
                        //ddlItems.DataBind();
                        //ddlItems.Items.Insert(0, new ListItem("--Select Item--", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void bindItemDetails(int DepartmentID, string ItemIDs)
        {
            try
            {

                DataSet dsItems = new DataSet();

                dsItems = ObjUpkeep.Fetch_LMS_ItemDetails_Dept_Transaction(DepartmentID, CompanyID, ItemIDs);

                if (dsItems.Tables.Count > 0)
                {
                    if (dsItems.Tables[0].Rows.Count > 0)
                    {
                        gvItemDetails.DataSource = dsItems.Tables[0];
                        gvItemDetails.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnItemSelect_Click(object sender, EventArgs e)
        {
            int DepartmentID = 0;
            string ItemIDs = string.Empty; ;
            try
            {
                DepartmentID = Convert.ToInt32(ddlDepartment.SelectedValue);
                for (int i = 0; i < chkItems.Items.Count; i++)
                {
                    if (chkItems.Items[i].Selected == true)// getting selected value from CheckBox List  
                    {
                        ItemIDs += chkItems.Items[i].Value + ","; // add selected Item text to the String .  
                    }
                }

                bindItemDetails(DepartmentID, ItemIDs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void bind_Department_Transaction_Details(int Dept_TransID)
        {
            DataSet dsItems = new DataSet();
            try
            {
                dsItems = ObjUpkeep.Fetch_LMS_Dept_Transaction_Details(Dept_TransID);

                if (dsItems.Tables.Count > 0)
                {
                    if (dsItems.Tables[0].Rows.Count > 0)
                    {
                        txtDept_ExecutiveName.Text = Convert.ToString(dsItems.Tables[0].Rows[0]["Dept_Exec_Name"]);
                        txtDept_ExecutiveContactNo.Text = Convert.ToString(dsItems.Tables[0].Rows[0]["Dept_Exec_Contact"]);

                        ddlDepartment.SelectedValue = Convert.ToString(dsItems.Tables[0].Rows[0]["Dept_ID"]);
                        lblTransactionNo.Text = Convert.ToString(dsItems.Tables[0].Rows[0]["Dept_Trans_ID"]);
                        lblTransactionDate.Text = Convert.ToString(dsItems.Tables[0].Rows[0]["TransactionDate"]);
                        lblTransactionBy.Text = Convert.ToString(dsItems.Tables[0].Rows[0]["TransactionByUser"]);

                        dvTransDetails.Attributes.Add("style", "display:block;");
                        dvSave.Attributes.Add("style", "display:none;");
                    }
                    if (dsItems.Tables[1].Rows.Count > 0)
                    {
                        gvItemDetails.DataSource = dsItems.Tables[1];
                        gvItemDetails.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}