﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Service_Requests.aspx.cs" Inherits="Upkeep_v3.CSM.Service_Requests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>

	<script type="text/javascript">

		var DatatableHtmlTableDemo = {
			init: function () {
				var e; e = $(".m-datatable").mDatatable({
					data: { saveState: { cookie: !1 } },
					search: { input: $("#generalSearch") },
					columns: [

						//{ field: "DepositPaid", type: "number" },
						//{
						//    field: "OrderDate", type: "date", format: "YYYY-MM-DD"
						//},

						{
							field: "Status", title: "Status", template: function (e) {
								var t =
								{
									"Open": { title: "Open", class: "m-badge--warning" },
									"Close": { title: "Close", class: " m-badge--success" },
									"Approve": { title: "Approved", class: " m-badge--success" },
									"Apply": { title: "Apply", class: " m-badge--brand" },
									"Reject": { title: "Rejected", class: " m-badge--danger" },
									"Expired": { title: "Expired", class: "bg-secondary text-black" },
									"In Progress": { title: "In Progress", class: "text-white bg-info" }
								}; return '<span class="m-badge ' + t[e.Status].class + ' m-badge--wide">' + t[e.Status].title + "</span>"
							}
						}

						//    ,
						//{
						//    field: "Status",
						//    title: "Status",
						//    template: function (e) {
						//        var t = {
						//            "Pending": { title: "Pending", state: "danger" },
						//            "Done": { title: "Done", state: "success" }
						//            //"Parked": { title: "Parked", state: "text-secondary" },
						//            //"ApprovalSent": { title: "ApprovalSent", state: "accent" }
						//        }; return '<span class="m-badge m-badge--' + t[e.Status].state + ' m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-' + t[e.Status].state + '">' + t[e.Status].title + "</span>"
						//    }
						//}

					]
				}),
					//$("#m_form_status").on("change", function () {

					//    e.search($(this).val().toLowerCase(), "RequestStatus")
					//}),
					$("#m_form_status").on("change", function () { e.search($(this).val().toLowerCase(), "Status") }),
					$("#m_form_status").selectpicker()

			}
		};

		$(document).ready(function () {
			DatatableHtmlTableDemo.init();
			$('#m_table_1').DataTable({
				pagingType: 'full_numbers',
				scrollX: true,
				//'fnDrawCallback': function () {
				//    init_plugins();
				//}
			});

			$('.m_selectpicker').selectpicker();
			//alert('1111');
			var picker = $('#daterangepicker');
			var start = moment().subtract(29, 'days');
			//var end = moment();
			//var start = moment();
			var end = moment().add(30, 'days');



			function cb(start, end, label) {
				var title = '';
				var range = '';

				////if ((end - start) < 100 || label == 'Today') {
				////    title = 'Today:';
				////    range = start.format('MMM D');
				////} else if (label == 'Yesterday') {
				////    title = 'Yesterday:';
				////    range = start.format('MMM D');
				////} else {
				////    range = start.format('MMM D') + ' - ' + end.format('MMM D');
				////}

				range = start.format('MMM D') + ' - ' + end.format('MMM D');

				picker.find('.m-subheader__daterange-date').html(range);
				picker.find('.m-subheader__daterange-title').html(title);
				//alert(start);
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<div class="m-grid__item m-grid__item--fluid m-wrapper">
		<div class="m-content">
			<div class="m-portlet m-portlet--mobile">
				<div class="m-portlet__head">
					<div class="m-portlet__head-caption">
						<div class="m-portlet__head-title">
							<h3 class="m-portlet__head-text">Service Requests	
							</h3>
						</div>
					</div>

					<div class="col-xl-4 order-1 order-xl-2 m--align-right">
						<a href="<%= Page.ResolveClientUrl("~/CSM/List_Service_Requests_Type.aspx") %>" style="margin-top: 5%;" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
							<span>
								<i class="la la-plus"></i>
								<span>New Request</span>
							</span>
						</a>
						<div class="m-separator m-separator--dashed d-xl-none"></div>
					</div>

				</div>
				<div class="m-portlet__body">
					<!--begin: Search Form -->

					<div class="m-form m-form--label-align-right m--margin-bottom-30">
						<div class="row align-items-center">
							<div class="col-xl-12 order-2 order-xl-1">
								<div class="form-group m-form__group row align-items-center">
									<div class="col-md-3">
										<div class="m-form__group m-form__group--inline">
											<div class="m-form__label">
												<label>Status:</label>
											</div>
											<div class="m-form__control">
												<select class="form-control m-bootstrap-select" id="m_form_status">
													<option value="">All</option>
													<option value="Open">Open</option>
													<option value="Close">Close</option>
												</select>
											</div>
										</div>
										<div class="d-md-none m--margin-bottom-10"></div>
									</div>

									<div class="col-md-3">
										<div class="m-input-icon m-input-icon--left">
											<input type="text" class="form-control m-input" placeholder="Search..." id="generalSearch" />
											<span class="m-input-icon__icon m-input-icon__icon--left">
												<span><i class="la la-search"></i></span>
											</span>
										</div>
									</div>

									<div class="col-md-6">
										<div class="m-form__group m-form__group--inline">
											<div class="m-form__label">
												<label>Date:</label>
											</div>
											<div class="m-form__control">
												<span class="m-subheader__daterange btn btn-sm btn-outline-accent" style="padding: 0.15rem 0.8rem;" id="daterangepicker">
													<span class="m-subheader__daterange-label">
														<span class="m-subheader__daterange-title"></span>
														<span class="m-subheader__daterange-date"></span>
														<asp:HiddenField ID="start_date" ClientIDMode="Static" runat="server" />
														<asp:HiddenField ID="end_date" ClientIDMode="Static" runat="server" />
														<asp:HiddenField ID="hdn_IsPostBack" ClientIDMode="Static" runat="server" />
														<asp:HiddenField ID="date_range_title" ClientIDMode="Static" runat="server" />
													</span>
													<button type="button" class="btn btn-accent btn-outline-accent m-btn m-btn--icon m-btn--icon-only m-btn--custom m-btn--pill m--font-light">
														<i class="la la-angle-down"></i>
													</button>
												</span>
												<div class="btn-group" style="margin-left: 50px;">
													<asp:Button ID="btnSearch" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnSearch_Click" Text="Search" />
												</div>
											</div>
										</div>
									</div>



								</div>
							</div>

						</div>
					</div>

					<!--end: Search Form -->

					<!--begin: Datatable -->
					<table class="m-datatable" id="html_table" width="100%">
						<thead>
							<tr>
								<%--<th title="Field #1" data-field="SrNo">Sr. No</th>--%>
								<th title="Request ID" data-field="RequestID">Request ID</th>
								<th title="Configuration Title" data-field="Config_Title">Configuration Title</th>
								<th title="Requested By" data-field="RequestBy">Request By</th>
								<th title="Request Date" data-field="RequestDate">Request Date</th>
								<th title="Closed By" data-field="ClosedBy">Closed By</th>
								<th title="Closed Date" data-field="ClosedDate">Closed Date</th>
								<th title="Status" data-field="Status">Status</th>

							</tr>
						</thead>
						<tbody>

							<%=fetchRequestList()%>
						</tbody>
					</table>

					<!--end: Datatable -->

				</div>
			</div>

			<!-- END EXAMPLE TABLE PORTLET-->
		</div>
	</div>
</asp:Content>
