<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cocktail_Code.aspx.cs" MasterPageFile="~/UpkeepMaster.Master" Inherits="Upkeep_v3.Cocktail_World.Setup.Cocktail_Code" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets/demo/custom/crud/metronic-datatable/base/html-table.js") %>" type="text/javascript"></script>



    <div class="m-content">
        <div class="m-grid__item m-grid__item--fluid">

            <div class="m-portlet m-portlet--mobile">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <h3 class="m-portlet__head-text">Cocktail Code
                            </h3>
                        </div>
                    </div>

                    <div class="m-portlet__head-tools">
                        <ul class="m-portlet__nav">

                            <li class="m-portlet__nav-item">
                                <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Setup/Setup.aspx") %>" class="btn m-btn--pill    btn-metal m-btn m-btn--custom">
                                    <span>
                                        <i class="la la-arrow-left"></i>
                                        <span>Back</span>
                                    </span>
                                </a>
                            </li>

                            <li class="m-portlet__nav-item">

                                <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Setup/Assign_Cocktail_Code.aspx") %>"
                                    class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                                    <span>
                                        <i class="flaticon-add"></i>
                                        <span>Add Cocktail Code</span>
                                    </span>
                                </a>
                            </li>


                        </ul>

                        <ul class="m-portlet__nav">
                            <li class="m-portlet__nav-item m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover" aria-expanded="true">

                                <a href="#" class="btn m-btn--pill    btn-primary m-btn m-btn--custom">
                                    <span>
                                        <i class="fa flaticon-grid-menu"></i>
                                        <span>Export Data</span>
                                    </span>

                                </a>
                                <div class="m-dropdown__wrapper" style="z-index: 101;">
                                    <span class="m-dropdown__arrow m-dropdown__arrow--right m-dropdown__arrow--adjust" style="left: auto; right: 72.5px;"></span>
                                    <div class="m-dropdown__inner">
                                        <div class="m-dropdown__body">
                                            <div class="m-dropdown__content">
                                                <ul class="m-nav">
                                                    <li class="m-nav__section m-nav__section--first">
                                                        <span class="m-nav__section-text"><i class="fa fa-database"></i>Export Data</span>
                                                    </li>
                                                    <hr />

                                                    <li class="m-nav__item">
                                                        <a class="m-nav__link" id="A1" runat="server" >
                                                            <i class="m-nav__link-icon la la-file-excel-o" style="font-size: 2rem"></i>
                                                            <span class="m-nav__link-text">Excel <b>( .xls )</b></span>
                                                        </a>
                                                    </li>

                                                    <li class="m-nav__item">
                                                        <a class="m-nav__link" id="A2" runat="server" >
                                                            <i class="m-nav__link-icon la la-file-pdf-o" style="font-size: 2rem"></i>
                                                            <span class="m-nav__link-text">Pdf  <b>( .pdf )</b></span>
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
                    <!--begin: Search Form -->


                    <div class="m-form m-form--fit m--margin-bottom-20">
                        <div class="row m--align-center">

                            <div class="col-lg-4 m--margin-bottom-10-tablet-and-mobile">

                                <label class="font-weight-bold">Cocktail Name :</label>
                                <input type="text" class="form-control m-input" placeholder="Search..." id="CocktailName" />

                            </div>

                            <div class="col-lg-4 m--margin-bottom-10-tablet-and-mobile">
                                <label class="font-weight-bold">Cocktail Code :</label>
                                <input type="text" class="form-control m-input" placeholder="Search..." id="CocktailCode" />
                            </div>




                            <div class="col-lg-4 m--margin-bottom-10-tablet-and-mobile">
                                <label class="font-weight-bold">Search Filters :</label>
                                <div class="m-form__control">
                                    <button class="btn m-btn--pill    btn-primary m-btn m-btn--custom" id="btnSearch" runat="server">
                                        <span>
                                            <i class="la la-search"></i>
                                            <span>Search</span>
                                        </span>
                                    </button>
                                </div>

                            </div>


                        </div>


                    </div>


                    <!--end: Search Form -->

                    <!--begin: Datatable -->
                    <table class="m-datatable" id="html_table" width="100%">
                        <thead>
                            <tr>
                                <th title="Ticket Number" data-field="TicketNo">Ticket Number</th>
                                <%--<th title="Field #2" data-field="Owner">Zone</th>--%>
                                <th title="Location" data-field="Location">Location</th>
                                <%--<th title="Field #4" data-field="CarMake">Sub Location</th>--%>
                                <th title="Category" data-field="Cat">Category</th>
                                <th title="Sub Category" data-field="SubCat">Sub Category</th>
                                <th title="Request Date" data-field="RequestDate">Request Date</th>
                                <th title="Raised By" data-field="RaisedBy">RaisedBy</th>
                                <th title="Down Time" data-field="Down_Time">Down Time</th>
                                <th title="Request Status" data-field="RequestStatus">Request Status</th>
                                <th title="Action Status" data-field="ActionStatus">Action Status</th>
                                <%--<th title="Field #10" data-field="Type">View</th>--%>
                            </tr>
                        </thead>
                        <tbody>

                            <%--<%=bindgrid()%>--%>
                        </tbody>
                    </table>

                    <!--end: Datatable -->

                </div>
            </div>


        </div>

    </div>

</asp:Content>

