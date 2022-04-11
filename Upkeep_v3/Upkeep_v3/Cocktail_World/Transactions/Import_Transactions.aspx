<%@ Page Language="C#" MasterPageFile="~/Cocktail_World_Master.Master" AutoEventWireup="true" CodeBehind="Import_Transactions.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Transactions.Import_Transactions" %>

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

        .btnchange {
            margin-top: 30px;
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
                                <h3 class="m-portlet__head-text">Import Master		
                                </h3>
                            </div>
                        </div>
                        <div class="m-portlet__head-tools">
                            <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Transactions/Select_Transaction.aspx") %>" class="btn btn-metal m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m--margin-right-10">
                                <span>
                                    <i class="la la-arrow-left"></i>
                                    <span>Back</span>
                                </span>
                            </a>
                        </div>
                    </div>

                    <div class="m-portlet__body">


                        <div class="m-form m-form--fit m--margin-bottom-20">
                            <div class="row m--align-center">

                                <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">

                                    <label class="font-weight-bold">Select License :</label>
                                    <asp:DropDownList ID="ddlLicense" AutoPostBack="false" class="form-control m-input" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlLicense" ValidationGroup="validationDept"
                                        ErrorMessage="Please select License" InitialValue="0" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>

                                <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                                    <label class="font-weight-bold">Select Master :</label>
                                    <asp:DropDownList ID="ddlMaster" AutoPostBack="true" class="form-control m-input" runat="server">
                                        <asp:ListItem Text="--Select Master--" Value="0" />
                                        <asp:ListItem Text="Sale (Brand)" Value="1" />
                                        <asp:ListItem Text="Sale (Cocktail)" Value="2" />
                                        <asp:ListItem Text="Auto-Billing (Brand)" Value="3" />
                                        <asp:ListItem Text="Auto-Billing (Cocktail)" Value="4" />
                                        <asp:ListItem Text="Purchase" Value="5" />
                                        <asp:ListItem Text="Transfer" Value="6" />
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlMaster" ValidationGroup="validationDept"
                                        ErrorMessage="Please select Master" InitialValue="0" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>


                                <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                                    <label class="font-weight-bold">Select Format :</label>
                                    <asp:DropDownList ID="ddlFormat" AutoPostBack="true" class="form-control m-input" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlFormat" ValidationGroup="validationDept"
                                        ErrorMessage="Please select License" InitialValue="0" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>

                                <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                                    <asp:LinkButton ID="btnImportExcelPopup" ValidationGroup="validationDept" runat="server" class="btnchange btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                                <span>
                                    <i class="fa fa-file-import"></i>
                                    <span>Import File</span>
                                </span>
                                    </asp:LinkButton>

                                </div>


                            </div>


                        </div>
                    </div>
                </div>

                <!-- END EXAMPLE TABLE PORTLET-->
            </div>
        </div>

    </div>


</asp:Content>

