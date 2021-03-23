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
    <%-- <script src="<%= Page.ResolveClientUrl("~/assets/vendors/custom/fullcalendar/fullcalendar.bundle.js") %>" type="text/javascript"></script>--%>
    <script src="<%= Page.ResolveClientUrl("~/assets1/demo/default/custom/crud/forms/widgets/bootstrap-datetimepicker.js") %>" type="text/javascript"></script>

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

    <script>
        //function init_autosize() {
        //    var autosize_textarea = $('.autosize_textarea');
        //    autosize(autosize_textarea);
        //    autosize.update(autosize_textarea);
        //}

        $(document).ready(function () {
            //init_autosize();
            //init_plugins();
            BootstrapTimepicker2.init()
            BootstrapTimepicker.init()

            //$('.datetimepicker').datetimepicker({
            //    todayHighlight: true,
            //    autoclose: true,
            //    pickerPosition: 'bottom-right',
            //    format: 'dd/mm/yyyy',
            //    //showMeridian: true,
            //   // ActivationDate: moment().format('YYYY-MM-DD'),
            //}).on('changeDate', function (event) {
            //    var ActivationDate = moment($('#ActivationDate').val(), 'DD/MM/YYYY').valueOf();
            //    //alert(ActivationDate.val);
            //    //var endDate = moment($('#endDate').val(), 'DD/MM/YYYY hh:mm A').valueOf();
            //    //$('#error_endDate').html('').parents('.form-group').removeClass('has-error');
            //    //if (endDate < startDate) {
            //    //    $('#error_endDate').html('Event end date-time can not be before the start date.').parents('.form-group').addClass('has-error');
            //    //}
            //});

            //$('.datetimepicker').on('click', function () {

            //    if ($(this).is('#ActivationDate')) {
            //        //$('#endDate').datetimepicker('hide');
            //    }
            //    //if ($(this).is('#endDate')) {
            //    //    $('#startDate').datetimepicker('hide');
            //    //}
            //});



        });

       var BootstrapTimepicker2 = {
            init: function () {
                $("#txt_Invoice_Date").datetimepicker(
                    { format: "dd/mm/yyyy", todayHighlight: !0, autoclose: !0, startView: 2, minView: 2, forceParse: 0, pickerPosition: "bottom-left" }
                    //, { minDate: today }
                );
                $('#txt_Invoice_Date').datetimepicker({
                    minDate:new Date()
                });
            }
        };

        var BootstrapTimepicker = {
            init: function () {
                $("#txt_Invoice_Due_Date").datetimepicker(
                    { format: "dd/mm/yyyy", todayHighlight: !0, autoclose: !0, startView: 2, minView: 2, forceParse: 0, pickerPosition: "bottom-left" }
                    //, { minDate: today }
                );
                $('#txt_Invoice_Due_Date').datetimepicker({
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
                                        <a href="/Invoices/Invoices_Listing.aspx" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
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
                                                    <label class="col-xl-2 col-lg-2 col-form-label">Select Invoice Date:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <div class="input-group date">
                                                            <asp:TextBox ID="txt_Invoice_Date" runat="server" ClientIDMode="Static" autocomplete="off" class="form-control m-input datetimepicker m-portlet__nav-link m-dropdown__toggle dropdown-toggle btn btn--sm btn-secondary m-btn m-btn--label-primary"
                                                                OnTextChanged="Invoice_Date_TextChanged" AutoPostBack="false" placeholder="Select Invoice Date"></asp:TextBox>

                                                            <div class="input-group-append">
                                                                <span class="input-group-text">
                                                                    <i class="la la-calendar glyphicon-th"></i>
                                                                </span>
                                                            </div>
                                                        </div>
                                                        <span id="error_Invoice_Date" class="text-danger small"></span>
                                                        <asp:Label ID="lbl_Invoice_Date" runat="server" ForeColor="Red" Visible="false" Font-Bold="true">Invoice Date cannot be more than Current Date</asp:Label>
                                                    </div>
                                                     <label class="col-xl-2 col-lg-2 col-form-label">Select Due Date:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <div class="input-group date">
                                                            <asp:TextBox ID="txt_Invoice_Due_Date" runat="server" ClientIDMode="Static" autocomplete="off" class="form-control m-input datetimepicker m-portlet__nav-link m-dropdown__toggle dropdown-toggle btn btn--sm btn-secondary m-btn m-btn--label-primary"
                                                                OnTextChanged="Invoice_Due_Date_TextChanged" AutoPostBack="false" placeholder="Select Invoice Due Date"></asp:TextBox>

                                                            <div class="input-group-append">
                                                                <span class="input-group-text">
                                                                    <i class="la la-calendar glyphicon-th"></i>
                                                                </span>
                                                            </div>
                                                        </div>
                                                        <span id="error_Invoice_Due_Date" class="text-danger small"></span>
                                                        <asp:Label ID="Label1" runat="server" ForeColor="Red" Visible="false" Font-Bold="true">Due Date cannot be Less than Current Date</asp:Label>
                                                    </div>
                                                </div>


                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Invoice Amount :</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="txt_Invoice_Amount" runat="server" TextMode="number" class="form-control m-input" placeholder="Enter Invoice Amount"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfv_Invoice_Amount" runat="server" ControlToValidate="txt_Invoice_Amount" Display="Dynamic"
                                                            ErrorMessage="Enter Invoice Amount" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                     <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span>Select GST Type:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:DropDownList ID="ddl_GST_Type" class="form-control m_selectpicker" runat="server">
                                                            <asp:ListItem Value="">--Select--</asp:ListItem>  
                                                            <asp:ListItem>CGST+SGST</asp:ListItem>  
                                                            <asp:ListItem>IGST</asp:ListItem>  
                                                    </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_Nature_of_Invoice" InitialValue="0" Display="Static"
                                                            ErrorMessage="Please select Nature of Invoice" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                <div class="form-group m-form__group row">
                                                    
                                                    
                                                    <label class="col-xl-2 col-lg-2 col-form-label">GST :</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:Label ID="lbl_Invoice_GST" runat="server" class="form-control m-input"></asp:Label>
                                                    </div>

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


                                                </div>

                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span>Select Company:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:DropDownList ID="ddl_Company_Desc" class="form-control m_selectpicker" runat="server"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfv_Company_Desc" runat="server" ControlToValidate="ddl_Company_Desc" InitialValue="0" Display="Dynamic"
                                                            ErrorMessage="Please select Company" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>

                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span>Billing Name:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="txt_Billing_Name" runat="server" class="form-control m-input" placeholder="Enter Company Billing Name"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfv_Billing_Name" runat="server" ControlToValidate="txt_Billing_Name" Display="Dynamic"
                                                            ErrorMessage="Enter Billing Name" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>

                                                </div>
                                                
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span>GSTIN</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="Txt_GSTIN" runat="server"  class="form-control m-input" placeholder="Enter Company GSTIN"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfv_GSTIN" runat="server" ControlToValidate="txt_GSTIN" Display="Dynamic"
                                                            ErrorMessage="Enter GSTIN" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>

                                                    
                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Upload Invoice:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:FileUpload ID="fileUpload_Invoice" runat="server" />
                                                    </div>
                                                    
                                                </div>

                                                <div class="form-group m-form__group row" id="dvStatus" runat="server">
                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span>Status:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:DropDownList ID="ddlStatus" class="form-control m_selectpicker" runat="server">
                                                            <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                                                            <asp:ListItem Text="Cleared" Value="Cleared"></asp:ListItem>
                                                        </asp:DropDownList>
                                                       
                                                    </div>

                                                    <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span>Transaction Details:</label>
                                                    <div class="col-xl-4 col-lg-4">
                                                        <asp:TextBox ID="txtTransaction_Details" runat="server" class="form-control m-input" placeholder="Enter Transaction Details"></asp:TextBox>
                                                      <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_Billing_Name" Display="Dynamic"
                                                            ErrorMessage="Enter Billing Name" ForeColor="Red"></asp:RequiredFieldValidator>--%>
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
