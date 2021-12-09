
$(document).ready(function () {
    LoadContentBasedOnViewport()
});

$(window).scroll(function () {
    LoadContentBasedOnViewport()
});

function LoadContentBasedOnViewport() {
    if (!$('#dvBlock1').hasClass('loaded')) {
        isBlock1Visible = isElementInViewport($('#dvBlock1'))
        if (isBlock1Visible) {
            $('#dvBlock1 .loader').removeClass('invisible')
            setTimeout(function myfunction() {
                Block1();
            }, 1000)
        }
    }
    if (!$('#dvBlock2').hasClass('loaded')) {
        isBlock2Visible = isElementInViewport($('#dvBlock2'))
        if (isBlock2Visible) {
            $('#dvBlock2 .loader').removeClass('invisible')
            //setTimeout(function myfunction() {
            Block2();
            //}, 1000)
        }
    }
    if (!$('#dvBlock3').hasClass('loaded')) {
        isBlock3Visible = isElementInViewport($('#dvBlock3'))
        if (isBlock3Visible) {
            $('#dvBlock3 .loader').removeClass('invisible')
            //setTimeout(function myfunction() {
            Block3();
            //   }, 1000)
        }
    }
    if (!$('#dvBlock4').hasClass('loaded')) {
        isBlock4Visible = isElementInViewport($('#dvBlock4'))
        if (isBlock4Visible) {
            $('#dvBlock4 .loader').removeClass('invisible')
            Block4();
        }
    }
    if (!$('#dvBlock5').hasClass('loaded')) {
        isBlock5Visible = isElementInViewport($('#dvBlock5'))
        if (isBlock5Visible) {
            $('#dvBlock5 .loader').removeClass('invisible')
            Block5();
        }
    }
    if (!$('#dvBlock6').hasClass('loaded')) {
        isBlock6Visible = isElementInViewport($('#dvBlock6'))
        if (isBlock6Visible) {
            $('#dvBlock6 .loader').removeClass('invisible')
            Block6();
        }
    }
    if (!$('#dvBlock7').hasClass('loaded')) {
        isBlock7Visible = isElementInViewport($('#dvBlock7'))
        if (isBlock7Visible) {
            $('#dvBlock7 .loader').removeClass('invisible')
            Block7();
        }
    }
}

function AfterContentLoad(blockID) {
    $('#' + blockID + ' .loader').addClass('invisible')
    $('#' + blockID + ' .m-portlet').removeClass('invisible')
    $('#' + blockID).addClass('loaded')
}

function Block1() {
    $.ajax({
        type: 'GET',
        url: 'Ticketing.aspx/Fetch_Analyze_Tkt_Block1',
        data: {},
        async: false,
        cache: false,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var dsTotalCount = JSON.parse(response.d)
            $('#totalCount').text(dsTotalCount["Table"][0].COUNT)
            $('#openTicket').text(dsTotalCount["Table1"][0].OPEN)
            $('#closedTicket').text(dsTotalCount["Table1"][0].CLOSED)
            $('#parkedTicket').text(dsTotalCount["Table1"][0].PARKED)
            $('#expiredTicket').text(dsTotalCount["Table1"][0].EXPIRED)

            AfterContentLoad('dvBlock1')
        },
        error: function (xhr, status, error) {
        }
    });

}

