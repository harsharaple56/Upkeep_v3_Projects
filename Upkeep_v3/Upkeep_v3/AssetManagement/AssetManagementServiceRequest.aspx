<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="AssetManagementServiceRequest.aspx.cs" Inherits="Upkeep_v3.AssetManagement.AssetManagementServiceRequest" EnableEventValidation = "false" %>

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
            });

            $("#Button1").on('click', function (e) {
                e.preventDefault();

                var value = <%= Session["ActionType"].ToString() %>;

                if (value == 0) {

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
                                        <h3 class="m-portlet__head-text">Asset Management Service</h3>
                                    </div>
                                </div>

                                <div class="m-portlet__head-tools" style="width: 28%;">
                                    <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
                                    <a href="<%= Page.ResolveClientUrl( Session["PreviousURL"].ToString()) %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                        <%--<%= Page.ResolveClientUrl( Session["PreviousURL"].ToString()) %>--%>
                                        <%--<%= Page.ResolveClientUrl("~/AssetManagement/AssetManagementServiceList.aspx") %>--%>
                                        <span>
                                            <i class="la la-arrow-left"></i>
                                            <span>Back</span>
                                        </span>
                                    </a>
                                    <div class="btn-group">

                                        <asp:Button ID="Button1" TYPE="button" Text="Save" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md"
                                            ClientIDMode="Static" />
                                        <%--OnClientClick="return FunSetXML();" --%>
                                        
                                        
                                         <asp:Button ID="btnClose" TYPE="button" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" ClientIDMode="Static"
                                            CausesValidation="true" ValidationGroup="validateAssetServiceClose" Text="Close" OnClick="btnSave_Click" Style="display: none" />

                                        <asp:Button ID="btnSaveEdit" TYPE="button" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" ClientIDMode="Static"
                                            CausesValidation="true" ValidationGroup="validateAssetService" Text="Save" OnClick="btnSave_Click" Style="display: none" />

                                        <asp:Button ID="btnSave" TYPE="button" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" ClientIDMode="Static"
                                            CausesValidation="true" ValidationGroup="validateAssetAddService" Text="Save" OnClick="btnSave_Click" Style="display: none" />

                                        <asp:Button ID="btnTest" Style="display: none;" runat="server" />
                                        <cc1:ModalPopupExtender ID="mpeWpRequestSaveSuccess" runat="server" PopupControlID="pnlWpReqestSuccess" TargetControlID="btnTest"
                                            CancelControlID="btnCloseHeader2" BackgroundCssClass="modalBackground">
                                        </cc1:ModalPopupExtender>
                                    </div>
                                </div>

                            </div>
                        </div>


                        <div class="m-portlet__body" style="padding: 0.4rem 2.2rem;">

                            <div class="m-portlet__body" style="padding: 0.3rem 2.2rem;">

                                <div class="m-portlet__body" style="padding: 0.3rem 2.2rem;">
                                    <br />
                                    <div id="DivIsServiceSchedule" runat="server">
                                        <div id="dvAssetType" runat="server" style="display: block;">
                                            <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Asset Type :</label>
                                                <div class="col-xl-3 col-lg-3">
                                                    <asp:DropDownList ID="ddlAssetType" class="form-control m-input" runat="server">
                                                    </asp:DropDownList>
                                                  <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlAssetType" Visible="true"
                                                        Display="Dynamic" ValidationGroup="validateAsset" ForeColor="Red" InitialValue="0"
                                                        ErrorMessage="Please select Asset Type"></asp:RequiredFieldValidator>--%>
                                                </div>
                                                <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Asset Category :</label>
                                                <div class="col-xl-3 col-lg-3">
                                                    <asp:DropDownList ID="ddlAssetCategory" class="form-control m-input" runat="server">
                                                    </asp:DropDownList>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlAssetCategory" Visible="true"
                                                        Display="Dynamic" ValidationGroup="validateAsset" ForeColor="Red" InitialValue="0"
                                                        ErrorMessage="Please select Asset Category"></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <div id="Div1" runat="server" style="display: block;">
                                            <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Asset Name :</label>
                                                <div class="col-xl-3 col-lg-3">
                                                    <asp:TextBox ID="txtAssetName" runat="server" class="form-control"></asp:TextBox>
                                                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAssetName" Visible="true"
                                                        Display="Dynamic" ValidationGroup="validateAsset" ForeColor="Red" InitialValue=""
                                                        ErrorMessage="Please enter Asset Name"></asp:RequiredFieldValidator>--%>
                                                </div>

                                                <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Asset Description :</label>
                                                <div class="col-xl-3 col-lg-3">
                                                    <asp:TextBox ID="txtAssetDescription" TextMode="MultiLine" runat="server" class="form-control"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAssetDescription" Visible="true"
                                                        Display="Dynamic" ValidationGroup="validateAsset" ForeColor="Red" InitialValue=""
                                                        ErrorMessage="Please enter Asset Description"></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <div id="Div2" runat="server" style="display: block;">
                                            <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Service :</label>
                                                <div class="col-xl-3 col-lg-3">
                                                </div>
                                                <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Service Status :</label>
                                                <div class="col-xl-3 col-lg-3">
                                                    <asp:TextBox ID="txtServiceStatus" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div id="Div3" runat="server" style="display: block;">
                                            <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Service Assign To :</label>
                                                <div class="col-xl-8 col-lg-8">
                                                    <asp:DropDownList ID="ddlServiceAssignTo" class="form-control m-input" runat="server"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlServiceAssignTo" Visible="true"
                                                        Display="Dynamic" ValidationGroup="validateAssetService" ForeColor="Red" InitialValue="0"
                                                        ErrorMessage="Please enter Asset Name"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <div id="Div4" runat="server" style="display: block;">
                                            <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Service Date :</label>
                                                <div class="col-xl-3 col-lg-3">
                                                    <div class="input-group date">
                                                        <asp:TextBox ID="txtServiceDate" runat="server" autocomplete="off" class="form-control m-input datepicker"
                                                            placeholder="Select Service Date"></asp:TextBox>
                                                        <div class="input-group-append">
                                                            <span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
                                                        </div>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtServiceDate" Visible="true" Display="Dynamic"
                                                            ValidationGroup="validateAssetService" ForeColor="Red" InitialValue="0" ErrorMessage="Please Service Date"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <span id="error_ServiceDate" class="text-danger small"></span>
                                                </div>

                                                <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Alert Date :</label>
                                                <div class="col-xl-3 col-lg-3">
                                                    <div class="input-group date">
                                                        <asp:TextBox ID="txtAlertDate" runat="server" autocomplete="off" class="form-control m-input datepicker"
                                                            placeholder="Select Purchase Date"></asp:TextBox>
                                                        <div class="input-group-append">
                                                            <span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
                                                        </div>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAlertDate" Visible="true" Display="Dynamic"
                                                            ValidationGroup="validateAssetService" ForeColor="Red" InitialValue="0" ErrorMessage="Please Alert Date"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <span id="error_AlertDate" class="text-danger small"></span>
                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <div id="divServiceRemarks" runat="server" style="display: block;">
                                            <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Service Remarks :</label>
                                                <div class="col-xl-8 col-lg-8">
                                                    <asp:TextBox ID="txtServiceRemarks" runat="server" autocomplete="off" class="form-control m-input"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtServiceRemarks" Visible="true"
                                                        Display="Dynamic" ValidationGroup="validateAssetServiceClose" ForeColor="Red" InitialValue=""
                                                        ErrorMessage="Please enter Closing Remarks"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <br />
                                        <div id="divCloseRemarks" runat="server" style="display: block;">
                                            <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Service Closing Remarks :</label>
                                                <div class="col-xl-8 col-lg-8">
                                                    <asp:TextBox ID="txtServiceClosingRemarks" runat="server" autocomplete="off" class="form-control m-input"></asp:TextBox>
                                                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtServiceClosingRemarks" Visible="true"
                                                        Display="Dynamic" ValidationGroup="validateAsset" ForeColor="Red" InitialValue="0"
                                                        ErrorMessage="Please enter Asset Name"></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>

                                <div class="m-portlet__body" style="padding: 0.3rem 2.2rem;">
                                    <br />
                                    <div id="DivAddServiceSchedule" runat="server">
                                        <div id="Div10" runat="server" style="display: block;">
                                            <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                <%--<label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Schedule Service : </label>--%>
                                                <div class="col-xl-3 col-lg-3">
                                                    <%--<input type="checkbox" id="customCheck1" runat="server" class="customcontrolinput" name="example1" clientidmode="Static" />--%>
                                                    <asp:TextBox ID="txtHdn" TextMode="MultiLine" runat="server" ClientIDMode="Static" Width="100%" Style="display: none"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="Div6" runat="server" style="display: block;">
                                            <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Asset Name :</label>
                                                <div class="col-xl-3 col-lg-3">
                                                    <asp:DropDownList ID="ddlAssetName" class="form-control m-input" runat="server">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlAssetName" Visible="true"
                                                        Display="Dynamic" ValidationGroup="validateAssetAddService" ForeColor="Red" InitialValue="0"
                                                        ErrorMessage="Please select Asset Type"></asp:RequiredFieldValidator>
                                                </div>
                                               
                                            </div>
                                        </div>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">

                                            <ContentTemplate>
                                                <br />
                                                <div id="Div16" runat="server" style="display: block;">
                                                    <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                        <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> No. of Services :</label>
                                                        <div class="col-xl-3 col-lg-3">
                                                            <%--<asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>--%>
                                                            <input type="number" min="1" id="txtNoOfService" class="form-control" runat="server" clientidmode="Static" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtNoOfService" Visible="true"
                                                                Display="Dynamic" ValidationGroup="validateAssetAddService" ForeColor="Red" InitialValue="0"
                                                                ErrorMessage="Please enter Asset Cost"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-xl-3 col-lg-3">
                                                            <asp:Button ID="btnNoOfService" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md"
                                                                Text="Submit" OnClick="btnNoOfService_Click" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <br />
                                                <div id="Div23" runat="server" style="display: block;">
                                                    <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                        <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span>Services :</label>
                                                    </div>
                                                </div>

                                                <div id="Div19" runat="server" style="display: block;">
                                                    <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                        <div class="col-xl-10 col-lg-10">
                                                            <%-- class="table table-nomargin"--%>
                                                            <table id="TblLevels" runat="server" border="1" visible="true" clientidmode="Static" width="100%">
                                                                <thead>
                                                                    <tr>
                                                                        <th>Sr No</th>
                                                                        <th>Schedule Date</th>
                                                                        <th>Assigned To</th>
                                                                        <th>Alert Before(Days)</th>
                                                                        <th>Remarks</th>
                                                                        <th>Status</th>
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
                                                <h5 class="modal-title" id="exampleModalLabel2">Asset Service Request Confirmation</h5>
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader2">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>
                                            <div class="modal-body">
                                                <div class="form-group m-form__group row">
                                                    <label for="recipient-name" class="col-xl-8 col-lg-3 form-control-label">Asset Service Request has been saved successfully</label>
                                                </div>
                                                <div class="form-group m-form__group row">
                                                    <label for="message-text" class="col-xl-5 col-lg-3 form-control-label font-weight-bold">Service ID :</label>
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



                </div>
            </div>
        </div>
    </div>
</asp:Content>
