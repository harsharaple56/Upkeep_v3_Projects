<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Site_Mst.aspx.cs" Inherits="Upkeep_v3.General_Masters.Site_Mst" %>

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
         </style>



    <script type="text/javascript">
    
        $(document).ready(function () {

            function openModal() {
                //alert('hgfhfghfg');
                $('#Add_Site_New').modal('show');
            }

            function openModal() {
                //alert('Hii');
                $('#Add_Category').modal('show');
            }
        });
       </script>

<script type="text/javascript">

 //$(document).ready(function () {

 //     $(".customcontrolinput").click(function () {
 //         //alert('FF');
 //         //alert($(this).attr('id'));
 //         //alert($(this).prop("checked"));
 //         if ($(this).attr('id') == 'customCheck') {
 //             //alert('FF0');
 //             if ($(this).prop("checked") == false) {
 //                 // alert('FF1');
 //                 $("div#DivIsAssetCoveredInAmc").hide("slow");
 //             }
 //             else {
 //                 //alert('FF2');
 //                 $("div#DivIsAssetCoveredInAmc").show("slow");
 //             }
 //         }
 //         //else {
 //         //    if ($(this).prop("checked") == false) {
 //         //        $("div#DivIsServiceSchedule").hide("slow");
 //         //    }
 //         //    else {
 //         //        $("div#DivIsServiceSchedule").show("slow");
 //         //    }
 //         //}
      



          //function DivShowHide() {

          //    if ($("#customCheck").prop("checked") == false) {
          //        //alert('FF1');
          //        $("div#DivIsAssetCoveredInAmc").hide("slow");
          //    }
          //    else {
          //        //alert('FF2');
          //        $("div#DivIsAssetCoveredInAmc").show("slow");
          //    }

          //    //if ($("#customCheck1").prop("checked") == false) {
          //    //    $("div#DivIsServiceSchedule").hide("slow");
          //    //}
          //    //else {
          //    //    $("div#DivIsServiceSchedule").show("slow");
          //    //}
          //}

          //DivShowHide();

     

        function CheckForm() {
            if ($('#<%=txtSitecode.ClientID %>').val() == "") {
                alert('Please Enter Site Code');
                return false;
            }
            else if ($('#<%=txtSiteDesc.ClientID %>').val() == "") {
                alert('Please Enter Site Desc');
                return false;
            }
            return true;
        }
       //     });

       //});

    </script>

   <%-- <script type="text/javascript">
        $(document).ready(function () {
            //$('#btnedit').click(function () {
            $("#btnedit").click(function(){
                //alert('edit');
                $('#Add_Site_New').modal('show');
                
            });
            
      


         });

    </script>--%>

