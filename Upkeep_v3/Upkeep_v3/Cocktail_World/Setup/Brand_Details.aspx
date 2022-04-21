<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UpkeepMaster.Master" CodeBehind="Brand_Details.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Setup.Brand_Details" %>


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

    <script type="text/javascript">
        $(document).ready(function () {
            $('#m_table_1').DataTable({
                responsive: true,
                pagingType: 'full_numbers',
                'fnDrawCallback': function () {
                    init_plugins();
                }
            });

            var Redirect = $("input[name=Redirect]").val();
            if (Redirect != undefined) {
                swal({
                    title: "Success..!",
                    text: "Brand Details successfully saved!",
                    type: "success"
                }).then(function () {
                    window.location = "Brands.aspx";
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
                                <h3 class="m-portlet__head-text">Add Brand Details
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
                            <asp:LinkButton ID="btnSave" ValidationGroup="validationDept" runat="server" OnClick="btnSave_Click" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                                <span>
                                    <i class="fa fa-plus"></i>
                                    <span>Save Brand Details</span>
                                </span>
                            </asp:LinkButton>

                        </div>

                    </div>

                    <div class="m-portlet__body">

                        <div class="form-group m-form__group row">

                            <label for="example-search-input" class="col-1 col-form-label">License</label>
                            <div class="col-3">
                                <asp:DropDownList ID="ddlLicense" class="form-control" Style="width: 100%" OnSelectedIndexChanged="ddlLicense_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                <asp:RequiredFieldValidator InitialValue="0" ID="rfvLicense" runat="server" ControlToValidate="ddlLicense" Visible="true" ValidationGroup="validationDept" ForeColor="Red" ErrorMessage="Please select License"></asp:RequiredFieldValidator>
                            </div>

                            <label for="example-search-input" class="col-1 col-form-label">Brand</label>
                            <div class="col-3">
                                <asp:TextBox ID="txtbrand" class="form-control" Style="width: 100%" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbrand" Visible="true" ValidationGroup="validationDept" ForeColor="Red" ErrorMessage="Please enter Brand name"></asp:RequiredFieldValidator>
                            </div>

                            <label for="example-search-input" class="col-1 col-form-label">Short Name</label>
                            <div class="col-3">
                                <asp:TextBox ID="txtShort" class="form-control" Style="width: 100%" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtShort" Visible="true" ValidationGroup="validationDept" ForeColor="Red" ErrorMessage="Please enter short name"></asp:RequiredFieldValidator>
                            </div>



                            <label for="example-search-input" class="col-1 col-form-label">Category</label>
                            <div class="col-3">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlCategory" class="form-control" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                        <asp:RequiredFieldValidator InitialValue="0" ID="rfvDept" runat="server" ControlToValidate="ddlCategory" Visible="true" ValidationGroup="validationDept" ForeColor="Red" ErrorMessage="Please select Department"></asp:RequiredFieldValidator>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlLicense" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>

                            <label for="example-search-input" class="col-1 col-form-label">SubCategory</label>
                            <div class="col-3">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlSubCategory" class="form-control" Style="width: 100%" AutoPostBack="true" runat="server"></asp:DropDownList>
                                        <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlCategory" Visible="true" ValidationGroup="validationDept" ForeColor="Red" ErrorMessage="Please select Department"></asp:RequiredFieldValidator>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlCategory" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>

                            <label for="example-search-input" class="col-1 col-form-label">Strength</label>
                            <div class="col-3">
                                <asp:TextBox ID="txtStrength" class="form-control" Style="width: 100%" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtStrength" Visible="true" ValidationGroup="validationDept" ForeColor="Red" ErrorMessage="Please enter Strength"></asp:RequiredFieldValidator>
                            </div>



                        </div>




                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>

                                <table width="100%" cellpadding="2" cellspacing="2">

                                    <tr>
                                        <td colspan="2" class="ClsControlTd">
                                            <asp:GridView ID="grdCatagLinkUp" runat="server" Width="100%" class="table table-striped- table-bordered table-hover table-checkable"
                                                AllowPaging="true"
                                                PageSize="10" AllowSorting="true" AutoGenerateColumns="false" CellPadding="5"
                                                PagerStyle-HorizontalAlign="Center">
                                                <AlternatingRowStyle BackColor="#E7F3FF"></AlternatingRowStyle>
                                                <Columns>


                                                    <asp:BoundField DataField="Size_ID" HeaderText="Size_ID" SortExpression="Size_ID"
                                                        />

                                                    <asp:BoundField DataField="SizeDesc" HeaderText="Size" SortExpression="SizeDesc" />
                                                    <asp:BoundField DataField="Alias" HeaderText="Alias" SortExpression="Alias" />

                                                    <asp:TemplateField HeaderText="Box Qty" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:TextBox onkeypress="return (event.charCode !=8 && event.charCode ==0 || (event.charCode >= 48 && event.charCode <= 57))" ID="txtbox" Width="100px" CssClass="form-control numeric" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"BoxQty"))%>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Purchase Rate" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:TextBox onkeypress="return (event.charCode !=8 && event.charCode ==0 || (event.charCode >= 48 && event.charCode <= 57))" ID="txtpegpur" Width="100px" CssClass="form-control numeric" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"PegPurRate"))%>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
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
                                    <tr>
                                        <td class="ClsControlTd" align="center" colspan="2">
                                            <asp:Label ID="lblwarn" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>

                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlCategory" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <asp:TextBox ID="txtDetails" runat="server" Width="500" Style="display: none;">
                        </asp:TextBox>

                    </div>
                </div>
            </div>
        </div>



    </div>


</asp:Content>

