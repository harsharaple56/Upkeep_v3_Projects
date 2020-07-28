<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Inventory_Stock_List.aspx.cs" Inherits="Upkeep_v3.Inventory.Inventory_Stock_List" %>

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


            $("#btnModalSave").on('click', function (e) {
                e.preventDefault();
                $('#txtHdn').val("");
                $("#btnModalsubmit").click();
                return false;
            });



            $("#ddlCategory").on('change', function (e) {
                var FilterVal = $(this).val();
                //alert(FilterVal);
                $("#ddlSubCategory").val(0);

                $("#ddlSubCategory option").each(function () {
                    if ($(this).attr('data-isMulti') == FilterVal) {
                        $(this).show();
                    }
                    else {
                        if ($(this).val() == 0) {
                            $(this).show();
                        }
                        else {
                            $(this).hide();
                        }
                    }
                });
            });

        });



        function SetTarget() {
            var ConfigID = "";
            var ConntP = 0;

            ////var ChkAllID = "";

            //$('#m_table_1').find('input[type="checkbox"]:checked').each(function () {
            //    //alert($(this).val())
            //    if ($(this).val() != "on") {
            //        ConfigID = ConfigID + $(this).val() + " ,";
            //    } else {
            //        ChkAllID = "On";
            //    }
            //    ConntP = ConntP + 1;
            //}); 

            //$("#hdnPrntD").val("");
            //$("#hdnPrntD").val(ConfigID);
            //alert($("#hdnPrntD").val());
            //alert(ConntP);

            // document.forms[0].target = "_blank";

            //document.getElementById("btnPopup").click();

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
                            <h3 class="m-portlet__head-text">Stock	
                            </h3>
                        </div>
                    </div>

                    <div class="col-xl-4 order-1 order-xl-2 m--align-right">

                        <a href="#myModal" data-toggle="modal" style="margin-top: 5%;" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill"
                            onclick="return SetTarget();">
                            <span>
                                <i class="la la-plus"></i>
                                <span>Add New Item</span>
                            </span>
                        </a>
                        <div class="m-separator m-separator--dashed d-xl-none"></div>

                        <a href="<%= Page.ResolveClientUrl("~/Inventory/Inventory_Stock_Detail.aspx") %>" style="margin-top: 5%; display: none;" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                            <span>
                                <i class="la la-plus"></i>
                                <span>Add New Stock</span>
                            </span>
                        </a>
                        <div class="m-separator m-separator--dashed d-xl-none"></div>

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
                                <th>Department</th>
                                <th>Category</th>
                                <th>Sub_Category</th>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                <th>Balance</th>
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

    <%--  <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
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
                    <h4 class="modal-title">Add Items</h4>
                </div>
                <div class="modal-body">
                    <div id="divModalAssetType" style="display: block;">

                        <br />
                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                            <label class="col-xl-4 col-lg-4 form-control-label"><span style="color: red;">*</span>Category :</label>
                            <div class="col-xl-8 col-lg-8">
                                <asp:DropDownList ID="ddlCategory" class="form-control m-input" runat="server" ClientIDMode="Static">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlCategory" Visible="true" 
                                    Display="Dynamic" ValidationGroup="validateStock" ForeColor="Red" InitialValue="0"
                                    ErrorMessage="Please select Category"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                            <label class="col-xl-4 col-lg-4 form-control-label"><span style="color: red;">*</span>Sub Category :</label>
                            <div class="col-xl-8 col-lg-8">
                                <asp:DropDownList ID="ddlSubCategory" class="form-control m-input" runat="server"  ClientIDMode="Static">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSubCategory" Visible="true"
                                    Display="Dynamic" ValidationGroup="validateStock" ForeColor="Red" InitialValue="0"
                                    ErrorMessage="Please select Sub Category"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <br />
                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                            <label class="col-xl-4 col-lg-4 form-control-label">Item :</label>
                            <div class="col-xl-8 col-lg-8">
                                <asp:TextBox ID="txtItem" runat="server" class="form-control" ClientIDMode="Static"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtItem" Visible="true"
                                    Display="Dynamic" ValidationGroup="validateStock" ForeColor="Red" InitialValue=""
                                    ErrorMessage="Please Enter Item Name"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                            <label class="col-xl-4 col-lg-4 form-control-label">Opening Stock :</label>
                            <div class="col-xl-8 col-lg-8">
                                <input type="number" min="1" name="txtOpening" id="txtOpening" class="form-control" clientidmode="Static" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtOpening" Visible="true"
                                    Display="Dynamic" ValidationGroup="validateStock" ForeColor="Red" InitialValue=""
                                    ErrorMessage="Please Enter Opening Stock"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                            <label class="col-xl-4 col-lg-4 form-control-label">Optinum :</label>
                            <div class="col-xl-8 col-lg-8">
                                <input type="number" min="1" name="txtOptinum" id="txtOptinum" class="form-control" clientidmode="Static" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtOptinum" Visible="true"
                                    Display="Dynamic" ValidationGroup="validateStock" ForeColor="Red" InitialValue=""
                                    ErrorMessage="Please Enter Optinum"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                            <label class="col-xl-4 col-lg-4 form-control-label">Re Order :</label>
                            <div class="col-xl-8 col-lg-8">
                                <input type="number" min="1" name="txtReOrder" id="txtReOrder" class="form-control" clientidmode="Static" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtReOrder" Visible="true"
                                    Display="Dynamic" ValidationGroup="validateStock" ForeColor="Red" InitialValue=""
                                    ErrorMessage="Please Enter Re-Order"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                            <label class="col-xl-4 col-lg-4 form-control-label">Base :</label>
                            <div class="col-xl-8 col-lg-8">
                                <input type="number" min="1" name="txtBase" id="txtBase" class="form-control" clientidmode="Static" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtBase" Visible="true"
                                    Display="Dynamic" ValidationGroup="validateStock" ForeColor="Red" InitialValue=""
                                    ErrorMessage="Please Enter Base value"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <br />
                        <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                            <label class="col-xl-4 col-lg-4 form-control-label">Cost Rate :</label>
                            <div class="col-xl-8 col-lg-8">
                                <input type="number" min="1" name="txtCost_rate" id="txtCost_rate" class="form-control" clientidmode="Static" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCost_rate" Visible="true"
                                    Display="Dynamic" ValidationGroup="validateStock" ForeColor="Red" InitialValue=""
                                    ErrorMessage="Please Enter Cost Rate"></asp:RequiredFieldValidator>
                            </div>
                        </div>
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
                    </div>

                </div>
                <div class="modal-footer">
                    <asp:TextBox ID="txtHdn" TextMode="MultiLine" runat="server" ClientIDMode="Static" Width="100%" Style="display: none"></asp:TextBox>
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
