using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Text;
using System.IO;

namespace Upkeep_v3.General_Masters
{
    public partial class Location_QRCode : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }

            if (!IsPostBack)
            {
                Bind_Locations();
            }
        }

        public void Bind_Locations()
        {
            DataSet dsLocation = new DataSet();
            try
            {
                dsLocation = ObjUpkeep.Fetch_LocationTree(CompanyID);

                if (dsLocation.Tables.Count > 0)
                {
                    if (dsLocation.Tables[0].Rows.Count > 0)
                    {
                        gvLocation_QRCode.DataSource = dsLocation.Tables[0];
                        gvLocation_QRCode.DataBind();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvLocation_QRCode_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //check if the row is the header row
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //add the thead and tbody section programatically
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void btnGenerateQRCode_Click(object sender, EventArgs e)
        {

        }

        protected void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chckheader = (CheckBox)gvLocation_QRCode.HeaderRow.FindControl("checkAll");

            foreach (GridViewRow row in gvLocation_QRCode.Rows)
            {

                CheckBox chckrw = (CheckBox)row.FindControl("ChkIndividual");

                if (chckheader.Checked == true)

                {
                    chckrw.Checked = true;
                }
                else

                {
                    chckrw.Checked = false;
                }

            }
        }
    }
}