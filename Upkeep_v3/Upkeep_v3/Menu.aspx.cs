using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3
{
    public partial class Menu : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeepCC = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            bindgrid();
        }

        public string bindgrid()
        {
            string data = "";
            try
            {
                ds = ObjUpkeepCC.MenuMaster_CRUD(0, "", "0", "", "", "0", "0", "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int MenuID = Convert.ToInt32(ds.Tables[0].Rows[i]["Menu_Id"]);
                            string Menu_Name = Convert.ToString(ds.Tables[0].Rows[i]["Menu_Desc"]);
                            string Menu_Url = Convert.ToString(ds.Tables[0].Rows[0]["Menu_Url"]);

                            data += "<tr><td>" + Menu_Name + "</td><td>" + Menu_Url + "</td><td><a href='Add_Menu.aspx?MenuID=" + MenuID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record'> <i class='la la-edit'></i> </a>  <a href='Add_Menu.aspx?DelMenuID=" + MenuID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

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
    }
}