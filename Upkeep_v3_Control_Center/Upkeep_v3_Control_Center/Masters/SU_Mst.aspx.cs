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
    public partial class SU_Mst : System.Web.UI.Page
    {
        UpkeepControlCenter_Service.UpkeepControlCenter_Service objUpkeepCC = new UpkeepControlCenter_Service.UpkeepControlCenter_Service();
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect("~/Login.aspx", false);
            }
            //bindTable();


        }


        public string bindTable()
        {
            string data = "";
            try
            {
                DataSet ds = new DataSet();

                ds = objUpkeepCC.AdminLogin_Master(0, "", "", "","","1", "0", "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"]);
                            string FirstName = Convert.ToString(ds.Tables[0].Rows[i]["FirstName"]);
                            string LastName = Convert.ToString(ds.Tables[0].Rows[i]["LastName"]);
                            string Username = Convert.ToString(ds.Tables[0].Rows[i]["Username"]);
                            //string Password = Convert.ToString(ds.Tables[0].Rows[i]["Password"]);


                            data += "<tr><td>" + FirstName + "</td><td>" + LastName + "</td><td>" + Username + "</td><td><a href='Add_SU.aspx?ID=" + ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record'> <i class='la la-edit'></i> </a>  <a href='Add_SU.aspx?DelID=" + ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

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