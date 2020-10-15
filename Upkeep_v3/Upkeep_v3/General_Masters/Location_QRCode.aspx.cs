using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Text;
using System.IO;
using System.Drawing;
using QRCoder;
using System.Drawing.Printing;

namespace Upkeep_v3.General_Masters
{
    public partial class Location_QRCode : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            CompanyID = Convert.ToInt32(Session["CompanyID"]);
            if (string.IsNullOrEmpty(LoggedInUserID))
            {
                Response.Redirect("~/Login.aspx", false);
                return;
            }

            if (!IsPostBack)
            {
                Bind_Locations();
            }
        }

        public void Bind_Locations()
        {
            DataSet dsLocation = new DataSet();
            try
            {
                dsLocation = ObjUpkeep.Fetch_LocationTree(CompanyID);

                if (dsLocation.Tables.Count > 0)
                {
                    if (dsLocation.Tables[0].Rows.Count > 0)
                    {
                        gvLocation_QRCode.DataSource = dsLocation.Tables[0];
                        gvLocation_QRCode.DataBind();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvLocation_QRCode_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //check if the row is the header row
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //add the thead and tbody section programatically
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void btnGenerateQRCode_Click(object sender, EventArgs e)
        {

            try
            {
                string LocationID22 = string.Empty;
                string LocationQR = string.Empty;
                string QRFileLocation = string.Empty;

                var rows = gvLocation_QRCode.Rows;
                int count = gvLocation_QRCode.Rows.Count;

                LocationQR objLocation = new LocationQR();
                //objLocation.LocationID = 1;
                //objLocation.Location = "";

                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5] { new DataColumn("LocId", typeof(int)),
                            new DataColumn("LocName", typeof(string)),
                            new DataColumn("LocationQR", typeof(string)),
                            new DataColumn("CompanyName",typeof(string)),
                            new DataColumn("CompanyLogo",typeof(string))});

                //StringBuilder strXmlLocation = new StringBuilder();
                //strXmlLocation.Append(@"<?xml version=""1.0"" ?>");
                //strXmlLocation.Append(@"<RootLocation>");

                string fileUploadPath = HttpContext.Current.Server.MapPath("~/General_Masters/LocationQRCodes/" + Convert.ToString(Session["CompanyCode"]));

                if (!Directory.Exists(fileUploadPath))
                {
                    Directory.CreateDirectory(fileUploadPath);
                }
                else
                {
                    System.IO.DirectoryInfo di = new DirectoryInfo(fileUploadPath);
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                }
                
                for (int i = 0; i < count; i++)
                {
                    

                    bool isChecked = ((CheckBox)rows[i].FindControl("ChkIndividual")).Checked;
                    if (isChecked)
                    {
                        //string EmployeeID = gvEmployee.Rows[i].Cells[1].Text;
                        string LocID = ((HiddenField)rows[i].FindControl("hdnLocationID")).Value;
                        string LocationName = gvLocation_QRCode.Rows[i].Cells[1].Text;
                        LocationName = LocationName.Replace("&gt;",">");
                        objLocation.LocationID = Convert.ToInt32(LocID);
                        objLocation.Location = Convert.ToString(LocationName);

                        string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(objLocation);

                        QRCoder.QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
                        QRCoder.QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(jsonString, QRCoder.QRCodeGenerator.ECCLevel.Q);
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        imgBarCode.Height = 150;
                        imgBarCode.Width = 150;
                        using (Bitmap bitMap = qrCode.GetGraphic(20))
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                byte[] byteImage = ms.ToArray();
                                //imgQR.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                                LocationQR =  Convert.ToBase64String(byteImage);
                                //byte[] bytes = Convert.FromBase64String(Convert.ToBase64String(byteImage));
                                //System.Drawing.Image image;
                                //image = System.Drawing.Image.FromStream(ms);
                                //LocationID22 = byteImage.ToString();
                                byte[] imageBytes = Convert.FromBase64String(LocationQR);

                                //Save the Byte Array as Image File.
                                string filePath = Server.MapPath("~/General_Masters/LocationQRCodes/" + Convert.ToString(Session["CompanyCode"])+"/" + Convert.ToString(objLocation.LocationID)+".png");
                                File.WriteAllBytes(filePath, imageBytes);
                                string imgPath = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadURL"]);
                                QRFileLocation = imgPath + "/General_Masters/LocationQRCodes/" + Convert.ToString(Session["CompanyCode"]) + "/" + Convert.ToString(objLocation.LocationID + ".png");
                            }
                        }
                        // imageTable.Rows.Add(Convert.ToBase64String((byte[])reader["img_storage"]));
                        dt.Rows.Add(new Object[]{
                                        objLocation.LocationID,
                                        objLocation.Location,
                                        QRFileLocation,
                                        Convert.ToString(Session["CompanyName"]),
                                        Convert.ToString(Session["CompanyLogo"])
                                    });

                        dt.AcceptChanges();


                        //strXmlLocation.Append(@"<Location>");
                        //strXmlLocation.Append(@"<LocID>" + objLocation.LocationID + "</LocID>");
                        //strXmlLocation.Append(@"<LocName>" + objLocation.Location + "</LocName>");
                        //strXmlLocation.Append(@"<LocQR>" + QRFileLocation + "</LocQR>");
                        //strXmlLocation.Append(@"<CompanyName>" + Convert.ToString(Session["CompanyName"]) + "</CompanyName>");
                        //strXmlLocation.Append(@"<CompanyLogo>" + Convert.ToString(Session["CompanyLogo"]) + "</CompanyLogo>");
                        //strXmlLocation.Append(@"</Location>");

                    }
                }

                //strXmlLocation.Append(@"</RootLocation>");
                //Session["LocQRXML"] = strXmlLocation.ToString();

                Session.Add("dtLocationQR", dt);

                DataTable Tissues = (DataTable)Session["dtLocationQR"];

                Response.Redirect(Page.ResolveClientUrl("~/General_Masters/Print_LocationQRCode.aspx"), false);


                //string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(objLocation);

                //QRCoder.QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
                //QRCoder.QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(jsonString, QRCoder.QRCodeGenerator.ECCLevel.Q);
                //System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                //imgBarCode.Height = 150;
                //imgBarCode.Width = 150;
                //using (Bitmap bitMap = qrCode.GetGraphic(20))
                //{
                //    using (MemoryStream ms = new MemoryStream())
                //    {
                //        bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                //        byte[] byteImage = ms.ToArray();
                //        imgQR.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                //    }
                //}

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chckheader = (CheckBox)gvLocation_QRCode.HeaderRow.FindControl("checkAll");

            foreach (GridViewRow row in gvLocation_QRCode.Rows)
            {

                CheckBox chckrw = (CheckBox)row.FindControl("ChkIndividual");

                if (chckheader.Checked == true)

                {
                    chckrw.Checked = true;
                }
                else

                {
                    chckrw.Checked = false;
                }

            }
        }
    }

    public class LocationQR
    {
        public int LocationID { get; set; }
        public string Location { get; set; }
    }
}