<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SubPack_Mst.aspx.cs" Inherits="Upkeep_v3_Control_Center.Masters.SubPack_Mst" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>

    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
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
    </style>

    <script type="text/javascript">

       <%-- function CheckForm() {
            if ($('#<%=txtCategoryDesc.ClientID %>').val() == "") {
                alert('Please Enter Category Desc');
                return false;
            }
            return true;
        }--%>

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
                //responsive: true,
                pagingType: 'full_numbers',
                'fnDrawCallback': function () {
                    init_plugins();
                }
            });
        });
    </script>


    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="row">
                <div class="col-lg-12">

                    <form class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" runat="server" id="frmLicense" method="post">
                        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
                        <div class="m-portlet m-portlet--mobile">
                            <div class="m-portlet__head">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">Subscription Package	
                                        </h3>
                                    </div>
                                </div>
                                <div class="m-portlet__head-tools">
                                    <ul class="m-portlet__nav">
                                        <li class="m-portlet__nav-item">
                                            <asp:Button ID="btnAddPackage" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="+ New Package" />

                                            <cc1:ModalPopupExtender ID="mpePackage" runat="server" PopupControlID="pnlPackage" TargetControlID="btnAddPackage"
                                                CancelControlID="btnCloseHeader" BackgroundCssClass="modalBackground">
                                            </cc1:ModalPopupExtender>

                                            <%--<a href="EmployeeDetails.aspx" class="btn btn-info m-btn m-btn--custom m-btn--icon m-btn--air">
                                    <span>
                                        <i class="la la-plus"></i>
                                        <span>New Package</span>
                                    </span>
                                </a>--%>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div class="m-portlet__body">

                                <!--begin: Datatable -->
                                <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">

                                    <thead>
                                        <tr>
                                            <th>Subscription Package Details</th>
                                            <th>No Of Days</th>
                                            <th>Price</th>
                                            <th>Actions</th>

                                        </tr>

                                    </thead>
                                     <tbody>
                                        <%=bind_Package_Grid()%>
                                    </tbody>
                                </table>
                            </div>
                        </div>

                        <!-- END EXAMPLE TABLE PORTLET-->



                        <asp:Panel ID="pnlPackage" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
                            <div class="" id="add_sub_location" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document" style="max-width: 590px;">
                                    <div class="modal-content">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>

                                                <div class="modal-header">
                                                    <h5 class="modal-title" id="exampleModalLabel">Package Details</h5>
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader">
                                                        <span aria-hidden="true">&times;</span>

                                                    </button>
                                                </div>
                                                <div class="modal-body">

                                                    <div class="form-group m-form__group row">
                                                        <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Package Name :</label>
                                                        <asp:TextBox ID="txtPackage" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvDept" runat="server" ControlToValidate="txtPackage" Visible="true" Style="margin-left: 34%;" ValidationGroup="validatePackage"
                                                            Display="Dynamic" ForeColor="Red" ErrorMessage="Please enter Package Name"></asp:RequiredFieldValidator>
                                                    </div>

                                                    <div class="form-group m-form__group row">
                                                        <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">No Of Days :</label>
                                                        <asp:TextBox ID="txtNoOfDays" runat="server" TextMode="Number" class="form-control" Style="width: 60%;"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="txtNoOfDays" Visible="true" Style="margin-left: 34%;" ValidationGroup="validatePackage"
                                                            Display="Dynamic" ForeColor="Red" ErrorMessage="Please enter No Of Days"></asp:RequiredFieldValidator>

                                                    </div>

                                                    <div class="form-group m-form__group row">
                                                        <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Price :</label>
                                                        <asp:TextBox ID="txtPrice" runat="server" TextMode="Number" class="form-control" Style="width: 60%;"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPrice" Visible="true" Style="margin-left: 34%;" ValidationGroup="validatePackage"
                                                            Display="Dynamic" ForeColor="Red" ErrorMessage="Please enter Price"></asp:RequiredFieldValidator>

                                                    </div>

                                                    <asp:Label ID="lblPackageErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                                </div>


                                                <div class="modal-footer">
                                                    <asp:Button ID="btnClosePackage" Text="Close" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnClosePackage_Click" />
                                                    <asp:Button ID="btnSavePackage" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" CausesValidation="true" ValidationGroup="validatePackage" OnClick="btnSavePackage_Click" Text="Save" />

                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnSavePackage" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                            <!-- End Modal -->
                        </asp:Panel>

                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
