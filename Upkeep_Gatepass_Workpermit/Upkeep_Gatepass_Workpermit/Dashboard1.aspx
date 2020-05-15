<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard1.aspx.cs" Inherits="Upkeep_Gatepass_Workpermit.Dashboard1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>

    <!--begin::Page Vendors -->
		<%--<script src="<%= Page.ResolveClientUrl("~/assets/vendors/custom/fullcalendar/fullcalendar.bundle.js") %>" type="text/javascript"></script>--%>
		<script src="http://www.amcharts.com/lib/3/amcharts.js" type="text/javascript"></script>
		<!-- <script src="http://www.amcharts.com/lib/3/serial.js" type="text/javascript"></script>
		<script src="http://www.amcharts.com/lib/3/radar.js" type="text/javascript"></script> -->
		<script src="http://www.amcharts.com/lib/3/pie.js" type="text/javascript"></script>
		<!-- <script src="http://www.amcharts.com/lib/3/plugins/tools/polarScatter/polarScatter.min.js" type="text/javascript"></script>
		<script src="http://www.amcharts.com/lib/3/plugins/animate/animate.min.js" type="text/javascript"></script> -->
		<script src="http://www.amcharts.com/lib/3/plugins/export/export.min.js" type="text/javascript"></script>
		<script src="http://www.amcharts.com/lib/3/themes/light.js" type="text/javascript"></script>

		<!--end::Page Vendors -->

		<!--begin::Page Scripts -->
		<!-- <script src="assets/app/js/dashboard.js" type="text/javascript"></script> -->

		<!--end::Page Scripts -->

		<!-- begin::Custom Scripts -->
		<script type="text/javascript">

		    var api_url = 'http://101.53.152.242/feedo_UAT_Service/FeedbackSystemMobService.asmx/';
		    //var api_url = 'http://localhost:5176/FeedbackSystemMobService.asmx/';

		    var chart = {
		        update_all: function () {
		            this.update_customer();
		            this.update_retailer();
		        },
		        update_customer: function () {
		            var event_id = $('#customer_events').val();
		            var start_date = $('#start_date').val();
		            var end_date = $('#end_date').val();

                    start_date = "01/01/2020";

		            _chart = this;
		            var chart_id = '#chart_customer_feedback';

		            $.ajax({
		                type: 'POST',
		                url: api_url + 'Get_ChartData',
		                data: { 'EventID': event_id, 'fromDate': start_date, 'toDate': end_date },
		                dataType: 'json',
		                beforeSend: function () {
		                    _chart.show_loader(chart_id);
		                },
		                success: function (data) {
		                    _chart.render(chart_id, data);
		                    _chart.show_legends(chart_id, data);
		                    _chart.hide_loader(chart_id);
		                },
		                error: function (data) {
		                    _chart.show_error(chart_id, data.status);
		                }
		            });
		        },
		        update_retailer: function () {
		            this.show_loader('#chart_retailer_feedback');

		            var event_id = $('#retailer_events').val();
		            var start_date = $('#start_date').val();
                    var end_date = $('#end_date').val();
                    //alert(start_date);

                    start_date = "01/01/2020";
		            _chart = this;
		            var chart_id = '#chart_retailer_feedback';

		            $.ajax({
		                type: 'POST',
		                url: api_url + 'Get_ChartData',
		                data: { 'EventID': event_id, 'fromDate': start_date, 'toDate': end_date },
		                dataType: 'json',
		                beforeSend: function () {
		                    _chart.show_loader(chart_id);
		                },
		                success: function (data) {
		                    _chart.render(chart_id, data);
		                    _chart.show_legends(chart_id, data);
		                    _chart.hide_loader(chart_id);
		                },
		                error: function (data) {
		                    _chart.show_error(chart_id, data.status);
		                }
		            });
		        },
		        show_loader: function (chart_id) {
		            $(chart_id).find('svg').remove();
		            $(chart_id).find('.m-widget14__stat').html('Loading...');
		        },
		        hide_loader: function (chart_id) {
		            setTimeout(function () {
		                $(chart_id).find('.m-widget14__stat').html('');
		            }, 3000);
		        },
		        show_error: function (chart_id, status_code) {
		            $(chart_id).find('svg').remove();
		            $(chart_id).find('.m-widget14__stat').html('Error ' + status_code);
		            $(chart_id).closest('.row').find('.m-widget14__legends .m-widget14__legend-text').html('Error occurred while loading data..');
		        },
		        render: function (chart_id, data) {
		            var positive = data[0].Positive;
		            var neutral = data[0].Neutral;
		            var negative = data[0].Negative;

		            $(function () {
		                var chart = new Chartist.Pie(chart_id, {
		                    series: [{
		                        value: positive,
		                        className: 'custom',
		                        meta: {
		                            color: mApp.getColor('success')
		                        }
		                    },
								{
								    value: neutral,
								    className: 'custom',
								    meta: {
								        color: mApp.getColor('warning')
								    }
								},
								{
								    value: negative,
								    className: 'custom',
								    meta: {
								        color: mApp.getColor('danger')
								    }
								}
		                    ],
		                },
						{
						    donut: true,
						    showLabel: false
						});

		                chart.on('draw', function (data) {
		                    if (data.type === 'slice') {
		                        // Get the total path length in order to use for dash array animation
		                        var pathLength = data.element._node.getTotalLength();

		                        // Set a dasharray that matches the path length as prerequisite to animate dashoffset
		                        data.element.attr({
		                            'stroke-dasharray': pathLength + 'px ' + pathLength + 'px'
		                        });

		                        // Create animation definition while also assigning an ID to the animation for later sync usage
		                        var animationDefinition = {
		                            'stroke-dashoffset': {
		                                id: 'anim' + data.index,
		                                dur: 1000,
		                                from: -pathLength + 'px',
		                                to: '0px',
		                                easing: Chartist.Svg.Easing.easeOutQuint,
		                                // We need to use `fill: 'freeze'` otherwise our animation will fall back to initial (not visible)
		                                fill: 'freeze',
		                                'stroke': data.meta.color
		                            }
		                        };

		                        // If this was not the first slice, we need to time the animation so that it uses the end sync event of the previous animation
		                        if (data.index !== 0) {
		                            animationDefinition['stroke-dashoffset'].begin = 'anim' + (data.index - 1) + '.end';
		                        }

		                        // We need to set an initial value before the animation starts as we are not in guided mode which would do that for us

		                        data.element.attr({
		                            'stroke-dashoffset': -pathLength + 'px',
		                            'stroke': data.meta.color
		                        });

		                        // We can't use guided mode as the animations need to rely on setting begin manually
		                        // See http://gionkunz.github.io/chartist-js/api-documentation.html#chartistsvg-function-animate
		                        data.element.animate(animationDefinition, false);
		                    }
		                });

		                return;

		            });
		        },
		        show_legends: function (id, data) {
		            var positive = data[0].Positive;
		            var neutral = data[0].Neutral;
		            var negative = data[0].Negative;

		            var parent_row = $(id).closest('.row');
		            parent_row.find('.m-widget14__legends .m-widget14__legend-text:eq(0)').html(positive + '% Positive');
		            parent_row.find('.m-widget14__legends .m-widget14__legend-text:eq(1)').html(neutral + '% Neutral');
		            parent_row.find('.m-widget14__legends .m-widget14__legend-text:eq(2)').html(negative + '% Negative');
		        }
		    }

		    $(function () {
		        $('.m_selectpicker').selectpicker();

		        $('.m_selectpicker').change(function () {
		            var id = $(this).attr('id');
		            if (id == 'retailer_events') {
		                chart.update_retailer();
		            }
		            if (id == 'customer_events') {
		                chart.update_customer();
		            }
		        });

		        var dropdowns = [
					{ 'id': 'retailer_events', 'type': 'R' },
					{ 'id': 'customer_events', 'type': 'C' }
		        ];

		        $.each(dropdowns, function (index, value) {
		            var dropdown = $('#' + value.id);
                    var type = value.type;
                    //debugger;
		            /* ajax function to load dropdowns */
		            $.ajax({
		                type: 'POST',
		                url: api_url + 'GetEventList',
		                data: { 'eventType': type },
		                dataType: 'json',
		                beforeSend: function () {
		                    dropdown.selectpicker({ title: 'Loading...' }).selectpicker('render');
		                    dropdown.html('').attr('disabled', true).selectpicker('refresh');
		                },
		                success: function (data) {
		                    var options = '';
		                    $.each(data, function (index, value) {
		                        options += '<option value="' + value.Event_ID + '">' + value.Event_Name + '</option>';
		                    });

		                    dropdown.selectpicker({ title: 'Select Event' }).selectpicker('render');
		                    dropdown.html(options).attr('disabled', false).selectpicker('refresh');
		                },
		                error: function (data) {
		                    dropdown.html('<option>No data found</option>').attr('disabled', true).selectpicker('refresh');
		                }
		            });
		        });


		        var picker = $('#m_dashboard_daterangepicker');
		        var start = moment();
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
                    chart.update_all();
                    //alert(start);
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

		        cb(start, end, '');
		    });

		</script>
		<!-- end::Custom Scripts -->
    
    
    
    
    <%--<div class="m-page--fluid m--skin- m-content--skin-light2 m-header--fixed m-header--fixed-mobile m-aside-left--enabled m-aside-left--skin-dark m-aside-left--fixed m-aside-left--offcanvas m-footer--push m-aside--offcanvas-default">

    <div class="m-grid m-grid--hor m-grid--root m-page">
    <div class="m-grid__item m-grid__item--fluid m-grid m-grid--ver-desktop m-grid--desktop m-body">--%>
        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <form class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmGatePass" method="post">
					<!-- BEGIN: Subheader -->
					<div class="m-subheader ">
						<div class="d-flex align-items-center">
							<div class="mr-auto">
								<h3 class="m-subheader__title ">Feedback</h3>
							</div>
							<div>
								<span class="m-subheader__daterange" id="m_dashboard_daterangepicker">
									<span class="m-subheader__daterange-label">
										<span class="m-subheader__daterange-title"></span>
										<span class="m-subheader__daterange-date m--font-brand"></span>
                                        <asp:HiddenField ID="start_date" runat="server" ClientIDMode="Static" />
										<%--<input type="hidden" id="start_date" />--%>
										<input type="hidden" id="end_date"/>
									</span>
									<a href="#" class="btn btn-sm btn-brand m-btn m-btn--icon m-btn--icon-only m-btn--custom m-btn--pill">
										<i class="la la-angle-down"></i>
									</a>
								</span>
							</div>
						</div>
					</div>

					<!-- END: Subheader -->
					<div class="m-content" >						
						<div class="m-portlet">
							<div class="m-portlet__body  m-portlet__body--no-padding">
								<div class="row m-row--no-padding m-row--col-separator-xl">
									<div class="col-xl-4">

										<!--begin:: Widgets/Daily Sales-->
										<div class="m-widget14" >
											<div class="m-widget14__header">
												<h3 class="m-widget14__title">
													<span class="m--block-inline m--margin-top-10">Retailers</span>
													<div class="m-form__group m--pull-right">
														<select class="form-control m-bootstrap-select m_selectpicker" title="Select Event" data-live-search="true" data-size="3" data-style="btn btn-brand m-btn--pill" data-width="150px" id="retailer_events">
														</select>
													</div>
												</h3>
											</div>
											<div class="clearfix"></div>
											<div class="row  align-items-center">
												<div class="col-12">
													<div id="chart_retailer_feedback" class="m-widget14__chart" style="height: 300px">
														<div class="m-widget14__stat"></div>
													</div>
												</div>
												<div class="col-12 m--margin-top-30">
													<div class="m-widget14__legends">
														<div class="m-widget14__legend">
															<span class="m-widget14__legend-bullet m--bg-success"></span>
															<span class="m-widget14__legend-text">Loading...</span>
														</div>
														<div class="m-widget14__legend">
															<span class="m-widget14__legend-bullet m--bg-warning"></span>
															<span class="m-widget14__legend-text">Loading...</span>
														</div>
														<div class="m-widget14__legend">
															<span class="m-widget14__legend-bullet m--bg-danger"></span>
															<span class="m-widget14__legend-text">Loading...</span>
														</div>
													</div>
												</div>
											</div>
										</div>

										<!--end:: Widgets/Daily Sales-->
									</div>
									<div class="col-xl-4">

										<!--begin:: Widgets/Profit Share-->
										<div class="m-widget14" >
											<div class="m-widget14__header" >
												<h3 class="m-widget14__title">
													<span class="m--block-inline m--margin-top-10">Customers</span>
													<div class="m-form__group m--pull-right">
														<select class="form-control m-bootstrap-select m_selectpicker" title="Select Event" data-live-search="true" data-size="3" data-style="btn btn-brand m-btn--pill" data-width="150px" id="customer_events">
														</select>
                                                        
													</div>
												</h3>
											</div>
											<div class="row align-items-center">
												<div class="col-12">
													<div id="chart_customer_feedback" class="m-widget14__chart" style="height: 300px">
														<div class="m-widget14__stat"></div>
													</div>
												</div>
												<div class="col-12 m--margin-top-30">
													<div class="m-widget14__legends">
														<div class="m-widget14__legend">
															<span class="m-widget14__legend-bullet m--bg-success"></span>
															<span class="m-widget14__legend-text">Loading...</span>
														</div>
														<div class="m-widget14__legend">
															<span class="m-widget14__legend-bullet m--bg-warning"></span>
															<span class="m-widget14__legend-text">Loading...</span>
														</div>
														<div class="m-widget14__legend">
															<span class="m-widget14__legend-bullet m--bg-danger"></span>
															<span class="m-widget14__legend-text">Loading...</span>
														</div>
													</div>
												</div>
											</div>
										</div>

										<!--end:: Widgets/Profit Share-->
									</div>
									<div class="col-xl-4">
										<div class="m-widget14" >
											<div class="m-widget14__header" >
												<h3 class="m-widget14__title m--margin-top-10">
													Upcoming Events
												</h3>
											</div>
											<div class="row align-items-center">
												<div class="col">
													<div class="">
														<div class="m-portlet__body">
															<div class="m-scrollable" data-scrollable="true" data-height="410" data-mobile-height="300">

																<!--Begin::Timeline 2 -->
																<div class="m-timeline-2">
																	<div class="m-timeline-2__items  m--padding-top-25 m--padding-bottom-30">
																		<div class="m-timeline-2__item">
																			<span class="m-timeline-2__item-time">10:00</span>
																			<div class="m-timeline-2__item-cricle">
																				<i class="fa fa-genderless m--font-danger"></i>
																			</div>
																			<div class="m-timeline-2__item-text  m--padding-top-5">
																				Lorem ipsum dolor sit amit,consectetur eiusmdd tempor<br>
																				incididunt ut labore et dolore magna
																			</div>
																		</div>
																		<div class="m-timeline-2__item m--margin-top-30">
																			<span class="m-timeline-2__item-time">12:45</span>
																			<div class="m-timeline-2__item-cricle">
																				<i class="fa fa-genderless m--font-success"></i>
																			</div>
																			<div class="m-timeline-2__item-text m-timeline-2__item-text--bold">
																				AEOL Meeting With
																			</div>
																			<div class="m-list-pics m-list-pics--sm m--padding-left-20">
																				<a href="#"><img src="assets/app/media/img/users/100_4.jpg" title=""></a>
																				<a href="#"><img src="assets/app/media/img/users/100_13.jpg" title=""></a>
																				<a href="#"><img src="assets/app/media/img/users/100_11.jpg" title=""></a>
																				<a href="#"><img src="assets/app/media/img/users/100_14.jpg" title=""></a>
																			</div>
																		</div>
																		<div class="m-timeline-2__item m--margin-top-30">
																			<span class="m-timeline-2__item-time">14:00</span>
																			<div class="m-timeline-2__item-cricle">
																				<i class="fa fa-genderless m--font-brand"></i>
																			</div>
																			<div class="m-timeline-2__item-text m--padding-top-5">
																				Make Deposit <a href="#" class="m-link m-link--brand m--font-bolder">USD 700</a> To ESL.
																			</div>
																		</div>
																		<div class="m-timeline-2__item m--margin-top-30">
																			<span class="m-timeline-2__item-time">16:00</span>
																			<div class="m-timeline-2__item-cricle">
																				<i class="fa fa-genderless m--font-warning"></i>
																			</div>
																			<div class="m-timeline-2__item-text m--padding-top-5">
																				Lorem ipsum dolor sit amit,consectetur eiusmdd tempor<br>
																				incididunt ut labore et dolore magna elit enim at minim<br>
																				veniam quis nostrud
																			</div>
																		</div>
																		<div class="m-timeline-2__item m--margin-top-30">
																			<span class="m-timeline-2__item-time">17:00</span>
																			<div class="m-timeline-2__item-cricle">
																				<i class="fa fa-genderless m--font-info"></i>
																			</div>
																			<div class="m-timeline-2__item-text m--padding-top-5">
																				Placed a new order in <a href="#" class="m-link m-link--brand m--font-bolder">SIGNATURE MOBILE</a> marketplace.
																			</div>
																		</div>
																		<div class="m-timeline-2__item m--margin-top-30">
																			<span class="m-timeline-2__item-time">16:00</span>
																			<div class="m-timeline-2__item-cricle">
																				<i class="fa fa-genderless m--font-brand"></i>
																			</div>
																			<div class="m-timeline-2__item-text m--padding-top-5">
																				Lorem ipsum dolor sit amit,consectetur eiusmdd tempor<br>
																				incididunt ut labore et dolore magna elit enim at minim<br>
																				veniam quis nostrud
																			</div>
																		</div>
																		<div class="m-timeline-2__item m--margin-top-30">
																			<span class="m-timeline-2__item-time">17:00</span>
																			<div class="m-timeline-2__item-cricle">
																				<i class="fa fa-genderless m--font-danger"></i>
																			</div>
																			<div class="m-timeline-2__item-text m--padding-top-5">
																				Received a new feedback on <a href="#" class="m-link m-link--brand m--font-bolder">FinancePro App</a> product.
																			</div>
																		</div>
																	</div>
																</div>

																<!--End::Timeline 2 -->
															</div>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>

                        <!--Begin::Section-->
						<div class="row">
							<div class="col-xl-4">

								<!--begin:: Widgets/Top Products-->
								<div class="m-portlet m-portlet--bordered-semi m-portlet--widget-fit m-portlet--full-height m-portlet--skin-light  m-portlet--rounded-force">
									<div class="m-portlet__head">
										<div class="m-portlet__head-caption">
											<div class="m-portlet__head-title">
												<h3 class="m-portlet__head-text m--font-light">
													Gatepass Summary
												</h3>
											</div>
										</div>
										<div class="m-portlet__head-tools">
											<ul class="m-portlet__nav">
												<li class="m-portlet__nav-item m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover">
													<a href="#" class="m-portlet__nav-link m-portlet__nav-link--icon m-portlet__nav-link--icon-xl">
														<i class="fa fa-genderless m--font-light"></i>
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
																		<li class="m-nav__separator m-nav__separator--fit">
																		</li>
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
									<div class="m-portlet__body" style="background-color: gainsboro;">
										<div class="m-widget17">
											<div class="m-widget17__visual m-widget17__visual--chart m-portlet-fit--top m-portlet-fit--sides m--bg-danger">
												<div class="m-widget17__chart" style="height:109px;">
													
												</div>
											</div>
											<div class="m-widget17__stats">
                                                <div class="m-widget17__items m-widget17__items-col1">
                                                    <div class="m-widget17__item">
                                                        <span class="m-widget17__icon">
                                                            <i class="flaticon-truck m--font-brand"></i>
                                                        </span>
                                                        <span class="m-widget17__subtitle">
                                                            Total
                                                        </span>
                                                        <span class="m-widget17__desc">
                                                            15 Requests raised
                                                        </span>
                                                    </div>
                                                    <div class="m-widget17__item">
                                                        <span class="m-widget17__icon">
                                                            <i class="flaticon-paper-plane m--font-info"></i>
                                                        </span>
                                                        <span class="m-widget17__subtitle">
                                                            On Hold
                                                        </span>
                                                        <span class="m-widget17__desc">
                                                            72 Requests
                                                        </span>
                                                    </div>
                                                    <div class="m-widget17__item">
                                                        <span class="m-widget17__icon">
                                                            <i class="flaticon-paper-plane m--font-info"></i>
                                                        </span>
                                                        <span class="m-widget17__subtitle">
                                                            Approve
                                                        </span>
                                                        <span class="m-widget17__desc">
                                                            72 Requests
                                                        </span>
                                                    </div>
                                                </div>
                                                <div class="m-widget17__items m-widget17__items-col2">
                                                    <div class="m-widget17__item">
                                                        <span class="m-widget17__icon">
                                                            <i class="flaticon-pie-chart m--font-success"></i>
                                                        </span>
                                                        <span class="m-widget17__subtitle">
                                                            Open
                                                        </span>
                                                        <span class="m-widget17__desc">
                                                            72 Requests
                                                        </span>
                                                    </div>
                                                    <div class="m-widget17__item">
                                                        <span class="m-widget17__icon">
                                                            <i class="flaticon-time m--font-danger"></i>
                                                        </span>
                                                        <span class="m-widget17__subtitle">
                                                            Rejected
                                                        </span>
                                                        <span class="m-widget17__desc">
                                                            34 Requests
                                                        </span>
                                                    </div>
                                                    <div class="m-widget17__item">
                                                        <span class="m-widget17__icon">
                                                            <i class="flaticon-time m--font-danger"></i>
                                                        </span>
                                                        <span class="m-widget17__subtitle">
                                                            Closed
                                                        </span>
                                                        <span class="m-widget17__desc">
                                                            34 Requests
                                                        </span>
                                                    </div>
                                                </div>

											</div>
										</div>
									</div>
								</div>
								<!--end:: Widgets/Top Products-->
							</div>
							<div class="col-xl-4">

								<!--begin:: Widgets/Activity-->
								<div class="m-portlet m-portlet--bordered-semi m-portlet--widget-fit m-portlet--full-height m-portlet--skin-light  m-portlet--rounded-force">
									<div class="m-portlet__head">
										<div class="m-portlet__head-caption">
											<div class="m-portlet__head-title">
												<h3 class="m-portlet__head-text m--font-light">
													Work Permit Summary
												</h3>
											</div>
										</div>
										<div class="m-portlet__head-tools">
											<ul class="m-portlet__nav">
												<li class="m-portlet__nav-item m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover">
													<a href="#" class="m-portlet__nav-link m-portlet__nav-link--icon m-portlet__nav-link--icon-xl">
														<i class="fa fa-genderless m--font-light"></i>
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
																		<li class="m-nav__separator m-nav__separator--fit">
																		</li>
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
									<div class="m-portlet__body" style="background-color: gainsboro;">
										<div class="m-widget17">
											<div class="m-widget17__visual m-widget17__visual--chart m-portlet-fit--top m-portlet-fit--sides m--bg-danger">
												<div class="m-widget17__chart" style="height:109px;">
													
												</div>
											</div>
											<div class="m-widget17__stats">
                                                <div class="m-widget17__items m-widget17__items-col1">
                                                    <div class="m-widget17__item">
                                                        <span class="m-widget17__icon">
                                                            <i class="flaticon-truck m--font-brand"></i>
                                                        </span>
                                                        <span class="m-widget17__subtitle">
                                                            Total
                                                        </span>
                                                        <span class="m-widget17__desc">
                                                            15 Requests raised
                                                        </span>
                                                    </div>
                                                    <div class="m-widget17__item">
                                                        <span class="m-widget17__icon">
                                                            <i class="flaticon-paper-plane m--font-info"></i>
                                                        </span>
                                                        <span class="m-widget17__subtitle">
                                                            On Hold
                                                        </span>
                                                        <span class="m-widget17__desc">
                                                            72 Requests
                                                        </span>
                                                    </div>
                                                    <div class="m-widget17__item">
                                                        <span class="m-widget17__icon">
                                                            <i class="flaticon-paper-plane m--font-info"></i>
                                                        </span>
                                                        <span class="m-widget17__subtitle">
                                                            Approve
                                                        </span>
                                                        <span class="m-widget17__desc">
                                                            72 Requests
                                                        </span>
                                                    </div>
                                                </div>
                                                <div class="m-widget17__items m-widget17__items-col2">
                                                    <div class="m-widget17__item">
                                                        <span class="m-widget17__icon">
                                                            <i class="flaticon-pie-chart m--font-success"></i>
                                                        </span>
                                                        <span class="m-widget17__subtitle">
                                                            Open
                                                        </span>
                                                        <span class="m-widget17__desc">
                                                            72 Requests
                                                        </span>
                                                    </div>
                                                    <div class="m-widget17__item">
                                                        <span class="m-widget17__icon">
                                                            <i class="flaticon-time m--font-danger"></i>
                                                        </span>
                                                        <span class="m-widget17__subtitle">
                                                            Rejected
                                                        </span>
                                                        <span class="m-widget17__desc">
                                                            34 Requests
                                                        </span>
                                                    </div>
                                                    <div class="m-widget17__item">
                                                        <span class="m-widget17__icon">
                                                            <i class="flaticon-time m--font-danger"></i>
                                                        </span>
                                                        <span class="m-widget17__subtitle">
                                                            Closed
                                                        </span>
                                                        <span class="m-widget17__desc">
                                                            34 Requests
                                                        </span>
                                                    </div>
                                                </div>

											</div>
										</div>
									</div>
								</div>

								<!--end:: Widgets/Activity-->
							</div>
							<div class="col-xl-4">

								<!--begin:: Widgets/Blog-->
								
								<!--end:: Widgets/Blog-->
							</div>
						</div>


					</div>
				
                </form>
                </div>
       <%-- </div>
        </div>
        </div>--%>
</asp:Content>
