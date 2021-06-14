<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="User_Mst.aspx.cs" Inherits="Upkeep_v3.General_Masters.User_Mst" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>

    <style type="text/css">
        .modalBackground {
            background-color: grey;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        /*.modalPopup {
          
            padding: 10px;
            width: 300px;
        }*/

        /*.highlight {
            background-color: blanchedalmond;
        }*/
    </style>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#m_table_1').DataTable({
                //responsive: true,
                pagingType: 'full_numbers',
                scrollX: true,
                //'fnDrawCallback': function(){
                //    init_plugins();
                //}
            });
        });
    </script>

    <script type="text/javascript">
        $(function () {
            $('#<%=FU_UserMst.ClientID %>').change(function () {
                var fileExtension = ['xls', 'xlsx'];
                $('#ImportError_Msg').text('').hide();
                if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
                    //alert("Only '.jpeg','.jpg', '.png', formats are allowed."); 
                    $('#ImportError_Msg').text("Failed!! Please upload Excel file only.").show();
                    $(this).replaceWith($(this).val('').clone(true));
                }

            })


        })
    </script>

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
        <div class="m-content">
            <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-progress">
                    </div>
                    <div class="m-portlet__head-wrapper">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">User Master		
                                </h3>
                            </div>
                        </div>
                        <%--<div class="m-portlet__head-tools">
                            <ul class="m-portlet__nav">
                                <li class="m-portlet__nav-item">
                                    <a href="Add_User_Mst.aspx" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md">
                                        <span>
                                            <i class="la la-plus"></i>
                                            <span>New User</span>
                                        </span>
                                    </a>
                                </li>
                            </ul>
                        </div>--%>

                        <div class="m-portlet__head-tools">
                            <ul class="m-portlet__nav" style="margin-right: 2%;">
                                <li class="m-portlet__nav-item">
                                    <a href="<%= Page.ResolveClientUrl("Add_User_Mst.aspx") %>" class="btn btn-accent  m-btn m-btn--icon" style="padding: 5%;">
                                        <span>

                                            <img src="../assets/app/media/img/icons/Add_Retailer_35.png" />
                                            <span>New User</span>
                                        </span>
                                    </a>
                                </li>
                            </ul>


                            <div class="m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-left" m-dropdown-toggle="hover" style="margin-right: 3%;">

                                <a href="#" class="m-dropdown__toggle btn btn-accent dropdown-toggle" style="padding: 5%; margin-left: 7%;">
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
                                                        <a class="m-nav__link" onserverclick="btnExportExcel_Click" runat="server">
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

                                <cc1:ModalPopupExtender ID="mpeUserMst" runat="server" PopupControlID="pnlImportExport" TargetControlID="btnImportExcelPopup"
                                    CancelControlID="btnCloseHeader" BackgroundCssClass="modalBackground">
                                </cc1:ModalPopupExtender>

                            </div>
                        </div>

                    </div>
                </div>
                <div class="m-portlet__body">

                    <!--begin: Datatable -->
                    <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">


                        <thead>
                            <tr>
                                <th>User Code</th>
                                <th>Name</th>
                                <th>Department</th>
                                <th>Designation</th>
                                <th>Email ID</th>
                                <th>Mobile No</th>
                                <%--<th>Approver</th>
                                <th>Global Approver</th>--%>
                                <th>Created On</th>
                                <th>Actions</th>
                            </tr>

                        </thead>

                        <tbody>
                            <%=bindGrid()%>
                        </tbody>
                    </table>
                </div>
            </div>

            <!-- END EXAMPLE TABLE PORTLET-->
        </div>


        <asp:Panel ID="pnlImportExport" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
            <div class="" id="add_sub_location" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document" style="max-width: 700px;">
                    <div class="modal-content">

                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">Import Data</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">

                            <div class="form-group m-form__group row">
                                <label for="message-text" class="col-xl-2 col-lg-2 form-control-label">Import :</label>
                                <div class="col-xl-4 col-lg-4">
                                    <asp:FileUpload ID="FU_UserMst" runat="server" />
                                </div>
                                <div class="col-xl-6 col-lg-6">
                                    <asp:RequiredFieldValidator ID="rfvImport" runat="server" ControlToValidate="FU_UserMst" ErrorMessage="Please upload a file" ForeColor="Red"
                                        Display="Dynamic" ValidationGroup="ValidationImport"></asp:RequiredFieldValidator>
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

                            </div>

                            <div class="form-group m-form__group row">
                                <div class="col-xl-2 col-lg-2"></div>
                                <div class="col-xl-9 col-lg-9">
                                    <span><b>NOTE</b> - 1. Data must be unique for the columns marked in <span style="color: red;"><b>RED</b></span>.</span><br />
                                    <span>2. Password will be set to <b>123456</b> for all Users being Imported.</span>
                                </div>
                            </div>
                            
                            <div class="form-group m-form__group row">
                                <asp:Label ID="lblImportErrorMsg" Text="" runat="server" CssClass="col-xl-10 col-lg-10 col-form-label" ForeColor="Red"></asp:Label>
                            </div>
                            
                            <div class="form-group m-form__group row">
                                <%--<div class="col-xl-1 col-lg-1"></div>--%>
                                <div class="col-xl-11 col-lg-11" style="overflow-y: auto; height: 210px; display: none;" id="dvErrorGrid" runat="server">
                                    <asp:GridView ID="gvImportError" runat="server" AutoGenerateColumns="true" HeaderStyle-BackColor="#f4f3f8" HeaderStyle-ForeColor="Black"
                                        CssClass="table table-striped- table-bordered table-hover table-checkable">
                                    </asp:GridView>
                                </div>
                            </div>

                            <div class="modal-footer" >
                                <asp:Button ID="btnCloseImportPopUp" Text="Close" OnClick="btnCloseImportPopUp_Click" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>



    </div>














</asp:Content>
