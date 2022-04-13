<%@ Page Language="C#" MasterPageFile="~/Cocktail_World_Master.Master" AutoEventWireup="true" CodeBehind="Washday.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Transactions.Washday" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .underline {
            border-bottom-color: #5867dd;
            border-bottom-width: 3px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#m_table_1').DataTable({
                responsive: true,
                pagingType: 'full_numbers',
                'fnDrawCallback': function () {
                    init_plugins();
                }
            });
        });
    </script>
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

                $('#start_date').val(start.format('DD-MMM-YYYY'));
                $('#end_date').val(end.format('DD-MMM-YYYY'));
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

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="m-portlet m-portlet--mobile">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <h3 class="m-portlet__head-text">Wash Day</h3>
                        </div>
                    </div>

                    <div class="m-portlet__head-tools">



                        <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Transactions/Select_Transaction.aspx") %>" class="btn btn-metal m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m--margin-right-10">
                            <span>
                                <i class="la la-arrow-left"></i>
                                <span>Back</span>
                            </span>
                        </a>

                        <asp:LinkButton ID="btnSave" ValidationGroup="ValidateSave" OnClick="btnSave_Click"
                            runat="server" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                                         <span>
                                <i class="fas fa-hands-wash"></i>
                                        <span>Wash</span>
                                    </span>
                        </asp:LinkButton>

                    </div>

                </div>

                <div class="m-portlet__body">

                    <form class="m-form m-form--fit m--margin-bottom-20">
                        <div class="row m--margin-bottom-20 m--align-center">


                            <div class="col-lg-4 m--margin-bottom-10-tablet-and-mobile">
                                <label class="font-weight-bold">Filter by License:</label>

                                <div class="m-form__control">
                                    <asp:DropDownList ID="ddlLicense" runat="server" CssClass="underline form-control" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-lg-4 m--margin-bottom-10-tablet-and-mobile">
                                <label class="font-weight-bold">Filter Date Range:</label>

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

                            <div class="col-lg-4 m--margin-bottom-10-tablet-and-mobile">
                                <label class="font-weight-bold">Sale</label>
                                <div class="m-form__control">
                                    <asp:CheckBox Checked="True" ID="chkSale" runat="server" />
                                </div>

                            </div>


                        </div>

                    </form>


                    <hr />



                </div>
            </div>

            <!-- END EXAMPLE TABLE PORTLET-->
        </div>
    </div>

</asp:Content>

