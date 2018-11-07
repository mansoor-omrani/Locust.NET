using Locust.WebTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.Test.Mvc.Areas.Test.Controllers
{
    public class BrowserController: ClientAwareController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
