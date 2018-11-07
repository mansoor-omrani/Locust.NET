using Locust.WebTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.FileManager.CKEditor.Areas.CKManager.Controllers
{
    public class ImagesController: ClientAwareController
    {
        public ActionResult Index(string CKEditor = "", string CKEditorFuncNum = "", string langCode = "")
        {
            return Redirect($"/{Lang.ShortName}/ckmanager/files?CKEditor={CKEditor}&CKEditorFuncNum={CKEditorFuncNum}&langCode={langCode}#path=/&displayType=Thumbnail");
        }
    }
}
