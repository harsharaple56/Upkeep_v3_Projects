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

        function functionCalculation() {
            //debugger;
            var Opening = parseInt($("#txtOpening").val());
            var soilded_collected = parseInt($("#txtSoiledCollected").val());
            var cleaned_given = parseInt($("#txtCleanedGiven").val());
            var damaged = parseInt($("#txtDamaged").val());
            var closing = parseInt($("#txtClosing").val());

            var closing_value = (soilded_collected - damaged) - cleaned_given + Opening;

            //$("#txtClosing").val(closing_value);
            //alert(soilded);

            //$("[id*=gvItemDetails]").find("[id*=txtSoiledCollected]").keyup(function () {
            //    //Reference the GridView Row.
            //    var row = $(this).closest("tr");

            //    //Determine the Row Index.
            //    var message = "Row Index: " + (row[0].rowIndex - 1);

            //    //Read values from Cells.
            //    message += "\nCustomer Id: " + row.find("td").eq(0).html();
            //    //message += "\nName: " + row.find("td").eq(1).html();

            //    ////Reference the TextBox and read value.
            //    //message += "\nCountry: " + row.find("td").eq(2).find("input").eq(0).val();

            //    var Opening1 = parseInt(row.find("td").eq(2).find("input").eq(0).val());
            //    alert(Opening1);
            //    row.find("td").eq(6).find("input").eq(0).val(Opening1);

            //    //Display the data using JavaScript Alert Message Box.
            //    alert(message);
            //    return false;
            //});


        }

    </script>

    <script type="text/javascript">
        $(function () {
            $("[id*=gvItemDetails]").find("[id*=txtSoiledCollected]").keyup(function () {
                //Reference the GridView Row.
                var row = $(this).closest("tr");

                var Opening = parseInt(row.find("td").eq(1).html());

                var soilded_collected = parseInt(row.find("td").eq(2).find("input").eq(0).val());
                var cleaned_given = parseInt(row.find("td").eq(3).find("input").eq(0).val());
                var damaged = parseInt(row.find("td").eq(4).find("input").eq(0).val());

                var closing_value = (soilded_collected - damaged) - cleaned_given + Opening;

                row.find("td").eq(5).find("input").eq(0).val(closing_value);

                return false;
            });

            $("[id*=gvItemDetails]").find("[id*=txtCleanedGiven]").keyup(function () {
                //Reference the GridView Row.
                var row = $(this).closest("tr");

                var Opening = parseInt(row.find("td").eq(1).html());

                var soilded_collected = parseInt(row.find("td").eq(2).find("input").eq(0).val());
                var cleaned_given = parseInt(row.find("td").eq(3).find("input").eq(0).val());
                var damaged = parseInt(row.find("td").eq(4).find("input").eq(0).val());

                var closing_value = (soilded_collected - damaged) - cleaned_given + Opening;

                row.find("td").eq(5).find("input").eq(0).val(closing_value);

                return false;
            });

            $("[id*=gvItemDetails]").find("[id*=txtDamaged]").keyup(function () {
                //Reference the GridView Row.
                var row = $(this).closest("tr");

                var Opening = parseInt(row.find("td").eq(1).html());

                var soilded_collected = parseInt(row.find("td").eq(2).find("input").eq(0).val());
                var cleaned_given = parseInt(row.find("td").eq(3).find("input").eq(0).val());
                var damaged = parseInt(row.find("td").eq(4).find("input").eq(0).val());

                var closing_value = (soilded_collected - damaged) - cleaned_given + Opening;

                row.find("td").eq(5).find("input").eq(0).val(closing_value);

                return false;
            });

        });
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

                        <%--<a href="#myModal" data-toggle="modal" style="margin-top: 5%;" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                            <span>
                                <i class="la la-plus"></i>
                                <span>Save Transaction</span>
                            </span>
                        </a>--%>
                        <div class="m-separator m-separator--dashed d-xl-none"></div>
                    </div>

                </div>

                <div class="m-portlet__body" style="padding: 2.2rem 2.2rem 0rem 2.2rem;">

                    <div class="form-group m-form__group row">
                        <label for="example-text-input" class="col-3 col-form-label">Department Executive Name</label>
                        <div class="col-3">
                            <asp:TextBox class="form-control m-input" ID="txtDept_ExecutiveName" runat="server"></asp:TextBox>
                        </div>
                        <label for="example-text-input" class="col-3 col-form-label">Department Executive Contact</label>
                        <div class="col-3">
                            <asp:TextBox class="form-control m-input" ID="txtDept_ExecutiveContactNo" TextMode="Number" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group m-form__group row" style="margin-bottom: 0rem;">

                        <div class="col-3">
                            <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control" ToolTip="Select Department" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                        </div>

                        <%--<div class="col-3">
                            <asp:DropDownList ID="ddlItems" runat="server" CssClass="form-control" ToolTip="Select Item"></asp:DropDownList>

                        </div>--%>

                        <%--<div class="dropdown bootstrap-select form-control m-bootstrap-select m_" style="width: 200px;">
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
                        </div>--%>



                        <div class="col-2">
                            <a href="#" class="btn btn-danger m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill" data-toggle="modal" data-target="#m_modal_1">
                                <span>
                                    <i class="la la-plus"></i>
                                    <span>Add Item</span>
                                </span>
                            </a>
                        </div>
                        <div class="col-7">
                            <div class="alert m-alert m-alert--default" role="alert">
                                <b>NOTE : </b>If Closing Stock for an Item is <b><span class="m--font-danger">NEGATIVE</span></b> It means that many <b><i>SOILED</i></b> Clothes needs to be collected from the Department.
                            </div>
                        </div>
                    </div>

                    <div class="form-group m-form__group row">
                        <label for="example-text-input" class="col-3 col-form-label">Transaction No :</label>
                        <div class="col-3">
                            <asp:Label class="form-control" id="lblTransactionNo" runat="server"></asp:Label>
                        </div>
                        <label for="example-text-input" class="col-3 col-form-label">Transaction By :</label>
                        <div class="col-3">
                            <asp:Label class="form-control" id="lblTransactionBy" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group m-form__group row">
                        <label for="example-text-input" class="col-3 col-form-label">Transaction Date :</label>
                        <div class="col-3">
                            <asp:Label class="form-control" id="lblTransactionDate" runat="server"></asp:Label>
                        </div>
                        
                    </div>
                    <div class="form-group m-form__group row" style="margin-bottom: 0rem;">

                        <div class="col-12">
                            <div class="alert m-alert m-alert--default" role="alert">
                                <b>NOTE : </b>If Closing Stock for an Item is <b><span class="m--font-success">POSITIVE</span></b> It means that many <b><i>CLEAN</i></b> Clothes needs to be given from the Department.
                            </div>
                        </div>
                    </div>


                </div>


                <div class="m-portlet__body" style="    padding: 0rem 2.2rem 2.2rem 2.2rem;">

                    <asp:HiddenField ID="hdnPrntD" runat="server" ClientIDMode="Static" />
                    <!--end: Search Form -->

                    <!--begin: Datatable -->

                    <asp:GridView ID="gvItemDetails" runat="server" Width="100%" AllowPaging="true" OnRowDataBound="gvItemDetails_RowDataBound"
                        PageSize="10" AllowSorting="true" AutoGenerateColumns="false" HeaderStyle-BackColor="#5867dd"
                        HeaderStyle-ForeColor="white" CellPadding="5" AlternatingRowStyle-BackColor="#E7F3FF"
                        PagerStyle-HorizontalAlign="Center" PagerStyle-Mode="NumericPages" PagerSettings-Mode="Numeric"
                        PagerSettings-Position="Bottom" ClientIDMode="Static">
                        <Columns>

                            <asp:BoundField DataField="Item_Desc" HeaderText="Item Name" HeaderStyle-Width="15%" />
                            <asp:BoundField DataField="Opening_Stock" HeaderText="Opening Stock" HeaderStyle-Width="15%" />

                            <asp:TemplateField HeaderText="Soiled Collected" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="15%">
                                <ItemTemplate>

                                    <%--<asp:TextBox ID="txtOpening" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Opening_Stock"))%>' Style="display: none;"></asp:TextBox>--%>
                                    <asp:TextBox ID="txtSoiledCollected" Width="90%" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"SoiledCollected"))%>' onkeyup="functionCalculation()"></asp:TextBox>
                                    <asp:HiddenField ID="hdnStock_ID" runat="server" Value='<%#(DataBinder.Eval(Container.DataItem,"Stock_ID"))%>' />
                                    <asp:HiddenField ID="hdnOpening_Stock" runat="server" Value='<%#(DataBinder.Eval(Container.DataItem,"Opening_Stock"))%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Cleaned Given" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCleanedGiven" Width="90%" CssClass="numeric" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"CleanedGiven"))%>' onkeyup="functionCalculation()"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Damaged" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDamaged" Width="90%" CssClass="numeric" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Damaged"))%>' onkeyup="functionCalculation()"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Closing" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtClosing" Width="90%" CssClass="numeric" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Closing"))%>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="15%">
                                <ItemTemplate>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            No Records Found !!!
                        </EmptyDataTemplate>
                        <EmptyDataRowStyle Height="50%" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px"
                            HorizontalAlign="Center" />
                    </asp:GridView>

                    <!--end: Datatable -->
                    <div style="text-align: center;">
                        <a style="margin-top: 5%;" runat="server" onserverclick="btnSaveTransaction_Click" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                            <span>
                                <i class="la la-plus"></i>
                                <span>Save Transaction</span>
                            </span>
                        </a>
                    </div>
                </div>

            </div>

            <!-- END EXAMPLE TABLE PORTLET-->
        </div>


        <div class="modal fade" id="m_modal_1" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header" style="padding: 16px;">
                                <h3>Select Items</h3>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body" style="padding: 0px;">


                        <div class="m-widget19">

                            <div class="m-widget1" style="padding: 0.2rem;">


                                <div class="m-stack m-stack--ver m-stack--general m-stack--demo" style="height: 45px;">
                                    <div class="m-stack__item m-stack__item--center">
                                        <div class="m-stack__demo-item">

                                            <asp:CheckBoxList ID="chkItems" runat="server" CssClass="normal" AutoPostBack="false" RepeatColumns="2"
                                                RepeatDirection="Vertical"
                                                RepeatLayout="Table"
                                                TextAlign="Right" CellPadding="5"
                                                CellSpacing="5">
                                            </asp:CheckBoxList>

                                        </div>
                                    </div>
                                </div>

                                <div class="m-stack m-stack--ver m-stack--general m-stack--demo" style="height: 45px;">
                                    <div class="m-stack__item m-stack__item--center">
                                        <div class="m-stack__demo-item">

                                            <asp:Button ID="btnItemSelect" runat="server" Text="Submit" OnClick="btnItemSelect_Click" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill" />

                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>




    </div>

    <!-- Modal -->



</asp:Content>
