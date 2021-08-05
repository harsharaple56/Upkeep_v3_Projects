<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FLR3_Report1.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Reports_Excise.Maharashtra.FLR3_Report1" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>  

        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" ShowBackButton="True" ProcessingMode="Remote" ShowPromptAreaButton="False">
         </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
