<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard_Retailer.aspx.cs" Inherits="Upkeep_v3.Dashboard_Retailer" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>

        <script>

        $(document).ready(function () {

            $('.m_selectpicker').selectpicker();
            //alert('1111');
            var picker = $('#daterangepicker');
            var start = moment().subtract(29, 'days');
            var end = moment();

            function cb(start, end, label) {
                var title = '';
                var range = '';

                if ((end - start) < 100 || label == 'Today') {
                    title = 'Today:';
                    range = start.format('MMM D');
                } else if (label == 'Yesterday') {
                    title = 'Yesterday:';
                    range = start.format('MMM D');
                } else {
                    range = start.format('MMM D') + ' - ' + end.format('MMM D');
                }

                picker.find('.m-subheader__daterange-date').html(range);
                picker.find('.m-subheader__daterange-title').html(title);

                $('#start_date').val(start.format('DD/MM/YYYY'));
                $('#end_date').val(end.format('DD/MM/YYYY'));
                $('#date_range_title').val(title + range);

                 //call button click here
                $("#btnSearchDashboard").click();
            }

            picker.daterangepicker({
                direction: mUtil.isRTL(),
                startDate: start,
                endDate: end,
                opens: 'left',
                ranges: {
                    'Today': [moment(), moment()],
                    'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                    'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                    'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                    'This Month': [moment().startOf('month'), moment().endOf('month')],
                    'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
                }
            }, cb);

            var IsPostBack2 = $('#hdn_IsPostBack').val();

            if (IsPostBack2 == "no") {
                cb(start, end, '');
            }
            else {

                picker.find('.m-subheader__daterange-title').html($('#date_range_title').val());
            }



        });

    </script>



    <div class="m-grid__item m-grid__item--fluid m-wrapper" style="margin-bottom: 20px;">
        <div class="m-content">

        <div class="m-subheader ">
            <div class="d-flex align-items-center">
                <div class="mr-auto">
                    <h3 class="m-subheader__title " style="padding: 7px 7px 7px 0;">Utilities & Widgets</h3>

                </div>

            </div>
        </div>
        

    
    <div class="m-porlet">

        <div class="row">

            

            <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

            <div class="col-xl-12">
                <div class="m-portlet m-portlet--mobile m-portlet--body-progress-">
                    <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <h3 class="m-portlet__head-text">Retail Store Attendance Portal<small>Log your Store Opening & Closing Time below</small>
                                    </h3>
                                </div>
                            </div>
                        </div>
                    <div class="m-portlet__body">
                      <asp:UpdatePanel ID="time" runat="server">
                                    <ContentTemplate>
                                        <div class="row m-row--no-padding m-row--col-separator-xl">
                                            <div class="col-md-6">

                                                <!--begin::Total Profit-->
                                                <div class="m-widget24">
                                                    <div class="m-widget24__item">
                                                        <h4 class="m-widget24__title">Store Punch-IN
                                                        </h4>
                                                        <br>
                                                        <span class="m-widget24__desc">Click to log the time when your store Opens

                                                        </span>
                                                        <span class="m-widget24__stats m--font-info">
                                                            <a href="#" class="btn btn-outline-primary m-btn m-btn--icon m-btn--pill m-btn--air" runat="server" id="btnPunchIn" onserverclick="Btn_Retailer_PunchIn_Click">
                                                                <span>
                                                                    <i class="la la-hand-pointer-o"></i>
                                                                    <span>Punch IN</span>
                                                                </span>
                                                            </a>
                                                        </span>
                                                        <div class="m--space-10"></div>
                                                        <div class="progress m-progress--sm">
                                                            <div class="progress-bar m--bg-brand" role="progressbar" style="width: 100%;" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                                        </div>
                                                        <span class="m-widget24__change">Last Punch-IN Logged Today
                                                        </span>
                                                        <span class="m-widget24__number">
                                                            <asp:Label ID="lblPunchInTime" runat="server"></asp:Label>

                                                        </span>
                                                    </div>
                                                </div>

                                                <!--end::Total Profit-->
                                            </div>
                                            <div class="col-md-6">

                                                <!--begin::New Feedbacks-->
                                                <div class="m-widget24">
                                                    <div class="m-widget24__item">
                                                        <h4 class="m-widget24__title">Store Punch-OUT
                                                        </h4>
                                                        <br>
                                                        <span class="m-widget24__desc">Click to log the time when your store Closes
                                                        </span>
                                                        <span class="m-widget24__stats m--font-info">
                                                            <a href="#" class="btn btn-outline-success m-btn m-btn--icon m-btn--pill m-btn--air" runat="server" id="btnPunchOut"  onserverclick="Btn_Retailer_PunchOut_Click">
                                                                <span>
                                                                    <i class="la la-hand-peace-o"></i>
                                                                    <span>Punch OUT</span>
                                                                </span>
                                                            </a>
                                                        </span>
                                                        <div class="m--space-10"></div>
                                                        <div class="progress m-progress--sm">
                                                            <div class="progress-bar m--bg-brand" role="progressbar" style="width: 100%;" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                                        </div>
                                                        <span class="m-widget24__change">Last Punch-OUT Logged Today
                                                        </span>
                                                        <span class="m-widget24__number">
                                                            <asp:Label ID="lblPunchOutTime" runat="server"></asp:Label>
                                                        </span>
                                                    </div>
                                                </div>

                                                <!--end::New Feedbacks-->
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                    </div>
                </div>
            </div>

            
        </div>



    </div>



    <div class="m-grid__item m-grid__item--fluid m-wrapper" style="margin-bottom: 20px;">

        <div class="m-subheader ">
            <div class="d-flex align-items-center">
                <div class="mr-auto">
                    <h3 class="m-subheader__title " style="padding: 7px 7px 7px 0;">Dashboard</h3>

                    <span class="m-subheader__daterange" id="daterangepicker">
                        <span class="m-subheader__daterange-label">
                            <span class="m-subheader__daterange-title"></span>
                            <span class="m-subheader__daterange-date m--font-brand"></span>
                            <asp:HiddenField ID="start_date" ClientIDMode="Static" runat="server" />
                            <asp:HiddenField ID="end_date" ClientIDMode="Static" runat="server" />
                            <asp:HiddenField ID="hdn_IsPostBack" ClientIDMode="Static" runat="server" />
                            <asp:HiddenField ID="date_range_title" ClientIDMode="Static" runat="server" />
                            <asp:HiddenField ID="hdnCompanyID" ClientIDMode="Static" runat="server" />
                        </span>
                        <a href="#" class="btn btn-sm btn-brand m-btn m-btn--icon m-btn--icon-only m-btn--custom m-btn--pill">
                            <i class="la la-angle-down"></i>
                        </a>
                    </span>

                    <asp:Button ID="btnSearchDashboard" runat="server" OnClick="btnSearchDashboard_Click" Text="Search" ClientIDMode="Static" style="display:none;" CssClass="btn btn-sm btn-brand" />

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
                                        <img class="m-widget19__img" style="width: 6rem;" src="<%= Page.ResolveClientUrl("~/assets/app/media/img/Dashboard_Icons/tkt.png") %>" alt="">
                                    </div>
                                    <div class="m-widget19__info">
                                        <span class="m-widget19__username m--font-danger" style="font-size: 2rem; margin-bottom: 2.4rem; line-height: initial;">Pending Closure
                                        </span>
                                        <br>
                                        <span class="m-widget19__time" style="line-height: initial;">Total No. of Tickets Pending for Closure
                                        </span>
                                    </div>
                                    <div class="m-widget19__stats" style="line-height: 1;">

                                        <asp:Label ID="lbl_tkt_Pending_Close" runat="server" class="m-widget19__number m--font-danger" Style="font-size: 2.5rem;">
                                            0
                                        </asp:Label>
                                        <span class="m-widget19__comment">Tickets
                                        </span>
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


                            <div class="m-widget1">
                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col-xl-9">
                                            <h3 class="m-widget1__title">Tickets
                                                <span class="m-badge m-badge--secondary m-badge--wide">Total</span>
                                            </h3>
                                            <span class="m-widget1__desc">Total No. of Tickets raised By You</span>

                                        </div>
                                        <div class="col m--align-right">
                                            <asp:Label ID="lbl_Tkt_Total_User" runat="server" class="m-widget1__number m--font-danger">0</asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col-xl-9">
                                            <h3 class="m-widget1__title">Tickets
                                                <span style="width: 110px;">
                                                    <span class="m-badge m-badge--info m-badge--dot"></span>
                                                    <span class="m--font-bold m--font-info">Assigned</span>
                                                </span>
                                                <span class="m-badge m-badge--danger m-badge--wide">Open</span>
                                            </h3>
                                            <span class="m-widget1__desc">No. of tickets raised but no Action is taken yet</span>
                                        </div>
                                        <div class="col m--align-right">
                                            <asp:Label ID="lbl_Tkt_Open_User" runat="server" class="m-widget1__number m--font-success">0</asp:Label>

                                        </div>
                                    </div>
                                </div>

                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col-xl-9">
                                            <h3 class="m-widget1__title">Tickets
                                                <span style="width: 110px;">
                                                    <span class="m-badge m-badge--info m-badge--dot"></span>
                                                    <span class="m--font-bold m--font-success">Accepted</span>
                                                </span>
                                                <span class="m-badge m-badge--danger m-badge--wide">Open</span>
                                            </h3>
                                            <span class="m-widget1__desc">No. of tickets where Users accepted your ticket for Closure</span>
                                        </div>
                                        <div class="col m--align-right">
                                            <asp:Label ID="lbl_tkt_Open_Accepted_User" runat="server" class="m-widget1__number m--font-warning">0</asp:Label>

                                        </div>
                                    </div>
                                </div>

                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col-xl-9">
                                            <h3 class="m-widget1__title">Tickets
                                                
                                            <span class="m-badge m-badge--success m-badge--wide">Closed</span>
                                            </h3>
                                            <span class="m-widget1__desc">No. of Tickets Closed which are raised by You</span>
                                        </div>
                                        <div class="col m--align-right">
                                            <asp:Label ID="lbl_tkt_Closed_User" runat="server" class="m-widget1__number m--font-info">0</asp:Label>

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
                                        <img class="m-widget19__img" style="width: 6rem;" src="<%= Page.ResolveClientUrl("~/assets/app/media/img/Dashboard_Icons/wp.png") %>" alt="">
                                    </div>
                                    <div class="m-widget19__info">
                                        <span class="m-widget19__username m--font-danger" style="font-size: 2rem; margin-bottom: 2.4rem;    line-height: initial;">Pending Approvals
                                        </span>
                                        <br>
                                        <span class="m-widget19__time" style="line-height: initial;" >Total No. of your Work Permits pending for approval
                                        </span>
                                    </div>
                                    <div class="m-widget19__stats" style="line-height: 1;">

                                        <asp:Label ID="lbl_WP_Pending_Approvals" runat="server" class="m-widget19__number m--font-danger" Style="font-size: 2.5rem;">
                                            0
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
                                        <div class="col-xl-9">
                                            <h3 class="m-widget1__title">Work Permits
                                                <span class="m-badge m-badge--danger m-badge--wide">Open</span>
                                            </h3>
                                            <span class="m-widget1__desc">Your Permit requests, pending for action</span>

                                        </div>
                                        <div class="col m--align-right">
                                            <asp:Label ID="lbl_WP_Open_User" runat="server" class="m-widget1__number m--font-danger">0</asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col-xl-9">
                                            <h3 class="m-widget1__title">Work Permits
                                                
                                            <span class="m-badge m-badge--success m-badge--wide">In Progress</span>
                                            </h3>
                                            <span class="m-widget1__desc">Your Permit requests, under approval</span>
                                        </div>
                                        <div class="col m--align-right">
                                            <asp:Label ID="lbl_WP_InProgress_User" runat="server" class="m-widget1__number m--font-success">0</asp:Label>

                                        </div>
                                    </div>
                                </div>

                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col-xl-9">
                                            <h3 class="m-widget1__title">Work Permits
                                                
                                            <span class="m-badge m-badge--warning m-badge--wide">On Hold</span>
                                            </h3>
                                            <span class="m-widget1__desc">Your Permit requests, under Hold</span>
                                        </div>
                                        <div class="col m--align-right">
                                            <asp:Label ID="lbl_WP_OnHold_User" runat="server" class="m-widget1__number m--font-warning">0</asp:Label>

                                        </div>
                                    </div>
                                </div>

                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col-xl-9">
                                            <h3 class="m-widget1__title">Work Permits
                                                
                                            <span class="m-badge m-badge--info m-badge--wide">Approved</span>
                                            </h3>
                                            <span class="m-widget1__desc">Your Permit requests, Approved</span>
                                        </div>
                                        <div class="col m--align-right">
                                            <asp:Label ID="lbl_WP_Approved_User" runat="server" class="m-widget1__number m--font-info">0</asp:Label>

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
                                        <img class="m-widget19__img" style="width: 6rem;" src="<%= Page.ResolveClientUrl("~/assets/app/media/img/Dashboard_Icons/gp.png") %>" alt="">
                                    </div>
                                    <div class="m-widget19__info">
                                        <span class="m-widget19__username m--font-danger" style="font-size: 2rem; margin-bottom: 2.4rem;    line-height: initial;">Pending Approvals
                                        </span>
                                        <br>
                                        <span class="m-widget19__time" style="line-height: initial;">Total No. of your Gate Passes pending for approval
                                        </span>
                                    </div>
                                    <div class="m-widget19__stats" style="line-height: 1;">
                                        <asp:Label ID="lbl_GP_Pending_Approval" runat="server" class="m-widget19__number m--font-danger" Style="font-size: 2.5rem;">
                                            0
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
                                        <div class="col-xl-9">
                                            <h3 class="m-widget1__title">Gatepass
                                                <span class="m-badge m-badge--danger m-badge--wide">Open</span>
                                            </h3>
                                            <span class="m-widget1__desc">Your Gatepass requests, pending for action</span>
                                        </div>
                                        <div class="col m--align-right">
                                            <asp:Label ID="lbl_GP_Open_User" runat="server" class="m-widget1__number m--font-danger">
                                                0
                                            </asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col-xl-9">
                                            <h3 class="m-widget1__title">Gatepass
                                                
                                            <span class="m-badge m-badge--success m-badge--wide">In Progress</span>
                                            </h3>
                                            <span class="m-widget1__desc">Your Gatepass requests, under approval</span>
                                        </div>
                                        <div class="col m--align-right">
                                            <asp:Label ID="lbl_GP_InProgress" runat="server" class="m-widget1__number m--font-success">
                                                0
                                            </asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col-xl-9">
                                            <h3 class="m-widget1__title">Gatepass
                                                
                                            <span class="m-badge m-badge--warning m-badge--wide">On Hold</span>
                                            </h3>
                                            <span class="m-widget1__desc">Your Gatepass requests, under Hold</span>
                                        </div>
                                        <div class="col m--align-right">
                                            <asp:Label ID="lbl_GP_OnHold" runat="server" class="m-widget1__number m--font-warning">
                                                0
                                            </asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col-xl-9">
                                            <h3 class="m-widget1__title">Gatepass
                                                
                                            <span class="m-badge m-badge--info m-badge--wide">Approved</span>
                                            </h3>
                                            <span class="m-widget1__desc">Your Gatepass requests, Approved</span>
                                        </div>
                                        <div class="col m--align-right">
                                            <asp:Label ID="lbl_GP_Approved_User" runat="server" class="m-widget1__number m--font-info">
                                                0
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

    </div>
    </div>
   


</asp:Content>
