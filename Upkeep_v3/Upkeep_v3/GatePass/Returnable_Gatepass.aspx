<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Returnable_Gatepass.aspx.cs" Inherits="Upkeep_v3.GatePass.Returnable_Gatepass" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            let hidebtns;
            let btn_ReturnSave = $("[id*=btn_ReturnableSave]");
            let btn_ForceSave = $("[id*=btn_ReturnableForcefullySave]");

            btn_ReturnSave.hide();
            btn_ForceSave.hide();

            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": false,
                "progressBar": false,
                "positionClass": "toast-bottom-center",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "1500",
                "hideDuration": "2000",
                "timeOut": "2000",
                "extendedTimeOut": "2000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            };

            $("[id*=ddlAction]").change(function () {
                var value = $("[id*=ddlAction]").val();
                if (value == "2" || value == "3") {
                    ValidatorEnable(document.getElementById('<%= RequiredFieldValidator2.ClientID %>'), true);
                }
                else if (value == "1" || value == "4") {
                    ValidatorEnable(document.getElementById('<%= RequiredFieldValidator2.ClientID %>'), false);
                }
            });

            $("[id*=txtreturnableqty]").keyup(function () {
                //calculate total for current row
                var val1 = $(this).val() == "" ? 0 : $(this).val();
                var val2 = $(this).closest('tr').find("td:eq(4)").text();
                var checkval = parseInt(val2) >= parseInt(val1);
                if (!checkval) {
                    $(this).val("");
                    hidebtns = true;
                    toastr.error("Please enter correct value.");
                }
                else {
                    var grid = document.getElementById("<%= gvGPHeader.ClientID %>");
                    for (var i = 0; i < grid.rows.length - 1; i++) {
                        let received = $("input[id*=txtreturnableqty]");
                        let pending = grid.rows[i + 1].cells[4].innerText
                        if (parseInt(pending) == parseInt(received[i].value)) {
                            hidebtns = true;
                            $("input[id*=hdnFullySave]").val('true');
                        }
                        else if (parseInt(pending) != parseInt(received[i].value)) {
                            hidebtns = false;
                            $("input[id*=hdnFullySave]").val('false');
                            break;
                        }
                    }

                    if (hidebtns) {
                        btn_ReturnSave.show();
                        btn_ForceSave.hide();
                    }
                    else {
                        btn_ReturnSave.show();
                        btn_ForceSave.show();
                    }
                }



            });
        });
    </script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        function FunctionBack() {
            document.getElementById("<%=btnCancel.ClientID %>").click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="m-grid__item m-grid__item--fluid">
        <div class="m-content">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <%--<form class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmGatePass" method="post">--%>
                        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
                        <asp:HiddenField ID="hdnFullySave" runat="server" ClientIDMode="Static" />
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
                                    <asp:Button ID="Btn_GP_Print_PDF_Employee" runat="server" Text="Print PDF E" OnClick="btn_GP_Print_PDF_Employee" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10" />
                                    <asp:Button ID="Btn_GP_Print_PDF_Retailer" runat="server" Text="Print PDF R" OnClick="btn_GP_Print_PDF_Retailer" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10" />

                                    <asp:LinkButton ID="lnbtn" OnClick="btnCancel_Click" runat="server" class="btn btn-secondary btn-outline-hover-danger btn-sm m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                        <span>
                                            <i class="la la-arrow-left"></i>
                                            <span>Back</span>
                                        </span>
                                    </asp:LinkButton>


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

                                    <asp:GridView ID="gvGPHeader" class="table table-striped- table-bordered table-hover table-checkable" runat="server" Width="100%"
                                        AllowPaging="true" HorizontalAlign="Center"
                                        PageSize="10" AutoGenerateColumns="false" CellPadding="5"
                                        PagerStyle-HorizontalAlign="Center" PagerStyle-Mode="NumericPages" PagerSettings-Mode="Numeric"
                                        PagerSettings-Position="Bottom" ClientIDMode="Static"
                                        OnPageIndexChanging="gvGPHeader_PageIndexChanging">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Columns>

                                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="GrayText" ControlStyle-CssClass="form-control" DataField="SrNo" HeaderText="SrNo" SortExpression="SrNo" />
                                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="GrayText" ControlStyle-CssClass="form-control" DataField="Item Description" HeaderText="Item Description" SortExpression="Item Description" />
                                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="GrayText" ControlStyle-CssClass="form-control" DataField="Actual Quantity" HeaderText="Actual Quantity" SortExpression="Actual Quantity" />
                                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="GrayText" ControlStyle-CssClass="form-control" DataField="Returned Quantity" HeaderText="Returned Quantity" SortExpression="Returned Quantity" />
                                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="GrayText" ControlStyle-CssClass="form-control" DataField="Pending Quantity" HeaderText="Pending Quantity" SortExpression="Pending Quantity" />

                                            <asp:TemplateField HeaderText="Received Quantity" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:TextBox autocomplete="off" onkeypress="return (event.charCode !=8 && event.charCode ==0 || (event.charCode >= 48 && event.charCode <= 57))" ID="txtreturnableqty"
                                                        Width="100px" CssClass="form-control" runat="server"></asp:TextBox>
                                                </ItemTemplate>

                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>

                                        </Columns>
                                        <EmptyDataTemplate>
                                            No Records Found !!!
                                        </EmptyDataTemplate>
                                        <EmptyDataRowStyle Height="50%" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px"
                                            HorizontalAlign="Center" />
                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />

                                        <PagerStyle HorizontalAlign="Center"></PagerStyle>
                                    </asp:GridView>


                                </div>

                                <br />

                                <div class="form-group row" id="dv_GP_Document" runat="server" style="background-color: #00c5dc;">
                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Gate Pass Documents</label>
                                </div>

                                <asp:Repeater ID="rptGP_Doc_Upload" runat="server">
                                    <ItemTemplate>
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="width: 5%"></td>
                                                <td style="width: 30%">
                                                    <asp:Label ID="lblGP_Doc_Desc" runat="server" Text='<%#Eval("Doc_Desc") %>' ClientIDMode="Static" CssClass="form-control-label col-form-label font-weight-bold"></asp:Label>
                                                </td>

                                                <td style="width: 65%">
                                                    <%--<button type='button' data-toggle='modal' data-target="#exampleModal" data-images="<%#Eval("Doc_Path") %>"  class='btn btn-accent m-btn m-btn--icon' data-container='body' style="width: 41px; height: 41px;" data-toggle='m-tooltip' data-placement='top' title='View Uploaded Documents'>
                                                        <i class='la la-image' style="margin-left: -106%; font-size: 2.3rem;"></i>
                                                    </button>--%>
                                                    <asp:LinkButton ID="lnk" runat="server" href='<%# DataBinder.Eval(Container.DataItem, "Doc_Path") %>' Text="Click Here" ToolTip="Click here to view Uploaded documents"
                                                        class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" target="_blank"></asp:LinkButton>
                                                </td>



                                            </tr>
                                            <br />
                                            <%--<tr>
                                                <td style="width: 5%"></td>

                                                <td style="width: 76%" id="tdRemarks" runat="server">
                                                    <div class="form-group row">
                                                    </div>
                                                </td>

                                            </tr>--%>
                                        </table>
                                    </ItemTemplate>
                                </asp:Repeater>




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
                                    <asp:GridView ID="gvApprovalHistory" runat="server" class="table table-striped- table-bordered table-hover table-checkable" HorizontalAlign="Center" AutoGenerateColumns="False">

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

                                <div id="dv_Approval" runat="server">

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


                                    </div>

                                    <div id="dvApprovalMatrix" runat="server">
                                        <div class="form-group row" style="background-color: #00c5dc;">
                                            <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Approval Matrix</label>
                                        </div>
                                        <div>
                                            <asp:GridView ID="gvApprovalMatrix" runat="server" CssClass="table table-hover table-striped" HorizontalAlign="Center" AutoGenerateColumns="true"></asp:GridView>
                                        </div>
                                    </div>

                                    <hr />

                                    <div id="dvSubmitSection" runat="server">
                                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Style="margin-right: 20px;" OnClick="btnSubmit_Click" Text="Submit" ValidationGroup="validateGatePass" />

                                        <asp:Button ID="btnCancel" runat="server" class="btn btn-secondary btn-outline-hover-danger btn-sm m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10" Style="margin-right: 20px;" OnClick="btnCancel_Click" Text="Cancel" />


                                    </div>

                                </div>

                                <label class="col-xl-2 col-lg-2 form-control-label font-weight-bold">Remarks :</label>
                                <div class="col-xl-12 col-lg-4">
                                    <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" class="form-control m-input autosize_textarea TermCondition_textarea"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRemarks"
                                        ValidationGroup="validateGatePass1" ForeColor="Red" ErrorMessage="Please enter Remarks"></asp:RequiredFieldValidator>
                                </div>
                                <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-8 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>

                                <hr />

                                <div id="dv_returnable" runat="server">
                                    <asp:Button ID="btn_ReturnableSave" runat="server" class="btn btn-success m-btn--wide" OnClick="btn_ReturnableSave_Click" Text="Save" ValidationGroup="validateGatePass1" />
                                    <asp:Button ID="btn_ReturnableForcefullySave" runat="server" class="btn btn-info m-btn--wide mx-2" OnClick="btn_ReturnableForcefullySave_Click" Text="Forcefully Close" />
                                </div>

                            </div>
                        </div>


                        <div aria-hidden="true" aria-labelledby="exampleModalLabel" class="modal fade" id="exampleModal" role="dialog" tabindex="-1">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="exampleModalLabel">Uploaded Documents
                                        </h5>
                                        <button aria-label="Close" class="close" data-dismiss="modal" type="button">
                                            <span aria-hidden="true">×
                                            </span>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <div class="carousel slide" data-ride="carousel" id="carouselExampleControls">
                                            <div class="carousel-inner">
                                            </div>
                                            <a class="carousel-control-prev" data-slide="prev" href="#carouselExampleControls" role="button">
                                                <span aria-hidden="true" class="carousel-control-prev-icon"></span>
                                                <span class="sr-only">Previous
                                                </span>
                                            </a>
                                            <a class="carousel-control-next" data-slide="next" href="#carouselExampleControls" role="button">
                                                <span aria-hidden="true" class="carousel-control-next-icon"></span>
                                                <span class="sr-only">Next
                                                </span>
                                            </a>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>



                        <%--</form>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" BorderWidth="0px" Visible="false" ShowFindControls="False" Height="100%" ShowBackButton="True"
        ProcessingMode="Remote" ShowPromptAreaButton="False">
    </rsweb:ReportViewer>

</asp:Content>
