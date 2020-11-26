<%@ Page Title="" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="System_Settings.aspx.cs" Inherits="Upkeep_v3.General_Masters.System_Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>System Settings</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                    <div class="m-content">

                        <div class="row">

							    <div class="col-md-6">

                                    <!-- Ticketing Settings-->
								    <!--begin::Portlet-->
								    <div class="m-portlet m-portlet--tab">
									    <div class="m-portlet__head">
										    <div class="m-portlet__head-caption">
											    <div class="m-portlet__head-title">
												    <span class="m-portlet__head-icon m--hide">
													    <i class="la la-gear"></i>
												    </span>
												    <h3 class="m-portlet__head-text">
													    Ticketing Settings
												    </h3>
											    </div>
										    </div>
									    </div>
									    <div class="m-portlet__body">

										    <!--begin::Section-->
										    <div class="m-section">
											    <span class="m-section__sub">
												    Customize your Ticketing Management System Functions:
											    </span>
											    <div class="m-section__content">
												    <div class="m-demo" data-code-preview="true" data-code-html="true" data-code-js="false">
													    <div class="m-demo__preview">

														    <!--begin::Form-->
														    <form class="m-form">

															    <div class="m-form__group form-group">
																
																    <div class="m-checkbox-list">
																	    <label class="m-checkbox m-checkbox--check-bold m-checkbox--state-brand">
																		    <input type="checkbox"> Photo Upload Compulsory while raising ticket
																		    <span></span>
																	    </label>
																	
																	    <label class="m-checkbox m-checkbox--check-bold m-checkbox--state-brand">
																		    <input type="checkbox" checked="checked"> Photo Upload Compulsory while closing ticket
																		    <span></span>
																	    </label>
                                                                        <label class="m-checkbox m-checkbox--check-bold m-checkbox--state-brand">
																		    <input type="checkbox" checked="checked" > Remarks Compulsory while raising ticket
																		    <span></span>
																	    </label>
                                                                        <label class="m-checkbox m-checkbox--check-bold m-checkbox--state-brand">
																		    <input type="checkbox" > Remarks Compulsory while closing ticket
																		    <span></span>
																	    </label>
																    </div>
															    </div>


                                                                <div class="m-form__group form-group row">
																            
																            <label class="col-3 col-form-label">Ticket Expiry</label>
																            <div class="col-3">
																	            <span class="m-switch m-switch--sm m-switch--icon">
																		            <label>
																			            <input type="checkbox" checked="checked" name="">
																			            <span></span>
																		            </label>
																	            </span>
																            </div>
                                                                            
																	            <div class="alert m-alert m-alert--default" role="alert">
													                                NOTE : If you Disable Ticket expiry , Downtime for Escalated Ticket will keep on increasing until it is closed.
												                                </div>
																            
															            </div>



														    </form>

														    <!--end::Form-->
													    </div>
												    </div>
											    </div>
										    </div>

										    <!--end::Section-->
									    </div>
								    </div>
								    <!--end::Portlet-->

                                    <!-- Checklist Settings-->
                                    <div class="m-portlet m-portlet--tab">
									    <div class="m-portlet__head">
										    <div class="m-portlet__head-caption">
											    <div class="m-portlet__head-title">
												    <span class="m-portlet__head-icon m--hide">
													    <i class="la la-gear"></i>
												    </span>
												    <h3 class="m-portlet__head-text">
													    Checklist Settings
												    </h3>
											    </div>
										    </div>
									    </div>
									    <div class="m-portlet__body">

										    <!--begin::Section-->
										    <div class="m-section">
											    <span class="m-section__sub">
												    Customize your Checklist Management Functions:
											    </span>
											    <div class="m-section__content">
												    <div class="m-demo" data-code-preview="true" data-code-html="true" data-code-js="false">
													    <div class="m-demo__preview">

														    <!--begin::Form-->
														    <form class="m-form">

															    <div class="m-form__group form-group">
																
																    <div class="m-checkbox-list">
																	    <label class="m-checkbox m-checkbox--check-bold m-checkbox--state-brand">
																		    <input type="checkbox"> QR Scan Compulsory to attend Scheduled Checklists
																		    <span></span>
																	    </label>
																	
																	  
																    </div>
															    </div>

														    </form>

														    <!--end::Form-->
													    </div>
												    </div>
											    </div>


										    </div>

										    <!--end::Section-->
									    </div>
								    </div>


							    </div>
                                <div class="col-md-6">

								    <!--begin::Portlet-->
								    <div class="m-portlet m-portlet--tab">
									    <div class="m-portlet__head">
										    <div class="m-portlet__head-caption">
											    <div class="m-portlet__head-title">
												    <span class="m-portlet__head-icon m--hide">
													    <i class="la la-gear"></i>
												    </span>
												    <h3 class="m-portlet__head-text">
													    Work Permit Settings
												    </h3>
											    </div>
										    </div>
									    </div>
									    <div class="m-portlet__body">

										    <!--begin::Section-->
										    <div class="m-section">
											    <span class="m-section__sub">
												    Customize your Work permit Management System Functions:
											    </span>
											    <div class="m-section__content">
												    <div class="m-demo" data-code-preview="true" data-code-html="true" data-code-js="false">
													    <div class="m-demo__preview">

														    <!--begin::Form-->
														    <form class="m-form">

															    <div class="m-form__group form-group">
																
																    <div class="m-checkbox-list">
																	    <label class="m-checkbox m-checkbox--check-bold m-checkbox--state-brand">
																		    <input type="checkbox" checked="checked"> Enable / Disable Work Permit Auto-Expiry
																		    <span></span>
																	    </label>
																	

                                                                        <span class="m-form__help">Disabling Auto-Expire will not mark the Work Permits as Expired, if it is not approved before the Permit To-Date</span>

                                                                        
                                                                    
																    </div>
															    </div>

														    </form>

														    <!--end::Form-->
													    </div>
												    </div>
											    </div>

										    </div>

										    <!--end::Section-->
									    </div>
								    </div>
								    <!--end::Portlet-->


                                    <!--begin::Portlet-->
								    <div class="m-portlet m-portlet--tab">
									    <div class="m-portlet__head">
										    <div class="m-portlet__head-caption">
											    <div class="m-portlet__head-title">
												    <span class="m-portlet__head-icon m--hide">
													    <i class="la la-gear"></i>
												    </span>
												    <h3 class="m-portlet__head-text">
													    Gate Pass Settings
												    </h3>
											    </div>
										    </div>
									    </div>
									    <div class="m-portlet__body">

										    <!--begin::Section-->
										    <div class="m-section">
											    <span class="m-section__sub">
												    Customize your Work permit Management System Functions:
											    </span>
											    <div class="m-section__content">
												    <div class="m-demo" data-code-preview="true" data-code-html="true" data-code-js="false">
													    <div class="m-demo__preview">

														    <!--begin::Form-->
														    <form class="m-form">

															    <div class="m-form__group form-group">
																
																    <div class="m-checkbox-list">
																	    <label class="m-checkbox m-checkbox--check-bold m-checkbox--state-brand">
																		    <input type="checkbox" checked="checked"> Enable / Disable Gate Pass Auto-Expiry
																		    <span></span>
																	    </label>
																	

                                                                        <span class="m-form__help">Disabling Auto-Expire will not mark the Gate Pass as Expired, if it is not approved before the Gate pass To-Date & Time </span>

                                                                        
                                                                    
																    </div>
															    </div>

														    </form>

														    <!--end::Form-->
													    </div>
												    </div>
											    </div>

										    </div>

										    <!--end::Section-->
									    </div>
								    </div>
								    <!--end::Portlet-->



                                    <!--begin::Portlet-->
								    <div class="m-portlet m-portlet--tab">
									    <div class="m-portlet__head">
										    <div class="m-portlet__head-caption">
											    <div class="m-portlet__head-title">
												    <span class="m-portlet__head-icon m--hide">
													    <i class="la la-gear"></i>
												    </span>
												    <h3 class="m-portlet__head-text">
													    Geo Fencing Settings
												    </h3>
											    </div>
										    </div>
									    </div>
									    <div class="m-portlet__body">

										    <!--begin::Section-->
										    <div class="m-section">
											    <span class="m-section__sub">
												    Customize your Geo-Fencing Settings here:
											    </span>
											    <div class="m-section__content">
												    <div class="m-demo" data-code-preview="true" data-code-html="true" data-code-js="false">
													    <div class="m-demo__preview">

														    <!--begin::Form-->
														    <form class="m-form">

                                                                        <div class="form-group m-form__group">
												                            <label>Lattitude</label>
												                            <div class="m-input-icon m-input-icon--left">
													                            <input type="text" class="form-control m-input" placeholder="Enter Lattitude">
													                            <span class="m-input-icon__icon m-input-icon__icon--left"><span><i class="la la-map-marker"></i></span></span>
												                            </div>
                                                                        
											                            </div>
                                                                        <div class="form-group m-form__group">
												                        
                                                                            <label>Longitude</label>
												                            <div class="m-input-icon m-input-icon--left">
													                            <input type="text" class="form-control m-input" placeholder="Enter Longitude">
													                            <span class="m-input-icon__icon m-input-icon__icon--left"><span><i class="la la-map-marker"></i></span></span>
												                            </div>
											                            </div>

                                                                        <div id="m_gmap_6" style="height:300px;"></div>

                            
                                                                    <div class="alert m-alert m-alert--default" role="alert">
													                    NOTE : Users will only be able to operate Web & Mobile Applications, when they are within the fencing range set below
												                    </div>
                                                                    
                                                                    <div class="form-group m-form__group">
												                        
                                                                            <label>Range</label>
												                            <div class="m-input-icon m-input-icon--left">
													                            <input type="text" class="form-control m-input" placeholder="Enter Fencing Range in Meters">
													                            <span class="m-input-icon__icon m-input-icon__icon--left"><span><i class="la la-map-marker"></i></span></span>
												                            </div>
											                            </div>
                                                                          
																    </div>
															    </div>


														    </form>

														    <!--end::Form-->
													    </div>
												    </div>
											    </div>

										    </div>

										    <!--end::Section-->
									    </div>
								    </div>
								    <!--end::Portlet-->
							    </div>  


                               
							   

                        </div>

                    </div>
    
</asp:Content>
