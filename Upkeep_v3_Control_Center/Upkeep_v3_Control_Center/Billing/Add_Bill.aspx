<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Add_Bill.aspx.cs" Inherits="Upkeep_v3_Control_Center.Billing.Add_Bill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">
        <script type="text/javascript">
            //<![CDATA[
            Sys.WebForms.PageRequestManager._initialize('ctl00$ContentPlaceHolder1$ctl00', 'ctl03', ['tctl00$ContentPlaceHolder1$updt', 'ContentPlaceHolder1_updt'], [], [], 90, 'ctl00');
//]]>
        </script>



        <div class="m-portlet__head" style="">
            <div class="m-portlet__head-progress">
            </div>
            <div class="m-portlet__head-wrapper">
                <div class="m-portlet__head-caption">
                    <div class="m-portlet__head-title">
                        <h3 class="m-portlet__head-text">User Details
                        </h3>
                    </div>
                </div>

                <div class="m-portlet__head-tools">


                    <a href="User_Mst.aspx" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                        <span>
                            <i class="la la-arrow-left"></i>
                            <span>Back</span>
                        </span>
                    </a>
                    <div class="btn-group">

                        <input type="submit" name="ctl00$ContentPlaceHolder1$btnSave" value="Save" onclick="javascript: WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions(& quot; ctl00$ContentPlaceHolder1$btnSave & quot;, & quot;& quot;, true, & quot; ValidateUser & quot;, & quot;& quot;, false, false))" id="ContentPlaceHolder1_btnSave" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md">
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
                            
                            <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Invoice Number:</label>
                            <div class="col-xl-4 col-lg-4">
                                <input name="ctl00$ContentPlaceHolder1$txtInvoiceNumber" type="text" id="ContentPlaceHolder1_txtInvoiceNumber" class="form-control m-input" placeholder="Enter Invoice Number">
                                <span id="ContentPlaceHolder1_rfvInvoiceNumber" style="color: Red; display: none;">Please enter Invoice Number</span>
                            </div>
                            
                            <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Payment Mode:</label>
                            <div class="col-xl-4 col-lg-4">
                                <select name="ctl00$ContentPlaceHolder1$PaymentMode" id="ContentPlaceHolder1_PaymentMode" class="form-control m-input">
                                    <option value="0">--Select--</option>
                                    <option value="1">Online</option>
                                    <option value="2">Cash</option>
                                    <option value="3">Cheque</option>
                                </select>
                                <span id="ContentPlaceHolder1_rfvPaymentMode" style="color: Red; display: none;">Please Payment Mode</span>
                            </div>

                        </div>
                        <div class="form-group m-form__group row">
                            
                            <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Invoice Number:</label>
                            <div class="col-xl-4 col-lg-4">
                                <input name="ctl00$ContentPlaceHolder1$txtInvoiceNumber" type="text" id="ContentPlaceHolder1_txtInvoiceNumber" class="form-control m-input" placeholder="Enter Invoice Number">
                                <span id="ContentPlaceHolder1_rfvInvoiceNumber" style="color: Red; display: none;">Please enter Invoice Number</span>
                            </div>
                            
                            <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Payment Mode:</label>
                            <div class="col-xl-4 col-lg-4">
                                <select name="ctl00$ContentPlaceHolder1$PaymentMode" id="ContentPlaceHolder1_PaymentMode" class="form-control m-input">
                                    <option value="0">--Select--</option>
                                    <option value="1">Online</option>
                                    <option value="2">Cash</option>
                                    <option value="3">Cheque</option>
                                </select>
                                <span id="ContentPlaceHolder1_rfvPaymentMode" style="color: Red; display: none;">Please Payment Mode</span>
                            </div>

                        </div>
                        <div class="form-group m-form__group row">
                            
                            <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Invoice Number:</label>
                            <div class="col-xl-4 col-lg-4">
                                <input name="ctl00$ContentPlaceHolder1$txtInvoiceNumber" type="text" id="ContentPlaceHolder1_txtInvoiceNumber" class="form-control m-input" placeholder="Enter Invoice Number">
                                <span id="ContentPlaceHolder1_rfvInvoiceNumber" style="color: Red; display: none;">Please enter Invoice Number</span>
                            </div>
                            
                            <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Payment Mode:</label>
                            <div class="col-xl-4 col-lg-4">
                                <select name="ctl00$ContentPlaceHolder1$PaymentMode" id="ContentPlaceHolder1_PaymentMode" class="form-control m-input">
                                    <option value="0">--Select--</option>
                                    <option value="1">Online</option>
                                    <option value="2">Cash</option>
                                    <option value="3">Cheque</option>
                                </select>
                                <span id="ContentPlaceHolder1_rfvPaymentMode" style="color: Red; display: none;">Please Payment Mode</span>
                            </div>

                        </div>
                        <div class="form-group m-form__group row">
                            
                            <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Invoice Number:</label>
                            <div class="col-xl-4 col-lg-4">
                                <input name="ctl00$ContentPlaceHolder1$txtInvoiceNumber" type="text" id="ContentPlaceHolder1_txtInvoiceNumber" class="form-control m-input" placeholder="Enter Invoice Number">
                                <span id="ContentPlaceHolder1_rfvInvoiceNumber" style="color: Red; display: none;">Please enter Invoice Number</span>
                            </div>
                            
                            <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Payment Mode:</label>
                            <div class="col-xl-4 col-lg-4">
                                <select name="ctl00$ContentPlaceHolder1$PaymentMode" id="ContentPlaceHolder1_PaymentMode" class="form-control m-input">
                                    <option value="0">--Select--</option>
                                    <option value="1">Online</option>
                                    <option value="2">Cash</option>
                                    <option value="3">Cheque</option>
                                </select>
                                <span id="ContentPlaceHolder1_rfvPaymentMode" style="color: Red; display: none;">Please Payment Mode</span>
                            </div>

                        </div>

                        

                    </div>

                </div>
            </div>
        </div>


    </div>

</asp:Content>
