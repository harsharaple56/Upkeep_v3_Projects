using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Text;
using System.Web.UI.HtmlControls;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace Upkeep_Gatepass_Workpermit.GatePass
{
    public partial class GatePass_Request : System.Web.UI.Page
    {
        Upkeep_GP_WP_Services.Upkeep_GP_WP_Services ObjUpkeep = new Upkeep_GP_WP_Services.Upkeep_GP_WP_Services();
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //LoggedInUserID = "admin";
            //LoggedInUserID = "121";
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            if (!IsPostBack)
            {
                //GenerateTableHeader();
                //GenerateTable(3, 1);
                BindGatePassTitle();
            }
        }

        public void BindGatePassTitle()
        {
            DataSet dsTitle = new DataSet();
            string Initiator = string.Empty;
            try
            {
                Initiator = Convert.ToString(Session["UserType"]);
                dsTitle = ObjUpkeep.Fetch_GatePassConfiguration(Initiator);
                if (dsTitle.Tables.Count > 0)
                {
                    if (dsTitle.Tables[0].Rows.Count > 0)
                    {
                        ddlGatePassTitle.DataSource = dsTitle.Tables[0];
                        ddlGatePassTitle.DataTextField = "GP_Title";
                        ddlGatePassTitle.DataValueField = "Gp_Config_ID";
                        ddlGatePassTitle.DataBind();
                        ddlGatePassTitle.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string bindGatePassHeader()
        {
            string data = "";
            int GatePassTitleID = 0;
            try
            {
                // GatePassTitleID = Convert.ToInt32(ddlGatePassTitle.SelectedValue);

                GatePassTitleID = 6;

                DataSet dsGatePassHeader = new DataSet();
                dsGatePassHeader = ObjUpkeep.Bind_GatePassConfiguration(GatePassTitleID);

                if (dsGatePassHeader.Tables.Count > 2)
                {
                    if (dsGatePassHeader.Tables[3].Rows.Count > 0)
                    {
                        rptTermsCondition.DataSource = dsGatePassHeader.Tables[3];
                        rptTermsCondition.DataBind();
                    }
                }

                int ColumnCount = 0;

                if (dsGatePassHeader.Tables.Count > 0)
                {
                    if (dsGatePassHeader.Tables[1].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(dsGatePassHeader.Tables[1].Rows.Count);

                        ColumnCount = (dsGatePassHeader.Tables[1].Rows.Count);

                        string GPHeader = string.Empty;
                        for (int j = 0; j < count; j++)
                        {

                            GPHeader = Convert.ToString(dsGatePassHeader.Tables[1].Rows[j]["Header_Name"]);

                            //data += "<th data-container='body' data-toggle='m-tooltip' data-placement='top' title='Nostrud esse officia adipisicing dolore est in eiusmod dolor tempor adipisicing ut non non.'>Q" + j + "</th> ";
                            data += "<th data-container='body' data-toggle='m-tooltip' data-placement='top'>" + GPHeader + "</th> ";

                        }
                        //}

                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

        public string bindGatePassHeaderValue()
        {
            string data = "";


            return data;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void GenerateTable(int colsCount, int rowsCount)
        {
            //Creat the Table and Add it to the Page
            //Table table = new Table();
            //table.ID = "tblGatePassHeader";
            //Page.Form.Controls.Add(table);

            // Now iterate through the table and add your controls 
            //HtmlTableCell cell = new HtmlTableCell();
            for (int i = 0; i < rowsCount; i++)
            {
                HtmlTableRow row = new HtmlTableRow();
                for (int j = 0; j < colsCount; j++)
                {
                    HtmlTableCell cell = new HtmlTableCell();
                    TextBox tb = new TextBox();

                    // Set a unique ID for each TextBox added
                    tb.ID = "txtHeaderValue_" + i + "Col_" + j;
                    tb.Attributes.Add("class", "form-control");
                    // Add the control to the TableCell
                    cell.Controls.Add(tb);
                    // Add the TableCell to the TableRow
                    row.Cells.Add(cell);
                }

                //Button btn = new Button();
                //btn.ID = "btnDeleteRow";
                //cell.Controls.Add(btn);

                // Add the TableRow to the Table
                tblGatePassHeader.Rows.Add(row);
            }
        }

        private void GenerateTableHeader(int ConfigTitleID)
        {
            //Creat the Table and Add it to the Page
            //Table table = new Table();
            //table.ID = "tblGatePassHeader";
            //Page.Form.Controls.Add(table);

            int GatePassTitleID = 0;
            int colsCount = 0;
            string GPHeader = string.Empty;
            int SequenceID = 0;
            GatePassTitleID = ConfigTitleID;

            DataSet dsGatePassHeader = new DataSet();
            dsGatePassHeader = ObjUpkeep.Bind_GatePassConfiguration(GatePassTitleID);

            //if (dsGatePassHeader.Tables.Count > 1)
            //{
            //    if (dsGatePassHeader.Tables[2].Rows.Count > 0)
            //    {
            //        ddlGatePassType.DataSource = dsGatePassHeader.Tables[2];
            //        ddlGatePassType.DataTextField = "GP_Type_Desc";
            //        ddlGatePassType.DataValueField = "GP_Type_ID";
            //        ddlGatePassType.DataBind();
            //        ddlGatePassType.Items.Insert(0, new ListItem("--Select--", "0"));
            //    }
            //}

            //if (dsGatePassHeader.Tables.Count > 2)
            //{
            //    if (dsGatePassHeader.Tables[3].Rows.Count > 0)
            //    {
            //        rptTermsCondition.DataSource = dsGatePassHeader.Tables[3];
            //        rptTermsCondition.DataBind();
            //    }
            //}

            //DataTable dtHeader = new DataTable();
            //dtHeader = dsGatePassHeader.Tables[1];

            colsCount = Convert.ToInt32(dsGatePassHeader.Tables[1].Rows.Count);
            Session["colsCount"] = Convert.ToString(colsCount);
            // Now iterate through the table and add your controls 
            //HtmlTableCell cell = new HtmlTableCell();
            for (int i = 0; i < 1; i++)
            {
                HtmlTableRow row = new HtmlTableRow();
                for (int j = 0; j < colsCount; j++)
                {
                    GPHeader = Convert.ToString(dsGatePassHeader.Tables[1].Rows[j]["Header_Name"]);
                    HtmlTableCell cell = new HtmlTableCell();
                    //TextBox tb = new TextBox();
                    Label lbl = new Label();
                    // Set a unique ID for each TextBox added
                    lbl.ID = "lbl_" + SequenceID;
                    lbl.Text = GPHeader;
                    lbl.Attributes.Add("class", "form-control-label");
                    // Add the control to the TableCell
                    cell.Controls.Add(lbl);
                    // Add the TableCell to the TableRow
                    row.Cells.Add(cell);

                    SequenceID = SequenceID + 1;
                }
                HtmlTableCell cell2 = new HtmlTableCell();
                Label lblAction = new Label();
                lblAction.ID = "lblAction";
                lblAction.Text = "Action";
                cell2.Controls.Add(lblAction);
                row.Cells.Add(cell2);

                // Add the TableRow to the Table
                tblGatePassHeader.Rows.Add(row);
            }

            for (int i = 0; i < 1; i++)
            {
                HtmlTableRow row = new HtmlTableRow();
                for (int j = 0; j < colsCount; j++)
                {
                    GPHeader = Convert.ToString(dsGatePassHeader.Tables[1].Rows[j]["GP_Header_ID"]);
                    HtmlTableCell cell = new HtmlTableCell();
                    //TextBox tb = new TextBox();
                    Label lbl = new Label();
                    // Set a unique ID for each TextBox added
                    lbl.ID = "lbl_ID_" + SequenceID;
                    lbl.Text = GPHeader;
                    lbl.Attributes.Add("class", "form-control-label");
                    // Add the control to the TableCell
                    cell.Controls.Add(lbl);
                    // Add the TableCell to the TableRow
                    row.Cells.Add(cell);

                    SequenceID = SequenceID + 1;
                }
                HtmlTableCell cell2 = new HtmlTableCell();
                Label lblAction = new Label();
                lblAction.ID = "ColHeaderID";
                //lblAction.Text = "Action";
                cell2.Controls.Add(lblAction);
                row.Cells.Add(cell2);

                // Add the TableRow to the Table
                tblGatePassHeader.Rows.Add(row);

                tblGatePassHeader.Rows[1].Attributes.Add("style", "display:none;");
            }



            GenerateTable(colsCount, 1);
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            int colsCount = 0;
            colsCount = Convert.ToInt32(Session["colsCount"]);
            GenerateTable(colsCount, 1);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            //foreach (RepeaterItem item in rptTermsCondition.Items)
            //{
            //    if (((CheckBox)item.FindControl("chkTermsCondition")).Checked==false)
            //    {
            //        //Do something
            //        lblErrorMsg1.Text = "Please select all Terms and Conditions";
            //    }
            //}


            string GpHeader = Convert.ToString(hdnGpHeader.Value);
            string GpHeaderData = Convert.ToString(hdnGpHeaderData.Value);

            string[] strArrayGpHeader = GpHeader.Split(',');
            string[] strArrayGpHeaderData = GpHeaderData.Split(',');

            int recCount = 0;
            recCount = strArrayGpHeader.Length - 1;

            DataTable dtHeader = new DataTable();

           // string df = "1,2,1,3";

            int i;

            DataColumn dc = new DataColumn();

            dtHeader.Columns.Add(dc);

            for (i = 0; i < 1; i++)
            {
                string[] LocArr = strArrayGpHeader[i].Split('#');
                int recCount2 = LocArr.Length;

                for (int j = 0; j < recCount2; j++)
                {
                    if (LocArr[j] != "")
                    {
                        //dr[dc] = GpHeader.Split(',')[i];
                        //dr[dc] = LocArr[j];
                        //dt.Rows.Add(dr);
                        dtHeader.Columns.Add(LocArr[j]);

                    }
                }
            }

            string[] LocArray = strArrayGpHeader[1].Split('#');

            DataRow row = dtHeader.NewRow(); ///creating new row in your datatable

            row.ItemArray = LocArray;///copying your data into data row object

            dtHeader.Rows.InsertAt(row, 2);///insert row at 3rd index of datatable


            for (int k = 0; k < strArrayGpHeaderData.Length-1; k++)
            {

                string[] HValueArray = strArrayGpHeaderData[k].Split('#');

                ////if(HValueArray)
                DataRow rowHValue = dtHeader.NewRow(); ///creating new row in your datatable

                rowHValue.ItemArray = HValueArray;///copying your data into data row object

                dtHeader.Rows.InsertAt(rowHValue, 2);///insert row at 3rd index of datatable

            }

            dtHeader.Columns.Remove("Column1");

            ////string  StrConn = ConfigurationManager.ConnectionStrings["Upkeep_GP_WP_ConString"].ConnectionString.ToString();
            ////SqlBulkCopy bulkInsert = new SqlBulkCopy(StrConn);
            ////bulkInsert.DestinationTableName = "Tbl_Temp_Gp_HeaderData";
            ////bulkInsert.WriteToServer(dtHeader);

            int GP_ConfigID = 0;
            string strGatePassDate = string.Empty;
            int DeptID = 0;
            int TypeID = 0;

            GP_ConfigID = Convert.ToInt32(ddlGatePassTitle.SelectedValue);
            strGatePassDate = Convert.ToString(txtGatePassDate.Text.Trim());
            DeptID = Convert.ToInt32(ddlDepartment.SelectedValue);
            TypeID = Convert.ToInt32(ddlGatePassType.SelectedValue);


            DataSet dsGpHeaderData = new DataSet();
            dsGpHeaderData = ObjUpkeep.Insert_GatePassRequest(GP_ConfigID, strGatePassDate, DeptID, TypeID, GpHeader, GpHeaderData, LoggedInUserID);

            if (dsGpHeaderData.Tables.Count > 0)
            {
                if (dsGpHeaderData.Tables[0].Rows.Count > 0)
                {
                    int Status = Convert.ToInt32(dsGpHeaderData.Tables[0].Rows[0]["Status"]);
                    if (Status == 1)
                    {
                        lblGPRequestCode.Text = Convert.ToString(dsGpHeaderData.Tables[1].Rows[0]["RequestID"]);

                        mpeGpRequestSaveSuccess.Show();
                    }
                }
            }


            //DataSet ds = new DataSet();
            //ds.Tables.Add(dtHeader);
            //string dsXml = ds.GetXml();

            //System.IO.StringWriter writer = new System.IO.StringWriter();
            //dtHeader.WriteXml(writer, XmlWriteMode.WriteSchema, false);
            //string result = writer.ToString();

            //int ie = 0;
            //for (i = 0; i < recCount; i++)
            //{
            //    DataRow dr = dt.NewRow();
            //    string[] LocArr = strArrayGpHeader[i].Split('#');
            //    int recCount2 = LocArr.Length ;

            //    for (int j = 0; j < recCount2; j++)
            //    {
            //        if (LocArr[j] != "")
            //        {
            //            //dr[dc] = GpHeader.Split(',')[i];
            //            //dr[dc] = LocArr[j];
            //            //dt.Rows.Add(dr);
            //            dt.Columns.Add(LocArr[j]);

            //        }
            //    }

            //    //dr[dc] = GpHeader.Split(',')[i];

            //    dt.Rows.Add(dr);

            //}




            //XmlDocument xmlDocProm = null;
            //xmlDocProm = new XmlDocument();
            //int recCount = 0;
            //recCount = strArrayGpHeader.Length - 1;

            //StringBuilder strXmlGpHeader = new StringBuilder();
            //strXmlGpHeader.Append(@"<?xml version=""1.0"" ?>");
            //strXmlGpHeader.Append(@"<GP_HEADER_ROOT>");

            //for (int intLocRowCtr = 0; intLocRowCtr <= recCount; intLocRowCtr++)
            //{
            //    if (!string.IsNullOrEmpty(Convert.ToString(strArrayGpHeader[intLocRowCtr])))
            //    {
            //        string[] LocArr = strArrayGpHeader[intLocRowCtr].Split('#');

            //        strXmlGpHeader.Append(@"<GP_HEADER_DETAILS>");

            //        strXmlGpHeader.Append(@"<level>" + LocArr[0] + "</level>");
            //        strXmlGpHeader.Append(@"<Userid>" + LocArr[1] + "</Userid>");

            //        strXmlGpHeader.Append(@"</GP_HEADER_DETAILS>");
            //    }
            //}
            //strXmlGpHeader.Append(@"</GP_HEADER_ROOT>");


            //DataTable dtHeader = new DataTable();
            //dtHeader = JsonStringToDataTable(GpHeaderData);

            //DataTable dt = JsonConvert.DeserializeObject<DataTable>(GpHeaderData);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void ddlGatePassTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsConfig = new DataSet();
            int ConfigTitleID = 0;

            try
            {
                //lblRequestDate.Text = DateTime.Now.ToString("dd/MMM/yyyy hh:mm tt");

                ConfigTitleID = Convert.ToInt32(ddlGatePassTitle.SelectedValue);
                dsConfig = ObjUpkeep.Bind_GatePassRequestDetails(ConfigTitleID, LoggedInUserID);

                if (dsConfig.Tables.Count > 1)
                {
                    if (Convert.ToInt32(dsConfig.Tables[0].Rows[0]["Link_Dept"]) == 0)
                    {
                        //ddlDepartment.SelectedValue = "0";
                        //ddlDepartment.Attributes.Add("class", "form-control m-input disabled");
                        //ddlDepartment.Attributes.Add("disabled", "disabled");
                        ddlDepartment.Attributes.Add("class", "form-control m-input");
                        ddlDepartment.Enabled = false;
                    }
                    else
                    {
                        ddlDepartment.Enabled = true;
                        //ddlDepartment.Attributes.Add("Enabled", "True");
                        //ddlDepartment.Attributes.Add("class", "form-control m-input");
                        //dvDepartment.Attributes.Add("style", "display:block;");
                        //dvDepartment.Attributes.Add("class", "col-xl-3 col-lg-3");
                    }

                    lblGatepassDescription.Text= Convert.ToString(dsConfig.Tables[0].Rows[0]["Gatepass_Description"]);

                    string strUserType = Convert.ToString(dsConfig.Tables[1].Rows[0]["UserType"]);
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

                    if (dsConfig.Tables.Count > 0)
                    {
                        if (dsConfig.Tables[1].Rows.Count > 0)
                        {
                            if (strUserType == "E")
                            {
                                lblEmpName.Text = Convert.ToString(dsConfig.Tables[1].Rows[0]["Name"]);
                                lblEmpCode.Text = Convert.ToString(dsConfig.Tables[1].Rows[0]["Code"]);
                                lblMobileNo.Text = Convert.ToString(dsConfig.Tables[1].Rows[0]["Mobile"]);
                                LblEmailID.Text = Convert.ToString(dsConfig.Tables[1].Rows[0]["Email"]);
                            }
                            else
                            {
                                lblStoreName.Text = Convert.ToString(dsConfig.Tables[1].Rows[0]["Retail_Store_Name"]);
                                lblRetailerName.Text = Convert.ToString(dsConfig.Tables[1].Rows[0]["Store_Mger_Name"]);
                                lblMobileNo.Text = Convert.ToString(dsConfig.Tables[1].Rows[0]["Contact"]);
                                LblEmailID.Text = Convert.ToString(dsConfig.Tables[1].Rows[0]["Email"]);
                            }


                        }
                    }
                }



                if (dsConfig.Tables.Count > 1)
                {
                    if (dsConfig.Tables[2].Rows.Count > 0)
                    {
                        ddlDepartment.DataSource = dsConfig.Tables[2];
                        ddlDepartment.DataTextField = "DepartmentName";
                        ddlDepartment.DataValueField = "DepartmentId";
                        ddlDepartment.DataBind();
                        ddlDepartment.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }

                GenerateTableHeader(ConfigTitleID);

                if (dsConfig.Tables.Count > 3)
                {
                    if (dsConfig.Tables[4].Rows.Count > 0)
                    {
                        ddlGatePassType.DataSource = dsConfig.Tables[4];
                        ddlGatePassType.DataTextField = "GP_Type_Desc";
                        ddlGatePassType.DataValueField = "GP_Type_ID";
                        ddlGatePassType.DataBind();
                        ddlGatePassType.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }

                if (dsConfig.Tables.Count > 4)
                {
                    if (dsConfig.Tables[5].Rows.Count > 0)
                    {
                        rptTermsCondition.DataSource = dsConfig.Tables[5];
                        rptTermsCondition.DataBind();
                    }
                }

                if (dsConfig.Tables.Count > 5)
                {
                    if (dsConfig.Tables[6].Rows.Count > 0)
                    {
                        gvApprovalMatrix.DataSource = dsConfig.Tables[6];
                        gvApprovalMatrix.DataBind();
                    }
                }




            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //public DataTable JsonStringToDataTable(string jsonString)
        //{
        //    DataTable dt = new DataTable();
        //    string[] jsonStringArray = Regex.Split(jsonString.Replace("[", "").Replace("]", ""), "},{");
        //    List<string> ColumnsName = new List<string>();
        //    foreach (string jSA in jsonStringArray)
        //    {
        //        string[] jsonStringData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
        //        foreach (string ColumnsNameData in jsonStringData)
        //        {
        //            try
        //            {
        //                int idx = ColumnsNameData.IndexOf(":");
        //                string ColumnsNameString = ColumnsNameData.Substring(0, idx - 1).Replace("\"", "");
        //                if (!ColumnsName.Contains(ColumnsNameString))
        //                {
        //                    ColumnsName.Add(ColumnsNameString);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //                //throw new Exception(string.Format("Error Parsing Column Name : {0}", ColumnsNameData));
        //            }
        //        }
        //        break;
        //    }
        //    foreach (string AddColumnName in ColumnsName)
        //    {
        //        dt.Columns.Add(AddColumnName);
        //    }
        //    foreach (string jSA in jsonStringArray)
        //    {
        //        string[] RowData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
        //        DataRow nr = dt.NewRow();
        //        foreach (string rowData in RowData)
        //        {
        //            try
        //            {
        //                int idx = rowData.IndexOf(":");
        //                string RowColumns = rowData.Substring(0, idx - 1).Replace("\"", "");
        //                string RowDataString = rowData.Substring(idx + 1).Replace("\"", "");
        //                nr[RowColumns] = RowDataString;
        //            }
        //            catch (Exception ex)
        //            {
        //                continue;
        //                throw ex;
        //            }
        //        }
        //        dt.Rows.Add(nr);
        //    }
        //    return dt;
        //}

        protected void btnSuccessOk_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveClientUrl("~/GatePass/MyGatePass.aspx"), false);
        }
    }
}