<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="EventDetails.aspx.cs" Inherits="Upkeep_v3.Feedback.EventDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <script>
        function init_autosize() {
            var autosize_textarea = $('.autosize_textarea');
            autosize(autosize_textarea);
            autosize.update(autosize_textarea);
        }

        $(document).ready(function () {

            init_autosize();
            init_plugins();

            $('.datetimepicker').datetimepicker({
                todayHighlight: true,
                autoclose: true,
                pickerPosition: 'bottom-right',
                format: 'dd/mm/yyyy HH:ii P',
                showMeridian: true,
                startDate: moment().format('YYYY-MM-DD'),
            }).on('changeDate', function (event) {
                var startDate = moment($('#startDate').val(), 'DD/MM/YYYY hh:mm A').valueOf();
                var endDate = moment($('#endDate').val(), 'DD/MM/YYYY hh:mm A').valueOf();
                $('#error_endDate').html('').parents('.form-group').removeClass('has-error');
                if (endDate < startDate) {
                    $('#error_endDate').html('Event end date-time can not be before the start date.').parents('.form-group').addClass('has-error');
                }
            });

            $('.datetimepicker').on('click', function () {
                if ($(this).is('#startDate')) {
                    $('#endDate').datetimepicker('hide');
                }
                if ($(this).is('#endDate')) {
                    $('#startDate').datetimepicker('hide');
                }
            });


            $('.question_repeater').repeater({
                initEmpty: false,
                show: function () {
                    $(this).slideDown();
                    var counter = $(this).parents('.question_repeater').find('.question_count');
                    var question_count = counter.data('count');
                    question_count++;
                    counter.data('count', question_count).html(question_count + ' Question(s)');
                    $('#error_question_repeater').html('');

                    init_autosize();
                    init_plugins();
                },
                hide: function (deleteElement) {
                    $(this).slideUp(deleteElement);
                    var counter = $(this).parents('.question_repeater').find('.question_count');
                    var question_count = counter.data('count');
                    question_count--;
                    counter.data('count', question_count).html(question_count + ' Question(s)');
                    if (question_count == 0) {
                        $('#error_question_repeater').html('Add at least one queston.');
                    }
                },
            });

            $('#name').on('change', function () {
                $('#error_name').html('').parents('.form-group').removeClass('has-error');
                if ($(this).val().trim() == '') {
                    $('#error_name').html('Enter event name.').parents('.form-group').addClass('has-error');
                }
            });

            $('#Location').on('change', function () {
                $('#error_Location').html('').parents('.form-group').removeClass('has-error');
                if ($(this).val().trim() == '') {
                    $('#error_Location').html('Enter location.').parents('.form-group').addClass('has-error');
                }
            });

            $('input:radio[name="question_for"]').change(function () {
                $('#error_question_for').html('').parents('.form-group').removeClass('has-error');
                if (!$(this).is(':checked')) {
                    $('#error_question_for').html('Select at least one option.').parents('.form-group').addClass('has-error');
                }
            });

            $('input:radio[name="ctl00$ContentPlaceHolder1$event_mode"]').change(function () {
                //debugger;
                //alert('1');
                $('#error_event_mode, #error_start_at, #error_end_at').html('').parents('.form-group').removeClass('has-error');
                $('.datetimepicker').val('');
                if (!$(this).is(':checked')) {
                    $('#error_event_mode').html('Select at least one option.').parents('.form-group').addClass('has-error');
                }

                if ($(this).val() == 'rdbPeriodic') {
                    //alert('2');
                    $('.dates_div_group').slideDown();
                }
                else {
                    //alert('3');
                    $('.dates_div_group').slideUp();
                }
            });

            $('.chkEnableNegativeFeedback').change(function () {
                //alert('dhfjhsd');
                $('.dvEnableNegativeFeedback').toggle();
            })

            $('input:radio[name="ctl00$ContentPlaceHolder1$question_for"]').change(function () {


                if ($(this).val() == 'rdbRetailer') {
                    //alert('2');
                    $('.dvEnable_RetailerFeedback_Alerts').slideDown();
                }
                else {
                    //alert('3');
                    $('.dvEnable_RetailerFeedback_Alerts').slideUp();
                }
            });

            $('input:radio[name="ctl00$ContentPlaceHolder1$question_for"]').change(function () {


                if ($(this).val() == 'rdbCustomer') {
                    //alert('2');
                    $('.dvConfigure_Mandatory_Fields_Cust').slideDown();
                }
                else {
                    //alert('3');
                    $('.dvConfigure_Mandatory_Fields_Cust').slideUp();
                }
            });



            $('#startDate').on('change', function () {
                $('#error_startDate').html('').parents('.form-group').removeClass('has-error');
                if ($(this).val().trim() == '') {
                    $('#error_startDate').html('Select event start date and time.').parents('.form-group').addClass('has-error');
                }
            });

            $('#endDate').on('change', function () {
                $('#error_endDate').html('').parents('.form-group').removeClass('has-error');
                if ($(this).val().trim() == '') {
                    $('#error_endDate').html('Select event end date and time.').parents('.form-group').addClass('has-error');
                }
            });

            $('body').on('change', '.question_repeater .question_textarea', function () {
                var error_ele = $(this).parent().find('.error_question');
                error_ele.html('').parents('.form-group').removeClass('has-error');
                if ($(this).val().trim() == '') {
                    $(this).parent().find('.error_question').html('Enter question.').parents('.form-group').addClass('has-error');
                }
            });

            $('body').on('change', '.question_repeater .type_select', function () {
                //debugger;
                var error_ele = $(this).parent().find('.error_type');
                error_ele.html('').parents('.form-group').removeClass('has-error');
                //alert($(this).val());
                if ($(this).val() == 'select') {
                    $(this).parent().find('.error_type').html('Select answer type.').parents('.form-group').addClass('has-error');
                }
                if ($(this).val() == 'Options') {
                    $(this).closest('.form-group').find('.options_group').slideDown();
                    $(this).closest('.form-group').find('.clsIncludeTicketRemarks').slideUp();
                }
                else {
                    $(this).closest('.form-group').find('.options_group').slideUp();
                }

                if ($(this).val() == 'Emoji' || $(this).val() == 'Star' || $(this).val() == 'NPS') {
                    $(this).closest('.form-group').find('.clsFlag_Negative').slideDown();
                    $(this).closest('.form-group').find('.clsIncludeTicketRemarks').slideUp();
                }
                else if ($(this).val() == 'Text') {
                    $(this).closest('.form-group').find('.clsIncludeTicketRemarks').slideDown();
                    $(this).closest('.form-group').find('.clsFlag_Negative').slideUp();
                }
                else if ($(this).val() != 'Emoji' || $(this).val() != 'Star' || $(this).val() != 'NPS') {
                    $(this).closest('.form-group').find('.clsFlag_Negative').slideUp();
                }
                else if ($(this).val() != 'Text') {
                    $(this).closest('.form-group').find('.clsIncludeTicketRemarks').slideUp();
                }



            });

            //$('body').on('change', '.question_repeater .text_option', function () {
            //    var error_ele = $(this).parent().find('.error_option');
            //    error_ele.html('').parents('.form-group').removeClass('has-error');
            //    if ($(this).val().trim() == '')
            //    {
            //        $(this).parent().find('.error_option').html('Enter option.').parents('.form-group').addClass('has-error');
            //    }
            //});

            //$('#event_form').submit(function (event) {

            $('#btnSave').click(function (event) {
                debugger;

                var is_valid = true;

                if ($('#name').val().trim() == '') {
                    is_valid = false;
                    $('#error_name').html('Enter event name.').parents('.form-group').addClass('has-error');
                }

                if ($('#Location').val().trim() == '') {
                    is_valid = false;
                    $('#error_Location').html('Enter location.').parents('.form-group').addClass('has-error');
                }


                if ($('input:radio[name="ctl00$ContentPlaceHolder1$event_mode"]:checked').val() == 'rdbPeriodic') {
                    if ($('#startDate').val().trim() == '') {
                        is_valid = false;
                        $('#error_startDate').html('Select event start date and time.').parents('.form-group').addClass('has-error');
                    }

                    if ($('#endDate').val().trim() == '') {
                        is_valid = false;
                        $('#error_endDate').html('Select event end date and time.').parents('.form-group').addClass('has-error');
                    }
                }

                if ($('#endDate').val().trim() != '' && $('#startDate').val().trim() != '') {
                    var startDate = moment($('#startDate').val(), 'DD/MM/YYYY hh:mm A').valueOf();
                    var endDate = moment($('#endDate').val(), 'DD/MM/YYYY hh:mm A').valueOf();
                    if (endDate < startDate) {
                        is_valid = false;
                        $('#error_endDate').html('Event end date-time can not be before the start date.').parents('.form-group').addClass('has-error');
                    }
                }

                $('.question_repeater .question_textarea').each(function (index, element) {
                    if ($(this).val().trim() == '') {
                        is_valid = false;
                        $(this).parent().find('.error_question').html('Enter question.').parents('.form-group').addClass('has-error');
                    }
                });


                $('.question_repeater .type_select').each(function (index, element) {
                    if ($(this).val() == 'select') {
                        is_valid = false;
                        $(this).parent().find('.error_type').html('Select answer type.').parents('.form-group').addClass('has-error');
                    }

                });

                if ($('.question_repeater .question_textarea').length == 0) {
                    is_valid = false;

                    $('#error_question_repeater').html('Add at least one queston.');
                }

                console.log('is_valid = ' + is_valid);

                if (!is_valid) {
                    event.preventDefault();
                }
            });

            $("#txtCategory").on('input', function () {
                var val = this.value;

                $('#hdnCategory').val("");
                if ($('#dlCategory option').filter(function () {
                    if (this.value.toUpperCase() === val.toUpperCase()) {
                        $('#hdnCategory').val($(this).attr('text'));
                    }
                    return this.value.toUpperCase() === val.toUpperCase();
                }).length) {
                    $("#btnCategoryChange").click();
                }
            });

            $("#txtSubCategory").on('input', function () {
                var val = this.value;

                $('#hdnSubCategory').val("");
                if ($('#dlSubCategory option').filter(function () {
                    if (this.value.toUpperCase() === val.toUpperCase()) {
                        //alert($(this).attr('text'));
                        $('#hdnSubCategory').val($(this).attr('text'));
                    }
                    return this.value.toUpperCase() === val.toUpperCase();
                }).length) {
                }
            });

            $("#txtassetLocation").on('input', function () {
                var val = this.value;

                $('#hdnassetLocation').val("");
                if ($('#dlassetLocation option').filter(function () {
                    if (this.value.toUpperCase() === val.toUpperCase()) {
                        //alert($(this).attr('text'));
                        $('#hdnassetLocation').val($(this).attr('text'));
                    }
                    return this.value.toUpperCase() === val.toUpperCase();
                }).length) {
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
                            <div class="m-portlet__head-wrapper">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">Configure Feedback Form
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
                                        <asp:Button ID="btnSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnSave_Click" Text="Save" ClientIDMode="Static" ValidationGroup="Feedback" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--begin: Form Body -->
                        <div class="m-portlet__body">
                            <div class="row">
                                <div class="col-xl-12">
                                    <div class="m-form__section m-form__section--first">
                                        <div class="form-group m-form__group row">
                                            <label class="col-xl-2 col-lg-3 col-form-label font-weight-bold" style="padding-right: 0px;">
                                                Feedback Form Name:</label>
                                            <div class="col-xl-4 col-lg-9">
                                                <asp:TextBox ID="name" runat="server" class="form-control m-input" placeholder="Enter the name of your Feedback Form" ClientIDMode="Static"></asp:TextBox>
                                                <span id="error_name" class="text-danger font-weight-bold"></span>
                                                <span class="error_type6 text-danger font-weight-bold"></span>

                                            </div>
                                            <label class="col-xl-2 col-lg-3 col-form-label font-weight-bold">
                                                Upload Form Banner:</label>
                                            <div class="col-xl-4 col-lg-9" style="padding-top: 8px;">
                                                <input type="file" name="FileUpload_BannerImage" id="FileUpload_BannerImage" style="padding-right: 20px;" />
                                                <input type="hidden" name="Is_ImageUpload_ValidFile" id="Is_ImageUpload_ValidFile" />
                                                <span class="error_type7 text-danger font-weight-bold"></span>

                                            </div>
                                        </div>
                                        <div class="m-form__group form-group row">
                                            <label class="col-2 col-form-label font-weight-bold">
                                                <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="Select For which whom you are configuring this Feedback form. <RETAILER> option is relevant when your property is a Mall. <VISITORS> Option can be selected if you want to add the Feedback form in your VMS Configuration ">
                                                    <i class="fa fa-info-circle"></i>
                                                </a>
                                                Questions For</label>
                                            <div class="col-10">
                                                <div class="m-radio-inline">
                                                    <label class="m-radio">
                                                        <asp:RadioButton ID="rdbCustomer" runat="server" GroupName="question_for" Checked="true" ClientIDMode="Static" />
                                                        Customers
																		<span></span>
                                                    </label>
                                                    <label class="m-radio">
                                                        <asp:RadioButton ID="rdbRetailer" runat="server" GroupName="question_for" ClientIDMode="Static" />
                                                        Retailers
																		<span></span>
                                                    </label>
                                                    <label class="m-radio">
                                                        <asp:RadioButton ID="rdbVisitor" runat="server" GroupName="question_for" ClientIDMode="Static" />Visitors
																		<span></span>
                                                    </label>
                                                    <label class="m-radio m-radio--disabled">
                                                        <input type="radio" id="rdbEmployee" runat="server" group="question_for" disabled="" />
                                                        Employee

                                                                <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-danger m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="top" title="" data-original-title="This Feature is Under Development">
                                                                    <i class="fa fa-info-circle"></i>
                                                                </a>
                                                    </label>
                                                </div>
                                                <span id="error_question_for" class="text-danger font-weight-bold"></span>

                                            </div>

                                        </div>

                                        <div class="dvEnable_RetailerFeedback_Alerts" style="display: none;">

                                            <div class="m-form__group form-group row">

                                                <span class="col-1 m-switch m-switch--outline m-switch--icon m-switch--success" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="Email Reminders are sent every week until they submit a feedback for the current Month.">
                                                    <label>
                                                        <input type="checkbox" name="">
                                                        <span></span>
                                                    </label>
                                                </span>
                                                <label class="col-form-label">Enable to send automated Email Reminders to Retailers to submit Feedback </label>
                                            </div>
                                        </div>

                                        <div class="dvConfigure_Mandatory_Fields_Cust">
                                            <div class="m-form__group form-group row">

                                                <label class="col-xl-4 col-form-label font-weight-bold">
                                                    <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="Select Which Customer Information Fields are mandatory while submitting this Feedback Form">
                                                        <i class="fa fa-info-circle" aria-hidden="true"></i>
                                                    </a>
                                                    Select Mandatory Fields for Customer Data

                                                </label>
                                                <div class="col-xl-8 m-checkbox-inline" style="padding: 10px;">
                                                    <label class="m-checkbox m-checkbox--solid m-checkbox--brand">
                                                        <input id="CheckBox1" runat="server" type="checkbox" checked="true" />
                                                        First Name
									                    <span></span>
                                                    </label>
                                                    <label class="m-checkbox m-checkbox--solid m-checkbox--brand">
                                                        <input id="CheckBox2" runat="server" type="checkbox" checked="true" />
                                                        Last Name
									                    <span></span>
                                                    </label>
                                                    <label class="m-checkbox m-checkbox--solid m-checkbox--brand">
                                                        <input id="CheckBox3" runat="server" type="checkbox" checked="true" />
                                                        Email
										                <span></span>
                                                    </label>
                                                    <label class="m-checkbox m-checkbox--solid m-checkbox--brand">
                                                        <input id="CheckBox4" runat="server" type="checkbox" checked="true" />
                                                        Contact
										                <span></span>
                                                    </label>
                                                    <label class="m-checkbox m-checkbox--solid m-checkbox--brand">
                                                        <input id="CheckBox5" runat="server" type="checkbox" checked="true" />
                                                        Gender
										                <span></span>
                                                    </label>
                                                </div>

                                            </div>
                                        </div>


                                        <div class="m-form__group form-group row">
                                            <label class="col-2 col-form-label font-weight-bold">
                                                <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="Choose if you want your Feedback form to be active Always OR Between a particular time Period ">
                                                    <i class="fa fa-info-circle"></i>
                                                </a>
                                                Active Mode</label>
                                            <div class="col-10">
                                                <div class="m-radio-inline">
                                                    <label class="m-radio">
                                                        <asp:RadioButton ID="rdbDaily" runat="server" GroupName="event_mode" Checked="true" />
                                                        Always Active
																		<span></span>
                                                    </label>
                                                    <label class="m-radio">
                                                        <asp:RadioButton ID="rdbPeriodic" runat="server" GroupName="event_mode" />
                                                        Between Scheduled Period
																		<span></span>
                                                    </label>
                                                </div>
                                                <span id="error_event_mode" class="text-danger font-weight-bold"></span>
                                            </div>
                                        </div>




                                        <div class="dates_div_group" style="display: none;" id="dvDate" runat="server">
                                            <div class="form-group m-form__group row" id="dvStartDate" runat="server">
                                                <label class="col-xl-2 col-lg-3 col-form-label font-weight-bold">* Start at</label>
                                                <div class="col-xl-10 col-lg-9">
                                                    <div class="input-group date">
                                                        <asp:TextBox ID="startDate" runat="server" class="form-control m-input datetimepicker" ReadOnly="true" ClientIDMode="Static" placeholder="Select date & time"></asp:TextBox>
                                                        <div class="input-group-append">
                                                            <span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
                                                        </div>
                                                    </div>
                                                    <span id="error_startDate" class="text-danger font-weight-bold"></span>
                                                </div>
                                            </div>
                                            <div class="form-group m-form__group row" id="dvEndDate" runat="server">
                                                <label class="col-xl-2 col-lg-3 col-form-label font-weight-bold">* End at</label>
                                                <div class="col-xl-10 col-lg-9">
                                                    <div class="input-group date">
                                                        <asp:TextBox ID="endDate" runat="server" class="form-control m-input datetimepicker" ReadOnly="true" ClientIDMode="Static" placeholder="Select date & time"></asp:TextBox>
                                                        <div class="input-group-append">
                                                            <span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
                                                        </div>
                                                    </div>
                                                    <span id="error_endDate" class="text-danger font-weight-bold"></span>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="form-group m-form__group row">
                                            <label class="col-xl-2 col-lg-3 col-form-label font-weight-bold">
                                                <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="Enter the Name of Location where this feedback form will be used. Eg. Phoenix Mall , Kurla">
                                                    <i class="fa fa-info-circle"></i>
                                                </a>
                                                Location</label>
                                            <div class="col-xl-10 col-lg-9">
                                                <asp:TextBox ID="Location" runat="server" class="form-control m-input" placeholder="Location Assigned to Feedback Form" ClientIDMode="Static"></asp:TextBox>
                                                 <span id="error_Location" class="text-danger font-weight-bold"></span>

                                            </div>
                                        </div>
                                        <div class="form-group m-form__group row">
                                            <div class="col-xl-7">

                                                <label class="m-checkbox m-checkbox--solid m-checkbox--brand chkEnableNegativeFeedback" style="margin-top: 10px;">
                                                    <input type="checkbox" id="chkEnableNegativeFeedback" runat="server" />
                                                    Enable and configure automated ticketing on Negative Feedbacks
											        <span></span>
                                                </label>

                                                <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="right" title="" data-original-title="If you have Ticketing Module enabled, You can check this box and configure the feedback form to recieve certain Negative Feedbacks">
                                                    <i class="fa fa-info-circle"></i>
                                                </a>
                                            </div>
                                            <div class="col-xl-5">
                                                <button type="button" id="btn_Chk_Fdbk_Info" class="btn btn-metal" data-toggle="modal" data-target="#m_modal_feedback_analysis">
                                                    <i class="fa fa-info-circle"></i>
                                                    Check how your Feedbacks are analysed
                                                </button>

                                            </div>
                                        </div>

                                        <div class="dvEnableNegativeFeedback" style="display: none;" id="dvEnableNegativeFeedback" runat="server">

                                            <div class="form-group m-form__group row">

                                                <label class="col-xl-3 col-form-label font-weight-bold">
                                                    <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="This ticket Category will be selected by default for the automatic Ticket">
                                                        <i class="fa fa-info-circle"></i>
                                                    </a>
                                                    Select Ticket Category
                                                </label>
                                                <div class="col-md-3">
                                                    <div class="m-form__group">
                                                        <asp:HiddenField ID="hdnCategory" runat="server" ClientIDMode="Static" />
                                                        <asp:Button ID="btnCategoryChange" runat="server" Style="display: none;" OnClick="btnCategoryChange_Click" ClientIDMode="Static" />

                                                        <input list="dlCategory" id="txtCategory" name="txtassetLocation"
                                                            class="form-control" runat="server" clientidmode="Static" />
                                                        <datalist id="dlCategory" runat="server" clientidmode="Static"></datalist>

                                                        <span id="CategoryError_Msg" style="color: red;"></span>

                                                        <%--<div class="m-form__control" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="Select the Answer Type for your Feedback point">
                                                                <select name="type" class="form-control m-input ">
                                                                    <option value="0" selected="selected">Answer Type</option>
                                                                    <option value="Emoji">Emoji</option>
                                                                    <option value="Text">Text</option>
                                                                    <option value="Options">Options</option>
                                                                    <option value="Star">Star</option>
                                                                    <option value="NPS">NPS</option>
                                                                </select>
                                                                <span class="error_type1 text-danger font-weight-bold">Answer Type error text</span>

                                                            </div>--%>
                                                    </div>
                                                </div>
                                                <label class="col-xl-3 col-form-label font-weight-bold">
                                                    <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="This ticket Sub-Category will be selected by default for the automatic Ticket">
                                                        <i class="fa fa-info-circle"></i>
                                                    </a>
                                                    Select Ticket Sub-Category
                                                </label>
                                                <div class="col-md-3">
                                                    <div class="m-form__group">
                                                        <asp:HiddenField ID="hdnSubCategory" runat="server" ClientIDMode="Static" />
                                                        <asp:Button ID="btnSubCategoryChange" runat="server" Style="display: none;" ClientIDMode="Static" />

                                                        <input list="dlSubCategory" id="txtSubCategory" name="txtassetLocation"
                                                            class="form-control" runat="server" clientidmode="Static" />
                                                        <datalist id="dlSubCategory" runat="server" clientidmode="Static"></datalist>
                                                    </div>
                                                </div>


                                            </div>

                                            <div class="form-group m-form__group row">

                                                <label class="col-xl-3 col-form-label font-weight-bold">
                                                    <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="This Location ( Configured in your General Setup >> Location Map )will be selected by default for the automatic Ticket">
                                                        <i class="fa fa-info-circle"></i>
                                                    </a>
                                                    Assign Location for Ticket
                                                </label>
                                                <div class="col-md-9">
                                                    <div class="m-form__group">
                                                        <asp:HiddenField ID="hdnassetLocation" runat="server" ClientIDMode="Static" />
                                                        <input list="dlassetLocation" id="txtassetLocation" name="txtassetLocation"
                                                            class="form-control" runat="server" clientidmode="Static" />
                                                        <datalist id="dlassetLocation" runat="server" clientidmode="Static"></datalist>

                                                        <span id="LocationError_Msg" style="color: red;"></span>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="form-group m-form__group row">
                                                <div class="col-xl-12">

                                                    <div class="input-group m-input-group">
                                                        <a href="#" style="width: 25px; height: 25px;" class="btn btn-outline-danger m-btn m-btn--icon m-btn--icon-only m-btn--outline-2x m-btn--pill" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="If checked , the system will keep track of Negative Responses on this question and raise a Red Flag. When total no. of Red-Flags on a Feedback are equal to the Number entered in the NEGATIVE FLAGS Textbox above , an automated Ticket will raise">
                                                            <i class="fa fa-flag"></i>
                                                        </a>
                                                        <div class="input-group-prepend"><span class="input-group-text" id="basic-addon1">Raise ticket with configured parameters when </span></div>

                                                        <input type="text" id="txtTotalNegativeFlag" runat="server" class="form-control m-input" placeholder="(Enter No. of Negative Flags)" aria-describedby="basic-addon1" />
                                                        <div class="input-group-append">

                                                            <span class="input-group-text" id="basic-addon2">Negative Flags are detected on feedback submission</span>
                                                        </div>
                                                    </div>
                                                    <span class="m-form__help m--font-danger font-weight-bold">Error Text here</span>
                                                </div>
                                            </div>

                                        </div>


                                    </div>
                                </div>
                                <div class="col-xl-12">
                                    <div class="m-form__section m--align-center">

                                        <div class="m-form__heading" style="text-align: center; padding-top: 10px; padding-bottom: 10px;">
                                            <h3 class="m-form__heading-title" style="line-height: 2.0; background: aliceblue; font-size: 1.2rem;">Feedback Points</h3>
                                        </div>
                                        <div class="question_repeater">
                                            <div class="form-group  m-form__group row">



                                                <div data-repeater-list="Customer" class="col-lg-12" runat="server" id="Customer1">

                                                    <%-- <%=EventBind()%>  --%>

                                                    <div data-repeater-item="" class="form-group m-form__group row" runat="server" id="dvCustomer">
                                                        <div class="col-md-7">
                                                            <div class="m-form__group">
                                                                <div class="m-form__control">
                                                                    <asp:TextBox ID="txtCustomerQuestion" runat="server" ClientIDMode="Static" TextMode="MultiLine" class="form-control m-input autosize_textarea question_textarea" placeholder="Enter question description" Rows="1"></asp:TextBox>
                                                                    <span class="error_question text-danger font-weight-bold"></span>
                                                                </div>

                                                                <div class="clsFlag_Negative" style="display: none;">

                                                                    <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-danger m-btn m-btn--icon m-btn--icon-only m-btn--outline-2x m-btn--pill" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="If checked , the system will keep track of Negative Responses on this question and raise a Red Flag. When total no. of Red-Flags on a Feedback are equal to the Number entered in the NEGATIVE FLAGS Textbox above , an automated Ticket will raise">
                                                                        <i class="fa fa-flag"></i>
                                                                    </a>
                                                                    <label class="m-checkbox m-checkbox--solid m-checkbox--brand" style="margin-top: 10px;">
                                                                        <input type="checkbox" id="chkFlag_Negative" runat="server" />
                                                                        Flag on Negative Feedback
											                            <span></span>
                                                                    </label>


                                                                </div>
                                                            </div>
                                                            <span class="error_type5 text-danger font-weight-bold"></span>
                                                            <%--<span class="error_type text-danger font-weight-bold">Answer Type error text</span>--%>

                                                            <div class="d-md-none m--margin-bottom-10"></div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="m-form__group">
                                                                <div class="m-form__control" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="Select the Answer Type for your Feedback point">
                                                                    <select name="type" class="form-control m-input type_select">
                                                                        <option value="select" selected="selected">Answer Type</option>
                                                                        <option value="Emoji">Emoji</option>
                                                                        <option value="Text">Text</option>
                                                                        <option value="Options">Options</option>
                                                                        <option value="Star">Star</option>
                                                                        <option value="NPS">NPS</option>
                                                                    </select>

                                                                    <span class="error_type text-danger font-weight-bold"></span>
                                                                </div>


                                                                <div class="clsIncludeTicketRemarks" style="display: none;">
                                                                    <label class="m-checkbox m-checkbox--solid m-checkbox--brand" style="margin-top: 10px;">
                                                                        <input type="checkbox" id="chkIncludeTicketRemarks" runat="server" />
                                                                        Include in Ticket Remarks
											                            <span></span>
                                                                    </label>
                                                                    <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="If Checked , whatever text is entered in the text field for this question , will be added as Remarks for the automated ticket">
                                                                        <i class="fa fa-info-circle"></i>
                                                                    </a>
                                                                </div>
                                                            </div>
                                                            <%--<span class="error_type text-danger font-weight-bold">Answer Type error text</span>--%>
                                                        </div>

                                                        <div class="col-md-1">
                                                            <div data-repeater-delete="" class="btn btn-danger m-btn m-btn--icon m-btn--icon-only">
                                                                <i class="la la-trash"></i>
                                                            </div>
                                                        </div>

                                                        <div class="options_group row col-md-12" style="display: none;">
                                                            <div class="col-md-12 m--margin-bottom-10 font-weight-bold">Enter Options</div>
                                                            <div class="col-md-6 m--margin-bottom-10">
                                                                <%--<input type="text" name="option1" class="form-control m-input text_option" placeholder="Enter option">--%>
                                                                <asp:TextBox ID="option1" runat="server" ClientIDMode="Static" class="form-control m-input text_option" placeholder="Enter option" Text=""></asp:TextBox>
                                                                <span class="error_option text-danger small"></span>
                                                            </div>
                                                            <div class="col-md-6 m--margin-bottom-10">
                                                                <%--<input type="text" name="option2" class="form-control m-input text_option" placeholder="Enter option">--%>
                                                                <asp:TextBox ID="option2" runat="server" ClientIDMode="Static" class="form-control m-input text_option" placeholder="Enter option"></asp:TextBox>
                                                                <span class="error_option text-danger small"></span>
                                                            </div>
                                                            <div class="col-md-6 m--margin-bottom-10">
                                                                <%--<input type="text" name="option3" class="form-control m-input text_option" placeholder="Enter option">--%>
                                                                <asp:TextBox ID="option3" runat="server" ClientIDMode="Static" class="form-control m-input text_option" placeholder="Enter option"></asp:TextBox>
                                                                <span class="error_option text-danger small"></span>
                                                            </div>
                                                            <div class="col-md-6 m--margin-bottom-10">
                                                                <%--<input type="text" name="option4" class="form-control m-input text_option" placeholder="Enter option">--%>
                                                                <asp:TextBox ID="option4" runat="server" ClientIDMode="Static" class="form-control m-input text_option" placeholder="Enter option"></asp:TextBox>
                                                                <span class="error_option text-danger small"></span>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="m-form__group form-group row">
                                                <div class="col-lg-3">
                                                    <div data-repeater-create="" class="btn btn-accent m-btn m-btn--icon m-btn--pill m-btn--wide">
                                                        <span>
                                                            <i class="la la-plus"></i>
                                                            <span>Add more questions</span>
                                                        </span>
                                                    </div>
                                                </div>
                                                <div class="col-lg-9 m--align-left">
                                                    <label id="lblCustQueCount" runat="server" class="col-xl-3 col-lg-3 col-form-label font-weight-bold question_count" data-count="1">1 Question(s)</label>
                                                </div>
                                                <span id="error_question_repeater" class="text-danger small"></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                            </div>
                        </div>


                        </form>
                    </div>
                    <!--end::Portlet-->
                </div>
            </div>


            <div class="modal fade" id="m_modal_feedback_analysis" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Sample Feedback Analysis</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <label>Sample Feedback Analysis Data</label>
                        </div>
                        <%--<div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-primary">Save changes</button>
                        </div>--%>
                    </div>
                </div>
            </div>



        </div>
    </div>


</asp:Content>
