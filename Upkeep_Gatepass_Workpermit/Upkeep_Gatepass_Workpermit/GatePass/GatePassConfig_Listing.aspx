<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="GatePassConfig_Listing.aspx.cs" Inherits="Upkeep_Gatepass_Workpermit.GatePass.GatePassConfig_Listing" %>
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

    <%--<form method="post" runat="server" id="frmMain">--%>
    <div class="m-grid__item m-grid__item--fluid m-wrapper">
					<div class="m-content">
						<div class="m-portlet m-portlet--mobile">
							<div class="m-portlet__head">
								<div class="m-portlet__head-caption">
									<div class="m-portlet__head-title">
										<h3 class="m-portlet__head-text">
											Gate Pass Configuration Listing		
										</h3>
									</div>
								</div>
								<div class="m-portlet__head-tools">
									<ul class="m-portlet__nav">
										<li class="m-portlet__nav-item">
											<a href="<%= Page.ResolveClientUrl("GatePass_Configuration.aspx") %>" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md">
												<span>
													<i class="la la-plus"></i>
													<span>New Configuration</span>
												</span>
											</a>
										</li>
									</ul>
								</div>
							</div>

                            <div>
                                        <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" ></asp:Label>

                            </div>


							<div class="m-portlet__body">

								<!--begin: Datatable -->
								<table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">
									<thead>
										<tr>
											<th>GatePass Title</th>
                                            <th>Company</th>
                                            <th>Initiator</th>
											<th>Created on</th>
											<th>Action</th>
										</tr>
									</thead>
									
                                     <tbody>
                                         <%=fetchGPConfigListing()%>  

                                    </tbody>
								</table>
							</div>
						</div>

						<!-- END EXAMPLE TABLE PORTLET-->
					</div>
				</div>
        <%--</form>--%>


</asp:Content>
