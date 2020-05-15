<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Locations_Mst.aspx.cs" Inherits="Upkeep_v3.General_Masters.Locations_Mst" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<script src="vendors/jquery/dist/jquery.js" type="text/javascript"></script>--%>
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript" ></script>
    
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

        .highlight {
            background-color: blanchedalmond;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#tblZone tr").click(function () {

                //alert($("#tblZone tr").index(this));
                var table = document.getElementById("tblZone");
                var rowID = $("#tblZone tr").index(this);

                var row = table.rows[rowID];
                var ZoneID;

                ZoneID = row.cells[0].innerHTML;
                ZoneID = ZoneID.substring(0, ZoneID.indexOf(' -'));

                $("#hdnZone").val(ZoneID);
                $("#hdnZoneName").val(ZoneID);

                $("#lblZoneName").text(ZoneID);
                document.getElementById("hdnTxtZone").value = ZoneID;
                //$("#lblZoneName").text(ZoneID); 
                //alert(ZoneID);
                var selected = $(this).hasClass("highlight");
                $("#tblZone tr").removeClass("highlight");
                if (!selected)
                    $(this).addClass("highlight");


                //alert('asdasdas');

                var obj = {};

                var dataString = { 'Zone': ZoneID };
                var param = JSON.stringify(dataString);

                //debugger;
                $.ajax({
                    type: 'POST',
                    url: 'Locations_Mst.aspx/Location_bindgrid1',
                    //data: '{EmpId :' + empId + '}',
                    //data: JSON.stringify(obj),
                    //data: dataString,
                    data: param,
                    //data: '',
                    contentType: 'application/json; charset=utf-8',
                    datatype: 'json',
                    //async: true,
                    //cache: false,
                    success: function (response) {
                        //alert('Success');
                        location.reload(true);
                    },
                    error: function (xhr, status, error) {

                        //alert(xhr.responseText);  // to see the error message
                    }
                });




            });


            $("#tblLocation tr").click(function () {

                //alert($("#tblZone tr").index(this));
                var table = document.getElementById("tblLocation");
                var rowID = $("#tblLocation tr").index(this);

                var row = table.rows[rowID];
                var Location;

                Location = row.cells[0].innerHTML;
                Location = Location.substring(0, Location.indexOf(' -'));

                $("#hdnLocation").val(Location);

                //alert(Location);
                //document.getElementById("lblLocation").val = Location;
                $("#lblLocation").text(Location);
                document.getElementById("hdnTxtLocation").value = Location;

                var selected = $(this).hasClass("highlight");
                $("#tblLocation tr").removeClass("highlight");
                if (!selected)
                    $(this).addClass("highlight");


                //alert('asdasdas');

                var obj = {};

                var dataString = { 'Location': Location };
                var param = JSON.stringify(dataString);

                //debugger;
                $.ajax({
                    type: 'POST',
                    url: 'Locations_Mst.aspx/SubLocation_bindgrid1',
                    //data: '{EmpId :' + empId + '}',
                    //data: JSON.stringify(obj),
                    //data: dataString,
                    data: param,
                    //data: '',
                    contentType: 'application/json; charset=utf-8',
                    datatype: 'json',
                    //async: true,
                    //cache: false,
                    success: function (response) {
                        //alert('Success');
                        location.reload(true);
                    },
                    error: function (xhr, status, error) {

                        //alert(xhr.responseText);  // to see the error message
                    }
                });




            });


        });

        function HighlightZoneTable() {
            $("#tblZone tr").click(function () {

                //alert($("#tblZone tr").index(this));
                var table = document.getElementById("tblZone");
                var rowID = $("#tblZone tr").index(this);

                var row = table.rows[rowID];
                var ZoneID;

                ZoneID = row.cells[0].innerHTML;
                ZoneID = ZoneID.substring(0, ZoneID.indexOf(' -'));



                //alert('asdasdas');

                //alert(ZoneID);
                var selected = $(this).hasClass("highlight");

                //alert(selected);
                $(this).addClass("highlight");

                $("#tblZone tr").removeClass("highlight");
                if (!selected)
                    $(this).addClass("highlight");
            });
        }

    </script>
    <body>

        <!-- begin::Body -->
        <%--<div class="m-grid__item m-grid__item--fluid m-grid m-grid--ver-desktop m-grid--desktop m-body">--%>

        <div runat="server" id="FrmMain">
            <cc1:ToolkitScriptManager runat="server">
            </cc1:ToolkitScriptManager>

            <asp:HiddenField ID="hdnZone" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdnLocation" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdnZoneName" runat="server" ClientIDMode="Static" />
            <asp:TextBox ID="hdnTxtLocation" runat="server" style="display:none;" ClientIDMode="Static" ></asp:TextBox>
            <asp:TextBox ID="hdnTxtZone" runat="server" style="display:none;" ClientIDMode="Static" ></asp:TextBox>
            <%-- <asp:ScriptManager ID="scriptmanager1" runat="server">
        </asp:ScriptManager>--%>

            <div class="m-grid__item m-grid__item--fluid m-wrapper">



                <div class="">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="m-portlet">
                                <div class="m-portlet__head p-3">
                                    <div class="m-portlet__head-caption">
                                        <div class="m-portlet__head-title">
                                            <span class="m-portlet__head-icon">
                                                <i class="flaticon-placeholder-2"></i>
                                            </span>
                                            <h3 class="m-portlet__head-text">Zones
                                            </h3>
                                        </div>
                                    </div>
                                    <div class="m-portlet__head-tools">
                                        <ul class="m-portlet__nav">
                                            <li class="m-portlet__nav-item">
                                                <%--<a href="#add_zone" class="m-portlet__nav-link m-portlet__nav-link--icon" data-toggle="modal"><i class="la la-plus"></i></a>--%>
                                                <asp:Button ID="btnAddZone" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="+" OnClick="btnAddZone_Click" />
                                                <cc1:ModalPopupExtender ID="mpeZone" runat="server" PopupControlID="pnlAddZone" TargetControlID="btnAddZone"
                                                    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                            </li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="m-portlet__body py-1 px-2">
                                    <table id="tblZone" class="table m-table table-sm table-hover">
                                        <tbody>

                                            <%=Zone_bindgrid()%>

                                            <%--<tr class="cursor-pointer">
                                                <td>Zone 1
													
                                            <span class="pull-right">
                                                <a href="javascript:;" class="text-success"><i class="fa fa-edit fa-fw"></i></a>
                                                <a href="javascript:;" class="text-danger" data-toggle="confirmation"><i class="fa fa-trash fa-fw"></i></a>
                                                <i class="fa fa-caret-right fa-fw invisible"></i>
                                            </span>
                                                </td>
                                            </tr>--%>


                                            <%--  <tr class="table-secondary">
                                        <td>Zone 2
													
                                            <span class="pull-right">
                                                <a href="javascript:;" class="text-success"><i class="fa fa-edit fa-fw"></i></a>
                                                <a href="javascript:;" class="text-danger" data-toggle="confirmation"><i class="fa fa-trash fa-fw"></i></a>
                                                <i class="fa fa-caret-right fa-fw"></i>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr class="cursor-pointer">
                                        <td>Zone 3
													
                                            <span class="pull-right">
                                                <a href="javascript:;" class="text-success"><i class="fa fa-edit fa-fw"></i></a>
                                                <a href="javascript:;" class="text-danger" data-toggle="confirmation"><i class="fa fa-trash fa-fw"></i></a>
                                                <i class="fa fa-caret-right fa-fw invisible"></i>
                                            </span>
                                        </td>
                                    </tr>--%>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="m-portlet">
                                <div class="m-portlet__head p-3">
                                    <div class="m-portlet__head-caption">
                                        <div class="m-portlet__head-title">
                                            <span class="m-portlet__head-icon">
                                                <i class="flaticon-placeholder-2"></i>
                                            </span>
                                            <h3 class="m-portlet__head-text">Locations
                                            </h3>
                                        </div>
                                    </div>
                                    <div class="m-portlet__head-tools">
                                        <ul class="m-portlet__nav">
                                            <li class="m-portlet__nav-item">
                                                <%--<a href="#add_location" class="m-portlet__nav-link m-portlet__nav-link--icon" data-toggle="modal"><i class="la la-plus"></i></a>--%>
                                                <asp:Button ID="btnAddLocation" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="+" OnClick="btnAddLocation_Click" />
                                                <cc1:ModalPopupExtender ID="mpeLocation" runat="server" PopupControlID="pnlAddLocation" TargetControlID="btnAddLocation"
                                                    CancelControlID="btnCloseLoc" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                            </li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="m-portlet__body py-1 px-2">
                                    <table id="tblLocation" class="table m-table table-sm">
                                        <tbody>

                                            <%=Location_bindgrid()%>

                                            <%--<tr class="cursor-pointer">
                                                <td>Location 1
													
                                            <span class="pull-right">
                                                <a href="javascript:;" class="text-success"><i class="fa fa-edit fa-fw"></i></a>
                                                <a href="javascript:;" class="text-danger" data-toggle="confirmation"><i class="fa fa-trash fa-fw"></i></a>
                                                <i class="fa fa-caret-right fa-fw invisible"></i>
                                            </span>
                                                </td>
                                            </tr>--%>

                                            <%--<tr class="cursor-pointer">
                                        <td>Location 2
													
                                            <span class="pull-right">
                                                <a href="javascript:;" class="text-success"><i class="fa fa-edit fa-fw"></i></a>
                                                <a href="javascript:;" class="text-danger" data-toggle="confirmation"><i class="fa fa-trash fa-fw"></i></a>
                                                <i class="fa fa-caret-right fa-fw invisible"></i>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr class="table-secondary">
                                        <td>Location 3
													
                                            <span class="pull-right">
                                                <a href="javascript:;" class="text-success"><i class="fa fa-edit fa-fw"></i></a>
                                                <a href="javascript:;" class="text-danger" data-toggle="confirmation"><i class="fa fa-trash fa-fw"></i></a>
                                                <i class="fa fa-caret-right fa-fw"></i>
                                            </span>
                                        </td>
                                    </tr>--%>
                                        </tbody>
                                    </table>


                                    <%--<asp:GridView ID="gvLocation" runat="server" CssClass="table m-table table-sm" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundField DataField="Location" HeaderText="Location" ItemStyle-Width="150px" />
                                        </Columns>
                                    </asp:GridView>--%>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="m-portlet">
                                <div class="m-portlet__head p-3">
                                    <div class="m-portlet__head-caption">
                                        <div class="m-portlet__head-title">
                                            <span class="m-portlet__head-icon">
                                                <i class="flaticon-placeholder-2"></i>
                                            </span>
                                            <h3 class="m-portlet__head-text">Sub-locations
                                            </h3>
                                        </div>
                                    </div>
                                    <div class="m-portlet__head-tools">
                                        <ul class="m-portlet__nav">
                                            <li class="m-portlet__nav-item">
                                                <%--<a href="#add_sub_location" class="m-portlet__nav-link m-portlet__nav-link--icon" data-toggle="modal"><i class="la la-plus"></i></a>--%>

                                                <asp:Button ID="btnSubLocation" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="+" OnClick="btnSubLocation_Click" />
                                                <cc1:ModalPopupExtender ID="mpeSubLocation" runat="server" PopupControlID="pnlAddSubLocation" TargetControlID="btnSubLocation"
                                                    CancelControlID="btnCloseSubLoc" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                            </li>
                                        </ul>
                                    </div>
                                </div>
                                <div class="m-portlet__body py-1 px-2">
                                    <table class="table m-table table-sm">
                                        <tbody>

                                              <%=SubLocation_bindgrid()%>

                                            <%--<tr class="cursor-pointer">
                                                <td>Sub-location 1
													
                                            <span class="pull-right">
                                                <a href="javascript:;" class="text-success"><i class="fa fa-edit fa-fw"></i></a>
                                                <a href="javascript:;" class="text-danger" data-toggle="confirmation"><i class="fa fa-trash fa-fw"></i></a>
                                            </span>
                                                </td>
                                            </tr>--%>
                                            <%--<tr class="cursor-pointer">
                                        <td>Sub-location 2
													
                                            <span class="pull-right">
                                                <a href="javascript:;" class="text-success"><i class="fa fa-edit fa-fw"></i></a>
                                                <a href="javascript:;" class="text-danger" data-toggle="confirmation"><i class="fa fa-trash fa-fw"></i></a>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr class="table-secondary">
                                        <td>Sub-location 3
													
                                            <span class="pull-right">
                                                <a href="javascript:;" class="text-success"><i class="fa fa-edit fa-fw"></i></a>
                                                <a href="javascript:;" class="text-danger" data-toggle="confirmation"><i class="fa fa-trash fa-fw"></i></a>
                                            </span>
                                        </td>
                                    </tr>--%>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%--</div>--%>

            <!-- Start Modal -->

            <asp:Panel ID="pnlAddZone" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
                <div class="" id="add_zone" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog modal-sm" role="document">

                        <%-- <asp:ScriptManager ID="scriptmanager2" runat="server">
                </asp:ScriptManager>--%>


                        <div class="modal-content">

                            <asp:UpdatePanel ID="updatepnl" runat="server">
                                <ContentTemplate>

                                    <div class="modal-header">
                                        <h5 class="modal-title" id="exampleModalLabel">Add New Zone</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <%--<span aria-hidden="true">&times;</span>--%>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <%-- <form>--%>
                                        <div class="form-group">
                                            <label for="recipient-name" class="form-control-label">Zone code:</label>

                                            <asp:TextBox ID="txtZoneCode" runat="server" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvZoneCode" runat="server" ControlToValidate="txtZoneCode" Visible="true" ValidationGroup="validationZone" ForeColor="Red" ErrorMessage="Please enter Zone code"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label for="message-text" class="form-control-label">Zone Description:</label>
                                            <%--<textarea class="form-control" id="message-text"></textarea>--%>
                                            <asp:TextBox ID="txtZoneDesc" runat="server" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtZoneDesc" Visible="true" ValidationGroup="validationZone" ForeColor="Red" ErrorMessage="Please enter Zone Desc"></asp:RequiredFieldValidator>

                                        </div>
                                        <%--</form>--%>
                                    </div>

                                    <div class="form-group m-form__group row">
                                        <div class="col-xl-9 col-lg-9">
                                            <asp:Label ID="lblZoneErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="modal-footer">
                                        <%--<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>--%>
                                        <asp:Button ID="btnClose" Text="Close" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnClose_Click" />
                                        <asp:Button ID="btnZoneSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" CausesValidation="true" ValidationGroup="validationZone" OnClick="btnZoneSave_Click" Text="Save" />
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnZoneSave" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>

                        </div>

                    </div>
                </div>

            </asp:Panel>

            <asp:Panel ID="pnlAddLocation" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
                <div class="" id="add_location" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog modal-sm" role="document">
                        <div class="modal-content">

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>

                                    <div class="modal-header">
                                        <h5 class="modal-title" id="exampleModalLabel">Add new location</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <%--<span aria-hidden="true">&times;</span>--%>
                                        </button>
                                    </div>
                                    <div class="modal-body">

                                        <div class="form-group">
                                            <label for="recipient-name" class="form-control-label">Location code:</label>
                                            <asp:TextBox ID="txtLocationCode" runat="server" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLocationCode" Visible="true" ValidationGroup="validationLocation" ForeColor="Red" ErrorMessage="Please enter Location code"></asp:RequiredFieldValidator>

                                        </div>
                                        <div class="form-group">
                                            <label for="message-text" class="form-control-label">Description:</label>
                                            <asp:TextBox ID="txtLocation" runat="server" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLocation" Visible="true" ValidationGroup="validationLocation" ForeColor="Red" ErrorMessage="Please enter Location"></asp:RequiredFieldValidator>

                                        </div>

                                    </div>
                                    <div class="form-group m-form__group row">
                                        <div class="col-xl-9 col-lg-9">
                                            <asp:Label ID="lblLocationErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="modal-footer">
                                        <asp:Button ID="btnCloseLoc" Text="Close" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnCloseLoc_Click" />
                                        <asp:Button ID="btnLocationSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" CausesValidation="true" ValidationGroup="validationLocation" OnClick="btnLocationSave_Click" Text="Save" />

                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnZoneSave" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>

            </asp:Panel>

            <asp:Panel ID="pnlAddSubLocation" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
                <div class="" id="add_sub_location" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document" style="max-width: 476px;">
                        <div class="modal-content">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>

                                    <div class="modal-header">
                                        <h5 class="modal-title" id="exampleModalLabel">Add new sub-location</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <%--<span aria-hidden="true">&times;</span>--%>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <div class="form-group m-form__group row">
                                            <label for="recipient-name" class="col-xl-4 col-lg-3 form-control-label">Zone :</label>
                                            <asp:Label ID="lblZoneName" Text="" ClientIDMode="Static" runat="server" class="form-control-label" Style="font-weight:bold"></asp:Label>
                                        </div>
                                        <div class="form-group m-form__group row">
                                            <label for="recipient-name" class="col-xl-4 col-lg-3 form-control-label">Location :</label>
                                            <asp:Label ID="lblLocation" Text="" ClientIDMode="Static" runat="server" class="form-control-label" Style="font-weight:bold"></asp:Label>
                                        </div>

                                        <div class="form-group m-form__group row">
                                            <label for="recipient-name" class="col-xl-4 col-lg-3 form-control-label">Sub-location code:</label>
                                            <asp:TextBox ID="txtSubLocationCode" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSubLocationCode" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationSubLoc" ForeColor="Red" ErrorMessage="Please enter Sub Location code"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group m-form__group row">
                                            <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Description:</label>
                                            <%--<textarea class="form-control" id="message-text"></textarea>--%>
                                            <asp:TextBox ID="txtSubLocation" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSubLocation" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationSubLoc" ForeColor="Red" ErrorMessage="Please enter Sub Location"></asp:RequiredFieldValidator>

                                        </div>
                                        <asp:Label ID="lblSubLocationErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                    </div>
                                    <%--<div class="form-group m-form__group row">
                                        <div class="col-xl-9 col-lg-9">
                                            <asp:Label ID="Label1" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>--%>

                                    <div class="modal-footer">
                                        <asp:Button ID="btnCloseSubLoc" Text="Close" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnCloseSubLoc_Click" />
                                        <asp:Button ID="btnSubLocationSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" CausesValidation="true" ValidationGroup="validationSubLoc" OnClick="btnSubLocationSave_Click" Text="Save" />

                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnSubLocationSave" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <!-- End Modal -->
            </asp:Panel>
            <!-- end:: Body -->





            <!-- begin::Scroll Top -->
            <div id="m_scroll_top" class="m-scroll-top">
                <i class="la la-arrow-up"></i>
            </div>

            <!-- end::Scroll Top -->

        </div>
    </body>
    
</asp:Content>
