<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BlankMaster.Master" CodeBehind="QRScanWebCam.aspx.cs" Inherits="Upkeep_v3.VMS.QRScanWebCam" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
                var context = canvas.getContext('2d');
                context.fillStyle = "#AAA";
                context.fillRect(0, 0, canvas.width, canvas.height);

                var data = canvas.toDataURL('image/png');
                photo.setAttribute('src', data);
            }

            function takepicture() {
                var context = canvas.getContext('2d');
                if (width && height) {
                    canvas.width = width;
                    canvas.height = height;
                    context.drawImage(video, 0, 0, width, height);

                    var data = canvas.toDataURL('image/png');
                    photo.setAttribute('src', data);
                } else {
                    clearphoto();
                }
            }

            window.addEventListener('load', startup, false);
        })();
    </script>


    <script type="text/javascript">
        function InserUserImage() {
            $.ajax({
                type: "POST",
                url: "Visit_Request_Public.aspx/SaveUserImage",
                data: "{data: '" + $("#photo")[0].src + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    $("#PhotoSuceess").show();
                    $("#m_modal_6").modal("hide");
                    toastr.success("Your Photo Successfully Added..!");
                },
                failure: function (response) {
                    $("#m_modal_6").modal("hide");
                    toastr.error("Your Photo Not Added..!");
                }
            });
        }
    </script>
   <script src="https://raw.githubusercontent.com/mebjas/html5-qrcode/master/minified/html5-qrcode.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">
                <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

                <%-- <asp:TextBox ID="textBox1" runat="server"></asp:TextBox>
                <asp:DropDownList ID="ddltp" runat="server"></asp:DropDownList>
                <asp:Button ID="btnSave" runat="server" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill"
                    OnClick="btnSave_Click" Text="Submit" />
                <asp:Image ID="pictureBox1" runat="server"></asp:Image>
                <asp:Timer ID="Timer1" OnTick="Timer1_Tick1" runat="server" Interval="10000" />--%>

                <button type="button" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air" data-toggle="modal" data-target="#m_modal_6">

                    <span>
                        <i class="fa fa-camera"></i>
                        <span>Use Webcam</span>
                    </span>

                </button>
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

                                        <button id="startbutton" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                                            <span>
                                                <i class="fa fa-camera"></i>
                                                <span>Click Photo</span>
                                            </span>
                                        </button>
                                    </div>
                                    <div class="col-xl-6">
                                        <canvas id="canvas">
                                            <img id="photo" style="width: 14rem" alt="The screen capture will appear in this box." />
                                        </canvas>
                                        <button onclick="InserUserImage()" type="button" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                                            <span>
                                                <i class="fa fa-cloud-upload-alt"></i>
                                                <span>Upload Photo</span>
                                            </span>
                                        </button>
                                    </div>
                                </div>


                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

