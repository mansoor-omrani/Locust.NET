using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Locust.Test.Mvc;
using Locust.Translation;
using Locust.WebTools;

namespace Locust.Test.Mvc.Areas.Test.Controllers
{
    [TestAction]
    public class ServerVarsController : ClientAwareController
    {
        public ServerVarsController(ITranslator translator) : base(translator)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}