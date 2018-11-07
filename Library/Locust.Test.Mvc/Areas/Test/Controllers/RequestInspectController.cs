using Locust.WebTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Locust.Translation;

namespace Locust.Test.Mvc.Areas.Test.Controllers
{
    [TestAction]
    public class RequestInspectController : ClientAwareController
    {
        public RequestInspectController(ITranslator translator) : base(translator)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
