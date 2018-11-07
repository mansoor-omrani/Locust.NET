using Locust.Service;
using Locust.Translation;
using Locust.WebTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.Test.Mvc.Areas.Test.Controllers
{
    public class TranslationController : ClientAwareController
    {
        public TranslationController(ITranslator translator):base(translator)
        {
        }
        [TestAction]
        public ActionResult Index()
        {
            ViewBag.TranslatorType = Translator.GetType().Name;
            ViewBag.Items = Translator.GetAll();

            return View();
        }
        [TestAction]
        public ActionResult Load()
        {
            var result = new ServiceResponse();

            Translator.Load();

            result.Success = true;
            
            return Json(result);
        }
    }
}
