<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="View_Request.aspx.cs" Inherits="Upkeep_v3_Control_Center.Support_Portal.View_Request" %>

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

    <form method="post" runat="server" id="frmMain" style="width: 100%;">

        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <div class="m-content" style="padding: 2px 2px;">
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
                                                <h3 class="m-portlet__head-text">Support Request Details
                                                </h3>
                                            </div>
                                        </div>

                                        <div class="m-portlet__head-tools">
                                            <a href="<%= Page.ResolveClientUrl("~/Support_Portal/View_Request_List.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                                <span>
                                                    <i class="la la-arrow-left"></i>
                                                    <span>Back</span>
                                                </span>
                                            </a>

                                            <asp:Button ID="btnSumit" OnClick="btnSumit_Click" runat="server" Text="Update Request" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10" />
                                        </div>
                                    </div>
                                </div>

                                <div class="m-portlet__body" style="padding: 0.4rem 0rem;">
                                    <!--begin: Form Body -->
                                    <div class="m-portlet__body" style="padding: 0.3rem 0.3rem;">
                                        <%--  <br />--%>
                                        <div class="m-form__section m-form__section--first">


                                            <div class="row" style="padding-left: 2%;">

                                                <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Request ID :</label>
                                                <div class="col-xl-3 col-lg-3 col-form-label">
                                                    <asp:Label ID="lblRequestID" runat="server" Text="" class="form-control-label"></asp:Label>
                                                </div>
                                                <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Request Date :</label>
                                                <div class="col-xl-5 col-lg-5 col-form-label">
                                                    <asp:Label ID="lblRequestDate" runat="server" Text="" class="form-control-label"></asp:Label>
                                                </div>
                                            </div>

                                            <div class=" row" style="padding-left: 2%;">
                                                <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Raised By :</label>
                                                <div class="col-xl-3 col-lg-3 col-form-label">
                                                    <asp:Label ID="lblRequestRaisedBy" runat="server" Text="" class="form-control-label"></asp:Label>
                                                </div>

                                                <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Module :</label>
                                                <div class="col-xl-5 col-lg-5 col-form-label">
                                                    <asp:Label ID="lblModule" runat="server" Text="" class="form-control-label"></asp:Label>
                                                </div>
                                            </div>


                                            <div class=" row" style="padding-left: 2%;">
                                                <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Request Type :</label>
                                                <div class="col-xl-3 col-lg-3 col-form-label">
                                                    <asp:Label ID="lblRequestType" runat="server" Text="" class="form-control-label"></asp:Label>
                                                </div>

                                                <label class="col-xl-3 col-lg-3 col-form-label font-weight-bold">Uploaded Images :</label>
                                                <div class="col-xl-2 col-lg-2 col-form-label">
                                                    <asp:Label ID="lblImageCount" runat="server" Text="" class="form-control-label"></asp:Label>
                                                </div>
                                                <div class="col-xl-1 col-lg-1">
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


                                            </div>

                                            <div class=" row" style="padding-left: 2%;">

                                                <label class="col-xl-2 col-lg-3 col-form-label font-weight-bold">Status :</label>
                                                <div class="col-xl-3 col-lg-3 col-form-label">
                                                    <asp:Label ID="lblActionStatus" runat="server" Text="" class="form-control-label"></asp:Label>
                                                </div>


                                            </div>

                                            <div class=" row" style="padding-left: 2%;">
                                                <label class="col-xl-3 col-lg-3 col-form-label font-weight-bold">Ticket Description :</label>
                                                <div class="col-xl-8 col-lg-3 col-form-label" style="margin-left: -8%;">
                                                    <asp:Label ID="lblTicketdesc" runat="server" Text="" class="form-control-label"></asp:Label>
                                                </div>

                                            </div>

                                            <div id="div1" runat="server" class=" row" style="padding-left: 2%;">
                                                <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Last Updated By :</label>
                                                <div class="col-xl-3 col-lg-3 col-form-label">
                                                    <asp:Label ID="lblUpdtedby" runat="server" Text="" class="form-control-label"></asp:Label>

                                                </div>

                                                <label class="col-xl-3 col-lg-3 col-form-label font-weight-bold">Last Updated Date :</label>
                                                <div class="col-xl-3 col-lg-3 col-form-label">
                                                    <asp:Label ID="lblUpdatedDate" runat="server" Text="" class="form-control-label"></asp:Label>

                                                </div>


                                            </div>

                                            <div id="div2" runat="server" class=" row" style="padding-left: 2%;">
                                                <label class="col-xl-3 col-lg-3 col-form-label font-weight-bold">Closing Remarks :</label>
                                                <div class="col-xl-8 col-lg-3 col-form-label" style="margin-left: -8%;">
                                                    <asp:Label ID="lblClosingRemarks" runat="server" Text="" class="form-control-label"></asp:Label>
                                                </div>

                                            </div>


                                            <div id="div3" runat="server" class=" row" style="padding-left: 2%;">
                                                <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Update Status:</label>
                                                <div class="col-xl-3 col-lg-3 col-form-label">
                                                    <asp:DropDownList ID="ddlStatus" class="form-control m-input" runat="server">
                                                        <asp:ListItem Value="">-- Update Current Status --</asp:ListItem>
                                                        <asp:ListItem>In-Progress</asp:ListItem>
                                                        <asp:ListItem>Parked</asp:ListItem>
                                                        <asp:ListItem>Closed</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div id="div4" runat="server" class=" row" style="padding-left: 2%;">
                                                <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Closing Remarks :</label>
                                                <div class="col-xl-9 col-lg-5 col-form-label">
                                                    <textarea id="txtClosingRemarks" cols="20" rows="2" runat="server" class="form-control m-input" placeholder="Enter Detailed for closing the ticket">

                                                </textarea>
                                                    <asp:RequiredFieldValidator ID="rfvtxtClosingRemarks" runat="server" ControlToValidate="txtClosingRemarks" ValidationGroup="ValidateUser"
                                                        ErrorMessage="Please enter Closing description" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

                                                </div>

                                                <asp:Label ID="lblError" runat="server" Text="" class="form-control-label"></asp:Label>
                                            </div>






                                            <div class="col-xl-12" style="padding-left: 2%; padding-bottom: 2%;">

                                                <div class="alert alert-primary" role="alert">
                                                    Below is <strong>Support Ticket</strong> Chat history & comments shared.
                                                </div>
                                            </div>


                                            <div class="col-xl-12" style="padding-left: 2%;">

                                                <div class="m-messenger m-messenger--message-arrow m-messenger--skin-light">

                                                <%--Support chatting Layout START--%>

