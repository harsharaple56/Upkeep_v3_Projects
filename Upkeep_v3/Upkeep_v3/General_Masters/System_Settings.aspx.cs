using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Common;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using QRCoder;
using System.Drawing;
using System.IO;

namespace Upkeep_v3.General_Masters
{
    public partial class System_Settings : System.Web.UI.Page
    {

        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();

        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        int SettingID = 0;

        GridView dgGrid = new GridView();

        protected void Page_Load(object sender, EventArgs e)
        {

            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            SettingID = Convert.ToInt32(Session["Setting_ID"]);

            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect("~/Login.aspx", false);
            }
            if (!IsPostBack)
            {
                // bindGrid();
                DisplayData(CompanyID, LoggedInUserID);
            }

            //string ServerURL = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "") + System.Configuration.ConfigurationManager.AppSettings["VDName"] + "/";
            //string GenerateQR = ServerURL + "Ticketing/Add_MyRequest_Public.aspx?cid=" + EnryptString(Convert.ToString(CompanyID));
            //GenerateQRImage(GenerateQR);

        }

        public void DisplayData(int CompanyID, string LoggedInUserID)
        {

            DataSet dsSetting = new DataSet();
            try
            {
                dsSetting = ObjUpkeep.CRU_System_Setting(0, 0, 0, 0, 0, 0, 0,0,0, CompanyID, LoggedInUserID, "R");

                if (dsSetting.Tables.Count > 0)
                {
                    if (dsSetting.Tables[0].Rows.Count > 0)
                    {
                        int intSettingID = Convert.ToInt32(dsSetting.Tables[0].Rows[0]["Setting_ID"]);
                        Session["Setting_ID"] = Convert.ToString(dsSetting.Tables[0].Rows[0]["Setting_ID"]);
                        //  int intSettingID = Convert.ToInt32(Session["Setting_ID"])
                        int intphotoRaisingCheck = Convert.ToInt32(dsSetting.Tables[0].Rows[0]["Tkt_Is_Img_Open"]);
                        int intPhotoClosingCheck = Convert.ToInt32(dsSetting.Tables[0].Rows[0]["Tkt_Is_Img_Close"]);
                        int intRemarksCompRaising = Convert.ToInt32(dsSetting.Tables[0].Rows[0]["Tkt_Is_Remark_Open"]);
                        int intRemarksCompclosing = Convert.ToInt32(dsSetting.Tables[0].Rows[0]["Tkt_Is_Remark_Close"]);
                        int intTicketExpiry = Convert.ToInt32(dsSetting.Tables[0].Rows[0]["Tkt_Is_Expiry"]);
                        int intChkQRCompulsory = Convert.ToInt32(dsSetting.Tables[0].Rows[0]["Chk_Is_QR_Compulsory"]);

                        int intphotoRaisingCheck_QR = Convert.ToInt32(dsSetting.Tables[0].Rows[0]["Tkt_Is_Img_Open_QR_Public"]);
                        int intRemarksCompRaising_QR = Convert.ToInt32(dsSetting.Tables[0].Rows[0]["Tkt_Is_Remark_Open_QR_Public"]);

                        if (intphotoRaisingCheck == 1)
                        {
                            photoRaisingCheck.Checked = true;
                        }
                        else
                            photoRaisingCheck.Checked = false;

                        if (intPhotoClosingCheck == 1)
                        {
                            PhotoClosingCheck.Checked = true;
                        }
                        else
                            PhotoClosingCheck.Checked = false;


                        if (intRemarksCompRaising == 1)
                        {
                            RemarksCompRaising.Checked = true;
                        }
                        else
                            RemarksCompRaising.Checked = false;


                        if (intRemarksCompclosing == 1)
                        {
                            RemarksCompclosing.Checked = true;
                        }
                        else
                            RemarksCompclosing.Checked = false;


                        if (intTicketExpiry == 1)
                        {
                            TicketExpiry.Checked = true;
                        }
                        else
                            TicketExpiry.Checked = false;

                        if (intChkQRCompulsory == 1)
                        {
                            chk_QR_Compulspory.Checked = true;
                        }
                        else
                            chk_QR_Compulspory.Checked = false;


                        if (intphotoRaisingCheck_QR == 1)
                        {
                            chk_Image_Public_QR.Checked = true;
                        }
                        else
                            chk_Image_Public_QR.Checked = false;

                        if (intRemarksCompRaising_QR == 1)
                        {
                            chk_Remarks_Public_QR.Checked = true;
                        }
                        else
                            chk_Remarks_Public_QR.Checked = false;

                    }
                }
                if (dsSetting.Tables.Count > 1)
                {
                    if (dsSetting.Tables[1].Rows.Count > 0)
                    {
                        string short_url = Convert.ToString(dsSetting.Tables[1].Rows[0]["ShortUrl"]);

                        string ServerURL = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "") + System.Configuration.ConfigurationManager.AppSettings["VDName"] + "/";
                        string GenerateQR = ServerURL + short_url;
                        GenerateQRImage(GenerateQR);

                        btn_Generate_TicketQR.Attributes.Add("style", "display:none;");
                    }
                    else
                    {
                        btn_show_QR.Attributes.Add("style", "display:none;");
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {



            DataSet dsSetting = new DataSet();


            try
            {

                // dsSetting = ObjUpkeep.CRU_System_Setting(0, 0, 0, 0, 0, 0, CompanyID, LoggedInUserID, "R");

                //SettingID = Convert.ToInt32(dsSetting.Tables[0].Rows[0]["Setting_ID"]);
                if (Convert.ToString(Session["Setting_ID"]) != "")
                {
                    SettingID = Convert.ToInt32(Session["Setting_ID"]);
                }
                else
                {
                    SettingID = 0;
                }

                string Action = "";
                DataSet ds = new DataSet();

                if (SettingID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                int intphotoRaisingCheck = 0;
                int intPhotoClosingCheck = 0;
                int intRemarksCompRaising = 0;
                int intRemarksCompclosing = 0;
                int intTicketExpiry = 0;
                int intChkQRCompulsory = 0;

                int intphotoRaisingCheck_QR = 0;
                int intRemarksCompRaising_QR = 0;

                if (photoRaisingCheck.Checked == true)
                {
                    intphotoRaisingCheck = 1;
                    //Approver_ID = txtApprovalId.Text.Trim();
                }
                else
                {
                    intphotoRaisingCheck = 0;

                }

                if (PhotoClosingCheck.Checked == true)
                {
                    intPhotoClosingCheck = 1;
                    //Approver_ID = txtApprovalId.Text.Trim();
                }
                else
                {
                    intPhotoClosingCheck = 0;

                }
                if (RemarksCompRaising.Checked == true)
                {
                    intRemarksCompRaising = 1;
                    //Approver_ID = txtApprovalId.Text.Trim();
                }
                else
                {
                    intRemarksCompRaising = 0;

                }
                if (RemarksCompclosing.Checked == true)
                {
                    intRemarksCompclosing = 1;
                    //Approver_ID = txtApprovalId.Text.Trim();
                }
                else
                {
                    intRemarksCompclosing = 0;

                }

                if (TicketExpiry.Checked == true)
                {
                    intTicketExpiry = 1;
                    //Approver_ID = txtApprovalId.Text.Trim();
                }
                else
                {
                    intTicketExpiry = 0;

                }
                if (chk_QR_Compulspory.Checked == true)
                {
                    intChkQRCompulsory = 1;
                }
                else
                {
                    intChkQRCompulsory = 0;
                }


                if (chk_Image_Public_QR.Checked == true)
                {
                    intphotoRaisingCheck_QR = 1;
                }
                else
                {
                    intphotoRaisingCheck_QR = 0;
                }
                if (chk_Remarks_Public_QR.Checked == true)
                {
                    intRemarksCompRaising_QR = 1;
                }
                else
                {
                    intRemarksCompRaising_QR = 0;
                }


                ds = ObjUpkeep.CRU_System_Setting(SettingID, intphotoRaisingCheck, intPhotoClosingCheck, intRemarksCompRaising, intRemarksCompclosing, intTicketExpiry, intChkQRCompulsory, intphotoRaisingCheck_QR, intRemarksCompRaising_QR, CompanyID, LoggedInUserID, Action);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {


                            Response.Redirect(Page.ResolveClientUrl("~/General_Masters/System_Settings.aspx"), false);
                        }
                        else if (Status == 3)
                        {
                            // lblUserErrorMsg.Text = "";
                        }
                        else if (Status == 2)
                        {
                            lblUserErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                    }



                }
            }


            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string EnryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

        public void GenerateQRImage(string URL)
        {
            string code = URL;
            hdnLink.Value = URL;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            imgBarCode.Height = 300;
            imgBarCode.Width = 300;
            using (Bitmap bitMap = qrCode.GetGraphic(20))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();
                    imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                }
                plBarCode.Controls.Add(imgBarCode);
            }
        }

        protected void btn_Generate_TicketQR_Click(object sender, EventArgs e)
        {
            DataSet ds_TicketQR = new DataSet();
            try
            {
                ds_TicketQR = ObjUpkeep.Insert_System_Setting_Ticket_QR(CompanyID);

                if (ds_TicketQR.Tables.Count > 0)
                {
                    if (ds_TicketQR.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds_TicketQR.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            //DisplayData(CompanyID, LoggedInUserID);
                            Response.Redirect("~/General_Masters/System_Settings.aspx", false);
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