<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Inventory_Stock_Detail.aspx.cs" Inherits="Upkeep_v3.Inventory.Inventory_Stock_Detail" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
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

        .auto-style1 {
            left: 0px;
            top: 15px;
        }
    </style>

    <script>

        $(document).ready(function () {
            $("#Button1").on('click', function (e) {
                e.preventDefault();

                $("#btnSave").click();

            });
        });


    </script>

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="">
            <div class="row">

                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <%--<form class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmWorkPermit" method="post">--%>
                        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

                        <asp:HiddenField ID="hdnWpHeaderData" runat="server" ClientIDMode="Static" />
                        <asp:HiddenField ID="hdnWpHeader" runat="server" ClientIDMode="Static" />
                        <p id="info" style="display: none;"></p>
                        <p id="infox" style="display: none;"></p>

                        <div class="m-portlet__head">
                            <div class="m-portlet__head-progress">
                            </div>
                            <div class="m-portlet__head-wrapper">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">Stock Details</h3>
                                    </div>
                                </div>

                                <div class="m-portlet__head-tools col-xl-4 order-1 order-xl-2 m--align-right" style="width: 28%;">
                                    <a href="<%= Page.ResolveClientUrl("~/Inventory/Inventory_Stock_List.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                        <span>
                                            <i class="la la-arrow-left"></i>
                                            <span>Back</span>
                                        </span>
                                    </a>
                                    <div class="btn-group">

                                        <asp:Button ID="Button1" TYPE="button" Text="Save" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md"
                                            ClientIDMode="Static" />

                                        <asp:Button ID="btnSave" TYPE="button" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" ClientIDMode="Static"
                                            CausesValidation="true" ValidationGroup="validateStock" Text="Save" OnClick="btnSave_Click" Style="display: none" />
                                        <%--
                                            
                                            <asp:Button ID="btnSaveAmc" TYPE="button" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" ClientIDMode="Static"
                                            CausesValidation="true" ValidationGroup="validateAssetAMC" Text="SaveAMC" Style="display: none" />--%>

                                        <asp:Button ID="btnTest" Style="display: none;" runat="server" />
                                        <cc1:ModalPopupExtender ID="mpeWpRequestSaveSuccess" runat="server" PopupControlID="pnlWpReqestSuccess" TargetControlID="btnTest"
                                            CancelControlID="btnCloseHeader2" BackgroundCssClass="modalBackground">
                                        </cc1:ModalPopupExtender>
                                    </div>
                                </div>

                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="m-portlet__body" style="padding: 0.4rem 2.2rem;">

                            <div class="m-portlet__body" style="padding: 0.3rem 2.2rem;">

                                <div class="m-portlet__body" style="padding: 0.3rem 2.2rem;">
                                    <br />
                                    <div id="Div1" runat="server" style="display: block;">
                                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Items :</label>
                                            <div class="col-xl-8 col-lg-8">
                                                <asp:DropDownList ID="ddlItems" class="form-control m-input" runat="server">
                                                </asp:DropDownList>
                                                <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlItems" Visible="true"
                                                    Display="Dynamic" ValidationGroup="validateStock" ForeColor="Red" InitialValue="0"
                                                    ErrorMessage="Please select Items"></asp:RequiredFieldValidator>--%>

                                                <asp:TextBox ID="txtItems" runat="server" class="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtItems" Visible="true"
                                                    Display="Dynamic" ValidationGroup="" ForeColor="Red" InitialValue=""
                                                    ErrorMessage="Please Enter Items"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <br />
                                    <div id="Div2" runat="server" style="display: block;">
                                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Opening Stock :</label>
                                            <div class="col-xl-3 col-lg-3">
                                                <%--<asp:TextBox ID="txtAssetName" runat="server" class="form-control"></asp:TextBox>--%>

                                                <input type="number" min="1" id="txtOpeningStockValue" class="form-control" runat="server" clientidmode="Static" />

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtOpeningStockValue" Visible="true"
                                                    Display="Dynamic" ValidationGroup="validateStock" ForeColor="Red" InitialValue=""
                                                    ErrorMessage="Please enter Opening Stock"></asp:RequiredFieldValidator>
                                            </div>

                                            <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Optimum Value :</label>
                                            <div class="col-xl-3 col-lg-3">
                                                <%--<asp:TextBox ID="txtAssetDescription" TextMode="MultiLine" runat="server" class="form-control"></asp:TextBox>--%>

                                                <input type="number" min="1" id="txtOptimumValue" class="form-control" runat="server" clientidmode="Static" />

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtOptimumValue" Visible="true"
                                                    Display="Dynamic" ValidationGroup="validateStock" ForeColor="Red" InitialValue=""
                                                    ErrorMessage="Please enter Optimum Value"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <br />
                                    <div id="Div3" runat="server" style="display: block;">
                                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Re-Order Value :</label>
                                            <div class="col-xl-3 col-lg-3">

                                                <input type="number" min="1" id="txtReorderValue" class="form-control" runat="server" clientidmode="Static" />

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtReorderValue" Visible="true"
                                                    Display="Dynamic" ValidationGroup="validateStock" ForeColor="Red" InitialValue=""
                                                    ErrorMessage="Please enter Re-Order Value"></asp:RequiredFieldValidator>
                                            </div>

                                            <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Base Value :</label>
                                            <div class="col-xl-3 col-lg-3">

                                                <input type="number" min="1" id="txtBaseValue" class="form-control" runat="server" clientidmode="Static" />

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBaseValue" Visible="true"
                                                    Display="Dynamic" ValidationGroup="validateStock" ForeColor="Red" InitialValue=""
                                                    ErrorMessage="Please enter Base Value"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>

                                    <br />
                                    <div id="Div4" runat="server" style="display: block;">
                                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Cost Rate :</label>
                                            <div class="col-xl-3 col-lg-3">

                                                <input type="number" min="1" id="txtCostRate" class="form-control" runat="server" clientidmode="Static" />

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCostRate" Visible="true"
                                                    Display="Dynamic" ValidationGroup="validateStock" ForeColor="Red" InitialValue=""
                                                    ErrorMessage="Please enter Cost Rate"></asp:RequiredFieldValidator>
                                            </div>

                                            <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Department :</label>
                                            <div class="col-xl-3 col-lg-3">
                                                <asp:DropDownList ID="ddlDepartment" class="form-control m-input" runat="server">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlDepartment" Visible="true"
                                                    Display="Dynamic" ValidationGroup="validateStock" ForeColor="Red" InitialValue="0"
                                                    ErrorMessage="Please select Items"></asp:RequiredFieldValidator>
                                            </div>

                                        </div>
                                    </div>


                                    <br />
                                    <div id="Div5" runat="server" style="display: block;">
                                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <label class="col-xl-2 col-lg-2 form-control-label">Current Stock :</label>
                                            <div class="col-xl-3 col-lg-3">

                                                <input type="number" min="0" id="txtCurrentStock" class="form-control" runat="server" clientidmode="Static" readonly />

                                            </div>


                                        </div>
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

