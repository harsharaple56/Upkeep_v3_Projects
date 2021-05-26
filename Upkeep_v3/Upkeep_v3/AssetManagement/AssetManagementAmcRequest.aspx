﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="AssetManagementAmcRequest.aspx.cs" Inherits="Upkeep_v3.AssetManagement.AssetManagementAmcRequest" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <style type="text/css">
        .modalBackground {
            background-color: grey;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            padding: 10px;
            width: 300px;
        }

        .auto-style1 {
            left: 0px;
            top: 15px;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {
            DatatableHtmlTableDemo.init();
        });

        var DatatableHtmlTableDemo = {
            init: function () {
                var e; e = $(".m-datatable").mDatatable({
                    data: { saveState: { cookie: !1 } },
                    search: { input: $("#generalSearch") },
                    columns: [
                        {
                            //field: "Status", title: "Status", template: function (e) {
                            //    var t =
                            //    {
                            //        "Open": { title: "Open", class: "m-badge--danger" },
                            //        "Close": { title: "Closed", class: " m-badge--success" },
                            //        "Approve": { title: "Approved", class: " m-badge--success" },
                            //        "Hold": { title: "Hold", class: " m-badge--warning" },
                            //        "Reject": { title: "Rejected", class: " m-badge--danger" },
                            //        "Expired": { title: "Expired", class: "bg-secondary text-black" },
                            //        "In Progress": { title: "In Progress", class: "text-white bg-info" }
                            //    }; return '<span class="m-badge ' + t[e.Status].class + ' m-badge--wide">' + t[e.Status].title + "</span>"
                            //}
                        }
                    ]
                }),
                    $("#m_form_status").on("change", function () { e.search($(this).val().toLowerCase(), "Status") }),
                    $("#m_form_status").selectpicker()

            }
        };


    </script>
    <script>

        $(document).ready(function () {

            function openModal() {
                $(".modal-backdrop").remove();
                $("#myModal").modal('show');
            }

            $("#txtamcassigVendor").on('input', function () {
                var val = this.value;
                $('#hfAmcAssignedVendor').val("");
                if ($('#dlamcassigVendor option').filter(function () {
                    if (this.value.toUpperCase() === val.toUpperCase()) {
                        //alert($(this).attr('text'));
                        $('#hfAmcAssignedVendor').val($(this).attr('text'));
                    }
                    return this.value.toUpperCase() === val.toUpperCase();
                }).length) {
                    //send ajax request
                    //alert(this.id);
                }
            });

            $("#txtRenewAmcassigVendor").on('input', function () {
                var val = this.value;
                $('#hfRenewAmcAssignedVendor').val("");
                if ($('#dlRenewAmcassigVendor option').filter(function () {
                    if (this.value.toUpperCase() === val.toUpperCase()) {
                        //alert($(this).attr('text'));
                        $('#hfRenewAmcAssignedVendor').val($(this).attr('text'));
                    }
                    //if ($('#hfRenewAmcAssignedVendor').val() == "" ) {
                    //    alert("Please select Vendor");
                    //}
                    return this.value.toUpperCase() === val.toUpperCase();
                }).length) {
                    //send ajax request
                    //alert(this.id);
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


            $("#ddlAssetVendor").on('input', function () {
                $('#txtamcassigVendor').val($("#ddlAssetVendor option:selected").html());
                $('#hfAmcAssignedVendor').val($("#ddlAssetVendor").val());
            });


            $('.datepicker').datepicker({
                todayHighlight: true,
                autoclose: true,
                pickerPosition: 'bottom-right',
                format: 'dd/M/yyyy', // HH:ii P
                showMeridian: true,
                startDate: moment().format('YYYY-MM-DD'),
            }).on('changeDate', function (event) {
                //var startDate = moment($('#txtWorkPermitDate').val(), 'DD/MMM/YYYY').valueOf();// hh:mm A
                //var endDate   = moment($('#endDate').val(), 'DD/MM/YYYY hh:mm A').valueOf();
                $('#error_endDate').html('').parents('.form-group').removeClass('has-error');
                //if(endDate < startDate)
                //{
                //    $('#error_endDate').html('Event end date-time can not be before the start date.').parents('.form-group').addClass('has-error');
                //}
            });

            $(".customcontrolinput").click(function () {
                if ($(this).attr('id') == 'customCheck') {
                    //alert('FF0');
                    if ($(this).prop("checked") == false) {
                        //alert('FF1');
                        $("div#DivIsAssetCoveredInAmc").hide("slow");
                    }
                    else {
                        //alert('FF2');
                        $("div#DivIsAssetCoveredInAmc").show("slow");
                    }
                }
                else {
                    if ($(this).prop("checked") == false) {
                        $("div#DivIsServiceSchedule").hide("slow");
                    }
                    else {
                        $("div#DivIsServiceSchedule").show("slow");
                    }
                }
            });


            function DivShowHide() {
                if ($("#customCheck").prop("checked") == false) {
                    //alert('FF1');
                    $("div#DivIsAssetCoveredInAmc").hide("slow");
                }
                else {
                    //alert('FF2');
                    $("div#DivIsAssetCoveredInAmc").show("slow");
                }

                if ($("#customCheck1").prop("checked") == false) {
                    $("div#DivIsServiceSchedule").hide("slow");
                }
                else {
                    $("div#DivIsServiceSchedule").show("slow");
                }
            }

            DivShowHide();

            $("#btnAddAssetType").click(function () {
                $("div#divModalAssetType").show();
                $("div#divModalAssetCategory").hide();
                $("div#divModalRenewAmc").hide();
                //   return false;
            });
            $("#btnAddAssetCategory").click(function () {
                $("div#divModalAssetType").hide();
                $("div#divModalAssetCategory").show();
                $("div#divModalRenewAmc").hide();
                // return false;
            });
            $("#btnAddAssetVendor").click(function () {
                $("div#divModalAssetType").hide();
                $("div#divModalAssetCategory").hide();
                $("div#divModalRenewAmc").hide();
                // return false;
            });
            $("#btnAddDepartment").click(function () {
                $("div#divModalAssetType").hide();
                $("div#divModalAssetCategory").hide();
                $("div#divModalRenewAmc").hide();
                // return false;
            });
            $("#btnAddLocation").click(function () {
                $("div#divModalAssetType").hide();
                $("div#divModalAssetCategory").hide();
                $("div#divModalRenewAmc").hide();
                // return false;
            });

            $("#btnRenewAMC").click(function () {
                $("div#divModalAssetType").hide();
                $("div#divModalAssetCategory").hide();
                $("div#divModalRenewAmc").show();
                // return false;
            });

            //$('#myNewModal').bootstrapValidator({

            //    fields: {
            //        txtRenewAmcExclusion: {
            //            validators: {
            //                notEmpty: {
            //                    message: 'The username is required'
            //                }
            //            }
            //        },
            //        txtRenewAmcInclusion: {
            //            validators: {
            //                notEmpty: {
            //                    message: 'The password is required'
            //                }
            //            }
            //        }
            //    }
            //    //rules: {
            //    //    txtRenewAmcExclusion: {
            //    //        required: true
            //    //    },
            //    //    txtRenewAmcInclusion: {
            //    //        required: true
            //    //    },
            //    //    txtRenewAmcassigVendor: {
            //    //        required: true
            //    //    },
            //    //    txtRenewAmcEndDate: {
            //    //        required: true
            //    //    },
            //    //    txtRenewAmcStartDate: {
            //    //        required: true
            //    //    },
            //    //    txtRenewAmcDescription: {
            //    //        required: true
            //    //    },
            //    //    ddlRenewAmcType: {
            //    //        required: true
            //    //    }
            //    //},
            //    //messages: {
            //    //    txtRenewAmcExclusion: "Please enter Exclusion",
            //    //    txtRenewAmcInclusion: "Please enter Inclusion",
            //    //    txtRenewAmcassigVendor: "Please select assign vendor",
            //    //    txtRenewAmcEndDate: "Please select end date",
            //    //    txtRenewAmcStartDate: "Please select start date",
            //    //    txtRenewAmcDescription: "Please enter Description",
            //    //    ddlRenewAmcType: "Please select Type"
            //    //}
            //});


            function ResetModalValues() {
                $('#lblModalAssetErrorMessage').val("");
                $("#lblModalAssetErrorMessage").html('');
                $('#txtModalAssetType').val("");
                $('#txtModalAssetCategory').val("");
                $('#ddlModalAssetType').val("0");
            }
            $('#myModal').on('show.bs.modal', function (event) {
                ResetModalValues();
                var button = $(event.relatedTarget); // Button that triggered the modal 
                var modal = $(this);

                var title = button.data('title');
                modal.find('.modal-title').text(title)

                //alert(button.attr('id'));
                if (button.attr('id') == "btnAddAssetType") {
                    $('#hdAddAsset').val("1");
                }
                else if (button.attr('id') == "btnAddAssetCategory") {
                    $('#hdAddAsset').val("2");
                }
                else if (button.attr('id') == "btnAddAssetVendor") {
                    $('#hdAddAsset').val("3");
                }
                else if (button.attr('id') == "btnAddDepartment") {
                    $('#hdAddAsset').val("4");
                }
                else if (button.attr('id') == "btnAddLocation") {
                    $('#hdAddAsset').val("5");
                }
                else if (button.attr('id') == "btnRenewAMC") {
                    $('#hdAddAsset').val("6");
                }

                //alert($('#hdAddAsset').attr('value')); 
            });


            $('#exampleModal').on('show.bs.modal', function (event) {
                var button = $(event.relatedTarget); // Button that triggered the modal
                var title = button.data('title');// button.data('Ffl'); // Extract info from data-* attributes
                //  var images_list = button.data('images'); // Extract info from data-* attributes
                var images_list = $(button).siblings().val(); // Extract info from data-* attributes

                var modal = $(this);
                modal.find('.modal-title').text(title);
                var images = images_list.split(',')
                modal.find('.modal-body .carousel-inner').html('')

                $.each(images, function (index, image) {

                    //alert(image);
                    //image = "~/WorkPermitImages/19-03-2020/48_63_3_0.jpg";

                    //alert(image);
                    if (title.includes("Image")) {
                        // alert("Image");

                        if (index == 0)
                            var item = '<div class="carousel-item active">';
                        else
                            var item = '<div class="carousel-item">';

                        item += '<img class="d-block w-100" src="' + image + '"></div>'

                        modal.find('.modal-body .carousel-inner').append(item);
                    }
                    if (title.includes("Video")) {
                        // alert("Video");
                    }
                    if (title.includes("Document")) {
                        // alert("Document"); 

                        if (index == 0)
                            var item = '<div class="carousel-item active">';
                        else
                            var item = '<div class="carousel-item">';

                        item += '<p><iframe src="' + image + '" frameborder="0" height="400" width="95%"></iframe></p></div>';

                        modal.find('.modal-body .carousel-inner').append(item);
                    }


                });
                //$('.carousel').carousel();
            })

            $("#Button1").on('click', function (e) {
                e.preventDefault();

                //   alert("ff");



                var value = <%= Session["TransactionID"].ToString() %>;
                if (value != 0) {

                    $('#txtHdn').val("");

                    if ($("#customCheck").is(':checked')) {
                        //$("#btnSaveAmc").click();

                        if ($('#hfAmcAssignedVendor').val() == '') {
                            alert("Please Select Proper AMC Vendor!");
                            return;
                        }
                    }
                } else {
                    if ($("#ddlAssetName").val() === "") {
                        alert("Please Select Asset!");
                        return;
                    }
                }

                // alert($('#ddlAmcType').val());

                if ($('#ddlAmcType').val() == "" || $('#ddlAmcType').val() == null) {
                    alert("Please Select Asset AMC Type!");
                    return;
                }

                $("#btnSave").click();

            });
        });


    </script>

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="">
            <div class="row">

                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <%--<form class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmWorkPermit" method="post">--%>
                        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

                        <asp:HiddenField ID="hdnWpHeaderData" runat="server" ClientIDMode="Static" />
                        <asp:HiddenField ID="hdnWpHeader" runat="server" ClientIDMode="Static" />
                        <p id="info" style="display: none;"></p>
                        <p id="infox" style="display: none;"></p>

                        <div class="m-portlet__head">
                            <div class="m-portlet__head-progress">
                            </div>
                            <div class="m-portlet__head-wrapper">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">Asset AMC Details</h3>
                                    </div>
                                </div>

                                <div class="m-portlet__head-tools" style="width: 28%;">
                                    <a href="<%= Page.ResolveClientUrl("~/AssetManagement/AssetManagementAmcList.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                        <%--<%= Page.ResolveClientUrl( Session["PreviousURL"].ToString()) %>--%>
                                        <span>
                                            <i class="la la-arrow-left"></i>
                                            <span>Back</span>
                                        </span>
                                    </a>
                                    <div class="btn-group">

                                        <asp:Button ID="Button1" TYPE="button" Text="Save" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md"
                                            ClientIDMode="Static" />
                                        <%--OnClientClick="return FunSetXML();" --%>

                                        <asp:Button ID="btnSave" TYPE="button" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" ClientIDMode="Static"
                                            CausesValidation="true" ValidationGroup="validateAssetAMC" Text="Save" OnClick="btnSave_Click" Style="display: none" />
                                        <%--<asp:Button ID="btnSaveAmc" TYPE="button" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" ClientIDMode="Static"
                                            CausesValidation="true" ValidationGroup="validateAssetAMC" Text="SaveAMC" Style="display: none" />--%>

                                        <asp:Button type="Button" ID="btnRenewAMC" runat="server" class="btn btn-accent m-btn m-btn--icon m-btn--wide m-btn--md"
                                            Text="RENEW" data-toggle="modal" data-target="#myModal" ClientIDMode="Static" OnClientClick="return false"
                                            data-title="Add AMC" data-backdrop="static" data-keyboard="false" />

                                        <asp:Button ID="btnTest" Style="display: none;" runat="server" />
                                        <cc1:ModalPopupExtender ID="mpeWpRequestSaveSuccess" runat="server" PopupControlID="pnlWpReqestSuccess" TargetControlID="btnTest"
                                            CancelControlID="btnCloseHeader2" BackgroundCssClass="modalBackground">
                                        </cc1:ModalPopupExtender>
                                    </div>
                                </div>

                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="m-portlet__body" style="padding: 0.3rem 2.2rem; display: none;">
                            <div id="Div3" runat="server" style="display: block;">
                                <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                    <div class="col-xl-12 col-lg-12">
                                        <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlAssetType" EventName="SelectedIndexChanged" />
                                </Triggers>
                                <ContentTemplate>

                                    <div id="dvAssetType" runat="server" style="display: block;">
                                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Asset Type :</label>
                                            <div class="col-xl-3 col-lg-3">
                                                <%--OnSelectedIndexChanged="ddlAssetType_SelectedIndexChanged" --%>
                                                <asp:DropDownList ID="ddlAssetType" class="form-control m-input" runat="server" AutoPostBack="true"
                                                    OnSelectedIndexChanged="ddlAssetType_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlAssetType" Visible="true"
                                                    Display="Dynamic" ValidationGroup="validateAsset" ForeColor="Red" InitialValue="0"
                                                    ErrorMessage="Please select Asset Type"></asp:RequiredFieldValidator>
                                            </div>

                                            <%-- <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;"></span></label>--%>
                                            <div class="col-xl-3 col-lg-3">
                                            </div>
                                        </div>
                                    </div>

                                    <br />
                                    <div id="Div1" runat="server" style="display: block;">
                                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Asset Category :</label>
                                            <div class="col-xl-3 col-lg-3">
                                                <%--OnSelectedIndexChanged="ddlAssetType_SelectedIndexChanged" --%>
                                                <asp:DropDownList ID="ddlAssetCategory" class="form-control m-input" runat="server">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlAssetCategory" Visible="true"
                                                    Display="Dynamic" ValidationGroup="validateAsset" ForeColor="Red" InitialValue="0"
                                                    ErrorMessage="Please select Asset Category"></asp:RequiredFieldValidator>
                                            </div>

                                            <%--<label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;"></span></label>--%>
                                            <div class="col-xl-3 col-lg-3">
                                            </div>
                                        </div>
                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <br />
                            <div id="Div2" runat="server" style="display: block;">
                                <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                    <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Asset Name :</label>
                                    <div class="col-xl-3 col-lg-3">
                                        <asp:TextBox ID="txtAssetName" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAssetName" Visible="true"
                                            Display="Dynamic" ValidationGroup="validateAsset" ForeColor="Red" InitialValue="0"
                                            ErrorMessage="Please enter Asset Name"></asp:RequiredFieldValidator>
                                    </div>

                                    <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Asset Description :</label>
                                    <div class="col-xl-3 col-lg-3">
                                        <asp:TextBox ID="txtAssetDescription" TextMode="MultiLine" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAssetDescription" Visible="true"
                                            Display="Dynamic" ValidationGroup="validateAsset" ForeColor="Red" InitialValue="0"
                                            ErrorMessage="Please enter Asset Description"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <br />
                            <div id="Div4" runat="server" style="display: block;">
                                <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                    <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Asset Maker :</label>
                                    <div class="col-xl-3 col-lg-3">
                                        <asp:TextBox ID="txtAssetMaker" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAssetMaker" Visible="true"
                                            Display="Dynamic" ValidationGroup="validateAsset" ForeColor="Red" InitialValue="0"
                                            ErrorMessage="Please enter Asset Maker"></asp:RequiredFieldValidator>
                                    </div>

                                    <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Asset Serial No :</label>
                                    <div class="col-xl-3 col-lg-3">
                                        <asp:TextBox ID="txtAssetSerialNo" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAssetSerialNo" Visible="true"
                                            Display="Dynamic" ValidationGroup="validateAsset" ForeColor="Red" InitialValue="0"
                                            ErrorMessage="Please enter Asset Serial No"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <br />
                            <div id="Div6" runat="server" style="display: block;">
                                <%-- <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlAssetVendor" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                    <ContentTemplate>--%>
                                <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                    <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Asset Vendor :</label>
                                    <div class="col-xl-3 col-lg-3">

                                        <%--AutoPostBack="true" OnSelectedIndexChanged="ddlAssetVendor_SelectedIndexChanged"--%>
                                        <asp:DropDownList ID="ddlAssetVendor" class="form-control m-input" runat="server"
                                            ClientIDMode="Static" autocomplete="off">
                                        </asp:DropDownList>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlAssetVendor" Visible="true"
                                            Display="Dynamic" ValidationGroup="validateAsset" ForeColor="Red" InitialValue="0"
                                            ErrorMessage="Please select Asset Vendor"></asp:RequiredFieldValidator>


                                    </div>

                                    <%--<label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;"></span></label>--%>
                                    <div class="col-xl-3 col-lg-3" style="display: none">
                                    </div>
                                </div>

                                <%-- </ContentTemplate>
                                                </asp:UpdatePanel>--%>
                            </div>

                            <br />
                            <div id="Div7" runat="server" style="display: block;">
                                <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                    <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Assign Department :</label>
                                    <div class="col-xl-3 col-lg-3">
                                        <%--OnSelectedIndexChanged="ddlAssetType_SelectedIndexChanged" --%>
                                        <asp:DropDownList ID="ddlDepartment" class="form-control m-input" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlDepartment" Visible="true"
                                            Display="Dynamic" ValidationGroup="validateAsset" ForeColor="Red" InitialValue="0"
                                            ErrorMessage="Please select Department"></asp:RequiredFieldValidator>
                                    </div>

                                    <%--<label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;"></span></label>--%>
                                    <div class="col-xl-3 col-lg-3" style="display: none">
                                    </div>
                                </div>
                            </div>

                            <br />
                            <div id="Div8" runat="server" style="display: block;">
                                <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                    <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Assign Location :</label>
                                    <div class="col-xl-3 col-lg-3">
                                        <%--OnSelectedIndexChanged="ddlAssetType_SelectedIndexChanged" --%>
                                        <%--<asp:DropDownList ID="ddlLocation" class="form-control m-input" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlLocation" Visible="true"
                                                            Display="Dynamic" ValidationGroup="validateAsset" ForeColor="Red" InitialValue="0"
                                                            ErrorMessage="Please select Location"></asp:RequiredFieldValidator>--%>

                                        <asp:HiddenField ID="hdnassetLocation" runat="server" ClientIDMode="Static" />

                                        <input list="dlassetLocation" id="txtassetLocation" name="txtassetLocation"
                                            class="form-control" runat="server" clientidmode="Static" />
                                        <datalist id="dlassetLocation" runat="server" clientidmode="Static"></datalist>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtassetLocation"
                                            Visible="true" Display="Dynamic" ValidationGroup="validateAsset" ForeColor="Red" InitialValue="0"
                                            ErrorMessage="Please select Vendor"></asp:RequiredFieldValidator>

                                    </div>
                                    <%--<label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;"></span></label>--%>
                                    <div class="col-xl-3 col-lg-3" style="display: none">
                                    </div>
                                </div>
                            </div>

                            <br />
                            <div id="Div9" runat="server" style="display: block;">
                                <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                    <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Asset Cost :</label>
                                    <div class="col-xl-3 col-lg-3">
                                        <%--<asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>--%>
                                        <input type="number" min="0" name="divNumberName" id="txtAssetCost" class="form-control" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtAssetCost" Visible="true"
                                            Display="Dynamic" ValidationGroup="validateAsset" ForeColor="Red" InitialValue="0"
                                            ErrorMessage="Please enter Asset Cost"></asp:RequiredFieldValidator>
                                    </div>

                                    <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Cost Currency Type :</label>
                                    <div class="col-xl-3 col-lg-3">
                                        <%--OnSelectedIndexChanged="ddlAssetType_SelectedIndexChanged" --%>
                                        <asp:DropDownList ID="ddlCurrencyType" class="form-control m-input" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlCurrencyType" Visible="true"
                                            Display="Dynamic" ValidationGroup="validateAsset" ForeColor="Red" InitialValue="0"
                                            ErrorMessage="Please select Currency Type"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <br />
                            <div id="Div11" runat="server" style="display: block;">
                                <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                    <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Asset Images :</label>
                                    <div class="col-xl-6 col-lg-6">
                                        <%--   <input id="flAssetImg" class="form-control" clientidmode="static" runat="server"
                                                    accept="image/*" onchange="readURL(this);" type="file" />--%>
                                        <asp:FileUpload ID="flAssetImg" runat="server" ClientIDMode="static" class="form-control" AllowMultiple="true" />

                                    </div>
                                    <div class="col-xl-3 col-lg-3 col-form-label" style="overflow: auto" id="AssetImg">

                                        <div id="divImgBtns" runat="server">
                                            <button id='btnAssetImg' type='button' data-toggle='modal' data-target="#exampleModal" class='btn btn-accent m-btn m-btn--icon'
                                                data-images="<%#Eval("ImagePath") %>" data-container='body' style="width: 41px; height: 41px;" data-placement='top'
                                                title='View Uploaded Image' data-title='View Uploaded Image'>
                                                <i class='la la-image' style="margin-left: -106%; font-size: 2.3rem;"></i>
                                            </button>
                                            <asp:HiddenField ID="hdnAssetImg" runat="server" ClientIDMode="Static" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <br />
                            <div id="Div12" runat="server" style="display: block;">
                                <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                    <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Asset Videos :</label>
                                    <div class="col-xl-6 col-lg-6">
                                        <%--        <input id="flAssetVideo" class="form-control" clientidmode="static" runat="server"
                                                    accept="video/*" onchange="readURL(this);" type="file" />--%>
                                        <asp:FileUpload ID="flAssetVideo" runat="server" ClientIDMode="static" class="form-control" AllowMultiple="true" />



                                    </div>
                                    <div class="col-xl-3 col-lg-3 col-form-label" style="overflow: auto" id="AssetVideo">
                                        <div id="div22" runat="server">
                                            <button id='btnAssetVid' type='button' data-toggle='modal' data-target="#exampleModal" class='btn btn-accent m-btn m-btn--icon'
                                                data-images="<%#Eval("ImagePath") %>" data-container='body' style="width: 41px; height: 41px;" data-placement='top'
                                                title='View Uploaded Video' data-title='View Uploaded Video'>
                                                <i class='la la-image' style="margin-left: -106%; font-size: 2.3rem;"></i>
                                            </button>
                                            <asp:HiddenField ID="hdnAssetVid" runat="server" ClientIDMode="Static" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <br />
                            <div id="Div13" runat="server" style="display: block;">
                                <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                    <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Asset Documents :</label>
                                    <div class="col-xl-6 col-lg-6">
                                        <%--  <input id="flAssetDoc" class="form-control" clientidmode="static" runat="server"
                                                    onchange="readURL(this);" type="file" />--%>

                                        <asp:FileUpload ID="flAssetDoc" runat="server" ClientIDMode="static" class="form-control" AllowMultiple="true" />


                                    </div>
                                    <div class="col-xl-3 col-lg-3 col-form-label" style="overflow: auto" id="AssetDoc">
                                        <div id="div25" runat="server">
                                            <button id='btnAssetDoc' type='button' data-toggle='modal' data-target="#exampleModal" class='btn btn-accent m-btn m-btn--icon'
                                                data-images="<%#Eval("ImagePath") %>" data-container='body' style="width: 41px; height: 41px;" data-placement='top'
                                                title='View Uploaded Document' data-title='View Uploaded Document'>
                                                <i class='la la-image' style="margin-left: -106%; font-size: 2.3rem;"></i>
                                            </button>
                                            <asp:HiddenField ID="hdnAssetDoc" runat="server" ClientIDMode="Static" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <br />
                            <div id="Div14" runat="server" style="display: block;">
                                <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                    <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Asset Purchase Date :</label>
                                    <div class="col-xl-3 col-lg-3">
                                        <div class="input-group date">
                                            <asp:TextBox ID="txtAssetPurchaseDate" runat="server" autocomplete="off" class="form-control m-input datepicker"
                                                placeholder="Select Purchase Date"></asp:TextBox>
                                            <div class="input-group-append">
                                                <span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
                                            </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtAssetPurchaseDate" Visible="true" Display="Dynamic"
                                                ValidationGroup="validateAsset" ForeColor="Red" InitialValue="0" ErrorMessage="Please Purchase Date"></asp:RequiredFieldValidator>
                                        </div>
                                        <span id="error_startDate" class="text-danger small"></span>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="m-portlet__body" style="padding: 0.3rem 2.2rem;">
                            <br />
                            <div id="DivIsUpdateAMC" runat="server" style="display: block;">
                                <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                    <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Asset is covered by AMC :</label>
                                    <div class="col-xl-8 col-lg-8">
                                        <input type="checkbox" id="customCheck" runat="server" class="customcontrolinput" name="example1" clientidmode="Static" />

                                    </div>
                                    <div class="col-xl-2 col-lg-2">
                                    </div>
                                </div>
                                <div class="form-group row" style=" margin-bottom: 0;">
                                    <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Asset Name:</label>
                                    <div class="col-xl-10 col-lg-8">
                                        <asp:TextBox ID="txttAmcName" runat="server" class="form-control"></asp:TextBox>


                                    </div>
                                    <div class="col-xl-2 col-lg-2">
                                    </div>
                                </div>
                            </div>
                            <div id="DivIsNewAmc" runat="server" style="display: block;">
                                <div class="form-group row" style=" margin-bottom: 0;">
                                    <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Asset Name:</label>
                                    <div class="col-xl-10 col-lg-8">
                                        <asp:DropDownList ID="ddlAssetName" class="form-control m-input" runat="server" ClientIDMode="Static"
                                            OnSelectedIndexChanged="ddlAssetName_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="ddlAssetName" Visible="true"
                                                        Display="Dynamic" ValidationGroup="validateAssetAddService" ForeColor="Red" InitialValue=""
                                                        ErrorMessage="Please select Asset Type"></asp:RequiredFieldValidator>--%>

                                        <asp:HiddenField ID="txtIsNewAmc" runat="server" ClientIDMode="Static" />

                                    </div>
                                </div>
                            </div>

                            <div id="DivIsAssetCoveredInAmc">

                                <br />
                                <div id="Div5" runat="server" style="display: block;">
                                    <div class="form-group row" style="margin-bottom: 0;">
                                        <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> AMC Type :</label>
                                        <div class="col-xl-3 col-lg-3">
                                            <%--OnSelectedIndexChanged="ddlAssetType_SelectedIndexChanged" --%>
                                            <asp:DropDownList ID="ddlAmcType" class="form-control m-input" runat="server" ClientIDMode="Static">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlAmcType" Visible="true"
                                                Display="Dynamic" ValidationGroup="validateAssetAMC" ForeColor="Red" InitialValue="0"
                                                ErrorMessage="Please select AMC Type"></asp:RequiredFieldValidator>
                                        </div>
                                        <label id="lblAmcStatus" runat="server" class="col-xl-2 col-lg-2 form-control-label">AMC Status :</label>
                                        <div class="col-xl-3 col-lg-3">
                                            <asp:TextBox ID="txtAmcStatus" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <br />
                                <div id="Div24" runat="server" style="display: block;">
                                    <div class="form-group row" style="margin-bottom: 0;">
                                        <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> AMC Description :</label>
                                        <div class="col-xl-10 col-lg-8">
                                            <asp:TextBox ID="txtAmcDescription" TextMode="MultiLine" runat="server" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtAmcDescription" Visible="true"
                                                Display="Dynamic" ValidationGroup="validateAssetAMC" ForeColor="Red" InitialValue=""
                                                ErrorMessage="Please enter AMC Description"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                                <br />
                                <div id="Div15" runat="server" style="display: block;">
                                    <div class="form-group row" style="margin-bottom: 0;">
                                        <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> AMC Start Date :</label>
                                        <div class="col-xl-3 col-lg-3 col-form-label" style="padding-top: calc(0rem + 0px);">
                                            <div class="input-group date">
                                                <asp:TextBox ID="txtAmcStartDate" runat="server" autocomplete="off" class="form-control m-input datepicker"
                                                    placeholder="Select Amc Start Date"></asp:TextBox>
                                                <div class="input-group-append">
                                                    <span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
                                                </div>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtAmcStartDate" Visible="true" Display="Dynamic"
                                                    ValidationGroup="validateAssetAMC" ForeColor="Red" InitialValue="" ErrorMessage="Please Select Start Date"></asp:RequiredFieldValidator>
                                            </div>
                                            <span id="error_AmcStartDate" class="text-danger small"></span>
                                        </div>
                                        <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> AMC End Date :</label>
                                        <div class="col-xl-3 col-lg-3 col-form-label" style="padding-top: calc(0rem + 0px);">
                                            <div class="input-group date">
                                                <asp:TextBox ID="txtAmcEndDate" runat="server" autocomplete="off" class="form-control m-input datepicker"
                                                    placeholder="Select AMC End Date"></asp:TextBox>
                                                <div class="input-group-append">
                                                    <span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
                                                </div>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtAmcEndDate" Visible="true" Display="Dynamic"
                                                    ValidationGroup="validateAssetAMC" ForeColor="Red" InitialValue="" ErrorMessage="Please Select End Date"></asp:RequiredFieldValidator>
                                            </div>
                                            <span id="error_AmcEndDate" class="text-danger small"></span>
                                        </div>
                                    </div>
                                </div>


                                <br />
                                <div id="Div17" runat="server" style="display: block;">
                                    <div class="form-group row" style="margin-bottom: 0;">
                                        <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Assigned Vendor :</label>
                                        <div class="col-xl-10 col-lg-3">
                                            <asp:HiddenField ID="hfAmcAssignedVendor" runat="server" ClientIDMode="Static" />
                                            <%--  <asp:TextBox ID="txtAmcAssignedVendor" runat="server" class="form-control" autocomplete="off"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtAmcAssignedVendor" Visible="true"
                                                        Display="Dynamic" ValidationGroup="validateWorkPermit" ForeColor="Red" InitialValue="0"
                                                        ErrorMessage="Please select Vendor"></asp:RequiredFieldValidator>--%>

                                            <input list="dlamcassigVendor" id="txtamcassigVendor" name="txtamcassigVendor"
                                                class="form-control" runat="server" clientidmode="Static" />
                                            <datalist id="dlamcassigVendor" runat="server" clientidmode="Static"></datalist>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtamcassigVendor"
                                                Visible="true" Display="Dynamic" ValidationGroup="validateAssetAMC" ForeColor="Red" InitialValue=""
                                                ErrorMessage="Please select Vendor"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                </div>

                                <br />
                                <div id="Div18" runat="server" style="display: block;">
                                    <div class="form-group row" style=" margin-bottom: 0;">
                                        <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> AMC Inclusion :</label>
                                        <div class="col-xl-4 col-lg-3" style="padding-right: 0px;">
                                            <asp:TextBox ID="txtAmcInclusion" TextMode="MultiLine" runat="server" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtAmcInclusion" Visible="true"
                                                Display="Dynamic" ValidationGroup="validateAssetAMC" ForeColor="Red" InitialValue="0"
                                                ErrorMessage="Please enter AMC Inclusion"></asp:RequiredFieldValidator>
                                        </div>
                                        <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> AMC Exclusion :</label>
                                        <div class="col-xl-4 col-lg-3">
                                            <asp:TextBox ID="txtAmcExclusion" TextMode="MultiLine" runat="server" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtAmcExclusion" Visible="true"
                                                Display="Dynamic" ValidationGroup="validateAssetAMC" ForeColor="Red" InitialValue="0"
                                                ErrorMessage="Please enter AMC Exclusion"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                                <br />
                                <div id="Div20" runat="server" style="display: block;">
                                    <div class="form-group row" style="margin-bottom: 0;">
                                        <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Additional Remarks :</label>
                                        <div class="col-xl-10 col-lg-6">
                                            <asp:TextBox ID="txtAmcRemarks" TextMode="MultiLine" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <br />
                                <div id="Div21" runat="server" style="display: block;">
                                    <div class="form-group row" style=" margin-bottom: 0;">
                                        <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> AMC Documents :</label>
                                        <div class="col-xl-9 col-lg-6">
                                            <%--<input id="flAmcDoc" class="form-control" clientidmode="static" runat="server" onchange="readURL(this);" type="file" />--%>

                                            <asp:FileUpload ID="flAmcDoc" runat="server" ClientIDMode="static" class="form-control" AllowMultiple="true" />

                                        </div>
                                        <div class="col-xl-1 col-lg-3 col-form-label" style="overflow: auto; padding-top: calc(0rem + 0px);" id="AmcDoc">
                                            <div id="div26" runat="server">
                                                <button id='btnAMCDoc' type='button' data-toggle='modal' data-target="#exampleModal" class='btn btn-accent m-btn m-btn--icon'
                                                    data-images="<%#Eval("ImagePath") %>" data-container='body' style="width: 41px; height: 41px;"
                                                    data-placement='top' title='View Uploaded Document' data-title='View Uploaded Document'>
                                                    <i class='la la-image' style="margin-left: -106%; font-size: 2.3rem;"></i>
                                                </button>
                                                <asp:HiddenField ID="HdnAmcDoc" runat="server" ClientIDMode="Static" />
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <br />
                                <div id="Div32" runat="server" style="display: block;">
                                        <div class="m-form__heading" style="text-align: center;">
                                            <h3 class="m-form__heading-title" style="line-height: 2.0; background: aliceblue; font-size: 1.2rem;">Asset AMC History</h3>
                                        </div>
                                </div>

                                <br />
                                <div id="Div10" runat="server" style="display: block;">
                                    <div class="form-group row" style=" margin-bottom: 4%;">
                                        <div class="col-xl-12 col-lg-10">
                                            <table class="m-datatable" id="html_table" width="100%">
                                                <thead>
                                                    <tr>
                                                        <%--<th title="Field #1" data-field="SrNo">Sr. No</th>--%>
                                                        <%--<th title="Config ID" data-field="Chk_Config_ID">Checklist Config ID</th>--%>
                                                        <th title="Asset_AMC_Type" data-field="Asset_AMC_Type_Desc">AMC ID</th>
                                                        <th title="AMC_Desc" data-field="AMC_Desc">AMC Type</th>
                                                        <th title="Start_Date" data-field="AMC_Start_Date">Start Date</th>
                                                        <th title="End_Date" data-field="AMC_End_Date">End Date</th>
                                                        <th title="Vendor_Name" data-field="Vendor_Name">Vendor</th>
                                                        <th title="Remarks" data-field="Additional Remarks">Status</th>
                                                        <th title="Status" data-field="AMC_Status">View Documents</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <%=fetchListing()%>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>

                                </div>
                            </div>

                        </div>

                    </div>




                </div>


                <!-- Modal -->
                <div class="modal fade" id="myModal" role="dialog">
                    <div class="modal-dialog modal-lg">
                        <!-- Modal content-->
                        <div class="modal-content">

                            <div class="modal-body">
                                <div class="modal-header">
                                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>

                                    <asp:HiddenField ID="hdAddAsset" runat="server" ClientIDMode="Static" />
                                    <h4 class="modal-title">
                                        <label id="lblmyModalTitle"></label>
                                    </h4>
                                </div>

                                <div class="modal-body">

                                    <form role="form" method="post" id="myNewModal">

                                        <div id="divModalAssetType" style="display: block;" class="form-group">

                                            <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                <label class="col-xl-4 col-lg-4 form-control-label"><span style="color: red;">*</span> Asset Type :</label>
                                                <div class="col-xl-8 col-lg-8">
                                                    <asp:TextBox ID="txtModalAssetType" runat="server" class="form-control" ClientIDMode="Static"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtModalAssetType" Visible="true"
                                                        Display="Dynamic" ValidationGroup="validateAssetModal" ForeColor="Red" InitialValue="0"
                                                        ErrorMessage="Please enter Asset Type"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divModalAssetCategory" style="display: block;" class="form-group">

                                            <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                <label class="col-xl-4 col-lg-4 form-control-label"><span style="color: red;">*</span> Asset Type :</label>
                                                <div class="col-xl-8 col-lg-8">
                                                    <asp:DropDownList ID="ddlModalAssetType" class="form-control m-input" runat="server" ClientIDMode="Static"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="ddlModalAssetType" Visible="true"
                                                        Display="Dynamic" ValidationGroup="validateAssetModal" ForeColor="Red" InitialValue="0"
                                                        ErrorMessage="Please select Asset Category"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                <label class="col-xl-4 col-lg-4 form-control-label"><span style="color: red;">*</span>Asset Category :</label>
                                                <div class="col-xl-8 col-lg-8">
                                                    <asp:TextBox ID="txtModalAssetCategory" runat="server" class="form-control" ClientIDMode="Static"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtModalAssetCategory" Visible="true"
                                                        Display="Dynamic" ValidationGroup="validateAssetModal" ForeColor="Red" InitialValue="0"
                                                        ErrorMessage="Please enter Asset Cost"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div id="divModalRenewAmc" style="display: block;" class="form-group">

                                            <div id="DivIsAssetCoveredInRenewAmc">

                                                <br />
                                                <div id="Div16" runat="server" style="display: block;">
                                                    <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                        <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> AMC Type :</label>
                                                        <div class="col-xl-3 col-lg-3">
                                                            <%--OnSelectedIndexChanged="ddlAssetType_SelectedIndexChanged" --%>
                                                            <asp:DropDownList ID="ddlRenewAmcType" class="form-control m-input" runat="server" ClientIDMode="Static">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlRenewAmcType" Visible="true"
                                                                Display="Dynamic" ValidationGroup="validateAssetRenewAmc" ForeColor="Red" InitialValue="0"
                                                                ErrorMessage="Please select AMC Type"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> AMC Status :</label>
                                                        <div class="col-xl-3 col-lg-3">
                                                            <asp:TextBox ID="txtRenewAmcStatus" ReadOnly="true" runat="server" class="form-control" ClientIDMode="Static" Text="ACTIVE"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <br />
                                                <div id="Div19" runat="server" style="display: block;">
                                                    <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                        <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> AMC Description :</label>
                                                        <div class="col-xl-8 col-lg-8">
                                                            <asp:TextBox ID="txtRenewAmcDescription" TextMode="MultiLine" runat="server" class="form-control" ClientIDMode="Static"> </asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtRenewAmcDescription" Visible="true"
                                                                Display="Dynamic" ValidationGroup="validateAssetRenewAmc" ForeColor="Red" InitialValue=""
                                                                ErrorMessage="Please enter AMC Description"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>

                                                <br />
                                                <div id="Div23" runat="server" style="display: block;">
                                                    <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                        <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> AMC Start Date :</label>
                                                        <div class="col-xl-3 col-lg-3 col-form-label">
                                                            <div class="input-group date">
                                                                <asp:TextBox ID="txtRenewAmcStartDate" runat="server" autocomplete="off" class="form-control m-input datepicker"
                                                                    placeholder="Select Amc Start Date" ClientIDMode="Static"></asp:TextBox>
                                                                <div class="input-group-append">
                                                                    <span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
                                                                </div>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtRenewAmcStartDate" Visible="true" Display="Dynamic"
                                                                    ValidationGroup="validateAssetRenewAmc" ForeColor="Red" InitialValue="" ErrorMessage="Please Select Start Date"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <span id="error_RenewAmcStartDate" class="text-danger small"></span>
                                                        </div>
                                                        <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> AMC End Date :</label>
                                                        <div class="col-xl-3 col-lg-3 col-form-label">
                                                            <div class="input-group date">
                                                                <asp:TextBox ID="txtRenewAmcEndDate" runat="server" autocomplete="off" class="form-control m-input datepicker"
                                                                    placeholder="Select AMC End Date" ClientIDMode="Static"></asp:TextBox>
                                                                <div class="input-group-append">
                                                                    <span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
                                                                </div>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtRenewAmcEndDate" Visible="true" Display="Dynamic"
                                                                    ValidationGroup="validateAssetRenewAmc" ForeColor="Red" InitialValue="" ErrorMessage="Please Select End Date"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <span id="error_RenewAmcEndDate" class="text-danger small"></span>
                                                        </div>
                                                    </div>
                                                </div>


                                                <br />
                                                <div id="Div27" runat="server" style="display: block;">
                                                    <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                        <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Assigned Vendor :</label>
                                                        <div class="col-xl-3 col-lg-3">
                                                            <asp:HiddenField ID="hfRenewAmcAssignedVendor" runat="server" ClientIDMode="Static" />

                                                            <input list="dlRenewAmcassigVendor" id="txtRenewAmcassigVendor" name="txtRenewAmcassigVendor"
                                                                class="form-control" runat="server" clientidmode="Static" />
                                                            <datalist id="dlRenewAmcassigVendor" runat="server" clientidmode="Static"></datalist>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtRenewAmcassigVendor"
                                                                Visible="true" Display="Dynamic" ValidationGroup="validateAssetRenewAmc" ForeColor="Red" InitialValue=""
                                                                ErrorMessage="Please select Vendor"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                </div>

                                                <br />
                                                <div id="Div28" runat="server" style="display: block;">
                                                    <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                        <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> AMC Inclusion :</label>
                                                        <div class="col-xl-3 col-lg-3">
                                                            <asp:TextBox ID="txtRenewAmcInclusion" TextMode="MultiLine" runat="server" class="form-control" ClientIDMode="Static"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtRenewAmcInclusion" Visible="true"
                                                                Display="Dynamic" ValidationGroup="validateAssetRenewAmc" ForeColor="Red" InitialValue=""
                                                                ErrorMessage="Please enter AMC Inclusion"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> AMC Exclusion :</label>
                                                        <div class="col-xl-3 col-lg-3">
                                                            <asp:TextBox ID="txtRenewAmcExclusion" TextMode="MultiLine" runat="server" class="form-control" ClientIDMode="Static"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtRenewAmcExclusion" Visible="true"
                                                                Display="Dynamic" ValidationGroup="validateAssetRenewAmc" ForeColor="Red" InitialValue=""
                                                                ErrorMessage="Please enter AMC Exclusion"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>

                                                <br />
                                                <div id="Div29" runat="server" style="display: block;">
                                                    <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                        <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Additional Remarks :</label>
                                                        <div class="col-xl-6 col-lg-6">
                                                            <asp:TextBox ID="txtRenewAmcRemarks" TextMode="MultiLine" runat="server" class="form-control" ClientIDMode="Static"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <br />
                                                <div id="Div30" runat="server" style="display: block;">
                                                    <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                        <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> AMC Documents :</label>
                                                        <div class="col-xl-6 col-lg-6">
                                                            <asp:FileUpload ID="flRenewAmcDoc" runat="server" ClientIDMode="static" class="form-control" AllowMultiple="true" />

                                                        </div>
                                                        <div class="col-xl-3 col-lg-3 col-form-label" style="overflow: auto" id="RenewAmcDoc">
                                                            <div id="div31" runat="server">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>

                                        <br />
                                        <div id="divModalAssetErrorMessage" style="display: block;">
                                            <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                <label class="col-xl-10 col-lg-10 form-control-label" style="display: none; font-size: large; font-weight: bold; color: red"
                                                    id="lblModalAssetErrorMessage" runat="server" clientidmode="Static">
                                                </label>
                                            </div>
                                        </div>

                                        <div class="modal-footer">
                                            <%-- <asp:Button ID="btnModalSave" runat="server" Text="Save" class="btn btn-accent mr-auto"
                                                     ValidationGroup="validateAssetModal"  CausesValidation="true" /> --%>
                                            <button type="submit" runat="server" id="btnModalAssetSave" onserverclick="btnModalAssetSave_Click" class="btn btn-accent mr-auto"
                                                validationgroup="validateAssetRenewAmc" causesvalidation="true">
                                                Save</button>
                                            <button type="button" runat="server" class="btn btn-default" data-dismiss="modal">Close</button>
                                        </div>

                                    </form>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <!-- SUCCESS PANEL -->
                <asp:Panel ID="pnlWpReqestSuccess" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
                    <div class="" id="add_sub_location2" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog" role="document" style="max-width: 590px;">
                            <div class="modal-content">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <div class="modal-header">
                                            <h5 class="modal-title" id="exampleModalLabel2">Asset Management AMC Request Confirmation</h5>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader2">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                        </div>
                                        <div class="modal-body">
                                            <div class="form-group m-form__group row">
                                                <label for="recipient-name" class="col-xl-8 col-lg-3 form-control-label">Asset Management AMC Request has been saved successfully</label>
                                            </div>
                                            <div class="form-group m-form__group row">
                                                <label for="message-text" class="col-xl-5 col-lg-3 form-control-label font-weight-bold">Ticket ID :</label>
                                                <asp:Label ID="lblWpRequestCode" Text="" runat="server" CssClass="col-xl-1 col-lg-3 col-form-label" Style="padding-top: calc(0.15rem + 1px); margin-left: -10%;"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="modal-footer">
                                            <asp:Button ID="btnSuccessOk" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md"
                                                Text="Ok" OnClick="btnSuccessOk_Click" />
                                            <%----%>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnTest" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </asp:Panel>

                <div aria-hidden="true" aria-labelledby="exampleModalLabel" class="modal fade" id="exampleModal" role="dialog" tabindex="-1">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLabel">Uploaded Image</h5>
                                <button aria-label="Close" class="close" data-dismiss="modal" type="button">
                                    <span aria-hidden="true">×</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <div class="carousel slide" data-ride="carousel" id="carouselExampleControls">
                                    <div class="carousel-inner">
                                    </div>
                                    <a class="carousel-control-prev" data-slide="prev" href="#carouselExampleControls" role="button">
                                        <span aria-hidden="true" class="carousel-control-prev-icon"></span>
                                        <span class="sr-only">Previous</span>
                                    </a>
                                    <a class="carousel-control-next" data-slide="next" href="#carouselExampleControls" role="button">
                                        <span aria-hidden="true" class="carousel-control-next-icon"></span>
                                        <span class="sr-only">Next </span>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    </div>


</asp:Content>
