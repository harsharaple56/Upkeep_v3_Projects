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
                //bindGrid();
            }
        }

        public string bindGrid()
        {
            string data = "";
            try
            {
                DataSet ds = new DataSet();

                ds = objUpkeepCC.CompanyMaster_CRUD(0, "", "", 0, "", "", 0, "", "", "", "", "", "", "", "", "", "", "", 0, 0, 0, 0, LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Company_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Company_ID"]);
                            int GroupID = Convert.ToInt32(ds.Tables[0].Rows[i]["Group_ID"]);
                            string Company_Code = Convert.ToString(ds.Tables[0].Rows[i]["Company_Code"]);
                            string Company_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Company_Desc"]);
                            string Group_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Group_Desc"]);
                            string Created_Date = Convert.ToString(ds.Tables[0].Rows[i]["Created_Date"]);

                            string Company_EmailID = Convert.ToString(ds.Tables[0].Rows[i]["Company_EmailID"]);
                            string Company_MobileNo = Convert.ToString(ds.Tables[0].Rows[i]["Company_MobileNo"]);

                            string Created_On = Created_Date.Substring(0, 10);
                            DateTime dt;

                            if (DateTime.TryParseExact(Created_On, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out dt))
                            {
                                Created_On = dt.ToString("dd/MMM/yyyy");
                            }

                            data += "<tr><td>" + Company_Desc + "</td><td>" + Company_Code + "</td><td>" + Company_EmailID + "</td><td>" + Company_MobileNo + "</td><td>" + Group_Desc + "</td><td>" + Created_On + "</td><td>" + Created_On + "</td><td>" + Created_On + "</td><td>" + Created_On + "</td><td>" + Company_EmailID + "</td><td>" + Created_On + "</td><td><a href='Add_Company.aspx?CompanyID=" + Company_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record'> <i class='la la-edit'></i> </a>  <a href='Add_Company.aspx?DelCompanyID=" + Company_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";
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