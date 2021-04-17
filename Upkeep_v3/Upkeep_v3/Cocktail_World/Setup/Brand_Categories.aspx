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


    <script type="text/javascript" language="javascript">



<%--        function FunSizeDetails(idn) {
            if (idn.tagName == "INPUT") {
                idn.value = idn.parentNode.title;
                if (idn.checked == true) {
                    if (document.getElementById('<%=Me.txtDetails.ClientId%>').value.indexOf("=$=" + idn.value + "=$=") < 0) {
                        if (document.getElementById('<%=Me.txtDetails.ClientId%>').value == "") //if it is 1st item in a hidden field
                        {
                            document.getElementById('<%=Me.txtDetails.ClientId%>').value = "=$=" + idn.value + "=$=";
                        }
                        else//if it is not 1st item in a hidden field
                        {

                            document.getElementById('<%=Me.txtDetails.ClientId%>').value += idn.value + "=$=";

                            idn.checked = true;
                        }
                    }
                }
                else //if check box is unchecked then remove Designation idn from hidden field
                {
                    if (document.getElementById('<%=Me.txtDetails.ClientId%>').value.indexOf("=$=" + idn.value + "=$=") >= 0) {
                        document.getElementById('<%=Me.txtDetails.ClientId%>').value = document.getElementById('<%=Me.txtDetails.ClientId%>').value.replace("=$=" + idn.value + "=$=", "=$=");

                    }

                }
            }
        }--%>


