<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="eFacilito_PAZO_Feedback_Issues_Report.aspx.cs" Inherits="Upkeep_v3.Custom_Reports.OBRC.eFacilito_PAZO_Feedback_Issues_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="m-grid__item m-grid__item--fluid">
        <div class="m-content">
            <div class="m-portlet m-portlet--mobile">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <h3 class="m-portlet__head-text">PAZO Feedback Issues Data
                            </h3>
                        </div>
                    </div>
                </div>
                <div class="m-portlet__body">

                    <!--begin: Search Form -->
                    <%--<div class="m-form m-form--label-align-right m--margin-top-20 m--margin-bottom-30">
                        <div class="row align-items-center">
                            <div class="col-xl-8 order-2 order-xl-1">
                                <div class="form-group m-form__group row align-items-center">
                                    <div class="col-md-4">
                                        <div class="m-form__group m-form__group--inline">
                                            <div class="m-form__label">
                                                <label>Status:</label>
                                            </div>
                                            <div class="m-form__control">
                                                <div class="dropdown bootstrap-select form-control m-bootstrap-select m-bootstrap-select--solid">
                                                    <select class="form-control m-bootstrap-select m-bootstrap-select--solid" id="m_form_status" tabindex="-98">
                                                        <option value="">All</option>
                                                        <option value="1">Pending</option>
                                                        <option value="2">Delivered</option>
                                                        <option value="3">Canceled</option>
                                                    </select>
                                                    <button type="button" class="btn dropdown-toggle bs-placeholder btn-light" data-toggle="dropdown" role="button" data-id="m_form_status" title="All">
                                                        <div class="filter-option">
                                                            <div class="filter-option-inner">All</div>
                                                        </div>
                                                        &nbsp;<span class="bs-caret"><span class="caret"></span></span></button><div class="dropdown-menu " role="combobox">
                                                            <div class="inner show" role="listbox" aria-expanded="false" tabindex="-1">
                                                                <ul class="dropdown-menu inner show"></ul>
                                                            </div>
                                                        </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="d-md-none m--margin-bottom-10"></div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="m-form__group m-form__group--inline">
                                            <div class="m-form__label">
                                                <label class="m-label m-label--single">Type:</label>
                                            </div>
                                            <div class="m-form__control">
                                                <div class="dropdown bootstrap-select form-control m-bootstrap-select m-bootstrap-select--solid">
                                                    <select class="form-control m-bootstrap-select m-bootstrap-select--solid" id="m_form_type" tabindex="-98">
                                                        <option value="">All</option>
                                                        <option value="1">Online</option>
                                                        <option value="2">Retail</option>
                                                        <option value="3">Direct</option>
                                                    </select>
                                                    <button type="button" class="btn dropdown-toggle bs-placeholder btn-light" data-toggle="dropdown" role="button" data-id="m_form_type" title="All">
                                                        <div class="filter-option">
                                                            <div class="filter-option-inner">All</div>
                                                        </div>
                                                        &nbsp;<span class="bs-caret"><span class="caret"></span></span></button><div class="dropdown-menu " role="combobox">
                                                            <div class="inner show" role="listbox" aria-expanded="false" tabindex="-1">
                                                                <ul class="dropdown-menu inner show"></ul>
                                                            </div>
                                                        </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="d-md-none m--margin-bottom-10"></div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="m-input-icon m-input-icon--left">
                                            <input type="text" class="form-control m-input m-input--solid" placeholder="Search..." id="generalSearch">
                                            <span class="m-input-icon__icon m-input-icon__icon--left">
                                                <span><i class="la la-search"></i></span>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-4 order-1 order-xl-2 m--align-right">
                                <a href="#" class="btn btn-focus m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                                    <span>
                                        <i class="la la-cart-plus"></i>
                                        <span>New Order</span>
                                    </span>
                                </a>
                                <div class="m-separator m-separator--dashed d-xl-none"></div>
                            </div>
                        </div>
                    </div>--%>

                    <!--end: Search Form -->

                    <!--begin: Datatable -->

                    <div class="m-portlet__body col-lg-12" id="dvFailure" runat="server" style="display: none;">
                        <div class="m-alert m-alert--icon m-alert--air m-alert--square alert alert-danger alert-dismissible fade show" role="alert">
                            <div class="m-alert__icon">
                                <i class="la la-warning"></i>
                            </div>
                            <div class="m-alert__text">
                                <strong>Error!</strong> Something went wrong, please try again later or contact us at <b>support@efacilito.com</b>.
                            </div>
                            <div class="m-alert__close">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                </button>
                            </div>
                        </div>
                    </div>
                    <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">
                        <thead>
                            <tr>

                                <th data-field="refId" class="m-datatable__cell"><span style="width: 110px;">Issue ID</span></th>
                                <th data-field="title" class="m-datatable__cell"><span style="width: 110px;">Issue Title</span></th>
                                <th data-field="createdTime" class="m-datatable__cell"><span style="width: 110px;">Time</span></th>
                                <th data-field="createdDate" class="m-datatable__cell"><span style="width: 110px;">Date</span></th>
                                <th data-field="department" class="m-datatable__cell"><span style="width: 110px;">Department</span></th>
                                <th data-field="location" class="m-datatable__cell"><span style="width: 110px;">Location</span></th>
                                <th data-field="raisedBy" class="m-datatable__cell"><span style="width: 110px;">Raised By</span></th>
                                <th data-field="assignedTo" class="m-datatable__cell"><span style="width: 110px;">Assigned To</span></th>
                                <th data-field="timeline" class="m-datatable__cell"><span style="width: 110px;">Timeline Status</span></th>
                                <th data-field="statusLabel" class="m-datatable__cell"><span style="width: 110px;">Status</span></th>
                            </tr>
                        </thead>
                        <tbody>
                        </tbody>
                    </table>

                </div>

                <!--end: Datatable -->
            </div>
        </div>
    </div>
    </div>


</asp:Content>
