<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Department_Master.aspx.cs" Inherits="Upkeep_v3.General_Masters.Department_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
    <script type="text/javascript">

        function CheckForm() {
            if ($('#<%=txtDeptDesc.ClientID %>').val() == "") {
                alert('Please Enter Department Desc');
                return false;
            }
            return true;
        }

    </script>

    <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

    <div runat="server" id="frmMain">


        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <div class="m-content">
                <div class="m-portlet m-portlet--mobile">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Department Master		
                                </h3>
                            </div>
                        </div>
                        <div class="m-portlet__head-tools">
                            <asp:LinkButton OnClick="btnAddDepartment_Click" ID="btnAddDepartment" runat="server" CssClass="btn btn-success m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                                <span>
                                    <i class="flaticon-add" aria-hidden="true"></i>
                                    <span>Add New Department</span>
                                </span>
                            </asp:LinkButton>

                            &nbsp;

                            <asp:LinkButton class="btn m-btn--pill btn-outline-focus m-btn--icon m-btn--air" runat="server" ID="btnImportExcelPopup">
                                                <span>
                                                    <i class="fa fa-file-import" aria-hidden="true"></i>
                                                    <span>Import Data</span>
                                                </span>
                            </asp:LinkButton>

                            <cc1:ModalPopupExtender ID="mpeUserMst" runat="server" PopupControlID="pnlImportExport" TargetControlID="btnImportExcelPopup"
                                CancelControlID="btnCloseHeader" BackgroundCssClass="modalBackground">
                            </cc1:ModalPopupExtender>
                        </div>
                    </div>
                    <div class="m-portlet__body">

                        <!--begin: Datatable -->
                        <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">


                            <thead>

                                <tr>
                                    <th>Department ID</th>
                                    <th>Department Description</th>
                                    <th>Actions</th>

                                </tr>

                            </thead>

                            <tbody>
                                <%=bindgrid()%>
                            </tbody>
                        </table>
                    </div>
                </div>

                <!-- END EXAMPLE TABLE PORTLET-->
            </div>
        </div>
        <asp:Panel ID="pnlImportExport" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
            <div class="" id="add_sub_location" tabindex="-1" aria-labelledby="exampleModalLabel1" aria-hidden="true">
                <div class="modal-dialog" role="document" style="max-width: 700px;">
                    <div class="modal-content">

                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel1">Import Data</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">

                            <div class="form-group m-form__group row">
                                <label for="message-text" class="col-xl-2 col-lg-2 form-control-label">Import :</label>
                                <div class="col-xl-8 col-lg-4 custom-file">
                                    <asp:FileUpload ID="FU_Department" CssClass="custom-file-input" runat="server" />
                                    <label class="custom-file-label" for="FU_Department">Choose file</label>

                                </div>
                                <div class="col-xl-6 col-lg-6">
                                    <asp:RequiredFieldValidator ID="rfvImport" runat="server" ControlToValidate="FU_Department" ErrorMessage="Please upload a file" ForeColor="Red"
                                        Display="Dynamic" ValidationGroup="ValidationImport"></asp:RequiredFieldValidator>
                                    <span id="ImportError_Msg" style="color: red;"></span>
                                </div>
                            </div>

                            <div class="form-group m-form__group row">
                                <asp:Label ID="lblImportErrorMsg" Text="" runat="server" CssClass="col-xl-10 col-lg-10 col-form-label" ForeColor="Red"></asp:Label>
                            </div>

                            <div class="form-group m-form__group row" style="justify-content: center;">
                                <div class="col-xl-11 col-lg-11" style="overflow-y: auto; height: 210px; display: none;" id="dvErrorGrid" runat="server">
                                    <asp:GridView ID="gvImportError" runat="server" AutoGenerateColumns="true" HeaderStyle-BackColor="#f4f3f8" HeaderStyle-ForeColor="Black"
                                        CssClass="table table-striped- table-bordered table-hover table-checkable">
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>


                        <div class="modal-footer">
                            <asp:LinkButton Style="margin-right: 250px;" ID="LinkButton1" runat="server" OnClick="lnkSampleFile_Click" ClientIDMode="Static">
                                     <img src="../assets/app/media/img/icons/download_sample_26.png" />
                                    <span>Download Sample Import File</span>
                            </asp:LinkButton>
                            <asp:Button ID="btnImportExcel" Text="Import" runat="server" OnClick="btnImportExcel_Click" ValidationGroup="ValidationImport" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" />
                            <asp:Button ID="btnCloseImportPopUp" Text="Close" OnClick="btnCloseImportPopUp_Click" runat="server" class="btn btn-danger  m-btn m-btn--icon m-btn--wide m-btn--md" />
                        </div>

                    </div>
                </div>
            </div>
        </asp:Panel>
        <!-- Start Modal -->
        <div class="modal fade" id="Add_Department1" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-sm" role="document">
                <div class="modal-content" id="dvpopup" runat="server">

                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Add New Department</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">

                        <div class="form-group">
                            <label for="recipient-name" class="form-control-label">Department Desc:</label>
                            <asp:TextBox ID="txtDeptDesc" runat="server" class="form-control"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="rfvDeptDesc" runat="server" ControlToValidate="txtDeptDesc" Visible="true" ValidationGroup="validationZone" ForeColor="Red" ErrorMessage="Please enter Department Desc"></asp:RequiredFieldValidator>--%>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnDepartmentSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" CausesValidation="true" ValidationGroup="validationZone" OnClick="btnDepartmentSave_Click" OnClientClick="return CheckForm()" Text="Save" />
                    </div>

                </div>

            </div>
        </div>
        <!-- End Modal -->
    </div>

</asp:Content>
