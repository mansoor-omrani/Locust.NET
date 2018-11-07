$(function () {
    $("#fsSMS").hide();
    $("#fsEmail").hide();

    $("#NotifyType").change(function () {
        var notifyType = $("#NotifyType").val();
        if (notifyType == "SMS") {
            $("#fsSMS").show();
            $("#fsEmail").hide();
        } else if (notifyType == "Email") {
            $("#fsSMS").hide();
            $("#fsEmail").show();
        }
    });

    $(".main-form").on("submit", function (e) {
        e.preventDefault();

        $.ajax({
            url: '/en/test/notification/send',
            method: "POST",
            dataType: "json",
            data: {
                NotifyType: $("#NotifyType").val(),
                targetNumber: $("#targetNumber").val(),
                Message: $("#Message").val(),
                IsHtml: ($("#IsHtml:checked").val() == "true" ? true : false),
                To: $("#To").val(),
                Subject: $("#Subject").val(),
                Body: $("#Body").val()
            }
        }).done(function (r) {
            $("#my-modal h4.modal-title").html("Send Notification");
            if (r.Success) {
                var html = "Send notification succeeded";
                if (r.Data) {
                    html += "<br/><br/>" + formatObject(r.Data);
                }
                $("#my-modal div.modal-body").html(html);
            } else {
                var html = "Send notification failed<br/><b>Status: </b> " + r.Status + "<br/><b>Message: </b> " + r.Message + "<br/>";
                if (r.Exception) {
                    html += "<b>Exception: </b> " + formatObject(r.Exception);
                }
                $("#my-modal div.modal-body").html(html);
            }
            $("#my-modal").modal();
        }).fail(function (xhr, status, msg) {
            $("#my-modal h4.modal-title").html("Send Notification");
            var html = "There was a problem sending notification: " + status;

            $("#my-modal div.modal-body").html(html);
            $("#my-modal").modal();
        });
    });
})