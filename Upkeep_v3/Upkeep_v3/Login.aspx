<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Upkeep_v3.Login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--  --%>
    <meta charset="utf-8" />
    <title>eFacilito | Login Page</title>
    <meta name="description" content="Latest updates and statistic charts" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, shrink-to-fit=no" />

    <style>
        #load {
            width: 100%;
            height: 100%;
            position: fixed;
            z-index: 99999999;
            background: url("../assets/app/media/img/misc/load.gif") no-repeat center center rgba(0,0,0,0.25)
        }
    </style>

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
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

    <script type="text/javascript">

        //var path = "airbrake.json";
        //var configurationBuilder = new ConfigurationBuilder()
        //    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
        //    .AddJsonFile(path)
        //    .Build();

        //var settings = configurationBuilder.AsEnumerable()
        //    .Where(setting => setting.Key.StartsWith("Airbrake"))
        //    .ToDictionary(setting => setting.Key, setting => setting.Value);

        //var airbrakeConfiguration = AirbrakeConfig.Load(settings);


        $(document).ready(function () {
            $("#load").hide();
            $("[id*=dvCompanyLogo]").hide();
            $("[id*=dvLogin]").hide();
            $("[id*=dvForgot]").hide();
            $("[id*=dvOTP]").hide();
            $("[id*=dvChangePass]").hide();

            document.getElementById("dvLogin").className = "form-group m-form__group";
            document.getElementById("dvForgot").className = "form-group m-form__group";
            document.getElementById("dvOTP").className = "form-group m-form__group";
            document.getElementById("dvChangePass").className = "form-group m-form__group";
            $("[id*=dvCompanyCode]").show();

            $("[id*=btnLogin]").click(function () {
                $("#load").show();
                var txtUsername = $("[id*=txtUsername]").val();
                var txtPassword = $("[id*=txtPassword]").val();
                var LoggingAs = $("input[name='LoggingAs']:checked").val();
                var checkvalid = false;

                if (txtUsername != '' || txtPassword != '') {
                    if (txtUsername != '') {
                        checkvalid = true;
                    } else {
                        checkvalid = false;
                        $("#lblUserName").show();
                        $("#lblUserName").text("Please enter Username");
                        return false;
                    }

                    if (txtPassword != '') {
                        checkvalid = true;
                    } else {
                        checkvalid = false;
                        $("#lblPassword").show();
                        $("#lblPassword").text("Please enter Password");
                        return false;
                    }
                }
                else {
                    $("#lblUserName").show();
                    $("#lblUserName").text("Please enter Username");
                    $("#lblPassword").show();
                    $("#lblPassword").text("Please enter Password");
                    return false;
                }

                if (checkvalid) {
                    var dataString = {
                        'txtUsername': txtUsername,
                        'txtPassword': txtPassword,
                        'LoggingAs': LoggingAs,
                    };
                    var param = JSON.stringify(dataString);
                    $.ajax({
                        type: 'POST',
                        url: 'Login.aspx/LoginClick',
                        data: param,
                        contentType: 'application/json; charset=utf-8',
                        datatype: 'json',
                        success: function (response) {
                            if (response.d[1]) {
                                window.location.replace(response.d[1]);
                            }
                            else if (response.d[2]) {
                                window.location.replace(response.d[2]);
                            }
                            else if (response.d[3]) {
                                $("#lblError").show();
                                $("#lblError").text(response.d[3]);
                                $("[id*=txtUsername]").text('');
                                $("[id*=txtPassword]").text('');
                            }
                        },
                        error: function (xhr, status, error) {
                        }
                    });
                }
            });

            $('#txtUsername').keyup(function (e) {
                $("#lblUserName").text('');
                $("#lblUserName").hide();
                $("#lblError").text('');
                $("#lblError").hide();
            });

            $('#txtPassword').keyup(function (e) {
                $("#lblPassword").text('');
                $("#lblPassword").hide();
                $("#lblError").text('');
                $("#lblError").hide();
            });

            $("[id*=btnOTP]").click(function () {
                var txtOtp = $("[id*=txtOtp]").val();
                if (txtOtp != '') {
                    var dataString = {
                        'txtOtp': txtOtp,
                    };
                    var param = JSON.stringify(dataString);
                    $.ajax({
                        type: 'POST',
                        url: 'Login.aspx/CheckOTP',
                        data: param,
                        contentType: 'application/json; charset=utf-8',
                        datatype: 'json',
                        success: function (response) {
                            if (response.d[1]) {
                                document.getElementById("dvChangePass").className = "form-group m-form__group animated flipInX";
                                $("[id*=dvCompanyLogo]").hide();
                                $("#lblError").hide();
                                $("[id*=dvCompanyCode]").hide();
                                $("[id*=dvLogin]").hide();
                                $("[id*=dvForgot]").hide();
                                $("[id*=dvOTP]").hide();
                                $("[id*=dvChangePass]").show();
                            }
                            else if (response.d[2]) {
                                $("#lblError").show();
                                $("#lblError").text(response.d[2]);
                            }
                        },
                        error: function (xhr, status, error) {
                        }
                    });
                } else {
                    $("#lblOTPError").text("Please enter OTP.");
                }
            });

            $("[id*=btnChangePass]").click(function () {
                var txtPass = $("[id*=TxtPass]").val();
                var txtconfipass = $("[id*=TxtConfirmPassword]").val();
                if (txtPass != '') {
                    if (txtconfipass == '') {

                        var dataString = {
                            'txtPass': txtPass,
                            'txtconfipass': txtconfipass,
                        };
                        var param = JSON.stringify(dataString);
                        $.ajax({
                            type: 'POST',
                            url: 'Login.aspx/ChangePassword',
                            data: param,
                            contentType: 'application/json; charset=utf-8',
                            datatype: 'json',
                            success: function (response) {
                                if (response.d[1]) {
                                    location.reload();
                                }
                                else if (response.d[2]) {
                                    $("#lblError").show();
                                    $("#lblError").text(response.d[2]);
                                }
                                else if (response.d[3]) {
                                    $("#lblError").show();
                                    $("#lblError").text(response.d[3]);
                                }
                                else if (response.d[4]) {
                                    $("#lblError").show();
                                    $("#lblError").text(response.d[4]);
                                }
                            },
                            error: function (xhr, status, error) {
                            }
                        });
                    } else {
                        $("#lblConPassError").text('Please enter confirm password.');
                    }
                }
                else {
                    $("#lblPassError").text('Please enter Password.');
                }
            });

            $("[id*=btnSubmit]").click(function () {
                $("#login_title").hide();
                var txtEmail = $("[id*=txtEmail]").val();
                if (txtEmail != '') {
                    var rdb = $("input[name='LoggingAs']:checked").val();
                    var dataString = {
                        'txtEmail': txtEmail,
                        'rdb': rdb,
                    };
                    var param = JSON.stringify(dataString);
                    $.ajax({
                        type: 'POST',
                        url: 'Login.aspx/ForgotPassword',
                        data: param,
                        contentType: 'application/json; charset=utf-8',
                        datatype: 'json',
                        success: function (response) {
                            if (response.d[1]) {
                                $("[id*=dvCompanyLogo]").hide();
                                $("#lblError").hide();
                                $("[id*=dvCompanyCode]").hide();
                                $("[id*=dvLogin]").hide();
                                $("[id*=dvForgot]").hide();
                                document.getElementById("dvOTP").className = "form-group m-form__group animated flipInX";
                                $("[id*=dvOTP]").show();
                            }
                            else if (response.d[2]) {
                                $("#lblError").show();
                                $("#lblError").text(response.d[2]);
                            }
                            else if (response.d[3]) {
                                $("#lblError").show();
                                $("#lblError").text(response.d[3]);
                            } else if (response.d[4]) {
                                $("#lblError").show();
                                $("#lblError").text(response.d[4]);
                            } else if (response.d[5]) {
                                $("#lblError").show();
                                $("#lblError").text(response.d[5]);
                            } else if (response.d[6]) {
                                $("#lblError").show();
                                $("#lblError").text(response.d[6]);
                            } else if (response.d[7]) {
                                $("#lblError").show();
                                $("#lblError").text(response.d[7]);
                            } else if (response.d[8]) {
                                $("#lblError").show();
                                $("#lblError").text(response.d[8]);
                            } else if (response.d[9]) {
                                $("#lblError").show();
                                $("#lblError").text(response.d[9]);
                            }
                        },
                        error: function (xhr, status, error) {
                        }
                    });
                } else {
                    $("#lblEmailError").text("Please enter your email to Recieve Password");
                }
            });

            $("[id*=btnNext]").click(function () {
                var companycode = $("[id*=txtCompanyCode]").val();
                if (companycode != '') {
                    var dataString = {
                        'companycode': companycode,
                    };
                    var param = JSON.stringify(dataString);
                    $.ajax({
                        type: 'POST',
                        url: 'Login.aspx/VerifiedCompanyCode',
                        data: param,
                        contentType: 'application/json; charset=utf-8',
                        datatype: 'json',
                        success: function (response) {
                            if (response.d[1]) {
                                document.getElementById("dvLogin").className = "form-group m-form__group animated flipInX";
                                $("[id*=dvCompanyLogo]").show();
                                $("#lblError").hide();
                                $("#imgCompany_Logo").attr("src", response.d[1]);
                                $("[id*=dvCompanyCode]").hide();
                                $("[id*=dvLogin]").show();
                                $("[id*=rdbEmployee]").prop("checked", true);
                            }
                            else if (response.d[2]) {
                                $("#lblError").show();
                                $("#lblError").text(response.d[2]);
                            }
                            else if (response.d[3]) {
                                $("#lblError").show();
                                $("#lblError").text(response.d[3]);
                            } else if (response.d[4]) {
                                $("#lblError").show();
                                $("#lblError").text(response.d[4]);
                            }
                        },
                        error: function (xhr, status, error) {
                        }
                    });
                } else {
                    $("#lblCCError").text("Please enter Company Code.");
                }
            });

            $("[id*=lnk_forgot]").click(function () {
                document.getElementById("dvForgot").className = "form-group m-form__group animated flipInX";
                $("[id*=login_title]").hide();
                $("[id*=dvLogin]").hide();
                $("[id*=dvForgot]").show();
                $("[id*=rdb_Employee]").prop("checked", true);
            });

            $('#txtCompanyCode').keypress(function (e) {
                $("#lblCCError").text('');
                var key = e.which;
                if (key == 13)  // the enter key code
                {
                    $("[id*=btnNext]").click();
                    return false;
                }
            });

            $('#TxtPass').keyup(function (e) {
                var key = e.which;
                if (key == 13)  // the enter key code
                {
                    return false;
                }
            });

            $('#TxtConfirmPassword').keyup(function (e) {
                $("#lblPassError").text('');
                $("#lblConPassError").text('');

                var txtPass = $("[id*=TxtPass]").val();
                var txtconfipass = $("[id*=TxtConfirmPassword]").val();

                if (txtPass == txtconfipass) {
                    $("#lblError").text('');
                    $("#lblError").hide();
                    var key = e.which;
                    if (key == 13)  // the enter key code
                    {
                        $("[id*=btnChangePass]").click();
                        return false;
                    }
                } else {
                    $("#lblError").show();
                    $("#lblError").text('Password & Confirm Password must be same.');
                }
            });

            $('#txtOtp').keypress(function (e) {

                var check = false;
                var key = e.which;
                var charCode = (key) ? key : e.keyCode;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                    check = false;
                }
                else {
                    check = true;
                }

                if (check) {
                    $("#lblOTPError").text('');
                    if (key == 13)  // the enter key code
                    {
                        $("[id*=btnOTP]").click();
                        return false;
                    }
                }
                else {
                    return false;
                }
            });

            $('#txtEmail').keypress(function (e) {
                $("#lblEmailError").text('');
                var key = e.which;
                if (key == 13)  // the enter key code
                {
                    var x = $('#txtEmail').val();
                    var atposition = x.indexOf("@");
                    var dotposition = x.lastIndexOf(".");
                    if (atposition < 1 || dotposition < atposition + 2 || dotposition + 2 >= x.length) {
                        $("#lblEmailError").text("Please enter valid email.");
                        return false;
                    }
                    else {
                        $("[id*=btnSubmit]").click();
                        return false;
                    }
                }
            });

            $('#txtUsername').keypress(function (e) {
                var key = e.which;
                if (key == 13)  // the enter key code
                {
                    $("[id*=btnLogin]").click();
                    return false;
                }
            });

            $('#txtPassword').keypress(function (e) {
                var key = e.which;
                if (key == 13)  // the enter key code
                {
                    $("[id*=btnLogin]").click();
                    return false;
                }
            });


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

    <div id="load"></div>

    <!-- begin:: Page -->
    <div class="m-grid m-grid--hor m-grid--root m-page">
        <div class="m-grid__item m-grid__item--fluid m-grid m-grid--desktop m-grid--ver-desktop m-grid--hor-tablet-and-mobile m-login m-login--6 m-login--5" id="m_login">
            <div class="m-login__wrapper-1 m-portlet-full-height">
                <div class="m-login__wrapper-1-1">
                    <div class="m-login__contanier">
                        <div class="m-login__content">

                            <div class="m-login__logo">
                                <img style="width: 265px; height: 265px;" src="assets/app/media/img/logos/efacilito_250.png" />
                            </div>

                            <div class="m-login__title" style="padding-top: 2rem !important;">
                                <h4>Manage all your Facilty Operations at a single instance. <b>Simple , Easy , Convenient </b></h4>
                            </div>

                            <div class="m-login__form-action">
                                <a href="https://efacilito.com/contact/" class="btn btn-outline-focus m-btn--pill" target="_blank">Buy eFacilito for your Organization</a>
                                <%--<button type="button" id="m_login_signup" class="btn btn-outline-focus m-btn--pill">Get An Account</button>--%>
                            </div>
                            <div class="m-login__logo">
                                <a href="https://play.google.com/store/apps/details?id=com.compelconsultancy.efacilito" target="_blank">
                                    <img style="width: 200px; height: 60px;" src="assets/app/media/img/logos/PlayStore_download.png" />
                                </a>
                                <a href="https://apps.apple.com/us/app/efacilito/id1520937169">
                                    <img style="width: 200px; height: 60px;" src="assets/app/media/img/logos/AppleStore_download.png" />
                                </a>
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
                    <div class="m-login__signin animated flipInX">
                        <div style="text-align: center; display: none" id="dvCompanyLogo" runat="server">
                            <img id="imgCompany_Logo" src="#" style="width: auto; max-height: 160px; max-width: 100%;" />
                        </div>
                        <br />
                        <div id="login_title" class="m-login__title" style="margin-bottom: 0rem !important;">
                            <h3>Sign In To Your Account</h3>
                        </div>

                        <!--begin::Form-->
                        <form class="m-login__form m-form " runat="server" style="margin: 0rem auto !important;">

                            <div style="text-align: center;">
                                <label id="lblError" style="font-weight: bold; color: Red;"></label>
                            </div>
                            <br />

                            <div class="form-group m-form__group  animated flipInX" id="dvCompanyCode" runat="server">
                                <input autocomplete="off" class="form-control m-input" type="text" id="txtCompanyCode" name="txtCompanyCode" style="height: 50px;" placeholder="Company Code" />
                                <center>  <label for="txtCompanyCode" id="lblCCError" style="color: Red;"></label></center>

                                <div class="m-login__action" style="margin-left: 32%;">
                                    <a>
                                        <asp:Button ID="btnNext" runat="server" OnClientClick="return false;" autopostback="false"
                                            class="btn btn-focus m-btn m-btn--pill m-btn--custom m-btn--air" ValidationGroup="CompanyCode"
                                            Text="Next"></asp:Button>
                                    </a>
                                </div>
                            </div>

                            <div class="form-group m-form__group" style="display: none;" id="dvLogin" runat="server">

                                <div class="m-radio-inline" style="text-align: center;">
                                    <span class="fa fa-user" style="font-size: 2rem;"></span>
                                    <label class="m-radio" style="margin-right: 60px;">
                                        <input id="rdbEmployee" type="radio" name="LoggingAs" value="1" checked="checked" />
                                        <b>Employee </b>

                                        <span></span>
                                    </label>

                                    <span class="fa fa-store" style="font-size: 2rem;"></span>
                                    <label class="m-radio">
                                        <input id="rdbRetailer" type="radio" name="LoggingAs" value="2" />
                                        <b>Retailers </b>

                                        <span></span>
                                    </label>
                                </div>


                                <div class="form-group m-form__group">
                                    <input autocomplete="off" class="form-control m-input" type="text" id="txtUsername" name="txtUsername" style="height: 50px;" placeholder="Username" />
                                    <center>  <label for="txtUsername" id="lblUserName" style="color: Red;display:none"></label></center>
                                </div>
                                <div class="form-group m-form__group">
                                    <input autocomplete="off" class="form-control m-input" type="password" id="txtPassword" name="txtPassword" style="height: 50px;" placeholder="Password" />
                                    <center>  <label for="txtPassword" id="lblPassword" style="color: Red;display:none"></label></center>
                                </div>


                                <!--end::Form-->

                                <!--begin::Action-->
                                <div class="m-login__action">
                                    <b>
                                        <a href="#" id="lnk_forgot" class="m-link">
                                            <span>Forgot Password ?</span>
                                        </a>
                                    </b>
                                    <a href="#">
                                        <asp:Button ID="btnLogin" runat="server" OnClientClick="return false;" autopostback="false"
                                            class="btn btn-focus m-btn m-btn--pill m-btn--custom m-btn--air" ValidationGroup="login"
                                            Text="Sign In"></asp:Button>
                                    </a>
                                </div>

                            </div>

                            <div class="form-group m-form__group" style="display: none;" id="dvForgot" runat="server">
                                <div class="m-radio-inline" style="text-align: center;">
                                    <span class="fa fa-user" style="font-size: 2rem;"></span>
                                    <label class="m-radio font-weight-bold" style="margin-right: 60px;">
                                        <asp:RadioButton ID="rdb_Employee" runat="server" GroupName="LoggingAs" Checked="true" />
                                        Employee<span></span>
                                    </label>
                                    <span class="fa fa-store" style="font-size: 2rem;"></span>
                                    <label class="m-radio font-weight-bold ">
                                        <asp:RadioButton ID="rdb_Retailer" runat="server" GroupName="LoggingAs" />
                                        Retailers<span></span>
                                    </label>
                                </div>


                                <input autocomplete="off" class="form-control m-input" type="text" id="txtEmail" name="txtEmail" style="height: 50px;" placeholder="Enter Your Email" />
                                <center><label for="txtEmail" id="lblEmailError" style="color: Red;"></label></center>


                                <div class="m-login__action">
                                    <b>
                                        <a href="<%= Page.ResolveClientUrl("~/Login.aspx") %>" class="m-link">
                                            <span>Back To Login</span>
                                        </a>

                                    </b>

                                    <a>
                                        <asp:Button ID="btnSubmit" runat="server" OnClientClick="return false;" autopostback="false" class="btn btn-focus m-btn m-btn--pill m-btn--custom m-btn--air" ValidationGroup="ForgotPassword"
                                            Text="Submit"></asp:Button>
                                    </a>
                                </div>
                            </div>

                            <div class="form-group m-form__group" style="display: none;" id="dvOTP" runat="server">

                                <input autocomplete="off" class="form-control m-input" type="text" id="txtOtp" name="txtOtp" style="height: 50px;" placeholder="Enter Your OTP Code." />
                                <center><label for="txtOtp" id="lblOTPError" style="color: Red;"></label></center>

                                <div class="m-login__action">

                                    <b>
                                        <a href="<%= Page.ResolveClientUrl("~/Login.aspx") %>" class="m-link">
                                            <span>Back To Login</span>
                                        </a>

                                    </b>

                                    <a>
                                        <asp:Button ID="btnOTP" runat="server" OnClientClick="return false;" autopostback="false" class="btn btn-focus m-btn m-btn--pill m-btn--custom m-btn--air" ValidationGroup="CompanyCode"
                                            Text="Next"></asp:Button>

                                    </a>
                                </div>
                            </div>
                            <div class="form-group m-form__group" style="display: none;" id="dvChangePass" runat="server">

                                <input autocomplete="off" class="form-control m-input" type="password" id="TxtPass" name="TxtPass" style="height: 50px;" placeholder="Password" />
                                <center><label for="TxtPass" id="lblPassError" style="color: Red;"></label></center>

                                <input autocomplete="off" class="form-control m-input" type="password" id="TxtConfirmPassword" name="TxtConfirmPassword" style="height: 50px;" placeholder="ConfirmPassword" />
                                <center><label for="TxtPass" id="lblConPassError" style="color: Red;"></label></center>

                                <div class="m-login__action">
                                    <b>
                                        <a href="<%= Page.ResolveClientUrl("~/Login.aspx") %>" class="m-link">
                                            <span>Back To Login</span>
                                        </a>
                                    </b>

                                    <a>
                                        <asp:Button ID="btnChangePass" runat="server" OnClientClick="return false;" autopostback="false" class="btn btn-focus m-btn m-btn--pill m-btn--custom m-btn--air" ValidationGroup="CompanyCode"
                                            Text="Change Password"></asp:Button>
                                    </a>
                                </div>
                            </div>
                            <div class="col m--align-right">
                                Version No:
                                <asp:Label ID="lblVersion" Text="1.0" runat="server"></asp:Label>
                            </div>

                        </form>
                        <!--end::Action-->

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