<%--        function onlyAlphabets(e, t) {
            try {
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }
                if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123))
                    return true;
                else
                    $("#<%=lblmsg.ClientID %>").text("Please Enter Only Alphabet.");
                $("#<%=divmsg.ClientID %>").css("display", "inline");
                return false;
            }
            catch (err) {
                alert(err.Description);
            }--%>
        }
        //-----Added by Ravindra 27-Dec-2017 to fetch Category Change msg

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
        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <div class="">
                <div class="m-portlet m-portlet--mobile">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Category Master		
                                </h3>
                            </div>
                        </div>
                        <div class="m-portlet__head-tools">
                            <ul class="m-portlet__nav">
                                <li class="m-portlet__nav-item">

                                    <asp:Button ID="btnAddcategory" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnAddcategory_Click" Text="+ New Category" />

                                    <cc1:ModalPopupExtender ID="mpeCategoryMaster" runat="server" PopupControlID="pnlCategoryMaster" TargetControlID="btnAddCategory"
                                        CancelControlID="btnCloseHeader" BackgroundCssClass="modalBackground">
                                    </cc1:ModalPopupExtender>

                                </li>
                            </ul>

                            <%--  <asp:Button ID="Add_Category1" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md"  OnClick="btnAddCategory_Click" Text="+ New Category" />
                            --%>
                        </div>

                    </div>

                    <div class="m-portlet__body">

                        <div class="m-form m-form--label-align-right m--margin-bottom-30">
                            <div class="align-items-center">
                                <div class="col-xl-12 order-2 order-xl-1 row">
                                    <%-- <div class="form-group m-form__group row align-items-center">--%>

                                    <div class="col-md-3">
                                        <div class="m-input-icon m-input-icon--left">
                                            <div class="form-group m-form__group">
                                                <label for="message-text" class="form-control-label">Category :</label>
                                            </div>

                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                        <div class="m-form__group m-form__group--inline">

                                            <div class="m-form__control">
                                                <asp:HiddenField ID="hdn_IsPostBack" ClientIDMode="Static" runat="server" />
                                                <div class="btn-group" style="width: 500px;">

                                                    <asp:DropDownList ID="ddlCategory" class="form-control" Style="width: 100%" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvDept" runat="server" ControlToValidate="ddlCategory" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationDept" ForeColor="Red" ErrorMessage="Please select Department"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                            <div class="m-form__control">

                                                <asp:HiddenField ID="HiddenField1" ClientIDMode="Static" runat="server" />

                                                <div class="btn-group" style="width: 500px;">

                                                    <asp:DropDownList ID="ddllicense" class="form-control" Style="width: 100%" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" runat="server"></asp:DropDownList>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCategory" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationDept" ForeColor="Red" ErrorMessage="Please select Department"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--</div>--%>
                                </div>

                            </div>
                        </div>

                        <table width="100%" cellpadding="2" cellspacing="2">
                            <%--  <tr>
                        <td class="ClsLabelTd">
                            Category
                        </td>
                        <td class="ClsControlTd">
                            <asp:DropDownList ID="DDLCatag" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>--%>
                            <%--   <tr id="tr_extra" runat="server">
                        <td class="ClsLabelTd">
                            License
                        </td>
                        <td class="ClsControlTd">
                            <asp:DataList ID="DataList1" runat="server" DataKeyField="LicenseId" RepeatDirection="Horizontal"
                                RepeatColumns="5">
                                <ItemTemplate>
                                    <asp:CheckBox ID="LicenseId" runat="server" Text='<%# Eval("LicenseName") %>' />
                                    <asp:Label ID="DescriptionLabel" Visible="false" runat="server" CssClass="big" Text='<%# Eval("LicenseId") %>' />
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                    </tr>--%>
                            <tr>
                                <td colspan="2" class="ClsControlTd">
                                    <asp:GridView ID="grdCatagLinkUp" runat="server" Width="100%" AllowPaging="true" OnRowDataBound="grdCatagLinkUp_RowDataBound"
                                        PageSize="10" AllowSorting="true" AutoGenerateColumns="false" HeaderStyle-BackColor="#2E5E79"
                                        HeaderStyle-ForeColor="white" CellPadding="5" AlternatingRowStyle-BackColor="#E7F3FF"
                                        PagerStyle-HorizontalAlign="Center" PagerStyle-Mode="NumericPages" PagerSettings-Mode="Numeric"
                                        PagerSettings-Position="Bottom" ClientIDMode="Static">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Select" ItemStyle-Width="5">
                                                <ItemTemplate>

                                                    <asp:CheckBox ID="chkSelct" runat="server" Checked='<%# Convert.ToBoolean(Eval("Selected"))%>' />

                                                    <%-- <asp:CheckBox ID="chkSelct" runat="server" Checked='<%#(DataBinder.Eval(Container.DataItem,"Selected"))%>' />--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="CategorySizeLinkID" HeaderText="categorysizelinkid" SortExpression="CategorySizeLinkID"
                                                Visible="false" />
                                            <asp:BoundField DataField="Size_ID" HeaderText="Size ID" SortExpression="Size_ID" />
                                            <asp:BoundField DataField="SizeDesc" HeaderText="Size" SortExpression="SizeDesc" />
                                            <asp:TemplateField HeaderText="Alias" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnSize_ID" runat="server" Value='<%#(DataBinder.Eval(Container.DataItem,"Size_ID"))%>' />
                                                    <asp:TextBox ID="txtalias" Width="80px" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Alias"))%>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  <asp:TemplateField HeaderText="ML" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtml" Width="80px" CssClass="numeric" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"ML"))%>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Speg" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtspeg" Width="80px" CssClass="numeric" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Speg"))%>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Stock IN" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <%-- <asp:TextBox ID="txtstockin" Width="40px" runat="server" MaxLength="1" onkeypress="return onlyAlphabets(event,this);"
                                                Text='<%#(DataBinder.Eval(Container.DataItem,"Stock_In"))%>'></asp:TextBox>--%>
                                                    <asp:HiddenField ID="hdnStockIn" runat="server" Value='<%#(DataBinder.Eval(Container.DataItem,"Stock_In"))%>' />
                                                    <asp:DropDownList ID="ddlStockIn" runat="server">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Bottle" Value="B"></asp:ListItem>
                                                        <asp:ListItem Text="Peg" Value="P"></asp:ListItem>
                                                        <asp:ListItem Text="ML" Value="M"></asp:ListItem>
                                                    </asp:DropDownList>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="No Of Speg" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtnoofspeg" Width="80px" CssClass="numeric" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"NoOfSpeg"))%>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Peg Size(ML)" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtpegsize" Width="80px" CssClass="numeric" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"PegSize"))%>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <%-- <asp:LinkButton ID="Delete" runat="server" Style="cursor: pointer; text-decoration: underline;"
                                                CommandName="Delete" CommandArgument='<%# Trim(DataBinder.Eval(Container.DataItem, "CategorySizeLinkUpID")) %>'
                                                OnClientClick="return confirm('Are you sure you want to delete ?');">
                                                        Delete
                                            </asp:LinkButton>--%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
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
                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-navy" ClientIDMode="Static" OnClick="btnSave_Click" />
                                    <asp:Label ID="lblwarn" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:TextBox ID="txtDetails" runat="server" Width="500" Style="display: none;">
                        </asp:TextBox>

                        <!--begin: Datatable -->
                        <%-- <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">


                            <thead>

                                <tr>
                                    <th>Category Desc</th>
                                    <th>Assigned Department</th>
                                    <th>Action</th>
                                </tr>

                            </thead>
                            <%-- <tbody>
                            <tr>
                                <td>compel</td>
                                <td>hjsdhfsj</td>
                            </tr>
                        </tbody>--%>
                        <%--  <tbody>
                                <%=bindgrid()%>
                            </tbody>
                        </table>--%>
                    </div>
                </div>

                <!-- END EXAMPLE TABLE PORTLET-->
            </div>
        </div>

        <!-- Start Modal -->
        <%--   <div class="modal fade" id="Add_Category" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-sm" role="document">
                <div class="modal-content" id="dvpopup" runat="server">

                
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Add New Category</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">

                        <div class="form-group">
                            <label for="recipient-name" class="form-control-label">Category Desc:</label>

                            <asp:TextBox ID="txtCategoryDesc" runat="server" class="form-control"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="rfvDeptDesc" runat="server" ControlToValidate="txtDeptDesc" Visible="true" ValidationGroup="validationZone" ForeColor="Red" ErrorMessage="Please enter Department Desc"></asp:RequiredFieldValidator>--%>
        <%-- </div>

                    </div>

                    
                                    <div class="form-group m-form__group row">
                                        <div class="col-xl-9 col-lg-9">
                                            <asp:Label ID="lblZoneErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnCategorySave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" CausesValidation="true" ValidationGroup="validationZone" OnClick="btnCategorySave_Click" OnClientClick="return CheckForm()" Text="Save" />
                    </div>

                </div>

            </div>
        </div>--%>
        <!-- End Modal -->

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
                                        <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="txtCategoryDesc" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationWorkflow" ForeColor="Red" ErrorMessage="Please enter Workflow Description"></asp:RequiredFieldValidator>

                                    </div>
                                    <asp:Label ID="lblCategoryErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                </div>
                                <%--<div class="form-group m-form__group row">
                                        <div class="col-xl-9 col-lg-9">
                                            <asp:Label ID="Label1" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>--%>

                                <div class="modal-footer">
                                    <asp:Button ID="btnCloseCategory" Text="Close" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnCloseCategory_Click" />
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
