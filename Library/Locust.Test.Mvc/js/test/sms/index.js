$(function () {
    $(".main-form").on("submit", function (e) {
        e.preventDefault();

        $.ajax({
            url: '/en/test/sms/send',
            method: 'POST',
            dataType: 'json',
            data: {
                Username: $("#Username").val(),
                Password: $("#Password").val(),
                Number: $("#Number").val(),
                targetNumber: $("#targetNumber").val(),
                Message: $("#Message").val(),
                SmsServiceType: $("#SmsServiceType").val()
            },
            success: function (r) {
                $("#my-modal h4.modal-title").html("Send SMS");
                if (r.Success) {
                    $("#my-modal div.modal-body").html("Send sms succeeded");
                } else {
                    var html = "Send sms failed<br/><b>Status: </b> " + r.Status + "<br/><b>Message: </b> " + r.Message + "<br/>";
                    if (r.Exception) {
                        html += "<b>Exception: </b> " + formatObject(r.Exception);
                    }
                    $("#my-modal div.modal-body").html(html);
                }
                $("#my-modal").modal();
            },
            fail: function (xhr, status, msg) {
                $("#my-modal h4.modal-title").html("Send SMS");
                var html = "There was a problem Sending sms: " + status;
                
                $("#my-modal div.modal-body").html(html);
                $("#my-modal").modal();
            }
        })
    });
})