using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace Upkeep_v3.General_Masters
{
    public partial class Department_Master : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeepCC = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            // bindgrid();
            //frmMain.Action = @"Department_Master.aspx";

            if (!IsPostBack)
            {
                //int DepartmentID = Convert.ToInt32(Request.QueryString["Department_ID"]);

                //if(DepartmentID>0)
                //{
                //    fetchDepartment(DepartmentID);
                //}

            }

        }

        public string bindgrid()
        {
            string data = "";
            try
            {
                ds = ObjUpkeepCC.DepartmentMaster_CRUD(0, "", CompanyID, LoggedInUserID, "0", "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Department_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Department_ID"]);
                            string Dept_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Dept_Desc"]);

                            data += "<tr><td>" + Department_ID + "</td><td>" + Dept_Desc + "</td><td><a href='Add_Department.aspx?Department_ID=" + Department_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  <a href='Add_Department.aspx?DelDept_ID=" + Department_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

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

        protected void btnDepartmentSave_Click(object sender, EventArgs e)
        {
            //if (btnDepartmentSave.Text == "")
            //{
            //    Response.Write("Select Dep");
            //}
            //else
            //{
            try
            {
                int Department_ID = Convert.ToInt32(Session["Department_ID"]);
                string Action = "";

                if (Department_ID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                ds = ObjUpkeepCC.DepartmentMaster_CRUD(Department_ID, txtDeptDesc.Text.Trim(), CompanyID, LoggedInUserID, "0", Action);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            //}
        }



        public void fetchDepartment(int DepartmentID)
        {
            try
            {
                ds = ObjUpkeepCC.DepartmentMaster_CRUD(DepartmentID, "", CompanyID, LoggedInUserID, "0", "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        int Department_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["Department_ID"]);
                        txtDeptDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["Dept_Desc"]);
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

        protected void btnImportExcel_Click(object sender, EventArgs e)
        {
            DataSet dsResult = new DataSet();

            if (FU_Department.HasFile && FU_Department.PostedFile != null)
            {
                try
                {
                    string path = string.Concat(Server.MapPath("~/Checklist/ImportFile/" + FU_Department.FileName));
                    string extension = Path.GetExtension(FU_Department.PostedFile.FileName);
                    FU_Department.SaveAs(path);

                    // Connection String to Excel Workbook  
                    string conString = string.Empty;
                    switch (extension)
                    {
                        case ".xls": //For Excel 97-03.  
                            conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                            break;
                        case ".xlsx": //For Excel 07 and above.  
                            conString = ConfigurationManager.ConnectionStrings["Excel07+ConString"].ConnectionString;
                            break;
                    }
                    string excelCS = string.Format(conString, path);

                    using (OleDbConnection con = new OleDbConnection(excelCS))
                    {
                        OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", con);
                        con.Open();
                        // Create DbDataReader to Data Worksheet  
                        DbDataReader dr = cmd.ExecuteReader();
                        // SQL Server Connection String  
                        string CS = ConfigurationManager.ConnectionStrings["Upkeep_ConString"].ConnectionString;
                        // Bulk Copy to SQL Server   
                        SqlBulkCopy bulkInsert = new SqlBulkCopy(CS);
                        bulkInsert.DestinationTableName = "Tbl_Department_Temp_Import";
                        bulkInsert.ColumnMappings.Add("Department", "Department_Desc");
                        bulkInsert.WriteToServer(dr);

                        dsResult = ObjUpkeepCC.Import_DepartmentList_Master(CompanyID, LoggedInUserID);

                        if (dsResult.Tables.Count > 0)
                        {
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                DataTable dtCTTReport = new DataTable();
                                dtCTTReport = dsResult.Tables[0];
                                dtCTTReport.Columns["Department_Desc"].ColumnName = "Department";
                                dtCTTReport.AcceptChanges();

                                dvErrorGrid.Attributes.Add("style", "display:block; overflow-y:auto; height:210px;");
                                pnlImportExport.Attributes.Add("style", "height:580px; width:700px; top:-14px !important;");

                                mpeUserMst.Show();
                                lblImportErrorMsg.Text = "Below Asset List can not be created, kindly check error message.";
                                gvImportError.DataSource = dtCTTReport;
                                gvImportError.DataBind();
                            }
                            else
                            {
                                bindgrid();
                            }
                        }
                        else
                        {
                            bindgrid();
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
            }
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
                string filePath = "~/General_Masters/Template/Department.xlsx";
                string filename = "Department.xlsx";
                Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");
                Response.TransmitFile(Server.MapPath(filePath));
                Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAddDepartment_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/General_Masters/Add_Department.aspx"), false);
        }
    }
}