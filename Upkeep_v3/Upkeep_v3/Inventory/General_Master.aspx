<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="General_Master.aspx.cs" Inherits="Upkeep_v3.Inventory.General_Master" %>

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
            width: 500px;
        }

        .highlight {
            background-color: #b4cae6;
        }
    </style>
    <script type="text/javascript">

        $(document).ready(function () {
            var CategoryTableName = $("input[name=CategoryName]").val();
            if (CategoryTableName != undefined) {
                $('#tblCategory > tbody  > tr').each(function (index, tr) {
                    if ($(this).children('td').text().includes(CategoryTableName)) {
                        var selected = $(this).hasClass("highlight");
                        $("#tblCategory tr").removeClass("highlight");
                        if (!selected)
                            $(this).addClass("highlight");
                    }
                });
            }

            var SubCategoryTableName = $("input[name=SubCatName]").val();
            if (SubCategoryTableName != undefined) {
                $('#tblLocation > tbody  > tr').each(function (index, tr) {
                    if ($(this).children('td').text().includes(SubCategoryTableName)) {
                        var selected = $(this).hasClass("highlight");
                        $("#tblLocation tr").removeClass("highlight");
                        if (!selected)
                            $(this).addClass("highlight");
                    }
                });
            }



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

                var row = "";
                $.ajax({
                    type: 'POST',
                    url: 'General_Master.aspx/SubCategory_bindgrid1',
                    data: param,
                    contentType: 'application/json; charset=utf-8',
                    datatype: 'json',
                    success: function (msg) {
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

                var dataString = { 'SubCategory': Location };
                var param = JSON.stringify(dataString);

                $.ajax({
                    type: 'POST',
                    url: 'General_Master.aspx/Item_bindgrid1',
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

            $('.text-success').click(function () {

                var tbl = $(this).closest('table').attr('id');;
                var strs = $(this).attr('data-val');
                var n = strs.includes("=");

                if (n == true) {
                    var IDa = strs.split('=')[1];

                    $("#hdnEditTableClicked").val(tbl);
                    $("#hdnEditClickedID").val(IDa);


                    var obj = {};
                    var dataString = { 'hdnEditTableClicked': tbl, 'hdnEditClickedID': IDa };
                    var param = JSON.stringify(dataString);

                    $.ajax({
                        type: 'POST',
                        url: 'General_Master.aspx/SetSeesions',
                        data: param,
                        //data: '',
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


        function confirmSubCategoryAction() {
            var catename = $("#lblCategoryName").text();
            if (catename != "") {
                document.getElementById("<%= btnAddLocc.ClientID %>").click();
                return false;
            }
            else {
                document.getElementById("m_sweetalert_demo_3_1").click();
                $("#swal2-title").text('Please select Category ..!');
                $("#swal2-content").hide();
                return false;
            }
        }

        function confirmItemAction() {
            var catename = $("#lblCategoryName").text();
            var subcatename = $("#lblSubCategory").text();

            if (catename != "" && subcatename != "") {
                document.getElementById("<%= btnItems1.ClientID %>").click();
                return false;
            }
            else{
                document.getElementById("m_sweetalert_demo_3_1").click();
                $("#swal2-title").hide();
                $("#swal2-content").text('Please select Category & Sub-Category ..!');
                return false;
            }
        }



    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div runat="server" id="FrmMain">
        <cc1:ToolkitScriptManager runat="server">
        </cc1:ToolkitScriptManager>

        <%--<button type="button" runat="server" id="btnoo" onserverclick="btnoo_Click" class="btn btn-accent mr-auto" style="display: none" clientidmode="Static">Save</button>--%>


        <asp:HiddenField ID="hdnEditTableClicked" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnEditClickedID" runat="server" ClientIDMode="Static" />

        <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />

        <asp:HiddenField ID="hdnCategory" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnLocation" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnCategoryName" runat="server" ClientIDMode="Static" />
        <asp:TextBox ID="hdnTxtSubCategory" runat="server" Style="display: none;" ClientIDMode="Static"></asp:TextBox>
        <asp:TextBox ID="hdnTxtCategory" runat="server" Style="display: none;" ClientIDMode="Static"></asp:TextBox>
        <%-- <asp:ScriptManager ID="scriptmanager1" runat="server">
        </asp:ScriptManager>--%>

        <div class="m-grid__item m-grid__item--fluid m-wrapper">



            <div class="m-content">
                <div class="row">


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
                                            <asp:LinkButton class="btn m-btn m-btn--gradient-from-primary m-btn--gradient-to-info" runat="server" ID="btnAddCate1">
                                            <div class="m-demo-icon__preview">
														<i class="la la-plus"></i>
													</div>
                                            </asp:LinkButton>

                                            <cc1:ModalPopupExtender ID="mpeCategory" runat="server" PopupControlID="pnlAddCategory" TargetControlID="btnAddCate1"
                                                CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                                            </cc1:ModalPopupExtender>

                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div class="m-portlet__body">
                                <table id="tblCategory" class="table table-sm m-table m-table--head-bg-brand">
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
                                            <asp:LinkButton OnClientClick="return confirmSubCategoryAction()"
                                                class="btn m-btn m-btn--gradient-from-primary m-btn--gradient-to-info" runat="server" ID="btnAddLoc">
                                            <div class="m-demo-icon__preview">
														<i class="la la-plus"></i>
													</div>
                                            </asp:LinkButton>
                                            <button style="display: none" type="button" class="btn btn-warning m-btn m-btn--custom" id="m_sweetalert_demo_3_1"></button>
                                            <asp:Button ID="btnAddLocc" runat="server" Style="display: none" />
                                            <cc1:ModalPopupExtender ID="mpeSubCategory" runat="server" PopupControlID="pnlAddSubCategory" TargetControlID="btnAddLocc"
                                                CancelControlID="btnCloseLoc" BackgroundCssClass="modalBackground">
                                            </cc1:ModalPopupExtender>

                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div class="m-portlet__body">
                                <table id="tblLocation" class="table table-sm m-table m-table--head-bg-brand">
                                    <tbody>
                                        <%=SubCategory_bindgrid()%>
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
                                        <h3 class="m-portlet__head-text">Item
                                        </h3>
                                    </div>
                                </div>
                                <div class="m-portlet__head-tools">
                                    <ul class="m-portlet__nav">
                                        <li class="m-portlet__nav-item">
                                            <asp:LinkButton OnClientClick="javascript:return confirmItemAction();" class="btn m-btn m-btn--gradient-from-primary m-btn--gradient-to-info" runat="server" ID="btnItems">
                                            <div class="m-demo-icon__preview">
														<i class="la la-plus"></i>
													</div>
                                            </asp:LinkButton>
                                            <button style="display: none" type="button" class="btn btn-warning m-btn m-btn--custom" id="m_sweetalert_demo_3_1"></button>
                                            <asp:Button ID="btnItems1" runat="server" Style="display: none" />
                                            <cc1:ModalPopupExtender ID="mpeItem" runat="server" PopupControlID="pnlAddItem" TargetControlID="btnItems1"
                                                CancelControlID="btnCloseItem" BackgroundCssClass="modalBackground">
                                            </cc1:ModalPopupExtender>

                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div class="m-portlet__body">
                                <table id="tblLItems" class="table table-sm m-table m-table--head-bg-brand">

                                    <tbody>
                                        <%=Item_bindgrid()%>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--</div>--%>

        <!-- Start Modal -->

        <asp:Panel ID="pnlAddCategory" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
            <div class="" id="add_Category" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-sm" role="document">

                    <%-- <asp:ScriptManager ID="scriptmanager2" runat="server">
                </asp:ScriptManager>--%>


                    <div class="modal-content">

                        <asp:UpdatePanel ID="updatepnl" runat="server">
                            <ContentTemplate>

                                <div class="modal-header">
                                    <h5 class="modal-title" id="exampleModalLabel">Add New Category</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <%--<span aria-hidden="true">&times;</span>--%>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <%-- <form>--%>
                                    <%-- <div class="form-group" visible="false">
                                        <label for="recipient-name" class="form-control-label">Category code:</label>

                                        <asp:TextBox ID="txtCategoryCode" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvCategoryCode" runat="server" ControlToValidate="txtCategoryCode" Visible="true" ValidationGroup="validationCategory" ForeColor="Red" ErrorMessage="Please enter Category code"></asp:RequiredFieldValidator>
                                    </div>--%>
                                    <div class="form-group">
                                        <label for="message-text" class="form-control-label">Category Description:</label>
                                        <%--<textarea class="form-control" id="message-text"></textarea>--%>
                                        <asp:TextBox ID="txtCategoryDesc" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCategoryDesc" Visible="true" ValidationGroup="validationCategory" ForeColor="Red" ErrorMessage="Please enter Category Desc"></asp:RequiredFieldValidator>
                                    </div>



                                    <%--</form>--%>
                                </div>

                                <div class="form-group m-form__group row">
                                    <div class="col-xl-9 col-lg-9">
                                        <asp:Label ID="lblCategoryErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                    </div>
                                </div>

                                <div class="modal-footer">
                                    <%--<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>--%>
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
                                    <h5 class="modal-title" id="exampleModalLabel">Add new SubCategory</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <%--<span aria-hidden="true">&times;</span>--%>
                                    </button>
                                </div>
                                <div class="modal-body">

                                    <%-- <div class="form-group" visible="false">
                                        <label for="recipient-name" class="form-control-label">SubCategory code:</label>
                                        <asp:TextBox ID="txtSubCategoryCode" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSubCategoryCode" Visible="true" ValidationGroup="validationSubCategory" ForeColor="Red" ErrorMessage="Please enter SubCategory code"></asp:RequiredFieldValidator>

                                    </div>--%>
                                    <div class="form-group m-form__group row">
                                        <label for="recipient-name" class="col-xl-4 col-lg-3 form-control-label">Category :</label>
                                        <asp:Label ID="lblCategoryName1" Text="" ClientIDMode="Static" runat="server" class="form-control-label" Style="font-weight: bold"></asp:Label>
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
                                    <asp:Button ID="btnCloseLoc" Text="Close" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" />
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

        <asp:Panel ID="pnlAddItem" runat="server" CssClass="modalPopup" align="center" Style="display: none;">
            <div class="" id="add_sub_SubCategory" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document" style="max-width: 476px;">
                    <div class="modal-content">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>

                                <div class="modal-header">
                                    <h5 class="modal-title" id="exampleModalLabel">Add New Item</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <%--<span aria-hidden="true">&times;</span>--%>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <div class="form-group m-form__group row">
                                        <label for="recipient-name" class="col-xl-4 col-lg-3 form-control-label">Category :</label>
                                        <asp:Label ID="lblCategoryName" Text="" ClientIDMode="Static" runat="server" class="form-control-label" Style="font-weight: bold"></asp:Label>
                                    </div>
                                    <div class="form-group m-form__group row">
                                        <label for="recipient-name" class="col-xl-4 col-lg-3 form-control-label">SubCategory :</label>
                                        <asp:Label ID="lblSubCategory" Text="" ClientIDMode="Static" runat="server" class="form-control-label" Style="font-weight: bold"></asp:Label>
                                    </div>

                                    <%--  <div class="form-group m-form__group row" visible="false">
                                        <label for="recipient-name" class="col-xl-4 col-lg-3 form-control-label">Sub-location code:</label>
                                        <asp:TextBox ID="txtItemCode" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtItemCode" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationItem" ForeColor="Red" ErrorMessage="Please enter Sub Location code"></asp:RequiredFieldValidator>
                                    </div>--%>

                                    <div class="form-group m-form__group row">
                                        <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Description:</label>
                                        <%--<textarea class="form-control" id="message-text"></textarea>--%>
                                        <asp:TextBox ID="txtItem" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtItem" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationItem" ForeColor="Red" ErrorMessage="Please enter Sub Location"></asp:RequiredFieldValidator>

                                    </div>
                                    <div class="form-group m-form__group row">
                                        <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Department:</label>
                                        <%--<textarea class="form-control" id="message-text"></textarea>--%>
                                        <asp:DropDownList ID="ddlDepartment" class="form-control" Style="width: 60%;" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlDepartment" Visible="true"
                                            Display="Dynamic" ValidationGroup="validateStock" ForeColor="Red" InitialValue="0"
                                            ErrorMessage="Please select Department"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group m-form__group row">
                                        <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Opening:</label>
                                        <%--<textarea class="form-control" id="message-text"></textarea>--%>
                                        <asp:TextBox ID="txtOpening" value="0" runat="server" class="form-control" Style="width: 60%;" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtOpening"
                                            Visible="true" Style="margin-left: 34%;" ValidationGroup="validationItem" ForeColor="Red"
                                            ErrorMessage="Please enter Opening stock"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group m-form__group row">
                                        <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Optimun:</label>
                                        <%--<textarea class="form-control" id="message-text"></textarea>--%>
                                        <asp:TextBox ID="txtOptimun" value="0" runat="server" class="form-control" Style="width: 60%;" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtOptimun"
                                            Visible="true" Style="margin-left: 34%;" ValidationGroup="validationItem" ForeColor="Red"
                                            ErrorMessage="Please enter Optimun stock"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group m-form__group row">
                                        <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Re Order:</label>
                                        <%--<textarea class="form-control" id="message-text"></textarea>--%>
                                        <asp:TextBox ID="txtReOrder" runat="server" value="0" class="form-control" Style="width: 60%;" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtReOrder"
                                            Visible="true" Style="margin-left: 34%;" ValidationGroup="validationItem" ForeColor="Red"
                                            ErrorMessage="Please enter Re Order"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group m-form__group row">
                                        <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Base:</label>
                                        <%--<textarea class="form-control" id="message-text"></textarea>--%>
                                        <asp:TextBox ID="txtBase" runat="server" value="0" class="form-control" Style="width: 60%;" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtBase"
                                            Visible="true" Style="margin-left: 34%;" ValidationGroup="validationItem" ForeColor="Red"
                                            ErrorMessage="Please enter Base"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group m-form__group row">
                                        <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Cost Rate:</label>
                                        <%--<textarea class="form-control" id="message-text"></textarea>--%>
                                        <asp:TextBox ID="txtCostRate" runat="server" value="0" class="form-control" Style="width: 60%;" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtCostRate"
                                            Visible="true" Style="margin-left: 34%;" ValidationGroup="validationItem" ForeColor="Red"
                                            ErrorMessage="Please enter Cost Rate"></asp:RequiredFieldValidator>
                                    </div>

                                    <asp:Label ID="lblItemErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                </div>
                                <%--<div class="form-group m-form__group row">
                                        <div class="col-xl-9 col-lg-9">
                                            <asp:Label ID="Label1" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>--%>

                                <div class="modal-footer">
                                    <asp:Button ID="btnCloseItem" Text="Close" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnCloseItem_Click" />
                                    <asp:Button ID="btnItemSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" CausesValidation="true" ValidationGroup="validationItem" OnClick="btnItemSave_Click" Text="Save" />

                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnItemSave" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <!-- End Modal -->
        </asp:Panel>
        <!-- end:: Body -->

        <!-- begin::Scroll Top -->
        <div id="m_scroll_top" class="m-scroll-top">
            <i class="la la-arrow-up"></i>
        </div>

        <!-- end::Scroll Top -->

    </div>

</asp:Content>