function Block2() {

    $.ajax({
        type: 'GET',
        url: 'Ticketing.aspx/Fetch_Analyze_Tkt_Block2',
        data: {},
        async: false,
        cache: false,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var dsBlock2 = JSON.parse(response.d).Table
            var design = '\n<div class="m-widget4__item" style="display: none">\n<div class="m-widget4__img m-widget4__img--pic">' +
                '\n<img src="##ProfilePic##" alt="">\n</div>\n<div class="m-widget4__info">\n<span class="m-widget4__title">##Name##' +
                '\n</span>\n<br>\n<span class="m-widget4__sub">##Designation##,<br>\n<b>##Department##</b>\n</span>\n</div>' +
                '\n<div class="m-widget4__progress">\n<div class="m-widget4__progress-wrapper">\n<span class="m-widget17__progress-number">##Pecent##%' +
                '</span>\n<span class="m-widget17__progress-label">Tickets</span>\n<div class="progress m-progress--sm">\n' +
                '<div class="progress-bar bg-danger h-100" role="progressbar" style="width: ##Pecent##%;" aria-valuenow="25" aria-valuemin="40" aria-valuemax="##Pecent##"></div>' +
                '\n</div>\n</div>\n</div>\n<div class="m-widget4__ext">\n<a href="##UserID##" class="m-btn m-btn--hover-brand m-btn--pill btn btn-sm btn-secondary">Profile</a>' +
                '\n</div>\n</div>\n\n';

            $('#appendBlock2Content').empty();
            var profileid = "View_User_Profile.aspx?ProfileID=";
            $(dsBlock2).each(function (i, e) {
                if (e.PROFILEPIC == "") {
                    e.PROFILEPIC = '/assets/app/media/img/users/user4.png';
                }
                else {
                    e.PROFILEPIC = e.PROFILEPIC;
                }
                var eachItem = design.replace('##Name##', e.NAME).replace('##ProfilePic##', e.PROFILEPIC).replace('##Designation##', e.DESIGNATION).replace('##Department##', e.DEPARTMENT).replace(/##Pecent##/g, e.TICKETPERCENT).replace('##UserID##', profileid + e.UserId).replace("display: none", "")
                $('#appendBlock2Content').append(eachItem);
            })

            AfterContentLoad('dvBlock2')
        },
        error: function (xhr, status, error) {
            //alert(xhr.responseText);  // to see the error message
        }
    });

}

function Block3() {
    $.ajax({
        type: 'GET',
        url: 'Ticketing.aspx/Fetch_Analyze_Tkt_Block3',
        data: {},
        async: false,
        cache: false,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var dsBlock3 = JSON.parse(response.d).Table
            $(dsBlock3).each(function (i, e) {
                $('#' + e.TICKETSTATUS + 'PerCount').text(e.TICKETPERCOUNT)
                $('#' + e.TICKETSTATUS + 'Percent').text(e.TICKETPERCENT + "%")
                $('#' + e.TICKETSTATUS + 'Progress').attr('style', 'width:' + e.TICKETPERCENT + '%');
            })

            AfterContentLoad('dvBlock3')
        },
        error: function (xhr, status, error) {

            //alert(xhr.responseText);  // to see the error message
        }
    });

}

function Block4() {
    if ($('#m_chart_sales_stats').length == 0) {
        return;
    }
    var labels = []
    var data = []
    $.ajax({
        type: 'GET',
        url: 'Ticketing.aspx/Fetch_Analyze_Tkt_Block4',
        data: {},
        async: false,
        cache: false,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var dsBlock4Stats = JSON.parse(response.d).Table
            $(dsBlock4Stats).each(function (i, e) {
                labels.push(e.MONTH)
                data.push(e.SALESTAT)
            })

            var dsBlock4Progress = JSON.parse(response.d).Table1

            $('#Block4OpenPer').text(dsBlock4Progress[0].OPEN + '%')
            $('#Block4OpenProgress').attr('style', 'width:' + dsBlock4Progress[0].OPEN + '%')
            $('#Block4ParkedPer').text(dsBlock4Progress[0].PARKED + '%')
            $('#Block4ParkedProgress').attr('style', 'width:' + dsBlock4Progress[0].PARKED + '%')
            $('#Block4ClosedPer').text(dsBlock4Progress[0].CLOSED + '%')
            $('#Block4ClosedProgress').attr('style', 'width:' + dsBlock4Progress[0].CLOSED + '%')
            $('#Block4ExpiredPer').text(dsBlock4Progress[0].EXPIRED + '%')
            $('#Block4ExpiredProgress').attr('style', 'width:' + dsBlock4Progress[0].EXPIRED + '%')

            AfterContentLoad('dvBlock4')
        },
        error: function (xhr, status, error) {

            //alert(xhr.responseText);  // to see the error message
        }
    });

    var config = {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: "Total Tickets",
                borderColor: mApp.getColor('brand'),
                borderWidth: 2,
                pointBackgroundColor: mApp.getColor('brand'),

                backgroundColor: mApp.getColor('accent'),

                pointHoverBackgroundColor: mApp.getColor('danger'),
                pointHoverBorderColor: Chart.helpers.color(mApp.getColor('danger')).alpha(0.2).rgbString(),
                data: data
            }]
        },
        options: {
            title: {
                display: false,
            },
            tooltips: {
                intersect: false,
                mode: 'nearest',
                xPadding: 10,
                yPadding: 10,
                caretPadding: 10
            },
            legend: {
                display: false,
                labels: {
                    usePointStyle: false
                }
            },
            responsive: true,
            maintainAspectRatio: false,
            hover: {
                mode: 'index'
            },
            scales: {
                xAxes: [{
                    display: false,
                    gridLines: false,
                    scaleLabel: {
                        display: true,
                        labelString: 'Month'
                    }
                }],
                yAxes: [{
                    display: false,
                    gridLines: false,
                    scaleLabel: {
                        display: true,
                        labelString: 'Value'
                    }
                }]
            },

            elements: {
                point: {
                    radius: 3,
                    borderWidth: 0,

                    hoverRadius: 8,
                    hoverBorderWidth: 2
                }
            }
        }
    };

    var chart = new Chart($('#m_chart_sales_stats'), config);
}

