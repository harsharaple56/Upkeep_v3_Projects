<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="List_Service_Requests_Type.aspx.cs" Inherits="Upkeep_v3.CSM.List_Service_Requests_Type" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row" style="margin-top: 25px;">
        <div class="col-lg-12
            ">

            <!--begin::Portlet-->
            <div class="m-portlet m-portlet--creative m-portlet--first m-portlet--bordered-semi" style="margin-top: 0rem;">
                <div class="m-portlet__head" style="padding: 0rem 2.2rem 2.2rem 2.2rem; height: 6.75rem;">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <span class="m-portlet__head-icon m--hide">
                                <i class="flaticon-statistics"></i>
                            </span>
                            <h3 class="m-portlet__head-text" style="padding-right: 2.2rem;">Portlet sub title goes herePortlet sub title goes herePortlet sub title goes herePortlet sub title goes herePortlet sub title goes herePortlet sub title goes herePortlet sub title goes herePortlet sub title goes herePortlet sub title goes herePortlet sub title goes herePortlet sub title goes herePortlet sub title goes here
                            </h3>
                            <h2 class="m-portlet__head-label m-portlet__head-label--danger">
                                <span><label id="lbl_Service_Title" runat="server">Baggage Parking Service</label></span>
                            </h2>
                        </div>
                    </div>
                    <div class="m-portlet__head-tools">

                        <a href="#" class="btn btn-primary m-btn m-btn--icon m-btn--pill">
                            <span>
                                <i class="fa fa-archive"></i>
                                <span>Create Service Request</span>
                            </span>
                        </a>
                    </div>
                </div>
            </div>

            <!--end::Portlet-->

            <!--end::Portlet-->
        </div>
    </div>
</asp:Content>
