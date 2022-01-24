<%@ Page Language="C#" MasterPageFile="~/BlankMaster.Master" AutoEventWireup="true" CodeBehind="FLR6.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Reports_Excise.Maharashtra.FLR6" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   
    <script>
        $(document).ready(function () {


            $('.m_selectpicker').selectpicker();
            //alert('1111');
            var picker = $('#daterangepicker');
            var start = moment().subtract(6, 'days');
            var end = moment();
            //var start = moment();
            //var end = moment().add(30, 'days');


            function cb(start, end, label) {
                var title = '';
                var range = '';


                range = start.format('DD-MMM-YYYY') + ' - ' + end.format('DD-MMM-YYYY');

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

            $("#m_form_status").on("change", function () {
                //alert($(this).val());
                $('#hdnTicketStatus').val($(this).val());
            })

            $("#m_form_type").on("change", function () {
                //alert($(this).val());
                $('#hdnActionStatus').val($(this).val());
            })

        });
    </script>

    <div class="m-grid__item m-grid__item--fluid">
        <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">
            <div class="m-portlet__head">
                <div class="m-portlet__head-caption">
                    <div class="m-portlet__head-title">
                        <h3 class="m-portlet__head-text">FLR-III Excise Report		
                        </h3>
                    </div>
                </div>
                <div class="m-portlet__head-tools">
                    <ul class="m-portlet__nav">
                        <li class="m-portlet__nav-item">
                            <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports_Excise/Generate_Reports.aspx") %>" class="btn btn-metal m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m--margin-right-10">
                                <span>
                                    <i class="la la-arrow-left"></i>
                                    <span>Back</span>
                                </span>
                            </a>
                        </li>
                    </ul>
                </div>


            </div>
            <div class="m-portlet__body">
                <!--begin: Search Form -->

                <div class="form-group row">
                    <label class="col-md-1 col-form-label font-weight-bold" style="margin-top: 10px;">License  :</label>
                    <div class="col-md-3 col-form-label">
                        <asp:DropDownList AutoPostBack="true" ID="ddlLicense" runat="server" CssClass="form-control m-input m-input--air" ClientIDMode="Static"></asp:DropDownList>
                    </div>

                    <label class="col-md-2 col-form-label font-weight-bold" style="margin-top: 10px;">Filter Date Range  :</label>
                    <div class="col-md-3 col-form-label">
                        <div class="m-form__control">
                            <span class="m-subheader__daterange btn btn-sm btn-outline-brand" style="padding: 0.15rem 0.8rem; width: -webkit-fill-available;" id="daterangepicker">
                                <span class="m-subheader__daterange-label" style="font-size: 12px;">
                                    <span class="m-subheader__daterange-title"></span>
                                    <span class="m-subheader__daterange-date"></span>
                                    <asp:HiddenField ID="start_date" ClientIDMode="Static" runat="server" />
                                    <asp:HiddenField ID="end_date" ClientIDMode="Static" runat="server" />
                                    <asp:HiddenField ID="hdn_IsPostBack" ClientIDMode="Static" runat="server" />
                                    <asp:HiddenField ID="date_range_title" ClientIDMode="Static" runat="server" />
                                    <asp:HiddenField ID="hdnTicketStatus" ClientIDMode="Static" runat="server" />
                                    <asp:HiddenField ID="hdnActionStatus" ClientIDMode="Static" runat="server" />
                                </span>
                                <button type="button" class="btn btn-brand btn-outline-brand m-btn m-btn--icon m-btn--icon-only m-btn--custom m-btn--pill m--font-brand">
                                    <i class="la la-angle-down"></i>
                                </button>
                            </span>
                        </div>
                    </div>

                    <label class="col-md-1 col-form-label font-weight-bold" style="padding-right: 0px;"></label>
                    <div class="col-md-2 col-form-label">
                        <div class="btn-group">
                            <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Transactions/Sales.aspx") %>" class="btn btn-danger m-btn m-btn--icon m-btn--pill m-btn--air">
                                <span>
                                    <i class="fa fa-angle-double-right"></i>
                                    <span>Generate</span>
                                    <i class="fab fa-whmcs"></i>

                                </span>
                            </a>
                        </div>
                    </div>
                </div>


                <div class="progress m-progress--sm">
                    <div class="progress-bar bg-primary" role="progressbar" style="width: 100%" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100"></div>
                </div>


                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <div class="row m--margin-bottom-20 m--align-center">
                            <div class="col-lg-12 m--margin-bottom-10-tablet-and-mobile">

                                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Width="1400px">
                                </rsweb:ReportViewer>

                            </div>
                        </div>

                    </ContentTemplate>

                </asp:UpdatePanel>


            </div>
        </div>


    </div>
</asp:Content>

