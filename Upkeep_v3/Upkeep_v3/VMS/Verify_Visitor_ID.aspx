<%@ Page Title="" Language="C#" MasterPageFile="~/BlankMaster.Master" AutoEventWireup="true" CodeBehind="Verify_Visitor_ID.aspx.cs" Inherits="Upkeep_v3.VMS.Verify_Visitor_ID" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
        <div class="col-md-12">
            <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">

                <div class="m--align-center" style="padding: 15px;">
                    <asp:image id="Img_CompanyLogo" src="../assets/app/media/img/logos/verify_certificate.png" runat="server" style="width: auto; max-height: 150px; max-width: 100%;" />

                </div>
                <div class="m--align-center" style="padding: 15px;">
                    <h2 class="m--font-primary" style="padding-bottom: inherit;">Verify Visitor ID</h2>

                    <a href="#" class="btn btn-outline-primary m-btn m-btn--icon m-btn--outline-2x m-btn--pill m-btn--air">
                        <span>
                            <i style="font-size: 2.3rem;" class="la la-qrcode"></i>
                            <span>Scan QR Code on Visitor ID</span>
                        </span>
                    </a>
                </div>
                <div class="m--align-center" style="padding: 15px;">
                    <h5 class="m--space-10" style="padding-bottom: 5rem;">The eFacilito Visitor ID has a digitally signed QR code. This can be authenticated online using the verification utility in this portal</h5>

                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">
                <div class="m-portlet__body">
                    <div class="m-stack m-stack--ver m-stack--tablet m-stack--demo m--align-center">

                        <div class="m-stack__item m-stack__item--center m-stack__item--top">

                            <img src="../assets/app/media/img/logos/verified.jpg" style="height: 130px;" />

                        </div>

                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                            <h3 class="m--font-success" style="padding-bottom: inherit;">Visitor ID Verified Successfully</h3>

                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">

                            <asp:image id="Image2" src="../assets/app/media/img/logos/Palladium.PNG" runat="server" style="width: auto; max-height: 70px; max-width: 100%;" />

                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">

                            <asp:image id="Img_Visitor_Photo" src="../../assets/app/media/img/users/user4.jpg" runat="server" style="width: auto; max-height: 70px; max-width: 100%;" />

                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                            <span class="font-weight-bold">Name : </span>
                            <label id="lbl_Visitor_Name" runat="server">Lokesh Devasani</label>


                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                            <span class="font-weight-bold">Email : </span>
                            <label id="lbl_Visitor_Email" runat="server">ldevasani08@gmail.com</label>


                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                            <span class="font-weight-bold">Contact : </span>
                            <label id="lbl_Visitor_Contact" runat="server">8898084488</label>


                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">

                            <span class="font-weight-bold">Visit Request ID : </span>
                            <label id="lbl_VisitRequest_ID" runat="server">45</label>


                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle" style="background: yellow;">

                            <div class="font-weight-bold">Vaccination Details</div>

                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                            <div class="font-weight-bold">
                                Vaccination Status : <span class="m-badge m-badge--success m-badge--wide m-badge--rounded">VACCINATED</span>
                            </div>
                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                            <span class="font-weight-bold">Date of Vaccination : </span>
                            <label id="lbl_Vacc_Date" runat="server">3rd Sep 2021</label>


                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                            <div class="col-form-label">Visit Request Created on
                                <label id="lbl_Request_Date_Text" runat="server">4th Sep 2021</label></div>


                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                            <div class="col-form-label">
                                <label id="lbl_Visit_Date_Text" runat="server">
                                </label>

                            </div>
                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--bottom">
                            <a href="#" class="btn btn-outline-primary m-btn m-btn--icon m-btn--outline-2x m-btn--pill m-btn--air">
                                <span>
                                    <i style="font-size: 2.3rem;" class="fa fa-angle-double-left"></i>
                                    <span>Go Back</span>
                                </span>
                            </a>
                        </div>


                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="row">
        <div class="col-md-12">
            <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">
                <div class="m-portlet__body">
                    <div class="m-stack m-stack--ver m-stack--tablet m-stack--demo m--align-center">

                        <div class="m-stack__item m-stack__item--center m-stack__item--top">

                            <img src="../assets/app/media/img/Dashboard_Icons/pending.png" style="height: 130px;" />

                        </div>

                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                            <h3 class="m--font-danger" style="padding-bottom: inherit;">Invalid Visitor ID</h3>

                        </div>
                        <div class="m-stack__item m-stack__item--center m-stack__item--middle">
                            <a href="#" class="btn btn-outline-primary m-btn m-btn--icon m-btn--outline-2x m-btn--pill m-btn--air">
                                <span>
                                    <i style="font-size: 2.3rem;" class="fa fa-angle-double-left"></i>
                                    <span>Go Back</span>
                                </span>
                            </a>
                        </div>


                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
