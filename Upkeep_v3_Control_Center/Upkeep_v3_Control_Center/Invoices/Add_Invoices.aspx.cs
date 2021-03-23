using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Intersoft.Crosslight.RestClient;
using Newtonsoft.Json;

namespace Upkeep_v3_Control_Center.Invoices
{
    public partial class Add_Invoices : System.Web.UI.Page
    {

        UpkeepControlCenter_Service.UpkeepControlCenter_Service objUpkeepCC = new UpkeepControlCenter_Service.UpkeepControlCenter_Service();
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);

            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            if (!IsPostBack)
            {
                bindCompanyDesc();

                int Invoice_ID_Update = Convert.ToInt32(Request.QueryString["Invoice_ID_Update"]);
                int Invoice_ID_Delete = Convert.ToInt32(Request.QueryString["Invoice_ID_Delete"]);

                if (Invoice_ID_Update > 0)
                {
                    Session["Invoice_ID_Update"] = Convert.ToString(Invoice_ID_Update);
                    //bindInvoice_Master(InvoiceID);
                    bind_Invoice_Details(Invoice_ID_Update);
                }
                if (Invoice_ID_Delete > 0)
                {
                    DeleteInvoice_Details(Invoice_ID_Delete);
                    Response.Redirect(Page.ResolveClientUrl("~/Invoices/Invoices_Listing.aspx"), false);

                }
            }

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               
                int InvoiceID = 0;
                if (Convert.ToString(Session["InvoiceID"]) != "")
                {
                    InvoiceID = Convert.ToInt32(Session["InvoiceID"]);
                }
                string Action = "";
                DataSet ds = new DataSet();

                if (InvoiceID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                
                string Invoice_No = string.Empty;
                string Invoice_Desc = string.Empty;
                string Invoice_Amount = string.Empty;
                string Invoice_GST = string.Empty;
                string GST_Type = string.Empty;
                int Company_ID = 0;
                string GSTIN = string.Empty;
                string Nature_of_Invoice = string.Empty;
                string Invoice_File_Path = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadURL"]);
                string Due_Date = string.Empty;
                string Billing_Name = string.Empty;
                string ConString = string.Empty;
                string Invoice_Date = string.Empty;


                Invoice_No = txt_Invoice_No.Text.Trim();
                Invoice_Desc = txt_Invoice_Desc.Text.Trim();
                Invoice_Amount = txt_Invoice_Amount.Text.Trim();
                Invoice_GST = Convert.ToString((Convert.ToDecimal(Invoice_Amount)*18)/ 100);
                GST_Type = Convert.ToString(ddl_GST_Type.SelectedValue);
                //Invoice_CGST = lbl_Invoice_CGST.Text.Trim();
                //Invoice_SGST = lbl_Invoice_SGST.Text.Trim();
                Company_ID = Convert.ToInt32(ddl_Company_Desc.SelectedValue);
                GSTIN = Txt_GSTIN.Text.Trim();
                Nature_of_Invoice = Convert.ToString(ddl_Nature_of_Invoice.SelectedValue);
                Billing_Name = txt_Billing_Name.Text.Trim();
                //Invoice_File_Path = fileUpload_Invoice.Text.Trim();
                Due_Date = txt_Invoice_Due_Date.Text.Trim();
                Invoice_Date = txt_Invoice_Date.Text.Trim();


                string Invoice_FilePath = string.Empty;
                string imgPath = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadURL"]);

                //string Activation_Date = Convert.ToString(ds.Tables[0].Rows[0]["Invoice_Due_Date"]);

             

                if (fileUpload_Invoice.HasFile)
                {
                    string fileUploadInvoice = string.Empty;

                    string fileUploadPath_Invoice = HttpContext.Current.Server.MapPath("~/Invoices/Uploads/");

                    if (!Directory.Exists(fileUploadPath_Invoice))
                    {
                        Directory.CreateDirectory(fileUploadPath_Invoice);
                    }

                    string fileExtension = Path.GetExtension(fileUpload_Invoice.FileName);
                   string Invoice_FileName = Invoice_No + fileExtension;

                    string Invoice_SaveLocation = Server.MapPath("~/Invoices/Uploads/") + Invoice_FileName;
                    Invoice_FilePath = imgPath + "/Invoices/Uploads/" + Invoice_FileName;

                    fileUpload_Invoice.PostedFile.SaveAs(Invoice_SaveLocation);

                   
                    //CompanyLogoName = CompanyCode + ".PNG";
                }
                else
                {
                    Invoice_FilePath = "";
                }

                //ConString = "";

                ds = objUpkeepCC.Invoices_CRUD(0, Invoice_No, Invoice_Desc, Invoice_Amount, Invoice_GST, GST_Type, Invoice_Date,"Pending", "", Company_ID,"","", Nature_of_Invoice, Billing_Name,Due_Date, GSTIN, Invoice_FilePath, LoggedInUserID, Action);


                Session["InvoiceID"] = "";
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 0)
                        {

                        }
                        else if (Status == 1)
                        {
                            Response.Redirect(Page.ResolveClientUrl("~/Invoices/Invoices_Listing.aspx"), false);
                            //Response.Redirect("~/Masters/Company_Mst.aspx", false);
                        }
                        else if (Status == 3)
                        {
                            lblErrorMsg.Text = "Invoice No. already exists";
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




        public void DeleteInvoice_Details(int Invoice_ID_Delete)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objUpkeepCC.Invoices_CRUD(Invoice_ID_Delete, "", "", "", "", "", "", "", "", 0, "", "", "", "", "", "", "",LoggedInUserID, "D");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Redirect("~/Invoices_Listing.aspx", false);
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
        }


