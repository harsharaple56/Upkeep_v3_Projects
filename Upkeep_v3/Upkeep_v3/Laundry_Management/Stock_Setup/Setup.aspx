<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="Upkeep_v3.Laundry_Management.Stock.Setup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">


        <div class="col-lg-4">

            <!--begin::Portlet-->
            <div class="m-portlet">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <span class="m-portlet__head-icon">
                                <i class="fa fa-sitemap" style="font-size: 2.4rem;"></i>
                            </span>
                            <h3 class="m-portlet__head-text">Item Categories
                            </h3>
                        </div>
                    </div>
                </div>
                <div class="m-portlet__body" style="padding: 1.2rem 1.2rem;">
                    <div class="m-scrollable m-scroller ps ps--active-y" data-scrollable="true" data-height="70" data-scrollbar-shown="true" style="height: 30px; font-size: 11px;">
                        Categorize your Laundry Items
                        <br />
                        <br />

                        Create , View , Update & Delete Item Categories. 
										<div class="ps__rail-x" style="left: 0px; bottom: 0px;">
                                            <div class="ps__thumb-x" tabindex="0" style="left: 0px; width: 0px;"></div>
                                        </div>
                        <div class="ps__rail-y" style="top: 0px; height: 200px; right: 4px;">
                            <div class="ps__thumb-y" tabindex="0" style="top: 0px; height: 94px;"></div>
                        </div>
                    </div>
                </div>
                <div class="m-portlet__foot" style="padding: 1.1rem 1.1rem;">
                    <div class="row align-items-center">
                        <div class="col-lg-4">
                            <a href="<%= Page.ResolveClientUrl("~/Laundry_Management/Stock_Setup/Item_Categories.aspx") %>" class="btn btn-success">Click Here</a>
                        </div>
                    </div>
                </div>
            </div>
            <!--end::Portlet-->

        </div>

        <div class="col-lg-4">

            <!--begin::Portlet-->
            <div class="m-portlet">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <span class="m-portlet__head-icon">
                                <i class="fa fa-sitemap" style="font-size: 2.4rem;"></i>
                            </span>
                            <h3 class="m-portlet__head-text">Item Sub-Categories
                            </h3>
                        </div>
                    </div>
                </div>
                <div class="m-portlet__body" style="padding: 1.2rem 1.2rem;">
                    <div class="m-scrollable m-scroller ps ps--active-y" data-scrollable="true" data-height="70" data-scrollbar-shown="true" style="height: 30px; font-size: 11px;">
                        Sub-Categories are used to further drill down your Item Categories
                        <br />
                        <br />

                        Create , View , Update & Delete Item Sub-Categories. 
										<div class="ps__rail-x" style="left: 0px; bottom: 0px;">
                                            <div class="ps__thumb-x" tabindex="0" style="left: 0px; width: 0px;"></div>
                                        </div>
                        <div class="ps__rail-y" style="top: 0px; height: 200px; right: 4px;">
                            <div class="ps__thumb-y" tabindex="0" style="top: 0px; height: 94px;"></div>
                        </div>
                    </div>
                </div>
                <div class="m-portlet__foot" style="padding: 1.1rem 1.1rem;">
                    <div class="row align-items-center">
                        <div class="col-lg-4">
                            <a href="<%= Page.ResolveClientUrl("~/Laundry_Management/Stock_Setup/Item_SubCategories.aspx") %>" class="btn btn-success">Click Here</a>
                        </div>
                    </div>
                </div>
            </div>
            <!--end::Portlet-->

        </div>

        <div class="col-lg-4">

            <!--begin::Portlet-->
            <div class="m-portlet">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <span class="m-portlet__head-icon">
                                <i class="fa fa-tshirt" style="font-size: 2.4rem;"></i>
                            </span>
                            <h3 class="m-portlet__head-text">Laundry Items
                            </h3>
                        </div>
                    </div>
                </div>
                <div class="m-portlet__body" style="padding: 1.2rem 1.2rem;">
                    <div class="m-scrollable m-scroller ps ps--active-y" data-scrollable="true" data-height="70" data-scrollbar-shown="true" style="height: 30px; font-size: 11px;">
                        Create Different Items & Assigned Different Categories & Sub-Categories for ease of Management
                        <br />
                        <br />

                        Create , View , Update & Delete Items
										<div class="ps__rail-x" style="left: 0px; bottom: 0px;">
                                            <div class="ps__thumb-x" tabindex="0" style="left: 0px; width: 0px;"></div>
                                        </div>
                        <div class="ps__rail-y" style="top: 0px; height: 200px; right: 4px;">
                            <div class="ps__thumb-y" tabindex="0" style="top: 0px; height: 94px;"></div>
                        </div>
                    </div>
                </div>
                <div class="m-portlet__foot" style="padding: 1.1rem 1.1rem;">
                    <div class="row align-items-center">
                        <div class="col-lg-4">
                            <a href="<%= Page.ResolveClientUrl("~/Laundry_Management/Stock_Setup/Items_Details.aspx") %>" class="btn btn-success">Click Here</a>
                        </div>
                    </div>
                </div>
            </div>
            <!--end::Portlet-->

        </div>


    </div>

    <div class="row">

        <div class="col-lg-4">

            <!--begin::Portlet-->
            <div class="m-portlet">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <span class="m-portlet__head-icon">
                                <i class="fa fa-stack-overflow" style="font-size: 2.4rem;"></i>
                            </span>
                            <h3 class="m-portlet__head-text">Laundry Stock Details
                            </h3>
                        </div>
                    </div>
                </div>
                <div class="m-portlet__body" style="padding: 1.2rem 1.2rem;">
                    <div class="m-scrollable m-scroller ps ps--active-y" data-scrollable="true" data-height="80" data-scrollbar-shown="true" style="height: 30px; font-size: 11px;">
                        Define Opening Stock, Optimum , Re-Order, Base Values for your Items
                        <br />
                        <br />
                        Once the Opening Stock is defined, the Items will be available for transactions.
                         
										<div class="ps__rail-x" style="left: 0px; bottom: 0px;">
                                            <div class="ps__thumb-x" tabindex="0" style="left: 0px; width: 0px;"></div>
                                        </div>
                        <div class="ps__rail-y" style="top: 0px; height: 200px; right: 4px;">
                            <div class="ps__thumb-y" tabindex="0" style="top: 0px; height: 94px;"></div>
                        </div>
                    </div>
                </div>
                <div class="m-portlet__foot" style="padding: 1.1rem 1.1rem;">
                    <div class="row align-items-center">
                        <div class="col-lg-4">
                            <a href="<%= Page.ResolveClientUrl("~/Laundry_Management/Stock_Setup/Stock_Details.aspx") %>" class="btn btn-success">Click Here</a>
                        </div>
                    </div>
                </div>
            </div>
            <!--end::Portlet-->

        </div>

        <div class="col-lg-4">

            <!--begin::Portlet-->
            <div class="m-portlet">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <span class="m-portlet__head-icon">
                                <i class="fa fa-money-check-alt" style="font-size: 2.4rem;"></i>
                            </span>
                            <h3 class="m-portlet__head-text">Laundry Item Costs
                            </h3>
                        </div>
                    </div>
                </div>
                <div class="m-portlet__body" style="padding: 1.2rem 1.2rem;">
                    <div class="m-scrollable m-scroller ps ps--active-y" data-scrollable="true" data-height="80" data-scrollbar-shown="true" style="height: 30px; font-size: 11px;">
                        The Cost of Laundry for every Vendor is different for different Items
                        <br />
                        <br />
                        Manager Vendor-wise , Item-wise Cost for each Laundry Item being sent of for Washing.
										<div class="ps__rail-x" style="left: 0px; bottom: 0px;">
                                            <div class="ps__thumb-x" tabindex="0" style="left: 0px; width: 0px;"></div>
                                        </div>
                        <div class="ps__rail-y" style="top: 0px; height: 200px; right: 4px;">
                            <div class="ps__thumb-y" tabindex="0" style="top: 0px; height: 94px;"></div>
                        </div>
                    </div>
                </div>
                <div class="m-portlet__foot" style="padding: 1.1rem 1.1rem;">
                    <div class="row align-items-center">
                        <div class="col-lg-4">
                            <a href="<%= Page.ResolveClientUrl("~/Laundry_Management/Stock_Setup/Vendor_Item_Cost.aspx") %>" class="btn btn-success">Click Here</a>
                        </div>
                    </div>
                </div>
            </div>
            <!--end::Portlet-->

        </div>



    </div>

</asp:Content>
