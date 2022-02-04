<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UpkeepMaster.Master" CodeBehind="Add_Cocktail_Recipes.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Setup.Add_Cocktail_Recipes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .btn_addrow {
            margin-top: 25px;
        }
    </style>
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

            var CocktailName = $("input[name=CocktailName]").val();
            var GridEmpty = $("input[name=GridEmpty]").val();

            if (CocktailName != undefined) {
                $('[id*=lst_ckname]').val(CocktailName);
            }

            if (GridEmpty != undefined) {
                toastr.warning("Please add atleast one row.");
            }

            var dataString = {
                'companycode': '',
            };
            var param = JSON.stringify(dataString);
            $.ajax({
                type: 'POST',
                url: 'Add_Cocktail_Recipes.aspx/FetchCocktailList',
                data: param,
                contentType: 'application/json; charset=utf-8',
                datatype: 'json',
                success: function (response) {
                    if (response.d) {
                        var mylist = document.getElementById("lst_cocktail");
                        for (var i = 0; i < Object.keys(response.d).length; i++) {
                            var optn = Object.values(response.d)[i];
                            var el = document.createElement("option");
                            el.textContent = optn;
                            el.value = optn;
                            mylist.appendChild(el);
                        }
                    }
                },
                error: function (xhr, status, error) {
                }
            });
        });


        function GetValue() {
            $('[id*=hdnCocktailName]').val($('[id*=lst_ckname]').val());
            return true;
        }
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
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Setup/Cocktail_Recipes.aspx") %>" class="btn btn-metal m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m--margin-right-10">
                                        <span>
                                            <i class="la la-arrow-left"></i>
                                            <span>Back</span>
                                        </span>
                                    </a>
                                    <asp:LinkButton ID="btnSave" ValidationGroup="ValidateSave" OnClientClick="return GetValue();" OnClick="btnSave_Click"
                                        runat="server" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                                         <span>
                                <i class="fa fa-plus"></i>
                                        <span>Save</span>
                                    </span>
                                    </asp:LinkButton>
                                </div>

                            </div>
                        </div>



                        <!--begin: Form Body -->
                        <div class="m-form m-form--fit m-form--label-align-right">
                            <div class="m-portlet__body">
                                <div class="col-xl-12">
                                    <div class="form-group m-form__group row">
                                        <div class="col-lg-7">
                                            <label><span style="color: red;">*</span> Cocktail Name :</label>
                                            <asp:HiddenField ID="hdnCocktailName" runat="server" />
                                            <input class="form-control" list="lst_cocktail" name="myBrowser" id="lst_ckname" runat="server" />
                                            <datalist id="lst_cocktail">
                                            </datalist>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="lst_ckname" Visible="true" ValidationGroup="ValidateSave" ForeColor="Red" ErrorMessage="Please Enter/Select cocktail name"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="col-lg-3">
                                            <label>Rate :</label>
                                            <asp:TextBox ID="txtRate" runat="server" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRate" Visible="true" ValidationGroup="ValidateSave" ForeColor="Red" ErrorMessage="Please enter rate"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="form-group m-form__group row">
                                        <div class="col-lg-4">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <label><span style="color: red;">*</span>  Brand :</label>
                                                    <asp:DropDownList ID="ddlBrand" OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged" AutoPostBack="true" class="form-control m-input" runat="server"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlBrand" Visible="true" ValidationGroup="ValidateUser" ForeColor="Red" ErrorMessage="Please enter Brand"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>


                                        <div class="col-lg-3">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <label><span style="color: red;">*</span>  Size :</label>
                                                    <asp:DropDownList ID="ddlSize" class="form-control m-input" runat="server"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlSize" Visible="true" ValidationGroup="ValidateUser" ForeColor="Red" ErrorMessage="Please enter Size"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlBrand" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>


                                        <div class="col-lg-3">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>
                                                    <label><span style="color: red;">*</span> Peg / ML:</label>
                                                    <asp:TextBox ID="txtpegml" runat="server" class="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpegml" Visible="true" ValidationGroup="ValidateUser" ForeColor="Red" ErrorMessage="Please enter Peg/ML"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>

                                        <div class="col-lg-2">
                                            <asp:LinkButton ID="btnAddtoRow" ValidationGroup="ValidateUser" OnClick="btnAddtoRow_Click" runat="server" class="btn_addrow btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m--margin-right-10">
                                                     <span>
                                                    <i class="la la-plus"></i>
                                                    <span>Add Row</span>
                                                </span>
                                            </asp:LinkButton>
                                        </div>
                                    </div>

                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <table class="table table-striped-table-bordered table-hover">
                                                <tr>
                                                    <td colspan="2" class="ClsControlTd">
                                                        <asp:GridView ID="grdAddData" runat="server" Width="100%" class="table table-striped- table-bordered table-hover table-checkable" AllowPaging="true"
                                                                    PageSize="10" AllowSorting="true" AutoGenerateColumns="false" CellPadding="5"
                                                                    PagerStyle-HorizontalAlign="Center" OnRowDeleting="OnRowDeleting"
                                                            OnRowDataBound="OnRowDataBound" OnPageIndexChanging="grdAddData_PageIndexChanging">
                                                            <AlternatingRowStyle BackColor="#E7F3FF"></AlternatingRowStyle>
                                                            <Columns>
                                                                 <asp:CommandField ItemStyle-HorizontalAlign="Left" ShowDeleteButton="True" HeaderText="Delete" DeleteText="" ControlStyle-CssClass="flaticon-delete-1" ButtonType="Link" ItemStyle-Width="10" />

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
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnAddtoRow" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>

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
