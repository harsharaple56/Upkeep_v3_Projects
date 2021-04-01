<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="Upkeep_v3.Laundry_Management.Stock.Setup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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

        .highlight {
            background-color: blanchedalmond;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#tblCategory tr").click(function () {

                //alert($("#tblCategory tr").index(this));
                var table = document.getElementById("tblCategory");
                var rowID = $("#tblCategory tr").index(this);

                var row = table.rows[rowID];
                var CategoryID, CategoryName;

                // alert($(this).attr('id'));
                // CategoryID = $(this).attr('id');

                CategoryID = row.cells[0].innerHTML;
                //CategoryID = CategoryID.substring(0, CategoryID.indexOf(' -'));

                $("#hdnCategory").val(CategoryID);
                $("#hdnCategoryName").val(CategoryID);

                $("#lblCategoryName").text(CategoryID);
                document.getElementById("hdnTxtCategory").value = CategoryID;
                //$("#lblCategoryName").text(CategoryID); 
                //alert(CategoryID);
                var selected = $(this).hasClass("highlight");
                $("#tblCategory tr").removeClass("highlight");
                if (!selected)
                    $(this).addClass("highlight");

                //$("#tblLItems tbody tr").remove(); 
                //$("#tblLocation tbody tr").remove(); 

                //alert('asdasdas');

                var obj = {};

                var dataString = { 'Category': CategoryID };
                var param = JSON.stringify(dataString);


                //debugger;
                $.ajax({
                    type: 'POST',
                    url: 'General_Master.aspx/SubCategory_bindgrid1',
                    //data: '{EmpId :' + empId + '}',
                    //data: JSON.stringify(obj),
                    //data: dataString,
                    data: param,
                    //data: '',
                    contentType: 'application/json; charset=utf-8',
                    datatype: 'json',
                    //async: true,
                    //cache: false,
                    success: function (response) {
                        //alert('Success');
                        location.reload(true);
                    },
                    error: function (xhr, status, error) {

                        //alert(xhr.responseText);  // to see the error message
                    }
                });

            });

            $("#tblLocation tr").click(function () {

                //alert($("#tblCategory tr").index(this));
                var table = document.getElementById("tblLocation");
                var rowID = $("#tblLocation tr").index(this);

                var row = table.rows[rowID];
                var Location, SubCategoryID, SubCategoryName;

                //alert($(this).attr('id'));
                //SubCategoryID = $(this).attr('id');
                Location = row.cells[0].innerHTML;
                //Location = Location.substring(0, Location.indexOf(' -'));



                $("#hdnLocation").val(Location);

                //alert(Location);
                //document.getElementById("lblLocation").val = Location;
                $("#lblLocation").text(Location);
                document.getElementById("hdnTxtSubCategory").value = Location;

                var selected = $(this).hasClass("highlight");
                $("#tblLocation tr").removeClass("highlight");
                if (!selected)
                    $(this).addClass("highlight");


                //alert('asdasdas');


                var obj = {};

                var dataString = { 'SubCategory': Location };
                var param = JSON.stringify(dataString);

                //debugger;
                $.ajax({
                    type: 'POST',
                    url: 'General_Master.aspx/Item_bindgrid1',
                    //data: '{EmpId :' + empId + '}',
                    //data: JSON.stringify(obj),
                    //data: dataString,
                    data: param,
                    //data: '',
                    contentType: 'application/json; charset=utf-8',
                    datatype: 'json',
                    //async: true,
                    //cache: false,
                    success: function (response) {
                        //alert('Success');
                        location.reload(true);
                    },
                    error: function (xhr, status, error) {

                        //alert(xhr.responseText);  // to see the error message
                    }
                });
            });

            $('.text-success').click(function () {
                //event.preventDefault();

                //$("#hdnEditTableClicked").val('');
                //$("#hdnEditClickedID").val('');

                var tbl = $(this).closest('table').attr('id');;
                var strs = $(this).attr('data-val');
                var n = strs.includes("=");

                if (n == true) {
                    var IDa = strs.split('=')[1]; // strs.substr(strs.indexOf('=')); 

                    //alert(tbl);
                    //alert(IDa);

                    //$("#hdnEditTableClicked").val('');
                    //$("#hdnEditClickedID").val('');

                    $("#hdnEditTableClicked").val(tbl);
                    $("#hdnEditClickedID").val(IDa);


                    var obj = {};
                    var dataString = { 'hdnEditTableClicked': tbl, 'hdnEditClickedID': IDa };
                    var param = JSON.stringify(dataString);

                    //debugger;
                    $.ajax({
                        type: 'POST',
                        url: 'General_Master.aspx/SetSeesions',
                        data: param,
                        //data: '',
                        contentType: 'application/json; charset=utf-8',
                        datatype: 'json',
                        success: function (response) {

                        },
                        error: function (xhr, status, error) {

                        }
                    });
                }

                //return false;
            });



            //$('.text-danger').click(function (event) {

            //    var tbl = $(this).closest('table').attr('id');;
            //    var strs = $(this).attr('data-val');
            //    var n = strs.includes("=");
            //    alert(strs);
            //    if (n == true) {
            //        var IDa = strs.split('=')[1]; // strs.substr(strs.indexOf('='));  
            //        var obj = {};
            //        var dataString = {'Table': tbl, 'ColID': IDa };
            //        var param = JSON.stringify(dataString);

            //        //debugger;
            //        $.ajax({
            //            type: 'POST',
            //            url: 'General_Master.aspx/DeleteRecord',
            //            data: param,
            //            //data: '',
            //            contentType: 'application/json; charset=utf-8',
            //            datatype: 'json',
            //            success: function (response) {

            //            },
            //            error: function (xhr, status, error) {

            //            }
            //        });
            //    }
            //});

        });



        //function functionDelete(x) {
        //    var tbl = $(x).closest('table').attr('id');;
        //    var strs = $(x).attr('data-val');
        //    var n = strs.includes("=");

        //    if (n == true) {
        //        var IDa = strs.split('=')[1]; // strs.substr(strs.indexOf('='));  
        //        var obj = {};
        //        var dataString = { 'Table': tbl, 'ColID': IDa };
        //        var param = JSON.stringify(dataString);

        //        //debugger;
        //        $.ajax({
        //            type: 'POST',
        //            url: 'General_Master.aspx/DeleteRecord',
        //            data: param,
        //            //data: '',
        //            contentType: 'application/json; charset=utf-8',
        //            datatype: 'json',
        //            success: function (response) {

        //            },
        //            error: function (xhr, status, error) {

        //            }
        //        });
        //    }
        //}

        function HighlightCategoryTable() {
            $("#tblCategory tr").click(function () {

                //alert($("#tblCategory tr").index(this));
                var table = document.getElementById("tblCategory");
                var rowID = $("#tblCategory tr").index(this);

                var row = table.rows[rowID];
                var CategoryID, CategoryName;

                //alert($(this).attr('id'));
                //CategoryID = $(this).attr('id');

                CategoryID = row.cells[0].innerHTML;
                //CategoryID = CategoryID.substring(0, CategoryID.indexOf(' -'));



                //alert('asdasdas');

                //alert(CategoryID);
                var selected = $(this).hasClass("highlight");

                //alert(selected);
                $(this).addClass("highlight");

                $("#tblCategory tr").removeClass("highlight");
                if (!selected)
                    $(this).addClass("highlight");
            });
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div runat="server" id="FrmMain">
        <cc1:ToolkitScriptManager runat="server">
        </cc1:ToolkitScriptManager>

        <%--<button type="button" runat="server" id="btnoo" onserverclick="btnoo_Click" class="btn btn-accent mr-auto" style="display: none" clientidmode="Static">Save</button>--%>


        <asp:HiddenField ID="hdnEditTableClicked" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnEditClickedID" runat="server" ClientIDMode="Static" />

        <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />

        <asp:HiddenField ID="hdnCategory" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnLocation" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnCategoryName" runat="server" ClientIDMode="Static" />
        <asp:TextBox ID="hdnTxtSubCategory" runat="server" Style="display: none;" ClientIDMode="Static"></asp:TextBox>
        <asp:TextBox ID="hdnTxtCategory" runat="server" Style="display: none;" ClientIDMode="Static"></asp:TextBox>
        <%-- <asp:ScriptManager ID="scriptmanager1" runat="server">
        </asp:ScriptManager>--%>

        <div class="m-grid__item m-grid__item--fluid m-wrapper">



            <div class="">
                <div class="row">


                    <div class="col-md-4">
                        <div class="m-portlet">
                            <div class="m-portlet__head p-3">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <span class="m-portlet__head-icon">
                                            <i class="flaticon-placeholder-2"></i>
                                        </span>
                                        <h3 class="m-portlet__head-text">Category
                                        </h3>
                                    </div>
                                </div>
                                <div class="m-portlet__head-tools">
                                    <ul class="m-portlet__nav">
                                        <li class="m-portlet__nav-item">
                                            <%--<a href="#add_Category" class="m-portlet__nav-link m-portlet__nav-link--icon" data-toggle="modal"><i class="la la-plus"></i></a>--%>
                                            <asp:Button ID="btnAddCategory" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="+" />
                                            <cc1:ModalPopupExtender ID="mpeCategory" runat="server" PopupControlID="pnlAddCategory" TargetControlID="btnAddCategory"
                                                CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                                            </cc1:ModalPopupExtender>

                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div class="m-portlet__body py-1 px-2">
                                <table id="tblCategory" class="table m-table table-sm table-hover">
                                    <tbody>

                                        <%=Category_bindgrid()%>

                                        <%--<tr class="cursor-pointer">
                                                <td>Category 1
													
                                            <span class="pull-right">
                                                <a href="javascript:;" class="text-success"><i class="fa fa-edit fa-fw"></i></a>
                                                <a href="javascript:;" class="text-danger" data-toggle="confirmation"><i class="fa fa-trash fa-fw"></i></a>
                                                <i class="fa fa-caret-right fa-fw invisible"></i>
                                            </span>
                                                </td>
                                            </tr>--%>


                                        <%--  <tr class="table-secondary">
                                        <td>Category 2
													
                                            <span class="pull-right">
                                                <a href="javascript:;" class="text-success"><i class="fa fa-edit fa-fw"></i></a>
                                                <a href="javascript:;" class="text-danger" data-toggle="confirmation"><i class="fa fa-trash fa-fw"></i></a>
                                                <i class="fa fa-caret-right fa-fw"></i>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr class="cursor-pointer">
                                        <td>Category 3
													
                                            <span class="pull-right">
                                                <a href="javascript:;" class="text-success"><i class="fa fa-edit fa-fw"></i></a>
                                                <a href="javascript:;" class="text-danger" data-toggle="confirmation"><i class="fa fa-trash fa-fw"></i></a>
                                                <i class="fa fa-caret-right fa-fw invisible"></i>
                                            </span>
                                        </td>
                                    </tr>--%>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="m-portlet">
                            <div class="m-portlet__head p-3">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <span class="m-portlet__head-icon">
                                            <i class="flaticon-placeholder-2"></i>
                                        </span>
                                        <h3 class="m-portlet__head-text">Sub Category
                                        </h3>
                                    </div>
                                </div>
                                <div class="m-portlet__head-tools">
                                    <ul class="m-portlet__nav">
                                        <li class="m-portlet__nav-item">
                                            <%--<a href="#add_location" class="m-portlet__nav-link m-portlet__nav-link--icon" data-toggle="modal"><i class="la la-plus"></i></a>--%>
                                            <asp:Button ID="btnAddLocation" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="+" OnClick="btnAddLocation_Click" />
                                            <cc1:ModalPopupExtender ID="mpeSubCategory" runat="server" PopupControlID="pnlAddSubCategory" TargetControlID="btnAddLocation"
                                                CancelControlID="btnCloseLoc" BackgroundCssClass="modalBackground">
                                            </cc1:ModalPopupExtender>

                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div class="m-portlet__body py-1 px-2">
                                <table id="tblLocation" class="table m-table table-sm">
                                    <tbody>

                                        <%=SubCategory_bindgrid()%>

                                        <%--<tr class="cursor-pointer">
                                                <td>Location 1
													
                                            <span class="pull-right">
                                                <a href="javascript:;" class="text-success"><i class="fa fa-edit fa-fw"></i></a>
                                                <a href="javascript:;" class="text-danger" data-toggle="confirmation"><i class="fa fa-trash fa-fw"></i></a>
                                                <i class="fa fa-caret-right fa-fw invisible"></i>
                                            </span>
                                                </td>
                                            </tr>--%>

                                        <%--<tr class="cursor-pointer">
                                        <td>Location 2
													
                                            <span class="pull-right">
                                                <a href="javascript:;" class="text-success"><i class="fa fa-edit fa-fw"></i></a>
                                                <a href="javascript:;" class="text-danger" data-toggle="confirmation"><i class="fa fa-trash fa-fw"></i></a>
                                                <i class="fa fa-caret-right fa-fw invisible"></i>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr class="table-secondary">
                                        <td>Location 3
													
                                            <span class="pull-right">
                                                <a href="javascript:;" class="text-success"><i class="fa fa-edit fa-fw"></i></a>
                                                <a href="javascript:;" class="text-danger" data-toggle="confirmation"><i class="fa fa-trash fa-fw"></i></a>
                                                <i class="fa fa-caret-right fa-fw"></i>
                                            </span>
                                        </td>
                                    </tr>--%>
                                    </tbody>
                                </table>


                                <%--<asp:GridView ID="gvLocation" runat="server" CssClass="table m-table table-sm" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundField DataField="Location" HeaderText="Location" ItemStyle-Width="150px" />
                                        </Columns>
                                    </asp:GridView>--%>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="m-portlet">
                            <div class="m-portlet__head p-3">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <span class="m-portlet__head-icon">
                                            <i class="flaticon-placeholder-2"></i>
                                        </span>
                                        <h3 class="m-portlet__head-text">Item
                                        </h3>
                                    </div>
                                </div>
                                <div class="m-portlet__head-tools">
                                    <ul class="m-portlet__nav">
                                        <li class="m-portlet__nav-item">
                                            <%--<a href="#add_sub_location" class="m-portlet__nav-link m-portlet__nav-link--icon" data-toggle="modal"><i class="la la-plus"></i></a>--%>

                                            <asp:Button ID="btnItem" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="+" />
                                            <cc1:ModalPopupExtender ID="mpeItem" runat="server" PopupControlID="pnlAddItem" TargetControlID="btnItem"
                                                CancelControlID="btnCloseItem" BackgroundCssClass="modalBackground">
                                            </cc1:ModalPopupExtender>

                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div class="m-portlet__body py-1 px-2">
                                <table id="tblLItems" class="table m-table table-sm">
                                    <tbody>
                                        <%=Item_bindgrid()%>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--</div>--%>

        <!-- Start Modal -->

        <asp:Panel ID="pnlAddCategory" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
            <div class="" id="add_Category" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-sm" role="document">

                    <%-- <asp:ScriptManager ID="scriptmanager2" runat="server">
                </asp:ScriptManager>--%>


                    <div class="modal-content">

                        <asp:UpdatePanel ID="updatepnl" runat="server">
                            <ContentTemplate>

                                <div class="modal-header">
                                    <h5 class="modal-title" id="exampleModalLabel">Add New Category</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <%--<span aria-hidden="true">&times;</span>--%>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <%-- <form>--%>
                                    <%-- <div class="form-group" visible="false">
                                        <label for="recipient-name" class="form-control-label">Category code:</label>

                                        <asp:TextBox ID="txtCategoryCode" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvCategoryCode" runat="server" ControlToValidate="txtCategoryCode" Visible="true" ValidationGroup="validationCategory" ForeColor="Red" ErrorMessage="Please enter Category code"></asp:RequiredFieldValidator>
                                    </div>--%>
                                    <div class="form-group">
                                        <label for="message-text" class="form-control-label">Category Description:</label>
                                        <%--<textarea class="form-control" id="message-text"></textarea>--%>
                                        <asp:TextBox ID="txtCategoryDesc" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCategoryDesc" Visible="true" ValidationGroup="validationCategory" ForeColor="Red" ErrorMessage="Please enter Category Desc"></asp:RequiredFieldValidator>
                                    </div>



                                    <%--</form>--%>
                                </div>

                                <div class="form-group m-form__group row">
                                    <div class="col-xl-9 col-lg-9">
                                        <asp:Label ID="lblCategoryErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                    </div>
                                </div>

                                <div class="modal-footer">
                                    <%--<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>--%>
                                    <asp:Button ID="btnClose" Text="Close" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnClose_Click" />
                                    <asp:Button ID="btnCategorySave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" CausesValidation="true" ValidationGroup="validationCategory" OnClick="btnCategorySave_Click" Text="Save" />
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnCategorySave" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>

                    </div>

                </div>
            </div>

        </asp:Panel>

        <asp:Panel ID="pnlAddSubCategory" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
            <div class="" id="add_SubCategory" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-sm" role="document">
                    <div class="modal-content">

                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>

                                <div class="modal-header">
                                    <h5 class="modal-title" id="exampleModalLabel">Add new SubCategory</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <%--<span aria-hidden="true">&times;</span>--%>
                                    </button>
                                </div>
                                <div class="modal-body">

                                    <%-- <div class="form-group" visible="false">
                                        <label for="recipient-name" class="form-control-label">SubCategory code:</label>
                                        <asp:TextBox ID="txtSubCategoryCode" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSubCategoryCode" Visible="true" ValidationGroup="validationSubCategory" ForeColor="Red" ErrorMessage="Please enter SubCategory code"></asp:RequiredFieldValidator>

                                    </div>--%>
                                    <div class="form-group">
                                        <label for="message-text" class="form-control-label">Description:</label>
                                        <asp:TextBox ID="txtSubCategory" runat="server" class="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSubCategory" Visible="true" ValidationGroup="validationSubCategory" ForeColor="Red" ErrorMessage="Please enter SubCategory"></asp:RequiredFieldValidator>

                                    </div>

                                </div>
                                <div class="form-group m-form__group row">
                                    <div class="col-xl-9 col-lg-9">
                                        <asp:Label ID="lblSubCategoryErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                    </div>
                                </div>

                                <div class="modal-footer">
                                    <asp:Button ID="btnCloseLoc" Text="Close" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" />
                                    <asp:Button ID="btnSubCategorySave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" CausesValidation="true" ValidationGroup="validationSubCategory" OnClick="btnSubCategorySave_Click" Text="Save" />

                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnCategorySave" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>

        </asp:Panel>

        <asp:Panel ID="pnlAddItem" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
            <div class="" id="add_sub_SubCategory" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document" style="max-width: 476px;">
                    <div class="modal-content">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>

                                <div class="modal-header">
                                    <h5 class="modal-title" id="exampleModalLabel">Add New Item</h5>
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <%--<span aria-hidden="true">&times;</span>--%>
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <div class="form-group m-form__group row">
                                        <label for="recipient-name" class="col-xl-4 col-lg-3 form-control-label">Category :</label>
                                        <asp:Label ID="lblCategoryName" Text="" ClientIDMode="Static" runat="server" class="form-control-label" Style="font-weight: bold"></asp:Label>
                                    </div>
                                    <div class="form-group m-form__group row">
                                        <label for="recipient-name" class="col-xl-4 col-lg-3 form-control-label">SubCategory :</label>
                                        <asp:Label ID="lblSubCategory" Text="" ClientIDMode="Static" runat="server" class="form-control-label" Style="font-weight: bold"></asp:Label>
                                    </div>

                                    <%--  <div class="form-group m-form__group row" visible="false">
                                        <label for="recipient-name" class="col-xl-4 col-lg-3 form-control-label">Sub-location code:</label>
                                        <asp:TextBox ID="txtItemCode" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtItemCode" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationItem" ForeColor="Red" ErrorMessage="Please enter Sub Location code"></asp:RequiredFieldValidator>
                                    </div>--%>

                                    <div class="form-group m-form__group row">
                                        <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Description:</label>
                                        <%--<textarea class="form-control" id="message-text"></textarea>--%>
                                        <asp:TextBox ID="txtItem" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtItem" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationItem" ForeColor="Red" ErrorMessage="Please enter Sub Location"></asp:RequiredFieldValidator>

                                    </div>
                                    <div class="form-group m-form__group row">
                                        <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Department:</label>
                                        <%--<textarea class="form-control" id="message-text"></textarea>--%>
                                        <asp:DropDownList ID="ddlDepartment" class="form-control" Style="width: 60%;" runat="server">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlDepartment" Visible="true"
                                            Display="Dynamic" ValidationGroup="validateStock" ForeColor="Red" InitialValue="0"
                                            ErrorMessage="Please select Department"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group m-form__group row">
                                        <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Opening:</label>
                                        <%--<textarea class="form-control" id="message-text"></textarea>--%>
                                        <asp:TextBox ID="txtOpening" value="0" runat="server" class="form-control" Style="width: 60%;" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtOpening"
                                            Visible="true" Style="margin-left: 34%;" ValidationGroup="validationItem" ForeColor="Red"
                                            ErrorMessage="Please enter Opening stock"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group m-form__group row">
                                        <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Optimun:</label>
                                        <%--<textarea class="form-control" id="message-text"></textarea>--%>
                                        <asp:TextBox ID="txtOptimun" value="0" runat="server" class="form-control" Style="width: 60%;" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtOptimun"
                                            Visible="true" Style="margin-left: 34%;" ValidationGroup="validationItem" ForeColor="Red"
                                            ErrorMessage="Please enter Optimun stock"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group m-form__group row">
                                        <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Re Order:</label>
                                        <%--<textarea class="form-control" id="message-text"></textarea>--%>
                                        <asp:TextBox ID="txtReOrder" runat="server" value="0" class="form-control" Style="width: 60%;" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtReOrder"
                                            Visible="true" Style="margin-left: 34%;" ValidationGroup="validationItem" ForeColor="Red"
                                            ErrorMessage="Please enter Re Order"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group m-form__group row">
                                        <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Base:</label>
                                        <%--<textarea class="form-control" id="message-text"></textarea>--%>
                                        <asp:TextBox ID="txtBase" runat="server" value="0" class="form-control" Style="width: 60%;" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtBase"
                                            Visible="true" Style="margin-left: 34%;" ValidationGroup="validationItem" ForeColor="Red"
                                            ErrorMessage="Please enter Base"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group m-form__group row">
                                        <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Cost Rate:</label>
                                        <%--<textarea class="form-control" id="message-text"></textarea>--%>
                                        <asp:TextBox ID="txtCostRate" runat="server" value="0" class="form-control" Style="width: 60%;" TextMode="Number"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtCostRate"
                                            Visible="true" Style="margin-left: 34%;" ValidationGroup="validationItem" ForeColor="Red"
                                            ErrorMessage="Please enter Cost Rate"></asp:RequiredFieldValidator>
                                    </div>

                                    <asp:Label ID="lblItemErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                </div>
                                <%--<div class="form-group m-form__group row">
                                        <div class="col-xl-9 col-lg-9">
                                            <asp:Label ID="Label1" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>--%>

                                <div class="modal-footer">
                                    <asp:Button ID="btnCloseItem" Text="Close" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnCloseItem_Click" />
                                    <asp:Button ID="btnItemSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" CausesValidation="true" ValidationGroup="validationItem" OnClick="btnItemSave_Click" Text="Save" />

                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnItemSave" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <!-- End Modal -->
        </asp:Panel>
        <!-- end:: Body -->

        <!-- begin::Scroll Top -->
        <div id="m_scroll_top" class="m-scroll-top">
            <i class="la la-arrow-up"></i>
        </div>

        <!-- end::Scroll Top -->

    </div>


</asp:Content>
