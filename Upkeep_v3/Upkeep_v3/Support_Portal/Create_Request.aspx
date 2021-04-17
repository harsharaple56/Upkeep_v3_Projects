<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Create_Request.aspx.cs" Inherits="Upkeep_v3.Support_Portal.Create_Request" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style1 {
            left: 0px;
            top: 0px;
        }
    </style>

    <script type="text/javascript">
        $(function () {
            $('#<%=fileUpload_RequestImage.ClientID %>').change(function () {
                var fileExtension = ['jpeg', 'jpg', 'png'];
                $('#SignUpload_Msg').text('').hide();
                if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
                    //alert("Only '.jpeg','.jpg', '.png', formats are allowed."); 
                    $('#SignUpload_Msg').text("Failed!! Please upload jpg, jpeg, png file only.").show();
                    $(this).replaceWith($(this).val('').clone(true));
                }
                //100000 Byte -- 100 KB
                if ($(this).get(0).files[0].size > (100000)) {
                    $('#SignUpload_Msg').text("Failed!! Max allowed file size is 100 KB").show();
                    $(this).replaceWith($(this).val('').clone(true));
                }
            })

        })
    </script>


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


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">
                        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>


                        <div class="m-portlet__head">
                            <div class="m-portlet__head-progress">
                            </div>
                            <div class="m-portlet__head-wrapper">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">Create a New Support Request
                                        </h3>
                                    </div>
                                </div>

                                <div class="m-portlet__head-tools">


                                    <a href="<%= Page.ResolveClientUrl("Dashboard.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                        <span>
                                            <i class="la la-arrow-left"></i>
                                            <span>Back</span>
                                        </span>
                                    </a>
                                    <div class="btn-group">

                                        <asp:Button ID="btnSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnSave_Click" Text="Submit Request" ValidationGroup="ValidateUser" />

                                    </div>
                                </div>

                            </div>
                        </div>



                        <!--begin: Form Body -->
                        <div class="m-form m-form--fit m-form--group-seperator-dashed">
                            <div class="row">
                                <div class="col-xl-12">
                                    <div class="m-form__section m-form__section--first">

                                        <div class="form-group m-form__group row" style="padding-bottom: 0px;">
                                            <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Select Request Type :</label>
                                            <div class="col-xl-3 col-lg-4">
                                                <asp:DropDownList ID="ddlRequestType" class="form-control m-input" runat="server">
                                                    <asp:ListItem Value="">-- Select Request Type --</asp:ListItem>
                                                    <asp:ListItem>Issue / Bug</asp:ListItem>
                                                    <asp:ListItem>Feature Request</asp:ListItem>
                                                    <asp:ListItem>Import Data</asp:ListItem>
                                                    <asp:ListItem>Re-Configuration</asp:ListItem>
                                                    <asp:ListItem>Training</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvddlRequestType" runat="server" ControlToValidate="ddlRequestType" ValidationGroup="ValidateRequest"
                                                    ErrorMessage="Please select Request Type" InitialValue="0" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>



                                            <div class="col-xl-7 col-lg-4">
                                                <div class="alert m-alert m-alert--default" role="alert">
                                                    Select the Type of Ticket. <b><code>Click Here</code></b> for more info on different Types mentioned.
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group m-form__group row" style="padding-bottom: 0px;">


                                            <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Select Module :</label>
                                            <div class="col-xl-3 col-lg-4">
                                                <asp:DropDownList ID="ddlModule" class="form-control m-input" runat="server">
                                                    <asp:ListItem Value="">-- Select Request Type --</asp:ListItem>
                                                    <asp:ListItem>Ticketing</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlModule" ValidationGroup="ValidateRequest"
                                                    ErrorMessage="Please select Module where Issue is occuring" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>

                                            <div class="col-xl-7 col-lg-4">
                                                <div class="alert m-alert m-alert--default" role="alert">
                                                    Select the Module which is related to your Query.
                                                </div>
                                            </div>

                                        </div>
                                        <div class="form-group m-form__group row" style="padding-bottom: 0px;">
                                            <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Upload Images</label>
                                            <div class="col-xl-3 col-lg-4">
                                                <asp:FileUpload ID="fileUpload_RequestImage" runat="server" />
                                            </div>
                                            <div class="col-xl-1 col-lg-1" runat="server" style="display: none;" id="dvRequestImage">
                                                <asp:Repeater ID="rptRequestImage" runat="server">
                                                    <ItemTemplate>
                                                        <table>
                                                            <tr>
                                                                <td style="width: 5%">
                                                                    <button type='button' data-toggle='modal' id="btnShowImage" data-target="#exampleModal" data-images="<%#Eval("Request_Photo") %>" class='btn btn-accent m-btn m-btn--icon' data-container='body' style="width: 41px; height: 41px;" data-toggle='m-tooltip' data-placement='top' title='View Uploaded Image'>
                                                                        <i class='la la-image' style="margin-left: -106%; font-size: 2.3rem;"></i>
                                                                    </button>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>

                                            <div class="col-xl-7 col-lg-4">
                                                <span id="RequestImageUpload_Msg" style="color: red;"></span>
                                                <div class="alert m-alert m-alert--default" role="alert">
                                                    Upload Relevant Images explaining the any Issue / Optimizations.
                                                </div>
                                            </div>
                                        </div>


                                        <div class="form-group m-form__group row">
                                            <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Description :</label>

                                            <div class="alert m-alert m-alert--default" role="alert">
                                                Give a detailed Description on the Ticket you are raising. This will assist us in understanding your query &
                                                    resolve the ticket at the earliest. 
                                                    </br>
                                                    <b>Example</b> <code>Work Permit No. #WPG2334 Not showing on my Login. I am in the approval Matrix</code>.
                                            </div>
                                            <div class="col-xl-12 col-lg-4">
                                                <textarea id="txtRequestDescription" cols="20" rows="2" runat="server" class="form-control m-input" placeholder="Enter Detailed Description about your Request">

                                                </textarea>
                                                <asp:RequiredFieldValidator ID="rfvRequestDescription" runat="server" ControlToValidate="txtRequestDescription" ValidationGroup="ValidateUser"
                                                    ErrorMessage="Please enter detailed description" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>


                                            </div>
                                            <label id="lblError" runat="server"></label>
                                        </div>

                                    </div>

                                </div>
                            </div>
                        </div>


                    </div>
                </div>

                <!--end::Portlet-->
            </div>
        </div>
    </div>


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

                    </div>
                </div>

            </div>
        </div>
    </div>


</asp:Content>
