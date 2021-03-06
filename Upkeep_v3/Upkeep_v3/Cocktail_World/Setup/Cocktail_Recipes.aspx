<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Cocktail_Recipes.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Setup.Cocktail_Recipes" %>


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
        });
    </script>


    <div runat="server">
        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
        <div class="m-grid__item m-grid__item--fluid">
            <div class="m-content">
                <div class="m-portlet m-portlet--mobile">

                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Cocktail Recipes	
                                </h3>
                            </div>
                        </div>
                        <div class="m-portlet__head-tools">
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
                                        <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Setup/Add_Cocktail_Recipes.aspx") %>"
                                            class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                                            <span>
                                                <i class="flaticon-add"></i>
                                                <span>Add Cocktail Recipes</span>
                                            </span>
                                        </a>
                                    </li>

                                </ul>

                                <ul class="m-portlet__nav">
                                    <li class="m-portlet__nav-item m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover" aria-expanded="true">

                                        <a href="#" class="btn m-btn--pill    btn-primary m-btn m-btn--custom">
                                            <span>
                                                <i class="fa flaticon-grid-menu"></i>
                                                <span>Import & Export Data</span>
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
                                                                <a class="m-nav__link" href="#" runat="server" onserverclick="btnExportExcel_Click">
                                                                    <i class="m-nav__link-icon la la-file-excel-o" style="font-size: 2rem"></i>
                                                                    <span class="m-nav__link-text">Excel <b>( .xls )</b></span>
                                                                </a>
                                                            </li>

                                                            <li class="m-nav__item">
                                                                <a class="m-nav__link" href="#" runat="server" onserverclick="btnExportPdf_Click" >
                                                                    <i class="m-nav__link-icon la la-file-pdf-o" style="font-size: 2rem"></i>
                                                                    <span class="m-nav__link-text">Pdf  <b>( .pdf )</b></span>
                                                                </a>
                                                            </li>

                                                        </ul>
                                                        <br />
                                                        <ul class="m-nav">
                                                            <li class="m-nav__section m-nav__section--first">
                                                                <span class="m-nav__section-text"><i class="fa fa-file-import"></i>Import Data</span>
                                                            </li>
                                                            <hr />
                                                            <li class="m-nav__item">
                                                                <a class="m-nav__link" id="A11" runat="server">
                                                                    <i class="m-nav__link-icon la la-file-excel-o" style="font-size: 2rem"></i>
                                                                    <span class="m-nav__link-text">Import <b>( .xls )</b></span>
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

                    </div>

                    <div class="m-portlet__body">

                        <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">
                            <thead>
                                <tr>
                                    <th>License Name</th>
                                    <th>Cocktail Name</th>
                                    <th>Rate</th>
                                    <th>Brand Name</th>
                                    <th>Size</th>
                                    <th>Peg / ML</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%=BindCocktailRecipes()%>
                            </tbody>
                        </table>

                    </div>
                </div>
            </div>
        </div>

    </div>



</asp:Content>
