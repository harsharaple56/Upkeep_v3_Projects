<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Brand_Opening_Stock.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Setup.Brand_Opening_Stock" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>

    <style type="text/css">
        .modalBackground {
            background-color: grey;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            /*background-color: #fff;
            border: 3px solid #ccc;*/
            padding: 10px;
            width: 300px;
        }
    </style>


    <script type="text/javascript">
        $(document).ready(function () {
            //$('#btnedit').click(function () {
            $("#btnedit").click(function () {
                //alert('edit');
                $('#Add_Category').modal('show');

            });

            <%--$("#btnSave").click(function () {
                debugger;
                var grid = document.getElementById("<%= grdCatagLinkUp.ClientID%>");

                for (var i = 0; i < grid.rows.length - 1; i++) {

                    //var chkSelct = $('input[type="checkbox"][id*=chkSelct]').checked;
                    //alert(chkSelct);
                    var checkBoxes = grid.getElementsByTagName("INPUT");
                    //if(chkSelct)
                    //Loop through the CheckBoxes.
                    for (var i = 0; i < checkBoxes.length; i++) {
                        if (checkBoxes[i].checked) {
                            var txtalias = $("input[id*=txtalias]")
                            if (txtalias[i].value != '') {
                                alert(txtalias[i].value);
                            }
                        }
                    }
                }
            });--%>

        });

        function openModal() {
            //alert('Hii');
            $('#Add_Category').modal('show');
        }




    </script>

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
                                <h3 class="m-portlet__head-text">Add Your Brand Opening Stock	
                                </h3>
                            </div>
                        </div>
                        <div class="m-portlet__head-tools">
                            <div class="m-portlet__head-tools">
                                <ul class="m-portlet__nav">
                                    
                                    <li class="m-portlet__nav-item">
                                        <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Setup/Add_Brand_Opening_Stock.aspx") %>" 
                                            class="btn btn-success m-btn m-btn--custom m-btn--pill m-btn--icon m-btn--air">
                                            <span>
                                                <i class="flaticon-add"></i>
                                                <span>Add Brand Opening</span>
                                            </span>
                                        </a>
                                    </li>

                                </ul>

                                <ul class="m-portlet__nav">
                                    <li class="m-portlet__nav-item m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover" aria-expanded="true">

                                        <a href="#" class="btn m-btn--pill btn-outline-focus m-btn--icon m-btn--air">
                                            <span>
                                                <i class="fa fa-database" aria-hidden="true"></i>
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
                                                                <span class="m-nav__section-text">Export Data Format</span>
                                                            </li>
                                                            <hr />

                                                           <li class="m-nav__item">
                                                                <a class="m-nav__link" id="export_excel" runat="server" onserverclick="btnExport_Click">
                                                                    <i class="m-nav__link-icon la la-file-excel-o" style="font-size: 2rem"></i>
                                                                    <span class="m-nav__link-text">Excel <b>( .xls )</b></span>
                                                                </a>
                                                            </li>

                                                            <li class="m-nav__item">
                                                                <a class="m-nav__link" id="export_pdf" runat="server" onserverclick="btnPdf_Click">
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

                                <ul class="m-portlet__nav">

                                    <li class="m-portlet__nav-item">
                                        <a href="#" class="btn m-btn--pill btn-outline-focus m-btn--icon m-btn--air">
                                            <span>
                                                <i class="fa fa-file-import"></i>
                                                <span>Import Data</span>
                                            </span>
                                        </a>
                                    </li>
                                    <li class="m-portlet__nav-item">
                                        <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Setup/Setup.aspx") %>" 
                                            class="btn m-btn--pill btn-outline-focus m-btn--icon m-btn--air">
                                            <span>
                                                <i class="la la-arrow-left"></i>
                                                <span>Back</span>
                                            </span>
                                        </a>
                                    </li>
                                </ul>

                            </div>

                        </div>

                    </div>

                    <div class="m-portlet__body">

                        <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">
                            <thead>
                                <tr>
                                    <th>Category</th>
                                    <th>Brand Name</th>
                                    <th>Size</th>
                                    <th>Bottle Qty</th>
                                    <th>SPeg Qty</th>
                                    <th>Bottle Rate</th>
                                    <th>Base Qty</th>
                                    <th>Re-Order Level</th>
                                    <th>Optimum Level</th>
                                    <th>Actions</th>
                                </tr>
                            </thead>

                           <tbody>
                                <%=BindBrandOpening()%>
                            </tbody>
                        </table>

                    </div>
                </div>
            </div>
        </div>

    </div>



</asp:Content>
