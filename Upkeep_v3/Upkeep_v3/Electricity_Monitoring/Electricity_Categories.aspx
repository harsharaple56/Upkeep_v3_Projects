<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Electricity_Categories.aspx.cs" Inherits="Upkeep_v3.Electricity_Monitoring.Electricity_Categories" %>

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


            $('.category_repeater').repeater({
                initEmpty: false,
                show: function () {
                    $(this).slideDown();
                    var counter = $(this).parents('.category_repeater').find('.question_count');
                    var question_count = counter.data('count');
                    question_count++;
                    counter.data('count', question_count).html(question_count + ' Category(s)');
                    $('#error_category_repeater').html('');

                    init_autosize();
                    init_plugins();
                },
                hide: function (deleteElement) {
                    $(this).slideUp(deleteElement);
                    var counter = $(this).parents('.category_repeater').find('.question_count');
                    var question_count = counter.data('count');
                    question_count--;
                    counter.data('count', question_count).html(question_count + ' Category(s)');
                    if (question_count == 0) {
                        $('#error_category_repeater').html('Add at least one Category.');
                    }
                },
            });


            $('body').on('change', '.category_repeater .question_textarea', function () {
                var error_ele = $(this).parent().find('.error_question');
                error_ele.html('').parents('.form-group').removeClass('has-error');
                if ($(this).val().trim() == '') {
                    $(this).parent().find('.error_question').html('Enter Category.').parents('.form-group').addClass('has-error');
                }
            });

            $('body').on('change', '.category_repeater .type_select', function () {
                var error_ele = $(this).parent().find('.error_type');
                error_ele.html('').parents('.form-group').removeClass('has-error');

                if ($(this).val() == 'Options') {
                    $(this).closest('.form-group').find('.options_group').slideDown();
                }
                else {
                    $(this).closest('.form-group').find('.options_group').slideUp();
                }
            });

            $('#event_form').submit(function (event) {
                var is_valid = true;

                $('.category_repeater .question_textarea').each(function (index, element) {
                    if ($(this).val().trim() == '') {
                        is_valid = false;
                        $(this).parent().find('.error_question').html('Enter question.').parents('.form-group').addClass('has-error');
                    }
                });


                if ($('.category_repeater .question_textarea').length == 0) {
                    is_valid = false;

                    $('#error_category_repeater').html('Add at least one queston.');
                }

                console.log('is_valid = ' + is_valid);

                if (!is_valid) {
                    event.preventDefault();
                }
            });


             if ($('#hdnElectricity_CatID').val() != "0") {
                Bind_Electricity_Category();
            }

            function Bind_Electricity_Category() {
                debugger;
                //$(".dltSection").click();
                var ElectricityCategory = $('#hdnElectricityCategory').val();
                var arrElectricityCategory = ElectricityCategory.split("~");
                //alert(arrElectricityCategory);
                var IncludeInTotal;
                for (var i = 0; i < arrElectricityCategory.length; i++) {
                    if (i <= 1) {
                        $("#divAddNewCategory").click();
                    }
                    //alert(arrElectricityCategory[i]);

                    var arrIDTerm = arrElectricityCategory[i].split("||");
                    $("input[name~='Category[" + i + "][hdnElec_CategoryID]']").val(arrIDTerm[0]);
                    $("input[name~='Category[" + i + "][ctl00$ContentPlaceHolder1$txtCategory]']").val(arrIDTerm[1]);

                    IncludeInTotal = arrIDTerm[2];
                    if (IncludeInTotal == "True") {
                        $("input[name~='Category[" + i + "][ctl00$ContentPlaceHolder1$chkIncludeInTotal][]']").prop("checked", true);
                    }
                    else {
                        $("input[name~='Category[" + i + "][ctl00$ContentPlaceHolder1$chkIncludeInTotal][]']").prop("checked", false);
                    }
                    //$("input[name~='Category[" + i + "][ctl00$ContentPlaceHolder1$chkIncludeInTotal][]']").prop("checked",arrIDTerm[2]);
                    //alert($("input[name~='AnswerType[" + i + "][txtAnswer]']").val()); WorkPermitTermCondition[0][hdnRepeaterTermID]
                }
                 
            }



        });
    </script>


    <div class="m-grid__item m-grid__item--fluid m-wrapper">

        <div class="">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <div class="m-form m-form--label-align-left- m-form--state-" id="event_form">

                            <div class="m-portlet__head">
                                <div class="m-portlet__head-wrapper">
                                    <div class="m-portlet__head-caption">
                                        <div class="m-portlet__head-title">
                                            <h3 class="m-portlet__head-text">Electricity Categories
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
                                            <asp:Button ID="btnSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="Save" OnClick="btnSave_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="m-portlet__body">
                                <!--begin: Form Body -->
                                <div class="">
                                    <div class="row">

                                        <div class="col-xl-12">
                                             <asp:HiddenField ID="hdnElectricity_CatID" ClientIDMode="Static" Value="0" runat="server" />
                                            <asp:HiddenField ID="hdnElectricityCategory" ClientIDMode="Static" runat="server" />
                                            <div class="m-form__section">
                                                <%--<div class="form-group  m-form__group row">
                                                    <div class="col-md-9"></div>
                                                    <div class="col-md-2">
                                                        <span>Include In Total</span>
                                                    </div>
                                                </div>--%>
                                                <div class="category_repeater">
                                                    <div class="form-group  m-form__group row">
                                                        <div data-repeater-list="Category" class="col-lg-12" runat="server" id="Category1">
                                                            <div data-repeater-item="" class="form-group m-form__group row" runat="server" id="dvCategory" style="padding-bottom: 0px !important;">
                                                                <div class="col-md-8">
                                                                    <div class="m-form__group" style="padding-bottom: 0px !important;">
                                                                        <div class="m-form__control">
                                                                            <asp:TextBox ID="txtCategory" runat="server" ClientIDMode="Static" class="form-control m-input autosize_textarea question_textarea" placeholder="Enter Category" Rows="1"></asp:TextBox>
                                                                             <input type="hidden" name="hdnElec_CategoryID" id="hdnElec_CategoryID" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="d-md-none m--margin-bottom-10"></div>
                                                                </div>

                                                                <div class="col-md-1">
                                                                    <div data-repeater-delete="" class="dltSection btn btn-danger m-btn m-btn--icon m-btn--icon-only">
                                                                        <i class="la la-trash"></i>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <asp:CheckBox ID="chkIncludeInTotal" runat="server" ClientIDMode="Static" />
                                                                    <span>Include In Total</span>
                                                                </div>
                                                                <%--<div class="col-md-2">
                                                                    <span>Include In Total</span>
                                                                </div>--%>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="m-form__group form-group row">
                                                        <div class="col-lg-4">
                                                            <div data-repeater-create="" class="btn btn-accent m-btn m-btn--icon m-btn--pill m-btn--wide"  id="divAddNewCategory">
                                                                <span>
                                                                    <i class="la la-plus"></i>
                                                                    <span>Add more category</span>
                                                                </span>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-8">
                                                            <label id="lblCategoryCount" runat="server" class="col-xl-3 col-lg-3 col-form-label font-weight-bold question_count" data-count="1">1 Category(s)</label>
                                                        </div>
                                                        <span id="error_category_repeater" class="text-danger small"></span>
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
