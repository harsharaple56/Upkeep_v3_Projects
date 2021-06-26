<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="Upkeep_v3.Feedback.Customers" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#m_table_1').DataTable({
                responsive: true,
                pagingType: 'full_numbers',
                'fnDrawCallback': function () {
                    init_plugins();
                }
            });

            $('#photo_modal').on('show.bs.modal', function (event) {
                var button = $(event.relatedTarget);
                var src = button.data('src');
                $(this).find('.modal-body img').attr('src', src);
            })
        });
    </script>

    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {

            var data = google.visualization.arrayToDataTable([
                ['Task', 'Hours per Day'],
                ['Unique', 11],
                ['Repeated', 2],
            ]);
            

            var chart = new google.visualization.PieChart(document.getElementById('piechart'));
            
            chart.draw(data, {
              title: 'Contacts',
            });
        }
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
            
            //alert('fsdfsdfs');
            var SelectedCompany = $('#hdnCompanyID').val();

            $.ajax({
                type: "POST",
                url: "Customers.aspx/GetEmails_PieChartData",
                //data: '{}',
                data: JSON.stringify({ Company_ID: SelectedCompany}),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    //alert(r.d);
                    //var ColumnChart = new google.visualization.ColumnChart($("#Columnchart")[0]);
                    //var BarChart = new google.visualization.BarChart($("#Barchart")[0]);
                    //var AreaChart = new google.visualization.AreaChart($("#chart_area")[0]);

                    var PieChart = new google.visualization.PieChart($("#piechart_Emails")[0]);

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

            var data = google.visualization.arrayToDataTable([
                ['Task', 'Hours per Day'],
                ['Unique', 20],
                ['Repeated', 10],
            ]);

            var options = {
                title: 'Names'
            };

            var chart = new google.visualization.PieChart(document.getElementById('piechart_Names'));

            chart.draw(data, options);
        }
    </script>





    <form class="m-form m-form--label-align-left- m-form--state-" id="Customer_form">
        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
            <asp:HiddenField ID="hdnCompanyID" ClientIDMode="Static" runat="server" />
            <div class="m-content">
                <div class="row">
                    <div class="col-xl-7">
                        <div class="m-portlet m-portlet--mobile">
                            <div class="m-portlet__head">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">Customers Data	
                                        </h3>
                                    </div>
                                </div>
                                <div class="m-portlet__head-tools">
                                    <ul class="m-portlet__nav">
                                        <li class="m-portlet__nav-item">
                                            <button id="btnAddSubCategory" runat="server" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--air" onclick="btnSendSMS_Click">
                                                <span>
                                                    <i class="fa fa-envelope"></i>
                                                    <span>Send SMS</span>
                                                </span>
                                            </button>
                                        </li>
                                    </ul>
                                </div>

                            </div>

                            <div class="m-portlet__body">

                                <!--begin: Datatable -->
                                <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">
                                    <thead>
                                        <tr>
                                            <th>Name</th>
                                            <th>Gender</th>
                                            <th>Email</th>
                                            <th>Contact</th>
                                            <th>Created on</th>
                                            <th>Photo</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <%=bindCustomers()%>
                                    </tbody>
                                </table>

                                <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="Excel" class="btn btn-primary btn-success" />

                            </div>
                        </div>
                    </div>
                    <div class="col-xl-5">
                        <div class="m-portlet m-portlet--mobile">
                            <div class="m-portlet__head">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">Data Analysis
                                        </h3>
                                    </div>
                                </div>
                            </div>

                            <div class="m-portlet__body">

                                <div id="piechart"></div>
                                <div id="piechart_Emails"></div>
                                <div id="piechart_Names"></div>


                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>

    </form>


</asp:Content>
