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
    public partial class Inventory_Transaction_Details : System.Web.UI.Page
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
                ViewState["Stock_ID"] = 0;
                if (Request.QueryString["Stock_ID"] != null)
                {
                    ViewState["Stock_ID"] = Convert.ToInt32(Request.QueryString["Stock_ID"]);
                }

                Session["PreviousURL"] = HttpContext.Current.Request.Url.AbsoluteUri;
            }

        }

        public string fetchInvItemListing()
        {
            string data = "";

            try
            {

                DataSet ds = new DataSet();

                if (LoggedInUserID == "")
                {
                    return "";
                }


                ds = ObjUpkeep.Fetch_Stock_Detail(LoggedInUserID, Session["CompanyID"].ToString(), (int)ViewState["Stock_ID"]);


                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            string Stock_ID = Convert.ToString(ds.Tables[0].Rows[i]["Stock_ID"]);
                            string Item_ID = Convert.ToString(ds.Tables[0].Rows[i]["Item_ID"]);
                            string Items = Convert.ToString(ds.Tables[0].Rows[i]["Items"]);
                            string Department = Convert.ToString(ds.Tables[0].Rows[i]["Department"]);
                            string Category = Convert.ToString(ds.Tables[0].Rows[i]["Category"]);
                            string Sub_Category = Convert.ToString(ds.Tables[0].Rows[i]["Sub_Category"]);

                            //if ((int)ViewState["Stock_ID"] != 0)
                            //{
                                data += "<tr>" +
                                "<td>" + "<input type='checkbox' id='" + Stock_ID + "' name='" + Stock_ID + "' value ='" + Stock_ID + "'>" + "</td>" +
                                "<td>" + Items + "</td>" +
                                "<td>" + Department + "</td>" +
                                "<td>" + Category + "</td>" +
                                "<td>" + Sub_Category + "</td>" +
                                "</tr>";
                            //}
                            //else
                            //{
                            //    data += "<tr>" +
                            //    "<td>" + "<input type='checkbox' id='" + Item_ID + "' name='" + Item_ID + "' value ='" + Item_ID + "'>" + "</td>" +
                            //    "<td>" + Items + "</td>" +
                            //    "<td>" + Department + "</td>" +
                            //    "<td>" + Category + "</td>" +
                            //    "<td>" + Sub_Category + "</td>" +
                            //    "</tr>";

                            //}
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



        protected void btnPopup_Click(object sender, EventArgs e)
        {
            fetchInvItemSelectedListing();
        }
        public void fetchInvItemSelectedListing()
        {
            string data = "";
            hdnTableBody.Value = "";
            try
            {

                DataSet ds = new DataSet();

                if (LoggedInUserID == "")
                {

                    hdnTableBody.Value = "";
                }

                //if (hdnPrntD.Value == "")
                //{
                //    return "";
                //}

                string[] sply = hdnPrntD.Value.Split(',');


                StringBuilder strXmlItem = new StringBuilder();

                strXmlItem.Append(@"<DocumentElement>");
                strXmlItem.Append(@"<Items>");
                if (sply.Length > 0)
                {
                    for (int d = 0; d < sply.Length; d++)
                    {
                        strXmlItem.Append(@"<ItemID>" + sply[d].ToString() + "</ItemID>");
                    }
                }
                else
                {
                    strXmlItem.Append(@"<ItemID>" + "0" + "</ItemID>");
                }

                strXmlItem.Append(@"</Items>");
                strXmlItem.Append(@"</DocumentElement>");

                ds = ObjUpkeep.Fetch_Inv_Items_List(LoggedInUserID, Session["CompanyID"].ToString(), strXmlItem.ToString());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            string Item_ID = Convert.ToString(ds.Tables[0].Rows[i]["Item_ID"]);
                            string Items = Convert.ToString(ds.Tables[0].Rows[i]["Items"]);
                            string OpeningStock = Convert.ToString(ds.Tables[0].Rows[i]["OpeningStock"]);
                            string Consumed = Convert.ToString(ds.Tables[0].Rows[i]["Consumed"]);
                            string Balance = Convert.ToString(ds.Tables[0].Rows[i]["Balance"]);

                            string OpName = "OP" + Item_ID;
                            string CoName = "CO" + Item_ID;

                            data += "<tr>" +
                            "<td>" + Convert.ToInt32(i) + 1 + "</td>" +
                            //"<td style ='display:none'>" + Item_ID + "</td>" +
                            "<td>" + Items + "</td>" +
                            "<td>" + "<input type='number' id='" + OpName + "' name='" + Item_ID + "' value ='" + OpeningStock + "' min='0' readonly>" + "</td>" +
                            "<td>" + "<input type='number' id='" + CoName + "' name='" + Item_ID + "' value ='" + Consumed + "' min='0' onchange ='CompareTargetVal()'>" + "</td>" +
                            "<td>" + "<input type='number' id='" + i + "' name='" + i + "' value ='" + Balance + "' readonly>" + "</td>" +
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

            hdnTableBody.Value = data;
        }


        protected void btnModalsubmit_Click(object sender, EventArgs e)
        {
            if (txtHdn.Text != "")
            {
                txtHdn.Text = "";
            }
        }

        //public string DeleteInvStockListing()
        //{
        //    if (hdnDeleteID.Value != "")
        //    {
        //        ObjUpkeep.Delete_Inv_Stock(Convert.ToInt32(hdnDeleteID.Value.ToString()), LoggedInUserID);
        //    }
        //    hdnDeleteID.Value = "";

        //    return "";
        //}
        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //    DeleteInvStockListing();
        //}

        //protected void btnPrintAll_Click(object sender, EventArgs e)
        //{
        //    if (hdnPrntD.Value != "")
        //    {
        //        string founderMinus1 = hdnPrntD.Value.TrimEnd(',');
        //        Session["PrintIdList"] = "";
        //        Session["PrintIdList"] = founderMinus1;

        //        Response.Redirect("ReportViewer.aspx");
        //    }
        //    hdnPrntD.Value = "";
        //}

    }
}