<%--                                                <div class="m-messenger__messages m-scrollable m-scroller ps ps--active-y">

                                                    <asp:UpdatePanel ID="comments" runat="server">
                                                        <ContentTemplate>

                                                            <div id="div_msg_client" runat="server" class="m-messenger__wrapper">
                                                                <div class="m-messenger__message m-messenger__message--in">

                                                                    <div class="m-messenger__message-body">
                                                                        <div class="m-messenger__message-arrow"></div>
                                                                        <div class="m-messenger__message-content">
                                                                            <div class="m-messenger__message-username">
                                                                                <label id="lblclient_name" runat="server"></label>
                                                                            </div>
                                                                            <div class="m-messenger__message-text">
                                                                                <label id="lblclient_Comment" runat="server"></label>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div id="div_msg_support" runat="server" class="m-messenger__wrapper">
                                                                <div class="m-messenger__message m-messenger__message--out">

                                                                    <div class="m-messenger__message-body">
                                                                        <div class="m-messenger__message-arrow"></div>
                                                                        <div class="m-messenger__message-content">
                                                                            <div class="m-messenger__message-username">
                                                                                <label id="lblSupport_Name" runat="server"></label>
                                                                            </div>
                                                                            <div class="m-messenger__message-text">
                                                                                <label id="lblSupport_Comment" runat="server"></label>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>--%>


                                                <%--Support chatting Layout END--%>


                                                <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">
                                                    <thead>
                                                        <tr>
                                                            <th>Client User Name</th>
                                                            <th>Support User Name</th>
                                                            
                                                            <th>Comment Description</th>
                                                        </tr>
                                                    </thead>

                                                    <tbody>
                                                        <%=View_Request_Comments()%>
                                                    </tbody>


                                                </table>

                                                <div class="m-messenger__form">
                                                    <div class="m-messenger__form-controls">
                                                        <asp:TextBox ID="txtcomment" runat="server" name="" placeholder="Enter your comment on the Ticket..." class="m-messenger__form-input"></asp:TextBox>

                                                    </div>
                                                    <div class="m-messenger__form-tools">
                                                        <a href="#" class="btn btn-outline-primary m-btn m-btn--icon m-btn--pill m-btn--air" runat="server" id="btnSaveComment" onserverclick="btnSaveComment_Click">
                                                            <span>
                                                                <i class="la la-send"></i>
                                                                <span>Send</span>
                                                            </span>
                                                        </a>


                                                    </div>
                                                </div>
                                            </div>


                                            </div>


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
                                                        </div>
                                                    </ContentTemplate>
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

    </form>


</asp:Content>
