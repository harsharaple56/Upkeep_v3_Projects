<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Add_User_Mst.aspx.cs" Inherits="Upkeep_v3.General_Masters.Add_User_Mst" %>
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
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <div class="m-form m-form--label-align-left- m-form--state-" runat ="server" id ="frmAddUser" >
                            <div class="m-portlet__head">
                                <div class="m-portlet__head-progress">

                                    <!-- here can place a progress bar-->
                                </div>
                                <div class="m-portlet__head-wrapper">
                                    <div class="m-portlet__head-caption">
                                        <div class="m-portlet__head-title">
                                            <h3 class="m-portlet__head-text">User details
                                            </h3>
                                        </div>
                                    </div>

                                    <div class="m-portlet__head-tools">

                                 <asp:Label ID="lblUserErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" style="font-size: large;font-weight: bold;"  ></asp:Label>

                                        <a href="<%= Page.ResolveClientUrl("User_Mst.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
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
                                <div class="m-portlet__body">
                                    <div class="row">
                                        <div class="col-xl-8 offset-xl-2">
                                            <div class="m-form__section m-form__section--first">
                                              
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Zone:</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                        <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter first name" value="">--%>
                                                       <asp:DropDownList ID="ddlZone" class="form-control m-input" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged" AutoPostBack="true" runat="server" ></asp:DropDownList>
                                                    <%--  OnSelectedIndexChanged="ddlZone_SelectedIndexChanged" AutoPostBack="true"--%>

                                                    </div>
                                                </div>
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Location:</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                        <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter first name" value="">--%>
                                                       <asp:DropDownList ID="ddlLocation" class="form-control m-input" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged" AutoPostBack="true" runat="server" ></asp:DropDownList>
                                                     

                                                    </div>
                                                </div>
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Sub-Location:</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                        <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter first name" value="">--%>
                                                       <asp:DropDownList ID="ddlSublocation" class="form-control m-input"  OnSelectedIndexChanged="ddlSublocation_SelectedIndexChanged" AutoPostBack="true" runat="server" ></asp:DropDownList>
                                                      
                                                      

                                                    </div>
                                                </div>
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Department:</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                        <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter first name" value="">--%>
                                                        <asp:DropDownList ID="ddlDepartment" class="form-control m-input" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="true"   runat="server"></asp:DropDownList>


                                                    </div>
                                                </div>
                                                 <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span>User Type:</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                        <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter first name" value="">--%>
                                                       <asp:DropDownList ID="ddlTypeUser" class="form-control m-input" OnSelectedIndexChanged="ddlTypeUser_SelectedIndexChanged"   runat="server" ></asp:DropDownList>
                                                     

                                                    </div>
                                                </div>
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> User Code:</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                        <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter last name" value="">--%>
                                                        <asp:TextBox ID="txtUserCode" runat="server" class="form-control m-input" placeholder="User_Code"></asp:TextBox>
                                                        <span id="error_txtUserCode" class="text-danger small"></span>
                                                        <asp:RequiredFieldValidator ID="rfvUserCode" runat="server" ControlToValidate="txtUserCode"
                                                        ErrorMessage="Please select User Code" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> First Name:</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                        <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter last name" value="">--%>
                                                        <asp:TextBox ID="txtFirstName" runat="server" class="form-control m-input" placeholder="First Name"></asp:TextBox>
                                                        <span id="error_txtFirstName" class="text-danger small"></span>
                                                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                                                        ErrorMessage="Please select First Name" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Last Name:</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                        <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter last name" value="">--%>
                                                        <asp:TextBox ID="txtlastName" runat="server" class="form-control m-input" placeholder="Last Name"></asp:TextBox>
                                                        <span id="error_txtlastName" class="text-danger small"></span>
                                                        <asp:RequiredFieldValidator ID="rfvlastName" runat="server" ControlToValidate="txtlastName"
                                                        ErrorMessage="Please select Last Name" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                 <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> User Email:</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                        <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter last name" value="">--%>
                                                        <asp:TextBox ID="txtuseremail" runat="server" class="form-control m-input" placeholder="User Email"></asp:TextBox>
                                                        <span id="error_txtUserEmail" class="text-danger small"></span>
                                                        <asp:RequiredFieldValidator ID="rfvUserEmail" runat="server" ControlToValidate="txtUserEmail"
                                                        ErrorMessage="Please select User Email" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> User Designation:</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                        <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter last name" value="">--%>
                                                        <asp:TextBox ID="txtUserDesignation" runat="server" class="form-control m-input" placeholder="User_Designation"></asp:TextBox>
                                                        <span id="error_txtUserDesignation" class="text-danger small"></span>
                                                        <asp:RequiredFieldValidator ID="rfvUserDesignation" runat="server" ControlToValidate="txtUserDesignation"
                                                        ErrorMessage="Please select User Designation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                 <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Mobile Number:</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                        <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter last name" value="">--%>
                                                        <asp:TextBox ID="txtmobile" runat="server" class="form-control m-input" placeholder="Mobile Number"></asp:TextBox>
                                                        <span id="error_txtMobile" class="text-danger small"></span>
                                                        <asp:RequiredFieldValidator ID="rfvmobile" runat="server" ControlToValidate="txtmobile"
                                                        ErrorMessage="Please select Mobile number" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                 <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Alter Mobile number:</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                        <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter last name" value="">--%>
                                                        <asp:TextBox ID="txtAlterMobile" runat="server" class="form-control m-input" placeholder="Alter Mobile Number"></asp:TextBox>
                                                        <span id="error_txtAlterMobile" class="text-danger small"></span>
                                                      <%--  <asp:RequiredFieldValidator ID="rfvAltermobile" runat="server" ControlToValidate="txtAlteMobile"
                                                        ErrorMessage="Please select Mobile" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>
                                                 <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Landline number:</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                        <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter last name" value="">--%>
                                                        <asp:TextBox ID="TxtLandline" runat="server" class="form-control m-input" placeholder="Landline Mobile Number"></asp:TextBox>
                                                        <span id="error_txtLandlineMobile" class="text-danger small"></span>
                                                      <%--  <asp:RequiredFieldValidator ID="rfvAltermobile" runat="server" ControlToValidate="txtAlteMobile"
                                                        ErrorMessage="Please select Mobile" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                </div>
                                             
                                               
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> User Image</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                       <asp:FileUpload ID="fileUpload_UserImage"  runat="server" />
                                                    </div>
                                                </div>

                                              

                                                <div class="form-group m-form__group row">
                                                    <div class="col-xl-1 col-lg-3 col-form-label">
                                                    <span style="color: red;">*</span><asp:CheckBox ID="chk_IsApproval" OnCheckedChanged="chk_IsApproval_CheckedChanged"  runat="server" style="margin-left: 3px;" />
                                                    </div>
                                                    <label class="col-xl-8 col-lg-3 col-form-label">Check the Box if User is Approval.</label>
                                                   
                                                    <%--OnCheckedChanged="chk_IsApproval_CheckedChanged"--%>

                                                </div>
                                                <div class="form-group m-form__group row">
                                                    <div class="col-xl-1 col-lg-3 col-form-label">
                                                    <span style="color: red;">*</span><asp:CheckBox ID="chk_IsGobalApproval" OnCheckedChanged="chk_IsGobalApproval_CheckedChanged"  runat="server" style="margin-left: 3px;" />
                                                    </div>
                                                    <label class="col-xl-8 col-lg-3 col-form-label">Check the box if User is Gobal Approval.</label>

                                                    <%-- OnCheckedChanged="chk_IsGobalApproval_CheckedChanged"--%>
                                                   
                                                </div>

                                                <div id="dvApprovalID" runat="server" visible="True" >
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Approval ID:</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                        <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter last name" value="">--%>
                                                        <asp:TextBox ID="txtApprovalId" runat="server" class="form-control m-input" placeholder="Enter Approval ID"></asp:TextBox>
                                                        <span id="error_txtApprovalID" class="text-danger small"></span>
                                                    </div>
                                                </div>
                                                
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Username:</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                        <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter last name" value="">--%>
                                                        <asp:TextBox ID="txtUserLogin" runat="server" class="form-control m-input" placeholder="Enter User Login ID"></asp:TextBox>
                                                        <span id="error_txtUserLogin" class="text-danger small"></span>
                                                         <asp:RequiredFieldValidator ID="rfvUserLogin" runat="server" ControlToValidate="txtUserLogin"
                                                        ErrorMessage="Please select User Login" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Password:</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                        <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter last name" value="">--%>
                                                        <asp:TextBox ID="txtPassword" runat="server" class="form-control m-input" placeholder="Enter User Password"></asp:TextBox>
                                                        <span id="error_txtPassword" class="text-danger small"></span>
                                                          <asp:RequiredFieldValidator ID="rfvUserPassword" runat="server" ControlToValidate="txtPassword"
                                                        ErrorMessage="Please select User Password" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                </div>

                                                <div class="form-group m-form__group row">
                                                    <div class="col-xl-9 col-lg-9">
                                                        <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
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

                <!--end::Portlet-->
            </div>
        </div>
    </div>





</asp:Content>
