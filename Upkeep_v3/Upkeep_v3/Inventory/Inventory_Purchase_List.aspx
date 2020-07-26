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

                    <asp:HiddenField ID="hdnPrntD" runat="server" ClientIDMode="Static" />
                    <!--end: Search Form -->

                    <!--begin: Datatable -->
                    <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1" width="100%">
                        <thead>
                            <tr>
                                <%--<th>Select</th>--%>
                                <th>Items</th>
                                <th>Count</th>
                                <th>Cost_rate</th> 
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
</asp:Content>
