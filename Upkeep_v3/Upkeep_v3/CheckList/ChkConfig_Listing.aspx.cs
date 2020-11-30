using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Data.OleDb;
using System.Data.Common;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace Upkeep_v3.CheckList
{
    public partial class ChkConfig_Listing : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            if (!IsPostBack)
            {
                Session["PreviousURL"] = HttpContext.Current.Request.Url.AbsoluteUri;
            }
        }


        public string fetchChkRequestListing()
        {
            string data = "";

            try
            {

                DataSet ds = new DataSet();

                if (LoggedInUserID == "")
                {
                    return "";
                }

                ds = ObjUpkeep.Fetch_MyChecklist(LoggedInUserID, Session["CompanyID"].ToString(), "", "");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            string SrNO = Convert.ToString(ds.Tables[0].Rows[i]["SrNo"]);
                            string Chk_Config_ID = Convert.ToString(ds.Tables[0].Rows[i]["Chk_Config_ID"]);
                            string Chk_Title = Convert.ToString(ds.Tables[0].Rows[i]["Chk_Title"]);
                            //string Chk_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Chk_Desc"]);
                            string Is_Enable_Score = Convert.ToString(ds.Tables[0].Rows[i]["Is_Enable_Score"]);
                            string Total_Score = Convert.ToString(ds.Tables[0].Rows[i]["Total_Score"]);
                            string Created_By = Convert.ToString(ds.Tables[0].Rows[i]["Created_By"]);
                            string Created_Date = Convert.ToString(ds.Tables[0].Rows[i]["Created_Date"]);
                            string Updated_By = Convert.ToString(ds.Tables[0].Rows[i]["Updated_By"]);
                            string Updated_date = Convert.ToString(ds.Tables[0].Rows[i]["Updated_date"]);

                            //data += "<tr><td> <a href='CheckList_Configuration.aspx?ChkConfigID=" + Chk_Config_ID + "' style='text-decoration: underline;' > " + Chk_Title + " </a></td>" +
                            //    "<td>" + Chk_Desc + "</td>" +
                            //    "<td>" + Is_Enable_Score + "</td>" +
                            //    "<td>" + Total_Score + "</td>" +
                            //    "<td>" + Created_By + "</td>" +
                            //    "<td>" + Created_Date + "</td>" +
                            //    "<td>" + Updated_By + "</td>" +
                            //    "<td>" + Updated_date + "</td>" + 
                            //    "</tr>";

                            data += "<tr>" +
                                "<td>" + Chk_Title + "</td>" +
                                //"<td>" + Chk_Desc + "</td>" +
                               // "<td>" + Is_Enable_Score + "</td>" +
                                "<td>" + Total_Score + "</td>" +
                                "<td>" + Created_By + "</td>" +
                                "<td>" + Created_Date + "</td>" +
                                "<td>" + Updated_By + "</td>" +
                                "<td>" + Updated_date + "</td>" +
                                "<td><a href='CheckList_Configuration.aspx?ChkConfigID=" + Chk_Config_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record'> <i class='la la-edit'></i> </a>  " +
                                "<a href='#' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation removeItem' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record' data-config-id='" + Chk_Config_ID + "'><i class='la la-trash'></i> </a> " +
                                "</tr>";


                        }
                    }
                    else
                    {
                        //invalid login
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
            return data;
        }
         
        public string DeleteChkRequestListing()
        { 
            if (hdnDeleteID.Value != "")
            {
               ObjUpkeep.Delete_CHKConfiguration(Convert.ToInt32(hdnDeleteID.Value.ToString()), LoggedInUserID);
            }
            hdnDeleteID.Value = "";

            return "";
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteChkRequestListing();
        }

        protected void lnkSampleFile_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "~/General_Masters/Template/Checklist_Import_Template.xlsx";

                //string filePath = "~/Feedback/Template/RetailerData.xls";
                //string filePath = Page.ResolveClientUrl("~/Feedback/Template/RetailerData.xls");

                //Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
                string filename = "Checklist_Import_Template.xlsx";
                Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");
                Response.TransmitFile(Server.MapPath(filePath));

                Response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnImportExcel_Click(object sender, EventArgs e)
        {
            DataSet dsResult = new DataSet();
            int CompanyID = 0;
            if (FU_ChecklistMst.PostedFile != null)
            {
                try
                {
                    CompanyID = Convert.ToInt32(Session["CompanyID"]);
                    string path = string.Concat(Server.MapPath("~/Checklist/ImportFile/" + FU_ChecklistMst.FileName));
                    FU_ChecklistMst.SaveAs(path);
                    // Connection String to Excel Workbook  
                  //string excelCS = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);
                    string excelCS = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties='Excel 12.0 Xml;HDR=YES'", path);

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
                        bulkInsert.DestinationTableName = "Tbl_CHK_Temp_Import";
                        bulkInsert.ColumnMappings.Add("Checklist_Name", "Checklist_Name");
                        bulkInsert.ColumnMappings.Add("Section_Name", "Section_Name");
                        bulkInsert.ColumnMappings.Add("Question_Desc", "Question_Desc");
                        bulkInsert.ColumnMappings.Add("Ans_Type", "Ans_Type");
                        //bulkInsert.ColumnMappings.Add(CompanyID.ToString(), "CompanyID");
                     
                        bulkInsert.WriteToServer(dr);

                        dsResult = ObjUpkeep.Import_Checklist_Master(CompanyID, LoggedInUserID);

                        if (dsResult.Tables.Count > 0)
                        {
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {

                                dvErrorGrid.Attributes.Add("style", "display:block; overflow-y:auto; height:210px;");
                                pnlImportExport.Attributes.Add("style", "height:580px; width:700px; top:-14px !important;");

                                mpeUserMst.Show();
                                lblImportErrorMsg.Text = "Below mentioned users can not be created, kindly check error message.";
                                gvImportError.DataSource = dsResult;
                                gvImportError.DataBind();
                            }
                            else
                            {
                                fetchChkRequestListing();
                            }
                        }
                        else
                        {
                            fetchChkRequestListing();
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
                //lbl
            }
        }

        protected void btnCloseImportPopUp_Click(object sender, EventArgs e)
        {
            lblImportErrorMsg.Text = "";
            gvImportError.DataSource = null;
            gvImportError.DataBind();
            mpeUserMst.Hide();
        }

       

    }

}