        protected void Invoice_Due_Date_TextChanged(object sender, EventArgs e)
        {
            //FetchLicenseExpiryDate(Convert.ToInt32(ddlSubscription.SelectedValue), ActivationDate.Text.Trim());
        }

        protected void Invoice_Date_TextChanged(object sender, EventArgs e)
        {
            //FetchLicenseExpiryDate(Convert.ToInt32(ddlSubscription.SelectedValue), ActivationDate.Text.Trim());
        }



        public void bindCompanyDesc()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objUpkeepCC.Fetch_CompanyDesc();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddl_Company_Desc.DataSource = ds.Tables[0];
                        ddl_Company_Desc.DataTextField = "Company_Desc";
                        ddl_Company_Desc.DataValueField = "Company_ID";
                        ddl_Company_Desc.DataBind();
                        ddl_Company_Desc.Items.Insert(0, new ListItem("--Select--", "0"));
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }





        public void bind_Invoice_Details(int Invoice_ID_Update)
        {
            try
            {
                DataSet ds = new DataSet();

                ds = objUpkeepCC.Invoices_CRUD(Invoice_ID_Update, "", "", "", "", "", "", "", "", 0, "", "", "", "", "", "", "", "", "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //txt_Invoice_No = Convert.ToString(ds.Tables[0].Rows[0]["Invoice_No"]);
                        //txt_Invoice_Desc = Convert.ToString(ds.Tables[0].Rows[0]["Invoice_Desc"]);
                        //txt_Invoice_Date = Convert.ToString(ds.Tables[0].Rows[0]["Invoice_Date"]);
                        //txt_Invoice_Due_Date = Convert.ToString(ds.Tables[0].Rows[0]["Invoice_Due_Date"]);
                        //txt_Invoice_Amount = Convert.ToString(ds.Tables[0].Rows[0]["Invoice_Amount"]);
                        //lbl_Invoice_GST = Convert.ToString(ds.Tables[0].Rows[0]["Invoice_GST"]);
                        //ddl_GST_Type = Convert.ToString(ds.Tables[0].Rows[0]["GST_Type"]);
                        //ddl_Nature_of_Invoice = Convert.ToString(ds.Tables[0].Rows[0]["Nature_of_Invoice"]);
                        //ddl_Company_Desc = Convert.ToString(ds.Tables[0].Rows[0]["Company_Desc"]);
                        //txt_Billing_Name = Convert.ToString(ds.Tables[0].Rows[0]["Billing_Name"]);
                        //Txt_GSTIN = Convert.ToString(ds.Tables[0].Rows[0]["GSTIN"]);
                        
                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        

        public static string GetJSONResponse(string sURL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
            request.MaximumAutomaticRedirections = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            request.ContentType = "application/json; charset=utf-8";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream receiveStream = response.GetResponseStream(
                );
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string sResponse = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                return sResponse;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

    }
}