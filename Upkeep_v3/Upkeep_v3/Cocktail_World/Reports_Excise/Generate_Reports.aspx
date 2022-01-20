﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Generate_Reports.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Reports_Excise.Generate_Reports" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


    <div class="m-grid__item m-grid__item--fluid">
        <div class="m-content" runat="server" id="div_Maharashtra_Excise" style="padding: 30px 10px;">
            <div class="m-portlet m-portlet--mobile">
                <div class="m-portlet__head">
                    <div class="col-xl-4 m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <h3 class="m-portlet__head-text">Maharashtra Liquor Excise Reports
                            </h3>
                        </div>
                    </div>

                    <div class="col-xl-8 m-portlet__head-tools">

                        <div class="col-lg-9 m--margin-bottom-10-tablet-and-mobile">

                            <div class="m-form__control">

                                <asp:DropDownList ID="m_form_type" runat="server" CssClass="form-control" ClientIDMode="Static">
                                    <asp:ListItem Value="All" Text="Select License / Outlet"></asp:ListItem>
                                    <asp:ListItem Value="In Progress" Text="In Progress"></asp:ListItem>
                                    <asp:ListItem Value="Accepted" Text="Accepted"></asp:ListItem>
                                    <asp:ListItem Value="Assigned" Text="Assigned"></asp:ListItem>
                                    <asp:ListItem Value="Hold" Text="Hold"></asp:ListItem>
                                    <asp:ListItem Value="Closed" Text="Closed"></asp:ListItem>
                                    <asp:ListItem Value="Expired" Text="Expired"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Transactions/Sales.aspx") %>" class="col-lg-2 btn btn-metal m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m--margin-right-10">
                            <span>
                                <i class="la la-arrow-left"></i>
                                <span>Back</span>
                            </span>
                        </a>
                    </div>

                </div>

                <div class="m-portlet m-portlet--tabs">

                    <div class="m-portlet__head ">
                        <div class="m-portlet__head-tools">
                            <ul class="nav nav-tabs m-tabs-line m-tabs-line--primary m-tabs-line--2x m--align-center" role="tablist">
                                <li class="nav-item m-tabs__item">
                                    <a class="nav-link m-tabs__link active show" data-toggle="tab" href="#m_portlet_base_demo_1_1_tab_content" role="tab" aria-selected="true">
                                        <i class="la la-file-text-o" style="font-size: 2rem;"></i>FLR-III
                                    </a>
                                </li>
                                <li class="nav-item m-tabs__item">
                                    <a class="nav-link m-tabs__link" data-toggle="tab" href="#m_portlet_base_demo_1_2_tab_content" role="tab" aria-selected="false">
                                        <i class="la la-file-text-o" style="font-size: 2rem;"></i>FLR-III (Pre-Printed)
                                    </a>
                                </li>
                                <li class="nav-item m-tabs__item">
                                    <a class="nav-link m-tabs__link" data-toggle="tab" href="#m_portlet_base_demo_1_3_tab_content" role="tab" aria-selected="false">
                                        <i class="la la-file-text-o" style="font-size: 2rem;"></i>FLR-III A
                                    </a>
                                </li>
                                <li class="nav-item m-tabs__item">
                                    <a class="nav-link m-tabs__link" data-toggle="tab" href="#m_portlet_base_demo_1_4_tab_content" role="tab" aria-selected="false">
                                        <i class="la la-file-text-o" style="font-size: 2rem;"></i>FLR-IV
                                    </a>
                                </li>
                                <li class="nav-item m-tabs__item">
                                    <a class="nav-link m-tabs__link" data-toggle="tab" href="#m_portlet_base_demo_1_5_tab_content" role="tab" aria-selected="false">
                                        <i class="la la-file-text-o" style="font-size: 2rem;"></i>FLR-VI
                                    </a>
                                </li>
                                <li class="nav-item m-tabs__item">
                                    <a class="nav-link m-tabs__link" data-toggle="tab" href="#m_portlet_base_demo_1_6_tab_content" role="tab" aria-selected="false">
                                        <i class="la la-file-text-o" style="font-size: 2rem;"></i>FLR-VI (Pre-Printed)
                                    </a>
                                </li>
                                <li class="nav-item m-tabs__item">
                                    <a class="nav-link m-tabs__link" data-toggle="tab" href="#m_portlet_base_demo_1_7_tab_content" role="tab" aria-selected="false">
                                        <i class="la la-file-text-o" style="font-size: 2rem;"></i>FLR-VI A
                                    </a>
                                </li>
                                <li class="nav-item m-tabs__item">
                                    <a class="nav-link m-tabs__link" data-toggle="tab" href="#m_portlet_base_demo_1_8_tab_content" role="tab" aria-selected="false">
                                        <i class="la la-file-text-o" style="font-size: 2rem;"></i>Chatai
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>




                    <div class="m-portlet__body">
                        <div class="tab-content">
                            <div class="tab-pane active show" id="m_portlet_base_demo_1_1_tab_content" role="tabpanel">

                                <div id="form1" class="m-form m-form--fit m--margin-bottom-20">

                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>

                                            <div class="row m--margin-bottom-20 m--align-center">

                                                <div class="col-lg-12 m--margin-bottom-10-tablet-and-mobile">
                                                    <div class="m-form__control">
                                                        <button class="btn btn-success m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air" id="btn_Generate_FLR3_Report_Click" onserverclick="btn_GenerateReport1_ServerClick2" runat="server">
                                                            <span>
                                                                <i class="fab fa-whmcs" style="font-size: 2.1rem; }"></i>
                                                                <span>Generate <b>FLR-III</b> Excise Report</span>
                                                            </span>
                                                        </button>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="row m--margin-bottom-20 m--align-center">
                                                <div class="col-lg-12 m--margin-bottom-10-tablet-and-mobile">


                                                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" ShowBackButton="True" ProcessingMode="Remote" ShowPromptAreaButton="False">
                                                    </rsweb:ReportViewer>


                                                </div>
                                            </div>

                                        </ContentTemplate>
                                        <%--<Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btn_Generate_FLR3_Report_Click" EventName="Click" />
                                                 </Triggers>--%>
                                    </asp:UpdatePanel>



                                </div>


                            </div>
                            <div class="tab-pane" id="m_portlet_base_demo_1_2_tab_content" role="tabpanel">

                                <div class="m-form m-form--fit m--margin-bottom-20">



                                    <div class="row m--margin-bottom-20 m--align-center">

                                        <div class="col-lg-12 m--margin-bottom-10-tablet-and-mobile">
                                            <div class="m-form__control">
                                                <button class="btn btn-success m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air" id="btn_Generate_FLRIII_PrePrinted" runat="server">
                                                    <span>
                                                        <i class="fab fa-whmcs" style="font-size: 2.1rem; }"></i>
                                                        <span>Generate <b>FLR-III (Pre-Printed)</b> Report</span>
                                                    </span>
                                                </button>
                                            </div>

                                        </div>
                                    </div>
                                </div>


                            </div>
                            <div class="tab-pane" id="m_portlet_base_demo_1_3_tab_content" role="tabpanel">


                                <div class="m-form m-form--fit m--margin-bottom-20">
                                
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>

                                            <div class="row m--margin-bottom-20 m--align-center">

                                                <div class="col-lg-12 m--margin-bottom-10-tablet-and-mobile">
                                                    <div class="m-form__control">
                                                        <button class="btn btn-success m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air" id="Button1" onserverclick="btn_GenerateReport1_ServerClick2" runat="server">
                                                            <span>
                                                                <i class="fab fa-whmcs" style="font-size: 2.1rem; }"></i>
                                                                <span>Generate <b>FLR-III A</b> Excise Report</span>
                                                            </span>
                                                        </button>
                                                    </div>

                                                </div>
                                            </div>
                                            <div class="row m--margin-bottom-20 m--align-center">
                                                <div class="col-lg-12 m--margin-bottom-10-tablet-and-mobile">


                                                    <rsweb:ReportViewer ID="ReportViewer2" runat="server" Width="100%" ShowBackButton="True" ProcessingMode="Remote" ShowPromptAreaButton="False">
                                                    </rsweb:ReportViewer>


                                                </div>
                                            </div>

                                        </ContentTemplate>
                                        <%--<Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btn_Generate_FLR3_Report_Click" EventName="Click" />
                                                 </Triggers>--%>
                                    </asp:UpdatePanel>

                                </div>

                                <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1" width="100%">
                                    <thead>
                                        <tr>
                                            <th>Stock Qty</th>
                                            <th>Bottle Qty</th>
                                            <th>Bottle Rate</th>
                                            <th>SPeg Qty</th>
                                            <th>SPeg Rate</th>
                                            <th>LPeg Qty</th>
                                            <th>LPeg Rate</th>
                                            <th>Total Amount</th>
                                        </tr>
                                    </thead>

                                    <tbody>
                                        <%--<%=Fetch_Department_Transactions()%>--%>
                                    </tbody>
                                </table>


                            </div>
                            <div class="tab-pane" id="m_portlet_base_demo_1_4_tab_content" role="tabpanel">


                                <form class="m-form m-form--fit m--margin-bottom-20">



                                    <div class="row m--margin-bottom-20 m--align-center">

                                        <div class="col-lg-12 m--margin-bottom-10-tablet-and-mobile">
                                            <div class="m-form__control">
                                                <button class="btn btn-success m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air" id="Button3" runat="server">
                                                    <span>
                                                        <i class="fab fa-whmcs" style="font-size: 2.1rem; }"></i>
                                                        <span>Generate <b>FLR-IV</b> Excise Report</span>
                                                    </span>
                                                </button>
                                            </div>

                                        </div>
                                    </div>
                                </form>

                                <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1" width="100%">
                                    <thead>
                                        <tr>
                                            <th>Stock Qty</th>
                                            <th>Bottle Qty</th>
                                            <th>Bottle Rate</th>
                                            <th>SPeg Qty</th>
                                            <th>SPeg Rate</th>
                                            <th>LPeg Qty</th>
                                            <th>LPeg Rate</th>
                                            <th>Total Amount</th>
                                        </tr>
                                    </thead>

                                    <tbody>
                                        <%--<%=Fetch_Department_Transactions()%>--%>
                                    </tbody>
                                </table>


                            </div>
                            <div class="tab-pane" id="m_portlet_base_demo_1_5_tab_content" role="tabpanel">


                                <form class="m-form m-form--fit m--margin-bottom-20">



                                    <div class="row m--margin-bottom-20 m--align-center">

                                        <div class="col-lg-12 m--margin-bottom-10-tablet-and-mobile">
                                            <div class="m-form__control">
                                                <button class="btn btn-success m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air" id="Button4" runat="server">
                                                    <span>
                                                        <i class="fab fa-whmcs" style="font-size: 2.1rem; }"></i>
                                                        <span>Generate <b>FLR-VI</b> Excise Report</span>
                                                    </span>
                                                </button>
                                            </div>

                                        </div>
                                    </div>
                                </form>

                                <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1" width="100%">
                                    <thead>
                                        <tr>
                                            <th>Stock Qty</th>
                                            <th>Bottle Qty</th>
                                            <th>Bottle Rate</th>
                                            <th>SPeg Qty</th>
                                            <th>SPeg Rate</th>
                                            <th>LPeg Qty</th>
                                            <th>LPeg Rate</th>
                                            <th>Total Amount</th>
                                        </tr>
                                    </thead>

                                    <tbody>
                                        <%--<%=Fetch_Department_Transactions()%>--%>
                                    </tbody>
                                </table>


                            </div>
                            <div class="tab-pane" id="m_portlet_base_demo_1_6_tab_content" role="tabpanel">


                                <form class="m-form m-form--fit m--margin-bottom-20">



                                    <div class="row m--margin-bottom-20 m--align-center">

                                        <div class="col-lg-12 m--margin-bottom-10-tablet-and-mobile">
                                            <div class="m-form__control">
                                                <button class="btn btn-success m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air" id="Button5" runat="server">
                                                    <span>
                                                        <i class="fab fa-whmcs" style="font-size: 2.1rem; }"></i>
                                                        <span>Generate <b>FLR-VI (Pre-Printed)</b> Excise Report</span>
                                                    </span>
                                                </button>
                                            </div>

                                        </div>
                                    </div>
                                </form>

                                <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1" width="100%">
                                    <thead>
                                        <tr>
                                            <th>Stock Qty</th>
                                            <th>Bottle Qty</th>
                                            <th>Bottle Rate</th>
                                            <th>SPeg Qty</th>
                                            <th>SPeg Rate</th>
                                            <th>LPeg Qty</th>
                                            <th>LPeg Rate</th>
                                            <th>Total Amount</th>
                                        </tr>
                                    </thead>

                                    <tbody>
                                        <%--<%=Fetch_Department_Transactions()%>--%>
                                    </tbody>
                                </table>


                            </div>
                            <div class="tab-pane" id="m_portlet_base_demo_1_7_tab_content" role="tabpanel">


                                <form class="m-form m-form--fit m--margin-bottom-20">



                                    <div class="row m--margin-bottom-20 m--align-center">

                                        <div class="col-lg-12 m--margin-bottom-10-tablet-and-mobile">
                                            <div class="m-form__control">
                                                <button class="btn btn-success m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air" id="Button6" runat="server">
                                                    <span>
                                                        <i class="fab fa-whmcs" style="font-size: 2.1rem; }"></i>
                                                        <span>Generate <b>FLR-VI A</b> Excise Report</span>
                                                    </span>
                                                </button>
                                            </div>

                                        </div>
                                    </div>
                                </form>

                                <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1" width="100%">
                                    <thead>
                                        <tr>
                                            <th>Stock Qty</th>
                                            <th>Bottle Qty</th>
                                            <th>Bottle Rate</th>
                                            <th>SPeg Qty</th>
                                            <th>SPeg Rate</th>
                                            <th>LPeg Qty</th>
                                            <th>LPeg Rate</th>
                                            <th>Total Amount</th>
                                        </tr>
                                    </thead>

                                    <tbody>
                                        <%--<%=Fetch_Department_Transactions()%>--%>
                                    </tbody>
                                </table>


                            </div>

                            <div class="tab-pane" id="m_portlet_base_demo_1_8_tab_content" role="tabpanel">


                                <form class="m-form m-form--fit m--margin-bottom-20">



                                    <div class="row m--margin-bottom-20 m--align-center">

                                        <div class="col-lg-12 m--margin-bottom-10-tablet-and-mobile">
                                            <div class="m-form__control">
                                                <button class="btn btn-success m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air" id="Button7" runat="server">
                                                    <span>
                                                        <i class="fab fa-whmcs" style="font-size: 2.1rem; }"></i>
                                                        <span>Generate <b>Chatai</b> Excise Report</span>
                                                    </span>
                                                </button>
                                            </div>

                                        </div>
                                    </div>
                                </form>

                                <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1" width="100%">
                                    <thead>
                                        <tr>
                                            <th>Stock Qty</th>
                                            <th>Bottle Qty</th>
                                            <th>Bottle Rate</th>
                                            <th>SPeg Qty</th>
                                            <th>SPeg Rate</th>
                                            <th>LPeg Qty</th>
                                            <th>LPeg Rate</th>
                                            <th>Total Amount</th>
                                        </tr>
                                    </thead>

                                    <tbody>
                                        <%--<%=Fetch_Department_Transactions()%>--%>
                                    </tbody>
                                </table>


                            </div>

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
                                    <h3 class="m-portlet__head-text">FLR-III
                                    </h3>
                                </div>

                            </div>
                            <div class="m-portlet__head-tools">

                                <div class="btn-group">
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Transactions/Sales.aspx") %>" class="btn btn-danger m-btn m-btn--icon m-btn--pill m-btn--air">
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
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Transactions/Sales.aspx") %>" class="btn btn-danger m-btn m-btn--icon m-btn--pill m-btn--air">
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
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Transactions/Sales.aspx") %>" class="btn btn-danger m-btn m-btn--icon m-btn--pill m-btn--air">
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
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Transactions/Sales.aspx") %>" class="btn btn-danger m-btn m-btn--icon m-btn--pill m-btn--air">
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
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Transactions/Sales.aspx") %>" class="btn btn-danger m-btn m-btn--icon m-btn--pill m-btn--air">
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
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Transactions/Sales.aspx") %>" class="btn btn-danger m-btn m-btn--icon m-btn--pill m-btn--air">
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
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Transactions/Sales.aspx") %>" class="btn btn-danger m-btn m-btn--icon m-btn--pill m-btn--air">
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
                                    <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Transactions/Sales.aspx") %>" class="btn btn-danger m-btn m-btn--icon m-btn--pill m-btn--air">
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
