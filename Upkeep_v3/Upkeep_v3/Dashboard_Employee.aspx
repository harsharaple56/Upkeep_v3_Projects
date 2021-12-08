<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard_Employee.aspx.cs" Inherits="Upkeep_v3.Dashboard_Employee" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {

            $('.m_selectpicker').selectpicker();
            var picker = $('#daterangepicker');
            var start = moment().subtract(29, 'days');
            var end = moment();

            function cb(start, end, label) {
                $("[id*=load]").removeAttr('style');
                $("[id*=load]").show();
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
                var start_date = $('#start_date').val(start.format('DD/MM/YYYY')).val();
                var end_date = $('#end_date').val(end.format('DD/MM/YYYY')).val();


                var dataString = {
                    'start_Date': start_date,
                    'end_Date': end_date
                };

                var param = JSON.stringify(dataString);
                $.ajax({
                    type: 'POST',
                    url: 'Dashboard_Employee.aspx/GetDashboardDetails',
                    data: param,
                    contentType: 'application/json; charset=utf-8',
                    datatype: 'json',
                    success: function (response) {

                        if (response.d != null) {
                            $("#ContentPlaceHolder1_lbl_Chk_Closed_User").text(response.d.lbl_Chk_Closed_User);
                            $("#ContentPlaceHolder1_lbl_Chk_Open_User").text(response.d.lbl_Chk_Open_User);
                            $("#ContentPlaceHolder1_lbl_Chk_Total").text(response.d.lbl_Chk_Total);
                            $("#ContentPlaceHolder1_lbl_GP_Approved_User").text(response.d.lbl_GP_Approved_User);
                            $("#ContentPlaceHolder1_lbl_GP_InProgress").text(response.d.lbl_GP_InProgress);
                            $("#ContentPlaceHolder1_lbl_GP_OnHold").text(response.d.lbl_GP_OnHold);
                            $("#ContentPlaceHolder1_lbl_GP_Open_User").text(response.d.lbl_GP_Open_User);
                            $("#ContentPlaceHolder1_lbl_GP_Pending_Approval").text(response.d.lbl_GP_Pending_Approval);
                            $("#ContentPlaceHolder1_lbl_Tkt_Expired_User").text(response.d.lbl_Tkt_Expired_User);
                            $("#ContentPlaceHolder1_lbl_Tkt_Open_Assigned").text(response.d.lbl_Tkt_Open_Assigned);
                            $("#ContentPlaceHolder1_lbl_Tkt_Open_User").text(response.d.lbl_Tkt_Open_User);
                            $("#ContentPlaceHolder1_lbl_Tkt_Parked_Hold").text(response.d.lbl_Tkt_Parked_Hold);
                            $("#ContentPlaceHolder1_lbl_VMS_IN").text(response.d.lbl_VMS_IN);
                            $("#ContentPlaceHolder1_lbl_VMS_OUT").text(response.d.lbl_VMS_OUT);
                            $("#ContentPlaceHolder1_lbl_lbl_VMS_Pending").text(response.d.lbl_VMS_Pending);
                            $("#ContentPlaceHolder1_lbl_lbl_VMS_Recieved").text(response.d.lbl_VMS_Recieved);
                            $("#ContentPlaceHolder1_lbl_VMS_Rejected").text(response.d.lbl_VMS_Rejected);
                            $("#ContentPlaceHolder1_lbl_WP_Approved_User").text(response.d.lbl_WP_Approved_User);
                            $("#ContentPlaceHolder1_lbl_WP_InProgress_User").text(response.d.lbl_WP_InProgress_User);
                            $("#ContentPlaceHolder1_lbl_WP_OnHold_User").text(response.d.lbl_WP_OnHold_User);
                            $("#ContentPlaceHolder1_lbl_WP_Open_User").text(response.d.lbl_WP_Open_User);
                            $("#ContentPlaceHolder1_lbl_WP_Pending_Approvals").text(response.d.lbl_WP_Pending_Approvals);
                            $("#ContentPlaceHolder1_lbl_tkt_Open_Accepted").text(response.d.lbl_tkt_Open_Accepted);
                            $("#ContentPlaceHolder1_lbl_tkt_Open_Accepted").text(response.d.lbl_tkt_Open_Accepted);
                            $("#ContentPlaceHolder1_lbl_tkt_Pending_Close").text(response.d.lbl_tkt_Pending_Close);

                            if (response.d.Chk_Visible != undefined && response.d.Chk_Visible == "true") {
                                $("[id*=ContentPlaceHolder1_Chk]").show();
                            }
                            else {
                                $("[id*=ContentPlaceHolder1_Chk]").hide();
                            }

                            if (response.d.GP_Visible != undefined && response.d.GP_Visible == "true") {
                                $("[id*=ContentPlaceHolder1_GP]").show();
                            }
                            else {
                                $("[id*=ContentPlaceHolder1_GP]").hide();
                            }

                            if (response.d.VMS_Visible != undefined && response.d.VMS_Visible == "true") {
                                $("[id*=ContentPlaceHolder1_VMS]").show();
                            }
                            else {
                                $("[id*=ContentPlaceHolder1_VMS]").hide();
                            }

                            if (response.d.WP_Visible != undefined && response.d.WP_Visible == "true") {
                                $("[id*=ContentPlaceHolder1_WP]").show();
                            }
                            else {
                                $("[id*=ContentPlaceHolder1_WP]").hide();
                            }

                            if (response.d.Tkt_Visible != undefined && response.d.Tkt_Visible == "true") {
                                $("[id*=ContentPlaceHolder1_Tkt]").show();
                            }
                            else {
                                $("[id*=ContentPlaceHolder1_Tkt]").hide();
                            }


                        }
                        $("[id*=load]").hide();
                    },
                    error: function (xhr, status, error) {
                        $("[id*=load]").hide()
                    }
                });

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



    <div class="m-content">
        <div class="m-subheader " style="padding: 0px 30px 15px 30px;">

            <div class="m-form-group row m--align-center">
                <div class="mr-auto">
                    <h3 class="m-subheader__title">Dashboard</h3>
                </div>
                <div class="col-xl-6 m--align-center" style="padding-bottom: 15px;">
                    <asp:Button ID="btn_Employee_Dashboard" runat="server" Text="Your Account Dashboard" class="m-btn btn btn-success m-btn--pill" OnClick="btn_Employee_Dashboard_Click" />
                    <asp:Button ID="btn_Admin_Dashboard" runat="server" Text="Switch to Admin Dashboard" class="m-btn btn btn-secondary m-btn--pill" OnClick="btn_Admin_Dashboard_Click" />

                </div>
                <div class="col-xl-3 m--align-center" style="padding-bottom: 15px;">
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
                </div>
            </div>

        </div>

        <div class="m-porlet">

            <div class="row" style="width: fit-content;">

                <div id="Tkt" runat="server" class="col-xl-6">

                    <!--begin:: Ticketing Section-->
                    <div class="m-portlet m-portlet--bordered-semi m-portlet--full-height  m-portlet--rounded-force">

                        <div class="m-portlet__body">
                            <div class="m-widget19">
                                <div class="m-widget19__content ">
                                    <div class="m-widget19__header">

                                        <div class="m-widget19__user-img">
                                            <img class="m-widget19__img" style="width: 6rem;" src="<%= Page.ResolveClientUrl("~/assets/app/media/img/Dashboard_Icons/pending.png") %>" alt="" />
                                        </div>
                                        <div class="m-widget19__info" style="padding-right: 1rem;">
                                            <span class="m-widget19__username m--font-danger" style="font-size: 2rem; margin-bottom: 2.4rem; line-height: initial;">Pending Closure
                                            </span>
                                            <br />
                                            <span class="m-widget1__title" style="line-height: initial;">Total No. of Tickets accepted by You which requires closure
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

                                <div class="m-widget1">
                                    <div class="m-widget1__item">
                                        <div class="row m-row--no-padding align-items-center">
                                            <div class="col-xl-7">
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
                                                <asp:Label ID="lbl_Tkt_Open_Assigned" runat="server" class="m-widget1__number m--font-info">0</asp:Label>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="m-widget1__item">
                                        <div class="row m-row--no-padding align-items-center">
                                            <div class="col-xl-7">
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
                                                <asp:Label ID="lbl_tkt_Open_Accepted" runat="server" class="m-widget1__number m--font-success">0</asp:Label>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="m-widget1__item">
                                        <div class="row m-row--no-padding align-items-center">
                                            <div class="col-xl-7">
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
                                                <asp:Label ID="lbl_Tkt_Parked_Hold" runat="server" class="m-widget1__number m--font-warning">0</asp:Label>

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
                                        <asp:Label ID="lbl_Tkt_Open_User" runat="server" class="m-widget1__number m--font-danger">0</asp:Label>

                                        </div>

                                        <div class="m-stack__item m-stack__item--center">
                                            <div class="m-stack__demo-item">
                                                <span class="m-badge m-badge--success m-badge--wide">Closed</span>
                                            </div>
                                            </br>
                                        <asp:Label ID="lbl_tkt_Closed_User" runat="server" class="m-widget1__number m--font-success">0</asp:Label>

                                        </div>

                                        <div class="m-stack__item m-stack__item--center">
                                            <div class="m-stack__demo-item">
                                                <span class="m-badge m-badge--secondary m-badge--wide">Expired</span>
                                            </div>
                                            </br>
                                        <asp:Label ID="lbl_Tkt_Expired_User" runat="server" class="m-widget1__number m--font-secondary">0</asp:Label>

                                        </div>

                                    </div>


                                </div>


                            </div>
                        </div>
                    </div>

                    <!--end:: Ticketing Section-->
                </div>

                <div id="Chk" runat="server" class="col-xl-6">

                    <!--begin:: Ticketing Section-->
                    <div class="m-portlet m-portlet--bordered-semi m-portlet--full-height  m-portlet--rounded-force">


                        <div class="m-portlet__body">
                            <div class="m-widget19">

                                <div class="m-widget19__content ">
                                    <div class="m-widget19__header">
                                        <div class="m-widget19__user-img">
                                            <img class="m-widget19__img" style="width: 6rem;" src="<%= Page.ResolveClientUrl("~/assets/app/media/img/Dashboard_Icons/pending.png") %>" alt="" />
                                        </div>
                                        <div class="m-widget19__info" style="padding-right: 1rem;">
                                            <span class="m-widget19__username m--font-danger" style="font-size: 2rem; margin-bottom: 2.4rem; line-height: initial;">Incomplete Checklists
                                            </span>
                                            <br />
                                            <span class="m-widget1__title" style="line-height: initial;">Total No. of Checklists pending for closure
                                            </span>
                                        </div>
                                        <div class="m-widget19__stats" style="line-height: 1;">
                                            <asp:Label ID="lbl_Chk_Open_User" runat="server" class="m-widget19__number m--font-danger" Style="font-size: 2.5rem;">
                                            0
                                            </asp:Label>
                                            <span class="m-widget19__comment">Checklists
                                            </span>
                                        </div>

                                    </div>
                                </div>



                                <div class="m-widget1">
                                    <div class="m-widget1__item">
                                        <div class="row m-row--no-padding align-items-center">
                                            <div class="col-xl-9">
                                                <h3 class="m-widget1__title">Total Checklists
                                                </h3>

                                                <span class="m-widget1__desc">Total No. of Checklists generated by You.</span>

                                            </div>
                                            <div class="col m--align-right">
                                                <asp:Label ID="lbl_Chk_Total" runat="server" class="m-widget1__number m--font-secondary">0</asp:Label>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="m-widget1__item">
                                        <div class="row m-row--no-padding align-items-center">
                                            <div class="col-xl-7">
                                                <h3 class="m-widget1__title">Checklists
                                                
                                            <span class="m-badge m-badge--success m-badge--wide">Closed</span>
                                                </h3>
                                                <span class="m-widget1__desc">No. of Checklists closed by You</span>
                                            </div>
                                            <div class="col m--align-right">
                                                <asp:Label ID="lbl_Chk_Closed_User" runat="server" class="m-widget1__number m--font-success">0</asp:Label>

                                            </div>
                                        </div>
                                    </div>


                                </div>


                            </div>
                        </div>
                    </div>

                    <!--end:: Ticketing Section-->
                </div>

                <div id="WP" runat="server" class="col-xl-6">

                    <!--begin:: Ticketing Section-->
                    <div class="m-portlet m-portlet--bordered-semi m-portlet--full-height  m-portlet--rounded-force">

                        <div class="m-portlet__body">
                            <div class="m-widget19">
                                <div class="m-widget19__content ">
                                    <div class="m-widget19__header">
                                        <div class="m-widget19__user-img">
                                            <img class="m-widget19__img" style="width: 6rem;" src="<%= Page.ResolveClientUrl("~/assets/app/media/img/Dashboard_Icons/pending.png") %>" alt="">
                                        </div>
                                        <div class="m-widget19__info" style="padding-right: 1rem;">
                                            <span class="m-widget19__username m--font-danger" style="font-size: 2rem; margin-bottom: 2.4rem; line-height: initial;">Pending Approvals
                                            </span>
                                            <br>
                                            <span class="m-widget1__title" style="line-height: initial;">Total No. of Work Permits pending for your approval
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

                <div id="GP" runat="server" class="col-xl-6">

                    <!--begin:: Ticketing Section-->
                    <div class="m-portlet m-portlet--bordered-semi m-portlet--full-height  m-portlet--rounded-force">

                        <div class="m-portlet__body">
                            <div class="m-widget19">
                                <div class="m-widget19__content ">
                                    <div class="m-widget19__header">
                                        <div class="m-widget19__user-img">
                                            <img class="m-widget19__img" style="width: 6rem;" src="<%= Page.ResolveClientUrl("~/assets/app/media/img/Dashboard_Icons/pending.png") %>" alt="">
                                        </div>
                                        <div class="m-widget19__info" style="padding-right: 1rem;">
                                            <span class="m-widget19__username m--font-danger" style="font-size: 2rem; margin-bottom: 2.4rem; line-height: initial;">Pending Approvals
                                            </span>
                                            <br>
                                            <span class="m-widget1__title" style="line-height: initial;">Total No. of Gatepass pending for your approval
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

                <div id="VMS" runat="server" class="col-xl-6">

                    <!--begin:: Ticketing Section-->
                    <div class="m-portlet m-portlet--bordered-semi m-portlet--full-height  m-portlet--rounded-force">

                        <div class="m-portlet__body">
                            <div class="m-widget19">
                                <div class="m-widget19__content ">
                                    <div class="m-widget19__header">
                                        <div class="m-widget19__user-img">
                                            <img class="m-widget19__img" style="width: 6rem;" src="<%= Page.ResolveClientUrl("~/assets/app/media/img/Dashboard_Icons/pending.png") %>" alt="">
                                        </div>
                                        <div class="m-widget19__info" style="padding-right: 1rem;">
                                            <span class="m-widget19__username m--font-danger" style="font-size: 2rem; margin-bottom: 2.4rem; line-height: initial;">Pending Approvals
                                            </span>
                                            <br>
                                            <span class="m-widget1__title" style="line-height: initial;">Total No. of Visit Requests pending for your approval
                                            </span>
                                        </div>
                                        <div class="m-widget19__stats" style="line-height: 1;">
                                            <asp:Label ID="lbl_VMS_Pending" runat="server" class="m-widget19__number m--font-danger" Style="font-size: 2.5rem;">
                                            0
                                            </asp:Label>
                                            <span class="m-widget19__comment">Visit Requests
                                            </span>
                                        </div>

                                    </div>
                                </div>

                                <div class="m-stack m-stack--ver m-stack--general m-stack--demo" style="height: 45px;">
                                    <div class="m-stack__item m-stack__item--center">
                                        <div class="m-stack__demo-item">

                                            <span class="m-widget19__username m--font-primary" style="font-size: 1rem; margin-bottom: 2.4rem;">Summary of Visit Requests recieved
                                            </span>

                                        </div>
                                    </div>
                                </div>


                                <div class="m-widget1">
                                    <div class="m-widget1__item">
                                        <div class="row m-row--no-padding align-items-center">
                                            <div class="col-xl-9">
                                                <h3 class="m-widget1__title">Vist Requests
                                                <span class="m-badge m-badge--primary m-badge--wide">Recieved</span>
                                                </h3>
                                                <span class="m-widget1__desc">Total Visit requests recieved through QR Code / Form Links</span>
                                            </div>
                                            <div class="col m--align-right">
                                                <asp:Label ID="lbl_VMS_Recieved" runat="server" class="m-widget1__number m--font-primary">
                                                0
                                                </asp:Label>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="m-widget1__item">
                                        <div class="row m-row--no-padding align-items-center">
                                            <div class="col-xl-9">
                                                <h3 class="m-widget1__title">Vistors Marked
                                                
                                            <span class="m-badge m-badge--success m-badge--wide">IN</span>
                                                </h3>
                                                <span class="m-widget1__desc">Total No. of Visitors Marked IN</span>
                                            </div>
                                            <div class="col m--align-right">
                                                <asp:Label ID="lbl_VMS_IN" runat="server" class="m-widget1__number m--font-success">
                                                0
                                                </asp:Label>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="m-widget1__item">
                                        <div class="row m-row--no-padding align-items-center">
                                            <div class="col-xl-9">
                                                <h3 class="m-widget1__title">Visitors Marked
                                                
                                            <span class="m-badge m-badge--warning m-badge--wide">OUT</span>
                                                </h3>
                                                <span class="m-widget1__desc">Total No. of Visitors Marked OUT</span>
                                            </div>
                                            <div class="col m--align-right">
                                                <asp:Label ID="lbl_VMS_OUT" runat="server" class="m-widget1__number m--font-warning">
                                                0
                                                </asp:Label>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="m-widget1__item">
                                        <div class="row m-row--no-padding align-items-center">
                                            <div class="col-xl-9">
                                                <h3 class="m-widget1__title">Visit Requests
                                                
                                            <span class="m-badge m-badge--danger m-badge--wide">Rejected</span>
                                                </h3>
                                                <span class="m-widget1__desc">Total No. of Visit requests Rejected</span>
                                            </div>
                                            <div class="col m--align-right">
                                                <asp:Label ID="lbl_VMS_Rejected" runat="server" class="m-widget1__number m--font-danger">
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


</asp:Content>
