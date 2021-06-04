<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Electricity_Consumption.aspx.cs" Inherits="Upkeep_v3.Electricity_Monitoring.Electricity_Consumption" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content" style="padding: 10px 10px;">
            <div class="m-portlet m-portlet--mobile">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <h3 class="m-portlet__head-text">Electricity Consumption
                            </h3>
                        </div>
                    </div>

                    <div class="col-xl-4 order-1 order-xl-2 m--align-right">
                        <a href="<%= Page.ResolveClientUrl("~/Laundry_Management/Transactions/Vendor_Transactions.aspx") %>" style="margin-top: 5%;" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
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
                        <label for="example-text-input" class="col-3 col-form-label">Select Vendor</label>
                        <div class="col-3">
                           <asp:DropDownList ID="ddlVendor" runat="server" CssClass="form-control" ToolTip="Select Vendor" ></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvddlDepartment" runat="server" ControlToValidate="ddlVendor" ValidationGroup="ValidateVendor"
                                                    ErrorMessage="Please select Vendor" InitialValue="0" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        
                    </div>
                    <div class="form-group m-form__group row" style="margin-bottom: 0rem;">


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

                    <div id="dvTransDetails" runat="server" style="display:none;">
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
                    </div>

                    <div class="form-group m-form__group row" style="margin-bottom: 0rem;">

                        <div class="col-12">
                            <div class="alert m-alert m-alert--default" role="alert">
                                <b>NOTE : </b>If Closing Stock for an Item is <b><span class="m--font-success">POSITIVE</span></b> It means that many <b><i>CLEAN</i></b> Clothes needs to be given from the Department.
                            </div>
                        </div>
                    </div>

                </div>


                <div class="m-portlet__body" style="padding: 0rem 2.2rem 2.2rem 2.2rem;">
                    <asp:HiddenField ID="hdnPrntD" runat="server" ClientIDMode="Static" />
                    <!--end: Search Form -->

                    <!--begin: Datatable -->

                    <asp:GridView ID="gvItemDetails" runat="server" Width="100%" AllowPaging="true" 
                        PageSize="10" AllowSorting="true" AutoGenerateColumns="false" HeaderStyle-BackColor="#5867dd"
                        HeaderStyle-ForeColor="white" CellPadding="5" AlternatingRowStyle-BackColor="#E7F3FF"
                        PagerStyle-HorizontalAlign="Center" PagerStyle-Mode="NumericPages" PagerSettings-Mode="Numeric"
                        PagerSettings-Position="Bottom" ClientIDMode="Static">
                        <Columns>

                            <asp:BoundField DataField="Item_Desc" HeaderText="Item Name" HeaderStyle-Width="15%" />
                            <asp:BoundField DataField="Opening_Stock" HeaderText="Opening Stock" HeaderStyle-Width="15%" />

                            <asp:TemplateField HeaderText="Soiled Given" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="15%">
                                <ItemTemplate>

                                    <%--<asp:TextBox ID="txtOpening" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Opening_Stock"))%>' Style="display: none;"></asp:TextBox>--%>
                                    <asp:TextBox ID="txtSoiledGiven" Width="90%" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"SoiledGiven"))%>' onkeyup="functionCalculation()"></asp:TextBox>
                                    <asp:HiddenField ID="hdnStock_ID" runat="server" Value='<%#(DataBinder.Eval(Container.DataItem,"Stock_ID"))%>' />
                                    <asp:HiddenField ID="hdnOpening_Stock" runat="server" Value='<%#(DataBinder.Eval(Container.DataItem,"Opening_Stock"))%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Cleaned Collected" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCleanedCollected" Width="90%" CssClass="numeric" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"CleanedCollected"))%>' onkeyup="functionCalculation()"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Rewash" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="15%">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtRewash" Width="90%" CssClass="numeric" runat="server" Text='<%#(DataBinder.Eval(Container.DataItem,"Rewash"))%>' onkeyup="functionCalculation()"></asp:TextBox>
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
                    <div style="text-align: center;" id="dvSave" runat="server">
                        <a style="margin-top: 5%;" runat="server" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
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



    </div>


</asp:Content>
