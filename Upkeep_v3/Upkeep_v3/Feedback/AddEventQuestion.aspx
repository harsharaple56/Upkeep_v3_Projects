<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddEventQuestion.aspx.cs" Inherits="Upkeep_v3.Feedback.AddEventQuestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript" ></script>
    <script>
        function init_autosize() {
            var autosize_textarea = $('.autosize_textarea');
            autosize(autosize_textarea);
            autosize.update(autosize_textarea);
        }

        $(document).ready(function () {
            init_autosize();
            init_plugins();


            $('body').on('change', '#question', function () {
                $('#error_question').html('').parents('.form-group').removeClass('has-error');
                if ($(this).val().trim() == '') {
                    $('#error_question').html('Enter question.').parents('.form-group').addClass('has-error');
                }
            });

            $('body').on('change', '#type', function () {
                $('#error_type').html('').parents('.form-group').removeClass('has-error');
                if ($(this).val() == '') {
                    $('#error_type').html('Select answer type.').parents('.form-group').addClass('has-error');
                }
                if ($(this).val() == '3') {
                    $('#options_group').slideDown();
                }
                else {
                    $('#options_group').slideUp();
                }
            });

            $('body').on('change', '.text_option', function () {
                var error_ele = $(this).parent().find('.error_option');
                error_ele.html('').parents('.form-group').removeClass('has-error');
                if ($(this).val().trim() == '') {
                    $(this).parent().find('.error_option').html('Enter option.').parents('.form-group').addClass('has-error');
                }
            });

            $('#question_form').submit(function (event) {
                var is_valid = true;

                if ($('#question').val().trim() == '') {
                    is_valid = false;
                    $('#error_question').html('Enter question.').parents('.form-group').addClass('has-error');
                }

                if ($('#type').val() == '') {
                    is_valid = false;
                    $('#error_type').html('Select answer type.').parents('.form-group').addClass('has-error');
                }

                if ($('#type').val() == '3') {
                    $('#options_group').find('.text_option').each(function (index, element) {
                        if ($(this).val().trim() == '') {
                            is_valid = false;
                            $(this).parent().find('.error_option').html('Enter option').parents('.form-group').addClass('has-error');
                        }
                    });
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

                        <form class="m-form m-form--label-align-left- m-form--state-" runat="server" id="question_form" method="POST">

                            <div class="m-portlet__head">
                                <div class="m-portlet__head-progress">

                                    <!-- here can place a progress bar-->
                                </div>
                                <div class="m-portlet__head-wrapper">
                                    <div class="m-portlet__head-caption">
                                        <div class="m-portlet__head-title">
                                            <h3 class="m-portlet__head-text">Add new question
                                            </h3>
                                        </div>
                                    </div>
                                    <div class="m-portlet__head-tools">
                                        <a href="<%= Page.ResolveClientUrl("EventListing.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                            <span>
                                                <i class="la la-arrow-left"></i>
                                                <span>Back To Events</span>
                                            </span>
                                        </a>
                                        <div class="btn-group">
                                            <asp:Button ID="btnSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnSave_Click" Text="Save" />
                                            <%--<button type="submit" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" form="question_form">
														<span>
															<i class="la la-check"></i>
															<span>Save</span>
														</span>
													</button>--%>
                                            <%--<button type="button" class="btn btn-accent  dropdown-toggle dropdown-toggle-split m-btn m-btn--md" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
													</button>
													<div class="dropdown-menu dropdown-menu-right">
														<a class="dropdown-item" href="#"><i class="la la-plus"></i> Save & New</a>
														<a class="dropdown-item" href="#"><i class="la la-copy"></i> Save & Duplicate</a>
														<a class="dropdown-item" href="#"><i class="la la-undo"></i> Save & Close</a>
														<div class="dropdown-divider"></div>
														<a class="dropdown-item" href="#"><i class="la la-close"></i> Cancel</a>
													</div>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="m-portlet__body">
                                <%--<form class="m-form m-form--label-align-left- m-form--state-" id="question_form" action="" method="POST">--%>

                                <!--begin: Form Body -->
                                <div class="m-portlet__body">
                                    <div class="row">
                                        <div class="col-xl-12">
                                            <div class="m-form__section">
                                                <div class="form-group m-form__group row">
                                                    <div class="col-lg-12">
                                                        <div class="form-group m-form__group row">
                                                            <div class="col-md-9">
                                                                <div class="m-form__group">
                                                                    <div class="m-form__control">
                                                                        <%--<textarea id="question" class="form-control m-input autosize_textarea" placeholder="Enter question" rows="1" name="question"></textarea>--%>
                                                                        <asp:TextBox ID="question" runat="server" ClientIDMode="Static" TextMode="MultiLine" class="form-control m-input autosize_textarea" placeholder="Enter question" Rows="1"></asp:TextBox>
                                                                        <span id="error_question" class="text-danger large"></span>
                                                                    </div>
                                                                </div>
                                                                <div class="d-md-none m--margin-bottom-10"></div>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <div class="m-form__group">
                                                                    <div class="m-form__control">
                                                                       
                                                                        <asp:DropDownList ID="type" ClientIDMode="Static" runat="server" CssClass="form-control m-input">
                                                                            <asp:ListItem Value="" Text="Select Answer Type"></asp:ListItem>
                                                                            <asp:ListItem Value="1" Text="Emoji"></asp:ListItem>
                                                                            <asp:ListItem Value="2" Text="Text"></asp:ListItem>
                                                                            <asp:ListItem Value="3" Text="Options"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <span id="error_type" class="text-danger large"></span>
                                                                    </div>
                                                                </div>
                                                                <div class="d-md-none m--margin-bottom-10"></div>
                                                            </div>
                                                            <div id="options_group" class="row col-md-12" style="display: none;" runat="server">
                                                                <div class="col-md-12 m--margin-bottom-10 font-weight-bold">Enter Options</div>
                                                                <div class="col-md-6 m--margin-bottom-10">
                                                                    <%--<input type="text" name="option1" class="form-control m-input text_option" placeholder="Enter option">--%>
                                                                    <asp:TextBox ID="option1" runat="server" ClientIDMode="Static" class="form-control m-input text_option" placeholder="Enter option"></asp:TextBox>
                                                                    <span class="error_option text-danger small"></span>
                                                                </div>
                                                                <div class="col-md-6 m--margin-bottom-10">
                                                                    <%--<input type="text" name="option2" class="form-control m-input text_option" placeholder="Enter option">--%>
                                                                    <asp:TextBox ID="option2" runat="server" ClientIDMode="Static" class="form-control m-input text_option" placeholder="Enter option"></asp:TextBox>
                                                                    <span class="error_option text-danger small"></span>
                                                                </div>
                                                                <div class="col-md-6 m--margin-bottom-10">
                                                                    <%--<input type="text" name="option2" class="form-control m-input text_option" placeholder="Enter option">--%>
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
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%--</form>--%>
                            </div>
                        </form>
                    </div>
                    <!--end::Portlet-->
                </div>
            </div>
        </div>
    </div>

</asp:Content>
