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

namespace Upkeep_v3.Manage_Account.Billing
{
    public partial class Invoices : System.Web.UI.Page
    {

        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        //DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        GridView dgGrid = new GridView();
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            if (!IsPostBack)
            {
                bindGrid_Invoices();
            }
        }

        public string bindGrid_Invoices()
        {
            string data = "";
            try
            {
                DataSet ds = new DataSet();

                ds = ObjUpkeep.Fetch_Invoices(CompanyID);


                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {

                            //int Invoice_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Invoice_ID"]);
                            string Invoice_No = Convert.ToString(ds.Tables[0].Rows[i]["Invoice_No"]);
                            string Invoice_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Invoice_Desc"]);
                            string Invoice_Amount = Convert.ToString(ds.Tables[0].Rows[i]["Invoice_Amount"]);

                            string Invoice_GST = Convert.ToString(ds.Tables[0].Rows[i]["Invoice_GST"]);
                            string Invoice_Total = Convert.ToString(ds.Tables[0].Rows[i]["Invoice_Total"]);
                            string Invoice_Date = Convert.ToString(ds.Tables[0].Rows[i]["Invoice_date"]);
                            string Status = Convert.ToString(ds.Tables[0].Rows[i]["Status"]);
                            string Nature_of_Invoice = Convert.ToString(ds.Tables[0].Rows[i]["Nature_of_Invoice"]);
                            string Due_date = Convert.ToString(ds.Tables[0].Rows[i]["Due_date"]);
                            string Invoice_File_Path = Convert.ToString(ds.Tables[0].Rows[i]["Invoice_File_Path"]);



                            //string Created_On = Created_Date.Substring(0, 10);
                            //DateTime dt;

                            //if (DateTime.TryParseExact(Created_On, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out dt))
                            //{
                            //    Created_On = dt.ToString("dd/MMM/yyyy");
                            //}

                            data += "<tr><td>" + Invoice_No + "</td><td>" + Invoice_Desc + "</td><td>" + Invoice_Amount + "</td><td>" + Invoice_GST + "</td><td>" + Invoice_Total + "</td><td>" + Invoice_Date + "</td><td>" + Status + "</td><td>" + Nature_of_Invoice + "</td><td>" + Due_date + "</td><td>   <a target='_blank' href='" + Invoice_File_Path + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='View Invoice'> <i class='la la-eye'></i> </a>     </td></tr>";
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