<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Add_Purchases.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Transactions.Add_Purchases" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>

    <style type="text/css">
        .auto-style1 {
            height: 21px;
        }

        .input-group-text {
            padding: 0rem;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.datetimepicker').datepicker({
                todayHighlight: true,
                orientation: 'auto bottom',
                autoclose: true,
                pickerPosition: 'bottom-right',
                format: 'dd-MM-yyyy',
                showMeridian: true
            });

            var selectedTab = $("#<%=hfTab.ClientID%>");
            var tabId = selectedTab.val() != "" ? selectedTab.val() : "tab1";
            if (tabId == "tab1") {
                $("#ddlCocktail").prop("selectedIndex", 0).val();
            }
            if (tabId == "tab2") {
                $("#ddlBrand").prop("selectedIndex", 0).val();
                $("#ddlSize").prop("selectedIndex", 0).val();
            }
            $('#dvTab a[href="#' + tabId + '"]').tab('show');
            $("#dvTab a").click(function () {
                selectedTab.val($(this).attr("href").substring(1));
            });

        });
    </script>
    <script type="text/javascript">
        function pageLoad(sender, args) {

            $('.datetimepicker').datepicker({
                todayHighlight: true,
                orientation: 'auto bottom',
                autoclose: true,
                pickerPosition: 'bottom-right',
                format: 'dd-MM-yyyy',
                showMeridian: true
            });

            $("[id*=txtspegqty]").keyup(function () {
                //calculate total for current row
                var val1 = $(this).val() == "" ? 0 : $(this).val();
                var val2 = $('#sessionInput').val() == "" ? 0 : $('#sessionInput').val();
                var val3 = $(this).parent().parent().find("#txtspegrate").val() == "" ? 0 : $(this).parent().parent().find("#txtspegrate").val();

                var val6 = $(this).parent().parent().find("#txtbottleqty").val() == "" ? 0 : $(this).parent().parent().find("#txtbottleqty").val();
                var val7 = $(this).parent().parent().find("#txtbottlerate").val() == "" ? 0 : $(this).parent().parent().find("#txtbottlerate").val();

                var rowTotal = (parseFloat(!isNaN(val1) ? val1 : 0) * parseFloat(!isNaN(val3) ? val3 : 0)) +
                    (parseFloat(!isNaN(val6) ? val6 : 0) * parseFloat(!isNaN(val7) ? val7 : 0));

                var taxAmount = rowTotal * val2 / 100;
                $(this).closest('tr').find('[id*=txtamount]').val(taxAmount);

                $(this).closest('tr').find('[id*=txttotalamount]').val(rowTotal + taxAmount);
            });
            $("[id*=txtspegrate]").keyup(function () {
                //calculate total for current row
                var val3 = $(this).val() == "" ? 0 : $(this).val();
                var val1 = $('#sessionInput').val() == "" ? 0 : $('#sessionInput').val();
                var val2 = $(this).parent().parent().find("#txtspegqty").val() == "" ? 0 : $(this).parent().parent().find("#txtspegqty").val();

                var val6 = $(this).parent().parent().find("#txtbottleqty").val() == "" ? 0 : $(this).parent().parent().find("#txtbottleqty").val();
                var val7 = $(this).parent().parent().find("#txtbottlerate").val() == "" ? 0 : $(this).parent().parent().find("#txtbottlerate").val();

                var rowTotal = (parseFloat(!isNaN(val3) ? val3 : 0) * parseFloat(!isNaN(val2) ? val2 : 0)) +
                    (parseFloat(!isNaN(val6) ? val6 : 0) * parseFloat(!isNaN(val7) ? val7 : 0));

                var taxAmount = rowTotal * val1 / 100;
                $(this).closest('tr').find('[id*=txtamount]').val(taxAmount);

                $(this).closest('tr').find('[id*=txttotalamount]').val(rowTotal + taxAmount);
            });
            $("[id*=txtbottleqty]").keyup(function () {
                //calculate total for current row
                var val6 = $(this).val() == "" ? 0 : $(this).val();
                var val1 = $(this).parent().parent().find("#txtspegqty").val() == "" ? 0 : $(this).parent().parent().find("#txtspegqty").val();
                var val3 = $(this).parent().parent().find("#txtspegrate").val() == "" ? 0 : $(this).parent().parent().find("#txtspegrate").val();

                var val2 = $('#sessionInput').val() == "" ? 0 : $('#sessionInput').val();
                var val7 = $(this).parent().parent().find("#txtbottlerate").val() == "" ? 0 : $(this).parent().parent().find("#txtbottlerate").val();

                var rowTotal = (parseFloat(!isNaN(val1) ? val1 : 0) * parseFloat(!isNaN(val3) ? val3 : 0)) +
                    (parseFloat(!isNaN(val6) ? val6 : 0) * parseFloat(!isNaN(val7) ? val7 : 0));

                var taxAmount = rowTotal * val2 / 100;
                $(this).closest('tr').find('[id*=txtamount]').val(taxAmount);

                $(this).closest('tr').find('[id*=txttotalamount]').val(rowTotal + taxAmount);
            });
            $("[id*=txtbottlerate]").keyup(function () {
                //calculate total for current row
                var val7 = $(this).val() == "" ? 0 : $(this).val();
                var val1 = $(this).parent().parent().find("#txtspegqty").val() == "" ? 0 : $(this).parent().parent().find("#txtspegqty").val();
                var val3 = $(this).parent().parent().find("#txtspegrate").val() == "" ? 0 : $(this).parent().parent().find("#txtspegrate").val();

                var val6 = $(this).parent().parent().find("#txtbottleqty").val() == "" ? 0 : $(this).parent().parent().find("#txtbottleqty").val();
                var val2 = $('#sessionInput').val() == "" ? 0 : $('#sessionInput').val();

                var rowTotal = (parseFloat(!isNaN(val1) ? val1 : 0) * parseFloat(!isNaN(val3) ? val3 : 0)) +
                    (parseFloat(!isNaN(val6) ? val6 : 0) * parseFloat(!isNaN(val7) ? val7 : 0));

                var taxAmount = rowTotal * val2 / 100;
                $(this).closest('tr').find('[id*=txtamount]').val(taxAmount);
                $(this).closest('tr').find('[id*=txttotalamount]').val(rowTotal + taxAmount);
            });

        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

    <div class="m-grid__item m-grid__item--fluid">
        <div class="m-content">
            <div class="m-portlet m-portlet--mobile">
                <div class="m-portlet__head">
                    <div class="col-xl-3 m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <h3 class="m-portlet__head-text">Add New Purchase
                            </h3>
                        </div>
                    </div>

                    <div class="col-xl-9 m-portlet__head-tools">

                        <div class="col-lg-7 m--margin-bottom-10-tablet-and-mobile">
                            <div class="m-form__control">
                                <asp:DropDownList ID="ddlLicense" runat="server" CssClass="form-control" ClientIDMode="Static">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlLicense" Visible="true"
                                    ValidationGroup="validateLicense" ForeColor="Red" ErrorMessage="Please enter License"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Transactions/Purchases.aspx") %>" class="col-lg-2 btn btn-metal m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m--margin-right-10">
                            <span>
                                <i class="la la-arrow-left"></i>
                                <span>Back</span>
                            </span>
                        </a>
                        <asp:LinkButton ID="linkAddData" ValidationGroup="validateLicense" CausesValidation="True" runat="server" OnClick="btn_Add_Purchase_Click" class="col-lg-3 btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                            <span>
                                <i class="fa fa-save"></i>
                                <span>Save Transaction</span>
                            </span>
                        </asp:LinkButton>
                    </div>

                </div>

                <div class="m-portlet m-portlet--tabs">

                    <div class="m-portlet__head ">
                        <div id="dvTab" class="m-portlet__head-tools">
                            <ul class="nav nav-tabs m-tabs-line m-tabs-line--primary m-tabs-line--2x m--align-center" role="tablist">
                                <li class="nav-item m-tabs__item">
                                    <a href="#tab1" class="nav-link m-tabs__link" aria-controls="tab1" role="tab" data-toggle="tab">
                                        <i class="fa fa-wine-bottle" style="font-size: 2rem;"></i>Add Purchase Data
                                    </a>
                                </li>
                                <li class="nav-item m-tabs__item">
                                    <a href="#tab2" class="nav-link m-tabs__link" aria-controls="tab2" role="tab" data-toggle="tab">
                                        <i class="fa fa-file-import" style="font-size: 2rem;"></i>Import Purchase Data
                                    </a>
                                </li>
                                <li class="nav-item m-tabs__item"></li>
                            </ul>
                        </div>
                    </div>

                    <div class="m-portlet__body">
                        <div class="tab-content">
                            <div class="tab-pane" id="tab1" role="tabpanel">
                                <div class="row m--margin-bottom-20 m--align-center">

                                    <div class="col-lg-2 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Select Purchase Date</label>

                                        <div class="m-form__control">
                                            <div class="input-group date">
                                                <asp:TextBox autocomplete="off" runat="server" type="text" class="form-control m-input datetimepicker" ID="txtPurchaseDate">
                                                </asp:TextBox>
                                                <div class="input-group-append">
                                                    <span class="input-group-text">
                                                        <i class="la la-calendar" style="font-size: 2rem;"></i>
                                                    </span>
                                                </div>
                                            </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPurchaseDate" Visible="true" ValidationGroup="Brandvalidate" ForeColor="Red" ErrorMessage="Please enter Date"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Select Supplier</label>

                                        <div class="m-form__control">
                                            <asp:DropDownList ID="ddlSupplier" runat="server" CssClass="form-control" ClientIDMode="Static">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlSupplier" Visible="true" ValidationGroup="Brandvalidate" ForeColor="Red" ErrorMessage="Please enter Brand"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Enter TP Number</label>
                                        <div class="m-form__control">
                                            <asp:TextBox ID="txttpnumber" autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txttpnumber" Visible="true" ValidationGroup="Brandvalidate" ForeColor="Red" ErrorMessage="Please enter Bill No"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Discount %</label>
                                        <div class="m-form__control">
                                            <asp:TextBox ID="txtdiscount" autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdiscount" Visible="true" ValidationGroup="Brandvalidate" ForeColor="Red" ErrorMessage="Please enter Bill No"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Invoice Number</label>
                                        <div class="m-form__control">
                                            <asp:TextBox ID="txtinvoicenumber" autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtinvoicenumber" Visible="true" ValidationGroup="Brandvalidate" ForeColor="Red" ErrorMessage="Please enter Bill No"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Total Charges</label>
                                        <div class="m-form__control">
                                            <asp:TextBox ID="txttotalcharges" autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txttotalcharges" Visible="true" ValidationGroup="Brandvalidate" ForeColor="Red" ErrorMessage="Please enter Bill No"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                </div>
                                <div class="row m--margin-bottom-20 m--align-center">

                                    <div class="col-lg-4 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Select Brand</label>
                                        <div class="m-form__control">
                                            <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged" ID="ddlBrand" runat="server" CssClass="form-control" ClientIDMode="Static">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlBrand" Visible="true" ValidationGroup="Brandvalidate" ForeColor="Red" ErrorMessage="Please enter Brand"></asp:RequiredFieldValidator>
                                        </div>
                                        <input id="sessionInput" type="hidden" value='<%= Session["hdnTax"] %>' />
                                    </div>


                                    <div class="col-lg-4 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Select Size</label>
                                        <div class="m-form__control">
                                            <asp:UpdatePanel ID="Updatepanel1" runat="server" UpdateMode="Always">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlSize" runat="server" CssClass="form-control" ClientIDMode="Static">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlSize" Visible="true" ValidationGroup="Brandvalidate" ForeColor="Red" ErrorMessage="Please select Size"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlBrand" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>


                                    <div class="col-lg-4 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Add Purchase</label>
                                        <div class="m-form__control">
                                            <asp:LinkButton ID="btn_AddPurchase" CausesValidation="true" OnClick="btn_AddPurchase_Click" ValidationGroup="Brandvalidate" class="btn btn-success m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air" runat="server">
                                                    <span>
                                                        <i class="fa fa-plus"></i>
                                                        <span>Add Selected Purchase</span>
                                                    </span>
                                            </asp:LinkButton>
                                        </div>

                                    </div>
                                </div>

                                <asp:UpdatePanel ID="Updatepanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>

                                        <table id="purchaseTbl" width="100%" cellpadding="2" cellspacing="2">
                                            <tr>
                                                <td colspan="2" class="ClsControlTd">
                                                    <asp:GridView ID="grdPurchase" class="table table-striped- table-bordered table-hover table-checkable" runat="server" Width="100%"
                                                        AllowPaging="true"
                                                        PageSize="10" AllowSorting="true" AutoGenerateColumns="false" CellPadding="5"
                                                        PagerStyle-HorizontalAlign="Center" PagerStyle-Mode="NumericPages" PagerSettings-Mode="Numeric"
                                                        PagerSettings-Position="Bottom" ClientIDMode="Static" OnRowDeleting="Purchase_OnRowDeleting"
                                                        OnRowDataBound="Purchase_OnRowDataBound" OnPageIndexChanging="Purchase_PageIndexChanging">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:CommandField ItemStyle-HorizontalAlign="Center" ShowDeleteButton="True" HeaderText="Delete" DeleteText="" ControlStyle-CssClass="flaticon-delete-1" ButtonType="Link" />

                                                            <asp:BoundField HeaderStyle-ForeColor="GrayText" ControlStyle-CssClass="form-control" DataField="Brand" HeaderText="Brand" SortExpression="Brand" />
                                                            <asp:BoundField HeaderStyle-ForeColor="GrayText" ControlStyle-CssClass="form-control" DataField="Size" HeaderText="Size" SortExpression="Size" />
                                                            <asp:BoundField HeaderStyle-ForeColor="GrayText" ControlStyle-CssClass="form-control" DataField="Stock" HeaderText="Stock Available" SortExpression="Stock" />

                                                            <asp:TemplateField HeaderText="Bottle Qty" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:TextBox autocomplete="off" onkeypress="return (event.charCode !=8 && event.charCode ==0 || (event.charCode >= 48 && event.charCode <= 57))" ID="txtbottleqty"
                                                                        Width="50px" CssClass="form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Bottle_Qty"))%>'></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Bottle Rate" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:TextBox autocomplete="off" onkeypress="return (event.charCode !=8 && event.charCode ==0 || (event.charCode >= 48 && event.charCode <= 57))" ID="txtbottlerate" Width="50px" CssClass="form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Bottle_Rate"))%>'></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="SPeg Qty" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:TextBox autocomplete="off" onkeypress="return (event.charCode !=8 && event.charCode ==0 || (event.charCode >= 48 && event.charCode <= 57))"
                                                                        ID="txtspegqty" Width="50px" CssClass="form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"sPegQty"))%>'></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="SPeg Rate" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:TextBox autocomplete="off" onkeypress="return (event.charCode !=8 && event.charCode ==0 || (event.charCode >= 48 && event.charCode <= 57))" ID="txtspegrate"
                                                                        Width="50px" CssClass="form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"sPegRate"))%>'></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Boxes" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:TextBox autocomplete="off" onkeypress="return (event.charCode !=8 && event.charCode ==0 || (event.charCode >= 48 && event.charCode <= 57))"
                                                                        ID="txtboxes" Width="50px" CssClass="form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Boxes"))%>'></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Batch No" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:TextBox autocomplete="off" onkeypress="return (event.charCode !=8 && event.charCode ==0 || (event.charCode >= 48 && event.charCode <= 57))"
                                                                        ID="txtbatchno" Width="50px" CssClass="form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"BatchNo"))%>'></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="Mfg Date" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <div class="m-form__control">
                                                                        <div class="input-group date">
                                                                            <asp:TextBox autocomplete="off" runat="server" type="text" Text='<%# (DataBinder.Eval(Container.DataItem,"MfgDate", "{0:dd/MMM/yyyy}")) %>'
                                                                                CssClass="form-control m-input datetimepicker" ID="txtmfgdate">
                                                                            </asp:TextBox>
                                                                            <div class="input-group-append">
                                                                                <span class="input-group-text">
                                                                                    <i class="la la-calendar" style="font-size: 2rem;"></i>
                                                                                </span>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Tax Amount" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtamount" Width="70px" CssClass="form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Tax_Amount"))%>'></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Total Amount" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txttotalamount" Width="70px" CssClass="form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Total_Amount"))%>'></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>


                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            No Records Found !!!
                                                        </EmptyDataTemplate>
                                                        <EmptyDataRowStyle Height="50%" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px"
                                                            HorizontalAlign="Center" />


                                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />

                                                        <PagerStyle HorizontalAlign="Center"></PagerStyle>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>

                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btn_AddPurchase" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>

                            <div class="tab-pane" id="tab2" role="tabpanel">
                                <div class="m-section">
                                    <div class="m-section__sub">
                                        You can import your Purchase data for the selected <b>Purchase Date</b>. Download the Sample File below and fill in the data as required.	
                                            
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-xl-12">
                                        <div class="m-section m--align-center">
                                            <div class="m-section__sub">
                                                <a href="#" class="btn btn-success m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                                                    <span>
                                                        <i class="fa fa-file-download" style="font-size: 1.6rem;"></i>
                                                        <span>Download Brands Purchase Sample File</span>
                                                        <i class="fa fa-wine-bottle" style="font-size: 1.6rem;"></i>
                                                    </span>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="m-dropzone dropzone m-dropzone--primary dz-clickable" action="inc/api/dropzone/upload.php" id="m-dropzone-two">
                                            <div class="m-dropzone__msg dz-message needsclick">
                                                <h3 class="m-dropzone__msg-title">Drop files here or click to upload Brands Purchase File.</h3>
                                                <span class="m-dropzone__msg-desc">Upload only 1 file</span>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                            </div>

                        </div>

                        <asp:HiddenField ID="hfTab" runat="server" />
                    </div>
                </div>
            </div>
        </div>


    </div>


    <script src="<%= Page.ResolveClientUrl("~/assets/demo/default/custom/crud/forms/widgets/bootstrap-datepicker.js") %>" type="text/javascript"></script>

</asp:Content>
