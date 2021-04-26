////== Class definition

//var DatatableHtmlTableDemo = function() {
//	//== Private functions

//	// demo initializer
//	var demo = function() {

//		var datatable = $('.m-datatable').mDatatable({
//			data: {
//				saveState: {cookie: false},
//			},
//			search: {
//				input: $('#generalSearch'),
//			},
//			columns: [
//				{
//					field: 'DepositPaid',
//					type: 'number',
//				},
//				{
//					field: 'OrderDate',
//					type: 'date',
//					format: 'DD-MM-YYYY',
//                },

//     //           {
//     //               field: "RequestStatus",
//     //               title: "RequestStatus",
//					//// callback function support for column rendering
//					//template: function(row) {
//					//	var status = {
//     //                       1: { title: "Open", class: "m-badge--brand"},
//					//		2: {title: "Closed", class: " m-badge--metal"},
//					//		//3: {title: 'Canceled', class: ' m-badge--primary'},
//					//		//4: {title: 'Success', class: ' m-badge--success'},
//					//		//5: {title: 'Info', class: ' m-badge--info'},
//					//		//6: {title: 'Danger', class: ' m-badge--danger'},
//					//		//7: {title: 'Warning', class: ' m-badge--warning'},
//					//	};
//					//	return '<span class="m-badge ' + status[row.Status].class + ' m-badge--wide">' + status[row.Status].title + '</span>';
//					//},
//     //           },

//    //            {
//				//	field: 'Type',
//				//	title: 'Type',
//				//	// callback function support for column rendering
//				//	template: function(row) {
//				//		var status = {
//				//			1: {'title': 'Online', 'state': 'danger'},
//				//			2: {'title': 'Retail', 'state': 'primary'},
//				//			3: {'title': 'Direct', 'state': 'accent'},
//				//		};
//				//		return '<span class="m-badge m-badge--' + status[row.Type].state + ' m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-' +
//				//			status[row.Type].state + '">' +
//				//			status[row.Type].title + '</span>';
//				//	},
//				//},
//			],
//		});

//        $('#m_form_status').on('change', function () {
//            alert('hi');
//            datatable.search($(this).val().toLowerCase(), 'RequestStatus');
//		});

//		$('#m_form_type').on('change', function() {
//            datatable.search($(this).val().toLowerCase(), 'ActionStatus');
//		});

//		$('#m_form_status, #m_form_type').selectpicker();

//	};

//	return {
//		//== Public functions
//		init: function() {
//			// init dmeo
//			demo();
//		},
//	};
//}();

//jQuery(document).ready(function() {
//	DatatableHtmlTableDemo.init();
//});


var DatatableHtmlTableDemo = {
    init: function () {
        var e; e = $(".m-datatable").mDatatable({
            data: { saveState: { cookie: !1 } },
            search: { input: $("#generalSearch") },
            columns: [{ field: "DepositPaid", type: "number" },
                {
                    field: "OrderDate", type: "date", format: "YYYY-MM-DD"
                }
                ,
                
                {
                    field: "RequestStatus", title: "RequestStatus", template: function (e) {
                        var t =
                        {
                            "Open": { title: "Open", class: "m-badge--danger" },
                            "Expired": { title: "Expired", class: "m-badge--secondary" },
                            //"FaultyTicket": { title: "FaultyTicket", class: " m-badge--primary" },
                            "Closed": { title: "Closed", class: " m-badge--success" },
                            "Parked": { title: "Parked", class: " m-badge--warning" }
                            //5: { title: "Info", class: " m-badge--info" },
                            //6: { title: "Danger", class: " m-badge--danger" },
                            //7: { title: "Warning", class: " m-badge--warning" }
                        }; return '<span class="m-badge ' + t[e.RequestStatus].class + ' m-badge--wide">' + t[e.RequestStatus].title + "</span>"
                    }
                }

                ,{
                    field: "ActionStatus",
                    title: "ActionStatus",
                    template: function (e) {
                        var t1 = {
                            "Assigned": { title: "Assigned", state: "info" },
                            "Accepted": { title: "Accepted", state: "success" },
                            "In Progress": { title: "In Progress", state: "accent" },
                            "Hold": { title: "Hold", state: "warning" },
                            "Closed": { title: "Closed", state: "success" },
                            "Expired": { title: "Expired", state: "secondary" }
                        }; return '<span class="m-badge m-badge--' + t1[e.ActionStatus].state + ' m-badge--dot"></span>&nbsp;<span class="m--font-bold m--font-' + t1[e.ActionStatus].state + '">' + t1[e.ActionStatus].title + "</span>"
                    }
                    }

            ]
        }),
            $("#m_form_status").on("change", function () {
                
                e.search($(this).val().toLowerCase(), "RequestStatus")
            }),
            $("#m_form_type").on("change", function () { e.search($(this).val().toLowerCase(), "ActionStatus") }),
            $("#m_form_status, #m_form_type").selectpicker()


       
        
    }
}; jQuery(document).ready(function () {
    DatatableHtmlTableDemo.init()
});