<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Upkeep_Gatepass_Workpermit.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">

            <h4 class="m-widget24__title">My Request </h4>
            <div class="row">
                <%--<div class="m-portlet__body  m-portlet__body--no-padding">
                    <div class="row m-row--no-padding m-row--col-separator-xl">--%>


                <div class="col-md-3 col-sm-6 col-12">
                    <div class="info-box bg-info">
                        <span class="info-box-icon"><i class="far fa-bookmark"></i></span>

                        <div class="info-box-content">
                            <span class="info-box-text">Bookmarks</span>
                            <span class="info-box-number">41,410</span>

                            <div class="progress">
                                <div class="progress-bar" style="width: 70%"></div>
                            </div>
                            <span class="progress-description">70% Increase in 30 Days
                            </span>
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </div>

                <div class="col-lg-3 col-6">
                    <!-- small card -->
                    <div class="small-box bg-info">
                        <div class="inner">
                            <h3>150</h3>

                            <p>New Orders</p>
                        </div>
                        <div class="icon">
                            <i class="fas fa-shopping-cart"></i>
                        </div>
                        <a href="#" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i>
                        </a>
                    </div>
                </div>


                <div class="col-lg-2 col-md-3 col-sm-6 col-xs-12">
                    <div class="dashboard-stat2 bordered pb-0">
                        <div class="display">
                            <div class="number">
                                <h3 class="font-green-sharp">
                                    <asp:Label ID="lblTotalCount" runat="server" Text="215"></asp:Label>
                                    <%--<span data-counter="counterup" data-value="7800">210</span>--%>
                                </h3>
                                <small>TOTAL</small>
                            </div>
                            <div class="icon">
                                <i class="flaticon-pie-chart "></i>
                            </div>
                        </div>

                    </div>
                </div>

                <div class="col-lg-2 col-md-3 col-sm-6 col-xs-12">
                    <div class="dashboard-stat2 bordered pb-0">
                        <div class="display">
                            <div class="number">
                                <h3 class="font-green-sharp">
                                    <asp:Label ID="Label1" runat="server" Text="215"></asp:Label>
                                    <img alt="" style="margin-left: 11px;" src="<%= Page.ResolveClientUrl("~/assets/demo/media/img/logo/open.png") %>" />
                                </h3>
                                <small>OPEN</small>
                            </div>
                            <%--<div class="icon">
                                        <i class="icon-pie-chart"></i>
                                    </div>--%>
                        </div>

                    </div>
                </div>
                <div class="col-lg-2 col-md-3 col-sm-6 col-xs-12">
                    <div class="dashboard-stat2 bordered pb-0">
                        <div class="display">
                            <div class="number">
                                <h3 class="font-green-sharp">
                                    <asp:Label ID="Label2" runat="server" Text="215"></asp:Label>
                                    <img alt="" style="margin-left: 11px;" src="<%= Page.ResolveClientUrl("~/assets/demo/media/img/logo/approve.png") %>" />
                                </h3>
                                <small>APPROVED</small>
                            </div>
                            <%-- <div class="icon">
                                        <i class="flaticon-like"></i>
                                    </div>--%>
                        </div>

                    </div>
                </div>

                <div class="col-lg-2 col-md-3 col-sm-6 col-xs-12">
                    <div class="dashboard-stat2 bordered pb-0">
                        <div class="display">
                            <div class="number">
                                <h3 class="font-green-sharp">
                                    <asp:Label ID="Label3" runat="server" Text="215"></asp:Label>
                                    <img alt="" style="margin-left: 11px;" src="<%= Page.ResolveClientUrl("~/assets/demo/media/img/logo/hold.png") %>" />
                                </h3>
                                <small>HOLD</small>
                            </div>
                            <%--<div class="icon">
                                        <i class="fa-hand-peace"></i>
                                    </div>--%>
                        </div>

                    </div>
                </div>

                <div class="col-lg-2 col-md-3 col-sm-6 col-xs-12">
                    <div class="dashboard-stat2 bordered pb-0">
                        <div class="display">
                            <div class="number">
                                <h3 class="font-green-sharp">
                                    <asp:Label ID="Label4" runat="server" Text="215"></asp:Label>
                                    <img alt="" style="margin-left: 11px;" src="<%= Page.ResolveClientUrl("~/assets/demo/media/img/logo/reject.png") %>" />
                                </h3>
                                <small>REJECTED</small>
                            </div>
                            <%--<div class="icon">
                                        <i class="fa-crosshairs"></i>
                                    </div>--%>
                        </div>

                    </div>
                </div>

                <div class="col-lg-2 col-md-3 col-sm-6 col-xs-12">
                    <div class="dashboard-stat2 bordered pb-0">
                        <div class="display">
                            <div class="number">
                                <h3 class="font-green-sharp">
                                    <asp:Label ID="Label5" runat="server" Text="215"></asp:Label>
                                    <img alt="" style="margin-left: 11px;" src="<%= Page.ResolveClientUrl("~/assets/demo/media/img/logo/close.png") %>" />
                                </h3>
                                <small>CLOSED</small>
                            </div>
                            <%--<div class="icon">
                                        <i class="icon-pie-chart"></i>
                                    </div>--%>
                        </div>

                    </div>
                </div>

                <%--<div class="col-md-12 col-lg-6 col-xl-2">
                            
                            <div class="m-widget24">
                                            <div class="m-widget24__item">
                                                <h4 class="m-widget24__title" style="margin-top:1.21rem;">Total Request
                                                </h4>
                                                <br/>
                                                <br/>
                                                <asp:Label ID="lblTotalCount" runat="server" Text="215"  CssClass="m-widget24__stats m--font-brand" style="margin-right: 5.8rem;"></asp:Label>
                                                                                                                                         
                                            </div>
                                        </div>
                            
                            
                        </div>
                        <div class="col-md-12 col-lg-6 col-xl-2">

                        
                            <div class="m-widget24">
                                <div class="m-widget24__item">
                                    <h4 class="m-widget24__title" style="margin-top:1.21rem;">Approved Cases
                                    </h4>
                                    <br />
                                    <br/>
                                  
                                                <asp:Label ID="lblApprovedCount" runat="server" Text="1349"  CssClass="m-widget24__stats m--font-brand" style="margin-right: 5.8rem;"></asp:Label>
                                   
                                </div>
                            </div>

                           
                        </div>
                        <div class="col-md-12 col-lg-6 col-xl-2">

                            <div class="m-widget24">
                                <div class="m-widget24__item">
                                    <h4 class="m-widget24__title" style="margin-top:1.21rem;">Hold Cases
                                    </h4>
                                    <br/><br/>
                                    
                                   <asp:Label ID="lblHoldCount" runat="server" Text="215"  CssClass="m-widget24__stats m--font-brand" style="margin-right: 5.8rem;"></asp:Label>
                                    
                                </div>
                            </div>

                           
                        </div>
                        <div class="col-md-12 col-lg-6 col-xl-2">
                          
                            <div class="m-widget24">
                                <div class="m-widget24__item">
                                    <h4 class="m-widget24__title" style="margin-top:1.21rem;">Rejected Cases
                                    </h4>
                                    <br/><br/>
                                   
                                 <asp:Label ID="lblRejectedCount" runat="server" Text="215"  CssClass="m-widget24__stats m--font-brand" style="margin-right: 5.8rem;"></asp:Label>

                                  
                                </div>
                            </div>

                           
                        </div>
                        <div class="col-md-12 col-lg-6 col-xl-2">
                           
                            <div class="m-widget24">
                                <div class="m-widget24__item">
                                    <h4 class="m-widget24__title" style="margin-top:1.21rem;">Closed Cases
                                    </h4>
                                    <br /><br/>
                                   
                                 <asp:Label ID="lblClosedCount" runat="server" Text="215"  CssClass="m-widget24__stats m--font-brand" style="margin-right: 5.8rem;"></asp:Label>
                                  
                                </div>
                            </div>

                           
                        </div>--%>
                <%-- </div>
                </div>--%>
            </div>
        </div>
        <h4 class="m-widget24__title">My Actionable </h4>
        <div class="row">
            <%--<div class="m-portlet__body  m-portlet__body--no-padding">
                    <div class="row m-row--no-padding m-row--col-separator-xl">--%>

            <div class="col-lg-2 col-md-3 col-sm-6 col-xs-12">
                <div class="dashboard-stat2 bordered pb-0">
                    <div class="display">
                        <div class="number">
                            <h3 class="font-green-sharp">
                                <asp:Label ID="Label6" runat="server" Text="215"></asp:Label>
                                <%--<img alt="" style="margin-left: 11px;" src="<%= Page.ResolveClientUrl("~/assets/demo/media/img/logo/approve.png") %>" />--%>
                                <%--<span data-counter="counterup" data-value="7800">210</span>--%>
                            </h3>
                            <small>TOTAL</small>
                        </div>
                        <div class="icon">
                            <i class="flaticon-pie-chart "></i>
                        </div>
                    </div>

                </div>
            </div>

            <div class="col-lg-2 col-md-3 col-sm-6 col-xs-12">
                <div class="dashboard-stat2 bordered pb-0">
                    <div class="display">
                        <div class="number">
                            <h3 class="font-green-sharp">
                                <asp:Label ID="Label7" runat="server" Text="215"></asp:Label>
                                <img alt="" style="margin-left: 11px;" src="<%= Page.ResolveClientUrl("~/assets/demo/media/img/logo/open.png") %>" />
                            </h3>
                            <small>OPEN</small>
                        </div>
                        <div class="icon">

                            <i class="icon-pie-chart"></i>
                        </div>
                    </div>

                </div>
            </div>
            <div class="col-lg-2 col-md-3 col-sm-6 col-xs-12">
                <div class="dashboard-stat2 bordered pb-0">
                    <div class="display">
                        <div class="number">
                            <h3 class="font-green-sharp">
                                <asp:Label ID="Label8" runat="server" Text="215"></asp:Label>
                                <img alt="" style="margin-left: 11px;" src="<%= Page.ResolveClientUrl("~/assets/demo/media/img/logo/approve.png") %>" />
                            </h3>

                            <small>APPROVED</small>
                        </div>
                        <div class="icon">
                            <%--<img alt="" src="<%= Page.ResolveClientUrl("~/assets/demo/media/img/logo/approve.png") %>" />--%>
                            <%--<i class="flaticon-like"></i>--%>
                        </div>
                    </div>

                </div>
            </div>

            <div class="col-lg-2 col-md-3 col-sm-6 col-xs-12">
                <div class="dashboard-stat2 bordered pb-0">
                    <div class="display">
                        <div class="number">
                            <h3 class="font-green-sharp">
                                <asp:Label ID="Label9" runat="server" Text="215"></asp:Label>
                                <img alt="" style="margin-left: 11px;" src="<%= Page.ResolveClientUrl("~/assets/demo/media/img/logo/hold.png") %>" />
                            </h3>
                            <small>HOLD</small>
                        </div>
                        <%--<div class="icon">
                                        <i class="fa-hand-peace"></i>
                                    </div>--%>
                    </div>

                </div>
            </div>

            <div class="col-lg-2 col-md-3 col-sm-6 col-xs-12">
                <div class="dashboard-stat2 bordered pb-0">
                    <div class="display">
                        <div class="number">
                            <h3 class="font-green-sharp">
                                <asp:Label ID="Label10" runat="server" Text="215"></asp:Label>
                                <img alt="" style="margin-left: 11px;" src="<%= Page.ResolveClientUrl("~/assets/demo/media/img/logo/reject.png") %>" />
                            </h3>
                            <small>REJECTED</small>
                        </div>
                        <%--<div class="icon">
                                        <i class="fa-crosshairs"></i>
                                    </div>--%>
                    </div>

                </div>
            </div>

            <div class="col-lg-2 col-md-3 col-sm-6 col-xs-12">
                <div class="dashboard-stat2 bordered pb-0">
                    <div class="display">
                        <div class="number">
                            <h3 class="font-green-sharp">
                                <asp:Label ID="Label11" runat="server" Text="215"></asp:Label>
                                <img alt="" style="margin-left: 11px;" src="<%= Page.ResolveClientUrl("~/assets/demo/media/img/logo/close.png") %>" />
                            </h3>
                            <small>CLOSED</small>
                        </div>
                        <div class="icon">
                            <i class="icon-pie-chart"></i>
                        </div>
                    </div>

                </div>
            </div>

            <%--<div class="col-md-12 col-lg-6 col-xl-2">
                            
                            <div class="m-widget24">
                                            <div class="m-widget24__item">
                                                <h4 class="m-widget24__title" style="margin-top:1.21rem;">Total Request
                                                </h4>
                                                <br/>
                                                <br/>
                                                <asp:Label ID="lblTotalCount" runat="server" Text="215"  CssClass="m-widget24__stats m--font-brand" style="margin-right: 5.8rem;"></asp:Label>
                                                                                                                                         
                                            </div>
                                        </div>
                            
                            
                        </div>
                        <div class="col-md-12 col-lg-6 col-xl-2">

                        
                            <div class="m-widget24">
                                <div class="m-widget24__item">
                                    <h4 class="m-widget24__title" style="margin-top:1.21rem;">Approved Cases
                                    </h4>
                                    <br />
                                    <br/>
                                  
                                                <asp:Label ID="lblApprovedCount" runat="server" Text="1349"  CssClass="m-widget24__stats m--font-brand" style="margin-right: 5.8rem;"></asp:Label>
                                   
                                </div>
                            </div>

                           
                        </div>
                        <div class="col-md-12 col-lg-6 col-xl-2">

                            <div class="m-widget24">
                                <div class="m-widget24__item">
                                    <h4 class="m-widget24__title" style="margin-top:1.21rem;">Hold Cases
                                    </h4>
                                    <br/><br/>
                                    
                                   <asp:Label ID="lblHoldCount" runat="server" Text="215"  CssClass="m-widget24__stats m--font-brand" style="margin-right: 5.8rem;"></asp:Label>
                                    
                                </div>
                            </div>

                           
                        </div>
                        <div class="col-md-12 col-lg-6 col-xl-2">
                          
                            <div class="m-widget24">
                                <div class="m-widget24__item">
                                    <h4 class="m-widget24__title" style="margin-top:1.21rem;">Rejected Cases
                                    </h4>
                                    <br/><br/>
                                   
                                 <asp:Label ID="lblRejectedCount" runat="server" Text="215"  CssClass="m-widget24__stats m--font-brand" style="margin-right: 5.8rem;"></asp:Label>

                                  
                                </div>
                            </div>

                           
                        </div>
                        <div class="col-md-12 col-lg-6 col-xl-2">
                           
                            <div class="m-widget24">
                                <div class="m-widget24__item">
                                    <h4 class="m-widget24__title" style="margin-top:1.21rem;">Closed Cases
                                    </h4>
                                    <br /><br/>
                                   
                                 <asp:Label ID="lblClosedCount" runat="server" Text="215"  CssClass="m-widget24__stats m--font-brand" style="margin-right: 5.8rem;"></asp:Label>
                                  
                                </div>
                            </div>

                           
                        </div>--%>
            <%-- </div>
                </div>--%>
        </div>

    </div>

</asp:Content>
