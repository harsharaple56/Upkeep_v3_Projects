﻿using System;
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

namespace Upkeep_Gatepass_Workpermit.WorkPermit
{
    public partial class WorkPermit_MIS : System.Web.UI.Page
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
                //LoggedInUserID="3";
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
            fetchWPRequestListing();
        }

        public string fetchWPRequestListing()
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
                    DateTime FrsmDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yy", CultureInfo.InvariantCulture)).AddDays(-5);
                    From_Date = FrsmDate.ToString("dd/MMM/yy", CultureInfo.InvariantCulture); 
                }

                if (end_date.Value != "")
                {
                    To_Date = Convert.ToString(end_date.Value);
                }
                else
                {
                    DateTime FromDate = DateTime.Parse(DateTime.Now.ToString("dd/MMM/yy", CultureInfo.InvariantCulture)).AddDays(25);
                    To_Date = FromDate.ToString("dd/MMM/yy", CultureInfo.InvariantCulture);
                }

                DataSet ds = new DataSet();
                ds = ObjUpkeep.Fetch_WorkPermit_MIS(LoggedInUserID, From_Date, To_Date);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            string SrNO = Convert.ToString(ds.Tables[0].Rows[i]["SrNo"]);
                            string TransactionID = Convert.ToString(ds.Tables[0].Rows[i]["WP_Trans_ID"]);
                            string TicketNo = Convert.ToString(ds.Tables[0].Rows[i]["TicketNo"]);
                            string WorkPermit_Title = Convert.ToString(ds.Tables[0].Rows[i]["WP_Title"]);
                            string Department = Convert.ToString(ds.Tables[0].Rows[i]["DepartmentName"]);
                            //string GP_Type = Convert.ToString(ds.Tables[0].Rows[i]["GP_Type_Desc"]);
                            string WorkPermitFromDate = Convert.ToString(ds.Tables[0].Rows[i]["WorkPermitFromDate"]);
                            string WorkPermitToDate = Convert.ToString(ds.Tables[0].Rows[i]["WorkPermitToDate"]);
                            string RequestDate = Convert.ToString(ds.Tables[0].Rows[i]["RequestDate"]);
                            string Status = Convert.ToString(ds.Tables[0].Rows[i]["WP_Status"]);
                            string Created_By = Convert.ToString(ds.Tables[0].Rows[i]["Created_By"]);

                            data += "<tr>" +
                                "<td> <a href='..\\WorkPermit\\WorkPermit_Request.aspx?TransactionID=" + TransactionID + "&MyAction=2' style='text-decoration: underline;' > " + TicketNo + " </a></td>" +
                                "<td>" + WorkPermit_Title + "</td>" +
                                "<td>" + Department + "</td>" +
                                "<td>" + WorkPermitFromDate + "</td>" +
                                "<td>" + WorkPermitToDate + "</td>" +
                                "<td>" + RequestDate + "</td>" +
                                "<td>" + Status + "</td>" +
                                "<td>" + Created_By + "</td>" +
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