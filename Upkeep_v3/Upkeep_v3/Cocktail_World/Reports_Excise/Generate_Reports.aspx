<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Generate_Reports.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Reports_Excise.Generate_Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="m-content">
        <div class="row">
            <div class="col-xl-16">
                <div class="m-portlet m-portlet--tabs">
                    <div class="m-portlet__head">
                        <%--<div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Maharashtra Excise Reports
                                </h3>
                            </div>
                        </div>--%>
                        <div class="m-portlet__head-tools">
                            <ul class="nav nav-tabs m-tabs-line m-tabs-line--primary m-tabs-line--2x" role="tablist">
                                <li class="nav-item m-tabs__item">
                                    <a class="nav-link m-tabs__link active show" data-toggle="tab" href="#m_tabs_6_1" role="tab" aria-selected="false">
                                        <i class="la la-file-text-o"></i>FLR-III
                                    </a>
                                </li>
                                <li class="nav-item m-tabs__item">
                                    <a class="nav-link m-tabs__link" data-toggle="tab" href="#m_tabs_6_2" role="tab" aria-selected="false">
                                        <i class="la la-file-text-o"></i>FLR-III (Pre-Printed)
                                    </a>
                                </li>
                                <li class="nav-item m-tabs__item">
                                    <a class="nav-link m-tabs__link" data-toggle="tab" href="#m_tabs_6_3" role="tab" aria-selected="true">
                                        <i class="la la-file-text-o"></i>FLR-III A
                                    </a>
                                </li>
                                <li class="nav-item m-tabs__item">
                                    <a class="nav-link m-tabs__link" data-toggle="tab" href="#m_tabs_6_4" role="tab" aria-selected="true">
                                        <i class="la la-file-text-o"></i>FLR-IV
                                    </a>
                                </li>
                                <li class="nav-item m-tabs__item">
                                    <a class="nav-link m-tabs__link" data-toggle="tab" href="#m_tabs_6_4" role="tab" aria-selected="true">
                                        <i class="la la-file-text-o"></i>FLR-VI
                                    </a>
                                </li>
                                <li class="nav-item m-tabs__item">
                                    <a class="nav-link m-tabs__link" data-toggle="tab" href="#m_tabs_6_4" role="tab" aria-selected="true">
                                        <i class="la la-file-text-o"></i>FLR-VI (Pre-Printed)
                                    </a>
                                </li>
                                <li class="nav-item m-tabs__item">
                                    <a class="nav-link m-tabs__link" data-toggle="tab" href="#m_tabs_6_4" role="tab" aria-selected="true">
                                        <i class="la la-file-text-o"></i>FLR-VI A
                                    </a>
                                </li>
                                <li class="nav-item m-tabs__item">
                                    <a class="nav-link m-tabs__link" data-toggle="tab" href="#m_tabs_6_5" role="tab" aria-selected="true">
                                        <i class="la la-file-text-o"></i>Chatai
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="m-portlet__body">
                        <div class="tab-content">
                            <div class="tab-pane" id="m_tabs_6_1" role="tabpanel">
                                <div id="m_table_1_wrapper" class="dataTables_wrapper dt-bootstrap4 no-footer">
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <table class="table table-striped- table-bordered table-hover table-checkable dataTable no-footer dtr-inline collapsed" id="m_table_1" role="grid" aria-describedby="m_table_1_info" style="width: 891px;">
                                                <thead>
                                                    <tr role="row">

                                                        <th class="sorting_desc" tabindex="0" aria-controls="m_table_1" rowspan="1" colspan="1" style="width: 37.25px;" aria-sort="descending" aria-label="Order ID: activate to sort column ascending">Order ID</th>
                                                        <th class="sorting" tabindex="0" aria-controls="m_table_1" rowspan="1" colspan="1" style="width: 55.25px;" aria-label="Country: activate to sort column ascending">Country</th>
                                                        <th class="sorting" tabindex="0" aria-controls="m_table_1" rowspan="1" colspan="1" style="width: 67.25px;" aria-label="Ship City: activate to sort column ascending">Ship City</th>
                                                        <th class="sorting" tabindex="0" aria-controls="m_table_1" rowspan="1" colspan="1" style="width: 84.25px;" aria-label="Ship Address: activate to sort column ascending">Ship Address</th>
                                                        <th class="sorting" tabindex="0" aria-controls="m_table_1" rowspan="1" colspan="1" style="width: 71.25px;" aria-label="Company Agent: activate to sort column ascending">Company Agent</th>
                                                        <th class="sorting" tabindex="0" aria-controls="m_table_1" rowspan="1" colspan="1" style="width: 103.25px;" aria-label="Company Name: activate to sort column ascending">Company Name</th>
                                                        <th class="sorting" tabindex="0" aria-controls="m_table_1" rowspan="1" colspan="1" style="width: 42.25px;" aria-label="Ship Date: activate to sort column ascending">Ship Date</th>
                                                        <th class="sorting" tabindex="0" aria-controls="m_table_1" rowspan="1" colspan="1" style="width: 53.25px;" aria-label="Status: activate to sort column ascending">Status</th>
                                                        <th class="sorting_disabled" rowspan="1" colspan="1" style="width: 0px; display: none;" aria-label="Actions">Actions</th>
                                                    </tr>
                                                </thead>
                                                <tbody>

                                                    <tr role="row" class="odd">
                                                        <td class=" dt-right" tabindex="0">
                                                            <label class="m-checkbox m-checkbox--single m-checkbox--solid m-checkbox--brand">
                                                                <input type="checkbox" value="" class="m-checkable">
                                                                <span></span>
                                                            </label>
                                                        </td>
                                                        <td class="sorting_1">75862-001</td>
                                                        <td>Indonesia</td>
                                                        <td>Pineleng</td>
                                                        <td>4 Messerschmidt Point</td>
                                                        <td>Cherish Peplay</td>
                                                        <td>McCullough-Gibson</td>
                                                        <td>11/23/2017</td>
                                                        <td><span class="m-badge  m-badge--metal m-badge--wide">Delivered</span></td>
                                                        <td style="display: none;"><span class="m-badge m-badge--primary m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-primary">Retail</span></td>
                                                        <td nowrap="" style="display: none;">
                                                            <span class="dropdown">
                                                                <a href="#" class="btn m-btn m-btn--hover-brand m-btn--icon m-btn--icon-only m-btn--pill" data-toggle="dropdown" aria-expanded="true">
                                                                    <i class="la la-ellipsis-h"></i>
                                                                </a>
                                                                <div class="dropdown-menu dropdown-menu-right">
                                                                    <a class="dropdown-item" href="#"><i class="la la-edit"></i>Edit Details</a>
                                                                    <a class="dropdown-item" href="#"><i class="la la-leaf"></i>Update Status</a>
                                                                    <a class="dropdown-item" href="#"><i class="la la-print"></i>Generate Report</a>
                                                                </div>
                                                            </span>
                                                            <a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-brand m-btn--icon m-btn--icon-only m-btn--pill" title="View">
                                                                <i class="la la-edit"></i>
                                                            </a></td>
                                                    </tr>
                                                    <tr role="row" class="even">
                                                        <td class=" dt-right" tabindex="0">
                                                            <label class="m-checkbox m-checkbox--single m-checkbox--solid m-checkbox--brand">
                                                                <input type="checkbox" value="" class="m-checkable">
                                                                <span></span>
                                                            </label>
                                                        </td>
                                                        <td class="sorting_1">68647-122</td>
                                                        <td>Philippines</td>
                                                        <td>Cardona</td>
                                                        <td>4765 Service Hill</td>
                                                        <td>Devi Iglesias</td>
                                                        <td>Ullrich-Dibbert</td>
                                                        <td>7/21/2016</td>
                                                        <td><span class="m-badge m-badge--brand m-badge--wide">Pending</span></td>
                                                        <td style="display: none;"><span class="m-badge m-badge--danger m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-danger">Online</span></td>
                                                        <td nowrap="" style="display: none;">
                                                            <span class="dropdown">
                                                                <a href="#" class="btn m-btn m-btn--hover-brand m-btn--icon m-btn--icon-only m-btn--pill" data-toggle="dropdown" aria-expanded="true">
                                                                    <i class="la la-ellipsis-h"></i>
                                                                </a>
                                                                <div class="dropdown-menu dropdown-menu-right">
                                                                    <a class="dropdown-item" href="#"><i class="la la-edit"></i>Edit Details</a>
                                                                    <a class="dropdown-item" href="#"><i class="la la-leaf"></i>Update Status</a>
                                                                    <a class="dropdown-item" href="#"><i class="la la-print"></i>Generate Report</a>
                                                                </div>
                                                            </span>
                                                            <a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-brand m-btn--icon m-btn--icon-only m-btn--pill" title="View">
                                                                <i class="la la-edit"></i>
                                                            </a></td>
                                                    </tr>
                                                    <tr role="row" class="odd">
                                                        <td class=" dt-right" tabindex="0">
                                                            <label class="m-checkbox m-checkbox--single m-checkbox--solid m-checkbox--brand">
                                                                <input type="checkbox" value="" class="m-checkable">
                                                                <span></span>
                                                            </label>
                                                        </td>
                                                        <td class="sorting_1">68428-725</td>
                                                        <td>China</td>
                                                        <td>Zhangcun</td>
                                                        <td>3 Goodland Terrace</td>
                                                        <td>Pavel Kringe</td>
                                                        <td>Goldner-Lehner</td>
                                                        <td>4/2/2017</td>
                                                        <td><span class="m-badge  m-badge--success m-badge--wide">Success</span></td>
                                                        <td style="display: none;"><span class="m-badge m-badge--danger m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-danger">Online</span></td>
                                                        <td nowrap="" style="display: none;">
                                                            <span class="dropdown">
                                                                <a href="#" class="btn m-btn m-btn--hover-brand m-btn--icon m-btn--icon-only m-btn--pill" data-toggle="dropdown" aria-expanded="true">
                                                                    <i class="la la-ellipsis-h"></i>
                                                                </a>
                                                                <div class="dropdown-menu dropdown-menu-right">
                                                                    <a class="dropdown-item" href="#"><i class="la la-edit"></i>Edit Details</a>
                                                                    <a class="dropdown-item" href="#"><i class="la la-leaf"></i>Update Status</a>
                                                                    <a class="dropdown-item" href="#"><i class="la la-print"></i>Generate Report</a>
                                                                </div>
                                                            </span>
                                                            <a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-brand m-btn--icon m-btn--icon-only m-btn--pill" title="View">
                                                                <i class="la la-edit"></i>
                                                            </a></td>
                                                    </tr>
                                                    <tr role="row" class="even">
                                                        <td class=" dt-right" tabindex="0">
                                                            <label class="m-checkbox m-checkbox--single m-checkbox--solid m-checkbox--brand">
                                                                <input type="checkbox" value="" class="m-checkable">
                                                                <span></span>
                                                            </label>
                                                        </td>
                                                        <td class="sorting_1">68084-123</td>
                                                        <td>Argentina</td>
                                                        <td>Puerto Iguazú</td>
                                                        <td>2 Pine View Park</td>
                                                        <td>Ula Luckin</td>
                                                        <td>Kulas, Cassin and Batz</td>
                                                        <td>5/26/2016</td>
                                                        <td><span class="m-badge m-badge--brand m-badge--wide">Pending</span></td>
                                                        <td style="display: none;"><span class="m-badge m-badge--primary m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-primary">Retail</span></td>
                                                        <td nowrap="" style="display: none;">
                                                            <span class="dropdown">
                                                                <a href="#" class="btn m-btn m-btn--hover-brand m-btn--icon m-btn--icon-only m-btn--pill" data-toggle="dropdown" aria-expanded="true">
                                                                    <i class="la la-ellipsis-h"></i>
                                                                </a>
                                                                <div class="dropdown-menu dropdown-menu-right">
                                                                    <a class="dropdown-item" href="#"><i class="la la-edit"></i>Edit Details</a>
                                                                    <a class="dropdown-item" href="#"><i class="la la-leaf"></i>Update Status</a>
                                                                    <a class="dropdown-item" href="#"><i class="la la-print"></i>Generate Report</a>
                                                                </div>
                                                            </span>
                                                            <a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-brand m-btn--icon m-btn--icon-only m-btn--pill" title="View">
                                                                <i class="la la-edit"></i>
                                                            </a></td>
                                                    </tr>
                                                    <tr role="row" class="odd">
                                                        <td class=" dt-right" tabindex="0">
                                                            <label class="m-checkbox m-checkbox--single m-checkbox--solid m-checkbox--brand">
                                                                <input type="checkbox" value="" class="m-checkable">
                                                                <span></span>
                                                            </label>
                                                        </td>
                                                        <td class="sorting_1">67510-0062</td>
                                                        <td>South Africa</td>
                                                        <td>Pongola</td>
                                                        <td>02534 Hauk Trail</td>
                                                        <td>Shandee Goracci</td>
                                                        <td>Bergnaum, Thiel and Schuppe</td>
                                                        <td>7/24/2016</td>
                                                        <td><span class="m-badge  m-badge--info m-badge--wide">Info</span></td>
                                                        <td style="display: none;"><span class="m-badge m-badge--accent m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-accent">Direct</span></td>
                                                        <td nowrap="" style="display: none;">
                                                            <span class="dropdown">
                                                                <a href="#" class="btn m-btn m-btn--hover-brand m-btn--icon m-btn--icon-only m-btn--pill" data-toggle="dropdown" aria-expanded="true">
                                                                    <i class="la la-ellipsis-h"></i>
                                                                </a>
                                                                <div class="dropdown-menu dropdown-menu-right">
                                                                    <a class="dropdown-item" href="#"><i class="la la-edit"></i>Edit Details</a>
                                                                    <a class="dropdown-item" href="#"><i class="la la-leaf"></i>Update Status</a>
                                                                    <a class="dropdown-item" href="#"><i class="la la-print"></i>Generate Report</a>
                                                                </div>
                                                            </span>
                                                            <a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-brand m-btn--icon m-btn--icon-only m-btn--pill" title="View">
                                                                <i class="la la-edit"></i>
                                                            </a></td>
                                                    </tr>
                                                    <tr role="row" class="even">
                                                        <td class=" dt-right" tabindex="0">
                                                            <label class="m-checkbox m-checkbox--single m-checkbox--solid m-checkbox--brand">
                                                                <input type="checkbox" value="" class="m-checkable">
                                                                <span></span>
                                                            </label>
                                                        </td>
                                                        <td class="sorting_1">67457-428</td>
                                                        <td>Indonesia</td>
                                                        <td>Talok</td>
                                                        <td>3050 Buell Terrace</td>
                                                        <td>Evangeline Cure</td>
                                                        <td>Pfannerstill-Treutel</td>
                                                        <td>7/2/2016</td>
                                                        <td><span class="m-badge m-badge--brand m-badge--wide">Pending</span></td>
                                                        <td style="display: none;"><span class="m-badge m-badge--accent m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-accent">Direct</span></td>
                                                        <td nowrap="" style="display: none;">
                                                            <span class="dropdown">
                                                                <a href="#" class="btn m-btn m-btn--hover-brand m-btn--icon m-btn--icon-only m-btn--pill" data-toggle="dropdown" aria-expanded="true">
                                                                    <i class="la la-ellipsis-h"></i>
                                                                </a>
                                                                <div class="dropdown-menu dropdown-menu-right">
                                                                    <a class="dropdown-item" href="#"><i class="la la-edit"></i>Edit Details</a>
                                                                    <a class="dropdown-item" href="#"><i class="la la-leaf"></i>Update Status</a>
                                                                    <a class="dropdown-item" href="#"><i class="la la-print"></i>Generate Report</a>
                                                                </div>
                                                            </span>
                                                            <a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-brand m-btn--icon m-btn--icon-only m-btn--pill" title="View">
                                                                <i class="la la-edit"></i>
                                                            </a></td>
                                                    </tr>
                                                    <tr role="row" class="odd">
                                                        <td class=" dt-right" tabindex="0">
                                                            <label class="m-checkbox m-checkbox--single m-checkbox--solid m-checkbox--brand">
                                                                <input type="checkbox" value="" class="m-checkable">
                                                                <span></span>
                                                            </label>
                                                        </td>
                                                        <td class="sorting_1">64980-196</td>
                                                        <td>Croatia</td>
                                                        <td>Vinica</td>
                                                        <td>0 Elka Street</td>
                                                        <td>Hazlett Kite</td>
                                                        <td>Streich LLC</td>
                                                        <td>8/5/2016</td>
                                                        <td><span class="m-badge  m-badge--danger m-badge--wide">Danger</span></td>
                                                        <td style="display: none;"><span class="m-badge m-badge--danger m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-danger">Online</span></td>
                                                        <td nowrap="" style="display: none;">
                                                            <span class="dropdown">
                                                                <a href="#" class="btn m-btn m-btn--hover-brand m-btn--icon m-btn--icon-only m-btn--pill" data-toggle="dropdown" aria-expanded="true">
                                                                    <i class="la la-ellipsis-h"></i>
                                                                </a>
                                                                <div class="dropdown-menu dropdown-menu-right">
                                                                    <a class="dropdown-item" href="#"><i class="la la-edit"></i>Edit Details</a>
                                                                    <a class="dropdown-item" href="#"><i class="la la-leaf"></i>Update Status</a>
                                                                    <a class="dropdown-item" href="#"><i class="la la-print"></i>Generate Report</a>
                                                                </div>
                                                            </span>
                                                            <a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-brand m-btn--icon m-btn--icon-only m-btn--pill" title="View">
                                                                <i class="la la-edit"></i>
                                                            </a></td>
                                                    </tr>
                                                    <tr role="row" class="even">
                                                        <td class=" dt-right" tabindex="0">
                                                            <label class="m-checkbox m-checkbox--single m-checkbox--solid m-checkbox--brand">
                                                                <input type="checkbox" value="" class="m-checkable">
                                                                <span></span>
                                                            </label>
                                                        </td>
                                                        <td class="sorting_1">64679-154</td>
                                                        <td>Mongolia</td>
                                                        <td>Sharga</td>
                                                        <td>102 Holmberg Park</td>
                                                        <td>Tannie Seakes</td>
                                                        <td>Blanda Group</td>
                                                        <td>7/31/2016</td>
                                                        <td><span class="m-badge  m-badge--danger m-badge--wide">Danger</span></td>
                                                        <td style="display: none;"><span class="m-badge m-badge--accent m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-accent">Direct</span></td>
                                                        <td nowrap="" style="display: none;">
                                                            <span class="dropdown">
                                                                <a href="#" class="btn m-btn m-btn--hover-brand m-btn--icon m-btn--icon-only m-btn--pill" data-toggle="dropdown" aria-expanded="true">
                                                                    <i class="la la-ellipsis-h"></i>
                                                                </a>
                                                                <div class="dropdown-menu dropdown-menu-right">
                                                                    <a class="dropdown-item" href="#"><i class="la la-edit"></i>Edit Details</a>
                                                                    <a class="dropdown-item" href="#"><i class="la la-leaf"></i>Update Status</a>
                                                                    <a class="dropdown-item" href="#"><i class="la la-print"></i>Generate Report</a>
                                                                </div>
                                                            </span>
                                                            <a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-brand m-btn--icon m-btn--icon-only m-btn--pill" title="View">
                                                                <i class="la la-edit"></i>
                                                            </a></td>
                                                    </tr>
                                                    <tr role="row" class="odd">
                                                        <td class=" dt-right" tabindex="0">
                                                            <label class="m-checkbox m-checkbox--single m-checkbox--solid m-checkbox--brand">
                                                                <input type="checkbox" value="" class="m-checkable">
                                                                <span></span>
                                                            </label>
                                                        </td>
                                                        <td class="sorting_1">64117-168</td>
                                                        <td>China</td>
                                                        <td>Rongkou</td>
                                                        <td>023 South Way</td>
                                                        <td>Gerhard Reinhard</td>
                                                        <td>Gleason, Kub and Marquardt</td>
                                                        <td>11/26/2016</td>
                                                        <td><span class="m-badge  m-badge--info m-badge--wide">Info</span></td>
                                                        <td style="display: none;"><span class="m-badge m-badge--accent m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-accent">Direct</span></td>
                                                        <td nowrap="" style="display: none;">
                                                            <span class="dropdown">
                                                                <a href="#" class="btn m-btn m-btn--hover-brand m-btn--icon m-btn--icon-only m-btn--pill" data-toggle="dropdown" aria-expanded="true">
                                                                    <i class="la la-ellipsis-h"></i>
                                                                </a>
                                                                <div class="dropdown-menu dropdown-menu-right">
                                                                    <a class="dropdown-item" href="#"><i class="la la-edit"></i>Edit Details</a>
                                                                    <a class="dropdown-item" href="#"><i class="la la-leaf"></i>Update Status</a>
                                                                    <a class="dropdown-item" href="#"><i class="la la-print"></i>Generate Report</a>
                                                                </div>
                                                            </span>
                                                            <a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-brand m-btn--icon m-btn--icon-only m-btn--pill" title="View">
                                                                <i class="la la-edit"></i>
                                                            </a></td>
                                                    </tr>
                                                    <tr role="row" class="even">
                                                        <td class=" dt-right" tabindex="0">
                                                            <label class="m-checkbox m-checkbox--single m-checkbox--solid m-checkbox--brand">
                                                                <input type="checkbox" value="" class="m-checkable">
                                                                <span></span>
                                                            </label>
                                                        </td>
                                                        <td class="sorting_1">63629-4697</td>
                                                        <td>Indonesia</td>
                                                        <td>Cihaur</td>
                                                        <td>01652 Fulton Trail</td>
                                                        <td>Emelita Giraldez</td>
                                                        <td>Rosenbaum-Reichel</td>
                                                        <td>8/6/2017</td>
                                                        <td><span class="m-badge  m-badge--danger m-badge--wide">Danger</span></td>
                                                        <td style="display: none;"><span class="m-badge m-badge--accent m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-accent">Direct</span></td>
                                                        <td nowrap="" style="display: none;">
                                                            <span class="dropdown">
                                                                <a href="#" class="btn m-btn m-btn--hover-brand m-btn--icon m-btn--icon-only m-btn--pill" data-toggle="dropdown" aria-expanded="true">
                                                                    <i class="la la-ellipsis-h"></i>
                                                                </a>
                                                                <div class="dropdown-menu dropdown-menu-right">
                                                                    <a class="dropdown-item" href="#"><i class="la la-edit"></i>Edit Details</a>
                                                                    <a class="dropdown-item" href="#"><i class="la la-leaf"></i>Update Status</a>
                                                                    <a class="dropdown-item" href="#"><i class="la la-print"></i>Generate Report</a>
                                                                </div>
                                                            </span>
                                                            <a href="#" class="m-portlet__nav-link btn m-btn m-btn--hover-brand m-btn--icon m-btn--icon-only m-btn--pill" title="View">
                                                                <i class="la la-edit"></i>
                                                            </a></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 col-md-5">
                                            <div class="dataTables_info" id="m_table_1_info" role="status" aria-live="polite">Showing 1 to 10 of 50 entries</div>
                                        </div>
                                        <div class="col-sm-12 col-md-7 dataTables_pager">
                                            <div class="dataTables_length" id="m_table_1_length">
                                                <label>
                                                    Display
                                                    <select name="m_table_1_length" aria-controls="m_table_1" class="custom-select custom-select-sm form-control form-control-sm">
                                                        <option value="5">5</option>
                                                        <option value="10">10</option>
                                                        <option value="25">25</option>
                                                        <option value="50">50</option>
                                                    </select></label>
                                            </div>
                                            <div class="dataTables_paginate paging_simple_numbers" id="m_table_1_paginate">
                                                <ul class="pagination">
                                                    <li class="paginate_button page-item previous disabled" id="m_table_1_previous"><a href="#" aria-controls="m_table_1" data-dt-idx="0" tabindex="0" class="page-link"><i class="la la-angle-left"></i></a></li>
                                                    <li class="paginate_button page-item active"><a href="#" aria-controls="m_table_1" data-dt-idx="1" tabindex="0" class="page-link">1</a></li>
                                                    <li class="paginate_button page-item "><a href="#" aria-controls="m_table_1" data-dt-idx="2" tabindex="0" class="page-link">2</a></li>
                                                    <li class="paginate_button page-item "><a href="#" aria-controls="m_table_1" data-dt-idx="3" tabindex="0" class="page-link">3</a></li>
                                                    <li class="paginate_button page-item "><a href="#" aria-controls="m_table_1" data-dt-idx="4" tabindex="0" class="page-link">4</a></li>
                                                    <li class="paginate_button page-item "><a href="#" aria-controls="m_table_1" data-dt-idx="5" tabindex="0" class="page-link">5</a></li>
                                                    <li class="paginate_button page-item next" id="m_table_1_next"><a href="#" aria-controls="m_table_1" data-dt-idx="6" tabindex="0" class="page-link"><i class="la la-angle-right"></i></a></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane" id="m_tabs_6_2" role="tabpanel">
                                It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more
												recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
                            </div>
                            <div class="tab-pane active show" id="m_tabs_6_3" role="tabpanel">
                                Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type
												specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged
                            </div>
                            <div class="tab-pane active show" id="m_tabs_6_4" role="tabpanel">
                                Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type
												specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged
                            </div>
                            <div class="tab-pane active show" id="m_tabs_6_5" role="tabpanel">
                                Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type
												specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>



</asp:Content>