<%--     <script type="text/javascript">
            $(document).ready(function(){
                $('#m_table_1').DataTable({
                    responsive: true,
                    pagingType: 'full_numbers',
                    'fnDrawCallback': function(){
                        init_plugins();
                    }
                });



            });
        </script>--%>

    <div runat="server">
         <cc1:toolkitscriptmanager runat="server"> </cc1:toolkitscriptmanager>
        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <div class="m-content">
                <div class="m-portlet m-portlet--mobile">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Site Master		
                                </h3>
                            </div>
                        </div>
                        <div class="m-portlet__head-tools">
                            <ul class="m-portlet__nav">
                                <li class="m-portlet__nav-item">

                                     <asp:Button ID="btnSite_New" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnSite_New_Click" Text="+ New Site" />
                           

                                     <cc1:modalpopupextender ID="mpeCategoryMaster" runat="server" PopupControlID="pnlSiteMaster" TargetControlID="btnSite_New"
                              CancelControlID="btnCloseHeader" BackgroundCssClass="modalBackground"> </cc1:modalpopupextender>   
                       
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
                                    <th>Site Code</th>
                                    <th>Site Desc</th>
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

      
        <!-- End Modal -->

          <asp:Panel ID="pnlSiteMaster" runat="server" CssClass="modalPopup" align="center" Style="display: none; width: 50%;">
                <div class="" id="add_sub_location" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document" style="max-width: 590px;">
                        <div class="modal-content">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>

                                    <div class="modal-header">
                                        <h5 class="modal-title" id="exampleModalLabel">Site Master</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="btnCloseHeader" runat="server" onserverclick="btnCloseHeader_ServerClick">
                                            <span aria-hidden="true">&times;</span>
                                       <%-- <asp:Button ID="btnCloseHeader" runat="server" class="Close"/>--%>

                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        
                                       <div class="form-group m-form__group row">
                                            <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Site Code :</label>
                                           <asp:TextBox ID="txtSitecode" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                          
                                           
                                           <asp:RequiredFieldValidator ID="rfvDept" runat="server" ControlToValidate="txtSitecode" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationDept" ForeColor="Red" ErrorMessage="Please select Department"></asp:RequiredFieldValidator>

                                        </div>


                                          <div class="form-group m-form__group row">
                                            <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Site Description :</label>
                                           <asp:TextBox ID="txtSiteDesc" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                          
                                           
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSiteDesc" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationDept" ForeColor="Red" ErrorMessage="Please select Department"></asp:RequiredFieldValidator>

                                        </div>


                                          <div class="form-group m-form__group row">
                                            <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">State :</label>
                                           <asp:DropDownList ID="DDLState" class="form-control" Style="width: 60%"  OnSelectedIndexChanged="DDLState_SelectedIndexChanged"  runat="server"></asp:DropDownList>
                                          
                                           
                                        <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSiteDesc" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationDept" ForeColor="Red" ErrorMessage="Please select Department"></asp:RequiredFieldValidator>--%>

                                        </div>


                                          <div class="form-group m-form__group row">
                                            <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">City :</label>
                                          <asp:DropDownList ID="ddlCity" class="form-control" Style="width: 60%"  OnSelectedIndexChanged="ddlCity_SelectedIndexChanged"  runat="server"></asp:DropDownList>
                                          
                                          <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSiteDesc" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationDept" ForeColor="Red" ErrorMessage="Please select Department"></asp:RequiredFieldValidator>--%>

                                        </div>


                                        
                                       
                                            
                                    <br />
                                     <div class="form-group m-form__group row">
                                            <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">Address :</label>
                                           <asp:TextBox ID="txtAddress" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                          
                                           
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAddress" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationDept" ForeColor="Red" ErrorMessage="Please select Department"></asp:RequiredFieldValidator>

                                        </div>


                                          <div class="form-group m-form__group row">

                                              <asp:CheckBox ID="chkcocktail" runat="server" class="customcontrolinput col-xl-4 col-lg-3" style="padding-right: 13px;left: -10;left: 70px;top: 3px;" />

                                        
                                          <%--   <input type="checkbox" id="txtCockail" runat="server" class="customcontrolinput col-xl-4 col-lg-3" style="padding-right: 13px;left: -10;left: 70px;top: 3px;" name="example1" clientidmode="Static" />
                                           --%>   
                                              
                                              <label for="message-text" class="form-control-label">Add this Site as License Under Cocktail World</label>
                                           
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSiteDesc" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationDept" ForeColor="Red" ErrorMessage="Please select Department"></asp:RequiredFieldValidator>

                                        </div>


                                          <div class="form-group m-form__group row">
                                            <label for="message-text" class="col-xl-4 col-lg-3 form-control-label">License Number :</label>
                                             <asp:TextBox ID="TxtLicenseNumber" runat="server" class="form-control" Style="width: 60%;"></asp:TextBox>
                                          
                                           
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtSiteDesc" Visible="true" Style="margin-left: 34%;" ValidationGroup="validationDept" ForeColor="Red" ErrorMessage="Please select Department"></asp:RequiredFieldValidator>

                                        </div>


                                                
                                      
                                   

                                 








                                        <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                              
                                    <%--<div class="form-group m-form__group row">
                                        <div class="col-xl-9 col-lg-9">
                                            <asp:Label ID="Label1" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>--%>

                                    <div class="modal-footer">
                                        <asp:Button ID="btnClose" Text="Close" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnClose_Click" />
                                        <asp:Button ID="btnSiteMst" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" CausesValidation="true" ValidationGroup="validationWorkflow" OnClick="btnSiteMst_Click" Text="Save" />

                                        


                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnSiteMst" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <!-- End Modal -->
            </asp:Panel>





    </div>





</asp:Content>
