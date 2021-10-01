<%@ Page MasterPageFile="~/UpkeepMaster.Master" Language="C#" AutoEventWireup="true" CodeBehind="Add_Inventory_Transaction.aspx.cs" Inherits="Upkeep_v3.Inventory.Add_Inventory_Transaction" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": false,
                "progressBar": false,
                "positionClass": "toast-bottom-center",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "3000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            };

            $('#m_table_1').DataTable({
                responsive: true,
                pagingType: 'full_numbers',
                'fnDrawCallback': function () {
                    init_plugins();
                }
            });

            $('#GridView1').DataTable({
                responsive: true,
                pagingType: 'full_numbers',
                'fnDrawCallback': function () {
                    init_plugins();
                }
            });

            $("input[type='checkbox']").change(function (e) {
                if (!$(this).is(":checked")) {
                    var td = $("td", $(this).closest("tr"));
                    td.css({ "background-color": "#FFF" });
                    $("input[type=number]", td).attr("disabled", "disabled");
                    $("input[type=number]", td).removeAttr("title");

                } else {
                    var td = $("td", $(this).closest("tr"));
                    td.css({ "background-color": "rgba(210, 224, 250, 1)" });
                    $("input[type=number]", td).removeAttr("disabled");
                    $("input[type=number]", td).attr("title", "Press enter to save.");

                }
            });

            //$('input[type="number"]').on("mouseover", function () {
            //    toastr.warning("Press enter to save!");
            //});

            $('input[type="number"]').on('keypress', function (e) {
                var code = e.keyCode || e.which;
                if (code == 13) {
                    var deptID = $('[id*=ddlDepartment] :selected').val();
                    var cnt = 1;
                    if (deptID > 0) {
                        var xml = "";
                        xml += "<DocumentElement>";
                        $('#m_table_1').children('tbody').children('tr').children('td:nth-child(7)').children('input[type="number"]').each(function () {
                            xml += "<Items>";
                            xml += "<ItemId>" + $(this).attr('id') + "</ItemId>";
                            xml += "<ConsumedBalance>" + $(this).val() + "</ConsumedBalance>";
                            xml += "<TransDtl_ID>" + $(this).attr('data-isdata') + "</TransDtl_ID>";
                            xml += "</Items>";
                            cnt = cnt + 1;
                        });
                        xml += "</DocumentElement>";
                        var xmldata = xml;

                        var obj = {};
                        obj.xmldata = xmldata;
                        obj.TransID = $.trim($(this).attr('data-transiddata'));
                        obj.DeptID = $.trim(deptID);

                        $.ajax({
                            type: "POST",
                            url: "Add_Inventory_Transaction.aspx/ConsumedUpdate",
                            data: JSON.stringify(obj),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (response) {
                                e.preventDefault();
                                toastr.success("Successfully Updated..!");
                            },
                            failure: function (response) {
                                e.preventDefault();
                                toastr.error("Successfully Not Updated..!");
                            }
                        });
                    }
                    else {
                        e.preventDefault();
                        toastr.error("Please select Department ..!");
                    }
                }
            });


        });

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
                    <div class="m-portlet__head-tools">
                        <div class="m-portlet__head-tools">
                            <ul class="m-portlet__nav">
                                <li class="m-portlet__nav-item">
                                    <asp:DropDownList Style="width: 350px;margin-right: 280px;" ID="ddlDepartment" class="form-control m-input m-input--pill m-input--solid" runat="server"></asp:DropDownList>
                                </li>
                                <li class="m-portlet__nav-item">
                                    <a href="<%= Page.ResolveClientUrl("~/Inventory/Inventory_Transaction_List.aspx") %>" style="margin-top: 5%;" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                                        <span>
                                            <i class="la la-backward"></i>
                                            <span>Back</span>
                                        </span>
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>




                <div class="m-portlet__body">
                    <asp:HiddenField ID="hdnPrntD" runat="server" ClientIDMode="Static" />
                    <!--end: Search Form -->

                    <!--begin: Datatable -->
                    <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1" width="100%">
                        <thead>
                            <tr>
                                <th id="chkRow1">Select</th>
                                <th>Items</th>
                                <th>Department</th>
                                <th>Category</th>
                                <th>Sub Category</th>
                                <th>Balance</th>
                                <th>Consumed</th>
                            </tr>
                        </thead>
                        <tbody>
                            <%=fetchInvItemListing()%>
                        </tbody>
                    </table>

                    <asp:GridView ID="GridView1" class="table table-striped- table-bordered table-hover table-checkable" runat="server" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="5">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkHeader" runat="server" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtName" runat="server" Text='<% # Eval("Name") %>' Enabled="false"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Country">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCity" runat="server" Text='<% # Eval("Country") %>' Enabled="false"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <!--end: Datatable -->

                </div>
            </div>

            <!-- END EXAMPLE TABLE PORTLET-->
        </div>
    </div>


</asp:Content>
