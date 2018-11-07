$(function () {
    $("#btnLoad").click(function () {
        $.ajax({
            url: "/test/translation/load",
            method: "get"
        }).always(function () {
            $("#my-modal h4.modal-title").html("Translation:Load");
            $("#my-modal div.modal-body").html("Done");
            $("#my-modal").modal();
        });
    });
})