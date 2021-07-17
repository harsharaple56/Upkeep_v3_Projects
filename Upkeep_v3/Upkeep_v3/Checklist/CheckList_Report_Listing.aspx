<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="CheckList_Report_Listing.aspx.cs" Inherits="Upkeep_v3.CheckList.CheckList_Report_Listing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>

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
                            field: "Status", title: "Status", template: function (e) {
                                var t =
                                {
                                    "OPEN": { title: "Open", class: "m-badge--danger" },
                                    "CLOSE": { title: "Closed", class: " m-badge--success" }
                                }; return '<span class="m-badge ' + t[e.Status].class + ' m-badge--wide">' + t[e.Status].title + "</span>"
                            }
                        }
                        //,{
                        //    field: "PercentCompleted", title: "PercentCompleted", template: function (e) {
                        //        var t1 =
                        //        {

                        //        }; return '<span class="m-badge m-badge--success Progress m-badge--wide"></span>'
                        //    }
                        //}
                    ]
                }),
                    $("#m_form_status").on("change", function () { e.search($(this).val().toLowerCase(), "Status") }),
                    $("#m_form_status").selectpicker()

            }
        };


    </script>

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


    <style>
        .Progress {
            color: #716aca;
            font-weight: bold;
        }
    </style>

    <%--<form method="post" runat="server" id="frmMain">--%>


    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">

            <div class="row">
                <div class="col-lg-12">
                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <div class="m-portlet__head">

                            <div class="m-portlet__head-wrapper">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">My Checklist Report
                                        </h3>
                                    </div>
                                </div>
                            </div>

                            <div class="m-portlet__head-tools">

                                <ul class="m-portlet__nav">
                                    <li class="m-portlet__nav-item m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover" aria-expanded="true">

                                        <a href="#" class="m-portlet__nav-link m-dropdown__toggle dropdown-toggle btn btn--sm m-btn--pill btn-primary m-btn m-btn--label-brand m-btn--air">
                                            <span class="fa fa-database" style="padding: 3px;"></span>
                                            Export Data
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
                                                                    <i class="m-nav__link-icon la la-file-excel-o"></i>
                                                                    <span class="m-nav__link-text">Excel</span>
                                                                </a>
                                                            </li>
                                                            <%--<li class="m-nav__item">
                                                                <a href="#" class="m-nav__link" id="export_csv">
                                                                    <i class="m-nav__link-icon la la-file-text-o"></i>
                                                                    <span class="m-nav__link-text">CSV</span>
                                                                </a>
                                                            </li>--%>
                                                            <li class="m-nav__item">
                                                                <a onserverclick="btnExportPDF_Click" runat="server" class="m-nav__link" id="export_pdf">
                                                                    <i class="m-nav__link-icon la la-file-pdf-o"></i>
                                                                    <span class="m-nav__link-text">PDF</span>
                                                                </a>
                                                            </li>
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

                                    <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Filter Checklist:</label>

                                        <div class="m-form__control">
                                            <asp:DropDownList ID="ddlCheckist_Name" runat="server" CssClass="form-control" ClientIDMode="Static">
                                            </asp:DropDownList>
                                        </div>
                                    </div>


                                    <div class="col-lg-2 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Filter Department:</label>

                                        <div class="m-form__control">
                                            <asp:DropDownList ID="ddlCheckist_Department" runat="server" CssClass="form-control" ClientIDMode="Static">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Filter Status:</label>

                                        <div class="m-form__control">
                                            <asp:DropDownList ID="ddlCheckist_Status" runat="server" CssClass="form-control" ClientIDMode="Static">
                                                <asp:ListItem Value="All" Text="All"></asp:ListItem>
                                                <asp:ListItem Value="Open" Text="Open"></asp:ListItem>
                                                <asp:ListItem Value="Close" Text="Closed"></asp:ListItem>
                                                <asp:ListItem Value="Expired" Text="Expired"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Filter Date Range:</label>

                                        <div class="m-form__control">
                                            <span class="m-subheader__daterange btn btn-sm btn-outline-primary" style="padding: 0.15rem 0.8rem; width: -webkit-fill-available;" id="daterangepicker">
                                                <span class="m-subheader__daterange-label">
                                                    <span class="m-subheader__daterange-title"></span>
                                                    <span class="m-subheader__daterange-date"></span>
                                                    <asp:HiddenField ID="start_date" ClientIDMode="Static" runat="server" />
                                                    <asp:HiddenField ID="end_date" ClientIDMode="Static" runat="server" />
                                                    <asp:HiddenField ID="hdn_IsPostBack" ClientIDMode="Static" runat="server" />
                                                    <asp:HiddenField ID="date_range_title" ClientIDMode="Static" runat="server" />
                                                    <asp:HiddenField ID="hdnTicketStatus" ClientIDMode="Static" runat="server" />
                                                    <asp:HiddenField ID="hdnActionStatus" ClientIDMode="Static" runat="server" />
                                                </span>
                                                <button type="button" class="btn btn-primary btn-outline-primary m-btn m-btn--icon m-btn--icon-only m-btn--custom m-btn--pill m--font-light">
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
                                <div class="row m--align-center" style="padding-top: 1rem;">
                                    <div class="col-lg-6 m--margin-bottom-10-tablet-and-mobile">
                                        <input type="text" class="form-control m-input" placeholder="Search..." id="generalSearch" />

                                    </div>

                                    <div class="col-lg-6 m--margin-bottom-10-tablet-and-mobile">
                                        <div class="m-form__control">
                                            <a href="<%= Page.ResolveClientUrl("~/CheckList/Checklist_Consolidated_Report_List.aspx") %>" class="btn btn-brand m-btn m-btn--icon" style="width: -webkit-fill-available;">
                                                <span>
                                                    <i class="flaticon-diagram"></i>
                                                    <span style="white-space: normal !important; word-wrap: break-word;">Generate Consolidated Checklist Report</span>
                                                </span>
                                            </a>

                                        </div>

                                    </div>

                                </div>



                            </div>

                            <!--end: Search Form -->

                            <!--begin: Datatable -->
                            <div id="m_table_1_wrapper" class="dataTables_wrapper dt-bootstrap4">
                                    <div class="row">
                                        <div class="col-sm-12"> 

                                            <table class="m-datatable" id="html_table" width="100%">
                                                <thead>
                                                    <tr>
                                                        <%--<th title="Field #1" data-field="SrNo">Sr. No</th>--%>
                                                        <%--<th title="Config ID" data-field="Chk_Config_ID">Checklist Config ID</th>--%>
                                                        <th title="Checklist No" data-field="Chk_Response_No">Checklist No</th>
                                                        <th title="Checklist Name" data-field="Checklist Name">Checklist Name</th>
                                                        <th title="Department" data-field="Department">Department</th>
                                                        <th title="Location" data-field="Location">Location</th>
                                                        <th title="Start Time" data-field="Start Time">Start Time</th>
                                                        <th title="End Time" data-field="End Time">End Time</th>
                                                        <th title="Total Hrs" data-field="Total Hrs">Total Hrs</th>
                                                        <th title="PercentCompleted" data-field="PercentCompleted">Progress</th>
                                                        <th title="Generated_By" data-field="Generated_By">Generated By</th>
                                                        <th title="Status" data-field="Status">Status</th>

                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <%=fetchChkReportListing()%>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            <!--end: Datatable -->

                        </div>

                    </div>

                    <!-- END EXAMPLE TABLE PORTLET-->
                </div>
            </div>
        </div>
    </div>


    <%--</form>--%>
</asp:Content>

