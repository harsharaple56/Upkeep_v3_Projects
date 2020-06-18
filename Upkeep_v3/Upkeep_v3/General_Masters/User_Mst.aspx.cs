using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;

namespace Upkeep_v3.General_Masters
{
    public partial class User_Mst : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeepCC = new Upkeep_V3_Services.Upkeep_V3_Services();

        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect("~/Login.aspx", false);
            }
            if (!IsPostBack)
            {
                bindGrid();
            }



        }


        public string bindGrid()
          {
            string data = "";
            try
            {
                DataSet ds = new DataSet();

                ds = ObjUpkeepCC.UserMaster_CRUD(0, "", "", "","", "", "", "", "",0,0,0,0,0,"","",0,0,0,0,"", CompanyID, LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int User_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["User_ID"]);
                            string UserCode = Convert.ToString(ds.Tables[0].Rows[i]["User_Code"]);
                            string Name = Convert.ToString(ds.Tables[0].Rows[i]["Name"]);
                            //string f_name = Convert.ToString(ds.Tables[0].Rows[i]["F_Name"]);
                            //string LastName = Convert.ToString(ds.Tables[0].Rows[i]["L_Name"]);
                            string UserDesignation = Convert.ToString(ds.Tables[0].Rows[i]["User_Designation"]);
                            string User_Email = Convert.ToString(ds.Tables[0].Rows[i]["User_Email"]);
                            string Usermobile = Convert.ToString(ds.Tables[0].Rows[i]["User_Mobile"]);
                            string Is_Approver = Convert.ToString(ds.Tables[0].Rows[i]["Approver"]);
                            string Is_GlobalApprover = Convert.ToString(ds.Tables[0].Rows[i]["GlobalApprover"]);
                            string Created_Date = Convert.ToString(ds.Tables[0].Rows[i]["Created_Date"]);
                            

                            string Created_On = Created_Date.Substring(0, 10);
                            DateTime dt;

                            if (DateTime.TryParseExact(Created_On, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out dt))
                            {
                                Created_On = dt.ToString("dd/MMM/yyyy");
                            }

                            data += "<tr><td>" + UserCode + "</td><td>" + Name + "</td><td>" + UserDesignation + "</td><td>" + User_Email + "</td><td>" + Usermobile + "</td><td>" + Is_Approver + "</td><td>" + Is_GlobalApprover + "</td><td>" + Created_On + "</td><td><a href='Add_User_Mst.aspx?User_ID=" + User_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Edit record'> <i class='la la-edit'></i> </a>  <a href='Add_User_Mst.aspx?DelUser_ID=" + User_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";
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
