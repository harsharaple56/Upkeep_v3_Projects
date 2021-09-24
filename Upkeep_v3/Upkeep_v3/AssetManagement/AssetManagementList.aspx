<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="AssetManagementList.aspx.cs" Inherits="Upkeep_v3.AssetManagement.AssetManagementList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            DatatableHtmlTableDemo.init();
        });

        var DatatableHtmlTableDemo = {
            init: function () {
                var e; e = $(".m-datatable").mDatatable({
                    data: { saveState: { cookie: !1 } },
                    search: { input: $("#generalSearch") },
                    columns: [
                        {
                            field: "AMC_Status", title: "AMC_Status", template: function (e) {
                                var t =
                                {
                                    // "Open": { title: "Open", class: "m-badge--danger" },
                                    "IN-ACTIVE": { title: "IN-ACTIVE", class: "m-badge--danger" },

                                    "ACTIVE": { title: "ACTIVE", class: " m-badge--success" },
                                    "CLOSE": { title: "Closed", class: " m-badge--success" },
                                    "APPROVE": { title: "Approved", class: " m-badge--success" },
                                    "HOLD": { title: "Hold", class: " m-badge--warning" },
                                    "Expired": { title: "Expired", class: "bg-secondary text-black" },
                                    "In Progress": { title: "In Progress", class: "text-white bg-info" }
                                }; return '<span class="m-badge ' + t[e.AMC_Status].class + ' m-badge--wide">' + t[e.AMC_Status].title + "</span>"
                            }
                        }

                    ]
                }),
                    $("#m_form_status").on("change", function () { e.search($(this).val().toLowerCase(), "AMC_Status") }),
                    $("#m_form_status").selectpicker()

            }
        };

    </script>

    <%--<script>
        $(document).ready(function () {
            //$('#m_table_1').DataTable({
            //    pagingType: 'full_numbers',
            //    scrollX: true,
            //    //'fnDrawCallback': function () {
            //    //    init_plugins();
            //    //}
            //});

            //$('.m_selectpicker').selectpicker();
            ////alert('1111');
            //var picker = $('#daterangepicker');
            ////var start = moment().subtract(29, 'days');
            ////var end = moment();
            //var start = moment();
            //var end = moment().add(30, 'days');


            //function cb(start, end, label) {
            //    var title = '';
            //    var range = ''; 
            //    range = start.format('MMM D') + ' - ' + end.format('MMM D');

            //    picker.find('.m-subheader__daterange-date').html(range);
            //    picker.find('.m-subheader__daterange-title').html(title);

            //    $('#start_date').val(start.format('DD/MM/YYYY'));
            //    $('#end_date').val(end.format('DD/MM/YYYY'));
            //    $('#date_range_title').val(title + range);
            //}

            //picker.daterangepicker({
            //    direction: mUtil.isRTL(),
            //    startDate: start,
            //    endDate: end,
            //    opens: 'left',
            //    ranges: {
            //        'Today': [moment(), moment()],
            //        'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
            //        'Last 7 Days': [moment().subtract(6, 'days'), moment()],
            //        'Last 30 Days': [moment().subtract(29, 'days'), moment()],
            //        'This Month': [moment().startOf('month'), moment().endOf('month')],
            //        'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
            //    }
            //}, cb);

            //var IsPostBack2 = $('#hdn_IsPostBack').val();

            //if (IsPostBack2 == "no") {
            //    cb(start, end, '');
            //}
            //else {

            //    //picker.find('.m-subheader__daterange-title').html($('#date_range_title').val());
            //}

        });
    </script>--%>

    <%--<form method="post" runat="server" id="frmMain">--%>


    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="m-portlet m-portlet--mobile">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <h3 class="m-portlet__head-text">List of Assets	
                            </h3>
                        </div>
                    </div>



                    <div class="m-portlet__head-tools">
                        <div class="m-portlet__head-tools">
                            <ul class="m-portlet__nav">

                                <li class="m-portlet__nav-item">
                                    <a href="<%= Page.ResolveClientUrl("~/AssetManagement/AssetManagementRequest.aspx") %>" style="margin-top: 5%;"
                                        class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                                        <span>
                                            <i class="la la-plus"></i>
                                            <span>Add New Asset</span>
                                        </span>
                                    </a>
                                </li>

                            </ul>

                            <ul class="m-portlet__nav">
                                <li class="m-portlet__nav-item m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover" aria-expanded="true">

                                    <a href="#" class="m-dropdown__toggle dropdown-toggle btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                                        <%--<span class="fa fa-database"></span>--%>
                                        Export Data
                                    </a>
                                    <div class="m-dropdown__wrapper">
                                        <div class="m-dropdown__inner">
                                            <div class="m-dropdown__body">
                                                <div class="m-dropdown__content">
                                                    <ul class="m-nav">
                                                        <li class="m-nav__section m-nav__section--first">
                                                            <span class="m-nav__section-text">Export Data Format</span>
                                                        </li>
                                                        <hr />
                                                        <li class="m-nav__item">
                                                            <a class="m-nav__link" id="export_excel" onserverclick="btnExportExcel_Click" runat="server">
                                                                <i class="m-nav__link-icon la la-file-excel-o"></i>
                                                                <span class="m-nav__link-text">Excel</span>
                                                            </a>
                                                        </li>

                                                        <li class="m-nav__item">
                                                            <a onserverclick="btnExportPDF_Click" runat="server" class="m-nav__link" id="export_pdf">
                                                                <i class="m-nav__link-icon la la-file-pdf-o"></i>
                                                                <span class="m-nav__link-text">PDF</span>
                                                            </a>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ul>

                            <ul class="m-portlet__nav">

                                <li class="m-portlet__nav-item">
                                    <a href="#" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill" runat="server" id="btnImportExcelPopup" onserverclick="btnImport_Click">
                                        <span>
                                            <i class="fa fa-file-import"></i>
                                            <span>Import Data</span>
                                        </span>
                                    </a>
                                </li>


                            </ul>
                            <cc1:ModalPopupExtender ID="mpeUserMst" runat="server" PopupControlID="pnlImportExport" TargetControlID="btnImportExcelPopup"
                                CancelControlID="btnCloseHeader" BackgroundCssClass="modalBackground">
                            </cc1:ModalPopupExtender>

                        </div>

                    </div>

                </div>
                <div class="m-portlet__body">
                    <!--begin: Search Form -->

                    <div class="m-form m-form--label-align-right m--margin-bottom-30">
                        <div class="row align-items-center">
                            <div class="col-xl-12 order-2 order-xl-1">
                                <div class="form-group m-form__group row align-items-center">


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
                                                <%--<label>Date:</label>--%>
                                            </div>
                                            <div class="m-form__control">
                                                <%--                                                    <span class="m-subheader__daterange btn btn-sm btn-outline-accent" style="padding: 0.15rem 0.8rem;" id="daterangepicker">
                                                        <span class="m-subheader__daterange-label">
                                                            <span class="m-subheader__daterange-title"></span>
                                                            <span class="m-subheader__daterange-date"></span>
                                                            <asp:HiddenField ID="start_date" ClientIDMode="Static" runat="server" />
                                                            <asp:HiddenField ID="end_date" ClientIDMode="Static" runat="server" />
                                                            <asp:HiddenField ID="date_range_title" ClientIDMode="Static" runat="server" />
                                                        </span>
                                                        <button type="button" class="btn btn-accent btn-outline-accent m-btn m-btn--icon m-btn--icon-only m-btn--custom m-btn--pill m--font-light">
                                                            <i class="la la-angle-down"></i>
                                                        </button>
                                                    </span>--%>
                                                <asp:HiddenField ID="hdn_IsPostBack" ClientIDMode="Static" runat="server" />

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
                    <table class="table table-striped- table-bordered table-hover table-checkable m-datatable" id="m_table_1">
                        <thead>
                            <tr>

                                <%--<th title="Field #1" data-field="SrNo">Sr. No</th>--%>
                                <%--<th title="Config ID" data-field="Chk_Config_ID">Checklist Config ID</th>--%>
                                <th>Asset ID</th>
                                <th>Asset Name</th>
                                <%--<th title="Desc" data-field="Asset_Desc">Desc</th>
                                    <th title="Maker" data-field="Asset_Make">Maker</th>--%>
                                <th>Serial No</th>
                                <th>Type</th>
                                <th>Category</th>
                                <th>Department</th>
                                <th>Location</th>
                                <%--<th title="Asset Cost" data-field="Asset_Cost">Asset Cost</th> 
                                    <th title="Currency Type" data-field="Currency_Type">Currency Type</th>
                                    <th title="Purchase Date" data-field="Asset_Purchase_Date">Purchase Date</th>
                                    <th title="Is AMC Active" data-field="Asset_Is_AMC_Active">Is AMC Active</th>
                                    <th title="Created By" data-field="Created_By">Created By</th>
                                    <th title="Created Date" data-field="Created_Date">Created Date</th>--%>
                                <th title="AMC_Status" data-field="AMC_Status">AMC Status</th>

                            </tr>
                        </thead>
                        <tbody>

                            <%=fetchListing()%>
                        </tbody>
                    </table>

                    <!--end: Datatable -->

                </div>
            </div>

            <!-- END EXAMPLE TABLE PORTLET-->
        </div>
        <asp:Panel ID="pnlImportExport" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 100%;">
            <div class="" id="add_sub_location" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document" style="max-width: 700px;">
                    <div class="modal-content">

                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Import Data</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="form-group m-form__group row">
                                <label for="message-text" class="col-xl-2 col-lg-2 form-control-label">Import :</label>
                                <div class="col-xl-9 col-lg-9">
                                    <asp:FileUpload ID="FU_AssetMst" runat="server" CssClass="custom-file-input" accept=".csv, application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/vnd.ms-excel" />
                                    <label id="lbl_userpic" class="custom-file-label" for="customFile" style="padding-right: 418px;">
                                        Choose file
                                    </label>
                                    <asp:RequiredFieldValidator ID="rfvImport" runat="server" ControlToValidate="FU_AssetMst" ErrorMessage="Please upload a file" ForeColor="Red"
                                        Display="Dynamic" ValidationGroup="ValidationImport"></asp:RequiredFieldValidator>
                                    <span id="ImportError_Msg" style="color: red;"></span>
                                    <asp:Label ID="lblImportErrorMsg" Text="" runat="server" ForeColor="Red"></asp:Label>

                                </div>
                            </div>
                            <div class="form-group m-form__group row">
                                <div class="col-xl-12 col-lg-11">
                                    <div style="overflow-y: auto; height: 250px; display: none;" id="dvErrorGrid" runat="server">
                                        <asp:GridView ID="gvImportError" runat="server" AutoGenerateColumns="true" HeaderStyle-BackColor="#f4f3f8" HeaderStyle-ForeColor="Black"
                                            CssClass="table table-striped- table-bordered table-hover table-checkable" OnRowDataBound="gvImportError_RowDataBound">
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">

                            <asp:LinkButton Style="margin-right: 250px;" ID="LinkButton1" runat="server" OnClick="lnkSampleFile_Click" ClientIDMode="Static">
                                     <img src="../assets/app/media/img/icons/download_sample_26.png" />
                                    <span>Download Sample Import File</span>
                            </asp:LinkButton>

                            <asp:Button ID="btnImportExcel" Text="Import" runat="server" OnClick="btnImport_Click" ValidationGroup="ValidationImport" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" />
                            <asp:Button ID="btnCloseImportPopUp" Text="Close" OnClick="btnCloseImportPopUp_Click" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" />
                        </div>

                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>



</asp:Content>
