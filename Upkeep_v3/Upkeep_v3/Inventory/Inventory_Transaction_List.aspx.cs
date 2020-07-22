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
using System.Globalization;

namespace Upkeep_v3.Inventory
{
    public partial class Inventory_Transaction_List : System.Web.UI.Page
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

        public string fetchInvTransactionListing()
        {
            string data = "";

            try
            {

                DataSet ds = new DataSet();

                if (LoggedInUserID == "")
                {
                    return "";
                }

                ds = ObjUpkeep.Fetch_Transaction_List(LoggedInUserID, Session["CompanyID"].ToString());

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {

                            string Transac_Detail_ID = Convert.ToString(ds.Tables[0].Rows[i]["Transac_Detail_ID"]);
                            string Transac_ID = Convert.ToString(ds.Tables[0].Rows[i]["Transac_ID"]);
                            string Items = Convert.ToString(ds.Tables[0].Rows[i]["Items"]);
                            string Category = Convert.ToString(ds.Tables[0].Rows[i]["Category"]);
                            string Sub_Category = Convert.ToString(ds.Tables[0].Rows[i]["Sub_Category"]);
                            string Department = Convert.ToString(ds.Tables[0].Rows[i]["Department"]);


                            data += "<tr>" +
                                "<td>" + Transac_ID + "</td>" +
                                "<td>" + Items + "</td>" +
                                "<td>" + Category + "</td>" +
                                "<td>" + Sub_Category + "</td>" +
                                "<td>" + Department + "</td>" +
                                "<td><a href='CheckList_Configuration.aspx?TransDtlID=" + Transac_Detail_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record'> <i class='la la-edit'></i> </a>  " +
                                "<a href='#' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation removeItem' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record' data-config-id='" + Transac_Detail_ID + "'><i class='la la-trash'></i> </a> " +
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

        public string DeleteInvTransactionListing()
        {
            if (hdnDeleteID.Value != "")
            {
                ObjUpkeep.Delete_Inv_Transaction(Convert.ToInt32(hdnDeleteID.Value.ToString()), LoggedInUserID);
            }
            hdnDeleteID.Value = "";

            return "";
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteInvTransactionListing();
        }
    }
}