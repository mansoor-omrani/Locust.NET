using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.WebTools
{
    public class MultiLanguageViewAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var cac = filterContext.Controller as ClientAwareControllerBase;

            if (cac != null)
            {
                cac.ViewBag.Translator = cac.Translator;
                cac.ViewBag.Lang = cac.Lang;
            }
        }
    }
}
