﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="User_Manual.aspx.cs" Inherits="Upkeep_v3.Knowledge_Base.User_Manual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<iframe src="https://docs.google.com/document/d/1bmq22dHHmRDiJtqrJL3j45lCDdJfroCFpaBQWLHnEWc/"
        style="width: 100%; height: 500px">
            <p>Your browser does not support iframes.</p>
    </iframe>
    <br/>
    <br/>
     <div>
        <h4>TIP : <b>Press Ctrl + F</b> to search anything within the User Manual </h4>
    </div>--%>

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="">

            <!--begin::Portlet-->
            <div class="m-portlet m-portlet--space">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <h3 class="m-portlet__head-text">FAQ Example
                            </h3>
                        </div>
                    </div>
                    <div class="m-portlet__head-tools">
                        <ul class="m-portlet__nav">
                            <li class="m-portlet__nav-item">
                                <a href="#" class="m-portlet__nav-link m-btn--pill">
                                    <div class="m-input-icon m-input-icon--right">
                                        <input type="text" class="form-control form-control-lg m-input m-input--solid m-input--pill" placeholder="Search FAQ...">
                                        <span class="m-input-icon__icon m-input-icon__icon--right"><span><i class="la la-search m--font-brand"></i></span></span>
                                    </div>
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="m-portlet__body">
                    <div class="row">
                        <div class="col-xl-3">
                            <div class="m-tabs" data-tabs="true" data-tabs-contents="#m_sections">
                                <ul class="m-nav m-nav--active-bg m-nav--active-bg-padding-lg m-nav--font-lg m-nav--font-bold m--margin-bottom-20 m--margin-top-10 m--margin-right-40" id="m_nav" role="tablist">
                                    <li class="m-nav__item">
                                        <a class="m-nav__link m-tabs__item m-tabs__item--active" data-tab-target="#m_section_1" href="#">
                                            <span class="m-nav__link-text">Ticketing</span>
                                        </a>
                                    </li>
                                    <li class="m-nav__item">
                                        <a class="m-nav__link m-tabs__item" data-tab-target="#m_section_2" href="#">
                                            <span class="m-nav__link-text">Google Maps</span>
                                        </a>
                                    </li>
                                    <li class="m-nav__item">
                                        <a class="m-nav__link collapsed" role="tab" id="m_nav_link_1" data-toggle="collapse" href="#m_nav_sub_1" aria-expanded=" false">
                                            <span class="m-nav__link-title">
                                                <span class="m-nav__link-wrap">
                                                    <span class="m-nav__link-text">Datatables</span>
                                                </span>
                                            </span>
                                            <span class="m-nav__link-arrow"></span>
                                        </a>
                                        <ul class="m-nav__sub collapse" id="m_nav_sub_1" role="tabpanel" aria-labelledby="m_nav_link_1" data-parent="#m_nav">
                                            <li class="m-nav__item">
                                                <a class="m-nav__link m-tabs__item" data-tab-target="#m_section_3" href="#">
                                                    <span class="m-nav__link-bullet m-nav__link-bullet--dot"><span></span></span>
                                                    <span class="m-nav__link-text">Ul Fatures</span>
                                                </a>
                                            </li>
                                            <li class="m-nav__item">
                                                <a class="m-nav__link m-tabs__item" data-tab-target="#m_section_4" href="#">
                                                    <span class="m-nav__link-bullet m-nav__link-bullet--dot"><span></span></span>
                                                    <span class="m-nav__link-title">
                                                        <span class="m-nav__link-wrap">
                                                            <span class="m-nav__link-text">Configuration</span>
                                                        </span>
                                                    </span>
                                                </a>
                                            </li>
                                            <li class="m-nav__item">
                                                <a class="m-nav__link m-tabs__item" data-tab-target="#m_section_5" href="#">
                                                    <span class="m-nav__link-bullet m-nav__link-bullet--dot"><span></span></span>
                                                    <span class="m-nav__link-text">Menu Options</span>
                                                </a>
                                            </li>
                                        </ul>
                                    </li>
                                    <li class="m-nav__item">
                                        <a class="m-nav__link  m-tabs__item" data-tab-target="#m_section_6" href="#">
                                            <span class="m-nav__link-text">Theme Configuration</span>
                                        </a>
                                    </li>
                                    <li class="m-nav__item">
                                        <a class="m-nav__link collapsed" role="tab" id="m_nav_link_2" data-toggle="collapse" href="#m_nav_sub_2" aria-expanded="  false">
                                            <span class="m-nav__link-title">
                                                <span class="m-nav__link-wrap">
                                                    <span class="m-nav__link-text">Top Menu</span>
                                                </span>
                                            </span>
                                            <span class="m-nav__link-arrow"></span>
                                        </a>
                                        <ul class="m-nav__sub collapse" id="m_nav_sub_2" role="tabpanel" aria-labelledby="m_nav_link_2" data-parent="#m_nav">
                                            <li class="m-nav__item">
                                                <a class="m-nav__link" data-toggle="tab" href="#m_section_7" role="tab">
                                                    <span class="m-nav__link-bullet m-nav__link-bullet--line"><span></span></span>
                                                    <span class="m-nav__link-text">New</span>
                                                </a>
                                            </li>
                                            <li class="m-nav__item">
                                                <a class="m-nav__link" data-toggle="tab" href="#m_section_8" role="tab">
                                                    <span class="m-nav__link-bullet m-nav__link-bullet--line"><span></span></span>
                                                    <span class="m-nav__link-title">
                                                        <span class="m-nav__link-wrap">
                                                            <span class="m-nav__link-text">Pending</span>
                                                        </span>
                                                    </span>
                                                </a>
                                            </li>
                                            <li class="m-nav__item">
                                                <a class="m-nav__link" data-toggle="tab" href="#m_section_9" role="tab">
                                                    <span class="m-nav__link-bullet m-nav__link-bullet--line"><span></span></span>
                                                    <span class="m-nav__link-text">Replied</span>
                                                </a>
                                            </li>
                                        </ul>
                                    </li>
                                    <li class="m-nav__item">
                                        <a class="m-nav__link" data-toggle="pill" href="#">
                                            <span class="m-nav__link-text">Sidebar Menu</span>
                                        </a>
                                    </li>
                                    <li class="m-nav__item">
                                        <a class="m-nav__link" data-toggle="pill" href="#">
                                            <span class="m-nav__link-text">Horizontal Menu</span>
                                        </a>
                                    </li>
                                    <li class="m-nav__item">
                                        <a class="m-nav__link" data-toggle="pill" href="#">
                                            <span class="m-nav__link-text">GULP Tasks</span>
                                        </a>
                                    </li>
                                    <li class="m-nav__item">
                                        <a href="" class="m-nav__link">
                                            <span class="m-nav__link-text">Coding & Extending</span>
                                        </a>
                                    </li>
                                    <li class="m-nav__item">
                                        <a href="" class="m-nav__link">
                                            <span class="m-nav__link-text">References</span>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="col-xl-9">
                            <div class="m-tabs-content" id="m_sections">

                                <!--begin::Section 1-->
                                <div class="m-tabs-content__item m-tabs-content__item--active" id="m_section_1">
                                    <h4 class="m--font-bold m--margin-top-15 m--margin-bottom-20">General Instruction</h4>
                                    <div class="m-accordion m-accordion--section m-accordion--padding-lg" id="m_section_1_content">


                                        <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed-" role="tab" id="m_section_1_content_1_head" data-toggle="collapse" href="#m_section_1_content_1_body">
                                                <span class="m-accordion__item-title">Sample Video</span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse show" id="m_section_1_content_1_body" role="tabpanel" aria-labelledby="m_section_1_content_1_head" data-parent="#m_section_1_content">
                                                <div class="m-accordion__item-content">

                                                    <video width="720" height="540" controls="controls">
                                                        <source src="https://compelapps.in/eFacilito_UAT/Knowledge_Base/Videos/Files/test_videos.mp4" type="audio/mp4" />
                                                        Your browser does not support the video tag.
                                                    </video>

                                                </div>
                                            </div>
                                        </div>

                                        <!--end::Item-->

                                        <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed" role="tab" id="m_section_1_content_2_head" data-toggle="collapse" href="#m_section_1_content_2_body">
                                                <span class="m-accordion__item-title">It has survived not only five centuries</span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse" id="m_section_1_content_2_body" role="tabpanel" aria-labelledby="m_section_1_content_2_head" data-parent="#m_section_1_content">
                                                <div class="m-accordion__item-content">
                                                    <p>
                                                        Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.
																	Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the
																	leap into Lorem Ipsum has been the industry's standard dummy text ever
                                                    </p>
                                                    <p>
                                                        Since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into
																	Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into nto Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It ha.
                                                    </p>
                                                    <p>
                                                        Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the
																	leap into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also
																	the leap into
                                                    </p>
                                                    <p>
                                                        It has survived not only five centuries, but also the leap into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen
																	book. It has survived not only five centuries, but also the leap into
                                                    </p>
                                                    <p>
                                                        Lorem Ipsum has been the industry's <a href="#" class="m-link m--font-boldest">Example boldest link</a>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>

                                        <!--end::Item-->

                                        <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed" role="tab" id="m_section_1_content_3_head" data-toggle="collapse" href="#m_section_1_content_3_body">
                                                <span class="m-accordion__item-title">Type and scrambled it to make a type specimen book</span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse" id="m_section_1_content_3_body" role="tabpanel" aria-labelledby="m_section_1_content_3_head" data-parent="#m_section_1_content">
                                                <div class="m-accordion__item-content">
                                                    <p>
                                                        Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.
																	Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the
																	leap into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also
																	the leap into
																	Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into
                                                    </p>
                                                    <p>
                                                        Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the
																	leap into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also
																	the leap into
                                                    </p>
                                                    <p>
                                                        Lorem Ipsum has been the industry's <a href="#" class="m-link m--font-boldest">Example boldest link</a>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>

                                        <!--end::Item-->
                                    </div>
                                </div>

                                <!--begin::Section 1-->

                                <!--begin::Section 2-->
                                <div class="m-tabs-content__item" id="m_section_2">
                                    <h4 class="m--font-bold m--margin-top-15 m--margin-bottom-20">Terms & Conditions</h4>
                                    <div class="m-accordion m-accordion--section m-accordion--padding-lg" id="m_section_2_content">

                                        <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed-" role="tab" id="m_section_2_content_1_head" data-toggle="collapse" href="#m_section_2_content_1_body">
                                                <span class="m-accordion__item-icon"><i class="flaticon-gift"></i></span>
                                                <span class="m-accordion__item-title">Lorem Ipsum has been the industry</span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse show" id="m_section_2_content_1_body" role="tabpanel" aria-labelledby="m_section_2_content_1_head" data-parent="#m_section_2_content">
                                                <div class="m-accordion__item-content">
                                                    <p>
                                                        Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.
																	Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of
                                                    </p>
                                                    <p>
                                                        Type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a
																	galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into
																	Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into
                                                    </p>
                                                    <p>
                                                        Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the
																	leap into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also
																	the leap into
                                                    </p>
                                                    <p>
                                                        Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the
																	leap into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also
																	the leap into
                                                    </p>
                                                    <p>
                                                        Lorem Ipsum has been the industry's <a href="#" class="m-link m--font-boldest">Example boldest link</a>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>

                                        <!--end::Item-->

                                        <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed" role="tab" id="m_section_2_content_2_head" data-toggle="collapse" href="#m_section_2_content_2_body">
                                                <span class="m-accordion__item-icon"><i class="flaticon-calendar-3"></i></span>
                                                <span class="m-accordion__item-title">It has survived not only five centuries</span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse" id="m_section_2_content_2_body" role="tabpanel" aria-labelledby="m_section_2_content_2_head" data-parent="#m_section_2_content">
                                                <div class="m-accordion__item-content">
                                                    <p>
                                                        Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.
																	Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the
																	leap into Lorem Ipsum has been the industry's standard dummy text ever
                                                    </p>
                                                    <p>
                                                        Since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into
																	Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into nto Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It ha.
                                                    </p>
                                                    <p>
                                                        Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the
																	leap into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also
																	the leap into
                                                    </p>
                                                    <p>
                                                        It has survived not only five centuries, but also the leap into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen
																	book. It has survived not only five centuries, but also the leap into
                                                    </p>
                                                    <p>
                                                        Lorem Ipsum has been the industry's <a href="#" class="m-link m--font-boldest">Example boldest link</a>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>

                                        <!--end::Item-->

                                        <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed" role="tab" id="m_section_2_content_3_head" data-toggle="collapse" href="#m_section_2_content_3_body">
                                                <span class="m-accordion__item-icon"><i class="flaticon-security"></i></span>
                                                <span class="m-accordion__item-title">Type and scrambled it to make a type specimen book</span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse" id="m_section_2_content_3_body" role="tabpanel" aria-labelledby="m_section_2_content_3_head" data-parent="#m_section_2_content">
                                                <div class="m-accordion__item-content">
                                                    <p>
                                                        Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.
																	Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the
																	leap into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also
																	the leap into
																	Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into
                                                    </p>
                                                    <p>
                                                        Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the
																	leap into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also
																	the leap into
                                                    </p>
                                                    <p>
                                                        Lorem Ipsum has been the industry's <a href="#" class="m-link m--font-boldest">Example boldest link</a>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>

                                        <!--end::Item-->
                                    </div>
                                </div>

                                <!--begin::Section 2-->

                                <!--begin::Section 3-->
                                <div class="m-tabs-content__item" id="m_section_3">
                                    <h4 class="m--font-bold m--margin-top-15 m--margin-bottom-20">User Policy</h4>
                                    <div class="m-accordion m-accordion--bordered" id="m_section_3_content">

                                        <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head" role="tab" id="m_section_3_content_1_head" data-toggle="collapse" href="#m_section_3_content_1_body">
                                                <span class="m-accordion__item-icon"><i class="flaticon-gift"></i></span>
                                                <span class="m-accordion__item-title">Lorem Ipsum has been the industry</span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse show" id="m_section_3_content_1_body" role="tabpanel" aria-labelledby="m_section_3_content_1_head" data-parent="#m_section_3_content">
                                                <div class="m-accordion__item-content">
                                                    <p>
                                                        Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.
																	Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of
                                                    </p>
                                                    <p>
                                                        Type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a
																	galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into
																	Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into
                                                    </p>
                                                    <p>
                                                        Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the
																	leap into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also
																	the leap into
                                                    </p>
                                                    <p>
                                                        Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the
																	leap into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also
																	the leap into
                                                    </p>
                                                    <p>
                                                        Lorem Ipsum has been the industry's <a href="#" class="m-link m--font-boldest">Example boldest link</a>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>

                                        <!--end::Item-->

                                        <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed" role="tab" id="m_section_3_content_2_head" data-toggle="collapse" href="#m_section_3_content_2_body">
                                                <span class="m-accordion__item-icon"><i class="flaticon-calendar-3"></i></span>
                                                <span class="m-accordion__item-title">It has survived not only five centuries</span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse" id="m_section_3_content_2_body" role="tabpanel" aria-labelledby="m_section_3_content_2_head" data-parent="#m_section_3_content">
                                                <div class="m-accordion__item-content">
                                                    <p>
                                                        Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.
																	Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the
																	leap into Lorem Ipsum has been the industry's standard dummy text ever
                                                    </p>
                                                    <p>
                                                        Since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into
																	Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into nto Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It ha.
                                                    </p>
                                                    <p>
                                                        Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the
																	leap into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also
																	the leap into
                                                    </p>
                                                    <p>
                                                        It has survived not only five centuries, but also the leap into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen
																	book. It has survived not only five centuries, but also the leap into
                                                    </p>
                                                    <p>
                                                        Lorem Ipsum has been the industry's <a href="#" class="m-link m--font-boldest">Example boldest link</a>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>

                                        <!--end::Item-->

                                        <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed" role="tab" id="m_section_3_content_3_head" data-toggle="collapse" href="#m_section_3_content_3_body">
                                                <span class="m-accordion__item-icon"><i class="flaticon-security"></i></span>
                                                <span class="m-accordion__item-title">Type and scrambled it to make a type specimen book</span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse" id="m_section_3_content_3_body" role="tabpanel" aria-labelledby="m_section_3_content_3_head" data-parent="#m_section_3_content">
                                                <div class="m-accordion__item-content">
                                                    <p>
                                                        Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.
																	Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the
																	leap into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also
																	the leap into
																	Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into
                                                    </p>
                                                    <p>
                                                        Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the
																	leap into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also
																	the leap into
                                                    </p>
                                                    <p>
                                                        Lorem Ipsum has been the industry's <a href="#" class="m-link m--font-boldest">Example boldest link</a>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>

                                        <!--end::Item-->
                                    </div>
                                </div>

                                <!--begin::Section 3-->
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!--end::Portlet-->
        </div>

    </div>


</asp:Content>