function Block5() {
    $.ajax({
        type: 'GET',
        url: 'Ticketing.aspx/Fetch_Analyze_Tkt_Block5',
        data: {},
        async: false,
        cache: false,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var dsBlock5 = JSON.parse(response.d).Table
            if (dsBlock5.length > 0) {
                var design = $('#appendBlock5Content').clone().html()
                $('#appendBlock5Content').empty()
                $(dsBlock5).each(function (i, e) {
                    var eachItem = design.replace('##DOWNTIME##', e.DOWNTIME).replace('##PRIORITY##', e.PRIORITY).replace(/##PERCENT##/g, e.PERCENT).replace("display: none", "")
                    if (e.PRIORITY == 'LOW' || e.PRIORITY == 'NOPRIORITY')
                        eachItem = eachItem.replace('m--bg-danger', 'm--bg-primary')

                    $('#appendBlock5Content').append(eachItem);
                })
            }
            else {
                $('#appendBlock5Content1').empty()
                $("#appendBlock5Content1").append("<center><h4 class='m-portlet__head-text'>No Records found..!</h4></center>");

            }

            AfterContentLoad('dvBlock5')
            //$(dsBlock3).each(function (i, e) {
            //    $('#' + e.TICKETSTATUS + 'PerCount').text(e.TICKETPERCOUNT)
            //    $('#' + e.TICKETSTATUS + 'Percent').text(e.TICKETPERCENT + "%")
            //    $('#' + e.TICKETSTATUS + 'Progress').attr('style', 'width:' + e.TICKETPERCENT + '%');
            //})

            //AfterContentLoad('dvBlock3')
        },
        error: function (xhr, status, error) {

            //alert(xhr.responseText);  // to see the error message
        }
    });

}

function Block6() {
    $.ajax({
        type: 'GET',
        url: 'Ticketing.aspx/Fetch_Analyze_Tkt_Block6',
        data: {},
        async: false,
        cache: false,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {

            var dsBlock6Tbl1 = JSON.parse(response.d).Table
            if (dsBlock6Tbl1.length > 0) {
                $('#dvBlock6 #ThisMonth tbody').empty()
                if (dsBlock6Tbl1.length > 4)
                    $('#dvBlock6 #ThisMonth').parent().addClass("within-scroll")


                $(dsBlock6Tbl1).each(function (i, e) {
                    $('#dvBlock6 #ThisMonth tbody').append("<tr><td><span class='m-widget11__title m--font-brand'>" + e.CATEGORY + "</span><span class='m-widget11__sub'>Total <b>" + e.TOTALTICKET + "</b> Tickets</span></td><td class='m--font-danger'>" + e.OPENTICKET + "</td><td class='m--font-warning'>" + e.PARKEDTICKET + "</td><td class='m--font-success'>" + e.CLOSEDTICKET + "</td><td class='m--align-right m--font-secondary'>" + e.TOTALTICKET + "</td></tr>")
                })
            }
            else {
                $('#appendBlock6Content1').empty()
                $("#appendBlock6Content1").append("<center><h4 class='m-portlet__head-text'>No Records found..!</h4></center>");
            }

            var dsBlock6Tbl2 = JSON.parse(response.d).Table1
            if (dsBlock6Tbl2.length > 0) {
                $('#dvBlock6 #LastMonth tbody').empty()
                if (dsBlock6Tbl2.length > 4)
                    $('#dvBlock6 #LastMonth').parent().addClass("within-scroll")

                $(dsBlock6Tbl2).each(function (i, e) {
                    $('#dvBlock6 #LastMonth tbody').append("<tr><td><span class='m-widget11__title m--font-brand'>" + e.CATEGORY + "</span><span class='m-widget11__sub'>Total <b>" + e.TOTALTICKET + "</b> Tickets</span></td><td class='m--font-danger'>" + e.OPENTICKET + "</td><td class='m--font-warning'>" + e.PARKEDTICKET + "</td><td class='m--font-success'>" + e.CLOSEDTICKET + "</td><td class='m--align-right m--font-secondary'>" + e.TOTALTICKET + "</td></tr>")
                })
            }
            else {
                $('#appendBlock6Content2').empty()
                $("#appendBlock6Content2").append("<center><h4 class='m-portlet__head-text'>No Records found..!</h4></center>");
            }

            AfterContentLoad('dvBlock6')

        },
        error: function (xhr, status, error) {

            //alert(xhr.responseText);  // to see the error message
        }
    });

}

