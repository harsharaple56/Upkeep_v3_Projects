<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Select_Transaction.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Transactions.Select_Transaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .m-portlet__body 
        {
            height: 6rem;
        }


    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="m-grid__item m-grid__item--fluid">
        <div class="m-content">
            <div class="row">
                <div class="col-xl-6">
                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--skin-dark m-portlet--bordered-semi m--bg-primary">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <span class="m-portlet__head-icon">
                                        <i class="fa fa-dollar-sign" style="font-size: 2.4rem;" aria-hidden="true"></i>
                                    </span>
                                    <h3 class="m-portlet__head-text">Add Sale
                                    </h3>
                                </div>

                            </div>
                            <div class="m-portlet__head-tools">

                                <div class="btn-group">
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Transactions/Sales.aspx") %>" class="btn btn-warning m-btn m-btn--icon m-btn--pill m-btn--air">
                                        <span>
                                            <i class="fa fa-angle-double-right"></i>
                                            <span>Click Here</span>
                                        </span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="m-portlet__body">
                            <div class="m-portlet__body-progress">Loading</div>
                            Add or Import your Liquor Sale Entry for Today. 
                        </div>
                    </div>
                    <!--end::Portlet-->

                </div>
                <div class="col-xl-6">
                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--skin-dark m-portlet--bordered-semi m--bg-primary">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <span class="m-portlet__head-icon">
                                        <i class="fa fa-receipt" style="font-size: 2.4rem;" aria-hidden="true"></i>
                                    </span>
                                    <h3 class="m-portlet__head-text">Auto-Billing
                                    </h3>
                                </div>

                            </div>
                            <div class="m-portlet__head-tools">

                                <div class="btn-group">
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Transactions/Auto_Billing.aspx") %>" class="btn btn-warning m-btn m-btn--icon m-btn--pill m-btn--air">
                                        <span>
                                            <i class="fa fa-angle-double-right"></i>
                                            <span>Click Here</span>
                                        </span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="m-portlet__body">
                            <div class="m-portlet__body-progress">Loading</div>
                           Manually Add your Liquor Sale Entry for Today. Bill Number is generated automatically.
                        </div>
                    </div>
                    <!--end::Portlet-->

                </div>
                <div class="col-xl-6">
                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--skin-dark m-portlet--bordered-semi m--bg-primary">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <span class="m-portlet__head-icon">
                                        <i class="fa fa-shopping-cart" style="font-size: 2.4rem;" aria-hidden="true"></i>
                                    </span>
                                    <h3 class="m-portlet__head-text">Add Purchase
                                    </h3>
                                </div>

                            </div>
                            <div class="m-portlet__head-tools">

                                <div class="btn-group">
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Transactions/Purchases.aspx") %>" class="btn btn-warning m-btn m-btn--icon m-btn--pill m-btn--air">
                                        <span>
                                            <i class="fa fa-angle-double-right"></i>
                                            <span>Click Here</span>
                                        </span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="m-portlet__body">
                            <div class="m-portlet__body-progress">Loading</div>
                            Add or Import your Liquor Purchase Entries 
                        </div>
                    </div>
                    <!--end::Portlet-->

                </div>
                <div class="col-xl-6">
                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--skin-dark m-portlet--bordered-semi m--bg-primary">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <span class="m-portlet__head-icon">
                                        <i class="fa fa-exchange" style="font-size: 2.4rem;" aria-hidden="true"></i>
                                    </span>
                                    <h3 class="m-portlet__head-text">Add Transfer
                                    </h3>
                                </div>

                            </div>
                            <div class="m-portlet__head-tools">

                                <div class="btn-group">
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Transactions/Transfers.aspx") %>" class="btn btn-warning m-btn m-btn--icon m-btn--pill m-btn--air">
                                        <span>
                                            <i class="fa fa-angle-double-right"></i>
                                            <span>Click Here</span>
                                        </span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="m-portlet__body">
                            <div class="m-portlet__body-progress">Loading</div>
                            Transfer your Stock from One Store to Another. Manage all Transfer Records 
                        </div>
                    </div>
                    <!--end::Portlet-->

                </div>

                 <div class="col-xl-6">
                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--skin-dark m-portlet--bordered-semi m--bg-primary">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <span class="m-portlet__head-icon">
                                        <i class="flaticon-refresh" style="font-size: 2.4rem;" aria-hidden="true"></i>
                                    </span>
                                    <h3 class="m-portlet__head-text">Wash Day 
                                    </h3>
                                </div>

                            </div>
                            <div class="m-portlet__head-tools">

                                <div class="btn-group">
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Transactions/Washday.aspx") %>" class="btn btn-warning m-btn m-btn--icon m-btn--pill m-btn--air">
                                        <span>
                                            <i class="fa fa-angle-double-right"></i>
                                            <span>Click Here</span>
                                        </span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="m-portlet__body">
                            <div class="m-portlet__body-progress">Loading</div>
                            Wash your Sale Liquor by selecting Date.
                        </div>
                    </div>
                    <!--end::Portlet-->

                </div>

                  <div class="col-xl-6">
                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--skin-dark m-portlet--bordered-semi m--bg-primary">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <span class="m-portlet__head-icon">
                                        <i class="fa fa-file-import" style="font-size: 2.4rem;" aria-hidden="true"></i>
                                    </span>
                                    <h3 class="m-portlet__head-text">Import Transactions
                                    </h3>
                                </div>

                            </div>
                            <div class="m-portlet__head-tools">

                                <div class="btn-group">
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Transactions/Import_Transactions.aspx") %>" class="btn btn-warning m-btn m-btn--icon m-btn--pill m-btn--air">
                                        <span>
                                            <i class="fa fa-angle-double-right"></i>
                                            <span>Click Here</span>
                                        </span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="m-portlet__body">
                            <div class="m-portlet__body-progress">Loading</div>
                            Import Transactions of Sale, Auto-Billing, Purchase and Transfer in one window. 
                        </div>
                    </div>
                    <!--end::Portlet-->

                </div>
            </div>
        </div>
    </div>
</asp:Content>
