<%@ Page Title="" Language="C#" MasterPageFile="~/BlankMaster.Master" AutoEventWireup="true" CodeBehind="Visitor_ID.aspx.cs" Inherits="Upkeep_v3.VMS.Visitor_ID" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-12">

            <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">
                <div class="row m--margin-bottom-20 m--align-center">

<%--                    <rsweb:reportviewer id="ReportViewer2" runat="server" width="100%" showbackbutton="True" processingmode="Remote" showpromptareabutton="False">
                     </rsweb:reportviewer>--%>
                </div>
            </div>


        </div>
    </div>


</asp:Content>
