using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Configuration;
using System.Linq;

namespace Upkeep_v3.CSM
{
	public partial class Raise_Service_Request : System.Web.UI.Page
	{

		#region Global variables
		Upkeep_V3_Services.Upkeep_V3_Services ObjUpkeep = new Upkeep_V3_Services.Upkeep_V3_Services();
		string LoggedInUserID = string.Empty;
		string SessionVisitor = string.Empty;
		DataSet dsConfig = new DataSet();
		//int CompanyID = 0;
		int ConfigID = 0;
		#endregion
		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			string strConfigID = string.Empty;
			string strRequestID = string.Empty;

			LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
			if (!IsPostBack)
			{
				if (!System.String.IsNullOrWhiteSpace(Request.QueryString["ConfigID"]))
				{
					strConfigID = Request.QueryString["ConfigID"].ToString();
					if (strConfigID.All(char.IsDigit))
						ViewState["ConfigID"] = Convert.ToInt32(strConfigID);

					BindCSMConfig();
					divClosing.Visible = false;
				}
				else if (!System.String.IsNullOrWhiteSpace(Request.QueryString["RequestID"]))
				{
					strRequestID = Request.QueryString["RequestID"].ToString();
					if (strRequestID.All(char.IsDigit))
					{
						ViewState["RequestID"] = Convert.ToInt32(strRequestID);

						FetchSectionHeaderData();
						divClosing.Visible = true;
					}

				}
			}
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{
			//string WpTitleSelectedID = "";
			//WpTitleSelectedID = ddlVMSTitle.SelectedValue;
			//if (ValidateData() == false)
			//{
			//    //ddlVMSTitle.SelectedValue = "0";
			//    //ddlVMSTitle.SelectedValue = WpTitleSelectedID;
			//    //setVMSData();
			//    SetRepeater();
			//    return;
			//}

			SaveServiceData();
		}
		protected void btnReject_Click(object sender, EventArgs e)
		{
			ViewState["Action"] = 'R';
			SaveServiceData();
		}

		protected void rptQuestionDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				//Reference the Repeater Item.
				RepeaterItem item = e.Item;

				string AnswerType = (e.Item.FindControl("hdnAnswerTypeSDesc") as HiddenField).Value;
				string HeadId = (e.Item.FindControl("hfQuestionId") as HiddenField).Value;

				if (AnswerType == "MSLCT") //Multi Selection [CheckBox]
				{
					HtmlGenericControl sample = e.Item.FindControl("divCheckBox") as HtmlGenericControl;
					sample.Attributes.Remove("style");
				}
				else if (AnswerType == "SSLCT") //Single Selection [Radio Button]
				{
					HtmlGenericControl sample = e.Item.FindControl("divRadioButton") as HtmlGenericControl;
					sample.Attributes.Remove("style");
				}
				else if (AnswerType == "IMAGE") //Image Upload  
				{
					HtmlGenericControl sample = e.Item.FindControl("divImage") as HtmlGenericControl;
					sample.Attributes.Remove("style");
				}
				else if (AnswerType == "NUMBR") //Number Text Field
				{
					HtmlGenericControl sample = e.Item.FindControl("divNumber") as HtmlGenericControl;
					sample.Attributes.Remove("style");
				}
				else if (AnswerType == "STEXT") //Normal Text Field
				{
					HtmlGenericControl sample = e.Item.FindControl("divText") as HtmlGenericControl;
					sample.Attributes.Remove("style");
				}
				else if (AnswerType == "LTEXT") // Textarea Field
				{
					HtmlGenericControl sample = e.Item.FindControl("divTextArea") as HtmlGenericControl;
					sample.Attributes.Remove("style");
				}
				else  //Normal Text Field
				{
					HtmlGenericControl sample = e.Item.FindControl("divText") as HtmlGenericControl;
					sample.Attributes.Remove("style");
				}


				//Repeater rptRadio = e.Item.FindControl("rptRadio") as Repeater;

				DataSet dsVMSQuestion = new DataSet();
				dsVMSQuestion = dsConfig.Copy(); //ObjUpkeep.Bind_VMSConfiguration(sPublicConfigId);

				DataTable dt = new DataTable();
				dt = dsVMSQuestion.Tables[2].Copy();
				dt.DefaultView.RowFilter = "Open_Qn_ID = " + Convert.ToString(HeadId) + "";
				dt = dt.DefaultView.ToTable();

