using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.CSM
{
    public partial class Create_CSM_Request_Public : System.Web.UI.Page
    {
        #region Golbal Variables
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        string SessionVisitor = string.Empty;
        int ConfigID = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            string strConfigID = string.Empty;
            string strRequestID = string.Empty;

            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            SessionVisitor = Convert.ToString(Session["Visitor"]);

            if (!IsPostBack)
            {
                if ((string.IsNullOrEmpty(LoggedInUserID) && !string.IsNullOrEmpty(SessionVisitor)) || (string.IsNullOrEmpty(LoggedInUserID) && string.IsNullOrEmpty(SessionVisitor)))
                {
                    if (string.IsNullOrEmpty(LoggedInUserID) && string.IsNullOrEmpty(SessionVisitor))
                        SessionVisitor = Convert.ToString("Visitor");

                    divTitle.Visible = false;
                    if (!System.String.IsNullOrWhiteSpace(Request.QueryString["ConfigID"]))
                    {
                        strConfigID = Request.QueryString["ConfigID"].ToString();
                        if (strConfigID.All(char.IsDigit))
                        {
                            ViewState["ConfigID"] = Convert.ToInt32(strConfigID);
                        }
                        BindCMSConfig();
                    }
                }
                //div_VisitDetails.Visible = false;
            }
        }

        private void BindCMSConfig()
        {
            try
            {
                ConfigID = Convert.ToInt32(ViewState["ConfigID"]);
                DataSet dsConfig = new DataSet();
                dsConfig = ObjUpkeep.Bind_CSMConfiguration(ConfigID);

                if (!System.String.IsNullOrWhiteSpace(dsConfig.Tables[0].Rows[0]["Config_Desc"].ToString()))
                {
                    lbl_Form_Name.Text = Convert.ToString(dsConfig.Tables[0].Rows[0]["Config_Desc"]);
                    divDesc.Visible = true;
                    SpanDesc.InnerText = dsConfig.Tables[0].Rows[0]["Config_Detailed_Desc"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveCSMData();
        }

        private void SaveCSMData()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
