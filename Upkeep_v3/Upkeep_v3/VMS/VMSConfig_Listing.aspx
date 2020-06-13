<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="VMSConfig_Listing.aspx.cs" Inherits="Upkeep_v3.VMS.VMSConfig_Listing" %>

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
            $(document).on("click", ".btnModalLink", function () {
                var newUrl = $(this).data('url');
                $(".modal-body #hLink").html(newUrl);
                $(".modal-body #hLink").attr("href", newUrl)

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
        <div class="modal-dialog" role="document" style="width:fit-content;">
            <div class="modal-content">
               <%-- <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Scan QR</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>--%>
                <div class="modal-body">
                    <figure class="figure">
                        <div id="plBarCode" runat="server" class="text-center"></div>
                      
                        <h5 class="text-center text-primary" id="hLink"></h5>
                    </figure>

                </div>
               
            </div>
        </div>
    </div>


</asp:Content>
