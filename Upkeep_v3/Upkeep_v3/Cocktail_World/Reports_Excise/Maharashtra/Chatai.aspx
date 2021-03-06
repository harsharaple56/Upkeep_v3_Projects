<%@ Page Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Chatai.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Reports_Excise.Maharashtra.Chatai" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .underline {
            border-bottom-color: #5867dd;
            border-bottom-width: 3px;
        }
    </style>

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

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="m-portlet m-portlet--mobile">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <h3 class="m-portlet__head-text">Chatai Report</h3>
                        </div>
                    </div>

                    <div class="m-portlet__head-tools">



                        <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports_Excise/Generate_Reports.aspx") %>" class="btn btn-metal m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m--margin-right-10">
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
                                                        <a id="export_excel" class="m-nav__link" runat="server" onserverclick="export_excel_ServerClick">
                                                            <i class="m-nav__link-icon la la-file-excel-o" style="font-size: 2rem"></i>
                                                            <span class="m-nav__link-text">Excel <b>( .xls )</b></span>
                                                        </a>
                                                    </li>
                                                    <li class="m-nav__item">
                                                        <a id="export_pdf" class="m-nav__link" runat="server" onserverclick="export_pdf_ServerClick">
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
                                <asp:DropDownList ID="ddlLicense" runat="server" CssClass="underline form-control" ClientIDMode="Static">
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


                    <div class="dataTables_scrollBody" style="position: relative; overflow: auto; width: 100%; max-height: 50vh;">
                        <table width="100%" cellpadding="2" cellspacing="2">

                            <tr>
                                <td colspan="2" class="ClsControlTd">
                                    <asp:GridView ID="grdChataiReport" runat="server" Width="100%" class="table table-striped- table-bordered table-hover table-checkable"
                                        AllowSorting="true" AutoGenerateColumns="false" CellPadding="5"
                                        PagerStyle-HorizontalAlign="Center">

                                        <AlternatingRowStyle BackColor="#E7F3FF"></AlternatingRowStyle>
                                        <Columns>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            No Records Found !!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle Height="50%" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px"
                                            HorizontalAlign="Center" />

                                        <HeaderStyle BackColor="#2E5E79" ForeColor="White"></HeaderStyle>

                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />

                                        <PagerStyle HorizontalAlign="Center"></PagerStyle>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td class="ClsControlTd" align="center" colspan="2">
                                    <asp:Label ID="lblwarn" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>

                    <!--end: Datatable -->
                </div>
            </div>

            <!-- END EXAMPLE TABLE PORTLET-->
        </div>
    </div>

</asp:Content>
