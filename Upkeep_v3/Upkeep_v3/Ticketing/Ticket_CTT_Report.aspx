<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Ticket_CTT_Report.aspx.cs" Inherits="Upkeep_v3.Ticketing.Ticket_CTT_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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

                    responsive: true,
                    pagingType: 'full_numbers',
                    scrollX: true,
                    'fnDrawCallback': function () {
                        init_plugins();
                    }
                })
            }
        };
    </script>

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

    <style type="text/css">
        .hiddencol {
            display: none;
        }
    </style>

    <style>
        th {
            /*background: cornflowerblue !important;
        color:white !important;
        position: sticky !important;*/
            top: 0;
            box-shadow: 0 2px 2px -1px rgba(0, 0, 0, 0.4);
        }

        th, td {
            padding: 0.25rem;
        }
    </style>
    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="row">
                <div class="col-lg-12">
                    <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <div class="m-portlet__head">

                            <div class="m-portlet__head-wrapper">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">Ticket CTT Report
                                        </h3>
                                    </div>
                                </div>
                            </div>


                            <div class="m-portlet__head-tools">
                                <ul class="m-portlet__nav">
                                    <li class="m-portlet__nav-item"></li>
                                    <li class="m-portlet__nav-item"></li>
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
                                                                <a class="m-nav__link" id="export_excel" onserverclick="btnExport_Click" runat="server">
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



                            <form class="m-form m-form--fit m--margin-bottom-20">
                                <div class="row m--margin-bottom-20 m--align-center">
                                    <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Search Data:</label>
                                        <input type="text" class="form-control m-input" placeholder="Search..." id="generalSearch" />

                                    </div>
                                    <div class="col-lg-2 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Filter by Status:</label>

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
                                    <div class="col-lg-2 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Filter Action Status:</label>

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
                                    <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Filter Date Range:</label>

                                        <div class="m-form__control">
                                            <span class="m-subheader__daterange btn btn-sm btn-outline-accent" style="padding: 0.15rem 0.8rem; width: -webkit-fill-available;" id="daterangepicker">
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
                                                <button type="button" class="btn btn-accent btn-outline-accent m-btn m-btn--icon m-btn--icon-only m-btn--custom m-btn--pill m--font-light">
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
                            </form>



                            <div id="m_table_1_wrapper" class="dataTables_wrapper dt-bootstrap4">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="table table-striped- table-bordered table-hover table-checkable dataTable dtr-inline" id="m_table_1" style="overflow-x: auto;">

                                            <asp:GridView ID="gvCTT_Report" runat="server" CssClass="table table-striped- table-bordered table-hover table-checkable m-datatable"
                                                OnRowDataBound="gvCTT_Report_RowDataBound" OnRowCommand="gvCTT_Report_RowCommand" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                                                AutoGenerateColumns="false" EmptyDataText="No records found.">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Ticket No" ItemStyle-Width="80px" HeaderStyle-Width="80px">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hdnTicketID" runat="server" Value='<%#Eval("Ticket_ID") %>' />
                                                            <asp:LinkButton ID="lnkTicketID" runat="server" CommandName="ViewTicket" CommandArgument="<%# Container.DataItemIndex %>" Text='<%#Eval("Tkt_Code") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Loc_Desc" HeaderText="Location" ItemStyle-Width="250" HeaderStyle-Width="100" />
                                                    <asp:BoundField DataField="Dept_Desc" HeaderText="Department" ItemStyle-Width="150" />
                                                    <asp:BoundField DataField="Category_Desc" HeaderText="Category" ItemStyle-Width="150" />
                                                    <asp:BoundField DataField="SubCategory_Desc" HeaderText="Sub Category" ItemStyle-Width="150" />
                                                    <asp:BoundField DataField="Ticket_Date_Time" HeaderText="Ticket Date & Time" ItemStyle-Width="150" />
                                                    <asp:BoundField DataField="Ticket_RaisedBy" HeaderText="Ticket RaisedBy" ItemStyle-Width="100" />
                                                    <asp:BoundField DataField="Ticket_Closing_Date_Time" HeaderText="Ticket Closing Date & Time" ItemStyle-Width="150" />
                                                    <asp:BoundField DataField="RequestStatus" HeaderText="Request Status" ItemStyle-Width="100" />
                                                    <asp:BoundField DataField="ActionStatus" HeaderText="Action Status" ItemStyle-Width="100" />
                                                    <asp:BoundField DataField="Down_Time" HeaderText="Down Time" ItemStyle-Width="150" />
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <div align="center">No records found.</div>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </div>
                                    
                                    </div>
                                </div>
                            </div>



                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>


</asp:Content>
