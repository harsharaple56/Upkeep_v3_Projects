<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Dashboard_Admin.aspx.cs" Inherits="Upkeep_v3_Control_Center.Dashboard_Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    

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
                                <button type="button" class="btn m-btn--pill btn-secondary m-btn m-btn--hover-brand m-btn--custom ">
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
                                <button type="button" class="btn m-btn--pill btn-secondary m-btn m-btn--hover-brand m-btn--custom ">
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
                                        <div class="m-dropdown__wrapper">
                                            <span class="m-dropdown__arrow m-dropdown__arrow--right m-dropdown__arrow--adjust"></span>
                                            <div class="m-dropdown__inner">
                                                <div class="m-dropdown__body">
                                                    <div class="m-dropdown__content">
                                                        <ul class="m-nav">
                                                            <li class="m-nav__section m-nav__section--first">
                                                                <span class="m-nav__section-text">Quick Actions</span>
                                                            </li>
                                                            <li class="m-nav__item">
                                                                <a href="" class="m-nav__link">
                                                                    <i class="m-nav__link-icon flaticon-share"></i>
                                                                    <span class="m-nav__link-text">Create Post</span>
                                                                </a>
                                                            </li>
                                                            <li class="m-nav__item">
                                                                <a href="" class="m-nav__link">
                                                                    <i class="m-nav__link-icon flaticon-chat-1"></i>
                                                                    <span class="m-nav__link-text">Send Messages</span>
                                                                </a>
                                                            </li>
                                                            <li class="m-nav__item">
                                                                <a href="" class="m-nav__link">
                                                                    <i class="m-nav__link-icon flaticon-multimedia-2"></i>
                                                                    <span class="m-nav__link-text">Upload File</span>
                                                                </a>
                                                            </li>
                                                            <li class="m-nav__section">
                                                                <span class="m-nav__section-text">Useful Links</span>
                                                            </li>
                                                            <li class="m-nav__item">
                                                                <a href="" class="m-nav__link">
                                                                    <i class="m-nav__link-icon flaticon-info"></i>
                                                                    <span class="m-nav__link-text">FAQ</span>
                                                                </a>
                                                            </li>
                                                            <li class="m-nav__item">
                                                                <a href="" class="m-nav__link">
                                                                    <i class="m-nav__link-icon flaticon-lifebuoy"></i>
                                                                    <span class="m-nav__link-text">Support</span>
                                                                </a>
                                                            </li>
                                                            <li class="m-nav__separator m-nav__separator--fit m--hide"></li>
                                                            <li class="m-nav__item m--hide">
                                                                <a href="#" class="btn btn-outline-danger m-btn m-btn--pill m-btn--wide btn-sm">Submit</a>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="m-portlet__body">

                        <!--begin: Datatable -->
                        <div class="m_datatable m-datatable m-datatable--default m-datatable--loaded m-datatable--scroll" id="m_datatable_latest_orders" style="">
                            <table class="m-datatable__table" style="display: block; min-height: 300px; max-height: 380px;">
                                <thead class="m-datatable__head">
                                    <tr class="m-datatable__row" style="left: 0px;">
                                        <th data-field="RecordID" class="m-datatable__cell--center m-datatable__cell m-datatable__cell--check"><span style="width: 40px;">
                                            <label class="m-checkbox m-checkbox--single m-checkbox--all m-checkbox--solid m-checkbox--brand">
                                                <input type="checkbox">&nbsp;<span></span></label></span></th>
                                        <th data-field="OrderID" class="m-datatable__cell m-datatable__cell--sort" data-sort="asc"><span style="width: 150px;">Order ID<i class="la la-arrow-up"></i></span></th>
                                        <th data-field="ShipName" class="m-datatable__cell m-datatable__cell--sort"><span style="width: 150px;">Ship Name</span></th>
                                        <th data-field="ShipDate" class="m-datatable__cell m-datatable__cell--sort"><span style="width: 110px;">Ship Date</span></th>
                                        <th data-field="Status" class="m-datatable__cell m-datatable__cell--sort"><span style="width: 100px;">Status</span></th>
                                        <th data-field="Type" class="m-datatable__cell m-datatable__cell--sort"><span style="width: 100px;">Type</span></th>
                                        <th data-field="Actions" class="m-datatable__cell m-datatable__cell--sort"><span style="width: 110px;">Actions</span></th>
                                    </tr>
                                </thead>
                                <tbody class="m-datatable__body ps ps--active-x ps--active-y" style="max-height: 328.667px;">
                                    <tr data-row="30" class="m-datatable__row" style="left: 0px;">
                                        <td class="m-datatable__cell--center m-datatable__cell m-datatable__cell--check" data-field="RecordID"><span style="width: 40px;">
                                            <label class="m-checkbox m-checkbox--single m-checkbox--solid m-checkbox--brand">
                                                <input type="checkbox" value="164">&nbsp;<span></span></label></span></td>
                                        <td class="m-datatable__cell--sorted m-datatable__cell" data-field="OrderID"><span style="width: 150px;">0527-1726 - FR</span></td>
                                        <td data-field="ShipName" class="m-datatable__cell"><span style="width: 150px;">Lubowitz, Walker and Schimmel</span></td>
                                        <td data-field="ShipDate" class="m-datatable__cell"><span style="width: 110px;">8/4/2017</span></td>
                                        <td data-field="Status" class="m-datatable__cell"><span style="width: 100px;"><span class="m-badge  m-badge--danger m-badge--wide">Danger</span></span></td>
                                        <td data-field="Type" class="m-datatable__cell"><span style="width: 100px;"><span class="m-badge m-badge--danger m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-danger">Online</span></span></td>
                                        <td data-field="Actions" class="m-datatable__cell"><span style="overflow: visible; position: relative; width: 110px;">
                                            <div class="dropdown ">
                                                <a href="#" class="btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill" data-toggle="dropdown"><i class="la la-ellipsis-h"></i></a>
                                                <div class="dropdown-menu dropdown-menu-right"><a class="dropdown-item" href="#"><i class="la la-edit"></i>Edit Details</a>                                <a class="dropdown-item" href="#"><i class="la la-leaf"></i>Update Status</a>                                <a class="dropdown-item" href="#"><i class="la la-print"></i>Generate Report</a>                            </div>
                                            </div>
                                            <a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill" title="Edit details"><i class="la la-edit"></i></a><a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-danger m-btn--icon m-btn--icon-only m-btn--pill" title="Delete"><i class="la la-trash"></i></a></span></td>
                                    </tr>
                                    <tr data-row="31" class="m-datatable__row m-datatable__row--even" style="left: 0px;">
                                        <td class="m-datatable__cell--center m-datatable__cell m-datatable__cell--check" data-field="RecordID"><span style="width: 40px;">
                                            <label class="m-checkbox m-checkbox--single m-checkbox--solid m-checkbox--brand">
                                                <input type="checkbox" value="218">&nbsp;<span></span></label></span></td>
                                        <td class="m-datatable__cell--sorted m-datatable__cell" data-field="OrderID"><span style="width: 150px;">0548-5632 - KZ</span></td>
                                        <td data-field="ShipName" class="m-datatable__cell"><span style="width: 150px;">Greenholt Group</span></td>
                                        <td data-field="ShipDate" class="m-datatable__cell"><span style="width: 110px;">1/27/2016</span></td>
                                        <td data-field="Status" class="m-datatable__cell"><span style="width: 100px;"><span class="m-badge  m-badge--success m-badge--wide">Success</span></span></td>
                                        <td data-field="Type" class="m-datatable__cell"><span style="width: 100px;"><span class="m-badge m-badge--primary m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-primary">Retail</span></span></td>
                                        <td data-field="Actions" class="m-datatable__cell"><span style="overflow: visible; position: relative; width: 110px;">
                                            <div class="dropdown ">
                                                <a href="#" class="btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill" data-toggle="dropdown"><i class="la la-ellipsis-h"></i></a>
                                                <div class="dropdown-menu dropdown-menu-right"><a class="dropdown-item" href="#"><i class="la la-edit"></i>Edit Details</a>                                <a class="dropdown-item" href="#"><i class="la la-leaf"></i>Update Status</a>                                <a class="dropdown-item" href="#"><i class="la la-print"></i>Generate Report</a>                            </div>
                                            </div>
                                            <a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill" title="Edit details"><i class="la la-edit"></i></a><a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-danger m-btn--icon m-btn--icon-only m-btn--pill" title="Delete"><i class="la la-trash"></i></a></span></td>
                                    </tr>
                                    <tr data-row="32" class="m-datatable__row" style="left: 0px;">
                                        <td class="m-datatable__cell--center m-datatable__cell m-datatable__cell--check" data-field="RecordID"><span style="width: 40px;">
                                            <label class="m-checkbox m-checkbox--single m-checkbox--solid m-checkbox--brand">
                                                <input type="checkbox" value="13">&nbsp;<span></span></label></span></td>
                                        <td class="m-datatable__cell--sorted m-datatable__cell" data-field="OrderID"><span style="width: 150px;">0573-0174 - AM</span></td>
                                        <td data-field="ShipName" class="m-datatable__cell"><span style="width: 150px;">Bergstrom Inc</span></td>
                                        <td data-field="ShipDate" class="m-datatable__cell"><span style="width: 110px;">9/10/2017</span></td>
                                        <td data-field="Status" class="m-datatable__cell"><span style="width: 100px;"><span class="m-badge  m-badge--info m-badge--wide">Info</span></span></td>
                                        <td data-field="Type" class="m-datatable__cell"><span style="width: 100px;"><span class="m-badge m-badge--danger m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-danger">Online</span></span></td>
                                        <td data-field="Actions" class="m-datatable__cell"><span style="overflow: visible; position: relative; width: 110px;">
                                            <div class="dropdown ">
                                                <a href="#" class="btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill" data-toggle="dropdown"><i class="la la-ellipsis-h"></i></a>
                                                <div class="dropdown-menu dropdown-menu-right"><a class="dropdown-item" href="#"><i class="la la-edit"></i>Edit Details</a>                                <a class="dropdown-item" href="#"><i class="la la-leaf"></i>Update Status</a>                                <a class="dropdown-item" href="#"><i class="la la-print"></i>Generate Report</a>                            </div>
                                            </div>
                                            <a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill" title="Edit details"><i class="la la-edit"></i></a><a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-danger m-btn--icon m-btn--icon-only m-btn--pill" title="Delete"><i class="la la-trash"></i></a></span></td>
                                    </tr>
                                    <tr data-row="33" class="m-datatable__row m-datatable__row--even" style="left: 0px;">
                                        <td class="m-datatable__cell--center m-datatable__cell m-datatable__cell--check" data-field="RecordID"><span style="width: 40px;">
                                            <label class="m-checkbox m-checkbox--single m-checkbox--solid m-checkbox--brand">
                                                <input type="checkbox" value="102">&nbsp;<span></span></label></span></td>
                                        <td class="m-datatable__cell--sorted m-datatable__cell" data-field="OrderID"><span style="width: 150px;">0573-2952 - PT</span></td>
                                        <td data-field="ShipName" class="m-datatable__cell"><span style="width: 150px;">Mraz LLC</span></td>
                                        <td data-field="ShipDate" class="m-datatable__cell"><span style="width: 110px;">2/21/2016</span></td>
                                        <td data-field="Status" class="m-datatable__cell"><span style="width: 100px;"><span class="m-badge  m-badge--danger m-badge--wide">Danger</span></span></td>
                                        <td data-field="Type" class="m-datatable__cell"><span style="width: 100px;"><span class="m-badge m-badge--danger m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-danger">Online</span></span></td>
                                        <td data-field="Actions" class="m-datatable__cell"><span style="overflow: visible; position: relative; width: 110px;">
                                            <div class="dropdown ">
                                                <a href="#" class="btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill" data-toggle="dropdown"><i class="la la-ellipsis-h"></i></a>
                                                <div class="dropdown-menu dropdown-menu-right"><a class="dropdown-item" href="#"><i class="la la-edit"></i>Edit Details</a>                                <a class="dropdown-item" href="#"><i class="la la-leaf"></i>Update Status</a>                                <a class="dropdown-item" href="#"><i class="la la-print"></i>Generate Report</a>                            </div>
                                            </div>
                                            <a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill" title="Edit details"><i class="la la-edit"></i></a><a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-danger m-btn--icon m-btn--icon-only m-btn--pill" title="Delete"><i class="la la-trash"></i></a></span></td>
                                    </tr>
                                    <tr data-row="34" class="m-datatable__row" style="left: 0px;">
                                        <td class="m-datatable__cell--center m-datatable__cell m-datatable__cell--check" data-field="RecordID"><span style="width: 40px;">
                                            <label class="m-checkbox m-checkbox--single m-checkbox--solid m-checkbox--brand">
                                                <input type="checkbox" value="90">&nbsp;<span></span></label></span></td>
                                        <td class="m-datatable__cell--sorted m-datatable__cell" data-field="OrderID"><span style="width: 150px;">0591-3739 - ID</span></td>
                                        <td data-field="ShipName" class="m-datatable__cell"><span style="width: 150px;">Schumm-Goldner</span></td>
                                        <td data-field="ShipDate" class="m-datatable__cell"><span style="width: 110px;">11/29/2017</span></td>
                                        <td data-field="Status" class="m-datatable__cell"><span style="width: 100px;"><span class="m-badge  m-badge--danger m-badge--wide">Danger</span></span></td>
                                        <td data-field="Type" class="m-datatable__cell"><span style="width: 100px;"><span class="m-badge m-badge--danger m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-danger">Online</span></span></td>
                                        <td data-field="Actions" class="m-datatable__cell"><span style="overflow: visible; position: relative; width: 110px;">
                                            <div class="dropdown ">
                                                <a href="#" class="btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill" data-toggle="dropdown"><i class="la la-ellipsis-h"></i></a>
                                                <div class="dropdown-menu dropdown-menu-right"><a class="dropdown-item" href="#"><i class="la la-edit"></i>Edit Details</a>                                <a class="dropdown-item" href="#"><i class="la la-leaf"></i>Update Status</a>                                <a class="dropdown-item" href="#"><i class="la la-print"></i>Generate Report</a>                            </div>
                                            </div>
                                            <a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill" title="Edit details"><i class="la la-edit"></i></a><a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-danger m-btn--icon m-btn--icon-only m-btn--pill" title="Delete"><i class="la la-trash"></i></a></span></td>
                                    </tr>
                                    <tr data-row="35" class="m-datatable__row m-datatable__row--even" style="left: 0px;">
                                        <td class="m-datatable__cell--center m-datatable__cell m-datatable__cell--check" data-field="RecordID"><span style="width: 40px;">
                                            <label class="m-checkbox m-checkbox--single m-checkbox--solid m-checkbox--brand">
                                                <input type="checkbox" value="86">&nbsp;<span></span></label></span></td>
                                        <td class="m-datatable__cell--sorted m-datatable__cell" data-field="OrderID"><span style="width: 150px;">0615-0446 - FR</span></td>
                                        <td data-field="ShipName" class="m-datatable__cell"><span style="width: 150px;">Lind-Bechtelar</span></td>
                                        <td data-field="ShipDate" class="m-datatable__cell"><span style="width: 110px;">10/30/2017</span></td>
                                        <td data-field="Status" class="m-datatable__cell"><span style="width: 100px;"><span class="m-badge  m-badge--success m-badge--wide">Success</span></span></td>
                                        <td data-field="Type" class="m-datatable__cell"><span style="width: 100px;"><span class="m-badge m-badge--accent m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-accent">Direct</span></span></td>
                                        <td data-field="Actions" class="m-datatable__cell"><span style="overflow: visible; position: relative; width: 110px;">
                                            <div class="dropdown ">
                                                <a href="#" class="btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill" data-toggle="dropdown"><i class="la la-ellipsis-h"></i></a>
                                                <div class="dropdown-menu dropdown-menu-right"><a class="dropdown-item" href="#"><i class="la la-edit"></i>Edit Details</a>                                <a class="dropdown-item" href="#"><i class="la la-leaf"></i>Update Status</a>                                <a class="dropdown-item" href="#"><i class="la la-print"></i>Generate Report</a>                            </div>
                                            </div>
                                            <a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill" title="Edit details"><i class="la la-edit"></i></a><a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-danger m-btn--icon m-btn--icon-only m-btn--pill" title="Delete"><i class="la la-trash"></i></a></span></td>
                                    </tr>
                                    <tr data-row="36" class="m-datatable__row" style="left: 0px;">
                                        <td class="m-datatable__cell--center m-datatable__cell m-datatable__cell--check" data-field="RecordID"><span style="width: 40px;">
                                            <label class="m-checkbox m-checkbox--single m-checkbox--solid m-checkbox--brand">
                                                <input type="checkbox" value="201">&nbsp;<span></span></label></span></td>
                                        <td class="m-datatable__cell--sorted m-datatable__cell" data-field="OrderID"><span style="width: 150px;">0641-6070 - DO</span></td>
                                        <td data-field="ShipName" class="m-datatable__cell"><span style="width: 150px;">Rohan Inc</span></td>
                                        <td data-field="ShipDate" class="m-datatable__cell"><span style="width: 110px;">12/7/2016</span></td>
                                        <td data-field="Status" class="m-datatable__cell"><span style="width: 100px;"><span class="m-badge  m-badge--danger m-badge--wide">Danger</span></span></td>
                                        <td data-field="Type" class="m-datatable__cell"><span style="width: 100px;"><span class="m-badge m-badge--danger m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-danger">Online</span></span></td>
                                        <td data-field="Actions" class="m-datatable__cell"><span style="overflow: visible; position: relative; width: 110px;">
                                            <div class="dropdown dropup">
                                                <a href="#" class="btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill" data-toggle="dropdown"><i class="la la-ellipsis-h"></i></a>
                                                <div class="dropdown-menu dropdown-menu-right"><a class="dropdown-item" href="#"><i class="la la-edit"></i>Edit Details</a>                                <a class="dropdown-item" href="#"><i class="la la-leaf"></i>Update Status</a>                                <a class="dropdown-item" href="#"><i class="la la-print"></i>Generate Report</a>                            </div>
                                            </div>
                                            <a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill" title="Edit details"><i class="la la-edit"></i></a><a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-danger m-btn--icon m-btn--icon-only m-btn--pill" title="Delete"><i class="la la-trash"></i></a></span></td>
                                    </tr>
                                    <tr data-row="37" class="m-datatable__row m-datatable__row--even" style="left: 0px;">
                                        <td class="m-datatable__cell--center m-datatable__cell m-datatable__cell--check" data-field="RecordID"><span style="width: 40px;">
                                            <label class="m-checkbox m-checkbox--single m-checkbox--solid m-checkbox--brand">
                                                <input type="checkbox" value="15">&nbsp;<span></span></label></span></td>
                                        <td class="m-datatable__cell--sorted m-datatable__cell" data-field="OrderID"><span style="width: 150px;">0641-6114 - KZ</span></td>
                                        <td data-field="ShipName" class="m-datatable__cell"><span style="width: 150px;">Jerde-Mueller</span></td>
                                        <td data-field="ShipDate" class="m-datatable__cell"><span style="width: 110px;">6/21/2016</span></td>
                                        <td data-field="Status" class="m-datatable__cell"><span style="width: 100px;"><span class="m-badge  m-badge--success m-badge--wide">Success</span></span></td>
                                        <td data-field="Type" class="m-datatable__cell"><span style="width: 100px;"><span class="m-badge m-badge--primary m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-primary">Retail</span></span></td>
                                        <td data-field="Actions" class="m-datatable__cell"><span style="overflow: visible; position: relative; width: 110px;">
                                            <div class="dropdown dropup">
                                                <a href="#" class="btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill" data-toggle="dropdown"><i class="la la-ellipsis-h"></i></a>
                                                <div class="dropdown-menu dropdown-menu-right"><a class="dropdown-item" href="#"><i class="la la-edit"></i>Edit Details</a>                                <a class="dropdown-item" href="#"><i class="la la-leaf"></i>Update Status</a>                                <a class="dropdown-item" href="#"><i class="la la-print"></i>Generate Report</a>                            </div>
                                            </div>
                                            <a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill" title="Edit details"><i class="la la-edit"></i></a><a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-danger m-btn--icon m-btn--icon-only m-btn--pill" title="Delete"><i class="la la-trash"></i></a></span></td>
                                    </tr>
                                    <tr data-row="38" class="m-datatable__row" style="left: 0px;">
                                        <td class="m-datatable__cell--center m-datatable__cell m-datatable__cell--check" data-field="RecordID"><span style="width: 40px;">
                                            <label class="m-checkbox m-checkbox--single m-checkbox--solid m-checkbox--brand">
                                                <input type="checkbox" value="46">&nbsp;<span></span></label></span></td>
                                        <td class="m-datatable__cell--sorted m-datatable__cell" data-field="OrderID"><span style="width: 150px;">0781-5555 - ID</span></td>
                                        <td data-field="ShipName" class="m-datatable__cell"><span style="width: 150px;">Schumm-Rempel</span></td>
                                        <td data-field="ShipDate" class="m-datatable__cell"><span style="width: 110px;">3/17/2017</span></td>
                                        <td data-field="Status" class="m-datatable__cell"><span style="width: 100px;"><span class="m-badge  m-badge--info m-badge--wide">Info</span></span></td>
                                        <td data-field="Type" class="m-datatable__cell"><span style="width: 100px;"><span class="m-badge m-badge--primary m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-primary">Retail</span></span></td>
                                        <td data-field="Actions" class="m-datatable__cell"><span style="overflow: visible; position: relative; width: 110px;">
                                            <div class="dropdown dropup">
                                                <a href="#" class="btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill" data-toggle="dropdown"><i class="la la-ellipsis-h"></i></a>
                                                <div class="dropdown-menu dropdown-menu-right"><a class="dropdown-item" href="#"><i class="la la-edit"></i>Edit Details</a>                                <a class="dropdown-item" href="#"><i class="la la-leaf"></i>Update Status</a>                                <a class="dropdown-item" href="#"><i class="la la-print"></i>Generate Report</a>                            </div>
                                            </div>
                                            <a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill" title="Edit details"><i class="la la-edit"></i></a><a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-danger m-btn--icon m-btn--icon-only m-btn--pill" title="Delete"><i class="la la-trash"></i></a></span></td>
                                    </tr>
                                    <tr data-row="39" class="m-datatable__row m-datatable__row--even" style="left: 0px;">
                                        <td class="m-datatable__cell--center m-datatable__cell m-datatable__cell--check" data-field="RecordID"><span style="width: 40px;">
                                            <label class="m-checkbox m-checkbox--single m-checkbox--solid m-checkbox--brand">
                                                <input type="checkbox" value="263">&nbsp;<span></span></label></span></td>
                                        <td class="m-datatable__cell--sorted m-datatable__cell" data-field="OrderID"><span style="width: 150px;">0832-0511 - PH</span></td>
                                        <td data-field="ShipName" class="m-datatable__cell"><span style="width: 150px;">Mayert, Bayer and Ratke</span></td>
                                        <td data-field="ShipDate" class="m-datatable__cell"><span style="width: 110px;">2/29/2016</span></td>
                                        <td data-field="Status" class="m-datatable__cell"><span style="width: 100px;"><span class="m-badge  m-badge--metal m-badge--wide">Delivered</span></span></td>
                                        <td data-field="Type" class="m-datatable__cell"><span style="width: 100px;"><span class="m-badge m-badge--danger m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-danger">Online</span></span></td>
                                        <td data-field="Actions" class="m-datatable__cell"><span style="overflow: visible; position: relative; width: 110px;">
                                            <div class="dropdown dropup">
                                                <a href="#" class="btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill" data-toggle="dropdown"><i class="la la-ellipsis-h"></i></a>
                                                <div class="dropdown-menu dropdown-menu-right"><a class="dropdown-item" href="#"><i class="la la-edit"></i>Edit Details</a>                                <a class="dropdown-item" href="#"><i class="la la-leaf"></i>Update Status</a>                                <a class="dropdown-item" href="#"><i class="la la-print"></i>Generate Report</a>                            </div>
                                            </div>
                                            <a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-accent m-btn--icon m-btn--icon-only m-btn--pill" title="Edit details"><i class="la la-edit"></i></a><a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-danger m-btn--icon m-btn--icon-only m-btn--pill" title="Delete"><i class="la la-trash"></i></a></span></td>
                                    </tr>
                                    <div class="ps__rail-x" style="width: 565px; left: 0px; bottom: 0px;">
                                        <div class="ps__thumb-x" tabindex="0" style="left: 0px; width: 354px;"></div>
                                    </div>
                                    <div class="ps__rail-y" style="top: 0px; height: 329px; right: 0px;">
                                        <div class="ps__thumb-y" tabindex="0" style="top: 0px; height: 194px;"></div>
                                    </div>
                                </tbody>
                            </table>
                            <div class="m-datatable__pager m-datatable--paging-loaded clearfix">
                                <ul class="m-datatable__pager-nav">
                                    <li><a title="First" class="m-datatable__pager-link m-datatable__pager-link--first" data-page="1"><i class="la la-angle-double-left"></i></a></li>
                                    <li><a title="Previous" class="m-datatable__pager-link m-datatable__pager-link--prev" data-page="3"><i class="la la-angle-left"></i></a></li>
                                    <li style="display: none;"><a title="More pages" class="m-datatable__pager-link m-datatable__pager-link--more-prev" data-page="1"><i class="la la-ellipsis-h"></i></a></li>
                                    <li style="display: none;">
                                        <input type="text" class="m-pager-input form-control" title="Page number"></li>
                                    <li><a class="m-datatable__pager-link m-datatable__pager-link-number" data-page="1" title="1">1</a></li>
                                    <li><a class="m-datatable__pager-link m-datatable__pager-link-number" data-page="2" title="2">2</a></li>
                                    <li><a class="m-datatable__pager-link m-datatable__pager-link-number" data-page="3" title="3">3</a></li>
                                    <li><a class="m-datatable__pager-link m-datatable__pager-link-number m-datatable__pager-link--active" data-page="4" title="4">4</a></li>
                                    <li><a class="m-datatable__pager-link m-datatable__pager-link-number" data-page="5" title="5">5</a></li>
                                    <li><a class="m-datatable__pager-link m-datatable__pager-link-number" data-page="6" title="6">6</a></li>
                                    <li><a title="More pages" class="m-datatable__pager-link m-datatable__pager-link--more-next" data-page="7"><i class="la la-ellipsis-h"></i></a></li>
                                    <li><a title="Next" class="m-datatable__pager-link m-datatable__pager-link--next" data-page="5"><i class="la la-angle-right"></i></a></li>
                                    <li><a title="Last" class="m-datatable__pager-link m-datatable__pager-link--last" data-page="35"><i class="la la-angle-double-right"></i></a></li>
                                </ul>
                                <div class="m-datatable__pager-info">
                                    <div class="dropdown bootstrap-select m-datatable__pager-size" style="width: 70px;">
                                        <select class="selectpicker m-datatable__pager-size" title="Select page size" data-width="70px" data-selected="10" tabindex="-98">
                                            <option class="bs-title-option" value="">Select page size</option>
                                            <option value="10">10</option>
                                            <option value="20">20</option>
                                            <option value="30">30</option>
                                            <option value="50">50</option>
                                            <option value="100">100</option>
                                        </select>
                                        <button type="button" class="btn dropdown-toggle btn-light" data-toggle="dropdown" role="button" title="Select page size">
                                            <div class="filter-option">
                                                <div class="filter-option-inner">10</div>
                                            </div>
                                            &nbsp;<span class="bs-caret"><span class="caret"></span></span></button><div class="dropdown-menu " role="combobox">
                                                <div class="inner show" role="listbox" aria-expanded="false" tabindex="-1">
                                                    <ul class="dropdown-menu inner show"></ul>
                                                </div>
                                            </div>
                                    </div>
                                    <span class="m-datatable__pager-detail">Displaying 31 - 40 of 350 records</span>
                                </div>
                            </div>
                        </div>

                        <!--end: Datatable -->
                    </div>
                </div>
            </div>
            <div class="col-xl-6">

                <div class="m-portlet m-portlet--bordered-semi m-portlet--full-height ">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Analysis on tickets for past 12 Months
                                </h3>
                            </div>
                        </div>
                        <div class="m-portlet__head-tools">
                            <ul class="m-portlet__nav">
                                <li class="m-portlet__nav-item m-portlet__nav-item--last m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover">
                                    <a href="#" class="m-portlet__nav-link m-portlet__nav-link--icon m-portlet__nav-link--icon-xl">
                                        <i class="fa fa-genderless m--font-brand"></i>
                                    </a>
                                    <div class="m-dropdown__wrapper">
                                        <span class="m-dropdown__arrow m-dropdown__arrow--right m-dropdown__arrow--adjust"></span>
                                        <div class="m-dropdown__inner">
                                            <div class="m-dropdown__body">
                                                <div class="m-dropdown__content">
                                                    <ul class="m-nav">
                                                        <li class="m-nav__section m-nav__section--first">
                                                            <span class="m-nav__section-text">Quick Actions</span>
                                                        </li>
                                                        <li class="m-nav__item">
                                                            <a href="" class="m-nav__link">
                                                                <i class="m-nav__link-icon flaticon-share"></i>
                                                                <span class="m-nav__link-text">Activity</span>
                                                            </a>
                                                        </li>
                                                        <li class="m-nav__item">
                                                            <a href="" class="m-nav__link">
                                                                <i class="m-nav__link-icon flaticon-chat-1"></i>
                                                                <span class="m-nav__link-text">Messages</span>
                                                            </a>
                                                        </li>
                                                        <li class="m-nav__item">
                                                            <a href="" class="m-nav__link">
                                                                <i class="m-nav__link-icon flaticon-info"></i>
                                                                <span class="m-nav__link-text">FAQ</span>
                                                            </a>
                                                        </li>
                                                        <li class="m-nav__item">
                                                            <a href="" class="m-nav__link">
                                                                <i class="m-nav__link-icon flaticon-lifebuoy"></i>
                                                                <span class="m-nav__link-text">Support</span>
                                                            </a>
                                                        </li>
                                                        <li class="m-nav__separator m-nav__separator--fit"></li>
                                                        <li class="m-nav__item">
                                                            <a href="#" class="btn btn-outline-danger m-btn m-btn--pill m-btn--wide btn-sm">Cancel</a>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
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
                                            <span class="m-widget15__stats">63%
                                            </span>
                                            <span class="m-widget15__text ">Percentage of Tickets
                                            </span>

                                            <span class="m-badge m-badge--danger m-badge--wide">Open
                                            </span>

                                            <div class="m--space-10"></div>
                                            <div class="progress m-progress--sm">
                                                <div class="progress-bar bg-danger" role="progressbar" style="width: 25%;" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col">
                                        <div class="m-widget15__item">
                                            <span class="m-widget15__stats">54%
                                            </span>
                                            <span class="m-widget15__text ">Percentage of Tickets
                                            </span>

                                            <span class="m-badge m-badge--warning m-badge--wide">Parked
                                            </span>
                                            <div class="m--space-10"></div>
                                            <div class="progress m-progress--sm">
                                                <div class="progress-bar bg-warning" role="progressbar" style="width: 40%;" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <div class="m-widget15__item">
                                            <span class="m-widget15__stats">41%
                                            </span>
                                            <span class="m-widget15__text ">Percentage of Tickets
                                            </span>

                                            <span class="m-badge m-badge--success m-badge--wide">Closed
                                            </span>
                                            <div class="m--space-10"></div>
                                            <div class="progress m-progress--sm">
                                                <div class="progress-bar bg-success" role="progressbar" style="width: 55%;" aria-valuenow="75" aria-valuemin="0" aria-valuemax="100"></div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col">
                                        <div class="m-widget15__item">
                                            <span class="m-widget15__stats">79%
                                            </span>
                                            <span class="m-widget15__text ">Percentage of Tickets
                                            </span>

                                            <span class="m-badge m-badge--secondary m-badge--wide">Expired
                                            </span>
                                            <div class="m--space-10"></div>
                                            <div class="progress m-progress--sm">
                                                <div class="progress-bar bg-primary" role="progressbar" style="width: 60%;" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100"></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="m-widget15__desc">
                                * lorem ipsum dolor sit amet consectetuer sediat elit
                            </div>
                        </div>

                        <!--end::Widget 6-->
                    </div>
                </div>

            </div>

        </div>
        

        <div class="row">

            <div class="col-xl-12">
                <div class="m-portlet m-portlet--bordered-semi m-portlet--full-height ">
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
                    <div class="m-portlet__body  m-portlet__body--no-padding">
                        <div class="row m-row--no-padding m-row--col-separator-xl">
                            <div class="col-md-12 col-lg-6 col-xl-4">

                                <!--begin::Total Profit-->
                                <div class="m-widget24">
                                    <div class="m-widget24__item">
                                        <h4 class="m-widget24__title">
                                                Assigned
                                        </h4>
                                        <br>
                                        <span class="m-widget24__desc">Tickets in Assigned state
                                        </span>
                                        <span class="m-widget24__stats m--font-danger">1800
                                        </span>
                                        <div class="m--space-10"></div>
                                        <div class="progress m-progress--sm">
                                            <div class="progress-bar m--bg-brand" role="progressbar" style="width: 78%;" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                        </div>
                                        <span class="m-widget24__change">From overall Open Tickets
                                        </span>
                                        <span class="m-widget24__number">78%
                                        </span>
                                    </div>
                                </div>

                                <!--end::Total Profit-->
                            </div>
                            <div class="col-md-12 col-lg-6 col-xl-4">

                                <!--begin::New Feedbacks-->
                                <div class="m-widget24">
                                    <div class="m-widget24__item">
                                        <h4 class="m-widget24__title">New Feedbacks
                                        </h4>
                                        <br>
                                        <span class="m-widget24__desc">Customer Review
                                        </span>
                                        <span class="m-widget24__stats m--font-info">1349
                                        </span>
                                        <div class="m--space-10"></div>
                                        <div class="progress m-progress--sm">
                                            <div class="progress-bar m--bg-info" role="progressbar" style="width: 84%;" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                        </div>
                                        <span class="m-widget24__change">Change
                                        </span>
                                        <span class="m-widget24__number">84%
                                        </span>
                                    </div>
                                </div>

                                <!--end::New Feedbacks-->
                            </div>
                            <div class="col-md-12 col-lg-6 col-xl-4">

                                <!--begin::New Orders-->
                                <div class="m-widget24">
                                    <div class="m-widget24__item">
                                        <h4 class="m-widget24__title">New Orders
                                        </h4>
                                        <br>
                                        <span class="m-widget24__desc">Fresh Order Amount
                                        </span>
                                        <span class="m-widget24__stats m--font-danger">567
                                        </span>
                                        <div class="m--space-10"></div>
                                        <div class="progress m-progress--sm">
                                            <div class="progress-bar m--bg-danger" role="progressbar" style="width: 69%;" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                        </div>
                                        <span class="m-widget24__change">Change
                                        </span>
                                        <span class="m-widget24__number">69%
                                        </span>
                                    </div>
                                </div>

                                <!--end::New Orders-->
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </div>


</asp:Content>
