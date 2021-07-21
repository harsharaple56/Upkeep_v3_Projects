<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Checklist_Consolidated_Report.aspx.cs" Inherits="Upkeep_v3.CheckList.Checklist_Consolidated_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <%--<form class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmWorkPermit" method="post">--%>
                        <%--<cc1:toolkitscriptmanager runat="server"></cc1:toolkitscriptmanager>--%>

                        <asp:HiddenField ID="hdnWpHeaderData" runat="server" ClientIDMode="Static" />
                        <asp:HiddenField ID="hdnWpHeader" runat="server" ClientIDMode="Static" />

                        <div class="m-portlet__head">
                            <div class="m-portlet__head-progress">
                            </div>
                            <div class="m-portlet__head-wrapper">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">Checklist Consolidated Report </h3>
                                    </div>
                                </div>

                                <div class="m-portlet__head-tools">
                                    <%--<asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>--%>
                                    <a href="<%= Page.ResolveClientUrl("~/Checklist/CheckList_Report_Listing.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                        <span>
                                            <i class="la la-arrow-left"></i>
                                            <span>Back</span>
                                        </span>
                                    </a>
                                    <%-- <a href="<%= Page.ResolveClientUrl(Session["PreviousURL"].ToString()) %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                        <span>
                                            <i class="la la-arrow-left"></i>
                                            <span>Back</span>
                                        </span>
                                    </a>--%>
                                    <div class="btn-group">
                                        <asp:Button ID="btnExportExcel" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="Export to Excel" OnClick="btnExportExcel_Click" />

                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="m-portlet__body" style="padding: 0.4rem 2.2rem;">

                            <div class="m-portlet__body" style="padding: 0.3rem 2.2rem;">
                                <div class="form-group row" style="background-color: #00c5dc;">
                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Checklist Details </label>
                                </div>

                                <div class="row" style="padding-left: 2%;">

                                    <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Checklist Name :</label>
                                    <div class="col-xl-5 col-lg-5 col-form-label">
                                        <asp:Label ID="lblChecklistName" runat="server" Text="" class="form-control-label"></asp:Label>
                                    </div>

                                    <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Department :</label>
                                    <div class="col-xl-3 col-lg-3 col-form-label">
                                        <asp:Label ID="lblDepartment" runat="server" Text="" class="form-control-label"></asp:Label>
                                    </div>
                                </div>

                                <div class="row" style="padding-left: 2%;">

                                    <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Checklist Description :</label>
                                    <div class="col-xl-5 col-lg-5 col-form-label">
                                        <asp:Label ID="lblChecklistDesc" runat="server" Text="" class="form-control-label"></asp:Label>
                                    </div>
                                    <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Generated Date :</label>
                                    <div class="col-xl-3 col-lg-3 col-form-label">
                                        <asp:Label ID="lblGeneratedDate" runat="server" Text="" class="form-control-label"></asp:Label>
                                    </div>
                                </div>

                                <div class="row" style="padding-left: 2%;">

                                    <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Generated By :</label>
                                    <div class="col-xl-5 col-lg-5 col-form-label">
                                        <asp:Label ID="lblGeneratedBy" runat="server" Text="" class="form-control-label"></asp:Label>
                                    </div>
                                </div>
                                <br />
                                 <div class="form-group row" style="background-color: #00c5dc;">
                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Checklist Points Details </label>
                                </div>
                                <br />

                                <div style="overflow-x:scroll;" >
                                    <asp:GridView class="table table-striped- table-bordered table-hover table-checkable dataTable no-footer dtr-inline collapsed" ID="gvChecklistReport" runat="server" AutoGenerateColumns="true" ></asp:GridView>
                                </div>



                            </div>


                        </div>



                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
