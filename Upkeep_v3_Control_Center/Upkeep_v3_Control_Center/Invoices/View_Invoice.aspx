<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="View_Invoice.aspx.cs" Inherits="Upkeep_v3_Control_Center.Invoices.View_Invoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        element.style {
        }

        .m-invoice-2 .m-invoice__wrapper .m-invoice__head .m-invoice__container .m-invoice__desc > span {
            display: block;
        }

        *, *::before, *::after {
            -webkit-box-sizing: border-box;
            box-sizing: border-box;
        }

        .m-invoice-2 .m-invoice__wrapper .m-invoice__head .m-invoice__container .m-invoice__desc {
            text-align: center;
            display: block;
            padding: 1rem 0 4rem 0;
        }




        .m-invoice-2 .m-invoice__wrapper .m-invoice__footer {
            margin-top: 0rem;
            padding: 0rem 0 3rem 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="m-grid__item m-grid__item--fluid m-wrapper">

        <!-- BEGIN: Subheader -->
        <div class="m-subheader ">
            <div class="d-flex align-items-center">
                <div class="mr-auto">
                    <h3 class="m-subheader__title m-subheader__title--separator">Invoice v2</h3>
                    <ul class="m-subheader__breadcrumbs m-nav m-nav--inline">
                        <li class="m-nav__item m-nav__item--home">
                            <a href="#" class="m-nav__link m-nav__link--icon">
                                <i class="m-nav__link-icon la la-home"></i>
                            </a>
                        </li>
                        <li class="m-nav__separator">-</li>
                        <li class="m-nav__item">
                            <a href="" class="m-nav__link">
                                <span class="m-nav__link-text">Invoices</span>
                            </a>
                        </li>
                        <li class="m-nav__separator">-</li>
                        <li class="m-nav__item">
                            <a href="" class="m-nav__link">
                                <span class="m-nav__link-text">Invoice v2</span>
                            </a>
                        </li>
                    </ul>
                </div>
                <div>
                    <div class="m-dropdown m-dropdown--inline m-dropdown--arrow m-dropdown--align-right m-dropdown--align-push" m-dropdown-toggle="hover" aria-expanded="true">
                        <a href="#" class="m-portlet__nav-link btn btn-lg btn-secondary  m-btn m-btn--outline-2x m-btn--air m-btn--icon m-btn--icon-only m-btn--pill  m-dropdown__toggle">
                            <i class="la la-plus m--hide"></i>
                            <i class="la la-ellipsis-h"></i>
                        </a>
                        <div class="m-dropdown__wrapper">
                            <span class="m-dropdown__arrow m-dropdown__arrow--right m-dropdown__arrow--adjust"></span>
                            <div class="m-dropdown__inner">
                                <div class="m-dropdown__body">
                                    <div class="m-dropdown__content">
                                        <ul class="m-nav">
                                            <li class="m-nav__section m-nav__section--first m--hide">
                                                <span class="m-nav__section-text">Quick Actions</span>
                                            </li>
                                            <li class="m-nav__item">
                                                <a href="" class="m-nav__link">
                                                    <i class="m-nav__link-icon flaticon-share"></i>
                                                    <span class="m-nav__link-text">Activity</span>
                                                </a>
                                            </li>
                                            <li class="m-nav__item">
                                                <a href="" class="m-nav__link">
                                                    <i class="m-nav__link-icon flaticon-chat-1"></i>
                                                    <span class="m-nav__link-text">Messages</span>
                                                </a>
                                            </li>
                                            <li class="m-nav__item">
                                                <a href="" class="m-nav__link">
                                                    <i class="m-nav__link-icon flaticon-info"></i>
                                                    <span class="m-nav__link-text">FAQ</span>
                                                </a>
                                            </li>
                                            <li class="m-nav__item">
                                                <a href="" class="m-nav__link">
                                                    <i class="m-nav__link-icon flaticon-lifebuoy"></i>
                                                    <span class="m-nav__link-text">Support</span>
                                                </a>
                                            </li>
                                            <li class="m-nav__separator m-nav__separator--fit"></li>
                                            <li class="m-nav__item">
                                                <a href="#" class="btn btn-outline-danger m-btn m-btn--pill m-btn--wide btn-sm">Submit</a>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- END: Subheader -->
        <div class="m-content">
            <div class="row">
                <div class="col-lg-12">
                    <div class="m-portlet">
                        <div class="m-portlet__body m-portlet__body--no-padding">
                            <div class="m-invoice-2">
                                <div class="m-invoice__wrapper">
                                    <div class="m-invoice__head" style="background-image: url(../../assets/app/media/img//logos/bg-6.jpg);">

                                        <div class="m-invoice__container m-invoice__container--centered">
                                            <div class="m-invoice__logo">
                                                <a href="#">
                                                    <img src="../../assets/app/media/img//logos/Invoice_Header_CC_Address.png">
                                                </a>
                                                <a href="#">
                                                    <img src="../../assets/app/media/img//logos/Invoice_Header_CC.png">
                                                </a>
                                            </div>

                                            <div class="m-invoice__items">
                                                <div class="m-invoice__item">
                                                    <span class="m-invoice__subtitle">Invoice Date</span>
                                                    <span class="m-invoice__text">Dec 12, 2017</span>
                                                    
                                                    </br>
                                                    <span class="m-invoice__subtitle">Invoice No.</span>
                                                    <span class="m-invoice__text">CC-INV-3456</span>

                                                    </br>
                                                   
                                                    
                                                </div>
                                                <div class="m-invoice__item">
                                                     <span class="m-invoice__subtitle">PO Number.</span>
                                                    <span class="m-invoice__text">CC-INV-3456</span>
                                                    </br>
                                                    <span class="m-invoice__subtitle">Due Date</span>
                                                    <span class="m-invoice__text">Dec 12, 2017</span>
                                                </div>
                                                <div class="m-invoice__item">
                                                    <span class="m-invoice__subtitle">Invoice To.</span>
                                                    <span class="m-invoice__text">
                                                        <b>Eureka Forbes Pvt. Ltd.</b>
                                                        <br>
                                                        B1/B2, 701, 7th Floor, Marathon Innova,
                                                        Off Ganpatrao Kadam Marg,Lower Parel,
                                                        Mumbai 400013, 
                                                            </br>
                                                        Maharashtra,
                                                        India,
                                                                            <br>
                                                        GSTIN 27AAACE5767F2ZJ
                                                                                <br>

                                                    </span>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="m-invoice__body m-invoice__body--centered">
                                        <div class="table-responsive">
                                            <table class="table">
                                                <thead>
                                                    <tr>
                                                        <th>DESCRIPTION</th>
                                                        <th>QUANTITY</th>
                                                        <th>RATE</th>
                                                        <th>CGST</th>
                                                        <th>SGST</th>
                                                        <th>Amount</th>


                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td>Creative Design</td>
                                                        <td>80</td>
                                                        <td>₹40.00</td>
                                                        <td>₹7.00</td>
                                                        <td>₹7.00</td>
                                                        <td class="m--font-danger">₹3200.00</td>

                                                    </tr>
                                                    <tr>
                                                        <td>Front-End Development</td>
                                                        <td>120</td>
                                                        <td>₹40.00</td>
                                                        <td>₹7.00</td>
                                                        <td>₹7.00</td>
                                                        <td class="m--font-danger">₹3200.00</td>

                                                    </tr>
                                                    <tr>
                                                        <td>Back-End Development</td>
                                                        <td>210</td>
                                                        <td>₹40.00</td>
                                                        <td>₹7.00</td>
                                                        <td>₹7.00</td>
                                                        <td class="m--font-danger">₹3200.00</td>


                                                    </tr>

                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="m-invoice__footer" style="margin-top: 0rem; padding: 0rem 0 0rem 0;">
                                        <div class="m-invoice__table  m-invoice__table--centered table-responsive" >
                                            <table class="table">
                                                <thead>
                                                    <tr>
                                                        <th>SUB TOTAL</th>
                                                        <th class="m--font-danger" >20,600.00</th>
                                                    </tr>
                                                    <tr>
                                                        <th>CGST (9%)</th>
                                                        <th class="m--font-danger" >20,600.00</th>
                                                    </tr>
                                                    <tr>
                                                        <th>SGST (9%)</th>
                                                        <th class="m--font-danger" >20,600.00</th>

                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td>TOTAL AMOUNT</td>
                                                        <td class="m--font-danger">20,600.00</td>
                                                    </tr>
                                                </tbody>
                                            </table>

                                        </div>
                                    </div>

                                    <div class="m-invoice__footer" style="margin-top: 0rem; padding: 3rem 0 5rem 0">
                                        <div class="m-invoice__table  m-invoice__table--centered table-responsive">
                                            <table class="table">
                                                <thead>
                                                    <tr>
                                                        <th>Bank</th>
                                                        <th>Acc.No.</th>
                                                        <th>IFSC Code</th>
                                                        <th>Pay</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td>HDFC Bank ( Sector 17-Vashi )</td>
                                                        <td>50200021877651</td>
                                                        <td>HDFC40540</td>
                                                        <td>
                                                                    <a href="https://rzp.io/l/wSqHipO" target="_blank" class="btn btn-accent m-btn m-btn--custom m-btn--icon m-btn--air m-btn--pill">
                                                                        <span>
                                                                            <i class="fa fa-rupee-sign" aria-hidden="true"></i>
                                                                            <span>Pay Online</span>
                                                                        </span>
                                                                    </a>

                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>

                                        
                                        <div class="m-invoice__table  m-invoice__table--centered table-responsive" style="margin-top: 0rem; padding: 3rem 0 0rem 0;">
                                            <table class="table">
                                                <thead>
                                                    <tr>
                                                        <th>Digitally Signed by </th>
                                                        <th>
                                                            Digital Sign
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td>Narsingh Devasani
                                                            <div class="m-invoice__logo">
                                                <a href="#">
                                                    <img src="../../assets/app/media/img//logos/Sign.png">
                                                </a>
                                            </div>



                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>

                                        <div class="m-invoice__head" style="background-image: url(../../assets/app/media/img//logos/bg-6.jpg);">

                                        <div class="m-invoice__container m-invoice__container--centered">
                                            <span class="m-invoice__desc" style="text-align: center;padding: 3rem 0 0rem 0;">
                                                <span>Thanks for providing us with the Opportunity. We will ensure best services are delivered against this value</span>
                                            </span>
                                        </div>
                                        </div>



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
