<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print_LocationQRCode.aspx.cs" Inherits="Upkeep_v3.General_Masters.Print_LocationQRCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--  --%>
    <meta charset="utf-8" />
    <title>eFacilito | QR Codes</title>
    <meta name="description" content="Latest updates and statistic charts" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, shrink-to-fit=no" />

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

    <!--begin:: Global Mandatory Vendors -->
    <link href="<%= Page.ResolveClientUrl("~/vendors/perfect-scrollbar/css/perfect-scrollbar.css") %>" rel="stylesheet" type="text/css" />

    <!--end:: Global Mandatory Vendors -->

    <!--begin:: Global Optional Vendors -->
    <link href="<%= Page.ResolveClientUrl("~/vendors/tether/dist/css/tether.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/bootstrap-datepicker/dist/css/bootstrap-datepicker3.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/bootstrap-datetime-picker/css/bootstrap-datetimepicker.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/bootstrap-timepicker/css/bootstrap-timepicker.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/bootstrap-daterangepicker/daterangepicker.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/bootstrap-switch/dist/css/bootstrap3/bootstrap-switch.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/bootstrap-select/dist/css/bootstrap-select.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/select2/dist/css/select2.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/nouislider/distribute/nouislider.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/owl.carousel/dist/assets/owl.carousel.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/owl.carousel/dist/assets/owl.theme.default.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/ion-rangeslider/css/ion.rangeSlider.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/ion-rangeslider/css/ion.rangeSlider.skinFlat.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/dropzone/dist/dropzone.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/summernote/dist/summernote.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/bootstrap-markdown/css/bootstrap-markdown.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/animate.css/animate.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/toastr/build/toastr.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/jstree/dist/themes/default/style.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/morris.js/morris.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/chartist/dist/chartist.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/sweetalert2/dist/sweetalert2.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/socicon/css/socicon.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/vendors/line-awesome/css/line-awesome.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/vendors/flaticon/css/flaticon.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/vendors/metronic/css/styles.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/vendors/vendors/fontawesome5/css/all.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/assets/custom/Dashboard.css") %>" rel="stylesheet" type="text/css" />
    <%--<link href="assets/custom/icons.min.css" rel="stylesheet" type="text/css" />--%>

    <!--end:: Global Optional Vendors -->

    <!--begin::Global Theme Styles -->
    <link href="<%= Page.ResolveClientUrl("~/assets/demo/base/style.bundle.css") %>" rel="stylesheet" type="text/css" />
    <%--<link href="assets1/demo/default/base/style.bundle.css" rel="stylesheet" type="text/css" />--%>

    <!--RTL version:<link href="assets/demo/base/style.bundle.rtl.css" rel="stylesheet" type="text/css" />-->

    <!--end::Global Theme Styles -->

    <!--begin::Page Vendors Styles -->
    <link href="<%= Page.ResolveClientUrl("~/assets/vendors/custom/fullcalendar/fullcalendar.bundle.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/assets/vendors/custom/datatables/datatables.bundle.css") %>" rel="stylesheet" type="text/css" />
    <!--RTL version:<link href="assets/vendors/custom/fullcalendar/fullcalendar.bundle.rtl.css" rel="stylesheet" type="text/css" />-->

    <!--end::Page Vendors Styles -->
    <link rel="shortcut icon" href="<%= Page.ResolveClientUrl("~/assets1/demo/default/media/img/logo/favicon.ico") %>" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="m-content">
            <div class="m-grid__item m-grid__item--fluid  m-grid__item--order-tablet-and-mobile-1  m-login__wrapper">
                <!--begin::Body-->
                <div class="m-portlet__body">
                    <br />
                    <table cellspacing="0" rules="all" border="5" style="width:35%; margin-left: 440px;">
                        <tr>
                            <td>
                                <div class="row" >
                                    <%--<div class="col-xl-3 col-lg-3"></div>--%>
                                    <div class="col-xl-12 col-lg-12 col-form-label" style="text-align: center;">
                                        <asp:Label ID="lblTicketNo" runat="server" Text="Compel Consultancy" class="form-control-label font-weight-bold" style="font-size: x-large;"></asp:Label>
                                    </div>
                                    <%--<div class="col-xl-3 col-lg-3"></div>--%>
                                </div>

                                <div class="row" >
                                    <%--<div class="col-xl-3 col-lg-3"></div>--%>
                                    <div class="col-xl-12 col-lg-12 col-form-label" style="text-align: center;">
                                        <img src="../assets/demo/media/img/misc/DemoQR.png" style="width: 370px; height: 350px;" />
                                    </div>
                                    <%--<div class="col-xl-3 col-lg-3"></div>--%>
                                </div>

                                <div class="row" >
                                    <%--<div class="col-xl-3 col-lg-3"></div>--%>
                                    <div class="col-xl-12 col-lg-12 col-form-label" style="text-align: center;">
                                        <asp:Label ID="Label1" runat="server" Text="Zone > Location > Sub Location > Cat" class="form-control-label font-weight-bold" style="font-size: x-large;"></asp:Label>
                                    </div>
                                    <%--<div class="col-xl-3 col-lg-3"></div>--%>
                                </div>
                                <br />
                                <div class="row " >
                                    <div class="col-xl-6 col-lg-6" style="text-align: left;">
                                        <img src="https://compelapps.in/efacilito_UAT_Control_Center//CompanyLogo/phxkurla.jpg" style="width: 100px; height: 50px;" />
                                    </div>
                                    <%--<div class="col-xl-6 col-lg-6 col-form-label" style="text-align: center;">
                                    </div>--%>
                                    <div class="col-xl-6 col-lg-6" style="text-align: right; width: 100px; height: 65px; overflow: hidden;">
                                        <img src="../assets/demo/media/img/misc/efacilito_QR_Logo.png" style="height: 60px; " />
                                    </div>
                                </div>

                            </td>
                        </tr>
                    </table>




                    <asp:Repeater ID="rptQRCodes" runat="server">

                        <ItemTemplate>
                            <div>
                                <asp:Label ID="lblCompanyName" runat="server" Text="Compel Consultancy"></asp:Label>
                            </div>
                            <div>
                                <img src="../assets/demo/media/img/misc/DemoQR.png" />
                            </div>

                            <%--<asp:Image ImageUrl='<%# Eval("Value") %>' runat="server" />--%>
                        </ItemTemplate>

                    </asp:Repeater>

                </div>
            </div>
        </div>
    </form>

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
    <script src="<%= Page.ResolveClientUrl("~/vendors/dropzone/dist/dropzone.js") %>" type="text/javascript"></script>
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

    <!--end::Global Theme Bundle -->

    <!--begin::Page Vendors -->
    <script src="<%= Page.ResolveClientUrl("~/assets/vendors/custom/fullcalendar/fullcalendar.bundle.js") %>" type="text/javascript"></script>

    <!--end::Page Vendors -->

    <!--begin::Page Vendors -->

    <script src="<%= Page.ResolveClientUrl("~/assets/vendors/custom/datatables/datatables.bundle.js") %>" type="text/javascript"></script>
    <!--end::Page Vendors -->

    <!--begin::Page Scripts -->
    <script src="<%= Page.ResolveClientUrl("~/assets/app/js/dashboard.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets/custom/common.js") %>" type="text/javascript"></script>


</body>
</html>
