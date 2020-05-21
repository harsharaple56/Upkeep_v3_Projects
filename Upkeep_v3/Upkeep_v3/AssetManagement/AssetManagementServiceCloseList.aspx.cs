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
namespace Upkeep_v3.AssetManagement
{
    public partial class AssetManagementServiceCloseList : System.Web.UI.Page
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
                //LoggedInUserID = "3";
            }
            hdn_IsPostBack.Value = "yes";
            if (!IsPostBack)
            {
                hdn_IsPostBack.Value = "no";
                Session["PreviousURL"] = HttpContext.Current.Request.Url.AbsoluteUri;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            fetchListing();
        }

        public string fetchListing()
        {
            string data = "";
            string From_Date = string.Empty;
            string To_Date = string.Empty;

            try
            {
                if (start_date.Value != "")
                {
                    From_Date = Convert.ToString(start_date.Value);
                }
                else
                {
                    From_Date = DateTime.Now.ToString("dd/MMM/yy", CultureInfo.InvariantCulture);

                }

                if (end_date.Value != "")
                {
                    To_Date = Convert.ToString(end_date.Value);
                }
                else
                {
                    DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yy", CultureInfo.InvariantCulture)).AddDays(30);
                    To_Date = FromDate.ToString("dd/MMM/yy", CultureInfo.InvariantCulture);
                }

                DataSet ds = new DataSet();
                ds = ObjUpkeep.Fetch_MyAsset_Service(LoggedInUserID, From_Date, To_Date);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    

                        DataTable dtClose = new DataTable();
                        dtClose = ds.Tables[0].Copy();
                        dtClose.DefaultView.RowFilter = "Status = 'Open' AND Assigned_To ='" + LoggedInUserID + "' ";
                        dtClose = dtClose.DefaultView.ToTable();
                        int count = Convert.ToInt32(dtClose.Rows.Count);
                        for (int i = 0; i < count; i++)
                        {

                            //Schedule_ID Service_Date Assigned_To Alert_Date Remarks Asset_ID Asset_Name  Asset_Type
                            //Asset_Category  Vendor Department  Location Service_Status Created_By Created_Date

                            string Schedule_ID = Convert.ToString(dtClose.Rows[i]["Schedule_ID"]);
                            string Service_Date = Convert.ToString(dtClose.Rows[i]["Service_Date"]);
                            string Assigned_To = Convert.ToString(dtClose.Rows[i]["Assigned_To"]);
                            string Alert_Date = Convert.ToString(dtClose.Rows[i]["Alert_Date"]);
                            string Remarks = Convert.ToString(dtClose.Rows[i]["Remarks"]);
                            string Asset_ID = Convert.ToString(dtClose.Rows[i]["Asset_ID"]);
                            string Asset_Name = Convert.ToString(dtClose.Rows[i]["Asset_Name"]);
                            string Asset_Type = Convert.ToString(dtClose.Rows[i]["Asset_Type"]);
                            string Asset_Category = Convert.ToString(dtClose.Rows[i]["Asset_Category"]);
                            string Vendor = Convert.ToString(dtClose.Rows[i]["Vendor"]);
                            string Department = Convert.ToString(dtClose.Rows[i]["Department"]);
                            string Location = Convert.ToString(dtClose.Rows[i]["Location"]);
                            string Status = Convert.ToString(dtClose.Rows[i]["Status"]);
                            string Created_By = Convert.ToString(dtClose.Rows[i]["Created_By"]);
                            string Created_Date = Convert.ToString(dtClose.Rows[i]["Created_Date"]);

                            data += "<tr><td> <a href='AssetManagementServiceRequest.aspx?TransactionID=" + Schedule_ID + "&AssetID=" + Asset_ID + "&ActionType=2' style='text-decoration: underline;' > " + Service_Date + " </a></td>" +
                                "<td>" + Assigned_To + "</td>" +
                                "<td>" + Alert_Date + "</td>" +
                                "<td>" + Remarks + "</td>" +
                                "<td>" + Asset_Name + "</td>" +
                                "<td>" + Asset_Type + "</td>" +
                                "<td>" + Asset_Category + "</td>" +
                                "<td>" + Vendor + "</td>" +
                                "<td>" + Department + "</td>" +
                                "<td>" + Location + "</td>" +
                                "<td>" + Status + "</td>" +
                                "<td>" + Created_By + "</td>" +
                                "<td>" + Created_Date + "</td>" +
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
    }

}