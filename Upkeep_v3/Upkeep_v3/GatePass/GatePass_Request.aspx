<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="GatePass_Request.aspx.cs" Inherits="Upkeep_v3.GatePass.GatePass_Request" %>

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
        <div class="m-content">
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

                                <div class="m-portlet__head-tools">
                                    <%--<asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>--%>
                                    
                                        <asp:Button ID="btnTest" Style="display: none;" runat="server" />
                                        <cc1:ModalPopupExtender ID="mpeGpRequestSaveSuccess" runat="server" PopupControlID="pnlGpReqestSuccess" TargetControlID="btnTest"
                                            CancelControlID="btnCloseHeader2" BackgroundCssClass="modalBackground">
                                        </cc1:ModalPopupExtender>

                                    
                                        <cc1:ModalPopupExtender ID="mpe_No_Gatepass" runat="server" PopupControlID="pnl_NoGatepass" TargetControlID="btnTest"
                                            CancelControlID="btnCloseHeader2" BackgroundCssClass="modalBackground">
                                        </cc1:ModalPopupExtender>


                                    <a href="<%= Page.ResolveClientUrl("~/GatePass/MyGatePass.aspx") %>" class="btn btn-metal m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m--margin-right-10">
                                        <span>
                                            <i class="la la-arrow-left"></i>
                                            <span>Back</span>
                                        </span>
                                    </a>

                                    
                                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air" Style="margin-right: 20px;" OnClick="btnSubmit_Click" OnClientClick="SubmitHeader()" Text="Submit" ValidationGroup="validateGatePass" />

                                </div>

                            </div>
                        </div>


                        <div class="m-portlet__body">
                            <div class="form-group m-form__group row">
                                <label class="col-xl-2 form-control-label font-weight-bold"><span class="fa fa-address-card"></span>Select Gatepass</label>
                                <div class="col-xl-10">
                                    <asp:DropDownList ID="ddlGatePassTitle" class="form-control m-input" runat="server" OnSelectedIndexChanged="ddlGatePassTitle_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlGatePassTitle" Visible="true" Display="Dynamic"
                                        ValidationGroup="validateGatePass" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Gate Pass Title"></asp:RequiredFieldValidator>
                                </div>
                            </div>


                            <div class="form-group row">
                                <label class="col-xl-3 col-lg-3 col-form-label font-weight-bold">Gatepass Description</label>
                                <div class="col-xl-9 col-lg-9 col-form-label">
                                    <asp:Label ID="lblGatepassDescription" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                </div>
                            </div>

                            <div class="form-group row">
                                <label class="col-xl-3 col-lg-3 col-form-label font-weight-bold">Returnable Gatepass</label>
                                <div class="col-xl-9 col-lg-9 col-form-label">
                                    <asp:Label ID="lbl_Returnable_Gatepass" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                </div>
                            </div>

                            <div class="m-form__heading" style="text-align: center; padding-top: 10px;">
                                <h3 class="m-form__heading-title" style="line-height: 2.0; background: aliceblue; font-size: 1.2rem;">Initiator details</h3>
                            </div>

                            <div id="dvEmployee" runat="server">
                                <div class="form-group row">
                                    <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold"><span class="fa fa-user"></span>Employee Name</label>
                                    <div class="col-xl-4 col-lg-3 col-form-label">
                                        <asp:Label ID="lblEmpName" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                    </div>

                                    <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold"><span class="fa fa-id-card-alt"></span>Employee Code</label>
                                    <div class="col-xl-4 col-lg-3 col-form-label">
                                        <asp:Label ID="lblEmpCode" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                    </div>

                                </div>
                            </div>

                            <div id="dvRetailer" runat="server">
                                <div class="form-group row">
                                    <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold"><span class="fa fa-store"></span>Store Name</label>
                                    <div class="col-xl-4 col-lg-3 col-form-label">
                                        <asp:Label ID="lblStoreName" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                    </div>

                                    <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold"><span class="fa fa-user-tie"></span>Manager Name</label>
                                    <div class="col-xl-4 col-lg-3 col-form-label">
                                        <asp:Label ID="lblRetailerName" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                    </div>

                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold"><span class="fa fa-phone"></span>Mobile No.</label>
                                <div class="col-xl-4 col-lg-3 col-form-label">
                                    <asp:Label ID="lblMobileNo" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                </div>

                                <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold"><span class="fa fa-envelope"></span>Email ID</label>
                                <div class="col-xl-4 col-lg-3 col-form-label">
                                    <asp:Label ID="LblEmailID" runat="server" Text="" CssClass="form-control-label"></asp:Label>
                                </div>

                            </div>

                            <div class="form-group row">
                                <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">
                                    <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="Select the Date and time , during which this Gatepass will be Valid">
                                        <i class="fa fa-info-circle"></i>
                                    </a>
                                    Gate Pass Date</label>
                                <div class="col-xl-4 col-lg-3 col-form-label">
                                    <%--<asp:Label ID="lblRequestDate" runat="server" Text="" CssClass="form-control-label"></asp:Label>--%>
                                    <div class="input-group date">
                                        <asp:TextBox ID="txtGatePassDate" runat="server" autocomplete="off" class="form-control m-input datetimepicker" placeholder="Select Gate Pass date & time"></asp:TextBox>
                                        
                                        <div class="input-group-append">
                                            <span class="input-group-text"><i class="la la-calendar-check-o glyphicon-th"></i></span>
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtGatePassDate" Visible="true" Display="Dynamic"
                                            ValidationGroup="validateGatePass" ForeColor="Red" ErrorMessage="Please select Gate Pass Date"></asp:RequiredFieldValidator>
                                    </div>
                                    <span id="error_startDate" class="text-danger small"></span>
                                </div>

                                <%-- <div id="dvDepartment" runat="server" style="display: block;">--%>
                                <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold">
                                    <a href="#" style="width: 25px; height: 25px; }" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="Select the Department which you would like to assign to the Gatepass. If Disabled in Configuration , this dropdown will be inactive">
                                        <i class="fa fa-info-circle"></i>
                                    </a>
                                    Department</label>
                                <div class="col-xl-4 col-lg-3 col-form-label">
                                    <asp:DropDownList ID="ddlDepartment" class="form-control m-input" runat="server"></asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlDepartment" Visible="true" Display="Dynamic"
                                                ValidationGroup="validateGatePass" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Department"></asp:RequiredFieldValidator>--%>
                                </div>
                                <%-- </div>--%>
                            </div>


                            <div class="m-form__heading" style="text-align: center; padding-top: 10px; padding-bottom: 10px;">
                                <h3 class="m-form__heading-title" style="line-height: 2.0; background: aliceblue; font-size: 1.2rem;">Gatepass Details</h3>
                            </div>


                            <div class="form-group m-form__group row">
                                <label class="col-xl-2 col-lg-2 form-control-label font-weight-bold">Select Gatepass Type</label>
                                <div class="col-xl-10 col-lg-4">
                                    <asp:DropDownList ID="ddlGatePassType" class="form-control m-input" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlGatePassType" Visible="true" Display="Dynamic"
                                        ValidationGroup="validateGatePass" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Gate Pass Type"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>--%>
                            <div class="m-portlet__body" style="overflow-x: scroll; padding: 1rem 0rem;">

                                <table class="table table-striped- table-bordered table-hover table-checkable" style="width: 100%" border="1" runat="server" id="tblGatePassHeader">
                                </table>



                            </div>
                            <input type="button" class="btn btn-accent m-btn m-btn--icon m-btn--pill m-btn--wide m--margin-10" onclick="AddRow()" value="+ Add New" id="btnAddNew" />


                            <div class="m-form__heading" style="text-align: center; padding-top: 10px; padding-bottom: 10px;">
                                <h3 class="m-form__heading-title" style="line-height: 2.0; background: aliceblue; font-size: 1.2rem;">Gatepass Terms and Conditions</h3>
                            </div>


                            <asp:Repeater ID="rptTermsCondition" runat="server" ClientIDMode="Static">
                                <ItemTemplate>
                                    <div class="form-group m-form__group row">
                                        <div class="col-xl-12 col-lg-4">

                                            <asp:CheckBox runat="server" ID="chkTermsCondition" />
                                            <asp:Label ID="lblTermID" runat="server" Text='<%#Eval("GP_Terms_ID") %>' Style="display: none;"></asp:Label>
                                            <asp:Label ID="lblTermDesc" runat="server" Text='<%#Eval("Terms_Desc") %>' ClientIDMode="Static" CssClass="form-control-label col-form-label font-weight-bold"></asp:Label>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                            <%-- Document section added by Suju 13-July-2020 --%>

                            <div class="m-form__heading" style="text-align: center; padding-top: 10px; padding-bottom: 10px;">
                                <h3 class="m-form__heading-title" style="line-height: 2.0; background: aliceblue; font-size: 1.2rem;">Upload Gatepass Documents</h3>
                            </div>

                            <h6 class="m--font-danger m--align-center" style="margin-bottom: 1rem;">Please upload jpg, jpeg, png, pdf file only.</h6>
                            <asp:Repeater ID="rptDocuments" runat="server" ClientIDMode="Static">
                                <ItemTemplate>


                                    <div class="form-group m-form__group row" style="margin-bottom: 1rem;">
                                        <label class="col-xl-5 col-lg-2 form-control-label font-weight-bold"><%# Convert.ToBoolean(Eval("Mandatory"))  ? "<span style='color: red;'>*</span>" : "&nbsp;" %> <%#Eval("Doc_Desc") %>:</label>
                                        <div class="col-xl-7 col-lg-8">
                                            <asp:HiddenField ID="hdnDocID" Value='<%#Eval("Doc_Config_Id") %>' runat="server" />
                                            <asp:FileUpload AllowMultiple="false" ID="flDoc" runat="server" />
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                            <%-- End Document Section --%>

                            <div id="dvApprovalMatrix" runat="server">

                                <div class="m-form__heading" style="text-align: center; padding-top: 10px; padding-bottom: 10px;">
                                    <h3 class="m-form__heading-title" style="line-height: 2.0; background: aliceblue; font-size: 1.2rem;">Approval Matrix</h3>
                                </div>

                                <div>
                                    <asp:GridView ID="gvApprovalMatrix" runat="server" CssClass="table table-striped- table-bordered table-hover table-checkable dataTable no-footer dtr-inline collapsed" HorizontalAlign="Center" AutoGenerateColumns="true"></asp:GridView>
                                </div>
                            </div>

                            <div class="col-lg-12 ml-lg-auto">

                                <asp:Label ID="lblErrorMsg1" Text="" runat="server" CssClass="col-xl-8 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
                                <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
                            </div>
                        </div>

                        <asp:Panel ID="pnl_NoGatepass" runat="server" CssClass="modalPopup" align="center">
                            <div class="" id="add_sub_location3" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <div class="modal-header">
                                                    <h5 class="modal-title m--align-center" id="exampleModalLabel3">No Gatepass Forms Available !</h5>
                                                </div>
                                                <div class="modal-body">
                                                    <div class="form-group m-form__group row">
                                                        <label for="recipient-name" class="col-xl-12 col-lg-3 form-control-label">It looks Like no Gatepass Forms have been configured in your Company for <span id="lbl_Retailer_NoForm" runat="server"></span> <span id="lbl_Employee_NoForm" runat="server"></span> </label>
                                                        
                                                        <label class="col-xl-12 col-lg-3 form-control-label font-weight-bold">Please contact your Property Administrator to get New Gatepass Forms Configured</label>
                                                        

                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <a href="<%= Page.ResolveClientUrl("~/GatePass/MyGatePass.aspx") %>" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m--margin-right-10">
                                                        <span>
                                                            <i class="la la-arrow-left"></i>
                                                            <span>Back</span>
                                                        </span>
                                                    </a>

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



                        <asp:Panel ID="pnlGpReqestSuccess" runat="server" CssClass="modalPopup" align="center">
                            <div class="" id="add_sub_location2" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                <div class="modal-dialog" role="document">
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
                                                        <label for="recipient-name" class="col-xl-12 col-lg-3 form-control-label">Your Gate Pass Request has been saved successfully</label>
                                                    </div>
                                                    <div class="form-group m-form__group row">
                                                        <div class="col-xl-12 col-lg-3">
                                                            <h2 class="m--font-info"><label class="form-control-label font-weight-bold">Gatepass ID</label></h2>
                                                        
                                                            <h2 class="m--font-danger"><label ID="lblGPRequestCode" runat="server" class="form-control-label" ></label></h2>

                                                        </div>
                                                        
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
