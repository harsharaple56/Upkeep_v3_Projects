using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Inventory
{
    public partial class General_Master2 : System.Web.UI.Page
    {

        #region Global variables
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        #region WebMethods
        public void DeleteData(string Table, int ID)
        {
            try
            {
                DataSet dst = new DataSet();
                string Action = "D";
                if (Table == "tblCategory")
                {
                    dst = ObjUpkeep.Crud_Inv_Category_Mst(Convert.ToString(Session["LoggedInUserID"]), Convert.ToString(Session["CompanyID"]), ID, "", Action);
                }
                else if (Table == "tblLocation")
                {
                    dst = ObjUpkeep.Crud_Inv_SubCategory_Mst(Convert.ToString(Session["LoggedInUserID"]), Convert.ToString(Session["CompanyID"]), "", ID, "", Action);
                }
                else if (Table == "tblLItems")
                {
                    dst = ObjUpkeep.Crud_Inv_Item_Mst(Convert.ToString(Session["LoggedInUserID"]), Convert.ToString(Session["CompanyID"]), "", "", ID,
                   "", 0, 0, 0, 0, 0, 0, Action);
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
                            Response.Redirect("~/Inventory/General_Master.aspx", false);
                        }
                        else if (Status == 2)
                        {
                            //  lblItemErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                        else if (Status == 3)
                        {
                            //  lblItemErrorMsg.Text = "Sub Location already exists";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [System.Web.Services.WebMethod]
        public static string Category_bindgrid(string txtName)
        {
            General_Master2 obj = new General_Master2();
            string data = "";
            DataSet ds = new DataSet();
            try
            {
                ds = obj.ObjUpkeep.Crud_Inv_Category_Mst(Convert.ToString(obj.Session["LoggedInUserID"]), Convert.ToString(obj.Session["CompanyID"]), 0, "", "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int CategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["Category_ID"]);
                            string Category = Convert.ToString(ds.Tables[0].Rows[i]["Category"]);
                            data += "<tr id ='" + CategoryID + "'>" +
                                "<td width='250px'>" + Category + "</td>" +
                                "<td></td>" +
                                "<td>" +
                               "<a href='#' class='text-success' data-placement='top' title='Edit record'> <i data-name='" + Category + "' id='btnedit' " +
                               "onclick='editCategory(this)' class='fa fa-edit fa-fw'></i> </a>  " +
                               "<a href='#' class='text-danger has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> " +
                               "<i data-id='" + CategoryID + "' onclick='deleteCategory(this)' class='fa fa-trash fa-fw'></i> </a>" +
                               " </td>" +
                               "</tr>";
                        }
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

        [System.Web.Services.WebMethod]
        public static string SubCategory_bindgrid(string Category)
        {
            DataSet ds = new DataSet();
            General_Master2 obj = new General_Master2();
            string data = "";

            try
            {
                if (Category != "")
                {
                    ds = obj.ObjUpkeep.Crud_Inv_SubCategory_Mst(Convert.ToString(obj.Session["LoggedInUserID"]), Convert.ToString(obj.Session["CompanyID"]),
                         Category, 0, "", "R");

                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            int count = Convert.ToInt32(ds.Tables[0].Rows.Count);
                            for (int i = 0; i < count; i++)
                            {
                                int SubCategoryID = Convert.ToInt32(ds.Tables[0].Rows[i]["SubCategory_ID"]);
                                string SubCategory = Convert.ToString(ds.Tables[0].Rows[i]["SubCategory"]);

                                data += "<tr id = '" + SubCategoryID + "' > " +
                                "<td width='250px'>" + SubCategory + "</td>" +
                                "<td></td>" +
                                "<td>" +
                               "<a href='#' class='text-success' data-placement='top' title='Edit record'> <i data-Category='" + Category + "' data-name='" + SubCategory + "' id='btnedit' " +
                               "onclick='editSubCategory(this)' class='fa fa-edit fa-fw'></i> </a>  " +
                               "<a href='#' class='text-danger has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> " +
                               "<i data-id='" + SubCategoryID + "' onclick='deleteSubCategory(this)' class='fa fa-trash fa-fw'></i> </a>" +
                               " </td>" +
                               "</tr> ";
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

        [System.Web.Services.WebMethod]
        public static string Item_bindgrid(string Category, string SubCategory)
        {
            string data = "";
            General_Master2 obj = new General_Master2();
            DataSet ds = new DataSet();

            try
            {
                if (Category != "" && SubCategory != "")
                {
                    ds = obj.ObjUpkeep.Crud_Inv_Item_Mst(Convert.ToString(obj.Session["LoggedInUserID"]), Convert.ToString(obj.Session["CompanyID"]),
                        Category, SubCategory, 0, "", 0, 0, 0, 0, 0, 0, "R");

                    if (ds.Tables.Count > 1)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                            for (int i = 0; i < count; i++)
                            {
                                int Item_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Item_ID"]);
                                string Item = Convert.ToString(ds.Tables[0].Rows[i]["Item_Desc"]);
                                string Current_Stock = Convert.ToString(ds.Tables[0].Rows[i]["Current_Stock"]);
                                string Department_ID = Convert.ToString(ds.Tables[0].Rows[i]["Department_ID"]);
                                string Base_Value = Convert.ToString(ds.Tables[0].Rows[i]["Base_Value"]);
                                string Cost_Rate = Convert.ToString(ds.Tables[0].Rows[i]["Cost_Rate"]);
                                string Opening_Stock = Convert.ToString(ds.Tables[0].Rows[i]["Opening_Stock"]);
                                string Optimum_Value = Convert.ToString(ds.Tables[0].Rows[i]["Optimum_Value"]);
                                string Reorder_Value = Convert.ToString(ds.Tables[0].Rows[i]["Reorder_Value"]);

                                data += "<tr id = '" + Item_ID + "' > " +
                               "<td width='250px'>" + Item + "<span style='float: center; color: red; font-weight:bold;'> [ " + Current_Stock + " ] </span> </td>" +
                               "<td></td>" +
                               "<td>" +
                              //"<a href='#' class='text-success' data-placement='top' title='Edit record'> <i  id='btnedit' " +
                              //" data-category='" + Category + "' data-subcategory='" + SubCategory + "' data-description='" + Item + "' " +
                              //"data-department='" + Department_ID + "' data-opening='" + Opening_Stock + "' data-optimum='" + Optimum_Value + "' data-reorder='" + Reorder_Value + "'" +
                              //"data-base='" + Base_Value + "' data-cost='" + Cost_Rate + "'" +
                              //"onclick='editItem(this)' class='fa fa-edit fa-fw'></i> </a>  " +
                              "<a href='#' class='text-danger has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> " +
                              "<i data-id='" + Item_ID + "' onclick='deleteItem(this)' class='fa fa-trash fa-fw'></i> </a>" +
                              " </td>" +
                              "</tr> ";
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

        [System.Web.Services.WebMethod]
        public static Dictionary<string, string> CategorySave_Click(int txtCategoryID, string txtCategory)
        {
            General_Master2 obj = new General_Master2();
            DataSet ds = new DataSet();
            Dictionary<string, string> data = new Dictionary<string, string>();
            int CategoryID = txtCategoryID;
            try
            {
                string Action = "";

                if (CategoryID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                ds = obj.ObjUpkeep.Crud_Inv_Category_Mst(Convert.ToString(obj.Session["LoggedInUserID"]), Convert.ToString(obj.Session["CompanyID"]), CategoryID, txtCategory.Trim(), Action);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {

                            data.Add("1", "<tr id = '" + ds.Tables[0].Rows[0]["CategoryID"].ToString() + "' > " +
                                "<td width='250px'>" + txtCategory + "</td>" +
                                "<td></td>" +
                                "<td>" +
                               "<a href='#' class='text-success' data-placement='top' title='Edit record'> <i data-name='" + txtCategory + "' id='btnedit' " +
                               "onclick='editSubCategory(this)' class='fa fa-edit fa-fw'></i> </a>  " +
                               "<a href='#' class='text-danger has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> " +
                               "<i data-id='" + ds.Tables[0].Rows[0]["CategoryID"].ToString() + "' onclick='deleteSubCategory(this)' class='fa fa-trash fa-fw'></i> </a>" +
                               " </td>" +
                               "</tr> ");
                        }
                        else if (Status == 3)
                        {
                            data.Add("3", "Category already exists");
                        }
                        else if (Status == 2)
                        {
                            data.Add("2", "Due to some technical issue your request can not be process. Kindly try after some time");
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

        [System.Web.Services.WebMethod]
        public static Dictionary<string, string> SubCategorySave_Click(int txtSubCategoryID, string txtSubCategory, string Category)
        {
            General_Master2 obj = new General_Master2();
            DataSet ds = new DataSet();
            Dictionary<string, string> data = new Dictionary<string, string>();
            int SubCategoryID = txtSubCategoryID;
            try
            {
                string Action = "";
                if (SubCategoryID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                ds = obj.ObjUpkeep.Crud_Inv_SubCategory_Mst(Convert.ToString(obj.Session["LoggedInUserID"]), Convert.ToString(obj.Session["CompanyID"]), Category, SubCategoryID, txtSubCategory.Trim(), Action);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {

                            data.Add("1", "<tr id = '" + ds.Tables[0].Rows[0]["SubCategoryID"].ToString() + "' > " +
                                "<td width='250px'>" + txtSubCategory + "</td>" +
                                "<td></td>" +
                                "<td>" +
                               "<a href='#' class='text-success' data-placement='top' title='Edit record'> <i data-Category='" + ds.Tables[0].Rows[0]["Category"].ToString() + "' data-name='" + txtSubCategory + "' id='btnedit' " +
                               "onclick='editSubCategory(this)' class='fa fa-edit fa-fw'></i> </a>  " +
                               "<a href='#' class='text-danger has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> " +
                               "<i data-id='" + ds.Tables[0].Rows[0]["SubCategoryID"].ToString() + "' onclick='deleteSubCategory(this)' class='fa fa-trash fa-fw'></i> </a>" +
                               " </td>" +
                               "</tr> ");
                        }
                        else if (Status == 3)
                        {
                            data.Add("3", "Sub Category already exists");
                        }
                        else if (Status == 2)
                        {
                            data.Add("2", "Due to some technical issue your request can not be process. Kindly try after some time");
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

        [System.Web.Services.WebMethod]
        public static Dictionary<string, string> ItemSave_Click(string CategoryID, string SubCategoryID, int ItemID, string ItemDesc, int DeptID, int Opening, int Optimum, int Reorder, int Base, int CostRate)
        {
            General_Master2 obj = new General_Master2();
            DataSet ds = new DataSet();
            Dictionary<string, string> data = new Dictionary<string, string>();
            try
            {
                string Action = "";
                if (ItemID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                ds = obj.ObjUpkeep.Crud_Inv_Item_Mst(Convert.ToString(obj.Session["LoggedInUserID"]),
                                   Convert.ToString(obj.Session["CompanyID"]), CategoryID, SubCategoryID, ItemID,
                                   ItemDesc.Trim(), DeptID, Opening, Optimum, Reorder, Base, CostRate, Action);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        

                        if (Status == 1)
                        {
                            int Item_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["Item_ID"]);
                            string Item = Convert.ToString(ds.Tables[0].Rows[0]["Item_Desc"]);
                            string Current_Stock = string.Empty;
                            object Current_Stockval = ds.Tables[0].Rows[0]["Current_Stock"];
                            if (Current_Stockval != DBNull.Value && !string.IsNullOrEmpty(Current_Stockval.ToString()))
                            {
                                Current_Stock = Convert.ToInt32(ds.Tables[0].Rows[0]["Current_Stock"]).ToString(); ;
                            }
                            else
                            {
                                Current_Stock = "0";
                            }
                            data.Add("1", "<tr id = '" + Item_ID + "' > " +
                               "<td width='250px'>" + Item + "<span style='float: center; color: red; font-weight:bold;'> [ " + Current_Stock + " ] </span> </td>" +
                               "<td></td>" +
                               "<td>" +
                              //"<a href='#' class='text-success' data-placement='top' title='Edit record'> <i  id='btnedit' " +
                              //" data-category='" + Category + "' data-subcategory='" + SubCategory + "' data-description='" + Item + "' " +
                              //"data-department='" + Department_ID + "' data-opening='" + Opening_Stock + "' data-optimum='" + Optimum_Value + "' data-reorder='" + Reorder_Value + "'" +
                              //"data-base='" + Base_Value + "' data-cost='" + Cost_Rate + "'" +
                              //"onclick='editItem(this)' class='fa fa-edit fa-fw'></i> </a>  " +
                              "<a href='#' class='text-danger has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> " +
                              "<i data-id='" + Item_ID + "' onclick='deleteItem(this)' class='fa fa-trash fa-fw'></i> </a>" +
                              " </td>" +
                              "</tr> ");
                        }
                        else if (Status == 3)
                        {
                            data.Add("3", "Item already exists");
                        }
                        else if (Status == 2)
                        {
                            data.Add("2", "Due to some technical issue your request can not be process. Kindly try after some time");
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

        [System.Web.Services.WebMethod]
        public static Dictionary<string, string> DeleteCategory(int txtCategoryID)
        {
            General_Master2 obj = new General_Master2();
            DataSet ds = new DataSet();
            Dictionary<string, string> data = new Dictionary<string, string>();
            int CategoryID = txtCategoryID;
            string Action = "D";
            try
            {
                ds = obj.ObjUpkeep.Crud_Inv_Category_Mst(Convert.ToString(obj.Session["LoggedInUserID"]), Convert.ToString(obj.Session["CompanyID"]), CategoryID, "", Action);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            data.Add("1", "Success");
                        }
                        else if (Status == 3)
                        {
                            data.Add("3", "Category already exists");
                        }
                        else if (Status == 2)
                        {
                            data.Add("2", "Due to some technical issue your request can not be process. Kindly try after some time");
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

        [System.Web.Services.WebMethod]
        public static Dictionary<string, string> DeleteSubCategory(int txtSubCategoryID)
        {
            General_Master2 obj = new General_Master2();
            DataSet ds = new DataSet();
            Dictionary<string, string> data = new Dictionary<string, string>();
            int SubCategoryID = txtSubCategoryID;
            string Action = "D";
            try
            {
                ds = obj.ObjUpkeep.Crud_Inv_SubCategory_Mst(Convert.ToString(obj.Session["LoggedInUserID"]), Convert.ToString(obj.Session["CompanyID"]), string.Empty, SubCategoryID, string.Empty, Action);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            data.Add("1", "Success");
                        }
                        else if (Status == 3)
                        {
                            data.Add("3", "Category already exists");
                        }
                        else if (Status == 2)
                        {
                            data.Add("2", "Due to some technical issue your request can not be process. Kindly try after some time");
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

        [System.Web.Services.WebMethod]
        public static Dictionary<string, string> DeleteItem(int txtItemID)
        {
            General_Master2 obj = new General_Master2();
            DataSet ds = new DataSet();
            Dictionary<string, string> data = new Dictionary<string, string>();
            int ItemID = txtItemID;
            string Action = "D";
            try
            {
                ds = obj.ObjUpkeep.Crud_Inv_Item_Mst(Convert.ToString(obj.Session["LoggedInUserID"]), Convert.ToString(obj.Session["CompanyID"]), "", "", ItemID, "", 0, 0, 0, 0, 0, 0, Action);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 1)
                        {
                            data.Add("1", "Success");
                        }
                        else if (Status == 3)
                        {
                            data.Add("3", "Category already exists");
                        }
                        else if (Status == 2)
                        {
                            data.Add("2", "Due to some technical issue your request can not be process. Kindly try after some time");
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

        [System.Web.Services.WebMethod]
        public static Dictionary<string, string> FetchDepartment(string item)
        {
            General_Master2 obj = new General_Master2();
            Dictionary<string, string> dlst = new Dictionary<string, string>();
            try
            {
                DataSet dsTitle = new DataSet();
                dsTitle = obj.ObjUpkeep.Fetch_Inv_Item_Stock_Ddl(Convert.ToString(obj.Session["LoggedInUserID"]), Convert.ToString(obj.Session["CompanyID"]), Convert.ToString(0));
                dlst.Add("0", "---- Select ----");
                if (dsTitle.Tables.Count > 0)
                {
                    if (dsTitle.Tables[1].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsTitle.Tables[1].Rows.Count; i++)
                        {
                            dlst.Add(dsTitle.Tables[1].Rows[i]["Department_ID"].ToString(), dsTitle.Tables[1].Rows[i]["Dept_Desc"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dlst;
        }

        #endregion

    }
}