<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Schedule_Checklist_Listing.aspx.cs" Inherits="Upkeep_v3.CheckList.Schedule_Checklist_Listing" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript" ></script>
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
            $(document).ready(function(){
                $('#m_table_1').DataTable({
                    responsive: true,
                    pagingType: 'full_numbers',
                    'fnDrawCallback': function(){
                        init_plugins();
                    }
                });
            });
        </script>

    <div runat="server" id="frmMain4">
        <cc1:ToolkitScriptManager runat="server"> </cc1:ToolkitScriptManager>

        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <div class="m-content">
                <div class="m-portlet m-portlet--mobile">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Schedule Checklist		
                                </h3>
                            </div>
                        </div>
                        <div class="m-portlet__head-tools">
                           <ul class="m-portlet__nav">
                                <li class="m-portlet__nav-item">

                                       <a href="<%= Page.ResolveClientUrl("Schedule_Checklist.aspx") %>" class="btn btn-accent  m-btn m-btn--icon" style="padding: 5%;">
                                 
                                 <!--   <a href="~/Checklist/Schedule_Checklist.aspx" class="btn btn-info m-btn m-btn--custom m-btn--icon m-btn--air" data-toggle="modal">-->
                                        <span>
                                            <i class="la la-plus"></i>
                                            <span>New Schedule</span>
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
                                    <th>Checklist Name</th>
                                    <th>Department</th>
                                    <th>Locations</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%=bindScheduleChecklist()%>
                            </tbody>
                        </table>
                    </div>
                </div>

                <!-- END EXAMPLE TABLE PORTLET-->
            </div>
        </div>

    </div>

</asp:Content>
