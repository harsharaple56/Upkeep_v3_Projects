<%@ Page Language="C#" MasterPageFile="~/BlankMaster.Master" AutoEventWireup="true" CodeBehind="Verify_Visitor_ID_V2.aspx.cs" Inherits="Upkeep_v3.VMS.Verify_Visitor_ID_V2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(function () {
            $("#userinfo").hide();
            $("#invaliduser").hide();
            $("#scaninfo").show();
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#lbl_Visitor_Name").html('');
            $("#lbl_Visitor_Email").html('');
            $("#lbl_VisitRequest_ID").html('');
            $("#lbl_Visitor_Contact").html('');
            $("#Img_Visitor_Photo").attr("src", "");
            $("#lbl_Vacc_Date").html('');
            $("#lbl_Request_Date_Text").html('');
            $("#lbl_Visit_Date_Text").html('');

            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": false,
                "progressBar": false,
                "positionClass": "toast-bottom-center",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "3000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            };

        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="scaninfo" class="row">
        <div class="col-md-12">
            <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile">

                <div class="m--align-center" style="padding: 15px;">
                    <asp:Image ID="Img_CompanyLogo" src="../assets/app/media/img/logos/verify_certificate.png" runat="server" Style="width: auto; max-height: 150px; max-width: 100%;" />

                </div>
                <div class="m--align-center" style="padding: 15px;">
                    <h2 class="m--font-primary" style="padding-bottom: inherit;">Verify Visitor ID</h2>

                    <button id="btn_ClickPhoto_Aadhar" type="button" class="btn btn-primary m-btn m-btn--icon m-btn--pill m-btn--air" data-toggle="modal" data-target="#m_modal_6">
                        <span>
                            <i class="fa fa-camera"></i>
                            <span>Scan QR Code on Visitor ID</span>
                        </span>
                    </button>
                </div>
                <div class="m--align-center" style="padding: 15px;">
                    <h5 class="m--space-10" style="padding-bottom: 5rem;">The eFacilito Visitor ID has a digitally signed QR code. This can be authenticated online using the verification utility in this portal</h5>

                </div>
            </div>
        </div>
    </div>

    <div id="userinfo" class="row m--hide">
        <div class="col-md-12">
            <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile">
                <div class="m-portlet__body">
                    <div class="m-stack m-stack--ver m-stack--tablet m-stack--demo m--align-center">

                        <div class="m-stack__item m-stack__item--center m-stack__item--top">

                            <img src="../assets/app/media/img/logos/verified.jpg" style="height: 130px;" />

                        </div>

                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                            <h3 class="m--font-success" style="padding-bottom: inherit;">Visitor ID Verified Successfully</h3>

                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">

                            <asp:Image ID="Image2" src="../assets/app/media/img/logos/Palladium.PNG" runat="server" Style="width: auto; max-height: 70px; max-width: 100%;" />

                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">

                            <img src="#" id="Img_Visitor_Photo" style="width: auto; max-height: 70px; max-width: 100%;" />

                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                            <span class="font-weight-bold">Name : </span>
                            <label id="lbl_Visitor_Name"></label>


                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                            <span class="font-weight-bold">Email : </span>
                            <label id="lbl_Visitor_Email"></label>


                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                            <span class="font-weight-bold">Contact : </span>
                            <label id="lbl_Visitor_Contact"></label>


                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">

                            <span class="font-weight-bold">Visit Request ID : </span>
                            <label id="lbl_VisitRequest_ID"></label>


                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle" style="background: yellow;">

                            <div class="font-weight-bold">Vaccination Details</div>

                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                            <div class="font-weight-bold">
                                Vaccination Status : <span class="m-badge m-badge--success m-badge--wide m-badge--rounded">VACCINATED</span>
                            </div>
                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                            <span class="font-weight-bold">Date of Vaccination : </span>
                            <label id="lbl_Vacc_Date"></label>


                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                            <div class="col-form-label">
                                <span class="font-weight-bold">Visit Request Created on : </span>
                                <label id="lbl_Request_Date_Text"></label>
                            </div>


                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                            <div class="col-form-label">
                                <span class="font-weight-bold">Visit Date on : </span>
                                <label id="lbl_Visit_Date_Text"></label>
                            </div>
                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--bottom">
                            <button type="button" onclick="window.location.reload();" class="btn btn-outline-primary m-btn m-btn--icon m-btn--outline-2x m-btn--pill m-btn--air">
                                <span>
                                    <i style="font-size: 2.3rem;" class="fa fa-angle-double-left"></i>
                                    <span>Go Back</span>
                                </span>
                            </button>
                        </div>


                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="invaliduser" class="row m--hide">
        <div class="col-md-12">
            <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">
                <div class="m-portlet__body">
                    <div class="m-stack m-stack--ver m-stack--tablet m-stack--demo m--align-center">

                        <div class="m-stack__item m-stack__item--center m-stack__item--top">

                            <img src="../assets/app/media/img/Dashboard_Icons/pending.png" style="height: 130px;" />

                        </div>

                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                            <h3 class="m--font-danger" style="padding-bottom: inherit;">Invalid Visitor ID</h3>

                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                            <button type="button" onclick="window.location.reload();" class="btn btn-outline-primary m-btn m-btn--icon m-btn--outline-2x m-btn--pill m-btn--air">
                                <span>
                                    <i style="font-size: 2.3rem;" class="fa fa-angle-double-left"></i>
                                    <span>Go Back</span>
                                </span>
                            </button>
                        </div>


                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="m_modal_6" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body m--align-center">
                    <div class="col-sm-12">
                        <div id="qr-reader" style="width: 730px"></div>
                        <div id="qr-reader-results"></div>
                    </div>
                    <script src="../assets/html5-qrcode.min.js"></script>
                    <script>
                        function docReady(fn) {
                            if (document.readyState === "complete"
                                || document.readyState === "interactive") {
                                setTimeout(fn, 1);
                            } else {
                                document.addEventListener("DOMContentLoaded", fn);
                            }
                        }

                        docReady(function () {
                            var resultContainer = document.getElementById('qr-reader-results');
                            var lastResult, countResults = 0;
                            function onScanSuccess(decodedText, decodedResult) {
                                if (decodedText !== lastResult) {
                                    ++countResults;
                                    lastResult = decodedText;
                                    if (decodedText != undefined || decodedText != "") {
                                        $.ajax({
                                            url: "Verify_Visitor_ID_V2.aspx/Verify_Visitor_ID",
                                            type: "POST",
                                            data: "{ 'visitor_code': '" + decodedText + "'} ",
                                            contentType: 'application/json;charset=utf-8',
                                            dataType: 'json',
                                            success: function (response) {
                                                if (response.d == "InvalidQR") {
                                                    $("#m_modal_6").modal("hide");
                                                    $("#userinfo").hide();
                                                    $("#scaninfo").hide();
                                                    $('#invaliduser').removeClass('m--hide');
                                                    $('#invaliduser').removeAttr('style', 'display:none');
                                                    $("#invaliduser").show();
                                                    toastr.warning("Please enter valid QR Code...!");
                                                }
                                                else if (response.d != "") {
                                                    $("#PhotoSuceess").show();
                                                    $("#m_modal_6").modal("hide");
                                                    $.each(response.d.split(","), function (key, val) {
                                                        if (key == 0)
                                                            $("#Img_Visitor_Photo").attr("src", val);
                                                        if (key == 1)
                                                            $("#lbl_Visitor_Name").html(val);
                                                        if (key == 2)
                                                            $("#lbl_Visitor_Email").html(val);
                                                        if (key == 3)
                                                            $("#lbl_Visitor_Contact").html(val);
                                                        if (key == 4)
                                                            $("#lbl_VisitRequest_ID").html(val);
                                                        if (key == 5)
                                                            $("#lbl_Vacc_Date").html(val);
                                                        if (key == 6)
                                                            $("#lbl_Request_Date_Text").html(val);
                                                        if (key == 7)
                                                            $("#lbl_Visit_Date_Text").html(val);
                                                    });
                                                    $('#userinfo').removeClass('m--hide');
                                                    $('#userinfo').removeAttr('style', 'display:none');
                                                    $("#userinfo").show();
                                                    $("#scaninfo").hide();
                                                    $("#invaliduser").hide();
                                                    toastr.success("QR CODE Scan Successfully..!");
                                                }

                                            },
                                            failure: function (response) {
                                                $("#m_modal_6").modal("hide");
                                                $("#userinfo").hide();
                                                $("#scaninfo").hide();
                                                $('#invaliduser').removeClass('m--hide');
                                                $('#invaliduser').removeAttr('style', 'display:none');
                                                $("#invaliduser").show();
                                                toastr.warning("There is no QR CODE inside the image..!");
                                            }
                                        });
                                    }
                                }
                            }

                            var html5QrcodeScanner = new Html5QrcodeScanner(
                                "qr-reader", { fps: 10, qrbox: 250 });
                            html5QrcodeScanner.render(onScanSuccess);
                        });
                    </script>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
