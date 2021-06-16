using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Custom_Integration.PAZO
{
    public partial class Raise_Feedback_Issue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {









        }


        public void Bind_Details()
        {
            try
            {
                ////int studentId = Request.QueryString["StudentId"];
                // string BaseURL = string.Empty;
                // //BaseURL = Convert.ToString(ConfigurationManager.AppSettings["Base_URL"]);

                //// SuccessURL = BaseURL + "Admission/FeePaymentSuccess.aspx?status=0&studentid=" + studentId;

                // //string surl = SuccessURL;
                // Session.Add("surl", surl);

                // Session["surl"] = SuccessURL;

                // Random r = new Random();
                // string txnid = "Txn" + r.Next(100, 9999);
                // Session.Add("txnid", txnid);

                // hdnMerchantKey.Value = Convert.ToString(ConfigurationManager.AppSettings["MERCHANT_KEY"]);
                // hdnMerchantSalt.Value = Convert.ToString(ConfigurationManager.AppSettings["SALT"]);
                // hdnTransactionID.Value = "";
                // hdnAmount.Value = "";
                // hdnProductInfo.Value = Convert.ToString(ConfigurationManager.AppSettings["ProductInfo"]);
                // hdnFirstName.Value = "Faisal"; //Convert.ToString(txtFirstname.Text.Trim());
                // hdnEmailID.Value = ""; //Convert.ToString(txtEmailID.Text.Trim());
                // hdnMobileNo.Value = ""; //Convert.ToString(txtMobileNo.Text.Trim());
                //                                   //hdnHash.Value =
                // Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "generateHash()", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}