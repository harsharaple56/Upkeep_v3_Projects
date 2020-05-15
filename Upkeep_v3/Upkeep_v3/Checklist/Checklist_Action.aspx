<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Checklist_Action.aspx.cs" Inherits="Upkeep_v3.Checklist.Checklist_Action" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        //$(document).ready(function () {

        //    $('#photo_modal').on('show.bs.modal', function (event) {
        //        var button = $(event.relatedTarget);
        //        var src = button.data('src');
        //        $(this).find('.modal-body img').attr('src', src);
        //    })
        //});
        $(document).ready(function () {
        $('#exampleModal').on('show.bs.modal', function (event) {
            
				var button      = $(event.relatedTarget); // Button that triggered the modal
				var title       = button.data('title'); // Extract info from data-* attributes
            var images_list = button.data('images'); // Extract info from data-* attributes
           
			  var modal = $(this);
			  modal.find('.modal-title').text(title);
			  var images = images_list.split(',')
			  modal.find('.modal-body .carousel-inner').html('')
			  $.each(images,function(index, image){
			  	if(index == 0)
			  		var item = '<div class="carousel-item active">';
			  	else
			  		var item = '<div class="carousel-item">';
			  	item += '<img class="d-block w-100" src="'+image+'"></div>'
			  	modal.find('.modal-body .carousel-inner').append(item);
			  });
			  //$('.carousel').carousel();
            })
            });
    </script>


    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <form class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmChkList">
                            <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

                            <div class="m-portlet__head">
                                <div class="m-portlet__head-progress">

                                    <!-- here can place a progress bar-->
                                </div>
                                <div class="m-portlet__head-wrapper">
                                    <div class="m-portlet__head-caption">
                                        <div class="m-portlet__head-title">
                                            <h3 class="m-portlet__head-text">Checklist Details
                                            </h3>
                                        </div>
                                    </div>

                                    <div class="m-portlet__head-tools">
                                        <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
                                        <%--<a href="<%= Page.ResolveClientUrl("~/Checklist/MyChecklist.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                            <span>
                                                <i class="la la-arrow-left"></i>
                                                <span>Back</span>
                                            </span>
                                        </a>--%>
                                        <div class="btn-group">

                                            <asp:Button ID="btnBack" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md " Style="margin-right: 20px;" OnClick="btnCancel_Click" ValidationGroup="validateTicket" Text="Back" />
                                        </div>
                                    </div>

                                </div>
                            </div>

                            <div class="m-portlet__body " style="padding: 0.4rem 2.2rem;">
                                <!--begin: Form Body -->
                                <div class="m-portlet__body " style="padding: 0.3rem 2.2rem;">

                                    <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                        <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Schedule Date Time :</label>
                                        <div class="col-xl-3 col-lg-3 col-form-label">
                                            <asp:Label ID="lblScheduleDateTime" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                        </div>

                                        <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold" style="text-align: right;">Ticket Number :</label>
                                        <div class="col-xl-3 col-lg-3 col-form-label">
                                            <asp:Label ID="lblTicketNo" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                        </div>

                                    </div>

                                    <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                        <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">From :</label>
                                        <div class="col-xl-3 col-lg-3 col-form-label">
                                            <asp:Label ID="lblFrom" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                        </div>

                                        <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold" style="text-align: right;">Department :</label>
                                        <div class="col-xl-3 col-lg-3 col-form-label">
                                            <asp:Label ID="lblDepartment" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                        <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Checklist :</label>
                                        <div class="col-xl-3 col-lg-3 col-form-label">
                                            <asp:Label ID="lblChecklist" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                        <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Zone :</label>
                                        <div class="col-xl-3 col-lg-3 col-form-label">
                                            <asp:Label ID="lblZone" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                        <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Location :</label>
                                        <div class="col-xl-3 col-lg-3 col-form-label">
                                            <asp:Label ID="lblLocation" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                        </div>

                                        <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold" style="text-align: right;">Sub Location :</label>
                                        <div class="col-xl-3 col-lg-3 col-form-label">
                                            <asp:Label ID="lblSubLocation" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                        </div>
                                    </div>


                               
                                    <br />
                                    <hr />
                                    <div class="m-portlet__head-title">
                                        <h4 class="m-portlet__head-text font-weight-bold">Checklist Points
                                        </h4>
                                    </div>



                                    <asp:Repeater ID="rptChecklistPoints" runat="server" OnItemDataBound="rptChecklistPoints_ItemDataBound">
                                        <ItemTemplate>
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="width: 5%">
                                                        <asp:Label ID="lblRowNum" runat="server" Text='<%#Eval("RowNum") %>' CssClass="form-control-label col-form-label"></asp:Label>
                                                        <asp:Label ID="lblChecklistPointID" runat="server" Text='<%#Eval("Chk_Point_Id") %>' Style="display: none;"></asp:Label>
                                                    </td>
                                                    <td style="width: 90%" colspan="2">
                                                        <asp:Label ID="lblChecklistPoint" runat="server" Text='<%#Eval("Chk_Point_Desc") %>' ClientIDMode="Static" CssClass="form-control-label col-form-label font-weight-bold"></asp:Label>
                                                    </td>
                                                    <%--<td style="width: 5%">

                                                    </td>--%>
                                                </tr>
                                                <br />
                                                <tr>
                                                    <td style="width: 5%"></td>
                                                    <td style="width: 19%" id="tdYesNo" runat="server">
                                                        <div class="">
                                                            <div class="m-radio-inline">
                                                                <label class="m-radio m-radio--state-success">
                                                                    <asp:RadioButton ID="rdbYes" runat="server" Checked='<%#Eval("Yes") %>' GroupName="Checklist" ClientIDMode="Static" />
                                                                    Yes
																		<span></span>
                                                                </label>
                                                                <label class="m-radio m-radio--state-danger">
                                                                    <asp:RadioButton ID="rdbNo" runat="server" Checked='<%#Eval("No") %>' GroupName="Checklist" ClientIDMode="Static" />
                                                                    No
																		<span></span>
                                                                </label>
                                                            </div>
                                                        </div>
                                                    </td>

                                                    <td style="width: 76%" id="tdRemarks" runat="server">
                                                        <div class="form-group row">
                                                            <label class="col-form-label" style="padding-top: 3%;">Remarks : </label>
                                                            &nbsp;
                                                            <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Text='<%#Eval("Remark") %>' class="form-control m-input" ClientIDMode="Static"
                                                                Width="45%" MaxLength="500">
                                                            </asp:TextBox>
                                                            &nbsp;
                                                            <asp:FileUpload ID="FileUpload_ChecklistImage" runat="server" ClientIDMode="Static" CssClass="btn" Style="width: 36%;" AllowMultiple="true" />
                                                            &nbsp;
                                                            <button type='button' data-toggle='modal' data-target="#exampleModal" data-images="<%#Eval("ImagePath") %>"  class='btn btn-accent m-btn m-btn--icon' data-container='body' style="width: 41px; height: 41px;" data-toggle='m-tooltip' data-placement='top' title='View Uploaded Image'>
                                                                <i class='la la-image' style="margin-left: -106%; font-size: 2.3rem;"></i> 
                                                            </button>

                                                        </div>
                                                    </td>

                                                    <td style="display: none;">
                                                        <asp:Label ID="lblAnswerType" runat="server" Text='<%#Eval("Answer_Type") %>' CssClass="form-control-label col-form-label"></asp:Label>
                                                    </td>

                                                </tr>



                                            </table>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                    <br />
                                    <div class="col-lg-9 ml-lg-auto">
                                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Style="margin-right: 20px;" OnClick="btnSubmit_Click" ValidationGroup="validateTicket" Text="Submit" />

                                        <asp:Button ID="btnCancel" runat="server" class="btn btn-secondary btn-outline-hover-danger btn-sm m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10" Style="margin-right: 20px;" OnClick="btnCancel_Click" ValidationGroup="validateTicket" Text="Cancel" />

                                        <asp:Label ID="lblTicketErrorMsg" Text="" runat="server" CssClass="col-xl-8 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>

                                    </div>
                                    <div class="" id="dvStatus" runat="server">
                                        <label id="lblStatus" runat="server" class="col-xl-3 col-lg-2 col-form-label font-weight-bold" style="color: green;">Request Closed On </label>
                                        <asp:Label ID="lblStatusTime" runat="server" CssClass="font-weight-bold col-form-label" Style="color: green; margin-left: -8%;"></asp:Label>

                                    </div>
                                    <br />
                                    <br />
                                </div>
                            </div>

                            <%--<div class="modal fade" id="photo_modal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document" style="max-width: 55%; max-height: 55%;">
                                    <div class="modal-content" style="width: 100%;">
                                        <div class="modal-header" style="padding: 10px;">
                                            <h5 class="modal-title" id="exampleModalLabel">Uploaded Image</h5>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close" style="margin-top: -4px;">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                        </div>
                                        <div class="modal-body text-center">
                                            <img class="img-responsive" src="" style="width: 100%;" />

                                           
                                        </div>
                                        
                                    </div>
                                </div>
                            </div>--%>

                            <div aria-hidden="true" aria-labelledby="exampleModalLabel" class="modal fade" id="exampleModal" role="dialog" tabindex="-1">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h5 class="modal-title" id="exampleModalLabel">Uploaded Image
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


                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
