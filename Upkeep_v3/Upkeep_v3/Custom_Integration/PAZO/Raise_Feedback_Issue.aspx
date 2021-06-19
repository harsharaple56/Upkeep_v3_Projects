<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Raise_Feedback_Issue.aspx.cs" Inherits="Upkeep_v3.Custom_Integration.PAZO.Raise_Feedback_Issue" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style type="text/css">
        .auto-style1 {
            left: 0px;
            top: 0px;
        }
    </style>


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

        $(document).ready(function () {


            $('.datetimepicker').datetimepicker({
                todayHighlight: true,
                autoclose: true,
                pickerPosition: 'bottom-right',
                format: 'dd/mm/yyyy HH:ii P',
                showMeridian: true,
                startDate: moment().format('YYYY-MM-DD'),
            }).on('changeDate', function (event) {
                var startDate = moment($('#txtDueDate').val(), 'DD/MM/YYYY hh:mm A').valueOf();
                var endDate = moment($('#txtDueDate').val(), 'DD/MM/YYYY hh:mm A').valueOf();
                $('#txtDueDate').html('').parents('.form-group').removeClass('has-error');
                if (endDate < startDate) {
                    $('#txtDueDate').html('Workpermit To datetime can not be less than From datetime.').parents('.form-group').addClass('has-error');
                    $('#txtWorkPermitToDate').val('');
                }
            });


        });


    </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="m-content">
        <div class="m-grid__item m-grid__item--fluid m-wrapper" style="margin-bottom: 0px;">

            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">
                        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>


                        <div class="m-portlet__head">
                            <div class="m-portlet__head-progress">
                            </div>
                            <div class="m-portlet__head-wrapper">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">Raise Issue over a Feedback
                                        </h3>
                                    </div>
                                </div>

                                <div class="m-portlet__head-tools">


                                    <a href="<%= Page.ResolveClientUrl("~/Feedback/Feedback_MIS_Report.aspx") %>" class="btn m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                        <span>
                                            <i class="la la-arrow-left"></i>
                                            <span>Back</span>
                                        </span>
                                    </a>
                                    <div class="btn-group">

                                        <asp:Button ID="btnSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnSave_Click" Text="Submit Issue to PAZO" ValidationGroup="ValidateUser" />

                                    </div>
                                </div>

                            </div>
                        </div>



                        <!--begin: Form Body -->
                        <div class="m-form m-form--fit m-form--group-seperator-dashed">
                            <div class="row">
                                <div class="col-xl-12">
                                    <div class="m-form__section m-form__section--first">

                                        <div class="form-group m-form__group row">
                                            <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Feedback ID :</label>

                                            <div class="col-xl-4 col-lg-4">
                                                <asp:Label ID="lblFeedbackID" cols="20" rows="2" runat="server" class="form-control m-input" placeholder="Enter Detailed Description about your Request" runat="server">
                                                    345
                                                </asp:Label>
                                            </div>

                                            <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Customer Name :</label>

                                            <div class="col-xl-4 col-lg-4">
                                                <asp:Label ID="lblCustomerName" cols="20" rows="2" runat="server" class="form-control m-input" placeholder="Enter Detailed Description about your Request" runat="server">
                                                    Lokesh Devasani (8898084488)
                                                </asp:Label>
                                            </div>
                                        </div>


                                        <div class="form-group m-form__group row">
                                            <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold"><span style="color: red;">*</span> Issue Name :</label>

                                            <div class="col-xl-4 col-lg-4">
                                                <asp:TextBox ID="txtIssueName" cols="20" Rows="2" runat="server" class="form-control m-input" placeholder="Enter Issue Title" runat="server">

                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtIssueName" ValidationGroup="ValidateUser"
                                                    ErrorMessage="Please enter detailed description" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                            <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold"><span style="color: red;">*</span> Due Date :</label>
                                            <div class="col-xl-4 col-lg-3">
                                                <%--<asp:Label ID="lblRequestDate" runat="server" Text="" CssClass="form-control-label"></asp:Label>--%>
                                                <div class="input-group date">
                                                    <asp:TextBox ID="txtDueDate" runat="server" autocomplete="off" class="form-control m-input datetimepicker" placeholder="Select Due date for Issue" ClientIDMode="Static"></asp:TextBox>
                                                    <div class="input-group-append">
                                                        <span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
                                                    </div>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDueDate" Visible="true" Display="Dynamic"
                                                        ValidationGroup="validateDueDate" ForeColor="Red" InitialValue="0" ErrorMessage="Please Select Due date for Issue"></asp:RequiredFieldValidator>
                                                </div>
                                                <span id="error_startDate" class="text-danger small"></span>
                                            </div>
                                        </div>

                                        <div class="form-group m-form__group row">
                                            <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold"><span style="color: red;">*</span> Issue Description :</label>

                                            <div class="col-xl-10 col-lg-4">
                                                <asp:TextBox ID="txtIssueDesc" cols="20" Rows="2" runat="server" class="form-control m-input" placeholder="Enter Detailed Description about your Issue" runat="server">

                                                </asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtIssueDesc" ValidationGroup="ValidateUser"
                                                    ErrorMessage="Please enter detailed description" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                            <label id="lblError" runat="server"></label>
                                        </div>

                                        <br />
                                        <%--<asp:Label ID="lblSuccessMsg" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                                        <asp:Label ID="lblFalureMsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>--%>
                                        
                                        <div class="m-portlet__body col-lg-7" id="dvSuccess" runat="server" style="display:none;" >
                                            <div class="m-alert m-alert--icon m-alert--air m-alert--square alert alert-success alert-dismissible fade show" role="alert">
                                                <div class="m-alert__icon">
                                                    <i class="la la-warning"></i>
                                                </div>
                                                <div class="m-alert__text">
                                                    <strong>Success!</strong> Ticket has been raised successfully in PAZO.
                                                </div>
                                                <div class="m-alert__close">
                                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                    </button>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="m-portlet__body col-lg-7" id="dvFailure" runat="server" style="display:none;">
                                            <div class="m-alert m-alert--icon m-alert--air m-alert--square alert alert-danger alert-dismissible fade show" role="alert">
                                                <div class="m-alert__icon">
                                                    <i class="la la-warning"></i>
                                                </div>
                                                <div class="m-alert__text">
                                                    <strong>Error!</strong> Something went wrong, please try again later.
                                                </div>
                                                <div class="m-alert__close">
                                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                    </button>
                                                </div>
                                            </div>
                                        </div>



                                    </div>

                                </div>
                            </div>
                        </div>


                    </div>
                </div>

                <!--end::Portlet-->
            </div>

        </div>
    </div>


    <div aria-hidden="true" aria-labelledby="exampleModalLabel" class="modal fade" id="exampleModal" role="dialog" tabindex="-1">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel1">Uploaded Image
                    </h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button">
                        <span aria-hidden="true">×
                        </span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="carousel slide" data-ride="carousel" id="carouselExampleControls">
                        <div class="carousel-inner">
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>



</asp:Content>
