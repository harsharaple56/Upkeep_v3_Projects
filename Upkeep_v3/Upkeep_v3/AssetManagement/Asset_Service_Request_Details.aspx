<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Asset_Service_Request_Details.aspx.cs" Inherits="Upkeep_v3.AssetManagement.Asset_Service_Request_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                                        <h3 class="m-portlet__head-text">Service Request Details
                                        </h3>
                                    </div>
                                </div>

                                <div class="m-portlet__head-tools">


                                    <a href="<%= Page.ResolveClientUrl("~/AssetManagement/AssetManagementServiceCloseList.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                        <span>
                                            <i class="la la-arrow-left"></i>
                                            <span>Back</span>
                                        </span>
                                    </a>
                                </div>

                            </div>
                        </div>



                        <!--begin: Form Body -->
                        <div class="m-form m-form--fit m-form--group-seperator-dashed">
                            <div class="row">
                                <div class="col-xl-12">
                                    <div class="m-form__section m-form__section--first">

                                        <div class="form-group m-form__group row">

                                            <label class="col-xl-2 col-lg-2 col-form-label"><b>Service Request ID:</b></label>
                                            <label class="col-xl-1 col-lg-2 col-form-label" style="text-align: left">23</label>


                                            <label class="col-xl-3 col-lg-2 col-form-label">
                                                <b>Current Status:
                                                        <span class="m-badge m-badge--danger m-badge--wide">Open</span>

                                                </b>

                                            </label>

                                            <label class="col-xl-2 col-lg-2 col-form-label" ><b>Created By:</b></label>
                                            <label class="col-xl-4 col-lg-2 col-form-label" style="text-align: left">Lokesh Devasani on 23 April 2021</label>


                                        </div>
                                        <div class="form-group m-form__group row">

                                            <label class="col-xl-3 col-lg-2 col-form-label"><b>Scheduled Service Date:</b></label>
                                            <label class="col-xl-3 col-lg-2 col-form-label" style="text-align: left">29th April 2021</label>


                                            <label class="col-xl-2 col-lg-2 col-form-label"><b>Assigned To:</b></label>
                                            <label class="col-xl-3 col-lg-2 col-form-label" style="text-align: left">Ajay Prajapati</label>


                                        </div>

                                        <div class="form-group m-form__group row">

                                            <label class="col-xl-1 col-lg-2 col-form-label"><b>Asset ID:</b></label>
                                            <label class="col-xl-2 col-lg-2 col-form-label" style="text-align: left">23</label>


                                            <label class=" col-form-label"><b>Asset Name:</b></label>
                                            <label class="col-xl-3 col-lg-2 col-form-label" style="text-align: left">Cooling Pump 4</label>

                                            <div class="col-xl-3 col-lg-2">
                                                <a href="Department_Transactions.aspx" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                                                    <span>
                                                        <i class="la la-backward"></i>
                                                        <span>View Asset Details</span>
                                                    </span>
                                                </a>
                                            </div>



                                        </div>

                                        <div class="form-group m-form__group row">

                                            <label class="col-xl-3 col-lg-2 col-form-label"><b>Service Closed Date:</b></label>
                                            <label class="col-xl-3 col-lg-2 col-form-label" style="text-align: left">29th April 2021</label>


                                            <label class="col-xl-2 col-lg-2 col-form-label"><b>Closed By:</b></label>
                                            <label class="col-xl-3 col-lg-2 col-form-label" style="text-align: left">Ajay Prajapati</label>


                                        </div>

                                        <div class="form-group m-form__group row">
                                            <label class="col-xl-3 col-lg-2 col-form-label"><span style="color: red;">*</span><b> Enter Request Closing Remarks:</b></label>
                                            <div class="col-xl-9 col-lg-4">
                                                <asp:TextBox ID="txtClosing_Remarks" runat="server" class="form-control m-input" placeholder="Enter a Unique Vendor Registration Code "></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group m-form__group row">
                                            <div class="col-xl-12 col-lg-2" style="text-align: center;">
                                                <a href="#" class="btn btn-success m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                                    <span>
                                                        <i class="la la-arrow-left"></i>
                                                        <span>Close Service Request</span>
                                                    </span>
                                                </a>
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

</asp:Content>
