<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="WorkPermit_Configuration.aspx.cs" Inherits="Upkeep_v3.WorkPermit.WorkPermit_Configuration" %>

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

        .lblAnswerCnt {
            cursor: pointer;
        }


        .txtAnswer {
            background: transparent;
            border: none;
            border-bottom: 1px solid #000000;
            -webkit-box-shadow: none !important;
            box-shadow: none;
            border-radius: 0;
        }

            .txtAnswer:focus {
                -webkit-box-shadow: none !important;
                box-shadow: none;
            }

        input[type=text].WPSectionName {
            color: #ffffff;
            background-color: transparent;
            border: 0;
        }

            input[type=text].WPSectionName:focus {
                background-color: white;
            }
    </style>

    <script>
        function init_autosize() {
            var autosize_textarea = $('.autosize_textarea');
            autosize(autosize_textarea);
            autosize.update(autosize_textarea);
        }

        $(document).ready(function () {


            $('.lblAnswerCnt').hide();

            //$('.ddlAns > option').each(function () {
            //    //$(this).setAttribute()
            //});


            init_autosize();
            init_plugins();

            $('.WorkPermitSection_repeater.outer').repeater({

                repeaters: [{
                    // (Required) //WorkPermitSection_repeater outer
                    // Specify the jQuery selector for this nested repeater
                    selector: '.WorkPermitSection_repeater.outer',

                    initEmpty: true,
                    defaultValues: {
                        'ContentPlaceHolder1_txtWorkPermitSection': 'Section',
                        //'this_name': 'foo'
                    },
                    show: function () {
                        $(this).slideDown();
                        var counter = $(this).parent().find('.section_count');
                        var section_count = counter.data('count');
                        section_count++;
                        alert(section_count);
                        counter.data('count', section_count).html(section_count + ' Section(s)');
                        $('#error_section_repeater').html('');

                        init_autosize();
                        init_plugins();
                    },
                    hide: function (deleteElement) {
                        $(this).slideUp(deleteElement);
                        var counter = $(this).parents('.WorkPermitSection_repeater.outer').find('.section_count');
                        var section_count = counter.data('count');
                        section_count--;
                        counter.data('count', section_count).html(section_count + ' Section(s)');
                        if (section_count == 0) {
                            $('#error_section_repeater').html('Add at least one Section Type.');
                        }
                    },

                    // (Required)
                    // Specify the jQuery selector for this nested repeater
                    //$('.WorkPermitSection_repeater.outer').repeater({

                    //	repeaters: [{

                    //	}]
                    //});
                    selector: '.WorkPermitHeader_repeater.inner',
                    initEmpty: true,
                    defaultValues: {
                        'ddlAns': '1',
                        //'this_name': 'foo'
                    },
                    show: function () {
                        $(this).slideDown();

                        //$(this).parents().find('.ddlAns').selectpicker();
                        var txtcounter = $(this).parents('.cntr').find('.txtquestion_count');
                        var counter = $(this).parents('.WorkPermitHeader_repeater.inner').find('.question_count');
                        var question_count = counter.data('count');
                        var txtquestion_count = txtcounter.data('count');
                        question_count++;
                        txtquestion_count++;
                        //alert(question_count);
                        counter.data('count', question_count).html(question_count + ' Header(s)');
                        txtcounter.data('count', txtquestion_count).val(txtquestion_count);
                        $('#error_question_repeater').html('');

                        init_autosize();
                        init_plugins();
                    },
                    hide: function (deleteElement) {
                        $(this).slideUp(deleteElement);
                        var counter = $(this).parents('.WorkPermitHeader_repeater.inner').find('.question_count');
                        var txtcounter = $(this).parents('.cntr').find('.txtquestion_count');
                        var question_count = counter.data('count');
                        var txtquestion_count = txtcounter.data('count');
                        question_count--;
                        txtquestion_count--;
                        //alert(question_count);
                        counter.data('count', question_count).html(question_count + ' Header(s)');
                        txtcounter.data('count', txtquestion_count).val(txtquestion_count);
                        if (question_count == 0) {
                            $('#error_question_repeater').html('Add at least one Header.');
                        }
                    },
                }]
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

            $('body').on('change', '.WorkPermitHeader_repeater .question_textarea', function () {
                var error_ele = $(this).parent().find('.error_question');
                error_ele.html('').parents('.form-group').removeClass('has-error');
                if ($(this).val().trim() == '') {
                    $(this).parent().find('.error_question').html('Enter question.').parents('.form-group').addClass('has-error');
                }
            });

            $('body').on('change', '.WorkPermitType_repeater .WorkPermitType_textarea', function () {
                var error_ele = $(this).parent().find('.error_WorkPermitType');
                error_ele.html('').parents('.form-group').removeClass('has-error');
                if ($(this).val().trim() == '') {
                    $(this).parent().find('.error_WorkPermitType').html('Enter WorkPermit Type.').parents('.form-group').addClass('has-error');
                }
            });

            $('body').on('change', '.TermComdition_repeater .TermCondition_textarea', function () {
                var error_ele = $(this).parent().find('.error_TermCondition');
                error_ele.html('').parents('.form-group').removeClass('has-error');
                if ($(this).val().trim() == '') {
                    $(this).parent().find('.error_TermCondition').html('Enter Term & Comdition').parents('.form-group').addClass('has-error');
                }
            });

            $('#frmWorkPermit').submit(function (event) {
                //alert('hiiiii');
                var is_valid = true;

                $('.WorkPermitHeader_repeater .question_textarea').each(function (index, element) {
                    if ($(this).val().trim() == '') {
                        is_valid = false;
                        $(this).parent().find('.error_question').html('Enter Header.').parents('.form-group').addClass('has-error');
                    }
                });



                $('.WorkPermitType_repeater .WorkPermitType_textarea').each(function (index, element) {
                    if ($(this).val().trim() == '') {
                        is_valid = false;
                        $(this).parent().find('.error_WorkPermitType').html('Enter Type.').parents('.form-group').addClass('has-error');
                    }
                });

                //$('.TermComdition_repeater .TermCondition_textarea').each(function (index, element) {
                //    if ($(this).val().trim() == '') {
                //        is_valid = false;
                //        $(this).parent().find('.error_TermCondition').html('Enter Term & Condition.').parents('.form-group').addClass('has-error');
                //    }
                //});

                if ($('.WorkPermitHeader_repeater .question_textarea').length == 0) {
                    //alert('sdf');
                    is_valid = false;

                    $('#error_question_repeater').html('Add at least one Header.');
                }

                console.log('is_valid = ' + is_valid);

                // alert('sgdfgdfgfdfdfdfddf');

                if (!is_valid) {
                    //alert('sgdfgdfgdf');
                    event.preventDefault();
                }
            });

            //var ModalHTML = "";
            var name = "";
            $(document).on('change', '.ddlAns', function () {
                var isMulti = $(this).find(':selected').attr("data-ismulti");
                if (isMulti === "")
                    return
                //alert(isMulti+"===");
                if (isMulti === 'True') {
                    //document.getElementsByName($(this).attr("name").replace("ctl00$ContentPlaceHolder1$ddlAns", "hdnRepeaterAnswer"))[0].setAttribute('type', 'hidden');
                    $(this).parent().parent().find(".lblAnswerCnt").show();

                    $('.dltrptanswer').click();
                    //WorkPermitSection[0][WorkPermitHeader][0][ctl00$ContentPlaceHolder1$ddlAns]  btnModalAdd
                    name = $(this).attr("name").replace("ctl00$ContentPlaceHolder1$ddlAns", "hdnRepeaterAnswer");
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
                name = $(this).parent().find('#hdnRepeaterAnswer').attr("name");
                //alert(name);
                //alert($(this).parent().find('#ddlAns').val());
                if ($(this).parent().find('#ddlAns').val() == "1")
                    $(".modal-title").text("Change Multi Select Answers");
                else if ($(this).parent().find('#ddlAns').val() == "2")
                    $(".modal-title").text("Change Single Select Answers");

                //alert("lblAnswerCnt click");
                var answers = $(this).parent().find('.hdnRepeaterAnswer').val();
                if ($('#hdnWPConfigID').val() != "0") {
                    answers = "ii::||;" + $(this).parent().find('.hdnRepeaterAnswer').val();
                }
                var arrAns = answers.split(";");

                for (var i = 0; i < arrAns.length; i++) {
                    //if (arrAns[i] != "ii::||") {
                    $("#divAnswerAdd").click();
                    //alert(arrAns[i]);
                    //alert(arrAns[i]); AnswerType[0][ctl00$ContentPlaceHolder1$hdnAnswerDataID]
                    if ($('#hdnWPConfigID').val() != "0") {
                        var arrIDAns = arrAns[i].split("::");

                        $("input[name~='AnswerType[" + i + "][ctl00$ContentPlaceHolder1$hdnAnswerDataID]']").val(arrIDAns[0]);
                        $("input[name~='AnswerType[" + i + "][txtAnswer]']").val(arrIDAns[1]);
                    }
                    else
                        $("input[name~='AnswerType[" + i + "][txtAnswer]']").val(arrAns[i]);
                    //var arrIDAns = arrAns[i].split("::");

                    //$("input[name~='AnswerType[" + i + "][ctl00$ContentPlaceHolder1$hdnAnswerDataID]']").val(arrIDAns[0]);
                    //$("input[name~='AnswerType[" + i + "][txtAnswer]']").val(arrIDAns[1]);
                    //alert(arrIDAns[1]);
                    //alert("input[name~='AnswerType[" + i + "][txtAnswer]']");
                    //alert(arrIDAns[1]);
                    //alert($("input[name~='AnswerType[" + i + "][txtAnswer]']").val());
                    //$("#divAnswerAdd").click();
                    //}

                }

                $('.divTxtAnswer input[type="text"]').each(function () {
                    // Do your magic here 
                    //alert($(this).val());
                    if ($(this).val() === "||" || $(this).val() === "") {//RC 19 May
                        //alert("jjjj");
                        //alert($(this).siblings('.dltrptanswer').html());
                        $(this).siblings('.dltrptanswer').click(); //RC 19 May
                    }
                });
                $('#btnModal').click();
            });

            $(document).on('click', '#btnModalAdd', function () {
                //var answers = "";
                var answers = "";
                var cnt = 0;
                //alert(name);
                $('.divTxtAnswer input[type="text"]').each(function () {
                    // Do your magic here 
                    //alert($(this).val());
                    if ($(this).val() === "||" || $(this).val() == "") {
                        //alert("found");
                        //$(this).siblings('.dltrptanswer').click();
                        return; //RC 19 May
                    }
                    if ($('#hdnWPConfigID').val() != "0") {
                        if (answers == "") {
                            answers += $(this).siblings('#hdnAnswerDataID').val() + "::" + $(this).val();
                        }
                        else {
                            answers += ";" + $(this).siblings('#hdnAnswerDataID').val() + "::" + $(this).val();
                        }
                        cnt++;
                    }
                    else {
                        if (answers == "") {
                            answers += $(this).val();
                        }
                        else {
                            answers += ";" + $(this).val();
                        }
                        cnt++;
                    }

                });
                //var name = $("#hdnAns").val();
                $("input[name~='" + name + "']").val(answers);
                $("input[name~='" + name + "']").change();
                //$(".divTxtAnswer").html(ModalHTML);
                $('.dltrptanswer').click();
                //alert(answers);
            });

            if ($('#hdnWPConfigID').val() != "0") {


                //$('#AnsModal').modal('show');
                //$('#AnsModal').modal('toggle');
                Bind_WorkPermitConfiguration($('#hdnWPConfigID').val());
            }

            function Bind_WorkPermitConfiguration(WPConfigID) {
                //alert(WPConfigID);
                //Bind WP Terms
                $(".dltSection").click();
                var terms = $('#hdnWPTerms').val();
                var arrTerms = terms.split("~");
                //alert(arrTerms);
                for (var i = 0; i < arrTerms.length; i++) {
                    $("#divTermAdd").click();
                    //alert(arrTerms[i]);

                    var arrIDTerm = arrTerms[i].split("||");
                    $("input[name~='WorkPermitTermCondition[" + i + "][hdnRepeaterTermID]']").val(arrIDTerm[0]);
                    $("textarea[name~='WorkPermitTermCondition[" + i + "][ctl00$ContentPlaceHolder1$txtTermComdition]']").val(arrIDTerm[1]);

                    //alert($("input[name~='AnswerType[" + i + "][txtAnswer]']").val()); WorkPermitTermCondition[0][hdnRepeaterTermID]
                }

                //Bind WP Section
                var sections = $('#hdnWPSections').val();
                var arrSections = sections.split("~");
                //alert(arrTerms);
                for (var i = 0; i < arrSections.length; i++) {
                    $("#divSectionAdd").click();
                    //alert(arrTerms[i]);
                    var arrIDSection = arrSections[i].split("||");
                    $("input[name~='WorkPermitSection[" + i + "][ctl00$ContentPlaceHolder1$hdnWPSectionID]']").parents('.dvWorkPermitSection').attr("data-SectionID", arrIDSection[0]);
                    $("input[name~='WorkPermitSection[" + i + "][ctl00$ContentPlaceHolder1$hdnWPSectionID]']").val(arrIDSection[0]);
                    $("input[name~='WorkPermitSection[" + i + "][ctl00$ContentPlaceHolder1$txtWorkPermitSection]']").val(arrIDSection[1]);

                    //alert($("input[name~='AnswerType[" + i + "][txtAnswer]']").val()); WorkPermitSection[0][ctl00$ContentPlaceHolder1$txtWorkPermitSection]
                }

                //Bind WP Headers with answesrs
                var headers = $('#hdnWPHeaders').val();
                var arrHeaders = headers.split("~");
                //alert(arrHeaders);
                //debugger;
                for (var i = 0; i < arrHeaders.length; i++) {
                    //$("#divSectionAdd").click();
                    //alert(arrTerms[i]);   
                    var arrHeaderData = arrHeaders[i].split("||");
                    var section = $("div[data-SectionID~='" + arrHeaderData[0] + "']");
                    section.children().find(".divHeaderAdd").click();
                    section.children().find(".dvWorkPermitHeader").not(".updated").attr("data-HeaderID", arrHeaderData[1]);
                    section.children().find(".dvWorkPermitHeader").addClass("updated");
                    var header = section.find("div[data-HeaderID~='" + arrHeaderData[1] + "']");
                    header.children().find("#hdnWorkPermitHeader").val(arrHeaderData[1]);
                    header.children().find(".question_textarea").val(arrHeaderData[2]);
                    //section.children().find(".question_textarea").val(arrHeaderData[2]);
                    //alert(arrHeaderData[4]);
                    //alert(section.children().find("#ddlAns").val());  $('.lblAnswerCnt').hide();
                    //alert(header.children().find("select").val());

                    var IsMandatory = arrHeaderData[3];
                    if (IsMandatory == "*") {
                        header.children().find(".clsMandatory input").prop('checked', true);
                        //header.children().find(".clsMandatory").find("input[type='checkbox']").prop('checked', true);
                    }

                    header.children().find("select").val(arrHeaderData[4]);
                    //header.children().find("select").selectpicker('refresh');
                    header.children().find(".hdnRepeaterAnswer").val(arrHeaderData[5]);
                    header.children().find(".hdnRepeaterAnswer").change();
                    if (arrHeaderData[4] == "1" || arrHeaderData[4] == "2") {
                        header.children().find(".lblAnswerCnt").show();
                    }
                    var isMulti = header.children().find("select").find('option:selected').attr("data-ismulti");
                    if (isMulti === 'True') {

                        //WorkPermitSection[1][WorkPermitHeader][2][ctl00$ContentPlaceHolder1$ddlAns]
                        header.children().find(".lblAnswerCnt").show();
                    }
                    else {
                        header.children().find(".lblAnswerCnt").hide();
                    }
                    //$("input[name~='WorkPermitSection[" + i + "][ctl00$ContentPlaceHolder1$hdnWPSectionID]']").parents('.dvWorkPermitSection').attr("data-SectionID",arrIDSection[0]);
                    //$("input[name~='WorkPermitSection[" + i + "][ctl00$ContentPlaceHolder1$hdnWPSectionID]']").val(arrIDSection[0]);
                    //$("input[name~='WorkPermitSection[" + i + "][ctl00$ContentPlaceHolder1$txtWorkPermitSection]']").val(arrIDSection[1]);

                    //alert($("input[name~='AnswerType[" + i + "][txtAnswer]']").val()); WorkPermitSection[0][ctl00$ContentPlaceHolder1$txtWorkPermitSection]
                }

            }
        });

        //        function OpenModal() {
        //}


        var txtControl = null;
        var txtHdn = null;
        function PopUpGrid(obj, objhdn) {
			//debugger;
			//alert($('#<%= mpeApprovalMatrix.ClientID %>').text());
			<%--$find('<%= mpeApprovalMatrix.ClientID %>').show();--%>
		   <%-- $('#<%= pnlApprovalMatrix.ClientID %>').show();--%>


            $find('<%= mpeApprovalMatrix.ClientID %>').show();
            txtHdn = objhdn.toString();
            txtControl = obj;
        }

        function FunEditClick(ID, Desc) {
            //debugger;
            txtControl.value = Desc;
            document.getElementById('ContentPlaceHolder1_' + txtHdn).value = ID;
			//document.getElementById("<%= txtHdn.ClientID%>").value = ID;
            $find('<%= mpeApprovalMatrix.ClientID %>').hide();
            //window.close();

        }

        function removeRows() {
            $("#ctl00_cntPlaceHolder_TblLevels").find("tr:gt(0)").remove();
        }


        function FunSetXML() {
            window.document.getElementById("<%= txtHdn.ClientID%>").value = "";
            var VarLocTab = window.document.getElementById("<%=TblLevels.ClientID%>");
            for (var i = 1; i <= VarLocTab.rows.length - 1; i++) {
                var VarLocRowObj = VarLocTab.rows[i].id;
                var lvl = window.document.getElementById(VarLocRowObj).children[0].innerHTML;
                if ((window.document.getElementById(VarLocRowObj).children[1].children[2].value) == "") {
                    ShowNotification("Warning !", "Action Details Should not be blank");
                    alert('Action Details Should not be blank');
                    return false;
                }
                else {
                    var action = window.document.getElementById(VarLocRowObj).children[1].children[2].value;
                }
                //        var action = window.document.getElementById(VarLocRowObj).children[1].children[2].value;



                if (document.getElementById(VarLocRowObj).children[2].children[0].checked == true) {
                    var SendEmail = 1;
                }
                else {
                    var SendEmail = 0;

                }

                if (document.getElementById(VarLocRowObj).children[3].children[0].checked == true) {
                    var SendSMS = 1;
                }
                else {
                    var SendSMS = 0;
                }

                if (document.getElementById(VarLocRowObj).children[4].children[0].checked == true) {
                    var SendNotification = 1;
                }
                else {
                    var SendNotification = 0;
                }

                if (document.getElementById(VarLocRowObj).children[5].children[0].checked == true) {
                    var MobileAccess = 1;
                }
                else {
                    var MobileAccess = 0;
                }

                if (document.getElementById(VarLocRowObj).children[6].children[0].checked == true) {
                    var WebAccess = 1;
                }
                else {
                    var WebAccess = 0;
                }

                if (document.getElementById(VarLocRowObj).children[7].children[0].checked == true) {
                    var ApprovalRights = 1;
                }
                else {
                    var ApprovalRights = 0;
                }

                if (document.getElementById(VarLocRowObj).children[8].children[0].checked == true) {
                    var HoldRights = 1;
                }
                else {
                    var HoldRights = 0;
                }

                if (document.getElementById(VarLocRowObj).children[9].children[0].checked == true) {
                    var RejectRights = 1;
                }
                else {
                    var RejectRights = 0;
                }



                var nxtlvl = window.document.getElementById(VarLocRowObj).children[10].innerHTML;
                var strInfo = lvl + "#" + action + "#" + SendEmail + "#" + SendSMS + "#" + SendNotification + "#" + MobileAccess + "#" + WebAccess + "#" + ApprovalRights + "#" + HoldRights + "#" + RejectRights + "#" + nxtlvl;

                if (window.document.getElementById("<%= txtHdn.ClientID%>").value == "") {
					<%--window.document.getElementById("<%= txtHdn.ClientID%>").value += "=$=" + strInfo + "=$=";--%>
                    window.document.getElementById("<%= txtHdn.ClientID%>").value += strInfo + ",";
                }
                else {
					<%--window.document.getElementById("<%= txtHdn.ClientID%>").value += strInfo + "=$=";--%>
                    window.document.getElementById("<%= txtHdn.ClientID%>").value += strInfo + ",";
                }

            }
            return true;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <%--<form class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmWorkPermit" method="post">--%>
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

                                        <h3 class="m-portlet__head-text">Work Permit Configuration
                                        </h3>
                                    </div>
                                </div>

                                <div class="m-portlet__head-tools" style="width: 28%;">
                                    <a href="<%= Page.ResolveClientUrl("~/WorkPermit/WPConfig_Listing.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                        <span>
                                            <i class="la la-arrow-left"></i>
                                            <span>Back</span>
                                        </span>
                                    </a>
                                    <div class="btn-group">

                                        <asp:Button ID="btnSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" ValidationGroup="validateTicket" OnClientClick="return FunSetXML();" OnClick="btnSave_Click" Text="Save" />

                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="m-portlet__body" style="padding: 0.4rem 2.2rem;">
                            <div class="m-portlet__body" style="padding: 0.3rem 2.2rem;">
                                <div class="form-group m-form__group row" style="padding-left: 1%;">
                                    <label class="col-xl-3 col-lg-2 form-control-label"><span style="color: red;">*</span>Title :</label>
                                    <div class="col-xl-4 col-lg-4">
                                        <asp:HiddenField ID="hdnWPConfigID" ClientIDMode="Static" Value="0" runat="server" />
                                        <asp:TextBox ID="txtTitle" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTitle" Visible="true" Display="Dynamic"
                                            ValidationGroup="validateWorkPermit" ForeColor="Red" ErrorMessage="Please enter Title"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <%--<div class="form-group m-form__group row" style="padding-left: 1%;">
										<label class="col-xl-3 col-lg-2 col-form-label"><span style="color: red;">*</span> Company :</label>
										<div class="col-xl-4 col-lg-4">
											<asp:DropDownList ID="ddlCompany" class="form-control m-input" runat="server"></asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCompany" Visible="true" Display="Dynamic"
												ValidationGroup="validateWorkPermit" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Company"></asp:RequiredFieldValidator>
										</div>
									</div>--%>


                                <div class="m-form__group form-group row" style="padding-left: 1%;">
                                    <label class="col-3 col-form-label"><span style="color: red;">*</span> Initiator</label>
                                    <div class="col-4">
                                        <div class="m-radio-inline">
                                            <label class="m-radio">
                                                <asp:RadioButton ID="rdbEmployee" runat="server" GroupName="Initiator" />
                                                Employee
													<span></span>
                                            </label>
                                            <label class="m-radio">
                                                <asp:RadioButton ID="rdbRetailer" runat="server" GroupName="Initiator" Checked="true" />
                                                Retailers
													<span></span>
                                            </label>
                                        </div>
                                        <span id="error_question_for" class="text-danger small"></span>
                                    </div>

                                    <div class="col-xl-4 col-lg-5" id="dvLinkDept" runat="server">
                                        <asp:CheckBox ID="ChkLinkDept" CssClass="m-checkbox--success" runat="server" />
                                        <label class="col-xl-6 col-lg-6 col-form-label m-checkbox--success">Link Department</label>
                                    </div>

                                </div>
                                <div class="form-group m-form__group row" style="padding-left: 1%;">
                                    <label class="col-xl-3 col-lg-2 form-control-label"><span style="color: red;">*</span>Work Permit Transaction Prefix :</label>
                                    <div class="col-xl-4 col-lg-4">
                                        <asp:TextBox ID="txtWPPrefix" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTitle" Visible="true" Display="Dynamic"
                                            ValidationGroup="validateGatePass" ForeColor="Red" ErrorMessage="Please enter Title"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="WorkPermitSection_repeater outer">
                                    <div class="form-group  m-form__group row">

                                        <div data-repeater-list="WorkPermitSection" class="outer col-lg-12" runat="server" id="WorkPermitSection">

                                            <div data-repeater-item="" class="dvWorkPermitSection outer form-group m-form__group row" runat="server" id="dvWorkPermitSection">
                                                <div class="form-group row w-100" style="background-color: #00c5dc;">

                                                    <label id="lblWorkPermitSection" runat="server" class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">
                                                        <i class="fa fa-edit ml-3">
                                                            <input type="text" value="Work Permit Section" class="txtvalidate" placeholder="Work Permit Section" id="txtWorkPermitSection" style="color: #ffffff; background-color: transparent; border: 0;" runat="server" />
                                                            <asp:HiddenField ID="hdnWPSectionID" Value="0" ClientIDMode="Static" runat="server" />
                                                        </i>

                                                    </label>

                                                    <%--<asp:TextBox ID="txtCount" runat="server" ></asp:TextBox>--%>
                                                    <div data-repeater-delete="" class="dltSection outer col-xl-1 col-lg-1 offset-8 btn btn-danger m-btn m-btn--icon m-btn--icon-only">
                                                        <i class="la la-trash"></i>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="col-xl-12">
                                                    <div class="m-form__section cntr">
                                                        <input type="hidden" id="txtCount" data-count="0" value="0" class="txtquestion_count" runat="server" />
                                                        <div class="WorkPermitHeader_repeater inner">
                                                            <div class="form-group  m-form__group row">
                                                                <div class="col-xl-1">

                                                                    <div data-repeater-create="" class="divHeaderAdd inner btn btn-accent s-btn s-btn--icon s-btn--pill s-btn--wide">
                                                                        <span>
                                                                            <i class="la la-plus"></i>
                                                                        </span>
                                                                    </div>
                                                                    <label id="lblHeaderCount" runat="server" class="col-form-label font-weight-bold question_count" data-count="0">0 Header(s)</label>
                                                                </div>
                                                                <div class="col-xl-11">

                                                                    <div data-repeater-list="WorkPermitHeader" class="inner col-lg-12" runat="server" id="WorkPermitHeader">

                                                                        <div data-repeater-item="" class="dvWorkPermitHeader inner form-group m-form__group row" runat="server" id="dvWorkPermitHeader">
                                                                            <div class="row w-100">
                                                                                <div class="col-md-6">
                                                                                    <div class="m-form__group">
                                                                                        <div class="m-form__control">
                                                                                            <asp:HiddenField ID="hdnWorkPermitHeader" Value="0" ClientIDMode="Static" runat="server" />
                                                                                            <asp:TextBox ID="txtWorkPermitHeader" runat="server" class="form-control m-input autosize_textarea question_textarea txtvalidate" placeholder="Enter WorkPermit Header" Rows="1"></asp:TextBox>
                                                                                            <span class="error_question text-danger medium"></span>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="d-md-none m--margin-bottom-10"></div>
                                                                                </div>

                                                                                <div class="col-md-2">
                                                                                    <div class="m-form__group">
                                                                                        <div class="m-form__control ">
                                                                                            <asp:CheckBox ID="ChkMandatory" runat="server" ClientIDMode="Static" class="clsMandatory" Text="Mandatory" />
                                                                                            <%--<label for="ChkMandatory" class="col-xl-6 col-lg-6 col-form-label">Mandatory</label>--%>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="d-md-none m--margin-bottom-10"></div>
                                                                                </div>
                                                                                <div class="col-md-3">
                                                                                    <div class="m-form__group">
                                                                                        <div class="m-form__control">
                                                                                            <%--		<select name="type" id="sltest" runat="server" class="form-control m-input type_select">
																			<option value="" selected="selected">Select Answer Type</option>
																			<option value="YesNo">Yes/No</option>
																			<option value="Text">Text</option>
																		</select>--%>
                                                                                            <asp:DropDownList ID="ddlAns" data-show-content="true" data-show-icon="true" ClientIDMode="Static" class="form-control m-input type_select ddlAns" placeholder="select" runat="server"></asp:DropDownList>
                                                                                            <input type="hidden" name="hdnRepeaterAnswer" placeholder="Enter Answer data" class="hdnRepeaterAnswer mt-1 form-control m-input autosize_textarea" id="hdnRepeaterAnswer" />
                                                                                            <i class="fa fa-edit lblAnswerCnt"></i>
                                                                                            <label id="lblAnswerCnt" runat="server" class="col-form-label font-weight-bold lblAnswerCnt">0 Answer(s) added !</label>

                                                                                            <span class="error_type text-danger medium"></span>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="d-md-none m--margin-bottom-10"></div>
                                                                                </div>
                                                                                <div class="col-md-1">
                                                                                    <div data-repeater-delete="" class="inner btn btn-danger m-btn m-btn--icon m-btn--icon-only">
                                                                                        <i class="la la-trash"></i>
                                                                                    </div>
                                                                                </div>

                                                                            </div>
                                                                            <div class="row">
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="m-form__group form-group row">
                                                                <div class="col-lg-4">
                                                                </div>
                                                                <div class="col-lg-8">
                                                                </div>
                                                                <span id="error_question_repeater" class="text-danger medium"></span>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="m-form__group form-group row">
                                        <div class="col-lg-4">
                                            <div data-repeater-create="" id="divSectionAdd" class="outer btn btn-accent m-btn m-btn--icon m-btn--pill m-btn--wide">
                                                <span>
                                                    <i class="la la-plus"></i>
                                                    <span>Add Section</span>
                                                </span>
                                            </div>
                                        </div>
                                        <div class="col-lg-8">
                                            <label id="lblSectionCount" runat="server" style="display: none" class="col-xl-3 col-lg-3 col-form-label font-weight-bold section_count" data-count="1">1 Section(s)</label>
                                        </div>
                                        <span id="error_section_repeater" class="text-danger medium"></span>
                                    </div>
                                </div>

                                <br />
                                <div class="form-group row" style="background-color: #00c5dc;">
                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Approval Matrix</label>
                                </div>
                                <br />
                                <div>
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

                                </div>

                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>

                                        <div class="form-group row" style="margin-bottom: 0;">
                                            <label for="message-text" class="col-xs-8 col-lg-2 form-control-label" style="text-align: center;">No Of Levels :</label>
                                            <asp:TextBox ID="txtNoOfLevel" runat="server" class="form-control" Style="width: 21%;"></asp:TextBox>

                                            <asp:Button ID="btnMakeCombination" runat="server" class="m-badge m-badge--brand m-badge--wide" Style="margin-left: 5%; cursor: pointer;" OnClick="btnMakeCombination_Click" Text="Make Combination" ValidationGroup="validationApprovalMatrx" />

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNoOfLevel" Visible="true"
                                                Style="margin-left: 1%; margin-top: 1%;" ValidationGroup="validationApprovalMatrx" ForeColor="Red" ErrorMessage="Please enter No of Level"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="row">
                                            <br />
                                        </div>


                                        <table class="table table-nomargin" id="TblLevels" runat="server" border="1" visible="true" style="margin-left: -3%; width: 106%;">
                                            <thead>
                                                <%--<tr>
												<th rowspan="2">Level</th>
												<th rowspan="2">Action/Action Group</th>
												<th colspan="3">Notification</th>
												<th colspan="2">Access</th>
												<th colspan="3">Approval</th>
												<th rowspan="2">Next Level</th>
											</tr>--%>
                                                <tr>
                                                    <th>Level</th>
                                                    <th>Action/Action Group</th>
                                                    <th>Email Notification</th>
                                                    <th>SMS Notification</th>
                                                    <th>App Notification</th>
                                                    <th>Mobile Access</th>
                                                    <th>Web Access</th>
                                                    <th>Approval Rights</th>
                                                    <th>Hold Rights</th>
                                                    <th>Reject Rights</th>
                                                    <th>Next Level</th>

                                                </tr>
                                            </thead>

                                        </table>



                                        <asp:Label ID="lblWorkflowErrorMsg1" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <div class="form-group row" style="margin-bottom: 0;">
                                    <div class="col-lg-6">
                                        <asp:CheckBox ID="chkShowApprovalMatrix_Initiator" CssClass="m-checkbox--success" runat="server" />
                                        <label for="message-text" class="form-control-label" style="text-align: center;">Show Approval Matrix to Initiator</label>
                                    </div>

                                    <div class="col-lg-6">
                                        <asp:CheckBox ID="chkShowApprovalMatrix_Approver" CssClass="m-checkbox--success" runat="server" />
                                        <label for="message-text" class="form-control-label" style="text-align: center;">Show Approval Matrix to Approver</label>
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

                                                <div data-repeater-list="WorkPermitTermCondition" class="col-lg-12" runat="server" id="WorkPermitTermCondition">

                                                    <div data-repeater-item="" class="form-group m-form__group row" runat="server" id="Div2">
                                                        <div class="col-md-9">
                                                            <div class="m-form__group">
                                                                <div class="m-form__control">
                                                                    <asp:TextBox ID="txtTermComdition" runat="server" TextMode="MultiLine" class="form-control m-input autosize_textarea TermCondition_textarea txtvalidate" placeholder="Enter Term & Condition" Rows="1"></asp:TextBox>
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
                                                    <label id="Label2" runat="server" class="col-xl-6 col-lg-3 col-form-label font-weight-bold TermCondition_count" data-count="0">0 Term & Condition(s)</label>
                                                </div>
                                                <span id="error_TermCondition" class="text-danger medium"></span>
                                            </div>

                                        </div>
                                    </div>
                                </div>

                                <br />


                            </div>
                        </div>


                        <asp:Panel runat="server" ID="pnlApprovalMatrix" CssClass="modalPopup" align="center" Style="display: none; width: 100%; top: 0px !important">

                            <div class="" id="add_sub_location" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document" style="max-width: 80%; max-height: 50%;">
                                    <div class="modal-content" style="max-width: 80%; max-height: 50%">
                                        <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
												<ContentTemplate>--%>

                                        <div class="modal-header">
                                            <h3 id="myModalLabel">Associate Information</h3>
                                            <button type="button" id="btnClose2" class="close" data-dismiss="modal" aria-hidden="true">×</button>

                                        </div>
                                        <div class="modal-body" style="max-height: 300px; overflow: scroll;">
                                            <div class="box">
                                                <div class="nav-tabs-custom">
                                                    <ul class="nav nav-tabs nav-fill" role="tablist">
                                                        <li class="nav-item">
                                                            <a class="nav-link active" data-toggle="tab" href="#t1">User Info</a>
                                                        </li>
                                                        <li class="nav-item">
                                                            <a class="nav-link" data-toggle="tab" href="#t2">User Group Info</a>
                                                        </li>

                                                    </ul>
                                                </div>
                                                <div class="box-body">
                                                    <div class="tab-content">
                                                        <div class="tab-pane active" id="t1">

                                                            <%-- <div class="form-group row" style="margin-bottom: 0;">
																	<label for="message-text" class="col-xs-8 col-lg-2 form-control-label" style="text-align: center;">Search :</label>
																	<asp:TextBox ID="txtUserSearch" runat="server" class="form-control" Style="width: 21%;"></asp:TextBox>
																</div>--%>

                                                            <div class="col-md-4">
                                                                <div class="m-input-icon m-input-icon--left">
                                                                    <input type="text" class="form-control m-input" placeholder="Search..." id="generalSearch" />
                                                                    <span class="m-input-icon__icon m-input-icon__icon--left">
                                                                        <span><i class="la la-search"></i></span>
                                                                    </span>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <asp:GridView class="m-datatable" ID="html_table" runat="server" ClientIDMode="Static" CssClass="table table-striped- table-bordered table-hover table-checkable" AutoGenerateColumns="false" SkinID="grdSearch">
                                                                <Columns>
                                                                    <asp:BoundField DataField="User_ID" Visible="false"></asp:BoundField>

                                                                    <asp:TemplateField HeaderText="Action/Info Description" SortExpression="Name">
                                                                        <ItemTemplate>
                                                                            <a style="cursor: pointer; text-decoration: underline;" onclick="FunEditClick('<%# (DataBinder.Eval(Container.DataItem,"User_ID")) %>#0','<%# (DataBinder.Eval(Container.DataItem,"User_Name")) %>')">
                                                                                <%# (DataBinder.Eval(Container.DataItem, "User_Name"))%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="User_Name_Code" SortExpression="User_Name" HeaderText="User_Name"></asp:BoundField>
                                                                </Columns>

                                                                <EmptyDataTemplate>No Records Found !!!</EmptyDataTemplate>
                                                                <EmptyDataRowStyle Height="50%" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Center" />
                                                            </asp:GridView>
                                                        </div>

                                                        <div class="tab-pane" id="t2">
                                                            <asp:GridView ID="grdGroupDesc" AutoGenerateColumns="false" CssClass="table table-striped- table-bordered table-hover table-checkable" runat="server" SkinID="grdSearch">
                                                                <Columns>
                                                                    <asp:BoundField DataField="GroupID" Visible="false"></asp:BoundField>

                                                                    <asp:TemplateField HeaderText="Action/Info Group Description" SortExpression="GroupName">
                                                                        <ItemTemplate>
                                                                            <a style="cursor: pointer; text-decoration: underline;" onclick="FunEditClick('0#<%# (DataBinder.Eval(Container.DataItem,"GroupID")) %>','<%# (DataBinder.Eval(Container.DataItem,"GroupName")) %>')">
                                                                                <%# (DataBinder.Eval(Container.DataItem, "GroupName"))%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="GroupUsers" SortExpression="GroupUsers" HeaderText="Users" ControlStyle-Width="100%"></asp:BoundField>

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
													<asp:AsyncPostBackTrigger ControlID="btnWorkflowMstSave" EventName="Click" />
												</Triggers>--%>
                                        <%--</asp:UpdatePanel>--%>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <%--<cc1:ModalPopupExtender ID="ModalPopupExtender2" ClientIDMode="Static" CancelControlID="btnClose2" runat="server" TargetControlID="pop2" PopupControlID="modal5">
							</cc1:ModalPopupExtender>--%>


                        <cc1:ModalPopupExtender ID="mpeApprovalMatrix" runat="server" PopupControlID="pnlApprovalMatrix" TargetControlID="pop2" ClientIDMode="Static"
                            CancelControlID="btnClose2" BackgroundCssClass="modalBackground">
                        </cc1:ModalPopupExtender>

                        <asp:Button Text="text" Style="display: none;" ID="pop2" runat="server" />

                        <input type="hidden" id="HdnID" runat="server" />
                        <asp:HiddenField ID="hdnWPTerms" ClientIDMode="Static" runat="server" />
                        <asp:HiddenField ID="hdnWPSections" ClientIDMode="Static" runat="server" />
                        <asp:HiddenField ID="hdnWPHeaders" ClientIDMode="Static" runat="server" />
                        <asp:TextBox ID="txtHdn" runat="server" Width="100%" Style="display: none"></asp:TextBox>
                        <%--</form>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
