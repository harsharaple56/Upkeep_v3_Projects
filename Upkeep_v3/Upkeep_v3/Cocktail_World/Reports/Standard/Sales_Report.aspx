<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Sales_Report.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Reports.Sales_Report" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


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

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="m-portlet m-portlet--mobile">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <h3 class="m-portlet__head-text">Brand Summary Report</h3>
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


                                                    <li class="m-nav__item">
                                                        <a id="export_excel" class="m-nav__link" href="javascript:__doPostBack('export_excel','')">
                                                            <i class="m-nav__link-icon la la-file-excel-o" style="font-size: 2rem"></i>
                                                            <span class="m-nav__link-text">Excel <b>( .xls )</b></span>
                                                        </a>
                                                    </li>
                                                    <li class="m-nav__item">
                                                        <a id="export_pdf" class="m-nav__link" href="javascript:__doPostBack('export_pdf','')">
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

                    <form class="m-form m-form--fit m--margin-bottom-20">
                        <div class="row m--margin-bottom-20 m--align-center">
                            <div class="col-lg-4 m--margin-bottom-10-tablet-and-mobile">
                                <label class="font-weight-bold">Search Data:</label>
                                <input type="text" class="form-control m-input" placeholder="Search..." id="generalSearch" />
                            </div>

                            <div class="col-lg-4 m--margin-bottom-10-tablet-and-mobile">
                                <label class="font-weight-bold">Filter by License:</label>

                                <div class="m-form__control">
                                    <asp:DropDownList ID="ddlLicense" runat="server" CssClass="form-control" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-lg-4 m--margin-bottom-10-tablet-and-mobile">
                                <label class="font-weight-bold">Filter by Category:</label>

                                <div class="m-form__control">
                                    <asp:DropDownList ID="m_form_status" runat="server" CssClass="form-control" ClientIDMode="Static">
                                        <asp:ListItem Value="All" Text="All"></asp:ListItem>
                                        <asp:ListItem Value="Open" Text="Open"></asp:ListItem>
                                        <asp:ListItem Value="Parked" Text="Parked"></asp:ListItem>
                                        <asp:ListItem Value="Closed" Text="Closed"></asp:ListItem>
                                        <asp:ListItem Value="Expired" Text="Expired"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>



                            </div>
                        </div>
                         <div class="row m--margin-bottom-20 m--align-center">
                            <div class="col-lg-4 m--margin-bottom-10-tablet-and-mobile">
                                <label class="font-weight-bold">Filter Brand:</label>

                                <div class="m-form__control">

                                    <asp:DropDownList ID="m_form_type" runat="server" CssClass="form-control" ClientIDMode="Static">
                                        <asp:ListItem Value="All" Text="All"></asp:ListItem>
                                        <asp:ListItem Value="In Progress" Text="In Progress"></asp:ListItem>
                                        <asp:ListItem Value="Accepted" Text="Accepted"></asp:ListItem>
                                        <asp:ListItem Value="Assigned" Text="Assigned"></asp:ListItem>
                                        <asp:ListItem Value="Hold" Text="Hold"></asp:ListItem>
                                        <asp:ListItem Value="Closed" Text="Closed"></asp:ListItem>
                                        <asp:ListItem Value="Expired" Text="Expired"></asp:ListItem>
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
                                    <button type="button" class="btn m-btn--pill    btn-primary m-btn m-btn--custom">
                                        <span>
                                            <i class="la la-search"></i>
                                            <span>Search</span>
                                        </span>
                                    </button>
                                </div>

                            </div>
                        </div>
                    </form>




                    <!--begin: Datatable -->
                    <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1" width="100%">
                        <thead>
                            <tr>
                                <th><b>Brand</b></th>
                                <th>Category</th>
                                <th>Sub-Category</th>
                                <th>Size</th>
                                <th>Opening</th>
                                <th>Purchase</th>
                                <th>Total</th>
                                <th><b>Sale</b></th>
                                <th><b>Closing</b></th>

                            </tr>
                        </thead>

                        <tbody>
                        </tbody>
                    </table>

                    <!--end: Datatable -->

                </div>
            </div>

            <!-- END EXAMPLE TABLE PORTLET-->
        </div>
    </div>

</asp:Content>

