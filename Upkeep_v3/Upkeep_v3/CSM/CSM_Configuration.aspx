<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="CSM_Configuration.aspx.cs" Inherits="Upkeep_v3.CSM.CSM_Configuration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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

        var txtControl = null;
        var txtHdn = null;
        function PopUpGrid() {
            //debugger;
            $find('<%= mpeMeetingUsers.ClientID %>').show();
            txtHdn = hdnUsersID.toString();
            txtControl = hdnUsersID;
        }

        function FunEditClick(ID, Desc) {
            //debugger;
            //alert(ID);
            //alert(Desc);
            $("#txtUsers").val(Desc.replace("$", ","));

             $("#hdnUsersID").val(ID);
//document.getElementById("<%= txtHdn.ClientID%>").value = ID;
            $find('<%= mpeMeetingUsers.ClientID %>').hide();
            //window.close();

        }

        function SelectUser() {
            //alert('method call');
            //debugger;
            var SelectedUsersID = null;
            var SelectedUsersName = null;

            SelectedUsersID = document.getElementById('<%= hdnSelectedUserID.ClientID%>').value + "#0";
            SelectedUsersName = document.getElementById('<%= hdnSelectedUserName.ClientID%>').value;

            FunEditClick(SelectedUsersID, SelectedUsersName);
        }


        $(document).ready(function () {

            init_autosize();
            init_plugins();

            $("#divFreeService").show();
            $("#divChkFreeService").click(function () {
                //alert("hii");
                if ($("#ChkFreeService").is(":checked")) {
                    $("#divFreeService").show(300);
                } else {
                    $("#divFreeService").hide(200);
                }
            });

            $('.InQuestion_repeater').repeater({
                initEmpty: false,
                show: function () {
                    $(this).slideDown();
                    var counter = $(this).parents('.InQuestion_repeater').find('.question_count');
                    var question_count = counter.data('count');
                    question_count++;
                    $('#txtInQuestionCount').val(question_count);
                    counter.data('count', question_count).html(question_count + ' Question(s)');
                    $('#error_question_repeater').html('');

                    init_autosize();
                    init_plugins();
                },
                hide: function (deleteElement) {
                    $(this).slideUp(deleteElement);
                    var counter = $(this).parents('.InQuestion_repeater').find('.question_count');
                    var question_count = counter.data('count');
                    question_count--;
                    $('#txtInQuestionCount').val(question_count);
                    counter.data('count', question_count).html(question_count + ' Question(s)');
                    if (question_count == 0) {
                        $('#error_inquestion_repeater').html('Add at least one Question.');
                    }
                },
            });

            $('.OutQuestion_repeater').repeater({
                initEmpty: false,
                show: function () {
                    $(this).slideDown();
                    var counter = $(this).parents('.OutQuestion_repeater').find('.question_count');
                    var question_count = counter.data('count');
                    question_count++;
                    $('#txtOutQuestionCount').val(question_count);
                    counter.data('count', question_count).html(question_count + ' Question(s)');
                    $('#error_question_repeater').html('');

                    init_autosize();
                    init_plugins();
                },
                hide: function (deleteElement) {
                    $(this).slideUp(deleteElement);
                    var counter = $(this).parents('.OutQuestion_repeater').find('.question_count');
                    var question_count = counter.data('count');
                    question_count--;
                    $('#txtOutQuestionCount').val(question_count);
                    counter.data('count', question_count).html(question_count + ' Question(s)');
                    if (question_count == 0) {
                        $('#error_inquestion_repeater').html('Add at least one Question.');
                    }
                },
            });

            $('.TermComdition_repeater').repeater({
                initEmpty: true,
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

            $('body').on('change', '.CSMQuestion_repeater .question_textarea', function () {
                var error_ele = $(this).parent().find('.error_question');
                error_ele.html('').parents('.form-group').removeClass('has-error');
                if ($(this).val().trim() == '') {
                    $(this).parent().find('.error_question').html('Enter question.').parents('.form-group').addClass('has-error');
                }
            });


            $('body').on('change', '.CSMFeedback_repeater .CSMFeedback_textarea', function () {
                var error_ele = $(this).parent().find('.error_CSMFeedback');
                error_ele.html('').parents('.form-group').removeClass('has-error');
                if ($(this).val().trim() == '') {
                    $(this).parent().find('.error_CSMFeedback').html('Enter CSM Feedback.').parents('.form-group').addClass('has-error');
                }
            });



            $('#frmCSM').submit(function (event) {
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


                $('.CSMQuestion_repeater .question_textarea').each(function (index, element) {
                    if ($(this).val().trim() == '') {
                        is_valid = false;
                        $(this).parent().find('.error_question').html('Enter Question.').parents('.form-group').addClass('has-error');
                    }
                });

                if ($('.CSMQuestion_repeater .question_textarea').length == 0) {
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
                if ($(this).parent().find('.ddlAns').val() == "1")
                    $(".modal-title").text("Change Multi Select Answers");
                else if ($(this).parent().find('.ddlAns').val() == "2")
                    $(".modal-title").text("Change Single Select Answers");

                //alert("lblAnswerCnt click");
                var answers = $(this).parent().find('.hdnRepeaterAnswer').val();
                //if ($('#hdnCSMConfigID').val() != "0") {
                    answers = "ii:||:false;" + $(this).parent().find('.hdnRepeaterAnswer').val();
                //}
                //alert(answers);
                var arrAns = answers.split(";");

                for (var i = 0; i < arrAns.length; i++) {
                    //if (arrAns[i] != "ii:||") {
                    $("#divAnswerAdd").click();
                    //alert(arrAns[i]);
                    //alert(arrAns[i]); AnswerType[0][ctl00$ContentPlaceHolder1$hdnAnswerDataID]
                    var arrIDAns = arrAns[i].split(":");
                    //alert(arrIDAns[2]);

                    $("input[name~='AnswerType[" + i + "][ctl00$ContentPlaceHolder1$hdnAnswerDataID]']").val(arrIDAns[0]);
                    $("input[name~='AnswerType[" + i + "][txtAnswer]']").val(arrIDAns[1]);
                    if (arrIDAns[2] == "true") {
                        $("input[name~='AnswerType[" + i + "][ctl00$ContentPlaceHolder1$ChkAnsFlag][]']").prop("checked", true)
                        $("input[name~='AnswerType[" + i + "][ctl00$ContentPlaceHolder1$ChkAnsFlag][]']").parent().parent().addClass("active");
                    }

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


            if ($('#hdnCSMConfigID').val() != "0") {


                //$('#AnsModal').modal('show');
                //$('#AnsModal').modal('toggle');
                //$(".divQnDel").click();
                Bind_CSMConfiguration($('#hdnCSMConfigID').val());
            }

            function Bind_CSMConfiguration(CSMConfigID) {
                //alert(WPConfigID);
                //Bind CSM Questions
                if ($("#ChkFreeService").is(":checked")) {
                    $("#divFreeService").hide(300);
                    $("#ChkFreeService").parent().parent().addClass("active");
                }

                //In questions
                var inqns = $('#hdnInQns').val();
                var arrInQns = inqns.split("~");
                //alert(qns);
                for (var i = 0; i < arrInQns.length; i++) {
                    if (i !== 0)
                        $("#divInQnAdd").click();
                    //alert(arrTerms[i]);CSMQuestion[0][hdnRepeaterAnswer]

                    var QuestionID = $("input[name~='InQuestion[" + i + "][ctl00$ContentPlaceHolder1$hdnInQnID]']");
                    var Question = $("input[name~='InQuestion[" + i + "][ctl00$ContentPlaceHolder1$txtInQuestion]']");
                    var Answer = $("select[name~='InQuestion[" + i + "][ctl00$ContentPlaceHolder1$ddlInAns]']");
                    var hdnAnswer = $("input[name~='InQuestion[" + i + "][hdnInRepeaterAnswer]']");

                    var arrQnData = arrInQns[i].split("||");
                    QuestionID.val(arrQnData[0]);
                    Question.val(arrQnData[1]);
                    Answer.val(arrQnData[2]);
                    hdnAnswer.val(arrQnData[3]);
                    hdnAnswer.change();
                    //alert($("select[name~='CSMQuestion[" + i + "][ctl00$ContentPlaceHolder1$ddlAns]']").find(':selected'));
                    var isMulti = $("select[name~='InQuestion[" + i + "][ctl00$ContentPlaceHolder1$ddlInAns]'] option[value='" + arrQnData[2] + "']").attr("data-ismulti");
                    if (isMulti === 'True') {

                        //document.getElementsByName($(this).attr("name").replace("ctl00$ContentPlaceHolder1$ddlAns", "hdnRepeaterAnswer"))[0].setAttribute('type', 'hidden');
                        hdnAnswer.parent().parent().find(".lblAnswerCnt").show();
                    }
                    else {
                        hdnAnswer.parent().parent().find(".lblAnswerCnt").hide();
                    }
                    //alert($("input[name~='AnswerType[" + i + "][txtAnswer]']").val()); WorkPermitTermCondition[0][hdnRepeaterTermID]
                }

                //Out questions
                var Outqns = $('#hdnOutQns').val();
                var arrOutQns = Outqns.split("~");
                //alert(qns);
                for (var i = 0; i < arrOutQns.length; i++) {
                    if (i !== 0)
                        $("#divOutQnAdd").click();
                    //alert(arrTerms[i]);CSMQuestion[0][hdnRepeaterAnswer]

                    var QuestionID = $("input[name~='OutQuestion[" + i + "][ctl00$ContentPlaceHolder1$hdnOutQnID]']");
                    var Question = $("input[name~='OutQuestion[" + i + "][ctl00$ContentPlaceHolder1$txtOutQuestion]']");
                    var Answer = $("select[name~='OutQuestion[" + i + "][ctl00$ContentPlaceHolder1$ddlOutAns]']");
                    var hdnAnswer = $("input[name~='OutQuestion[" + i + "][hdnOutRepeaterAnswer]']");

                    var arrQnData = arrOutQns[i].split("||");
                    QuestionID.val(arrQnData[0]);
                    Question.val(arrQnData[1]);
                    Answer.val(arrQnData[2]);
                    hdnAnswer.val(arrQnData[3]);
                    hdnAnswer.change();
                    //alert($("select[name~='CSMQuestion[" + i + "][ctl00$ContentPlaceHolder1$ddlAns]']").find(':selected'));
                    var isMulti = $("select[name~='OutQuestion[" + i + "][ctl00$ContentPlaceHolder1$ddlOutAns]'] option[value='" + arrQnData[2] + "']").attr("data-ismulti");
                    //alert(isMulti);
                    if (isMulti === 'True') {
                        //alert('if');
                        //document.getElementsByName($(this).attr("name").replace("ctl00$ContentPlaceHolder1$ddlAns", "hdnRepeaterAnswer"))[0].setAttribute('type', 'hidden');
                        hdnAnswer.parent().parent().find(".lblAnswerCnt").show();
                    }
                    else {
                        //alert(hdnAnswer.parent().parent().find(".lblAnswerCnt").val());
                        hdnAnswer.parent().parent().find(".lblAnswerCnt").hide();
                    }
                    //alert($("input[name~='AnswerType[" + i + "][txtAnswer]']").val()); WorkPermitTermCondition[0][hdnRepeaterTermID]
                }

                //Terms
                var terms = $('#hdnTerms').val();
                var arrTerms = terms.split("~");
                debugger;
                for (var i = 0; i < arrTerms.length; i++) {
                    //if (i !== 0) {
                        $("#divTermAdd").click();//TermCondition[0][hdnRepeaterTermID]
                    //}
                }
                for (var i = 0; i < arrTerms.length; i++) {
                    var QuestionID = $("input[name='TermCondition[" + i + "][hdnRepeaterTermID]']");
                    var Question = $("textarea[name='TermCondition[" + i + "][ctl00$ContentPlaceHolder1$txtTermCondition]']");
                    //alert(Question.val());
                    //alert(terms);
                    var arrQnData = arrTerms[i].split("||");
                    QuestionID.val(arrQnData[0]);
                    Question.val(arrQnData[1]);
                    //alert("input[name~='TermCondition[" + i + "][hdnRepeaterTermID]']");

                }
                return;
            }
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

                        <%--<form class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmCSM" method="post">--%>
                        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

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
                                        <h3 class="m-portlet__head-text">CSM Configuration
                                        </h3>
                                    </div>
                                </div>

                                <div class="m-portlet__head-tools" style="width: 28%;">
                                    <%--<asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>--%>
                                    <a href="<%= Page.ResolveClientUrl("~/CSM/CSMConfig_Listing.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                        <span>
                                            <i class="la la-arrow-left"></i>
                                            <span>Back</span>
                                        </span>
                                    </a>
                                    <div class="btn-group">

                                        <asp:Button ID="btnSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" CausesValidation="true" ValidationGroup="validateCSM" OnClientClick="if(this.value === 'Saving...') { return false; } else { this.value = 'Saving...'; }return FunSetXML();" OnClick="btnSave_Click" Text="Save" />

                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="m-portlet__body" style="padding: 0.4rem 2.2rem;">

                            <div class="m-portlet__body" style="padding: 0.3rem 2.2rem;">
                                <div class="form-group m-form__group row" style="padding-left: 1%;">
                                    <label class="col-md-2 col-form-label font-weight-bold"><span style="color: red;">*</span>Title :</label>
                                    <div class="col-xl-6 col-lg-6">
                                        <asp:HiddenField ID="hdnCSMConfigID" ClientIDMode="Static" Value="0" runat="server" />
                                        <asp:TextBox ID="txtTitle" runat="server" class="form-control" ClientIDMode="Static"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTitle" Visible="true" Display="Dynamic"
                                                ValidationGroup="validateCSM" ForeColor="Red" ErrorMessage="Please enter Title"></asp:RequiredFieldValidator>--%>
                                        <span class="error_title text-danger medium"></span>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="btn-group btn-group-toggle" id="divChkFreeService" data-toggle="buttons">
                                            <label class="btn btn-light" id="lblFreeService">
                                                <asp:CheckBox ID="ChkFreeService" autocomplete="off" runat="server" ClientIDMode="Static" />
                                                <i class="fa fa-check" aria-hidden="true"></i>Free Service</label>
                                        </div>
                                    </div>

                                </div>
                                <div class="form-group m-form__group row" style="padding-left: 1%;">
                                    <label class="col-2 col-form-label font-weight-bold"><span style="color: red;">*</span> Request Flow:</label>
                                    <div class="col-6">
                                        <asp:TextBox ID="txtUsers" runat="server" ClientIDMode="Static" ReadOnly="true" CssClass="form-control m-input d-inline w-75">
                                        </asp:TextBox>
                                        <img src="../assets/app/media/img/icons/AddUser.png" width="32" height="32" onclick="PopUpGrid();" />
                                        <input type="hidden" name="hdnUsersID" id="hdnUsersID" tabindex="0" value="" />
                                        <span id="error_question_for" class="text-danger small"></span>
                                    </div>
                                    <div class="col-md-4" id="divFreeService">
                                        <label class="col-form-label font-weight-bold">Cost of Service:</label>
                                        <asp:TextBox ID="txtCost" Columns="1" CssClass="m-input" runat="server"></asp:TextBox>/
                                        <asp:TextBox ID="txtUnit" Columns="1" CssClass="m-inpt" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <br />

                                <div class="form-group row" style="background-color: #00c5dc;">
                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Requests Opening Questions</label>
                                </div>
                                <br />
                                <div class="col-xl-12">
                                    <div class="m-form__section">
                                        <div class="InQuestion_repeater">
                                            <div class="form-group  m-form__group row">

                                                <div data-repeater-list="InQuestion" class="col-lg-12" runat="server" id="InQuestion">

                                                    <div data-repeater-item="" class="form-group m-form__group row" runat="server" id="dvInQuestion">
                                                        <div class="col-md-7">
                                                            <div class="m-form__group">
                                                                <div class="m-form__control">
                                                                    <asp:HiddenField ID="hdnInQnID" ClientIDMode="Static" Value="0" runat="server" />
                                                                    <asp:TextBox ID="txtInQuestion" runat="server" class="form-control m-input autosize_textarea question_textarea" placeholder="Enter Opening Question" Rows="1"></asp:TextBox>
                                                                    <span class="error_question text-danger medium"></span>
                                                                </div>
                                                            </div>
                                                            <div class="d-md-none m--margin-bottom-10"></div>
                                                        </div>

                                                        <div class="col-md-4">
                                                            <div class="m-form__group">
                                                                <div class="m-form__control">
                                                                    <asp:DropDownList ID="ddlInAns" data-show-content="true" data-show-icon="true" ClientIDMode="Static" class="form-control m-input type_select ddlAns" placeholder="select" runat="server"></asp:DropDownList>
                                                                    <input type="hidden" name="hdnInRepeaterAnswer" placeholder="Enter Answer data" class="hdnRepeaterAnswer mt-3 form-control m-input autosize_textarea" id="hdnInRepeaterAnswer" />
                                                                    <i class="fa fa-edit lblAnswerCnt" style="display:none;"></i>
                                                                    <label id="lblInAnswerCnt" runat="server" style="display:none;" class="col-form-label font-weight-bold lblAnswerCnt mt-3">0 Answer(s) added !</label>

                                                                    <span class="error_type text-danger medium"></span>
                                                                </div>
                                                            </div>
                                                            <div class="d-md-none m--margin-bottom-10"></div>
                                                        </div>
                                                        <div class="col-md-1">
                                                            <div data-repeater-delete="" class="btn btn-danger m-btn m-btn--icon m-btn--icon-only divQnDel" id="divInQnDel">
                                                                <i class="la la-trash"></i>
                                                            </div>
                                                        </div>



                                                    </div>
                                                </div>
                                            </div>
                                            <div class="m-form__group form-group row">
                                                <div class="col-lg-4">
                                                    <div data-repeater-create="" class="btn btn-accent m-btn m-btn--icon m-btn--pill m-btn--wide" id="divInQnAdd">
                                                        <span>
                                                            <i class="la la-plus"></i>
                                                            <span>Add Question</span>
                                                        </span>
                                                    </div>
                                                </div>
                                                <div class="col-lg-8">

                                                    <input type="hidden" id="txtInQuestionCount" clientidmode="Static" data-count="1" value="1" class="txtquestion_count" runat="server" />
                                                    <label id="lblInQuestionCount" runat="server" class="col-xl-3 col-lg-3 col-form-label font-weight-bold question_count" data-count="1">1 Question(s)</label>
                                                </div>
                                                <span id="error_inquestion_repeater" class="text-danger medium"></span>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="form-group row" style="background-color: #00c5dc;">
                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Requests Closing Questions</label>
                                </div>
                                <br />
                                <div class="col-xl-12">
                                    <div class="m-form__section">
                                        <div class="OutQuestion_repeater">
                                            <div class="form-group  m-form__group row">

                                                <div data-repeater-list="OutQuestion" class="col-lg-12" runat="server" id="OutQuestion">

                                                    <div data-repeater-item="" class="form-group m-form__group row" runat="server" id="dvOutQuestion">
                                                        <div class="col-md-7">
                                                            <div class="m-form__group">
                                                                <div class="m-form__control">
                                                                    <asp:HiddenField ID="hdnOutQnID" ClientIDMode="Static" Value="0" runat="server" />
                                                                    <asp:TextBox ID="txtOutQuestion" runat="server" class="form-control m-input autosize_textarea question_textarea" placeholder="Enter Closing Question" Rows="1"></asp:TextBox>
                                                                    <span class="error_question text-danger medium"></span>
                                                                </div>
                                                            </div>
                                                            <div class="d-md-none m--margin-bottom-10"></div>
                                                        </div>

                                                        <div class="col-md-4">
                                                            <div class="m-form__group">
                                                                <div class="m-form__control">
                                                                    <asp:DropDownList ID="ddlOutAns" data-show-content="true" data-show-icon="true" ClientIDMode="Static" class="form-control m-input type_select ddlAns" placeholder="select" runat="server"></asp:DropDownList>
                                                                    <input type="hidden" name="hdnOutRepeaterAnswer" placeholder="Enter Answer data" class="hdnRepeaterAnswer mt-3 form-control m-input autosize_textarea" id="hdnOutRepeaterAnswer" />
                                                                    <i class="fa fa-edit lblAnswerCnt" style="display:none;"></i>
                                                                    <label id="lblOutAnswerCnt" runat="server" style="display:none;" class="col-form-label font-weight-bold lblAnswerCnt mt-3">0 Answer(s) added !</label>

                                                                    <span class="error_type text-danger medium"></span>
                                                                </div>
                                                            </div>
                                                            <div class="d-md-none m--margin-bottom-10"></div>
                                                        </div>
                                                        <div class="col-md-1">
                                                            <div data-repeater-delete="" class="btn btn-danger m-btn m-btn--icon m-btn--icon-only divQnDel" id="divOutQnDel">
                                                                <i class="la la-trash"></i>
                                                            </div>
                                                        </div>



                                                    </div>
                                                </div>
                                            </div>
                                            <div class="m-form__group form-group row">
                                                <div class="col-lg-4">
                                                    <div data-repeater-create="" class="btn btn-accent m-btn m-btn--icon m-btn--pill m-btn--wide" id="divOutQnAdd">
                                                        <span>
                                                            <i class="la la-plus"></i>
                                                            <span>Add Question</span>
                                                        </span>
                                                    </div>
                                                </div>
                                                <div class="col-lg-8">

                                                    <input type="hidden" id="txtOutQuestionCount" clientidmode="Static" data-count="1" value="1" class="txtquestion_count" runat="server" />
                                                    <label id="lblOutQuestionCount" runat="server" class="col-xl-3 col-lg-3 col-form-label font-weight-bold question_count" data-count="1">1 Question(s)</label>
                                                </div>
                                                <span id="error_outquestion_repeater" class="text-danger medium"></span>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <br />


                                <div class="form-group row" style="background-color: #00c5dc;">
                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Terms & Condition</label>
                                </div>
                                <br />
                                <div class="col-xl-12">
                                    <div class="m-form__section">
                                        <div class="TermComdition_repeater">
                                            <div class="form-group  m-form__group row">

                                                <div data-repeater-list="TermCondition" class="col-lg-12" runat="server" id="TermCondition">

                                                    <div data-repeater-item="" class="form-group m-form__group row" runat="server" id="Div2">
                                                        <div class="col-md-9">
                                                            <div class="m-form__group">
                                                                <div class="m-form__control">
                                                                    <asp:TextBox ID="txtTermCondition" TextMode="MultiLine" runat="server" class="form-control m-input autosize_textarea TermCondition_textarea txtvalidate" placeholder="Enter Term & Condition" Rows="1"></asp:TextBox>
                                                                    <input type="hidden" name="hdnRepeaterTermID" id="hdnRepeaterTermID" />
                                                                    <span class="error_TermCondition text-danger medium"></span>
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
                                                    <div data-repeater-create="" class="btn btn-accent m-btn m-btn--icon m-btn--pill m-btn--wide" id="divTermAdd">
                                                        <span>
                                                            <i class="la la-plus"></i>
                                                            <span>Add Term & Condition</span>
                                                        </span>
                                                    </div>
                                                </div>
                                                <div class="col-lg-8">
                                                    <input type="hidden" id="txtTermCount" clientidmode="Static" data-count="1" value="1" class="txtquestion_count" runat="server" />
                                                    <label id="lblTermCount" runat="server" class="col-xl-6 col-lg-3 col-form-label font-weight-bold TermCondition_count" data-count="0">0 Term & Condition(s)</label>
                                                </div>
                                                <span id="error_TermCondition" class="text-danger medium"></span>
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
                                                            <asp:CheckBox ID="ChkAnsFlag" CssClass="ChkAnsFlag" autocomplete="off" runat="server" ClientIDMode="Static" />
                                                            Flag</label>
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

                        <%--Panel for user selection--%>

                        <asp:Panel runat="server" ID="pnlMeetingUsers" CssClass="modalPopup" align="center" Style="display: none; width: 100%; top: 0;">
                            <div class="" id="add_sub_location" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document" style="max-width: 60%;">
                                    <div class="modal-content">
                                        <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>--%>

                                        <div class="modal-header">
                                            <h3 id="myModalLabel">Associate Information</h3>
                                            <button type="button" id="btnClose2" class="close" data-dismiss="modal" aria-hidden="true">×</button>

                                        </div>
                                        <div class="modal-body">
                                            <div class="box">
                                                <div class="nav-tabs-custom">
                                                    <ul class="nav nav-tabs nav-fill" role="tablist">
                                                        <li class="nav-item">
                                                            <a class="nav-link active" data-toggle="tab" href="#t1">User Info</a>
                                                        </li>
                                                        <li class="nav-item">
                                                            <a class="nav-link" data-toggle="tab" href="#t2">User Group Info</a>
                                                        </li>
                                                        <%--<li class="active">
<a href="#t1" data-toggle="tab">User Info</a>
</li>
<li>
<a href="#t2" data-toggle="tab">User Info Group</a>
</li>--%>
                                                    </ul>
                                                </div>
                                                <div class="box-body">
                                                    <div class="tab-content">
                                                        <div class="tab-pane active" id="t1" style="max-height: 500px; overflow: scroll;">

                                                            <br />

                                                            <asp:UpdatePanel runat="server">
                                                                <ContentTemplate>
                                                                    <div class="form-group m-form__group row">
                                                                        <div class="col-md-3">
                                                                            <div class="m-input-icon m-input-icon--left">
                                                                                <input type="text" class="form-control m-input" placeholder="Search..." id="generalSearch" />
                                                                                <span class="m-input-icon__icon m-input-icon__icon--left">
                                                                                    <span><i class="la la-search"></i></span>
                                                                                </span>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-6 row">
                                                                            <label class="col-form-label col-md-4">Department:</label>
                                                                            <asp:DropDownList ID="ddlDepartment" class="form-control m-input" Style="width: 40%;" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>

                                                                        </div>
                                                                        <div class="col-md-3" style="text-align: right;">
                                                                            <asp:Button ID="btnSelectUser" runat="server" Text="Select User" OnClick="btnSelectUser_Click" class="btn btn-primary btn-success" />
                                                                        </div>
                                                                    </div>
                                                                    <br />

                                                                    <asp:HiddenField ID="hdnSelectedUserID" runat="server" ClientIDMode="Static" />
                                                                    <asp:HiddenField ID="hdnSelectedUserName" runat="server" ClientIDMode="Static" />

                                                                    <asp:GridView ID="grdInfodetails" runat="server" ClientIDMode="Static" CssClass="table table-striped- table-bordered table-hover table-checkable m-datatable"
                                                                        AutoGenerateColumns="false" SkinID="grdSearch" OnRowDataBound="grdInfodetails_RowDataBound" Style="display: block;">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="User_ID" Visible="false"></asp:BoundField>
                                                                            <asp:TemplateField HeaderText="Select">
                                                                                <ItemTemplate>
                                                                                    <%--<asp:CheckBox ID="chkUserID" runat="server" CssClass="checkbox--success" Checked='<%# Convert.ToBoolean(Eval("Is_Selected")) %>' />--%>

                                                                                    <asp:CheckBox ID="chkUserID" runat="server" CssClass="m-checkbox--success" />

                                                                                    <asp:HiddenField ID="hdnUserID" runat="server" Value='<%#Eval("User_ID") %>' />
                                                                                    <asp:HiddenField ID="hdnUser_Name" runat="server" Value='<%#Eval("User_Name") %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Action/Info Description" SortExpression="User_Name">
                                                                                <ItemTemplate>
                                                                                    <a style="cursor: pointer; text-decoration: underline;" onclick="FunEditClick('<%# (DataBinder.Eval(Container.DataItem,"User_ID")) %>#0','<%# (DataBinder.Eval(Container.DataItem,"User_Name")) %>')">
                                                                                        <%# (DataBinder.Eval(Container.DataItem, "User_Name"))%>
                                                                                    </a>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="User_Name_Code" SortExpression="User_Name_Code" HeaderText="Employee"></asp:BoundField>
                                                                        </Columns>

                                                                        <EmptyDataTemplate>No Records Found !!!</EmptyDataTemplate>
                                                                        <EmptyDataRowStyle Height="50%" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Center" />
                                                                    </asp:GridView>

                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlDepartment" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </div>

                                                        <div class="tab-pane" id="t2">

                                                            <br />
                                                            <div class="form-group m-form__group row">
                                                                <div class="col-md-3">
                                                                    <div class="m-input-icon m-input-icon--left">
                                                                        <input type="text" class="form-control m-input" placeholder="Search..." id="generalSearchGroup" />
                                                                        <span class="m-input-icon__icon m-input-icon__icon--left">
                                                                            <span><i class="la la-search"></i></span>
                                                                        </span>
                                                                    </div>
                                                                </div>

                                                            </div>
                                                            <br />

                                                            <asp:GridView ID="grdGroupDesc" AutoGenerateColumns="false" CssClass="table table-striped- table-bordered table-hover table-checkable m-datatableGroup" runat="server" SkinID="grdSearch">
                                                                <Columns>
                                                                    <asp:BoundField DataField="GroupID" Visible="false"></asp:BoundField>

                                                                    <asp:TemplateField HeaderText="Action/Info Group Description" SortExpression="GroupName">
                                                                        <ItemTemplate>
                                                                            <a style="cursor: pointer; text-decoration: underline;" onclick="FunEditClick('0#<%# (DataBinder.Eval(Container.DataItem,"GroupID")) %>','<%# (DataBinder.Eval(Container.DataItem,"GroupName")) %>')">
                                                                                <%# (DataBinder.Eval(Container.DataItem, "GroupName"))%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="GroupUsers" SortExpression="GroupUsers" HeaderText="ActionInfo" ControlStyle-Width="100%"></asp:BoundField>

                                                                </Columns>

                                                                <EmptyDataTemplate>No Records Found !!!</EmptyDataTemplate>
                                                                <EmptyDataRowStyle Height="50%" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Center" />
                                                            </asp:GridView>
                                                        </div>

                                                    </div>
                                                </div>

                                            </div>
                                        </div>

                                        <%-- </ContentTemplate>--%>
                                        <%--<Triggers>
<asp:AsyncPostBackTrigger ControlID="btnMeetingMstSave" EventName="Click" />
</Triggers>--%>
                                        <%--</asp:UpdatePanel>--%>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>

                        <cc1:ModalPopupExtender ID="mpeMeetingUsers" runat="server" PopupControlID="pnlMeetingUsers" TargetControlID="pop2"
                            CancelControlID="btnClose2" BackgroundCssClass="modalBackground">
                        </cc1:ModalPopupExtender>

                        <asp:Button Text="text" Style="display: none;" ID="pop2" runat="server" />

                        <input type="hidden" id="HdnID" runat="server" />
                        <asp:TextBox ID="txtHdn" runat="server" ClientIDMode="Static" Width="100%" Style="display: none"></asp:TextBox>
                        <asp:HiddenField ID="hdnInQns" ClientIDMode="Static" runat="server" />
                        <asp:HiddenField ID="hdnOutQns" ClientIDMode="Static" runat="server" />
                        <asp:HiddenField ID="hdnTerms" ClientIDMode="Static" runat="server" />

                        <%--</form>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
