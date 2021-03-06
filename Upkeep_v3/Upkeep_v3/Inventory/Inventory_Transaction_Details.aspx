<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Inventory_Transaction_Details.aspx.cs" Inherits="Upkeep_v3.Inventory.Inventory_Transaction_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>--%>
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
                    xml += "<TransDtl_ID>" + $(this).attr('data-isdata') + "</TransDtl_ID>";

                    xml += "</Items>";
                    cnt = cnt + 1;
                });
                xml += "</DocumentElement>";
                $('#txtHdn').val(xml);
                //alert(xml);
                //alert($('#txtHdn').val());  

                $("#btnModalsubmit").click();

            });

            $("#btnShowPopup").click(function () {
                //alert("Apple");
                $("#myModal").modal("show");

                $("#hdnPrntD").val("");
                $("#hdnIsSubmitted").val("");
            });
            //alert('xxxx');
            //alert($("#hdnTableBody").val());
            if ($("#hdnTableBody").val() != "") {
                //alert("Banana");
                BindTable();
            }
        });


        function CompareTargetVal() {
            var resultx = 0;
            $('#m_table_2').children('tbody').children('tr').each(function () {
                if ($(this).children('td:nth-child(5)').children('input[type="number"]').val() > 0) {
                    if ((parseInt($(this).children('td:nth-child(4)').children('input[type="number"]').val()) > parseInt($(this).children('td:nth-child(5)').children('input[type="number"]').val()))) {

                        alert("Consumption cannot be more then balance");
                        resultx = 1;
                    }
                    //if ($(this).children('td:nth-child(4)').children('input[type="number"]').val() == 0) {
                    //    alert("Consumption cannot be 0");
                    //    resultx = 1;
                    //}

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
            return true;
            // document.getElementById("btnPopup").click();

        };

        function BindTable() {
            //alert("fdfsadds")

            $("#btnShowPopup").trigger("click");

            //$('#hdnOpenModal').click(); 
            $('#m_table_2 tbody').empty();

            $('#m_table_2 tbody').append($("#hdnTableBody").val());
            // alert($("#hdnTableBody").val());

            // $('#myModal').dialog('open');  
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="m-portlet m-portlet--mobile">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <h3 class="m-portlet__head-text">Transaction Detail
                            </h3>
                        </div>
                    </div>
                    <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>

                    <div class="col-xl-4 order-1 order-xl-2 m--align-right">
                        <a href="<%= Page.ResolveClientUrl("~/Inventory/Inventory_Transaction_List.aspx") %>" style="margin-top: 5%;" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                            <span>
                                <i class="la la-backward"></i>
                                <span>Back</span>
                            </span>
                        </a>
                        <div class="m-separator m-separator--dashed d-xl-none"></div>

                       <%-- <a href="#" style="margin-top: 5%;" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill"
                            onserverclick="btnPopup_Click" runat="server" onclick="return SetTarget();">
                            <span>
                                <i class="la la-plus"></i>
                                <span>Submit</span>
                            </span>
                        </a>--%>
                        <div class="m-separator m-separator--dashed d-xl-none"></div>

                        <%--  
                        <div class="m-separator m-separator--dashed d-xl-none"></div>
                        --%>
                        <input type="button" id="btnShowPopup" value="Show Popup" class="btn btn-info btn-lg" style="display: none;" />

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
                                <th>Items</th>
                                <th>Department</th>
                                <th>Category</th>
                                <th>Sub Category</th>
                                <th>Balance</th>
                                <th>Consumed</th>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                            </tr>
                        </thead>
                        <tbody>
                            <%=fetchInvItemListing()%>
                        </tbody>
                    </table>

                    <!--end: Datatable -->

                </div>
            </div>

            <!-- END EXAMPLE TABLE PORTLET-->
        </div>
    </div>


    <%--    <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
    <asp:UpdatePanel runat="server" style="width: 100%;">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnPopup" EventName="Click" />
        </Triggers> 
        <ContentTemplate>

            <asp:Button ID="btnPopup" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" ClientIDMode="Static"
                Style="display: none;" OnClick="btnPopup_Click" Text="Search" />

        </ContentTemplate>
    </asp:UpdatePanel>--%>
    <!-- Modal -->
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog modal-lg">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 class="modal-title">Selected Items</h4>
                </div>
                <div class="modal-body">

                    <br />
                    <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                        <label class="col-xl-4 col-lg-4 form-control-label"><span style="color: red;">*</span>Department :</label>
                        <div class="col-xl-8 col-lg-8">
                            <asp:DropDownList ID="ddlDepartment" class="form-control m-input" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlDepartment" Visible="true"
                                Display="Dynamic" ValidationGroup="validateStock" ForeColor="Red" InitialValue="0"
                                ErrorMessage="Please select Department"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />

                    <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_2">
                        <thead>
                            <tr>
                                <th>Sr no.</th>
                                <th>Items</th>
                                <th>Opening Stock</th>
                                <th>Consumed</th>
                                <th>Balance</th>
                            </tr>
                        </thead>
                        <tbody>
                            <%--<%=fetchInvItemSelectedListing()%>--%>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <asp:TextBox ID="txtHdn" TextMode="MultiLine" runat="server" ClientIDMode="Static" Width="100%" Style="display: none"></asp:TextBox>

                    <input id="hdnTableBody" runat="server" clientidmode="static" type="hidden" />

                    <button type="button" runat="server" id="btnModalSave" class="btn btn-accent mr-auto" clientidmode="Static">Save</button>
                    <button type="button" runat="server" id="btnModalsubmit" onserverclick="btnModalsubmit_Click" class="btn btn-accent mr-auto" style="display: none" clientidmode="Static"
                        validationgroup="validateStock" causesvalidation="true">
                        Save</button>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>


</asp:Content>
