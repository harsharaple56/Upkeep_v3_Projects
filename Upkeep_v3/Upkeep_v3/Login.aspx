<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Upkeep_v3.Login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--  --%>
    <meta charset="utf-8" />
    <title>eFacilito | Login Page</title>
    <meta name="description" content="Latest updates and statistic charts">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, shrink-to-fit=no">

    <!--begin::Web font -->
    <script src="https://ajax.googleapis.com/ajax/libs/webfont/1.6.16/webfont.js"></script>
    <script>
        WebFont.load({
            google: { "families": ["Poppins:300,400,500,600,700", "Roboto:300,400,500,600,700"] },
            active: function () {
                sessionStorage.fonts = true;
            }
        });
    </script>

    <!--end::Web font -->

    <!--begin::Global Theme Styles -->
    <link href="assets1/vendors/base/vendors.bundle.css" rel="stylesheet" type="text/css" />

    <!--RTL version:<link href="../../../assets/vendors/base/vendors.bundle.rtl.css" rel="stylesheet" type="text/css" />-->
    <link href="assets1/demo/default/base/style.bundle.css" rel="stylesheet" type="text/css" />

    <!--RTL version:<link href="../../../assets/demo/default/base/style.bundle.rtl.css" rel="stylesheet" type="text/css" />-->

    <!--end::Global Theme Styles -->
    <link rel="shortcut icon" href="assets1/demo/default/media/img/logo/favicon.ico" />
</head>

<!-- begin::Body -->
<body class="m--skin- m-header--fixed m-header--fixed-mobile m-aside-left--enabled m-aside-left--skin-dark m-aside-left--fixed m-aside-left--offcanvas m-footer--push m-aside--offcanvas-default">

    <!-- begin:: Page -->

    <div class="m-grid m-grid--hor m-grid--root m-page">
        <div class="m-grid__item m-grid__item--fluid m-grid m-grid--desktop m-grid--ver-desktop m-grid--hor-tablet-and-mobile m-login m-login--6 m-login--5" id="m_login">
            <div class="m-login__wrapper-1 m-portlet-full-height">
                <div class="m-login__wrapper-1-1">
                    <div class="m-login__contanier">
                        <div class="m-login__content">
                            <div class="m-login__logo">
                                <img style="width: 300px; height: 300px;" src="assets/app/media/img/logos/efacilito_250.png" />
                            </div>
                            <div class="m-login__title">
                                <h4>Manage all your Facilty Operations at a single instance. <b>Simple , Easy , Convenient </b></h4>
                            </div>

                            <div class="m-login__form-action">
                                <a href="http://efacilito.com/" class="btn btn-outline-focus m-btn--pill" target="_blank">Get An Account </a>
                                <%--<button type="button" id="m_login_signup" class="btn btn-outline-focus m-btn--pill">Get An Account</button>--%>
                            </div>
                        </div>
                    </div>
                    <div class="m-login__border">
                        <div></div>
                    </div>
                </div>
            </div>


            <div class="m-grid__item m-grid__item--fluid  m-grid__item--order-tablet-and-mobile-1  m-login__wrapper">

                <!--begin::Body-->
                <div class="m-login__body">

                    <!--begin::Signin-->
                    <div class="m-login__signin">
                        <div class="m-login__title">
                            <h3>Sign In To Your Account</h3>
                        </div>

                        <!--begin::Form-->
                        <form class="m-login__form m-form" runat="server">

                            <div style="text-align: center;">
                                <asp:Label ID="lblError" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
                            </div>
                            <br />
                            <div class="m-radio-inline" style="text-align: center;">
                                <label class="m-radio font-weight-bold">
                                    <asp:RadioButton ID="rdbEmployee" runat="server" GroupName="LoggingAs" Checked="true" />
                                    Employee<span></span>
                                </label>
                                <label class="m-radio font-weight-bold">
                                    <asp:RadioButton ID="rdbRetailer" runat="server" GroupName="LoggingAs" />
                                    Retailers<span></span>
                                </label>
                            </div>



                            <div class="form-group m-form__group">
                                <asp:TextBox ID="txtCompanyCode" class="form-control m-input" AutoPostBack="true" AutoComplete="off" placeholder="Company Code" name="company" OnTextChanged="txtCompanyCode_TextChanged" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCompany" runat="server" ControlToValidate="txtCompanyCode" Display="Dynamic" ForeColor="Red" ErrorMessage="Please enter your company code"
                                    ValidationGroup="login"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group m-form__group">
                                <asp:TextBox ID="txtUsername" class="form-control m-input" ReadOnly="true" AutoComplete="off" placeholder="Username" name="email" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" Display="Dynamic" ForeColor="Red"
                                    ErrorMessage="Please enter username" ValidationGroup="login"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group m-form__group">
                                <asp:TextBox ID="txtPassword" class="form-control m-input m-login__form-input--last" AutoComplete="off" ReadOnly="true" type="password" placeholder="Password" name="password" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red"
                                    ErrorMessage="Please enter password" ValidationGroup="login"></asp:RequiredFieldValidator>
                            </div>


                            <!--end::Form-->

                            <!--begin::Action-->
                            <div class="m-login__action">
                                <a href="#" class="m-link">
                                    <span>Forgot Password ?</span>
                                </a>
                                <a href="#">
                                    <asp:Button ID="btnLogin" runat="server" class="btn btn-focus m-btn m-btn--pill m-btn--custom m-btn--air" ValidationGroup="login"
                                        OnClick="btnLogin_Click" Text=" Sign In"></asp:Button>
                                </a>
                            </div>
                            <div class="col m--align-right">
                                Version No:
                                <asp:Label ID="lblVersion" Text="1.0" runat="server"></asp:Label>
                            </div>

                        </form>
                        <!--end::Action-->

                        <!--begin::Divider-->

                        <!--end::Divider-->

                        <!--begin::Options-->


                        <!--end::Options-->
                    </div>

                    <!--end::Signin-->
                </div>

                <!--end::Body-->
            </div>
        </div>
    </div>

    <!-- end:: Page -->

    <!--begin::Global Theme Bundle -->
    <script src="assets1/vendors/base/vendors.bundle.js" type="text/javascript"></script>
    <script src="assets1/demo/default/base/scripts.bundle.js" type="text/javascript"></script>

    <!--end::Global Theme Bundle -->

    <!--begin::Page Scripts -->
    <script src="assets1/snippets/custom/pages/user/login.js" type="text/javascript"></script>

    <!--end::Page Scripts -->
</body>

<!-- end::Body -->
</html>
