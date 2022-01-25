<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="System_Settings.aspx.cs" Inherits="Upkeep_v3.General_Masters.System_Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>System Settings</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">

        $(document).ready(
            function () {
                $(document).on("click", ".btnModalLink", function () {
                    var newUrl = $("[id*=hdnLink]").val();
                    $(".modal-body #hLink").html(newUrl);
                    $(".modal-body #hLink").attr("href", newUrl)
                    $("#ContentPlaceHolder1_plBarCode img").hide();
                    $("#" + newUrl.substr(newUrl.length - 5)).show();
                });
            });
    </script>
    <script>
        //Copy Element Function

        function copyText() {
            var range, selection, worked;
            var element = document.getElementById("hLink");

            if (document.body.createTextRange) {
                range = document.body.createTextRange();
                range.moveToElementText(element);
                range.select();
            } else if (window.getSelection) {
                selection = window.getSelection();
                range = document.createRange();
                range.selectNodeContents(element);
                selection.removeAllRanges();
                selection.addRange(range);
            }

            try {
                document.execCommand('copy');
                toastr.options = {
                    "closeButton": true,
                    "debug": false,
                    "newestOnTop": false,
                    "progressBar": false,
                    "positionClass": "toast-bottom-center",
                    "preventDuplicates": false,
                    "onclick": null,
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "3000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                };

                toastr.success("Successfully Copied..!");
            }
            catch (err) {
                toastr.options = {
                    "closeButton": true,
                    "debug": false,
                    "newestOnTop": false,
                    "progressBar": false,
                    "positionClass": "toast-top-right",
                    "preventDuplicates": false,
                    "onclick": null,
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "3000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                };

                toastr.error("Enable To Copy..!");
            }

        }

    </script>

    <script>

        function PrintDiv() {
            var divContents = document.getElementById("printdivcontent").innerHTML;
            var printWindow = window.open('', '', 'height=400,width=400');
            printWindow.document.write('<html><head><title>Print DIV Content</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(divContents);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            printWindow.print();
        }

    </script>
    <div class="m-content">

        <div class="row">
            <div class="col-md-12">
                <div class="m-portlet m-portlet--tab">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <span class="m-portlet__head-icon m--hide">
                                    <i class="la la-gear"></i>
                                </span>

                                <asp:Button ID="btnSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnSave_Click" Text="Save Settings" ValidationGroup="ValidateUser" />
                                <asp:Label ID="lblUserErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>

                            </div>
                        </div>
                    </div>

                </div>

            </div>
        </div>

        <div class="row">

            <div class="col-md-6">

                <!-- Ticketing Settings-->
                <!--begin::Portlet-->
                <div class="m-portlet m-portlet--tab">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <span class="m-portlet__head-icon m--hide">
                                    <i class="la la-gear"></i>
                                </span>
                                <h3 class="m-portlet__head-text">Ticketing Settings
                                </h3>
                            </div>
                        </div>
                    </div>
                    <div class="m-portlet__body">

                        <!--begin::Section-->
                        <div class="m-section">
                            <span class="m-section__sub">Customize your Ticketing Management System Functions:
                            </span>
                            <div class="m-section__content">
                                <div class="m-demo" data-code-preview="true" data-code-html="true" data-code-js="false">
                                    <div class="m-demo__preview">

                                        <!--begin::Form-->
                                        <form class="m-form">

                                            <div class="m-form__group form-group">

                                                <div class="m-checkbox-list">



                                                    <%--    <label class="m-checkbox m-checkbox--check-bold m-checkbox--state-brand"></label>--%>

                                                    <!--      <div class="col-xl-3 col-lg-3">-->
                                                    <input type="checkbox" id="photoRaisingCheck" runat="server" class="customcontrolinput" clientidmode="Static" />
                                                    Photo Upload Compulsory while raising ticket :


                                         <!--   </div>-->
                                                    <%-- <input type="checkbox"> Photo Upload Compulsory while raising ticket--%>
                                                    <span></span>
                                                    <br />
                                                    <br />

                                                    <!--   <label class="m-checkbox m-checkbox--check-bold m-checkbox--state-brand">-->

                                                    <input type="checkbox" id="PhotoClosingCheck" runat="server" class="customcontrolinput" clientidmode="Static" />

                                                    Photo Upload Compulsory while closing ticket
                                                                            
                                                                            <%-- <input type="checkbox" checked="checked"> Photo Upload Compulsory while closing ticket
																		    <span></span>--%>
                                                    <!--   </label>-->

                                                    <br />
                                                    <br />


                                                    <input type="checkbox" id="RemarksCompRaising" runat="server" class="customcontrolinput" clientidmode="Static" />
                                                    Remarks Compulsory while raising ticket
                                                                        
                                                                     <%--   <label class="m-checkbox m-checkbox--check-bold m-checkbox--state-brand">
																		    <input type="checkbox" checked="checked" > Remarks Compulsory while raising ticket
																		    <span></span>
																	    </label>

                                                                        <label class="m-checkbox m-checkbox--check-bold m-checkbox--state-brand">
																		    <input type="checkbox" > Remarks Compulsory while closing ticket
																		    <span></span>
																	    </label>--%>

                                                    <br />
                                                    <br />

                                                    <input type="checkbox" id="RemarksCompclosing" runat="server" class="customcontrolinput" clientidmode="Static" />

                                                    Remarks Compulsory while closing ticket
                                                                        
                                                                        <br />
                                                    <br />




                                                </div>
                                            </div>


                                            <div class="m-form__group form-group row">

                                                <label class="col-3 col-form-label">Ticket Expiry</label>
                                                <div class="col-3">
                                                    <span class="m-switch m-switch--sm m-switch--icon">
                                                        <label>


                                                            <input type="checkbox" id="TicketExpiry" runat="server" class="customcontrolinput" clientidmode="Static" />


                                                            <%--    <input type="checkbox" checked="checked" name="">--%>
                                                            <span></span>
                                                        </label>
                                                    </span>
                                                </div>

                                                <div class="alert m-alert m-alert--default" role="alert">
                                                    NOTE : If you Disable Ticket expiry , Downtime for Escalated Ticket will keep on increasing until it is closed.
                                                </div>

                                            </div>
                                            <div class="m-form__group form-group row">
                                                <div class="col-lg-7">
                                                    Generate Ticket from QR Code 
                                                </div>
                                                <div class="col-lg-4">
                                                    <asp:Button ID="btn_Generate_TicketQR" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btn_Generate_TicketQR_Click" Text="Generate QR"  />
                                                    <a href='#' id="btn_show_QR" runat="server" class='btn btn-focus m-btn m-btn--icon btn-sm m-btn--icon-only btnModalLink' data-container='body' data-toggle='modal' data-target='#modalLink' data-placement='top' data-url='" + URL + "' title='Click here to view QR code'><i class='la la-qrcode' style='font-size: 2.1rem;'></i></a>
                                                </div>
                                            </div>

                                        </form>

                                        <!--end::Form-->
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!--end::Section-->
                    </div>
                </div>
                <!--end::Portlet-->

                <!-- Checklist Settings-->
                <div class="m-portlet m-portlet--tab">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <span class="m-portlet__head-icon m--hide">
                                    <i class="la la-gear"></i>
                                </span>
                                <h3 class="m-portlet__head-text">Checklist Settings
                                </h3>
                            </div>
                        </div>
                    </div>
                    <div class="m-portlet__body">

                        <!--begin::Section-->
                        <div class="m-section">
                            <span class="m-section__sub">Customize your Checklist Management Functions:
                            </span>
                            <div class="m-section__content">
                                <div class="m-demo" data-code-preview="true" data-code-html="true" data-code-js="false">
                                    <div class="m-demo__preview">



                                        <div class="m-form__group form-group">

                                            <div class="m-checkbox-list">

                                                <input type="checkbox" id="chk_QR_Compulspory" runat="server" class="customcontrolinput" clientidmode="Static" />

                                                QR Scan Compulsory to attend Scheduled Checklists
                                                                         
																		   

                                            </div>
                                        </div>



                                    </div>
                                </div>
                            </div>


                        </div>

                        <!--end::Section-->
                    </div>
                </div>


            </div>
            <div class="col-md-6">

                <!--begin::Portlet-->
                <div class="m-portlet m-portlet--tab">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <span class="m-portlet__head-icon m--hide">
                                    <i class="la la-gear"></i>
                                </span>
                                <h3 class="m-portlet__head-text">Work Permit Settings
                                </h3>
                            </div>
                        </div>
                    </div>
                    <div class="m-portlet__body">

                        <!--begin::Section-->
                        <div class="m-section">
                            <span class="m-section__sub">Customize your Work permit Management System Functions:
                            </span>
                            <div class="m-section__content">
                                <div class="m-demo" data-code-preview="true" data-code-html="true" data-code-js="false">
                                    <div class="m-demo__preview">

                                        <!--begin::Form-->
                                        <form class="m-form">

                                            <div class="m-form__group form-group">

                                                <div class="m-checkbox-list">
                                                    <label class="m-checkbox m-checkbox--check-bold m-checkbox--state-brand">
                                                        <input type="checkbox" checked="checked">
                                                        Enable / Disable Work Permit Auto-Expiry
																		    <span></span>
                                                    </label>


                                                    <span class="m-form__help">Disabling Auto-Expire will not mark the Work Permits as Expired, if it is not approved before the Permit To-Date</span>



                                                </div>
                                            </div>

                                        </form>

                                        <!--end::Form-->
                                    </div>
                                </div>
                            </div>

                        </div>

                        <!--end::Section-->
                    </div>
                </div>
                <!--end::Portlet-->


                <!--begin::Portlet-->
                <div class="m-portlet m-portlet--tab">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <span class="m-portlet__head-icon m--hide">
                                    <i class="la la-gear"></i>
                                </span>
                                <h3 class="m-portlet__head-text">Gate Pass Settings
                                </h3>
                            </div>
                        </div>
                    </div>
                    <div class="m-portlet__body">

                        <!--begin::Section-->
                        <div class="m-section">
                            <span class="m-section__sub">Customize your Work permit Management System Functions:
                            </span>
                            <div class="m-section__content">
                                <div class="m-demo" data-code-preview="true" data-code-html="true" data-code-js="false">
                                    <div class="m-demo__preview">

                                        <!--begin::Form-->
                                        <form class="m-form">

                                            <div class="m-form__group form-group">

                                                <div class="m-checkbox-list">
                                                    <label class="m-checkbox m-checkbox--check-bold m-checkbox--state-brand">
                                                        <input type="checkbox" checked="checked">
                                                        Enable / Disable Gate Pass Auto-Expiry
																		    <span></span>
                                                    </label>


                                                    <span class="m-form__help">Disabling Auto-Expire will not mark the Gate Pass as Expired, if it is not approved before the Gate pass To-Date & Time </span>



                                                </div>
                                            </div>

                                        </form>

                                        <!--end::Form-->
                                    </div>
                                </div>
                            </div>

                        </div>

                        <!--end::Section-->
                    </div>
                </div>
                <!--end::Portlet-->



                <!--begin::Portlet-->
                <div class="m-portlet m-portlet--tab">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <span class="m-portlet__head-icon m--hide">
                                    <i class="la la-gear"></i>
                                </span>
                                <h3 class="m-portlet__head-text">Geo Fencing Settings
                                </h3>
                            </div>
                        </div>
                    </div>
                    <div class="m-portlet__body">

                        <!--begin::Section-->
                        <div class="m-section">
                            <span class="m-section__sub">Customize your Geo-Fencing Settings here:
                            </span>
                            <div class="m-section__content">
                                <div class="m-demo" data-code-preview="true" data-code-html="true" data-code-js="false">
                                    <div class="m-demo__preview">

                                        <!--begin::Form-->
                                        <form class="m-form">

                                            <div class="form-group m-form__group">
                                                <label>Lattitude</label>
                                                <div class="m-input-icon m-input-icon--left">
                                                    <input type="text" class="form-control m-input" placeholder="Enter Lattitude">
                                                    <span class="m-input-icon__icon m-input-icon__icon--left"><span><i class="la la-map-marker"></i></span></span>
                                                </div>

                                            </div>
                                            <div class="form-group m-form__group">

                                                <label>Longitude</label>
                                                <div class="m-input-icon m-input-icon--left">
                                                    <input type="text" class="form-control m-input" placeholder="Enter Longitude">
                                                    <span class="m-input-icon__icon m-input-icon__icon--left"><span><i class="la la-map-marker"></i></span></span>
                                                </div>
                                            </div>

                                            <div id="m_gmap_6" style="" width="640" height="480">
                                                <iframe src="https://www.google.com/maps/d/embed?mid=15VeEbeTCNB81rzmQHEC-UMUEaJ5fbw_V"></iframe>
                                            </div>


                                            <div class="alert m-alert m-alert--default" role="alert">
                                                NOTE : Users will only be able to operate Web & Mobile Applications, when they are within the fencing range set below
                                            </div>

                                            <div class="form-group m-form__group">

                                                <label>Range</label>
                                                <div class="m-input-icon m-input-icon--left">
                                                    <input type="text" class="form-control m-input" placeholder="Enter Fencing Range in Meters">
                                                    <span class="m-input-icon__icon m-input-icon__icon--left"><span><i class="la la-map-marker"></i></span></span>
                                                </div>
                                            </div>
                                    </div>
                                </div>


                                </form>

														    <!--end::Form-->
                            </div>
                        </div>
                    </div>

                </div>

                <!--end::Section-->
            </div>
        </div>
        <!--end::Portlet-->
    </div>





    <div class="modal fade" id="modalLink" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document" style="width: fit-content;">
            <div class="modal-content">

                <div class="modal-body">
                    <figure class="figure" id="printdivcontent">
                        <div id="Div1" runat="server" class="text-center">
                            <asp:PlaceHolder ID="plBarCode" runat="server" />
                        </div>

                        <h6 class="text-center text-primary" style="word-break: break-all;" id="hLink"></h6>
                        <asp:HiddenField ID="hdnLink" runat="server" />
                    </figure>

                    <h5 class="text-center text-primary">
                        <button onclick="PrintDiv();" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m-btn--align-center">
                            <span>
                                <i class="la la-qrcode "></i>
                                <i class="la la-download "></i>
                                <span>Download QR Code</span>
                            </span>
                        </button>
                        <a href="#" onclick='copyText()' class="btn btn-outline-success m-btn m-btn--icon m-btn--icon-only" data-toggle="m-popover" title="" data-content="Click to Copy Link to QR Code">
                            <i class="fa fa-copy"></i>
                        </a>
                    </h5>

                </div>

            </div>
        </div>
    </div>

</asp:Content>
