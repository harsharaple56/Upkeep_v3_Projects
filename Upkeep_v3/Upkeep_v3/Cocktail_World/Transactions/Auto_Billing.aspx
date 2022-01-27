<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Auto_Billing.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Transactions.Auto_Billing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>

    <style type="text/css">
        .auto-style1 {
            height: 21px;
        }
    </style>
     <script type="text/javascript">
        $(document).ready(function () {
            $('#m_table_1').DataTable({
                pagingType: 'full_numbers',
                scrollX: true,
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
                            <h3 class="m-portlet__head-text">Auto Billing Transactions</h3>
                        </div>
                    </div>

                    <div class="m-portlet__head-tools">
                        
                        <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Transactions/Select_Transaction.aspx") %>" class="btn btn-metal m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m--margin-right-10">
                            <span>
                                <i class="la la-arrow-left"></i>
                                <span>Back</span>
                            </span>
                        </a>
                        <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Transactions/Add_Auto_Billing.aspx") %>" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                            <span>
                                <i class="fa fa-plus"></i>
                                <span>Add Auto Billing</span>
                            </span>
                        </a>
                    </div>

                </div>

                <div class="m-portlet__body">

                    <!--begin: Datatable -->
                    <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1" width="100%">
                        <thead>
                            <tr>
                                <th>Transaction ID</th>
                                <th>Bill No</th>
                                <th>Sale Date</th>
                                <th>License Name</th>
                                <th>Created By</th>
                                <th>Created Date</th>
                                <th>Action</th>

                            </tr>
                        </thead>

                        <tbody>
                            <%=Fetch_Sales_Transaction()%>
                        </tbody>
                    </table>

                    <!--end: Datatable -->

                </div>
            </div>

            <!-- END EXAMPLE TABLE PORTLET-->
        </div>
    </div>


</asp:Content>
