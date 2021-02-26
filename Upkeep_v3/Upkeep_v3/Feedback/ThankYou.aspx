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
            }, 3000);


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
                    <img src="<%= Page.ResolveClientUrl("~/assets/app/media/img/bg/coming-soon-9.gif") %>" />

                    <h1>Coming Soon...</h1>

                </div>
                <p>
                    This feature is under Development<br>
                    Your will be notified soon once its available for use.
                        <br />
                    <br />
                    <br />
                </p>
            </div>
        </div>
    </div>
</asp:Content>
