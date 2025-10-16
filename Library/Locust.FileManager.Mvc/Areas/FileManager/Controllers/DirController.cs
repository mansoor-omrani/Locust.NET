using Locust.MvcAttributes;
using Locust.Service;
using Locust.Web.Html;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.FileManager.Mvc.Areas.FileManager.Controllers
{
    [RestrictMethod(Name = "POST")]
    [RestrictHeader(Name = "fmtoken", Key = "FileManagerRestrictHeaderToken")]
    public class DirController: Controller
    {
        private IFileManager filemanager;
        public DirController(IFileManager filemanager)
        {
            this.filemanager = filemanager;
        }
        private ActionResult GetResult(Func<ServiceResponse> fn)
        {
            var r = fn();

            return Content(JsonConvert.SerializeObject(r), "application/json");
        }
        public ActionResult Create(string path)
        {
            return GetResult(() => filemanager.CreateDir(path));
        }
        public ActionResult Delete(string path, bool recursive = false)
        {
            return GetResult(() => filemanager.DeleteDir(path, recursive));
        }
        public ActionResult Move(string path, string newPath)
        {
            return GetResult(() => filemanager.MoveDir(path, newPath));
        }
        public ActionResult Rename(string path, string newname)
        {
            return GetResult(() => filemanager.RenameDir(path, newname));
        }
        public ActionResult Exists(string path)
        {
            return GetResult(() => filemanager.DirExists(path));
        }
        public ActionResult Info(string path)
        {
            return GetResult(() => filemanager.DirInfo(path));
        }
        public ActionResult Size(string path)
        {
            return GetResult(() => filemanager.DirSize(path));
        }
        public ActionResult SubDirs(string path)
        {
            return GetResult(() => filemanager.GetSubDirectories(path));
        }
        public ActionResult Files(string path)
        {
            return GetResult(() => filemanager.GetFiles(path));
        }
    }
}
