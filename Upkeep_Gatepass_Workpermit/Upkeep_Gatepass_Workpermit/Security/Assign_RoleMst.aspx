<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Assign_RoleMst.aspx.cs" Inherits="Upkeep_Gatepass_Workpermit.Security.Assign_RoleMst" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            DatatableHtmlTableDemo.init();
        });

        var DatatableHtmlTableDemo = {
            init: function () {
                var e; e = $(".m-datatable").mDatatable({
                    data: { saveState: { cookie: !1 } },
                    search: { input: $("#generalSearch") }
                    //,columns: [                  
                    //{
                    //    field: "Status", title: "Status", template: function (e) {
                    //        var t =
                    //        {
                    //            "Open": { title: "Open", class: "m-badge--danger" },
                    //            "Close": { title: "Closed", class: " m-badge--success" },
                    //            "Approve": { title: "Approved", class: " m-badge--info" },
                    //            "Hold": { title: "Hold", class: " m-badge--warning" },
                    //            "Reject": { title: "Rejected", class: " m-badge--danger" },
                    //            "In Progress": { title: "In Progress", class: " m-badge--success" }
                    //        }; return '<span class="m-badge ' + t[e.Status].class + ' m-badge--wide">' + t[e.Status].title + "</span>"
                    //    }
                    //    }



                    //]
                    , responsive: true,
                    pagingType: 'full_numbers',
                    scrollX: true,
                    'fnDrawCallback': function () {
                        init_plugins();
                    }



                })
                //,

                //$("#m_form_status").on("change", function () { e.search($(this).val().toLowerCase(), "Status") }),
                //$("#m_form_status").selectpicker()

            }
        };


    </script>

    <%--<script>
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
    </script>--%>

    <style type="text/css">
    .hiddencol
    {
        display: none;
    }
</style>

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                        <%--<form class="m-form m-form--label-align-left- m-form--state-" runat="server" id="frmGatePass" method="post">--%>
                        <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>


                        <div class="m-portlet__head">
                            <div class="m-portlet__head-progress">

                                <!-- here can place a progress bar-->
                            </div>
                            <div class="m-portlet__head-wrapper">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">Assign Role Master
                                        </h3>
                                    </div>
                                </div>
                                <div class="m-portlet__head-tools">
                                        <a href="<%= Page.ResolveClientUrl("~/Security/Assign_RoleList.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                            <span>
                                                <i class="la la-arrow-left"></i>
                                                <span>Back</span>
                                            </span>
                                        </a>
                                        
                                    </div>
                            </div>
                        </div>

                        <div class="m-portlet__body" style="padding: 0.4rem 2.2rem;">

                            <div class="form-group m-form__group row" style="padding-left: 1%;">
                                <label class="col-xl-3 col-lg-2 form-control-label font-weight-bold" style="text-align: right;"><span style="color: red;">*</span> Role :</label>
                                <div class="col-xl-4 col-lg-4">
                                    <asp:DropDownList ID="ddlRole" class="form-control m-input" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlRole" Visible="true" Display="Dynamic"
                                        ValidationGroup="validateAssignRole" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Role"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <br />

                            <div class="col-md-3">
                                <div class="m-input-icon m-input-icon--left">
                                    <input type="text" class="form-control m-input" placeholder="Search..." id="generalSearch" />
                                    <span class="m-input-icon__icon m-input-icon__icon--left">
                                        <span><i class="la la-search"></i></span>
                                    </span>
                                </div>
                            </div>

                            <br />

                            <div class="form-group m-form__group row" style="padding-left: 1%;">

                                <div class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">
                                    <asp:GridView ID="gvEmployee" runat="server" CssClass="table table-striped- table-bordered table-hover table-checkable m-datatable"
                                        OnRowDataBound="gvEmployee_RowDataBound" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                                        AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField >
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkEmployee" runat="server" CssClass="checkbox--success" Checked='<%# Convert.ToBoolean(Eval("IsAssigned")) %>'/>
                                                    <asp:HiddenField ID="hdnEmployeeID" runat="server" Value='<%#Eval("EmployeeID") %>'/>
                                                    
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" ItemStyle-Width="150" Visible="false" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                            <asp:BoundField DataField="Code" HeaderText="Employee Code" ItemStyle-Width="150" />
                                            <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="150" />
                                            <asp:BoundField DataField="Company" HeaderText="Company" ItemStyle-Width="150" />
                                            <asp:BoundField DataField="Location" HeaderText="Location" ItemStyle-Width="150" />
                                            <asp:BoundField DataField="Department" HeaderText="Department" ItemStyle-Width="150" />
                                            <asp:BoundField DataField="Designation" HeaderText="Designation" ItemStyle-Width="150" />

                                        </Columns>
                                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                    </asp:GridView>

                                </div>

                                <div id="divInsertButton" class="col-xl-12 col-lg-4" runat="server" style="text-align: center;" >
                                    <asp:Button ID="btnSubmit" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Style="margin-right: 20px;" Text="Submit" ValidationGroup="validateAssignRole"
                                        OnClick="btnSubmit_Click" />
                                    <asp:Button ID="btnCancel" runat="server" class="btn btn-secondary btn-outline-hover-danger btn-sm m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10" Style="margin-right: 20px;" Text="Cancel" OnClick="btnCancel_Click" />
                                    <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-8 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
                                </div>

                            </div>




                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
