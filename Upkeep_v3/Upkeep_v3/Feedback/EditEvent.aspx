<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="EditEvent.aspx.cs" Inherits="Upkeep_v3.Feedback.EditEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript" ></script>
    <script>

		    $(document).ready(function () {
		        init_plugins();

		        $('.datetimepicker').datetimepicker({
		            todayHighlight: true,
		            autoclose: true,
		            pickerPosition: 'bottom-right',
		            format: 'dd/mm/yyyy HH:ii P',
		            showMeridian: true,
		            startDate: moment().format('YYYY-MM-DD'),
		        }).on('changeDate', function (event) {
		            var start_at = moment($('#start_at').val(), 'DD/MM/YYYY hh:mm A').valueOf();
		            var end_at = moment($('#end_at').val(), 'DD/MM/YYYY hh:mm A').valueOf();
		            $('#error_end_at').html('').parents('.form-group').removeClass('has-error');
		            if (end_at < start_at) {
		                $('#error_end_at').html('Event end date-time can not be before the start date.').parents('.form-group').addClass('has-error');
		            }
		        });

		        $('.datetimepicker').on('click', function () {
		            if ($(this).is('#start_at')) {
		                $('#end_at').datetimepicker('hide');
		            }
		            if ($(this).is('#end_at')) {
		                $('#start_at').datetimepicker('hide');
		            }
		        });


		        $('#event_name').on('change', function () {
		            $('#error_event_name').html('').parents('.form-group').removeClass('has-error');
		            if ($(this).val().trim() == '') {
		                $('#error_event_name').html('Enter event name.').parents('.form-group').addClass('has-error');
		            }
		        });

		        $('input:radio[name="question_for"]').change(function () {
		            $('#error_question_for').html('').parents('.form-group').removeClass('has-error');
		            if (!$(this).is(':checked')) {
		                $('#error_question_for').html('Select at least one option.').parents('.form-group').addClass('has-error');
		            }
		        });

		        //$('input:radio[name="event_mode"]').change(function () {
                $('input:radio[name="ctl00$ContentPlaceHolder1$event_mode"]').change(function () {
		            $('#error_event_mode, #error_start_at, #error_end_at').html('').parents('.form-group').removeClass('has-error');
		            $('.datetimepicker').val('');
		            if (!$(this).is(':checked')) {
		                $('#error_event_mode').html('Select at least one option.').parents('.form-group').addClass('has-error');
		            }

		            if ($(this).val() == 'rdbPeriodic') {
		                $('.dates_div_group').slideDown();
		            }
		            else {
		                $('.dates_div_group').slideUp();
		            }
		        });

		        $('#location').on('change', function () {
		            $('#error_location').html('').parents('.form-group').removeClass('has-error');
		            if ($(this).val().trim() == '') {
		                $('#error_location').html('Enter location.').parents('.form-group').addClass('has-error');
		            }
		        });

		        $('#start_at').on('change', function () {
		            $('#error_start_at').html('').parents('.form-group').removeClass('has-error');
		            if ($(this).val().trim() == '') {
		                $('#error_start_at').html('Select event start date and time.').parents('.form-group').addClass('has-error');
		            }
		        });

		        $('#end_at').on('change', function () {
		            $('#error_end_at').html('').parents('.form-group').removeClass('has-error');
		            if ($(this).val().trim() == '') {
		                $('#error_end_at').html('Select event end date and time.').parents('.form-group').addClass('has-error');
		            }
		        });

		        $('#event_form').submit(function (event) {
		            var is_valid = true;

		            if ($('#event_name').val().trim() == '') {
		                is_valid = false;
		                $('#error_event_name').html('Enter event name.').parents('.form-group').addClass('has-error');
		            }

		            if (!$('input:radio[name="question_for"]').is(':checked')) {
		                is_valid = false;
		                $('#error_question_for').html('Select at least one option.').parents('.form-group').addClass('has-error');
		            }

		            if (!$('input:radio[name="event_mode"]').is(':checked')) {
		                is_valid = false;
		                $('#error_event_mode').html('Select at least one option.').parents('.form-group').addClass('has-error');
		            }
		            else if ($('input:radio[name="event_mode"]:checked').val() == '2') {
		                if ($('#start_at').val().trim() == '') {
		                    is_valid = false;
		                    $('#error_start_at').html('Select event start date and time.').parents('.form-group').addClass('has-error');
		                }

		                if ($('#end_at').val().trim() == '') {
		                    is_valid = false;
		                    $('#error_end_at').html('Select event end date and time.').parents('.form-group').addClass('has-error');
		                }
		            }

		            if ($('#location').val().trim() == '') {
		                is_valid = false;
		                $('#error_location').html('Enter location.').parents('.form-group').addClass('has-error');
		            }

		            if ($('#end_at').val().trim() != '' && $('#start_at').val().trim() != '') {
		                var start_at = moment($('#start_at').val(), 'DD/MM/YYYY hh:mm A').valueOf();
		                var end_at = moment($('#end_at').val(), 'DD/MM/YYYY hh:mm A').valueOf();
		                if (end_at < start_at) {
		                    is_valid = false;
		                    $('#error_end_at').html('Event end date-time can not be before the start date.').parents('.form-group').addClass('has-error');
		                }
		            }

		            console.log('is_valid = ' + is_valid);

		            if (!is_valid) {
		                event.preventDefault();
		            }
		        });
		    });
		</script>


    <div class="m-grid__item m-grid__item--fluid m-wrapper">

					<div class="m-content">
						<div class="row">
							<div class="col-lg-12">

								<!--begin::Portlet-->
								<div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">
									
                                    

                                    <div class="m-portlet__head">
										<div class="m-portlet__head-progress">

											<!-- here can place a progress bar-->
										</div>
										<div class="m-portlet__head-wrapper">
											<div class="m-portlet__head-caption">
												<div class="m-portlet__head-title">
													<h3 class="m-portlet__head-text">
														Edit event
													</h3>
												</div>
											</div>
											<div class="m-portlet__head-tools">
												<a href="<%= Page.ResolveClientUrl("EventListing.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
													<span>
														<i class="la la-arrow-left"></i>
														<span>Back</span>
													</span>
												</a>
												<div class="btn-group">
                                                    <asp:Button ID="btnSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnSave_Click" Text="Update" />													
													
												</div>
											</div>
										</div>
									</div>
									<div class="m-portlet__body">
										
											<!--begin: Form Body -->
											<div class="m-portlet__body">
												<div class="row">
													<div class="col-xl-8 offset-xl-2">
														<div class="m-form__section m-form__section--first">
															<div class="m-form__heading">
																<h3 class="m-form__heading-title">Event details</h3>
															</div>
															<div class="form-group m-form__group row">
																<label class="col-xl-3 col-lg-3 col-form-label">* Event Name:</label>
																<div class="col-xl-9 col-lg-9">
																	<asp:TextBox id="event_name" ReadOnly="true" runat="server" class="form-control m-input" placeholder="Event name"></asp:TextBox>
																	<span id="error_event_name" class="text-danger small"></span>
																</div>
															</div>
															<div class="form-group m-form__group row">
																<label class="col-xl-3 col-lg-3 col-form-label">* Location:</label>
																<div class="col-xl-9 col-lg-9">
														<asp:TextBox id="Location" runat="server" class="form-control m-input" placeholder="Event Location"></asp:TextBox>
																	<span id="error_location" class="text-danger small"></span>
																</div>
															</div>
															<div class="m-form__group form-group row">
																<label class="col-3 col-form-label">* Questions For</label>
																<div class="col-9">
																	<div class="m-radio-inline">
																		<label class="m-radio">
																			<asp:RadioButton id="rdbCustomer" runat="server" GroupName="question_for" Checked="true" /> Customers
																			<span></span>
																		</label>
																		<label class="m-radio">
																			<asp:RadioButton id="rdbRetailer" runat="server" GroupName="question_for" /> Retailers
																			<span></span>
																		</label>
																	</div>
																	<span id="error_question_for" class="text-danger small"></span>
																</div>
															</div>
															<div class="m-form__group form-group row">
																<label class="col-3 col-form-label">* Event Mode</label>
																<div class="col-9">
																	<div class="m-radio-inline">
																		<label class="m-radio">
																			<asp:RadioButton id="rdbDaily" runat="server" GroupName="event_mode" Checked="true" /> Daily/Monthly
																			<span></span>
																		</label>
																		<label class="m-radio">
																			<asp:RadioButton id="rdbPeriodic" runat="server" GroupName="event_mode" /> Periodic
																			<span></span>
																		</label>
																	</div>
																	<span id="error_event_mode" class="text-danger small"></span>
																</div>
															</div>
															<div class="dates_div_group" style="display: none;" id="dvDate" runat="server">
																<div class="form-group m-form__group row">
																	<label class="col-xl-3 col-lg-3 col-form-label">* Start at</label>
																	<div class="col-xl-9 col-lg-9">
																		<div class="input-group date">
                                                                        <asp:TextBox id="startDate" runat="server" class="form-control m-input datetimepicker" readonly="true" placeholder="Select date & time"></asp:TextBox>
																			<div class="input-group-append">
																				<span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
																			</div>
																		</div>
																		<span id="error_start_at" class="text-danger small"></span>
																	</div>
																</div>
																<div class="form-group m-form__group row">
																	<label class="col-xl-3 col-lg-3 col-form-label">* End at</label>
																	<div class="col-xl-9 col-lg-9">
																		<div class="input-group date">
                                                                        <asp:TextBox id="endDate" runat="server" class="form-control m-input datetimepicker" readonly="true" placeholder="Select date & time"></asp:TextBox>
																			<div class="input-group-append">
																				<span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
																			</div>
																		</div>
																		<span id="error_end_at" class="text-danger small"></span>
																	</div>
																</div>
															</div>
														</div>
													</div>
												</div>
											</div>
										
									</div>
                                        
								</div>
								<!--end::Portlet-->
							</div>
						</div>
					</div>
				</div>

</asp:Content>
