<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="UserGrp_Mst.aspx.cs" Inherits="Upkeep_v3.General_Masters.UserGrp_Mst" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div runat="server" id="frmMain">

        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <div class="m-content">
                <div class="m-portlet m-portlet--mobile">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">User Group Master		
                                </h3>
                            </div>
                        </div>
                        <div class="m-portlet__head-tools">
                            <%-- <ul class="m-portlet__nav">
                            <li class="m-portlet__nav-item">
                                <a href="Add_Company.aspx" class="btn btn-info m-btn m-btn--custom m-btn--icon m-btn--air">
                                    <span>
                                        <i class="la la-plus"></i>
                                        <span>New User Type</span>
                                    </span>
                                </a>
                            </li>
                        </ul>--%>

                            <asp:Button ID="btnAddUserGroup" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnAddUserGroup_Click" Text="+ New User Group" />

                        </div>
                    </div>

                

                    <div class="m-portlet__body">

                        <!--begin: Datatable -->
                        <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">

                            <%-- <div class="row"><div class="col-sm-12 col-md-6"><div class="dataTables_length" id="m_table_1_length">
                            <label>Show <select name="m_table_1_length" aria-controls="m_table_1" class="custom-select custom-select-sm form-control form-control-sm">
                                <option value="10">10</option><option value="25">25</option><option value="50">50</option>
                                <option value="100">100</option></select> entries</label></div></div><div class="col-sm-12 col-md-6">
                                    <div id="m_table_1_filter" class="dataTables_filter"><label>Search:<input type="search" class="form-control form-control-sm" placeholder="" aria-controls="m_table_1"/></label></div></div></div>
                            --%>

                            <thead>
                                <tr>

                                    <th>User Group Description</th>
                                    <th>User Name</th>
                                    <th>Action</th>
                                </tr>

                            </thead>
                            <%-- <tbody>
                            <tr>
                                <td>compel</td>
                                <td>hjsdhfsj</td>
                            </tr>
                        </tbody>--%>
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
