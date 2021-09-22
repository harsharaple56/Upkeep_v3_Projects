using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace Upkeep_v3.Laundry_Management.Stock_Setup
{
    public partial class Item_Categorization : System.Web.UI.Page
    {

        #region Global variables

        DataSet ds = new DataSet();
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        static string CategoryName = string.Empty;
        static string SubCatName = string.Empty;

        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(hdnTxtSubCategory.Text))
            {
                Session["hdnSubCategory"] = hdnTxtSubCategory.Text;
            }
            if (!string.IsNullOrEmpty(hdnTxtCategory.Text))
            {
                lblCategoryName.Text = hdnTxtCategory.Text;
                Session["CategoryName"] = hdnTxtCategory.Text;
            }
            if (!string.IsNullOrEmpty(Convert.ToString(Session["CategoryName"])))
            {
                lblCategoryName.Text = Convert.ToString(Session["CategoryName"]);
            }

            string ncn = Convert.ToString(hdnCategory.Value);
            if (!IsPostBack)
            {
                if (Session["hdnEditTableClicked"] != null)
                { hdnEditTableClicked.Value = Session["hdnEditTableClicked"].ToString(); }
                if (Session["hdnEditClickedID"] != null)
                { hdnEditClickedID.Value = Session["hdnEditClickedID"].ToString(); }

                if (hdnEditClickedID.Value != "")
                {
                    int IDx = Convert.ToInt32(hdnEditClickedID.Value);
                    if (hdnEditTableClicked.Value == "tblCategory")
                    {
                        FetchCategory(IDx);
                    }
                    else if (hdnEditTableClicked.Value == "tblLocation")
                    {
                        FetchSubCategory(IDx);
                    }

                    if (Session["hdnEditTableClicked"] != null)
                    { Session["hdnEditTableClicked"] = ""; }
                    if (Session["hdnEditClickedID"] != null)
                    { Session["hdnEditClickedID"] = ""; }
                }
                hdnEditTableClicked.Value = "";
                hdnEditClickedID.Value = "";

                string DeleteTable = "";
                int DeleteID = 0;
                int CategoryID = Convert.ToInt32(Request.QueryString["delcategory_id"]);
                int SubCategoryID = Convert.ToInt32(Request.QueryString["delsubcategory_id"]);
                int ItemID = Convert.ToInt32(Request.QueryString["delitem_id"]);

                if (CategoryID > 0)
                {
                    DeleteID = CategoryID;
                }
                else if (SubCategoryID > 0)
                {
                    DeleteID = SubCategoryID;
                }
                else if (ItemID > 0)
                {
                    DeleteID = ItemID;
                }


                if (DeleteID > 0)
                {
                    int IDx = Convert.ToInt32(DeleteID);
                    if (CategoryID > 0)
                    {
                        DeleteTable = "tblCategory";
                    }
                    else if (SubCategoryID > 0)
                    {
                        DeleteTable = "tblLocation";
                    }
                    else if (ItemID > 0)
                    {
                        DeleteTable = "tblLItems";
                    }

                    DeleteData(DeleteTable, IDx);
                }
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            //txtCategoryCode.Text = "";
            txtCategoryDesc.Text = "";
            mpeCategory.Hide();
        }

        protected void btnCategorySave_Click(object sender, EventArgs e)
        {
            int CategoryID = 0;
            string Category_Desc = txtCategoryDesc.Text.Trim();

            try
            {
                if (Convert.ToString(Session["CategoryID"]) != "")
                {
                    CategoryID = Convert.ToInt32(Session["CategoryID"]);
                }
                string Action = "";

                if (CategoryID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                ds = ObjUpkeep.LMS_Category_Mst(CategoryID, Category_Desc, Convert.ToInt32(Session["CompanyID"]), Convert.ToString(Session["LoggedInUserID"]), Action);

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
                            Session["CategoryID"] = "";
                            txtCategoryDesc.Text = "";
                            CategoryName = txtCategoryDesc.Text.Trim();
                            mpeCategory.Hide();
                            Response.Redirect("~/Laundry_Management/Stock_Setup/Item_Categorization.aspx", false);
                        }
                        else if (Status == 3)
                        {
                            lblCategoryErrorMsg.Text = "Category already exists";
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

        protected void btnSubCategorySave_Click(object sender, EventArgs e)
        {
            int SubCategoryID = 0;
            string Category = "";
            string SubCategoryDesc = txtSubCategory.Text.Trim();

            if (Convert.ToString(Session["Category"]) != "")
            {
                Category = Convert.ToString(Session["Category"]);
            }
            else if (CategoryName != "")
            {
                Category = CategoryName;
            }

            try
            {
                if (Convert.ToString(Session["SubCategoryID"]) != "")
                {
                    SubCategoryID = Convert.ToInt32(Session["SubCategoryID"]);
                }
                string Action = "";

                if (SubCategoryID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                if (Category != "")
                {
                    ds = ObjUpkeep.LMS_SubCategory_Mst(SubCategoryID, SubCategoryDesc, Category, Convert.ToInt32(Session["CompanyID"]), Convert.ToString(Session["LoggedInUserID"]), Action);

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
                                Session["SubCategoryID"] = "";
                                txtSubCategory.Text = "";
                                mpeSubCategory.Hide();
                                Response.Redirect("~/Laundry_Management/Stock_Setup/Item_Categorization.aspx", false);
                            }
                            else if (Status == 3)
                            {
                                lblSubCategoryErrorMsg.Text = "SubCategory already exists";
                            }
                            else if (Status == 2)
                            {
                                lblSubCategoryErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                            }
                        }
                    }
                }
                else
                {
                    lblSubCategoryErrorMsg.Text = "Please select Category.";
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCloseSubCategory_Click(object sender, EventArgs e)
        {
            txtSubCategory.Text = "";
            //txtSubCategoryCode.Text = "";
            mpeSubCategory.Hide();
        }

        protected void btnAddLocation_Click(object sender, EventArgs e)
        {
            txtSubCategory.Text = "";

        }

        #endregion

        #region Functions
        public void DeleteData(string Table, int ID)
        {
            try
            {
                DataSet dst = new DataSet();
                string Action = "D";
                if (Table == "tblCategory")
                {
                    dst = ObjUpkeep.LMS_Category_Mst(ID, string.Empty, Convert.ToInt32(Session["CompanyID"]), Convert.ToString(Session["LoggedInUserID"]), Action);
                }
                else if (Table == "tblLocation")
                {
                    dst = ObjUpkeep.LMS_SubCategory_Mst(ID, string.Empty, string.Empty, Convert.ToInt32(Session["CompanyID"]), Convert.ToString(Session["LoggedInUserID"]), Action);
                }

                if (dst.Tables.Count > 0)
                {
                    if (dst.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(dst.Tables[0].Rows[0]["Status"]);
                        if (Status == 0)
                        {

                        }
                        else if (Status == 1)
                        {
                            Response.Redirect("~/Laundry_Management/Stock_Setup/Item_Categorization.aspx", false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void FetchCategory(int CategoryID)
        {
            try
            {
                ds = ObjUpkeep.LMS_Category_Mst(CategoryID, string.Empty, Convert.ToInt32(Session["CompanyID"]), Convert.ToString(Session["LoggedInUserID"]), "F");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["CategoryID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Category_ID"]);
                        txtCategoryDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["Category_Desc"].ToString());
                        mpeCategory.Show();
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

        public void FetchSubCategory(int SubCategoryID)
        {
            try
            {
                ds = ObjUpkeep.Crud_Inv_SubCategory_Mst(Convert.ToString(Session["LoggedInUserID"]), Convert.ToString(Session["CompanyID"]), "",
                    SubCategoryID, "", "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["SubCategoryID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["SubCategory_ID"]);
                        txtSubCategory.Text = Convert.ToString(ds.Tables[0].Rows[0]["SubCategory_Desc"]);

                        mpeSubCategory.Show();
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

        public string Category_bindgrid()
        {
            string data = "";
            string URL = "";
            URL = Page.ResolveClientUrl("~/Laundry_Management/Stock_Setup/Item_Categorization.aspx");

            string LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            string CompanyID = Convert.ToString(Session["CompanyID"]);


            try
            {
                ds = ObjUpkeep.LMS_Category_Mst(0, string.Empty, Convert.ToInt32(CompanyID), LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int CategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["Category_ID"]);
                            string Category = Convert.ToString(ds.Tables[0].Rows[i]["Category_Desc"]);

                            data += "<tr id ='" + CategoryID + "'><td>" + Category + "</td><td style='float: right;'>" +
                               "<a href='#' data-val='Item_Categorization.aspx?CategoryID=" + CategoryID + "' class='text-success' data-placement='top' title='Edit record'> <i id='btnedit' " +
                               "runat='server' class='fa fa-edit fa-fw'></i> </a>  " +
                               "<a href='Item_Categorization.aspx?DelCategory_ID=" + CategoryID + "' " +
                               "class='text-danger has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> " +
                               "	<i class='fa fa-trash fa-fw'></i> </a><i class='fa fa-caret - right fa - fw invisible'></i> </span> </td></tr>";


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

        public string SubCategory_bindgrid()
        {

            string data = "";
            string Category = "";
            if (Convert.ToString(Session["Category"]) != "")
            {
                Category = Convert.ToString(Session["Category"]);
            }
            else if (CategoryName != "")
            {
                Session["CategoryName"] = CategoryName;
                Category = CategoryName;
            }

            try
            {
                if (Category != "")
                {
                    ds = ObjUpkeep.LMS_SubCategory_Mst(0, string.Empty, Category, Convert.ToInt32(Session["CompanyID"]), Convert.ToString(Session["LoggedInUserID"]), "R");

                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                            for (int i = 0; i < count; i++)
                            {
                                int SubCategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["SubCategory_ID"]);
                                string SubCategory = Convert.ToString(ds.Tables[0].Rows[i]["SubCategory_Desc"]);

                                data += "<tr id ='" + SubCategoryID + "'><td runat='server' id='mySubCategoryTable'>" + SubCategory + " </td><td>" +
                          "<span style='float: right;'><a href='#' data-val='Item_Categorization.aspx?SubCategoryID=" + SubCategoryID + "' class='text-success' data-placement='top' title='Edit record'> " +
                          "<i id='btnedit' runat='server' class='fa fa-edit fa-fw'></i> </a>  " +
                          "<a href='Item_Categorization.aspx?DelSubCategory_ID=" + SubCategoryID + "' class='text-danger has-confirmation' " +
                          "data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	" +
                          "<i class='fa fa-trash fa-fw'></i> </a><i class='fa fa-caret - right fa - fw invisible'></i></span> </td></tr>";
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

        #endregion

        #region WebMethods

        [System.Web.Services.WebMethod]
        //[System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        public static void SubCategory_bindgrid1(string Category)
        {
            CategoryName = Category;
            Item_Categorization obj = new Item_Categorization();
            obj.SubCategory_bindgrid();
        }

        [System.Web.Services.WebMethod]
        public static void SetSeesions(string hdnEditTableClicked, string hdnEditClickedID)
        {
            Item_Categorization obj = new Item_Categorization();
            obj.SetSeesion(hdnEditTableClicked, hdnEditClickedID);
        }

        public void SetSeesion(string hdnEditTableClicked, string hdnEditClickedID)
        {
            Session["hdnEditTableClicked"] = hdnEditTableClicked;
            Session["hdnEditClickedID"] = hdnEditClickedID;
        }

        #endregion

    }
}