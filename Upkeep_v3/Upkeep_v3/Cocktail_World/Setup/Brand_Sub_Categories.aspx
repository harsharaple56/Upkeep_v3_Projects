<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Brand_Sub_Categories.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Setup.Brand_Sub_Categories" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .modalBackground {
            background-color: grey;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            padding: 10px;
            width: 300px;
        }
    </style>
    <script language="C#" runat="server">

        protected void LinkButton_Click(Object sender, EventArgs e)
        {
            Closecontrol();
        }

    </script>

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

    <div runat="server">
        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <div class="m-content">
                <div class="m-portlet m-portlet--mobile">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Sub Category Master		
                                </h3>
                            </div>
                        </div>
                        <div class="m-portlet__head-tools">
                            <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Setup/Setup.aspx") %>" class="btn btn-metal m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m--margin-right-10">
                                <span>
                                    <i class="la la-arrow-left"></i>
                                    <span>Back</span>
                                </span>
                            </a>
                            <asp:LinkButton ID="btnAddSubCategory" runat="server" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                                <span>
                                   <i class="fa fa-plus"></i>
                                    <span>Add Sub Category</span>
                                </span>
                            </asp:LinkButton>
                            <cc1:ModalPopupExtender CancelControlID="btnCloseHeader" BackgroundCssClass="modalBackground" ID="mpeSubCategory" runat="server" PopupControlID="pnlSubCategory" TargetControlID="btnAddSubCategory" />
                        </div>
                    </div>
                    <div class="m-portlet__body">

                        <!--begin: Datatable -->
                        <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">
                            <thead>
                                <tr>
                                    <th>Sub Catgeory Description </th>
                                    <th>Category </th>
                                    <th>Action </th>
                                </tr>
                            </thead>

                            <tbody>
                                <%=bindSubCategorygrid()%>
                            </tbody>
                        </table>
                    </div>
                </div>

                <!-- END EXAMPLE TABLE PORTLET-->
            </div>
        </div>


        <asp:Panel ID="pnlSubCategory" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
            <div class="" id="add_sub_location" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>

                                <%-- <div class="modal-header">
                                    <h5 class="modal-title" id="exampleModalLabel">Sub Category Master</h5>
                                    <asp:LinkButton ID="lnkbtnClose" OnClick="LinkButton_Click" runat="server"><i style="color:red" class="la la-close"></i></asp:LinkButton>
                                </div>--%>
                                <div class="modal-header">
                                    <h5 class="modal-title" id="exampleModalLabel">Sub Category Master</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <div class="form-group m-form__group row">
                                        <label for="recipient-name" class="col-xl-4 col-lg-3 form-control-label">Category :</label>
                                        <asp:DropDownList ID="ddlCategory" class="form-control m-input" Style="width: 60%;" runat="server"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvCat" runat="server" ControlToValidate="ddlCategory" Visible="true" Style="margin-left: 34%;"
                                            ValidationGroup="validationSubCategory" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Category"></asp:RequiredFieldValidator>
                                    </div>


                                    <div class="form-group m-form__group row">
                                        <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">SubCategory Description :</label>
                                        <asp:TextBox ID="txtSubCategoryDesc" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rvfSubCategory" runat="server" ControlToValidate="txtSubCategoryDesc" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationSubCategory" ForeColor="Red" ErrorMessage="Please enter Subcategory Description"></asp:RequiredFieldValidator>

                                    </div>

                                    <asp:Label ID="lblSubCategoryErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                </div>

                                <div class="modal-footer">
                                    <asp:Button ID="btnCloseSubCategory" Text="Close" runat="server" class="btn btn-danger" OnClick="btnCloseSubCategory_Click" />
                                    <asp:Button ID="btnSubCategorySave" runat="server" class="btn btn-primary" CausesValidation="true" ValidationGroup="validationSubCategory" OnClick="btnSubCategorySave_Click" Text="Save" />
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnSubCategorySave" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <!-- End Modal -->
        </asp:Panel>

    </div>




</asp:Content>
