<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UpkeepMaster.Master" CodeBehind="Add_Cocktail_Recipes.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Setup.Add_Cocktail_Recipes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                                            ValidationGroup="ValidateUser" OnClick="btnSave_Click" />
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
                                            <div class="col-xl-4 col-lg-4" style="position: relative; background-color: white; border: solid #ebedf2 1px; max-width: 335px; height: 42px;">
                                                <asp:TextBox OnTextChanged="txtCocktail_TextChanged" AutoPostBack="true" ID="txtCocktail" runat="server" class="form-control" Style="width: 60%; position: absolute; top: 0px; left: 37px; width: 296px; padding: 0px; font-size: 13px; border: none; outline: none; font-family: sans-serif,Arial"></asp:TextBox>
                                                <asp:DropDownList OnSelectedIndexChanged="ddlCocktail_SelectedIndexChanged" AutoPostBack="true" ID="ddlCocktail" Style="position: absolute; top: 0px; left: 204px; font-size: 14px; border: none; width: 117px; margin: 0; outline: none;" class="form-control m-input" runat="server">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCocktail" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationWorkflow" ForeColor="Red" ErrorMessage="Please enter Cocktail Name"></asp:RequiredFieldValidator>
                                            </div>

                                            <label class="col-xl-2 col-lg-2 col-form-label" style="padding-left:140px">Rate :</label>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:TextBox ID="txtRate" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                            </div>
                                        </div>


                                        <div class="form-group m-form__group row">
                                            <label class="col-xl-1 col-lg-1 col-form-label"><span style="color: red;">*</span>  Brand :</label>
                                            <div class="col-xl-2 col-lg-2">
                                                <asp:DropDownList ID="ddlBrand" OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged" AutoPostBack="true" class="form-control m-input" runat="server"></asp:DropDownList>
                                            </div>
                                            <label class="col-xl-1 col-lg-1 col-form-label"><span style="color: red;">*</span>  Size :</label>
                                            <div class="col-xl-2 col-lg-2">
                                                <asp:DropDownList ID="ddlSize" OnSelectedIndexChanged="ddlSize_SelectedIndexChanged" class="form-control m-input" runat="server"></asp:DropDownList>
                                            </div>
                                            <label class="col-xl-1 col-lg-1 col-form-label"><span style="color: red;">*</span> Peg / ML:</label>
                                            <div class="col-xl-3 col-lg-3">
                                                <asp:TextBox ID="txtpegml" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpegml" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationWorkflow" ForeColor="Red" ErrorMessage="Please enter Rate"></asp:RequiredFieldValidator>
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
