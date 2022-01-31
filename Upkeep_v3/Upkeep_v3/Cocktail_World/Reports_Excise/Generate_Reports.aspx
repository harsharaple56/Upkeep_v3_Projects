<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Generate_Reports.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Reports_Excise.Generate_Reports" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .underline {
            border-bottom-color: #5867dd;
            border-bottom-width: 5px;
            height: 45px;
        }
        [class^="flaticon-"], [class*=" flaticon-"] {
            font-size: 2.3rem;
        }
        .m-demo .m-demo__preview {
            background: white;
            border: 4px solid #f7f7fa;
            padding: 13px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


    <div class="m-grid__item m-grid__item--fluid">
        <div class="m-content" runat="server" id="div_Maharashtra_Excise">
            <div class="row">
                <div class="col-xl-12">
                    <div class="m-demo" data-code-preview="true" data-code-html="true" data-code-js="false">
													<div class="m-demo__preview">
														<h2 class="m--font-danger">
                                                            <i class="flaticon-medal"></i>
                                                            Maharashtra State Excise Reports
                                                            <i class="flaticon-medal"></i>
														</h2>
													</div>
												</div>
                </div>
            </div>
            
            <div class="row">
                <div class="col-xl-4">
                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--skin-dark m-portlet--bordered-semi m--bg-primary">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <span class="m-portlet__head-icon">
                                        <i class="la la-file-text-o" style="font-size: 2.4rem;" aria-hidden="true"></i>

                                    </span>
                                    <h3 class="m-portlet__head-text">FLR-III(3)
                                    </h3>
                                </div>

                            </div>
                            <div class="m-portlet__head-tools">

                                <div class="btn-group">
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports_Excise/Maharashtra/FLR3.aspx") %>" class="btn btn-warning m-btn m-btn--icon m-btn--pill m-btn--air">
                                        <span>
                                            <i class="fa fa-angle-double-right"></i>
                                            <span>Generate</span>
                                            <i class="fab fa-whmcs"></i>

                                        </span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="m-portlet__body">
                            <div class="m-portlet__body-progress">Loading</div>

                            <b>FLR-3 A</b> , also known as <b>Brand-wise report</b> is submitted to the Excise Department on Monthly Basis. Contains information about Liquor Consumed
                        </div>
                    </div>
                    <!--end::Portlet-->


                </div>
                <div class="col-xl-4">
                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--skin-dark m-portlet--bordered-semi m--bg-primary">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <span class="m-portlet__head-icon">
                                        <i class="la la-file-text-o" style="font-size: 2.4rem;" aria-hidden="true"></i>

                                    </span>
                                    <h3 class="m-portlet__head-text">FLR-III(3) (Pre-Printed)
                                    </h3>
                                </div>

                            </div>
                            <div class="m-portlet__head-tools">

                                <div class="btn-group">
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports_Excise/Maharashtra/FLR3_Pre_Printed.aspx") %>" class="btn btn-warning m-btn m-btn--icon m-btn--pill m-btn--air">
                                        <span>
                                            <i class="fa fa-angle-double-right"></i>
                                            <span>Generate</span>
                                            <i class="fab fa-whmcs"></i>

                                        </span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="m-portlet__body">
                            <div class="m-portlet__body-progress">Loading</div>

                            <b>FLR-3 A</b> , also known as <b>Brand-wise report</b> is submitted to the Excise Department on Monthly Basis. Contains information about Liquor Consumed
                        </div>
                    </div>
                    <!--end::Portlet-->

                </div>
                <div class="col-xl-4">
                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--skin-dark m-portlet--bordered-semi m--bg-primary">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <span class="m-portlet__head-icon">
                                        <i class="la la-file-text-o" style="font-size: 2.4rem;" aria-hidden="true"></i>

                                    </span>
                                    <h3 class="m-portlet__head-text">FLR-III(3) A 
                                    </h3>
                                </div>

                            </div>
                            <div class="m-portlet__head-tools">

                                <div class="btn-group">
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports_Excise/Maharashtra/FLR3_A.aspx") %>" class="btn btn-warning m-btn m-btn--icon m-btn--pill m-btn--air">
                                        <span>
                                            <i class="fa fa-angle-double-right"></i>
                                            <span>Generate</span>
                                            <i class="fab fa-whmcs"></i>

                                        </span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="m-portlet__body">
                            <div class="m-portlet__body-progress">Loading</div>
                            <b>FLR-3 A</b> , also known as <b>Brand-wise report</b> is submitted to the Excise Department on Monthly Basis. Contains information about Liquor Consumed
                        </div>
                    </div>
                    <!--end::Portlet-->

                </div>
            </div>

            <div class="row">

                <div class="col-xl-4">
                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--skin-dark m-portlet--bordered-semi m--bg-primary">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <span class="m-portlet__head-icon">
                                        <i class="la la-file-text-o" style="font-size: 2.4rem;" aria-hidden="true"></i>

                                    </span>
                                    <h3 class="m-portlet__head-text">FLR-IV(4)
                                    </h3>
                                </div>

                            </div>
                            <div class="m-portlet__head-tools">

                                <div class="btn-group">
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports_Excise/Maharashtra/FLR4.aspx") %>" class="btn btn-warning m-btn m-btn--icon m-btn--pill m-btn--air">
                                        <span>
                                            <i class="fa fa-angle-double-right"></i>
                                            <span>Generate</span>
                                            <i class="fab fa-whmcs"></i>

                                        </span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="m-portlet__body">
                            <div class="m-portlet__body-progress">Loading</div>
                            Description and Usage about Report 
                        </div>
                    </div>
                    <!--end::Portlet-->

                </div>
                <div class="col-xl-4">
                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--skin-dark m-portlet--bordered-semi m--bg-primary">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <span class="m-portlet__head-icon">
                                        <i class="la la-file-text-o" style="font-size: 2.4rem;" aria-hidden="true"></i>

                                    </span>
                                    <h3 class="m-portlet__head-text">FLR-VI(6)
                                    </h3>
                                </div>

                            </div>
                            <div class="m-portlet__head-tools">

                                <div class="btn-group">
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports_Excise/Maharashtra/FLR6.aspx") %>" class="btn btn-warning m-btn m-btn--icon m-btn--pill m-btn--air">
                                        <span>
                                            <i class="fa fa-angle-double-right"></i>
                                            <span>Generate</span>
                                            <i class="fab fa-whmcs"></i>

                                        </span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="m-portlet__body">
                            <div class="m-portlet__body-progress">Loading</div>
                            Description and Usage about Report 
                        </div>
                    </div>
                    <!--end::Portlet-->

                </div>
                <div class="col-xl-4">
                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--skin-dark m-portlet--bordered-semi m--bg-primary">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <span class="m-portlet__head-icon">
                                        <i class="la la-file-text-o" style="font-size: 2.4rem;" aria-hidden="true"></i>

                                    </span>
                                    <h3 class="m-portlet__head-text">FLR-VI(6) (Pre-Printed)
                                    </h3>
                                </div>

                            </div>
                            <div class="m-portlet__head-tools">

                                <div class="btn-group">
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports_Excise/Maharashtra/FLR6_Pre_Printed.aspx") %>" class="btn btn-warning m-btn m-btn--icon m-btn--pill m-btn--air">
                                        <span>
                                            <i class="fa fa-angle-double-right"></i>
                                            <span>Generate</span>
                                            <i class="fab fa-whmcs"></i>

                                        </span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="m-portlet__body">
                            <div class="m-portlet__body-progress">Loading</div>
                            Description and Usage about Report 
                        </div>
                    </div>
                    <!--end::Portlet-->

                </div>
            </div>

            <div class="row">


                <div class="col-xl-4">
                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--skin-dark m-portlet--bordered-semi m--bg-primary">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <span class="m-portlet__head-icon">
                                        <i class="la la-file-text-o" style="font-size: 2.4rem;" aria-hidden="true"></i>

                                    </span>
                                    <h3 class="m-portlet__head-text">FLR-VI(6) A
                                    </h3>
                                </div>

                            </div>
                            <div class="m-portlet__head-tools">

                                <div class="btn-group">
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports_Excise/Maharashtra/FLR6_A.aspx") %>" class="btn btn-warning m-btn m-btn--icon m-btn--pill m-btn--air">
                                        <span>
                                            <i class="fa fa-angle-double-right"></i>
                                            <span>Generate</span>
                                            <i class="fab fa-whmcs"></i>

                                        </span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="m-portlet__body">
                            <div class="m-portlet__body-progress">Loading</div>
                            Description and Usage about Report 
                        </div>
                    </div>
                    <!--end::Portlet-->

                </div>
              
                <div class="col-xl-4">
                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--skin-dark m-portlet--bordered-semi m--bg-primary">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <span class="m-portlet__head-icon">
                                        <i class="la la-file-text-o" style="font-size: 2.4rem;" aria-hidden="true"></i>

                                    </span>
                                    <h3 class="m-portlet__head-text">Cash Memo
                                    </h3>
                                </div>

                            </div>
                            <div class="m-portlet__head-tools">

                                <div class="btn-group">
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports_Excise/Maharashtra/Cash_Memo.aspx") %>" class="btn btn-warning m-btn m-btn--icon m-btn--pill m-btn--air">
                                        <span>
                                            <i class="fa fa-angle-double-right"></i>
                                            <span>Generate</span>
                                            <i class="fab fa-whmcs"></i>

                                        </span>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="m-portlet__body">
                            <div class="m-portlet__body-progress">Loading</div>
                            Description and Usage about Report 
                        </div>
                    </div>
                    <!--end::Portlet-->

                </div>
            </div>



        </div>

    </div>


    <script src="<%= Page.ResolveClientUrl("~/assets/demo/default/custom/crud/forms/widgets/bootstrap-datepicker.js") %>" type="text/javascript"></script>




</asp:Content>
