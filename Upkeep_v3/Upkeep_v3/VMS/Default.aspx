<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BlankMaster.Master" CodeBehind="Default.aspx.cs" Inherits="Upkeep_v3.VMS.Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="http://ajax.microsoft.com/ajax/jquery/jquery-1.4.2.js" type="text/javascript"></script>
    <script type="text/javascript" src="webcam.js"></script>

    <style>
        span {
            font-size: 20px;
        }
    </style>
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
             var canvas, context, timer;
            canvas = document.getElementById('canvas');
            var img = canvas.toDataURL('image/jpeg', 0.9).split(', ')[0];
            var selection = 'QR-Code'
            $.ajax({
                url: "HTML5Camera.aspx/Upload",
                type: "POST",
                data: "{ 'image': '" + img + "' , 'type': '" + selection + "'} ",
                contentType: 'application/json;charset=utf-8',
                dataType: 'json',
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
    <script type='text/javascript'>
        var canvas, context, timer;

        //  (HTML5 based camera only) this portion of code will be used when browser supports navigator.getUserMedia  *********     */
        window.addEventListener('DOMContentLoaded', function () {
            canvas = document.getElementById('photo'),
                context = canvas.getContext('2d'),
                video = document.getElementById('video'),
                videoObj = { 'video': true },
                errBack = function (error) {
                    console.log('Video capture error: ', error.code);
                };

            if (navigator.getUserMedia) { // Standard browser (Opera)
                document.getElementById('userMedia').style.display = '';
                // adding click event to take photo from webcam
                document.getElementById('snap').addEventListener('click', function () {
                    context.drawImage(video, 0, 0, 640, 480);
                });

                navigator.getUserMedia(videoObj, function (stream) {
                    video.src = stream;
                    video.play();
                }, errBack);
            }

            // check if we can use HTML5 based camera (through .getUserMedia() function in Webkit based browser)
            else if (navigator.webkitGetUserMedia) { // WebKit-prefixed for Google Chrome
                // display HTML5 camera
                document.getElementById('userMedia').style.display = '';
                // adding click event to take photo from webcam
                document.getElementById('snap').addEventListener('click', function () {
                    context.drawImage(video, 0, 0, 640, 480);
                });

                navigator.getUserMedia(videoObj, function (stream) {
                    video.src = stream;
                    video.play();
                }, errBack);
            }

            // check if we can use HTML5 based camera (through .getUserMedia() function in Firefox based browser)
            else if (navigator.mozGetUserMedia) { // moz-prefixed for Firefox
                // display HTML5 camera
                document.getElementById('userMedia').style.display = '';
                // adding click event to take photo from webcam
                document.getElementById('snap').addEventListener('click', function () {
                    context.drawImage(video, 0, 0, 640, 480);
                });

                navigator.getUserMedia(videoObj, function (stream) {
                    video.src = stream;
                    video.play();
                }, errBack);
            }

            else

            // if we can not use any of HTML5 based camera ways then we use Flash-based camera
            {
                // display Flash camera
                document.getElementById('flashDiv').style.display = '';
                document.getElementById('flashOut').innerHTML = (webcam.get_html(640, 480));
            }



        }, false);



        // (all type of camera) set the default selection of barcode type
        var selection = 'All barcodes (slow) ';



        // (all type of camera) gets the selection text of “barcode type to scan” combobox
        function selectType(type) {
            selection = type.options[type.selectedIndex].text;
        }
        // (HTML5 based camera only)
        // uploads the image to the server
        function UploadToCloud() {
            document.getElementById('report').innerHTML = 'scanning the current frame……';
            context.drawImage(video, 0, 0, 640, 480);
            $("#upload").attr("disabled", "disabled");
            $("#upload").attr("value", "Uploading");
            var img = canvas.toDataURL('image/jpeg', 0.9).split(', ')[1];
            // send AJAX request to the server with image data
            $.ajax({
                url: "HTML5Camera.aspx/Upload",
                type: "POST",
                data: "{ 'image': '" + img + "' , 'type': '" + selection + "'} ",
                contentType: 'application/json;charset=utf-8',
                dataType: 'json',
                // on success output the result returned by the server side (See HTML5Camera.aspx)
                success: function (data, status) {
                    $("#upload").removeAttr('disabled');
                    $("#upload").attr("value", "Upload");
                    if (data.d.length != 0) {
                        var htmlSelect = document.getElementById('OutListBoxHTML5');
                        var selectBoxOption = document.createElement("option");
                        selectBoxOption.text = data.d;
                        selectBoxOption.id = 'child';
                        htmlSelect.insertBefore(selectBoxOption, htmlSelect.childNodes[0]);
                    }
                },
                // on error just show the message that no barcodes were found
                error: function (data) {
                    document.getElementById('report').innerHTML = "no barcode found, scanning…..";
                    $("#upload").removeAttr('disabled');
                    $("#upload").attr("value", "Upload");
                },
                async: false
            });
            timer = setTimeout(UploadToCloud, 3000);  // will capture new image to detect barcode after 3000 mili second
        }
        // (flash-based camera only) stop the capturing
        function stopCall() {
            document.getElementById('report').innerHTML = "STOPPED Scanning."
            clearTimeout(timer);
        }



        // (flash-based camera only) sets the handler for callback completion to output the result
        webcam.set_hook('onComplete', 'my_completion_handler');



        // (flash-based camera only) this function will start flash to capture image and send the image to the server for further processing (for IE)
        function take_snapshot() {
            // set API to be called by flash camera
            webcam.set_api_url('FlashCamera.aspx ? type =' + selection);
            webcam.set_quality(100);
            // enable the shutter sound
            webcam.set_shutter_sound(true);
            document.getElementById('upload_results').innerHTML = '<h4>Scanning…</h4>';
            // capture image from the webcam
            webcam.snap();
            // set timeout to capture a new image (interval between captures)
            timer = setTimeout(take_snapshot, 3000);
        }

        // (flash-based camera only) this one will work after receiving barcode from server
        // this function writes the output result back to the front page (from server-side)
        function my_completion_handler(msg) {
            var str = msg;
            // encode into html compatible string
            var result = str.match('/<d>(.*?)</d > /g').map(function (val) {
                return val.replace('/</ ? d > /g, ');
            });
            // add new result into the Listbox
            var htmlSelect = document.getElementById('OutListBoxFlash');
            var selectBoxOption = document.createElement("option");
            selectBoxOption.text = result;
            selectBoxOption.id = "child";
            htmlSelect.insertBefore(selectBoxOption, htmlSelect.childNodes[0]);
            // reset webcam and flash to capture a new image. this reset process flickers a little
            webcam.reset();
        }



        // (flash-based camera only) stop the scan and set the message on the page
        function stopScanning() {
            document.getElementById('upload_results').innerHTML = "STOPPED Scanning."
            clearTimeout(timer);
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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


    <div id="userMedia" style="display: none; height: 575px; width: 1182px">
        <table>
            <tr align="left" valign="top">
                <td valign="top" colspan="2">
                    <h3 style="color: Green;">(HTML5 based camera) This works in Chrome, Firefox, Safari and other modern browsers with HTML5 support. If the HTML5 camera is not enabled then Flash-based camera should appear instead. To enable webcam access answer ALLOW when asked if you want to give access to webcam </h3>
                </td>
            </tr>
            <tr align="left" valign="top">
                <td valign="top">
                    <h2 id="choiceU"><b>Barcode Type To Scan (to start barcode scan – click START below)</b></h2>
                    <br />
                    <select id="comboBoxBarCodeTypeHTML5" onchange="selectType(this)">
                        <option value="1">All Barcodes (slow)</option>
                        <option value="2">All Linear Barcodes (Code39, Code 128 etc)</option>
                        <option value="3">All 2D Barcodes (QR Code, Aztec, Datamtrix, PDF417 and others)</option>
                        <option value="4">Code 39c</option>
                        <option value="5">Code 128</option>
                        <option value="6">EAN 13</option>
                        <option value="7">UPCA</option>
                        <option value="8">GS1-128</option>
                        <option value="9">GS1DataBarExpanded</option>
                        <option value="10">GS1DataBarExpandedStacked </option>
                        <option value="11">GS1DataBarLimited</option>
                        <option value="12">GS1DataBarOmnidirectional</option>
                        <option value="13">GS1DataBarStacked</option>
                        <option value="14">I2of5</option>
                        <option value="15">Patch Code</option>
                        <option value="16">PDF 417</option>
                        <option value="17">QR Code</option>
                        <option value="18">Datamatrix</option>
                        <option value="19">Aztec</option>
                        <option value="20">MaxiCode</option>
                    </select>
                    <br />
                    <span style="font-size: 20px;">Output barcode values read appears below: </span>
                    <br />
                    <!– decoding results appear in this listbox –>
                            <select style="width: 500px; height: 100px;" size="8" id="OutListBoxHTML5">
                            </select>
                    <br />
                    <input id="snap" style="color: black; font-weight: bold; font-size: x-large;" type="button" onclick="UploadToCloud();" value="START READING BARCODES…" />
                    <input id="pause" style="color: black;" type="button" onclick="stopCall();" value="STOP" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <h4 id="report">
                </td>
                <td valign="top">
                    <span>Webcam preview shows below:</span>
                    <video id="video" width="640" height="480"></video>
                    <!– canvas with the output –>
                            <canvas id="canvasU" width="640" height="480" style="display: none"></canvas>

                </td>
            </tr>
        </table>
    </div>
    <div id="flashDiv" style="display: none;">
        <table>
            <tr align="left" valign="top">
                <td colspan="2">
                    <h3 style="color: Green;">(FLASH based camera) This works in Internet Explorer 9+, Chrome, Firefox and other browsers with flash support. To enable web-cam access answer ALLOW when asked if you want to give access to webcam </h3>
                </td>
            </tr>
            <tr align="left" valign="top">
                <td valign="top">
                    <h4 id="choice"><b>Barcode Type To Scan (to start barcode scan – click START below)</b></h4>
                    <br />
                    <select id="comboBoxBarCodeTypeFlash" onchange="selectType(this)">
                        <option value="1">All Barcodes (slow)</option>
                        <option value="2">All Linear Barcodes (Code39, Code 128, EAN 13, UPCA, UPCE etc)</option>
                        <option value="3">All 2D Barcodes (QR Code, Aztec, Datamtrix, PDF417 and others)</option>
                        <option value="4">Code 39</option>
                        <option value="5">Code 128</option>
                        <option value="6">EAN 13</option>
                        <option value="7">UPCA</option>
                        <option value="8">GS1-128</option>
                        <option value="9">GS1DataBarExpanded</option>
                        <option value="10">GS1DataBarExpandedStacked </option>
                        <option value="11">GS1DataBarLimited</option>
                        <option value="12">GS1DataBarOmnidirectional</option>
                        <option value="13">GS1DataBarStacked</option>
                        <option value="14">I2of5</option>
                        <option value="15">Patch Code</option>
                        <option value="16">PDF 417</option>
                        <option value="17">QR Code</option>
                        <option value="18">Datamatrix</option>
                        <option value="19">Aztec</option>
                        <option value="20">MaxiCode</option>
                    </select>
                    <br />
                    <span style="font-size: 20px;">Output barcode values read appears below: </span>
                    <br />
                    <!– decoding results appear in this listbox –>
                            <select style="width: 500px; height: 100px;" size="8" id="OutListBoxFlash"></select>
                    <br />
                    <input type="button" style="color: black; font-weight: bold; font-size: x-large;" value="START READING BARCODES.." onclick="take_snapshot()" />
                    &nbsp;&nbsp;&nbsp;
                            <br />
                    <input type="button" style="color: black; font-weight: bold; font-size: x-large;" value="STOP" onclick="stopScanning()" />
                    <br />
    </div>
    <div id="upload_results" style="background-color: #eee;"></div>
    </td>
            <td>
                <div id="flashOut"></div>
            </td>
    </tr>
</table>
</asp:Content>
