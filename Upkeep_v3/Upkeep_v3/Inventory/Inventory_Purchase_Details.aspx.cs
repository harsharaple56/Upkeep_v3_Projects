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
    public partial class Inventory_Purchase_Details : System.Web.UI.Page
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
        protected void btnPopup_Click(object sender, EventArgs e)
        {
            fetchInvItemSelectedListing();
        }
        public string fetchInvStockListing()
        {
            string data = "";

            try
            {

                DataSet ds = new DataSet();

                if (LoggedInUserID == "")
                {
                    return "";
                }

                ds = ObjUpkeep.Fetch_Stock_List(LoggedInUserID, Session["CompanyID"].ToString());

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
                            string Balance = Convert.ToString(ds.Tables[0].Rows[i]["Balance"]);


                            data += "<tr>" +
                                "<td>" + "<input type='checkbox' id='" + Item_ID + "' name='" + Item_ID + "' value ='" + Item_ID + "'>" + "</td>" +
                                "<td>" + Items + "</td>" +
                                "<td>" + Department + "</td>" +
                                "<td>" + Category + "</td>" +
                                "<td>" + Sub_Category + "</td>" +
                                "<td>" + Balance + "</td>" +
                                //"<td><a href='Inventory_Stock_Detail.aspx?Stock_ID=" + Stock_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record'> <i class='la la-edit'></i> </a>  " +
                                //"<a href='#' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation removeItem' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record' data-config-id='" + Stock_ID + "'><i class='la la-trash'></i> </a> " +
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

        public void fetchInvItemSelectedListing()
        {
            string data = "";

            try
            {

                DataSet ds = new DataSet();

                if (LoggedInUserID == "")
                {

                    hdnTableBody.Value = "";
                }


                if (hdnIsSubmitted.Value == "")
                {
                    hdnTableBody.Value = "";
                }

                if (hdnPrntD.Value == "")
                {
                    hdnTableBody.Value = "";
                }

                string[] sply = hdnPrntD.Value.Split(',');


                StringBuilder strXmlItem = new StringBuilder();

                strXmlItem.Append(@"<DocumentElement>");
                strXmlItem.Append(@"<Items>");
                if (sply.Length > 0)
                {
                    for (int d = 0; d < sply.Length; d++)
                    {
                        if (sply[d].ToString() != "")
                        {
                            strXmlItem.Append(@"<ItemID>" + sply[d].ToString() + "</ItemID>");
                        }
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

                            string OpName = "OP" + Item_ID;
                            string CoName = "CO" + Item_ID;

                            data += "<tr>" +
                            "<td>" + Convert.ToInt32(i) + 1 + "</td>" +
                            //"<td style ='display:none'>" + Item_ID + "</td>" +
                            "<td>" + Items + "</td>" +
                            "<td>" + "<input type='number' id='" + OpName + "' name='" + Item_ID + "' value ='1' min='1'>" + "</td>" +
                            "<td>" + "<input type='number' id='" + CoName + "' name='" + Item_ID + "' value ='0' min='0'>" + "</td>" +
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
           // Page.ClientScript.RegisterStartupScript(this.GetType(), "CallBindTable", "BindTable();", true);

        }

        protected void btnModalsubmit_Click(object sender, EventArgs e)
        {
            if (txtHdn.Text != "")
            {

                int Status = 0;
                DataSet ds = new DataSet();
  
                //PROCESS DATA 
                ds = ObjUpkeep.Crud_Inv_Purchase(Convert.ToString(Session["LoggedInUserID"]), Convert.ToString(Session["CompanyID"]), Convert.ToString(0), txtHdn.Text);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        //ViewState["Stock_ID"] = Convert.ToString(ds.Tables[0].Rows[0]["StockID"]);
                        //Session["Stock_ID"] = Convert.ToString(ds.Tables[0].Rows[0]["StockID"]);
                    }
                }

                txtHdn.Text = "";

                //DISPLAY RESPONSE
                if (Status == 1)
                {
                    lblErrorMsg.Text = "Due to some technical issue, Request Cannot be Processed. Kindly try after some time";
                }
                else if (Status == 2)
                {
                    //lblErrorMsg.Text = "OKAY";
                    //lblWpRequestCode.Text = Convert.ToString(ViewState["RequestAssetID"]).ToString();
                    //mpeWpRequestSaveSuccess.Show();
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Data saved successfully')</script>");

                    Response.Redirect(Page.ResolveClientUrl("~/Inventory/Inventory_Purchase_List.aspx"), false);
                    //return;
                }
                else if (Status == 3)
                {
                    lblErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                }
                else
                {
                    lblErrorMsg.Text = "Error Occured !!!";
                }
            }
        }

         

        public string DeleteInvStockListing()
        {
            //if (hdnDeleteID.Value != "")
            //{
            //    ObjUpkeep.Delete_Inv_Stock(Convert.ToInt32(hdnDeleteID.Value.ToString()), LoggedInUserID);
            //}
            //hdnDeleteID.Value = "";

            return "";
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteInvStockListing();
        }

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