<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cocktail_Code.aspx.cs" MasterPageFile="~/UpkeepMaster.Master" Inherits="Upkeep_v3.Cocktail_World.Setup.Cocktail_Code" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets/demo/custom/crud/metronic-datatable/base/html-table.js") %>" type="text/javascript"></script>


     <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
    <div class="m-content">
        <div class="m-grid__item m-grid__item--fluid">

            <div class="m-portlet m-portlet--mobile">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <h3 class="m-portlet__head-text">Cocktail Code
                            </h3>
                        </div>
                    </div>

                    <div class="m-portlet__head-tools">
                        <ul class="m-portlet__nav">

                            <li class="m-portlet__nav-item">
                                <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Setup/Setup.aspx") %>" class="btn m-btn--pill    btn-metal m-btn m-btn--custom">
                                    <span>
                                        <i class="la la-arrow-left"></i>
                                        <span>Back</span>
                                    </span>
                                </a>
                            </li>

                            <li class="m-portlet__nav-item">

                                <asp:LinkButton ID="btnAddLicense" runat="server" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                                <span>
                                    <i class="flaticon-add"></i>
                                    <span>Assign Cocktail Code</span>
                                </span>
                                </asp:LinkButton>
                                <cc1:ModalPopupExtender ID="mpeLicenseMaster" runat="server" PopupControlID="pnlLicenseMaster" TargetControlID="btnAddLicense" BackgroundCssClass="modalBackground"
                                    CancelControlID="btnCloseHeader" />
                            </li>


                        </ul>

                        <ul class="m-portlet__nav">
                            <li class="m-portlet__nav-item m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover" aria-expanded="true">

                                <a href="#" class="btn m-btn--pill    btn-primary m-btn m-btn--custom">
                                    <span>
                                        <i class="fa flaticon-grid-menu"></i>
                                        <span>Export Data</span>
                                    </span>

                                </a>
                                <div class="m-dropdown__wrapper" style="z-index: 101;">
                                    <span class="m-dropdown__arrow m-dropdown__arrow--right m-dropdown__arrow--adjust" style="left: auto; right: 72.5px;"></span>
                                    <div class="m-dropdown__inner">
                                        <div class="m-dropdown__body">
                                            <div class="m-dropdown__content">
                                                <ul class="m-nav">
                                                    <li class="m-nav__section m-nav__section--first">
                                                        <span class="m-nav__section-text"><i class="fa fa-database"></i>Export Data</span>
                                                    </li>
                                                    <hr />

                                                    <li class="m-nav__item">
                                                        <a class="m-nav__link" id="A1" runat="server">
                                                            <i class="m-nav__link-icon la la-file-excel-o" style="font-size: 2rem"></i>
                                                            <span class="m-nav__link-text">Excel <b>( .xls )</b></span>
                                                        </a>
                                                    </li>

                                                    <li class="m-nav__item">
                                                        <a class="m-nav__link" id="A2" runat="server">
                                                            <i class="m-nav__link-icon la la-file-pdf-o" style="font-size: 2rem"></i>
                                                            <span class="m-nav__link-text">Pdf  <b>( .pdf )</b></span>
                                                        </a>
                                                    </li>

                                                </ul>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </li>

                        </ul>
                    </div>
                </div>
                <div class="m-portlet__body">
                    <!--begin: Search Form -->


                    <div class="m-form m-form--fit m--margin-bottom-20">
                        <div class="row m--align-center">
                        </div>


                    </div>


                    <!--end: Search Form -->

                    <!--begin: Datatable -->
                    <table class="m-datatable" id="html_table" width="100%">
                        <thead>
                            <tr>
                                <th title="Ticket Number" data-field="TicketNo">Ticket Number</th>
                                <%--<th title="Field #2" data-field="Owner">Zone</th>--%>
                                <th title="Location" data-field="Location">Location</th>
                                <%--<th title="Field #4" data-field="CarMake">Sub Location</th>--%>
                                <th title="Category" data-field="Cat">Category</th>
                                <th title="Sub Category" data-field="SubCat">Sub Category</th>
                                <th title="Request Date" data-field="RequestDate">Request Date</th>
                                <th title="Raised By" data-field="RaisedBy">RaisedBy</th>
                                <th title="Down Time" data-field="Down_Time">Down Time</th>
                                <th title="Request Status" data-field="RequestStatus">Request Status</th>
                                <th title="Action Status" data-field="ActionStatus">Action Status</th>
                                <%--<th title="Field #10" data-field="Type">View</th>--%>
                            </tr>
                        </thead>
                        <tbody>

                            <%--<%=bindgrid()%>--%>
                        </tbody>
                    </table>

                    <!--end: Datatable -->

                </div>
            </div>


        </div>

    </div>

    <asp:Panel ID="pnlLicenseMaster" runat="server" align="center" Style="display: none; width: 50%;">
        <div class="" id="add_sub_location" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLabel">Assign Cocktail Code</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>

                            <div class="modal-body">

                                <div class="form-group m-form__group row">
                                    <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Cocktail Name :</label>
                                    <asp:DropDownList ID="ddlCocktail" class="form-control" Style="width: 60%" AutoPostBack="true" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvBrand" runat="server" ControlToValidate="ddlCocktail" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationWorkflow" ForeColor="Red" ErrorMessage="Please Select Cocktail"></asp:RequiredFieldValidator>
                                </div>


                                <div class="form-group m-form__group row">
                                    <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Cocktail Code :</label>
                                    <asp:TextBox ID="txtcode" runat="server" class="form-control" Style="width: 60%;" onkeypress="return RestrictSpaceSpecial(event)"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcode" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationWorkflow" ForeColor="Red" ErrorMessage="Please enter cocktail code"></asp:RequiredFieldValidator>
                                </div>


                                <asp:Label ID="lblError" ForeColor="Red" runat="server" CssClass="form-control-label"></asp:Label>

                            </div>

                            <div class="modal-footer">
                                <asp:Button ID="btnCloseCategory" Text="Close" runat="server" class="btn btn-danger"  />
                                <asp:Button ID="btnLicenseSave" runat="server" class="btn btn-primary" CausesValidation="true" ValidationGroup="validationWorkflow"  Text="Save" />
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnAddLicense" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <!-- End Modal -->
    </asp:Panel>
</asp:Content>
