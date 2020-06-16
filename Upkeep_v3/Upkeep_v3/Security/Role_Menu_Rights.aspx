<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Role_Menu_Rights.aspx.cs" Inherits="Upkeep_v3.Security.Role_Menu_Rights" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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

        .hide_column {
            display: none;
            width: 0px;
        }
 

    </style>


    <%--"ajax": "data/objects.txt",
            "columns": [
                { "data": "Role_Menu_ID" },
                { "data": "Menu_Id" },
                { "data": "Parent_Menu_Id" },
                { "data": "Role_Id" },
                { "data": "Menu_Desc" },
                { "data": "SelectAll" },
                { "data": "Is_Add" },
                { "data": "Is_Update" },
                { "data": "Is_Read" },
                { "data": "Is_Delete" },
                { "data": "Is_Export" }],

    
            //$.ajax({
            //    type: "POST",
            //    dataType: "json",
            //    url: "Upkeep_V3_Services.asmx/Get_Role_MENU_Rights?RoleID=1&ParentMenuId=3",
            //    success: function (data) {

    --%>

    <script type="text/javascript">

        $(document).ready(function () { 
            $('#m_table_1').DataTable({
                "columnDefs": [//className: "hide_column" ,
                    { "targets": [0], "searchable": false, className: "hide_column" }
                    //, null, null, null, null, null, null, null

                    //,{ "targets": [1], "visible": false, "searchable": false },
                    //{ "targets": [2], "visible": false, "searchable": false }
                    //,
                    //{
                    //    "targets": [4], "searchable": false, "orderable": false, "className": "dt-body-center"//,
                    //    //"render": function (data, type, full, meta) {
                    //    //    return '<input type="checkbox" name="id[]" value="' + $('<div/>').text(data).html() + '">";
                    //    //}
                    //}
                ],
                responsive: true,
                pagingType: 'full_numbers', 
                'fnDrawCallback': function () {
                    init_plugins(); 
                }
            });

            $('input[name="Selectcheck"]').click(function () {
                //alert('Ccc');
                //alert($(this).attr("id"));
                var isChck = 99;
                if ($(this).prop("checked") == true) {
                    //alert("Checkbox is checked.");
                    isChck = 1;
                }
                //else if ($(this).prop("checked") == false) {
                //    //alert("Checkbox is unchecked.");
                //    isChck = 0;
                //}

                var vl = $(this).attr("id").replace("idSelect", "");
                var idx = "idTr" + vl;
                //var i = $(this).parent('td').parent('tr').data('id');
                //alert(idx);
                $('#m_table_1 tr').each(function () {
                    if ($(this).attr("id") == idx) {
                        $(this).find("td input:checkbox").each(function () {
                            if (isChck == 1) {
                                //alert("q1");
                                $(this).attr("checked", true);
                                $(this).prop('checked', true);
                            }
                            else {
                                //alert("q2");
                                $(this).attr("checked", false);
                                $(this).prop('checked', false);
                            }
                        });
                    }
                });
            });

            $('input[name="Inptcheck"]').click(function () {

               if ($(this).prop("checked") == true) {
                   $(this).attr("checked", true);
               }
               else {
                   $(this).attr("checked", false);
               }

                
                var trid = $(this).closest('tr').attr('id');
                var vl = "#idSelect" + trid.replace("idTr", "");
                //alert(vl);
                $(vl).prop('checked', false);
            });


            $('#<%=Button1.ClientID%>').click(function () {
                //alert("f");
                var heads = [];
                $("thead").find("th").each(function () {
                    heads.push($(this).text().trim());
                });
                var rows = [];
                $("tbody tr").each(function () {
                    var cur = {};
                    $(this).find("td").each(function (i, v) {
                        if (($(this).find('input[type="checkbox"]')).length) {

                            if ($(this).find('input[type="checkbox"]').attr('checked')) {
                                cur[heads[i]] = 1;
                            }
                            else {
                                cur[heads[i]] = 0;
                            }
                        }
                        else {
                            cur[heads[i]] = $(this).text().trim();
                        }
                    });
                    rows.push(cur);
                    cur = {};
                });
                //alert(JSON.stringify(rows));
                var Valuess = JSON.stringify(rows);
                $('#<%= hdTableJsonData.ClientID %>').val(Valuess);
                //alert(hdTableJsonData.text);

                $('#<%=btnSubmit.ClientID%>').click();
                return false;

            });

        });
    </script>

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="m-portlet m-portlet--mobile">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <h3 class="m-portlet__head-text">Set Role Menu Rights		
                            </h3>
                        </div>
                    </div>
                </div>
                <div class="m-portlet__body">
                    <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>
                    <div class="form-group m-form__group row" style="padding-left: 1%;">
                        <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Role Name :</label>
                        <div class="col-xl-4 col-lg-4">
                            <asp:DropDownList ID="ddlRole" class="form-control m-input" runat="server" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        </div>
                        <div class="col-xl-3 col-lg-3">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlRole" Visible="true" Display="Dynamic" SetFocusOnError="True"
                                ValidationGroup="validateRole" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Role"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group m-form__group row" style="padding-left: 1%;">
                        <label class="col-xl-2 col-lg-2 form-control-label"><span style="color: red;">*</span> Menu Name :</label>
                        <div class="col-xl-4 col-lg-4">
                            <asp:DropDownList ID="ddlMenu" class="form-control m-input" runat="server" OnSelectedIndexChanged="ddlMenu_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        </div>
                        <div class="col-xl-3 col-lg-3">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlMenu" Visible="true" Display="Dynamic" SetFocusOnError="True"
                                ValidationGroup="validateRole" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Menu"></asp:RequiredFieldValidator>
                        </div>
                    </div>


                    <%--<div class="m-portlet__body" style="overflow-x: scroll;">--%>
                    <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">
                        <thead>
                            <tr>
                                <th>Menu_Id</th>
                                <%--<th>Parent_Menu_Id</th>--%>
                                <%--<th>Role_Id</th>--%>
                                <th>Menu</th>
                                <th>SelectAll</th>
                                <th>Add</th>
                                <th>Update</th>
                                <th>Read</th>
                                <th>Delete</th>
                                <th>Export</th>
                            </tr>
                        </thead>
                        <tbody>
                            <%=BindData()%>
                        </tbody>
                    </table>
                    <%--</div>--%>

                    <div id="divInsertButton" class="col-lg-9 ml-lg-auto" runat="server">
                        <asp:HiddenField ID="hdTableJsonData" runat="server" />
                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Style="margin-right: 20px; display: none" Text="Submit"
                            OnClick="btnSubmit_Click" />
                        <asp:Button ID="Button1" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Style="margin-right: 20px;" Text="Submit" ValidationGroup="validateRole" />
                        <asp:Button ID="btnCancel" runat="server" class="btn btn-secondary btn-outline-hover-danger btn-sm m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10" Style="margin-right: 20px;" Text="Cancel" OnClick="btnCancel_Click" />
                        <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-8 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
                    </div>


                    <div class="btn-group">
                        <asp:Button ID="btnTest" Style="display: none;" runat="server" />
                        <cc1:ModalPopupExtender ID="mpeWpRequestSaveSuccess" runat="server" PopupControlID="pnlWpReqestSuccess" TargetControlID="btnTest"
                            CancelControlID="btnCloseHeader2" BackgroundCssClass="modalBackground">
                        </cc1:ModalPopupExtender>
                    </div>
                    <asp:Panel ID="pnlWpReqestSuccess" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
                        <div class="" id="add_sub_location2" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                            <div class="modal-dialog" role="document" style="max-width: 590px;">
                                <div class="modal-content">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div class="modal-header">
                                                <h5 class="modal-title" id="exampleModalLabel2">Menu Rights Confirmation</h5>
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader2">
                                                    <span aria-hidden="true">&times;</span>
                                                </button>
                                            </div>
                                            <div class="modal-body">
                                                <div class="form-group m-form__group row">
                                                    <label for="recipient-name" class="col-xl-8 col-lg-3 form-control-label">Menu Rights has been saved successfully</label>
                                                </div>
                                            </div>
                                            <%--<div class="modal-footer">
                                                <asp:Button ID="btnSuccessOk" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="Ok" OnClick="btnSuccessOk_Click" />
                                            </div>--%>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnTest" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>

                </div>



            </div>
        </div>

        <!-- END EXAMPLE TABLE PORTLET-->
    </div>



</asp:Content>
