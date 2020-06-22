<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Workflow_Details.aspx.cs" Inherits="Upkeep_v3.Ticketing.Workflow_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <%--<script src="<%= Page.ResolveClientUrl("~/vendors/bootstrap/js/src/tab.js") %>" type="text/javascript"></script>--%>

    <script type="text/javascript">
        $(document).ready(function () {
            //DatatableHtmlTableDemo.init();
            DatatableHtmlTableDemoGroup.init();

             //$("#ddlDepartment").on("change", function () {
             //           //alert('department clicked');
             //           var selection = $("#ddlDepartment option:selected").html();
             //           var dataset = $('#grdInfodetails tbody').find('tr');
             //           // show all rows first
             //           dataset.show();
             //           // filter the rows that should be hidden
             //           dataset.filter(function (index, item) {
             //               return $(item).find('td:nth-child(4)').text().indexOf(selection) === -1;
             //           }).hide();
             //           //e.search($(this).val().toLowerCase(), "Department")
             //       })
        });

        var DatatableHtmlTableDemo = {
            init: function () {
                var e; e = $(".m-datatableUser").mDatatable({
                    data: { saveState: { cookie: !1 } },
                    search: { input: $("#generalSearch") }

                    //, responsive: true,
                    //pagingType: 'full_numbers',
                    //scrollX: true,
                    //scrollY: true,
                    //'fnDrawCallback': function () {
                    //    init_plugins();
                    //}
                })
            //    ,
            //$("#ddlDepartment").on("change", function () {
            //        alert('department clicked');
            //    e.search($(this).val().toLowerCase(), "Department")
            //        })
                    //$("#ddlDepartment").selectpicker()
            }
        };

        var DatatableHtmlTableDemoGroup = {
            init: function () {
                var e; e = $(".m-datatableGroup").mDatatable({
                    data: { saveState: { cookie: !1 } },
                    search: { input: $("#generalSearchGroup") }

                    , responsive: true,
                    pagingType: 'full_numbers',
                    scrollX: true,
                    'fnDrawCallback': function () {
                        init_plugins();
                    }
                })
            }
        };


    </script>

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

    <%--<script type="text/javascript">
        $(document).ready(function () {
            //alert('hi');
            $('#grdInfodetails').DataTable({
                responsive: true,
                pagingType: 'full_numbers',
                'fnDrawCallback': function () {
                    init_plugins();
                }
            });
        });
    </script>--%>


    <script type="text/javascript">
        var txtControl = null;
        var txtHdn = null;
        function PopUpGrid(obj, objhdn) {
            //debugger;
            $find('<%= mpeWorkflowUsers.ClientID %>').show();
            txtHdn = objhdn.toString();
            txtControl = obj;
        }

         function funddl() {
             //alert('department clicked');
                        var selection = $("#ddlDepartment option:selected").html();
                        var dataset = $('#grdInfodetails tbody').find('tr');
                        // show all rows first
                        dataset.show();
                        // filter the rows that should be hidden
                        dataset.filter(function (index, item) {
                            return $(item).find('td:nth-child(4)').text().indexOf(selection) === -1;
                        }).hide();
        }

        function FunEditClick(ID, Desc) {
            //debugger;
            //alert(ID);
            //alert(Desc);
            txtControl.value = Desc.replace("$", ",");
            document.getElementById('ContentPlaceHolder1_' + txtHdn).value = ID;
            //document.getElementById("<%= txtHdn.ClientID%>").value = ID;
            $find('<%= mpeWorkflowUsers.ClientID %>').hide();
            //window.close();

        }

        function SelectUser() {
            //alert('method call');
            //debugger;
            var SelectedUsersID = null;
            var SelectedUsersName = null;

            //$('#grdInfodetails').DataTable({
            //    responsive: true,
            //    pagingType: 'full_numbers',
            //    'fnDrawCallback': function () {
            //        init_plugins();
            //    }
            //});

            //var hiddenValue = $('#hdnSelectedUserID').val();
            //var hiddenValue2 = $('#hdnSelectedUserName').val();  

            SelectedUsersID = document.getElementById('<%= hdnSelectedUserID.ClientID%>').value + "#0";
            SelectedUsersName = document.getElementById('<%= hdnSelectedUserName.ClientID%>').value;

            //SelectedUsersID = '<%= Session["SelectedUsersID"].ToString() %>';
            //SelectedUsersName = '<%= Session["SelectedUsersName"].ToString() %>';

            //alert(SelectedUsersID);
            //alert(SelectedUsersName);

            FunEditClick(SelectedUsersID, SelectedUsersName);
        }

        function removeRows() {
            //alert('remove');
            $("#ctl00_cntPlaceHolder_TblLevels").find("tr:gt(0)").remove();
        }

        function FunSetXML() {
            //debugger;
            window.document.getElementById("<%= txtHdn.ClientID%>").value = "";
            var VarLocTab = window.document.getElementById("<%=TblLevels.ClientID%>");
            for (var i = 1; i <= VarLocTab.rows.length - 1; i++) {
                var VarLocRowObj = VarLocTab.rows[i].id;
                var lvl = window.document.getElementById(VarLocRowObj).children[0].innerHTML;
                if ((window.document.getElementById(VarLocRowObj).children[1].children[2].value) == "") {
                    ShowNotification("Warning !", "Action Details Should not be blank");
                    alert('Action Details Should not be blank');
                    return false;
                }
                else {
                    var action = window.document.getElementById(VarLocRowObj).children[1].children[2].value;
                }
                //        var action = window.document.getElementById(VarLocRowObj).children[1].children[2].value;



                if (document.getElementById(VarLocRowObj).children[2].children[0].checked == true) {
                    var SendEmail = 1;
                }
                else {
                    var SendEmail = 0;

                }

                if (document.getElementById(VarLocRowObj).children[3].children[0].checked == true) {
                    var SendEmailText = 1;
                }
                else {
                    var SendEmailText = 0;
                }

                if (document.getElementById(VarLocRowObj).children[4].children[0].checked == true) {
                    var SendNotification = 1;
                }
                else {
                    var SendNotification = 0;
                }


                if (window.document.getElementById(VarLocRowObj).children[5].children[0].value == "") {
                    ShowNotification("Warning !", "Time Should not be blank");
                    //alert('Time Should not be blank');
                    return false;
                }
                else {
                    var time = window.document.getElementById(VarLocRowObj).children[5].children[0].value;
                }

                var nxtlvl = window.document.getElementById(VarLocRowObj).children[6].innerHTML;

                //if (window.document.getElementById(VarLocRowObj).children[6].children[2].value == "") {
                //    var inf = "0#0";
                //}
                //else {
                //    var inf = window.document.getElementById(VarLocRowObj).children[6].children[2].value;
                //}


                //if (document.getElementById(VarLocRowObj).children[7].children[0].checked == true) {
                //    var SendEmailInformation = 1;
                //}
                //else {
                //    var SendEmailInformation = 0;
                //}

                //if (document.getElementById(VarLocRowObj).children[8].children[0].checked == true) {
                //    var SendEmailTextInformation = 1;
                //}
                //else {
                //    var SendEmailTextInformation = 0;
                //}


                //var strInfo = lvl + "#" + action + "#" + SendEmail + "#" + SendEmailText + "#" + time + "#" + nxtlvl + "#" + inf + "#" + SendEmailInformation + "#" + SendEmailTextInformation;
                var strInfo = lvl + "#" + action + "#" + SendEmail + "#" + SendEmailText + "#" + SendNotification + "#" + time + "#" + nxtlvl;

                if (window.document.getElementById("<%= txtHdn.ClientID%>").value == "") {
                    <%--window.document.getElementById("<%= txtHdn.ClientID%>").value += "=$=" + strInfo + "=$=";--%>
                    window.document.getElementById("<%= txtHdn.ClientID%>").value += strInfo + ",";
                }
                else {
                    <%--window.document.getElementById("<%= txtHdn.ClientID%>").value += strInfo + "=$=";--%>
                    window.document.getElementById("<%= txtHdn.ClientID%>").value += strInfo + ",";
                }

            }
            return true;
        }

    </script>



    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content" style="padding: 7px 4px;">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" runat="server" id="frmMain1">
                        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

                        <div class="m-form m-form--label-align-left- m-form--state-" id="employee_form">
                            <div class="m-portlet__head">
                                <div class="m-portlet__head-progress">



                                    <!-- here can place a progress bar-->
                                </div>
                                <div class="m-portlet__head-wrapper">
                                    <div class="m-portlet__head-caption">
                                        <div class="m-portlet__head-title">
                                            <h3 class="m-portlet__head-text">Workflow Details</h3>
                                        </div>
                                    </div>

                                    <div class="m-portlet__head-tools">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="lblWorkflowErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>

                                                <a href="<%= Page.ResolveClientUrl("~/Ticketing/Workflow_Master.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                                    <span>
                                                        <i class="la la-arrow-left"></i>
                                                        <span>Back</span>
                                                    </span>
                                                </a>
                                                <div class="btn-group">

                                                    <asp:Button ID="btnSaveWorkflowDetail" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnSaveWorkflowDetail_Click"
                                                        Text="Save" OnClientClick="return FunSetXML();" ValidationGroup="validationWorkflow" />

                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                            <div class="">
                                <!--begin: Form Body -->
                                <div class="m-portlet__body">
                                    <div class="row">
                                        <div class="modal-body">
                                            <div class="row" style="margin-bottom: 0;">
                                                <div class="col-xs-8 col-lg-6 form-inline">
                                                    <label for="message-text" class="col-xl-5 col-lg-5 form-control-label" style="text-align: right;">Workflow Description :</label>
                                                    <asp:TextBox ID="txtWorkflowDesc" class="form-control m-input" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtWorkflowDesc" Visible="true"
                                                        Style="margin-left: 34%;" ValidationGroup="validationWorkflow" ForeColor="Red" ErrorMessage="Please enter Workflow Description"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-xs-8 col-lg-6 form-inline" style="display: none;">
                                                    <label for="recipient-name" class="col-xl-4 col-lg-3 form-control-label">Zone :</label>
                                                    <asp:DropDownList ID="ddlZone" class="form-control m-input" Style="width: 43%;" runat="server"></asp:DropDownList>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlZone" Visible="true" Style="margin-left: 34%;"
                                                            ValidationGroup="validationWorkflow" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Zone"></asp:RequiredFieldValidator>--%>
                                                </div>

                                            </div>

                                            <%--<div class="row" >--%>
                                                <asp:UpdatePanel runat="server" style="width: 100%;">
                                                    <ContentTemplate>
                                                        <div class="form-group row" style="margin-bottom: 0;">
                                                        <div class="col-xs-8 col-lg-6 form-inline">
                                                            <label for="message-text" class="col-xl-5 col-lg-5 form-control-label" style="text-align: right;">Category :</label>
                                                            <asp:DropDownList ID="ddlCategory" class="form-control m-input" Style="width: 43%;" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="rfvCat" runat="server" ControlToValidate="ddlCategory" Visible="true" Style="margin-left: 34%;"
                                                                ValidationGroup="validationWorkflow" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Category"></asp:RequiredFieldValidator>

                                                        </div>
                                                        <div class="col-xs-8 col-lg-6 form-inline" style="margin-bottom: 0;">
                                                            <label for="recipient-name" class="col-xl-4 col-lg-3 form-control-label">Sub-Category :</label>
                                                            <asp:DropDownList ID="ddlSubCategory" class="form-control m-input" Style="width: 43%;" runat="server"></asp:DropDownList>
                                                            <%--<asp:RequiredFieldValidator ID="rfvSubCat" runat="server" ControlToValidate="ddlSubCategory" Visible="true" Style="margin-left: 34%;"
                                                                ValidationGroup="validationWorkflow" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Sub Category"></asp:RequiredFieldValidator>--%>
                                                        </div>
                                                            </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                           <%-- </div>--%>
                                            <%--<div class="form-group row" style="margin-bottom: 0;">
                                                    <label for="recipient-name" class="col-xl-4 col-lg-3 form-control-label">Zone :</label>
                                                    <asp:DropDownList ID="ddlZone" class="form-control m-input" Style="width: 25%;" runat="server"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlZone" Visible="true" Style="margin-left: 34%;"
                                                        ValidationGroup="validationWorkflow" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Zone"></asp:RequiredFieldValidator>
                                                </div>--%>
                                            <div class="form-group row" style="margin-bottom: 0;">
                                                <label for="message-text" class="col-xs-8 col-lg-2 form-control-label" style="text-align: center;">No Of Levels :</label>
                                                <asp:TextBox ID="txtNoOfLevel" runat="server" class="form-control" Style="width: 21%; margin-left: 4%;"></asp:TextBox>

                                                <asp:Button ID="btnMakeCombination" runat="server" class="m-badge m-badge--brand m-badge--wide" Style="margin-left: 5%; cursor: pointer;" OnClick="btnMakeCombination_Click" Text="Make Combination" ValidationGroup="validationWorkflow" />

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNoOfLevel" Visible="true"
                                                    Style="margin-left: 1%; margin-top: 1%;" ValidationGroup="validationWorkflow" ForeColor="Red" ErrorMessage="Please enter No of Level"></asp:RequiredFieldValidator>


                                            </div>

                                            <div class="row">
                                                <br />
                                            </div>


                                            <table class="table table-nomargin" id="TblLevels" runat="server" visible="true">
                                                <thead>
                                                    <tr>
                                                        <th>Level
                                                        </th>
                                                        <th>Action/Action Group
                                                        </th>
                                                        <th>Email
                                                        </th>
                                                        <th>SMS
                                                        </th>
                                                        <th>Notification
                                                        </th>
                                                        <th>Time(in Mins.)
                                                        </th>
                                                        <th>Next Level
                                                        </th>

                                                    </tr>
                                                </thead>

                                            </table>



                                            <asp:Label ID="lblWorkflowErrorMsg1" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>

                        <!--end::Portlet-->



                        <asp:Panel runat="server" ID="pnlWorkflowUsers" CssClass="modalPopup" align="center" Style="display: none; width: 100%;">
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
                                                                            <label class="col-form-label col-xl-4 col-lg-3 ">Department:</label>
                                                                            <asp:DropDownList ID="ddlDepartment" class="form-control m-input" ClientIDMode="Static" Style="width: 40%;"  onchange="funddl();"  OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged"  runat="server"></asp:DropDownList>

                                                                        </div>
                                                                        <div class="col-md-3" style="text-align: right;">
                                                                            <asp:Button ID="btnSelectUser" runat="server" Text="Select User" OnClick="btnSelectUser_Click" class="btn btn-primary btn-success" />
                                                                        </div>
                                                                    </div>
                                                                    <br />

                                                                    <asp:HiddenField ID="hdnSelectedUserID" runat="server" ClientIDMode="Static" />
                                                                    <asp:HiddenField ID="hdnSelectedUserName" runat="server" ClientIDMode="Static" />

                                                                    <asp:GridView ID="grdInfodetails" runat="server" ClientIDMode="Static" CssClass="table table-striped- table-bordered table-hover table-checkable m-datatableUser"
                                                                        AutoGenerateColumns="false" SkinID="grdSearch" OnRowDataBound="grdInfodetails_RowDataBound">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="ActionInfoId" Visible="false"></asp:BoundField>
                                                                            <asp:TemplateField HeaderText="Select">
                                                                                <ItemTemplate>
                                                                                    <%--<asp:CheckBox ID="chkUserID" runat="server" CssClass="checkbox--success" Checked='<%# Convert.ToBoolean(Eval("Is_Selected")) %>' />--%>

                                                                                    <asp:CheckBox ID="chkUserID" runat="server" CssClass="m-checkbox--success" />

                                                                                    <asp:HiddenField ID="hdnUserID" runat="server" Value='<%#Eval("User_ID") %>' />
                                                                                    <asp:HiddenField ID="hdnUser_Name" runat="server" Value='<%#Eval("User_Name") %>' />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Action/Info Description" SortExpression="ActionInfoDesc">
                                                                                <ItemTemplate>
                                                                                    <a style="cursor: pointer; text-decoration: underline;" onclick="FunEditClick('<%# (DataBinder.Eval(Container.DataItem,"User_ID")) %>#0','<%# (DataBinder.Eval(Container.DataItem,"User_Name")) %>')">
                                                                                        <%# (DataBinder.Eval(Container.DataItem, "User_Name"))%>
                                                                                    </a>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="User_Name_Code" SortExpression="User_Name_Code" HeaderText="Employee"></asp:BoundField>
                                                                            <asp:BoundField DataField="Department" SortExpression="Department" HeaderText="Department"></asp:BoundField>
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
                                                                    <asp:BoundField DataField="ActionInfoGId" Visible="false"></asp:BoundField>

                                                                    <asp:TemplateField HeaderText="Action/Info Group Description" SortExpression="ActionInfoGroupDesc">
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
                                                    <asp:AsyncPostBackTrigger ControlID="btnWorkflowMstSave" EventName="Click" />
                                                </Triggers>--%>
                                        <%--</asp:UpdatePanel>--%>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <%--<cc1:ModalPopupExtender ID="ModalPopupExtender2" ClientIDMode="Static" CancelControlID="btnClose2" runat="server" TargetControlID="pop2" PopupControlID="modal5">
                            </cc1:ModalPopupExtender>--%>

                        <cc1:ModalPopupExtender ID="mpeWorkflowUsers" runat="server" PopupControlID="pnlWorkflowUsers" TargetControlID="pop2"
                            CancelControlID="btnClose2" BackgroundCssClass="modalBackground">
                        </cc1:ModalPopupExtender>

                        <asp:Button Text="text" Style="display: none" ID="pop2" runat="server" />

                        <input type="hidden" id="HdnID" runat="server" />
                        <asp:TextBox ID="txtHdn" runat="server" ClientIDMode="Static" Width="100%" Style="display: none"></asp:TextBox>




                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
