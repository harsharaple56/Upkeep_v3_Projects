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
    public partial class Inventory_Purchase_List : System.Web.UI.Page
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

                ds = ObjUpkeep.Fetch_Inv_Item_Purchase_List(LoggedInUserID, Session["CompanyID"].ToString());

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            string Purchase_ID = Convert.ToString(ds.Tables[0].Rows[i]["Purchase_ID"]);
                            string Item_ID = Convert.ToString(ds.Tables[0].Rows[i]["Item_ID"]);
                            string Items = Convert.ToString(ds.Tables[0].Rows[i]["Items"]);
                            string Count = Convert.ToString(ds.Tables[0].Rows[i]["Count"]);
                            string Cost_rate = Convert.ToString(ds.Tables[0].Rows[i]["Cost_rate"]);
                            string PurchaseDate = Convert.ToString(ds.Tables[0].Rows[i]["PurchaseDate"]);


                            data += "<tr>" +
                                //"<td>" + "<input type='checkbox' id='" + Stock_ID + "' name='" + Stock_ID + "' value ='" + Stock_ID + "'>" + "</td>" +
                                "<td>" + Items + "</td>" +
                                "<td>" + Count + "</td>" +
                                "<td>" + Cost_rate + "</td>" +
                                "<td>" + PurchaseDate + "</td>" +
                                "<td><a href='#' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only editItem' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record' data-config-id='" + Purchase_ID + "' data-items-id='" + Item_ID + "'  data-itemname-id='" + Items + "'  data-count-id='" + Count + "'  data-crate-id='" + Cost_rate + "'> <i class='la la-edit'></i> </a>  " +
                                "<a href='#' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation removeItem' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record' data-config-id='" + Purchase_ID + "' ><i class='la la-trash'></i> </a> " +
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

        public string DeleteInvStockListing()
        {
            if (hdnDeleteID.Value != "")
            {
                ObjUpkeep.Delete_Inv_Purchase(Convert.ToInt32(hdnDeleteID.Value.ToString()), LoggedInUserID);
            }
            hdnDeleteID.Value = "";

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
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (hdneditD.Value != "")
            {
                DataSet ds = new DataSet();

                if (LoggedInUserID != "")
                {

                    ds = ObjUpkeep.Fetch_Inv_Item_Purchase_List(LoggedInUserID, Session["CompanyID"].ToString());

                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                            for (int i = 0; i < count; i++)
                            {
                                lblPurchaseId.Value = Convert.ToString(ds.Tables[0].Rows[i]["Purchase_ID"]);
                                lblItemId.Value = Convert.ToString(ds.Tables[0].Rows[i]["Item_ID"]);

                                txtItem.Text = Convert.ToString(ds.Tables[0].Rows[i]["Items"]);
                                txtCount.Value = Convert.ToString(ds.Tables[0].Rows[i]["Count"]);
                                txtCost_rate.Value = Convert.ToString(ds.Tables[0].Rows[i]["Cost_rate"]);
                            }
                        }
                        else
                        {
                            //invalid login
                        }
                    }
                }
            }

        }
        protected void btnModalsubmit_Click(object sender, EventArgs e)
        {
            if (lblPurchaseId.Value != "")
            {
                int Status = 0;
                DataSet ds = new DataSet();

                //PROCESS DATA 
                StringBuilder strXmlAt = new StringBuilder();
                //strXmlAsset.Append(@"<?xml version=""1.0"" ?>");
                strXmlAt.Append(@"<DocumentElement>");
                strXmlAt.Append(@"<Items>"); 
                //-------------------------------------------------------------------------------------------------------------------
                strXmlAt.Append(@"<ItemId>" + lblItemId.Value.ToString() + "</ItemId>");
                strXmlAt.Append(@"<ConsumedBalance>" + txtCount.Value.ToString() + "</ConsumedBalance>");
                strXmlAt.Append(@"<Cost_rate>" + txtCost_rate.Value.ToString() + "</Cost_rate>");
                //-------------------------------------------------------------------------------------------------------------------
                strXmlAt.Append(@"</Items>");
                strXmlAt.Append(@"</DocumentElement>");

                ds = ObjUpkeep.Crud_Inv_Purchase(Convert.ToString(Session["LoggedInUserID"]), Convert.ToString(Session["CompanyID"]), Convert.ToString(lblPurchaseId.Value), strXmlAt.ToString());
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
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Due to some technical issue, Request Cannot be Processed. Kindly try after some time')</script>");
                    return;
                }
                else if (Status == 2)
                {
                    //lblErrorMsg.Text = "OKAY";
                    //lblWpRequestCode.Text = Convert.ToString(ViewState["RequestAssetID"]).ToString();
                    //mpeWpRequestSaveSuccess.Show();
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Data saved successfully')</script>");
                    return;
                }
                else if (Status == 3)
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Due to some technical issue your request can not be process. Kindly try after some time')</script>");
                    return;
                }
                else
                {

                }
            }
            else
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('No Item Found for Updation')</script>");
                return;
            }
        }


    }
}