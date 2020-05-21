using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Text;
using System.Data;

namespace Upkeep_Gatepass_Workpermit.GatePass
{
    public partial class GatePass_Approval : System.Web.UI.Page
    {
        Upkeep_GP_WP_Services.Upkeep_GP_WP_Services ObjUpkeep = new Upkeep_GP_WP_Services.Upkeep_GP_WP_Services();
        string LoggedInUserID = string.Empty;
        string MyActionFlag = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            int TransactionID = Convert.ToInt32(Request.QueryString["TransactionID"]);
            MyActionFlag= Convert.ToString(Request.QueryString["MyAction"]);
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }

            if (!IsPostBack)
            {
                if (TransactionID > 0)
                {
                    Session["TransactionID"] = Convert.ToString(TransactionID);
                    BindGatePassRequest_Approval_Details(TransactionID, LoggedInUserID);
                    //Session["PreviousURL"] = HttpContext.Current.Request.Url.AbsoluteUri;
                }
            }
        }

        public void BindGatePassRequest_Approval_Details(int TransactionID, string LoggedInUserID)
        {
            DataSet dsApproval = new DataSet();
            string RequestStatus = string.Empty;
            try
            {
                dsApproval = ObjUpkeep.Fetch_GatePassRequest_Approval_Details(TransactionID, LoggedInUserID);

                if (dsApproval.Tables.Count > 0)
                {
                    lblGatepassTitle.Text= Convert.ToString(dsApproval.Tables[0].Rows[0]["GP_Title"]);
                    lblGatepassDescription.Text = Convert.ToString(dsApproval.Tables[0].Rows[0]["Gatepass_Description"]);
                    lblTicketNo.Text= Convert.ToString(dsApproval.Tables[0].Rows[0]["TicketNo"]);
                    lblDepartment.Text = Convert.ToString(dsApproval.Tables[0].Rows[0]["DepartmentName"]);
                    lblRequestDate.Text = Convert.ToString(dsApproval.Tables[0].Rows[0]["GatePassDate"]);
                    lblGatePassType.Text = Convert.ToString(dsApproval.Tables[0].Rows[0]["GP_Type_Desc"]);

                    RequestStatus= Convert.ToString(dsApproval.Tables[0].Rows[0]["GP_Status"]);
                    if (Convert.ToString(dsApproval.Tables[0].Rows[0]["GP_Status"]) == "Open")
                    {
                        dvApprovalHistory.Attributes.Add("Style", "display:none;");
                    }
                    else
                    {
                        dvApprovalHistory.Attributes.Add("Style", "display:block;");
                    }

                    if (RequestStatus == "Open")
                    {
                        lblRequestStatus.Text = "Open";
                        lblRequestStatus.Attributes.Add("class", "m-badge m-badge--danger m-badge--wide");
                    }
                    else if (RequestStatus == "Approve")
                    {
                        lblRequestStatus.Text = "Approved";
                        lblRequestStatus.Attributes.Add("class", "m-badge m-badge--info m-badge--wide");
                    }
                    else if (RequestStatus == "In Progress")
                    {
                        lblRequestStatus.Text = "In Progress";
                        lblRequestStatus.Attributes.Add("class", "m-badge m-badge--success m-badge--wide");
                    }
                    else if (RequestStatus == "Close")
                    {
                        lblRequestStatus.Text = "Closed";
                        lblRequestStatus.Attributes.Add("class", "m-badge m-badge--success m-badge--wide");
                    }
                    else if (RequestStatus == "Hold")
                    {
                        lblRequestStatus.Text = "Hold";
                        lblRequestStatus.Attributes.Add("class", "m-badge m-badge--warning m-badge--wide");
                    }
                    else if (RequestStatus == "Reject")
                    {
                        lblRequestStatus.Text = "Rejected";
                        lblRequestStatus.Attributes.Add("class", "m-badge m-badge--danger m-badge--wide");
                    }

                }
                if (dsApproval.Tables.Count > 1)
                {
                    string strUserType = Convert.ToString(dsApproval.Tables[1].Rows[0]["UserType"]);
                    if (strUserType == "E")
                    {
                        dvEmployee.Attributes.Add("style", "display:block;");
                        dvRetailer.Attributes.Add("style", "display:none;");
                    }
                    else
                    {
                        dvEmployee.Attributes.Add("style", "display:none;");
                        dvRetailer.Attributes.Add("style", "display:block;");
                    }

                    if (dsApproval.Tables.Count > 0)
                    {
                        if (dsApproval.Tables[1].Rows.Count > 0)
                        {
                            if (strUserType == "E")
                            {
                                lblEmpName.Text = Convert.ToString(dsApproval.Tables[1].Rows[0]["Name"]);
                                lblEmpCode.Text = Convert.ToString(dsApproval.Tables[1].Rows[0]["Code"]);
                                lblMobileNo.Text = Convert.ToString(dsApproval.Tables[1].Rows[0]["Mobile"]);
                                LblEmailID.Text = Convert.ToString(dsApproval.Tables[1].Rows[0]["Email"]);
                            }
                            else
                            {
                                lblStoreName.Text = Convert.ToString(dsApproval.Tables[1].Rows[0]["Retail_Store_Name"]);
                                lblRetailerName.Text = Convert.ToString(dsApproval.Tables[1].Rows[0]["Store_Mger_Name"]);
                                lblMobileNo.Text = Convert.ToString(dsApproval.Tables[1].Rows[0]["Contact"]);
                                LblEmailID.Text = Convert.ToString(dsApproval.Tables[1].Rows[0]["Email"]);
                            }


                        }
                    }
                }

                if (dsApproval.Tables.Count > 1)
                {
                    if (dsApproval.Tables[2].Rows.Count > 0)
                    {
                        gvGPHeader.DataSource = dsApproval.Tables[2];
                        gvGPHeader.DataBind();
                    }
                }

                if (dsApproval.Tables.Count > 2)
                {
                    if (dsApproval.Tables[3].Rows.Count > 0)
                    {
                        rptTermsCondition.DataSource = dsApproval.Tables[3];
                        rptTermsCondition.DataBind();
                    }
                }

                if (dsApproval.Tables.Count > 3)
                {
                    if (dsApproval.Tables[4].Rows.Count > 0)
                    {
                        ddlAction.DataSource = dsApproval.Tables[4];
                        ddlAction.DataTextField = "Action_Desc";
                        ddlAction.DataValueField = "ActionID";
                        ddlAction.DataBind();
                        ddlAction.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }

                if (dsApproval.Tables.Count > 4)
                {
                    if (dsApproval.Tables[5].Rows.Count > 0)
                    {
                        Session["CurrentLevel"] = Convert.ToString(dsApproval.Tables[5].Rows[0]["CurrentLevel"]);

                        //if (Convert.ToInt32(dsApproval.Tables[5].Rows[0]["CurrentLevel"]) == 1)
                        //{
                        //    dvApprovalHistory.Attributes.Add("Style", "display:none;");

                        //}
                        //else
                        //{
                        //    dvApprovalHistory.Attributes.Add("Style", "display:block;");
                        //}
                    }
                }

                if (dsApproval.Tables.Count > 5)
                {
                    if (dsApproval.Tables[6].Rows.Count > 0)
                    {
                        gvApprovalHistory.DataSource = dsApproval.Tables[6];
                        gvApprovalHistory.DataBind();
                    }
                }

                string Is_Initiator = Convert.ToString(dsApproval.Tables[5].Rows[0]["Is_Initiator"]);

                if (dsApproval.Tables.Count > 6)
                {
                    if (dsApproval.Tables[7].Rows.Count > 0)
                    {
                        gvApprovalMatrix.DataSource = dsApproval.Tables[7];
                        gvApprovalMatrix.DataBind();

                        if (Is_Initiator == "1")
                        {
                            dvApprovalMatrix.Attributes.Add("Style", "display:block;");
                        }
                        else
                        {
                            dvApprovalMatrix.Attributes.Add("Style", "display:none;");
                        }
                    }
                }

                if (MyActionFlag=="1")
                {

                    //dvApprovalDetHeader.Attributes.Add("Style", "display:block;");
                    //dvApprovalDetails.Attributes.Add("Style", "display:block;");
                    //dvSubmitSection.Attributes.Add("Style", "display:block;");
                }
                else
                {
                    dvApprovalDetHeader.Attributes.Add("Style", "display:none;");
                    dvApprovalDetails.Attributes.Add("Style", "display:none;");
                    dvSubmitSection.Attributes.Add("Style", "display:none;"); ;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string CurrentLevel =string.Empty;
            string TransactionID = string.Empty;
            string ActionStatus = string.Empty;
            string strRemarks = string.Empty;
            DataSet dsApproval = new DataSet();
            try
            {
                CurrentLevel = Convert.ToString(Session["CurrentLevel"]);
                TransactionID = Convert.ToString(Session["TransactionID"]);
                ActionStatus = Convert.ToString(ddlAction.SelectedItem.Text);
                strRemarks = Convert.ToString(txtRemarks.Text.Trim());

                dsApproval = ObjUpkeep.UpdateAction_GatePassRequest(TransactionID, CurrentLevel, ActionStatus, strRemarks, LoggedInUserID);

                if (dsApproval.Tables.Count > 0)
                {
                    if (dsApproval.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsApproval.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            Response.Redirect(Page.ResolveClientUrl(Convert.ToString(Session["PreviousURL"])), false);
                        }
                        else if (Status == 2)
                        {
                            lblErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl(Convert.ToString(Session["PreviousURL"])), false);
        }
    }
}