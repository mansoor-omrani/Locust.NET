using Locust.FileManager.Client;
using Locust.Logging;
using Locust.MvcAttributes;
using Locust.Notification;
using Locust.Service;
using Locust.Translation;
using Locust.WebTools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.FileManager.CKEditor.Areas.CKManager.Controllers
{
    [JsonAuthorize]
    public class FoldersController: CKManagerBaseController
    {
        public FoldersController(IFileManagerClient client,
                                ITranslator translator,
                                ILogger logger,
                                IExceptionLogger exceptionLogger,
                                INotificationService notification) : base(client, translator, logger, exceptionLogger, notification)
        {
        }
        [HttpPost]
        public async Task<ActionResult> Index(string path)
        {
            var dr = await client.GetSubDirectoriesAsync(path);

            return await SendJsonAsync(dr, new { Path = path }, $"error getting list of sub-directories: {path}");
        }
        [HttpPost]
        public async Task<ActionResult> Create(string path)
        {
            var dr = await client.CreateDirAsync(path);

            return await SendJsonAsync(dr, new { Path = path }, $"error creating directory: {path}");
        }
        [HttpPost]
        public async Task<ActionResult> Move(string path, string newPath)
        {
            var dr = await client.MoveDirAsync(path, newPath);

            return await SendJsonAsync(dr, new { Path = path, NewPath = newPath }, $"error moving directory: {path}");
        }
        [HttpPost]
        public async Task<ActionResult> Rename(string path, string newname)
        {
            var dr = await client.RenameDirAsync(path, newname);

            return await SendJsonAsync(dr, new { Path = path, NewName = newname }, $"error renaming directory: {path}");
        }
        [HttpPost]
        public async Task<ActionResult> Remove(string path)
        {
            var dr = await client.DeleteDirAsync(path);

            return await SendJsonAsync(dr, new { Path = path }, $"error removing directory: {path}");
        }
    }
}
