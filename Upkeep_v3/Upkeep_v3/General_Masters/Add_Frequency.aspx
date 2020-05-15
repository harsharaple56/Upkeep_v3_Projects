<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Add_Frequency.aspx.cs" Inherits="Upkeep_v3.General_Masters.Add_Frequency" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <html xmlns="http://www.w3.org/1999/xhtml">
    <body>

     <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" runat="server" id="frmFrequency" >

                        <div class="m-form m-form--label-align-left- m-form--state-" id="employee_form">
                            <div class="m-portlet__head">
                                <div class="m-portlet__head-progress">

                                    <!-- here can place a progress bar-->
                                </div>
                                <div class="m-portlet__head-wrapper">
                                    <div class="m-portlet__head-caption">
                                        <div class="m-portlet__head-title">
                                            <h3 class="m-portlet__head-text">Frequency
                                            </h3>
                                        </div>
                                    </div>

                                    <div class="m-portlet__head-tools">
                                        <a href="<%= Page.ResolveClientUrl("Frequency_Master.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                            <span>
                                                <i class="la la-arrow-left"></i>
                                                <span>Back</span>
                                            </span>
                                        </a>
                                        <div class="btn-group">


                                            <asp:Button ID="btnFrequencySave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnFrequencySave_Click" Text="Save" ValidationGroup="validationfreq" />

                                        </div>
                                    </div>


                                </div>
                            </div>
                            <div class="m-portlet__body">


                                <!--begin: Form Body -->
                                <div class="m-portlet__body">
                                    <div class="row">

                                        <div class="col-xl-12 offset-xl-2">
                                        <div class="form-group m-form__group row" id="dvHeaderButton" runat="server" visible="false">
                                                   
                                                </div>
                                            </div>
                                        

                                        <div class="col-xl-8 offset-xl-2" style="margin-top: 25px;">
                                            <div class="m-form__section m-form__section--first">

                                            
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-4 col-lg-3 col-form-label">* Frequency Desc:</label>
                                                    <div class="col-xl-8 col-lg-8">
                                                       <asp:TextBox ID="txtFrequencyDesc" runat="server" class="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvtxtFrequencyDesc" runat="server" ControlToValidate="txtFrequencyDesc" Visible="true" ValidationGroup="validationfreq" ForeColor="Red" ErrorMessage="Please enter Frequency"></asp:RequiredFieldValidator>
                                                       
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

                        <!--end::Portlet-->
                    </div>
                </div>
            </div>
        </div>
    </div>

         </body>
    </html>
</asp:Content>
