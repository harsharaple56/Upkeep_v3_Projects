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
    public partial class AssetManagementList : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
           // LoggedInUserID = "3";
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
               //
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
                    From_Date = DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);

                }

                if (end_date.Value != "")
                {
                    To_Date = Convert.ToString(end_date.Value);
                }
                else
                {
                    DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture)).AddDays(30);
                    To_Date = FromDate.ToString("dd/MMM/yyyy", CultureInfo.InvariantCulture);
                }

                DataSet ds = new DataSet();
                ds = ObjUpkeep.Fetch_MyAsset(LoggedInUserID, From_Date, To_Date);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            string Asset_ID = Convert.ToString(ds.Tables[0].Rows[i]["Asset_ID"]);
                            string Asset_Name = Convert.ToString(ds.Tables[0].Rows[i]["Asset_Name"]);
                            //string Asset_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Asset_Desc"]);
                            //string Asset_Make = Convert.ToString(ds.Tables[0].Rows[i]["Asset_Make"]);
                            string Asset_Serial_No = Convert.ToString(ds.Tables[0].Rows[i]["Asset_Serial_No"]);
                            string Asset_Type = Convert.ToString(ds.Tables[0].Rows[i]["Asset_Type"]);
                            string Asset_Category = Convert.ToString(ds.Tables[0].Rows[i]["Asset_Category"]);
                            string Vendor = Convert.ToString(ds.Tables[0].Rows[i]["Vendor"]);
                            string Department = Convert.ToString(ds.Tables[0].Rows[i]["Department"]);
                            string Location = Convert.ToString(ds.Tables[0].Rows[i]["Location"]);

                            //string Asset_Cost = Convert.ToString(ds.Tables[0].Rows[i]["Asset_Cost"]);
                            //string Currency_Type = Convert.ToString(ds.Tables[0].Rows[i]["Currency_Type"]);
                            //string Asset_Purchase_Date = Convert.ToString(ds.Tables[0].Rows[i]["Asset_Purchase_Date"]);
                            //string Asset_Is_AMC_Active = Convert.ToString(ds.Tables[0].Rows[i]["Asset_Is_AMC_Active"]);
                            //string Created_By = Convert.ToString(ds.Tables[0].Rows[i]["Created_By"]);
                            //string Created_Date = Convert.ToString(ds.Tables[0].Rows[i]["Created_Date"]);
                            string AMC_Status = Convert.ToString(ds.Tables[0].Rows[i]["AMC_Status"]);
                            

                            //Asset_ID Asset_Name  Asset_Desc Asset_Make  Asset_Serial_No Asset_Type  Asset_Category Vendor  Department Location    
                            //    Asset_Cost Currency_Type   Asset_Purchase_Date Asset_Is_AMC_Active Created_By Created_Date

                            data += "<tr><td> <a href='AssetManagementRequest.aspx?TransactionID=" + Asset_ID + "' style='text-decoration: underline;' > " + Asset_Name + " </a></td>" +
                                //"<td>" + Asset_Desc + "</td>" + 
                                //"<td>" + Asset_Make + "</td>" +
                                "<td>" + Asset_Serial_No + "</td>" +
                                "<td>" + Asset_Type + "</td>" +
                                "<td>" + Asset_Category + "</td>" +
                                "<td>" + Vendor + "</td>" +
                                "<td>" + Department + "</td>" +
                                "<td>" + Location + "</td>" +
                                //"<td>" + Asset_Cost + "</td>" +
                                //"<td>" + Currency_Type + "</td>" +
                                //"<td>" + Asset_Purchase_Date + "</td>" +
                                //"<td>" + Asset_Is_AMC_Active + "</td>" +
                                //"<td>" + Created_By + "</td>" +
                                //"<td>" + Created_Date + "</td>" +
                                "<td>" + AMC_Status + "</td>" +
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