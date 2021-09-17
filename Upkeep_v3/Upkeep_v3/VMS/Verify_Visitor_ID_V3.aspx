<%@ Page Title="" Language="C#" MasterPageFile="~/BlankMaster.Master" AutoEventWireup="true" CodeBehind="Verify_Visitor_ID_V3.aspx.cs" Inherits="Upkeep_v3.VMS.Verify_Visitor_ID_V3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="../assets/html5-qrcode.min.js"></script>

    <script type="text/javascript">
        $(function () {
            $("#userinfo").hide();
            $("#invaliduser").hide();
            $("#scaninfo").show();
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#lbl_Visitor_Name").html('');
            $("#lbl_Visitor_Email").html('');
            $("#lbl_VisitRequest_ID").html('');
            $("#lbl_Visitor_Contact").html('');
            $("#Img_Visitor_Photo").attr("src", "");
            $("#lbl_Vacc_Date").html('');
            $("#lbl_Request_Date_Text").html('');
            $("#lbl_Visit_Date_Text").html('');

            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": false,
                "progressBar": false,
                "positionClass": "toast-bottom-center",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "3000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            };

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
