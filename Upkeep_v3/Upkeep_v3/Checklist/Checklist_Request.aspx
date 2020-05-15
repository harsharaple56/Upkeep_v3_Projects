<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Checklist_Request.aspx.cs" Inherits="Upkeep_v3.Checklist.Checklist_Request" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets1/demo/default/custom/crud/forms/widgets/bootstrap-datetimepicker.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets1/demo/default/custom/crud/forms/widgets/bootstrap-timepicker.js") %>" type="text/javascript"></script>
    <script>
        $(document).ready(function () {
            BootstrapTimepicker.init()

        });

        var BootstrapTimepicker = {
            init: function () {
                //$("#m_timepicker_1, #m_timepicker_1_modal").timepicker(),
                //    $("#m_timepicker_2, #m_timepicker_2_modal").timepicker(
                //        { minuteStep: 1, defaultTime: "", showSeconds: !0, showMeridian: !1, snapToStep: !0 }),
                //    $("#m_timepicker_3, #m_timepicker_3_modal").timepicker(
                //        { defaultTime: "11:45:20 AM", minuteStep: 1, showSeconds: !0, showMeridian: !0 }),
                //    $("#m_timepicker_4, #m_timepicker_4_modal").timepicker(
                //        { defaultTime: "10:30:20 AM", minuteStep: 1, showSeconds: !0, showMeridian: !0 }),
                    $("#ContentPlaceHolder1_txtStartTime").timepicker(
                    { minuteStep: 1, showSeconds: !1, showMeridian: 1, snapToStep: !0 }),

                 $("#ContentPlaceHolder1_txtScheduleDate").datetimepicker(
                { format: "dd/mm/yyyy", todayHighlight: !0, autoclose: !0, startView: 2, minView: 2, forceParse: 0, pickerPosition: "bottom-left" })
           
            }
        };
    </script>

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <form class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmChkList">
                            <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

                            <div class="m-portlet__head">
                                <div class="m-portlet__head-progress">

                                    <!-- here can place a progress bar-->
                                </div>
                                <div class="m-portlet__head-wrapper">
                                    <div class="m-portlet__head-caption">
                                        <div class="m-portlet__head-title">
                                            <h3 class="m-portlet__head-text">Checklist Request
                                            </h3>
                                        </div>
                                    </div>

                                    <div class="m-portlet__head-tools">
                                        <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
                                        <a href="<%= Page.ResolveClientUrl("~/Checklist/MyChecklist.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                            <span>
                                                <i class="la la-arrow-left"></i>
                                                <span>Back</span>
                                            </span>
                                        </a>
                                        <div class="btn-group">

                                            <asp:Button ID="btnSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Style="margin-right: 20px;" OnClick="btnSave_Click" ValidationGroup="validateTicket" Text="Save" />

                                        </div>
                                    </div>

                                </div>
                            </div>

                            <div class="m-portlet__body" style="padding: 0.4rem 2.2rem;">
                                <!--begin: Form Body -->
                                <div class="m-portlet__body" style="padding: 0.3rem 2.2rem;">

                                    <div class="form-group m-form__group row" style="padding-left: 1%;">
                                        <label class="col-xl-2 col-lg-2 form-control-label">Schedule Date :</label>
                                        <div class="col-xl-3 col-lg-3">
                                            <div class="input-group date">
                                                <input type="text" class="form-control m-input" runat="server" placeholder="Select date" id="txtScheduleDate" />
                                                <%--<asp:TextBox ID="TextBox1" runat="server" class="form-control m-input datetimepicker" placeholder="Select Date"></asp:TextBox>--%>
                                                <div class="input-group-append">
                                                    <span class="input-group-text">
                                                        <i class="la la-calendar glyphicon-th"></i>
                                                    </span>
                                                </div>
                                            </div>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="m_datetimepicker_6" Visible="true" Display="Dynamic"
                                        ValidationGroup="validateTicket" ForeColor="Red" ErrorMessage="Please enter Checklist Schedule date"></asp:RequiredFieldValidator>
                                            --%>
                                            <span id="error_startDate" class="text-danger small"></span>
                                        </div>
                                    </div>


                                    <%-- <div class="col-lg-4 col-md-9 col-sm-12">
                                        <div class="input-group date">
                                           <asp:TextBox ID="m_datetimepicker_6" runat="server" class="form-control m-input datetimepicker" placeholder="Select Date"></asp:TextBox>
                                            <div class="input-group-append">
                                                <span class="input-group-text">
                                                    <i class="la la-calendar glyphicon-th"></i>
                                                </span>
                                            </div>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="m_datetimepicker_6" Visible="true" Display="Dynamic"
                                        ValidationGroup="validateTicket" ForeColor="Red" ErrorMessage="Please enter Checklist Schedule date"></asp:RequiredFieldValidator>
                                            
                                    </div>--%>

                                    <asp:UpdatePanel runat="server" style="width: 100%;">
                                        <ContentTemplate>
                                            <div class="form-group m-form__group row" style="padding-left: 1%;">
                                                <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Zone :</label>
                                                <div class="col-xl-3 col-lg-3">
                                                    <asp:DropDownList ID="ddlZone" class="form-control m-input" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlZone" Visible="true" Display="Dynamic"
                                                        ValidationGroup="validateTicket" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Zone"></asp:RequiredFieldValidator>
                                                </div>

                                                <label class="col-xl-2 col-lg-2 col-form-label" style="text-align: right;"><span style="color: red;">*</span> Location :</label>
                                                <div class="col-xl-3 col-lg-3">
                                                    <asp:DropDownList ID="ddlLocation" class="form-control m-input" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlLocation" Visible="true" Display="Dynamic"
                                                        ValidationGroup="validateTicket" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Location"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="form-group m-form__group row" style="padding-left: 1%;">
                                                <label class="col-xl-2 col-lg-2 col-form-label"><%--<span style="color: red;">*</span>--%> Sub Location :</label>
                                                <div class="col-xl-3 col-lg-3">
                                                    <asp:DropDownList ID="ddlSublocation" class="form-control m-input" runat="server"></asp:DropDownList>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlSublocation" Visible="true" Display="Dynamic"
                                                        ValidationGroup="validateTicket" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Sub Loaction"></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </div>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                    <div class="form-group m-form__group row" style="padding-left: 1%;">
                                        <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Department :</label>
                                        <div class="col-xl-3 col-lg-3">
                                            <asp:DropDownList ID="ddlDept" class="form-control m-input" runat="server"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlDept" Visible="true" Display="Dynamic"
                                                ValidationGroup="validateTicket" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Department"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="form-group m-form__group row" style="padding-left: 1%;">
                                        <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Checklist Name :</label>
                                        <div class="col-xl-3 col-lg-3">
                                            <asp:DropDownList ID="ddlChecklist" class="form-control m-input" runat="server"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlChecklist" Visible="true" Display="Dynamic"
                                                ValidationGroup="validateTicket" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Checklist"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="form-group m-form__group row" style="padding-left: 1%;">
                                        <label class="col-form-label col-lg-2 col-sm-12">Start Time :</label>
                                        <div class="input-group timepicker col-xl-3 col-lg-3">
                                            <%--<input class="form-control m-input" id="m_timepicker_1_validate" readonly="true" placeholder="Select time" type="text" />--%>
                                            <input class="form-control m-input" id="txtStartTime" runat="server" readonly="true" placeholder="Select time" type="text" />
                                            <div class="input-group-append">
                                                <span class="input-group-text"><i class="la la-clock-o"></i></span>
                                            </div>
                                        </div>
                                    </div>




                                    <br />


                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
