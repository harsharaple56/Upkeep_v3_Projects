using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Globalization;
using System.IO;

namespace Upkeep_Gatepass_Workpermit.Feedback
{
    public partial class Customers : System.Web.UI.Page
    {
        Upkeep_GP_WP_Services.Upkeep_GP_WP_Services ObjUpkeepFeedback = new Upkeep_GP_WP_Services.Upkeep_GP_WP_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        GridView dgGrid = new GridView();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            //Customer_form.Action = @"Customers.aspx";
            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                //Response.Redirect("~/Login.aspx", false);
            }
        }

        public string bindCustomers()
        {
            string data = "";
            try
            {

                DataSet ds = new DataSet();
                ds = ObjUpkeepFeedback.Get_CustomerDetails();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int UserID = Convert.ToInt32(ds.Tables[0].Rows[i]["User_ID"]);
                            string CustomerName = Convert.ToString(ds.Tables[0].Rows[i]["Name"]);
                            string Gender = Convert.ToString(ds.Tables[0].Rows[i]["Gender"]);
                            string MobileNo = Convert.ToString(ds.Tables[0].Rows[i]["MobileNo"]);
                            string EmailID = Convert.ToString(ds.Tables[0].Rows[i]["EmailID"]);
                            string CreatedOn = Convert.ToString(ds.Tables[0].Rows[i]["Created_Date"]);
                            string ImagePath = Convert.ToString(ds.Tables[0].Rows[i]["ImagePath"]);


                            data += "<tr><td>" + CustomerName + "</td><td>" + Gender + "</td><td>" + EmailID + "</td><td>" + MobileNo + "</td><td>" + CreatedOn + "</td><td><button type='button' data-toggle='modal' data-target='#photo_modal' data-src='" + ImagePath + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='View Photo'><i class='la la-image'></i></button></td></tr>";
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
        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        public void ExportToExcel()
        {

            DataSet dsCustomer = new DataSet();
            dsCustomer = ObjUpkeepFeedback.Get_CustomerDetails();

            System.Data.DataTable dtCustomer = new System.Data.DataTable();
            dtCustomer = dsCustomer.Tables[0];

            if (dsCustomer != null)
            {
                if (dsCustomer.Tables.Count > 0)
                {
                    if (dsCustomer.Tables[0].Rows.Count > 0)
                    {
                        dtCustomer.Columns.Remove("User_ID");
                        dtCustomer.Columns.Remove("ImagePath");
                        //dtCustomer.Columns.Remove("User_ID");
                        dtCustomer.AcceptChanges();

                        System.IO.StringWriter tw = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                        string filename = "Feedback_Customer_" + DateTime.Now + ".xls";


                        //btnExportToExcel.Visible = true;
                        //dgGrid.DataSource = dsMisReport.Tables[0];
                        dgGrid.DataSource = dtCustomer;
                        dgGrid.DataBind();
                        //Get the HTML for the control.
                        dgGrid.RenderControl(hw);


                        //Write the HTML back to the browser.

                        Response.ContentType = "application/vnd.ms-excel";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                        this.EnableViewState = false;
                        Response.Write(tw.ToString());
                        Response.End();
                        return;
                    }
                }
            }
            else
            {
                //lblError.Visible = true;
                //lblError.Text = "No Data Found";

                dgGrid.DataSource = null;
                dgGrid.DataBind();

                return;
            }
        }


    }
}