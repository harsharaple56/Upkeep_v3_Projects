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

namespace Upkeep_v3.CheckList
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
            if (!IsPostBack)
            {
                Session["PreviousURL"] = HttpContext.Current.Request.Url.AbsoluteUri;
            }
        }


        public string fetchChkRequestListing()
        {
            string data = "";

            try
            {

                DataSet ds = new DataSet();

                if (LoggedInUserID == "")
                {
                    return "";
                }

                ds = ObjUpkeep.Fetch_MyChecklist(LoggedInUserID, Session["CompanyID"].ToString(), "", "");

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
                            //string Chk_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Chk_Desc"]);
                            string Is_Enable_Score = Convert.ToString(ds.Tables[0].Rows[i]["Is_Enable_Score"]);
                            string Total_Score = Convert.ToString(ds.Tables[0].Rows[i]["Total_Score"]);
                            string Created_By = Convert.ToString(ds.Tables[0].Rows[i]["Created_By"]);
                            string Created_Date = Convert.ToString(ds.Tables[0].Rows[i]["Created_Date"]);
                            string Updated_By = Convert.ToString(ds.Tables[0].Rows[i]["Updated_By"]);
                            string Updated_date = Convert.ToString(ds.Tables[0].Rows[i]["Updated_date"]);

                            //data += "<tr><td> <a href='CheckList_Configuration.aspx?ChkConfigID=" + Chk_Config_ID + "' style='text-decoration: underline;' > " + Chk_Title + " </a></td>" +
                            //    "<td>" + Chk_Desc + "</td>" +
                            //    "<td>" + Is_Enable_Score + "</td>" +
                            //    "<td>" + Total_Score + "</td>" +
                            //    "<td>" + Created_By + "</td>" +
                            //    "<td>" + Created_Date + "</td>" +
                            //    "<td>" + Updated_By + "</td>" +
                            //    "<td>" + Updated_date + "</td>" + 
                            //    "</tr>";

                            data += "<tr>" +
                                "<td>" + Chk_Title + "</td>" +
                                //"<td>" + Chk_Desc + "</td>" +
                               // "<td>" + Is_Enable_Score + "</td>" +
                                "<td>" + Total_Score + "</td>" +
                                "<td>" + Created_By + "</td>" +
                                "<td>" + Created_Date + "</td>" +
                                "<td>" + Updated_By + "</td>" +
                                "<td>" + Updated_date + "</td>" +
                                "<td><a href='CheckList_Configuration.aspx?ChkConfigID=" + Chk_Config_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record'> <i class='la la-edit'></i> </a>  " +
                                "<a href='#' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation removeItem' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record' data-config-id='" + Chk_Config_ID + "'><i class='la la-trash'></i> </a> " +
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
         
        public string DeleteChkRequestListing()
        { 
            if (hdnDeleteID.Value != "")
            {
               ObjUpkeep.Delete_CHKConfiguration(Convert.ToInt32(hdnDeleteID.Value.ToString()), LoggedInUserID);
            }
            hdnDeleteID.Value = "";

            return "";
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteChkRequestListing();
        }
    }

}