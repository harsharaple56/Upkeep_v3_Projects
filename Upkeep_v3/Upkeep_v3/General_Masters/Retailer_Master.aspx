<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Retailer_Master.aspx.cs" Inherits="Upkeep_v3.General_Masters.Retailer_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>

    <%-- <script src="<%= Page.ResolveClientUrl("~/assets/demo/default/custom/crud/datatables/extensions/buttons.js") %>" type="text/javascript"></script>--%>

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

        /*.highlight {
            background-color: blanchedalmond;
        }*/
    </style>


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

        $("#btnDownloadSampleFile").click(function () {
            // // hope the server sets Content-Disposition: attachment!
            //window.location = '~/General_Masters/Template/RetailerData.xlsx';
        });

    </script>

    <script type="text/javascript">
        $(function () {
            $('#<%=FU_RetailerMst.ClientID %>').change(function () {
                var fileExtension = ['xls', 'xlsx'];
                $('#ImportError_Msg').text('').hide();
                if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
                    //alert("Only '.jpeg','.jpg', '.png', formats are allowed."); 
                    $('#ImportError_Msg').text("Failed!! Please upload Excel file only.").show();
                    $(this).replaceWith($(this).val('').clone(true));
                }
                //100000 Byte -- 100 KB
                //if ($(this).get(0).files[0].size > (100000)) {
                //    $('#ImportError_Msg').text("Failed!! Max allowed file size is 100 KB").show();
                //    $(this).replaceWith($(this).val('').clone(true));
                //}
            })


        })
    </script>


    <div runat="server" id="frmMain">
        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <div class="">
                <div class="m-portlet m-portlet--mobile">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Retailers		
                                </h3>
                            </div>
                        </div>
                        <div class="m-portlet__head-tools">
                            <ul class="m-portlet__nav" style="margin-right: 2%;">
                                <li class="m-portlet__nav-item">
                                    <a href="<%= Page.ResolveClientUrl("Add_Retailer.aspx") %>" class="btn btn-accent  m-btn m-btn--icon" style="padding: 5%;">
                                        <span>
                                            
                                            <img src="../assets/app/media/img/icons/Add_Retailer_35.png" />
                                            <span>New Retailer</span>
                                        </span>
                                    </a>
                                </li>
                                <%-- <asp:ImageButton ID="imgBtnExcel" runat="server" ImageUrl="../assets/app/media/img/icons/excel_32.png" ToolTip="Import Export Wizard" />--%>
                            </ul>


                            <div class="m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-left" m-dropdown-toggle="hover" style="margin-right: 3%;">

                                <a href="#" class="m-dropdown__toggle btn btn-accent dropdown-toggle" style="padding: 5%;margin-left: 7%;">
                                    <img src="../assets/app/media/img/icons/database_export_35.png" />
                                    Export
                                </a>
                                <div class="m-dropdown__wrapper">
                                    <span class="m-dropdown__arrow m-dropdown__arrow--left"></span>
                                    <div class="m-dropdown__inner">
                                        <div class="m-dropdown__body">
                                            <div class="m-dropdown__content">
                                                <ul class="m-nav">
                                                    <li class="m-nav__item">
                                                        <a class="m-nav__link" onserverclick="btnExport_Click" runat="server">
                                                            <i class="m-nav__link-icon fa fa-file-excel "></i>
                                                            <span class="m-nav__link-text">Excel</span>
                                                        </a>
                                                    </li>
                                                    <li class="m-nav__item">
                                                        <a class="m-nav__link" onserverclick="btnExportPDF_Click" runat="server">
                                                            <i class="m-nav__link-icon fa fa-file-pdf"></i>
                                                            <span class="m-nav__link-text">PDF</span>
                                                        </a>
                                                    </li>
                                                    <%--<li class="m-nav__item">
																			<a href="" class="m-nav__link">
																				<i class="m-nav__link-icon flaticon-chat-1"></i>
																				<span class="m-nav__link-text">CSV</span>
																			</a>
																		</li>--%>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            &nbsp;&nbsp;
                            <div>
                                <ul class="m-portlet__nav">
                                    <li class="m-portlet__nav-item">
                                        <a class="btn btn-accent  m-btn m-btn--icon" runat="server" id="btnImportExcelPopup" onserverclick="btnImportExcel_Click" style="padding: 5%;">
                                            <span>
                                                <img src="../assets/app/media/img/icons/database_import.png" />
                                                <span>Import</span>
                                            </span>
                                        </a>
                                    </li>
                                </ul>

                            </div>
                        </div>
                    </div>
                    <div class="m-portlet__body">

                        <!--begin: Datatable -->
                        <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">
                            <thead>
                                <tr>
                                    <th>Store Name</th>
                                    <th>Manager Name</th>
                                    <th>Email</th>
                                    <th>Contact</th>
                                    <th>Created on</th>
                                    <th>Action</th>
                                </tr>
                            </thead>

                            <tbody>
                                <%=fetchRetailerDetails()%>
                            </tbody>


                        </table>

                        <div class="m-form m-form--label-align-left- m-form--state- m--margin-10" id="event_form1" runat="server">

                            <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="Export To Excel" class="btn btn-primary btn-success" />

                            <div class="pull-right">
                                <asp:LinkButton ID="lnkSampleFile" runat="server" Text="Download Sample File" OnClick="lnkSampleFile_Click"></asp:LinkButton>
                                <asp:FileUpload ID="fileUpload" runat="server" />
                                <asp:Button ID="btnImportExcel1" runat="server" OnClick="btnImportExcel_Click" Text="Import From Excel" class="btn btn-primary btn-success" />
                                <cc1:ModalPopupExtender ID="mpeSubCategory" runat="server" PopupControlID="pnlImportExport" TargetControlID="btnImportExcelPopup"
                                    CancelControlID="btnCloseHeader" BackgroundCssClass="modalBackground">
                                </cc1:ModalPopupExtender>
                            </div>


                            <!--begin::Modal-->
                            <div class="modal fade" id="import_error_modal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel1" aria-hidden="true">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h5 class="modal-title" id="exampleModalLabel1">Retailer Import Error</h5>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                        </div>
                                        <div class="modal-body">

                                            <%--<asp:GridView ID="gvImportError" runat="server" AutoGenerateColumns="false"></asp:GridView>--%>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <!--end::Modal-->





                        </div>

                        <%--<asp:Button ID="btnExport1" runat="server" OnClick="btnExport_Click" Text="Export To Excel" class="btn btn-primary btn-success" />
                               		<input type="file" name="import_excel" id="import_excel" class="d-none" />
                               		<label for="import_excel">
                                           <button class="btn btn-success">Choose file...</button>
                                	</label>
                                    <asp:Button ID="btnImportExcel" runat="server" OnClick="btnImportExcel_Click" Text="Upload" class="btn btn-primary btn-success" />
                                </form>--%>
                    </div>
                </div>

                <!-- END EXAMPLE TABLE PORTLET-->
            </div>
        </div>


        <asp:Panel ID="pnlImportExport" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
            <div class="" id="add_sub_location" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document" style="max-width: 590px;">
                    <div class="modal-content">
                        <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>--%>

                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Import Data</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader">
                                <span aria-hidden="true">&times;</span>
                                <%-- <asp:Button ID="btnCloseHeader" runat="server" class="Close"/>--%>
                            </button>
                        </div>
                        <div class="modal-body">


                            <div class="form-group m-form__group row">
                                <label for="message-text" class="col-xl-2 col-lg-2 form-control-label">Import :</label>
                                <div class="col-xl-4 col-lg-4">
                                    <asp:FileUpload ID="FU_RetailerMst" runat="server" />
                                </div>
                                <div class="col-xl-6 col-lg-6">
                                    <asp:RequiredFieldValidator ID="rfvImport" runat="server" ControlToValidate="FU_RetailerMst" ErrorMessage="Please upload a file" ForeColor="Red" 
                                        ValidationGroup="ValidationImport" ></asp:RequiredFieldValidator>
                                    <span id="ImportError_Msg" style="color: red;"></span>
                                </div>
                            </div>
                            <div class="form-group m-form__group row">
                                <div class="col-xl-2 col-lg-2 col-form-label"></div>
                                <img src="../assets/app/media/img/icons/download_sample_26.png" />
                               
                                <asp:LinkButton ID="btnDownloadSampleFile" runat="server" OnClick="lnkSampleFile_Click" Text="Download Sample Import File" ClientIDMode="Static"></asp:LinkButton>

                            </div>
                            <div class="form-group m-form__group row">
                                <div class="col-xl-2 col-lg-2"></div>
                                <div class="col-xl-2 col-lg-2">
                                    <asp:Button ID="btnImportExcel" Text="Import" runat="server" OnClick="btnImportExcel_Click" ValidationGroup="ValidationImport" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" />
                                </div>
                                <asp:Label ID="lblImportErrorMsg" Text="" runat="server" CssClass="col-xl-8 col-lg-8 col-form-label" ForeColor="Red"></asp:Label>
                            </div>

                            <div class="form-group m-form__group row">
                                <div class="col-xl-2 col-lg-2"></div>
                                <div class="col-xl-9 col-lg-9">
                                    <span><b>NOTE</b> - Username will be same as * <b>Email</b> & Password will be set to <b>123456</b> for all Retailers being Imported.</span>
                                </div>
                            </div>
                            <br />
                            <div class="form-group m-form__group row"  >
                                <div class="col-xl-1 col-lg-1"></div>
                                <div class="col-xl-10 col-lg-10" style="overflow-y:auto; height:280px; display:none;" id="dvErrorGrid" runat="server">
                                    <asp:GridView ID="gvImportError" runat="server" AutoGenerateColumns="true" HeaderStyle-BackColor="#f4f3f8" HeaderStyle-ForeColor="Black"
                                        CssClass="table table-striped- table-bordered table-hover table-checkable">
                                    </asp:GridView>
                                </div>
                            </div>



                            <div class="modal-footer">
                                <asp:Button ID="btnCloseImportPopUp" Text="Close" OnClick="btnCloseImportPopUp_Click" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" />
                                <%--<asp:Button ID="btnSubCategorySave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" CausesValidation="true" ValidationGroup="validationSubCategory" Text="Save" />--%>
                            </div>
                            <%-- </ContentTemplate>--%>
                            <%--<Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnSubCategorySave" EventName="Click" />
                            </Triggers>--%>
                            <%--</asp:UpdatePanel>--%>
                        </div>
                    </div>
                </div>
                <!-- End Modal -->
        </asp:Panel>


    </div>
</asp:Content>
