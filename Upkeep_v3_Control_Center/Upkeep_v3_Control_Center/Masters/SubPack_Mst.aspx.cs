using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3_Control_Center.Masters
{
    public partial class SubPack_Mst : System.Web.UI.Page
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

                int Pack_ID = Convert.ToInt32(Request.QueryString["PackID"]);
                if (Pack_ID > 0)
                {
                    BindPackage(Pack_ID);
                }
                int DelPack_ID = Convert.ToInt32(Request.QueryString["DelPackID"]);
                if (DelPack_ID > 0)
                {
                     DeletePackage(DelPack_ID);
                }

            }
        }

        public string bind_Package_Grid()
        {
            DataSet ds = new DataSet();
            string data = "";
            try
            {
                ds = objUpkeepCC.Subscription_Package_CRUD(0, "", 0, 0, LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Subs_Pack_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Subs_Pack_ID"]);
                            string Subs_Pack_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Subs_Pack_Desc"]);
                            string No_of_Days = Convert.ToString(ds.Tables[0].Rows[i]["No_of_Days"]);
                            string Price = Convert.ToString(ds.Tables[0].Rows[i]["Price"]);

                            data += "<tr><td>" + Subs_Pack_Desc + "</td><td>" + No_of_Days + "</td><td>" + Price + "</td><td><a href='SubPack_Mst.aspx?PackID=" + Subs_Pack_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  <a href='SubPack_Mst.aspx?DelPackID=" + Subs_Pack_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

                        }
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

        public void BindPackage(int Pack_ID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = objUpkeepCC.Subscription_Package_CRUD(Pack_ID, "", 0, 0, LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["Pack_ID"] = Convert.ToString(ds.Tables[0].Rows[0]["Subs_Pack_ID"]);
                        txtPackage.Text = Convert.ToString(ds.Tables[0].Rows[0]["Subs_Pack_Desc"]);
                        txtNoOfDays.Text = Convert.ToString(ds.Tables[0].Rows[0]["No_of_Days"]);
                        txtPrice.Text = Convert.ToString(ds.Tables[0].Rows[0]["Price"]);
                        mpePackage.Show();
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
        }


        protected void btnClosePackage_Click(object sender, EventArgs e)
        {
            txtPackage.Text = "";
            txtNoOfDays.Text = "";
            txtPrice.Text = "";
            mpePackage.Hide();
        }

        protected void btnSavePackage_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {

                string Pack_Desc = string.Empty;
                int No_Of_Days = 0;
                int Price = 0;

                Pack_Desc = Convert.ToString(txtPackage.Text.Trim());
                No_Of_Days = Convert.ToInt32(txtNoOfDays.Text.Trim());
                Price = Convert.ToInt32(txtPrice.Text.Trim());

                ds = objUpkeepCC.Subscription_Package_CRUD(0, Pack_Desc, No_Of_Days, Price, LoggedInUserID, "C");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            txtPackage.Text = "";
                            txtNoOfDays.Text = "";
                            txtPrice.Text = "";
                            mpePackage.Hide();
                            bind_Package_Grid();
                            Response.Redirect(Page.ResolveClientUrl("~/Masters/SubPack_Mst.aspx"), false);
                        }
                        if (Status == 3)
                        {
                            lblPackageErrorMsg.Text = "Package description already exists.";
                        }
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
        }

        public void DeletePackage(int Pack_ID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = objUpkeepCC.Subscription_Package_CRUD(Pack_ID, "", 0, 0, LoggedInUserID, "D");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            
                            bind_Package_Grid();
                            Response.Redirect(Page.ResolveClientUrl("~/Masters/SubPack_Mst.aspx"), false);
                        }
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
        }
    }
}