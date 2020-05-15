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

namespace Upkeep_v3_Control_Center
{
    public partial class Licence_Management : System.Web.UI.Page
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

                ds = objUpkeepCC.License_CRUD(0, "", 0, 0, "", "", "", 0, "", LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int License_Id = Convert.ToInt32(ds.Tables[0].Rows[i]["License_Id"]);
                            string Client_ID = Convert.ToString(ds.Tables[0].Rows[i]["Client_Id"]);
                            string Company_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Company_Desc"]);
                            string Subs_Pack_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Subs_Pack_Desc"]);
                            string Activation_Date = Convert.ToString(ds.Tables[0].Rows[i]["Activation_Date"]);
                            string Expiry_Date = Convert.ToString(ds.Tables[0].Rows[i]["Expiry_Date"]);
                            string Due_Date = Convert.ToString(ds.Tables[0].Rows[i]["Due_Date"]);
                            string Modules = Convert.ToString(ds.Tables[0].Rows[i]["Modules"]);
                            string User_Limit_No = Convert.ToString(ds.Tables[0].Rows[i]["User_Limit_No"]);
                            string Status = Convert.ToString(ds.Tables[0].Rows[i]["Status"]);
                            string Created_Date = Convert.ToString(ds.Tables[0].Rows[i]["Created_Date"]);

                            string Activation_Dt = Activation_Date.Substring(0, 10);
                            DateTime Activationdt;

                            if (DateTime.TryParseExact(Activation_Dt, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out Activationdt))
                            {
                                Activation_Dt = Activationdt.ToString("dd/MMM/yyyy");
                            }

                            string Expiry_Dt = Expiry_Date.Substring(0, 10);
                            DateTime Expirydt;

                            if (DateTime.TryParseExact(Expiry_Dt, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out Expirydt))
                            {
                                Expiry_Dt = Expirydt.ToString("dd/MMM/yyyy");
                            }

                            string Due_Dt = Due_Date.Substring(0, 10);
                            DateTime DueDt;

                            if (DateTime.TryParseExact(Due_Dt, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out DueDt))
                            {
                                Due_Dt = DueDt.ToString("dd/MMM/yyyy");
                            }

                            string Created_On = Created_Date.Substring(0, 10);
                            DateTime dt;

                            if (DateTime.TryParseExact(Created_On, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out dt))
                            {
                                Created_On = dt.ToString("dd/MMM/yyyy");
                            }

                            data += "<tr><td>" + Client_ID + "</td><td>" + Company_Desc + "</td><td>" + Subs_Pack_Desc + "</td><td>" + Activation_Dt + "</td><td>" + Expiry_Dt + "</td><td>" + Due_Dt + "</td><td>" + Modules + "</td><td>" + User_Limit_No + "</td><td>" + Status + "</td><td>" + Created_On + "</td><td><a href='Add_License.aspx?LicenseID=" + License_Id + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record'> <i class='la la-edit'></i> </a>  <a href='Add_License.aspx?DelLicense_Id=" + License_Id + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";
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