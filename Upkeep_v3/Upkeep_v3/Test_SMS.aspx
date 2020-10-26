<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Test_SMS.aspx.cs" Inherits="Upkeep_v3.Test_SMS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:button runat="server" text="Send Test SMS" OnClick="OnClick_Send_SMS" />
</asp:Content>
