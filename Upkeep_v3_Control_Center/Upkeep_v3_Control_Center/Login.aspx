
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Upkeep_v3_Control_Center.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
		<title>Login | UpKeep</title>
		<meta name="description" content="Latest updates and statistic charts">
		<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, shrink-to-fit=no">

		<!--begin::Web font -->
		<script src="https://ajax.googleapis.com/ajax/libs/webfont/1.6.16/webfont.js"></script>
		<script>
			WebFont.load({
            google: {"families":["Poppins:300,400,500,600,700","Roboto:300,400,500,600,700"]},
            active: function() {
                sessionStorage.fonts = true;
            }
          });
        </script>

		<!--end::Web font -->

		<!--begin:: Global Mandatory Vendors -->
		<link href="vendors/perfect-scrollbar/css/perfect-scrollbar.css" rel="stylesheet" type="text/css" />

		<!--end:: Global Mandatory Vendors -->

		<!--begin:: Global Optional Vendors -->
		<link href="vendors/tether/dist/css/tether.css" rel="stylesheet" type="text/css" />
		<link href="vendors/bootstrap-datepicker/dist/css/bootstrap-datepicker3.min.css" rel="stylesheet" type="text/css" />
		<link href="vendors/bootstrap-datetime-picker/css/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css" />
		<link href="vendors/bootstrap-timepicker/css/bootstrap-timepicker.min.css" rel="stylesheet" type="text/css" />
		<link href="vendors/bootstrap-daterangepicker/daterangepicker.css" rel="stylesheet" type="text/css" />
		<link href="vendors/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.css" rel="stylesheet" type="text/css" />
		<link href="vendors/bootstrap-switch/dist/css/bootstrap3/bootstrap-switch.css" rel="stylesheet" type="text/css" />
		<link href="vendors/bootstrap-select/dist/css/bootstrap-select.css" rel="stylesheet" type="text/css" />
		<link href="vendors/select2/dist/css/select2.css" rel="stylesheet" type="text/css" />
		<link href="vendors/nouislider/distribute/nouislider.css" rel="stylesheet" type="text/css" />
		<link href="vendors/owl.carousel/dist/assets/owl.carousel.css" rel="stylesheet" type="text/css" />
		<link href="vendors/owl.carousel/dist/assets/owl.theme.default.css" rel="stylesheet" type="text/css" />
		<link href="vendors/ion-rangeslider/css/ion.rangeSlider.css" rel="stylesheet" type="text/css" />
		<link href="vendors/ion-rangeslider/css/ion.rangeSlider.skinFlat.css" rel="stylesheet" type="text/css" />
		<link href="vendors/dropzone/dist/dropzone.css" rel="stylesheet" type="text/css" />
		<link href="vendors/summernote/dist/summernote.css" rel="stylesheet" type="text/css" />
		<link href="vendors/bootstrap-markdown/css/bootstrap-markdown.min.css" rel="stylesheet" type="text/css" />
		<link href="vendors/animate.css/animate.css" rel="stylesheet" type="text/css" />
		<link href="vendors/toastr/build/toastr.css" rel="stylesheet" type="text/css" />
		<link href="vendors/jstree/dist/themes/default/style.css" rel="stylesheet" type="text/css" />
		<link href="vendors/morris.js/morris.css" rel="stylesheet" type="text/css" />
		<link href="vendors/chartist/dist/chartist.min.css" rel="stylesheet" type="text/css" />
		<link href="vendors/sweetalert2/dist/sweetalert2.min.css" rel="stylesheet" type="text/css" />
		<link href="vendors/socicon/css/socicon.css" rel="stylesheet" type="text/css" />
		<link href="vendors/vendors/line-awesome/css/line-awesome.css" rel="stylesheet" type="text/css" />
		<link href="vendors/vendors/flaticon/css/flaticon.css" rel="stylesheet" type="text/css" />
		<link href="vendors/vendors/metronic/css/styles.css" rel="stylesheet" type="text/css" />
		<link href="vendors/vendors/fontawesome5/css/all.min.css" rel="stylesheet" type="text/css" />

		<!--end:: Global Optional Vendors -->

		<!--begin::Global Theme Styles -->
		<link href="assets/demo/base/style.bundle.css" rel="stylesheet" type="text/css" />

		<!--RTL version:<link href="assets/demo/base/style.bundle.rtl.css" rel="stylesheet" type="text/css" />-->

		<!--end::Global Theme Styles -->
		<link rel="shortcut icon" href="assets/demo/media/img/logo/favicon.ico" />
