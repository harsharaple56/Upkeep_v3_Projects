<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="CheckList_Report_Details.aspx.cs" Inherits="Upkeep_v3.CheckList.CheckList_Report_Details" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="">
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
                                        <h3 class="m-portlet__head-text">Checklist Report </h3>
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
                                        <asp:Button ID="btnExportPDF" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="Export to PDF" OnClick="btnExportPDF_Click" />
                                       
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="m-portlet__body" style="padding: 0.4rem 2.2rem;">

                            <div class="m-portlet__body border-bottom " style="padding: 0.3rem 2.2rem;">
                                <div class="form-group row" style="background-color: #00c5dc;">
                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Checklist Details </label>
                                </div>
                                <div id="Div1" runat="server" style="display: block;">
                                    <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">

                                        <div class="col-md-4" style="padding-left: 1%; margin-bottom: 0;">
                                            <div class="form-group">
                                                <label class="col-form-label font-weight-bold">Checklist ID : </label>
                                                <div class="form-control" style="word-wrap: break-word; height: auto;">
                                                    <asp:Label ID="lblChecklisID" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-form-label font-weight-bold">Checklist Name : </label>
                                                <br />
                                                <div class="form-control" style="word-wrap: break-word; height: auto;">
                                                    <asp:Label ID="lblChecklistName" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label class="col-form-label font-weight-bold">Checklist Description : </label>
                                                <br />
                                                <div class="form-control" style="word-wrap: break-word; height: auto;">
                                                    <asp:Label ID="lblChecklistDesc" runat="server" Text="" CssClass="text-justify"></asp:Label>

                                                </div>
                                            </div>
                                        </div>

                                        <%--    <div class="col-md-1" style="padding-left: 1%; margin-bottom: 0;">
                                            <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                <div class="vl" style="border-left: 1px solid lightblue; height: 325px;"></div>
                                            </div>
                                        </div>--%>

                                        <div class="col-md-8 border-left" style="padding-left: 1%; margin-bottom: 0;">
                                            <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">

                                                <div class="col-md-6" style="padding-left: 1%; margin-bottom: 0;">

                                                    <div class="form-group">
                                                        <label class="col-form-label font-weight-bold">Department : </label>
                                                        <br />
                                                        <div class="form-control" style="word-wrap: break-word; height: auto;">
                                                            <asp:Label ID="lblDepartment" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="col-form-label font-weight-bold">Start Time : </label>
                                                        <br />
                                                        <div class="form-control" style="word-wrap: break-word; height: auto;">
                                                            <asp:Label ID="lblstartTime" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="col-form-label font-weight-bold">Generated By : </label>
                                                        <br />
                                                        <div class="form-control" style="word-wrap: break-word; height: auto;">
                                                            <asp:Label ID="lblGeneratedBy" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="col-form-label font-weight-bold">Status : </label>
                                                        <br />
                                                        <div class="form-control" style="word-wrap: break-word; height: auto;">
                                                            <asp:Label ID="lblStatus" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                                        </div>
                                                    </div>

                                                </div>

                                                <div class="col-md-6" style="padding-left: 1%; margin-bottom: 0;">

                                                    <div class="form-group">
                                                        <label class="col-form-label font-weight-bold">Location : </label>
                                                        <br />
                                                        <div class="form-control" style="word-wrap: break-word; height: auto;">
                                                            <asp:Label ID="lblLocation" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <label class="col-form-label font-weight-bold">End Time : </label>
                                                        <br />
                                                        <div class="form-control" style="word-wrap: break-word; height: auto;">
                                                            <asp:Label ID="lblEndTime" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <label class="col-form-label font-weight-bold">Total Score : </label>
                                                        <br />
                                                        <div class="form-control" style="word-wrap: break-word; height: auto;">
                                                            <asp:Label ID="lblTotalScore" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <label class="col-form-label font-weight-bold">Progress : </label>
                                                        <br />
                                                        <div class="form-control" style="word-wrap: break-word; height: auto;">
                                                            <asp:Label ID="lblProgress" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>

                            <asp:Repeater ID="rptSectionDetails" runat="server" OnItemDataBound="rptSectionDetails_ItemDataBound">
                                <ItemTemplate>

                                    <div class="m-portlet__body border-bottom " style="padding: 0.3rem 2.2rem;">

                                        <div class="form-group row" style="background-color: #00c5dc;">
                                            <%--SECTION NAME --%>
                                            <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;" id="lblSectionName"><%#Eval("Chk_Section_Desc")%></label>
                                            <asp:HiddenField ID="hdnSectionID" runat="server" Value='<%# Eval("Chk_Section_ID") %>' />
                                        </div>

                                        <%--QUESTION GRID --%>
                                        <div id="Div3" runat="server" style="display: block;">
                                            <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                                <%--TABLE--%>

                                                <table class="table table-light table-bordered">
                                                    <thead>
                                                        <tr>
                                                            <th class="text-center" style="width:35%;word-wrap: break-word; height: auto;" >Question</th>
                                                            <th class="text-center" style="width:15%;word-wrap: break-word; height: auto;" >Flag</th>
                                                            <th class="text-center" style="width:50%;word-wrap: break-word; height: auto;" >Response</th>
                                                        </tr>
                                                    </thead>
                                                    <tr>
                                                        <td colspan="3">

                                                            <asp:Repeater ID="grdTable" runat="server">
                                                                <ItemTemplate>
                                                                    <table class="table table-bordered">
                                                                <%-- <tr>
                                                                <th>Question</th>
                                                                <th>Flag</th>
                                                                <th>Response</th>
                                                                 </tr>--%>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td style="width:35%;word-wrap: break-word; height: auto;"><%#Eval("Qn_Desc")%></td>
                                                                                <td style="width:15%;word-wrap: break-word; height: auto;"><%#Eval("Flag")%></td>
                                                                                <td style="width:50%;word-wrap: break-word; height: auto;"><%#Eval("Chk_Ans_Value_Data")%></td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:Repeater>

                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>

                                    </div>

                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                        <div aria-hidden="true" aria-labelledby="exampleModalLabel" class="modal fade" id="exampleModal" role="dialog" tabindex="-1">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="exampleModalLabel">Uploaded Image</h5>
                                        <button aria-label="Close" class="close" data-dismiss="modal" type="button">
                                            <span aria-hidden="true">×</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <div class="carousel slide" data-ride="carousel" id="carouselExampleControls">
                                            <div class="carousel-inner">
                                            </div>
                                            <a class="carousel-control-prev" data-slide="prev" href="#carouselExampleControls" role="button">
                                                <span aria-hidden="true" class="carousel-control-prev-icon"></span>
                                                <span class="sr-only">Previous</span>
                                            </a>
                                            <a class="carousel-control-next" data-slide="next" href="#carouselExampleControls" role="button">
                                                <span aria-hidden="true" class="carousel-control-next-icon"></span>
                                                <span class="sr-only">Next </span>
                                            </a>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

      <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" BorderWidth="0px" Visible="false" ShowFindControls="False" Height="100%" ShowBackButton="True"
                        ProcessingMode="Remote" ShowPromptAreaButton="False">
        </rsweb:ReportViewer>

</asp:Content>
