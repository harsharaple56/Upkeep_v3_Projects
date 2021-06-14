<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Invoices_Listing.aspx.cs" Inherits="Upkeep_v3.Manage_Account.Billing.Invoices" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>

    <%-- <script src="<%= Page.ResolveClientUrl("~/assets/demo/default/custom/crud/datatables/extensions/buttons.js") %>" type="text/javascript"></script>--%>

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


    <script type="text/javascript">
        $(document).ready(function () {
            $('#m_table_1').DataTable({
                responsive: true,
                pagingType: 'full_numbers',
                scrollX: true,
                'fnDrawCallback': function () {
                    init_plugins();
                }
            });
        });


    </script>



    <div runat="server" id="frmMain">
        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
        <div class="m-content">
        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <div class="">
                <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Billing Details	
                                </h3>
                            </div>
                        </div>
                        <div class="m-portlet__head-tools">
                            <ul class="m-portlet__nav" style="margin-right: 2%;">
                                <li class="m-portlet__nav-item">
                                    <a href="https://rzp.io/l/wSqHipO" target="_blank" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                                        <span>
                                            <i class="fa fa-rupee-sign"></i>
                                            <span>Pay Online</span>
                                        </span>
                                    </a>

                                </li>
                                <%-- <asp:ImageButton ID="imgBtnExcel" runat="server" ImageUrl="../assets/app/media/img/icons/excel_32.png" ToolTip="Import Export Wizard" />--%>
                            </ul>
                        </div>
                    </div>
                    <div class="m-portlet__body">

                        <div id="" style="overflow-x: auto;" >
                            <!--begin: Datatable -->
                            <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1" >
                                <thead>
                                    <tr>
                                        <th>Invoice No.</th>
                                        <th>Description</th>
                                        <th>Amount</th>
                                        <th>GST</th>
                                        <th>Total</th>
                                        <th>Invoice Date</th>
                                        <th>Status</th>
                                        <th>Nature of Invoice</th>
                                        <th>Due Date</th>
                                        <th>View Invoice</th>
                                    </tr>
                                </thead>

                                <tbody>
                                    <%=bindGrid_Invoices()%>
                                </tbody>


                            </table>
                        </div>
                    </div>
                </div>

                <!-- END EXAMPLE TABLE PORTLET-->
            </div>
        </div>
    </div>

        <asp:Panel ID="pnlImportExport" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
            <div class="" id="add_sub_location" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document" style="max-width: 590px;">
                    <div class="modal-content">
                        <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>--%>

                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Import Data</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader">
                                <span aria-hidden="true">&times;</span>
                                <%-- <asp:Button ID="btnCloseHeader" runat="server" class="Close"/>--%>
                            </button>
                        </div>
                        <div class="modal-body">

                            <div class="form-group m-form__group row">
                                <div class="col-xl-1 col-lg-1"></div>
                                <div class="col-xl-10 col-lg-10" style="overflow-y: auto; height: 280px; display: none;" id="dvErrorGrid" runat="server">
                                    <asp:GridView ID="gvImportError" runat="server" AutoGenerateColumns="true" HeaderStyle-BackColor="#f4f3f8" HeaderStyle-ForeColor="Black"
                                        CssClass="table table-striped- table-bordered table-hover table-checkable">
                                    </asp:GridView>
                                </div>
                            </div>



                            <div class="modal-footer">
                                <%--<asp:Button ID="btnSubCategorySave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" CausesValidation="true" ValidationGroup="validationSubCategory" Text="Save" />--%>
                            </div>
                            <%-- </ContentTemplate>--%>
                            <%--<Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnSubCategorySave" EventName="Click" />
                            </Triggers>--%>
                            <%--</asp:UpdatePanel>--%>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>


    </div>

</asp:Content>
