<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="eFacilito_PAZO_Feedback_Issues_Report.aspx.cs" Inherits="Upkeep_v3.Custom_Reports.OBRC.eFacilito_PAZO_Feedback_Issues_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="m-grid__item m-grid__item--fluid">
        <div class="m-content">
            <div class="m-portlet m-portlet--mobile">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <h3 class="m-portlet__head-text">PAZO Feedback Issues Data
                            </h3>
                        </div>
                    </div>

                    <div class="m-portlet__head-tools">
                                        <a href="<%= Page.ResolveClientUrl("~/Custom_Reports/Custom_Reports_Listing.aspx") %>" class="btn btn-metal m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                            <span>
                                                <i class="la la-arrow-left"></i>
                                                <span>Back</span>
                                            </span>
                                        </a>
                                    </div>

                </div>

                <div class="m-portlet__body">

                    <!--begin: Datatable -->

                    <div class="m-portlet__body col-lg-12" id="dvFailure" runat="server" style="display: none;">
                        <div class="m-alert m-alert--icon m-alert--air m-alert--square alert alert-danger alert-dismissible fade show" role="alert">
                            <div class="m-alert__icon">
                                <i class="la la-warning"></i>
                            </div>
                            <div class="m-alert__text">
                                <strong>Error!</strong> Something went wrong, please try again later or contact us at <b>support@efacilito.com</b>.
                            </div>
                            <div class="m-alert__close">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                </button>
                            </div>
                        </div>
                    </div>


                        <div id="m_table_1_wrapper" class="dataTables_wrapper dt-bootstrap4">
                            <div class="row">
                                <div class="col-xl-12">

                                    <div class="table table-striped- table-bordered table-hover table-checkable dataTable dtr-inline" id="m_table_1" style="overflow-x: auto;">

                                        <asp:GridView ID="gv_Pazo_GetIssues" runat="server" CssClass="table table-striped- table-bordered table-hover table-checkable m-datatablee"
                                            AutoGenerateColumns="false" EmptyDataText="No records found.">
                                            <Columns>

                                                <asp:BoundField DataField="refId" HeaderText="Issue ID" ItemStyle-Width="150" />
                                                <asp:BoundField DataField="title" HeaderText="Issue Title" ItemStyle-Width="150" />
                                                <asp:BoundField DataField="statusLabel" HeaderText="Status" ItemStyle-Width="150" />
                                                <asp:BoundField DataField="department" HeaderText="Department" ItemStyle-Width="100" />
                                                <asp:BoundField DataField="assignedTo" HeaderText="Assigned To" ItemStyle-Width="150" />
                                                <asp:BoundField DataField="timeline" HeaderText="Timeline" ItemStyle-Width="150" />
                                                <asp:BoundField DataField="createdTime" HeaderText="Created On" ItemStyle-Width="150" />
                                                <asp:BoundField DataField="createdDate" HeaderText="Created Date" ItemStyle-Width="150" />
                                                <asp:BoundField DataField="dueDate" HeaderText="Due Date" ItemStyle-Width="100" />
                                                <asp:BoundField DataField="dueTime" HeaderText="Due Time" ItemStyle-Width="100" />
                                                <asp:BoundField DataField="lastActivityOn" HeaderText="Last Activity On" ItemStyle-Width="150" />

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

                <!--end: Datatable -->
            </div>
        </div>
    </div>


</asp:Content>
