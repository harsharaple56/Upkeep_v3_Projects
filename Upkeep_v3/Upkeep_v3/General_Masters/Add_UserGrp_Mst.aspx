﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Add_UserGrp_Mst.aspx.cs" Inherits="Upkeep_v3.General_Masters.Add_UserGrp_Mst" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .hiddencol {
            display: none;
        }
    </style>

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>

    <%--<script src="<%= Page.ResolveClientUrl("~/assets/jquery-1.7.2.min.js") %>" type="text/javascript"></script>--%>
    <%--<script src="assets/jquery-1.7.2.min.js"></script>--%>

    <script type="text/javascript">
        <%--$(function () {
           
            $("#<%=btnAddUserGrp.ClientID%>").click(function () {
                
                var empcd = window.document.getElementById('<%=GrdEmp.ClientID%>');

                $("#<%=Usernm.ClientID%> input[type=checkbox]:checked").each(function () {
                    var row = $(this).closest("tr")[0];
                   
                    empcd.value = row.cells[1].innerHTML + "," + empcd.value;
                });
            });
        });--%>

        
        function Search_Gridview(strKey, strGV) {

            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById(strGV);
            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                        styleDisplay = '';
                    else {
                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }
        }




        <%--function FunLocCheck(VarLocChkObj, VarLocLoop) {
            if (VarLocChkObj.checked == true) {
                if (document.getElementById('<%=this.TxtMembers.ClientID%>').value.indexOf("=$=" + VarLocChkObj.value + "=$=") < 0) {
                    if (document.getElementById('<%=this.TxtMembers.ClientID%>').value == "") //if it is 1st item in a hidden field
                    {
                        document.getElementById('<%=this.TxtMembers.ClientID%>').value = "=$=" + VarLocChkObj.value + "=$=";
                    }
                    else//if it is not 1st item in a hidden field
                    {
                        document.getElementById('<%=this.TxtMembers.ClientID%>').value += VarLocChkObj.value + "=$=";
                        VarLocChkObj.checked = true;
                    }
                }
            }
            else //if check box is unchecked then remove Designation id from hidden field
            {
                if (document.getElementById('<%=this.TxtMembers.ClientID%>').value.indexOf("=$=" + VarLocChkObj.value + "=$=") >= 0) {
                    document.getElementById('<%=this.TxtMembers.ClientID%>').value = document.getElementById('<%=this.TxtMembers.ClientID%>').value.replace("=$=" + VarLocChkObj.value + "=$=", "=$=");
                }
            }
        }--%>

       <%-- function FunPubOnload() {
           
            if (window.document.getElementById('<%=TxtMembers.ClientID%>').value != "") {
                var temp = window.document.getElementById('<%=TxtMembers.ClientID%>').value;
                var arrt = temp.split("=$=");
                var i;
               
                for (i = 1; i < arrt.length - 1; i++) {
                    window.document.getElementById('<%=HdnEmpDetail.ClientID%>').value = arrt[i];
                   
                    FunPubNeedload()
                }
            }
        }--%>



        <%--function FunPubNeedload() {
          
            if (window.document.getElementById('<%=HdnEmpDetail.ClientID%>').value != "") {
                var hdnValues = window.document.getElementById('<%=HdnEmpDetail.ClientID%>').value;
                var VarLocStrCount;
               
                for (var intCount = 0; ; intCount++) {
                    if (intCount <= 9) {
                        VarLocStrCount = intCount;
                    }
                    else {
                        VarLocStrCount = intCount;
                    }

                    var chkBox = window.document.all('ContentPlaceHolder1_Usernm_ctl00_' + VarLocStrCount);

                    if (chkBox != null) {

                        var chkBoxVal = Trim(chkBox.value) + "=$=";
                        var chkboxval1 = Trim(chkBox.value);

                        if (window.document.getElementById('<%=HdnEmpDetail.ClientID%>').value != "") {


                            if (Trim(chkboxval1) == Trim(hdnValues)) {
                                chkBox.checked = true;
                            }
                        }
                    }
                    else {
                        break;
                    }
                }

            }
        }--%>




        function Trim(myString) {
            return myString.replace(/^\s*(\b.*\b|)\s*$/, "$1");
        }



    </script>
    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" runat="server" id="frmUserGrp">
                        <div class="m-form m-form--label-align-left- m-form--state-" id="employee_form">
                            <div class="m-portlet__head">
                                <div class="m-portlet__head-progress">

                                    <!-- here can place a progress bar-->
                                </div>
                                <div class="m-portlet__head-wrapper">
                                    <div class="m-portlet__head-caption">
                                        <div class="m-portlet__head-title">
                                            <h3 class="m-portlet__head-text">User Group
                                            </h3>
                                        </div>
                                    </div>

                                    <div class="m-portlet__head-tools">
                                        <a href="<%= Page.ResolveClientUrl("UserGrp_Mst.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                            <span>
                                                <i class="la la-arrow-left"></i>
                                                <span>Back</span>
                                            </span>
                                        </a>
                                        <div class="btn-group">

                                            <asp:Button ID="btnAddUserGrp" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnAddUserGrp_Click" Text="+ Add User Group" ValidationGroup="validationGroupName" />

                                        </div>
                                    </div>


                                </div>
                            </div>

                            <div class="m-portlet__body">


                                <!--begin: Form Body -->
                                <div class="m-portlet__body">
                                    <div class="row">
                                        <div class="col-xl-8 offset-xl-0" style="margin-top: 1px;">
                                            <div class="m-form__section m-form__section--first">
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-4 col-form-label">* Group Name:</label>
                                                    <div class="col-xl-6">
                                                        <asp:TextBox ID="txtGroupName" runat="server" class="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvGroupname" runat="server" ControlToValidate="txtGroupName" Visible="true" ValidationGroup="validationGroupName" ForeColor="Red" ErrorMessage="Please enter Group Name"></asp:RequiredFieldValidator>
                                                        <asp:Label ID="lblGroupName" runat="server" ForeColor="Red" Visible="false" Font-Bold="true">Group Name already Exists</asp:Label>

                                                    </div>

                                                </div>

                                                <div class="form-group m-form__group row">
                                                    <%--<label class="col-xl-4 col-form-label">Search User Name:</label>--%>
                                                    <div class="col-xl-6">
                                                        <asp:TextBox ID="txtSearchUserName" runat="server" placeholder="Search UserName" class="form-control" onkeyup="Search_Gridview(this, 'ContentPlaceHolder1_Usernm')"></asp:TextBox>
                                                    </div>
                                                </div>


                                                <div class="form-group m-form__group row">
                                                    <div class="col-xl-9 col-lg-9">
                                                        <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>

                                        <div class="col-xl-12">
                                            <asp:GridView ID="Usernm" runat="server" AutoGenerateColumns="False"
                                                CssClass="table table-striped- table-bordered table-hover table-checkable"
                                                OnRowDataBound="Usernm_RowDataBound" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White">
                                                <Columns>
                                                    <%--<asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                        <ItemStyle CssClass="table-checkbox" />
                                                    </asp:TemplateField>--%>

                                                    <asp:TemplateField HeaderText="Select">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkUserID" runat="server" CssClass="checkbox--success" Checked='<%# Convert.ToBoolean(Eval("Is_Selected")) %>' />
                                                            <asp:HiddenField ID="hdnUserID" runat="server" Value='<%#Eval("User_ID") %>' />

                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="User_ID" HeaderText="User_ID"
                                                        SortExpression="User_ID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                                    <asp:BoundField DataField="F_Name" HeaderText="User name" ReadOnly="True" SortExpression="F_Name" />

                                                </Columns>
                                                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                            </asp:GridView>
                                        </div>

                                        <asp:TextBox ID="TxtMembers" runat="server" Width="100%" Style="display: none;"></asp:TextBox>
                                        <input type="hidden" id="HdnEmpDetail" runat="server" />
                                        <asp:HiddenField ID="GrdEmp" runat="server" />
                                        <asp:HiddenField ID="ChkEmp" runat="server" />
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