</head>
<body class="m--skin- m-header--fixed m-header--fixed-mobile m-aside-left--enabled m-aside-left--skin-dark m-aside-left--fixed m-aside-left--offcanvas m-footer--push m-aside--offcanvas-default">

		<!-- begin:: Page -->
		<div class="m-grid m-grid--hor m-grid--root m-page">
			<div class="m-grid__item m-grid__item--fluid m-grid m-grid--hor m-login m-login--signin m-login--2 m-login-2--skin-2" id="m_login" style="background-image: url(assets/app/media/img//bg/bg-3.jpg);">
				<div class="m-grid__item m-grid__item--fluid	m-login__wrapper">
					<div class="m-login__container">
						<div class="m-login__logo">
							<a href="#">
								<img src="assets/app/media/img/logos/efacilito_250.png" class="img-fluid">
							</a>
						</div>
						<div class="m-login__signin">
							<div class="m-login__head">
								<h3 class="m-login__title">eFacilito Login</h3>
							</div>
							<%--<form class="m-login__form m-form" action="">
								<div class="form-group m-form__group">
									<input class="form-control m-input" type="text" placeholder="Email" name="email" autocomplete="off">
								</div>
								<div class="form-group m-form__group">
									<input class="form-control m-input m-login__form-input--last" type="password" placeholder="Password" name="password">
								</div>
								<div class="row m-login__form-sub">
									<div class="col m--align-right m-login__form-right">
										<a href="forgot_password.html" class="m-link">Forget Password ?</a>
									</div>
								</div>
								<div class="m-login__form-action">
									<button id="m_login_signin_submit" class="btn btn-focus m-btn m-btn--pill m-btn--custom m-btn--air m-login__btn m-login__btn--primary">Login</button>
								</div>
							</form>--%>

                            <form id="login_form" class="m-login__form m-form" action="" runat="server">
										<div class="form-group m-form__group">
                                            <asp:TextBox ID="txtUserName" runat="server" class="form-control m-input" type="text" placeholder="UserName" autocomplete="off" ></asp:TextBox>
                                            <span id="error_txtUserName" class="small text-danger"></span>
										</div>
										<div class="form-group m-form__group">
                                            <asp:TextBox ID="txtPassword" runat="server" class="form-control m-input m-login__form-input--last" type="password" placeholder="Password" name="password" ></asp:TextBox>
                                            <span id="error_txtPassword" class="small text-danger"></span>
										</div>

										<!-- <div class="row m-login__form-sub">
											<div class="col m--align-left">
												<label class="m-checkbox m-checkbox--focus">
													<input type="checkbox" name="remember"> Remember me
													<span></span>
												</label>
											</div>
											<div class="col m--align-right">
												<a href="javascript:;" id="m_login_forget_password" class="m-link">Forget Password ?</a>
											</div>
										</div> -->
                                        <div>
                                            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                        </div>

										

										<div class="m-login__form-action">
										
                                        <asp:Button ID="m_login_signin_submit1" runat="server" class="btn btn-focus m-btn m-btn--pill m-btn--custom m-btn--air" OnClick="btnLogin_Click" Text="Submit" />
                                        </div>
									</form>


						</div>
					</div>
				</div>
			</div>
		</div>

		<!-- end:: Page -->

		<!--begin:: Global Mandatory Vendors -->
		<script src="vendors/jquery/dist/jquery.js" type="text/javascript"></script>
		<script src="vendors/popper.js/dist/umd/popper.js" type="text/javascript"></script>
		<script src="vendors/bootstrap/dist/js/bootstrap.min.js" type="text/javascript"></script>
		<script src="vendors/js-cookie/src/js.cookie.js" type="text/javascript"></script>
		<script src="vendors/moment/min/moment.min.js" type="text/javascript"></script>
		<script src="vendors/tooltip.js/dist/umd/tooltip.min.js" type="text/javascript"></script>
		<script src="vendors/perfect-scrollbar/dist/perfect-scrollbar.js" type="text/javascript"></script>
		<script src="vendors/wnumb/wNumb.js" type="text/javascript"></script>

		<!--end:: Global Mandatory Vendors -->

		<!--begin:: Global Optional Vendors -->
		<script src="vendors/jquery.repeater/src/lib.js" type="text/javascript"></script>
		<script src="vendors/jquery.repeater/src/jquery.input.js" type="text/javascript"></script>
		<script src="vendors/jquery.repeater/src/repeater.js" type="text/javascript"></script>
		<script src="vendors/jquery-form/dist/jquery.form.min.js" type="text/javascript"></script>
		<script src="vendors/block-ui/jquery.blockUI.js" type="text/javascript"></script>
		<script src="vendors/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js" type="text/javascript"></script>
		<script src="vendors/js/framework/components/plugins/forms/bootstrap-datepicker.init.js" type="text/javascript"></script>
		<script src="vendors/bootstrap-datetime-picker/js/bootstrap-datetimepicker.min.js" type="text/javascript"></script>
		<script src="vendors/bootstrap-timepicker/js/bootstrap-timepicker.min.js" type="text/javascript"></script>
		<script src="vendors/js/framework/components/plugins/forms/bootstrap-timepicker.init.js" type="text/javascript"></script>
		<script src="vendors/bootstrap-daterangepicker/daterangepicker.js" type="text/javascript"></script>
		<script src="vendors/js/framework/components/plugins/forms/bootstrap-daterangepicker.init.js" type="text/javascript"></script>
		<script src="vendors/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.js" type="text/javascript"></script>
		<script src="vendors/bootstrap-maxlength/src/bootstrap-maxlength.js" type="text/javascript"></script>
		<script src="vendors/bootstrap-switch/dist/js/bootstrap-switch.js" type="text/javascript"></script>
		<script src="vendors/js/framework/components/plugins/forms/bootstrap-switch.init.js" type="text/javascript"></script>
		<script src="vendors/vendors/bootstrap-multiselectsplitter/bootstrap-multiselectsplitter.min.js" type="text/javascript"></script>
		<script src="vendors/bootstrap-select/dist/js/bootstrap-select.js" type="text/javascript"></script>
		<script src="vendors/select2/dist/js/select2.full.js" type="text/javascript"></script>
		<script src="vendors/typeahead.js/dist/typeahead.bundle.js" type="text/javascript"></script>
		<script src="vendors/handlebars/dist/handlebars.js" type="text/javascript"></script>
		<script src="vendors/inputmask/dist/jquery.inputmask.bundle.js" type="text/javascript"></script>
		<script src="vendors/inputmask/dist/inputmask/inputmask.date.extensions.js" type="text/javascript"></script>
		<script src="vendors/inputmask/dist/inputmask/inputmask.numeric.extensions.js" type="text/javascript"></script>
		<script src="vendors/inputmask/dist/inputmask/inputmask.phone.extensions.js" type="text/javascript"></script>
		<script src="vendors/nouislider/distribute/nouislider.js" type="text/javascript"></script>
		<script src="vendors/owl.carousel/dist/owl.carousel.js" type="text/javascript"></script>
		<script src="vendors/autosize/dist/autosize.js" type="text/javascript"></script>
		<script src="vendors/clipboard/dist/clipboard.min.js" type="text/javascript"></script>
		<script src="vendors/ion-rangeslider/js/ion.rangeSlider.js" type="text/javascript"></script>
		<script src="vendors/dropzone/dist/dropzone.js" type="text/javascript"></script>
		<script src="vendors/summernote/dist/summernote.js" type="text/javascript"></script>
		<script src="vendors/markdown/lib/markdown.js" type="text/javascript"></script>
		<script src="vendors/bootstrap-markdown/js/bootstrap-markdown.js" type="text/javascript"></script>
		<script src="vendors/js/framework/components/plugins/forms/bootstrap-markdown.init.js" type="text/javascript"></script>
		<script src="vendors/jquery-validation/dist/jquery.validate.js" type="text/javascript"></script>
		<script src="vendors/jquery-validation/dist/additional-methods.js" type="text/javascript"></script>
		<script src="vendors/js/framework/components/plugins/forms/jquery-validation.init.js" type="text/javascript"></script>
		<script src="vendors/bootstrap-notify/bootstrap-notify.min.js" type="text/javascript"></script>
		<script src="vendors/js/framework/components/plugins/base/bootstrap-notify.init.js" type="text/javascript"></script>
		<script src="vendors/toastr/build/toastr.min.js" type="text/javascript"></script>
		<script src="vendors/jstree/dist/jstree.js" type="text/javascript"></script>
		<script src="vendors/raphael/raphael.js" type="text/javascript"></script>
		<script src="vendors/morris.js/morris.js" type="text/javascript"></script>
		<script src="vendors/chartist/dist/chartist.js" type="text/javascript"></script>
		<script src="vendors/chart.js/dist/Chart.bundle.js" type="text/javascript"></script>
		<script src="vendors/js/framework/components/plugins/charts/chart.init.js" type="text/javascript"></script>
		<script src="vendors/vendors/bootstrap-session-timeout/dist/bootstrap-session-timeout.min.js" type="text/javascript"></script>
		<script src="vendors/vendors/jquery-idletimer/idle-timer.min.js" type="text/javascript"></script>
		<script src="vendors/waypoints/lib/jquery.waypoints.js" type="text/javascript"></script>
		<script src="vendors/counterup/jquery.counterup.js" type="text/javascript"></script>
		<script src="vendors/es6-promise-polyfill/promise.min.js" type="text/javascript"></script>
		<script src="vendors/sweetalert2/dist/sweetalert2.min.js" type="text/javascript"></script>
		<script src="vendors/js/framework/components/plugins/base/sweetalert2.init.js" type="text/javascript"></script>

		<!--end:: Global Optional Vendors -->

		<!--begin::Global Theme Bundle -->
		<script src="assets/demo/base/scripts.bundle.js" type="text/javascript"></script>

		<!--end::Global Theme Bundle -->

	</body>
</html>
