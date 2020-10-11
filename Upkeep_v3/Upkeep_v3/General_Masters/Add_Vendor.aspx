<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Add_Vendor.aspx.cs" Inherits="Upkeep_v3.General_Masters.Add_Vendor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>
	    Vendor Details
    </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">



                        <div class="m-portlet__head">
                            <div class="m-portlet__head-progress">
                            </div>
                            <div class="m-portlet__head-wrapper">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">Vendor Details
                                        </h3>
                                    </div>
                                </div>

                                <div class="m-portlet__head-tools">


                                    <a href="<%= Page.ResolveClientUrl("Vendor_Mst.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                        <span>
                                            <i class="la la-arrow-left"></i>
                                            <span>Back</span>
                                        </span>
                                    </a>
                                    <div class="btn-group">

                                        <asp:Button ID="btnSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnSave_Click" Text="Save" ValidationGroup="ValidateUser" />

                                    </div>
                                </div>

                            </div>
                        </div>



                        <!--begin: Form Body -->
                        <div class="m-form m-form--fit m-form--group-seperator-dashed">
                            <div class="row">
                                <div class="col-xl-12">
                                    <div class="m-form__section m-form__section--first">

                                        <div class="form-group m-form__group row">
                                            
                                            <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Vendor Name:</label>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:TextBox ID="txtVendorName" runat="server" class="form-control m-input" placeholder="Enter Vendor Company Name"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfVendorName" runat="server" ControlToValidate="txtVendorName" ValidationGroup="ValidateUser"
                                                    ErrorMessage="Please enter Vendor Name" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                            
                                            <label class="col-xl-2 col-lg-2 col-form-label"> Vendor Description:</label>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:TextBox ID="txtVendorDesc" runat="server" class="form-control m-input" placeholder="Enter Details of Vendor Specialization"></asp:TextBox>
                                                
                                            </div>
                                        </div>
                                        <div class="form-group m-form__group row">
                                            
                                            <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span>Contact No.:</label>
                                            <div class="col-xl-4 col-lg-4">

                                                <asp:TextBox ID="txtPrimaryContact" runat="server" class="form-control m-input" placeholder="Enter Vendor Primary Contact No."></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPrimaryContact" ValidationGroup="ValidateUser"
                                                    ErrorMessage="Please enter Vendor Contact No." ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                
                                            </div>
                                            
                                            <label class="col-xl-2 col-lg-2 col-form-label">Alternative Contact:</label>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:TextBox ID="txtAlternateContact" runat="server" class="form-control m-input" placeholder="Enter Vendor Alternative Contact No."></asp:TextBox>
                                                
                                            </div>
                                        </div>
                                        <div class="form-group m-form__group row">
                                            
                                            <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span>Email.:</label>
                                            <div class="col-xl-4 col-lg-4">

                                                <asp:TextBox ID="txtEmail" runat="server" class="form-control m-input" placeholder="Enter Vendor Email ID"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rvVendorEmail" runat="server" ControlToValidate="txtEmail" ValidationGroup="ValidateUser"
                                                    ErrorMessage="Please enter Vendor Email ID" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
     
                                            </div>
                                            
                                            <label class="col-xl-2 col-lg-2 col-form-label">Vendor Address:</label>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:TextBox ID="txtAddress" runat="server" class="form-control m-input" placeholder="Enter Vendor Address."></asp:TextBox>
                                                
                                            </div>
                                        </div>
                                        <div class="form-group m-form__group row">
                                            
                                            <label class="col-xl-2 col-lg-2 col-form-label">GSTIN Number:</label>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:TextBox ID="txtGSTIN" runat="server" class="form-control m-input" placeholder="Enter Vendor GSTIN Number."></asp:TextBox>
                                            </div>
                                            
                                            <label class="col-xl-2 col-lg-2 col-form-label">PAN Number:</label>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:TextBox ID="txtPAN" runat="server" class="form-control m-input" placeholder="Enter Vendor PAN Number."></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group m-form__group row">
                                            
                                            <label class="col-xl-2 col-lg-2 col-form-label">Vendor Bank Details:</label>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:TextBox ID="txtBankDetails" runat="server" class="form-control m-input" placeholder="Enter Vendor Bank Details."></asp:TextBox>
                                            </div>
                                        </div>


                                        
                                        <div class="form-group m-form__group row">
                                            <div class="col-xl-9 col-lg-9">
                                                <asp:Label ID="lblUserErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
                                                <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
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


    <div aria-hidden="true" aria-labelledby="exampleModalLabel" class="modal fade" id="exampleModal" role="dialog" tabindex="-1">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel1">Uploaded Image
                    </h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button">
                        <span aria-hidden="true">×
                        </span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="carousel slide" data-ride="carousel" id="carouselExampleControls">
                        <div class="carousel-inner">
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>





</asp:Content>
