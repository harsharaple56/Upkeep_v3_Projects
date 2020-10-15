<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="ChkConfig_Listing.aspx.cs" Inherits="Upkeep_v3.CheckList.ChkConfig_Listing" %>

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
            //$(document).on("click", ".btnModalLink", function () {
            //    var newUrl = $(this).data('url');
            //    $(".modal-body #hLink").html(newUrl);
            //    $(".modal-body #hLink").attr("href", newUrl)
            //    $("#" + newUrl.substr(newUrl.length - 5)).show();
            //    // As pointed out in comments, 
            //    // it is unnecessary to have to manually call the modal.
            //    // $('#addBookDialog').modal('show');
            //    //jQuery("#demo").qrcode("url or text");
            //    // or
            //    //$('#demo').qrcode(newUrl);
            //});

            $(".removeItem").click(function (event) {
                //var row_index = $(this).parent().parent().index();
                //alert(row_index);
                var ConfigID = $(this).attr("data-config-id");
                //alert(ConfigID);
                $("#hdnDeleteID").val("");
                //alert($("#hdnDeleteID").val());
                $("#hdnDeleteID").val(ConfigID);
                // alert($("#hdnDeleteID").val());
                document.getElementById("btnDelete").click();
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
                            <h3 class="m-portlet__head-text">My Checklist		
                            </h3>
                        </div>
                    </div>

                    <div class="col-xl-4 order-1 order-xl-2 m--align-right">
                        <a href="<%= Page.ResolveClientUrl("~/CheckList/CheckList_Configuration.aspx") %>" style="margin-top: 5%;" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                            <span>
                                <i class="la la-plus"></i>
                                <span>New Checklist</span>
                            </span>
                        </a>
                        <div class="m-separator m-separator--dashed d-xl-none"></div>
                    </div>

                </div>
                <div class="m-portlet__body">
                    <!--begin: Search Form -->
                    <asp:HiddenField ID="hdnDeleteID" runat="server" ClientIDMode="Static" />
                    <asp:Button ID="btnDelete" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" ClientIDMode="Static"
                        Style="display: none;" OnClick="btnDelete_Click" Text="Search" />
                    <!--end: Search Form -->

                    <!--begin: Datatable -->
                    <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1" width="100%">
                        <thead>
                            <tr>
                                <%--<th title="Field #1" data-field="SrNo">Sr. No</th>--%>
                                <%--<th title="Config ID" data-field="Chk_Config_ID">Checklist Config ID</th>--%>
                                <th>Checklist Title</th>
                                
                                <%--<th>Is Enable Score</th>--%>
                                <th>Total Score</th>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                <th>Created By</th>
                                <th>Created Date</th>
                                <th>Updated By</th>
                                <th>Updated Date</th>
                                <th>Action</th>

                            </tr>
                        </thead>
                        <tbody>
                            <%=fetchChkRequestListing()%>
                        </tbody>
                    </table>

                    <!--end: Datatable -->

                </div>
            </div>

            <!-- END EXAMPLE TABLE PORTLET-->
        </div>
    </div>


    <%--</form>--%>
</asp:Content>

