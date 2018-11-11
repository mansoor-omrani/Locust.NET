using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Locust.Test.Web.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult AppPath()
        {
            var x = Locust.AppPath.ApplicationPath.HtmlAll();
            x = "<b>Root:</b>" + Locust.AppPath.ApplicationPath.Root + "<br/>" + x;

            return Content(x, "text/html");
        }
    }
}