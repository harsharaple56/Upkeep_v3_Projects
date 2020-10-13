<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Upkeep_v3.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<script type="text/javascript">
        function myFunction() {
            alert('ds');
            document.getElementById("ContentPlaceHolder1_iframe1").src = "https://compelapps.in/eFacilito_UAT/Login.aspx";

        }


    </script>--%>


    <iframe  runat="server" scrolling="yes" src="https://www.doc.govt.nz/parks-and-recreation/places-to-go/auckland/places/maungauika-north-head-historic-reserve/tracks/maungauika-north-head-historic-walk?docCode=152922bd-f31e-4945-b836-266c42afc68f&docPwd=f1e6d7a2-6d14-45ae-89ca-5a3af6befde0&postbackURL=close&addToCartButton=Finished%20Editing&cancelButton=Cancel%20Order&a" style="width: 840px; height: 633px"></iframe>

    <%--<iframe id="iframe1" scrolling="yes" runat="server" width="900px" height="600px" src="https://compelapps.in/eFacilito_UAT/Login.aspx"></iframe>--%>
    <%--<input type="submit" value="Customize" onclick="javascript: myFunction(); return false;" />--%>

</asp:Content>
