<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="MyActionable.aspx.cs" Inherits="Upkeep_v3.Ticketing.MyActionable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets/demo/custom/crud/metronic-datatable/base/html-table.js") %>" type="text/javascript"></script>

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

    <%-- <script type="text/javascript">
            $(document).ready(function(){
                $('#m_table_1').DataTable({
                    responsive: true,
                    pagingType: 'full_numbers',
                    'fnDrawCallback': function(){
                        init_plugins();
                    }
                });
            });
        </script>--%>
    <%--<div runat="server">--%>


    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="">
            <div class="row">
                <div class="col-lg-12">

                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile"  id="main_portlet">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-progress">
                                <!-- here can place a progress bar-->
                            </div>
                            <div class="m-portlet__head-wrapper">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">Ticket My Actionables		
                                        </h3>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="m-input-icon m-input-icon--left">
                                        <input type="text" class="form-control m-input" placeholder="Search..." id="generalSearch" style="margin-top: 4%;"/>
                                        <span class="m-input-icon__icon m-input-icon__icon--left">
                                            <span><i class="la la-search"></i></span>
                                        </span>
                                    </div>
                                </div>


                                <div class="col-xl-4 order-1 order-xl-2 m--align-right">
                                    <a href="<%= Page.ResolveClientUrl("~/Ticketing/Add_MyRequest.aspx") %>" style="margin-top: 4%;" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                                        <span>
                                            <i class="la la-plus"></i>
                                            <span>New Request</span>
                                        </span>
                                    </a>
                                    <div class="m-separator m-separator--dashed d-xl-none"></div>
                                </div>
                            </div>
                        </div>
                        <div class="m-portlet__body">
                            <!--begin: Search Form -->

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
                                                            <asp:Button ID="btnSearch" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="Search"/>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <%-- <div class="col-md-4">
                                            <div class="m-input-icon m-input-icon--left">
                                                <input type="text" class="form-control m-input" placeholder="Search..." id="generalSearch" />
                                                <span class="m-input-icon__icon m-input-icon__icon--left">
                                                    <span><i class="la la-search"></i></span>
                                                </span>
                                            </div>
                                        </div>--%>
                                        </div>
                                    </div>
                                    <%--<div class="col-xl-4 order-1 order-xl-2 m--align-right">
                                    <a href="<%= Page.ResolveClientUrl("~/Ticketing/Add_MyRequest.aspx") %>" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                                        <span>
                                            <i class="la la-plus"></i>
                                            <span>New Request</span>
                                        </span>
                                    </a>
                                    <div class="m-separator m-separator--dashed d-xl-none"></div>
                                </div>--%>
                                </div>
                                
                                <%--<div class="col-md-3">
                                    <div class="m-input-icon m-input-icon--left">
                                        <input type="text" class="form-control m-input" placeholder="Search..." id="generalSearch" />
                                        <span class="m-input-icon__icon m-input-icon__icon--left">
                                            <span><i class="la la-search"></i></span>
                                        </span>
                                    </div>
                                </div>--%>

                            </div>

                            <!--end: Search Form -->

                            <!--begin: Datatable -->
                            <table class="m-datatable" id="html_table" width="100%">
                                <thead>
                                    <tr>
                                        <th title="Ticket Number" data-field="TicketNo">Ticket Number</th>
                                        <%--<th title="Field #2" data-field="Owner">Zone</th>--%>
                                        <th title="Location" data-field="Location">Location</th>
                                        <%--<th title="Field #4" data-field="CarMake">Sub Location</th>--%>
                                        <th title="Category" data-field="Cat">Category</th>
                                        <th title="Sub Category" data-field="SubCat">Sub Category</th>
                                        <th title="Request Date" data-field="RequestDate">Request Date</th>
                                        <th title="Raised By" data-field="RaisedBy">RaisedBy</th>
                                        <th title="Down Time" data-field="Down_Time">Down Time</th>
                                        <th title="Request Status" data-field="RequestStatus">Request Status</th>
                                        <th title="Action Status" data-field="ActionStatus">Action Status</th>
                                        <%--<th title="Field #10" data-field="Type">View</th>--%>
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
        </div>
    </div>


    <%--  </div>--%>
</asp:Content>
