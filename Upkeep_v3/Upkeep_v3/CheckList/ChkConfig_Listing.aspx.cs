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
namespace Upkeep_v3.Checklist
{
    public partial class ChkConfig_Listing : System.Web.UI.Page
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
                ds = ObjUpkeep.Fetch_MyChecklist(LoggedInUserID, From_Date, To_Date);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            string SrNO = Convert.ToString(ds.Tables[0].Rows[i]["SrNo"]);
                            string Chk_Config_ID = Convert.ToString(ds.Tables[0].Rows[i]["Chk_Config_ID"]);
                            string Chk_Title = Convert.ToString(ds.Tables[0].Rows[i]["Chk_Title"]);
                            string Chk_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Chk_Desc"]);
                            string Is_Enable_Score = Convert.ToString(ds.Tables[0].Rows[i]["Is_Enable_Score"]);
                            string Total_Score = Convert.ToString(ds.Tables[0].Rows[i]["Total_Score"]);
                            string Created_By = Convert.ToString(ds.Tables[0].Rows[i]["Created_By"]);
                            string Created_Date = Convert.ToString(ds.Tables[0].Rows[i]["Created_Date"]);
                            string Updated_By = Convert.ToString(ds.Tables[0].Rows[i]["Updated_By"]);
                            string Updated_date = Convert.ToString(ds.Tables[0].Rows[i]["Updated_date"]);

                            data += "<tr><td> <a href='CheckList_Configuration.aspx?ChkConfigID=" + Chk_Config_ID + "' style='text-decoration: underline;' > " + Chk_Title + " </a></td>" +
                                "<td>" + Chk_Desc + "</td>" +
                                "<td>" + Is_Enable_Score + "</td>" +
                                "<td>" + Total_Score + "</td>" +
                                "<td>" + Created_By + "</td>" +
                                "<td>" + Created_Date + "</td>" +
                                "<td>" + Updated_By + "</td>" +
                                "<td>" + Updated_date + "</td>" + 
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