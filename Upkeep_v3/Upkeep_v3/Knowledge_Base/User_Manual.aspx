﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="User_Manual.aspx.cs" Inherits="Upkeep_v3.Knowledge_Base.User_Manual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<iframe src="https://docs.google.com/document/d/1bmq22dHHmRDiJtqrJL3j45lCDdJfroCFpaBQWLHnEWc/"
        style="width: 100%; height: 500px">
            <p>Your browser does not support iframes.</p>
    </iframe>
    <br/>
    <br/>
     <div>
        <h4>TIP : <b>Press Ctrl + F</b> to search anything within the User Manual </h4>
    </div>--%>

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="">

            <!--begin::Portlet-->
            <div class="m-portlet m-portlet--space">
                <div class="m-portlet__head">
                    <div class="m-portlet__head-caption">
                        <div class="m-portlet__head-title">
                            <h3 class="m-portlet__head-text">FAQ Example
                            </h3>
                        </div>
                    </div>
                    <div class="m-portlet__head-tools">
                        <ul class="m-portlet__nav">
                            <li class="m-portlet__nav-item">
                                <a href="#" class="m-portlet__nav-link m-btn--pill">
                                    <div class="m-input-icon m-input-icon--right">
                                        <input type="text" class="form-control form-control-lg m-input m-input--solid m-input--pill" placeholder="Search FAQ...">
                                        <span class="m-input-icon__icon m-input-icon__icon--right"><span><i class="la la-search m--font-brand"></i></span></span>
                                    </div>
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>

                <div class="m-portlet__body">
                    <div class="row">
                        <div class="col-xl-3">
                            <div class="m-tabs" data-tabs="true" data-tabs-contents="#m_sections">
                                <ul class="m-nav m-nav--active-bg m-nav--active-bg-padding-lg m-nav--font-lg m-nav--font-bold m--margin-bottom-20 m--margin-top-10 m--margin-right-40" id="m_nav" role="tablist">
                                    <li class="m-nav__item">
                                        <a class="m-nav__link m-tabs__item m-tabs__item--active" data-tab-target="#m_section_1" href="#">
                                            <span class="m-nav__link-text">Ticketing</span>
                                        </a>
                                    </li>

                                    <li class="m-nav__item">
                                        <a class="m-nav__link m-tabs__item m-tabs__item" data-tab-target="#m_section_2" href="#">
                                            <span class="m-nav__link-text">Checklist</span>
                                        </a>
                                    </li>

                                    <li class="m-nav__item">
                                         <a class="m-nav__link m-tabs__item m-tabs__item" data-tab-target="#m_section_3" href="#">
                                   
                                                    <span class="m-nav__link-text">WorkPermit</span>
                                        </a>
                                    </li>

                                    <li class="m-nav__item">
                                        <a class="m-nav__link m-tabs__item m-tabs__item" data-tab-target="#m_section_4" href="#">
                                            <span class="m-nav__link-text">GatePass</span>
                                        </a>
                                    </li>

                                    <li class="m-nav__item">
                                        <a class="m-nav__link m-tabs__item m-tabs__item" data-tab-target="#m_section_5" href="#">
                                                    <span class="m-nav__link-text">Feedback</span>
                                        </a>
                                    </li>

                                       
                                    <li class="m-nav__item">
                                        <a class="m-nav__link m-tabs__item m-tabs__item" data-tab-target="#m_section_6" href="#">
                                            <span class="m-nav__link-text">Asset Manager</span>
                                        </a>
                                    </li>

                                    <li class="m-nav__item">
                                        <a class="m-nav__link m-tabs__item m-tabs__item" data-tab-target="#m_section_7" href="#">
                                            <span class="m-nav__link-text">VMS</span>
                                        </a>
                                    </li>

                                    <li class="m-nav__item">
                                        <a class="m-nav__link m-tabs__item m-tabs__item" data-tab-target="#m_section_8" href="#">
                                            <span class="m-nav__link-text">General Setup</span>
                                        </a>
                                    </li>

                                    <li class="m-nav__item">
                                         <a class="m-nav__link m-tabs__item m-tabs__item" data-tab-target="#m_section_9" href="#">
                                            <span class="m-nav__link-text">Rights Management</span>
                                        </a>
                                    </li>

                                    <li class="m-nav__item">
                                         <a class="m-nav__link m-tabs__item m-tabs__item" data-tab-target="#m_section_10" href="#">
                                            <span class="m-nav__link-text">Inventory</span>
                                        </a>
                                    </li>

                                </ul>
                            </div>
                        </div>
                        <div class="col-xl-9">
                            <div class="m-tabs-content" id="m_sections">

                                <!--begin::Section 1-->
                                <div class="m-tabs-content__item m-tabs-content__item--active" id="m_section_1">
                                    <h4 class="m--font-bold m--margin-top-15 m--margin-bottom-20">General Instruction</h4>
                                    <div class="m-accordion m-accordion--section m-accordion--padding-lg" id="m_section_1_content">


                                        <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed" role="tab" id="m_section_1_content_1_head" data-toggle="collapse" href="#m_section_1_content_1_body">
                                                <span class="m-accordion__item-title">Getting Started</span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse" id="m_section_1_content_1_body" role="tabpanel" aria-labelledby="m_section_1_content_1_head" data-parent="#m_section_1_content">
                                                <div class="m-accordion__item-content">

                                                    <video width="720" height="540" controls="controls">
                                                        <source src="https://compelapps.in/eFacilito_UAT/Knowledge_Base/Videos/Files/test_videos.mp4" type="audio/mp4" />
                                                        Your browser does not support the video tag.
                                                    </video>
                                                    <br />
                                                    </br>

                                                    <p>
                                                       
                                                    </p>

                                                </div>
                                            </div>
                                        </div>

                                        <!--end::Item-->
                                         <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed" role="tab" id="m_section_1_content_2_head" data-toggle="collapse" href="#m_section_1_content_2_body">
                                                <span class="m-accordion__item-title">Ticketing</span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse" id="m_section_1_content_2_body" role="tabpanel" aria-labelledby="m_section_1_content_2_head" data-parent="#m_section_1_content">
                                                <div class="m-accordion__item-content">
                                                    <p>
                                                       <h2>Ticketing</h2>
                                                     
                                                       <h6>Manage your facility’s daily complaints Issues & Task in the form of Ticket , assigned It To Respective Department.</h6> 
                                                        <br /> &nbsp;<h4>Log Complaints & ensure a progressive TAT</h4>
                                                    </p>
                                                    <p>
                                                       <ol>
                                                           <li>Manage your facility's daily complaints &  tasks in the form of Ticket</li>
                                                           <li>Assign Tickets to respective Departments & Users</li>
                                                           <li>Automated Escalations & Notifications on raised tickets</li>
                                                           <li>Convert Checklist flags to tickets</li>
                                                           <li>Detailed Category-wise , Department-wise & User Ticket Downtime Reports. </li>
                                                       </ol>
                                                    </p>
                                                    </div>
                                                </div>
                                            </div>
                                         <!--end::Item-->
                                         <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed" role="tab" id="m_section_1_content_3_head" data-toggle="collapse" href="#m_section_1_content_3_body">
                                                <span class="m-accordion__item-title">Login Process</span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse" id="m_section_1_content_3_body" role="tabpanel" aria-labelledby="m_section_1_content_3_head" data-parent="#m_section_1_content">
                                                <div class="m-accordion__item-content">
                                                    <p>
                                                        <h2>Login Process</h2>
                                                        <h6>Credentials for eFacilito will be provided to users by Administration / Operations Department</h6>


                                                    </p>
                                                    <p>
                                                        <h4>How to Sign In ?</h4>
                                                        <ul>
                                                            <li>Enter your Company Code in Company Code section eg. PHXKURLA </li>
                                                            <li>Once you enter your company code logo your company will be fetched </li>
                                                            <li>Select Employee Or Retailer</li>
                                                            <li>Enter your unique credentials                                                   eg. Username - abc@companyname.com                    password - 123456</li>
                                                            <li>Finally Click on SIGN IN</li>
                                                        </ul>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                         <!--end::Item-->
                                         <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed" role="tab" id="m_section_1_content_4_head" data-toggle="collapse" href="#m_section_1_content_4_body">
                                                <span class="m-accordion__item-title">Forget Password</span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse" id="m_section_1_content_4_body" role="tabpanel" aria-labelledby="m_section_1_content_4_head" data-parent="#m_section_1_content">
                                                <div class="m-accordion__item-content">
                                                    <p>
                                                        <h2>Forget Password</h2>
                                                        <h6>What If User Forget Password.There Is Option Of Forget Password When User Login</h6>
                                                        
                                                        <ul>
                                                            <li>Click On Forget Password</li>
                                                            <li>User Needs To Enter Email Id Which Is Linked With The Account </li>
                                                            <li>OTP Will BE Generated On User Email Id</li>
                                                            <li>Enter The OTP</li>
                                                            <li>Enter New Password And Confirm It Again</li>
                                                            <li>Click On Submit</li>
                                                            <li>Back To Login</li>
                                                        </ul>

                                                    </p>
                                                    </div>
                                                </div>
                                            </div>
                                         <!--end::Item-->
                                         <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed" role="tab" id="m_section_1_content_5_head" data-toggle="collapse" href="#m_section_1_content_5_body">
                                                <span class="m-accordion__item-title">Raise Request</span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse" id="m_section_1_content_5_body" role="tabpanel" aria-labelledby="m_section_1_content_5_head" data-parent="#m_section_1_content">
                                                <div class="m-accordion__item-content">
                                                    <p>
                                                      
                                                        <h2>Transactions</h2>
                                                       <h6> This will help users to quickly gain insights into the most important aspects of their data. They get real time insights and competitive analyses, and use them to identify items that require urgent action, streamlining workflows and properly purposing resources.</h6>
                                                        <br />&nbsp  <h4>How To Raise a Ticket ?</h4>
                                                        <ul>
                                                            <li>Click On Ticketing Module</li>
                                                            <li>Click On My Tickets </li>
                                                            <li>Click On New Request Button</li>
                                                        </ul>
                                                            <h6>My Request Details Gets Displayed</h6>
                                                        <ul>
                                                            <li>User Needs to Fill This Form For Raising Any Request</li>
                                                            <li>Select the location eg: PMC > GRD FLOOR > PEST CRTL > 2ND FLOOR</li>
                                                            <li>Select Category eg. Housekeeping</li>
                                                            <li>Then Select Sub-Category eg. Chairs to be cleaned </li>
                                                            <li>Insert Image against the ticket by clicking On Select Image   </li>
                                                            <li>After Selecting Images Click On Done </li>
                                                            <li>Finally Click On Save  </li>
                                                        </ul>
                                                        
                                                        <h4>Where User Can See The Raised Ticket ?</h4>
                                                        <ul>
                                                            <li>Click On Ticketing Module</li>
                                                            <li>Click On My Tickets</li>
                                                            <li>Enter The Unique Ticket No. Generated While Raising Ticket In the Search Box</li>
                                                        </ul>
                                                      

                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        
                                
                                         <!--end::Item-->
                                         <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed" role="tab" id="m_section_1_content_6_head" data-toggle="collapse" href="#m_section_1_content_6_body">
                                                <span class="m-accordion__item-title">Take Action On Raise Ticket</span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse" id="m_section_1_content_6_body" role="tabpanel" aria-labelledby="m_section_1_content_6_head" data-parent="#m_section_1_content">
                                                <div class="m-accordion__item-content">
                                                    <p>
                                                      <h4>How And From Where Take Action On Raised Tickets ?</h4>
                                                        <ul>
                                                            <li>Click On Ticket Module</li>
                                                            <li>Click On My Actionable</li>
                                                        </ul>
                                                        <h6>Here User Can See All The Raised Ticket</h6>
                                                        <ul>
                                                            <h6><u>User Can Take Action Here</u></h6>
                                                            <li>Open</li>
                                                            <li>hold</li>
                                                            <li>Closed</li>
                                                        </ul>

                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        
                                
                                         <!--end::Item-->
                                         <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed" role="tab" id="m_section_1_content_7_head" data-toggle="collapse" href="#m_section_1_content_7_body">
                                                <span class="m-accordion__item-title">Ticket Categories</span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse" id="m_section_1_content_7_body" role="tabpanel" aria-labelledby="m_section_1_content_7_head" data-parent="#m_section_1_content">
                                                <div class="m-accordion__item-content">
                                                    <p>
                                                        <h2>Ticket Category</h2>
                                                        &nbsp <br />
                                                        <h6>There Are Different Category User Can Create According To Which User Can Raise Ticket To Respective Category (In WorkFlow).</h6>
                                                        <h4>How To Create Category ?</h4>
                                                        <ul>
                                                            <li>Click On Ticket Module</li>
                                                            <li>Click On Ticket Category</li>
                                                            <li>Click On New Cattegory Button</li>
                                                        </ul>
                                                            <h6>Category Master Page Gets Displayed</h6>
                                                    <ul>
                                                        <li>Select Department From DropDown List</li>
                                                        <li>Enter The Category Description</li>
                                                        <li>Click On Save</li>
                                                    </ul>
                                                     <h2>Ticket Sub Category</h2>
                                                        <h6>According To There Category User Can Create SubCategory (In Workflow).</h6>
                                                        <h4>How To Create Sub Category ?</h4>
                                                        <ul>
                                                            <li>Click On Ticket Module</li>
                                                            <li>Click On Ticket Sub Category</li>
                                                            <li>Click On Add SubCategory Button</li>
                                                        </ul>
                                                        <h6>Category Master Page Gets Displayed</h6>
                                                        <ul>
                                                            <li>Select Category</li>
                                                            <li>Enter Sub Category Description</li>
                                                            <li>Click On Save</li>
                                                        </ul>
                                                      
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        
                                
                                         <!--end::Item-->
                                         <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed" role="tab" id="m_section_1_content_8_head" data-toggle="collapse" href="#m_section_1_content_8_body">
                                                <span class="m-accordion__item-title">Configure Workflow</span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse" id="m_section_1_content_8_body" role="tabpanel" aria-labelledby="m_section_1_content_8_head" data-parent="#m_section_1_content">
                                                <div class="m-accordion__item-content">
                                                    <p>
                                                          
                                                        <h2>Configure Workflow</h2>
                                                       <h6>Workflow Is Where User Get To Know . What Is Expected Time Of Ticket Resolution . If User Ticket Get Escalated . Escalation Timings .</h6>  
                                                        <ul>
                                                            <li>Click On Ticket Moduke</li>
                                                            <li>Click On Configure Workflow</li>
                                                            <li>Click On New Workflow Button</li>
                                                        </ul>
                                                        <h4>Workflow Details Page Gets Displayed</h4>
                                                        <ul>
                                                            <li>Enter Workflow Description</li>
                                                            <li>Select Category From DropDown List</li>
                                                            <li>Select Sub Category From DropDown List</li>
                                                            <li>Enter No.Of Levels</li>
                                                            <li>Click On Make Combination</li>
                                                            <li>Level Will Get Created In The Form Of Tables</li>
                                                            <li>Select Action Group</li>
                                                            <li>Click On Checkboxes Email SMS Notification As Per User Requirment</li>
                                                            <li>Enter Time To Each Level</li>
                                                            <li>Click On Save</li>
                                                        </ul>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                        
                                
                                         <!--end::Item-->

                                <!--begin::Section 2-->

                                <div class="m-tabs-content__item m-tabs-content__item" id="m_section_3">
                                    <h4 class="m--font-bold m--margin-top-15 m--margin-bottom-20"> Work Permit </h4>
                                    <div class="m-accordion m-accordion--section m-accordion--padding-lg" id="m_section_3_content">


                                        <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed" role="tab" id="m_section_3_content_1_head" data-toggle="collapse"  href="#m_section_3_content_1_body">
                                                <span class="m-accordion__item-title"> Work Permit </span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse" id="m_section_3_content_1_body" role="tabpanel" aria-labelledby="m_section_3_content_1_head" data-parent="#m_section_3_content">
                                                <div class="m-accordion__item-content">

                                                   
                                                    <p>
                                                      <h6> Work Permit Is For Contractor Visitor (Create Permit When Contractor Will Visit Date & Time And When The Permits Ends Date & Time) . </h6>
                                                       <h4>How To Create Work Permit ?</h4>
                                                        <ul>
                                                            <li>Click On Work Permit</li>
                                                            <li>Click On My Request</li>
                                                            <li>Click On New Request Button</li>
                                                            <li>Select Work Permit Title</li>
                                                            <li>Initiator Details (Get Filled AutoMatically When Selected Title)</li>
                                                            <li>Select From Date (Contractor Visit Date & Time)</li>
                                                            <li>Select To Date (Permit Ends Date & Time)</li>
                                                            <li>Click On Check Box To Agree Work Permit Terms And Conditions</li>
                                                            <li>Click On Submit</li>
                                                            <li>User Will Get Message Work Permit Request has been saved successfully With Unique Ticket No</li>
                                                        </ul>
                                                    </p>

                                                </div>
                                            </div>
                                        </div>
                                        <!--end::Item-->
                                          <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed" role="tab" id="m_section_3_content_2_head" data-toggle="collapse"  href="#m_section_3_content_2_body">
                                                <span class="m-accordion__item-title"> Configure Work Permit </span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse" id="m_section_3_content_2_body" role="tabpanel" aria-labelledby="m_section_3_content_2_head" data-parent="#m_section_3_content">
                                                <div class="m-accordion__item-content">

                                                   <h6>User Can Create What All Thing Contractor Needs To Mention When User Issue Work Permit</h6>
                                                    <p>
                                                       <h4>How To Configure Work Permit ?</h4>
                                                        <ul>
                                                            <li>Click On Work Permit</li>
                                                            <li>Click On Configure Work Permit</li>
                                                            <li>CLick On New Configure Button</li>
                                                            <li>Enter Title</li>
                                                            <li>Initiator (Employee , Retailer)</li>
                                                             <li>Click On CheckBox</li>
                                                            <li>Enter Work Permit Transaction Prefix</li>
                                                            <li>WorkPermitSection : Click On + Sign The Three Boxes Will Get Display <ol><li>Enter Question</li><li>Click On Check Box If User Wants The Question Is Mandatory</li><li>Select From Drop-Down List Type Of Answer User Need(multi-Select , Single Select Etc.)</li></ol></li>
                                                            <li>User Can Also Add More Work Permit Sections By Clicking On Add Section </li>
                                                            <li>Enter No Of Level & Click On Make Combination</li>
                                                            <li>The Table Boxes Will Get Created<ol><li>Click On The Icon Display In Action/Action Group & Select User</li><li>Click On Check Boxes (What All Notification,Access,Rights User Need To Enabled)</li></ol></li>
                                                            <li>Click On Add Term & Condition And Enter The Term & Condition</li>
                                                            <li>CLick On Save</li>
                                                        </ul>
                                                    </p>
                                                    <p><h6>If Want to Delete any Section Or Sub Section Click On Red Delete Icon On Right Side</h6></p>

                                                </div>
                                            </div>
                                        </div>
                                        <!--end::Item-->
                                        <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed" role="tab" id="m_section_3_content_3_head" data-toggle="collapse"  href="#m_section_3_content_3_body">
                                                <span class="m-accordion__item-title"> Work Permit Report </span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse" id="m_section_3_content_3_body" role="tabpanel" aria-labelledby="m_section_3_content_3_head" data-parent="#m_section_3_content">
                                                <div class="m-accordion__item-content">

                                                <h6>User Can View All The Report Issued Permit All The Details About the Permit When The Permit Ends .</h6>
                                                    <p>
                                                    <h4>How To View WorkPermit Report</h4>
                                                    <ul>
                                                        <li>Click On Work Permit</li>
                                                        <li>Click On Work Permit Report</li>
                                                        <li>Work Permit MIS Report Page Will Get Displayed</li>
                                                        <li>User Can See Ticket No Click On Ticket No & Can See All The Detail About That Ticket No </li>
                                                    </ul>
                                                        </p>
                                                </div>
                                            </div>
                                        </div>
                                        <!--end::Item-->


                                        </div>
                                    </div>
                                    
                                   

                                        <!--end::Item-->
                                        
                                        <!--begin::Section 3-->
                              <div class="m-tabs-content__item m-tabs-content__item" id="m_section_2">
                                    <h4 class="m--font-bold m--margin-top-15 m--margin-bottom-20"> Checklist </h4>
                                    <div class="m-accordion m-accordion--section m-accordion--padding-lg" id="m_section_2_content">


                                        <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed" role="tab" id="m_section_2_content_1_head" data-toggle="collapse"  href="#m_section_2_content_1_body">
                                                <span class="m-accordion__item-title"> Checklist </span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse" id="m_section_2_content_1_body" role="tabpanel" aria-labelledby="m_section_2_content_1_head" data-parent="#m_section_2_content">
                                                <div class="m-accordion__item-content">

                                                   
                                                    <p>
                                                       Type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a
																	galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into
																	Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into
                                                    </p>

                                                </div>
                                            </div>
                                        </div>

                                        </div>
                                    </div>
                      

                                        <!--end::Item-->

                                          
                                         <!--begin::Section 4-->

                                <div class="m-tabs-content__item m-tabs-content__item" id="m_section_4">
                                    <h4 class="m--font-bold m--margin-top-15 m--margin-bottom-20"> GatePass </h4>
                                    <div class="m-accordion m-accordion--section m-accordion--padding-lg" id="m_section_4_content">


                                        <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed" role="tab" id="m_section_4_content_1_head" data-toggle="collapse"  href="#m_section_4_content_1_body">
                                                <span class="m-accordion__item-title"> GatePass </span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse" id="m_section_4_content_1_body" role="tabpanel" aria-labelledby="m_section_4_content_1_head" data-parent="#m_section_4_content">
                                                <div class="m-accordion__item-content">

                                                   
                                                    <p>
                                                       <h6>Gate Pass Is Used For Inward And OutWard Of Material </h6>
                                                        <ul>
                                                            <li>Click On Gate Pass</li>
                                                            <li>Click On My Request</li>
                                                            <li>Click On New Request Button</li>
                                                            <li>Select Gate Pass Title</li>
                                                            <li>Gate Pass Description & Initiator Details  (Get Filled AutoMatically When Selected Title)</li>
                                                             <li>Select Gate Pass Date (Material Visit Date & Time)</li>
                                                             <li>Select Department</li>
                                                            <li>Gate Pass Details : Select Gate Pass Type & Fill All Detail Mention In It.</li>
                                                            <li>Click On Check Box To Agree Gate Pass Terms & Conditions</li>
                                                            <li>Upload Gate Pass Document</li>
                                                            <li>Click On Submit</li>
                                                            <li>User Will Get Message Work Permit Request has been saved successfully With Unique Ticket No</li>
                                                        </ul>
                                                    </p>

                                                </div>
                                            </div>
                                        </div>

                                        </div>
                                    </div>

                                        <!--end::Item-->
                               

                                 <!--begin::Section 5-->
                 
                                   <div class="m-tabs-content__item m-tabs-content__item" id="m_section_5">
                                    <h4 class="m--font-bold m--margin-top-15 m--margin-bottom-20"> FeedBack </h4>
                                    <div class="m-accordion m-accordion--section m-accordion--padding-lg" id="m_section_5_content">


                                        <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed" role="tab" id="m_section_5_content_1_head" data-toggle="collapse"  href="#m_section_5_content_1_body">
                                                <span class="m-accordion__item-title"> FeedBack </span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse" id="m_section_5_content_1_body" role="tabpanel" aria-labelledby="m_section_5_content_1_head" data-parent="#m_section_5_content">
                                                <div class="m-accordion__item-content">

                                                   
                                                    <p>
                                                        <h6>When Any Event Organizied User Can Fill Online Form For FeedBack Instead Of Using Pen & Paper For FeedBack</h6><br />
                                                        <h4>How To Fill FeedBack Form ?</h4>
                                                        <ul>
                                                            <li>User Have To Scan QR Code Or Browse The Given Link</li>
                                                            <li>FeedBack Request Form Will Get Displayed</li>
                                                            <li>Select FeedBack Form Title</li>
                                                            <li>Enter All Customer Details : First Name , Last Name , Phone no , Email Id , Gender</li>
                                                            <li>Enter Or Select FeedBack Details Questions</li>
                                                            <li>Click On Save</li>
                                                            <li>FeedBack Will Get Submitted</li>
                                                        </ul>
                                                    </p>

                                                </div>
                                            </div>
                                        </div>

                                        </div>
                                    </div>
                                  <!--end::Item-->
                                
                                 <!--begin::Section 6-->
                 
                                   <div class="m-tabs-content__item m-tabs-content__item" id="m_section_6">
                                    <h4 class="m--font-bold m--margin-top-15 m--margin-bottom-20"> AssetManager </h4>
                                    <div class="m-accordion m-accordion--section m-accordion--padding-lg" id="m_section_6_content">


                                        <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed" role="tab" id="m_section_6_content_1_head" data-toggle="collapse"  href="#m_section_6_content_1_body">
                                                <span class="m-accordion__item-title"> AssetManager </span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse" id="m_section_6_content_1_body" role="tabpanel" aria-labelledby="m_section_6_content_1_head" data-parent="#m_section_5_content">
                                                <div class="m-accordion__item-content">

                                                   
                                                    <p>
                                                       <h4>Asset </h4>
                                                    </p>

                                                </div>
                                            </div>
                                        </div>

                                        </div>
                                    </div>
                                  <!--end::Item-->

                                
                                 <!--begin::Section 7-->
                 
                                   <div class="m-tabs-content__item m-tabs-content__item" id="m_section_7">
                                    <h4 class="m--font-bold m--margin-top-15 m--margin-bottom-20"> VMS </h4>
                                    <div class="m-accordion m-accordion--section m-accordion--padding-lg" id="m_section_7_content">


                                        <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed" role="tab" id="m_section_7_content_1_head" data-toggle="collapse"  href="#m_section_7_content_1_body">
                                                <span class="m-accordion__item-title"> VMS </span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse" id="m_section_7_content_1_body" role="tabpanel" aria-labelledby="m_section_7_content_1_head" data-parent="#m_section_7_content">
                                                <div class="m-accordion__item-content">

                                                   
                                                    <p>
                                                       <h6>VMS (Visitor Management System) : Is Used For Normal Visitor/User</h6><br />
                                                        <h4>How To Create VMS ?</h4>
                                                        <UL>
                                                            <li>Click On VMS</li>
                                                            <li>Click On Visit Request</li>
                                                            <li>Click On New Request Button : Visit Request Page Get Displayed</li>
                                                            <li>Select Form Title</li>
                                                            <li>Enter Name , Email , Phone no , Visit Date , Meeting With.</li>
                                                            <li>Enter Visit Details</li>
                                                            <li>Covid-19 Assessment Test</li>
                                                            <li>Click On <span style="color : blue;">MARK IN</span> Button </li>
                                                        </UL>
                                                    </p>

                                                </div>
                                            </div>
                                        </div>

                                        </div>
                                    </div>
                                  <!--end::Item-->

                                
                                 <!--begin::Section 8-->
                 
                                   <div class="m-tabs-content__item m-tabs-content__item" id="m_section_8">
                                    <h4 class="m--font-bold m--margin-top-15 m--margin-bottom-20"> GeneralSetup </h4>
                                    <div class="m-accordion m-accordion--section m-accordion--padding-lg" id="m_section_8_content">


                                        <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed" role="tab" id="m_section_8_content_1_head" data-toggle="collapse"  href="#m_section_8_content_1_body">
                                                <span class="m-accordion__item-title"> GeneralSetup </span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse" id="m_section_8_content_1_body" role="tabpanel" aria-labelledby="m_section_8_content_1_head" data-parent="#m_section_8_content">
                                                <div class="m-accordion__item-content">

                                                   
                                                    <p>
                                                      <h6>In General SetUp User Can Create Departments , Can Create User By Creating There Unique Credential , Can Create Location Path Details & Etc. </h6><br />
                                                        <h4>How To Create User ?</h4>
                                                        <ul>
                                                            <li> Click On General SetUp</li>
                                                            <li>Click On User</li>
                                                            <li>Click On New User Button</li>
                                                            <li>Select Department</li>
                                                            <li>Select User Designation</li>
                                                            <li>Enter User Code</li>
                                                            <li>Select Role (User Is Employee , Retailer , Admin , Manager)</li>
                                                            <li>Enter First Name , Last Name , User Email Id , Mobile no</li>
                                                            <li>Enter Alternate No , Landline No (Optional)</li>
                                                            <li>Upload User Image & User Signature</li>
                                                            <li>Select Approver</li>
                                                            <li>UserName & Password (Unique Credential For Login)</li>
                                                            <li>Save</li>
                                                        </ul>

                                                    </p>

                                                </div>
                                            </div>
                                        </div>

                                        </div>
                                    </div>
                                  <!--end::Item-->

                                
                                 <!--begin::Section 9-->
                 
                                   <div class="m-tabs-content__item m-tabs-content__item" id="m_section_9">
                                    <h4 class="m--font-bold m--margin-top-15 m--margin-bottom-20"> RightsManagement </h4>
                                    <div class="m-accordion m-accordion--section m-accordion--padding-lg" id="m_section_9_content">


                                        <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed" role="tab" id="m_section_9_content_1_head" data-toggle="collapse"  href="#m_section_9_content_1_body">
                                                <span class="m-accordion__item-title"> RightsManagement </span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse" id="m_section_9_content_1_body" role="tabpanel" aria-labelledby="m_section_9_content_1_head" data-parent="#m_section_9_content">
                                                <div class="m-accordion__item-content">

                                                   
                                                    <p>
                                                       <h6>In Rights Management User Can Give Role Eg: Manager , Retailer , Admin , Employee Etc. & Provide There Rights  .</h6>
                                                        <h4>How To Create Role ?</h4>
                                                        <ul>
                                                            <li>Click On Rights Management</li>
                                                            <li>Click On Role</li>
                                                            <li>Click On New Role Button</li>
                                                            <li>Enter(Add/Edit) Role </li>
                                                            <li>Sumbit</li>
                                                        </ul>
                                                        <h4>How To Create(give) Rights To Respective Created Roles ?</h4>
                                                        <ul>
                                                            <li>Click On Rights Management </li>
                                                            <li>Select Role Name (Emp , Manager Etc.)</li>
                                                            <li>Select Menu Name (The Module On The Left Side Ticketing Dashboard Etc . )</li>
                                                            <li>Click On Check Boxes (Which SubModule Rights To Be Provided/Shown To The Respective User .)</li>
                                                            <li>Click On Submit</li>
                                                        </ul>
                                                        <h4>How To Assign Role To Particular User ?</h4>
                                                        <ul>
                                                            <li>Click On Rights Management</li>
                                                            <li>Click On Assign Role</li>
                                                            <li>Click On Assign Role Button</li>
                                                            <li>Slect Role</li>
                                                            <li>Click On Check Boxes (Select User)</li>
                                                            <li>Click On Submit</li>
                                                        </ul>
                                                    </p>

                                                </div>
                                            </div>
                                        </div>

                                        </div>
                                    </div>
                                  <!--end::Item-->

                                
                                 <!--begin::Section 10-->
                 
                                   <div class="m-tabs-content__item m-tabs-content__item" id="m_section_10">
                                    <h4 class="m--font-bold m--margin-top-15 m--margin-bottom-20"> Inventory </h4>
                                    <div class="m-accordion m-accordion--section m-accordion--padding-lg" id="m_section_10_content">


                                        <!--begin::Item-->
                                        <div class="m-accordion__item">
                                            <div class="m-accordion__item-head collapsed" role="tab" id="m_section_10_content_1_head" data-toggle="collapse"  href="#m_section_10_content_1_body">
                                                <span class="m-accordion__item-title"> Inventory </span>
                                                <span class="m-accordion__item-mode"></span>
                                            </div>
                                            <div class="m-accordion__item-body collapse" id="m_section_10_content_1_body" role="tabpanel" aria-labelledby="m_section_10_content_1_head" data-parent="#m_section_10_content">
                                                <div class="m-accordion__item-content">

                                                   
                                                    <p>
                                                       Type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a
																	galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into
																	Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap
																	into
                                                    </p>

                                                </div>
                                            </div>
                                        </div>

                                        </div>
                                    </div>
                                  <!--end::Item-->

                                </div>
                            </div>
                        

                        
                                 </div>

            <!--end::Portlet-->
       

    </div>

                    </div>
                    </div>
                </div>
            </div>
       
</asp:Content>
