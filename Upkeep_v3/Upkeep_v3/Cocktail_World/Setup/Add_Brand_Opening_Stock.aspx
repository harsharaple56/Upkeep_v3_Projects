<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UpkeepMaster.Master" CodeBehind="Add_Brand_Opening_Stock.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Setup.Add_Brand_Opening_Stock" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="DropDownListChosen" Namespace="DropDownListChosen" TagPrefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .chz {
            padding: 0.85rem 1.15rem;
            line-height: 1.25;
            color: #495057;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            border-radius: 0.25rem;
            font-weight: bold;
            height: calc(2.95rem + 2px);
        }

        .chosen-container-single .chosen-single {
            display: block;
            width: 100%;
            height: calc(2.95rem + 2px);
            padding: 0.85rem 1.15rem;
            font-size: 1rem;
            line-height: 1.25;
            color: #495057;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            border-radius: 0.25rem;
            -webkit-transition: border-color 0.15s ease-in-out, -webkit-box-shadow 0.15s ease-in-out;
            transition: border-color 0.15s ease-in-out, -webkit-box-shadow 0.15s ease-in-out;
            transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
            transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out, -webkit-box-shadow 0.15s ease-in-out;
            background-color: #fff;
            background: -webkit-gradient(linear, 50% 0%, 50% 100%, color-stop(20%, #ffffff), color-stop(50%, #ffffff), color-stop(52%, #ffffff), color-stop(100%, #ffffff));
            background: -webkit-linear-gradient(top, #ffffff 20%, #ffffff 50%, #ffffff 52%, #ffffff 100%);
            background: -moz-linear-gradient(top, #ffffff 20%, #ffffff 50%, #ffffff 52%, #ffffff 100%);
            background: -o-linear-gradient(top, #ffffff 20%, #ffffff 50%, #ffffff 52%, #ffffff 100%);
            background: linear-gradient(top, #ffffff 20%, #ffffff 50%, #ffffff 52%, #ffffff 100%);
            background-clip: padding-box;
            box-shadow: 0 0 3px white inset, 0 1px 1px rgba(0, 0, 0, 0.1);
            text-decoration: none;
            white-space: nowrap;
        }

            .chosen-container-single .chosen-single div b {
                display: block;
                width: 100%;
                height: 100%;
                background: url('WebResource.axd?d=HVPEiozS1UvTkLHiRNIdnfmoEReZmGiXCCXQCLvOYZjJW7-_1ztDrX3OiIn6ac6jmPYbaKN4uqJSJYiIVQ6hWfmOggJWCNQyz9Eo2bPAbyLAtPQb86opO9HqlyPGjTBPYxOCase5581CGVmtEx9T6Q2&t=636544785540000000') no-repeat 0px 10px;
            }

        .chosen-container-active.chosen-with-drop .chosen-single div b {
            background-position: -15px 5px;
        }
    </style>

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

            var selected = $("input[name=selected]").val();
            if (selected != undefined) {
                Swal.fire(
                    'Warning..!',
                    'Please select atleast one row.',
                    'info'
                )
            }

            var matched = $("input[name=matched]").val();
            if (matched != undefined) {
                Swal.fire(
                    'Warning..!',
                    'There are no changes to save.',
                    'info'
                )
            }

            var Redirect = $("input[name=Redirect]").val();
            if (Redirect != undefined) {
                //swal({
                //    title: "Success..!",
                //    text: "Your trasaction successfully saved!",
                //    type: "success"
                //}).then(function () {
                //    window.location = "Brand_Opening_Stock.aspx";
                //});
                Swal.fire(
                    'Success..!',
                    'Your trasaction successfully saved!',
                    'success'
                )
            }
        });
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

                                                    <label for="example-search-input" class="col-1 col-form-label">License :</label>
                                                    <div class="col-4">
                                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlLicense" AutoPostBack="true" class="form-control m-input" runat="server" OnSelectedIndexChanged="ddlLicense_SelectedIndexChanged"></asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlLicense" ValidationGroup="ValidateUser"
                                                                    ErrorMessage="Please select License" InitialValue="0" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>


                                                    <label for="example-search-input" class="col-1 col-form-label">Brands :</label>
                                                    <div class="col-4">
                                                        <cc2:DropDownListChosen AutoPostBack="true" CssClass="chz form-control m-input"
                                                            ID="DropDownListChosen1" runat="server" Font-Size="Medium" Font-Bold="True" CellPadding="5" CellSpacing="0" DataPlaceHolder="Click here to Search Brands" Width="450px" OnSelectedIndexChanged="DropDownListChosen1_SelectedIndexChanged">
                                                        </cc2:DropDownListChosen>

                                                        <asp:RequiredFieldValidator ID="rfvddlBrand" runat="server" ControlToValidate="DropDownListChosen1" ValidationGroup="ValidateUser"
                                                            ErrorMessage="Please select Brand" InitialValue="0" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </div>



                                                </div>
                                            </div>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlLicense" />
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

                                                                <AlternatingRowStyle BackColor="#E7F3FF"></AlternatingRowStyle>
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Select" ItemStyle-Width="5">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkSelct" runat="server" Checked='<%# Convert.ToBoolean(Eval("Selected"))%>' />
                                                                        </ItemTemplate>

                                                                        <ItemStyle Width="5px"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="CategorySizeLinkID" HeaderText="categorysizelinkid" SortExpression="CategorySizeLinkID"
                                                                        Visible="false" />
                                                                    <asp:BoundField DataField="Alias" HeaderText="Alias" SortExpression="Alias" />
                                                                    <asp:TemplateField HeaderText="Bottle Qty" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:HiddenField ID="hdnSize_ID" runat="server" Value='<%#(DataBinder.Eval(Container.DataItem,"Cat_Size_ID"))%>' />
                                                                            <asp:TextBox onkeypress="return (event.charCode !=8 && event.charCode ==0 || (event.charCode >= 48 && event.charCode <= 57))" ID="txtbottleqty" Width="100px" CssClass="numeric form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Bottle_Qty"))%>'></asp:TextBox>
                                                                        </ItemTemplate>

                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="SPeg Qty" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox onkeypress="return (event.charCode !=8 && event.charCode ==0 || (event.charCode >= 48 && event.charCode <= 57))" ID="txtspegqty" Width="100px" CssClass="numeric form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Speg_Qty"))%>'></asp:TextBox>
                                                                        </ItemTemplate>

                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Bottle Rate" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox onkeypress="return (event.charCode !=8 && event.charCode ==0 || (event.charCode >= 48 && event.charCode <= 57))" ID="txtbottlerate" Width="100px" CssClass="numeric form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Bottle_Rate"))%>'></asp:TextBox>
                                                                        </ItemTemplate>

                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Base Qty" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox onkeypress="return (event.charCode !=8 && event.charCode ==0 || (event.charCode >= 48 && event.charCode <= 57))" ID="txtbaseqty" Width="100px" CssClass="numeric form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Base_Qty"))%>'></asp:TextBox>
                                                                        </ItemTemplate>

                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Re-Order Level" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox onkeypress="return (event.charCode !=8 && event.charCode ==0 || (event.charCode >= 48 && event.charCode <= 57))" ID="txtreorderlevel" Width="100px" CssClass="numeric form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Re_Order_Level"))%>'></asp:TextBox>
                                                                        </ItemTemplate>

                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Optimum Level" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox onkeypress="return (event.charCode !=8 && event.charCode ==0 || (event.charCode >= 48 && event.charCode <= 57))" ID="txtoptimumlevel" Width="100px" CssClass="numeric form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Optimum_Level"))%>'></asp:TextBox>
                                                                        </ItemTemplate>

                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
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
                                                </table>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="DropDownListChosen1" />
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

</asp:Content>
