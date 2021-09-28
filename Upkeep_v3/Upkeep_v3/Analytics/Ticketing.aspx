<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Ticketing.aspx.cs" Inherits="Upkeep_v3.Analytics.Ticketing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="JS/Ticketing.js"></script>
    <style>
        .loader {
            border: 16px solid #f3f3f3;
            border-top: 16px solid #3498db;
            border-radius: 50%;
            width: 120px;
            height: 120px;
            animation: spin 2s linear infinite;
            position: absolute;
            top: 35%;
            left: 40%;
        }

        .invisible {
            visibility: hidden;
        }

        @keyframes spin {
            0% {
                transform: rotate(0deg);
            }

            100% {
                transform: rotate(360deg);
            }
        }

        .within-scroll {
            overflow-y: scroll !important;
            height: 340px;
        }

        #dvBlock6 .within-scroll::-webkit-scrollbar, #dvBlock7 .within-scroll::-webkit-scrollbar {
            width: 5px;
        }

        #dvBlock6 .within-scroll::-webkit-scrollbar-track, #dvBlock7 .within-scroll::-webkit-scrollbar-track {
            background-color: #dfdfdf;
            border-radius: 10px;
        }

        #dvBlock6 .within-scroll::-webkit-scrollbar-thumb, #dvBlock7 .within-scroll::-webkit-scrollbar-thumb {
            box-shadow: inset 0 0 20px 5px rgb(0 0 0 / 30%);
            border-radius: 10px;
        }

        #dvBlock6 .table, #dvBlock7 .table {
            width: 99% !important;
        }
    </style>
    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="row">

                <div class="col-xl-6" id="dvBlock1">
                    <div class="loader"></div>
                    <!--begin:: Ticketing Section-->
                    <div class="m-portlet m-portlet--bordered-semi m-portlet--full-height  m-portlet--rounded-force invisible">

                        <div class="m-portlet__body">
                            <div class="m-widget19">
                                <div class="m-widget19__content">
                                    <div class="m-widget19__header">
                                        <div class="m-widget19__user-img">
                                            <img class="m-widget19__img" style="width: 6rem;" src="../../assets/app/media/img/Dashboard_Icons/tkt.png" alt="" />
                                        </div>
                                        <div class="m-widget19__info">
                                            <span class="m-widget19__username">Total tickets
                                            </span>
                                            <br />
                                            <span class="m-widget19__time">Total No. of Tickets raised
                                            </span>
                                        </div>
                                        <div class="m-widget19__stats">
                                            <span class="m-widget19__number m--font-brand" style="font-size: 3.5rem;" id="totalCount"></span>
                                            <span class="m-widget19__comment" style="line-height: 2;">Tickets
                                            </span>
                                        </div>

                                    </div>

                                    <div class="m-widget19__body">
                                        Get in-depth insights & Analysis on all tickets data. 
                                    </div>
                                </div>


                                <div class="m-widget4 m-widget4--chart-bottom" style="min-height: auto;">
                                    <div class="m-widget4__item">
                                        <div class="m-widget4__ext">
                                            <a href="#" class="m-widget4__icon m--font-brand">
                                                <i class="flaticon-interface-3"></i>
                                            </a>
                                        </div>
                                        <div class="m-widget4__info">
                                            <span class="m-widget4__text">No. of tickets with Status
                                            <span class="m-badge m-badge--danger m-badge--wide">Open</span>
                                            </span>
                                        </div>
                                        <div class="m-widget4__ext">
                                            <span class="m-widget4__number m--font-accent" id="openTicket"></span>
                                        </div>
                                    </div>
                                    <div class="m-widget4__item">
                                        <div class="m-widget4__ext">
                                            <a href="#" class="m-widget4__icon m--font-brand">
                                                <i class="flaticon-interface-3"></i>
                                            </a>
                                        </div>
                                        <div class="m-widget4__info">
                                            <span class="m-widget4__text">No. of tickets with Status
                                            <span class="m-badge  m-badge--success m-badge--wide">Closed</span>
                                            </span>
                                        </div>
                                        <div class="m-widget4__ext">
                                            <span class="m-widget4__stats m--font-info">
                                                <span class="m-widget4__number m--font-accent" id="closedTicket"></span>
                                            </span>
                                        </div>
                                    </div>
                                    <div class="m-widget4__item">
                                        <div class="m-widget4__ext">
                                            <a href="#" class="m-widget4__icon m--font-brand">
                                                <i class="flaticon-interface-3"></i>
                                            </a>
                                        </div>
                                        <div class="m-widget4__info">
                                            <span class="m-widget4__text">No. of tickets with Status
                                            <span class="m-badge m-badge--warning m-badge--wide">Parked</span>
                                            </span>
                                        </div>
                                        <div class="m-widget4__ext">
                                            <span class="m-widget4__stats m--font-info">
                                                <span class="m-widget4__number m--font-accent" id="parkedTicket"></span>
                                            </span>
                                        </div>
                                    </div>
                                    <div class="m-widget4__item m-widget4__item--last">
                                        <div class="m-widget4__ext">
                                            <a href="#" class="m-widget4__icon m--font-brand">
                                                <i class="flaticon-interface-3"></i>
                                            </a>
                                        </div>
                                        <div class="m-widget4__info">
                                            <span class="m-widget4__text">No. of tickets with Status
                                            <span class="m-badge m-badge--secondary m-badge--wide">Expired</span>
                                            </span>
                                        </div>
                                        <div class="m-widget4__ext">
                                            <span class="m-widget4__stats m--font-info">
                                                <span class="m-widget4__number m--font-accent" id="expiredTicket"></span>
                                            </span>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                    <!--end:: Ticketing Section-->
                </div>

                <div class="col-xl-6" id="dvBlock2">
                    <div class="loader"></div>
                    <div class="m-portlet m-portlet--full-height invisible">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <h3 class="m-portlet__head-text">Top 5 Perfomers of the Month
                                    </h3>
                                </div>
                            </div>
                        </div>
                        <div class="m-portlet__body">
                            <div class="tab-content">
                                <div class="tab-pane active" id="m_widget4_tab1_content">
                                    <div class="m-widget4 m-widget4--progress" id="appendBlock2Content">
                                        <div class="m-widget4__item" style="display: none">
                                            <div class="m-widget4__img m-widget4__img--pic">
                                                <img src="##ProfilePic##" alt="">
                                            </div>
                                            <div class="m-widget4__info">
                                                <span class="m-widget4__title">##Name##
                                                </span>
                                                <br>
                                                <span class="m-widget4__sub">##Designation##, <b>##Department##</b>
                                                </span>
                                            </div>
                                            <div class="m-widget4__progress">
                                                <div class="m-widget4__progress-wrapper">
                                                    <span class="m-widget17__progress-number">##Pecent##%</span>
                                                    <span class="m-widget17__progress-label">Tickets</span>
                                                    <div class="progress m-progress--sm">
                                                        <div class="progress-bar bg-danger h-100" role="progressbar" style="width: ##Pecent##%;" aria-valuenow="25" aria-valuemin="40" aria-valuemax="##Pecent##"></div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="m-widget4__ext">
                                                <a href="#" class="m-btn m-btn--hover-brand m-btn--pill btn btn-sm btn-secondary">Profile</a>
                                            </div>
                                        </div>
                                        <%--<div class="m-widget4__item">
                                            <div class="m-widget4__img m-widget4__img--pic">
                                                <img src="../../assets/app/media/img/users/100_4.jpg" alt="">
                                            </div>
                                            <div class="m-widget4__info">
                                                <span class="m-widget4__title">Anna Strong
                                                </span>
                                                <br>
                                                <span class="m-widget4__sub">Sr. Operations Executive, <b>Housekeeping</b>
                                                </span>
                                            </div>
                                            <div class="m-widget4__progress">
                                                <div class="m-widget4__progress-wrapper">
                                                    <span class="m-widget17__progress-number">63%</span>
                                                    <span class="m-widget17__progress-label">Tickets</span>
                                                    <div class="progress m-progress--sm">
                                                        <div class="progress-bar bg-danger" role="progressbar" style="width: 63%;" aria-valuenow="25" aria-valuemin="40" aria-valuemax="63"></div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="m-widget4__ext">
                                                <a href="#" class="m-btn m-btn--hover-brand m-btn--pill btn btn-sm btn-secondary">Profile</a>
                                            </div>
                                        </div>
                                        <div class="m-widget4__item">
                                            <div class="m-widget4__img m-widget4__img--pic">
                                                <img src="../../assets/app/media/img/users/100_14.jpg" alt="">
                                            </div>
                                            <div class="m-widget4__info">
                                                <span class="m-widget4__title">Milano Esco
                                                </span>
                                                <br>
                                                <span class="m-widget4__sub">Sr. Operations Executive, Housekeeping
                                                </span>
                                            </div>
                                            <div class="m-widget4__progress">
                                                <div class="m-widget4__progress-wrapper">
                                                    <span class="m-widget17__progress-number">33%</span>
                                                    <span class="m-widget17__progress-label">Tickets</span>
                                                    <div class="progress m-progress--sm">
                                                        <div class="progress-bar bg-success" role="progressbar" style="width: 33%;" aria-valuenow="45" aria-valuemin="0" aria-valuemax="33"></div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="m-widget4__ext">
                                                <a href="#" class="m-btn m-btn--hover-brand m-btn--pill btn btn-sm btn-secondary">Follow</a>
                                            </div>
                                        </div>
                                        <div class="m-widget4__item">
                                            <div class="m-widget4__img m-widget4__img--pic">
                                                <img src="../../assets/app/media/img/users/100_11.jpg" alt="">
                                            </div>
                                            <div class="m-widget4__info">
                                                <span class="m-widget4__title">Nick Bold
                                                </span>
                                                <br>
                                                <span class="m-widget4__sub">Web Developer, Facebook Inc
                                                </span>
                                            </div>
                                            <div class="m-widget4__progress">
                                                <div class="m-widget4__progress-wrapper">
                                                    <span class="m-widget17__progress-number">13%</span>
                                                    <span class="m-widget17__progress-label">London</span>
                                                    <div class="progress m-progress--sm">
                                                        <div class="progress-bar bg-brand" role="progressbar" style="width: 13%;" aria-valuenow="65" aria-valuemin="0" aria-valuemax="13"></div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="m-widget4__ext">
                                                <a href="#" class="m-btn m-btn--hover-brand m-btn--pill btn btn-sm btn-secondary">Follow</a>
                                            </div>
                                        </div>
                                        <div class="m-widget4__item">
                                            <div class="m-widget4__img m-widget4__img--pic">
                                                <img src="../../assets/app/media/img/users/100_1.jpg" alt="">
                                            </div>
                                            <div class="m-widget4__info">
                                                <span class="m-widget4__title">Wiltor Delton
                                                </span>
                                                <br>
                                                <span class="m-widget4__sub">Project Manager, Amazon Inc
                                                </span>
                                            </div>
                                            <div class="m-widget4__progress">
                                                <div class="m-widget4__progress-wrapper">
                                                    <span class="m-widget17__progress-number">93%</span>
                                                    <span class="m-widget17__progress-label">New York</span>
                                                    <div class="progress m-progress--sm">
                                                        <div class="progress-bar bg-danger" role="progressbar" style="width: 93%;" aria-valuenow="25" aria-valuemin="0" aria-valuemax="93"></div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="m-widget4__ext">
                                                <a href="#" class="m-btn m-btn--hover-brand m-btn--pill btn btn-sm btn-secondary">Follow</a>
                                            </div>
                                        </div>
                                        <div class="m-widget4__item">
                                            <div class="m-widget4__img m-widget4__img--pic">
                                                <img src="../../assets/app/media/img/users/100_6.jpg" alt="">
                                            </div>
                                            <div class="m-widget4__info">
                                                <span class="m-widget4__title">Sam Stone
                                                </span>
                                                <br>
                                                <span class="m-widget4__sub">Project Manager, Kilpo Inc
                                                </span>
                                            </div>
                                            <div class="m-widget4__progress">
                                                <div class="m-widget4__progress-wrapper">
                                                    <span class="m-widget17__progress-number">50%</span>
                                                    <span class="m-widget17__progress-label">New York</span>
                                                    <div class="progress m-progress--sm">
                                                        <div class="progress-bar bg-warning" role="progressbar" style="width: 50%;" aria-valuenow="50" aria-valuemin="0" aria-valuemax="50"></div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="m-widget4__ext">
                                                <a href="#" class="m-btn m-btn--hover-brand m-btn--pill btn btn-sm btn-secondary">Follow</a>
                                            </div>
                                        </div>--%>
                                    </div>
                                </div>
                                <div class="tab-pane" id="m_widget4_tab2_content">
                                </div>
                                <div class="tab-pane" id="m_widget4_tab3_content">
                                </div>
                            </div>
                        </div>
                    </div>

                </div>


            </div>

            <div class="row">

                <div class="col-xl-12" id="dvBlock3">
                    <div class="loader"></div>
                    <div class="m-portlet m-portlet--bordered-semi m-portlet--full-height invisible">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <h3 class="m-portlet__head-text" style="margin-right: 12px;">Bifurcation of Tickets with status
                                    </h3>
                                    <span class="m-badge m-badge--danger m-badge--wide">Open
                                    </span>

                                </div>
                            </div>
                        </div>
                        <div class="m-portlet__body  m-portlet__body--no-padding" style="padding-top: 0rem;">
                            <div class="row m-row--no-padding m-row--col-separator-xl">
                                <div class="col-md-12 col-lg-6 col-xl-4">

                                    <!--begin::Total Profit-->
                                    <div class="m-widget24">
                                        <div class="m-widget24__item">
                                            <h4 class="m-widget24__title">Assigned
                                            </h4>
                                            <br>
                                            <span class="m-widget24__desc">Tickets in Assigned state
                                            </span>
                                            <span class="m-widget24__stats m--font-info" id="ASSIGNEDPerCount"></span>
                                            <div class="m--space-10"></div>
                                            <div class="progress m-progress--sm">
                                                <div class="progress-bar m--bg-info" id="ASSIGNEDProgress" role="progressbar" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                            </div>
                                            <span class="m-widget24__change">From overall Open Tickets
                                            </span>
                                            <span class="m-widget24__number" id="ASSIGNEDPercent"></span>
                                        </div>
                                    </div>

                                    <!--end::Total Profit-->
                                </div>
                                <div class="col-md-12 col-lg-6 col-xl-4">

                                    <!--begin::New Feedbacks-->
                                    <div class="m-widget24">
                                        <div class="m-widget24__item">
                                            <h4 class="m-widget24__title">Accepted
                                            </h4>
                                            <br>
                                            <span class="m-widget24__desc">Tickets accepted by Users
                                            </span>
                                            <span class="m-widget24__stats m--font-success" id="ACCEPTEDPerCount"></span>
                                            <div class="m--space-10"></div>
                                            <div class="progress m-progress--sm">
                                                <div class="progress-bar m--bg-success" id="ACCEPTEDProgress" role="progressbar" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                            </div>
                                            <span class="m-widget24__change">Change
                                            </span>
                                            <span class="m-widget24__number" id="ACCEPTEDPercent"></span>
                                        </div>
                                    </div>

                                    <!--end::New Feedbacks-->
                                </div>
                                <div class="col-md-12 col-lg-6 col-xl-4">

                                    <!--begin::New Orders-->
                                    <div class="m-widget24">
                                        <div class="m-widget24__item">
                                            <h4 class="m-widget24__title">In Progress
                                            </h4>
                                            <br>
                                            <span class="m-widget24__desc">Work in Progress on tickets
                                            </span>
                                            <span class="m-widget24__stats m--font-warning" id="INPROGRESSPerCount"></span>
                                            <div class="m--space-10"></div>
                                            <div class="progress m-progress--sm">
                                                <div class="progress-bar m--bg-warning" id="INPROGRESSProgress" role="progressbar" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                            </div>
                                            <span class="m-widget24__change">Change
                                            </span>
                                            <span class="m-widget24__number" id="INPROGRESSPercent"></span>
                                        </div>
                                    </div>

                                    <!--end::New Orders-->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>


            <div class="row">

                <div class="col-xl-12" id="dvBlock4">
                    <div class="loader"></div>
                    <div class="m-portlet m-portlet--bordered-semi m-portlet--full-height invisible">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <h3 class="m-portlet__head-text">Analysis on tickets for past 12 Months
                                    </h3>
                                </div>
                            </div>
                        </div>
                        <div class="m-portlet__body">

                            <!--begin::Widget 6-->
                            <div class="m-widget15">
                                <div class="m-widget15__chart" style="height: 180px;">
                                    <div class="chartjs-size-monitor" style="position: absolute; inset: 0px; overflow: hidden; pointer-events: none; visibility: hidden; z-index: -1;">
                                        <div class="chartjs-size-monitor-expand" style="position: absolute; left: 0; top: 0; right: 0; bottom: 0; overflow: hidden; pointer-events: none; visibility: hidden; z-index: -1;">
                                            <div style="position: absolute; width: 1000000px; height: 1000000px; left: 0; top: 0"></div>
                                        </div>
                                        <div class="chartjs-size-monitor-shrink" style="position: absolute; left: 0; top: 0; right: 0; bottom: 0; overflow: hidden; pointer-events: none; visibility: hidden; z-index: -1;">
                                            <div style="position: absolute; width: 200%; height: 200%; left: 0; top: 0"></div>
                                        </div>
                                    </div>
                                    <canvas id="m_chart_sales_stats" width="358" height="270" class="chartjs-render-monitor" style="display: block; height: 180px; width: 239px;"></canvas>
                                </div>



                                <div class="m-widget15__items">
                                    <div class="row">
                                        <div class="col">
                                            <div class="m-widget15__item">
                                                <span class="m-widget15__stats" id="Block4OpenPer"></span>
                                                <span class="m-widget15__text ">Average Percent of Tickets every Month
                                                </span>

                                                <span class="m-badge m-badge--danger m-badge--wide">Open
                                                </span>

                                                <div class="m--space-10"></div>
                                                <div class="progress m-progress--sm">
                                                    <div class="progress-bar bg-danger" role="progressbar" id="Block4OpenProgress" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="m-widget15__item">
                                                <span class="m-widget15__stats" id="Block4ParkedPer"></span>
                                                <span class="m-widget15__text ">Average Percent of Tickets every Month
                                                </span>

                                                <span class="m-badge m-badge--warning m-badge--wide">Parked
                                                </span>
                                                <div class="m--space-10"></div>
                                                <div class="progress m-progress--sm">
                                                    <div class="progress-bar bg-warning" role="progressbar" id="Block4ParkedProgress" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <div class="m-widget15__item">
                                                <span class="m-widget15__stats" id="Block4ClosedPer"></span>
                                                <span class="m-widget15__text ">Average Percent of Tickets every Month
                                                </span>

                                                <span class="m-badge m-badge--success m-badge--wide">Closed
                                                </span>
                                                <div class="m--space-10"></div>
                                                <div class="progress m-progress--sm">
                                                    <div class="progress-bar bg-success" role="progressbar" id="Block4ClosedProgress" aria-valuenow="75" aria-valuemin="0" aria-valuemax="100"></div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col">
                                            <div class="m-widget15__item">
                                                <span class="m-widget15__stats" id="Block4ExpiredPer"></span>
                                                <span class="m-widget15__text ">Average Percent of Tickets every Month
                                                </span>

                                                <span class="m-badge m-badge--secondary m-badge--wide">Expired
                                                </span>
                                                <div class="m--space-10"></div>
                                                <div class="progress m-progress--sm">
                                                    <div class="progress-bar bg-primary" role="progressbar" id="Block4ExpiredProgress" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100"></div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                            </div>

                            <!--end::Widget 6-->
                        </div>

                    </div>


                </div>

            </div>


            <div class="row">

                <div class="col-xl-6">
                    <div class="m-portlet m-portlet--mobile ">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <h3 class="m-portlet__head-text">TOP 10 Tickets highest Downtime
                                    </h3>
                                </div>
                            </div>
                            <div class="m-portlet__head-tools">
                                <ul class="m-portlet__nav">
                                    <li class="m-portlet__nav-item">
                                        <div class="m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover" aria-expanded="true">
                                            <a href="#" class="m-portlet__nav-link btn btn-lg btn-secondary  m-btn m-btn--icon m-btn--icon-only m-btn--pill  m-dropdown__toggle">
                                                <i class="la la-ellipsis-h m--font-brand"></i>
                                            </a>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="m-portlet__body">

                            <!--begin: Datatable -->
                            <div class="form-group m-form__group row" style="padding-left: 1%;">

                                <div class="" id="m_table_1" style="overflow-x: auto;">
                                    <div>
                                        <div class="m-datatable m-datatable--default m-datatable--brand m-datatable--loaded">
                                            <table class="table table-striped- table-bordered table-hover table-checkable m-datatable__table" cellspacing="0" rules="all" border="1" id="ContentPlaceHolder1_gvCTT_Report" style="border-collapse: collapse; display: block; min-height: 300px; overflow-x: auto;">
                                                <thead class="m-datatable__head">
                                                    <tr style="color: white; background-color: rgb(58, 192, 242); left: 0px;" class="m-datatable__row">
                                                        <th scope="col" style="width: 80px;" class="m-datatable__cell m-datatable__cell--sort"><span style="width: 110px;">Ticket No</span></th>
                                                        <th scope="col" class="m-datatable__cell m-datatable__cell--sort"><span style="width: 110px;">Department</span></th>
                                                        <th scope="col" class="m-datatable__cell m-datatable__cell--sort"><span style="width: 110px;">Category</span></th>
                                                        <th scope="col" class="m-datatable__cell m-datatable__cell--sort"><span style="width: 110px;">Sub Category</span></th>
                                                        <th scope="col" class="m-datatable__cell m-datatable__cell--sort"><span style="width: 110px;">Ticket Date &amp; Time</span></th>
                                                        <th scope="col" class="m-datatable__cell m-datatable__cell--sort"><span style="width: 110px;">Request Status</span></th>
                                                        <th scope="col" class="m-datatable__cell m-datatable__cell--sort"><span style="width: 110px;">Action Status</span></th>
                                                        <th scope="col" class="m-datatable__cell m-datatable__cell--sort"><span style="width: 110px;">Down Time</span></th>
                                                    </tr>
                                                </thead>
                                                <tbody style="" class="m-datatable__body">
                                                    <tr data-row="0" class="m-datatable__row" style="left: 0px;">
                                                        <td data-field="Ticket No" class="m-datatable__cell"><span style="width: 110px;">
                                                            <input type="hidden" name="ctl00$ContentPlaceHolder1$gvCTT_Report$ctl02$hdnTicketID" id="ContentPlaceHolder1_gvCTT_Report_hdnTicketID_0" value="31494">
                                                            <a id="ContentPlaceHolder1_gvCTT_Report_lnkTicketID_0" href="javascript:__doPostBack('ctl00$ContentPlaceHolder1$gvCTT_Report$ctl02$lnkTicketID','')">TKT4156</a></span></td>
                                                        <td data-field="Department" class="m-datatable__cell"><span style="width: 110px;">Housekeeping</span></td>
                                                        <td data-field="Category" class="m-datatable__cell"><span style="width: 110px;">Housekeeping</span></td>
                                                        <td data-field="Sub Category" class="m-datatable__cell"><span style="width: 110px;">&nbsp;</span></td>
                                                        <td data-field="Ticket Date &amp; Time" class="m-datatable__cell"><span style="width: 110px;">28 Mar 2021   1:37AM</span></td>
                                                        <td data-field="Request Status" class="m-datatable__cell"><span style="width: 110px;"><span class="m-badge m-badge--secondary m-badge--wide">Parked</span></span></td>
                                                        <td data-field="Action Status" class="m-datatable__cell"><span style="width: 110px;"><span class="m-badge m-badge-- m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-">Hold</span></span></td>
                                                        <td data-field="Down Time" class="m-datatable__cell"><span style="width: 110px;">24h 22m 38s</span></td>
                                                    </tr>
                                                    <tr data-row="1" class="m-datatable__row m-datatable__row--even" style="left: 0px;">
                                                        <td data-field="Ticket No" class="m-datatable__cell"><span style="width: 110px;">
                                                            <input type="hidden" name="ctl00$ContentPlaceHolder1$gvCTT_Report$ctl03$hdnTicketID" id="ContentPlaceHolder1_gvCTT_Report_hdnTicketID_1" value="31493">
                                                            <a id="ContentPlaceHolder1_gvCTT_Report_lnkTicketID_1" href="javascript:__doPostBack('ctl00$ContentPlaceHolder1$gvCTT_Report$ctl03$lnkTicketID','')">TKT4154</a></span></td>
                                                        <td data-field="Department" class="m-datatable__cell"><span style="width: 110px;">Engineering</span></td>
                                                        <td data-field="Category" class="m-datatable__cell"><span style="width: 110px;">Plumbing</span></td>
                                                        <td data-field="Sub Category" class="m-datatable__cell"><span style="width: 110px;">Pipe Leaking</span></td>
                                                        <td data-field="Ticket Date &amp; Time" class="m-datatable__cell"><span style="width: 110px;">28 Mar 2021   1:30AM</span></td>
                                                        <td data-field="Request Status" class="m-datatable__cell"><span style="width: 110px;"><span class="m-badge m-badge--danger m-badge--wide">Open</span></span></td>
                                                        <td data-field="Action Status" class="m-datatable__cell"><span style="width: 110px;"><span class="m-badge m-badge--info m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-info">Assigned</span></span></td>
                                                        <td data-field="Down Time" class="m-datatable__cell"><span style="width: 110px;">12h 18m 55s</span></td>
                                                    </tr>
                                                    <tr data-row="2" class="m-datatable__row" style="left: 0px;">
                                                        <td data-field="Ticket No" class="m-datatable__cell"><span style="width: 110px;">
                                                            <input type="hidden" name="ctl00$ContentPlaceHolder1$gvCTT_Report$ctl04$hdnTicketID" id="ContentPlaceHolder1_gvCTT_Report_hdnTicketID_2" value="31488">
                                                            <a id="ContentPlaceHolder1_gvCTT_Report_lnkTicketID_2" href="javascript:__doPostBack('ctl00$ContentPlaceHolder1$gvCTT_Report$ctl04$lnkTicketID','')">TKT31488</a></span></td>
                                                        <td data-field="Department" class="m-datatable__cell"><span style="width: 110px;">Housekeeping</span></td>
                                                        <td data-field="Category" class="m-datatable__cell"><span style="width: 110px;">Housekeeping</span></td>
                                                        <td data-field="Sub Category" class="m-datatable__cell"><span style="width: 110px;">cleaning required</span></td>
                                                        <td data-field="Ticket Date &amp; Time" class="m-datatable__cell"><span style="width: 110px;">24 Mar 2021  12:25PM</span></td>
                                                        <td data-field="Request Status" class="m-datatable__cell"><span style="width: 110px;"><span class="m-badge m-badge--secondary m-badge--wide">Expired</span></span></td>
                                                        <td data-field="Action Status" class="m-datatable__cell"><span style="width: 110px;"><span class="m-badge m-badge--secondary m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-secondary">Expired</span></span></td>
                                                        <td data-field="Down Time" class="m-datatable__cell"><span style="width: 110px;">00h 14m 59s</span></td>
                                                    </tr>
                                                    <tr data-row="3" class="m-datatable__row m-datatable__row--even" style="left: 0px;">
                                                        <td data-field="Ticket No" class="m-datatable__cell"><span style="width: 110px;">
                                                            <input type="hidden" name="ctl00$ContentPlaceHolder1$gvCTT_Report$ctl05$hdnTicketID" id="ContentPlaceHolder1_gvCTT_Report_hdnTicketID_3" value="31487">
                                                            <a id="ContentPlaceHolder1_gvCTT_Report_lnkTicketID_3" href="javascript:__doPostBack('ctl00$ContentPlaceHolder1$gvCTT_Report$ctl05$lnkTicketID','')">TKT31487</a></span></td>
                                                        <td data-field="Department" class="m-datatable__cell"><span style="width: 110px;">Housekeeping</span></td>
                                                        <td data-field="Category" class="m-datatable__cell"><span style="width: 110px;">Housekeeping</span></td>
                                                        <td data-field="Sub Category" class="m-datatable__cell"><span style="width: 110px;">cleaning required</span></td>
                                                        <td data-field="Ticket Date &amp; Time" class="m-datatable__cell"><span style="width: 110px;">24 Mar 2021  12:25PM</span></td>
                                                        <td data-field="Request Status" class="m-datatable__cell"><span style="width: 110px;"><span class="m-badge m-badge--secondary m-badge--wide">Expired</span></span></td>
                                                        <td data-field="Action Status" class="m-datatable__cell"><span style="width: 110px;"><span class="m-badge m-badge--secondary m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-secondary">Expired</span></span></td>
                                                        <td data-field="Down Time" class="m-datatable__cell"><span style="width: 110px;">00h 14m 59s</span></td>
                                                    </tr>
                                                    <tr data-row="4" class="m-datatable__row" style="left: 0px;">
                                                        <td data-field="Ticket No" class="m-datatable__cell"><span style="width: 110px;">
                                                            <input type="hidden" name="ctl00$ContentPlaceHolder1$gvCTT_Report$ctl06$hdnTicketID" id="ContentPlaceHolder1_gvCTT_Report_hdnTicketID_4" value="31486">
                                                            <a id="ContentPlaceHolder1_gvCTT_Report_lnkTicketID_4" href="javascript:__doPostBack('ctl00$ContentPlaceHolder1$gvCTT_Report$ctl06$lnkTicketID','')">TKT31486</a></span></td>
                                                        <td data-field="Department" class="m-datatable__cell"><span style="width: 110px;">Housekeeping</span></td>
                                                        <td data-field="Category" class="m-datatable__cell"><span style="width: 110px;">Housekeeping</span></td>
                                                        <td data-field="Sub Category" class="m-datatable__cell"><span style="width: 110px;">cleaning required</span></td>
                                                        <td data-field="Ticket Date &amp; Time" class="m-datatable__cell"><span style="width: 110px;">24 Mar 2021  12:22PM</span></td>
                                                        <td data-field="Request Status" class="m-datatable__cell"><span style="width: 110px;"><span class="m-badge m-badge--secondary m-badge--wide">Expired</span></span></td>
                                                        <td data-field="Action Status" class="m-datatable__cell"><span style="width: 110px;"><span class="m-badge m-badge--secondary m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-secondary">Expired</span></span></td>
                                                        <td data-field="Down Time" class="m-datatable__cell"><span style="width: 110px;">00h 15m 00s</span></td>
                                                    </tr>
                                                    <tr data-row="5" class="m-datatable__row m-datatable__row--even" style="left: 0px;">
                                                        <td data-field="Ticket No" class="m-datatable__cell"><span style="width: 110px;">
                                                            <input type="hidden" name="ctl00$ContentPlaceHolder1$gvCTT_Report$ctl07$hdnTicketID" id="ContentPlaceHolder1_gvCTT_Report_hdnTicketID_5" value="31485">
                                                            <a id="ContentPlaceHolder1_gvCTT_Report_lnkTicketID_5" href="javascript:__doPostBack('ctl00$ContentPlaceHolder1$gvCTT_Report$ctl07$lnkTicketID','')">TKT31485</a></span></td>
                                                        <td data-field="Department" class="m-datatable__cell"><span style="width: 110px;">Housekeeping</span></td>
                                                        <td data-field="Category" class="m-datatable__cell"><span style="width: 110px;">Housekeeping</span></td>
                                                        <td data-field="Sub Category" class="m-datatable__cell"><span style="width: 110px;">cleaning required</span></td>
                                                        <td data-field="Ticket Date &amp; Time" class="m-datatable__cell"><span style="width: 110px;">24 Mar 2021  12:22PM</span></td>
                                                        <td data-field="Request Status" class="m-datatable__cell"><span style="width: 110px;"><span class="m-badge m-badge--secondary m-badge--wide">Expired</span></span></td>
                                                        <td data-field="Action Status" class="m-datatable__cell"><span style="width: 110px;"><span class="m-badge m-badge--secondary m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-secondary">Expired</span></span></td>
                                                        <td data-field="Down Time" class="m-datatable__cell"><span style="width: 110px;">00h 15m 00s</span></td>
                                                    </tr>
                                                    <tr data-row="6" class="m-datatable__row" style="left: 0px;">
                                                        <td data-field="Ticket No" class="m-datatable__cell"><span style="width: 110px;">
                                                            <input type="hidden" name="ctl00$ContentPlaceHolder1$gvCTT_Report$ctl08$hdnTicketID" id="ContentPlaceHolder1_gvCTT_Report_hdnTicketID_6" value="31484">
                                                            <a id="ContentPlaceHolder1_gvCTT_Report_lnkTicketID_6" href="javascript:__doPostBack('ctl00$ContentPlaceHolder1$gvCTT_Report$ctl08$lnkTicketID','')">TKT31484</a></span></td>
                                                        <td data-field="Department" class="m-datatable__cell"><span style="width: 110px;">Housekeeping</span></td>
                                                        <td data-field="Category" class="m-datatable__cell"><span style="width: 110px;">Housekeeping</span></td>
                                                        <td data-field="Sub Category" class="m-datatable__cell"><span style="width: 110px;">cleaning required</span></td>
                                                        <td data-field="Ticket Date &amp; Time" class="m-datatable__cell"><span style="width: 110px;">24 Mar 2021  12:22PM</span></td>
                                                        <td data-field="Request Status" class="m-datatable__cell"><span style="width: 110px;"><span class="m-badge m-badge--secondary m-badge--wide">Expired</span></span></td>
                                                        <td data-field="Action Status" class="m-datatable__cell"><span style="width: 110px;"><span class="m-badge m-badge--secondary m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-secondary">Expired</span></span></td>
                                                        <td data-field="Down Time" class="m-datatable__cell"><span style="width: 110px;">00h 15m 00s</span></td>
                                                    </tr>

                                                </tbody>
                                            </table>

                                        </div>
                                    </div>

                                </div>



                            </div>

                            <!--end: Datatable -->
                        </div>
                    </div>
                </div>


                <div class="col-xl-6" id="dvBlock5">
                    <div class="loader"></div>
                    <div class="m-portlet m-portlet--mobile invisible">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <h3 class="m-portlet__head-text">Priority-wise Analysis
                                    </h3>
                                </div>
                            </div>
                            <div class="m-portlet__head-tools">
                                <ul class="m-portlet__nav">
                                    <li class="m-portlet__nav-item">
                                        <div class="m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover" aria-expanded="true">
                                            <a href="#" class="m-portlet__nav-link btn btn-lg btn-secondary  m-btn m-btn--icon m-btn--icon-only m-btn--pill  m-dropdown__toggle">
                                                <i class="la la-ellipsis-h m--font-brand"></i>
                                            </a>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="m-portlet__body">
                            <div class="m-widget25" id="appendBlock5Content" >
                                <div class="m-widget25--progress" style="margin: 40px auto 0; padding-top: 0px; display: none">
                                    <div class="m-widget25__progress">
                                        <span class="m-widget25__progress-number">##PERCENT## %
                                        </span>
                                        <div class="m--space-10"></div>
                                        <div class="progress m-progress--sm">
                                            <div class="progress-bar m--bg-danger" role="progressbar" style="width: ##PERCENT##%;" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                        </div>
                                        <span class="m-widget25__progress-sub">##PRIORITY##
                                        </span>
                                    </div>
                                    <div class="m-widget25__progress">
                                        <span class="m-widget25__progress-number">##DOWNTIME##
                                        </span>
                                        <span class="m-widget25__progress-sub"><b>Average downtime</b> for Closed Tickets
                                        </span>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>


            <div class="row">
                <div class="col-xl-6" id="dvBlock6">
                    <div class="loader"></div>
                    <div class="m-portlet m-portlet--full-height invisible">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <h3 class="m-portlet__head-text">Category-wise Analysis
                                    </h3>
                                </div>
                            </div>
                            <div class="m-portlet__head-tools">
                                <ul class="nav nav-pills nav-pills--brand m-nav-pills--align-right m-nav-pills--btn-pill m-nav-pills--btn-sm" role="tablist">
                                    <li class="nav-item m-tabs__item">
                                        <a class="nav-link m-tabs__link " data-toggle="tab" href="#m_widget11_tab1_content" role="tab">Last Month
                                        </a>
                                    </li>
                                    <li class="nav-item m-tabs__item">
                                        <a class="nav-link m-tabs__link active" data-toggle="tab" href="#m_widget11_tab2_content" role="tab">This Month
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="m-portlet__body">
                            <div class="tab-content">
                                <div class="tab-pane" id="m_widget11_tab1_content">

                                    <!--begin::Widget 11-->
                                    <div class="m-widget11">
                                        <div class="table-responsive">

                                            <!--begin::Table-->
                                            <table class="table" id="LastMonth">

                                                <!--begin::Thead-->
                                                <thead>
                                                    <tr>
                                                        <td class="m-widget11__app">Category</td>
                                                        <td class="m-widget11__sales">Open</td>
                                                        <td class="m-widget11__change">Parked</td>
                                                        <td class="m-widget11__price">Closed</td>
                                                        <td class="m-widget11__total m--align-right">Total</td>
                                                    </tr>
                                                </thead>

                                                <!--end::Thead-->

                                                <!--begin::Tbody-->
                                                <tbody>
                                                </tbody>

                                                <!--end::Tbody-->
                                            </table>

                                            <!--end::Table-->
                                        </div>
                                        <div class="m-widget11__action m--align-right">
                                            <button type="button" class="btn m-btn--pill btn-secondary m-btn m-btn--custom m-btn--hover-brand">Generate Report</button>
                                        </div>
                                    </div>

                                    <!--end::Widget 11-->
                                </div>
                                <div class="tab-pane active" id="m_widget11_tab2_content">

                                    <!--begin::Widget 11-->
                                    <div class="m-widget11">
                                        <div class="table-responsive">

                                            <!--begin::Table-->
                                            <table class="table" id="ThisMonth">

                                                <!--begin::Thead-->
                                                <thead>
                                                    <tr>
                                                        <td class="m-widget11__app">Category</td>
                                                        <td class="m-widget11__sales">Open</td>
                                                        <td class="m-widget11__change">Parked</td>
                                                        <td class="m-widget11__price">Closed</td>
                                                        <td class="m-widget11__total m--align-right">Total</td>
                                                    </tr>
                                                </thead>

                                                <!--end::Thead-->

                                                <!--begin::Tbody-->
                                                <tbody>
                                                </tbody>

                                                <!--end::Tbody-->
                                            </table>

                                            <!--end::Table-->
                                        </div>
                                        <div class="m-widget11__action m--align-right">
                                            <button type="button" class="btn m-btn--pill btn-secondary m-btn m-btn--custom m-btn--hover-brand">Generate Report</button>
                                        </div>
                                    </div>

                                    <!--end::Widget 11-->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-xl-6" id="dvBlock7">
                    <div class="loader"></div>
                    <div class="m-portlet m-portlet--full-height invisible">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <h3 class="m-portlet__head-text">Department-wise Analysis
                                    </h3>
                                </div>
                            </div>
                            <div class="m-portlet__head-tools">
                                <ul class="nav nav-pills nav-pills--brand m-nav-pills--align-right m-nav-pills--btn-pill m-nav-pills--btn-sm" role="tablist">
                                    <li class="nav-item m-tabs__item">
                                        <a class="nav-link m-tabs__link " data-toggle="tab" href="#m_widget11_tab1_content_dep" role="tab">Last Month
                                        </a>
                                    </li>
                                    <li class="nav-item m-tabs__item">
                                        <a class="nav-link m-tabs__link active" data-toggle="tab" href="#m_widget11_tab2_content_dep" role="tab">This Month
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="m-portlet__body">
                            <div class="tab-content">
                                <div class="tab-pane " id="m_widget11_tab1_content_dep">

                                    <!--begin::Widget 11-->
                                    <div class="m-widget11">
                                        <div class="table-responsive">

                                            <!--begin::Table-->
                                            <table class="table" id="LastMonthDep">

                                                <!--begin::Thead-->
                                                <thead>
                                                    <tr>
                                                        <td class="m-widget11__app">Department</td>
                                                        <td class="m-widget11__sales">Open</td>
                                                        <td class="m-widget11__change">Parked</td>
                                                        <td class="m-widget11__price">Closed</td>
                                                        <td class="m-widget11__total m--align-right">Total</td>
                                                    </tr>
                                                </thead>

                                                <!--end::Thead-->

                                                <!--begin::Tbody-->
                                                <tbody>
                                                </tbody>

                                                <!--end::Tbody-->
                                            </table>

                                            <!--end::Table-->
                                        </div>
                                        <div class="m-widget11__action m--align-right">
                                            <button type="button" class="btn m-btn--pill btn-secondary m-btn m-btn--custom m-btn--hover-brand">Generate Report</button>
                                        </div>
                                    </div>

                                    <!--end::Widget 11-->
                                </div>
                                <div class="tab-pane active" id="m_widget11_tab2_content_dep">

                                    <!--begin::Widget 11-->
                                    <div class="m-widget11">
                                        <div class="table-responsive">

                                            <!--begin::Table-->
                                            <table class="table" id="ThisMonthDep">

                                                <!--begin::Thead-->
                                                <thead>
                                                    <tr>
                                                        <td class="m-widget11__app">Department</td>
                                                        <td class="m-widget11__sales">Open</td>
                                                        <td class="m-widget11__change">Parked</td>
                                                        <td class="m-widget11__price">Closed</td>
                                                        <td class="m-widget11__total m--align-right">Total</td>
                                                    </tr>
                                                </thead>

                                                <!--end::Thead-->
                                                <tbody></tbody>
                                            </table>

                                            <!--end::Table-->
                                        </div>
                                        <div class="m-widget11__action m--align-right">
                                            <button type="button" class="btn m-btn--pill btn-secondary m-btn m-btn--custom m-btn--hover-brand">Generate Report</button>
                                        </div>
                                    </div>

                                    <!--end::Widget 11-->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
