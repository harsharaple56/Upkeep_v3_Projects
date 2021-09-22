<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Item_Categorization.aspx.cs" Inherits="Upkeep_v3.Laundry_Management.Stock_Setup.Item_Categorization" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

        .highlight {
            background-color: blanchedalmond;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {

            $("#tblCategory tr").click(function () {
                var table = document.getElementById("tblCategory");
                var rowID = $("#tblCategory tr").index(this);

                var row = table.rows[rowID];
                var CategoryID;
                CategoryID = row.cells[0].innerHTML;

                $("#hdnCategory").val(CategoryID);
                $("#hdnCategoryName").val(CategoryID);
                $("#lblCategoryName").text(CategoryID);
                document.getElementById("hdnTxtCategory").value = CategoryID;
                var selected = $(this).hasClass("highlight");
                $("#tblCategory tr").removeClass("highlight");
                if (!selected)
                    $(this).addClass("highlight");

                var dataString = { 'Category': CategoryID };
                var param = JSON.stringify(dataString);
                $.ajax({
                    type: 'POST',
                    url: 'Item_Categorization.aspx/SubCategory_bindgrid1',
                    data: param,
                    contentType: 'application/json; charset=utf-8',
                    datatype: 'json',
                    success: function (response) {
                        location.reload(true);
                    },
                    error: function (xhr, status, error) {
                    }
                });

            });

            $("#tblLocation tr").click(function () {

                var table = document.getElementById("tblLocation");
                var rowID = $("#tblLocation tr").index(this);
                var row = table.rows[rowID];
                var Location;

                Location = row.cells[0].innerHTML;
                $("#hdnLocation").val(Location);
                $("#lblLocation").text(Location);
                document.getElementById("hdnTxtSubCategory").value = Location;

                var selected = $(this).hasClass("highlight");
                $("#tblLocation tr").removeClass("highlight");
                if (!selected)
                    $(this).addClass("highlight");

            });

            $('.text-success').click(function () {
                var tbl = $(this).closest('table').attr('id');;
                var strs = $(this).attr('data-val');
                var n = strs.includes("=");

                if (n == true) {
                    var IDa = strs.split('=')[1];
                    $("#hdnEditTableClicked").val(tbl);
                    $("#hdnEditClickedID").val(IDa);


                    var dataString = { 'hdnEditTableClicked': tbl, 'hdnEditClickedID': IDa };
                    var param = JSON.stringify(dataString);
                    $.ajax({
                        type: 'POST',
                        url: 'Item_Categorization.aspx/SetSeesions',
                        data: param,
                        contentType: 'application/json; charset=utf-8',
                        datatype: 'json',
                        success: function (response) {
                        },
                        error: function (xhr, status, error) {
                        }
                    });
                }
            });

        });

        function HighlightCategoryTable() {
            $("#tblCategory tr").click(function () {

                var table = document.getElementById("tblCategory");
                var rowID = $("#tblCategory tr").index(this);

                var row = table.rows[rowID];
                CategoryID = row.cells[0].innerHTML;
                var selected = $(this).hasClass("highlight");

                $(this).addClass("highlight");

                $("#tblCategory tr").removeClass("highlight");
                if (!selected)
                    $(this).addClass("highlight");
            });
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div runat="server" id="FrmMain">
        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

        <asp:HiddenField ID="hdnEditTableClicked" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnEditClickedID" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnCategory" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnLocation" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnCategoryName" runat="server" ClientIDMode="Static" />
        <asp:TextBox ID="hdnTxtSubCategory" runat="server" Style="display: none;" ClientIDMode="Static"></asp:TextBox>
        <asp:TextBox ID="hdnTxtCategory" runat="server" Style="display: none;" ClientIDMode="Static"></asp:TextBox>

        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <div class="m-content">
                <div class="row">

                    <div class="col-md-2"></div>

                    <div class="col-md-4">
                        <div class="m-portlet">
                            <div class="m-portlet__head p-3">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <span class="m-portlet__head-icon">
                                            <i class="flaticon-placeholder-2"></i>
                                        </span>
                                        <h3 class="m-portlet__head-text">Category
                                        </h3>
                                    </div>
                                </div>
                                <div class="m-portlet__head-tools">
                                    <ul class="m-portlet__nav">
                                        <li class="m-portlet__nav-item">
                                            <asp:Button ID="btnAddCategory" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="+" />
                                            <cc1:ModalPopupExtender ID="mpeCategory" runat="server" PopupControlID="pnlAddCategory" TargetControlID="btnAddCategory"
                                                CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                                            </cc1:ModalPopupExtender>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div class="m-portlet__body py-1 px-2">
                                <table id="tblCategory" class="table m-table table-sm table-hover">
                                    <tbody>
                                        <%=Category_bindgrid()%>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="m-portlet">
                            <div class="m-portlet__head p-3">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <span class="m-portlet__head-icon">
                                            <i class="flaticon-placeholder-2"></i>
                                        </span>
                                        <h3 class="m-portlet__head-text">Sub Category
                                        </h3>
                                    </div>
                                </div>
                                <div class="m-portlet__head-tools">
                                    <ul class="m-portlet__nav">
                                        <li class="m-portlet__nav-item">
                                            <asp:Button ID="btnAddLocation" runat="server" class="btn btn-accent m-btn m-btn--icon m-btn--wide m-btn--md" Text="+" OnClick="btnAddLocation_Click" />
                                            <cc1:ModalPopupExtender ID="mpeSubCategory" runat="server" PopupControlID="pnlAddSubCategory" TargetControlID="btnAddLocation"
                                                CancelControlID="btnCloseLoc" BackgroundCssClass="modalBackground">
                                            </cc1:ModalPopupExtender>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div class="m-portlet__body py-1 px-2">
                                <table id="tblLocation" class="table m-table table-sm">
                                    <tbody>
                                        <%=SubCategory_bindgrid()%>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-2"></div>

                </div>
            </div>
        </div>

        <!-- Start Modal -->

        <asp:Panel ID="pnlAddCategory" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
            <div class="" id="add_Category" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-sm" role="document">
                    <div class="modal-content">
                        <asp:UpdatePanel ID="updatepnl" runat="server">
                            <ContentTemplate>
                                <div class="modal-header">
                                    <h5 class="modal-title" id="exampleModalLabel">Add New Category</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <div class="form-group">
                                        <label for="message-text" class="form-control-label">Category Description:</label>
                                        <asp:TextBox ID="txtCategoryDesc" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCategoryDesc" Visible="true" ValidationGroup="validationCategory" ForeColor="Red" ErrorMessage="Please enter Category Desc"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="form-group m-form__group row">
                                    <div class="col-xl-9 col-lg-9">
                                        <asp:Label ID="lblCategoryErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                    </div>
                                </div>

                                <div class="modal-footer">
                                    <asp:Button ID="btnClose" Text="Close" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnClose_Click" />
                                    <asp:Button ID="btnCategorySave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" CausesValidation="true" ValidationGroup="validationCategory" OnClick="btnCategorySave_Click" Text="Save" />
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnCategorySave" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="pnlAddSubCategory" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
            <div class="" id="add_SubCategory" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-sm" role="document">
                    <div class="modal-content">

                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>

                                <div class="modal-header">
                                    <h5 class="modal-title" id="exampleModalLabel1">Add new SubCategory</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <div class="form-group m-form__group row">
                                        <label for="recipient-name" class="col-xl-4 col-lg-3 form-control-label">Category :</label>
                                        <asp:Label ID="lblCategoryName" Text="" ClientIDMode="Static" runat="server" class="form-control-label" Style="font-weight: bold"></asp:Label>
                                    </div>
                                    <div class="form-group">
                                        <label for="message-text" class="form-control-label">SubCategory Description:</label>
                                        <asp:TextBox ID="txtSubCategory" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSubCategory" Visible="true" ValidationGroup="validationSubCategory" ForeColor="Red" ErrorMessage="Please enter SubCategory"></asp:RequiredFieldValidator>
                                    </div>

                                </div>
                                <div class="form-group m-form__group row">
                                    <div class="col-xl-9 col-lg-9">
                                        <asp:Label ID="lblSubCategoryErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                    </div>
                                </div>

                                <div class="modal-footer">
                                    <asp:Button ID="btnCloseLoc" Text="Close" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnCloseSubCategory_Click" />
                                    <asp:Button ID="btnSubCategorySave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" CausesValidation="true" ValidationGroup="validationSubCategory" OnClick="btnSubCategorySave_Click" Text="Save" />

                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnCategorySave" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>

        </asp:Panel>


        <!-- end:: Body -->

        <!-- begin::Scroll Top -->
        <div id="m_scroll_top" class="m-scroll-top">
            <i class="la la-arrow-up"></i>
        </div>

        <!-- end::Scroll Top -->

    </div>

</asp:Content>

