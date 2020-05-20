<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EventDetails.aspx.cs" Inherits="Upkeep_v3.Feedback.EventDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript" ></script>
    <script>
        function init_autosize()
        {
            var autosize_textarea = $('.autosize_textarea');
            autosize(autosize_textarea);
            autosize.update(autosize_textarea);
        }

        $(document).ready(function()
        {
            
            init_autosize();
            init_plugins();

            $('.datetimepicker').datetimepicker({
                todayHighlight: true,
                autoclose: true,
                pickerPosition: 'bottom-right',
                format: 'dd/mm/yyyy HH:ii P',
                showMeridian: true,
                startDate: moment().format('YYYY-MM-DD'),
            }).on('changeDate', function(event)
            {
                var startDate = moment($('#startDate').val(), 'DD/MM/YYYY hh:mm A').valueOf();
                var endDate   = moment($('#endDate').val(), 'DD/MM/YYYY hh:mm A').valueOf();
                $('#error_endDate').html('').parents('.form-group').removeClass('has-error');
                if(endDate < startDate)
                {
                    $('#error_endDate').html('Event end date-time can not be before the start date.').parents('.form-group').addClass('has-error');
                }
            });

            $('.datetimepicker').on('click', function () {
                if ($(this).is('#startDate')) 
                {
                    $('#endDate').datetimepicker('hide');
                }
                if($(this).is('#endDate'))
                {
                    $('#startDate').datetimepicker('hide');
                }
            });


            $('.question_repeater').repeater({            
                initEmpty: false,
                show: function ()
                {
                    $(this).slideDown();
                    var counter = $(this).parents('.question_repeater').find('.question_count');
                    var question_count = counter.data('count');
                    question_count++;
                    counter.data('count',question_count).html(question_count +' Question(s)');
                    $('#error_question_repeater').html('');

                    init_autosize();
                    init_plugins();
                },
                hide: function (deleteElement)
                {                
                    $(this).slideUp(deleteElement);
                    var counter = $(this).parents('.question_repeater').find('.question_count');
                    var question_count = counter.data('count');
                    question_count--;
                    counter.data('count',question_count).html(question_count +' Question(s)');
                    if(question_count == 0)
                    {
                        $('#error_question_repeater').html('Add at least one queston.');
                    }
                },   
            });

            $('#name').on('change', function()
            {
                $('#error_name').html('').parents('.form-group').removeClass('has-error');
                if($(this).val().trim() == '')
                {
                    $('#error_name').html('Enter event name.').parents('.form-group').addClass('has-error');
                }
            });

            $('#Location').on('change', function()
            {
                $('#error_Location').html('').parents('.form-group').removeClass('has-error');
                if($(this).val().trim() == '')
                {
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

                if ($(this).val() == 'rdbPeriodic') 
                {
                    //alert('2');
                    $('.dates_div_group').slideDown();
                }
                else
                {
                    //alert('3');
                    $('.dates_div_group').slideUp();
                }
            });

            $('#startDate').on('change', function()
            {
                $('#error_startDate').html('').parents('.form-group').removeClass('has-error');
                if($(this).val().trim() == '')
                {
                    $('#error_startDate').html('Select event start date and time.').parents('.form-group').addClass('has-error');
                }
            });

            $('#endDate').on('change', function()
            {
                $('#error_endDate').html('').parents('.form-group').removeClass('has-error');
                if($(this).val().trim() == '')
                {
                    $('#error_endDate').html('Select event end date and time.').parents('.form-group').addClass('has-error');
                }
            });

            $('body').on('change', '.question_repeater .question_textarea', function()
            {
                var error_ele = $(this).parent().find('.error_question');
                error_ele.html('').parents('.form-group').removeClass('has-error');
                if($(this).val().trim() == '')
                {
                    $(this).parent().find('.error_question').html('Enter question.').parents('.form-group').addClass('has-error');
                }
            });

            $('body').on('change', '.question_repeater .type_select', function()
            {
                var error_ele = $(this).parent().find('.error_type');
                error_ele.html('').parents('.form-group').removeClass('has-error');
                if($(this).val() == '')
                {
                    $(this).parent().find('.error_type').html('Select answer type.').parents('.form-group').addClass('has-error');
                }
                if ($(this).val() == 'Options')
                {
                    $(this).closest('.form-group').find('.options_group').slideDown();
                }
                else {
                    $(this).closest('.form-group').find('.options_group').slideUp();
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

            $('#event_form').submit(function(event)
            {
                var is_valid = true;

                if($('#name').val().trim() == '')
                {
                    is_valid = false;
                    $('#error_name').html('Enter event name.').parents('.form-group').addClass('has-error');
                }

                if($('#Location').val().trim() == '')
                {
                    is_valid = false;
                    $('#error_Location').html('Enter location.').parents('.form-group').addClass('has-error');
                }

                if (!$('input:radio[name="question_for"]').is(':checked')) {
                    is_valid = false;
                    $('#error_question_for').html('Select at least one option.').parents('.form-group').addClass('has-error');
                }

                if (!$('input:radio[name="event_mode"]').is(':checked')) 
                {
                    is_valid = false;
                    $('#error_event_mode').html('Select at least one option.').parents('.form-group').addClass('has-error');
                }
                else if ($('input:radio[name="event_mode"]:checked').val() == 'rdbPeriodic')
                {
                    if ($('#startDate').val().trim() == '')
                    {
                        is_valid = false;
                        $('#error_startDate').html('Select event start date and time.').parents('.form-group').addClass('has-error');
                    }

                    if ($('#endDate').val().trim() == '')
                    {
                        is_valid = false;
                        $('#error_endDate').html('Select event end date and time.').parents('.form-group').addClass('has-error');
                    }
                }

                if($('#endDate').val().trim() != '' && $('#startDate').val().trim() != '')
                {
                    var startDate = moment($('#startDate').val(), 'DD/MM/YYYY hh:mm A').valueOf();
                    var endDate   = moment($('#endDate').val(), 'DD/MM/YYYY hh:mm A').valueOf();
                    if(endDate < startDate)
                    {
                        is_valid = false;
                        $('#error_endDate').html('Event end date-time can not be before the start date.').parents('.form-group').addClass('has-error');
                    }
                }

                $('.question_repeater .question_textarea').each(function (index, element)
                {
                    if($(this).val().trim() == '')
                    {
                        is_valid = false;
                        $(this).parent().find('.error_question').html('Enter question.').parents('.form-group').addClass('has-error');
                    }
                });

                $('.question_repeater .type_select').each(function(index, element)
                {
                    if($(this).val() == '')
                    {
                        is_valid = false;
                        $(this).parent().find('.error_type').html('Select answer type.').parents('.form-group').addClass('has-error');
                    }
                    //if ($(this).val() == 'Options')
                    //{
                    //    $(this).closest('.form-group').find('.text_option').each(function (index, element)
                    //    {
                    //        if ($(this).val().trim() == '')
                    //        {
                    //            is_valid = false;
                    //            $(this).parent().find('.error_option').html('Enter option').parents('.form-group').addClass('has-error');
                    //        }
                    //    });
                    //}
                });

                if($('.question_repeater .question_textarea').length == 0)
                {
                    is_valid = false;
                    
                    $('#error_question_repeater').html('Add at least one queston.');
                }

                console.log('is_valid = ' + is_valid);

                if( ! is_valid)
                {
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

                                <form class="m-form m-form--label-align-left- m-form--state-" id="event_form" runat="server" method="post">

                                    <div class="m-portlet__head">
                                        <div class="m-portlet__head-wrapper">
                                            <div class="m-portlet__head-caption">
                                                <div class="m-portlet__head-title">
                                                    <h3 class="m-portlet__head-text">Event details
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
                                                    <asp:Button ID="btnSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnSave_Click" Text="Save" />
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
                                                        <div class="form-group m-form__group row">
                                                            <label class="col-xl-3 col-lg-3 col-form-label">* Event Name:</label>
                                                            <div class="col-xl-9 col-lg-9">
                                                                <asp:TextBox id="name" runat="server" class="form-control m-input" placeholder="Event name"></asp:TextBox>
                                                                <span id="error_name" class="text-danger small"></span>
                                                            </div>
                                                        </div>
                                                        <div class="m-form__group form-group row">
															<label class="col-3 col-form-label">* Questions For</label>
															<div class="col-9">
																<div class="m-radio-inline">
																	<label class="m-radio" >
                                                                        <asp:RadioButton id="rdbCustomer" runat="server" GroupName="question_for" Checked="true" /> Customers
																		<span></span>
																	</label>
																	<label class="m-radio">
                                                                         <asp:RadioButton id="rdbRetailer" runat="server" GroupName="question_for" /> Retailers
																		<span></span>
																	</label>
                                                                    <label class="m-radio">
                                                                         <asp:RadioButton id="rdbBoth" runat="server" GroupName="question_for" /> Both
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
																	<label class="m-radio" >
                                                                        <asp:RadioButton id="rdbDaily" runat="server" GroupName="event_mode" Checked="true" /> Daily/Monthly
																		<span></span>
																	</label>
																	<label class="m-radio">
                                                                         <asp:RadioButton id="rdbPeriodic" runat="server" GroupName="event_mode" ClientIDMode="Static" /> Periodic
																		<span></span>
																	</label>
																</div>
                                                                <span id="error_event_mode" class="text-danger small"></span>
															</div>
														</div>


                                                        <div class="form-group m-form__group row">
                                                            <label class="col-xl-3 col-lg-3 col-form-label">* Location:</label>
                                                            <div class="col-xl-9 col-lg-9">
                                                                <asp:TextBox id="Location" runat="server" class="form-control m-input" placeholder="Event Location"></asp:TextBox>
                                                               <span id="error_Location" class="text-danger small"></span>
                                                            </div>
                                                        </div>
                                                        
                                                        <div class="dates_div_group" style="display: none;" id="dvDate" runat="server">
                                                            <div class="form-group m-form__group row" id="dvStartDate" runat="server">
                                                                <label class="col-xl-3 col-lg-3 col-form-label">* Start at</label>
                                                                <div class="col-xl-9 col-lg-9">
                                                                    <div class="input-group date">
                                                                        <asp:TextBox id="startDate" runat="server" class="form-control m-input datetimepicker" readonly="true" placeholder="Select date & time"></asp:TextBox>
                                                                        <div class="input-group-append">
                                                                            <span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
                                                                        </div>
                                                                    </div>
                                                                    <span id="error_startDate" class="text-danger small"></span>
                                                                </div>
                                                            </div>
                                                            <div class="form-group m-form__group row" id="dvEndDate" runat="server">
                                                                <label class="col-xl-3 col-lg-3 col-form-label">* End at</label>
                                                                <div class="col-xl-9 col-lg-9">
                                                                    <div class="input-group date">
                                                                        <asp:TextBox id="endDate" runat="server" class="form-control m-input datetimepicker" readonly="true" placeholder="Select date & time"></asp:TextBox>
                                                                        <div class="input-group-append">
                                                                            <span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
                                                                        </div>
                                                                    </div>
                                                                    <span id="error_endDate" class="text-danger small"></span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-xl-12">
                                                    <div class="m-separator m-separator--dashed m-separator--lg"></div>
                                                    <div class="m-form__section">
                                                        <div class="m-form__heading">
                                                            <h3 class="m-form__heading-title">Questions
                                                            </h3>
                                                        </div>
                                                        <div class="question_repeater">
                                                            <div class="form-group  m-form__group row">

                                                              

                                                                <div data-repeater-list="Customer" class="col-lg-12" runat="server" id="Customer1">

                                                                      <%-- <%=EventBind()%>  --%>

                                                                    <div data-repeater-item="" class="form-group m-form__group row" runat="server" id="dvCustomer">
                                                                        <div class="col-md-8">
                                                                            <div class="m-form__group">
                                                                                <div class="m-form__control">
                                                                                    <asp:TextBox id="txtCustomerQuestion" runat="server" ClientIDMode="Static" TextMode="MultiLine" class="form-control m-input autosize_textarea question_textarea" placeholder="Enter question" rows="1"></asp:TextBox>
                                                                                
                                                                                <%--<textarea class="form-control m-input autosize_textarea question_textarea" placeholder="Enter question" rows="1" runat="server" id="txtquestion" name="txtquestion"></textarea>--%>
																						
                                                                                </div>
                                                                            </div>
                                                                            <div class="d-md-none m--margin-bottom-10"></div>
                                                                        </div>
                                                                        <div class="col-md-3">
                                                                            <div class="m-form__group">
                                                                                <div class="m-form__control">
                                                                                    <select name="type" class="form-control m-input type_select">
                                                                                        <option value="" selected="selected">Select Answer Type</option>
                                                                                        <option value="Emoji">Emoji</option>
                                                                                        <option value="Text">Text</option>
                                                                                        <option value="Options">Options</option>
                                                                                        <option value="Star">Star</option>
                                                                                        <option value="NPS">NPS</option>
                                                                                    </select>
                                                                                    <span class="error_type text-danger small"></span>
                                                                                </div>
                                                                            </div>
                                                                            <div class="d-md-none m--margin-bottom-10"></div>
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
                                                                                    <asp:TextBox ID="option1" runat="server" class="form-control m-input text_option" placeholder="Enter option" Text="" ></asp:TextBox>
																					<span class="error_option text-danger small"></span>
																				</div>
																				<div class="col-md-6 m--margin-bottom-10">
																					<%--<input type="text" name="option2" class="form-control m-input text_option" placeholder="Enter option">--%>
                                                                                    <asp:TextBox ID="option2" runat="server" class="form-control m-input text_option" placeholder="Enter option" ></asp:TextBox>
																					<span class="error_option text-danger small"></span>
																				</div>
																				<div class="col-md-6 m--margin-bottom-10">
																					<%--<input type="text" name="option3" class="form-control m-input text_option" placeholder="Enter option">--%>
                                                                                    <asp:TextBox ID="option3" runat="server" class="form-control m-input text_option" placeholder="Enter option" ></asp:TextBox>
																					<span class="error_option text-danger small"></span>
																				</div>
																				<div class="col-md-6 m--margin-bottom-10">
																					<%--<input type="text" name="option4" class="form-control m-input text_option" placeholder="Enter option">--%>
                                                                                     <asp:TextBox ID="option4" runat="server" class="form-control m-input text_option" placeholder="Enter option" ></asp:TextBox>
																					<span class="error_option text-danger small"></span>
																				</div>
																			</div>

                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="m-form__group form-group row">
                                                                <div class="col-lg-4">
                                                                    <div data-repeater-create="" class="btn btn-accent m-btn m-btn--icon m-btn--pill m-btn--wide">
                                                                        <span>
                                                                            <i class="la la-plus"></i>
                                                                            <span>Add more questions</span>
                                                                        </span>
                                                                    </div>
                                                                </div>
                                                                <div class="col-lg-8">
                                                                    <label id="lblCustQueCount" runat="server" class="col-xl-3 col-lg-3 col-form-label font-weight-bold question_count" data-count="1">1 Question(s)</label>
                                                                </div>
                                                                <span id="error_question_repeater" class="text-danger small"></span>
                                                            </div>
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
                </div>
            </div>


</asp:Content>
