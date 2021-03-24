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
using System.Globalization;

namespace Upkeep_v3_Control_Center.Invoices
{
    public partial class Invoices_Listing : System.Web.UI.Page
    {

        UpkeepControlCenter_Service.UpkeepControlCenter_Service objUpkeepCC = new UpkeepControlCenter_Service.UpkeepControlCenter_Service();
        string LoggedInUserID = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            if (!IsPostBack)
            {
                //bindGrid_Invoices();
            }
        }

        public string bindGrid_Invoices()
        {
            string data = "";
            try
            {
                DataSet ds = new DataSet();

                ds = objUpkeepCC.Invoices_CRUD(0,"","", "", "", "", "", "", "", 0,"", "", "", "", "", "", "", "", "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {

                            int Invoice_ID= Convert.ToInt32(ds.Tables[0].Rows[i]["Invoice_ID"]);
                            string Invoice_No = Convert.ToString(ds.Tables[0].Rows[i]["Invoice_No"]);
                            string Invoice_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Invoice_Desc"]);
                            string Invoice_Amount = Convert.ToString(ds.Tables[0].Rows[i]["Invoice_Amount"]);

                            string Invoice_GST = Convert.ToString(ds.Tables[0].Rows[i]["Invoice_GST"]);
                            string GST_Type = Convert.ToString(ds.Tables[0].Rows[i]["GST_Type"]);
                            string Invoice_Total= Convert.ToString(ds.Tables[0].Rows[i]["Invoice_Total"]);

                            string Invoice_Date = Convert.ToString(ds.Tables[0].Rows[i]["Invoice_date"]);
                            string Status = Convert.ToString(ds.Tables[0].Rows[i]["Status"]);
                            string Company_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Company_Desc"]);
                            //int Company_ID=Convert.ToInt32(ds.Tables[0].Rows[i]["Invoice_No"]);

                            string Nature_of_Invoice = Convert.ToString(ds.Tables[0].Rows[i]["Nature_of_Invoice"]);
                            string Billing_Name = Convert.ToString(ds.Tables[0].Rows[i]["Billing_Name"]);
                            string Due_date = Convert.ToString(ds.Tables[0].Rows[i]["Due_date"]);
                            string GSTIN = Convert.ToString(ds.Tables[0].Rows[i]["GSTIN"]);
                            string Invoice_File_Path = Convert.ToString(ds.Tables[0].Rows[i]["Invoice_File_Path"]);



                            //string Created_On = Created_Date.Substring(0, 10);
                            //DateTime dt;

                            //if (DateTime.TryParseExact(Created_On, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out dt))
                            //{
                            //    Created_On = dt.ToString("dd/MMM/yyyy");
                            //}

                            data += "<tr><td>" + Company_Desc + "</td><td>" + Invoice_No + "</td><td>" + Invoice_Date + "</td><td>" + Invoice_Amount + "</td><td>" + Invoice_GST + "</td><td>" + GST_Type + "</td><td>" + Invoice_Total + "</td><td>" + Status + "</td><td>" + Nature_of_Invoice + "</td><td>" + Billing_Name + "</td><td>" + GSTIN + "</td><td>" + Due_date + "</td><td><a href='Add_Invoices.aspx?Invoice_ID_Update=" + Invoice_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record'> <i class='la la-edit'></i> </a>   <a target='_blank' href='" + Invoice_File_Path + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='View Invoice'> <i class='la la-eye'></i> </a>    <a href='Add_Invoices.aspx?Invoice_ID_Delete=" + Invoice_ID +"' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record' > 	<i class='la la-trash'></i> </a> </td></tr>";
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

    }
}