<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Raise_Service_Request.aspx.cs" Inherits="Upkeep_v3.CSM.Raise_Service_Request" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<div class="m-grid__item m-grid__item--fluid m-wrapper">
		<div class="">
			<div class="row">
				<div class="col-md-12">

					<!--begin::Portlet-->
					<div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

						<%--<form class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmVMS" method="post">--%>
						<cc1:toolkitscriptmanager runat="server"></cc1:toolkitscriptmanager>

						<asp:HiddenField ID="hdnVMSQuestionData" runat="server" ClientIDMode="Static" />
						<asp:HiddenField ID="hdnVMSQuestion" runat="server" ClientIDMode="Static" />
						<p id="info" style="display: none;"></p>
						<p id="infox" style="display: none;"></p>


						<div class="alert m-alert--default m-alert--icon" id="divAlertExpired" visible="false" runat="server" role="alert">
							<div class="m-alert__icon">
								<i class="la la-warning"></i>
							</div>
							<div class="m-alert__text">
								<strong>Expired!</strong> This Request is Expired.
							</div>
						</div>
						<div class="alert alert-warning m-alert--icon" id="divAlertOpen" visible="false" runat="server" role="alert">
							<div class="m-alert__icon">
								<i class="la la-warning"></i>
							</div>
							<div class="m-alert__text">
								<strong>IN!</strong> This Request is Open.
							</div>
						</div>
						<div class="alert alert-success m-alert--icon" id="divAlertClosed" visible="false" runat="server" role="alert">
							<div class="m-alert__icon">
								<i class="la la-warning"></i>
							</div>
							<div class="m-alert__text">
								<strong>OUT!</strong> This Request is Closed.
							</div>
						</div>
						<div class="alert alert-brand m-alert--icon" id="divAlertApply" visible="false" runat="server" role="alert">
							<div class="m-alert__icon">
								<i class="la la-warning"></i>
							</div>
							<div class="m-alert__text">
								<strong>Apply!</strong> This Request is Applied.
							</div>
						</div>
						<div class="alert alert-danger m-alert--icon" id="divAlertRejected" visible="false" runat="server" role="alert">
							<div class="m-alert__icon">
								<i class="la la-warning"></i>
							</div>
							<div class="m-alert__text">
								<strong>Rejected!</strong> This Request is Rejected.
							</div>
						</div>

						<div class="alert alert-danger" id="divError" visible="False" runat="server" role="alert">
							<asp:Label ID="lblErrorMsg" Text="" runat="server"></asp:Label>

						</div>

						<div class="m-portlet__head">
							<div class="m-portlet__head-progress">

								<!-- here can place a progress bar-->
							</div>
							<div class="m-portlet__head-wrapper">
								<div class="m-portlet__head-caption">
									<div class="m-portlet__head-title">
										<h3 class="m-portlet__head-text">Service Request
										</h3>
									</div>
								</div>

								<div class="m-portlet__head-tools">
									<a href="<%= Page.ResolveClientUrl("~/CSM/Service_Requests.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
										<span>
											<i class="la la-arrow-left"></i>
											<span>Back</span>
										</span>
									</a>
									<div class="btn-group">

										<asp:Button ID="btnSave" runat="server" class="btn btn-accent m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10" OnClientClick="if(this.value === 'Saving...') { return false; } else { this.value = 'Saving...'; }SubmitQuestion()" ValidationGroup="validateVMS" OnClick="btnSave_Click" Text="Save" />

										<asp:Button ID="btnTest" Style="display: none;" runat="server" />
										<cc1:modalpopupextender id="mpeVMSRequestSaveSuccess" runat="server" popupcontrolid="pnlVMSReqestSuccess" targetcontrolid="btnTest"
											cancelcontrolid="btnCloseQuestion2" backgroundcssclass="modalBackground">
										</cc1:modalpopupextender>
									</div>

									<asp:Button ID="btnReject" Visible="false" OnClick="btnReject_Click" runat="server" class="btn btn-danger m-btn m-btn--icon m-btn--wide m-btn--md" Text="Reject" />

								</div>

							</div>
						</div>

						<div class="m-portlet__body" style="padding: 0.4rem 2.2rem;">

							<div class="m-portlet__body" style="padding: 0.3rem 2.2rem;">
								
								<div class="form-group row" style="background-color: #00c5dc;">
									<label class="col-md-3" style="color: #ffffff; margin-top: 1%;">Service Request Opening Questions</label>
								</div>


								<asp:Repeater ID="rptQuestionDetails" runat="server" OnItemDataBound="rptQuestionDetails_ItemDataBound">
									<ItemTemplate>

										<asp:HiddenField ID="hdnAnswerTypeSDesc" runat="server" Value='<%# Eval("SDesc") %>' />
										<asp:HiddenField ID="hdnAnswerID" runat="server" Value='<%# Eval("Ans_Type_ID") %>' />
										<%--<asp:HiddenField ID="hdnlblAnswerTypeData" runat="server" Value='<%# Eval("Ans_Type_Data_ID") %>' />--%>

										<div class="form-group m-form__group row" style="padding-left: 1%;">
											<div class="col-md-3">
												<asp:HiddenField ID="hfQuestionId" runat="server" Value='<%# Eval("Open_Qn_ID") %>' />
												<label class="form-control-label font-weight-bold" id=' <%#Eval("Open_Qn_ID") %> '><span style="color: red;"><%# Convert.ToBoolean(Eval("Is_Flag"))  ? "*" : " " %></span> &nbsp; &nbsp; <%#Eval("Desc") %> :</label>
												<asp:HiddenField ID="hdnIs_Mandatory" runat="server" Value='<%# Convert.ToBoolean(Eval("Is_Flag"))  ? "*" : " " %>' />
												<asp:Label ID="lblQuestionErr" Text="" runat="server" CssClass="col-md-8 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
											</div>
											<div class="col-md-9">

												<div id="divText" style="display: none" runat="server">
													<input name="divTextName" id="divTextid" type="text" class="form-control" runat="server" />
												</div>

												<div id="divNumber" style="display: none" runat="server">
													<input type="number" min="0" name="divNumberName" id="divNumberid" class="form-control" runat="server" />
												</div>

												<div id="divTextArea" style="display: none" runat="server">
													<textarea rows="4" cols="50" name="divTextAreaName" id="divTextAreaid" class="form-control" runat="server"></textarea>
												</div>

												<div id="divRadioButton" style="display: none" runat="server">
													<asp:RadioButtonList class="m-radio-inline" runat="server" ID="divRadioButtonrdbYes" RepeatDirection="Horizontal" ValidationGroup="Radio" ClientIDMode="Static" CellSpacing="5" CellPadding="5"></asp:RadioButtonList>
												</div>

												<div id="divImage" style="display: none" runat="server">
													<asp:FileUpload ID="FileUpload_ChecklistImage" runat="server" ClientIDMode="Static" CssClass="btn FileUpload_ChecklistImage" Style="width: 36%;" AllowMultiple="true" />
													&nbsp;
													<div id="divImgBtns" style="display: none" runat="server">
														<button id='btnImg' type='button' data-toggle='modal' data-target="#exampleModal" class='btn btn-accent m-btn m-btn--icon'
															data-images="<%#Eval("ImagePath") %>" data-container='body' style="width: 41px; height: 41px;" data-placement='top' title='View Uploaded Image'>
															<i class='la la-image' style="margin-left: -106%; font-size: 2.3rem;"></i>
															<%--data-images="<%#Eval("Question_Data") %>"--%>
														</button>
														<asp:HiddenField ID="hdnImg" runat="server" ClientIDMode="Static" />
													</div>
												</div>

												<div id="divDate" style="display: none" runat="server">
													<div class="input-group date">
														<asp:TextBox ID="divDateID" runat="server" autocomplete="off" class="form-control m-input datetimepicker"
															placeholder="Select date & time"></asp:TextBox>
														<div class="input-group-append">
															<span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
														</div>
													</div>
												</div>
												<div id="divCheckBox" style="display: none" runat="server">
													<asp:CheckBoxList ID="divCheckBoxIDI" runat="server" RepeatDirection="Horizontal" CellSpacing="5" CellPadding="5" ClientIDMode="Static"></asp:CheckBoxList>
												</div>
											</div>
										</div>

									</ItemTemplate>
									<FooterTemplate>
										<asp:Label ID="HeaderFooter" runat="server" Text='No Records Found' CssClass="form-control-label col-form-label"
											Style="display: none;"></asp:Label>
									</FooterTemplate>

								</asp:Repeater>
								<div id="divClosing" runat="server">
								<div class="form-group row" style="background-color: #00c5dc;">
									<label class="col-md-3" style="color: #ffffff; margin-top: 1%;">Service Request Closing Questions</label>
								</div>

								</div>
								<asp:Repeater ID="rptCloseQuestionDetails" runat="server" OnItemDataBound="rptCloseQuestionDetails_ItemDataBound">
									<ItemTemplate>

										<asp:HiddenField ID="hdnAnswerTypeSDesc" runat="server" Value='<%# Eval("SDesc") %>' />
										<asp:HiddenField ID="hdnAnswerID" runat="server" Value='<%# Eval("Ans_Type_ID") %>' />
										<%--<asp:HiddenField ID="hdnlblAnswerTypeData" runat="server" Value='<%# Eval("Ans_Type_Data_ID") %>' />--%>

										<div class="form-group m-form__group row" style="padding-left: 1%;">
											<div class="col-md-3">
												<asp:HiddenField ID="hfQuestionId" runat="server" Value='<%# Eval("Close_Qn_ID") %>' />
												<label class="form-control-label font-weight-bold" id=' <%#Eval("Close_Qn_ID") %> '><span style="color: red;"><%# Convert.ToBoolean(Eval("Is_Flag"))  ? "*" : " " %></span> &nbsp; &nbsp; <%#Eval("Desc") %> :</label>
												<asp:HiddenField ID="hdnIs_Mandatory" runat="server" Value='<%# Convert.ToBoolean(Eval("Is_Flag"))  ? "*" : " " %>' />
												<asp:Label ID="lblQuestionErr" Text="" runat="server" CssClass="col-md-8 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
											</div>
											<div class="col-md-9">

												<div id="divText" style="display: none" runat="server">
													<input name="divTextName" id="divTextid" type="text" class="form-control" runat="server" />
												</div>

												<div id="divNumber" style="display: none" runat="server">
													<input type="number" min="0" name="divNumberName" id="divNumberid" class="form-control" runat="server" />
												</div>

												<div id="divTextArea" style="display: none" runat="server">
													<textarea rows="4" cols="50" name="divTextAreaName" id="divTextAreaid" class="form-control" runat="server"></textarea>
												</div>

												<div id="divRadioButton" style="display: none" runat="server">
													<asp:RadioButtonList class="m-radio-inline" runat="server" ID="divRadioButtonrdbYes" RepeatDirection="Horizontal" ValidationGroup="Radio" ClientIDMode="Static" CellSpacing="5" CellPadding="5"></asp:RadioButtonList>
												</div>

												<div id="divImage" style="display: none" runat="server">
													<asp:FileUpload ID="FileUpload_ChecklistImage" runat="server" ClientIDMode="Static" CssClass="btn FileUpload_ChecklistImage" Style="width: 36%;" AllowMultiple="true" />
													&nbsp;
													<div id="divImgBtns" style="display: none" runat="server">
														<button id='btnImg' type='button' data-toggle='modal' data-target="#exampleModal" class='btn btn-accent m-btn m-btn--icon'
															data-images="<%#Eval("ImagePath") %>" data-container='body' style="width: 41px; height: 41px;" data-placement='top' title='View Uploaded Image'>
															<i class='la la-image' style="margin-left: -106%; font-size: 2.3rem;"></i>
															<%--data-images="<%#Eval("Question_Data") %>"--%>
														</button>
														<asp:HiddenField ID="hdnImg" runat="server" ClientIDMode="Static" />
													</div>
												</div>

												<div id="divDate" style="display: none" runat="server">
													<div class="input-group date">
														<asp:TextBox ID="divDateID" runat="server" autocomplete="off" class="form-control m-input datetimepicker"
															placeholder="Select date & time"></asp:TextBox>
														<div class="input-group-append">
															<span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
														</div>
													</div>
												</div>
												<div id="divCheckBox" style="display: none" runat="server">
													<asp:CheckBoxList ID="divCheckBoxIDI" runat="server" RepeatDirection="Horizontal" CellSpacing="5" CellPadding="5" ClientIDMode="Static"></asp:CheckBoxList>
												</div>
											</div>
										</div>

									</ItemTemplate>
									<FooterTemplate>
										<asp:Label ID="HeaderFooter" runat="server" Text='No Records Found' CssClass="form-control-label col-form-label"
											Style="display: none;"></asp:Label>
									</FooterTemplate>

								</asp:Repeater>

								<div class="form-group row" style="background-color: #00c5dc;">
									<label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Service Request Terms & Conditions</label>
								</div>
								<asp:Repeater ID="rptTermsCondition" runat="server" ClientIDMode="Static">
									<ItemTemplate>
										<table style="width: 100%">
											<tr>
												<td>
													<asp:CheckBox runat="server" ID="chkTermsCondition" />
												</td>
												<td style="width: 5%">
													<asp:Label ID="lblTermID" runat="server" Text='<%#Eval("Terms_ID") %>' Style="display: none;"></asp:Label>
												</td>
												<td style="width: 90%" colspan="2">
													<asp:Label ID="lblTermDesc" runat="server" Text='<%#Eval("Term_Desc") %>' ClientIDMode="Static" CssClass="form-control-label col-form-label font-weight-bold"></asp:Label>
												</td>

											</tr>
											<br />
										</table>
									</ItemTemplate>
								</asp:Repeater>

								<br />
							</div>
						</div>
						<asp:Panel ID="pnlReqestSuccess" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
							<div class="" id="add_sub_location2" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
								<div class="modal-dialog" role="document" style="max-width: 590px;">
									<div class="modal-content">
										<asp:UpdatePanel ID="UpdatePanel2" runat="server">
											<ContentTemplate>
												<div class="modal-header">
													<h5 class="modal-title" id="exampleModalLabel2">Visit Request Confirmation</h5>
													<button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseQuestion2">
														<span aria-hidden="true">&times;</span>
													</button>
												</div>
												<div class="modal-body">
													<div class="form-group m-form__group row">
														<label for="recipient-name" class="col-md-8 form-control-label">Visit Request has been submitted successfully</label>
													</div>
													<div class="form-group m-form__group row">
														<label for="message-text" class="col-md-5 form-control-label font-weight-bold">Request ID :</label>
														<asp:Label ID="lblRequestCode" Text="" runat="server" CssClass="col-md-1 col-form-label" Style="padding-top: calc(0.15rem + 1px); margin-left: -10%;"></asp:Label>
														<br />
														<strong>Please note down your Request ID.</strong>
													</div>
												</div>
												<div class="modal-footer">
													<asp:Button ID="btnSuccessOk" runat="server" class="btn btn-accent m-btn m-btn--icon m-btn--wide m-btn--md" Text="Ok" OnClick="btnSuccessOk_Click" />
												</div>
											</ContentTemplate>
											<Triggers>
												<asp:AsyncPostBackTrigger ControlID="btnTest" EventName="Click" />
											</Triggers>
										</asp:UpdatePanel>


									</div>
								</div>
							</div>

						</asp:Panel>
						<%--</form>--%>
					</div>
				</div>
			</div>
		</div>
	</div>
</asp:Content>
