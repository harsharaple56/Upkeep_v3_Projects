<%@ Page Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Import_Master.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Setup.Import_Master" %>

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
            padding: 10px;
            width: 300px;
        }

        .btnchange {
            margin-top: 30px;
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

            var Redirect = $("input[name=Redirect]").val();
            if (Redirect != undefined) {
                Swal.fire(
                    'Success..!',
                    'Your data successfully imported!',
                    'success'
                )
            }
        });
    </script>

    <div runat="server">
        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <div class="m-content">
                <div class="m-portlet m-portlet--mobile">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Import Master		
                                </h3>
                            </div>
                        </div>
                        <div class="m-portlet__head-tools">
                            <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Setup/Setup.aspx") %>" class="btn btn-metal m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m--margin-right-10">
                                <span>
                                    <i class="la la-arrow-left"></i>
                                    <span>Back</span>
                                </span>
                            </a>
                        </div>
                    </div>

                    <div class="m-portlet__body">


                        <div class="m-form m-form--fit m--margin-bottom-20">
                            <div class="row m--align-center">

                                <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">

                                    <label class="font-weight-bold">Select License :</label>
                                    <asp:DropDownList ID="ddlLicense" AutoPostBack="false" class="form-control m-input" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlLicense" ValidationGroup="validationDept"
                                        ErrorMessage="Please select License" InitialValue="0" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>

                                <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                                    <label class="font-weight-bold">Select Master :</label>
                                    <asp:DropDownList OnSelectedIndexChanged="ddlMaster_SelectedIndexChanged" ID="ddlMaster" AutoPostBack="true" class="form-control m-input" runat="server">
                                        <asp:ListItem Text="--Select Master--" Value="0" />
                                        <asp:ListItem Text="Brand" Value="1" />
                                        <asp:ListItem Text="Supplier" Value="2" />
                                        <asp:ListItem Text="Brand Opening" Value="3" />
                                        <asp:ListItem Text="Brand Code" Value="4" />
                                        <asp:ListItem Text="Cocktail Code" Value="5" />
                                        <asp:ListItem Text="Cocktail" Value="6" />
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlMaster" ValidationGroup="validationDept"
                                        ErrorMessage="Please select Master" InitialValue="0" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>


                                <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                                    <label class="font-weight-bold">Select Format :</label>
                                    <asp:DropDownList ID="ddlFormat" AutoPostBack="true" class="form-control m-input" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlFormat" ValidationGroup="validationDept"
                                        ErrorMessage="Please select License" InitialValue="0" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>

                                <div class="col-lg-3 m--margin-bottom-10-tablet-and-mobile">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="btnImportExcelPopup" ValidationGroup="validationDept" runat="server" class="btnchange btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                                <span>
                                    <i class="fa fa-file-import"></i>
                                    <span>Import File</span>
                                </span>
                                            </asp:LinkButton>
                                            <cc1:ModalPopupExtender ID="mpeUserMst" runat="server" PopupControlID="pnlImportExport" TargetControlID="btnImportExcelPopup"
                                                CancelControlID="btnCloseHeader1" BackgroundCssClass="modalBackground">
                                            </cc1:ModalPopupExtender>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlMaster" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>


                            </div>


                        </div>
                    </div>
                </div>

                <!-- END EXAMPLE TABLE PORTLET-->
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
