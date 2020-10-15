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

namespace Upkeep_v3.GatePass
{
    public partial class GatePassConfig_Listing : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }

            if (!string.IsNullOrEmpty(Convert.ToString(Session["GPConfig_Not_Delete"])))
            {
                if (Convert.ToString(Session["GPConfig_Not_Delete"]) == "1")
                {
                    lblErrorMsg.Text = "Can not delete this configuration bacause it has transaction";
                    Session["GPConfig_Not_Delete"] = "";
                   // Response.Write("<script>alert('Can not delete this configuration bacause it has transaction');</script>");
                }
            }
        }

        public string fetchGPConfigListing()
        {
            string data = "";
            string strInitiator = string.Empty;
            try
            {
                strInitiator = Convert.ToString(Session["UserType"]);
                DataSet ds = new DataSet();
                ds = ObjUpkeep.Fetch_GatePassConfiguration("", CompanyID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int ConfigID = Convert.ToInt32(ds.Tables[0].Rows[i]["Gp_Config_ID"]);
                            string GatePass_Title = Convert.ToString(ds.Tables[0].Rows[i]["GP_Title"]);
                            string Company = Convert.ToString(ds.Tables[0].Rows[i]["Company"]);
                            string Initiator = Convert.ToString(ds.Tables[0].Rows[i]["Initiator"]);
                            string CreatedOn = Convert.ToString(ds.Tables[0].Rows[i]["Created_Date"]);
                           
                            data += "<tr><td>" + GatePass_Title + "</td><td>" + Company + "</td><td>" + Initiator + "</td><td>" + CreatedOn + "</td><td><a href='EditGP_Configuration.aspx?GPConfigID=" + ConfigID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record'> <i class='la la-edit'></i> </a>  <a href='EditGP_Configuration.aspx?DelGPConfigID=" + ConfigID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

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