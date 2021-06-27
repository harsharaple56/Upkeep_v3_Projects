<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Select_Transactions.aspx.cs" Inherits="Upkeep_v3.Laundry_Management.Transactions.Transactions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="m-content">
    <div class="row">

        <div class="col-xl-6">

            <div class="m-portlet">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <span class="m-portlet__head-icon">
                                <i class="fa fa-users" style="font-size: 3.4rem;"></i>
                            </span>
                            <h3 class="m-portlet__head-text">Department Transaction
                            </h3>
                        </div>
                    </div>
                </div>
                <div class="m-portlet__body" style="text-align: center;">
                    Manage all your Transactions with different Laundry Vendors
                    </br>
                    To Add a Laundry Transaction with a Department Executive , click below
                    
                    

                    <img src="<%= Page.ResolveClientUrl("~/assets/app/media/img/LMS_Icons/laundry_department_50.png") %>"  alt="" style="padding-top: 30px;">

                    


                </div>
                <div class="m-portlet__foot">
                    <div class="row align-items-center">
                        <div class="col-lg-12 m--align-center">
                            
                            <a href="<%= Page.ResolveClientUrl("~/Laundry_Management/Transactions/Department_Transactions.aspx") %>" class="btn btn-brand">
                                Click here to Add <b>Department</b> transaction
                            </a>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <div class="col-xl-6">

            <div class="m-portlet">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <span class="m-portlet__head-icon">
                                <i class="fa fa-shopping-basket" style="font-size: 3.4rem;"></i>
                            </span>
                            <h3 class="m-portlet__head-text">Vendor Transaction
                            </h3>
                        </div>
                    </div>
                </div>
                <div class="m-portlet__body" style="text-align: center;">
                    Manage all your Transactions with different Laundry Vendors
                    </br>
                    To Add a Laundry Transaction with a Vendor , click below
                    
                    

                    <img src="/assets/app/media/img/LMS_Icons/laundry_vendor_50.png"  alt="" style="padding-top: 30px;">


                </div>
                <div class="m-portlet__foot">
                    <div class="row align-items-center">
                        <div class="col-lg-12 m--align-center">
                            <a href="<%= Page.ResolveClientUrl("~/Laundry_Management/Transactions/Vendor_Transactions.aspx") %>" class="btn btn-brand">
                                Click here to Add <b>Vendor</b> transaction

                            </a>
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </div>

            </div>
            </div>

</asp:Content>
