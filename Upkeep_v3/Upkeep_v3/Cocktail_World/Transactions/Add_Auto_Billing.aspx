<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UpkeepMaster.Master" CodeBehind="Add_Auto_Billing.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Transactions.Add_Auto_Billing" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>

    <style type="text/css">
        .auto-style1 {
            height: 21px;
        }

        .form-control {
            padding: 0.5rem;
        }

        .underline {
            border-bottom-color: #5867dd;
            border-bottom-width: 5px;
            height: 45px;
        }
    </style>
    <script type="text/javascript">
        function confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to delete data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
        }

        function GetBillsCount() {
            var dataString = {
                'item': '',
            };
            var param = JSON.stringify(dataString);

            $.ajax({
                type: "POST",
                url: "Add_Auto_Billing.aspx/GetCount",
                data: param,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                },
                failure: function (response) {
                    toastr.error("Your transaction Not Added..!");
                }
            });
        }
    </script>


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

            var BillDataDetails = $("input[name=BillDataDetails]").val();
            if (BillDataDetails != undefined) {
                swal({
                    title: "Are you sure?",
                    text: BillDataDetails + " Bills will be created..!",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonColor: '#DD6B55',
                    confirmButtonText: 'Yes',
                    cancelButtonText: "No",
                })
                    .then((isConfirm) => {
                        if (isConfirm.value) {
                            var dataString = {
                                'item': '',
                            };
                            var param = JSON.stringify(dataString);
                            $.ajax({
                                type: "POST",
                                url: "Add_Auto_Billing.aspx/GetCount",
                                data: param,
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (response) {
                                    swal({
                                        title: "Success..!",
                                        text: "Your AutoBilling trasaction successfully added!",
                                        type: "success"
                                    }).then(function () {
                                        window.location = "Auto_Billing.aspx";
                                    });
                                },
                                failure: function (response) {
                                    toastr.error("Your transaction Not Added..!");
                                }
                            });
                        }

                        if (isConfirm.dismiss) {
                            swal("Cancelled", "Your data are safe :)", "error");
                        }
                        return false;
                    });
            }


            var getOpening_ID = $("input[name=Opening_ID]").val();
            var getBS_QTY = $("input[name=BS_QTY]").val();
            var getNegative = $("input[name=Negative]").val();
            var getLicense = $("input[name=License]").val();
            var getDuplicate = $("input[name=Duplicate]").val();
            var CheckAmount = $("input[name=CheckAmount]").val();

            if (getOpening_ID != undefined) {
                toastr.error("Brand Opening ID not available.");
            }
            if (getBS_QTY != undefined) {
                toastr.error("Please Check Bottle Qty and SPeg Qty.");
            }
            if (getNegative != undefined) {
                toastr.error(getNegative);
            }
            if (getLicense != undefined) {
                toastr.error("Please Select Brand.");
            }
            if (getDuplicate != undefined) {
                toastr.error("This data already in database.");
            }
             if (CheckAmount != undefined) {
                toastr.error("Please enter quantity.");
            }

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
            if (tabId == "tab3") {
                $("#ddlCocktail").prop("selectedIndex", 0).val();
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
            $("[id*=txtspegqty]").keyup(function () {
                //calculate total for current row
                var val1 = $(this).val() == "" ? 0 : $(this).val();
                var val2 = $('#sessionInput').val() == "" ? 0 : $('#sessionInput').val();
                var val3 = $(this).parent().parent().find("#txtspegrate").val() == "" ? 0 : $(this).parent().parent().find("#txtspegrate").val();

                var val4 = $(this).parent().parent().find("#txtlpegqty").val() == "" ? 0 : $(this).parent().parent().find("#txtlpegqty").val();
                var val5 = $(this).parent().parent().find("#txtlpegrate").val() == "" ? 0 : $(this).parent().parent().find("#txtlpegrate").val();

                var val6 = $(this).parent().parent().find("#txtbottleqty").val() == "" ? 0 : $(this).parent().parent().find("#txtbottleqty").val();
                var val7 = $(this).parent().parent().find("#txtbottlerate").val() == "" ? 0 : $(this).parent().parent().find("#txtbottlerate").val();

                var rowTotal = (parseFloat(!isNaN(val1) ? val1 : 0) * parseFloat(!isNaN(val3) ? val3 : 0)) +
                    (parseFloat(!isNaN(val4) ? val4 : 0) * parseFloat(!isNaN(val5) ? val5 : 0)) +
                    (parseFloat(!isNaN(val6) ? val6 : 0) * parseFloat(!isNaN(val7) ? val7 : 0));

                var taxAmount = 0;
                $(this).closest('tr').find('[id*=txtamount]').val(taxAmount);

                $(this).closest('tr').find('[id*=txttotalamount]').val(rowTotal);
            });
            $("[id*=txtspegrate]").keyup(function () {
                //calculate total for current row
                var val3 = $(this).val() == "" ? 0 : $(this).val();
                var val1 = $('#sessionInput').val() == "" ? 0 : $('#sessionInput').val();
                var val2 = $(this).parent().parent().find("#txtspegqty").val() == "" ? 0 : $(this).parent().parent().find("#txtspegqty").val();

                var val4 = $(this).parent().parent().find("#txtlpegqty").val() == "" ? 0 : $(this).parent().parent().find("#txtlpegqty").val();
                var val5 = $(this).parent().parent().find("#txtlpegrate").val() == "" ? 0 : $(this).parent().parent().find("#txtlpegrate").val();

                var val6 = $(this).parent().parent().find("#txtbottleqty").val() == "" ? 0 : $(this).parent().parent().find("#txtbottleqty").val();
                var val7 = $(this).parent().parent().find("#txtbottlerate").val() == "" ? 0 : $(this).parent().parent().find("#txtbottlerate").val();

                var rowTotal = (parseFloat(!isNaN(val3) ? val3 : 0) * parseFloat(!isNaN(val2) ? val2 : 0)) +
                    (parseFloat(!isNaN(val4) ? val4 : 0) * parseFloat(!isNaN(val5) ? val5 : 0)) +
                    (parseFloat(!isNaN(val6) ? val6 : 0) * parseFloat(!isNaN(val7) ? val7 : 0));

                var taxAmount = 0;
                $(this).closest('tr').find('[id*=txtamount]').val(taxAmount);

                $(this).closest('tr').find('[id*=txttotalamount]').val(rowTotal);
            });
            $("[id*=txtlpegqty]").keyup(function () {
                //calculate total for current row
                var val4 = $(this).val() == "" ? 0 : $(this).val();
                var val1 = $(this).parent().parent().find("#txtspegqty").val() == "" ? 0 : $(this).parent().parent().find("#txtspegqty").val();
                var val3 = $(this).parent().parent().find("#txtspegrate").val() == "" ? 0 : $(this).parent().parent().find("#txtspegrate").val();

                var val2 = $('#sessionInput').val() == "" ? 0 : $('#sessionInput').val();
                var val5 = $(this).parent().parent().find("#txtlpegrate").val() == "" ? 0 : $(this).parent().parent().find("#txtlpegrate").val();

                var val6 = $(this).parent().parent().find("#txtbottleqty").val() == "" ? 0 : $(this).parent().parent().find("#txtbottleqty").val();
                var val7 = $(this).parent().parent().find("#txtbottlerate").val() == "" ? 0 : $(this).parent().parent().find("#txtbottlerate").val();

                var rowTotal = (parseFloat(!isNaN(val1) ? val1 : 0) * parseFloat(!isNaN(val3) ? val3 : 0)) +
                    (parseFloat(!isNaN(val4) ? val4 : 0) * parseFloat(!isNaN(val5) ? val5 : 0)) +
                    (parseFloat(!isNaN(val6) ? val6 : 0) * parseFloat(!isNaN(val7) ? val7 : 0));

                var taxAmount = 0;
                $(this).closest('tr').find('[id*=txtamount]').val(taxAmount);

                $(this).closest('tr').find('[id*=txttotalamount]').val(rowTotal);
            });
            $("[id*=txtlpegrate]").keyup(function () {
                //calculate total for current row
                var val5 = $(this).val() == "" ? 0 : $(this).val();
                var val1 = $(this).parent().parent().find("#txtspegqty").val() == "" ? 0 : $(this).parent().parent().find("#txtspegqty").val();
                var val3 = $(this).parent().parent().find("#txtspegrate").val() == "" ? 0 : $(this).parent().parent().find("#txtspegrate").val();

                var val4 = $(this).parent().parent().find("#txtlpegqty").val() == "" ? 0 : $(this).parent().parent().find("#txtlpegqty").val();
                var val2 = $('#sessionInput').val() == "" ? 0 : $('#sessionInput').val();

                var val6 = $(this).parent().parent().find("#txtbottleqty").val() == "" ? 0 : $(this).parent().parent().find("#txtbottleqty").val();
                var val7 = $(this).parent().parent().find("#txtbottlerate").val() == "" ? 0 : $(this).parent().parent().find("#txtbottlerate").val();

                var rowTotal = (parseFloat(!isNaN(val1) ? val1 : 0) * parseFloat(!isNaN(val3) ? val3 : 0)) +
                    (parseFloat(!isNaN(val4) ? val4 : 0) * parseFloat(!isNaN(val5) ? val5 : 0)) +
                    (parseFloat(!isNaN(val6) ? val6 : 0) * parseFloat(!isNaN(val7) ? val7 : 0));

                var taxAmount = 0;
                $(this).closest('tr').find('[id*=txtamount]').val(taxAmount);

                $(this).closest('tr').find('[id*=txttotalamount]').val(rowTotal);
            });
            $("[id*=txtbottleqty]").keyup(function () {
                //calculate total for current row
                var val6 = $(this).val() == "" ? 0 : $(this).val();
                var val1 = $(this).parent().parent().find("#txtspegqty").val() == "" ? 0 : $(this).parent().parent().find("#txtspegqty").val();
                var val3 = $(this).parent().parent().find("#txtspegrate").val() == "" ? 0 : $(this).parent().parent().find("#txtspegrate").val();

                var val4 = $(this).parent().parent().find("#txtlpegqty").val() == "" ? 0 : $(this).parent().parent().find("#txtlpegqty").val();
                var val5 = $(this).parent().parent().find("#txtlpegrate").val() == "" ? 0 : $(this).parent().parent().find("#txtlpegrate").val();

                var val2 = $('#sessionInput').val() == "" ? 0 : $('#sessionInput').val();
                var val7 = $(this).parent().parent().find("#txtbottlerate").val() == "" ? 0 : $(this).parent().parent().find("#txtbottlerate").val();

                var rowTotal = (parseFloat(!isNaN(val1) ? val1 : 0) * parseFloat(!isNaN(val3) ? val3 : 0)) +
                    (parseFloat(!isNaN(val4) ? val4 : 0) * parseFloat(!isNaN(val5) ? val5 : 0)) +
                    (parseFloat(!isNaN(val6) ? val6 : 0) * parseFloat(!isNaN(val7) ? val7 : 0));

                var taxAmount = 0;
                //var taxAmount = rowTotal * val2 / 100;
                $(this).closest('tr').find('[id*=txtamount]').val(taxAmount);

                $(this).closest('tr').find('[id*=txttotalamount]').val(rowTotal);
            });
            $("[id*=txtbottlerate]").keyup(function () {
                //calculate total for current row
                var val7 = $(this).val() == "" ? 0 : $(this).val();
                var val1 = $(this).parent().parent().find("#txtspegqty").val() == "" ? 0 : $(this).parent().parent().find("#txtspegqty").val();
                var val3 = $(this).parent().parent().find("#txtspegrate").val() == "" ? 0 : $(this).parent().parent().find("#txtspegrate").val();

                var val4 = $(this).parent().parent().find("#txtlpegqty").val() == "" ? 0 : $(this).parent().parent().find("#txtlpegqty").val();
                var val5 = $(this).parent().parent().find("#txtlpegrate").val() == "" ? 0 : $(this).parent().parent().find("#txtlpegrate").val();

                var val6 = $(this).parent().parent().find("#txtbottleqty").val() == "" ? 0 : $(this).parent().parent().find("#txtbottleqty").val();
                var val2 = $('#sessionInput').val() == "" ? 0 : $('#sessionInput').val();

                var rowTotal = (parseFloat(!isNaN(val1) ? val1 : 0) * parseFloat(!isNaN(val3) ? val3 : 0)) +
                    (parseFloat(!isNaN(val4) ? val4 : 0) * parseFloat(!isNaN(val5) ? val5 : 0)) +
                    (parseFloat(!isNaN(val6) ? val6 : 0) * parseFloat(!isNaN(val7) ? val7 : 0));

                var taxAmount = 0;
                $(this).closest('tr').find('[id*=txtamount]').val(taxAmount);
                $(this).closest('tr').find('[id*=txttotalamount]').val(rowTotal);
            });

            $("[id*=cocktailqty]").keyup(function () {
                //calculate total for current row
                var val1 = $(this).val() == "" ? 0 : $(this).val();
                var val2 = $(this).parent().parent().find("#cocktailrate").val() == "" ? 0 : $(this).parent().parent().find("#cocktailrate").val();

                var val3 = $("#sessionCocktail").val() == "" ? 0 : $("#sessionCocktail").val();

                var rowTotal = (parseFloat(!isNaN(val1) ? val1 : 0) * parseFloat(!isNaN(val2) ? val2 : 0));

                var taxAmount = 0;
                $(this).closest('tr').find('[id*=cocktailamount]').val(taxAmount);
                $(this).closest('tr').find('[id*=cocktailtotalamount]').val(rowTotal);
            });

            $("[id*=cocktailrate]").keyup(function () {
                //calculate total for current row
                var val1 = $(this).val() == "" ? 0 : $(this).val();
                var val2 = $(this).parent().parent().find("#cocktailqty").val() == "" ? 0 : $(this).parent().parent().find("#cocktailqty").val();

                var val3 = $("#sessionCocktail").val() == "" ? 0 : $("#sessionCocktail").val();

                var rowTotal = (parseFloat(!isNaN(val1) ? val1 : 0) * parseFloat(!isNaN(val2) ? val2 : 0));

                var taxAmount = 0;
                $(this).closest('tr').find('[id*=cocktailamount]').val(taxAmount);
                $(this).closest('tr').find('[id*=cocktailtotalamount]').val(rowTotal);
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
                            <h3 class="m-portlet__head-text">Add New Auto Billing Transaction</h3>
                        </div>
                    </div>

                    <div class="m-portlet__head-tools">
                        <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Transactions/Auto_Billing.aspx") %>" class="btn btn-metal m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m--margin-right-10">
                            <span>
                                <i class="la la-arrow-left"></i>
                                <span>Back</span>
                            </span>
                        </a>
                        <asp:LinkButton ID="linkAddData" ValidationGroup="validateLicense" CausesValidation="True" runat="server" OnClick="btn_Add_Brand_Cocktail_Sale_Click" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                            <span>
                                <i class="fa fa-plus"></i>
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
                                        <i class="fa fa-wine-bottle" style="font-size: 2rem;"></i>Add Brand Auto Billing
                                    </a>
                                </li>
                                <li class="nav-item m-tabs__item"><a href="#tab2" class="nav-link m-tabs__link" aria-controls="tab2" role="tab" data-toggle="tab"><i class="fa fa-cocktail" style="font-size: 2rem;"></i>Add Cocktail Auto Billing
                                </a></li>
                                <li class="nav-item m-tabs__item"><a href="#tab3" class="nav-link m-tabs__link" aria-controls="tab3" role="tab" data-toggle="tab"><i class="fa fa-file-import" style="font-size: 2rem;"></i>Import Auto Billing Data
                                </a></li>
                            </ul>
                        </div>
                        <div class="m-portlet m-portlet--tabs" style="width: 300px; margin-top: 10px;">
                            <asp:DropDownList ID="ddlLicense" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlLicense_SelectedIndexChanged" CssClass="underline form-control" ClientIDMode="Static">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlLicense" Visible="true"
                                ValidationGroup="validateLicense" ForeColor="Red" ErrorMessage="Please enter License"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="m-portlet__body">
                        <div class="tab-content">


                            <div class="tab-pane" id="tab1" role="tabpanel">
                                <div class="row m--margin-bottom-20 m--align-center">



                                    <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Select Date</label>

                                        <div class="m-form__control">
                                            <div class="input-group date">
                                                <asp:TextBox autocomplete="off" runat="server" type="text" class="form-control m-input datetimepicker" ID="txtBrandDate">
                                                </asp:TextBox>
                                                <div class="input-group-append">
                                                    <span class="input-group-text">
                                                        <i class="la la-calendar" style="font-size: 2rem;"></i>
                                                    </span>
                                                </div>
                                            </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBrandDate" Visible="true" ValidationGroup="Brandvalidate" ForeColor="Red" ErrorMessage="Please enter Date"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Amount</label>
                                        <div class="m-form__control">
                                            <asp:TextBox ID="txtBillAmount" autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBillAmount" Visible="true" ValidationGroup="Brandvalidate" ForeColor="Red" ErrorMessage="Please enter Bill Amount"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="col-lg-2 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Select Brand</label>
                                        <div class="m-form__control">
                                            <asp:UpdatePanel ID="Updatepanel4" runat="server" UpdateMode="Always">
                                                <ContentTemplate>
                                                    <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged" ID="ddlBrand" runat="server" CssClass="form-control" ClientIDMode="Static">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlBrand" Visible="true" ValidationGroup="Brandvalidate" ForeColor="Red" ErrorMessage="Please select Brand"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlLicense" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <input id="sessionInput" type="hidden" value='<%= Session["hdnTax"] %>' />
                                    </div>


                                    <div class="col-lg-2 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Select Size</label>

                                        <div class="m-form__control">
                                            <asp:UpdatePanel ID="Updatepanel1" runat="server" UpdateMode="Always">
                                                <ContentTemplate>
                                                    <asp:DropDownList OnSelectedIndexChanged="ddlSize_SelectedIndexChanged" ID="ddlSize" runat="server" CssClass="form-control"
                                                        AutoPostBack="true" ClientIDMode="Static">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlSize" Visible="true" ValidationGroup="Brandvalidate" ForeColor="Red" ErrorMessage="Please select Size"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlBrand" />
                                                    <asp:AsyncPostBackTrigger ControlID="ddlSize" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>


                                    <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                                        <asp:UpdatePanel ID="Updatepanel5" runat="server" UpdateMode="Always">
                                            <ContentTemplate>
                                                <u>
                                                    <asp:Label CssClass="font-weight-bold" ID="lbl_stock" runat="server"></asp:Label></u>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        &nbsp;
                                        <div class="m-form__control">
                                            <asp:LinkButton ID="btn_AddBrand" CausesValidation="true" OnClick="btn_AddBrand_Click" ValidationGroup="Brandvalidate" class="btn btn-success m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air" runat="server">
                                                    <span>
                                                        <i class="fa fa-plus"></i>
                                                        <span>Add Selected Brand</span>
                                                    </span>
                                            </asp:LinkButton>
                                        </div>

                                    </div>


                                </div>
                                <asp:UpdatePanel ID="Updatepanel2" runat="server" UpdateMode="Always">
                                    <ContentTemplate>

                                        <table id="brandTbl" width="100%" cellpadding="2" cellspacing="2">
                                            <tr>
                                                <td colspan="2" class="ClsControlTd">
                                                    <asp:GridView ID="grdBrandLinkup" class="table table-striped- table-bordered table-hover table-checkable" runat="server" Width="100%"
                                                        AllowSorting="true" AutoGenerateColumns="false" CellPadding="5"
                                                        ClientIDMode="Static" OnRowDeleting="BrandOnRowDeleting"
                                                        OnRowDataBound="BrandOnRowDataBound" OnPageIndexChanging="grdBrandLinkup_PageIndexChanging">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:CommandField ItemStyle-HorizontalAlign="Center" ShowDeleteButton="True" HeaderText="Delete" DeleteText="" ControlStyle-CssClass="flaticon-delete-1" ButtonType="Link" />

                                                            <asp:BoundField HeaderStyle-ForeColor="GrayText" ControlStyle-CssClass="form-control" DataField="Brand" HeaderText="Brand" SortExpression="Brand" />
                                                            <asp:BoundField HeaderStyle-ForeColor="GrayText" ControlStyle-CssClass="form-control" DataField="Size" HeaderText="Size" SortExpression="Size" />
                                                            <asp:BoundField HeaderStyle-ForeColor="GrayText" ControlStyle-CssClass="form-control" DataField="Stock" HeaderText="Stock" SortExpression="Stock" />

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

                                                            <asp:TemplateField HeaderText="LPeg Qty" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:TextBox autocomplete="off" onkeypress="return (event.charCode !=8 && event.charCode ==0 || (event.charCode >= 48 && event.charCode <= 57))"
                                                                        ID="txtlpegqty" Width="50px" CssClass="form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"lPegQty"))%>'></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="LPeg Rate" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:TextBox autocomplete="off" onkeypress="return (event.charCode !=8 && event.charCode ==0 || (event.charCode >= 48 && event.charCode <= 57))"
                                                                        ID="txtlpegrate" Width="50px" CssClass="form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"lPegRate"))%>'></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
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
                                                            <asp:TemplateField HeaderText="Total Amount" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txttotalamount" Width="70px" CssClass="form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Total_Amount"))%>'></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Tax Amount" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtamount" Width="70px" CssClass="form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Tax_Amount"))%>'></asp:TextBox>
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
                                        <asp:AsyncPostBackTrigger ControlID="btn_AddBrand" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="grdBrandLinkup" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>


                            <div class="tab-pane" id="tab2" role="tabpanel">
                                <div class="row m--margin-bottom-20 m--align-center">
                                    <div class="col-lg-2 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Bill No.</label>
                                        <div class="m-form__control">

                                            <asp:TextBox ID="CocktailBill" autocomplete="off" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="CocktailBill" Visible="true" ValidationGroup="cocktailvalidate" ForeColor="Red" ErrorMessage="Please enter Bill No."></asp:RequiredFieldValidator>

                                        </div>
                                    </div>

                                    <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Select Sale Date</label>
                                        <div class="m-form__control">
                                            <div class="input-group date">
                                                <asp:TextBox autocomplete="off" runat="server" type="text" class="form-control m-input datetimepicker" ID="txtCocktailDate">
                                                </asp:TextBox>
                                                <div class="input-group-append">
                                                    <span class="input-group-text">
                                                        <i class="la la-calendar" style="font-size: 2rem;"></i>
                                                    </span>
                                                </div>
                                            </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCocktailDate" Visible="true" ValidationGroup="cocktailvalidate" ForeColor="Red" ErrorMessage="Please enter Date"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>


                                    <div class="col-lg-4 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Select Cocktail</label>
                                        <div class="m-form__control">
                                            <asp:DropDownList ID="ddlCocktail" runat="server" CssClass="form-control" ClientIDMode="Static">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlCocktail" Visible="true" ValidationGroup="cocktailvalidate" ForeColor="Red" ErrorMessage="Please select Cocktail"></asp:RequiredFieldValidator>

                                        </div>
                                        <input id="sessionCocktail" type="hidden" value='<%= Session["hdnCocktailTax"] %>' />

                                    </div>

                                    <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                                        <label class="font-weight-bold">Add Cocktail</label>
                                        <div class="m-form__control">
                                            <asp:LinkButton ID="btnAddCocktail" CausesValidation="true" OnClick="btn_AddCocktail_Click" ValidationGroup="cocktailvalidate" class="btn btn-success m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air" runat="server">
                                                    <span>
                                                        <i class="fa fa-plus"></i>
                                                        <span>Add Selected Cocktail</span>
                                                    </span>
                                            </asp:LinkButton>
                                        </div>

                                    </div>
                                </div>

                                <asp:UpdatePanel ID="Updatepanel3" runat="server" UpdateMode="Always">
                                    <ContentTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td colspan="2" class="ClsControlTd">
                                                    <asp:GridView ID="grdCocktail" class="table table-striped- table-bordered table-hover table-checkable" runat="server" Width="100%"
                                                        AllowPaging="true"
                                                        PageSize="10" AllowSorting="true" AutoGenerateColumns="false" CellPadding="5"
                                                        PagerStyle-HorizontalAlign="Center" PagerStyle-Mode="NumericPages" PagerSettings-Mode="Numeric"
                                                        PagerSettings-Position="Bottom" ClientIDMode="Static" OnRowDeleting="CocktailOnRowDeleting"
                                                        OnRowDataBound="CocktailOnRowDataBound" OnPageIndexChanging="grdCocktailLinkup_PageIndexChanging">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <Columns>

                                                            <asp:CommandField ItemStyle-HorizontalAlign="Center" HeaderText="Delete" ShowDeleteButton="True" DeleteText="" ControlStyle-CssClass="flaticon-delete-1" ButtonType="Link" />
                                                            <asp:BoundField HeaderStyle-ForeColor="GrayText" ControlStyle-CssClass="form-control" DataField="Cocktail_Desc" HeaderText="Cocktail" SortExpression="Cocktail_Desc" />

                                                            <asp:TemplateField HeaderText="Bottle Qty" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:TextBox autocomplete="off" onkeypress="return (event.charCode !=8 && event.charCode ==0 || (event.charCode >= 48 && event.charCode <= 57))" ID="cocktailqty" Width="100px" CssClass="form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Cat_Bottle_Qty"))%>'></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Bottle Rate" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:TextBox autocomplete="off" onkeypress="return (event.charCode !=8 && event.charCode ==0 || (event.charCode >= 48 && event.charCode <= 57))" ID="cocktailrate" Width="100px" CssClass="form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Cat_Bottle_Rate"))%>'></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Total Amount" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="cocktailtotalamount" Width="100px" CssClass="form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Cat_Total_Amount"))%>'></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Tax Amount" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="cocktailamount" Width="100px" CssClass="form-control" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Cat_Tax_Amount"))%>'></asp:TextBox>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Permit Holder">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AppendDataBoundItems="true">
                                                                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
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
                                        <asp:AsyncPostBackTrigger ControlID="btnAddCocktail" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="grdCocktail" />
                                    </Triggers>
                                </asp:UpdatePanel>

                            </div>

                            <div class="tab-pane" id="tab3" role="tabpanel">
                                <div class="m-section">
                                    <div class="m-section__sub">
                                        You can import your sale data for the selected <b>Sale Date</b>. Download the Sample File below and fill in the data as required.	
                                            
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-xl-6">
                                        <div class="m-section m--align-center">
                                            <div class="m-section__sub">
                                                <a href="#" class="btn btn-success m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                                                    <span>
                                                        <i class="fa fa-file-download" style="font-size: 1.6rem;"></i>
                                                        <span>Download Brand Sale Sample File</span>
                                                        <i class="fa fa-wine-bottle" style="font-size: 1.6rem;"></i>
                                                    </span>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="m-dropzone dropzone m-dropzone--primary dz-clickable" action="inc/api/dropzone/upload.php" id="m-dropzone-two">
                                            <div class="m-dropzone__msg dz-message needsclick">
                                                <h3 class="m-dropzone__msg-title">Drop files here or click to upload Brand Sale File.</h3>
                                                <span class="m-dropzone__msg-desc">Upload only 1 file</span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xl-6">
                                        <div class="m-section m--align-center">
                                            <div class="m-section__sub">
                                                <a href="#" class="btn btn-success m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                                                    <span>
                                                        <i class="fa fa-file-download" style="font-size: 1.6rem;"></i>
                                                        <span>Download Cocktail Sale Sample File</span>
                                                        <i class="fa fa-cocktail" style="font-size: 1.6rem;"></i>
                                                    </span>
                                                </a>
                                            </div>
                                        </div>
                                        <div class="m-dropzone dropzone m-dropzone--primary dz-clickable" action="inc/api/dropzone/upload.php" id="m-dropzone-two">
                                            <div class="m-dropzone__msg dz-message needsclick">
                                                <h3 class="m-dropzone__msg-title">Drop files here or click to upload Cocktail Sale File.</h3>
                                                <span class="m-dropzone__msg-desc">Upload only 1 file</span>
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

    </div>

    <script src="<%= Page.ResolveClientUrl("~/assets/demo/default/custom/crud/forms/widgets/bootstrap-datepicker.js") %>" type="text/javascript"></script>

</asp:Content>
