<%@ Page Title="" Language="C#" MasterPageFile="~/BlankMaster.Master" AutoEventWireup="true" CodeBehind="Visitor_ID_v2.aspx.cs" Inherits="Upkeep_v3.VMS.Visitor_ID_v2" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="m-grid__item m-grid__item--fluid">
        <div class="m-content">

            <div class="row">

                <div id="div_Visitor_ID" runat="server" class="col-lg-12">
                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">
                        <div class="m-portlet__head">

                            <div class="m-portlet__head-tools" style="padding-top: 0.5rem; padding-bottom: 0.5rem;">
                                
                                <ul class="m-portlet__nav">
                                    <li class="m-portlet__nav-item m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover" aria-expanded="true">

                                        <a href="#" runat="server" onserverclick="Download_Visitor_ID" class="btn m-btn--pill btn-outline-focus m-btn--icon m-btn--air">
                                            <span>
                                                <i class="fa fa-download"></i>
                                                <span>Download</span>
                                            </span>
                                            
                                        </a>
                                    </li>
                                </ul>

                            </div>
                            
                        </div>
                        <div class="m-portlet__body">
                            <rsweb:ReportViewer ID="rv_Visitor_ID" AsyncRendering="false" ZoomMode="FullPage" runat="server" Width="100%" ShowBackButton="True" ShowPrintButton="true" ProcessingMode="Remote" ShowPromptAreaButton="False">
                            </rsweb:ReportViewer>
                        </div>


                    </div>
                </div>

                <div id="div_No_Visitor_ID" runat="server" class="col-lg-12">
                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">
                        
                        <div class="m-portlet__body">

                            NO ID Card found
                        </div>


                    </div>
                </div>


            </div>
        </div>
    </div>





</asp:Content>
