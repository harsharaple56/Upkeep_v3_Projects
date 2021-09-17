<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Brand_Categories.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Setup.Brand_Categories" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>

    <%--<script type="text/javascript" src="https://code.jquery.com/jquery-2.1.4.min.js"></script>
    <script src="http://code.jquery.com/ui/1.11.2/jquery-ui.js"></script>--%>

    <%-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>

    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>--%>

    <style type="text/css">
        .modalBackground {
            background-color: grey;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            /*background-color: #fff;
            border: 3px solid #ccc;*/
            padding: 10px;
            width: 300px;
        }
    </style>

    <script type="text/javascript">

        function CheckForm() {
            if ($('#<%=txtCategoryDesc.ClientID %>').val() == "") {
                alert('Please Enter Category Desc');
                return false;
            }
            return true;
        }

        function openModal() {
            //alert('hgfhfghfg');
            $('#Add_Category').modal('show');
        }

    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            //$('#btnedit').click(function () {
            $("#btnedit").click(function () {
                //alert('edit');
                $('#Add_Category').modal('show');

            });

            <%--$("#btnSave").click(function () {
                debugger;
                var grid = document.getElementById("<%= grdCatagLinkUp.ClientID%>");

                for (var i = 0; i < grid.rows.length - 1; i++) {

                    //var chkSelct = $('input[type="checkbox"][id*=chkSelct]').checked;
                    //alert(chkSelct);
                    var checkBoxes = grid.getElementsByTagName("INPUT");
                    //if(chkSelct)
                    //Loop through the CheckBoxes.
                    for (var i = 0; i < checkBoxes.length; i++) {
                        if (checkBoxes[i].checked) {
                            var txtalias = $("input[id*=txtalias]")
                            if (txtalias[i].value != '') {
                                alert(txtalias[i].value);
                            }
                        }
                    }
                }
            });--%>

        });

        function openModal() {
            //alert('Hii');
            $('#Add_Category').modal('show');
        }




    </script>

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


    <script type="text/javascript">

        function Confirm(CategoryChangeMsg) {

            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm(CategoryChangeMsg)) {
                confirm_value.value = "Yes";
                document.forms[0].appendChild(confirm_value);
                document.getElementById('<%= btnSave.ClientID %>').click();
            }
            else {
                confirm_value.value = "No";
                document.forms[0].appendChild(confirm_value);
                document.getElementById('<%= btnSave.ClientID %>').click();
            }
        }




    </script>

    <div runat="server">
        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
        <div class="m-grid__item m-grid__item--fluid">
            <div class="m-content">
                <div class="m-portlet m-portlet--mobile">

                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Assign Available Brand Sizes for each Category	
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

                            <ul class="m-portlet__nav">
                                <li class="m-portlet__nav-item">

                                    <button type="button" runat="server" id="btnSave" onserverclick="btnSave_Click" class="btn btn-success m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                                        <span>
                                            <i class="flaticon-add"></i>
                                            <span>Save Category Sizes</span>
                                        </span>
                                    </button>



                                </li>
                            </ul>

                        </div>

                    </div>

                    <div class="m-portlet__body">

                        <form class="m-form m-form--fit m--margin-bottom-20">



                            <div class="m--form-group row m--align-center">
                                <div class="col-lg-2 m--margin-bottom-10-tablet-and-mobile">
                                    <label class="font-weight-bold">Select Category</label>
                                </div>

                                <div class="col-lg-5 m--margin-bottom-10-tablet-and-mobile">

                                    <div class="m-form__control">
                                        <asp:HiddenField ID="hdn_IsPostBack" ClientIDMode="Static" runat="server" />
                                        <asp:DropDownList ID="ddlCategory" class="form-control" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvDept" runat="server" ControlToValidate="ddlCategory" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationDept" ForeColor="Red" ErrorMessage="Please select Department"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="col-lg-2 m--margin-bottom-10-tablet-and-mobile">
                                       <asp:LinkButton ToolTip="Edit Category" style="width: 55px;height: 35px;" class='btn btn-accent m-btn m-btn--icon btn-sm m-btn--icon-only' ID="btn_edit" runat="server"  OnClick="btn_Edit_Click" ><i id='I1' runat='server' class='la la-edit'></i></asp:LinkButton>
                                       <asp:LinkButton ToolTip="Delete Category" style="width: 55px;height: 35px;" class='btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only has-confirmation' ID="btn_delete" runat="server"  OnClick="btn_Delete_Click" ><i id='I2' runat='server' class='la la-trash'></i></asp:LinkButton>
                                </div>

                                <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                                    <div class="m-form__control">
                                        <button type="button" id="btnAddcategory" runat="server" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                                            <span>
                                                <i class="fa fa-plus"></i>
                                                <span>Add New Category</span>
                                            </span>
                                        </button>

                                        <cc1:ModalPopupExtender ID="mpeCategoryMaster" runat="server" PopupControlID="pnlCategoryMaster" TargetControlID="btnAddCategory"
                                            CancelControlID="btnCloseHeader" BackgroundCssClass="modalBackground">
                                        </cc1:ModalPopupExtender>
                                    </div>

                                </div>
                            </div>
                        </form>


                        <table width="100%" cellpadding="2" cellspacing="2">

                            <tr>
                                <td colspan="2" class="ClsControlTd">
                                    <asp:GridView ID="grdCatagLinkUp" runat="server" Width="100%" class="table table-striped- table-bordered table-hover table-checkable" AllowPaging="true" OnRowDataBound="grdCatagLinkUp_RowDataBound"
                                        PageSize="10" AllowSorting="true" AutoGenerateColumns="false" CellPadding="5"
                                        PagerStyle-HorizontalAlign="Center" PagerStyle-Mode="NumericPages" PagerSettings-Mode="Numeric"
                                        PagerSettings-Position="Bottom" ClientIDMode="Static" OnPageIndexChanging="grdCatagLinkUp_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Select" ItemStyle-Width="5">
                                                <ItemTemplate>
                                                     <asp:CheckBox ID="chkSelct" runat="server" Checked='<%# Convert.ToBoolean(Eval("Selected"))%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CategorySizeLinkID" HeaderText="categorysizelinkid" SortExpression="CategorySizeLinkID"
                                                Visible="false" />
                                            <asp:BoundField DataField="SizeDesc" HeaderText="Size" SortExpression="SizeDesc" />
                                            <asp:TemplateField HeaderText="Alias" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnSize_ID" runat="server" Value='<%#(DataBinder.Eval(Container.DataItem,"Size_ID"))%>' />
                                                    <asp:TextBox class="form-control m-input" ID="txtalias" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Alias"))%>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Stock IN" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>

                                                    <asp:HiddenField ID="hdnStockIn" runat="server" Value='<%#(DataBinder.Eval(Container.DataItem,"Stock_In"))%>' />
                                                    <asp:DropDownList class="form-control m-input" ID="ddlStockIn" runat="server">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Bottle" Value="B"></asp:ListItem>
                                                        <asp:ListItem Text="Peg" Value="P"></asp:ListItem>
                                                        <asp:ListItem Text="ML" Value="M"></asp:ListItem>
                                                    </asp:DropDownList>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="No Of Speg" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:TextBox onkeypress="return (event.charCode !=8 && event.charCode ==0 || (event.charCode >= 48 && event.charCode <= 57))" ID="txtnoofspeg" Width="80px" CssClass="form-control numeric" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"NoOfSpeg"))%>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Peg Size(ML)" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:TextBox onkeypress="return (event.charCode !=8 && event.charCode ==0 || (event.charCode >= 48 && event.charCode <= 57))" ID="txtpegsize" Width="80px" CssClass="form-control numeric" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"PegSize"))%>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            No Records Found !!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle Height="50%" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px"
                                            HorizontalAlign="Center" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td class="ClsControlTd" align="center" colspan="2">
                                    <asp:Label ID="lblwarn" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:TextBox ID="txtDetails" runat="server" Width="500" Style="display: none;">
                        </asp:TextBox>

                    </div>
                </div>
            </div>
        </div>


        <asp:Panel ID="pnlCategoryMaster" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
            <div class="" id="add_sub_location" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document" style="max-width: 590px;">
                    <div class="modal-content">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>

                                <div class="modal-header">
                                    <h5 class="modal-title" id="exampleModalLabel">Category Master</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader" runat="server" onserverclick="btnCloseCategory_Click">
                                        <span aria-hidden="true">&times;</span>
                                        <%-- <asp:Button ID="btnCloseHeader" runat="server" class="Close"/>--%>
                                    </button>
                                </div>
                                <div class="modal-body">


                                    <div class="form-group m-form__group row">
                                        <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Category Description :</label>
                                        <asp:TextBox ID="txtCategoryDesc" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="txtCategoryDesc" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationWorkflow" ForeColor="Red" ErrorMessage="Please enter Category Description"></asp:RequiredFieldValidator>

                                    </div>
                                    <asp:Label ID="lblCategoryErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                </div>
                                <%--<div class="form-group m-form__group row">
                                        <div class="col-xl-9 col-lg-9">
                                            <asp:Label ID="Label1" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>--%>

                                <div class="modal-footer">
                                    <asp:Button ID="btnCloseCategory" Text="Close" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnCloseCategory_Click"  />
                                    <asp:Button ID="btnCategorySave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" CausesValidation="true" ValidationGroup="validationWorkflow" OnClick="btnCategorySave_Click" Text="Save" />

                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnCategorySave" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <!-- End Modal -->
        </asp:Panel>

    </div>


</asp:Content>
