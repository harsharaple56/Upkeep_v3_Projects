using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Cocktail_World.Setup
{
    public partial class Bill_Book : System.Web.UI.Page
    {
        CocktailWorld_Service.CocktailWorld_Service ObjCocktailWorld = new CocktailWorld_Service.CocktailWorld_Service();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            if (!IsPostBack)
            {
                int Bill_Book_ID = Convert.ToInt32(Request.QueryString["Bill_Book_ID"]);
                if (Bill_Book_ID > 0)
                {
                    Bind_BillBook(Bill_Book_ID);
                }
                int DelBill_Book_ID = Convert.ToInt32(Request.QueryString["DelBill_Book_ID"]);
                if (DelBill_Book_ID > 0)
                {
                    Delete_BillBook(DelBill_Book_ID);
                }
            }
        }

        public void Delete_BillBook(int Bill_Book_ID)
        {
            try
            {
                DataSet dsDelBillBook = new DataSet();
                dsDelBillBook = ObjCocktailWorld.BillBook_Crud(Bill_Book_ID,string.Empty,string.Empty, string.Empty,"D",LoggedInUserID,CompanyID);
                if (dsDelBillBook.Tables[0].Rows.Count > 0)
                {
                    Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Bill_Book.aspx"), false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Bind_BillBook(int Bill_Book_ID)
        {
            try
            {
                ds = ObjCocktailWorld.BillBook_Crud(Bill_Book_ID, string.Empty, string.Empty, string.Empty, "R", LoggedInUserID, CompanyID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtLicenseName.Text = Convert.ToString(ds.Tables[0].Rows[0]["License_Name"]);
                        txtLicenseNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["License_No"]);
                        txtStartNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["Bill_Start_No"]);
                        txtEndNumber.Text = Convert.ToString(ds.Tables[0].Rows[0]["Bill_End_No"]);
                        mpeCategoryMaster.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCloseCategory_Click(object sender, EventArgs e)
        {
            Closecontrol();
        }

        public void Closecontrol()
        {
            txtLicenseNo.Text = "";
            txtStartNumber.Text = "";
            txtEndNumber.Text = "";
            lblCategoryErrorMsg.Text = "";
            mpeCategoryMaster.Hide();
            Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Bill_Book.aspx"), false);
        }

        protected void btnCategorySave_Click(object sender, EventArgs e)
        {
            int Bill_Book_ID = 0;
            string LicenseNo = string.Empty;
            string StartNumber = string.Empty;
            string EndNumber = string.Empty;

            try
            {
                if (Convert.ToString(Request.QueryString["Bill_Book_ID"]) != "")
                {
                    Bill_Book_ID = Convert.ToInt32(Request.QueryString["Bill_Book_ID"]);
                }

                string Action = "";

                if (Bill_Book_ID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                LicenseNo = txtLicenseNo.Text.Trim();
                StartNumber = txtStartNumber.Text.Trim();
                EndNumber = txtEndNumber.Text.Trim();

                ds = ObjCocktailWorld.BillBook_Crud(Bill_Book_ID,StartNumber,EndNumber, LicenseNo, Action, LoggedInUserID, CompanyID);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            txtLicenseNo.Text = "";
                            txtStartNumber.Text = "";
                            txtEndNumber.Text = "";
                            mpeCategoryMaster.Hide();
                            Response.Redirect(Page.ResolveClientUrl("~/Cocktail_World/Setup/Bill_Book.aspx"), false);
                        }
                        else if (Status == 3)
                        {
                            lblCategoryErrorMsg.Text = "Bill Book already exists";
                        }
                        else if (Status == 2)
                        {
                            lblCategoryErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public string bindgrid()
        {
            string data = "";
            try
            {
                ds = ObjCocktailWorld.BillBook_Crud(0,string.Empty,string.Empty,string.Empty,"R", LoggedInUserID, CompanyID);


                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Bill_Book_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Bill_Book_ID"]);
                            string License_Name = Convert.ToString(ds.Tables[0].Rows[i]["License_Name"]);
                            string License_No = Convert.ToString(ds.Tables[0].Rows[i]["License_No"]);
                            string Bill_Start_No = Convert.ToString(ds.Tables[0].Rows[i]["Bill_Start_No"]);
                            string Bill_End_No = Convert.ToString(ds.Tables[0].Rows[i]["Bill_End_No"]);

                            data += "<tr><td>" + License_Name + "</td><td>" + License_No + "</td><td>" + Bill_Start_No + "</td><td>" + Bill_End_No + "</td>" +
                                "<td><a href='Bill_Book.aspx?Bill_Book_ID=" + Bill_Book_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a> </td></tr>";

                        }
                    }
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