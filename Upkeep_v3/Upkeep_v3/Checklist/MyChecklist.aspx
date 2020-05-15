<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MyChecklist.aspx.cs" Inherits="Upkeep_v3.Checklist.MyChecklist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <%--<script src="<%= Page.ResolveClientUrl("~/assets/demo/custom/crud/metronic-datatable/base/html-table.js") %>" type="text/javascript"></script>--%>

    <script type="text/javascript">
        $(document).ready(function () {
            DatatableHtmlTableDemo.init();
        });

        var DatatableHtmlTableDemo = {
            init: function () {
                var e; e = $(".m-datatable").mDatatable({
                    data: { saveState: { cookie: !1 } },
                    search: { input: $("#generalSearch") },
                    columns: [{ field: "DepositPaid", type: "number" },
                    {
                        field: "OrderDate", type: "date", format: "YYYY-MM-DD"
                    },

                    {
                        field: "RequestStatus", title: "RequestStatus", template: function (e) {
                            var t =
                            {
                                "Open": { title: "Open", class: "m-badge--danger" },
                                "Close": { title: "Close", class: " m-badge--success" }
                                //5: { title: "Info", class: " m-badge--info" },
                                //6: { title: "Danger", class: " m-badge--danger" },
                                //7: { title: "Warning", class: " m-badge--warning" }
                            }; return '<span class="m-badge ' + t[e.RequestStatus].class + ' m-badge--wide">' + t[e.RequestStatus].title + "</span>"
                        }
                    },
                    {
                        field: "Status",
                        title: "Status",
                        template: function (e) {
                            var t = {
                                "Pending": { title: "Pending", state: "danger" },
                                "Done": { title: "Done", state: "success" }
                                //"Parked": { title: "Parked", state: "text-secondary" },
                                //"ApprovalSent": { title: "ApprovalSent", state: "accent" }
                            }; return '<span class="m-badge m-badge--' + t[e.Status].state + ' m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-' + t[e.Status].state + '">' + t[e.Status].title + "</span>"
                        }
                    }

                    ]
                }),
                    $("#m_form_status").on("change", function () {

                        e.search($(this).val().toLowerCase(), "RequestStatus")
                    }),
                    $("#m_form_type").on("change", function () { e.search($(this).val().toLowerCase(), "Status") }),
                    $("#m_form_status, #m_form_type").selectpicker()

            }
        };


    </script>


    <form method="post" runat="server" id="frmMain">


        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <div class="m-content">
                <div class="m-portlet m-portlet--mobile">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Checklist Details		
                                </h3>
                            </div>
                        </div>

                        <div class="col-xl-4 order-1 order-xl-2 m--align-right">
                            <a href="<%= Page.ResolveClientUrl("~/Checklist/Checklist_Request.aspx") %>" style="margin-top: 5%;" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                                <span>
                                    <i class="la la-plus"></i>
                                    <span>New Request</span>
                                </span>
                            </a>
                            <div class="m-separator m-separator--dashed d-xl-none"></div>
                        </div>

                    </div>
                    <div class="m-portlet__body">
                        <!--begin: Search Form -->

                        <div class="m-form m-form--label-align-right m--margin-bottom-30">
                            <div class="row align-items-center">
                                <div class="col-xl-10 order-2 order-xl-1">
                                    <div class="form-group m-form__group row align-items-center">
                                        <div class="col-md-4">
                                            <div class="m-form__group m-form__group--inline">
                                                <div class="m-form__label" style="width: 53%;">
                                                    <label>Request Status:</label>
                                                </div>
                                                <div class="m-form__control">
                                                    <select class="form-control m-bootstrap-select" id="m_form_status">
                                                        <option value="">All</option>
                                                        <option value="Open">Open</option>
                                                        <option value="Closed">Closed</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="d-md-none m--margin-bottom-10"></div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="m-form__group m-form__group--inline">
                                                <div class="m-form__label">
                                                    <label class="m-label m-label--single">Status:</label>
                                                </div>
                                                <div class="m-form__control">
                                                    <select class="form-control m-bootstrap-select" id="m_form_type">
                                                        <option value="">All</option>
                                                        <option value="Pending">Pending</option>
                                                        <option value="Done">Done</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="d-md-none m--margin-bottom-10"></div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="m-input-icon m-input-icon--left">
                                                <input type="text" class="form-control m-input" placeholder="Search..." id="generalSearch" />
                                                <span class="m-input-icon__icon m-input-icon__icon--left">
                                                    <span><i class="la la-search"></i></span>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%--<div class="col-xl-2 order-1 order-xl-2 m--align-right">
                                    <a href="<%= Page.ResolveClientUrl("~/Checklist/Checklist_Request.aspx") %>" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                                        <span>
                                            <i class="la la-plus"></i>
                                            <span>New Request</span>
                                        </span>
                                    </a>
                                    <div class="m-separator m-separator--dashed d-xl-none"></div>
                                </div>--%>
                            </div>
                        </div>

                        <!--end: Search Form -->

                        <!--begin: Datatable -->
                        <table class="m-datatable" id="html_table" width="100%">
                            <thead>
                                <tr>
                                    <th title="Field #1" data-field="TicketID">Ticket No</th>
                                    <th title="Field #2" data-field="ChecklistName">Checklist Name</th>
                                    <th title="Field #3" data-field="ScheduleDate">Schedule Date</th>
                                    <th title="Field #4" data-field="StartTime">Start Time</th>
                                    <th title="Field #5" data-field="EndTime">End Time</th>
                                    <th title="Field #6" data-field="RequestStatus">Request Status</th>
                                    <th title="Field #7" data-field="Status">Status</th>
                                    <th title="Field #8" data-field="CompletedPercentage">Completed Percentage</th>
                                    <th title="Field #9" data-field="UserName">UserName</th>

                                </tr>
                            </thead>
                            <tbody>

                                <%=bindgrid()%>
                            </tbody>
                        </table>

                        <!--end: Datatable -->

                    </div>
                </div>

                <!-- END EXAMPLE TABLE PORTLET-->
            </div>
        </div>


    </form>

</asp:Content>
