<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="View_Request_List.aspx.cs" Inherits="Upkeep_v3_Control_Center.Support_Portal.View_Request_List" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    

        <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript" ></script>
 
    <%-- <script src="<%= Page.ResolveClientUrl("~/assets/demo/default/custom/crud/datatables/extensions/buttons.js") %>" type="text/javascript"></script>--%>

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


    <script type="text/javascript">
        $(document).ready(function () {
            $('#m_table_1').DataTable({
                responsive: true,
                pagingType: 'full_numbers',
                scrollX: true,
                'fnDrawCallback': function () {
                    init_plugins();
                }
            });
        });

    </script>

     <form method="post" runat="server" id="frmMain" style="width: 100%;">

        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <div class="">
                <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Support Tickets
                                </h3>
                            </div>
                        </div>
                        <div class="m-portlet__head-tools">
                            <ul class="m-portlet__nav" style="margin-right: 2%;">
                                <li class="m-portlet__nav-item">
                                    <a href="<%= Page.ResolveClientUrl("~/Support_Portal/Create_Request.aspx") %>" class="btn m-btn--pill btn-danger m-btn m-btn--custom " style="border: 7px solid transparent;">
                                        <i class="fa fa-user-tag" style="font-size: 2.3rem;"></i>
                                        Raise NEW Support Ticket
                                    </a>
                                </li>
                                <%-- <asp:ImageButton ID="imgBtnExcel" runat="server" ImageUrl="../assets/app/media/img/icons/excel_32.png" ToolTip="Import Export Wizard" />--%>
                            </ul>
                        </div>
                    </div>
                    <div class="m-portlet__body">

                        <div id="" style="overflow-x: auto;">
                            <!--begin: Datatable -->
                            <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">
                                <thead>
                                    <tr>
                                        <th>Request ID</th>
                                        <th>Company Name</th>
                                        <th>Raised By</th>
                                        <th>Request Type</th>
                                        <th>Module</th>
                                        <th>Status</th>
                                        <th>Created on</th>
                                        <th>Action</th>
                                    </tr>
                                </thead>

                                <tbody>
                                    <%=fetch_Request_List()%>
                                </tbody>


                            </table>
                        </div>
                    </div>
                </div>

                <!-- END EXAMPLE TABLE PORTLET-->
            </div>
        </div>
    </form>



</asp:Content>
