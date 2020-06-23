<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Ticket_CTT_Report.aspx.cs" Inherits="Upkeep_v3.Ticketing.Ticket_CTT_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets/demo/custom/crud/metronic-datatable/base/html-table.js") %>" type="text/javascript" ></script>
   
    <script type="text/javascript">
        $(document).ready(function () {
            DatatableHtmlTableDemo.init();
        });

        var DatatableHtmlTableDemo = {
            init: function () {
                var e; e = $(".m-datatable").mDatatable({
                    data: { saveState: { cookie: !1 } },
                    search: { input: $("#generalSearch") }

                    , responsive: true,
                    pagingType: 'full_numbers',
                    scrollX: true,
                    'fnDrawCallback': function () {
                        init_plugins();
                    }
                })               
            }
        };
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

                            </div>
                        </div>

                        <div class="m-portlet__body" style="padding: 0.4rem 2.2rem;">

                            <br />
                            <div class="form-group m-form__group row">
                                <div class="col-md-3">
                                    <div class="m-input-icon m-input-icon--left">
                                        <input type="text" class="form-control m-input" placeholder="Search..." id="generalSearch" />
                                        <span class="m-input-icon__icon m-input-icon__icon--left">
                                            <span><i class="la la-search"></i></span>
                                        </span>
                                    </div>
                                </div>
                                <div class="col-md-9" style="text-align: right;">
                                    <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="Export To Excel" class="btn btn-primary btn-success" />
                                </div>
                            </div>
                            <br />

                            <div class="form-group m-form__group row" style="padding-left: 1%;">

                                <div class="" id="m_table_1">
                                    <asp:GridView ID="gvCTT_Report" runat="server" CssClass="table table-striped- table-bordered table-hover table-checkable m-datatable"
                                        OnRowDataBound="gvCTT_Report_RowDataBound" OnRowCommand="gvCTT_Report_RowCommand" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                                        AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Ticket No">
                                                <ItemTemplate>                                                 
                                                    <asp:HiddenField ID="hdnTicketID" runat="server" Value='<%#Eval("Ticket_ID") %>' />
                                                    <asp:LinkButton ID="lnkTicketID" runat="server" CommandName="ViewTicket" CommandArgument="<%# Container.DataItemIndex %>" Text='<%#Eval("Tkt_Code") %>' ></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Dept_Desc" HeaderText="Department" ItemStyle-Width="150" />
                                            <asp:BoundField DataField="Category_Desc" HeaderText="Category" ItemStyle-Width="150" />
                                            <asp:BoundField DataField="SubCategory_Desc" HeaderText="Sub Category" ItemStyle-Width="150" />
                                            <asp:BoundField DataField="Ticket_Date" HeaderText="Ticket Date" ItemStyle-Width="150" />
                                            <asp:BoundField DataField="RequestStatus" HeaderText="Ticket Status" ItemStyle-Width="150" />
                                            <asp:BoundField DataField="ActionStatus" HeaderText="Action Status" ItemStyle-Width="150" />

                                        </Columns>
                                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
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
