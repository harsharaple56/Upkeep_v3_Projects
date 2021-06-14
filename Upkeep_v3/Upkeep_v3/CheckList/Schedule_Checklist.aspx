<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Schedule_Checklist.aspx.cs" Inherits="Upkeep_v3.CheckList.Schedule_Checklist" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript"></script>
    <%--<script src="<%= Page.ResolveClientUrl("~/vendors/bootstrap/js/src/tab.js") %>" type="text/javascript"></script>--%>

    <script type="text/javascript">
        $(document).ready(function () {
            DatatableHtmlTableDemo.init();
            //DatatableHtmlTableDemoGroup.init();

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

                    , responsive: true,
                    // pagingType: 'full_numbers',
                    scrollX: true,
                    scrollY: true
                    //,'fnDrawCallback': function () {
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
                    scrollX: true
                    , 'fnDrawCallback': function () {
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


    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">

            <!--begin::Portlet-->
            <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" runat="server" id="frmMain1">
                <cc1:ToolkitScriptManager runat="server"></cc1:ToolkitScriptManager>

                <div class="m-form" id="employee_form">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-progress">
                        </div>
                        <div class="m-portlet__head-wrapper">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <h3 class="m-portlet__head-text">Checklist Scheduling</h3>
                                </div>
                            </div>

                            <div class="m-portlet__head-tools">
                                <a href="<%= Page.ResolveClientUrl("~/Checklist/Schedule_Checklist_Listing.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                    <span>
                                        <i class="la la-arrow-left"></i>
                                        <span>Back</span>
                                    </span>
                                </a>
                                <div>
                                    <asp:Button ID="btnSaveChecklistSchedule" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnSaveChecklistSchedule_Click"
                                        Text="Save" ValidationGroup="validationChecklist" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <!--begin: Form Body -->
                    <div class="m-portlet__body">
                        <div class="modal-body">
                            <div class="form-group row">
                                <div class="col-xs-2 col-lg-2 form-inline">
                                    <label for="message-text" class="form-control-label" style="text-align: right;">Checklist :</label>
                                </div>
                                <div class="col-xs-10 col-lg-10 form-inline">
                                    <asp:DropDownList ID="ddlChecklist" class="form-control m-input" Style="width: 50%;" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvCat" runat="server" ControlToValidate="ddlChecklist" Display="Dynamic"
                                        ValidationGroup="validationChecklist" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Checklist"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-xs-2 col-lg-2 form-inline">
                                    <label for="recipient-name" class="form-control-label">Department :</label>
                                </div>
                                <div class="col-xs-10 col-lg-10 form-inline">
                                    <asp:DropDownList ID="ddlDepartment" class="form-control m-input" Style="width: 50%;" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvSubCat" runat="server" ControlToValidate="ddlDepartment" Display="Dynamic"
                                        ValidationGroup="validationChecklist" ForeColor="Red" InitialValue="0" ErrorMessage="Please select Department"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <br />
                            <div class="form-group row">
                                <div class="col-xs-5 col-lg-5 form-inline">
                                    <h4>Selected Locations</h4>
                                </div>
                                <asp:Button ID="btnAddLocation" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="Add Location" ValidationGroup="validationChecklist" />
                                <cc1:ModalPopupExtender ID="mpeAddLocation" runat="server" PopupControlID="pnlAddLocation" TargetControlID="btnAddLocation"
                                    CancelControlID="btnClose2" BackgroundCssClass="modalBackground">
                                </cc1:ModalPopupExtender>
                                <asp:Label ID="lblError" runat="server" class="form-control-label" ClientIDMode="Static" ForeColor="Red" Style="margin-left: 21%;"></asp:Label>
                                <asp:Label ID="lblSuccessMsg" runat="server" class="form-control-label" ForeColor="Green" Style="margin-left: 21%;"></asp:Label>

                            </div>

                            <div class="form-group row">

                                <div id="m_table_1" style="padding: 10px; width: 750px; overflow-x: auto;">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="gvSelectedLocation" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvSelectedLocation_RowDataBound"
                                                DataKeyNames="Loc_Id" 
                                                OnRowDeleting="gvSelectedLocation_RowDeleting" EmptyDataText="No records has been added."
                                                HeaderStyle-BackColor="#f4f3f8" HeaderStyle-ForeColor="Black" >
                                                <Columns>
                                                    
                                                    <asp:TemplateField HeaderText="Selected Location" ItemStyle-Width="550" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Loc_Name") %>'></asp:Label>
                                                            <asp:HiddenField ID="hdnLocID" runat="server" Value='<%#Eval("Loc_Id") %>' />
                                                        </ItemTemplate>
                                                      
                                                    </asp:TemplateField>
                                                   
                                                    <asp:CommandField ButtonType="Link" ShowDeleteButton="true" HeaderText="Action" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                        ItemStyle-Width="150" />
                                                </Columns>
                                            </asp:GridView>
                                            <br />
                                            <br />

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>


                            </div>


                        </div>


                    </div>

                </div>

                <!--end::Portlet-->



                <asp:Panel runat="server" ID="pnlAddLocation" CssClass="modalPopup" align="center" Style="display: none; width: 100%;">
                    <div class="" id="add_sub_location" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div class="modal-dialog" role="document" style="max-width: 60%;">
                            <div class="modal-content">

                                <div class="modal-header">
                                    <h3 id="myModalLabel">Location</h3>
                                    <button type="button" id="btnClose2" class="close" data-dismiss="modal" aria-hidden="true">×</button>

                                </div>
                                <div class="modal-body" style="max-height: 400px; overflow: scroll;">
                                    <div class="box">

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
                                                                </div>
                                                                <div class="col-md-3" style="text-align: right;">
                                                                    <asp:Button ID="btnSelectLocation" runat="server" Text="Add Location" OnClick="btnSelectLocation_Click" class="btn btn-primary btn-success" />
                                                                </div>
                                                            </div>
                                                            <br />

                                                            <asp:HiddenField ID="hdnSelectedUserID" runat="server" ClientIDMode="Static" />
                                                            <asp:HiddenField ID="hdnSelectedUserName" runat="server" ClientIDMode="Static" />

                                                            <asp:GridView ID="gvLocation" runat="server" CssClass="table table-striped- table-bordered table-hover table-checkable m-datatableUser"
                                                                AutoGenerateColumns="false" SkinID="grdSearch" OnRowDataBound="gvLocation_RowDataBound">
                                                                <Columns>
                                                                    <asp:BoundField DataField="Loc_ID" Visible="false"></asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Select">
                                                                        <ItemTemplate>
                                                                            <%--<asp:CheckBox ID="chkUserID" runat="server" CssClass="checkbox--success" Checked='<%# Convert.ToBoolean(Eval("Is_Selected")) %>' />--%>

                                                                            <asp:CheckBox ID="chkLocationID" runat="server" CssClass="m-checkbox--success" />

                                                                            <asp:HiddenField ID="hdnLocationID" runat="server" Value='<%#Eval("Loc_ID") %>' />
                                                                            <asp:HiddenField ID="hdnLocation_Name" runat="server" Value='<%#Eval("Loc_Desc") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Location" SortExpression="Loc_Desc">
                                                                        <ItemTemplate>
                                                                            <a style="cursor: pointer; text-decoration: underline;" onclick="FunEditClick('<%# (DataBinder.Eval(Container.DataItem,"Loc_ID")) %>#0','<%# (DataBinder.Eval(Container.DataItem,"Loc_Desc")) %>')">
                                                                                <%# (DataBinder.Eval(Container.DataItem, "Loc_Desc"))%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                </Columns>

                                                                <EmptyDataTemplate>No Records Found !!!</EmptyDataTemplate>
                                                                <EmptyDataRowStyle Height="50%" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Center" />
                                                            </asp:GridView>

                                                        </ContentTemplate>

                                                    </asp:UpdatePanel>
                                                </div>

                                            </div>
                                        </div>

                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </asp:Panel>

                <%--<cc1:ModalPopupExtender ID="mpeWorkflowUsers" runat="server" PopupControlID="pnlWorkflowUsers" TargetControlID="pop2"
                            CancelControlID="btnClose2" BackgroundCssClass="modalBackground">
                        </cc1:ModalPopupExtender>--%>

                <asp:Button Text="text" Style="display: none" ID="pop2" runat="server" />

                <input type="hidden" id="HdnID" runat="server" />
                <asp:TextBox ID="txtHdn" runat="server" ClientIDMode="Static" Width="100%" Style="display: none"></asp:TextBox>

            </div>

        </div>
    </div>

</asp:Content>
