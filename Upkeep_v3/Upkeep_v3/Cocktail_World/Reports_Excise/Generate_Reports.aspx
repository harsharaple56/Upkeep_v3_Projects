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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


    <div class="m-grid__item m-grid__item--fluid">
        <div class="m-content" runat="server" id="div_Maharashtra_Excise" style="padding: 30px 10px;">
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
                                    <h3 class="m-portlet__head-text">FLR-III
                                    </h3>
                                </div>

                            </div>
                            <div class="m-portlet__head-tools">

                                <div class="btn-group">
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports_Excise/Maharashtra/FLR3.aspx") %>" class="btn btn-danger m-btn m-btn--icon m-btn--pill m-btn--air">
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
                                    <h3 class="m-portlet__head-text">FLR-III (Pre-Printed)
                                    </h3>
                                </div>

                            </div>
                            <div class="m-portlet__head-tools">

                                <div class="btn-group">
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports_Excise/Maharashtra/FLR3_Pre_Printed.aspx") %>" class="btn btn-danger m-btn m-btn--icon m-btn--pill m-btn--air">
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
                                    <h3 class="m-portlet__head-text">FLR-III A
                                    </h3>
                                </div>

                            </div>
                            <div class="m-portlet__head-tools">

                                <div class="btn-group">
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports_Excise/Maharashtra/FLR3_A.aspx") %>" class="btn btn-danger m-btn m-btn--icon m-btn--pill m-btn--air">
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
                                    <h3 class="m-portlet__head-text">FLR-IV
                                    </h3>
                                </div>

                            </div>
                            <div class="m-portlet__head-tools">

                                <div class="btn-group">
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports_Excise/Maharashtra/FLR4.aspx") %>" class="btn btn-danger m-btn m-btn--icon m-btn--pill m-btn--air">
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
                                    <h3 class="m-portlet__head-text">FLR-VI
                                    </h3>
                                </div>

                            </div>
                            <div class="m-portlet__head-tools">

                                <div class="btn-group">
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports_Excise/Maharashtra/FLR6.aspx") %>" class="btn btn-danger m-btn m-btn--icon m-btn--pill m-btn--air">
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
                                    <h3 class="m-portlet__head-text">FLR-VI (Pre-Printed)
                                    </h3>
                                </div>

                            </div>
                            <div class="m-portlet__head-tools">

                                <div class="btn-group">
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports_Excise/Maharashtra/FLR6_Pre_Printed.aspx") %>" class="btn btn-danger m-btn m-btn--icon m-btn--pill m-btn--air">
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
                                    <h3 class="m-portlet__head-text">FLR-VI A
                                    </h3>
                                </div>

                            </div>
                            <div class="m-portlet__head-tools">

                                <div class="btn-group">
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports_Excise/Maharashtra/FLR6_A.aspx") %>" class="btn btn-danger m-btn m-btn--icon m-btn--pill m-btn--air">
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
                                    <h3 class="m-portlet__head-text">Chatai
                                    </h3>
                                </div>

                            </div>
                            <div class="m-portlet__head-tools">

                                <div class="btn-group">
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports_Excise/Maharashtra/Chatai.aspx") %>" class="btn btn-danger m-btn m-btn--icon m-btn--pill m-btn--air">
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
