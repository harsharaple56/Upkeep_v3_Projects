<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Visit_Request_Details.aspx.cs" Inherits="Upkeep_v3.VMS.Visit_Request_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style type="text/css">
        .modalBackground {
            background-color: grey;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            /*background-color: #fff;
border: 3px solid #ccc;*/
            padding: 10px;
            width: 300px;
        }

        .CovidColorBoxGreen {
            width: 100%;
            height: 30px;
            margin: 5px;
            border: 1px solid rgba(0, 0, 0, .2);
            font-size: initial;
            font-weight: bolder;
            text-align: center;
            cursor: pointer;
            color: green;
        }

        .CovidColorBoxOrange {
            width: 100%;
            height: 30px;
            margin: 5px;
            border: 1px solid rgba(0, 0, 0, .2);
            font-size: initial;
            font-weight: bolder;
            text-align: center;
            cursor: pointer;
            color: orange;
        }

        .CovidColorBoxRed {
            width: 100%;
            height: 30px;
            margin: 5px;
            border: 1px solid rgba(0, 0, 0, .2);
            font-size: initial;
            font-weight: bolder;
            text-align: center;
            cursor: pointer;
            color: red;
        }

        .CovidColorCheckGreen {
            display: none;
        }

        .CovidColorCheckOrange {
            display: none;
        }

        .CovidColorCheckRed {
            display: none;
        }

        .CovidColorCheckGreen:checked + label {
            background-color: limegreen;
            color: white;
        }

        .CovidColorCheckOrange:checked + label {
            background-color: orange;
            color: white;
        }

        .CovidColorCheckRed:checked + label {
            background-color: red;
            color: white;
        }

        .rbl input[type="radio"] {
            display: inline-block;
            margin-right: 43px;
            margin-bottom: 13px;
            height: 18px;
            width: 18px;
            color: #575962;
            box-sizing: border-box;
            padding: 0;
            position: relative;
            cursor: pointer;
            font-size: 1rem;
            -webkit-box-sizing: border-box;
            -webkit-transition: all 0.3s;
            transition: all 0.3s;
        }

        .rbl label {
            margin-right: 3%;
            width: 14%;
            font-weight: 400;
            font-size: 1rem;
        }


        /* ----------- Non-Retina Screens ----------- */
        @media screen and (min-device-width: 1200px) and (max-device-width: 1600px) and (-webkit-min-device-pixel-ratio: 1) {
            .rbl label {
                margin-right: 16%;
            }

            .rbl input[type="radio"] {
                margin-right: 1%;
            }
        }

        /* ----------- Retina Screens ----------- */
        @media screen and (min-device-width: 1200px) and (max-device-width: 1600px) and (-webkit-min-device-pixel-ratio: 2) and (min-resolution: 192dpi) {
            .rbl label {
                margin-right: 16%;
            }

            .rbl input[type="radio"] {
                margin-right: 1%;
            }
        }

        /* ----------- iPhone 4 and 4S ----------- */

        /* Portrait and Landscape */
        @media only screen and (min-device-width: 320px) and (max-device-width: 480px) and (-webkit-min-device-pixel-ratio: 2) {
            .rbl label {
                margin-right: 22%;
            }

            .rbl input[type="radio"] {
                margin-right: 5%;
            }
        }

        /* Portrait */
        @media only screen and (min-device-width: 320px) and (max-device-width: 480px) and (-webkit-min-device-pixel-ratio: 2) and (orientation: portrait) {
            .rbl label {
                margin-right: 22%;
            }

            .rbl input[type="radio"] {
                margin-right: 5%;
            }
        }

        /* Landscape */
        @media only screen and (min-device-width: 320px) and (max-device-width: 480px) and (-webkit-min-device-pixel-ratio: 2) and (orientation: landscape) {
            .rbl label {
                margin-right: 22%;
            }

            .rbl input[type="radio"] {
                margin-right: 5%;
            }
        }

        /* ----------- iPhone 5, 5S, 5C and 5SE ----------- */

        /* Portrait and Landscape */
        @media only screen and (min-device-width: 320px) and (max-device-width: 568px) and (-webkit-min-device-pixel-ratio: 2) {
            .rbl label {
                margin-right: 22%;
            }

            .rbl input[type="radio"] {
                margin-right: 5%;
            }
        }

        /* Portrait */
        @media only screen and (min-device-width: 320px) and (max-device-width: 568px) and (-webkit-min-device-pixel-ratio: 2) and (orientation: portrait) {
            .rbl label {
                margin-right: 22%;
            }

            .rbl input[type="radio"] {
                margin-right: 5%;
            }
        }

        /* Landscape */
        @media only screen and (min-device-width: 320px) and (max-device-width: 568px) and (-webkit-min-device-pixel-ratio: 2) and (orientation: landscape) {
            .rbl label {
                margin-right: 22%;
            }

            .rbl input[type="radio"] {
                margin-right: 5%;
            }
        }

        /* ----------- iPhone 6, 6S, 7 and 8 ----------- */

        /* Portrait and Landscape */
        @media only screen and (min-device-width: 375px) and (max-device-width: 667px) and (-webkit-min-device-pixel-ratio: 2) {
            .rbl label {
                margin-right: 22%;
            }

            .rbl input[type="radio"] {
                margin-right: 5%;
            }
        }

        /* Portrait */
        @media only screen and (min-device-width: 375px) and (max-device-width: 667px) and (-webkit-min-device-pixel-ratio: 2) and (orientation: portrait) {
            .rbl label {
                margin-right: 22%;
            }

            .rbl input[type="radio"] {
                margin-right: 5%;
            }
        }

        /* Landscape */
        @media only screen and (min-device-width: 375px) and (max-device-width: 667px) and (-webkit-min-device-pixel-ratio: 2) and (orientation: landscape) {
            .rbl label {
                margin-right: 22%;
            }

            .rbl input[type="radio"] {
                margin-right: 5%;
            }
        }

        /* ----------- iPhone 6+, 7+ and 8+ ----------- */

        /* Portrait and Landscape */
        @media only screen and (min-device-width: 414px) and (max-device-width: 736px) and (-webkit-min-device-pixel-ratio: 3) {
            .rbl label {
                margin-right: 22%;
            }

            .rbl input[type="radio"] {
                margin-right: 5%;
            }
        }

        /* Portrait */
        @media only screen and (min-device-width: 414px) and (max-device-width: 736px) and (-webkit-min-device-pixel-ratio: 3) and (orientation: portrait) {
            .rbl label {
                margin-right: 22%;
            }

            .rbl input[type="radio"] {
                margin-right: 5%;
            }
        }

        /* Landscape */
        @media only screen and (min-device-width: 414px) and (max-device-width: 736px) and (-webkit-min-device-pixel-ratio: 3) and (orientation: landscape) {
            .rbl label {
                margin-right: 22%;
            }

            .rbl input[type="radio"] {
                margin-right: 5%;
            }
        }

        /* ----------- iPhone X ----------- */

        /* Portrait and Landscape */
        @media only screen and (min-device-width: 375px) and (max-device-width: 812px) and (-webkit-min-device-pixel-ratio: 3) {
            .rbl label {
                margin-right: 22%;
            }

            .rbl input[type="radio"] {
                margin-right: 5%;
            }
        }

        /* Portrait */
        @media only screen and (min-device-width: 375px) and (max-device-width: 812px) and (-webkit-min-device-pixel-ratio: 3) and (orientation: portrait) {
            .rbl label {
                margin-right: 22%;
            }

            .rbl input[type="radio"] {
                margin-right: 5%;
            }
        }

        /* Landscape */
        @media only screen and (min-device-width: 375px) and (max-device-width: 812px) and (-webkit-min-device-pixel-ratio: 3) and (orientation: landscape) {
            .rbl label {
                margin-right: 22%;
            }

            .rbl input[type="radio"] {
                margin-right: 5%;
            }
        }

        /* ----------- iPad 1, 2, Mini and Air ----------- */

        /* Portrait and Landscape */
        @media only screen and (min-device-width: 768px) and (max-device-width: 1024px) and (-webkit-min-device-pixel-ratio: 1) {
            .rbl label {
                margin-right: 9%;
            }

            .rbl input[type="radio"] {
                margin-right: 5%;
            }
        }

        /* Portrait */
        @media only screen and (min-device-width: 768px) and (max-device-width: 1024px) and (orientation: portrait) and (-webkit-min-device-pixel-ratio: 1) {
            .rbl label {
                margin-right: 9%;
            }

            .rbl input[type="radio"] {
                margin-right: 5%;
            }
        }

        /* Landscape */
        @media only screen and (min-device-width: 768px) and (max-device-width: 1024px) and (orientation: landscape) and (-webkit-min-device-pixel-ratio: 1) {
            .rbl label {
                margin-right: 9%;
            }

            .rbl input[type="radio"] {
                margin-right: 5%;
            }
        }

        /* ----------- iPad 3, 4 and Pro 9.7" ----------- */

        /* Portrait and Landscape */
        @media only screen and (min-device-width: 768px) and (max-device-width: 1024px) and (-webkit-min-device-pixel-ratio: 2) {
            .rbl label {
                margin-right: 9%;
            }

            .rbl input[type="radio"] {
                margin-right: 5%;
            }
        }

        /* Portrait */
        @media only screen and (min-device-width: 768px) and (max-device-width: 1024px) and (orientation: portrait) and (-webkit-min-device-pixel-ratio: 2) {
            .rbl label {
                margin-right: 9%;
            }

            .rbl input[type="radio"] {
                margin-right: 5%;
            }
        }

        /* Landscape */
        @media only screen and (min-device-width: 768px) and (max-device-width: 1024px) and (orientation: landscape) and (-webkit-min-device-pixel-ratio: 2) {
            .rbl label {
                margin-right: 9%;
            }

            .rbl input[type="radio"] {
                margin-right: 5%;
            }
        }

        /* ----------- iPad Pro 10.5" ----------- */

        /* Portrait and Landscape */
        @media only screen and (min-device-width: 834px) and (max-device-width: 1112px) and (-webkit-min-device-pixel-ratio: 2) {
            .rbl label {
                margin-right: 9%;
            }

            .rbl input[type="radio"] {
                margin-right: 6%;
            }
        }

        /* Portrait */
        /* Declare the same value for min- and max-width to avoid colliding with desktops */
        /* Source: https://medium.com/connect-the-dots/css-media-queries-for-ipad-pro-8cad10e17106*/
        @media only screen and (min-device-width: 834px) and (max-device-width: 834px) and (orientation: portrait) and (-webkit-min-device-pixel-ratio: 2) {
            .rbl label {
                margin-right: 9%;
            }

            .rbl input[type="radio"] {
                margin-right: 6%;
            }
        }

        /* Landscape */
        /* Declare the same value for min- and max-width to avoid colliding with desktops */
        /* Source: https://medium.com/connect-the-dots/css-media-queries-for-ipad-pro-8cad10e17106*/
        @media only screen and (min-device-width: 1112px) and (max-device-width: 1112px) and (orientation: landscape) and (-webkit-min-device-pixel-ratio: 2) {
            .rbl label {
                margin-right: 9%;
            }

            .rbl input[type="radio"] {
                margin-right: 6%;
            }
        }

        /* ----------- iPad Pro 12.9" ----------- */

        /* Portrait and Landscape */
        @media only screen and (min-device-width: 1024px) and (max-device-width: 1366px) and (-webkit-min-device-pixel-ratio: 2) {
            .rbl label {
                margin-right: 9%;
            }

            .rbl input[type="radio"] {
                margin-right: 6%;
            }
        }

        /* Portrait */
        /* Declare the same value for min- and max-width to avoid colliding with desktops */
        /* Source: https://medium.com/connect-the-dots/css-media-queries-for-ipad-pro-8cad10e17106*/
        @media only screen and (min-device-width: 1024px) and (max-device-width: 1024px) and (orientation: portrait) and (-webkit-min-device-pixel-ratio: 2) {
            .rbl label {
                margin-right: 9%;
            }

            .rbl input[type="radio"] {
                margin-right: 6%;
            }
        }

        /* Landscape */
        /* Declare the same value for min- and max-width to avoid colliding with desktops */
        /* Source: https://medium.com/connect-the-dots/css-media-queries-for-ipad-pro-8cad10e17106*/
        @media only screen and (min-device-width: 1366px) and (max-device-width: 1366px) and (orientation: landscape) and (-webkit-min-device-pixel-ratio: 2) {
            .rbl label {
                margin-right: 9%;
            }

            .rbl input[type="radio"] {
                margin-right: 6%;
            }
        }
    </style>


    <%--Script for Web Cam--%>

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


    <script>

        $(document).ready(function () {
            $('.datetimepicker').datetimepicker({
                todayHighlight: true,
                autoclose: true,
                pickerPosition: 'bottom-right',
                format: 'dd-MM-yyyy HH:ii P',
                showMeridian: true,
                startDate: moment().format('dd-MM-yyyy'),
            }).on('changeDate', function (event) {
                var startDate = moment($('#txtVMSDate').val(), 'dd-MM-yyyy hh:mm A').valueOf();
                //var endDate = moment($('#endDate').val(), 'DD/MM/YYYY hh:mm A').valueOf();
                $('#error_endDate').html('').parents('.form-group').removeClass('has-error');
                //if(endDate < startDate)
                //{
                // $('#error_endDate').html('Event end date-time can not be before the start date.').parents('.form-group').addClass('has-error');
                //}
            });
        });

        //function AddRow() {
        //    var tbl = document.getElementById('ContentPlaceHolder1_tblVMSQuestion');
        //    var len = tbl.rows.length;
        //    var row = tbl.insertRow(len);
        //    for (var i = 0; i < tbl.rows[0].cells.length - 1; i++) {
        //        row.insertCell(i).innerHTML = "<input type=text id=txt" + len + "_" + i + " class='form-control' >";
        //    }
        //    //row.insertCell(tbl.rows[0].cells.length - 1).innerHTML = '<INPUT TYPE="button" ONCLICK="deleteRow(this)" class="btn btn-outline btn-circle dark btn-sm black" data-container="body" data-toggle="m-tooltip" data-placement="top" title="Delete record">';

        //    row.insertCell(tbl.rows[0].cells.length - 1).innerHTML = '<a ONCLICK="deleteRow(this)" class="btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="top" title="Delete record"> <i class="la la-trash"></i> </a>';
        //}

        //function deleteRow(obj) {
        //    var row = obj;
        //    while (row.nodeName.toLowerCase() != 'tr') {
        //        row = row.parentNode;
        //    }
        //    var tbl = document.getElementById('ContentPlaceHolder1_tblVMSQuestion');
        //    tbl.deleteRow(row.rowIndex);

        //}


        //function SubmitQuestion() {

        //    var cols_len = 0;
        //    $('#ContentPlaceHolder1_tblVMSQuestion').find('tr:first td').each(function () {
        //        var cspan = $(this).attr('colspan');
        //        if (!cspan) cspan = 1;
        //        cols_len += parseInt(cspan, 10);
        //    });

        //    document.getElementById("hdnVMSQuestionData").value = '';
        //    document.getElementById("hdnVMSQuestion").value = '';

        //    var arrDataParent = [];
        //    var arrDataChild = [];
        //    // loop over each table row (tr)
        //    $("#ContentPlaceHolder1_tblVMSQuestion tr").each(function () {
        //        var currentRow = $(this);
        //        // debugger;
        //        var k = 0;
        //        for (var j = 0; j < cols_len - 1; j++) {
        //            k = currentRow;
        //            var col1_value = currentRow.find("td:eq(" + j + ")").text();
        //            //var col2_value = currentRow.find("td:eq(1)").text();
        //            //var col3_value = currentRow.find("td:eq(2)").text();

        //            var obj = {};
        //            obj.colNo = col1_value;
        //            //obj.col2 = col2_value;
        //            //obj.col3 = col3_value;

        //            infox.innerHTML = infox.innerHTML + '#' + col1_value;
        //            arrDataChild.push(obj);
        //        }
        //        infox.innerHTML = infox.innerHTML + ',';
        //        arrDataParent.push(arrDataChild);
        //    });
        //    // alert(infox.innerHTML);
        //    // alert(JSON.stringify(arrDataParent));
        //    document.getElementById("hdnVMSQuestion").value = infox.innerHTML;
        //    var myTab = document.getElementById('ContentPlaceHolder1_tblVMSQuestion');


        //    // LOOP THROUGH EACH ROW OF THE TABLE AFTER Question.
        //    for (i = 2; i < myTab.rows.length; i++) {

        //        // GET THE CELLS COLLECTION OF THE CURRENT ROW.
        //        var objCells = myTab.rows.item(i).cells;
        //        //var objCells = myTab.rows.item(i).cells.find('input').val();

        //        // LOOP THROUGH EACH CELL OF THE CURENT ROW TO READ CELL VALUES.
        //        //for (var j = 0; j < objCells.length; j++) {
        //        for (var j = 0; j < cols_len - 1; j++) {
        //            info.innerHTML = info.innerHTML + '#' + $(myTab.rows.item(i).cells[j]).find('input').val();

        //        }
        //        info.innerHTML = info.innerHTML + ','; // ADD A BREAK (TAG).
        //    }
        //    document.getElementById("hdnVMSQuestionData").value = info.innerHTML;
        //    //alert(info.innerHTML);
        //}
        var txtControl = null;
        var txtHdn = null;
        function PopUpGrid() {
            //debugger;
            $find('<%= mpeMeetingUsers.ClientID %>').show();
            txtHdn = hdnMeetUsersID.toString();
            txtControl = txtMeetUsers;
        }

        function FunEditClick(ID, Desc) {
            //debugger;
            //alert(ID);
            //alert(Desc);
            txtControl.value = Desc.replace("$", ",");
            document.getElementById('ContentPlaceHolder1_' + txtHdn).value = ID;
//document.getElementById("<%= txtHdn.ClientID%>").value = ID;
            $find('<%= mpeMeetingUsers.ClientID %>').hide();
            // window.close();
            pnlMeetingUsers.close();
        }

        function SelectUser() {
            //alert('method call');
            //debugger;
            var SelectedUsersID = null;
            var SelectedUsersName = null;



            //var hiddenValue = $('#hdnSelectedUserID').val();
            //var hiddenValue2 = $('#hdnSelectedUserName').val();

            SelectedUsersID = document.getElementById('<%= hdnSelectedUserID.ClientID%>').value + "#0";
            SelectedUsersName = document.getElementById('<%= hdnSelectedUserName.ClientID%>').value;

            <%--//SelectedUsersID = '<%= Session["SelectedUsersID"].ToString() %>';
            //SelectedUsersName = '<%= Session["SelectedUsersName"].ToString() %>';--%>

            //alert(SelectedUsersID);
            //alert(SelectedUsersName);

            FunEditClick(SelectedUsersID, SelectedUsersName);
            // window.close();

            pnlMeetingUsers.close();
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="m-grid__item m-grid__item--fluid">
        <div class="m-content">
            <div class="row">
                <div class="col-md-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <%--<form class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmVMS" method="post">--%>
                        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

                        <asp:HiddenField ID="hdnVMSQuestionData" runat="server" ClientIDMode="Static" />
                        <asp:HiddenField ID="hdnVMSQuestion" runat="server" ClientIDMode="Static" />
                        <p id="info" style="display: none;"></p>
                        <p id="infox" style="display: none;"></p>


                        <div class="alert m-alert--default m-alert--icon" id="divAlertExpired" visible="false" runat="server" role="alert">
                            <div class="m-alert__icon">
                                <i class="la la-warning"></i>
                            </div>
                            <div class="m-alert__text">
                                <strong>Expired!</strong> This Request is Expired.
                            </div>
                        </div>
                        <div class="alert alert-warning m-alert--icon" id="divAlertOpen" visible="false" runat="server" role="alert">
                            <div class="m-alert__icon">
                                <i class="la la-warning"></i>
                            </div>
                            <div class="m-alert__text">
                                <strong>IN!</strong> This Request is Open.
                            </div>
                        </div>
                        <div class="alert alert-success m-alert--icon" id="divAlertClosed" visible="false" runat="server" role="alert">
                            <div class="m-alert__icon">
                                <i class="la la-warning"></i>
                            </div>
                            <div class="m-alert__text">
                                <strong>OUT!</strong> This Request is Closed.
                            </div>
                        </div>
                        <div class="alert alert-brand m-alert--icon" id="divAlertApply" visible="false" runat="server" role="alert">
                            <div class="m-alert__icon">
                                <i class="la la-warning"></i>
                            </div>
                            <div class="m-alert__text">
                                <strong>Apply!</strong> This Request is in Applied State.
                            </div>
                        </div>
                        <div class="alert alert-danger m-alert--icon" id="divAlertRejected" visible="false" runat="server" role="alert">
                            <div class="m-alert__icon">
                                <i class="la la-warning"></i>
                            </div>
                            <div class="m-alert__text">
                                <strong>Rejected!</strong> This Request is Rejected.
                            </div>
                        </div>

                        <div class="alert alert-brand m-alert--icon" id="divCountFull" visible="false" runat="server" role="alert">
                            <div class="m-alert__icon">
                                <i class="la la-warning"></i>
                            </div>
                            <div class="m-alert__text">
                                <strong>Covid Restriction Alert!</strong> Active Visitor Count Limit is Full. Please Mark someone OUT to raise a request.
                            </div>
                        </div>

                        <div class="alert alert-danger" id="divError" visible="False" runat="server" role="alert">
                            <asp:Label ID="lblErrorMsg" Text="" runat="server"></asp:Label>

                        </div>

                        <div class="m-portlet__head">
                            <div class="m-portlet__head-progress">

                                <!-- here can place a progress bar-->
                            </div>
                            <div class="m-portlet__head-wrapper">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">Visit Request
                                        </h3>
                                    </div>
                                </div>
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">Total number of Visitor Inside :
                                            <span id="totalNumber" runat="server">0</span>
                                        </h3>
                                    </div>
                                </div>

                                <div class="m-portlet__head-tools">

                                    <a href="<%= Page.ResolveClientUrl("~/VMS/VMSRequest_Listing.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                        <span>
                                            <i class="la la-arrow-left"></i>
                                            <span>Back</span>
                                        </span>
                                    </a>
                                    <%--<asp:Button ID="btnSave" runat="server" class="btn btn-accent m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10" OnClientClick="if(this.value === 'Saving...') { return false; } else { this.value = 'Saving...'; }SubmitQuestion()" ValidationGroup="validateVMS" OnClick="btnSave_Click" Text="Save" />--%>

                                    <asp:Button ID="btnSave" runat="server" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill" ValidationGroup="validateVMS" OnClick="btnSave_Click" Text="Save" />

                                    <asp:Button ID="btnTest" Style="display: none;" runat="server" />
                                    <cc1:ModalPopupExtender ID="mpeVMSRequestSaveSuccess" runat="server" PopupControlID="pnlVMSReqestSuccess" TargetControlID="btnTest"
                                        CancelControlID="btnCloseQuestion2" BackgroundCssClass="modalBackground">
                                    </cc1:ModalPopupExtender>
                                    <asp:Button ID="btnReject" Visible="false" OnClick="btnReject_Click" runat="server" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill" Text="Reject" />

                                </div>

                            </div>
                        </div>


                        <div class="m-portlet__body">
                            <div class="form-group m-form__group row" id="divTitle" runat="server">
                                <label class="col-md-2 col-form-label font-weight-bold">Select Visitor form</label>
                                <div class="col-md-10">
                                    <asp:DropDownList ID="ddlVMSTitle" class="form-control m-input" runat="server" OnSelectedIndexChanged="ddlVMSTitle_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlVMSTitle" Visible="true" Display="Dynamic"
                                        ValidationGroup="validateVMS" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Visit Title"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div id="divDesc" class="form-group row" runat="server">
                                <label class="col-xl-2 col-lg-3 col-form-label font-weight-bold">Description</label>
                                <div class="col-xl-9 col-lg-9 col-form-label">
                                    <span id="spnDesc" runat="server" class="form-control-label"></span>
                                </div>
                            </div>

                            <div class="m-form__heading" style="text-align: center; padding-top: 10px; padding-bottom: 10px;">
                                <h3 class="m-form__heading-title" style="line-height: 2.0; background: aliceblue; font-size: 1.2rem;">Visitor Information</h3>
                            </div>

                            <div class="form-group row">
                                <%--<div id="divNameComp" runat="server" style="display: block;">
                                    <span id="NameComp" runat="server" style="color: red;">*</span>
                                        </div>--%>
                                <label class="col-md-1 col-form-label font-weight-bold" style="padding-right: 0px;"><span class="fa fa-user"></span>Name</label>
                                <div class="col-md-3 col-form-label">
                                    <%--<asp:Label ID="lblRequestDate" runat="server" Text="" CssClass="form-control-label"></asp:Label>--%>

                                    <asp:TextBox ID="txtName" TextMode="SingleLine" runat="server" autocomplete="off" class="form-control m-input" placeholder="Enter Visitor Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Visible="true" Display="Dynamic"
                                        ValidationGroup="validateVMS" ForeColor="Red" ErrorMessage="Please enter Name"></asp:RequiredFieldValidator>

                                </div>
                                <%-- <div id="divEmailComp" runat="server" style="display: block;">
                                    <span id ="spnEmailComp" runat="server" style="color: red;">*</span>
                                        </div>--%>
                                <label class="col-md-1 col-form-label font-weight-bold" style="padding-right: 0px;"><span class="fa fa-envelope"></span>Email</label>
                                <div class="col-md-3 col-form-label">

                                    <%--<asp:Label ID="lblRequestDate" runat="server" Text="" CssClass="form-control-label"></asp:Label>--%>
                                    <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" autocomplete="off" class="form-control m-input" placeholder="Enter Visitor Email ID"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" Visible="true" Display="Dynamic" Enabled="false"
                                        ValidationGroup="validateVMS" ForeColor="Red" ErrorMessage="Please enter Email"></asp:RequiredFieldValidator>


                                    <%--        <asp:HiddenField ID="hdnIs_EmailMandatory" runat="server" Value='<%# Convert.ToBoolean(Eval("Is_EnamilMandatory"))  ? "*" : " " %>' />
                                            <asp:Label ID="lblQuestionErr" Text="" runat="server" CssClass="col-md-8 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>--%>
                                </div>
                                <%--  <div id="dvphone" runat="server" style="display: block;">
                                <span id ="SpnPhone" runat="server" style="color: red;">*</span>
                                </div>--%>
                                <%-- <div id="dvDepartment" runat="server" style="display: block;">--%>
                                <label class="col-md-1 col-form-label font-weight-bold" style="padding-right: 0px; padding-left: 7px;"><span class="fa fa-phone"></span>Contact</label>
                                <div class="col-md-3 col-form-label">

                                    <%--<asp:Label ID="lblRequestDate" runat="server" Text="" CssClass="form-control-label"></asp:Label>--%>
                                    <asp:TextBox ID="txtPhone" TextMode="Phone" runat="server" autocomplete="off" class="form-control m-input" placeholder="Enter Visitor Contact No." OnTextChanged="txtPhone_TextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvphone" runat="server" ControlToValidate="txtPhone" Visible="true" Display="Dynamic" Enabled="false"
                                        ValidationGroup="validateVMS" ForeColor="Red" ErrorMessage="Please enter Contact Number"></asp:RequiredFieldValidator>


                                </div>
                            </div>

                            <div class="form-group row">

                                <label class="col-md-2 col-form-label font-weight-bold"><span class="fa fa-calendar-alt"></span>Date of Visit</label>
                                <div class="col-md-4 col-form-label">
                                    <%--<asp:Label ID="lblRequestDate" runat="server" Text="" CssClass="form-control-label"></asp:Label>--%>

                                    <div class="input-group date">
                                        <asp:TextBox ID="txtVMSDate" runat="server" autocomplete="off" class="form-control m-input datetimepicker" placeholder="Select Visit date & time"></asp:TextBox>
                                        <div class="input-group-append">
                                            <span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
                                        </div>
                                    </div>
                                    <span id="error_startDate" class="text-danger small"></span>
                                </div>
                                <asp:RequiredFieldValidator ID="rfVMSDate" runat="server" ControlToValidate="txtVMSDate" Visible="true" Display="Dynamic"
                                    ValidationGroup="validateVMS" ForeColor="Red" ErrorMessage="Please select Date"></asp:RequiredFieldValidator>


                                <label id="div_MeetingWith1" runat="server" class="col-md-2 col-form-label font-weight-bold"><span class="fa fa-user-tie"></span>Meeting with</label>
                                <div id="div_MeetingWith2" runat="server" class="col-md-4 col-form-label">
                                    <asp:Label runat="server" ID="txtMeetUsers" class="form-control m-select2" aria-describedby="emailHelp" placeholder="Enter email">
                                    </asp:Label>
                                </div>


                            </div>

                            <div class="m-form__heading" style="text-align: center;" id="div_vaccination" visible="false" runat="server">
                                <h3 class="m-form__heading-title" style="line-height: 2.0; background: #ffaeae; font-size: 1.2rem;">Vaccination Details</h3>
                            </div>

                            <div class="form-group row" id="div_vaccination1" visible="false" runat="server">
                                <div class="col-xl-6">
                                    <div class="m-stack m-stack--ver m-stack--general m-stack--demo">
                                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                                            <iframe id="iframe_Document" runat="server" width="100%" height="621px"></iframe>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xl-6">
                                    <div class="m-stack m-stack--ver m-stack--tablet m-stack--demo">
                                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">

                                            <div class="m-card-profile__title">
                                                <b>Photo of Vaccinated Visitor</b>
                                            </div>
                                            <div class="m-card-profile">
                                                <div class="m-card-profile__pic">
                                                    <div class="m-card-profile__pic-wrapper" style="margin: 0px;">
                                                        <%--<img runat="server" id="ContentPlaceHolder1_imgProfilePic">--%>
                                                        <asp:Image ID="ContentPlaceHolder1_imgProfilePic" runat="server" />
                                                    </div>
                                                </div>
                                            </div>


                                        </div>
                                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                                            <b>Date of 2nd Dose Vaccination provided by Visitor</b> :
                                                                                            <h2 class="font-weight-bold m--font-danger">
                                                                                                <asp:Label ID="lbl_DoseDate" runat="server" CssClass="font-weight-bold m--font-danger"></asp:Label>
                                                                                            </h2>
                                            <br />

                                            <div>
                                                <h5 class="font-weight-bold m--font-danger">NOTE: Please verify if the Vaccination date shown above is mentioned in the Certificate on the Left under </h5>
                                            </div>
                                            <h4 class="m--font-success">Date of 2nd Dose ुसा डोसची तारीख</h4>
                                            <br />

                                            <div>
                                                <h5 class="font-weight-bold m--font-danger">If Date is Same , then Approve the Request , else Reject it</h5>
                                            </div>
                                        </div>
                                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">

                                            <div class="m-card-profile__title">
                                                <b>Photo of ID Proof </b>
                                            </div>
                                            <div class="m-card-profile">
                                                <div class="">
                                                    <div class="m-card-profile__pic-wrapper" style="margin: 0px;">
                                                        <asp:Image ID="IDProof" runat="server" Style="width: -webkit-fill-available; height: -webkit-fill-available;" />
                                                    </div>
                                                </div>
                                            </div>


                                        </div>

                                    </div>
                                </div>
                            </div>

                            <br />
                            <div id="dv_rpt" runat="server">
                                <div class="m-form__heading" style="text-align: center; padding-top: 10px; padding-bottom: 10px;">
                                    <h3 class="m-form__heading-title" style="line-height: 2.0; background: aliceblue; font-size: 1.2rem;">Visit Details</h3>
                                </div>


                                <asp:Repeater ID="rptQuestionDetails" runat="server" OnItemDataBound="rptQuestionDetails_ItemDataBound">
                                    <ItemTemplate>

                                        <asp:HiddenField ID="hdnAnswerTypeSDesc" runat="server" Value='<%# Eval("SDesc") %>' />
                                        <asp:HiddenField ID="hdnAnswerID" runat="server" Value='<%# Eval("Ans_Type_ID") %>' />
                                        <%--<asp:HiddenField ID="hdnlblAnswerTypeData" runat="server" Value='<%# Eval("Ans_Type_Data_ID") %>' />--%>

                                        <div class="form-group m-form__group row" style="padding-left: 1%;">
                                            <div class="col-md-3">
                                                <asp:HiddenField ID="hfQuestionId" runat="server" Value='<%# Eval("VMS_Qn_ID") %>' />
                                                <label class="form-control-label font-weight-bold" id=' <%#Eval("VMS_Qn_ID") %> '><span style="color: red;"><%# Convert.ToBoolean(Eval("Is_Mandatory"))  ? "*" : " " %></span> &nbsp; &nbsp; <%#Eval("Qn_Desc") %> :</label>
                                                <asp:HiddenField ID="hdnIs_Mandatory" runat="server" Value='<%# Convert.ToBoolean(Eval("Is_Mandatory"))  ? "*" : " " %>' />
                                                <asp:Label ID="lblQuestionErr" Text="" runat="server" CssClass="col-md-8 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
                                            </div>
                                            <div class="col-md-9">

                                                <div id="divText" style="display: none" runat="server">
                                                    <input name="divTextName" id="divTextid" type="text" class="form-control" runat="server" />
                                                </div>

                                                <div id="divNumber" style="display: none" runat="server">
                                                    <input type="number" min="0" name="divNumberName" id="divNumberid" class="form-control" runat="server" />
                                                </div>

                                                <div id="divTextArea" style="display: none" runat="server">
                                                    <textarea rows="4" cols="50" name="divTextAreaName" id="divTextAreaid" class="form-control" runat="server"></textarea>
                                                </div>

                                                <div id="divRadioButton" class="m-radio-inline" style="display: none" runat="server">
                                                    <asp:RadioButtonList CssClass="rbl" runat="server" ID="divRadioButtonrdbYes" RepeatLayout="Flow" RepeatDirection="Horizontal" ValidationGroup="Radio" ClientIDMode="Static"></asp:RadioButtonList>
                                                    <hr />
                                                </div>

                                                <div id="divImage" style="display: none" runat="server">
                                                    <asp:FileUpload ID="FileUpload_ChecklistImage" runat="server" ClientIDMode="Static" CssClass="btn FileUpload_ChecklistImage" Style="width: inherit;" AllowMultiple="true" />
                                                    &nbsp;

                                                <button type="button" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air" data-toggle="modal" data-target="#m_modal_6">

                                                    <span>
                                                        <i class="fa fa-camera"></i>
                                                        <span>Use Webcam</span>
                                                    </span>

                                                </button>



                                                    <div id="divImgBtns" style="display: none" runat="server">
                                                        <button id='btnImg' type='button' data-toggle='modal' data-target="#exampleModal" class='btn btn-accent m-btn m-btn--icon'
                                                            data-images="<%#Eval("ImagePath") %>" data-container='body' style="width: 41px; height: 41px;" data-placement='top' title='View Uploaded Image'>
                                                            <i class='la la-image' style="margin-left: -106%; font-size: 2.3rem;"></i>
                                                            <%--data-images="<%#Eval("Question_Data") %>"--%>
                                                        </button>
                                                        <asp:HiddenField ID="hdnImg" runat="server" ClientIDMode="Static" />
                                                    </div>
                                                </div>

                                                <div id="divDate" style="display: none" runat="server">
                                                    <div class="input-group date">
                                                        <asp:TextBox ID="divDateID" runat="server" autocomplete="off" class="form-control m-input datetimepicker"
                                                            placeholder="Select date & time"></asp:TextBox>
                                                        <div class="input-group-append">
                                                            <span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div id="divCheckBox" style="display: none" runat="server">
                                                    <asp:CheckBoxList ID="divCheckBoxIDI" runat="server" RepeatDirection="Horizontal" CellSpacing="5" CellPadding="5" ClientIDMode="Static"></asp:CheckBoxList>
                                                </div>
                                            </div>
                                        </div>

                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="HeaderFooter" runat="server" Text='No Records Found' CssClass="form-control-label col-form-label"
                                            Style="display: none;"></asp:Label>
                                    </FooterTemplate>

                                </asp:Repeater>
                            </div>
                            <br />
                            <div id="divCovid" runat="server" visible="false" class="m-form__heading" style="text-align: center;">
                                <h3 class="m-form__heading-title" style="line-height: 2.0; background: #ffb9b9; font-size: 1.2rem; margin-bottom: 2.5rem;">Covid-19 Assessment Test</h3>
                            </div>

                            <div class="form-group row" id="divCovid1" runat="server" visible="false">
                                <div class="col-md-6">
                                    <img src="../assets/app/media/img/misc/AarogyaQR.png" class="img-fluid" alt="qr code" />
                                </div>
                                <div class="col-md-6">
                                    <h5>Color Code:</h5>
                                    <div class="row">
                                        <div class="col-md-7">

                                            <div class="form-check">
                                                <input type="radio" id="rdbGreen" class="form-check-input CovidColorCheckGreen" name="Color" runat="server" clientidmode="Static" />
                                                <label for="rdbGreen" class="form-check-label CovidColorBoxGreen">Green</label>
                                            </div>
                                            <div class="form-check">
                                                <input type="radio" id="rdbOrange" class="form-check-input CovidColorCheckOrange" name="Color" runat="server" clientidmode="Static" />
                                                <label for="rdbOrange" class="form-check-label CovidColorBoxOrange">Orange</label>

                                            </div>
                                            <div class="form-check">
                                                <input type="radio" id="rdbRed" class="form-check-input CovidColorCheckRed" name="Color" runat="server" clientidmode="Static" />
                                                <label for="rdbRed" class="form-check-label CovidColorBoxRed">Red</label>

                                            </div>
                                        </div>
                                        <div class="col-md-5">
                                            <p class="form-text text-muted">Check your phone and select the color code displayed in your Aarogya Setu app.</p>
                                        </div>
                                    </div>
                                    <h5 class="mt-5">Assessment Date:</h5>
                                    <div class="row">
                                        <div class="input-group date">
                                            <asp:TextBox ID="txtAsmmtDate" runat="server" autocomplete="off" class="form-control m-input datetimepicker" placeholder="click here to select or enter..."></asp:TextBox>
                                            <div class="input-group-append">
                                                <span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
                                            </div>
                                        </div>
                                        <p class="form-text text-muted">It is recommended to take an assessment test as of now if possible, or else enter the most latest time..</p>

                                    </div>
                                    <h5 class="mt-5">Temperature:</h5>
                                    <div class="row">
                                        <div class="input-group date">
                                            <asp:TextBox ID="txtTemperature" TextMode="Number" step=".01" runat="server" autocomplete="off" class="form-control m-input" placeholder="enter body temperature in °C..."></asp:TextBox>
                                            <div class="input-group-append">
                                                <span class="input-group-text"><i class="fa fa-thermometer-half"></i></span>
                                            </div>
                                        </div>
                                        <%--<p class="form-text text-muted">It is recommended to take an assessment test as of now if possible, or else enter the most latest time..</p>--%>
                                    </div>
                                </div>
                            </div>

                            <div id="dv_Remark" runat="server" class="m-form__heading" style="text-align: center; padding-top: 10px; padding-bottom: 10px;">
                                <h3 class="m-form__heading-title" style="line-height: 2.0; background: #ffaeae; font-size: 1.2rem;">Remarks</h3>
                            </div>
                            <div id="dv_ClosingRemark" runat="server" class="form-group row">
                                <label class="col-md-2 col-form-label font-weight-bold" style="padding-right: 0px;"><span class="fab fa-readme"></span>Closing Remarks : </label>
                                <div class="col-md-10 col-form-label">
                                    <asp:TextBox ID="txtClosingRemarks" TextMode="SingleLine" runat="server" autocomplete="off" class="form-control m-input" placeholder="Enter Closing Remarks"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtClosingRemarks" Visible="true" Display="Dynamic"
                                        ValidationGroup="validateVMS" ForeColor="Red" ErrorMessage="Please enter Closing Remarks"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <br />
                            <br />
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

                                                <button id="startbutton" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                                                    <span>
                                                        <i class="fa fa-camera"></i>
                                                        <span>Click Photo</span>
                                                    </span>
                                                </button>
                                            </div>
                                            <div class="col-xl-6">
                                                <canvas id="canvas">
                                                    <img id="photo" style="width: 14rem" alt="The screen capture will appear in this box.">
                                                </canvas>
                                                <button id="Upload_Photo" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
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


                        <asp:Panel ID="pnlVMSReqestSuccess" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
                            <div class="" id="add_sub_location2" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document" style="max-width: 590px;">
                                    <div class="modal-content">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <div class="modal-header">
                                                    <h5 class="modal-title" id="exampleModalLabel2">Visit Request Confirmation</h5>
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseQuestion2">
                                                        <span aria-hidden="true">&times;</span>
                                                    </button>
                                                </div>
                                                <div class="modal-body">
                                                    <div class="form-group m-form__group row">
                                                        <label for="recipient-name" class="col-md-8 form-control-label">Visit Request has been submitted successfully</label>
                                                    </div>
                                                    <div class="form-group m-form__group row">
                                                        <label for="message-text" class="col-md-5 form-control-label font-weight-bold">Request ID :</label>
                                                        <asp:Label ID="lblVMSRequestCode" Text="" runat="server" CssClass="col-md-1 col-form-label" Style="padding-top: calc(0.15rem + 1px); margin-left: -10%;"></asp:Label>
                                                        <br />
                                                        <strong>Please note down your Request ID.</strong>
                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <asp:Button ID="btnSuccessOk" runat="server" class="btn btn-accent m-btn m-btn--icon m-btn--wide m-btn--md" Text="Ok" OnClick="btnSuccessOk_Click" />
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnTest" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>


                                    </div>
                                </div>
                            </div>

                        </asp:Panel>


                        <%--Panel for user selection--%>

                        <asp:Panel runat="server" ID="pnlMeetingUsers" CssClass="modalPopup" align="center" Style="display: none; width: 100%">
                            <div class="" id="add_sub_location" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>--%>

                                        <div class="modal-header">
                                            <h3 id="myModalLabel">Select Users for Meeting</h3>
                                            <button type="button" id="btnClose2" class="close" data-dismiss="modal" aria-hidden="true">×</button>

                                        </div>
                                        <div class="modal-body">
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <div class="form-group m-form__group row">
                                                        <div class="col-md-4">
                                                            <div class="m-input-icon m-input-icon--left">
                                                                <input type="text" class="form-control m-input" placeholder="Search..." id="generalSearch" />
                                                                <span class="m-input-icon__icon m-input-icon__icon--left">
                                                                    <span><i class="la la-search"></i></span>
                                                                </span>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-5">
                                                            <asp:DropDownList ID="ddlDepartment" class="form-control m-input " OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>

                                                        </div>
                                                        <div class="col-md-3" style="text-align: center;">
                                                            <asp:Button ID="btnSelectUser" runat="server" Text="Select" OnClick="btnSelectUser_Click" Style="width: inherit;" class="btn btn-primary btn-success" />
                                                        </div>
                                                    </div>
                                                    <br />

                                                    <asp:HiddenField ID="hdnSelectedUserID" runat="server" ClientIDMode="Static" />
                                                    <asp:HiddenField ID="hdnSelectedUserName" runat="server" ClientIDMode="Static" />

                                                    <asp:GridView ID="grdInfodetails" runat="server" ClientIDMode="Static" CssClass="table table-striped- table-bordered table-hover table-checkable m-datatable"
                                                        AutoGenerateColumns="false" SkinID="grdSearch" OnRowDataBound="grdInfodetails_RowDataBound" Style="display: block;">
                                                        <Columns>
                                                            <asp:BoundField DataField="User_ID" Visible="false"></asp:BoundField>
                                                            <asp:TemplateField HeaderText="Select">
                                                                <ItemTemplate>
                                                                    <%--<asp:CheckBox ID="chkUserID" runat="server" CssClass="checkbox--success" Checked='<%# Convert.ToBoolean(Eval("Is_Selected")) %>' />--%>

                                                                    <asp:CheckBox ID="chkUserID" runat="server" CssClass="m-checkbox--success" />

                                                                    <asp:HiddenField ID="hdnUserID" runat="server" Value='<%#Eval("User_ID") %>' />
                                                                    <asp:HiddenField ID="hdnUser_Name" runat="server" Value='<%#Eval("User_Name") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Action/Info Description" SortExpression="User_Name">
                                                                <ItemTemplate>
                                                                    <a style="cursor: pointer; text-decoration: underline;" onclick="FunEditClick('<%# (DataBinder.Eval(Container.DataItem,"User_ID")) %>#0','<%# (DataBinder.Eval(Container.DataItem,"User_Name")) %>')">
                                                                        <%# (DataBinder.Eval(Container.DataItem, "User_Name"))%>
                                                                    </a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="User_Name_Code" SortExpression="User_Name_Code" HeaderText="Employee"></asp:BoundField>
                                                        </Columns>

                                                        <EmptyDataTemplate>No Records Found !!!</EmptyDataTemplate>
                                                        <EmptyDataRowStyle Height="25%" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Center" />
                                                    </asp:GridView>

                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlDepartment" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>

                        <cc1:ModalPopupExtender ID="mpeMeetingUsers" runat="server" PopupControlID="pnlMeetingUsers" TargetControlID="pop2"
                            CancelControlID="btnClose2" BackgroundCssClass="modalBackground">
                        </cc1:ModalPopupExtender>

                        <asp:Button Text="text" Style="display: none" ID="pop2" runat="server" />

                        <input type="hidden" id="HdnID" runat="server" />
                        <asp:TextBox ID="txtHdn" runat="server" ClientIDMode="Static" Width="100%" Style="display: none"></asp:TextBox>






                        <%--</form>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>




