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

            $('#btnClose').click(function () {
                var ddlAction = $('#ddlAction').val();
                //alert(ddlAction);
                debugger;
                var hdn_Mandatory_Img_Close = $('#hdn_Mandatory_Img_Close').val();
                var hdn_Mandatory_Remark_Close = $('#hdn_Mandatory_Remark_Close').val();

                var FileUpload_TicketImage = $("#FileUpload_TicketImage").val();
                var txtCloseTicketDesc = $("#txtCloseTicketDesc").val();

                var Is_ImageUpload_ValidFile = $("#Is_ImageUpload_ValidFile").val();
                //alert(Is_ImageUpload_ValidFile);
                if (Is_ImageUpload_ValidFile == 0) {
                    $('#ImageUpload_Msg').text("Failed!! Please upload jpg, jpeg, png file only.").show();
                    return false;
                }
                else if (Is_ImageUpload_ValidFile == 1) {
                    $('#ImageUpload_Msg').text("Failed!! Max allowed file size is 100 KB").show();
                    return false;
                }

                //alert(FileUpload_TicketImage);
                //alert(hdn_Mandatory_Remark_Close); 
                $('#ImageUpload_Msg').text('').hide();
                $('#Remarks_Msg').text('').hide();

                if (ddlAction == "Closed") {
                    if (hdn_Mandatory_Img_Close == "True") {
                         //document.getElementById("<%=rfvFileupload.ClientID%>").enabled = true;
                        if (FileUpload_TicketImage == "") {
                            $('#ImageUpload_Msg').text("Please upload image").show();
                            return false;
                        }
                    }
                    if (hdn_Mandatory_Remark_Close == "True") {
                         //document.getElementById("<%=rfvClosingRemarks.ClientID%>").enabled = true;
                        if (txtCloseTicketDesc == "") {
                            $('#Remarks_Msg').text("Please enter remarks").show();
                            return false;
                        }
                    }
                }

                else if (ddlAction == "Hold") {
                     //document.getElementById("<%=rfvClosingRemarks.ClientID%>").enabled = true;
                     //document.getElementById("<%=rfvFileupload.ClientID%>").enabled = false;
                    if (txtCloseTicketDesc == "") {
                        $('#Remarks_Msg').text("Please enter remarks").show();
                        return false;
                    }
                }
                else {
                     //document.getElementById("<%=rfvClosingRemarks.ClientID%>").enabled = false;
                     //document.getElementById("<%=rfvFileupload.ClientID%>").enabled = false;
                }
            });

            $("#ddlAction").change(function () {
                //alert($('option:selected', this).text());
                var ddlAction = $('option:selected', this).text();
                if (ddlAction == "Close") {
                    $('.dvImageUpload').show();
                }
                else {
                    $('.dvImageUpload').hide();
                    $("#Is_ImageUpload_ValidFile").val("3");
                }
            });



        });
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
                    $("#Is_ImageUpload_ValidFile").val("0");

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
    <div class="m-content">
    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <div class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmticket1">
                            <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

                            <asp:HiddenField ID="hdnImage" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="hdn_Mandatory_Img_Close" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="hdn_Mandatory_Remark_Close" runat="server" ClientIDMode="Static" />

                            <div class="m-portlet__head">
                                <div class="m-portlet__head-progress">

                                    <!-- here can place a progress bar-->
                                </div>
                                <div class="m-portlet__head-wrapper">
                                    <div class="m-portlet__head-caption">
                                        <div class="m-portlet__head-title">
                                            <h3 class="m-portlet__head-text">Ticket Details
                                            </h3>
                                        </div>
                                    </div>

                                    <div class="m-portlet__head-tools">
                                        <a runat="server" onserverclick="btnBack_Click" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                            <span>
                                                <i class="la la-arrow-left"></i>
                                                <span>Back</span>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                            </div>

                            <div class="m-portlet__body" style="padding: 0.4rem 2.2rem;">
                                <!--begin: Form Body -->
                                <div class="m-portlet__body" style="padding: 0.3rem 2.2rem;">
                                    <%--  <br />--%>
                                    <div class="m-form__section m-form__section--first">

                                        <div class="form-group row" style="background-color: #00c5dc;">
                                            <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Ticket Details</label>
                                        </div>

                                        <div class="row" style="padding-left: 2%;">

                                            <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Ticket No :</label>
                                            <div class="col-xl-3 col-lg-3 col-form-label">
                                                <asp:Label ID="lblTicketNo" runat="server" Text="" class="form-control-label"></asp:Label>
                                            </div>
                                            <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Request Date :</label>
                                            <div class="col-xl-5 col-lg-5 col-form-label">
                                                <asp:Label ID="lblRequestDate" runat="server" Text="" class="form-control-label"></asp:Label>
                                            </div>
                                        </div>

                                        <div class=" row" style="padding-left: 2%;">
                                            <%--<label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Raised By :</label>
                                            <div class="col-xl-3 col-lg-3 col-form-label">
                                                <asp:Label ID="lblTicketRaisedBy" runat="server" Text="" class="form-control-label"></asp:Label>
                                            </div>--%>

                                            <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Location :</label>
                                            <div class="col-xl-9 col-lg-9 col-form-label">
                                                <asp:Label ID="lblLocation" runat="server" Text="" class="form-control-label"></asp:Label>
                                            </div>
                                        </div>


                                        <div class=" row" style="padding-left: 2%;">
                                            <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Category :</label>
                                            <div class="col-xl-3 col-lg-3 col-form-label">
                                                <asp:Label ID="lblCategory" runat="server" Text="" class="form-control-label"></asp:Label>
                                            </div>

                                            <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Sub Category :</label>
                                            <div class="col-xl-5 col-lg-5 col-form-label">
                                                <asp:Label ID="lblSubCategory" runat="server" Text="" class="form-control-label"></asp:Label>
                                            </div>

                                        </div>

                                        <div class=" row" style="padding-left: 2%;">
                                            <%--<label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">View Workflow :</label>--%>
                                            <div class="col-xl-5 col-lg-5 col-form-label" style="text-align: center;">
                                                <%--<asp:ImageButton ID="imgbtnViewWorkflow" runat="server" ToolTip="Click here to view workflow" ImageUrl="../assets/app/media/img/icons/workflow.png" />--%>
                                                <asp:Button ID="imgbtnViewWorkflow" runat="server" Text="Click to View Workflow"  class="btn btn-success m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10"/>
                                                <cc1:ModalPopupExtender ID="mpeWorkflow" runat="server" PopupControlID="pnlWorkflow" TargetControlID="imgbtnViewWorkflow"
                                                    CancelControlID="btnCloseHeader" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                               <%-- <a runat="server" onserverclick="btnBack_Click" class="btn btn-success m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                                    <span>
                                                        <img src="../assets/app/media/img/icons/workflow.png" />
                                                        <span>View Workflow</span>
                                                    </span>
                                                </a>--%>


                                            </div>

                                            <label class="col-xl-3 col-lg-3 col-form-label font-weight-bold">Uploaded Image Count :</label>
                                            <div class="col-xl-2 col-lg-2 col-form-label">
                                                <asp:Label ID="lblRaisedImageCount" runat="server" Text="" class="form-control-label"></asp:Label>
                                            </div>
                                            <div class="col-xl-1 col-lg-1" id="dvRaiseImage" runat="server">
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
                                            <label class="col-xl-3 col-lg-3 col-form-label font-weight-bold">Ticket Description :</label>
                                            <div class="col-xl-8 col-lg-8 col-form-label" style="margin-left: -8%;">
                                                <asp:Label ID="lblTicketdesc" runat="server" Text="" class="form-control-label"></asp:Label>
                                            </div>

                                            <%--  <label class="col-xl-3 col-lg-3 col-form-label"> Ticket Images :</label>   --%>
                                        </div>

                                        <br />

                                        <div class="form-group row" style="background-color: #00c5dc;">
                                            <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Raiser Details</label>
                                        </div>
                                        <div class=" row" style="padding-left: 2%;">
                                            <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Raised By :</label>
                                            <div class="col-xl-7 col-lg-7 col-form-label">
                                                <asp:Label ID="lblTicketRaisedBy" runat="server" Text="" class="form-control-label"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="row" style="padding-left: 2%;">
                                            <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Mobile No :</label>
                                            <div class="col-xl-3 col-lg-3 col-form-label">
                                                <asp:Label ID="lblTicketRaisedBy_MobileNo" runat="server" Text="" class="form-control-label"></asp:Label>
                                            </div>
                                            <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Email ID :</label>
                                            <div class="col-xl-3 col-lg-3 col-form-label">
                                                <asp:Label ID="lblTicketRaisedBy_EmailID" runat="server" Text="" class="form-control-label"></asp:Label>
                                            </div>
                                        </div>

                                        <br />


                                        <div id="dv_Custom_Field" runat="server">
                                            <div class="form-group row" style="background-color: #00c5dc;">
                                                <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Ticket Custom Fields Data</label>
                                            </div>

                                            <div class="form-group m-form__group row" >
                                                <asp:GridView ID="gvCustomField" runat="server" CssClass="table table-striped- table-bordered table-hover table-checkable"
                                                    HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" AutoGenerateColumns="false">
                                                    <Columns>
                                                    <asp:BoundField DataField="Custom Field" HeaderText="Custom Field" ItemStyle-Width="500" />
                                                    <asp:BoundField DataField="Value" HeaderText="Value" ItemStyle-Width="500" />
                                                </Columns>
                                                    <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                </asp:GridView>

                                            </div>
                                            <br />
                                        </div>



                                        <div class="form-group row" style="background-color: #00c5dc;">
                                            <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Ticket Assignment</label>
                                        </div>

                                        <div class="row" style="padding-left: 2%;">
                                            <label class="col-xl-3 col-lg-3 col-form-label font-weight-bold">Assigned To Department :</label>
                                            <div class="col-xl-3 col-lg-3 col-form-label">
                                                <asp:Label ID="lblAssignedDept" runat="server" Text="" class="form-control-label"></asp:Label>
                                            </div>
                                            <label class="col-xl-3 col-lg-3 col-form-label font-weight-bold">Current Level :</label>
                                            <div class="col-xl-3 col-lg-3 col-form-label">
                                                <asp:Label ID="lblCurrentLevel" runat="server" Text="" class="form-control-label"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="row" style="padding-left: 2%;">
                                            <label class="col-xl-3 col-lg-3 col-form-label font-weight-bold">Action Status :</label>
                                            <div class="col-xl-3 col-lg-3 col-form-label">
                                                <asp:Label ID="lblActionStatus" runat="server" Text="" class="form-control-label"></asp:Label>
                                            </div>
                                            <label class="col-xl-3 col-lg-3 col-form-label font-weight-bold">Ticket Status :</label>
                                            <div class="col-xl-3 col-lg-3 col-form-label">
                                                <asp:Label ID="lblTicketStatus" runat="server" Text="" class="form-control-label"></asp:Label>
                                            </div>
                                        </div>

                                        <div class=" row" style="padding-left: 2%;">
                                            <label class="col-xl-3 col-lg-3 col-form-label font-weight-bold">Downtime :</label>
                                            <div class="col-xl-3 col-lg-3 col-form-label">
                                                <asp:Label ID="lblDowntime" runat="server" Text="" class="form-control-label"></asp:Label>
                                            </div>

                                            <label class="col-xl-3 col-lg-3 col-form-label font-weight-bold">Uploaded Image Count :</label>
                                            <div class="col-xl-1 col-lg-1 col-form-label">
                                                <asp:Label ID="lblClosedImageCount" runat="server" Text="" class="form-control-label"></asp:Label>
                                            </div>
                                            <div class="col-xl-2 col-lg-2" id="dvCloseImage" runat="server">
                                                <asp:Repeater ID="rptTicketClosingImage" runat="server">
                                                    <ItemTemplate>
                                                        <table>
                                                            <tr>
                                                                <td style="width: 5%">
                                                                    <button type='button' data-toggle='modal' id="btnShowImageClose" data-target="#exampleModal" data-images="<%#Eval("CloseImagePath") %>" class='btn btn-accent m-btn m-btn--icon' data-container='body' style="width: 41px; height: 41px;" data-toggle='m-tooltip' data-placement='top' title='View Ticket Closing Image'>
                                                                        <i class='la la-image' style="margin-left: -106%; font-size: 2.3rem;"></i>
                                                                    </button>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>

                                        </div>
                                        <br />

                                        <div class="form-group row" style="background-color: #00c5dc;">
                                            <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Ticket Action History</label>
                                        </div>

                                        <div class="form-group m-form__group row" style="padding-left: 2%;">

                                            <asp:GridView ID="gvActionHistory" runat="server" CssClass="table table-striped- table-bordered table-hover table-checkable"
                                                HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                                                AutoGenerateColumns="false">
                                                <Columns>
                                                    <asp:BoundField DataField="Level" HeaderText="Level" ItemStyle-Width="50" />
                                                    <asp:BoundField DataField="User" HeaderText="User" ItemStyle-Width="150" />
                                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks" ItemStyle-Width="300" />
                                                    <asp:BoundField DataField="Action Date" HeaderText="Action Date" ItemStyle-Width="150" />
                                                    <asp:BoundField DataField="Expected Time" HeaderText="Expected Time" ItemStyle-Width="150" />
                                                    <asp:BoundField DataField="Ticket Status" HeaderText="Ticket Status" ItemStyle-Width="110" />
                                                    <asp:BoundField DataField="Action Status" HeaderText="Action Status" ItemStyle-Width="110" />
                                                </Columns>
                                                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                            </asp:GridView>

                                        </div>
                                        <br />


                                        <div id="dvTicketAction" runat="server">
                                            <div class="form-group row" style="background-color: #00c5dc;">
                                                <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Ticket Action</label>
                                            </div>

                                            <div id="dvAction" runat="server">

                                                <div class="form-group m-form__group row dvImageUpload" style="padding-left: 1%; display: none;" id="dvImageUpload" runat="server">
                                                    <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Ticket Images :</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                        <asp:FileUpload ID="FileUpload_TicketImage" runat="server" CssClass="btn btn-accent" AllowMultiple="true" ClientIDMode="Static" />
                                                        <asp:RequiredFieldValidator ID="rfvFileupload" ValidationGroup="validate" runat="server" Display="Dynamic" ForeColor="Red" Enabled="false"
                                                            ErrorMessage="Please upload image" ControlToValidate="FileUpload_TicketImage"></asp:RequiredFieldValidator>
                                                        <span id="ImageUpload_Msg" style="color: red;"></span>
                                                        <asp:HiddenField ID="Is_ImageUpload_ValidFile" runat="server" ClientIDMode="Static" Value="3" />
                                                    </div>

                                                </div>

                                                <div class="form-group m-form__group row" style="padding-left: 1%;" id="dvApprovalDetails" runat="server">
                                                    <label class="col-xl-2 col-lg-2 form-control-label font-weight-bold"><span style="color: red;">*</span> Action :</label>
                                                    <div class="col-xl-3 col-lg-4">
                                                        <asp:DropDownList ID="ddlAction" class="form-control m-input" runat="server" ClientIDMode="Static">
                                                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Value="In Progress" Text="In Progress"></asp:ListItem>
                                                            <asp:ListItem Value="Hold" Text="Hold"></asp:ListItem>
                                                            <asp:ListItem Value="Closed" Text="Close"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="validate" runat="server" Display="Dynamic" ForeColor="Red"
                                                            ErrorMessage="Please select action" ControlToValidate="ddlAction" InitialValue="0"></asp:RequiredFieldValidator>
                                                    </div>

                                                    <label class="col-xl-2 col-lg-2 form-control-label font-weight-bold">Remarks :</label>
                                                    <div class="col-xl-5 col-lg-4">
                                                        <asp:TextBox ID="txtCloseTicketDesc" runat="server" TextMode="MultiLine" class="form-control m-input autosize_textarea TermCondition_textarea" ClientIDMode="Static"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvClosingRemarks" ValidationGroup="validate" runat="server" Display="Dynamic" ForeColor="Red" Enabled="false"
                                                            ErrorMessage="Please enter remarks" ControlToValidate="txtCloseTicketDesc"></asp:RequiredFieldValidator>
                                                        <span id="Remarks_Msg" style="color: red;"></span>
                                                    </div>

                                                </div>

                                                <div class="form-group m-form__group row" id="dvClose" runat="server">
                                                    <div class="col-xl-3 col-lg-3"></div>
                                                    <div class="btn-group col-xl-3 col-lg-3">

                                                        <%-- <asp:Button ID="btnAccept" runat="server" class="btn btn-success  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnAccept_Click" Text="Accept" />
                                                    &nbsp;&nbsp;&nbsp;--%>
                                                        <asp:Button ID="btnClose" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnClose_Click" Text="Submit" ValidationGroup="validate" ClientIDMode="Static" />

                                                        <asp:Button ID="btnTest" Style="display: none;" runat="server" />
                                                        <cc1:ModalPopupExtender ID="mpeTicketSaveSuccess" runat="server" PopupControlID="pnlTicketSuccess" TargetControlID="btnTest"
                                                            CancelControlID="btnCloseHeader2" BackgroundCssClass="modalBackground">
                                                        </cc1:ModalPopupExtender>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <div id="dv_force_close" runat="server">
                                            <div class="form-group row" style="background-color: #00c5dc;">
                                                <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Force Close Details</label>
                                            </div>
                                            <div class=" row" style="padding-left: 2%;">
                                                <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Force Close By :</label>
                                                <div class="col-xl-3 col-lg-3 col-form-label">
                                                    <asp:Label ID="lbl_force_close_by" runat="server" Text="" class="form-control-label"></asp:Label>
                                                </div>

                                                <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Force Close Date :</label>
                                                <div class="col-xl-3 col-lg-3 col-form-label">
                                                    <asp:Label ID="lbl_force_close_date" runat="server" Text="" class="form-control-label"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="row" style="padding-left: 2%;">
                                                <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Force Close Remarks :</label>
                                                <div class="col-xl-9 col-lg-9 col-form-label">
                                                    <asp:Label ID="lbl_force_close_remarks" runat="server" Text="" class="form-control-label"></asp:Label>
                                                </div>

                                            </div>
                                        </div>

                                        <br />

                                        <div class="form-group m-form__group row" id="dvAccept" runat="server">
                                            <div class="col-xl-3 col-lg-3"></div>
                                            <div class="btn-group col-xl-3 col-lg-3">

                                                <asp:Button ID="btnAccept" runat="server" class="btn btn-success  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnAccept_Click" Text="Accept" />

                                            </div>
                                        </div>

                                        <div class="form-group m-form__group row" style="padding-left: 15%;">
                                            <asp:Label ID="lblTicketErrorMsg" Text="" runat="server" CssClass="col-xl-8 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="lblUser" runat="server"></asp:Label>
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
</div>

</asp:Content>
