<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Store_Opening_Closing_Report.aspx.cs" Inherits="Upkeep_v3.Store_Attendance.Store_Opening_Closing_Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#m_table_1').DataTable({
                responsive: true,
                pagingType: 'full_numbers',
                'fnDrawCallback': function () {
                    init_plugins();
                }
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="m-portlet m-portlet--mobile">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <h3 class="m-portlet__head-text">Store Opening and Closing Report		
                            </h3>
                        </div>
                    </div>
                    <div class="m-portlet__head-tools">
                                <a href="#" class="btn btn-success  m-btn m-btn--icon m-btn--wide m-btn--md">
                                    <span>
                                        <i class="fa fa-file-excel"></i>
                                        <span>Export</span>
                                    </span>
                                </a>
                    </div>
                </div>
                <div class="m-portlet__body">

                    <!--begin: Datatable -->
                    <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">
                        <thead>
                            <tr>
                                <th>Store Name</th>
                                <th>Store Manager</th>
                                <th>Date</th>
                                <th>Store Opening Time</th>
                                <th>Store Closing Time</th>
                                <th>Total Hrs</th>
                            </tr>
                        </thead>

                        <tbody>
                            <%=Fetch_Store_Attendance()%>
                        </tbody>
                    </table>
                </div>
            </div>

            <!-- END EXAMPLE TABLE PORTLET-->

        </div>
    </div>
</asp:Content>

