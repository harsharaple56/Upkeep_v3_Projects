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
                ViewState["TransID"] = 0;
                if (Request.QueryString["TransID"] != null)
                {
                    ViewState["TransID"] = Convert.ToInt32(Request.QueryString["TransID"]);
                }

                Session["PreviousURL"] = HttpContext.Current.Request.Url.AbsoluteUri;

                BindDropDown();
            }

        }
        public void BindDropDown()
        {
            try
            {
                DataSet dsTitle = new DataSet();

                dsTitle = ObjUpkeep.Fetch_Inv_Item_Stock_Ddl(Convert.ToString(Session["LoggedInUserID"]), Convert.ToString(Session["CompanyID"]), Convert.ToString(0));

                if (dsTitle.Tables.Count > 0)
                {
                    if (dsTitle.Tables[1].Rows.Count > 0)
                    {
                        ddlDepartment.DataSource = dsTitle.Tables[1];
                        ddlDepartment.DataTextField = "Dept_Desc";
                        ddlDepartment.DataValueField = "Department_ID";
                        ddlDepartment.DataBind();
                        ddlDepartment.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

                if ((int)ViewState["TransID"] > 0)
                {
                    ds = ObjUpkeep.Fetch_Tran_Detail(LoggedInUserID, Session["CompanyID"].ToString(), (int)ViewState["TransID"]);
                }
                else
                {
                    ds = ObjUpkeep.Fetch_Stock_Detail(LoggedInUserID, Session["CompanyID"].ToString(), 0);
                }


                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if ((int)ViewState["TransID"] > 0)
                        {
                            ddlDepartment.SelectedValue = ds.Tables[0].Rows[0]["Department_ID"].ToString();
                        }

                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            string Stock_ID = Convert.ToString(ds.Tables[0].Rows[i]["Stock_ID"]);
                            string Item_ID = Convert.ToString(ds.Tables[0].Rows[i]["Item_ID"]);
                            string Items = Convert.ToString(ds.Tables[0].Rows[i]["Items"]);
                            string Department = Convert.ToString(ds.Tables[0].Rows[i]["Department"]);
                            string Category = Convert.ToString(ds.Tables[0].Rows[i]["Category"]);
                            string Sub_Category = Convert.ToString(ds.Tables[0].Rows[i]["Sub_Category"]);
                            string OpeningStock = Convert.ToString(ds.Tables[0].Rows[i]["OpeningStock"]);
                            string Consumed = Convert.ToString(ds.Tables[0].Rows[i]["Consumed"]);
                            string Balance = Convert.ToString(ds.Tables[0].Rows[i]["Balance"]);

                            string chkBoxField = "";
                            if ((int)ViewState["TransID"] > 0)
                            {
                                chkBoxField = "<td>" + "<input type='checkbox' id='" + Item_ID + "' name='" + Item_ID + "' value ='" + Item_ID + "' checked readonly disabled>" + "</td>";
                            }
                            else
                            {
                                chkBoxField = "<td>" + "<input type='checkbox' id='" + Item_ID + "' name='" + Item_ID + "' value ='" + Item_ID + "'>" + "</td>";
                            }

                            //if ((int)ViewState["Stock_ID"] != 0)
                            //{
                            data += "<tr>" +
                            //"<td>" + "<input type='checkbox' id='" + Stock_ID + "' name='" + Stock_ID + "' value ='" + Stock_ID + "'>" + "</td>" +

                            chkBoxField +

                            "<td>" + Items + "</td>" +
                            "<td>" + Department + "</td>" +
                            "<td>" + Category + "</td>" +
                            "<td>" + Sub_Category + "</td>" +
                            "<td>" + OpeningStock + "</td>" +
                            "<td>" + Consumed + "</td>" +
                            "<td>" + Balance + "</td>" +
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

                        strXmlItem.Append(@"<ItemXVal>");

                        strXmlItem.Append(@"<ItemID>" + sply[d].ToString() + "</ItemID>");

                        strXmlItem.Append(@"</ItemXVal>");
                    }
                }
                else
                {
                    strXmlItem.Append(@"<ItemID>" + "0" + "</ItemID>");
                }

                strXmlItem.Append(@"</Items>");
                strXmlItem.Append(@"</DocumentElement>");


                if ((int)ViewState["TransID"] > 0)
                {
                    ds = ObjUpkeep.Fetch_Tran_Item_Detail(LoggedInUserID, Session["CompanyID"].ToString(), (int)ViewState["TransID"], strXmlItem.ToString());
                }
                else
                {
                    ds = ObjUpkeep.Fetch_Inv_Items_List(LoggedInUserID, Session["CompanyID"].ToString(), strXmlItem.ToString());
                }


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

                            string TransDtl_ID = "0";
                            if ((int)ViewState["TransID"] > 0)
                            {
                                TransDtl_ID = Convert.ToString(ds.Tables[0].Rows[i]["TransDtl_ID"]);
                            }


                            string OpName = "OP" + Item_ID;
                            string CoName = "CO" + Item_ID;

                            int j = i + 1;

                            data += "<tr>" +
                            "<td>" + Convert.ToInt32(j) + "</td>" +
                            //"<td style ='display:none'>" + Item_ID + "</td>" +
                            "<td>" + Items + "</td>" +
                            //"<td>" + "<input type='text' id='" + TransDtl_ID + "' name='" + TransDtl_ID + "' value ='" + Items + "'readonly>" + "</td>" +
                            "<td>" + "<input type='number' id='" + OpName + "' name='" + Item_ID + "' value ='" + OpeningStock + "' min='0' readonly>" + "</td>" +
                            "<td>" + "<input type='number' id='" + CoName + "' name='" + Item_ID + "' value ='" + Consumed + "' data-isdata ='" + TransDtl_ID + "' min='0' onchange ='CompareTargetVal()'>" + "</td>" +
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

                int Status = 0;
                DataSet ds = new DataSet();
                //PROCESS DATA 
                ds = ObjUpkeep.Crud_Inv_Transaction(Convert.ToString(Session["LoggedInUserID"]), Convert.ToString(Session["CompanyID"]), ddlDepartment.SelectedValue.ToString()
                    , Convert.ToString((int)ViewState["TransID"]), txtHdn.Text);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
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

                    Response.Redirect(Page.ResolveClientUrl("~/Inventory/Inventory_Transaction_List.aspx"), false);
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