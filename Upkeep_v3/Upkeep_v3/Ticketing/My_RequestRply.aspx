<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="My_RequestRply.aspx.cs" Inherits="Upkeep_v3.Ticketing.My_RequestRply" %>

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

    <script>
        $(document).ready(function () {
            //$('#clickmewow').click(function () {
            //    $('#radio1003').attr('checked', 'checked');
            //});


            $('#exampleModal').on('show.bs.modal', function (event) {

                var button = $(event.relatedTarget); // Button that triggered the modal
                var title = button.data('title'); // Extract info from data-* attributes
                var images_list = button.data('images'); // Extract info from data-* attributes
                // alert(images_list);
                var modal = $(this);
                modal.find('.modal-title').text(title);
                var images = images_list.split(',')
                modal.find('.modal-body .carousel-inner').html('')
                $.each(images, function (index, image) {
                    if (index == 0)
                        var item = '<div class="carousel-item active">';
                    else
                        var item = '<div class="carousel-item">';
                    item += '<img class="d-block w-100" src="' + image + '"></div>'
                    modal.find('.modal-body .carousel-inner').append(item);
                });
                //$('.carousel').carousel();
            })
        });
    </script>

    <%-- <asp:FileUpload ID="FileUpload_TicketImage" runat="server" CssClass="btn btn-accent" AllowMultiple="true" />
                                                <asp:RequiredFieldValidator ID="rfvFileupload" ValidationGroup="validate" runat="server" Display="Dynamic"
                                                    ErrorMessage="Please upload image" ControlToValidate="FileUpload_TicketImage"></asp:RequiredFieldValidator>
    --%>

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <div class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmticket1">
                            <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

                            <asp:HiddenField ID="hdnImage" runat="server" ClientIDMode="Static" />
                            <div class="m-portlet__head">
                                <div class="m-portlet__head-progress">

                                    <!-- here can place a progress bar-->
                                </div>
                                <div class="m-portlet__head-wrapper">
                                    <div class="m-portlet__head-caption">
                                        <div class="m-portlet__head-title">
                                            <h3 class="m-portlet__head-text">My Request Details
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
                                        <%--<div class="btn-group">

                                            <asp:Button ID="btnClose" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" ValidationGroup="validateTicket" OnClick="btnClose_Click" Text="Close" />

                                            <asp:Button ID="btnTest" Style="display: none;" runat="server" />
                                            <cc1:ModalPopupExtender ID="mpeTicketSaveSuccess" runat="server" PopupControlID="pnlTicketSuccess" TargetControlID="btnTest"
                                                CancelControlID="btnCloseHeader2" BackgroundCssClass="modalBackground">
                                            </cc1:ModalPopupExtender>

                                        </div>--%>
                                    </div>

                                </div>
                            </div>




                            <div class="m-portlet__body" style="padding: 0.4rem 2.2rem;">
                                <!--begin: Form Body -->
                                <div class="m-portlet__body" style="padding: 0.3rem 2.2rem;">
                                    <%--  <br />--%>
                                    <div class="m-form__section m-form__section--first">

                                        <div class="form-group m-form__group row" style="padding-left: 15%;">
                                            <%--<button type="button" class="btn btn-success m-btn m-btn--custom" id="m_sweetalert_demo_3_4">Success</button>--%>
                                            <label class="col-xl-3 col-lg-3 form-control-label">TicketID :</label>
                                            <div class="col-xl-3 col-lg-3">
                                                <asp:Label ID="lblTicketID" runat="server" Text="" class="form-control-label"></asp:Label>
                                            </div>
                                            <label class="col-xl-3 col-lg-3 form-control-label">Request Date :</label>
                                            <div class="col-xl-3 col-lg-3">
                                                <asp:Label ID="lblRequestDate" runat="server" Text="" class="form-control-label"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="form-group row" style="background-color: #00c5dc;">
                                            <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Select Location Details</label>
                                        </div>

                                        <%--<div class="form-group m-form__group row" style="padding-left: 15%;">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Zone :</label>
                                                    <div class="col-xl-5 col-lg-9">
                                                        <asp:Label ID="lblZone" runat="server" Text="" class="form-control-label"></asp:Label>
                                                    </div>
                                                </div>--%>
                                        <div class="form-group m-form__group row" style="padding-left: 15%;">
                                            <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Location :</label>
                                            <div class="col-xl-5 col-lg-9">
                                                <asp:Label ID="lblLocation" runat="server" Text="" class="form-control-label"></asp:Label>
                                            </div>

                                        </div>
                                        <%--<div class="form-group m-form__group row" style="padding-left: 15%;">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Sub-Location :</label>
                                                    <div class="col-xl-5 col-lg-9">
                                                        <asp:Label ID="lblSubLocation" runat="server" Text="" class="form-control-label"></asp:Label>
                                                    </div>                                                
                                                </div>--%>



                                        <br />

                                        <div class="form-group row" style="background-color: #00c5dc;">
                                            <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Select Ticket Categorization</label>
                                        </div>

                                        <%--</div>
                                    </div>--%>                                        <%--<asp:Panel ID="pnlTicketSuccess" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;" class="modal fade" role="dialog">--%>
                                        <div class="form-group m-form__group row" style="padding-left: 15%;">
                                            <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Category :</label>
                                            <div class="col-xl-5 col-lg-9">

                                                <asp:Label ID="lblCategory" runat="server" Text="" class="form-control-label"></asp:Label>



                                            </div>
                                        </div>

                                        <div class="form-group m-form__group row" style="padding-left: 15%;">
                                            <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Sub Category :</label>
                                            <div class="col-xl-5 col-lg-9">

                                                <asp:Label ID="lblSubCategory" runat="server" Text="" class="form-control-label"></asp:Label>



                                            </div>
                                            <%--<asp:Button ID="btnTicketSuccessOk" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="Ok" OnClick="btnTicketSuccessOk_Click" />--%><%--<hr style="width: 100%" />
                                        <div class="form-group m-form__group row" style="padding-left: 15%;">
                                            <label class="col-xl-5 col-lg-3 col-form-label">Note: Ticket closure will be approved by :</label>
                                            <div class="col-xl-5 col-lg-9">
                                                <asp:DropDownList ID="ddlApprover" class="form-control m-input" runat="server"></asp:DropDownList>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlApprover" Visible="true" Display="Dynamic"
                                                    ValidationGroup="validateTicket" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Approver"></asp:RequiredFieldValidator>

                                            </div>
                                        </div>--%>
                                            <div class="col-xl-3 col-lg-9 m-section__content">
                                                <asp:Button ID="btnViewWorkflow" runat="server" class="btn btn-accent  m-btn m-btn--icon dark disabled" Style="padding: 0.45rem 1.15rem; pointer-events: none;"
                                                    OnClick="btnViewWorkflow_Click" Text="View Workflow" />

                                                <cc1:ModalPopupExtender ID="mpeWorkflow" runat="server" PopupControlID="pnlWorkflow" TargetControlID="btnViewWorkflow"
                                                    CancelControlID="btnCloseHeader" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                                <asp:Button ID="btnWorkflow" runat="server" Visible="false" />

                                            </div>
                                        </div>

                                        <div class="row" style="padding-left: 15%; display: none;" id="dvDepartment" runat="server">
                                            <label class="col-form-label">Note: Ticket will be assigned to </label>
                                            <%--  <br />--%>
                                            <asp:Label ID="lblDepartmentName" CssClass="col-form-label" runat="server" Text=""></asp:Label>
                                            <%--<button type="button" class="btn btn-success m-btn m-btn--custom" id="m_sweetalert_demo_3_4">Success</button>--%>
                                            <label class="col-form-label">department</label>
                                        </div>

                                        <%--<asp:Button ID="m_sweetalert_demo_3_3" ClientIDMode="Static"  runat="server"/>--%>
                                        <%--</div>
                                    </div>--%>

                                        <div class="form-group row" style="background-color: #00c5dc;">
                                            <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Ticket Description</label>
                                        </div>

                                        <div class="form-group m-form__group row" style="padding-left: 15%;">
                                            <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Ticket Description :</label>
                                            <div class="col-xl-9 col-lg-9">

                                                <asp:Label ID="lblTicketdesc" runat="server" Text="" class="form-control-label"></asp:Label>



                                            </div>
                                        </div>


                                        <div class="form-group m-form__group row" style="padding-left: 15%;">
                                            <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Ticket Images :</label>
                                            <div class="col-xl-7 col-lg-9">
                                                <%--<asp:Panel ID="pnlTicketSuccess" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;" class="modal fade" role="dialog">--%>
                                                <asp:FileUpload ID="FileUpload_TicketImage" runat="server" CssClass="btn btn-accent" AllowMultiple="true" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="validate" runat="server" Display="Dynamic"
                                                    ErrorMessage="Please upload image" ControlToValidate="FileUpload_TicketImage"></asp:RequiredFieldValidator>
                                            </div>


                                            <asp:Repeater ID="rptTicketImage" runat="server">
                                                <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td style="width: 5%">
                                                                <button type='button' data-toggle='modal' id="btnShowImage" data-target="#exampleModal" data-images="<%#Eval("ImagePath") %>" class='btn btn-accent m-btn m-btn--icon' data-container='body' style="width: 41px; height: 41px;" data-toggle='m-tooltip' data-placement='top' title='View Uploaded Image'>
                                                                    <i class='la la-image' style="margin-left: -106%; font-size: 2.3rem;"></i>
                                                                </button>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:Repeater>

                                        </div>

                                        <div class="form-group m-form__group row" style="padding-left: 15%;">
                                            <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Close Ticket Description :</label>
                                            <div class="col-xl-9 col-lg-9">
                                                <asp:TextBox ID="txtCloseTicketDesc" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group m-form__group row" id="dvClose" runat="server">
                                            <div class="col-xl-5 col-lg-5"></div>
                                            <div class="btn-group col-xl-3 col-lg-3">

                                                <asp:Button ID="btnClose" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" ValidationGroup="validateTicket" OnClick="btnClose_Click" Text="Close" />

                                                <asp:Button ID="btnTest" Style="display: none;" runat="server" />
                                                <cc1:ModalPopupExtender ID="mpeTicketSaveSuccess" runat="server" PopupControlID="pnlTicketSuccess" TargetControlID="btnTest"
                                                    CancelControlID="btnCloseHeader2" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>
                                            </div>
                                        </div>

                                        <!-- The fileupload-buttonbar contains buttons to add/delete files and start/cancel the upload -->
                                        <%--<asp:Button ID="btnTicketSuccessOk" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="Ok" OnClick="btnTicketSuccessOk_Click" />--%>





                                        <%--<hr style="width: 100%" />
                                        <div class="form-group m-form__group row" style="padding-left: 15%;">
                                            <label class="col-xl-5 col-lg-3 col-form-label">Note: Ticket closure will be approved by :</label>
                                            <div class="col-xl-5 col-lg-9">
                                                <asp:DropDownList ID="ddlApprover" class="form-control m-input" runat="server"></asp:DropDownList>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlApprover" Visible="true" Display="Dynamic"
                                                    ValidationGroup="validateTicket" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Approver"></asp:RequiredFieldValidator>

                                            </div>
                                        </div>--%>
                                        <%--  <br />--%>
                                        <br />

                                        <%--<button type="button" class="btn btn-success m-btn m-btn--custom" id="m_sweetalert_demo_3_4">Success</button>--%>
                                        <%--<asp:Button ID="m_sweetalert_demo_3_3" ClientIDMode="Static"  runat="server"/>--%>

                                        <div class="form-group m-form__group row" style="padding-left: 15%;">
                                            <asp:Label ID="lblTicketErrorMsg" Text="" runat="server" CssClass="col-xl-8 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="lblUser" runat="server"></asp:Label>
                                        </div>

                                    </div>
                                    <%--</div>
                                    </div>--%>
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
                                                        <%--<asp:Button ID="btnTicketSuccessOk" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="Ok" OnClick="btnTicketSuccessOk_Click" />--%>
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

                            <div aria-hidden="true" aria-labelledby="exampleModalLabel" class="modal fade" id="exampleModal" role="dialog" tabindex="-1">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h5 class="modal-title" id="exampleModalLabel1">Uploaded Image
                                            </h5>
                                            <button aria-label="Close" class="close" data-dismiss="modal" type="button">
                                                <span aria-hidden="true">×
                                                </span>
                                            </button>
                                        </div>
                                        <div class="modal-body">
                                            <div class="carousel slide" data-ride="carousel" id="carouselExampleControls">
                                                <div class="carousel-inner">
                                                </div>
                                                <a class="carousel-control-prev" data-slide="prev" href="#carouselExampleControls" role="button">
                                                    <span aria-hidden="true" class="carousel-control-prev-icon"></span>
                                                    <span class="sr-only">Previous
                                                    </span>
                                                </a>
                                                <a class="carousel-control-next" data-slide="next" href="#carouselExampleControls" role="button">
                                                    <span aria-hidden="true" class="carousel-control-next-icon"></span>
                                                    <span class="sr-only">Next
                                                    </span>
                                                </a>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>








</asp:Content>
