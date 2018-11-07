$(function () {
    $(".main-form").on("submit", function (e) {
        e.preventDefault();

        $.ajax({
            url: '/en/test/mail/send',
            method: 'POST',
            dataType: 'json',
            data: {
                Username: $("#Username").val(),
                Password: $("#Password").val(),
                Host: $("#Host").val(),
                DefaultMail: $("#DefaultMail").val(),
                Port: $("#Port").val(),
                UseDefaultCredentials: ($("#UseDefaultCredentials:checked").val() == "true" ? true : false),
                EnableSSL: ($("#EnableSSL:checked").val() == "true" ? true : false),
                IsHtml: ($("#IsHtml:checked").val() == "true" ? true : false),
                To: $("#To").val(),
                Subject: $("#Subject").val(),
                Body: $("#Body").val(),
                MailManagerType: $("#MailManagerType").val()
            },
            success: function (r) {
                $("#my-modal h4.modal-title").html("Send Mail");
                if (r.Success) {
                    $("#my-modal div.modal-body").html("Send mail succeeded");
                } else {
                    var html = "Send mail failed<br/><b>Status: </b> " + r.Status + "<br/><b>Message: </b> " + r.Message + "<br/>";
                    if (r.Exception) {
                        html += "<b>Exception: </b> " + formatObject(r.Exception);
                    }
                    $("#my-modal div.modal-body").html(html);
                }
                $("#my-modal").modal();
            },
            fail: function (xhr, status, msg) {
                $("#my-modal h4.modal-title").html("Send Mail");
                var html = "There was a problem Sending mail: " + status;
                
                $("#my-modal div.modal-body").html(html);
                $("#my-modal").modal();
            }
        })
    });
})