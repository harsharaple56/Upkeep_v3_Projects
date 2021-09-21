
$(document).ready(function () {

    $.ajax({
        type: 'GET',
        url: 'Ticketing.aspx/Fetch_Analyze_Tkt_Block1',
        data: {},
        async: false,
        cache: false,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            debugger;
            console.log(response);
        },
        error: function (xhr, status, error) {

            //alert(xhr.responseText);  // to see the error message
        }
    });
});