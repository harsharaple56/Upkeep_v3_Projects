<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UpkeepMaster.Master" CodeBehind="Add_Cocktail_Recipes.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Setup.Add_Cocktail_Recipes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": false,
                "progressBar": false,
                "positionClass": "toast-bottom-center",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "3000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            };

            var options = $('[id$="ddlCocktail"] option');
            var values = $.map(options, function (option) {
                return option.innerText;
            });
            
            $("[id*=txtCocktail]").on('keyup', function () {
                $.each(values, function (index, value) {
                    if ($("[id*=txtCocktail]").val().toLowerCase().trim() == value.toLowerCase().trim()) {
                        toastr.warning("Please check the Cocktail name that value is already in Cocktail Dropdown.");
                    }
                });
            });
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>


    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">
                        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>


                        <div class="m-portlet__head">
                            <div class="m-portlet__head-progress">
                            </div>
                            <div class="m-portlet__head-wrapper">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">Add Cocktail Recipes
                                        </h3>
                                    </div>
                                </div>

                                <div class="m-portlet__head-tools">


                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Setup/Cocktail_Recipes.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                        <span>
                                            <i class="la la-arrow-left"></i>
                                            <span>Back</span>
                                        </span>
                                    </a>
                                    <div class="btn-group">
                                        <asp:Button ID="btnSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="Save"
                                            ValidationGroup="ValidateSave" OnClick="btnSave_Click" />
                                    </div>
                                </div>

                            </div>
                        </div>



                        <!--begin: Form Body -->
                        <div class="m-form m-form--fit m-form--group-seperator-dashed">
                            <div class="row">
                                <div class="col-xl-12">
                                    <div class="m-form__section m-form__section--first">

                                        <div class="form-group m-form__group row">
                                            <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Cocktail Name :</label>
                                            <div class="col-xl-5 col-lg-5">
                                                <div class="input-group">
                                                    <asp:TextBox CssClass="form-control" OnTextChanged="txtCocktail_TextChanged" AutoPostBack="true" ID="txtCocktail" runat="server"></asp:TextBox>
                                                    <asp:DropDownList OnSelectedIndexChanged="ddlCocktail_SelectedIndexChanged" AutoPostBack="true" ID="ddlCocktail" class="form-control m-input" runat="server">
                                                    </asp:DropDownList>
                                                </div>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCocktail" Visible="true" Style="margin-left: 34%;" ValidationGroup="ValidateSave" ForeColor="Red" ErrorMessage="Please enter Cocktail Name"></asp:RequiredFieldValidator>
                                            </div>


                                            <label class="col-xl-2 col-lg-2 col-form-label">Rate :</label>
                                            <div class="col-xl-3 col-lg-3">
                                                <asp:TextBox ID="txtRate" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>


                                        <div class="form-group m-form__group row">
                                            <label class="col-xl-1 col-lg-1 col-form-label"><span style="color: red;">*</span>  Brand :</label>
                                            <div class="col-xl-3 col-lg-3">
                                                <asp:DropDownList ID="ddlBrand" OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged" AutoPostBack="true" class="form-control m-input" runat="server"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlBrand" Visible="true" ValidationGroup="ValidateUser" ForeColor="Red" ErrorMessage="Please enter Brand"></asp:RequiredFieldValidator>

                                            </div>
                                            <label class="col-xl-1 col-lg-1 col-form-label"><span style="color: red;">*</span>  Size :</label>
                                            <div class="col-xl-2 col-lg-2">
                                                <asp:DropDownList ID="ddlSize" OnSelectedIndexChanged="ddlSize_SelectedIndexChanged" class="form-control m-input" runat="server"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlSize" Visible="true" ValidationGroup="ValidateUser" ForeColor="Red" ErrorMessage="Please enter Size"></asp:RequiredFieldValidator>

                                            </div>
                                            <label class="col-xl-1 col-lg-1 col-form-label"><span style="color: red;">*</span> Peg / ML:</label>
                                            <div class="col-xl-2 col-lg-2">
                                                <asp:TextBox ID="txtpegml" runat="server" class="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpegml" Visible="true" ValidationGroup="ValidateUser" ForeColor="Red" ErrorMessage="Please enter Peg/ML"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="col-xl-3 col-lg-3" style="max-width: 16%;">
                                                <asp:Button ID="btnAddtoRow" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="Add Rows To Grid"
                                                    ValidationGroup="ValidateUser" OnClick="btnAddtoRow_Click" />
                                            </div>

                                        </div>


                                        <table class="table table-striped-table-bordered table-hover">
                                            <tr>
                                                <td colspan="2" class="ClsControlTd">
                                                    <asp:GridView ID="grdAddData" runat="server" Width="100%" AllowPaging="true"
                                                        PageSize="10" AllowSorting="true" AutoGenerateColumns="false" HeaderStyle-BackColor="#2E5E79"
                                                        HeaderStyle-ForeColor="white" CellPadding="5" AlternatingRowStyle-BackColor="#E7F3FF"
                                                        PagerStyle-HorizontalAlign="Center" PagerStyle-Mode="NumericPages" PagerSettings-Mode="Numeric"
                                                        PagerSettings-Position="Bottom" ClientIDMode="Static" CssClass="ct-grid" OnRowDeleting="OnRowDeleting"
                                                        OnRowDataBound="OnRowDataBound" OnPageIndexChanging="grdAddData_PageIndexChanging">
                                                        <AlternatingRowStyle BackColor="#E7F3FF"></AlternatingRowStyle>
                                                        <Columns>
                                                            <asp:CommandField ShowDeleteButton="True" DeleteText="Remove" ControlStyle-CssClass="btn btn-danger" ButtonType="Button" ItemStyle-Width="120" />
                                                            <asp:BoundField DataField="Name" HeaderText="Brand Name" ItemStyle-Width="120" />
                                                            <asp:BoundField DataField="Size" HeaderText="Size" ItemStyle-Width="120" />
                                                            <asp:BoundField DataField="Pegml" HeaderText="ML / Peg" ItemStyle-Width="120" />
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            No Records Found !!!
                                                        </EmptyDataTemplate>
                                                        <EmptyDataRowStyle Height="50%" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px"
                                                            HorizontalAlign="Center" />

                                                        <HeaderStyle BackColor="#2E5E79" ForeColor="White"></HeaderStyle>

                                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />

                                                        <PagerStyle HorizontalAlign="Center"></PagerStyle>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
