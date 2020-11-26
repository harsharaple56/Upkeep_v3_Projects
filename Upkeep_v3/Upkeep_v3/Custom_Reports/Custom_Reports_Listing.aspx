<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Custom_Reports_Listing.aspx.cs" Inherits="Upkeep_v3.Custom_Reports.Custom_Reports_Listing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="m-portlet m-portlet--mobile">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <h3 class="m-portlet__head-text">Custom Reports List	
                            </h3>
                        </div>
                    </div>
                    <div class="m-portlet__head-tools">
                        <ul class="m-portlet__nav">
                            <li class="m-portlet__nav-item">
                                	<%--<button type="button" class="btn btn-warning" data-toggle="modal" data-target="#m_modal_4">Launch Modal</button>
									--%>	
                                <a href="https://efacilito.com/contact/" class="btn btn-info m-btn m-btn--custom m-btn--icon m-btn--air">
                                    <span>
                                        <i class="flaticon-statistics"></i>
                                        <span>Build New Report</span>
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
                                
                                <th>Report Name</th>
                                <th>Report Description</th>
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

</asp:Content>
