<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Add_Invoices.aspx.cs" Inherits="Upkeep_v3_Control_Center.Invoices.Add_Invoices" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style1 {
            left: 0px;
            top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets1/demo/default/custom/crud/forms/widgets/bootstrap-datetimepicker.js") %>" type="text/javascript"></script>


    <script type="text/javascript">

        $(document).ready(function () {
        $('#lbl_Invoice_CGST').text('Hello, I am Arun Banik');
        });

        $(document).ready(function () {
            //debugger;
            //$.ajax({
            //    type: "GET",
            //    dataType: "jsonp",
            //    url: "http://sms.thebulksms.in/api/mt/GetBalance?User=alembic&Password=alm@123",
            //    success: function (data) {
            //        alert(data);
            //    }
            //});
            //var settings = {
            //    "async": true,
            //    "crossDomain": true,
            //    "url": "http://sms.thebulksms.in/api/mt/GetBalance?User=alembic&Password=alm@123",
            //    "method": "POST",
            //    "headers": {
            //        "cache-control": "no-cache",
            //        "postman-token": "ea4f2d12-fbbc-3cca-76d2-1bd4d17e5323"
            //    }
            //}

            //$.ajax(settings).done(function (response) {
            //    console.log(response);
            //});
        });

        
        var BootstrapTimepicker = {
            init: function () {
                $("#Invoice_Due_Date").datetimepicker(
                    { format: "dd/mm/yyyy", todayHighlight: !0, autoclose: !0, startView: 2, minView: 2, forceParse: 0, pickerPosition: "bottom-left" }
                    //, { minDate: today }
                );
                $('#Invoice_Due_Date').datetimepicker({
                    minDate:new Date()
                });
            }
        };

    </script>


    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <form class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" method="post" runat="server" id="frmCompany">
                        <asp:ScriptManager ID="scrptmgnr" runat="server"></asp:ScriptManager>
                        <div class="m-form m-form--label-align-left- m-form--state-" id="employee_form">
                            <div class="m-portlet__head">
                                <div class="m-portlet__head-progress">

                                    <!-- here can place a progress bar-->
                                </div>
                                <div class="m-portlet__head-wrapper">
                                    <div class="m-portlet__head-caption">
                                        <div class="m-portlet__head-title">
                                            <h3 class="m-portlet__head-text">Invoice details
                                            </h3>
                                        </div>
                                    </div>

                                    <div class="m-portlet__head-tools">
                                        <a href="~/Invoices/Invoices_Listing.aspx" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
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
                                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Invoice Details</label>
                                                </div>

                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Invoice Number :</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="txt_Invoice_No" runat="server" class="form-control m-input" placeholder="Enter Invoice Number"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfv_Invoice_No" runat="server" ControlToValidate="txt_Invoice_No" Display="Dynamic"
                                                            ErrorMessage="Please enter Invoice Number" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>

                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Description:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="txt_Invoice_Desc" runat="server" class="form-control m-input" placeholder="Enter Invoice Description"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfv_Invoice_Desc" runat="server" ControlToValidate="txt_Invoice_Desc" Display="Dynamic"
                                                            ErrorMessage="Please enter Invoice Description" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Invoice Amount :</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="txt_Invoice_Amount" runat="server" TextMode="number" class="form-control m-input" placeholder="Enter Invoice Amount"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfv_Invoice_Amount" runat="server" ControlToValidate="txt_Invoice_Amount" Display="Dynamic"
                                                            ErrorMessage="Enter Invoice Amount" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                     <label class="col-xl-2 col-lg-2 col-form-label">Total Amount :</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:Label ID="lbl_Total_Amount" runat="server" class="form-control m-input"></asp:Label>
                                                    </div>
                                                </div>

                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-2 col-lg-2 col-form-label">CGST :</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:Label ID="lbl_Invoice_CGST" runat="server" class="form-control m-input"></asp:Label>
                                                    </div>
                                                    <label class="col-xl-2 col-lg-2 col-form-label">SGST :</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:Label ID="lbl_Invoice_SGST" runat="server" class="form-control m-input"></asp:Label>
                                                    </div>
                                                </div>

                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span>Select Company:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:DropDownList ID="ddl_Company_Desc" class="form-control m_selectpicker" runat="server"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfv_Company_Desc" runat="server" ControlToValidate="ddl_Company_Desc" InitialValue="0" Display="Dynamic"
                                                            ErrorMessage="Please select Company" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>

                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span>GSTIN</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="Txt_GSTIN" runat="server" TextMode="number" class="form-control m-input" placeholder="Enter Company GSTIN"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfv_GSTIN" runat="server" ControlToValidate="txt_GSTIN" Display="Dynamic"
                                                            ErrorMessage="Enter GSTIN" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                    
                                                </div>
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span>Nature/Type of Invoice:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:DropDownList ID="ddl_Nature_of_Invoice" class="form-control m_selectpicker" runat="server">
                                                            <asp:ListItem Value="">--Select--</asp:ListItem>  
                                                            <asp:ListItem>Subscription</asp:ListItem>  
                                                            <asp:ListItem>AMC</asp:ListItem>  
                                                            <asp:ListItem>License</asp:ListItem> 
                                                    </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfv_Nature_of_Invoice" runat="server" ControlToValidate="ddl_Nature_of_Invoice" InitialValue="0" Display="Static"
                                                            ErrorMessage="Please select Nature of Invoice" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>


                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Upload Invoice</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:FileUpload ID="fileUpload_Invoice" runat="server" />
                                                    </div>
                                                </div>

                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-2 col-lg-2 col-form-label">Select Due Date:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <div class="input-group date">
                                                            <%--<asp:TextBox ID="ActivationDate" runat="server" AutoCompleteType="Disabled" class="form-control m-input datetimepicker" OnTextChanged="ActivationDate_TextChanged" AutoPostBack="true" placeholder="Select activation date"></asp:TextBox>
                                                            <div class="input-group-append">
                                                                <span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
                                                            </div>--%>
                                                            <asp:TextBox ID="Invoice_Due_Date" runat="server" ClientIDMode="Static" autocomplete="off" class="form-control m-input datetimepicker m-portlet__nav-link m-dropdown__toggle dropdown-toggle btn btn--sm btn-secondary m-btn m-btn--label-primary"
                                                                OnTextChanged="Invoice_Due_Date_TextChanged" AutoPostBack="true" placeholder="Select Invoice Due Date"></asp:TextBox>

                                                            <div class="input-group-append">
                                                                <span class="input-group-text">
                                                                    <i class="la la-calendar glyphicon-th"></i>
                                                                </span>
                                                            </div>
                                                        </div>
                                                        <span id="error_Invoice_Due_Date" class="text-danger small"></span>
                                                        <asp:Label ID="lbl_Invoice_Due_Date" runat="server" ForeColor="Red" Visible="false" Font-Bold="true">Due Date cannot be Less than Current Date</asp:Label>
                                                    </div>

                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span>Billing Name</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="txt_Billing_Name" runat="server" TextMode="number" class="form-control m-input" placeholder="Enter Company Billing Name"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfv_Billing_Name" runat="server" ControlToValidate="txt_Billing_Name" Display="Dynamic"
                                                            ErrorMessage="Enter Billing Name" ForeColor="Red"></asp:RequiredFieldValidator>
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
                    </form>
                </div>

                <!--end::Portlet-->
            </div>
        </div>
    </div>


</asp:Content>
