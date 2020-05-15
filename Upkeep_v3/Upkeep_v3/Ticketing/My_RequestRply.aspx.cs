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

namespace Upkeep_v3.Ticketing
{
    public partial class My_RequestRply : System.Web.UI.Page
    {
        Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
            int TicketID = Convert.ToInt32(Request.QueryString["TicketID"]);
            //Session["TicketID"]= Convert.ToString(Session["TicketID"]);
            //string SessionUser = Session["User"].ToString();  //Sam

            if (TicketID > 0)
            {
                Session["TicketID"] = Convert.ToString(TicketID);
                bind_Master(TicketID);

            }


        }

        public string bind_Master(int TicketID)
        {
            string data = "";
            DataSet dsTicket = new DataSet();
            try
            {
                dsTicket = ObjUpkeep.Insert_Ticket_Details((Request.QueryString["TicketID"]), 0, 0, 0, 0, 0, "", "", LoggedInUserID, "R");

                // int TicketID = 0;
                string TicketNumber = string.Empty;
                string Zone = string.Empty;
                string Location = string.Empty;
                string SubLocation = string.Empty;
                string Category = string.Empty;
                string SubCategory = string.Empty;
                string RequestDate = string.Empty;
                string RequestStatus = string.Empty;
                string ActionStatus = string.Empty;


                if (dsTicket.Tables.Count > 0)
                {
                    if (dsTicket.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(dsTicket.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            Session["TicketCode"] = dsTicket.Tables[0].Rows[i].Field<string>("Tkt_Code"); //ajay
                            lblTicketID.Text = dsTicket.Tables[0].Rows[i].Field<string>("Tkt_Code");
                            lblZone.Text = dsTicket.Tables[0].Rows[i].Field<string>("Zone_Desc");
                            lblLocation.Text = dsTicket.Tables[0].Rows[i].Field<string>("Loc_Desc");
                            lblSubLocation.Text = dsTicket.Tables[0].Rows[i].Field<string>("SubLoc_Desc");
                            lblCategory.Text = dsTicket.Tables[0].Rows[i].Field<string>("Category_Desc");
                            lblSubCategory.Text = dsTicket.Tables[0].Rows[i].Field<string>("SubCategory_Desc");
                            lblRequestDate.Text = dsTicket.Tables[0].Rows[i].Field<string>("Ticket_Date");
                            lblTicketdesc.Text = dsTicket.Tables[0].Rows[i].Field<string>("Tkt_Message");

                            rptTicketImage.DataSource = dsTicket.Tables[0];
                            rptTicketImage.DataBind();


                            // lblTicketID.Text = Convert.ToInt32(dsTicket.Tables[0].Rows[i]["Ticket_ID"]);
                            //TicketNumber = Convert.ToString(dsTicket.Tables[0].Rows[i]["Tkt_Code"]);
                            //Zone = Convert.ToString(dsTicket.Tables[0].Rows[i]["Zone_Desc"]);
                            //Location = Convert.ToString(dsTicket.Tables[0].Rows[i]["Loc_Desc"]);
                            //SubLocation = Convert.ToString(dsTicket.Tables[0].Rows[i]["SubLoc_Desc"]);
                            //Category = Convert.ToString(dsTicket.Tables[0].Rows[i]["Category_Desc"]);
                            //SubCategory = Convert.ToString(dsTicket.Tables[0].Rows[i]["SubCategory_Desc"]);
                            //RequestDate = Convert.ToString(dsTicket.Tables[0].Rows[i]["Ticket_Date"]);
                            //RequestStatus = Convert.ToString(dsTicket.Tables[0].Rows[i]["Tkt_Status"]);
                            //ActionStatus = Convert.ToString(dsTicket.Tables[0].Rows[i]["Tkt_ActionStatus"]);

                            //data += "<tr><td>" + TicketNumber + "</td><td>" + Zone + "</td><td>" + Location + "</td><td>" + SubLocation + "</td><td>" + Category + "</td><td>" + SubCategory + "</td><td>" + RequestDate + "</td><td>" + RequestStatus + "</td><td>" + ActionStatus + "</td><td><a href='Add_MyRequest.aspx?TicketID=" + TicketID + "' class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' data-placement='top' title='Edit record'> <i id='btnedit' runat='server' class='la la-edit'></i> </a>   </td></tr>";
                            // data += "<tr><td> <a href='My_RequestRply.aspx?TicketID=" + TicketID + "' style='text-decoration: underline;' > " + TicketNumber + " </a></td><td>" + Zone + "</td><td>" + Location + "</td><td>" + SubLocation + "</td><td>" + Category + "</td><td>" + SubCategory + "</td><td>" + RequestDate + "</td><td>" + RequestStatus + "</td><td>" + ActionStatus + "</td></tr>";

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


        protected void btnViewWorkflow_Click(object sender, EventArgs e)
        {

        }


        protected void btnClose_Click(object sender, EventArgs e)
        {
            Close_Ticket();


        }

        ////Added by Sam
        //public string Close_Ticket()
        //{
        //    string data = "";
        //    string imgPath = string.Empty;
        //    string CloseTicketDesc = txtCloseTicketDesc.Text;
        //    string strTicketID = Convert.ToString((Request.QueryString["TicketID"]));
        //    DataSet dsCloseTicket = new DataSet();
        //     try
        //    {

        //        dsCloseTicket = ObjUpkeep.Close_Ticket_Details(strTicketID, CloseTicketDesc, LoggedInUserID,imgPath);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return data;
        //}


        public void Close_Ticket()
        {


            //string data = "";
            string imgPath = string.Empty;
            string CloseTicketDesc = txtCloseTicketDesc.Text;
            string strTicketID = Convert.ToString((Request.QueryString["TicketID"]));
            List<int> Lst_ValidImage = new List<int>();
            List<int> Lst_ImageSaved = new List<int>();
            List<string> Lst_Images = new List<string>();
            string TicketImages = string.Empty;
            StringBuilder ImagesList = new StringBuilder();



            string fileName = string.Empty;
            string TicketCode = string.Empty;
            string CurrentDate = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));
            TicketCode = Convert.ToString(Session["TicketCode"]);

            string list_Images = string.Empty;  //sam

            DataSet dsCloseTicket = new DataSet();
            //try
            //{

            //    dsCloseTicket = ObjUpkeep.Close_Ticket_Details(strTicketID, CloseTicketDesc, LoggedInUserID, imgPath);

            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //return data;


            try
            {
                if (FileUpload_TicketImage.HasFile)
                {
                string fileUploadPath = HttpContext.Current.Server.MapPath("~/TicketImages/" + CurrentDate);

                  if (!Directory.Exists(fileUploadPath))
                  {
                    Directory.CreateDirectory(fileUploadPath);
                  }

                int i = 0;

                foreach (HttpPostedFile postfiles in FileUpload_TicketImage.PostedFiles)
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
                foreach (HttpPostedFile postfiles in FileUpload_TicketImage.PostedFiles)
                {
                    //for (int i = 0; i < FileUpload_TicketImage.PostedFiles.Count; i++)
                    //{

                    string filetype = Path.GetExtension(postfiles.FileName);
                    if (filetype.ToLower() == ".jpg" || filetype.ToLower() == ".png")
                    {
                        try
                        {
                            fileName = TicketCode + "_Close_" + Convert.ToString(i) + filetype;
                            //fileName = postfiles.FileName;

                             imgPath = Convert.ToString(ConfigurationManager.AppSettings["TicketImagePath"]);

                            //string fileUploadPath = HttpContext.Current.Server.MapPath("~/TicketImages/" + fileName);
                            // FileUpload_TicketImage.SaveAs(Server.MapPath("~/") + fileName);

                            string SaveLocation = Server.MapPath("~/TicketImages/" + CurrentDate) + "/" + fileName;
                            //string SaveLocation = Server.MapPath(filePath) + fileName;
                            //File.Copy(SaveLocation, imgPath);

                            //string SaveLocation = Server.MapPath(imgPath) + fileName;

                            if (!Lst_ValidImage.Contains(0))
                            {
                                //FileUpload_TicketImage.PostedFile.SaveAs(SaveLocation);
                                postfiles.SaveAs(SaveLocation);
                                Lst_Images.Add(SaveLocation);
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
                if (Lst_ValidImage.Contains(0))
                {
                    lblTicketErrorMsg.Text = "Image format not supported";
                    FileUpload_TicketImage.Focus();
                }
                else if (Lst_ImageSaved.Contains(0))
                {
                    lblTicketErrorMsg.Text = "Image upload failed, please try again";
                    //txtTicketDesc.Focus(); //sam
                }
                else
                {
                    //Save details       
                    //DataSet dsTicketSave = new DataSet();
                    try
                    {
                         list_Images = String.Join(",", Lst_Images);


                            //string title = "Greetings";
                            //string body = "Welcome to ASPSnippets.com";
                            //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);

                            dsCloseTicket = ObjUpkeep.Close_Ticket_Details(strTicketID, CloseTicketDesc, LoggedInUserID,list_Images);                        //mpeTicketSaveSuccess.Show();


                            //Samvedna
                        //    if (dsTicketSave.Tables.Count > 0)
                        //{
                        //    if (dsTicketSave.Tables[0].Rows.Count > 0)
                        //    {
                        //        int Status = Convert.ToInt32(dsTicketSave.Tables[0].Rows[0]["Status"]);
                        //        if (Status == 1)
                        //        {
                        //            lblTicketCode.Text = TicketCode;
                        //            Session["NextTicketCode"] = "";
                        //            mpeTicketSaveSuccess.Show();
                        //        }
                        //    }
                        //}


                    }

                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                lblTicketErrorMsg.Text = "Please select image";
                FileUpload_TicketImage.Focus();
            }
        }
            catch (Exception ex)
            {
                throw ex;
            }




}



    }

}
    