				if (AnswerType == "SSLCT")
				{
					RadioButtonList divRadioButtonrdbYes = e.Item.FindControl("divRadioButtonrdbYes") as RadioButtonList;

					if (dt.Rows.Count > 0)
					{
						//rptRadio.DataSource = dt;
						//rptRadio.DataBind(); 
						divRadioButtonrdbYes.DataTextField = "Ans_Type_Data"; // "Ans_Type_Desc";
						divRadioButtonrdbYes.DataValueField = "Ans_Type_Data_ID";  // "Ans_Type_ID";// 
						divRadioButtonrdbYes.DataSource = dt;
						divRadioButtonrdbYes.DataBind();
					}
					else
					{
						DataTable dt1 = new DataTable();
						//rptRadio.DataSource = dt1;
						//rptRadio.DataBind();
						divRadioButtonrdbYes.DataSource = dt;
						divRadioButtonrdbYes.DataBind();
					}

				}
				else if (AnswerType == "MSLCT")
				{
					CheckBoxList divCheckBoxIDI = e.Item.FindControl("divCheckBoxIDI") as CheckBoxList;
					if (dt.Rows.Count > 0)
					{
						//rptRadio.DataSource = dt;
						//rptRadio.DataBind(); 
						divCheckBoxIDI.DataTextField = "Ans_Type_Data"; // "Ans_Type_Desc";
						divCheckBoxIDI.DataValueField = "Ans_Type_Data_ID";  // "Ans_Type_ID";// 
						divCheckBoxIDI.DataSource = dt;
						divCheckBoxIDI.DataBind();
					}
					else
					{
						DataTable dt1 = new DataTable();
						//rptRadio.DataSource = dt1;
						//rptRadio.DataBind();
						divCheckBoxIDI.DataSource = dt;
						divCheckBoxIDI.DataBind();
					}
				}

			}
		}

		protected void rptCloseQuestionDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				//Reference the Repeater Item.
				RepeaterItem item = e.Item;

				string AnswerType = (e.Item.FindControl("hdnAnswerTypeSDesc") as HiddenField).Value;
				string HeadId = (e.Item.FindControl("hfQuestionId") as HiddenField).Value;

				if (AnswerType == "MSLCT") //Multi Selection [CheckBox]
				{
					HtmlGenericControl sample = e.Item.FindControl("divCheckBox") as HtmlGenericControl;
					sample.Attributes.Remove("style");
				}
				else if (AnswerType == "SSLCT") //Single Selection [Radio Button]
				{
					HtmlGenericControl sample = e.Item.FindControl("divRadioButton") as HtmlGenericControl;
					sample.Attributes.Remove("style");
				}
				else if (AnswerType == "IMAGE") //Image Upload  
				{
					HtmlGenericControl sample = e.Item.FindControl("divImage") as HtmlGenericControl;
					sample.Attributes.Remove("style");
				}
				else if (AnswerType == "NUMBR") //Number Text Field
				{
					HtmlGenericControl sample = e.Item.FindControl("divNumber") as HtmlGenericControl;
					sample.Attributes.Remove("style");
				}
				else if (AnswerType == "STEXT") //Normal Text Field
				{
					HtmlGenericControl sample = e.Item.FindControl("divText") as HtmlGenericControl;
					sample.Attributes.Remove("style");
				}
				else if (AnswerType == "LTEXT") // Textarea Field
				{
					HtmlGenericControl sample = e.Item.FindControl("divTextArea") as HtmlGenericControl;
					sample.Attributes.Remove("style");
				}
				else  //Normal Text Field
				{
					HtmlGenericControl sample = e.Item.FindControl("divText") as HtmlGenericControl;
					sample.Attributes.Remove("style");
				}


				//Repeater rptRadio = e.Item.FindControl("rptRadio") as Repeater;

				DataSet dsVMSQuestion = new DataSet();
				dsVMSQuestion = dsConfig.Copy(); //ObjUpkeep.Bind_VMSConfiguration(sPublicConfigId);

				DataTable dt = new DataTable();
				dt = dsVMSQuestion.Tables[4].Copy();
				dt.DefaultView.RowFilter = "Close_Qn_ID = " + Convert.ToString(HeadId) + "";
				dt = dt.DefaultView.ToTable();

				if (AnswerType == "SSLCT")
				{
					RadioButtonList divRadioButtonrdbYes = e.Item.FindControl("divRadioButtonrdbYes") as RadioButtonList;

					if (dt.Rows.Count > 0)
					{
						//rptRadio.DataSource = dt;
						//rptRadio.DataBind(); 
						divRadioButtonrdbYes.DataTextField = "Ans_Type_Data"; // "Ans_Type_Desc";
						divRadioButtonrdbYes.DataValueField = "Ans_Type_Data_ID";  // "Ans_Type_ID";// 
						divRadioButtonrdbYes.DataSource = dt;
						divRadioButtonrdbYes.DataBind();
					}
					else
					{
						DataTable dt1 = new DataTable();
						//rptRadio.DataSource = dt1;
						//rptRadio.DataBind();
						divRadioButtonrdbYes.DataSource = dt;
						divRadioButtonrdbYes.DataBind();
					}

				}
				else if (AnswerType == "MSLCT")
				{
					CheckBoxList divCheckBoxIDI = e.Item.FindControl("divCheckBoxIDI") as CheckBoxList;
					if (dt.Rows.Count > 0)
					{
						//rptRadio.DataSource = dt;
						//rptRadio.DataBind(); 
						divCheckBoxIDI.DataTextField = "Ans_Type_Data"; // "Ans_Type_Desc";
						divCheckBoxIDI.DataValueField = "Ans_Type_Data_ID";  // "Ans_Type_ID";// 
						divCheckBoxIDI.DataSource = dt;
						divCheckBoxIDI.DataBind();
					}
					else
					{
						DataTable dt1 = new DataTable();
						//rptRadio.DataSource = dt1;
						//rptRadio.DataBind();
						divCheckBoxIDI.DataSource = dt;
						divCheckBoxIDI.DataBind();
					}
				}

			}
		}

		protected void btnSuccessOk_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(LoggedInUserID) && !string.IsNullOrEmpty(SessionVisitor))
				Response.Redirect("http://www.efacilito.com");
			else
				Response.Redirect(Page.ResolveClientUrl("~/CSM/Service_Requests.aspx"), false);
		}

		#endregion

		#region Functions

		private void BindCSMConfig()
		{
			try
			{
				//lblRequestDate.Text = DateTime.Now.ToString("dd/MMM/yyyy hh:mm tt");


				if (!IsPostBack)
				{
					ConfigID = Convert.ToInt32(ViewState["ConfigID"]);
					dsConfig = ObjUpkeep.Bind_CSMConfiguration(ConfigID);

					if (!Convert.ToString(dsConfig.Tables[0].Rows[0]["Request_Flow_ID"] ?? "").Contains(LoggedInUserID))
					{
						Response.Write(@"<script>alert('You are not authorized to raise this request.');
							window.location = '" + Page.ResolveClientUrl("~/CSM/List_Service_Requests_Type.aspx") + @"';</script>");
					}

					if (!System.String.IsNullOrWhiteSpace(dsConfig.Tables[0].Rows[0]["Company_ID"].ToString()))
					{
						ViewState["CompanyID"] = dsConfig.Tables[0].Rows[0]["Company_ID"];
					}


					if (ViewState["RequestID"] == null)
					{
						rptQuestionDetails.DataSource = dsConfig.Tables[1];
						rptQuestionDetails.DataBind();
					}
					else
					{
						rptCloseQuestionDetails.DataSource = dsConfig.Tables[3];
						rptCloseQuestionDetails.DataBind();
					}
					if (dsConfig.Tables.Count > 4)
					{
						rptTermsCondition.DataSource = dsConfig.Tables[5];
						rptTermsCondition.DataBind();
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void SaveServiceData()
		{
			try
			{
				#region UserData
				int RequestID = 0;
				char Action = 'N';
				if (ViewState["Action"] != null)
				{
					Action = Convert.ToChar(ViewState["Action"]);
				}
				if (ViewState["RequestID"] != null)
				{
					RequestID = Convert.ToInt32(ViewState["RequestID"]);
				}
				ConfigID = Convert.ToInt32(ViewState["ConfigID"]);

				#endregion

				#region Question
				/*
				 Create table and store data in table and convert later in xml and pass in to Datatbase..
				 Table Structure :  QuestionID | AnswerID | Data
				*/

				string strCSMData = "";

				DataTable dt = new DataTable();
				dt.Clear();
				dt.TableName = "TableQuestion";
				dt.Columns.Add("QuestionID");
				dt.Columns.Add("AnswerID");
				dt.Columns.Add("Data");
				// dtRow["SectionID"] = ""; dtRow["QuestionID"] = ""; dtRow["AnswerID"] = ""; dtRow["Data"] = ""; 

				string Is_Not_Valid = "False";

				if (Action == 'N')
					foreach (RepeaterItem itemQuestion in rptQuestionDetails.Items)
					{

						string AnswerType = (itemQuestion.FindControl("hdnAnswerTypeSDesc") as HiddenField).Value;
						string Is_Mandatory = Convert.ToString((itemQuestion.FindControl("hdnIs_Mandatory") as HiddenField).Value);
						Label lblQuestionErr = (itemQuestion.FindControl("lblQuestionErr") as Label);
						string isField = "False";

						int AnswerTypeID = Convert.ToInt32((itemQuestion.FindControl("hdnAnswerID") as HiddenField).Value);
						string HeadId = (itemQuestion.FindControl("hfQuestionId") as HiddenField).Value;

						if (AnswerType == "MSLCT") //Multi Selection [CheckBox]
						{
							CheckBoxList divCheckBoxIDI = itemQuestion.FindControl("divCheckBoxIDI") as CheckBoxList;
							List<String> chkStrList = new List<string>();


							foreach (ListItem item in divCheckBoxIDI.Items)
							{
								if (item.Selected)
								{
									isField = "True";

									chkStrList.Add(item.Value);
									DataRow dtRow = dt.NewRow();
									dtRow["QuestionID"] = HeadId;
									dtRow["AnswerID"] = AnswerTypeID;
									dtRow["Data"] = item.Value;
									dt.Rows.Add(dtRow);
								}
							}

							if (Is_Mandatory == "*")
							{
								if (isField == "False")
								{
									Is_Not_Valid = "True";
									lblQuestionErr.Text = "Please provide valid data.";
								}
							}

							//String YrStr = String.Join(";", chkStrList.ToArray());
						}
						else if (AnswerType == "SSLCT") //Single Selection [Radio Button]
						{
							RadioButtonList divRadioButtonrdbYes = itemQuestion.FindControl("divRadioButtonrdbYes") as RadioButtonList;
							List<String> RadioStrList = new List<string>();
							foreach (ListItem item in divRadioButtonrdbYes.Items)
							{
								if (item.Selected)
								{
									isField = "True";
									RadioStrList.Add(item.Value);

									DataRow dtRow = dt.NewRow();
									dtRow["QuestionID"] = HeadId;
									dtRow["AnswerID"] = AnswerTypeID;
									dtRow["Data"] = item.Value;
									dt.Rows.Add(dtRow);
								}
							}
							if (Is_Mandatory == "*")
							{
								if (isField == "False")
								{
									Is_Not_Valid = "True";
									lblQuestionErr.Text = "Please provide valid data.";
								}
							}
							//String YrStr = String.Join(";", RadioStrList.ToArray());

						}
						else if (AnswerType == "IMAGE") //Image Upload  
						{
							HtmlGenericControl sample = itemQuestion.FindControl("divImage") as HtmlGenericControl;

							FileUpload ChecklistImage = (FileUpload)itemQuestion.FindControl("FileUpload_ChecklistImage");


							if (ChecklistImage.HasFile)
							{
								List<int> Lst_ValidImage = new List<int>();
								List<int> Lst_ImageSaved = new List<int>();
								List<string> Lst_Images = new List<string>();
								string CurrentDate = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));
								string fileName = string.Empty;

								string fileUploadPath = HttpContext.Current.Server.MapPath("~/CSMImages/" + CurrentDate);
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
									string filetype = Path.GetExtension(postfiles.FileName);
									if (filetype.ToLower() == ".jpg" || filetype.ToLower() == ".png")
									{
										try
										{
											fileName = HeadId + "_" + AnswerType + "_" + Convert.ToString(i) + filetype;
											string imgPath = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadURL"]);
											string SaveLocation = Server.MapPath("~/CSMImages/" + CurrentDate) + "/" + fileName;
											string FileLocation = imgPath + "/CSMImages/" + CurrentDate + "/" + fileName;// + "*WP";
											string ImageName = Path.GetFileName(postfiles.FileName);
											Stream strm = postfiles.InputStream;  //FileUpload_TicketImage.PostedFile.InputStream;
											var targetFile = SaveLocation;

											if (!Lst_ValidImage.Contains(0))
											{
												postfiles.SaveAs(SaveLocation);
												Lst_Images.Add(FileLocation);

												isField = "True";
												DataRow dtRow = dt.NewRow();
												dtRow["QuestionID"] = HeadId;
												dtRow["AnswerID"] = AnswerTypeID;
												dtRow["Data"] = FileLocation;
												dt.Rows.Add(dtRow);
											}
										}
										catch (Exception ex)
										{
											Lst_ImageSaved.Add(0); // Image failed to save
											throw ex;
										}
									}
									else
									{
										Lst_ValidImage.Add(0);  // image extension is not proper
									}
									i = i + 1;
								}
							}


							if (Is_Mandatory == "*")
							{
								if (isField == "False")
								{
									Is_Not_Valid = "True";
									lblQuestionErr.Text = "Please provide valid data.";
								}
							}

						}
						else if (AnswerType == "NUMBR") //Number Text Field
						{
							HtmlGenericControl sample = itemQuestion.FindControl("divNumber") as HtmlGenericControl;
							string txtNum = sample.Controls[1].UniqueID;
							string sVal = Request.Form.GetValues(txtNum)[0];
							DataRow dtRow = dt.NewRow();
							dtRow["QuestionID"] = HeadId;
							dtRow["AnswerID"] = AnswerTypeID;
							dtRow["Data"] = sVal;
							dt.Rows.Add(dtRow);
							isField = string.IsNullOrEmpty(sVal) ? "False" : "True";
							if (Is_Mandatory == "*")
							{
								if (isField == "False")
								{
									Is_Not_Valid = "True";
									lblQuestionErr.Text = "Please provide valid data.";
								}
							}

						}
						else if (AnswerType == "STEXT") //Normal Text Field
						{
							HtmlGenericControl sample = itemQuestion.FindControl("divText") as HtmlGenericControl;
							string txtNum = sample.Controls[1].UniqueID;
							string sVal = Request.Form.GetValues(txtNum)[0];
							DataRow dtRow = dt.NewRow();
							dtRow["QuestionID"] = HeadId;
							dtRow["AnswerID"] = AnswerTypeID;
							dtRow["Data"] = sVal;
							dt.Rows.Add(dtRow);

							isField = string.IsNullOrEmpty(sVal) ? "False" : "True";

							if (Is_Mandatory == "*")
							{
								if (isField == "False")
								{
									Is_Not_Valid = "True";
									lblQuestionErr.Text = "Please provide valid data.";
								}
							}
						}
						else if (AnswerType == "LTEXT") // Textarea Field
						{
							HtmlGenericControl sample = itemQuestion.FindControl("divTextArea") as HtmlGenericControl;
							string txtNum = sample.Controls[1].UniqueID;
							string sVal = Request.Form.GetValues(txtNum)[0];
							DataRow dtRow = dt.NewRow();
							dtRow["QuestionID"] = HeadId;
							dtRow["AnswerID"] = AnswerTypeID;
							dtRow["Data"] = sVal;
							dt.Rows.Add(dtRow);
							isField = string.IsNullOrEmpty(sVal) ? "False" : "True";

							if (Is_Mandatory == "*")
							{
								if (isField == "False")
								{
									Is_Not_Valid = "True";
									lblQuestionErr.Text = "Please provide valid data.";
								}
							}
						}
						else  //Normal Text Field
						{
							HtmlGenericControl sample = itemQuestion.FindControl("divText") as HtmlGenericControl;
							string txtNum = sample.Controls[1].UniqueID;
							string sVal = Request.Form.GetValues(txtNum)[0];
							DataRow dtRow = dt.NewRow();
							dtRow["QuestionID"] = HeadId;
							dtRow["AnswerID"] = AnswerTypeID;
							dtRow["Data"] = sVal;
							dt.Rows.Add(dtRow);
							isField = string.IsNullOrEmpty(sVal) ? "False" : "True";

							if (Is_Mandatory == "*")
							{
								if (isField == "False")
								{
									Is_Not_Valid = "True";
									lblQuestionErr.Text = "Please provide valid data.";
								}
							}
						}
					}
				else if (Action == 'C')
					foreach (RepeaterItem itemQuestion in rptCloseQuestionDetails.Items)
					{

						string AnswerType = (itemQuestion.FindControl("hdnAnswerTypeSDesc") as HiddenField).Value;
						string Is_Mandatory = Convert.ToString((itemQuestion.FindControl("hdnIs_Mandatory") as HiddenField).Value);
						Label lblQuestionErr = (itemQuestion.FindControl("lblQuestionErr") as Label);
						string isField = "False";

						int AnswerTypeID = Convert.ToInt32((itemQuestion.FindControl("hdnAnswerID") as HiddenField).Value);
						string HeadId = (itemQuestion.FindControl("hfQuestionId") as HiddenField).Value;

						if (AnswerType == "MSLCT") //Multi Selection [CheckBox]
						{
							CheckBoxList divCheckBoxIDI = itemQuestion.FindControl("divCheckBoxIDI") as CheckBoxList;
							List<String> chkStrList = new List<string>();


							foreach (ListItem item in divCheckBoxIDI.Items)
							{
								if (item.Selected)
								{
									isField = "True";

									chkStrList.Add(item.Value);
									DataRow dtRow = dt.NewRow();
									dtRow["QuestionID"] = HeadId;
									dtRow["AnswerID"] = AnswerTypeID;
									dtRow["Data"] = item.Value;
									dt.Rows.Add(dtRow);
								}
							}

							if (Is_Mandatory == "*")
							{
								if (isField == "False")
								{
									Is_Not_Valid = "True";
									lblQuestionErr.Text = "Please provide valid data.";
								}
							}

							//String YrStr = String.Join(";", chkStrList.ToArray());
						}
						else if (AnswerType == "SSLCT") //Single Selection [Radio Button]
						{
							RadioButtonList divRadioButtonrdbYes = itemQuestion.FindControl("divRadioButtonrdbYes") as RadioButtonList;
							List<String> RadioStrList = new List<string>();
							foreach (ListItem item in divRadioButtonrdbYes.Items)
							{
								if (item.Selected)
								{
									isField = "True";
									RadioStrList.Add(item.Value);

									DataRow dtRow = dt.NewRow();
									dtRow["QuestionID"] = HeadId;
									dtRow["AnswerID"] = AnswerTypeID;
									dtRow["Data"] = item.Value;
									dt.Rows.Add(dtRow);
								}
							}
							if (Is_Mandatory == "*")
							{
								if (isField == "False")
								{
									Is_Not_Valid = "True";
									lblQuestionErr.Text = "Please provide valid data.";
								}
							}
							//String YrStr = String.Join(";", RadioStrList.ToArray());

						}
						else if (AnswerType == "IMAGE") //Image Upload  
						{
							HtmlGenericControl sample = itemQuestion.FindControl("divImage") as HtmlGenericControl;

							FileUpload ChecklistImage = (FileUpload)itemQuestion.FindControl("FileUpload_ChecklistImage");


							if (ChecklistImage.HasFile)
							{
								List<int> Lst_ValidImage = new List<int>();
								List<int> Lst_ImageSaved = new List<int>();
								List<string> Lst_Images = new List<string>();
								string CurrentDate = Convert.ToString(DateTime.Now.ToString("dd-MM-yyyy"));
								string fileName = string.Empty;

								string fileUploadPath = HttpContext.Current.Server.MapPath("~/CSMImages/" + CurrentDate);
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
									string filetype = Path.GetExtension(postfiles.FileName);
									if (filetype.ToLower() == ".jpg" || filetype.ToLower() == ".png")
									{
										try
										{
											fileName = HeadId + "_" + AnswerType + "_" + Convert.ToString(i) + filetype;
											string imgPath = Convert.ToString(ConfigurationManager.AppSettings["ImageUploadURL"]);
											string SaveLocation = Server.MapPath("~/CSMImages/" + CurrentDate) + "/" + fileName;
											string FileLocation = imgPath + "/CSMImages/" + CurrentDate + "/" + fileName;// + "*WP";
											string ImageName = Path.GetFileName(postfiles.FileName);
											Stream strm = postfiles.InputStream;  //FileUpload_TicketImage.PostedFile.InputStream;
											var targetFile = SaveLocation;

											if (!Lst_ValidImage.Contains(0))
											{
												postfiles.SaveAs(SaveLocation);
												Lst_Images.Add(FileLocation);

												isField = "True";
												DataRow dtRow = dt.NewRow();
												dtRow["QuestionID"] = HeadId;
												dtRow["AnswerID"] = AnswerTypeID;
												dtRow["Data"] = FileLocation;
												dt.Rows.Add(dtRow);
											}
										}
										catch (Exception ex)
										{
											Lst_ImageSaved.Add(0); // Image failed to save
											throw ex;
										}
									}
									else
									{
										Lst_ValidImage.Add(0);  // image extension is not proper
									}
									i = i + 1;
								}
							}


							if (Is_Mandatory == "*")
							{
								if (isField == "False")
								{
									Is_Not_Valid = "True";
									lblQuestionErr.Text = "Please provide valid data.";
								}
							}

						}
						else if (AnswerType == "NUMBR") //Number Text Field
						{
							HtmlGenericControl sample = itemQuestion.FindControl("divNumber") as HtmlGenericControl;
							string txtNum = sample.Controls[1].UniqueID;
							string sVal = Request.Form.GetValues(txtNum)[0];
							DataRow dtRow = dt.NewRow();
							dtRow["QuestionID"] = HeadId;
							dtRow["AnswerID"] = AnswerTypeID;
							dtRow["Data"] = sVal;
							dt.Rows.Add(dtRow);
							isField = string.IsNullOrEmpty(sVal) ? "False" : "True";
							if (Is_Mandatory == "*")
							{
								if (isField == "False")
								{
									Is_Not_Valid = "True";
									lblQuestionErr.Text = "Please provide valid data.";
								}
							}

						}
						else if (AnswerType == "STEXT") //Normal Text Field
						{
							HtmlGenericControl sample = itemQuestion.FindControl("divText") as HtmlGenericControl;
							string txtNum = sample.Controls[1].UniqueID;
							string sVal = Request.Form.GetValues(txtNum)[0];
							DataRow dtRow = dt.NewRow();
							dtRow["QuestionID"] = HeadId;
							dtRow["AnswerID"] = AnswerTypeID;
							dtRow["Data"] = sVal;
							dt.Rows.Add(dtRow);

							isField = string.IsNullOrEmpty(sVal) ? "False" : "True";

							if (Is_Mandatory == "*")
							{
								if (isField == "False")
								{
									Is_Not_Valid = "True";
									lblQuestionErr.Text = "Please provide valid data.";
								}
							}
						}
						else if (AnswerType == "LTEXT") // Textarea Field
						{
							HtmlGenericControl sample = itemQuestion.FindControl("divTextArea") as HtmlGenericControl;
							string txtNum = sample.Controls[1].UniqueID;
							string sVal = Request.Form.GetValues(txtNum)[0];
							DataRow dtRow = dt.NewRow();
							dtRow["QuestionID"] = HeadId;
							dtRow["AnswerID"] = AnswerTypeID;
							dtRow["Data"] = sVal;
							dt.Rows.Add(dtRow);
							isField = string.IsNullOrEmpty(sVal) ? "False" : "True";

							if (Is_Mandatory == "*")
							{
								if (isField == "False")
								{
									Is_Not_Valid = "True";
									lblQuestionErr.Text = "Please provide valid data.";
								}
							}
						}
						else  //Normal Text Field
						{
							HtmlGenericControl sample = itemQuestion.FindControl("divText") as HtmlGenericControl;
							string txtNum = sample.Controls[1].UniqueID;
							string sVal = Request.Form.GetValues(txtNum)[0];
							DataRow dtRow = dt.NewRow();
							dtRow["QuestionID"] = HeadId;
							dtRow["AnswerID"] = AnswerTypeID;
							dtRow["Data"] = sVal;
							dt.Rows.Add(dtRow);
							isField = string.IsNullOrEmpty(sVal) ? "False" : "True";

							if (Is_Mandatory == "*")
							{
								if (isField == "False")
								{
									Is_Not_Valid = "True";
									lblQuestionErr.Text = "Please provide valid data.";
								}
							}
						}
					}

				if (Is_Not_Valid == "True")
				{
					return;
				}

				if (dt.Rows.Count > 0)
				{
					DataTable DTS = new DataTable();
					DTS = dt.Copy();

					MemoryStream str = new MemoryStream();
					DTS.WriteXml(str, true);
					str.Seek(0, SeekOrigin.Begin);
					StreamReader sr = new StreamReader(str);
					string xmlstr;
					xmlstr = sr.ReadToEnd();
					strCSMData = xmlstr;
				}
				#endregion

				#region SaveDataToDB
				DataSet dsVMSQuestionData = new DataSet();
				dsVMSQuestionData = ObjUpkeep.Insert_CSMRequest(Convert.ToInt32(ViewState["CompanyID"]), Action, RequestID, ConfigID, strCSMData, LoggedInUserID);

				if (dsVMSQuestionData.Tables.Count > 0)
				{
					if (dsVMSQuestionData.Tables[0].Rows.Count > 0)
					{
						int status = Convert.ToInt32(dsVMSQuestionData.Tables[0].Rows[0]["Status"]);
						if (status == 1 && Action == 'N')
						{
							//SetRepeater();
							//divinsertbutton.visible = false;
							lblRequestCode.Text = Convert.ToString(dsVMSQuestionData.Tables[0].Rows[0]["RequestID"]);
							mpeVMSRequestSaveSuccess.Show();
						}
						else if (status == 1 && Action != 'N')
						{
							Response.Write("<script>alert('Status changed.');</script>");
							Response.Redirect(Page.ResolveClientUrl("~/CSM/Service_Requests.aspx"), false);
						}
						else
						{
							//SetRepeater();
							divError.Visible = true;
							lblErrorMsg.Text = "Due to some technical issue your request can not be process. Kindly contact support team.";
						}
					}
				}

				#endregion
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private void FetchSectionHeaderData()
		{
			try
			{
				int RequestID = Convert.ToInt32(ViewState["RequestID"]);

				DataSet dsData = new DataSet();
				dsData = ObjUpkeep.Bind_CSMRequestDetails(RequestID, LoggedInUserID);

				if (dsData.Tables.Count > 0)
				{

					if (dsData.Tables[0].Rows.Count > 0)
					{

						ViewState["ConfigID"] = Convert.ToInt32(dsData.Tables[0].Rows[0]["Config_ID"]);

						//ddlWorkPermitTitle.SelectedValue = dsData.Tables[0].Rows[0]["WP_Config_ID"].ToString();
						BindCSMConfig();
					}
					//Bind inserted Visit data
					if (dsData.Tables[1].Rows.Count > 0)
					{
						//txtWorkPermitToDate.Text = dsData.Tables[0].Rows[0]["Wp_To_Date"].ToString();

						//lblTicket.Text = dsData.Tables[0].Rows[0]["TicketNo"].ToString();

						switch (dsData.Tables[1].Rows[0]["Request_Status"].ToString())
						{
							case "Open":
								divAlertOpen.Visible = true;
								btnReject.Visible = true;
								ViewState["Action"] = 'C';
								lblRequestedBy.Text = dsData.Tables[1].Rows[0]["Requested_By"].ToString();
								lblRequestedDate.Text = dsData.Tables[1].Rows[0]["Request_Date"].ToString();
								divRequest.Visible = true;
								break;
							case "Close":
								divAlertClosed.Visible = true;
								btnSave.Visible = false;
								lblRequestedBy.Text = dsData.Tables[1].Rows[0]["Requested_By"].ToString();
								lblRequestedDate.Text = dsData.Tables[1].Rows[0]["Request_Date"].ToString();
								divRequest.Visible = true;
								lblClosedBy.Text = dsData.Tables[1].Rows[0]["Closed_By"].ToString();
								lblClosedDate.Text = dsData.Tables[1].Rows[0]["Closed_Date"].ToString();
								divClosed.Visible = true;
								break;
							case "Expired":
								divAlertExpired.Visible = true;
								btnSave.Visible = false;
								break;
							case "Reject":
								divAlertRejected.Visible = true;
								btnSave.Visible = false;
								break;
						}

					}

					//Bind configured open question
					if (dsData.Tables[2].Rows.Count > 0)
					{
						rptQuestionDetails.DataSource = dsData.Tables[2];
						rptQuestionDetails.DataBind();
					}
					if (dsData.Tables[3].Rows.Count > 0)
					{

						DataTable dta = new DataTable();
						dta = dsData.Tables[3].Copy();

						foreach (RepeaterItem itemHeader in rptQuestionDetails.Items)
						{
							string AnswerType = (itemHeader.FindControl("hdnAnswerTypeSDesc") as HiddenField).Value;
							string HeadId = (itemHeader.FindControl("hfQuestionId") as HiddenField).Value;

							DataTable dtQN = new DataTable();

							dta.DefaultView.RowFilter = "Open_QN_ID = '" + HeadId + "' ";
							dtQN = dta.DefaultView.ToTable();
							//dta.DefaultView.RowFilter = "WP_Section_ID = " + Convert.ToString(DivId) + " AND WP_Header_ID =" + Convert.ToString(HeadId) + "  ";

							if (dta.Rows.Count > 0)
							{
								if (AnswerType == "MSLCT") //Multi Selection [CheckBox]
								{
									CheckBoxList divCheckBoxIDI = itemHeader.FindControl("divCheckBoxIDI") as CheckBoxList;

									for (int i = 0; i < divCheckBoxIDI.Items.Count; i++)
									{
										for (int j = 0; j < dtQN.Rows.Count; j++)
										{
											string vals = divCheckBoxIDI.Items[i].Value;
											if (vals == dtQN.Rows[j]["Ans_Type_Data"].ToString() && Convert.ToBoolean(dtQN.Rows[j]["Selected"]))
											{
												divCheckBoxIDI.Items[i].Selected = true;
											}
											divCheckBoxIDI.Items[i].Enabled = false;
										}
										divCheckBoxIDI.Attributes.Add("Enabled", "false");
									}

								}
								else if (AnswerType == "SSLCT") //Single Selection [Radio Button]
								{
									RadioButtonList divRadioButtonrdbYes = itemHeader.FindControl("divRadioButtonrdbYes") as RadioButtonList;

									for (int i = 0; i < divRadioButtonrdbYes.Items.Count; i++)
									{
										for (int j = 0; j < dtQN.Rows.Count; j++)
										{
											string vals = divRadioButtonrdbYes.Items[i].Value;
											if (vals == dtQN.Rows[j]["Ans_Type_Data"].ToString() && Convert.ToBoolean(dtQN.Rows[j]["Selected"]))
											{
												divRadioButtonrdbYes.Items[i].Selected = true;
											}
											divRadioButtonrdbYes.Items[i].Enabled = false;
										}
										divRadioButtonrdbYes.Attributes.Add("Enabled", "false");
									}
								}
								else if (AnswerType == "IMAGE") //Image Upload  
								{
									HtmlGenericControl sample = itemHeader.FindControl("divImage") as HtmlGenericControl;
									FileUpload ChecklistImage = (FileUpload)itemHeader.FindControl("FileUpload_ChecklistImage");

									string vals = "";
									for (int j = 0; j < dtQN.Rows.Count; j++)
									{
										if (j == 0)
										{
											vals = dtQN.Rows[j]["Ans_Type_Data"].ToString();
										}
										else
										{
											vals = vals + "," + dtQN.Rows[j]["Ans_Type_Data"].ToString();
										}
									}

									ChecklistImage.Attributes.Add("style", "display:none;");

									HiddenField hdImg = itemHeader.FindControl("hdnImg") as HiddenField;
									hdImg.Value = vals;


									HtmlGenericControl divsImgBtns = itemHeader.FindControl("divImgBtns") as HtmlGenericControl;
									divsImgBtns.Attributes.Remove("style");

									//Button BtnDivImg = itemHeader.FindControl("btnImg") as Button;
									//BtnDivImg.Attributes.Remove("data-images");
									//BtnDivImg.Attributes.Add("data-images", vals);

								}
								else if (AnswerType == "NUMBR") //Number Text Field
								{
									HtmlGenericControl sample = itemHeader.FindControl("divNumber") as HtmlGenericControl;
									string txtNum = sample.Controls[1].UniqueID;
									//string sVal = Request.Form.GetValues(txtNum)[0];


									HtmlInputGenericControl tb = FindControl(txtNum) as HtmlInputGenericControl;
									tb.Value = dtQN.Rows[0]["Ans_Type_Data"].ToString();
									tb.Disabled = true;
									//Request.Form.Set(txtNum, dtQN.Rows[0]["Ans_Type_Data"].ToString());
								}
								else if (AnswerType == "STEXT") //Normal Text Field
								{
									HtmlGenericControl sample = itemHeader.FindControl("divText") as HtmlGenericControl;
									string txtNum = sample.Controls[1].UniqueID;
									//string sVal = Request.Form.GetValues(txtNum)[0];

									HtmlInputText tb = FindControl(txtNum) as HtmlInputText;
									tb.Value = dtQN.Rows[0]["Ans_Type_Data"].ToString();
									tb.Disabled = true;
									//Request.Form.Set(txtNum, dtQN.Rows[0]["Ans_Type_Data"].ToString());
								}
								else if (AnswerType == "LTEXT") // Textarea Field
								{
									HtmlGenericControl sample = itemHeader.FindControl("divTextArea") as HtmlGenericControl;
									string txtNum = sample.Controls[1].UniqueID;
									// string sVal = Request.Form.GetValues(txtNum)[0];

									HtmlTextArea tb = FindControl(txtNum) as HtmlTextArea;
									tb.Value = dtQN.Rows[0]["Ans_Type_Data"].ToString();
									tb.Disabled = true;
									//Request.Form.Set(txtNum, dtQN.Rows[0]["Ans_Type_Data"].ToString());
								}
								else  //Normal Text Field
								{
									HtmlGenericControl sample = itemHeader.FindControl("divText") as HtmlGenericControl;
									string txtNum = sample.Controls[1].UniqueID;
									//string sVal = Request.Form.GetValues(txtNum)[0];

									HtmlInputGenericControl tb = FindControl(txtNum) as HtmlInputGenericControl;
									tb.Value = dtQN.Rows[0]["Ans_Type_Data"].ToString();
									tb.Disabled = true;
									//Request.Form.Set(txtNum, dta.Rows[0]["Ans_Type_Data"].ToString());
								}
							}
						}



					}

					//Bind configured Closing question
					if (dsData.Tables[4].Rows.Count > 0)
					{
						rptCloseQuestionDetails.DataSource = dsData.Tables[4];
						rptCloseQuestionDetails.DataBind();
					}

					if (dsData.Tables[5].Rows.Count > 0)
					{

						DataTable dta = new DataTable();
						dta = dsData.Tables[5].Copy();

						foreach (RepeaterItem itemHeader in rptCloseQuestionDetails.Items)
						{
							string AnswerType = (itemHeader.FindControl("hdnAnswerTypeSDesc") as HiddenField).Value;
							string HeadId = (itemHeader.FindControl("hfQuestionId") as HiddenField).Value;

							DataTable dtQN = new DataTable();

							dta.DefaultView.RowFilter = "Close_QN_ID = '" + HeadId + "' ";
							dtQN = dta.DefaultView.ToTable();
							//dta.DefaultView.RowFilter = "WP_Section_ID = " + Convert.ToString(DivId) + " AND WP_Header_ID =" + Convert.ToString(HeadId) + "  ";

							if (dta.Rows.Count > 0)
							{
								if (AnswerType == "MSLCT") //Multi Selection [CheckBox]
								{
									CheckBoxList divCheckBoxIDI = itemHeader.FindControl("divCheckBoxIDI") as CheckBoxList;

									for (int i = 0; i < divCheckBoxIDI.Items.Count; i++)
									{
										for (int j = 0; j < dtQN.Rows.Count; j++)
										{
											string vals = divCheckBoxIDI.Items[i].Value;
											if (vals == dtQN.Rows[j]["Ans_Type_Data"].ToString() && Convert.ToBoolean(dtQN.Rows[j]["Selected"]))
											{
												divCheckBoxIDI.Items[i].Selected = true;
											}
											divCheckBoxIDI.Items[i].Enabled = false;
										}
										divCheckBoxIDI.Attributes.Add("Enabled", "false");
									}

								}
								else if (AnswerType == "SSLCT") //Single Selection [Radio Button]
								{
									RadioButtonList divRadioButtonrdbYes = itemHeader.FindControl("divRadioButtonrdbYes") as RadioButtonList;

									for (int i = 0; i < divRadioButtonrdbYes.Items.Count; i++)
									{
										for (int j = 0; j < dtQN.Rows.Count; j++)
										{
											string vals = divRadioButtonrdbYes.Items[i].Value;
											if (vals == dtQN.Rows[j]["Ans_Type_Data"].ToString() && Convert.ToBoolean(dtQN.Rows[j]["Selected"]))
											{
												divRadioButtonrdbYes.Items[i].Selected = true;
											}
											divRadioButtonrdbYes.Items[i].Enabled = false;
										}
										divRadioButtonrdbYes.Attributes.Add("Enabled", "false");
									}
								}
								else if (AnswerType == "IMAGE") //Image Upload  
								{
									HtmlGenericControl sample = itemHeader.FindControl("divImage") as HtmlGenericControl;
									FileUpload ChecklistImage = (FileUpload)itemHeader.FindControl("FileUpload_ChecklistImage");

									string vals = "";
									for (int j = 0; j < dtQN.Rows.Count; j++)
									{
										if (j == 0)
										{
											vals = dtQN.Rows[j]["Ans_Type_Data"].ToString();
										}
										else
										{
											vals = vals + "," + dtQN.Rows[j]["Ans_Type_Data"].ToString();
										}
									}

									ChecklistImage.Attributes.Add("style", "display:none;");

									HiddenField hdImg = itemHeader.FindControl("hdnImg") as HiddenField;
									hdImg.Value = vals;


									HtmlGenericControl divsImgBtns = itemHeader.FindControl("divImgBtns") as HtmlGenericControl;
									divsImgBtns.Attributes.Remove("style");

									//Button BtnDivImg = itemHeader.FindControl("btnImg") as Button;
									//BtnDivImg.Attributes.Remove("data-images");
									//BtnDivImg.Attributes.Add("data-images", vals);

								}
								else if (AnswerType == "NUMBR") //Number Text Field
								{
									HtmlGenericControl sample = itemHeader.FindControl("divNumber") as HtmlGenericControl;
									string txtNum = sample.Controls[1].UniqueID;
									//string sVal = Request.Form.GetValues(txtNum)[0];


									HtmlInputGenericControl tb = FindControl(txtNum) as HtmlInputGenericControl;
									tb.Value = dtQN.Rows[0]["Ans_Type_Data"].ToString();
									tb.Disabled = true;
									//Request.Form.Set(txtNum, dtQN.Rows[0]["Ans_Type_Data"].ToString());
								}
								else if (AnswerType == "STEXT") //Normal Text Field
								{
									HtmlGenericControl sample = itemHeader.FindControl("divText") as HtmlGenericControl;
									string txtNum = sample.Controls[1].UniqueID;
									//string sVal = Request.Form.GetValues(txtNum)[0];

									HtmlInputText tb = FindControl(txtNum) as HtmlInputText;
									tb.Value = dtQN.Rows[0]["Ans_Type_Data"].ToString();
									tb.Disabled = true;
									//Request.Form.Set(txtNum, dtQN.Rows[0]["Ans_Type_Data"].ToString());
								}
								else if (AnswerType == "LTEXT") // Textarea Field
								{
									HtmlGenericControl sample = itemHeader.FindControl("divTextArea") as HtmlGenericControl;
									string txtNum = sample.Controls[1].UniqueID;
									// string sVal = Request.Form.GetValues(txtNum)[0];

									HtmlTextArea tb = FindControl(txtNum) as HtmlTextArea;
									tb.Value = dtQN.Rows[0]["Ans_Type_Data"].ToString();
									tb.Disabled = true;
									//Request.Form.Set(txtNum, dtQN.Rows[0]["Ans_Type_Data"].ToString());
								}
								else  //Normal Text Field
								{
									HtmlGenericControl sample = itemHeader.FindControl("divText") as HtmlGenericControl;
									string txtNum = sample.Controls[1].UniqueID;
									//string sVal = Request.Form.GetValues(txtNum)[0];

									HtmlInputGenericControl tb = FindControl(txtNum) as HtmlInputGenericControl;
									tb.Value = dtQN.Rows[0]["Ans_Type_Data"].ToString();
									tb.Disabled = true;
									//Request.Form.Set(txtNum, dta.Rows[0]["Ans_Type_Data"].ToString());
								}
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
		#endregion
	}
}