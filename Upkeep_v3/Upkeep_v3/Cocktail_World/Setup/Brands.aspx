<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Brands.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Setup.Brands" %>

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
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>

    <script language="C#" runat="server">

        protected void LinkButton_Click(Object sender, EventArgs e)
        {
            Closecontrol();
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

        function RestrictSpaceSpecial(e) {
            var k;
            document.all ? k = e.keyCode : k = e.which;
            return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || k == 32 || (k >= 48 && k <= 57));
        }
    </script>

    <div runat="server">
        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <div class="m-content">
                <div class="m-portlet m-portlet--mobile">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Brand Master		
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
                            <asp:LinkButton ID="btnAddcategory" runat="server" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                                <span>
                                    <i class="fa fa-plus"></i>
                                    <span>Add Brand</span>
                                </span>
                            </asp:LinkButton>
                            <cc1:ModalPopupExtender BackgroundCssClass="modalBackground" ID="mpeCategoryMaster" runat="server" PopupControlID="pnlCategoryMaster" TargetControlID="btnAddCategory"/>

                        </div>
                    </div>
                    <div class="m-portlet__body">

                        <!--begin: Datatable -->
                        <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">


                            <thead>

                                <tr>
                                    <th>Brand Name</th>
                                    <th>Brand Short Name</th>
                                    <th>Assigned Category</th>
                                    <th>Assigned SubCategory</th>
                                    <th>Action</th>
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

        <asp:Panel ID="pnlCategoryMaster" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
            <div class="" id="add_sub_location" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-lg" role="document">
                    <div class="modal-content">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>

                                <div class="modal-header">
                                    <h5 class="modal-title" id="exampleModalLabel">Brand Master</h5>
                                      <asp:LinkButton ID="lnkbtnClose" OnClick="LinkButton_Click" runat="server"><i style="color:red" class="la la-close"></i></asp:LinkButton>
                                </div>
                                <div class="modal-body">

                                    <div class="row">
                                        <div class="col-6">

                                            <div class="form-group m-form__group row">
                                                <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Category :</label>
                                                <asp:DropDownList ID="ddlcategory" class="form-control" Style="width: 60%" AutoPostBack="true" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvDept" runat="server" ControlToValidate="ddlcategory" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationDept" ForeColor="Red" ErrorMessage="Please select Department"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="form-group m-form__group row">
                                                <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Sub Category:</label>
                                                <asp:DropDownList ID="ddlSubCategory" class="form-control" Style="width: 60%" runat="server"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlSubCategory" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationDept" ForeColor="Red" ErrorMessage="Please select Department"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="form-group m-form__group row">
                                                <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Brand Description :</label>
                                                <asp:TextBox ID="txtBrandDesc" runat="server" class="form-control" Style="width: 60%;" onkeypress="return RestrictSpaceSpecial(event)"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="txtBrandDesc" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationWorkflow" ForeColor="Red" ErrorMessage="Please enter Brand Description"></asp:RequiredFieldValidator>

                                            </div>

                                            <div class="form-group m-form__group row">
                                                <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Brand Short Description :</label>
                                                <asp:TextBox ID="txtBrandShortDesc" runat="server" class="form-control" Style="width: 60%;" onkeypress="return RestrictSpaceSpecial(event)"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvCategory1" runat="server" ControlToValidate="txtBrandShortDesc" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationWorkflow" ForeColor="Red" ErrorMessage="Please enter Brand Short Description"></asp:RequiredFieldValidator>

                                            </div>


                                        </div>
                                        <div class="col-6">
                                            <div class="form-group m-form__group row">
                                                <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Strength :</label>
                                                <asp:TextBox ID="txtShortname" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtShortname" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationWorkflow" ForeColor="Red" ErrorMessage="Please enter Strength"></asp:RequiredFieldValidator>

                                            </div>
                                            <div class="form-group m-form__group row">
                                                <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Brand Purchase Rate ( Peg - INR ) :</label>
                                                <asp:TextBox ID="txtPurchRatepeg" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPurchRatepeg" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationWorkflow" ForeColor="Red" ErrorMessage="Please enter Purchase Rate"></asp:RequiredFieldValidator>

                                            </div>

                                            <div class="form-group m-form__group row">
                                                <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Brand Selling Rate in Peg:</label>
                                                <asp:TextBox ID="txtSellingRatePeg" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSellingRatePeg" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationWorkflow" ForeColor="Red" ErrorMessage="Please enter Selling Rate in Peg"></asp:RequiredFieldValidator>

                                            </div>

                                            <div class="form-group m-form__group row">
                                                <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Brand Selling Rate in Bottle:</label>
                                                <asp:TextBox ID="txtSellingRateBotle" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSellingRateBotle" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationWorkflow" ForeColor="Red" ErrorMessage="Please enter Selling Rate in Bottle"></asp:RequiredFieldValidator>

                                            </div>

                                        </div>

                                        <div class="col-12">
                                            <div class="form-group m-form__group row">
                                                <div class="col-lg-12">
                                                    <asp:CheckBox ID="chkBrndDisable" CssClass="m-checkbox--success" runat="server" />
                                                    <label for="message-text" style="text-align: center;">Click for Disable this brand in Transaction</label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <asp:Label ID="lblCategoryErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>

                                </div>

                                <div class="modal-footer">
                                    <asp:Button ID="btnCloseCategory" Text="Close" runat="server" class="btn btn-danger" OnClick="btnCloseCategory_Click" />
                                    <asp:Button ID="btnCategorySave" runat="server" class="btn btn-primary" CausesValidation="true" ValidationGroup="validationWorkflow" OnClick="btnCategorySave_Click" Text="Save" />
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
