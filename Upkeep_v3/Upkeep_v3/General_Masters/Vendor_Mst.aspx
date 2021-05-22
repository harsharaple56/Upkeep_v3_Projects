<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Vendor_Mst.aspx.cs" Inherits="Upkeep_v3.General_Masters.Vendor_Mst" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>
	    Vendors List
    </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        
        <div class="">
            <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-progress">
                    </div>
                    <div class="m-portlet__head-wrapper">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Vendor Master		
                                </h3>
                            </div>
                        </div>
                        <div class="m-portlet__head-tools">
                            <ul class="m-portlet__nav" style="margin-right: 2%;">
                                <li class="m-portlet__nav-item">
                                    <a href="<%= Page.ResolveClientUrl("Add_Vendor.aspx") %>" class="btn btn-accent  m-btn m-btn--icon" style="padding: 5%;">
                                        <span>
                                            <img src="../assets/app/media/img/icons/Add_Retailer_35.png" />
                                            <span>Add Vendor</span>
                                        </span>
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="m-portlet__body">
                    <!--begin: Datatable -->
                    <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">
                        <thead>

                            <tr>
                                <th>Vendor Name</th>
                                <th>Vendor Code</th>
                                <th>Description</th>
                                <th>Contact</th>
                                <th>Email</th>
                                <th>GSTIN</th>
                                <th>Created By</th>
                                <th>Created On</th>
                                <th>Actions</th>
                            </tr>
                        </thead>   
                        <tbody>
                            <%=fetchVendorDetails()%>
                        </tbody>
                    </table>
                </div>
            </div>
            <!-- END EXAMPLE TABLE PORTLET-->
        </div>
    </div>
</asp:Content>
