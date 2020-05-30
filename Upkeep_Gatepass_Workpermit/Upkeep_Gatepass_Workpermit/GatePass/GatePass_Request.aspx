<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="GatePass_Request.aspx.cs" Inherits="Upkeep_Gatepass_Workpermit.GatePass.GatePass_Request" %>

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
                var startDate = moment($('#txtGatePassDate').val(), 'DD/MM/YYYY hh:mm A').valueOf();
                //var endDate   = moment($('#endDate').val(), 'DD/MM/YYYY hh:mm A').valueOf();
                $('#error_endDate').html('').parents('.form-group').removeClass('has-error');
                //if(endDate < startDate)
                //{
                //    $('#error_endDate').html('Event end date-time can not be before the start date.').parents('.form-group').addClass('has-error');
                //}
            });
        });
    </script>

    <script>
        //$(function () {

        //    $("#btnAddNew").click(function () {
        //        //var row = $('#ContentPlaceHolder1_tblGatePassHeader tr').eq(1);
        //        //var row = $('#ContentPlaceHolder1_tblGatePassHeader tr:first').html();
        //        ////$("#maintable").append("<tr> <td> New Row</td> </tr>")
        //        ////alert(row);
        //        //$("#ContentPlaceHolder1_tblGatePassHeader").append("<tr>" + row + "</tr>");

        //        // $('#ContentPlaceHolder1_tblGatePassHeader > tbody > tr').eq(1).after(row); 

        //        var tbl = document.getElementById('ContentPlaceHolder1_tblGatePassHeader');
        //        var len = tbl.rows.length;
        //        var row = tbl.insertRow(len);
        //        for (var i = 0; i < tbl.rows[0].cells.length; i++) {
        //            row.insertCell(i).innerHTML = "<input type=text>";
        //        }
        //        //row.insertCell(tbl.rows[0].cells.length-1).innerHTML='<INPUT TYPE="button" ONCLICK="delRow(this)" VALUE="Delete Row">';

        //    });
        //})
    </script>
    <script>
        function AddRow() {
            var tbl = document.getElementById('ContentPlaceHolder1_tblGatePassHeader');
            var len = tbl.rows.length;
            var row = tbl.insertRow(len);
            for (var i = 0; i < tbl.rows[0].cells.length - 1; i++) {
                row.insertCell(i).innerHTML = "<input type=text id=txt" + len + "_" + i + " class='form-control' >";
            }
            //row.insertCell(tbl.rows[0].cells.length - 1).innerHTML = '<INPUT TYPE="button" ONCLICK="deleteRow(this)" class="btn btn-outline btn-circle dark btn-sm black" data-container="body" data-toggle="m-tooltip" data-placement="top" title="Delete record">';

            row.insertCell(tbl.rows[0].cells.length - 1).innerHTML = '<a ONCLICK="deleteRow(this)" class="btn btn-danger m-btn m-btn--icon btn-sm m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="top" title="Delete record"> 	<i class="la la-trash"></i> </a>';
        }

        function deleteRow(obj) {
            var row = obj;
            while (row.nodeName.toLowerCase() != 'tr') {
                row = row.parentNode;
            }
            var tbl = document.getElementById('ContentPlaceHolder1_tblGatePassHeader');
            tbl.deleteRow(row.rowIndex);

        }


        function SubmitHeader() {
            //alert('sdf');
            // debugger;
            //var GPHeadersData = new Array();
            //var tbl = document.getElementById('ContentPlaceHolder1_tblGatePassHeader');
            //var row_len = tbl.rows.length;
            ////var Column_len = tbl.columns.

            //    $('#myRepeater input[type="checkbox"]').each(function () {
            //        if ($(this).prop('checked') == false) {
            //        alert('Please select');
            //    }
            //});



            var cols_len = 0;
            $('#ContentPlaceHolder1_tblGatePassHeader').find('tr:first td').each(function () {
                var cspan = $(this).attr('colspan');
                if (!cspan) cspan = 1;
                cols_len += parseInt(cspan, 10);
            });
            //alert(cols_len)

            //for (var i = 1; i < tbl.rows.length; i++) {
            //    //Reference the Table Row.
            //    var row = tbl.rows[i];

            //    //Copy values from Table Cell to JSON object.
            //    var Gp_HeaderColumns = {};
            //    for (var j = 1; j < cols_len-1; j++) {
            //        Gp_HeaderColumns.j = row.cells[j].innerHTML;
            //        GPHeadersData.push(Gp_HeaderColumns);
            //    }
            //}
            //alert(JSON.stringify(GPHeadersData));
            //document.getElementsByName("hdnGpHeaderData")[0].value = JSON.stringify(GPHeadersData);

            //document.getElementById("ColHeaderID").style.display = 'none';

            document.getElementById("hdnGpHeaderData").value = '';
            document.getElementById("hdnGpHeader").value = '';

            var arrDataParent = [];
            var arrDataChild = [];
            // loop over each table row (tr)
            $("#ContentPlaceHolder1_tblGatePassHeader tr").each(function () {
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
            document.getElementById("hdnGpHeader").value = infox.innerHTML;
            //console.log(arrData);
            //alert(JSON.stringify(arrData));
            //alert(arrData);

            //var xml = '<TileMaps><level><map>';
            //xml += JSON.stringify(arrDataParent);
            //xml += '</map></level></TileMaps>';


            //  var xml = '';
            //xml += JSON.stringify(arrDataParent);
            ////xml += '</map></level></TileMaps>';
            //document.getElementById("hdnGpHeaderData").value = xml;
            //alert(xml);

            //  debugger;

            //var AoA = $('#ContentPlaceHolder1_tblGatePassHeader tr').map(function () {
            //    return [
            //        $('td', this).map(function () {
            //            return $(this).text();
            //        }).get()
            //    ];
            //}).get();
            //var json = JSON.stringify(AoA);

            //  document.getElementById("hdnGpHeaderData").value = JSON.stringify(AoA);

            //var tbl = $('#ContentPlaceHolder1_tblGatePassHeader tr').get().map(function (row) {
            //    return $(row).find('td').get().map(function (cell) {
            //        return $(cell).html();
            //    });
            //});

            //var tbl = $('#ContentPlaceHolder1_tblGatePassHeader tr').map(function () {
            //    return $(this).find('td').map(function () {
            //        return $(this).html();
            //    }).get();
            //}).get();

            // var json = JSON.stringify(tbl);

            //var InvoiceData = {};

            //var table = document.getElementById('#ContentPlaceHolder1_tblGatePassHeader');
            //var tableRowCount = $("#ContentPlaceHolder1_tblGatePassHeader > tbody > tr").length;
            //for (var i = 1; i <= tableRowCount; i++) {
            //    var obj = {
            //        Inv_Date: table.rows.item(i).cells[0].innerText,
            //        Bill_No: table.rows.item(i).cells[1].innerText,
            //        Net_Amt: table.rows.item(i).cells[2].innerText,
            //        Paid_Amt: table.rows.item(i).cells[3].innerText,
            //        Pay_Dis: $(table.rows.item(i).cells[4]).find('input').val(),
            //        Paying_Amt: $(table.rows.item(i).cells[5]).find('input').val(),
            //        Balance: table.rows.item(i).cells[6].innerText,
            //    };
            //    InvoiceData.push(obj);
            //}


            // document.getElementById('info').innerHTML = "";
            var myTab = document.getElementById('ContentPlaceHolder1_tblGatePassHeader');

            //var myTabx = document.getElementById('ContentPlaceHolder1_tblGatePassHeader');
            //// LOOP THROUGH EACH ROW OF THE TABLE AFTER HEADER.
            //for (x = 1; x < myTabx.rows.length; x++) {

            //    // GET THE CELLS COLLECTION OF THE CURRENT ROW.
            //    var objCells = myTabx.rows.item(x).cells;
            //    //var objCells = myTab.rows.item(i).cells.find('input').val();

            //    // LOOP THROUGH EACH CELL OF THE CURENT ROW TO READ CELL VALUES.
            //    //for (var j = 0; j < objCells.length; j++) {
            //    for (var y = 0; y < cols_len-1; y++) {
            //        infox.innerHTML = infox.innerHTML + '#' + myTabx.rows.item(x).cells[y].innerText;

            //    }
            //    infox.innerHTML = infox.innerHTML + ',';     // ADD A BREAK (TAG).
            //}
            //alert(infox.innerHTML);


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
                info.innerHTML = info.innerHTML + ',';     // ADD A BREAK (TAG).
            }
            document.getElementById("hdnGpHeaderData").value = info.innerHTML;
            //alert(info.innerHTML);
        }

    </script>

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <%--<form class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmGatePass" method="post">--%>
                        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

                        <asp:HiddenField ID="hdnGpHeaderData" runat="server" ClientIDMode="Static" />
                        <asp:HiddenField ID="hdnGpHeader" runat="server" ClientIDMode="Static" />
                        <p id="info" style="display: none;"></p>
                        <p id="infox" style="display: none;"></p>

                        <div class="m-portlet__head">
                            <div class="m-portlet__head-progress">

                                <!-- here can place a progress bar-->
                            </div>
                            <div class="m-portlet__head-wrapper">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">Gate Pass Request
                                        </h3>
                                    </div>
                                </div>

                                <div class="m-portlet__head-tools" style="width: 28%;">
                                    <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
                                    <a href="<%= Page.ResolveClientUrl("~/GatePass/MyGatePass.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                        <span>
                                            <i class="la la-arrow-left"></i>
                                            <span>Back</span>
                                        </span>
                                    </a>
                                    <div class="btn-group">

                                        <asp:Button ID="btnSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Style="display: none;" ValidationGroup="validateTicket" OnClick="btnSave_Click" Text="Save" />

                                        <asp:Button ID="btnTest" Style="display: none;" runat="server" />
                                        <cc1:ModalPopupExtender ID="mpeGpRequestSaveSuccess" runat="server" PopupControlID="pnlGpReqestSuccess" TargetControlID="btnTest"
                                            CancelControlID="btnCloseHeader2" BackgroundCssClass="modalBackground">
                                        </cc1:ModalPopupExtender>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="m-portlet__body" style="padding: 0.4rem 2.2rem;">

                            <div class="m-portlet__body" style="padding: 0.3rem 2.2rem;">
                                <div class="form-group m-form__group row" style="padding-left: 1%;">
                                    <label class="col-xl-3 col-lg-3 form-control-label font-weight-bold"><span style="color: red;">*</span> Gate Pass Title :</label>
                                    <div class="col-xl-4 col-lg-4">
                                        <asp:DropDownList ID="ddlGatePassTitle" class="form-control m-input" runat="server" OnSelectedIndexChanged="ddlGatePassTitle_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlGatePassTitle" Visible="true" Display="Dynamic"
                                            ValidationGroup="validateGatePass" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Gate Pass Title"></asp:RequiredFieldValidator>
                                    </div>
                                </div>


                                <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                    <label class="col-xl-3 col-lg-3 col-form-label font-weight-bold">Gatepass Description :</label>
                                    <div class="col-xl-9 col-lg-9 col-form-label">
                                        <asp:Label ID="lblGatepassDescription" runat="server" Text="" CssClass="form-control-label"></asp:Label>
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

                                        <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold" style="text-align: right;">Manager Name :</label>
                                        <div class="col-xl-3 col-lg-3 col-form-label">
                                            <asp:Label ID="lblRetailerName" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                        </div>

                                    </div>

                                    <%--<div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Mobile No. :</label>
                                            <div class="col-xl-3 col-lg-3 col-form-label">
                                                <asp:Label ID="lblRetailerMobileNo" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                            </div>

                                            <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold" style="text-align: right;">Email ID :</label>
                                            <div class="col-xl-3 col-lg-3 col-form-label">
                                                <asp:Label ID="lblRetailerEmailID" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                            </div>

                                        </div>--%>
                                    <%--<div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                            <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Request Date :</label>
                                            <div class="col-xl-3 col-lg-3 col-form-label">
                                                <asp:Label ID="Label5" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                            </div>
                                            <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold" style="text-align: right;">Department :</label>
                                            <div class="col-xl-3 col-lg-3 col-form-label">
                                                <asp:Label ID="Label1" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                            </div>
                                        </div>--%>
                                </div>
                                <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                    <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Mobile No. :</label>
                                    <div class="col-xl-3 col-lg-3 col-form-label">
                                        <asp:Label ID="lblMobileNo" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                    </div>

                                    <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold" style="text-align: right;">Email ID :</label>
                                    <div class="col-xl-3 col-lg-3 col-form-label">
                                        <asp:Label ID="LblEmailID" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                    </div>

                                </div>

                                <div class="form-group row" style="padding-left: 1%; margin-bottom: 0;">
                                    <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">Gate Pass Date :</label>
                                    <div class="col-xl-3 col-lg-3 col-form-label">
                                        <%--<asp:Label ID="lblRequestDate" runat="server" Text="" CssClass="form-control-label"></asp:Label>--%>
                                        <div class="input-group date">
                                            <asp:TextBox ID="txtGatePassDate" runat="server" autocomplete="off" class="form-control m-input datetimepicker" placeholder="Select Gate Pass date & time"></asp:TextBox>
                                            <div class="input-group-append">
                                                <span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
                                            </div>
                                        </div>
                                        <span id="error_startDate" class="text-danger small"></span>
                                    </div>

                                    <%-- <div id="dvDepartment" runat="server" style="display: block;">--%>
                                    <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold" style="text-align: right;">Department :</label>
                                    <div class="col-xl-3 col-lg-3 col-form-label">
                                        <asp:DropDownList ID="ddlDepartment" class="form-control m-input" runat="server"></asp:DropDownList>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlDepartment" Visible="true" Display="Dynamic"
                                                ValidationGroup="validateGatePass" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Department"></asp:RequiredFieldValidator>--%>
                                    </div>
                                    <%-- </div>--%>
                                </div>





                                <br />

                                <div class="form-group row" style="background-color: #00c5dc;">
                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Gate Pass Details</label>
                                </div>

                                <div class="form-group m-form__group row" style="padding-left: 1%;">
                                    <label class="col-xl-3 col-lg-2 form-control-label"><span style="color: red;">*</span> Gate Pass Type :</label>
                                    <div class="col-xl-4 col-lg-4">
                                        <asp:DropDownList ID="ddlGatePassType" class="form-control m-input" runat="server"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlGatePassType" Visible="true" Display="Dynamic"
                                            ValidationGroup="validateGatePass" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Gate Pass Type"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>--%>
                                <div class="m-portlet__body" style="overflow-x: scroll;">

                                    <table class="table table-striped- table-bordered table-hover table-checkable" style="width: 100%" border="1" runat="server" id="tblGatePassHeader">
                                    </table>



                                </div>
                                <br />
                                <input type="button" class="btn btn-accent m-btn m-btn--icon m-btn--pill m-btn--wide" onclick="AddRow()" value="+ Add New" id="btnAddNew" />
                                <%--<asp:Button ID="btnAddNew1" runat="server" class="btn btn-accent m-btn m-btn--icon m-btn--pill m-btn--wide" UseSubmitBehavior="false" ClientIDMode="Static" Text="+ Add New" />--%>
                                <%--</ContentTemplate></asp:UpdatePanel>--%>
                                <br />
                                <br />
                                <div class="form-group row" style="background-color: #00c5dc;">
                                    <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Gate Pass Terms & Conditions</label>
                                </div>


                                <asp:Repeater ID="rptTermsCondition" runat="server" ClientIDMode="Static">
                                    <ItemTemplate>
                                        <table style="width: 100%">
                                            <tr>
                                                <td>
                                                    <asp:CheckBox runat="server" ID="chkTermsCondition" />
                                                </td>
                                                <td style="width: 5%">
                                                    <asp:Label ID="lblTermID" runat="server" Text='<%#Eval("GP_Terms_ID") %>' Style="display: none;"></asp:Label>
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

                                <div id="dvApprovalMatrix" runat="server">
                                    <div class="form-group row" style="background-color: #00c5dc;">
                                        <label class="col-xl-3 col-lg-3" style="color: #ffffff; margin-top: 1%;">Approval Matrix</label>
                                    </div>
                                    <div>
                                        <asp:GridView ID="gvApprovalMatrix" runat="server" CssClass="table table-hover table-striped" HorizontalAlign="Center" AutoGenerateColumns="true"></asp:GridView>
                                    </div>
                                </div>
                                <br />

                                <div class="col-lg-9 ml-lg-auto">
                                    <asp:Button ID="btnSubmit" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Style="margin-right: 20px;" OnClick="btnSubmit_Click" OnClientClick="SubmitHeader()" Text="Submit" ValidationGroup="validateGatePass" />

                                    <asp:Button ID="btnCancel" runat="server" class="btn btn-secondary btn-outline-hover-danger btn-sm m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10" Style="margin-right: 20px;" OnClick="btnCancel_Click" Text="Cancel" />

                                    <asp:Label ID="lblErrorMsg1" Text="" runat="server" CssClass="col-xl-8 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>

                                </div>
                                <br />
                                <br />
                            </div>
                        </div>



                        <asp:Panel ID="pnlGpReqestSuccess" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
                            <div class="" id="add_sub_location2" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document" style="max-width: 590px;">
                                    <div class="modal-content">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <div class="modal-header">
                                                    <h5 class="modal-title" id="exampleModalLabel2">Gate Pass Request Confirmation</h5>
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader2">
                                                        <span aria-hidden="true">&times;</span>
                                                    </button>
                                                </div>
                                                <div class="modal-body">
                                                    <div class="form-group m-form__group row">
                                                        <label for="recipient-name" class="col-xl-8 col-lg-3 form-control-label">Gate Pass Request has been saved successfully</label>
                                                    </div>
                                                    <div class="form-group m-form__group row">
                                                        <label for="message-text" class="col-xl-5 col-lg-3 form-control-label font-weight-bold">Ticket No :</label>
                                                        <asp:Label ID="lblGPRequestCode" Text="" runat="server" CssClass="col-xl-1 col-lg-3 col-form-label" Style="padding-top: calc(0.15rem + 1px); margin-left: -10%;"></asp:Label>
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





                        <%--</form>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
