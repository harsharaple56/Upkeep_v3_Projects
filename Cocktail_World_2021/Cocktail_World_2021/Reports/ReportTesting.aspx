<%@ Page Title="" Language="C#" MasterPageFile="~/CW_MasterPage.Master" AutoEventWireup="true" CodeBehind="ReportTesting.aspx.cs" Inherits="Cocktail_World_2021.Reports.ReportTesting" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" 
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div>

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server"  Width="100%" Height="950px" ForeColor="#999999" ToolBarItemBorderColor="#999999">

<%--                 <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Width="100%"
            Font-Size="6pt" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Times New Roman"
            WaitMessageFont-Size="Smaller" Height="100%">--%>


            </rsweb:ReportViewer>
            
            
            <%--<rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="950px"></rsweb:ReportViewer>--%>
        </div>


</asp:Content>
