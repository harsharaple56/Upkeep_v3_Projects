<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="LocationTree.aspx.cs" Inherits="Upkeep_v3.General_Masters.LocationTree" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
            text-align: center;
            margin: 0;
            min-width: 200px !important;
            border: 1px solid #8e44ad;
            text-decoration: none !important;
            color: black;
            border-color: #e2e5ee;
            font-size: 16px;
        }

        .rootNode {
            font-size: 16px;
            border-color: #e2e5ee;
            color: #337ab7;
        }

        .leafNode {
            font-size: 16px;
            border: 1px solid #8e44ad;
            border-color: #e2e5ee;
            background-color: #eeeeee;
            color: #337ab7;
        }

        .selectNode {
            background-color: darkgray;
            font-weight: bold;
            color: #fff;
        }
    </style>
    <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="" runat="server">
                <div class="m-portlet m-portlet--mobile">
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">
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

                                        <div>
                                            <a href="<%= Page.ResolveClientUrl("Location_QRCode.aspx") %>" class="btn m-btn--pill m-btn--air         btn-success">
                                                <span>
                                                    <span>Generate QR Code</span>
                                                </span>
                                            </a>

                                            <asp:LinkButton class="btn m-btn--pill btn-outline-focus m-btn--icon m-btn--air" runat="server" ID="btnImportExcelPopup">
                                                <span>
                                                    <i class="fa fa-file-import" aria-hidden="true"></i>
                                                    <span>Import Data</span>
                                                </span>
                                            </asp:LinkButton>

                                            <cc1:ModalPopupExtender ID="mpeUserMst" runat="server" PopupControlID="pnlImportExport" TargetControlID="btnImportExcelPopup"
                                                CancelControlID="btnCloseHeader" BackgroundCssClass="modalBackground">
                                            </cc1:ModalPopupExtender>
                                        </div>

                                    </div>
                                    <div class="m-portlet__body" style="overflow-x: auto; overflow-y: auto; height: 500px;">

                                        <asp:TreeView ID="TreeView1" OnTreeNodePopulate="TreeView1_TreeNodePopulate" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged"
                                            ExpandDepth="0" ShowLines="true" runat="server" SelectedNodeStyle-CssClass="selectNode"
                                            NodeStyle-CssClass="treeNode" RootNodeStyle-CssClass="rootNode" LeafNodeStyle-CssClass="leafNode" />
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
                                                <asp:RequiredFieldValidator ID="rfvLoc" runat="server" ControlToValidate="txtNewNode" Display="Dynamic"
                                                    ForeColor="Red" ErrorMessage="Please enter Location" ValidationGroup="ValidateLocation"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="m-separator m-separator--dashed"></div>
                                        <div class="m-demo__preview m-demo__preview--btn">

                                            <asp:Button ID="btnAddParent" runat="server" ValidationGroup="ValidateLocation"
                                                class="btn btn-primary btn-sm m-btn m-btn--custom" Text="Add Parent Node" OnClick="btnAddParent_Click" />
                                            <asp:Button ID="btnAddChild" runat="server" ValidationGroup="ValidateLocation"
                                                class="btn btn-brand btn-sm m-btn m-btn--custom" Text="Add Child Node" OnClick="btnAddChild_Click" />
                                            <asp:Button ID="btnUpdate" runat="server" ValidationGroup="ValidateLocation"
                                                class="btn btn-accent btn-sm m-btn m-btn--custom" Text="Update Node" OnClick="btnUpdate_Click" />
                                            <asp:Button ID="btDelete" runat="server"
                                                class="btn btn-danger btn-sm m-btn m-btn--custom" Text="Delete Node" OnClick="btnDelete_Click" />

                                        </div>


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


                        <asp:Panel ID="pnlImportExport" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
                            <div class="" id="add_sub_location" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document" style="max-width: 700px;">
                                    <div class="modal-content">

                                        <div class="modal-header">
                                            <h5 class="modal-title" id="exampleModalLabel">Import Data</h5>
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader">
                                                <span aria-hidden="true">&times;</span>
                                            </button>
                                        </div>
                                        <div class="modal-body">

                                            <div class="form-group m-form__group row">
                                                <label for="message-text" class="col-xl-2 col-lg-2 form-control-label">Import :</label>
                                                <div class="col-xl-8 col-lg-4 custom-file">
                                                    <asp:FileUpload ID="FU_ChecklistMst" CssClass="custom-file-input" runat="server" />
                                                    <label class="custom-file-label" for="FU_ChecklistMst">Choose file</label>

                                                </div>
                                                <div class="col-xl-6 col-lg-6">
                                                    <asp:RequiredFieldValidator ID="rfvImport" runat="server" ControlToValidate="FU_ChecklistMst" ErrorMessage="Please upload a file" ForeColor="Red"
                                                        Display="Dynamic" ValidationGroup="ValidationImport"></asp:RequiredFieldValidator>
                                                    <span id="ImportError_Msg" style="color: red;"></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group m-form__group row">
                                            <div class="col-xl-2 col-lg-2 col-form-label"></div>
                                            <img src="../assets/app/media/img/icons/download_sample_26.png" />
                                            <asp:LinkButton ID="btnDownloadSampleFile" runat="server" OnClick="lnkSampleFile_Click" Text="Download Sample Import File" ClientIDMode="Static"></asp:LinkButton>
                                        </div>
                                        <div class="form-group m-form__group row">
                                            <asp:Label ID="lblImportErrorMsg" Text="" runat="server" CssClass="col-xl-10 col-lg-10 col-form-label" ForeColor="Red"></asp:Label>
                                        </div>

                                        <div class="form-group m-form__group row" style="justify-content: center;">
                                            <div class="col-xl-11 col-lg-11" style="overflow-y: auto; height: 210px; display: none;" id="dvErrorGrid" runat="server">
                                                <asp:GridView ID="gvImportError" runat="server" AutoGenerateColumns="true" HeaderStyle-BackColor="#f4f3f8" HeaderStyle-ForeColor="Black"
                                                    CssClass="table table-striped- table-bordered table-hover table-checkable">
                                                </asp:GridView>
                                            </div>
                                        </div>

                                        <div class="modal-footer">
                                            <asp:Button ID="btnImportExcel" Text="Import" runat="server" OnClick="btnImportExcel_Click" ValidationGroup="ValidationImport" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" />
                                            <asp:Button ID="btnCloseImportPopUp" Text="Close" OnClick="btnCloseImportPopUp_Click" runat="server" class="btn btn-danger  m-btn m-btn--icon m-btn--wide m-btn--md" />
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </asp:Panel>

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
    </div>
</asp:Content>
