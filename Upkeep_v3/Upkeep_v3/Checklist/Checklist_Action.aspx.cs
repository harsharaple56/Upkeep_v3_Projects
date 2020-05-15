using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Configuration;

namespace Upkeep_v3.Checklist
{
    public partial class Checklist_Action : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);

            frmChkList.Action = @"Checklist_Action.aspx";
            if (LoggedInUserID == "")
            {
                //Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
            }
            if (!IsPostBack)
            {
                string TicketNumber = Convert.ToString(Session["TicketNo"]);
                string TicketNoQueryStr = Convert.ToString(Request.QueryString["TicketNo"]);
                //TicketNumber= "CKT10";
                if (TicketNumber != "")
                {
                    BindChecklistDetails(TicketNumber);
                }
                else if (TicketNoQueryStr != "")
                {
                    Session["TicketNo"] = TicketNoQueryStr;
                    BindChecklistDetails(TicketNoQueryStr);
                }
                else
                {
                    Response.Redirect(Page.ResolveClientUrl("~/Login.aspx"), false);
                }
            }
        }

        public void BindChecklistDetails(string TicketNumber)
        {
            DataSet dsChecklstDetails = new DataSet();
            try
            {
                dsChecklstDetails = ObjUpkeep.ChecklistRequest("", 0, 0, 0, 0, 0, "", TicketNumber, LoggedInUserID, "R");

                if (dsChecklstDetails.Tables.Count > 0)
                {
                    if (dsChecklstDetails.Tables[0].Rows.Count > 0)
                    {
                        lblScheduleDateTime.Text = Convert.ToString(dsChecklstDetails.Tables[0].Rows[0]["ScheduleDate"]);
                        lblTicketNo.Text = Convert.ToString(dsChecklstDetails.Tables[0].Rows[0]["TicketId"]);
                        lblFrom.Text = Convert.ToString(dsChecklstDetails.Tables[0].Rows[0]["User"]);
                        lblDepartment.Text = Convert.ToString(dsChecklstDetails.Tables[0].Rows[0]["Dept_Desc"]);
                        lblChecklist.Text = Convert.ToString(dsChecklstDetails.Tables[0].Rows[0]["Chk_Name"]);
                        lblZone.Text = Convert.ToString(dsChecklstDetails.Tables[0].Rows[0]["Zone_Desc"]);
                        lblLocation.Text = Convert.ToString(dsChecklstDetails.Tables[0].Rows[0]["Loc_Desc"]);
                        lblSubLocation.Text = Convert.ToString(dsChecklstDetails.Tables[0].Rows[0]["SubLoc_Desc"]);

                        Session["TicketNo"] = Convert.ToString(dsChecklstDetails.Tables[0].Rows[0]["TicketId"]);

                        string RequestStatus = Convert.ToString(dsChecklstDetails.Tables[0].Rows[0]["Requeststatus"]);

                        if (RequestStatus == "Close")
                        {
                            lblStatusTime.Text = Convert.ToString(dsChecklstDetails.Tables[0].Rows[0]["EndDate"]);
                            //btnSubmit.Attributes.Add("style", "display:none;");
                            btnSubmit.Attributes.Add("disabled", "disabled");
                            dvStatus.Attributes.Add("style", "display:block;");
                        }
                        else
                        {
                            dvStatus.Attributes.Add("style", "display:none;");
                            // btnSubmit.Attributes.Add("style", "display:block;");
                        }
                    }

                    if (dsChecklstDetails.Tables[1].Rows.Count > 0)
                    {
                        rptChecklistPoints.DataSource = dsChecklstDetails.Tables[1];
                        rptChecklistPoints.DataBind();

                    }
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void rptChecklistPoints_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Reference the Repeater Item.
                RepeaterItem item = e.Item;

                //Reference the Controls.
                string lblAnswerType = (item.FindControl("lblAnswerType") as Label).Text;
                HtmlTableCell tdValue2 = (HtmlTableCell)e.Item.FindControl("tdYesNo");

                if (lblAnswerType == "Text")
                {
                    tdValue2.Visible = false;
                }
                //string name = (item.FindControl("lblName") as Label).Text;
                //string country = (item.FindControl("lblCountry") as Label).Text;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataSet dsChecklstDetails = new DataSet();
            try
            {
                List<int> Lst_ValidImage = new List<int>();
                List<int> Lst_ImageSaved = new List<int>();
                List<string> Lst_Images = new List<string>();
                string TicketCode = string.Empty;
                string fileName = string.Empty;

                string CurrentDate = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));

                TicketCode = Convert.ToString(Session["TicketNo"]);

                StringBuilder strXmlChecklist = new StringBuilder();
                strXmlChecklist.Append(@"<?xml version=""1.0"" ?>");
                strXmlChecklist.Append(@"<CHECKLISTPOINT_ROOT>");

                foreach (RepeaterItem item in rptChecklistPoints.Items)
                {
                    Label lblChecklistPointID = (Label)item.FindControl("lblChecklistPointID");
                    RadioButton rdbYes = (RadioButton)item.FindControl("rdbYes");
                    RadioButton rdbNo = (RadioButton)item.FindControl("rdbNo");
                    TextBox txtRemarks = (TextBox)item.FindControl("txtRemarks");
                    FileUpload ChecklistImage = (FileUpload)item.FindControl("FileUpload_ChecklistImage");

                    string FileName = ChecklistImage.FileName;


                    strXmlChecklist.Append(@"<CHECKLIST_ANSWER>");
                    strXmlChecklist.Append(@"<CHECKLIST_POINTID>" + lblChecklistPointID.Text + "</CHECKLIST_POINTID>");
                    strXmlChecklist.Append(@"<CHECKLIST_YES>" + rdbYes.Checked + "</CHECKLIST_YES>");
                    strXmlChecklist.Append(@"<CHECKLIST_NO>" + rdbNo.Checked + "</CHECKLIST_NO>");
                    strXmlChecklist.Append(@"<CHECKLIST_REMARKS>" + txtRemarks.Text + "</CHECKLIST_REMARKS>");
                    strXmlChecklist.Append(@"<CHECKLIST_IMAGE>" + FileName + "</CHECKLIST_IMAGE>");
                    strXmlChecklist.Append(@"</CHECKLIST_ANSWER>");

                    //Image upload start
                    if (ChecklistImage.HasFile)
                    {
                        string fileUploadPath = HttpContext.Current.Server.MapPath("~/TicketImages/" + CurrentDate);
                        if (!Directory.Exists(fileUploadPath))
                        {
                            Directory.CreateDirectory(fileUploadPath);
                        }

                        int i = 0;

                        foreach (HttpPostedFile postfiles in ChecklistImage.PostedFiles)
                        {
                            string filetype = Path.GetExtension(postfiles.FileName);
                            if (filetype.ToLower() == ".jpg" || filetype.ToLower() == ".png")
                            {
                                Lst_ValidImage.Add(1);
                            }
                            else
                            {
                                Lst_ValidImage.Add(0);
                            }
                        }
                        foreach (HttpPostedFile postfiles in ChecklistImage.PostedFiles)
                        {
                            //for (int i = 0; i < FileUpload_TicketImage.PostedFiles.Count; i++)
                            //{

                            string filetype = Path.GetExtension(postfiles.FileName);
                            if (filetype.ToLower() == ".jpg" || filetype.ToLower() == ".png")
                            {
                                try
                                {

                                    fileName = TicketCode + "_"+ lblChecklistPointID.Text + "_" + Convert.ToString(i) + filetype;
                                    //fileName = postfiles.FileName;

                                    string imgPath = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadURL"]);

                                    //string fileUploadPath = HttpContext.Current.Server.MapPath("~/TicketImages/" + fileName);
                                    // FileUpload_TicketImage.SaveAs(Server.MapPath("~/") + fileName);

                                    string SaveLocation = Server.MapPath("~/TicketImages/" + CurrentDate) + "/" + fileName;
                                    string FileLocation = imgPath+"/TicketImages/" + CurrentDate + "/" + fileName+"*"+ lblChecklistPointID.Text;
                                    //string SaveLocation = Server.MapPath(filePath) + fileName;
                                    //File.Copy(SaveLocation, imgPath);

                                    //[+][Size Compress]
                                    string ImageName = Path.GetFileName(postfiles.FileName);
                                    //string storedb = "Images/" + ImageName + "";
                                    //string targetPath = Server.MapPath("Images/" + ImageName);
                                    Stream strm = postfiles.InputStream;  //FileUpload_TicketImage.PostedFile.InputStream;
                                    var targetFile = SaveLocation;
                                    //ReduceImageSize(0.5, strm, targetFile);
                                    //GenerateThumbnails(0.5, strm, targetFile);
                                    //[-][Size Compress]



                                    //string SaveLocation = Server.MapPath(imgPath) + fileName;

                                    if (!Lst_ValidImage.Contains(0))
                                    {
                                        //FileUpload_TicketImage.PostedFile.SaveAs(SaveLocation);
                                        postfiles.SaveAs(SaveLocation);
                                        //Lst_Images.Add(SaveLocation);
                                        Lst_Images.Add(FileLocation);
                                    }

                                    //ImagesList.Append(fileName);
                                    //abc += fileName;
                                }
                                catch (Exception ex)
                                {

                                    //Is_ImageSaved = false;
                                    Lst_ImageSaved.Add(0); // Image failed to save
                                    throw ex;
                                }
                            }
                            else
                            {
                                //Is_ValidImage = false;
                                Lst_ValidImage.Add(0);  // image extension is not proper
                            }
                            //}

                            i = i + 1;
                        }
                    }


                    //Image Upload End
                }

                strXmlChecklist.Append(@"</CHECKLISTPOINT_ROOT>");

                string TicketNumber = Convert.ToString(Session["TicketNo"]);

                if (Lst_ValidImage.Contains(0))
                {
                    lblTicketErrorMsg.Text = "Image format not supported";

                }
                else if (Lst_ImageSaved.Contains(0))
                {
                    lblTicketErrorMsg.Text = "Image upload failed, please try again";
                }

                else
                {
                    string list_Images = String.Join(",", Lst_Images);

                    dsChecklstDetails = ObjUpkeep.Update_ChecklistPoints(TicketNumber, strXmlChecklist.ToString(), list_Images, LoggedInUserID);
                    if (dsChecklstDetails.Tables.Count > 0)
                    {
                        if (dsChecklstDetails.Tables[0].Rows.Count > 0)
                        {
                            int Status = Convert.ToInt32(dsChecklstDetails.Tables[0].Rows[0]["Status"]);
                            if (Status == 1)
                            {
                                Session["TicketNo"] = "";
                                //Session["TicketNo"] = Convert.ToString(dsAChecklistReq.Tables[1].Rows[0]["TicketId"]);
                                Response.Redirect(Page.ResolveClientUrl("~/Checklist/MyChecklist.aspx"), false);
                            }

                            else if (Status == 2)
                            {
                                //lblChecklstErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly try after some time";
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["TicketNo"] = "";
            Response.Redirect(Page.ResolveClientUrl("~/Checklist/MyChecklist.aspx"), false);
        }
    }
}