<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Visit_Configuration.aspx.cs" Inherits="Upkeep_v3.VMS.Visit_Configuration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets/demo/custom/crud/metronic-datatable/base/html-table.js") %>" type="text/javascript"></script>

    <style type="text/css">
        .modalBackground {
            background-color: grey;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            /*background-color: #fff;
            border: 3px solid #ccc;*/
            padding: 10px;
            width: 300px;
        }

        /*.highlight {
            background-color: blanchedalmond;
        }*/
    </style>

    <script>
        function init_autosize() {
            var autosize_textarea = $('.autosize_textarea');
            autosize(autosize_textarea);
            autosize.update(autosize_textarea);
        }

        $(document).ready(function () {

            init_autosize();
            init_plugins();

            $('.VMSQuestion_repeater').repeater({
                initEmpty: false,
                show: function () {
                    $(this).slideDown();
                    var counter = $(this).parents('.VMSQuestion_repeater').find('.question_count');
                    var question_count = counter.data('count');
                    question_count++;
                    $('#txtQuestionCount').val(question_count);
                    counter.data('count', question_count).html(question_count + ' Question(s)');
                    $('#error_question_repeater').html('');

                    init_autosize();
                    init_plugins();
                },
                hide: function (deleteElement) {
                    $(this).slideUp(deleteElement);
                    var counter = $(this).parents('.VMSQuestion_repeater').find('.question_count');
                    var question_count = counter.data('count');
                    question_count--;
                    $('#txtQuestionCount').val(question_count);
                    counter.data('count', question_count).html(question_count + ' Question(s)');
                    if (question_count == 0) {
                        $('#error_question_repeater').html('Add at least one Question.');
                    }
                },
            });

            $('.VMSFeedback_repeater').repeater({
                initEmpty: false,
                show: function () {
                    $(this).slideDown();
                    var counter = $(this).parents('.VMSFeedback_repeater').find('.VMSFeedback_count');
                    var question_count = counter.data('count');
                    question_count++;
                    $('#txtFeedbackCount').val(question_count);
                    counter.data('count', question_count).html(question_count + ' VMS Feedback(s)');
                    $('#error_VMSFeedback').html('');

                    init_autosize();
                    init_plugins();
                },
                hide: function (deleteElement) {
                    $(this).slideUp(deleteElement);
                    var counter = $(this).parents('.VMSFeedback_repeater').find('.VMSFeedback_count');
                    var question_count = counter.data('count');
                    question_count--;
                    $('#txtFeedbackCount').val(question_count);
                    counter.data('count', question_count).html(question_count + ' VMS Feedback(s)');
                    if (question_count == 0) {
                        $('#error_VMSFeedback').html('Add at least one VMS Feedback.');
                    }
                },
            });


            $('.AnswerType_repeater').repeater({
                initEmpty: false,
                show: function () {
                    $(this).slideDown();
                    //var txtcounter = $(this).parents('.cntr').find('.txtquestion_count');
                    //var counter = $(this).parents('.AnswerType_repeater').find('.question_count');
                    //var question_count = counter.data('count');
                    //var txtquestion_count = txtcounter.data('count');
                    //question_count++;
                    //txtquestion_count++;
                    //alert(question_count);
                    //counter.data('count', question_count).html(question_count + ' Header(s)');
                    //txtcounter.data('count', txtquestion_count).val(txtquestion_count);
                    $('#error_question_repeater').html('');

                    init_autosize();
                    init_plugins();
                },
                hide: function (deleteElement) {
                    $(this).slideUp(deleteElement);
                    //var counter = $(this).parents('.AnswerType_repeater').find('.question_count');
                    //var txtcounter = $(this).parents('.cntr').find('.txtquestion_count');
                    //var question_count = counter.data('count');
                    //var txtquestion_count = txtcounter.data('count');
                    //question_count--;
                    //txtquestion_count--;
                    ////alert(question_count);
                    //counter.data('count', question_count).html(question_count + ' Header(s)');
                    //txtcounter.data('count', txtquestion_count).val(txtquestion_count);
                    //if (question_count == 0) {
                    //	$('#error_question_repeater').html('Add at least one Header.');
                    //}
                },
            });

            $('body').on('change', '.VMSQuestion_repeater .question_textarea', function () {
                var error_ele = $(this).parent().find('.error_question');
                error_ele.html('').parents('.form-group').removeClass('has-error');
                if ($(this).val().trim() == '') {
                    $(this).parent().find('.error_question').html('Enter question.').parents('.form-group').addClass('has-error');
                }
            });

            //$('body').on('change', '.question_repeater .type_select', function()
            //{
            //    var error_ele = $(this).parent().find('.error_type');
            //    error_ele.html('').parents('.form-group').removeClass('has-error');
            //    if($(this).val() == '')
            //    {
            //        $(this).parent().find('.error_type').html('Select answer type.').parents('.form-group').addClass('has-error');
            //    }
            //    if ($(this).val() == 'Options')
            //    {
            //        $(this).closest('.form-group').find('.options_group').slideDown();
            //    }
            //    else {
            //        $(this).closest('.form-group').find('.options_group').slideUp();
            //    }
            //});

            $('body').on('change', '.VMSFeedback_repeater .VMSFeedback_textarea', function () {
                var error_ele = $(this).parent().find('.error_VMSFeedback');
                error_ele.html('').parents('.form-group').removeClass('has-error');
                if ($(this).val().trim() == '') {
                    $(this).parent().find('.error_VMSFeedback').html('Enter VMS Feedback.').parents('.form-group').addClass('has-error');
                }
            });

            $('body').on('change', '.TermComdition_repeater .TermCondition_textarea', function () {
                var error_ele = $(this).parent().find('.error_TermCondition');
                error_ele.html('').parents('.form-group').removeClass('has-error');
                if ($(this).val().trim() == '') {
                    $(this).parent().find('.error_TermCondition').html('Enter Term & Comdition').parents('.form-group').addClass('has-error');
                }
            });

            $('#frmVMS').submit(function (event) {
                //alert('hiiiii');
                var is_valid = true;
                //debugger;
                if ($('#txtTitle').val() == "") {
                    is_valid = false;
                    $(this).parent().find('.error_title').html('Enter Title.').parents('.form-group').addClass('has-error');
                }
                else {
                    var error_ele = $(this).parent().find('.error_title');
                    error_ele.html('').parents('.form-group').removeClass('has-error');
                }

                if ($('#txtGPPrefix').val() == "") {
                    is_valid = false;
                    $(this).parent().find('.error_Prefix').html('Enter Prefix.').parents('.form-group').addClass('has-error');
                }
                else {
                    var error_ele = $(this).parent().find('.error_Prefix');
                    error_ele.html('').parents('.form-group').removeClass('has-error');
                }


                $('.VMSQuestion_repeater .question_textarea').each(function (index, element) {
                    if ($(this).val().trim() == '') {
                        is_valid = false;
                        $(this).parent().find('.error_question').html('Enter Question.').parents('.form-group').addClass('has-error');
                    }
                });

                $('.VMSFeedback_repeater .VMSFeedback_textarea').each(function (index, element) {
                    if ($(this).val().trim() == '') {
                        is_valid = false;
                        $(this).parent().find('.error_VMSFeedback').html('Enter Feedback.').parents('.form-group').addClass('has-error');
                    }
                });

                $('.TermComdition_repeater .TermCondition_textarea').each(function (index, element) {
                    if ($(this).val().trim() == '') {
                        is_valid = false;
                        $(this).parent().find('.error_TermCondition').html('Enter Terms and Condition.').parents('.form-group').addClass('has-error');
                    }
                });


                if ($('.VMSQuestion_repeater .question_textarea').length == 0) {
                    //alert('sdf');
                    is_valid = false;

                    $('#error_question_repeater').html('Add at least one Question.');
                }

                console.log('is_valid = ' + is_valid);

                // alert('sgdfgdfgfdfdfdfddf');

                if (!is_valid) {
                    //alert('sgdfgdfgdf');
                    event.preventDefault();
                }
            });

            var name = "";
            $(document).on('change', '.ddlAns', function () {
                var ddlansval = $(this).val();
                if (ddlansval === "")
                    return
                //alert(ddlansval+"===");
                if (ddlansval == '1' || ddlansval == '2') {
                    //document.getElementsByName($(this).attr("name").replace("ctl00$ContentPlaceHolder1$ddlAns", "hdnRepeaterAnswer"))[0].setAttribute('type', 'hidden');
                    $(this).parent().parent().find(".lblAnswerCnt").show();

                    $('.dltrptanswer').click();
                    //WorkPermitSection[0][WorkPermitHeader][0][ctl00$ContentPlaceHolder1$ddlAns]  btnModalAdd
                    name = $(this).siblings('.hdnRepeaterAnswer').attr("name");//.replace("ctl00$ContentPlaceHolder1$ddlAns", "hdnRepeaterAnswer");
                    //$("#hdnAns").val(name);
                    //ModalHTML = $(".divTxtAnswer").html();

                    $('#btnModal').click();
                    //alert($(this).val())
                    if ($(this).val() == "1")
                        $(".modal-title").text("Add Multi Select Answers");
                    else if ($(this).val() == "2")
                        $(".modal-title").text("Add Single Select Answers");

                }
                else {
                    //alert($(this).attr("name").replace("ctl00$ContentPlaceHolder1$ddlAns", "hdnRepeaterAnswer"));
                    //var ddlname = $(this).attr("name");
                    //var ansname = ddlname.replace("ctl00$ContentPlaceHolder1$ddlAns", "hdnRepeaterAnswer");
                    //alert("llll");
                    $(this).parent().parent().find(".hdnRepeaterAnswer").val("");
                    //document.getElementsByName(ansname)[0].value = "";
                    //document.getElementsByName(ansname)[0].setAttribute('type', 'text');
                    $(this).parent().parent().find(".lblAnswerCnt").hide();
                }

            });

            $(document).on('change', '.hdnRepeaterAnswer', function () {

                //alert("hdnRepeaterAnswer change");AnswerType[0][txtAnswer]
                //alert($(this).val().split(";").length);
                //alert($(this).val());
                if ($(this).val() === "")
                    $(this).next().next().text("0 Answer(s) added !");
                else
                    $(this).next().next().text($(this).val().split(";").length + " Answer(s) added !");

            });

            $(document).on('focusout', '.hdnRepeaterAnswer, .divTxtAnswer input[type="text"],.txtvalidate', function () {

                //Regex for Valid Characters i.e. Alphabets, Numbers and Space.
                //var regex = /^[A-Za-z0-9 ]+$/

                //Validate TextBox value against the Regex.
                //var isValid = regex.test($(this).val());
                if ($(this).val().includes("||") || $(this).val().includes(";") || $(this).val().includes("::")) {
                    alert("Contains Special Characters.");
                    $(this).val("");
                }


            });


            $('#AnsModal').on('hidden.bs.modal', function () {
                $('#btnModalAdd').click();
            })

            $(document).on('click', '.lblAnswerCnt', function () {

                $('.dltrptanswer').click();
                name = $(this).parent().find('.hdnRepeaterAnswer').attr("name");
                //alert(name);
                //alert($(this).parent().find('#ddlAns').val());
                if ($(this).parent().find('#ddlAns').val() == "1")
                    $(".modal-title").text("Change Multi Select Answers");
                else if ($(this).parent().find('#ddlAns').val() == "2")
                    $(".modal-title").text("Change Single Select Answers");

                //alert("lblAnswerCnt click");
                var answers = $(this).parent().find('.hdnRepeaterAnswer').val();
                if ($('#hdnVMSConfigID').val() != "0") {
                    answers = "ii:||;" + $(this).parent().find('.hdnRepeaterAnswer').val();
                }
                var arrAns = answers.split(";");

                for (var i = 0; i < arrAns.length; i++) {
                    //if (arrAns[i] != "ii:||") {
                    $("#divAnswerAdd").click();
                    //alert(arrAns[i]);
                    //alert(arrAns[i]); AnswerType[0][ctl00$ContentPlaceHolder1$hdnAnswerDataID]
                    var arrIDAns = arrAns[i].split(":");

                    $("input[name~='AnswerType[" + i + "][ctl00$ContentPlaceHolder1$hdnAnswerDataID]']").val(arrIDAns[0]);
                    $("input[name~='AnswerType[" + i + "][txtAnswer]']").val(arrIDAns[1]);
                    $("input[name~='AnswerType[" + i + "][ctl00$ContentPlaceHolder1$ChkAnsFlag][]']").val(arrIDAns[2]);
                    //alert(arrIDAns[1]);AnswerType[0][ctl00$ContentPlaceHolder1$ChkAnsDef][]
                    //alert("input[name~='AnswerType[" + i + "][txtAnswer]']");
                    //alert(arrIDAns[1]);
                    //alert($("input[name~='AnswerType[" + i + "][txtAnswer]']").val());
                    //$("#divAnswerAdd").click();
                    //}

                }

                $('.divTxtAnswer input[type="text"]').each(function () {
                    // Do your magic here 
                    //alert($(this).val());
                    if ($(this).val() === "||") {
                        //alert("jjjj");
                        //alert($(this).siblings('.dltrptanswer').html());
                        $(this).parent().siblings('.dltrptanswer').click();
                    }
                });
                $('#btnModal').click();
            });

            $(document).on('click', '#btnModalAdd', function () {
                //var answers = "";
                var answers = "";
                var cnt = 0;
                //alert(name);
                $('.divTxtAnswer input:text').each(function () {
                    // Do your magic here 
                    //alert($(this).val());
                    if ($(this).val() === "||") {
                        $(this).parent().siblings('.dltrptanswer').click();
                    }
                    if (answers == "") {
                        answers += $(this).siblings('#hdnAnswerDataID').val() + ":" + $(this).val() + ":" + $(this).parent().find('#ChkAnsFlag').val();
                    }
                    else {
                        answers += ";" + $(this).siblings('#hdnAnswerDataID').val() + ":" + $(this).val() + ":" + $(this).parent().find('#ChkAnsFlag').val();
                    }
                    cnt++;

                });
                //var name = $("#hdnAns").val();
                $("input[name~='" + name + "']").val(answers);
                $("input[name~='" + name + "']").change();
                //$(".divTxtAnswer").html(ModalHTML);
                $('.dltrptanswer').click();
                //alert(answers);
            });

        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <%--<form class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmVMS" method="post">--%>
                        <%--<cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>--%>

                        <div class="m-portlet__head">
                            <div class="m-portlet__head-progress">

                                <!-- here can place a progress bar-->
                            </div>
                            <div class="m-portlet__head-wrapper">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">VMS Configuration
                                        </h3>
                                    </div>
                                </div>

                                <div class="m-portlet__head-tools" style="width: 28%;">
                                    <%--<asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>--%>
                                    <a href="<%= Page.ResolveClientUrl("~/VMS/VMSConfig_Listing.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                        <span>
                                            <i class="la la-arrow-left"></i>
                                            <span>Back</span>
                                        </span>
                                    </a>
                                    <div class="btn-group">

                                        <asp:Button ID="btnSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" CausesValidation="true" ValidationGroup="validateVMS" OnClientClick="return FunSetXML();" OnClick="btnSave_Click" Text="Save" />

                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="m-portlet__body" style="padding: 0.4rem 2.2rem;">

                            <div class="m-portlet__body" style="padding: 0.3rem 2.2rem;">
                                <div class="form-group m-form__group row" style="padding-left: 1%;">
                                    <label class="col-md-3  col-form-label font-weight-bold"><span style="color: red;">*</span>Title :</label>
                                    <div class="col-xl-4 col-lg-4">
                                        <asp:HiddenField ID="hdnVMSConfigID" ClientIDMode="Static" Value="0" runat="server" />
                                        <asp:TextBox ID="txtTitle" runat="server" class="form-control" ClientIDMode="Static"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTitle" Visible="true" Display="Dynamic"
                                                ValidationGroup="validateVMS" ForeColor="Red" ErrorMessage="Please enter Title"></asp:RequiredFieldValidator>--%>
                                        <span class="error_title text-danger medium"></span>
                                    </div>

                                </div>
                                <div class="form-group m-form__group row" style="padding-left: 1%;">
                                    <label class="col-md-3 col-form-label font-weight-bold"><span style="color: red;">*</span>Description :</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtVMSDesc" TextMode="MultiLine" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTitle" Visible="true" Display="Dynamic"
                                            ValidationGroup="validateGatePass" ForeColor="Red" ErrorMessage="Please enter Title"></asp:RequiredFieldValidator>
                                    </div>

                                </div>
                                <div class="form-group m-form__group row" style="padding-left: 1%;">
                                    <label class="col-3  col-form-label font-weight-bold"><span style="color: red;">*</span> Form For:</label>
                                    <div class="col-3">
                                        <div class="m-radio-inline">
                                            <label class="m-radio" for="rdbCustomer">
                                                <asp:RadioButton ID="rdbCustomer" runat="server" ClientIDMode="Static" GroupName="Initiator" />
                                                Customer
													<span></span>
                                            </label>
                                            <label class="m-radio" for="rdbVisitor">
                                                <asp:RadioButton ID="rdbVisitor" runat="server" ClientIDMode="Static" GroupName="Initiator" Checked="true" />
                                                Visitor
													<span></span>
                                            </label>
                                        </div>
                                        <span id="error_question_for" class="text-danger small"></span>
                                    </div>

                                    <div class="col-md-3">
                                        <div class="btn-group btn-group-toggle" data-toggle="buttons">
                                            <label class="btn btn-light">
                                                <asp:CheckBox ID="ChkFeedback" autocomplete="off" runat="server" ClientIDMode="Static" /><i class="fa fa-check" aria-hidden="true"></i> Enable Feedback</label>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="btn-group btn-group-toggle" data-toggle="buttons">
                                            <label class="btn btn-light">
                                                <asp:CheckBox ID="ChkCovid" autocomplete="off" runat="server" ClientIDMode="Static" /><i class="fa fa-check" aria-hidden="true"></i> Enable Covid Test</label>
                                        </div>
                                    </div>
                                </div>
                                 <div class="form-group m-form__group row" style="padding-left: 1%;" id="divFeedback">
                                    <label class="col-3  col-form-label font-weight-bold"><span style="color: red;">*</span> Select Feedback Form:</label>
                                      <div class="col-md-4">
                                        <asp:DropDownList ID="ddFeedback" class="form-control m-input" runat="server" AutoPostBack="False"></asp:DropDownList>
                                    </div>
                                   
                                </div>

                                <br />

                                <div class="form-group row" style="background-color: #00c5dc;">
                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">VMS Questions</label>
                                </div>
                                <br />
                                <div class="col-xl-12">
                                    <div class="m-form__section">
                                        <div class="VMSQuestion_repeater">
                                            <div class="form-group  m-form__group row">

                                                <div data-repeater-list="VMSQuestion" class="col-lg-12" runat="server" id="VMSQuestion">

                                                    <div data-repeater-item="" class="form-group m-form__group row" runat="server" id="dvVMSQuestion">
                                                        <div class="col-md-5">
                                                            <div class="m-form__group">
                                                                <div class="m-form__control">
                                                                    <asp:TextBox ID="txtVMSQuestion" runat="server" class="form-control m-input autosize_textarea question_textarea" placeholder="Enter VMS Question" Rows="1"></asp:TextBox>
                                                                    <span class="error_question text-danger medium"></span>
                                                                </div>
                                                            </div>
                                                            <div class="d-md-none m--margin-bottom-10"></div>
                                                        </div>

                                                        <div class="col-md-3">
                                                            <div class="btn-group btn-group-toggle" data-toggle="buttons">
                                                                <label class="btn btn-light btn-sm">
                                                                    <asp:CheckBox ID="ChkVisible" autocomplete="off" runat="server" ClientIDMode="Static" /><i class="fa fa-check" aria-hidden="true"></i> Visible</label>
                                                            </div>
                                                            <div class="btn-group btn-group-toggle" data-toggle="buttons">
                                                                <label class="btn btn-light btn-sm">
                                                                    <asp:CheckBox ID="ChkMandatory" autocomplete="off" runat="server" ClientIDMode="Static" /><i class="fa fa-check" aria-hidden="true"></i> Mandatory</label>
                                                            </div>
                                                            <div class="d-md-none m--margin-bottom-10"></div>
                                                        </div>

                                                        <div class="col-md-3">
                                                            <div class="m-form__group">
                                                                <div class="m-form__control">
                                                                    <asp:DropDownList ID="ddlAns" data-show-content="true" data-show-icon="true" ClientIDMode="Static" class="form-control m-input type_select ddlAns" placeholder="select" runat="server"></asp:DropDownList>
                                                                    <input type="hidden" name="hdnRepeaterAnswer" placeholder="Enter Answer data" class="hdnRepeaterAnswer mt-3 form-control m-input autosize_textarea" id="hdnRepeaterAnswer" />
                                                                    <i class="fa fa-edit lblAnswerCnt"></i>
                                                                    <label id="lblAnswerCnt" runat="server" class="col-form-label font-weight-bold lblAnswerCnt mt-3">0 Answer(s) added !</label>

                                                                    <span class="error_type text-danger medium"></span>
                                                                </div>
                                                            </div>
                                                            <div class="d-md-none m--margin-bottom-10"></div>
                                                        </div>
                                                        <div class="col-md-1">
                                                            <div data-repeater-delete="" class="btn btn-danger m-btn m-btn--icon m-btn--icon-only">
                                                                <i class="la la-trash"></i>
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
                                                            <span>Add Question</span>
                                                        </span>
                                                    </div>
                                                </div>
                                                <div class="col-lg-8">

                                                    <input type="hidden" id="txtQuestionCount" clientidmode="Static" data-count="1" value="1" class="txtquestion_count" runat="server" />
                                                    <label id="lblQuestionCount" runat="server" class="col-xl-3 col-lg-3 col-form-label font-weight-bold question_count" data-count="1">1 Question(s)</label>
                                                </div>
                                                <span id="error_question_repeater" class="text-danger medium"></span>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <br />

                                <div class="form-group row" style="background-color: #00c5dc;">
                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">VMS Feedback</label>
                                </div>
                                <br />
                                <div class="col-xl-12">
                                    <div class="m-form__section">
                                        <div class="VMSFeedback_repeater">
                                            <div class="form-group  m-form__group row">

                                                <div data-repeater-list="VMSFeedback" class="col-lg-12" runat="server" id="VMSFeedback">

                                                    <div data-repeater-item="" class="form-group m-form__group row" runat="server" id="dvVMSFeedback">
                                                        <div class="col-md-5">
                                                            <div class="m-form__group">
                                                                <div class="m-form__control">
                                                                    <asp:TextBox ID="txtVMSFeedback" runat="server" class="form-control m-input autosize_textarea VMSFeedback_textarea" placeholder="Enter VMS Feedback" Rows="1"></asp:TextBox>
                                                                    <span class="error_VMSFeedback text-danger medium"></span>
                                                                </div>
                                                            </div>
                                                            <div class="d-md-none m--margin-bottom-10"></div>
                                                        </div>

                                                        <div class="col-md-3">
                                                            <div class="btn-group btn-group-toggle" data-toggle="buttons">
                                                                <label class="btn btn-light btn-sm">
                                                                    <asp:CheckBox ID="ChkFVisible" autocomplete="off" runat="server" ClientIDMode="Static" /><i class="fa fa-check" aria-hidden="true"></i> Visible</label>
                                                            </div>
                                                            <div class="btn-group btn-group-toggle" data-toggle="buttons">
                                                                <label class="btn btn-light btn-sm">
                                                                    <asp:CheckBox ID="ChkFMandatory" autocomplete="off" runat="server" ClientIDMode="Static" /><i class="fa fa-check" aria-hidden="true"></i> Mandatory</label>
                                                            </div>
                                                            <div class="d-md-none m--margin-bottom-10"></div>
                                                        </div>

                                                        <div class="col-md-3">
                                                            <div class="m-form__group">
                                                                <div class="m-form__control">
                                                                    <asp:DropDownList ID="ddlFAns" data-show-content="true" data-show-icon="true" ClientIDMode="Static" class="form-control m-input type_select ddlAns" placeholder="select" runat="server"></asp:DropDownList>
                                                                    <input type="hidden" name="hdnFRepeaterAnswer" placeholder="Enter Answer data" class="hdnRepeaterAnswer mt-3 form-control m-input autosize_textarea" id="hdnFRepeaterAnswer" />
                                                                    <i class="fa fa-edit lblAnswerCnt"></i>
                                                                    <label id="lblFAnswerCnt" runat="server" class="col-form-label font-weight-bold lblAnswerCnt mt-3">0 Answer(s) added !</label>

                                                                    <span class="error_type text-danger medium"></span>
                                                                </div>
                                                            </div>
                                                            <div class="d-md-none m--margin-bottom-10"></div>
                                                        </div>

                                                        <div class="col-md-1">
                                                            <div data-repeater-delete="" class="btn btn-danger m-btn m-btn--icon m-btn--icon-only">
                                                                <i class="la la-trash"></i>
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
                                                            <span>Add VMS Feedback</span>
                                                        </span>
                                                    </div>
                                                </div>
                                                <div class="col-lg-8">

                                                    <input type="hidden" clientidmode="Static" id="txtFeedbackCount" data-count="1" value="1" class="txtVMSFeedback_count" runat="server" />
                                                    <label id="Label1" runat="server" class="col-xl-6 col-lg-3 col-form-label font-weight-bold VMSFeedback_count" data-count="1">1 VMS Feedback(s)</label>
                                                </div>
                                                <span id="error_VMSFeedback" class="text-danger medium"></span>
                                            </div>

                                        </div>
                                    </div>
                                </div>

                                <br />

                                <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>

                            </div>
                        </div>


                        <button type="button" style="display: none" id="btnModal" class="btn btn-info btn-lg" data-toggle="modal" data-target="#AnsModal">Open Modal</button>

                        <div class="modal fade" id="AnsModal" role="dialog">
                            <div class="modal-dialog">

                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h4 class="modal-title">Add Answer Data</h4>
                                        <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                                    </div>
                                    <div class="modal-body">
                                        <%--<input type="text" id="hdnAns" />--%>
                                        <div class="AnswerType_repeater answer divTxtAnswer">
                                            <div data-repeater-list="AnswerType">
                                                <div data-repeater-item="">
                                                    <asp:HiddenField ID="hdnAnswerDataID" ClientIDMode="Static" Value="0" runat="server" />
                                                    <input type="text" class="txtAnswer txtvalidate" name="txtAnswer" placeholder="Enter Value" id="txtAnswer" />

                                                    <div class="btn-group btn-group-toggle" data-toggle="buttons">
                                                        <label class="btn btn-light">
                                                            <%--<input id="ChkAnsFlag" type="checkbox" />--%>
                                                            <asp:CheckBox ID="ChkAnsFlag" autocomplete="off" runat="server" ClientIDMode="Static" />Flag</label>
                                                    </div>
                                                    <%--<div class="btn-group btn-group-toggle" data-toggle="buttons">
                                                        <label class="btn btn-light">
                                                            <asp:CheckBox ID="ChkAnsDef" autocomplete="off" runat="server" ClientIDMode="Static" />Default</label>
                                                    </div>--%>
                                                    <div data-repeater-delete="" class="dltrptanswer answer btn">
                                                        <i class="la la-remove"></i>
                                                    </div>
                                                </div>
                                            </div>

                                            <div data-repeater-create="AnswerType_repeater" class="btn" id="divAnswerAdd">
                                                <span>
                                                    <i class="la la-plus"></i>
                                                    <span>Add Answer</span>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal-footer" style="display: none;">
                                        <button type="button" id="btnModalAdd" data-dismiss="modal" class="btn btn-info">Add</button>
                                    </div>
                                </div>

                            </div>
                        </div>


                        <asp:Button Text="text" Style="display: none;" ID="pop2" runat="server" />

                        <input type="hidden" id="HdnID" runat="server" />
                        <asp:TextBox ID="txtHdn" runat="server" ClientIDMode="Static" Width="100%" Style="display: none"></asp:TextBox>

                        <%--</form>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
