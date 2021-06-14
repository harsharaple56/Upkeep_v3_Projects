<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Add_Retailer.aspx.cs" Inherits="Upkeep_v3.General_Masters.Add_Retailer" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            $("#email").blur(function () {
                $("#txtUsername").val($("#email").val());
            });

            $("#txtassetLocation").on('input', function () {
                var val = this.value;

                $('#hdnassetLocation').val("");
                if ($('#dlassetLocation option').filter(function () {
                    if (this.value.toUpperCase() === val.toUpperCase()) {
                        //alert($(this).attr('text'));
                        $('#hdnassetLocation').val($(this).attr('text'));
                    }
                    return this.value.toUpperCase() === val.toUpperCase();
                }).length) {
                    //send ajax request
                    //alert(this.id);
                }
            });

            $('#btnSave').click(function () {
                $('#LocationError_Msg').text('').hide();

                if ($('#hdnassetLocation').val() == '') {
                    //alert("Please Select Proper Location!");
                    $('#LocationError_Msg').text("Please Select Proper Location").show();
                    return false;
                }
            });



        });
    </script>

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

        <div class="row">
            <div class="col-lg-12">

                <!--begin::Portlet-->
                <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                    <div class="m-portlet__head">
                        <div class="m-portlet__head-progress">

                            <!-- here can place a progress bar-->
                        </div>
                        <div class="m-portlet__head-wrapper">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <h3 class="m-portlet__head-text">Retailer details
                                    </h3>
                                </div>
                            </div>
                            <div class="m-portlet__head-tools">
                                <a href="<%= Page.ResolveClientUrl("Retailer_Master.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                    <span>
                                        <i class="la la-arrow-left"></i>
                                        <span>Back</span>
                                    </span>
                                </a>
                                <div class="btn-group">

                                    <asp:Button ID="btnSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" ValidationGroup="validateRetailer" OnClick="btnSave_Click" Text="Save" ClientIDMode="Static" />

                                </div>
                            </div>
                        </div>
                    </div>

                    <%--<form class="m-form m-form--label-align-left- m-form--state-" id="retailer_form" method="post" action="" runat="server" >--%>

                    <!--begin: Form Body -->
                    <div class="m-portlet__body">
                        <div class="row">
                            <div class="col-xl-10 offset-xl-2">
                                <div class="m-form__section m-form__section--first">

                                    <div class="form-group m-form__group row">
                                        <label class="col-xl-4 col-lg-3 col-form-label"><span style="color: red;">*</span> Store Name:</label>
                                        <div class="col-xl-6 col-lg-9">
                                            <asp:TextBox ID="store" runat="server" class="form-control m-input" placeholder="Enter store name"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvstore" runat="server" Display="Dynamic" ControlToValidate="store" Visible="true" ValidationGroup="validateRetailer" ForeColor="Red" ErrorMessage="Please enter Store name"></asp:RequiredFieldValidator>
                                            <span id="error_store" class="text-danger small"></span>
                                        </div>
                                    </div>

                                    <div class="form-group m-form__group row">
                                        <label class="col-xl-4 col-lg-3 col-form-label"><span style="color: red;">*</span> Store No.:</label>
                                        <div class="col-xl-6 col-lg-9">
                                            <asp:TextBox ID="txtStoreNo" runat="server" class="form-control m-input" placeholder="Enter store no"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic" ControlToValidate="txtStoreNo" Visible="true"
                                                ValidationGroup="validateRetailer" ForeColor="Red" ErrorMessage="Please enter Store No."></asp:RequiredFieldValidator>

                                        </div>
                                    </div>


                                    <div class="form-group m-form__group row">
                                        <label class="col-xl-4 col-lg-3 col-form-label"><span style="color: red;">*</span> Manager First name:</label>
                                        <div class="col-xl-6 col-lg-9">
                                            <%--<input type="text" name="first_name" id="first_name" class="form-control m-input" placeholder="Enter first name" value="">--%>
                                            <asp:TextBox ID="first_name" runat="server" class="form-control m-input" placeholder="Enter first name"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="first_name" Visible="true" ValidationGroup="validateRetailer" ForeColor="Red" ErrorMessage="Please enter first name"></asp:RequiredFieldValidator>

                                            <span id="error_first_name" class="text-danger small"></span>
                                        </div>
                                    </div>
                                    <div class="form-group m-form__group row">
                                        <label class="col-xl-4 col-lg-3 col-form-label"><span style="color: red;">*</span> Manager Last name:</label>
                                        <div class="col-xl-6 col-lg-9">
                                            <%--<input type="text" name="last_name" id="last_name" class="form-control m-input" placeholder="Enter last name" value="">--%>
                                            <asp:TextBox ID="last_name" runat="server" class="form-control m-input" placeholder="Enter last name"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="last_name" Visible="true" ValidationGroup="validateRetailer" ForeColor="Red" ErrorMessage="Please enter last name"></asp:RequiredFieldValidator>

                                            <span id="error_last_name" class="text-danger small"></span>
                                        </div>
                                    </div>
                                    <div class="form-group m-form__group row">
                                        <label class="col-xl-4 col-lg-3 col-form-label"><span style="color: red;">*</span> Email:</label>
                                        <div class="col-xl-6 col-lg-9">
                                            <%--<input type="text" name="email" id="email" class="form-control m-input" placeholder="Enter Email" value="">--%>
                                            <asp:TextBox ID="email" runat="server" class="form-control m-input" placeholder="Enter Email ID"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ControlToValidate="email" Visible="true" ValidationGroup="validateRetailer" ForeColor="Red" ErrorMessage="Please enter Email ID"></asp:RequiredFieldValidator>

                                            <span id="error_email" class="text-danger small"></span>
                                        </div>
                                    </div>
                                    <div class="form-group m-form__group row">
                                        <label class="col-xl-4 col-lg-3 col-form-label"><span style="color: red;">*</span> Contact Number</label>
                                        <div class="col-xl-6 col-lg-9">
                                            <div class="input-group">
                                                <div class="input-group-prepend"><span class="input-group-text"><i class="la la-phone"></i></span></div>
                                                <%--<input type="text" name="contact" id="contact" class="form-control m-input numbers_only" placeholder="Enter contact number" value="" maxlength="12">--%>
                                                <asp:TextBox ID="contact" runat="server" class="form-control m-input numbers_only" MaxLength="12" placeholder="Enter contact number"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" ControlToValidate="contact" Visible="true" ValidationGroup="validateRetailer" ForeColor="Red" ErrorMessage="Please enter contact number"></asp:RequiredFieldValidator>

                                            </div>
                                            <span id="error_contact" class="text-danger small"></span>
                                        </div>
                                    </div>

                                    <div class="form-group m-form__group row">
                                        <label class="col-xl-4 col-lg-3 col-form-label"><span style="color: red;">*</span> Location:</label>
                                        <div class="col-xl-8 col-lg-9">
                                            <asp:HiddenField ID="hdnassetLocation" runat="server" ClientIDMode="Static" />

                                            <input list="dlassetLocation" id="txtassetLocation" name="txtassetLocation"
                                                class="form-control" runat="server" clientidmode="Static" />
                                            <datalist id="dlassetLocation" runat="server" clientidmode="Static"></datalist>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtassetLocation"
                                                Display="Dynamic" ValidationGroup="validateRetailer" ForeColor="Red" InitialValue="0"
                                                ErrorMessage="Please select Location"></asp:RequiredFieldValidator>
                                            <span id="LocationError_Msg" style="color: red;"></span>
                                            <%-- <asp:DropDownList ID="ddlLocation" class="form-control m-input" runat="server"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlLocation" Visible="true" Display="Dynamic"
                                                ValidationGroup="validateRetailer" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Location"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>

                                    <div class="form-group m-form__group row">
                                        <label class="col-xl-4 col-lg-3 col-form-label"><span style="color: red;">*</span> Username:</label>
                                        <div class="col-xl-6 col-lg-9">
                                            <%--<input type="text" name="email" id="email" class="form-control m-input" placeholder="Enter Email" value="">--%>
                                            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control m-input" ClientIDMode="Static" placeholder="Enter Username"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" ControlToValidate="txtUsername" Visible="true" ValidationGroup="validateRetailer" ForeColor="Red" ErrorMessage="Please enter Username"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>

                                    <div class="form-group m-form__group row">
                                        <label class="col-xl-4 col-lg-3 col-form-label"><span style="color: red;">*</span> Password:</label>
                                        <div class="col-xl-6 col-lg-9">
                                            <%--<input type="text" name="email" id="email" class="form-control m-input" placeholder="Enter Email" value="">--%>
                                            <asp:TextBox ID="txtPassword" runat="server" class="form-control m-input" placeholder="Enter Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" ControlToValidate="txtpassword" Visible="true" ValidationGroup="validateRetailer" ForeColor="Red" ErrorMessage="Please enter Password"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="form-group m-form__group row">
                                        <div class="col-xl-9 col-lg-9">
                                            <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="m-form__section">
                                        <div class="form-group m-form__group row">
                                            <div class="col-4">
                                                <h3 class="m-form__section">Escalation Levels</h3>
                                            </div>
                                        </div>
                                        <div class="question_repeater">
                                            <div class="form-group  m-form__group row">

                                                <%--Editable grid start--%>

                                                <div id="m_table_1" style="padding: 10px; width: 750px; overflow-x: auto;">
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="gvEscalation" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvEscalation_RowDataBound"
                                                                DataKeyNames="Escalation_ID" OnRowEditing="gvEscalation_RowEditing" OnRowCancelingEdit="gvEscalation_RowCancelingEdit"
                                                                PageSize="3" AllowPaging="true" OnPageIndexChanging="gvEscalation_PageIndexChanging"
                                                                OnRowUpdating="gvEscalation_RowUpdating" OnRowDeleting="gvEscalation_RowDeleting" EmptyDataText="No records has been added."
                                                                HeaderStyle-BackColor="#f4f3f8" HeaderStyle-ForeColor="Black" CssClass="">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Level" ItemStyle-Width="150">
                                                                        <ItemTemplate>
                                                                            <%--<asp:HiddenField ID="hdnEscalationID" runat="server" Value='<%# Eval("Escalation_ID") %>' />--%>
                                                                            <asp:Label ID="lblLevel" runat="server" Text='<%# Eval("Escalation_Level") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("Name") %>' Width="130"></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Designation" ItemStyle-Width="150">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("Designation") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="txtDesignation" runat="server" Text='<%# Eval("Designation") %>' Width="110"></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Department" ItemStyle-Width="150">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("R_Dept_Name") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="txtDepartment" runat="server" Text='<%# Eval("R_Dept_Name") %>' Width="120"></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Contact No" ItemStyle-Width="150">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblContactNo" runat="server" Text='<%# Eval("Contact") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="txtContactNo_Esc" runat="server" Text='<%# Eval("Contact") %>' Width="100"></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="EmailID" ItemStyle-Width="150">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblEmailID" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="txtEmailID_Esc" runat="server" Text='<%# Eval("Email") %>' Width="120"></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" HeaderText="Action"
                                                                        ItemStyle-Width="150" />
                                                                </Columns>
                                                            </asp:GridView>
                                                            <br />
                                                            <br />

                                                            <div id="dvGrid1" style="width: 750px">
                                                                <table border="1" cellpadding="1" cellspacing="1" style="border-collapse: collapse;">
                                                                    <thead>
                                                                        <tr style="color: Black; background-color: #F4F3F8;">
                                                                            <th>Name</th>
                                                                            <th>Designation</th>
                                                                            <th>Department</th>
                                                                            <th>ContactNo</th>
                                                                            <th>EmailID</th>
                                                                            <th>Action</th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tr>
                                                                        <td style="width: 140px">
                                                                            <asp:TextBox ID="txtAddName" runat="server" Width="140" />
                                                                        </td>
                                                                        <td style="width: 100px">
                                                                            <asp:TextBox ID="txtAddDesignation" runat="server" Width="120" />
                                                                        </td>
                                                                        <td style="width: 100px">
                                                                            <asp:TextBox ID="txtAddDepartment" runat="server" Width="120" />
                                                                        </td>
                                                                        <td style="width: 100px">
                                                                            <asp:TextBox ID="txtAddContactNo" runat="server" Width="120" />
                                                                        </td>
                                                                        <td style="width: 100px">
                                                                            <asp:TextBox ID="txtAddEmailID" runat="server" Width="120" />
                                                                        </td>
                                                                        <td style="width: 90px; text-align: center;">
                                                                            <asp:Button ID="btnAddEscalation" runat="server" Text="Add" OnClick="btnAddEscalation_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>


                                                <%--Editable grid end--%>
                                            </div>

                                        </div>
                                    </div>

                                <div class="m-portlet__foot m-portlet__foot--fit">
                                    <div class="m-form__actions">
                                        <div class="row">
                                            <div class="col-2">
                                            </div>
                                            <div class="col-7">
                                                <asp:Label ID="lblEscalationError" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <%--</form>--%>
                </div>

                <!--end::Portlet-->

            </div>
        </div>
    </div>

</asp:Content>
