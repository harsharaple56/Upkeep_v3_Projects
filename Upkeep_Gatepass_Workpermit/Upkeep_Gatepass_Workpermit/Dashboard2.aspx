<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard2.aspx.cs" Inherits="Upkeep_Gatepass_Workpermit.Dashboard2" %>

<%--<%@ Register TagPrefix="asp" Namespace="Saplin.Controls" Assembly="DropDownCheckBoxes" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/webfont/1.6.16/webfont.js"></script>

    <script type="text/javascript">
        function CallDashboardEvent() {
            alert('onch');
            document.getElementById('<%= btnDashboard.ClientID %>').click();
        }



    </script>

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



    <script>
        WebFont.load({
            google: { "families": ["Poppins:300,400,500,600,700", "Roboto:300,400,500,600,700"] },
            active: function () {
                sessionStorage.fonts = true;
            }
        });
    </script>

    <script>
        google.charts.load('current', { 'packages': ['line'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {

            var data = new google.visualization.DataTable();
            data.addColumn('number', 'Day');
            data.addColumn('number', 'Present');
            data.addColumn('number', 'Absent');
            data.addColumn('number', 'Punched In');

            data.addRows([
                [1, 37.8, 80.8, 41.8],
                [2, 30.9, 69.5, 32.4],
                [3, 25.4, 57, 25.7],
                [4, 11.7, 18.8, 10.5],
                [5, 11.9, 17.6, 10.4],
                [6, 8.8, 13.6, 7.7],
                [7, 7.6, 12.3, 9.6],
                [8, 12.3, 29.2, 10.6],
                [9, 16.9, 42.9, 14.8],
                [10, 12.8, 30.9, 11.6],
                [11, 5.3, 7.9, 4.7],
                [12, 6.6, 8.4, 5.2],
                [13, 4.8, 6.3, 3.6],
                [14, 4.2, 6.2, 3.4]
            ]);

            var options = {
                chart: {
                    title: 'Employee Attendance Analysis ',
                    subtitle: 'over the period selected'
                },
                width: 900,
                height: 500
            };

            var chart = new google.charts.Line(document.getElementById('linechart_material'));

            chart.draw(data, google.charts.Line.convertOptions(options));
        }

    </script>


    <%--<script>
        google.charts.load('current', { packages: ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawMultSeries);

        function drawMultSeries() {

            var data = google.visualization.arrayToDataTable([
                ['City', 'Closed', 'Open', 'Parked'],
                ['Housekeeping', 8, 8, 4],
                ['Engineering', 3, 4, 4],
                ['FLS', 3, 5, 4],
                ['Operations', 6, 5, 4],
                ['Security', 3, 7, 4]
            ]);

            var options = {
                title: 'Ticketing / Complaints Dashboard',
                chartArea: { width: '50%' },
                hAxis: {
                    title: 'Total Tickets',
                    minValue: 0
                },
                vAxis: {
                    title: 'Departments'
                }
            };

            var chart = new google.visualization.BarChart(document.getElementById('chart_div'));
            chart.draw(data, options);
        }

    </script>--%>


    <%--<script>
        google.charts.load('current', { packages: ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawMultSeries);

        function drawMultSeries() {

            var data = google.visualization.arrayToDataTable([
                ['City', 'Closed', 'Open', 'Expired'],
                ['Housekeeping', 8, 8, 4],
                ['Engineering', 3, 1, 4],
                ['FLS', 3, 5, 4],
                ['Operations', 6, 2, 4],
                ['Security', 3, 7, 10]
            ]);

            var options = {
                title: 'Checklist Dashboard',
                chartArea: { width: '50%' },
                hAxis: {
                    title: 'Total Checklists',
                    minValue: 0
                },
                vAxis: {
                    title: 'Departments'
                }
            };

            var chart = new google.visualization.BarChart(document.getElementById('chart_div1'));
            chart.draw(data, options);
        }

    </script>--%>

    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
            var options = {
                title: 'Feedbacks analysis',
                hAxis: { title: 'Events', titleTextStyle: { color: '#333' } },
                vAxis: { minValue: 0 }

                //width: 600,
                //height: 400,
                //bar: { groupWidth: "95%" },
                //legend: { position: "none" },
                //isStacked: true,
                //pieHole: 0.4,
            };


            var FromDate = $('#start_date').val();
            var ToDate = $('#end_date').val();

            if (FromDate == '') {
                //alert('blank date');
                var start = moment().subtract(29, 'days');
                var end = moment();

                FromDate = (start.format('DD/MM/YYYY'));
                ToDate = (end.format('DD/MM/YYYY'));
            }


            $.ajax({
                type: "POST",
                url: "Dashboard2.aspx/GetFeedback_AreaChartData",
                //data: '{}',
                data: JSON.stringify({ From_Date: FromDate, To_Date: ToDate }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    //alert(r.d);
                    //var ColumnChart = new google.visualization.ColumnChart($("#Columnchart")[0]);
                    //var BarChart = new google.visualization.BarChart($("#Barchart")[0]);
                    var AreaChart = new google.visualization.AreaChart($("#chart_area")[0]);

                    //var PieChart = new google.visualization.PieChart($("#Piechart")[0]);

                    //ColumnChart.draw(data, options);
                    //BarChart.draw(data, options);
                    AreaChart.draw(data, options);
                    //PieChart.draw(data, options);
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }
        //function drawChart() {
        //    var data = google.visualization.arrayToDataTable([
        //        ['Events', 'Postive', 'Negative', ' Neutral'],
        //        ['RSI Feedback', 1000, 400, 300],
        //        ['CSI Feedback', 1170, 460, 200],
        //        ['Mall Experience', 660, 112, 100],
        //        ['Music Event', 1030, 540, 440]
        //    ]);

        //    var options = {
        //        title: 'Feedbacks analysis',
        //        hAxis: { title: 'Events', titleTextStyle: { color: '#333' } },
        //        vAxis: { minValue: 0 }
        //    };

        //    var chart = new google.visualization.AreaChart(document.getElementById('chart_area'));
        //    chart.draw(data, options);
        //}
    </script>


    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
            var options = {
                //title: 'Checklist',

                //hAxis: { title: 'Events', titleTextStyle: { color: '#333' } },
                //vAxis: { minValue: 0 }

                width: 370,
                height: 250,
                //bar: { groupWidth: "95%" },
                //legend: { position: "none" },
                //isStacked: true,
                pieHole: 0.4,
            };


            var FromDate = $('#start_date').val();
            var ToDate = $('#end_date').val();

            if (FromDate == '') {
                //alert('blank date');
                var start = moment().subtract(29, 'days');
                var end = moment();

                FromDate = (start.format('DD/MM/YYYY'));
                ToDate = (end.format('DD/MM/YYYY'));
            }

            var SelectedCompany = "";

            $.ajax({
                type: "POST",
                url: "Dashboard2.aspx/GetChecklist_PieChartData",
                //data: '{}',
                data: JSON.stringify({ Selected_Company: SelectedCompany, From_Date: FromDate, To_Date: ToDate }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    //alert(r.d);
                    //var ColumnChart = new google.visualization.ColumnChart($("#Columnchart")[0]);
                    //var BarChart = new google.visualization.BarChart($("#Barchart")[0]);
                    //var AreaChart = new google.visualization.AreaChart($("#chart_area")[0]);

                    var PieChart = new google.visualization.PieChart($("#m_chart_checklist_share")[0]);

                    //ColumnChart.draw(data, options);
                    //BarChart.draw(data, options);
                    //AreaChart.draw(data, options);
                    PieChart.draw(data, options);
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }

    </script>


    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {

            var options = {
                //title: 'Checklist Dashboard',
                chartArea: { width: '50%' },
                hAxis: {
                    title: 'Total Checklists',
                    minValue: 0
                },
                vAxis: {
                    title: 'Departments'
                }
            };

            var FromDate = $('#start_date').val();
            var ToDate = $('#end_date').val();

            if (FromDate == '') {
                //alert('blank date');
                var start = moment().subtract(29, 'days');
                var end = moment();

                FromDate = (start.format('DD/MM/YYYY'));
                ToDate = (end.format('DD/MM/YYYY'));
            }

            var SelectedCompany = "";

            $.ajax({
                type: "POST",
                url: "Dashboard2.aspx/GetChecklist_Departmentwise_BarChartData",
                //data: '{}',
                data: JSON.stringify({ Selected_Company: SelectedCompany, From_Date: FromDate, To_Date: ToDate }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    //alert(r.d);
                    //var ColumnChart = new google.visualization.ColumnChart($("#Columnchart")[0]);
                    var BarChart = new google.visualization.BarChart($("#chart_checklist_departmentwise")[0]);
                    //var AreaChart = new google.visualization.AreaChart($("#chart_area")[0]);

                    //var PieChart = new google.visualization.PieChart($("#m_chart_checklist_share")[0]);

                    //ColumnChart.draw(data, options);
                    BarChart.draw(data, options);
                    //AreaChart.draw(data, options);
                    //PieChart.draw(data, options);
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }

    </script>

    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {

            var options = {
                //title: 'Checklist Dashboard',
                chartArea: { width: '50%' },
                hAxis: {
                    title: 'Total Tickets',
                    minValue: 0
                },
                vAxis: {
                    title: 'Departments'
                }
            };

            var FromDate = $('#start_date').val();
            var ToDate = $('#end_date').val();

            if (FromDate == '') {
                //alert('blank date');
                var start = moment().subtract(29, 'days');
                var end = moment();

                FromDate = (start.format('DD/MM/YYYY'));
                ToDate = (end.format('DD/MM/YYYY'));
            }

            var SelectedCompany = "";

            $.ajax({
                type: "POST",
                url: "Dashboard2.aspx/GetTicket_Departmentwise_BarChartData",
                //data: '{}',
                data: JSON.stringify({ Selected_Company: SelectedCompany, From_Date: FromDate, To_Date: ToDate }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    //alert(r.d);
                    //var ColumnChart = new google.visualization.ColumnChart($("#Columnchart")[0]);
                    var BarChart = new google.visualization.BarChart($("#chart_ticket_departmentwise")[0]);
                    //var AreaChart = new google.visualization.AreaChart($("#chart_area")[0]);

                    //var PieChart = new google.visualization.PieChart($("#m_chart_checklist_share")[0]);

                    //ColumnChart.draw(data, options);
                    BarChart.draw(data, options);
                    //AreaChart.draw(data, options);
                    //PieChart.draw(data, options);
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }

    </script>

    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {

            var options = {
                title: {
                    display: false,
                },
                tooltips: {
                    intersect: false,
                    mode: 'nearest',
                    xPadding: 10,
                    yPadding: 10,
                    caretPadding: 10
                },
                legend: {
                    display: false
                },
                responsive: true,
                maintainAspectRatio: false,
                barRadius: 4,
                scales: {
                    xAxes: [{
                        display: false,
                        gridLines: false,
                        stacked: false
                    }],
                    yAxes: [{
                        display: false,
                        stacked: false,
                        gridLines: false
                    }]
                },
                layout: {
                    padding: {
                        left: 0,
                        right: 0,
                        top: 0,
                        bottom: 0
                    }
                },
                //title: 'Checklist Dashboard',
                chartArea: { width: '70%' },
                hAxis: { textPosition: 'none' },
                //hAxis: {
                //   // title: 'Total Tickets',
                //    minValue: 0
                //},
                //vAxis: {
                //    title: 'Departments'
                //},
                isStacked: true,
            };

            var FromDate = $('#start_date').val();
            var ToDate = $('#end_date').val();

            if (FromDate == '') {
                //alert('blank date');
                var start = moment().subtract(29, 'days');
                var end = moment();

                FromDate = (start.format('DD/MM/YYYY'));
                ToDate = (end.format('DD/MM/YYYY'));
            }

            var SelectedCompany = "";

            $.ajax({
                type: "POST",
                url: "Dashboard2.aspx/GetTicket_Categorywise_BarChartData",
                //data: '{}',
                data: JSON.stringify({ Selected_Company: SelectedCompany, From_Date: FromDate, To_Date: ToDate }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    //alert(r.d);
                    var ColumnChart = new google.visualization.ColumnChart($("#chart_Ticket_categorywise")[0]);
                    //var BarChart = new google.visualization.BarChart($("#chart_Ticket_categorywise")[0]);
                    //var AreaChart = new google.visualization.AreaChart($("#chart_area")[0]);

                    //var PieChart = new google.visualization.PieChart($("#m_chart_checklist_share")[0]);

                    ColumnChart.draw(data, options);
                    //BarChart.draw(data, options);
                    //AreaChart.draw(data, options);
                    //PieChart.draw(data, options);
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }

    </script>

    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {

            var data = google.visualization.arrayToDataTable([
                ['Feedback Type', 'Count'],
                ['Positive', 11],
                ['Negative', 2],
                ['Neutral', 6],

            ]);

            var options = {
                title: 'Customers Feedback Analysis'
            };

            // var chart = new google.visualization.PieChart(document.getElementById('piechart1'));

            // chart.draw(data, options);
        }
    </script>


    <%--<script type="text/javascript">

        var api_url = 'http://101.53.152.242/feedo_UAT_Service/FeedbackSystemMobService.asmx/';
        //var api_url = 'http://localhost:5176/FeedbackSystemMobService.asmx/';

        var chart = {
            update_all: function () {
                this.update_Checklist_share();
            },

            update_Checklist_share: function () {
                this.show_loader('#m_chart_checklist_share');

                var event_id = $('#retailer_events').val();
                var start_date = $('#start_date').val();
                var end_date = $('#end_date').val();

                event_id = "13";
                //alert(start_date);
                _chart = this;
                var chart_id = '#m_chart_checklist_share';
                //debugger;
                $.ajax({
                    type: 'POST',
                    url: api_url + 'Get_ChartData',
                    data: { 'EventID': event_id, 'fromDate': start_date, 'toDate': end_date },
                    dataType: 'json',
                    //beforeSend: function () {
                    //    _chart.show_loader(chart_id);
                    //},

                    success: function (data) {

                        Console.log('success');
                        _chart.render(chart_id, data);
                        _chart.show_legends(chart_id, data);
                        _chart.hide_loader(chart_id);
                    },
                    error: function (data) {
                        Console.log('sdsadas');
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
            //$('.m_selectpicker').selectpicker();


            $('#btnDashboard').click(function () {
                //alert('hhhhh');
                //chart.update_Checklist_share();
            }
            );

            $('.m_selectpicker').change(function () {
                var id = $(this).attr('id');
                if (id == 'retailer_events') {
                    chart.update_Checklist_share();
                }
                if (id == 'customer_events') {
                    chart.update_Checklist_share();
                }
            });

            var dropdowns = [
                { 'id': 'retailer_events', 'type': 'R' },
                { 'id': 'customer_events', 'type': 'C' }
            ];
        });

    </script>--%>



    <%--<form method="post" runat="server" id="frmMain">--%>
    <asp:ScriptManager ID="ScriptMgr" runat="server" EnablePageMethods="true"></asp:ScriptManager>

    <div class="m-grid__item m-grid__item--fluid m-wrapper">

        <!-- BEGIN: Subheader -->
        <div class="m-subheader ">
            <div class="d-flex align-items-center">
                <div class="mr-auto">
                    <h3 class="m-subheader__title ">Dashboard</h3>

                    <div class="m-portlet__head-tools">
                        <%--<ul class="m-portlet__nav">            
                            <li class="m-portlet__nav-item m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover" aria-expanded="true">
                                <a href="#" class="m-portlet__nav-link m-dropdown__toggle dropdown-toggle btn btn--sm m-btn--pill btn-secondary m-btn m-btn--label-primary">Select Company
                                </a>
                                <div class="m-dropdown__wrapper" style="z-index: 101;">
                                    <span class="m-dropdown__arrow m-dropdown__arrow--right m-dropdown__arrow--adjust" style="left: auto; right: 51px;"></span>
                                    <div class="m-dropdown__inner">
                                        <div class="m-dropdown__body">
                                            <div class="m-dropdown__content">

                                                
                                                <ul class="m-nav">
                                                    <li class="m-nav__section m-nav__section--first">
                                                        <span class="m-nav__section-text">Listed Companies</span>
                                                    </li>
                                                    <li class="m-nav__item">
                                                        <a href="" class="m-nav__link">

                                                            <span class="m-nav__link-text">Phoenix Kurla</span>
                                                        </a>
                                                    </li>
                                                    <li class="m-nav__item">
                                                        <a href="" class="m-nav__link">

                                                            <span class="m-nav__link-text">High Street Phoenix</span>
                                                        </a>
                                                    </li>
                                                    <li class="m-nav__item">
                                                        <a href="" class="m-nav__link">

                                                            <span class="m-nav__link-text">Phoenix Lucknow</span>
                                                        </a>
                                                    </li>
                                                    <li class="m-nav__item">
                                                        <a href="" class="m-nav__link">
                                                            <i class="m-nav__link-icon flaticon-lifebuoy"></i>
                                                            <span class="m-nav__link-text">Phoenix Bareilly</span>
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
                        </ul>--%>

                        <%--<asp:DropDownCheckBoxes ID="ddlCompany" runat="server" Width="180px" UseSelectAllNode="false">
                                <Style SelectBoxWidth="195" DropDownBoxBoxWidth="160" DropDownBoxBoxHeight="90" />

                            

                            </asp:DropDownCheckBoxes>
                            &nbsp;
                                                <asp:ExtendedRequiredFieldValidator ID="ExtendedRequiredFieldValidator1" runat="server" ControlToValidate="ddlCompany"
                                                    ErrorMessage="Please select Company" ForeColor="Red"></asp:ExtendedRequiredFieldValidator>--%>
                        <asp:DropDownList ID="ddlCompany" runat="server" ToolTip="Company Name"
                            CssClass="m-portlet__nav-link m-dropdown__toggle dropdown-toggle btn btn--sm m-btn--pill btn-secondary m-btn m-btn--label-primary">
                        </asp:DropDownList>

                    </div>
                </div>

                <div>
                    <span class="m-subheader__daterange" id="daterangepicker">
                        <span class="m-subheader__daterange-label">
                            <span class="m-subheader__daterange-title"></span>
                            <span class="m-subheader__daterange-date m--font-brand"></span>
                            <asp:HiddenField ID="start_date" ClientIDMode="Static" runat="server" />
                            <asp:HiddenField ID="end_date" ClientIDMode="Static" runat="server" />
                            <asp:HiddenField ID="hdn_IsPostBack" ClientIDMode="Static" runat="server" />
                            <asp:HiddenField ID="date_range_title" ClientIDMode="Static" runat="server" />
                        </span>
                        <a href="#" class="btn btn-sm btn-brand m-btn m-btn--icon m-btn--icon-only m-btn--custom m-btn--pill">
                            <i class="la la-angle-down"></i>
                        </a>
                    </span>
                    <%--<button id="btnDashboard" onclick="CallDashboardEvent()" style="display: none;"></button>--%>
                    <asp:Button ID="btnDashboard" runat="server" OnClick="btnDashboard_Click" Text="Search" ClientIDMode="Static" CssClass="btn btn-sm btn-brand" />
                </div>
            </div>
        </div>

        <!-- END: Subheader -->
        <div class="m-content" id="dvEmployee" runat="server" style="display: block;">


            <div class="m-portlet">

                <!--begin:: Widgets/Best Sellers-->
                <div class="m-portlet m-portlet--full-height ">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Ticketing / Complaints Dashboard
                                </h3>
                            </div>
                        </div>

                    </div>
                    <div class="m-portlet__body">

                        <!--begin::Content-->
                        <div class="tab-content">
                            <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
                            <div id="chart_ticket_departmentwise"></div>
                        </div>

                        <!--end::Content-->
                    </div>
                </div>

                <!--end:: Widgets/Best Sellers-->
            </div>

            <div class="m-portlet">

                <!--begin:: Widgets/Best Sellers-->
                <div class="m-portlet m-portlet--full-height ">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Checklist Dashboard
                                </h3>
                            </div>
                        </div>

                    </div>
                    <div class="m-portlet__body">

                        <!--begin::Content-->
                        <div class="tab-content">
                            <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
                            <div id="chart_checklist_departmentwise"></div>
                        </div>

                        <!--end::Content-->
                    </div>
                </div>

                <!--end:: Widgets/Best Sellers-->
            </div>



            <%--<div class="m-portlet">--%>

            <%--<div class="m-portlet__body  m-portlet__body--no-padding">--%>
            <div class="m-portlet">
                <div class="m-portlet__body  m-portlet__body--no-padding">
                    <div class="row m-row--no-padding m-row--col-separator-xl">
                        <div class="col-xl-3">

                            <!--begin:: Widgets/Stats2-1 -->
                            <div class="m-widget1">
                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col">
                                            <h3 class="m-widget1__title">Total Open</h3>
                                            <span class="m-widget1__desc">Total No. of Open Tickets</span>
                                        </div>
                                        <div class="col m--align-right">
                                            <span class="m-widget1__number m--font-brand">
                                                <asp:Label ID="lblOpenTicket" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col">
                                            <h3 class="m-widget1__title">Total Closed</h3>
                                            <span class="m-widget1__desc">Total No. of Closed Tickets</span>
                                        </div>
                                        <div class="col m--align-right">
                                            <span class="m-widget1__number m--font-success">
                                                <asp:Label ID="lblCloseTicket" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">
                                        <div class="col">
                                            <h3 class="m-widget1__title">Total Parked</h3>
                                            <span class="m-widget1__desc">Total No. of Closed Tickets</span>
                                        </div>
                                        <div class="col m--align-right">
                                            <span class="m-widget1__number m--font-brand">
                                                <asp:Label ID="lblParkedTicket" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                            </span>
                                        </div>
                                    </div>
                                </div>


                            </div>

                            <!--end:: Widgets/Stats2-1 -->
                        </div>
                        <div class="col-xl-4">

                            <!--begin:: Widgets/Daily Sales-->
                            <div class="m-widget14">
                                <div class="m-widget14__header m--margin-bottom-30">
                                    <h3 class="m-widget14__title">Category wise Tickets
                                    </h3>
                                    <span class="m-widget14__desc">Bifurcation of tickets based on different Categories
                                    </span>
                                </div>
                                <div class="tab-content">
                                    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
                                    <div id="chart_Ticket_categorywise"></div>
                                </div>

                                <%--<div class="m-widget14__chart" style="height: 120px;">
                                    <canvas id="m_chart_daily_sales"></canvas>
                                </div>--%>
                            </div>

                            <!--end:: Widgets/Daily Sales-->
                        </div>
                        <div class="col-xl-5">

                            <!--begin:: Widgets/Profit Share-->
                            <div class="m-widget14">
                                <div class="m-widget14__header">
                                    <h3 class="m-widget14__title">Checklists
                                    </h3>
                                    <span class="m-widget14__desc">Summary of Checklists for the period
                                    </span>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <div id="m_chart_checklist_share" class="m-widget14__chart">
                                            <div class="m-widget14__stat"></div>
                                        </div>
                                    </div>
                                    <%--<div class="col">                                       
                                        <div class="m-widget14__legends">
                                            <div class="m-widget14__legend">
                                                <span class="m-widget14__legend-bullet m--bg-accent"></span>
                                                <span class="m-widget14__legend-text">Pending</span>
                                            </div>
                                            <div class="m-widget14__legend">
                                                <span class="m-widget14__legend-bullet m--bg-warning"></span>
                                                <span class="m-widget14__legend-text">Closed</span>
                                            </div>
                                            <div class="m-widget14__legend">
                                                <span class="m-widget14__legend-bullet m--bg-brand"></span>
                                                <span class="m-widget14__legend-text">Expired</span>
                                            </div>
                                        </div>
                                    </div>--%>
                                </div>
                            </div>

                            <!--end:: Widgets/Profit Share-->
                        </div>
                    </div>
                </div>
            </div>



            <%-- <div class="m-portlet">--%>
            <!--Begin::Section-->
            <div class="row">
                <div class="col-xl-4">

                    <!--begin:: Widgets/Top Products-->
                    <div class="m-portlet m-portlet--bordered-semi m-portlet--widget-fit m-portlet--full-height m-portlet--skin-light  m-portlet--rounded-force">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <h3 class="m-portlet__head-text m--font-light">Gatepass Summary
                                    </h3>
                                </div>
                            </div>
                            <div class="m-portlet__head-tools">
                                <ul class="m-portlet__nav">
                                    <li class="m-portlet__nav-item m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover">
                                        <%--<a href="#" class="m-portlet__nav-link m-portlet__nav-link--icon m-portlet__nav-link--icon-xl">
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
                                                                        <li class="m-nav__separator m-nav__separator--fit"></li>
                                                                        <li class="m-nav__item">
                                                                            <a href="#" class="btn btn-outline-danger m-btn m-btn--pill m-btn--wide btn-sm">Cancel</a>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>--%>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="m-portlet__body">
                            <div class="m-widget17">
                                <div class="m-widget17__visual m-widget17__visual--chart m-portlet-fit--top m-portlet-fit--sides m--bg-danger">
                                    <div class="m-widget17__chart" style="height: 109px;">
                                    </div>
                                </div>
                                <div class="m-widget17__stats">
                                    <div class="m-widget17__items m-widget17__items-col1">
                                        <div class="m-widget17__item">
                                            <span class="m-widget17__icon">
                                                <%--<i class="flaticon-truck m--font-brand"></i>--%>
                                                <img src="assets/app/media/img/icons/total.png" style="width: 55px; height: 39px;" />
                                            </span>
                                            <span class="m-widget17__subtitle">Total
                                            </span>
                                            <%--<asp:Label ID="lblGPTotal" runat="server" CssClass="form-control-label widget17__desc" style="font-weight:bold;" Text="15" ></asp:Label>--%>
                                            <span class="m-widget17__desc">
                                                <asp:Label ID="lblGPTotal" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                                Requests raised
                                            </span>
                                        </div>
                                        <div class="m-widget17__item">
                                            <span class="m-widget17__icon">
                                                <%--<i class="flaticon-paper-plane m--font-info"></i>--%>
                                                <img src="assets/app/media/img/icons/hold-90.png" style="width: 55px; height: 42px;" />
                                            </span>
                                            <span class="m-widget17__subtitle">On Hold
                                            </span>
                                            <span class="m-widget17__desc">
                                                <asp:Label ID="lblGPHold" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                                Requests
                                            </span>
                                        </div>
                                        <div class="m-widget17__item">
                                            <span class="m-widget17__icon">
                                                <%--<i class="flaticon-paper-plane m--font-info"></i>--%>
                                                <img src="assets/app/media/img/icons/approved-64.png" style="width: 55px; height: 42px;" />
                                            </span>
                                            <span class="m-widget17__subtitle">Approve
                                            </span>
                                            <span class="m-widget17__desc">
                                                <asp:Label ID="lblGPApproved" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                                Requests
                                            </span>
                                        </div>
                                    </div>
                                    <div class="m-widget17__items m-widget17__items-col2">
                                        <div class="m-widget17__item">
                                            <span class="m-widget17__icon">
                                                <i class="flaticon-pie-chart m--font-success"></i>

                                            </span>
                                            <span class="m-widget17__subtitle">Open
                                            </span>
                                            <span class="m-widget17__desc">
                                                <asp:Label ID="lblGPOpen" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text="15"></asp:Label>
                                                Requests
                                            </span>
                                        </div>
                                        <div class="m-widget17__item">
                                            <span class="m-widget17__icon">
                                                <%--<i class="flaticon-time m--font-danger"></i>--%>
                                                <img src="assets/app/media/img/icons/rejcted-144.png" style="width: 55px; height: 42px;" />
                                            </span>
                                            <span class="m-widget17__subtitle">Rejected
                                            </span>
                                            <span class="m-widget17__desc">
                                                <asp:Label ID="lblGPRejected" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text="15"></asp:Label>
                                                Requests
                                            </span>
                                        </div>
                                        <div class="m-widget17__item">
                                            <span class="m-widget17__icon">
                                                <%--<i class="flaticon-time m--font-danger"></i>--%>
                                                <img src="assets/app/media/img/icons/closed-96.png" style="width: 55px; height: 42px;" />
                                            </span>
                                            <span class="m-widget17__subtitle">Closed
                                            </span>
                                            <span class="m-widget17__desc">
                                                <asp:Label ID="lblGPClosed" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                                Requests
                                            </span>
                                        </div>
                                    </div>


                                </div>
                                <div class="m-widget17__item m-widget17__items m-widget17__items-col2" style="text-align: center;" id="dvGPPendingApproval" runat="server">
                                    <span class="m-widget17__subtitle" style="font-weight: bold;">Pending Approvals :</span>
                                    <span class="m-widget17__desc">
                                        <asp:Label ID="lblGPPendingApprovalCount" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                    </span>
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
                                    <h3 class="m-portlet__head-text m--font-light">Work Permit Summary
                                    </h3>
                                </div>
                            </div>
                            <div class="m-portlet__head-tools">
                                <ul class="m-portlet__nav">
                                    <li class="m-portlet__nav-item m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover">
                                        <%--<a href="#" class="m-portlet__nav-link m-portlet__nav-link--icon m-portlet__nav-link--icon-xl">
                                                        <i class="fa fa-genderless m--font-light"></i>
                                                    </a>--%>
                                        <%--<div class="m-dropdown__wrapper">
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
                                                    </div>--%>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="m-portlet__body">
                            <div class="m-widget17">
                                <div class="m-widget17__visual m-widget17__visual--chart m-portlet-fit--top m-portlet-fit--sides m--bg-danger">
                                    <div class="m-widget17__chart" style="height: 109px;">
                                    </div>
                                </div>
                                <div class="m-widget17__stats">
                                    <div class="m-widget17__items m-widget17__items-col1">
                                        <div class="m-widget17__item">
                                            <span class="m-widget17__icon">
                                                <%--<i class="flaticon-truck m--font-brand"></i>--%>
                                                <img src="assets/app/media/img/icons/total.png" style="width: 55px; height: 39px;" />
                                            </span>
                                            <span class="m-widget17__subtitle">Total
                                            </span>
                                            <span class="m-widget17__desc">
                                                <asp:Label ID="lblWPTotalRequest" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                                Requests raised
                                            </span>
                                        </div>
                                        <div class="m-widget17__item">
                                            <span class="m-widget17__icon">
                                                <%--<i class="flaticon-paper-plane m--font-info"></i>--%>
                                                <img src="assets/app/media/img/icons/hold-90.png" style="width: 55px; height: 42px;" />
                                            </span>
                                            <span class="m-widget17__subtitle">On Hold
                                            </span>
                                            <span class="m-widget17__desc">
                                                <asp:Label ID="lblWPHold" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                                Requests
                                            </span>
                                        </div>
                                        <div class="m-widget17__item">
                                            <span class="m-widget17__icon">
                                                <%--<i class="flaticon-paper-plane m--font-info"></i>--%>
                                                <img src="assets/app/media/img/icons/approved-64.png" style="width: 55px; height: 42px;" />
                                            </span>
                                            <span class="m-widget17__subtitle">Approve
                                            </span>
                                            <span class="m-widget17__desc">
                                                <asp:Label ID="lblWPApproved" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                                Requests
                                            </span>
                                        </div>
                                    </div>
                                    <div class="m-widget17__items m-widget17__items-col2">
                                        <div class="m-widget17__item">
                                            <span class="m-widget17__icon">
                                                <i class="flaticon-pie-chart m--font-success"></i>
                                            </span>
                                            <span class="m-widget17__subtitle">Open
                                            </span>
                                            <span class="m-widget17__desc">
                                                <asp:Label ID="lblWPOpen" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                                Requests
                                            </span>
                                        </div>
                                        <div class="m-widget17__item">
                                            <span class="m-widget17__icon">
                                                <%--<i class="flaticon-time m--font-danger"></i>--%>
                                                <img src="assets/app/media/img/icons/rejcted-144.png" style="width: 55px; height: 42px;" />
                                            </span>
                                            <span class="m-widget17__subtitle">Rejected
                                            </span>
                                            <span class="m-widget17__desc">
                                                <asp:Label ID="lblWPRejected" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                                Requests
                                            </span>
                                        </div>
                                        <div class="m-widget17__item">
                                            <span class="m-widget17__icon">
                                                <%--<i class="flaticon-time m--font-danger"></i>--%>
                                                <img src="assets/app/media/img/icons/closed-96.png" style="width: 55px; height: 42px;" />
                                            </span>
                                            <span class="m-widget17__subtitle">Closed
                                            </span>
                                            <span class="m-widget17__desc">
                                                <asp:Label ID="lblWPClosed" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                                Requests
                                            </span>
                                        </div>

                                    </div>
                                </div>
                                <div class="m-widget17__item m-widget17__items m-widget17__items-col2" style="text-align: center;" id="dvWPPendingApproval" runat="server">
                                    <span class="m-widget17__subtitle" style="font-weight: bold;">Pending Approvals :</span>
                                    <span class="m-widget17__desc">
                                        <asp:Label ID="lblWPPendingApprovalCount" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                    </span>
                                </div>


                            </div>
                        </div>
                    </div>

                    <!--end:: Widgets/Activity-->

                </div>
                <div class="col-xl-4">

                    <!--begin:: Packages-->
                    <div class="m-portlet m--bg-warning m-portlet--bordered-semi m-portlet--full-height ">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <h3 class="m-portlet__head-text m--font-light">WOW Centre Services
                                    </h3>
                                </div>
                            </div>
                            <div class="m-portlet__head-tools">
                                <ul class="m-portlet__nav">
                                    <li class="m-portlet__nav-item m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover">
                                        <%--<a href="#" class="m-portlet__nav-link m-dropdown__toggle dropdown-toggle btn btn--sm m-btn--pill m-btn btn-outline-light m-btn--hover-light">2018
                                                    </a>--%>
                                        <div class="m-dropdown__wrapper">
                                            <span class="m-dropdown__arrow m-dropdown__arrow--right m-dropdown__arrow--adjust"></span>
                                            <div class="m-dropdown__inner">
                                                <div class="m-dropdown__body">
                                                    <div class="m-dropdown__content">
                                                        <ul class="m-nav">
                                                            <li class="m-nav__section m-nav__section--first">
                                                                <span class="m-nav__section-text">Reports</span>
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
                                                            <li class="m-nav__section m-nav__section--first">
                                                                <span class="m-nav__section-text">Export</span>
                                                            </li>
                                                            <li class="m-nav__item">
                                                                <a href="" class="m-nav__link">
                                                                    <i class="m-nav__link-icon flaticon-lifebuoy"></i>
                                                                    <span class="m-nav__link-text">PDF</span>
                                                                </a>
                                                            </li>
                                                            <li class="m-nav__item">
                                                                <a href="" class="m-nav__link">
                                                                    <i class="m-nav__link-icon flaticon-lifebuoy"></i>
                                                                    <span class="m-nav__link-text">Excel</span>
                                                                </a>
                                                            </li>
                                                            <li class="m-nav__item">
                                                                <a href="" class="m-nav__link">
                                                                    <i class="m-nav__link-icon flaticon-lifebuoy"></i>
                                                                    <span class="m-nav__link-text">CSV</span>
                                                                </a>
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

                            <!--begin::Widget 29-->
                            <div class="m-widget29">
                                <div class="m-widget_content">
                                    <h3 class="m-widget_content-title">Baggage Service Requests</h3>
                                    <div class="m-widget_content-items">
                                        <div class="m-widget_content-item">
                                            <span>Total</span>
                                            <span class="m--font-accent">
                                                <asp:Label ID="lblBaggageTotal" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                            </span>
                                        </div>
                                        <div class="m-widget_content-item">
                                            <span>Open</span>
                                            <span>
                                                <asp:Label ID="lblBaggageOpen" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold; color: red;" Text=""></asp:Label>
                                            </span>
                                        </div>
                                        <div class="m-widget_content-item">
                                            <span>Closed</span>
                                            <span>
                                                <asp:Label ID="lblBaggageClosed" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold; color: green;" Text=""></asp:Label>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                <div class="m-widget_content">
                                    <h3 class="m-widget_content-title">Power Bank Service Requests</h3>
                                    <div class="m-widget_content-items">
                                        <div class="m-widget_content-item">
                                            <span>Total</span>
                                            <span class="m--font-accent">
                                                <asp:Label ID="lblPowerBankTotalRequest" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                            </span>
                                        </div>
                                        <div class="m-widget_content-item">
                                            <span>Open</span>
                                            <span>
                                                <asp:Label ID="lblPowerBankOpen" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold; color: red;" Text=""></asp:Label>
                                            </span>
                                        </div>
                                        <div class="m-widget_content-item">
                                            <span>Closed</span>
                                            <span>
                                                <asp:Label ID="lblPowerBankClosed" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold; color: green;" Text=""></asp:Label>
                                            </span>
                                        </div>

                                    </div>
                                    <br />
                                    <h3 class="m-widget_content-title">Power Bank Inventory</h3>
                                    <div class="m-widget_content-items">
                                        <div class="m-widget_content-item">
                                            <span>Available</span>
                                            <span>
                                                <asp:Label ID="lblPowerBankAvailable" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold; color: green;" Text=""></asp:Label>
                                            </span>
                                        </div>
                                        <div class="m-widget_content-item">
                                            <span>In Use</span>
                                            <span>
                                                <asp:Label ID="lblPowerBankInUse" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold; color: red;" Text=""></asp:Label>
                                            </span>
                                        </div>
                                        <div class="m-widget_content-item">
                                            <span>Total</span>
                                            <span>
                                                <asp:Label ID="lblPowerBankTotal" runat="server" CssClass="form-control-label widget17__desc m--font-accent" Style="font-weight: bold;" Text=""></asp:Label>
                                            </span>
                                        </div>
                                    </div>
                                </div>

                            </div>

                            <!--end::Widget 29-->
                        </div>
                    </div>

                    <!--end:: Packages-->
                </div>
                <div class="col-xl-4">

                    <!--begin:: Widgets/Blog-->
                    <!--end:: Widgets/Blog-->
                </div>
            </div>
            <%--</div>--%>
            <!--End::Section-->
            <!--Begin::Section-->
            <!--End::Section-->
            <!--Begin::Section-->
            <div class="row">
                <div class="col-xl-4">

                    <!--begin:: Widgets/Blog-->
                    <!--end:: Widgets/Blog-->
                </div>
                <div class="col-xl-4">

                    <!--begin:: Widgets/Blog-->
                    <!--end:: Widgets/Blog-->
                </div>
                <div class="col-xl-4">

                    <!--begin:: Packages-->
                    <!--end:: Packages-->
                </div>
            </div>

            <!--End::Section-->
            <!--Begin::Section-->
            <div class="row">
                <div class="col-xl-6">

                    <!--begin:: Widgets/Tasks -->
                    <!--end:: Widgets/Tasks -->
                </div>
                <div class="col-xl-6">

                    <!--begin:: Widgets/Support Tickets -->
                    <!--end:: Widgets/Support Tickets -->
                </div>
            </div>

            <!--End::Section-->
            <!--Begin::Section-->
            <div class="row">
                <div class="col-xl-6 col-lg-12">

                    <!--Begin::Portlet-->
                    <!--End::Portlet-->
                </div>
                <div class="col-xl-6 col-lg-12">

                    <!--Begin::Portlet-->
                    <!--End::Portlet-->
                </div>
            </div>

            <!--End::Section-->
            <!--Begin::Section-->
            <!--End::Section-->
            <!--Begin::Section-->

            <div class="m-portlet">

                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <h3 class="m-portlet__head-text">Feedbacks Dashboard
                            </h3>
                        </div>
                    </div>

                    <div class="m-dropdown m-dropdown--inline m-dropdown--large m-dropdown--arrow m-dropdown--align-right" style="display: none;" m-dropdown-toggle="hover" aria-expanded="true">
                        <a href="#" class="m-dropdown__toggle btn btn-warning dropdown-toggle">Select Event
                        </a>
                        <div class="m-dropdown__wrapper" style="z-index: 101;">
                            <span class="m-dropdown__arrow m-dropdown__arrow--left"></span>
                            <div class="m-dropdown__inner">
                                <div class="m-dropdown__body">
                                    <div class="m-dropdown__content">
                                        <ul class="m-nav">
                                            <li class="m-nav__section m-nav__section--first">
                                                <span class="m-nav__section-text">Events</span>
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
                                                <a href="#" class="btn btn-outline-danger m-btn m-btn--pill m-btn--wide btn-sm">Logout</a>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>


                </div>

                <div class="m-portlet__body  m-portlet__body--no-padding">
                    <div class="row m-row--no-padding m-row--col-separator-xl">

                        <!--begin:: Widgets/Daily Sales-->
                        <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
                        <div id="chart_area" style="width: 100%; height: 500px;"></div>



                        <!--end:: Widgets/Daily Sales-->
                    </div>

                </div>
            </div>



            <div class="m-portlet">



                <div class="m-portlet__body  m-portlet__body--no-padding">
                    <div class="row m-row--no-padding m-row--col-separator-xl">
                        <div class="col-xl-4">

                            <!--begin:: Widgets/Daily Sales-->
                            <div class="m-widget14">
                                <div class="m-portlet__head">
                                    <div class="m-portlet__head-caption">
                                        <div class="m-portlet__head-title">
                                            <h3 class="m-portlet__head-text">User Attendances Dashboard
                                            </h3>
                                        </div>
                                    </div>

                                </div>
                                <div class="m-portlet__body">

                                    <div class="row m-row--no-padding m-row--col-separator-xl">

                                        <div>
                                            <!--begin::Content-->
                                            <div class="tab-content">
                                                <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
                                                <div id="linechart_material"></div>
                                            </div>
                                            <div class="m-widget1">
                                                <div class="m-widget1__item">
                                                    <div class="row m-row--no-padding align-items-center">
                                                        <div>
                                                            <h3 class="m-widget1__title">Total Employees</h3>
                                                            <span class="m-widget1__desc">Total No. of Employees</span>
                                                        </div>
                                                        <div class="col m--align-right">
                                                            <span class="m-widget1__number m--font-brand">800</span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="m-widget1__item">
                                                    <div class="row m-row--no-padding align-items-center">
                                                        <div>
                                                            <h3 class="m-widget1__title">Present Employees</h3>
                                                            <span class="m-widget1__desc">Total No. of Present Employees from 1-March-2020 to 31-March-2020</span>
                                                        </div>
                                                        <div class="col m--align-right">
                                                            <span class="m-widget1__number m--font-success">27</span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="m-widget1__item">
                                                    <div class="row m-row--no-padding align-items-center">
                                                        <div>
                                                            <h3 class="m-widget1__title">Absent Employees</h3>
                                                            <span class="m-widget1__desc">Total No. of Absent Employees from from 1-March-2020 to 31-March-2020</span>
                                                        </div>
                                                        <div class="col m--align-right">
                                                            <span class="m-widget1__number m--font-brand">123</span>
                                                        </div>
                                                    </div>
                                                </div>


                                            </div>


                                            <!--end::Content-->

                                        </div>

                                    </div>

                                </div>

                                <!--end:: Widgets/Daily Sales-->
                            </div>

                        </div>
                        <div class="col-xl-4">

                            <!--begin:: Widgets/Stats2-1 -->

                            <!--end:: Widgets/Stats2-1 -->
                        </div>

                    </div>



                    <!--begin:: Widgets/Best Sellers-->

                    <!--end:: Widgets/Best Sellers-->
                </div>

                <%-- </div>--%>
                <div class="row">
                </div>

                <!--End::Section-->
            </div>



            <%--</div>--%>




            <%-- </div>--%>
        </div>


        <div class="m-content bg-white" id="dvRetailer" runat="server" style="display: block;">
            <div class="m-portlet">
                <div class="row">
                    <div class="col-xl-4">

                        <!--begin:: Widgets/Top Products-->
                        <div class="m-portlet m-portlet--bordered-semi m-portlet--widget-fit m-portlet--full-height m-portlet--skin-light  m-portlet--rounded-force">
                            <div class="m-portlet__head">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text m--font-light">Gatepass Summary
                                        </h3>
                                    </div>
                                </div>
                                <div class="m-portlet__head-tools">
                                    <ul class="m-portlet__nav">
                                        <li class="m-portlet__nav-item m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover">
                                            <%--<a href="#" class="m-portlet__nav-link m-portlet__nav-link--icon m-portlet__nav-link--icon-xl">
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
                                                                        <li class="m-nav__separator m-nav__separator--fit"></li>
                                                                        <li class="m-nav__item">
                                                                            <a href="#" class="btn btn-outline-danger m-btn m-btn--pill m-btn--wide btn-sm">Cancel</a>
                                                                        </li>
                                                                    </ul>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>--%>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div class="m-portlet__body">
                                <div class="m-widget17">
                                    <div class="m-widget17__visual m-widget17__visual--chart m-portlet-fit--top m-portlet-fit--sides m--bg-danger">
                                        <div class="m-widget17__chart" style="height: 109px;">
                                        </div>
                                    </div>
                                    <div class="m-widget17__stats">
                                        <div class="m-widget17__items m-widget17__items-col1">
                                            <div class="m-widget17__item">
                                                <span class="m-widget17__icon">
                                                    <%--<i class="flaticon-truck m--font-brand"></i>--%>
                                                    <img src="assets/app/media/img/icons/total.png" style="width: 55px; height: 39px;" />
                                                </span>
                                                <span class="m-widget17__subtitle">Total
                                                </span>
                                                <%--<asp:Label ID="lblGPTotal" runat="server" CssClass="form-control-label widget17__desc" style="font-weight:bold;" Text="15" ></asp:Label>--%>
                                                <span class="m-widget17__desc">
                                                    <asp:Label ID="lblR_GP_Total" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                                    Requests raised
                                                </span>
                                            </div>
                                            <div class="m-widget17__item">
                                                <span class="m-widget17__icon">
                                                    <%--<i class="flaticon-paper-plane m--font-info"></i>--%>
                                                    <img src="assets/app/media/img/icons/hold-90.png" style="width: 55px; height: 42px;" />
                                                </span>
                                                <span class="m-widget17__subtitle">On Hold
                                                </span>
                                                <span class="m-widget17__desc">
                                                    <asp:Label ID="lblR_GP_Hold" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                                    Requests
                                                </span>
                                            </div>
                                            <div class="m-widget17__item">
                                                <span class="m-widget17__icon">
                                                    <%--<i class="flaticon-paper-plane m--font-info"></i>--%>
                                                    <img src="assets/app/media/img/icons/approved-64.png" style="width: 55px; height: 42px;" />
                                                </span>
                                                <span class="m-widget17__subtitle">Approve
                                                </span>
                                                <span class="m-widget17__desc">
                                                    <asp:Label ID="lblR_GP_Approve" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                                    Requests
                                                </span>
                                            </div>
                                        </div>
                                        <div class="m-widget17__items m-widget17__items-col2">
                                            <div class="m-widget17__item">
                                                <span class="m-widget17__icon">
                                                    <i class="flaticon-pie-chart m--font-success"></i>
                                                </span>
                                                <span class="m-widget17__subtitle">Open
                                                </span>
                                                <span class="m-widget17__desc">
                                                    <asp:Label ID="lblR_GP_Open" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                                    Requests
                                                </span>
                                            </div>
                                            <div class="m-widget17__item">
                                                <span class="m-widget17__icon">
                                                    <%--<i class="flaticon-time m--font-danger"></i>--%>
                                                    <img src="assets/app/media/img/icons/rejcted-144.png" style="width: 55px; height: 42px;" />
                                                </span>
                                                <span class="m-widget17__subtitle">Rejected
                                                </span>
                                                <span class="m-widget17__desc">
                                                    <asp:Label ID="lblR_GP_Rejected" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                                    Requests
                                                </span>
                                            </div>
                                            <div class="m-widget17__item">
                                                <span class="m-widget17__icon">
                                                    <%--<i class="flaticon-time m--font-danger"></i>--%>
                                                    <img src="assets/app/media/img/icons/closed-96.png" style="width: 55px; height: 42px;" />
                                                </span>
                                                <span class="m-widget17__subtitle">Closed
                                                </span>
                                                <span class="m-widget17__desc">
                                                    <asp:Label ID="lblR_GP_Close" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                                    Requests
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
                                        <h3 class="m-portlet__head-text m--font-light">Work Permit Summary
                                        </h3>
                                    </div>
                                </div>
                                <div class="m-portlet__head-tools">
                                    <ul class="m-portlet__nav">
                                        <li class="m-portlet__nav-item m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover">
                                            <%--<a href="#" class="m-portlet__nav-link m-portlet__nav-link--icon m-portlet__nav-link--icon-xl">
                                                        <i class="fa fa-genderless m--font-light"></i>
                                                    </a>--%>
                                            <%--<div class="m-dropdown__wrapper">
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
                                                    </div>--%>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div class="m-portlet__body">
                                <div class="m-widget17">
                                    <div class="m-widget17__visual m-widget17__visual--chart m-portlet-fit--top m-portlet-fit--sides m--bg-danger">
                                        <div class="m-widget17__chart" style="height: 109px;">
                                        </div>
                                    </div>
                                    <div class="m-widget17__stats">
                                        <div class="m-widget17__items m-widget17__items-col1">
                                            <div class="m-widget17__item">
                                                <span class="m-widget17__icon">
                                                    <%--<i class="flaticon-truck m--font-brand"></i>--%>
                                                    <img src="assets/app/media/img/icons/total.png" style="width: 55px; height: 39px;" />
                                                </span>
                                                <span class="m-widget17__subtitle">Total
                                                </span>
                                                <span class="m-widget17__desc">
                                                    <asp:Label ID="lblR_WP_Total" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                                    Requests raised
                                                </span>
                                            </div>
                                            <div class="m-widget17__item">
                                                <span class="m-widget17__icon">
                                                    <%--<i class="flaticon-paper-plane m--font-info"></i>--%>
                                                    <img src="assets/app/media/img/icons/hold-90.png" style="width: 55px; height: 42px;" />
                                                </span>
                                                <span class="m-widget17__subtitle">On Hold
                                                </span>
                                                <span class="m-widget17__desc">
                                                    <asp:Label ID="lblR_WP_Hold" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                                    Requests
                                                </span>
                                            </div>
                                            <div class="m-widget17__item">
                                                <span class="m-widget17__icon">
                                                    <%--<i class="flaticon-paper-plane m--font-info"></i>--%>
                                                    <img src="assets/app/media/img/icons/approved-64.png" style="width: 55px; height: 42px;" />
                                                </span>
                                                <span class="m-widget17__subtitle">Approve
                                                </span>
                                                <span class="m-widget17__desc">
                                                    <asp:Label ID="lblR_WP_Approve" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                                    Requests
                                                </span>
                                            </div>
                                        </div>
                                        <div class="m-widget17__items m-widget17__items-col2">
                                            <div class="m-widget17__item">
                                                <span class="m-widget17__icon">
                                                    <i class="flaticon-pie-chart m--font-success"></i>
                                                </span>
                                                <span class="m-widget17__subtitle">Open
                                                </span>
                                                <span class="m-widget17__desc">
                                                    <asp:Label ID="lblR_WP_Open" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                                    Requests
                                                </span>
                                            </div>
                                            <div class="m-widget17__item">
                                                <span class="m-widget17__icon">
                                                    <%--<i class="flaticon-time m--font-danger"></i>--%>
                                                    <img src="assets/app/media/img/icons/rejcted-144.png" style="width: 55px; height: 42px;" />
                                                </span>
                                                <span class="m-widget17__subtitle">Rejected
                                                </span>
                                                <span class="m-widget17__desc">
                                                    <asp:Label ID="lblR_WP_Rejected" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                                    Requests
                                                </span>
                                            </div>
                                            <div class="m-widget17__item">
                                                <span class="m-widget17__icon">
                                                    <%--<i class="flaticon-time m--font-danger"></i>--%>
                                                    <img src="assets/app/media/img/icons/closed-96.png" style="width: 55px; height: 42px;" />
                                                </span>
                                                <span class="m-widget17__subtitle">Closed
                                                </span>
                                                <span class="m-widget17__desc">
                                                    <asp:Label ID="lblR_WP_Close" runat="server" CssClass="form-control-label widget17__desc" Style="font-weight: bold;" Text=""></asp:Label>
                                                    Requests
                                                </span>
                                            </div>

                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <!--end:: Widgets/Activity-->

                    </div>


                </div>

            </div>
        </div>
        <!-- end:: Body -->

    </div>
    <%--</form>--%>
    <%--</div>--%>
</asp:Content>
