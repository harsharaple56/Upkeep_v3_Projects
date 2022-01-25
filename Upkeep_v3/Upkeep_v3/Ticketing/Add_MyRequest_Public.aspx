<%@ Page Async="true" Language="C#" MasterPageFile="~/BlankMaster.Master" AutoEventWireup="true" CodeBehind="Add_MyRequest_Public.aspx.cs" Inherits="Upkeep_v3.Ticketing.Add_MyRequest_Public" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>

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
                $('#ImageUpload_Msg').text('').hide();
                $('#LocationError_Msg').text('').hide();

                if ($('#hdnIs_Retailer').val() == '0') {
                    if ($('#hdnassetLocation').val() == '') {
                        $('#LocationError_Msg').text("Please Select Proper Location").show();
                        return false;
                    }
                }

                if ($('#hdnCategory').val() == '') {
                    $('#CategoryError_Msg').text("Please Select Category").show();
                    return false;
                }

            });

            $("#txtassetLocation").on('input', function () {
                var val = this.value;

                $('#hdnassetLocation').val("");
                if ($('#dlassetLocation option').filter(function () {
                    if (this.value.toUpperCase() === val.toUpperCase()) {
                        $('#hdnassetLocation').val($(this).attr('text'));
                    }
                    return this.value.toUpperCase() === val.toUpperCase();
                }).length) {
                }
            });

            $("#txtCategory").on('input', function () {
                var val = this.value;

                $('#hdnCategory').val("");
                if ($('#dlCategory option').filter(function () {
                    if (this.value.toUpperCase() === val.toUpperCase()) {
                        $('#hdnCategory').val($(this).attr('text'));
                    }
                    return this.value.toUpperCase() === val.toUpperCase();
                }).length) {
                    $("#btnCategoryChange").click();
                }
            });

            $("#txtSubCategory").on('input', function () {
                var val = this.value;

                $('#hdnSubCategory').val("");
                if ($('#dlSubCategory option').filter(function () {
                    if (this.value.toUpperCase() === val.toUpperCase()) {
                        $('#hdnSubCategory').val($(this).attr('text'));
                    }
                    return this.value.toUpperCase() === val.toUpperCase();
                }).length) {
                    $("#btnSubCategoryChange").click();
                }
            });

            function Category_Change() {
                $("#btnCategoryChange").click();
            }

        })
    </script>

    <script type="text/javascript">
        $(function () {
            $('#<%=FileUpload_TicketImage.ClientID %>').change(function () {
                $('#ImageUpload_Msg').text('').hide();
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">

            <!--begin::Portlet-->
            <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
                <div class="m--align-center" style="padding: 15px;">
                    <%--<asp:Image ID="Img_CompanyLogo" runat="server" Style="width: auto; max-height: 100px; max-width: 100%;" />--%>
                    <img style="width: 265px; height: 165px;" src="https://compelapps.in/eFacilito/assets/app/media/img/logos/efacilito_250.png" />
                </div>
                <div class="m--align-center" style="padding: 15px;">
                    <h4 class="m--font-primary font-weight-bold">
                        <asp:Label ID="lbl_Form_Name" runat="server">Ticket Request Form..!</asp:Label>
                    </h4>
                </div>

                <div class="m-portlet__body">

                    <div class="m-form__section m-form__section--first">
                        <div class="m-form__heading" style="text-align: center; padding-top: 10px;">
                            <h3 class="m-form__heading-title" style="line-height: 2.0; background: aliceblue; font-size: 1.2rem;">Customer Information</h3>
                        </div>

                        <div class="form-group m-form__group row">
                            <label class="col-xl-1 col-form-label font-weight-bold">
                                <span style="color: red;">*</span>
                                <span class="fa fa-user" aria-hidden="true"></span>
                                Name
                            </label>

                            <div class="col-xl-3 col-lg-3">
                                <asp:TextBox ID="txtName" TextMode="SingleLine" runat="server" autocomplete="off" class="form-control m-input m-input--air" placeholder="Enter User Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" Visible="true" Display="Dynamic"
                                    ValidationGroup="validateTicket" ForeColor="Red" ErrorMessage="Please User Name"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtName" ValidationGroup="validateTicket" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="*Only Alphabets allow." ForeColor="Red" />
                            </div>

                            <label class="col-xl-1 col-form-label font-weight-bold">
                                <span style="color: red;">*</span>
                                <span class="fa fa-envelope" aria-hidden="true"></span>
                                Email
                            </label>

                            <div class="col-xl-3 col-lg-3">
                                <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" autocomplete="off" class="form-control m-input m-input--air" placeholder="Enter User Email ID"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" Visible="true" Display="Dynamic"
                                    ValidationGroup="validateTicket" ForeColor="Red" ErrorMessage="Please enter Email"></asp:RequiredFieldValidator>

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ValidationGroup="validateTicket"
                                    ErrorMessage="*Please enter valid email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">  
                                </asp:RegularExpressionValidator>
                            </div>

                            <label class="col-xl-1 col-form-label font-weight-bold">
                                <span style="color: red;">*</span>
                                <span class="fa fa-phone" aria-hidden="true"></span>
                                Mobile
                            </label>

                            <div class="col-xl-3 col-lg-3">
                                <asp:TextBox ID="txtPhone" TextMode="Phone" runat="server" autocomplete="off" class="form-control m-input m-input--air" placeholder="Enter User Mobile No."></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvphone" runat="server" ControlToValidate="txtPhone" Visible="true" Display="Dynamic"
                                    ValidationGroup="validateTicket" ForeColor="Red" ErrorMessage="Please enter Mobile Number"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtPhone" ValidationGroup="validateTicket"
                                    ErrorMessage="Enter valid phone number in 10 digits." ForeColor="Red" ValidationExpression="^[0-9]{10,10}$">  
                                </asp:RegularExpressionValidator>
                            </div>

                        </div>

                    </div>


                    <div class="m-form__section m-form__section--first">

                        <div class="m-form__heading" style="text-align: center; padding-top: 10px;">
                            <h3 class="m-form__heading-title" style="line-height: 2.0; background: aliceblue; font-size: 1.2rem;">Fill Up Ticket Details</h3>
                        </div>

                        <asp:UpdatePanel runat="server" style="width: 100%;">
                            <ContentTemplate>

                                <div class="form-group m-form__group row">
                                    <label class="col-xl-2 col-form-label font-weight-bold">
                                        <span style="color: red;">*</span>
                                        <span class="fa fa-map-marker-alt" aria-hidden="true"></span>
                                        Select Location
                                    </label>
                                    <div class="col-xl-10 col-lg-9" id="dvRetailerLocation" runat="server">
                                        <asp:HiddenField ID="hdnIs_Retailer" runat="server" ClientIDMode="Static" />
                                        <asp:DropDownList ID="ddlLocation" class="form-control m-input m-input--air" runat="server"></asp:DropDownList>
                                        <asp:Label ID="lblRetailerLocError" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                                    <div class="col-xl-10 col-lg-9" id="dvEmployeeLocation" runat="server">
                                        <asp:HiddenField ID="hdnassetLocation" runat="server" ClientIDMode="Static" />
                                        <input list="dlassetLocation" id="txtassetLocation" name="txtassetLocation"
                                            class="form-control m-input m-input--air" runat="server" clientidmode="Static" />
                                        <datalist id="dlassetLocation" runat="server" clientidmode="Static"></datalist>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtassetLocation" Visible="true" Display="Dynamic"
                                            ValidationGroup="validateTicket" ForeColor="Red" ErrorMessage="Please select Location"></asp:RequiredFieldValidator>
                                        <span id="LocationError_Msg" style="color: red;"></span>
                                    </div>
                                </div>



                            </ContentTemplate>
                        </asp:UpdatePanel>


                        <div class="m-form__heading" style="text-align: center; padding-top: 10px;">
                            <h3 class="m-form__heading-title" style="line-height: 2.0; background: aliceblue; font-size: 1.2rem;">Categorize Your Ticket</h3>
                        </div>

                        <div class="form-group m-form__group row">
                            <label class="col-xl-2 col-form-label font-weight-bold">
                                <span style="color: red;">*</span>
                                <span class="fa fa-sitemap" aria-hidden="true"></span>
                                Select Category
                            </label>

                            <div class="col-xl-4 col-lg-4">

                                <asp:HiddenField ID="hdnCategory" runat="server" ClientIDMode="Static" />
                                <asp:Button ID="btnCategoryChange" runat="server" Style="display: none;" OnClick="btnCategoryChange_Click" ClientIDMode="Static" />

                                <input list="dlCategory" id="txtCategory" name="txtassetLocation"
                                    class="form-control m-input m-input--air" runat="server" clientidmode="Static" />
                                <datalist id="dlCategory" runat="server" clientidmode="Static"></datalist>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCategory" Visible="true" Display="Dynamic"
                                    ValidationGroup="validateTicket" ForeColor="Red" ErrorMessage="Please select Category"></asp:RequiredFieldValidator>
                                <span id="CategoryError_Msg" style="color: red;"></span>

                            </div>

                            <label class="col-xl-2 col-form-label font-weight-bold">
                                <span class="fa fa-sitemap" aria-hidden="true"></span>
                                Select Sub-Category
                            </label>

                            <div class="col-xl-4 col-lg-4">

                                <asp:HiddenField ID="hdnSubCategory" runat="server" ClientIDMode="Static" />
                                <asp:Button ID="btnSubCategoryChange" runat="server" Style="display: none;" OnClick="btnSubCategoryChange_Click" ClientIDMode="Static" />

                                <input list="dlSubCategory" id="txtSubCategory" name="txtassetLocation"
                                    class="form-control m-input m-input--air" runat="server" clientidmode="Static" />
                                <datalist id="dlSubCategory" runat="server" clientidmode="Static"></datalist>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSubCategory" Visible="true" Display="Dynamic"
                                    ValidationGroup="validateTicket" ForeColor="Red" ErrorMessage="Please select SubCategory"></asp:RequiredFieldValidator>

                            </div>

                        </div>

                        <div class="m-form__heading" style="text-align: center; padding-top: 10px;">
                            <h3 class="m-form__heading-title" style="line-height: 2.0; background: aliceblue; font-size: 1.2rem;">Describe Your Ticket</h3>
                        </div>

                        <div class="form-group m-form__group row">
                            <label class="col-xl-2 col-form-label font-weight-bold">
                                <span style="color: red;">*</span>
                                <span class="fa fa-text-height" aria-hidden="true"></span>
                                Description
                            </label>
                            <div class="col-xl-4 col-lg-4">
                                <asp:TextBox ID="txtTicketDesc" runat="server" class="form-control m-input m-input--air" Rows="3" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvTicketDesc" ValidationGroup="validateTicket" runat="server" Display="Dynamic"
                                    ErrorMessage="Please enter Ticket Description" ForeColor="Red" ControlToValidate="txtTicketDesc"></asp:RequiredFieldValidator>
                            </div>
                            <label class="col-xl-2 col-form-label font-weight-bold">
                                <span style="color: red;">*</span>
                                <span class="fa fa-images" aria-hidden="true"></span>
                                Upload Images :
                            </label>
                            <div class="col-xl-4 col-lg-4">
                                <asp:FileUpload accept="image/jpg, image/jpeg, image/png" ID="FileUpload_TicketImage" CssClass="custom-file-input m-input m-input--air" runat="server" AllowMultiple="true" />
                                <label class="custom-file-label" for="customFile">
                                    Choose file
                                </label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="FileUpload_TicketImage" Visible="true" Display="Dynamic"
                                    ValidationGroup="validateTicket" ForeColor="Red" ErrorMessage="Please upload image."></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ForeColor="Red" ID="RegularExpressionValidator4" runat="server"
                                    ControlToValidate="FileUpload_TicketImage" ValidationGroup="validateTicket"
                                    ErrorMessage="Failed!! Please upload jpg, jpeg, png file only." ValidationExpression="^.*\.(jpg|JPG|png|PNG|jpeg|JPEG)$"></asp:RegularExpressionValidator>
                                <br />

                                <span id="ImageUpload_Msg" style="color: red;"></span>
                                <asp:HiddenField ID="Is_ImageUpload_ValidFile" runat="server" ClientIDMode="Static" />
                            </div>

                            <div class="form-group m-form__group row" style="padding-left: 10%;">
                                <asp:Label ID="lblTicketErrorMsg" Text="" runat="server" CssClass="col-xl-8 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
                            </div>
                        </div>

                        <hr />
                        <asp:Button ID="btnSave" runat="server" class="btn m-btn--pill btn-primary btn-block" ValidationGroup="validateTicket" OnClick="btnSave_Click" Text="Save Your Ticket" />
                        <asp:Button ID="btnTest" Style="display: none;" runat="server" />
                        <cc1:ModalPopupExtender ID="mpeTicketSaveSuccess" runat="server" PopupControlID="pnlTicketSuccess" TargetControlID="btnTest"
                            CancelControlID="btnCloseHeader2" BackgroundCssClass="modalBackground">
                        </cc1:ModalPopupExtender>
                        <div class="alert alert-danger" id="divError" visible="False" runat="server" role="alert">
                            <asp:Label ID="lblErrorMsg" Text="" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

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

</asp:Content>
