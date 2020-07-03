<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Add_License.aspx.cs" Inherits="Upkeep_v3_Control_Center.Add_License" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <%-- <script src="<%= Page.ResolveClientUrl("~/assets/vendors/custom/fullcalendar/fullcalendar.bundle.js") %>" type="text/javascript"></script>--%>
    <script src="<%= Page.ResolveClientUrl("~/assets1/demo/default/custom/crud/forms/widgets/bootstrap-datetimepicker.js") %>" type="text/javascript"></script>

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
        //function init_autosize() {
        //    var autosize_textarea = $('.autosize_textarea');
        //    autosize(autosize_textarea);
        //    autosize.update(autosize_textarea);
        //}

        $(document).ready(function () {
            //init_autosize();
            //init_plugins();
            BootstrapTimepicker.init()
            //$('.datetimepicker').datetimepicker({
            //    todayHighlight: true,
            //    autoclose: true,
            //    pickerPosition: 'bottom-right',
            //    format: 'dd/mm/yyyy',
            //    //showMeridian: true,
            //   // ActivationDate: moment().format('YYYY-MM-DD'),
            //}).on('changeDate', function (event) {
            //    var ActivationDate = moment($('#ActivationDate').val(), 'DD/MM/YYYY').valueOf();
            //    //alert(ActivationDate.val);
            //    //var endDate = moment($('#endDate').val(), 'DD/MM/YYYY hh:mm A').valueOf();
            //    //$('#error_endDate').html('').parents('.form-group').removeClass('has-error');
            //    //if (endDate < startDate) {
            //    //    $('#error_endDate').html('Event end date-time can not be before the start date.').parents('.form-group').addClass('has-error');
            //    //}
            //});

            //$('.datetimepicker').on('click', function () {

            //    if ($(this).is('#ActivationDate')) {
            //        //$('#endDate').datetimepicker('hide');
            //    }
            //    //if ($(this).is('#endDate')) {
            //    //    $('#startDate').datetimepicker('hide');
            //    //}
            //});



        });

        var BootstrapTimepicker = {
            init: function () {
                $("#ActivationDate").datetimepicker(
                    { format: "dd/mm/yyyy", todayHighlight: !0, autoclose: !0, startView: 2, minView: 2, forceParse: 0, pickerPosition: "bottom-left" }
                    //, { minDate: today }
                );
                $('#ActivationDate').datetimepicker({
                    minDate:new Date()
                });
            }
        };

      

    </script>



    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <form class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" runat="server" id="frmLicense" method="post">
                        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
                        <div class="m-form m-form--label-align-left- m-form--state-" id="employee_form">
                            <div class="m-portlet__head">
                                <div class="m-portlet__head-progress">

                                    <!-- here can place a progress bar-->
                                </div>
                                <div class="m-portlet__head-wrapper">
                                    <div class="m-portlet__head-caption">
                                        <div class="m-portlet__head-title">
                                            <h3 class="m-portlet__head-text">License Details
                                            </h3>
                                        </div>
                                    </div>

                                    <div class="m-portlet__head-tools">
                                        <a href="<%= Page.ResolveClientUrl("~/License_Management.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                            <span>
                                                <i class="la la-arrow-left"></i>
                                                <span>Back</span>
                                            </span>
                                        </a>
                                        <div class="btn-group">


                                            <asp:Button ID="btnSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnSave_Click" Text="Save" />

                                        </div>
                                    </div>


                                </div>
                            </div>
                            <div class="m-portlet__body">


                                <!--begin: Form Body -->
                                <div class="">
                                    <div class="row">

                                        <div class="col-xl-12 offset-xl-2">
                                            <div class="form-group m-form__group row" id="dvHeaderButton" runat="server" visible="false">
                                                <div class="col-xl-9 col-lg-9">
                                                    <asp:Button ID="btnActivate" runat="server" class="btn btn-outline-success m-btn m-btn--icon m-btn--outline-2x m-btn--pill m-btn--air" OnClick="btnActivate_Click" Text="Activate" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        
                                                       <asp:Button ID="btnDeactivate" runat="server" class="btn btn-outline-danger m-btn m-btn--icon m-btn--outline-2x m-btn--pill m-btn--air" OnClick="btnDeactivate_Click" Text="De-activate" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="btnRenew" runat="server" class="btn btn-outline-success m-btn m-btn--icon m-btn--outline-2x m-btn--pill m-btn--air" OnClick="btnRenew_Click" Text="Renew" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                       <asp:Label ID="lblS" runat="server" Text="Current Status : "></asp:Label>
                                                    <asp:Label ID="lblStatus" runat="server" Text="" class="m-btn m-btn--icon m-btn--outline-2x m-btn--pill m-btn--air active"></asp:Label>

                                                    <cc1:ModalPopupExtender ID="mpeLicenseStatus" runat="server" PopupControlID="pnlLicense" TargetControlID="btnDeactivate"
                                                        CancelControlID="btnCloseHeader" BackgroundCssClass="modalBackground">
                                                    </cc1:ModalPopupExtender>

                                                </div>
                                            </div>
                                        </div>


                                        <div class="col-xl-8 offset-xl-2" style="margin-top: 25px;">
                                            <div class="m-form__section m-form__section--first">

                                                <%--<div class="form-group m-form__group row" id="dvHeaderButton" runat="server" visible="false">
                                                    <div class="col-xl-9 col-lg-9">
                                                       <asp:Button ID="btnActivate" runat="server" class="btn btn-outline-success m-btn m-btn--icon m-btn--outline-2x m-btn--pill m-btn--air" OnClick="btnActivate_Click" Text="Activate" />
                                                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        
                                                       <asp:Button ID="btnDeactivate" runat="server" class="btn btn-outline-danger m-btn m-btn--icon m-btn--outline-2x m-btn--pill m-btn--air" OnClick="btnDeactivate_Click" Text="De-activate" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="btnRenew" runat="server" class="btn btn-outline-success m-btn m-btn--icon m-btn--outline-2x m-btn--pill m-btn--air" OnClick="btnRenew_Click" Text="Renew" />
                                                       &nbsp;&nbsp;&nbsp;&nbsp;
                                                       <asp:Label ID="lblStatus" runat="server" Text="Current Status :"  ></asp:Label>
                                                    </div>
                                                </div>--%>


                                                <div class="form-group m-form__group row" style="display: none;">
                                                    <label class="col-xl-4 col-lg-4 col-form-label">* Client ID:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter first name" value="">--%>
                                                        <asp:TextBox ID="txtClient_ID" runat="server" class="form-control m-input" placeholder="Enter Client ID"></asp:TextBox>

                                                        <asp:Label ID="Label1" runat="server" ForeColor="Red" Visible="false" Font-Bold="true">Client ID Already Exists</asp:Label>
                                                    </div>
                                                </div>

                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-4 col-lg-4 col-form-label">* Select Company:</label>
                                                    <div class="col-xl-6 col-lg-6">
                                                        <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter first name" value="">--%>
                                                        <asp:DropDownList ID="ddlcompanyName" class="form-control m-input" runat="server"></asp:DropDownList>
                                                        <span id="error_Company" class="text-danger small"></span>
                                                        <asp:Label ID="Label3" runat="server" ForeColor="Red" Visible="false" Font-Bold="true">License for the Company already Exists</asp:Label>
                                                    </div>
                                                </div>

                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-4 col-lg-4 col-form-label">* Select Subscription Pack:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter first name" value="">--%>
                                                        <asp:DropDownList ID="ddlSubscription" class="form-control m-input" runat="server" OnSelectedIndexChanged="ddlSubscription_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                        <span id="error_Company_Code2" class="text-danger small"></span>

                                                    </div>
                                                </div>

                                                <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>--%>
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-4 col-lg-4 col-form-label">* Select Activation Date:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <div class="input-group date">
                                                            <%--<asp:TextBox ID="ActivationDate" runat="server" AutoCompleteType="Disabled" class="form-control m-input datetimepicker" OnTextChanged="ActivationDate_TextChanged" AutoPostBack="true" placeholder="Select activation date"></asp:TextBox>
                                                            <div class="input-group-append">
                                                                <span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
                                                            </div>--%>
                                                            <asp:TextBox ID="ActivationDate" runat="server" ClientIDMode="Static" autocomplete="off" class="form-control m-input datetimepicker m-portlet__nav-link m-dropdown__toggle dropdown-toggle btn btn--sm btn-secondary m-btn m-btn--label-primary"
                                                                OnTextChanged="ActivationDate_TextChanged" AutoPostBack="true" placeholder="Select activation date"></asp:TextBox>

                                                            <div class="input-group-append">
                                                                <span class="input-group-text">
                                                                    <i class="la la-calendar glyphicon-th"></i>
                                                                </span>
                                                            </div>
                                                        </div>
                                                        <span id="error_Company_Code" class="text-danger small"></span>
                                                        <asp:Label ID="Label4" runat="server" ForeColor="Red" Visible="false" Font-Bold="true">Activate Date cannot be Less than Current Date</asp:Label>
                                                    </div>

                                                </div>


                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-4 col-lg-4 col-form-label">* Expiration Date:</label>
                                                    <div class="col-xl-4 col-lg-4">

                                                        <asp:Label ID="txtExpDate" runat="server" ForeColor="Orange" Font-Bold="true" class="form-control m-input" placeholder="Enter User name"></asp:Label>

                                                        <span id="error_ExpDate" class="text-danger small"></span>
                                                    </div>
                                                </div>

                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-4 col-lg-4 col-form-label">* Due Date:</label>
                                                    <div class="col-xl-4 col-lg-4">

                                                        <asp:Label ID="txtDueDate" runat="server" ForeColor="Red" Font-Bold="true" class="form-control m-input" placeholder="Enter User name"></asp:Label>

                                                        <span id="error_DueDate" class="text-danger small"></span>
                                                    </div>
                                                </div>

                                                <%--</ContentTemplate>
                                                    </asp:UpdatePanel>--%>
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-4 col-lg-4 col-form-label">* Select User Limit:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter first name" value="">--%>
                                                        <asp:DropDownList ID="ddlUserLimit" class="form-control m-input" runat="server"></asp:DropDownList>
                                                        <span id="error_drpUserLimit" class="text-danger small"></span>

                                                    </div>
                                                </div>

                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-4 col-lg-4 col-form-label">* Select Modules to activate:</label>
                                                    <div class="col-xl-4 col-lg-4">

                                                        <div>
                                                            <asp:CheckBoxList ID="chkModules" runat="server" class="checkbox m-radio m-checkbox  m-checkbox--bold m-checkbox--state-success" AutoPostBack="false">
                                                            </asp:CheckBoxList>

                                                        </div>
                                                    </div>
                                                </div>




                                                <div class="form-group m-form__group row">
                                                    <div class="col-xl-9 col-lg-9">
                                                        <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                                    </div>
                                                </div>


                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>

                        <!--end::Portlet-->


                        <asp:Panel ID="pnlLicense" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
                            <div class="" id="add_sub_location" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document" style="max-width: 590px;">
                                    <div class="modal-content">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>

                                                <div class="modal-header">
                                                    <h5 class="modal-title" id="exampleModalLabel">License Update Confirmation</h5>
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader">
                                                        <span aria-hidden="true">&times;</span>

                                                    </button>
                                                </div>
                                                <div class="modal-body">

                                                    <asp:Label ID="lblLicenseAction" Text="Are you sure, you want to de-activate this License ?" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label"></asp:Label>
                                                </div>

                                                <div class="modal-footer">
                                                    <asp:Button ID="btnCloseLicense" Text="Cancel" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnCloseLicense_Click" />
                                                    <asp:Button ID="btnLicenseStatusSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" CausesValidation="true" OnClick="btnLicenseStatusSave_Click" Text="Yes" />
                                                    <asp:HiddenField ID="hdnLicenseAction" runat="server" />
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnLicenseStatusSave" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                            <!-- End Modal -->
                        </asp:Panel>




                    </form>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
