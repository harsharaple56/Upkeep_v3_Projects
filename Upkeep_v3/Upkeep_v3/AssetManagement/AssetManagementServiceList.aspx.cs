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
namespace Upkeep_Gatepass_Workpermit.AssetManagement
{
    public partial class AssetManagementServiceList : System.Web.UI.Page
    {

        Upkeep_GP_WP_Services.Upkeep_GP_WP_Services ObjUpkeep = new Upkeep_GP_WP_Services.Upkeep_GP_WP_Services();
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
               // LoggedInUserID = "3";
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
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {


                            //Schedule_ID Service_Date Assigned_To Alert_Date Remarks Asset_ID Asset_Name  Asset_Type
                            //Asset_Category  Vendor Department  Location Status Created_By Created_Date

                            string Schedule_ID = Convert.ToString(ds.Tables[0].Rows[i]["Schedule_ID"]);
                            string Service_Date = Convert.ToString(ds.Tables[0].Rows[i]["Service_Date"]);
                            string Assigned_To = Convert.ToString(ds.Tables[0].Rows[i]["Assigned_To"]);
                            string Alert_Date = Convert.ToString(ds.Tables[0].Rows[i]["Alert_Date"]);
                            string Remarks = Convert.ToString(ds.Tables[0].Rows[i]["Remarks"]);
                            string Asset_ID = Convert.ToString(ds.Tables[0].Rows[i]["Asset_ID"]);
                            string Asset_Name = Convert.ToString(ds.Tables[0].Rows[i]["Asset_Name"]);
                            string Asset_Type = Convert.ToString(ds.Tables[0].Rows[i]["Asset_Type"]);
                            string Asset_Category = Convert.ToString(ds.Tables[0].Rows[i]["Asset_Category"]);
                            string Vendor = Convert.ToString(ds.Tables[0].Rows[i]["Vendor"]);
                            string Department = Convert.ToString(ds.Tables[0].Rows[i]["Department"]);
                            string Location = Convert.ToString(ds.Tables[0].Rows[i]["Location"]);
                            string Status = Convert.ToString(ds.Tables[0].Rows[i]["Status"]); 
                            string Created_By = Convert.ToString(ds.Tables[0].Rows[i]["Created_By"]);
                            string Created_Date = Convert.ToString(ds.Tables[0].Rows[i]["Created_Date"]);
                             
                            data += "<tr><td> <a href='AssetManagementServiceRequest.aspx?TransactionID=" + Schedule_ID + "&AssetID=" + Asset_ID + "&ActionType=1' style='text-decoration: underline;' > " + Service_Date + " </a></td>" +
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