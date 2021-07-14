<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="MyRequest.aspx.cs" Inherits="Upkeep_v3.Ticketing.MyRequest" %>

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

<div class="m-content">
        <div class="m-grid__item m-grid__item--fluid">
          
                <div class="m-portlet m-portlet--mobile">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">My Tickets		
                                </h3>
                            </div>
                        </div>

                         <div class="m-portlet__head-tools">
                                <ul class="m-portlet__nav">

                                    <li class="m-portlet__nav-item">
											<a href="<%= Page.ResolveClientUrl("~/Ticketing/Add_MyRequest.aspx") %>" class="btn btn-success m-btn m-btn--custom m-btn--pill m-btn--icon m-btn--air">
												<span>
													<i class="flaticon-add"></i>
													<span>Raise New Ticket</span>
												</span>
											</a>
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
                                                        <option value="Open">Open</option>
                                                        <option value="Closed">Closed</option>
                                                        <option value="Parked">Parked</option>
                                                        <option value="Expired">Expired</option>
                                                    </select>
                                                </div>
                                    </div>


                                       <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Filter Action Status:</label>

                                    <div class="m-form__control">
                                                    <select class="form-control m-bootstrap-select" id="m_form_type">
                                                        <option value="">All</option>
                                                        <option value="Assigned">Assigned</option>
                                                        <option value="Accepted">Accepted</option>
                                                        <option value="InProgress">In Progress</option>
                                                        <option value="Hold">Hold</option>
                                                        <option value="Closed">Closed</option>
                                                        <option value="Expired">Expired</option>
                                                    </select>
                                                </div>
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

           
        </div>

    </div>

</asp:Content>
