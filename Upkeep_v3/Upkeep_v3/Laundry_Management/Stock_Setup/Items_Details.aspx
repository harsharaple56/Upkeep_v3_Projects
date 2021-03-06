<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Items_Details.aspx.cs" Inherits="Upkeep_v3.Laundry_Management.Stock.Stock_Details" %>

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
            //alert(resultx);
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
            //alert($("#hdnPrntD").val());
            //alert(ConntP);
            document.getElementById("btnPopup").click();
            // document.forms[0].target = "_blank";
        };

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="m-portlet m-portlet--mobile">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <h3 class="m-portlet__head-text">Laundry Item Details
                            </h3>
                        </div>
                    </div>

                    <div class="col-xl-4 order-1 order-xl-2 m--align-right">
                        <a href="<%= Page.ResolveClientUrl("~/Laundry_Management/Stock_Setup/Setup.aspx") %>" style="margin-top: 5%;" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                            <span>
                                <i class="la la-backward"></i>
                                <span>Back</span>
                            </span>
                        </a>
                        <div class="m-separator m-separator--dashed d-xl-none"></div>

                        <a href="#myModal" data-toggle="modal" style="margin-top: 5%;" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill"
                            onclick="SetTarget();">
                            <span>
                                <i class="la la-plus"></i>
                                <span>Add New Item</span>
                            </span>
                        </a>
                        <div class="m-separator m-separator--dashed d-xl-none"></div>
                    </div>

                </div>
                <div class="m-portlet__body">
                    <!--begin: Search Form -->
                    <%--  <asp:HiddenField ID="hdnDeleteID" runat="server" ClientIDMode="Static" />
                    <asp:Button ID="btnDelete" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" ClientIDMode="Static"
                        Style="display: none;" OnClick="btnDelete_Click" Text="Search" />--%>

                    <asp:HiddenField ID="hdnPrntD" runat="server" ClientIDMode="Static" />
                    <!--end: Search Form -->

                    <!--begin: Datatable -->
                    <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1" width="100%">
                        <thead>
                            <tr>
                                <%--                                <th>Select</th>--%>
                                <th style="display: none">Item ID</th>
                                <th>Item Name</th>
                                <%--                                <th>Available Stock</th>
                                <th>Department</th>--%>
                                <th>Category</th>
                                <th>Sub Category</th>
                                <th>Action</th>

                                <%--                                <asp:HiddenField ID="HiddenField1" runat="server" />--%>
                            </tr>
                        </thead>
                        <tbody>

                            <%=Fetch_Stock_Details()%>
                        </tbody>
                    </table>

                    <!--end: Datatable -->

                </div>
            </div>

            <!-- END EXAMPLE TABLE PORTLET-->
        </div>
    </div>


    <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
    <asp:UpdatePanel runat="server" style="width: 100%;">
        <%--<Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnPopup" EventName="Click" />
        </Triggers>--%>
        <ContentTemplate>

            <asp:Button ID="btnPopup" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" ClientIDMode="Static"
                Style="display: none;" OnClick="btnPopup_Click" Text="Search" />

        </ContentTemplate>
    </asp:UpdatePanel>
    <!-- Modal -->
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog modal-sm">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 class="modal-title">Add New Item</h4>
                </div>
                <div class="modal-body">

                    <div class="row">
                        <div class="col-xl-12">
                            <div class="form-group m-form__group row">
                                <label for="message-text" class="form-control-label font-weight-bold">Item Name:</label>
                                <asp:TextBox ID="txtItem_Desc" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="col-xl-12">
                                    <div class="form-group m-form__group row">
                                        <label for="message-text" class="form-control-label font-weight-bold">Assign Category:</label>
                                        <asp:DropDownList ID="ddl_Category" AutoPostBack="true" OnSelectedIndexChanged="ddl_SubCategory_SelectedIndexChanged" class="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-xl-12">
                                    <div class="form-group m-form__group row">
                                        <label for="message-text" class="form-control-label font-weight-bold">Assign Sub-Category :</label>
                                        <asp:DropDownList ID="ddl_SubCategory" class="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <asp:Label ID="lblStockErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                </div>
                <div class="modal-footer">
                    <asp:TextBox ID="txtHdn" TextMode="MultiLine" runat="server" ClientIDMode="Static" Width="100%" Style="display: none"></asp:TextBox>

                    <button type="button" runat="server" id="btnModalSave" class="btn btn-accent mr-auto" onserverclick="btnModalsubmit_Click" clientidmode="Static">Save</button>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>






</asp:Content>
