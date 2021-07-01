<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="Upkeep_v3.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
        <asp:TextBox ID="txtMsg" class="form-control m-input m-login__form-input--last" AutoComplete="off" type="text" placeholder="Message" name="txtMsg" runat="server" Style="height: 50px;"></asp:TextBox>
        <asp:TextBox ID="txtNumber" class="form-control m-input m-login__form-input--last" AutoComplete="off" type="text" placeholder="Number" name="txtNumber" runat="server" Style="height: 50px;"></asp:TextBox>
        <asp:Button ID="btnWhatsapp" runat="server" class="btn btn-focus m-btn m-btn--pill m-btn--custom m-btn--air"
            OnClick="btnWhatsapp_Click" Text="Whatsapp" CssClass="hidden"></asp:Button>
    </form>
</body>
</html>
