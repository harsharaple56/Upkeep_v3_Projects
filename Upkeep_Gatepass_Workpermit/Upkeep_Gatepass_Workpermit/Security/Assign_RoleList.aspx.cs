using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_Gatepass_Workpermit.Security
{
    public partial class Assign_RoleList : System.Web.UI.Page
    {
        Upkeep_GP_WP_Services.Upkeep_GP_WP_Services ObjUpkeep = new Upkeep_GP_WP_Services.Upkeep_GP_WP_Services();
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (LoggedInUserID == "")
            {
                // redirect to custom error page -- session timeout
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
        }

        public string bindRoleListing()
        {
            string data = "";
            DataSet dsRole = new DataSet();
            try
            {
                dsRole = ObjUpkeep.Fetch_RoleListing();

                if (dsRole.Tables.Count > 0)
                {
                    if (dsRole.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(dsRole.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            string RoleID = Convert.ToString(dsRole.Tables[0].Rows[i]["Role_ID"]);
                            string RoleCount = Convert.ToString(dsRole.Tables[0].Rows[i]["RoleCount"]);
                            string RoleName = Convert.ToString(dsRole.Tables[0].Rows[i]["Role_Name"]);
                            
                            data += "<tr><td>" + RoleCount + "</td><td>" + RoleID + "</td><td>" + RoleName + "</td><td><a href='Assign_RoleMst.aspx?RoleID=" + RoleID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record'> <i class='la la-edit'></i> </a></a> </td></tr>";

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