function Block7() {
    $.ajax({
        type: 'GET',
        url: 'Ticketing.aspx/Fetch_Analyze_Tkt_Block7',
        data: {},
        async: false,
        cache: false,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var dsBlock7Tbl1 = JSON.parse(response.d).Table
            if (dsBlock7Tbl1.length > 0) {
                $('#dvBlock7 #ThisMonthDep tbody').empty()
                if (dsBlock7Tbl1.length > 4)
                    $('#dvBlock7 #ThisMonthDep').parent().addClass("within-scroll")


                $(dsBlock7Tbl1).each(function (i, e) {
                    $('#dvBlock7 #ThisMonthDep tbody').append("<tr><td><span class='m-widget11__title m--font-brand'>" + e.DEPARTMENT + "</span><span class='m-widget11__sub'>Total <b>" + e.TOTALTICKET + "</b> Tickets</span></td><td class='m--font-danger'>" + e.OPENTICKET + "</td><td class='m--font-warning'>" + e.PARKEDTICKET + "</td><td class='m--font-success'>" + e.CLOSEDTICKET + "</td><td class='m--align-right m--font-secondary'>" + e.TOTALTICKET + "</td></tr>")
                })
            }
            else {
                $('#appendBlock7Content1').empty()
                $("#appendBlock7Content1").append("<center><h4 class='m-portlet__head-text'>No Records found..!</h4></center>");
            }

            var dsBlock7Tbl2 = JSON.parse(response.d).Table1
            if (dsBlock7Tbl2.length > 0) {
                $('#dvBlock7 #LastMonthDep tbody').empty()
                if (dsBlock7Tbl2.length > 4)
                    $('#dvBlock7 #LastMonthDep').parent().addClass("within-scroll")

                $(dsBlock7Tbl2).each(function (i, e) {
                    $('#dvBlock7 #LastMonthDep tbody').append("<tr><td><span class='m-widget11__title m--font-brand'>" + e.DEPARTMENT + "</span><span class='m-widget11__sub'>Total <b>" + e.TOTALTICKET + "</b> Tickets</span></td><td class='m--font-danger'>" + e.OPENTICKET + "</td><td class='m--font-warning'>" + e.PARKEDTICKET + "</td><td class='m--font-success'>" + e.CLOSEDTICKET + "</td><td class='m--align-right m--font-secondary'>" + e.TOTALTICKET + "</td></tr>")
                })
            }
            else {
                $('#appendBlock7Content2').empty()
                $("#appendBlock7Content2").append("<center><h4 class='m-portlet__head-text'>No Records found..!</h4></center>");
            }

            AfterContentLoad('dvBlock7')

        },
        error: function (xhr, status, error) {

            //alert(xhr.responseText);  // to see the error message
        }
    });

}



///////////////////////////////
function isElementInViewport(el) {
    if (typeof jQuery === "function" && el instanceof jQuery) {
        el = el[0];
    }

    var rect = el.getBoundingClientRect();

    return (
        rect.top >= 0 &&
        rect.left >= 0 &&
        rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) && /* or $(window).height() */
        rect.right <= (window.innerWidth || document.documentElement.clientWidth) /* or $(window).width() */
    );
}

