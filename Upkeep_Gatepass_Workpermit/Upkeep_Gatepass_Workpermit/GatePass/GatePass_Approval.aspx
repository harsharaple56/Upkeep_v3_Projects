<%@ Page Title="" Async="true"  Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="GatePass_Approval.aspx.cs" Inherits="Upkeep_Gatepass_Workpermit.GatePass.GatePass_Approval" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        function FunctionBack() {
            document.getElementById("<%=btnCancel.ClientID %>").click();
        }
    </script>

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <%--<form class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmGatePass" method="post">--%>
                        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

                        <asp:HiddenField ID="hdnGpHeaderData" runat="server" ClientIDMode="Static" />
                        <asp:HiddenField ID="hdnGpHeader" runat="server" ClientIDMode="Static" />
                        <p id="info" style="display: none;"></p>
                        <p id="infox" style="display: none;"></p>

                        <div class="m-portlet__head">
                            <div class="m-portlet__head-progress">

                                <!-- here can place a progress bar-->
                            </div>
                            <div class="m-portlet__head-wrapper">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">Gate Pass Request Approval
                                        </h3>
                                    </div>
                                </div>

                                <div class="m-portlet__head-tools">

                                    <a class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10" onclick="FunctionBack();">
                                        <span>
                                            <i class="la la-arrow-left"></i>
                                            <span>Back</span>
                                        </span>
                                    </a>
                                    <%--<div class="btn-group">
                                            <asp:Button ID="btnSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" ValidationGroup="validateTicket" OnClick="btnSave_Click" Text="Save" />                                          
                                        </div>--%>
                                </div>

                            </div>
                        </div>

                        <div class="m-portlet__body" style="padding: 0.4rem 2.2rem;">

                            <div class="m-portlet__body" style="padding: 0.3rem 2.2rem;">
                                <div class="form-group row" style="padding-left: 1%;">
                                    <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Ticket No :</label>
                                    <div class="col-xl-3 col-lg-3 col-form-label">
                                        <asp:Label ID="lblTicketNo" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                    </div>

                                    <label class="col-xl-3 col-lg-2 col-form-label font-weight-bold">Gate Pass Title :</label>
                                    <div class="col-xl-4 col-lg-4 col-form-label">
                                        <asp:Label ID="lblGatepassTitle" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group row" style="padding-left: 1%;">
                                    <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Request Status :</label>
                                    <div class="col-xl-3 col-lg-3 col-form-label">
                                        <asp:Label ID="lblRequestStatus" runat="server"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                    <label class="col-xl-3 col-lg-3 col-form-label font-weight-bold">Gatepass Description :</label>
                                    <div class="col-xl-9 col-lg-9 col-form-label">
                                        <asp:Label ID="lblGatepassDescription" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                    </div>
                                </div>

                                <%--<br />--%>

                                <div class="form-group row" style="background-color: #00c5dc;">
                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Initiator Details</label>
                                </div>

                                <div id="dvEmployee" runat="server" style="display: block;">
                                    <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                        <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Employee Name :</label>
                                        <div class="col-xl-3 col-lg-3 col-form-label">
                                            <asp:Label ID="lblEmpName" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                        </div>

                                        <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold" style="text-align: right;">Employee Code :</label>
                                        <div class="col-xl-3 col-lg-3 col-form-label">
                                            <asp:Label ID="lblEmpCode" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                        </div>

                                    </div>
                                </div>

                                <div id="dvRetailer" runat="server" style="display: block;">
                                    <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                        <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Store Name :</label>
                                        <div class="col-xl-3 col-lg-3 col-form-label">
                                            <asp:Label ID="lblStoreName" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                        </div>

                                        <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold" style="text-align: right;">Manager Name :</label>
                                        <div class="col-xl-3 col-lg-3 col-form-label">
                                            <asp:Label ID="lblRetailerName" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                        </div>

                                    </div>


                                </div>
                                <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                    <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Mobile No. :</label>
                                    <div class="col-xl-3 col-lg-3 col-form-label">
                                        <asp:Label ID="lblMobileNo" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                    </div>

                                    <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold" style="text-align: right;">Email ID :</label>
                                    <div class="col-xl-3 col-lg-3 col-form-label">
                                        <asp:Label ID="LblEmailID" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                    </div>

                                </div>

                                <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                    <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Gate Pass Date :</label>
                                    <div class="col-xl-3 col-lg-3 col-form-label">
                                        <asp:Label ID="lblRequestDate" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                    </div>

                                    <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold" style="text-align: right;">Department :</label>
                                    <div class="col-xl-3 col-lg-3 col-form-label">
                                        <asp:Label ID="lblDepartment" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                    </div>
                                </div>

                                <br />

                                <div class="form-group row" style="background-color: #00c5dc;">
                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Gate Pass Details</label>
                                </div>

                                <div class="form-group m-form__group row" style="padding-left: 1%;">
                                    <label class="col-xl-3 col-lg-2 form-control-label font-weight-bold">Gate Pass Type :</label>
                                    <div class="col-xl-4 col-lg-4">
                                        <asp:Label ID="lblGatePassType" runat="server" Text="" CssClass="form-control-label"></asp:Label>

                                    </div>
                                </div>


                                <div class="m-portlet__body" style="overflow-x: scroll;">

                                    <%--<table class="table table-striped- table-bordered table-hover table-checkable" style="width: 100%" border="1" runat="server" id="tblGatePassHeader">
                                        </table>--%>
                                    <asp:GridView ID="gvGPHeader" runat="server" CssClass="table table-hover table-striped" HorizontalAlign="Center" AutoGenerateColumns="true"></asp:GridView>


                                </div>

                                <br />
                                <br />
                                <div class="form-group row" style="background-color: #00c5dc;">
                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Gate Pass Terms & Conditions</label>
                                </div>


                                <asp:Repeater ID="rptTermsCondition" runat="server" ClientIDMode="Static">
                                    <ItemTemplate>
                                        <table style="width: 100%">
                                            <tr>
                                                <td>
                                                    <asp:CheckBox runat="server" ID="chkTermsCondition" Checked="true" CssClass="disabled" Enabled="false" />
                                                </td>
                                                <td style="width: 5%">
                                                    <asp:Label ID="lblTermID" runat="server" Text='<%#Eval("GP_Terms_ID") %>' Style="display: none;"></asp:Label>
                                                </td>
                                                <td style="width: 90%" colspan="2">
                                                    <asp:Label ID="lblTermDesc" runat="server" Text='<%#Eval("Terms_Desc") %>' ClientIDMode="Static" CssClass="form-control-label col-form-label font-weight-bold"></asp:Label>
                                                </td>

                                            </tr>
                                            <br />
                                        </table>
                                    </ItemTemplate>
                                </asp:Repeater>


                                <br />

                                <div id="dvApprovalHistory" runat="server" style="display: none;">
                                    <div class="form-group row" style="background-color: #00c5dc;">
                                        <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Gate Pass Approval History</label>
                                    </div>
                                    <asp:GridView ID="gvApprovalHistory" runat="server" CssClass="table table-hover table-striped" HorizontalAlign="Center" AutoGenerateColumns="False">

                                        <Columns>
                                            <asp:BoundField DataField="Level" HeaderText="Level" />
                                            <asp:BoundField DataField="Approver" HeaderText="Approver" />
                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                            <asp:BoundField DataField="Action Date" HeaderText="Action Date" />
                                            <asp:BoundField DataField="Status" HeaderText="Status" />
                                            <asp:TemplateField HeaderText="Signature" HeaderStyle-Width="200px">
                                                <ItemTemplate>
                                                    <asp:Image ID="imgSignature" Height="100" Width="100" runat="server" AlternateText="Signature Missing.."
                                                        ImageUrl='<%# ResolveUrl("../assets/app/media/img/signature/"+Eval("Emp_Sign").ToString()) %>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <br />

                                <div class="form-group row" style="background-color: #00c5dc;" id="dvApprovalDetHeader" runat="server">
                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Gate Pass Approval Details</label>
                                </div>

                                <div class="form-group m-form__group row" style="padding-left: 1%;" id="dvApprovalDetails" runat="server">
                                    <label class="col-xl-2 col-lg-2 form-control-label font-weight-bold"><span style="color: red;">*</span> Action :</label>
                                    <div class="col-xl-2 col-lg-4">
                                        <asp:DropDownList ID="ddlAction" class="form-control m-input" runat="server"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlAction" Visible="true" Display="Dynamic"
                                            ValidationGroup="validateGatePass" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Action"></asp:RequiredFieldValidator>
                                    </div>

                                    <label class="col-xl-2 col-lg-2 form-control-label font-weight-bold"><span style="color: red;">*</span> Remarks :</label>
                                    <div class="col-xl-6 col-lg-4">
                                        <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" class="form-control m-input autosize_textarea TermCondition_textarea"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRemarks" Visible="true" Display="Dynamic"
                                            ValidationGroup="validateGatePass" ForeColor="Red" InitialValue="0" ErrorMessage="Please enter Remarks"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div id="dvApprovalMatrix" runat="server">
                                    <div class="form-group row" style="background-color: #00c5dc;">
                                        <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Approval Matrix</label>
                                    </div>
                                    <div>
                                        <asp:GridView ID="gvApprovalMatrix" runat="server" CssClass="table table-hover table-striped" HorizontalAlign="Center" AutoGenerateColumns="true"></asp:GridView>
                                    </div>
                                </div>

                                <br />

                                <div class="col-lg-9 ml-lg-auto" id="dvSubmitSection" runat="server">
                                    <asp:Button ID="btnSubmit" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Style="margin-right: 20px;" OnClick="btnSubmit_Click" Text="Submit" ValidationGroup="validateGatePass" />

                                    <asp:Button ID="btnCancel" runat="server" class="btn btn-secondary btn-outline-hover-danger btn-sm m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10" Style="margin-right: 20px;" OnClick="btnCancel_Click" Text="Cancel" />

                                    <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-8 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>

                                </div>
                                <br />
                                <br />

                            </div>
                        </div>





                        <%--</form>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
