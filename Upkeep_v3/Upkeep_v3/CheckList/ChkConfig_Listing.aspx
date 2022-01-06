<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="ChkConfig_Listing.aspx.cs" Inherits="Upkeep_v3.CheckList.ChkConfig_Listing" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            //$(document).on("click", ".btnModalLink", function () {
            //    var newUrl = $(this).data('url');
            //    $(".modal-body #hLink").html(newUrl);
            //    $(".modal-body #hLink").attr("href", newUrl)
            //    $("#" + newUrl.substr(newUrl.length - 5)).show();
            //    // As pointed out in comments, 
            //    // it is unnecessary to have to manually call the modal.
            //    // $('#addBookDialog').modal('show');
            //    //jQuery("#demo").qrcode("url or text");
            //    // or
            //    //$('#demo').qrcode(newUrl);
            //});

            $(".removeItem").click(function (event) {
                //var row_index = $(this).parent().parent().index();
                //alert(row_index);
                var ConfigID = $(this).attr("data-config-id");
                //alert(ConfigID);
                $("#hdnDeleteID").val("");
                //alert($("#hdnDeleteID").val());
                $("#hdnDeleteID").val(ConfigID);
                // alert($("#hdnDeleteID").val());
                document.getElementById("btnDelete").click();
            });

        });
    </script>

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
        $(function () {
            $('#<%=FU_ChecklistMst.ClientID %>').change(function () {
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="m-portlet m-portlet--mobile">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <h3 class="m-portlet__head-text">My Checklist		
                            </h3>
                        </div>
                    </div>

                    <%--<div class="col-xl-4 order-1 order-xl-2 m--align-right">
                        <a href="<%= Page.ResolveClientUrl("~/CheckList/CheckList_Configuration.aspx") %>" style="margin-top: 5%;" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                            <span>
                                <i class="la la-plus"></i>
                                <span>New Checklist</span>
                            </span>
                        </a>
                        <div class="m-separator m-separator--dashed d-xl-none"></div>
                    </div>--%>

                    <div class="m-portlet__head-tools">
                        <ul class="m-portlet__nav" style="margin-right: 2%;">
                            <li class="m-portlet__nav-item">
                                <a href="<%= Page.ResolveClientUrl("~/CheckList/CheckList_Configuration.aspx") %>" style="margin-top: 5%;" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                                    <span>
                                        <i class="la la-plus"></i>
                                        <span>New Checklist</span>
                                    </span>
                                </a>
                            </li>
                        </ul>


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
                <div class="m-portlet__body">
                    <!--begin: Search Form -->
                    <asp:HiddenField ID="hdnDeleteID" runat="server" ClientIDMode="Static" />
                    <asp:Button ID="btnDelete" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" ClientIDMode="Static"
                        Style="display: none;" OnClick="btnDelete_Click" Text="Search" />
                    <!--end: Search Form -->

                    <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" style="font-size: larger;" Text=""></asp:Label>

                    <!--begin: Datatable -->
                    <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1" width="100%">
                        <thead>
                            <tr>
                                <%--<th title="Field #1" data-field="SrNo">Sr. No</th>--%>
                                <%--<th title="Config ID" data-field="Chk_Config_ID">Checklist Config ID</th>--%>
                                <th>Checklist Title</th>

                                <%--<th>Is Enable Score</th>--%>
                                <th>Total Score</th>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                <th>Created By</th>
                                <th>Created Date</th>
                                <th>Updated By</th>
                                <th>Updated Date</th>
                                <th>Action</th>

                            </tr>
                        </thead>
                        <tbody>
                            <%=fetchChkRequestListing()%>
                        </tbody>
                    </table>

                    <!--end: Datatable -->

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
                                    <asp:FileUpload ID="FU_ChecklistMst" runat="server" />
                                </div>
                                <div class="col-xl-6 col-lg-6">
                                    <asp:RequiredFieldValidator ID="rfvImport" runat="server" ControlToValidate="FU_ChecklistMst" ErrorMessage="Please upload a file" ForeColor="Red"
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

                            <div class="modal-footer">
                                <asp:Button ID="btnCloseImportPopUp" Text="Close" OnClick="btnCloseImportPopUp_Click" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>



    </div>


    <%--</form>--%>
</asp:Content>

