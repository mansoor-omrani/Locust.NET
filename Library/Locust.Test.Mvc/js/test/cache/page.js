$(function () {
    var messages = [];
    var messageDisplayTimeout = 5000;

    function Alert(type, message) {
        messages.push(Date.now());

        var id = messages.length;
        $('#divMessage').append("<div id='msg" + id + "' class='alert alert-" + type + " alert-dismissible'>" +
            "<a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>" +
            message + "</div>");
        
    }
    window.setInterval(function () {
        for (var i = 0; i < messages.length; i++) {
            if (messages[i] > 0 && Date.now() - messages[i] >= messageDisplayTimeout) {
                messages[i] = 0;
                $("#msg" + (i + 1)).fadeOut();
            }
        }
    }, 1000);

    function bindClick(config) {
        var _config = $.extend({
            btnId: "",
            url: "",
            msgSuccess: "",
            msgWarning: "",
            msgFail: "operation failed",
            fnCallback: function () { }
        }, config);

        

        $(_config.btnId).click(function () {
            var data;

            if (config) {
                try {
                    data = $.extend(JSON5.parse($("#txtValue").val()), {});
                } catch (e) {
                    console.log("parsing value failed");
                    console.log(e);
                }
            }

            _config.data = $.extend({
                id: $("#PageId").val(),
                key: $("#txtKey").val(),
                dependentKey: $("#txtDependentKey").val(),
                lifelength: $("#txtLifeLength").val() ? $("#txtLifeLength").val() : 0
            }, data);

            $.post({
                url: _config.url,
                data: _config.data
            }).done(function (result) {
                if (_config.fnCallback && typeof _config.fnCallback == "function") {
                    _config.fnCallback(result);
                }
                if (result.Success) {
                    if (_config.msgSuccess) {
                        Alert('success', _config.msgSuccess);
                    }
                } else {
                    if (_config.msgWarning) {
                        Alert('warning', _config.msgWarning + "<br/>" + result.Message);
                    } else {
                        Alert('warning', result.Message);
                    }
                }
            }).fail(function () {
                Alert('danger', _config.msgFail);
            });
        });
    }

    bindClick({
        btnId: "#btnAdd",
        url: "/test/cache/add",
        msgSuccess: 'Item added to cache',
        msgFail: 'Adding item failed.'
    });
    bindClick({
        btnId: "#btnRemove",
        url: "/test/cache/remove",
        msgSuccess: 'Item was removed from cache',
        msgFail: 'Removing item failed.'
    });
    bindClick({
        btnId: "#btnContains",
        url: "/test/cache/contains",
        msgSuccess: 'Item exists in the cache',
        msgWarning: 'Item does not exist in the cache',
        msgFail: 'checking item existence failed.'
    });
    bindClick({
        btnId: "#btnGet",
        url: "/test/cache/get",
        msgSuccess: '',
        msgWarning: 'Item does not exist in the cache',
        msgFail: 'Getting item failed.',
        fnCallback: function (result) {
            $("#txtValue").val(JSON5.stringify(result.Data, undefined, 3));
        }
    });
    bindClick({
        btnId: "#btnTryGet",
        url: "/test/cache/tryget",
        msgSuccess: '',
        msgWarning: 'Item does not exist in the cache or its dependent item has expired',
        msgFail: 'Trying to get item failed.',
        fnCallback: function (result) {
            $("#txtValue").val(JSON5.stringify(result.Data, undefined, 3));
        }
    });
    bindClick({
        btnId: "#btnGetItem",
        url: "/test/cache/getitem",
        msgSuccess: '',
        msgWarning: 'Item does not exist in the cache',
        msgFail: 'Getting item info failed.',
        fnCallback: function (result) {
            $("#txtValue").val(JSON5.stringify(result.Data, undefined, 3));
            $("#txtLifeLength").val(result.Data.LifeLength);
        }
    });
    bindClick({
        btnId: "#btnClean",
        url: "/test/cache/clean",
        msgSuccess: 'Cache cleaned (dead and expired items were removed from cache).',
        msgFail: 'Cleaning cache failed.',
        fnCallback: function (result) {
            $("#txtValue").val(JSON5.stringify(result.Data, undefined, 3));
        }
    });
    bindClick({
        btnId: "#btnClear",
        url: "/test/cache/clear",
        msgSuccess: 'Cache cleared and all its items were removed.',
        msgFail: 'Clearing cache failed.'
    });
    bindClick({
        btnId: "#btnCount",
        url: "/test/cache/count",
        msgFail: 'Getting the count of cached items failed.',
        fnCallback: function (result) {
            $("#txtValue").val("Total number of items in cache: " + result.Data);
        }
    });
    $("#btnReset").click(function () {
        $("#txtKey").val("");
        $("#txtLifeLength").val("");
        $("#txtDependentKey").val("");
        $("#txtValue").val("");
    });
})