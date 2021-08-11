<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Transfers.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Transactions.Transfers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>

    <style type="text/css">
        .auto-style1 {
            height: 21px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="m-portlet m-portlet--mobile">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <h3 class="m-portlet__head-text">Stock Transfers Transactions
                            </h3>
                        </div>
                    </div>

                    <div class="m-portlet__head-tools">
                        
                        <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Transactions/Select_Transaction.aspx") %>" class="btn btn-metal m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m--margin-right-10">
                            <span>
                                <i class="la la-arrow-left"></i>
                                <span>Back</span>
                            </span>
                        </a>
                        <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Transactions/Add_Transfers.aspx") %>" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                            <span>
                                <i class="fa fa-plus"></i>
                                <span>Add New Transfer</span>
                            </span>
                        </a>
                    </div>

                </div>

                <div class="m-portlet__body">

                    <!--begin: Datatable -->
                    <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1" width="100%">
                        <thead>
                            <tr>
                                <th>Transfer Date</th>
                                <th>From License</th>
                                <th>To License</th>
                                <th>TP No.</th>
                                <th>Invoice No.</th>
                                <th>FL IV Banquet Lic.No.</th>
                                <th>Action</th>

                            </tr>
                        </thead>

                        <tbody>
                            <%--<%=Fetch_Department_Transactions()%>--%>
                        </tbody>
                    </table>

                    <!--end: Datatable -->

                </div>
            </div>

            <!-- END EXAMPLE TABLE PORTLET-->
        </div>
    </div>


</asp:Content>
