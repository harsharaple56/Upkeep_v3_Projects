using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing;

namespace Upkeep_v3.VMS
{
    public partial class Verify_Visitor_ID_V2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static string Verify_Visitor_ID(string visitor_code)
        {
            try
            {
                #region Fetch Data From (Spr_VMS_Verify_Visitor_ID) using qrcode
                if (!string.IsNullOrEmpty(visitor_code))
                {
                    string Visit_Request_Code = visitor_code;
                    string Visitor_Name = string.Empty; ;
                    string Visitor_Email = string.Empty; ;
                    string Visitor_Contact = string.Empty;
                    string Visitor_Request_ID = string.Empty;
                    string Visitor_Photo = string.Empty;
                    string Vaccination_Date = string.Empty;
                    string Visit_Request_Date = string.Empty;
                    string Visit_Date = string.Empty;

                    Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
                    DataSet dsVCOde = new DataSet();
                    dsVCOde = ObjUpkeep.Get_VMS_Verify_Visitor_ID(Visit_Request_Code);
                    if (dsVCOde.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dsVCOde.Tables[0].Rows[0]["Vaccination_Verified"]) == 1)
                        {
                            Visitor_Name = dsVCOde.Tables[0].Rows[0]["Visitor_Name"].ToString();
                            Visitor_Email = dsVCOde.Tables[0].Rows[0]["Visitor_Email"].ToString();
                            Visitor_Request_ID = dsVCOde.Tables[0].Rows[0]["Visit_Request_ID"].ToString();
                            Visitor_Contact = dsVCOde.Tables[0].Rows[0]["Visitor_Contact"].ToString();
                            Visitor_Photo = dsVCOde.Tables[0].Rows[0]["Visitor_Photo"].ToString();
                            DateTime vdate = DateTime.Parse(dsVCOde.Tables[0].Rows[0]["Vaccination_Date"].ToString());
                            DateTime vistidate = DateTime.Parse(dsVCOde.Tables[0].Rows[0]["Visit_Date"].ToString());
                            Vaccination_Date = vdate.ToString("dddd - dd MMMM yyyy");
                            Visit_Date = vistidate.ToString("dddd - dd/MMM/yyyy hh:mm tt");
                            Visit_Request_Date = dsVCOde.Tables[0].Rows[0]["Visit_Request_Date"].ToString();

                            string vCodedata = string.Join(",", Visitor_Photo, Visitor_Name, Visitor_Email, Visitor_Contact, Visitor_Request_ID, Vaccination_Date, Visit_Request_Date, Visit_Date);
                            return vCodedata;
                        }
                        else
                        {
                            return "InvalidQR";
                        }
                    }
                }
                else
                {
                    return "InvalidQR";
                }
                #endregion

                return visitor_code;
            }
            catch (Exception ex)
            {
                return (ex.Message + "rn" + ex.StackTrace);
            }
        }

    }
}