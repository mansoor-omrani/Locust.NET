$(function () {
    $(".btn-check").click(function () {
        var btn = $(this);
        btn.parent().parent().find("td:nth-child(4)").html("");
        var provider = btn.parents("table")[0].id;
        var cnn = btn.parent().parent().find("td:nth-child(1)").text();

        $.ajax({
            url: '/en/test/dbconnection/check',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ "provider": provider, "cnn": cnn }),
            success: function (r) {
                if (r && r.Success) {
                    btn.parent().parent().find("td:nth-child(4)").html("<span class='glyphicon glyphicon-ok'> </span>");
                } else {
                    var icon = $("<a href='#' data-toggle='tooltip' title='" + r.Message + "'><span class='glyphicon glyphicon-warning-sign'> </span></a>");
                    btn.parent().parent().find("td:nth-child(4)").html(icon);
                    $(icon).tooltip();
                }
            },
            fail: function (xhr, status, msg) {
                var icon = $("<a href='#' data-toggle='tooltip' title='" + msg + "'><span class='glyphicon glyphicon-remove'> </span></a>");
                btn.parent().parent().find("td:nth-child(4)").html(icon);

                console.log(status);
            }
        })
    });

    $(".btn-manual-check").click(function () {
        var btn = $(this);
        $.ajax({
            url: '/en/test/dbconnection/manualcheck',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({
                datasource: $("#dataSource").val(),
                initialcatalog: $("#initialCatalog").val(),
                integratedSecurity: $("#integratedSecurity").val(),
                userId: $("#userId").val(),
                password: $("#password").val(),
            }),
            success: function (r) {
                if (r && r.Success) {
                    $("#manual-check-icon").html("<span class='glyphicon glyphicon-ok'> </span>");
                } else {
                    var icon = $("<a href='#' data-toggle='tooltip' title='" + r.Message + "'><span class='glyphicon glyphicon-warning-sign'> </span></a>");
                    $("#manual-check-icon").html(icon);
                    $(icon).tooltip();
                }
            },
            fail: function (xhr, status, msg) {
                var icon = $("<a href='#' data-toggle='tooltip' title='" + msg + "'><span class='glyphicon glyphicon-remove'> </span></a>");
                $("#manual-check-icon").html(icon);

                console.log(status);
            }
        })
    });
})