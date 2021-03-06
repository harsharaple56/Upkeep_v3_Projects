<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Retailer_Profile.aspx.cs" Inherits="Upkeep_v3.Retailer_Profile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/assets/demo/custom/crud/metronic-datatable/base/html-table.js") %>" type="text/javascript"></script>
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

        /*.highlight {
            background-color: blanchedalmond;
        }*/
    </style>
    <script type="text/javascript">

        $(document).ready(function () {
            Dropzone.autoDiscover = false;
            var url = window.location.href;
            $("#dZUpload").dropzone({
                url: "Handlers/RetailerImage_Handler.ashx",
                maxFiles: 1,
                success: function () {
                    $('#m_modal_1').modal('hide');
                    $(location).attr('href', url);
                },
                error: function () {
                    $('#m_modal_1').modal('hide');
                    $(location).attr('href', url);
                }
            });
        });
    </script>
    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

        <!-- BEGIN: Subheader -->
        <div class="m-content">
            <div class="d-flex align-items-center">
                <div class="mr-auto">
                    <h3 class="m-subheader__title ">My Profile</h3>
                </div>

            </div>


            <!-- END: Subheader -->
            <div class="">
                <div class="row">
                    <div class="col-xl-3 col-lg-4">
                        <div class="m-portlet m-portlet--full-height  ">
                            <div class="m-portlet__body">
                                <div class="m-card-profile">
                                    <div class="m-card-profile__title m--hide">
                                        Your Profile
                                    </div>
                                    <div class="m-card-profile__pic">
                                        <div class="m-card-profile__pic-wrapper">
                                            <%--<img src="../assets/app/media/img/users/user4.jpg" alt="" />--%>
                                            <asp:Image ID="imgProfilePic" runat="server" />
                                        </div>
                                    </div>
                                    <div class="m-card-profile__details">
                                        <asp:Label ID="lblProfileName" runat="server" Text="" class="m-card-profile__name"></asp:Label>
                                        <asp:Label ID="lblProfileUsername" runat="server" Text="" class="m-card-profile__email m-link"></asp:Label>
                                    </div>
                                    <div class="m-card-profile__details">
                                        <button type="button" class="btn-outline-success btn btn-accent" data-toggle="modal" data-target="#m_modal_1"><i class="fa fa-image fa-fw"></i>&nbsp; Change Pic</button>
                                    </div>

                                </div>
                                <ul class="m-nav m-nav--hover-bg m-portlet-fit--sides">
                                    <li class="m-nav__separator m-nav__separator--fit"></li>
                                    <li class="m-nav__section m--hide">
                                        <span class="m-nav__section-text">Section</span>
                                    </li>
                                    <li class="m-nav__item">
                                        <a href="../header/profile&amp;demo=default.html" class="m-nav__link">
                                            <i class="m-nav__link-icon flaticon-profile-1"></i>
                                            <span class="m-nav__link-title">
                                                <span class="m-nav__link-wrap">
                                                    <span class="m-nav__link-text">My Profile</span>
                                                    <span class="m-nav__link-badge"><span class="m-badge m-badge--success">2</span></span>
                                                </span>
                                            </span>
                                        </a>
                                    </li>
                                    <li class="m-nav__item">
                                        <a href="../header/profile&amp;demo=default.html" class="m-nav__link">
                                            <i class="m-nav__link-icon flaticon-share"></i>
                                            <span class="m-nav__link-text">Activity</span>
                                        </a>
                                    </li>

                                    <li class="m-nav__item">
                                        <a href="../header/profile&amp;demo=default.html" class="m-nav__link">
                                            <i class="m-nav__link-icon flaticon-lifebuoy"></i>
                                            <span class="m-nav__link-text">Support</span>
                                        </a>
                                    </li>
                                </ul>
                                <div class="m-portlet__body-separator"></div>
                                <div class="m-widget1 m-widget1--paddingless">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-9 col-lg-8">
                        <div class="m-portlet m-portlet--full-height m-portlet--tabs  ">
                            <div class="m-portlet__head">
                                <div class="m-portlet__head-tools">
                                    <ul class="nav nav-tabs m-tabs m-tabs-line   m-tabs-line--left m-tabs-line--primary" role="tablist">
                                        <li class="nav-item m-tabs__item">
                                            <a class="nav-link m-tabs__link active" data-toggle="tab" href="#m_user_profile_tab_1" role="tab">
                                                <i class="flaticon-share m--hide"></i>
                                                Store Manager Details
                                            </a>
                                        </li>
                                        <li class="nav-item m-tabs__item">
                                            <a class="nav-link m-tabs__link" data-toggle="tab" href="#m_user_profile_tab_2" role="tab">Escalation Details
                                            </a>
                                        </li>
                                        <li class="nav-item m-tabs__item">
                                            <a class="nav-link m-tabs__link" data-toggle="tab" href="#m_user_profile_tab_3" role="tab">Settings 
                                            </a>
                                        </li>
                                    </ul>
                                </div>
                                <div class="m-portlet__head-tools">
                                    <ul class="m-portlet__nav">
                                        <li class="m-portlet__nav-item m-portlet__nav-item--last">
                                            <div class="m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover" aria-expanded="true">
                                                <a href="#" class="m-portlet__nav-link btn btn-lg btn-secondary  m-btn m-btn--icon m-btn--icon-only m-btn--pill  m-dropdown__toggle">
                                                    <i class="la la-gear"></i>
                                                </a>
                                                <div class="m-dropdown__wrapper">
                                                    <span class="m-dropdown__arrow m-dropdown__arrow--right m-dropdown__arrow--adjust"></span>
                                                    <div class="m-dropdown__inner">
                                                        <div class="m-dropdown__body">
                                                            <div class="m-dropdown__content">
                                                                <ul class="m-nav">
                                                                    <li class="m-nav__section m-nav__section--first">
                                                                        <span class="m-nav__section-text">Quick Actions</span>
                                                                    </li>
                                                                    <li class="m-nav__item">
                                                                        <a id="btnChangePassword" runat="server" class="m-nav__link">
                                                                            <i class="m-nav__link-icon flaticon-share"></i>
                                                                            <span class="m-nav__link-text">Change Password</span>
                                                                        </a>
                                                                    </li>

                                                                    <li class="m-nav__section">
                                                                        <span class="m-nav__section-text">Useful Links</span>
                                                                    </li>
                                                                    <li class="m-nav__item">
                                                                        <a href="<%= Page.ResolveClientUrl("~/Knowledge_Base/Retailer_Manual.aspx") %>" class="m-nav__link">
                                                                            <i class="m-nav__link-icon flaticon-lifebuoy"></i>
                                                                            <span class="m-nav__link-text">Retailer Manual</span>
                                                                        </a>
                                                                    </li>
                                                                    <li class="m-nav__item">
                                                                        <a href="https://efacilito.com/support-page/" class="m-nav__link">
                                                                            <i class="m-nav__link-icon flaticon-questions-circular-button"></i>
                                                                            <span class="m-nav__link-text">Support</span>
                                                                        </a>
                                                                    </li>
                                                                    <li class="m-nav__separator m-nav__separator--fit m--hide"></li>
                                                                    <li class="m-nav__item m--hide">
                                                                        <a href="#" class="btn btn-outline-danger m-btn m-btn--pill m-btn--wide btn-sm">Submit</a>
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div class="tab-content">
                                <div class="tab-pane active" id="m_user_profile_tab_1">
                                    <div class="m-form m-form--fit m-form--label-align-right">
                                        <div class="m-portlet__body">

                                            <div class="form-group m-form__group row">
                                                <label for="example-text-input" class="col-3 col-form-label font-weight-bold">Store Name :</label>
                                                <div class="col-7 col-form-label">
                                                    <asp:Label ID="lblStorename" runat="server" Text="" class="form-control-label"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="form-group m-form__group row">
                                                <label for="example-text-input" class="col-3 col-form-label font-weight-bold">Store No. :</label>
                                                <div class="col-7 col-form-label">
                                                    <asp:Label ID="lblStoreNo" runat="server" Text="" class="form-control-label"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="form-group m-form__group row">
                                                <label for="example-text-input" class="col-3 col-form-label font-weight-bold">Username :</label>
                                                <div class="col-7 col-form-label">
                                                    <asp:Label ID="lblUsername" runat="server" Text="" class="form-control-label"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="form-group m-form__group row">
                                                <label for="example-text-input" class="col-3 col-form-label font-weight-bold">First Name :</label>
                                                <div class="col-7 col-form-label">
                                                    <asp:TextBox ID="txtFirstName" runat="server" class="form-control m-input"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group m-form__group row">
                                                <label for="example-text-input" class="col-3 col-form-label font-weight-bold">Last Name :</label>
                                                <div class="col-7 col-form-label">
                                                    <asp:TextBox ID="txtLastName" runat="server" class="form-control m-input"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group m-form__group row">
                                                <label for="example-text-input" class="col-3 col-form-label font-weight-bold">Contact No. :</label>
                                                <div class="col-7">
                                                    <asp:TextBox ID="txtContactNo" runat="server" TextMode="Number" class="form-control m-input"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group m-form__group row">
                                                <label for="example-text-input" class="col-3 col-form-label font-weight-bold">Alternate Contact No. :</label>
                                                <div class="col-7">
                                                    <asp:TextBox ID="txtAlternatePhoneNo" runat="server" TextMode="Number" class="form-control m-input"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group m-form__group row">
                                                <label for="example-text-input" class="col-3 col-form-label font-weight-bold">Email :</label>
                                                <div class="col-7">
                                                    <asp:TextBox ID="txtEmailID" runat="server" class="form-control m-input"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group m-form__group row">
                                                <label for="example-text-input" class="col-3 col-form-label font-weight-bold">Address :</label>
                                                <div class="col-7">
                                                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" class="form-control m-input"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group m-form__group row">
                                                <label for="example-text-input" class="col-3 col-form-label font-weight-bold">City :</label>
                                                <div class="col-7">
                                                    <asp:TextBox ID="txtCity" runat="server" class="form-control m-input"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group m-form__group row">
                                                <label for="example-text-input" class="col-3 col-form-label font-weight-bold">State :</label>
                                                <div class="col-7">
                                                    <asp:TextBox ID="txtState" runat="server" class="form-control m-input"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group m-form__group row">
                                                <label for="example-text-input" class="col-3 col-form-label font-weight-bold">Postcode :</label>
                                                <div class="col-7">
                                                    <asp:TextBox ID="txtPostcode" TextMode="Number" runat="server" class="form-control m-input"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="m-portlet__foot m-portlet__foot--fit">
                                            <div class="m-form__actions">
                                                <br />
                                                <div class="row">
                                                    <div class="col-4">
                                                    </div>
                                                    <div class="col-7">
                                                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-accent m-btn m-btn--air m-btn--custom" Text="Submit" OnClick="btnSubmit_Click" />
                                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-secondary m-btn m-btn--air m-btn--custom" Text="Cancel" OnClick="btnCancel_Click" />
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <asp:Label ID="lblMsg" runat="server" Font-Bold="true" ForeColor="Green"></asp:Label>
                                                </div>
                                                <br />
                                                <br />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane " id="m_user_profile_tab_2">
                                    <div class="m-form m-form--fit m-form--label-align-right">
                                        <div class="m-portlet__body">

                                            <div class="m-form__section">
                                                <div class="form-group m-form__group row">
                                                    <div class="col-10 ml-auto">
                                                        <h3 class="m-form__section">Escalation Level</h3>
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
                                <div class="tab-pane " id="m_user_profile_tab_3">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <asp:Button ID="btnTest" Style="display: none;" runat="server" />
            <cc1:ModalPopupExtender ID="mpeChangePassword" runat="server" PopupControlID="pnlChangePassword" TargetControlID="btnChangePassword"
                CancelControlID="btnCloseHeader2" BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>

            <asp:Panel ID="pnlChangePassword" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 65%;">
                <div class="" id="add_sub_location2" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document" style="max-width: 100%;">
                        <div class="modal-content">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>


                                    <div class="modal-header">
                                        <h5 class="modal-title" id="exampleModalLabel2">Change Password</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader2">
                                            <span aria-hidden="true">&times;</span>

                                        </button>
                                    </div>
                                    <div class="modal-body">

                                        <div class="form-group m-form__group row">
                                            <label for="message-text" class="col-xl-3 col-lg-3 form-control-label">Current Password :</label>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:TextBox ID="txtCurrentPassword" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                                            </div>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:RequiredFieldValidator ID="rfvCurrentPasswrd" ValidationGroup="ChangePassword" runat="server" Display="Dynamic" ForeColor="Red"
                                                    ErrorMessage="Please enter Current Password" ControlToValidate="txtCurrentPassword"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="form-group m-form__group row">
                                            <label for="message-text" class="col-xl-3 col-lg-3 form-control-label">New Password :</label>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:TextBox ID="txtNewPassword" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                                            </div>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="ChangePassword" runat="server" Display="Dynamic" ForeColor="Red"
                                                    ErrorMessage="Please enter New Password" ControlToValidate="txtNewPassword"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="form-group m-form__group row">
                                            <label for="message-text" class="col-xl-3 col-lg-3 form-control-label">Confirm Password :</label>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:TextBox ID="txtConfirmPassword" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                                            </div>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="ChangePassword" runat="server" Display="Dynamic" ForeColor="Red"
                                                    ErrorMessage="Please enter Confirm Password" ControlToValidate="txtConfirmPassword"></asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="cmpChangepasswrd" runat="server" Display="Dynamic" ForeColor="Red" ValidationGroup="ChangePassword"
                                                    ControlToCompare="txtNewPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="New Password and Confirm Password does not match"></asp:CompareValidator>
                                            </div>
                                        </div>

                                        <div class="form-group m-form__group row">
                                            <div class="col-xl-1 col-lg-1">
                                            </div>
                                            <asp:Label ID="lblChangePasswordError" runat="server" ForeColor="Red"></asp:Label>
                                            <asp:Label ID="lblChangePasswordSuccess" runat="server" ForeColor="Green"></asp:Label>

                                        </div>

                                    </div>


                                    <div class="modal-footer">
                                        <asp:Button ID="btnChangePassword_Submit" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" ValidationGroup="ChangePassword" Text="Submit" OnClick="btnChangePassword_Submit_Click" />
                                        <asp:Button ID="btnChangePassword_Cancel" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="Cancel" OnClick="btnChangePassword_Cancel_Click" />

                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnTest" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>


                        </div>
                    </div>
                </div>
                <!-- End Modal -->
            </asp:Panel>
            <div class="modal fade" id="m_modal_1" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Change Profile Picture</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>

                        <div class="modal-body">
                            <div class="m-dropzone dropzone" id="dZUpload">
                                <div class="m-dropzone__msg dz-message needsclick">
                                    <h5 class="m-dropzone__msg-title">Drop files here or click to upload.</h5>
                                </div>
                            </div>
                        </div>



                        <%--<div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-primary">Save changes</button>
                        </div>--%>
                    </div>
                </div>
            </div>

        </div>



    </div>


</asp:Content>
