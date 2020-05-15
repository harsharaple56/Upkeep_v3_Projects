using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.General_Masters
{

    public partial class Locations_Mst : System.Web.UI.Page
    {
        static string ZoneName = string.Empty;
        static string LocName = string.Empty;
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            //FrmMain.Action = @"General_Masters/Locations_Mst.aspx";
            //FrmMain.Action = @"Locations_Mst.aspx";

            if (!string.IsNullOrEmpty(hdnTxtLocation.Text))
            {
                lblLocation.Text = hdnTxtLocation.Text;
                Session["hdnLocation"] = hdnTxtLocation.Text;
            }
            if (!string.IsNullOrEmpty(Convert.ToString(Session["hdnLocation"])))
            {
                lblLocation.Text = Convert.ToString(Session["hdnLocation"]);
            }

            if (!string.IsNullOrEmpty(hdnTxtZone.Text))
            {
                lblZoneName.Text = hdnTxtZone.Text;
                Session["ZoneName"] = hdnTxtZone.Text;
            }
            if (!string.IsNullOrEmpty(Convert.ToString(Session["ZoneName"])))
            {
                lblZoneName.Text = Convert.ToString(Session["ZoneName"]);
            }

            string ncn = Convert.ToString(hdnZone.Value);
            //Location_bindgrid();
            if (!IsPostBack)
            {
                int ZoneID = Convert.ToInt32(Request.QueryString["ZoneID"]);

                int LocID = Convert.ToInt32(Request.QueryString["LocID"]);
                int SubLocID = Convert.ToInt32(Request.QueryString["SubLocID"]);
                //int Del_Frequency_ID = Convert.ToInt32(Request.QueryString["DelFreq_ID"]);

                if (ZoneID > 0)
                {
                    FetchZone(ZoneID);
                }
                else if (LocID > 0)
                {
                    FetchLocation(LocID);
                }
                else if (SubLocID > 0)
                {
                    FetchSubLocation(SubLocID);
                }

                //if (Del_Frequency_ID > 0)
                //{
                //    DeleteFrequency(Del_Frequency_ID);
                //}
            }

            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "HighlightZoneTable()", true);

        }

        //protected override void OnPreRender(EventArgs e)
        //{
        //    base.OnPreRender(e);

        //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), this.ClientID, ";", true);
        //}

        public string Zone_bindgrid()
        {
            string data = "";
            string URL = "";
            URL = Page.ResolveClientUrl("~/General_Masters/Locations_Mst.aspx");
            try
            {
                ds = ObjUpkeep.ZoneMaster_CRUD(0, 0, "", "", LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int ZoneID = Convert.ToInt32(ds.Tables[0].Rows[i]["Zone_ID"]);
                            string Zone = Convert.ToString(ds.Tables[0].Rows[i]["Zone"]);
                            //string ZoneDesc = Convert.ToString(ds.Tables[0].Rows[i]["Zone_Desc"]);

                            data += "<tr><td>" + Zone + "</td><td style='float: right;'><a href='Locations_Mst.aspx?ZoneID=" + ZoneID + "' class='text-success' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='fa fa-edit fa-fw'></i> </a>  <a href='General_Masters/Locations_Mst.aspx?DelZone_ID=" + ZoneID + "' class='text-danger' data-container='body' data-toggle='confirmation' data-placement='top' title='Delete record'> 	<i class='fa fa-trash fa-fw'></i> </a><i class='fa fa-caret - right fa - fw invisible'></i> </td></tr>";
                            //data += "<tr><td runat='server' id='myTable' onclick='javascript: __doPostBack(); '>" + Zone + " <span style='float: right;'><a href='General_Masters/Locations_Mst.aspx?ZoneID=" + ZoneID + "' class='text-success' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='fa fa-edit fa-fw'></i> </a>  <a href='General_Masters/Locations_Mst.aspx?DelZone_ID=" + ZoneID + "' class='text-danger' data-container='body' data-toggle='confirmation' data-placement='top' title='Delete record'> 	<i class='fa fa-trash fa-fw'></i> </a><i class='fa fa-caret - right fa - fw invisible'></i> </td></tr>";
                            //data += "<tr><td runat='server' id='myZoneTable'>" + Zone + " <span style='float: right;'><a href='Locations_Mst.aspx?ZoneID=" + ZoneID + "' class='text-success' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='fa fa-edit fa-fw'></i> </a>  <a href='Locations_Mst.aspx?DelZone_ID=" + ZoneID + "' class='text-danger' data-container='body' data-toggle='confirmation' data-placement='top' title='Delete record'> 	<i class='fa fa-trash fa-fw'></i> </a><i class='fa fa-caret - right fa - fw invisible'></i> </td></tr>";
                            
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

        public string Location_bindgrid()
        {
            
            string data = "";
            string Zone = "";
            if (Convert.ToString(Session["Zone"]) != "")
            {
                Zone = Convert.ToString(Session["Zone"]);
                //lblZoneName.Text = Zone;
            }
            else if (ZoneName != "")
            {
                Session["ZoneName"] = ZoneName;
                //hdnZoneName.Value = Convert.ToString(Session["Zone"]);
                Zone = ZoneName;
                //ZoneName = "";
            }

            try
            {
                if (Zone != "")
                {
                    ds = ObjUpkeep.LocationMaster_CRUD(0, Zone, "", "", LoggedInUserID, "R");

                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                            //gvLocation.DataSource = ds.Tables[0];
                            //gvLocation.DataBind();


                            for (int i = 0; i < count; i++)
                            {
                                int LocID = Convert.ToInt32(ds.Tables[0].Rows[i]["Loc_ID"]);
                                string Location = Convert.ToString(ds.Tables[0].Rows[i]["Location"]);
                                //string ZoneDesc = Convert.ToString(ds.Tables[0].Rows[i]["Zone_Desc"]);

                                //data += "<tr><td>" + Zone + "</td><td style='float: right;'><a href='General_Masters/Locations_Mst.aspx?ZoneID=" + ZoneID + "' class='text-success' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='fa fa-edit fa-fw'></i> </a>  <a href='General_Masters/Locations_Mst.aspx?DelZone_ID=" + ZoneID + "' class='text-danger' data-container='body' data-toggle='confirmation' data-placement='top' title='Delete record'> 	<i class='fa fa-trash fa-fw'></i> </a><i class='fa fa-caret - right fa - fw invisible'></i> </td></tr>";
                                //data += "<tr><td runat='server' id='myTable' onclick='javascript: __doPostBack(); '>" + Zone + " <span style='float: right;'><a href='General_Masters/Locations_Mst.aspx?ZoneID=" + ZoneID + "' class='text-success' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='fa fa-edit fa-fw'></i> </a>  <a href='General_Masters/Locations_Mst.aspx?DelZone_ID=" + ZoneID + "' class='text-danger' data-container='body' data-toggle='confirmation' data-placement='top' title='Delete record'> 	<i class='fa fa-trash fa-fw'></i> </a><i class='fa fa-caret - right fa - fw invisible'></i> </td></tr>";
                                data += "<tr><td runat='server' id='myLocationTable'>" + Location + " <span style='float: right;'><a href='Locations_Mst.aspx?LocID=" + LocID + "' class='text-success' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='fa fa-edit fa-fw'></i> </a>  <a href='Locations_Mst.aspx?DelLoc_ID=" + LocID + "' class='text-danger' data-container='body' data-toggle='confirmation' data-placement='top' title='Delete record'> 	<i class='fa fa-trash fa-fw'></i> </a><i class='fa fa-caret - right fa - fw invisible'></i> </td></tr>";

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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }


        [System.Web.Services.WebMethod]
        //[System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        public static void Location_bindgrid1(string Zone)
        {
            ZoneName = Zone;
            Locations_Mst obj = new Locations_Mst();
            obj.Location_bindgrid();

        }

        //[System.Web.Services.WebMethod]
        //public static string GetData()
        //{
        //    Location_bindgrid();
        //    return DateTime.Now.ToString();
        //}

        protected void btnZoneSave_Click(object sender, EventArgs e)
        {
            //int CompanyID = 2;
            int ZoneID = 0;

            try
            {

                if (Convert.ToString(Session["ZoneID"]) != "")
                {
                    ZoneID = Convert.ToInt32(Session["ZoneID"]);
                }
                string Action = "";

                if (ZoneID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                ds = ObjUpkeep.ZoneMaster_CRUD(ZoneID, CompanyID, txtZoneCode.Text.Trim(), txtZoneDesc.Text.Trim(), LoggedInUserID, Action);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 0)
                        {

                        }
                        else if (Status == 1)
                        {
                            Session["ZoneID"] = "";
                            txtZoneCode.Text = "";
                            txtZoneDesc.Text = "";
                            mpeZone.Hide();
                            //Zone_bindgrid();
                            Response.Redirect("~/General_Masters/Locations_Mst.aspx", false);
                        }
                        else if (Status == 3)
                        {
                            lblZoneErrorMsg.Text = "Zone already exists";
                        }
                        else if (Status == 2)
                        {
                            lblZoneErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void btnAddZone_Click(object sender, EventArgs e)
        {

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            txtZoneCode.Text = "";
            txtZoneDesc.Text = "";
            mpeZone.Hide();
        }

        public void FetchZone(int ZoneID)
        {
            try
            {
                ds = ObjUpkeep.ZoneMaster_CRUD(ZoneID, 0, "", "", LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        Session["ZoneID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Zone_ID"]);
                        txtZoneCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["Zone_Code"]);
                        txtZoneDesc.Text = Convert.ToString(ds.Tables[0].Rows[0]["Zone_Desc"]);

                        mpeZone.Show();
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
        }

        protected void btnAddLocation_Click(object sender, EventArgs e)
        {

        }

        protected void btnCloseLoc_Click(object sender, EventArgs e)
        {
            txtLocation.Text = "";
            txtLocationCode.Text = "";
            mpeLocation.Hide();
        }

        protected void btnLocationSave_Click(object sender, EventArgs e)
        {
            int LocID = 0;


            string Zone = "";
            if (Convert.ToString(Session["Zone"]) != "")
            {
                Zone = Convert.ToString(Session["Zone"]);
            }
            else if (ZoneName != "")
            {
                Zone = ZoneName;
                //ZoneName = "";
            }



            //string Zone = Convert.ToString(hdnZone.Value);

            Session["Zone"] = Zone;

            try
            {
                if (Convert.ToString(Session["LocID"]) != "")
                {
                    LocID = Convert.ToInt32(Session["LocID"]);
                }
                string Action = "";

                if (LocID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                ds = ObjUpkeep.LocationMaster_CRUD(LocID, Zone, txtLocationCode.Text.Trim(), txtLocation.Text.Trim(), LoggedInUserID, Action);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 0)
                        {

                        }
                        else if (Status == 1)
                        {
                            Session["LocID"] = "";
                            txtLocationCode.Text = "";
                            txtLocation.Text = "";
                            mpeLocation.Hide();
                            //Zone_bindgrid();
                            Response.Redirect("~/General_Masters/Locations_Mst.aspx", false);
                        }
                        else if (Status == 3)
                        {
                            lblLocationErrorMsg.Text = "Location already exists";
                        }
                        else if (Status == 2)
                        {
                            lblLocationErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSubLocation_Click(object sender, EventArgs e)
        {

        }

        protected void btnCloseSubLoc_Click(object sender, EventArgs e)
        {
            //lblLocation.Text = "";
            txtSubLocation.Text = "";
            txtSubLocationCode.Text = "";
            lblSubLocationErrorMsg.Text = "";
            mpeSubLocation.Hide();
        }

        protected void btnSubLocationSave_Click(object sender, EventArgs e)
        {
            int SubLocID = 0;

            string Loc = "";
            if (Convert.ToString(lblLocation.Text) != "")
            {
                Loc = Convert.ToString(lblLocation.Text);
            }
            //else if (ZoneName != "")
            //{
            //    Loc = ZoneName;
            //    //ZoneName = "";
            //}



            string ZoneName = Convert.ToString(Session["ZoneName"]);

            //Session["Zone"] = Zone;

            try
            {
                if (Convert.ToString(Session["SubLocID"]) != "")
                {
                    SubLocID = Convert.ToInt32(Session["SubLocID"]);
                }
                string Action = "";

                if (SubLocID > 0)
                {
                    Action = "U";
                }
                else
                {
                    Action = "C";
                }

                ds = ObjUpkeep.SubLocationMaster_CRUD(SubLocID, Loc, ZoneName, txtSubLocationCode.Text.Trim(), txtSubLocation.Text.Trim(), LoggedInUserID, Action);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]);
                        if (Status == 0)
                        {

                        }
                        else if (Status == 1)
                        {
                            //Session["LocID"] = "";
                            txtSubLocationCode.Text = "";
                            txtSubLocation.Text = "";
                            mpeSubLocation.Hide();
                            //Zone_bindgrid();
                            Response.Redirect("~/General_Masters/Locations_Mst.aspx", false);
                        }
                        else if (Status == 3)
                        {
                            lblSubLocationErrorMsg.Text = "Sub Location already exists";
                        }
                        else if (Status == 2)
                        {
                            lblSubLocationErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string SubLocation_bindgrid()
        {

            string data = "";
            string Zone = Convert.ToString(Session["ZoneName"]);
            if (Convert.ToString(Session["Zone"]) != "")
            {
                Zone = Convert.ToString(Session["Zone"]);
                //lblZoneName.Text = Zone;
            }
            else if (ZoneName != "")
            {
                Session["ZoneName"] = ZoneName;
                //hdnZoneName.Value = Convert.ToString(Session["Zone"]);
                Zone = ZoneName;
                //ZoneName = "";
            }

            //Session["hdnLocation"]

            string Loc = "";
            //string Loc = lblLocation.Text;
            

            if (Convert.ToString(Session["hdnLocation"]) != "")
            {
                Loc = Convert.ToString(Session["hdnLocation"]);
            }
            if (LocName != "")
            {
                Session["hdnLocation"] = LocName;
                Loc = LocName;
            }

            try
            {
                if (Zone != "")
                {
                    ds = ObjUpkeep.SubLocationMaster_CRUD(0, Loc, Zone, "", "", LoggedInUserID, "R");


                    if (ds.Tables.Count > 1)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                            for (int i = 0; i < count; i++)
                            {
                                int SubLoc_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["SubLoc_ID"]);
                                string SubLocation = Convert.ToString(ds.Tables[0].Rows[i]["SubLocation"]);
                                //string ZoneDesc = Convert.ToString(ds.Tables[0].Rows[i]["Zone_Desc"]);

                                //data += "<tr><td>" + Zone + "</td><td style='float: right;'><a href='General_Masters/Locations_Mst.aspx?ZoneID=" + ZoneID + "' class='text-success' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='fa fa-edit fa-fw'></i> </a>  <a href='General_Masters/Locations_Mst.aspx?DelZone_ID=" + ZoneID + "' class='text-danger' data-container='body' data-toggle='confirmation' data-placement='top' title='Delete record'> 	<i class='fa fa-trash fa-fw'></i> </a><i class='fa fa-caret - right fa - fw invisible'></i> </td></tr>";
                                //data += "<tr><td runat='server' id='myTable' onclick='javascript: __doPostBack(); '>" + Zone + " <span style='float: right;'><a href='General_Masters/Locations_Mst.aspx?ZoneID=" + ZoneID + "' class='text-success' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='fa fa-edit fa-fw'></i> </a>  <a href='General_Masters/Locations_Mst.aspx?DelZone_ID=" + ZoneID + "' class='text-danger' data-container='body' data-toggle='confirmation' data-placement='top' title='Delete record'> 	<i class='fa fa-trash fa-fw'></i> </a><i class='fa fa-caret - right fa - fw invisible'></i> </td></tr>";
                                data += "<tr><td runat='server' id='myTable'>" + SubLocation + " <span style='float: right;'><a href='Locations_Mst.aspx?SubLocID=" + SubLoc_ID + "' class='text-success' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='fa fa-edit fa-fw'></i> </a>  <a href='Locations_Mst.aspx?DelSubLoc_ID=" + SubLoc_ID + "' class='text-danger' data-container='body' data-toggle='confirmation' data-placement='top' title='Delete record'> 	<i class='fa fa-trash fa-fw'></i> </a><i class='fa fa-caret - right fa - fw invisible'></i> </td></tr>";

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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

        public void FetchLocation(int LocID)
        {
            try
            {
                //ds = ObjUpkeep.ZoneMaster_CRUD(ZoneID, 0, "", "", LoggedInUserID, "R");
                ds = ObjUpkeep.LocationMaster_CRUD(LocID, "", "", "", LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["LocID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Loc_ID"]);
                        txtLocationCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["Loc_Code"]);
                        txtLocation.Text = Convert.ToString(ds.Tables[0].Rows[0]["Loc_Desc"]);

                        mpeLocation.Show();
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
        }

        public void FetchSubLocation(int SubLocID)
        {
            try
            {
                //ds = ObjUpkeep.LocationMaster_CRUD(LocID, "", "", "", LoggedInUserID, "R");
                ds = ObjUpkeep.SubLocationMaster_CRUD(SubLocID, "", "", "", "", LoggedInUserID, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["LocID"] = Convert.ToInt32(ds.Tables[0].Rows[0]["Loc_ID"]);
                        txtSubLocationCode.Text = Convert.ToString(ds.Tables[0].Rows[0]["SubLoc_Code"]);
                        txtSubLocation.Text = Convert.ToString(ds.Tables[0].Rows[0]["SubLoc_Desc"]);

                        mpeSubLocation.Show();
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
        }

        [System.Web.Services.WebMethod]
        public static void SubLocation_bindgrid1(string Location)
        {
            LocName = Location;
            Locations_Mst obj = new Locations_Mst();
            obj.SubLocation_bindgrid();

        }


    }
}