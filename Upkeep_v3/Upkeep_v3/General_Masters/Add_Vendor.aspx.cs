using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.General_Masters
{
    public partial class Add_Vendor : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        int CompanyID = 0;   //Added by Sujata
        string LoggedInUserID = string.Empty;
        int Vendor_ID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]); //Added by Sujata
            

            if (LoggedInUserID == "")
            {
                Response.Redirect("~/Login.aspx", false);
            }

            if (!IsPostBack)
            {
                Vendor_ID = Convert.ToInt32(Request.QueryString["Vendor_ID"]);
                if (Vendor_ID > 0)
                {
                    Session["Vendor_ID"] = Convert.ToString(Vendor_ID);
                    bind_Vendor_Data();
                }

                int Vendor_Delete = Convert.ToInt32(Request.QueryString["Del_Vendor_ID"]);

                if (Vendor_Delete > 0)
                {
                    DeleteVendor(Vendor_Delete);
                }

            }



        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

           
            string Action = "";

            Vendor_ID = Convert.ToInt32(Request.QueryString["Vendor_ID"]);

            if (Vendor_ID > 0)
            {
                Action = "U";
            }
            else
            {
                Action = "C";
            }

            string Vendor_Name = Convert.ToString(txtVendorName.Text);
            string Vendor_Desc = Convert.ToString(txtVendorDesc.InnerText);
            string Vendor_Address = Convert.ToString(txtAddress.InnerText);
            string Vendor_Contact1 = Convert.ToString(txtPrimaryContact.Text);
            string Vendor_Contact2 = Convert.ToString(txtAlternateContact.Text);
            string Vendor_Email = Convert.ToString(txtEmail.Text);
            string Vendor_Reg_ID = Convert.ToString(txtVendor_Reg_ID.Text);
            string Vendor_GSTIN = Convert.ToString(txtGSTIN.Text);
            string Vendor_PAN = Convert.ToString(txtPAN.Text);
            string Vendor_Bank_Details = Convert.ToString(txtBankDetails.InnerText);

            try
            {
                ds = ObjUpkeep.Fetch_CRUD_Vendor_Mst(Vendor_ID, Vendor_Name, Vendor_Desc, Vendor_Address, Vendor_Contact1, Vendor_Contact2, Vendor_Email, Vendor_Reg_ID, Vendor_GSTIN, Vendor_PAN, Vendor_Bank_Details, LoggedInUserID, CompanyID, Action);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            Session["Vendor_ID"] = "";
                            Response.Redirect(Page.ResolveClientUrl("~/General_Masters/Vendor_Mst.aspx"), false);
                        }
                        else if (Status == 3)
                        {
                            lblErrorMsg.Text = "Vendor details already exists";
                        }
                        else if (Status == 2)
                        {
                            lblErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
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
        }

        protected void DeleteVendor(int Vendor_Delete)
        {
            try
            {
                ds = ObjUpkeep.Fetch_CRUD_Vendor_Mst(Vendor_Delete, " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", CompanyID, "D");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            Session["Vendor_ID"] = "";
                            Response.Redirect(Page.ResolveClientUrl("~/General_Masters/Vendor_Mst.aspx"), false);
                        }
                        else if (Status == 3)
                        {
                            lblErrorMsg.Text = "Vendor Cant be deleted due to dependency";
                        }
                        else if (Status == 2)
                        {
                            lblErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
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
        }

        public string bind_Vendor_Data()
        {
            string data = "";
            try
            {
                ds = ObjUpkeep.Fetch_CRUD_Vendor_Mst(Vendor_ID, " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", CompanyID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtVendorName.Text = Convert.ToString(ds.Tables[0].Rows[0]["Vendor_Name"]);
                        txtVendor_Reg_ID.Text = Convert.ToString(ds.Tables[0].Rows[0]["Vendor_Reg_ID"]);
                        txtVendorDesc.InnerText = Convert.ToString(ds.Tables[0].Rows[0]["Vendor_Desc"]);
                        txtPrimaryContact.Text = Convert.ToString(ds.Tables[0].Rows[0]["Vendor_Contact1"]);
                        txtAlternateContact.Text = Convert.ToString(ds.Tables[0].Rows[0]["Vendor_Contact2"]);
                        txtEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["Vendor_Email"]);
                        txtAddress.InnerText = Convert.ToString(ds.Tables[0].Rows[0]["Vendor_Address"]);
                        txtGSTIN.Text = Convert.ToString(ds.Tables[0].Rows[0]["Vendor_GSTIN"]);
                        txtPAN.Text = Convert.ToString(ds.Tables[0].Rows[0]["Vendor_PAN"]);
                        txtBankDetails.InnerText = Convert.ToString(ds.Tables[0].Rows[0]["Vendor_Bank_Details"]);

                    }
                    else
                    {

                    }
                }
                else
                {

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