<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="View_Reports.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Reports.View_Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .m-portlet .m-portlet__head .m-portlet__head-tools .btn
        {
            margin-top:auto; 
            margin-bottom:auto;
        }

        .m-btn--icon > span > span 
        {
            padding-left: 0rem;
        }

        .m-portlet__body
        {
            text-align: center;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="m-grid__item m-grid__item--fluid">
        <div class="m-content">
            <div class="row">
                <div class="col-xl-12">
                    
                <div class="m-portlet m-portlet--tabs">
									<div class="m-portlet__head">
										<div class="m-portlet__head-tools">
											<ul class="nav nav-tabs m-tabs-line m-tabs-line--primary m-tabs-line--2x" role="tablist">
												<li class="nav-item m-tabs__item">
													<a class="nav-link m-tabs__link active show" data-toggle="tab" href="#m_tabs_6_1" role="tab">
														<i class="socicon-buffer"></i> Standard Reports
													</a>
												</li>
                                                
												<li class="nav-item m-tabs__item">
													<a class="nav-link m-tabs__link" data-toggle="tab" href="#m_tabs_6_2" role="tab" aria-selected="false">
														<i class="socicon-buffer"></i> Controls Reports
													</a>
												</li>
												<li class="nav-item m-tabs__item">
													<a class="nav-link m-tabs__link" data-toggle="tab" href="#m_tabs_6_3" role="tab">
														<i class="la la-cog"></i>Custom Reports
													</a>
												</li>
											</ul>
										</div>
									</div>
									<div class="m-portlet__body">
										<div class="tab-content">
											<div class="tab-pane active show" id="m_tabs_6_1" role="tabpanel">
											
                                                <div class="row">
                                                    <div class="col-xl-3">
                                                        <!--begin::Portlet-->
                                                        <div class="m-portlet m-portlet--skin-dark m-portlet--bordered-semi m--bg-primary">
                                                            <div class="m-portlet__head">
                                                                <div class="m-portlet__head-caption">
                                                                    <div class="m-portlet__head-title">
                                                                        <span class="m-portlet__head-icon">
                                                                            <i class="la la-file-text-o" style="font-size: 2.4rem;" aria-hidden="true"></i>
                                       
                                                                        </span>
                                                                        <h3 class="m-portlet__head-text">Brand Summary Report
                                                                        </h3>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                            <div class="m-portlet__body">
                                                                <div class="m-portlet__body-progress">Loading</div>
                                                                <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports/Standard/Brand_Summary_Report.aspx") %>" class="btn btn-warning m-btn m-btn--icon m-btn--pill m-btn--air" data-container="body" data-toggle="m-tooltip" data-skin="dark" data-placement="right" title="" data-original-title="Report Description and Details">
                                                                            <span>
                                                                                <i class="fa fa-angle-double-right"></i>
                                                                                <span>View Report</span>
                                            
                                                                            </span>
                                                                        </a>
                                                            </div>
                                                        </div>
                                                        <!--end::Portlet-->

                                                    </div>
                                                    <div class="col-xl-3">
                                                        <!--begin::Portlet-->
                                                        <div class="m-portlet m-portlet--skin-dark m-portlet--bordered-semi m--bg-primary">
                                                            <div class="m-portlet__head">
                                                                <div class="m-portlet__head-caption">
                                                                    <div class="m-portlet__head-title">
                                                                        <span class="m-portlet__head-icon">
                                                                            <i class="la la-file-text-o" style="font-size: 2.4rem;" aria-hidden="true"></i>
                                       
                                                                        </span>
                                                                        <h3 class="m-portlet__head-text">Sales Report
                                                                        </h3>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                            <div class="m-portlet__body">
                                                                <div class="m-portlet__body-progress">Loading</div>
                                                                <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports/Standard/Sales_Report.aspx") %>" class="btn btn-warning m-btn m-btn--icon m-btn--pill m-btn--air" data-container="body" data-toggle="m-tooltip" data-skin="dark" data-placement="right" title="" data-original-title="Report Description and Details">
                                                                            <span>
                                                                                <i class="fa fa-angle-double-right"></i>
                                                                                <span>View Report</span>
                                            
                                                                            </span>
                                                                        </a>
                                                            </div>
                                                        </div>
                                                        <!--end::Portlet-->

                                                    </div>
                                                    <div class="col-xl-3">
                                                        <!--begin::Portlet-->
                                                        <div class="m-portlet m-portlet--skin-dark m-portlet--bordered-semi m--bg-primary">
                                                            <div class="m-portlet__head">
                                                                <div class="m-portlet__head-caption">
                                                                    <div class="m-portlet__head-title">
                                                                        <span class="m-portlet__head-icon">
                                                                            <i class="la la-file-text-o" style="font-size: 2.4rem;" aria-hidden="true"></i>
                                       
                                                                        </span>
                                                                        <h3 class="m-portlet__head-text">Purchase Report
                                                                        </h3>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                            <div class="m-portlet__body">
                                                                <div class="m-portlet__body-progress">Loading</div>
                                                                <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports/Standard/Purchase_Report.aspx") %>" class="btn btn-warning m-btn m-btn--icon m-btn--pill m-btn--air" data-container="body" data-toggle="m-tooltip" data-skin="dark" data-placement="right" title="" data-original-title="Report Description and Details">
                                                                            <span>
                                                                                <i class="fa fa-angle-double-right"></i>
                                                                                <span>View Report</span>
                                            
                                                                            </span>
                                                                        </a>
                                                            </div>
                                                        </div>
                                                        <!--end::Portlet-->

                                                    </div>
                                                    <div class="col-xl-3">
                                                        <!--begin::Portlet-->
                                                        <div class="m-portlet m-portlet--skin-dark m-portlet--bordered-semi m--bg-primary">
                                                            <div class="m-portlet__head">
                                                                <div class="m-portlet__head-caption">
                                                                    <div class="m-portlet__head-title">
                                                                        <span class="m-portlet__head-icon">
                                                                            <i class="la la-file-text-o" style="font-size: 2.4rem;" aria-hidden="true"></i>
                                       
                                                                        </span>
                                                                        <h3 class="m-portlet__head-text">Transfers Report
                                                                        </h3>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                            <div class="m-portlet__body">
                                                                <div class="m-portlet__body-progress">Loading</div>
                                                                <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports/Standard/Transfers_Report.aspx") %>" class="btn btn-warning m-btn m-btn--icon m-btn--pill m-btn--air" data-container="body" data-toggle="m-tooltip" data-skin="dark" data-placement="right" title="" data-original-title="Report Description and Details">
                                                                            <span>
                                                                                <i class="fa fa-angle-double-right"></i>
                                                                                <span>View Report</span>
                                            
                                                                            </span>
                                                                        </a>
                                                            </div>
                                                        </div>
                                                        <!--end::Portlet-->

                                                    </div>
                                                    <div class="col-xl-3">
                                                        <!--begin::Portlet-->
                                                        <div class="m-portlet m-portlet--skin-dark m-portlet--bordered-semi m--bg-primary">
                                                            <div class="m-portlet__head">
                                                                <div class="m-portlet__head-caption">
                                                                    <div class="m-portlet__head-title">
                                                                        <span class="m-portlet__head-icon">
                                                                            <i class="la la-file-text-o" style="font-size: 2.4rem;" aria-hidden="true"></i>
                                       
                                                                        </span>
                                                                        <h3 class="m-portlet__head-text">Cost Report
                                                                        </h3>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                            <div class="m-portlet__body">
                                                                <div class="m-portlet__body-progress">Loading</div>
                                                                <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports/Standard/Cost_Report.aspx") %>" class="btn btn-warning m-btn m-btn--icon m-btn--pill m-btn--air" data-container="body" data-toggle="m-tooltip" data-skin="dark" data-placement="right" title="" data-original-title="Report Description and Details">
                                                                            <span>
                                                                                <i class="fa fa-angle-double-right"></i>
                                                                                <span>View Report</span>
                                            
                                                                            </span>
                                                                        </a>
                                                            </div>
                                                        </div>
                                                        <!--end::Portlet-->
                                                        
                                                    
                                                </div>
                                                    <div class="col-xl-3">
                                                        <!--begin::Portlet-->
                                                        <div class="m-portlet m-portlet--skin-dark m-portlet--bordered-semi m--bg-primary">
                                                            <div class="m-portlet__head">
                                                                <div class="m-portlet__head-caption">
                                                                    <div class="m-portlet__head-title">
                                                                        <span class="m-portlet__head-icon">
                                                                            <i class="la la-file-text-o" style="font-size: 2.4rem;" aria-hidden="true"></i>
                                       
                                                                        </span>
                                                                        <h3 class="m-portlet__head-text">Bulk Litre Report
                                                                        </h3>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                            <div class="m-portlet__body">
                                                                <div class="m-portlet__body-progress">Loading</div>
                                                                <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports/Standard/Bulk_Litre_Report.aspx") %>" class="btn btn-warning m-btn m-btn--icon m-btn--pill m-btn--air" data-container="body" data-toggle="m-tooltip" data-skin="dark" data-placement="right" title="" data-original-title="Report Description and Details">
                                                                            <span>
                                                                                <i class="fa fa-angle-double-right"></i>
                                                                                <span>View Report</span>
                                            
                                                                            </span>
                                                                        </a>
                                                            </div>
                                                        </div>

                                                    </div>

                                            </div>

                                            </div>
											<div class="tab-pane" id="m_tabs_6_2" role="tabpanel">
												These reports are Under Development. They will be available soon.
											</div>
											<div class="tab-pane" id="m_tabs_6_3" role="tabpanel">
												Get a Customized Report built for Your Company. Click on Contact Support and raise a request.

											</div>
										</div>
									</div>
								</div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
