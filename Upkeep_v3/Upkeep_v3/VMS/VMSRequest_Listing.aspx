<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="VMSRequest_Listing.aspx.cs" Inherits="Upkeep_v3.VMS.VMSRequest_Listing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>

    <script type="text/javascript">

        var DatatableHtmlTableDemo = {
            init: function () {
                var e; e = $(".m-datatable").mDatatable({
                    data: { saveState: { cookie: !1 } },
                    search: { input: $("#generalSearch") },
                    columns: [

                        //{ field: "DepositPaid", type: "number" },
                        //{
                        //    field: "OrderDate", type: "date", format: "YYYY-MM-DD"
                        //},

                        {
                            field: "Status", title: "Status", template: function (e) {
                                var t =
                                {
                                    "IN": { title: "IN", class: "m-badge--warning" },
                                    "OUT": { title: "OUT", class: " m-badge--success" },
                                    "Approve": { title: "Approved", class: " m-badge--success" },
                                    "Apply": { title: "Apply", class: " m-badge--brand" },
                                    "Reject": { title: "Rejected", class: " m-badge--danger" },
                                    "Expired": { title: "Expired", class: "bg-secondary text-black" },
                                    "In Progress": { title: "In Progress", class: "text-white bg-info" }
                                }; return '<span class="m-badge ' + t[e.Status].class + ' m-badge--wide">' + t[e.Status].title + "</span>"
                            }
                        }

                        //    ,
                        //{
                        //    field: "Status",
                        //    title: "Status",
                        //    template: function (e) {
                        //        var t = {
                        //            "Pending": { title: "Pending", state: "danger" },
                        //            "Done": { title: "Done", state: "success" }
                        //            //"Parked": { title: "Parked", state: "text-secondary" },
                        //            //"ApprovalSent": { title: "ApprovalSent", state: "accent" }
                        //        }; return '<span class="m-badge m-badge--' + t[e.Status].state + ' m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-' + t[e.Status].state + '">' + t[e.Status].title + "</span>"
                        //    }
                        //}

                    ]
                }),
                    //$("#m_form_status").on("change", function () {

                    //    e.search($(this).val().toLowerCase(), "RequestStatus")
                    //}),
                    $("#m_form_status").on("change", function () { e.search($(this).val().toLowerCase(), "Status") }),
                    $("#m_form_status").selectpicker()

            }
        };

        $(document).ready(function () {
            DatatableHtmlTableDemo.init();
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
            var start = moment().subtract(0, 'days');
            //var end = moment();
            //var start = moment();
            var end = moment().add(0, 'days');



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

                range = start.format('DD-MMM-YYYY') + ' - ' + end.format('DD-MMM-YYYY');

                picker.find('.m-subheader__daterange-date').html(range);
                picker.find('.m-subheader__daterange-title').html(title);
                //alert(start);
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="m-grid__item m-grid__item--fluid">
        <div class="m-content">

            <div class="row">
                <div class="col-lg-12">
                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">
                        <div class="m-portlet__head">

                            <div class="m-portlet__head-wrapper">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">List of Visit Requests	
                                        </h3>
                                    </div>
                                </div>
                            </div>

                             <div class="m-portlet__head-tools">
                                <ul class="m-portlet__nav">

                                    <li class="m-portlet__nav-item">
											<a href="<%= Page.ResolveClientUrl("~/VMS/Visit_Request.aspx") %>" class="btn btn-success m-btn m-btn--custom m-btn--pill m-btn--icon m-btn--air">
												<span>
													<i class="flaticon-add"></i>
													<span>New Visit Request</span>
												</span>
											</a>
										</li>

                                </ul>

                                 <ul class="m-portlet__nav">
                                    <li class="m-portlet__nav-item m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover" aria-expanded="true">

                                        <a href="#" class="btn m-btn--pill btn-outline-focus m-btn--icon m-btn--air">
                                            <span>
                                                <i class="fa fa-database"></i>
                                                <span>Export Data</span>
                                            </span>
                                            
                                        </a>
                                        <div class="m-dropdown__wrapper" style="z-index: 101;">
                                            <span class="m-dropdown__arrow m-dropdown__arrow--right m-dropdown__arrow--adjust" style="left: auto; right: 55.5px;"></span>
                                            <div class="m-dropdown__inner">
                                                <div class="m-dropdown__body">
                                                    <div class="m-dropdown__content">
                                                        <ul class="m-nav">
                                                            <li class="m-nav__section m-nav__section--first">
                                                                <span class="m-nav__section-text">Export Data Format</span>
                                                            </li>
                                                            <%--<li class="m-nav__item">
                                                                <a href="#" class="m-nav__link" id="export_print">
                                                                    <i class="m-nav__link-icon la la-print"></i>
                                                                    <span class="m-nav__link-text">Print</span>
                                                                </a>
                                                            </li>--%>
                                                            <%--<li class="m-nav__item">
                                                                <a href="#" class="m-nav__link" id="export_copy">
                                                                    <i class="m-nav__link-icon la la-copy"></i>
                                                                    <span class="m-nav__link-text">Copy</span>
                                                                </a>
                                                            </li>--%>
                                                            <li class="m-nav__item">
                                                                <a class="m-nav__link" id="export_excel" onserverclick="btnExportExcel_Click" runat="server">
                                                                    <i class="m-nav__link-icon la la-file-excel-o" style="font-size:2rem"></i>
                                                                    <span class="m-nav__link-text">Excel <b>( .xls )</b></span>
                                                                </a>
                                                            </li>
                                                            <%--<li class="m-nav__item">
                                                                <a href="#" class="m-nav__link" id="export_csv">
                                                                    <i class="m-nav__link-icon la la-file-text-o"></i>
                                                                    <span class="m-nav__link-text">CSV</span>
                                                                </a>
                                                            </li>--%>
                                                            <%--<li class="m-nav__item">
                                                                <a onserverclick="btnExportPDF_Click" runat="server" class="m-nav__link" id="export_pdf">
                                                                    <i class="m-nav__link-icon la la-file-pdf-o"></i>
                                                                    <span class="m-nav__link-text">PDF</span>
                                                                </a>
                                                            </li>--%>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                </ul>



                            </div>

                        </div>
                        <div class="m-portlet__body">
                            <!--begin: Search Form -->

                            <div class="m-form m-form--fit m--margin-bottom-20">
                                <div class="row m--align-center">

                                    <div class="col-lg-4 m--margin-bottom-10-tablet-and-mobile">
                                        
                                        <label class="font-weight-bold">Search Data:</label>
                                        <input type="text" class="form-control m-input" placeholder="Search..." id="generalSearch" />

                                    </div>

                                    <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Filter Status:</label>

                                        <div class="m-form__control">
                                                        <select class="form-control m-bootstrap-select" id="m_form_status">
                                                            <option value="">All</option>
                                                            <option value="IN">IN</option>
                                                            <option value="Apply">Apply</option>
                                                            <option value="OUT">OUT</option>
                                                            <option value="Rejected">--</option>
                                                            <option value="Closed">--</option>
                                                        </select>
                                                    </div>
                                    </div>

                                    <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Filter Date Range:</label>

                                        <div class="m-form__control">
                                            <span class="m-subheader__daterange btn btn-sm btn-outline-brand" style="padding: 0.15rem 0.8rem; width: -webkit-fill-available;" id="daterangepicker">
                                                <span class="m-subheader__daterange-label" style="font-size: 12px;">
                                                                <span class="m-subheader__daterange-title"></span>
                                                                <span class="m-subheader__daterange-date"></span>
                                                                <asp:HiddenField ID="start_date" ClientIDMode="Static" runat="server" />
                                                                <asp:HiddenField ID="end_date" ClientIDMode="Static" runat="server" />
                                                                <asp:HiddenField ID="hdn_IsPostBack" ClientIDMode="Static" runat="server" />
                                                                <asp:HiddenField ID="date_range_title" ClientIDMode="Static" runat="server" />
                                                            </span>
                                                <button type="button" class="btn btn-brand
                                                    btn-outline-brand m-btn m-btn--icon m-btn--icon-only m-btn--custom m-btn--pill m--font-brand">
                                                    <i class="la la-angle-down"></i>
                                                </button>
                                            </span>
                                        </div>

                                    </div>

                                    <div class="col-lg-2 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Search Filters:</label>
                                        <div class="m-form__control">
                                            <button class="btn btn-brand m-btn m-btn--icon" id="btnSearch" runat="server" onserverclick="btnSearch_Click">
                                                <span>
                                                    <i class="la la-search"></i>
                                                    <span>Search</span>
                                                </span>
                                            </button>

                                        </div>

                                    </div>


                                </div>
                                

                            </div>







                            <!--end: Search Form -->

                            <!--begin: Datatable -->
                            <table class="m-datatable" id="html_table" width="100%">
                                <thead>
                                    <tr>
                                        <%--<th title="Field #1" data-field="SrNo">Sr. No</th>--%>
                                        <th title="Request ID" data-field="RequestID">Request ID</th>
                                        <th title="Configuration Title" data-field="Config_Title">Configuration Title</th>
                                        <th title="Name" data-field="Name">Name</th>
                                        <th title="Contact" data-field="Phone">Contact</th>
                                        <th title="Email" data-field="Email">Email</th>
                                        <th title="In Time" data-field="InTime">In Time</th>
                                        <th title="Out Time" data-field="OutTime">Out Time</th>
                                        <th title="Status" data-field="Status">Status</th>
                                        <th title="Created By" data-field="Created_By">Created By</th>
                                        <th title="Visit Date" data-field="MeetDate">Visit Date</th>
                                        <th title="Request Date" data-field="RequestDate">Request Date</th>


                                    </tr>
                                </thead>
                                <tbody>

                                    <%=fetchVMSRequestList()%>
                                </tbody>
                            </table>

                            <!--end: Datatable -->

                        </div>
                    </div>
                </div>
            </div>

            <!-- END EXAMPLE TABLE PORTLET-->
        </div>
    </div>
</asp:Content>
