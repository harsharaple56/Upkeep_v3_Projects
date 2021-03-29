<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard_Admin.aspx.cs" Inherits="Upkeep_v3.Dashboard_v2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="m-grid__item m-grid__item--fluid m-wrapper" style="margin-bottom: 20px;">

        <div class="m-subheader ">
            <div class="d-flex align-items-center">
                <div class="mr-auto">
                    <h3 class="m-subheader__title ">Dashboard</h3>

                    <span class="m-subheader__daterange" id="m_dashboard_daterangepicker">
                        <span class="m-subheader__daterange-label">
                            <span class="m-subheader__daterange-title">Today:</span>
                            <span class="m-subheader__daterange-date m--font-brand">Mar 29</span>
                        </span>
                        <a href="#" class="btn btn-sm btn-brand m-btn m-btn--icon m-btn--icon-only m-btn--custom m-btn--pill">
                            <i class="la la-angle-down"></i>
                        </a>
                    </span>
                </div>
                <div>
                    <div class="btn-group m-btn-group m-btn-group--pill" role="group" aria-label="...">
                        <asp:Button ID="btn_Employee_Dashboard" runat="server" Text="Your Account Dashboard" class="m-btn btn btn-secondary" OnClick="btn_Employee_Dashboard_Click"/>
                        <asp:Button ID="btn_Admin_Dashboard" runat="server" Text="Switch to Admin Dashboard" class="m-btn btn btn-success" OnClick="btn_Admin_Dashboard_Click"/>
                       
                    </div>
                </div>

            </div>
        </div>

    </div>




    <div class="m-porlet">
        <div class="row">

            <div class="col-xl-6">

                <!--begin:: Ticketing Section-->
                <div class="m-portlet m-portlet--bordered-semi m-portlet--full-height  m-portlet--rounded-force">

                    <div class="m-portlet__body">
                        <div class="m-widget19">
                            
                            <div class="m-widget19__content">
                                <div class="m-widget19__header">
                                    <div class="m-widget19__user-img">
                                        <img class="m-widget19__img" style="width: 6rem;" src="../../assets/app/media/img/Dashboard_Icons/tkt.png" alt="">
                                    </div>
                                    <div class="m-widget19__info">
                                        <span class="m-widget19__username">Total tickets
                                        </span>
                                        <br>
                                        <span class="m-widget19__time">Total No. of Tickets raised
                                        </span>
                                    </div>
                                    <div class="m-widget19__stats">
                                        <asp:Label ID="lbl_Tkt_Total" runat="server" class="m-widget19__number m--font-brand">18</asp:Label>
                                        
                                        <span class="m-widget19__comment">Tickets
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
                                        <asp:Label ID="lbl_Tkt_open" runat="server" class="m-widget4__number m--font-accent">500</asp:Label>
                                       
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
                                            <asp:Label ID="lbl_Tkt_Closed" runat="server" class="m-widget4__number m--font-accent" >64</asp:Label>
                                            
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
                                            <asp:Label ID="Label1" runat="server" class="m-widget4__number m--font-accent">1800</asp:Label>
                                           
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
                                            <asp:Label ID="Label2" runat="server" class="m-widget4__number m--font-accent">19</asp:Label>
                                          
                                        </span>
                                    </div>
                                </div>
                            </div>



                            <div class="m-widget19__action">
                                <button type="button" class="btn m-btn--pill btn-secondary m-btn m-btn--hover-brand m-btn--custom " onclick="btnClick_Tkt_Analyse">
                                    <i class="flaticon-diagram"></i>
                                    Analyze Tickets Data

                                </button>
                            </div>
                        </div>
                    </div>
                </div>

                <!--end:: Ticketing Section-->
            </div>

            <div class="col-xl-6">

                <!--begin:: Ticketing Section-->
                <div class="m-portlet m-portlet--bordered-semi m-portlet--full-height  m-portlet--rounded-force">


                    <div class="m-portlet__body">
                        <div class="m-widget19">

                            
                            <div class="m-widget19__content">
                                <div class="m-widget19__header">
                                    <div class="m-widget19__user-img">
                                        <img class="m-widget19__img" src="../../assets/app/media/img/Dashboard_Icons/chk.png" style="width: 6rem;" alt="">
                                    </div>
                                    <div class="m-widget19__info">
                                        <span class="m-widget19__username">Total Checklists
                                        </span>
                                        <br>
                                        <span class="m-widget19__time">Total No. of Checklists generated
                                        </span>
                                    </div>
                                    <div class="m-widget19__stats">
                                        <span class="m-widget19__number m--font-brand">1800
                                        </span>
                                        <span class="m-widget19__comment">Checklists
                                        </span>
                                    </div>

                                </div>

                                <div class="m-widget19__body">
                                    Get in-depth insights & Analysis on all Checklist data. 
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
                                        <span class="m-widget4__text">No. of Checklists with Status
                                            <span class="m-badge m-badge--danger m-badge--wide">Open</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__number m--font-accent">500</span>
                                    </div>
                                </div>
                                <div class="m-widget4__item">
                                    <div class="m-widget4__ext">
                                        <a href="#" class="m-widget4__icon m--font-brand">
                                            <i class="flaticon-interface-3"></i>
                                        </a>
                                    </div>
                                    <div class="m-widget4__info">
                                        <span class="m-widget4__text">No. of Checklists with Status
                                            <span class="m-badge  m-badge--success m-badge--wide">Closed</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__stats m--font-info">
                                            <span class="m-widget4__number m--font-accent">64</span>
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
                                            <span class="m-widget4__number m--font-accent">1080</span>
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
                                            <span class="m-widget4__number m--font-accent">19</span>
                                        </span>
                                    </div>
                                </div>
                            </div>



                            <div class="m-widget19__action">
                                <button type="button" class="btn m-btn--pill btn-secondary m-btn m-btn--hover-brand m-btn--custom " onclick="btnClick_Tkt_Analyse">
                                    <i class="flaticon-diagram"></i>
                                    Analyze Checklist Data
                                </button>




                            </div>
                        </div>
                    </div>
                </div>

                <!--end:: Ticketing Section-->
            </div>

        </div>

        <div class="row">

            <div class="col-xl-6">

                <!--begin:: Ticketing Section-->
                <div class="m-portlet m-portlet--bordered-semi m-portlet--full-height  m-portlet--rounded-force">

                    <div class="m-portlet__body">
                        <div class="m-widget19">
                            
                            <div class="m-widget19__content">
                                <div class="m-widget19__header">
                                    <div class="m-widget19__user-img">
                                        <img class="m-widget19__img" style="width: 6rem;" src="../../assets/app/media/img/Dashboard_Icons/gp.png" alt="">
                                    </div>
                                    <div class="m-widget19__info">
                                        <span class="m-widget19__username">Total Gatepasses
                                        </span>
                                        <br>
                                        <span class="m-widget19__time">Total No. of Gatepass raised
                                        </span>
                                    </div>
                                    <div class="m-widget19__stats" style="line-height: 1;">
                                        <span class="m-widget19__number m--font-brand">18
                                        </span>
                                        <span class="m-widget19__comment">Gate Passes
                                        </span>
                                    </div>

                                </div>

                                <div class="m-widget19__body">
                                    Get in-depth insights & Analysis your Gatepass data. 
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
                                        <span class="m-widget4__number m--font-accent">500</span>
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
                                            <span class="m-badge m-badge--warning m-badge--wide">In Progress</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__number m--font-accent">500</span>
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
                                            <span class="m-badge  m-badge--info m-badge--wide">Approved</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__stats m--font-info">
                                            <span class="m-widget4__number m--font-accent">64</span>
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
                                            <span class="m-badge  m-badge--success m-badge--wide">Closed</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__stats m--font-info">
                                            <span class="m-widget4__number m--font-accent">64</span>
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
                                            <span class="m-badge m-badge--warning m-badge--wide">Hold</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__stats m--font-info">
                                            <span class="m-widget4__number m--font-accent">1080</span>
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
                                            <span class="m-badge m-badge--danger m-badge--wide">Rejected</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__stats m--font-info">
                                            <span class="m-widget4__number m--font-accent">1080</span>
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
                                            <span class="m-widget4__number m--font-accent">19</span>
                                        </span>
                                    </div>
                                </div>
                            </div>

                            <div class="m-widget19__action">
                                <button type="button" class="btn m-btn--pill btn-secondary m-btn m-btn--hover-brand m-btn--custom " onclick="btnClick_Tkt_Analyse">
                                    <i class="flaticon-diagram"></i>
                                    Analyze Gatepass Data

                                </button>
                            </div>




                        </div>
                    </div>
                </div>

                <!--end:: Ticketing Section-->
            </div>


            <div class="col-xl-6">

                <!--begin:: Ticketing Section-->
                <div class="m-portlet m-portlet--bordered-semi m-portlet--full-height  m-portlet--rounded-force">

                    <div class="m-portlet__body">
                        <div class="m-widget19">
                            
                            <div class="m-widget19__content">
                                <div class="m-widget19__header">
                                    <div class="m-widget19__user-img">
                                        <img class="m-widget19__img" style="width: 6rem;" src="../../assets/app/media/img/Dashboard_Icons/wp.png" alt="">
                                    </div>
                                    <div class="m-widget19__info">
                                        <span class="m-widget19__username">Total Gatepasses
                                        </span>
                                        <br>
                                        <span class="m-widget19__time">Total No. of Work Permits raised
                                        </span>
                                    </div>
                                    <div class="m-widget19__stats" style="line-height: 1;">
                                        <span class="m-widget19__number m--font-brand">18
                                        </span>
                                        <span class="m-widget19__comment">Work Permits
                                        </span>
                                    </div>

                                </div>

                                <div class="m-widget19__body">
                                    Get in-depth insights & Analysis your Work Permit data. 
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
                                        <span class="m-widget4__number m--font-accent">500</span>
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
                                            <span class="m-badge m-badge--warning m-badge--wide">In Progress</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__number m--font-accent">500</span>
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
                                            <span class="m-badge  m-badge--info m-badge--wide">Approved</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__stats m--font-info">
                                            <span class="m-widget4__number m--font-accent">64</span>
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
                                            <span class="m-badge  m-badge--success m-badge--wide">Closed</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__stats m--font-info">
                                            <span class="m-widget4__number m--font-accent">64</span>
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
                                            <span class="m-badge m-badge--warning m-badge--wide">Hold</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__stats m--font-info">
                                            <span class="m-widget4__number m--font-accent">1080</span>
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
                                            <span class="m-badge m-badge--danger m-badge--wide">Rejected</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__stats m--font-info">
                                            <span class="m-widget4__number m--font-accent">1080</span>
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
                                            <span class="m-widget4__number m--font-accent">19</span>
                                        </span>
                                    </div>
                                </div>
                            </div>

                            <div class="m-widget19__action">
                                <button type="button" class="btn m-btn--pill btn-secondary m-btn m-btn--hover-brand m-btn--custom " onclick="btnClick_Tkt_Analyse">
                                    <i class="flaticon-diagram"></i>
                                    Analyze Work Permit Data

                                </button>
                            </div>




                        </div>
                    </div>
                </div>

                <!--end:: Ticketing Section-->
            </div>



        </div>




        <div class="row">
            <div class="col-xl-12">
                <div class="m-portlet">
                    <div class="m-portlet__head" >
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <img class="m-widget19__img" style="width: 6rem;" src="../../assets/app/media/img/Dashboard_Icons/fbk.png" alt="">
                                <h3 class="m-portlet__head-text">Feedbacks Summary
                                </h3>
                            </div>
                        </div>
                    </div>


                    <div class="m-portlet__body">

                        <!--begin::Section-->
                        <div class="m-section">
                            <div class="m-section__content">
                                <table class="table m-table">
                                    <thead>
                                        <tr>
                                            <th >Event Name</th>
                                            <th>
                                                <span class="btn btn-focus">Collected Feedbacks</span>
                                            </th>
                                            <th>
                                                <span class="fa fa-smile-beam" style="font-size: 2.5rem;"></span>
                                                <span class="btn btn-success">Positive Feedbacks</span>
                                            </th>
                                            <th>
                                                <span class="fa fa-angry" style="font-size: 2.5rem;"></span>
                                                   <span class="btn btn-danger">Negative Feedbacks</span>
                                            </th>
                                            <th>
                                                <span class="fa fa-smile" style="font-size: 2.5rem;"></span>
                                                   <span class="btn btn-warning">Neutral Feedbacks</span>
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <th>Mall Experience Feedback</th>
                                            <td>34
                                                <div class="progress">
													<div class="progress-bar bg-focus" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
												</div>
                                            </td>
                                            <td>34 (40%)
                                                <div class="progress">
													<div class="progress-bar bg-success" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
												</div>
                                            </td>
                                            <td>34 (30%)
                                                <div class="progress">
													<div class="progress-bar bg-danger" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
												</div>
                                            </td>

                                            <td>34 (30%)
                                                <div class="progress">
													<div class="progress-bar bg-warning" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
												</div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>Mall Experience Feedback FeedbackFeedback</th>
                                            <td>34
                                                <div class="progress">
													<div class="progress-bar bg-focus" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
												</div>
                                            </td>
                                            <td>34 (30%)
                                                <div class="progress">
													<div class="progress-bar bg-success" role="progressbar" style="width: 45%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
												</div>
                                            </td>
                                            <td>34 (30%)
                                                  <div class="progress">
													<div class="progress-bar bg-danger" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
												</div>
                                            </td>
                                            <td>34 (30%)
                                               <div class="progress">
													<div class="progress-bar bg-warning" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
												</div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>Mall Experience Feedback</th>
                                            <td>34
                                                <div class="progress">
													<div class="progress-bar bg-primary" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
												</div>
                                            </td>
                                            <td>34 (30%)
                                                <div class="progress">
													<div class="progress-bar bg-success" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
												</div>
                                            </td>
                                            <td>34 (30%)
                                                <div class="progress">
													<div class="progress-bar bg-danger" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
												</div>
                                            </td>
                                            <td>34 (30%)
                                                <div class="progress">
													<div class="progress-bar bg-warning" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
												</div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>

                        <!--end::Section-->

                    </div>

                </div>
            </div>
        </div>





    </div>

</asp:Content>
