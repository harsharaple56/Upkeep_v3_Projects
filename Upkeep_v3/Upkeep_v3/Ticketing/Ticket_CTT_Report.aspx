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
        <div class="">
            <div class="row">
                <div class="col-lg-12">
                    <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <%--<form class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmGatePass" method="post">--%>
                        <%--<cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>--%>


                        <div class="m-portlet__head">
                            <div class="m-portlet__head-progress">

                                <!-- here can place a progress bar-->
                            </div>
                            <div class="m-portlet__head-wrapper">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">Ticket CTT Report
                                        </h3>
                                    </div>
                                </div>
                                <div class="col-xl-4 order-1 order-xl-2 m--align-right">
                                    <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="Export To Excel" class="btn btn-primary btn-success" Style="margin-top: 4%;" />
                                    <div class="m-separator m-separator--dashed d-xl-none"></div>
                                </div>
                            </div>
                        </div>

                        <div class="m-portlet__body" style="padding: 0.4rem 2.2rem;">

                            <br />
                            <%--<div class="form-group m-form__group row">

                                <div class="col-md-3 row">
                                    <div class="m-form__group m-form__group--inline">
                                        <div class="m-form__label">
                                            <label>Status:</label>
                                        </div>
                                        <div class="m-form__control">
                                            <select class="form-control m-bootstrap-select" id="m_form_status">
                                                <option value="">All</option>
                                                <option value="Open">Open</option>
                                                <option value="Closed">Closed</option>
                                                <option value="Transferred">Transferred</option>
                                                <option value="FaultyTicket">Faulty Ticket</option>
                                            </select>
                                        </div>
                                    </div>
                                    <div class="d-md-none m--margin-bottom-10"></div>
                                </div>
                                <div class="col-md-3 row">
                                    <div class="m-form__group m-form__group--inline">
                                        <div class="m-form__label">
                                            <label class="m-label m-label--single">Action:</label>
                                        </div>
                                        <div class="m-form__control">
                                            <select class="form-control m-bootstrap-select" id="m_form_type">
                                                <option value="">All</option>
                                                <option value="Assigned">Assigned</option>
                                                <option value="Reassigned">Re-assigned</option>
                                                <option value="Parked">Parked</option>
                                                <option value="ApprovalSent">Approval Sent</option>
                                            </select>
                                        </div>
                                    </div>
                                    <div class="d-md-none m--margin-bottom-10"></div>
                                </div>


                                <div class="col-md-2">
                                    <div class="m-input-icon m-input-icon--left">
                                        <input type="text" class="form-control m-input" placeholder="Search..." id="generalSearch" />
                                        <span class="m-input-icon__icon m-input-icon__icon--left">
                                            <span><i class="la la-search"></i></span>
                                        </span>
                                    </div>
                                    
                                </div>
                                <div class="col-md-3" style="text-align: right;">
                                    <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="Export To Excel" class="btn btn-primary btn-success" />
                                </div>
                            </div>--%>

                            <div class="m-form m-form--label-align-right m--margin-bottom-30">
                                <div class="row align-items-center">
                                    <div class="col-xl-12 order-2 order-xl-1">
                                        <div class="form-group m-form__group row align-items-center">
                                            <div class="col-md-3">
                                                <div class="m-form__group m-form__group--inline">
                                                    <div class="m-form__label">
                                                        <label>Status:</label>
                                                    </div>
                                                    <div class="m-form__control">
                                                        <asp:DropDownList ID="m_form_status" runat="server" CssClass="form-control" ClientIDMode="Static">
                                                            <asp:ListItem Value="All" Text="All"></asp:ListItem>
                                                            <asp:ListItem Value="Open" Text="Open"></asp:ListItem>
                                                            <asp:ListItem Value="Parked" Text="Parked"></asp:ListItem>
                                                            <asp:ListItem Value="Closed" Text="Closed"></asp:ListItem>
                                                            <asp:ListItem Value="Expired" Text="Expired"></asp:ListItem>
                                                        </asp:DropDownList>


                                                        <%--<select class="form-control m-bootstrap-select" id="m_form_status">
                                                            <option value="">All</option>
                                                            <option value="Open">Open</option>
                                                            <option value="Parked">Parked</option>
                                                            <option value="Closed">Closed</option>
                                                        </select>--%>
                                                    </div>
                                                </div>
                                                <div class="d-md-none m--margin-bottom-10"></div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="m-form__group m-form__group--inline">
                                                    <div class="m-form__label">
                                                        <label class="m-label m-label--single">Action:</label>
                                                    </div>
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


                                                        <%--<select class="form-control m-bootstrap-select" id="m_form_type">
                                                            <option value="">All</option>
                                                            <option value="In Progress">In Progress</option>
                                                            <option value="Accepted">Accepted</option>
                                                            <option value="Assigned">Assigned</option>
                                                            <option value="Hold">Hold</option>
                                                            <option value="Closed">Closed</option>
                                                        </select>--%>
                                                    </div>
                                                </div>
                                                <div class="d-md-none m--margin-bottom-10"></div>
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
                                                                <asp:HiddenField ID="hdnTicketStatus" ClientIDMode="Static" runat="server" />
                                                                <asp:HiddenField ID="hdnActionStatus" ClientIDMode="Static" runat="server" />
                                                            </span>
                                                            <button type="button" class="btn btn-accent btn-outline-accent m-btn m-btn--icon m-btn--icon-only m-btn--custom m-btn--pill m--font-light">
                                                                <i class="la la-angle-down"></i>
                                                            </button>
                                                        </span>
                                                        <div class="btn-group" style="margin-left: 50px;">
                                                            <asp:Button ID="btnSearch" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="Search" OnClick="btnSearch_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <br />
                                        <div>
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
                                    <%--<div class="col-xl-4 order-1 order-xl-2 m--align-right">
											<asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="Export To Excel" class="btn btn-primary btn-success" />
											<div class="m-separator m-separator--dashed d-xl-none"></div>
										</div>--%>
                                </div>
                            </div>



                            <div class="form-group m-form__group row" style="padding-left: 1%;">

                                <div class="" id="m_table_1" style="overflow-x: auto;">
                                    <asp:GridView ID="gvCTT_Report" runat="server" CssClass="table table-striped- table-bordered table-hover table-checkable m-datatable"
                                        OnRowDataBound="gvCTT_Report_RowDataBound" OnRowCommand="gvCTT_Report_RowCommand" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                                        AutoGenerateColumns="false" EmptyDataText="No records found." >
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



</asp:Content>
