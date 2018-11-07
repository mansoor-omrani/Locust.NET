using Locust.FileManager.Web;
using Locust.MvcAttributes;
using Locust.Service;
using Locust.Web.Html;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Locust.FileManager.Mvc.Areas.FileManager.Controllers
{
    [RestrictMethod(Name = HttpMethod.Post)]
    [RestrictHeader(Name = "fmtoken", Key = "FileManagerRestrictHeaderToken")]
    public class FileController : Controller
    {
        private IFileManager filemanager;
        public FileController(IFileManager filemanager)
        {
            this.filemanager = filemanager;
        }
        private ActionResult GetResult(Func<ServiceResponse> fn)
        {
            var r = fn();

            return Content(JsonConvert.SerializeObject(r), "application/json");
        }
        public async Task<ActionResult> Save(string path, bool overwrite = false)
        {
            ServiceResponse r = null;
            HttpPostedFileBase file = null;

            if (Request.Files?.Count > 0)
            {
                if (Request.Files.Count == 1)
                {
                    file = Request.Files[0];

                    r = await filemanager.SaveFileAsync(path, file, overwrite, filemanager.SaveFileFilter, CancellationToken.None);
                }
                else
                {
                    r = await filemanager.SaveFilesAsync(path, Request.Files, overwrite, filemanager.SaveFileFilter, CancellationToken.None);
                }
            }

            return Content(JsonConvert.SerializeObject(r), "application/json");
        }
        public async Task<ActionResult> Get(string path)
        {
            var r = await filemanager.GetFileAsync(path);

            return Content(JsonConvert.SerializeObject(r), "application/json");
        }
        public ActionResult Delete(string path)
        {
            return GetResult(() => filemanager.DeleteFile(path));
        }
        public ActionResult DeleteMany(string[] paths)
        {
            return GetResult(() => filemanager.DeleteFiles(paths));
        }
        public ActionResult Move(string path, string newPath)
        {
            return GetResult(() => filemanager.MoveFile(path, newPath));
        }
        public ActionResult Rename(string path, string newname)
        {
            return GetResult(() => filemanager.RenameFile(path, newname));
        }
        public ActionResult Exists(string path)
        {
            return GetResult(() => filemanager.FileExists(path));
        }
        public ActionResult Info(string path)
        {
            return GetResult(() => filemanager.FileInfo(path));
        }
        public ActionResult Infos(string path)
        {
            return GetResult(() => filemanager.FileInfos(path));
        }
    }
}
