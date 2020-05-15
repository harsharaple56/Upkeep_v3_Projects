using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Text;
using System.Web.UI.HtmlControls;
//using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;

namespace Upkeep_Gatepass_Workpermit.Security
{
    public partial class Role_Menu_Rights : System.Web.UI.Page
    {
        Upkeep_GP_WP_Services.Upkeep_GP_WP_Services ObjUpkeep = new Upkeep_GP_WP_Services.Upkeep_GP_WP_Services();
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                //LoggedInUserID = "3";
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);

            }

            if (!IsPostBack)
            {
                lblErrorMsg.Visible = false;
                BindDropDown();
            }
        }

        public void BindDropDown()
        {
            DataSet dsTitle = new DataSet();
            dsTitle = ObjUpkeep.Fetch_Role_Menu();
            if (dsTitle.Tables.Count > 0)
            {
                if (dsTitle.Tables[0].Rows.Count > 0)
                {
                    ddlRole.DataSource = dsTitle.Tables[0];
                    ddlRole.DataTextField = "Role_Name";
                    ddlRole.DataValueField = "Role_Id";
                    ddlRole.DataBind();
                    ddlRole.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                if (dsTitle.Tables[1].Rows.Count > 0)
                {
                    ddlMenu.DataSource = dsTitle.Tables[1];
                    ddlMenu.DataTextField = "Menu_Desc";
                    ddlMenu.DataValueField = "Menu_Id";
                    ddlMenu.DataBind();
                    ddlMenu.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
        }

        public string BindData()
        {
            DataSet dsRole = new DataSet();
            string data = "";
            try
            {
                if (ddlRole.SelectedValue != "0" && ddlMenu.SelectedValue != "0")
                {
                    dsRole = ObjUpkeep.FETCH_Saved_Role_MENU_Rights(Convert.ToInt32(ddlRole.SelectedValue), Convert.ToInt32(ddlMenu.SelectedValue));
                    if (dsRole.Tables.Count > 0)
                    {
                        if (dsRole.Tables[0].Rows.Count > 0)
                        {
                            int count = Convert.ToInt32(dsRole.Tables[0].Rows.Count);

                            for (int i = 0; i < count; i++)
                            {
                                int Menu_Id = Convert.ToInt32(dsRole.Tables[0].Rows[i]["Menu_Id"]);
                                //int Parent_Menu_Id = Convert.ToInt32(dsRole.Tables[0].Rows[i]["Parent_Menu_Id"]);
                                //int Role_Id = Convert.ToInt32(dsRole.Tables[0].Rows[i]["Role_Id"]);
                                string Menu = Convert.ToString(dsRole.Tables[0].Rows[i]["Menu_Desc"]);
                                bool Select = Convert.ToBoolean(dsRole.Tables[0].Rows[i]["SelectAll"]);
                                bool Add = Convert.ToBoolean(dsRole.Tables[0].Rows[i]["Is_Add"]);
                                bool Update = Convert.ToBoolean(dsRole.Tables[0].Rows[i]["Is_Update"]);
                                bool Read = Convert.ToBoolean(dsRole.Tables[0].Rows[i]["Is_Read"]);
                                bool Delete = Convert.ToBoolean(dsRole.Tables[0].Rows[i]["Is_Delete"]);
                                bool Export = Convert.ToBoolean(dsRole.Tables[0].Rows[i]["Is_Export"]);

                                //<input type="checkbox" name="id[]" value="' + $('<div/>').text(data).html() + '">

                                if (i % 2 == 0)
                                { data += "<tr id='idTr" + i + "'>"; }
                                else
                                { data += "<tr id='idTr" + i + "'>"; }

                                data += "<td><span id='idMenu_Id" + i + "' >" + Menu_Id + "</span></td>";
                                //data += "<td><span id='idParent_Menu_Id" + i + "' >" + Parent_Menu_Id + "</span></td>";
                                //data += "<td><span id='idRole_Id" + i + "' >" + Role_Id + "</span></td>";
                                data += "<td><span id='idMenu" + i + "' >" + Menu + "</span></td>";

                                if (Select == true)
                                {
                                    data += "<td> <input name='Selectcheck' type='checkbox' id='idSelect" + i + "' value='" + Select + "' runat='server' checked> </td>";
                                }
                                else
                                {
                                    data += "<td> <input name='Selectcheck' type='checkbox' id='idSelect" + i + "' value='" + Select + "' runat='server'> </td>";
                                }

                                if (Add == true)
                                {
                                    data += "<td><input name='Inptcheck' type='checkbox' id='idAdd" + i + "' value='" + Add + "' runat='server' checked></td>";
                                }
                                else
                                {
                                    data += "<td><input name='Inptcheck' type='checkbox' id='idAdd" + i + "' value='" + Add + "' runat='server' ></td>";
                                }

                                if (Update == true)
                                {
                                    data += "<td><input name='Inptcheck' type='checkbox' id='idUpdate" + i + "' value='" + Update + "' runat='server' checked></td>";
                                }
                                else
                                {
                                    data += "<td><input name='Inptcheck' type='checkbox' id='idUpdate" + i + "' value='" + Update + "' runat='server' ></td>";
                                }

                                if (Read == true)
                                {
                                    data += "<td><input name='Inptcheck' type='checkbox' id='idRead" + i + "' value='" + Read + "' runat='server' checked></td>";
                                }
                                else
                                {
                                    data += "<td><input name='Inptcheck' type='checkbox' id='idRead" + i + "' value='" + Read + "' runat='server' ></td>";
                                }

                                if (Delete == true)
                                {
                                    data += "<td><input name='Inptcheck' type='checkbox' id='idDelete" + i + "' value='" + Delete + "' runat='server' checked></td>";
                                }
                                else
                                {
                                    data += "<td><input name='Inptcheck' type='checkbox' id='idDelete" + i + "' value='" + Delete + "' runat='server' ></td>";
                                }

                                if (Export == true)
                                {
                                    data += "<td><input name='Inptcheck' type='checkbox' id='idExport" + i + "' value='" + Export + "' runat='server' checked ></td>";
                                }
                                else
                                {
                                    data += "<td><input name='Inptcheck' type='checkbox' id='idExport" + i + "' value='" + Export + "' runat='server' ></td>";
                                }

                                data += "</tr>";
                            }
                        }
                        else { return ""; }
                    }
                    else { return ""; }
                }
                else { return ""; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

        public void SaveData()
        {
            try
            {
                lblErrorMsg.Visible = false;
                string strWpSectionHeaderData = "";
                if (hdTableJsonData.Value != "")
                {
                    DataTable dtSave = new DataTable();
                    dtSave = JsonConvert.DeserializeObject<DataTable>(hdTableJsonData.Value);
                    if (dtSave.Rows.Count > 0)
                    {
                        //Insert Code here :-
                        DataTable DTS = new DataTable();
                        DTS = dtSave.Copy();
                        DTS.DefaultView.RowFilter = "  Add = 1 OR  Update = 1 OR Read = 1  OR Delete = 1 OR Export = 1 ";
                        DTS = DTS.DefaultView.ToTable();

                        DTS.TableName = "Table1";
                        if (DTS.Rows.Count > 0)
                        {
                            MemoryStream str = new MemoryStream();
                            DTS.WriteXml(str, true);
                            str.Seek(0, SeekOrigin.Begin);
                            StreamReader sr = new StreamReader(str);
                            string xmlstr;
                            xmlstr = sr.ReadToEnd();
                            strWpSectionHeaderData = xmlstr;

                            DataSet dsStatus = new DataSet();
                            int RoleID = Convert.ToInt32(ddlRole.SelectedValue);
                            int ParentMenuID = Convert.ToInt32(ddlMenu.SelectedValue);

                            dsStatus = ObjUpkeep.Insert_RoleMenuRights(RoleID, ParentMenuID, LoggedInUserID, strWpSectionHeaderData);

                            if (dsStatus.Tables.Count > 0)
                            {
                                if (dsStatus.Tables[0].Rows.Count > 0)
                                {
                                    int Status = Convert.ToInt32(dsStatus.Tables[0].Rows[0]["Status"]);
                                    if (Status == 1)
                                    {
                                        mpeWpRequestSaveSuccess.Show();

                                        lblErrorMsg.Visible = false;
                                        ddlRole.SelectedIndex = 0;
                                        ddlMenu.SelectedIndex = 0;
                                    }
                                }
                            }
                        }
                        else
                        {
                            lblErrorMsg.Visible = true;
                            lblErrorMsg.Text = "Please Select Rights";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void ddlMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Visible = false;
            ddlRole.SelectedIndex = 0;
            ddlMenu.SelectedIndex = 0;
        }
    }
}