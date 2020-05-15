<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="BaggageReport.aspx.cs" Inherits="Upkeep_Gatepass_Workpermit.Reports.BaggageReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>



    <script>
        $(document).ready(function () {
            $('#m_table_1').DataTable({
                pagingType: 'full_numbers',
                scrollX: true,
                //'fnDrawCallback': function () {
                //    init_plugins();
                //}
            });

            $('.m_selectpicker').selectpicker();
            //alert('1111');
            var picker = $('#daterangepicker');
            //var start = moment().subtract(29, 'days');
            //var end = moment();
            var start = moment();
            var end = moment().add(30, 'days');


            function cb(start, end, label) {
                var title = '';
                var range = '';

                ////if ((end - start) < 100 || label == 'Today') {
                ////    title = 'Today:';
                ////    range = start.format('MMM D');
                ////} else if (label == 'Yesterday') {
                ////    title = 'Yesterday:';
                ////    range = start.format('MMM D');
                ////} else {
                ////    range = start.format('MMM D') + ' - ' + end.format('MMM D');
                ////}

                range = start.format('MMM D') + ' - ' + end.format('MMM D');

                picker.find('.m-subheader__daterange-date').html(range);
                picker.find('.m-subheader__daterange-title').html(title);

                $('#start_date').val(start.format('DD/MM/YYYY'));
                $('#end_date').val(end.format('DD/MM/YYYY'));
                $('#date_range_title').val(title + range);
            }

            picker.daterangepicker({
                direction: mUtil.isRTL(),
                startDate: start,
                endDate: end,
                opens: 'left',
                ranges: {
                    'Today': [moment(), moment()],
                    'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                    'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                    'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                    'This Month': [moment().startOf('month'), moment().endOf('month')],
                    'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
                }
            }, cb);

            var IsPostBack2 = $('#hdn_IsPostBack').val();

            if (IsPostBack2 == "no") {
                cb(start, end, '');
            }
            else {

                picker.find('.m-subheader__daterange-title').html($('#date_range_title').val());
            }

        });
    </script>

    <%--<form method="post" runat="server" id="frmMain">--%>


        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <div class="m-content" style="padding: 6px 7px !important;">
                <div class="m-portlet m-portlet--mobile">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Baggage Report		
                                </h3>
                            </div>
                        </div>



                    </div>
                    <div class="m-portlet__body">
                        <!--begin: Search Form -->

                        <div class="m-form m-form--label-align-right m--margin-bottom-30">
                            <div class="row align-items-center">
                                <div class="col-xl-12 order-2 order-xl-1">
                                    <div class="form-group m-form__group row align-items-center">
                                        <%--<div class="col-md-4">
                                            <div class="m-form__group m-form__group--inline">
                                                <div class="m-form__label">
                                                    <label>Status:</label>
                                                </div>
                                                <div class="m-form__control">
                                                    <select class="form-control m-bootstrap-select" id="m_form_status">
                                                        <option value="">All</option>
                                                        <option value="Open">Open</option>
                                                        <option value="Approved">Approved</option>
                                                        <option value="Hold">Hold</option>
                                                        <option value="Rejected">Rejected</option>
                                                        <option value="Closed">Closed</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="d-md-none m--margin-bottom-10"></div>
                                        </div>--%>



                                        <div class="col-md-12" style="text-align: right;">
                                            <div class="m-form__group m-form__group--inline">
                                                <div class="m-form__label">
                                                    <%--<label>Date:</label>--%>
                                                </div>
                                                <div class="m-form__control">
                                                    <label style="font-weight:bold;">Date : </label>
                                                    <span class="m-subheader__daterange btn btn-sm btn-outline-accent" style="padding: 0.15rem 0.8rem;" id="daterangepicker">
                                                        <span class="m-subheader__daterange-label">
                                                            <span class="m-subheader__daterange-title"></span>
                                                            <span class="m-subheader__daterange-date"></span>
                                                            <asp:HiddenField ID="start_date" ClientIDMode="Static" runat="server" />
                                                            <asp:HiddenField ID="end_date" ClientIDMode="Static" runat="server" />
                                                            <asp:HiddenField ID="hdn_IsPostBack" ClientIDMode="Static" runat="server" />
                                                            <asp:HiddenField ID="date_range_title" ClientIDMode="Static" runat="server" />
                                                        </span>

                                                        <button type="button" class="btn btn-accent  m-btn m-btn--icon m-btn--icon-only m-btn--custom m-btn--pill m--font-light">
                                                            <i class="la la-angle-down"></i>
                                                        </button>
                                                    </span>
                                                    <div class="btn-group" style="margin-left: 50px;">
                                                        <asp:Button ID="btnSearch" runat="server" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill" OnClick="btnSearch_Click" Text="Search" />
                                                    </div>
                                                    <%--<div class="btn-group" style="margin-left: 50px;">
                                                        <asp:Button ID="btnExportPDF" runat="server" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill" OnClick="btnExportPDF_Click" Text="Export To PDF" />
                                                    </div>
                                                    <div class="btn-group" style="margin-left: 50px;">
                                                        <asp:Button ID="btnExportExcel" runat="server" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill" OnClick="btnExportExcel_Click" Text="Export To Excel" />
                                                    </div>--%>
                                                </div>
                                            </div>
                                        </div>

                                        <%--<div class="col-md-12" style="text-align: right;">
                                            <div class="btn-group" style="margin-left: 50px;">
                                                <asp:Button ID="btnExportPDF" runat="server" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill" OnClick="btnExportPDF_Click" Text="Export To PDF" />
                                            </div>
                                            <div class="btn-group" style="margin-left: 50px;">
                                                <asp:Button ID="btnExportExcel" runat="server" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill" OnClick="btnExportExcel_Click" Text="Export To Excel" />
                                            </div>
                                        </div>--%>


                                    </div>
                                </div>

                            </div>
                        </div>

                        <!--end: Search Form -->

                        <!--begin: Datatable -->
                        <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1" width="100%">
                            <thead>
                                <tr>
                                    <%--<th title="Field #1" data-field="SrNo">Sr. No</th>--%>
                                    <th title="Bag TicketID" data-field="BagTicketID">Bag TicketID</th>
                                    <th title="Customer Name" data-field="CustomerName">Customer Name</th>
                                    <th title="Location" data-field="Location">Location</th>
                                    <th title="Contact No" data-field="ContactNo">Contact No</th>
                                    <th title="Alter No" data-field="AlterNo">Alter No</th>
                                    <th title="Total Bag" data-field="TotalBag">Total Bag</th>
                                    <th title="Price" data-field="Price">Price</th>
                                    <th title="User Name" data-field="UserName">User Name</th>
                                    <th title="In Time" data-field="InTime">In Time</th>
                                    <th title="Out Time" data-field="OutTime">Out Time</th>
                                    <th title="Given User" data-field="GivenUser">Given User</th>
                                    <th title="Porter" data-field="Porter">Porter</th>
                                    <th title="Bag Tag ID" data-field="BagTagID">Bag Tag ID</th>
                                    <th title="Total Time" data-field="TotalTime">Total Time</th>
                                </tr>
                            </thead>
                            <tbody>

                                   <%=FetchBaggageReport()%>
                            </tbody>
                        </table>

                        <!--end: Datatable -->
                <asp:Button ID="btnExportPDF" runat="server" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill" OnClick="btnExportPDF_Click" Text="Export To PDF" />
                        <asp:Button ID="btnExportExcel" runat="server" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill" OnClick="btnExportExcel_Click" Text="Export To Excel" />
                    </div>
                </div>

                <!-- END EXAMPLE TABLE PORTLET-->
            </div>
        </div>


    <%--</form>--%>

</asp:Content>
