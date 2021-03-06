<%@ Page Title="" Language="C#" MasterPageFile="~/BlankMaster.Master" AutoEventWireup="true" CodeBehind="Visitor_ID_v2.aspx.cs" Inherits="Upkeep_v3.VMS.Visitor_ID_v2" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <div class="">

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
                            <rsweb:ReportViewer ID="rv_Visitor_ID" AsyncRendering="false" Visible="false" ZoomMode="FullPage" runat="server" Width="100%" ShowBackButton="True" ShowPrintButton="true" ProcessingMode="Remote" ShowPromptAreaButton="False">
                            </rsweb:ReportViewer>
                        </div>

                        <div class="m-portlet__body">

                            <div class="m-stack m-stack--ver m-stack--tablet m-stack--demo m--align-center">
                                <div class="m-stack__item m-stack__item--center m-stack__item--top">
                                    <asp:Image ID="Img_CompanyLogo" runat="server" Style="width: auto; max-height: 100px; max-width: 100%;" />

                                </div>
                                <div class="m-stack m-stack--ver m-stack--general m-stack--demo">
                                    <div class="m-stack__item m-stack__item--right">
                                        <asp:Image ID="Img_Visitor_Photo" runat="server" Style="width: auto; max-height: 100px; max-width: 100%;" />
                                    </div>
                                    <div class="m-stack__item m-stack__item--left">
                                        <asp:Image ID="Img_QR_Code" runat="server" Style="width: auto; max-height: 100px; max-width: 100%;" />

                                    </div>
                                </div>
                                <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                                    <div class="font-weight-bold">
                                        Name :
                                        <label id="lbl_Visitor_Name" runat="server"></label>
                                    </div>


                                </div>
                                <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                                    <div class="font-weight-bold">
                                        Email :
                                        <label id="lbl_Visitor_Email" runat="server"></label>
                                    </div>


                                </div>
                                <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                                    <div class="font-weight-bold">
                                        Contact :
                                        <label id="lbl_Visitor_Contact" runat="server"></label>
                                    </div>


                                </div>
                                <div class="m-stack__item m-stack__item--center m-stack__item--middle">

                                    <div class="font-weight-bold">
                                        Visit Request ID :
                                        <label id="lbl_VisitRequest_ID" runat="server"></label>
                                    </div>


                                </div>
                                <div class="m-stack__item m-stack__item--center m-stack__item--middle" style="background: yellow;">

                                    <div class="font-weight-bold">Vaccination Details</div>

                                </div>
                                <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                                    <div class="font-weight-bold">
                                        Vaccination Status : <span class="m-badge m-badge--success m-badge--wide m-badge--rounded">VACCINATED</span>
                                    </div>
                                </div>
                                <div class="m-stack__item m-stack__item--center m-stack__item--bottom">
                                    <div class="font-weight-bold">
                                        Date of Vaccination : 
                                         <label id="lbl_Vacc_Date" runat="server"></label>
                                    </div>


                                </div>
                                <div class="m-stack__item m-stack__item--center m-stack__item--bottom">
                                    <div class="col-form-label">
                                        Visit Request Created on
                                        <label id="lbl_Request_Date_Text" runat="server"></label>
                                    </div>


                                </div>
                                <div class="m-stack__item m-stack__item--center m-stack__item--bottom">
                                    <div class="col-form-label">
                                        <label id="lbl_Visit_Date_Text" runat="server">
                                        </label>

                                    </div>


                                </div>


                            </div>

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

                <div id="div1" runat="server" class="col-lg-12 m--align-center">
                    <!--begin::Portlet-->

                </div>

            </div>

</asp:Content>
