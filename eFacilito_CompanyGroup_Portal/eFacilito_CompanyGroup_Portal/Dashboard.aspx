<%@ Page Title="" Language="C#" MasterPageFile="~/eFacilito_MasterPage.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="eFacilito_CompanyGroup_Portal.Dashboard" %>
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

        <div class="m-subheader " style="padding: 0px 5px 0 5px;">
            <div class="d-flex align-items-center">

                                
					    <div class="dropdown bootstrap-select">
                            
                            <asp:DropDownList ID="ddl_CompanyList" class="form-control m-bootstrap-select m_selectpicker" name="param" tabindex="-98"
                               OnSelectedIndexChanged="ddl_CompanyList_SelectedIndexChanged" AutoPostBack="true" runat="server">

                            </asp:DropDownList>
                        </div>

                        <div class="input-group-append">
						    <button class="btn btn-success" type="button" runat="server" onserverclick="btn_LoadDashboard_Click">Go!</button>
						</div>

                <div class="mr-auto">
                    
                    <h3 class="m-subheader__title " style="padding: 8px 230px 8px 230px;">Admin Dashboard</h3>

                    <span class="m-subheader__daterange" id="m_dashboard_daterangepicker">
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

                    
                    <%--<asp:Button ID="btnDashboard" runat="server" OnClick="btnDashboard_Click" Text="Search" ClientIDMode="Static" CssClass="btn btn-sm btn-brand" />
                    --%>
                </div>




            </div>
        </div>

    </div>




    <div class="m-porlet">
        <div class="row">

            <div class="col-xl-6" id="div_Ticketing" runat="server">

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
                                    <div class="m-widget19__stats" style="line-height: 1;">
                                        <asp:Label ID="lbl_Tkt_Total" runat="server" class="m-widget19__number m--font-brand" style="font-size: 2.5rem;">18</asp:Label>

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
                                        <asp:Label ID="lbl_Tkt_open" runat="server" class="m-widget4__number m--font-danger">500</asp:Label>

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
                                            <asp:Label ID="lbl_Tkt_Closed" runat="server" class="m-widget4__number m--font-success">64</asp:Label>

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
                                            <asp:Label ID="lbl_Tkt_Parked" runat="server" class="m-widget4__number m--font-warning">1800</asp:Label>

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
                                            <asp:Label ID="lbl_Tkt_Expired" runat="server" class="m-widget4__number m--font-secondary">19</asp:Label>

                                        </span>
                                    </div>
                                </div>
                            </div>

                            <div class="m-widget19__action">
                                <a href="<%= Page.ResolveClientUrl("~/Analytics/Ticketing.aspx") %>"" class="btn m-btn--pill btn-secondary m-btn m-btn--hover-brand m-btn--custom ">
                                    <i class="flaticon-diagram"></i>
                                    Analyze Tickets Data
                                </a>
                            </div>
                        </div>
                    </div>
                </div>

                <!--end:: Ticketing Section-->
            </div>

            <div class="col-xl-6" id="div_Checklist" runat="server">

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
                                    <div class="m-widget19__stats" style="line-height: 1;">
                                        <asp:label id="lbl_Chk_Total_Attended" runat="server" class="m-widget19__number m--font-brand" style="font-size: 2.5rem;">1800</asp:label>
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
                                        <asp:label id="lbl_chk_Open" runat="server" class="m-widget4__number m--font-danger">501</asp:label>
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
                                            <asp:label id="lbl_chk_Closed" runat="server" class="m-widget4__number m--font-success">501</asp:label>
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

            <div class="col-xl-6" id="div_Gatepass" runat="server">

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
                                        <asp:Label ID="lbl_GP_Total" runat="server" class="m-widget19__number m--font-brand" style="font-size: 2.5rem;">18</asp:Label>

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
                                        <span class="m-widget4__text">No. of Gatepass with Status
                                            <span class="m-badge m-badge--danger m-badge--wide">Open</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <asp:label id="lbl_GP_Open" runat="server" class="m-widget4__number m--font-danger">501</asp:label>
                                    </div>
                                </div>

                                <div class="m-widget4__item">
                                    <div class="m-widget4__ext">
                                        <a href="#" class="m-widget4__icon m--font-brand">
                                            <i class="flaticon-interface-3"></i>
                                        </a>
                                    </div>
                                    <div class="m-widget4__info">
                                        <span class="m-widget4__text">No. of Gatepass with Status
                                            <span class="m-badge m-badge--warning m-badge--wide">In Progress</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <asp:label id="lbl_GP_InProgress" runat="server" class="m-widget4__number m--font-warning">501</asp:label>
                                    </div>
                                </div>

                                <div class="m-widget4__item">
                                    <div class="m-widget4__ext">
                                        <a href="#" class="m-widget4__icon m--font-brand">
                                            <i class="flaticon-interface-3"></i>
                                        </a>
                                    </div>
                                    <div class="m-widget4__info">
                                        <span class="m-widget4__text">No. of Gatepass with Status
                                            <span class="m-badge  m-badge--info m-badge--wide">Approved</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__stats m--font-info">
                                            <asp:label id="lbl_GP_Approved" runat="server" class="m-widget4__number m--font-info">501</asp:label>
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
                                        <span class="m-widget4__text">No. of Gatepass with Status
                                            <span class="m-badge  m-badge--success m-badge--wide">Closed</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__stats m--font-info">
                                            <asp:label id="lbl_GP_Closed" runat="server" class="m-widget4__number m--font-success">501</asp:label>
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
                                        <span class="m-widget4__text">No. of Gatepass with Status
                                            <span class="m-badge m-badge--warning m-badge--wide">Hold</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__stats m--font-info">
                                            <asp:label id="lbl_GP_Hold" runat="server" class="m-widget4__number m--font-info">501</asp:label>
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
                                        <span class="m-widget4__text">No. of Gatepass with Status
                                            <span class="m-badge m-badge--danger m-badge--wide">Rejected</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__stats m--font-info">
                                            <asp:label id="lbl_GP_Rejected" runat="server" class="m-widget4__number m--font-danger">501</asp:label>
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
                                        <span class="m-widget4__text">No. of Gatepass with Status
                                            <span class="m-badge m-badge--secondary m-badge--wide">Expired</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__stats m--font-info">
                                            <asp:label id="lbl_GP_Expired" runat="server" class="m-widget4__number m--font-secondary">501</asp:label>
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


            <div class="col-xl-6" id="div_Workpermit" runat="server">

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
                                        <span class="m-widget19__username">Total Work Permits
                                        </span>
                                        <br>
                                        <span class="m-widget19__time">Total No. of Work Permits raised
                                        </span>
                                    </div>
                                    <div class="m-widget19__stats" style="line-height: 1;">
                                        <asp:Label id="lbl_WP_Total" class="m-widget19__number m--font-brand" runat="server" style="font-size: 2.5rem;">0</asp:Label>
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
                                        <span class="m-widget4__text">No. of Permits with Status
                                            <span class="m-badge m-badge--danger m-badge--wide">Open</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <asp:label id="lbl_WP_Open" runat="server" class="m-widget4__number m--font-danger">501</asp:label>
                                    </div>
                                </div>

                                <div class="m-widget4__item">
                                    <div class="m-widget4__ext">
                                        <a href="#" class="m-widget4__icon m--font-brand">
                                            <i class="flaticon-interface-3"></i>
                                        </a>
                                    </div>
                                    <div class="m-widget4__info">
                                        <span class="m-widget4__text">No. of Permits with Status
                                            <span class="m-badge m-badge--warning m-badge--wide">In Progress</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <asp:label id="lbl_WP_InProgress" runat="server" class="m-widget4__number m--font-warning">501</asp:label>
                                    </div>
                                </div>

                                <div class="m-widget4__item">
                                    <div class="m-widget4__ext">
                                        <a href="#" class="m-widget4__icon m--font-brand">
                                            <i class="flaticon-interface-3"></i>
                                        </a>
                                    </div>
                                    <div class="m-widget4__info">
                                        <span class="m-widget4__text">No. of Permits with Status
                                            <span class="m-badge  m-badge--info m-badge--wide">Approved</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__stats m--font-info">
                                            <asp:label id="lbl_WP_Approved" runat="server" class="m-widget4__number m--font-info">501</asp:label>
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
                                        <span class="m-widget4__text">No. of Permits with Status
                                            <span class="m-badge  m-badge--success m-badge--wide">Closed</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__stats m--font-info">
                                            <asp:label id="lbl_WP_Closed" runat="server" class="m-widget4__number m--font-success">501</asp:label>
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
                                        <span class="m-widget4__text">No. of Permits with Status
                                            <span class="m-badge m-badge--warning m-badge--wide">Hold</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__stats m--font-info">
                                            <asp:label id="lbl_WP_Hold" runat="server" class="m-widget4__number m--font-info">501</asp:label>
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
                                        <span class="m-widget4__text">No. of Permits with Status
                                            <span class="m-badge m-badge--danger m-badge--wide">Rejected</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__stats m--font-info">
                                            <asp:label id="lbl_WP_Rejected" runat="server" class="m-widget4__number m--font-danger">501</asp:label>
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
                                        <span class="m-widget4__text">No. of Permits with Status
                                            <span class="m-badge m-badge--secondary m-badge--wide">Expired</span>
                                        </span>
                                    </div>
                                    <div class="m-widget4__ext">
                                        <span class="m-widget4__stats m--font-info">
                                            <asp:label id="lbl_WP_Expired" runat="server" class="m-widget4__number m--font-secondary">501</asp:label>
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
            <div class="col-xl-12" id="div_Feedback" runat="server">
                <div class="m-portlet">
                    
                    <div class="m-portlet__body">
                        <!--begin::Section-->

                        <div class="m-widget19">
                        <div class="m-widget19__content">
                            <div class="m-widget19__header" style="margin-top: 0rem; margin-bottom: 1rem;">
                                <div class="m-widget19__user-img">
                                    <img class="m-widget19__img" style="width: 6rem;" src="../../assets/app/media/img/Dashboard_Icons/wp.png" alt="">
                                </div>
                                <div class="m-widget19__info">
                                    <span class="m-widget19__username">Total Feedbacks
                                    </span>
                                    <br>
                                    <span class="m-widget19__time">Total No. of Feedbacks Collected through different Events
                                    </span>
                                </div>
                                <div class="m-widget19__stats" style="line-height: 1;">
                                    <asp:Label id="lbl_Feedback_Total" class="m-widget19__number m--font-brand" runat="server" style="font-size: 2.5rem;">18</asp:Label>
                                    <span class="m-widget19__comment">Feedbacks
                                    </span>
                                </div>

                            </div>

                            <div class="m-widget19__body">
                                Get in-depth insights & Analysis your Feedbacks data. 
                            </div>
                        </div>
                    </div>



                        <div class="m-section">
                            <div class="m-section__content">
                                <table class="table m-table">
                                    <thead>
                                        <tr>
                                            <th>Event Name</th>
                                            <th>
                                                <span class="btn btn-focus">Collected Feedbacks</span>
                                            </th>
                                            <th>
                                                <span class="btn btn-success">Positive Feedbacks</span>
                                            </th>
                                            <th>
                                                <span class="btn btn-danger">Negative Feedbacks</span>
                                            </th>
                                            <th>
                                                <span class="btn btn-warning">Neutral Feedbacks</span>
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <th>Mall Experience Feedback</th>
                                            <td style="font-weight: 450;">34
                                                <div class="progress">
                                                    <div class="progress-bar bg-focus" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                                </div>
                                            </td>
                                            <td style="font-weight: 450;">31 (41%)
                                                <div class="progress">
                                                    <div class="progress-bar bg-success" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                                </div>
                                            </td >
                                            <td style="font-weight: 450;">34 (30%)
                                                <div class="progress">
                                                    <div class="progress-bar bg-danger" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100"></div>
                                                </div>
                                            </td>
                                            <td style="font-weight: 450;">34 (30%)
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
