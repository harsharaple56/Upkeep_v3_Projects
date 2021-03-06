<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="VMSConfig_Listing.aspx.cs" Inherits="Upkeep_v3.VMS.VMSConfig_Listing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(
            function () {
                $('#m_table_1').DataTable({
                    responsive: true,
                    pagingType: 'full_numbers',
                    'fnDrawCallback': function () {
                        init_plugins();
                    }
                });
                $(document).on("click", ".btnModalLink", function () {
                    var newUrl = $(this).data('url');
                    $(".modal-body #hLink").html(newUrl);
                    $(".modal-body #hLink").attr("href", newUrl)
                    $("#ContentPlaceHolder1_plBarCode img").hide();
                    $("#" + newUrl.substr(newUrl.length - 5)).show();

                    // As pointed out in comments, 
                    // it is unnecessary to have to manually call the modal.
                    // $('#addBookDialog').modal('show');
                    //jQuery("#demo").qrcode("url or text");

                    // or
                    //$('#demo').qrcode(newUrl);

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


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="m-portlet m-portlet--mobile">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <h3 class="m-portlet__head-text">VMS Configuration Listing		
                            </h3>
                        </div>
                    </div>
                    <div class="m-portlet__head-tools">
                        <ul class="m-portlet__nav">
                            <li class="m-portlet__nav-item">
                                <a href="<%= Page.ResolveClientUrl("Visit_Configuration.aspx") %>" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md">
                                    <span>
                                        <i class="la la-plus"></i>
                                        <span>New Configuration</span>
                                    </span>
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="m-portlet__body">

                    <!--begin: Datatable -->
                    <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">
                        <thead>
                            <tr>
                                <th>Config Title</th>
                                <th>Company</th>
                                <th>Form For</th>
                                <th>Created on</th>
                                <th>Action</th>
                            </tr>
                        </thead>

                        <tbody>
                            <%=fetchVMSConfigListing()%>
                        </tbody>
                    </table>
                </div>
            </div>

            <!-- END EXAMPLE TABLE PORTLET-->

        </div>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="modalLink" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document" style="width: fit-content;">
            <div class="modal-content">
                <%-- <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Scan QR</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>--%>
                <div class="modal-body">
                    <figure class="figure" id="printdivcontent">
                        <div id="plBarCode" runat="server" class="text-center"></div>
                        <h5 class="text-center text-primary" id="hLink"></h5>

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
