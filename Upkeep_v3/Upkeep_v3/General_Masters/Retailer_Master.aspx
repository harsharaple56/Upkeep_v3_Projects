<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Retailer_Master.aspx.cs" Inherits="Upkeep_v3.General_Masters.Retailer_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript" ></script>
    <script type="text/javascript">
            $(document).ready(function(){
                $('#m_table_1').DataTable({
                    responsive: true,
                    pagingType: 'full_numbers',
                    'fnDrawCallback': function(){
                        init_plugins();
                    }
                });
            });
        </script>

    <div runat="server" id="frmMain">
    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="m-portlet m-portlet--mobile">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <h3 class="m-portlet__head-text">Retailers		
                            </h3>
                        </div>
                    </div>
                    <div class="m-portlet__head-tools">
                        <ul class="m-portlet__nav">
                            <li class="m-portlet__nav-item">
                                <a href="<%= Page.ResolveClientUrl("Add_Retailer.aspx") %>" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md">
                                    <span>
                                        <i class="la la-plus"></i>
                                        <span>New Retailer</span>
                                    </span>
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="m-portlet__body">

                    <!--begin: Datatable -->
                    <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">
                        <thead>
                            <tr>
                                <th>Store Name</th>
                                <th>Manager Name</th>
                                <th>Email</th>
                                <th>Contact</th>
                                <th>Created on</th>
                                <th>Action</th>
                            </tr>
                        </thead>

                        <tbody>
                            <%=fetchRetailerDetails()%>
                        </tbody>


                    </table>

                    <div class="m-form m-form--label-align-left- m-form--state- m--margin-10" id="event_form1" runat="server">

                        <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="Export To Excel" class="btn btn-primary btn-success" />

                        <div class="pull-right">
                            <asp:LinkButton ID="lnkSampleFile" runat="server" Text="Download Sample File" OnClick="lnkSampleFile_Click" ></asp:LinkButton>
                            <asp:FileUpload ID="fileUpload" runat="server" />
                            <asp:Button ID="btnImportExcel" runat="server" OnClick="btnImportExcel_Click" Text="Import From Excel" class="btn btn-primary btn-success" />

                        </div>


                        <!--begin::Modal-->
                        <div class="modal fade" id="import_error_modal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="exampleModalLabel">Retailer Import Error</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">

                                        <asp:GridView ID="gvImportError" runat="server" AutoGenerateColumns="false"></asp:GridView>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!--end::Modal-->





                    </div>

                    <%--<asp:Button ID="btnExport1" runat="server" OnClick="btnExport_Click" Text="Export To Excel" class="btn btn-primary btn-success" />
                               		<input type="file" name="import_excel" id="import_excel" class="d-none" />
                               		<label for="import_excel">
                                           <button class="btn btn-success">Choose file...</button>
                                	</label>
                                    <asp:Button ID="btnImportExcel" runat="server" OnClick="btnImportExcel_Click" Text="Upload" class="btn btn-primary btn-success" />
                                </form>--%>
                </div>
            </div>

            <!-- END EXAMPLE TABLE PORTLET-->
        </div>
    </div>
</div>
</asp:Content>
