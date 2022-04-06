<%@ Page Language="C#" MasterPageFile="~/BlankMaster.Master" AutoEventWireup="true" CodeBehind="FLR3_Pre_Printed.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Reports_Excise.Maharashtra.FLR3_Pre_Printed" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   
    <script>
        $(document).ready(function () {
            $('.datetimepicker').datepicker({
                todayHighlight: true,
                orientation: 'auto bottom',
                autoclose: true,
                pickerPosition: 'bottom-right',
                format: 'dd-MM-yyyy',
                showMeridian: true
            });
        });
    </script>

    <div class="m-grid__item m-grid__item--fluid">
        <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">
            <div class="m-portlet__head">
                <div class="m-portlet__head-caption">
                    <div class="m-portlet__head-title">
                        <h3 class="m-portlet__head-text">FLR-III(3) Pre-Printed Excise Report		
                        </h3>
                    </div>
                </div>
                <div class="m-portlet__head-tools">
                    <ul class="m-portlet__nav">
                        <li class="m-portlet__nav-item">
                            <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Reports_Excise/Generate_Reports.aspx") %>" class="btn btn-metal m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m--margin-right-10">
                                <span>
                                    <i class="la la-arrow-left"></i>
                                    <span>Back</span>
                                </span>
                            </a>
                        </li>
                    </ul>
                </div>


            </div>
            <div class="m-portlet__body">
                <!--begin: Search Form -->

               <div class="form-group row">
                    <label class="col-md-1 col-form-label font-weight-bold" style="margin-top: 10px;">License  :</label>
                    <div class="col-md-3 col-form-label">
                        <asp:DropDownList AutoPostBack="false" ID="ddlLicense" runat="server" CssClass="form-control m-input m-input--air" ClientIDMode="Static"></asp:DropDownList>
                    </div>

                    <label class="col-md-2 col-form-label font-weight-bold" style="margin-top: 10px;">Filter Date Range  :</label>
                    <div class="col-md-3 col-form-label">
                        <div class="m-form__control">
                            <div class="input-group date">
                                <asp:TextBox autocomplete="off" runat="server" type="text" class="form-control m-input datetimepicker" ID="txtDate">
                                </asp:TextBox>
                                <div class="input-group-append">
                                    <span class="input-group-text">
                                        <i class="la la-calendar" style="font-size: 2rem;"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>

                    <label class="col-md-1 col-form-label font-weight-bold" style="padding-right: 0px;"></label>
                    <div class="col-md-2 col-form-label">
                        <div class="btn-group">
                            <a id="generate" class="btn btn-danger m-btn m-btn--icon m-btn--pill m-btn--air" runat="server" onserverclick="generate_ServerClick">
                                <span>
                                    <i class="fa fa-angle-double-right"></i>
                                    <span>Generate</span>
                                    <i class="fab fa-whmcs"></i>
                                </span>
                            </a>
                        </div>
                    </div>
                </div>


                <div class="progress m-progress--sm">
                    <div class="progress-bar bg-primary" role="progressbar" style="width: 100%" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100"></div>
                </div>


                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <div class="row m--margin-bottom-20 m--align-center">
                            <div class="col-lg-12 m--margin-bottom-10-tablet-and-mobile">

                                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Width="1400px">
                                </rsweb:ReportViewer>

                            </div>
                        </div>

                    </ContentTemplate>

                </asp:UpdatePanel>


            </div>
        </div>


    </div>
</asp:Content>



