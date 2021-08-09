<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Add_Purchases.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Transactions.Add_Purchases" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>

    <style type="text/css">
        .auto-style1 {
            height: 21px;
        }
    </style>
    <script type="text/javascript">

        $(document).ready(function () {
            $('.datetimepicker').datepicker({
                todayHighlight: true,
                autoclose: true,
                pickerPosition: 'bottom-right',
                format: 'dd-MM-yyyy',
                showMeridian: true,
            }).on('changeDate', function (event) {
                var startDate = moment($('#txtVMSDate').val(), 'dd-MM-yyyy hh:mm A').valueOf();
                $('#error_endDate').html('').parents('.form-group').removeClass('has-error');
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



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

                                <asp:DropDownList ID="m_form_type" runat="server" CssClass="form-control" ClientIDMode="Static">
                                    <asp:ListItem Value="All" Text="Select License / Outlet"></asp:ListItem>
                                    <asp:ListItem Value="In Progress" Text="In Progress"></asp:ListItem>
                                    <asp:ListItem Value="Accepted" Text="Accepted"></asp:ListItem>
                                    <asp:ListItem Value="Assigned" Text="Assigned"></asp:ListItem>
                                    <asp:ListItem Value="Hold" Text="Hold"></asp:ListItem>
                                    <asp:ListItem Value="Closed" Text="Closed"></asp:ListItem>
                                    <asp:ListItem Value="Expired" Text="Expired"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Transactions/Purchases.aspx") %>" class="col-lg-2 btn btn-metal m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m--margin-right-10">
                            <span>
                                <i class="la la-arrow-left"></i>
                                <span>Back</span>
                            </span>
                        </a>
                        <a href="#" class="col-lg-3 btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                            <span>
                                <i class="fa fa-save"></i>
                                <span>Save Transaction</span>
                            </span>
                        </a>
                    </div>

                </div>

                <div class="m-portlet m-portlet--tabs">

                    <div class="m-portlet__head ">
                        <div class="m-portlet__head-tools">
                            <ul class="nav nav-tabs m-tabs-line m-tabs-line--primary m-tabs-line--2x m--align-center" role="tablist">
                                <li class="nav-item m-tabs__item">
                                    <a class="nav-link m-tabs__link active show" data-toggle="tab" href="#m_portlet_base_demo_1_1_tab_content" role="tab" aria-selected="true">
                                        <i class="fa fa-wine-bottle" style="font-size: 2rem;"></i>Add Purchase Data
                                    </a>
                                </li>
                                <li class="nav-item m-tabs__item">
                                    <a class="nav-link m-tabs__link" data-toggle="tab" href="#m_portlet_base_demo_1_3_tab_content" role="tab" aria-selected="false">
                                        <i class="fa fa-file-import" style="font-size: 2rem;"></i>Import Purchase Data
                                    </a>
                                </li>
                                <li class="nav-item m-tabs__item"></li>
                            </ul>
                        </div>
                    </div>

                    <div class="m-portlet__body">
                        <div class="tab-content">
                            <div class="tab-pane active show" id="m_portlet_base_demo_1_1_tab_content" role="tabpanel">

                                <form class="m-form m-form--fit m--margin-bottom-20">



                                    <div class="row m--margin-bottom-20 m--align-center">
                                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                                            <label class="font-weight-bold">Select Purchase Date</label>

                                            <div class="m-form__control">
                                                <div class="input-group date">
                                                    <input type="text" class="form-control m-input" id="m_datepicker_3">
                                                    <div class="input-group-append">
                                                        <span class="input-group-text">
                                                            <i class="la la-calendar" style="font-size: 2rem;"></i>
                                                        </span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4 m--margin-bottom-10-tablet-and-mobile">
                                            <label class="font-weight-bold">Select Brand</label>
                                            <div class="m-form__control">
                                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" ClientIDMode="Static">
                                                    <asp:ListItem Value="All" Text="All"></asp:ListItem>
                                                    <asp:ListItem Value="Open" Text="Open"></asp:ListItem>
                                                    <asp:ListItem Value="Parked" Text="Parked"></asp:ListItem>
                                                    <asp:ListItem Value="Closed" Text="Closed"></asp:ListItem>
                                                    <asp:ListItem Value="Expired" Text="Expired"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-2 m--margin-bottom-10-tablet-and-mobile">
                                            <label class="font-weight-bold">Select Size</label>

                                            <div class="m-form__control">
                                                <asp:DropDownList ID="m_form_status" runat="server" CssClass="form-control" ClientIDMode="Static">
                                                    <asp:ListItem Value="All" Text="All"></asp:ListItem>
                                                    <asp:ListItem Value="Open" Text="Open"></asp:ListItem>
                                                    <asp:ListItem Value="Parked" Text="Parked"></asp:ListItem>
                                                    <asp:ListItem Value="Closed" Text="Closed"></asp:ListItem>
                                                    <asp:ListItem Value="Expired" Text="Expired"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>



                                        </div>

                                        <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                                            <label class="font-weight-bold">Add Brand</label>
                                            <div class="m-form__control">
                                                <button class="btn btn-success m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air" id="btn_AddBrand" runat="server">
                                                    <span>
                                                        <i class="fa fa-plus"></i>
                                                        <span>Add Selected Brand</span>
                                                    </span>
                                                </button>
                                            </div>

                                        </div>
                                    </div>
                                </form>

                                <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1" width="100%">
                                    <thead>
                                        <tr>
                                            <th>Delete</th>

                                            <th>Brand</th>
                                            <th>Size</th>

                                            <th>Stock Qty</th>
                                            <th>Bottle Qty</th>
                                            <th>Bottle Rate</th>
                                            <th>SPeg Qty</th>
                                            <th>SPeg Rate</th>
                                            <th>LPeg Qty</th>
                                            <th>LPeg Rate</th>
                                            <th>Total Amount</th>
                                            <th>Tax Amt</th>
                                            <th>Permit Holder</th>


                                        </tr>
                                    </thead>

                                    <tbody>
                                        <%--<%=Fetch_Department_Transactions()%>--%>
                                    </tbody>
                                </table>

                            </div>
                            <div class="tab-pane" id="m_portlet_base_demo_1_3_tab_content" role="tabpanel">
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
                    </div>
                </div>
            </div>


        </div>

    </div>
    
    <script src="<%= Page.ResolveClientUrl("~/assets/demo/default/custom/crud/forms/widgets/bootstrap-datepicker.js") %>" type="text/javascript"></script>

</asp:Content>
