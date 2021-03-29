<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard_Employee.aspx.cs" Inherits="Upkeep_v3.Dashboard_Employee" %>

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
                        <asp:Button ID="btn_Employee_Dashboard" runat="server" Text="Your Account Dashboard" class="m-btn btn btn-success" OnClick="btn_Employee_Dashboard_Click" />
                        <asp:Button ID="btn_Admin_Dashboard" runat="server" Text="Switch to Admin Dashboard" class="m-btn btn btn-secondary" OnClick="btn_Admin_Dashboard_Click" />

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
                            <div class="m-widget19__content ">
                                <div class="m-widget19__header">

                                    <div class="m-widget19__user-img">
                                        <img class="m-widget19__img" style="width: 6rem;" src="../../assets/app/media/img/Dashboard_Icons/pending.jpg" alt="">
                                    </div>
                                    <div class="m-widget19__info">
                                        <span class="m-widget19__username m--font-danger" style="font-size: 2rem; margin-bottom: 2.4rem;">Pending Closure
                                        </span>
                                        <br>
                                        <span class="m-widget19__time">Total No. of Tickets accepted by You which requires closure
                                        </span>
                                    </div>
                                    <div class="m-widget19__stats" style="line-height: 1;">
                                        <asp:Label ID="lbl_tkt_Pending_Close" runat="server" class="m-widget19__number m--font-danger" Style="font-size: 2.5rem;">
                                            17
                                        </asp:Label>

                                        <span class="m-widget19__comment">Tickets
                                        </span>
                                    </div>

                                </div>
                            </div>

                            <div class="m-widget1">
                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col">
                                            <h3 class="m-widget1__title">Tickets
                                                <span style="width: 110px;">
                                                    <span class="m-badge m-badge--info m-badge--dot"></span>
                                                    <span class="m--font-bold m--font-info">Assigned</span>
                                                </span>
                                                <span class="m-badge m-badge--danger m-badge--wide">Open</span>
                                            </h3>

                                            <span class="m-widget1__desc">No. of Tickets Assigned at your level</span>

                                        </div>
                                        <div class="col m--align-right">
                                            <asp:Label ID="lbl_Tkt_Open_Assigned" runat="server" class="m-widget1__number m--font-info">17,801</asp:Label>

                                        </div>
                                    </div>
                                </div>
                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col">
                                            <h3 class="m-widget1__title">Tickets
                                                <span style="width: 110px;">
                                                    <span class="m-badge m-badge--success m-badge--dot"></span>
                                                    <span class="m--font-bold m--font-success">Accepted</span>
                                                </span>

                                                <span class="m-badge m-badge--danger m-badge--wide">Open</span>
                                            </h3>
                                            <span class="m-widget1__desc">No. of Tickets Accepted by You</span>
                                        </div>
                                        <div class="col m--align-right">
                                            <asp:Label ID="lbl_tkt_Open_Accepted" runat="server" class="m-widget1__number m--font-success">1,800</asp:Label>

                                        </div>
                                    </div>
                                </div>
                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col">
                                            <h3 class="m-widget1__title">Tickets
                                                <span style="width: 110px;">
                                                    <span class="m-badge m-badge--warning m-badge--dot"></span>
                                                    <span class="m--font-bold m--font-warning">Hold</span>
                                                </span>

                                                <span class="m-badge m-badge--warning m-badge--wide">Parked</span>
                                            </h3>
                                            <span class="m-widget1__desc">No. of Tickets Parked by you</span>
                                        </div>
                                        <div class="col m--align-right">
                                            <asp:Label ID="lbl_Tkt_Parked_Hold" runat="server" class="m-widget1__number m--font-warning">27</asp:Label>

                                        </div>
                                    </div>
                                </div>

                                <div class="m-stack m-stack--ver m-stack--general m-stack--demo" style="height: 45px;">
                                    <div class="m-stack__item m-stack__item--center">
                                        <div class="m-stack__demo-item">

                                            <span class="m-widget19__username m--font-primary" style="font-size: 1rem; margin-bottom: 2.4rem;">Summary of Tickets raised by You
                                            </span>

                                        </div>
                                    </div>
                                </div>


                                <div class="m-stack m-stack--ver m-stack--general m-stack--demo">

                                    <div class="m-stack__item m-stack__item--center">
                                        <div class="m-stack__demo-item">
                                            <span class="m-badge m-badge--danger m-badge--wide">Open</span>
                                        </div>
                                        </br>
                                        <asp:Label ID="lbl_Tkt_Open_User" runat="server" class="m-widget1__number m--font-danger">1,800</asp:Label>

                                    </div>

                                    <div class="m-stack__item m-stack__item--center">
                                        <div class="m-stack__demo-item">
                                            <span class="m-badge m-badge--success m-badge--wide">Closed</span>
                                        </div>
                                        </br>
                                        <asp:Label ID="lbl_tkt_Closed_User" runat="server" class="m-widget1__number m--font-success">1,800</asp:Label>

                                    </div>

                                    <div class="m-stack__item m-stack__item--center">
                                        <div class="m-stack__demo-item">
                                            <span class="m-badge m-badge--secondary m-badge--wide">Expired</span>
                                        </div>
                                        </br>
                                        <asp:Label ID="lbl_Tkt_Expired_User" runat="server" class="m-widget1__number m--font-secondary">1,800</asp:Label>

                                    </div>

                                </div>


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

                            <div class="m-widget19__content ">
                                <div class="m-widget19__header">
                                    <div class="m-widget19__user-img">
                                        <img class="m-widget19__img" style="width: 6rem;" src="../../assets/app/media/img/Dashboard_Icons/pending.jpg" alt="">
                                    </div>
                                    <div class="m-widget19__info">
                                        <span class="m-widget19__username m--font-danger" style="font-size: 2rem; margin-bottom: 2.4rem;">Incomplete Checklists
                                        </span>
                                        <br>
                                        <span class="m-widget19__time">Total No. of Checklists pending for closure
                                        </span>
                                    </div>
                                    <div class="m-widget19__stats" style="line-height: 1;">
                                        <asp:Label ID="lbl_Chk_Total" runat="server" class="m-widget19__number m--font-danger" Style="font-size: 2.5rem;">
                                            18
                                        </asp:Label>
                                        <span class="m-widget19__comment">Checklists
                                        </span>
                                    </div>

                                </div>
                            </div>



                            <div class="m-widget1">
                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col">
                                            <h3 class="m-widget1__title">Checklists
                                                
                                                <span style="width: 110px;">
                                                    <span class="m-badge m-badge--info m-badge--dot"></span>
                                                    <span class="m--font-bold m--font-info">Draft</span>
                                                </span>
                                                <span class="m-badge m-badge--danger m-badge--wide">Open</span>
                                            </h3>

                                            <span class="m-widget1__desc">No. of Checklists partially done</span>

                                        </div>
                                        <div class="col m--align-right">
                                            <asp:Label ID="lbl_Chk_Open_User" runat="server" class="m-widget1__number m--font-info">17,800</asp:Label>

                                        </div>
                                    </div>
                                </div>
                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col">
                                            <h3 class="m-widget1__title">Checklists
                                                
                                            <span class="m-badge m-badge--success m-badge--wide">Closed</span>
                                            </h3>
                                            <span class="m-widget1__desc">No. of Checklists closed by You</span>
                                        </div>
                                        <div class="col m--align-right">
                                            <asp:Label ID="lbl_Chk_Closed_User" runat="server" class="m-widget1__number m--font-success">1,800</asp:Label>

                                        </div>
                                    </div>
                                </div>


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
                            <div class="m-widget19__content ">
                                <div class="m-widget19__header">
                                    <div class="m-widget19__user-img">
                                        <img class="m-widget19__img" style="width: 6rem;" src="../../assets/app/media/img/Dashboard_Icons/pending.jpg" alt="">
                                    </div>
                                    <div class="m-widget19__info">
                                        <span class="m-widget19__username m--font-danger" style="font-size: 2rem; margin-bottom: 2.4rem;">Pending Approvals
                                        </span>
                                        <br>
                                        <span class="m-widget19__time">Total No. of Work Permits pending for your approval
                                        </span>
                                    </div>
                                    <div class="m-widget19__stats" style="line-height: 1;">

                                        <asp:Label ID="lbl_WP_Pending_Approvals" runat="server" class="m-widget19__number m--font-danger" Style="font-size: 2.5rem;">
                                            18
                                        </asp:Label>
                                        <span class="m-widget19__comment">Work Permits
                                        </span>
                                    </div>

                                </div>
                            </div>

                            <div class="m-stack m-stack--ver m-stack--general m-stack--demo" style="height: 45px;">
                                <div class="m-stack__item m-stack__item--center">
                                    <div class="m-stack__demo-item">

                                        <span class="m-widget19__username m--font-primary" style="font-size: 1rem; margin-bottom: 2.4rem;">Summary of Permit Requests raised by You
                                        </span>

                                    </div>
                                </div>
                            </div>


                            <div class="m-widget1">
                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col">
                                            <h3 class="m-widget1__title">Work Permits
                                                <span class="m-badge m-badge--danger m-badge--wide">Open</span>
                                            </h3>
                                            <span class="m-widget1__desc">Your Permit requests, pending for action</span>

                                        </div>
                                        <div class="col m--align-right">
                                            <asp:Label ID="lbl_WP_Open_User" runat="server" class="m-widget1__number m--font-danger">17,800</asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col">
                                            <h3 class="m-widget1__title">Work Permits
                                                
                                            <span class="m-badge m-badge--success m-badge--wide">In Progress</span>
                                            </h3>
                                            <span class="m-widget1__desc">Your Permit requests, under approval</span>
                                        </div>
                                        <div class="col m--align-right">
                                            <asp:Label ID="lbl_WP_InProgress_User" runat="server" class="m-widget1__number m--font-success">1,800</asp:Label>

                                        </div>
                                    </div>
                                </div>

                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col">
                                            <h3 class="m-widget1__title">Work Permits
                                                
                                            <span class="m-badge m-badge--warning m-badge--wide">On Hold</span>
                                            </h3>
                                            <span class="m-widget1__desc">Your Permit requests, under Hold</span>
                                        </div>
                                        <div class="col m--align-right">
                                            <asp:Label ID="lbl_WP_OnHold_User" runat="server" class="m-widget1__number m--font-warning">1,800</asp:Label>

                                        </div>
                                    </div>
                                </div>

                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col">
                                            <h3 class="m-widget1__title">Work Permits
                                                
                                            <span class="m-badge m-badge--info m-badge--wide">Approved</span>
                                            </h3>
                                            <span class="m-widget1__desc">Your Permit requests, Approved</span>
                                        </div>
                                        <div class="col m--align-right">
                                            <asp:Label ID="lbl_WP_Approved_User" runat="server" class="m-widget1__number m--font-info">1,800</asp:Label>

                                        </div>
                                    </div>
                                </div>


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
                            <div class="m-widget19__content ">
                                <div class="m-widget19__header">
                                    <div class="m-widget19__user-img">
                                        <img class="m-widget19__img" style="width: 6rem;" src="../../assets/app/media/img/Dashboard_Icons/pending.jpg" alt="">
                                    </div>
                                    <div class="m-widget19__info">
                                        <span class="m-widget19__username m--font-danger" style="font-size: 2rem; margin-bottom: 2.4rem;">Pending Approvals
                                        </span>
                                        <br>
                                        <span class="m-widget19__time">Total No. of Gatepass pending for your approval
                                        </span>
                                    </div>
                                    <div class="m-widget19__stats" style="line-height: 1;">
                                        <asp:Label ID="lbl_GP_Pending_Approval" runat="server" class="m-widget19__number m--font-danger" Style="font-size: 2.5rem;">
                                            18
                                        </asp:Label>
                                        <span class="m-widget19__comment">Gate Passes
                                        </span>
                                    </div>

                                </div>
                            </div>

                            <div class="m-stack m-stack--ver m-stack--general m-stack--demo" style="height: 45px;">
                                <div class="m-stack__item m-stack__item--center">
                                    <div class="m-stack__demo-item">

                                        <span class="m-widget19__username m--font-primary" style="font-size: 1rem; margin-bottom: 2.4rem;">Summary of Gatepass Requests raised by You
                                        </span>

                                    </div>
                                </div>
                            </div>


                            <div class="m-widget1">
                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col">
                                            <h3 class="m-widget1__title">Gatepass
                                                <span class="m-badge m-badge--danger m-badge--wide">Open</span>
                                            </h3>
                                            <span class="m-widget1__desc">Your Gatepass requests, pending for action</span>
                                        </div>
                                        <div class="col m--align-right">
                                            <asp:Label ID="lbl_GP_Open_User" runat="server" class="m-widget1__number m--font-danger">
                                                17,800
                                            </asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col">
                                            <h3 class="m-widget1__title">Gatepass
                                                
                                            <span class="m-badge m-badge--success m-badge--wide">In Progress</span>
                                            </h3>
                                            <span class="m-widget1__desc">Your Gatepass requests, under approval</span>
                                        </div>
                                        <div class="col m--align-right">
                                            <asp:Label ID="lbl_GP_InProgress" runat="server" class="m-widget1__number m--font-success">
                                                1,800
                                            </asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col">
                                            <h3 class="m-widget1__title">Gatepass
                                                
                                            <span class="m-badge m-badge--warning m-badge--wide">On Hold</span>
                                            </h3>
                                            <span class="m-widget1__desc">Your Gatepass requests, under Hold</span>
                                        </div>
                                        <div class="col m--align-right">
                                            <asp:Label ID="lbl_GP_OnHold" runat="server" class="m-widget1__number m--font-warning">
                                                1,800
                                            </asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col">
                                            <h3 class="m-widget1__title">Gatepass
                                                
                                            <span class="m-badge m-badge--info m-badge--wide">Approved</span>
                                            </h3>
                                            <span class="m-widget1__desc">Your Gatepass requests, Approved</span>
                                        </div>
                                        <div class="col m--align-right">
                                            <asp:Label ID="lbl_GP_Approved_User" runat="server" class="m-widget1__number m--font-info">
                                                1,800
                                            </asp:Label>
                                        </div>
                                    </div>
                                </div>


                            </div>

                        </div>
                    </div>
                </div>

                <!--end:: Ticketing Section-->
            </div>

        </div>


        
    </div>


</asp:Content>
