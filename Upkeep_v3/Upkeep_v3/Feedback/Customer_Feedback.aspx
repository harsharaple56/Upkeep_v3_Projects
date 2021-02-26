<%@ Page Title="" Language="C#" MasterPageFile="~/BlankMaster.Master" AutoEventWireup="true" CodeBehind="Customer_Feedback.aspx.cs" Inherits="Upkeep_v3.Feedback.Customer_Feedback" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--<script src="https://cdn.jsdelivr.net/npm/sweetalert2@8.0.6/dist/sweetalert2.all.min.js"></script>
<link href="https://cdn.jsdelivr.net/npm/sweetalert2@8.0.6/dist/sweetalert2.min.css" rel="stylesheet"/>
<script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>--%>

    <style type="text/css">
        /* start Range Slider*/
        .slidecontainer {
            width: 100%;
        }

        .slider {
            -webkit-appearance: none;
            width: 100%;
            height: 15px;
            border-radius: 5px;
            background: #d3d3d3;
            outline: none;
            opacity: 0.7;
            -webkit-transition: .2s;
            transition: opacity .2s;
        }

            .slider:hover {
                opacity: 1;
            }

            .slider::-webkit-slider-thumb {
                -webkit-appearance: none;
                appearance: none;
                width: 25px;
                height: 25px;
                border-radius: 50%;
                background: #4CAF50;
                cursor: pointer;
            }

            .slider::-moz-range-thumb {
                width: 25px;
                height: 25px;
                border-radius: 50%;
                background: #4CAF50;
                cursor: pointer;
            }


        /*End Range Slider*/

        .new-react-version {
            padding: 20px 20px;
            border: 1px solid #eee;
            border-radius: 20px;
            box-shadow: 0 2px 12px 0 rgba(0,0,0,0.1);
            text-align: center;
            font-size: 14px;
            line-height: 1.7;
        }

            .new-react-version .react-svg-logo {
                text-align: center;
                max-width: 60px;
                margin: 20px auto;
                margin-top: 0;
            }





        .success-box {
            margin: 50px 0;
            padding: 10px 10px;
            border: 1px solid #eee;
            background: #f9f9f9;
        }

            .success-box img {
                margin-right: 10px;
                display: inline-block;
                vertical-align: top;
            }

            .success-box > div {
                vertical-align: top;
                display: inline-block;
                color: #888;
            }



        /* Rating Star Widgets Style */
        .rating-stars ul {
            list-style-type: none;
            padding: 0;
            -moz-user-select: none;
            -webkit-user-select: none;
        }

            .rating-stars ul > li.star {
                display: inline-block;
            }

                /* Idle State of the stars */
                .rating-stars ul > li.star > i.fa {
                    font-size: 3.5em; /* Change the size of the stars */
                    color: #ccc; /* Color on idle state */
                }

                /* Hover state of the stars */
                .rating-stars ul > li.star.hover > i.fa {
                    color: #FFCC36;
                }

                /* Selected state of the stars */
                .rating-stars ul > li.star.selected > i.fa {
                    color: #FF912C;
                }



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


        /*.highlight {
background-color: blanchedalmond;
}*/

        /*Smiley CSS*/
        .ratingSmiley {
            font-size: 45px;
        }

        .rating1:hover:before {
            content: "😠";
            position: absolute;
            font-size: 50px;
            /*width: 90px;*/
            /*margin-left: -10px;*/
        }

        .rating2:hover:before {
            content: "🙁";
            position: absolute;
            font-size: 50px;
            /*width: 90px;*/
            /*margin-left: -10px;*/
        }

        .rating3:hover:before {
            content: "😐";
            position: absolute;
            font-size: 50px;
            /*width: 90px;*/
            /*margin-left: -10px;*/
        }

        .rating4:hover:before {
            content: "😊";
            position: absolute;
            font-size: 50px;
            /*width: 90px;*/
            /*margin-left: -10px;*/
        }

        .rating5:hover:before {
            content: "😍";
            position: absolute;
            font-size: 50px;
            /*margin-left: -10px;*/
        }

        bfm
        .selectedSmiley {
            font-size: 85px;
        }
    </style>


    <script>

        $(document).ready(function () {
            $('.datetimepicker').datetimepicker({
                todayHighlight: true,
                autoclose: true,
                pickerPosition: 'bottom-right',
                format: 'dd/mm/yyyy HH:ii P',
                showMeridian: true,
                startDate: moment().format('YYYY-MM-DD'),
            }).on('changeDate', function (event) {
                var startDate = moment($('#txtFeedbackDate').val(), 'DD/MM/YYYY hh:mm A').valueOf();
                //var endDate = moment($('#endDate').val(), 'DD/MM/YYYY hh:mm A').valueOf();
                $('#error_endDate').html('').parents('.form-group').removeClass('has-error');
                //if(endDate < startDate)
                //{
                // $('#error_endDate').html('Event end date-time can not be before the start date.').parents('.form-group').addClass('has-error');
                //}
            });

            /* 1. Visualizing things on Hover - See next part for action on click */
            $('.ulStars li').on('mouseover', function () {
                var onStar = parseInt($(this).data('value'), 10); // The star currently mouse on

                // Now highlight all the stars that's not after the current hovered star
                $(this).parent().children('li.star').each(function (e) {
                    if (e < onStar) {
                        $(this).addClass('hover');
                    }
                    else {
                        $(this).removeClass('hover');
                    }
                });

            }).on('mouseout', function () {
                $(this).parent().children('li.star').each(function (e) {
                    $(this).removeClass('hover');
                });

            });


            /* 2. Action to perform on click */
            $('.ulStars li').on('click', function () {
                var onStar = parseInt($(this).data('value'), 10); // The star currently selected
                var stars = $(this).parent().children('li.star');

                for (i = 0; i < stars.length; i++) {
                    $(stars[i]).removeClass('selected');
                }

                for (i = 0; i < onStar; i++) {
                    $(stars[i]).addClass('selected');
                }

                // JUST RESPONSE (Not needed)
                var rating = parseInt($('.ulStars li.selected').last().data('value'), 10);

                $(this).parent().parent().siblings('.hdnStar').val(rating);
                //var msg = "";
                //if (ratingValue > 1) {
                //    msg = "Thanks! You rated this " + ratingValue + " stars.";
                //}
                //else {
                //    msg = "We will improve ourselves. You rated this " + ratingValue + " stars.";
                //}
                //responseMessage(msg);

            });
            $("span").click(function () {
                var Rclass = $(this).attr('class').split(" ")[0];
                var rating = Rclass.substring(6);

                $(this).siblings('.hdnEmoji').val(rating);

                var emoji = ["😶", "😠", "🙁", "😐", "😊", "😍"];
                for (var i = 1; i <= 5; i++) {
                    if (i <= rating) {
                        $(this).parent().find(".rating" + i).text(emoji[rating]);
                        $(this).parent().find(".rating" + i).addClass("selectedSmiley");


                    }
                    else {
                        $(this).parent().find(".rating" + i).text(emoji[0]);
                        $(this).parent().find(".rating" + i).removeClass("selectedSmiley");

                    }
                }

            });

            $(document).on('change', '.NPRSlider', function () {
                //alert("change");
                $(this).siblings('.NPRValue').html("Value: " + $(this).val())
            });



            //$("#ContentPlaceHolder1_m_sweetalert_demo_6").click(function () {
            //    alert('show msg');
            //    swal({ position: "center", type: "success", title: "Thanks for your valuable time, Your feedback helps us to serve you better.", showConfirmButton: !1, timer: 2500 })
            //});

            $("#ContentPlaceHolder1_m_sweetalert_demo_6").on('click', function () {
                alert('show msg2312');
                swal({ position: "center", type: "success", title: "Thanks for your valuable time, Your feedback helps us to serve you better.", showConfirmButton: !1, timer: 5500 })
                alert('show msg23125654');
            });

            //$("#m_sweetalert_demo_61").click(function () {
            //    //alert('show msg');
            //    swal({ position: "center", type: "success", title: "Thanks for your valuable time, Your feedback helps us to serve you better.", showConfirmButton: !1, timer: 5500 })
            //    //alert('show msg2312987978');
            //});

        });


        //function responseMessage(msg) {
        //    $('.success-box').fadeIn(200);
        //    $('.success-box div.text-message').html("<span>" + msg + "</span>");
        //}
        function AddRow() {
            var tbl = document.getElementById('ContentPlaceHolder1_tblFeedbackHeader');
            var len = tbl.rows.length;
            var row = tbl.insertRow(len);
            for (var i = 0; i < tbl.rows[0].cells.length - 1; i++) {
                row.insertCell(i).innerHTML = "<input type=text id=txt" + len + "_" + i + " class='form-control' >";
            }
            //row.insertCell(tbl.rows[0].cells.length - 1).innerHTML = '<INPUT TYPE="button" ONCLICK="deleteRow(this)" class="btn btn-outline btn-circle dark btn-sm black" data-container="body" data-toggle="m-tooltip" data-placement="top" title="Delete record">';

            row.insertCell(tbl.rows[0].cells.length - 1).innerHTML = '<a ONCLICK="deleteRow(this)" class="btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="top" title="Delete record"> <i class="la la-trash"></i> </a>';
        }

        function deleteRow(obj) {
            var row = obj;
            while (row.nodeName.toLowerCase() != 'tr') {
                row = row.parentNode;
            }
            var tbl = document.getElementById('ContentPlaceHolder1_tblFeedbackHeader');
            tbl.deleteRow(row.rowIndex);

        }


        function SubmitHeader() {
            //debugger;
            var cols_len = 0;
            $('#ContentPlaceHolder1_tblFeedbackHeader').find('tr:first td').each(function () {
                var cspan = $(this).attr('colspan');
                if (!cspan) cspan = 1;
                cols_len += parseInt(cspan, 10);
            });

            document.getElementById("hdnFeedbackHeaderData").value = '';
            document.getElementById("hdnFeedbackHeader").value = '';

            var arrDataParent = [];
            var arrDataChild = [];
            // loop over each table row (tr)
            $("#ContentPlaceHolder1_tblFeedbackHeader tr").each(function () {
                var currentRow = $(this);
                // debugger;
                var k = 0;
                for (var j = 0; j < cols_len - 1; j++) {
                    k = currentRow;
                    var col1_value = currentRow.find("td:eq(" + j + ")").text();
                    //var col2_value = currentRow.find("td:eq(1)").text();
                    //var col3_value = currentRow.find("td:eq(2)").text();

                    var obj = {};
                    obj.colNo = col1_value;
                    //obj.col2 = col2_value;
                    //obj.col3 = col3_value;

                    infox.innerHTML = infox.innerHTML + '#' + col1_value;
                    arrDataChild.push(obj);
                }
                infox.innerHTML = infox.innerHTML + ',';
                arrDataParent.push(arrDataChild);
            });
            //alert(infox.innerHTML);
            // alert(JSON.stringify(arrDataParent));
            document.getElementById("hdnFeedbackHeader").value = infox.innerHTML;
            var myTab = document.getElementById('ContentPlaceHolder1_tblFeedbackHeader');


            // LOOP THROUGH EACH ROW OF THE TABLE AFTER HEADER.
            for (i = 2; i < myTab.rows.length; i++) {

                // GET THE CELLS COLLECTION OF THE CURRENT ROW.
                var objCells = myTab.rows.item(i).cells;
                //var objCells = myTab.rows.item(i).cells.find('input').val();

                // LOOP THROUGH EACH CELL OF THE CURENT ROW TO READ CELL VALUES.
                //for (var j = 0; j < objCells.length; j++) {
                for (var j = 0; j < cols_len - 1; j++) {
                    info.innerHTML = info.innerHTML + '#' + $(myTab.rows.item(i).cells[j]).find('input').val();

                }
                info.innerHTML = info.innerHTML + ','; // ADD A BREAK (TAG).
            }
            document.getElementById("hdnFeedbackHeaderData").value = info.innerHTML;
            //alert(info.innerHTML);
        }
        var txtControl = null;
        var txtHdn = null;

        //Range Slider start

        //var slider = document.getElementById("myRange");
        //var output = document.getElementById("demo");
        //output.innerHTML = slider.value;




        //slider.oninput = function () {
        //    output.innerHTML = this.value;
        //}




    </script>
    <script type="text/javascript">
        function callSaveAlert() {
            //alert('hiiiiii');
            //$("#m_sweetalert_demo_61").click();
            $("#m_sweetalert_demo_61").click(function () {
                //alert('show msg');
                swal({ position: "center", type: "success", title: "Thanks for your valuable time, Your feedback helps us to serve you better.", showConfirmButton: !1, timer: 3000 })
                //alert('show msg2312987978');
                event.preventDefault()
            });
        }

        function SessionExpireAlert(timeout) {
            //alert('hiiiiii');
            //    swal({ position: "center", type: "success", title: "Thanks for your valuable time, Your feedback helps us to serve you better.", showConfirmButton: !1, timer: 3000 })

            swal({
                title: "Checking...",
                text: "Please wait",
                //imageUrl: "images/ajaxloader.gif",
                showConfirmButton: false,
                allowOutsideClick: false
            });

            //using setTimeout to simulate ajax request
            setTimeout(() => {
                swal({
                    title: "Finished!",
                    showConfirmButton: false,
                    timer: 1000
                });
            }, 2000);

        }

        function successalert() {
            swal({
                    position: "center",
                    type: "success",
                    title: "Thanks for your valuable time, Your feedback helps us to serve you better.",
                    showConfirmButton: !1,
                    timer: 3000
                })

        }

    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="">
            <div class="row">
                <div class="col-md-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <%--<form class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmFeedback" method="post">--%>
                        <cc1:ToolkitScriptManager runat="server" ScriptMode="Release"></cc1:ToolkitScriptManager>

                        <asp:HiddenField ID="hdnFeedbackHeaderData" runat="server" ClientIDMode="Static" />
                        <asp:HiddenField ID="hdnFeedbackHeader" runat="server" ClientIDMode="Static" />
                        <p id="info" style="display: none;"></p>
                        <p id="infox" style="display: none;"></p>
                        <div class="alert alert-danger" id="divStatus" visible="False" runat="server" role="alert">
                            <asp:Label ID="lblStatus" Text="" runat="server"></asp:Label>

                        </div>
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-progress">

                                <!-- here can place a progress bar-->
                            </div>
                            <div class="m-portlet__head-wrapper">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">
                                            <%--Feedback Request--%>
                                            <asp:Label ID="lblEventName" Style="font-size: large; margin-top: 0.5rem;" runat="server"></asp:Label>
                                        </h3>
                                    </div>
                                </div>

                                <div class="m-portlet__head-tools">
                                    <div id="dvBackButton" runat="server">
                                        <a href="<%= Page.ResolveClientUrl("~/Feedback/MyFeedback.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                            <span>
                                                <i class="la la-arrow-left"></i>
                                                <span>Back</span>
                                            </span>
                                        </a>
                                    </div>
                                    <div class="btn-group">

                                        <asp:Button ID="btnSave" runat="server" class="btn btn-accent m-btn m-btn--icon m-btn--wide m-btn--md" OnClientClick="if(this.value === 'Saving...') { return false; } else { this.value = 'Saving...'; }SubmitHeader();" ValidationGroup="validateFeedback" OnClick="btnSave_Click" Text="Submit Feedback" />

                                        <asp:Button ID="m_sweetalert_demo_61" ClientIDMode="Static" Style="display: none;" runat="server" Text="Popup" OnClick="btntest1_Click" />

                                        <asp:Button ID="btnTest" Style="display: none;" runat="server" />
                                        <cc1:ModalPopupExtender ID="mpeFeedbackRequestSaveSuccess" runat="server" PopupControlID="pnlFeedbackReqestSuccess" TargetControlID="btnTest"
                                            CancelControlID="btnCloseHeader2" BackgroundCssClass="modalBackground">
                                        </cc1:ModalPopupExtender>

                                        <%--<button type="button" class="btn btn-success m-btn m-btn--custom m_sweetalert_demo_6" id="m_sweetalert_demo_3" runat="server">Success</button>--%>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="m-portlet__body" style="padding: 0.4rem 2.2rem;">

                            <div class="m-portlet__body" style="padding: 0.3rem 2.2rem;">

                                <div class="form-group m-form__group row" id="dvBanner" runat="server">

                                    <%--<img alt="" src="https://compelapps.in/eFacilito_UAT/Feedback_Form_banners/Banner1.jpg" style="width: 100%; height: 225px;" />--%>
                                    <asp:Image ID="imgBanner" runat="server" Style="width: 100%; height: 225px;" />
                                </div>

                                <div class="form-group m-form__group row" style="padding-left: 1%;" id="divTitle" runat="server">
                                    <label class="col-md-3 form-control-label"><span style="color: red;">*</span> Feedback Title :</label>
                                    <div class="col-md-4">
                                        <asp:DropDownList ID="ddlFeedbackTitle" class="form-control m-input" runat="server" OnSelectedIndexChanged="ddlFeedbackTitle_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlFeedbackTitle" Visible="true" Display="Dynamic"
                                            ValidationGroup="validateFeedback" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Feedback Title"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <br />

                                <div id="divCustomer" runat="server">
                                    <div class="form-group row" style="background-color: #00c5dc;">
                                        <label class="col-md-3" style="color: #ffffff; font-size: large; margin-top: 0.5rem;">Customer Details</label>
                                    </div>


                                    <div class="m-form__section m-form__section--first">
                                        <div class="form-group m-form__group row">
                                            <label class="col-xl-3 col-lg-3 col-form-label">First Name::</label>
                                            <div class="col-xl-9 col-lg-9">
                                                <asp:TextBox ID="Fname" runat="server" class="form-control m-input" placeholder="First name"></asp:TextBox>
                                                <span id="error_First_name" class="text-danger small"></span>
                                            </div>
                                        </div>
                                        <div class="form-group m-form__group row">
                                            <label class="col-xl-3 col-lg-3 col-form-label">Last Name:</label>
                                            <div class="col-xl-9 col-lg-9">
                                                <asp:TextBox ID="Lname" runat="server" class="form-control m-input" placeholder="Last Name"></asp:TextBox>
                                                <span id="error_Last_Name" class="text-danger small"></span>
                                            </div>
                                        </div>
                                        <div class="form-group m-form__group row">
                                            <label class="col-xl-3 col-lg-3 col-form-label">Phone No:</label>
                                            <div class="col-xl-9 col-lg-9">
                                                <asp:TextBox ID="Phoneno" TextMode="Phone" runat="server" class="form-control m-input" placeholder="Phone No."></asp:TextBox>
                                                <span id="error_Phone_No" class="text-danger small"></span>
                                            </div>
                                        </div>
                                        <div class="form-group m-form__group row">
                                            <label class="col-xl-3 col-lg-3 col-form-label">EmailID:</label>
                                            <div class="col-xl-9 col-lg-9">
                                                <asp:TextBox ID="EmailID" TextMode="Email" runat="server" class="form-control m-input" placeholder="EmailID"></asp:TextBox>
                                                <span id="error_EmailID" class="text-danger small"></span>
                                            </div>
                                        </div>
                                        <div class="m-form__group form-group row">
                                            <label class="col-3 col-form-label">Gender:</label>
                                            <div class="col-9">
                                                <div class="m-radio-inline">
                                                    <label class="m-radio">
                                                        <asp:RadioButton ID="rdbMale" runat="server" GroupName="Gender" Checked="true" />
                                                        Male
																			<span></span>
                                                    </label>
                                                    <label class="m-radio">
                                                        <asp:RadioButton ID="rdbFemale" runat="server" GroupName="Gender" />
                                                        Female
																			<span></span>
                                                    </label>

                                                    <label class="m-radio">
                                                        <asp:RadioButton ID="rdbOther" runat="server" GroupName="Gender" />
                                                        Other
																			<span></span>
                                                    </label>
                                                </div>
                                                <span id="error_Gender" class="text-danger small"></span>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                                <div class="form-group row" style="background-color: #00c5dc;">
                                    <label class="col-md-3" style="color: #ffffff; font-size: large; margin-top: 0.5rem;">Feedback Details</label>
                                </div>

                                <asp:Label ID="lblFeedbackError" Text="" runat="server" ForeColor="Red"></asp:Label>
                                <br />
                                <asp:Repeater ID="rptHeaderDetails" runat="server" OnItemDataBound="rptHeaderDetails_ItemDataBound">
                                    <ItemTemplate>

                                        <asp:HiddenField ID="hdnlblAnswerType" runat="server" Value='<%# Eval("Answer_Type") %>' />
                                        <%--<asp:HiddenField ID="hdnlblAnswerTypeData" runat="server" Value='<%# Eval("Ans_Type_Data_ID") %>' />--%>

                                        <div class="form-group" style="padding-left: 1%; margin-top: 4%; text-align: center;">
                                            <asp:HiddenField ID="hfHeaderId" runat="server" Value='<%# Eval("Question_ID") %>' />
                                            <label class="form-control-label font-weight-bold" id=' <%#Eval("Question_ID") %> '>&nbsp;+ &nbsp; <%#Eval("Question") %> :</label>
                                            <%--<asp:HiddenField ID="hdnIs_Mandatory" runat="server" Value='<%# Eval("Is_Mandatory") %>' />--%>
                                            <asp:Label ID="lblHeaderErr" Text="" runat="server" CssClass="col-md-8 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>

                                            <div id="divStar" style="display: none" runat="server">
                                                <section class='rating-widget'>
                                                    <input type="hidden" clientidmode="Static" runat="server" class="hdnStar" id="hdnStar" />
                                                    <!-- Rating Stars Box -->
                                                    <div class='rating-stars text-center'>
                                                        <ul id='stars' class="ulStars">
                                                            <li class='star' title='Poor' data-value='1'>
                                                                <i class='fa fa-star fa-fw'></i>
                                                            </li>
                                                            <li class='star' title='Fair' data-value='2'>
                                                                <i class='fa fa-star fa-fw'></i>
                                                            </li>
                                                            <li class='star' title='Good' data-value='3'>
                                                                <i class='fa fa-star fa-fw'></i>
                                                            </li>
                                                            <li class='star' title='Excellent' data-value='4'>
                                                                <i class='fa fa-star fa-fw'></i>
                                                            </li>
                                                            <li class='star' title='WOW!!!' data-value='5'>
                                                                <i class='fa fa-star fa-fw'></i>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                    <div>
                                                    </div>

                                                    <div class='success-box' style="display: none;">
                                                        <div class='clearfix'></div>
                                                        <img alt='tick image' width='32' src='data:image/svg+xml;utf8;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iaXNvLTg4NTktMSI/Pgo8IS0tIEdlbmVyYXRvcjogQWRvYmUgSWxsdXN0cmF0b3IgMTkuMC4wLCBTVkcgRXhwb3J0IFBsdWctSW4gLiBTVkcgVmVyc2lvbjogNi4wMCBCdWlsZCAwKSAgLS0+CjxzdmcgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB4bWxuczp4bGluaz0iaHR0cDovL3d3dy53My5vcmcvMTk5OS94bGluayIgdmVyc2lvbj0iMS4xIiBpZD0iTGF5ZXJfMSIgeD0iMHB4IiB5PSIwcHgiIHZpZXdCb3g9IjAgMCA0MjYuNjY3IDQyNi42NjciIHN0eWxlPSJlbmFibGUtYmFja2dyb3VuZDpuZXcgMCAwIDQyNi42NjcgNDI2LjY2NzsiIHhtbDpzcGFjZT0icHJlc2VydmUiIHdpZHRoPSI1MTJweCIgaGVpZ2h0PSI1MTJweCI+CjxwYXRoIHN0eWxlPSJmaWxsOiM2QUMyNTk7IiBkPSJNMjEzLjMzMywwQzk1LjUxOCwwLDAsOTUuNTE0LDAsMjEzLjMzM3M5NS41MTgsMjEzLjMzMywyMTMuMzMzLDIxMy4zMzMgIGMxMTcuODI4LDAsMjEzLjMzMy05NS41MTQsMjEzLjMzMy0yMTMuMzMzUzMzMS4xNTcsMCwyMTMuMzMzLDB6IE0xNzQuMTk5LDMyMi45MThsLTkzLjkzNS05My45MzFsMzEuMzA5LTMxLjMwOWw2Mi42MjYsNjIuNjIyICBsMTQwLjg5NC0xNDAuODk4bDMxLjMwOSwzMS4zMDlMMTc0LjE5OSwzMjIuOTE4eiIvPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8L3N2Zz4K' />
                                                        <div class='text-message'></div>
                                                        <div class='clearfix'></div>
                                                    </div>
                                                </section>

                                            </div>
                                            <div id="divNPS" style="display: none" runat="server">
                                                <div class="slidecontainer">
                                                    <input type="range" min="1" max="10" clientidmode="Static" runat="server" value="5" class="slider NPRSlider" id="myRange" />
                                                    <p class="NPRValue">Value: 5</p>
                                                </div>
                                            </div>
                                            <div id="divTextArea" style="display: none" runat="server">
                                                <textarea rows="4" cols="50" name="divTextAreaName" id="divTextAreaid" class="form-control" runat="server"></textarea>
                                            </div>
                                            <div id="divOptions" class="text-center" style="display: none" runat="server">
                                                <asp:RadioButtonList class="m-radio-inline" Style="margin-left: 40%;" runat="server" ID="divRadioButtonrdbYes" RepeatDirection="Horizontal" ValidationGroup="Radio" ClientIDMode="Static" CellSpacing="10" CellPadding="10"></asp:RadioButtonList>
                                            </div>
                                            <div id="divOptions1" style="display: none" runat="server">
                                                <asp:CheckBoxList ID="divCheckBoxIDI" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CellPadding="1" CellSpacing="1" ClientIDMode="Static"></asp:CheckBoxList>
                                            </div>
                                            <div id="divEmoji" style="display: none" runat="server">
                                                <div class="ratingSmiley text-center">
                                                    <input type="Hidden" clientidmode="Static" runat="server" class="hdnEmoji" id="hdnEmoji" />
                                                    <span class="rating1">😶</span><span class="rating2">😶</span><span class="rating3">😶</span><span class="rating4">😶</span><span class="rating5">😶</span>

                                                </div>
                                            </div>
                                        </div>

                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="HeaderFooter" runat="server" Text='No Records Found' CssClass="form-control-label col-form-label"
                                            Style="display: none;"></asp:Label>
                                    </FooterTemplate>

                                </asp:Repeater>

                                <br />

                                <br />
                                <br />
                                <div style="text-align: center;">
                                    <asp:Button ID="Button1" runat="server" class="btn btn-accent m-btn m-btn--icon m-btn--wide m-btn--md" OnClientClick="if(this.value === 'Saving...') { return false; } else { this.value = 'Saving...'; }SubmitHeader();" ValidationGroup="validateFeedback" OnClick="btnSave_Click" Text="Submit Feedback" />
                                </div>
                                <br />
                                <br />
                            </div>
                        </div>


                        <asp:Button Text="text" Style="display: none" ID="pop2" runat="server" />

                        <input type="hidden" id="HdnID" runat="server" />
                        <asp:TextBox ID="txtHdn" runat="server" ClientIDMode="Static" Width="100%" Style="display: none"></asp:TextBox>

                        <asp:Panel ID="pnlFeedbackReqestSuccess" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
                            <div class="" id="add_sub_location2" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document" style="max-width: 590px;">
                                    <div class="modal-content">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <div class="modal-header">
                                                    <h5 class="modal-title" id="exampleModalLabel2">Feedback Request Confirmation</h5>
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseQuestion2">
                                                        <span aria-hidden="true">&times;</span>
                                                    </button>
                                                </div>
                                                <div class="modal-body">
                                                    <div class="form-group m-form__group row">
                                                        <label for="recipient-name" class="col-md-8 form-control-label">Visit Request has been submitted successfully</label>
                                                    </div>
                                                    <%-- <div class="form-group m-form__group row">
                                                        <label for="message-text" class="col-md-5 form-control-label font-weight-bold">Request ID :</label>
                                                        <asp:Label ID="lblVMSRequestCode" Text="" runat="server" CssClass="col-md-1 col-form-label" Style="padding-top: calc(0.15rem + 1px); margin-left: -10%;"></asp:Label>
                                                        <br />
                                                        <strong>Please note down your Request ID.</strong>
                                                    </div>--%>
                                                </div>
                                                <div class="modal-footer">
                                                    <asp:Button ID="btnSuccessOk" runat="server" class="btn btn-accent m-btn m-btn--icon m-btn--wide m-btn--md" Text="Ok" />
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
                        <%--</form>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
