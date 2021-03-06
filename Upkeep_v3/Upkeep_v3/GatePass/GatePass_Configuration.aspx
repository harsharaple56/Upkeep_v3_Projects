<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="GatePass_Configuration.aspx.cs" Inherits="Upkeep_v3.GatePass.GatePass_Configuration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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

   
    <script type="text/javascript">
        $(document).ready(function () {
            $('#tbl_GP_Header').DataTable({
                responsive: true,
                pagingType: 'full_numbers',
                'fnDrawCallback': function () {
                    init_plugins();
                }
            });
            $('#tbl_GP_Type').DataTable({
                responsive: true,
                pagingType: 'full_numbers',
                'fnDrawCallback': function () {
                    init_plugins();
                }
            });
            $('#tbl_GP_Document').DataTable({
                responsive: true,
                pagingType: 'full_numbers',
                'fnDrawCallback': function () {
                    init_plugins();
                }
            });
            $('#tbl_GP_Terms').DataTable({
                responsive: true,
                pagingType: 'full_numbers',
                'fnDrawCallback': function () {
                    init_plugins();
                }
            });
        });
    </script>

    <script>
        function init_autosize() {
            var autosize_textarea = $('.autosize_textarea');
            autosize(autosize_textarea);
            autosize.update(autosize_textarea);
        }

        $(document).ready(function () {

            init_autosize();
            init_plugins();

            $('.GatepassHeader_repeater').repeater({
                initEmpty: true,
                show: function () {
                    $(this).slideDown();
                    var counter = $(this).parents('.GatepassHeader_repeater').find('.question_count');
                    var question_count = counter.data('count');
                    question_count++;
                    counter.data('count', question_count).html(question_count + ' Header(s)');
                    $('#error_question_repeater').html('');

                    init_autosize();
                    init_plugins();
                },
                hide: function (deleteElement) {
                    $(this).slideUp(deleteElement);
                    var counter = $(this).parents('.GatepassHeader_repeater').find('.question_count');
                    var question_count = counter.data('count');
                    question_count--;
                    counter.data('count', question_count).html(question_count + ' Header(s)');
                    if (question_count == 0) {
                        $('#error_question_repeater').html('Add at least one Header.');
                    }
                },
            });

            $('.GatepassType_repeater').repeater({
                initEmpty: true,
                show: function () {
                    $(this).slideDown();
                    var counter = $(this).parents('.GatepassType_repeater').find('.GatepassType_count');
                    var question_count = counter.data('count');
                    question_count++;
                    counter.data('count', question_count).html(question_count + ' GatePass Type(s)');
                    $('#error_GatepassType').html('');

                    init_autosize();
                    init_plugins();
                },
                hide: function (deleteElement) {
                    $(this).slideUp(deleteElement);
                    var counter = $(this).parents('.GatepassType_repeater').find('.GatepassType_count');
                    var question_count = counter.data('count');
                    question_count--;
                    counter.data('count', question_count).html(question_count + ' GatePass Type(s)');
                    if (question_count == 0) {
                        $('#error_GatepassType').html('Add at least one GatePass Type.');
                    }
                },
            });

            //Gate Pass Document Section Added By Suju 13-July-2020

            $('.GatepassDoc_repeater').repeater({
                initEmpty: true,
                show: function () {
                    $(this).slideDown();
                    var counter = $(this).parents('.GatepassDoc_repeater').find('.GatepassDoc_count');
                    var question_count = counter.data('count');
                    question_count++;
                    counter.data('count', question_count).html(question_count + ' Document Header(s)');
                    $('#error_GatepassDoc').html('');

                    init_autosize();
                    init_plugins();
                },
                hide: function (deleteElement) {
                    $(this).slideUp(deleteElement);
                    var counter = $(this).parents('.GatepassDoc_repeater').find('.GatepassDoc_count');
                    var question_count = counter.data('count');
                    question_count--;
                    counter.data('count', question_count).html(question_count + ' Document Header(s)');
                    if (question_count == 0) {
                        $('#error_GatepassDoc').html('Add at least one GatePass Document header.');
                    }
                },
            });
            //End Gate Pass Document Section

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


            $('body').on('change', '.GatepassHeader_repeater .question_textarea', function () {
                var error_ele = $(this).parent().find('.error_question');
                error_ele.html('').parents('.form-group').removeClass('has-error');
                if ($(this).val().trim() == '') {
                    $(this).parent().find('.error_question').html('Enter question.').parents('.form-group').addClass('has-error');
                }
            });



            $('body').on('change', '.GatepassType_repeater .GatepassType_textarea', function () {
                var error_ele = $(this).parent().find('.error_GatepassType');
                error_ele.html('').parents('.form-group').removeClass('has-error');
                if ($(this).val().trim() == '') {
                    $(this).parent().find('.error_GatepassType').html('Enter GatePass Type.').parents('.form-group').addClass('has-error');
                }
            });

            $('body').on('change', '.TermComdition_repeater .TermCondition_textarea', function () {
                var error_ele = $(this).parent().find('.error_TermCondition');
                error_ele.html('').parents('.form-group').removeClass('has-error');
                if ($(this).val().trim() == '') {
                    $(this).parent().find('.error_TermCondition').html('Enter Term & Comdition').parents('.form-group').addClass('has-error');
                }
            });


        });
    </script>


    <script type="text/javascript">
        var txtControl = null;
        var txtHdn = null;
        var txtHdn_Returnable = null;
        function PopUpGrid(obj, objhdn, call_type) {
            $('#hdn_call_type').val(call_type);
            $find('<%= mpeApprovalMatrix.ClientID %>').show();
            if (call_type == 'close')
                txtHdn = objhdn.toString();
            else if (call_type == 'return')
                txtHdn_Returnable = objhdn.toString();
            if (call_type == 'close' && obj.length == undefined)
                txtControl = obj;
            if (call_type == 'close' && obj.length > 0)
                txtControl = obj[0];
            if (call_type == 'return' && obj.length > 0)
                txtControl = obj[1];
            if (call_type == 'return' && obj.length == undefined)
                txtControl = obj;

        }


        function FunEditClick(ID, Desc) {
            txtControl.value = Desc;

            if ($('#hdn_call_type').val() == 'close') {
                if (txtHdn == "") {
                    document.getElementById('txtGPClosure').value = Desc;
                    $('#hdnGPClosureBy').val(ID);
                }
                else {
                    document.getElementById('ContentPlaceHolder1_' + txtHdn).value = ID;
                }
            }
            else if ($('#hdn_call_type').val() == 'return') {
                if (txtHdn_Returnable == "") {
                    document.getElementById('txtGPReceivedBy').value = Desc;
                    $('#hdnGPReceivedBy').val(ID);
                }
                else {
                    document.getElementById('ContentPlaceHolder1_' + txtHdn_Returnable).value = ID;
                }
            }


            $find('<%= mpeApprovalMatrix.ClientID %>').hide();
            //window.close();

        }

        function removeRows() {
            $("#ctl00_cntPlaceHolder_TblLevels").find("tr:gt(0)").remove();
        }

        function removeRowsReturnable() {
            $("#ctl00_cntPlaceHolder_TblLevels_Returnable").find("tr:gt(0)").remove();
        }

        function FunSetXML() {
            window.document.getElementById("<%= txtHdn.ClientID%>").value = "";
            var VarLocTab = window.document.getElementById("<%=TblLevels.ClientID%>");
            for (var i = 1; i <= VarLocTab.rows.length - 1; i++) {
                var VarLocRowObj = VarLocTab.rows[i].id;
                var lvl = window.document.getElementById(VarLocRowObj).children[0].innerHTML;
                if ((window.document.getElementById(VarLocRowObj).children[1].children[2].value) == "") {
                    alert('Action Details Should not be blank');
                    return false;
                }
                else {
                    var action = window.document.getElementById(VarLocRowObj).children[1].children[2].value;
                }

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
                    window.document.getElementById("<%= txtHdn.ClientID%>").value += strInfo + ",";
                }
                else {
                    window.document.getElementById("<%= txtHdn.ClientID%>").value += strInfo + ",";
                }
            }

            if ($("[id*=chk_returnable_gatepass]").prop('checked') == true) {
                window.document.getElementById("<%= txtHdn_Returnable.ClientID%>").value = "";
                var VarLocTab1 = window.document.getElementById("<%=TblLevels_Returnable.ClientID%>");
                for (var i = 1; i <= VarLocTab1.rows.length - 1; i++) {
                    var VarLocRowObj1 = VarLocTab1.rows[i].id;
                    var lvl = window.document.getElementById(VarLocRowObj1).children[0].innerHTML;
                    if ((window.document.getElementById(VarLocRowObj1).children[1].children[2].value) == "") {
                        alert('Action Details Should not be blank');
                        return false;
                    }
                    else {
                        var action = window.document.getElementById(VarLocRowObj).children[1].children[2].value;
                    }


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


                    if (window.document.getElementById("<%= txtHdn_Returnable.ClientID%>").value == "") {
                        window.document.getElementById("<%= txtHdn_Returnable.ClientID%>").value += strInfo + ",";
                    }
                    else {
                        window.document.getElementById("<%= txtHdn_Returnable.ClientID%>").value += strInfo + ",";
                    }
                }

            }

            return true;
        }

    </script>
    <script>
        $(document).ready(function () {
            if ($("[id*=chk_returnable_gatepass]").prop('checked') == true) {
                $("[id*=dvReturnable]").show();
            } else {
                $("[id*=dvReturnable]").hide();
            }

            $("[id*=chk_returnable_gatepass]").change(function () {
                if ($("[id*=chk_returnable_gatepass]").prop('checked') == true) {
                    $("[id*=dvReturnable]").show();
                } else {
                    $("[id*=dvReturnable]").hide();
                }
            });
        });

    </script>

    <script>
        $(document).ready(function () {
            if ($('#hdnGPConfigID').val() != "0") {
                Bind_GatePassConfiguration($('#hdnGPConfigID').val());
            }

            function Bind_GatePassConfiguration(WPConfigID) {

                //Gate Pass Type
                var GPTypes = $('#hdnGPTypeValues').val();
                var arrGPT = GPTypes.split("~");
                for (var i = 0; i < arrGPT.length; i++) {
                    $("#GPT_Repeater_Create").click();
                    var arrIDGPT = arrGPT[i].split("||");
                    $("input[name~='GatepassType[" + i + "][hdnRepeaterGPTID]']").val(arrIDGPT[0]);
                    $("textarea[name~='GatepassType[" + i + "][ctl00$ContentPlaceHolder1$txtGatepassType]']").val(arrIDGPT[1]);
                }

                //Gate Pass Document
                var GPDocs = $('#hdnGPDocumentValues').val();
                var arrGPDoc = GPDocs.split("~");
                for (var i = 0; i < arrGPDoc.length; i++) {
                    var header = $(".dvGatePassDoc");
                    $("#GPDocs_Repeater_Create").click();
                    var arrIDDocs = arrGPDoc[i].split("||");
                    $("input[name~='GatepassDoc[" + i + "][hdnRepeaterGPDocID]']").val(arrIDDocs[0]);
                    $("textarea[name~='GatepassDoc[" + i + "][ctl00$ContentPlaceHolder1$txtGPDoc]']").val(arrIDDocs[1]);

                    var IsMandatory = arrIDDocs[2];
                    if (IsMandatory == "True") {
                        header.children().find("#chkDocMandatory").prop('checked', true);
                    }
                }

                //Terms and Condiition 
                var terms = $('#hdnGPTermsValues').val();
                var arrTerms = terms.split("~");
                for (var i = 0; i < arrTerms.length; i++) {
                    $("#divTermAdd").click();
                    var arrIDTerm = arrTerms[i].split("||");
                    $("input[name~='GatepassTermCondition[" + i + "][hdnRepeaterTermID]']").val(arrIDTerm[0]);
                    $("textarea[name~='GatepassTermCondition[" + i + "][ctl00$ContentPlaceHolder1$txtTermComdition]']").val(arrIDTerm[1]);
                }


                //Bind GP Headers with answesrs
                var headers = $('#hdnGPHeaderValues').val();
                var arrHeaders = headers.split("~");
                for (var i = 0; i < arrHeaders.length; i++) {
                    $("#divHeaderAdd").click();
                    var arrHeaderData = arrHeaders[i].split("||");
                    $("input[name~='GatepassHeader[" + i + "][hdntxtGatepassHeader]']").val(arrHeaderData[0]);
                    $("input[name~='GatepassHeader[" + i + "][ctl00$ContentPlaceHolder1$txtGatepassHeader]']").val(arrHeaderData[1]);
                    var headerList = $(".dvGatepassHeader");
                    headerList.not(".updated").attr("data-HeaderID", arrHeaderData[0]);
                    headerList.addClass("updated");
                    var headerData = $("[data-headerid='" + arrHeaderData[0] + "']");
                    var IsMandatory = arrHeaderData[2];
                    if (IsMandatory == "Yes") {
                        headerData.children().find("#ChkNumeric").prop('checked', true);
                    }
                    headerData.children().find("select").val(arrHeaderData[3]);

                }
            }
        });
    </script>

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <%--<form class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmGatePass" method="post">--%>
                        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
                        <asp:HiddenField runat="server" ID="hdnGPTypeID" ClientIDMode="Static" />
                        <asp:HiddenField runat="server" ID="hdnGPDocID" ClientIDMode="Static" />
                        <asp:HiddenField runat="server" ID="hdnGPHeaderValues" ClientIDMode="Static" />
                        <asp:HiddenField runat="server" ID="hdnGPTypeValues" ClientIDMode="Static" />
                        <asp:HiddenField runat="server" ID="hdnGPDocumentValues" ClientIDMode="Static" />
                        <asp:HiddenField runat="server" ID="hdnGPTermsValues" ClientIDMode="Static" />
                        <asp:HiddenField runat="server" ID="hdnGPConfigID" ClientIDMode="Static" />



                        <div class="m-portlet__head">
                            <div class="m-portlet__head-progress">

                                <!-- here can place a progress bar-->
                            </div>
                            <div class="m-portlet__head-wrapper">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">Gate Pass Configuration
                                        </h3>
                                    </div>
                                </div>

                                <div class="m-portlet__head-tools" style="width: 28%;">
                                    <%--<asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>--%>
                                    <a href="<%= Page.ResolveClientUrl("~/GatePass/GatePassConfig_Listing.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                        <span>
                                            <i class="la la-arrow-left"></i>
                                            <span>Back</span>
                                        </span>
                                    </a>
                                    <div class="btn-group">

                                        <asp:Button ID="btnSave" runat="server" ClientIDMode="Static" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" CausesValidation="true" ValidationGroup="validateGatePass" OnClientClick="return FunSetXML();" OnClick="btnSave_Click" Text="Save" />

                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="m-portlet__body" style="padding: 0.4rem 2.2rem;">

                            <div class="m-portlet__body" style="padding: 0.3rem 2.2rem;">
                                <div class="form-group m-form__group row" style="padding-left: 1%;">
                                    <label class="col-xl-3 col-lg-2 form-control-label"><span style="color: red;">*</span>Title :</label>
                                    <div class="col-xl-4 col-lg-4">
                                        <asp:TextBox ID="txtTitle" runat="server" class="form-control" ClientIDMode="Static"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTitle" Visible="true" Display="Dynamic"
                                                ValidationGroup="validateGatePass" ForeColor="Red" ErrorMessage="Please enter Title"></asp:RequiredFieldValidator>--%>
                                        <span class="error_title text-danger medium"></span>
                                    </div>

                                </div>

                                <%--<div class="form-group m-form__group row" style="padding-left: 1%; display:none;">
                                    <label class="col-xl-3 col-lg-2 col-form-label"><span style="color: red;">*</span> Company :</label>
                                    <div class="col-xl-4 col-lg-4">
                                        <asp:DropDownList ID="ddlCompany" class="form-control m-input" runat="server"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCompany" Visible="true" Display="Dynamic"
                                            ValidationGroup="validateGatePass" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Company"></asp:RequiredFieldValidator>
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
                                                <asp:RadioButton ID="rdbRetailer" runat="server" GroupName="Initiator" />
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
                                    <label class="col-xl-3 col-lg-2 form-control-label"><span style="color: red;">*</span>Gate Pass Transaction Prefix :</label>
                                    <div class="col-xl-4 col-lg-4">
                                        <asp:TextBox ID="txtGPPrefix" runat="server" ClientIDMode="Static" class="form-control"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTitle" Visible="true" Display="Dynamic"
                                                ValidationGroup="validateGatePass" ForeColor="Red" ErrorMessage="Please enter Title"></asp:RequiredFieldValidator>--%>
                                        <span class="error_Prefix text-danger medium"></span>
                                    </div>

                                    <div class="col-xl-4 col-lg-5" id="Div1" runat="server">
                                        <asp:CheckBox ID="chk_returnable_gatepass" CssClass="m-checkbox--success" runat="server" />
                                        <label class="col-xl-10 col-lg-10 col-form-label m-checkbox--success">Returnable Gatepass</label>
                                    </div>
                                </div>

                                <div class="form-group m-form__group row" style="padding-left: 1%;">
                                    <label class="col-xl-3 col-lg-2 form-control-label"><span style="color: red;">*</span>Gatepass Description:</label>
                                    <div class="col-xl-4 col-lg-4">
                                        <%-- <div class="m-form__group">
                                            <div class="m-form__control">--%>
                                        <asp:TextBox ID="txtGatepassDescription" runat="server" TextMode="MultiLine" class="form-control m-input autosize_textarea" ClientIDMode="Static" placeholder="Enter Gatepass Description"></asp:TextBox>
                                        <%--  </div>
                                        </div>--%>
                                    </div>
                                </div>

                                <br />

                                <div class="form-group row" style="background-color: #00c5dc;">
                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Gate Pass Headers</label>
                                </div>
                                <br />

                                <div class="col-xl-12" id="dv_GP_Header" runat="server">
                                    <div class="m-form__section">
                                        <div class="GatepassHeader_repeater">
                                            <div class="form-group  m-form__group row">

                                                <div data-repeater-list="GatepassHeader" class="col-lg-12" runat="server" id="GatepassHeader">

                                                    <div data-repeater-item="" class="dvGatepassHeader form-group m-form__group row" runat="server" id="dvGatepassHeader">
                                                        <div class="col-md-5">
                                                            <div class="m-form__group">
                                                                <div class="m-form__control">
                                                                    <asp:TextBox ID="txtGatepassHeader" runat="server" class="form-control m-input autosize_textarea question_textarea" placeholder="Enter Gatepass Header" Rows="1"></asp:TextBox>
                                                                    <input type="hidden" name="hdntxtGatepassHeader" id="hdntxtGatepassHeader" />
                                                                    <span class="error_question text-danger medium"></span>
                                                                </div>
                                                            </div>
                                                            <div class="d-md-none m--margin-bottom-10"></div>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <div class="m-form__group">
                                                                <div class="m-form__control">
                                                                    <asp:CheckBox ID="ChkNumeric" class="clsMandatory" runat="server" ClientIDMode="Static" />
                                                                    <label class="col-xl-6 col-lg-6 col-form-label">Mandatory</label>

                                                                </div>
                                                            </div>
                                                            <div class="d-md-none m--margin-bottom-10"></div>
                                                        </div>

                                                        <div class="col-md-2" style="padding-left: 1px !important;">
                                                            <div class="m-form__group">
                                                                <div class="m-form__control">
                                                                    <asp:DropDownList ID="ddlUnit" ClientIDMode="Static"
                                                                        class="form-control m-input type_select" placeholder="select" runat="server">
                                                                    </asp:DropDownList>

                                                                    <span class="error_type text-danger medium"></span>
                                                                </div>
                                                            </div>
                                                            <div class="d-md-none m--margin-bottom-10"></div>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <div class="m-form__group">
                                                                <div class="m-form__control">
                                                                    <asp:CheckBox ID="chk_is_quantity" runat="server" ClientIDMode="Static" />
                                                                    <label class="col-xl-10 col-lg-5 col-form-label">Is Quantity</label>

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
                                                    <div data-repeater-create="" id="divHeaderAdd" class="btn btn-accent m-btn m-btn--icon m-btn--pill m-btn--wide">
                                                        <span>
                                                            <i class="la la-plus"></i>
                                                            <span>Add Header</span>
                                                        </span>
                                                    </div>
                                                </div>
                                                <div class="col-lg-8">
                                                    <label id="lblHeaderCount" runat="server" class="col-xl-3 col-lg-3 col-form-label font-weight-bold question_count" data-count="0">0 Header(s)</label>
                                                </div>
                                                <span id="error_question_repeater" class="text-danger medium"></span>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <br />

                                <div class="form-group row" style="background-color: #00c5dc;">
                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Gate Pass Type</label>
                                </div>
                                <br />

                                <div class="col-xl-12" id="dv_GP_Type" runat="server">
                                    <div class="m-form__section">
                                        <div class="GatepassType_repeater">
                                            <div class="form-group  m-form__group row">

                                                <div data-repeater-list="GatepassType" class="col-lg-12" runat="server" id="GatepassType">

                                                    <div data-repeater-item="" class="form-group m-form__group row" runat="server" id="dvGatepassType">
                                                        <div class="col-md-11">
                                                            <div class="m-form__group">
                                                                <div class="m-form__control">
                                                                    <asp:TextBox ID="txtGatepassType" runat="server" TextMode="MultiLine" class="form-control m-input autosize_textarea GatepassType_textarea" placeholder="Enter Gatepass Type" Rows="1"></asp:TextBox>
                                                                    <input type="hidden" name="hdnRepeaterGPTID" id="hdnRepeaterGPTID" />
                                                                    <span class="error_GatepassType text-danger medium"></span>
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
                                                    <div data-repeater-create="" id="GPT_Repeater_Create" class="btn btn-accent m-btn m-btn--icon m-btn--pill m-btn--wide">
                                                        <span>
                                                            <i class="la la-plus"></i>
                                                            <span>Add GatePass Type</span>
                                                        </span>
                                                    </div>
                                                </div>
                                                <div class="col-lg-8">
                                                    <label id="Label1" runat="server" class="col-xl-6 col-lg-3 col-form-label font-weight-bold GatepassType_count" data-count="0">0 GatePass Type(s)</label>
                                                </div>
                                                <span id="error_GatepassType" class="text-danger medium"></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- Document section added by Suju 13-July-2020 --%>

                                <br />

                                <div class="form-group row" style="background-color: #00c5dc;">
                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Gate Pass Document</label>
                                </div>
                                <br />

                                <div class="col-xl-12" id="dv_Doc_Grid" runat="server">
                                    <div class="m-form__section">
                                        <div class="GatepassDoc_repeater">
                                            <div class="form-group  m-form__group row">

                                                <div data-repeater-list="GatepassDoc" class="col-lg-12" runat="server" id="GatePassDoc">

                                                    <div data-repeater-item="" class="dvGatePassDoc form-group m-form__group row" runat="server" id="dvGatePassDoc">
                                                        <div class="col-md-9">
                                                            <div class="m-form__group">
                                                                <div class="m-form__control">
                                                                    <asp:TextBox ID="txtGPDoc" runat="server" TextMode="MultiLine" class="form-control m-input autosize_textarea GatepassDoc_textarea" placeholder="Enter Document Description" Rows="1"></asp:TextBox>
                                                                    <input type="hidden" name="hdnRepeaterGPDocID" id="hdnRepeaterGPDocID" />
                                                                    <span class="error_GatepassDoc text-danger medium"></span>
                                                                </div>
                                                            </div>
                                                            <div class="d-md-none m--margin-bottom-10"></div>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <div class="m-form__group">
                                                                <div class="m-form__control">
                                                                    <asp:CheckBox ID="chkDocMandatory" runat="server" ClientIDMode="Static" />
                                                                    <label class="col-xl-6 col-lg-6 col-form-label">Mandatory</label>

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
                                                    <div data-repeater-create="" id="GPDocs_Repeater_Create" class="btn btn-accent m-btn m-btn--icon m-btn--pill m-btn--wide">
                                                        <span>
                                                            <i class="la la-plus"></i>
                                                            <span>Add Document Header</span>
                                                        </span>
                                                    </div>
                                                </div>
                                                <div class="col-lg-8">
                                                    <label id="Label3" runat="server" class="col-xl-6 col-lg-3 col-form-label font-weight-bold GatepassDoc_count" data-count="0">0 Document Header(s)</label>
                                                </div>
                                                <span id="error_GatepassDoc" class="text-danger medium"></span>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <%-- End Document Section --%>
                                <br />
                                <div class="form-group row" style="background-color: #00c5dc;">
                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Approval Matrix</label>
                                </div>
                                <br />



                                <div class="form-group row" style="margin-bottom: 0;">
                                    <label for="message-text" class="col-xs-8 col-lg-2 form-control-label" style="text-align: center;">No Of Levels :</label>
                                    <asp:TextBox ID="txtNoOfLevel" runat="server" class="form-control" Style="width: 21%;"></asp:TextBox>

                                    <asp:Button ID="btnMakeCombination" runat="server" class="m-badge m-badge--brand m-badge--wide" Style="margin-left: 5%; cursor: pointer;" OnClick="btnMakeCombination_Click" Text="Make Combination" ValidationGroup="validationApprovalMatrx" />

                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNoOfLevel" Visible="true"
                                                    Style="margin-left: 1%; margin-top: 1%;" ValidationGroup="validationApprovalMatrx" ForeColor="Red" ErrorMessage="Please enter No of Level"></asp:RequiredFieldValidator>--%>

                                    <label for="message-text" class="col-xs-8 col-lg-4 form-control-label" style="text-align: center;">Show Approval Matrix to Initiator :</label>
                                    <asp:CheckBox ID="chkShowApprovalMatrix" CssClass="m-checkbox--success" runat="server" />

                                </div>

                                <div class="row">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNoOfLevel" Visible="true"
                                        Style="margin-left: 1%; margin-top: 1%;" ValidationGroup="validationApprovalMatrx" ForeColor="Red" ErrorMessage="Please enter No of Level"></asp:RequiredFieldValidator>
                                    <br />
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>

                                        <table class="table table-striped- table-bordered table-hover table-checkable" id="TblLevels" runat="server" border="1" visible="true" style="margin-left: -3%; width: 106%;">
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
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnMakeCombination" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>


                                <asp:Label ID="lblWorkflowErrorMsg1" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>



                                <div class="form-group m-form__group row" style="padding-left: 1%;">
                                    <label class="col-xl-3 col-lg-2 form-control-label"><span style="color: red;">*</span>Gate Pass Closure By :</label>
                                    <div class="col-xl-4 col-lg-4">
                                        <asp:TextBox ID="txtGPClosure" runat="server" ClientIDMode="Static" class="form-control"></asp:TextBox>
                                        <asp:HiddenField ID="hdnGPClosureBy" runat="server" ClientIDMode="Static" />

                                        <span class="error_GPClosure text-danger medium"></span>
                                    </div>
                                    <div class="col-xl-4 col-lg-4">
                                        <img src="../assets/app/media/img/icons/AddUser.png" width="32" height="32" title="Click here to add user" onclick="PopUpGrid(0,'','close');" />
                                    </div>
                                </div>

                                <%--returnable gatepass matrix--%>
                                <div id="dvReturnable" runat="server">
                                    <div class="form-group m-form__group row" style="padding-left: 1%;">
                                        <label class="col-xl-3 col-lg-2 form-control-label"><span style="color: red;">*</span>Received By User :</label>
                                        <div class="col-xl-4 col-lg-4">
                                            <asp:TextBox ID="txtGPReceivedBy" runat="server" ClientIDMode="Static" class="form-control"></asp:TextBox>
                                            <asp:HiddenField ID="hdnGPReceivedBy" runat="server" ClientIDMode="Static" />

                                            <span class="error_GPClosure text-danger medium"></span>
                                        </div>
                                        <div class="col-xl-4 col-lg-4">
                                            <img src="../assets/app/media/img/icons/AddUser.png" width="32" height="32" title="Click here to add user" onclick="PopUpGrid(0,'','return');" />
                                        </div>
                                    </div>

                                    <br />


                                    <div class="form-group row" style="margin-bottom: 0;">
                                        <label for="message-text" class="col-xs-8 col-lg-2 form-control-label" style="text-align: center;">No Of Levels :</label>
                                        <asp:TextBox ID="txtNoOfLevel_Returnable" runat="server" class="form-control" Style="width: 21%;"></asp:TextBox>

                                        <asp:Button ID="btnMakeCombination_Returnable" runat="server" class="m-badge m-badge--brand m-badge--wide" Style="margin-left: 5%; cursor: pointer;" OnClick="btnMakeCombination_Returnable_Click" Text="Make Combination" ValidationGroup="validationApprovalMatrx_returnable" />

                                    </div>

                                    <div class="row">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNoOfLevel_Returnable" Visible="true" Display="Dynamic"
                                            Style="margin-left: 1%; margin-top: 1%;" ValidationGroup="validationApprovalMatrx_returnable" ForeColor="Red" ErrorMessage="Please enter No of Level"></asp:RequiredFieldValidator>
                                        <br />
                                    </div>

                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <table class="table table-striped- table-bordered table-hover table-checkable" id="TblLevels_Returnable" runat="server" border="1" visible="true" style="margin-left: -3%; width: 106%;">
                                                <thead>

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
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnMakeCombination_Returnable" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>


                                    <asp:Label ID="lblWorkflowErrorMsg_return" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>


                                </div>


                                <br />

                                <div class="form-group row" style="background-color: #00c5dc;">
                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Terms & Condition</label>
                                </div>
                                <br />


                                <div class="col-xl-12" id="dv_Termcondition" runat="server">
                                    <div class="m-form__section">
                                        <div class="TermComdition_repeater">
                                            <div class="form-group  m-form__group row">

                                                <div data-repeater-list="GatepassTermCondition" class="col-lg-12" runat="server" id="GatepassTermCondition">

                                                    <div data-repeater-item="" class="form-group m-form__group row" runat="server" id="Div2">
                                                        <div class="col-md-11">
                                                            <div class="m-form__group">
                                                                <div class="m-form__control">
                                                                    <asp:TextBox ID="txtTermComdition" runat="server" TextMode="MultiLine" class="form-control m-input autosize_textarea TermCondition_textarea" placeholder="Enter Term & Condition" Rows="1"></asp:TextBox>
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
                                                    <div data-repeater-create="" id="divTermAdd" class="btn btn-accent m-btn m-btn--icon m-btn--pill m-btn--wide">
                                                        <span>
                                                            <i class="la la-plus"></i>
                                                            <span>Add Term & Condition</span>
                                                        </span>
                                                    </div>
                                                </div>
                                                <div class="col-lg-8">
                                                    <label id="Label2" runat="server" class="col-xl-6 col-lg-3 col-form-label font-weight-bold TermCondition_count" data-count="0">0 Term & Condition(s)</label>
                                                </div>
                                                <span id="error_TermCondition1" class="text-danger medium"></span>
                                            </div>

                                        </div>
                                    </div>
                                </div>

                                <br />


                                <br />

                                <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>

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
                                                            <asp:HiddenField ID="hdn_call_type" runat="server" ClientIDMode="Static" />
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
                                                                    <asp:BoundField DataField="User_Name" SortExpression="User_Name" HeaderText="User_Name"></asp:BoundField>
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
                                                                    <asp:BoundField DataField="GroupName" SortExpression="GroupName" HeaderText="GroupName" ControlStyle-Width="100%"></asp:BoundField>

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
                        <asp:TextBox ID="txtHdn" runat="server" ClientIDMode="Static" Width="100%" Style="display: none"></asp:TextBox>
                        <asp:TextBox ID="txtHdn_Returnable" runat="server" ClientIDMode="Static" Width="100%" Style="display: none"></asp:TextBox>

                        <%--</form>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
