<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Optimum_Quantity_Report.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Reports.Standard.Optimum_Quantity_Report" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .underline {
            border-bottom-color: #5867dd;
            border-bottom-width: 3px;
        }
    </style>

    <script>
        $(document).ready(function () {

            $('#m_table_1').DataTable({
                responsive: true,
                pagingType: 'full_numbers',
                'fnDrawCallback': function () {
                    init_plugins();
                }
            });


            $('.datetimepicker').datepicker({
                todayHighlight: true,
                orientation: 'auto bottom',
                autoclose: true,
                pickerPosition: 'bottom-right',
                format: 'dd-MM-yyyy',
                showMeridian: true
            });
        });
    </script>
    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="m-portlet m-portlet--mobile">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <h3 class="m-portlet__head-text">Optimum Quantity Report</h3>
                        </div>
                    </div>

                    <div class="m-portlet__head-tools">



                        <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports/View_Reports.aspx") %>" class="btn btn-metal m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m--margin-right-10">
                            <span>
                                <i class="la la-arrow-left"></i>
                                <span>Back</span>
                            </span>
                        </a>
                        <ul class="m-portlet__nav">
                            <li class="m-portlet__nav-item m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover" aria-expanded="true">

                                <a href="#" class="btn m-btn--pill btn-outline-focus m-btn--icon m-btn--air">
                                    <span>
                                        <i class="fa fa-database" aria-hidden="true"></i>
                                        <span>Export Data</span>
                                    </span>

                                </a>
                                <div class="m-dropdown__wrapper" style="z-index: 101;">
                                    <span class="m-dropdown__arrow m-dropdown__arrow--right m-dropdown__arrow--adjust" style="left: auto; right: 73px;"></span>
                                    <div class="m-dropdown__inner">
                                        <div class="m-dropdown__body">
                                            <div class="m-dropdown__content">
                                                <ul class="m-nav">
                                                    <li class="m-nav__section m-nav__section--first">
                                                        <span class="m-nav__section-text">Export Data Format</span>
                                                    </li>
                                                    <hr />

                                                    <li class="m-nav__item">
                                                        <a id="export_excel" class="m-nav__link" href="javascript:__doPostBack('export_excel','')">
                                                            <i class="m-nav__link-icon la la-file-excel-o" style="font-size: 2rem"></i>
                                                            <span class="m-nav__link-text">Excel <b>( .xls )</b></span>
                                                        </a>
                                                    </li>
                                                    <li class="m-nav__item">
                                                        <a id="export_pdf" class="m-nav__link" href="javascript:__doPostBack('export_pdf','')">
                                                            <i class="m-nav__link-icon la la-file-pdf-o" style="font-size: 2rem"></i>
                                                            <span class="m-nav__link-text">PDF <b>( .pdf )</b></span>
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
                                <label class="font-weight-bold">Date:</label>
                                <div class="m-form__control">
                                    <div class="input-group date">
                                        <asp:TextBox autocomplete="off" runat="server" type="text" class="form-control m-input datetimepicker" ID="txtDate">
                                        </asp:TextBox>
                                        <div class="input-group-append">
                                            <span class="input-group-text">
                                                <i class="la la-calendar" style="font-size: 2rem;"></i>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-lg-4 m--margin-bottom-10-tablet-and-mobile">
                                <label class="font-weight-bold">Search Filters:</label>
                                <div class="m-form__control">
                                    <button id="btnSearch" runat="server" class="btn m-btn--pill    btn-primary m-btn m-btn--custom">
                                        <span>
                                            <i class="la la-search"></i>
                                            <span>Search</span>
                                        </span>
                                    </button>
                                </div>

                            </div>

                        </div>

                    </form>




                    <!--begin: Datatable -->
                    <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1" width="100%">
                        <thead>
                            <tr>
                                <th>Category</th>
                                <th>Subcategory</th>
                                <th>Brand</th>
                                <th>Size</th>
                                <th>Optimum Level</th>
                                <th>Opening</th>
                                <th>Purchase</th>
                                <th>Sale</th>
                                <th>Closing</th>
                                <th>BaseQty</th>
                                <th>Reorder Level</th>
                                <th>Excess Quantity</th>
                                <th>License Name</th>
                                <th>License No</th>
                                <th>Address</th>
                            </tr>
                        </thead>

                        <tbody>
                            <%=Bind_Report()%>
                        </tbody>
                    </table>

                    <!--end: Datatable -->

                </div>
            </div>

            <!-- END EXAMPLE TABLE PORTLET-->
        </div>
    </div>

</asp:Content>

