<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="FLR3_Report.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Reports_Excise.Maharashtra.FLR3_Report" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>  

        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" ShowBackButton="True" ProcessingMode="Remote" ShowPromptAreaButton="False">
         </rsweb:ReportViewer>

</asp:Content>
