<%@ Page Title="" Language="C#" MasterPageFile="~/BlankMaster.Master" AutoEventWireup="true" CodeBehind="Visit_Request_Public.aspx.cs" Inherits="Upkeep_v3.VMS.Visit_Request_Public" %>

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
    </style>


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
                        <strong>Apply!</strong> This Request is Applied.
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
                        <label class="col-md-1 col-form-label font-weight-bold" style="padding-right: 0px;"><span class="fa fa-user"></span>Name</label>
                        <div class="col-md-3 col-form-label">
                            <%--<asp:Label ID="lblRequestDate" runat="server" Text="" CssClass="form-control-label"></asp:Label>--%>
                            <asp:TextBox ID="txtName" TextMode="SingleLine" runat="server" autocomplete="off" class="form-control m-input" placeholder="Enter Visitor Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" Visible="true" Display="Dynamic"
                                ValidationGroup="validateVMS" ForeColor="Red" ErrorMessage="Please enter Name"></asp:RequiredFieldValidator>

                        </div>
                        <label class="col-md-1 col-form-label font-weight-bold" style="padding-right: 0px;"><span class="fa fa-envelope"></span>Email</label>
                        <div class="col-md-3 col-form-label">
                            <%--<asp:Label ID="lblRequestDate" runat="server" Text="" CssClass="form-control-label"></asp:Label>--%>
                            <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" autocomplete="off" class="form-control m-input" placeholder="Enter Visitor Email ID"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" Visible="true" Display="Dynamic"
                                ValidationGroup="validateVMS" ForeColor="Red" ErrorMessage="Please enter Email"></asp:RequiredFieldValidator>

                        </div>

                        <%-- <div id="dvDepartment" runat="server" style="display: block;">--%>
                        <label class="col-md-1 col-form-label font-weight-bold" style="padding-right: 0px; padding-left: 7px;"><span class="fa fa-phone"></span>Contact</label>
                        <div class="col-md-3 col-form-label">
                            <%--<asp:Label ID="lblRequestDate" runat="server" Text="" CssClass="form-control-label"></asp:Label>--%>
                            <asp:TextBox ID="txtPhone" TextMode="Phone" runat="server" autocomplete="off" class="form-control m-input" placeholder="Enter Visitor Contact No." OnTextChanged="txtPhone_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPhone" Visible="true" Display="Dynamic"
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtVMSDate" Visible="true" Display="Dynamic"
                            ValidationGroup="validateVMS" ForeColor="Red" ErrorMessage="Please select Date"></asp:RequiredFieldValidator>

                        <%-- <div id="dvDepartment" runat="server" style="display: block;">--%>
                        <label class="col-md-2 col-form-label font-weight-bold"><span class="fa fa-user-tie"></span>Meeting with</label>
                        <div class="col-md-4 col-form-label">
                            <asp:TextBox ID="txtMeetUsers" runat="server" ClientIDMode="Static" ReadOnly="true" CssClass="form-control m-input d-inline w-75"></asp:TextBox>
                            <img src="../assets/app/media/img/icons/AddUser.png" width="32" height="32" onclick="PopUpGrid();" />
                            <input type="hidden" name="hdnMeetUsersID" id="hdnMeetUsersID" tabindex="0" value="" />
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlDepartment" Visible="true" Display="Dynamic"
ValidationGroup="validateVMS" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Department"></asp:RequiredFieldValidator>--%>
                        </div>
                        <%-- </div>--%>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtMeetUsers" Visible="true" Display="Dynamic"
                            ValidationGroup="validateVMS" ForeColor="Red" ErrorMessage="Please select Meeting Person"></asp:RequiredFieldValidator>

                    </div>


                    <br />

                    <div class="m-form__heading" style="text-align: center;">
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

                                    <div id="divRadioButton" class="m-radio-inline" style="display: none; text-align: center;" runat="server">
													<div class="m-radio-inline" style="padding-left: 0px;">
														<label class="m-radio" style="padding-left:0px;">
															<asp:RadioButtonList class="m-radio-inline " runat="server" ID="divRadioButtonrdbYes" RepeatColumns="3" RepeatDirection="Horizontal" ValidationGroup="Radio" ClientIDMode="Static" CellSpacing="10" CellPadding="10">
															</asp:RadioButtonList>
														</label>
													</div>
												</div>

                                    <div id="divImage" style="display: none" runat="server">
                                        <asp:FileUpload ID="FileUpload_ChecklistImage" runat="server" ClientIDMode="Static" CssClass="btn FileUpload_ChecklistImage" Style="width: 36%;" AllowMultiple="true" />
                                        &nbsp;
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

                    <br />
                    <%-- Covid19 assessment --%>
                    <div id="divCovid" runat="server" visible="false">
                        <div class="m-form__heading" style="text-align: center;">
                            <h3 class="m-form__heading-title" style="line-height: 2.0; background: #ffb9b9; font-size: 1.2rem; margin-bottom: 2.5rem;">Covid-19 Assessment Test</h3>
                        </div>

                        <div class="form-group row">
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
                    </div>

                    <br />
                    <br />
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

                <asp:Panel runat="server" ID="pnlMeetingUsers" CssClass="modalPopup" align="center" Style="display: none; width: 100%;">
                    <div class="" id="add_sub_location" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog" role="document" style="max-width: 60%;">
                            <div class="modal-content">
                                <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>--%>

                                <div class="modal-header">
                                    <h3 id="myModalLabel">Associate Information</h3>
                                    <button type="button" id="btnClose2" class="close" data-dismiss="modal" aria-hidden="true">×</button>

                                </div>
                                <div class="modal-body">
                                    <div class="box">
                                        <div class="nav-tabs-custom">
                                            <ul class="nav nav-tabs nav-fill" role="tablist">
                                                <li class="nav-item">
                                                    <a class="nav-link active" data-toggle="tab" href="#t1">User Info</a>
                                                </li>
                                                <li class="nav-item">
                                                    <a class="nav-link" data-toggle="tab" href="#t2">User Group Info</a>
                                                </li>
                                                <%--<li class="active">
