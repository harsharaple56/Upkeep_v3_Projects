<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Useful Snippets.aspx.cs" Inherits="Upkeep_v3.Developer_Code_Snippets.Useful_Snippets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--    Grid for REPORTS
    file:///D:/GitHub/GitHub_Repositories/Upkeep_v3_Projects/UI_Template1/UI_Template1/crud/datatables/search-options/advanced-search.html--%>



    <%--Tooltip Code for Information--%>

    <a href="#" style="width: 25px; height: 25px;" class="btn btn-outline-info m-btn m-btn--icon m-btn--icon-only" data-container="body" data-toggle="m-tooltip" data-placement="left" title="" data-original-title="Tooltip Data">
        <i class="fa fa-info-circle"></i>
    </a>

    <%-- Code to Section a Form --%>

    <div class="m-form__heading" style="text-align: center; padding-top: 10px; padding-bottom: 10px;">
        <h3 class="m-form__heading-title" style="line-height: 2.0; background: aliceblue; font-size: 1.2rem;">Asset Details</h3>
    </div>

    <%--For Creating Forms--%>

    <div class="m--form-group row">
        <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold"><span class="fa fa-phone" aria-hidden="true"></span>Mobile No</label>
        <div class="col-xl-4 col-lg-3 col-form-label">
            <span id="ContentPlaceHolder1_lblMobileNo" class="form-control-label">8652050860</span>
        </div>

        <label class="col-xl-2 col-lg-2 col-form-label font-weight-bold"><span class="fa fa-envelope" aria-hidden="true"></span>Email ID</label>
        <div class="col-xl-4 col-lg-3 col-form-label">
            <span id="ContentPlaceHolder1_LblEmailID" class="form-control-label">sales@efacilito.com</span>
        </div>

    </div>

   <%-- Error Text--%>

    <span class="error_type text-danger font-weight-bold">Answer Type error text</span>

    <%--For Checkbox--%>

    <label class="m-checkbox m-checkbox--solid m-checkbox--brand" style="margin-top: 10px;">
        <input type="checkbox">
        Enable and configure automated ticketing on Negative Feedbacks
											        <span></span>
    </label>

    <%--Pill style Button--%>

    <a href="#" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
        <span>
            <i class="fa fa-archive"></i>
            <span>Primary</span>
        </span>
    </a>
    <a id="btnAddcategory" runat="server" onserverclick="btnAddcategory_Click1" class="btn btn-success m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air">
        <span>
            <i class="flaticon-add"></i>
            <span>Add New Category</span>
        </span>
    </a>

    <%--Pill style BACK Button--%>


    <a href="<%= Page.ResolveClientUrl("~/VMS/VMSConfig_Listing.aspx") %>" class="btn btn-metal m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m--margin-right-10">
        <span>
            <i class="la la-arrow-left"></i>
            <span>Back</span>
        </span>
    </a>


    <%--Modals Popups--%>

    <asp:Panel ID="pnl_NoWorkPermits" runat="server" CssClass="modalPopup" align="center">
        <div class="" id="add_sub_location3" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="modal-header">
                                <h5 class="modal-title m--align-center" id="exampleModalLabel3">No Work Permits Forms Available !</h5>
                            </div>
                            <div class="modal-body">
                                <div class="form-group m-form__group row">
                                    <label for="recipient-name" class="col-xl-12 col-lg-3 form-control-label">It looks Like no Work Permit Forms have been configured in your Company for <span id="lbl_Retailer_NoForm" runat="server"></span><span id="lbl_Employee_NoForm" runat="server"></span></label>

                                    <label class="col-xl-12 col-lg-3 form-control-label font-weight-bold">Please contact your Property Administrator to get New Work Permit Forms Configured</label>


                                </div>
                            </div>
                            <div class="modal-footer">
                                <a href="<%= Page.ResolveClientUrl("~/WorkPermit/MyWorkPermit.aspx") %>" class="btn btn-primary m-btn m-btn--custom m-btn--icon m-btn--pill m-btn--air m--margin-right-10">
                                    <span>
                                        <i class="la la-arrow-left"></i>
                                        <span>Back</span>
                                    </span>
                                </a>

                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnTest" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </asp:Panel>

</asp:Content>
