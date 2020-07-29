<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Inventory_Purchase_List.aspx.cs" Inherits="Upkeep_v3.Inventory.Inventory_Purchase_List" %>


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

            $(".removeItem").click(function (event) {
                //var row_index = $(this).parent().parent().index();
                //alert(row_index);
                var ConfigID = $(this).attr("data-config-id");
                //alert(ConfigID);
                $("#hdnDeleteID").val("");
                //alert($("#hdnDeleteID").val());
                $("#hdnDeleteID").val(ConfigID);
                // alert($("#hdnDeleteID").val());
                document.getElementById("btnDelete").click();
            });

            $(".editItem").click(function (event) {
                //var row_index = $(this).parent().parent().index();
                //alert(row_index);
                var PurchID = $(this).attr("data-config-id");
                var itemID = $(this).attr("data-items-id");
                var itemName = $(this).attr("data-itemname-id");
                var CountQ = $(this).attr("data-count-id");
                var CostRate = $(this).attr("data-crate-id"); 
                
                $("#hdneditD").val("");
                $("#hdneditD").val(PurchID);
                

                $("#lblPurchaseId").val("");
                $("#lblItemId").val("");
                $("#txtItem").val("");
                $("#txtCount").val("");
                $("#txtCost_rate").val("");

                $("#lblPurchaseId").val(PurchID);
                $("#lblItemId").val(itemID);
                $("#txtItem").val(itemName);
                $("#txtCount").val(CountQ);
                $("#txtCost_rate").val(CostRate);

                //lblPurchaseId
                //lblItemId

                //txtItem
                //txtCount
                //txtCost_rate

                // document.getElementById("btnEdit").click();
                $('#myModal').modal("show");
            });


            $("#btnModalSave").on('click', function (e) {
                e.preventDefault();
                $("#btnModalsubmit").click();
            });

        });



        function SetTarget() {
            var ConfigID = "";
            var ConntP = 0;

            //var ChkAllID = "";

            $('#m_table_1').find('input[type="checkbox"]:checked').each(function () {
                //alert($(this).val())
                if ($(this).val() != "on") {
                    ConfigID = ConfigID + $(this).val() + " ,";
                } else {
                    ChkAllID = "On";
                }
                ConntP = ConntP + 1;
            });

            //if (ChkAllID = "On") {
            //    ConfigID = "";
            //    $('#m_table_1').find('input[type="checkbox"]').each(function () {
            //        //alert($(this).val())
            //        if ($(this).val() != "on") {
            //            ConfigID = ConfigID + $(this).val() + " ,";
            //        }
            //    });
            //}

            $("#hdnPrntD").val("");
            $("#hdnPrntD").val(ConfigID);
            alert($("#hdnPrntD").val());
            alert(ConntP);

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
                            <h3 class="m-portlet__head-text">Purchase	
                            </h3>
                        </div>
                    </div>

                    <div class="col-xl-4 order-1 order-xl-2 m--align-right">
                        <a href="<%= Page.ResolveClientUrl("~/Inventory/Inventory_Purchase_Details.aspx") %>" style="margin-top: 5%;" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                            <span>
                                <i class="la la-plus"></i>
                                <span>Add New</span>
                            </span>
                        </a>
                        <div class="m-separator m-separator--dashed d-xl-none"></div>

                        <%-- 
                           <a href="<%= Page.ResolveClientUrl("#") %>" style="margin-top: 5%;" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill" onclick="SetTarget();">
                            <span>
                                <i class="la la-plus"></i>
                                <span>Add Purchase</span>
                            </span>
                        </a>
                        <div class="m-separator m-separator--dashed d-xl-none"></div>
                        --%>
                    </div>

                </div>
                <div class="m-portlet__body">
                    <!--begin: Search Form -->
                    <asp:HiddenField ID="hdnDeleteID" runat="server" ClientIDMode="Static" />
                    <asp:Button ID="btnDelete" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" ClientIDMode="Static"
                        Style="display: none;" OnClick="btnDelete_Click" Text="Search" />
                    <asp:Button ID="btnEdit" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" ClientIDMode="Static"
                         Style="display: none;"  OnClick="btnEdit_Click" Text="Search" />

                    <asp:HiddenField ID="hdnPrntD" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdneditD" runat="server" ClientIDMode="Static" />
                    <!--end: Search Form -->

                    <!--begin: Datatable -->
                    <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1" width="100%">
                        <thead>
                            <tr>
                                <%--<th>Select</th>--%>
                                <th>Items</th>
                                <th>Count</th>
                                <th>Cost_rate</th>
                                <th>Purchase Date</th>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            <%=fetchInvStockListing()%>
                        </tbody>
                    </table>

                    <!--end: Datatable -->

                </div>
            </div>

            <!-- END EXAMPLE TABLE PORTLET-->
        </div>
    </div>


    <%--</form>--%>


    <!-- Modal -->
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog modal-lg">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 class="modal-title">Purchase Items</h4>
                </div>
                <div class="modal-body">

                    <br />
                    <div id="divModalAssetType" style="display: block;">
                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                            <label class="col-xl-4 col-lg-4 form-control-label">Item :</label>
                            <div class="col-xl-8 col-lg-8">
                                <asp:TextBox ID="txtItem" runat="server" class="form-control" ClientIDMode="Static" ReadOnly="true"></asp:TextBox>

                                <asp:HiddenField ID="lblPurchaseId" runat="server" ClientIDMode="Static" />
                                <asp:HiddenField ID="lblItemId" runat="server" ClientIDMode="Static" />
                            </div>
                        </div>
                        <br />
                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                            <label class="col-xl-4 col-lg-4 form-control-label">Count :</label>
                            <div class="col-xl-8 col-lg-8">
                                <input type="number" min="1" name="txtCount" id="txtCount" class="form-control" clientidmode="Static" runat="server" />
                                <%--<asp:TextBox ID="txtCount" runat="server" class="form-control" ClientIDMode="Static"></asp:TextBox>--%>
                            </div>
                        </div>
                        <br />
                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                            <label class="col-xl-4 col-lg-4 form-control-label">Cost Rate :</label>
                            <div class="col-xl-8 col-lg-8">
                                <input type="number" min="1" name="txtCost_rate" id="txtCost_rate" class="form-control" clientidmode="Static" runat="server" />
                                <%--<asp:TextBox ID="txtCost_rate" runat="server" class="form-control" ClientIDMode="Static"></asp:TextBox>--%>
                            </div>
                        </div>
                    </div>



                </div>
                <div class="modal-footer">
                    <asp:TextBox ID="txtHdn" TextMode="MultiLine" runat="server" ClientIDMode="Static" Width="100%" Style="display: none">
                    </asp:TextBox>
                    <input id="hdnTableBody" runat="server" clientidmode="static" type="hidden" />

                    <button type="button" runat="server" id="btnModalSave" class="btn btn-accent mr-auto" clientidmode="Static"   >Save</button>
                    <button type="submit" runat="server" id="btnModalsubmit" onserverclick="btnModalsubmit_Click" class="btn btn-accent mr-auto" style="display: none" clientidmode="Static">Save</button>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>


</asp:Content>
