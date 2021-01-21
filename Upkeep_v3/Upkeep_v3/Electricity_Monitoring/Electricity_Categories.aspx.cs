using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Electricity_Monitoring
{
    public partial class Electricity_Categories : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            //frmGatePass.Action = @"GatePass_Configuration.aspx";
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }

            if (!IsPostBack)
            {
                Bind_Electricity_Category();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string CategoryName = string.Empty;
                string IncludeTotalValue = string.Empty;

                StringBuilder strXmlElectricity_Cat = new StringBuilder();
                strXmlElectricity_Cat.Append(@"<?xml version=""1.0"" ?>");
                strXmlElectricity_Cat.Append(@"<EC_ROOT>");

                int ccc = Request.Form.Count;
                for (int i = 0; i < ccc; i++)
                {
                    int IncludeInTotal = 0;
                    string[] CategoryArray = Request.Form.GetValues("Category[" + i + "][ctl00$ContentPlaceHolder1$txtCategory]");
                    if (CategoryArray != null)
                    {
                        CategoryName = CategoryArray[0];
                    }

                    string[] IncludeInTotalArray = Request.Form.GetValues("Category[" + i + "][ctl00$ContentPlaceHolder1$chkIncludeInTotal][]");
                    if (IncludeInTotalArray != null)
                    {
                        IncludeTotalValue = IncludeInTotalArray[0];
                        if (IncludeTotalValue == "on")
                        {
                            IncludeInTotal = 1;
                        }

                    }
                    if (CategoryArray != null)
                    {
                        strXmlElectricity_Cat.Append(@"<EC_DESC>");
                        strXmlElectricity_Cat.Append(@"<CATEGORY>" + CategoryName + "</CATEGORY>");
                        strXmlElectricity_Cat.Append(@"<INCLUDE_IN_TOTAL>" + IncludeInTotal + "</INCLUDE_IN_TOTAL>");
                        strXmlElectricity_Cat.Append(@"</EC_DESC>");
                    }
                }

                strXmlElectricity_Cat.Append(@"</EC_ROOT>");

                string Electricity_CatXML = strXmlElectricity_Cat.ToString();

                DataSet dsElectricity = new DataSet();

                int Electricity_Cat_ID = 0;
                string strAction = string.Empty;

                if (Convert.ToString(Session["IsUpdate"]) == "1")
                {
                    strAction = "U";
                }
                else
                {
                    strAction = "C";
                }

                dsElectricity = ObjUpkeep.INSERT_Electricity_Category(Electricity_CatXML, CompanyID, LoggedInUserID, Electricity_Cat_ID, strAction);

                if (dsElectricity.Tables.Count > 0)
                {
                    if (dsElectricity.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dsElectricity.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            Bind_Electricity_Category();
                            //Response.Redirect(Page.ResolveClientUrl("~/GatePass/GatePassConfig_Listing.aspx"), false);
                        }

                        //else if (Status == 2)
                        //{
                        //    lblErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        //}
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Bind_Electricity_Category()
        {
            DataSet dsElectricity = new DataSet();
            string strAction = string.Empty;
            try
            {
                strAction = "R";

                dsElectricity = ObjUpkeep.INSERT_Electricity_Category("", CompanyID, LoggedInUserID, 0, strAction);

                if (dsElectricity != null)
                {
                    if (dsElectricity.Tables.Count > 0)
                    {
                        if (dsElectricity.Tables[0].Rows.Count > 0)
                        {
                            Session["IsUpdate"] = "1";
                            //btnSave.Text = "Update";
                            hdnElectricity_CatID.Value = Convert.ToString(dsElectricity.Tables[0].Rows[0]["Electric_Cat_ID"]);

                            var CaltegoryValues = dsElectricity.Tables[0].AsEnumerable().Select(s => s.Field<int>("Electric_Cat_ID").ToString() + "||" + s.Field<string>("Cat_Desc") + "||" + s.Field<bool>("IncludeInTotal").ToString()).ToArray();

                            hdnElectricityCategory.Value = string.Join("~", CaltegoryValues);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}