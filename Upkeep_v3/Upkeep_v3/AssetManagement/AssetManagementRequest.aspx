<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/UpkeepMaster.Master" CodeBehind="AssetManagementRequest.aspx.cs" Inherits="Upkeep_v3.AssetManagement.AssetManagementRequest" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<script src="http://ajax.aspnetcdn.com/ajax/jquery/jquery-1.8.0.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.22/jquery-ui.js"></script>
    <link rel="Stylesheet" href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.10/themes/redmond/jquery-ui.css" />--%>

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
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
        .auto-style1 {
            left: 0px;
            top: 15px;
        }

        .w100 {
            width: 100%;
            position: absolute;
            height: 100%;
        }
    </style>


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
                    //send ajax request
                    //alert(this.id);
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

            //customCheck divScheduleTable DivIsAssetCoveredInAmc
            //custom-control-input
            $(".customcontrolinput").click(function () {
                //alert('FF');
                //alert($(this).attr('id'));
                //alert($(this).prop("checked"));
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

            //$("div#DivIsServiceSchedule").hide("slow");
            //$("div#DivIsAssetCoveredInAmc").hide("slow");

            DivShowHide();

            $("#btnAddAssetType").click(function () {

                $("div#divModalAssetType").show();
                $("div#divModalAssetCategory").hide();
                $("div#divModalAssetTypeSave").show();
                $("div#divModalAssetCategorySave").hide();
                $("div#divModalDepartmentSave").hide();
                $("div#divModalAssetDepartment").hide();
                $("div#divModalVendorSave").hide();
                $("div#divModalAssetVendor").hide();
                //   return false;
            });
            $("#btnAddAssetCategory").click(function () {

                $("div#divModalAssetType").hide();
                $("div#divModalAssetCategory").show();
                $("div#divModalAssetTypeSave").hide();
                $("div#divModalAssetCategorySave").show();
                $("div#divModalDepartmentSave").hide();
                $("div#divModalAssetDepartment").hide();
                $("div#divModalVendorSave").hide();
                $("div#divModalAssetVendor").hide();
                // return false;
            });
            $("#btnAddAssetVendor").click(function () {

                $("div#divModalAssetType").hide();
                $("div#divModalAssetCategory").hide();
                $("div#divModalAssetTypeSave").hide();
                $("div#divModalAssetCategorySave").hide();
                $("div#divModalDepartmentSave").hide();
                $("div#divModalAssetDepartment").hide();
                $("div#divModalVendorSave").show();
                $("div#divModalAssetVendor").show();
                // return false;
            });
            $("#btnAddDepartment").click(function () {

                $("div#divModalAssetType").hide();
                $("div#divModalAssetCategory").hide();
                $("div#divModalAssetTypeSave").hide();
                $("div#divModalAssetCategorySave").hide();
                $("div#divModalDepartmentSave").show();
                $("div#divModalAssetDepartment").show();
                $("div#divModalVendorSave").hide();
                $("div#divModalAssetVendor").hide();
                // return false;
            });
            $("#btnAddLocation").click(function () {

                $("div#divModalAssetType").hide();
                $("div#divModalAssetCategory").hide();
                $("div#divModalAssetTypeSave").hide();
                $("div#divModalAssetCategorySave").hide();
                $("div#divModalDepartmentSave").hide();
                $("div#divModalAssetDepartment").hide();
                $("div#divModalVendorSave").hide();
                $("div#divModalAssetVendor").hide();
                // return false;
            });

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

                    $("div#divModalAssetType").show();
                    $("div#divModalAssetCategory").hide();
                    $("div#divModalAssetTypeSave").show();
                    $("div#divModalAssetCategorySave").hide();
                    $("div#divModalDepartmentSave").hide();
                    $("div#divModalAssetDepartment").hide();
                    $("div#divModalVendorSave").hide();
                    $("div#divModalAssetVendor").hide();
                }
                else if (button.attr('id') == "btnAddAssetCategory") {
                    $('#hdAddAsset').val("2");

                    $("div#divModalAssetType").hide();
                    $("div#divModalAssetCategory").show();
                    $("div#divModalAssetTypeSave").hide();
                    $("div#divModalAssetCategorySave").show();
                    $("div#divModalDepartmentSave").hide();
                    $("div#divModalAssetDepartment").hide();
                    $("div#divModalVendorSave").hide();
                    $("div#divModalAssetVendor").hide();
                }
                else if (button.attr('id') == "btnAddAssetVendor") {
                    $('#hdAddAsset').val("3");

                    $("div#divModalAssetType").hide();
                    $("div#divModalAssetCategory").hide();
                    $("div#divModalAssetTypeSave").hide();
                    $("div#divModalAssetCategorySave").hide();
                    $("div#divModalDepartmentSave").hide();
                    $("div#divModalAssetDepartment").hide();
                    $("div#divModalVendorSave").show();
                    $("div#divModalAssetVendor").show();
                }
                else if (button.attr('id') == "btnAddDepartment") {
                    $('#hdAddAsset').val("4");

                    $("div#divModalAssetType").hide();
                    $("div#divModalAssetCategory").hide();
                    $("div#divModalAssetTypeSave").hide();
                    $("div#divModalAssetCategorySave").hide();
                    $("div#divModalDepartmentSave").show();
                    $("div#divModalAssetDepartment").show();
                    $("div#divModalVendorSave").hide();
                    $("div#divModalAssetVendor").hide();
                }
                else if (button.attr('id') == "btnAddLocation") {
                    $('#hdAddAsset').val("5");

                    $("div#divModalAssetType").hide();
                    $("div#divModalAssetCategory").hide();
                    $("div#divModalAssetTypeSave").hide();
                    $("div#divModalAssetCategorySave").hide();
                    $("div#divModalDepartmentSave").hide();
                    $("div#divModalAssetDepartment").hide();
                    $("div#divModalVendorSave").hide();
                    $("div#divModalAssetVendor").hide();
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

                    alert(image);
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
                        //alert("Video");
                        if (index == 0)
                            var item = '<div class="carousel-item active">';
                        else
                            var item = '<div class="carousel-item">';

                        item += '<video width="320" height="240" controls><source src="' + image + '" type="video/mp4"></video>';

                        modal.find('.modal-body .carousel-inner').append(item);
                    }
                    if (title.includes("Document")) {
                        //alert("Document");


                        //$obj = $('<object>');
                        //$obj.attr("data", "'" + image + "'");
                        //$obj.attr("type", "application/txt");
                        //$obj.addClass("w100");

                        ////$("#pdfdiv_content").append($obj);
                        //modal.find('.modal-body .carousel-inner').append($obj);

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
                //alert("A1");
                var value = <%= Session["TransactionID"].ToString() %>;
                /*
                                alert($("#HdflAssetImg").val());
                                alert($("#HdflAssetVideo").val());
                                alert($("#HdflAssetDoc").val());
                                alert($("#HdflAmcDoc").val());
                */
                if (value == 0) {

                    //  alert("A2");

                    $('#txtHdn').val("");

                    if ($("#customCheck").is(':checked')) {
                        $("#btnSaveAmc").click();

                        if ($("#HdflAmcDoc").val() = "1") {
                            alert('3 Mb Documents Size Limit, Please Correct');
                            return;
                        }

                        if ($('#hfAmcAssignedVendor').val() == '') {
                            alert("Please Select Proper AMC Vendor!");
                            return;
                        }
                    }
                    if ($("#customCheck1").is(':checked')) {

                        var RwsCnt = $("#TblLevels tr").length;
                        //alert(RwsCnt);
                        var cnt = 1;

                        var xml = "";
                        xml += "<Asset_Service_ROOT>";
                        for (var i = 1; i <= RwsCnt - 2; ++i) {

                            //var cellsID = "#Cell" + parseInt(cnt) + parseInt(1);
                            //alert($(cellsID).val());

                            xml += "<Asset_Service>";

                            if ($("#Cell" + parseInt(cnt) + parseInt(1)).val() == "") {
                                alert("Please Select Service Schedule Date!");
                                return false;
                            }
                            if ($("#Cell" + parseInt(cnt) + parseInt(2)).val() == "0") {
                                alert("Please Select Service Assigned to!");
                                return false;
                            }
                            if ($("#Cell" + parseInt(cnt) + parseInt(3)).val() == "") {
                                alert("Please Enter Days Before Alert Mail !");
                                return false;
                            }
                            else if ($("#Cell" + parseInt(cnt) + parseInt(3)).val() > 31) {
                                alert("Alert days cannot be more then 31Days !");
                                return false;
                            }


                            xml += "<Asset_Service_Date>" + $("#Cell" + parseInt(cnt) + parseInt(1)).val() + "</Asset_Service_Date>";
                            xml += "<Asset_Service_AssignTo>" + $("#Cell" + parseInt(cnt) + parseInt(2)).val() + "</Asset_Service_AssignTo>";
                            xml += "<Asset_Service_AlertBeforeDays>" + $("#Cell" + parseInt(cnt) + parseInt(3)).val() + "</Asset_Service_AlertBeforeDays>";
                            xml += "<Asset_Service_Remarks>" + $("#Cell" + parseInt(cnt) + parseInt(4)).val() + "</Asset_Service_Remarks>";
                            xml += "</Asset_Service>";
                            cnt = cnt + 1;
                        }
                        xml += "</Asset_Service_ROOT>";
                        $('#txtHdn').val(xml);
                        //alert(xml);
                        //alert($('#txtHdn').val());
                        //alert("F");

                    }
                }

                // alert("A3");
                if ($('#hdnassetLocation').val() == '') {
                    alert("Please Select Proper Location!");
                    return;
                }
                if ($("#HdflAssetImg").val() == "1") {
                    alert('3 Mb Image Size Limit, Please Correct');
                    return;
                }
                else if ($("#HdflAssetVideo").val() == "1") {
                    alert('4 Mb Video Size Limit, Please Correct');
                    return;
                }
                else if ($("#HdflAssetDoc").val() == "1") {
                    alert('3 Mb Documents Size Limit, Please Correct');
                    return;
                }

                $("#btnSave").click();

            });

            //Check file Upload Size.

            /*
                flAssetImg
                flAssetVideo
                flAssetDoc
                flAmcDoc
             */

            $("#flAssetImg").on('change', function (e) {
                $("#HdflAssetImg").val("0");
                bytesToSize(this.files[0].size, 'flAssetImg');
            });
            $("#flAssetVideo").on('change', function (e) {
                $("#HdflAssetVideo").val("0");
                bytesToSize(this.files[0].size, 'flAssetVideo');
            });
            $("#flAssetDoc").on('change', function (e) {
                $("#HdflAssetDoc").val("0");
                bytesToSize(this.files[0].size, 'flAssetDoc');
            });
            $("#flAmcDoc").on('change', function (e) {
                $("#HdflAmcDoc").val("0");
                bytesToSize(this.files[0].size, 'flAmcDoc');
            });

            function bytesToSize(bytes, types) {

                var sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB'];
                if (bytes == 0) return '0 Byte';
                var i = parseInt(Math.floor(Math.log(bytes) / Math.log(1024)));
                var sSize = 0;
                sSize = Math.round(bytes / Math.pow(1024, i), 2);
                //Math.round(bytes / Math.pow(1024, i), 2) + ' ' + sizes[i]
                //if (sizes[i] == 'Bytes' || sizes[i] == 'KB') {
                //    // return 0;
                //}
                //else 
                if (sizes[i] == 'MB') {
                    if (sSize > 4 && types == 'flAssetVideo') {
                        $("#HdflAssetVideo").val("1");
                        alert('4 Mb Video Size Limit');
                    }
                    else if (sSize > 3) {

                        if (types == 'flAssetImg') {
                            $("#HdflAssetImg").val("1");
                            alert('3 Mb Image Size Limit');
                        }
                        else if (types == 'flAssetDoc') {
                            $("#HdflAssetDoc").val("1");
                            alert('3 Mb Documents Size Limit');
                        }
                        else if (types == 'flAmcDoc') {
                            $("#HdflAmcDoc").val("1");
                            alert('3 Mb Documents Size Limit');
                        }
                    }
                }
            }


        });


    </script>

    <div class="m-grid__item m-grid__item--fluid m-wrapper" style="margin-bottom: 10px;">
        <div class="m-content">
            <div class="row">

                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <%--<form class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmWorkPermit" method="post">--%>
                        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

                        <asp:HiddenField ID="hdnWpHeaderData" runat="server" ClientIDMode="Static" />
                        <asp:HiddenField ID="hdnWpHeader" runat="server" ClientIDMode="Static" />

                        <asp:HiddenField ID="HdflAssetImg" runat="server" ClientIDMode="Static" Value="0" />
                        <asp:HiddenField ID="HdflAssetVideo" runat="server" ClientIDMode="Static" Value="0" />
                        <asp:HiddenField ID="HdflAssetDoc" runat="server" ClientIDMode="Static" Value="0" />
                        <asp:HiddenField ID="HdflAmcDoc" runat="server" ClientIDMode="Static" Value="0" />

                        <p id="info" style="display: none;"></p>
                        <p id="infox" style="display: none;"></p>

                        <div class="m-portlet__head">
                            <div class="m-portlet__head-progress">
                            </div>
                            <div class="m-portlet__head-wrapper">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">Add Asset Details</h3>
                                    </div>
                                </div>

                                <div class="m-portlet__head-tools" style="width: 28%;">
                                    <a href="<%= Page.ResolveClientUrl("~/AssetManagement/AssetManagementList.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
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
                                            CausesValidation="true" ValidationGroup="validateAsset" Text="Save" OnClick="btnSave_Click" Style="display: none" />
                                        <asp:Button ID="btnSaveAmc" TYPE="button" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" ClientIDMode="Static"
                                            CausesValidation="true" ValidationGroup="validateAssetAMC" Text="SaveAMC" Style="display: none" />

                                        <asp:Button ID="btnTest" Style="display: none;" runat="server" />
                                        <cc1:ModalPopupExtender ID="mpeWpRequestSaveSuccess" runat="server" PopupControlID="pnlWpReqestSuccess" TargetControlID="btnTest"
                                            CancelControlID="btnCloseHeader2" BackgroundCssClass="modalBackground">
                                        </cc1:ModalPopupExtender>
                                    </div>
                                </div>

                            </div>
                        </div>

                                <div class="m-portlet__body" style="padding: 2rem 3rem 0rem 3rem;">

                                        <div class="m-form__heading" style="text-align:center; ">
										    <h3 class="m-form__heading-title" style="line-height: 2.0;background: aliceblue; font-size: 1.2rem;">Asset Details</h3>
									    </div>
                                    </br>
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
                                                    <div class="col-xl-1 col-lg-1">
                                                        <%-- <div class="glyphicon">
                                                    <i class="glyphicon glyphicon-search form-control-feedback"></i>
                                                    <asp:Button ID="Button2" runat="server" class="btn btn-primary btn-search"></asp:Button>
                                                </div>--%>

                                                        <asp:Button type="Button" ID="btnAddAssetType" runat="server" class="btn btn-success m-btn m-btn--icon m-btn--wide"
                                                            Text="Add New Type" data-toggle="modal" data-target="#myModal" ClientIDMode="Static" OnClientClick="return false"
                                                            data-title="Add Asset Type" data-backdrop="static" data-keyboard="false" />

                                                        <%-- OnClick="btnSave_Click"   --%>
                                                    </div>

        

                                                </div>
                                            </div>

                                            <br />
                                            <div id="Div1" runat="server" style="display: block;">
                                                <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                                                                <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Asset Category :</label>
                                                    <div class="col-xl3 col-lg-3">
                                                        <%--OnSelectedIndexChanged="ddlAssetType_SelectedIndexChanged" --%>
                                                        <asp:DropDownList ID="ddlAssetCategory" class="form-control m-input" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlAssetCategory" Visible="true"
                                                            Display="Dynamic" ValidationGroup="validateAsset" ForeColor="Red" InitialValue="0"
                                                            ErrorMessage="Please select Asset Category"></asp:RequiredFieldValidator>
                                                    </div>

                                                    <%--<label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;"></span></label>--%>
                                                    <div class="col-xl-1 col-lg-1">
                                                        <asp:Button type="Button" ID="btnAddAssetCategory" runat="server" class="btn btn-success m-btn m-btn--icon m-btn--wide"
                                                            Text="Add New Category" data-toggle="modal" data-target="#myModal" ClientIDMode="Static" OnClientClick="return false"
                                                            data-title="Add Asset Category" data-backdrop="static" data-keyboard="false" />
                                                        <%--OnClick="btnSave_Click"  OnClientClick="return false"   --%>
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

                                            <label class="col-xl-2 col-lg-2 form-control-label"> Asset Description :</label>
                                            <div class="col-xl-5 col-lg-3">
                                                <asp:TextBox ID="txtAssetDescription" TextMode="MultiLine" runat="server" class="form-control" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <br />
                                    <div id="Div4" runat="server" style="display: block;">
                                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <label class="col-xl-2 col-lg-2 form-control-label">Manufactured By :</label>
                                            <div class="col-xl-3 col-lg-3">
                                                <asp:TextBox ID="txtAssetMaker" runat="server" class="form-control"></asp:TextBox>
                                            </div>

                                            <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Asset Serial No :</label>
                                            <div class="col-xl-5 col-lg-3">
                                                <asp:TextBox ID="txtAssetSerialNo" runat="server" class="form-control" placeholder="Enter Serial No as printed on Asset Barcode"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAssetSerialNo" Visible="true"
                                                    Display="Dynamic" ValidationGroup="validateAsset" ForeColor="Red" InitialValue="0"
                                                    ErrorMessage="Please enter Asset Serial No"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    </br>
                                        <div class="m-form__heading" style="text-align:center; ">
										    <h3 class="m-form__heading-title" style="line-height: 2.0;background: aliceblue; font-size: 1.2rem;">Asset Purchase Information</h3>
									    </div>
                                    </br>

                                    <div id="Div6" runat="server" style="display: block;">
                                        <%-- <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="ddlAssetVendor" EventName="SelectedIndexChanged" />
                                                    </Triggers>
                                                    <ContentTemplate>--%>
                                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Select Asset Vendor ( Purchased From ) :</label>
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
                                            <div class="col-xl-3 col-lg-3">
                                                <asp:Button ID="btnAddAssetVendor" type="Button" runat="server" class="btn btn-success m-btn m-btn--icon m-btn--wide"
                                                    Text="Add New Vendor" data-toggle="modal" data-target="#myModal" ClientIDMode="Static" OnClientClick="return false"
                                                    data-title="Add Asset Vendor" data-backdrop="static" data-keyboard="false" />
                                                <%--OnClick="btnSave_Click"  OnClientClick="return false" --%>
                                            </div>
                                        </div>

                                        <%-- </ContentTemplate>
                                                </asp:UpdatePanel>--%>
                                    </div>
                                    </br>
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

                                            <label class="col-xl-5 col-lg-2 form-control-label" style="max-width: 30%;"><span style="color: red;">*</span> Currency in which Asset was Purchased:</label>
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
                                    </br>

                                

                                    <div id="Div14" runat="server" style="display: block;">
                                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <label class="col-xl-3 col-lg-2 form-control-label"><span style="color: red;">*</span>Select Asset Purchase Date :</label>
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


                                    <br />

                                    <div class="m-form__heading" style="text-align:center; ">
										    <h3 class="m-form__heading-title" style="line-height: 2.0;background: aliceblue; font-size: 1.2rem;">Asset Assigned Details</h3>
									    </div>
                                    </br>
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
                                            <div class="col-xl-3 col-lg-3">
                                                <asp:Button ID="btnAddDepartment" type="Button" runat="server" class="btn btn-success m-btn m-btn--icon m-btn--wide"
                                                    Text="Add New Department" data-toggle="modal" data-target="#myModal" ClientIDMode="Static" OnClientClick="return false"
                                                    data-title="Add Department" data-backdrop="static" data-keyboard="false" />
                                                <%--OnClick="btnSave_Click"  OnClientClick="return false" --%>
                                            </div>
                                        </div>
                                    </div>

                                    <br />
                                    <div id="Div8" runat="server" style="display: block;">
                                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Assign Location :</label>
                                            <div class="col-xl-10 col-lg-3">
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
                                                <asp:Button ID="btnAddLocation" type="Button" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md"
                                                    Text="+" data-toggle="modal" data-target="#myModal" ClientIDMode="Static" OnClientClick="return false"
                                                    data-title="Add Location" data-backdrop="static" data-keyboard="false" />
                                                <%--OnClick="btnSave_Click" OnClientClick="return false" --%>
                                            </div>
                                        </div>
                                    </div>

                                    <br />
                                     <div class="m-form__heading" style="text-align:center; ">
										    <h3 class="m-form__heading-title" style="line-height: 2.0;background: aliceblue; font-size: 1.2rem;">Asset Media Files</h3>
									    </div>
                                    </br>
                                    <br />
                                    <div id="Div11" runat="server" style="display: block;">
                                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <label class="col-xl-3 col-lg-2 form-control-label" style="max-width: 20%;"><span style="color: red;">*</span> Upload Asset Images :</label>
                                            <div class="col-xl-8 col-lg-6">
                                                <%--   <input id="flAssetImg" class="form-control" clientidmode="static" runat="server"
                                                    accept="image/*" onchange="readURL(this);" type="file" />--%>
                                                <asp:FileUpload ID="flAssetImg" runat="server" ClientIDMode="static" class="form-control" AllowMultiple="true" />

                                            </div>
                                            <div class="col-xl-1 col-lg-3 col-form-label" style="overflow: auto; padding-top: calc(0rem + 0px);" id="AssetImg">

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
                                            <label class="col-xl-3 col-lg-2 form-control-label" style="max-width: 20%;">Upload Asset Videos :</label>
                                            <div class="col-xl-8 col-lg-6">
                                                <%--        <input id="flAssetVideo" class="form-control" clientidmode="static" runat="server"
                                                    accept="video/*" onchange="readURL(this);" type="file" />--%>
                                                <asp:FileUpload ID="flAssetVideo" runat="server" ClientIDMode="static" class="form-control" AllowMultiple="true" />



                                            </div>
                                            <div class="col-xl-1 col-lg-3 col-form-label" style="overflow: auto; padding-top: calc(0rem + 0px);" id="AssetImg" id="AssetVideo">
                                                <div id="div22" runat="server">
                                                    <button id='btnAssetVid' type='button' data-toggle='modal' data-target="#exampleModal" class='btn btn-accent m-btn m-btn--icon'
                                                        data-images="<%#Eval("ImagePath") %>" data-container='body' style="width: 41px; height: 41px;" data-placement='top'
                                                        title='View Uploaded Video' data-title='View Uploaded Videos'> 
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
                                            <label class="col-xl-3 col-lg-2 form-control-label" style="max-width: 20%;">Upload Asset Documents :</label>
                                            <div class="col-xl-8 col-lg-6">
                                                <%--  <input id="flAssetDoc" class="form-control" clientidmode="static" runat="server"
                                                    onchange="readURL(this);" type="file" />--%>

                                                <asp:FileUpload ID="flAssetDoc" runat="server" ClientIDMode="static" class="form-control" AllowMultiple="true" />


                                            </div>
                                            <div class="col-xl-1 col-lg-3 col-form-label" style="overflow: auto; padding-top: calc(0rem + 0px);" id="AssetDoc">
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

                                </div>

                                <div class="m-portlet__body" style="padding: 0rem 3rem 0rem 3rem;">
                                    <br />
                                     <div class="m-form__heading" style="text-align:center; ">
										    <h3 class="m-form__heading-title" style="line-height: 2.0;background: aliceblue; font-size: 1.2rem;">Asset Annual Maintenance Contract (AMC) Details</h3>
									    </div>
                                    </br>
                                    <div id="Div3" runat="server" style="display: block;">
                                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            
                                            <div class="col-xl-1 col-lg-3" style="text-align:center; max-width: 3%;">
                                                <input type="checkbox" id="customCheck" runat="server" class="customcontrolinput" name="example1" clientidmode="Static" />

                                            </div>
                                            <label class="col-xl-5 col-lg-2 form-control-label">Check this box if Asset is covered by AMC :</label>

                                        </div>
                                    </div>

                                    <div id="DivIsAssetCoveredInAmc">

                                        <br />
                                        <div id="Div5" runat="server" style="display: block;">
                                            <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Select AMC Type :</label>
                                                <div class="col-xl-3 col-lg-3">
                                                    <%--OnSelectedIndexChanged="ddlAssetType_SelectedIndexChanged" --%>
                                                    <asp:DropDownList ID="ddlAmcType" class="form-control m-input" runat="server">
                                                        <asp:ListItem value="value" selected="True">--Select AMC Type--</asp:ListItem>
                                                        <asp:ListItem value="value" >Monthly</asp:ListItem>
                                                        <asp:ListItem value="value" >Quarterly</asp:ListItem>
                                                        <asp:ListItem value="value" >Annually</asp:ListItem>

                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlAmcType" Visible="true"
                                                        Display="Dynamic" ValidationGroup="validateAssetAMC" ForeColor="Red" InitialValue="0"
                                                        ErrorMessage="Please select AMC Type"></asp:RequiredFieldValidator>
                                                </div>
                                                <label id="AMC_Status1" runat="server" class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> AMC Status :</label>
                                                <div id="AMC_Status2" runat="server" class="col-xl-3 col-lg-3">
                                                    <asp:TextBox ID="txtAmcStatus" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <div id="Div24" runat="server" style="display: block;">
                                            <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                <label class="col-xl-2 col-lg-2 form-control-label">AMC Description :</label>
                                                <div class="col-xl-10 col-lg-8">
                                                    <asp:TextBox ID="txtAmcDescription" TextMode="MultiLine" runat="server" class="form-control" placeholder="Enter Detailed Description OR Summary about AMC"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtAmcDescription" Visible="true"
                                                        Display="Dynamic" ValidationGroup="validateAssetAMC" ForeColor="Red" InitialValue="0"
                                                        ErrorMessage="Please enter AMC Description"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <div id="Div15" runat="server" style="display: block;">
                                            <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                <label class="col-xl-2 col-lg-2 form-control-label"><span style=" color: red; ">*</span> AMC Start Date :</label>
                                                <div class="col-xl-3 col-lg-3 col-form-label" style="padding-top: calc(0rem + 0px);">
                                                    <div class="input-group date">
                                                        <asp:TextBox ID="txtAmcStartDate" runat="server" autocomplete="off" class="form-control m-input datepicker"
                                                            placeholder="Select Amc Start Date"></asp:TextBox>
                                                        <div class="input-group-append">
                                                            <span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
                                                        </div>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtAmcStartDate" Visible="true" Display="Dynamic"
                                                            ValidationGroup="validateAssetAMC" ForeColor="Red" InitialValue="0" ErrorMessage="Please Select Start Date"></asp:RequiredFieldValidator>
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
                                                            ValidationGroup="validateAssetAMC" ForeColor="Red" InitialValue="0" ErrorMessage="Please Select End Date"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <span id="error_AmcEndDate" class="text-danger small"></span>
                                                </div>
                                            </div>
                                        </div>


                                        <br />
                                        <div id="Div17" runat="server" style="display: block;">
                                            <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
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
                                                        Visible="true" Display="Dynamic" ValidationGroup="validateAssetAMC" ForeColor="Red" InitialValue="0"
                                                        ErrorMessage="Please select Vendor"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <div id="Div18" runat="server" style="display: block;">
                                            <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                <label class="col-xl-2 col-lg-2 form-control-label" > AMC Inclusions :</label>
                                                <div class="col-xl-4 col-lg-3" style="padding-right: 0px;" >
                                                    <asp:TextBox ID="txtAmcInclusion" TextMode="MultiLine" runat="server" class="form-control" placeholder="Summarize List of things Included Under AMC"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtAmcInclusion" Visible="true"
                                                        Display="Dynamic" ValidationGroup="validateAssetAMC" ForeColor="Red" InitialValue="0"
                                                        ErrorMessage="Please enter AMC Inclusion"></asp:RequiredFieldValidator>
                                                </div>
                                                <label class="col-xl-2 col-lg-2 form-control-label"> AMC Exclusions :</label>
                                                <div class="col-xl-4 col-lg-3" >
                                                    <asp:TextBox ID="txtAmcExclusion" TextMode="MultiLine" runat="server" class="form-control" placeholder="Summarize List of things Included Under AMC"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtAmcExclusion" Visible="true"
                                                        Display="Dynamic" ValidationGroup="validateAssetAMC" ForeColor="Red" InitialValue="0"
                                                        ErrorMessage="Please enter AMC Exclusion"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <div id="Div20" runat="server" style="display: block;">
                                            <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                <label class="col-xl-2 col-lg-2 form-control-label"> Additional Remarks :</label>
                                                <div class="col-xl-10 col-lg-6">
                                                    <asp:TextBox ID="txtAmcRemarks" TextMode="MultiLine" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <div id="Div21" runat="server" style="display: block;">
                                            <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                <label class="col-xl-2 col-lg-2 form-control-label"> AMC Documents :</label>
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

                                    </div>
                                </div>

                                <div class="m-portlet__body" style="padding: 0rem 3rem 3rem 3rem;">
                                    
                                     <br />
                                     <div class="m-form__heading" style="text-align:center; ">
										    <h3 class="m-form__heading-title" style="line-height: 2.0;background: aliceblue; font-size: 1.2rem;">Asset Scheduled Service / Maintenance Details</h3>
									    </div>
                                    </br>
                                    <div id="Div10" runat="server" style="display: block;">
                                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <div class="col-xl-1 col-lg-3" style="text-align:center; max-width: 3%;">
                                                <input type="checkbox" id="customCheck1" runat="server" checked="checked" class="customcontrolinput" name="example1" clientidmode="Static" />
                                                <asp:TextBox ID="txtHdn" TextMode="MultiLine" runat="server" ClientIDMode="Static" Width="100%" Style="display: none"></asp:TextBox>
                                            </div>
                                            <label class="col-xl-10 col-lg-2 form-control-label">Check this box if you would like to Schedule Service Dates of your Asset now</label>
                                            
                                        </div>
                                    </div>

                                    <div id="DivIsServiceSchedule">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">

                                            <ContentTemplate>
                                                <br />
                                                <div id="Div16" runat="server" style="display: block;">
                                                    <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                        <label class="col-xl-4 col-lg-2 form-control-label"><span style="color: red;">*</span> Enter No. of Service Requests to Schedule :</label>
                                                        <div class="col-xl-2 col-lg-3">
                                                            <%--<asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>--%>
                                                            <input type="number" min="1" id="txtNoOfService" class="form-control" runat="server" clientidmode="Static" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtNoOfService" Visible="true"
                                                                Display="Dynamic" ValidationGroup="validateAssetService" ForeColor="Red" InitialValue="0"
                                                                ErrorMessage="Please enter Number of Services to Schedule"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-xl-3 col-lg-3">
                                                            <asp:Button id="btnNoOfService" text="Click here to Schedule" runat="server" class="btn btn-accent m-btn m-btn--custom m-btn--icon" OnClick="btnNoOfService_Click" />
                                                        </div>
                                                        
                                                    </div>
                                                </div>

                                                <br />
                                                <div id="Div23" runat="server" style="display: block;">
                                                    <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                        <label class="col-xl-12 col-lg-2 form-control-label"><span style="color: red;">*</span> Fill in the below Details for each Service Schedule Request :</label>
                                                    </div>
                                                </div>

                                                <div id="Div19" runat="server" style="display: block;">
                                                    <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                        <div class="col-xl-12 col-lg-12">
                                                            <%-- class="table table-nomargin"--%>
                                                            <table id="TblLevels" runat="server" border="1" visible="true" clientidmode="Static" width="100%">
                                                                <thead>
                                                                    <tr>
                                                                        <th>Sr No</th>
                                                                        <th>Service Scheduled Date</th>
                                                                        <th>Assigned To</th>
                                                                        <th>Alert Before(Days)</th>
                                                                        <th style="display: none;">Remarks</th>
                                                                        <th style="display: none;">Status</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                    <tr></tr>
                                                                </tbody>
                                                            </table>

                                                        </div>
                                                    </div>
                                                </div>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                        <br />

                                    </div>

                                </div>
                            
                        <asp:Label runat="server" id="lblErrorMsg"></asp:Label>

                    </div>

                    <!-- SUCCESS PANEL -->
                    <asp:Panel ID="pnlWpReqestSuccess" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
                        <div class="" id="add_sub_location2" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                            <div class="modal-dialog" role="document" style="max-width: 590px;">
                                <div class="modal-content">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div class="modal-header">
                                                <h5 class="modal-title" id="exampleModalLabel2">Asset Details Saved Successfully</h5>
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader2">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>
                                            <div class="modal-body">
                                                <div class="form-group m-form__group row">
                                                    <label for="recipient-name" class="col-xl-12 col-lg-3 form-control-label">Your Asset Details has been saved successfully. As Unique Asset ID has been assigned as mentioned below</label>
                                                </div>
                                                <div class="form-group m-form__group row">
                                                    <label for="message-text" class="col-xl-6 col-lg-3 form-control-label font-weight-bold" style="text-align:right">Asset ID :</label>
                                                    <asp:Label ID="lblWpRequestCode" Text="" runat="server" CssClass="col-xl-6 col-lg-3 col-form-label" Style="padding-top: calc(0.15rem + 1px); margin-left: -10%; text-align:Left"></asp:Label>
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

                    <!-- Modal -->
                    <div class="modal fade" id="myModal" role="dialog">
                        <div class="modal-dialog modal-lg">
                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>

                                    <asp:HiddenField ID="hdAddAsset" runat="server" ClientIDMode="Static" />
                                    <h4 class="modal-title">
                                        <label id="lblmyModalTitle"></label>
                                    </h4>
                                </div>
                                <div class="modal-body">

                                    <br />
                                    <div id="divModalAssetType" style="display: block;">
                                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <label class="col-xl-4 col-lg-4 form-control-label"><span style="color: red;">*</span>Asset Type :</label>
                                            <div class="col-xl-8 col-lg-8">
                                                <asp:TextBox ID="txtModalAssetType" runat="server" class="form-control" ClientIDMode="Static"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtModalAssetType" Visible="true"
                                                    Display="Dynamic" ValidationGroup="validateModalAssetAmcType" ForeColor="Red" InitialValue=""
                                                    ErrorMessage="Please enter Asset Type"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <br />
                                    <div id="divModalAssetCategory" style="display: block;">
                                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <label class="col-xl-4 col-lg-4 form-control-label"><span style="color: red;">*</span> Asset Type :</label>
                                            <div class="col-xl-8 col-lg-8">
                                                <asp:DropDownList ID="ddlModalAssetType" class="form-control m-input" runat="server" ClientIDMode="Static"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="ddlModalAssetType" Visible="true"
                                                    Display="Dynamic" ValidationGroup="validateModalAssetAmcCategory" ForeColor="Red" InitialValue="0"
                                                    ErrorMessage="Please select Asset Category"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <label class="col-xl-4 col-lg-4 form-control-label"><span style="color: red;">*</span>Asset Category :</label>
                                            <div class="col-xl-8 col-lg-8">
                                                <asp:TextBox ID="txtModalAssetCategory" runat="server" class="form-control" ClientIDMode="Static"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtModalAssetCategory" Visible="true"
                                                    Display="Dynamic" ValidationGroup="validateModalAssetAmcCategory" ForeColor="Red" InitialValue=""
                                                    ErrorMessage="Please enter Asset Cost"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>


                                    <br />
                                    <div id="divModalAssetDepartment" style="display: block;">
                                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <label class="col-xl-4 col-lg-4 form-control-label"><span style="color: red;">*</span>Department :</label>
                                            <div class="col-xl-8 col-lg-8">
                                                <asp:TextBox ID="txtModalDepartment" runat="server" class="form-control" ClientIDMode="Static"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtModalDepartment" Visible="true"
                                                    Display="Dynamic" ValidationGroup="validateModalDepartment" ForeColor="Red" InitialValue=""
                                                    ErrorMessage="Please enter Department Name"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <br />
                                    <div id="divModalAssetVendor" style="display: block;">
                                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <label class="col-xl-4 col-lg-4 form-control-label"><span style="color: red;">*</span>Vendor Name :</label>
                                            <div class="col-xl-8 col-lg-8">
                                                <asp:TextBox ID="txtModalVendor_Name" runat="server" class="form-control" ClientIDMode="Static"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtModalVendor_Name" Visible="true"
                                                    Display="Dynamic" ValidationGroup="validateModalVendor" ForeColor="Red" InitialValue=""
                                                    ErrorMessage="Please enter Vendor Name"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <label class="col-xl-4 col-lg-4 form-control-label"><span style="color: red;">*</span>Vendor Description :</label>
                                            <div class="col-xl-8 col-lg-8">
                                                <asp:TextBox ID="txtModalVendor_Desc" TextMode="MultiLine" runat="server" class="form-control" ClientIDMode="Static"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtModalVendor_Desc" Visible="true"
                                                    Display="Dynamic" ValidationGroup="validateModalVendor" ForeColor="Red" InitialValue=""
                                                    ErrorMessage="Please enter Vendor Description"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <label class="col-xl-4 col-lg-4 form-control-label"><span style="color: red;">*</span>Vendor Address :</label>
                                            <div class="col-xl-8 col-lg-8">
                                                <asp:TextBox ID="txtModalVendor_Address" runat="server" TextMode="MultiLine" class="form-control" ClientIDMode="Static"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtModalVendor_Address" Visible="true"
                                                    Display="Dynamic" ValidationGroup="validateModalVendor" ForeColor="Red" InitialValue=""
                                                    ErrorMessage="Please enter Vendor Name"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <label class="col-xl-4 col-lg-4 form-control-label"><span style="color: red;">*</span>Vendor Contact 1 :</label>
                                            <div class="col-xl-8 col-lg-8">
                                                <asp:TextBox ID="txtModalVendor_Contact1" runat="server" TextMode="Number" class="form-control" ClientIDMode="Static"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtModalVendor_Contact1" Visible="true"
                                                    Display="Dynamic" ValidationGroup="validateModalVendor" ForeColor="Red" InitialValue=""
                                                    ErrorMessage="Please enter Contact 2"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <label class="col-xl-4 col-lg-4 form-control-label"><span style="color: red;">*</span>Vendor Contact 2 :</label>
                                            <div class="col-xl-8 col-lg-8">
                                                <asp:TextBox ID="txtModalVendor_Contact2" runat="server" TextMode="Number" class="form-control" ClientIDMode="Static"></asp:TextBox>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtModalVendor_Contact2" Visible="true"
                                                    Display="Dynamic" ValidationGroup="validateModalVendor" ForeColor="Red" InitialValue=""
                                                    ErrorMessage="Please enter Contact 1"></asp:RequiredFieldValidator>--%>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <label class="col-xl-4 col-lg-4 form-control-label"><span style="color: red;">*</span>Vendor Email :</label>
                                            <div class="col-xl-8 col-lg-8">
                                                <asp:TextBox ID="txtModalVendor_Email" runat="server" TextMode="Email" class="form-control" ClientIDMode="Static"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtModalVendor_Email" Visible="true"
                                                    Display="Dynamic" ValidationGroup="validateModalVendor" ForeColor="Red" InitialValue=""
                                                    ErrorMessage="Please enter Email ID"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>



                                    <div id="divModalAssetErrorMessage" style="display: block;">
                                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <label class="col-xl-10 col-lg-10 form-control-label" style="display: none; font-size: large; font-weight: bold; color: red"
                                                id="lblModalAssetErrorMessage" runat="server" clientidmode="Static">
                                            </label>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <div id="divModalAssetTypeSave">
                                        <button type="submit" runat="server" id="ModalAssetTypeSave" onserverclick="btnModalAssetSave_Click" class="btn btn-accent mr-auto"
                                            validationgroup="validateModalAssetAmcType" causesvalidation="true">
                                            Save</button>
                                    </div>
                                    <div id="divModalAssetCategorySave">
                                        <button type="submit" runat="server" id="ModalAssetCategorySave" onserverclick="btnModalAssetSave_Click" class="btn btn-accent mr-auto"
                                            validationgroup="validateModalAssetAmcCategory" causesvalidation="true">
                                            Save</button>
                                    </div>
                                    <div id="divModalDepartmentSave">
                                        <button type="submit" runat="server" id="Button2" onserverclick="btnModalAssetSave_Click" class="btn btn-accent mr-auto"
                                            validationgroup="validateModalDepartment" causesvalidation="true">
                                            Save</button>
                                    </div>
                                    <div id="divModalVendorSave">
                                        <button type="submit" runat="server" id="Button3" onserverclick="btnModalAssetSave_Click" class="btn btn-accent mr-auto"
                                            validationgroup="validateModalVendor" causesvalidation="true">
                                            Save</button>
                                    </div>

                                    <%-- <asp:Button ID="btnModalSave" runat="server" Text="Save" class="btn btn-accent mr-auto"
                                        ValidationGroup="validateAssetModal"  CausesValidation="true" /> --%>
                                    <%--<button type="button" runat="server" id="btnModalAssetSave" onserverclick="btnModalAssetSave_Click" class="btn btn-accent mr-auto">Save</button>--%>
                                    <button type="button" runat="server" class="btn btn-default" data-dismiss="modal">Close</button>
                                </div>
                            </div>
                        </div>
                    </div>


                    <!-- Image Display -->

                    <%--data-images="<%#Eval("Header_Data") %>"--%>
                    <%-- <div id="divImgBtns" style="display: none" runat="server">
                        <button id='btnImg' type='button' data-toggle='modal' data-target="#exampleModal" class='btn btn-accent m-btn m-btn--icon'
                            data-images="<%#Eval("ImagePath") %>" data-container='body' style="width: 41px; height: 41px;" data-placement='top' title='View Uploaded Image'>
                            <i class='la la-image' style="margin-left: -106%; font-size: 2.3rem;"></i>
                        </button>
                        <asp:HiddenField ID="hdnImg" runat="server" ClientIDMode="Static" />
                    </div>--%>

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
