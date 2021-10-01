using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.Services;

namespace Upkeep_v3.Inventory
{
    public partial class Add_Inventory_Transaction : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (LoggedInUserID == "")
            {
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

        [WebMethod(EnableSession = true)]
        public static string ConsumedUpdate(string xmldata, string TransID, string DeptID)
        {
            Add_Inventory_Transaction form = new Add_Inventory_Transaction();
            DataSet ds = new DataSet();
            string Status = string.Empty;
            ds = form.ObjUpkeep.Crud_Inv_Transaction(Convert.ToString(form.Session["LoggedInUserID"]), Convert.ToString(form.Session["CompanyID"]), DeptID, TransID, xmldata);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Status = Convert.ToString(ds.Tables[0].Rows[0]["Status"]);
                }
            }
            return Status;
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
                        ddlDepartment.Items.Insert(0, new ListItem("---- Select Department ----", "0"));
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
                            string Transac_ID = Convert.ToString(ds.Tables[0].Rows[i]["Transac_ID"]);
                            string Transac_Detail_ID = Convert.ToString(ds.Tables[0].Rows[i]["Transac_Detail_ID"]);
                            string Stock_ID = Convert.ToString(ds.Tables[0].Rows[i]["Stock_ID"]);
                            string Item_ID = Convert.ToString(ds.Tables[0].Rows[i]["Item_ID"]);
                            string Items = Convert.ToString(ds.Tables[0].Rows[i]["Items"]);
                            string Department = Convert.ToString(ds.Tables[0].Rows[i]["Department"]);
                            string Category = Convert.ToString(ds.Tables[0].Rows[i]["Category"]);
                            string Sub_Category = Convert.ToString(ds.Tables[0].Rows[i]["Sub_Category"]);
                            string Balance = Convert.ToString(ds.Tables[0].Rows[i]["Balance"]);
                            string Consumed = Convert.ToString(ds.Tables[0].Rows[i]["Consumed"]);

                            string chkBoxField = "";

                            if ((int)ViewState["TransID"] > 0)
                            {
                                chkBoxField = "<td>" + "<label style='margin-bottom:18px;margin-left:14px;' class='m-checkbox'><input type='checkbox' id='" + Transac_Detail_ID + "' " +
                                    "name='" + Transac_Detail_ID + "' value ='" + Transac_Detail_ID + "' checked readonly disabled><span></span></label>" + "</td>";
                            }
                            else
                            {
                                chkBoxField = "<td>" + "<label style='margin-bottom:18px;margin-left:14px;' class='m-checkbox'><input type='checkbox' id='" + Transac_Detail_ID + "' " +
                                    "name='" + Transac_Detail_ID + "' value ='" + Transac_Detail_ID + "'><span></span></label>" + "</td>";
                            }

                            data += "<tr>" +

                            chkBoxField +

                            "<td>" + Items + "</td>" +
                            "<td>" + Department + "</td>" +
                            "<td>" + Category + "</td>" +
                            "<td>" + Sub_Category + "</td>" +
                            "<td>" + Balance + "</td>" +
                            "<td>" + "<input id='" + Item_ID + "' data-transiddata ='" + Transac_ID + "' data-isdata ='" + Transac_Detail_ID + "' style='width:150px' class='form-control' type='number' value='" + Consumed + "' disabled></td>" +
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