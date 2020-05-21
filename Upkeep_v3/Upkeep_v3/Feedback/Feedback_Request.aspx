<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Feedback_Request.aspx.cs" Inherits="Upkeep_v3.Feedback.Feedback_Request" %>

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



        /*.highlight {
background-color: blanchedalmond;
}*/
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
        });

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
            // alert(infox.innerHTML);
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
                        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

                        <asp:HiddenField ID="hdnFeedbackHeaderData" runat="server" ClientIDMode="Static" />
                        <asp:HiddenField ID="hdnFeedbackHeader" runat="server" ClientIDMode="Static" />
                        <p id="info" style="display: none;"></p>
                        <p id="infox" style="display: none;"></p>

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

                                <div class="m-portlet__head-tools" style="width: 28%;">
                                    <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-md-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
                                    <a href="<%= Page.ResolveClientUrl("~/Feedback/MyFeedback.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                        <span>
                                            <i class="la la-arrow-left"></i>
                                            <span>Back</span>
                                        </span>
                                    </a>
                                    <div class="btn-group">

                                        <asp:Button ID="btnSave" runat="server" class="btn btn-accent m-btn m-btn--icon m-btn--wide m-btn--md" OnClientClick="SubmitHeader()" ValidationGroup="validateFeedback" OnClick="btnSave_Click" Text="Save" />

                                        <asp:Button ID="btnTest" Style="display: none;" runat="server" />
                                        <cc1:ModalPopupExtender ID="mpeFeedbackRequestSaveSuccess" runat="server" PopupControlID="pnlFeedbackReqestSuccess" TargetControlID="btnTest"
                                            CancelControlID="btnCloseHeader2" BackgroundCssClass="modalBackground">
                                        </cc1:ModalPopupExtender>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="m-portlet__body" style="padding: 0.4rem 2.2rem;">

                            <div class="m-portlet__body" style="padding: 0.3rem 2.2rem;">
                                <div class="form-group m-form__group row" style="padding-left: 1%;">
                                    <label class="col-md-3 form-control-label"><span style="color: red;">*</span> Visit Title :</label>
                                    <div class="col-md-4">
                                        <asp:DropDownList ID="ddlFeedbackTitle" class="form-control m-input" runat="server" OnSelectedIndexChanged="ddlFeedbackTitle_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlFeedbackTitle" Visible="true" Display="Dynamic"
                                            ValidationGroup="validateFeedback" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Visit Title"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <br />

                                 


                                <br />

                                <div class="form-group row" style="background-color: #00c5dc;">
                                    <label class="col-md-3" style="color: #ffffff; margin-top: 1%;">Visit Details</label>
                                </div>


                                <asp:Repeater ID="rptHeaderDetails" runat="server" OnItemDataBound="rptHeaderDetails_ItemDataBound">
                                    <ItemTemplate>

                                        <asp:HiddenField ID="hdnlblAnswerType" runat="server" Value='<%# Eval("Ans_Type_ID") %>' />
                                        <%--<asp:HiddenField ID="hdnlblAnswerTypeData" runat="server" Value='<%# Eval("Ans_Type_Data_ID") %>' />--%>

                                        <div class="form-group m-form__group row" style="padding-left: 1%;">
                                            <div class="col-md-3">
                                                <asp:HiddenField ID="hfHeaderId" runat="server" Value='<%# Eval("Feedback_Qn_ID") %>' />
                                                <label class="form-control-label font-weight-bold" id=' <%#Eval("Feedback_Qn_ID") %> '><span style="color: red;"><%#Eval("Is_Mandatory") %></span> &nbsp;+ &nbsp; <%#Eval("Qn_Desc") %> :</label>
                                                <asp:HiddenField ID="hdnIs_Mandatory" runat="server" Value='<%# Eval("Is_Mandatory") %>' />
                                                <asp:Label ID="lblHeaderErr" Text="" runat="server" CssClass="col-md-8 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
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


                                                <div id="divRadioButton" style="display: none" runat="server">
                                                    <asp:RadioButtonList class="m-radio-inline" runat="server" ID="divRadioButtonrdbYes" RepeatDirection="Vertical" ValidationGroup="Radio" ClientIDMode="Static" RepeatLayout="Flow" CellSpacing="1" CellPadding="1"></asp:RadioButtonList>
                                                </div>

                                                <div id="divImage" style="display: none" runat="server">
                                                    <asp:FileUpload ID="FileUpload_ChecklistImage" runat="server" ClientIDMode="Static" CssClass="btn FileUpload_ChecklistImage" Style="width: 36%;" AllowMultiple="true" />
                                                    &nbsp;
                                                    <div id="divImgBtns" style="display: none" runat="server">
                                                        <button id='btnImg' type='button' data-toggle='modal' data-target="#exampleModal" class='btn btn-accent m-btn m-btn--icon'
                                                            data-images="<%#Eval("ImagePath") %>" data-container='body' style="width: 41px; height: 41px;" data-placement='top' title='View Uploaded Image'>
                                                            <i class='la la-image' style="margin-left: -106%; font-size: 2.3rem;"></i>
                                                            <%--data-images="<%#Eval("Header_Data") %>"--%>
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
                                                    <asp:CheckBoxList ID="divCheckBoxIDI" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CellPadding="1" CellSpacing="1" ClientIDMode="Static"></asp:CheckBoxList>
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
                            </div>
                        </div>



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
