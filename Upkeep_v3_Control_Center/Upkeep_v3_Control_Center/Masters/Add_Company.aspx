<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Add_Company.aspx.cs" Inherits="Upkeep_v3_Control_Center.Masters.Add_Company" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            left: 0px;
            top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <form class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" method="post" runat="server" id="frmCompany">

                        <div class="m-form m-form--label-align-left- m-form--state-" id="employee_form">
                            <div class="m-portlet__head">
                                <div class="m-portlet__head-progress">

                                    <!-- here can place a progress bar-->
                                </div>
                                <div class="m-portlet__head-wrapper">
                                    <div class="m-portlet__head-caption">
                                        <div class="m-portlet__head-title">
                                            <h3 class="m-portlet__head-text">Company details
                                            </h3>
                                        </div>
                                    </div>

                                    <div class="m-portlet__head-tools">
                                        <a href="Company_Mst.aspx" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                            <span>
                                                <i class="la la-arrow-left"></i>
                                                <span>Back</span>
                                            </span>
                                        </a>
                                        <div class="btn-group">

                                            <asp:Button ID="btnSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnSave_Click" Text="Save" />

                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div class="m-portlet__body">

                                <!--begin: Form Body -->
                                <div class="">
                                    <div class="row">
                                        <div class="col-xl-12">
                                            <div class="">

                                                <div class="form-group row" style="background-color: #00c5dc;">
                                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Company Details</label>
                                                </div>

                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Company Code:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="txtCompany_Code" runat="server" class="form-control m-input" placeholder="Enter Company Code"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvCompanyCode" runat="server" ControlToValidate="txtCompany_Code" Display="Dynamic"
                                                            ErrorMessage="Please enter Company Code" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>

                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Company Name:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="txtCompDesc" runat="server" class="form-control m-input" placeholder="Enter Company Name"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvCompDesc" runat="server" ControlToValidate="txtCompDesc" Display="Dynamic"
                                                            ErrorMessage="Please enter company name" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Company Email ID:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="txtCompanyEmailID" runat="server" TextMode="Email" class="form-control m-input" placeholder="Enter Company Email ID"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCompDesc" Display="Dynamic"
                                                            ErrorMessage="Enter Company Email ID" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>

                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Company Mobile No:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="txtCompanyMobileNo" runat="server" TextMode="Number" MaxLength="10" class="form-control m-input" placeholder="Enter Company Mobile No"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCompDesc" Display="Dynamic"
                                                            ErrorMessage="Enter Company Mobile No" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                 <div class="form-group m-form__group row">
                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Group Description:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:DropDownList ID="ddlGroupDesc" class="form-control m_selectpicker" runat="server"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfvGroupDesc" runat="server" ControlToValidate="ddlGroupDesc" InitialValue="0" Display="Dynamic"
                                                            ErrorMessage="Please select Group description" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>

                                                     <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Company Logo</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:FileUpload ID="fileUpload_CompanyLogo" runat="server" />
                                                    </div>
                                                </div>

                                                 <div class="form-group m-form__group row">
                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Client URL:</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                        <asp:TextBox ID="txtClientURL" runat="server" class="form-control m-input" placeholder="Enter Client URL"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtClientURL" Display="Dynamic"
                                                            ErrorMessage="Please enter client URL" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>

                                                <div class="form-group row" style="background-color: #00c5dc;">
                                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">User Details</label>
                                                </div>

                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Name:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="txtAdminName" runat="server" class="form-control m-input" placeholder="Enter Name"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAdminName" Display="Dynamic"
                                                            ErrorMessage="Enter Name" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>

                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> User Designation:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="txtUserDesignation" runat="server" class="form-control m-input" placeholder="User Designation"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtUserDesignation" Display="Dynamic"
                                                            ErrorMessage="Enter User Designation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> User Email ID:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="txtUserEmailID" runat="server" TextMode="Email" class="form-control m-input" placeholder="Enter User Email ID"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtUserEmailID" Display="Dynamic"
                                                            ErrorMessage="Enter User Email ID" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>

                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> User Mobile No:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="txtUserMobileNo" runat="server" TextMode="Number" MaxLength="10" class="form-control m-input" placeholder="Enter User Mobile No"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtUserMobileNo" Display="Dynamic"
                                                            ErrorMessage="Enter User Mobile No" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                <div class="form-group row" style="background-color: #00c5dc;">
                                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Other Details</label>
                                                </div>


                                                <div class="form-group m-form__group row">
                                                    <div class="col-xl-1 col-lg-3 col-form-label">
                                                        <span style="color: red;">*</span><asp:CheckBox ID="chk_IsDBatClient" OnCheckedChanged="chk_IsDBatClient_CheckedChanged" AutoPostBack="true" runat="server" Style="margin-left: 3px;" />
                                                    </div>
                                                    <label class="col-xl-8 col-lg-3 col-form-label">Check the Box if Database is on Client Server.</label>
                                                </div>

                                                <div id="dvServerDetails" runat="server" visible="false">
                                                    <div class="form-group m-form__group row">
                                                        <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Server Name:</label>
                                                        <div class="col-xl-9 col-lg-9">
                                                            <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter last name" value="">--%>
                                                            <asp:TextBox ID="txtServerName" runat="server" class="form-control m-input" placeholder="Enter Database Server Name"></asp:TextBox>
                                                            <span id="error_txtServerName" class="text-danger small"></span>
                                                        </div>
                                                    </div>
                                                    <div class="form-group m-form__group row">
                                                        <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Database Name:</label>
                                                        <div class="col-xl-9 col-lg-9">
                                                            <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter last name" value="">--%>
                                                            <asp:TextBox ID="txtDatabase" runat="server" class="form-control m-input" placeholder="Enter Database Name"></asp:TextBox>
                                                            <span id="error_txtDatabase" class="text-danger small"></span>
                                                        </div>
                                                    </div>
                                                    <div class="form-group m-form__group row">
                                                        <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Username:</label>
                                                        <div class="col-xl-9 col-lg-9">
                                                            <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter last name" value="">--%>
                                                            <asp:TextBox ID="txtDbUser" runat="server" class="form-control m-input" placeholder="Enter Database User Name"></asp:TextBox>
                                                            <span id="error_txtDbUser" class="text-danger small"></span>
                                                        </div>
                                                    </div>
                                                    <div class="form-group m-form__group row">
                                                        <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Password:</label>
                                                        <div class="col-xl-9 col-lg-9">
                                                            <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter last name" value="">--%>
                                                            <asp:TextBox ID="txtDbPassword" runat="server" class="form-control m-input" placeholder="Enter Database User Password"></asp:TextBox>
                                                            <span id="error_txtDbPassword" class="text-danger small"></span>
                                                        </div>
                                                    </div>

                                                </div>

                                                <div class="form-group m-form__group row">
                                                    <div class="col-xl-9 col-lg-9">
                                                        <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="form-group row" style="background-color: #00c5dc;">
                                                <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">SMS Configurataion</label>
                                            </div>

                                                <div class="form-group m-form__group row">
                                                    <div class="col-xl-1 col-lg-3 col-form-label">
                                                        <span style="color: red;">*</span><asp:CheckBox ID="chk_Is_SMS_Enable" OnCheckedChanged="chk_Is_SMS_Enable_CheckedChanged" AutoPostBack="true" runat="server" Style="margin-left: 3px;" />
                                                    </div>
                                                    <label class="col-xl-8 col-lg-3 col-form-label">Enable SMS</label>
                                                </div>
                                                
                                                <div id="SMS_Config_Details" runat="server" visible="false">
                                                    <div class="form-group m-form__group row">
                                                        <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Select SMS Configuration:</label>
                                                        <div class="col-xl-9 col-lg-9">
                                                            <asp:DropDownList ID="SMS_Config_ID" class="form-control m-input" runat="server"></asp:DropDownList>
                                                            <span id="error_SMS_Config" class="text-danger small"></span>
                                                        </div>
                                                    </div>
                                                    <div class="form-group m-form__group row">
                                                        <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Available Allot SMS Balance:</label>
                                                        <div class="col-xl-9 col-lg-9">
                                                            <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter last name" value="">--%>
                                                            <asp:Label ID="Available_Allot_SMS_Bal" runat="server" class="form-control m-input" ></asp:Label>
                                                            <span id="error_Available_Allot_SMS_Bal" class="text-danger small"></span>
                                                        </div>
                                                    </div>
                                                    <div class="form-group m-form__group row">
                                                        <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Alloted SMS Balance:</label>
                                                        <div class="col-xl-9 col-lg-9">
                                                            <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter last name" value="">--%>
                                                            <asp:TextBox ID="txt_Alloted_SMS" runat="server" class="form-control m-input" placeholder="Enter No. of SMS to be alloted to be Company"></asp:TextBox>
                                                            <span id="error_txt_Alloted_SMS" class="text-danger small"></span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group m-form__group row">
                                                    <div class="col-xl-9 col-lg-9">
                                                        <asp:Label ID="Label1" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                                    </div>
                                                </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </form>
                </div>

                <!--end::Portlet-->
            </div>
        </div>
    </div>


</asp:Content>
