<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UpkeepMaster.Master" CodeBehind="Add_Brand_Opening_Stock.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Setup.Add_Brand_Opening_Stock" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            $("#txtCategory").on('input', function () {
                var val = this.value;

                $('#hdnCategory').val("");
                if ($('#dlCategory option').filter(function () {
                    if (this.value.toUpperCase() === val.toUpperCase()) {
                        $('#hdnCategory').val($(this).attr('text'));
                    }
                    return this.value.toUpperCase() === val.toUpperCase();
                }).length) {
                    $("#btnCategoryChange").click();
                }
            });

            $("#txtSubCategory").on('input', function () {
                var val = this.value;

                $('#hdnSubCategory').val("");
                if ($('#dlSubCategory option').filter(function () {
                    if (this.value.toUpperCase() === val.toUpperCase()) {
                        $('#hdnSubCategory').val($(this).attr('text'));
                    }
                    return this.value.toUpperCase() === val.toUpperCase();
                }).length) {
                    $("#btnSubCategoryChange").click();
                }
            });
        })
    </script>
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
                                        <h3 class="m-portlet__head-text">Add Brand Opening Stock
                                        </h3>
                                    </div>
                                </div>
                                <div class="m-portlet__head-tools">
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Setup/Brand_Opening_Stock.aspx") %>" class="btn btn-metal m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m--margin-right-10">
                                        <span>
                                            <i class="la la-arrow-left"></i>
                                            <span>Back</span>
                                        </span>
                                    </a>
                                    <asp:LinkButton ID="btnSave" runat="server" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air" ValidationGroup="ValidateUser" OnClick="btnSave_Click">
                                <span>
                                    <i class="fa fa-plus"></i>
                                    <span>Save</span>
                                </span>
                                    </asp:LinkButton>

                                </div>

                            </div>
                        </div>



                        <!--begin: Form Body -->
                        <div class="m-form m-form--fit m-form--group-seperator-dashed">
                            <div class="row">
                                <div class="col-xl-12">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div class="m-form__section m-form__section--first">

                                                <div class="form-group m-form__group row">

                                                    <div class="col-lg-4">
                                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                            <ContentTemplate>
                                                                <label><span style="color: red;">*</span>  License :</label>
                                                                <asp:DropDownList ID="ddlLicense" AutoPostBack="true" class="form-control m-input" runat="server" OnSelectedIndexChanged="ddlLicense_SelectedIndexChanged"></asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlLicense" ValidationGroup="ValidateUser"
                                                                    ErrorMessage="Please select License" InitialValue="0" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>


                                                    <div class="col-lg-4">
                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                            <ContentTemplate>
                                                                <label><span style="color: red;">*</span>  Category :</label>
                                                                <asp:DropDownList ID="ddlCategory" AutoPostBack="true" class="form-control m-input" runat="server" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvddlCategory" runat="server" ControlToValidate="ddlCategory" ValidationGroup="ValidateUser"
                                                                    ErrorMessage="Please select Category" InitialValue="0" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>


                                                    <div class="col-lg-4">
                                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                            <ContentTemplate>
                                                                <label><span style="color: red;">*</span>  Brand :</label>
                                                                <asp:DropDownList ID="ddlBrand" AutoPostBack="true" class="form-control m-input" OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="rfvddlBrand" runat="server" ControlToValidate="ddlBrand" ValidationGroup="ValidateUser"
                                                                    ErrorMessage="Please select Brand" InitialValue="0" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="ddlBrand" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </div>

                                                </div>
                                            </div>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlCategory" />
                                        </Triggers>
                                    </asp:UpdatePanel>


                                    <div class="col-xl-12">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                    <table class="table table-striped-table-bordered table-hover">
                                                        <tr>
                                                            <td colspan="2" class="ClsControlTd">
                                                                <asp:GridView ID="grdCatagLinkUp" runat="server" Width="100%" class="table table-striped- table-bordered table-hover table-checkable" AllowPaging="true"
                                                                    PageSize="10" AllowSorting="true" AutoGenerateColumns="false" CellPadding="5"
                                                                    PagerStyle-HorizontalAlign="Center" OnPageIndexChanging="grdCatagLinkUp_PageIndexChanging">

                                                                        <alternatingrowstyle backcolor="#E7F3FF"></alternatingrowstyle>
                                                                        <columns>
                                                                        <asp:TemplateField HeaderText="Select" ItemStyle-Width="5">
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="chkSelct" runat="server" Checked='<%# Convert.ToBoolean(Eval("Selected"))%>' />
                                                                            </ItemTemplate>

                                                                            <ItemStyle Width="5px"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="CategorySizeLinkID" HeaderText="categorysizelinkid" SortExpression="CategorySizeLinkID"
                                                                            Visible="false" />
                                                                        <asp:BoundField DataField="SizeDesc" HeaderText="Size" SortExpression="SizeDesc" />
                                                                        <asp:TemplateField HeaderText="Bottle Qty" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:HiddenField ID="hdnSize_ID" runat="server" Value='<%#(DataBinder.Eval(Container.DataItem,"Cat_Size_ID"))%>' />
                                                                                <asp:TextBox ID="txtbottleqty" Width="100px" CssClass="numeric form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Bottle_Qty"))%>'></asp:TextBox>
                                                                            </ItemTemplate>

                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="SPeg Qty" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtspegqty" Width="100px" CssClass="numeric form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Speg_Qty"))%>'></asp:TextBox>
                                                                            </ItemTemplate>

                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Bottle Rate" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtbottlerate" Width="100px" CssClass="numeric form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Bottle_Rate"))%>'></asp:TextBox>
                                                                            </ItemTemplate>

                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Base Qty" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtbaseqty" Width="100px" CssClass="numeric form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Base_Qty"))%>'></asp:TextBox>
                                                                            </ItemTemplate>

                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Re-Order Level" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtreorderlevel" Width="100px" CssClass="numeric form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Re_Order_Level"))%>'></asp:TextBox>
                                                                            </ItemTemplate>

                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Optimum Level" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtoptimumlevel" Width="100px" CssClass="numeric form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Optimum_Level"))%>'></asp:TextBox>
                                                                            </ItemTemplate>

                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                    </columns>
                                                                        <emptydatatemplate>
                                                                        No Records Found !!!
                                                                    </emptydatatemplate>
                                                                        <emptydatarowstyle height="50%" bordercolor="Black" borderstyle="Solid" borderwidth="2px"
                                                                            horizontalalign="Center" />

                                                                        <headerstyle backcolor="#2E5E79" forecolor="White"></headerstyle>

                                                                        <pagersettings firstpagetext="First" lastpagetext="Last" mode="NumericFirstLast" />

                                                                        <pagerstyle horizontalalign="Center"></pagerstyle>
                                                                    </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlBrand" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>


                </div>
            </div>

            <!--end::Portlet-->
        </div>
    </div>
    </div>

</asp:Content>
