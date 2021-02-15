<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="MyActionable.aspx.cs" Inherits="Upkeep_v3.Ticketing.MyActionable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets/demo/custom/crud/metronic-datatable/base/html-table.js") %>" type="text/javascript"></script>


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
    <div runat="server">


        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <div class="">
                <div class="m-portlet m-portlet--mobile">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Ticket Details		
                                </h3>
                            </div>
                        </div>
                        <%--<div class="m-portlet__head-tools">
                            <ul class="m-portlet__nav">
                                <li class="m-portlet__nav-item">
                                    <a href="~/General_Masters/Add_Department.aspx" class="btn btn-info m-btn m-btn--custom m-btn--icon m-btn--air" data-toggle="modal">
                                        <span>
                                            <i class="la la-plus"></i>
                                            <span>New Request</span>
                                        </span>
                                    </a>


                                </li>
                            </ul>
                           
                               
                        </div>--%>
                    </div>
                    <div class="m-portlet__body">
                        <!--begin: Search Form -->

                        <div class="m-form m-form--label-align-right m--margin-bottom-30">
                            <div class="row align-items-center">
                                <div class="col-xl-8 order-2 order-xl-1">
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
                                </div>
                                <div class="col-xl-4 order-1 order-xl-2 m--align-right">
                                    <a href="<%= Page.ResolveClientUrl("~/Ticketing/Add_MyRequest.aspx") %>" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                                        <span>
                                            <i class="la la-plus"></i>
                                            <span>New Request</span>
                                        </span>
                                    </a>
                                    <div class="m-separator m-separator--dashed d-xl-none"></div>
                                </div>
                            </div>
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


</asp:Content>
