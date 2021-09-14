using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Upkeep_v3.Cocktail_World.Transactions
{
    public partial class Transfers : System.Web.UI.Page
    {
        CocktailWorld_Service.CocktailWorld_Service ObjCocktailWorld = new CocktailWorld_Service.CocktailWorld_Service();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
        }

        public string Fetch_Transfer_Transactions()
        {
            string data = "";
            try
            {
                ds = ObjCocktailWorld.TransferMaster_CRUD(0,string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,0,0,LoggedInUserID,CompanyID,"Select");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            int Transfer_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["Transfer_ID"]);
                            DateTime Transfer_Date = DateTime.Parse(Convert.ToString(ds.Tables[0].Rows[i]["Transfer_Date"]));
                            string From_License = Convert.ToString(ds.Tables[0].Rows[i]["From_License"]);
                            string To_License = Convert.ToString(ds.Tables[0].Rows[i]["To_License"]);
                            string Tp_No = Convert.ToString(ds.Tables[0].Rows[i]["TP_No"]);
                            string Invoice_No = Convert.ToString(ds.Tables[0].Rows[i]["Invoice_No"]);
                            string CreateBy = Convert.ToString(ds.Tables[0].Rows[i]["UserName"]);
                            DateTime CreatedDate = DateTime.Parse(Convert.ToString(ds.Tables[0].Rows[i]["Created_Date"]));
                            data += "<tr>";
                            data += "<td>" + Transfer_Date.ToString("dd-MMM-yyyy") + "</td>";
                            data += "<td>" + From_License + "</td>";
                            data += "<td>" + To_License + "</td>";
                            data += "<td>" + Tp_No + "</td>";
                            data += "<td>" + Invoice_No + "</td>";
                            data += "<td>" + CreateBy + "</td>";
                            data += "<td>" + CreatedDate.ToString("dd-MMM-yyyy") + "</td>";
                            data += "<td>" +
                                "<a href='Add_Transfers.aspx?Transfer_ID=" + Transfer_ID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>  " +
                                "<a href='Add_Transfers.aspx?DelTransfer_ID=" + Transfer_ID + "' class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' data-container='body' data-toggle='m-tooltip' data-placement='top' title='Delete record'> 	<i class='la la-trash'></i> </a> " +
                                "</td>";
                            data += "</tr>";

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
    }
}