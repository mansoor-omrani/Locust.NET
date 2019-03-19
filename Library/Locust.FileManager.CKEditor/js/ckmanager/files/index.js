$(function () {
    var app = {
        lang: {},
        translator: {}
    };

    app.lang = Locust.Language.Current;

    app.translator = new Locust.Translation.TranslatorProxy({ basePath: "/" + app.lang.shortName + "/localization", cit: ["ckmanager-en", "ckmanager-fa"] });
    app.translator.load().done(function () {
        localizePage();
    });
    function getUrlParam( paramName ) {
        var reParam = new RegExp( '(?:[\?&]|&)' + paramName + '=([^&]+)', 'i' );
        var match = window.location.search.match( reParam );

        return ( match && match.length > 1 ) ? match[1] : null;
    }
    function getHash() {
        var result = {
            path: "",
            displayType: "",
            sort: "",
            sortdir: 0,
            search: ""
        };

        var hash = window.location.hash;

        if (hash && hash.length > 1) {
            var arr = hash.substr(1).split("&");

            for (var i = 0; i < arr.length; i++) {
                if (arr[i]) {
                    var eqIndex = arr[i].indexOf("=");
                    if (eqIndex > 0) {
                        var key = arr[i].substr(0, eqIndex);
                        var value = arr[i].substr(eqIndex + 1);

                        if (key && value) {
                            switch (key.toLowerCase()) {
                                case "path": result.path = decodeURI(value); break;
                                case "displaytype": result.displayType = value; break;
                                case "sort": result.sort = value; break;
                                case "sortdir": result.sortdir = value; break;
                                case "search": result.search = decodeURI(value); break;
                            }
                        }
                    }
                }
            }
        }

        if (!(result.displayType == "List" || result.displayType == "Table" || result.displayType == "Thumbnail")) {
            result.displayType = "List";
        }

        return result;
    };
    function updateHash() {
        var _hash = "";

        _hash += "path=" + encodeURI(currentPath);

        var displayType = $("#selDisplayType").val();
        if (displayType) {
            _hash += "&displayType=" + displayType;
        }

        var sort = $("#selSortBy").val();
        if (sort) {
            _hash += "&sort=" + sort;
        }

        var sortdir = $("input[name=rdSortDir]:checked").val();
        if (sortdir) {
            _hash += "&sortdir=" + sortdir;
        }

        var search = $("#txtSearch").val();
        if (search) {
            _hash += "&search=" + encodeURI(search);
        }

        window.location.hash = _hash;
    }
    function prepareText(text) {
        return "<div dir='" + app.lang.dir + "'>" + text + "</div>";
    }
    function showMessage(config) {
        var message = "";
        var title = prepareText(config.title);

        if (config.response) {
            message += config.response.Message;

            if (config.response.InnerResponses && config.response.InnerResponses.length) {
                var innerMessages = "";

                $(config.response.InnerResponses).each(function (i, x) {
                    innerMessages += x.Message + "<br/>";
                });

                innerMessages = prepareText(innerMessages);
                message += "&nbsp;&nbsp;<a href=\"javascript:BootstrapDialog.show({ title: &quot;" + config.title +
                                                                                          "&quot;, type: BootstrapDialog.TYPE_INFO, message: &quot;" + innerMessages + "&quot; });\">" + (app.lang.shortName == "en" ? "more" : "جزئیات") + "</a>";
            }
        } else {
            message += config.message;
        }

        message = prepareText(message);

        var modal = BootstrapDialog.show({ title: title, type: config.type, message: message });

        correctModalHeader(modal);
    }
    function correctModalHeader(modal) {
        modal.getModalHeader().css("direction", app.lang.dir);
        modal.getModalHeader().find(".bootstrap-dialog-close-button").css("margin-" + app.lang.altAlign, "10px");
    }
    function getText(key, value, defaultValue, args) {
        var r = app.translator.getSingle(key, value, app.lang.shortName);

        if (!r) {
            r = defaultValue;
        }

        if (args && r.format) {
            r = r.format(args);
        }

        return r;
    };
    function localizePage() {

    };

    var _1KB = 1024;
    var _1MB = _1KB * 1024;
    var _1GB = _1MB * 1024;

    var API_ROOT = "/" + app.lang.shortName + "/ckmanager";
    var datatable = null;
    var _original_files = null;
    var _files = [];
    var selectedFile = -1;

    var hash = getHash();
    var currentPath = hash.path;
    var uploader;

    if (!currentPath) {
        currentPath = "/";
    }

    if (hash.displayType) {
        $("#selDisplayType").val(hash.displayType);
    }

    if (hash.sort) {
        $("#selSortBy").val(hash.sort);
    }

    $("input[name=rdSortDir][value=" + hash.sortdir + "]").prop("checked", true);

    if (hash.search) {
        $("#txtSearch").val(hash.search);
    }

    function getFiles(path) {
        var d = $.Deferred();

        $.post(API_ROOT + "/files/list", { "path": path }).done(function (r) {
            if (!r.Success) {
                showMessage({ title: getText("CKManager", "titleFiles", "Files"), response: r, type: BootstrapDialog.TYPE_WARNING });
                d.reject();
            } else {
                d.resolve(r.Data);
            }
        }).fail(function (xhr, txt, msg) {
            var message = getText("CKManager", "msgServerOrInternetProblem", "Server or Connection problem. Try again later");
            showMessage({ title: getText("CKManager", "titleFiles", "Files"), message: message, type: BootstrapDialog.TYPE_DANGER });
            console.log(txt, msg);
            d.reject();
        });

        return d.promise();
    }
    function getSubDirs(path) {
        var d = $.Deferred();

        $.post(API_ROOT + "/folders", { "path": path }).done(function (r) {
            if (!r.Success) {
                showMessage({ title: getText("CKManager", "titleFolders", "Folders"), response: r, type: BootstrapDialog.TYPE_WARNING });
                d.reject();
            } else {
                d.resolve(r.Data);
            }
        }).fail(function (xhr, txt, msg) {
            var message = getText("CKManager", "msgServerOrInternetProblem", "Server or Connection problem. Try again later");
            showMessage({ title: getText("CKManager", "titleFolders", "Folders"), message: message, type: BootstrapDialog.TYPE_DANGER });
            console.log(txt, msg);
            d.reject();
        });

        return d.promise();
    }
    function showFolders(data) {
        $(".dirs ul").empty();

        var html = "";

        if (currentPath != "/") {
            html = "<li><a href='#'>..</a></option>";
        }

        $(data).each(function (i, x) {
            var p = x.replace(currentPath, "");
            if (p.length && p[0] == '/') {
                p = p.substr(1);
            }
            html += "<li><a href='#'>" + htmlEncode(p) + "</a></option>";
        });

        $(".dirs ul").html(html);

        $(".dirs ul li a").click(getFoldersAndFiles);
    }
    function fileSize(size) {
        var result = "";

        if (size < _1KB) {
            result = size + " bytes";
        } else if (size >= _1KB && size < _1MB) {
            result = Math.roundBy(size / _1KB, 2) + " KB";
        } else if (size >= _1MB && size < _1GB) {
            result = Math.roundBy(size / _1MB, 2) + " MB";
        } else {
            result = Math.roundBy(size / _1GB, 2) + " GB";
        }
        return result;
    }

    function deleteSelectedFiles() {
        var title = getText("CKManager", "titleDeleteFiles", "Delete File(s)");
        title = prepareText(title);

        var msgDeleteFileNoSelection = getText("CKManager", "msgDeleteFileNoSelection", "Please select one or more files.");
        msgDeleteFileNoSelection = prepareText(msgDeleteFileNoSelection);

        if ($(".file-checkbox:checked").length > 0) {
            var paths = [];

            $(".file-checkbox:checked").each(function () {
                var i = $(this).val();
                var path = _files[i].Name;
                paths.push(getPath(path));
            });

            var msgDeleteConfirm = getText("CKManager", "msgDeleteFileConfirm", "Are you sure to delete {n} file(s)?", { n: paths.length });
            msgDeleteConfirm = prepareText(msgDeleteConfirm);

            var msgDeleteFileProblem = getText("CKManager", "msgDeleteFileProblem", "Cannot delete file(s) now due to internet connection or server problem.");
            msgDeleteFileProblem = prepareText(msgDeleteFileProblem);

            var modal = BootstrapDialog.confirm({
                title: title,
                message: msgDeleteConfirm,
                closable: true,
                cssClass: 'myclass',
                type: BootstrapDialog.TYPE_WARNING,
                btnCancelLabel: getText("CKManager", "btnCancel", "Cancel"),
                btnOKLabel: getText("CKManager", "btnYes", "Yes"),
                callback: function (result) {
                    if (result) {
                        $.ajax({
                            url: API_ROOT + "/files/delete",
                            type: "POST",
                            data: { paths: paths },
                            dataType: "json",
                            traditional: true
                        }).done(function (r) {
                            if (r.Success) {
                                getFoldersAndFiles();

                                showMessage({ title: title, type: BootstrapDialog.TYPE_SUCCESS, response: r });
                            } else {
                                showMessage({ title: title, type: BootstrapDialog.TYPE_DANGER, response: r });
                            }
                        }).fail(function (xhr, text) {
                            showMessage({ title: title, type: BootstrapDialog.TYPE_WARNING, message: msgDeleteFileProblem });
                        });
                    }
                }
            });

            correctModalHeader(modal);
        } else {
            showMessage({ title: title, type: BootstrapDialog.TYPE_INFO, message: msgDeleteFileNoSelection });
        }
    }
    function renameSelectedFile() {
        var msgRenameFile = getText("CKManager", "msgRenameFile", "Enter new name");

        var title = getText("CKManager", "titleRenameFile", "Rename File");
        title = prepareText(title);

        var msgRenameFileProblem = getText("CKManager", "msgRenameFileProblem", "Cannot rename file now due to internet connection or server problem.");
        msgRenameFileProblem = prepareText(msgRenameFileProblem);

        if (selectedFile >= 0) {
            var modal = BootstrapDialog.show({
                title: title,
                message: prepareText(msgRenameFile + " <input type='text' class='form-control' dir='ltr' value='" + _files[selectedFile].Name + "'/>"),
                buttons: [{
                    label: getText("CKManager", "btnYes", "Yes"),
                    cssClass: 'btn-primary',
                    action: function (dialogRef) {
                        var newname = dialogRef.getModalBody().find('input').val();

                        $.post(API_ROOT + "/files/rename", { path: getPath(_files[selectedFile].Name), newname: newname }).done(function (r) {
                            if (r.Success) {
                                _files[selectedFile].Name = newname;

                                showFiles(_files);
                            } else {
                                showMessage({ title: title, type: BootstrapDialog.TYPE_DANGER, response: r });
                            }

                            dialogRef.close();
                        }).fail(function (xhr, text) {
                            showMessage({ title: title, type: BootstrapDialog.TYPE_WARNING, message: msgRenameFileProblem });

                            dialogRef.close();
                        });
                    }
                }, {
                    label: getText("CKManager", "btnCancel", "Cancel"),
                    action: function (dialogRef) {
                        dialogRef.close();
                    }
                }]
            });

            correctModalHeader(modal);
        }
    }
    function isImage(extension) {
        if (extension) {
            if (extension[0] == '.') {
                extension = extension.substring(1);
            }

            var imgExtensions = ["jpg", "jpeg", "png", "gif", "bmp", "tga"];

            return imgExtensions.find(function (e) { return e == extension; }) != undefined;
        }

        return false;
    }
    function showFilesAsTable() {
        $("#files").html("<table id='files-table' class='table table-striped table-bordered' width='100%'></table>");
        datatable = $('#files-table').DataTable({
            data: _files.map(function (f) {
                var result = [];
                result.push(f.Name);
                result.push(f.Extension);
                result.push(f.CreationTime);
                result.push(f.LastAccessTime);
                result.push(f.Size);
                return result;
            }),
            columns: [
                { title: "Name" },
                { title: "Extension" },
                { title: "CreationTime", type: "date" },
                { title: "LastAccessTime", type: "date" },
                { title: "Size" }
            ],
            searching: false
        });

        $('#files-table').on('draw.dt', function () {
            $("#files tr.success").removeClass("success");

            var paging = datatable.page.info();

            if (selectedFile >= paging.start && selectedFile < paging.end) {
                $("#files tr:nth-child(" + ((selectedFile % paging.length) + 1) + ")").addClass("success");
            }
        });

        $('#files tbody').on('click', 'tr', function () {
            $("#files tr.success").removeClass("success");

            $(this).addClass("success");

            selectedFile = datatable.row(this).index();
            $("#btnRenameFile").prop("disabled", false);
        });
    }
    function showFilesAsList() {
        var html = "<div class='row'>";

        $(_files).each(function (i, f) {
            html += "<div class='col-md-3 col-sm-4 col-xs-6 file filename' id='f" + i + "' data-tooltip-content='#tt" + i + "'>" +
                        "<div align='" + app.lang.align + "'>" +
                        (
                            (app.lang.dir == "ltr") ?
                                ("<input type='checkbox' name='chkFile' class='file-checkbox' value='" + i + "' />&nbsp;" + f.Name) :
                                (f.Name + "&nbsp;<input type='checkbox' name='chkFile' class='file-checkbox' value='" + i + "' />")
                        ) +
                        "</div>" +
                    "</div>" +
                    "<div class='ttts'>" +
                        "<span id='tt" + i + "'>" +
                            "<b>Filename:</b> " + f.Name + "<br/>" +
                            "<b>Size:</b> " + fileSize(f.Size) + "<br/>" +
                            "<b>CreationTime:</b> " + f.CreationTime + "<br/>" +
                        "</span>" +
                    "</div>"
        });

        html += "</div>";

        $("#files").html(html);

        $('.file').tooltipster({
            theme: 'tooltipster-noir',
            animation: 'fade',
            arrow: true,
            side: 'top'
        });

        $(".file").mouseover(function () { $(this).addClass("over"); });
        $(".file").mouseout(function () { $(this).removeClass("over"); });

        $(".file").click(function () {
            if (selectedFile) {
                $("#f" + selectedFile).removeClass("success");
            }

            $(this).addClass("success");

            selectedFile = $(this).attr("id").replace("f", "");
            $("#btnRenameFile").prop("disabled", false);
        });
    }
    function showFilesAsThumbnail() {
        var basePath = $("#baseFilesPath").val();
        var html = "<div class='row' id='gallery'>";

        $(_files).each(function (i, f) {
            if (isImage(f.Extension)) {
                var _path = basePath + (f.Path == "/" ? "/" : f.Path + "/") + f.Name;
                html += "<div class='col-xs-2 file' id='f" + i + "' data-tooltip-content='#tt" + i + "'>" +
                            "<div class='filename' align='" + app.lang.align + "'>" +
                                ("<a href='" + _path + "' class='mag-pop'><img src='" + _path + "' class='img-responsive'/></a>") +
                                (
                                    (app.lang.dir == "ltr") ?
                                        ("<input type='checkbox' name='chkFile' class='file-checkbox' value='" + i + "' />&nbsp;" + f.Name) :
                                        (f.Name + "&nbsp;<input type='checkbox' name='chkFile' class='file-checkbox' value='" + i + "' />")
                                ) +
                            "</div>" +
                        "</div>" +
                        "<div class='ttts'>" +
                            "<span id='tt" + i + "'>" +
                                "<b>Filename:</b> " + f.Name + "<br/>" +
                                "<b>Size:</b> " + fileSize(f.Size) + "<br/>" +
                                "<b>CreationTime:</b> " + f.CreationTime + "<br/>" +
                            "</span>" +
                        "</div>";
            } else {
                html += "<div class='col-xs-2 file' id='f" + i + "' data-tooltip-content='#tt" + i + "'>" +
                            "<div class='filename' align='" + app.lang.align + "'>" +
                                "<img src=\"/ckmanager/files/icon/?type=" + f.Extension + "\" class='img-responsive'>" +
                                (
                                    (app.lang.dir == "ltr") ?
                                        ("<input type='checkbox' name='chkFile' class='file-checkbox' value='" + i + "' />&nbsp;" + f.Name) :
                                        (f.Name + "&nbsp;<input type='checkbox' name='chkFile' class='file-checkbox' value='" + i + "' />")
                                ) +
                            "</div>" +
                        "</div>" +
                        "<div class='ttts'>" +
                            "<span id='tt" + i + "'>" +
                                "<b>Filename:</b> " + f.Name + "<br/>" +
                                "<b>Size:</b> " + fileSize(f.Size) + "<br/>" +
                                "<b>CreationTime:</b> " + f.CreationTime + "<br/>" +
                            "</span>" +
                        "</div>";
            }
        });

        html += "</div>";

        $("#files").html(html);

        $('.file').tooltipster({
            theme: 'tooltipster-noir',
            animation: 'fade',
            arrow: true,
            side: 'right'
        });

        $(".file").mouseover(function () { $(this).addClass("over"); });
        $(".file").mouseout(function () { $(this).removeClass("over"); });

        $(".file").click(function () {
            if (selectedFile >= 0) {
                $("#f" + selectedFile).removeClass("success");
            }

            $(this).addClass("success");

            selectedFile = $(this).attr("id").replace("f", "");

            $("#btnRenameFile").prop("disabled", false);
        });

        function initGallery(selector) {
            $(selector).click(function (e) { e.preventDefault(); });

            $(selector).dblclick(function (e) {
                e.preventDefault();

                $(selector).magnificPopup({
                    type: 'image',
                    gallery: { enabled: true },
                    callbacks: {
                        close: function () {
                            $(selector).unbind("click");
                            $(selector).click(function (e) { e.preventDefault(); });
                        }
                    }
                });

                $(selector).magnificPopup('open');
                $(selector).magnificPopup('goTo', $(selector).index(this));
            });
        }

        initGallery(".mag-pop");
    }
    function showFiles(data) {
        $("#files").empty();
        selectedFile = -1;
        $("#btnRenameFile").prop("disabled", true);

        _files = data;

        if (!_original_files) {
            _original_files = data;
        }

        var displayType = $("#selDisplayType").val();

        switch (displayType) {
            case "Table":
                showFilesAsTable();
                break;
            case "List":
                showFilesAsList();
                break;
            case "Thumbnail":
                showFilesAsThumbnail();
                break;
        }
    }
    function getPath(path) {
        var result = "";

        if (!currentPath || currentPath == "/") {
            if (path) {
                if (path[0] == '/') {
                    result = path;
                } else {
                    result = "/" + path;
                }
            } else {
                result = "/";
            }
        } else {
            if (path) {
                if (path[0] == '/') {
                    result = currentPath + path;
                } else {
                    result = currentPath + "/" + path;
                }
            } else {
                result = currentPath;
            }
        }

        return result;
    }
    function updatePath(a) {
        var result = currentPath;
        var path = $(a).text();

        if (path == "..") {
            var i = result.lastIndexOf('/');

            if (i > 0) {
                result = result.substring(0, i);
            } else {
                result = "/";
            }
        } else {
            result += (result == "/" ? "" : "/") + path;
        }

        return result;
    }
    function getFoldersAndFiles(e) {
        var path = currentPath;
        if (e) {
            e.preventDefault();
            path = updatePath(this);
        }

        _original_files = null;

        getSubDirs(path).done(function (data) {
            currentPath = path;
            updateHash();
            showFolders(data);
            getFiles(path).done(showFiles);
        });
    }

    $("#selDisplayType").change(function () {
        datatable = null;

        $("#txtSearch").val("");
        _files = _original_files;

        showFiles(_files);

        updateHash();
    });

    function sortFiles() {
        var sort = $("#selSortBy").val();
        var sort_dir = $("input[name=rdSortDir]:checked").val();

        _files.sort(function (f1, f2) {
            if (f1[sort] == f2[sort]) return 0;
            if (f1[sort] < f2[sort]) return (sort_dir == "1" ? -1 : 1);
            return (sort_dir == "1" ? 1 : -1);
        });

        showFiles(_files);

        updateHash();
    }

    $("input[name=rdSortDir]").click(sortFiles);
    $("#selSortBy").change(sortFiles);

    $("#btnUpload").click(function () {
        var config = {
            url: API_ROOT + "/files/pupload"
            //,max_file_size: '2mb'
            , multipart_params: {
                path: currentPath
            }
            //,filters: [
            //    { title: "Image files", extensions: "jpg,gif,png" },
            //    { title: "Zip files", extensions: "zip,avi" }
            //]
            , rename: true
            , sortable: true
            , dragdrop: true
            , views: {
                list: true,
                thumbs: true, // Show thumbs
                active: 'list'
            }
            , init: {
                PostInit: function (u) {
                    uploader = u;
                },
                FilesAdded: function (up, files) {
                    $(files).each(function (i, file) {
                        $.post(API_ROOT + "/files/exists", { "path": currentPath + "/" + file.name }).done(function (r) {
                            if (r.Success) {
                                BootstrapDialog.confirm({
                                    title: "Adding files to Upload Queue",
                                    message: "File " + file.name + " exists on the server. Overwrite?",
                                    closable: true,
                                    type: BootstrapDialog.TYPE_WARNING,
                                    callback: function (result) {
                                        if (!result) {
                                            up.removeFile(file);
                                        }
                                    }
                                });
                            } else {
                                if (up.files.filter(function (f) { return f.name == file.name }).length > 1) {
                                    BootstrapDialog.show({
                                        title: "Adding files to Upload Queue",
                                        message: "File already exists in the queue"
                                    });

                                    up.removeFile(file);
                                }
                            }
                        }).fail(function () {
                            BootstrapDialog.show({
                                title: 'Upload files',
                                message: 'Checking ' + file.name + " existence failed. Upload might not be succesful."
                            });
                        });
                    });
                },
                BeforeUpload: function (up, file) {
                    up.setOption("multipart_params", {
                        path: currentPath
                    });
                    up.setOption("params", {
                        path: currentPath
                    });
                },
                FileUploaded: function (up, file, res) {
                    try {
                        var result = JSON.parse(res.response);
                        if (result.Success) {
                            up.removeFile(file);
                        }
                        //BootstrapDialog.show({ title: 'Upload files', message: result.Message });
                    } catch (e) {
                        console.log(e);
                    }
                }
            }
        };

        if (!uploader) {
            config.runtimes = 'html5,flash,html4';
            config.flash_swf_url = 'https://cdnjs.cloudflare.com/ajax/libs/plupload/3.1.2/Moxie.swf';

            $("#upload-modal div.modal-body").plupload(config);
        }

        $("#upload-modal h4.modal-title").html("Upload");

        $("#upload-modal").modal({
            show: true,
            keyboard: false,
            backdrop: 'static'
        });

        $("#upload-modal").on("hidden.bs.modal", function () {
            getFiles(currentPath).done(showFiles);
        });
    });
    $("#btnOk").click(function () {
        var title = getText("CKManager", "titleFileSelector", "File Selector");
        title = prepareText(title);

        if (selectedFile >= 0) {
            var basePath = $("#baseFilesPath").val();
            var f = _files[selectedFile];
            var _path = (basePath + (f.Path == "/" ? "/" : f.Path + "/") + f.Name).replaceAll("//", "/").replaceAll("\\\\", "/");

            if (getUrlParam('CKEditor')) {
                var funcNum = getUrlParam('CKEditorFuncNum');
                funcNum = decodeURIComponent(funcNum);

                if (!window.opener) {
                    showMessage({ type: BootstrapDialog.TYPE_WARNING, title: title, message: "Parent window not found." });
                } else if (!window.opener.CKEDITOR) {
                    showMessage({ type: BootstrapDialog.TYPE_WARNING, title: title, message: "CKEditor not found in parent window." });
                } else {
                    window.opener.CKEDITOR.tools.callFunction(funcNum, _path);
                    window.close();
                }
            } else {
                if (!window.opener) {
                    showMessage({ type: BootstrapDialog.TYPE_WARNING, title: title, message: "Parent window not found." });
                } else if (!window.opener.Locust) {
                    showMessage({ type: BootstrapDialog.TYPE_WARNING, title: title, message: "Locust not found in parent window." });
                } else if (!window.opener.Locust.FileManager) {
                    showMessage({ type: BootstrapDialog.TYPE_WARNING, title: title, message: "Locust.FileManager not found in parent window." });
                } else {
                    var field = getUrlParam('fmfield');
                    field = decodeURIComponent(field);

                    var form = getUrlParam('fmform');
                    form = decodeURIComponent(form);

                    window.opener.Locust.FileManager.callFunction(_path, field, form);
                    window.close();
                }
            }
        } else {
            var msgPleaseSelectAFile = getText("CKManager", "msgPleaseSelectAFile", "Please select a file.");
            msgPleaseSelectAFile = prepareText(msgPleaseSelectAFile);
            
            showMessage({ type: BootstrapDialog.TYPE_WARNING, title: title, message: msgPleaseSelectAFile });
        }
    });
    $("#btnReturn").click(function () { window.close(); });
    $("#txtSearch").keyup(function () {
        var search = $(this).val();

        if (!search) {
            _files = _original_files;
            showFiles(_files);
        } else {
            _files = _files.filter(function (f) { return f.Name.indexOf(search) >= 0 });
            showFiles(_files);
        }
    });

    $("#btnDeleteFiles").click(deleteSelectedFiles);
    $("#btnRenameFile").click(renameSelectedFile);

    getFoldersAndFiles();
})