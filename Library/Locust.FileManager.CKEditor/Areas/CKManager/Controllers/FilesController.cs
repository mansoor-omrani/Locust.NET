using Locust.Extensions;
using Locust.FileManager.Client;
using Locust.Logging;
using Locust.Mime;
using Locust.MvcAttributes;
using Locust.Notification;
using Locust.Service;
using Locust.Translation;
using Locust.WebExtensions;
using Locust.WebTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.FileManager.CKEditor.Areas.CKManager.Controllers
{
    public class FileInfoSummary
    {
        public string Extension { get; set; }
        public long Size { get; set; }
        public string Path { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastAccessTime { get; set; }
        public string Name { get; set; }
        public FileInfoSummary()
        {

        }
        public FileInfoSummary(FileInfo fi)
        {
            if (fi != null)
            {
                Extension = fi.Extension;
                Size = fi.Size;
                Path = fi.Path;
                CreationTime = fi.CreationTime;
                LastAccessTime = fi.LastAccessTime;
                Name = fi.Name;
            }
        }
    }
    public class FilesController: CKManagerBaseController
    {
        public FilesController(IFileManagerClient client,
                                ITranslator translator,
                                ILogger logger,
                                IExceptionLogger exceptionLogger,
                                INotificationService notification) : base(client, translator, logger, exceptionLogger, notification)
        {

        }
        public ActionResult Index(string type, string CKEditor, string CKEditorFuncNum, string langCode)
        {
            ViewBag.Type = type;
            ViewBag.CKEditor = CKEditor;
            ViewBag.CKEditorFuncNum = CKEditorFuncNum;
            ViewBag.langCode = langCode;
            ViewBag.BaseFilesPath = (client.FileManager.Root + client.FileManager.BasePath).Replace("\\", "/");

            return View();
        }
        
        [HttpPost]
        [JsonAuthorize]
        public async Task<ActionResult> Exists(string path)
        {
            var result = await client.FileExistsAsync(path);

            return await SendJsonAsync(result, new { Path = path }, "error checking file existence");
        }
        [HttpPost]
        [JsonAuthorize]
        public async Task<ActionResult> Delete(string[] paths)
        {
            var result = await client.DeleteFilesAsync(paths);

            return await SendJsonAsync(result, new { Path = paths }, "error deleting file(s)");
        }
        [HttpPost]
        [JsonAuthorize]
        public async Task<ActionResult> Move(string path, string newPath)
        {
            var result = await client.MoveFileAsync(path, newPath);

            return await SendJsonAsync(result, new { Path = path, NewPath = newPath }, "error moving file");
        }
        [HttpPost]
        [JsonAuthorize]
        public async Task<ActionResult> Rename(string path, string newname)
        {
            var result = await client.RenameFileAsync(path, newname);

            return await SendJsonAsync(result, new { Path = path, NewName = newname }, "error renaming file");
        }
        [HttpPost]
        [JsonAuthorize]
        public async Task<ActionResult> List(string path)
        {
            var result = new ServiceResponse<List<FileInfoSummary>>();
            var sr = await client.FileInfosAsync(path);
            
            if (sr.Success)
            {
                var query = sr.Data as IEnumerable<FileInfo>;

                result.Data = query.Select(fi => new FileInfoSummary(fi)).ToList();
            }

            (result as ServiceResponse).Copy(sr);

            if (result.Data == null)
            {
                result.Data = new List<FileInfoSummary>();
            }
            
            return await SendJsonAsync(result, new { Path = path }, "error getting list of files", true);
        }
        [HttpPost]
        [JsonAuthorize]
        public async Task<ActionResult> Upload(string CKEditorFuncNum, string CKEditor, string langCode, string ckCsrfToken)
        {
            var message = "";
            var filename = "";
            var uploaded = 0;
            var url = "";
            var result = null as object;

            if (Request.Cookies["ckCsrfToken"].Value == ckCsrfToken)
            {
                if (Request.Files.Count > 0)
                {
                    filename = Request.Files[0].FileName;
                    var path = "/";
                    var r = await client.SaveFileAsync(path, Request.Files[0], false);
                    url = (client.FileManager.Root + client.FileManager.BasePath + path + Request.Files[0].FileName).Replace("\\", "/");

                    Translator.Translate(r, Lang.ShortName, true);

                    message = r.Message;

                    if (r.Success)
                    {
                        uploaded = 1;
                    }
                }
                else
                {
                    message = GetText("CKManager", "msgNoFileUploaded");
                }
            }
            else
            {
                message = GetText("CKManager", "msgCsrfUploadDetected");
            }

            if (uploaded == 0)
                result = new { uploaded = 0, url = url, filename = filename, error = new { message } };
            else
                result = new { uploaded = 1, url = url, filename = filename };

            return Json(result);
        }
        [JsonAuthorize]
        public async Task<ActionResult> PUpload(string path)
        {
            var result = new ServiceResponse();
            var filename = "";
            var overrideMessage = false;

            if (Request.Files.Count > 0)
            {
                filename = Request.Form["name"];
                var data = await Request.Files[0].GetBytesAsync();

                result = await client.SaveFileAsync(path, filename, data, true);
            }
            else
            {
                result.Status = "NoFile";
                overrideMessage = true;
            }

            return SendJson(result, overrideMessage);
        }
        [OutputCache(Duration = 31536000, Location = System.Web.UI.OutputCacheLocation.Any)]
        public async Task<ActionResult> Icon(string type)
        {
            var bytes = await FileManagerHelper.GetImageAsync(type);

            return File(bytes, MimeHelper.GetMimeType(type));
        }
    }
}
