<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Add_Dept_Transaction.aspx.cs" Inherits="Upkeep_v3.Laundry_Management.Transactions.Add_Dept_Transaction" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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

            $('#m_table_2').DataTable({
                responsive: true,
                pagingType: 'full_numbers',
                'fnDrawCallback': function () {
                    init_plugins();
                }
            });
            //$(".removeItem").click(function (event) {
            //    //var row_index = $(this).parent().parent().index();
            //    //alert(row_index);
            //    var ConfigID = $(this).attr("data-config-id");
            //    //alert(ConfigID);
            //    $("#hdnDeleteID").val("");
            //    //alert($("#hdnDeleteID").val());
            //    $("#hdnDeleteID").val(ConfigID);
            //    // alert($("#hdnDeleteID").val());
            //    document.getElementById("btnDelete").click();
            //});


            $("#btnModalSave").on('click', function (e) {
                e.preventDefault();
                $('#txtHdn').val("");

                var RwsCnt = $("#m_table_2 tr").length;
                //alert(RwsCnt);
                var cnt = 1;

                if (!CompareTargetVal()) {
                    return false;
                }


                var xml = "";
                xml += "<DocumentElement>";
                $('#m_table_2').children('tbody').children('tr').children('td:nth-child(4)').children('input[type="number"]').each(function () {
                    // alert($(this).attr('id')); 
                    //alert($(this).val()); 
                    xml += "<Items>";
                    xml += "<ItemId>" + $(this).attr('name') + "</ItemId>";

                    xml += "<ConsumedBalance>" + $(this).val() + "</ConsumedBalance>";
                    xml += "</Items>";
                    cnt = cnt + 1;
                });
                xml += "</DocumentElement>";
                $('#txtHdn').val(xml);
                //alert(xml);
                //alert($('#txtHdn').val());  

                $("#btnModalsubmit").click();

            });
        });


        function CompareTargetVal() {
            var resultx = 0;
            $('#m_table_2').children('tbody').children('tr').each(function () {
                if ($(this).children('td:nth-child(5)').children('input[type="number"]').val() > 0) {
                    if (($(this).children('td:nth-child(4)').children('input[type="number"]').val() > $(this).children('td:nth-child(5)').children('input[type="number"]').val())) {
                        alert("Consumption cannot be more then balance");
                        resultx = 1;
                    }
                    if ($(this).children('td:nth-child(4)').children('input[type="number"]').val() == 0) {
                        alert("Consumption cannot be 0");
                        resultx = 1;
                    }

                    if (resultx == 1) {
                        return false;
                    }
                }
                // return resultx;
            });
            alert(resultx);
            return true;
        }

        function SetTarget() {
            var ConfigID = "";
            var ConntP = 0;

            $('#m_table_1').find('input[type="checkbox"]:checked').each(function () {
                //alert($(this).val())
                if ($(this).val() != "on") {
                    ConfigID = ConfigID + $(this).val() + " ,";
                } else {
                    ChkAllID = "On";
                }
                ConntP = ConntP + 1;
            });
            $("#hdnPrntD").val("");
            $("#hdnPrntD").val(ConfigID);
            alert($("#hdnPrntD").val());
            alert(ConntP);
            document.getElementById("btnPopup").click();
            // document.forms[0].target = "_blank";
        };

    </script>

    <style type="text/css">
        .auto-style1 {
            height: 21px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content" style="padding: 10px 10px;">
            <div class="m-portlet m-portlet--mobile">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <h3 class="m-portlet__head-text">Add New Department transaction
                            </h3>
                        </div>
                    </div>

                    <div class="col-xl-4 order-1 order-xl-2 m--align-right">
                        <a href="<%= Page.ResolveClientUrl("~/Laundry_Management/Transactions/Department_Transactions.aspx") %>" style="margin-top: 5%;" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                            <span>
                                <i class="la la-backward"></i>
                                <span>Back</span>
                            </span>
                        </a>
                        <div class="m-separator m-separator--dashed d-xl-none"></div>

                        <a href="#myModal" data-toggle="modal" style="margin-top: 5%;" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                            <span>
                                <i class="la la-plus"></i>
                                <span>Save Transaction</span>
                            </span>
                        </a>
                        <div class="m-separator m-separator--dashed d-xl-none"></div>
                    </div>

                </div>

                <div class="m-portlet__body" style="padding: 2.2rem 2.2rem;">

                                        <div class="form-group m-form__group row">
                                            <label for="example-text-input" class="col-3 col-form-label">Department Executive Name</label>
                                            <div class="col-3">
                                                <input class="form-control m-input" type="text" value="Artisanal kale" id="example-text-input">
                                            </div>
                                            <label for="example-text-input" class="col-3 col-form-label">Department Executive Contact</label>
                                            <div class="col-3">
                                                <input class="form-control m-input" type="text" value="Artisanal kale" id="example-text-input">
                                            </div>
                                        </div>
                                        <div class="form-group m-form__group row">
                                            
                                                <div class="dropdown bootstrap-select form-control m-bootstrap-select m_" style="width: 200px;">
                                                    <select name="ctl00$ContentPlaceHolder1$ddlEventName" id="ddlEventName" class="form-control m-bootstrap-select m_selectpicker" title="Select Event" data-live-search="true" data-size="3" data-style="btn btn-accent m-btn--pill" data-width="400px" tabindex="-98">
                                                        <option class="bs-title-option" value="">Select Event</option>
                                                        <option value="0">--Select--</option>
                                                        <option value="67">Test Feedback Form 2</option>
                                                        <option selected="selected" value="64">Feedback Form</option>

                                                    </select>
                                                    <button type="button" class="dropdown-toggle btn m-btn--pill" data-toggle="dropdown" role="button" data-id="ddlEventName" title="Feedback Form" aria-expanded="false">
                                                        <div class="filter-option">
                                                            <div class="filter-option-inner">Feedback Form</div>
                                                        </div>
                                                        &nbsp;<span class="bs-caret"><span class="caret"></span></span></button>
                                                    <div class="dropdown-menu" role="combobox" x-placement="top-start" style="overflow: hidden; position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, -143px, 0px);">
                                                        <div class="bs-searchbox">
                                                            <input type="text" class="form-control" autocomplete="off" role="textbox" aria-label="Search">
                                                        </div>
                                                        <div class="inner show" role="listbox" aria-expanded="false" tabindex="-1" style="overflow-y: auto;">
                                                            <ul class="dropdown-menu inner show">
                                                                <li><a role="option" class="dropdown-item" aria-disabled="false" tabindex="0" aria-selected="false"><span class=" bs-ok-default check-mark"></span><span class="text">--Select--</span></a></li>
                                                                <li><a role="option" class="dropdown-item" aria-disabled="false" tabindex="0" aria-selected="false"><span class=" bs-ok-default check-mark"></span><span class="text">Test Feedback Form 2</span></a></li>
                                                                <li class="selected active"><a role="option" class="dropdown-item selected active" aria-disabled="false" tabindex="0" aria-selected="true"><span class=" bs-ok-default check-mark"></span><span class="text">Feedback Form</span></a></li>
                                                            </ul>
                                                        </div>
                                                    </div>
                                                </div>
                                            <div class="col-3">
                                                <a href="#" class="btn btn-danger m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                                                    <span>
                                                        <i class="la la-plus"></i>
                                                        <span>Add Item</span>
                                                    </span>
                                                </a>
                                            </div>
                                        </div>

                                            

                </div>


                <div class="m-portlet__body">

                    <asp:HiddenField ID="hdnPrntD" runat="server" ClientIDMode="Static" />
                    <!--end: Search Form -->

                    <!--begin: Datatable -->
                    <table class="table table-bordered table-hover" id="m_table_1" width="100%">
                        <thead>
                            <tr>
                                <th>Item Name</th>
                                <th>Opening Balance</th>
                                <th>Soiled Collected</th>
                                <th>Cleaned Given</th>
                                <th>Damaged</th>
                                <th>Actions</th>


                                <%--                                <asp:HiddenField ID="HiddenField1" runat="server" />--%>
                            </tr>
                        </thead>

                        <tbody>
                            <%-- <%=Fetch_ItemStock_Details()%>--%>
                        </tbody>
                    </table>

                    <!--end: Datatable -->

                </div>
            </div>

            <!-- END EXAMPLE TABLE PORTLET-->
        </div>
    </div>

    <!-- Modal -->



</asp:Content>
