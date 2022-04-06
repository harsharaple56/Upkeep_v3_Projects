<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Brand_Opening_Stock.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Setup.Brand_Opening_Stock" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .modalBackground {
            background-color: grey;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            /*background-color: #fff;
            border: 3px solid #ccc;*/
            padding: 10px;
            width: 300px;
        }

        .form-group {
            margin-bottom: 0rem;
        }
    </style>
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
        });
    </script>



    <div runat="server">
        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
        <div class="m-grid__item m-grid__item--fluid">
            <div class="m-content">
                <div class="m-portlet m-portlet--mobile">

                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Add Your Brand Opening Stock	
                                </h3>
                            </div>
                        </div>
                        <div class="m-portlet__head-tools">
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

                                        <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Setup/Add_Brand_Opening_Stock.aspx") %>"
                                            class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                                            <span>
                                                <i class="flaticon-add"></i>
                                                <span>Add Brand Opening</span>
                                            </span>
                                        </a>
                                    </li>

                                </ul>

                                <ul class="m-portlet__nav">
                                    <li class="m-portlet__nav-item m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover" aria-expanded="true">

                                        <a href="#" class="btn m-btn--pill    btn-primary m-btn m-btn--custom">
                                            <span>
                                                <i class="fa flaticon-grid-menu"></i>
                                                <span>Import & Export Data</span>
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
                                                                <a class="m-nav__link" id="A1" runat="server" onserverclick="btnExport_Click">
                                                                    <i class="m-nav__link-icon la la-file-excel-o" style="font-size: 2rem"></i>
                                                                    <span class="m-nav__link-text">Excel <b>( .xls )</b></span>
                                                                </a>
                                                            </li>

                                                            <li class="m-nav__item">
                                                                <a class="m-nav__link" id="A2" runat="server" onserverclick="btnPdf_Click">
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

                    </div>

                    <div class="m-portlet__body">

                        <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">
                            <thead>
                                <tr>
                                    <th>License Name</th>
                                    <th>Category</th>
                                    <th>Brand Name</th>
                                    <th>Size</th>
                                    <th>Bottle Qty</th>
                                    <th>SPeg Qty</th>
                                    <th>Bottle Rate</th>
                                    <th>Base Qty</th>
                                    <th>Re-Order Level</th>
                                    <th>Optimum Level</th>
                                    <th>Actions</th>
                                </tr>
                            </thead>

                            <tbody>
                                <%=BindBrandOpening()%>
                            </tbody>
                        </table>

                    </div>
                </div>
            </div>
        </div>

    </div>

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
                        <asp:LinkButton Style="margin-right: 250px;" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" ClientIDMode="Static">
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
