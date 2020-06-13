<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="EventQuestions.aspx.cs" Inherits="Upkeep_v3.Feedback.EventQuestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     
        <div class="m-grid__item m-grid__item--fluid m-wrapper">
            <div class="m-content">
                <div class="m-portlet m-portlet--mobile">
                    <div class="m-portlet__head">
                        <div class="m-portlet__head-caption">
                            <div class="m-portlet__head-title">
                                <h3 class="m-portlet__head-text">Questions - Events name	<%--<asp:Label ID="lblEventName1" runat="server"></asp:Label>	--%>
                                </h3>
                                <%--<asp:Label ID="lblEventName" runat="server"></asp:Label>--%>
                            </div>
                        </div>
                        <div class="m-portlet__head-tools">
                            <a href="<%= Page.ResolveClientUrl("EventListing.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                <span>
                                    <i class="la la-arrow-left"></i>
                                    <span>Back</span>
                                </span>
                            </a>
                            <div class="btn-group">
                                <a href="AddEventQuestion.aspx" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md">
                                <span>
                                    <i class="la la-plus"></i>
                                    <span>New Question</span>
                                    <%--<asp:Button ID="btnAddNewQuestion" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" Text="New Question" />--%>
                                </span>
                                    </a>
                            </div>
                            <%--<ul class="m-portlet__nav">
										<li class="m-portlet__nav-item">
											<a href="AddEventQuestion.aspx" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md">
												<span>
													<i class="la la-plus"></i>
													<span>New Question</span>
												</span>
											</a>
										</li>
                                        <li class="m-portlet__nav-item">
											<a href="EventListing.aspx" class="btn btn-info m-btn m-btn--custom m-btn--icon m-btn--air">
												<span>
													<i class="la "></i>
													<span>Back</span>
												</span>
											</a>
										</li>
									</ul>--%>
                        </div>
                    </div>
                    <div class="m-portlet__body">

                        <!--begin: Datatable -->
                        <table class="table table-striped- table-bordered table-hover table-checkable" id="m_table_1">
                            <thead>
                                <tr>
                                    <th>Q No</th>
                                    <th>Question</th>
                                    <th>Answer Type</th>
                                    <th>Created on</th>
                                    <th>Action</th>
                                </tr>
                            </thead>

                            <tbody>
                                <%=fetchEventQuestions()%>
                            </tbody>

                        </table>
                    </div>
                </div>
                <!-- END EXAMPLE TABLE PORTLET-->
            </div>
        </div>
    
</asp:Content>
