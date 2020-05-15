<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Add_SubPack.aspx.cs" Inherits="Upkeep_v3_Control_Center.Masters.Add_SubPack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <div class="m-form m-form--label-align-left- m-form--state-" id="employee_form">
                            <div class="m-portlet__head">
                                <div class="m-portlet__head-progress">

                                    <!-- here can place a progress bar-->
                                </div>
                                <div class="m-portlet__head-wrapper">
                                    <div class="m-portlet__head-caption">
                                        <div class="m-portlet__head-title">
                                            <h3 class="m-portlet__head-text">Subscription Package details
                                            </h3>
                                        </div>
                                    </div>

                                    <div class="m-portlet__head-tools">
                                        <a href="EmployeeListing.aspx" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
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
                                                <%--<div class="m-form__heading">
                                                                                                                                <h3 class="m-form__heading-title">Employee details</h3>
                                                                                                                        </div>--%>

                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label">* Subscription Package :</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                        <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter last name" value="">--%>
                                                        <asp:TextBox ID="txtSubscriptionPackage" runat="server" class="form-control m-input" placeholder="Enter Subscription Package"></asp:TextBox>
                                                        <span id="txtSubscriptionPckg" class="text-danger small"></span>
                                                    </div>
                                                </div>
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label">* No Of Days :</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                        <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter last name" value="">--%>
                                                        <asp:TextBox ID="txtNoOfDays" runat="server" class="form-control m-input" placeholder="Enter No Of Days"></asp:TextBox>
                                                        <span id="txtDays" class="text-danger small"></span>
                                                    </div>
                                                </div>
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label">* Price :</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                        <%--<input type="text" name="name" class="form-control m-input" placeholder="Enter last name" value="">--%>
                                                        <asp:TextBox ID="txtPackPrice" runat="server" class="form-control m-input" placeholder="Enter Price"></asp:TextBox>
                                                        <span id="txtpckPrc" class="text-danger small"></span>
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
