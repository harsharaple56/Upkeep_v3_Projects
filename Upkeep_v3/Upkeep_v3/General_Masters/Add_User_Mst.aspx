<%@ Page Title="eFacilito | Users" Language="C#" MasterPageFile="~/UpkeepMaster.Master" AutoEventWireup="true" CodeBehind="Add_User_Mst.aspx.cs" Inherits="Upkeep_v3.General_Masters.Add_User_Mst" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            left: 0px;
            top: 0px;
        }
    </style>

    <script type="text/javascript">
        $(function () {
            $('#<%=fileUpload_UserSignature.ClientID %>').change(function () {
                var fileExtension = ['jpeg', 'jpg', 'png'];
                $('#SignUpload_Msg').text('').hide();
                if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
                    //alert("Only '.jpeg','.jpg', '.png', formats are allowed."); 
                    $('#SignUpload_Msg').text("Failed!! Please upload jpg, jpeg, png file only.").show();
                    $(this).replaceWith($(this).val('').clone(true));
                }
                //100000 Byte -- 100 KB
                if ($(this).get(0).files[0].size > (100000)) {
                    $('#SignUpload_Msg').text("Failed!! Max allowed file size is 100 KB").show();
                    $(this).replaceWith($(this).val('').clone(true));
                }
            })

            $('#<%=fileUpload_UserImage.ClientID %>').change(function () {
                var fileExtension = ['jpeg', 'jpg', 'png'];
                $('#UserImgUpload_Msg').text('').hide();
                if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
                    //alert("Only '.jpeg','.jpg', '.png', formats are allowed."); 
                    $('#UserImgUpload_Msg').text("Failed!! Please upload jpg, jpeg, png file only.").show();
                    $(this).replaceWith($(this).val('').clone(true));
                }
                //100000 Byte -- 100 KB
                if ($(this).get(0).files[0].size > (100000)) {
                    $('#UserImgUpload_Msg').text("Failed!! Max allowed file size is 100 KB").show();
                    $(this).replaceWith($(this).val('').clone(true));
                }
            })

        })
    </script>


    <style type="text/css">
        .modalBackground {
            background-color: grey;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            /*background-color: #fff;
            border: 3px solid #ccc;*/
            padding: 10px;
            width: 300px;
        }

        /*.highlight {
            background-color: blanchedalmond;
        }*/
    </style>

    <script>
        $(document).ready(function () {
            //$('#clickmewow').click(function () {
            //    $('#radio1003').attr('checked', 'checked');
            //});


            $('#exampleModal').on('show.bs.modal', function (event) {

                var button = $(event.relatedTarget); // Button that triggered the modal
                var title = button.data('title'); // Extract info from data-* attributes
                var images_list = button.data('images'); // Extract info from data-* attributes
                // alert(images_list);
                var modal = $(this);
                modal.find('.modal-title').text(title);
                var images = images_list.split(',')
                modal.find('.modal-body .carousel-inner').html('')
                $.each(images, function (index, image) {
                    if (index == 0)
                        var item = '<div class="carousel-item active">';
                    else
                        var item = '<div class="carousel-item">';
                    item += '<img class="d-block w-100" src="' + image + '"></div>'
                    modal.find('.modal-body .carousel-inner').append(item);
                });
                //$('.carousel').carousel();
            })
        });
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="m-grid__item m-grid__item--fluid m-wrapper">
        <div class="">
            <div class="row">
                <div class="col-lg-12">

                    <!--begin::Portlet-->
                    <div class="m-portlet m-portlet--last m-portlet--head-lg m-portlet--responsive-mobile" id="main_portlet">



                        <div class="m-portlet__head">
                            <div class="m-portlet__head-progress">
                            </div>
                            <div class="m-portlet__head-wrapper">
                                <div class="m-portlet__head-caption">
                                    <div class="m-portlet__head-title">
                                        <h3 class="m-portlet__head-text">User Details
                                        </h3>
                                    </div>
                                </div>

                                <div class="m-portlet__head-tools">


                                    <a href="<%= Page.ResolveClientUrl("User_Mst.aspx") %>" class="btn btn-secondary m-btn m-btn--icon m-btn--wide m-btn--md m--margin-right-10">
                                        <span>
                                            <i class="la la-arrow-left"></i>
                                            <span>Back</span>
                                        </span>
                                    </a>
                                    <div class="btn-group">

                                        <asp:Button ID="btnSave" runat="server" class="btn btn-accent  m-btn m-btn--icon m-btn--wide m-btn--md" OnClick="btnSave_Click" Text="Save" ValidationGroup="ValidateUser" />

                                    </div>
                                </div>

                            </div>
                        </div>



                        <!--begin: Form Body -->
                        <div class="m-form m-form--fit m-form--group-seperator-dashed">
                            <div class="row">
                                <div class="col-xl-12">
                                    <div class="m-form__section m-form__section--first">

                                        <%-- commented by sujata --%>

                                        <%--         <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Zone:</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                       <asp:DropDownList ID="ddlZone" class="form-control m-input" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged" AutoPostBack="true" runat="server" ></asp:DropDownList>

                                                    </div>
                                                </div>
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Location:</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                       <asp:DropDownList ID="ddlLocation" class="form-control m-input" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged" AutoPostBack="true" runat="server" ></asp:DropDownList>
                                                     

                                                    </div>
                                                </div>
                                                <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Sub-Location:</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                       <asp:DropDownList ID="ddlSublocation" class="form-control m-input"  OnSelectedIndexChanged="ddlSublocation_SelectedIndexChanged" AutoPostBack="true" runat="server" ></asp:DropDownList>
                                                      
                                                    </div>
                                                </div>--%>
                                        <%-- end commented by sujata --%>

                                        <div class="form-group m-form__group row">
                                            <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Department:</label>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:DropDownList ID="ddlDepartment" class="form-control m-input" runat="server"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvddlDepartment" runat="server" ControlToValidate="ddlDepartment" ValidationGroup="ValidateUser"
                                                    ErrorMessage="Please select Department" InitialValue="0" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>

                                            <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> User Designation:</label>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:TextBox ID="txtUserDesignation" runat="server" class="form-control m-input" placeholder="User Designation"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvUserDesignation" runat="server" ControlToValidate="txtUserDesignation" ValidationGroup="ValidateUser"
                                                    ErrorMessage="Please select User Designation" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group m-form__group row" style="display: none;">
                                            <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span>User Type:</label>
                                            <div class="col-xl-9 col-lg-9">
                                                <asp:DropDownList ID="ddlTypeUser" class="form-control m-input" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group m-form__group row">
                                            <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> User Code:</label>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:TextBox ID="txtUserCode" runat="server" class="form-control m-input" placeholder="User_Code"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvUserCode" runat="server" ControlToValidate="txtUserCode" ValidationGroup="ValidateUser"
                                                    ErrorMessage="Please select User Code" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>

                                            <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Role :</label>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:DropDownList ID="ddlRole" class="form-control m-input" runat="server"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorddlRole" runat="server" ControlToValidate="ddlRole" ValidationGroup="ValidateUser"
                                                    ErrorMessage="Please select Role" InitialValue="0" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group m-form__group row">
                                            <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> First Name:</label>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:TextBox ID="txtFirstName" runat="server" class="form-control m-input" placeholder="First Name"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" ValidationGroup="ValidateUser"
                                                    ErrorMessage="Please enter First Name" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>

                                            <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Last Name:</label>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:TextBox ID="txtlastName" runat="server" class="form-control m-input" placeholder="Last Name"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvlastName" runat="server" ControlToValidate="txtlastName" ValidationGroup="ValidateUser"
                                                    ErrorMessage="Please enter Last Name" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="form-group m-form__group row">
                                            <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> User Email:</label>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:TextBox ID="txtuseremail" runat="server" class="form-control m-input" placeholder="User Email"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvUserEmail" runat="server" ControlToValidate="txtUserEmail" ValidationGroup="ValidateUser"
                                                    ErrorMessage="Please enter User Email" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>

                                            <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Mobile Number:</label>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:TextBox ID="txtmobile" runat="server" class="form-control m-input" placeholder="Mobile Number"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvmobile" runat="server" ControlToValidate="txtmobile" ValidationGroup="ValidateUser"
                                                    ErrorMessage="Please enter Mobile number" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <%--<div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> User Designation:</label>
                                                    <div class="col-xl-9 col-lg-9">                                                     
                                                        <asp:TextBox ID="txtUserDesignation" runat="server" class="form-control m-input" placeholder="User_Designation"></asp:TextBox>
                                                        <span id="error_txtUserDesignation" class="text-danger small"></span>
                                                        <asp:RequiredFieldValidator ID="rfvUserDesignation" runat="server" ControlToValidate="txtUserDesignation"
                                                        ErrorMessage="Please select User Designation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>--%>

                                        <div class="form-group m-form__group row">
                                            <label class="col-xl-2 col-lg-2 col-form-label">Alter Mobile number:</label>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:TextBox ID="txtAlterMobile" runat="server" class="form-control m-input" placeholder="Alter Mobile Number"></asp:TextBox>
                                            </div>

                                            <label class="col-xl-2 col-lg-2 col-form-label">Landline number:</label>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:TextBox ID="TxtLandline" runat="server" class="form-control m-input" placeholder="Landline Mobile Number"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group m-form__group row">
                                            <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> User Image</label>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:FileUpload ID="fileUpload_UserImage" runat="server" />
                                            </div>
                                            <div class="col-xl-1 col-lg-1" runat="server" style="display: none;" id="dvProfilePic">
                                                <asp:Repeater ID="rptProfilePic" runat="server">
                                                    <ItemTemplate>
                                                        <table>
                                                            <tr>
                                                                <td style="width: 5%">
                                                                    <button type='button' data-toggle='modal' id="btnShowImage" data-target="#exampleModal" data-images="<%#Eval("Profile_Photo") %>" class='btn btn-accent m-btn m-btn--icon' data-container='body' style="width: 41px; height: 41px;" data-toggle='m-tooltip' data-placement='top' title='View Uploaded Image'>
                                                                        <i class='la la-image' style="margin-left: -106%; font-size: 2.3rem;"></i>
                                                                    </button>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                            <div class="col-xl-5 col-lg-5">
                                                <span id="UserImgUpload_Msg" style="color: red;"></span>
                                            </div>
                                        </div>

                                        <div class="form-group m-form__group row">
                                            <label class="col-xl-2 col-lg-2 col-form-label">User Signature</label>
                                            <div class="col-xl-4 col-lg-4">
                                                <asp:FileUpload ID="fileUpload_UserSignature" runat="server" />
                                            </div>
                                            <div class="col-xl-1 col-lg-1" runat="server" style="display: none;" id="dvSignature">
                                                <asp:Repeater ID="rptSignature" runat="server">
                                                    <ItemTemplate>
                                                        <table>
                                                            <tr>
                                                                <td style="width: 5%">
                                                                    <button type='button' data-toggle='modal' id="btnShowImage" data-target="#exampleModal" data-images="<%#Eval("Signature") %>" class='btn btn-accent m-btn m-btn--icon' data-container='body' style="width: 41px; height: 41px;" data-toggle='m-tooltip' data-placement='top' title='View Uploaded Image'>
                                                                        <i class='la la-image' style="margin-left: -106%; font-size: 2.3rem;"></i>
                                                                    </button>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                            <div class="col-xl-5 col-lg-5">
                                                <span id="SignUpload_Msg" style="color: red;"></span>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-9">
                                                <asp:CheckBox ID="chk_IsApproval" OnCheckedChanged="chk_IsApproval_CheckedChanged" runat="server" Style="margin-left: 3px;" />
                                                <label class="col-form-label">Check the Box if User is an Approver.</label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-1"></div>
                                            <div class="col-lg-9">
                                                <asp:CheckBox ID="chk_IsGobalApproval" OnCheckedChanged="chk_IsGobalApproval_CheckedChanged" runat="server" Style="margin-left: 3px;" />
                                                <label class="col-form-label">Check the box if User is Global Approver.</label>
                                            </div>
                                        </div>




                                        <div id="dvApprovalID" runat="server" visible="True">
                                            <div class="form-group m-form__group row">
                                                <label class="col-xl-2 col-lg-2 col-form-label">Approver :</label>
                                                <div class="col-xl-4 col-lg-4">
                                                    <asp:DropDownList ID="ddlApprover" class="form-control m-input" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>

                                            <%-- <div class="form-group m-form__group row">
                                                    <label class="col-xl-3 col-lg-3 col-form-label"><span style="color: red;">*</span> Role :</label>
                                                    <div class="col-xl-9 col-lg-9">
                                                        <asp:DropDownList ID="ddlRole" class="form-control m-input" runat="server"></asp:DropDownList>
                                                    </div>
                                                </div>--%>

                                            <div class="form-group m-form__group row">
                                                <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Username:</label>
                                                <div class="col-xl-4 col-lg-4">
                                                    <asp:TextBox ID="txtUserLogin" runat="server" class="form-control m-input" placeholder="Enter User Login ID"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvUserLogin" runat="server" ControlToValidate="txtUserLogin" ValidationGroup="ValidateUser"
                                                        ErrorMessage="Please enter User Login" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </div>

                                                <label class="col-xl-2 col-lg-2 col-form-label"><span style="color: red;">*</span> Password:</label>
                                                <div class="col-xl-4 col-lg-4">
                                                    <asp:TextBox ID="txtPassword" runat="server" class="form-control m-input" placeholder="Enter User Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvUserPassword" runat="server" ControlToValidate="txtPassword" ValidationGroup="ValidateUser"
                                                        ErrorMessage="Please enter User Password" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>


                                        </div>

                                        <div class="form-group m-form__group row">
                                            <div class="col-xl-9 col-lg-9">
                                                <asp:Label ID="lblUserErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red" Style="font-size: large; font-weight: bold;"></asp:Label>
                                                <asp:Label ID="lblErrorMsg" Text="" runat="server" CssClass="col-xl-3 col-lg-3 col-form-label" ForeColor="Red"></asp:Label>
                                            </div>
                                        </div>

                                    </div>

                                </div>
                            </div>
                        </div>


                    </div>
            </div>

            <!--end::Portlet-->
        </div>
    </div>
    </div>


    <div aria-hidden="true" aria-labelledby="exampleModalLabel" class="modal fade" id="exampleModal" role="dialog" tabindex="-1">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel1">Uploaded Image
                    </h5>
                    <button aria-label="Close" class="close" data-dismiss="modal" type="button">
                        <span aria-hidden="true">×
                        </span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="carousel slide" data-ride="carousel" id="carouselExampleControls">
                        <div class="carousel-inner">
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>



</asp:Content>
