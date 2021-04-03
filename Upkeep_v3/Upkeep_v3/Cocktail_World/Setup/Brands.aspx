<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Brands.aspx.cs" Inherits="Upkeep_v3.Cocktail_World.Setup.Brands" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    
     <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript" ></script>

       <%--<script type="text/javascript" src="https://code.jquery.com/jquery-2.1.4.min.js"></script>
    <script src="http://code.jquery.com/ui/1.11.2/jquery-ui.js"></script>--%>

   <%-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>

    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>--%>

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
         </style>

    <script type="text/javascript">

        function CheckForm() {
            if ($('#<%=txtBrandDesc.ClientID %>').val() == "") {
                alert('Please Enter Category Desc');
                return false;
            }
            return true;
        }

        function openModal() {
            //alert('hgfhfghfg');
            $('#Add_Category').modal('show');
        }

    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            //$('#btnedit').click(function () {
            $("#btnedit").click(function(){
                //alert('edit');
                $('#Add_Category').modal('show');
                
            });
            
        });

        function openModal() {
            //alert('Hii');
            $('#Add_Category').modal('show');
        }

    </script>

     <script type="text/javascript">
            $(document).ready(function(){
                $('#m_table_1').DataTable({
                    responsive: true,
                    pagingType: 'full_numbers',
                    'fnDrawCallback': function(){
                        init_plugins();
                    }
                });
            });
        </script>

    <div runat="server">
         <cc1:ToolkitScriptManager runat="server"> </cc1:ToolkitScriptManager>
        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <div class="m-content">
                <div class="m-portlet m-portlet--mobile">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Brand Master		
                                </h3>
                            </div>
                        </div>
                        <div class="m-portlet__head-tools">
                            <ul class="m-portlet__nav">
                                <li class="m-portlet__nav-item">

                                     <asp:Button ID="btnAddcategory" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnAddcategory_Click" Text="+ New Brand" />
                           

                                     <cc1:ModalPopupExtender ID="mpeCategoryMaster" runat="server" PopupControlID="pnlCategoryMaster" TargetControlID="btnAddCategory"
                              CancelControlID="btnCloseHeader" BackgroundCssClass="modalBackground"> </cc1:ModalPopupExtender>   
                       
                                    <%--<a href="#Add_Category" class="btn btn-info m-btn m-btn--custom m-btn--icon m-btn--air" data-toggle="modal">
                                        <span>
                                    --%>        <%--<i class="la la-plus"></i>
                                            <span>New Category</span>--%>
                                       <%-- </span>
                                    </a>--%>


                                </li>
                            </ul>
                           
                          <%--  <asp:Button ID="Add_Category1" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md"  OnClick="btnAddCategory_Click" Text="+ New Category" />
                          --%>      
                        </div>
                    </div>
                    <div class="m-portlet__body">

                        <!--begin: Datatable -->
                        <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">


                            <thead>

                                <tr>
                                    <th>Brand Name</th>
                                    <th>Assigned Category</th>
                                   <%-- <th>Short Name</th>--%>
                                    <th>Action</th>
                                </tr>

                            </thead>
                            <%-- <tbody>
                            <tr>
                                <td>compel</td>
                                <td>hjsdhfsj</td>
                            </tr>
                        </tbody>--%>
                            <tbody>
                                <%=bindgrid()%>
                            </tbody>
                        </table>
                    </div>
                </div>

                <!-- END EXAMPLE TABLE PORTLET-->
            </div>
        </div>

        <!-- Start Modal -->
     <%--   <div class="modal fade" id="Add_Category" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-sm" role="document">
                <div class="modal-content" id="dvpopup" runat="server">

                
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Add New Category</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">

                        <div class="form-group">
                            <label for="recipient-name" class="form-control-label">Category Desc:</label>

                            <asp:TextBox ID="txtCategoryDesc" runat="server" class="form-control"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="rfvDeptDesc" runat="server" ControlToValidate="txtDeptDesc" Visible="true" ValidationGroup="validationZone" ForeColor="Red" ErrorMessage="Please enter Department Desc"></asp:RequiredFieldValidator>--%>
                       <%-- </div>

                    </div>

                    
                                    <div class="form-group m-form__group row">
                                        <div class="col-xl-9 col-lg-9">
                                            <asp:Label ID="lblZoneErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnCategorySave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" CausesValidation="true" ValidationGroup="validationZone" OnClick="btnCategorySave_Click" OnClientClick="return CheckForm()" Text="Save" />
                    </div>

                </div>

            </div>
        </div>--%>
        <!-- End Modal -->

          <asp:Panel ID="pnlCategoryMaster" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
                <div class="" id="add_sub_location" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document" style="max-width: 590px;">
                        <div class="modal-content">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>

                                    <div class="modal-header">
                                        <h5 class="modal-title" id="exampleModalLabel">Brand Master</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader" runat="server" onserverclick="btnCloseHeader_ServerClick"  >
                                            <span aria-hidden="true">&times;</span>
                                       <%-- <asp:Button ID="btnCloseHeader" runat="server" class="Close"/>--%>

                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        
                                       <div class="form-group m-form__group row">
                                            <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Category :</label>
                                           <asp:DropDownList ID="ddlcategory" class="form-control" Style="width: 60%" AutoPostBack="true"  OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                                       
                                           <asp:RequiredFieldValidator ID="rfvDept" runat="server" ControlToValidate="ddlcategory" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationDept" ForeColor="Red" ErrorMessage="Please select Department"></asp:RequiredFieldValidator>

                                        </div>

                                          <div class="form-group m-form__group row">
                                            <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Sub Category :</label>
                                           <asp:DropDownList ID="ddlSubCategory" class="form-control" Style="width: 60%"  OnSelectedIndexChanged="ddlSubCategory_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                                       
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlSubCategory" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationDept" ForeColor="Red" ErrorMessage="Please select Department"></asp:RequiredFieldValidator>

                                        </div>

                                        
                                        <div class="form-group m-form__group row">
                                            <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Brand Description :</label>
                                            <asp:TextBox ID="txtBrandDesc" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="txtBrandDesc" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationWorkflow" ForeColor="Red" ErrorMessage="Please enter Workflow Description"></asp:RequiredFieldValidator>

                                        </div>
                                      

                                         <div class="form-group m-form__group row">
                                            <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Strength :</label>
                                            <asp:TextBox ID="txtShortname" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtShortname" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationWorkflow" ForeColor="Red" ErrorMessage="Please enter"></asp:RequiredFieldValidator>

                                        </div>
                                     

                                        <div class="form-group m-form__group row">
                                            <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Brand Purchase Rate in Peg :</label>
                                            <asp:TextBox ID="txtPurchRatepeg" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPurchRatepeg" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationWorkflow" ForeColor="Red" ErrorMessage="Please enter"></asp:RequiredFieldValidator>

                                        </div>
                                      
                                        
                                        <div class="form-group m-form__group row">
                                            <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Brand Selling Rate in Peg:</label>
                                            <asp:TextBox ID="txtSellingRatePeg" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSellingRatePeg" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationWorkflow" ForeColor="Red" ErrorMessage="Please enter"></asp:RequiredFieldValidator>

                                        </div>


                                          <div class="form-group m-form__group row">
                                            <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Brand Selling Rate in Bottle:</label>
                                            <asp:TextBox ID="txtSellingRateBotle" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSellingRateBotle" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationWorkflow" ForeColor="Red" ErrorMessage="Please enter Value"></asp:RequiredFieldValidator>

                                        </div>

                                        
                                          <div class="form-group m-form__group row">

                                              <asp:CheckBox ID="chkBrndDisable" runat="server" class="customcontrolinput col-xl-4 col-lg-3" style="padding-right: 13px;left: -10;left: 70px;top: 3px;" />

                                        
                                        
                                              
                                              <label for="message-text" class="form-control-label">Click for Disable this brand in Transaction</label>
                                           
                                       
                                        </div>

                                      




  <asp:Label ID="lblCategoryErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                   
                                    </div>
                                    <%--<div class="form-group m-form__group row">
                                        <div class="col-xl-9 col-lg-9">
                                            <asp:Label ID="Label1" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>--%>

                                    <div class="modal-footer">
                                        <asp:Button ID="btnCloseCategory" Text="Close" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnCloseCategory_Click" />
                                        <asp:Button ID="btnCategorySave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" CausesValidation="true" ValidationGroup="validationWorkflow" OnClick="btnCategorySave_Click" Text="Save" />

                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnCategorySave" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <!-- End Modal -->
            </asp:Panel>





    </div>








</asp:Content>
