<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Edit_Checklist.aspx.cs" Inherits="Upkeep_v3.Checklist.Edit_Checklist" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
        });
    </script>

    <style type="text/css">
        .modalBackground {
            background-color: grey;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            /*background-color: #fff;
            border: 3px solid #ccc;*/
            padding: 10px;
            width: 500px;
        }

        /*.highlight {
            background-color: blanchedalmond;
        }*/
    </style>


    <script>
        function init_autosize() {
            var autosize_textarea = $('.autosize_textarea');
            autosize(autosize_textarea);
            autosize.update(autosize_textarea);
        }

        $(document).ready(function () {
            init_autosize();
            init_plugins();

            $('.datetimepicker').datetimepicker({
                todayHighlight: true,
                autoclose: true,
                pickerPosition: 'bottom-right',
                format: 'dd/mm/yyyy HH:ii P',
                showMeridian: true,
                startDate: moment().format('YYYY-MM-DD'),
            }).on('changeDate', function (event) {
                var startDate = moment($('#startDate').val(), 'DD/MM/YYYY hh:mm A').valueOf();
                var endDate = moment($('#endDate').val(), 'DD/MM/YYYY hh:mm A').valueOf();
                $('#error_endDate').html('').parents('.form-group').removeClass('has-error');
                if (endDate < startDate) {
                    $('#error_endDate').html('Event end date-time can not be before the start date.').parents('.form-group').addClass('has-error');
                }
            });

            $('.datetimepicker').on('click', function () {
                if ($(this).is('#startDate')) {
                    $('#endDate').datetimepicker('hide');
                }
                if ($(this).is('#endDate')) {
                    $('#startDate').datetimepicker('hide');
                }
            });




        });
    </script>

    <script type="text/javascript">
        function BindChklstPoint(ChecklstPointID) {
            $("#hdnChecklstPointID").val(ChecklstPointID)

            document.getElementById('<%= btnBindChklstPoint.ClientID %>').click();
        }

        function DeleteChklstPoint(ChecklstPointID) {
            $("#hdnDeleteChklstPointID").val(ChecklstPointID)

            <%--document.getElementById('<%= btnBindChklstPoint.ClientID %>').click();--%>

            if (confirm('Are you sure you want to delete this point?')) {
                // Save it!
                document.getElementById('<%= btnBindChklstPoint.ClientID %>').click();
            } else {
                // Do nothing!
            }
        }
    </script>

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content" style="padding: 7px 4px;">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <form class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmChkList" method="post">
                            <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

                            <asp:HiddenField runat="server" ID="hdnChecklstPointID" ClientIDMode="Static" />
                            <asp:HiddenField runat="server" ID="hdnDeleteChklstPointID" ClientIDMode="Static" />

                            <div class="m-portlet__head">
                                <div class="m-portlet__head-progress">

                                    <!-- here can place a progress bar-->
                                </div>
                                <div class="m-portlet__head-wrapper">
                                    <div class="m-portlet__head-caption">
                                        <div class="m-portlet__head-title">
                                            <h3 class="m-portlet__head-text">Checklist Details
                                            </h3>
                                        </div>
                                    </div>

                                    <div class="m-portlet__head-tools">
                                        <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-6 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold; display:none;"></asp:Label>
                                        <a href="<%= Page.ResolveClientUrl("~/Checklist/Checklist.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                            <span>
                                                <i class="la la-arrow-left"></i>
                                                <span>Back</span>
                                            </span>
                                        </a>
                                        <div class="btn-group">

                                            <asp:Button ID="btnSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Style="margin-right: 20px;" ValidationGroup="validateTicket" OnClick="btnSave_Click" Text="Save" />

                                        </div>
                                    </div>

                                </div>
                            </div>

                            <div class="m-portlet__body" style="padding: 0.4rem 2.2rem;">
                                <!--begin: Form Body -->
                                <div class="m-portlet__body" style="padding: 0.3rem 2.2rem;">
                                    <div class="form-group m-form__group row" style="padding-left: 1%;">
                                        <label class="col-xl-3 col-lg-2 form-control-label">Checklist Name :</label>
                                        <div class="col-xl-4 col-lg-4">
                                            <asp:TextBox ID="txtChklist" runat="server" class="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtChklist" Visible="true" Display="Dynamic"
                                                ValidationGroup="validateTicket" ForeColor="Red" ErrorMessage="Please enter Checklist name"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="form-group m-form__group row" style="padding-left: 1%;">
                                        <label class="col-xl-3 col-lg-2 col-form-label"><span style="color: red;">*</span> Department Name :</label>
                                        <div class="col-xl-4 col-lg-4">
                                            <asp:DropDownList ID="ddlDept" class="form-control m-input" runat="server"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlDept" Visible="true" Display="Dynamic"
                                                ValidationGroup="validateTicket" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Department"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="form-group row" style="background-color: #00c5dc;">
                                        <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Select Chaecklist Details</label>
                                    </div>

                                    <div class="col-xl-5 col-lg-5">
                                        <asp:CheckBox ID="ChkApproval" runat="server" />
                                        <label class="col-xl-6 col-lg-6 col-form-label">Approval Required</label>
                                    </div>

                                    <div class="form-group m-form__group row" style="padding-left: 1%;">
                                        <label class="col-1 col-form-label">Expiry :</label>
                                        <div class="col-4">
                                            <span class="m-switch m-switch--icon m-switch--success">
                                                <label>
                                                    <input id="ChkExpiry" type="checkbox" checked="checked" name="" runat="server" />
                                                    <span></span>
                                                </label>
                                            </span>
                                        </div>
                                        <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Expiry Time (in hours) :</label>
                                        <div class="col-xl-2 col-lg-2">
                                            <asp:DropDownList ID="ddlExpirytime" class="form-control m-input" runat="server">
                                                <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                <asp:ListItem>8</asp:ListItem>
                                                <asp:ListItem>9</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem>11</asp:ListItem>
                                                <asp:ListItem>12</asp:ListItem>
                                                <asp:ListItem>13</asp:ListItem>
                                                <asp:ListItem>14</asp:ListItem>
                                                <asp:ListItem>15</asp:ListItem>
                                                <asp:ListItem>16</asp:ListItem>
                                                <asp:ListItem>17</asp:ListItem>
                                                <asp:ListItem>18</asp:ListItem>
                                                <asp:ListItem>19</asp:ListItem>
                                                <asp:ListItem>20</asp:ListItem>
                                                <asp:ListItem>21</asp:ListItem>
                                                <asp:ListItem>22</asp:ListItem>
                                                <asp:ListItem>23</asp:ListItem>
                                                <asp:ListItem>24</asp:ListItem>


                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlExpirytime" Visible="true" Display="Dynamic"
                                                ValidationGroup="validateTicket" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Expiry time"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="col-xl-5 col-lg-5">
                                        <asp:CheckBox ID="ChkIS" runat="server" />
                                        <label class="col-xl-6 col-lg-6 col-form-label">Scheduled Checklist</label>
                                    </div>

                                    <div class="form-group m-form__group row" style="padding-left: 1%;">
                                        <label class="col-xl-2 col-lg-2 form-control-label">Schedule Date :</label>
                                        <div class="col-xl-3 col-lg-3">

                                            <div class="input-group date">
                                                <asp:TextBox ID="dtSchdate" runat="server" autocomplete="off" class="form-control m-input datetimepicker" placeholder="Select date & time"></asp:TextBox>
                                                <div class="input-group-append">
                                                    <span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
                                                </div>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="dtSchdate" Visible="true" Display="Dynamic"
                                                    ValidationGroup="validateTicket" ForeColor="Red" ErrorMessage="Please enter Checklist Schedule date"></asp:RequiredFieldValidator>
                                            </div>
                                            <span id="error_startDate" class="text-danger small"></span>
                                        </div>
                                        <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Frequency :</label>
                                        <div class="col-xl-3 col-lg-3">
                                            <asp:DropDownList ID="ddlFrequency" class="form-control m-input" runat="server">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">Daily</asp:ListItem>
                                                <asp:ListItem Value="2">Weekly</asp:ListItem>
                                                <asp:ListItem Value="3">Monthly</asp:ListItem>

                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlFrequency" Visible="true" Display="Dynamic"
                                                ValidationGroup="validateTicket" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Frequency"></asp:RequiredFieldValidator>
                                        </div>

                                    </div>

                                    <div class="form-group m-form__group row" style="padding-left: 1%;">
                                        <label class="col-xl-2 col-lg-2 form-control-label">Start time :</label>
                                        <div class="col-xl-3 col-lg-3">
                                            <asp:TextBox ID="txtStarttime" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                        <label class="col-xl-2 col-lg-2 form-control-label">End time :</label>
                                        <div class="col-xl-3 col-lg-3">
                                            <asp:TextBox ID="txtEndtime" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group m-form__group row" style="padding-left: 1%;">
                                        <label class="col-xl-3 col-lg-3 form-control-label">Custom Frequency (in Day's)</label>
                                        <div class="col-xl-3 col-lg-3">
                                            <asp:TextBox ID="txtCustFrequency" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group row" style="background-color: #00c5dc;">
                                        <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Checklist Location Details</label>
                                    </div>


                                    <asp:UpdatePanel runat="server" style="width: 100%;">
                                        <ContentTemplate>
                                            <div class="form-group m-form__group row" style="padding-left: 1%;">
                                                <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Zone :</label>
                                                <div class="col-xl-3 col-lg-3">
                                                    <asp:DropDownList ID="ddlZone" class="form-control m-input" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlZone" Visible="true" Display="Dynamic"
                                                        ValidationGroup="validateTicket" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Zone"></asp:RequiredFieldValidator>
                                                </div>

                                                <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Location :</label>
                                                <div class="col-xl-3 col-lg-3">
                                                    <asp:DropDownList ID="ddlLocation" class="form-control m-input" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlLocation" Visible="true" Display="Dynamic"
                                                        ValidationGroup="validateTicket" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Location"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="form-group m-form__group row" style="padding-left: 1%;">
                                                <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Sub Location :</label>
                                                <div class="col-xl-3 col-lg-3">
                                                    <asp:DropDownList ID="ddlSublocation" class="form-control m-input" runat="server"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlSublocation" Visible="true" Display="Dynamic"
                                                        ValidationGroup="validateTicket" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Sub Loaction"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                    <br />

                                    <div class="form-group row" style="background-color: #00c5dc;">
                                        <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Checklist Point's</label>
                                    </div>
                                    <br />




                                    <div class="m-portlet__body">

                                        <!--begin: Datatable -->
                                        <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">
                                            <thead>

                                                <tr>
                                                    <th>Checklist Point</th>
                                                    <th>Answer Type</th>
                                                    <th>Created On</th>
                                                    <th>Action</th>
                                                </tr>

                                            </thead>

                                            <tbody>
                                                <%=bindChecklistPoint()%>
                                            </tbody>
                                        </table>
                                    </div>



                                    <div class="m-form__group form-group row">
                                        <div class="col-lg-4">
                                            <%-- <div data-repeater-create="" class="btn btn-accent m-btn m-btn--icon m-btn--pill m-btn--wide">--%>
                                            <span>
                                                <%--<i class="la la-plus"></i>--%>
                                                <%-- <span>Add Point</span>--%>
                                                <asp:Button ID="btnAddPoint" runat="server" class="btn btn-accent m-btn m-btn--icon m-btn--pill m-btn--wide" Text="+ Add Point" />
                                                <cc1:ModalPopupExtender ID="mpeChecklistPoint" runat="server" PopupControlID="pnlAddEditChecklstPoint" TargetControlID="btnAddPoint"
                                                    CancelControlID="btnCloseHeader" BackgroundCssClass="modalBackground">
                                                </cc1:ModalPopupExtender>
                                            </span>
                                            <%--  </div>--%>
                                        </div>

                                    </div>




                                </div>
                            </div>

                            <asp:Button ID="btnBindChklstPoint" runat="server" OnClick="btnBindChklstPoint_Click" Style="display: none" />

                            <asp:Panel ID="pnlAddEditChecklstPoint" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 80%;">
                                <div class="" id="add_sub_location" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                    <div class="modal-dialog" role="document" style="max-width: 79%;">
                                        <div class="modal-content">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>

                                                    <div class="modal-header">
                                                        <h5 class="modal-title" id="exampleModalLabel">Add Point</h5>
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader">
                                                            <span aria-hidden="true">&times;</span>
                                                        </button>
                                                    </div>
                                                    <div class="modal-body row">
                                                        <div class="col-md-8">
                                                            <div class="m-form__group">
                                                                <div class="m-form__control">
                                                                    <asp:TextBox ID="txtChklistpoints" runat="server" TextMode="MultiLine" class="form-control m-input autosize_textarea question_textarea" placeholder="Enter Checklist Point" Rows="1"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtChklistpoints" Visible="true" Display="Dynamic"
                                                                        ValidationGroup="validateChkPoint" ForeColor="Red" ErrorMessage="Please enter Checklist point"></asp:RequiredFieldValidator>

                                                                </div>
                                                            </div>
                                                            <div class="d-md-none m--margin-bottom-10"></div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="m-form__group">
                                                                <div class="m-form__control">
                                                                    <%--<select name="type" class="form-control m-input type_select">
                                                                        <option value="" selected="selected">Select Answer Type</option>
                                                                        <option value="YesNo">Yes/No</option>
                                                                        <option value="Text">Text</option>
                                                                    </select>--%>
                                                                    <asp:DropDownList ID="ddlChkPoint" runat="server" class="form-control m-input type_select">
                                                                        <asp:ListItem Value="0" Text="Select Answer Type"></asp:ListItem>
                                                                        <asp:ListItem Value="YesNo" Text="Yes/No"></asp:ListItem>
                                                                        <asp:ListItem Value="Text" Text="Text"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlChkPoint" Visible="true" Display="Dynamic"
                                                                        ValidationGroup="validateChkPoint" ForeColor="Red" InitialValue="0" ErrorMessage="Please select answer type"></asp:RequiredFieldValidator>

                                                                </div>
                                                            </div>
                                                            <div class="d-md-none m--margin-bottom-10"></div>
                                                        </div>
                                                        <%--<div class="col-md-1">
                                                            <div data-repeater-delete="" class="btn btn-danger m-btn m-btn--icon m-btn--icon-only">
                                                                <i class="la la-trash"></i>
                                                            </div>
                                                        </div>--%>
                                                    </div>
                                                    <asp:Label ID="lblChecklstPointErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>


                                                    <div class="modal-footer">
                                                        <asp:Button ID="btnCloseAddPoint" Text="Close" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnCloseAddPoint_Click" />
                                                        <asp:Button ID="btnAddPointSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" CausesValidation="true" ValidationGroup="validateChkPoint" OnClick="btnAddPointSave_Click" Text="Save" />

                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnAddPointSave" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <!-- End Modal -->
                            </asp:Panel>



                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
