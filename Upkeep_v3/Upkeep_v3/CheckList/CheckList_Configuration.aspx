<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="CheckList_Configuration.aspx.cs" Inherits="Upkeep_v3.CheckList.CheckList_Configuration" %>

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

        input[type=text].CLGroupName {
            color: #ffffff;
            background-color: transparent;
            border: 0;
        }

            input[type=text].CLGroupName:focus {
                background-color: white;
            }
    </style>

    <script>

        function init_autosize() {
            var autosize_textarea = $('.autosize_textarea');
            autosize(autosize_textarea);
            autosize.update(autosize_textarea);
        }

        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#img')
                        .attr('src', e.target.result)
                        .width('400px')
                        .height('250px');
                };

                reader.readAsDataURL(input.files[0]);
            }
        }

        $(document).ready(function () {

            $('[data-toggle="tooltip"]').tooltip();
            $('.lblAnswerCnt').hide();
            $('.qscore').hide();

            init_autosize();
            init_plugins();

            $('.CheckListGroup_repeater.outer').repeater({

                repeaters: [{
                    // (Required) //CheckListGroup_repeater outer
                    // Specify the jQuery selector for this nested repeater
                    selector: '.CheckListGroup_repeater.outer',

                    initEmpty: true,
                    defaultValues: {
                        'ContentPlaceHolder1_txtCheckListGroup': 'Group',
                        //'this_name': 'foo'
                    },
                    show: function () {
                        $(this).slideDown();
                        var counter = $(this).parent().find('.Group_count');
                        var Group_count = counter.data('count');
                        Group_count++;
                        alert(Group_count);
                        counter.data('count', Group_count).html(Group_count + ' Groupnnn(s)');
                        $('#error_Group_repeater').html('');

                        $('#ChkScoring').change();
                        $('.qscore').change();
                        $('[data-toggle="tooltip"]').tooltip();
                        init_autosize();
                        init_plugins();
                    },
                    hide: function (deleteElement) {
                        $(this).slideUp(deleteElement);
                        var counter = $(this).parents('.CheckListGroup_repeater.outer').find('.Group_count');
                        var Group_count = counter.data('count');
                        Group_count--;
                        counter.data('count', Group_count).html(Group_count + ' Group(s)');
                        $('.qscore').change();
                        if (Group_count == 0) {
                            $('#error_Group_repeater').html('Add at least one Group Type.');
                        }
                    },

                    // (Required)
                    // Specify the jQuery selector for this nested repeater
                    //$('.CheckListGroup_repeater.outer').repeater({

                    //	repeaters: [{

                    //	}]
                    //});
                    selector: '.CheckListQuestion_repeater.inner',
                    initEmpty: false,
                    defaultValues: {
                        'ddlAns': '1',
                        //'this_name': 'foo'
                    },
                    show: function () {
                        $(this).slideDown();

                        //$(this).parents().find('.ddlAns').selectpicker();
                        var txtcounter = $(this).parents('.cntr').find('.txtquestion_count');
                        var counter = $(this).parents('.CheckListQuestion_repeater.inner').find('.question_count');
                        var question_count = counter.data('count');
                        var txtquestion_count = txtcounter.data('count');
                        question_count++;
                        txtquestion_count++;
                        //alert(question_count);
                        counter.data('count', question_count).html(question_count + ' Question(s)');
                        txtcounter.data('count', txtquestion_count).val(txtquestion_count);
                        $('#error_question_repeater').html('');
                        $('#ChkScoring').change();
                        $('.qscore').change();
                        $('[data-toggle="tooltip"]').tooltip();
                        init_autosize();
                        init_plugins();
                    },
                    hide: function (deleteElement) {
                        $(this).slideUp(deleteElement);
                        var counter = $(this).parents('.CheckListQuestion_repeater.inner').find('.question_count');
                        var txtcounter = $(this).parents('.cntr').find('.txtquestion_count');
                        var question_count = counter.data('count');
                        var txtquestion_count = txtcounter.data('count');
                        question_count--;
                        txtquestion_count--;
                        //alert(question_count);
                        $('.qscore').change();
                        counter.data('count', question_count).html(question_count + ' Question(s)');
                        txtcounter.data('count', txtquestion_count).val(txtquestion_count);
                        if (question_count == 0) {
                            $('#error_question_repeater').html('Add at least one Question.');
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
                    //counter.data('count', question_count).html(question_count + ' Question(s)');
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
                    //counter.data('count', question_count).html(question_count + ' Question(s)');
                    //txtcounter.data('count', txtquestion_count).val(txtquestion_count);
                    //if (question_count == 0) {
                    //	$('#error_question_repeater').html('Add at least one Question.');
                    //}
                },
            });

            $('body').on('change', '.CheckListQuestion_repeater .question_textarea', function () {
                var error_ele = $(this).parent().find('.error_question');
                error_ele.html('').parents('.form-group').removeClass('has-error');
                if ($(this).val().trim() == '') {
                    $(this).parent().find('.error_question').html('Enter question.').parents('.form-group').addClass('has-error');
                }
            });

            $('body').on('change', '.CheckListType_repeater .CheckListType_textarea', function () {
                var error_ele = $(this).parent().find('.error_CheckListType');
                error_ele.html('').parents('.form-group').removeClass('has-error');
                if ($(this).val().trim() == '') {
                    $(this).parent().find('.error_CheckListType').html('Enter CheckList Type.').parents('.form-group').addClass('has-error');
                }
            });

            //$('body').on('change', '.TermComdition_repeater .TermCondition_textarea', function () {
            //    var error_ele = $(this).parent().find('.error_TermCondition');
            //    error_ele.html('').parents('.form-group').removeClass('has-error');
            //    if ($(this).val().trim() == '') {
            //        $(this).parent().find('.error_TermCondition').html('Enter Term & Comdition').parents('.form-group').addClass('has-error');
            //    }
            //});

            $('#frmCheckList').submit(function (event) {
                //alert('hiiiii');
                var is_valid = true;

                $('.CheckListQuestion_repeater .question_textarea').each(function (index, element) {
                    if ($(this).val().trim() == '') {
                        is_valid = false;
                        $(this).parent().find('.error_question').html('Enter Question.').parents('.form-group').addClass('has-error');
                    }
                });
                 
                $('.CheckListType_repeater .CheckListType_textarea').each(function (index, element) {
                    if ($(this).val().trim() == '') {
                        is_valid = false;
                        $(this).parent().find('.error_CheckListType').html('Enter Type.').parents('.form-group').addClass('has-error');
                    }
                });

                //$('.TermComdition_repeater .TermCondition_textarea').each(function (index, element) {
                //    if ($(this).val().trim() == '') {
                //        is_valid = false;
                //        $(this).parent().find('.error_TermCondition').html('Enter Term & Condition.').parents('.form-group').addClass('has-error');
                //    }
                //});

                if ($('.CheckListQuestion_repeater .question_textarea').length == 0) {
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

            //var ModalHTML = "";
            var name = "";
            $(document).on('change', '.ddlAns', function () {
                //var ddlansval = $('option:selected', this).attr("data-multi"); 
                //if (ddlansval === "")
                //    return
                ////alert(ddlansval + "===");
                //if (ddlansval == "1") {
                //    $(this).parent().parent().find(".lblAnswerCnt").show();
                //    $('.dltrptanswer').click();
                //    name = $(this).attr("name").replace("ctl00$ContentPlaceHolder1$ddlAns", "hdnRepeaterAnswer");
                //    $(this).parent().parent().find(".hdnRepeaterAnswer").attr('type', 'hidden');
                //    $('#btnModal').click(); 
                //}
                //else { 
                //    $(this).parent().parent().find(".hdnRepeaterAnswer").attr('type', 'text');
                //    $(this).parent().parent().find(".hdnRepeaterAnswer").val(""); 
                //    $(this).parent().parent().find(".lblAnswerCnt").hide();
                //}

                var isMulti = $(this).find(':selected').attr("data-ismulti");
                if (isMulti === "")
                    return

                if (isMulti === 'True') {
                    $(this).parent().parent().find(".lblAnswerCnt").show();

                    $('.dltrptanswer').click();
                    name = $(this).attr("name").replace("ctl00$ContentPlaceHolder1$ddlAns", "hdnRepeaterAnswer");
                    //name = $(this).siblings('.hdnRepeaterAnswer').attr("name");
                    $('#btnModal').click();
                }
                else { 
                    $(this).parent().parent().find(".hdnRepeaterAnswer").val(""); 
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
                if ($('#hdnCLConfigID').val() != "0") {
                    answers = "ii:||;" + $(this).parent().find('.hdnRepeaterAnswer').val();
                }
                var arrAns = answers.split(";");

                for (var i = 0; i < arrAns.length; i++) {
                    //if (arrAns[i] != "ii:||") {
                    $("#divAnswerAdd").click();
                  //  alert(arrAns[i]);
                    //alert(arrAns[i]); AnswerType[0][ctl00$ContentPlaceHolder1$hdnAnswerDataID]
                    var arrIDAns = arrAns[i].split(":");

                    $("input[name~='AnswerType[" + i + "][ctl00$ContentPlaceHolder1$hdnAnswerDataID]']").val(arrIDAns[0]);
                    $("input[name~='AnswerType[" + i + "][txtAnswer]']").val(arrIDAns[1]);
                     

                    //$("input[name~='AnswerType[" + i + "][ctl00$ContentPlaceHolder1$ChkAnsFlag][]']").val(arrIDAns[2]);
                    //$("input[name~='AnswerType[" + i + "][ctl00$ContentPlaceHolder1$ChkAnsDef][]']").val(arrIDAns[3]);
 
                     
                    var isMand = arrIDAns[2];
                    var isAttc = arrIDAns[3];
                    //alert(isMand);
                   // alert(isAttc);
                    if (isMand == "True") { 
                        //alert(":f:");
                       $("input[name~='AnswerType[" + i + "][ctl00$ContentPlaceHolder1$ChkAnsFlag][]']").prop("checked", true);
                       $("input[name~='AnswerType[" + i + "][ctl00$ContentPlaceHolder1$ChkAnsFlag][]']").parent().parent().addClass('active');
                    } 
                    if (isAttc == "True") { 
                       // alert(":oof:");
                        $("input[name~='AnswerType[" + i + "][ctl00$ContentPlaceHolder1$ChkAnsDef][]']").prop( "checked", true );
                        $("input[name~='AnswerType[" + i + "][ctl00$ContentPlaceHolder1$ChkAnsDef][]']").parent().parent().addClass('active');
                    } 

                    //alert(arrIDAns[1]);AnswerType[0][ctl00$ContentPlaceHolder1$ChkAnsDef][]
                    //alert("input[name~='AnswerType[" + i + "][txtAnswer]']");
                    //alert(arrIDAns[1]);
                    //alert($("input[name~='AnswerType[" + i + "][txtAnswer]']").val());
                    //$("#divAnswerAdd").click();
                    //}

                }

                //$('.divTxtAnswer input[type="text"]').each(function () {
                //    // Do your magic here 
                //    //alert($(this).val());
                //    if ($(this).val() === "||") {
                //        alert("jjjj");
                //        alert($(this).siblings('.dltrptanswer').html());
                //        $(this).parent().siblings('.dltrptanswer').click();
                //    }
                //});

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
                $('.divTxtAnswer input:text').each(function () {
                    // Do your magic here 
                    //alert($(this).val());
                    if ($(this).val() === "||") {
                        $(this).parent().siblings('.dltrptanswer').click();
                    }

                    var isChkAnsFlag = 0;
                    var isChkAnsDef = 0;
                    if ($(this).parent().find('#ChkAnsFlag').prop('checked') == true) {
                        //do something
                        isChkAnsFlag = 1;
                    } if ($(this).parent().find('#ChkAnsDef').prop('checked') == true) {
                        //do something
                        isChkAnsDef = 1;
                    }

                    //if (answers == "") {
                    //    answers += $(this).siblings('#hdnAnswerDataID').val() + ":" + $(this).val() + ":" + $(this).parent().find('#ChkAnsFlag').val() + ":" + $(this).parent().find('#ChkAnsDef').val();
                    //}
                    //else {
                    //    answers += ";" + $(this).siblings('#hdnAnswerDataID').val() + ":" + $(this).val() + ":" + $(this).parent().find('#ChkAnsFlag').val() + ":" + $(this).parent().find('#ChkAnsDef').val();;
                    //}

                    if (answers == "") {
                        answers += $(this).siblings('#hdnAnswerDataID').val() + ":" + $(this).val() + ":" + isChkAnsFlag + ":" + isChkAnsDef;
                    }
                    else {
                        answers += ";" + $(this).siblings('#hdnAnswerDataID').val() + ":" + $(this).val() + ":" + isChkAnsFlag + ":" + isChkAnsDef;
                    }

                    cnt++;

                });
                //var name = $("#hdnAns").val();
                $("input[name~='" + name + "']").val(answers);
                $("input[name~='" + name + "']").change();
                //$(".divTxtAnswer").html(ModalHTML);
                $('.dltrptanswer').click();
                alert(answers);
            });

            if ($('#hdnCLConfigID').val() != "0") {
                //$('#AnsModal').modal('show');
                //$('#AnsModal').modal('toggle');
                Bind_CheckListConfiguration($('#hdnCLConfigID').val());
            }

            function Bind_CheckListConfiguration(CLConfigID) {
                //alert(CLConfigID);
                //Bind CL Terms
                $(".dltGroup").click();
                var terms = $('#hdnCLTerms').val();
                var arrTerms = terms.split("~");
                //alert(arrTerms);
                for (var i = 0; i < arrTerms.length; i++) {
                    $("#divTermAdd").click();
                    //alert(arrTerms[i]);

                    var arrIDTerm = arrTerms[i].split("||");
                    $("input[name~='CheckListTermCondition[" + i + "][hdnRepeaterTermID]']").val(arrIDTerm[0]);
                    $("textarea[name~='CheckListTermCondition[" + i + "][ctl00$ContentPlaceHolder1$txtTermComdition]']").val(arrIDTerm[1]);

                    //alert($("input[name~='AnswerType[" + i + "][txtAnswer]']").val()); CheckListTermCondition[0][hdnRepeaterTermID]
                }

                //Bind CL Group
                var Groups = $('#hdnCLGroups').val();
                var arrGroups = Groups.split("~");
                //alert(arrTerms);
                for (var i = 0; i < arrGroups.length; i++) {
                    $("#divGroupAdd").click();
                    //alert(arrTerms[i]);
                    var arrIDGroup = arrGroups[i].split("||");
                    $("input[name~='CheckListGroup[" + i + "][ctl00$ContentPlaceHolder1$hdnCLGroupID]']").parents('.dvCheckListGroup').attr("data-GroupID", arrIDGroup[0]);
                    $("input[name~='CheckListGroup[" + i + "][ctl00$ContentPlaceHolder1$hdnCLGroupID]']").val(arrIDGroup[0]);
                    $("input[name~='CheckListGroup[" + i + "][ctl00$ContentPlaceHolder1$txtCheckListGroup]']").val(arrIDGroup[1]);

                    //alert($("input[name~='AnswerType[" + i + "][txtAnswer]']").val()); CheckListGroup[0][ctl00$ContentPlaceHolder1$txtCheckListGroup]
                }

                //Bind CL Questions with answesrs
                var Questions = $('#hdnCLQuestions').val();
                var arrQuestions = Questions.split("~");
                alert(Questions);
                for (var i = 0; i < arrQuestions.length; i++) {
                    //$("#divGroupAdd").click();
                    //alert(arrTerms[i]);   
                    var arrQuestionData = arrQuestions[i].split("||");
                    var Group = $("div[data-GroupID~='" + arrQuestionData[0] + "']");

                    var chkGrpDa = "";
                    if (i != 0) {
                        var arrRefOldQuestionData = arrQuestions[i - 1].split("||");
                        if (arrQuestionData[0] != arrRefOldQuestionData[0]) {
                            chkGrpDa = "0";
                        }
                    }

                    if (i != 0 && chkGrpDa != "0") {
                        Group.children().find(".divQuestionAdd").click();
                    }

                    Group.children().find(".dvCheckListQuestion").not(".updated").attr("data-QuestionID", arrQuestionData[1]);
                    Group.children().find(".dvCheckListQuestion").addClass("updated");
                    var Question = Group.find("div[data-QuestionID~='" + arrQuestionData[1] + "']");
                    Question.children().find("#hdnCheckListQuestion").val(arrQuestionData[1]);
                    Question.children().find(".question_textarea").val(arrQuestionData[2]);
                    //Group.children().find(".question_textarea").val(arrQuestionData[2]);
                    //alert("FG"); 
                    //alert(arrQuestionData[7]);
                    //alert(arrQuestionData[8]);
                    //alert(arrQuestionData[9]);
                    //alert(Group.children().find("#ddlAns").val());  $('.lblAnswerCnt').hide();
                    //alert(Question.children().find("select").val());


                    //ChkAttach
                    //ChkMandatory 
                    var isMand = arrQuestionData[3];
                    var isAttc = arrQuestionData[4];


                    alert(arrQuestionData[6]);
                    alert(arrQuestionData[7]);

                    Question.children().find(".hdnRefDesc").val(arrQuestionData[6]);
                    Question.children().find(".hdnRefPathUploaded").val(arrQuestionData[7]);

                    //Question.children().find(".hdnflRefImage").val(arrQuestionData[7]);
                    //Question.children().find(".hdnRefPath").val(arrQuestionData[7]);


                    if (isMand == "True") {
                        //do something
                        //alert(":f:");
                        Question.children().find('.ChkMandatory').children().prop("checked", true);
                        Question.children().find('.ChkMandatory').parent().addClass('active');
                    } 
                    if (isAttc == "True") {
                        //do something
                        //alert(":oof:");
                        Question.children().find('.ChkAttach').children().prop( "checked", true );
                        Question.children().find('.ChkAttach').parent().addClass('active');
                    } 

                    Question.children().find("select").val(arrQuestionData[9]);
                    Question.children().find("select").selectpicker('refresh');
                    Question.children().find(".hdnRepeaterAnswer").val(arrQuestionData[10]);
                    Question.children().find(".hdnRepeaterAnswer").change();
                    // if (arrQuestionData[9] == "1" || arrQuestionData[9] == "2")
                    //Option for multi
                    if (arrQuestionData[9] == "1" || arrQuestionData[9] == "2")
                    {
                        Question.children().find(".lblAnswerCnt").show();
                    }
                    //$("input[name~='CheckListGroup[" + i + "][ctl00$ContentPlaceHolder1$hdnCLGroupID]']").parents('.dvCheckListGroup').attr("data-GroupID",arrIDGroup[0]);
                    //$("input[name~='CheckListGroup[" + i + "][ctl00$ContentPlaceHolder1$hdnCLGroupID]']").val(arrIDGroup[0]);
                    //$("input[name~='CheckListGroup[" + i + "][ctl00$ContentPlaceHolder1$txtCheckListGroup]']").val(arrIDGroup[1]);

                    //alert($("input[name~='AnswerType[" + i + "][txtAnswer]']").val()); CheckListGroup[0][ctl00$ContentPlaceHolder1$txtCheckListGroup]
                }

            }


            $(document).on('change', '.qscore', function () {
                var sum = 0;
                $('.qscore').each(function () {
                    if (!isNaN(this.value) && this.value.length != 0) {
                        sum += parseFloat(this.value);
                    }
                });

                $('#ContentPlaceHolder1_txtTotScore').text(sum);
            });

            $(document).on('change', '#ChkScoring', function () {
                if ($(this).prop('checked')) {
                    $('.qscore').show();
                } else {
                    $('.qscore').hide();
                }
            });

            var opener;

            $('#RefModal').on('show.bs.modal', function (e) {
                opener = document.activeElement.name;
                var DescName = opener.replace("btnAddRef", "hdnRefDesc");
                var flName = opener.replace("btnAddRef", "hdnRefPathUploaded");
                if ($('#hdnCLConfigID').val() != "0") {
                    $("#RefModal input").val();
                    $("#RefModal textarea").val($("input[name~='" + DescName + "']").val());
                    $("#RefModal img").attr('src', $("input[name~='" + flName + "']").val())
                        .width('400px')
                        .height('250px');; 

                }
            });

            $('#RefModal button').click(function () {
                var DescName = opener.replace("btnAddRef", "hdnRefDesc");
                var flName = opener.replace("btnAddRef", "hdnflRefImage");
                $("input[name~='" + DescName + "']").val($('#txtRefDesc').val());

                if ($("input[name~='" + flName + "']").length)
                    $("input[name~='" + flName + "']").remove();

                var x = $("#flRefImage"),
                    y = x.clone();
                y.attr("name", opener.replace("btnAddRef", "hdnflRefImage"));
                y.attr("id", opener.replace("btnAddRef", "hdnflRefImage"));
                y.hide();
                y.insertAfter("input[name~='" + DescName + "']");

                $("button[name~='" + opener + "']").removeClass("btn-light").addClass("btn-accent");

                $("#RefModal input").val("");
                $("#RefModal textarea").val("");
                $("#RefModal img").attr('src', '');
                //document.getElementsByName(opener.replace("btnAddRef", "hdnRefDesc"))[0].files = $('#flRefImage').files;
                //$("input[name~='" + opener.replace("btnAddRef", "hdnRefPath") + "']").val($('#flRefImage').val());

            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="">
            <div class="row">
                <div class="col-md-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <%--<form class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmCheckList" method="post">--%>
                        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

                        <div class="m-portlet__head">
                            <div class="m-portlet__head-progress">

                                <!-- here can place a progress bar-->
                            </div>
                            <div class="m-portlet__head-wrapper">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">Check List Configuration
                                        </h3>
                                    </div>
                                </div>

                                <div class="m-portlet__head-tools" style="width: 28%;">
                                    <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-md-3 col-md-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
                                    <a href="<%= Page.ResolveClientUrl("~/CheckList/ChkConfig_Listing.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
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
                                    <label class="col-md-3 form-control-label"><span style="color: red;">*</span>Title :</label>
                                    <div class="col-md-6">
                                        <asp:HiddenField ID="hdnCLConfigID" ClientIDMode="Static" Value="0" runat="server" />
                                        <asp:TextBox ID="txtTitle" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTitle" Visible="true" Display="Dynamic"
                                            ValidationGroup="validateCheckList" ForeColor="Red" ErrorMessage="Please enter Title"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="btn-group btn-group-toggle" data-toggle="buttons">
                                            <label class="btn btn-light">
                                                <asp:CheckBox ID="ChkScoring" autocomplete="off" runat="server" ClientIDMode="Static" /><i class="fa fa-check" aria-hidden="true"></i> Scoring</label>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group m-form__group row" style="padding-left: 1%;">
                                    <label class="col-md-3 form-control-label"><span style="color: red;">*</span>Check List Description :</label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtCLDesc" TextMode="MultiLine" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTitle" Visible="true" Display="Dynamic"
                                            ValidationGroup="validateGatePass" ForeColor="Red" ErrorMessage="Please enter Title"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-3">
                                        <label class="form-control-label text-center qscore">
                                            Total Score:<br />
                                            <span class="text-center text-dark" runat="server" id="txtTotScore">0
                                            </span>
                                        </label>

                                    </div>
                                </div>
                                <div class="CheckListGroup_repeater outer">
                                    <div class="form-group  m-form__group row">

                                        <div data-repeater-list="CheckListGroup" class="outer col-md-12" runat="server" id="CheckListGroup">

                                            <div data-repeater-item="" class="dvCheckListGroup outer form-group m-form__group row" runat="server" id="dvCheckListGroup">
                                                <div class="form-group row w-100" style="background-color: #00c5dc;">

                                                    <label id="lblCheckListGroup" runat="server" class="col-md-3 col-md-3" style="color: #ffffff; margin-top: 1%;">
                                                        <i class="fa fa-edit ml-3" data-toggle="tooltip" data-placement="top"
                                                            title="Edit Group Title">
                                                            <input type="text" value="Check List Group" class="txtvalidate" placeholder="Check List Group" id="txtCheckListGroup" style="color: #ffffff; background-color: transparent; border: 0;" runat="server" />
                                                            <asp:HiddenField ID="hdnCLGroupID" Value="0" ClientIDMode="Static" runat="server" />
                                                        </i>

                                                    </label>

                                                    <%--<asp:TextBox ID="txtCount" runat="server" ></asp:TextBox>--%>
                                                    <div data-repeater-delete="" class="dltGroup outer col-md-1 col-md-1 offset-8 btn btn-danger m-btn m-btn--icon m-btn--icon-only"
                                                        style="border-color: transparent; background-color: transparent; color: red; height: auto;">
                                                        <i class="fa fa-trash"></i>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="col-md-12">
                                                    <div class="m-form__Group cntr">
                                                        <input type="hidden" id="txtCount" data-count="1" value="1" class="txtquestion_count" runat="server" />
                                                        <div class="CheckListQuestion_repeater inner">
                                                            <div class="form-group  m-form__group row">
                                                                <div class="col-md-2">

                                                                    <div data-repeater-create="" class="divQuestionAdd inner btn btn-accent s-btn s-btn--icon s-btn--pill s-btn--wide">
                                                                        <span>
                                                                            <i class="la la-plus"></i>
                                                                        </span>
                                                                    </div>
                                                                    <label id="lblQuestionCount" runat="server" class="col-form-label font-weight-bold question_count" data-count="1">1 Question(s)</label>
                                                                </div>
                                                                <div class="col-md-10">

                                                                    <div data-repeater-list="CheckListQuestion" class="inner col-md-12" runat="server" id="CheckListQuestion">

                                                                        <div data-repeater-item="" class="border border-top-0 border-left-0 border-info rounded dvCheckListQuestion inner form-group m-form__group row" runat="server" id="dvCheckListQuestion">
                                                                            <div class="row w-100">
                                                                                <div class="col-md-6">
                                                                                    <div class="m-form__group">
                                                                                        <div class="m-form__control">
                                                                                            <asp:HiddenField ID="hdnCheckListQuestion" Value="0" ClientIDMode="Static" runat="server" />
                                                                                            <asp:TextBox ID="txtCheckListQuestion" runat="server" class="form-control m-input autosize_textarea question_textarea txtvalidate" placeholder="Enter CheckList Question" Rows="1"></asp:TextBox>

                                                                                            <span class="error_question text-danger medium"></span>

                                                                                        </div>
                                                                                    </div>
                                                                                    <%--<div class="d-md-none m--margin-bottom-10"></div>--%>
                                                                                    <div class="row mt-3">
                                                                                        <div class="col-md-6">
                                                                                            <div class="btn-group btn-group-toggle" data-toggle="buttons">
                                                                                                <label class="btn btn-light">
                                                                                                    <asp:CheckBox ID="ChkMandatory" class="ChkMandatory" autocomplete="off" runat="server" ClientIDMode="Static" /><i class="fa fa-check" aria-hidden="true"></i>Mandatory</label>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-md-6">
                                                                                            <div class="btn-group btn-group-toggle" data-toggle="buttons">
                                                                                                <label class="btn btn-light">
                                                                                                    <asp:CheckBox ID="ChkAttach" class="ChkAttach" autocomplete="off" runat="server" ClientIDMode="Static" /><i class="fa fa-check" aria-hidden="true"></i>Attachment</label>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
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
                                                                                    <%--<div class="d-md-none m--margin-bottom-10"></div>--%>
                                                                                </div>
                                                                                <div class="col-md-2">
                                                                                    <input type="hidden" name="hdnRefDesc" id="hdnRefDesc" class="hdnRefDesc"/>
                                                                                    <input type="hidden" name="hdnRefPathUploaded" id="hdnRefPathUploaded" class="hdnRefPathUploaded" />
                                                                                    <input type="hidden" name="hdnRefDescUpload" id="hdnRefDescUpload" class="hdnRefDescUpload" />
                                                                                    <button type="button" class="btn btn-light" name="btnAddRef" id="btnAddRef" data-toggle="modal" data-target="#RefModal"><i class="fa fa-image"></i>Reference</button>
                                                                                    <asp:TextBox ID="txtScore" TextMode="Number" runat="server" data-toggle="tooltip" data-placement="right"
                                                                                        title="Question wise score.." class="form-control m-input autosize_textarea qscore txtvalidate mt-3" placeholder="Score"></asp:TextBox>

                                                                                </div>
                                                                                <div class="col-md-1">
                                                                                    <div data-repeater-delete="" class="inner btn btn-danger m-btn m-btn--icon m-btn--icon-only">
                                                                                        <i class="la la-trash"></i>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="m-form__group form-group row">
                                                                <div class="col-md-4">
                                                                </div>
                                                                <div class="col-md-8">
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
                                        <div class="col-md-4">
                                            <div data-repeater-create="" id="divGroupAdd" class="outer btn btn-accent m-btn m-btn--icon m-btn--pill m-btn--wide">
                                                <span>
                                                    <i class="la la-plus"></i>
                                                    <span>Add Group</span>
                                                </span>
                                            </div>
                                        </div>
                                        <div class="col-md-8">
                                            <label id="lblGroupCount" runat="server" style="display: none" class="col-md-3 col-md-3 col-form-label font-weight-bold Group_count" data-count="1">1 Group(s)</label>
                                        </div>
                                        <span id="error_Group_repeater" class="text-danger medium"></span>
                                    </div>
                                </div>

                            </div>
                        </div>



                        <div class="modal fade" id="RefModal" role="dialog">
                            <div class="modal-dialog">

                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h4 class="modal-title">Add Refernce</h4>
                                        <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                                    </div>
                                    <div class="modal-body">
                                        <%--<input type="text" id="hdnAns" />--%>
                                        <div class="form-group">
                                            <label for="txtRefDesc">Description</label><br />
                                            <textarea id="txtRefDesc" class="form-control" cols="50" rows="2"></textarea>
                                        </div>
                                        <div class="form-group">
                                            <label for="flRefImage">Ref. Image</label><br />

                                            <input id="flRefImage" class="form-control" clientidmode="static" runat="server" onchange="readURL(this);" type="file" />
                                        </div>
                                        <div class="form-group">
                                            <img alt="" id="img" src="" />
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" id="btnModalAddRef" data-dismiss="modal" class="btn btn-info">Add</button>
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
                                                        <label class="btn btn-light">
                                                            <%--<input id="ChkAnsFlag" type="checkbox" />--%>
                                                            <asp:CheckBox ID="ChkAnsFlag" class="ChkAnsFlag" autocomplete="off" runat="server" ClientIDMode="Static" />Flag</label>
                                                    </div>
                                                    <div class="btn-group btn-group-toggle" data-toggle="buttons">
                                                        <label class="btn btn-light">
                                                            <asp:CheckBox ID="ChkAnsDef" class="ChkAnsDef" autocomplete="off" runat="server" ClientIDMode="Static" />Default</label>
                                                    </div>
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
                        <asp:HiddenField ID="hdnCLTerms" ClientIDMode="Static" runat="server" />
                        <asp:HiddenField ID="hdnCLGroups" ClientIDMode="Static" runat="server" />
                        <asp:HiddenField ID="hdnCLQuestions" ClientIDMode="Static" runat="server" />
                        <asp:TextBox ID="txtHdn" runat="server" Width="100%" Style="display: none"></asp:TextBox>
                        <%--</form>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

