<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Useful Snippets.aspx.cs" Inherits="Upkeep_v3.Developer_Code_Snippets.Useful_Snippets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--Tooltip Code for Information--%>

    <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="Tooltip Data">
        <i class="fa fa-info-circle"></i>
    </a>

    <%-- Code to Section a Form --%>

    <div class="m-form__heading" style="text-align: center; padding-top: 10px; padding-bottom: 10px;">
        <h3 class="m-form__heading-title" style="line-height: 2.0; background: aliceblue; font-size: 1.2rem;">Asset Details</h3>
    </div>

    <%--Pill style Button--%>

    <a href="#" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
        <span>
            <i class="fa fa-archive"></i>
            <span>Primary</span>
        </span>
    </a>

    <a href="<%= Page.ResolveClientUrl("~/VMS/VMSConfig_Listing.aspx") %>" class="btn btn-metal m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m--margin-right-10">
        <span>
            <i class="la la-arrow-left"></i>
            <span>Back</span>
        </span>
    </a>

</asp:Content>
