<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Feedback_Details.aspx.cs" Inherits="Upkeep_v3.Feedback.Feedback_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
            <div class="row">

                <div class="col-xl-12">

                    <!--begin:: Widgets/Tasks -->
                    <div class="m-portlet m-portlet--full-height ">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <h3 class="m-portlet__head-text">Feedback Summary  
                                    </h3>

                                </div>
                            </div>
                            <div class="m-portlet__head-tools">
                                <ul class="m-portlet__nav">
                                    <li class="m-portlet__nav-item m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover" aria-expanded="true">
                                        <a href="#" class="btn btn-danger m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                                            <span>
                                                <i class="fa fa-exclamation-circle" style="font-size: 2rem;"></i>
                                                <span>Raise Issue / Ticket</span>
                                            </span>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </div>


                        <div class="m-portlet__body">
                            <div class="m-widget15">
                                <asp:Repeater ID="rptFeedbackDetails" runat="server">
                                            <ItemTemplate>
                                <div class="m-widget15__items m--margin-top-20">
                                    <div class="row">
                                        <div class="col">

                                            <!--begin::widget item-->
                                            <div class="m-widget15__item">
                                                <span class="m-widget15__stats">
                                                    <label id="lbl_Postive_Points_Percent" runat="server"><%#Eval("Positive_Points_Percent")%></label>%
                                                </span>
                                                <span class="m-widget24__stats m--font-success">
                                                    <b>
                                                        <span class="m-badge m-badge--success m-badge--wide">
                                                            <i class="fa fa-check-circle "></i>
                                                            <b>Positive</b>
                                                        </span>
                                                        <label id="lbl_Postive_Points_Count" runat="server"><%#Eval("Positive_Points_Count")%></label> Responses
                                                    </b>
                                                </span>
                                                <div class="m--space-10"></div>
                                                <div class="progress m-progress--sm">
                                                    <div class="progress-bar bg-success" role="progressbar" style="width: <%#Eval("Positive_Points_Percent")%>%" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
                                                </div>
                                            </div>

                                            <!--end::widget item-->
                                        </div>
                                        <div class="col">

                                            <!--begin::widget item-->
                                            <div class="m-widget15__item">
                                                <span class="m-widget15__stats">
                                                    <label id="lbl_Negative_Points_Percent" runat="server"><%#Eval("Negative_Points_Percent")%></label>%
                                                </span>

                                                <span class="m-widget24__stats m--font-danger">
                                                    <b>
                                                        <span class="m-badge m-badge--danger m-badge--wide">
                                                            <i class="fa fa-times-circle"></i>
                                                            <b>Negative</b>
                                                        </span>
                                                        <label id="lbl_Negative_Points_Count" runat="server"><%#Eval("Negative_Points_Percent")%></label> Responses
                                                    </b>
                                                </span>
                                                <div class="m--space-10"></div>
                                                <div class="progress m-progress--sm">
                                                    <div class="progress-bar bg-danger" role="progressbar" style="width: <%#Eval("Negative_Points_Percent")%>%" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
                                                </div>
                                            </div>

                                            <!--end::widget item-->
                                        </div>
                                        <div class="col">

                                            <!--begin::widget item-->
                                            <div class="m-widget15__item">
                                               <span class="m-widget15__stats">
                                                    <label id="lbl_Neutral_Points_Percent" runat="server"><%#Eval("Neutral_Points_Percent")%></label>%
                                                </span>

                                                <span class="m-widget24__stats m--font-warning">
                                                    <b>
                                                        <span class="m-badge m-badge--warning m-badge--wide">
                                                            <i class="fa fa-times-circle"></i>
                                                            <b>Neutral</b>
                                                        </span>
                                                        <label id="lbl_Neutral_Points_Count" runat="server"><%#Eval("Neutral_Points_Count")%></label> Responses
                                                    </b>
                                                </span>
                                                <div class="m--space-10"></div>
                                                <div class="progress m-progress--sm">
                                                    <div class="progress-bar bg-warning" role="progressbar" style="width: <%#Eval("Neutral_Points_Percent")%>%" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
                                                </div>
                                            </div>

                                            <!--end::widget item-->
                                        </div>

                                    </div>

                                </div>
                               
                              </ItemTemplate> 
                            </asp:Repeater>

                            </div>
                        </div>

                    </div>
                </div>

                <div class="col-xl-6">

                    <!--begin:: Widgets/Tasks -->
                    <div class="m-portlet m-portlet--full-height ">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <h3 class="m-portlet__head-text">Feedback Given By
                                    </h3>
                                </div>
                            </div>

                        </div>

                        <div class="m-portlet__body">
                            <div class="m-widget6" id="div_Customer_Details" runat="server">
                                <div id="div_Employee" class="m-widget6__head">
                                    <div class="m-widget6__item">
                                        <span class="m-widget6__caption">Customer Name
                                        </span>
                                        <label class="m-widget6__text m--align-right m--font-boldest m--font-brand" id="lbl_Customer_Name" runat="server"></label>
                                    </div>
                                    <div class="m-widget6__item">
                                        <span class="m-widget6__caption">Customer Email
                                        </span>
                                        <label class="m-widget6__text m--align-right m--font-boldest m--font-brand" id="lbl_Customer_Email" runat="server"></label>
                                    </div>
                                    <div class="m-widget6__item">
                                        <span class="m-widget6__caption">Customer Contact
                                        </span>
                                        <label class="m-widget6__text m--align-right m--font-boldest m--font-brand" id="lbl_Customer_Contact" runat="server"></label>
                                    </div>
                                    <div class="m-widget6__item">
                                        <span class="m-widget6__caption">Customer Gender
                                        </span>
                                        <label class="m-widget6__text m--align-right m--font-boldest m--font-brand" id="lbl_Customer_Gender" runat="server"></label>
                                    </div>
                                    <div class="m-widget6__item">
                                        <span class="m-widget6__caption">Customer Photo
                                        </span>
                                        <div class="m-widget3__user-img">
                                            <img id="imp_Customer_Image" runat="server" class="m-widget3__img" style="width:auto; max-height: 70px; max-width: 100%;">
                                        </div>
                                    </div>
                                </div>

                                <div class="m-widget6__head" id="div_Retailer_Details" runat="server">
                                    <div class="m-widget6__item">
                                        <span class="m-widget6__caption">Store Name
                                        </span>
                                        <label class="m-widget6__text m--align-right m--font-boldest m--font-brand" id="lbl_Retailer_StoreName" runat="server"></label>
                                    </div>
                                    <div class="m-widget6__item">
                                        <span class="m-widget6__caption">Store No.
                                        </span>
                                        <label class="m-widget6__text m--align-right m--font-boldest m--font-brand" id="lbl_Retailer_StoreNo" runat="server"></label>
                                    </div>
                                    <div class="m-widget6__item">
                                        <span class="m-widget6__caption">Store Manager Name
                                        </span>
                                        <label class="m-widget6__text m--align-right m--font-boldest m--font-brand" id="lbl_Retailer_StoreMgrName" runat="server"></label>
                                    </div>
                                    <div class="m-widget6__item">
                                        <span class="m-widget6__caption">Store Email
                                        </span>
                                        <label class="m-widget6__text m--align-right m--font-boldest m--font-brand" id="lbl_Retailer_Email" runat="server"></label>
                                    </div>
                                    <div class="m-widget6__item">
                                        <span class="m-widget6__caption">Store Contact
                                        </span>
                                        <label class="m-widget6__text m--align-right m--font-boldest m--font-brand" id="lbl_Retailer_Contact" runat="server"></label>
                                    </div>
                                </div>


                            </div>

                        </div>
                    </div>

                    <!--end:: Widgets/Tasks -->
                </div>

                <div class="col-xl-6">

                    <!--begin:: Widgets/Support Tickets -->
                    <div class="m-portlet m-portlet--full-height ">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <h3 class="m-portlet__head-text">Feedback Collected
                                    </h3>
                                </div>
                            </div>
                            <div class="m-portlet__head-tools">
                                <ul class="m-portlet__nav">
                                    <li class="m-portlet__nav-item m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover" aria-expanded="true">
                                        <span class="m-widget6__text m--align-right m--font-boldest m--font-brand">Total Points
                                                        <label id="lbl_Feedback_Total_Points" runat="server">0</label>
                                        </span>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="m-portlet__body">
                            <div class="form-group" style="padding-left: 1%; margin-top: 4%; text-align: center;">
                                
                                <asp:Repeater ID="rptHeaderDetails" runat="server" OnItemDataBound="rptHeaderDetails_ItemDataBound">
                                    <ItemTemplate>

                                        <asp:HiddenField ID="hdnlblAnswerType" runat="server" Value='<%# Eval("Answer_Type") %>' />
                                        <%--<asp:HiddenField ID="hdnlblAnswerTypeData" runat="server" Value='<%# Eval("Ans_Type_Data_ID") %>' />--%>

                                        <div class="form-group" style="padding-left: 1%; margin-top: 4%; text-align: center;">
                                            <asp:HiddenField ID="hfHeaderId" runat="server" Value='<%# Eval("Question_ID") %>' />
                                            <label class="form-control-label font-weight-bold" id=' <%#Eval("Question_ID") %> '>&nbsp;+ &nbsp; <%#Eval("Question") %> :</label>
                                            <%--<asp:HiddenField ID="hdnIs_Mandatory" runat="server" Value='<%# Eval("Is_Mandatory") %>' />--%>
                                            <asp:Label ID="lblHeaderErr" Text="" runat="server" CssClass="col-md-8 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>

                                            <div id="divStar" style="display: none" runat="server">
                                                <section class='rating-widget'>
                                                    <input type="hidden" clientidmode="Static"  runat="server" class="hdnStar" id="hdnStar" />
                                                    <!-- Rating Stars Box -->
                                                    <div class='rating-stars text-center'>
                                                        <ul id='stars' class="ulStars">
                                                            <li class='star' title='Poor' data-value='1'>
                                                                <i class='fa fa-star fa-fw'></i>
                                                            </li>
                                                            <li class='star' title='Fair' data-value='2'>
                                                                <i class='fa fa-star fa-fw'></i>
                                                            </li>
                                                            <li class='star' title='Good' data-value='3'>
                                                                <i class='fa fa-star fa-fw'></i>
                                                            </li>
                                                            <li class='star' title='Excellent' data-value='4'>
                                                                <i class='fa fa-star fa-fw'></i>
                                                            </li>
                                                            <li class='star' title='WOW!!!' data-value='5'>
                                                                <i class='fa fa-star fa-fw'></i>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                    <div>
                                                    </div>

                                                    <div class='success-box' style="display: none;">
                                                        <div class='clearfix'></div>
                                                        <img alt='tick image' width='32' src='data:image/svg+xml;utf8;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iaXNvLTg4NTktMSI/Pgo8IS0tIEdlbmVyYXRvcjogQWRvYmUgSWxsdXN0cmF0b3IgMTkuMC4wLCBTVkcgRXhwb3J0IFBsdWctSW4gLiBTVkcgVmVyc2lvbjogNi4wMCBCdWlsZCAwKSAgLS0+CjxzdmcgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB4bWxuczp4bGluaz0iaHR0cDovL3d3dy53My5vcmcvMTk5OS94bGluayIgdmVyc2lvbj0iMS4xIiBpZD0iTGF5ZXJfMSIgeD0iMHB4IiB5PSIwcHgiIHZpZXdCb3g9IjAgMCA0MjYuNjY3IDQyNi42NjciIHN0eWxlPSJlbmFibGUtYmFja2dyb3VuZDpuZXcgMCAwIDQyNi42NjcgNDI2LjY2NzsiIHhtbDpzcGFjZT0icHJlc2VydmUiIHdpZHRoPSI1MTJweCIgaGVpZ2h0PSI1MTJweCI+CjxwYXRoIHN0eWxlPSJmaWxsOiM2QUMyNTk7IiBkPSJNMjEzLjMzMywwQzk1LjUxOCwwLDAsOTUuNTE0LDAsMjEzLjMzM3M5NS41MTgsMjEzLjMzMywyMTMuMzMzLDIxMy4zMzMgIGMxMTcuODI4LDAsMjEzLjMzMy05NS41MTQsMjEzLjMzMy0yMTMuMzMzUzMzMS4xNTcsMCwyMTMuMzMzLDB6IE0xNzQuMTk5LDMyMi45MThsLTkzLjkzNS05My45MzFsMzEuMzA5LTMxLjMwOWw2Mi42MjYsNjIuNjIyICBsMTQwLjg5NC0xNDAuODk4bDMxLjMwOSwzMS4zMDlMMTc0LjE5OSwzMjIuOTE4eiIvPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8Zz4KPC9nPgo8L3N2Zz4K' />
                                                        <div class='text-message'></div>
                                                        <div class='clearfix'></div>
                                                    </div>
                                                </section>

                                            </div>
                                            <div id="divNPS" style="display: none" runat="server">
                                                <div class="slidecontainer">
                                                    <input type="range" min="1" max="10" clientidmode="Static" runat="server" value="5" class="slider NPRSlider" id="myRange" />
                                                    <p class="NPRValue">Value: 5</p>
                                                </div>
                                            </div>
                                            <div id="divTextArea" style="display: none" runat="server">
                                                <textarea rows="4" cols="50" name="divTextAreaName" id="divTextAreaid" class="form-control" runat="server"></textarea>
                                            </div>
                                            <div id="divOptions" class="text-center" style="display: none" runat="server">
                                                <asp:RadioButtonList class="m-radio-inline" runat="server" ID="divRadioButtonrdbYes" RepeatDirection="Horizontal" ValidationGroup="Radio" ClientIDMode="Static" CellSpacing="10" CellPadding="10"></asp:RadioButtonList>
                                            </div>
                                            <div id="divOptions1" style="display: none" runat="server">
                                                <asp:CheckBoxList ID="divCheckBoxIDI" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CellPadding="1" CellSpacing="1" ClientIDMode="Static"></asp:CheckBoxList>
                                            </div>
                                            <div id="divEmoji" style="display: none" runat="server">
                                                <div class="ratingSmiley text-center">
                                                    <input type="Hidden" clientidmode="Static" runat="server" class="hdnEmoji" id="hdnEmoji" />
                                                    <span class="rating1">😶‍</span><span class="rating2">😶</span><span class="rating3">😶</span><span class="rating4">😶</span><span class="rating5">😶</span>

                                                </div>
                                            </div>
                                        </div>

                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="HeaderFooter" runat="server" Text='No Records Found' CssClass="form-control-label col-form-label"
                                            Style="display: none;"></asp:Label>
                                    </FooterTemplate>

                                </asp:Repeater>


                            </div>
                        </div>
                    </div>

                    <!--end:: Widgets/Support Tickets -->
                </div>

                <div class="col-xl-12">

                    <!--begin:: Widgets/Tasks -->
                    <div class="m-portlet m-portlet--full-height ">
                        <div class="m-portlet__head">
                            <div class="m-portlet__head-caption">
                                <div class="m-portlet__head-title">
                                    <h3 class="m-portlet__head-text">Custom Integrations  
                                    </h3>

                                </div>
                            </div>
                        </div>

                        <div class="m-portlet__body">

                            <div id="div_Integration_PAZO" runat="server" class="m-section__content">
                                <div class="m-demo" data-code-preview="true" data-code-html="true" data-code-js="false">
                                    <div class="m-demo__preview m-demo__preview--btn">
                                        <a id="btn_SubmitIssuePAZO" href="<%= Page.ResolveClientUrl("~/Custom_Integration/PAZO/Raise_Feedback_Issue.aspx") %>" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
                                            <span>
                                                <div class="m-widget3__user-img">
                                                    <img class="m-widget3__img" src="<%= Page.ResolveClientUrl("~/Custom_Integration/PAZO/Images/pazo.png") %>" alt="">
                                                </div>
                                                <span><b>Raise ISSUE in PAZO</b></span>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                            </div>


                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
