using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.General_Masters
{
    public partial class UserGrp_Mst : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeepCC = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            //frmMain.Action = @"UserGrp_Mst.aspx";
        }

        public string bindgrid()
        {
            string data = "";
            try
            {
                ds = ObjUpkeepCC.UserGroupMaster_CRUD(0, "", "", CompanyID, LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Grp_Id = Convert.ToInt32(ds.Tables[0].Rows[i]["GroupID"]);
                            string Grp_Desc = Convert.ToString(ds.Tables[0].Rows[i]["GroupName"]);
                            string User_Name = Convert.ToString(ds.Tables[0].Rows[i]["GroupUsers"]);
                            //string User_ID = Convert.ToString(ds.Tables[0].Rows[i]["User_ID"]);


                            data += "<tr><td>" + Grp_Desc + "</td><td>" + User_Name + "</td><td><a href='Add_UserGrp_Mst.aspx?Grp_Id=" + Grp_Id + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record'> <i class='la la-edit'></i> </a>  <a href='Add_UserGrp_Mst.aspx?DelGrp_Id=" + Grp_Id + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

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


        protected void btnAddUserGroup_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/General_Masters/Add_UserGrp_Mst.aspx", false);
            Response.Redirect(Page.ResolveClientUrl("~/General_Masters/Add_UserGrp_Mst.aspx"), false);
        }
    }
}