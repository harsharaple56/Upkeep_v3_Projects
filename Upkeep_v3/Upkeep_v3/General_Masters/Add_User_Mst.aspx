<%@ Page Title="eFacilito | Users" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Add_User_Mst.aspx.cs" Inherits="Upkeep_v3.General_Masters.Add_User_Mst" %>
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
                                            <h3 class="m-portlet__head-text">User Details
                                            </h3>
                                        </div>
                                    </div>

                                    <div class="m-portlet__head-tools">

                                
                                        <a href="<%= Page.ResolveClientUrl("User_Mst.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                            <span>
                                                <i class="la la-arrow-left"></i>
                                                <span>Back</span>
                                            </span>
                                        </a>
                                        <div class="btn-group">

                                            <asp:Button ID="btnSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnSave_Click" Text="Save"  ValidationGroup="ValidateUser" />

                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div class="m-portlet__body">


                                <!--begin: Form Body -->
                                <div class="">
                                    <div class="row">
                                        <div class="col-xl-12">
                                            <div class="m-form__section m-form__section--first">
                                              
                                                 <%-- commented by sujata --%>

                                           <%--         <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Zone:</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                       <asp:DropDownList ID="ddlZone" class="form-control m-input" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged" AutoPostBack="true" runat="server" ></asp:DropDownList>

                                                    </div>
                                                </div>
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Location:</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                       <asp:DropDownList ID="ddlLocation" class="form-control m-input" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged" AutoPostBack="true" runat="server" ></asp:DropDownList>
                                                     

                                                    </div>
                                                </div>
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Sub-Location:</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                       <asp:DropDownList ID="ddlSublocation" class="form-control m-input"  OnSelectedIndexChanged="ddlSublocation_SelectedIndexChanged" AutoPostBack="true" runat="server" ></asp:DropDownList>
                                                      
                                                    </div>
                                                </div>--%>   
                                    <%-- end commented by sujata --%>
                                         
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Department:</label>
                                                    <div class="col-xl-4 col-lg-4">                                                        
                                                        <asp:DropDownList ID="ddlDepartment" class="form-control m-input" runat="server"></asp:DropDownList>
                                                         <asp:RequiredFieldValidator ID="rfvddlDepartment" runat="server" ControlToValidate="ddlDepartment" ValidationGroup="ValidateUser"
                                                        ErrorMessage="Please select Department" InitialValue="0" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </div>

                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> User Designation:</label>
                                                    <div class="col-xl-4 col-lg-4">                                                     
                                                        <asp:TextBox ID="txtUserDesignation" runat="server" class="form-control m-input" placeholder="User Designation"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvUserDesignation" runat="server" ControlToValidate="txtUserDesignation" ValidationGroup="ValidateUser"
                                                        ErrorMessage="Please select User Designation" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                 <div class="form-group m-form__group row" style="display:none;">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span>User Type:</label>
                                                    <div class="col-xl-9 col-lg-9">                                                      
                                                       <asp:DropDownList ID="ddlTypeUser" class="form-control m-input" runat="server" ></asp:DropDownList>                                                     
                                                    </div>
                                                </div>
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> User Code:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="txtUserCode" runat="server" class="form-control m-input" placeholder="User_Code"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvUserCode" runat="server" ControlToValidate="txtUserCode" ValidationGroup="ValidateUser"
                                                        ErrorMessage="Please select User Code" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </div>

                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Role :</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:DropDownList ID="ddlRole" class="form-control m-input" runat="server"></asp:DropDownList>
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidatorddlRole" runat="server" ControlToValidate="ddlRole" ValidationGroup="ValidateUser"
                                                        ErrorMessage="Please select Role" InitialValue="0" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> First Name:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="txtFirstName" runat="server" class="form-control m-input" placeholder="First Name"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" ValidationGroup="ValidateUser"
                                                        ErrorMessage="Please enter First Name" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </div>

                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Last Name:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="txtlastName" runat="server" class="form-control m-input" placeholder="Last Name"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvlastName" runat="server" ControlToValidate="txtlastName" ValidationGroup="ValidateUser"
                                                        ErrorMessage="Please enter Last Name" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                               
                                                 <div class="form-group m-form__group row">
                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> User Email:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="txtuseremail" runat="server" class="form-control m-input" placeholder="User Email"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvUserEmail" runat="server" ControlToValidate="txtUserEmail" ValidationGroup="ValidateUser"
                                                        ErrorMessage="Please enter User Email" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </div>

                                                     <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Mobile Number:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="txtmobile" runat="server" class="form-control m-input" placeholder="Mobile Number"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvmobile" runat="server" ControlToValidate="txtmobile" ValidationGroup="ValidateUser"
                                                        ErrorMessage="Please enter Mobile number" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                <%--<div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> User Designation:</label>
                                                    <div class="col-xl-9 col-lg-9">                                                     
                                                        <asp:TextBox ID="txtUserDesignation" runat="server" class="form-control m-input" placeholder="User_Designation"></asp:TextBox>
                                                        <span id="error_txtUserDesignation" class="text-danger small"></span>
                                                        <asp:RequiredFieldValidator ID="rfvUserDesignation" runat="server" ControlToValidate="txtUserDesignation"
                                                        ErrorMessage="Please select User Designation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>--%>
                                                 
                                                 <div class="form-group m-form__group row">
                                                    <label class="col-xl-2 col-lg-2 col-form-label"> Alter Mobile number:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="txtAlterMobile" runat="server" class="form-control m-input" placeholder="Alter Mobile Number"></asp:TextBox>
                                                    </div>

                                                      <label class="col-xl-2 col-lg-2 col-form-label">Landline number:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="TxtLandline" runat="server" class="form-control m-input" placeholder="Landline Mobile Number"></asp:TextBox>
                                                    </div>
                                                </div>                                              
                                               
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> User Image</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                       <asp:FileUpload ID="fileUpload_UserImage"  runat="server" />
                                                    </div>
                                                </div>                                            

                                                <div class="row">
                                                    <div class="col-lg-9">
                                                    <asp:CheckBox ID="chk_IsApproval" OnCheckedChanged="chk_IsApproval_CheckedChanged"  runat="server" style="margin-left: 3px;" />
                                                        <label class="col-form-label">Check the Box if User is Approval.</label>
                                                    </div>                                             
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-9">
                                                    <asp:CheckBox ID="chk_IsGobalApproval" OnCheckedChanged="chk_IsGobalApproval_CheckedChanged"  runat="server" style="margin-left: 3px;" />
                                                        <label class="col-form-label">Check the box if User is Gobal Approval.</label>
                                                    </div>                                               
                                                </div>

                                                <div id="dvApprovalID" runat="server" visible="True" >
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-2 col-lg-2 col-form-label">Approver :</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:DropDownList ID="ddlApprover" class="form-control m-input" runat="server"></asp:DropDownList>
                                                    </div>
                                                </div>

                                                   <%-- <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Role :</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                        <asp:DropDownList ID="ddlRole" class="form-control m-input" runat="server"></asp:DropDownList>
                                                    </div>
                                                </div>--%>
                                                
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Username:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="txtUserLogin" runat="server" class="form-control m-input" placeholder="Enter User Login ID"></asp:TextBox>
                                                         <asp:RequiredFieldValidator ID="rfvUserLogin" runat="server" ControlToValidate="txtUserLogin" ValidationGroup="ValidateUser"
                                                        ErrorMessage="Please enter User Login" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </div>

                                                     <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Password:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="txtPassword" runat="server" class="form-control m-input" placeholder="Enter User Password"></asp:TextBox>
                                                          <asp:RequiredFieldValidator ID="rfvUserPassword" runat="server" ControlToValidate="txtPassword" ValidationGroup="ValidateUser"
                                                        ErrorMessage="Please enter User Password" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                               

                                                </div>

                                                <div class="form-group m-form__group row">
                                                    <div class="col-xl-9 col-lg-9">
                                                         <asp:Label ID="lblUserErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" style="font-size: large;font-weight: bold;"  ></asp:Label>
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
