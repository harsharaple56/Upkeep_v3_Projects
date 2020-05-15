<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Checklist.aspx.cs" Inherits="Upkeep_v3.Checklist.Checklist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="<%= Page.ResolveClientUrl("~/vendors/jquery/dist/jquery.js") %>" type="text/javascript" ></script>
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

    <script type="text/javascript">
       
        function DeleteChecklist(ChecklistID) {
            $("#hdnChecklstID").val(ChecklistID)
            
            if (confirm('Are you sure you want to delete this Checklist?')) {
                // Save it!
                document.getElementById('<%= btnDeleteChecklist.ClientID %>').click();
            } else {
                // Do nothing!
            }
        }
    </script>

     <form method="post" runat="server" id="frmMain">

         <asp:HiddenField runat="server" ID="hdnChecklstID" ClientIDMode="Static" />
         <asp:Button ID="btnDeleteChecklist" runat="server" OnClick="btnDeleteChecklist_Click" Style="display: none" />

        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <div class="m-content">
                <div class="m-portlet m-portlet--mobile">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Checklist		
                                </h3>
                            </div>
                        </div>
                        <div class="m-portlet__head-tools">
                            <%--<ul class="m-portlet__nav">
                                <li class="m-portlet__nav-item">
                                    <a href="~/General_Masters/Add_Department.aspx" class="btn btn-info m-btn m-btn--custom m-btn--icon m-btn--air" data-toggle="modal">
                                        <span>
                                            <i class="la la-plus"></i>
                                            <span>New Department</span>
                                        </span>
                                    </a>


                                </li>
                            </ul>--%>
                           
                            <asp:Button ID="btnAddChecklist" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnAddChecklist_Click" Text="+ New Checklist" />
                               
                        </div>
                    </div>
                    <div class="m-portlet__body">

                        <!--begin: Datatable -->
                        <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">


                            <thead>

                                <tr>
                                    <th>Checklist Name</th>
                                    <th>Department</th>
                                    <th>Zone</th>
                                    <th>Location</th>
                                    <th>Created On</th>
                                    <th>Action</th>
                                </tr>

                            </thead>
                            
                            <tbody>
                                <%=bindgrid()%>
                            </tbody>
                        </table>

                        <asp:Label ID="lblChecklstErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                    </div>

                  
                </div>

                <!-- END EXAMPLE TABLE PORTLET-->
            </div>
        </div>

        
    </form>



</asp:Content>
