<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="LocationTree.aspx.cs" Inherits="Upkeep_v3.General_Masters.LocationTree" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .vertical {
            border-left: 6px solid green;
            height: 50%;
            position: absolute;
            left: 50%;
            margin-left: 15%;
        }

        /* Split the screen in half */
        .split {
            height: 100%;
            width: 50%;
            position: fixed;
            z-index: 1;
            /*top: 0;*/
            overflow-x: hidden;
            padding-top: 20px;
        }

        /* Control the left side */
        .left {
            left: 0;
            margin-left: 20%;
        }

        /* Control the right side */
        .right {
            /*right: 0;*/
            right: -16%;
        }

        .treeNode {
            transition: all .3s;
            /*padding: 12px 5px;*/
            text-align: center;
            /*width: 100%;*/
            margin: 0;
            min-width: 200px !important;
            border: 1px solid #8e44ad;
            text-decoration: none !important;
            color: black;
            /*color:blue;
            font:14px Arial, Sans-Serif;*/
        }

        .rootNode {
            font-size: 15px;
            /*width:100%;*/
            /*border-bottom: Solid 1px black;*/
            color: #337ab7;
        }

        .leafNode {
            border: 1px solid #8e44ad;
            /*padding: 10px;*/
            background-color: #eeeeee;
            /*font-weight: bold;*/
            color: #337ab7;
        }

        .selectNode {
            background-color: darkgray;
            /*border: Dotted 2px black;*/
            font-weight: bold;
            color: #fff;
        }
    </style>

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="" runat="server">
            <div class="m-portlet m-portlet--mobile">
                <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                    <%--<div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Location Master		
                                </h3>
                            </div>
                        </div>
                    </div>--%>

                    <div class="m-grid__item m-grid__item--fluid m-wrapper">



                        <div class="">
                            <div class="row">
                                <div class="col-md-7">
                                    <div class="m-portlet">
                                        <div class="m-portlet__head p-3">
                                            <div class="m-portlet__head-caption">
                                                <div class="m-portlet__head-title">
                                                    <span class="m-portlet__head-icon">
                                                        <i class="flaticon-placeholder-2"></i>
                                                    </span>
                                                    <h3 class="m-portlet__head-text">Location Details
                                                    </h3>
                                                </div>
                                            </div>
                                            <a href="<%= Page.ResolveClientUrl("Location_QRCode.aspx") %>" class="btn btn-primary btn-success">
                                                <span>
                                                    <span>Generate QR Code</span>
                                                </span>
                                            </a>

                                            <%--<div class="m-portlet__head-tools">
                                        <ul class="m-portlet__nav">
                                            <li class="m-portlet__nav-item">
                                                <asp:Button ID="btnAddZone" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="+"  />                                          
                                            </li>
                                        </ul>
                                    </div>--%>
                                        </div>
                                        <div class="m-portlet__body py-1 px-2" style="overflow-x: auto; overflow-y: auto; height: 500px;">

                                            <asp:TreeView
                                                ID="TreeView1" OnTreeNodePopulate="TreeView1_TreeNodePopulate" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged"
                                                ExpandDepth="0" NodeStyle-CssClass="treeNode" RootNodeStyle-CssClass="rootNode" LeafNodeStyle-CssClass="leafNode" SelectedNodeStyle-CssClass="selectNode"
                                                ShowLines="true"
                                                runat="server" />
                                            <asp:HiddenField ID="hdnNode" runat="server" />

                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-5">
                                    <div class="m-portlet">
                                        <div class="m-portlet__head p-3">
                                            <div class="m-portlet__head-caption">
                                                <div class="m-portlet__head-title">
                                                    <span class="m-portlet__head-icon">
                                                        <i class="flaticon-placeholder-2"></i>
                                                    </span>
                                                    <h3 class="m-portlet__head-text">Location Actions
                                                    </h3>
                                                </div>
                                            </div>
                                            <%--<div class="m-portlet__head-tools">
                                        <ul class="m-portlet__nav">
                                            <li class="m-portlet__nav-item">
                                                
                                                <asp:Button ID="btnSubLocation" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="+" OnClick="btnSubLocation_Click" />
                                                <cc1:ModalPopupExtender ID="mpeSubLocation" runat="server" PopupControlID="pnlAddSubLocation" TargetControlID="btnSubLocation"
                                                    CancelControlID="btnCloseSubLoc" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>

                                            </li>
                                        </ul>
                                    </div>--%>
                                        </div>
                                        <div class="m-portlet__body py-1 px-2">

                                            <div class="row">

                                                <label class="col-lg-5 col-form-label font-weight-bold">Selected Location :</label>
                                                <asp:Label ID="lblSelectedLocation" runat="server" Text="" CssClass="col-xl-4 col-lg-4 col-form-label font-weight-bold"></asp:Label>

                                            </div>
                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <label class="col-form-label font-weight-bold">New Location :</label>
                                                </div>
                                                <div class="col-lg-7">
                                                    <asp:TextBox ID="txtNewNode" runat="server" autocomplete="off" class="form-control m-input"></asp:TextBox>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">

                                                <%--   <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Action :</label>--%>
                                                <div class="col-lg-2" style="margin-left: 30px;">
                                                    <asp:Button ID="btnAddParent" runat="server" class="btn btn-success  m-btn m-btn--icon m-btn--wide m-btn--md" Text="Add Parent Node" OnClick="btnAddParent_Click" />
                                                </div>
                                                &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                                <div class="col-lg-2">
                                                    <asp:Button ID="btnAddChild" runat="server" class="btn btn-success  m-btn m-btn--icon m-btn--wide m-btn--md" Text="Add Child Node" OnClick="btnAddChild_Click" />
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-lg-1"></div>
                                                <div class="col-lg-2">
                                                    <asp:Button ID="btnUpdate" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Style="padding: 1rem 1rem !important;" Text="Update Node" OnClick="btnUpdate_Click" />
                                                </div>
                                                &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                                <div class="col-lg-2">
                                                    <asp:Button ID="btnDelete" runat="server" class="btn btn-danger  m-btn m-btn--icon m-btn--wide m-btn--md" Style="padding: 1rem 1rem !important;" Text="Delete Node" OnClick="btnDelete_Click" />
                                                </div>
                                            </div>

                                            <br />
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" Style="font-weight: bold;"></asp:Label>
                                                    <asp:Label ID="lblSuccessMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Green" Style="font-weight: bold;"></asp:Label>

                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>


                    <%--<div class="m-portlet__body">
                        <div class="m-portlet__body" style="padding: 0.3rem 2.2rem;">
                            <div class="vertical"></div>

                            <div class="split left m-portlet__body">
                                <div class="" style="overflow-x: auto;">
                                    <asp:TreeView
                                        ID="TreeView1" OnTreeNodePopulate="TreeView1_TreeNodePopulate" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged"
                                        ExpandDepth="0" NodeStyle-CssClass="treeNode" RootNodeStyle-CssClass="rootNode" LeafNodeStyle-CssClass="leafNode" SelectedNodeStyle-CssClass="selectNode"
                                        ShowLines="true"
                                        runat="server" />
                                </div>
                                <asp:HiddenField ID="hdnNode" runat="server" />

                                <br />

                            </div>

                            <div class="split right">
                                <div class="row">
                                  
                                    <label class="col-lg-3 col-form-label font-weight-bold">Selected Location :</label>
                                    <asp:Label ID="lblSelectedLocation" runat="server" Text="" CssClass="col-xl-4 col-lg-4 col-form-label font-weight-bold"></asp:Label>
                                    
                                </div>
                                <div class="row">
                                    <div class="col-lg-3">
                                        <label class="col-form-label font-weight-bold">New Location :</label>
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox ID="txtNewNode" runat="server" autocomplete="off" Style="width: 210%; margin-left: -48%;" class="form-control m-input"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                  
                                    <label class="col-xl-2 col-lg-1 col-form-label font-weight-bold">Action :</label>
                                    <asp:Button ID="btnAddParent" runat="server" class="btn btn-success  m-btn m-btn--icon m-btn--wide m-btn--md" Style="padding: 1rem 1rem !important;" Text="Add Parent Node" OnClick="btnAddParent_Click" />
                                    &nbsp;&nbsp;
                <asp:Button ID="btnAddChild" runat="server" class="btn btn-success  m-btn m-btn--icon m-btn--wide m-btn--md" Style="padding: 1rem 1rem !important;" Text="Add Child Node" OnClick="btnAddChild_Click" />
                                    &nbsp;&nbsp;
                                        &nbsp;&nbsp;
           
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-lg-2"></div>
                                    <div class="col-lg-2">
                                        <asp:Button ID="btnUpdate" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Style="padding: 1rem 1rem !important;" Text="Update Node" OnClick="btnUpdate_Click" />
                                    </div>
                                    <div class="col-lg-2">
                                        <asp:Button ID="btnDelete" runat="server" class="btn btn-danger  m-btn m-btn--icon m-btn--wide m-btn--md" Style="padding: 1rem 1rem !important;" Text="Delete Node" OnClick="btnDelete_Click" />
                                    </div>
                                </div>

                                <br />
                                <div class="row">
                                    <div class="col-lg-12">
                                        <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" Style="font-weight: bold;"></asp:Label>

                                    </div>
                                </div>

                            </div>

                        </div>
                    </div>--%>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
