<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard_v2.aspx.cs" Inherits="Upkeep_v3.Dashboard_v2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .m-portlet.m-portlet--full-height {
            height: auto;
        }
        .m-portlet-body

        element.style {
            min-height: auto;
        }
    </style>



    <div class="m-porlet">
        <div class="row">

            <div class="col-xl-6">

                <!--begin:: Widgets/Blog-->
                <div class="m-portlet m-portlet--bordered-semi m-portlet--full-height  m-portlet--rounded-force">

                    <div class="m-portlet__body">
                        <div class="m-widget19">
                            <div class="m-widget19__content">
                                <div class="m-widget19__header">
                                    <div class="m-widget19__user-img">
                                        <img class="m-widget19__img" src="../../assets/app/media/img/Dashboard_Icons/tkt.png" alt="">
                                    </div>
                                    <div class="m-widget19__info">
                                        <span class="m-widget19__username">Total tickets
                                        </span>
                                        <br>
                                        <span class="m-widget19__time">Total No. of Tickets raised
                                        </span>
                                    </div>
                                    <div class="m-widget19__stats">
                                        <span class="m-widget19__number m--font-brand">18
                                        </span>
                                        <span class="m-widget19__comment">Tickets
                                        </span>
                                    </div>

                                </div>

                                <div class="m-widget19__body">
                                    Get in-depth insights & Analysis on all tickets data. 
                                </div>
                            </div>


                            <div class="m-widget4 m-widget4--chart-bottom" style="min-height: 350px">
                                <div class="m-widget4__item">
                                    <div class="m-widget4__ext">
                                        <a href="#" class="m-widget4__icon m--font-brand">
                                            <i class="flaticon-interface-3"></i>
                                        </a>
                                    </div>
                                    <div class="m-widget4__info">
                                        <span class="m-widget4__text">Make Metronic Great Again
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__number m--font-accent">+500</span>
                                    </div>
                                </div>
                                <div class="m-widget4__item">
                                    <div class="m-widget4__ext">
                                        <a href="#" class="m-widget4__icon m--font-brand">
                                            <i class="flaticon-folder-4"></i>
                                        </a>
                                    </div>
                                    <div class="m-widget4__info">
                                        <span class="m-widget4__text">Green Maker Team
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__stats m--font-info">
                                            <span class="m-widget4__number m--font-accent">-64</span>
                                        </span>
                                    </div>
                                </div>
                                <div class="m-widget4__item">
                                    <div class="m-widget4__ext">
                                        <a href="#" class="m-widget4__icon m--font-brand">
                                            <i class="flaticon-line-graph"></i>
                                        </a>
                                    </div>
                                    <div class="m-widget4__info">
                                        <span class="m-widget4__text">Make Apex Great Again
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__stats m--font-info">
                                            <span class="m-widget4__number m--font-accent">+1080</span>
                                        </span>
                                    </div>
                                </div>
                                <div class="m-widget4__item m-widget4__item--last">
                                    <div class="m-widget4__ext">
                                        <a href="#" class="m-widget4__icon m--font-brand">
                                            <i class="flaticon-diagram"></i>
                                        </a>
                                    </div>
                                    <div class="m-widget4__info">
                                        <span class="m-widget4__text">A Programming Language
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__stats m--font-info">
                                            <span class="m-widget4__number m--font-accent">+19</span>
                                        </span>
                                    </div>
                                </div>
                            </div>



                            <div class="m-widget19__action">
                                <button type="button" class="btn m-btn--pill btn-secondary m-btn m-btn--hover-brand m-btn--custom">Read More</button>
                            </div>
                        </div>
                    </div>
                </div>

                <!--end:: Widgets/Blog-->
            </div>
            <div class="col-xl-6">

                <!--begin:: Widgets/Blog-->
                <div class="m-portlet m-portlet--bordered-semi m-portlet--full-height  m-portlet--rounded-force">

                    <div class="m-portlet__body">
                        <div class="m-widget19">
                            <div class="m-widget19__content">
                                <div class="m-widget19__header">
                                    <div class="m-widget19__user-img">
                                        <img class="m-widget19__img" src="../../assets/app/media/img/Dashboard_Icons/tkt.png" alt="">
                                    </div>
                                    <div class="m-widget19__info">
                                        <span class="m-widget19__username">Total tickets
                                        </span>
                                        <br>
                                        <span class="m-widget19__time">Total No. of Tickets raised
                                        </span>
                                    </div>
                                    <div class="m-widget19__stats">
                                        <span class="m-widget19__number m--font-brand">18
                                        </span>
                                        <span class="m-widget19__comment">Tickets
                                        </span>
                                    </div>

                                </div>

                                <div class="m-widget19__body">
                                    Get in-depth insights & Analysis on all tickets data. 
                                </div>
                            </div>


                            <div class="m-widget4 m-widget4--chart-bottom" style="min-height: 350px">
                                <div class="m-widget4__item">
                                    <div class="m-widget4__ext">
                                        <a href="#" class="m-widget4__icon m--font-brand">
                                            <i class="flaticon-interface-3"></i>
                                        </a>
                                    </div>
                                    <div class="m-widget4__info">
                                        <span class="m-widget4__text">Total No. of Tickets OPEN
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__number m--font-accent">500</span>
                                    </div>
                                </div>
                                <div class="m-widget4__item">
                                    <div class="m-widget4__ext">
                                        <a href="#" class="m-widget4__icon m--font-brand">
                                            <i class="flaticon-folder-4"></i>
                                        </a>
                                    </div>
                                    <div class="m-widget4__info">
                                        <span class="m-widget4__text">Green Maker Team
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__stats m--font-info">
                                            <span class="m-widget4__number m--font-accent">-64</span>
                                        </span>
                                    </div>
                                </div>
                                <div class="m-widget4__item">
                                    <div class="m-widget4__ext">
                                        <a href="#" class="m-widget4__icon m--font-brand">
                                            <i class="flaticon-line-graph"></i>
                                        </a>
                                    </div>
                                    <div class="m-widget4__info">
                                        <span class="m-widget4__text">Make Apex Great Again
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__stats m--font-info">
                                            <span class="m-widget4__number m--font-accent">+1080</span>
                                        </span>
                                    </div>
                                </div>
                                <div class="m-widget4__item m-widget4__item--last">
                                    <div class="m-widget4__ext">
                                        <a href="#" class="m-widget4__icon m--font-brand">
                                            <i class="flaticon-diagram"></i>
                                        </a>
                                    </div>
                                    <div class="m-widget4__info">
                                        <span class="m-widget4__text">A Programming Language
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__stats m--font-info">
                                            <span class="m-widget4__number m--font-accent">+19</span>
                                        </span>
                                    </div>
                                </div>
                            </div>



                            <div class="m-widget19__action">
                                <button type="button" class="btn m-btn--pill btn-secondary m-btn m-btn--hover-brand m-btn--custom">Read More</button>
                            </div>
                        </div>
                    </div>
                </div>

                <!--end:: Widgets/Blog-->
            </div>
            
        </div>
    </div>
</asp:Content>
