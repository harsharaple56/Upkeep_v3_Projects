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
                        //field: "Status", title: "Status", template: function (e) {
                        //    var t =
                        //    {
                        //        "Open": { title: "Open", class: "m-badge--danger" },
                        //        "Close": { title: "Closed", class: " m-badge--success" },
                        //        "Approve": { title: "Approved", class: " m-badge--success" },
                        //        "Hold": { title: "Hold", class: " m-badge--warning" },
                        //        "Reject": { title: "Rejected", class: " m-badge--danger" },
                        //        "Expired": { title: "Expired", class: "bg-secondary text-black" },
                        //        "In Progress": { title: "In Progress", class: "text-white bg-info" }
                        //    }; return '<span class="m-badge ' + t[e.Status].class + ' m-badge--wide">' + t[e.Status].title + "</span>"
                        //}
                        } 
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

    <%--<form method="post" runat="server" id="frmMain">--%>


        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <div class="m-content">
                <div class="m-portlet m-portlet--mobile">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text"> My Checklist Report		
                                </h3>
                            </div>
                        </div>

                        <div class="m-portlet__head-tools">
                           

                            <div class="m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-left" m-dropdown-toggle="hover" style="margin-right: 3%;">

                                <a href="#" class="m-dropdown__toggle btn btn-accent dropdown-toggle" style="padding: 5%; margin-left: 7%;">
                                    <img src="../assets/app/media/img/icons/database_export_35.png" />
                                    Export
                                </a>
                                <div class="m-dropdown__wrapper">
                                    <span class="m-dropdown__arrow m-dropdown__arrow--left"></span>
                                    <div class="m-dropdown__inner">
                                        <div class="m-dropdown__body">
                                            <div class="m-dropdown__content">
                                                <ul class="m-nav">
                                                    <li class="m-nav__item">
                                                        <a class="m-nav__link" onserverclick="btnExportExcel_Click" runat="server">
                                                            <i class="m-nav__link-icon fa fa-file-excel "></i>
                                                            <span class="m-nav__link-text">Excel</span>
                                                        </a>
                                                    </li>
                                                    <li class="m-nav__item">
                                                        <a class="m-nav__link" onserverclick="btnExportPDF_Click" runat="server">
                                                            <i class="m-nav__link-icon fa fa-file-pdf"></i>
                                                            <span class="m-nav__link-text">PDF</span>
                                                        </a>
                                                    </li>

                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            
                        </div>

                        <%--<div class="col-xl-4 order-1 order-xl-2 m--align-right">
                            <a href="<%= Page.ResolveClientUrl("~/CheckList/CheckList_Configuration.aspx") %>" style="margin-top: 5%;" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                                <span>
                                    <i class="la la-plus"></i>
                                    <span>New Checklist</span>
                                </span>
                            </a>
                            <div class="m-separator m-separator--dashed d-xl-none"></div>
                        </div>--%>

                    </div>
                    <div class="m-portlet__body">
                        <!--begin: Search Form -->

                        <div class="m-form m-form--label-align-right m--margin-bottom-30">
                            <div class="row align-items-center">
                                <div class="col-xl-12 order-2 order-xl-1">
                                    <div class="form-group m-form__group row align-items-center">
                                        <div class="col-md-3">
                                            <div class="m-form__group m-form__group--inline"> 
                                            </div>
                                            <div class="d-md-none m--margin-bottom-10"></div>
                                        </div>

                                        <div class="col-md-3">
                                            <div class="m-input-icon m-input-icon--left">
                                                <input type="text" class="form-control m-input" placeholder="Search..." id="generalSearch" />
                                                <span class="m-input-icon__icon m-input-icon__icon--left">
                                                    <span><i class="la la-search"></i></span>
                                                </span>
                                            </div>
                                        </div>

                                        <div class="col-md-6">
                                            <div class="m-form__group m-form__group--inline">
                                                <div class="m-form__label">
                                                    <label>Date:</label>
                                                </div>
                                                <div class="m-form__control">
                                                    <span class="m-subheader__daterange btn btn-sm btn-outline-accent" style="padding: 0.15rem 0.8rem;" id="daterangepicker">
                                                        <span class="m-subheader__daterange-label">
                                                            <span class="m-subheader__daterange-title"></span>
                                                            <span class="m-subheader__daterange-date"></span>
                                                            <asp:HiddenField ID="start_date" ClientIDMode="Static" runat="server" />
                                                            <asp:HiddenField ID="end_date" ClientIDMode="Static" runat="server" />
                                                            <asp:HiddenField ID="hdn_IsPostBack" ClientIDMode="Static" runat="server" />
                                                            <asp:HiddenField ID="date_range_title" ClientIDMode="Static" runat="server" />
                                                        </span>
                                                        <button type="button" class="btn btn-accent btn-outline-accent m-btn m-btn--icon m-btn--icon-only m-btn--custom m-btn--pill m--font-light">
                                                            <i class="la la-angle-down"></i>
                                                        </button>
                                                    </span>
                                                    <div class="btn-group" style="margin-left: 50px;">
                                                        <asp:Button ID="btnSearch" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnSearch_Click" Text="Search" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>



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
                                    <%--<th title="Config ID" data-field="Chk_Config_ID">Checklist Config ID</th>--%>
                                    <th title="Checklist No" data-field="Chk_Response_No">Checklist No</th>
                                    <th title="Checklist Name" data-field="Checklist Name">Checklist Name</th>
                                    <th title="Department" data-field="Department">Department</th>
                                    <th title="Location" data-field="Location">Location</th>
                                    <th title="Start Time" data-field="Start Time">Start Time</th>
                                    <th title="End Time" data-field="End Time">End Time</th>
                                    <th title="Total Hrs" data-field="Total Hrs">Total Hrs</th>
                                    <th title="Generated_By" data-field="Generated_By">Generated By</th>
                                    <th title="Status" data-field="Status">Status</th> 

                                </tr>
                            </thead>
                            <tbody>
                                 <%=fetchChkReportListing()%>  
                            </tbody>
                        </table>

                        <!--end: Datatable -->

                    </div>
                </div>

                <!-- END EXAMPLE TABLE PORTLET-->
            </div>
        </div>


    <%--</form>--%>

</asp:Content>

