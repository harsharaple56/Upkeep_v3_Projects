<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Visit_Configuration.aspx.cs" Inherits="Upkeep_v3.VMS.Visit_Configuration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets/demo/custom/crud/metronic-datatable/base/html-table.js") %>" type="text/javascript"></script>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>

    <script src="<%= Page.ResolveClientUrl("~/assets/demo/default/custom/crud/forms/widgets/bootstrap-timepicker.js") %>" type="text/javascript"></script>

    <script type="text/javascript">
        // This jQuery code makes all check boxes read-only
        $('#ChkNameComp').click(function () {
            return false;
        });
    </script>

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

            $("#divFeedback").hide();
            $("#divChkFeedback").click(function () {
                //alert("hii");
                if ($("#ChkFeedback").is(":checked")) {
                    $("#divFeedback").hide(300);
                } else {
                    $("#divFeedback").show(200);
                }
            });

            $("#divCount").hide();
            $("#divChkCovid").click(function () {
                //alert("hii");
                if ($("#ChkCovid").is(":checked")) {
                    $("#divCount").hide(300);
                } else {
                    $("#divCount").show(200);
                }
            });

            $("#divTimeLimit").hide();
            $("#divChkTimeLimit").click(function () {
                //alert("hii");
                if ($("#ChkTimeLimit").is(":checked")) {
                    $("#divTimeLimit").hide(300);
                } else {
                    $("#divTimeLimit").show(200);
                }
            });


            $('.timepicker').timepicker();




            $('.VMSQuestion_repeater').repeater({
                initEmpty: false,
                show: function () {
                    $(this).slideDown();
                    var counter = $(this).parents('.VMSQuestion_repeater').find('.question_count');
                    var question_count = counter.data('count');
                    question_count++;
                    $('#txtQuestionCount').val(question_count);
                    $(this).find("#ddlAns").val(1);
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

            $('.TermComdition_repeater').repeater({
                initEmpty: false,
                show: function () {
                    $(this).slideDown();
                    var counter = $(this).parents('.TermComdition_repeater').find('.TermCondition_count');
                    var question_count = counter.data('count');
                    question_count++;
                    counter.data('count', question_count).html(question_count + ' Term & Condition(s)');
                    $('#error_TermCondition').html('');

                    init_autosize();
                    init_plugins();
                },
                hide: function (deleteElement) {
                    $(this).slideUp(deleteElement);
                    var counter = $(this).parents('.TermComdition_repeater').find('.TermCondition_count');
                    var question_count = counter.data('count');
                    question_count--;
                    counter.data('count', question_count).html(question_count + ' Term & Condition(s)');
                    if (question_count == 0) {
                        $('#error_TermCondition').html('Add at least one Term & Condition.');
                    }
                },
            });

            $('.SMSTemplate_repeater').repeater({
                initEmpty: false,
                show: function () {
                    $(this).slideDown();
                    $(this).find("#ddlSMS").val(0);
                    var counter = $(this).parents('.SMSTemplate_repeater').find('.SMSTemplate_count');
                    var question_count = counter.data('count');
                    question_count++;
                    counter.data('count', question_count).html(question_count + ' SMS Template(s)');
                    $('#error_SMSTemplate').html('');
                    init_autosize();
                    init_plugins();
                },
                hide: function (deleteElement) {
                    $(this).slideUp(deleteElement);
                    var counter = $(this).parents('.SMSTemplate_repeater').find('.SMSTemplate_count');
                    var question_count = counter.data('count');
                    question_count--;
                    counter.data('count', question_count).html(question_count + ' SMS Template(s)');
                    //alert(question_count);
                    if (question_count == 0) {
                        $('#error_SMSTemplate').html('Add at least one SMS Template.');
                    }
                },
            });

            

            $('.AnswerType_repeater').repeater({
                initEmpty: false,
                show: function () {
                    $(this).slideDown();
                    $('#error_question_repeater').html('');

                    init_autosize();
                    init_plugins();
                },
                hide: function (deleteElement) {
                    $(this).slideUp(deleteElement);
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
                var isMulti = $(this).find(':selected').attr("data-ismulti");
                if (isMulti === "")
                    return
                //alert(isMulti+"===");
                if (isMulti === 'True') {
                    $(this).parent().parent().find(".lblAnswerCnt").show();

                    $('.dltrptanswer').click();
                    name = $(this).siblings('.hdnRepeaterAnswer').attr("name");
                    $('#btnModal').click();

                    //Commented by RC
                    //if ($(this).val() == "1")
                    //    $(".modal-title").text("Add Multi Select Answers");
                    //else if ($(this).val() == "2")
                    //    $(".modal-title").text("Add Single Select Answers");
                    //Commented by RC END
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
                if ($(this).val().includes("||") || $(this).val().includes(";") || $(this).val().includes(":")) {
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
                    answers = "ii:||:on;" + $(this).parent().find('.hdnRepeaterAnswer').val();
                }
                //alert(answers);
                var arrAns = answers.split(";");

                for (var i = 0; i < arrAns.length; i++) {
                    //if (arrAns[i] != "ii:||") {
                    $("#divAnswerAdd").click();
                    //alert(arrAns[i]);
                    //alert(arrAns[i]); AnswerType[0][ctl00$ContentPlaceHolder1$hdnAnswerDataID]
                    var arrIDAns = arrAns[i].split(":");

                    $("input[name~='AnswerType[" + i + "][ctl00$ContentPlaceHolder1$hdnAnswerDataID]']").val(arrIDAns[0]);
                    $("input[name~='AnswerType[" + i + "][txtAnswer]']").val(arrIDAns[1]);
                    if (arrIDAns[2].toLowerCase() == "true") {
                        $("input[name~='AnswerType[" + i + "][ctl00$ContentPlaceHolder1$ChkAnsFlag][]']").prop("checked", true)
                        $("input[name~='AnswerType[" + i + "][ctl00$ContentPlaceHolder1$ChkAnsFlag][]']").parent().parent().addClass("active");
                    }
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
                    if ($(this).val() === "||" || $(this).val() === "") {
                        //alert("jjjj");
                        //alert($(this).siblings('.dltrptanswer').html());
                        $(this).siblings('.dltrptanswer').click();
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
                        answers += $(this).siblings('#hdnAnswerDataID').val() + ":" + $(this).val() + ":" + $(this).parent().find('#ChkAnsFlag').is(":checked");
                    }
                    else {
                        answers += ";" + $(this).siblings('#hdnAnswerDataID').val() + ":" + $(this).val() + ":" + $(this).parent().find('#ChkAnsFlag').is(":checked");
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


            if ($('#hdnVMSConfigID').val() != "0") {


                //$('#AnsModal').modal('show');
                //$('#AnsModal').modal('toggle');
                //$(".divQnDel").click();
                Bind_VMSConfiguration($('#hdnVMSConfigID').val());
            }

            function Bind_VMSConfiguration(VMSConfigID) {
                //alert(WPConfigID);
                //Bind VMS Questions
                if ($("#ChkFeedback").is(":checked")) {
                    $("#divFeedback").show(300);
                    $("#ChkFeedback").parent().parent().addClass("active");
                }
                if ($("#ChkCovid").is(":checked")) {
                    $("#divCount").show(300);
                    $("#ChkCovid").parent().parent().addClass("active");
                }

                if ($("#ChkVaccinated").is(":checked")) {
                    $("#divChkCovid").show(300);
                    $("#ChkVaccinated").parent().parent().addClass("active");
                }

                if ($("#ChkTimeLimit").is(":checked")) {
                    $("#divTimeLimit").show(300);
                    $("#ChkTimeLimit").parent().parent().addClass("active");
                }


                var qns = $('#hdnVMSQns').val();
                var arrQns = qns.split("~");
                //alert(qns);
                for (var i = 0; i < arrQns.length; i++) {
                    if (i !== 0)
                        $("#divQnAdd").click();
                    //alert(arrTerms[i]);VMSQuestion[0][hdnRepeaterAnswer]

                    var QuestionID = $("input[name~='VMSQuestion[" + i + "][ctl00$ContentPlaceHolder1$hdnQnID]']");
                    var Question = $("input[name~='VMSQuestion[" + i + "][ctl00$ContentPlaceHolder1$txtVMSQuestion]']");
                    var isMandatory = $("input[name~='VMSQuestion[" + i + "][ctl00$ContentPlaceHolder1$ChkMandatory][]']");
                    var isVisible = $("input[name~='VMSQuestion[" + i + "][ctl00$ContentPlaceHolder1$ChkVisible][]']");
                    var Answer = $("select[name~='VMSQuestion[" + i + "][ctl00$ContentPlaceHolder1$ddlAns]']");
                    var hdnAnswer = $("input[name~='VMSQuestion[" + i + "][hdnRepeaterAnswer]']");

                    var arrQnData = arrQns[i].split("||");
                    QuestionID.val(arrQnData[0]);
                    Question.val(arrQnData[1]);
                    if (arrQnData[2] == "True") {
                        isMandatory.prop("checked", true)
                        isMandatory.parent().parent().addClass("active");
                    }
                    if (arrQnData[3] == "True") {
                        isVisible.prop("checked", true)
                        isVisible.parent().parent().addClass("active");
                    }
                    Answer.val(arrQnData[4]);
                    hdnAnswer.val(arrQnData[5]);
                    hdnAnswer.change();
                    //alert($("select[name~='VMSQuestion[" + i + "][ctl00$ContentPlaceHolder1$ddlAns]']").find(':selected'));
                    var isMulti = $("select[name~='VMSQuestion[" + i + "][ctl00$ContentPlaceHolder1$ddlAns]'] option[value='" + arrQnData[4] + "']").attr("data-ismulti");
                    if (isMulti === 'True') {

                        //document.getElementsByName($(this).attr("name").replace("ctl00$ContentPlaceHolder1$ddlAns", "hdnRepeaterAnswer"))[0].setAttribute('type', 'hidden');
                        hdnAnswer.parent().parent().find(".lblAnswerCnt").show();
                    }
                    else {
                        hdnAnswer.parent().parent().find(".lblAnswerCnt").hide();
                    }
                    //alert($("input[name~='AnswerType[" + i + "][txtAnswer]']").val()); WorkPermitTermCondition[0][hdnRepeaterTermID]
                }
                //$(".dltSection").click();
                //debugger;
                var terms = $('#hdnVMSTerms').val();
                //alert(terms);
                var arrTerms = terms.split("~");
                for (var i = 0; i < arrTerms.length; i++) {
                    if (i !== 0)
                        $("#divTermAdd").click();
                    //alert(arrTerms[i]);

                    var arrIDTerm = arrTerms[i].split("||");
                    $("input[name~='VMSTermCondition[" + i + "][hdnRepeaterTermID]']").val(arrIDTerm[0]);
                    $("textarea[name~='VMSTermCondition[" + i + "][ctl00$ContentPlaceHolder1$txtTermCondition]']").val(arrIDTerm[1]);

                    //alert($("input[name~='AnswerType[" + i + "][txtAnswer]']").val()); WorkPermitTermCondition[0][hdnRepeaterTermID]
                }

                //custom SMS
                var sms = $('#hdnSMSTemplate').val();
                //alert(terms);
                var arrSMS = sms.split("~");
                for (var i = 0; i < arrSMS.length; i++) {
                    if (i !== 0)
                        $("#divSMSAdd").click();
                    //alert(arrTerms[i]);

                    var arrIDSMS = arrSMS[i].split("||");
                    $("input[name~='VMS_SMSTemplate[" + i + "][hdnRepeaterSMSID]']").val(arrIDSMS[0]);
                    $("textarea[name~='VMS_SMSTemplate[" + i + "][ctl00$ContentPlaceHolder1$txtSMSTemplate]']").val(arrIDSMS[1]);

                    var SMS_Type = $("select[name~='VMS_SMSTemplate[" + i + "][ctl00$ContentPlaceHolder1$ddlSMS]']");
                    SMS_Type.val(arrIDSMS[2]);

                    //ddlSMS
                    //alert($("input[name~='AnswerType[" + i + "][txtAnswer]']").val()); WorkPermitTermCondition[0][hdnRepeaterTermID]
                }




                return;
                //Bind WP Headers with answesrs
                //var headers = $('#hdnWPHeaders').val();
                //var arrHeaders = headers.split("~");
                //alert(headers);
                //for (var i = 0; i < arrHeaders.length; i++) {
                //    //$("#divSectionAdd").click();
                //    //alert(arrTerms[i]);   
                //    var arrHeaderData = arrHeaders[i].split("||");
                //    var section = $("div[data-SectionID~='" + arrHeaderData[0] + "']");
                //    section.children().find(".divHeaderAdd").click();
                //    section.children().find(".dvWorkPermitHeader").not(".updated").attr("data-HeaderID", arrHeaderData[1]);
                //    section.children().find(".dvWorkPermitHeader").addClass("updated");
                //    var header = section.find("div[data-HeaderID~='" + arrHeaderData[1] + "']");
                //    header.children().find("#hdnWorkPermitHeader").val(arrHeaderData[1]);
                //    header.children().find(".question_textarea").val(arrHeaderData[2]);
                //    //section.children().find(".question_textarea").val(arrHeaderData[2]);
                //    //alert(arrHeaderData[4]);
                //    //alert(section.children().find("#ddlAns").val());  $('.lblAnswerCnt').hide();
                //    //alert(header.children().find("select").val());
                //    header.children().find("select").val(arrHeaderData[4]);
                //    header.children().find("select").selectpicker('refresh');
                //    header.children().find(".hdnRepeaterAnswer").val(arrHeaderData[5]);
                //    header.children().find(".hdnRepeaterAnswer").change();
                //    if (arrHeaderData[4] == "1" || arrHeaderData[4] == "2") {
                //        header.children().find(".lblAnswerCnt").show();
                //    }
                //    //$("input[name~='WorkPermitSection[" + i + "][ctl00$ContentPlaceHolder1$hdnWPSectionID]']").parents('.dvWorkPermitSection').attr("data-SectionID",arrIDSection[0]);
                //    //$("input[name~='WorkPermitSection[" + i + "][ctl00$ContentPlaceHolder1$hdnWPSectionID]']").val(arrIDSection[0]);
                //    //$("input[name~='WorkPermitSection[" + i + "][ctl00$ContentPlaceHolder1$txtWorkPermitSection]']").val(arrIDSection[1]);

                //    //alert($("input[name~='AnswerType[" + i + "][txtAnswer]']").val()); WorkPermitSection[0][ctl00$ContentPlaceHolder1$txtWorkPermitSection]
                //}

            }
        });
    </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <%--<form class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmVMS" method="post">--%>
                        <%--<cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>--%>

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
                                        <h3 class="m-portlet__head-text">Configure Visitor Form
                                        </h3>
                                    </div>
                                </div>

                                <div class="m-portlet__head-tools">
                                    <%--<asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>--%>
                                    <a href="<%= Page.ResolveClientUrl("~/VMS/VMSConfig_Listing.aspx") %>" class="btn btn-metal m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m--margin-right-10">
                                        <span>
                                            <i class="la la-arrow-left"></i>
                                            <span>Back</span>
                                        </span>
                                    </a>
                                    <div class="btn-group">

                                        <asp:Button ID="btnSave" runat="server" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air" CausesValidation="true" ValidationGroup="validateVMS" OnClientClick="if(this.value === 'Saving...') { return false; } else { this.value = 'Saving...'; }return FunSetXML();" OnClick="btnSave_Click" Text="Save" />


                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="m-portlet__body">
                            <div class="form-group m-form__group row">
                                <label class="col-md-1  col-form-label font-weight-bold">Title</label>
                                <div class="col-xl-11 col-lg-4">
                                    <asp:HiddenField ID="hdnVMSConfigID" ClientIDMode="Static" Value="0" runat="server" />
                                    <asp:TextBox ID="txtTitle" runat="server" class="form-control" ClientIDMode="Static" placeholder="Enter Title of your Visior Form"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTitle" Visible="true" Display="Dynamic"
                                        ValidationGroup="validateVMS" ForeColor="Red" ErrorMessage="Please enter Title"></asp:RequiredFieldValidator>
                                    <span class="error_title text-danger medium"></span>
                                </div>

                            </div>
                            <div class="form-group m-form__group row">
                                <label class="col-md-1 col-form-label font-weight-bold">
                                    Description</label>
                                <div class="col-md-11">
                                    <asp:TextBox ID="txtVMSDesc" TextMode="MultiLine" runat="server" class="form-control" placeholder="Enter Description about how this Visitor Form will be used OR define its purpose"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTitle" Visible="true" Display="Dynamic"
                                        ValidationGroup="validateGatePass" ForeColor="Red" ErrorMessage="Please enter Title"></asp:RequiredFieldValidator>
                                </div>

                            </div>
                            <div class="form-group m-form__group row">
                                <label class="col-2  col-form-label font-weight-bold">
                                    <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="Relevant Feedback Forms will be displayed in dropdown, as created for Visitors / Customer">
                                        <i class="fa fa-info-circle"></i>
                                    </a>
                                    Form For

                                </label>
                                <div class="col-4">
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

                            </div>
                            <div class="form-group m-form__group row">

                                <div class="col-md-3">
                                    <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="If enabled you can select a Feedback Form which will be sent to Visitors once they are Marked Out">
                                        <i class="fa fa-info-circle"></i>
                                    </a>
                                    <div class="btn-group btn-group-toggle" id="divChkFeedback" data-toggle="buttons">

                                        <label class="btn btn-light" id="lblChkFeedback">
                                            <asp:CheckBox ID="ChkFeedback" autocomplete="off" runat="server" ClientIDMode="Static" /><i class="fa fa-check" aria-hidden="true"></i> Enable Feedback</label>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="If enabled the visitors need to go through Covid Assesment Test as per Govt. of India issued AROGYA SETU App, before their visit request is registered">
                                        <i class="fa fa-info-circle"></i>
                                    </a>
                                    <div class="btn-group btn-group-toggle" id="divChkCovid" data-toggle="buttons">
                                        <label class="btn btn-light" id="lblChkCovid">
                                            <asp:CheckBox ID="ChkCovid" autocomplete="off" runat="server" ClientIDMode="Static" /><i class="fa fa-check" aria-hidden="true"></i> Enable Covid Test</label>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="If enabled the visitors Photo needs to be uploaded, 2nd Dose Vaccine Date needs to be entered and 2nd Dose Vaccination Cerificate by CoWIN needs to be uploaded to raise a Visit Request">
                                        <i class="fa fa-info-circle"></i>
                                    </a>
                                    <div class="btn-group btn-group-toggle" id="divChkVaccinated" data-toggle="buttons">
                                        <label class="btn btn-light" id="lblChkVaccinated">
                                            <asp:CheckBox ID="ChkVaccinated" autocomplete="off" runat="server" ClientIDMode="Static" /><i class="fa fa-check" aria-hidden="true"></i> Check for Vaccination</label>
                                    </div>
                                </div>
                                <div class="col-md-3">

                                    <asp:TextBox ID="txt_Emails" runat="server" class="form-control" data-container="body" data-toggle="m-tooltip" data-placement="top" title="" data-original-title="Email ID's Entered here will be notified whenever a Visit requests is registered for this Configuration. Enter Multiple Email ID's in comma seperated " ClientIDMode="Static" placeholder="Enter Email ID's to Notify"></asp:TextBox>


                                </div>
                            </div>
                            <div class="form-group m-form__group row">
                                <div class="col-md-6" id="divFeedback">
                                    <div class="row">
                                        <label class="col-5  col-form-label font-weight-bold">
                                            <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="Select a Feedback form to be sent to Visitor post completion of their Visit">
                                                <i class="fa fa-info-circle"></i>
                                            </a>
                                            Select Feedback Form
                                        </label>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="ddlFeedbackTitle" class="form-control m-input" runat="server" AutoPostBack="False"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6" id="divCount">
                                    <div class="row">
                                        <label class="col-4 col-form-label font-weight-bold">
                                            <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="Enter the limit No. of People to be allowed as Marked IN , depending on total Number of ACTIVE occupancy you need in your premises. Post this Count , visit requests will be blocked until someone is marked out">
                                                <i class="fa fa-info-circle"></i>
                                            </a>
                                            Entry Count

                                        </label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtCount" TextMode="Number" Text="0" runat="server" class="form-control" AutoPostBack="False"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group m-form__group row">
                                <div class="col-xl-6">
                                    <label class="col-form-label font-weight-bold">
                                        <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="Select Which Visitor Information Fields are mandatory for raising a Visit Request">
                                            <i class="fa fa-info-circle"></i>
                                        </a>
                                        Select Mandatory Fields</label>
                                    <div class="m-checkbox-inline">
                                        <%--<label class="m-checkbox">--%>
                                        <asp:CheckBox ID="ChkNameComp" autocomplete="off" runat="server" Checked="true" ClientIDMode="Static" />
                                        <i class="fa fa-check" aria-hidden="true"></i>Name
                                        
                                        <%--</label>--%>

                                        <%--<input type="checkbox" checked="true">
                                            Name
									    <span></span>
                                        </label>--%>
                                        <%--    <label class="m-checkbox">
                                            <input type="checkbox">
                                            Email
										<span></span>
                                        </label>--%>
                                        <label class="">
                                            <asp:CheckBox ID="ChkEmailComp" autocomplete="off" runat="server" ClientIDMode="Static" />
                                            <i class="fa fa-check" aria-hidden="true"></i>Email</label>



                                        <%--  <label class="m-checkbox">
                                            <input type="checkbox">
                                            Contact
										<span></span>
                                        </label>--%>

                                        <label class="">
                                            <asp:CheckBox ID="ChkContactComp" autocomplete="off" runat="server" ClientIDMode="Static" />
                                            <i class="fa fa-check" aria-hidden="true"></i>Contact</label>



                                        <%-- <label class="m-checkbox">
                                            <input type="checkbox">
                                            Meeting With
										<span></span>
                                        </label>--%>

                                        <label class="">
                                            <asp:CheckBox ID="ChkMeetingComp" autocomplete="off" runat="server" ClientIDMode="Static" />
                                            <i class="fa fa-check" aria-hidden="true"></i>Meeting With</label>


                                    </div>
                                </div>

                                <div class="col-xl-6">
                                    <label class="col-form-label font-weight-bold">
                                        <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="Make OTP Verification for Email / Contact Number Compulsory for raising Visit Request">
                                            <i class="fa fa-info-circle"></i>
                                        </a>
                                        Visitor Email and Contact Verification</label>
                                    <div class="m-checkbox-inline">

                                        <label class="">
                                            <asp:CheckBox ID="ChkContactOTPComp" autocomplete="off" runat="server" ClientIDMode="Static" />
                                            <i class="fa fa-check" aria-hidden="true"></i>Contact OTP Compulsory</label>

                                        <%--  <label class="m-checkbox">
                                            <input type="checkbox" checked="true">
                                           
									    <span></span>
                                        </label>--%>
                                        <%--  <label class="m-checkbox">
                                            <input type="checkbox">
                                            Email OTP Compulsory 
										<span></span>
                                        </label>--%>


                                        <label class="">
                                            <asp:CheckBox ID="ChkEmailOtpCom" autocomplete="off" runat="server" ClientIDMode="Static" />
                                            <i class="fa fa-check" aria-hidden="true"></i>Email OTP Compulsory
                                        </label>
                                    </div>
                                </div>

                            </div>


                            <div class="form-group m-form__group row">

                                <div class="col-md-3">
                                    <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="If enabled you can select a Feedback Form which will be sent to Visitors once they are Marked Out">
                                        <i class="fa fa-info-circle"></i>
                                    </a>
                                    <div class="btn-group btn-group-toggle" id="divChkTimeLimit" data-toggle="buttons">

                                        <label class="btn btn-light" id="lblChkTimeLimit">
                                            <asp:CheckBox ID="ChkTimeLimit" autocomplete="off" runat="server" ClientIDMode="Static" /><i class="fa fa-check" aria-hidden="true"></i> Enable Time Limit</label>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group m-form__group row" id="divTimeLimit">
                                <div class="col-md-6">
                                    <div class="row">
                                        <label class="col-4  col-form-label font-weight-bold">
                                            <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="Select a Feedback form to be sent to Visitor post completion of their Visit">
                                                <i class="fa fa-info-circle"></i>
                                            </a>
                                            From Time
                                        </label>
                                        <div class="col-lg-5 col-md-5 col-sm-12">
                                            <div class="input-group ">
                                                <asp:TextBox ID="txtFromTime" runat="server" autocomplete="off" class="form-control m-input timepicker" placeholder="Select From Time"></asp:TextBox>
                                                <div class="input-group-append">
                                                    <span class="input-group-text">
                                                        <i class="la la-clock-o"></i>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-12"></div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="row">
                                        <label class="col-4 col-form-label font-weight-bold">
                                            <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="Enter the limit No. of People to be allowed as Marked IN , depending on total Number of ACTIVE occupancy you need in your premises. Post this Count , visit requests will be blocked until someone is marked out">
                                                <i class="fa fa-info-circle"></i>
                                            </a>
                                            To Time

                                        </label>
                                        <div class="col-lg-5 col-md-5 col-sm-12">
                                            <div class="input-group">
                                                <asp:TextBox ID="txtToTime" runat="server" autocomplete="off" class="form-control m-input timepicker" placeholder="Select To Time"></asp:TextBox>
                                                <div class="input-group-append">
                                                    <span class="input-group-text">
                                                        <i class="la la-clock-o"></i>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>




                            <div class="m-form__heading" style="text-align: center; padding-top: 10px;">
                                <h3 class="m-form__heading-title" style="line-height: 2.0; background: #ffaeae; font-size: 1.2rem;">Configure Additional Fields For your Visitor Form</h3>
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
                                                                <asp:HiddenField ID="hdnQnID" ClientIDMode="Static" Value="0" runat="server" />
                                                                <asp:TextBox ID="txtVMSQuestion" runat="server" class="form-control m-input autosize_textarea question_textarea" placeholder="Enter Question" Rows="1"></asp:TextBox>
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

                                                        <div class="m-form__group row">
                                                            <div class="col-md-2">
                                                                <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="Select the Answer Type , depending upon the type of responses you require from the Visitor against the questions\">
                                                                    <i class="fa fa-info-circle"></i>
                                                                </a>
                                                            </div>
                                                            <div class="col-md-10">

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
                                                        <div data-repeater-delete="" class="btn btn-danger m-btn m-btn--icon m-btn--icon-only divQnDel" id="divQnDel">
                                                            <i class="la la-trash"></i>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="m-form__group form-group row">
                                            <div class="col-lg-4">
                                                <div data-repeater-create="" class="btn btn-accent m-btn m-btn--icon m-btn--pill m-btn--wide" id="divQnAdd">
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


                            <div class="m-form__heading" style="text-align: center; padding-top: 10px;">
                                <h3 class="m-form__heading-title" style="line-height: 2.0; background: #ffaeae; font-size: 1.2rem;">Terms and Conditions</h3>
                            </div>
                            <br />
                            <div class="col-xl-12">
                                <div class="m-form__section">
                                    <div class="TermComdition_repeater">
                                        <div class="form-group  m-form__group row">

                                            <div data-repeater-list="VMSTermCondition" class="col-lg-12" runat="server" id="VMSTermCondition">

                                                <div data-repeater-item="" class="form-group m-form__group row" runat="server" id="Div2">
                                                    <div class="col-md-9">
                                                        <div class="m-form__group">
                                                            <div class="m-form__control">
                                                                <asp:TextBox ID="txtTermCondition" runat="server" TextMode="MultiLine" class="form-control m-input autosize_textarea TermCondition_textarea" placeholder="Enter Term & Condition" Rows="1"></asp:TextBox>
                                                                <span class="error_TermCondition text-danger medium"></span>
                                                                <input type="hidden" name="hdnRepeaterTermID" id="hdnRepeaterTermID" />
                                                            </div>
                                                        </div>
                                                        <div class="d-md-none m--margin-bottom-10"></div>
                                                    </div>

                                                    <div class="col-md-1">
                                                        <div data-repeater-delete="" class="btn btn-danger m-btn m-btn--icon m-btn--icon-only dltSection" id="dltSection">
                                                            <i class="la la-trash"></i>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="m-form__group form-group row">
                                            <div class="col-lg-4">
                                                <div data-repeater-create="" class="btn btn-accent m-btn m-btn--icon m-btn--pill m-btn--wide" id="divTermAdd">
                                                    <span>
                                                        <i class="la la-plus"></i>
                                                        <span>Add Term & Condition</span>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <label id="Label2" runat="server" class="col-xl-6 col-lg-3 col-form-label font-weight-bold TermCondition_count" data-count="1">1 Term & Condition(s)</label>
                                            </div>
                                            <span id="error_TermCondition" class="text-danger medium"></span>
                                        </div>

                                    </div>
                                </div>
                            </div>


                            <div class="m-form__heading" style="text-align: center; padding-top: 10px;">
                                <h3 class="m-form__heading-title" style="line-height: 2.0; background: #ffaeae; font-size: 1.2rem;">SMS Templates</h3>
                            </div>
                            <br />
                            <div class="col-xl-12">
                                <div class="m-form__section">
                                    <div class="SMSTemplate_repeater">
                                        <div class="form-group  m-form__group row">

                                            <div data-repeater-list="VMS_SMSTemplate" class="col-lg-12" runat="server" id="VMS_SMSTemplate">

                                                <div data-repeater-item="" class="form-group m-form__group row" runat="server" id="Div3">
                                                    <div class="col-md-8">
                                                        <div class="m-form__group">
                                                            <div class="m-form__control">
                                                                <asp:TextBox ID="txtSMSTemplate" runat="server" TextMode="MultiLine" class="form-control m-input autosize_textarea TermCondition_textarea" placeholder="Enter SMS Template" ClientIDMode="Static" Rows="1"></asp:TextBox>
                                                                <span class="error_SMSTemplate text-danger medium"></span>
                                                                <input type="hidden" name="hdnRepeaterSMSID" id="hdnRepeaterSMSID" />
                                                            </div>
                                                        </div>
                                                        <div class="d-md-none m--margin-bottom-10"></div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:DropDownList ID="ddlSMS" data-show-content="true" data-show-icon="true" ClientIDMode="Static" class="form-control m-input type_select ddlSMS" placeholder="select" runat="server">
                                                            <asp:ListItem Value="0" Text="-Select-"></asp:ListItem>
                                                            <asp:ListItem Value="1" Text="Visit Request Submitted"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Visitor Marked IN"></asp:ListItem>
                                                            <asp:ListItem Value="3" Text="Visitor Marked OUT"></asp:ListItem>
                                                            <asp:ListItem Value="4" Text="Visit Request Rejected"></asp:ListItem>

                                                        </asp:DropDownList>

                                                    </div>

                                                    <div class="col-md-1">
                                                        <div data-repeater-delete="" class="btn btn-danger m-btn m-btn--icon m-btn--icon-only dltSection" id="dltSectionSMS">
                                                            <i class="la la-trash"></i>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="m-form__group form-group row">
                                            <div class="col-lg-4">
                                                <div data-repeater-create="" class="btn btn-accent m-btn m-btn--icon m-btn--pill m-btn--wide" id="divSMSAdd">
                                                    <span>
                                                        <i class="la la-plus"></i>
                                                        <span>Add SMS Template</span>
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="col-lg-8">
                                                <label id="Label1" runat="server" class="col-xl-6 col-lg-3 col-form-label font-weight-bold SMSTemplate_count" data-count="1">1 SMS Template(s)</label>
                                            </div>
                                            <span id="error_SMSTemplate" class="text-danger medium"></span>
                                        </div>

                                    </div>
                                </div>
                            </div>


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
                                                    <label class="btn btn-sm btn-light">
                                                        <%--<input id="ChkAnsFlag" type="checkbox" />--%>
                                                        <asp:CheckBox ID="ChkAnsFlag" CssClass="ChkAnsFlag" autocomplete="off" runat="server" ClientIDMode="Static" />Flag</label>
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
                    <asp:HiddenField ID="hdnVMSQns" ClientIDMode="Static" runat="server" />
                    <asp:HiddenField ID="hdnVMSTerms" ClientIDMode="Static" runat="server" />
                    <asp:HiddenField ID="hdnSMSTemplate" ClientIDMode="Static" runat="server" />
                    <%--</form>--%>
                </div>
            </div>
        </div>
    </div>
    <%--</div>--%>
</asp:Content>
