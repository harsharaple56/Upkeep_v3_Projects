<%@ Page Language="C#" MasterPageFile="~/BlankMaster.Master" AutoEventWireup="true" CodeBehind="Create_CSM_Request_Public.aspx.cs" Inherits="Upkeep_v3.CSM.Create_CSM_Request_Public" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            width: 300px;
        }

        .CovidColorBoxGreen {
            width: 100%;
            height: 30px;
            margin: 5px;
            border: 1px solid rgba(0, 0, 0, .2);
            font-size: initial;
            font-weight: bolder;
            text-align: center;
            cursor: pointer;
            color: green;
        }

        .CovidColorBoxOrange {
            width: 100%;
            height: 30px;
            margin: 5px;
            border: 1px solid rgba(0, 0, 0, .2);
            font-size: initial;
            font-weight: bolder;
            text-align: center;
            cursor: pointer;
            color: orange;
        }

        .CovidColorBoxRed {
            width: 100%;
            height: 30px;
            margin: 5px;
            border: 1px solid rgba(0, 0, 0, .2);
            font-size: initial;
            font-weight: bolder;
            text-align: center;
            cursor: pointer;
            color: red;
        }

        .CovidColorCheckGreen {
            display: none;
        }

        .CovidColorCheckOrange {
            display: none;
        }

        .CovidColorCheckRed {
            display: none;
        }

        .CovidColorCheckGreen:checked + label {
            background-color: limegreen;
            color: white;
        }

        .CovidColorCheckOrange:checked + label {
            background-color: orange;
            color: white;
        }

        .CovidColorCheckRed:checked + label {
            background-color: red;
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
        <div class="col-md-12">

            <!--begin::Portlet-->
            <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                <%--<form class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmVMS" method="post">--%>
                <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
                <asp:HiddenField ID="hdnVMSQuestionData" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdnVMSQuestion" runat="server" ClientIDMode="Static" />
                <p id="info" style="display: none;"></p>
                <p id="infox" style="display: none;"></p>


                <div class="alert m-alert--default m-alert--icon" id="divAlertExpired" visible="false" runat="server" role="alert">
                    <div class="m-alert__icon">
                        <i class="la la-warning"></i>
                    </div>
                    <div class="m-alert__text">
                        <strong>Expired!</strong> This Request is Expired.
                    </div>
                </div>
                <div class="alert alert-warning m-alert--icon" id="divAlertOpen" visible="false" runat="server" role="alert">
                    <div class="m-alert__icon">
                        <i class="la la-warning"></i>
                    </div>
                    <div class="m-alert__text">
                        <strong>IN!</strong> This Request is Open.
                    </div>
                </div>
                <div class="alert alert-success m-alert--icon" id="divAlertClosed" visible="false" runat="server" role="alert">
                    <div class="m-alert__icon">
                        <i class="la la-warning"></i>
                    </div>
                    <div class="m-alert__text">
                        <strong>OUT!</strong> This Request is Closed.
                    </div>
                </div>
                <div class="alert alert-brand m-alert--icon" id="divAlertApply" visible="false" runat="server" role="alert">
                    <div class="m-alert__icon">
                        <i class="la la-warning"></i>
                    </div>
                    <div class="m-alert__text">
                        <strong>Apply!</strong> This Request is Applied.
                    </div>
                </div>
                <div class="alert alert-danger m-alert--icon" id="divAlertRejected" visible="false" runat="server" role="alert">
                    <div class="m-alert__icon">
                        <i class="la la-warning"></i>
                    </div>
                    <div class="m-alert__text">
                        <strong>Rejected!</strong> This Request is Rejected.
                    </div>
                </div>

                <div class="alert alert-danger" id="divError" visible="False" runat="server" role="alert">
                    <asp:Label ID="lblErrorMsg" Text="" runat="server"></asp:Label>

                </div>
                <div class="m--align-center" style="padding: 15px;">
                    <img id="Img_CompanyLogo" src="https://compelapps.in/Fetch_Logos/Phx_Palladium.PNG" style="width: auto; max-height: 100px; max-width: 100%;">
                </div>
                <div class="m--align-center" style="padding: 15px;">
                    <h4 class="m--font-primary font-weight-bold">
                        <asp:Label ID="lbl_Form_Name" runat="server"></asp:Label>
                    </h4>

                    <asp:Button ID="btnTest" Style="display: none;" runat="server" />
                    <cc1:ModalPopupExtender ID="mpeVMSRequestSaveSuccess" runat="server" PopupControlID="pnlVMSReqestSuccess" TargetControlID="btnTest"
                        CancelControlID="btnCloseQuestion2" BackgroundCssClass="modalBackground">
                    </cc1:ModalPopupExtender>

                </div>


                <div class="m-portlet__body" style="padding: 0rem 2.2rem;">
                    <div class="form-group m-form__group row" id="divTitle" runat="server">
                        <%--<label class="col-md-2 col-form-label font-weight-bold">Select Visitor form</label>
                        <div class="col-md-10">
                            <asp:DropDownList ID="ddlVMSTitle" class="form-control m-input" runat="server" OnSelectedIndexChanged="ddlVMSTitle_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlVMSTitle" Visible="true" Display="Dynamic"
                                ValidationGroup="validateVMS" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Visit Title"></asp:RequiredFieldValidator>
                        </div>--%>
                    </div>
                    <div id="divDesc" class="form-group row" runat="server">
                        <div class="col-xl-12 col-lg-9 col-form-label m--align-center">
                            <span id="SpanDesc" runat="server" class="form-control-label font-weight-bold"></span>
                        </div>
                    </div>
                </div>

                <br />

                <div class="m-form__heading" style="text-align: center;">
                    <h3 class="m-form__heading-title" style="line-height: 2.0; background: bisque; font-size: 1.2rem;">Questions</h3>
                </div>


                <br />
                <div class="m-demo" data-code-preview="true" data-code-html="true" data-code-js="false">
                    <div class="m-demo__preview">
                        <div class="m-stack m-stack--hor m-stack--general m-stack--demo" style="height: 400px">
                            <div class="m-stack__item">
                                <div class="m-stack__demo-item">Item 1</div>
                            </div>
                            <div class="m-stack__item">
                                <div class="m-stack__demo-item">Item 2</div>
                            </div>
                            <div class="m-stack__item">
                                <div class="m-stack__demo-item">Item 3</div>
                            </div>
                            <div class="m-stack__item">
                                <div class="m-stack__demo-item">Item 4</div>
                            </div>
                        </div>
                    </div>
                </div>

                <br />

                <div class="m-form__heading" style="text-align: center;">
                    <h3 class="m-form__heading-title" style="line-height: 2.0; background: bisque; font-size: 1.2rem;">Term & Conditions</h3>
                </div>

                <%--<div class="m-stack m-stack--ver m-stack--general m-stack--demo">
                    <div class="m-stack__item ">

                        <asp:Repeater ID="rptTermsCondition1" runat="server" ClientIDMode="Static">
                            <ItemTemplate>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                </div>--%>

                <asp:Label ID="lblErrorMsg2" Text="" runat="server" CssClass="col-xl-8 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
                <div class="m-stack m-stack--ver m-stack--general m-stack--demo">
                    <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                        <asp:Button ID="btnSave" runat="server" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill" ValidationGroup="validateVMS" OnClick="btnSave_Click" Text="Submit" />
                    </div>
                </div>
                <br />
              
            </div>

        </div>
    </div>

</asp:Content>

