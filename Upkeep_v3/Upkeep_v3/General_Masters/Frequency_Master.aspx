<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Frequency_Master.aspx.cs" Inherits="Upkeep_v3.General_Masters.Frequency_Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript" ></script>
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
     <div runat="server" id="frmMain">


        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <div class="m-content">
                <div class="m-portlet m-portlet--mobile">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Frequency Master		
                                </h3>
                            </div>
                        </div>
                        <div class="m-portlet__head-tools">
                            <%--<ul class="m-portlet__nav">
                                <li class="m-portlet__nav-item">
                                    <a href="~/General_Masters/Add_Department.aspx" class="btn btn-info m-btn m-btn--custom m-btn--icon m-btn--air" data-toggle="modal">
                                        <span>
                                            <i class="la la-plus"></i>
                                            <span>New Department</span>
                                        </span>
                                    </a>


                                </li>
                            </ul>--%>
                           
                            <asp:Button ID="btnFrequency" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnFrequency_Click" Text="+ New Frequency" />
                               
                        </div>
                    </div>
                    <div class="m-portlet__body">

                        <!--begin: Datatable -->
                        <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">


                            <thead>

                                <tr>
                                    <th>Frequency ID</th>
                                    <th>Frequency Description</th>
                                    <th>Action</th>
                                </tr>

                            </thead>
                            
                            <tbody>
                                <%=bindgrid()%>
                            </tbody>
                        </table>
                    </div>
                </div>

                <!-- END EXAMPLE TABLE PORTLET-->
            </div>
        </div>

        
    </div>

</asp:Content>
