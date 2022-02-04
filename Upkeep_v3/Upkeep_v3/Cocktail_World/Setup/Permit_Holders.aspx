<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Permit_Holders.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Setup.Permit_Holders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .modalBackground {
            background-color: grey;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            padding: 10px;
            width: 300px;
        }
    </style>

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#m_table_1').DataTable({
                responsive: true,
                pagingType: 'full_numbers',
                'fnDrawCallback': function () {
                    init_plugins();
                }
            });

            $('.datetimepicker').datepicker({
                todayHighlight: true,
                orientation: 'auto bottom',
                autoclose: true,
                pickerPosition: 'bottom-right',
                format: 'dd-MM-yyyy',
                showMeridian: true
            });
        });

    </script>

    <script language="C#" runat="server">

        protected void LinkButton_Click(Object sender, EventArgs e)
        {
            Closecontrol();
        }

    </script>

    <div runat="server">
        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <div class="m-content">
                <div class="m-portlet m-portlet--mobile">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Permit Master		
                                </h3>
                            </div>
                        </div>
                        <div class="m-portlet__head-tools">
                            <a href="<%= Page.ResolveClientUrl("~/Cocktail_World/Setup/Setup.aspx") %>" class="btn btn-metal m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m--margin-right-10">
                                <span>
                                    <i class="la la-arrow-left"></i>
                                    <span>Back</span>
                                </span>
                            </a>
                            <asp:LinkButton ID="btnAddPermit" runat="server" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air" OnClick="btnPermitSave_Click">
                                <span>
                                    <i class="fa fa-plus"></i>
                                    <span>Add Permit Holder</span>
                                </span>
                            </asp:LinkButton>
                            <cc1:ModalPopupExtender CancelControlID="btnCloseHeader" BackgroundCssClass="modalBackground" ID="mpeCategoryMaster" runat="server" PopupControlID="pnlCategoryMaster" TargetControlID="btnAddPermit" />
                        </div>
                    </div>
                    <div class="m-portlet__body">
                        <!--begin: Datatable -->
                        <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">
                            <thead>
                                <tr>
                                    <th>Permit Type</th>
                                    <th>Permit Holder</th>
                                    <th>Permit Number</th>
                                    <th>Expiry Date</th>
                                    <th>Life Time</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                <%=bindgrid()%>
                            </tbody>
                        </table>
                    </div>
                </div>

                <!-- END EXAMPLE TABLE PORTLET-->
            </div>
        </div>

        <asp:Panel ID="pnlCategoryMaster" runat="server" align="center" Style="display: none; width: 50%;">
            <div class="" id="add_sub_location" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>

                                <div class="modal-header">
                                    <h5 class="modal-title" id="exampleModalLabel">Permit Master</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <div class="form-group m-form__group row">
                                        <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Permit Type :</label>

                                        <asp:DropDownList ID="ddlPermitType" class="form-control" Style="width: 60%" runat="server">
                                            <asp:ListItem Value="0"> --- Select Permit Type --- </asp:ListItem>
                                            <asp:ListItem Value="1"> PERMITHOLDER </asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlPermitType" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationWorkflow" ForeColor="Red" ErrorMessage="Please enter Permit Type"></asp:RequiredFieldValidator>

                                    </div>

                                    <div class="form-group m-form__group row">
                                        <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Permit Number :</label>
                                        <asp:TextBox ID="txtPermitNumber" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPermitNumber" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationWorkflow" ForeColor="Red" ErrorMessage="Please enter Permit Number"></asp:RequiredFieldValidator>
                                    </div>


                                    <div class="form-group m-form__group row">
                                        <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Permit Holder Name :</label>
                                        <asp:TextBox ID="txtPermitHolder" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPermitHolder" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationWorkflow" ForeColor="Red" ErrorMessage="Please enter Permit Holder"></asp:RequiredFieldValidator>

                                    </div>


                                    <div class="form-group m-form__group row">
                                        <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Expire Date :</label>
                                        <div class="m-form__control">
                                            <div class="input-group date">
                                                
                                                        <asp:TextBox autocomplete="off" runat="server" type="text" class="form-control m-input datetimepicker" ID="txtExpireDate">
                                                        </asp:TextBox>
                                                        <div class="input-group-append">
                                                            <span class="input-group-text">
                                                                <i class="la la-calendar" style="font-size: 2rem;"></i>
                                                            </span>
                                                        </div>
                                                        </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtExpireDate" Visible="true" ValidationGroup="validationWorkflow" ForeColor="Red" ErrorMessage="Please enter Expire Date"></asp:RequiredFieldValidator>
                                                   
                                </div>
                                </div>

                                        <div class="col-12">
                                            <div class="form-group m-form__group row">
                                                <div class="col-lg-10">
                                                    <asp:CheckBox ID="chkLifeTime" CssClass="m-checkbox--success" runat="server" />
                                                    <label for="message-text" style="text-align: center;">Life Time</label>
                                                </div>
                                            </div>
                                        </div>


                                        <asp:Label ID="lblCategoryErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>

                                    </div>

                                    <div class="modal-footer">
                                        <asp:Button ID="btnClosePermit" Text="Close" runat="server" class="btn btn-danger" OnClick="btnClosePermit_Click" />
                                        <asp:Button ID="btnPermitSave" runat="server" class="btn btn-primary" CausesValidation="true" ValidationGroup="validationWorkflow" OnClick="btnPermitSave_Click" Text="Save" />

                                    </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnPermitSave" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <!-- End Modal -->
        </asp:Panel>
    </div>
</asp:Content>
