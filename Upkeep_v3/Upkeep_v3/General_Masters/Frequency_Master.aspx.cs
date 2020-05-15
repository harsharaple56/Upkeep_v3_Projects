using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace Upkeep_v3.General_Masters
{
    public partial class Frequency_Master : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);

            //frmMain.Action = @"General_Masters/Frequency_Master.aspx";
            //frmMain.Action = @"Frequency_Master.aspx";
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
                ds = ObjUpkeep.FrequencyMaster_CRUD(0, "", CompanyID, LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int Frquency_Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Frquency_Id"]);
                            string Frquency_Desc = Convert.ToString(ds.Tables[0].Rows[i]["Frquency_Desc"]);

                            //data += "<tr><td>" + Frquency_Id + "</td><td>" + Frquency_Desc + "</td><td><a href='General_Masters/Add_Frequency.aspx?Frquency_Id=" + Frquency_Id + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  <a href='General_Masters/Add_Frequency.aspx?DelFreq_ID=" + Frquency_Id + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";
                            data += "<tr><td>" + Frquency_Id + "</td><td>" + Frquency_Desc + "</td><td><a href='Add_Frequency.aspx?Frquency_Id=" + Frquency_Id + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  <a href='Add_Frequency.aspx?DelFreq_ID=" + Frquency_Id + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> </td></tr>";

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

        protected void btnFrequency_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/General_Masters/Add_Frequency.aspx", false);
            Response.Redirect(Page.ResolveClientUrl("~/General_Masters/Add_Frequency.aspx"), false);
        }
    }
}