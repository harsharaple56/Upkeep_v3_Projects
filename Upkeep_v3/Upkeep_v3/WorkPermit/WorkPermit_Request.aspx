<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="WorkPermit_Request.aspx.cs" Inherits="Upkeep_v3.WorkPermit.WorkPermit_Request" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>


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

        /*.highlight {
            background-color: blanchedalmond;
        }*/
        .auto-style1 {
            left: 0px;
            top: 15px;
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
                var startDate = moment($('#txtWorkPermitDate').val(), 'DD/MM/YYYY hh:mm A').valueOf();
                //var endDate   = moment($('#endDate').val(), 'DD/MM/YYYY hh:mm A').valueOf();
                $('#error_endDate').html('').parents('.form-group').removeClass('has-error');
                //if(endDate < startDate)
                //{
                //    $('#error_endDate').html('Event end date-time can not be before the start date.').parents('.form-group').addClass('has-error');
                //}
            });

            $('.FileUpload_ChecklistImage').on('change', function (event) {
                //alert($(this).val());
                var files = $(this).prop("files");
                var names = $.map(files, function (val) { return val.name; });
                //alert(names);
            })


            $('#exampleModal').on('show.bs.modal', function (event) {
                var button = $(event.relatedTarget); // Button that triggered the modal
                var title = button.data('title'); // Extract info from data-* attributes
                //  var images_list = button.data('images'); // Extract info from data-* attributes
                var images_list = $(button).siblings().val(); // Extract info from data-* attributes

                var modal = $(this);
                modal.find('.modal-title').text(title);
                var images = images_list.split(',')
                modal.find('.modal-body .carousel-inner').html('')
                $.each(images, function (index, image) {
                    //alert(image);
                    //image = "~/WorkPermitImages/19-03-2020/48_63_3_0.jpg";
                    if (index == 0)
                        var item = '<div class="carousel-item active">';
                    else
                        var item = '<div class="carousel-item">';
                    item += '<img class="d-block w-100" src="' + image + '"></div>'
                    modal.find('.modal-body .carousel-inner').append(item);
                });
                //$('.carousel').carousel();
            })
        });
        function AddRow(tblName) {
            var contnt = tblName
            var tbl = document.getElementById(tblName);
            var len = tbl.rows.length;
            var row = tbl.insertRow(len);
            for (var i = 0; i < tbl.rows[0].cells.length - 1; i++) {
                row.insertCell(i).innerHTML = "<input type=text id=txt" + len + "_" + i + " class='form-control' >";
            }
            row.insertCell(tbl.rows[0].cells.length - 1).innerHTML = '<a ONCLICK=deleteRow(this,"' + tblName + '") class="btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="top" title="Delete record"> 	<i class="la la-trash"></i> </a>';
        }

        function deleteRow(obj, tblName) {
            var row = obj;
            while (row.nodeName.toLowerCase() != 'tr') {
                row = row.parentNode;
            }
            var tbl = document.getElementById(tblName);
            tbl.deleteRow(row.rowIndex);
        }

        function SubmitHeader() {
            var cols_len = 0;
            $('#ContentPlaceHolder1_tblWorkPermitHeader').find('tr:first td').each(function () {
                var cspan = $(this).attr('colspan');
                if (!cspan) cspan = 1;
                cols_len += parseInt(cspan, 10);
            });
            document.getElementById("hdnWpHeaderData").value = '';
            document.getElementById("hdnWpHeader").value = '';

            var arrDataParent = [];
            var arrDataChild = [];
            // loop over each table row (tr)
            $("#ContentPlaceHolder1_tblWorkPermitHeader tr").each(function () {
                var currentRow = $(this);
                var k = 0;
                for (var j = 0; j < cols_len - 1; j++) {
                    k = currentRow;
                    var col1_value = currentRow.find("td:eq(" + j + ")").text();
                    var obj = {};
                    obj.colNo = col1_value;
                    infox.innerHTML = infox.innerHTML + '#' + col1_value;
                    arrDataChild.push(obj);
                }
                infox.innerHTML = infox.innerHTML + ',';
                arrDataParent.push(arrDataChild);
            });
            document.getElementById("hdnWpHeader").value = infox.innerHTML;
            var myTab = document.getElementById('ContentPlaceHolder1_tblWorkPermitHeader');
            // LOOP THROUGH EACH ROW OF THE TABLE AFTER HEADER.
            for (i = 2; i < myTab.rows.length; i++) {
                // GET THE CELLS COLLECTION OF THE CURRENT ROW.
                var objCells = myTab.rows.item(i).cells;
                // LOOP THROUGH EACH CELL OF THE CURENT ROW TO READ CELL VALUES. 
                for (var j = 0; j < cols_len - 1; j++) {
                    info.innerHTML = info.innerHTML + '#' + $(myTab.rows.item(i).cells[j]).find('input').val();
                }
                info.innerHTML = info.innerHTML + ',';     // ADD A BREAK (TAG).
            }
            document.getElementById("hdnWpHeaderData").value = info.innerHTML;
        }

    </script>

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <%--<form class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmWorkPermit" method="post">--%>
                        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

                        <asp:HiddenField ID="hdnWpHeaderData" runat="server" ClientIDMode="Static" />
                        <asp:HiddenField ID="hdnWpHeader" runat="server" ClientIDMode="Static" />
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
                        <div class="alert alert-success m-alert--icon" id="divAlertClosed" visible="false" runat="server" role="alert">
                            <div class="m-alert__icon">
                                <i class="la la-warning"></i>
                            </div>
                            <div class="m-alert__text">
                                <strong>Closed!</strong> This Request is Closed.
                            </div>
                        </div>
                        <div class="alert alert-warning m-alert--icon" id="divAlertOpen" visible="false" runat="server" role="alert">
                            <div class="m-alert__icon">
                                <i class="la la-warning"></i>
                            </div>
                            <div class="m-alert__text">
                                <strong>Open!</strong> This Request is Open.
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
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-progress">
                            </div>
                            <div class="m-portlet__head-wrapper">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">Work Permit Request
                                        </h3>
                                    </div>
                                </div>

                                <div class="m-portlet__head-tools" style="width: 28%;">
                                    <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
                                    <%--<a href="<%= Page.ResolveClientUrl("~/WorkPermit/MyWorkPermit.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                            <span>
                                                <i class="la la-arrow-left"></i>
                                                <span>Back</span>
                                            </span>
                                        </a>--%>
                                    <a href="<%= Page.ResolveClientUrl( Session["PreviousURL"].ToString()) %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                        <span>
                                            <i class="la la-arrow-left"></i>
                                            <span>Back</span>
                                        </span>
                                    </a>
                                    <div class="btn-group">

                                        <asp:Button ID="btnSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" ValidationGroup="validateTicket" OnClick="btnSave_Click" Text="Save" Style="display: none" />
                                        <asp:Button ID="btnTest" Style="display: none;" runat="server" />
                                        <cc1:ModalPopupExtender ID="mpeWpRequestSaveSuccess" runat="server" PopupControlID="pnlWpReqestSuccess" TargetControlID="btnTest"
                                            CancelControlID="btnCloseHeader2" BackgroundCssClass="modalBackground">
                                        </cc1:ModalPopupExtender>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="m-portlet__body" style="padding: 0.4rem 2.2rem;">

                            <div class="m-portlet__body" style="padding: 0.3rem 2.2rem;">
                                <div class="form-group m-form__group row" style="padding-left: 1%;">
                                    <label class="col-xl-3 col-form-label font-weight-bold"><span style="color: red;" class="col-x-1">*</span>Work Permit Title :</label>
                                    
                                    <div class="col-xl-4">
                                        <asp:DropDownList ID="ddlWorkPermitTitle" class="form-control m-input" runat="server" OnSelectedIndexChanged="ddlWorkPermitTitle_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlWorkPermitTitle" Visible="true" Display="Dynamic"
                                            ValidationGroup="validateWorkPermit" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Work Permit Title"></asp:RequiredFieldValidator>
                                    </div>
                                    <label class="col-xl-2 col-form-label font-weight-bold" runat="server" visible="false" id="lblTicketNo">Ticket No. :</label>
                                    <div class="col-xl-2">
                                        <div class="col-form-label">
                                            <asp:Label ID="lblTicket" runat="server" Text="" CssClass="form-control-label" Visible="false"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group m-form__group row" id="divStatus" runat="server" visible="false" style="padding-left: 1%;">
                                    <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Request Status :</label>
                                    <div class="col-xl-3 col-lg-3 col-form-label">
                                        <asp:Label ID="lblRequestStatus" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <br />

                                <div class="form-group row" style="background-color: #00c5dc;">
                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Initiator Details</label>
                                </div>

                                <div id="dvEmployee" runat="server" style="display: block;">
                                    <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                        <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Employee Name :</label>
                                        <div class="col-xl-3 col-lg-3 col-form-label">
                                            <asp:Label ID="lblEmpName" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                        </div>

                                        <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold" style="text-align: right;">Employee Code :</label>
                                        <div class="col-xl-3 col-lg-3 col-form-label">
                                            <asp:Label ID="lblEmpCode" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                        </div>

                                    </div>
                                </div>

                                <div id="dvRetailer" runat="server" style="display: block;">
                                    <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                        <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Store Name :</label>
                                        <div class="col-xl-3 col-lg-3 col-form-label">
                                            <asp:Label ID="lblStoreName" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                        </div>

                                        <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Manager Name :</label>
                                        <div class="col-xl-3 col-lg-3 col-form-label">
                                            <asp:Label ID="lblRetailerName" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                        </div>

                                    </div>

                                </div>
                                <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                    <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Mobile No. :</label>
                                    <div class="col-xl-3 col-lg-3 col-form-label">
                                        <asp:Label ID="lblMobileNo" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                    </div>

                                    <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Email ID :</label>
                                    <div class="col-xl-3 col-lg-3 col-form-label">
                                        <asp:Label ID="LblEmailID" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                    </div>

                                </div>

                                <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                    <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">From Date :</label>
                                    <div class="col-xl-3 col-lg-3 col-form-label">
                                        <%--<asp:Label ID="lblRequestDate" runat="server" Text="" CssClass="form-control-label"></asp:Label>--%>
                                        <div class="input-group date">
                                            <asp:TextBox ID="txtWorkPermitDate" runat="server" autocomplete="off" class="form-control m-input datetimepicker" placeholder="Select Work Permit date & time"></asp:TextBox>
                                            <div class="input-group-append">
                                                <span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
                                            </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtWorkPermitDate" Visible="true" Display="Dynamic"
                                                ValidationGroup="validateWorkPermit" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Work Permit Date"></asp:RequiredFieldValidator>
                                        </div>
                                        <span id="error_startDate" class="text-danger small"></span>
                                    </div>

                                    <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">To Date :</label>
                                    <div class="col-xl-3 col-lg-3 col-form-label">
                                        <%--<asp:Label ID="lblRequestDate" runat="server" Text="" CssClass="form-control-label"></asp:Label>--%>
                                        <div class="input-group date">
                                            <asp:TextBox ID="txtWorkPermitToDate" runat="server" autocomplete="off" class="form-control m-input datetimepicker" placeholder="Select Work Permit date & time"></asp:TextBox>
                                            <div class="input-group-append">
                                                <span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
                                            </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtWorkPermitToDate" Visible="true" Display="Dynamic"
                                                ValidationGroup="validateWorkPermit" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Work Permit Date"></asp:RequiredFieldValidator>
                                        </div>
                                        <span id="error_startDate" class="text-danger small"></span>
                                    </div>
                                </div>


                                <br />


                                <%--    <div class="form-group row" style="background-color: #00c5dc;">
                                        <label class="auto-style1" style="color: #ffffff; margin-top: 1%;">Work Permit Details</label>
                                    </div>--%>

                                <%--<div class="form-group m-form__group row" style="padding-left: 1%;">--%>

                                <%--<label class="col-xl-3 col-lg-2 form-control-label"><span style="color: red;">*</span> Work Permit Type :</label>--%>

                                <%--<div class="col-xl-4 col-lg-4">--%>

                                <%--<asp:DropDownList ID="ddlWorkPermitType" class="form-control m-input" runat="server"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlWorkPermitType" Visible="true" Display="Dynamic"
                                                ValidationGroup="validateWorkPermit" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Work Permit Type"></asp:RequiredFieldValidator>--%>

                                <%--</div>
                                    </div>--%>


                                <asp:Label ID="lbTable" runat="server" />


                                <asp:Repeater ID="rptSectionDetails" runat="server" OnItemDataBound="rptSectionDetails_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hfCustomerId" runat="server" Value='<%# Eval("WP_Section_ID") %>' />
                                        <div class="form-group row" style="background-color: #00c5dc;" id="DivSectionID">
                                            <label class="auto-style1" style="color: #ffffff; margin-top: 1%; display: none" id="DivSectionIDLabel" runat="server"><%#Eval("WP_Section_ID") %>  </label>
                                            <label class="auto-style1" style="color: #ffffff; margin-top: 1%;">&nbsp; &nbsp; <%#Eval("WP_Section_Desc") %>  </label>
                                        </div>

                                        <%--<div class="m-portlet__body" style="overflow-x: scroll;">--%>
                                        <asp:Repeater ID="rptHeaderDetails" runat="server" OnItemDataBound="rptHeaderDetails_ItemDataBound">
                                            <ItemTemplate>

                                                <asp:HiddenField ID="hdnAnswerTypeSDesc" runat="server" Value='<%# Eval("SDesc") %>' />
                                                <asp:HiddenField ID="hdnlblAnswerType" runat="server" Value='<%# Eval("Ans_Type_ID") %>' />
                                                <%--<asp:HiddenField ID="hdnlblAnswerTypeData" runat="server" Value='<%# Eval("Ans_Type_Data_ID") %>' />--%>

                                                <div class="form-group m-form__group row" style="padding-left: 1%;">
                                                    <div class="col-xl-3 col-lg-3">
                                                        <asp:HiddenField ID="hfHeaderId" runat="server" Value='<%# Eval("WP_Header_ID") %>' />
                                                        <label class="form-control-label font-weight-bold" id=' <%#Eval("WP_Header_ID") %> '><span style="color: red;"><%#Eval("Is_Mandatory") %></span> &nbsp;+ &nbsp;  <%#Eval("Header_Name") %>  :</label>
                                                        <asp:HiddenField ID="hdnIs_Mandatory" runat="server" Value='<%# Eval("Is_Mandatory") %>' />

                                                        <asp:Label ID="lblIsMandatory" Text="*" runat="server" CssClass="col-xl-8 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold; display: none;"></asp:Label>

                                                        <asp:Label ID="lblHeaderErr" Text="" runat="server" CssClass="col-xl-8 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
                                                    </div>
                                                    <div class="col-xl-9 col-lg-9">
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
                                                            <asp:RadioButtonList class="m-radio-inline" runat="server" ID="divRadioButtonrdbYes" RepeatColumns="5" RepeatDirection="Horizontal" ValidationGroup="Radio" ClientIDMode="Static" CellSpacing="5" CellPadding="5"></asp:RadioButtonList>
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
                                                            <asp:CheckBoxList class="CheckBoxList11" ID="divCheckBoxIDI" runat="server" RepeatColumns="5" RepeatDirection="Horizontal" CellPadding="5" CellSpacing="5" ClientIDMode="Static"></asp:CheckBoxList>
                                                        </div>
                                                    </div>
                                                </div>

                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Label ID="HeaderFooter" runat="server" Text='No Records Found' CssClass="form-control-label col-form-label"
                                                    Style="display: none;"></asp:Label>
                                            </FooterTemplate>

                                        </asp:Repeater>
                                        <%--</div>--%>
                                    </ItemTemplate>
                                </asp:Repeater>



                                <div class="form-group row" style="background-color: #00c5dc;">
                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Work Permit Terms & Conditions</label>
                                </div>
                                <asp:Repeater ID="rptTermsCondition" runat="server" ClientIDMode="Static">
                                    <ItemTemplate>
                                        <table style="width: 100%">
                                            <tr>
                                                <td>
                                                    <asp:CheckBox runat="server" ID="chkTermsCondition" />
                                                </td>
                                                <td style="width: 5%">
                                                    <asp:Label ID="lblTermID" runat="server" Text='<%#Eval("Wp_Terms_ID") %>' Style="display: none;"></asp:Label>
                                                </td>
                                                <td style="width: 90%" colspan="2">
                                                    <asp:Label ID="lblTermDesc" runat="server" Text='<%#Eval("Terms_Desc") %>' ClientIDMode="Static" CssClass="form-control-label col-form-label font-weight-bold"></asp:Label>
                                                </td>

                                            </tr>
                                            <br />
                                        </table>
                                    </ItemTemplate>
                                </asp:Repeater>

                                <br />

                                <div class="form-group row" style="background-color: #00c5dc;">
                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Approval Matrix</label>
                                </div>
                                <div>
                                    <asp:GridView ID="gvApprovalMatrix" runat="server" CssClass="table table-hover table-striped" HorizontalAlign="Center" AutoGenerateColumns="true"></asp:GridView>
                                </div>
                                <br />


                                <div id="dvApprovalHistory" runat="server">
                                    <div class="form-group row" style="background-color: #00c5dc;">
                                        <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Work Permit Approval History</label>
                                    </div>
                                    <div>
                                        <asp:GridView ID="gvApprovalHistory" runat="server" CssClass="table table-hover table-striped" HorizontalAlign="Center" AutoGenerateColumns="False">

                                            <Columns>
                                                <asp:BoundField DataField="Level" HeaderText="Level" />
                                                <asp:BoundField DataField="Approver" HeaderText="Approver" />
                                                <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                                <asp:BoundField DataField="Action Date" HeaderText="Action Date" />
                                                <asp:BoundField DataField="Status" HeaderText="Status" />
                                                <asp:TemplateField HeaderText="Signature" HeaderStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <asp:Image ID="imgSignature" Height="100" Width="100" runat="server" AlternateText="Signature Missing.."
                                                            ImageUrl='<%# ResolveUrl(Eval("Emp_Sign").ToString()) %>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <br />

                                <div class="form-group row" style="background-color: #00c5dc;" id="dvApprovalDetHeader" runat="server">
                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Work Permit Approval Details</label>
                                </div>
                                <div class="form-group m-form__group row" style="padding-left: 1%;" id="dvApprovalDetails" runat="server">
                                    <label class="col-xl-2 col-lg-2 form-control-label font-weight-bold"><span style="color: red;">*</span> Action :</label>
                                    <div class="col-xl-2 col-lg-4">
                                        <asp:DropDownList ID="ddlAction" class="form-control m-input" runat="server"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlAction" Visible="true" Display="Dynamic"
                                            ValidationGroup="validateWP" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Action"></asp:RequiredFieldValidator>
                                    </div>

                                    <label class="col-xl-2 col-lg-2 form-control-label font-weight-bold"><span style="color: red;">*</span> Remarks :</label>
                                    <div class="col-xl-6 col-lg-4">
                                        <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" class="form-control m-input autosize_textarea TermCondition_textarea"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRemarks" Visible="true" Display="Dynamic"
                                            ValidationGroup="validateWP" ForeColor="Red" ErrorMessage="Please enter Remarks"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div id="divInsertButton" class="col-lg-9 ml-lg-auto" runat="server">
                                    <%--OnClientClick="SubmitHeader()" --%>
                                    <asp:Button ID="btnSubmit" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Style="margin-right: 20px;" OnClick="btnSubmit_Click" Text="Submit" ValidationGroup="validateWorkPermit" />
                                    <asp:Button ID="btnCancel" runat="server" class="btn btn-secondary btn-outline-hover-danger btn-sm m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10" Style="margin-right: 20px;" OnClick="btnCancel_Click" Text="Cancel" />
                                </div>
                                    <asp:Label ID="lblErrorMsg1" Text="" runat="server" CssClass="col-xl-8 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>


                                <div class="col-lg-9 ml-lg-auto" style="display: none" id="divUpdateButton" runat="server">
                                    <asp:Button ID="btnApprove" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Style="margin-right: 20px;" Text="Submit" OnClick="btnApprove_Click" ValidationGroup="validateWP" />
                                    <asp:Label ID="LabelERRORmsg" Text="" runat="server" CssClass="col-xl-8 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
                                </div>

                                <br />
                                <br />
                            </div>
                        </div>

                        <asp:Panel ID="pnlWpReqestSuccess" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
                            <div class="" id="add_sub_location2" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document" style="max-width: 590px;">
                                    <div class="modal-content">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <div class="modal-header">
                                                    <h5 class="modal-title" id="exampleModalLabel2">Work Permit Request Confirmation</h5>
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader2">
                                                        <span aria-hidden="true">&times;</span>
                                                    </button>
                                                </div>
                                                <div class="modal-body">
                                                    <div class="form-group m-form__group row">
                                                        <label for="recipient-name" class="col-xl-8 col-lg-3 form-control-label">Work Permit Request has been saved successfully</label>
                                                    </div>
                                                    <div class="form-group m-form__group row">
                                                        <label for="message-text" class="col-xl-5 col-lg-3 form-control-label font-weight-bold">Ticket No :</label>
                                                        <asp:Label ID="lblWpRequestCode" Text="" runat="server" CssClass="col-xl-1 col-lg-3 col-form-label" Style="padding-top: calc(0.15rem + 1px); margin-left: -10%;"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <asp:Button ID="btnSuccessOk" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="Ok" OnClick="btnSuccessOk_Click" />
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



                        <div aria-hidden="true" aria-labelledby="exampleModalLabel" class="modal fade" id="exampleModal" role="dialog" tabindex="-1">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="exampleModalLabel">Uploaded Image</h5>
                                        <button aria-label="Close" class="close" data-dismiss="modal" type="button">
                                            <span aria-hidden="true">×</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <div class="carousel slide" data-ride="carousel" id="carouselExampleControls">
                                            <div class="carousel-inner">
                                            </div>
                                            <a class="carousel-control-prev" data-slide="prev" href="#carouselExampleControls" role="button">
                                                <span aria-hidden="true" class="carousel-control-prev-icon"></span>
                                                <span class="sr-only">Previous</span>
                                            </a>
                                            <a class="carousel-control-next" data-slide="next" href="#carouselExampleControls" role="button">
                                                <span aria-hidden="true" class="carousel-control-next-icon"></span>
                                                <span class="sr-only">Next </span>
                                            </a>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>


                        <%--</form>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
