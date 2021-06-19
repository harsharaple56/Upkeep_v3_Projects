<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Google_Authenticator.aspx.cs" Inherits="Upkeep_v3.Authentication.Google_Authenticator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="m-content">

        <div class="row" style="width: fit-content;">

            <div class="col-xl-12">

                <!--begin:: Ticketing Section-->
                <div class="m-portlet m-portlet--bordered-semi m-portlet--full-height  m-portlet--rounded-force">

                    <div class="m-portlet__body">
                        <div class="m-widget19">

                            <div class="m-widget1">
                                <div class="m-widget1__item">
                                    <div class="row m-row--no-padding align-items-center">


                                        <div class="col-md-12">
                                            <div class="col-md-4">
                                                <asp:Image ID="imgQrCode" runat="server" />
                                            </div>
                                            <div class="col-md-6">
                                                <div>
                                                    <span style="font-weight: bold; font-size: 14px;">Account Name:</span>
                                                </div>
                                                <div>
                                                    <asp:Label runat="server" ID="lblAccountName"></asp:Label>
                                                </div>

                                                <div>
                                                    <span style="font-weight: bold; font-size: 14px;">Secret Key:</span>
                                                </div>
                                                <div>
                                                    <asp:Label runat="server" ID="lblManualSetupCode"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <div class="col-md-12" style="margin-top: 2%">
                                            <div class="form-group col-md-4">
                                                <asp:TextBox runat="server" CssClass="form-control" ID="txtSecurityCode" MaxLength="50" ToolTip="Please enter security code you get on your authenticator application">  
                                                </asp:TextBox>
                                            </div>
                                            <asp:Button ID="btnValidate" OnClick="btnValidate_Click" CssClass="btn btn-primary" runat="server" Text="Validate" />
                                        </div>
                                        <h3>Result:</h3>
                                        <div class="alert alert-success col-md-12" runat="server" role="alert">
                                            <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>


                                        </div>
                                    </div>


                                </div>


                            </div>
                        </div>
                    </div>

                    <!--end:: Ticketing Section-->
                </div>
            </div>
        </div>
</asp:Content>
