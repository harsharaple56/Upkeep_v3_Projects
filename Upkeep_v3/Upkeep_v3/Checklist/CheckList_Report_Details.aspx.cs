using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Text;
using System.Web.UI.HtmlControls;
//using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Upkeep_v3.CheckList
{
    public partial class CheckList_Report_Details : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        DataSet dsGlobalDataS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {

            string Trans_Ans_Response_ID = "";
            if (Request.QueryString["Ans_Response_ID"] != null)
            {
                Trans_Ans_Response_ID = Convert.ToString(Request.QueryString["Ans_Response_ID"]);
                Session["Ans_Response_ID"] = Trans_Ans_Response_ID;
            }

            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);

                //Session["PreviousURL"] = "";
                //LoggedInUserID = "1"; 
            }


            if (!IsPostBack)
            {
                if (System.Web.HttpContext.Current.Session["PreviousURL"] == null)
                {
                    Session["PreviousURL"] = "~/CheckList/CheckList_Report_Details.aspx";
                }
                else
                {
                    Session["PreviousURL"] = "";
                }

                //if (Trans_Ans_Response_ID != "")
                //{
                    FetchAndBindData(Trans_Ans_Response_ID);
                //}
            }

        }


        public void FetchAndBindData(string Trans_Ans_Response_ID)
        {
            DataSet ds = new DataSet();

            ds = ObjUpkeep.Fetch_Checklist_Report(Trans_Ans_Response_ID, Convert.ToString(Session["LoggedInUserID"]));

            dsGlobalDataS.Clear();
            dsGlobalDataS = ds.Copy();


            if (ds.Tables[0].Rows.Count > 0)
            { 
                lblChecklisID.Text = ds.Tables[0].Rows[0]["Chk_Response_No"].ToString();
                lblChecklistName.Text = ds.Tables[0].Rows[0]["Checklist Name"].ToString();
                lblChecklistDesc.Text = ds.Tables[0].Rows[0]["Checklist Desc"].ToString();

                lblDepartment.Text = ds.Tables[0].Rows[0]["Department"].ToString();
                lblLocation.Text = ds.Tables[0].Rows[0]["Location"].ToString();
                lblstartTime.Text = ds.Tables[0].Rows[0]["Start Time"].ToString();
                lblEndTime.Text = ds.Tables[0].Rows[0]["End Time"].ToString();
                lblTotalScore.Text = ds.Tables[0].Rows[0]["Total Hrs"].ToString();
                lblGeneratedBy.Text = ds.Tables[0].Rows[0]["Generated_By"].ToString();
                lblStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();
            }


            if (ds.Tables[1].Rows.Count > 0)
            {
                rptSectionDetails.DataSource = ds.Tables[1];
                rptSectionDetails.DataBind();
            }
        }

        protected void rptSectionDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Reference the Repeater Item.
                RepeaterItem item = e.Item;
                 
                Label SectionName = e.Item.FindControl("lblSectionName") as Label;

                string hdnSectionID = (e.Item.FindControl("hdnSectionID") as HiddenField).Value;

                Repeater tblGrid = e.Item.FindControl("grdTable") as Repeater;

                DataSet dsWorkPermitHeader = new DataSet();
                dsWorkPermitHeader = dsGlobalDataS.Copy(); // ObjUpkeep.Bind_WorkPermitConfiguration(sPublicConfigId);

                DataTable dt = new DataTable();
                dt = dsWorkPermitHeader.Tables[2].Copy();
                dt.DefaultView.RowFilter = "Chk_Section_ID  = " + Convert.ToString(hdnSectionID) + "";
                dt = dt.DefaultView.ToTable();
                 

                if (dt.Rows.Count > 0)
                {
                    tblGrid.DataSource = dt;
                    tblGrid.DataBind();
                }
                else
                {
                    DataTable dt1 = new DataTable();
                    tblGrid.DataSource = dt1;
                    tblGrid.DataBind();

                }
            }
        }

    }

}