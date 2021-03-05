<%@ Page Title="" Language="C#" MasterPageFile="~/BlankMaster.Master" AutoEventWireup="true" CodeBehind="ThankYou.aspx.cs" Inherits="Upkeep_v3.Feedback.ThankYou" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>

        $(document).ready(function () {
            //debugger;
            //var feedbackURL = location.search;
            var feedbackURL = getUrlParameter('url');
            //var EventID = getUrlParameter('EventID');
            //var fullFeedoURL = feedbackURL + "=" + EventID;

            //alert(fullFeedoURL);

            setTimeout(function () {
                window.location.href = feedbackURL
            }, 2200);


            function getUrlParameter(sParam) {
                //debugger;
                var sPageURL = window.location.search.substring(1),
                    sURLVariables = sPageURL.split('&'),
                    sParameterName,
                    i;

                //alert(sPageURL);
                for (i = 0; i < sURLVariables.length; i++) {
                    sParameterName = sURLVariables[i].split('=');

                    //alert(sParameterName[1]);
                    return sParameterName[1]+"="+sParameterName[2];

                    //if (sParameterName[0] === sParam) {
                    //    //return typeof sParameterName[1] === undefined ? true : decodeURIComponent(sParameterName[1]);
                    //    return typeof sParameterName[1]; //=== undefined ? true : decodeURIComponent(sParameterName[1]);
                    //}
                }
                return false;
            };



        });


    </script>




    <div class="m-grid m-grid--hor m-grid--root m-page">
        <div class="m-grid__item m-grid__item--fluid m-grid  m-error-6">
            <div class="m-error_container">
                <div>
                    <img src="<%= Page.ResolveClientUrl("~/assets/app/media/img/bg/Feedback_Thankyou.gif") %>" />
                    <br />
                    <br />
                    <h1>Thanks for your Feedback</h1>

                </div>
                <p>
                   <h2>Your feedback will help us serve you better.</h2>
                </p>
            </div>
        </div>
    </div>
</asp:Content>
