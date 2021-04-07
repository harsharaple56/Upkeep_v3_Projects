using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Laundry_Management.Stock
{
    public partial class Setup : System.Web.UI.Page
    {
        #region Global variables

        //DataSet ds = new DataSet();
        //Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        //static string CategoryName = string.Empty;
        //static string SubCatName = string.Empty;

        //#endregion

        //#region Events
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(hdnTxtSubCategory.Text))
        //    {
        //        lblSubCategory.Text = hdnTxtSubCategory.Text;
        //        Session["hdnSubCategory"] = hdnTxtSubCategory.Text;
        //    }
        //    if (!string.IsNullOrEmpty(Convert.ToString(Session["hdnSubCategory"])))
        //    {
        //        lblSubCategory.Text = Convert.ToString(Session["hdnSubCategory"]);
        //    }

        //    if (!string.IsNullOrEmpty(hdnTxtCategory.Text))
        //    {
        //        lblCategoryName.Text = hdnTxtCategory.Text;
        //        Session["CategoryName"] = hdnTxtCategory.Text;
        //    }
        //    if (!string.IsNullOrEmpty(Convert.ToString(Session["CategoryName"])))
        //    {
        //        lblCategoryName.Text = Convert.ToString(Session["CategoryName"]);
        //    }

        //    string ncn = Convert.ToString(hdnCategory.Value);
        //    //SubCategory_bindgrid();
        //    if (!IsPostBack)
        //    {
        //        if (Session["hdnEditTableClicked"] != null)
        //        { hdnEditTableClicked.Value = Session["hdnEditTableClicked"].ToString(); }
        //        if (Session["hdnEditClickedID"] != null)
        //        { hdnEditClickedID.Value = Session["hdnEditClickedID"].ToString(); }

        //        if (hdnEditClickedID.Value != "")
        //        {
        //            int IDx = Convert.ToInt32(hdnEditClickedID.Value);
        //            if (hdnEditTableClicked.Value == "tblCategory")
        //            {
        //                FetchCategory(IDx);
        //            }
        //            else if (hdnEditTableClicked.Value == "tblLocation")
        //            {
        //                FetchSubCategory(IDx);
        //            }
        //            else if (hdnEditTableClicked.Value == "tblLItems")
        //            {
        //                FetchItem(IDx);
        //            }

        //            if (Session["hdnEditTableClicked"] != null)
        //            { Session["hdnEditTableClicked"] = ""; }
        //            if (Session["hdnEditClickedID"] != null)
        //            { Session["hdnEditClickedID"] = ""; }
        //        }
        //        hdnEditTableClicked.Value = "";
        //        hdnEditClickedID.Value = "";

        //        string DeleteTable = "";
        //        int DeleteID = 0;

        //        //if (Session["DeleteTable"] != null)
        //        //{ DeleteTable = Session["DeleteTable"].ToString(); }
        //        //if (Session["DeleteID"] != null)
        //        //{ DeleteID = Session["DeleteID"].ToString(); }

        //        int CategoryID = Convert.ToInt32(Request.QueryString["delcategory_id"]);
        //        int SubCategoryID = Convert.ToInt32(Request.QueryString["delsubcategory_id"]);
        //        int ItemID = Convert.ToInt32(Request.QueryString["delitem_id"]);

        //        if (CategoryID > 0)
        //        {
        //            DeleteID = CategoryID;
        //        }
        //        else if (SubCategoryID > 0)
        //        {
        //            DeleteID = SubCategoryID;
        //        }
        //        else if (ItemID > 0)
        //        {
        //            DeleteID = ItemID;
        //        }


        //        if (DeleteID > 0)
        //        {
        //            int IDx = Convert.ToInt32(DeleteID);
        //            if (CategoryID > 0)
        //            {
        //                DeleteTable = "tblCategory";
        //            }
        //            else if (SubCategoryID > 0)
        //            {
        //                DeleteTable = "tblLocation";
        //            }
        //            else if (ItemID > 0)
        //            {
        //                DeleteTable = "tblLItems";
        //            }

        //            DeleteData(DeleteTable, IDx);

        //            //if (Session["DeleteTable"] != null)
        //            //{ Session["DeleteTable"] = ""; }
        //            //if (Session["DeleteID"] != null)
        //            //{ Session["DeleteID"] = ""; }
        //        }


        //        //int CategoryID = Convert.ToInt32(Request.QueryString["CategoryID"]);
        //        //int SubCategoryID = Convert.ToInt32(Request.QueryString["SubCategoryID"]);
        //        //int ItemID = Convert.ToInt32(Request.QueryString["ItemID"]);


        //        ////int Del_Frequency_ID = Convert.ToInt32(Request.QueryString["DelFreq_ID"]);

        //        //if (CategoryID > 0)
        //        //{
        //        //    FetchCategory(CategoryID);
        //        //}
        //        //else if (SubCategoryID > 0)
        //        //{
        //        //    FetchSubCategory(SubCategoryID);
        //        //}
        //        //else if (ItemID > 0)
        //        //{
        //        //    FetchItem(ItemID);
        //        //}


        //        ////if (Del_Frequency_ID > 0)
        //        ////{
        //        ////    DeleteFrequency(Del_Frequency_ID);
        //        ////}
        //        BindDropDown();
        //    }
        //}

        //protected void btnClose_Click(object sender, EventArgs e)
        //{
        //    //txtCategoryCode.Text = "";
        //    txtCategoryDesc.Text = "";
        //    mpeCategory.Hide();
        //}

        //protected void btnItemSave_Click(object sender, EventArgs e)
        //{
        //    int ItemID = 0, DeptID = 0,
        //     Opening = 0, Optimum = 0, Reorder = 0, Base = 0, CostRate = 0;

        //    string SubCategory = "";
        //    if (Convert.ToString(lblSubCategory.Text) != "")
        //    {
        //        SubCategory = Convert.ToString(lblSubCategory.Text);
        //    }
        //    //else if (CategoryName != "")
        //    //{
        //    //    SubCategory = CategoryName;
        //    //    //CategoryName = "";
        //    //}

        //    if (ddlDepartment.SelectedValue.All(char.IsDigit))
        //        DeptID = Convert.ToInt32(ddlDepartment.SelectedValue);
        //    if (txtOpening.Text.All(char.IsDigit))
        //        Opening = Convert.ToInt32(txtOpening.Text);
        //    if (txtOptimun.Text.All(char.IsDigit))
        //        Optimum = Convert.ToInt32(txtOptimun.Text);
        //    if (txtReOrder.Text.All(char.IsDigit))
        //        Reorder = Convert.ToInt32(txtReOrder.Text);
        //    if (txtBase.Text.All(char.IsDigit))
        //        Base = Convert.ToInt32(txtBase.Text);
        //    if (txtCostRate.Text.All(char.IsDigit))
        //        CostRate = Convert.ToInt32(txtCostRate.Text);


        //    string CategoryName = Convert.ToString(Session["CategoryName"]);

        //    //Session["Category"] = Category;

        //    try
        //    {
        //        if (Convert.ToString(Session["ItemID"]) != "")
        //        {
        //            ItemID = Convert.ToInt32(Session["ItemID"]);
        //        }
        //        string Action = "";

        //        if (ItemID > 0)
        //        {
        //            Action = "U";
        //        }
        //        else
        //        {
        //            Action = "C";
        //        }

        //        ds = ObjUpkeep.Crud_Inv_Item_Mst(Convert.ToString(Session["LoggedInUserID"]),
        //            Convert.ToString(Session["CompanyID"]), CategoryName, SubCategory, ItemID,
        //            txtItem.Text.Trim(), DeptID, Opening, Optimum, Reorder, Base, CostRate, Action);

        //        if (ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
        //                if (Status == 0)
        //                {

        //                }
        //                else if (Status == 1)
        //                {
        //                    //Session["SubCategoryID"] = "";
        //                    //txtItemCode.Text = "";

        //                    //CategoryName = lblCategoryName.Text;
        //                    //SubCatName = lblSubCategory.Text;
        //                    txtItem.Text = "";
        //                    mpeItem.Hide();
        //                    //Category_bindgrid();
        //                    Response.Redirect("~/Inventory/General_Master.aspx", false);
        //                }
        //                else if (Status == 3)
        //                {
        //                    lblItemErrorMsg.Text = "Sub Location already exists";
        //                }
        //                else if (Status == 2)
        //                {
        //                    lblItemErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
        //                }
        //            }
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //protected void btnCloseItem_Click(object sender, EventArgs e)
        //{
        //    //lblLocation.Text = "";
        //    txtItem.Text = "";
        //    //txtItemCode.Text = "";
        //    lblItemErrorMsg.Text = "";
        //    mpeItem.Hide();
        //}

        //protected void btnCategorySave_Click(object sender, EventArgs e)
        //{
        //    //int Convert.ToInt32(Session["CompanyID"]) = 2;
        //    int CategoryID = 0;

        //    try
        //    {

        //        if (Convert.ToString(Session["CategoryID"]) != "")
        //        {
        //            CategoryID = Convert.ToInt32(Session["CategoryID"]);
        //        }
        //        string Action = "";

        //        if (CategoryID > 0)
        //        {
        //            Action = "U";
        //        }
        //        else
        //        {
        //            Action = "C";
        //        }

        //        ds = ObjUpkeep.Crud_Inv_Category_Mst(Convert.ToString(Session["LoggedInUserID"]), Convert.ToString(Session["CompanyID"]), CategoryID, txtCategoryDesc.Text.Trim(), Action);

        //        if (ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
        //                if (Status == 0)
        //                {

        //                }
        //                else if (Status == 1)
        //                {
        //                    Session["CategoryID"] = "";
        //                    //txtCategoryCode.Text = "";
        //                    CategoryName = txtCategoryDesc.Text;
        //                    txtCategoryDesc.Text = "";
        //                    mpeCategory.Hide();
        //                    //Category_bindgrid();
        //                    Response.Redirect("~/Inventory/General_Master.aspx", false);
        //                }
        //                else if (Status == 3)
        //                {
        //                    lblCategoryErrorMsg.Text = "Category already exists";
        //                }
        //                else if (Status == 2)
        //                {
        //                    lblCategoryErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
        //                }
        //            }
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        //protected void btnSubCategorySave_Click(object sender, EventArgs e)
        //{
        //    int SubCategoryID = 0;


        //    string Category = "";
        //    if (Convert.ToString(Session["Category"]) != "")
        //    {
        //        Category = Convert.ToString(Session["Category"]);
        //    }
        //    else if (CategoryName != "")
        //    {
        //        Category = CategoryName;
        //        //CategoryName = "";
        //    }



        //    //string Category = Convert.ToString(hdnCategory.Value);

        //    Session["Category"] = Category;

        //    try
        //    {
        //        if (Convert.ToString(Session["SubCategoryID"]) != "")
        //        {
        //            SubCategoryID = Convert.ToInt32(Session["SubCategoryID"]);
        //        }
        //        string Action = "";

        //        if (SubCategoryID > 0)
        //        {
        //            Action = "U";
        //        }
        //        else
        //        {
        //            Action = "C";
        //        }

        //        ds = ObjUpkeep.Crud_Inv_SubCategory_Mst(Convert.ToString(Session["LoggedInUserID"]), Convert.ToString(Session["CompanyID"]), Category, SubCategoryID, txtSubCategory.Text.Trim(), Action);

        //        if (ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
        //                if (Status == 0)
        //                {

        //                }
        //                else if (Status == 1)
        //                {
        //                    Session["SubCategoryID"] = "";
        //                    //txtSubCategoryCode.Text = "";
        //                    txtSubCategory.Text = "";
        //                    mpeSubCategory.Hide();
        //                    //Category_bindgrid();
        //                    Response.Redirect("~/Inventory/General_Master.aspx", false);
        //                }
        //                else if (Status == 3)
        //                {
        //                    lblSubCategoryErrorMsg.Text = "SubCategory already exists";
        //                }
        //                else if (Status == 2)
        //                {
        //                    lblSubCategoryErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
        //                }
        //            }
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //protected void btnCloseSubCategory_Click(object sender, EventArgs e)
        //{
        //    txtSubCategory.Text = "";
        //    //txtSubCategoryCode.Text = "";
        //    mpeSubCategory.Hide();
        //}

        //protected void btnAddLocation_Click(object sender, EventArgs e)
        //{
        //    txtSubCategory.Text = "";

        //}

        ////protected void btnoo_Click(object sender, EventArgs e)
        ////{
        ////    if (hdnEditClickedID.Value != "")
        ////    {
        ////        int IDx = Convert.ToInt32(hdnEditClickedID.Value);
        ////        if (hdnEditTableClicked.Value == "tblLocation")
        ////        {
        ////            FetchCategory(IDx);
        ////        }
        ////        else if (hdnEditTableClicked.Value == "tblCategory")
        ////        {
        ////            FetchSubCategory(IDx);
        ////        }
        ////        else if (hdnEditTableClicked.Value == "tblLItems")
        ////        {
        ////            FetchItem(IDx);
        ////        }
        ////    }
        ////    hdnEditTableClicked.Value = "";
        ////    hdnEditClickedID.Value = "";
        ////}

        //#endregion

        //#region Functions
        //public void DeleteData(string Table, int ID)
        //{
        //    try
        //    {
        //        DataSet dst = new DataSet();
        //        string Action = "D";
        //        if (Table == "tblCategory")
        //        {
        //            dst = ObjUpkeep.Crud_Inv_Category_Mst(Convert.ToString(Session["LoggedInUserID"]), Convert.ToString(Session["CompanyID"]), ID, "", Action);
        //        }
        //        else if (Table == "tblLocation")
        //        {
        //            dst = ObjUpkeep.Crud_Inv_SubCategory_Mst(Convert.ToString(Session["LoggedInUserID"]), Convert.ToString(Session["CompanyID"]), "", ID, "", Action);
        //        }
        //        else if (Table == "tblLItems")
        //        {
        //            dst = ObjUpkeep.Crud_Inv_Item_Mst(Convert.ToString(Session["LoggedInUserID"]), Convert.ToString(Session["CompanyID"]), "", "", ID,
        //           "", 0, 0, 0, 0, 0, 0, Action);
        //        }
        //        if (dst.Tables.Count > 0)
        //        {
        //            if (dst.Tables[0].Rows.Count > 0)
        //            {
        //                int Status = Convert.ToInt32(dst.Tables[0].Rows[0]["Status"]);
        //                if (Status == 0)
        //                {

        //                }
        //                else if (Status == 1)
        //                {
        //                    Response.Redirect("~/Inventory/General_Master.aspx", false);
        //                }
        //                else if (Status == 2)
        //                {
        //                    lblItemErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
        //                }
        //                else if (Status == 3)
        //                {
        //                    lblItemErrorMsg.Text = "Sub Location already exists";
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        //public void FetchCategory(int CategoryID)
        //{
        //    try
        //    {
        //        ds = ObjUpkeep.Crud_Inv_Category_Mst(Convert.ToString(Session["LoggedInUserID"]), Convert.ToString(Session["CompanyID"]), CategoryID, "", "R");

        //        if (ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {

        //                Session["CategoryID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Category_ID"]);
        //                //txtCategoryCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["Category_Code"]);
        //                txtCategoryDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["Category_Desc"].ToString());

        //                mpeCategory.Show();
        //            }
        //            else
        //            {

        //            }
        //        }
        //        else
        //        {

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void FetchSubCategory(int SubCategoryID)
        //{
        //    try
        //    {
        //        //ds = ObjUpkeep.CategoryMaster_CRUD(CategoryID, 0, "", "", Convert.ToString(Session["LoggedInUserID"]), "R");
        //        ds = ObjUpkeep.Crud_Inv_SubCategory_Mst(Convert.ToString(Session["LoggedInUserID"]), Convert.ToString(Session["CompanyID"]), "",
        //            SubCategoryID, "", "R");

        //        if (ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                Session["SubCategoryID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["SubCategory_ID"]);
        //                //txtSubCategoryCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["SubCategory_Code"]);
        //                txtSubCategory.Text = Convert.ToString(ds.Tables[0].Rows[0]["SubCategory_Desc"]);

        //                mpeSubCategory.Show();
        //            }
        //            else
        //            {

        //            }
        //        }
        //        else
        //        {

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public void FetchItem(int ItemID)
        //{
        //    try
        //    {
        //        //ds = ObjUpkeep.LocationMaster_CRUD(LocID, "", "", "", Convert.ToString(Session["LoggedInUserID"]), "R");
        //        ds = ObjUpkeep.Crud_Inv_Item_Mst(Convert.ToString(Session["LoggedInUserID"]), Convert.ToString(Session["CompanyID"]), "", "",
        //            ItemID, "", 0, 0, 0, 0, 0, 0, "R");

        //        if (ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                Session["SubCategoryID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["SubCategory_ID"]);
        //                //txtItemCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["Item_Code"]);
        //                txtItem.Text = Convert.ToString(ds.Tables[0].Rows[0]["Item_Desc"]);

        //                mpeItem.Show();
        //            }
        //            else
        //            {

        //            }
        //        }
        //        else
        //        {

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public string Category_bindgrid()
        //{
        //    string data = "";
        //    string URL = "";
        //    URL = Page.ResolveClientUrl("~/Inventory/General_Master.aspx");
        //    try
        //    {
        //        ds = ObjUpkeep.Crud_Inv_Category_Mst(Convert.ToString(Session["LoggedInUserID"]), Convert.ToString(Session["CompanyID"]), 0, "", "R");

        //        if (ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {
        //                int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

        //                for (int i = 0; i < count; i++)
        //                {
        //                    int CategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["Category_ID"]);
        //                    string Category = Convert.ToString(ds.Tables[0].Rows[i]["Category"]);

        //                    //data += "<tr id ='" + CategoryID + "'><td>" + Category + "</td><td style='float: right;'><a href='General_Master.aspx?CategoryID=" + CategoryID + "' class='text-success' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='fa fa-edit fa-fw'></i> </a>  <a href='Inventory/General_Master.aspx?DelCategory_ID=" + CategoryID + "' class='text-danger' data-container='body' data-toggle='confirmation' data-placement='top' title='Delete record'> 	<i class='fa fa-trash fa-fw'></i> </a><i class='fa fa-caret - right fa - fw invisible'></i> </td></tr>";

        //                    //data += "<tr id ='" + CategoryID + "'><td>" + Category + "</td><td style='float: right;'>" +
        //                    //    "<a href='#' data-val='General_Master.aspx?CategoryID=" + CategoryID + "' class='text-success' data-placement='top' title='Edit record'> <i id='btnedit' " +
        //                    //    "runat='server' class='fa fa-edit fa-fw'></i> </a>  " +
        //                    //    "<a href='#' onclick='functionDelete(this);' data-val='Inventory/General_Master.aspx?DelCategory_ID=" + CategoryID + "' " +
        //                    //    "class='text-danger has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> " +
        //                    //    "	<i class='fa fa-trash fa-fw'></i> </a><i class='fa fa-caret - right fa - fw invisible'></i> </td></tr>";

        //                    data += "<tr id ='" + CategoryID + "'><td>" + Category + "</td><td style='float: right;'>" +
        //                       "<a href='#' data-val='General_Master.aspx?CategoryID=" + CategoryID + "' class='text-success' data-placement='top' title='Edit record'> <i id='btnedit' " +
        //                       "runat='server' class='fa fa-edit fa-fw'></i> </a>  " +
        //                       "<a href='General_Master.aspx?DelCategory_ID=" + CategoryID + "' " +
        //                       "class='text-danger has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> " +
        //                       "	<i class='fa fa-trash fa-fw'></i> </a><i class='fa fa-caret - right fa - fw invisible'></i> </span> </td></tr>";
        //                }
        //            }
        //            else
        //            {

        //            }
        //        }
        //        else
        //        {

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return data;
        //}

        //public string SubCategory_bindgrid()
        //{

        //    string data = "";
        //    string Category = "";
        //    if (Convert.ToString(Session["Category"]) != "")
        //    {
        //        Category = Convert.ToString(Session["Category"]);
        //        //lblCategoryName.Text = Category;
        //    }
        //    else if (CategoryName != "")
        //    {
        //        Session["CategoryName"] = CategoryName;
        //        //hdnCategoryName.Value = Convert.ToString(Session["Category"]);
        //        Category = CategoryName;
        //        //CategoryName = "";
        //    }

        //    try
        //    {
        //        if (Category != "")
        //        {
        //            // ds = ObjUpkeep.LocationMaster_CRUD(0, Category, "", "", Convert.ToString(Session["LoggedInUserID"]), "R");

        //            ds = ObjUpkeep.Crud_Inv_SubCategory_Mst(Convert.ToString(Session["LoggedInUserID"]), Convert.ToString(Session["CompanyID"]),
        //                 Category, 0, "", "R");

        //            if (ds.Tables.Count > 0)
        //            {
        //                if (ds.Tables[0].Rows.Count > 0)
        //                {
        //                    int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

        //                    //gvSubCategory.DataSource = ds.Tables[0];
        //                    //gvSubCategory.DataBind();


        //                    for (int i = 0; i < count; i++)
        //                    {
        //                        int SubCategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["SubCategory_ID"]);
        //                        string SubCategory = Convert.ToString(ds.Tables[0].Rows[i]["SubCategory"]);
        //                        //string CategoryDesc = Convert.ToString(ds.Tables[0].Rows[i]["Category_Desc"]);

        //                        //data += "<tr><td>" + Category + "</td><td style='float: right;'><a href='Inventory/General_Master.aspx?CategoryID=" + CategoryID + "' class='text-success' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='fa fa-edit fa-fw'></i> </a>  <a href='Inventory/General_Master.aspx?DelCategory_ID=" + CategoryID + "' class='text-danger' data-container='body' data-toggle='confirmation' data-placement='top' title='Delete record'> 	<i class='fa fa-trash fa-fw'></i> </a><i class='fa fa-caret - right fa - fw invisible'></i> </td></tr>";
        //                        //data += "<tr><td runat='server' id='myTable' onclick='javascript: __doPostBack(); '>" + Category + " <span style='float: right;'><a href='Inventory/General_Master.aspx?CategoryID=" + CategoryID + "' class='text-success' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='fa fa-edit fa-fw'></i> </a>  <a href='Inventory/General_Master.aspx?DelCategory_ID=" + CategoryID + "' class='text-danger' data-container='body' data-toggle='confirmation' data-placement='top' title='Delete record'> 	<i class='fa fa-trash fa-fw'></i> </a><i class='fa fa-caret - right fa - fw invisible'></i> </td></tr>";

        //                        //data += "<tr id ='" + SubCategoryID + "'><td runat='server' id='mySubCategoryTable'>" + SubCategory + " </td><td>" +
        //                        //    "<span style='float: right;'><a href='General_Master.aspx?SubCategoryID=" + SubCategoryID + "' class='text-success' data-placement='top' title='Edit record'> " +
        //                        //    "<i id='btnedit' runat='server' class='fa fa-edit fa-fw'></i> </a>  " +
        //                        //    "<a href='General_Master.aspx?DelSubCategory_ID=" + SubCategoryID + "' class='text-danger' data-container='body' data-toggle='confirmation' data-placement='top' title='Delete record'> 	" +
        //                        //    "<i class='fa fa-trash fa-fw'></i> </a><i class='fa fa-caret - right fa - fw invisible'></i> </td></tr>";

        //                        // data += "<tr id ='" + SubCategoryID + "'><td runat='server' id='mySubCategoryTable'>" + SubCategory + " </td><td>" +
        //                        //"<span style='float: right;'><a href='#' data-val='General_Master.aspx?SubCategoryID=" + SubCategoryID + "' class='text-success' data-placement='top' title='Edit record'> " +
        //                        //"<i id='btnedit' runat='server' class='fa fa-edit fa-fw'></i> </a>  " +
        //                        //"<a href='#'  onclick='functionDelete(this);' data-val ='General_Master.aspx?DelSubCategory_ID=" + SubCategoryID + "' class='text-danger has-confirmation' " +
        //                        //"data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	" +
        //                        //"<i class='fa fa-trash fa-fw'></i> </a><i class='fa fa-caret - right fa - fw invisible'></i> </td></tr>";

        //                        data += "<tr id ='" + SubCategoryID + "'><td runat='server' id='mySubCategoryTable'>" + SubCategory + " </td><td>" +
        //                      "<span style='float: right;'><a href='#' data-val='General_Master.aspx?SubCategoryID=" + SubCategoryID + "' class='text-success' data-placement='top' title='Edit record'> " +
        //                      "<i id='btnedit' runat='server' class='fa fa-edit fa-fw'></i> </a>  " +
        //                      "<a href='General_Master.aspx?DelSubCategory_ID=" + SubCategoryID + "' class='text-danger has-confirmation' " +
        //                      "data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	" +
        //                      "<i class='fa fa-trash fa-fw'></i> </a><i class='fa fa-caret - right fa - fw invisible'></i></span> </td></tr>";
        //                    }
        //                }
        //                else
        //                {

        //                }
        //            }
        //            else
        //            {

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return data;
        //}

        //public string Item_bindgrid()
        //{

        //    string data = "";
        //    string Category = Convert.ToString(Session["CategoryName"]);
        //    if (Convert.ToString(Session["Category"]) != "")
        //    {
        //        Category = Convert.ToString(Session["Category"]);
        //        //lblCategoryName.Text = Category;
        //    }
        //    else if (CategoryName != "")
        //    {
        //        Session["CategoryName"] = CategoryName;
        //        //hdnCategoryName.Value = Convert.ToString(Session["Category"]);
        //        Category = CategoryName;
        //        //CategoryName = "";
        //    }

        //    //Session["hdnSubCategory"]

        //    string SubCategory = "";
        //    //string SubCategory = lblSubCategory.Text;


        //    if (Convert.ToString(Session["hdnSubCategory"]) != "")
        //    {
        //        SubCategory = Convert.ToString(Session["hdnSubCategory"]);
        //    }
        //    if (SubCatName != "")
        //    {
        //        Session["hdnSubCategory"] = SubCatName;
        //        SubCategory = SubCatName;
        //    }

        //    try
        //    {
        //        if (Category != "")
        //        {
        //            //ds = ObjUpkeep.SubLocationMaster_CRUD(0, SubCategory, Category, "", "", Convert.ToString(Session["LoggedInUserID"]), "R");

        //            ds = ObjUpkeep.Crud_Inv_Item_Mst(Convert.ToString(Session["LoggedInUserID"]), Convert.ToString(Session["CompanyID"]),
        //                Category, SubCategory, 0, "", 0, 0, 0, 0, 0, 0, "R");

        //            if (ds.Tables.Count > 1)
        //            {
        //                if (ds.Tables[0].Rows.Count > 0)
        //                {
        //                    int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

        //                    for (int i = 0; i < count; i++)
        //                    {
        //                        int Item_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Item_ID"]);
        //                        string Item = Convert.ToString(ds.Tables[0].Rows[i]["Item_Desc"]);
        //                        string Current_Stock = Convert.ToString(ds.Tables[0].Rows[i]["Current_Stock"]);

        //                        // data += "<tr><td runat='server' id='myTable'>" + Item + " <span style='float: right;'><a href='General_Master.aspx?ItemID=" + Item_ID + "' class='text-success' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='fa fa-edit fa-fw'></i> </a>  <a href='General_Master.aspx?DelItem_ID=" + Item_ID + "' class='text-danger' data-container='body' data-toggle='confirmation' data-placement='top' title='Delete record'> 	<i class='fa fa-trash fa-fw'></i> </a><i class='fa fa-caret - right fa - fw invisible'></i> </td></tr>";

        //                        //data += "<tr><td runat='server' id='myTable'> " + Item + "" +
        //                        //    " <span style='color: red;'> [" + Current_Stock + "]</span> " +
        //                        //    "<span style='float: right;'><a href='#' data-val='General_Master.aspx?ItemID=" + Item_ID + "' class='text-success' data-placement='top' title='Edit record'> " +
        //                        //    "<i id='btnedit' runat='server' class='fa fa-edit fa-fw'></i> </a> " +
        //                        //    " <a href='#' onclick='functionDelete(this);' class='text-danger has-confirmation' data-container='body' data-val='General_Master.aspx?DelItem_ID=" + Item_ID + "' " +
        //                        //    "data-toggle='m-tooltip' data-placement='top' " +
        //                        //    "title='Delete record'> 	" +
        //                        //    "<i class='fa fa-trash fa-fw'></i> </a><i class='fa fa-caret - right fa - fw invisible'></i> " +
        //                        //    "</td></tr>";

        //                        //data += "<tr><td runat='server' id='myTable'> " + Item + "" +
        //                        //    " <span style='color: red;'> [" + Current_Stock + "]</span> " +
        //                        //    "<span style='float: right;'><a href='#' data-val='General_Master.aspx?ItemID=" + Item_ID + "' class='text-success' data-placement='top' title='Edit record'> " +
        //                        //    "<i id='btnedit' runat='server' class='fa fa-edit fa-fw'></i> </a> " +
        //                        //    " <a href='General_Master.aspx?DelItem_ID=" + Item_ID + "'  class='text-danger has-confirmation' data-container='body'  " +
        //                        //    "data-toggle='m-tooltip' data-placement='top' " +
        //                        //    "title='Delete record'> 	" +
        //                        //    "<i class='fa fa-trash fa-fw'></i> </a><i class='fa fa-caret - right fa - fw invisible'></i> </span></td></tr>";

        //                        data += "<tr><td runat='server' id='myTable'> " + Item + "" +
        //                            " <span style='float: center; color: red; font-weight:bold;'> [ " + Current_Stock + " ] </span> " +
        //                            "<span style='float: right;'> " +
        //                            " <a href='General_Master.aspx?DelItem_ID=" + Item_ID + "'  class='text-danger has-confirmation' data-container='body'  " +
        //                            "data-toggle='m-tooltip' data-placement='top' " +
        //                            "title='Delete record'> 	" +
        //                            "<i class='fa fa-trash fa-fw'></i> </a><i class='fa fa-caret - right fa - fw invisible'></i> </span></td></tr>";
        //                    }
        //                }
        //                else
        //                {

        //                }
        //            }
        //            else
        //            {

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return data;
        //}


        //public void BindDropDown()
        //{
        //    try
        //    {
        //        DataSet dsTitle = new DataSet();

        //        dsTitle = ObjUpkeep.Fetch_Inv_Item_Stock_Ddl(Convert.ToString(Session["LoggedInUserID"]), Convert.ToString(Session["CompanyID"]), Convert.ToString(0));

        //        if (dsTitle.Tables.Count > 0)
        //        {
        //            if (dsTitle.Tables[1].Rows.Count > 0)
        //            {
        //                ddlDepartment.DataSource = dsTitle.Tables[1];
        //                ddlDepartment.DataTextField = "Dept_Desc";
        //                ddlDepartment.DataValueField = "Department_ID";
        //                ddlDepartment.DataBind();
        //                ddlDepartment.Items.Insert(0, new ListItem("--Select--", "0"));
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //#endregion

        //#region WebMethods

        //[System.Web.Services.WebMethod]
        ////[System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        //public static void SubCategory_bindgrid1(string Category)
        //{
        //    CategoryName = Category;
        //    General_Master obj = new General_Master();
        //    obj.SubCategory_bindgrid();

        //}

        //[System.Web.Services.WebMethod]
        //public static void Item_bindgrid1(string SubCategory)
        //{
        //    SubCatName = SubCategory;
        //    General_Master obj = new General_Master();
        //    obj.Item_bindgrid();

        //}

        //[System.Web.Services.WebMethod]
        //public static void SetSeesions(string hdnEditTableClicked, string hdnEditClickedID)
        //{
        //    General_Master obj = new General_Master();
        //    obj.SetSeesion(hdnEditTableClicked, hdnEditClickedID);
        //}

        //public void SetSeesion(string hdnEditTableClicked, string hdnEditClickedID)
        //{
        //    Session["hdnEditTableClicked"] = hdnEditTableClicked;
        //    Session["hdnEditClickedID"] = hdnEditClickedID;

        //    //if (hdnEditClickedID != "")
        //    //{

        //    //    int IDx = Convert.ToInt32(hdnEditClickedID);
        //    //    if (hdnEditTableClicked == "tblCategory")
        //    //    {
        //    //        FetchCategory(IDx);
        //    //    }
        //    //    else if (hdnEditTableClicked == "tblLocation")
        //    //    {
        //    //        FetchSubCategory(IDx);
        //    //    }
        //    //    else if (hdnEditTableClicked == "tblLItems")
        //    //    {
        //    //        FetchItem(IDx);
        //    //    }
        //    //}

        //    //hdnEditTableClicked = "";
        //    //hdnEditClickedID = "";
        //    //Session["hdnEditClickedID"] = "";
        //    //Session["hdnEditClickedID"] = "";
        //}

        ////[System.Web.Services.WebMethod]
        ////public static void DeleteRecord(string Table, string ColID)
        ////{
        ////    General_Master obj = new General_Master();
        ////    obj.DeleteRecordDD(Table, ColID);
        ////}
        ////public void DeleteRecordDD(string Table, string ColID)
        ////{
        ////    Session["DeleteTable"] = Table;
        ////    Session["DeleteID"] = ColID;
        ////}


        #endregion
    }
}