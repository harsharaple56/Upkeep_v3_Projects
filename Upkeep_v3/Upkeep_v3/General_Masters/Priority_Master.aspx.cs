using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.General_Masters
{
    public partial class Priority_Master : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeepCC = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            //frmMain.Action = @"General_Masters/Priority_Master.aspx";
            //frmMain.Action = @"Priority_Master.aspx";
            if (LoggedInUserID == "")
            {
                Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
        }

        public string bindgrid()
        {
            string data = "";
            try
            {
                ds = ObjUpkeepCC.PriorityMaster_CRUD(0, "", CompanyID, LoggedInUserID,"R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Priority_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Priority_ID"]);
                            string Priority_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Priority_Desc"]);

                            //data += "<tr><td>" + Priority_ID + "</td><td>" + Priority_Desc + "</td><td><a href='General_Masters/Add_Priority.aspx?Priority_ID=" + Priority_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  <a href='General_Masters/Add_Priority.aspx?DelPrio_ID=" + Priority_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";
                            data += "<tr><td>" + Priority_ID + "</td><td>" + Priority_Desc + "</td><td><a href='Add_Priority.aspx?Priority_ID=" + Priority_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  <a href='Add_Priority.aspx?DelPrio_ID=" + Priority_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

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

        protected void btnPriority_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/General_Masters/Add_Priority.aspx", false);
            Response.Redirect(Page.ResolveClientUrl("~/General_Masters/Add_Priority.aspx"), false);
        }
    }
}