<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Generate_Reports.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Reports_Excise.Generate_Reports" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script type='text/javascript'>
$(window).load(function(){
$(function() {
    $("#btn_Generate_FLR3_Report_Click").click(function() {
        $('#div_FLR3_Report')
            .load('HtmlPage1.html');
    
    });
});
});
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="m-grid__item m-grid__item--fluid">
        <div class="m-content" runat="server" id="div_Maharashtra_Excise" style="padding: 30px 10px;" >
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

                                <form id="form1" class="m-form m-form--fit m--margin-bottom-20">



                                    <div class="row m--margin-bottom-20 m--align-center">
                                        
                                        <div class="col-lg-12 m--margin-bottom-10-tablet-and-mobile">
                                            <div class="m-form__control">
                                                <button class="btn btn-success m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air" id="btn_Generate_FLR3_Report_Click" runat="server">
                                                    <span>
                                                        <i class="fab fa-whmcs" style="font-size: 2.1rem;}"></i>
                                                        <span>Generate <b>FLR-III</b> Excise Report</span>
                                                    </span>
                                                </button>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="row m--margin-bottom-20 m--align-center">
                                        <div class="col-lg-12 m--margin-bottom-10-tablet-and-mobile">
                                            <div id="div_FLR3_Report"></div>
                                                <iframe name="div_FLR3_Report_iFrame" runat="server" src="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports_Excise/Maharashtra/FLR3_Report1.aspx") %>" width="100%" height="100%">
                                                    
                                                </iframe>
                                        </div>
                                    </div>

                                    
                                    
                                </form>
                     

                            </div>
                            <div class="tab-pane" id="m_portlet_base_demo_1_2_tab_content" role="tabpanel">
                                
                                <form class="m-form m-form--fit m--margin-bottom-20">



                                    <div class="row m--margin-bottom-20 m--align-center">
                                        
                                        <div class="col-lg-12 m--margin-bottom-10-tablet-and-mobile">
                                            <div class="m-form__control">
                                                <button class="btn btn-success m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air"  id="btn_Generate_FLRIII_PrePrinted" runat="server">
                                                    <span>
                                                        <i class="fab fa-whmcs" style="font-size: 2.1rem;}"></i>
                                                        <span>Generate <b>FLR-III (Pre-Printed)</b> Report</span>
                                                    </span>
                                                </button>
                                                <button class="btn btn-success m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air" id="Button1" onclick="" runat="server">
                                                    <span>
                                                        <i class="fab fa-whmcs" style="font-size: 2.1rem;}"></i>
                                                        <span>Generate <b>FLR-III A</b> Excise Report</span>
                                                    </span>
                                                </button>
                                            </div>

                                        </div>
                                    </div>
                                </form>


                            </div>
                            <div class="tab-pane" id="m_portlet_base_demo_1_3_tab_content" role="tabpanel">
                                
                                
                                <form class="m-form m-form--fit m--margin-bottom-20">



                                    <div class="row m--margin-bottom-20 m--align-center">
                                        
                                        <div class="col-lg-12 m--margin-bottom-10-tablet-and-mobile">
                                            <div class="m-form__control">
                                                <button class="btn btn-success m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air" id="Button2" runat="server">
                                                    <span>
                                                        <i class="fab fa-whmcs" style="font-size: 2.1rem;}"></i>
                                                        <span>Generate <b>FLR-III A</b> Excise Report</span>
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
                            <div class="tab-pane" id="m_portlet_base_demo_1_4_tab_content" role="tabpanel">
                                
                                
                                <form class="m-form m-form--fit m--margin-bottom-20">



                                    <div class="row m--margin-bottom-20 m--align-center">
                                        
                                        <div class="col-lg-12 m--margin-bottom-10-tablet-and-mobile">
                                            <div class="m-form__control">
                                                <button class="btn btn-success m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air" id="Button3" runat="server">
                                                    <span>
                                                        <i class="fab fa-whmcs" style="font-size: 2.1rem;}"></i>
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
                                                        <i class="fab fa-whmcs" style="font-size: 2.1rem;}"></i>
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
                                                        <i class="fab fa-whmcs" style="font-size: 2.1rem;}"></i>
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
                                                        <i class="fab fa-whmcs" style="font-size: 2.1rem;}"></i>
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
                                                        <i class="fab fa-whmcs" style="font-size: 2.1rem;}"></i>
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


        </div>

    </div>

    
    <script src="<%= Page.ResolveClientUrl("~/assets/demo/default/custom/crud/forms/widgets/bootstrap-datepicker.js") %>" type="text/javascript"></script>




</asp:Content>
