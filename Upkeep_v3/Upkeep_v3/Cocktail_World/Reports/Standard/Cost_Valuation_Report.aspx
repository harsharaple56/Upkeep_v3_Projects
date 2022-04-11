<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Cost_Valuation_Report.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Reports.Standard.Cost_Valuation_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
     <script>
        $(document).ready(function () {


            $('.m_selectpicker').selectpicker();
            //alert('1111');
            var picker = $('#daterangepicker');
            var start = moment().subtract(6, 'days');
            var end = moment();
            //var start = moment();
            //var end = moment().add(30, 'days');


            function cb(start, end, label) {
                var title = '';
                var range = '';


                range = start.format('DD-MMM-YYYY') + ' - ' + end.format('DD-MMM-YYYY');

                picker.find('.m-subheader__daterange-date').html(range);
                picker.find('.m-subheader__daterange-title').html(title);

                $('#start_date').val(start.format('DD-MMM-YYYY'));
                $('#end_date').val(end.format('DD-MMM-YYYY'));
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

            $("#m_form_status").on("change", function () {
                //alert($(this).val());
                $('#hdnTicketStatus').val($(this).val());
            })

            $("#m_form_type").on("change", function () {
                //alert($(this).val());
                $('#hdnActionStatus').val($(this).val());
            })

        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#m_table_1').DataTable({
                responsive: true,
                pagingType: 'full_numbers',
                'fnDrawCallback': function () {
                    init_plugins();
                }
            });

            $('#m_table_2').DataTable({
                responsive: true,
                pagingType: 'full_numbers',
                'fnDrawCallback': function () {
                    init_plugins();
                }
            });
        });
    </script>

    <div runat="server">
        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
        <div class="m-grid__item m-grid__item--fluid">
            <div class="m-content">
                <div class="m-portlet m-portlet--mobile">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Cost Valuation Report	</h3>
                            </div>
                        </div>
                        <div class="m-portlet__head-tools">
                            <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports/View_Reports.aspx") %>" class="btn btn-metal m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m--margin-right-10">
                                <span>
                                    <i class="la la-arrow-left"></i>
                                    <span>Back</span>
                                </span>
                            </a>
                            <ul class="m-portlet__nav">
                                <li class="m-portlet__nav-item m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover" aria-expanded="true">

                                    <a href="#" class="btn m-btn--pill btn-outline-focus m-btn--icon m-btn--air">
                                        <span>
                                            <i class="fa fa-database" aria-hidden="true"></i>
                                            <span>Export Data</span>
                                        </span>

                                    </a>
                                    <div class="m-dropdown__wrapper" style="z-index: 101;">
                                        <span class="m-dropdown__arrow m-dropdown__arrow--right m-dropdown__arrow--adjust" style="left: auto; right: 73px;"></span>
                                        <div class="m-dropdown__inner">
                                            <div class="m-dropdown__body">
                                                <div class="m-dropdown__content">
                                                    <ul class="m-nav">
                                                        <li class="m-nav__section m-nav__section--first">
                                                            <span class="m-nav__section-text">Export Data Format</span>
                                                        </li>
                                                        <hr />

                                                        <li class="m-nav__item">
                                                            <a id="export_excel" class="m-nav__link" runat="server">
                                                                <i class="m-nav__link-icon la la-file-excel-o" style="font-size: 2rem"></i>
                                                                <span class="m-nav__link-text">Excel <b>( .xls )</b></span>
                                                            </a>
                                                        </li>
                                                        <li class="m-nav__item">
                                                            <a id="export_pdf" class="m-nav__link" runat="server">
                                                                <i class="m-nav__link-icon la la-file-pdf-o" style="font-size: 2rem"></i>
                                                                <span class="m-nav__link-text">PDF <b>( .pdf )</b></span>
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
                        <div class="row m--margin-bottom-20 m--align-center">
                            <div class="col-lg-4 m--margin-bottom-10-tablet-and-mobile">
                                <label class="font-weight-bold">Filter by License:</label>

                                <div class="m-form__control">
                                    <asp:DropDownList ID="ddlLicense" AutoPostBack="false" runat="server" CssClass="underline form-control" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-lg-4 m--margin-bottom-10-tablet-and-mobile">
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
                                            <asp:HiddenField ID="hdnTicketStatus" ClientIDMode="Static" runat="server" />
                                            <asp:HiddenField ID="hdnActionStatus" ClientIDMode="Static" runat="server" />
                                        </span>
                                        <button type="button" class="btn btn-brand btn-outline-brand m-btn m-btn--icon m-btn--icon-only m-btn--custom m-btn--pill m--font-brand">
                                            <i class="la la-angle-down"></i>
                                        </button>
                                    </span>
                                </div>

                            </div>

                            <div class="col-lg-4 m--margin-bottom-10-tablet-and-mobile">
                                <label class="font-weight-bold">Search Filters:</label>
                                <div class="m-form__control">
                                    <button id="btnSearch" runat="server" class="btn m-btn--pill    btn-primary m-btn m-btn--custom">
                                        <span>
                                            <i class="la la-search"></i>
                                            <span>Search</span>
                                        </span>
                                    </button>
                                </div>

                            </div>
                        </div>
                        <hr/>
                        <ul class="nav nav-tabs m-tabs-line m-tabs-line--primary m-tabs-line--2x" role="tablist">
                            <li class="nav-item m-tabs__item">
                                <a class="nav-link m-tabs__link active show" data-toggle="tab" href="#m_tabs_6_1" role="tab">
                                    <i class="fa fa-wine-bottle"></i>Brand 
                                </a>
                            </li>


                            <li class="nav-item m-tabs__item">
                                <a class="nav-link m-tabs__link" data-toggle="tab" href="#m_tabs_6_3" role="tab">
                                    <i class="fa fa-glass-cheers"></i>Category
                                </a>
                            </li>
                        </ul>

                        <div class="tab-content">
                            <div class="tab-pane active show" id="m_tabs_6_1" role="tabpanel">

                                <div class="row">
                                    <div class="col-xl-12">
                                        <!--begin::Portlet-->
                                        <div class="m-portlet m-portlet--bordered-semi">
                                            <div class="m-portlet__head">
                                                <div class="m-portlet__head-caption">
                                                    <div class="m-portlet__head-title">
                                                        <span class="m-portlet__head-icon">
                                                            <i class="la la-file-text-o" style="font-size: 2.4rem;" aria-hidden="true"></i>

                                                        </span>
                                                        <h3 class="m-portlet__head-text">Brand Wise Report
                                                        </h3>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="m-portlet__body">
                                                <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">
                                                    <thead>
                                                        <tr>
                                                            <th>Brand</th>
                                                            <th>Size</th>
                                                            <th>Category</th>
                                                            <th>Opening Stock</th>
                                                            <th>Opening Unit Cost</th>
                                                            <th>Opening Cost Value</th>
                                                            <th>Purchase</th>
                                                            <th>Purchase Cost</th>
                                                            <th>Sale</th>
                                                            <th>Sale Revenue</th>
                                                            <th>Sale Cost</th>
                                                            <th>Sale Profit</th>
                                                            <th>Closing Stock</th>
                                                            <th>Closing Unit Cost </th>
                                                            <th>Closing Cost Value</th>
                                                        </tr>

                                                    </thead>
                                                    <tbody>
                                                        <%=Bind_BrandReport()%>
                                                    </tbody>

                                                </table>
                                            </div>
                                        </div>
                                        <!--end::Portlet-->

                                    </div>
                                </div>

                            </div>
                            <div class="tab-pane" id="m_tabs_6_3" role="tabpanel">
                                <div class="row">
                                    <div class="col-xl-12">
                                        <!--begin::Portlet-->
                                        <div class="m-portlet m-portlet--bordered-semi">
                                            <div class="m-portlet__head">
                                                <div class="m-portlet__head-caption">
                                                    <div class="m-portlet__head-title">
                                                        <span class="m-portlet__head-icon">
                                                            <i class="la la-file-text-o" style="font-size: 2.4rem;" aria-hidden="true"></i>

                                                        </span>
                                                        <h3 class="m-portlet__head-text">Category Wise Report
                                                        </h3>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="m-portlet__body">
                                                <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_2">
                                                   <thead>
                                                        <tr>
                                                            <th>Category</th>
                                                            <th>Size</th>
                                                            <th>Stock</th>
                                                            <th>Unit Cost </th>
                                                            <th>Cost Value</th>
                                                        </tr>

                                                    </thead>
                                                    <tbody>
                                                        <%=Bind_CategoryReport()%>
                                                    </tbody>

                                                </table>
                                            </div>
                                        </div>
                                        <!--end::Portlet-->

                                    </div>
                                </div>

                            </div>
                        </div>
                        <!--begin: Datatable -->

                    </div>
                </div>
                <!-- END EXAMPLE TABLE PORTLET-->
            </div>
        </div>
    </div>

</asp:Content>




