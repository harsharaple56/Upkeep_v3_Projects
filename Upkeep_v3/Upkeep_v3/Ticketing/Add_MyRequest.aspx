<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Add_MyRequest.aspx.cs" Inherits="Upkeep_v3.Ticketing.Add_MyRequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>



    <%-- <script src="https://keenthemes.com/preview/metronic/theme/assets/global/plugins/jquery-file-upload/blueimp-gallery/jquery.blueimp-gallery.min.js" type="text/javascript"></script>
        <script src="https://keenthemes.com/preview/metronic/theme/assets/global/plugins/jquery-file-upload/js/jquery.iframe-transport.js" type="text/javascript"></script>
        <script src="https://keenthemes.com/preview/metronic/theme/assets/global/plugins/jquery-file-upload/js/jquery.fileupload.js" type="text/javascript"></script>
        <script src="https://keenthemes.com/preview/metronic/theme/assets/global/plugins/jquery-file-upload/js/jquery.fileupload-process.js" type="text/javascript"></script>
        <script src="https://keenthemes.com/preview/metronic/theme/assets/global/plugins/jquery-file-upload/js/jquery.fileupload-image.js" type="text/javascript"></script>
        <script src="https://keenthemes.com/preview/metronic/theme/assets/global/plugins/jquery-file-upload/js/jquery.fileupload-audio.js" type="text/javascript"></script>
        <script src="https://keenthemes.com/preview/metronic/theme/assets/global/plugins/jquery-file-upload/js/jquery.fileupload-video.js" type="text/javascript"></script>
        <script src="https://keenthemes.com/preview/metronic/theme/assets/global/plugins/jquery-file-upload/js/jquery.fileupload-validate.js" type="text/javascript"></script>
        <script src="https://keenthemes.com/preview/metronic/theme/assets/global/plugins/jquery-file-upload/js/jquery.fileupload-ui.js" type="text/javascript"></script>
     <script src="https://keenthemes.com/preview/metronic/theme/assets/pages/scripts/form-fileupload.min.js" type="text/javascript"></script>--%>

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

        .m-form .m-form__group {
            margin-bottom: 0;
            padding-top: 0px;
            padding-bottom: 0px;
        }
        /*.highlight {
            background-color: blanchedalmond;
        }*/
    </style>

    <script>
        $(document).ready(function () {
            $('#clickmewow').click(function () {
                $('#radio1003').attr('checked', 'checked');
            });

            $('#btnSave').click(function () {
                //debugger;
                $('#ImageUpload_Msg').text('').hide();
                $('#LocationError_Msg').text('').hide();

                if ($('#hdnIs_Retailer').val() == '0') {
                    if ($('#hdnassetLocation').val() == '') {
                        //alert("Please Select Proper Location!");
                        $('#LocationError_Msg').text("Please Select Proper Location").show();
                        return false;
                    }
                }

                if ($('#hdnCategory').val() == '') {
                    //alert("Please Select Proper Location!");
                    $('#CategoryError_Msg').text("Please Select Category").show();
                    return false;
                }

                var Is_ImageUpload_ValidFile = $("#Is_ImageUpload_ValidFile").val();
                //alert(Is_ImageUpload_ValidFile);
                if (Is_ImageUpload_ValidFile == 2) {
                    $('#ImageUpload_Msg').text("Failed!! Please upload jpg, jpeg, png file only.").show();
                    return false;
                }
                else if (Is_ImageUpload_ValidFile == 1) {
                    $('#ImageUpload_Msg').text("Failed!! Max allowed file size is 100 KB").show();
                    return false;
                }

            });

            $("#txtassetLocation").on('input', function () {
                var val = this.value;

                $('#hdnassetLocation').val("");
                if ($('#dlassetLocation option').filter(function () {
                    if (this.value.toUpperCase() === val.toUpperCase()) {
                        //alert($(this).attr('text'));
                        $('#hdnassetLocation').val($(this).attr('text'));
                    }
                    return this.value.toUpperCase() === val.toUpperCase();
                }).length) {
                    //send ajax request
                    //alert(this.id);
                }
            });

            $("#txtCategory").on('input', function () {
                var val = this.value;

                $('#hdnCategory').val("");
                if ($('#dlCategory option').filter(function () {
                    if (this.value.toUpperCase() === val.toUpperCase()) {
                        //alert($(this).attr('text'));
                        $('#hdnCategory').val($(this).attr('text'));
                    }
                    return this.value.toUpperCase() === val.toUpperCase();
                }).length) {
                    //send ajax request
                    //alert(this.id);
                    $("#btnCategoryChange").click();
                }
            });

            $("#txtSubCategory").on('input', function () {
                var val = this.value;

                $('#hdnSubCategory').val("");
                if ($('#dlSubCategory option').filter(function () {
                    if (this.value.toUpperCase() === val.toUpperCase()) {
                        //alert($(this).attr('text'));
                        $('#hdnSubCategory').val($(this).attr('text'));
                    }
                    return this.value.toUpperCase() === val.toUpperCase();
                }).length) {
                    //send ajax request
                    //alert(this.id);
                    $("#btnSubCategoryChange").click();
                }
            });

            function Category_Change() {
                //alert('hi');
                $("#btnCategoryChange").click();
            }

        })
    </script>

    <script type="text/javascript">
        $(function () {
            $('#<%=FileUpload_TicketImage.ClientID %>').change(function () {
                var fileExtension = ['jpeg', 'jpg', 'png'];
                $('#ImageUpload_Msg').text('').hide();
                if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
                    //alert("Only '.jpeg','.jpg', '.png', formats are allowed."); 
                    $('#ImageUpload_Msg').text("Failed!! Please upload jpg, jpeg, png file only.").show();
                    $(this).replaceWith($(this).val('').clone(true));
                    $("#Is_ImageUpload_ValidFile").val("2");

                }
                else {
                    $("#Is_ImageUpload_ValidFile").val("3");
                }
                //100000 Byte -- 100 KB
                if ($(this).get(0).files[0].size > (100000)) {
                    $('#ImageUpload_Msg').text("Failed!! Max allowed file size is 100 KB").show();
                    $(this).replaceWith($(this).val('').clone(true));
                    $("#Is_ImageUpload_ValidFile").val("1");
                }
                else {
                    $("#Is_ImageUpload_ValidFile").val("3");
                }
            })

        })
    </script>


    <%--  <script type="text/javascript">
        function ShowPopup(title, body) {
            alert('hiiiiii');
            $("#pnlTicketSuccess .modal-title").html(title);
            $("#pnlTicketSuccess .modal-body").html(body);
            alert(title);
            alert(body);
            $("#pnlTicketSuccess").modal("show");
        }
    </script>--%>
    <div class="m-content">
        <div class="m-grid__item m-grid__item--fluid">
            <div class="">
                <div class="row">
                    <div class="col-lg-12">

                        <!--begin::Portlet-->
                        <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                            <div class="m-form m-form--label-align-left- m-form--state-" runat="server">
                                <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

                                <div class="m-portlet__head">
                                    <div class="m-portlet__head-progress">

                                        <!-- here can place a progress bar-->
                                    </div>
                                    <div class="m-portlet__head-wrapper">
                                        <div class="m-portlet__head-caption">
                                            <div class="m-portlet__head-title">
                                                <h3 class="m-portlet__head-text">Raise a New Ticket
                                                </h3>
                                            </div>
                                        </div>

                                        <div class="m-portlet__head-tools">

                                            <a href="<%= Page.ResolveClientUrl("~/Ticketing/MyRequest.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                                <span>
                                                    <i class="la la-arrow-left"></i>
                                                    <span>Back</span>
                                                </span>
                                            </a>


                                            
                                            <a OnserverClick="btnSave_Click" runat="server" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                                                Save

                                            </a>
                                            
                                            <asp:Button ID="btnTest" Style="display: none;" runat="server" />
                                                <cc1:ModalPopupExtender ID="mpeTicketSaveSuccess" runat="server" PopupControlID="pnlTicketSuccess" TargetControlID="btnTest"
                                                    CancelControlID="btnCloseHeader2" BackgroundCssClass="modalBackground">
                                            </cc1:ModalPopupExtender>
                                        
                                        
                                        </div>

                                    </div>
                                </div>

                                <div class="m-portlet__body">

                                    <div class="m-form__section m-form__section--first">

                                        <div class="form-group m-form__group row" style="padding-left: 15%; display: none;">
                                            <label class="col-xl-3 col-lg-3 form-control-label">Company :</label>
                                            <div class="col-xl-3 col-lg-3">
                                                <asp:Label ID="lblCompanyName" runat="server" Text="" class="form-control-label"></asp:Label>
                                            </div>
                                        </div>


                                        <div class="m-form__heading" style="text-align: center; padding-top: 10px;">
                                            <h3 class="m-form__heading-title" style="line-height: 2.0; background: aliceblue; font-size: 1.2rem;">Fill Up Ticket Details</h3>
                                        </div>

                                        <asp:UpdatePanel runat="server" style="width: 100%;">
                                            <ContentTemplate>

                                                <div class="form-group m-form__group row" style="padding-left: 10%; display: none;">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Zone :</label>
                                                    <div class="col-xl-5 col-lg-9">
                                                        <asp:DropDownList ID="ddlZone" class="form-control m-input" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlZone" Visible="true" Display="Dynamic"
                                                            ValidationGroup="validateTicket" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Zone"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                    <div class="col-xl-3 col-lg-9">
                                                        <asp:Button ID="btnAddZone" runat="server" class="btn btn-accent  m-btn m-btn--icon" Style="padding: 0.45rem 1.15rem;" OnClick="btnSave_Click" Text="Add Zone" />
                                                    </div>
                                                </div>


                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-2 col-form-label font-weight-bold">
                                                        <span style="color: red;">*</span>
                                                        <span class="fa fa-map-marker-alt" aria-hidden="true"></span>
                                                        Select Location
                                                    </label>
                                                    <div class="col-xl-10 col-lg-9" id="dvRetailerLocation" runat="server">
                                                        <asp:HiddenField ID="hdnIs_Retailer" runat="server" ClientIDMode="Static" />
                                                        <asp:DropDownList ID="ddlLocation" class="form-control m-input" runat="server"></asp:DropDownList>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlLocation" Visible="true" Display="Dynamic"
                                                            ValidationGroup="validateTicket" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Location"></asp:RequiredFieldValidator>--%>
                                                        <asp:Label ID="lblRetailerLocError" runat="server" ForeColor="Red"></asp:Label>
                                                    </div>
                                                    <div class="col-xl-10 col-lg-9" id="dvEmployeeLocation" runat="server">
                                                        <asp:HiddenField ID="hdnassetLocation" runat="server" ClientIDMode="Static" />
                                                        <input list="dlassetLocation" id="txtassetLocation" name="txtassetLocation"
                                                            class="form-control" runat="server" clientidmode="Static" />
                                                        <datalist id="dlassetLocation" runat="server" clientidmode="Static"></datalist>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtassetLocation"
                                                            Display="Dynamic" ValidationGroup="validateTicket" ForeColor="Red" InitialValue="0"
                                                            ErrorMessage="Please select Location"></asp:RequiredFieldValidator>
                                                        <span id="LocationError_Msg" style="color: red;"></span>

                                                    </div>

                                                </div>


                                                <div class="form-group m-form__group row" style="display: none;">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Sub-Location :</label>
                                                    <div class="col-xl-5 col-lg-9">
                                                        <asp:DropDownList ID="ddlSublocation" class="form-control m-input" OnSelectedIndexChanged="ddlSublocation_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlSublocation" Visible="true" Display="Dynamic"
                                                            ValidationGroup="validateTicket" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Sub Location"></asp:RequiredFieldValidator>--%>
                                                    </div>
                                                    <div class="col-xl-3 col-lg-9">
                                                        <asp:Button ID="btnAddSubLoc" runat="server" class="btn btn-accent  m-btn m-btn--icon" Style="padding: 0.45rem 1.15rem;" OnClick="btnSave_Click" Text="Add Sub Location" />
                                                    </div>
                                                </div>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                        <div class="m-form__heading" style="text-align: center; padding-top: 10px;">
                                            <h3 class="m-form__heading-title" style="line-height: 2.0; background: aliceblue; font-size: 1.2rem;">Categorize Your Ticket</h3>
                                        </div>

                                        <div class="form-group m-form__group row m--align-center">
                                            <label class="col-xl-2 col-form-label font-weight-bold">
                                                <span style="color: red;">*</span>
                                                <span class="fa fa-sitemap" aria-hidden="true"></span>
                                                Select Category
                                            </label>

                                            <div class="col-xl-3 col-lg-9">

                                                <asp:HiddenField ID="hdnCategory" runat="server" ClientIDMode="Static" />
                                                <asp:Button ID="btnCategoryChange" runat="server" Style="display: none;" OnClick="btnCategoryChange_Click" ClientIDMode="Static" />

                                                <input list="dlCategory" id="txtCategory" name="txtassetLocation"
                                                    class="form-control" runat="server" clientidmode="Static" />
                                                <datalist id="dlCategory" runat="server" clientidmode="Static"></datalist>

                                                <%--<asp:DropDownList ID="ddlCategory" class="form-control m-input" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>--%>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCategory" Visible="true" Display="Dynamic"
                                                    ValidationGroup="validateTicket" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Category"></asp:RequiredFieldValidator>
                                                <span id="CategoryError_Msg" style="color: red;"></span>
                                            </div>

                                            <label class="col-xl-3 col-form-label font-weight-bold">
                                                <span class="fa fa-sitemap" aria-hidden="true"></span>
                                                Select Sub-Category
                                            </label>

                                            <div class="col-xl-4 col-lg-9">

                                                <asp:HiddenField ID="hdnSubCategory" runat="server" ClientIDMode="Static" />
                                                <asp:Button ID="btnSubCategoryChange" runat="server" Style="display: none;" OnClick="btnSubCategoryChange_Click" ClientIDMode="Static" />

                                                <input list="dlSubCategory" id="txtSubCategory" name="txtassetLocation"
                                                    class="form-control" runat="server" clientidmode="Static" />
                                                <datalist id="dlSubCategory" runat="server" clientidmode="Static"></datalist>

                                                <%--<asp:DropDownList ID="ddlSubCategory" class="form-control m-input" OnSelectedIndexChanged="ddlSubCategory_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>--%>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlSubCategory" Visible="true" Display="Dynamic"
                                                    ValidationGroup="validateTicket" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Sub Category"></asp:RequiredFieldValidator>--%>
                                            </div>

                                        </div>

                                        <div class="form-group m-form__group row m--align-center" id="dvDepartment" runat="server" style="display: none;">
                                            <div class="col-xl-11 m-form__heading" style="text-align: center; padding-top: 10px; padding-bottom: 10px;">
                                                <h5 class="m-form__heading-title m--font-success" style="line-height: 2.0; background: aliceblue; font-size: 1.2rem;">Note: Ticket will be assigned to
                                                    <span id="lblDepartmentName" runat="server"></span> department
                                                </h5>
                                            </div>
                                            <div class="col-xl-1">
                                                <button type="button" id="btnViewWorkflow" runat="server" class="btn btn-success m-btn m-btn--icon m-btn--icon-only" onserverclick="btnViewWorkflow_Click">
                                                    <i class="fa fa-sitemap"></i>
                                                </button>

                                                <cc1:ModalPopupExtender ID="mpeWorkflow" runat="server" PopupControlID="pnlWorkflow" TargetControlID="btnViewWorkflow"
                                                    CancelControlID="btnCloseHeader" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Button ID="btnWorkflow" runat="server" Visible="false" />

                                            </div>
                                        </div>


                                        <div class="m-form__heading" style="text-align: center; padding-top: 10px;">
                                            <h3 class="m-form__heading-title" style="line-height: 2.0; background: aliceblue; font-size: 1.2rem;">Describe Your Ticket</h3>
                                        </div>

                                        <div class="form-group m-form__group row m--align-center">
                                            <label class="col-xl-2 col-form-label font-weight-bold">
                                                <span style="color: red;">*</span>
                                                <span class="fa fa-text-height" aria-hidden="true"></span>
                                                Description
                                            </label>
                                            <div class="col-xl-4 col-lg-9">
                                                <asp:TextBox ID="txtTicketDesc" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvTicketDesc" ValidationGroup="validateTicket" runat="server" Display="Dynamic"
                                                    ErrorMessage="Please enter ticket description" ForeColor="Red" ControlToValidate="txtTicketDesc"></asp:RequiredFieldValidator>
                                            </div>
                                            <label class="col-xl-3 col-form-label font-weight-bold">
                                                <span style="color: red;">*</span>
                                                <span class="fa fa-images" aria-hidden="true"></span>
                                                Upload Images :
                                            </label>
                                            <div class="col-xl-3 col-lg-9">
                                                <asp:FileUpload ID="FileUpload_TicketImage" runat="server" AllowMultiple="true" />
                                                <asp:RequiredFieldValidator ID="rfvFileupload" ValidationGroup="validateTicket" runat="server" Display="Dynamic"
                                                    ErrorMessage="Please upload image" ForeColor="Red" ControlToValidate="FileUpload_TicketImage"></asp:RequiredFieldValidator>
                                                <span id="ImageUpload_Msg" style="color: red;"></span>
                                                <asp:HiddenField ID="Is_ImageUpload_ValidFile" runat="server" ClientIDMode="Static" />
                                            </div>
                                        </div>

                                        <div class="m-form__heading" style="text-align: center; padding-top: 10px;">
                                            <h3 class="m-form__heading-title" style="line-height: 2.0; background: aliceblue; font-size: 1.2rem;">Additional Fields Ticket</h3>
                                        </div>

                                        <asp:Repeater ID="rptCustomFields" runat="server">
                                            <ItemTemplate>
                                                <div class="form-group m-form__group row mb-3">
                                                    <asp:HiddenField ID="hdnFieldID" ClientIDMode="Static" runat="server" Value='<%#Eval("Field_ID")%>' />
                                                    <asp:Label ID="lblCustomFieldDesc" runat="server" class="col-xl-3 col-lg-3 col-form-label" Text='<%#Eval("Tkt_AddOn_Field_Desc")%>' Style="font-weight: bolder;"></asp:Label>
                                                    <div class="col-xl-9 col-lg-9">
                                                        <asp:TextBox ID="txtCustomFieldsValue" runat="server" class="form-control"></asp:TextBox>
                                                    </div>

                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>



                                        <%--<button type="button" class="btn btn-success m-btn m-btn--custom" id="m_sweetalert_demo_3_4">Success</button>--%>
                                        <%--<asp:Button ID="m_sweetalert_demo_3_3" ClientIDMode="Static"  runat="server"/>--%>

                                        <div class="form-group m-form__group row" style="padding-left: 10%;">
                                            <asp:Label ID="lblTicketErrorMsg" Text="" runat="server" CssClass="col-xl-8 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
                                        </div>

                                    </div>

                                </div>


                                <asp:Panel ID="pnlWorkflow" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
                                    <div class="" id="add_sub_location" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                        <div class="modal-dialog" role="document" style="max-width: 590px;">
                                            <div class="modal-content">

                                                <div class="modal-header">
                                                    <h5 class="modal-title" id="exampleModalLabel">Workflow Details</h5>
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader">
                                                        <span aria-hidden="true">&times;</span>
                                                    </button>
                                                </div>
                                                <div class="modal-body">
                                                    <asp:GridView ID="gvWorkflow" runat="server" CssClass="table table-striped- table-bordered table-hover table-checkable"></asp:GridView>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- End Modal -->
                                </asp:Panel>

                                <%--<asp:Panel ID="pnlTicketSuccess" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;" class="modal fade" role="dialog">--%>
                                <asp:Panel ID="pnlTicketSuccess" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
                                    <div class="" id="add_sub_location2" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                        <div class="modal-dialog" role="document" style="max-width: 590px;">
                                            <div class="modal-content">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>


                                                        <div class="modal-header">
                                                            <h5 class="modal-title" id="exampleModalLabel2">Ticket Confirmation</h5>
                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader2">
                                                                <span aria-hidden="true">&times;</span>

                                                            </button>
                                                        </div>
                                                        <div class="modal-body">
                                                            <div class="form-group m-form__group row">

                                                                <label for="recipient-name" class="col-xl-8 col-lg-3 form-control-label">Ticket has been saved successfully</label>

                                                            </div>



                                                            <div class="form-group m-form__group row">
                                                                <label for="message-text" class="col-xl-5 col-lg-3 form-control-label">Ticket Number :</label>
                                                                <asp:Label ID="lblTicketCode" Text="" runat="server" CssClass="col-xl-1 col-lg-3 col-form-label" Style="padding-top: calc(0.15rem + 1px); margin-left: -10%;"></asp:Label>

                                                            </div>
                                                        </div>


                                                        <div class="modal-footer">
                                                            <asp:Button ID="btnTicketSuccessOk" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="Ok" OnClick="btnTicketSuccessOk_Click" />

                                                        </div>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="btnTest" EventName="Click" />
                                                    </Triggers>
                                                </asp:UpdatePanel>


                                            </div>
                                        </div>
                                    </div>
                                    <!-- End Modal -->
                                </asp:Panel>



                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
