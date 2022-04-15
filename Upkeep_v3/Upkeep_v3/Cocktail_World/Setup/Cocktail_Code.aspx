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
                                                        <a class="m-nav__link" id="exce" runat="server" onserverclick="exce_ServerClick">
                                                            <i class="m-nav__link-icon la la-file-excel-o" style="font-size: 2rem"></i>
                                                            <span class="m-nav__link-text">Excel <b>( .xls )</b></span>
                                                        </a>
                                                    </li>

                                                    <li class="m-nav__item">
                                                        <a class="m-nav__link" id="pdf" runat="server" onserverclick="pdf_ServerClick">
                                                            <i class="m-nav__link-icon la la-file-pdf-o" style="font-size: 2rem"></i>
                                                            <span class="m-nav__link-text">Pdf  <b>( .pdf )</b></span>
                                                        </a>
                                                    </li>

                                                </ul>
                                                <br />
                                                <ul class="m-nav">
                                                    <li class="m-nav__section m-nav__section--first">
                                                        <span class="m-nav__section-text"><i class="fa fa-file-import"></i>Import Data</span>
                                                    </li>
                                                    <hr />
                                                    <li class="m-nav__item">
                                                        <asp:LinkButton class="m-nav__link" runat="server" ID="btnImportExcelPopup">
                                                <span>
                                                      <i class="m-nav__link-icon la la-file-excel-o" style="font-size: 2rem"></i>
                                                     <span class="m-nav__link-text">&nbsp;Import <b>( .xls )</b></span>
                                                </span>
                                                        </asp:LinkButton>

                                                        <cc1:ModalPopupExtender ID="mpeUserMst" runat="server" PopupControlID="pnlImportExport" TargetControlID="btnImportExcelPopup"
                                                            CancelControlID="btnCloseHeader1" BackgroundCssClass="modalBackground">
                                                        </cc1:ModalPopupExtender>
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


                     <div class="form-group m-form__group row">
                        <div class="col-4"></div>
                        <div class="col-4"></div>
                        <div class="col-4">
                            <%--<label for="example-search-input" class="col-1 col-form-label">License :</label>--%>
                            <asp:DropDownList ID="ddlLicense_grd" class="form-control" Style="width: 100%" AutoPostBack="true" runat="server"></asp:DropDownList>
                        </div>
                    </div>


                    <!--end: Search Form -->

                    <!--begin: Datatable -->
                    <table class="m-datatable" id="html_table" width="100%">
                        <thead>
                            <tr>
                                <th>Cocktail Name</th>
                                <th>Cocktail Code</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>

                            <%=bindgrid()%>
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
                                    <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">License Name :</label>
                                    <asp:DropDownList OnSelectedIndexChanged="ddlLicense_SelectedIndexChanged" ID="ddlLicense" class="form-control" Style="width: 60%" AutoPostBack="true" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlLicense" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationWorkflow" ForeColor="Red" ErrorMessage="Please Select License"></asp:RequiredFieldValidator>
                                </div>

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
                                <asp:Button ID="btnCloseCategory" OnClick="btnCloseCategory_Click" Text="Close" runat="server" class="btn btn-danger"  />
                                <asp:Button ID="btnLicenseSave" OnClick="btnLicenseSave_Click" runat="server" class="btn btn-primary" CausesValidation="true" ValidationGroup="validationWorkflow"  Text="Save" />
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

     <asp:Panel ID="pnlImportExport" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
        <div class="" id="add_sub_location1" tabindex="-1" aria-labelledby="exampleModalLabel1" aria-hidden="true">
            <div class="modal-dialog" role="document" style="max-width: 700px;">
                <div class="modal-content">

                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel1">Import Data</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader1" runat="server">
                            <span aria-hidden="true">&times;</span>
                        </button>


                    </div>
                    <div class="modal-body">

                        <div class="form-group m-form__group row">
                            <label for="message-text" class="col-xl-2 col-lg-2 form-control-label">Import :</label>
                            <div class="col-xl-8 col-lg-4 custom-file">
                                <asp:FileUpload ID="FU_Category" CssClass="custom-file-input" runat="server" />
                                <label class="custom-file-label" for="FU_Category">Choose file</label>

                            </div>
                            <div class="col-xl-6 col-lg-6">
                                <asp:RequiredFieldValidator ID="rfvImport" runat="server" ControlToValidate="FU_Category" ErrorMessage="Please upload a file" ForeColor="Red"
                                    Display="Dynamic" ValidationGroup="ValidationImport"></asp:RequiredFieldValidator>
                                <span id="ImportError_Msg" style="color: red;"></span>
                            </div>
                        </div>

                        <div class="form-group m-form__group row">
                            <asp:Label ID="lblImportErrorMsg" Text="" runat="server" CssClass="col-xl-10 col-lg-10 col-form-label" ForeColor="Red"></asp:Label>
                        </div>

                        <div class="form-group m-form__group row" style="justify-content: center;">
                            <div class="col-xl-11 col-lg-11" style="overflow-y: auto; height: 210px; display: none;" id="dvErrorGrid" runat="server">
                                <asp:GridView ID="gvImportError" runat="server" AutoGenerateColumns="true" HeaderStyle-BackColor="#f4f3f8" HeaderStyle-ForeColor="Black"
                                    CssClass="table table-striped- table-bordered table-hover table-checkable">
                                </asp:GridView>
                            </div>
                        </div>
                    </div>


                    <div class="modal-footer">
                        <asp:LinkButton Style="margin-right: 250px;" ID="lnk" OnClick="lnk_Click" runat="server" ClientIDMode="Static">
                                    <img src="../../assets/app/media/img/icons/download_sample_26.png" />
                                    <span>Download Sample Import File</span>
                        </asp:LinkButton>
                        <asp:Button ID="btnImportExcel" Text="Import" runat="server" OnClick="btnImportExcel_Click" ValidationGroup="ValidationImport" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" />
                        <asp:Button ID="btnCloseImportPopUp" Text="Close" runat="server" OnClick="btnCloseImportPopUp_Click" class="btn btn-danger  m-btn m-btn--icon m-btn--wide m-btn--md" />
                    </div>

                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
