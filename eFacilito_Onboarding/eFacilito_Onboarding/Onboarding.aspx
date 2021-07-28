﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Onboarding.aspx.cs" Inherits="Onboarding" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
    <title>eFacilito</title>
    <meta http-equiv="Content-Security-Policy" content="upgrade-insecure-requests" />
    <meta name="description" content="Latest updates and statistic charts" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, shrink-to-fit=no" />
    <meta name="author" content="" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE10" />


    <base href="" />

    <!--begin::Web font -->
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/webfont/1.6.16/webfont.js"></script>
    <script src="https://kit.fontawesome.com/3ac466fc6d.js" crossorigin="anonymous"></script>


    <script>
        WebFont.load({
            google: { "families": ["Poppins:300,400,500,600,700", "Roboto:300,400,500,600,700"] },
            active: function () {
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
    <link href="vendors/dropzone/dropzone.css" rel="stylesheet" type="text/css" />
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
    <link href="assets/custom/Dashboard.css" rel="stylesheet" type="text/css" />
    <%--<link href="assets/custom/icons.min.css" rel="stylesheet" type="text/css" />--%>

    <!--end:: Global Optional Vendors -->

    <!--begin::Global Theme Styles -->
    <link href="assets/demo/base/style.bundle.css" rel="stylesheet" type="text/css" />
    <%--<link href="assets1/demo/default/base/style.bundle.css" rel="stylesheet" type="text/css" />--%>

    <!--RTL version:<link href="assets/demo/base/style.bundle.rtl.css" rel="stylesheet" type="text/css" />-->

    <!--end::Global Theme Styles -->

    <!--begin::Page Vendors Styles -->
    <link href="assets/vendors/custom/fullcalendar/fullcalendar.bundle.css" rel="stylesheet" type="text/css" />
    <link href="assets/vendors/custom/datatables/datatables.bundle.css" rel="stylesheet" type="text/css" />
    <!--RTL version:<link href="assets/vendors/custom/fullcalendar/fullcalendar.bundle.rtl.css" rel="stylesheet" type="text/css" />-->

    <!--end::Page Vendors Styles -->
    <link rel="shortcut icon" href="assets1/demo/default/media/img/logo/favicon.ico" />

    <style>
        #load {
            width: 100%;
            height: 100%;
            position: fixed;
            z-index: 99999999;
            background: url("../assets/app/media/img/misc/load.gif") no-repeat center center rgba(0,0,0,0.25)
        }

    </style>














    



    <script>
        $(document).ready(function () {

            //$('#parentUL').find('li).each(function () {
            //    $(this).attr();
            //});

            $('ul a[href^="javascript:;"]').addClass(' m-menu__toggle');
            //Added by RC to show active menu
            //var location = window.location.href;
            //alert(location.pathname);
            //alert($('ul a[href^=".' + location.pathname + '"]').html());
            $('ul a[href^="' + location.pathname + '"]').parent().addClass('m-menu__item--active');
            $('ul a[href^="' + location.pathname + '"]').parent().parent().parent().removeAttr("style");
            $('ul a[href^="' + location.pathname + '"]').parent().parent().parent().parent().addClass('m-menu__item--open');
        });
        document.onreadystatechange = function () {
            var state = document.readyState
            if (state == 'complete') {
                document.getElementById('interactive');
            }
        }
    </script>

    <%--<style type="text/css">
       
        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
        }
        .modalPopup
        {
            background-color: #FFFFFF;
            width: 500px;
            border: 3px solid #0DA9D0;
            border-radius: 12px;
            padding: 0;
        }
        .modalPopup .header
        {
            background-color: #2FBDF1;
            height: 30px;
            color: White;
            line-height: 30px;
            text-align: center;
            font-weight: bold;
            border-top-left-radius: 6px;
            border-top-right-radius: 6px;
        }
        .modalPopup .body
        {
            padding: 10px;
            min-height: 50px;
            text-align: center;
            font-weight: bold;
        }
        .modalPopup .footer
        {
            padding: 6px;
        }
        .modalPopup .yes, .modalPopup .no
        {
            height: 23px;
            color: White;
            line-height: 23px;
            text-align: center;
            font-weight: bold;
            cursor: pointer;
            border-radius: 4px;
        }
        .modalPopup .yes
        {
            background-color: #2FBDF1;
            border: 1px solid #0DA9D0;
        }
        .modalPopup .no
        {
            background-color: #9F9F9F;
            border: 1px solid #5C5C5C;
        }
    </style>--%>

    <script type="text/javascript">
        function SessionExpireAlert(timeout) {
            var seconds = timeout / 1000;

            //document.getElementsByName("secondsIdle").innerHTML = seconds;
            document.getElementsByName("seconds").innerHTML = seconds; //Ajay

            setInterval(function () {
                seconds--;
                //document.getElementById("seconds").innerHTML = seconds;
                document.getElementById("secondsIdle").innerHTML = seconds; //Ajay

            }, 1000);
            setTimeout(function () {
                //Show Popup before 20 seconds of timeout.
                //$find("mpeTimeout").show();

                $("#MyPopup").modal({
                    backdrop: 'static',
                    keyboard: false
                });
                $("#MyPopup").modal("show");

            }, timeout - 120 * 1000);
            setTimeout(function () {
                window.location = "<%= Page.ResolveClientUrl("~/Login.aspx") %>";
            }, timeout);
        };
        function ResetSession() {
            //Redirect to refresh Session.
            window.location = window.location.href;
        }
    </script>

</head>
<body class="m-page--fluid m--skin- m-content--skin-light2 m-header--fixed m-header--fixed-mobile m-aside-left--enabled m-aside-left--skin-dark m-aside-left--fixed m-aside-left--offcanvas m-footer--push m-aside--offcanvas-default">


				<!-- END: Left Aside -->
				<div class="m-grid__item m-grid__item--fluid m-wrapper">

					<!-- END: Subheader -->
					<div class="m-content">

						<!--Begin::Main Portlet-->
						<div class="m-portlet m-portlet--full-height">

							<!--begin: Portlet Head-->
							<div class="m-portlet__head">
								<div class="m-portlet__head-caption">
									<div class="m-portlet__head-title">
										<h3 class="m-portlet__head-text">
											Form Wizard
										</h3>
									</div>
								</div>
								<div class="m-portlet__head-tools">
									<ul class="m-portlet__nav">
										<li class="m-portlet__nav-item">
											<a href="#" data-toggle="m-tooltip" class="m-portlet__nav-link m-portlet__nav-link--icon" data-direction="left" data-width="auto" title="" data-original-title="Get help with filling up this form">
												<i class="flaticon-info m--icon-font-size-lg3"></i>
											</a>
										</li>
									</ul>
								</div>
							</div>

							<!--end: Portlet Head-->

							<!--begin: Portlet Body-->
							<div class="m-portlet__body m-portlet__body--no-padding">

								<!--begin: Form Wizard-->
								<div class="m-wizard m-wizard--4 m-wizard--brand m-wizard--step-between" id="m_wizard">
									<div class="row m-row--no-padding">
										<div class="col-xl-3 col-lg-12 m--padding-top-20 m--padding-bottom-15">

											<!--begin: Form Wizard Head -->
											<div class="m-wizard__head">

												<!--begin: Form Wizard Nav -->
												<div class="m-wizard__nav">
													<div class="m-wizard__steps">
														<div class="m-wizard__step m-wizard__step--current" m-wizard-target="m_wizard_form_step_1">
															<div class="m-wizard__step-info">
																<a href="#" class="m-wizard__step-number">
																	<span><span>1</span></span>
																</a>
																<div class="m-wizard__step-label">
																	Account Setup
																</div>
																<div class="m-wizard__step-icon"><i class="la la-check"></i></div>
															</div>
														</div>
														<div class="m-wizard__step" m-wizard-target="m_wizard_form_step_2">
															<div class="m-wizard__step-info">
																<a href="#" class="m-wizard__step-number">
																	<span><span>2</span></span>
																</a>
																<div class="m-wizard__step-label">
																	Profile Setup
																</div>
																<div class="m-wizard__step-icon"><i class="la la-check"></i></div>
															</div>
														</div>
														<div class="m-wizard__step" m-wizard-target="m_wizard_form_step_3">
															<div class="m-wizard__step-info">
																<a href="#" class="m-wizard__step-number">
																	<span><span>3</span></span>
																</a>
																<div class="m-wizard__step-label">
																	Billing Setup
																</div>
																<div class="m-wizard__step-icon"><i class="la la-check"></i></div>
															</div>
														</div>
														<div class="m-wizard__step" m-wizard-target="m_wizard_form_step_4">
															<div class="m-wizard__step-info">
																<a href="#" class="m-wizard__step-number">
																	<span><span>4</span></span>
																</a>
																<div class="m-wizard__step-label">
																	Confirmation
																</div>
																<div class="m-wizard__step-icon"><i class="la la-check"></i></div>
															</div>
														</div>
													</div>
												</div>

												<!--end: Form Wizard Nav -->
											</div>

											<!--end: Form Wizard Head -->
										</div>
										<div class="col-xl-9 col-lg-12">

											<!--begin: Form Wizard Form-->
											<div class="m-wizard__form">

												<!--
							1) Use m-form--label-align-left class to alight the form input lables to the right
							2) Use m-form--state class to highlight input control borders on form validation
						-->
												<form class="m-form m-form--label-align-left- m-form--state-" id="m_form" novalidate="novalidate">

													<!--begin: Form Body -->
													<div class="m-portlet__body m-portlet__body--no-padding">

														<!--begin: Form Wizard Step 1-->
														<div class="m-wizard__form-step m-wizard__form-step--current" id="m_wizard_form_step_1">
															<div class="m-form__section m-form__section--first">
																<div class="m-form__heading">
																	<h3 class="m-form__heading-title">Client Details</h3>
																</div>
																<div class="form-group m-form__group row">
																	<label class="col-xl-3 col-lg-3 col-form-label">* Name:</label>
																	<div class="col-xl-9 col-lg-9">
																		<input type="text" name="name" class="form-control m-input" placeholder="" value="Nick Stone">
																		<span class="m-form__help">Please enter your first and last names</span>
																	</div>
																</div>
																<div class="form-group m-form__group row">
																	<label class="col-xl-3 col-lg-3 col-form-label">* Email:</label>
																	<div class="col-xl-9 col-lg-9">
																		<input type="email" name="email" class="form-control m-input" placeholder="" value="nick.stone@gmail.com">
																		<span class="m-form__help">We'll never share your email with anyone else</span>
																	</div>
																</div>
																<div class="form-group m-form__group row">
																	<label class="col-xl-3 col-lg-3 col-form-label">* Phone</label>
																	<div class="col-xl-9 col-lg-9">
																		<div class="input-group">
																			<div class="input-group-prepend"><span class="input-group-text"><i class="la la-phone"></i></span></div>
																			<input type="text" name="phone" class="form-control m-input" placeholder="" value="1-541-754-3010">
																		</div>
																		<span class="m-form__help">Enter your valid phone in US phone format. E.g: 1-541-754-3010</span>
																	</div>
																</div>
															</div>
															<div class="m-separator m-separator--dashed m-separator--lg"></div>
															<div class="m-form__section">
																<div class="m-form__heading">
																	<h3 class="m-form__heading-title">
																		Mailing Address
																		<i data-toggle="m-tooltip" data-width="auto" class="m-form__heading-help-icon flaticon-info" title="" data-original-title="Some help text goes here"></i>
																	</h3>
																</div>
																<div class="form-group m-form__group row">
																	<label class="col-xl-3 col-lg-3 col-form-label">* Address Line 1:</label>
																	<div class="col-xl-9 col-lg-9">
																		<input type="text" name="address1" class="form-control m-input" placeholder="" value="Headquarters 1120 N Street Sacramento 916-654-5266">
																		<span class="m-form__help">Street address, P.O. box, company name, c/o</span>
																	</div>
																</div>
																<div class="form-group m-form__group row">
																	<label class="col-xl-3 col-lg-3 col-form-label">Address Line 2:</label>
																	<div class="col-xl-9 col-lg-9">
																		<input type="text" name="address2" class="form-control m-input" placeholder="" value="P.O. Box 942873 Sacramento, CA 94273-0001">
																		<span class="m-form__help">Appartment, suite, unit, building, floor, etc</span>
																	</div>
																</div>
																<div class="form-group m-form__group row">
																	<label class="col-xl-3 col-lg-3 col-form-label">* City:</label>
																	<div class="col-xl-9 col-lg-9">
																		<input type="text" name="city" class="form-control m-input" placeholder="" value="Polo Alto">
																	</div>
																</div>
																<div class="form-group m-form__group row">
																	<label class="col-xl-3 col-lg-3 col-form-label">* State:</label>
																	<div class="col-xl-9 col-lg-9">
																		<input type="text" name="state" class="form-control m-input" placeholder="" value="California">
																	</div>
																</div>
																<div class="form-group m-form__group row">
																	<label class="col-xl-3 col-lg-3 col-form-label">* Country:</label>
																	<div class="col-xl-9 col-lg-9">
																		<select name="country" class="form-control m-input">
																			<option value="">Select</option>
																			<option value="AF">Afghanistan</option>
																			<option value="AX">Åland Islands</option>
																			<option value="AL">Albania</option>
																			<option value="DZ">Algeria</option>
																			<option value="AS">American Samoa</option>
																			<option value="AD">Andorra</option>
																			<option value="AO">Angola</option>
																			<option value="AI">Anguilla</option>
																			<option value="AQ">Antarctica</option>
																			<option value="AG">Antigua and Barbuda</option>
																			<option value="AR">Argentina</option>
																			<option value="AM">Armenia</option>
																			<option value="AW">Aruba</option>
																			<option value="AU">Australia</option>
																			<option value="AT">Austria</option>
																			<option value="AZ">Azerbaijan</option>
																			<option value="BS">Bahamas</option>
																			<option value="BH">Bahrain</option>
																			<option value="BD">Bangladesh</option>
																			<option value="BB">Barbados</option>
																			<option value="BY">Belarus</option>
																			<option value="BE">Belgium</option>
																			<option value="BZ">Belize</option>
																			<option value="BJ">Benin</option>
																			<option value="BM">Bermuda</option>
																			<option value="BT">Bhutan</option>
																			<option value="BO">Bolivia, Plurinational State of</option>
																			<option value="BQ">Bonaire, Sint Eustatius and Saba</option>
																			<option value="BA">Bosnia and Herzegovina</option>
																			<option value="BW">Botswana</option>
																			<option value="BV">Bouvet Island</option>
																			<option value="BR">Brazil</option>
																			<option value="IO">British Indian Ocean Territory</option>
																			<option value="BN">Brunei Darussalam</option>
																			<option value="BG">Bulgaria</option>
																			<option value="BF">Burkina Faso</option>
																			<option value="BI">Burundi</option>
																			<option value="KH">Cambodia</option>
																			<option value="CM">Cameroon</option>
																			<option value="CA">Canada</option>
																			<option value="CV">Cape Verde</option>
																			<option value="KY">Cayman Islands</option>
																			<option value="CF">Central African Republic</option>
																			<option value="TD">Chad</option>
																			<option value="CL">Chile</option>
																			<option value="CN">China</option>
																			<option value="CX">Christmas Island</option>
																			<option value="CC">Cocos (Keeling) Islands</option>
																			<option value="CO">Colombia</option>
																			<option value="KM">Comoros</option>
																			<option value="CG">Congo</option>
																			<option value="CD">Congo, the Democratic Republic of the</option>
																			<option value="CK">Cook Islands</option>
																			<option value="CR">Costa Rica</option>
																			<option value="CI">Côte d'Ivoire</option>
																			<option value="HR">Croatia</option>
																			<option value="CU">Cuba</option>
																			<option value="CW">Curaçao</option>
																			<option value="CY">Cyprus</option>
																			<option value="CZ">Czech Republic</option>
																			<option value="DK">Denmark</option>
																			<option value="DJ">Djibouti</option>
																			<option value="DM">Dominica</option>
																			<option value="DO">Dominican Republic</option>
																			<option value="EC">Ecuador</option>
																			<option value="EG">Egypt</option>
																			<option value="SV">El Salvador</option>
																			<option value="GQ">Equatorial Guinea</option>
																			<option value="ER">Eritrea</option>
																			<option value="EE">Estonia</option>
																			<option value="ET">Ethiopia</option>
																			<option value="FK">Falkland Islands (Malvinas)</option>
																			<option value="FO">Faroe Islands</option>
																			<option value="FJ">Fiji</option>
																			<option value="FI">Finland</option>
																			<option value="FR">France</option>
																			<option value="GF">French Guiana</option>
																			<option value="PF">French Polynesia</option>
																			<option value="TF">French Southern Territories</option>
																			<option value="GA">Gabon</option>
																			<option value="GM">Gambia</option>
																			<option value="GE">Georgia</option>
																			<option value="DE">Germany</option>
																			<option value="GH">Ghana</option>
																			<option value="GI">Gibraltar</option>
																			<option value="GR">Greece</option>
																			<option value="GL">Greenland</option>
																			<option value="GD">Grenada</option>
																			<option value="GP">Guadeloupe</option>
																			<option value="GU">Guam</option>
																			<option value="GT">Guatemala</option>
																			<option value="GG">Guernsey</option>
																			<option value="GN">Guinea</option>
																			<option value="GW">Guinea-Bissau</option>
																			<option value="GY">Guyana</option>
																			<option value="HT">Haiti</option>
																			<option value="HM">Heard Island and McDonald Islands</option>
																			<option value="VA">Holy See (Vatican City State)</option>
																			<option value="HN">Honduras</option>
																			<option value="HK">Hong Kong</option>
																			<option value="HU">Hungary</option>
																			<option value="IS">Iceland</option>
																			<option value="IN">India</option>
																			<option value="ID">Indonesia</option>
																			<option value="IR">Iran, Islamic Republic of</option>
																			<option value="IQ">Iraq</option>
																			<option value="IE">Ireland</option>
																			<option value="IM">Isle of Man</option>
																			<option value="IL">Israel</option>
																			<option value="IT">Italy</option>
																			<option value="JM">Jamaica</option>
																			<option value="JP">Japan</option>
																			<option value="JE">Jersey</option>
																			<option value="JO">Jordan</option>
																			<option value="KZ">Kazakhstan</option>
																			<option value="KE">Kenya</option>
																			<option value="KI">Kiribati</option>
																			<option value="KP">Korea, Democratic People's Republic of</option>
																			<option value="KR">Korea, Republic of</option>
																			<option value="KW">Kuwait</option>
																			<option value="KG">Kyrgyzstan</option>
																			<option value="LA">Lao People's Democratic Republic</option>
																			<option value="LV">Latvia</option>
																			<option value="LB">Lebanon</option>
																			<option value="LS">Lesotho</option>
																			<option value="LR">Liberia</option>
																			<option value="LY">Libya</option>
																			<option value="LI">Liechtenstein</option>
																			<option value="LT">Lithuania</option>
																			<option value="LU">Luxembourg</option>
																			<option value="MO">Macao</option>
																			<option value="MK">Macedonia, the former Yugoslav Republic of</option>
																			<option value="MG">Madagascar</option>
																			<option value="MW">Malawi</option>
																			<option value="MY">Malaysia</option>
																			<option value="MV">Maldives</option>
																			<option value="ML">Mali</option>
																			<option value="MT">Malta</option>
																			<option value="MH">Marshall Islands</option>
																			<option value="MQ">Martinique</option>
																			<option value="MR">Mauritania</option>
																			<option value="MU">Mauritius</option>
																			<option value="YT">Mayotte</option>
																			<option value="MX">Mexico</option>
																			<option value="FM">Micronesia, Federated States of</option>
																			<option value="MD">Moldova, Republic of</option>
																			<option value="MC">Monaco</option>
																			<option value="MN">Mongolia</option>
																			<option value="ME">Montenegro</option>
																			<option value="MS">Montserrat</option>
																			<option value="MA">Morocco</option>
																			<option value="MZ">Mozambique</option>
																			<option value="MM">Myanmar</option>
																			<option value="NA">Namibia</option>
																			<option value="NR">Nauru</option>
																			<option value="NP">Nepal</option>
																			<option value="NL">Netherlands</option>
																			<option value="NC">New Caledonia</option>
																			<option value="NZ">New Zealand</option>
																			<option value="NI">Nicaragua</option>
																			<option value="NE">Niger</option>
																			<option value="NG">Nigeria</option>
																			<option value="NU">Niue</option>
																			<option value="NF">Norfolk Island</option>
																			<option value="MP">Northern Mariana Islands</option>
																			<option value="NO">Norway</option>
																			<option value="OM">Oman</option>
																			<option value="PK">Pakistan</option>
																			<option value="PW">Palau</option>
																			<option value="PS">Palestinian Territory, Occupied</option>
																			<option value="PA">Panama</option>
																			<option value="PG">Papua New Guinea</option>
																			<option value="PY">Paraguay</option>
																			<option value="PE">Peru</option>
																			<option value="PH">Philippines</option>
																			<option value="PN">Pitcairn</option>
																			<option value="PL">Poland</option>
																			<option value="PT">Portugal</option>
																			<option value="PR">Puerto Rico</option>
																			<option value="QA">Qatar</option>
																			<option value="RE">Réunion</option>
																			<option value="RO">Romania</option>
																			<option value="RU">Russian Federation</option>
																			<option value="RW">Rwanda</option>
																			<option value="BL">Saint Barthélemy</option>
																			<option value="SH">Saint Helena, Ascension and Tristan da Cunha</option>
																			<option value="KN">Saint Kitts and Nevis</option>
																			<option value="LC">Saint Lucia</option>
																			<option value="MF">Saint Martin (French part)</option>
																			<option value="PM">Saint Pierre and Miquelon</option>
																			<option value="VC">Saint Vincent and the Grenadines</option>
																			<option value="WS">Samoa</option>
																			<option value="SM">San Marino</option>
																			<option value="ST">Sao Tome and Principe</option>
																			<option value="SA">Saudi Arabia</option>
																			<option value="SN">Senegal</option>
																			<option value="RS">Serbia</option>
																			<option value="SC">Seychelles</option>
																			<option value="SL">Sierra Leone</option>
																			<option value="SG">Singapore</option>
																			<option value="SX">Sint Maarten (Dutch part)</option>
																			<option value="SK">Slovakia</option>
																			<option value="SI">Slovenia</option>
																			<option value="SB">Solomon Islands</option>
																			<option value="SO">Somalia</option>
																			<option value="ZA">South Africa</option>
																			<option value="GS">South Georgia and the South Sandwich Islands</option>
																			<option value="SS">South Sudan</option>
																			<option value="ES">Spain</option>
																			<option value="LK">Sri Lanka</option>
																			<option value="SD">Sudan</option>
																			<option value="SR">Suriname</option>
																			<option value="SJ">Svalbard and Jan Mayen</option>
																			<option value="SZ">Swaziland</option>
																			<option value="SE">Sweden</option>
																			<option value="CH">Switzerland</option>
																			<option value="SY">Syrian Arab Republic</option>
																			<option value="TW">Taiwan, Province of China</option>
																			<option value="TJ">Tajikistan</option>
																			<option value="TZ">Tanzania, United Republic of</option>
																			<option value="TH">Thailand</option>
																			<option value="TL">Timor-Leste</option>
																			<option value="TG">Togo</option>
																			<option value="TK">Tokelau</option>
																			<option value="TO">Tonga</option>
																			<option value="TT">Trinidad and Tobago</option>
																			<option value="TN">Tunisia</option>
																			<option value="TR">Turkey</option>
																			<option value="TM">Turkmenistan</option>
																			<option value="TC">Turks and Caicos Islands</option>
																			<option value="TV">Tuvalu</option>
																			<option value="UG">Uganda</option>
																			<option value="UA">Ukraine</option>
																			<option value="AE">United Arab Emirates</option>
																			<option value="GB">United Kingdom</option>
																			<option value="US" selected="">United States</option>
																			<option value="UM">United States Minor Outlying Islands</option>
																			<option value="UY">Uruguay</option>
																			<option value="UZ">Uzbekistan</option>
																			<option value="VU">Vanuatu</option>
																			<option value="VE">Venezuela, Bolivarian Republic of</option>
																			<option value="VN">Viet Nam</option>
																			<option value="VG">Virgin Islands, British</option>
																			<option value="VI">Virgin Islands, U.S.</option>
																			<option value="WF">Wallis and Futuna</option>
																			<option value="EH">Western Sahara</option>
																			<option value="YE">Yemen</option>
																			<option value="ZM">Zambia</option>
																			<option value="ZW">Zimbabwe</option>
																		</select>
																	</div>
																</div>
															</div>
														</div>

														<!--end: Form Wizard Step 1-->

														<!--begin: Form Wizard Step 2-->
														<div class="m-wizard__form-step" id="m_wizard_form_step_2">
															<div class="m-form__section m-form__section--first">
																<div class="m-form__heading">
																	<h3 class="m-form__heading-title">Account Details</h3>
																</div>
																<div class="form-group m-form__group row">
																	<div class="col-lg-12">
																		<label class="form-control-label">* URL:</label>
																		<input type="url" name="account_url" class="form-control m-input" placeholder="" value="http://sinortech.vertoffice.com">
																		<span class="m-form__help">Please enter your preferred URL to your dashboard</span>
																	</div>
																</div>
																<div class="form-group m-form__group row">
																	<div class="col-lg-6 m-form__group-sub">
																		<label class="form-control-label">* Username:</label>
																		<input type="text" name="account_username" class="form-control m-input" placeholder="" value="nick.stone">
																		<span class="m-form__help">Your username to login to your dashboard</span>
																	</div>
																	<div class="col-lg-6 m-form__group-sub">
																		<label class="form-control-label">* Password:</label>
																		<input type="password" name="account_password" class="form-control m-input" placeholder="" value="qwerty">
																		<span class="m-form__help">Please use letters and at least one number and symbol</span>
																	</div>
																</div>
															</div>
															<div class="m-separator m-separator--dashed m-separator--lg"></div>
															<div class="m-form__section">
																<div class="m-form__heading">
																	<h3 class="m-form__heading-title">Client Settings</h3>
																</div>
																<div class="form-group m-form__group row">
																	<div class="col-lg-6 m-form__group-sub">
																		<label class="form-control-label">* User Group:</label>
																		<div class="m-radio-inline">
																			<label class="m-radio m-radio--solid m-radio--brand">
																				<input type="radio" name="account_group" checked="" value="2"> Sales Person
																				<span></span>
																			</label>
																			<label class="m-radio m-radio--solid m-radio--brand">
																				<input type="radio" name="account_group" value="2"> Customer
																				<span></span>
																			</label>
																		</div>
																		<span class="m-form__help">Please select user group</span>
																	</div>
																	<div class="col-lg-6 m-form__group-sub">
																		<label class="form-control-label">* Communications:</label>
																		<div class="m-checkbox-inline">
																			<label class="m-checkbox m-checkbox--solid m-checkbox--brand">
																				<input type="checkbox" name="account_communication[]" checked="" value="email"> Email
																				<span></span>
																			</label>
																			<label class="m-checkbox m-checkbox--solid  m-checkbox--brand">
																				<input type="checkbox" name="account_communication[]" value="sms"> SMS
																				<span></span>
																			</label>
																			<label class="m-checkbox m-checkbox--solid  m-checkbox--brand">
																				<input type="checkbox" name="account_communication[]" value="phone"> Phone
																				<span></span>
																			</label>
																		</div>
																		<span class="m-form__help">Please select user communication options</span>
																	</div>
																</div>
															</div>
														</div>

														<!--end: Form Wizard Step 2-->

														<!--begin: Form Wizard Step 3-->
														<div class="m-wizard__form-step" id="m_wizard_form_step_3">
															<div class="m-form__section m-form__section--first">
																<div class="m-form__heading">
																	<h3 class="m-form__heading-title">Billing Information</h3>
																</div>
																<div class="form-group m-form__group row">
																	<div class="col-lg-12">
																		<label class="form-control-label">* Cardholder Name:</label>
																		<input type="text" name="billing_card_name" class="form-control m-input" placeholder="" value="Nick Stone">
																	</div>
																</div>
																<div class="form-group m-form__group row">
																	<div class="col-lg-12">
																		<label class="form-control-label">* Card Number:</label>
																		<input type="text" name="billing_card_number" class="form-control m-input" placeholder="" value="372955886840581">
																	</div>
																</div>
																<div class="form-group m-form__group row">
																	<div class="col-lg-4 m-form__group-sub">
																		<label class="form-control-label">* Exp Month:</label>
																		<select class="form-control m-input" name="billing_card_exp_month">
																			<option value="">Select</option>
																			<option value="01">01</option>
																			<option value="02">02</option>
																			<option value="03">03</option>
																			<option value="04" selected="">04</option>
																			<option value="05">05</option>
																			<option value="06">06</option>
																			<option value="07">07</option>
																			<option value="08">08</option>
																			<option value="09">09</option>
																			<option value="10">10</option>
																			<option value="11">11</option>
																			<option value="12">12</option>
																		</select>
																	</div>
																	<div class="col-lg-4 m-form__group-sub">
																		<label class="form-control-label">* Exp Year:</label>
																		<select class="form-control m-input" name="billing_card_exp_year">
																			<option value="">Select</option>
																			<option value="2018">2018</option>
																			<option value="2019">2019</option>
																			<option value="2020">2020</option>
																			<option value="2021" selected="">2021</option>
																			<option value="2022">2022</option>
																			<option value="2023">2023</option>
																			<option value="2024">2024</option>
																		</select>
																	</div>
																	<div class="col-lg-4 m-form__group-sub">
																		<label class="form-control-label">* CVV:</label>
																		<input type="number" class="form-control m-input" name="billing_card_cvv" placeholder="" value="450">
																	</div>
																</div>
															</div>
															<div class="m-separator m-separator--dashed m-separator--lg"></div>
															<div class="m-form__section">
																<div class="m-form__heading">
																	<h3 class="m-form__heading-title">Billing Address <i data-toggle="m-tooltip" data-width="auto" class="m-form__heading-help-icon flaticon-info" title="" data-original-title="If different than the corresponding address"></i></h3>
																</div>
																<div class="form-group m-form__group row">
																	<div class="col-lg-12">
																		<label class="form-control-label">* Address 1:</label>
																		<input type="text" name="billing_address_1" class="form-control m-input" placeholder="" value="Headquarters 1120 N Street Sacramento 916-654-5266">
																	</div>
																</div>
																<div class="form-group m-form__group row">
																	<div class="col-lg-12">
																		<label class="form-control-label">Address 2:</label>
																		<input type="text" name="billing_address_2" class="form-control m-input" placeholder="" value="P.O. Box 942873 Sacramento, CA 94273-0001">
																	</div>
																</div>
																<div class="form-group m-form__group row">
																	<div class="col-lg-5 m-form__group-sub">
																		<label class="form-control-label">* City:</label>
																		<input type="text" class="form-control m-input" name="billing_city" placeholder="" value="Polo Alto">
																	</div>
																	<div class="col-lg-5 m-form__group-sub">
																		<label class="form-control-label">* State:</label>
																		<input type="text" class="form-control m-input" name="billing_state" placeholder="" value="California">
																	</div>
																	<div class="col-lg-2 m-form__group-sub">
																		<label class="form-control-label">* ZIP:</label>
																		<input type="text" class="form-control m-input" name="billing_zip" placeholder="" value="34890">
																	</div>
																</div>
															</div>
															<div class="m-separator m-separator--dashed m-separator--lg"></div>
															<div class="m-form__section">
																<div class="m-form__heading">
																	<h3 class="m-form__heading-title">Delivery Type</h3>
																</div>
																<div class="form-group m-form__group">
																	<div class="row">
																		<div class="col-lg-6">
																			<label class="m-option">
																				<span class="m-option__control">
																					<span class="m-radio m-radio--state-brand">
																						<input type="radio" name="billing_delivery" value="">
																						<span></span>
																					</span>
																				</span>
																				<span class="m-option__label">
																					<span class="m-option__head">
																						<span class="m-option__title">
																							Standart Delevery
																						</span>
																						<span class="m-option__focus">
																							Free
																						</span>
																					</span>
																					<span class="m-option__body">
																						Estimated 14-20 Day Shipping
																						(&nbsp;Duties end taxes may be due
																						upon delivery&nbsp;)
																					</span>
																				</span>
																			</label>
																		</div>
																		<div class="col-lg-6">
																			<label class="m-option">
																				<span class="m-option__control">
																					<span class="m-radio m-radio--state-brand">
																						<input type="radio" name="billing_delivery" value="">
																						<span></span>
																					</span>
																				</span>
																				<span class="m-option__label">
																					<span class="m-option__head">
																						<span class="m-option__title">
																							Fast Delevery
																						</span>
																						<span class="m-option__focus">
																							$&nbsp;8.00
																						</span>
																					</span>
																					<span class="m-option__body">
																						Estimated 2-5 Day Shipping
																						(&nbsp;Duties end taxes may be due
																						upon delivery&nbsp;)
																					</span>
																				</span>
																			</label>
																		</div>
																	</div>
																	<div class="m-form__help">

																		<!--must use this helper element to display error message for the options-->
																	</div>
																</div>
															</div>
														</div>

														<!--end: Form Wizard Step 3-->

														<!--begin: Form Wizard Step 4-->
														<div class="m-wizard__form-step" id="m_wizard_form_step_4">

															<!--begin::Section-->
															<div class="m-accordion m-accordion--default" id="m_accordion_1" role="tablist">

																<!--begin::Item-->
																<div class="m-accordion__item active">
																	<div class="m-accordion__item-head" role="tab" id="m_accordion_1_item_1_head" data-toggle="collapse" href="#m_accordion_1_item_1_body" aria-expanded="  false">
																		<span class="m-accordion__item-icon"><i class="fa flaticon-user-ok"></i></span>
																		<span class="m-accordion__item-title">1. Client Information</span>
																		<span class="m-accordion__item-mode"></span>
																	</div>
																	<div class="m-accordion__item-body collapse show" id="m_accordion_1_item_1_body" role="tabpanel" aria-labelledby="m_accordion_1_item_1_head" data-parent="#m_accordion_1">

																		<!--begin::Content-->
																		<div class="tab-content active  m--padding-30">
																			<div class="m-form__section m-form__section--first">
																				<div class="m-form__heading">
																					<h4 class="m-form__heading-title">Client Details</h4>
																				</div>
																				<div class="form-group m-form__group m-form__group--sm row">
																					<label class="col-xl-4 col-lg-4 col-form-label">Name:</label>
																					<div class="col-xl-8 col-lg-8">
																						<span class="m-form__control-static">Nick Stone</span>
																					</div>
																				</div>
																				<div class="form-group m-form__group m-form__group--sm row">
																					<label class="col-xl-4 col-lg-4 col-form-label">Email:</label>
																					<div class="col-xl-8 col-lg-8">
																						<span class="m-form__control-static">nick.stone@gmail.com</span>
																					</div>
																				</div>
																				<div class="form-group m-form__group m-form__group--sm row">
																					<label class="col-xl-4 col-lg-4 col-form-label">Phone</label>
																					<div class="col-xl-8 col-lg-8">
																						<span class="m-form__control-static">+206-78-55034890</span>
																					</div>
																				</div>
																			</div>
																			<div class="m-separator m-separator--dashed m-separator--lg"></div>
																			<div class="m-form__section">
																				<div class="m-form__heading">
																					<h4 class="m-form__heading-title">Corresponding Address <i data-toggle="m-tooltip" class="m-form__heading-help-icon flaticon-info" title="" data-original-title="Some help text goes here"></i></h4>
																				</div>
																				<div class="form-group m-form__group m-form__group--sm row">
																					<label class="col-xl-4 col-lg-4 col-form-label">Address Line 1:</label>
																					<div class="col-xl-8 col-lg-8">
																						<span class="m-form__control-static">Headquarters 1120 N Street Sacramento 916-654-5266</span>
																					</div>
																				</div>
																				<div class="form-group m-form__group m-form__group--sm row">
																					<label class="col-xl-4 col-lg-4 col-form-label">Address Line 2:</label>
																					<div class="col-xl-8 col-lg-8">
																						<span class="m-form__control-static">P.O. Box 942873 Sacramento, CA 94273-0001</span>
																					</div>
																				</div>
																				<div class="form-group m-form__group m-form__group--sm row">
																					<label class="col-xl-4 col-lg-4 col-form-label">City:</label>
																					<div class="col-xl-8 col-lg-8">
																						<span class="m-form__control-static">Polo Alto</span>
																					</div>
																				</div>
																				<div class="form-group m-form__group m-form__group--sm row">
																					<label class="col-xl-4 col-lg-4 col-form-label">State:</label>
																					<div class="col-xl-8 col-lg-8">
																						<span class="m-form__control-static">California</span>
																					</div>
																				</div>
																				<div class="form-group m-form__group m-form__group--sm row">
																					<label class="col-xl-4 col-lg-4 col-form-label">Country:</label>
																					<div class="col-xl-8 col-lg-8">
																						<span class="m-form__control-static">USA</span>
																					</div>
																				</div>
																			</div>
																		</div>

																		<!--end::Section-->
																	</div>
																</div>

																<!--end::Item-->

																<!--begin::Item-->
																<div class="m-accordion__item">
																	<div class="m-accordion__item-head collapsed" role="tab" id="m_accordion_1_item_2_head" data-toggle="collapse" href="#m_accordion_1_item_2_body" aria-expanded="    false">
																		<span class="m-accordion__item-icon"><i class="fa  flaticon-placeholder"></i></span>
																		<span class="m-accordion__item-title">2. Account Setup</span>
																		<span class="m-accordion__item-mode"></span>
																	</div>
																	<div class="m-accordion__item-body collapse" id="m_accordion_1_item_2_body" role="tabpanel" aria-labelledby="m_accordion_1_item_2_head" data-parent="#m_accordion_1">

																		<!--begin::Content-->
																		<div class="tab-content  m--padding-30">
																			<div class="m-form__section m-form__section--first">
																				<div class="m-form__heading">
																					<h4 class="m-form__heading-title">Account Details</h4>
																				</div>
																				<div class="form-group m-form__group m-form__group--sm row">
																					<label class="col-xl-4 col-lg-4 col-form-label">URL:</label>
																					<div class="col-xl-8 col-lg-8">
																						<span class="m-form__control-static">sinortech.vertoffice.com</span>
																					</div>
																				</div>
																				<div class="form-group m-form__group m-form__group--sm row">
																					<label class="col-xl-4 col-lg-4 col-form-label">Username:</label>
																					<div class="col-xl-8 col-lg-8">
																						<span class="m-form__control-static">sinortech.admin</span>
																					</div>
																				</div>
																				<div class="form-group m-form__group m-form__group--sm row">
																					<label class="col-xl-4 col-lg-4 col-form-label">Password:</label>
																					<div class="col-xl-8 col-lg-8">
																						<span class="m-form__control-static">*********</span>
																					</div>
																				</div>
																			</div>
																			<div class="m-separator m-separator--dashed m-separator--lg"></div>
																			<div class="m-form__section">
																				<div class="m-form__heading">
																					<h4 class="m-form__heading-title">Client Settings</h4>
																				</div>
																				<div class="form-group m-form__group m-form__group--sm row">
																					<label class="col-xl-4 col-lg-4 col-form-label">User Group:</label>
																					<div class="col-xl-8 col-lg-8">
																						<span class="m-form__control-static">Customer</span>
																					</div>
																				</div>
																				<div class="form-group m-form__group m-form__group--sm row">
																					<label class="col-xl-4 col-lg-4 col-form-label">Communications:</label>
																					<div class="col-xl-8 col-lg-8">
																						<span class="m-form__control-static">Phone, Email</span>
																					</div>
																				</div>
																			</div>
																		</div>

																		<!--end::Content-->
																	</div>
																</div>

																<!--end::Item-->

																<!--begin::Item-->
																<div class="m-accordion__item">
																	<div class="m-accordion__item-head collapsed" role="tab" id="m_accordion_1_item_3_head" data-toggle="collapse" href="#m_accordion_1_item_3_body" aria-expanded="    false">
																		<span class="m-accordion__item-icon"><i class="fa  flaticon-placeholder"></i></span>
																		<span class="m-accordion__item-title">3. Billing Setup</span>
																		<span class="m-accordion__item-mode"></span>
																	</div>
																	<div class="m-accordion__item-body collapse" id="m_accordion_1_item_3_body" role="tabpanel" aria-labelledby="m_accordion_1_item_3_head" data-parent="#m_accordion_1">

																		<!--begin::Content-->
																		<div class="tab-content  m--padding-30">
																			<div class="m-form__section m-form__section--first">
																				<div class="m-form__heading">
																					<h4 class="m-form__heading-title">Billing Information</h4>
																				</div>
																				<div class="form-group m-form__group m-form__group--sm row">
																					<label class="col-xl-4 col-lg-4 col-form-label">Cardholder Name:</label>
																					<div class="col-xl-8 col-lg-8">
																						<span class="m-form__control-static">Nick Stone</span>
																					</div>
																				</div>
																				<div class="form-group m-form__group m-form__group--sm row">
																					<label class="col-xl-4 col-lg-4 col-form-label">Card Number:</label>
																					<div class="col-xl-8 col-lg-8">
																						<span class="m-form__control-static">*************4589</span>
																					</div>
																				</div>
																				<div class="form-group m-form__group m-form__group--sm row">
																					<label class="col-xl-4 col-lg-4 col-form-label">Exp Month:</label>
																					<div class="col-xl-8 col-lg-8">
																						<span class="m-form__control-static">10</span>
																					</div>
																				</div>
																				<div class="form-group m-form__group m-form__group--sm row">
																					<label class="col-xl-4 col-lg-4 col-form-label">Exp Year:</label>
																					<div class="col-xl-8 col-lg-8">
																						<span class="m-form__control-static">2018</span>
																					</div>
																				</div>
																				<div class="form-group m-form__group m-form__group--sm row">
																					<label class="col-xl-4 col-lg-4 col-form-label">CVV:</label>
																					<div class="col-xl-8 col-lg-8">
																						<span class="m-form__control-static">***</span>
																					</div>
																				</div>
																			</div>
																			<div class="m-separator m-separator--dashed m-separator--lg"></div>
																			<div class="m-form__section">
																				<div class="m-form__heading">
																					<h4 class="m-form__heading-title">Billing Address</h4>
																				</div>
																				<div class="form-group m-form__group m-form__group--sm row">
																					<label class="col-xl-4 col-lg-4 col-form-label">Address Line 1:</label>
																					<div class="col-xl-8 col-lg-8">
																						<span class="m-form__control-static">Headquarters 1120 N Street Sacramento 916-654-5266</span>
																					</div>
																				</div>
																				<div class="form-group m-form__group m-form__group--sm row">
																					<label class="col-xl-4 col-lg-4 col-form-label">Address Line 2:</label>
																					<div class="col-xl-8 col-lg-8">
																						<span class="m-form__control-static">P.O. Box 942873 Sacramento, CA 94273-0001</span>
																					</div>
																				</div>
																				<div class="form-group m-form__group m-form__group--sm row">
																					<label class="col-xl-4 col-lg-4 col-form-label">City:</label>
																					<div class="col-xl-8 col-lg-8">
																						<span class="m-form__control-static">Polo Alto</span>
																					</div>
																				</div>
																				<div class="form-group m-form__group m-form__group--sm row">
																					<label class="col-xl-4 col-lg-4 col-form-label">State:</label>
																					<div class="col-xl-8 col-lg-8">
																						<span class="m-form__control-static">California</span>
																					</div>
																				</div>
																				<div class="form-group m-form__group m-form__group--sm row">
																					<label class="col-xl-4 col-lg-4 col-form-label">ZIP:</label>
																					<div class="col-xl-8 col-lg-8">
																						<span class="m-form__control-static">37505</span>
																					</div>
																				</div>
																				<div class="form-group m-form__group m-form__group--sm row">
																					<label class="col-xl-4 col-lg-4 col-form-label">Country:</label>
																					<div class="col-xl-8 col-lg-8">
																						<span class="m-form__control-static">USA</span>
																					</div>
																				</div>
																			</div>
																		</div>

																		<!--end::Content-->
																	</div>
																</div>

																<!--end::Item-->
															</div>

															<!--end::Section-->

															<!--end::Section-->
															<div class="m-separator m-separator--dashed m-separator--lg"></div>
															<div class="form-group m-form__group m-form__group--sm row">
																<div class="col-xl-12">
																	<div class="m-checkbox-inline">
																		<label class="m-checkbox m-checkbox--solid m-checkbox--brand">
																			<input type="checkbox" name="accept" value="1">
																			Click here to indicate that you have read and agree to the terms presented in the Terms and Conditions agreement
																			<span></span>
																		</label>
																	</div>
																</div>
															</div>
														</div>

														<!--end: Form Wizard Step 4-->
													</div>

													<!--end: Form Body -->

													<!--begin: Form Actions -->
													<div class="m-portlet__foot m-portlet__foot--fit m--margin-top-40">
														<div class="m-form__actions">
															<div class="row">
																<div class="col-lg-6 m--align-left">
																	<a href="#" class="btn btn-secondary m-btn m-btn--custom m-btn--icon" data-wizard-action="prev">
																		<span>
																			<i class="la la-arrow-left"></i>&nbsp;&nbsp;
																			<span>Back</span>
																		</span>
																	</a>
																</div>
																<div class="col-lg-6 m--align-right">
																	<a href="#" class="btn btn-primary m-btn m-btn--custom m-btn--icon" data-wizard-action="submit">
																		<span>
																			<i class="la la-check"></i>&nbsp;&nbsp;
																			<span>Submit</span>
																		</span>
																	</a>
																	<a href="#" class="btn btn-success m-btn m-btn--custom m-btn--icon" data-wizard-action="next">
																		<span>
																			<span>Save &amp; Continue</span>&nbsp;&nbsp;
																			<i class="la la-arrow-right"></i>
																		</span>
																	</a>
																</div>
															</div>
														</div>
													</div>

													<!--end: Form Actions -->
												</form>
											</div>

											<!--end: Form Wizard Form-->
										</div>
									</div>

								</div>

								<!--end: Form Wizard-->
							</div>

							<!--end: Portlet Body-->
						</div>

						<!--End::Main Portlet-->
					</div>
				</div>
	
     <footer class="m-grid__item m-footer " style="margin-left:0px;">
        <div class="m-container m-container--fluid m-container--full-height m-page__container">
            <div class="m-stack m-stack--flex-tablet-and-mobile m-stack--ver m-stack--desktop">
                <div class="m-stack__item m-stack__item--left m-stack__item--middle m-stack__item--last">
                    <span class="m-footer__copyright">2019 &copy; eFacilito - Powered by <a href="https://efacilito.com/about-us/" class="m-link">Compel Consultancy</a>
                    </span>
                </div>
            </div>
        </div>
    </footer>



    <!-- end::Scroll Top -->

    <!--begin:: Global Mandatory Vendors -->
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/popper.js/dist/umd/popper.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/bootstrap/dist/js/bootstrap.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/js-cookie/src/js.cookie.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/moment/min/moment.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/tooltip.js/dist/umd/tooltip.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/perfect-scrollbar/dist/perfect-scrollbar.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/wnumb/wNumb.js") %>" type="text/javascript"></script>

    <!--end:: Global Mandatory Vendors -->

    <!--begin:: Global Optional Vendors -->
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery.repeater/src/lib.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery.repeater/src/jquery.input.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery.repeater/src/repeater.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery-form/dist/jquery.form.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/block-ui/jquery.blockUI.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/js/framework/components/plugins/forms/bootstrap-datepicker.init.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/bootstrap-datetime-picker/js/bootstrap-datetimepicker.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/bootstrap-timepicker/js/bootstrap-timepicker.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/js/framework/components/plugins/forms/bootstrap-timepicker.init.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/bootstrap-daterangepicker/daterangepicker.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/js/framework/components/plugins/forms/bootstrap-daterangepicker.init.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/bootstrap-maxlength/src/bootstrap-maxlength.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/bootstrap-switch/dist/js/bootstrap-switch.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/js/framework/components/plugins/forms/bootstrap-switch.init.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/vendors/bootstrap-multiselectsplitter/bootstrap-multiselectsplitter.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/bootstrap-select/dist/js/bootstrap-select.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/select2/dist/js/select2.full.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/typeahead.js/dist/typeahead.bundle.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/handlebars/dist/handlebars.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/inputmask/dist/jquery.inputmask.bundle.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/inputmask/dist/inputmask/inputmask.date.extensions.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/inputmask/dist/inputmask/inputmask.numeric.extensions.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/inputmask/dist/inputmask/inputmask.phone.extensions.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/nouislider/distribute/nouislider.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/owl.carousel/dist/owl.carousel.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/autosize/dist/autosize.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/clipboard/dist/clipboard.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/ion-rangeslider/js/ion.rangeSlider.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/dropzone/dropzone.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/summernote/dist/summernote.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/markdown/lib/markdown.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/bootstrap-markdown/js/bootstrap-markdown.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/js/framework/components/plugins/forms/bootstrap-markdown.init.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery-validation/dist/jquery.validate.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery-validation/dist/additional-methods.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/js/framework/components/plugins/forms/jquery-validation.init.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/bootstrap-notify/bootstrap-notify.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/js/framework/components/plugins/base/bootstrap-notify.init.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/toastr/build/toastr.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/jstree/dist/jstree.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/raphael/raphael.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/morris.js/morris.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/chartist/dist/chartist.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/chart.js/dist/Chart.bundle.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/js/framework/components/plugins/charts/chart.init.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/vendors/bootstrap-session-timeout/dist/bootstrap-session-timeout.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/vendors/jquery-idletimer/idle-timer.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/waypoints/lib/jquery.waypoints.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/counterup/jquery.counterup.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/es6-promise-polyfill/promise.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/sweetalert2/dist/sweetalert2.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/js/framework/components/plugins/base/sweetalert2.init.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/vendors/sweetalert2/src/sweetalert2.js") %>" type="text/javascript"></script>

    <script src="<%= Page.ResolveClientUrl("~/vendors/bootstrap-confirmation/bootstrap-confirmation.js") %>" type="text/javascript"></script>
    <!--end:: Global Optional Vendors -->

    <!--begin::Global Theme Bundle -->
    <script src="<%= Page.ResolveClientUrl("~/assets/demo/base/scripts.bundle.js") %>" type="text/javascript"></script>

    <%--    <script src="<%= Page.ResolveClientUrl("~/assets/vendors/custom/flot/flot.bundle.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets/demo/default/custom/components/charts/flotcharts.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets/demo/default/base/scripts.bundle.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets/vendors/base/vendors.bundle.js") %>" type="text/javascript"></script>--%>
    <%--
    <script src="<%= Page.ResolveClientUrl("~/assets/demo/default/custom/components/charts/flotcharts.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets/vendors/custom/flot/flot.bundle.js") %>" type="text/javascript"></script>--%>

    <!--end::Global Theme Bundle -->

    <!--begin::Page Vendors -->
    <script src="<%= Page.ResolveClientUrl("~/assets/vendors/custom/fullcalendar/fullcalendar.bundle.js") %>" type="text/javascript"></script>

    <!--end::Page Vendors -->

    <!--begin::Page Vendors -->

    <script src="<%= Page.ResolveClientUrl("~/assets/vendors/custom/datatables/datatables.bundle.js") %>" type="text/javascript"></script>

    <%--<script src="<%= Page.ResolveClientUrl("~/assets/demo/default/custom/crud/datatables/extensions/buttons.js") %>" type="text/javascript"></script>--%>


    <!--end::Page Vendors -->

    <!--begin::Page Scripts -->
    <script src="<%= Page.ResolveClientUrl("~/assets/app/js/dashboard.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets/custom/common.js") %>" type="text/javascript"></script>

    <!-- The core Firebase JS SDK is always required and must be listed first -->
    <script src="https://www.gstatic.com/firebasejs/8.3.1/firebase-app.js"></script>

    <!-- TODO: Add SDKs for Firebase products that you want to use
     https://firebase.google.com/docs/web/setup#available-libraries -->
    <script src="https://www.gstatic.com/firebasejs/8.3.1/firebase-analytics.js"></script>


</body>
</html>
