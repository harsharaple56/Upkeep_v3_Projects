<%@ Page Language="C#" MasterPageFile="~/BlankMaster.Master" AutoEventWireup="true" CodeBehind="Verify_Visitor_ID_V2.aspx.cs" Inherits="Upkeep_v3.VMS.Verify_Visitor_ID_V2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        /* JS comes here */
        (function () {

            var width = 280; // We will scale the photo width to this
            var height = 0; // This will be computed based on the input stream

            var streaming = false;

            var video = null;
            var canvas = null;
            var photo = null;
            var startbutton = null;

            function startup() {
                video = document.getElementById('video');
                canvas = document.getElementById('canvas');
                photo = document.getElementById('photo');
                startbutton = document.getElementById('startbutton');

                navigator.mediaDevices.getUserMedia({
                    video: true,
                    audio: false
                })
                    .then(function (stream) {
                        video.srcObject = stream;
                        video.play();
                    })
                    .catch(function (err) {
                        console.log("An error occurred: " + err);
                    });

                video.addEventListener('canplay', function (ev) {
                    if (!streaming) {
                        height = video.videoHeight / (video.videoWidth / width);

                        if (isNaN(height)) {
                            height = width / (4 / 3);
                        }

                        video.setAttribute('width', width);
                        video.setAttribute('height', height);
                        canvas.setAttribute('width', width);
                        canvas.setAttribute('height', height);
                        streaming = true;
                    }
                }, false);

                startbutton.addEventListener('click', function (ev) {
                    takepicture();
                    ev.preventDefault();
                }, false);

                clearphoto();
            }


            function clearphoto() {
                var context = video.getContext('2d');
                context.fillStyle = "#AAA";
                context.fillRect(0, 0, video.width, video.height);

                var data = video.toDataURL('video/mp4');
                photo.setAttribute('src', data);
            }

            function takepicture() {
                var context = video.getContext('2d');
                if (width && height) {
                    video.width = width;
                    video.height = height;
                    context.drawImage(video, 0, 0, width, height);

                    var data = video.toDataURL('video/mp4');
                    photo.setAttribute('src', data);
                } else {
                    clearphoto();
                }
            }

            window.addEventListener('load', startup, false);
        })();
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#scaninfo").show();
            $("#userinfo").hide();
            $("#invaliduser").hide();
            $("#lbl_Visitor_Name").html('');
            $("#lbl_Visitor_Email").html('');
            $("#lbl_VisitRequest_ID").html('');
            $("#lbl_Visitor_Contact").html('');

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

            $("#btn_ClickPhoto_Aadhar").click(function () {
                var width = 280; // We will scale the photo width to this
                var height = 210; // This will be computed based on the input stream
                var video = null;
                var canvas = null;
                var photo = null;

                video = document.getElementById('video');
                canvas = document.getElementById('canvas');
                photo = document.getElementById('photo');
                startbutton = document.getElementById('startbutton');

                var myVar = setInterval(myTimer, 4000);

                function myTimer() {
                    var context = canvas.getContext('2d');
                    if (width && height) {
                        video.width = width;
                        video.height = height;
                        context.drawImage(video, 0, 0, width, height);

                        var data = canvas.toDataURL('image/png');
                        photo.setAttribute('src', data);
                        InserUserImage();
                    } else {
                        var context = canvas.getContext('2d');
                        context.fillStyle = "#AAA";
                        context.fillRect(0, 0, canvas.width, canvas.height);

                        var data = canvas.toDataURL('image/png');
                        photo.setAttribute('src', data);
                    }
                }

                function myStopFunction() {
                    clearInterval(myVar);
                }

                function InserUserImage() {
                    var canvas;
                    canvas = document.getElementById('canvas');
                    var img = canvas.toDataURL('image/jpeg', 0.9).split(', ')[0];
                    var selection = 'QR-Code'
                    $.ajax({
                        url: "Verify_Visitor_ID_V2.aspx/Upload",
                        type: "POST",
                        data: "{ 'image': '" + img + "' , 'type': '" + selection + "'} ",
                        contentType: 'application/json;charset=utf-8',
                        dataType: 'json',
                        success: function (response) {
                            if (response.d != "") {
                                clearInterval(myVar);
                                $("#PhotoSuceess").show();
                                $("#m_modal_6").modal("hide");
                                $.each(response.d.split(","), function (key, val) {
                                    if (key == 0)
                                        $("#lbl_Visitor_Name").html(val);
                                    if (key == 1)
                                        $("#lbl_Visitor_Email").html(val);
                                    if (key == 2)
                                        $("#lbl_VisitRequest_ID").html(val);
                                    if (key == 3)
                                        $("#lbl_Visitor_Contact").html(val);
                                });
                                $("#userinfo").show();
                                $("#scaninfo").hide();
                                $("#invaliduser").hide();
                                toastr.success("QR CODE Scan Successfully..!");
                            }
                            else {
                                clearInterval(myVar);
                                $("#PhotoSuceess").show();
                                $("#m_modal_6").modal("hide");
                                $("#userinfo").hide();
                                $("#scaninfo").hide();
                                $("#invaliduser").show();
                                toastr.warning("There is no QR CODE inside the image..!");
                            }
                        },
                        failure: function (response) {
                            clearInterval(myVar);
                            $("#m_modal_6").modal("hide");
                            $("#userinfo").hide();
                            $("#scaninfo").hide();
                            $("#invaliduser").show();
                            toastr.warning("There is no QR CODE inside the image..!");
                        }
                    });
                }
            });



        });
    </script>
    <script type="text/javascript">



</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div id="scaninfo" class="row">
        <div class="col-md-12">
            <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" >

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

    <div id="userinfo" class="row">
        <div class="col-md-12">
            <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" >
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

                            <asp:Image ID="Img_Visitor_Photo" src="../../assets/app/media/img/users/user4.jpg" runat="server" Style="width: auto; max-height: 70px; max-width: 100%;" />

                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                            <span class="font-weight-bold">Name : </span>
                            <label id="lbl_Visitor_Name">Lokesh Devasani</label>


                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                            <span class="font-weight-bold">Email : </span>
                            <label id="lbl_Visitor_Email">ldevasani08@gmail.com</label>


                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                            <span class="font-weight-bold">Contact : </span>
                            <label id="lbl_Visitor_Contact">8898084488</label>


                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">

                            <span class="font-weight-bold">Visit Request ID : </span>
                            <label id="lbl_VisitRequest_ID">45</label>


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
                            <label id="lbl_Vacc_Date" runat="server">3rd Sep 2021</label>


                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                            <div class="col-form-label">
                                Visit Request Created on
                                <label id="lbl_Request_Date_Text" runat="server">4th Sep 2021</label>
                            </div>


                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                            <div class="col-form-label">
                                <label id="lbl_Visit_Date_Text" runat="server">
                                </label>

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


    <div id="invaliduser" class="row">
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
                            <button type="button" onclick="window.location.reload();"  class="btn btn-outline-primary m-btn m-btn--icon m-btn--outline-2x m-btn--pill m-btn--air">
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
                    <h5 class="modal-title" id="exampleModalLongTitle">Click Photo and Upload</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body m--align-center">
                    <div class="row">
                        <div class="col-xl-6">
                            <video id="video">Video stream not available.</video>
                        </div>
                        <div class="col-xl-6">
                            <canvas id="canvas">
                                <img id="photo" style="width: 14rem" alt="The screen capture will appear in this box." />
                            </canvas>
                        </div>
                    </div>


                </div>

            </div>
        </div>
    </div>
</asp:Content>
