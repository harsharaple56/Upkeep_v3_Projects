<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Location_QRCode.aspx.cs" Inherits="Upkeep_v3.General_Masters.Location_QRCode" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets/demo/custom/crud/metronic-datatable/base/html-table.js") %>" type="text/javascript"></script>

     <style type="text/css">
        .hiddencol {
            display: none;
        }
    </style>

    <style>
     th {
        /*background: cornflowerblue !important;
        color:white !important;
        position: sticky !important;*/
        top: 0;
        box-shadow: 0 2px 2px -1px rgba(0, 0, 0, 0.4);
        
    }
    th, td {
        padding: 0.25rem;
    }
</style>

    <%--<script type="text/javascript">
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                //Get the Cell To find out ColumnIndex
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        //If the header checkbox is checked
                        //check all checkboxes
                        //and highlight all rows
                        row.style.backgroundColor = "aqua";
                        inputList[i].checked = true;
                    }
                    else {
                        //If the header checkbox is checked
                        //uncheck all checkboxes
                        //and change rowcolor back to original
                        if (row.rowIndex % 2 == 0) {
                            //Alternating Row Color
                            row.style.backgroundColor = "#C2D69B";
                        }
                        else {
                            row.style.backgroundColor = "white";
                        }
                        inputList[i].checked = false;
                    }
                }
            }
        }

        function MouseEvents(objRef, evt) {
            var checkbox = objRef.getElementsByTagName("input")[0];
            if (evt.type == "mouseover") {

                objRef.style.backgroundColor = "orange";
            }
            else {
                if (checkbox.checked) {
                    objRef.style.backgroundColor = "aqua";
                }
                else if (evt.type == "mouseout") {
                    if (objRef.rowIndex % 2 == 0) {
                        //Alternating Row Color
                        objRef.style.backgroundColor = "#C2D69B";
                    }
                    else {
                        objRef.style.backgroundColor = "white";
                    }
                }
            }
        }

        function Check_Click(objRef) {
            //Get the Row based on checkbox
            var row = objRef.parentNode.parentNode;
            if (objRef.checked) {
                //If checked change color to Aqua
                //row.style.backgroundColor = "aqua";
            }
            else {
                //If not checked change back to original color
                if (row.rowIndex % 2 == 0) {
                    //Alternating Row Color
                    //row.style.backgroundColor = "#C2D69B";
                }
                else {
                    //row.style.backgroundColor = "white";
                }
            }
            //Get the reference of GridView
            var GridView = row.parentNode;
            //Get all input elements in Gridview
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                //The First element is the Header Checkbox
                var headerCheckBox = inputList[0];
                //Based on all or none checkboxes
                //are checked check/uncheck Header Checkbox
                var checked = true;
                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                    if (!inputList[i].checked) {
                        checked = false;
                        break;
                    }
                }
            }
            headerCheckBox.checked = checked;
        }

    </script>--%>




    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="">
            <div class="row">
                <div class="col-lg-12">
                    <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">


                        <div class="m-portlet__head">
                            <div class="m-portlet__head-progress">

                                <!-- here can place a progress bar-->
                            </div>
                            <div class="m-portlet__head-wrapper">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">Location QR Codes
                                        </h3>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="m-portlet__body" style="padding: 0.4rem 2.2rem;">

                            <br />
                            <div class="form-group m-form__group row">
                                <div class="col-md-3">
                                    <div class="m-input-icon m-input-icon--left">
                                        <input type="text" class="form-control m-input" placeholder="Search..." id="generalSearch" />
                                        <span class="m-input-icon__icon m-input-icon__icon--left">
                                            <span><i class="la la-search"></i></span>
                                        </span>
                                    </div>
                                </div>
                                <div class="col-md-9" style="text-align: right;">
                                    <asp:Button ID="btnGenerateQRCode" runat="server" OnClick="btnGenerateQRCode_Click" OnClientClick="target ='_blank';" Text="Generate QR Code" class="btn btn-primary btn-success" />
                                </div>
                            </div>
                            <br />

                            <div class="form-group m-form__group row" style="padding-left: 1%;">

                                <div class="" id="" style="overflow-x: auto; width: 90%;">
                                    <asp:GridView ID="gvLocation_QRCode" runat="server" CssClass="table table-striped- table-bordered table-hover table-checkable m-datatable"
                                        OnRowDataBound="gvLocation_QRCode_RowDataBound" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                                        AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="20px">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="checkAll" runat="server" OnCheckedChanged="checkAll_CheckedChanged" AutoPostBack="true" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="ChkIndividual" runat="server"  />
                                                    <asp:HiddenField ID="hdnLocationID" runat="server" Value='<%#Eval("Loc_id") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Loc_Desc" HeaderText="Location" ItemStyle-Width="800px" />

                                        </Columns>
                                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                    </asp:GridView>

                                </div>

                                <asp:Image ID="imgQR" runat="server" Visible="false" />
                             

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
