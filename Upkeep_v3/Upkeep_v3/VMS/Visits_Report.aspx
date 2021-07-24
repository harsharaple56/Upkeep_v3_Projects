<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Visits_Report.aspx.cs" Inherits="Upkeep_v3.VMS.Visits_Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <!-- <div class="m-grid m-grid--hor m-grid--root m-page">
			<div class="m-grid__item m-grid__item--fluid m-grid  m-error-6" >
				<div class="m-error_container">
					<div >
						<img src="assets/app/media/img/bg/coming-soon-9.gif">

                        <h1>Coming Soon...</h1>
                        
					</div>
					<p >
                        
						This feature is under Development<br>
						Your will be notified soon once its available for use.
                        <br />
                        <br />
                        <br />

					</p>
				</div>
			</div>
		</div>-->


      <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript" ></script>
    <script>
        $(document).ready(function () {
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
                $('#date_range_title').val(title+range);
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

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
                <div class="m-content">

                     
                        <div class="m-portlet m-portlet--mobile">
                            <div class="m-portlet__head">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">Vist Report		
                                        </h3>
                                    </div>
                                </div>
                                <div class="m-portlet__head-caption float-right">
                                    <div class="m-form__group m--margin-right-15">                                       

                                        <asp:DropDownList class="btn btn-accent dropdown-toggle" ID="ddlFormName" ClientIDMode="Static" runat="server" title="Select Form" data-live-search="true" data-size="3" data-style="btn btn-accent m-btn--pill" data-width="200px">
                                        </asp:DropDownList>

                                    </div>
                                    <span class="m-subheader__daterange btn btn-sm btn-accent"  id="daterangepicker"  style="padding: 0.15rem 0.8rem;">
                                        <span class="m-subheader__daterange-label">
                                            <span class="m-subheader__daterange-title"></span>
                                            <span class="m-subheader__daterange-date"></span>
                                            <%--<input type="hidden" id="start_date" runat="server" >
                                            <input type="hidden" id="end_date" runat="server">--%>
                                            <asp:HiddenField id="start_date" ClientIDMode="Static" runat="server" />
                                            <asp:HiddenField id="end_date" ClientIDMode="Static" runat="server" />
                                            <asp:HiddenField id="hdn_IsPostBack" ClientIDMode="Static" runat="server" />
                                            <asp:HiddenField id="date_range_title" ClientIDMode="Static" runat="server" />
                                        </span>
                                        <button type="button" class="btn btn-accent btn-outline-accent m-btn m-btn--icon m-btn--icon-only m-btn--custom m-btn--pill m--font-light" style="width: 37px; height: 37px;">
                                            <i class="la la-angle-down"></i>
                                        </button>
                                    </span>
                                    <div class="btn-group" style="margin-left: 15px;">
                                        <asp:Button ID="btnSearch" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnSearch_Click" Text="Search" />
                                    </div>
                                </div>

                            </div>
                           
                            <div class="m-portlet__body">

                                <!--begin: Datatable -->

                                 <table class="m-datatable" id="html_table" width="100%">
                                <thead>
                                    <tr>
                                        <%--<th title="Field #1" data-field="SrNo">Sr. No</th>--%>
                                        <th title="Request ID" data-field="RequestID">Request ID</th>
                                        <th title="Configuration Title" data-field="Config_Title">Configuration Title</th>
                                        <th title="Name" data-field="Name">Name</th>
                                        <th title="Contact" data-field="Phone">Contact</th>
                                        <th title="Email" data-field="Email">Email</th>
                                        <th title="In Time" data-field="InTime">In Time</th>
                                        <th title="Out Time" data-field="OutTime">Out Time</th>
                                        <th title="Status" data-field="Status">Status</th>
                                        <th title="Created By" data-field="Created_By">Created By</th>
                                        <th title="Visit Date" data-field="MeetDate">Visit Date</th>
                                        <th title="Request Date" data-field="RequestDate">Request Date</th>


                                    </tr>
                                </thead>
                                <tbody>

                                    <%=fetchVMSRequestList()%>
                                </tbody>
                            </table>

















                               <!-- <table class="table table-striped- table-bordered table-hover table-checkable dataTable" id="m_table_1">
                                    <thead>
                                     
                                  <%--      <%=bindHeader()%>--%>

                                           
                                    </thead>
                                    <tbody>

                                     <%--   <%=bindMIS_Report()%>--%>

                                       
                                    </tbody>
                                </table>-->
                                
                                <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="Export To Excel" class="btn btn-primary btn-success" />
                            </div>
                        </div>
                        <!-- END EXAMPLE TABLE PORTLET-->

                   
                </div>
            </div>

</asp:Content>
