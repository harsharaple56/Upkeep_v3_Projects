<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Frm_Category.aspx.cs" Inherits="Upkeep_v3.Ticketing.Frm_Category" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>

    <%--<script type="text/javascript" src="https://code.jquery.com/jquery-2.1.4.min.js"></script>
    <script src="http://code.jquery.com/ui/1.11.2/jquery-ui.js"></script>--%>

    <%-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>

    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>--%>

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

        .form-group {
            margin-bottom: 0rem;
        }
    </style>

    <script type="text/javascript">

        function CheckForm() {
            if ($('#<%=txtCategoryDesc.ClientID %>').val() == "") {
                alert('Please Enter Category Desc');
                return false;
            }
            return true;
        }

        function openModal() {
            //alert('hgfhfghfg');
            $('#Add_Category').modal('show');
        }

    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            //$('#btnedit').click(function () {
            $("#btnedit").click(function () {
                //alert('edit');
                $('#Add_Category').modal('show');

            });

        });

        function openModal() {
            //alert('Hii');
            $('#Add_Category').modal('show');
        }

    </script>

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

    <div runat="server">
        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
        <div class="m-grid__item m-grid__item--fluid">
            <div class="m-content">
                <div class="m-portlet m-portlet--mobile">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <a href="#" style="width: 25px; height: 25px; margin-right:5px;" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="Create , Update and Delete your Ticket Categories. You can assign different Ticket Categories to different Departments">
                                    <i class="fa fa-info-circle"></i>
                                </a>
                                <h3 class="m-portlet__head-text">Ticket Categories		
                                </h3>

                            </div>
                        </div>
                        <div class="m-portlet__head-tools">
                            <ul class="m-portlet__nav">
                                <li class="m-portlet__nav-item">

                                    <a href="#" id="btnAddcategory" runat="server" onserverclick="btnAddcategory_Click1" class="btn btn-success m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="Create , Update and Delete your Ticket Categories. You can assign different Ticket Categories to different Departments">
                                        <span>
                                            <i class="flaticon-add"></i>
                                            <span>Add New Category</span>
                                        </span>
                                    </a>

                                    <cc1:ModalPopupExtender ID="mpeCategoryMaster" runat="server" PopupControlID="pnlCategoryMaster" TargetControlID="btnAddCategory"
                                        CancelControlID="btnCloseHeader" BackgroundCssClass="modalBackground">
                                    </cc1:ModalPopupExtender>

                                    <%--<a href="#Add_Category" class="btn btn-info m-btn m-btn--custom m-btn--icon m-btn--air" data-toggle="modal">
                                        <span>
                                    --%>        <%--<i class="la la-plus"></i>
                                            <span>New Category</span>--%>
                                    <%-- </span>
                                    </a>--%>


                                </li>
                            </ul>

                            <%--  <asp:Button ID="Add_Category1" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md"  OnClick="btnAddCategory_Click" Text="+ New Category" />
                            --%>
                        </div>
                    </div>
                    <div class="m-portlet__body">

                        <!--begin: Datatable -->
                        <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">


                            <thead>

                                <tr>
                                    <th>Category Description</th>
                                    <th>Assigned Department</th>
                                    <th>Action</th>
                                </tr>

                            </thead>
                            <%-- <tbody>
                            <tr>
                                <td>compel</td>
                                <td>hjsdhfsj</td>
                            </tr>
                        </tbody>--%>
                            <tbody>
                                <%=bindgrid()%>
                            </tbody>
                        </table>
                    </div>
                </div>

                <!-- END EXAMPLE TABLE PORTLET-->
            </div>
        </div>
    </div>
    <!-- Start Modal -->
    <%--   <div class="modal fade" id="Add_Category" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-sm" role="document">
                <div class="modal-content" id="dvpopup" runat="server">

                
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Add New Category</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">

                        <div class="form-group">
                            <label for="recipient-name" class="form-control-label">Category Desc:</label>

                            <asp:TextBox ID="txtCategoryDesc" runat="server" class="form-control"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="rfvDeptDesc" runat="server" ControlToValidate="txtDeptDesc" Visible="true" ValidationGroup="validationZone" ForeColor="Red" ErrorMessage="Please enter Department Desc"></asp:RequiredFieldValidator>--%>
    <%-- </div>

                    </div>

                    
                                    <div class="form-group m-form__group row">
                                        <div class="col-xl-9 col-lg-9">
                                            <asp:Label ID="lblZoneErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnCategorySave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" CausesValidation="true" ValidationGroup="validationZone" OnClick="btnCategorySave_Click" OnClientClick="return CheckForm()" Text="Save" />
                    </div>

                </div>

            </div>
        </div>--%>
    <!-- End Modal -->

    <asp:Panel ID="pnlCategoryMaster" runat="server" CssClass="modalPopup" align="center">
        <div class="" id="add_sub_location" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document" style="max-width: 590px;">
                <div class="modal-content modal-sm">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>

                            <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLabel">Add New Ticket Category</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader" runat="server" onserverclick="btnCloseCategory_Click">
                                    <span aria-hidden="true">&times;</span>
                                    <%-- <asp:Button ID="btnCloseHeader" runat="server" class="Close"/>--%>
                                </button>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <label class="form-control-label font-weight-bold">Assign Department:</label>
                                    <asp:DropDownList ID="ddlDept" class="form-control" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvDept" runat="server" ControlToValidate="ddldept" Visible="true" ValidationGroup="validationDept" ForeColor="Red" ErrorMessage="Please select Department"></asp:RequiredFieldValidator>

                                </div>
                                <div class="form-group">
                                    <label class="form-control-label font-weight-bold">Category Description:</label>
                                    <asp:TextBox ID="txtCategoryDesc" runat="server" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="txtCategoryDesc" Visible="true" ValidationGroup="validationWorkflow" ForeColor="Red" ErrorMessage="Please enter Workflow Description"></asp:RequiredFieldValidator>

                                </div>

                                <asp:Label ID="lblCategoryErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red">dddd</asp:Label>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnCategorySave" runat="server" class="btn btn-success m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air" CausesValidation="true" ValidationGroup="validationWorkflow" OnClick="btnCategorySave_Click1" Text="Save" />

                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnCategorySave" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <!-- End Modal -->
    </asp:Panel>





    </div>





</asp:Content>
