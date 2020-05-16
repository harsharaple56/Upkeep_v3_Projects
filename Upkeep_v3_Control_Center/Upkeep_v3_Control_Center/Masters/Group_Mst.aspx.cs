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

namespace Upkeep_v3_Control_Center.Masters
{
    public partial class Group_Mst : System.Web.UI.Page
    {
        UpkeepControlCenter_Service.UpkeepControlCenter_Service objUpkeepCC = new UpkeepControlCenter_Service.UpkeepControlCenter_Service();
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            frmMain.Action = @"Group_Mst.aspx";
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                //Response.Redirect("~/Login.aspx", false);
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }

            //bindGrid();
        }

        public string bindGrid()
        {
            string data = "";
            try
            {
                DataSet ds = new DataSet();

                ds = objUpkeepCC.GroupMaster_CRUD(0, "", "", "1", "0", "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int GroupID = Convert.ToInt32(ds.Tables[0].Rows[i]["Group_ID"]);
                            string Group_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Group_Desc"]);
                            string Group_Code = Convert.ToString(ds.Tables[0].Rows[i]["Group_Code"]);
                            
                            data += "<tr><td>" + Group_Desc + "</td><td>" + Group_Code + "</td><td><a href='Add_Group.aspx?GroupID=" + GroupID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record'> <i class='la la-edit'></i> </a>  <a href='Add_Group.aspx?DelGroupID=" + GroupID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

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
            return data;
        }
    }
}