<a href="#t1" data-toggle="tab">User Info</a>
</li>
<li>
<a href="#t2" data-toggle="tab">User Info Group</a>
</li>--%>
                                            </ul>
                                        </div>
                                        <div class="box-body">
                                            <div class="tab-content">
                                                <div class="tab-pane active" id="t1">

                                                    <br />

                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <div class="form-group m-form__group row">
                                                                <div class="col-md-3">
                                                                    <div class="m-input-icon m-input-icon--left">
                                                                        <input type="text" class="form-control m-input" placeholder="Search..." id="generalSearch" />
                                                                        <span class="m-input-icon__icon m-input-icon__icon--left">
                                                                            <span><i class="la la-search"></i></span>
                                                                        </span>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 row">
                                                                    <label class="col-form-label col-md-4">Department:</label>
                                                                    <asp:DropDownList ID="ddlDepartment" class="form-control m-input" Style="width: 40%;" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>

                                                                </div>
                                                                <div class="col-md-3" style="text-align: right;">
                                                                    <asp:Button ID="btnSelectUser" runat="server" Text="Select User" OnClick="btnSelectUser_Click" class="btn btn-primary btn-success" />
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
                                                                <EmptyDataRowStyle Height="50%" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Center" />
                                                            </asp:GridView>

                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlDepartment" EventName="SelectedIndexChanged" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </div>

                                                <div class="tab-pane" id="t2">

                                                    <br />
                                                    <div class="form-group m-form__group row">
                                                        <div class="col-md-3">
                                                            <div class="m-input-icon m-input-icon--left">
                                                                <input type="text" class="form-control m-input" placeholder="Search..." id="generalSearchGroup" />
                                                                <span class="m-input-icon__icon m-input-icon__icon--left">
                                                                    <span><i class="la la-search"></i></span>
                                                                </span>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <br />

                                                    <asp:GridView ID="grdGroupDesc" AutoGenerateColumns="false" CssClass="table table-striped- table-bordered table-hover table-checkable m-datatableGroup" runat="server" SkinID="grdSearch">
                                                        <Columns>
                                                            <asp:BoundField DataField="GroupID" Visible="false"></asp:BoundField>

                                                            <asp:TemplateField HeaderText="Action/Info Group Description" SortExpression="GroupName">
                                                                <ItemTemplate>
                                                                    <a style="cursor: pointer; text-decoration: underline;" onclick="FunEditClick('0#<%# (DataBinder.Eval(Container.DataItem,"GroupID")) %>','<%# (DataBinder.Eval(Container.DataItem,"GroupName")) %>')">
                                                                        <%# (DataBinder.Eval(Container.DataItem, "GroupName"))%>
                                                                    </a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="GroupUsers" SortExpression="GroupUsers" HeaderText="ActionInfo" ControlStyle-Width="100%"></asp:BoundField>

                                                        </Columns>

                                                        <EmptyDataTemplate>No Records Found !!!</EmptyDataTemplate>
                                                        <EmptyDataRowStyle Height="50%" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Center" />
                                                    </asp:GridView>
                                                </div>

                                            </div>
                                        </div>

                                    </div>
                                </div>

                                <%-- </ContentTemplate>--%>
                                <%--<Triggers>
<asp:AsyncPostBackTrigger ControlID="btnMeetingMstSave" EventName="Click" />
</Triggers>--%>
                                <%--</asp:UpdatePanel>--%>
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


</asp:Content>
